Get-CFGAggregateDiscoveredResourceCount -ConfigurationAggregatorName Master -Filters_Region us-east-1 -GroupByKey RESOURCE_TYPE | 
			Select-Object -ExpandProperty GroupedResourceCounts