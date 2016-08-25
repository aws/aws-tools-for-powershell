Describe -Tag "Smoke" "CloudWatch Tests" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Can list and get metrics" {

        It "Can list metrics" {
            $metrics = Get-CWMetrics
            if ($metrics) {
                $metrics.Count | Should BeGreaterThan 0
            }
        }

        It "Can get metric by name" {
            $metrics = Get-CWMetrics
            if ($metrics) {
                $m = Get-CWMetrics -MetricName $metrics[0].MetricName

                $m | Should Not Be $null
                $m.MetricName | Should Be $metrics[0].MetricName
                $m.Namespace | Should Be $metrics[0].Namespace
            }
        }
    }

    Context "Can list and get alarms" {

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

    Context "Can manually iterate alarms collection" {

        BeforeEach {
            $allAlarms = Get-CWAlarm
        }

        # test using service api names for tokenization
        It "Can manually iterate with service token names" {
            [int]$numPerPage = $allAlarms.Count / 4
	        $numPerPage = [System.Math]::Min($numPerPage, 100)

            $manualIter1 = (Get-CWAlarm -MaxRecords $numPerPage | Measure).Count
            while ($awshistory.LastServiceResponse.NextToken -ne $null)
            {
                $manualIter1 += (Get-CWAlarm -MaxRecords $numPerPage -NextToken $awshistory.LastServiceResponse.NextToken | Measure).Count
            }
    
            $manualIter1 | Should Be $allAlarms.Count
        }

        It "Can manually iterate with token aliases" {
            [int]$numPerPage = $allAlarms.Count / 8
	        $numPerPage = [System.Math]::Min($numPerPage, 50)

            $manualIter2 = (Get-CWAlarm -MaxItems $numPerPage | Measure).Count
            while ($awshistory.LastServiceResponse.NextToken -ne $null)
            {
                $manualIter2 += (Get-CWAlarm -MaxItems $numPerPage -NextToken $awshistory.LastServiceResponse.NextToken | Measure).Count
            }
    
            $manualIter2 | Should Be $allAlarms.Count
        }
    }
}
