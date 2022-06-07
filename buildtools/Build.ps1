param (
  [Parameter()]
  [ValidateNotNullOrEmpty()]
  [string] $RepositoryPath,

  [Parameter()]
  [string] $SdkArtifactsUri,

  [Parameter()]
  [ValidateNotNullOrEmpty()]
  [string] $Version,

  [Parameter()]
  [ValidateNotNullOrEmpty()]
  [string] $BuildType,

  [Parameter()]
  [string] $Configuration = 'Release',

  [Parameter()]
  [string] $Environment = 'DEV',

  [Parameter()]
  [string] $RequiredAWSPowerShellVersionToUse = '4.1.14.0',

  [Parameter()]
  [string] $SignModules = "true",

  [Parameter()]
  [string] $RunTests = "false",

  [Parameter()]
  [string] $RunAsStagingBuild = "false"
)

$ErrorActionPreference = "Stop"
$ProgressPreference = "SilentlyContinue"

Write-Host "Building PowerShell Version $Version"
Write-Host "Build type: $BuildType"
Write-Host "Repository path: $RepositoryPath"

Push-Location
try {
  Set-Location $RepositoryPath

  #Import S3
  if (-not (Get-Module -ListAvailable -Name AWS.Tools.S3 | Where-Object { $_.Version -eq $RequiredAWSPowerShellVersionToUse })) {
    Write-Host "Installing AWS.Tools.S3 $RequiredAWSPowerShellVersionToUse"
    Install-Module -Name AWS.Tools.S3 -RequiredVersion $RequiredAWSPowerShellVersionToUse -Force
  }
  Import-Module -Name AWS.Tools.S3 -RequiredVersion $RequiredAWSPowerShellVersionToUse

  $BuildResult = $null

  if ($BuildType -eq 'PREVIEW') {
    if ($SdkArtifactsUri) {
      $s3Uri = $null
      if (Test-Path -Path $SdkArtifactsUri -PathType Leaf) {
        Write-Host "Copying $SdkArtifactsUri"
        Copy-Item -literalPath $SdkArtifactsUri -Destination ./Include/sdk.zip -Force
      }
      elseif (-Not [Amazon.S3.Util.AmazonS3Uri]::TryParseAmazonS3Uri($SdkArtifactsUri, [ref] $s3Uri)) {
        Write-Host "Downloading $SdkArtifactsUri"
        Invoke-WebRequest -Uri $SdkArtifactsUri -OutFile ./Include/sdk.zip
      }
      else {
        Write-Host "Downloading $($s3Uri.Bucket) $($s3Uri.Key)"
        Read-S3Object -BucketName $s3Uri.Bucket -Key $s3Uri.Key -File ./Include/sdk.zip
      }

      Write-Host "Extracting sdk.zip"
      Expand-Archive ./Include/sdk.zip -DestinationPath ./Include/sdktmp -Force
      Remove-Item ./Include/sdktmp/assemblies/*/AWSSDK.Core.*
      Move-Item ./Include/sdktmp/assemblies ./Include/sdk/assemblies
      Remove-Item ./Include/sdktmp -Recurse
    }
    elseif ($Environment -eq "DEV") {
      Write-Host "WARNING: running preview build without specific SDK artifacts."
    }
    else {
      throw "ERROR: Preview build is missing specific SDK artifacts."
    }

    dotnet msbuild ./buildtools/build.proj /t:preview-build `
      /p:RunTests=$RunTests `
      /p:CleanSdkReferences=false `
      /p:BreakOnNewOperations=true `
      /p:Configuration=$Configuration
    $BuildResult = $LASTEXITCODE
  }
  elseif ($BuildType -eq 'RELEASE') {
    if ($SdkArtifactsUri) {
      Write-Host "Downloading $SdkArtifactsUri"
      $maxHttpGetAttempts = 10
      for ($i = 1; $i -le $maxHttpGetAttempts; $i++) {
        try {
          Invoke-WebRequest -Uri $SdkArtifactsUri -OutFile ./Include/sdk/_sdk-versions.json
          break
        }
        catch {
          if ($i -eq $maxHttpGetAttempts) {
            throw "Error retrieving versions file. $_"
          }
          Write-Host "Error downloading versions file, waiting for retry. $_"
          Start-Sleep -Seconds 30
        }
      }
    }
    elseif ($Environment -eq "DEV") {
      Write-Host "WARNING: running release build without specific SDK artifacts."
    }
    else {
      throw "ERROR: Release build is missing specific SDK artifacts."
    }

    if ($RunAsStagingBuild -eq 'true') {
      msbuild ./buildtools/build.proj `
        /t:staging-build `
        /p:Configuration=$Configuration
    }
    else {
      msbuild ./buildtools/build.proj `
        /t:full-build `
        /p:PatchNumber=$Version `
        /p:RunTests=$RunTests `
        /p:RunKeyScan=true `
        /p:Configuration=$Configuration `
        /p:SignModules=$SignModules `
        /p:DraftReleaseNotes=true `
        /p:SkipCmdletGeneration=false
    }
    $BuildResult = $LASTEXITCODE
  }
  else {
    #DRY_RUN | PULL_REQUEST
    throw "DRY_RUN | PULL_REQUEST are not supported. Type: ${BuildType}"
  }

  if ($BuildResult -ne 0) {
    throw "dotnet msbuild returned error $BuildResult"
  }
  else {
    Write-Host "Build complete!"
  }
}
finally {
  Pop-Location
}
