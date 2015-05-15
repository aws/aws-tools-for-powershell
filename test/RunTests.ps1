Import-Module ..\Deployment\AWSPowerShell.psd1 -WarningAction Stop
$PSUnitPath = Resolve-Path ..\PSUnit

. ..\PSUnit\Profiles\profile.ps1
. ..\PSUnit\PSUnit.Report.ps1
. ..\PSUnit\PSUnit.Assert.ps1
. ..\PSUnit\PSUnit.Assert.Advanced.ps1

$AWSCommonPath = Resolve-Path ..\Include\sdk\dotnet35\TestUtilities.dll
[void]([System.Reflection.Assembly]::LoadFrom($AWSCommonPath))
$testCreds = [Amazon.Common.TestCredentials.TestCredentials]::DefaultCredentials
Set-AWSCredentials -AccessKey $testCreds.AccessKey -SecretKey $testCreds.SecretKey
Set-DefaultAWSRegion -Region us-east-1

$original_creds_file = '..\Tests\test-credentials'
$creds_file = '..\Tests\test-credentials-correct'
(Get-Content $original_creds_file) | Foreach-Object {
    $_ -replace 'ACCESS_KEY_1', $testCreds.AccessKey `
       -replace 'SECRET_KEY_1', $testCreds.SecretKey
} | Set-Content $creds_file

$resultsPath = (Resolve-Path Results)
$result = ..\PSUnit\PSUnit.Run.ps1 -PSUnitTestFile Tests.ps1 -ResultDirectory $resultsPath
del $creds_file

Write-Host "Result is $result"
if ($result -isnot [int])
{
	Write-Host "Tests failed because result isn't an int"
	$result = 1
}
exit $result