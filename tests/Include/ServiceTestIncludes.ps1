. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
Set-AWSCredentials -AccessKey $testCreds.AccessKey -SecretKey $testCreds.SecretKey
