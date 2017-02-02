. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestIncludes.ps1")
Describe -Tag "Smoke" "DirectConnect" {
    Context "Virtual gateways" {
        It "Can list gateways" {
            $gateways = Get-DCVirtualGateway
            if ($gateways) {
                $gateways.Count | Should BeGreaterThan 0

                $gateway1 = $gateways[0]
                $gateway1.VirtualGatewayId | Should Not BeNullOrEmpty
            }
        }
    }

    Context "Connections" {
        It "Can list connections" {
        	$connections = Get-DCConnection
            if ($connections) {
                $connections.Count | Should BeGreaterThan 0

                $connection1 = $connections[0]
                $connection1.ConnectionId | Should Not BeNullOrEmpty
            }
        }
    }
}
