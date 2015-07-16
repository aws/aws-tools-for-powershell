function Test.ECS.ListClusters
{
    $clusters = Get-ECSClusters
    if ($clusters)
    {
        Assert $clusters.Count -ge 0
        if ($clusters.Count -gt 0)
        {
            Assert $clusters.Count -eq $awshistory.LastCommand.EmittedObjectsCount

            if ($clusters.Count -eq 1)
            {
                $cluster = Get-ECSClusterDetail -Cluster $clusters
            }
            else
            {
                $cluster = Get-ECSClusterDetail -Cluster $clusters[0]
            }

            Assert $cluster -IsNotNull
        }
    }    
}
