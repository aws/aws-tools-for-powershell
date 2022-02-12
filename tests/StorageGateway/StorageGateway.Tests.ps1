BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    $helper = New-Object ServiceTestHelper
    $helper.BeforeAll()
    
    $script:firstActiveGatway = $null
}

AfterAll {
    $helper.AfterAll()
}

Describe -Tag "Smoke","Disabled" "StorageGateway" {

    Context "Gateways" {

        It "Can list and read gateways" {
        	$gateways = Get-SGGateway
            if ($gateways) {
                $gateways.Count | Should -BeGreaterThan 0

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
                $gateway | Should -Not -Be $null
                $gateway.GatewayId | Should -Be $script:firstActiveGatway.GatewayId
            }
        }
    }
}
