Describe -Tag "Smoke" "S3" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Buckets" {

        It "Can list buckets" {
            $buckets = Get-S3Bucket
            if ($buckets) {
                $buckets.Count | Should BeGreaterThan 0
            }
        }

        $script:bucketName = "PSTest-" + [DateTime]::Now.ToFileTime()

        It "Can create a bucket" {
            New-S3Bucket -BucketName $script:bucketName
        
            Test-S3Bucket $script:bucketName | Should Be $true
        }

        It "Can delete buckets" {
        	# continual eventual consistency issues with testing bucket no longer exists,
	        # (even after various sleeps) so stopped verifying
            $script:bucketName | Remove-S3Bucket -Force
        }
    }

    Context "Writing" {

        BeforeAll {
            $script:bucketName = "PSTest-" + [DateTime]::Now.ToFileTime()
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
            } | Should Throw
        }
    }

    Context "Reading" {
     
        BeforeAll {
            $script:bucketName = "PSTest-" + [DateTime]::Now.ToFileTime()
            New-S3Bucket -BucketName $script:bucketName
            
            $void = New-Item -Path temp\bar -Type directory -Force
            $void = New-Item -Path temp\bar\baz -Type directory -Force
            
            "sample text" | Out-File -FilePath ".\temp\bar\test.txt" -Force
            "more sample text" | Out-File -FilePath ".\temp\bar\test2.txt" -Force
            "another file" | Out-File -FilePath ".\temp\bar\baz\blah.txt" -Force
            "basic file" | Out-File -FilePath "temp\basic.txt" -Force

            Write-S3Object -BucketName $script:bucketName -KeyPrefix bar2\ -Folder .\temp\bar -Recurse
            Write-S3Object -BucketName $script:bucketName -Key bar2\foo.txt -Content "foo"
            Write-S3Object -BucketName $script:bucketName -Key basic.txt -File "temp\basic.txt"
        }

        AfterAll {
            $script:bucketName | Remove-S3Bucket -Force -DeleteBucketContent
        }

        It "Can download to a folder hierarchy" {
            Read-S3Object -BucketName $script:bucketName -KeyPrefix bar2\ -Folder temp\new-bar

            (Get-Content ".\temp\new-bar\foo.txt").Length | Should BeGreaterThan 0
            (Get-Content ".\temp\new-bar\test.txt").Length | Should BeGreaterThan 0
            (Get-Content ".\temp\new-bar\test2.txt").Length | Should BeGreaterThan 0
            (Get-Content ".\temp\new-bar\baz\blah.txt").Length | Should BeGreaterThan 0
        }

        It "Can copy an object to a local file" {
            Copy-S3Object -BucketName $script:bucketName -Key "basic.txt" -LocalFile "$pwd\temp\blah.blah"
            (Get-Content "$pwd\temp\blah.blah").Length | Should BeGreaterThan 0
        }

        It "Can read an object into a local file" {
            Read-S3Object -BucketName $script:bucketName -Key "basic.txt" -File "temp\basic2.txt"
            (Get-Content "temp\basic2.txt").Length | Should BeGreaterThan 0
        }
    }
}