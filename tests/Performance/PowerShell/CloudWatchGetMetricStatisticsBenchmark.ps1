param( $MetricNamespace, $MetricName, $MetricDataQueryId, $StartDateUTC, $EndDateUTC, $Period = 1, $Stat = 'Maximum')

$metric = New-Object -TypeName Amazon.CloudWatch.Model.Metric
$metric.MetricName = $MetricName
$metricStat = New-Object -TypeName Amazon.CloudWatch.Model.MetricStat
$metric.Namespace = $MetricNamespace
$metricStat.Metric = $metric
$metricStat.Stat = $Stat
$metricStat.Period = $Period
$metricDataQuery = [Amazon.CloudWatch.Model.MetricDataQuery]::new()
$metricDataQuery.MetricStat = $metricStat
$metricDataQuery.Id = $MetricDataQueryId

$mdata = Get-CWMetricData -MetricDataQuery $metricDataQuery -UtcStartTime $StartDateUTC -UtcEndTime $EndDateUTC
