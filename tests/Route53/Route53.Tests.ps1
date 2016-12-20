Describe -Tag "Smoke" "Route53" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Hosted Zones" {

        It "Can list and enumerate hosted zones" {
            $zones = Get-R53HostedZones
            if ($zones) {
                $zones.Count | Should BeGreaterThan 0

                foreach ($z in $zones) {
                    $zone = Get-R53HostedZone -Id $z.Id
                    $zone | Should Not Be $null
                    $zone.HostedZone | Should Not Be $null
                    $zone.DelegationSet | Should Not Be $null
                }
            }
        }
    }
}
