<#
.SYNOPSIS
    Extracts specific AWS.Tools modules from the AWS.Tools.zip archive without extracting the entire archive.

.DESCRIPTION
    This script uses the System.IO.Compression.ZipFile class to extract specific AWS.Tools modules
    from the AWS.Tools.zip archive without extracting the entire archive. It directly streams the
    files from the archive to the destination.

.PARAMETER Name
    Array of AWS.Tools module names to extract (e.g., "AWS.Tools.S3", "AWS.Tools.CloudFormation").
    If not specified, it will default to extracting AWS.Tools.S3.

.PARAMETER Path
    Path to the AWS.Tools.zip archive file.
    If not specified, it will look for AWS.Tools.zip in the parent directory of the script.

.PARAMETER DestinationPath
    Path where the extracted modules will be placed.
    If not specified, it will create an "ExtractedModules" directory in the same directory as the script.

.PARAMETER Force
    If specified, overwrites existing files at the destination.

.EXAMPLE
    Extract specific modules

    Expand-ArchivePart -Name "AWS.Tools.S3","AWS.Tools.CloudFormation","AWS.Tools.Common"

.EXAMPLE
    Extract modules with custom paths

    Expand-ArchivePart -Name "AWS.Tools.S3","AWS.Tools.EC2" -Path "C:\path\to\AWS.Tools.zip" -DestinationPath "C:\path\to\extract"
#>
function Expand-ArchivePart {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory, Position = 0)]
        [ValidateNotNullOrEmpty()]
        [string[]]$Name,
        
        [Parameter(Position = 1)]
        [ValidateNotNullOrEmpty()]
        [string]$Path,
        
        [Parameter(Position = 2)]
        [ValidateNotNullOrEmpty()]
        [string]$DestinationPath,
        
        [Parameter()]
        [switch]$Force
    )

    # Set default paths if not provided
    if (-not $PSBoundParameters.ContainsKey('Path')) {
        $scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
        $Path = Join-Path -Path (Split-Path -Parent $scriptPath) -ChildPath "AWS.Tools.zip"
        Write-Debug "Using default Path: $Path"
    }

    if (-not $PSBoundParameters.ContainsKey('DestinationPath')) {
        $scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
        $DestinationPath = Join-Path -Path $scriptPath -ChildPath "ExtractedModules"
        Write-Debug "Using default DestinationPath: $DestinationPath"
    }

    # Convert relative path to absolute path if needed
    if (-not [System.IO.Path]::IsPathRooted($DestinationPath)) {
        $currentDir = (Get-Location).Path
        $DestinationPath = Join-Path -Path $currentDir -ChildPath $DestinationPath
        Write-Debug "Converted to absolute path: $DestinationPath"
    }

    # Ensure the destination directory exists
    if (-not (Test-Path -Path $DestinationPath)) {
        Write-Debug "Creating destination directory: $DestinationPath"
        try {
            New-Item -ItemType Directory -Path $DestinationPath -Force -ErrorAction Stop | Out-Null
            Write-Debug "Destination directory created successfully"
        }
        catch {
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.IO.IOException]"Error creating destination directory: $DestinationPath"),
                    'DirectoryCreationFailure',
                    [System.Management.Automation.ErrorCategory]::WriteError,
                    $DestinationPath
                )
            )
            Write-Debug $_.Exception.Message
        }
    }
    else {
        Write-Debug "Destination directory already exists"
    }

    # Check if the ZIP file exists
    if (-not (Test-Path -Path $Path)) {
        $PSCmdlet.ThrowTerminatingError(
            [System.Management.Automation.ErrorRecord]::new(
                ([System.IO.FileNotFoundException]"Zip file not found at $Path"),
                'ZipFileNotFound',
                [System.Management.Automation.ErrorCategory]::ObjectNotFound,
                $Path
            )
        )
    }

    # Load required assembly
    Add-Type -AssemblyName System.IO.Compression.FileSystem

    # Open the ZIP archive
    Write-Debug "Opening ZIP archive: $Path"
    $zipFile = $null
    $overallSuccess = $true

    try {
        $zipFile = [System.IO.Compression.ZipFile]::OpenRead($Path)
        
        # Process each module
        foreach ($moduleName in $Name) {
            Write-Debug "Extracting module: $moduleName"
            
            # Find entries that match the specified module
            $folderPrefix = "$moduleName/"
            Write-Debug "Looking for entries with prefix: $folderPrefix"
            
            $matchingEntries = $zipFile.Entries | Where-Object { 
                $_.FullName.StartsWith($folderPrefix) 
            }
            
            $entryCount = $matchingEntries.Count
            Write-Debug "Found $entryCount matching entries for module: $moduleName"
            
            if ($entryCount -eq 0) {
                Write-Debug "No entries found matching module: $moduleName"
                $overallSuccess = $false
                continue
            }
            
            # First, create all the necessary directories
            Write-Debug "Creating directory structure..."
            foreach ($entry in $matchingEntries) {
                $entryPath = $entry.FullName
                
                # Skip non-directory entries
                if (-not $entryPath.EndsWith('/')) {
                    continue
                }
                
                # Determine the destination directory path
                $destinationDirPath = Join-Path -Path $DestinationPath -ChildPath $entryPath
                
                # Create the directory
                if (-not (Test-Path -Path $destinationDirPath)) {
                    try {
                        Write-Verbose "Creating directory: $destinationDirPath"
                        New-Item -ItemType Directory -Path $destinationDirPath -Force -ErrorAction Stop | Out-Null
                    }
                    catch {
                        Write-Debug "Error creating directory: $destinationDirPath"
                        Write-Debug $_.Exception.Message
                    }
                }
            }
            
            # Now extract all the files
            Write-Debug "Extracting files..."
            foreach ($entry in $matchingEntries) {
                $entryPath = $entry.FullName
                
                # Skip directory entries
                if ($entryPath.EndsWith('/')) {
                    continue
                }
                
                # Determine the destination file path
                $destinationFilePath = Join-Path -Path $DestinationPath -ChildPath $entryPath
                
                # Create parent directory if needed
                $parentDir = [System.IO.Path]::GetDirectoryName($destinationFilePath)
                if (-not [string]::IsNullOrEmpty($parentDir) -and -not (Test-Path -Path $parentDir)) {
                    try {
                        Write-Verbose "Creating parent directory: $parentDir"
                        New-Item -ItemType Directory -Path $parentDir -Force -ErrorAction Stop | Out-Null
                    }
                    catch {
                        Write-Debug "Error creating directory: $parentDir"
                        Write-Debug $_.Exception.Message
                        continue
                    }
                }
                
                # Check if file exists and Force parameter is not specified
                if ((Test-Path -Path $destinationFilePath) -and -not $Force) {
                    Write-Debug "File already exists at destination: $destinationFilePath. Use -Force to overwrite."
                    continue
                }
                
                # Extract the file
                try {
                    Write-Verbose "Extracting: $entryPath"
                    [System.IO.Compression.ZipFileExtensions]::ExtractToFile($entry, $destinationFilePath, $Force)
                    Write-Verbose "Successfully extracted: $destinationFilePath"
                }
                catch {
                    Write-Debug "Error extracting file: $entryPath"
                    Write-Debug $_.Exception.Message
                }
            }
            
            Write-Debug "Successfully extracted module: $moduleName"
            
            # List the extracted files
            Write-Debug "Extracted files for $($moduleName):"
            Get-ChildItem -Path (Join-Path -Path $DestinationPath -ChildPath $moduleName) -Recurse | ForEach-Object {
                Write-Debug "  - $($_.FullName)"
            }
        }
        
        if ($overallSuccess) {
            Write-Debug "All modules extracted successfully."
        } else {
            Write-Debug "Some modules could not be extracted. Please check the output for details."
        }
    }
    catch {
        Write-Debug "Error occurred during extraction"
        Write-Debug $_.Exception.GetType().FullName
        Write-Debug $_.Exception.Message
        if ($_.Exception.InnerException) {
            Write-Debug "Inner Exception: $($_.Exception.InnerException.Message)"
        }
        $overallSuccess = $false
    }
    finally {
        # Close and dispose the ZIP file
        if ($null -ne $zipFile) {
            $zipFile.Dispose()
            Write-Debug "Closed ZIP archive"
        }
    }
}
