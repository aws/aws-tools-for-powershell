function Invoke-WithExponentialBackoff {
  [CmdletBinding()]
  param (
    [Parameter(Mandatory)]
    [scriptblock]$ScriptBlock,
    
    [int]$MaxAttempts = 10,
    
    [int]$InitialDelaySeconds = 30,
    
    [int]$MaxDelaySeconds = 300,
    
    [double]$BackoffMultiplier = 2.0,
    
    [string]$ErrorMessage = "Operation failed after maximum retry attempts"
  )
  
  for ($attempt = 1; $attempt -le $MaxAttempts; $attempt++) {
    try {
      return & $ScriptBlock
    }
    catch {
      if ($attempt -eq $MaxAttempts) {
        throw "$ErrorMessage. $_"
      }
      
      $delay = [Math]::Min(
        $InitialDelaySeconds * [Math]::Pow($BackoffMultiplier, $attempt - 1),
        $MaxDelaySeconds
      )
      
      Write-Host "Attempt $attempt failed. Retrying in $delay seconds... $_"
      Start-Sleep -Seconds $delay
    }
  }
}

# Adds an AddAsReference="false" <Library> entry under <IncludeLibraries> in the generator manifest
# for each supplied H2-required service assembly name. This tells the cmdlet generator the service
# is intentionally excluded from generation, so its VerifyAllAssembliesHaveConfiguration pass does not
# fail for a service that has no <Service> config. The edit is additive and idempotent (existing
# entries are left untouched). Any failure to apply the entries (missing manifest, missing
# <IncludeLibraries> element, or malformed XML) throws to fail the build, because a skipped H2 service
# that is not allowlisted would otherwise fail the generator later with a less actionable error.
function Add-SkippedH2ServicesToGeneratorManifest {
  param(
    [string] $SkippedH2Services
  )

  if ([string]::IsNullOrWhiteSpace($SkippedH2Services)) {
    return
  }

  $assemblyNames = $SkippedH2Services.Split(',') | ForEach-Object { $_.Trim() } | Where-Object { $_ }
  if ($assemblyNames.Count -eq 0) {
    return
  }

  $manifestPath = './generator/AWSPSGeneratorLib/Config/Configs.xml'
  if (-not (Test-Path $manifestPath)) {
    throw "Generator manifest not found at $manifestPath. Cannot allowlist skipped H2 service(s): $($assemblyNames -join ', ')."
  }

  try {
    $resolvedPath = (Resolve-Path -LiteralPath $manifestPath).Path
    # PreserveWhitespace keeps the existing formatting so Save() does not re-indent the whole file;
    # the diff stays limited to the injected <Library> lines.
    $xml = New-Object System.Xml.XmlDocument
    $xml.PreserveWhitespace = $true
    $xml.Load($resolvedPath)

    $includeLibraries = $xml.SelectSingleNode('/ConfigModelCollection/IncludeLibraries')
    if ($null -eq $includeLibraries) {
      throw "<IncludeLibraries> element not found in $manifestPath. Cannot allowlist skipped H2 service(s): $($assemblyNames -join ', ')."
    }

    # Reuse the indentation whitespace that precedes an existing <Library> so injected entries match
    # the file's formatting, and insert before the trailing whitespace so the closing tag stays put.
    $sampleLibrary = $includeLibraries.SelectSingleNode('Library')
    if ($null -eq $sampleLibrary) {
      throw "No existing <Library> entry found in $manifestPath to derive indentation from. Cannot allowlist skipped H2 service(s): $($assemblyNames -join ', ')."
    }
    $indentNode = $sampleLibrary.PreviousSibling
    $closingWhitespace = $includeLibraries.LastChild

    $existingNames = @($includeLibraries.SelectNodes('Library') | ForEach-Object { $_.GetAttribute('Name') })
    $added = @()
    foreach ($assemblyName in $assemblyNames) {
      $libraryName = "AWSSDK.$assemblyName"
      if ($existingNames -contains $libraryName) {
        continue
      }
      $library = $xml.CreateElement('Library')
      $library.SetAttribute('Name', $libraryName)
      $library.SetAttribute('AddAsReference', 'false')
      $null = $includeLibraries.InsertBefore($indentNode.CloneNode($true), $closingWhitespace)
      $null = $includeLibraries.InsertBefore($library, $closingWhitespace)
      $added += $libraryName
    }

    if ($added.Count -gt 0) {
      $xml.Save($resolvedPath)
      Write-Host "Added generator allowlist entries for H2-required service(s): $($added -join ', ')"
    }
  }
  catch {
    throw "Failed to update generator manifest with skipped H2 services: $($_.Exception.Message)"
  }
}