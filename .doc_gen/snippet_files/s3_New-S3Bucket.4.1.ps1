$bucketConfiguration = @{
      BucketInfo = @{
          DataRedundancy = 'SingleAvailabilityZone'
          Type = 'Directory'
      }
      Location = @{
          Name = 'use1-az5'
          Type = 'AvailabilityZone'
      }
    }
New-S3Bucket -BucketName samplebucket--use1-az5--x-s3 -BucketConfiguration $bucketConfiguration -Region us-east-1