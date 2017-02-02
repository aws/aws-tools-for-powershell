Import-Module ..\Deployment\AWSPowershell\AWSPowerShell.psd1 -WarningAction Stop

# get some good credentials from somewhere, in order to run the tests
try
{
    #try to handle as dev machine
    $profileCreds =  Get-AWSCredentials default
    Write-Output "Setting test credentials from local profile 'default'"
    $testCreds = $profileCreds.GetCredentials()
}
catch
{
    #try to handle as build machine
    Write-Output "Setting test credentials from environment variables"

    $testCreds = New-Object PSObject
    $testCreds | Add-Member -NotePropertyName AccessKey -NotePropertyValue (Get-Item env:AWS_ACCESS_KEY_ID).Value
    $testCreds | Add-Member -NotePropertyName SecretKey -NotePropertyValue (Get-Item env:AWS_SECRET_ACCESS_KEY).Value
}
# $testCreds is now set and accessible from any script that includes this file

Set-DefaultAWSRegion -Region us-east-1
