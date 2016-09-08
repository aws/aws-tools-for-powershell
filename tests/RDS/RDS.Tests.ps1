Describe -Tag "Smoke" "RDS" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Engines" {

        It "Can get engines" {
            $engines = Get-RDSDBEngineVersion
            if ($engines) {
                $engines.Count | Should BeGreaterThan 0
            }
        }
    }
}
