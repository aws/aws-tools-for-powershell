<#
    Slow/expensive halves of the S3 drive suite, split out of S3.PSDrive.Tests.ps1 so the daily
    lane stays fast. These transfer tens of MB, seed 1000+ objects, or need extra buckets and
    bucket-policy propagation waits.

    The Describe carries one "Disabled" tag, which the daily run excludes, so none of this runs
    there. The tag is on the Describe only - run this file directly, with no filter, and everything
    in it runs. Splitting it into its own named file is what keeps it discoverable, rather than
    tags scattered through the main suite where they are easy to miss.

    To run them:  Invoke-Pester ./S3/S3.PSDrive.Extended.Tests.ps1
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

    . (Join-Path $PSScriptRoot "S3.PSDrive.Fixture.ps1")
    NewS3DriveFixture
}

AfterAll {
    RemoveS3DriveFixture

    $helper.AfterAll()
    if ($script:OriginalLocation) {
        Set-Location -LiteralPath $script:OriginalLocation -ErrorAction SilentlyContinue
    }
}

Describe -Tag "Disabled" "S3 PowerShell drive provider (extended)" {

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

    # Slow: moves a >16MB object, so it exercises the TransferUtility MULTIPART paths on
    # both ends (upload via UploadUnseekableStreamAsync through the PushPullStream bridge; download
    # via OpenStreamWithResponseAsync with ranged multipart streaming). Small round-trips above only
    # need the SDK's first ranged download response. ~20MB.
    Context "Large-object multipart round-trip" {
        It "uploads and downloads a 20MB object byte-for-byte (SHA-256)" {
            $key = "large/multipart-$([DateTime]::Now.ToFileTime()).bin"
            # Deterministic 20MB payload (over the default multipart part size).
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

    Context "Small-write escalation to multipart" {
        # >=5 MiB must still escalate to multipart. The sub-threshold cases stay in the main suite.
        It "escalates <name> to multipart" -TestCases @(
            @{ name = '5 MiB (exactly at threshold)'; size = 5 * 1024 * 1024 }
            @{ name = '10 MiB';                        size = 10 * 1024 * 1024 }
        ) {
            param($name, $size)
            $key = "smallwrite/multi-$($size)-$([DateTime]::Now.ToFileTime()).bin"
            $path = "PSTest:\$($script:Bucket)\$key"
            $payload = [byte[]]::new($size)
            (New-Object System.Random ($size + 2)).NextBytes($payload)

            Set-Content $path -AsByteStream -Value $payload

            S3WasMultipart $script:Bucket $key | Should -BeTrue   # streaming multipart path
            $got = S3GetBytes $script:Bucket $key
            $got.Length | Should -Be $size
            $sha = [System.Security.Cryptography.SHA256]::Create()
            try {
                [BitConverter]::ToString($sha.ComputeHash($got)) |
                    Should -Be ([BitConverter]::ToString($sha.ComputeHash($payload)))
            } finally { $sha.Dispose() }
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

    Context "Multi-drive provider cmdlet resolution" {
        BeforeAll {
            $stamp = [DateTime]::Now.ToFileTime()
            $script:MDPrefix1 = "mdrive-one-$stamp"
            $script:MDPrefix2 = "mdrive-two-$stamp"
            S3PutText "$($script:MDPrefix1)/seed.txt" "seed one"
            S3PutText "$($script:MDPrefix2)/seed.txt" "seed two"
            Mount-S3PSDrive -Name PSTestMD1 -Root "$($script:Bucket)/$($script:MDPrefix1)" -ProfileName $script:Profile -Region $script:Region
            Mount-S3PSDrive -Name PSTestMD2 -Root "$($script:Bucket)/$($script:MDPrefix2)" -ProfileName $script:Profile -Region $script:Region
        }
        AfterAll {
            Set-Location $HOME -ErrorAction SilentlyContinue
            foreach ($d in 'PSTestMD1','PSTestMD2') {
                if (Test-Path "$($d):\") { try { Dismount-S3PSDrive -Name $d -ErrorAction SilentlyContinue } catch { } }
            }
        }

        It "keeps drive-qualified provider cmdlets scoped to their mounted root" {
            Set-Location 'PSTestMD1:\'
            try {
                Set-Content '.\shared.txt' -Value 'from md1' -NoNewline
                Set-Content 'PSTestMD2:\shared.txt' -Value 'from md2' -NoNewline

                Test-Path '.\shared.txt' | Should -BeTrue
                Test-Path 'PSTestMD2:\shared.txt' | Should -BeTrue
                (Get-Item '.\shared.txt').Type | Should -Be 'Object'
                (Get-Item 'PSTestMD2:\shared.txt').Type | Should -Be 'Object'
                (Get-ChildItem '.\' -Name) | Should -Contain 'shared.txt'
                (Get-ChildItem 'PSTestMD2:\' -Name) | Should -Contain 'shared.txt'
                (Get-Content '.\shared.txt' -Raw).TrimEnd("`r","`n") | Should -Be 'from md1'
                (Get-Content 'PSTestMD2:\shared.txt' -Raw).TrimEnd("`r","`n") | Should -Be 'from md2'

                (S3GetText $script:Bucket "$($script:MDPrefix1)/shared.txt").TrimEnd("`r","`n") | Should -Be 'from md1'
                (S3GetText $script:Bucket "$($script:MDPrefix2)/shared.txt").TrimEnd("`r","`n") | Should -Be 'from md2'

                Get-Content '.\shared.txt' -Raw | Set-Content 'PSTestMD2:\copied-from-md1.txt' -NoNewline
                (Get-Content 'PSTestMD2:\copied-from-md1.txt' -Raw).TrimEnd("`r","`n") | Should -Be 'from md1'
                (S3GetText $script:Bucket "$($script:MDPrefix2)/copied-from-md1.txt").TrimEnd("`r","`n") | Should -Be 'from md1'
                S3ObjectExists $script:Bucket "$($script:MDPrefix1)/copied-from-md1.txt" | Should -BeFalse

                Set-Content '.\tree\a.txt' -Value 'md1 tree' -NoNewline
                Set-Content 'PSTestMD2:\tree\a.txt' -Value 'md2 tree' -NoNewline
                Remove-Item '.\tree' -Recurse -Force
                Test-Path '.\tree\a.txt' | Should -BeFalse
                Test-Path 'PSTestMD2:\tree\a.txt' | Should -BeTrue
                S3ObjectExists $script:Bucket "$($script:MDPrefix1)/tree/a.txt" | Should -BeFalse
                (S3GetText $script:Bucket "$($script:MDPrefix2)/tree/a.txt").TrimEnd("`r","`n") | Should -Be 'md2 tree'

                Remove-Item 'PSTestMD2:\tree' -Recurse -Force
                S3ObjectExists $script:Bucket "$($script:MDPrefix2)/tree/a.txt" | Should -BeFalse

                Remove-Item '.\shared.txt' -Force
                Test-Path '.\shared.txt' | Should -BeFalse
                Test-Path 'PSTestMD2:\shared.txt' | Should -BeTrue
                S3ObjectExists $script:Bucket "$($script:MDPrefix1)/shared.txt" | Should -BeFalse
                S3ObjectExists $script:Bucket "$($script:MDPrefix2)/shared.txt" | Should -BeTrue

                Remove-Item 'PSTestMD2:\copied-from-md1.txt' -Force
                S3ObjectExists $script:Bucket "$($script:MDPrefix2)/copied-from-md1.txt" | Should -BeFalse

                Remove-Item 'PSTestMD2:\shared.txt' -Force
                Test-Path 'PSTestMD2:\shared.txt' | Should -BeFalse
                S3ObjectExists $script:Bucket "$($script:MDPrefix2)/shared.txt" | Should -BeFalse
            }
            finally {
                Set-Location $HOME -ErrorAction SilentlyContinue
            }
        }

        It "resolves provider-qualified paths by matching the mounted root" {
            Set-Content 'PSTestMD1:\roundtrip.txt' -Value 'from md1' -NoNewline
            Set-Content 'PSTestMD2:\roundtrip.txt' -Value 'from md2' -NoNewline
            $item = Get-ChildItem 'PSTestMD1:\' | Where-Object Name -eq 'roundtrip.txt' | Select-Object -First 1
            $item | Should -Not -BeNullOrEmpty
            $item.PSPath | Should -Match 'AWS\.S3::'

            (Get-Item -LiteralPath $item.PSPath -ErrorAction Stop).Type | Should -Be 'Object'
            (Get-Content -LiteralPath $item.PSPath -Raw -ErrorAction Stop).TrimEnd("`r","`n") | Should -Be 'from md1'
            Set-Content -LiteralPath $item.PSPath -Value 'changed md1' -NoNewline -ErrorAction Stop
            (S3GetText $script:Bucket "$($script:MDPrefix1)/roundtrip.txt").TrimEnd("`r","`n") | Should -Be 'changed md1'
            (S3GetText $script:Bucket "$($script:MDPrefix2)/roundtrip.txt").TrimEnd("`r","`n") | Should -Be 'from md2'

            Remove-Item -LiteralPath $item.PSPath -Force -ErrorAction Stop
            S3ObjectExists $script:Bucket "$($script:MDPrefix1)/roundtrip.txt" | Should -BeFalse
            S3ObjectExists $script:Bucket "$($script:MDPrefix2)/roundtrip.txt" | Should -BeTrue
            Remove-Item 'PSTestMD2:\roundtrip.txt' -Force
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
}
