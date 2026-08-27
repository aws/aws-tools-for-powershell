<#
    Shared fixture for the S3 drive suites (S3.PSDrive.Tests.ps1 and
    S3.PSDrive.Extended.Tests.ps1). Dot-sourced from each suite's BeforeAll after the repo harness
    has set the credential profile, so both run against one identical bucket layout.
#>

function script:NewS3DriveFixture {
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

    function script:S3GetPartsCount([string]$bucket, [string]$key, $client = $null) {
        if (-not $client) { $client = $script:S3 }
        $req = New-Object Amazon.S3.Model.GetObjectMetadataRequest
        $req.BucketName = $bucket; $req.Key = $key; $req.PartNumber = 1
        $resp = $client.GetObjectMetadataAsync($req).GetAwaiter().GetResult()
        return $resp.PartsCount
    }

    # True if the object was uploaded multipart. S3 encodes the part count after a dash in the ETag
    # of a multipart object ("<md5>-<parts>"); a single PutObject gets a plain MD5 ETag with no dash.
    # This is how the write tests tell the writer's simple (PutObject) path from its streaming
    # multipart path without any SDK logging.
    function script:S3WasMultipart([string]$bucket, [string]$key, $client = $null) {
        if (-not $client) { $client = $script:S3 }
        $req = New-Object Amazon.S3.Model.GetObjectMetadataRequest
        $req.BucketName = $bucket; $req.Key = $key
        $resp = $client.GetObjectMetadataAsync($req).GetAwaiter().GetResult()
        return [bool]($resp.ETag -match '-\d+"?$')
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

function script:RemoveS3DriveFixture {
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
}
