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

# Argument completions for service Amazon Elastic Container Service for Kubernetes


$EKS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.EKS.AccessScopeType
        "Add-EKSAccessPolicy/AccessScope_Type"
        {
            $v = "cluster","namespace"
            break
        }

        # Amazon.EKS.AMITypes
        "New-EKSNodegroup/AmiType"
        {
            $v = "AL2023_ARM_64_NVIDIA","AL2023_ARM_64_STANDARD","AL2023_x86_64_NEURON","AL2023_x86_64_NVIDIA","AL2023_x86_64_STANDARD","AL2_ARM_64","AL2_x86_64","AL2_x86_64_GPU","BOTTLEROCKET_ARM_64","BOTTLEROCKET_ARM_64_FIPS","BOTTLEROCKET_ARM_64_NVIDIA","BOTTLEROCKET_x86_64","BOTTLEROCKET_x86_64_FIPS","BOTTLEROCKET_x86_64_NVIDIA","CUSTOM","WINDOWS_CORE_2019_x86_64","WINDOWS_CORE_2022_x86_64","WINDOWS_FULL_2019_x86_64","WINDOWS_FULL_2022_x86_64"
            break
        }

        # Amazon.EKS.AuthenticationMode
        {
            ($_ -eq "New-EKSCluster/AccessConfig_AuthenticationMode") -Or
            ($_ -eq "Update-EKSClusterConfig/AccessConfig_AuthenticationMode")
        }
        {
            $v = "API","API_AND_CONFIG_MAP","CONFIG_MAP"
            break
        }

        # Amazon.EKS.CapabilityDeletePropagationPolicy
        {
            ($_ -eq "New-EKSCapability/DeletePropagationPolicy") -Or
            ($_ -eq "Update-EKSCapability/DeletePropagationPolicy")
        }
        {
            $v = "RETAIN"
            break
        }

        # Amazon.EKS.CapabilityType
        "New-EKSCapability/Type"
        {
            $v = "ACK","ARGOCD","KRO"
            break
        }

        # Amazon.EKS.CapacityTypes
        "New-EKSNodegroup/CapacityType"
        {
            $v = "CAPACITY_BLOCK","ON_DEMAND","SPOT"
            break
        }

        # Amazon.EKS.ClusterVersionStatus
        "Get-EKSClusterVersion/Status"
        {
            $v = "extended-support","standard-support","unsupported"
            break
        }

        # Amazon.EKS.ConnectorConfigProvider
        "Register-EKSCluster/ConnectorConfig_Provider"
        {
            $v = "AKS","ANTHOS","EC2","EKS_ANYWHERE","GKE","OPENSHIFT","OTHER","RANCHER","TANZU"
            break
        }

        # Amazon.EKS.EksAnywhereSubscriptionLicenseType
        "New-EKSEksAnywhereSubscription/LicenseType"
        {
            $v = "Cluster"
            break
        }

        # Amazon.EKS.EksAnywhereSubscriptionTermUnit
        "New-EKSEksAnywhereSubscription/Term_Unit"
        {
            $v = "MONTHS"
            break
        }

        # Amazon.EKS.IpFamily
        {
            ($_ -eq "New-EKSCluster/KubernetesNetworkConfig_IpFamily") -Or
            ($_ -eq "Update-EKSClusterConfig/KubernetesNetworkConfig_IpFamily")
        }
        {
            $v = "ipv4","ipv6"
            break
        }

        # Amazon.EKS.NodegroupUpdateStrategies
        {
            ($_ -eq "New-EKSNodegroup/UpdateConfig_UpdateStrategy") -Or
            ($_ -eq "Update-EKSNodegroupConfig/UpdateConfig_UpdateStrategy")
        }
        {
            $v = "DEFAULT","MINIMAL"
            break
        }

        # Amazon.EKS.ProvisionedControlPlaneTier
        {
            ($_ -eq "New-EKSCluster/ControlPlaneScalingConfig_Tier") -Or
            ($_ -eq "Update-EKSClusterConfig/ControlPlaneScalingConfig_Tier")
        }
        {
            $v = "standard","tier-2xl","tier-4xl","tier-xl"
            break
        }

        # Amazon.EKS.ResolveConflicts
        {
            ($_ -eq "New-EKSAddon/ResolveConflict") -Or
            ($_ -eq "Update-EKSAddon/ResolveConflict")
        }
        {
            $v = "NONE","OVERWRITE","PRESERVE"
            break
        }

        # Amazon.EKS.SupportType
        {
            ($_ -eq "New-EKSCluster/UpgradePolicy_SupportType") -Or
            ($_ -eq "Update-EKSClusterConfig/UpgradePolicy_SupportType")
        }
        {
            $v = "EXTENDED","STANDARD"
            break
        }

        # Amazon.EKS.VersionStatus
        "Get-EKSClusterVersion/VersionStatus"
        {
            $v = "EXTENDED_SUPPORT","STANDARD_SUPPORT","UNSUPPORTED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EKS_map = @{
    "AccessConfig_AuthenticationMode"=@("New-EKSCluster","Update-EKSClusterConfig")
    "AccessScope_Type"=@("Add-EKSAccessPolicy")
    "AmiType"=@("New-EKSNodegroup")
    "CapacityType"=@("New-EKSNodegroup")
    "ConnectorConfig_Provider"=@("Register-EKSCluster")
    "ControlPlaneScalingConfig_Tier"=@("New-EKSCluster","Update-EKSClusterConfig")
    "DeletePropagationPolicy"=@("New-EKSCapability","Update-EKSCapability")
    "KubernetesNetworkConfig_IpFamily"=@("New-EKSCluster","Update-EKSClusterConfig")
    "LicenseType"=@("New-EKSEksAnywhereSubscription")
    "ResolveConflict"=@("New-EKSAddon","Update-EKSAddon")
    "Status"=@("Get-EKSClusterVersion")
    "Term_Unit"=@("New-EKSEksAnywhereSubscription")
    "Type"=@("New-EKSCapability")
    "UpdateConfig_UpdateStrategy"=@("New-EKSNodegroup","Update-EKSNodegroupConfig")
    "UpgradePolicy_SupportType"=@("New-EKSCluster","Update-EKSClusterConfig")
    "VersionStatus"=@("Get-EKSClusterVersion")
}

_awsArgumentCompleterRegistration $EKS_Completers $EKS_map

$EKS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EKS.$($commandName.Replace('-', ''))Cmdlet]"
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

$EKS_SelectMap = @{
    "Select"=@("Add-EKSAccessPolicy",
               "Add-EKSEncryptionConfig",
               "Add-EKSIdentityProviderConfig",
               "New-EKSAccessEntry",
               "New-EKSAddon",
               "New-EKSCapability",
               "New-EKSCluster",
               "New-EKSEksAnywhereSubscription",
               "New-EKSFargateProfile",
               "New-EKSNodegroup",
               "New-EKSPodIdentityAssociation",
               "Remove-EKSAccessEntry",
               "Remove-EKSAddon",
               "Remove-EKSCapability",
               "Remove-EKSCluster",
               "Remove-EKSEksAnywhereSubscription",
               "Remove-EKSFargateProfile",
               "Remove-EKSNodegroup",
               "Remove-EKSPodIdentityAssociation",
               "Unregister-EKSCluster",
               "Get-EKSAccessEntry",
               "Get-EKSAddon",
               "Get-EKSAddonConfiguration",
               "Get-EKSAddonVersion",
               "Get-EKSCapabilityDetail",
               "Get-EKSCluster",
               "Get-EKSClusterVersion",
               "Get-EKSEksAnywhereSubscription",
               "Get-EKSFargateProfile",
               "Get-EKSIdentityProviderConfig",
               "Get-EKSInsight",
               "Get-EKSInsightsRefresh",
               "Get-EKSNodegroup",
               "Get-EKSPodIdentityAssociation",
               "Get-EKSUpdate",
               "Remove-EKSAccessPolicy",
               "Remove-EKSIdentityProviderConfig",
               "Get-EKSAccessEntryList",
               "Get-EKSAccessPolicyList",
               "Get-EKSAddonList",
               "Get-EKSAssociatedAccessPolicyList",
               "Get-EKSCapabilityList",
               "Get-EKSClusterList",
               "Get-EKSEksAnywhereSubscriptionList",
               "Get-EKSFargateProfileList",
               "Get-EKSIdentityProviderConfigList",
               "Get-EKSInsightList",
               "Get-EKSNodegroupList",
               "Get-EKSPodIdentityAssociationList",
               "Get-EKSResourceTag",
               "Get-EKSUpdateList",
               "Register-EKSCluster",
               "Start-EKSInsightsRefresh",
               "Add-EKSResourceTag",
               "Remove-EKSResourceTag",
               "Update-EKSAccessEntry",
               "Update-EKSAddon",
               "Update-EKSCapability",
               "Update-EKSClusterConfig",
               "Update-EKSClusterVersion",
               "Update-EKSEksAnywhereSubscription",
               "Update-EKSNodegroupConfig",
               "Update-EKSNodegroupVersion",
               "Update-EKSPodIdentityAssociation")
}

_awsArgumentCompleterRegistration $EKS_SelectCompleters $EKS_SelectMap

