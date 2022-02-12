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

Describe -Tag "Smoke" "CloudWatchLogs" {

    Context "Log Groups" {

        It "Can list log groups" {
            $logGroups = Get-CWLLogGroups
            if ($logGroups) {
                $logGroups.Count | Should -BeGreaterThan 0
            }
        }
    }
}
