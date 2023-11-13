using BenchmarkDotNet.Attributes;
using Performance.Helpers;

namespace Performance.Benchmarks
{
    public class CloudWatchLogBenchmarks : BenchmarkBase
    {

        private string logGroupName;
        private string logStreamName;
        private const int messageNumberOfCharacters = 100;
        private const int numberOfLogEvents = 10;
        private string[] _modulesToImport = { "AWS.Tools.Common", "AWS.Tools.CloudWatchLogs" };
        public override string[] ModulesToImport { get { return _modulesToImport; } }

        #region GetLogEvents
        [GlobalSetup(Target = nameof(GetLogEvents))]
        public void GlobalSetupForGetLogEvents()
        {
            logGroupName = logStreamName = "perftests" + Guid.NewGuid().ToString("N");
            string createLogGroupStreamEvents = File.ReadAllText(FileHelper.GetPowerShellScriptPath("CloudWatchLogsGlobalSetupForGetLogEvents.ps1"));
            var parameters = new Dictionary<string, object> {
                {"LogGroupName", logGroupName},
                {"LogStreamName", logStreamName},
                {"MessageNumberOfCharacters", messageNumberOfCharacters},
                {"NumberOfLogEvents",numberOfLogEvents }
            };
            InvokePowerShellScript(createLogGroupStreamEvents, parameters);
        }

        [GlobalCleanup(Target = nameof(GetLogEvents))]
        public void GlobalCleanUpForGetLogEvents()
        {
            string deleteLogGroup = @$"
                    Remove-CWLLogGroup -LogGroupName '{logGroupName}' -Force
            ";
            InvokePowerShellScript(deleteLogGroup);
        }

        [Benchmark]
        public void GetLogEvents()
        {
            string getLogEvents = @$"
                $result = Get-CWLLogEvent -LogGroupName '{logGroupName}' -LogStreamName '{logStreamName}' -StartFromHead $true
            ";
            var results = InvokePowerShellScript(getLogEvents);
        }

        #endregion

        #region DescribeLogGroups

        [Benchmark]
        public void DescribeLogGroups()
        {
            string getLogGroups = "$logGroups = Get-CWLLogGroup";
            var results = InvokePowerShellScript(getLogGroups);
        }
        #endregion
    }
}
