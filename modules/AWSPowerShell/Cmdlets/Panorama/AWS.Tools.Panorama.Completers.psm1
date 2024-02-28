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

# Argument completions for service AWS Panorama


$PAN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Panorama.ConnectionType
        {
            ($_ -eq "Register-PANDevice/Ethernet0_ConnectionType") -Or
            ($_ -eq "Register-PANDevice/Ethernet1_ConnectionType")
        }
        {
            $v = "DHCP","STATIC_IP"
            break
        }

        # Amazon.Panorama.DeviceAggregatedStatus
        "Get-PANDeviceList/DeviceAggregatedStatusFilter"
        {
            $v = "AWAITING_PROVISIONING","DELETING","ERROR","FAILED","LEASE_EXPIRED","OFFLINE","ONLINE","PENDING","REBOOTING","UPDATE_NEEDED"
            break
        }

        # Amazon.Panorama.JobType
        "New-PANJobForDevice/JobType"
        {
            $v = "OTA","REBOOT"
            break
        }

        # Amazon.Panorama.ListDevicesSortBy
        "Get-PANDeviceList/SortBy"
        {
            $v = "CREATED_TIME","DEVICE_AGGREGATED_STATUS","DEVICE_ID","NAME"
            break
        }

        # Amazon.Panorama.NodeCategory
        "Get-PANNodeList/Category"
        {
            $v = "BUSINESS_LOGIC","MEDIA_SINK","MEDIA_SOURCE","ML_MODEL"
            break
        }

        # Amazon.Panorama.PackageImportJobType
        "New-PANPackageImportJob/JobType"
        {
            $v = "MARKETPLACE_NODE_PACKAGE_VERSION","NODE_PACKAGE_VERSION"
            break
        }

        # Amazon.Panorama.SortOrder
        "Get-PANDeviceList/SortOrder"
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.Panorama.StatusFilter
        "Get-PANApplicationInstanceList/StatusFilter"
        {
            $v = "DEPLOYMENT_ERROR","DEPLOYMENT_FAILED","DEPLOYMENT_SUCCEEDED","PROCESSING_DEPLOYMENT","PROCESSING_REMOVAL","REMOVAL_FAILED","REMOVAL_SUCCEEDED"
            break
        }

        # Amazon.Panorama.TemplateType
        "New-PANNodeFromTemplateJob/TemplateType"
        {
            $v = "RTSP_CAMERA_STREAM"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$PAN_map = @{
    "Category"=@("Get-PANNodeList")
    "DeviceAggregatedStatusFilter"=@("Get-PANDeviceList")
    "Ethernet0_ConnectionType"=@("Register-PANDevice")
    "Ethernet1_ConnectionType"=@("Register-PANDevice")
    "JobType"=@("New-PANJobForDevice","New-PANPackageImportJob")
    "SortBy"=@("Get-PANDeviceList")
    "SortOrder"=@("Get-PANDeviceList")
    "StatusFilter"=@("Get-PANApplicationInstanceList")
    "TemplateType"=@("New-PANNodeFromTemplateJob")
}

_awsArgumentCompleterRegistration $PAN_Completers $PAN_map

$PAN_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.PAN.$($commandName.Replace('-', ''))Cmdlet]"
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

$PAN_SelectMap = @{
    "Select"=@("New-PANApplicationInstance",
               "New-PANJobForDevice",
               "New-PANNodeFromTemplateJob",
               "New-PANPackage",
               "New-PANPackageImportJob",
               "Remove-PANDevice",
               "Remove-PANPackage",
               "Unregister-PANPackageVersion",
               "Get-PANApplicationInstance",
               "Get-PANApplicationInstanceDetail",
               "Get-PANDevice",
               "Get-PANDeviceJob",
               "Get-PANNode",
               "Get-PANNodeFromTemplateJob",
               "Get-PANPackage",
               "Get-PANPackageImportJob",
               "Get-PANPackageVersion",
               "Get-PANApplicationInstanceDependencyList",
               "Get-PANApplicationInstanceNodeInstanceList",
               "Get-PANApplicationInstanceList",
               "Get-PANDeviceList",
               "Get-PANDevicesJobList",
               "Get-PANNodeFromTemplateJobList",
               "Get-PANNodeList",
               "Get-PANPackageImportJobList",
               "Get-PANPackageList",
               "Get-PANResourceTag",
               "Register-PANDevice",
               "Register-PANPackageVersion",
               "Remove-PANApplicationInstance",
               "Send-PANApplicationInstanceNodeInstance",
               "Add-PANResourceTag",
               "Remove-PANResourceTag",
               "Update-PANDeviceMetadata")
}

_awsArgumentCompleterRegistration $PAN_SelectCompleters $PAN_SelectMap

