using BenchmarkDotNet.Attributes;
using Performance.Helpers;

namespace Performance.Benchmarks
{
    public class EC2Benchmarks : BenchmarkBase
    {
        private readonly string performanceTestTagValue = "perftests" + Guid.NewGuid().ToString("N");
        private readonly int NumberOfTags = 10;
        private readonly string amiSSMParameter = "/aws/service/ami-amazon-linux-latest/al2023-ami-minimal-kernel-default-x86_64";
        private string[] _modulesToImport = { "AWS.Tools.Common", "AWS.Tools.EC2" };
        public override string[] ModulesToImport { get { return _modulesToImport; } }

        [GlobalSetup]
        public void GlobalSetup()
        {
            // Create EC2 instance with tags
            string createEc2InstanceScript = File.ReadAllText(FileHelper.GetPowerShellScriptPath("EC2GlobalSetup.ps1"));
            var parameters = new Dictionary<string, object> {
                {"NumberOfTags", NumberOfTags},
                {"PerformanceTestTagValue", performanceTestTagValue},
                {"AMISSMParameter", amiSSMParameter}
            };
            InvokePowerShellScript(createEc2InstanceScript, parameters);
        }
        [GlobalCleanup]
        public void GlobalCleanup()
        {
            // Delete EC2 instance by looking for tag with value from performanceTestTagValue
            string deleteEc2InstanceScript = File.ReadAllText(FileHelper.GetPowerShellScriptPath("EC2GlobalCleanup.ps1"));
            var parameters = new Dictionary<string, object> {
                {"PerformanceTestTagValue", performanceTestTagValue}
            };
            InvokePowerShellScript(deleteEc2InstanceScript, parameters);
        }

        #region DescribeTags

        [Benchmark]
        public void DescribeTags()
        {
            string describeTagsScript = "$tags = Get-EC2Tag";
            InvokePowerShellScript(describeTagsScript);
        }
        #endregion

        #region DescribeInstances
        [Benchmark]
        public void DescribeInstances()
        {
            string describeInstancesScript = "$instances = Get-EC2Instance";
            InvokePowerShellScript(describeInstancesScript);
        }
        #endregion
    }
}
