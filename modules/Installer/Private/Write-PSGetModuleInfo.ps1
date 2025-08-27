<#
.Synopsis
    Writes PSGetModuleInfo.xml content to a file for PowerShellGet compatibility.

.Description
    Creates a PSGetModuleInfo.xml file with the provided XML content and sets it as hidden.
    Ignores access denied errors if the file already exists.

.Parameter XmlContent
    The XML content to write to the PSGetModuleInfo.xml file.

.Parameter Path
    The full path where the PSGetModuleInfo.xml file should be created.
#>
function Write-PSGetModuleInfo {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [string]
        $XmlContent,

        [Parameter(Mandatory)]
        [string]
        $Path
    )

    Begin {
        Write-Debug "[$($MyInvocation.MyCommand)] Begin - Path=$Path"
    }

    Process {
        try {
            [System.IO.File]::WriteAllText($Path, $XmlContent, [System.Text.Encoding]::UTF8)
            $setItemPropertyParams = @{
                Path = $Path
                Name = 'Attributes'
                Value = [System.IO.FileAttributes]::Hidden
            }
            Set-ItemProperty @setItemPropertyParams
        }
        catch {
            # Ignore access denied errors if file already exists
            if ($_.Exception.Message -like "*Access to the path*is denied*" -and (Test-Path $Path)) {
                Write-Verbose ("PSGetModuleInfo.xml file already exists at $Path, " +
                    "ignoring access error")
                return
            }
            throw
        }
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
