$resIdentifier=[Amazon.ConfigService.Model.AggregateResourceIdentifier]@{
		ResourceId= "i-012e3cb4df567e8aa"
		ResourceName = "arn:aws:ec2:eu-west-1:123456789012:instance/i-012e3cb4df567e8aa"
		ResourceType = [Amazon.ConfigService.ResourceType]::AWSEC2Instance
		SourceAccountId = "123456789012"
		SourceRegion = "eu-west-1"
	}
		
	Get-CFGAggregateResourceConfigBatch -ResourceIdentifier $resIdentifier -ConfigurationAggregatorName raju