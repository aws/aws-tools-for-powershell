using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Amazon.Runtime.CredentialManagement;
using Amazon.PowerShell.Common;

namespace Common.Tests
{
    [TestClass]
    public class CredentialProfileValidationTests
    {
        [DataTestMethod]
        [DataRow("bad\rname")]
        [DataRow("bad\nname")]
        [DataRow("bad\r\nname")]
        [DataRow("bad[name")]
        [DataRow("bad]name")]
        [DataRow("   ")]
        [DataRow("legit]\r\n[attacker]\r\ncredential_process=unused\r\n[tail")]
        public void SetCredential_InvalidStoreAs_IsRejectedBeforeCredentialResolution(string name)
        {
            var cmdlet = new TestSetCredentialCmdlet { StoreAs = name };

            var error = Assert.ThrowsException<ArgumentException>(() => cmdlet.Run());

            Assert.AreEqual("StoreAs", error.ParamName);
        }

        [DataTestMethod]
        [DataRow("bad\rname")]
        [DataRow("bad\nname")]
        [DataRow("bad\r\nname")]
        [DataRow("bad[name")]
        [DataRow("bad]name")]
        [DataRow("   ")]
        [DataRow("legit]\r\n[attacker]\r\ncredential_process=unused\r\n[tail")]
        public void SetSamlRoleProfile_InvalidStoreAs_IsRejectedBeforeAuthentication(string name)
        {
            var cmdlet = new TestSetSamlRoleProfileCmdlet { StoreAs = name };

            var error = Assert.ThrowsException<ArgumentException>(() => cmdlet.Run());

            Assert.AreEqual("StoreAs", error.ParamName);
        }

        public static IEnumerable<object[]> InvalidProfileValues()
        {
            // Enumerating the SDK properties also catches missing validation after SDK upgrades.
            foreach (var property in typeof(CredentialProfileOptions).GetProperties()
                .Where(property => property.PropertyType == typeof(string)))
            {
                foreach (var value in new[] { "bad\rvalue", "bad\nvalue", "bad\r\nvalue",
                    "value\n[injected]\ncredential_process=unused" })
                {
                    foreach (var existingFile in new[] { false, true })
                        yield return new object[] { property.Name, value, existingFile };
                }
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(InvalidProfileValues), DynamicDataSourceType.Method)]
        public void RegisterProfile_InvalidValue_IsRejectedWithoutChangingFile(string propertyName, string value, bool existingFile)
        {
            var directory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(directory);
            try
            {
                var path = Path.Combine(directory, "credentials");
                var original = "[existing]\naws_access_key_id=original\naws_secret_access_key=original\n";
                if (existingFile)
                    File.WriteAllText(path, original);
                var before = existingFile ? File.ReadAllBytes(path) : null;
                var options = new CredentialProfileOptions { AccessKey = "access_key", SecretKey = "secret_key" };
                typeof(CredentialProfileOptions).GetProperty(propertyName)!.SetValue(options, value);

                var error = Assert.ThrowsException<ArgumentException>(() =>
                    SettingsStore.RegisterProfile(options, "safe-profile", path, null));

                Assert.AreEqual(propertyName, error.ParamName);
                if (existingFile)
                    CollectionAssert.AreEqual(before, File.ReadAllBytes(path));
                else
                    Assert.IsFalse(File.Exists(path));
            }
            finally
            {
                Directory.Delete(directory, true);
            }
        }

        [DataTestMethod]
        [DataRow("us-west-2\r[injected]", false)]
        [DataRow("us-west-2\r[injected]", true)]
        [DataRow("us-west-2\n[injected]", false)]
        [DataRow("us-west-2\n[injected]", true)]
        [DataRow("us-west-2\r\n[injected]", false)]
        [DataRow("us-west-2\r\n[injected]", true)]
        [DataRow("us-west-2\n[injected]\ncredential_process=unused", false)]
        [DataRow("us-west-2\n[injected]\ncredential_process=unused", true)]
        public void RegisterProfile_InvalidRegion_IsRejectedWithoutChangingFile(string systemName, bool existingFile)
        {
            var directory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(directory);
            try
            {
                var path = Path.Combine(directory, "credentials");
                if (existingFile)
                    File.WriteAllText(path, "[existing]\naws_access_key_id=original\naws_secret_access_key=original\n");
                var before = existingFile ? File.ReadAllBytes(path) : null;
                var options = new CredentialProfileOptions { AccessKey = "access_key", SecretKey = "secret_key" };
                // Bypass SDK construction checks to exercise validation at the persistence boundary.
                var region = (Amazon.RegionEndpoint)Activator.CreateInstance(typeof(Amazon.RegionEndpoint),
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                    null, new object[] { systemName, "Test region", "aws", "amazonaws.com", ".*",
                        "{service}.{region}.{dnsSuffix}" }, null)!;

                var error = Assert.ThrowsException<ArgumentException>(() =>
                    SettingsStore.RegisterProfile(options, "safe-profile", path, region));

                Assert.AreEqual("region", error.ParamName);
                if (existingFile)
                    CollectionAssert.AreEqual(before, File.ReadAllBytes(path));
                else
                    Assert.IsFalse(File.Exists(path));
            }
            finally
            {
                Directory.Delete(directory, true);
            }
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("us-west-2")]
        public void RegisterProfile_ValidOrAbsentRegion_IsPreserved(string systemName)
        {
            var directory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(directory);
            try
            {
                var path = Path.Combine(directory, "credentials");
                var options = new CredentialProfileOptions { AccessKey = "access_key", SecretKey = "secret_key" };
                var region = systemName == null ? null : Amazon.RegionEndpoint.GetBySystemName(systemName);

                SettingsStore.RegisterProfile(options, "safe-profile", path, region);

                Assert.IsTrue(new SharedCredentialsFile(path).TryGetProfile("safe-profile", out var saved));
                Assert.AreEqual(systemName, saved.Region?.SystemName);
            }
            finally
            {
                Directory.Delete(directory, true);
            }
        }

        private class TestSetCredentialCmdlet : SetCredentialCmdlet
        {
            public void Run() => ProcessRecord();
        }

        private class TestSetSamlRoleProfileCmdlet : SetSamlRoleProfileCmdlet
        {
            public void Run() => ProcessRecord();
        }
    }
}
