using System.Collections.Generic;
using System.Diagnostics;

namespace Layout
{
    public class ValidationError
    {
        public enum ErrorType
        {
            InvalidLayout,      // A problem with the layout (not a specific rule)
            RuleFailed          // A rule failed
        };

        public string Message { get; set; }
        public ErrorType Type { get; set; }
        public Rule Rule { get; set; }  // If ErrorType is RuleFailed, this is the rule that failed rule
    };

    /// <summary>
    /// Tests the LayoutEditorPopulation rules against the SingleLayoutEditor state
    /// </summary>
    public static class LayoutValidation
    {
        /// <summary>
        /// Validates the passed in state with the LayoutEditorPopulation, note that the SampleTypes are as specified in the LayoutEditorPopulation
        /// </summary>
        /// <param name="state"></param>
        /// <param name="layoutEditorPopulation"></param>
        /// <returns></returns>
        static public List<ValidationError> Validate(SingleLayoutEditor state, LayoutEditorPopulation layoutEditorPopulation)
        {
            List<ValidationError> errors = new List<ValidationError>();

            // Check the state is setup correctly
            Debug.Assert(state.NumPositions == state.Width * state.Height);
            Debug.Assert(state.NumPositions == state.LayoutPositions.Count);

            if ((layoutEditorPopulation.Width != state.Width) || (layoutEditorPopulation.Height != state.Height))
            {
                errors.Add(new ValidationError()
                {
                    Type = ValidationError.ErrorType.InvalidLayout,
                    Message = string.Format("The layout dimensions are not correct, they should be {0}x{1}. ", layoutEditorPopulation.Width, layoutEditorPopulation.Height)
                });
                return errors;
            }

            try
            {
                var mergedTypesSingle = layoutEditorPopulation.GetMergedTypesSingle();

                LayoutAnalysis layoutAnalysis = new LayoutAnalysis(state.LayoutPositions, layoutEditorPopulation.SampleTypes,
                    true,   // groupNumberingMustStartFromOne - for types that are NOT merged
                    mergedTypesSingle);

                foreach (Rule rule in layoutEditorPopulation.Rules)
                {
                    TestRule(rule, layoutAnalysis, errors);
                }
            }
            catch (Layout.LayoutAnalysis.InvalidLayoutException invalidLayoutException)
            {
                // Convert the InvalidLayoutException into a message.
                errors.Add(new ValidationError()
                {
                    Type = ValidationError.ErrorType.InvalidLayout,
                    Message = invalidLayoutException.Message
                });
            }

            return errors;
        }

        public static void TestRule(Rule rule, LayoutAnalysis layoutAnalysis, List<ValidationError> errors)
        {
            #region Group Count Tests
            int numGroupsOfType = layoutAnalysis.GetNumGroupsOfType(rule.TypeId);

            // If the rule specifies that both max and min are equal and NumGroups is not set then set NumGroups accordingly.
            if ((rule.MaxNumGroups == rule.MinNumGroups) && (rule.NumGroups == 0))
            {
                rule.NumGroups = rule.MaxNumGroups;
            }

            if (rule.NumGroups != 0)
            {
                if (rule.NumGroups != numGroupsOfType)
                {
                    errors.Add(CreateValidationErrorRule(rule,
                                string.Format("There should be {0} {1} group(s), there are {2} {1} group(s). ",
                                rule.NumGroups, layoutAnalysis.GetSampleTypeNameFromTypeId(rule.TypeId), numGroupsOfType)));
                }
            }
            else
            {
                if ((rule.MinNumGroups != 0) && (numGroupsOfType < rule.MinNumGroups))
                {
                    errors.Add(CreateValidationErrorRule(rule,
                                string.Format("There should be at least {0} {1} group(s), there are {2} {1} group(s). ",
                                rule.MinNumGroups, layoutAnalysis.GetSampleTypeNameFromTypeId(rule.TypeId), numGroupsOfType)));
                }

                if ((rule.MaxNumGroups != 0) && (numGroupsOfType > rule.MaxNumGroups))
                {
                    errors.Add(CreateValidationErrorRule(rule,
                                string.Format("There should be no more than {0} {1} group(s), there are {2} {1} group(s). ",
                                rule.MaxNumGroups, layoutAnalysis.GetSampleTypeNameFromTypeId(rule.TypeId), numGroupsOfType)));
                }
            }
            #endregion

            #region Replicate Count Tests
            // The replicate rules are only applied if there are actually groups of this type.
            if (numGroupsOfType > 0)
            {
                // If the rule specifies that both max and min are equal and NumReplicates is not set then set NumReplicates accordingly.
                if ((rule.MaxNumReplicates == rule.MinNumReplicates) && (rule.NumReplicates == 0))
                {
                    rule.NumReplicates = rule.MaxNumReplicates;
                }

                bool replicatesConsistent = layoutAnalysis.GetReplicatesConsistent(rule.TypeId);

                if ((rule.AllGroupsSameReplicates) && (!replicatesConsistent))
                {
                    errors.Add(CreateValidationErrorRule(rule,
                                string.Format("All {0} groups should have the same number of replicates, this is not the case. ",
                                layoutAnalysis.GetSampleTypeNameFromTypeId(rule.TypeId))));
                }

                if (rule.NumReplicates != 0)
                {
                    // If a specific number of replicates has been specified but there are different replicates in each group then 
                    if (!replicatesConsistent)
                    {
                        int firstGroupWithWrongReplicates = layoutAnalysis.GetFirstGroupWhichDoesNotHaveSpecifiedReplicates(rule.TypeId, rule.NumReplicates);
                        int wrongReplicates = layoutAnalysis.GetNumReplicates(rule.TypeId, firstGroupWithWrongReplicates);
                        errors.Add(CreateValidationErrorRule(rule,
                                    string.Format("All {1} groups should have {0} replicates, {2} has {3} replicate(s). ",
                                        rule.NumReplicates,
                                        layoutAnalysis.GetSampleTypeNameFromTypeId(rule.TypeId),
                                        layoutAnalysis.GetGroupNameForDisplay(rule.TypeId, firstGroupWithWrongReplicates),
                                        wrongReplicates)));
                    }
                    else
                    {
                        // All groups are replicate consistent, so just get the first group to check
                        int numReplicates = layoutAnalysis.GetNumReplicates(rule.TypeId, 1);

                        if (rule.NumReplicates != numReplicates)
                        {
                            errors.Add(CreateValidationErrorRule(rule,
                                        string.Format("There should be {0} replicate(s) in each {1} group, each {1} group has {2} replicate(s). ",
                                        rule.NumReplicates, layoutAnalysis.GetSampleTypeNameFromTypeId(rule.TypeId), numReplicates)));
                        }
                    }
                }
                else
                {
                    // If the replicates on the layout are inconsistent AND this is allowed then (with AllGroupsSameReplicates="false")
                    // check that each group follows the min/max rules 
                    if (!replicatesConsistent)
                    {
                        if (!rule.AllGroupsSameReplicates)
                        {
                            // Go through each group and check that it matches the min/max rules
                            for (int index = 0; index < numGroupsOfType; index++)
                            {
                                int numReplicates = layoutAnalysis.GetNumReplicatesZeroIndex(rule.TypeId, index);

                                if ((rule.MinNumReplicates != 0) && (numReplicates < rule.MinNumReplicates))
                                {
                                    errors.Add(CreateValidationErrorRule(rule,
                                                string.Format("There should be at least {0} replicate(s) in each {1} group, {3} has {2} replicate(s). ",
                                                    rule.MinNumReplicates,
                                                    layoutAnalysis.GetSampleTypeNameFromTypeId(rule.TypeId),
                                                    numReplicates,
                                                    layoutAnalysis.GetGroupNameForDisplay(rule.TypeId, index + layoutAnalysis.GetLowestGroupNum(rule.TypeId)))));
                                }

                                if ((rule.MaxNumReplicates != 0) && (numReplicates > rule.MaxNumReplicates))
                                {
                                    errors.Add(CreateValidationErrorRule(rule,
                                                string.Format("There should be no more than {0} replicate(s) in each {1} group, {3} has {2} replicate(s). ",
                                                    rule.MaxNumReplicates,
                                                    layoutAnalysis.GetSampleTypeNameFromTypeId(rule.TypeId),
                                                    numReplicates,
                                                    layoutAnalysis.GetGroupNameForDisplay(rule.TypeId, index + layoutAnalysis.GetLowestGroupNum(rule.TypeId)))));
                                }
                            }
                        }
                    }
                    else
                    {
                        // Only get and check replicates if this rule requires it:
                        if ((rule.MinNumReplicates != 0) || (rule.MaxNumReplicates != 0))
                        {
                            // The replicates on the layout are consistent
                            // In this case it does not matter whether AllGroupsSameReplicates is true or false 
                            // All groups are replicate consistent, so just get the first group to check
                            int numReplicates = layoutAnalysis.GetNumReplicates(rule.TypeId, 1);

                            if ((rule.MinNumReplicates != 0) && (numReplicates < rule.MinNumReplicates))
                            {
                                errors.Add(CreateValidationErrorRule(rule,
                                            string.Format("There should be at least {0} replicate(s) in each {1} group, there are {2} replicates in all {1} group(s). ",
                                            rule.MinNumReplicates, layoutAnalysis.GetSampleTypeNameFromTypeId(rule.TypeId), numReplicates)));
                            }

                            if ((rule.MaxNumReplicates != 0) && (numReplicates > rule.MaxNumReplicates))
                            {
                                errors.Add(CreateValidationErrorRule(rule,
                                            string.Format("There should be no more than {0} replicate(s) in each {1} group, there are {2} replicates in all {1} group(s). ",
                                            rule.MaxNumReplicates, layoutAnalysis.GetSampleTypeNameFromTypeId(rule.TypeId), numReplicates)));
                            }
                        }
                    }
                }
            }
            #endregion

            if (rule.MatchGroupsInTypeId != 0)
            {
                int numGroupsOfMatchedType = layoutAnalysis.GetNumGroupsOfType(rule.MatchGroupsInTypeId);

                if (numGroupsOfMatchedType != numGroupsOfType)
                {
                    errors.Add(CreateValidationErrorRule(rule,
                                string.Format("The number of {0} groups ({1}) should equal the number of {2} groups ({3}). ",
                                layoutAnalysis.GetSampleTypeNameFromTypeId(rule.TypeId), numGroupsOfType,
                                layoutAnalysis.GetSampleTypeNameFromTypeId(rule.MatchGroupsInTypeId), numGroupsOfMatchedType
                                )));

                }
            }
        }

        private static ValidationError CreateValidationErrorRule(Rule rule, string message)
        {
            return new ValidationError() { Message = message, Rule = rule, Type = ValidationError.ErrorType.RuleFailed };
        }
    }
}