#
# Basic test to verify we can call CloudTrail
#
function Test.CT
{
	$Trails = Get-CTTrail	
	Assert $awshistory.LastServiceResponse -IsNotNull	
}
