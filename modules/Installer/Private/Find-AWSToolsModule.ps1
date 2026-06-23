<#
.Synopsis
    Finds AWS.Tools modules in PowerShell Gallery.

.Description
    Searches for AWS.Tools modules in PowerShell Gallery repository. This function is used by
    legacy compatibility cmdlets that require PowerShell Gallery access.

.Parameter Name
    Specifies names of the AWS.Tools modules to find.

.Parameter Proxy
    Specifies a proxy server for the request.

.Parameter ProxyCredential
    Specifies credentials for the proxy server.
#>
function Find-AWSToolsModule {
    Param(
        ## Specifies names of the AWS.Tools modules to find.
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
        Write-Verbose "[$($MyInvocation.MyCommand)] Name=($Name)"
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

        # 'Find-Module AWS.Tools*' is only slightly slower than Find-Module for a single module
        if ($Name.Count -gt $script:Config.general.MaxModulesToFindIndividually) {
            $availableModules += PowerShellGet\Find-Module -Name 'AWS.Tools*' -Repository 'PSGallery' @proxyParams -ErrorAction 'Stop' | 
                Where-Object { $_.Name -in $Name -and $_.CompanyName -ceq $script:Config.general.ExpectedModuleCompanyName }
            $missingModules = $Name | Where-Object { $_ -notin ($availableModules | Select-Object -ExpandProperty Name) }
            if ($missingModules) {
                Write-Verbose "[$($MyInvocation.MyCommand)] Retrying Find-Module on ($missingModules)"
            }
        }

        if ($missingModules) {
            # 'Find-Module AWS.Tools*' doesn't always return all modules, so we have to retry missing ones
            $missingModules | ForEach-Object {
                $availableModules += PowerShellGet\Find-Module -Name $_ -Repository 'PSGallery' @proxyParams -ErrorAction 'Ignore' | 
                    Where-Object { $_.Name -in $Name -and $_.CompanyName -ceq $script:Config.general.ExpectedModuleCompanyName }
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
