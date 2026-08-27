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

    Context "Generated cmdlet help" {
        It "<Name> has a real synopsis and at least one example" -TestCases @(
            @{ Name = 'Mount-S3PSDrive' }
            @{ Name = 'Dismount-S3PSDrive' }
        ) {
            param($Name)

            $command = Get-Command $Name -ErrorAction Stop
            $repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '../..')).Path
            $moduleRoot = (Resolve-Path (Join-Path $repoRoot 'Deployment/AWSPowerShell.NetCore')).Path
            $command.Module.Path.StartsWith(
                $moduleRoot,
                [System.StringComparison]::OrdinalIgnoreCase) | Should -BeTrue

            $help = Get-Help $Name -Full
            $help.Synopsis | Should -Not -BeNullOrEmpty
            $help.Synopsis.Trim() | Should -Not -Be $Name
            @($help.Examples.Example).Count | Should -BeGreaterThan 0
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
        # Get-Item on the drive ROOT returns the SINGLE root item, NOT the whole bucket listing (that's
        # Get-ChildItem's job). Before the fix this branch enumerated ListBuckets and emitted one item
        # per bucket, so Get-Item and Get-ChildItem were identical at the root. The account-root item is
        # a synthesized container named after the drive (no backing S3 resource); buckets/prefixes are
        # unaffected (covered above).
        It "returns a single container item at the drive root (not the bucket listing)" {
            $root = @(Get-Item 'PSTest:\')
            $root.Count            | Should -Be 1        # one root item, not one-per-bucket
            $root[0].Type          | Should -Be 'Folder'
            $root[0].PSIsContainer | Should -BeTrue
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

    Context "Get-Content multipart download" {
        It "reads a large byte-stream object with default and custom download -PartSize" {
            $key = "download-multipart-$([DateTime]::Now.ToFileTime()).bin"
            $path = "PSTest:\$($script:Bucket)\$key"
            $size = 17 * 1024 * 1024
            $payload = New-Object byte[] $size
            (New-Object System.Random 20260727).NextBytes($payload)
            Set-Content $path -AsByteStream -Value $payload

            $got = [byte[]]((Get-Content $path -AsByteStream -Raw) | ForEach-Object { $_ })

            $got.Length | Should -Be $size
            $sha = [System.Security.Cryptography.SHA256]::Create()
            try {
                [BitConverter]::ToString($sha.ComputeHash($got)) |
                    Should -Be ([BitConverter]::ToString($sha.ComputeHash($payload)))

                $gotCustomPartSize = [byte[]]((Get-Content $path -AsByteStream -Raw -PartSize 5MB) | ForEach-Object { $_ })
                $gotCustomPartSize.Length | Should -Be $size
                [BitConverter]::ToString($sha.ComputeHash($gotCustomPartSize)) |
                    Should -Be ([BitConverter]::ToString($sha.ComputeHash($payload)))
            } finally {
                $sha.Dispose()
            }
        }

        It "rejects invalid download -PartSize values" {
            $key = "download-bad-partsize-$([DateTime]::Now.ToFileTime()).txt"
            $path = "PSTest:\$($script:Bucket)\$key"
            Set-Content $path -Value "content"

            { Get-Content $path -Raw -PartSize 10 -ErrorAction Stop } |
                Should -Throw
            { Get-Content $path -Raw -PartSize -1 -ErrorAction Stop } |
                Should -Throw
        }
    }


    # NOTE: a plain text round-trip and a small binary -AsByteStream round-trip used to live here.
    # Removed as redundant: the text round-trip is asserted incidentally by nearly every write test
    # (utf8, array-of-strings, trailing-newline, special-char keys), and the small binary round-trip
    # is subsumed by the 130KB content-stream copy and the 20MB multipart round-trip, both of which
    # verify byte-for-byte via SHA-256 (and every upload is multipart anyway, so there was no unique
    # single-part path to guard).


    # The writer buffers content and decides at Close: under SimpleUploadThreshold (5 MiB) it hands
    # TU a seekable stream so TU does a single PutObject; at or above it, it escalates to the
    # streaming multipart bridge. These tests pin both the byte-correctness of that decision and that
    # it actually engages, read from the stored object's ETag (see S3WasMultipart): a dashless ETag
    # means one PutObject, a dashed one means multipart. Only the sub-threshold cases live here; the
    # over-threshold ones transfer >=5 MiB and moved to S3.PSDrive.Extended.Tests.ps1.
    Context "Small-write single PutObject (buffer-then-decide)" {
        It "round-trips <name> as a single PutObject (no multipart)" -TestCases @(
            @{ name = '0 bytes';  size = 0 }
            @{ name = '1 byte';   size = 1 }
            @{ name = '1 KB';     size = 1024 }
            @{ name = '100 KB';   size = 100 * 1024 }
            @{ name = '4.9 MiB';  size = [int](4.9 * 1024 * 1024) }
        ) {
            param($name, $size)
            $key = "smallwrite/put-$($size)-$([DateTime]::Now.ToFileTime()).bin"
            $path = "PSTest:\$($script:Bucket)\$key"
            $payload = [byte[]]::new($size)
            if ($size -gt 0) { (New-Object System.Random ($size + 1)).NextBytes($payload) }

            Set-Content $path -AsByteStream -Value $payload

            S3WasMultipart $script:Bucket $key | Should -BeFalse   # single PutObject
            $got = S3GetBytes $script:Bucket $key
            $got.Length | Should -Be $size
            if ($size -gt 0) {
                $sha = [System.Security.Cryptography.SHA256]::Create()
                try {
                    [BitConverter]::ToString($sha.ComputeHash($got)) |
                        Should -Be ([BitConverter]::ToString($sha.ComputeHash($payload)))
                } finally { $sha.Dispose() }
            }
        }

        It "forwards -StorageClass on the simple path" {
            $key = "smallwrite/sc-$([DateTime]::Now.ToFileTime()).txt"
            Set-Content "PSTest:\$($script:Bucket)\$key" -Value 'sc' -StorageClass STANDARD_IA
            S3WasMultipart $script:Bucket $key | Should -BeFalse
            $req = New-Object Amazon.S3.Model.GetObjectMetadataRequest
            $req.BucketName = $script:Bucket; $req.Key = $key
            $resp = $script:S3.GetObjectMetadataAsync($req).GetAwaiter().GetResult()
            $resp.StorageClass.Value | Should -Be 'STANDARD_IA'
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
        # -Filter must scope a recursive delete to matching leaf names, exactly as Get-ChildItem
        # -Filter -Recurse does. Regression guard for a data-loss bug where RemoveItem ignored the
        # filter and deleted every object under the prefix, including non-matching ones and nested keys.
        It "removes only -Filter matches under -Recurse, leaving non-matching objects" {
            $prefix = "delfilter-$([DateTime]::Now.ToFileTime())"
            Set-Content "PSTest:\$($script:Bucket)\$prefix/a.log"        -Value "a"
            Set-Content "PSTest:\$($script:Bucket)\$prefix/keep.txt"     -Value "k"
            Set-Content "PSTest:\$($script:Bucket)\$prefix/sub/c.log"    -Value "c"
            Set-Content "PSTest:\$($script:Bucket)\$prefix/sub/keep2.txt" -Value "k2"

            Remove-Item "PSTest:\$($script:Bucket)\$prefix" -Filter *.log -Recurse

            # Assert via the raw client (bypasses provider caches). Only the .txt objects survive.
            S3ObjectExists $script:Bucket "$prefix/a.log"        | Should -BeFalse
            S3ObjectExists $script:Bucket "$prefix/sub/c.log"    | Should -BeFalse
            S3ObjectExists $script:Bucket "$prefix/keep.txt"     | Should -BeTrue
            S3ObjectExists $script:Bucket "$prefix/sub/keep2.txt" | Should -BeTrue
        }
        # No filter => the recursive delete still removes everything (the fix must not regress this).
        It "removes every object under -Recurse when no -Filter is given" {
            $prefix = "delnofilter-$([DateTime]::Now.ToFileTime())"
            Set-Content "PSTest:\$($script:Bucket)\$prefix/a.log"     -Value "a"
            Set-Content "PSTest:\$($script:Bucket)\$prefix/keep.txt"  -Value "k"
            Set-Content "PSTest:\$($script:Bucket)\$prefix/sub/b.txt" -Value "b"

            Remove-Item "PSTest:\$($script:Bucket)\$prefix" -Recurse

            S3PrefixObjectCount $script:Bucket "$prefix/" | Should -Be 0
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
        # All six unsupported operations now fail the SAME way: a PSNotSupportedException carrying the
        # "<Cmdlet> is not supported by the S3 drive. ..." shape. Before the fix New-Item/Copy/Move/
        # Rename fell through to the engine's generic "provider does not support this operation" and
        # Add-Content threw a bare System.NotSupportedException - three inconsistent styles. Lock the
        # consistency (message shape + exception type) so a regression can't reintroduce the drift.
        It "reports a consistent S3-specific PSNotSupportedException for all unsupported operations" {
            $b = $script:Bucket
            $key = "unsupported-consist-$([DateTime]::Now.ToFileTime()).txt"
            S3PutText $key 'original'
            $ops = @(
                { New-Item    "PSTest:\$b\uns-consist-$([DateTime]::Now.ToFileTime())" -ItemType Directory -ErrorAction Stop },
                { Copy-Item   "PSTest:\$b\$key" "PSTest:\$b\uns-copy.txt"   -ErrorAction Stop },
                { Move-Item   "PSTest:\$b\$key" "PSTest:\$b\uns-moved.txt"  -ErrorAction Stop },
                { Rename-Item "PSTest:\$b\$key" 'uns-renamed.txt'           -ErrorAction Stop },
                { Add-Content "PSTest:\$b\$key" -Value 'x'                  -ErrorAction Stop },
                { Clear-Content "PSTest:\$b\$key"                           -ErrorAction Stop }
            )
            foreach ($op in $ops) {
                $e = $null
                try { & $op } catch { $e = $_ }
                $e                       | Should -Not -BeNullOrEmpty
                $e.Exception             | Should -BeOfType [System.Management.Automation.PSNotSupportedException]
                $e.Exception.Message     | Should -Match 'is not supported by the S3 drive'
            }
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
        # An account-root mount (no -Root) MUST keep an empty Root. A "/" root would make the PowerShell
        # engine treat the drive's paths as filesystem-absolute and route a Set-Content to a not-yet-
        # existing key to the C: FileSystem provider ("Could not find a part of the path 'C:\...'"),
        # silently failing every new-object write. Guard both facts so that regression can't return:
        # the account-root Root stays empty, and writing a brand-new object through the account-root
        # drive lands in S3. `PSTest:\ -Recurse` is the supported recursive-list form; the bare
        # `PSTest: -Recurse` form is a known engine limitation and intentionally not asserted here.
        It "keeps an empty Root and writes new objects on an account-root mount" {
            (Get-PSDrive -Name PSTest).Root | Should -BeNullOrEmpty   # NOT "/": "/" breaks new-object writes

            $key = "acctroot-write-$([DateTime]::Now.ToFileTime()).txt"
            Set-Content "PSTest:\$($script:Bucket)\$key" -Value 'acct-root' -ErrorAction Stop
            S3ObjectExists $script:Bucket $key | Should -BeTrue   # raw HEAD: the write reached S3, not C:\

            @(Get-ChildItem 'PSTest:\' -Recurse -ErrorAction Stop | Select-Object -First 1).Count |
                Should -BeGreaterThan 0   # supported recursive-list form still works
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



    # Piping listed items straight into another provider cmdlet (Get-ChildItem | Get-Content /
    # | Remove-Item) binds each item's PSPath, which is PROVIDER-QUALIFIED
    # ("AWS.Tools.S3\AWS.S3::bucket\key"). The provider must emit a drive-INDEPENDENT
    # item path (bucket\key, not "S3:\...") and recover its S3DriveInfo when the engine resolves
    # that PSPath against the hidden drive - otherwise the pipe fails "Cannot find path ..." before
    # the content/remove op runs. Regression guard for that bug (it was invisible because earlier
    # tests only used literal-path strings, never piped Get-ChildItem output).
    Context "Pipe a listed item into another provider cmdlet (PSPath round-trip)" {
        AfterEach {
            foreach ($d in 'PSTestPipe2','PSTestPipeRoot','PSTestPipeSession') {
                if (Test-Path "$($d):\") { try { Dismount-S3PSDrive -Name $d -ErrorAction SilentlyContinue } catch { } }
            }
        }

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
        It "Get-ChildItem | Get-Content resolves listed PSPath when a second plain S3 drive is mounted" {
            $prefix = "pipe-read-mdrive-$([DateTime]::Now.ToFileTime())"
            Set-Content "PSTest:\$($script:Bucket)\$prefix/p1.txt" -Value 'one' -NoNewline
            Set-Content "PSTest:\$($script:Bucket)\$prefix/p2.txt" -Value 'two' -NoNewline
            Mount-S3PSDrive -Name PSTestPipe2 -ProfileName $script:Profile -Region $script:Region

            $prefixPath = "PSTest:\$($script:Bucket)\$prefix"
            (ListWhenReady $prefixPath 2).Count | Should -Be 2
            $got = @(
                Get-ChildItem $prefixPath |
                    Sort-Object Name |
                    ForEach-Object { Get-Content -LiteralPath $_.PSPath -Raw }
            )

            $got.Count | Should -Be 2
            $got | Should -Contain 'one'
            $got | Should -Contain 'two'
        }
        It "resolves listed PSPath across explicit and session-default mounts of the same profile" {
            $prefix = "pipe-read-session-$([DateTime]::Now.ToFileTime())"
            Set-Content "PSTest:\$($script:Bucket)\$prefix/p1.txt" -Value 'one' -NoNewline
            Set-Content "PSTest:\$($script:Bucket)\$prefix/p2.txt" -Value 'two' -NoNewline
            Set-AWSCredential -ProfileName $script:Profile
            Set-DefaultAWSRegion -Region $script:Region
            Mount-S3PSDrive -Name PSTestPipeSession

            $prefixPath = "PSTest:\$($script:Bucket)\$prefix"
            (ListWhenReady $prefixPath 2).Count | Should -Be 2
            $got = @(
                Get-ChildItem $prefixPath |
                    Sort-Object Name |
                    ForEach-Object { Get-Content -LiteralPath $_.PSPath -Raw -ErrorAction Stop }
            )

            $got.Count | Should -Be 2
            $got | Should -Contain 'one'
            $got | Should -Contain 'two'
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
        It "Get-ChildItem | Remove-Item resolves listed PSPath when a second rooted S3 drive is mounted" {
            $prefix = "pipe-del-mdrive-$([DateTime]::Now.ToFileTime())"
            S3PutText "$prefix/a.txt" "A"
            S3PutText "$prefix/b.txt" "B"
            Mount-S3PSDrive -Name PSTestPipeRoot -Root $script:Bucket -ProfileName $script:Profile -Region $script:Region

            $prefixPath = "PSTest:\$($script:Bucket)\$prefix"
            $items = ListWhenReady $prefixPath 2
            $items.Count | Should -Be 2
            $items | Remove-Item -Force

            $lr = New-Object Amazon.S3.Model.ListObjectsV2Request
            $lr.BucketName = $script:Bucket; $lr.Prefix = "$prefix/"
            $resp = $script:S3.ListObjectsV2Async($lr).GetAwaiter().GetResult()
            @($resp.S3Objects | Where-Object { $_ }).Count | Should -Be 0
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
        It "uses the default upload part size and honors -PartSize overrides" {
            $prefix = "shape-$([DateTime]::Now.ToFileTime())"
            $payload = New-Object byte[] (17 * 1024 * 1024)

            # Default part size is 5 MiB (matches TransferUtility's default), so 17 MiB is 4 parts.
            Set-Content "PSTest:\$($script:Bucket)\$prefix/default.bin" -AsByteStream -Value $payload
            S3GetPartsCount $script:Bucket "$prefix/default.bin" | Should -Be 4

            # A larger -PartSize produces fewer parts: 17 MiB at 16 MiB per part is 2.
            Set-Content "PSTest:\$($script:Bucket)\$prefix/custom.bin" -AsByteStream -Value $payload -PartSize 16MB
            S3GetPartsCount $script:Bucket "$prefix/custom.bin" | Should -Be 2
        }
        It "rejects a negative -PartSize without creating an object" {
            $key = "shape-$([DateTime]::Now.ToFileTime())/bad-part-size.bin"
            { Set-Content "PSTest:\$($script:Bucket)\$key" -AsByteStream -Value ([byte[]](1,2,3)) -PartSize -1 -ErrorAction Stop } |
                Should -Throw
            S3ObjectExists $script:Bucket $key | Should -BeFalse
        }
        It "creates a zero-byte object from an explicit empty byte array" {
            $key = "shape-$([DateTime]::Now.ToFileTime())/empty.bin"
            Set-Content "PSTest:\$($script:Bucket)\$key" -AsByteStream -Value ([byte[]]@())
            (S3GetBytes $script:Bucket $key).Length | Should -Be 0
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

    # A content op targeting an existing PREFIX (folder) must be refused (folder-wins), matching the
    # FileSystem provider. Before the fix, Set-Content on a prefix silently PUT a shadow object named
    # after the folder (invisible, unremovable by name), and Get-Content on a prefix surfaced the raw
    # SDK "specified key does not exist". Both now error with PathIsContainer and create nothing. Uses
    # the seeded reports/ tree (reports/index.txt), so 'reports' is unambiguously a folder.
    Context "Content ops reject a prefix (folder) path" {
        It "Set-Content on a prefix errors with PathIsContainer and creates no shadow object" {
            $ev = $null
            Set-Content "PSTest:\$($script:Bucket)\reports" -Value 'shadow' -ErrorVariable ev -ErrorAction SilentlyContinue
            $ev.Count                    | Should -BeGreaterThan 0
            $ev[0].FullyQualifiedErrorId | Should -BeLike 'PathIsContainer*'
            S3ObjectExists $script:Bucket 'reports' | Should -BeFalse   # raw HEAD: no shadow key created
        }
        It "Get-Content on a prefix errors with PathIsContainer, not the raw NoSuchKey message" {
            $ev = $null
            Get-Content "PSTest:\$($script:Bucket)\reports" -ErrorVariable ev -ErrorAction SilentlyContinue
            $ev.Count                    | Should -BeGreaterThan 0
            $ev[0].FullyQualifiedErrorId | Should -BeLike 'PathIsContainer*'
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

    # -Filter is a client-side wildcard on the LEAF name (provider declares ProviderCapabilities.Filter
    # and applies it at the emit sites in GetChildItems/GetChildNames), matching the FileSystem
    # provider. Before the fix the provider declared only ShouldProcess, so ANY -Filter (and the
    # positional `-Name <value>` form, whose value binds to -Filter since -Name is a switch) threw
    # "The provider does not support the use of filters." Uses a dedicated prefix so counts are exact.
    Context "Get-ChildItem -Filter (leaf-name wildcard)" {
        BeforeAll {
            $script:FltPrefix = "flt-$([DateTime]::Now.ToFileTime())"
            Set-Content "PSTest:\$($script:Bucket)\$($script:FltPrefix)/apple.txt"   -Value 'a'
            Set-Content "PSTest:\$($script:Bucket)\$($script:FltPrefix)/apricot.txt" -Value 'a'
            Set-Content "PSTest:\$($script:Bucket)\$($script:FltPrefix)/banana.txt"  -Value 'b'
            Set-Content "PSTest:\$($script:Bucket)\$($script:FltPrefix)/sub/deep.txt" -Value 'd'
        }
        AfterAll {
            Remove-Item "PSTest:\$($script:Bucket)\$($script:FltPrefix)" -Recurse -Force -ErrorAction SilentlyContinue
        }
        It "filters immediate children by wildcard (no 'does not support filters' error)" {
            $names = @(Get-ChildItem "PSTest:\$($script:Bucket)\$($script:FltPrefix)" -Filter 'ap*' -ErrorAction Stop).Name
            $names | Should -Contain 'apple.txt'
            $names | Should -Contain 'apricot.txt'
            $names | Should -Not -Contain 'banana.txt'
        }
        It "applies the filter to leaf names under -Recurse" {
            $matched = @(Get-ChildItem "PSTest:\$($script:Bucket)\$($script:FltPrefix)" -Filter '*.txt' -Recurse -ErrorAction Stop |
                Where-Object Type -eq 'Object')
            $matched.Count | Should -BeGreaterThan 0
            @(Get-ChildItem "PSTest:\$($script:Bucket)\$($script:FltPrefix)" -Filter 'zzz*' -Recurse -ErrorAction Stop |
                Where-Object Type -eq 'Object').Count | Should -Be 0
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
        # ResolveCredentials: AccessKey/SecretKey are a pair. A partial set (one key, or a SessionToken
        # without both) is a typo, not a request to fall back to the profile - silently doing so could
        # mount against the wrong account. Assert each partial shape throws and creates no drive.
        It "fails cleanly (no drive created) when only one of AccessKey/SecretKey is given" {
            { Mount-S3PSDrive -Name PSTestOnlyAK -AccessKey AKIAEXAMPLE -Region $script:Region -ErrorAction Stop } |
                Should -Throw
            Test-Path 'PSTestOnlyAK:\' | Should -BeFalse

            { Mount-S3PSDrive -Name PSTestOnlySK -SecretKey somesecret -Region $script:Region -ErrorAction Stop } |
                Should -Throw
            Test-Path 'PSTestOnlySK:\' | Should -BeFalse

            { Mount-S3PSDrive -Name PSTestOnlyST -SessionToken sometoken -Region $script:Region -ErrorAction Stop } |
                Should -Throw
            Test-Path 'PSTestOnlyST:\' | Should -BeFalse
        }
        # Invalid (not merely under-permissioned) credentials come back from S3 as a 403 too. They must
        # NOT be treated as "exists but inaccessible" - the mount validates against them and would
        # otherwise succeed. A well-formed-but-fake access key yields InvalidAccessKeyId; assert the
        # mount fails and no drive is left behind.
        It "fails cleanly (no drive created) when the credentials are invalid" {
            { Mount-S3PSDrive -Name PSTestBadKey -AccessKey AKIAIOSFODNN7EXAMPLE `
                    -SecretKey wJalrXUtnFEMIK7MDENGbPxRfiCYEXAMPLEKEY -Region $script:Region -ErrorAction Stop } |
                Should -Throw
            Test-Path 'PSTestBadKey:\' | Should -BeFalse
        }
        # -StorageClass is typed S3StorageClass (a ConstantClass that constructs from ANY string), so an
        # invalid value would otherwise mount silently and fail only later at the first upload. The
        # cmdlet validates it up front against the SDK's known values (InvalidStorageClass) and a valid
        # value still mounts.
        It "fails cleanly (no drive created) when -StorageClass is not a known class" {
            { Mount-S3PSDrive -Name PSTestBadSC -StorageClass NOT_A_CLASS `
                    -ProfileName $script:Profile -Region $script:Region -ErrorAction Stop } |
                Should -Throw
            Test-Path 'PSTestBadSC:\' | Should -BeFalse
        }
        It "accepts a valid -StorageClass" {
            Mount-S3PSDrive -Name PSTestGoodSC -StorageClass STANDARD_IA `
                -ProfileName $script:Profile -Region $script:Region
            Test-Path 'PSTestGoodSC:\' | Should -BeTrue
            Dismount-S3PSDrive -Name PSTestGoodSC
        }
        # Mounting an SSO profile whose token is expired/absent must surface the SAME guided message the
        # S3 cmdlets give ("...run Invoke-AWSSSOLogin") rather than the raw SDK "No valid SSO Token could
        # be found." / a generic NewDriveFailed. The provider calls the public
        # SettingsStore.ThrowIfSsoLoginRequired up front (mirrors ServiceCmdlet.ValidateSSOToken).
        # Reproduces without a real SSO account via a throwaway AWS_CONFIG_FILE with an uncached SSO
        # profile - IsSsoLoginRequiredAsync returns true when the token cache is empty.
        #
        # Runs in a CHILD pwsh with AWS_CONFIG_FILE preset: the SDK caches the config-file location
        # process-wide at first resolution, and this suite already resolved credentials (the shared
        # PSTest mount in BeforeAll), so an in-process AWS_CONFIG_FILE swap would be ignored. The child
        # imports the same monolithic module this suite uses (the SSO SDK assemblies ship with it).
        It "surfaces the guided Invoke-AWSSSOLogin error for an expired/absent SSO token" {
            $cfgDir = Join-Path ([System.IO.Path]::GetTempPath()) ("psdrive-sso-" + [DateTime]::Now.ToFileTime())
            New-Item -ItemType Directory -Path $cfgDir -Force | Out-Null
            $cfgFile = Join-Path $cfgDir 'config'
            @(
                '[profile probe-sso]'
                'sso_session = probe-session'
                'sso_account_id = 123456789012'
                'sso_role_name = ReadOnly'
                'region = us-east-1'
                ''
                '[sso-session probe-session]'
                'sso_region = us-east-1'
                'sso_start_url = https://example-does-not-resolve.awsapps.com/start'
                'sso_registration_scopes = sso:account:access'
            ) | Set-Content -Path $cfgFile -Encoding ascii

            # Resolve the module the SAME way the child must import it: reuse the module this suite
            # already loaded (Mount-S3PSDrive's source), so the path is correct regardless of where the
            # tests run from (repo `tests/` vs CI's copied `Deployment/Tests/`). A hardcoded relative
            # path broke here before - it pointed at the wrong depth and left $modulePath empty, so the
            # child failed with "Missing an argument for parameter 'ModulePath'".
            $modulePath = (Get-Command Mount-S3PSDrive -ErrorAction Stop).Module.Path
            if (-not $modulePath) { throw "Could not resolve the AWS module path for the SSO child process." }
            # Child: import the module, mount the uncached SSO profile, print a one-line verdict.
            $childScript = @'
param([string]$ModulePath)
$ErrorActionPreference = "Stop"
Import-Module $ModulePath -WarningAction SilentlyContinue
$ev = $null
Mount-S3PSDrive -Name PSTestSso -ProfileName probe-sso -Region us-east-1 -ErrorVariable ev -ErrorAction SilentlyContinue
if (Get-PSDrive -Name PSTestSso -ErrorAction SilentlyContinue) { "MOUNT_SUCCEEDED" }
elseif ($ev -and $ev.Count -gt 0) { "MOUNT_ERROR: " + $ev[0].Exception.Message }
else { "NO_ERROR_NO_DRIVE" }
'@
            $childFile = Join-Path $cfgDir 'child.ps1'
            Set-Content -Path $childFile -Value $childScript -Encoding ascii

            $oldCfg = $env:AWS_CONFIG_FILE
            $env:AWS_CONFIG_FILE = $cfgFile
            try {
                $out = & (Get-Process -Id $PID).Path -NoProfile -File $childFile -ModulePath $modulePath 2>&1 | Out-String
                $out | Should -Match 'Invoke-AWSSSOLogin'
                $out | Should -Not -Match 'MOUNT_SUCCEEDED'
            }
            finally {
                $env:AWS_CONFIG_FILE = $oldCfg
                Remove-Item -Recurse -Force $cfgDir -ErrorAction SilentlyContinue
            }
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
        It "returns one actionable error and keeps the drive when dismounting the current drive" {
            Mount-S3PSDrive -Name PSTestInUse -ProfileName $script:Profile -Region $script:Region
            Set-Location 'PSTestInUse:\'

            $dismountErrors = @()
            Dismount-S3PSDrive -Name PSTestInUse -ErrorAction SilentlyContinue -ErrorVariable +dismountErrors

            @($dismountErrors).Count | Should -Be 1
            $dismountErrors[0].FullyQualifiedErrorId |
                Should -Be 'DismountDriveInUse,Amazon.PowerShell.Cmdlets.S3.DismountS3PSDriveCmdlet'
            $dismountErrors[0].CategoryInfo.Category | Should -Be 'ResourceBusy'
            $dismountErrors[0].Exception.Message | Should -Be (
                "Cannot dismount drive 'PSTestInUse' because it is in use. " +
                "Change to a location outside the drive (for example, Set-Location `$HOME), " +
                "then retry Dismount-S3PSDrive -Name PSTestInUse.")

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
