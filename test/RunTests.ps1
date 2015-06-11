Import-Module ..\Deployment\AWSPowerShell.psd1 -WarningAction Stop
$PSUnitPath = Resolve-Path ..\thirdparty\PSUnit

. ..\thirdparty\PSUnit\Profiles\profile.ps1
. ..\thirdparty\PSUnit\PSUnit.Report.ps1
. ..\thirdparty\PSUnit\PSUnit.Assert.ps1
. ..\thirdparty\PSUnit\PSUnit.Assert.Advanced.ps1

# build server uses environment variables, dev machines use profiles - try
# and handle both scenarios
try
{
    $profileCreds =  Get-AWSCredentials default
    Write-Output "Setting test credentials from local profile 'default'"
    
    $testCreds = $profileCreds.GetCredentials()
}
catch
{
    Write-Output "Setting test credentials from environment variables"
    
    $testCreds = New-Object PSObject
    $testCreds | Add-Member -NotePropertyName AccessKey -NotePropertyValue (Get-Item env:AWS_ACCESS_KEY_ID).Value
    $testCreds | Add-Member -NotePropertyName SecretKey -NotePropertyValue (Get-Item env:AWS_SECRET_ACCESS_KEY).Value
}

Set-AWSCredentials -AccessKey $testCreds.AccessKey -SecretKey $testCreds.SecretKey
Set-DefaultAWSRegion -Region us-east-1

New-Item -Path ..\test\temp -ItemType directory

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