BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    $helper = New-Object ServiceTestHelper
    $helper.BeforeAll()
}

AfterAll {
    $helper.AfterAll()
}

Describe -Tag "Smoke" "Route53" {

    Context "Hosted Zones" {

        It "Can list and enumerate hosted zones" {
            $zones = Get-R53HostedZones
            if ($zones) {
                $zones.Count | Should -BeGreaterThan 0

                foreach ($z in $zones) {
                    $zone = Get-R53HostedZone -Id $z.Id
                    $zone | Should -Not -Be $null
                    $zone.HostedZone | Should -Not -Be $null
                }
            }
        }
    }
}
