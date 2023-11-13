param($DeliveryStreamName, $RecordSizeInBytes)
$data = 'A' * $RecordSizeInBytes
$result = Write-KINFRecord -DeliveryStreamName $DeliveryStreamName -Record_Data $data