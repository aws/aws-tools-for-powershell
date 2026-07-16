BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    $helper = New-Object ServiceTestHelper
    $helper.BeforeAll()
}

AfterAll {
    $helper.AfterAll()
}

Describe -Tag "Smoke" "S3 Multipart Download" {

    # Shared bucket for all multipart download tests to minimize bucket creation overhead
    BeforeAll {
        $script:bucketName = "pstest-mp-" + [DateTime]::Now.ToFileTime()
        New-S3Bucket -BucketName $script:bucketName

        New-Item -Path temp\mp -Type directory -Force

        # Upload a small file (single PUT)
        "sample text content for testing multipart download" | Out-File -FilePath "temp\mp\small.txt" -Force
        Write-S3Object -BucketName $script:bucketName -Key "mp/small.txt" -File "temp\mp\small.txt"

        # Upload a 24MB file with multipart (8MB parts = 3 parts)
        $buffer = New-Object byte[] (24MB)
        [System.Security.Cryptography.RandomNumberGenerator]::Create().GetBytes($buffer)
        [System.IO.File]::WriteAllBytes("$pwd\temp\mp\large.bin", $buffer)
        Write-S3Object -BucketName $script:bucketName -Key "mp/large.bin" -File "temp\mp\large.bin" -PartSize 8MB

        # Upload an empty file
        New-Item -ItemType File -Path "temp\mp\empty.txt" -Force
        Write-S3Object -BucketName $script:bucketName -Key "mp/empty.txt" -File "temp\mp\empty.txt"

        # Upload multiple files for directory download tests
        1..5 | ForEach-Object {
            Write-S3Object -BucketName $script:bucketName -Key "testdir/file$_.txt" -Content "Content for file $_ - padding data"
        }
    }

    AfterAll {
        $script:bucketName | Remove-S3Bucket -Force -DeleteBucketContent
        Remove-Item -Path "temp\mp" -Recurse -Force -ErrorAction SilentlyContinue
    }

    # ==========================================
    # READ-S3OBJECT TESTS
    # ==========================================

    Context "Read-S3Object - Regression (default behavior unchanged)" {

        It "Returns FileInfo for single file without -UseMultipartDownload" {
            $result = Read-S3Object -BucketName $script:bucketName -Key "mp/small.txt" -File "temp\mp\read-reg.txt"
            $result | Should -BeOfType [System.IO.FileInfo]
            $result.Length | Should -BeGreaterThan 0
        }

        It "Returns DirectoryInfo for folder without -UseMultipartDownload" {
            $result = Read-S3Object -BucketName $script:bucketName -KeyPrefix "testdir/" -Folder "temp\mp\read-reg-dir"
            $result | Should -BeOfType [System.IO.DirectoryInfo]
            (Get-ChildItem "temp\mp\read-reg-dir" -Recurse -File).Count | Should -Be 5
        }
    }

    Context "Read-S3Object - Multipart Single File" {

        It "Returns TransferUtilityDownloadResponse with -UseMultipartDownload" {
            $result = Read-S3Object -BucketName $script:bucketName -Key "mp/small.txt" -File "temp\mp\read-mp.txt" -UseMultipartDownload
            $result.GetType().Name | Should -Be "TransferUtilityDownloadResponse"
            $result.ETag | Should -Not -BeNullOrEmpty
            $result.LastModified | Should -Not -BeNullOrEmpty
        }

        It "Downloads 24MB file with RANGE mode, custom PartSize, and verifies integrity" {
            Read-S3Object -BucketName $script:bucketName -Key "mp/large.bin" -File "temp\mp\read-range.bin" `
                -UseMultipartDownload -MultipartDownloadType RANGE -PartSize 4MB
            (Get-FileHash "temp\mp\read-range.bin" -Algorithm MD5).Hash | Should -Be (Get-FileHash "temp\mp\large.bin" -Algorithm MD5).Hash
        }

        It "Downloads empty file (0 bytes) with multipart" {
            $result = Read-S3Object -BucketName $script:bucketName -Key "mp/empty.txt" -File "temp\mp\read-empty.txt" -UseMultipartDownload
            $result.GetType().Name | Should -Be "TransferUtilityDownloadResponse"
            (Get-Item "temp\mp\read-empty.txt").Length | Should -Be 0
        }
    }

    Context "Read-S3Object - Multipart Directory" {

        It "Returns TransferUtilityDownloadDirectoryResponse with -UseMultipartDownload" {
            $result = Read-S3Object -BucketName $script:bucketName -KeyPrefix "testdir/" -Folder "temp\mp\read-mpdir" -UseMultipartDownload
            $result.GetType().Name | Should -Be "TransferUtilityDownloadDirectoryResponse"
            $result.ObjectsDownloaded | Should -Be 5
            $result.ObjectsFailed | Should -Be 0
            $result.Result | Should -Be "Success"
        }

        It "Downloads directory with -DownloadFilesConcurrently and multipart" {
            $result = Read-S3Object -BucketName $script:bucketName -KeyPrefix "testdir/" -Folder "temp\mp\read-concurrent" `
                -UseMultipartDownload -DownloadFilesConcurrently
            $result.ObjectsDownloaded | Should -Be 5
        }

        It "Downloads directory with -DownloadFilesConcurrently without multipart (legacy)" {
            $result = Read-S3Object -BucketName $script:bucketName -KeyPrefix "testdir/" -Folder "temp\mp\read-conc-legacy" `
                -DownloadFilesConcurrently
            $result | Should -BeOfType [System.IO.DirectoryInfo]
        }

        It "Downloads directory with -FailurePolicy ContinueOnFailure" {
            $result = Read-S3Object -BucketName $script:bucketName -KeyPrefix "testdir/" -Folder "temp\mp\read-continue" `
                -UseMultipartDownload -FailurePolicy ContinueOnFailure
            $result.Result | Should -Be "Success"
        }
    }

    Context "Read-S3Object - Piped S3Object" {

        It "Can download piped S3Object with -UseMultipartDownload" {
            $obj = Get-S3Object -BucketName $script:bucketName -Key "mp/small.txt"
            $result = $obj | Read-S3Object -File "temp\mp\read-piped.txt" -UseMultipartDownload
            $result.GetType().Name | Should -Be "TransferUtilityDownloadResponse"
            $result.ETag | Should -Not -BeNullOrEmpty
        }
    }

    Context "Read-S3Object - Validation" {

        It "Throws when -MultipartDownloadType is used without -UseMultipartDownload" {
            { Read-S3Object -BucketName $script:bucketName -Key "mp/small.txt" -File "temp\mp\rerr1.txt" `
                -MultipartDownloadType RANGE } | Should -Throw "*requires -UseMultipartDownload*"
        }

        It "Throws when -PartSize is used without -UseMultipartDownload" {
            { Read-S3Object -BucketName $script:bucketName -Key "mp/small.txt" -File "temp\mp\rerr2.txt" `
                -PartSize 8MB } | Should -Throw "*requires -UseMultipartDownload*"
        }

        It "Throws when -ConcurrentServiceRequest is used without -UseMultipartDownload" {
            { Read-S3Object -BucketName $script:bucketName -Key "mp/small.txt" -File "temp\mp\rerr3.txt" `
                -ConcurrentServiceRequest 20 } | Should -Throw "*requires -UseMultipartDownload*"
        }

        It "Throws when -ConcurrentServiceRequest is 0" {
            { Read-S3Object -BucketName $script:bucketName -Key "mp/small.txt" -File "temp\mp\rerr4.txt" `
                -UseMultipartDownload -ConcurrentServiceRequest 0 } | Should -Throw
        }

        It "Does NOT throw when -DownloadFilesConcurrently is used without -UseMultipartDownload" {
            { Read-S3Object -BucketName $script:bucketName -KeyPrefix "testdir/" -Folder "temp\mp\rno-throw" `
                -DownloadFilesConcurrently } | Should -Not -Throw
        }

        It "Does NOT throw when -FailurePolicy is used without -UseMultipartDownload" {
            { Read-S3Object -BucketName $script:bucketName -KeyPrefix "testdir/" -Folder "temp\mp\rno-throw2" `
                -FailurePolicy ContinueOnFailure } | Should -Not -Throw
        }
    }

    # ==========================================
    # COPY-S3OBJECT TESTS
    # ==========================================

    Context "Copy-S3Object - Regression (default behavior unchanged)" {

        It "Returns FileInfo for single file without -UseMultipartDownload" {
            $result = Copy-S3Object -BucketName $script:bucketName -Key "mp/small.txt" -LocalFile "temp\mp\copy-reg.txt"
            $result | Should -BeOfType [System.IO.FileInfo]
            $result.Length | Should -BeGreaterThan 0
        }

        It "Returns DirectoryInfo for folder without -UseMultipartDownload" {
            $result = Copy-S3Object -BucketName $script:bucketName -KeyPrefix "testdir/" -LocalFolder "temp\mp\copy-reg-dir"
            $result | Should -BeOfType [System.IO.DirectoryInfo]
            (Get-ChildItem "temp\mp\copy-reg-dir" -Recurse -File).Count | Should -Be 5
        }

        It "S3-to-S3 copy works without multipart download params" {
            Copy-S3Object -BucketName $script:bucketName -Key "mp/small.txt" -DestinationKey "mp/copy-s3dest.txt"
            $obj = Get-S3Object -BucketName $script:bucketName -Key "mp/copy-s3dest.txt"
            $obj | Should -Not -BeNullOrEmpty
        }
    }

    Context "Copy-S3Object - Multipart Single File" {

        It "Returns TransferUtilityDownloadResponse with -UseMultipartDownload" {
            $result = Copy-S3Object -BucketName $script:bucketName -Key "mp/small.txt" -LocalFile "temp\mp\copy-mp.txt" -UseMultipartDownload
            $result.GetType().Name | Should -Be "TransferUtilityDownloadResponse"
            $result.ETag | Should -Not -BeNullOrEmpty
            $result.LastModified | Should -Not -BeNullOrEmpty
        }

        It "Downloads 24MB file with RANGE mode, custom PartSize, and verifies integrity" {
            Copy-S3Object -BucketName $script:bucketName -Key "mp/large.bin" -LocalFile "temp\mp\copy-range.bin" `
                -UseMultipartDownload -MultipartDownloadType RANGE -PartSize 4MB
            (Get-FileHash "temp\mp\copy-range.bin" -Algorithm MD5).Hash | Should -Be (Get-FileHash "temp\mp\large.bin" -Algorithm MD5).Hash
        }
    }

    Context "Copy-S3Object - Multipart Directory" {

        It "Returns TransferUtilityDownloadDirectoryResponse with -UseMultipartDownload" {
            $result = Copy-S3Object -BucketName $script:bucketName -KeyPrefix "testdir/" -LocalFolder "temp\mp\copy-mpdir" -UseMultipartDownload
            $result.GetType().Name | Should -Be "TransferUtilityDownloadDirectoryResponse"
            $result.ObjectsDownloaded | Should -Be 5
            $result.ObjectsFailed | Should -Be 0
            $result.Result | Should -Be "Success"
        }

        It "Downloads directory with -DownloadFilesConcurrently and multipart" {
            $result = Copy-S3Object -BucketName $script:bucketName -KeyPrefix "testdir/" -LocalFolder "temp\mp\copy-concurrent" `
                -UseMultipartDownload -DownloadFilesConcurrently
            $result.ObjectsDownloaded | Should -Be 5
        }
    }

    Context "Copy-S3Object - Validation" {

        It "Throws when -MultipartDownloadType is used without -UseMultipartDownload" {
            { Copy-S3Object -BucketName $script:bucketName -Key "mp/small.txt" -LocalFile "temp\mp\cerr1.txt" `
                -MultipartDownloadType RANGE } | Should -Throw "*requires -UseMultipartDownload*"
        }

        It "Throws when -PartSize is used without -UseMultipartDownload" {
            { Copy-S3Object -BucketName $script:bucketName -Key "mp/small.txt" -LocalFile "temp\mp\cerr2.txt" `
                -PartSize 8MB } | Should -Throw "*requires -UseMultipartDownload*"
        }

        It "Throws when -ConcurrentServiceRequest is used without -UseMultipartDownload" {
            { Copy-S3Object -BucketName $script:bucketName -Key "mp/small.txt" -LocalFile "temp\mp\cerr3.txt" `
                -ConcurrentServiceRequest 20 } | Should -Throw "*requires -UseMultipartDownload*"
        }

        It "Throws when -ConcurrentServiceRequest is 0" {
            { Copy-S3Object -BucketName $script:bucketName -Key "mp/small.txt" -LocalFile "temp\mp\cerr4.txt" `
                -UseMultipartDownload -ConcurrentServiceRequest 0 } | Should -Throw
        }

        It "Does NOT throw when -DownloadFilesConcurrently is used without -UseMultipartDownload" {
            { Copy-S3Object -BucketName $script:bucketName -KeyPrefix "testdir/" -LocalFolder "temp\mp\cno-throw" `
                -DownloadFilesConcurrently } | Should -Not -Throw
        }

        It "Does NOT throw when -FailurePolicy is used without -UseMultipartDownload" {
            { Copy-S3Object -BucketName $script:bucketName -KeyPrefix "testdir/" -LocalFolder "temp\mp\cno-throw2" `
                -FailurePolicy ContinueOnFailure } | Should -Not -Throw
        }
    }

    # ==========================================
    # PARAMETER SET VERIFICATION (no S3 calls)
    # ==========================================

    Context "Parameter Set Verification" {

        It "UseMultipartDownload is in all Read-S3Object download parameter sets" {
            $paramSets = (Get-Command Read-S3Object).ParameterSets
            foreach ($set in $paramSets) {
                $param = $set.Parameters | Where-Object { $_.Name -eq 'UseMultipartDownload' }
                $param | Should -Not -BeNullOrEmpty -Because "UseMultipartDownload should be in '$($set.Name)'"
            }
        }

        It "MultipartDownloadType is NOT in DownloadFolder parameter set" {
            $folderSet = (Get-Command Read-S3Object).ParameterSets | Where-Object { $_.Name -eq 'DownloadFolder' }
            $param = $folderSet.Parameters | Where-Object { $_.Name -eq 'MultipartDownloadType' }
            $param | Should -BeNullOrEmpty
        }

        It "DownloadFilesConcurrently is NOT in DownloadFile parameter set" {
            $fileSet = (Get-Command Read-S3Object).ParameterSets | Where-Object { $_.Name -eq 'DownloadFile' }
            $param = $fileSet.Parameters | Where-Object { $_.Name -eq 'DownloadFilesConcurrently' }
            $param | Should -BeNullOrEmpty
        }

        It "UseMultipartDownload is NOT in CopyS3ObjectToS3Object parameter set" {
            $s3ToS3 = (Get-Command Copy-S3Object).ParameterSets | Where-Object { $_.Name -eq 'CopyS3ObjectToS3Object' }
            $param = $s3ToS3.Parameters | Where-Object { $_.Name -eq 'UseMultipartDownload' }
            $param | Should -BeNullOrEmpty
        }
    }
}
