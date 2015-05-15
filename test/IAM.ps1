function Test.IAM.Roles
{
	$roles = Get-IAMRoles
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($roles -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
	}
	
	foreach ($role in $roles)
	{
		Assert -Actual $role -IsNotNull
		$fullRole = Get-IAMRole -RoleName $role.RoleName
		Assert $fullRole -IsNotNull
		Assert $awshistory.LastServiceResponse -IsNotNull
	}
}

function Test.IAM.InstanceProfiles
{
	$profiles = Get-IAMInstanceProfiles
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($profiles -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
	}
	
	foreach ($profile in $profiles)
	{
		Assert $profile -IsNotNull
		$fullProfile = Get-IAMInstanceProfile -InstanceProfileName $profile.InstanceProfileName
		Assert $fullProfile -IsNotNull
		Assert $awshistory.LastServiceResponse -IsNotNull
	}
}

function Test.IAM.AccountSummary
{
	$summaryMap = Get-IAMAccountSummary
	Assert $summaryMap -IsNotNull
	Assert $summaryMap.Users -Gt 0
	Assert $summaryMap.GroupsQuota -Gt 0
	Assert $summaryMap.RolesQuota -Gt 0
	Assert $summaryMap.GroupPolicySizeQuota -Gt 0
	Assert $summaryMap.ServerCertificates -Gt 0
	Assert $summaryMap.ServerCertificatesQuota -Gt 0
	Assert $summaryMap.Roles -Gt 0
	Assert $summaryMap.InstanceProfiles -Gt 0
}

# Tests that the request signs against us-east-1 even if a region is set.
# If the SDK support isn't working, we'll see a credential scoping error
function Test.IAM.NonUSEastRegion
{
	$summaryMap = Get-IAMAccountSummary -Region ap-southeast-2
	Assert $summaryMap -IsNotNull
}
