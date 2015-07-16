function Test.CC.ListRepositories
{
    $repos = Get-CCRepositoryList
    if ($repos)
    {
        Assert $repos.Count -ge 0
        if ($repos.Count -gt 0)
        {
		    Assert $awshistory.LastCommand.EmittedObjectsCount -eq $repos.Count
        }
    }    
}
