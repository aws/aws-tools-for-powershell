function Test.RDS.DescribeDBEngineVersions
{
    $engines = Get-RDSDBEngineVersion
    if ($engines)
    {
        Assert $engines.Count -ge 0
        Assert $engines.Count -eq $awshistory.LastCommand.EmittedObjectsCount
    }
}
