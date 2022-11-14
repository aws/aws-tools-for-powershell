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

# Argument completions for service Amazon WorkDocs


$WD_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.WorkDocs.BooleanEnumType
        "Update-WDUser/GrantPoweruserPrivileges"
        {
            $v = "FALSE","TRUE"
            break
        }

        # Amazon.WorkDocs.CommentVisibilityType
        "New-WDComment/Visibility"
        {
            $v = "PRIVATE","PUBLIC"
            break
        }

        # Amazon.WorkDocs.DocumentVersionStatus
        "Update-WDDocumentVersion/VersionStatus"
        {
            $v = "ACTIVE"
            break
        }

        # Amazon.WorkDocs.FolderContentType
        "Get-WDFolderContent/Type"
        {
            $v = "ALL","DOCUMENT","FOLDER"
            break
        }

        # Amazon.WorkDocs.LocaleType
        "Update-WDUser/Locale"
        {
            $v = "de","default","en","es","fr","ja","ko","pt_BR","ru","zh_CN","zh_TW"
            break
        }

        # Amazon.WorkDocs.OrderType
        {
            ($_ -eq "Get-WDFolderContent/Order") -Or
            ($_ -eq "Get-WDUserList/Order")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.WorkDocs.PrincipalType
        "Remove-WDResourcePermission/PrincipalType"
        {
            $v = "ANONYMOUS","GROUP","INVITE","ORGANIZATION","USER"
            break
        }

        # Amazon.WorkDocs.ResourceCollectionType
        "Get-WDResource/CollectionType"
        {
            $v = "SHARED_WITH_ME"
            break
        }

        # Amazon.WorkDocs.ResourceSortType
        "Get-WDFolderContent/Sort"
        {
            $v = "DATE","NAME"
            break
        }

        # Amazon.WorkDocs.ResourceStateType
        {
            ($_ -eq "Update-WDDocument/ResourceState") -Or
            ($_ -eq "Update-WDFolder/ResourceState")
        }
        {
            $v = "ACTIVE","RECYCLED","RECYCLING","RESTORING"
            break
        }

        # Amazon.WorkDocs.StorageType
        {
            ($_ -eq "New-WDUser/StorageRule_StorageType") -Or
            ($_ -eq "Update-WDUser/StorageRule_StorageType")
        }
        {
            $v = "QUOTA","UNLIMITED"
            break
        }

        # Amazon.WorkDocs.SubscriptionProtocolType
        "New-WDNotificationSubscription/Protocol"
        {
            $v = "HTTPS","SQS"
            break
        }

        # Amazon.WorkDocs.SubscriptionType
        "New-WDNotificationSubscription/SubscriptionType"
        {
            $v = "ALL"
            break
        }

        # Amazon.WorkDocs.UserFilterType
        "Get-WDUserList/Include"
        {
            $v = "ACTIVE_PENDING","ALL"
            break
        }

        # Amazon.WorkDocs.UserSortType
        "Get-WDUserList/Sort"
        {
            $v = "FULL_NAME","STORAGE_LIMIT","STORAGE_USED","USER_NAME","USER_STATUS"
            break
        }

        # Amazon.WorkDocs.UserType
        "Update-WDUser/Type"
        {
            $v = "ADMIN","MINIMALUSER","POWERUSER","USER","WORKSPACESUSER"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$WD_map = @{
    "CollectionType"=@("Get-WDResource")
    "GrantPoweruserPrivileges"=@("Update-WDUser")
    "Include"=@("Get-WDUserList")
    "Locale"=@("Update-WDUser")
    "Order"=@("Get-WDFolderContent","Get-WDUserList")
    "PrincipalType"=@("Remove-WDResourcePermission")
    "Protocol"=@("New-WDNotificationSubscription")
    "ResourceState"=@("Update-WDDocument","Update-WDFolder")
    "Sort"=@("Get-WDFolderContent","Get-WDUserList")
    "StorageRule_StorageType"=@("New-WDUser","Update-WDUser")
    "SubscriptionType"=@("New-WDNotificationSubscription")
    "Type"=@("Get-WDFolderContent","Update-WDUser")
    "VersionStatus"=@("Update-WDDocumentVersion")
    "Visibility"=@("New-WDComment")
}

_awsArgumentCompleterRegistration $WD_Completers $WD_map

$WD_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.WD.$($commandName.Replace('-', ''))Cmdlet]"
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

$WD_SelectMap = @{
    "Select"=@("Stop-WDDocumentVersionUpload",
               "Enable-WDUser",
               "Add-WDResourcePermission",
               "New-WDComment",
               "New-WDCustomMetadata",
               "New-WDFolder",
               "New-WDLabel",
               "New-WDNotificationSubscription",
               "New-WDUser",
               "Disable-WDUser",
               "Remove-WDComment",
               "Remove-WDCustomMetadata",
               "Remove-WDDocument",
               "Remove-WDDocumentVersion",
               "Remove-WDFolder",
               "Remove-WDFolderContent",
               "Remove-WDLabel",
               "Remove-WDNotificationSubscription",
               "Remove-WDUser",
               "Get-WDActivity",
               "Get-WDComment",
               "Get-WDDocumentVersionList",
               "Get-WDFolderContent",
               "Get-WDGroup",
               "Get-WDNotificationSubscriptionList",
               "Get-WDResourcePermissionList",
               "Get-WDRootFolder",
               "Get-WDUserList",
               "Get-WDCurrentUser",
               "Get-WDDocument",
               "Get-WDDocumentPath",
               "Get-WDDocumentVersion",
               "Get-WDFolder",
               "Get-WDFolderPath",
               "Get-WDResource",
               "Start-WDDocumentVersionUpload",
               "Remove-WDResourcePermission",
               "Restore-WDDocumentVersion",
               "Update-WDDocument",
               "Update-WDDocumentVersion",
               "Update-WDFolder",
               "Update-WDUser")
}

_awsArgumentCompleterRegistration $WD_SelectCompleters $WD_SelectMap

