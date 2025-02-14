BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "RetryHelper.ps1")
    $helper = New-Object ServiceTestHelper
    $helper.BeforeAll()
}

AfterAll {
    $helper.AfterAll()
}
# ServerSideEncryptionKeyManagementServiceKeyId property is sensitive in Amazon.S3.Model.PutObjectRequest
# There are no sensitive responses in S3 Advanced Cmdlets
Describe -Tag "Smoke" "S3 AWSHistory Advanced Cmdlet" {
    BeforeAll {
        $bucketName = "pstest-" + [DateTime]::Now.ToFileTime()
        $bucket = New-S3Bucket -BucketName $bucketName
        $kmsKey = New-KMSKey -KeySpec SYMMETRIC_DEFAULT -KeyUsage ENCRYPT_DECRYPT

        $enabledKey = Invoke-WithRetry `
            -ScriptBlock { Get-KMSKey -KeyId $kmsKey.KeyId } `
            -ValidateBlock { param($result) $result.KeyState -eq 'Enabled' } `
            -OperationName "KMS key creation" `
            -Verbose

        $writeObjectParams = @{
            'BucketName'                                    = $bucketName
            'Key'                                           = 'test.txt'
            'Content'                                       = 'this is test'
            'ServerSideEncryptionKeyManagementServiceKeyId' = $kmsKey.KeyId
            'ServerSideEncryption'                          = 'aws:kms'
        }
    }
    AfterAll {
        Remove-S3Bucket -BucketName $bucketName -Force -DeleteBucketContent
        Request-KMSKeyDeletion -KeyId $kmsKey.KeyId -Force -PendingWindowInDay 7
    }
    Context '$AWSHistory Sensitive Data Redacted' {
        It '$AWSHistory Request is not recorded by default' {
            $result = Write-S3Object @writeObjectParams
            $AWSHistory.Commands.ToArray()[-1].CmdletName | Should -Be 'Write-S3Object'
            $AWSHistory.LastServiceRequest | Should -Be $null
        }
    }
    Context '$AWSHistory non-sensitive data is not redacted' {
        It '$AWSHistory Response Non-Sensitive data is not Redacted' {

            $s3bucket = Get-S3Bucket -BucketName $bucketName

            $AWSHistory.Commands.ToArray()[-1].CmdletName | Should -Be 'Get-S3Bucket'
            $AWSHistory.LastServiceResponse | Should -Not -Be $null
            $bucketName | Should -BeIn $awsHistory.LastServiceResponse.Buckets.BucketName
        }
    }
    Context '$AWSHistory RecordServiceRequests is set' {
        BeforeAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests
        }
        AfterAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests:$false
        }
        It '$AWSHistory Request Redacted' {
            $result = Write-S3Object @writeObjectParams


            $AWSHistory.Commands.ToArray()[-1].CmdletName | Should -Be 'Write-S3Object'
            $AWSHistory.LastServiceRequest | Should -Not -Be $null
            $AWSHistory.LastServiceRequest.ServerSideEncryptionKeyManagementServiceKeyId | Should -BeNullOrEmpty
        }
    }
    Context '$AWSHistory RecordServiceRequests and IncludeSensitiveData are set' {
        BeforeAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests -IncludeSensitiveData
        }
        AfterAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests:$false -IncludeSensitiveData:$false
        }
        It '$AWSHistory has full Request when RecordServiceRequests and IncludeSensitiveData are set' {
            $result = Write-S3Object @writeObjectParams

            $AWSHistory.LastServiceRequest | Should -Not -Be $null
            $AWSHistory.LastServiceRequest.ServerSideEncryptionKeyManagementServiceKeyId | Should -BeExactly $kmsKey.KeyId 
        }
    }
    Context '$AWSHistory RecordServiceRequests is false, IncludeSensitiveData is true' {
        BeforeAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests:$false -IncludeSensitiveData:$true
        }
        AfterAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests:$false -IncludeSensitiveData:$false
        }
        It '$AWSHistory Request is not recorded when RecordServiceRequests is false' {
            $result = Write-S3Object @writeObjectParams

            $AWSHistory.Commands.ToArray()[-1].CmdletName | Should -Be 'Write-S3Object'
            $AWSHistory.LastServiceRequest | Should -Be $null
        }
    }
}