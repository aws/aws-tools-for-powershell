using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using Performance.Benchmarks;

// Adding ConfigOptions.DisableOptimizationsValidator to address this error "Assembly PerformanceTests which defines benchmarks references non-optimized System.Management.Automation"
//  Microsoft.PowerShell.SDK version 7.2.16 on Linux has this issue but not on Windows. 7.3 version that is targeted for .NET 7 doesn't have this issue.
var benchmarkDotNetDefaultConfig = DefaultConfig.Instance
                      .AddJob(Job
                        .MediumRun
                        .WithLaunchCount(1)
                        .WithMinIterationCount(3)
                        .WithMaxIterationCount(5)
                        .WithWarmupCount(5)
                        .WithIterationCount(5)
                      ).WithOptions(ConfigOptions.DisableOptimizationsValidator);

BenchmarkRunner.Run<CloudWatchBenchmarks>(benchmarkDotNetDefaultConfig);
BenchmarkRunner.Run<CloudWatchLogBenchmarks>(benchmarkDotNetDefaultConfig);
BenchmarkRunner.Run<EC2Benchmarks>(benchmarkDotNetDefaultConfig);
BenchmarkRunner.Run<FirehoseBenchmarks>(benchmarkDotNetDefaultConfig);
BenchmarkRunner.Run<S3Benchmarks>(benchmarkDotNetDefaultConfig);
BenchmarkRunner.Run<SSMBenchmarks>(benchmarkDotNetDefaultConfig);
BenchmarkRunner.Run<STSBenchmarks>(benchmarkDotNetDefaultConfig);
