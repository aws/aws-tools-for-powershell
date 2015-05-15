function Init.SQS
{
	$random = New-Object System.Random
	$queueName = "ps-test-" + $random.Next()
	$nq = New-SQSQueue -QueueName $queueName
	$context.QueueUrl = $nq
}
function Test.SQS
{
	$queues = Get-SQSQueue
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($queues -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
	}
	
	$qu = $context.QueueUrl
	Send-SQSMessage -QueueUrl $qu -MessageBody "testing testing 1 2 3"
	
	$messages = Receive-SQSMessage -QueueUrl $qu
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($messages -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0

		if ($awshistory.LastCommand.EmittedObjectsCount -gt 1)
		{
			$body = $messages[0].Body
		}
		else
		{
			$body = $messages.Body
		}
		
		Assert $body -IsNotNull
		Assert $body.Length -Gt 5
	}
}
function Term.SQS
{
	$queues = Get-SQSQueue
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($queues -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
	}
	$garbage = Remove-SQSQueue -QueueUrl $context.QueueUrl -Force
}