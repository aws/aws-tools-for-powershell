using BenchmarkDotNet.Attributes;
using Performance.Helpers;


namespace Performance.Benchmarks
{
    public class FirehoseBenchmarks : BenchmarkBase
    {
        private readonly string deliveryStreamName = "perftests" + Guid.NewGuid().ToString("N");
        private readonly string s3BucketName = "perftests" + DateTime.Now.Ticks;
        private readonly string iamRoleName = "perftestsrole" + Guid.NewGuid().ToString("N");
        private readonly string iamPolicyName = "perftestspolicy" + Guid.NewGuid().ToString("N");
        private readonly long recordSize = Constants.KB * 600;
        private readonly int numberOfRecords = 2;

        private string[] _modulesToImport = { "AWS.Tools.Common", "AWS.Tools.KinesisFirehose" };
        public override string[] ModulesToImport { get { return _modulesToImport; } }

        [GlobalSetup]
        public void GlobalSetup()
        {
            string createKinesisFirehoseScript = File.ReadAllText(FileHelper.GetPowerShellScriptPath("FirehoseGlobalSetup.ps1"));
            var parameters = new Dictionary<string, object> {
                {"DeliveryStreamName", deliveryStreamName},
                {"S3BucketName", s3BucketName},
                {"RoleName", iamRoleName},
                {"PolicyName", iamPolicyName}
            };
            var results = InvokePowerShellScript(createKinesisFirehoseScript, parameters);
        }
        [GlobalCleanup]
        public void GlobalCleanup()
        {
            string deleteKinesisFirehoseScript = File.ReadAllText(FileHelper.GetPowerShellScriptPath("FirehoseGlobalCleanup.ps1"));
            var parameters = new Dictionary<string, object> {
                {"DeliveryStreamName", deliveryStreamName},
                {"S3BucketName", s3BucketName},
                {"RoleName", iamRoleName},
                {"PolicyName", iamPolicyName}
            };
            var result = InvokePowerShellScript(deleteKinesisFirehoseScript, parameters);
        }
        #region PutRecord


        [Benchmark]
        public void PutRecord()
        {
            string putRecordScript = File.ReadAllText(FileHelper.GetPowerShellScriptPath("FirehosePutRecordBenchmarks.ps1"));
            var parameters = new Dictionary<string, object> {
                {"DeliveryStreamName", deliveryStreamName},
                {"RecordSizeInBytes", recordSize}
            };
            InvokePowerShellScript(putRecordScript, parameters);
        }
        #endregion

        #region PutRecordBatch
        [Benchmark]
        public void PutRecordBatch()
        {
            string putRecordScript = File.ReadAllText(FileHelper.GetPowerShellScriptPath("FirehosePutRecordBatchBenchmarks.ps1"));
            var parameters = new Dictionary<string, object> {
                {"DeliveryStreamName", deliveryStreamName},
                {"RecordSizeInBytes", recordSize},
                {"NumberOfRecords", numberOfRecords}
            };
            InvokePowerShellScript(putRecordScript, parameters);
        }
        #endregion
    }
}
