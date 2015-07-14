function Test.CC.ListRepositories
{
    $repos = Get-CCRepositoryList -region us-east-1
    if ($repos)
    {
        Assert $repos.Count -ge 0
        if ($repos.Count -gt 0)
        {
		    Assert $awshistory.LastCommand.EmittedObjectsCount -eq $repos.Count
        }
    }    
}
