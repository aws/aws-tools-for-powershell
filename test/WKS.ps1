function Test.WKS
{
    # we currently have no workspaces, but the cmdlet should at least roundtrip
    # without error
    $workspaces = Get-WKSWorkspaces
    if ($workspaces)
    {
        Assert $workspaces.Count -eq $awshistory.LastCommand.EmittedObjectsCount
    }
}
