using BenchmarkDotNet.Attributes;
using Performance.Helpers;


namespace Performance.Benchmarks
{
    public class S3Benchmarks : BenchmarkBase
    {
        private string CurrentS3Bucket;

        private string[] _modulesToImport = { "AWS.Tools.Common", "AWS.Tools.S3" };
        public override string[] ModulesToImport { get { return _modulesToImport; } }

        private readonly string smallFile = Path.GetFullPath($"small-{Guid.NewGuid().ToString()}.txt");
        private readonly string largeFile = Path.GetFullPath($"large-{Guid.NewGuid().ToString()}.txt");

        private void CreateS3Bucket(string bucketName)
        {
            string newBucketScript = $"New-S3Bucket -BucketName '{bucketName}'";
            InvokePowerShellScript(newBucketScript);
        }

        private void RemoveS3Bucket(string bucketName)
        {
            string removeS3BucketScript = $"Remove-S3Bucket -BucketName '{bucketName}' -Force -DeleteBucketContent";
            InvokePowerShellScript(removeS3BucketScript);
        }

        #region ListBuckets

        [GlobalSetup(Target = nameof(ListBuckets))]
        public void GlobalSetupForListBucket()
        {
            CurrentS3Bucket = CurrentS3Bucket = "perftests" + DateTime.Now.Ticks;
            CreateS3Bucket(CurrentS3Bucket);
        }

        [GlobalCleanup(Target = nameof(ListBuckets))]
        public void GlobalCleanUpForListBucket()
        {
            RemoveS3Bucket(CurrentS3Bucket);
        }

        [Benchmark]
        public void ListBuckets()
        {
            string listBucketsScript = "Get-S3Bucket";
            var results = InvokePowerShellScript(listBucketsScript);
        }

        #endregion

        #region PutObjectSmall

        [GlobalSetup(Target = nameof(PutObjectSmall))]
        public void GlobalSetUpForPutObjectSmall()
        {
            // Generate 100 KB file
            FileHelper.GenerateFile(smallFile, sizeInBytes: Constants.KB * 100);
            CurrentS3Bucket = CurrentS3Bucket = "perftests" + DateTime.Now.Ticks;
            CreateS3Bucket(CurrentS3Bucket);
        }

        [GlobalCleanup(Target = nameof(PutObjectSmall))]
        public void GlobalCleanUpForPutObjectSmall()
        {
            if (File.Exists(smallFile))
            {
                File.Delete(smallFile);
            }
            RemoveS3Bucket(CurrentS3Bucket);
        }

        [Benchmark]
        public void PutObjectSmall()
        {
            string randomKey = Guid.NewGuid().ToString();
            string putObjectSmallScript = $"Write-S3Object -BucketName '{CurrentS3Bucket}' -Key {randomKey} -File {smallFile}";
            var results = InvokePowerShellScript(putObjectSmallScript);
        }
        #endregion


        #region PutObjectLarge

        [GlobalSetup(Target = nameof(PutObjectLarge))]
        public void GlobalSetUpForPutObjectLarge()
        {
            // Generate 100 MB file
            FileHelper.GenerateFile(largeFile, sizeInBytes: Constants.MB * 100);
            CurrentS3Bucket = CurrentS3Bucket = "perftests" + DateTime.Now.Ticks;
            CreateS3Bucket(CurrentS3Bucket);
        }

        [GlobalCleanup(Target = nameof(PutObjectLarge))]
        public void GlobalCleanUpForPutObjectLarge()
        {
            if (File.Exists(largeFile))
            {
                File.Delete(largeFile);
            }
            RemoveS3Bucket(CurrentS3Bucket);
        }

        [Benchmark]
        public void PutObjectLarge()
        {
            string randomKey = Guid.NewGuid().ToString();
            string putObjectLargeScript = $"Write-S3Object -BucketName '{CurrentS3Bucket}' -Key {randomKey} -File {largeFile}";
            var results = InvokePowerShellScript(putObjectLargeScript);
        }
        #endregion

    }
}