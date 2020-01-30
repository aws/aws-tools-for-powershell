param (
  [Parameter()]
  [ValidateNotNullOrEmpty()]
  [string] $SdkArtifactsZipUri,

  [Parameter()]
  [ValidateNotNullOrEmpty()]
  [string] $RepositoryPath,
    
  [Parameter()]
  [ValidateNotNullOrEmpty()]
  [string] $BuildS3Bucket,

  [Parameter()]
  [ValidateNotNullOrEmpty()]
  [string] $S3Prefix,

  [Parameter()]
  [string] $S3OverridesKey,

  [Parameter()]
  [string] $S3OverridesVersion,

  [Parameter()]
  [string] $Configuration = 'Release',

  [Parameter()]
  [bool] $S3Download = $true,

  [Parameter()]
  [string] $AWSPowerShellVersion = '4.0.2.0'
)

Write-Host "Building $S3Prefix"

Set-Location $RepositoryPath

if (-not (Get-Module -ListAvailable -Name AWS.Tools.S3 | Where-Object { $_.Version -eq $AWSPowerShellVersion })) {
  Write-Host "Installing AWS.Tools.S3 $AWSPowerShellVersion"
  Install-Module -Name AWS.Tools.S3 -RequiredVersion $AWSPowerShellVersion -Force
}
Import-Module -Name AWS.Tools.S3 -RequiredVersion $AWSPowerShellVersion

If ($S3Download) {
  $s3Uri = $null
  if (-Not [Amazon.S3.Util.AmazonS3Uri]::TryParseAmazonS3Uri($SdkArtifactsZipUri, [ref] $s3Uri)) {
    Throw "Couldn't parse S3 URI $SdkArtifactsZipUri"
  }
  Write-Host "Downloading $($s3Uri.Bucket) $($s3Uri.Key)"
  Read-S3Object -BucketName $s3Uri.Bucket -Key $s3Uri.Key -File ./Include/sdk.zip
}
Else {
  Write-Host "Downloading $SdkArtifactsZipUri"
  Invoke-WebRequest -Uri $SdkArtifactsZipUri -OutFile ./Include/sdk.zip
}
Expand-Archive ./Include/sdk.zip -DestinationPath ./Include/sdk -Force

if ($S3OverridesKey) {
  Write-Host "Downloading $BuildS3Bucket $S3OverridesKey $S3OverridesVersion"
  Read-S3Object -BucketName $BuildS3Bucket -Key $S3OverridesKey -Version $S3OverridesVersion -File ./overrides.xml
}

dotnet msbuild ./buildtools/build.proj /t:preview-build /p:CleanSdkReferences=false /p:BreakOnNewOperations=true /p:Configuration=$Configuration
$BuildResult = $LASTEXITCODE

Write-Host "Saving new S3 artifacts in $BuildS3Bucket/$S3Prefix"

try {
  Write-S3Object -BucketName $BuildS3Bucket -Key "$S3Prefix/overrides.xml" -File ./report.xml
}
catch {
  Write-Host "Error uploading ./report.xml to S3: $($_.Exception)"
}

try {
  Write-S3Object -BucketName $BuildS3Bucket -Key "$S3Prefix/ReleaseNotesDraft.txt" -File ./ReleaseNotesDraft.txt
}
catch {
  Write-Host "Error uploading ./ReleaseNotesDraft.txt to S3: $($_.Exception)"
}

if ($BuildResult -ne 0) {
  throw "dotnet msbuild returned error $BuildResult"
}
else {
  Compress-Archive -Path ./Deployment/AWSPowerShell.NetCore -DestinationPath ./AWSPowerShell.NetCore.zip
  Write-S3Object -BucketName $BuildS3Bucket -Key "$S3Prefix/AWSPowerShell.NetCore.zip" -File ./AWSPowerShell.NetCore.zip
}

