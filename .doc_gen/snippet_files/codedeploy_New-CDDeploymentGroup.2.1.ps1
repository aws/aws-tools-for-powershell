New-CDDeploymentGroup -ApplicationName MyNewApplication -AutoScalingGroup CodeDeployDemo-ASG -DeploymentConfigName CodeDeployDefault.OneAtATime -DeploymentGroupName MyNewDeploymentGroup -Ec2TagFilter @{Key="Name"; Type="KEY_AND_VALUE"; Value="CodeDeployDemo"} -ServiceRoleArn arn:aws:iam::80398EXAMPLE:role/CodeDeployDemo -Ec2TagSetList @(@{Key="key1";Type="KEY_ONLY"},@{Key="Key2";Type="KEY_AND_VALUE";Value="Value2"}),@(@{Key="Key3";Type="VALUE_ONLY";Value="Value3"})