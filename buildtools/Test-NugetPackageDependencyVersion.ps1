<#
.Synopsis
    Validates a NuGet package's dependencies.

.DESCRIPTION
    This script creates a NuGet package from a PowerShell module and validates
    that it has the specified dependency with the correct version.

.PARAMETER ModulePath
    The path to the PowerShell module directory.

.NOTES
    The script creates a temporary directory for processing which is cleaned up when complete.

.EXAMPLE
    .\Test-NugetPackageDependencyVersion.ps1 -ModulePath "C:\Modules\MyModule"
#>

[CmdletBinding()]
Param
(
    [Parameter(Mandatory)]
    [string]$ModulePath
)

function Test-NugetPackageDependencyVersion {
    <#
    .SYNOPSIS
        Validates a NuGet package's dependencies.

    .DESCRIPTION
        This function extracts a NuGet package, reads the .nuspec file, and validates
        that it has the specified dependency with the correct version.
        Throws an exception if validation fails.

    .PARAMETER PackagePath
        The path to the NuGet package (.nupkg) file.

    .PARAMETER DependencyId
        The ID of the dependency to check for.

    .PARAMETER DependencyVersion
        The expected version of the dependency as a plain version number, e.g., "4.1.877".
        The function will automatically add brackets when checking against the nuspec file. brackets indicate that the version needs to be exact match.

    .PARAMETER TempDirectory
        The temporary directory to use for extracting the package. If not provided, a new one will be created.

    .EXAMPLE
        Test-NugetPackageDependencyVersion -PackagePath "C:\Users\Downloads\AWS.Tools.4.1.877.NuPkg\AWS.Tools.S3.4.1.877.nupkg" -DependencyId "AWS.Tools.Common" -DependencyVersion "4.1.877"
    #>

    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [string]$PackagePath,
        
        [Parameter()]
        [string]$DependencyId = 'AWS.Tools.Common',
        
        [Parameter(Mandatory = $true)]
        [string]$DependencyVersion,
        
        [Parameter()]
        [string]$TempDirectory
    )

    # Ensure the DependencyVersion has brackets if not already present. The brackets match exact version.
    if (-not ($DependencyVersion.StartsWith('[') -and $DependencyVersion.EndsWith(']'))) {
        $DependencyVersion = "[$DependencyVersion]"
    }

    # Check if the package file exists
    if (-not (Test-Path -Path $PackagePath)) {
        throw "Package file not found at path: $PackagePath"
    }

    # Create a subdirectory within the provided temp directory for extraction
    $extractDir = Join-Path -Path $TempDirectory -ChildPath "extract"
    $null = New-Item -ItemType Directory -Path $extractDir -Force
    
    try {
        # Extract the NuGet package
        Write-Host "Extracting .nuspec to: $extractDir"
        Expand-Archive -Path $PackagePath -DestinationPath $extractDir
        
        # Find the .nuspec file
        $nuspecFiles = Get-ChildItem -Path $extractDir -Filter "*.nuspec"
        
        if ($nuspecFiles.Count -eq 0) {
            throw "No .nuspec file found in the package."
        }
        
        $nuspecFile = $nuspecFiles[0]
        
        # Read the .nuspec file content
        $nuspecContent = [xml](Get-Content -Path $nuspecFile.FullName -Raw)

        # Check for dependencies
        $dependencies = $nuspecContent.package.metadata.dependencies.dependency
        
        if ($null -eq $dependencies) {
            throw "No dependencies found in the package."
        }
        
        # If there's only one dependency, wrap in an array
        if ($dependencies -is [System.Xml.XmlElement]) {
            $dependencies = @($dependencies)
        }
        
        # Check for the specific dependency
        $targetDependency = $dependencies | Where-Object { $_.id -eq $DependencyId }
        
        if ($null -eq $targetDependency) {
            throw "Dependency '$DependencyId' not found in the package."
        }

        # Compare the version numbers
        if ($targetDependency.version -ne $DependencyVersion) {
            throw "Validation FAILED: Dependency '$DependencyId' has version '$($targetDependency.version)', but expected is '$DependencyVersion'."
        }
        else {
            Write-Host "Dependency Validation Succeeded. actual:$($targetDependency.version) expected:$DependencyVersion"
        }
    }
    catch {
        throw $_
    }
    finally {
        # Clean up the extraction directory
        if (Test-Path -Path $extractDir) {
            Write-Host "Cleaning up extraction directory: $extractDir"
            try {
                Remove-Item -Path $extractDir -Recurse -Force
            }
            catch {
                # the folder can remain. not important enough for publish to fail
                Write-Host "issue cleaning up extraction directory: $($_.Exception.Message)"
            }
        }
    }
}

# Create a single temporary directory at the top level
try {
    $tempDir = [System.IO.Path]::Combine([System.IO.Path]::GetTempPath(), [System.Guid]::NewGuid().ToString())
    $null = New-Item -ItemType Directory -Path $tempDir -Force
    Write-Host "Created temporary directory: $tempDir"
    
    # Get module information
    $psd1File = Get-ChildItem $ModulePath -Filter *.psd1
    if (-not $psd1File) {
        throw "No PowerShell module manifest (*.psd1) found in $ModulePath"
    }
    
    $psd1Data = Import-PowerShellDataFile $psd1File.FullName
    $moduleVersion = $psd1Data.ModuleVersion
    
    Write-Host 'Creating NuGet package'
    $nupkgPath = Compress-PSResource -Path $ModulePath -DestinationPath $tempDir -PassThru -SkipModuleManifestValidate
    
    Write-Host 'Validating nuspec dependency version'
    Test-NugetPackageDependencyVersion -PackagePath $nupkgPath -DependencyVersion $moduleVersion -TempDirectory $tempDir
}
catch {
    throw $_
}
finally {
    # Clean up the top-level temporary directory
    if (Test-Path -Path $tempDir) {
        Write-Host "Cleaning up main temporary directory: $tempDir"
        
        try {
            Remove-Item -Path $tempDir -Recurse -Force
        }
        catch {
            # the folder can remain. not important enough for publish to fail
            Write-Host "issue cleaning up extraction directory: $($_.Exception.Message)"
        }
    }
}
