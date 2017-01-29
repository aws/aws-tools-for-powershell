Import-Module ..\Deployment\AWSPowershell\AWSPowerShell.psd1 -WarningAction Stop
Invoke-Pester -EnableExit -OutputFile results\PesterResults.xml -OutputFormat NUnitXML -ExcludeTag Disabled
exit $LASTEXITCODE
