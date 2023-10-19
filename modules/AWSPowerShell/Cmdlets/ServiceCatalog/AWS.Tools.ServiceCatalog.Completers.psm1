# Auto-generated argument completers for parameters of SDK ConstantClass-derived type used in cmdlets.
# Do not modify this file; it may be overwritten during version upgrades.

$psMajorVersion = $PSVersionTable.PSVersion.Major
if ($psMajorVersion -eq 2) 
{ 
	Write-Verbose "Dynamic argument completion not supported in PowerShell version 2; skipping load."
	return 
}

# PowerShell's native Register-ArgumentCompleter cmdlet is available on v5.0 or higher. For lower
# version, we can use the version in the TabExpansion++ module if installed.
$registrationCmdletAvailable = ($psMajorVersion -ge 5) -Or !((Get-Command Register-ArgumentCompleter -ea Ignore) -eq $null)

# internal function to perform the registration using either cmdlet or manipulation
# of the options table
function _awsArgumentCompleterRegistration()
{
    param
    (
        [scriptblock]$scriptBlock,
        [hashtable]$param2CmdletsMap
    )

    if ($registrationCmdletAvailable)
    {
        foreach ($paramName in $param2CmdletsMap.Keys)
        {
             $args = @{
                "ScriptBlock" = $scriptBlock
                "Parameter" = $paramName
            }

            $cmdletNames = $param2CmdletsMap[$paramName]
            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                $args["Command"] = $cmdletNames
            }

            Register-ArgumentCompleter @args
        }
    }
    else
    {
        if (-not $global:options) { $global:options = @{ CustomArgumentCompleters = @{ }; NativeArgumentCompleters = @{ } } }

        foreach ($paramName in $param2CmdletsMap.Keys)
        {
            $cmdletNames = $param2CmdletsMap[$paramName]

            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                foreach ($cn in $cmdletNames)
                {
                    $fqn =  [string]::Concat($cn, ":", $paramName)
                    $global:options['CustomArgumentCompleters'][$fqn] = $scriptBlock
                }
            }
            else
            {
                $global:options['CustomArgumentCompleters'][$paramName] = $scriptBlock
            }
        }

        $function:tabexpansion2 = $function:tabexpansion2 -replace 'End\r\n{', 'End { if ($null -ne $options) { $options += $global:options} else {$options = $global:options}'
    }
}

# To allow for same-name parameters of different ConstantClass-derived types 
# each completer function checks on command name concatenated with parameter name.
# Additionally, the standard code pattern for completers is to pipe through 
# sort-object after filtering against $wordToComplete but we omit this as our members 
# are already sorted.

# Argument completions for service AWS Service Catalog


$SC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ServiceCatalog.AccessLevelFilterKey
        {
            ($_ -eq "Find-SCProvisionedProduct/AccessLevelFilter_Key") -Or
            ($_ -eq "Get-SCProvisionedProduct/AccessLevelFilter_Key") -Or
            ($_ -eq "Get-SCProvisionedProductPlanList/AccessLevelFilter_Key") -Or
            ($_ -eq "Get-SCRecordHistory/AccessLevelFilter_Key")
        }
        {
            $v = "Account","Role","User"
            break
        }

        # Amazon.ServiceCatalog.DescribePortfolioShareType
        "Get-SCPortfolioShare/Type"
        {
            $v = "ACCOUNT","ORGANIZATION","ORGANIZATIONAL_UNIT","ORGANIZATION_MEMBER_ACCOUNT"
            break
        }

        # Amazon.ServiceCatalog.EngineWorkflowStatus
        {
            ($_ -eq "Start-SCProvisionProductEngineWorkflowResult/Status") -Or
            ($_ -eq "Start-SCTerminateProvisionedProductEngineWorkflowResult/Status") -Or
            ($_ -eq "Start-SCUpdateProvisionedProductEngineWorkflowResult/Status")
        }
        {
            $v = "FAILED","SUCCEEDED"
            break
        }

        # Amazon.ServiceCatalog.OrganizationNodeType
        {
            ($_ -eq "New-SCPortfolioShare/OrganizationNode_Type") -Or
            ($_ -eq "Remove-SCPortfolioShare/OrganizationNode_Type") -Or
            ($_ -eq "Update-SCPortfolioShare/OrganizationNode_Type") -Or
            ($_ -eq "Get-SCOrganizationPortfolioAccessList/OrganizationNodeType")
        }
        {
            $v = "ACCOUNT","ORGANIZATION","ORGANIZATIONAL_UNIT"
            break
        }

        # Amazon.ServiceCatalog.PortfolioShareType
        {
            ($_ -eq "Deny-SCPortfolioShare/PortfolioShareType") -Or
            ($_ -eq "Get-SCAcceptedPortfolioShareList/PortfolioShareType") -Or
            ($_ -eq "Receive-SCPortfolioShare/PortfolioShareType")
        }
        {
            $v = "AWS_ORGANIZATIONS","AWS_SERVICECATALOG","IMPORTED"
            break
        }

        # Amazon.ServiceCatalog.PrincipalType
        {
            ($_ -eq "Register-SCPrincipalWithPortfolio/PrincipalType") -Or
            ($_ -eq "Unregister-SCPrincipalFromPortfolio/PrincipalType")
        }
        {
            $v = "IAM","IAM_PATTERN"
            break
        }

        # Amazon.ServiceCatalog.ProductSource
        "Find-SCProductsAsAdmin/ProductSource"
        {
            $v = "ACCOUNT"
            break
        }

        # Amazon.ServiceCatalog.ProductType
        "New-SCProduct/ProductType"
        {
            $v = "CLOUD_FORMATION_TEMPLATE","EXTERNAL","MARKETPLACE","TERRAFORM_CLOUD","TERRAFORM_OPEN_SOURCE"
            break
        }

        # Amazon.ServiceCatalog.ProductViewSortBy
        {
            ($_ -eq "Find-SCProduct/SortBy") -Or
            ($_ -eq "Find-SCProductsAsAdmin/SortBy")
        }
        {
            $v = "CreationDate","Title","VersionCount"
            break
        }

        # Amazon.ServiceCatalog.ProvisionedProductPlanType
        "New-SCProvisionedProductPlan/PlanType"
        {
            $v = "CLOUDFORMATION"
            break
        }

        # Amazon.ServiceCatalog.ProvisioningArtifactGuidance
        "Update-SCProvisioningArtifact/Guidance"
        {
            $v = "DEFAULT","DEPRECATED"
            break
        }

        # Amazon.ServiceCatalog.ProvisioningArtifactType
        {
            ($_ -eq "New-SCProvisioningArtifact/Parameters_Type") -Or
            ($_ -eq "New-SCProduct/ProvisioningArtifactParameters_Type")
        }
        {
            $v = "CLOUD_FORMATION_TEMPLATE","EXTERNAL","MARKETPLACE_AMI","MARKETPLACE_CAR","TERRAFORM_CLOUD","TERRAFORM_OPEN_SOURCE"
            break
        }

        # Amazon.ServiceCatalog.ServiceActionDefinitionType
        "New-SCServiceAction/DefinitionType"
        {
            $v = "SSM_AUTOMATION"
            break
        }

        # Amazon.ServiceCatalog.SortOrder
        {
            ($_ -eq "Find-SCProduct/SortOrder") -Or
            ($_ -eq "Find-SCProductsAsAdmin/SortOrder") -Or
            ($_ -eq "Find-SCProvisionedProduct/SortOrder")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.ServiceCatalog.SourceType
        {
            ($_ -eq "New-SCProduct/SourceConnection_Type") -Or
            ($_ -eq "Update-SCProduct/SourceConnection_Type")
        }
        {
            $v = "CODESTAR"
            break
        }

        # Amazon.ServiceCatalog.StackSetOperationType
        "Update-SCProvisionedProduct/ProvisioningPreferences_StackSetOperationType"
        {
            $v = "CREATE","DELETE","UPDATE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SC_map = @{
    "AccessLevelFilter_Key"=@("Find-SCProvisionedProduct","Get-SCProvisionedProduct","Get-SCProvisionedProductPlanList","Get-SCRecordHistory")
    "DefinitionType"=@("New-SCServiceAction")
    "Guidance"=@("Update-SCProvisioningArtifact")
    "OrganizationNode_Type"=@("New-SCPortfolioShare","Remove-SCPortfolioShare","Update-SCPortfolioShare")
    "OrganizationNodeType"=@("Get-SCOrganizationPortfolioAccessList")
    "Parameters_Type"=@("New-SCProvisioningArtifact")
    "PlanType"=@("New-SCProvisionedProductPlan")
    "PortfolioShareType"=@("Deny-SCPortfolioShare","Get-SCAcceptedPortfolioShareList","Receive-SCPortfolioShare")
    "PrincipalType"=@("Register-SCPrincipalWithPortfolio","Unregister-SCPrincipalFromPortfolio")
    "ProductSource"=@("Find-SCProductsAsAdmin")
    "ProductType"=@("New-SCProduct")
    "ProvisioningArtifactParameters_Type"=@("New-SCProduct")
    "ProvisioningPreferences_StackSetOperationType"=@("Update-SCProvisionedProduct")
    "SortBy"=@("Find-SCProduct","Find-SCProductsAsAdmin")
    "SortOrder"=@("Find-SCProduct","Find-SCProductsAsAdmin","Find-SCProvisionedProduct")
    "SourceConnection_Type"=@("New-SCProduct","Update-SCProduct")
    "Status"=@("Start-SCProvisionProductEngineWorkflowResult","Start-SCTerminateProvisionedProductEngineWorkflowResult","Start-SCUpdateProvisionedProductEngineWorkflowResult")
    "Type"=@("Get-SCPortfolioShare")
}

_awsArgumentCompleterRegistration $SC_Completers $SC_map

$SC_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.SC.$($commandName.Replace('-', ''))Cmdlet]"
    if (-not $cmdletType) {
        return
    }
    $awsCmdletAttribute = $cmdletType.GetCustomAttributes([Amazon.PowerShell.Common.AWSCmdletAttribute], $false)
    if (-not $awsCmdletAttribute) {
        return
    }
    $type = $awsCmdletAttribute.SelectReturnType
    if (-not $type) {
        return
    }

    $splitSelect = $wordToComplete -Split '\.'
    $splitSelect | Select-Object -First ($splitSelect.Length - 1) | ForEach-Object {
        $propertyName = $_
        $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')) | Where-Object { $_.Name -ieq $propertyName }
        if ($properties.Length -ne 1) {
            break
        }
        $type = $properties.PropertyType
        $prefix += "$($properties.Name)."

        $asEnumerableType = $type.GetInterface('System.Collections.Generic.IEnumerable`1')
        if ($asEnumerableType -and $type -ne [System.String]) {
            $type =  $asEnumerableType.GetGenericArguments()[0]
        }
    }

    $v = @( '*' )
    $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')).Name | Sort-Object
    if ($properties) {
        $v += ($properties | ForEach-Object { $prefix + $_ })
    }
    $parameters = $cmdletType.GetProperties(('Instance', 'Public')) | Where-Object { $_.GetCustomAttributes([System.Management.Automation.ParameterAttribute], $true) } | Select-Object -ExpandProperty Name | Sort-Object
    if ($parameters) {
        $v += ($parameters | ForEach-Object { "^$_" })
    }

    $v |
        Where-Object { $_ -match "^$([System.Text.RegularExpressions.Regex]::Escape($wordToComplete)).*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SC_SelectMap = @{
    "Select"=@("Receive-SCPortfolioShare",
               "Register-SCBudgetWithResource",
               "Register-SCPrincipalWithPortfolio",
               "Register-SCProductWithPortfolio",
               "Add-SCServiceActionAssociationWithProvisioningArtifact",
               "Add-SCTagOptionToResource",
               "Add-SCServiceActionAssociationWithProvisioningArtifactBatch",
               "Remove-SCServiceActionAssociationFromProvisioningArtifactBatch",
               "Copy-SCProduct",
               "New-SCConstraint",
               "New-SCPortfolio",
               "New-SCPortfolioShare",
               "New-SCProduct",
               "New-SCProvisionedProductPlan",
               "New-SCProvisioningArtifact",
               "New-SCServiceAction",
               "New-SCTagOption",
               "Remove-SCConstraint",
               "Remove-SCPortfolio",
               "Remove-SCPortfolioShare",
               "Remove-SCProduct",
               "Remove-SCProvisionedProductPlan",
               "Remove-SCProvisioningArtifact",
               "Remove-SCServiceAction",
               "Remove-SCTagOption",
               "Get-SCConstraint",
               "Get-SCCopyProductStatus",
               "Get-SCPortfolio",
               "Get-SCPortfolioShare",
               "Get-SCPortfolioShareStatus",
               "Get-SCProduct",
               "Get-SCProductAsAdmin",
               "Get-SCProductView",
               "Get-SCProvisionedProductDetail",
               "Get-SCProvisionedProductPlan",
               "Get-SCProvisioningArtifact",
               "Get-SCProvisioningParameter",
               "Get-SCRecord",
               "Get-SCServiceAction",
               "Get-SCServiceActionExecutionParameter",
               "Get-SCTagOption",
               "Disable-SCAWSOrganizationsAccess",
               "Unregister-SCBudgetFromResource",
               "Unregister-SCPrincipalFromPortfolio",
               "Unregister-SCProductFromPortfolio",
               "Remove-SCServiceActionAssociationFromProvisioningArtifact",
               "Remove-SCTagOptionFromResource",
               "Enable-SCAWSOrganizationsAccess",
               "Start-SCProvisionedProductPlanExecution",
               "Start-SCProvisionedProductServiceActionExecution",
               "Get-SCAWSOrganizationsAccessStatus",
               "Get-SCProvisionedProductOutput",
               "Import-SCAsProvisionedProduct",
               "Get-SCAcceptedPortfolioShareList",
               "Get-SCBudgetsForResource",
               "Get-SCConstrainsForPortfolioList",
               "Get-SCLaunchPath",
               "Get-SCOrganizationPortfolioAccessList",
               "Get-SCPortfolioAccessList",
               "Get-SCPortfolioList",
               "Get-SCProductPortfolioList",
               "Get-SCPrincipalsForPortfolio",
               "Get-SCProvisionedProductPlanList",
               "Get-SCProvisioningArtifactList",
               "Get-SCProvisioningArtifactsForServiceActionList",
               "Get-SCRecordHistory",
               "Get-SCResourcesForTagOption",
               "Get-SCServiceActionList",
               "Get-SCServiceActionsForProvisioningArtifactList",
               "Get-SCStackInstancesForProvisionedProduct",
               "Get-SCTagOptionList",
               "Start-SCProvisionProductEngineWorkflowResult",
               "Start-SCTerminateProvisionedProductEngineWorkflowResult",
               "Start-SCUpdateProvisionedProductEngineWorkflowResult",
               "New-SCProvisionedProduct",
               "Deny-SCPortfolioShare",
               "Get-SCProvisionedProduct",
               "Find-SCProduct",
               "Find-SCProductsAsAdmin",
               "Find-SCProvisionedProduct",
               "Remove-SCProvisionedProduct",
               "Update-SCConstraint",
               "Update-SCPortfolio",
               "Update-SCPortfolioShare",
               "Update-SCProduct",
               "Update-SCProvisionedProduct",
               "Update-SCProvisionedProductProperty",
               "Update-SCProvisioningArtifact",
               "Update-SCServiceAction",
               "Update-SCTagOption")
}

_awsArgumentCompleterRegistration $SC_SelectCompleters $SC_SelectMap

