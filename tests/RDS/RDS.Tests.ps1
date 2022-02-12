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


Describe -Tag "Smoke" "RDS" {

    Context "Engines" {

        It "Can get engines" {
            $engines = Get-RDSDBEngineVersion
            if ($engines) {
                $engines.Count | Should -BeGreaterThan 0
            }
        }
    }
}
