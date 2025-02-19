(Get-EC2Instance -Filter @{Name="instance-state-name";Values=@("running","stopped")}).Instances `
 | Select InstanceID,InstanceType,Platform,PrivateIpAddress,@{Name="Name";Expression={$_.Tags[$_.Tags.Key.IndexOf("Name")].Value}},@{N="State";E={$_.State.Name}} `
 | Format-Table