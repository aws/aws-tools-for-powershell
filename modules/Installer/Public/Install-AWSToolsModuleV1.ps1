<#
.Synopsis
    Install AWS.Tools modules from PowerShell Gallery (Legacy compatibility).

.Description
    This cmdlet uses Install-Module to install AWS.Tools modules from PowerShell Gallery.
    Unless -SkipUpdate is specified, this cmdlet also updates all other currently installed AWS.Tools modules to the version being installed.

    This is a legacy compatibility cmdlet that replicates the behavior of AWS.Tools.Installer 1.0.3.
    For new installations, consider using Install-AWSToolsModule which uses CloudFront distribution for improved reliability.

.Notes
    This cmdlet uses the PSRepository named PSGallery as source.
    Use 'Get-PSRepository -Name PSGallery' for information on the PSRepository used by Install-AWSToolsModuleV1.
    This cmdlet downloads all modules from https://www.powershellgallery.com/api/v2/package/ and considers it a trusted source.

.Example
    Install-AWSToolsModuleV1 EC2,S3 -RequiredVersion 4.0.0.0

    This example installs version 4.0.0.0 of AWS.Tools.EC2, AWS.Tools.S3 and their dependencies from PowerShell Gallery.

.Example
    Get-AWSService -Service EFS | Install-AWSToolsModuleV1 -RequiredVersion 4.1.463

    This example installs version 4.1.463 of AWS.Tools.ElasticFileSystem and its dependencies from PowerShell Gallery.
#>
function Install-AWSToolsModuleV1 {
    [CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'High')]
    Param(
        ## Specifies names of the AWS.Tools modules to install.
        ## The names can be listed either with or without the "AWS.Tools." prefix (i.e. "AWS.Tools.Common" or simply "Common").
        [Parameter(ValueFromPipelineByPropertyName, ValueFromPipeline, Mandatory, Position = 0)]
        [string[]]
        [Alias('ModuleName')]
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

        ## Install-AWSToolsModuleV1 by default also updates all currently installed AWS.Tools modules. -SkipUpdate disables the update.
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
        # Deprecation warning
        Write-Warning "Install-AWSToolsModuleV1 is deprecated. Please use Install-AWSToolsModule instead, which provides improved reliability through CloudFront distribution and faster installation speeds."
        
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

        if ($Name -notlike 'AWS.Tools*') {
            throw "The Name parameter must contain only AWS.Tools modules."
        }

        if ($Name -eq 'AWS.Tools.Installer') {
            throw "AWS.Tools.Installer cannot be used to install AWS.Tools.Installer. Use Update-Module instead."
        }

        [PSObject[]]$availableModulesToInstall = Find-AWSToolsModule -Name $Name -Proxy $Proxy -ProxyCredential $ProxyCredential

        [Version]$availableVersion = [Version[]]$availableModulesToInstall.Version | Measure-Object -Minimum | Select-Object -Expand Minimum

        $availableVersion = Get-CleanVersion $availableVersion

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

        $modulesToInstall = $modulesToInstall | Where-Object { -not (Get-Module $_ -ListAvailable -Verbose:$false | Where-Object { (Get-CleanVersion $_.Version) -eq $RequiredVersion }) }
        Write-Verbose "[$($MyInvocation.MyCommand)] Removing already installed modules from the. Final list of modules to install: ($modulesToInstall)"

        if ($modulesToInstall) {
            if ($Force -or $WhatIfPreference -or $PSCmdlet.ShouldProcess("AWS Tools version $RequiredVersion")) {
                $ConfirmPreference = 'None'

                [string]$temporaryRepoDirectory = Join-Path ([System.IO.Path]::GetTempPath()) ([System.IO.Path]::GetRandomFileName())
                Write-Verbose "[$($MyInvocation.MyCommand)] Create folder for temporary repository $temporaryRepoDirectory"
                Microsoft.PowerShell.Management\New-Item -ItemType Directory -Path $temporaryRepoDirectory -WhatIf:$false | Out-Null
                try {
                    if (-not $WhatIfPreference) {
                        PowerShellGet\Unregister-PSRepository -Name $script:Config.legacy.AWSToolsTempRepoName -ErrorAction 'SilentlyContinue'
                        Write-Verbose "[$($MyInvocation.MyCommand)] Registering temporary repository $($script:Config.legacy.AWSToolsTempRepoName)"
                        PowerShellGet\Register-PSRepository -Name $script:Config.legacy.AWSToolsTempRepoName -SourceLocation $temporaryRepoDirectory -ErrorAction 'Stop'
                        PowerShellGet\Set-PSRepository -Name $script:Config.legacy.AWSToolsTempRepoName -InstallationPolicy Trusted
                    }

                    Add-Type -AssemblyName System.Net.Http -ErrorAction Stop

                    [System.Net.Http.HttpClient]$httpClient = $null
                    [System.Net.Http.HttpClientHandler]$httpClientHandler = $null
                    [System.Collections.Generic.List[PSCustomObject]]$tasks = @()

                    Write-Verbose "[$($MyInvocation.MyCommand)] Downloading modules to temporary repository"
                    try {
                        $httpClientHandler = [System.Net.Http.HttpClientHandler]::new()
                        if ($Proxy) {
                            $httpClientHandler.Proxy = [System.Net.WebProxy]::new($Proxy)
                            if ($ProxyCredential) {
                                $httpClientHandler.Proxy.Credentials = $ProxyCredential.GetNetworkCredential()
                            }
                        }
                        $httpClient = [System.Net.Http.HttpClient]::new($httpClientHandler);

                        Add-Type $script:Config.legacy.ParallelDownloaderClassCode -ReferencedAssemblies System.Net.Http,System.Threading.Tasks
                        [ParallelDownloader]$parallelDownloader = [ParallelDownloader]::new($httpClient)

                        [string[]]$modulesToDownload = $modulesToInstall
                        [System.Collections.Generic.HashSet[string]]$savedModules = New-Object -TypeName System.Collections.Generic.HashSet[string]

                        Write-Verbose "[$($MyInvocation.MyCommand)] Downloading modules ($modulesToDownload)"

                        while ($modulesToDownload) {
                            [string[]]$dependencies = @()

                            $tasks = $modulesToDownload | Where-Object { $savedModules.Add($_) } | ForEach-Object {
                                [string]$nupkgFilePath = Join-Path $temporaryRepoDirectory "$_.$($RequiredVersion).nupkg"
                                Write-Verbose "[$($MyInvocation.MyCommand)] Downloading module $_ to $temporaryRepoDirectory"
                                [PSCustomObject]@{
                                    Task       = $parallelDownloader.DownloadToFile("https://www.powershellgallery.com/api/v2/package/$_/$RequiredVersion", $nupkgFilePath)
                                    ModuleName = $_
                                    Path       = $nupkgFilePath
                                }
                            }
                            while ($tasks) {
                                [int]$taskIndex = [System.Threading.Tasks.Task]::WaitAny($tasks.Task)
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
                                [System.Threading.Tasks.Task]::WaitAll($tasks.Task)
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
                        Repository      = $script:Config.legacy.AWSToolsTempRepoName
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
                        Write-Verbose "[$($MyInvocation.MyCommand)] Unregistering temporary repository $($script:Config.legacy.AWSToolsTempRepoName)"
                        PowerShellGet\Unregister-PSRepository -Name $script:Config.legacy.AWSToolsTempRepoName -ErrorAction 'Continue'
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
