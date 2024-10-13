New-CFNStack -StackName "myStack" `
             -TemplateURL https://s3.amazonaws.com/amzn-s3-demo-bucket/templatefile.template `
             -Parameter @{ ParameterKey="PK1"; ParameterValue="PV1" }