. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestIncludes.ps1")
Describe -Tag "Smoke" "ImportExport" {
    Context "Jobs" {

        It "Can list jobs and get job status" {
            $jobs = Get-IEJob
            if ($jobs) {
                $jobs.Count | Should BeGreaterThan 0

                $status = Get-IEStatus -JobId $jobs[0].JobId
                $status | Should Not Be $null

                $status.JobId | Should Be $jobs[0].JobId
            }
        }
    }
}