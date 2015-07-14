function Test.ASA.DescribeServices
{
    # Serves as a simple test case to ensure SDK service assembly has loaded correctly.
    # Note that calling AWS Support requires an account with an AWS Premium Support
    # subscription.
    $services = Get-ASAServices -Region us-east-1
    Assert $services -IsNotNull
    Assert $services.Count -ge 0
    if ($services.Count -gt 0)
    {
		Assert $awshistory.LastCommand.EmittedObjectsCount -eq $services.Count
    }
}
