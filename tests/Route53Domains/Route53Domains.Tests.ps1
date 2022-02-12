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

Describe -Tag "Smoke" "Route53Domains" {

    Context "Domains" {

        It "Can check domain availability" {
            $response = Get-R53DDomainAvailability -DomainName "amazon.com"
            $response | Should -Not -Be $null
            $response.Value | Should -Be "UNAVAILABLE"
        }
    }
}
