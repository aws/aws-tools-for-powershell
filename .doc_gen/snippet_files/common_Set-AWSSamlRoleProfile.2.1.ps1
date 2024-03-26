$credential = Get-Credential -Message "Enter user credentials for authentication" 
Set-AWSSamlRoleProfile -StoreAs Role1 -EndpointName MyADFSEndpoint -NetworkCredential $credential