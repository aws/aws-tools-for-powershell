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


        [TestMethod]
        public void SelectShouldProcessTarget_SingleCandidateAfterFiltering_SelectsCandidate()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("ProcessData");
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("DataId"), // Ends with Id - supported suffix
                CreateParameter("MetadataParam", isMetadata: true),
                CreateParameter("CollectionParam", typeof(List<string>))
            );

            // Act
            var result = analyzer.SelectShouldProcessTarget();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("DataId", result[0].AnalyzedName);
            Assert.AreEqual(1, operation.InfoMessages.Count);
            StringAssert.Contains(operation.InfoMessages[0].Message, "ShouldProcessTarget selected suffix match");
        }

        [TestMethod]
        public void SelectShouldProcessTarget_MultipleCandidatesAfterFiltering_ReturnsMultipleParameters()
        {
            // Arrange
            // Use a method name that won't have exact noun matches with the parameters
            var operation = CreateAutoConfiguringOperation("ProcessItem");
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("DataId"), // Ends with Id - supported suffix
                CreateParameter("ProcessName"), // Ends with Name - supported suffix
                CreateParameter("MetadataParam", isMetadata: true)
            );

            // Act
            var result = analyzer.SelectShouldProcessTarget();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count); // Should return the 2 candidates for multiple parameter scenario
            Assert.AreEqual(1, operation.InfoMessages.Count);
            StringAssert.Contains(operation.InfoMessages[0].Message, "ShouldProcessTarget selected multiple parameters");
        }

        [TestMethod]
        public void SelectShouldProcessTarget_NoParameters_ReturnsNull()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("SimpleOperation");
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(); // No parameters

            // Act
            var result = analyzer.SelectShouldProcessTarget();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count); // Empty list when no parameters
            Assert.AreEqual(1, operation.InfoMessages.Count);
            StringAssert.Contains(operation.InfoMessages[0].Message, "No suitable ShouldProcessTarget parameters found");
        }

        [TestMethod]
        public void DetermineSupportsShouldProcessParameter_AutoConfiguring_SetsMultipleParametersWhenThreeCandidates()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("ComplexOperation");
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("ComplexId"), // Ends with Id - supported suffix
                CreateParameter("ComplexName"), // Ends with Name - supported suffix
                CreateParameter("ComplexArn") // Ends with Arn - supported suffix
            );

            // Act
            analyzer.DetermineSupportsShouldProcessParameter();

            // Assert
            Assert.IsFalse(operation.AnonymousShouldProcessTarget);
            Assert.AreEqual("ComplexId,ComplexName,ComplexArn", operation.ShouldProcessTarget);
            Assert.AreEqual(1, operation.InfoMessages.Count);
            // Message should be about multiple parameters being selected
            StringAssert.Contains(operation.InfoMessages[0].Message, "ShouldProcessTarget selected multiple parameters");
            StringAssert.Contains(operation.InfoMessages[0].Message, "ComplexId, ComplexName, ComplexArn");
        }

        [TestMethod]
        public void DetermineSupportsShouldProcessParameter_AutoConfiguring_SetsAnonymousWhenMoreThanThreeCandidates()
        {
            // Arrange
            var operation = CreateAutoConfiguringOperation("ComplexOperation");
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("ComplexId"), // Ends with Id - supported suffix
                CreateParameter("ComplexName"), // Ends with Name - supported suffix
                CreateParameter("ComplexArn"), // Ends with Arn - supported suffix
                CreateParameter("ComplexIdentifier") // Ends with Identifier - supported suffix (4 parameters - should set anonymous)
            );

            // Act
            analyzer.DetermineSupportsShouldProcessParameter();

            // Assert
            Assert.IsTrue(operation.AnonymousShouldProcessTarget);
            Assert.AreEqual(2, operation.InfoMessages.Count);
            // First message from SelectShouldProcessTarget about multiple candidates
            StringAssert.Contains(operation.InfoMessages[0].Message, "ShouldProcessTarget multiple candidates found");
            // Second message from DetermineSupportsShouldProcessParameter about setting anonymous
            StringAssert.Contains(operation.InfoMessages[1].Message, "ShouldProcessTarget set to anonymous");
        }

        [TestMethod]
        public void SelectShouldProcessTarget_PrimitiveCollectionSupport_AllowsPrimitiveCollections()
        {
            // Arrange - Test that primitive collections are allowed in ShouldProcessTarget selection
            var operation = CreateAutoConfiguringOperation("ProcessData");
            var analyzer = CreateAnalyzer(operation);
            analyzer.SetParameters(
                CreateParameter("ResourceIds", typeof(string[])), // Primitive collection - should be allowed
                CreateParameter("ComplexObjects", typeof(List<object>)), // Complex collection - should be filtered out
                CreateParameter("MetadataParam", isMetadata: true)
            );

            // Act
            var result = analyzer.SelectShouldProcessTarget();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("ResourceIds", result[0].AnalyzedName);
            Assert.AreEqual(1, operation.InfoMessages.Count);
            StringAssert.Contains(operation.InfoMessages[0].Message, "ShouldProcessTarget selected single parameter");
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

        public new List<SimplePropertyInfo> SelectShouldProcessTargetCandidateParameters(IEnumerable<SimplePropertyInfo> parameters, bool isRequiredParameter = true, bool isRootLevelParameter = true, bool excludeCollections = false) =>
            base.SelectShouldProcessTargetCandidateParameters(parameters, isRequiredParameter, isRootLevelParameter, excludeCollections);

        public new void DetermineSupportsShouldProcessParameter() =>
            base.DetermineSupportsShouldProcessParameter();

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
}
