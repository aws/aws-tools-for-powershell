. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestIncludes.ps1")
Describe -Tag "Smoke" "CloudWatch" {
    Context "Metrics" {

        It "Can list metrics" {
            $metrics = Get-CWMetrics
            if ($metrics) {
                $metrics.Count | Should BeGreaterThan 0
            }
        }

        It "Can get metric by name" {
            $metrics = Get-CWMetrics
            if ($metrics) {
                $targetMetric = $metrics[0]

                $m = (Get-CWMetrics -MetricName $targetMetric.MetricName)[0]

                $m | Should Not Be $null

                $m.MetricName | Should Be $targetMetric.MetricName
                $m.Namespace | Should Be $targetMetric.Namespace
            }
        }
    }

    Context "Alarms" {

        It "Can list alarms" {
            $alarms = Get-CWAlarm
            if ($alarms) {
                $alarms.Count | Should BeGreaterThan 0
            }
        }

        It "Can get alarm by name" {
            $alarms = Get-CWAlarm
            if ($alarms) {
                $alarm = Get-CWAlarm -AlarmName $alarms[0].AlarmName

                $alarm | Should Not Be $null
                $alarm.AlarmName | Should Be $alarms[0].AlarmName
                $alarm.AlarmArn | Should Be $alarms[0].AlarmArn
            }
        }
    }

    Context "Manual Iteration" {

        BeforeEach {
            $allAlarms = Get-CWAlarm
        }

        # test using service api names for tokenization
        It "Can manually iterate with service token names, max 2 per call" {
            [int]$numPerPage = 2
            $manualIter1 = (Get-CWAlarm -MaxRecords $numPerPage | Measure-Object).Count
            while ($awshistory.LastServiceResponse.NextToken -ne $null)
            {
                $manualIter1 += (Get-CWAlarm -MaxRecords $numPerPage -NextToken $awshistory.LastServiceResponse.NextToken | Measure-Object).Count
            }

            $manualIter1 | Should Be $allAlarms.Count
        }

        It "Can manually iterate with token aliases, max 2 per call" {
            [int]$numPerPage = 2
            $manualIter2 = (Get-CWAlarm -MaxItems $numPerPage | Measure-Object).Count
            while ($awshistory.LastServiceResponse.NextToken -ne $null)
            {
                $manualIter2 += (Get-CWAlarm -MaxItems $numPerPage -NextToken $awshistory.LastServiceResponse.NextToken | Measure-Object).Count
            }

            $manualIter2 | Should Be $allAlarms.Count
        }
    }
}
