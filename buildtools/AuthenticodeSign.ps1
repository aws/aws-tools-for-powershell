<#
.Synopsis
    Authenticode-sign text-based script and module artifacts
.DESCRIPTION
    Authenticode-sign text-based script and module artifacts. Expects
    the following environment variables to be set on the build server 
    prior to use:
    DOTNET_BUILD_CERTFILE   				The path to the pfx file to sign with
    DOTNET_BUILD_CERTFILE_PASSWORD 			The encrypted password materials for the pfx (in KMS)
    DOTNET_BUILD_CERTFILE_PROFILE			The credential profile owning the KMS key for decryption
    DOTNET_BUILD_CERTFILE_PROFILE_LOCATION	Credential file holding the specified profile
    DOTNET_BUILD_CERTFILE_REGION			Region holding the decryption key materials
#>

Param
(
    # Root folder location of the AWSPowerShell module containing artifacts 
    # to be signed
    [string]$ModuleFolder
)

Function _getCertPasswordFromKMS
{
    $encryptedBytes = [System.Convert]::FromBase64String($env:DOTNET_BUILD_CERTFILE_PASSWORD)
	
    $encryptedMemoryStreamToDecrypt = New-Object System.IO.MemoryStream($encryptedBytes, 0, $encryptedBytes.Length)
    $decryptedMemoryStream = Invoke-KMSDecrypt -CiphertextBlob $encryptedMemoryStreamToDecrypt -ProfileName $env:DOTNET_BUILD_CERTFILE_PROFILE -ProfilesLocation $env:DOTNET_BUILD_CERTFILE_PROFILE_LOCATION -Region $env:DOTNET_BUILD_CERTFILE_REGION

    return [System.Text.Encoding]::UTF8.GetString($decryptedMemoryStream.Plaintext.ToArray())
}

$certPassword = _getCertPasswordFromKMS

# Get-PfxCertificate has no password parameter so use import
$cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2
$cert.Import($env:DOTNET_BUILD_CERTFILE,$certPassword,[System.Security.Cryptography.X509Certificates.X509KeyStorageFlags]"DefaultKeySet")

$signableExts = "*.ps1","*.psm1","*.psd1","*.ps1xml"
$artifactsToSign = Get-ChildItem -Path $ModuleFolder -Include $signableExts  -Recurse

foreach ($artifact in $artifactsToSign)
{
    Set-AuthenticodeSignature $artifact.FullName $cert     
}
