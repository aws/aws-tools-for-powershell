using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.PowerShell.Common;

namespace Common.Tests
{
    [TestClass]
    public class FormatParameterValuesTests
    {
        private TestCmdlet _cmdlet;
        private Dictionary<string, object> _boundParameters;

        [TestInitialize]
        public void Setup()
        {
            _cmdlet = new TestCmdlet();
            _boundParameters = new Dictionary<string, object>();
        }

        [TestMethod]
        public void FormatParameterValuesForConfirmationMsg_SingleStringParameter_ReturnsValue()
        {
            // Arrange
            _boundParameters["ResourceId"] = "bucket-123";

            // Act
            var result = _cmdlet.TestFormatParameterValuesForConfirmationMsg("ResourceId", _boundParameters);

            // Assert
            Assert.AreEqual("bucket-123", result);
        }

        [TestMethod]
        public void FormatParameterValuesForConfirmationMsg_SingleStringArray_ReturnsFormattedList()
        {
            // Arrange
            _boundParameters["ResourceIds"] = new[] { "bucket-1", "bucket-2", "bucket-3" };

            // Act
            var result = _cmdlet.TestFormatParameterValuesForConfirmationMsg("ResourceIds", _boundParameters);

            // Assert
            Assert.AreEqual("bucket-1, bucket-2, bucket-3", result);
        }

        [TestMethod]
        public void FormatParameterValuesForConfirmationMsg_LargeStringArray_TruncatesWithCount()
        {
            // Arrange - Create array with more than 10 items (ArrayTruncationThreshold)
            var largeArray = Enumerable.Range(1, 15).Select(i => $"item-{i}").ToArray();
            _boundParameters["ResourceIds"] = largeArray;

            // Act
            var result = _cmdlet.TestFormatParameterValuesForConfirmationMsg("ResourceIds", _boundParameters);

            // Assert
            StringAssert.Contains(result, "item-1, item-2");
            StringAssert.Contains(result, "item-10");
            StringAssert.Contains(result, "(plus 5 more)");
            Assert.IsFalse(result.Contains("item-11")); // Should not contain truncated items
        }

        [TestMethod]
        public void FormatParameterValuesForConfirmationMsg_MultipleParameters_ConcatenatesWithHyphens()
        {
            // Arrange
            _boundParameters["ResourceId"] = "bucket-123";
            _boundParameters["ResourceName"] = "MyBucket";
            _boundParameters["ResourceArn"] = "arn:aws:s3:::bucket-123";

            // Act
            var result = _cmdlet.TestFormatParameterValuesForConfirmationMsg(
                new[] { "ResourceId", "ResourceName", "ResourceArn" }, _boundParameters);

            // Assert
            Assert.AreEqual("bucket-123-MyBucket-arn:aws:s3:::bucket-123", result);
        }

        [TestMethod]
        public void FormatParameterValuesForConfirmationMsg_MultipleParametersLongResult_TruncatesTo100Characters()
        {
            // Arrange - Create values that will exceed 100 characters when concatenated
            _boundParameters["ResourceId"] = "very-long-resource-identifier-that-exceeds-normal-length-limits";
            _boundParameters["ResourceName"] = "another-very-long-resource-name-that-adds-to-the-total-length";
            _boundParameters["ResourceArn"] = "arn:aws:s3:::very-long-bucket-name-that-makes-this-even-longer";

            // Act
            var result = _cmdlet.TestFormatParameterValuesForConfirmationMsg(
                new[] { "ResourceId", "ResourceName", "ResourceArn" }, _boundParameters);

            // Assert
            Assert.IsTrue(result.Length <= 103); // 100 + "..." = 103
            StringAssert.EndsWith(result, "...");
        }

        [TestMethod]
        public void FormatParameterValuesForConfirmationMsg_MultipleParametersWithArray_UsesOnlyFirstParameter()
        {
            // Arrange - When any parameter is an array, should fall back to first parameter only
            _boundParameters["ResourceId"] = "bucket-123";
            _boundParameters["ResourceIds"] = new[] { "bucket-1", "bucket-2" }; // Array parameter
            _boundParameters["ResourceName"] = "MyBucket";

            // Act
            var result = _cmdlet.TestFormatParameterValuesForConfirmationMsg(
                new[] { "ResourceId", "ResourceIds", "ResourceName" }, _boundParameters);

            // Assert
            Assert.AreEqual("bucket-123", result); // Should only use first parameter when array is present
        }

        [TestMethod]
        public void FormatParameterValuesForConfirmationMsg_NullOrMissingParameters_ReturnsEmpty()
        {
            // Test null parameter names
            var result1 = _cmdlet.TestFormatParameterValuesForConfirmationMsg((string[])null, _boundParameters);
            Assert.AreEqual(string.Empty, result1);

            // Test empty parameter names
            var result2 = _cmdlet.TestFormatParameterValuesForConfirmationMsg(new string[0], _boundParameters);
            Assert.AreEqual(string.Empty, result2);

            // Test missing parameter in bound parameters
            var result3 = _cmdlet.TestFormatParameterValuesForConfirmationMsg("NonExistentParam", _boundParameters);
            Assert.AreEqual(string.Empty, result3);

            // Test null bound parameters
            var result4 = _cmdlet.TestFormatParameterValuesForConfirmationMsg("ResourceId", null);
            Assert.AreEqual(string.Empty, result4);
        }

        [TestMethod]
        public void FormatParameterValuesForConfirmationMsg_ValueTypes_FormatsCorrectly()
        {
            // Arrange
            _boundParameters["IntParam"] = 42;
            _boundParameters["BoolParam"] = true;
            _boundParameters["DoubleParam"] = 3.14;

            // Act & Assert
            Assert.AreEqual("42", _cmdlet.TestFormatParameterValuesForConfirmationMsg("IntParam", _boundParameters));
            Assert.AreEqual("True", _cmdlet.TestFormatParameterValuesForConfirmationMsg("BoolParam", _boundParameters));
            Assert.AreEqual("3.14", _cmdlet.TestFormatParameterValuesForConfirmationMsg("DoubleParam", _boundParameters));
        }

        [TestMethod]
        public void FormatParameterValuesForConfirmationMsg_ComplexObjectArray_HandlesNullItems()
        {
            // Arrange
            _boundParameters["ComplexArray"] = new object[] { "item1", null, "item3", null };

            // Act
            var result = _cmdlet.TestFormatParameterValuesForConfirmationMsg("ComplexArray", _boundParameters);

            // Assert
            Assert.AreEqual("item1, null, item3, null", result);
        }

        [TestMethod]
        public void FormatParameterValuesForConfirmationMsg_BackwardCompatibility_SingleParameterOverload()
        {
            // Arrange
            _boundParameters["ResourceId"] = "bucket-123";

            // Act - Test the single parameter overload for backward compatibility
            var result = _cmdlet.TestFormatParameterValuesForConfirmationMsg("ResourceId", _boundParameters);

            // Assert
            Assert.AreEqual("bucket-123", result);
        }

        [TestMethod]
        public void FormatParameterValuesForConfirmationMsg_ExceptionHandling_ReturnsEmptyOnError()
        {
            // Arrange - Create a scenario that might cause an exception
            _boundParameters["BadParam"] = new ThrowingObject();

            // Act
            var result = _cmdlet.TestFormatParameterValuesForConfirmationMsg("BadParam", _boundParameters);

            // Assert - Should return fallback message when ToString() throws, not empty string
            StringAssert.Contains(result, "values bound to the parameter BadParam");
        }

        /// <summary>
        /// Test cmdlet that inherits from the actual BaseCmdlet to expose the protected FormatParameterValuesForConfirmationMsg method
        /// This uses the real implementation from the current base class without duplicating code
        /// </summary>
        private class TestCmdlet : BaseCmdlet
        {
            public string TestFormatParameterValuesForConfirmationMsg(string targetParameterName, IDictionary<string, object> boundParameters)
            {
                return FormatParameterValuesForConfirmationMsg(targetParameterName, boundParameters);
            }

            public string TestFormatParameterValuesForConfirmationMsg(string[] targetParameterNames, IDictionary<string, object> boundParameters)
            {
                return FormatParameterValuesForConfirmationMsg(targetParameterNames, boundParameters);
            }
        }

        /// <summary>
        /// Helper class that throws an exception when ToString() is called
        /// </summary>
        private class ThrowingObject
        {
            public override string ToString()
            {
                throw new InvalidOperationException("Test exception");
            }
        }
    }
}
