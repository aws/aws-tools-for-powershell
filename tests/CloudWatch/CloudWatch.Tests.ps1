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

Describe -Tag "Smoke" "CloudWatch" {

    Context "Metrics" {

        It "Can list metrics" {
            $metrics = Get-CWMetrics
            if ($metrics) {
                $metrics.Count | Should -BeGreaterThan 0
            }
        }

        It "Can get metric by name" {
            $metrics = Get-CWMetrics
            if ($metrics) {
                $targetMetric = $metrics[0]

                $m = (Get-CWMetrics -MetricName $targetMetric.MetricName -Namespace $targetMetric.Namespace)[0]

                $m | Should -Not -Be $null

                $m.MetricName | Should -Be $targetMetric.MetricName
                $m.Namespace | Should -Be $targetMetric.Namespace
            }
        }
    }

    Context "Alarms" {

        It "Can list alarms" {
            $alarms = Get-CWAlarm
            if ($alarms) {
                $alarms.Count | Should -BeGreaterThan 0
            }
        }

        It "Can get alarm by name" {
            $alarms = Get-CWAlarm
            if ($alarms) {
                $alarm = Get-CWAlarm -AlarmName $alarms[0].AlarmName

                $alarm | Should -Not -Be $null
                $alarm.AlarmName | Should -Be $alarms[0].AlarmName
                $alarm.AlarmArn | Should -Be $alarms[0].AlarmArn
            }
        }
    }

    Context "Manual Iteration" {

        BeforeEach {
            $allAlarms = Get-CWAlarm
        }

        # test using service api names for tokenization
        It "Can manually iterate with service token names, max 2 per call" {
            $numPerPage = 2

            $cwAlarms = do
            {
                $splatParams = @{
                    
                    MaxRecord = $numPerPage 
                    NextToken = $result.NextToken
                    Select = '*'
                }
                $result = Get-CWAlarm @splatParams
                
                $result.MetricAlarms
            }
            while ($null -ne $result.NextToken)

            $allAlarms.MetricAlarms.Count | Should -Be $cwAlarms.Count
        }

        It "Can manually iterate with token aliases, max 2 per call" {
            $numPerPage = 2

            $cwAlarms = do
            {
                $splatParams = @{
                    
                    MaxRecords = $numPerPage 
                    NextToken = $result.NextToken
                    Select = '*'
                    NoAutoIteration = $true
                }
                $result = Get-CWAlarm @splatParams
                
                $result.MetricAlarms
            }
            while ($null -ne $result.NextToken)

            $allAlarms.MetricAlarms.Count | Should -Be $cwAlarms.Count
        }
    }
}
