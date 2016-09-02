Describe -Tag "Smoke" "StorageGateway" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Gateways" {

        BeforeAll {
            $firstActiveGatway = $null
        }

        It "Can list and read gateways" {
        	$gateways = Get-SGGateway
            if ($gateways) {
                $gateways.Count | Should BeGreaterThan 0

                # gateway has to be operational to query
                foreach ($g in $gateways) {
                    if ($g.GatewayOperationalState -eq "ACTIVE") {
                        $firstActiveGatway = $g
                        break
                    }
                }
            }
        }

        It "Can read an active gateway" {
            if ($firstActiveGatway) {
                $gateway = Get-SGGatewayInformation -GatewayARN $firstActiveGatway.GatewayARN
                $gateway | Should Not Be $null
                $gateway.GatewayId | Should Be $firstActiveGatway.GatewayId
            }
        }
    }
}
