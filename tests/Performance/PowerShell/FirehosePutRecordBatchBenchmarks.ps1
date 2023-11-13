param([string]$DeliveryStreamName, [int]$RecordSizeInBytes, [int]$NumberOfRecords)

$data = 
foreach ($i in @(0..($NumberOfRecords - 1))) {
    # generate different characters starting from A
    $recordString = ([char]([byte][char]'A' + $i)).ToString() * $RecordSizeInBytes
    $recordBytes = [Text.Encoding]::UTF8.GetBytes($recordString)
    $record = [Amazon.KinesisFirehose.Model.Record]::new()
    $record.Data = $recordBytes
    $record
}
$result = Write-KINFRecordBatch -DeliveryStreamName $DeliveryStreamName -Record $data