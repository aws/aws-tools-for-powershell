param($MetricName, $NumberOfMetricsForSetup)
for ($i = 0; $i -lt $NumberOfMetricsForSetup; $i++) {
    $Metric = New-Object -TypeName Amazon.CloudWatch.Model.MetricDatum
    $Metric.Timestamp = [DateTime]::UtcNow
    $Metric.MetricName = $MetricName
    $Metric.Value = $i
    Write-CWMetricData -Namespace instance1 -MetricData $Metric
}