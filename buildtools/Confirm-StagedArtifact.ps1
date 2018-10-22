<#
.Synopsis
    Validates that the AWS Tools for PowerShell modules (AWSPowerShell and AWSPowerShell.NetCore) are
    both Authenticode signed and the module manifest has the expected version number.

.Description
    Validates that the built AWS Tools for PowerShell modules (for Windows PowerShell and PowerShell 6)
    are both Authenticode signed and have the expected version number in the module manifest and thus can
    be safely released.

.Notes
    The script must be run in a folder that contains subfolders holding the modules to be published
    (i.e. .\AWSPowerShell and .\AWSPowerShell.NetCore).

.Example
    Test-StagedArtifact -ExpectedVersion 3.3.283.0
#>
Param (
    # The expected version of the module. This will be verified against
    # the module manifest and the running binary.
    [Parameter(Mandatory=$true, Position=0)]
    [string]$ExpectedVersion
)

$modulesToTest = @(
    "AWSPowerShell"
    "AWSPowerShell.NetCore"
)

$authenticodeSignatureStart = 'SIG # Begin signature block'

function _validateModule([string]$modulePath) {
    Write-Host "Validating module $modulePath"

    $manifestPath = (Get-ChildItem -Path "$modulePath\*.psd1").FullName
    Write-Host "Verifying version in manifest $manifestPath"

    $manifest = Test-ModuleManifest $manifestPath
	$manifestVersion = $manifest.Version.ToString()
	Write-Host "Found version $manifestVersion"

    if ($manifestVersion -eq $ExpectedVersion)
    {
        Write-Host "...version check - PASS"
    }
    else
    {
        throw "Manifest has version $manifestVersion, not expected version $ExpectedVersion"
    }

    Write-Host "Verifying module files are Authenticode-signed"
    $filter = @("*.ps1","*.psm1","*.psd1","*.ps1xml")
    $signableFiles = Get-ChildItem -Path $modulePath\* -Include $filter | Select-Object -ExpandProperty Name

    $signableFiles | ForEach-Object {
        Write-Host "......testing module file $_"
        $fileToTest = Join-Path $modulePath $_
        if (!(Select-String -Path $fileToTest -Pattern $authenticodeSignatureStart -Quiet))
        {
            throw "Failed to locate start of Authenticode signature, $authenticodeSignatureStart, in module file $_."
        }
    }
    Write-Host "...module files signing check - PASS"

    # validate that the change log contains the expected version header in the first line
    $changelogFile = Join-Path $modulePath "CHANGELOG.txt"

    Write-Host "Verifying $changelogFile contains expected version details"
    $changelogHeader = Get-Content -TotalCount 1 -Path $changelogFile
    Write-Host "...inspecting latest changelog header: $changelogHeader"
    $headerParts = $changelogHeader.Split()
    if ($headerParts[1] -eq $ExpectedVersion)
    {
        Write-Host "...changelog file version check - PASS"
    }
    else
    {
        throw "Changelog does not appear to contain details of the new version"
    }
}

$modulesToTest | ForEach-Object {
    try {
        _validateModule $_
        Write-Host "PASSED validation for module $_"
    } catch {
        throw "FAILED validation for module $_, error $error"
    }
}
