<#
.SYNOPSIS
    Sets up (or tears down) the S3 buckets and objects used by the S3 PowerShell drive bug bash.

.DESCRIPTION
    Testers run this against their OWN AWS account so they don't have to build the test tree by hand.

    IMPORTANT: this script seeds fixtures with the trusted S3 cmdlets (New-S3Bucket / Write-S3Object),
    NOT with the S3 drive under test. That keeps fixture setup independent of the feature being
    bug-bashed — a bug in the drive can't corrupt the starting state.

    It creates two buckets:
      * a PRIMARY bucket in -Region, seeded with a small known tree, and
      * a CROSS-REGION bucket in -CrossRegion, seeded with one object
        (for the "a single drive spans all Regions" scenarios).

    Bucket names are globally unique, so the script generates them and PRINTS them at the end — use
    those names in the bug-bash scenarios. Re-run with -Cleanup (and the SAME -BucketPrefix) to delete
    everything the setup created.

.PARAMETER ProfileName
    AWS credential profile to use. Omit to use whatever Set-AWSCredential / the default chain resolves.

.PARAMETER Region
    Region for the primary bucket. Default: us-east-1.

.PARAMETER CrossRegion
    Region for the cross-region bucket. Must differ from -Region. Default: us-west-2.

.PARAMETER BucketPrefix
    Prefix for the generated bucket names. Default: 'psdrive-bugbash'. The generated names are
    "<prefix>-<region>-<suffix>"; the suffix is derived so -Cleanup can find the same buckets.

.PARAMETER Cleanup
    Delete the buckets (and all their contents) that a prior setup created for this -BucketPrefix.

.EXAMPLE
    .\Setup-S3DriveBugBash.ps1 -ProfileName my-profile -Region us-east-1
    # Creates + seeds the buckets, then prints the bucket names to use in the scenarios.

.EXAMPLE
    .\Setup-S3DriveBugBash.ps1 -ProfileName my-profile -Region us-east-1 -Cleanup
    # Removes the buckets and everything in them.
#>
[CmdletBinding()]
param(
    [string] $ProfileName,
    [string] $Region      = 'us-east-1',
    [string] $CrossRegion = 'us-west-2',
    [string] $BucketPrefix = 'psdrive-bugbash',
    [switch] $Cleanup
)

$ErrorActionPreference = 'Stop'

if ($Region -eq $CrossRegion) {
    throw "-Region and -CrossRegion must differ (got '$Region' for both). The cross-region scenarios need a bucket in a different Region."
}

# The S3 cmdlets used for seeding live in AWS.Tools.S3 (or a monolithic module). Fail early if absent.
if (-not (Get-Command Write-S3Object -ErrorAction SilentlyContinue)) {
    throw "The AWS S3 cmdlets aren't loaded. Import AWS.Tools.S3 first (see the bug-bash doc's Installation section)."
}

# Common credential/region args threaded into every cmdlet call.
$commonArgs = @{}
if ($ProfileName) { $commonArgs['ProfileName'] = $ProfileName }

# Deterministic bucket names so -Cleanup targets the same buckets a prior setup made. The suffix is a
# stable hash of prefix + account identity (not a timestamp), so re-running setup/cleanup lines up.
# Bucket names must be lowercase, 3-63 chars, no underscores.
$identity =
    try { (Get-STSCallerIdentity @commonArgs -Region $Region).Account } catch { $env:USERNAME }
if ([string]::IsNullOrWhiteSpace($identity)) { $identity = 'anon' }
$suffix = ([System.BitConverter]::ToString(
    [System.Security.Cryptography.MD5]::Create().ComputeHash(
        [System.Text.Encoding]::UTF8.GetBytes("$BucketPrefix|$identity"))
) -replace '-','').Substring(0, 10).ToLowerInvariant()

$primaryBucket = ("{0}-{1}-{2}" -f $BucketPrefix, $Region, $suffix).ToLowerInvariant()
$xrBucket      = ("{0}-{1}-{2}" -f $BucketPrefix, $CrossRegion, $suffix).ToLowerInvariant()

# ----------------------------------------------------------------------------------------------------

if ($Cleanup) {
    Write-Host "Cleaning up bug-bash buckets..." -ForegroundColor Cyan
    foreach ($b in @(@{ Name = $primaryBucket; Region = $Region },
                     @{ Name = $xrBucket;      Region = $CrossRegion })) {
        try {
            if (Test-S3Bucket -BucketName $b.Name @commonArgs -Region $b.Region) {
                Remove-S3Bucket -BucketName $b.Name -DeleteBucketContent -Force @commonArgs -Region $b.Region | Out-Null
                Write-Host "  removed $($b.Name) ($($b.Region))"
            } else {
                Write-Host "  $($b.Name) ($($b.Region)) not found — skipping"
            }
        } catch {
            Write-Warning "  failed to remove $($b.Name): $($_.Exception.Message)"
        }
    }
    Write-Host "Cleanup done." -ForegroundColor Green
    return
}

# ---- Setup ----------------------------------------------------------------------------------------

function New-BucketIfMissing([string] $Name, [string] $Rgn) {
    if (Test-S3Bucket -BucketName $Name @commonArgs -Region $Rgn) {
        Write-Host "  bucket $Name already exists ($Rgn) — reusing"
    } else {
        New-S3Bucket -BucketName $Name @commonArgs -Region $Rgn | Out-Null
        Write-Host "  created bucket $Name ($Rgn)"
    }
}

function Set-TextObject([string] $Bucket, [string] $Rgn, [string] $Key, [string] $Text) {
    Write-S3Object -BucketName $Bucket -Key $Key -Content $Text @commonArgs -Region $Rgn | Out-Null
    Write-Host "    seeded $Key"
}

Write-Host "Setting up bug-bash fixtures..." -ForegroundColor Cyan

Write-Host "Primary bucket:" -ForegroundColor Cyan
New-BucketIfMissing $primaryBucket $Region
# A small known tree the navigation / read scenarios rely on.
Set-TextObject $primaryBucket $Region 'top.txt'                 'top level'
Set-TextObject $primaryBucket $Region 'reports/index.txt'       'index'
Set-TextObject $primaryBucket $Region 'reports/2026/summary.txt' 'hello summary'

# A small binary object for the Get-Content -AsByteStream read scenario. Written from a temp file via
# the trusted Write-S3Object -File path (no local file is left behind).
$tmp = [System.IO.Path]::GetTempFileName()
try {
    $bytes = New-Object byte[] 2048
    (New-Object System.Random 20260721).NextBytes($bytes)
    [System.IO.File]::WriteAllBytes($tmp, $bytes)
    Write-S3Object -BucketName $primaryBucket -Key 'images/logo.png' -File $tmp @commonArgs -Region $Region | Out-Null
    Write-Host "    seeded images/logo.png (2 KB binary)"
} finally {
    Remove-Item $tmp -ErrorAction SilentlyContinue
}

Write-Host "Cross-region bucket:" -ForegroundColor Cyan
New-BucketIfMissing $xrBucket $CrossRegion
Set-TextObject $xrBucket $CrossRegion 'xr/hello.txt' 'cross region'

Write-Host ""
Write-Host "Setup complete. Use these bucket names in the bug-bash scenarios:" -ForegroundColor Green
Write-Host ""
Write-Host "  Primary bucket (-Region $Region):        $primaryBucket" -ForegroundColor Yellow
Write-Host "  Cross-region bucket (-Region $CrossRegion): $xrBucket" -ForegroundColor Yellow
Write-Host ""
Write-Host "When you're done, tear it all down with:" -ForegroundColor Green
$cleanupCmd = ".\Setup-S3DriveBugBash.ps1 -Cleanup"
if ($ProfileName)                { $cleanupCmd += " -ProfileName $ProfileName" }
if ($Region -ne 'us-east-1')     { $cleanupCmd += " -Region $Region" }
if ($CrossRegion -ne 'us-west-2'){ $cleanupCmd += " -CrossRegion $CrossRegion" }
if ($BucketPrefix -ne 'psdrive-bugbash') { $cleanupCmd += " -BucketPrefix $BucketPrefix" }
Write-Host "  $cleanupCmd" -ForegroundColor Yellow
