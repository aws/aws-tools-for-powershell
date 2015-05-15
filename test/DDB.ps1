Function Test.DDB.ListTables([switch] $Category_Smoke)
{
	$tables = Get-DDBTables
    if ($tables -ne $null)
    {
        Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
    }
}

function Init.DDB.NewTable()
{
	$context.TableName = "PSDDBTest" + [System.DateTime]::UtcNow.ToString("yyyyMMddTHHmmssZ")
}
function Test.DDB.NewTable([switch] $Category_Smoke)
{
	$schema = New-DDBTableSchema
	$schema | Add-DDBKeySchema -KeyName "ForumName" -KeyDataType S
	$schema | Add-DDBKeySchema -KeyName "Subject" -KeyType "range" -KeyDataType S
	$schema | Add-DDBIndexSchema -IndexName "LastPostIndex" -RangeKeyName "LastPostDateTime" -RangeKeyDataType "S" -ProjectionType "keys_only"
	$table = New-DDBTable -TableName $context.TableName -ReadCapacity 10 -WriteCapacity 5 -Schema $schema

	Assert $table -IsNotNull

	$tableStatus = $table.TableStatus
	Write-Host "...latest status: " $tableStatus

	while ($tableStatus -eq "CREATING")
	{
		Write-Host "...sleeping 5s, waiting for table creation to complete"
		Start-Sleep -s 5

		$table = Get-DDBTable $context.TableName
		if ($table -ne $null)
		{
			$tableStatus = $table.TableStatus
			Write-Host "...latest status: " $tableStatus
		}
	} 

	Assert $tableStatus -eq "ACTIVE"
}
function Term.DDB.NewTable()
{
	# need to grab TableDescription otherwise test f/x thinks
	# it's a failure (not int) so may as well make it useful
	$table = Remove-DDBTable $context.TableName -Force
	Assert $table -IsNotNull
}
