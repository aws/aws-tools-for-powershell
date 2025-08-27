<#
.Synopsis
    Installs AWS Tools modules from a zip file.

.Description
    Extracts modules from zip file, copies them to target path, and generates
    PSGetModuleInfo.xml files for PowerShellGet compatibility. Supports both
    AWS.Tools and AWS.Tools.Installer.

.Parameter Name
    Specifies which module type to install. Valid values are 'AWS.Tools' or 'AWS.Tools.Installer'.
    Defaults to 'AWS.Tools' for backward compatibility.

.Parameter ZipPath
    Path to the zip file (AWS.Tools.zip or AWS.Tools.Installer.zip).

.Parameter ModuleNames
    Array of specific module names to install. If null, installs all modules.

.Parameter TargetPath
    Target installation path for modules.
#>
function Install-AWSToolsModuleFromZip {
    [CmdletBinding()]
    param(
        [Parameter()]
        [ValidateSet('AWS.Tools', 'AWS.Tools.Installer')]
        [string]
        $Name = 'AWS.Tools',
        
        [Parameter(Mandatory)]
        [string]$ZipPath,
        
        [Parameter()]
        [string[]]$ModuleNames,
        
        [Parameter(Mandatory)]
        [string]$TargetPath
    )
    
    Begin {
        Write-Debug ("[$($MyInvocation.MyCommand)] Begin - Name=$Name ZipPath=$ZipPath " +
            "ModuleNames=($($ModuleNames -join ',')) TargetPath=$TargetPath")
    }

    Process {
        # Get module configuration from general.psd1
        $moduleConfig = $script:Config.general.Modules[$Name]
        if (-not $moduleConfig) {
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.InvalidOperationException]"Configuration not found for module type: $Name"),
                    'ModuleConfigNotFound',
                    [System.Management.Automation.ErrorCategory]::InvalidOperation,
                    $Name
                )
            )
        }
        $tempPath = [System.IO.Path]::GetTempPath()
        $randomName = [System.IO.Path]::GetRandomFileName()
        $tempDir = Join-Path $tempPath $randomName
        $extractDir = Join-Path $tempDir "AwsTools"
        
        try {
            # Create temporary directory
            New-Item -ItemType 'Directory' -Path $tempDir -Force -ErrorAction Stop | Out-Null
            
            Write-Verbose "[$($MyInvocation.MyCommand)] Expanding $($moduleConfig.ZipFileName) archive..."
            
            # Use Expand-ArchivePart when specific modules are requested for AWS.Tools
            # This avoids extracting the entire archive which saves significant time
            if ($Name -eq 'AWS.Tools' -and $ModuleNames) {
                Write-Verbose "[$($MyInvocation.MyCommand)] Using Expand-ArchivePart for specific modules: $($ModuleNames -join ', ')"

                Expand-ArchivePart -Name $ModuleNames -Path $ZipPath -DestinationPath $extractDir -Force -ErrorAction Stop
            } else {
                # Extract the entire archive for AWS.Tools.Installer or when no specific modules are requested
                Write-Verbose "[$($MyInvocation.MyCommand)] Extracting entire archive"
                # Temporarily suppress progress if PowerShell version is less than 6
                if ($PSVersionTable.PSVersion.Major -lt 6) {
                    # Must set global preference specifically for Expand-Archive
                    $savedProgressPreference = $global:ProgressPreference
                    $global:ProgressPreference = 'SilentlyContinue'
                    try {
                        Expand-Archive -Path $ZipPath -DestinationPath $extractDir -Force -ErrorAction Stop
                    }
                    finally {
                        $global:ProgressPreference = $savedProgressPreference
                    }
                }
                else {
                    Expand-Archive -Path $ZipPath -DestinationPath $extractDir -Force -ErrorAction Stop
                }
            }

            $moduleDirectories = @(Get-ChildItem -Path $extractDir -Directory -ErrorAction Stop)
            
            if ($ModuleNames) {
                $moduleDirectories = @($moduleDirectories | 
                    Where-Object { $_.Name -in $ModuleNames })
                if ($moduleDirectories.Count -eq 0) {
                    $PSCmdlet.ThrowTerminatingError(
                        [System.Management.Automation.ErrorRecord]::new(
                            ([System.IO.FileNotFoundException]"None of the specified modules were found in the $($moduleConfig.ZipFileName) file."),
                            'ModulesNotFoundInZip',
                            [System.Management.Automation.ErrorCategory]::ObjectNotFound,
                            $ModuleNames
                        )
                    )
                }
            }

            $installedVersion = $null
            $totalModules = $moduleDirectories.Count
            $currentModule = 0
            
            Write-Verbose "[$($MyInvocation.MyCommand)] Found $totalModules modules to install"
            
            foreach ($moduleDir in $moduleDirectories) {
                $currentModule++
                $activityName = if ($Name -eq 'AWS.Tools.Installer') { 
                    "Installing AWS Tools Installer Module" 
                } else { 
                    "Installing AWS Tools Modules" 
                }
                $writeProgressParams = @{
                    Id = 2
                    ParentId = 1
                    Activity = $activityName
                    Status = "Processing $($moduleDir.Name)"
                    PercentComplete = (($currentModule / $totalModules) * 100)
                }
                # Write progress only if PowerShell version is greater than 6
                if ($PSVersionTable.PSVersion.Major -ge 6) {
                    Write-Progress @writeProgressParams
                }
                
                $psd1File = Get-ChildItem -Path $moduleDir.FullName -Filter '*.psd1' -Recurse | 
                    Select-Object -First 1
                if (-not $psd1File) {
                    $PSCmdlet.ThrowTerminatingError(
                        [System.Management.Automation.ErrorRecord]::new(
                            ([System.IO.FileNotFoundException]"No manifest file found for module $($moduleDir.Name). Installation cannot continue."),
                            'ManifestNotFound',
                            [System.Management.Automation.ErrorCategory]::ObjectNotFound,
                            $moduleDir.Name
                        )
                    )
                }

                $pathParts = $psd1File.FullName.Split([System.IO.Path]::DirectorySeparatorChar)
                $moduleVersion = $pathParts[-2]
                $moduleName = $moduleDir.Name
                
                Write-Verbose ("[$($MyInvocation.MyCommand)] Installing module $moduleName " +
                    "version $moduleVersion")
                
                # Track the installed version (for AWS.Tools, use any non-installer module; for installer, use the installer itself)
                if (($Name -eq 'AWS.Tools' -and $moduleName -ne 'AWS.Tools.Installer') -or 
                    ($Name -eq 'AWS.Tools.Installer' -and $moduleName -eq 'AWS.Tools.Installer')) {
                    $installedVersion = $moduleVersion
                }

                $moduleTargetPath = Join-Path $TargetPath $moduleName
                $versionTargetPath = Join-Path $moduleTargetPath $moduleVersion

                # Create target directory
                if (-not (Test-Path $versionTargetPath)) {
                    New-Item -ItemType 'Directory' -Path $versionTargetPath -Force -ErrorAction Stop | Out-Null
                }

                # Copy module files
                $sourceVersionPath = $psd1File.Directory.FullName
                $copyItemParams = @{
                    Path = "$sourceVersionPath\*"
                    Destination = $versionTargetPath
                    Recurse = $true
                    Force = $true
                    ErrorAction = 'Stop'
                }
                # Temporarily suppress progress just for this operation
                $savedProgressPreference = $ProgressPreference
                $ProgressPreference = 'SilentlyContinue'
                try {
                    Copy-Item @copyItemParams
                }
                finally {
                    $ProgressPreference = $savedProgressPreference
                }

                $psd1TargetPath = Join-Path $versionTargetPath "$moduleName.psd1"
                $infoXmlPath = Join-Path $versionTargetPath 'PSGetModuleInfo.xml'
                
                # Generate PSGetModuleInfo.xml
                $newPSGetModuleInfoParams = @{
                    PsdPath = $psd1TargetPath
                    NormalizedVersion = $moduleVersion
                }
                $xml = New-PSGetModuleInfo @newPSGetModuleInfoParams
                $writePSGetModuleInfoParams = @{
                    XmlContent = $xml
                    Path = $infoXmlPath
                }
                Write-PSGetModuleInfo @writePSGetModuleInfoParams
                    
                Write-Verbose ("[$($MyInvocation.MyCommand)] Successfully installed " +
                    "$moduleName version $moduleVersion")
            }
            
            # Clear progress indicator
            $activityName = if ($Name -eq 'AWS.Tools.Installer') { 
                "Installing AWS Tools Installer Module" 
            } else { 
                "Installing AWS Tools Modules" 
            }
            Write-Progress -Id 2 -Activity $activityName -Completed
            
            return $installedVersion
        }
        finally {
            if (Test-Path $tempDir) {
                $removeItemParams = @{
                    Path = $tempDir
                    Recurse = $true
                    Force = $true
                    ErrorAction = 'SilentlyContinue'
                }
                # Temporarily suppress progress just for this operation
                $savedProgressPreference = $ProgressPreference
                $ProgressPreference = 'SilentlyContinue'
                try {
                    Remove-Item @removeItemParams
                }
                finally {
                    $ProgressPreference = $savedProgressPreference
                }
            }
        }
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
