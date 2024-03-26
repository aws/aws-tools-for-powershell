New-CFNStack -StackName "myStack" `
             -TemplateBody "{TEMPLATE CONTENT HERE}" `
             -Parameter @( @{ ParameterKey="PK1"; ParameterValue="PV1" }, @{ ParameterKey="PK2"; ParameterValue="PV2" }) `
             -DisableRollback $true