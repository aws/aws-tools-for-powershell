using namespace System
using namespace System.Collections.Generic
using namespace System.IO
using namespace System.IO.Compression
using namespace System.Management.Automation
using namespace System.Net
using namespace System.Net.Http
using namespace System.Threading.Tasks

Microsoft.PowerShell.Core\Set-StrictMode -Version 3

$script:AWSToolsSignatureAmazonSubject = 'CN="Amazon.com, Inc.", O="Amazon.com, Inc.", L=Seattle, S=Washington, C=US'
$script:AWSToolsSignatureAwsSubject = 'CN="Amazon Web Services, Inc.", OU=AWS, O="Amazon Web Services, Inc.", L=Seattle, S=Washington, C=US'
$script:AWSToolsTempRepoName = 'AWSToolsTemp'
$script:CurrentMinAWSToolsInstallerVersion = '0.0.0.0'
$script:ExpectedModuleCompanyName = 'aws-dotnet-sdk-team'
$script:MaxModulesToFindIndividually = 3
$script:ParallelDownloaderClassCode = @"
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class ParallelDownloader
{
    private readonly HttpClient Client;
    private readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

    public ParallelDownloader(HttpClient client)
    {
        Client = client;
    }

    public async Task DownloadToFile(string uri, string filePath)
    {
        using (var httpResponseMessage = await Client.GetAsync(uri, CancellationTokenSource.Token))
        using (var stream = await httpResponseMessage.EnsureSuccessStatusCode().Content.ReadAsStreamAsync())
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await stream.CopyToAsync(fileStream, 81920, CancellationTokenSource.Token);
        }
    }

    public void Cancel()
    {
        CancellationTokenSource.Cancel();
    }
}
"@

function Get-CleanVersion {
    Param(
        [Parameter(ValueFromPipelineByPropertyName, ValueFromPipeline, Mandatory, Position = 0)]
        [AllowNull()]
        [Version]
        $Version
    )

    Process {
        if ($null -eq $Version) {
            $Version
        }
        else {
            [int]$major = $Version.Major
            [int]$minor = $Version.Minor
            [int]$build = $Version.Build
            [int]$revision = $Version.Revision

            #PowerShell modules version numbers can have missing fields, that would create problems with
            #matching and sorting versions. Replacing missing fields with 0s
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
}

function Get-AWSToolsModule {
    Param(
        [Parameter()]
        [Switch]
        $SkipIfInvalidSignature
    )

    Process {
        #Windows Powershell 5.1 has inconistent behavior where Get-Module could return nothing in %USERPROFILE%\Documents\WindowsPowerShell\Modules.
        [PSModuleInfo[]]$installedAwsToolsModules = Microsoft.PowerShell.Core\Get-Module -Name 'AWS.Tools.*' -ListAvailable -Verbose:$false

        if ($installedAwsToolsModules -and ($PSVersionTable.PSVersion.Major -lt 6 -or $IsWindows)) {
            $installedAwsToolsModules = $installedAwsToolsModules | Where-Object {
                [Signature]$signature = Microsoft.PowerShell.Security\Get-AuthenticodeSignature -FilePath $_.Path
                ($signature.Status -eq 'Valid' -or $SkipIfInvalidSignature) -and ($signature.SignerCertificate.Subject -eq $script:AWSToolsSignatureAmazonSubject -or $signature.SignerCertificate.Subject -eq $script:AWSToolsSignatureAwsSubject)
            }
        }

        if($installedAwsToolsModules) {
            $installedAwsToolsModules = $installedAwsToolsModules | Where-Object { $_.Name -ne 'AWS.Tools.Installer' }
        }

        $installedAwsToolsModules
    }
}

<#
.Synopsis
    Uninstalls all currently installed AWS.Tools modules.

.Description
    This cmdlet uses Uninstall-Module to uninstall all currently installed AWS.Tools
    modules.

.Notes

.Example
    Uninstall-AWSToolsModule -ExceptVersion 4.0.0.0

    This example uninstalls all versions of all AWS.Tools modules except for version 4.0.0.0.
#>
function Uninstall-AWSToolsModule {
    [CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'High')]
    Param(
        ## Specifies the minimum version of the modules to uninstall.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Version]
        $MinimumVersion,

        ## Specifies exact version number of the module to uninstall.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Version]
        $RequiredVersion,

        ## Specifies the maximum version of the modules to uninstall.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Version]
        $MaximumVersion,

        ## Specifies that you want to uninstall all of the other available versions of AWS Tools except this one.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Version]
        $ExceptVersion,

        ## Forces Uninstall-AWSToolsModule to run without asking for user confirmation
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $Force
    )

    Begin {
        $MinimumVersion = Get-CleanVersion $MinimumVersion
        $RequiredVersion = Get-CleanVersion $RequiredVersion
        $MaximumVersion = Get-CleanVersion $MaximumVersion
        $ExceptVersion = Get-CleanVersion $ExceptVersion

        Write-Verbose "[$($MyInvocation.MyCommand)] ConfirmPreference=$ConfirmPreference WhatIfPreference=$WhatIfPreference VerbosePreference=$VerbosePreference Force=$Force"
    }

    Process {
        $ErrorActionPreference = 'Stop'

        Write-Verbose "[$($MyInvocation.MyCommand)] Searching installed modules"
        [PSModuleInfo[]]$InstalledAwsToolsModules = Get-AWSToolsModule

        if ($MinimumVersion -and $InstalledAwsToolsModules) {
            $InstalledAwsToolsModules = $InstalledAwsToolsModules | Where-Object { $_.Version -ge $MinimumVersion }
        }
        if ($MaximumVersion -and $InstalledAwsToolsModules) {
            $InstalledAwsToolsModules = $InstalledAwsToolsModules | Where-Object { $_.Version -le $MaximumVersion }
        }
        if ($RequiredVersion -and $InstalledAwsToolsModules) {
            $InstalledAwsToolsModules = $InstalledAwsToolsModules | Where-Object { $_.Version -eq $RequiredVersion }
        }
        if ($ExceptVersion -and $InstalledAwsToolsModules) {
            $InstalledAwsToolsModules = $InstalledAwsToolsModules | Where-Object { $_.Version -ne $ExceptVersion }
        }

        if ($InstalledAwsToolsModules) {
            $versions = $InstalledAwsToolsModules | Group-Object Version

            if ($versions -and ($Force -or $WhatIfPreference -or $PSCmdlet.ShouldProcess("AWS Tools version $([string]::Join(', ', $versions.Name))"))) {
                $ConfirmPreference = 'None'

                $versions | ForEach-Object {
                    Write-Host "Uninstalling AWS.Tools version $($_.Name)"

                    [PSModuleInfo[]]$versionModules = $_.Group

                    while ($versionModules) {
                        [string[]]$dependencyNames = $versionModules | Select-Object -ExpandProperty RequiredModules | Select-Object -ExpandProperty Name | Sort-Object -Unique
                        if ($dependencyNames) {
                            [PSModuleInfo[]]$removableModules = $versionModules | Where-Object { -not $dependencyNames.Contains($_.Name) }
                        }
                        else {
                            [PSModuleInfo[]]$removableModules = $versionModules
                        }

                        if (-not $removableModules) {
                            Write-Error "Remaining modules for version $($_.Name) cannot be removed"
                            break
                        }
                        $removableModules | ForEach-Object {
                            if ($WhatIfPreference) {
                                Write-Host "What if: Uninstalling module $($_.Name)"
                            }
                            else {
                                Write-Host "Uninstalling module $($_.Name)"
                                #We need to use -Force to work around https://github.com/PowerShell/PowerShellGet/issues/542
                                $uninstallModuleParams = @{
                                    Name            = $_.Name
                                    RequiredVersion = $_.Version
                                    Force           = $true
                                    Confirm         = $false
                                    ErrorAction     = 'Continue'
                                }
                                PowerShellGet\Uninstall-Module @uninstallModuleParams
                            }
                        }

                        $versionModules = $versionModules | Where-Object { $_.Name -notin ($removableModules | Select-Object -ExpandProperty Name) }
                    }
                }
            }
        }
    }

    End {
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}

function Find-AWSToolsModule {
    Param(
        ## Specifies a proxy server for the request, rather than connecting directly to an internet resource.
        [Parameter(ValueFromPipelineByPropertyName, ValueFromPipeline, Mandatory, Position = 0)]
        [string[]]
        $Name,

        ## Specifies a proxy server for the request, rather than connecting directly to an internet resource.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Uri]
        $Proxy,

        ## Specifies a user account that has permission to use the proxy server specified by the Proxy parameter.
        [Parameter(ValueFromPipelineByPropertyName)]
        [PSCredential]
        $ProxyCredential
    )

    Begin {
        $RequiredVersion = Get-CleanVersion $RequiredVersion
        $MaximumVersion = Get-CleanVersion $MaximumVersion

        Write-Verbose "[$($MyInvocation.MyCommand)] ConfirmPreference=$ConfirmPreference WhatIfPreference=$WhatIfPreference VerbosePreference=$VerbosePreference Name=($Name)"
    }

    Process {
        $proxyParams = @{ }
        if ($Proxy) {
            $proxyParams['Proxy'] = $Proxy
        }
        if ($ProxyCredential) {
            $proxyParams['ProxyCredential'] = $ProxyCredential
        }

        [PSObject[]]$availableModules = @()
        [string[]]$missingModules = $Name

        #'Find-Module AWS.Tools.*' is only slightly slower than Find-Module for a single module
        if ($Name.Count -gt $script:MaxModulesToFindIndividually) {
            $availableModules += PowerShellGet\Find-Module -Name 'AWS.Tools.*' -Repository 'PSGallery' @proxyParams -ErrorAction 'Stop' | Where-Object { $_.Name -in $Name -and $_.CompanyName -ceq $script:ExpectedModuleCompanyName }
            $missingModules = $Name | Where-Object { $_ -notin ($availableModules | Select-Object -ExpandProperty Name) }
            if ($missingModules) {
                Write-Verbose "[$($MyInvocation.MyCommand)] Retrying Find-Module on ($missingModules)"
            }
        }

        if ($missingModules) {
            #'Find-Module AWS.Tools.*' doesn't always return all modules, so we have to retry missing ones
            $missingModules | ForEach-Object {
                $availableModules += PowerShellGet\Find-Module -Name $_ -Repository 'PSGallery' @proxyParams -ErrorAction 'Ignore' | Where-Object { $_.Name -in $Name -and $_.CompanyName -ceq $script:ExpectedModuleCompanyName }
            }

            $missingModules = $Name | Where-Object { $_ -notin ($availableModules | Select-Object -ExpandProperty Name) }
            if ($missingModules) {
                throw "Could not find AWS.Tools module on PSGallery: $([string]::Join(', ', $missingModules))."
            }
        }

        $availableModules
    }

    End {
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}

function Get-AWSToolsModuleDependenciesAndValidate {
    Param(
        ## Path of the manifest file to validate
        [Parameter(ValueFromPipelineByPropertyName, Mandatory)]
        [string]
        $Path,

        ## Name of the module to validate
        [Parameter(ValueFromPipelineByPropertyName, Mandatory)]
        [string]
        $Name
    )

    Begin {
        Write-Verbose "[$($MyInvocation.MyCommand)] ConfirmPreference=$ConfirmPreference WhatIfPreference=$WhatIfPreference VerbosePreference=$VerbosePreference Name=$Name Path=$Path"
    }

    Process {
        $ErrorActionPreference = 'Stop'

        Add-Type -AssemblyName System.IO.Compression.FileSystem -ErrorAction Stop
        Add-Type -AssemblyName System.IO.Compression -ErrorAction Stop

        [Stream]$manifestFileStream = $null
        [Stream]$entryStream = $null
        [ZipArchive]$zipArchive = $null
        [string]$temporaryManifestFilePath = $null

        try {
            $zipArchive = [ZipFile]::OpenRead($Path)
            [ZipArchiveEntry]$entry = $zipArchive.GetEntry("$($Name).psd1")
            $entryStream = $entry.Open()
            $temporaryManifestFilePath = Join-Path ([Path]::GetTempPath()) "$([Path]::GetRandomFileName()).psd1"
            $manifestFileStream = [File]::OpenWrite($temporaryManifestFilePath)
            $entryStream.CopyTo($manifestFileStream)
            $manifestFileStream.Close();

            if ($PSVersionTable.PSVersion.Major -lt 6 -or $IsWindows) {
                [Signature]$manifestSignature = Microsoft.PowerShell.Security\Get-AuthenticodeSignature -FilePath $temporaryManifestFilePath
                if ($manifestSignature.Status -eq 'Valid' -and ($manifestSignature.SignerCertificate.Subject -eq $script:AWSToolsSignatureAmazonSubject -or $manifestSignature.SignerCertificate.Subject -eq $script:AWSToolsSignatureAwsSubject)) {
                    Write-Verbose "[$($MyInvocation.MyCommand)] Manifest signature correctly validated"
                }
                else {
                    throw "Error validating manifest signature for $($Name)"
                }
            }
            else {
                Write-Verbose "[$($MyInvocation.MyCommand)] Authenticode signature can only be verified on Windows, skipping"
            }

            [PSObject]$manifestData = Microsoft.PowerShell.Utility\Import-PowerShellDataFile $temporaryManifestFilePath

            if ($manifestData.PrivateData.ContainsKey('MinAWSToolsInstallerVersion')) {
                [Version]$minVersion = Get-CleanVersion $manifestData.PrivateData.MinAWSToolsInstallerVersion
                if ($minVersion -gt $script:CurrentMinAWSToolsInstallerVersion) {
                    throw "$Name version $($manifestData.ModuleVersion) requires at least AWS.Tools.Installer version $minVersion. Run 'Update-Module AWS.Tools.Installer'."
                }
            }

            $manifestData.RequiredModules | ForEach-Object {
                Write-Verbose "[$($MyInvocation.MyCommand)] Found dependency $($_.ModuleName)"
                $_.ModuleName
            }
        }
        finally {
            if ($manifestFileStream) {
                $manifestFileStream.Dispose()
            }
            if ($entryStream) {
                $entryStream.Dispose()
            }
            if ($zipArchive) {
                $zipArchive.Dispose()
            }
            if ($temporaryManifestFilePath) {
                Microsoft.PowerShell.Management\Remove-Item -Path $temporaryManifestFilePath -WhatIf:$false
            }
        }
    }

    End {
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}

<#
.Synopsis
    Install AWS.Tools modules.

.Description
    This cmdlet uses Install-Module to install AWS.Tools modules.
    Unless -SkipUpdate is specified, this cmdlet also updates all other currently installed AWS.Tools modules to the version being installed.

.Notes
    This cmdlet uses the PSRepository named PSGallery as source.
    Use 'Get-PSRepository -Name PSGallery' for information on the PSRepository used by Update-AWSToolsModule.
    This cmdlet downloads all modules from https://www.powershellgallery.com/api/v2/package/ and considers it a trusted source.

.Example
    Install-AWSToolsModule EC2,S3 -RequiredVersion 4.0.0.0

    This example installs version 4.0.0.0 of AWS.Tools.EC2, AWS.Tools.S3 and their dependencies.
#>
function Install-AWSToolsModule {
    [CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'High')]
    Param(
        ## Specifies names of the AWS.Tools modules to install.
        ## The names can be listed either with or without the "AWS.Tools." prefix (i.e. "AWS.Tools.Common" or simply "Common").
        [Parameter(ValueFromPipelineByPropertyName, ValueFromPipeline, Mandatory, Position = 0)]
        [string[]]
        $Name,

        ## Specifies exact version number of the module to install.
        [Parameter(ValueFromPipelineByPropertyName, Position = 1)]
        [Version]
        $RequiredVersion,

        ## Specifies the minimum version of the modules to install.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Version]
        $MinimumVersion,

        ## Specifies the maximum version of the modules to install.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Version]
        $MaximumVersion,

        ## Specifies that, after a successful install, all other versions of the AWS Tools modules should be uninstalled.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $CleanUp,

        ## Install-AWSToolsModule by default also updates all currently installed AWS.Tools modules. -SkipUpdate disables the update.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $SkipUpdate,
		
        ## Allows skipping the publisher validation check.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $SkipPublisherCheck,		

        ## Specifies the installation scope of the module. The acceptable values for this parameter are AllUsers and CurrentUser.
        ## The AllUsers scope installs modules in a location that is accessible to all users of the computer:
        ##  $env:ProgramFiles\PowerShell\Modules
        ## The CurrentUser installs modules in a location that is accessible only to the current user of the computer:
        ##  $home\Documents\PowerShell\Modules
        ## When no Scope is defined, the default is CurrentUser.
        [Parameter(ValueFromPipelineByPropertyName)]
        [ValidateSet('CurrentUser', 'AllUsers')]
        [string]
        $Scope = 'CurrentUser',

        ## Overrides warning messages about installation conflicts about existing commands on a computer.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $AllowClobber,

        ## Specifies a proxy server for the request, rather than connecting directly to an internet resource.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Uri]
        $Proxy,

        ## Specifies a user account that has permission to use the proxy server specified by the Proxy parameter.
        [Parameter(ValueFromPipelineByPropertyName)]
        [PSCredential]
        $ProxyCredential,

        ## Forces an install of each specified module without a prompt to request confirmation
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $Force
    )

    Begin {
        $RequiredVersion = Get-CleanVersion $RequiredVersion
        $MaximumVersion = Get-CleanVersion $MaximumVersion

        Write-Verbose "[$($MyInvocation.MyCommand)] ConfirmPreference=$ConfirmPreference WhatIfPreference=$WhatIfPreference VerbosePreference=$VerbosePreference Force=$Force Name=($Name) RequiredVersion=$RequiredVersion SkipUpdate=$SkipUpdate CleanUp=$CleanUp"
    }

    Process {
        $ErrorActionPreference = 'Stop'

        $Name = $Name | ForEach-Object {
            if ($_.Contains('.')) {
                $_
            }
            else {
                "AWS.Tools.$_"
            }
        } | Sort-Object -Unique

        if ($Name -notlike 'AWS.Tools.*') {
            throw "The Name parameter must contain only AWS.Tools modules."
        }

        if ($Name -eq 'AWS.Tools.Installer') {
            throw "AWS.Tools.Installer cannot be used to install AWS.Tools.Installer. Use Update-Module instead."
        }

        [PSObject[]]$availableModulesToInstall = Find-AWSToolsModule -Name $Name -Proxy $Proxy -ProxyCredential $ProxyCredential

        [Version]$availableVersion = [Version[]]$availableModulesToInstall.Version | Measure-Object -Minimum | Select-Object -Expand Minimum

        if ($MinimumVersion -and $MinimumVersion -gt $availableVersion) {
            throw "The maximum version available is $availableVersion."
        }
        if ($RequiredVersion -and $RequiredVersion -gt $availableVersion) {
            throw "The maximum version available is $availableVersion."
        }
        if ($MinimumVersion -and $RequiredVersion -and $MinimumVersion -gt $RequiredVersion) {
            throw 'Parameter MinimumVersion is greater than RequiredVersion.'
        }
        if ($MaximumVersion -and $RequiredVersion -and $MaximumVersion -lt $RequiredVersion) {
            throw 'Parameter MaximumVersion is less than RequiredVersion.'
        }
        if ($MaximumVersion -and -not $RequiredVersion -and $MaximumVersion -lt $availableVersion) {
            $RequiredVersion = Find-Module -Name 'AWS.Tools.Common' -MaximumVersion $MaximumVersion | Select-Object -Expand Version
        }
        if (-not $RequiredVersion) {
            $RequiredVersion = $availableVersion
        }

        Write-Verbose "[$($MyInvocation.MyCommand)] Installing AWS Tools version $RequiredVersion"

        [string[]]$modulesToInstall = $availableModulesToInstall.Name

        if (-not $SkipUpdate) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Searching installed modules"
            [PSModuleInfo[]]$installedAwsToolsModules = Get-AWSToolsModule -SkipIfInvalidSignature
            if ($installedAwsToolsModules) {
                $modulesToInstall = ($modulesToInstall + ($installedAwsToolsModules | Select-Object -Expand Name)) | Sort-Object -Unique
                Write-Verbose "[$($MyInvocation.MyCommand)] Merging existing modules into the list of modules to install: ($modulesToInstall)"
            }
        }

        $modulesToInstall = $modulesToInstall | Where-Object { -not (Get-Module $_ -ListAvailable -Verbose:$false | Where-Object { $_.Version -eq $RequiredVersion }) }
        Write-Verbose "[$($MyInvocation.MyCommand)] Removing already installed modules from the. Final list of modules to install: ($modulesToInstall)"

        if ($modulesToInstall) {
            if ($Force -or $WhatIfPreference -or $PSCmdlet.ShouldProcess("AWS Tools version $RequiredVersion")) {
                $ConfirmPreference = 'None'

                [string]$temporaryRepoDirectory = Join-Path ([Path]::GetTempPath()) ([Path]::GetRandomFileName())
                Write-Verbose "[$($MyInvocation.MyCommand)] Create folder for temporary repository $temporaryRepoDirectory"
                Microsoft.PowerShell.Management\New-Item -ItemType Directory -Path $temporaryRepoDirectory -WhatIf:$false | Out-Null
                try {
                    if (-not $WhatIfPreference) {
                        PowerShellGet\Unregister-PSRepository -Name $script:AWSToolsTempRepoName -ErrorAction 'SilentlyContinue'
                        Write-Verbose "[$($MyInvocation.MyCommand)] Registering temporary repository $script:AWSToolsTempRepoName"
                        PowerShellGet\Register-PSRepository -Name $script:AWSToolsTempRepoName -SourceLocation $temporaryRepoDirectory -ErrorAction 'Stop'
                        PowerShellGet\Set-PSRepository -Name $script:AWSToolsTempRepoName -InstallationPolicy Trusted
                    }

                    Add-Type -AssemblyName System.Net.Http -ErrorAction Stop

                    [HttpClient]$httpClient = $null
                    [HttpClientHandler]$httpClientHandler = $null
                    [List[PSCustomObject]]$tasks = @()

                    Write-Verbose "[$($MyInvocation.MyCommand)] Downloading modules to temporary repository"
                    try {
                        $httpClientHandler = [HttpClientHandler]::new()
                        if ($Proxy) {
                            $httpClientHandler.Proxy = [WebProxy]::new($Proxy)
                            if ($ProxyCredential) {
                                $httpClientHandler.Proxy.Credentials = $ProxyCredential.GetNetworkCredential()
                            }
                        }
                        $httpClient = [HttpClient]::new($httpClientHandler);

                        Add-Type $script:ParallelDownloaderClassCode -ReferencedAssemblies System.Net.Http,System.Threading.Tasks
                        [ParallelDownloader]$parallelDownloader = [ParallelDownloader]::new($httpClient)

                        [string[]]$modulesToDownload = $modulesToInstall
                        [HashSet[string]]$savedModules = New-Object -TypeName System.Collections.Generic.HashSet[string]

                        Write-Verbose "[$($MyInvocation.MyCommand)] Downloading modules ($modulesToDownload)"

                        while ($modulesToDownload) {
                            [string[]]$dependencies = @()

                            $tasks = $modulesToDownload | Where-Object { $savedModules.Add($_) } | ForEach-Object {
                                [string]$nupkgFilePath = Join-Path $temporaryRepoDirectory "$_.$($RequiredVersion).nupkg"
                                Write-Verbose "[$($MyInvocation.MyCommand)] Downloading module $_ to $TemporaryRepoDirectory"
                                [PSCustomObject]@{
                                    Task       = $parallelDownloader.DownloadToFile("https://www.powershellgallery.com/api/v2/package/$_/$RequiredVersion", $nupkgFilePath)
                                    ModuleName = $_
                                    Path       = $nupkgFilePath
                                }
                            }
                            while ($tasks) {
                                [int]$taskIndex = [Task]::WaitAny($tasks.Task)
                                [PSObject]$task = $tasks[$taskIndex]
                                $tasks.RemoveAt($taskIndex)
                                if ($task.Task.IsCompleted) {
                                    $dependencies += Get-AWSToolsModuleDependenciesAndValidate -Path $task.Path -Name $task.ModuleName
                                } else {
                                    throw "Error downloading $($task.ModuleName): $($task.Task.Exception)"
                                }
                            }

                            $modulesToDownload = $dependencies | Sort-Object -Unique
                        }
                    }
                    finally {
                        if ($tasks) {
                            Write-Verbose "[$($MyInvocation.MyCommand)] Cancelling $($tasks.Count) tasks"
                            $parallelDownloader.Cancel()
                            try {
                                [Task]::WaitAll($tasks.Task)
                            } catch {

                            }
                        }

                        if ($httpClient) {
                            $httpClient.Dispose()
                        }
                        if ($httpClientHandler) {
                            $httpClientHandler.Dispose()
                        }
                    }

                    Write-Verbose "[$($MyInvocation.MyCommand)] Installing modules ($modulesToInstall)"
                    $installModuleParams = @{
                        RequiredVersion = $RequiredVersion
                        Scope           = $Scope
                        Repository      = $script:AWSToolsTempRepoName
                        AllowClobber    = $AllowClobber
                        Confirm         = $false
                        ErrorAction     = 'Stop'
						SkipPublisherCheck = $SkipPublisherCheck
                    }
                    $modulesToInstall | ForEach-Object {
                        if (-not $WhatIfPreference) {
                            Write-Host "Installing module $_ version $RequiredVersion"
                            PowerShellGet\Install-Module -Name $_ @installModuleParams
                        }
                        else {
                            Write-Host "What if: Installing module $_ version $RequiredVersion"
                        }
                    }
                    Write-Verbose "[$($MyInvocation.MyCommand)] Modules install complete"
                }
                finally {
                    if (-not $WhatIfPreference) {
                        Write-Verbose "[$($MyInvocation.MyCommand)] Unregistering temporary repository $script:AWSToolsTempRepoName"
                        PowerShellGet\Unregister-PSRepository -Name $script:AWSToolsTempRepoName -ErrorAction 'Continue'
                    }
                    Write-Verbose "[$($MyInvocation.MyCommand)] Delete repository folder $temporaryRepoDirectory"
                    Microsoft.PowerShell.Management\Remove-Item -Path $temporaryRepoDirectory -Recurse -WhatIf:$false
                }
            }
        }
        else {
            Write-Verbose "[$($MyInvocation.MyCommand)] All modules are up to date"
        }

        if ($CleanUp) {
            Uninstall-AWSToolsModule -ExceptVersion $RequiredVersion
        }
    }

    End {
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}

<#
.Synopsis
    Updates all currently installed AWS.Tools modules.

.Description
    This cmdlet uses Install-Module to update all AWS.Tools modules.

.Notes
    This cmdlet uses the PSRepository named PSGallery as source.
    Use 'Get-PSRepository -Name PSGallery' for information on the PSRepository used by Update-AWSToolsModule.
    This cmdlet downloads all modules from https://www.powershellgallery.com/api/v2/package/ and considers it a trusted source.

.Example
    Update-AWSToolsModule -CleanUp

    This example updates all installed AWS.Tools modules to the latest version available on the PSGallery and uninstalls all other versions.
#>
function Update-AWSToolsModule {
    [CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'High')]
    Param(
        ## Specifies the exact version of the modules to update to.
        [Parameter(ValueFromPipelineByPropertyName, Position = 0)]
        [Version]
        $RequiredVersion,

        ## Specifies the maximum version of the modules to update to.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Version]
        $MaximumVersion,

        ## Specifies that, after a successful install, all other versions of the AWS Tools modules should be uninstalled.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $CleanUp,
		
        ## Allows skipping the publisher validation check.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $SkipPublisherCheck,			

        #Specifies the installation scope of the module. The acceptable values for this parameter are AllUsers and CurrentUser.
        #The AllUsers scope installs modules in a location that is accessible to all users of the computer:
        # $env:ProgramFiles\PowerShell\Modules
        #The CurrentUser installs modules in a location that is accessible only to the current user of the computer:
        # $home\Documents\PowerShell\Modules
        #When no Scope is defined, the default is CurrentUser.
        [Parameter(ValueFromPipelineByPropertyName)]
        [ValidateSet('CurrentUser', 'AllUsers')]
        [string]
        $Scope = 'CurrentUser',

        #Overrides warning messages about installation conflicts about existing commands on a computer.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $AllowClobber,

        #Specifies a proxy server for the request, rather than connecting directly to an internet resource.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Uri]
        $Proxy,

        ## Specifies a user account that has permission to use the proxy server specified by the Proxy parameter.
        [Parameter(ValueFromPipelineByPropertyName)]
        [PSCredential]
        $ProxyCredential,

        ## Forces an update of each specified module without a prompt to request confirmation
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $Force
    )

    Begin {
        $RequiredVersion = Get-CleanVersion $RequiredVersion
        $MaximumVersion = Get-CleanVersion $MaximumVersion

        Write-Verbose "[$($MyInvocation.MyCommand)] ConfirmPreference=$ConfirmPreference WhatIfPreference=$WhatIfPreference VerbosePreference=$VerbosePreference Force=$Force"
    }

    Process {
        $ErrorActionPreference = 'Stop'

        Write-Verbose "[$($MyInvocation.MyCommand)] Searching installed modules"
        [PSModuleInfo[]]$installedAwsToolsModules = Get-AWSToolsModule -SkipIfInvalidSignature
        [string[]]$installedAwsToolsModuleNames = $installedAwsToolsModules | Select-Object -Expand Name | Sort-Object -Unique

        if ($installedAwsToolsModuleNames) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Found modules ($installedAwsToolsModuleNames)"

            $installAWSToolsModuleParams = @{
                Name            = $installedAwsToolsModuleNames
                RequiredVersion = $RequiredVersion
                MaximumVersion  = $MaximumVersion
                Scope           = $Scope
                AllowClobber    = $AllowClobber
                CleanUp         = $CleanUp
                Force           = $Force
                SkipUpdate      = $true
                Proxy           = $Proxy
                ProxyCredential = $ProxyCredential
				SkipPublisherCheck = $SkipPublisherCheck
            }
            Install-AWSToolsModule @installAWSToolsModuleParams
        }
    }

    End {
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}
