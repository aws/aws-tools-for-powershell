Param($MetricName, $NumberOfPutMetricDataRequests)
for ($i = 0; $i -lt $NumberOfPutMetricDataRequests; $i++) {
    $Metric = New-Object -TypeName Amazon.CloudWatch.Model.MetricDatum
    $Metric.Timestamp = [DateTime]::UtcNow
    $Metric.MetricName = $MetricName
    $Metric.Value = $i
    Write-CWMetricData -Namespace PutMetricData -MetricData $Metric
}