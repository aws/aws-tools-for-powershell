Import-Module ..\Deployment\AWSPowerShell.psd1 -WarningAction Stop
$PSUnitPath = Resolve-Path ..\thirdparty\PSUnit

. ..\thirdparty\PSUnit\Profiles\profile.ps1
. ..\thirdparty\PSUnit\PSUnit.Report.ps1
. ..\thirdparty\PSUnit\PSUnit.Assert.ps1
. ..\thirdparty\PSUnit\PSUnit.Assert.Advanced.ps1

Set-AWSCredentials default
Set-DefaultAWSRegion -Region us-east-1

$testCreds = (Get-AWSCredentials default).GetCredentials()

$original_creds_file = '..\test\test-credentials'
$creds_file = '..\test\temp\test-credentials-correct'
(Get-Content $original_creds_file) | Foreach-Object {
    $_ -replace 'ACCESS_KEY_1', $testCreds.AccessKey `
       -replace 'SECRET_KEY_1', $testCreds.SecretKey
} | Set-Content $creds_file

$resultsPath = (Resolve-Path Results)
$result = ..\thirdparty\PSUnit\PSUnit.Run.ps1 -PSUnitTestFile Tests.ps1 -ResultDirectory $resultsPath

Write-Host "Result is $result"
if ($result -isnot [int])
{
	Write-Host "Tests failed because result isn't an int"
	$result = 1
}
exit $result