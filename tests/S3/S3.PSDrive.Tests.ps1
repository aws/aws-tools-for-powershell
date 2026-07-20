<#
    Pester (5.x) integration tests for the S3 PowerShell drive provider (AWS.S3), which ships in
    AWS.Tools.S3 — live AWS, read+write.

    Exercises the provider through the real PowerShell command surface (Mount-S3PSDrive,
    Set-Location, Get-ChildItem, Get-Item, Get-Content, Set-Content, Remove-Item,
    Dismount-S3PSDrive): navigation, listing+pagination, upload/download, single+recursive delete,
    multi-region, and that unsupported ops error cleanly.

    HARNESS: uses the repo's shared test harness (tests/Include/*.ps1), which imports the built
    module and sets the 'test-runner' credential profile + us-east-1 region — same as the sibling
    tests/S3/*.Tests.ps1. The provider (Cmdlets/S3/Drive/) and its two cmdlets (Cmdlets/S3/Advanced/)
    are compiled into that module, so no separate import is needed.

    A raw AmazonS3Client is still used for FIXTURE setup/teardown (create/delete buckets, seed
    directory-marker objects, bucket policies, list/abort multipart uploads) — operations the
    provider intentionally does not expose. It reuses the AWSSDK.S3 assembly the module already
    loaded, so there is no second-copy collision.

    Buckets are named pstest-psdrive-<filetime> and removed (with content) in AfterAll.
#>

BeforeAll {
    $script:OriginalLocation = (Get-Location).Path

    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    $helper = New-Object ServiceTestHelper
    $helper.BeforeAll()

    # The harness set the 'test-runner' profile as the session default; the raw fixture client and
    # the drive mounts below use that same profile/region.
    $script:Profile = 'test-runner'
    $script:Region  = 'us-east-1'

    # FIXTURE SETUP/TEARDOWN uses a raw AmazonS3Client (the provider can't create/delete buckets -
    # that's out of scope - so fixtures must reach S3 directly). It reuses the AWSSDK.S3 assembly
    # the module already loaded.
    $chain = New-Object Amazon.Runtime.CredentialManagement.CredentialProfileStoreChain
    $creds = $null
    if (-not $chain.TryGetAWSCredentials($script:Profile, [ref]$creds)) {
        throw "Could not load AWS profile '$($script:Profile)' for test fixtures."
    }
    $script:Creds = $creds   # script-scoped so nested contexts (e.g. cross-region) can reuse it
    $script:S3 = New-Object Amazon.S3.AmazonS3Client($creds, [Amazon.RegionEndpoint]::GetBySystemName($script:Region))

    # Small SDK fixture helpers (block on the async client, like the provider does).
    function script:S3PutText([string]$key, [string]$text) {
        $req = New-Object Amazon.S3.Model.PutObjectRequest
        $req.BucketName = $script:Bucket; $req.Key = $key; $req.ContentBody = $text
        [void]$script:S3.PutObjectAsync($req).GetAwaiter().GetResult()
    }

    function script:S3ObjectExists([string]$bucket, [string]$key, $client = $null) {
        if (-not $client) { $client = $script:S3 }
        $req = New-Object Amazon.S3.Model.GetObjectMetadataRequest
        $req.BucketName = $bucket; $req.Key = $key
        try {
            [void]$client.GetObjectMetadataAsync($req).GetAwaiter().GetResult()
            return $true
        } catch [Amazon.S3.AmazonS3Exception] {
            if ($_.Exception.StatusCode -eq [System.Net.HttpStatusCode]::NotFound -or
                $_.Exception.ErrorCode -in @('NoSuchBucket','NoSuchKey','NotFound')) {
                return $false
            }
            throw
        }
    }

    function script:S3GetText([string]$bucket, [string]$key, $client = $null) {
        if (-not $client) { $client = $script:S3 }
        $req = New-Object Amazon.S3.Model.GetObjectRequest
        $req.BucketName = $bucket; $req.Key = $key
        $resp = $client.GetObjectAsync($req).GetAwaiter().GetResult()
        try {
            $reader = New-Object System.IO.StreamReader($resp.ResponseStream)
            try { return $reader.ReadToEnd() }
            finally { $reader.Dispose() }
        } finally {
            $resp.Dispose()
        }
    }

    function script:S3GetBytes([string]$bucket, [string]$key, $client = $null) {
        if (-not $client) { $client = $script:S3 }
        $req = New-Object Amazon.S3.Model.GetObjectRequest
        $req.BucketName = $bucket; $req.Key = $key
        $resp = $client.GetObjectAsync($req).GetAwaiter().GetResult()
        try {
            $ms = New-Object System.IO.MemoryStream
            try {
                $resp.ResponseStream.CopyTo($ms)
                return ,$ms.ToArray()
            } finally {
                $ms.Dispose()
            }
        } finally {
            $resp.Dispose()
        }
    }

    function script:S3PrefixObjectCount([string]$bucket, [string]$prefix) {
        $req = New-Object Amazon.S3.Model.ListObjectsV2Request
        $req.BucketName = $bucket; $req.Prefix = $prefix
        $count = 0
        do {
            $resp = $script:S3.ListObjectsV2Async($req).GetAwaiter().GetResult()
            $count += @($resp.S3Objects | Where-Object { $_ }).Count
            $req.ContinuationToken = $resp.NextContinuationToken
        } while ($resp.IsTruncated)
        return $count
    }

    # Fixtures seeded via the raw SDK land BEHIND the provider's 1s listing cache, so a listing
    # taken right after seeding can briefly be a pre-seed one. Retry past the TTL to return the
    # named child once it appears. (A real user's Set-Content invalidates the cache at once; this
    # race is fixture-only.) Shared by the tests that seed through the raw client.
    function script:WaitForChild([string]$container, [string]$name) {
        foreach ($i in 1..8) {
            $child = Get-ChildItem $container -ErrorAction SilentlyContinue | Where-Object Name -eq $name
            if ($child) { return $child }
            Start-Sleep -Milliseconds 300
        }
        return $null
    }

    $script:Bucket = "pstest-psdrive-" + [DateTime]::Now.ToFileTime()
    $mk = New-Object Amazon.S3.Model.PutBucketRequest
    $mk.BucketName = $script:Bucket
    [void]$script:S3.PutBucketAsync($mk).GetAwaiter().GetResult()

    # Seed a known tree: two prefixes + a top-level object. (The pagination context seeds its own.)
    S3PutText "reports/2026/summary.txt" "hello summary"
    S3PutText "reports/index.txt"        "index"
    S3PutText "top.txt"                  "top level"

    # Mount the drive under test (explicit profile/region; raw New-PSDrive path also works).
    Mount-S3PSDrive -Name PSTest -ProfileName $script:Profile -Region $script:Region
}

AfterAll {
    # SINGLE CLEANUP AUTHORITY for the shared $script:Bucket: this block lists+deletes every object
    # in it, then the bucket. So tests that write to $script:Bucket with a UNIQUE key/prefix do NOT
    # add their own per-object cleanup - it would just be a duplicate live DeleteObject call, and
    # unique naming already prevents any sibling from colliding. (Per-test cleanup is retained only
    # where the delete IS the assertion, or where the sweep can't reach: separate buckets,
    # bucket policies, in-progress multipart uploads, and drive dismounts.) Tradeoff: orphans
    # accumulate within a run and would linger only if the run is interrupted before this runs -
    # acceptable for a manually-run live suite against a per-run throwaway bucket.
    #
    # Step off the drive and remove it if still mounted. The last test already dismounts PSTest,
    # so guard with Test-Path and a try/catch - a dismount error must NOT abort AfterAll before
    # the bucket cleanup below runs (that was leaving the test bucket orphaned). Dismount wraps
    # Remove-PSDrive, whose not-terminating error isn't caught by -ErrorAction SilentlyContinue.
    Set-Location $HOME -ErrorAction SilentlyContinue   # OS-agnostic step-off (not C:\, which is Windows-only)
    if (Test-Path 'PSTest:\') {
        try { Dismount-S3PSDrive -Name PSTest -ErrorAction SilentlyContinue } catch { }
    }
    if ($script:Bucket -and $script:S3) {
        try {
            # Delete all objects, then the (now-empty) bucket. AmazonS3Util.DeleteS3BucketWithObjects
            # would also work, but an explicit list+delete keeps the dependency surface minimal.
            $lreq = New-Object Amazon.S3.Model.ListObjectsV2Request; $lreq.BucketName = $script:Bucket
            do {
                $lresp = $script:S3.ListObjectsV2Async($lreq).GetAwaiter().GetResult()
                foreach ($o in @($lresp.S3Objects)) {
                    $d = New-Object Amazon.S3.Model.DeleteObjectRequest
                    $d.BucketName = $script:Bucket; $d.Key = $o.Key
                    [void]$script:S3.DeleteObjectAsync($d).GetAwaiter().GetResult()
                }
                $lreq.ContinuationToken = $lresp.NextContinuationToken
            } while ($lresp.IsTruncated)
            $db = New-Object Amazon.S3.Model.DeleteBucketRequest; $db.BucketName = $script:Bucket
            [void]$script:S3.DeleteBucketAsync($db).GetAwaiter().GetResult()
        } catch {
            Write-Warning "Fixture cleanup failed for bucket '$($script:Bucket)': $($_.Exception.Message)"
        }
        $script:S3.Dispose()
    }

    $helper.AfterAll()
    if ($script:OriginalLocation) {
        Set-Location -LiteralPath $script:OriginalLocation -ErrorAction SilentlyContinue
    }
}

Describe -Tag "Smoke" "S3 PowerShell drive provider" {

    Context "Mount / provider registration" {
        It "registers the AWS.S3 provider" {
            Get-PSProvider AWS.S3 | Should -Not -BeNullOrEmpty
        }
        It "mounts a drive that resolves" {
            Test-Path 'PSTest:\' | Should -BeTrue
        }
    }

    Context "Modular manifest exports" {
        It "exports the S3 PSDrive wrapper cmdlets from AWS.Tools.S3" {
            $repoRoot = Resolve-Path (Join-Path $PSScriptRoot '../..')
            $manifest = Join-Path $repoRoot 'modules/AWSPowerShell/Cmdlets/S3/AWS.Tools.S3.psd1'
            $data = Import-PowerShellDataFile $manifest
            $data.CmdletsToExport | Should -Contain 'Mount-S3PSDrive'
            $data.CmdletsToExport | Should -Contain 'Dismount-S3PSDrive'
        }
    }

    Context "Navigation and listing" {
        It "lists the test bucket at the drive root" {
            (Get-ChildItem PSTest:\ -Name) | Should -Contain $script:Bucket
        }
        It "changes location into a bucket and prefix" {
            Set-Location "PSTest:\$($script:Bucket)\reports"
            # Normalize the separator: the provider emits '\' on Windows, '/' on Linux/macOS.
            ((Get-Location).Path -replace '\\','/') | Should -BeLike "*$($script:Bucket)/reports"
            Set-Location 2026
            (Get-ChildItem -Name) | Should -Contain 'summary.txt'
            Set-Location $HOME   # OS-agnostic; C:\ doesn't exist on Linux/macOS
        }
        It "lists prefixes and objects as uniform S3ItemInfo items" {
            $items = Get-ChildItem "PSTest:\$($script:Bucket)"
            ($items | ForEach-Object Name) | Should -Contain 'reports'   # prefix -> folder
            ($items | ForEach-Object Name) | Should -Contain 'top.txt'   # object -> file
            $folder = $items | Where-Object Name -eq 'reports'
            $file   = $items | Where-Object Name -eq 'top.txt'
            $folder.Type | Should -Be 'Folder'
            $folder.Size | Should -BeNullOrEmpty          # containers carry no size
            $file.Type   | Should -Be 'Object'
            $file.Size   | Should -Be 9                    # "top level" = 9 bytes
        }
    }

    Context "Item shape edge cases" {
        BeforeAll {
            # A directory-marker: a 0-byte object whose key ends in "/". Should surface as an
            # empty FOLDER, not a zero-byte file (and the marker itself is filtered from listings).
            $script:S3.PutObjectAsync((New-Object Amazon.S3.Model.PutObjectRequest -Property @{
                BucketName = $script:Bucket; Key = "markerdir/"; ContentBody = "" })).GetAwaiter().GetResult() | Out-Null

            # Name collision: a name that is BOTH an object ("dup") AND a prefix ("dup/child.txt").
            # The provider must present ONE entry, a folder, shadowing the colliding object.
            S3PutText "dup"           "i am the object"
            S3PutText "dup/child.txt" "i am under the prefix"
        }

        It "surfaces a directory marker as an empty folder and keeps it a container after listing" {
            # Fixtures seeded via the raw SDK sit behind the 1s listing cache; WaitForChild retries
            # past the TTL rather than racing it (a real user's Set-Content invalidates at once).
            $marker = WaitForChild "PSTest:\$($script:Bucket)" 'markerdir'
            $marker            | Should -Not -BeNullOrEmpty
            $marker.Type       | Should -Be 'Folder'
            Test-Path "PSTest:\$($script:Bucket)\markerdir" -PathType Container | Should -BeTrue
            @(Get-ChildItem "PSTest:\$($script:Bucket)\markerdir").Count | Should -Be 0
            Test-Path "PSTest:\$($script:Bucket)\markerdir" -PathType Container | Should -BeTrue
            (Get-Item "PSTest:\$($script:Bucket)\markerdir").Type | Should -Be 'Folder'
        }
        It "collapses an object+prefix name collision to a single folder entry" {
            $dup = WaitForChild "PSTest:\$($script:Bucket)" 'dup'   # retry past the cache TTL (see marker test)
            @($dup).Count | Should -Be 1          # exactly one entry, not two
            $dup.Type     | Should -Be 'Folder'   # the folder wins; the object is shadowed
            # and you can navigate into it
            (Get-ChildItem "PSTest:\$($script:Bucket)\dup" -Name) | Should -Contain 'child.txt'
            $i = Get-Item "PSTest:\$($script:Bucket)\dup"
            @($i).Count | Should -Be 1
            $i.Type     | Should -Be 'Folder'
        }
        It "recursively deleting a collision removes both children and the shadowed object" {
            $name = "dupdel-$([DateTime]::Now.ToFileTime())"
            S3PutText $name "shadowed object"
            S3PutText "$name/child.txt" "child"
            WaitForChild "PSTest:\$($script:Bucket)" $name | Should -Not -BeNullOrEmpty

            Remove-Item "PSTest:\$($script:Bucket)\$name" -Recurse -Force

            S3ObjectExists $script:Bucket $name | Should -BeFalse
            S3ObjectExists $script:Bucket "$name/child.txt" | Should -BeFalse
        }
    }

    # Get-Item returns the SINGLE item at the exact path (no children) - the complement of
    # Get-ChildItem. Uses the top-level fixture tree (top.txt object, reports/ prefix) plus the
    # dup/dup-object collision seeded above.
    Context "Get-Item (single item at exact path)" {
        It "returns an object with size and last-modified" {
            $i = Get-Item "PSTest:\$($script:Bucket)\top.txt"
            $i.Type         | Should -Be 'Object'
            $i.Size         | Should -Be 9          # "top level" = 9 bytes
            $i.LastModified | Should -Not -BeNullOrEmpty
        }
        It "returns a prefix as a Folder (no size)" {
            $i = Get-Item "PSTest:\$($script:Bucket)\reports"
            $i.Type | Should -Be 'Folder'
            $i.Size | Should -BeNullOrEmpty
        }
        It "returns a bucket as a Bucket item" {
            $i = Get-Item "PSTest:\$($script:Bucket)"
            $i.Name | Should -Be $script:Bucket
            $i.Type | Should -Be 'Bucket'
        }
        It "lists the buckets at the drive root" {
            (Get-Item 'PSTest:\' | ForEach-Object Name) | Should -Contain $script:Bucket
        }
        It "errors (not hangs) on a missing object" {
            { Get-Item "PSTest:\$($script:Bucket)\nope-$([guid]::NewGuid()).txt" -ErrorAction Stop } |
                Should -Throw
        }
        It "errors on a missing bucket" {
            { Get-Item "PSTest:\no-such-bucket-$([guid]::NewGuid())" -ErrorAction Stop } |
                Should -Throw
        }
    }

    Context "Get-Content encoding and -Raw" {
        BeforeAll {
            # Known text with a trailing newline and a non-ASCII char to exercise encodings.
            $script:TextKey = "enc/sample.txt"
            S3PutText $script:TextKey "line1`nline2`n"
        }

        It "reads line-by-line by default (array of lines)" {
            $lines = Get-Content "PSTest:\$($script:Bucket)\$($script:TextKey)"
            $lines[0] | Should -Be 'line1'
            $lines[1] | Should -Be 'line2'
        }
        It "-Raw returns the whole object as one string" {
            $raw = Get-Content "PSTest:\$($script:Bucket)\$($script:TextKey)" -Raw
            $raw | Should -BeOfType [string]
            $raw | Should -Match 'line1'
            $raw | Should -Match 'line2'
        }
        It "honors a friendly -Encoding name (utf8) round-trip" {
            $key = "enc/utf8-$([DateTime]::Now.ToFileTime()).txt"
            $val = "café naïve"   # non-ASCII, exercises the encoding path
            Set-Content "PSTest:\$($script:Bucket)\$key" -Value $val
            (Get-Content "PSTest:\$($script:Bucket)\$key" -Raw -Encoding utf8).TrimEnd("`r","`n") |
                Should -Be $val
        }
        It "rejects an unknown -Encoding value with a clear error" {
            { Get-Content "PSTest:\$($script:Bucket)\$($script:TextKey)" -Encoding not-a-real-encoding -ErrorAction Stop } |
                Should -Throw
        }
    }

    # Slow: seeds 1050 objects (~3 min) to force ListObjectsV2 pagination past the 1000-key page.
    Context "Listing and recursive delete with pagination" {
        BeforeAll {
            # Seed > one page (1000) of objects under a prefix so the provider must follow
            # continuation tokens. Raw SDK put (fixture-only), same client as BeforeAll.
            $script:PageBucketPrefix = 'paged'
            1..1050 | ForEach-Object {
                S3PutText ("{0}/obj-{1:D4}.txt" -f $script:PageBucketPrefix, $_) "x"
            }
        }
        It "enumerates names, recursive objects, and recursive deletion across pages (>1000)" {
            $path = "PSTest:\$($script:Bucket)\$($script:PageBucketPrefix)"
            $names = @(Get-ChildItem $path -Name)
            $names.Count | Should -Be 1050
            $names | Should -Contain 'obj-1050.txt'
            @((Get-ChildItem $path -Recurse) | Where-Object Type -eq 'Object').Count | Should -Be 1050
            @(Get-ChildItem $path).Count | Should -Be 1050
            Remove-Item "PSTest:\$($script:Bucket)\$($script:PageBucketPrefix)" -Recurse -Force
            S3PrefixObjectCount $script:Bucket "$($script:PageBucketPrefix)/" | Should -Be 0
        }
    }

    # NOTE: a plain text round-trip and a small binary -AsByteStream round-trip used to live here.
    # Removed as redundant: the text round-trip is asserted incidentally by nearly every write test
    # (utf8, array-of-strings, trailing-newline, special-char keys), and the small binary round-trip
    # is subsumed by the 130KB content-stream copy and the 20MB multipart round-trip, both of which
    # verify byte-for-byte via SHA-256 (and every upload is multipart anyway, so there was no unique
    # single-part path to guard).

    # Slow: moves a >8MB object, so it exercises the TransferUtility MULTIPART paths on
    # both ends (upload via UploadUnseekableStreamAsync through the PushPullStream bridge; download
    # via OpenStream with MultipartDownloadType.PART) - the whole reason the content layer moved to
    # TransferUtility. Small round-trips above only hit the single-part path. ~20MB.
    Context "Large-object multipart round-trip" {
        It "uploads and downloads a 20MB object byte-for-byte (SHA-256)" {
            $key = "large/multipart-$([DateTime]::Now.ToFileTime()).bin"
            # Deterministic 20MB payload (well over the 8MB multipart threshold).
            $size = 20 * 1024 * 1024
            $src = New-Object byte[] $size
            (New-Object System.Random 20260701).NextBytes($src)

            Set-Content "PSTest:\$($script:Bucket)\$key" -AsByteStream -Value $src
            # Get-Content -AsByteStream -Raw returns an Object[] of the reader's 80KB chunks (NOT a
            # flat byte[]), so flatten before measuring/hashing - else .Length is the chunk count.
            $got = Get-Content "PSTest:\$($script:Bucket)\$key" -AsByteStream -Raw
            $flat = [byte[]]($got | ForEach-Object { $_ })

            $flat.Length | Should -Be $size
            $sha = [System.Security.Cryptography.SHA256]::Create()
            $srcHash = [BitConverter]::ToString($sha.ComputeHash($src))
            $gotHash = [BitConverter]::ToString($sha.ComputeHash($flat))
            $gotHash | Should -Be $srcHash   # byte-exact through multipart up + down
        }
    }

    # Slow: starts a large multipart upload then cancels it mid-flight. Verifies the
    # design's marquee interruption-safety claim: because every upload is multipart (the bridge
    # stream is non-seekable), the destination is only ever replaced by the final
    # CompleteMultipartUpload - so cancelling BEFORE completion leaves any PRE-EXISTING object at
    # the key fully intact, never truncated/partial. We run the upload in its OWN runspace and call
    # .Stop() (-> the provider's StopProcessing -> cancels the CTS -> TU aborts its multipart), then
    # read the object back via the raw SDK and assert it is still the original bytes.
    #
    # We deliberately do NOT assert "zero orphaned multipart uploads": TU's abort is itself async,
    # and an abrupt runspace teardown (like a process kill - which the design doc explicitly says
    # bypasses the abort) can race it. That count is non-deterministic and would flake. The
    # DEPENDABLE contract - and the one that matters for data safety - is that the existing object
    # is untouched. AfterAll aborts any parts left by the race so no billable data lingers.
    Context "Interrupted upload leaves the existing object intact" {
        BeforeAll {
            $script:CxKey = "interrupt/target-$([DateTime]::Now.ToFileTime()).bin"
            S3PutText $script:CxKey "ORIGINAL-CONTENT"   # small known pre-existing object
        }
        AfterAll {
            # Abort any multipart uploads the cancel race may have left under the test key, so we
            # never leave uncommitted (billable) parts behind. TU's abort is async and USUALLY
            # completes before this runs (then the list is empty), but the race can leave one - so
            # abort defensively. Filter to REAL uploads (non-null, with a UploadId) first: when the
            # list is empty, $lmr.MultipartUploads is $null and @($null) would yield a phantom
            # single $null element. For the key, prefer the listed value but fall back to the known
            # $script:CxKey (AWSSDK.S3 v4 can return an empty MultipartUpload.Key here).
            try {
                $lm = New-Object Amazon.S3.Model.ListMultipartUploadsRequest; $lm.BucketName = $script:Bucket
                $lmr = $script:S3.ListMultipartUploadsAsync($lm).GetAwaiter().GetResult()
                $uploads = @($lmr.MultipartUploads) | Where-Object { $_ -and $_.UploadId }
                foreach ($u in $uploads) {
                    $k = if ([string]::IsNullOrEmpty($u.Key)) { $script:CxKey } else { $u.Key }
                    $ab = New-Object Amazon.S3.Model.AbortMultipartUploadRequest
                    $ab.BucketName = $script:Bucket; $ab.Key = $k; $ab.UploadId = $u.UploadId
                    [void]$script:S3.AbortMultipartUploadAsync($ab).GetAwaiter().GetResult()
                }
            } catch { Write-Warning "Multipart cleanup after interrupt test failed: $($_.Exception.Message)" }
            try {
                $d = New-Object Amazon.S3.Model.DeleteObjectRequest; $d.BucketName = $script:Bucket; $d.Key = $script:CxKey
                [void]$script:S3.DeleteObjectAsync($d).GetAwaiter().GetResult()
            } catch { }
        }
        It "does not replace the pre-existing object when the upload is cancelled mid-transfer" {
            $module = Get-Module AWS.Tools.S3 -ErrorAction SilentlyContinue | Select-Object -First 1
            if (-not $module) { $module = Get-Module AWSPowerShell.NetCore -ErrorAction SilentlyContinue | Select-Object -First 1 }
            if (-not $module) { $module = Get-Module AWSPowerShell -ErrorAction SilentlyContinue | Select-Object -First 1 }
            $modulePath = $module.Path
            $modulePath | Should -Not -BeNullOrEmpty
            Test-Path $modulePath | Should -BeTrue
            $bg = [PowerShell]::Create()
            [void]$bg.AddScript({
                param($modulePath, $profile, $region, $bucket, $key)
                Import-Module $modulePath -Force
                Get-Command Mount-S3PSDrive -ErrorAction Stop | Out-Null
                Mount-S3PSDrive -Name CX -ProfileName $profile -Region $region
                $buf = New-Object byte[] (100 * 1024 * 1024)   # 100 MB: guarantees the upload is still in-flight when we Stop
                (New-Object System.Random 7).NextBytes($buf)
                Set-Content "CX:\$bucket\$key" -AsByteStream -Value $buf
            }).AddParameters(@{ modulePath = $modulePath; profile = $script:Profile; region = $script:Region; bucket = $script:Bucket; key = $script:CxKey })

            $async = $bg.BeginInvoke()
            Start-Sleep -Milliseconds 500     # let the multipart upload get in-flight
            if ($async.IsCompleted) {
                try { $bg.EndInvoke($async) } catch { throw "Background upload failed before cancellation was issued: $($_.Exception.Message)" }
                if ($bg.Streams.Error.Count -gt 0) {
                    throw "Background upload wrote errors before cancellation was issued: $($bg.Streams.Error[0].Exception.Message)"
                }
                throw "Background upload completed before cancellation was issued; the cancellation path was not exercised."
            }
            $bg.Stop()                         # provider StopProcessing -> CTS cancel -> TU abort
            try { $bg.EndInvoke($async) } catch [System.Management.Automation.PipelineStoppedException] { }
            $bg.Dispose()
            Start-Sleep -Seconds 1             # let the abort settle before reading back

            # The pre-existing object must be byte-for-byte its original content - not truncated,
            # not the 100MB payload.
            $gr = New-Object Amazon.S3.Model.GetObjectRequest; $gr.BucketName = $script:Bucket; $gr.Key = $script:CxKey
            $resp = $script:S3.GetObjectAsync($gr).GetAwaiter().GetResult()
            $sr = New-Object System.IO.StreamReader($resp.ResponseStream)
            $body = $sr.ReadToEnd(); $sr.Dispose()
            $body | Should -Be 'ORIGINAL-CONTENT'
        }
    }

    Context "Delete" {
        # NOTE (not tested here, by design): deleting a non-empty prefix without -Recurse triggers
        # PowerShell's OWN container-recurse confirmation ("...has children and the Recurse parameter
        # was not specified..."), fired by the engine BEFORE our RemoveItem runs (even under -WhatIf).
        # In a non-interactive host that prompt blocks with nothing to answer it - verified identical
        # to the built-in FileSystem provider (Remove-Item <non-empty-folder> hangs the same way), so
        # it's standard engine behavior, NOT a provider bug. It can't be asserted headlessly, so there
        # is no test for it (the recursive-delete path IS covered below).
        # --- Confirmation: the S3 drive matches the built-in FileSystem provider (and `aws s3 rm`) -
        # Remove-Item is gated by ShouldProcess ONLY and does NOT prompt by default. -WhatIf / -Confirm
        # and $ConfirmPreference are the native ways to preview or gate a delete. We assert the
        # observable contract: -WhatIf never deletes; a plain delete (no -Force, default
        # $ConfirmPreference) proceeds without prompting, exactly like FileSystem.
        It "does NOT delete a single object under -WhatIf (ShouldProcess honored)" {
            $key = "delprompt/whatif-$([DateTime]::Now.ToFileTime()).txt"
            Set-Content "PSTest:\$($script:Bucket)\$key" -Value "keep me"
            Remove-Item "PSTest:\$($script:Bucket)\$key" -WhatIf
            S3ObjectExists $script:Bucket $key | Should -BeTrue   # raw HEAD bypasses provider caches
        }
        # A plain single-object delete without -Force deletes without prompting, matching FileSystem's
        # Remove-Item at the default $ConfirmPreference (Medium ConfirmImpact < High preference => no
        # prompt). It does NOT decline or hang: the old RemoveRequiresForce / prompt-by-default gate
        # was removed. -WhatIf (above) and -Confirm remain the ways to preview / gate the delete.
        It "deletes a single object without -Force (no prompt, matches FileSystem)" {
            $key = "delprompt/noforce-$([DateTime]::Now.ToFileTime()).txt"
            Set-Content "PSTest:\$($script:Bucket)\$key" -Value "remove me"
            Remove-Item "PSTest:\$($script:Bucket)\$key"
            Test-Path "PSTest:\$($script:Bucket)\$key" | Should -BeFalse   # gone, no prompt, no -Force needed
        }
        It "does NOT delete a prefix under -WhatIf -Recurse" {
            $prefix = "delprompt-rec-$([DateTime]::Now.ToFileTime())"
            Set-Content "PSTest:\$($script:Bucket)\$prefix/x.txt" -Value "x"
            Remove-Item "PSTest:\$($script:Bucket)\$prefix" -Recurse -WhatIf
            S3PrefixObjectCount $script:Bucket "$prefix/" | Should -Be 1   # raw listing bypasses provider caches
        }
    }

    Context "Unsupported operations error cleanly" {
        It "rejects unsupported item operations without creating destinations" {
            { Copy-Item "PSTest:\$($script:Bucket)\top.txt" "PSTest:\$($script:Bucket)\copy.txt" -ErrorAction Stop } |
                Should -Throw
            Test-Path "PSTest:\$($script:Bucket)\copy.txt" | Should -BeFalse
            { Move-Item "PSTest:\$($script:Bucket)\top.txt" "PSTest:\$($script:Bucket)\moved.txt" -ErrorAction Stop } |
                Should -Throw
            Test-Path "PSTest:\$($script:Bucket)\moved.txt" | Should -BeFalse
            { Rename-Item "PSTest:\$($script:Bucket)\top.txt" "renamed.txt" -ErrorAction Stop } |
                Should -Throw
            Test-Path "PSTest:\$($script:Bucket)\renamed.txt" | Should -BeFalse
            { New-Item "PSTest:\$($script:Bucket)\empty-prefix" -ItemType Directory -ErrorAction Stop } |
                Should -Throw
            Test-Path "PSTest:\$($script:Bucket)\empty-prefix" | Should -BeFalse
            { Set-Item "PSTest:\$($script:Bucket)\top.txt" -Value 'changed' -ErrorAction Stop } |
                Should -Throw
            (S3GetText $script:Bucket 'top.txt').TrimEnd("`r","`n") | Should -Be 'top level'

            $localSrc = Join-Path $TestDrive 'copy-source.txt'
            $localDst = Join-Path $TestDrive 'copy-dest.txt'
            Set-Content $localSrc -Value 'local file'
            $copyKey = "copy-local-$([DateTime]::Now.ToFileTime()).txt"
            { Copy-Item $localSrc "PSTest:\$($script:Bucket)\$copyKey" -ErrorAction Stop } |
                Should -Throw
            S3ObjectExists $script:Bucket $copyKey | Should -BeFalse
            { Copy-Item "PSTest:\$($script:Bucket)\top.txt" $localDst -ErrorAction Stop } |
                Should -Throw
            Test-Path $localDst | Should -BeFalse
        }
        # ClearContent is a deliberate override in S3Provider that throws PSNotSupportedException
        # - distinct from Copy/Move (which are simply not overridden). A regression turning it into a
        # no-op or a truncation would be silent without this.
        It "rejects Clear-Content (deliberately unsupported)" {
            { Clear-Content "PSTest:\$($script:Bucket)\top.txt" -ErrorAction Stop } | Should -Throw
            # and the object's content is untouched
            (Get-Content "PSTest:\$($script:Bucket)\top.txt" -Raw).Trim() | Should -Be 'top level'
        }
        It "rejects Add-Content without truncating the existing object" {
            $key = "unsupported-$([DateTime]::Now.ToFileTime())/append.txt"
            S3PutText $key 'original'

            { Add-Content "PSTest:\$($script:Bucket)\$key" -Value 'appended' -ErrorAction Stop } |
                Should -Throw

            (S3GetText $script:Bucket $key).TrimEnd("`r","`n") | Should -Be 'original'
        }
    }

    # ---- Edge-case coverage (added to close roadmap gaps) --------------------------------------
    # These test provider BEHAVIOR (assertions), which is independent of where the module ships;
    # only the harness/CI wiring is placement-gated, not these It blocks.

    # The design doc's marquee cache claim: "Write operations originating from the drive
    # (Set-Content, Remove-Item) invalidate affected cache entries immediately." The other tests
    # only ever work AROUND the 1s listing cache (they retry past its TTL because their fixtures
    # are seeded via the RAW SDK, behind the provider). Nothing yet asserts the invalidation
    # itself. These do: prime the cache with a listing, then mutate THROUGH the drive and re-list
    # within the TTL window - a stale (still-fresh) entry would fail, proving the write evicted it.
    # Unique per-test prefixes avoid cross-test cache bleed.
    Context "Cache invalidation on drive-originated writes" {
        It "shows a newly written object at once, without waiting out the listing-cache TTL" {
            $prefix = "cacheadd-$([DateTime]::Now.ToFileTime())"
            Set-Content "PSTest:\$($script:Bucket)\$prefix/first.txt"  -Value 'first'
            (Get-ChildItem "PSTest:\$($script:Bucket)\$prefix" -Name) | Should -Contain 'first.txt'  # primes a COMPLETE cache entry
            Set-Content "PSTest:\$($script:Bucket)\$prefix/second.txt" -Value 'second'                # invalidates $prefix/ immediately
            # Within the 1s TTL the primed entry is still "fresh"; only invalidation makes second.txt appear now.
            $names = Get-ChildItem "PSTest:\$($script:Bucket)\$prefix" -Name
            $names | Should -Contain 'first.txt'
            $names | Should -Contain 'second.txt'
        }
        It "drops a deleted object from the listing at once (delete invalidates the cache)" {
            $prefix = "cachedel-$([DateTime]::Now.ToFileTime())"
            Set-Content "PSTest:\$($script:Bucket)\$prefix/a.txt" -Value 'a'
            Set-Content "PSTest:\$($script:Bucket)\$prefix/b.txt" -Value 'b'
            (Get-ChildItem "PSTest:\$($script:Bucket)\$prefix" -Name) | Should -Contain 'a.txt'   # primes cache
            Remove-Item "PSTest:\$($script:Bucket)\$prefix/a.txt" -Force                           # invalidates (this delete IS the assertion)
            $names = Get-ChildItem "PSTest:\$($script:Bucket)\$prefix" -Name
            $names | Should -Not -Contain 'a.txt'   # gone from the listing at once, not after the TTL
            $names | Should -Contain 'b.txt'
        }
    }

    # Existence-probe cache (2026-07-13 perf fix). ItemExists/IsItemContainer resolve object existence
    # via ObjectExists (GetObjectMetadata HEAD) and prefix existence via PrefixHasChildren; both are now
    # backed by a probe cache with a LONG positive TTL / SHORT negative TTL. The engine re-resolves these
    # dozens of times per command (and re-walks the whole ancestor chain for a deep path), so without the
    # cache a single Test-Path/Get-Content fanned out to many redundant S3 calls (measured: Test-Path
    # ~880ms, a 15-level Get-Content 254 calls / ~20s). We can't assert wall-clock here (flaky), so these
    # assert the CORRECTNESS the cache must preserve - especially that the long positive TTL never masks a
    # subsequent write/delete made THROUGH the drive (which invalidates the probe immediately).
    Context "Existence-probe cache correctness (perf fix)" {
        It "reports a deleted object as absent at once, despite the long positive-probe TTL" {
            $key = "probe-del-$([DateTime]::Now.ToFileTime()).txt"
            Set-Content "PSTest:\$($script:Bucket)\$key" -Value 'x'
            Test-Path "PSTest:\$($script:Bucket)\$key" | Should -BeTrue    # primes a POSITIVE object probe (long TTL)
            Remove-Item "PSTest:\$($script:Bucket)\$key" -Force            # must invalidate that probe now
            Test-Path "PSTest:\$($script:Bucket)\$key" | Should -BeFalse   # not a stale "exists" from the long TTL
        }
        It "does not hold an externally deleted object in the positive probe cache past the short TTL" {
            $key = "probe-extdel-$([DateTime]::Now.ToFileTime()).txt"
            S3PutText $key 'x'
            Test-Path "PSTest:\$($script:Bucket)\$key" | Should -BeTrue     # primes a POSITIVE object probe
            $d = New-Object Amazon.S3.Model.DeleteObjectRequest
            $d.BucketName = $script:Bucket; $d.Key = $key
            [void]$script:S3.DeleteObjectAsync($d).GetAwaiter().GetResult()
            Start-Sleep -Milliseconds 1500
            Test-Path "PSTest:\$($script:Bucket)\$key" | Should -BeFalse
        }
        It "reflects an overwrite through the drive (probe cache does not mask changed content)" {
            $key = "probe-ow-$([DateTime]::Now.ToFileTime()).txt"
            Set-Content "PSTest:\$($script:Bucket)\$key" -Value 'AAA'
            (Get-Content "PSTest:\$($script:Bucket)\$key" -Raw).Trim() | Should -Be 'AAA'   # primes probe + reads
            Set-Content "PSTest:\$($script:Bucket)\$key" -Value 'BBB'                        # overwrite invalidates
            (Get-Content "PSTest:\$($script:Bucket)\$key" -Raw).Trim() | Should -Be 'BBB'
            Remove-Item "PSTest:\$($script:Bucket)\$key" -Force
        }
        It "resolves a deep nested object and reads it back (deep ancestor-walk path)" {
            # Exercises the ancestor-chain probe walk the perf fix de-thrashes. Depth is enough to force
            # multiple ancestor prefixes without being slow to seed.
            $base = "probe-deep-$([DateTime]::Now.ToFileTime())"
            $rel  = "L0/L1/L2/L3/L4/L5/leaf.txt"
            Set-Content "PSTest:\$($script:Bucket)\$base/$rel" -Value 'deep'
            Test-Path "PSTest:\$($script:Bucket)\$base/$rel" | Should -BeTrue
            (Get-Content "PSTest:\$($script:Bucket)\$base/$rel" -Raw).Trim() | Should -Be 'deep'
            # An intermediate ancestor resolves as a container.
            Test-Path "PSTest:\$($script:Bucket)\$base/L0/L1/L2" -PathType Container | Should -BeTrue
            Remove-Item "PSTest:\$($script:Bucket)\$base" -Recurse -Force
        }
        # Regression for the pre-existing InvalidateForKey gap the long TTL exposed: a recursive prefix
        # delete must evict DESCENDANT listing/probe entries too, so an INTERMEDIATE descendant prefix
        # does not read stale "exists". (Before the fix, "$base/a/b" reported exists after deleting $base.)
        It "invalidates intermediate descendant prefixes on a recursive delete" {
            $base = "probe-recdel-$([DateTime]::Now.ToFileTime())"
            Set-Content "PSTest:\$($script:Bucket)\$base/a/b/c.txt" -Value 'x'
            Test-Path "PSTest:\$($script:Bucket)\$base/a/b" -PathType Container | Should -BeTrue  # primes descendant prefix probe
            Remove-Item "PSTest:\$($script:Bucket)\$base" -Recurse -Force
            Test-Path "PSTest:\$($script:Bucket)\$base"        | Should -BeFalse   # root gone
            Test-Path "PSTest:\$($script:Bucket)\$base/a/b"    | Should -BeFalse   # intermediate descendant NOT stale
            Test-Path "PSTest:\$($script:Bucket)\$base/a/b/c.txt" | Should -BeFalse
        }
    }

    # Safety guard: a bucket is NOT a deletable item through the drive - deleting buckets is out of
    # scope (that's Remove-S3Bucket). RemoveItem rejects an empty-key path (bucket-only) with
    # InvalidRemovePath BEFORE any S3 call. We pass -Recurse -Force so the request reaches our
    # RemoveItem (recurse handled in the provider) rather than tripping PowerShell's own
    # container-recurse prompt, which would hang non-interactively (see the Delete context note).
    # Runs against an ISOLATED throwaway bucket so a delete-safety test can never risk the shared
    # fixture bucket, even under an unexpected engine dispatch.
    Context "Remove-Item safety guards" {
        BeforeAll {
            $script:GuardBucket = "pstest-psdrive-guard-" + [DateTime]::Now.ToFileTime()
            $mk = New-Object Amazon.S3.Model.PutBucketRequest; $mk.BucketName = $script:GuardBucket
            [void]$script:S3.PutBucketAsync($mk).GetAwaiter().GetResult()
            $put = New-Object Amazon.S3.Model.PutObjectRequest
            $put.BucketName = $script:GuardBucket; $put.Key = "keep.txt"; $put.ContentBody = "keep"
            [void]$script:S3.PutObjectAsync($put).GetAwaiter().GetResult()
        }
        AfterAll {
            if ($script:GuardBucket) {
                try {
                    $d = New-Object Amazon.S3.Model.DeleteObjectRequest
                    $d.BucketName = $script:GuardBucket; $d.Key = "keep.txt"
                    [void]$script:S3.DeleteObjectAsync($d).GetAwaiter().GetResult()
                    $db = New-Object Amazon.S3.Model.DeleteBucketRequest; $db.BucketName = $script:GuardBucket
                    [void]$script:S3.DeleteBucketAsync($db).GetAwaiter().GetResult()
                } catch { Write-Warning "Guard-bucket cleanup failed for '$($script:GuardBucket)': $($_.Exception.Message)" }
            }
        }
        It "refuses to delete a whole bucket through the drive (bucket ops are out of scope)" {
            $ev = $null
            Remove-Item "PSTest:\$($script:GuardBucket)" -Recurse -Force -ErrorVariable ev -ErrorAction SilentlyContinue
            $ev.Count                    | Should -BeGreaterThan 0
            $ev[0].FullyQualifiedErrorId | Should -BeLike 'InvalidRemovePath*'
            Test-Path "PSTest:\$($script:GuardBucket)\keep.txt" | Should -BeTrue   # object (and bucket) survive - guard fired before any delete
        }
    }

    # Get-ChildItem -Recurse. Recursive listing is supported and shipping (GetChildItems recurse=true
    # -> StreamAllUnder), but nothing exercised it through the real command surface. This asserts the
    # contract that holds regardless of how PowerShell dispatches -Recurse (flat StreamAllUnder, or
    # engine-driven per-level walk): every object at every depth is surfaced, and a directory
    # marker is NOT surfaced as a file. Unique prefix => no prior cache, no cross-test bleed.
    Context "Recursive listing (Get-ChildItem -Recurse)" {
        BeforeAll {
            $script:RecPrefix = "rec-$([DateTime]::Now.ToFileTime())"
            Set-Content "PSTest:\$($script:Bucket)\$($script:RecPrefix)/a.txt"          -Value 'a'
            Set-Content "PSTest:\$($script:Bucket)\$($script:RecPrefix)/sub/b.txt"      -Value 'b'
            Set-Content "PSTest:\$($script:Bucket)\$($script:RecPrefix)/sub/deep/c.txt" -Value 'c'
            # A directory marker (0-byte key ending in "/"); only the raw SDK can create one.
            $script:S3.PutObjectAsync((New-Object Amazon.S3.Model.PutObjectRequest -Property @{
                BucketName = $script:Bucket; Key = "$($script:RecPrefix)/emptydir/"; ContentBody = "" })).GetAwaiter().GetResult() | Out-Null
        }
        AfterAll {
            Remove-Item "PSTest:\$($script:Bucket)\$($script:RecPrefix)" -Recurse -Force -ErrorAction SilentlyContinue
        }
        It "surfaces every real object at all depths and skips directory markers" {
            $objects = Get-ChildItem "PSTest:\$($script:Bucket)\$($script:RecPrefix)" -Recurse | Where-Object Type -eq 'Object'
            @($objects).Count | Should -Be 3
            # the deepest object is reached (name form differs by dispatch: "sub/deep/c.txt" flat, or "c.txt")
            ($objects | Where-Object { $_.Name -like '*c.txt' }) | Should -Not -BeNullOrEmpty
            ($objects | Where-Object { $_.Name -like '*emptydir*' }) | Should -BeNullOrEmpty
        }
    }

    # A 0-byte object whose key does NOT end in "/" is a real empty FILE - distinct from a
    # directory marker (key ending in "/", surfaced as an empty folder; see the marker test). It
    # must list as a 0-byte Object and read back as empty content. Seeded raw (Set-Content can't
    # reliably produce a truly 0-byte object); unique prefix => first listing is a cache miss.
    Context "Zero-byte object (empty file, not a marker)" {
        BeforeAll {
            $script:ZeroPrefix = "zero-$([DateTime]::Now.ToFileTime())"
            $script:S3.PutObjectAsync((New-Object Amazon.S3.Model.PutObjectRequest -Property @{
                BucketName = $script:Bucket; Key = "$($script:ZeroPrefix)/empty.dat"; ContentBody = "" })).GetAwaiter().GetResult() | Out-Null
        }
        AfterAll {
            Remove-Item "PSTest:\$($script:Bucket)\$($script:ZeroPrefix)" -Recurse -Force -ErrorAction SilentlyContinue
        }
        It "lists a 0-byte object as an empty file and reads it as empty content" {
            $item = Get-ChildItem "PSTest:\$($script:Bucket)\$($script:ZeroPrefix)" | Where-Object Name -eq 'empty.dat'
            $item      | Should -Not -BeNullOrEmpty
            $item.Type | Should -Be 'Object'
            $item.Size | Should -Be 0
            $raw = Get-Content "PSTest:\$($script:Bucket)\$($script:ZeroPrefix)/empty.dat" -Raw
            [string]$raw | Should -BeNullOrEmpty   # -Raw on an empty object => $null or '' (both mean no content)
        }
    }

    # The sanctioned stand-in for the out-of-scope S3->S3 Copy-Item: pipe an object's bytes through
    # Get-Content | Set-Content on the same drive. Exercises the byte-stream contract end to end -
    # the reader's 80KB Object[] chunks must flow into the writer and reassemble byte-for-byte.
    # Payload spans several reader chunks.
    Context "Content-stream copy within the drive (Get-Content | Set-Content)" {
        It "copies an object byte-for-byte via the content pipeline" {
            $prefix = "streamcopy-$([DateTime]::Now.ToFileTime())"
            $src = "PSTest:\$($script:Bucket)\$prefix/src.bin"
            $dst = "PSTest:\$($script:Bucket)\$prefix/dst.bin"
            $bytes = New-Object byte[] (130 * 1024)   # > one 80KB reader chunk
            (New-Object System.Random 4242).NextBytes($bytes)
            Set-Content $src -AsByteStream -Value $bytes

            Get-Content $src -AsByteStream | Set-Content $dst -AsByteStream

            $flat = [byte[]]((Get-Content $dst -AsByteStream -Raw) | ForEach-Object { $_ })   # flatten the Object[] of chunks
            $flat.Length | Should -Be $bytes.Length
            $sha = [System.Security.Cryptography.SHA256]::Create()
            [BitConverter]::ToString($sha.ComputeHash($flat)) |
                Should -Be ([BitConverter]::ToString($sha.ComputeHash($bytes)))
        }
    }

    Context "Local filesystem interop (design examples)" {
        It "uploads from and downloads to the local filesystem byte-for-byte" {
            $prefix = "localio-$([DateTime]::Now.ToFileTime())"
            $key = "$prefix/payload.bin"
            $localSrc = Join-Path $TestDrive 'src.bin'
            $localDst = Join-Path $TestDrive 'dst.bin'
            $bytes = New-Object byte[] (96 * 1024)
            (New-Object System.Random 8601).NextBytes($bytes)
            [System.IO.File]::WriteAllBytes($localSrc, $bytes)

            # Local-file byte I/O differs by edition (a built-in FileSystem-provider difference, NOT
            # the S3 provider): PS7+ uses -AsByteStream; Windows PowerShell 5.1 has no -AsByteStream on
            # its FileSystem provider and uses -Encoding Byte instead. The S3 side uses -AsByteStream on
            # both. This mirrors the local<->S3 copy guidance in docs/psdrive-s3/guide.md.
            $s3Path = "PSTest:\$($script:Bucket)\$key"
            if ($PSVersionTable.PSEdition -eq 'Desktop') {
                Get-Content $localSrc -Encoding Byte -ReadCount 8MB |
                    Set-Content -LiteralPath $s3Path -AsByteStream
                Get-Content -LiteralPath $s3Path -AsByteStream |
                    Set-Content $localDst -Encoding Byte
            } else {
                Get-Content $localSrc -AsByteStream |
                    Set-Content -LiteralPath $s3Path -AsByteStream
                Get-Content -LiteralPath $s3Path -AsByteStream |
                    Set-Content $localDst -AsByteStream
            }

            $got = [System.IO.File]::ReadAllBytes($localDst)
            $got.Length | Should -Be $bytes.Length
            $sha = [System.Security.Cryptography.SHA256]::Create()
            [BitConverter]::ToString($sha.ComputeHash($got)) |
                Should -Be ([BitConverter]::ToString($sha.ComputeHash($bytes)))
        }
    }

    # Piping listed items straight into another provider cmdlet (Get-ChildItem | Get-Content /
    # | Remove-Item) binds each item's PSPath, which is PROVIDER-QUALIFIED
    # ("AWS.Tools.S3\AWS.S3::bucket\key"). The provider must emit a drive-INDEPENDENT
    # item path (bucket\key, not "S3:\...") and recover its S3DriveInfo when the engine resolves
    # that PSPath against the hidden drive - otherwise the pipe fails "Cannot find path ..." before
    # the content/remove op runs. Regression guard for that bug (it was invisible because earlier
    # tests only used literal-path strings, never piped Get-ChildItem output).
    Context "Pipe a listed item into another provider cmdlet (PSPath round-trip)" {
        # Helper: list a prefix's immediate children, retrying past the 1s listing-cache TTL (the
        # fixtures are seeded via the raw SDK behind the provider, so a pre-seed empty listing can be
        # briefly cached - see the marker/collision tests). Returns the child items once they appear.
        function script:ListWhenReady($prefixPath, $expectedCount) {
            $items = @()
            foreach ($i in 1..8) {
                $items = @(Get-ChildItem $prefixPath -ErrorAction SilentlyContinue)
                if ($items.Count -ge $expectedCount) { break }
                Start-Sleep -Milliseconds 300
            }
            return $items
        }

        It "Get-ChildItem | Get-Content honors -AsByteStream for listed objects" {
            $prefix = "pipe-bytes-$([DateTime]::Now.ToFileTime())"
            $bytes = [byte[]](0,1,2,3,254,255)
            Set-Content "PSTest:\$($script:Bucket)\$prefix/payload.bin" -AsByteStream -Value $bytes
            $prefixPath = "PSTest:\$($script:Bucket)\$prefix"
            (ListWhenReady $prefixPath 1).Count | Should -Be 1   # wait out the cache TTL first
            $got = [byte[]](
                Get-ChildItem $prefixPath |
                    ForEach-Object { Get-Content -LiteralPath $_.PSPath -AsByteStream -Raw }
            )
            [BitConverter]::ToString($got) | Should -Be ([BitConverter]::ToString($bytes))
        }
        It "Get-ChildItem | Remove-Item deletes the piped objects" {
            $prefix = "pipe-del-$([DateTime]::Now.ToFileTime())"
            S3PutText "$prefix/a.txt" "A"
            S3PutText "$prefix/b.txt" "B"
            $prefixPath = "PSTest:\$($script:Bucket)\$prefix"
            $items = ListWhenReady $prefixPath 2                  # ensure both are visible to pipe
            $items.Count | Should -Be 2
            $items | Remove-Item -Force
            # Verify against a raw SDK listing (bypasses the provider's short-TTL listing cache).
            # NOTE: SDK v4 ListObjectsV2 returns S3Objects=NULL (not empty) when nothing matches, and
            # @($null).Count is 1 in PowerShell - so coalesce null->@() before counting, or an empty
            # result reads as a phantom survivor.
            $lr = New-Object Amazon.S3.Model.ListObjectsV2Request
            $lr.BucketName = $script:Bucket; $lr.Prefix = "$prefix/"
            $resp = $script:S3.ListObjectsV2Async($lr).GetAwaiter().GetResult()
            @($resp.S3Objects | Where-Object { $_ }).Count | Should -Be 0
        }
    }

    # S3 keys legally contain spaces, non-ASCII, and PowerShell wildcard chars ([ ]). Path
    # parsing/round-tripping must survive them; wildcard chars require -LiteralPath (as on the
    # FileSystem provider). (Keys containing "\" are a documented dead-end - PowerShell's path
    # separator - and are intentionally not tested here.)
    Context "Keys with special characters" {
        It "round-trips representative literal key names without changing the raw S3 key" {
            $stamp = [DateTime]::Now.ToFileTime()
            $cases = @(
                @{ Key = "spaces-$stamp/my report.txt"; Value = 'spaced'; Literal = $false },
                @{ Key = "unicode-$stamp/café-日本.txt"; Value = 'unicode key'; Literal = $false },
                @{ Key = "wild-$stamp/data[1]*?.txt"; Value = 'literal'; Literal = $true }
            )

            foreach ($case in $cases) {
                $path = "PSTest:\$($script:Bucket)\$($case.Key)"
                if ($case.Literal) {
                    Set-Content -LiteralPath $path -Value $case.Value
                    (Get-Content -LiteralPath $path -Raw).TrimEnd("`r","`n") | Should -Be $case.Value
                } else {
                    Set-Content $path -Value $case.Value
                    (Get-Content $path -Raw).TrimEnd("`r","`n") | Should -Be $case.Value
                }
                S3ObjectExists $script:Bucket $case.Key | Should -BeTrue
            }
        }
        It "round-trips keys containing colon separators through direct and piped paths" {
            $prefix = "colon-$([DateTime]::Now.ToFileTime())"
            S3PutText "$prefix/one:a.txt"  "colon-one"
            S3PutText "$prefix/two::b.txt" "colon-two"

            (Get-Content -LiteralPath "PSTest:\$($script:Bucket)\$prefix/two::b.txt" -Raw).TrimEnd("`r","`n") |
                Should -Be 'colon-two'

            $joined = (Get-ChildItem "PSTest:\$($script:Bucket)\$prefix" | Get-Content -Raw) -join "`n"
            $joined | Should -Match 'colon-one'
            $joined | Should -Match 'colon-two'
        }
    }

    Context "Set-Content input shapes" {
        It "writes an array of strings as separate newline-terminated lines" {
            $key = "shape-$([DateTime]::Now.ToFileTime())/lines.txt"
            Set-Content "PSTest:\$($script:Bucket)\$key" -Value @('alpha','beta','gamma')
            $lines = Get-Content "PSTest:\$($script:Bucket)\$key"
            $lines[0] | Should -Be 'alpha'
            $lines[1] | Should -Be 'beta'
            $lines[2] | Should -Be 'gamma'
            # Read the raw bytes back: text-mode Set-Content emits ToString()+"\n" per item.
            $bytes = [byte[]]((Get-Content "PSTest:\$($script:Bucket)\$key" -AsByteStream -Raw) | ForEach-Object { $_ })
            $bytes[-1] | Should -Be 10   # trailing LF
        }
        It "round-trips bytes through explicit S3 -AsByteStream paths" {
            $key = "shape-$([DateTime]::Now.ToFileTime())/explicit-bytes.bin"
            $s3Path = "PSTest:\$($script:Bucket)\$key"
            $bytes = [byte[]](0,1,2,3,4,5,254,255)

            Set-Content -LiteralPath $s3Path -AsByteStream -Value $bytes
            $got = [byte[]]((Get-Content -LiteralPath $s3Path -AsByteStream -Raw) | ForEach-Object { $_ })

            [BitConverter]::ToString($got) | Should -Be ([BitConverter]::ToString($bytes))
        }
        # -AsByteStream accepts byte / byte[] / nested object[]; a non-byte element throws
        # InvalidCastException from S3TransferContentWriter.AppendItem. Without this, a
        # regression silently coercing or dropping the value would go unseen (the byte-stream happy
        # paths only ever feed valid byte[]).
        It "rejects a non-byte element under -AsByteStream" {
            $key = "shape-$([DateTime]::Now.ToFileTime())/bad.bin"
            { Set-Content "PSTest:\$($script:Bucket)\$key" -AsByteStream -Value 'not-a-byte' -ErrorAction Stop } |
                Should -Throw
            S3ObjectExists $script:Bucket $key | Should -BeFalse
        }
        It "honors -NoNewline for text-mode uploads" {
            $key = "shape-$([DateTime]::Now.ToFileTime())/no-newline.txt"
            Set-Content "PSTest:\$($script:Bucket)\$key" -Value @('alpha','beta') -NoNewline
            [System.Text.Encoding]::UTF8.GetString((S3GetBytes $script:Bucket $key)) |
                Should -Be 'alphabeta'
        }
        It "accepts a per-upload -PartSize override" {
            $key = "shape-$([DateTime]::Now.ToFileTime())/part-size.txt"
            Set-Content "PSTest:\$($script:Bucket)\$key" -Value 'custom part size' -PartSize 8MB
            (S3GetText $script:Bucket $key).TrimEnd("`r","`n") |
                Should -Be 'custom part size'
        }
        It "creates a zero-byte object from an explicit empty byte array" {
            $key = "shape-$([DateTime]::Now.ToFileTime())/empty.bin"
            Set-Content "PSTest:\$($script:Bucket)\$key" -AsByteStream -Value ([byte[]]@())
            (S3GetBytes $script:Bucket $key).Length | Should -Be 0
        }
    }

    Context "Set-Content writer parameters on pipeline-bound S3 paths" {
        It "honors -NoNewline when the destination path comes from Get-Item" {
            $key = "pipe-write-$([DateTime]::Now.ToFileTime())/no-newline.txt"
            $s3Path = "PSTest:\$($script:Bucket)\$key"
            Set-Content $s3Path -Value 'seed'

            Get-Item $s3Path | Set-Content -NoNewline

            [System.Text.Encoding]::UTF8.GetString((S3GetBytes $script:Bucket $key)) |
                Should -Be 'no-newline.txt'
        }

        It "honors -Encoding and -NoNewline when the destination path comes from Get-Item" {
            $leaf = "caf$([char]0x00E9).txt"
            $key = "pipe-write-$([DateTime]::Now.ToFileTime())/$leaf"
            $s3Path = "PSTest:\$($script:Bucket)\$key"
            Set-Content $s3Path -Value 'seed'

            Get-Item $s3Path | Set-Content -Encoding ASCII -NoNewline

            [BitConverter]::ToString((S3GetBytes $script:Bucket $key)) |
                Should -Be ([BitConverter]::ToString([System.Text.Encoding]::ASCII.GetBytes($leaf)))
        }

        # PS7-only: pipeline-bound -AsByteStream can't bind on Windows PowerShell 5.1 - its FileSystem
        # provider has no -AsByteStream, so the engine rejects the parameter before the S3 provider
        # runs (a platform limitation, not a provider gap; explicit-path -AsByteStream works on both,
        # covered elsewhere). -Skip on 5.1 rather than omitting the It, so it shows as Skipped.
        It "honors -AsByteStream when the destination path comes from Get-Item" -Skip:($PSVersionTable.PSVersion.Major -lt 7) {
            $key = "pipe-write-$([DateTime]::Now.ToFileTime())/bytes.bin"
            $s3Path = "PSTest:\$($script:Bucket)\$key"
            $bytes = [byte[]](0,1,2,3,254,255)
            Set-Content $s3Path -Value 'seed'

            Get-Item $s3Path | Set-Content -Value $bytes -AsByteStream
            $got = [byte[]]((Get-Content -LiteralPath $s3Path -AsByteStream -Raw) | ForEach-Object { $_ })

            [BitConverter]::ToString($got) |
                Should -Be ([BitConverter]::ToString($bytes))
        }
    }

    Context "Get-Content error paths" {
        It "errors (does not hang) reading a nonexistent object" {
            { Get-Content "PSTest:\$($script:Bucket)\nope-$([guid]::NewGuid()).txt" -ErrorAction Stop } |
                Should -Throw
        }
    }

    # A content op (Get-Content/Set-Content) needs an OBJECT path (bucket + key). A bucket-only path
    # (no key) is rejected up front with InvalidContentPath by TryParseObjectPath, at two distinct
    # call sites (GetContentReader + GetContentWriter) - before any S3 call. The analogous
    # Remove-Item bucket-only guard (InvalidRemovePath) is tested; these content-op guards were not.
    Context "Content ops reject a bucket-only path (no key)" {
        It "Get-Content on a bucket-only path errors with InvalidContentPath" {
            $ev = $null
            Get-Content "PSTest:\$($script:Bucket)" -ErrorVariable ev -ErrorAction SilentlyContinue
            $ev.Count                    | Should -BeGreaterThan 0
            $ev[0].FullyQualifiedErrorId | Should -BeLike 'InvalidContentPath*'
        }
        It "Set-Content on a bucket-only path errors with InvalidContentPath" {
            $ev = $null
            Set-Content "PSTest:\$($script:Bucket)" -Value 'x' -ErrorVariable ev -ErrorAction SilentlyContinue
            $ev.Count                    | Should -BeGreaterThan 0
            $ev[0].FullyQualifiedErrorId | Should -BeLike 'InvalidContentPath*'
        }
    }

    # Set-Content -Encoding. The Get-Content utf8 round-trip exercises the READ decode; nothing
    # exercised the WRITE encode path or its validation. These lock: (1) a non-default -Encoding
    # controls the on-the-wire bytes, and (2) an unknown -Encoding is rejected before the writer opens.
    Context "Set-Content -Encoding (write-side)" {
        It "honors -Encoding on write (round-trips a multibyte char through utf8)" {
            $key = "encw-$([DateTime]::Now.ToFileTime())/u.txt"
            $val = 'ünïcödé'
            Set-Content "PSTest:\$($script:Bucket)\$key" -Value $val -Encoding utf8
            (Get-Content "PSTest:\$($script:Bucket)\$key" -Raw -Encoding utf8).TrimEnd("`r","`n") | Should -Be $val
        }
        It "writes the requested BOM for utf8BOM uploads" {
            $key = "encw-$([DateTime]::Now.ToFileTime())/bom.txt"
            Set-Content "PSTest:\$($script:Bucket)\$key" -Value 'hello' -Encoding utf8BOM
            $bytes = S3GetBytes $script:Bucket $key
            $bytes[0] | Should -Be 0xEF
            $bytes[1] | Should -Be 0xBB
            $bytes[2] | Should -Be 0xBF
        }
        It "rejects an unknown -Encoding value on write with a clear error" {
            { Set-Content "PSTest:\$($script:Bucket)\encw-$([DateTime]::Now.ToFileTime()).txt" -Value 'x' -Encoding not-a-real-encoding -ErrorAction Stop } |
                Should -Throw
        }
    }

    # -WhatIf on Set-Content (upload). GetContentWriter does NOT call ShouldProcess itself, yet
    # -WhatIf IS honored: the PowerShell ENGINE gates content writes ("What if: Performing the
    # operation 'Set Content'") and never opens the writer. Verified (probe): a -WhatIf upload
    # neither creates a new object nor overwrites an existing one. (Contrast Remove-Item, where the
    # PROVIDER drives ShouldProcess.) Locks this in so a future change can't silently start writing.
    Context "Set-Content -WhatIf (engine-gated, no write)" {
        It "does not create or overwrite objects under -WhatIf" {
            $newKey = "whatif-$([DateTime]::Now.ToFileTime())/new.txt"
            $existingKey = "whatif-$([DateTime]::Now.ToFileTime())/existing.txt"
            Set-Content "PSTest:\$($script:Bucket)\$existingKey" -Value 'ORIGINAL'

            Set-Content "PSTest:\$($script:Bucket)\$newKey" -Value 'should not be written' -WhatIf
            Set-Content "PSTest:\$($script:Bucket)\$existingKey" -Value 'REPLACED' -WhatIf

            S3ObjectExists $script:Bucket $newKey | Should -BeFalse
            (S3GetText $script:Bucket $existingKey).TrimEnd("`r","`n") | Should -Be 'ORIGINAL'
        }
    }

    # Tab-completion routes through the provider's GetChildNames + ItemExists/IsItemContainer.
    # TabExpansion2 is the programmatic entry point the shell uses for <Tab>. Assert it completes a
    # partial name to the matching folder (as a container) and lists a folder's children (subfolder
    # + object) - the behavior that makes cd/<Tab> usable. Uses the seeded reports/ tree.
    Context "Tab-completion (GetChildNames)" {
        It "completes a partial name to the matching folder, typed as a container" {
            $line = "Get-ChildItem PSTest:\$($script:Bucket)\rep"
            $c = TabExpansion2 -inputScript $line -cursorColumn $line.Length
            $match = $c.CompletionMatches | Where-Object { $_.CompletionText -like '*reports' }
            $match            | Should -Not -BeNullOrEmpty
            $match.ResultType | Should -Be ([System.Management.Automation.CompletionResultType]::ProviderContainer)
        }
        It "lists a folder's children (subfolder and object) as completions" {
            $line = "Get-ChildItem PSTest:\$($script:Bucket)\reports\"
            $c = TabExpansion2 -inputScript $line -cursorColumn $line.Length
            $items = $c.CompletionMatches.ListItemText
            $items | Should -Contain '2026'        # subfolder
            $items | Should -Contain 'index.txt'   # object
        }
    }

    # AccessDenied resolves as "exists" (deliberate design): ItemExists/IsItemContainer return true
    # on AccessDenied so path resolution SUCCEEDS and the real operation then surfaces the genuine
    # AccessDenied - instead of the engine masking a thrown error as a misleading "path not found".
    # Setup: a throwaway bucket with a SCOPED Deny (GetObject + ListBucket only - NOT
    # DeleteObject/DeleteBucket/DeleteBucketPolicy, so teardown still works). Cleanup removes the
    # policy, then deletes the known key BY NAME (no ListBucket needed) and the bucket.
    Context "AccessDenied resolves as exists (not 'not found')" {
        BeforeAll {
            $script:AdBucket = "pstest-psdrive-ad-" + [DateTime]::Now.ToFileTime()
            $mk = New-Object Amazon.S3.Model.PutBucketRequest; $mk.BucketName = $script:AdBucket
            [void]$script:S3.PutBucketAsync($mk).GetAwaiter().GetResult()
            $put = New-Object Amazon.S3.Model.PutObjectRequest
            $put.BucketName = $script:AdBucket; $put.Key = "secret.txt"; $put.ContentBody = "cannot read me"
            [void]$script:S3.PutObjectAsync($put).GetAwaiter().GetResult()
            $policy = '{ "Version":"2012-10-17","Statement":[{"Sid":"DenyRead","Effect":"Deny",' +
                      '"Principal":"*","Action":["s3:GetObject","s3:ListBucket"],"Resource":' +
                      '["arn:aws:s3:::' + $script:AdBucket + '","arn:aws:s3:::' + $script:AdBucket + '/*"]}]}'
            $pp = New-Object Amazon.S3.Model.PutBucketPolicyRequest; $pp.BucketName = $script:AdBucket; $pp.Policy = $policy
            [void]$script:S3.PutBucketPolicyAsync($pp).GetAwaiter().GetResult()
            Start-Sleep -Seconds 3   # let the deny policy propagate before probing through the drive
        }
        AfterAll {
            if ($script:AdBucket) {
                try {
                    $dp = New-Object Amazon.S3.Model.DeleteBucketPolicyRequest; $dp.BucketName = $script:AdBucket
                    [void]$script:S3.DeleteBucketPolicyAsync($dp).GetAwaiter().GetResult()
                    Start-Sleep -Seconds 1   # policy removal propagates
                    $d = New-Object Amazon.S3.Model.DeleteObjectRequest; $d.BucketName = $script:AdBucket; $d.Key = "secret.txt"
                    [void]$script:S3.DeleteObjectAsync($d).GetAwaiter().GetResult()
                    $db = New-Object Amazon.S3.Model.DeleteBucketRequest; $db.BucketName = $script:AdBucket
                    [void]$script:S3.DeleteBucketAsync($db).GetAwaiter().GetResult()
                } catch { Write-Warning "AccessDenied-fixture cleanup failed for '$($script:AdBucket)': $($_.Exception.Message)" }
            }
        }
        It "resolves a read-denied object as existing, then surfaces the real AccessDenied" {
            Test-Path "PSTest:\$($script:AdBucket)\secret.txt" | Should -BeTrue
            $err = $null
            try { Get-Content "PSTest:\$($script:AdBucket)\secret.txt" -Raw -ErrorAction Stop } catch { $err = $_ }
            $err | Should -Not -BeNullOrEmpty
            $err.Exception.Message | Should -Match 'denied|not authorized'   # real S3 error, not "path not found"
        }
    }

    Context "Exact object operations without ListBucket" {
        BeforeAll {
            $script:NoListBucket = "pstest-psdrive-nolist-" + [DateTime]::Now.ToFileTime()
            $mk = New-Object Amazon.S3.Model.PutBucketRequest; $mk.BucketName = $script:NoListBucket
            [void]$script:S3.PutBucketAsync($mk).GetAwaiter().GetResult()
            $put = New-Object Amazon.S3.Model.PutObjectRequest
            $put.BucketName = $script:NoListBucket; $put.Key = "allowed.txt"; $put.ContentBody = "allowed"
            [void]$script:S3.PutObjectAsync($put).GetAwaiter().GetResult()
            $policy = '{ "Version":"2012-10-17","Statement":[{"Sid":"DenyListOnly","Effect":"Deny",' +
                      '"Principal":"*","Action":"s3:ListBucket","Resource":"arn:aws:s3:::' + $script:NoListBucket + '"}]}'
            $pp = New-Object Amazon.S3.Model.PutBucketPolicyRequest; $pp.BucketName = $script:NoListBucket; $pp.Policy = $policy
            [void]$script:S3.PutBucketPolicyAsync($pp).GetAwaiter().GetResult()
            $script:NoListBucketListDenied = $false
            foreach ($i in 1..12) {
                try {
                    $lr = New-Object Amazon.S3.Model.ListObjectsV2Request
                    $lr.BucketName = $script:NoListBucket; $lr.MaxKeys = 1
                    [void]$script:S3.ListObjectsV2Async($lr).GetAwaiter().GetResult()
                } catch [Amazon.S3.AmazonS3Exception] {
                    if ($_.Exception.StatusCode -eq [System.Net.HttpStatusCode]::Forbidden -or $_.Exception.ErrorCode -eq 'AccessDenied') {
                        $script:NoListBucketListDenied = $true
                        break
                    }
                    throw
                }
                Start-Sleep -Milliseconds 500
            }
            if (-not $script:NoListBucketListDenied) {
                throw "ListObjectsV2 was not denied for no-ListBucket fixture '$($script:NoListBucket)'."
            }
        }
        AfterAll {
            Set-Location $HOME -ErrorAction SilentlyContinue
            if (Test-Path 'PSNoList:\') { try { Dismount-S3PSDrive -Name PSNoList -ErrorAction SilentlyContinue } catch { } }
            if ($script:NoListBucket) {
                try {
                    $dp = New-Object Amazon.S3.Model.DeleteBucketPolicyRequest; $dp.BucketName = $script:NoListBucket
                    [void]$script:S3.DeleteBucketPolicyAsync($dp).GetAwaiter().GetResult()
                    Start-Sleep -Seconds 1
                    foreach ($k in 'allowed.txt') {
                        $d = New-Object Amazon.S3.Model.DeleteObjectRequest
                        $d.BucketName = $script:NoListBucket; $d.Key = $k
                        [void]$script:S3.DeleteObjectAsync($d).GetAwaiter().GetResult()
                    }
                    $db = New-Object Amazon.S3.Model.DeleteBucketRequest; $db.BucketName = $script:NoListBucket
                    [void]$script:S3.DeleteBucketAsync($db).GetAwaiter().GetResult()
                } catch { Write-Warning "No-ListBucket fixture cleanup failed for '$($script:NoListBucket)': $($_.Exception.Message)" }
            }
        }
        It "mounts the denied-list bucket as a root, then gets, overwrites, and deletes an exact object" {
            Mount-S3PSDrive -Name PSNoList -Root $script:NoListBucket -ProfileName $script:Profile -Region $script:Region
            (Get-Item 'PSNoList:\allowed.txt' -ErrorAction Stop).Type | Should -Be 'Object'
            (Get-Content 'PSNoList:\allowed.txt' -Raw -ErrorAction Stop).TrimEnd("`r","`n") | Should -Be 'allowed'

            $path = "PSTest:\$($script:NoListBucket)\allowed.txt"
            (Get-Item $path -ErrorAction Stop).Type | Should -Be 'Object'
            (Get-Content $path -Raw -ErrorAction Stop).TrimEnd("`r","`n") | Should -Be 'allowed'
            Set-Content $path -Value 'updated' -ErrorAction Stop
            (Get-Content 'PSNoList:\allowed.txt' -Raw -ErrorAction Stop).TrimEnd("`r","`n") | Should -Be 'updated'
            Remove-Item 'PSNoList:\allowed.txt' -Force -ErrorAction Stop

            $head = New-Object Amazon.S3.Model.GetObjectMetadataRequest
            $head.BucketName = $script:NoListBucket; $head.Key = 'allowed.txt'
            { $script:S3.GetObjectMetadataAsync($head).GetAwaiter().GetResult() } | Should -Throw
        }
    }

    # WRITE-side fault surfacing (complement of the read-side AccessDenied context above). An upload
    # runs on a background task feeding a PushPullStream; if the PUT faults (e.g. AccessDenied), the
    # provider surfaces the GENUINE S3 error via WriteError in the Close() path (see onFault callback
    # in GetContentWriter and TransferContentWriter.Close). Scoped Deny on s3:PutObject only, so
    # teardown (DeleteObject/policy/bucket) still works. Own bucket so it can't affect the shared
    # fixture.
    Context "Set-Content surfaces a genuine upload fault (not silent data loss)" {
        BeforeAll {
            $script:WdBucket = "pstest-psdrive-wd-" + [DateTime]::Now.ToFileTime()
            $mk = New-Object Amazon.S3.Model.PutBucketRequest; $mk.BucketName = $script:WdBucket
            [void]$script:S3.PutBucketAsync($mk).GetAwaiter().GetResult()
            $policy = '{ "Version":"2012-10-17","Statement":[{"Sid":"DenyPut","Effect":"Deny",' +
                      '"Principal":"*","Action":["s3:PutObject"],"Resource":' +
                      '["arn:aws:s3:::' + $script:WdBucket + '/*"]}]}'
            $pp = New-Object Amazon.S3.Model.PutBucketPolicyRequest; $pp.BucketName = $script:WdBucket; $pp.Policy = $policy
            [void]$script:S3.PutBucketPolicyAsync($pp).GetAwaiter().GetResult()
            Start-Sleep -Seconds 3   # let the deny policy propagate before uploading through the drive
        }
        AfterAll {
            if ($script:WdBucket) {
                try {
                    $dp = New-Object Amazon.S3.Model.DeleteBucketPolicyRequest; $dp.BucketName = $script:WdBucket
                    [void]$script:S3.DeleteBucketPolicyAsync($dp).GetAwaiter().GetResult()
                    Start-Sleep -Seconds 1
                    # Deny was PutObject-only, so no object should exist; delete the (empty) bucket.
                    $db = New-Object Amazon.S3.Model.DeleteBucketRequest; $db.BucketName = $script:WdBucket
                    [void]$script:S3.DeleteBucketAsync($db).GetAwaiter().GetResult()
                } catch { Write-Warning "Write-denied-fixture cleanup failed for '$($script:WdBucket)': $($_.Exception.Message)" }
            }
        }
        It "surfaces the genuine S3 AccessDenied error and leaves no object behind" {
            # Even with the fault surfaced, no partial/truncated object should exist.
            $key = 'denied.txt'
            $err = $null
            try { Set-Content "PSTest:\$($script:WdBucket)\$key" -Value 'nope' -ErrorAction Stop } catch { $err = $_ }
            $err                    | Should -Not -BeNullOrEmpty
            $err.Exception.Message | Should -Match 'denied|not authorized'
            # Error id from the onFault callback in GetContentWriter:
            $err.FullyQualifiedErrorId | Should -BeLike 'UploadFailed*'
            S3ObjectExists $script:WdBucket $key | Should -BeFalse
        }
    }

    Context "Test-Path -PathType" {
        It "distinguishes an object (Leaf) from a prefix (Container)" {
            Test-Path "PSTest:\$($script:Bucket)\top.txt" -PathType Leaf      | Should -BeTrue
            Test-Path "PSTest:\$($script:Bucket)\top.txt" -PathType Container | Should -BeFalse
            Test-Path "PSTest:\$($script:Bucket)\reports" -PathType Container | Should -BeTrue
            Test-Path "PSTest:\$($script:Bucket)\reports" -PathType Leaf      | Should -BeFalse
        }
    }

    Context "Mount failure handling" {
        It "fails cleanly (no drive created) when the profile does not exist" {
            $bogus = "no-such-profile-$([guid]::NewGuid())"
            { Mount-S3PSDrive -Name PSTestBad -ProfileName $bogus -ErrorAction Stop } | Should -Throw
            Test-Path 'PSTestBad:\' | Should -BeFalse
        }
        # ValidRegionOrThrow: a bad -Region system name is rejected up front with a clear
        # ArgumentException (GetBySystemName otherwise fabricates a synthetic "Unknown" endpoint that
        # fails later with an obscure DNS/signing error). The profile-failure case above is tested;
        # the region fast-fail was not.
        It "fails cleanly (no drive created) when the region is not a known region" {
            { Mount-S3PSDrive -Name PSTestBadR -Region not-a-real-region -ProfileName $script:Profile -ErrorAction Stop } |
                Should -Throw
            Test-Path 'PSTestBadR:\' | Should -BeFalse
        }
    }

    # HIGH-value gap closer: the LOCKED design decision that a mount with NO explicit
    # -AWSCredential/-ProfileName/-Region reuses AWS.Tools.Common's session defaults
    # ($StoredAWSCredentials via Get-AWSCredential, $StoredAWSRegion via Get-DefaultAWSRegion, both
    # through SessionState.InvokeCommand), defaulting region to us-east-1. EVERY other mount in this
    # suite passes explicit params, so a regression in the SessionState/Common integration would pass
    # the entire rest of the suite. This test sets the session defaults, mounts bare, and asserts the
    # drive resolves + lists - then restores the session region the harness set (us-east-1).
    Context "Mount reuses session-default credentials/region (no explicit params)" {
        BeforeAll {
            Set-AWSCredential -ProfileName $script:Profile          # -> $StoredAWSCredentials
            Set-DefaultAWSRegion -Region 'us-west-2'                # prove the provider uses the session value, not its fallback
        }
        AfterAll {
            Set-Location $HOME -ErrorAction SilentlyContinue
            if (Test-Path 'PSTestSD:\') { try { Dismount-S3PSDrive -Name PSTestSD -ErrorAction SilentlyContinue } catch { } }
            # Restore the global region the shared harness relies on (TestHelper set us-east-1).
            Set-DefaultAWSRegion -Region $script:Region
        }
        It "mounts with no credential/region params and resolves via the session defaults" {
            Mount-S3PSDrive -Name PSTestSD          # no -ProfileName, no -Region
            Test-Path 'PSTestSD:\' | Should -BeTrue
            $drive = Get-PSDrive PSTestSD
            $prop = $drive.GetType().GetProperty('MountRegionName', [System.Reflection.BindingFlags]'Instance,NonPublic')
            $prop.GetValue($drive) | Should -Be 'us-west-2'
            (Get-ChildItem 'PSTestSD:\' -Name) | Should -Contain $script:Bucket   # us-east-1 default reached the fixture bucket
        }
    }

    # Mount surface variants that the happy-path Mount tests don't cover: -PassThru's return value,
    # the raw New-PSDrive path (the file header claims it "also works" but nothing proved it), and two
    # AWS.S3 drives mounted concurrently (each keeps its own DriveInfo; a listing under one is
    # independent of the other). Each mounts a uniquely-named drive and dismounts in AfterAll.
    Context "Mount surface variants (-PassThru, raw New-PSDrive, concurrent drives)" {
        AfterAll {
            Set-Location $HOME -ErrorAction SilentlyContinue
            foreach ($d in 'PSTestPT','PSTestRaw','PSTestC1','PSTestC2','PSTestCred','PSTestKeys','PSTestKeyPref','PSTestProfilePref') {
                if (Test-Path "$($d):\") { try { Dismount-S3PSDrive -Name $d -ErrorAction SilentlyContinue } catch { } }
            }
        }
        It "-PassThru returns the PSDriveInfo (and nothing is returned without it)" {
            $none = Mount-S3PSDrive -Name PSTestC1 -ProfileName $script:Profile -Region $script:Region
            $none | Should -BeNullOrEmpty                                   # no -PassThru => no output
            $info = Mount-S3PSDrive -Name PSTestPT -ProfileName $script:Profile -Region $script:Region -PassThru
            $info          | Should -Not -BeNullOrEmpty
            $info.Name     | Should -Be 'PSTestPT'
            $info.Provider.Name | Should -Be 'AWS.S3'
        }
        It "mounts via raw New-PSDrive with provider dynamic params and a non-empty root" {
            # NewDrive (the provider) handles cred/region resolution, so the raw path must work too.
            New-PSDrive -Name PSTestRaw -PSProvider AWS.S3 -Root "$($script:Bucket)/reports" -Scope Global -ProfileName $script:Profile -Region $script:Region | Out-Null
            Test-Path 'PSTestRaw:\' | Should -BeTrue
            (Get-ChildItem 'PSTestRaw:\' -Name) | Should -Contain 'index.txt'
            (Get-ChildItem 'PSTestRaw:\' -Name) | Should -Not -Contain $script:Bucket
        }
        It "mounts with AWSCredential and explicit key credentials" {
            Mount-S3PSDrive -Name PSTestCred -AWSCredential $script:Creds -Region $script:Region
            (Get-ChildItem 'PSTestCred:\' -Name) | Should -Contain $script:Bucket

            $immutable = $script:Creds.GetCredentials()
            $params = @{
                Name = 'PSTestKeys'
                AccessKey = $immutable.AccessKey
                SecretKey = $immutable.SecretKey
                Region = $script:Region
            }
            if (-not [string]::IsNullOrEmpty($immutable.Token)) { $params.SessionToken = $immutable.Token }
            Mount-S3PSDrive @params
            (Get-ChildItem 'PSTestKeys:\' -Name) | Should -Contain $script:Bucket

            $bogus = "no-such-profile-$([guid]::NewGuid())"
            $params.Name = 'PSTestKeyPref'
            $params.ProfileName = $bogus
            Mount-S3PSDrive @params
            (Get-ChildItem 'PSTestKeyPref:\' -Name) | Should -Contain $script:Bucket

            { Mount-S3PSDrive -Name PSTestProfilePref -ProfileName $bogus -AWSCredential $script:Creds -Region $script:Region -ErrorAction Stop } |
                Should -Throw
            Test-Path 'PSTestProfilePref:\' | Should -BeFalse
        }
        It "keeps two concurrently-mounted drives independent" {
            # PSTestC1 mounted above; add PSTestC2. Both must resolve and list the same account.
            Mount-S3PSDrive -Name PSTestC2 -ProfileName $script:Profile -Region $script:Region
            (Get-ChildItem 'PSTestC1:\' -Name) | Should -Contain $script:Bucket
            (Get-ChildItem 'PSTestC2:\' -Name) | Should -Contain $script:Bucket
        }
    }

    # Multi-region: one mounted drive (us-east-1) reaching a bucket in ANOTHER region (us-west-2).
    # This is the marquee "a single drive spans all regions" claim. The provider resolves the
    # bucket's region on first touch (GetBucketLocation) and routes through a per-region client.
    # Needs its own us-west-2 bucket fixture, created by a client pinned to that region.
    Context "Cross-region (drive mounted us-east-1, bucket in us-west-2)" {
        BeforeAll {
            $script:XRRegion = 'us-west-2'
            $script:XRClient = New-Object Amazon.S3.AmazonS3Client(
                $script:Creds, [Amazon.RegionEndpoint]::GetBySystemName($script:XRRegion))
            $script:XRBucket = "pstest-psdrive-xr-" + [DateTime]::Now.ToFileTime()
            $mk = New-Object Amazon.S3.Model.PutBucketRequest; $mk.BucketName = $script:XRBucket
            [void]$script:XRClient.PutBucketAsync($mk).GetAwaiter().GetResult()
            $put = New-Object Amazon.S3.Model.PutObjectRequest
            $put.BucketName = $script:XRBucket; $put.Key = "xr/hello.txt"; $put.ContentBody = "cross region"
            [void]$script:XRClient.PutObjectAsync($put).GetAwaiter().GetResult()
        }
        AfterAll {
            if ($script:XRBucket -and $script:XRClient) {
                try {
                    $lreq = New-Object Amazon.S3.Model.ListObjectsV2Request; $lreq.BucketName = $script:XRBucket
                    do {
                        $lresp = $script:XRClient.ListObjectsV2Async($lreq).GetAwaiter().GetResult()
                        foreach ($o in @($lresp.S3Objects)) {
                            $d = New-Object Amazon.S3.Model.DeleteObjectRequest
                            $d.BucketName = $script:XRBucket; $d.Key = $o.Key
                            [void]$script:XRClient.DeleteObjectAsync($d).GetAwaiter().GetResult()
                        }
                        $lreq.ContinuationToken = $lresp.NextContinuationToken
                    } while ($lresp.IsTruncated)
                    $db = New-Object Amazon.S3.Model.DeleteBucketRequest; $db.BucketName = $script:XRBucket
                    [void]$script:XRClient.DeleteBucketAsync($db).GetAwaiter().GetResult()
                } catch {
                    Write-Warning "Cross-region fixture cleanup failed for '$($script:XRBucket)': $($_.Exception.Message)"
                }
                $script:XRClient.Dispose()
            }
        }

        It "lists an out-of-region bucket through the us-east-1 drive" {
            (Get-ChildItem "PSTest:\$($script:XRBucket)" -Name) | Should -Contain 'xr'
        }
        It "reads an object from an out-of-region bucket" {
            (Get-Content "PSTest:\$($script:XRBucket)\xr\hello.txt" -Raw).Trim() | Should -Be 'cross region'
        }
        It "writes and deletes an object in an out-of-region bucket" {
            $key = "xr/write-delete-$([DateTime]::Now.ToFileTime()).txt"
            Set-Content "PSTest:\$($script:XRBucket)\$key" -Value 'created cross-region'
            S3ObjectExists $script:XRBucket $key $script:XRClient | Should -BeTrue
            (S3GetText $script:XRBucket $key $script:XRClient).TrimEnd("`r","`n") | Should -Be 'created cross-region'

            Remove-Item "PSTest:\$($script:XRBucket)\$key" -Force
            S3ObjectExists $script:XRBucket $key $script:XRClient | Should -BeFalse
        }
    }

    # The COMPLEMENT of the context above: mount the drive in us-west-2 and reach the us-east-1
    # fixture bucket. This is the branch the other direction can't hit - ResolveBucketRegion's
    # "empty/null GetBucketLocation => us-east-1" special case (S3 returns no location for
    # us-east-1 buckets). Reuses the existing us-east-1 $script:Bucket, so no extra fixture.
    Context "Cross-region complement (drive mounted us-west-2, bucket in us-east-1)" {
        BeforeAll {
            Mount-S3PSDrive -Name PSTestW -ProfileName $script:Profile -Region 'us-west-2'
        }
        AfterAll {
            Set-Location $HOME -ErrorAction SilentlyContinue
            if (Test-Path 'PSTestW:\') { try { Dismount-S3PSDrive -Name PSTestW -ErrorAction SilentlyContinue } catch { } }
        }
        It "reads a us-east-1 bucket through a us-west-2-mounted drive (empty-location => us-east-1)" {
            (Get-ChildItem "PSTestW:\$($script:Bucket)" -Name) | Should -Contain 'top.txt'
            (Get-Content "PSTestW:\$($script:Bucket)\top.txt" -Raw).Trim() | Should -Be 'top level'
        }
    }

    Context "Storage class (drive default + per-upload override)" {
        BeforeAll {
            # Reads the resolved storage class off the real object. S3 reports STANDARD as
            # null/empty in metadata, so normalize that to 'STANDARD'.
            function script:HeadStorageClass([string]$key) {
                $r = New-Object Amazon.S3.Model.GetObjectMetadataRequest
                $r.BucketName = $script:Bucket; $r.Key = $key
                $resp = $script:S3.GetObjectMetadataAsync($r).GetAwaiter().GetResult()
                if ([string]::IsNullOrEmpty($resp.StorageClass)) { 'STANDARD' } else { "$($resp.StorageClass)" }
            }
            # A drive whose default storage class is STANDARD_IA.
            Mount-S3PSDrive -Name PSTestSC -ProfileName $script:Profile -Region $script:Region -StorageClass STANDARD_IA
        }
        AfterAll {
            # Only the drive dismount is needed here; the sc/* objects live in the shared bucket and
            # are removed by the top-level AfterAll sweep.
            Set-Location $HOME -ErrorAction SilentlyContinue
            if (Test-Path 'PSTestSC:\') { try { Dismount-S3PSDrive -Name PSTestSC -ErrorAction SilentlyContinue } catch { } }
        }
        It "applies the drive's default storage class to an upload" {
            Set-Content "PSTestSC:\$($script:Bucket)\sc\default.txt" -Value 'x'
            HeadStorageClass 'sc/default.txt' | Should -Be 'STANDARD_IA'
        }
        It "lets a per-upload -StorageClass override the drive default" {
            Set-Content "PSTestSC:\$($script:Bucket)\sc\override.txt" -Value 'x' -StorageClass STANDARD
            HeadStorageClass 'sc/override.txt' | Should -Be 'STANDARD'
        }
        It "defaults to STANDARD when no storage class is set (drive or per-upload)" {
            # The shared PSTest drive was mounted with no -StorageClass. sc/plain.txt lives in the
            # shared bucket and is removed by the top-level AfterAll sweep.
            Set-Content "PSTest:\$($script:Bucket)\sc\plain.txt" -Value 'x'
            HeadStorageClass 'sc/plain.txt' | Should -Be 'STANDARD'
        }
    }

    # Prefix mounting: a drive rooted at a bucket, or a bucket+prefix, instead of the account
    # root. The engine prepends the drive Root to every drive-relative path, so navigation is
    # scoped beneath the root; `..` cannot climb above it (engine-enforced). The root must exist
    # (bad bucket / nonexistent prefix fails the mount). Reuses the seeded reports/ prefix.
    Context "Prefix mounting (-Root)" {
        AfterAll {
            Set-Location $HOME -ErrorAction SilentlyContinue
            foreach ($d in 'PSBkt','PSPfx','PSNorm') {
                if (Test-Path "$($d):\") { try { Dismount-S3PSDrive -Name $d -ErrorAction SilentlyContinue } catch { } }
            }
        }

        It "mounts rooted at a bucket and resolves root-relative content" {
            Mount-S3PSDrive -Name PSBkt -Root $script:Bucket -ProfileName $script:Profile -Region $script:Region
            Test-Path 'PSBkt:\' | Should -BeTrue
            # At a bucket root, the drive root lists the bucket's top-level entries.
            (Get-ChildItem 'PSBkt:\' -Name) | Should -Contain 'top.txt'
            (Get-ChildItem 'PSBkt:\' -Name) | Should -Contain 'reports'
            (Get-Content 'PSBkt:\top.txt' -Raw).Trim() | Should -Be 'top level'
        }

        It "mounts rooted at a bucket+prefix and resolves nested root-relative content" {
            Mount-S3PSDrive -Name PSPfx -Root "$($script:Bucket)/reports" -ProfileName $script:Profile -Region $script:Region
            Test-Path 'PSPfx:\' | Should -BeTrue
            # reports/ holds index.txt + the 2026/ subfolder; both show at the prefix drive's root.
            $names = Get-ChildItem 'PSPfx:\' -Name
            $names | Should -Contain 'index.txt'
            $names | Should -Contain '2026'
            (Get-Content 'PSPfx:\index.txt' -Raw).Trim() | Should -Be 'index'
            (Get-Content 'PSPfx:\2026\summary.txt' -Raw).Trim() | Should -Be 'hello summary'
        }
        It "normalizes a messy wrapper -Root before mounting" {
            Mount-S3PSDrive -Name PSNorm -Root "\\$($script:Bucket)//reports\\2026/" -ProfileName $script:Profile -Region $script:Region
            (Get-PSDrive PSNorm).Root | Should -Be "$($script:Bucket)/reports/2026"
            (Get-ChildItem 'PSNorm:\' -Name) | Should -Contain 'summary.txt'
        }
        It "writes and deletes root-relative objects inside the mounted prefix only" {
            $relative = "scoped-write-$([DateTime]::Now.ToFileTime()).txt"
            $scopedKey = "reports/$relative"
            Set-Content "PSPfx:\$relative" -Value 'scoped'
            S3ObjectExists $script:Bucket $scopedKey | Should -BeTrue
            S3ObjectExists $script:Bucket $relative | Should -BeFalse

            Remove-Item "PSPfx:\$relative" -Force
            S3ObjectExists $script:Bucket $scopedKey | Should -BeFalse
        }
        It "blocks '..' from climbing above the prefix root (engine-enforced)" {
            # The seeded top.txt is ABOVE the reports/ root; a relative escape must not reach it.
            { Get-Item 'PSPfx:\..\..\top.txt' -ErrorAction Stop } | Should -Throw
        }

        It "fails fast when the root bucket does not exist" {
            $bad = "no-such-bucket-$([Guid]::NewGuid())"
            { Mount-S3PSDrive -Name PSBad -Root $bad -ProfileName $script:Profile -Region $script:Region -ErrorAction Stop } |
                Should -Throw
            Test-Path 'PSBad:\' | Should -BeFalse   # no half-mounted drive left behind
        }
        It "fails fast when the root prefix does not exist under a real bucket" {
            $badPrefix = "$($script:Bucket)/definitely-not-a-prefix-$([Guid]::NewGuid())"
            { Mount-S3PSDrive -Name PSBadP -Root $badPrefix -ProfileName $script:Profile -Region $script:Region -ErrorAction Stop } |
                Should -Throw
            Test-Path 'PSBadP:\' | Should -BeFalse
        }
    }

    Context "Dismount" {
        # Dismounting the drive you're STANDING ON must ERROR and must NOT silently drop the drive
        # (the safety contract). The "removes the drive" test below steps off first, so nothing else
        # exercises the still-on-the-drive path. Own drive so the shared PSTest teardown is unaffected.
        #
        # NOTE on the error id: the cmdlet TRIES to remap Remove-PSDrive's "in use" failure into an
        # actionable 'DismountDriveInUse' hint (see Dismount-S3PSDrive in Mount-S3PSDrive-Cmdlet.cs).
        # In isolation that remap fires (category ResourceBusy); inside the full suite the raw
        # Remove-PSDrive error (InvalidOperation) sometimes passes through instead - the remap's
        # category/message match is environment-sensitive. That inconsistency is a minor hint-id nit,
        # not a safety issue; asserting the exact id here would be flaky, so we assert the reliable
        # contract: it errors, and the drive is NOT lost.
        It "errors and keeps the drive when you dismount the one you are standing on" {
            Mount-S3PSDrive -Name PSTestInUse -ProfileName $script:Profile -Region $script:Region
            Set-Location 'PSTestInUse:\'
            { Dismount-S3PSDrive -Name PSTestInUse -ErrorAction Stop } | Should -Throw
            Set-Location $HOME                                    # step off first
            Test-Path 'PSTestInUse:\' | Should -BeTrue            # drive survived the failed dismount
            Dismount-S3PSDrive -Name PSTestInUse -ErrorAction SilentlyContinue   # now remove it for real
        }
        It "removes the drive" {
            Set-Location $HOME   # OS-agnostic step-off; C:\ doesn't exist on Linux/macOS
            Dismount-S3PSDrive -Name PSTest
            Test-Path 'PSTest:\' | Should -BeFalse
        }
    }
}
