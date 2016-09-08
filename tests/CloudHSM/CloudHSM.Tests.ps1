Describe -Tag "Smoke" "CloudHSM" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Available Zones" {

        It "Can list available zones" {
            $zones = Get-HSMAvailableZones
            if ($zones) {
                $zones.Count | Should BeGreaterThan 0
            }
        }

    }
}