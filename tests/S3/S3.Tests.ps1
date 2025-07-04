BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    $helper = New-Object ServiceTestHelper
    $helper.BeforeAll()
    $script:bucketName = "pstest-" + [DateTime]::Now.ToFileTime()
}

AfterAll {
    $helper.AfterAll()
}

Describe -Tag "Smoke" "S3" {

    Context "Buckets" {

        It "Can list buckets" {
            $buckets = Get-S3Bucket
            if ($buckets) {
                $buckets.Count | Should -BeGreaterThan 0
            }
        }

        It "Can create a bucket" {
            New-S3Bucket -BucketName $script:bucketName
        
            Test-S3Bucket $script:bucketName | Should -Be $true
        }

        It "Can delete buckets" {
        	# continual eventual consistency issues with testing bucket no longer exists,
	        # (even after various sleeps) so stopped verifying
            $script:bucketName | Remove-S3Bucket -Force
        }
    }

    Context "Writing" {

        BeforeAll {
            $script:bucketName = "pstest-" + [DateTime]::Now.ToFileTime()
            New-S3Bucket -BucketName $script:bucketName
        }

        AfterAll {
            $script:bucketName | Remove-S3Bucket -Force -DeleteBucketContent
        }        

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
            Write-S3Object -BucketName $script:bucketName -Key foo.txt -Stream (New-Object IO.MemoryStream(,[Text.Encoding]::UTF8.GetBytes("this is a test")))
        }

        It "Throws writing with invalid SSE option" {
            {
                Write-S3Object -BucketName $script:bucketName -Key foo.txt -Content "this is a test" -ServerSideEncryption Naan
            } | Should -Throw
        }

        It "Can verify bucket ownership during write operations" {
            $accountId = (Get-S3Bucket -BucketName $script:bucketName).Owner.ID
            Write-S3Object -BucketName $script:bucketName -Key "ownership-test.txt" -ExpectedBucketOwner $accountId -Content "testing bucket ownership verification"
        }
    }

    Context "Reading" {
     
        BeforeAll {
            $script:bucketName = "pstest-" + [DateTime]::Now.ToFileTime()
            New-S3Bucket -BucketName $script:bucketName
            $key = "versionTest"
            $void = New-Item -Path temp\bar -Type directory -Force
            $void = New-Item -Path temp\bar\baz -Type directory -Force
            
            "sample text" | Out-File -FilePath ".\temp\bar\test.txt" -Force
            "more sample text" | Out-File -FilePath ".\temp\bar\test2.txt" -Force
            "another file" | Out-File -FilePath ".\temp\bar\baz\blah.txt" -Force
            "basic file" | Out-File -FilePath "temp\basic.txt" -Force

            Write-S3Object -BucketName $script:bucketName -KeyPrefix bar2\ -Folder .\temp\bar -Recurse -EnableLegacyKeyCleaning
            Write-S3Object -BucketName $script:bucketName -Key bar2\foo.txt -Content "foo" -EnableLegacyKeyCleaning
            Write-S3Object -BucketName $script:bucketName -Key basic.txt -File "temp\basic.txt" -EnableLegacyKeyCleaning

            Write-S3Object -BucketName $script:bucketName -KeyPrefix bar2v5/ -Folder .\temp\bar -Recurse
            Write-S3Object -BucketName $script:bucketName -Key bar2v5/foo.txt -Content "foo"
            Write-S3Object -BucketName $script:bucketName -Key basic.txt -File "temp\basic.txt"

            Write-S3Object -BucketName $script:bucketName -KeyPrefix bar2v5backslash\ -Folder .\temp\bar -Recurse
            Write-S3Object -BucketName $script:bucketName -Key bar2v5backslash\foo.txt -Content "foo"

            Write-S3Object -BucketName $script:bucketName -Key '\leading-backslash.txt' -Content "leading backslash content"

            Write-S3Object -BucketName $script:bucketName -Key '\leading-backslash-with-keycleaning.txt' -Content "leading backslash content" -EnableLegacyKeyCleaning

            Write-S3BucketVersioning -BucketName $script:bucketName -VersioningConfig_Status Enabled

            Write-S3Object -BucketName $script:bucketName -Key $key -Content "Version 1"
            Write-S3Object -BucketName $script:bucketName -Key $key -Content "Version 2"

            $s3ObjectVersions = Get-S3Version -BucketName $script:bucketName -Prefix $key

            
        }

        AfterAll {
            $script:bucketName | Remove-S3Bucket -Force -DeleteBucketContent
        }

        It "Can download to a folder hierarchy" {
            Read-S3Object -BucketName $script:bucketName -KeyPrefix bar2v5 -Folder temp\new-bar-v5-noslash

            (Get-Content ".\temp\new-bar-v5-noslash\foo.txt").Length | Should -BeGreaterThan 0
            (Get-Content ".\temp\new-bar-v5-noslash\test.txt").Length | Should -BeGreaterThan 0
            (Get-Content ".\temp\new-bar-v5-noslash\test2.txt").Length | Should -BeGreaterThan 0
            (Get-Content ".\temp\new-bar-v5-noslash\baz\blah.txt").Length | Should -BeGreaterThan 0
        }

        It "Can download to a folder hierarchy when Keyprefix ends with forward slash" {
            Read-S3Object -BucketName $script:bucketName -KeyPrefix bar2v5/ -Folder temp\new-bar-v5-forwardslash

            (Get-Content ".\temp\new-bar-v5-forwardslash\foo.txt").Length | Should -BeGreaterThan 0
            (Get-Content ".\temp\new-bar-v5-forwardslash\test.txt").Length | Should -BeGreaterThan 0
            (Get-Content ".\temp\new-bar-v5-forwardslash\test2.txt").Length | Should -BeGreaterThan 0
            (Get-Content ".\temp\new-bar-v5-forwardslash\baz\blah.txt").Length | Should -BeGreaterThan 0
        }

        It "Can download to a folder hierarchy when Keyprefix ends with backslash" {
            Read-S3Object -BucketName $script:bucketName -KeyPrefix bar2v5backslash\ -Folder temp\new-bar-v5-backslash

            (Get-Content ".\temp\new-bar-v5-backslash\test.txt").Length | Should -BeGreaterThan 0
            (Get-Content ".\temp\new-bar-v5-backslash\test2.txt").Length | Should -BeGreaterThan 0
            (Get-Content ".\temp\new-bar-v5-backslash\baz\blah.txt").Length | Should -BeGreaterThan 0
        }

        It "Can download to a folder hierarchy when EnableLegacyKeyCleaning is set" {
            Read-S3Object -BucketName $script:bucketName -KeyPrefix bar2\ -Folder temp\new-bar -EnableLegacyKeyCleaning

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

        It "Can download to a folder hierarchy with partial KeyPrefix and DisableSlashCorrection enabled" {
            Read-S3Object -BucketName $script:bucketName -KeyPrefix 'ba' -Folder temp\new-bar-disableslashcorrection -DisableSlashCorrection $true

            (Get-Content ".\temp\new-bar-disableslashcorrection\basic.txt").Length | Should -BeGreaterThan 0
            (Get-Content ".\temp\new-bar-disableslashcorrection\bar2\foo.txt").Length | Should -BeGreaterThan 0
            (Get-Content ".\temp\new-bar-disableslashcorrection\bar2\test.txt").Length | Should -BeGreaterThan 0
            (Get-Content ".\temp\new-bar-disableslashcorrection\bar2\test2.txt").Length | Should -BeGreaterThan 0
            (Get-Content ".\temp\new-bar-disableslashcorrection\bar2\baz\blah.txt").Length | Should -BeGreaterThan 0
        }

        It "Can copy an object to a local file" {
            Copy-S3Object -BucketName $script:bucketName -Key "basic.txt" -LocalFile "$pwd\temp\blah.blah"
            (Get-Content "$pwd\temp\blah.blah").Length | Should -BeGreaterThan 0
        }

        It "Can read an object into a local file" {
            Read-S3Object -BucketName $script:bucketName -Key "basic.txt" -File "temp\basic2.txt"
            (Get-Content "temp\basic2.txt").Length | Should -BeGreaterThan 0
        }

        It "Can retrieve a specific version using the VersionId parameter" {
            $versionId = $s3ObjectVersions.Versions[0].VersionId
            Read-S3Object -BucketName $script:bucketName -Key $key -VersionId $versionId -File "temp\version-test.txt"
            (Get-Content "temp\version-test.txt") | Should -Be "Version 2"
        }
        It "Can retrieve a specific version using the Version alias" {
            $versionId = $s3ObjectVersions.Versions[1].VersionId
            Read-S3Object -BucketName $script:bucketName -Key $key -Version $versionId -File "temp\version-test.txt"
            (Get-Content "temp\version-test.txt") | Should -Be "Version 1"  
        }
        It "Can retrieve a key with leading backslash" {
            (Get-S3Object -BucketName $script:bucketName -Key '\leading-backslash.txt').Key | Should -BeExactly '\leading-backslash.txt'
        }
        It "Leading backslash is cleaned with EnableLegacyCleanKey" {
            (Get-S3Object -BucketName $script:bucketName -Key '\leading-backslash-with-keycleaning.txt' -EnableLegacyKeyCleaning).Key | Should -BeExactly 'leading-backslash-with-keycleaning.txt'
        }
    }

    Context "Copying" {

        BeforeEach {
            $content = [DateTime]::Now.ToFileTime()
            $bucketName = "pstest-" + $content
            $eastBucketName = $bucketName + "east"
            New-S3Bucket -BucketName $eastBucketName -Region us-east-1
            
            $westBucketName = $bucketName + "west"
            New-S3Bucket -BucketName $westBucketName -Region us-west-1

            Write-S3Object -BucketName $eastBucketName -Key key -Content $content -region us-east-1

            Write-S3Object -BucketName $eastBucketName -Key '\leading-backslash.txt' -Content $content -region us-east-1
        }

        AfterEach {
            $eastBucketName | Remove-S3Bucket -Force -DeleteBucketContent
            $westBucketName | Remove-S3Bucket -Region us-west-1 -Force -DeleteBucketContent
        }

        It "Can copy cross-region with SourceRegion Parameter"{
            Copy-S3Object -BucketName $eastBucketName -Key key -SourceRegion us-east-1 -DestinationBucket $westBucketName -DestinationKey key -Region us-west-1

            Read-S3Object -BucketName $westBucketName -Key key -File "temp\cross-region-copy.txt" -Region us-west-1
            (Get-Content "temp\cross-region-copy.txt") | Should -Be $content
        }

        It "Can copy with /-prefixed keys when EnableLegacyKeyCleaning is set" {
            $prefixedKey = "/key"
            # this triggered exception before fix: https://github.com/aws/aws-sdk-net/issues/833
            Copy-S3Object -BucketName $eastBucketName -Key $prefixedKey -DestinationKey "/data/keycopy" -Region us-east-1 -EnableLegacyKeyCleaning
        }

        It "Can copy with key with leading backslash" {
            $prefixedKey = '\leading-backslash.txt'
            Copy-S3Object -BucketName $eastBucketName -Key $prefixedKey -DestinationKey "\destkeycopyleadingbackslash" -Region us-east-1
        }

        It "Can copy S3 object to S3 with TagSet parameter" -Skip {
            Copy-S3Object -BucketName $eastBucketName -Key key -DestinationBucket $eastBucketName -DestinationKey "key-copy-tagset" -Region us-east-1 -TagSet @{Key='testtag';Value='testvalue'}

            $tagCollection = Get-S3ObjectTagSet -BucketName $eastBucketName -Key "key-copy-tagset"
            $tagCollection | Should -HaveCount 1
            ($tagCollection[0].Key) | Should -Be "testtag"
            ($tagCollection[0].Value) | Should -Be "testvalue"
        }
        It "Can copy with ExpectedBucketOwner parameter" {
            $accountId = (Get-STSCallerIdentity).Account
            Copy-S3Object -BucketName $eastBucketName -Key key -SourceRegion us-east-1 -DestinationBucket $westBucketName -DestinationKey "key-copy-owner" -Region us-west-1 -ExpectedBucketOwner $accountId
            Read-S3Object -BucketName $westBucketName -Key "key-copy-owner" -File "temp\owner-copy.txt" -Region us-west-1
            (Get-Content "temp\owner-copy.txt") | Should -Be $content

            $incorrectAccountId = "000000000000"
            { Copy-S3Object -BucketName $eastBucketName -Key key -SourceRegion us-east-1 -DestinationBucket $westBucketName -DestinationKey "key-copy-owner-fail" -Region us-west-1 -ExpectedBucketOwner $incorrectAccountId } | Should -Throw 
        }
    }

    Context "Checksums" {

        BeforeAll {
            $script:bucketName = "pstest-" + [DateTime]::Now.ToFileTime()
            New-S3Bucket -BucketName $script:bucketName
        }

        AfterAll {
            $script:bucketName | Remove-S3Bucket -Force -DeleteBucketContent
        }

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

        It "Can copy an object with a checksum" {
            Write-S3Object -BucketName $script:bucketName -Key "source" -Content "this is a test" -ChecksumAlgorithm SHA256
            Copy-S3Object -BucketName $script:bucketName -Key "source" -DestinationBucket $script -DestinationKey "dest" -ChecksumAlgorithm SHA256
            Get-S3ObjectAttribute -BucketName $script:bucketName -Key "dest" -ObjectAttributes Checksum | Select-Object -ExpandProperty Checksum | Should -Not -BeNullOrEmpty
        }

        It "Can delete objects with a checksum" {
            Write-S3Object -BucketName $script:bucketName -Key "key1" -Content "this is a test"
            Write-S3Object -BucketName $script:bucketName -Key "key2" -Content "this is a test"

            Remove-S3Object -BucketName $script:bucketName -KeyCollection @( "key1", "key2" ) -ChecksumAlgorithm SHA256 -Force

            { Read-S3Object -BucketName $script:bucketName -Key "key1" -File "temp\key1.txt" } | Should -Throw
            { Read-S3Object -BucketName $script:bucketName -Key "key2" -File "temp\key2.txt" } | Should -Throw
        }
    }
}