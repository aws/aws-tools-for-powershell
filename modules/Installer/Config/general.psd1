@{
    # Temporary repository name used during installation
    TempRepoName = "AWSToolsTemp"

    <#
        Note this bug introduced in PowerShellGet . . . 

        PS> Find-Module AWS.Tools.Common | Select CompanyName

        CompanyName
        -----------
        aws-dotnet-sdk-team

        . . . and resolved in PSResourceGet:

        PS> Find-PSResource AWS.Tools.Common | Select CompanyName

        CompanyName
        -----------
        Amazon.com, Inc

        AWS.Tools.Installer PSGetModuleInfo.xml generation is based on PowerShellGet because it satisfies both Remove-Module and Remove-PSResource. Correcting the company name value breaks Uninstall-PSModule (still works with Uninstall-PSResource).
    #>
    # Expected company name for AWS Tools modules (See comment above for further explanation.)
    ExpectedModuleCompanyName = "aws-dotnet-sdk-team"
    
    # Maximum number of modules to find individually before switching to bulk operations
    MaxModulesToFindIndividually = 3
    
    # PowerShell Gallery repository information
    PowerShellGallery = @{
        Repository = "PSGallery"
        RepositorySourceLocation = "https://www.powershellgallery.com/api/v2"
    }
    
    # CloudFront base configuration
    CloudFront = @{
        BaseUrl = "https://sdk-for-net.amazonwebservices.com"
        Paths = @{
            AWSTools = "ps"
            AWSToolsInstaller = "ps/installer"
        }
    }
    
    # Module-specific configuration for different zip types
    Modules = @{
        "AWS.Tools" = @{
            # CloudFront URL patterns (version will be dynamically determined)
            CloudFrontUrls = @{
                VersionEndpointPattern = "{baseUrl}/{path}/v{majorVersion}/latest/awspowershell_versioninfo.json"
                ZipDownloadUrlPattern = "{baseUrl}/{path}/v{majorVersion}/latest/AWS.Tools.zip"
                ZipDownloadUrlVersionPattern = "{baseUrl}/{path}/releases/AWS.Tools.{version}.zip"
            }
            
            # Module metadata
            ModulePrefix = "AWS.Tools"
            ZipFileName = "AWS.Tools.zip"
            DefaultMajorVersion = "5"  # Can be overridden by version resolution
            
            # Installation settings
            DefaultScope = "CurrentUser"
            SupportsBulkInstall = $true
            SupportsVersionSelection = $true
            SupportsWildcardVersions = $true
        }
        
        "AWS.Tools.Installer" = @{
            # CloudFront URL patterns
            CloudFrontUrls = @{
                VersionEndpointPattern = "{baseUrl}/{path}/v{majorVersion}/latest/awspowershell_versioninfo.json"
                ZipDownloadUrlPattern = "{baseUrl}/{path}/v{majorVersion}/latest/AWS.Tools.Installer.zip"
                ZipDownloadUrlVersionPattern = "{baseUrl}/{path}/releases/AWS.Tools.Installer.{version}.zip"
            }
            
            # Module metadata
            ModulePrefix = "AWS.Tools.Installer"
            ZipFileName = "AWS.Tools.Installer.zip"
            DefaultMajorVersion = "1"  # Installer uses v1 path
            
            # Installation settings
            DefaultScope = "CurrentUser"
            SupportsBulkInstall = $false
            SupportsVersionSelection = $true
            SupportsWildcardVersions = $true  # Enable wildcard patterns for consistent user experience
        }
    }
    
    # Default module type when none specified
    DefaultModuleType = "AWS.Tools"
}
