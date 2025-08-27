<#
.Synopsis
    Generates PSGetModuleInfo.xml content for PowerShellGet compatibility.

.Description
    Creates XML content that mimics the PSGetModuleInfo.xml file structure used by PowerShellGet
    to track installed modules. This enables compatibility with Uninstall-Module and other 
    PowerShellGet cmdlets.

.Parameter PsdPath
    Path to the module manifest (.psd1) file to read module information from.

.Parameter PublishedDate
    The published date for the module. Defaults to current date.

.Parameter InstalledDate
    The installation date for the module. Defaults to current date.

.Parameter CompanyName
    The company name associated with the module. Defaults to "aws-dotnet-sdk-team".

.Parameter Repository
    The repository name where the module was published. Defaults to "PSGallery".

.Parameter RepositorySourceLocation
    The URL of the repository source. Defaults to PSGallery API v2 URL.

.Parameter InstalledLocation
    The installation location of the module. Defaults to the directory containing the manifest file.

.Parameter NormalizedVersion
    The normalized version string for the module.
#>
function New-PSGetModuleInfo {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]$PsdPath,

        [Parameter(Mandatory = $false)]
        [datetime]$PublishedDate = (Get-Date),

        [Parameter(Mandatory = $false)]
        [datetime]$InstalledDate = (Get-Date),

        [Parameter(Mandatory = $false)]
        [string]$CompanyName = $script:Config.general.ExpectedModuleCompanyName,

        [Parameter(Mandatory = $false)]
        [string]$Repository = $script:Config.general.PowerShellGallery.Repository,

        [Parameter(Mandatory = $false)]
        [string]$RepositorySourceLocation = $script:Config.general.PowerShellGallery.RepositorySourceLocation,

        [Parameter(Mandatory = $false)]
        [string]$InstalledLocation,

        [Parameter(Mandatory = $false)]
        [string]$NormalizedVersion
    )

    Begin {
        Write-Debug ("[$($MyInvocation.MyCommand)] Begin - PsdPath=$PsdPath " +
            "Repository=$Repository")
    }

    Process {
        # Import the .psd1 file
        $manifest = Import-PowerShellDataFile -Path $PsdPath

    # Extract module name and set default installed location
    $moduleName = [System.IO.Path]::GetFileNameWithoutExtension($PsdPath)
    if (-not $InstalledLocation) {
        $InstalledLocation = [System.IO.Path]::GetDirectoryName($PsdPath)
    }

    # Format description for XML
    $description = $manifest.Description -replace "`r`n", "_x000D__x000A_" `
        -replace "`n", "_x000D__x000A_"

    # Generate dependency XML if RequiredModules exist
    $dependencyXml = ""
    if ($manifest.RequiredModules -and $manifest.RequiredModules.Count -gt 0) {
        $depEntries = @()
        foreach ($dep in $manifest.RequiredModules) {
            if ($dep -is [string]) {
                $depName = $dep
            }
            else {
                # Handle different property names for module name
                if ($dep.ModuleName) {
                    $depName = $dep.ModuleName
                }
                else {
                    # Fallback to Name property or the object itself as a string
                    $depName = if ($dep.Name) { $dep.Name } else { $dep.ToString() }
                }
            }
            if ($dep -is [string]) {
                $depVersion = $manifest.ModuleVersion
            }
            else {
                if ($dep.RequiredVersion) {
                    $depVersion = $dep.RequiredVersion
                }
                elseif ($dep.ModuleVersion) {
                    $depVersion = $dep.ModuleVersion
                }
                else {
                    $depVersion = $manifest.ModuleVersion
                }
            }
            $depEntries += @"
          <Obj RefId="9">
            <TN RefId="4">
              <T>System.Collections.Specialized.OrderedDictionary</T>
              <T>System.Object</T>
            </TN>
            <DCT>
              <En>
                <S N="Key">Name</S>
                <S N="Value">$depName</S>
              </En>
              <En>
                <S N="Key">RequiredVersion</S>
                <S N="Value">$depVersion</S>
              </En>
              <En>
                <S N="Key">CanonicalId</S>
                <S N="Value">nuget:$depName/[$depVersion]</S>
              </En>
            </DCT>
          </Obj>
"@
        }
        $dependencyXml = $depEntries -join "`r`n"
    }

    # Generate cmdlet list XML
    $cmdletListXml = ($manifest.CmdletsToExport | 
        ForEach-Object { "                <S>$_</S>" }) -join "`r`n"

    # Generate tags string for AdditionalMetadata
    $allTags = @($manifest.PrivateData.PSData.Tags) + @("PSModule")
    $manifest.CmdletsToExport | ForEach-Object {
        $allTags += "PSCmdlet_$_"
        $allTags += "PSCommand_$_"
    }
    $allTags += "PSIncludes_Cmdlet"
    $tagsString = $allTags -join " "

    # Build AdditionalMetadata dynamically
    $metadataEntries = @()
    if ($manifest.Copyright) { 
        $metadataEntries += "          <S N=`"copyright`">$($manifest.Copyright)</S>" 
    }
    if ($manifest.Description) { 
        $metadataEntries += "          <S N=`"description`">$description</S>" 
    }
    $metadataEntries += "          <S N=`"requireLicenseAcceptance`">False</S>"
    if ($manifest.PrivateData.PSData.ReleaseNotes) { 
        $metadataEntries += ("          <S N=`"releaseNotes`">" +
            "$($manifest.PrivateData.PSData.ReleaseNotes)</S>")
    }
    if ($tagsString) { $metadataEntries += "          <S N=`"tags`">$tagsString</S>" }
    if ($manifest.CompanyName) { 
        $metadataEntries += "          <S N=`"CompanyName`">$($manifest.CompanyName)</S>" 
    }
    if ($manifest.GUID) { $metadataEntries += "          <S N=`"GUID`">$($manifest.GUID)</S>" }
    if ($manifest.PowerShellVersion) { 
        $metadataEntries += ("          <S N=`"PowerShellVersion`">" +
            "$($manifest.PowerShellVersion)</S>")
    }
    if ($manifest.DotNetFrameworkVersion) { 
        $metadataEntries += ("          <S N=`"DotNetFrameworkVersion`">" +
            "$($manifest.DotNetFrameworkVersion)</S>")
    }
    if ($NormalizedVersion) { 
        $metadataEntries += "          <S N=`"NormalizedVersion`">$NormalizedVersion</S>" 
    }
    $additionalMetadataXml = $metadataEntries -join "`r`n"

    # Generate XML content with retry logic for file access issues
    $xml = @"
<Objs Version="1.1.0.1" xmlns="http://schemas.microsoft.com/powershell/2004/04">
  <Obj RefId="0">
    <TN RefId="0">
      <T>Microsoft.PowerShell.Commands.PSRepositoryItemInfo</T>
      <T>System.Management.Automation.PSCustomObject</T>
      <T>System.Object</T>
    </TN>
    <MS>
      <S N="Name">$moduleName</S>
      <Version N="Version">$($manifest.ModuleVersion)</Version>
      <S N="Type">Module</S>
      <S N="Description">$description</S>
      <S N="Author">$($manifest.Author -replace ', Inc$', ' Inc')</S>
      <S N="CompanyName">$CompanyName</S>
      <S N="Copyright">$($manifest.Copyright)</S>
      <DT N="PublishedDate">$($PublishedDate.ToString("yyyy-MM-ddTHH:mm:ss.ffK"))</DT>
      <Obj N="InstalledDate" RefId="1">
        <DT>$($InstalledDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK"))</DT>
        <MS>
          <Obj N="DisplayHint" RefId="2">
            <TN RefId="1">
              <T>Microsoft.PowerShell.Commands.DisplayHintType</T>
              <T>System.Enum</T>
              <T>System.ValueType</T>
              <T>System.Object</T>
            </TN>
            <ToString>DateTime</ToString>
            <I32>2</I32>
          </Obj>
        </MS>
      </Obj>
      <Nil N="UpdatedDate" />
      <URI N="LicenseUri">$($manifest.PrivateData.PSData.LicenseUri)</URI>
      <URI N="ProjectUri">$($manifest.PrivateData.PSData.ProjectUri)</URI>
      <URI N="IconUri">$($manifest.PrivateData.PSData.IconUri)</URI>
      <Obj N="Tags" RefId="3">
        <TN RefId="2">
          <T>System.Object[]</T>
          <T>System.Array</T>
          <T>System.Object</T>
        </TN>
        <LST>
$($manifest.PrivateData.PSData.Tags | 
    ForEach-Object { "          <S>$_</S>" } | Out-String)          <S>PSModule</S>
        </LST>
      </Obj>
      <Obj N="Includes" RefId="4">
        <TN RefId="3">
          <T>System.Collections.Hashtable</T>
          <T>System.Object</T>
        </TN>
        <DCT>
          <En>
            <S N="Key">Cmdlet</S>
            <Obj N="Value" RefId="5">
              <TNRef RefId="2" />
              <LST>
$cmdletListXml
              </LST>
            </Obj>
          </En>
          <En>
            <S N="Key">DscResource</S>
            <Obj N="Value" RefId="6">
              <TNRef RefId="2" />
              <LST />
            </Obj>
          </En>
          <En>
            <S N="Key">RoleCapability</S>
            <Ref N="Value" RefId="6" />
          </En>
          <En>
            <S N="Key">Command</S>
            <Obj N="Value" RefId="7">
              <TNRef RefId="2" />
              <LST>
$cmdletListXml
              </LST>
            </Obj>
          </En>
          <En>
            <S N="Key">Workflow</S>
            <Ref N="Value" RefId="6" />
          </En>
          <En>
            <S N="Key">Function</S>
            <Ref N="Value" RefId="6" />
          </En>
        </DCT>
      </Obj>
      <Nil N="PowerShellGetFormatVersion" />
      <S N="ReleaseNotes">$($manifest.PrivateData.PSData.ReleaseNotes)</S>
      <Obj N="Dependencies" RefId="8">
        <TNRef RefId="2" />
        <LST>
$dependencyXml
        </LST>
      </Obj>
      <S N="RepositorySourceLocation">$RepositorySourceLocation</S>
      <S N="Repository">$Repository</S>
      <S N="PackageManagementProvider">NuGet</S>
      <Obj N="AdditionalMetadata" RefId="10">
        <TN RefId="5">
          <T>System.Management.Automation.PSCustomObject</T>
          <T>System.Object</T>
        </TN>
        <MS>
$additionalMetadataXml
        </MS>
      </Obj>
      <S N="InstalledLocation">$InstalledLocation</S>
    </MS>
  </Obj>
</Objs>
"@

        return $xml
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
