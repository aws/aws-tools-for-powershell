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

# Argument completions for service Amazon Route 53


$R53_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Route53.AccountLimitType
        "Get-R53AccountLimit/Type"
        {
            $v = "MAX_HEALTH_CHECKS_BY_OWNER","MAX_HOSTED_ZONES_BY_OWNER","MAX_REUSABLE_DELEGATION_SETS_BY_OWNER","MAX_TRAFFIC_POLICIES_BY_OWNER","MAX_TRAFFIC_POLICY_INSTANCES_BY_OWNER"
            break
        }

        # Amazon.Route53.CloudWatchRegion
        {
            ($_ -eq "New-R53HealthCheck/AlarmIdentifier_Region") -Or
            ($_ -eq "Update-R53HealthCheck/AlarmIdentifier_Region")
        }
        {
            $v = "af-south-1","ap-east-1","ap-northeast-1","ap-northeast-2","ap-northeast-3","ap-south-1","ap-south-2","ap-southeast-1","ap-southeast-2","ap-southeast-3","ap-southeast-4","ca-central-1","ca-west-1","cn-north-1","cn-northwest-1","eu-central-1","eu-central-2","eu-north-1","eu-south-1","eu-south-2","eu-west-1","eu-west-2","eu-west-3","il-central-1","me-central-1","me-south-1","sa-east-1","us-east-1","us-east-2","us-gov-east-1","us-gov-west-1","us-iso-east-1","us-iso-west-1","us-isob-east-1","us-west-1","us-west-2"
            break
        }

        # Amazon.Route53.HealthCheckType
        "New-R53HealthCheck/HealthCheckConfig_Type"
        {
            $v = "CALCULATED","CLOUDWATCH_METRIC","HTTP","HTTPS","HTTPS_STR_MATCH","HTTP_STR_MATCH","RECOVERY_CONTROL","TCP"
            break
        }

        # Amazon.Route53.HostedZoneLimitType
        "Get-R53HostedZoneLimit/Type"
        {
            $v = "MAX_RRSETS_BY_ZONE","MAX_VPCS_ASSOCIATED_BY_ZONE"
            break
        }

        # Amazon.Route53.HostedZoneType
        "Get-R53HostedZoneList/HostedZoneType"
        {
            $v = "PrivateHostedZone"
            break
        }

        # Amazon.Route53.InsufficientDataHealthStatus
        {
            ($_ -eq "New-R53HealthCheck/HealthCheckConfig_InsufficientDataHealthStatus") -Or
            ($_ -eq "Update-R53HealthCheck/InsufficientDataHealthStatus")
        }
        {
            $v = "Healthy","LastKnownStatus","Unhealthy"
            break
        }

        # Amazon.Route53.ReusableDelegationSetLimitType
        "Get-R53ReusableDelegationSetLimit/Type"
        {
            $v = "MAX_ZONES_BY_REUSABLE_DELEGATION_SET"
            break
        }

        # Amazon.Route53.RRType
        {
            ($_ -eq "Test-R53DNSAnswer/RecordType") -Or
            ($_ -eq "Get-R53ResourceRecordSet/StartRecordType") -Or
            ($_ -eq "Get-R53TrafficPolicyInstanceList/TrafficPolicyInstanceTypeMarker") -Or
            ($_ -eq "Get-R53TrafficPolicyInstancesByHostedZone/TrafficPolicyInstanceTypeMarker") -Or
            ($_ -eq "Get-R53TrafficPolicyInstancesByPolicy/TrafficPolicyInstanceTypeMarker")
        }
        {
            $v = "A","AAAA","CAA","CNAME","DS","MX","NAPTR","NS","PTR","SOA","SPF","SRV","TXT"
            break
        }

        # Amazon.Route53.TagResourceType
        {
            ($_ -eq "Edit-R53TagsForResource/ResourceType") -Or
            ($_ -eq "Get-R53TagsForResource/ResourceType") -Or
            ($_ -eq "Get-R53TagsForResourceList/ResourceType")
        }
        {
            $v = "healthcheck","hostedzone"
            break
        }

        # Amazon.Route53.VPCRegion
        {
            ($_ -eq "New-R53HostedZone/VPC_VPCRegion") -Or
            ($_ -eq "New-R53VPCAssociationAuthorization/VPC_VPCRegion") -Or
            ($_ -eq "Register-R53VPCWithHostedZone/VPC_VPCRegion") -Or
            ($_ -eq "Remove-R53VPCAssociationAuthorization/VPC_VPCRegion") -Or
            ($_ -eq "Unregister-R53VPCFromHostedZone/VPC_VPCRegion") -Or
            ($_ -eq "Get-R53HostedZonesByVPC/VPCRegion")
        }
        {
            $v = "af-south-1","ap-east-1","ap-northeast-1","ap-northeast-2","ap-northeast-3","ap-south-1","ap-south-2","ap-southeast-1","ap-southeast-2","ap-southeast-3","ap-southeast-4","ca-central-1","ca-west-1","cn-north-1","eu-central-1","eu-central-2","eu-north-1","eu-south-1","eu-south-2","eu-west-1","eu-west-2","eu-west-3","il-central-1","me-central-1","me-south-1","sa-east-1","us-east-1","us-east-2","us-gov-east-1","us-gov-west-1","us-iso-east-1","us-iso-west-1","us-isob-east-1","us-west-1","us-west-2"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$R53_map = @{
    "AlarmIdentifier_Region"=@("New-R53HealthCheck","Update-R53HealthCheck")
    "HealthCheckConfig_InsufficientDataHealthStatus"=@("New-R53HealthCheck")
    "HealthCheckConfig_Type"=@("New-R53HealthCheck")
    "HostedZoneType"=@("Get-R53HostedZoneList")
    "InsufficientDataHealthStatus"=@("Update-R53HealthCheck")
    "RecordType"=@("Test-R53DNSAnswer")
    "ResourceType"=@("Edit-R53TagsForResource","Get-R53TagsForResource","Get-R53TagsForResourceList")
    "StartRecordType"=@("Get-R53ResourceRecordSet")
    "TrafficPolicyInstanceTypeMarker"=@("Get-R53TrafficPolicyInstanceList","Get-R53TrafficPolicyInstancesByHostedZone","Get-R53TrafficPolicyInstancesByPolicy")
    "Type"=@("Get-R53AccountLimit","Get-R53HostedZoneLimit","Get-R53ReusableDelegationSetLimit")
    "VPC_VPCRegion"=@("New-R53HostedZone","New-R53VPCAssociationAuthorization","Register-R53VPCWithHostedZone","Remove-R53VPCAssociationAuthorization","Unregister-R53VPCFromHostedZone")
    "VPCRegion"=@("Get-R53HostedZonesByVPC")
}

_awsArgumentCompleterRegistration $R53_Completers $R53_map

$R53_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.R53.$($commandName.Replace('-', ''))Cmdlet]"
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

$R53_SelectMap = @{
    "Select"=@("Enable-R53KeySigningKey",
               "Register-R53VPCWithHostedZone",
               "Edit-R53CidrCollection",
               "Edit-R53ResourceRecordSet",
               "Edit-R53TagsForResource",
               "New-R53CidrCollection",
               "New-R53HealthCheck",
               "New-R53HostedZone",
               "New-R53KeySigningKey",
               "New-R53QueryLoggingConfig",
               "New-R53ReusableDelegationSet",
               "New-R53TrafficPolicy",
               "New-R53TrafficPolicyInstance",
               "New-R53TrafficPolicyVersion",
               "New-R53VPCAssociationAuthorization",
               "Disable-R53KeySigningKey",
               "Remove-R53CidrCollection",
               "Remove-R53HealthCheck",
               "Remove-R53HostedZone",
               "Remove-R53KeySigningKey",
               "Remove-R53QueryLoggingConfig",
               "Remove-R53ReusableDelegationSet",
               "Remove-R53TrafficPolicy",
               "Remove-R53TrafficPolicyInstance",
               "Remove-R53VPCAssociationAuthorization",
               "Disable-R53HostedZoneDNSSEC",
               "Unregister-R53VPCFromHostedZone",
               "Enable-R53HostedZoneDNSSEC",
               "Get-R53AccountLimit",
               "Get-R53Change",
               "Get-R53CheckerIpRange",
               "Get-R53DNSSEC",
               "Get-R53GeoLocation",
               "Get-R53HealthCheck",
               "Get-R53HealthCheckCount",
               "Get-R53HealthCheckLastFailureReason",
               "Get-R53HealthCheckStatus",
               "Get-R53HostedZone",
               "Get-R53HostedZoneCount",
               "Get-R53HostedZoneLimit",
               "Get-R53QueryLoggingConfig",
               "Get-R53ReusableDelegationSet",
               "Get-R53ReusableDelegationSetLimit",
               "Get-R53TrafficPolicy",
               "Get-R53TrafficPolicyInstance",
               "Get-R53TrafficPolicyInstanceCount",
               "Get-R53CidrBlockList",
               "Get-R53CidrCollectionList",
               "Get-R53CidrLocationList",
               "Get-R53GeoLocationList",
               "Get-R53HealthCheckList",
               "Get-R53HostedZoneList",
               "Get-R53HostedZonesByVPC",
               "Get-R53QueryLoggingConfigList",
               "Get-R53ResourceRecordSet",
               "Get-R53ReusableDelegationSetList",
               "Get-R53TagsForResource",
               "Get-R53TagsForResourceList",
               "Get-R53TrafficPolicyList",
               "Get-R53TrafficPolicyInstanceList",
               "Get-R53TrafficPolicyInstancesByHostedZone",
               "Get-R53TrafficPolicyInstancesByPolicy",
               "Get-R53TrafficPolicyVersionList",
               "Get-R53VPCAssociationAuthorizationList",
               "Test-R53DNSAnswer",
               "Update-R53HealthCheck",
               "Update-R53HostedZoneComment",
               "Update-R53TrafficPolicyComment",
               "Update-R53TrafficPolicyInstance",
               "Get-R53HostedZonesByName")
}

_awsArgumentCompleterRegistration $R53_SelectCompleters $R53_SelectMap

