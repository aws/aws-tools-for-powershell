Measure-CFNTemplateCost -TemplateURL https://s3.amazonaws.com/mytemplates/templatefile.template `
                        -Region us-west-1 `
                        -Parameter @{ ParameterKey="KeyName"; ParameterValue="myKeyPairName" }