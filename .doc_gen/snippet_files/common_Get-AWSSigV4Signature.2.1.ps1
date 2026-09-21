$uri = "https://abc123.execute-api.us-west-2.amazonaws.com/prod/items"
$body = @{ Name = "example" } | ConvertTo-Json -Compress
$contentType = @{ "Content-Type" = "application/json" }
$headers = Get-AWSSigV4Signature -Uri $uri -Method POST -Body $body -Header $contentType -Service execute-api
Invoke-RestMethod -Uri $uri -Method POST -Body $body -Headers ($headers + $contentType)