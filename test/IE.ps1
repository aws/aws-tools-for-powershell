function Test.IE.ListJobs
{
    $jobs = Get-IEJob
    if ($jobs)
    {
        Assert $jobs.Count -ge 0;
        Assert $jobs.Count -eq $awshistory.LastCommand.EmittedObjectsCount

        if ($jobs.Count -eq 1)
        {
            $jobStatus = Get-IEStatus -JobId $jobs.JobId
        }
        else
        {
            $jobStatus = Get-IEStatus -JobId $jobs[0].JobId
        }

        Assert $jobStatus -IsNotNull
    }
}
