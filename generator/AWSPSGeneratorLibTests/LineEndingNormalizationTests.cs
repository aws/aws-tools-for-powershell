using AWSPowerShellGenerator.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AWSPSGeneratorLibTests
{
    [TestClass]
    public class LineEndingNormalizationTests
    {
        [TestMethod]
        public void LfBecomesCrlf()
        {
            Assert.AreEqual("a\r\nb\r\nc", "a\nb\nc".NormalizeLineEndingsToCrlf());
        }

        [TestMethod]
        public void MixedBecomesUniformCrlf()
        {
            // The real case: a file with some CRLF (template header) and some LF (generated body).
            Assert.AreEqual("a\r\nb\r\nc\r\nd", "a\r\nb\nc\r\nd".NormalizeLineEndingsToCrlf());
        }

        [TestMethod]
        public void AlreadyCrlfIsUnchanged()
        {
            // Windows output is already all CRLF, so normalizing it must be a no-op.
            const string crlf = "a\r\nb\r\nc\r\n";
            Assert.AreEqual(crlf, crlf.NormalizeLineEndingsToCrlf());
        }

        [TestMethod]
        public void NullAndEmptyAreSafe()
        {
            Assert.IsNull(((string)null).NormalizeLineEndingsToCrlf());
            Assert.AreEqual("", "".NormalizeLineEndingsToCrlf());
        }
    }
}
