Describe -Tag "Smoke" "RedShift" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Clusters" {

        It "Can get Orderable Cluster Options" {
            $options = Get-RSOrderableClusterOptions
            if ($options) {
                $options.Count | Should BeGreaterThan 0
            }
        }
    }
}
