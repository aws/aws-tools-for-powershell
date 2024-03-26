$credential = Get-Credential -Message "Enter your domain credentials for federated identity"    
Set-AWSCredential -ProfileName mySamlCredentialProfile -NetworkCredential $credential