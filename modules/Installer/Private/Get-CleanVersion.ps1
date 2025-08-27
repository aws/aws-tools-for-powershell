<#
.Synopsis
    Normalizes version objects by replacing missing fields with zeros.

.Description
    PowerShell version objects can have missing fields (-1 values) which cause issues with
    version comparison and sorting. This function replaces any missing fields with 0.

.Parameter Version
    The version object to normalize. Can be null.

.Example
    Get-CleanVersion -Version "4.1"
    Returns [Version]"4.1.0.0"
#>
function Get-CleanVersion {
    Param(
        [Parameter(ValueFromPipelineByPropertyName, ValueFromPipeline, Mandatory, Position = 0)]
        [AllowNull()]
        [Version]
        $Version
    )

    Begin {
        Write-Debug "[$($MyInvocation.MyCommand)] Begin"
    }

    Process {
        if ($null -eq $Version) {
            $Version
        }
        else {
            [int]$major = $Version.Major
            [int]$minor = $Version.Minor
            [int]$build = $Version.Build
            [int]$revision = $Version.Revision

            # PowerShell modules version numbers can have missing fields, that would create
            # problems with matching and sorting versions. Replacing missing fields with 0s
            if ($major -lt 0) {
                $major = 0
            }
            if ($minor -lt 0) {
                $minor = 0
            }
            if ($build -lt 0) {
                $build = 0
            }
            if ($revision -lt 0) {
                $revision = 0
            }

            [Version]::new($major, $minor, $build, $revision)
        }
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
