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

Describe -Tag "Smoke" "ImportExport" {

    Context "Jobs" {

        It "Can list jobs and get job status" {
            # Get-IEJob can't be used here because it requires permanent credentials
            if ($helper.Token -ne $null) {
                return
            }
            $jobs = Get-IEJob
            if ($jobs) {
                $jobs.Count | Should -BeGreaterThan 0

                $status = Get-IEStatus -JobId $jobs[0].JobId
                $status | Should -Not -Be $null

                $status.JobId | Should -Be $jobs[0].JobId
            }
        }
    }
}