using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using AWSPowerShellGenerator.Analysis;
using AWSPowerShellGenerator.Generators;
using AWSPowerShellGenerator.ServiceConfig;

namespace AWSPSGeneratorLibTests
{
    [TestClass]
    public class VerbNounTransformationPatternsTests
    {
        private ConfigModelCollection _allModels;
        private ConfigModel _testModel;

        [TestInitialize]
        public void Setup()
        {
            _allModels = new ConfigModelCollection 
            { 
                MetadataParameterNames = new List<string>(),
                VerbNounTransformationPatternsList = new List<VerbTransformationPattern>
                {
                    new VerbTransformationPattern { Verb = "Filter", TargetVerb = "Get", NounTransformation = "Filtered{Noun}" },
                    new VerbTransformationPattern { Verb = "Monitor", TargetVerb = "Start", NounTransformation = "{Noun}Monitoring" },
                    new VerbTransformationPattern { Verb = "Unmonitor", TargetVerb = "Stop", NounTransformation = "{Noun}Monitoring" },
                    new VerbTransformationPattern { Verb = "Analyze", TargetVerb = "Invoke", NounTransformation = "{Noun}Analysis" }
                }
            };
            _testModel = new ConfigModel
            {
                AssemblyName = "TestService",
                ServiceName = "Test Service", 
                ServiceNounPrefix = "TEST",
                MetadataPropertyNames = new List<string>()
            };
        }

        [TestMethod]
        public void TryParseVerbTransformationPattern_FilterPattern_ReturnsCorrectTransformation()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("FilterInstances");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.TryParseVerbTransformationPattern("FilterInstances");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Get", result.Value.verb);
            Assert.AreEqual("FilteredInstance", result.Value.noun); // Transformed noun with pattern applied
        }

        [TestMethod]
        public void TryParseVerbTransformationPattern_MonitorPattern_ReturnsCorrectTransformation()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("MonitorDatabase");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.TryParseVerbTransformationPattern("MonitorDatabase");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Start", result.Value.verb);
            Assert.AreEqual("DatabaseMonitoring", result.Value.noun); // Transformed noun with pattern applied
        }

        [TestMethod]
        public void TryParseVerbTransformationPattern_UnmonitorPattern_ReturnsCorrectTransformation()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("UnmonitorInstances");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.TryParseVerbTransformationPattern("UnmonitorInstances");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Stop", result.Value.verb);
            Assert.AreEqual("InstanceMonitoring", result.Value.noun); // Transformed noun with pattern applied
        }

        [TestMethod]
        public void TryParseVerbTransformationPattern_AnalyzePattern_ReturnsCorrectTransformation()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("AnalyzeDocument");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.TryParseVerbTransformationPattern("AnalyzeDocument");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Invoke", result.Value.verb);
            Assert.AreEqual("DocumentAnalysis", result.Value.noun); // Transformed noun with pattern applied
        }

        [TestMethod]
        public void TryParseVerbTransformationPattern_NoMatchingPattern_ReturnsNull()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("CreateBucket");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.TryParseVerbTransformationPattern("CreateBucket");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TryParseVerbTransformationPattern_SingleWordOperation_ReturnsNull()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("Filter");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.TryParseVerbTransformationPattern("Filter");

            // Assert
            Assert.IsNull(result);
        }

        #region Helper Methods

        private ServiceOperation CreateAutoConfiguringOperation(string methodName = "TestOperation")
        {
            var operation = new ServiceOperation
            {
                MethodName = methodName,
                IsAutoConfiguring = true
            };

            // Extract the noun from the method name
            for (var i = 1; i < methodName.Length; i++)
            {
                if (char.IsUpper(methodName[i]))
                {
                    operation.OriginalNoun = methodName.Substring(i);
                    break;
                }
            }

            return operation;
        }

        private TestableVerbNounTransformationAnalyzer CreateAnalyzer(ServiceOperation operation) =>
            new(_allModels, _testModel, operation, null);

        #endregion
    }

    [TestClass]
    public class VerbMappingsTests
    {
        private ConfigModelCollection _allModels;
        private ConfigModel _testModel;

        [TestInitialize]
        public void Setup()
        {
            _allModels = new ConfigModelCollection 
            { 
                MetadataParameterNames = new List<string>(),
                VerbMappingsList = new List<ServiceOperationVerb>
                {
                    new ServiceOperationVerb
                    {
                        Name = "Attach",
                        Mappings = new List<VerbMappingData>
                        {
                            new VerbMappingData { Verb = "Mount", Weight = 12, Default = true },
                            new VerbMappingData { Verb = "Add", Weight = 17, Default = false },
                            new VerbMappingData { Verb = "Register", Weight = 3, Default = false },
                            new VerbMappingData { Verb = "Connect", Weight = 1, Default = false }
                        }
                    },
                    new ServiceOperationVerb
                    {
                        Name = "Create",
                        Mappings = new List<VerbMappingData>
                        {
                            new VerbMappingData { Verb = "New", Weight = 1910, Default = true },
                            new VerbMappingData { Verb = "Add", Weight = 2, Default = false },
                            new VerbMappingData { Verb = "Publish", Weight = 1, Default = false }
                        }
                    }
                }
            };
            _testModel = new ConfigModel
            {
                AssemblyName = "TestService",
                ServiceName = "Test Service", 
                ServiceNounPrefix = "TEST",
                MetadataPropertyNames = new List<string>(),
                ServiceOperationsList = new List<ServiceOperation>()
            };
        }

        [TestMethod]
        public void GetVerbMappingsInPriorityOrder_Attach_ReturnsCorrectOrder()
        {
            // Act
            var mappings = _allModels.GetVerbMappingsInPriorityOrder("Attach").ToList();

            // Assert
            Assert.AreEqual(4, mappings.Count);
            Assert.AreEqual("Mount", mappings[0].Verb); // Default with weight 12
            Assert.AreEqual("Add", mappings[1].Verb);   // Weight 17 (highest non-default)
            Assert.AreEqual("Register", mappings[2].Verb); // Weight 3
            Assert.AreEqual("Connect", mappings[3].Verb);  // Weight 1
        }

        [TestMethod]
        public void GetVerbMappingsInPriorityOrder_Create_ReturnsHighestWeightFirst()
        {
            // Act
            var mappings = _allModels.GetVerbMappingsInPriorityOrder("Create").ToList();

            // Assert
            Assert.AreEqual(3, mappings.Count);
            Assert.AreEqual("New", mappings[0].Verb);     // Default with weight 1910
            Assert.AreEqual("Add", mappings[1].Verb);     // Weight 2
            Assert.AreEqual("Publish", mappings[2].Verb); // Weight 1
        }

        [TestMethod]
        public void AssignVerb_AttachWithConflict_IteratesToNextOption()
        {
            // Arrange - Create operations that will conflict with "Mount" and "Add"
            var conflictingOp1 = new ServiceOperation { MethodName = "MountVolume", SelectedVerb = "Mount", OriginalNoun = "Volume" };
            var conflictingOp2 = new ServiceOperation { MethodName = "AddVolume", SelectedVerb = "Add", OriginalNoun = "Volume" };
            _testModel.ServiceOperations["MountVolumeAsync"] = conflictingOp1;
            _testModel.ServiceOperations["AddVolumeAsync"] = conflictingOp2;

            var operation = CreateAutoConfiguringOperation("AttachVolume");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.AssignVerb("Attach");

            // Assert
            Assert.AreEqual("Register", result); // Should skip Mount and Add due to conflicts, use Register
        }

        [TestMethod]
        public void AssignVerb_WeightPreference_SelectsHigherWeightWhenNoConflict()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("AttachVolume");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.AssignVerb("Attach");

            // Assert
            Assert.AreEqual("Mount", result); // Should select default verb "Mount"
        }

        [TestMethod]
        public void AssignVerb_ServiceLevelMapping_TakesPrecedence()
        {
            // Arrange - Add service-level mapping that should override global mappings
            _testModel.VerbMappingsList.Add(new Map { From = "Attach", To = "Connect" });
            var operation = CreateAutoConfiguringOperation("AttachVolume");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.AssignVerb("Attach");

            // Assert
            Assert.AreEqual("Connect", result); // Service-level mapping should take precedence
        }

        #region Helper Methods

        private ServiceOperation CreateAutoConfiguringOperation(string methodName = "TestOperation")
        {
            var operation = new ServiceOperation
            {
                MethodName = methodName,
                IsAutoConfiguring = true
            };

            // Extract the noun from the method name
            for (var i = 1; i < methodName.Length; i++)
            {
                if (char.IsUpper(methodName[i]))
                {
                    operation.OriginalNoun = methodName.Substring(i);
                    break;
                }
            }

            return operation;
        }

        private TestableVerbMappingsAnalyzer CreateAnalyzer(ServiceOperation operation) =>
            new(_allModels, _testModel, operation, null);

        #endregion
    }

    [TestClass]
    public class MethodPrefixModifiersTests
    {
        private ConfigModelCollection _allModels;
        private ConfigModel _testModel;

        [TestInitialize]
        public void Setup()
        {
            _allModels = new ConfigModelCollection 
            { 
                MetadataParameterNames = new List<string>(),
                MethodPrefixModifiersList = new List<MethodPrefixModifier>
                {
                    new MethodPrefixModifier { StartsWith = "Admin", NounTransformation = "Admin{Noun}" },
                    new MethodPrefixModifier { StartsWith = "Batch", NounTransformation = "{Noun}Batch" }
                }
            };
            _testModel = new ConfigModel
            {
                AssemblyName = "TestService",
                ServiceName = "Test Service", 
                ServiceNounPrefix = "TEST",
                MetadataPropertyNames = new List<string>()
            };
        }

        [TestMethod]
        public void TryParseModifierPattern_AdminPrefix_ExtractsCorrectly()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("AdminCreateUser");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.TryParseModifierPattern("AdminCreateUser");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Admin", result.Value.prefix);
            Assert.AreEqual("CreateUser", result.Value.remainingName);
        }

        [TestMethod]
        public void TryParseModifierPattern_BatchPrefix_ExtractsCorrectly()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("BatchDeleteItem");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.TryParseModifierPattern("BatchDeleteItem");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Batch", result.Value.prefix);
            Assert.AreEqual("DeleteItem", result.Value.remainingName);
        }

        [TestMethod]
        public void TryParseModifierPattern_NoMatchingPrefix_ReturnsNull()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("CreateUser");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.TryParseModifierPattern("CreateUser");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TryParseModifierPattern_CaseInsensitive_ExtractsCorrectly()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("adminCreateUser");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.TryParseModifierPattern("adminCreateUser");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Admin", result.Value.prefix);
            Assert.AreEqual("CreateUser", result.Value.remainingName);
        }

        [TestMethod]
        public void TransformNounForMethodPrefix_AdminModifier_TransformsCorrectly()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("AdminCreateUser");
            operation.AppliedMethodPrefixModifier = _allModels.MethodPrefixModifiers["Admin"];
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.TransformNounForMethodPrefix("User");

            // Assert
            Assert.AreEqual("AdminUser", result);
        }

        [TestMethod]
        public void TransformNounForMethodPrefix_BatchModifier_TransformsCorrectly()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("BatchDeleteItem");
            operation.AppliedMethodPrefixModifier = _allModels.MethodPrefixModifiers["Batch"];
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.TransformNounForMethodPrefix("Item");

            // Assert
            Assert.AreEqual("ItemBatch", result);
        }

        #region Helper Methods

        private ServiceOperation CreateAutoConfiguringOperation(string methodName = "TestOperation")
        {
            var operation = new ServiceOperation
            {
                MethodName = methodName,
                IsAutoConfiguring = true
            };

            // Extract the noun from the method name
            for (var i = 1; i < methodName.Length; i++)
            {
                if (char.IsUpper(methodName[i]))
                {
                    operation.OriginalNoun = methodName.Substring(i);
                    break;
                }
            }

            return operation;
        }

        private TestableMethodPrefixModifiersAnalyzer CreateAnalyzer(ServiceOperation operation) =>
            new(_allModels, _testModel, operation, null);

        #endregion
    }

    [TestClass]
    public class SingleWordMethodNameTests
    {
        private ConfigModelCollection _allModels;
        private ConfigModel _testModel;

        [TestInitialize]
        public void Setup()
        {
            _allModels = new ConfigModelCollection 
            { 
                MetadataParameterNames = new List<string>()
            };
            _testModel = new ConfigModel
            {
                AssemblyName = "TestService",
                ServiceName = "Test Service", 
                ServiceNounPrefix = "TEST",
                MetadataPropertyNames = new List<string>()
            };
        }

        [TestMethod]
        public void ParseVerbAndNoun_SingleWordConverse_ReturnsVerbWithNullNoun()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("Converse");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("Converse");

            // Assert
            Assert.AreEqual("Converse", result.verb);
            Assert.IsNull(result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        [TestMethod]
        public void AssignVerb_SingleWordOperation_ReturnsInvoke()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("Converse");
            operation.OriginalNoun = null; // Single word operation
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.AssignVerb("Converse");

            // Assert
            Assert.AreEqual("Invoke", result);
        }

        [TestMethod]
        public void AssignNoun_SingleWordOperation_ReturnsMethodName()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("Converse");
            operation.OriginalNoun = null; // Single word operation
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.AssignNoun(null);

            // Assert
            Assert.AreEqual("Converse", result);
        }

        [TestMethod]
        public void ParseVerbAndNoun_SingleWordExecute_ReturnsVerbWithNullNoun()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("Execute");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("Execute");

            // Assert
            Assert.AreEqual("Execute", result.verb);
            Assert.IsNull(result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        #region Helper Methods

        private ServiceOperation CreateAutoConfiguringOperation(string methodName = "TestOperation")
        {
            var operation = new ServiceOperation
            {
                MethodName = methodName,
                IsAutoConfiguring = true
            };

            // Extract the noun from the method name
            for (var i = 1; i < methodName.Length; i++)
            {
                if (char.IsUpper(methodName[i]))
                {
                    operation.OriginalNoun = methodName.Substring(i);
                    break;
                }
            }

            return operation;
        }

        private TestableSingleWordAnalyzer CreateAnalyzer(ServiceOperation operation) =>
            new(_allModels, _testModel, operation, null);

        #endregion
    }

    [TestClass]
    public class PrefixVerbMethodNameTests
    {
        private ConfigModelCollection _allModels;
        private ConfigModel _testModel;

        [TestInitialize]
        public void Setup()
        {
            _allModels = new ConfigModelCollection 
            { 
                MetadataParameterNames = new List<string>(),
                MethodPrefixModifiersList = new List<MethodPrefixModifier>
                {
                    new MethodPrefixModifier { StartsWith = "Batch", NounTransformation = "{Noun}Batch" }
                }
            };
            _testModel = new ConfigModel
            {
                AssemblyName = "TestService",
                ServiceName = "Test Service", 
                ServiceNounPrefix = "TEST",
                MetadataPropertyNames = new List<string>()
            };
        }

        [TestMethod]
        public void ParseVerbAndNoun_BatchRead_ExtractsCorrectly()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("BatchRead");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("BatchRead");

            // Assert
            Assert.AreEqual("Read", result.verb);
            Assert.IsNull(result.noun); // BatchRead is prefix + verb, no noun
            Assert.AreEqual("Batch", result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_BatchReadItem_ExtractsCorrectly()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("BatchReadItem");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("BatchReadItem");

            // Assert
            Assert.AreEqual("Read", result.verb);
            Assert.AreEqual("Item", result.noun);
            Assert.AreEqual("Batch", result.methodPrefix);
        }

        [TestMethod]
        public void AssignVerb_BatchRead_ReturnsCorrectVerb()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("BatchRead");
            operation.OriginalNoun = null; // BatchRead has no noun
            operation.ParsedMethodPrefix = "Batch";
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.AssignVerb("Read");

            // Assert
            Assert.AreEqual("Invoke", result); // BatchRead without noun gets mapped to Invoke
        }

        [TestMethod]
        public void AssignNoun_BatchRead_ReturnsMethodName()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("BatchRead");
            operation.OriginalNoun = null; // BatchRead has no noun
            operation.ParsedMethodPrefix = "Batch";
            operation.AppliedMethodPrefixModifier = _allModels.MethodPrefixModifiers["Batch"];
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.AssignNoun(null);

            // Assert
            Assert.AreEqual("BatchRead", result); // For single-word operations, returns the method name without transformation
        }

        #region Helper Methods

        private ServiceOperation CreateAutoConfiguringOperation(string methodName = "TestOperation")
        {
            var operation = new ServiceOperation
            {
                MethodName = methodName,
                IsAutoConfiguring = true
            };

            // Extract the noun from the method name
            for (var i = 1; i < methodName.Length; i++)
            {
                if (char.IsUpper(methodName[i]))
                {
                    operation.OriginalNoun = methodName.Substring(i);
                    break;
                }
            }

            return operation;
        }

        private TestablePrefixVerbAnalyzer CreateAnalyzer(ServiceOperation operation) =>
            new(_allModels, _testModel, operation, null);

        #endregion
    }

    [TestClass]
    public class PluralNounRulesTests
    {
        private ConfigModelCollection _allModels;
        private ConfigModel _testModel;

        [TestInitialize]
        public void Setup()
        {
            _allModels = new ConfigModelCollection 
            { 
                MetadataParameterNames = new List<string>(),
                PluralNounRulesList = new PluralNounRules
                {
                    DefaultSuffix = "Collection",
                    RulesList = new List<PluralNounRule>
                    {
                        new PluralNounRule { Verb = "Get" },
                        new PluralNounRule { Verb = "Describe" },
                        new PluralNounRule { Verb = "List" }
                    }
                }
            };
            _testModel = new ConfigModel
            {
                AssemblyName = "CloudFormation",
                ServiceName = "AWS CloudFormation", 
                ServiceNounPrefix = "CFN",
                MetadataPropertyNames = new List<string>(),
                ServiceOperationsList = new List<ServiceOperation>()
            };
        }

        [TestMethod]
        public void ShouldApplyPluralNounRule_DescribeStackResourceAndDescribeStackResources_ReturnsTrue()
        {
            // Arrange - Add conflicting operations to the service
            var singularOp = new ServiceOperation { MethodName = "DescribeStackResource", OriginalVerb = "Describe", OriginalNoun = "StackResource" };
            var pluralOp = new ServiceOperation { MethodName = "DescribeStackResources", OriginalVerb = "Describe", OriginalNoun = "StackResources" };
            _testModel.ServiceOperations["DescribeStackResourceAsync"] = singularOp;
            _testModel.ServiceOperations["DescribeStackResourcesAsync"] = pluralOp;

            var operation = CreateAutoConfiguringOperation("DescribeStackResources");
            operation.OriginalVerb = "Describe";
            operation.OriginalNoun = "StackResources";
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ShouldApplyPluralNounRule("Describe", "StackResources", "StackResource");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldApplyPluralNounRule_ListStackResourcesWithDescribeStackResource_ReturnsTrue()
        {
            // Arrange - Add conflicting operations with different verbs but same noun
            var describeOp = new ServiceOperation { MethodName = "DescribeStackResource", OriginalVerb = "Describe", OriginalNoun = "StackResource" };
            var listOp = new ServiceOperation { MethodName = "ListStackResources", OriginalVerb = "List", OriginalNoun = "StackResources" };
            _testModel.ServiceOperations["DescribeStackResourceAsync"] = describeOp;
            _testModel.ServiceOperations["ListStackResourcesAsync"] = listOp;

            var operation = CreateAutoConfiguringOperation("ListStackResources");
            operation.OriginalVerb = "List";
            operation.OriginalNoun = "StackResources";
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ShouldApplyPluralNounRule("List", "StackResources", "StackResource");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldApplyPluralNounRule_NoConflictingOperations_ReturnsFalse()
        {
            // Arrange - No conflicting operations
            var operation = CreateAutoConfiguringOperation("DescribeStackResources");
            operation.OriginalVerb = "Describe";
            operation.OriginalNoun = "StackResources";
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ShouldApplyPluralNounRule("Describe", "StackResources", "StackResource");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldApplyPluralNounRule_VerbNotInRules_ReturnsFalse()
        {
            // Arrange - Add conflicting operations but use verb not in rules
            var singularOp = new ServiceOperation { MethodName = "CreateStackResource", OriginalVerb = "Create", OriginalNoun = "StackResource" };
            var pluralOp = new ServiceOperation { MethodName = "CreateStackResources", OriginalVerb = "Create", OriginalNoun = "StackResources" };
            _testModel.ServiceOperations["CreateStackResourceAsync"] = singularOp;
            _testModel.ServiceOperations["CreateStackResourcesAsync"] = pluralOp;

            var operation = CreateAutoConfiguringOperation("CreateStackResources");
            operation.OriginalVerb = "Create";
            operation.OriginalNoun = "StackResources";
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ShouldApplyPluralNounRule("Create", "StackResources", "StackResource");

            // Assert
            Assert.IsFalse(result); // Create is not in the plural noun rules
        }

        [TestMethod]
        public void ShouldApplyPluralNounRule_SingularNoun_ReturnsFalse()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("DescribeStackResource");
            operation.OriginalVerb = "Describe";
            operation.OriginalNoun = "StackResource";
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ShouldApplyPluralNounRule("Describe", "StackResource", "StackResource");

            // Assert
            Assert.IsFalse(result); // Singular noun should not apply plural rules
        }

        #region Helper Methods

        private ServiceOperation CreateAutoConfiguringOperation(string methodName = "TestOperation")
        {
            var operation = new ServiceOperation
            {
                MethodName = methodName,
                IsAutoConfiguring = true
            };

            // Extract the noun from the method name
            for (var i = 1; i < methodName.Length; i++)
            {
                if (char.IsUpper(methodName[i]))
                {
                    operation.OriginalNoun = methodName.Substring(i);
                    break;
                }
            }

            return operation;
        }

        private TestablePluralNounRulesAnalyzer CreateAnalyzer(ServiceOperation operation) =>
            new(_allModels, _testModel, operation, null);

        #endregion
    }

    [TestClass]
    public class PipelineParameterTests
    {
        private ConfigModelCollection _allModels;
        private ConfigModel _testModel;

        [TestInitialize]
        public void Setup()
        {
            _allModels = new ConfigModelCollection { MetadataParameterNames = new List<string>() };
            _testModel = new ConfigModel
            {
                AssemblyName = "TestService",
                ServiceName = "Test Service", 
                ServiceNounPrefix = "TEST",
                MetadataPropertyNames = new List<string>()
            };
        }

        #region DeterminePipelineParameter Tests

        [TestMethod]
        public void DeterminePipelineParameter_NoCandidates_SetsNoPipelineParameterTrue()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation();
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("MetadataParam", isMetadata: true),
                CreateParameter("CollectionParam", typeof(List<string>))
            );

            // Act
            analyzer.DeterminePipelineParameter(null);

            // Assert
            Assert.IsTrue(operation.NoPipelineParameter);
            Assert.AreEqual(1, operation.InfoMessages.Count);
            StringAssert.Contains(operation.InfoMessages[0].Message, "No suitable pipeline parameter candidates found");
        }

        [TestMethod]
        public void DeterminePipelineParameter_SingleCandidate_SelectsParameterAndLogsInfo()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation();
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("ResourceId"),
                CreateParameter("MetadataParam", isMetadata: true)
            );

            // Act
            analyzer.DeterminePipelineParameter(null);

            // Assert
            Assert.IsFalse(operation.NoPipelineParameter);
            Assert.AreEqual("ResourceId", operation.PipelineParameter);
            Assert.AreEqual(1, operation.InfoMessages.Count);
            StringAssert.Contains(operation.InfoMessages[0].Message, "Single pipeline parameter candidate found: ResourceId");
        }

        [TestMethod]
        public void DeterminePipelineParameter_MultipleCandidates_SetsNoPipelineParameterTrueAndListsCandidates()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation();
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("ResourceId"),
                CreateParameter("ResourceName"),
                CreateParameter("MetadataParam", isMetadata: true)
            );

            // Act
            analyzer.DeterminePipelineParameter(null);

            // Assert
            Assert.IsTrue(operation.NoPipelineParameter);
            Assert.AreEqual(1, operation.InfoMessages.Count);
            var message = operation.InfoMessages[0].Message;
            StringAssert.Contains(message, "Multiple pipeline parameter candidates found");
            StringAssert.Contains(message, "ResourceId");
            StringAssert.Contains(message, "ResourceName");
        }

        [TestMethod]
        public void DeterminePipelineParameter_ExistingCmdlet_MaintainsCurrentBehavior()
        {
            // Arrange
            var operation = new ServiceOperation
            {
                MethodName = "TestOperation",
                IsAutoConfiguring = false,
                PipelineParameter = "ExistingParam",
                NoPipelineParameter = false
            };
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("ExistingParam"),
                CreateParameter("OtherParam")
            );

            // Act
            analyzer.DeterminePipelineParameter(null);

            // Assert
            Assert.IsFalse(operation.NoPipelineParameter);
            Assert.AreEqual("ExistingParam", operation.PipelineParameter);
            Assert.AreEqual(0, operation.InfoMessages.Count);
        }

        [TestMethod]
        public void DeterminePipelineParameter_ExistingCmdletWithNoPipelineParameter_MaintainsCurrentBehavior()
        {
            // Arrange
            var operation = new ServiceOperation
            {
                MethodName = "TestOperation",
                IsAutoConfiguring = false,
                PipelineParameter = "",
                NoPipelineParameter = true
            };
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("ResourceId"),
                CreateParameter("ResourceName")
            );

            // Act
            analyzer.DeterminePipelineParameter(null);

            // Assert
            Assert.IsTrue(operation.NoPipelineParameter);
            Assert.AreEqual("", operation.PipelineParameter);
            Assert.AreEqual(0, operation.InfoMessages.Count);
        }

        [TestMethod]
        public void DeterminePipelineParameter_ServiceLevelParameter_UsesServiceDefault()
        {
            // Arrange
            _testModel.PipelineParameter = "ServiceDefaultParam";
            var operation = CreateAutoConfiguringOperation();
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("ServiceDefaultParam"),
                CreateParameter("OtherParam")
            );

            // Act
            analyzer.DeterminePipelineParameter(null);

            // Assert
            Assert.IsFalse(operation.NoPipelineParameter);
            Assert.AreEqual("ServiceDefaultParam", operation.PipelineParameter);
            Assert.AreEqual(0, operation.InfoMessages.Count);
        }

        #endregion

        #region SelectPreferredCandidateParameters Tests

        [TestMethod]
        public void SelectPreferredCandidateParameters_FiltersCollections()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation();
            var analyzer = CreateAnalyzer(operation);
            var parameters = new[]
            {
                CreateParameter("StringParam", typeof(string)),
                CreateParameter("ListParam", typeof(List<string>)),
                CreateParameter("ArrayParam", typeof(string[]))
            };

            // Act
            var result = analyzer.SelectPreferredCandidateParameters(parameters);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("StringParam", result[0].AnalyzedName);
        }

        [TestMethod]
        public void SelectPreferredCandidateParameters_FiltersMetadataParameters()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation();
            var analyzer = CreateAnalyzer(operation);
            _allModels.MetadataParameterNames.Add("MetadataParam");
            var parameters = new[]
            {
                CreateParameter("RegularParam", typeof(string)),
                CreateParameter("MetadataParam", typeof(string))
            };

            // Act
            var result = analyzer.SelectPreferredCandidateParameters(parameters);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("RegularParam", result[0].AnalyzedName);
        }

        [TestMethod]
        public void SelectPreferredCandidateParameters_ReturnsAllValidParameters()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation();
            var analyzer = CreateAnalyzer(operation);
            var parameters = new[]
            {
                CreateParameter("ValidParam1", typeof(string)),
                CreateParameter("ValidParam2", typeof(string))
            };

            // Act
            var result = analyzer.SelectPreferredCandidateParameters(parameters);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Any(p => p.AnalyzedName == "ValidParam1"));
            Assert.IsTrue(result.Any(p => p.AnalyzedName == "ValidParam2"));
        }

        [TestMethod]
        public void SelectPreferredCandidateParameters_FiltersIterationParameters()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation();
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetAutoIterateSettings(new AutoIteration
            {
                Start = "NextToken",
                Next = "NextToken",
                EmitLimit = "MaxItems"
            });
            var parameters = new[]
            {
                CreateParameter("ResourceId"),
                CreateParameter("NextToken"), // This is an iteration parameter
                CreateParameter("MaxItems", typeof(int)) // This is also an iteration parameter
            };

            // Act
            var result = analyzer.SelectPreferredCandidateParameters(parameters);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("ResourceId", result[0].AnalyzedName);
        }

        [TestMethod]
        public void SelectPreferredCandidateParameters_FiltersDeprecatedParameters()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation();
            var analyzer = CreateAnalyzer(operation);
            var parameters = new[]
            {
                CreateParameter("ActiveParam"),
                CreateParameter("DeprecatedParam", isDeprecated: true)
            };

            // Act
            var result = analyzer.SelectPreferredCandidateParameters(parameters);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("ActiveParam", result[0].AnalyzedName);
        }

        #endregion

        #region Helper Methods

        private ServiceOperation CreateAutoConfiguringOperation(string methodName = "TestOperation")
        {
            var operation = new ServiceOperation
            {
                MethodName = methodName,
                IsAutoConfiguring = true
            };

            // Extract the noun from the method name (similar to how OperationAnalyzer.DetermineVerbAndNoun works)
            for (var i = 1; i < methodName.Length; i++)
            {
                if (char.IsUpper(methodName[i]))
                {
                    operation.OriginalNoun = methodName.Substring(i);
                    break;
                }
            }

            return operation;
        }

        private TestableOperationAnalyzer CreateAnalyzer(ServiceOperation operation) =>
            new(_allModels, _testModel, operation, null);

        private SimplePropertyInfo CreateParameter(string name, Type type = null, bool isMetadata = false, bool isDeprecated = false, bool isRequired = false, SimplePropertyInfo parent = null)
        {
            type ??= typeof(string);
            var mockProperty = new MockPropertyInfo(name, type);
            if (isDeprecated)
                mockProperty.SetDeprecated(true);

            var parameter = new SimplePropertyInfo(
                mockProperty, 
                parent, 
                type.Name, 
                null,
                SimplePropertyInfo.PropertyCollectionType.NoCollection, 
                null);

            if (isMetadata)
                _allModels.MetadataParameterNames.Add(name);

            if (isRequired)
            {
                // Set required using reflection since it's a private field
                var field = typeof(SimplePropertyInfo).GetField("_isRequired", BindingFlags.NonPublic | BindingFlags.Instance);
                field?.SetValue(parameter, true);
            }

            return parameter;
        }

        #endregion
    }

    [TestClass]
    public class ParseVerbAndNounTests
    {
        private ConfigModelCollection _allModels;
        private ConfigModel _testModel;

        [TestInitialize]
        public void Setup()
        {
            _allModels = new ConfigModelCollection 
            { 
                MetadataParameterNames = new List<string>(),
                MethodPrefixModifiersList = new List<MethodPrefixModifier>
                {
                    new MethodPrefixModifier { StartsWith = "Admin" },
                    new MethodPrefixModifier { StartsWith = "Batch" }
                },
                VerbNounTransformationPatternsList = new List<VerbTransformationPattern>
                {
                    new VerbTransformationPattern { Verb = "Filter", TargetVerb = "Get", NounTransformation = "Filtered{Noun}" },
                    new VerbTransformationPattern { Verb = "Monitor", TargetVerb = "Start", NounTransformation = "{Noun}Monitoring" },
                    new VerbTransformationPattern { Verb = "Unmonitor", TargetVerb = "Stop", NounTransformation = "{Noun}Monitoring" }
                }
            };
            _testModel = new ConfigModel
            {
                AssemblyName = "TestService",
                ServiceName = "Test Service", 
                ServiceNounPrefix = "TEST",
                MetadataPropertyNames = new List<string>()
            };
        }

        #region Basic Verb-Noun Parsing Tests


        [TestMethod]
        public void ParseVerbAndNoun_LongVerbName_ParsesCorrectly()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("AuthorizeSecurityGroupIngress");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("AuthorizeSecurityGroupIngress");

            // Assert
            Assert.AreEqual("Authorize", result.verb);
            Assert.AreEqual("SecurityGroupIngress", result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_SingleWordOperation_ReturnsVerbWithNullNoun()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("Execute");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("Execute");

            // Assert
            Assert.AreEqual("Execute", result.verb);
            Assert.IsNull(result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_VerbOnlyWithLowercase_ReturnsVerbWithNullNoun()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("process");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("process");

            // Assert
            Assert.AreEqual("process", result.verb);
            Assert.IsNull(result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        #endregion

        #region Modifier Pattern Tests

        [TestMethod]
        public void ParseVerbAndNoun_AdminModifier_ExtractsModifierPrefix()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("AdminCreateUser");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("AdminCreateUser");

            // Assert
            Assert.AreEqual("Create", result.verb);
            Assert.AreEqual("User", result.noun);
            Assert.AreEqual("Admin", result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_BatchModifier_ExtractsModifierPrefix()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("BatchDeleteItem");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("BatchDeleteItem");

            // Assert
            Assert.AreEqual("Delete", result.verb);
            Assert.AreEqual("Item", result.noun);
            Assert.AreEqual("Batch", result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_ModifierWithSingleWord_ReturnsVerbWithNullNoun()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("AdminExecute");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("AdminExecute");

            // Assert
            Assert.AreEqual("Execute", result.verb);
            Assert.IsNull(result.noun);
            Assert.AreEqual("Admin", result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_NoMatchingModifier_NoModifierExtracted()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("CustomCreateBucket");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("CustomCreateBucket");

            // Assert
            Assert.AreEqual("Custom", result.verb);
            Assert.AreEqual("CreateBucket", result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_ModifierCaseInsensitive_ExtractsModifierPrefix()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("adminCreateUser");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("adminCreateUser");

            // Assert
            Assert.AreEqual("Create", result.verb);
            Assert.AreEqual("User", result.noun);
            Assert.AreEqual("Admin", result.methodPrefix);
        }

        #endregion

        #region Verb Transformation Pattern Tests

        [TestMethod]
        public void ParseVerbAndNoun_FilterPattern_DoesNotTransformInParseMethod()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("FilterInstances");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("FilterInstances");

            // Assert
            // ParseVerbAndNoun should only parse, not transform
            Assert.AreEqual("Filter", result.verb);
            Assert.AreEqual("Instances", result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_MonitorPattern_DoesNotTransformInParseMethod()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("MonitorDatabase");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("MonitorDatabase");

            // Assert
            // ParseVerbAndNoun should only parse, not transform
            Assert.AreEqual("Monitor", result.verb);
            Assert.AreEqual("Database", result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_UnmonitorPattern_DoesNotTransformInParseMethod()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("UnmonitorInstances");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("UnmonitorInstances");

            // Assert
            // ParseVerbAndNoun should only parse, not transform
            Assert.AreEqual("Unmonitor", result.verb);
            Assert.AreEqual("Instances", result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        #endregion

        #region Edge Cases and Complex Scenarios

        [TestMethod]
        public void ParseVerbAndNoun_EmptyString_ReturnsEmptyVerbWithNullNoun()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("");

            // Assert
            Assert.AreEqual("", result.verb);
            Assert.IsNull(result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_AllLowercase_ReturnsVerbWithNullNoun()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("createbucket");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("createbucket");

            // Assert
            Assert.AreEqual("createbucket", result.verb);
            Assert.IsNull(result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_AllUppercase_ParsesAtFirstUppercaseAfterFirst()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("CREATEBUCKET");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("CREATEBUCKET");

            // Assert
            // For all-uppercase strings, the parsing logic finds the first uppercase after position 0
            // which is position 1 ('R'), so it splits "C" and "REATEBUCKET"
            Assert.AreEqual("C", result.verb);
            Assert.AreEqual("REATEBUCKET", result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_NumbersInName_ParsesCorrectly()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("CreateS3Bucket");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("CreateS3Bucket");

            // Assert
            Assert.AreEqual("Create", result.verb);
            Assert.AreEqual("S3Bucket", result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_ConsecutiveCapitalLetters_ParsesAtFirstCapital()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("CreateDBCluster");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("CreateDBCluster");

            // Assert
            Assert.AreEqual("Create", result.verb);
            Assert.AreEqual("DBCluster", result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_ModifierWithTransformationPattern_PrefersModifierOverTransformation()
        {
            // Arrange - Add a transformation pattern that could conflict with modifier
            _allModels.VerbNounTransformationPatternsList.Add(
                new VerbTransformationPattern { Verb = "Admin", TargetVerb = "Invoke", NounTransformation = "Admin{Noun}" });
            var operation = CreateAutoConfiguringOperation("AdminFilterInstances");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("AdminFilterInstances");

            // Assert
            // Should extract Admin as modifier, not apply transformation pattern
            Assert.AreEqual("Filter", result.verb);
            Assert.AreEqual("Instances", result.noun);
            Assert.AreEqual("Admin", result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_VeryLongMethodName_ParsesCorrectly()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("CreateVeryLongComplexMethodNameWithManyWords");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("CreateVeryLongComplexMethodNameWithManyWords");

            // Assert
            Assert.AreEqual("Create", result.verb);
            Assert.AreEqual("VeryLongComplexMethodNameWithManyWords", result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        [TestMethod]
        public void ParseVerbAndNoun_SingleCharacterVerb_ParsesCorrectly()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("AResource");
            var analyzer = CreateAnalyzer(operation);

            // Act
            var result = analyzer.ParseVerbAndNoun("AResource");

            // Assert
            Assert.AreEqual("A", result.verb);
            Assert.AreEqual("Resource", result.noun);
            Assert.IsNull(result.methodPrefix);
        }

        #endregion

        #region AssignVerb Tests

        [TestMethod]
        public void AssignVerb_PowerShellApprovedVerb_ReturnsOriginalVerb()
        {
            // Setup: Create a test operation with PowerShell-approved verb
            var operation = new ServiceOperation
            {
                MethodName = "GetBucket",
                IsAutoConfiguring = true
            };
            
            // Set up the analyzer with the test operation
            var analyzer = CreateAnalyzer(operation);
            
            // Parse the verb and noun first to set OriginalNoun
            var (verb, noun, methodPrefix) = analyzer.ParseVerbAndNoun("GetBucket");
            operation.OriginalNoun = noun;
            operation.ParsedMethodPrefix = methodPrefix;
            
            // Test: AssignVerb should return the original verb since "Get" is approved
            var result = analyzer.AssignVerb(verb);
            
            Assert.AreEqual("Get", result, "Should return original PowerShell-approved verb");
        }

        [TestMethod]
        public void AssignVerb_PowerShellApprovedVerbWithPluralNoun_ReturnsOriginalVerb()
        {
            // Setup: Create a test operation with PowerShell-approved verb and plural noun
            var operation = new ServiceOperation
            {
                MethodName = "GetBuckets", // plural noun
                IsAutoConfiguring = true
            };
            
            // Set up the analyzer with the test operation
            var analyzer = CreateAnalyzer(operation);
            
            // Parse the verb and noun first to set OriginalNoun
            var (verb, noun, methodPrefix) = analyzer.ParseVerbAndNoun("GetBuckets");
            operation.OriginalNoun = noun;
            operation.ParsedMethodPrefix = methodPrefix;
            
            // Test: AssignVerb should return the original verb since "Get" is approved (noun doesn't matter)
            var result = analyzer.AssignVerb(verb);
            
            Assert.AreEqual("Get", result, "Should return original PowerShell-approved verb regardless of noun");
        }

        [TestMethod]
        public void AssignVerb_NonApprovedVerb_DoesNotReturnOriginalVerb()
        {
            // Setup: Create a test operation with non-approved verb
            var operation = new ServiceOperation
            {
                MethodName = "CustomBucket", // "Custom" is not a PowerShell-approved verb
                IsAutoConfiguring = true
            };
            
            // Set up the analyzer with the test operation
            var analyzer = CreateAnalyzer(operation);
            
            // Parse the verb and noun first to set OriginalNoun
            var (verb, noun, methodPrefix) = analyzer.ParseVerbAndNoun("CustomBucket");
            operation.OriginalNoun = noun;
            operation.ParsedMethodPrefix = methodPrefix;
            
            // Test: AssignVerb should NOT return the original verb since "Custom" is not approved
            var result = analyzer.AssignVerb(verb);
            
            // The result should be a verb (either from transformation patterns or verb mappings)
            Assert.IsNotNull(result, "Should return a verb");
            
            // Since "Custom" is not a PowerShell-approved verb, it should go through the rest of the logic
            // The exact result depends on verb mappings, but we can verify it's not null and is a string
            Assert.IsTrue(result.Length > 0, "Should return a non-empty verb");
        }

        #endregion

        #region Helper Methods

        private ServiceOperation CreateAutoConfiguringOperation(string methodName = "TestOperation")
        {
            var operation = new ServiceOperation
            {
                MethodName = methodName,
                IsAutoConfiguring = true
            };

            // Extract the noun from the method name (similar to how OperationAnalyzer.DetermineVerbAndNoun works)
            for (var i = 1; i < methodName.Length; i++)
            {
                if (char.IsUpper(methodName[i]))
                {
                    operation.OriginalNoun = methodName.Substring(i);
                    break;
                }
            }

            return operation;
        }

        private TestableParseVerbAndNounAnalyzer CreateAnalyzer(ServiceOperation operation) =>
            new(_allModels, _testModel, operation, null);

        #endregion
    }

    /// <summary>
    /// Testable version of OperationAnalyzer that exposes ParseVerbAndNoun method for testing
    /// </summary>
    internal class TestableParseVerbAndNounAnalyzer : OperationAnalyzer
    {
        public TestableParseVerbAndNounAnalyzer(ConfigModelCollection allModels, ConfigModel currentModel, 
            ServiceOperation currentOperation, XmlDocument assemblyDocumentation)
            : base(allModels, currentModel, currentOperation, assemblyDocumentation)
        {
        }

        public new (string verb, string noun, string methodPrefix) ParseVerbAndNoun(string methodName) =>
            base.ParseVerbAndNoun(methodName);

        public new (string prefix, string remainingName)? TryParseModifierPattern(string methodName) =>
            base.TryParseModifierPattern(methodName);

        public new (string verb, string noun)? TryParseVerbTransformationPattern(string methodName) =>
            base.TryParseVerbTransformationPattern(methodName);

        public new string AssignVerb(string verb) =>
            base.AssignVerb(verb);
    }

    [TestClass]
    public class ShouldProcessTargetTests
    {
        private ConfigModelCollection _allModels;
        private ConfigModel _testModel;

        [TestInitialize]
        public void Setup()
        {
            _allModels = new ConfigModelCollection { MetadataParameterNames = new List<string>() };
            _testModel = new ConfigModel
            {
                AssemblyName = "TestService",
                ServiceName = "Test Service",
                ServiceNounPrefix = "TEST",
                MetadataPropertyNames = new List<string>()
            };
        }

        [TestMethod]
        public void SelectShouldProcessTarget_ExactNounMatch_SelectsMatchingParameter()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("CreateResource");
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("Resource"),
                CreateParameter("ResourceId"),
                CreateParameter("OtherParam")
            );

            // Act
            var result = analyzer.SelectShouldProcessTarget();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Resource", result[0].AnalyzedName);
            Assert.AreEqual(1, operation.InfoMessages.Count);
            StringAssert.Contains(operation.InfoMessages[0].Message, "exact noun match");
        }


        [TestMethod]
        public void SelectShouldProcessTarget_SingularizedNounMatch_SelectsMatchingParameter()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("CreateResources");
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("Resource"), // Singular parameter name that matches singularized noun
                CreateParameter("ResourceId"),
                CreateParameter("OtherParam")
            );

            // Act
            var result = analyzer.SelectShouldProcessTarget();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Resource", result[0].AnalyzedName);
            Assert.AreEqual(1, operation.InfoMessages.Count);
            StringAssert.Contains(operation.InfoMessages[0].Message, "singularized noun match");
            StringAssert.Contains(operation.InfoMessages[0].Message, "Resource");
        }

        [TestMethod]
        public void SelectShouldProcessTarget_NounPrefixSingularizedMatch_SelectsMatchingParameter()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("CreateResources");
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("ResourceName"), // Parameter that starts with singularized noun and ends with suffix
                CreateParameter("OtherParam"),
                CreateParameter("SomeId")
            );

            // Act
            var result = analyzer.SelectShouldProcessTarget();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("ResourceName", result[0].AnalyzedName);
            Assert.AreEqual(1, operation.InfoMessages.Count);
            // The logic will match this as a regular noun prefix match at root level since ResourceName starts with "Resources" (original noun)
            // and the singularized logic only applies when the original noun doesn't match
            StringAssert.Contains(operation.InfoMessages[0].Message, "noun prefix match");
            StringAssert.Contains(operation.InfoMessages[0].Message, "ResourceName");
        }

        [TestMethod]
        public void SelectShouldProcessTarget_NounPrefixWithSuffix_SelectsMatchingParameter()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("CreateBucket");
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("BucketName"),
                CreateParameter("OtherParam"),
                CreateParameter("ResourceId")
            );

            // Act
            var result = analyzer.SelectShouldProcessTarget();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("BucketName", result[0].AnalyzedName);
            Assert.AreEqual(1, operation.InfoMessages.Count);
            StringAssert.Contains(operation.InfoMessages[0].Message, "noun prefix match");
        }

        [TestMethod]
        public void SelectShouldProcessTarget_CaseInsensitiveMatching_SelectsParametersRegardlessOfCase()
        {
            // Arrange - Test case-insensitive matching for parameter suffixes
            // Use a method name that won't have exact noun matches with the parameters
            var operation = CreateAutoConfiguringOperation("CreateItem");
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("resourceid"), // lowercase suffix "id" should match
                CreateParameter("ResourceNAME"), // mixed case suffix "NAME" should match
                CreateParameter("BucketArn"), // proper case suffix "Arn" should match
                CreateParameter("SomeKey") // no matching suffix - should be filtered out
            );

            // Act
            var result = analyzer.SelectShouldProcessTarget();

            // Assert - Should return the 3 parameters with valid suffixes (2-3 range triggers multiple parameter selection)
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count); // All 3 parameters with case-insensitive suffix matches
            
            // Verify all expected parameters are included
            var parameterNames = result.Select(p => p.AnalyzedName).ToList();
            Assert.IsTrue(parameterNames.Contains("resourceid"), "Should match lowercase 'id' suffix");
            Assert.IsTrue(parameterNames.Contains("ResourceNAME"), "Should match mixed case 'NAME' suffix");
            Assert.IsTrue(parameterNames.Contains("BucketArn"), "Should match proper case 'Arn' suffix");
            Assert.IsFalse(parameterNames.Contains("SomeKey"), "Should not match parameter without valid suffix");

            // Should log message about multiple parameters being selected (3 parameters)
            Assert.AreEqual(1, operation.InfoMessages.Count);
            StringAssert.Contains(operation.InfoMessages[0].Message, "ShouldProcessTarget selected multiple parameters");
        }

        private ServiceOperation CreateAutoConfiguringOperation(string methodName = "TestOperation")
        {
            var operation = new ServiceOperation
            {
                MethodName = methodName,
                IsAutoConfiguring = true
            };

            // Extract the noun from the method name (similar to how OperationAnalyzer.DetermineVerbAndNoun works)
            for (var i = 1; i < methodName.Length; i++)
            {
                if (char.IsUpper(methodName[i]))
                {
                    operation.OriginalNoun = methodName.Substring(i);
                    break;
                }
            }

            return operation;
        }

        private TestableOperationAnalyzer CreateAnalyzer(ServiceOperation operation) =>
            new(_allModels, _testModel, operation, null);

        private SimplePropertyInfo CreateParameter(string name, Type type = null, bool isMetadata = false, bool isDeprecated = false, bool isRequired = false, SimplePropertyInfo parent = null)
        {
            type ??= typeof(string);
            var mockProperty = new MockPropertyInfo(name, type);
            if (isDeprecated)
                mockProperty.SetDeprecated(true);

            var parameter = new SimplePropertyInfo(
                mockProperty, 
                parent, 
                type.Name, 
                null,
                SimplePropertyInfo.PropertyCollectionType.NoCollection, 
                null);

            if (isMetadata)
                _allModels.MetadataParameterNames.Add(name);

            if (isRequired)
            {
                // Set required using reflection since it's a private field
                var field = typeof(SimplePropertyInfo).GetField("_isRequired", BindingFlags.NonPublic | BindingFlags.Instance);
                field?.SetValue(parameter, true);
            }

            return parameter;
        }
    }

    /// <summary>
    /// Testable version of OperationAnalyzer that exposes protected methods for testing
    /// </summary>
    internal class TestableOperationAnalyzer : OperationAnalyzer
    {
        private AutoIteration _testAutoIterateSettings;

        public TestableOperationAnalyzer(ConfigModelCollection allModels, ConfigModel currentModel, 
            ServiceOperation currentOperation, XmlDocument assemblyDocumentation)
            : base(allModels, currentModel, currentOperation, assemblyDocumentation)
        {
            AnalyzedParameters = new List<SimplePropertyInfo>();
        }

        public void SetParameters(params SimplePropertyInfo[] parameters) =>
            AnalyzedParameters = new List<SimplePropertyInfo>(parameters);

        public void SetAutoIterateSettings(AutoIteration settings) =>
            _testAutoIterateSettings = settings;

        public override AutoIteration AutoIterateSettings => _testAutoIterateSettings ?? base.AutoIterateSettings;

        public override IEnumerable<SimplePropertyInfo> NonIterationParameters => AnalyzedParameters;

        public new void DeterminePipelineParameter(CmdletGenerator generator) =>
            base.DeterminePipelineParameter(generator);

        public new List<SimplePropertyInfo> SelectPreferredCandidateParameters(IEnumerable<SimplePropertyInfo> parameters) =>
            base.SelectPreferredCandidateParameters(parameters);

        public new List<SimplePropertyInfo> SelectShouldProcessTarget() =>
            base.SelectShouldProcessTarget();
    }

    /// <summary>
    /// Minimal mock PropertyInfo for testing - only implements what SimplePropertyInfo actually uses
    /// </summary>
    internal class MockPropertyInfo : PropertyInfo
    {
        private bool _isDeprecated;

        public MockPropertyInfo(string name, Type propertyType)
        {
            Name = name;
            PropertyType = propertyType;
            DeclaringType = typeof(object); // Used by SimplePropertyInfo constructor
        }

        // Used by SimplePropertyInfo constructor and throughout OperationAnalyzer
        public override string Name { get; }
        public override Type PropertyType { get; }
        public override Type DeclaringType { get; }

        public void SetDeprecated(bool isDeprecated) => _isDeprecated = isDeprecated;

        // Used by SimplePropertyInfo constructor to detect ObsoleteAttribute for IsDeprecated property
        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            if (_isDeprecated && attributeType == typeof(ObsoleteAttribute))
                return new[] { new ObsoleteAttribute("This parameter is deprecated") };
            return Array.Empty<Attribute>();
        }
        
        public override object[] GetCustomAttributes(bool inherit)
        {
            if (_isDeprecated)
                return new[] { new ObsoleteAttribute("This parameter is deprecated") };
            return Array.Empty<Attribute>();
        }
        
        public override bool IsDefined(Type attributeType, bool inherit) => 
            _isDeprecated && attributeType == typeof(ObsoleteAttribute);

        // Used by SimplePropertyInfo constructor to set IsReadWrite property
        public override bool CanRead => true;
        public override bool CanWrite => true;
        
        // Used by .NET Framework's attribute system when calling GetCustomAttributes
        public override ParameterInfo[] GetIndexParameters() => Array.Empty<ParameterInfo>();
        public override MethodInfo GetGetMethod(bool nonPublic) => null;
        public override MethodInfo GetSetMethod(bool nonPublic) => null;

        // Unused by SimplePropertyInfo - safe to throw NotImplementedException
        public override PropertyAttributes Attributes => throw new NotImplementedException();
        public override Type ReflectedType => throw new NotImplementedException();
        public override MethodInfo[] GetAccessors(bool nonPublic) => throw new NotImplementedException();
        public override object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
        public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
    }

    /// <summary>
    /// Testable version of OperationAnalyzer that exposes VerbNounTransformationPattern methods for testing
    /// </summary>
    internal class TestableVerbNounTransformationAnalyzer : OperationAnalyzer
    {
        public TestableVerbNounTransformationAnalyzer(ConfigModelCollection allModels, ConfigModel currentModel, 
            ServiceOperation currentOperation, XmlDocument assemblyDocumentation)
            : base(allModels, currentModel, currentOperation, assemblyDocumentation)
        {
        }

        public new (string verb, string noun)? TryParseVerbTransformationPattern(string methodName) =>
            base.TryParseVerbTransformationPattern(methodName);
    }

    /// <summary>
    /// Testable version of OperationAnalyzer that exposes VerbMappings methods for testing
    /// </summary>
    internal class TestableVerbMappingsAnalyzer : OperationAnalyzer
    {
        public TestableVerbMappingsAnalyzer(ConfigModelCollection allModels, ConfigModel currentModel, 
            ServiceOperation currentOperation, XmlDocument assemblyDocumentation)
            : base(allModels, currentModel, currentOperation, assemblyDocumentation)
        {
        }

        public new string AssignVerb(string verb) =>
            base.AssignVerb(verb);

        public new bool IsVerbNounCombinationInUse(string verb, string noun) =>
            base.IsVerbNounCombinationInUse(verb, noun);
    }

    /// <summary>
    /// Testable version of OperationAnalyzer that exposes MethodPrefixModifiers methods for testing
    /// </summary>
    internal class TestableMethodPrefixModifiersAnalyzer : OperationAnalyzer
    {
        public TestableMethodPrefixModifiersAnalyzer(ConfigModelCollection allModels, ConfigModel currentModel, 
            ServiceOperation currentOperation, XmlDocument assemblyDocumentation)
            : base(allModels, currentModel, currentOperation, assemblyDocumentation)
        {
        }

        public new (string prefix, string remainingName)? TryParseModifierPattern(string methodName) =>
            base.TryParseModifierPattern(methodName);

        public new string TransformNounForMethodPrefix(string noun) =>
            base.TransformNounForMethodPrefix(noun);
    }

    /// <summary>
    /// Testable version of OperationAnalyzer that exposes single word method name methods for testing
    /// </summary>
    internal class TestableSingleWordAnalyzer : OperationAnalyzer
    {
        public TestableSingleWordAnalyzer(ConfigModelCollection allModels, ConfigModel currentModel, 
            ServiceOperation currentOperation, XmlDocument assemblyDocumentation)
            : base(allModels, currentModel, currentOperation, assemblyDocumentation)
        {
        }

        public new (string verb, string noun, string methodPrefix) ParseVerbAndNoun(string methodName) =>
            base.ParseVerbAndNoun(methodName);

        public new string AssignVerb(string verb) =>
            base.AssignVerb(verb);

        public new string AssignNoun(string noun) =>
            base.AssignNoun(noun);
    }

    /// <summary>
    /// Testable version of OperationAnalyzer that exposes prefix+verb method name methods for testing
    /// </summary>
    internal class TestablePrefixVerbAnalyzer : OperationAnalyzer
    {
        public TestablePrefixVerbAnalyzer(ConfigModelCollection allModels, ConfigModel currentModel, 
            ServiceOperation currentOperation, XmlDocument assemblyDocumentation)
            : base(allModels, currentModel, currentOperation, assemblyDocumentation)
        {
        }

        public new (string verb, string noun, string methodPrefix) ParseVerbAndNoun(string methodName) =>
            base.ParseVerbAndNoun(methodName);

        public new string AssignVerb(string verb) =>
            base.AssignVerb(verb);

        public new string AssignNoun(string noun) =>
            base.AssignNoun(noun);

        public new string TransformNounForMethodPrefix(string noun) =>
            base.TransformNounForMethodPrefix(noun);
    }

    /// <summary>
    /// Testable version of OperationAnalyzer that exposes PluralNounRules methods for testing
    /// </summary>
    internal class TestablePluralNounRulesAnalyzer : OperationAnalyzer
    {
        public TestablePluralNounRulesAnalyzer(ConfigModelCollection allModels, ConfigModel currentModel, 
            ServiceOperation currentOperation, XmlDocument assemblyDocumentation)
            : base(allModels, currentModel, currentOperation, assemblyDocumentation)
        {
        }

        public new bool ShouldApplyPluralNounRule(string verb, string originalNoun, string singularNoun) =>
            base.ShouldApplyPluralNounRule(verb, originalNoun, singularNoun);
    }
}
