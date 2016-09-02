Describe -Tag "Smoke" "EC2ContainerService" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Clusters" {

        It "Can list and read clusters" {
            $clusters = Get-ECSClusters
            if ($clusters) {
                $clusters.Count | Should BeGreaterThan 0

                $cluster = Get-ECSClusterDetail -Cluster $clusters[0]
                $cluster | Should Not Be $null
            }
        }
    }
}
