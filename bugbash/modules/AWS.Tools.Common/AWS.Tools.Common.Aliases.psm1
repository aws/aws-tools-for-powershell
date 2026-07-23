# Shell Configuration
Set-Alias -Name Clear-AWSCredentials -Value Clear-AWSCredential
Set-Alias -Name Clear-AWSDefaults -Value Clear-AWSDefaultConfiguration
Set-Alias -Name Get-AWSCredentials -Value Get-AWSCredential
Set-Alias -Name Initialize-AWSDefaults -Value Initialize-AWSDefaultConfiguration
Set-Alias -Name New-AWSCredentials -Value New-AWSCredential
Set-Alias -Name Set-AWSCredentials -Value Set-AWSCredential

Export-ModuleMember -Alias *