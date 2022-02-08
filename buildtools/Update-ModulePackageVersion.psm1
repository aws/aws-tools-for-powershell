$ErrorActionPreference = "Stop"
$env:AWS_STS_REGIONAL_ENDPOINTS = 'regional'

$ddbClient = $null
function Update-ModulePackageVersion([string]$modulePath, [string]$versionNumber, [string]$repository, [string]$profileName) {
    if ($null -eq $ddbClient) {
        $credentials = $null
        $profileVal = $null
        $chain = New-Object Amazon.Runtime.CredentialManagement.CredentialProfileStoreChain($null)
        if ($true -eq $chain.TryGetProfile($profileName, [ref]$profileVal)) {
            $credentials = $profileVal.GetAWSCredentials($chain)
        }
        else {
            Throw "Credential profile $(profileName) could not be found."
        }
        
        $ddbClient = New-Object Amazon.DynamoDBv2.AmazonDynamoDBClient($credentials, [Amazon.RegionEndpoint]::USWest2)
    }

    #Extract the filename off of the path
    $packageId = Split-Path $modulePath -leaf
    
    #Setup update item request
    $request = New-Object Amazon.DynamoDBv2.Model.UpdateItemRequest
    $request.TableName = "PackageVersions"
    $request.Key = New-Object "system.collections.generic.dictionary[string, Amazon.DynamoDBv2.Model.AttributeValue]"
    $request.AttributeUpdates = New-Object "system.collections.generic.dictionary[string, Amazon.DynamoDBv2.Model.AttributeValueUpdate]"

    #Set the key
    $val = New-Object Amazon.DynamoDBv2.Model.AttributeValue
    $val.S = $packageId
    $request.Key.Add("PackageId", $val)

    #Add fields to update
    $fields = @(        
        @("LatestVersionNumber", $versionNumber),
        @("Repository", $repository),
        @("LastPublishedOn", (Get-Date).ToUniversalTime().ToString("s"))
    )
    
    foreach ($field in $fields) {		
        $attribute = New-Object Amazon.DynamoDBv2.Model.AttributeValueUpdate
        $attribute.Action = [Amazon.DynamoDBv2.AttributeAction]::PUT
        $attribute.Value = New-Object Amazon.DynamoDBv2.Model.AttributeValue
        $attribute.Value.S = $field[1]
        $request.AttributeUpdates.Add($field[0], $attribute)
    }    

    $ddbClient.UpdateItemAsync($request).GetAwaiter().GetResult()
}

Export-ModuleMember -Function "Update-ModulePackageVersion"