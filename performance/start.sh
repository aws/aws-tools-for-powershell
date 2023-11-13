#!/bin/bash

# Arm workarounds
LD_LIBRARY_PATH=/home/ec2-user/libicu/lib
export LD_LIBRARY_PATH

cd /psperf-test/tests/Performance/
dotnet build ./PerformanceTests.csproj --configuration Release

dotnet run --project ./PerformanceTests.csproj --configuration Release

export DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
pwsh -File "/psperf-test/performance/storeOutput.ps1" /psperf-test/tests/Performance/BenchmarkDotNet.Artifacts/results/Performance.Benchmarks.CloudWatchBenchmarks-report.csv
pwsh -File "/psperf-test/performance/storeOutput.ps1" /psperf-test/tests/Performance/BenchmarkDotNet.Artifacts/results/Performance.Benchmarks.CloudWatchLogBenchmarks-report.csv
pwsh -File "/psperf-test/performance/storeOutput.ps1" /psperf-test/tests/Performance/BenchmarkDotNet.Artifacts/results/Performance.Benchmarks.EC2Benchmarks-report.csv
pwsh -File "/psperf-test/performance/storeOutput.ps1" /psperf-test/tests/Performance/BenchmarkDotNet.Artifacts/results/Performance.Benchmarks.FirehoseBenchmarks-report.csv
pwsh -File "/psperf-test/performance/storeOutput.ps1" /psperf-test/tests/Performance/BenchmarkDotNet.Artifacts/results/Performance.Benchmarks.S3Benchmarks-report.csv
pwsh -File "/psperf-test/performance/storeOutput.ps1" /psperf-test/tests/Performance/BenchmarkDotNet.Artifacts/results/Performance.Benchmarks.SSMBenchmarks-report.csv
pwsh -File "/psperf-test/performance/storeOutput.ps1" /psperf-test/tests/Performance/BenchmarkDotNet.Artifacts/results/Performance.Benchmarks.STSBenchmarks-report.csv
