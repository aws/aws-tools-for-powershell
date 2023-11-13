Param($PerformanceTestTagValue)
$allTags = Get-EC2Tag
$instanceId = $allTags.Where{ $_.ResourceType -eq 'instance' -and $_.'Value' -eq $PerformanceTestTagValue }.ResourceId | Select-Object -Unique
Remove-EC2Instance -InstanceId $instanceId -Force