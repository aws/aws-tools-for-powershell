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
    # make a call so the static user agent field gets set in the relevant
    # service config
    try
    {
        Get-S3Bucket
    }
    catch
    {
    }
    
    # new up a config for the service, read back the user agent and test that
    # our expected data is present
    $s3Config = new-object Amazon.S3.AmazonS3Config
    $userAgent = $s3Config.UserAgent
    #Write-Host "User agent = [$userAgent]"
    $containsAWSPS = $userAgent.Contains("AWSPowerShell")
    #Write-Host "Contains = [$containsAWSPS]"
    Assert $containsAWSPS -Eq $True
}