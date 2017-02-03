. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

# Note that calling AWS Support requires an account with an AWS Premium Support
# subscription.
Describe -Tag "Smoke" "SupportService" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

    Context "Services" {

        It "Can retrieve services" {
            $services = Get-ASAServices
            $services | Should Not Be $null
            $services.Length | Should BeGreaterThan 0
        }
    }
}
