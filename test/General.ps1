function Test.DefaultRegion
{	
	$region = Get-DefaultAWSRegion
	Clear-DefaultAWSRegion

	Get-IAMRoles
	
	try
	{
		Get-SNSTopics
		$thrown = $false
	}
	catch
	{
		$thrown = $true
	}
	
	if (-not $thrown)
	{
		throw "Exception should have been thrown"
	}

	Set-DefaultAWSRegion -Region $region.Region
}

function Test.ModuleListing
{
	Get-Command -Module AWSPowerShell -ErrorAction Stop
}

function Test.CredentialsFile
{
	try
	{
		Get-S3Bucket -ProfilesLocation $creds_file
		$thrown = $false
	}
	catch
	{
		$thrown = $true
	}

	if (-not $thrown)
	{
		throw "Exception should have been thrown due to invalid keys"
	}

	$buckets = Get-S3Bucket -ProfileName testprofile -ProfilesLocation $creds_file
	Assert $buckets.BucketName.Length -Gt 0
}

function Test.SDKUserAgent
{
    try
    {
        Get-S3Bucket
    }
    catch
    {
    }
    
    $userAgent = [Amazon.Util.AWSSDKUtils]::SDKUserAgent
    #Write-Host "User agent = [$userAgent]"
    $containsAWSPS = $userAgent.Contains("AWSPowerShell")
    #Write-Host "Contains = [$containsAWSPS]"
    Assert $containsAWSPS -Eq $True
}