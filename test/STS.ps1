function Test.STS.GetSessionToken
{
    $creds = Get-STSSessionToken

	Assert $awshistory.LastServiceResponse -IsNotNull
	Assert $awshistory.LastCommand.EmittedObjectsCount -eq 1
    Assert $creds -IsNotNull

    Assert $creds.SessionToken -IsNotNull
    Assert $creds.SessionToken.Length -gt 0
}
