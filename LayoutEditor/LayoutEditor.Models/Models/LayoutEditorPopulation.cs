using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Serialization;
//#if SILVERLIGHT
//using LayoutEditorSilverlight4.ServiceReferenceLayouts;
//#endif

namespace Layout
{
    [XmlRoot("LayoutEditorPopulation")]
    public class LayoutEditorPopulation
    {
        List<List<int>> matchedTypes;

        [XmlAttribute]
        public int Width { get; set; }  // Note, this is used instead of LayoutDimensions class, to ensure XmlAttributes are applied as required

        [XmlAttribute]
        public int Height { get; set; }

        [XmlAttribute]
        public string Default { get; set; }

        [XmlAttribute]
        public bool EraseOnly { get; set; }

        [XmlAttribute]
        public bool RackMode { get; set; }

        public List<SampleType> SampleTypes { get; set; }

        public List<Rule> Rules { get; set; }

        /// <summary>
        /// Whether the editor should provide multiple layout functionality
        /// </summary>
        [XmlAttribute]
        public bool IsMultiple { get; set; }
        /// <summary>
        /// String, used to represent the real world container type
        /// </summary>
        [XmlAttribute]
        public string ContainerName { get; set; }
        /// <summary>
        /// Describes how the multiple layout editor is arranged and behaves
        /// </summary>
        [XmlAttribute]
        public string MultipleLayout { get; set; }
        /// <summary>
        /// If true then for each container a Calibrator group can be selected
        /// </summary>
        [XmlAttribute]
        public bool SelectCalibratorsPerContainer { get; set; }
        /// <summary>
        /// A CSV list of SampleType IDs which represent the available Calibrators (as used by SelectCalibratorsPerContainer and elsewhere)
        /// </summary>
        [XmlAttribute]
        public string CalibratorGroups { get; set; }
        /// <summary>
        /// If True then the SampleType bar groups all calibrator types (as specified by CalibratorGroups) to a single item.  
        /// Alongside the item a selector button can be used to display all other sample types for selection..
        /// This single item displays the name of the last selected calibrator type (or the first if there was none previously selected).
        /// When the selector button is pushed a list box of the other calibrator types appears and any item including the original selection can be picked).
        /// </summary>
        [XmlAttribute]
        public bool GroupCalibratorTypes { get; set; }
        /// <summary>
        /// The group numbering
        /// </summary>
        [XmlAttribute]
        public string GroupNumbering { get; set; }

        public LayoutEditorPopulation()
        {
            Rules = new List<Rule>();
            ContainerName = "Plate";
            MultipleLayout = LayoutEditor.Enums.MultipleLayoutType.ThumbsVertical.ToString();
            GroupNumbering = LayoutEditor.Enums.GroupNumbering.Absolute.ToString();
        }
        /// <summary>
        /// Getting GroupNumbering attribute as Enum
        /// </summary>
        /// <returns></returns>
        public LayoutEditor.Enums.GroupNumbering GetGroupNumberingEnum()
        {
            LayoutEditor.Enums.GroupNumbering g;
            return Enum.TryParse(GroupNumbering, true, out g) ? g : LayoutEditor.Enums.GroupNumbering.Absolute;
        }
        /// <summary>
        /// Getting MultipleLayout attribute as Enum
        /// </summary>
        /// <returns></returns>
        public LayoutEditor.Enums.MultipleLayoutType GetMultipleLayoutEnum()
        {
            LayoutEditor.Enums.MultipleLayoutType g;
            return Enum.TryParse(MultipleLayout, true, out g) ? g : LayoutEditor.Enums.MultipleLayoutType.ThumbsVertical;
        }
        /// <summary>
        /// When EraseOnly is true, only groups which do not have NumGroups set can be erased 
        /// or any types not mentioned in any rules
        /// (This ignores the fact that MinNumGroups might be set to 1)
        /// </summary>
        /// <returns></returns>
        public List<int> GetErasableTypes()
        {
            if (EraseOnly == false)
                throw new InvalidOperationException("Erasable types are only relevant when EraseMode is true.");

            var allUsedTypeIds = SampleTypes.Where(x => x.Id != 1).Select(x => x.Id);
            var typeIdsUsedInRules = Rules.Select(x => x.TypeId).Distinct();
            var typeIdsNotUsedInRules = allUsedTypeIds.Where(x => !typeIdsUsedInRules.Contains(x)).Select(x => x);

            // Get any of the rules where NumGroups is not specified
            var rulesWithNoNumGroups = Rules.Where(x => x.NumGroups == 0).Select(x => x.TypeId).Distinct();

            // Get any of the rules where NumGroups is not specified
            return rulesWithNoNumGroups.Concat(typeIdsNotUsedInRules).ToList();
        }

        public IEnumerable<int> GetMergedTypesSingle()
        {
            // Currently this implementation assumes that there is only 1 set of merged types
            // If there are 2 sets of merged types this won't work properly
            var mergedTypes = new List<int>();
            var mergeRules = Rules.Where(x => x.MergeGroupsWithType != 0);

            foreach (var mergeRule in mergeRules)
            {
                mergedTypes.Add(mergeRule.MergeGroupsWithType);
                mergedTypes.Add(mergeRule.TypeId);
            }
            return mergedTypes.Distinct();
        }
        /// <summary>
        /// Returns a list of matched type groups, i.e. each item in the list is itself a list of types that match each other.  
        /// Does not include Unused
        /// Each type will only appear in one list.
        /// If a type is not matched it is not included
        /// </summary>
        /// <returns></returns>
        public List<List<int>> GetMatchedTypes()
        {
            Debug.Assert(SampleTypes != null);
            Debug.Assert(SampleTypes.Count > 0);

            // Setup a list of matchedTypes (i.e. each list contains types that are matched together)
            List<List<int>> matchedTypes = new List<List<int>>();

            // Initially each list will contain each sample type (i.e. 1 list for each type)
            var typeIds = from t in SampleTypes where (t.Id != 1) select t.Id;

            foreach (int typeId in typeIds)
            {
                List<int> list = new List<int>();
                list.Add(typeId);
                matchedTypes.Add(list);
            }

            // Move all matched types into the same list
            var matchPairs = from rule in Rules where rule.MatchGroupsInTypeId != 0 select new { A = rule.TypeId, B = rule.MatchGroupsInTypeId };

            foreach (var pair in matchPairs)
            {
                // Find which lists A or B are in separately (but not together)
                // i.e. thoses lists which include A but not B or B but not A
                var lists = from matchList in matchedTypes
                            where
                                ((matchList.Contains(pair.A) && !matchList.Contains(pair.B)) ||
                                (!matchList.Contains(pair.A) && matchList.Contains(pair.B)))
                            select matchList;

                // Determine the longest list (note this must be done before items are removed as the query is reused)
                var longestList = (from matchList in lists orderby matchList.Count descending select matchList).First();

                // Make sure both A+B only exist in one list 1
                // First remove A+B from all the lists that they currently belong to
                // Then add A+B to the list (of these matched types) currently with the greatest length (or the first)
                foreach (var list in lists)
                {
                    list.Remove(pair.A);
                    list.Remove(pair.B);
                }

                longestList.Add(pair.A);
                longestList.Add(pair.B);
            }

            // Only provide the lists that have more than 1 types matched 
            // (Lists with only 1 type have no matches so are excluded)
            List<List<int>> result = (from matchList in matchedTypes
                                      where matchList.Count > 1
                                      select matchList).ToList();
            int numGroupsSpecified = 0;

            // Go through each matched type group, find the NumGroups specified for each type and check it is either not specified or consistent 
            // This is a check to ensure the XML has been setup correctly.
            foreach (List<int> matchList in result)
            {
                foreach (int type in matchList)
                {
                    // Find rules which reference this type and set NumGroups 
                    var v = (from rule in Rules where (((rule.TypeId == type) || (rule.MatchGroupsInTypeId == type)) && rule.NumGroups != 0) select rule.NumGroups).Distinct();
                    int numDifferentNumGroupsSpecified = v.Count();
                    if (numDifferentNumGroupsSpecified > 1)
                    {
                        throw new ArgumentException("The NumGroups specified for each of the matched type rules is inconsistent.");
                    }
                    if (numGroupsSpecified == 0)
                    {
                        numGroupsSpecified = v.FirstOrDefault();
                    }
                    else
                    {
                        int firstOrDefault = v.FirstOrDefault();
                        if (firstOrDefault != 0)
                        {
                            if (numGroupsSpecified != firstOrDefault)
                            {
                                throw new ArgumentException(string.Format("The NumGroups specified for each of the matched type rules is inconsistent, one group specified {0} and another specified {1} NumGroups", numGroupsSpecified, firstOrDefault));
                            }
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Returns a list of all types matched to the specified type INCLUDING this the specified type
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public List<int> GetTypeMatches(int typeId)
        {
            if (this.matchedTypes == null)
                this.matchedTypes = GetMatchedTypes();
            return (from list in this.matchedTypes where list.Contains(typeId) select list).FirstOrDefault();      // FirstOrDefault returns first or null (in this case) if there are no elements
        }
    }
}