<#
.Synopsis
    Builds a concise, de-duplicated version list for a set of modules.

.Description
    Returns the distinct version strings (including prerelease tags) for the supplied
    modules, joined for display and truncated to the configured MaxVersionsToShow so
    long lists do not flood the console. This is the single source of truth for the
    version-list formatting reused by Format-ModuleTarget (ShouldProcess targets) and
    by the install/uninstall console summaries.

.Parameter Modules
    Array of PSModuleInfo objects whose versions should be summarized. An empty
    collection yields an empty VersionList and a DistinctCount of 0.

.Example
    Get-ModuleVersionSummary -Modules $modules

    Returns an object whose VersionList is e.g. "5.0.10, 5.0.11" (or
    "5.0.10, 5.0.11, ... and 3 more" when more than MaxVersionsToShow versions exist).

.Notes
    Distinct versions preserve first-occurrence order, matching Format-ModuleTarget's
    prior Group-Object behaviour.
#>
function Get-ModuleVersionSummary {
    [CmdletBinding()]
    [OutputType([PSCustomObject])]
    param(
        [Parameter(Mandatory)]
        [AllowEmptyCollection()]
        [PSObject[]]$Modules
    )

    Process {
        # Distinct version strings (including prerelease tag), preserving first-occurrence order.
        $distinctVersions = @($Modules | ForEach-Object {
            if ($_.Version) { Get-ModuleVersionString -Module $_ } else { "Unknown" }
        } | Select-Object -Unique)

        $distinctVersionCount = $distinctVersions.Count

        # Limit version display to avoid noise when many versions exist.
        $maxVersionsToShow = $script:Config.general.MaxVersionsToShow

        if ($distinctVersionCount -le $maxVersionsToShow) {
            $versionList = $distinctVersions -join ', '
        } else {
            $displayedVersions = $distinctVersions | Select-Object -First $maxVersionsToShow
            $remainingCount = $distinctVersionCount - $maxVersionsToShow
            $versionList = "$($displayedVersions -join ', ') and $remainingCount more"
        }

        return [PSCustomObject]@{
            VersionList   = $versionList
            DistinctCount = $distinctVersionCount
        }
    }
}
