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

# Argument completions for service Partner Central Account API


$PCAA_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.PartnerCentralAccount.AccessType
        "Update-PCAAConnectionPreference/AccessType"
        {
            $v = "ALLOW_ALL","ALLOW_BY_DEFAULT_DENY_SOME","DENY_ALL"
            break
        }

        # Amazon.PartnerCentralAccount.ConnectionType
        {
            ($_ -eq "Get-PCAAConnectionInvitationList/ConnectionType") -Or
            ($_ -eq "New-PCAAConnectionInvitation/ConnectionType") -Or
            ($_ -eq "Stop-PCAAConnection/ConnectionType")
        }
        {
            $v = "OPPORTUNITY_COLLABORATION","SUBSIDIARY"
            break
        }

        # Amazon.PartnerCentralAccount.InvitationStatus
        "Get-PCAAConnectionInvitationList/Status"
        {
            $v = "ACCEPTED","CANCELED","EXPIRED","PENDING","REJECTED"
            break
        }

        # Amazon.PartnerCentralAccount.ParticipantType
        "Get-PCAAConnectionInvitationList/ParticipantType"
        {
            $v = "RECEIVER","SENDER"
            break
        }

        # Amazon.PartnerCentralAccount.PrimarySolutionType
        {
            ($_ -eq "New-PCAAPartner/PrimarySolutionType") -Or
            ($_ -eq "Start-PCAAProfileUpdateTask/TaskDetails_PrimarySolutionType")
        }
        {
            $v = "COMMUNICATION_SERVICES","CONSULTING_SERVICES","HARDWARE_PRODUCTS","MANAGED_SERVICES","PROFESSIONAL_SERVICES","SOFTWARE_PRODUCTS","TRAINING_SERVICES","VALUE_ADDED_RESALE_AWS_SERVICES"
            break
        }

        # Amazon.PartnerCentralAccount.ProfileVisibility
        "Write-PCAAProfileVisibility/Visibility"
        {
            $v = "PRIVATE","PUBLIC"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$PCAA_map = @{
    "AccessType"=@("Update-PCAAConnectionPreference")
    "ConnectionType"=@("Get-PCAAConnectionInvitationList","New-PCAAConnectionInvitation","Stop-PCAAConnection")
    "ParticipantType"=@("Get-PCAAConnectionInvitationList")
    "PrimarySolutionType"=@("New-PCAAPartner")
    "Status"=@("Get-PCAAConnectionInvitationList")
    "TaskDetails_PrimarySolutionType"=@("Start-PCAAProfileUpdateTask")
    "Visibility"=@("Write-PCAAProfileVisibility")
}

_awsArgumentCompleterRegistration $PCAA_Completers $PCAA_map

$PCAA_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.PCAA.$($commandName.Replace('-', ''))Cmdlet]"
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

$PCAA_SelectMap = @{
    "Select"=@("Approve-PCAAConnectionInvitation",
               "Add-PCAAAwsTrainingCertificationEmailDomain",
               "Stop-PCAAConnection",
               "Stop-PCAAConnectionInvitation",
               "Stop-PCAAProfileUpdateTask",
               "New-PCAAConnectionInvitation",
               "New-PCAAPartner",
               "Remove-PCAAAwsTrainingCertificationEmailDomain",
               "Get-PCAAAllianceLeadContact",
               "Get-PCAAConnection",
               "Get-PCAAConnectionInvitation",
               "Get-PCAAConnectionPreference",
               "Get-PCAAPartner",
               "Get-PCAAProfileUpdateTask",
               "Get-PCAAProfileVisibility",
               "Get-PCAAConnectionInvitationList",
               "Get-PCAAConnectionList",
               "Get-PCAAPartnerList",
               "Get-PCAAResourceTag",
               "Write-PCAAAllianceLeadContact",
               "Write-PCAAProfileVisibility",
               "Deny-PCAAConnectionInvitation",
               "Send-PCAAEmailVerificationCode",
               "Start-PCAAProfileUpdateTask",
               "Add-PCAAResourceTag",
               "Remove-PCAAResourceTag",
               "Update-PCAAConnectionPreference")
}

_awsArgumentCompleterRegistration $PCAA_SelectCompleters $PCAA_SelectMap

