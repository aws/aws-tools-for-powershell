if (Get-Module -ListAvailable -Name AWS.Tools.CloudWatch) {
    Import-Module AWS.Tools.CloudWatch
} 
else {
    Install-Module AWS.Tools.CloudWatch -Force -AllowClobber
    Import-Module AWS.Tools.CloudWatch
}

Function SaveToCloudWatch
{
    [CmdletBinding()]
    Param
    (
        # The root folder containing the core runtime or a service
        [Parameter(Mandatory=$true)]
        [string]
        $ResultsCSV
    )

    Process
    {
        $results = Import-CSV $ResultsCSV

        ForEach ($result in $results) {
            $method= $($result.Method)
            $platform= $($result.Platform)
            $runtime= $($result.Runtime)
            $meanWithUnits= $($result.Mean)

            Write-Host $method took $meanWithUnits mean on $platform on $runtime

            $units = $meanWithUnits.substring($meanWithUnits.length-2)
            $rawMean =  [int]$meanWithUnits.substring(0,$meanWithUnits.length-3)
            
            $Metric = New-Object -TypeName Amazon.CloudWatch.Model.MetricDatum

            if ($units -eq "ns") {
                $Metric.Value = $rawMean / 1000
                $Metric.Unit = "Microseconds"
            } 
            elseif ($units -eq "us") {
                $Metric.Value = $rawMean
                $Metric.Unit = "Microseconds"
            }
           elseif ($units -eq "ms") {
                $Metric.Value = $rawMean
                $Metric.Unit = "Milliseconds"
            }
            else { # assume seconds
                $Metric.Value = $rawMean
                $Metric.Unit = "Seconds"
            }
            
            $Metric.Timestamp = [DateTime]::UtcNow
            $Metric.MetricName = $method            

            $platformDimension = [Amazon.CloudWatch.Model.Dimension]::new()
            $platformDimension.Name = 'Platform'
            $platformDimension.Value = $platform

            $runtimeDimension = [Amazon.CloudWatch.Model.Dimension]::new()
            $runtimeDimension.Name = 'Runtime'
            $runtimeDimension.Value = $runtime


            $Metric.Dimensions=$platformDimension,$runtimeDimension

            Write-Host About to push $Metric.Value $Metric.Unit for $Metric.MetricName
            Write-CWMetricData -Namespace "AWS-PS-PerformanceBenchmarks" -MetricData $Metric
        }

    }
}


SaveToCloudWatch $args[0]