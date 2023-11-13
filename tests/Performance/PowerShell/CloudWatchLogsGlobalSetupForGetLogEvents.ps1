param($LogGroupName, $LogStreamName, $MessageNumberOfCharacters, $NumberOfLogEvents)
New-CWLLogGroup -LogGroupName $LogGroupName
New-CWLLogStream -LogGroupName $LogGroupName -LogStreamName $LogStreamName

for ($i = 0; $i -lt $NumberOfLogEvents; $i++) {
    $cwlLogEvent = New-Object -TypeName Amazon.CloudWatchLogs.Model.InputLogEvent -Property @{ 
        Message   = 'a' * ($MessageNumberOfCharacters - 1) + $i
        TimeStamp = [datetime]::UtcNow
    }
    Write-CWLLogEvent -LogGroupName $LogGroupName -LogStreamName $LogStreamName -LogEvent $cwlLogEvent
}