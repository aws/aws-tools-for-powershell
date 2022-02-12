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

Describe -Tag "Smoke" "Cloud9" {

    Context "Cloud9" {
        It "Can list Cloud9 environments" {
            $environments = Get-C9EnvironmentList
            if ($environments) {
                $environments.Count | Should -BeGreaterThan 0
            }
        }
    }
}
