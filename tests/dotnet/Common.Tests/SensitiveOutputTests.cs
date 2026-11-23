using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Amazon.PowerShell.Common;
using Amazon.Runtime.Internal;

namespace Common.Tests
{
    [TestClass]
    public class SensitiveOutputTests
    {
        private class WithSensitiveProperty
        {
            public string? Name { get; set; }

            [AWSProperty(Sensitive = true)]
            public string? Token { get; set; }
        }

        private class WithoutSensitiveProperty
        {
            [AWSProperty(Required = true)]
            public string? Name { get; set; }
        }

        private const BindingFlags Internal = BindingFlags.NonPublic | BindingFlags.Static;

        private static bool HasSensitiveData(object? value) =>
            (bool)typeof(SensitiveOutput).GetMethod("HasSensitiveData", Internal)!.Invoke(null, new[] { value })!;

        [TestMethod]
        public void HasSensitiveData_IsTrueOnlyForTypesWithASensitiveProperty()
        {
            Assert.IsTrue(HasSensitiveData(new WithSensitiveProperty()));
            Assert.IsFalse(HasSensitiveData(new WithoutSensitiveProperty()));
            Assert.IsFalse(HasSensitiveData("value"));
            Assert.IsFalse(HasSensitiveData(null));
        }

        [TestMethod]
        public void RemoteSessionWarning_DoesNotThrowWhenTheCheckFails()
        {
            // A null cmdlet makes every step of the check fail.
            var warns = typeof(SensitiveOutput).GetMethod("WarnsInRemoteSession", Internal)!.Invoke(null, new object?[] { null });
            var done = typeof(SensitiveOutput).GetMethod("WarnOnSensitiveData", Internal)!.Invoke(null, new object?[] { null, new WithSensitiveProperty() });

            Assert.AreEqual(false, warns);
            Assert.AreEqual(true, done);
        }
    }
}
