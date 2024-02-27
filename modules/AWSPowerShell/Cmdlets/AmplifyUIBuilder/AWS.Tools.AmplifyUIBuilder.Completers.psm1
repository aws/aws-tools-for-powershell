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

# Argument completions for service AWS Amplify UI Builder


$AMPUI_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AmplifyUIBuilder.CodegenJobGenericDataSourceType
        "New-AMPUICodegenJob/CodegenJobToCreate_GenericDataSchema_DataSourceType"
        {
            $v = "DataStore"
            break
        }

        # Amazon.AmplifyUIBuilder.FixedPosition
        {
            ($_ -eq "New-AMPUIForm/FormToCreate_Cta_Cancel_Position_Fixed") -Or
            ($_ -eq "New-AMPUIForm/FormToCreate_Cta_Clear_Position_Fixed") -Or
            ($_ -eq "New-AMPUIForm/FormToCreate_Cta_Submit_Position_Fixed") -Or
            ($_ -eq "Update-AMPUIForm/UpdatedForm_Cta_Cancel_Position_Fixed") -Or
            ($_ -eq "Update-AMPUIForm/UpdatedForm_Cta_Clear_Position_Fixed") -Or
            ($_ -eq "Update-AMPUIForm/UpdatedForm_Cta_Submit_Position_Fixed")
        }
        {
            $v = "first"
            break
        }

        # Amazon.AmplifyUIBuilder.FormActionType
        {
            ($_ -eq "New-AMPUIForm/FormToCreate_FormActionType") -Or
            ($_ -eq "Update-AMPUIForm/UpdatedForm_FormActionType")
        }
        {
            $v = "create","update"
            break
        }

        # Amazon.AmplifyUIBuilder.FormButtonsPosition
        {
            ($_ -eq "New-AMPUIForm/FormToCreate_Cta_Position") -Or
            ($_ -eq "Update-AMPUIForm/UpdatedForm_Cta_Position")
        }
        {
            $v = "bottom","top","top_and_bottom"
            break
        }

        # Amazon.AmplifyUIBuilder.FormDataSourceType
        {
            ($_ -eq "New-AMPUIForm/FormToCreate_DataType_DataSourceType") -Or
            ($_ -eq "Update-AMPUIForm/UpdatedForm_DataType_DataSourceType")
        }
        {
            $v = "Custom","DataStore"
            break
        }

        # Amazon.AmplifyUIBuilder.JSModule
        "New-AMPUICodegenJob/CodegenJobToCreate_RenderConfig_React_Module"
        {
            $v = "es2020","esnext"
            break
        }

        # Amazon.AmplifyUIBuilder.JSScript
        "New-AMPUICodegenJob/CodegenJobToCreate_RenderConfig_React_Script"
        {
            $v = "js","jsx","tsx"
            break
        }

        # Amazon.AmplifyUIBuilder.JSTarget
        "New-AMPUICodegenJob/CodegenJobToCreate_RenderConfig_React_Target"
        {
            $v = "es2015","es2020"
            break
        }

        # Amazon.AmplifyUIBuilder.LabelDecorator
        {
            ($_ -eq "New-AMPUIForm/FormToCreate_LabelDecorator") -Or
            ($_ -eq "Update-AMPUIForm/UpdatedForm_LabelDecorator")
        }
        {
            $v = "none","optional","required"
            break
        }

        # Amazon.AmplifyUIBuilder.TokenProviders
        {
            ($_ -eq "Convert-AMPUICodeForToken/Provider") -Or
            ($_ -eq "Update-AMPUIToken/Provider")
        }
        {
            $v = "figma"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AMPUI_map = @{
    "CodegenJobToCreate_GenericDataSchema_DataSourceType"=@("New-AMPUICodegenJob")
    "CodegenJobToCreate_RenderConfig_React_Module"=@("New-AMPUICodegenJob")
    "CodegenJobToCreate_RenderConfig_React_Script"=@("New-AMPUICodegenJob")
    "CodegenJobToCreate_RenderConfig_React_Target"=@("New-AMPUICodegenJob")
    "FormToCreate_Cta_Cancel_Position_Fixed"=@("New-AMPUIForm")
    "FormToCreate_Cta_Clear_Position_Fixed"=@("New-AMPUIForm")
    "FormToCreate_Cta_Position"=@("New-AMPUIForm")
    "FormToCreate_Cta_Submit_Position_Fixed"=@("New-AMPUIForm")
    "FormToCreate_DataType_DataSourceType"=@("New-AMPUIForm")
    "FormToCreate_FormActionType"=@("New-AMPUIForm")
    "FormToCreate_LabelDecorator"=@("New-AMPUIForm")
    "Provider"=@("Convert-AMPUICodeForToken","Update-AMPUIToken")
    "UpdatedForm_Cta_Cancel_Position_Fixed"=@("Update-AMPUIForm")
    "UpdatedForm_Cta_Clear_Position_Fixed"=@("Update-AMPUIForm")
    "UpdatedForm_Cta_Position"=@("Update-AMPUIForm")
    "UpdatedForm_Cta_Submit_Position_Fixed"=@("Update-AMPUIForm")
    "UpdatedForm_DataType_DataSourceType"=@("Update-AMPUIForm")
    "UpdatedForm_FormActionType"=@("Update-AMPUIForm")
    "UpdatedForm_LabelDecorator"=@("Update-AMPUIForm")
}

_awsArgumentCompleterRegistration $AMPUI_Completers $AMPUI_map

$AMPUI_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.AMPUI.$($commandName.Replace('-', ''))Cmdlet]"
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

$AMPUI_SelectMap = @{
    "Select"=@("New-AMPUIComponent",
               "New-AMPUIForm",
               "New-AMPUITheme",
               "Remove-AMPUIComponent",
               "Remove-AMPUIForm",
               "Remove-AMPUITheme",
               "Convert-AMPUICodeForToken",
               "Export-AMPUIComponent",
               "Export-AMPUIForm",
               "Export-AMPUITheme",
               "Get-AMPUICodegenJob",
               "Get-AMPUIComponent",
               "Get-AMPUIForm",
               "Get-AMPUIMetadata",
               "Get-AMPUITheme",
               "Get-AMPUICodegenJobList",
               "Get-AMPUIComponentList",
               "Get-AMPUIFormList",
               "Get-AMPUIResourceTag",
               "Get-AMPUIThemeList",
               "Write-AMPUIMetadataFlag",
               "Update-AMPUIToken",
               "New-AMPUICodegenJob",
               "Add-AMPUIResourceTag",
               "Remove-AMPUIResourceTag",
               "Update-AMPUIComponent",
               "Update-AMPUIForm",
               "Update-AMPUITheme")
}

_awsArgumentCompleterRegistration $AMPUI_SelectCompleters $AMPUI_SelectMap

