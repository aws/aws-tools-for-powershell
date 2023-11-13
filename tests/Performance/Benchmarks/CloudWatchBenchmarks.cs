using BenchmarkDotNet.Attributes;
using Performance.Helpers;

namespace Performance.Benchmarks
{
    public class CloudWatchBenchmarks : BenchmarkBase
    {
        private string startDateUTC;
        private string endDateUTC;
        private readonly string metricName = "perftests" + Guid.NewGuid().ToString("N");
        private readonly string metricNamespace = "perftests" + Guid.NewGuid().ToString("N");
        private readonly string metricDataQueryId = "perftests" + Guid.NewGuid().ToString("N");
        private readonly string metricStat = "Maximum";
        private readonly int metricPeriodInSeconds = 1;
        private readonly int numberOfMetricsForSetup = 100;
        private readonly int numberOfPutMetricDataRequests = 10;
        private readonly string[] _modulesToImport = { "AWS.Tools.Common", "AWS.Tools.CloudWatch" };
        public override string[] ModulesToImport { get { return _modulesToImport; } }

        #region GetMetricStatistics

        [GlobalSetup(Target = nameof(GetMetricStatistics))]
        public void GlobalSetUpForGetMetricStatistics()
        {
            startDateUTC = DateTime.UtcNow.ToString();

            string putMetricData = File.ReadAllText(FileHelper.GetPowerShellScriptPath("CloudWatchGlobalSetUpForGetMetricStatistics.ps1"));
            var parameters = new Dictionary<string, object> {
                {"MetricName", metricName},
                {"NumberOfMetricsForSetup", numberOfMetricsForSetup}
            };

            InvokePowerShellScript(putMetricData, parameters);

            endDateUTC = DateTime.UtcNow.ToString();
        }

        [Benchmark]
        public void GetMetricStatistics()
        {
            string getMetricsStatistics = File.ReadAllText(FileHelper.GetPowerShellScriptPath("CloudWatchGetMetricStatisticsBenchmark.ps1"));
            var parameters = new Dictionary<string, object> {
                {"MetricNamespace", metricNamespace},
                {"MetricName", metricName},
                {"MetricDataQueryId", metricDataQueryId},
                {"StartDateUTC", startDateUTC},
                {"EndDateUTC", endDateUTC},
                {"Period", metricPeriodInSeconds},
                {"Stat", metricStat}
            };
            var results = InvokePowerShellScript(getMetricsStatistics, parameters);
        }

        #endregion

        #region PutMetricData

        [Benchmark]
        public void PutMetricData()
        {
            string putMetricData = File.ReadAllText(FileHelper.GetPowerShellScriptPath("CloudWatchPutMetricDataBenchmark.ps1"));
            var parameters = new Dictionary<string, object> {
                {"MetricName", "PutMetricData"},
                {"NumberOfPutMetricDataRequests", numberOfPutMetricDataRequests},
            };
            var results = InvokePowerShellScript(putMetricData, parameters);
        }

        #endregion
    }
}
