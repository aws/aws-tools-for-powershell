@{
    # Latest major version to use when no version is specified
    LatestMajorVersion = "5"
    
    # Minimum supported version for AWS Tools
    MinimumSupportedVersion = "4.0.0"
    
    # Current minimum installer version required
    CurrentMinInstallerVersion = "1.0.3"
    
    # PowerShell version requirements
    PowerShell = @{
        # Minimum version that supports ProgressAction parameter
        ProgressActionSupportVersion = "7.4.0"
        
        # Major version threshold for Windows PowerShell vs PowerShell Core
        PowerShellCoreMinimumMajorVersion = 6
    }
}
