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
    public class OperationAnalyzerTests
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

        private ServiceOperation CreateAutoConfiguringOperation() => new()
        {
            MethodName = "TestOperation",
            IsAutoConfiguring = true
        };

        private TestableOperationAnalyzer CreateAnalyzer(ServiceOperation operation) =>
            new(_allModels, _testModel, operation, null);

        private SimplePropertyInfo CreateParameter(string name, Type type = null, bool isMetadata = false, bool isDeprecated = false, bool isRequired = false)
        {
            type ??= typeof(string);
            var mockProperty = new MockPropertyInfo(name, type);
            if (isDeprecated)
                mockProperty.SetDeprecated(true);

            var parameter = new SimplePropertyInfo(
                mockProperty, 
                null, 
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

    [TestClass]
    public class SelectPreferredCandidateParametersTests
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

        private SimplePropertyInfo CreateParameter(string name, Type type = null, bool isMetadata = false, bool isDeprecated = false, bool isRequired = false)
        {
            type ??= typeof(string);
            var mockProperty = new MockPropertyInfo(name, type);
            if (isDeprecated)
                mockProperty.SetDeprecated(true);

            var parameter = new SimplePropertyInfo(
                mockProperty,
                null,
                type.Name,
                null,
                SimplePropertyInfo.PropertyCollectionType.NoCollection,
                null);

            if (isMetadata)
                _testModel.MetadataPropertyNames.Add(name);

            if (isRequired)
            {
                // Set required using reflection since it's a private field
                var field = typeof(SimplePropertyInfo).GetField("_isRequired", BindingFlags.NonPublic | BindingFlags.Instance);
                field?.SetValue(parameter, true);
            }

            return parameter;
        }

        private ServiceOperation CreateAutoConfiguringOperation() => new()
        {
            MethodName = "TestOperation",
            IsAutoConfiguring = true
        };

        private TestableOperationAnalyzer CreateAnalyzer(ServiceOperation operation) =>
            new(_allModels, _testModel, operation, null);
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
