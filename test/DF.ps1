function Test.DF.ListProjects
{
    $projects = Get-DFProjectList -Region us-west-2

    if ($projects)
    {
        Assert $projects.Count -ge 0
        if ($projects.Count -gt 0)
        {
		    Assert $awshistory.LastCommand.EmittedObjectsCount -eq $projects.Count
        }
    }
}

