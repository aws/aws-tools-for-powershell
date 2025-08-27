<#
.Synopsis
    Removes PowerShell modules with ShouldProcess support.

.Description
    This function provides centralized module removal logic with ShouldProcess support,
    error handling, and detailed logging. It is the lowest level of module-specific
    handling and calls Remove-ItemWithRetry for actual file operations.

    The function accepts PSModuleInfo objects and handles ShouldProcess internally,
    providing detailed error context and logging for module removal operations.

.Parameter Module
    The PSModuleInfo objects representing the modules to remove.
    Multiple modules can be provided via pipeline.

.Parameter Reason
    A description of why the modules are being removed (for logging and confirmation).

.Example
    $modules = Get-Module AWS.Tools.EC2 -ListAvailable
    Remove-ModuleItem -Module $modules

.Example
    $modules = Get-Module AWS.Tools.EC2 -ListAvailable
    Remove-ModuleItem -Module $modules -Reason "Cleanup old versions"

.Example
    Get-Module AWS.Tools.* -ListAvailable | Remove-ModuleItem

.Notes
    This function handles ShouldProcess internally and provides module-specific
    error context and logging. It continues processing remaining modules even if
    individual removals fail, providing a comprehensive summary of results.
#>
function Remove-ModuleItem {
    [CmdletBinding(SupportsShouldProcess)]
    param(
        [Parameter(Mandatory, Position = 0, ValueFromPipeline, ValueFromPipelineByPropertyName)]
        [ValidateNotNullOrEmpty()]
        [System.Management.Automation.PSModuleInfo[]]$Module,
        
        [Parameter()]
        [string]$Reason = "Remove module"
    )
    
    Begin {
        Write-Debug "[$($MyInvocation.MyCommand)] Begin - Reason: $Reason"
        
        # Initialize removal summary
        $script:removalSummary = @{
            SuccessCount = 0
            FailureCount = 0
            RemovedModules = @()
            FailedModules = @()
        }
    }
    
    Process {
        
        foreach ($moduleInfo in $Module) {
            try {
                # Extract module information from PSModuleInfo object
                $moduleName = $moduleInfo.Name
                $moduleVersion = $moduleInfo.Version.ToString()
                $moduleDir = $moduleInfo.ModuleBase
                
                Write-Verbose ("[$($MyInvocation.MyCommand)] Processing module: $moduleName " +
                    "version $moduleVersion at path: $moduleDir")
                
                # Build target description for ShouldProcess with enhanced context
                $target = "$moduleName version $moduleVersion at $moduleDir"
                $operation = "$Reason"
                
                # Handle ShouldProcess internally
                if ($PSCmdlet.ShouldProcess($target, $operation)) {
                    Write-Verbose ("[$($MyInvocation.MyCommand)] Removing module: $moduleName " +
                        "version $moduleVersion")
                    
                    # Remove the module directory directly
                    $removeParams = @{
                        Path = $moduleDir
                        Recurse = $true
                        Force = $true
                        ErrorAction = 'SilentlyContinue'
                    }
                    
                    # Temporarily suppress progress just for this operation
                    $savedProgressPreference = $ProgressPreference
                    $ProgressPreference = 'SilentlyContinue'
                    try {
                        # Use Invoke-WithRetry for module removal to handle transient failures
                        Invoke-WithRetry -ScriptBlock {
                            Remove-Item @removeParams
                        } -OperationName "Remove module directory" -RetryableExceptions $script:Config.retry.RetryableExceptions.FileSystem
                    }
                    finally {
                        $ProgressPreference = $savedProgressPreference
                    }
                    $success = -not (Test-Path -Path $moduleDir)
                    
                    if ($success) {
                        Write-Verbose ("[$($MyInvocation.MyCommand)] Successfully removed " +
                            "module: $moduleName version $moduleVersion")
                        $script:removalSummary.SuccessCount++
                        $script:removalSummary.RemovedModules += "$moduleName ($moduleVersion)"
                        
                    # Check if parent module directory is empty and remove it if so
                    try {
                        # Get parent directory path (module directory)
                        $parentModuleDir = Split-Path -Path $moduleDir -Parent
                        
                        # Check if parent directory exists and is empty
                        if (Test-Path -Path $parentModuleDir) {
                            $parentDirItems = Get-ChildItem -Path $parentModuleDir -Force -ErrorAction SilentlyContinue
                            
                            if ($null -eq $parentDirItems -or $parentDirItems.Count -eq 0) {
                                Write-Verbose ("[$($MyInvocation.MyCommand)] Parent module directory is empty: $parentModuleDir")
                                
                                # Build target description for ShouldProcess
                                $parentTarget = "Empty parent module directory: $parentModuleDir"
                                $parentOperation = "Remove empty module directory"
                                
                                # Handle ShouldProcess for parent directory removal
                                if ($PSCmdlet.ShouldProcess($parentTarget, $parentOperation)) {
                                    Write-Verbose ("[$($MyInvocation.MyCommand)] Removing empty parent module directory: $parentModuleDir")
                                    
                                    # Remove empty parent directory
                                    $parentRemoveParams = @{
                                        Path = $parentModuleDir
                                        Force = $true
                                        ErrorAction = 'SilentlyContinue'
                                    }
                                    
                                    # Temporarily suppress progress just for this operation
                                    $savedProgressPreference = $ProgressPreference
                                    $ProgressPreference = 'SilentlyContinue'
                                    try {
                                        # Use Invoke-WithRetry for parent directory removal to handle transient failures
                                        Invoke-WithRetry -ScriptBlock {
                                            Remove-Item @parentRemoveParams
                                        } -OperationName "Remove parent module directory" -RetryableExceptions $script:Config.retry.RetryableExceptions.FileSystem
                                    }
                                    finally {
                                        $ProgressPreference = $savedProgressPreference
                                    }
                                    $parentSuccess = -not (Test-Path -Path $parentModuleDir)
                                    
                                    if ($parentSuccess) {
                                        Write-Verbose ("[$($MyInvocation.MyCommand)] Successfully removed empty parent module directory: $parentModuleDir")
                                    }
                                    else {
                                        Write-Warning ("[$($MyInvocation.MyCommand)] Failed to remove empty parent module directory: $parentModuleDir")
                                    }
                                }
                            }
                                else {
                                    Write-Verbose ("[$($MyInvocation.MyCommand)] Parent module directory is not empty: $parentModuleDir")
                                }
                            }
                        }
                        catch {
                            # Log error but don't fail the operation if parent directory cleanup fails
                            Write-Warning ("[$($MyInvocation.MyCommand)] Error checking/removing parent module directory: $($_.Exception.Message)")
                        }
                    }
                    else {
                        # Enhanced error message with context and potential remediation
                        $errorMessage = ("Failed to remove module '$moduleName' version " +
                            "$moduleVersion from path '$moduleDir'. The module directory " +
                            "could not be deleted. Ensure the module is not in use and " +
                            "you have sufficient permissions.")
                        Write-Error $errorMessage
                        $script:removalSummary.FailureCount++
                        $script:removalSummary.FailedModules += "$moduleName ($moduleVersion)"
                    }
                }
                else {
                    Write-Verbose ("[$($MyInvocation.MyCommand)] Skipped removal of module: " +
                        "$moduleName version $moduleVersion (ShouldProcess returned false)")
                }
            }
            catch {
                # Enhanced error handling with more context
                $errorModuleName = if ($null -ne $moduleInfo -and $null -ne $moduleInfo.Name) { $moduleInfo.Name } else { "Unknown" }
                $errorModuleVersion = if ($null -ne $moduleInfo -and $null -ne $moduleInfo.Version) { $moduleInfo.Version.ToString() } else { "Unknown" }
                $errorModulePath = if ($null -ne $moduleInfo -and $null -ne $moduleInfo.ModuleBase) { $moduleInfo.ModuleBase } else { "Unknown path" }
                
                # Provide detailed error context for troubleshooting
                $errorMessage = ("Failed to remove module '$errorModuleName' version " +
                    "$errorModuleVersion at path '$errorModulePath': $($_.Exception.Message)")
                    
                # Add remediation suggestions based on error type
                if ($_.Exception -is [System.UnauthorizedAccessException]) {
                    $errorMessage += " Try running with elevated permissions."
                }
                elseif ($_.Exception -is [System.IO.IOException]) {
                    $errorMessage += " The file may be in use by another process."
                }
                
                Write-Error $errorMessage
                
                $script:removalSummary.FailureCount++
                $script:removalSummary.FailedModules += "$errorModuleName ($errorModuleVersion)"
                
                # Continue processing remaining modules despite this failure
                continue
            }
        }
    }
    
    End {
        # Enhanced debug output with more context
        Write-Debug ("[$($MyInvocation.MyCommand)] End - Processed modules. " +
            "Success: $($script:removalSummary.SuccessCount), " +
            "Failed: $($script:removalSummary.FailureCount)")
        
        if ($script:removalSummary.FailureCount -gt 0) {
            Write-Debug ("[$($MyInvocation.MyCommand)] Failed modules: " +
                "$($script:removalSummary.FailedModules -join ', ')")
        }
        
        # Return comprehensive removal summary
        return [PSCustomObject]@{
            SuccessCount = $script:removalSummary.SuccessCount
            FailureCount = $script:removalSummary.FailureCount
            RemovedModules = $script:removalSummary.RemovedModules
            FailedModules = $script:removalSummary.FailedModules
        }
    }
}
