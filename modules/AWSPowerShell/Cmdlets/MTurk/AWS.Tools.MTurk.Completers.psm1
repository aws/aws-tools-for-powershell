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

# Argument completions for service Amazon MTurk Service


$MTR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MTurk.EventType
        "Send-MTRTestEventNotification/TestEventType"
        {
            $v = "AssignmentAbandoned","AssignmentAccepted","AssignmentApproved","AssignmentRejected","AssignmentReturned","AssignmentSubmitted","HITCreated","HITDisposed","HITExpired","HITExtended","HITReviewable","Ping"
            break
        }

        # Amazon.MTurk.NotificationTransport
        {
            ($_ -eq "Send-MTRTestEventNotification/Notification_Transport") -Or
            ($_ -eq "Update-MTRNotificationSetting/Notification_Transport")
        }
        {
            $v = "Email","SNS","SQS"
            break
        }

        # Amazon.MTurk.QualificationStatus
        "Get-MTRWorkersWithQualificationType/Status"
        {
            $v = "Granted","Revoked"
            break
        }

        # Amazon.MTurk.QualificationTypeStatus
        {
            ($_ -eq "New-MTRQualificationType/QualificationTypeStatus") -Or
            ($_ -eq "Update-MTRQualificationType/QualificationTypeStatus")
        }
        {
            $v = "Active","Inactive"
            break
        }

        # Amazon.MTurk.ReviewableHITStatus
        "Get-MTRReviewableHITList/Status"
        {
            $v = "Reviewable","Reviewing"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$MTR_map = @{
    "Notification_Transport"=@("Send-MTRTestEventNotification","Update-MTRNotificationSetting")
    "QualificationTypeStatus"=@("New-MTRQualificationType","Update-MTRQualificationType")
    "Status"=@("Get-MTRReviewableHITList","Get-MTRWorkersWithQualificationType")
    "TestEventType"=@("Send-MTRTestEventNotification")
}

_awsArgumentCompleterRegistration $MTR_Completers $MTR_map

$MTR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.MTR.$($commandName.Replace('-', ''))Cmdlet]"
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

$MTR_SelectMap = @{
    "Select"=@("Grant-MTRQualificationRequest",
               "Approve-MTRAssignment",
               "Add-MTRQualificationToWorker",
               "New-MTRAdditionalAssignmentsForHIT",
               "New-MTRHIT",
               "New-MTRHITType",
               "New-MTRHITWithHITType",
               "New-MTRQualificationType",
               "New-MTRWorkerBlock",
               "Remove-MTRHIT",
               "Remove-MTRQualificationType",
               "Remove-MTRWorkerBlock",
               "Remove-MTRQualificationFromWorker",
               "Get-MTRAccountBalance",
               "Get-MTRAssignment",
               "Get-MTRFileUploadURL",
               "Get-MTRHIT",
               "Get-MTRQualificationScore",
               "Get-MTRQualificationType",
               "Get-MTRHITAssignmentList",
               "Get-MTRBonusPaymentList",
               "Get-MTRHITList",
               "Get-MTRHITListForQualificationType",
               "Get-MTRQualificationRequestList",
               "Get-MTRQualificationTypeList",
               "Get-MTRReviewableHITList",
               "Get-MTRReviewPolicyResultList",
               "Get-MTRWorkerBlockList",
               "Get-MTRWorkersWithQualificationType",
               "Send-MTRWorkerNotification",
               "Deny-MTRAssignment",
               "Deny-MTRQualificationRequest",
               "Send-MTRBonus",
               "Send-MTRTestEventNotification",
               "Update-MTRExpirationForHIT",
               "Update-MTRHITReviewStatus",
               "Update-MTRHITTypeOfHIT",
               "Update-MTRNotificationSetting",
               "Update-MTRQualificationType")
}

_awsArgumentCompleterRegistration $MTR_SelectCompleters $MTR_SelectMap

