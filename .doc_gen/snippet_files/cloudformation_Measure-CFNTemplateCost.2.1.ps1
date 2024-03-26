Measure-CFNTemplateCost -TemplateBody "{TEMPLATE CONTENT HERE}" `
                        -Parameter @( @{ ParameterKey="KeyName"; ParameterValue="myKeyPairName" },`
                                      @{ ParameterKey="InstanceType"; ParameterValue="m1.large" })