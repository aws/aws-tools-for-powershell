Param($NumberOfTags, $PerformanceTestTagValue, $AMISSMParameter)
# generate tags in the format @{"key"="tag1";"value"="value1"},@{"key"="tag2";"value"="value2"}
      
$tags = @(1..$NumberOfTags) | ForEach-Object { @{'key' = "tag$_"; 'value' = $PerformanceTestTagValue } }
$tagSpecification = [Amazon.EC2.Model.TagSpecification]::new()
$tagSpecification.ResourceType = 'Instance'
$tagSpecification.Tags = $Tags
$imageId = (Get-SSMParameter $AMISSMParameter).Value
New-EC2Instance -ImageId $imageId -TagSpecification $tagSpecification -InstanceType "m6i.large"