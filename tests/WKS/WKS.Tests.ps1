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

Describe -Tag "Smoke" "WKS" {

    Context "Workspaces" {

        It "Can list workspaces" {
            $workspaces = Get-WKSWorkspaces
            if ($workspaces) {
                $workspaces.Count | Should -BeGreaterThan 0
            }
        }
    }
}