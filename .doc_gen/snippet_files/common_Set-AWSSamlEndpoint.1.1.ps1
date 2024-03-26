$endpoint = "https://adfs.example.com/adfs/ls/IdpInitiatedSignOn.aspx?loginToRp=urn:amazon:webservices"	
Set-AWSSamlEndpoint -StoreAs MyADFSEndpoint -Endpoint $endpoint