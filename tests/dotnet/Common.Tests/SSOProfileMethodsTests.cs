using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Amazon.PowerShell.Utils;

namespace Common.Tests
{
    [TestClass]
    public class SSOProfileMethodsTests
    {
        [TestMethod]
        public void ValidateSectionNameComponent_SimpleName_DoesNotThrow()
        {
            SSOProfileMethods.ValidateSectionNameComponent("my-session", "SessionName");
        }

        [TestMethod]
        public void ValidateSectionNameComponent_NameWithSpacesAndSymbols_DoesNotThrow()
        {
            SSOProfileMethods.ValidateSectionNameComponent("111111111111-ReadOnly", "SessionName");
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("   ")]
        public void ValidateSectionNameComponent_NullOrWhiteSpace_Throws(string value)
        {
            Assert.ThrowsException<ArgumentException>(
                () => SSOProfileMethods.ValidateSectionNameComponent(value, "SessionName"));
        }

        [TestMethod]
        public void ValidateSectionNameComponent_LineFeed_Throws()
        {
            var payload = "candidate]\n[profile victim-profile]\ncredential_process = evil\n[sso-session tail";

            var ex = Assert.ThrowsException<ArgumentException>(
                () => SSOProfileMethods.ValidateSectionNameComponent(payload, "SessionName"));

            StringAssert.Contains(ex.Message, "invalid characters");
        }

        [TestMethod]
        public void ValidateSectionNameComponent_CarriageReturnLineFeed_Throws()
        {
            var payload = "candidate]\r\n[profile victim-profile]\r\ncredential_process = evil";

            Assert.ThrowsException<ArgumentException>(
                () => SSOProfileMethods.ValidateSectionNameComponent(payload, "SessionName"));
        }

        [DataTestMethod]
        [DataRow("has[bracket")]
        [DataRow("has]bracket")]
        [DataRow("[wrapped]")]
        public void ValidateSectionNameComponent_Brackets_Throw(string value)
        {
            Assert.ThrowsException<ArgumentException>(
                () => SSOProfileMethods.ValidateSectionNameComponent(value, "SessionName"));
        }

        [TestMethod]
        public void ValidateSectionNameComponent_ThrownArgumentException_UsesProvidedParamName()
        {
            var ex = Assert.ThrowsException<ArgumentException>(
                () => SSOProfileMethods.ValidateSectionNameComponent("bad\nname", "ProfileName"));

            Assert.AreEqual("ProfileName", ex.ParamName);
        }
    }
}
