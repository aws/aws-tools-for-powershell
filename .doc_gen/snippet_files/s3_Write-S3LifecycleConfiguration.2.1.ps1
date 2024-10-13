$ExpireRule = [Amazon.S3.Model.LifecycleRule] @{
		Expiration =  @{
			Days=  150
		}
		Id =  "Remove-in-150-days"
		Filter=  @{
			LifecycleFilterPredicate =  [Amazon.S3.Model.LifecycleAndOperator]@{
				Operands=  @(
					[Amazon.S3.Model.LifecyclePrefixPredicate] @{
						"Prefix" =  "py"
					},
					[Amazon.S3.Model.LifecycleTagPredicate] @{
						"Tag"=  @{
							"Key" =  "archived"
							"Value" = "yes"
						}
					}
				)
			}
		}
		Status= 'Enabled'
		NoncurrentVersionExpiration = @{
			NoncurrentDays = 150
		}
	}

	$ArchiveRule = [Amazon.S3.Model.LifecycleRule] @{
		Expiration =  $null
		Id =  "Archive-to-Glacier-in-30-days"
		Filter=  @{
			LifecycleFilterPredicate =  [Amazon.S3.Model.LifecycleAndOperator]@{
				Operands= @(
					[Amazon.S3.Model.LifecyclePrefixPredicate] @{
						"Prefix" =  "py"
					},
					[Amazon.S3.Model.LifecycleTagPredicate] @{
						"Tag"=  @{
							"Key" =  "reviewed"
							"Value" = "yes"
						}
					}
				)
			}
		}
		Status = 'Enabled'
		NoncurrentVersionExpiration = @{
			NoncurrentDays = 75
		}
		Transitions = @(
			@{
				Days = 30
				"StorageClass"= 'Glacier'
			},
			@{
				Days = 120
				"StorageClass"= [Amazon.S3.S3StorageClass]::DeepArchive
			}
		)
	}

	Write-S3LifecycleConfiguration -BucketName amzn-s3-demo-bucket -Configuration_Rule $ExpireRule,$ArchiveRule