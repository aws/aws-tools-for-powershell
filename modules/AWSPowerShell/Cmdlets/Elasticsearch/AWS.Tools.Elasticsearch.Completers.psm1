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

# Argument completions for service Amazon Elasticsearch


$ES_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Elasticsearch.ESPartitionInstanceType
        {
            ($_ -eq "New-ESDomain/ElasticsearchClusterConfig_DedicatedMasterType") -Or
            ($_ -eq "Update-ESDomainConfig/ElasticsearchClusterConfig_DedicatedMasterType") -Or
            ($_ -eq "New-ESDomain/ElasticsearchClusterConfig_InstanceType") -Or
            ($_ -eq "Update-ESDomainConfig/ElasticsearchClusterConfig_InstanceType") -Or
            ($_ -eq "Get-ESInstanceTypeLimit/InstanceType")
        }
        {
            $v = "c4.2xlarge.elasticsearch","c4.4xlarge.elasticsearch","c4.8xlarge.elasticsearch","c4.large.elasticsearch","c4.xlarge.elasticsearch","c5.18xlarge.elasticsearch","c5.2xlarge.elasticsearch","c5.4xlarge.elasticsearch","c5.9xlarge.elasticsearch","c5.large.elasticsearch","c5.xlarge.elasticsearch","d2.2xlarge.elasticsearch","d2.4xlarge.elasticsearch","d2.8xlarge.elasticsearch","d2.xlarge.elasticsearch","i2.2xlarge.elasticsearch","i2.xlarge.elasticsearch","i3.16xlarge.elasticsearch","i3.2xlarge.elasticsearch","i3.4xlarge.elasticsearch","i3.8xlarge.elasticsearch","i3.large.elasticsearch","i3.xlarge.elasticsearch","m3.2xlarge.elasticsearch","m3.large.elasticsearch","m3.medium.elasticsearch","m3.xlarge.elasticsearch","m4.10xlarge.elasticsearch","m4.2xlarge.elasticsearch","m4.4xlarge.elasticsearch","m4.large.elasticsearch","m4.xlarge.elasticsearch","m5.12xlarge.elasticsearch","m5.2xlarge.elasticsearch","m5.4xlarge.elasticsearch","m5.large.elasticsearch","m5.xlarge.elasticsearch","r3.2xlarge.elasticsearch","r3.4xlarge.elasticsearch","r3.8xlarge.elasticsearch","r3.large.elasticsearch","r3.xlarge.elasticsearch","r4.16xlarge.elasticsearch","r4.2xlarge.elasticsearch","r4.4xlarge.elasticsearch","r4.8xlarge.elasticsearch","r4.large.elasticsearch","r4.xlarge.elasticsearch","r5.12xlarge.elasticsearch","r5.2xlarge.elasticsearch","r5.4xlarge.elasticsearch","r5.large.elasticsearch","r5.xlarge.elasticsearch","t2.medium.elasticsearch","t2.micro.elasticsearch","t2.small.elasticsearch","ultrawarm1.large.elasticsearch","ultrawarm1.medium.elasticsearch"
            break
        }

        # Amazon.Elasticsearch.ESWarmPartitionInstanceType
        {
            ($_ -eq "New-ESDomain/ElasticsearchClusterConfig_WarmType") -Or
            ($_ -eq "Update-ESDomainConfig/ElasticsearchClusterConfig_WarmType")
        }
        {
            $v = "ultrawarm1.large.elasticsearch","ultrawarm1.medium.elasticsearch"
            break
        }

        # Amazon.Elasticsearch.TLSSecurityPolicy
        {
            ($_ -eq "New-ESDomain/DomainEndpointOptions_TLSSecurityPolicy") -Or
            ($_ -eq "Update-ESDomainConfig/DomainEndpointOptions_TLSSecurityPolicy")
        }
        {
            $v = "Policy-Min-TLS-1-0-2019-07","Policy-Min-TLS-1-2-2019-07"
            break
        }

        # Amazon.Elasticsearch.VolumeType
        {
            ($_ -eq "New-ESDomain/EBSOptions_VolumeType") -Or
            ($_ -eq "Update-ESDomainConfig/EBSOptions_VolumeType")
        }
        {
            $v = "gp2","io1","standard"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ES_map = @{
    "DomainEndpointOptions_TLSSecurityPolicy"=@("New-ESDomain","Update-ESDomainConfig")
    "EBSOptions_VolumeType"=@("New-ESDomain","Update-ESDomainConfig")
    "ElasticsearchClusterConfig_DedicatedMasterType"=@("New-ESDomain","Update-ESDomainConfig")
    "ElasticsearchClusterConfig_InstanceType"=@("New-ESDomain","Update-ESDomainConfig")
    "ElasticsearchClusterConfig_WarmType"=@("New-ESDomain","Update-ESDomainConfig")
    "InstanceType"=@("Get-ESInstanceTypeLimit")
}

_awsArgumentCompleterRegistration $ES_Completers $ES_map

$ES_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.ES.$($commandName.Replace('-', ''))Cmdlet]"
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

$ES_SelectMap = @{
    "Select"=@("Add-ESResourceTag",
               "Stop-ESElasticsearchServiceSoftwareUpdate",
               "New-ESDomain",
               "Remove-ESDomain",
               "Remove-ESElasticsearchServiceRole",
               "Get-ESDomain",
               "Get-ESDomainConfig",
               "Get-ESDomainList",
               "Get-ESInstanceTypeLimit",
               "Get-ESReservedElasticsearchInstanceOfferingList",
               "Get-ESReservedElasticsearchInstanceList",
               "Get-ESCompatibleElasticsearchVersion",
               "Get-ESUpgradeHistory",
               "Get-ESUpgradeStatus",
               "Get-ESDomainNameList",
               "Get-ESInstanceTypeList",
               "Get-ESVersionList",
               "Get-ESResourceTag",
               "New-ESReservedElasticsearchInstanceOffering",
               "Remove-ESResourceTag",
               "Start-ESElasticsearchServiceSoftwareUpdate",
               "Update-ESDomainConfig",
               "Update-ESElasticsearchDomain")
}

_awsArgumentCompleterRegistration $ES_SelectCompleters $ES_SelectMap

