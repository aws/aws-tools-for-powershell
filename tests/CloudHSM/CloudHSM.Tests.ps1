. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestIncludes.ps1")
Describe -Tag "Smoke" "CloudHSM" {
    Context "Available Zones" {

        It "Can list available zones" {
            $zones = Get-HSMAvailableZones
            if ($zones) {
                $zones.Count | Should BeGreaterThan 0
            }
        }

    }
}