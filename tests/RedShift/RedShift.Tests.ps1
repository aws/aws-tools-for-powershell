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

Describe -Tag "Smoke" "RedShift" {

    Context "Clusters" {

        It "Can get Orderable Cluster Options" {
            $options = Get-RSOrderableClusterOptions
            if ($options) {
                $options.Count | Should -BeGreaterThan 0
            }
        }
    }
}
