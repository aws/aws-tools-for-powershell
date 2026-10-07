using Amazon;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace Common.Tests
{
    [TestClass]
    public class LoginProfileRegionTests
    {
        private const string LoginSession = "arn:aws:iam::123456789012:user/test";

        private string credentialsPath = null!;
        private SharedCredentialsFile store = null!;

        [TestInitialize]
        public void Setup()
        {
            credentialsPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            File.WriteAllText(credentialsPath, "");
            store = new SharedCredentialsFile(credentialsPath);
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(credentialsPath);
        }

        [TestMethod]
        public void LoginProfileWithRegion_KeepsProfileRegion()
        {
            var profile = new CredentialProfile("login", new CredentialProfileOptions { LoginSession = LoginSession })
            {
                Region = RegionEndpoint.EUWest1
            };

            var credentials = GetProfileCredentials(profile);

            Assert.AreEqual("eu-west-1", ((LoginAWSCredentials)credentials).Options.Region);
        }

        [TestMethod]
        public void LoginProfileWithoutRegion_UsesPowerShellRegionWithoutPersisting()
        {
            File.WriteAllText(credentialsPath, $"[login]\nlogin_session = {LoginSession}\n");
            var contentBefore = File.ReadAllBytes(credentialsPath);
            Assert.IsTrue(store.TryGetProfile("login", out var profile));

            var credentials = GetProfileCredentials(profile);

            Assert.AreEqual("ap-southeast-4", ((LoginAWSCredentials)credentials).Options.Region);
            CollectionAssert.AreEqual(contentBefore, File.ReadAllBytes(credentialsPath));
            Assert.IsTrue(new SharedCredentialsFile(credentialsPath).TryGetProfile("login", out var reloaded));
            Assert.IsNull(reloaded.Region);
        }

        [TestMethod]
        public void SamlProfileWithLoginSession_KeepsRegionAndFactoryBehavior()
        {
            var options = new CredentialProfileOptions
            {
                LoginSession = LoginSession,
                EndpointName = Guid.NewGuid().ToString("N"),
                RoleArn = "arn:aws:iam::123456789012:role/test"
            };
            var expected = CaptureException(() => AWSCredentialsFactory.GetAWSCredentials(new CredentialProfile("saml", options), store));
            var profile = new CredentialProfile("saml", options);

            var actual = CaptureException(() => GetProfileCredentials(profile));

            Assert.AreEqual(expected?.GetType(), actual?.GetType());
            Assert.AreEqual(expected?.Message, actual?.Message);
            Assert.IsNull(profile.Region);
        }

        // AWS.Tools.Common is strong-name signed, so InternalsVisibleTo would require signing this assembly.
        private AWSCredentials GetProfileCredentials(CredentialProfile profile)
        {
            var method = typeof(StandaloneRegionArguments).Assembly
                .GetType("Amazon.PowerShell.Common.ICredentialsArgumentsMethods", throwOnError: true)!
                .GetMethod("GetProfileCredentials", BindingFlags.Static | BindingFlags.NonPublic)!;
            var regionArguments = new StandaloneRegionArguments { Region = "ap-southeast-4" };
            try
            {
                return (AWSCredentials)method.Invoke(null, new object?[] { profile, store, regionArguments, null })!;
            }
            catch (TargetInvocationException ex) when (ex.InnerException != null)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                throw;
            }
        }

        private static Exception? CaptureException(Func<AWSCredentials> resolve)
        {
            try
            {
                resolve();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
