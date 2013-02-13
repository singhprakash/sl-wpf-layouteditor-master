using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Layout
{
    /// <summary>
    /// Single pass analysis of the layout, i.e. sets up accessors to retrieve all layout/well/group information with a single lookup
    /// </summary>
    public class LayoutAnalysis
    {
#if !SILVERLIGHT 
        [global::System.Serializable]
#endif
        public class InvalidLayoutException : Exception
        {
            //
            // For guidelines regarding the creation of new exception types, see
            //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
            // and
            //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
            //

            public InvalidLayoutException() { }
            public InvalidLayoutException(string message) : base(message) { }
            public InvalidLayoutException(string message, Exception inner) : base(message, inner) { }

#if !SILVERLIGHT 
            protected InvalidLayoutException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
#endif
        }

        class TypeInfo
        {
            public TypeInfo(int typeId)
            {
                this.TypeId = typeId;
            }

            public int TypeId;
            public int WellCount;       // Number of wells of each type
            public int GroupCount;      // Number of groups of each type 
            public int LowestGroupNum = int.MaxValue;
            public int HighestGroupNum = int.MinValue;
            public int[] ReplicateCount;
            public bool ReplicateConsistent;
        }

        public string GetSampleTypeNameFromTypeId(int typeId)
        {
            foreach (SampleType sampleType in this.sampleTypes)
            {
                if (sampleType.Id == typeId)
                    return sampleType.Name;
            }

            throw new ArgumentException(string.Format("There is no typeId: {0} in SampleTypes", typeId));
        }


        /// <summary>
        /// Display a name useful for display e.g. "Unknown1" or "Unknown 1:100-1"
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="groupNum"></param>
        /// <returns></returns>
        public string GetGroupNameForDisplay(int typeId, int groupNum)
        {
            string typeName = GetSampleTypeNameFromTypeId(typeId);

            if (char.IsDigit(typeName[typeName.Length - 1]))
            {
                return string.Format("{0}-{1}", typeName, groupNum);
            }
            else
            {
                return string.Format("{0}{1}", typeName, groupNum);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layout"></param>
        /// <param name="sampleTypes"></param>
        /// <param name="mergedTypesSingle">Type IDs which can be merged together, there are special rules when merged types are used</param>
        public LayoutAnalysis(List<LayoutPosEditor> layout, List<SampleType> sampleTypes,
            bool groupNumberingMustStartFromOneForNonMergedTypes, IEnumerable<int> mergedTypesSingle = null)
        {
            this.layout = layout;
            this.sampleTypes = sampleTypes;

            this.typeInfoDictionary = new Dictionary<int, TypeInfo>();

            foreach (SampleType sampleType in sampleTypes)
            {
                this.typeInfoDictionary.Add(sampleType.Id, new TypeInfo(sampleType.Id));
            }

            foreach (LayoutPosEditor lpe in this.layout)
            {
                try
                {
                    TypeInfo typeInfo = this.typeInfoDictionary[lpe.LayoutPos.TypeId];

                    // Determine how many wells there are of each type
                    typeInfo.WellCount++;

                    if (typeInfo.TypeId != 1)
                    {
                        // Store lowest and highest group number of each type
                        if (lpe.LayoutPos.Group > typeInfo.HighestGroupNum)
                        {
                            typeInfo.HighestGroupNum = lpe.LayoutPos.Group;
                        }
                        if (lpe.LayoutPos.Group < typeInfo.LowestGroupNum)
                        {
                            typeInfo.LowestGroupNum = lpe.LayoutPos.Group;
                        }
                    }
                    else
                    {
                        // Unused does not have group numbering
                        typeInfo.HighestGroupNum = typeInfo.LowestGroupNum = 0;
                    }
                }
                catch (KeyNotFoundException)
                {
                    // This can occur when the SampleTypes used in the UserLayout do not correspond with those used in a LayoutPopulationEditor
                    throw new InvalidLayoutException(string.Format("A layout position references a typeId {0} which is not listed in the SampleTypes. ", lpe.LayoutPos.TypeId));
                }
            }

            // Determine the group count using the 
            foreach (TypeInfo typeInfo in this.typeInfoDictionary.Values)
            {
                if (typeInfo.TypeId != 1)  // Group counts only relevant for non-unused
                {
                    if ((typeInfo.HighestGroupNum == int.MinValue) && (typeInfo.LowestGroupNum == int.MaxValue))
                    {
                        typeInfo.GroupCount = 0;
                    }
                    else
                    {
                        bool isTypeMerged = false;
                        if (mergedTypesSingle != null)
                        {
                            isTypeMerged = mergedTypesSingle.Contains(typeInfo.TypeId);
                        }

                        // Skip checking for starting from 1 here if type is merged - check that later
                        if (!isTypeMerged && groupNumberingMustStartFromOneForNonMergedTypes)
                        {
                            if (typeInfo.LowestGroupNum != 1)
                            {
                                throw new InvalidLayoutException(string.Format("The group numbering for type {0} does not start at 1. ", GetSampleTypeNameFromTypeId(typeInfo.TypeId)));
                            }
                        }

                        typeInfo.GroupCount = 1 + (typeInfo.HighestGroupNum - typeInfo.LowestGroupNum);
                        typeInfo.ReplicateCount = new int[typeInfo.GroupCount];
                    }
                }
            }

            // Go through the layout again and count the number of replicates in each group
            foreach (LayoutPosEditor lpe in this.layout)
            {
                if (lpe.LayoutPos.TypeId != 1) // Group counts only relevant for non-unused
                {
                    TypeInfo typeInfo = this.typeInfoDictionary[lpe.LayoutPos.TypeId];

                    int index = lpe.LayoutPos.Group - typeInfo.LowestGroupNum;
                    Debug.Assert(index >= 0);
                    Debug.Assert(index < typeInfo.ReplicateCount.Length);

                    typeInfo.ReplicateCount[index]++;
                }
            }


            // Check number of members/replicates in each group to see if they are:
            // 1: Consistent or not (i.e. all groups of this type have the same number of replicates) - set ReplicateConsistent accordingly
            // 2: They are all non-zero (so that group numering is contiguous)
            foreach (TypeInfo typeInfo in this.typeInfoDictionary.Values)
            {
                if (typeInfo.TypeId != 1) // Group counts only relevant for non-unused
                {
                    if (typeInfo.GroupCount > 0)
                    {
                        bool isTypeMerged = false;
                        if (mergedTypesSingle != null)
                        {
                            isTypeMerged = mergedTypesSingle.Contains(typeInfo.TypeId);
                        }

                        int firstReplicateCount = typeInfo.ReplicateCount[0];

                        typeInfo.ReplicateConsistent = true;

                        for (int groupNum = 1; groupNum < typeInfo.ReplicateCount.Length; groupNum++)
                        {
                            int replicatesInGroup = typeInfo.ReplicateCount[groupNum];

                            // Only check for contiguous-ness if this is NOT a merged type
                            if (!isTypeMerged)
                            {
                                if (replicatesInGroup == 0)
                                {
                                    throw new InvalidLayoutException(string.Format("The group numbering is not contiguous in type {0}, there is no {0}{1}. ", GetSampleTypeNameFromTypeId(typeInfo.TypeId), groupNum + typeInfo.LowestGroupNum));
                                }
                            }

                            if (replicatesInGroup != firstReplicateCount)
                            {
                                typeInfo.ReplicateConsistent = false;
                            }
                        }
                    }
                }
            }

            if (mergedTypesSingle != null)
            {
                // When merged types are used - check that the merged types result in contiguous group numbering starting from 1
                if (mergedTypesSingle.Any())
                {
                    var toCheck = from TypeInfo typeInfo in this.typeInfoDictionary.Values
                                  where mergedTypesSingle.Contains(typeInfo.TypeId)
                                  select typeInfo;

                    var maxNumGroupsInAllTypes = (from item in toCheck select item.HighestGroupNum).Max();

                    if (maxNumGroupsInAllTypes != int.MinValue)
                    {
                        VerifyMergedGroups(mergedTypesSingle, maxNumGroupsInAllTypes, toCheck);
                    }
                }
            }
        }

        private void VerifyMergedGroups(IEnumerable<int> mergedTypesSingle, int maxNumGroupsInAllTypes, IEnumerable<TypeInfo> toCheck)
        {
            var mergedGroupsUsed = new int[maxNumGroupsInAllTypes];

            foreach (var item in toCheck)
            {
                bool noGroupsOfThisType = (item.LowestGroupNum == int.MaxValue) &&
                                          (item.HighestGroupNum == int.MinValue);

                if (!noGroupsOfThisType)
                {
                    int numGroupsInType = 1 + (item.HighestGroupNum - item.LowestGroupNum);
                    for (int zGroupNum = 0; zGroupNum < numGroupsInType; zGroupNum++)
                    {
                        mergedGroupsUsed[item.LowestGroupNum + zGroupNum - 1] +=
                            item.ReplicateCount[zGroupNum];
                    }
                }
            }

            // Check group numbering starts at 1
            if (mergedGroupsUsed[0] == 0) // 1 based
            {
                string names = GetSampleTypeNamesFromTypeIds(mergedTypesSingle, "and/or");
                throw new InvalidLayoutException(
                    string.Format("The group numbering should start from 1 for {0}.", names));
            }

            // Check contiguous
            var missingGroups =
                mergedGroupsUsed.Select((item, index) => new { Item = item, Index = index })
                                .Where(x => x.Item == 0);
            if (missingGroups.Any())
            {
                string names = GetSampleTypeNamesFromTypeIds(mergedTypesSingle, "and");
                throw new InvalidLayoutException(string.Format(
                    "The group numbering is not contiguous in types {0}, there is no group {1}.",
                    names, missingGroups.First().Index + 1));
            }
        }

        private string GetSampleTypeNamesFromTypeIds(IEnumerable<int> mergedTypesSingle, string conjunction)
        {
            var names = (from typeId in mergedTypesSingle select GetSampleTypeNameFromTypeId(typeId)).ToList();

            int numItems = names.Count();

            if (numItems == 1) return names[0];

            if (numItems == 2) return string.Format("{0} {1} {2}", names[0], conjunction, names[1]);

            var sb = new StringBuilder();

            for (int i = 0; i < numItems; i++)
            {
                sb.Append(names[0]);
                if (i == numItems - 1)
                {
                    sb.Append(" " + conjunction + " ");
                }
                else if (i < numItems - 1)
                {
                    sb.Append(", ");
                }
            }

            return sb.ToString();

        }

        Dictionary<int, TypeInfo> typeInfoDictionary;

        public int GetNumWellsOfType(int typeId)
        {
            if (typeId == 0)
            {
                throw new ArgumentException("Invalid typeId");
            }

            try
            {
                return this.typeInfoDictionary[typeId].WellCount;
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
        }

        private TypeInfo GetTypeInfo(int typeId)
        {
            if (typeId == 0)
            {
                throw new ArgumentException("Invalid typeId");
            }

            if (typeId == 1)
            {
                throw new ArgumentException("Cannot get information for Unused type");
            }

            try
            {
                return this.typeInfoDictionary[typeId];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }


        public int GetNumGroupsOfType(int typeId)
        {
            TypeInfo typeInfo = GetTypeInfo(typeId);

            if (typeInfo == null)
                return 0;

            return typeInfo.GroupCount;
        }


        public bool GetReplicatesConsistent(int typeId)
        {
            TypeInfo typeInfo = GetTypeInfo(typeId);

            // If no groups of this type then this is undefined
            if (typeInfo == null)
            {
                throw new ArgumentException(string.Format("There are no groups of typeId: {0}", typeId));
            }

            return typeInfo.ReplicateConsistent;
        }

        public int GetLowestGroupNum(int typeId)
        {
            TypeInfo typeInfo = GetTypeInfo(typeId);

            // If no groups of this type then this is undefined
            if (typeInfo == null)
            {
                throw new ArgumentException(string.Format("There are no groups of typeId: {0}", typeId));
            }

            return typeInfo.LowestGroupNum;
        }


        /// <summary>
        /// Gets the number of replciates from a 0 based group index number (where 0 is the first group
        /// on the layout
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetNumReplicatesZeroIndex(int typeId, int groupIndex)
        {
            if (groupIndex < 0)
            {
                throw new ArgumentException("Index number must be 0 or greater");
            }

            TypeInfo typeInfo = GetTypeInfo(typeId);

            if (typeInfo == null)
                return 0;

            // If index is out of the range (i.e. there is no group as specified) then report 0 replicates
            if (groupIndex >= typeInfo.ReplicateCount.Length)
            {
                return 0;
            }

            return typeInfo.ReplicateCount[groupIndex];
        }

        public int GetNumReplicates(int typeId, int groupNum)
        {
            if (groupNum == 0)
            {
                throw new ArgumentException("Group numbering must be 1 or greater");
            }

            TypeInfo typeInfo = GetTypeInfo(typeId);

            if (typeInfo == null)
                return 0;

            int index = groupNum - typeInfo.LowestGroupNum;

            // If Index is < 0 then there is no group with that number (this can happen if the first group number is 2 and not 1 as it should be)
            // Note that when using MultiDilutionGroup, group numbering does not have to be sequential or start from zero.
            if (index < 0)
            {
                return 0;
            }
            Debug.Assert(index >= 0);

            // If index is out of the range (i.e. there is no group as specified) then report 0 replicates
            if (index >= typeInfo.ReplicateCount.Length)
            {
                return 0;
            }

            return typeInfo.ReplicateCount[index];
        }

        public int GetFirstGroupWhichDoesNotHaveSpecifiedReplicates(int typeId, int replicates)
        {
            TypeInfo typeInfo = GetTypeInfo(typeId);

            if (typeInfo == null)
                return 0;

            //if (GetReplicatesConsistent(typeId))
            //{
            //    throw new ArgumentException(string.Format("All groups of typeId: {0} have the same number of replicates."));
            //}

            for (int index = 0; index < typeInfo.ReplicateCount.Length; index++)
            {
                if (typeInfo.ReplicateCount[index] != replicates)
                {
                    return index + typeInfo.LowestGroupNum;
                }
            }

            throw new ArgumentException(string.Format("All groups of typeId: {0} have {1} replicates.", replicates));
        }



        private List<LayoutPosEditor> layout;
        private List<SampleType> sampleTypes;
    }
}