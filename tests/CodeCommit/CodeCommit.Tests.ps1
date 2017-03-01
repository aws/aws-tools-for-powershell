. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "CodeCommit" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

    Context "Repositories" {

        It "Can list repositories" {
            # if we have no real repos, we get null response
            $repos = Get-CCRepositoryList
            if ($repos) {
                $repos.Length | Should BeGreaterThan 0
            }
        }
    }
}
