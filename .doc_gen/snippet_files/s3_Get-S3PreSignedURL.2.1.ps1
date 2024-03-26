[Amazon.AWSConfigsS3]::UseSignatureVersion4 = $true
      Get-S3PreSignedURL -BucketName sampledirectorybucket--use1-az5--x-s3 -Key 'testkey' -Expire '2023-11-17'