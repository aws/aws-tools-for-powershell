[CmdletBinding()]
Param
(
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string]$NewDocsPath,

    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string]$DocsRepoPath,

    [Parameter(Mandatory = $false)]
    [bool]$FailOnRemovedFiles = $true
)

"Checking for missing documentation files"

[System.Collections.Generic.HashSet[string]]$generatedFiles =
    Get-ChildItem -Path $NewDocsPath -Recurse -File |
    ForEach-Object { [System.IO.Path]::GetRelativePath($NewDocsPath, $_.FullName) }
[string[]]$removedFiles =
    Get-ChildItem -Path $DocsRepoPath -Recurse -File |
    ForEach-Object { [System.IO.Path]::GetRelativePath($DocsRepoPath, $_.FullName) } |
    Where-Object { -not $generatedFiles.Contains($_) }

if ($removedFiles) {
    "Found missing documentation files, checking for redirects"

    [System.Collections.Generic.HashSet[string]]$redirectedPaths = 
        Get-Content ([System.IO.Path]::Combine($NewDocsPath, 'package.redirects.conf')) |
        Where-Object { $_ -match '^RewriteRule\s\^/powershell/latest/reference/(?<relativePath>[^\s]+)\s(?<newPath>[^\s]+)\s\[L,R\]$' } |
        ForEach-Object { $matches['relativePath'] }

    [string[]]$missingRedirects =
        $removedFiles |
        Where-Object { -not $redirectedPaths.Contains($_.Replace('\', '/')) }

    if ($missingRedirects) {
        if ($FailOnRemovedFiles) {
            throw "Missing documentation file $missingRedirects"
        }
        else {
            "Missing documentation file $missingRedirects"
        }
    }
}

"Checking for missing documentation files complete"