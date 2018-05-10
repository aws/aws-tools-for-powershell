. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "Transcribe" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

    Context "Transcribe" {
    
        It "Can list transcribe jobs" {
            $jobs = Get-TRSTranscriptionJobList
            if ($jobs) {
                $jobs.Count | Should BeGreaterThan 0
            }
        }
    }
}
