# tests that can access the public ip address ranges file (that's not
# under our control) and do rudimentary filtering
function Test.PublicIpAddressRanges
{
	$allRanges = Get-AWSPublicIpAddressRange
	Assert $allRanges.Length -gt 0

	$serviceRanges = Get-AWSPublicIpAddressRange -ServiceKey ec2
	Assert $serviceRanges.Length -gt 0

	$regionRanges = Get-AWSPublicIpAddressRange -Region us-west-1
	Assert $regionRanges.Length -gt 0

	$keys = Get-AWSPublicIpAddressRange -OutputServiceKeys
	Assert $keys.Length -gt 0
}
