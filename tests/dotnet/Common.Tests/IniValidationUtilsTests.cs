using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Amazon.PowerShell.Common.Internal;

namespace Common.Tests
{
    [TestClass]
    public class IniValidationUtilsTests
    {
        [TestMethod]
        public void ValidateSectionNameComponent_SimpleName_DoesNotThrow()
        {
            IniValidationUtils.ValidateSectionNameComponent("my-session", "SessionName");
        }

        [TestMethod]
        public void ValidateSectionNameComponent_NameWithSpacesAndSymbols_DoesNotThrow()
        {
            IniValidationUtils.ValidateSectionNameComponent("my session-111111111111", "SessionName");
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("   ")]
        public void ValidateSectionNameComponent_NullOrWhiteSpace_Throws(string value)
        {
            Assert.ThrowsException<ArgumentException>(
                () => IniValidationUtils.ValidateSectionNameComponent(value, "SessionName"));
        }

        [TestMethod]
        public void ValidateSectionNameComponent_LineFeed_Throws()
        {
            var payload = "candidate]\n[profile victim-profile]\ncredential_process = evil\n[sso-session tail";

            var ex = Assert.ThrowsException<ArgumentException>(
                () => IniValidationUtils.ValidateSectionNameComponent(payload, "SessionName"));

            StringAssert.Contains(ex.Message, "invalid characters");
        }

        [TestMethod]
        public void ValidateSectionNameComponent_CarriageReturnLineFeed_Throws()
        {
            var payload = "candidate]\r\n[profile victim-profile]\r\ncredential_process = evil";

            Assert.ThrowsException<ArgumentException>(
                () => IniValidationUtils.ValidateSectionNameComponent(payload, "SessionName"));
        }

        [DataTestMethod]
        [DataRow("has[bracket")]
        [DataRow("has]bracket")]
        [DataRow("[wrapped]")]
        public void ValidateSectionNameComponent_Brackets_Throw(string value)
        {
            Assert.ThrowsException<ArgumentException>(
                () => IniValidationUtils.ValidateSectionNameComponent(value, "SessionName"));
        }

        [TestMethod]
        public void ValidateSectionNameComponent_ThrownArgumentException_UsesProvidedParamName()
        {
            var ex = Assert.ThrowsException<ArgumentException>(
                () => IniValidationUtils.ValidateSectionNameComponent("bad\nname", "ProfileName"));

            Assert.AreEqual("ProfileName", ex.ParamName);
        }

        [DataTestMethod]
        [DataRow("sso:account:access")]
        [DataRow("valid value with spaces")]
        [DataRow(null)]
        [DataRow("")]
        public void ValidatePropertyValue_NoLineBreaks_DoesNotThrow(string value)
        {
            // Null/empty are allowed here; optional properties are simply not written by the caller.
            IniValidationUtils.ValidatePropertyValue(value, "SsoRegistrationScopes");
        }

        [TestMethod]
        public void ValidatePropertyValue_LineFeedInjectsSection_Throws()
        {
            // A registration-scopes value that tries to start a new profile section with a credential_process.
            var payload = "sso:account:access\n[profile victim-profile]\ncredential_process = evil";

            var ex = Assert.ThrowsException<ArgumentException>(
                () => IniValidationUtils.ValidatePropertyValue(payload, "SsoRegistrationScopes"));

            StringAssert.Contains(ex.Message, "invalid characters");
            Assert.AreEqual("SsoRegistrationScopes", ex.ParamName);
        }

        [TestMethod]
        public void ValidatePropertyValue_CarriageReturnLineFeed_Throws()
        {
            var payload = "sso:account:access\r\n[profile victim-profile]\r\ncredential_process = evil";

            Assert.ThrowsException<ArgumentException>(
                () => IniValidationUtils.ValidatePropertyValue(payload, "SsoRegistrationScopes"));
        }

        [TestMethod]
        public void ValidatePropertyValue_BareCarriageReturn_Throws()
        {
            Assert.ThrowsException<ArgumentException>(
                () => IniValidationUtils.ValidatePropertyValue("value\rmore", "SsoRegion"));
        }
    }
}
