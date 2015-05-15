function Init.SNS
{
	$random = New-Object System.Random
	$context.TopicName = "snsPsTopic" + $random.Next()
}
function Test.SNS
{
	$originalTopics = 0

	$topics = Get-SNSTopic
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($topics -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
		$originalTopics = $awshistory.LastCommand.EmittedObjectsCount
	}

	$topicArn = New-SNSTopic -Name $context.TopicName
	Assert $topicArn -IsNotNull
	Get-SNSTopic
	Assert $awshistory.LastCommand.EmittedObjectsCount -Ne $originalTopics
	
	Set-SNSTopicAttribute -TopicArn $topicArn -AttributeName DisplayName -AttributeValue SNS_IntegTest_PS
	$attributes = Get-SNSTopicAttribute -TopicArn $topicArn
    $displayName = $attributes["DisplayName"]
	Assert $displayName -IsNotNull
	
	Remove-SNSTopic -TopicArn $topicArn -Force
	Get-SNSTopic
	Assert $awshistory.LastCommand.EmittedObjectsCount -Eq $originalTopics
}
