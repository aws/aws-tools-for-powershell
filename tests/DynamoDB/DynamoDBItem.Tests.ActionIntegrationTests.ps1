BeforeAll {
    $table1Name = 'Music'

    $schema = New-DDBTableSchema

    $null = Add-DDBKeySchema -KeyName "SongTitle" -KeyType 'HASH' -KeyDataType "S" -Schema $schema
    $null = Add-DDBKeySchema -KeyName "Artist" -KeyType 'RANGE' -KeyDataType "S" -Schema $schema

    $addDdbIndexSchema = @{
        IndexName = "SongTitle-AlbumTitle-index"
        Global = $true
        HashKeyName = 'SongTitle'
        HashKeyDataType = 'S'
        RangeKeyName = "AlbumTitle"
        RangeKeyDataType = "S"
        ProjectionType = "keys_only"
        ReadCapacity = 1
        WriteCapacity = 1
        Schema = $schema
    }
    $null = Add-DDBIndexSchema @addDdbIndexSchema
    $null = New-DDBTable -TableName $table1Name -ReadCapacity 10 -WriteCapacity 5 -Schema $schema

    # Wait for DDB Table to create
    :waitTable for ($index = 0; $index -le 10; $index++)
    {
        if ($index -eq 10)
        {
            throw "Test DynamoDB table creation timed out."
        }

        if ((Get-DDBTable -TableName $table1Name).TableStatus -ne 'ACTIVE')
        {
            $index++
            Start-Sleep -Seconds $index
        }
        else
        {
            break :waitTable
        }
    }

    #New-DdbTable -TableName $table1Name -
    $song1ItemHashTable = @{
        SongTitle = "My Dog Spot" # PartitionKey
        Artist = "No One You Know" # SortKey
        AlbumTitle = "Hey Now"
        Price = 1.98
        Genre = "Country"
        CriticRating = 8.4
    }

    $song1KeyHashTable = @{
        SongTitle = $song1ItemHashTable.SongTitle
        Artist = $song1ItemHashTable.Artist
    }

    $item1 = ConvertTo-DDBItem -InputObject $song1ItemHashTable
    $key1 = ConvertTo-DDBItem -InputObject $song1KeyHashTable

    $song2ItemHashTable = @{
        SongTitle = 'Somewhere Down The Road' # PartitionKey
        Artist = 'No One You Know' # SortKey
        AlbumTitle = 'Somewhat Famous'
        Price = 1.94
        Genre = 'Country'
        CriticRating = 9.0
    }

    $song2KeyHashTable = @{
        SongTitle = $song2ItemHashTable.SongTitle
        Artist = $song2ItemHashTable.Artist
    }

    $item2 = ConvertTo-DDBItem -InputObject $song2ItemHashTable
    $key2 = ConvertTo-DDBItem -InputObject $song2KeyHashTable
}
Describe -Tag "Smoke" "DynamoDBv2 PowerShell Module Integration Tests" {
    BeforeEach {
        $ddbAttributeDictionary = Set-DDBItem -TableName $table1Name -Item $item1
    }

    It 'Set-DDBItem creates a DynamoDB table item' {
        $key1 = ConvertTo-DDBItem -InputObject $song1KeyHashTable
        $ddbAttributeDictionary = Get-DDBItem -TableName $table1Name -Key $key1
        $outputItem = ConvertFrom-DDBItem -InputObject $ddbAttributeDictionary

        $outputItem.SongTitle | Should -Be $song1KeyHashTable.SongTitle -Because 'this test sets and gets an item with this property'
        $outputItem.Artist | Should -Be $song1KeyHashTable.Artist -Because 'this test sets and gets an item with this property'
    }

    It 'Set-DDBItem replaces a DynamoDB table item' {
        $modifiedSong1KeyHashTable = $song1KeyHashTable.Clone()
        $modifiedSong1KeyHashTable.Remove('CriticRating')

        $item1 = ConvertTo-DDBItem -InputObject $modifiedSong1KeyHashTable
        Set-DDBItem -TableName $table1Name -Item $item1

        $ddbAttributeDictionary = Get-DDBItem -TableName $table1Name -Key $key1
        $outputItem = ConvertFrom-DDBItem -InputObject $ddbAttributeDictionary

        $ddbAttributeDictionary.PSObject.Properties.Name | Should -Not -Contain 'CriticRating' -Because 'this test sets an item without this property'
        $outputItem.Artist | Should -Be $song1KeyHashTable.Artist -Because 'this test sets and gets an item with this property'
    }

    It 'Invoke-DDBScan gets multiple items from a DynamoDB table.' {
        Set-DDBItem -TableName $table1Name -Item $item2

        $outputItems = Invoke-DDBScan -TableName $table1Name | ConvertFrom-DDBItem

        $outputItems.SongTitle | Should -Contain 'My Dog Spot' -Because 'this test scans a table containing an item with this song title'
        $outputItems.SongTitle | Should -Contain 'Somewhere Down the Road' -Because 'this test scans a table containing an item with this song title'
    }

    It 'Update-DDBItem changes a property for a DynamoDB table item' {
        $updateDdbItem = @{
            TableName = $table1Name
            Key = $key1
            UpdateExpression = 'set Genre = :val1'
            ExpressionAttributeValue = (@{
                ':val1' = ([Amazon.DynamoDBv2.Model.AttributeValue]'Rap')
            })
            ReturnValue = 'UPDATED_NEW'
        }
        $outputItem = Update-DDBItem @updateDdbItem | ConvertFrom-DDBItem

        $outputItem.Genre | Should -Be 'Rap' -Because 'this test changes the genre property from country to rap'
    }

    It 'Invoke-DDBQuery gets DDB items using a query expression.' {
        $invokeDDBQuery = @{
            TableName = $table1Name
            KeyConditionExpression = ' SongTitle = :SongTitle and Artist = :Artist'
            ExpressionAttributeValues = @{
                ':SongTitle' = [Amazon.DynamoDBv2.Model.AttributeValue]'My Dog Spot'
                ':Artist' = [Amazon.DynamoDBv2.Model.AttributeValue]'No One You Know'
            }
        }
        $outputItem = Invoke-DDBQuery @invokeDDBQuery | ConvertFrom-DDBItem

        $outputItem.Price | Should -Be 1.98 -Because 'the DDB item found by this query has a price of 1.98'
    }

    It 'Remove-DDBItem deletes a DynamoDB table item' {
        $key1 = ConvertTo-DDBItem -InputObject $song1KeyHashTable
        $outputItem = Remove-DDBItem -TableName $table1Name -Key $key1 -ReturnValue 'ALL_OLD' -Confirm:$false | ConvertFrom-DDBItem

        $outputItem.SongTitle | Should -Be $song1KeyHashTable.SongTitle
        $outputItem.Artist | Should -Be $song1KeyHashTable.Artist
    }

    It "Get-DDBBatchItem returns a batch of DynamoDB items." {
        $keysAndAttributes = New-Object Amazon.DynamoDBv2.Model.KeysAndAttributes
        $list = New-Object 'System.Collections.Generic.List[System.Collections.Generic.Dictionary[String, Amazon.DynamoDBv2.Model.AttributeValue]]'
        $list.Add($key1)
        $keysAndAttributes.Keys = $list

        $items = Get-DDBBatchItem -RequestItem @{$table1Name = [Amazon.DynamoDBv2.Model.KeysAndAttributes]$keysAndAttributes}
        ($items.Music | ConvertFrom-DDBItem).SongTitle | Should -Be 'My Dog Spot' -Because 'this test specifies a DynamoDB item with that song title'
    }

    It "Write-DDBBatchItem returns a batch of DynamoDB items." {

        $modifiedSong1KeyHashTable = $song1KeyHashTable.Clone()
        $modifiedSong1KeyHashTable.CriticRating = '10'

        $item1 = ConvertTo-DDBItem -InputObject $modifiedSong1KeyHashTable
        $writeRequest = New-Object Amazon.DynamoDBv2.Model.WriteRequest
        $writeRequest.PutRequest = [Amazon.DynamoDBv2.Model.PutRequest]$item1

        $requestItem = @{
            $table1Name = [Amazon.DynamoDBv2.Model.WriteRequest]($writeRequest)
        }

        Set-DDBBatchItem -RequestItem $requestItem
        $outputItem = Get-DDBItem -TableName $table1Name -Key $key1 | ConvertFrom-DDBItem

        $outputItem.CriticRating | Should -Be 10 -Because 'this test specifies a DynamoDB item with that critic rating'
    }
}

AfterAll {
    Remove-DDBTable -TableName $table1Name -Confirm:$false
}