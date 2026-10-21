$request = Get-AWSSigV4PreSignedURL -Uri "https://abc123.execute-api.us-west-2.amazonaws.com/prod/items" -Service execute-api -Expire (Get-Date).AddMinutes(15)
Invoke-RestMethod @request