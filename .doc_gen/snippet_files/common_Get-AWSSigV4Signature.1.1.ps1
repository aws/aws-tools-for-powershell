$uri = "https://abc123.execute-api.us-west-2.amazonaws.com/prod/items"
$headers = Get-AWSSigV4Signature -Uri $uri -Service execute-api
Invoke-RestMethod -Uri $uri -Headers $headers