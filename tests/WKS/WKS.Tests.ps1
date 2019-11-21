. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "WKS" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

    Context "Workspaces" {

        It "Can list workspaces" {
            $workspaces = Get-WKSWorkspaces
            if ($workspaces) {
                $workspaces.Count | Should BeGreaterThan 0
            }
        }
    }
}