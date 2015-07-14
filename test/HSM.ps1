function Test.HSM.ListAvailableZones
{
    $zones = Get-HSMAvailableZones
    if ($zones)
    {
        Assert $zones.Count -ge 0    
        if ($zones.Count -gt 0)
        {
		    Assert $awshistory.LastCommand.EmittedObjectsCount -eq $zones.Count
        }
    }
}
