BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    $helper = New-Object ServiceTestHelper
    $helper.BeforeAll()
    $script:bucketName = 'samplebucket' + [DateTime]::Now.ToFileTime() + '--use1-az5--x-s3'
}

AfterAll {
    $helper.AfterAll()
    Remove-S3Bucket -BucketName $script:bucketName -Force -DeleteBucketContent
}

Describe -Tag "Smoke" "S3 Express" {

    Context "Buckets" {

        It "Can create an S3Express Bucket with PutConfiguration" {
            $bucketInfo = [Amazon.S3.Model.BucketInfo]::new()
            $bucketInfo.DataRedundancy = 'SingleAvailabilityZone'
            $bucketInfo.Type = 'Directory'
            
            $locationInfo = [Amazon.S3.Model.LocationInfo]::new()
            $locationInfo.Name = 'use1-az5'
            $locationInfo.Type = 'AvailabilityZone'
            
            $putBucketConfiguration = [Amazon.S3.Model.PutBucketConfiguration]::new()
            $putBucketConfiguration.BucketInfo = $bucketInfo
            $putBucketConfiguration.Location = $locationInfo
            
            New-S3Bucket -BucketName $script:bucketName -BucketConfiguration $putBucketConfiguration
        }
        It "Can list S3Express bucket" {
            (Get-S3DirectoryBucket).Buckets.BucketName | Should -Contain $script:bucketName
        }
      
    }
    Context "Writing" {      

        It "Can write objects with SSE" {
            Write-S3Object -BucketName $script:bucketName -Key foo.txt -Content "this is a test" -ServerSideEncryption AES256
            Write-S3Object -BucketName $script:bucketName -Key foo.txt -Content "this is a test" -ServerSideEncryption Aes256
        }

        It "Can write objects with no SSE" {
            Write-S3Object -BucketName $script:bucketName -Key foo.txt -Content "this is a test" -ServerSideEncryption None
            Write-S3Object -BucketName $script:bucketName -Key foo.txt -Content "this is a test" -ServerSideEncryption NoNe
        }

        It "Can write objects from a memory stream" {
            Write-S3Object -BucketName $script:bucketName -Key foo.txt -Stream (New-Object IO.MemoryStream)
            Write-S3Object -BucketName $script:bucketName -Key foo.txt -Stream (New-Object IO.MemoryStream(, [Text.Encoding]::UTF8.GetBytes("this is a test")))
        }

        It "Throws writing with invalid SSE option" {
            {
                Write-S3Object -BucketName $script:bucketName -Key foo.txt -Content "this is a test" -ServerSideEncryption Naan
            } | Should -Throw
        }
    }

    Context "Reading" {
     
        BeforeAll {
            
            $null = New-Item -Path temp\bar -Type directory -Force
            $null = New-Item -Path temp\bar\baz -Type directory -Force
            
            "sample text" | Out-File -FilePath ".\temp\bar\test.txt" -Force
            "more sample text" | Out-File -FilePath ".\temp\bar\test2.txt" -Force
            "another file" | Out-File -FilePath ".\temp\bar\baz\blah.txt" -Force
            "basic file" | Out-File -FilePath "temp\basic.txt" -Force

            Write-S3Object -BucketName $script:bucketName -KeyPrefix bar2\ -Folder .\temp\bar -Recurse
            Write-S3Object -BucketName $script:bucketName -Key bar2\foo.txt -Content "foo"
            Write-S3Object -BucketName $script:bucketName -Key basic.txt -File "temp\basic.txt"
        }

        It "Can download to a folder hierarchy" {
            Read-S3Object -BucketName $script:bucketName -KeyPrefix bar2\ -Folder temp\new-bar

            (Get-Content ".\temp\new-bar\foo.txt").Length | Should -BeGreaterThan 0
            (Get-Content ".\temp\new-bar\test.txt").Length | Should -BeGreaterThan 0
            (Get-Content ".\temp\new-bar\test2.txt").Length | Should -BeGreaterThan 0
            (Get-Content ".\temp\new-bar\baz\blah.txt").Length | Should -BeGreaterThan 0
        }

        It "Cannot download to a folder hierarchy with partial KeyPrefix and DisableSlashCorrection disabled (default setting)" {
            Read-S3Object -BucketName $script:bucketName -KeyPrefix 'ba' -Folder temp\new-bar-nodisableslashcorrection

            (Test-Path ".\temp\new-bar-nodisableslashcorrection\basic.txt") | Should -BeFalse
            (Test-Path ".\temp\new-bar-nodisableslashcorrection\bar2\foo.txt") | Should -BeFalse
            (Test-Path ".\temp\new-bar-nodisableslashcorrection\bar2\test.txt") | Should -BeFalse
            (Test-Path ".\temp\new-bar-nodisableslashcorrection\bar2\test2.txt") | Should -BeFalse
            (Test-Path ".\temp\new-bar-nodisableslashcorrection\bar2\baz\blah.txt") | Should -BeFalse
        }

        It "Can copy an object to a local file" {
            Copy-S3Object -BucketName $script:bucketName -Key "basic.txt" -LocalFile "$pwd\temp\blah.blah"
            (Get-Content "$pwd\temp\blah.blah").Length | Should -BeGreaterThan 0
        }

        It "Can read an object into a local file" {
            Read-S3Object -BucketName $script:bucketName -Key "basic.txt" -File "temp\basic2.txt"
            (Get-Content "temp\basic2.txt").Length | Should -BeGreaterThan 0
        }
    }
    Context "Copying" {
        It "Can copy with /-prefixed keys" {
            $prefixedKey = "/key"
            Write-S3Object -BucketName $script:bucketName -Key $prefixedKey -Content "this is a test"
            Copy-S3Object -BucketName $script:bucketName -Key $prefixedKey -DestinationKey "/data/keycopy"
        }
        It "Copy-S3Object returns type of S3Object" {
            $prefixedKey = "/key"
            Write-S3Object -BucketName $script:bucketName -Key $prefixedKey -Content "this is a test"
            $copyResult = Copy-S3Object -BucketName $script:bucketName -Key $prefixedKey -DestinationKey "/data/keycopy"
            $copyResult | Should -BeOfType Amazon.S3.Model.S3Object
        }
        It "Copy-S3Object result should have expected properties" {
            $sourceKey = 'sourcekey'
            $destKey = 'destkey'
            Write-S3Object -BucketName $script:bucketName -Key $sourceKey -Content "this is a test"
            $copyResult = Copy-S3Object -BucketName $script:bucketName -Key $sourceKey -DestinationKey $destKey
            $copyResult.BucketName | Should -BeExactly $script:bucketName
            $copyResult.Key | Should -BeExactly $destKey
            $copyResult.ETag  | Should -Not -BeNullOrEmpty
            $copyResult.Size  | Should -BeGreaterThan 0
            $copyResult.StorageClass  | Should -Not -BeNullOrEmpty
            $copyResult.LastModified  | Should -Not -BeNullOrEmpty
        }
    }
    Context "Checksums" {

        It "Put and get an object with a SHA1 checksum" {
            Write-S3Object -BucketName $script:bucketName -Key "ps-sha1" -Content "this is a test" -ChecksumAlgorithm SHA1
            Read-S3Object -BucketName $script:bucketName -Key "ps-sha1" -ChecksumMode ENABLED -File "temp\sha1.txt"
        }
        It "Put and get an object with a SHA256 checksum" {
            Write-S3Object -BucketName $script:bucketName -Key "ps-sha256" -Content "this is a test" -ChecksumAlgorithm SHA256
            Read-S3Object -BucketName $script:bucketName -Key "ps-sha256" -ChecksumMode ENABLED -File "temp\sha256.txt"
        }
        It "Put and get an object with a CRC32 checksum" {
            Write-S3Object -BucketName $script:bucketName -Key "ps-crc32" -Content "this is a test" -ChecksumAlgorithm CRC32
            Read-S3Object -BucketName $script:bucketName -Key "ps-crc32" -ChecksumMode ENABLED -File "temp\crc32.txt"
        }
        It "Put and get an object with a CRC32C checksum" {
            Write-S3Object -BucketName $script:bucketName -Key "ps-crc32c" -Content "this is a test" -ChecksumAlgorithm CRC32C
            Read-S3Object -BucketName $script:bucketName -Key "ps-crc32c" -ChecksumMode ENABLED -File "temp\crc32c.txt"
        }
        It "Can copy an object with a checksum with a Key without trailing slash" {
            Write-S3Object -BucketName $script:bucketName -Key "source" -Content "this is a test" -ChecksumAlgorithm SHA256
            Copy-S3Object -BucketName $script:bucketName -Key "source" -DestinationBucket $script:bucketName -DestinationKey "dest" -ChecksumAlgorithm SHA256
            Get-S3ObjectAttribute -BucketName $script:bucketName -Key "dest" -ObjectAttributes Checksum | Select-Object -ExpandProperty Checksum | Should -Not -BeNullOrEmpty
        }
        It "Can copy an object with a checksum with a Key with a trailing slash" {
            Write-S3Object -BucketName $script:bucketName -Key "source/" -Content "this is a test" -ChecksumAlgorithm SHA256
            Copy-S3Object -BucketName $script:bucketName -Key "source/" -DestinationBucket $script:bucketName -DestinationKey "dest/" -ChecksumAlgorithm SHA256
            Get-S3ObjectAttribute -BucketName $script:bucketName -Key "dest/" -ObjectAttributes Checksum | Select-Object -ExpandProperty Checksum | Should -Not -BeNullOrEmpty
        }

        It "Can delete objects with a checksum" {
            Write-S3Object -BucketName $script:bucketName -Key "key1" -Content "this is a test"
            Write-S3Object -BucketName $script:bucketName -Key "key2" -Content "this is a test"

            Remove-S3Object -BucketName $script:bucketName -KeyCollection @( "key1", "key2" ) -ChecksumAlgorithm SHA256 -Force

            { Read-S3Object -BucketName $script:bucketName -Key "key1" -File "temp\key1.txt" } | Should -Throw
            { Read-S3Object -BucketName $script:bucketName -Key "key2" -File "temp\key2.txt" } | Should -Throw
        }
    }
    Context "Delete S3Express Bucket" {
        It "Can delete buckets" {

            $deleteBucketName = 'samplebucket2' + [DateTime]::Now.ToFileTime() + '--use1-az5--x-s3'


            $bucketInfo = [Amazon.S3.Model.BucketInfo]::new()
            $bucketInfo.DataRedundancy = 'SingleAvailabilityZone'
            $bucketInfo.Type = 'Directory'
            
            $locationInfo = [Amazon.S3.Model.LocationInfo]::new()
            $locationInfo.Name = 'use1-az5'
            $locationInfo.Type = 'AvailabilityZone'
            
            $putBucketConfiguration = [Amazon.S3.Model.PutBucketConfiguration]::new()
            $putBucketConfiguration.BucketInfo = $bucketInfo
            $putBucketConfiguration.Location = $locationInfo
            
            New-S3Bucket -BucketName $deleteBucketName -BucketConfiguration $putBucketConfiguration

            # continual eventual consistency issues with testing bucket no longer exists,
            # (even after various sleeps) so stopped verifying
            $deleteBucketName | Remove-S3Bucket -Force
        }
    }
}