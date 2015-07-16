function Test.EFS.DescribeFileSystems
{
    $fs = Get-EFSFileSystem -region us-west-2
    if ($fs)
    {
        Assert $fs.Count -ge 0
        if ($fs.Count -gt 0)
        {
            Assert $fs.Count -eq $awshistory.LastCommand.EmittedObjectsCount
        }
    }
}
