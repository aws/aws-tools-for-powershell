<#
.Synopsis
    Copies the latest update release notes from the changelog file to the module manifest

.DESCRIPTION
    The release notes are read from the changelog file by reading until the first blank line is encountered.
    It is assumed that the validation script, Confirm-StagedArtifact.ps1 has been run previously to ensure
    the version indicated in the changelog header line for the notes matches the version of the module being
    published.

.NOTES
    The release notes are updated the Update-ModuleManifest cmdlet of the PowerShellGet module. This module
    must be installed (either in user scope or globally) before this script can be used.
#>

param (
    [string]$changelogFile,
    [string]$moduleManifestFile
)

Import-Module -Name "PowerShellGet"

function _getChangelogNotes([string]$changelog)
{
    $notes = ""

    $allNotes = Get-Content $changelog

    if (!$allNotes[0].StartsWith("### ")) {
        throw "Changelog file doesn't start with version line"
    }

    for ($i = 0; $i -le $allNotes.Length; $i++) {
        if ($allNotes[$i].Length -eq 0) {
            if (!$allNotes[$i + 1].StartsWith("### ")) {
                throw "Unexpected text line: " + $allNotes[$i + 1]
            }
            break
        } elseif ($i -ne 0 -and $allNotes[$i].StartsWith("#")) {
            throw "Changelog file missing empy line between versions"
        } else {
            $notes += $allNotes[$i].Replace("'","''")
            $notes += "`r`n"
        }
    }

    $notes
}


$changelogNotes = _getChangelogNotes $changelogFile
Write-Host "Changelog notes for the release:"
$changelogNotes

Write-Host ""

$content = [System.IO.File]::ReadAllText($moduleManifestFile).Replace("[RELEASE NOTES PLACEHOLDER]",$changelogNotes)
[System.IO.File]::WriteAllText($moduleManifestFile, $content)