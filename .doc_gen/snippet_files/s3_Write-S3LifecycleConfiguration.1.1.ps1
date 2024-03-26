$NewRule = [Amazon.S3.Model.LifecycleRule] @{
		Expiration =  @{
			Days=  50
		}
		Id =  "Test-From-Write-cmdlet-1"
		Filter=  @{
			LifecycleFilterPredicate =  [Amazon.S3.Model.LifecycleAndOperator]@{
				Operands=  @(
					[Amazon.S3.Model.LifecyclePrefixPredicate] @{
						"Prefix" =  "py"
					},
					[Amazon.S3.Model.LifecycleTagPredicate] @{
						"Tag"=  @{
							"Key" =  "non-use"
							"Value" = "yes"
						}
					}
				)
			}
		}
		"Status"= 'Enabled'
		NoncurrentVersionExpiration = @{
			NoncurrentDays = 75
		}
	}
    
	Write-S3LifecycleConfiguration -BucketName my-review-scrap -Configuration_Rule $NewRule