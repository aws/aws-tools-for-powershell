Param(
    ## Specifies a proxy server for the module import request, rather than connecting directly to an internet resource.
    [Parameter(ValueFromPipelineByPropertyName, Position = 0)]
    [Uri]
    $Proxy,

    ## Specifies a user account that has permission to use the proxy server specified by the Proxy parameter.
    [Parameter(ValueFromPipelineByPropertyName, Position = 1)]
    [PSCredential]
    $ProxyCredential
)

$script:AWSToolsSignatureSubject = 'CN="Amazon.com, Inc.", O="Amazon.com, Inc.", L=Seattle, S=Washington, C=US'
$script:AWSToolsInstallerModuleName = 'AWS.Tools.Installer'
$script:AWSToolsTempRepoName = 'AWSToolsTemp'
$script:CurrentMinAWSToolsInstallerVersion = '0.0.0.0'
$script:ExpectedModuleCompanyName = 'aws-dotnet-sdk-team'

#region Retrieve the current list of AWS.Tools modules from the PowerShell Gallery for custom validation
$findModuleParams = @{
    Name        = 'AWS.Tools.*'
    Repository  = 'PSGallery'
    ErrorAction = 'Stop'
}
if ($Proxy) {
    $findModuleParams.Add('Proxy', $Proxy)
}
if ($ProxyCredential) {
    $findModuleParams.Add('ProxyCredential', $ProxyCredential)
}

$script:validAwsToolsModuleNames = Find-Module @findModuleParams |
    Where-Object -FilterScript {
        $_.Name -ne $script:AWSToolsInstallerModuleName -and
        $_.CompanyName -eq $script:ExpectedModuleCompanyName
    } |
    Sort-Object -Property 'Name' |
    Select-Object -ExpandProperty 'Name'

if ($null -eq $script:validAwsToolsModuleNames) {
    $message = 'Failed to retrieve the list of AWS.Tools modules from the PowerShell Gallery.'
    throw [System.ArgumentNullException]::new('validAwsToolsModuleNames', $message)
}
elseif ($script:validAwsToolsModuleNames.Count -eq 0) {
    throw [System.Management.Automation.ValidationMetadataException]::new('No AWS.Tools modules were found.')
}
#endregion

#region Prepend the shortnames of all AWS.Tools modules so that these populate first in argument completion
$script:validAwsToolsModuleNames = $script:validAwsToolsModuleNames.ForEach( { $_.Split('.')[-1] }) + $script:validAwsToolsModuleNames
#endregion

#region Create a custom parameter validator
class ValidateAwsToolsModuleSet : System.Management.Automation.ValidateArgumentsAttribute {
    [void] Validate([object]$Arguments, [System.Management.Automation.EngineIntrinsics]$EngineIntrinsics) {
        [string[]]$moduleNames = $Arguments
        foreach ($moduleName in $moduleNames) {
            if ($moduleName -notin $script:validAwsToolsModuleNames) {
                $validAwsToolsModuleNameList = $script:validAwsToolsModuleNames -join ', '
                $message = (
                    "The argument `"${moduleName}`" does not belong to the set `"${validAwsToolsModuleNameList}`" " +
                    "specified by the ValidateAwsToolsModuleSet attribute. " +
                    "Supply an argument that is in the set and then try the command again."
                )

                throw $message
            }
        }
    }
}
#endregion

#region Register argument completion for AWS.Tools module names
$scriptBlock = {
    Param($CommandName, $ParameterName, $WordToComplete, $CommandAst, $FakeBoundParameter)

    $script:validAwsToolsModuleNames |
        Where-Object -FilterScript { $_ -like "${WordToComplete}*" } |
        ForEach-Object -Process { New-Object -TypeName 'System.Management.Automation.CompletionResult' -ArgumentList $_ }
}
Register-ArgumentCompleter -CommandName 'Install-AWSToolsModule' -ParameterName 'Name' -ScriptBlock $scriptBlock
#endregion

function Get-CleanVersion {
    Param(
        [Parameter(ValueFromPipelineByPropertyName, ValueFromPipeline, Mandatory, Position = 0)]
        [AllowNull()]
        [System.Version]
        $Version
    )

    Process {
        if ($null -eq $Version) {
            $Version
        }
        else {
            $major = $Version.Major
            $minor = $Version.Minor
            $build = $Version.Build
            $revision = $Version.Revision
    
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
    
            [System.Version]::new($major, $minor, $build, $revision)
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
        $awsToolsModules = Get-Module AWS.Tools.* -ListAvailable
        if ($awsToolsModules -and ($PSVersionTable.PSVersion.Major -lt 6 -or $IsWindows)) {
            $awsToolsModules = $awsToolsModules | Where-Object {
                $signature = Get-AuthenticodeSignature $_.Path
                ($signature.Status -eq 'Valid' -or $SkipIfInvalidSignature) -and
                $signature.SignerCertificate.Subject -eq $script:AWSToolsSignatureSubject
            }
        }
        $awsToolsModules | Where-Object { $_.Name -ne $script:AWSToolsInstallerModuleName }
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
        [System.Version]
        $MinimumVersion,

        ## Specifies exact version number of the module to uninstall.
        [Parameter(ValueFromPipelineByPropertyName)]
        [System.Version]
        $RequiredVersion,

        ## Specifies the maximum version of the modules to uninstall.
        [Parameter(ValueFromPipelineByPropertyName)]
        [System.Version]
        $MaximumVersion,

        ## Specifies that you want to uninstall all of the other available versions of AWS Tools except this one.
        [Parameter(ValueFromPipelineByPropertyName)]
        [System.Version]
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
        $awsToolsModules = Get-AWSToolsModule
        
        if ($MinimumVersion) {
            $awsToolsModules = $awsToolsModules | Where-Object { $_.Version -ge $MinimumVersion }
        }
        if ($MaximumVersion) {
            $awsToolsModules = $awsToolsModules | Where-Object { $_.Version -le $MaximumVersion }
        }
        if ($RequiredVersion) {
            $awsToolsModules = $awsToolsModules | Where-Object { $_.Version -eq $RequiredVersion }
        }
        if ($ExceptVersion) {
            $awsToolsModules = $awsToolsModules | Where-Object { $_.Version -ne $ExceptVersion }
        }

        $versions = $awsToolsModules | Group-Object Version

        if ($awsToolsModules -and ($Force -or $WhatIfPreference -or $PSCmdlet.ShouldProcess("AWS Tools version $([System.String]::Join(', ', $versions.Name))"))) {
            $ConfirmPreference = 'None'

            $versions | ForEach-Object {
                Write-Host "Uninstalling AWS.Tools version $($_.Name)"
            
                $versionModules = $_.Group
            
                while ($versionModules) {
                    $dependencies = $versionModules.RequiredModules | Sort-Object -Unique
                    if ($dependencies) {
                        $removableModules = $versionModules | Where-Object { -not $dependencies.Name.Contains($_.Name) }
                    }
                    else {
                        $removableModules = $versionModules
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
                            Uninstall-Module @uninstallModuleParams
                        }
                    }
            
                    $versionModules = $versionModules | Where-Object { -not $removableModules.Name.Contains($_.Name) }
                }
            }
        }
    }

    End {
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}

function Get-AvailableModuleVersion {
    Param(
        ## Specifies names of the AWS.Tools modules to retrieve the version for.
        [Parameter(ValueFromPipelineByPropertyName, ValueFromPipeline, Mandatory)]
        [string[]]
        $Name,

        ## Specifies exact version number of the module to install.
        [Parameter(ValueFromPipelineByPropertyName)]
        [System.Version]
        $RequiredVersion,

        ## Specifies the maximum version of the modules to install.
        [Parameter(ValueFromPipelineByPropertyName)]
        [System.Version]
        $MaximumVersion,

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

        Write-Verbose "[$($MyInvocation.MyCommand)] ConfirmPreference=$ConfirmPreference WhatIfPreference=$WhatIfPreference VerbosePreference=$VerbosePreference Force=$Force"
    }

    Process {
        $proxyParams = @{ }
        if ($Proxy) {
            $proxyParams['Proxy'] = $Proxy
        }
        if ($ProxyCredential) {
            $proxyParams['ProxyCredential'] = $ProxyCredential
        }
        $findModuleParams = @{
            RequiredVersion = $versionToInstall
            MaximumVersion  = $MaximumVersion
            Repository      = 'PSGallery'
            ErrorAction     = 'Stop'
        }
        $savedModules = $Name | ForEach-Object { Find-Module -Name $_ @findModuleParams @proxyParams }
        
        $versionToInstall = $savedModules.Version | Sort-Object -Unique
            
        if ($versionToInstall.Count -gt 1) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Found multiple modules versions: $([System.String]::Join(', ', $versionToInstall)).)"
            $versionToInstall = [System.Version[]]$versionToInstall | Measure-Object -Minimum | Select-Object -Expand Minimum
        
            $findModuleParams = @{
                RequiredVersion = $versionToInstall
                Repository      = 'PSGallery'
                ErrorAction     = 'Stop'
            }
            $savedModules = $Name | ForEach-Object { Find-Module -Name $_ $findModuleParams @proxyParams }
        }
        
        $versionToInstall
    }

    End {
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}

function Save-AWSToolsModule {
    [CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'Low')]
    Param(
        ## Specifies name of the AWS.Tools module to save.
        [Parameter(ValueFromPipelineByPropertyName, ValueFromPipeline, Mandatory)]
        [string]
        $Name,

        ## Specifies directory the module should be saved to.
        [Parameter(ValueFromPipelineByPropertyName, Mandatory)]
        [string]
        $TemporaryRepoDirectory,

        ## Specifies exact version number of the module to install.
        [Parameter(ValueFromPipelineByPropertyName, Mandatory)]
        [System.Version]
        $RequiredVersion,

        ## Specifies which modules are already available either installed or in the temporary repository.
        [Parameter(ValueFromPipelineByPropertyName, Mandatory)]
        [AllowEmptyCollection()]
        [System.Collections.Generic.HashSet[string]]
        $SavedModules,

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

        Write-Verbose "[$($MyInvocation.MyCommand)] ConfirmPreference=$ConfirmPreference WhatIfPreference=$WhatIfPreference VerbosePreference=$VerbosePreference Force=$Force"
    }

    Process {
        $ErrorActionPreference = 'Stop'

        if ($SavedModules.Add($Name.ToLower())) {
            $proxyParams = @{ }
            if ($Proxy) {
                $proxyParams['Proxy'] = $Proxy
            }
            if ($ProxyCredential) {
                $proxyParams['ProxyCredential'] = $ProxyCredential
            }

            $findModuleParams = @{
                Name            = $Name
                RequiredVersion = $versionToInstall
                Repository      = 'PSGallery'
                ErrorAction     = 'Stop'
            }
            $moduleInfo = Find-Module @findModuleParams @proxyParams
            if ($moduleInfo.CompanyName -ne $script:ExpectedModuleCompanyName) {
                throw "Error validating CompanyName for $($moduleInfo.Name)"
            }

            $nupkgFilePath = Join-Path $TemporaryRepoDirectory "$($moduleInfo.Name).$($moduleInfo.Version).nupkg"

            Write-Verbose "[$($MyInvocation.MyCommand)] Downloading module $($moduleInfo.Name) to $TemporaryRepoDirectory"
            $webRequestParams = @{
                Uri     = "https://www.powershellgallery.com/api/v2/package/$($moduleInfo.Name)/$($moduleInfo.Version)"
                OutFile = $nupkgFilePath
            }
            if ($PSVersionTable.PSVersion.Major -le 5) {
                $webRequestParams['UseBasicParsing'] = $true
            }
            Invoke-WebRequest @webRequestParams @proxyParams

            Write-Verbose "[$($MyInvocation.MyCommand)] Validating module manifest"
            try {
                Add-Type -AssemblyName System.IO.Compression.FileSystem -ErrorAction Stop
                $zipArchive = [System.IO.Compression.ZipFile]::OpenRead($nupkgFilePath)
                $entry = $zipArchive.GetEntry("$($moduleInfo.Name).psd1")
                $entryStream = $entry.Open()
                $temporaryManifestFilePath = Join-Path ([System.IO.Path]::GetTempPath()) "$([System.IO.Path]::GetRandomFileName()).psd1"
                $manifestFileStream = [System.IO.File]::OpenWrite($temporaryManifestFilePath)
                $entryStream.CopyTo($manifestFileStream)
                $manifestFileStream.Close();

                if ($awsToolsModules -and ($PSVersionTable.PSVersion.Major -lt 6 -or $IsWindows)) {
                    $manifestSignature = Get-AuthenticodeSignature $temporaryManifestFilePath
                    if ($manifestSignature.Status -eq 'Valid' -and $manifestSignature.SignerCertificate.Subject -eq $script:AWSToolsSignatureSubject) {
                        Write-Verbose "[$($MyInvocation.MyCommand)] Manifest signature correctly validated"
                    }
                    else {
                        Write-Host $temporaryManifestFilePath
                        Write-Host $manifestSignature.Status
                        Write-Host $manifestSignature.SignerCertificate.Subject
                        throw "Error validating manifest signature for $($moduleInfo.Name)"
                    }
                }
                else {
                    Write-Verbose "[$($MyInvocation.MyCommand)] Authenticode signature can only be vefied on Windows, skipping"
                }

                $manifestData = Import-PowerShellDataFile $temporaryManifestFilePath

                if ($manifestData.PrivateData.MinAWSToolsInstallerVersion) {
                    $minVersion = Get-CleanVersion $manifestData.PrivateData.MinAWSToolsInstallerVersion
                    if ($minVersion -gt $script:CurrentMinAWSToolsInstallerVersion) {
                        throw "$($moduleInfo.Name) version $RequiredVersion requires at least $script:AWSToolsInstallerModuleName version $minVersion. Run 'Update-Module $script:AWSToolsInstallerModuleName -Force'."
                    }
                }

                $saveAWSToolsModuleParams = @{
                    RequiredVersion        = $RequiredVersion
                    TemporaryRepoDirectory = $TemporaryRepoDirectory
                    SavedModules           = $SavedModules
                }
                $manifestData.RequiredModules | ForEach-Object {
                    Write-Verbose "[$($MyInvocation.MyCommand)] Found dependency $($_.ModuleName)"
                    Save-AWSToolsModule -Name $_.ModuleName @saveAWSToolsModuleParams @proxyParams | Out-Null
                }

                #Returning the property capitalized module name.
                $moduleInfo.Name
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
                    Remove-Item $temporaryManifestFilePath
                }
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
    This cmdlet uses Instal-Module to install AWS.Tools modules.
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
        [ValidateAwsToolsModuleSet()]
        [string[]]
        $Name,

        ## Specifies exact version number of the module to install.
        [Parameter(ValueFromPipelineByPropertyName, Position = 1)]
        [System.Version]
        $RequiredVersion,

        ## Specifies the maximum version of the modules to install.
        [Parameter(ValueFromPipelineByPropertyName)]
        [System.Version]
        $MaximumVersion,

        ## Specifies that, after a successful install, all other versions of the AWS Tools modules should be uninstalled.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $CleanUp,

        ## Install-AWSToolsModule by default also updates all currently installed AWS.Tools modules. -SkipUpdate disables the update.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $SkipUpdate,

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

        Write-Verbose "[$($MyInvocation.MyCommand)] ConfirmPreference=$ConfirmPreference WhatIfPreference=$WhatIfPreference VerbosePreference=$VerbosePreference Force=$Force"
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
        }

        if (($Name -like 'AWS.Tools.*' | Sort-Object -Unique).Count -ne $Name.Count) {
            throw "The Name parameter must contain only AWS.Tools modules without duplicates."
        }

        if ($RequiredVersion) {
            $versionToInstall = $RequiredVersion
        }
        else {
            $versionToInstall = Get-AvailableModuleVersion -Name $Name -MaximumVersion $MaximumVersion -Proxy $Proxy -ProxyCredential $ProxyCredential
            Write-Verbose "[$($MyInvocation.MyCommand)] Installing AWS Tools version $versionToInstall"
        }

        if (-not $SkipUpdate) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Searching installed modules"
            $awsToolsModules = Get-AWSToolsModule -SkipIfInvalidSignature
            if ($awsToolsModules) {
                Write-Verbose "[$($MyInvocation.MyCommand)] Merging existing modules into the list of modules to install"
                $Name = ($Name + ($awsToolsModules | Select-Object -Expand Name)) | Sort-Object -Unique
            }
        }

        $Name = $Name | Where-Object { -not (Get-Module $_ -ListAvailable | Where-Object { $_.Version -eq $versionToInstall }) }

        if ($Name) {
            if ($Force -or $WhatIfPreference -or $PSCmdlet.ShouldProcess("AWS Tools version $versionToInstall")) {
                $ConfirmPreference = 'None'

                $temporaryRepoDirectory = Join-Path ([System.IO.Path]::GetTempPath()) ([System.IO.Path]::GetRandomFileName())
                Write-Verbose "[$($MyInvocation.MyCommand)] Create folder for temporary repository $temporaryRepoDirectory"
                New-Item -ItemType Directory -Path $temporaryRepoDirectory -WhatIf:$false | Out-Null
                try {
                    if (-not $WhatIfPreference) {
                        Unregister-PSRepository -Name $script:AWSToolsTempRepoName -ErrorAction 'SilentlyContinue'
                        Write-Verbose "[$($MyInvocation.MyCommand)] Registering temporary repository $script:AWSToolsTempRepoName"
                        Register-PSRepository -Name $script:AWSToolsTempRepoName -SourceLocation $temporaryRepoDirectory -ErrorAction 'Stop'
                        Set-PSRepository -Name $script:AWSToolsTempRepoName -InstallationPolicy Trusted
                    }

                    $savedModules = New-Object System.Collections.Generic.HashSet[string]
                    $modulesToInstall = @()

                    Write-Verbose "[$($MyInvocation.MyCommand)] Downloading modules to temporary repository"
                    $saveAWSToolsModuleParams = @{
                        RequiredVersion        = $versionToInstall
                        TemporaryRepoDirectory = $temporaryRepoDirectory
                        SavedModules           = $savedModules
                        Proxy                  = $Proxy
                        ProxyCredential        = $ProxyCredential
                        Confirm                = $false
                        WhatIf                 = $false
                    }
                    $Name | ForEach-Object {
                        if (Get-Module $_ -ListAvailable | Where-Object { $_.Version -eq $versionToInstall } ) {
                            Write-Verbose "[$($MyInvocation.MyCommand)] Skipping installation of $_ because already installed"
                        }
                        else {
                            $modulesToInstall += Save-AWSToolsModule -Name $_ @saveAWSToolsModuleParams
                        }
                    }

                    Write-Verbose "[$($MyInvocation.MyCommand)] Installing modules"
                    $installModuleParams = @{
                        RequiredVersion = $versionToInstall
                        Scope           = $Scope
                        Repository      = $script:AWSToolsTempRepoName
                        AllowClobber    = $AllowClobber
                        Confirm         = $false
                        ErrorAction     = 'Stop'
                    }
                    $modulesToInstall | ForEach-Object {
                        if (-not $WhatIfPreference) {
                            Write-Host "Installing module $_ version $versionToInstall"
                            Install-Module -Name $_ @installModuleParams
                        }
                        else {
                            Write-Host "What if: Installing module $_ version $versionToInstall"
                        }
                    }
                    Write-Verbose "[$($MyInvocation.MyCommand)] Modules install complete"
                }
                finally {
                    if (-not $WhatIfPreference) {
                        Write-Verbose "[$($MyInvocation.MyCommand)] Unregistering temporary repository $script:AWSToolsTempRepoName"
                        Unregister-PSRepository -Name $script:AWSToolsTempRepoName -ErrorAction 'Continue'
                    }
                    Write-Verbose "[$($MyInvocation.MyCommand)] Delete repository folder $temporaryRepoDirectory"
                    Remove-Item -Path $temporaryRepoDirectory -Recurse -WhatIf:$false
                }
            }
        }
        else {
            Write-Verbose "[$($MyInvocation.MyCommand)] All modules are up to date"
        }

        if ($CleanUp) {
            Uninstall-AWSToolsModule -ExceptVersion $versionToInstall
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
    This cmdlet uses Instal-Module to update all AWS.Tools modules.

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
        [System.Version]
        $RequiredVersion,

        ## Specifies the maximum version of the modules to update to.
        [Parameter(ValueFromPipelineByPropertyName)]
        [System.Version]
        $MaximumVersion,

        ## Specifies that, after a successful install, all other versions of the AWS Tools modules should be uninstalled.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $CleanUp,

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
        $awsToolsModules = Get-AWSToolsModule -SkipIfInvalidSignature
        $awsToolsModulesNames = $awsToolsModules | Select-Object -Expand Name | Sort-Object -Unique

        if ($awsToolsModulesNames) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Found modules $([System.String]::Join(', ', $awsToolsModulesNames))"
            if ($RequiredVersion) {
                $versionToInstall = $RequiredVersion
            }
            else {
                $getAvailableModuleVersionParams = @{
                    Name            = $awsToolsModulesNames
                    MaximumVersion  = $MaximumVersion
                    Proxy           = $Proxy
                    ProxyCredential = $ProxyCredential
                }
                $versionToInstall = Get-AvailableModuleVersion @getAvailableModuleVersionParams
                Write-Host "Installing AWS Tools version $versionToInstall"
            }
    
            $installAWSToolsModuleParams = @{
                Name            = $awsToolsModulesNames
                RequiredVersion = $versionToInstall
                Scope           = $Scope
                AllowClobber    = $AllowClobber
                CleanUp         = $CleanUp
                Force           = $Force
                SkipUpdate      = $true
                Proxy           = $Proxy
                ProxyCredential = $ProxyCredential
            }
            Install-AWSToolsModule @installAWSToolsModuleParams
        }
    }

    End {
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}
