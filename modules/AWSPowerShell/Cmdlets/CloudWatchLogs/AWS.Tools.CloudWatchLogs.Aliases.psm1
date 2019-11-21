# CloudWatchLogs
Set-Alias -Name Get-CWLExportTasks -Value Get-CWLExportTask
Set-Alias -Name Get-CWLLogEvents -Value Get-CWLLogEvent
Set-Alias -Name Get-CWLLogGroups -Value Get-CWLLogGroup
Set-Alias -Name Get-CWLLogStreams -Value Get-CWLLogStream
Set-Alias -Name Get-CWLMetricFilters -Value Get-CWLMetricFilter
Set-Alias -Name Get-CWLSubscriptionFilters -Value Get-CWLSubscriptionFilter
Set-Alias -Name Write-CWLLogEvents -Value Write-CWLLogEvent

Export-ModuleMember -Alias *