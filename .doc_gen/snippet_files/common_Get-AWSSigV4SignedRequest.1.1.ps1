$uri = "https://abc123.execute-api.us-west-2.amazonaws.com/prod/items"
$request = Get-AWSSigV4SignedRequest -Uri $uri -Service execute-api
Invoke-RestMethod @request