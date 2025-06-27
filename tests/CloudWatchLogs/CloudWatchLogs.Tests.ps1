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
    Context "Get-CWLLogEvents" {
        BeforeAll {
            $logGroupName = (New-Guid).Guid
            $null = New-CWLLogGroup -LogGroupName $logGroupName
            $logStreamName = (New-Guid).Guid
            $null = New-CWLLogStream -LogGroupName $logGroupName -LogStreamName $logStreamName
            $cwlEvents = 
            foreach ($i in 3..1) {
                $cwlEvent = [Amazon.CloudWatchLogs.Model.InputLogEvent]::new()
                $cwlEvent.Message = $i
                $cwlEvent.Timestamp = (Get-Date).ToUniversalTime().AddSeconds(-$i)
                $cwlEvent
            }
            $null = Write-CWLLogEvent -LogGroupName $logGroupName -LogStreamName $logStreamName -LogEvent $cwlEvents
        }
        AfterAll {
            Remove-CWLLogGroup -LogGroupName $logGroupName -Force
        }
        It "-NoAutoIteration stops Auto-Iteration" {
            (Get-CWLLogEvents -LogGroupName $logGroupName -LogStreamName $logStreamName -NoAutoIteration -Limit 1).Events.Count | Should -Be 1
        }
    }
}
