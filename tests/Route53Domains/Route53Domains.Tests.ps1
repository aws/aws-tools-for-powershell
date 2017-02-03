. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "Route53Domains" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

    Context "Domains" {

        It "Can check domain availability" {
            $response = Get-R53DDomainAvailability -DomainName "amazon.com"
            $response | Should Not Be $null
            $response.Value | Should Be "UNAVAILABLE"
        }
    }
}
