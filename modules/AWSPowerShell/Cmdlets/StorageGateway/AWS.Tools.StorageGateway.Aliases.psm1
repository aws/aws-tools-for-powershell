# StorageGateway
Set-Alias -Name Get-SGChapCredentials -Value Get-SGChapCredential
Set-Alias -Name Get-SGResourceTags -Value Get-SGResourceTag
Set-Alias -Name Get-SGTapeArchives -Value Get-SGTapeArchiveList
Set-Alias -Name Get-SGTapeRecoveryPoints -Value Get-SGTapeRecoveryPointList
Set-Alias -Name Get-SGTapes -Value Get-SGTapeList
Set-Alias -Name Get-SGVolumeInitiators -Value Get-SGVolumeInitiatorList
Set-Alias -Name Get-SGVTLDevices -Value Get-SGVTLDevice
Set-Alias -Name New-SGTapes -Value New-SGTape
Set-Alias -Name Remove-SGChapCredentials -Value Remove-SGChapCredential
Set-Alias -Name Update-SGChapCredentials -Value Update-SGChapCredential

Export-ModuleMember -Alias *