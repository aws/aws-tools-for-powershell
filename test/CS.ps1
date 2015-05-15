function Test.CS
{
	$domains = Get-CSDomain
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($domains -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -gt 0
	}

	foreach($domain in $domains)
	{
		$dn = $domain.DomainName
		Assert $domain -IsNotNull
		Write-Host "Examining domain [$dn]"

#		$searchField = Get-CSDefaultSearchField -DomainName $dn
#		Assert $searchField -IsNotNull
#		Assert $awshistory.LastServiceResponse -IsNotNull
#		$status = $searchField.Status
#		Assert $status -IsNotNull

		$indexFields = Get-CSIndexField -DomainName $dn
		Assert $awshistory.LastServiceResponse -IsNotNull
		if ($indexFields -ne $null)
		{
			Assert $awshistory.LastCommand.EmittedObjectsCount -gt 0
		}

#		$stemming = Get-CSStemmingOption -DomainName $dn
#		Assert $stemming -IsNotNull
#		Assert $awshistory.LastServiceResponse -IsNotNull
#		Assert $stemming.Options -IsNotNull
#		Assert $stemming.Status -IsNotNull
#	
#		$stopword = Get-CSStopwordOption -DomainName $dn
#		Assert $stopword -IsNotNull
#		Assert $awshistory.LastServiceResponse -IsNotNull
#		Assert $stopword.Options -IsNotNull
#		Assert $stopword.Status -IsNotNull
#	
#		$synonym = Get-CSSynonymOption -DomainName $dn
#		Assert $synonym -IsNotNull
#		Assert $awshistory.LastServiceResponse -IsNotNull
#		Assert $synonym.Options -IsNotNull
#		Assert $synonym.Status -IsNotNull
	}
}
