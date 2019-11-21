[CmdletBinding() ]
param(
    [Parameter(mandatory = $true)]
    [string]$servicePrefix,
    [Parameter(mandatory = $true)]
    [string]$cmdletName
)

$fileName = ".\$servicePrefix\$cmdletName.xml"

New-Item -Type Directory -Name $servicePrefix -Confirm
New-Item -Type file -Name $fileName -Confirm

$content = @"
<?xml version="1.0" encoding="utf-8" ?>
<examples>
    <example>
        <code></code>
        <description></description>
    </example>
</examples>
"@ 

$content | Out-File -Append -FilePath $fileName -Encoding utf8 

