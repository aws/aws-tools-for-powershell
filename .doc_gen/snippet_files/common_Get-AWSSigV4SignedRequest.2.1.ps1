$uri = "https://abc123.execute-api.us-west-2.amazonaws.com/prod/items"
$body = @{ Name = "example" } | ConvertTo-Json -Compress
$request = Get-AWSSigV4SignedRequest -Uri $uri -Method POST -Body $body -Header @{ "Content-Type" = "application/json" } -Service execute-api
Invoke-RestMethod @request -TimeoutSec 30