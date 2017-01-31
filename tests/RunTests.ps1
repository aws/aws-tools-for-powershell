Import-Module ..\Deployment\AWSPowershell\AWSPowerShell.psd1 -WarningAction Stop

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

Invoke-Pester -EnableExit -OutputFile results\PesterResults.xml -OutputFormat NUnitXML -ExcludeTag Disabled
exit $LASTEXITCODE
