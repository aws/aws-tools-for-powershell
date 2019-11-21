# RDSDataService
Set-Alias -Name Begin-RDSDTransaction -Value Start-RDSDTransaction
Set-Alias -Name Commit-RDSDTransaction -Value Confirm-RDSDTransaction
Set-Alias -Name Rollback-RDSDTransaction -Value Reset-RDSDTransaction

Export-ModuleMember -Alias *