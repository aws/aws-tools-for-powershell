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

# Argument completions for service AWS Elemental MediaConvert


$EMC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MediaConvert.AccelerationMode
        {
            ($_ -eq "New-EMCJob/AccelerationSettings_Mode") -Or
            ($_ -eq "New-EMCJobTemplate/AccelerationSettings_Mode") -Or
            ($_ -eq "Update-EMCJobTemplate/AccelerationSettings_Mode")
        }
        {
            $v = "DISABLED","ENABLED","PREFERRED"
            break
        }

        # Amazon.MediaConvert.BillingTagsSource
        "New-EMCJob/BillingTagsSource"
        {
            $v = "JOB","JOB_TEMPLATE","PRESET","QUEUE"
            break
        }

        # Amazon.MediaConvert.Commitment
        {
            ($_ -eq "New-EMCQueue/ReservationPlanSettings_Commitment") -Or
            ($_ -eq "Update-EMCQueue/ReservationPlanSettings_Commitment")
        }
        {
            $v = "ONE_YEAR"
            break
        }

        # Amazon.MediaConvert.DescribeEndpointsMode
        "Get-EMCEndpoint/Mode"
        {
            $v = "DEFAULT","GET_ONLY"
            break
        }

        # Amazon.MediaConvert.InputPolicy
        {
            ($_ -eq "Write-EMCPolicy/Policy_HttpInput") -Or
            ($_ -eq "Write-EMCPolicy/Policy_HttpsInput") -Or
            ($_ -eq "Write-EMCPolicy/Policy_S3Input")
        }
        {
            $v = "ALLOWED","DISALLOWED"
            break
        }

        # Amazon.MediaConvert.JobStatus
        {
            ($_ -eq "Get-EMCJobList/Status") -Or
            ($_ -eq "Search-EMCJob/Status")
        }
        {
            $v = "CANCELED","COMPLETE","ERROR","PROGRESSING","SUBMITTED"
            break
        }

        # Amazon.MediaConvert.JobTemplateListBy
        "Get-EMCJobTemplateList/ListBy"
        {
            $v = "CREATION_DATE","NAME","SYSTEM"
            break
        }

        # Amazon.MediaConvert.Order
        {
            ($_ -eq "Get-EMCJobList/Order") -Or
            ($_ -eq "Get-EMCJobTemplateList/Order") -Or
            ($_ -eq "Get-EMCPresetList/Order") -Or
            ($_ -eq "Get-EMCQueueList/Order") -Or
            ($_ -eq "Search-EMCJob/Order") -Or
            ($_ -eq "Start-EMCJobsQuery/Order")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.MediaConvert.PresetListBy
        "Get-EMCPresetList/ListBy"
        {
            $v = "CREATION_DATE","NAME","SYSTEM"
            break
        }

        # Amazon.MediaConvert.PricingPlan
        "New-EMCQueue/PricingPlan"
        {
            $v = "ON_DEMAND","RESERVED"
            break
        }

        # Amazon.MediaConvert.QueueListBy
        "Get-EMCQueueList/ListBy"
        {
            $v = "CREATION_DATE","NAME"
            break
        }

        # Amazon.MediaConvert.QueueStatus
        {
            ($_ -eq "New-EMCQueue/Status") -Or
            ($_ -eq "Update-EMCQueue/Status")
        }
        {
            $v = "ACTIVE","PAUSED"
            break
        }

        # Amazon.MediaConvert.RenewalType
        {
            ($_ -eq "New-EMCQueue/ReservationPlanSettings_RenewalType") -Or
            ($_ -eq "Update-EMCQueue/ReservationPlanSettings_RenewalType")
        }
        {
            $v = "AUTO_RENEW","EXPIRE"
            break
        }

        # Amazon.MediaConvert.SimulateReservedQueue
        "New-EMCJob/SimulateReservedQueue"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.MediaConvert.StatusUpdateInterval
        {
            ($_ -eq "New-EMCJob/StatusUpdateInterval") -Or
            ($_ -eq "New-EMCJobTemplate/StatusUpdateInterval") -Or
            ($_ -eq "Update-EMCJobTemplate/StatusUpdateInterval")
        }
        {
            $v = "SECONDS_10","SECONDS_12","SECONDS_120","SECONDS_15","SECONDS_180","SECONDS_20","SECONDS_240","SECONDS_30","SECONDS_300","SECONDS_360","SECONDS_420","SECONDS_480","SECONDS_540","SECONDS_60","SECONDS_600"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EMC_map = @{
    "AccelerationSettings_Mode"=@("New-EMCJob","New-EMCJobTemplate","Update-EMCJobTemplate")
    "BillingTagsSource"=@("New-EMCJob")
    "ListBy"=@("Get-EMCJobTemplateList","Get-EMCPresetList","Get-EMCQueueList")
    "Mode"=@("Get-EMCEndpoint")
    "Order"=@("Get-EMCJobList","Get-EMCJobTemplateList","Get-EMCPresetList","Get-EMCQueueList","Search-EMCJob","Start-EMCJobsQuery")
    "Policy_HttpInput"=@("Write-EMCPolicy")
    "Policy_HttpsInput"=@("Write-EMCPolicy")
    "Policy_S3Input"=@("Write-EMCPolicy")
    "PricingPlan"=@("New-EMCQueue")
    "ReservationPlanSettings_Commitment"=@("New-EMCQueue","Update-EMCQueue")
    "ReservationPlanSettings_RenewalType"=@("New-EMCQueue","Update-EMCQueue")
    "SimulateReservedQueue"=@("New-EMCJob")
    "Status"=@("Get-EMCJobList","New-EMCQueue","Search-EMCJob","Update-EMCQueue")
    "StatusUpdateInterval"=@("New-EMCJob","New-EMCJobTemplate","Update-EMCJobTemplate")
}

_awsArgumentCompleterRegistration $EMC_Completers $EMC_map

$EMC_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EMC.$($commandName.Replace('-', ''))Cmdlet]"
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

$EMC_SelectMap = @{
    "Select"=@("Register-EMCCertificate",
               "Stop-EMCJob",
               "New-EMCJob",
               "New-EMCJobTemplate",
               "New-EMCPreset",
               "New-EMCQueue",
               "New-EMCResourceShare",
               "Remove-EMCJobTemplate",
               "Remove-EMCPolicy",
               "Remove-EMCPreset",
               "Remove-EMCQueue",
               "Get-EMCEndpoint",
               "Unregister-EMCCertificate",
               "Get-EMCJob",
               "Get-EMCJobsQueryResult",
               "Get-EMCJobTemplate",
               "Get-EMCPolicy",
               "Get-EMCPreset",
               "Get-EMCQueue",
               "Get-EMCJobList",
               "Get-EMCJobTemplateList",
               "Get-EMCPresetList",
               "Get-EMCQueueList",
               "Get-EMCResourceTag",
               "Get-EMCVersionList",
               "Invoke-EMCProbe",
               "Write-EMCPolicy",
               "Search-EMCJob",
               "Start-EMCJobsQuery",
               "Add-EMCResourceTag",
               "Remove-EMCResourceTag",
               "Update-EMCJobTemplate",
               "Update-EMCPreset",
               "Update-EMCQueue")
}

_awsArgumentCompleterRegistration $EMC_SelectCompleters $EMC_SelectMap

