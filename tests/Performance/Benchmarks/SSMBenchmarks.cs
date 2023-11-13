using BenchmarkDotNet.Attributes;
using Performance.Helpers;

namespace Performance.Benchmarks
{
    public class SSMBenchmarks : BenchmarkBase
    {
        private readonly string parameterName = "perftests" + Guid.NewGuid().ToString("N");
        private readonly string documentName = "perftests" + Guid.NewGuid().ToString("N");
        private readonly string documentContent = File.ReadAllText(FileHelper.GetDataFilePath("SSMDocument.json"));

        private readonly int NumberOfTags = 10;
        private string[] _modulesToImport = { "AWS.Tools.Common", "AWS.Tools.SimpleSystemsManagement" };
        public override string[] ModulesToImport { get { return _modulesToImport; } }

        #region GetParameter
        [GlobalSetup(Target = nameof(GetParameter))]
        public void GlobalSetupForGetParameter()
        {
            string createSSMParameter = @$"
                 $null =  Write-SSMParameter -Type String -Description 'this is an ssm parameter' -Name '{parameterName}' -Value ""this is a test value""
            ";
            InvokePowerShellScript(createSSMParameter);
        }

        [GlobalCleanup(Target = nameof(GetParameter))]
        public void GlobalCleanupForGetParameter()
        {
            string deleteSSMParameter = $"$null =  Remove-SSMParameter -Name '{parameterName}' -Force";
            InvokePowerShellScript(deleteSSMParameter);
        }

        [Benchmark]
        public void GetParameter()
        {
            string getParameter = @$"
                $result = Get-SSMParameter -Name '{parameterName}'
            ";
            InvokePowerShellScript(getParameter);
        }
        #endregion

        #region ListTagsForResource
        [GlobalSetup(Target = nameof(ListTagsForResource))]
        public void GlobalSetupForListTagsForResource()
        {
            // generate tags in the format @{"key"="tag1";"value"="value1"},@{"key"="tag2";"value"="value2"}
            var tags = string.Join(",", Enumerable.Range(1, NumberOfTags).Select(i => $"@{{'key'='tag{i}';'value'='value{i}'}}"));
            string createSSMParameter = @$"
                $result = New-SSMDocument -Content '{documentContent}' -Name '{documentName}' -DocumentFormat JSON -DocumentType Command -Tag {tags}";
            InvokePowerShellScript(createSSMParameter);
        }

        [GlobalCleanup(Target = nameof(ListTagsForResource))]
        public void GlobalCleanupForListTagsForResource()
        {
            string createSSMParameter = $"$result = Remove-SSMDocument -Name '{documentName}' -Force";
            InvokePowerShellScript(createSSMParameter);
        }

        [Benchmark]
        public void ListTagsForResource()
        {
            string getParameter = @$"
                $result = Get-SsmResourceTag -ResourceType Document -ResourceId '{documentName}'
            ";
            InvokePowerShellScript(getParameter);
        }
        #endregion
    }
}
