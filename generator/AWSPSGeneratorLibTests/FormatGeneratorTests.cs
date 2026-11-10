using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Xml;
using AWSPowerShellGenerator.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amazon.PowerShell.Common
{
    // Matched by full name, as the generator does for the attribute in the built cmdlet assembly.
    [AttributeUsage(AttributeTargets.Class)]
    public class AWSCmdletAttribute : Attribute
    {
        public Type SelectReturnType { get; set; }
    }
}

namespace AWSPSGeneratorLibTests
{
    [TestClass]
    public class FormatGeneratorTests
    {
        private const string Secret = "SECRET-7f3a9";
        private const string Redacted = "*** sensitive data redacted from host ***";

        public class FakeItem
        {
            public string Name { get; set; }
        }

        private class FakeResponse
        {
            [Amazon.Runtime.Internal.AWSProperty(Sensitive = true)]
            public List<FakeItem> Items { get; set; }

            [Amazon.Runtime.Internal.AWSProperty(Sensitive = true)]
            public Dictionary<string, string> Tags { get; set; }

            [Amazon.Runtime.Internal.AWSProperty(Sensitive = true)]
            public string EmbedUrl { get; set; }

            [Amazon.Runtime.Internal.AWSProperty(Sensitive = false)]
            public List<string> Names { get; set; }
        }

        [Amazon.PowerShell.Common.AWSCmdlet(SelectReturnType = typeof(FakeResponse))]
        private class FakeCmdlet { }

        private static string Write(Action<XmlWriter> write)
        {
            var output = new StringBuilder();
            using (var writer = XmlWriter.Create(output, new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Fragment }))
            {
                write(writer);
            }
            return output.ToString();
        }

        private static string Format(string viewsXml, object tagged, string formatCommand, bool showSensitiveData = false)
        {
            var path = Path.Combine(Path.GetTempPath(), $"sspo-{Guid.NewGuid():N}.Format.ps1xml");
            File.WriteAllText(path, $"<Configuration>{viewsXml}</Configuration>");
            try
            {
                using (var ps = System.Management.Automation.PowerShell.Create())
                {
                    ps.AddCommand("Update-FormatData").AddParameter("PrependPath", path).Invoke();
                    ps.Commands.Clear();
                    ps.Runspace.SessionStateProxy.SetVariable("AWSPowerShell_Show_Sensitive_Data", showSensitiveData);
                    var result = ps.AddCommand(formatCommand).AddCommand("Out-String").AddParameter("Width", 200).Invoke(new object[] { tagged });
                    Assert.AreEqual(0, ps.Streams.Error.Count, string.Join("; ", ps.Streams.Error));
                    return string.Concat(result);
                }
            }
            finally
            {
                File.Delete(path);
            }
        }

        private static PSObject Tag(object value)
        {
            var tagged = PSObject.AsPSObject(value);
            tagged.TypeNames.Insert(0, $"{FormatGenerator.SensitiveDataTypeName}#{value.GetType().FullName}");
            tagged.TypeNames.Insert(1, FormatGenerator.SensitiveDataTypeName);
            return tagged;
        }

        private static string GenericViews() => Write(w =>
        {
            FormatGenerator.WriteSensitiveDataDefaultSettings(w);
            w.WriteStartElement("ViewDefinitions");
            FormatGenerator.WriteGenericSensitiveDataViews(w);
            w.WriteEndElement();
        });

        // Tagged as SensitiveOutput.RedactOnHost does on PowerShell 7.
        private static PSObject TagString(string value)
        {
            var tagged = Tag(value);
            tagged.Properties.Add(new PSNoteProperty("AWSSensitive", Redacted));
            return tagged;
        }

        private static void AssertRedacted(string output, bool showSensitiveData)
        {
            Assert.AreEqual(showSensitiveData, output.Contains(Secret), output);
            Assert.AreEqual(!showSensitiveData, output.Contains(Redacted), output);
        }

        [TestMethod]
        [DataRow(true, "TableControl,ListControl")]
        [DataRow(false, "TableControl")]
        public void TypeViews_AddOtherKindOnlyForSensitiveColumns(bool isSensitive, string expectedControls)
        {
            var config = new AWSPowerShellGenerator.FormatConfig.ConfigModel();
            config.Columns.Add(new AWSPowerShellGenerator.FormatConfig.ColumnConfig { HeaderLabel = "Name", PropertyName = "Name", IsSensitive = isSensitive });

            var views = Write(w => FormatGenerator.GenerateView_NonReflective(config, w, typeof(FakeItem)));

            var controls = System.Text.RegularExpressions.Regex.Matches(views, "<(TableControl|ListControl)>").Select(m => m.Groups[1].Value).ToArray();
            CollectionAssert.AreEqual(expectedControls.Split(','), controls);
            Assert.AreEqual(isSensitive ? controls.Length : 0, System.Text.RegularExpressions.Regex.Matches(views, System.Text.RegularExpressions.Regex.Escape(Redacted)).Count);
        }

        [TestMethod]
        public void SensitiveOutputTypes_AreElementTypesOfSensitiveNonStringMembers()
        {
            var types = FormatGenerator.GetSensitiveOutputTypes(new[] { typeof(FakeCmdlet), typeof(FakeItem) });

            CollectionAssert.AreEquivalent(new[] { typeof(FakeItem), typeof(Dictionary<string, string>) }, types.ToArray());
        }

        [TestMethod]
        [DataRow("Format-Table", false)]
        [DataRow("Format-List", false)]
        [DataRow("Format-List", true)]
        public void PerTypeViews_RedactEveryColumnUnlessRedactionIsOff(string formatCommand, bool showSensitiveData)
        {
            var views = $"<ViewDefinitions>{Write(w => FormatGenerator.WriteSensitiveOutputViews(w, typeof(FakeItem), new[] { nameof(FakeItem.Name) }))}</ViewDefinitions>";

            var output = Format(views, Tag(new FakeItem { Name = Secret }), formatCommand, showSensitiveData);

            AssertRedacted(output, showSensitiveData);
        }

        [TestMethod]
        [DataRow("Format-Table", false)]
        [DataRow("Format-List", false)]
        [DataRow("Format-Custom", false)]
        [DataRow("Format-Wide", false)]
        [DataRow("Format-Table", true)]
        public void GenericViews_RedactTaggedDictionaryUnlessRedactionIsOff(string formatCommand, bool showSensitiveData)
        {
            var output = Format(GenericViews(), Tag(new Dictionary<string, string> { ["owner"] = Secret }), formatCommand, showSensitiveData);

            AssertRedacted(output, showSensitiveData);
        }

        [TestMethod]
        [DataRow("Write-Output", false)]
        [DataRow("Write-Output", true)]
        [DataRow("Format-List", false)]
        [DataRow("Format-Wide", false)]
        public void StringView_RedactsTaggedString(string formatCommand, bool afterOtherOutput)
        {
            var input = afterOtherOutput ? new object[] { new DateTime(2026, 1, 1), TagString(Secret) } : (object)TagString(Secret);

            var output = Format(GenericViews(), input, formatCommand);

            AssertRedacted(output, showSensitiveData: false);
            Assert.IsFalse(output.Contains("Length"), output);
        }

        [TestMethod]
        public void StringView_ShowsWholeValueWhenRedactionIsOff()
        {
            var longValue = Secret + new string('a', 400);

            var output = Format(GenericViews(), TagString(longValue), "Write-Output", showSensitiveData: true);

            Assert.AreEqual(longValue, output.Trim());
        }
    }
}
