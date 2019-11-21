# Route53
Set-Alias -Name Get-R53CheckerIpRanges -Value Get-R53CheckerIpRange
Set-Alias -Name Get-R53GeoLocations -Value Get-R53GeoLocationList
Set-Alias -Name Get-R53HealthChecks -Value Get-R53HealthCheckList
Set-Alias -Name Get-R53HostedZones -Value Get-R53HostedZoneList
Set-Alias -Name Get-R53ReusableDelegationSets -Value Get-R53ReusableDelegationSetList
Set-Alias -Name Get-R53TagsForResources -Value Get-R53TagsForResourceList
Set-Alias -Name Get-R53TrafficPolicies -Value Get-R53TrafficPolicyList
Set-Alias -Name Get-R53TrafficPolicyInstances -Value Get-R53TrafficPolicyInstanceList
Set-Alias -Name Get-R53TrafficPolicyVersions -Value Get-R53TrafficPolicyVersionList

Export-ModuleMember -Alias *