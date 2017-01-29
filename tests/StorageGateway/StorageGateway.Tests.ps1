Describe -Tag "Smoke","Disabled" "StorageGateway" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Gateways" {

        $script:firstActiveGatway = $null

        It "Can list and read gateways" {
        	$gateways = Get-SGGateway
            if ($gateways) {
                $gateways.Count | Should BeGreaterThan 0

                # gateway has to be operational to query
                foreach ($g in $gateways) {
                    if ($g.GatewayOperationalState -eq "ACTIVE") {
                        $script:firstActiveGatway = $g
                        break
                    }
                }
            }
        }

        It "Can read an active gateway" {
            if ($script:firstActiveGatway) {
                $gateway = Get-SGGatewayInformation -GatewayARN $script:firstActiveGatway.GatewayARN
                $gateway | Should Not Be $null
                $gateway.GatewayId | Should Be $script:firstActiveGatway.GatewayId
            }
        }
    }
}
