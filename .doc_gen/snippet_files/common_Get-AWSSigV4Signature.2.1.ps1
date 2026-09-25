$uri = "https://abc123.execute-api.us-west-2.amazonaws.com/prod/items"
$body = @{ Name = "example" } | ConvertTo-Json -Compress
$contentType = "application/json"
$headers = Get-AWSSigV4Signature -Uri $uri -Method POST -Body $body -Header @{ "Content-Type" = $contentType } -Service execute-api
Invoke-RestMethod -Uri $uri -Method POST -Body $body -ContentType $contentType -Headers $headers -SkipHeaderValidation