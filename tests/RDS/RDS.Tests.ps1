Describe -Tag "Smoke" "RDS" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Engine versions" {

        It "Can get engines" {
            $engines = Get-RDSDBEngineVersion
            if ($engines) {
                $engines.Count | Should BeGreaterThan 0
            }
        }
    }
}
