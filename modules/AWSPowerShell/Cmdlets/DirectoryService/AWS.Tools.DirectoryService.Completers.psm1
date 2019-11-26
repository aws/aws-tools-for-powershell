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

# Argument completions for service AWS Directory Service


$DS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DirectoryService.DirectoryEdition
        "New-DSMicrosoftAD/Edition"
        {
            $v = "Enterprise","Standard"
            break
        }

        # Amazon.DirectoryService.DirectorySize
        {
            ($_ -eq "Connect-DSDirectory/Size") -Or
            ($_ -eq "New-DSDirectory/Size")
        }
        {
            $v = "Large","Small"
            break
        }

        # Amazon.DirectoryService.LDAPSType
        {
            ($_ -eq "Disable-DSLDAPS/Type") -Or
            ($_ -eq "Enable-DSLDAPS/Type") -Or
            ($_ -eq "Get-DSLDAPSSetting/Type")
        }
        {
            $v = "Client"
            break
        }

        # Amazon.DirectoryService.RadiusAuthenticationProtocol
        {
            ($_ -eq "Enable-DSRadius/RadiusSettings_AuthenticationProtocol") -Or
            ($_ -eq "Update-DSRadius/RadiusSettings_AuthenticationProtocol")
        }
        {
            $v = "CHAP","MS-CHAPv1","MS-CHAPv2","PAP"
            break
        }

        # Amazon.DirectoryService.SelectiveAuth
        {
            ($_ -eq "New-DSTrust/SelectiveAuth") -Or
            ($_ -eq "Update-DSTrust/SelectiveAuth")
        }
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.DirectoryService.ShareMethod
        "Enable-DSDirectoryShare/ShareMethod"
        {
            $v = "HANDSHAKE","ORGANIZATIONS"
            break
        }

        # Amazon.DirectoryService.TargetType
        {
            ($_ -eq "Enable-DSDirectoryShare/ShareTarget_Type") -Or
            ($_ -eq "Disable-DSDirectoryShare/UnshareTarget_Type")
        }
        {
            $v = "ACCOUNT"
            break
        }

        # Amazon.DirectoryService.TrustDirection
        "New-DSTrust/TrustDirection"
        {
            $v = "One-Way: Incoming","One-Way: Outgoing","Two-Way"
            break
        }

        # Amazon.DirectoryService.TrustType
        "New-DSTrust/TrustType"
        {
            $v = "External","Forest"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DS_map = @{
    "Edition"=@("New-DSMicrosoftAD")
    "RadiusSettings_AuthenticationProtocol"=@("Enable-DSRadius","Update-DSRadius")
    "SelectiveAuth"=@("New-DSTrust","Update-DSTrust")
    "ShareMethod"=@("Enable-DSDirectoryShare")
    "ShareTarget_Type"=@("Enable-DSDirectoryShare")
    "Size"=@("Connect-DSDirectory","New-DSDirectory")
    "TrustDirection"=@("New-DSTrust")
    "TrustType"=@("New-DSTrust")
    "Type"=@("Disable-DSLDAPS","Enable-DSLDAPS","Get-DSLDAPSSetting")
    "UnshareTarget_Type"=@("Disable-DSDirectoryShare")
}

_awsArgumentCompleterRegistration $DS_Completers $DS_map

$DS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.DS.$($commandName.Replace('-', ''))Cmdlet]"
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

$DS_SelectMap = @{
    "Select"=@("Confirm-DSSharedDirectory",
               "Add-DSIpRoute",
               "Add-DSResourceTag",
               "Stop-DSSchemaExtension",
               "Connect-DSDirectory",
               "New-DSAlias",
               "New-DSComputer",
               "New-DSConditionalForwarder",
               "New-DSDirectory",
               "New-DSLogSubscription",
               "New-DSMicrosoftAD",
               "New-DSSnapshot",
               "New-DSTrust",
               "Remove-DSConditionalForwarder",
               "Remove-DSDirectory",
               "Remove-DSLogSubscription",
               "Remove-DSSnapshot",
               "Remove-DSTrust",
               "Unregister-DSCertificate",
               "Unregister-DSEventTopic",
               "Get-DSCertificate",
               "Get-DSConditionalForwarder",
               "Get-DSDirectory",
               "Get-DSDomainControllerList",
               "Get-DSEventTopic",
               "Get-DSLDAPSSetting",
               "Get-DSSharedDirectory",
               "Get-DSSnapshot",
               "Get-DSTrust",
               "Disable-DSLDAPS",
               "Disable-DSRadius",
               "Disable-DSSso",
               "Enable-DSLDAPS",
               "Enable-DSRadius",
               "Enable-DSSso",
               "Get-DSDirectoryLimit",
               "Get-DSSnapshotLimit",
               "Get-DSCertificateList",
               "Get-DSIpRouteList",
               "Get-DSLogSubscriptionList",
               "Get-DSSchemaExtension",
               "Get-DSResourceTag",
               "Register-DSCertificate",
               "Register-DSEventTopic",
               "Deny-DSSharedDirectory",
               "Remove-DSIpRoute",
               "Remove-DSResourceTag",
               "Reset-DSUserPassword",
               "Restore-DSFromSnapshot",
               "Enable-DSDirectoryShare",
               "Start-DSSchemaExtension",
               "Disable-DSDirectoryShare",
               "Update-DSConditionalForwarder",
               "Set-DSDomainControllerCount",
               "Update-DSRadius",
               "Update-DSTrust",
               "Approve-DSTrust")
}

_awsArgumentCompleterRegistration $DS_SelectCompleters $DS_SelectMap

