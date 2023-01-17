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

# Argument completions for service EC2 Image Builder


$EC2IB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Imagebuilder.ComponentFormat
        "Import-EC2IBComponent/Format"
        {
            $v = "SHELL"
            break
        }

        # Amazon.Imagebuilder.ComponentType
        "Import-EC2IBComponent/Type"
        {
            $v = "BUILD","TEST"
            break
        }

        # Amazon.Imagebuilder.ContainerRepositoryService
        "New-EC2IBContainerRecipe/TargetRepository_Service"
        {
            $v = "ECR"
            break
        }

        # Amazon.Imagebuilder.ContainerType
        "New-EC2IBContainerRecipe/ContainerType"
        {
            $v = "DOCKER"
            break
        }

        # Amazon.Imagebuilder.Ownership
        {
            ($_ -eq "Get-EC2IBComponentList/Owner") -Or
            ($_ -eq "Get-EC2IBContainerRecipeList/Owner") -Or
            ($_ -eq "Get-EC2IBImageList/Owner") -Or
            ($_ -eq "Get-EC2IBImageRecipeList/Owner")
        }
        {
            $v = "Amazon","Self","Shared","ThirdParty"
            break
        }

        # Amazon.Imagebuilder.PipelineExecutionStartCondition
        {
            ($_ -eq "New-EC2IBImagePipeline/Schedule_PipelineExecutionStartCondition") -Or
            ($_ -eq "Update-EC2IBImagePipeline/Schedule_PipelineExecutionStartCondition")
        }
        {
            $v = "EXPRESSION_MATCH_AND_DEPENDENCY_UPDATES_AVAILABLE","EXPRESSION_MATCH_ONLY"
            break
        }

        # Amazon.Imagebuilder.PipelineStatus
        {
            ($_ -eq "New-EC2IBImagePipeline/Status") -Or
            ($_ -eq "Update-EC2IBImagePipeline/Status")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.Imagebuilder.Platform
        {
            ($_ -eq "Import-EC2IBComponent/Platform") -Or
            ($_ -eq "Import-EC2IBVmImage/Platform") -Or
            ($_ -eq "New-EC2IBComponent/Platform") -Or
            ($_ -eq "New-EC2IBContainerRecipe/PlatformOverride")
        }
        {
            $v = "Linux","Windows"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EC2IB_map = @{
    "ContainerType"=@("New-EC2IBContainerRecipe")
    "Format"=@("Import-EC2IBComponent")
    "Owner"=@("Get-EC2IBComponentList","Get-EC2IBContainerRecipeList","Get-EC2IBImageList","Get-EC2IBImageRecipeList")
    "Platform"=@("Import-EC2IBComponent","Import-EC2IBVmImage","New-EC2IBComponent")
    "PlatformOverride"=@("New-EC2IBContainerRecipe")
    "Schedule_PipelineExecutionStartCondition"=@("New-EC2IBImagePipeline","Update-EC2IBImagePipeline")
    "Status"=@("New-EC2IBImagePipeline","Update-EC2IBImagePipeline")
    "TargetRepository_Service"=@("New-EC2IBContainerRecipe")
    "Type"=@("Import-EC2IBComponent")
}

_awsArgumentCompleterRegistration $EC2IB_Completers $EC2IB_map

$EC2IB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EC2IB.$($commandName.Replace('-', ''))Cmdlet]"
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

$EC2IB_SelectMap = @{
    "Select"=@("Stop-EC2IBImageCreation",
               "New-EC2IBComponent",
               "New-EC2IBContainerRecipe",
               "New-EC2IBDistributionConfiguration",
               "New-EC2IBImage",
               "New-EC2IBImagePipeline",
               "New-EC2IBImageRecipe",
               "New-EC2IBInfrastructureConfiguration",
               "Remove-EC2IBComponent",
               "Remove-EC2IBContainerRecipe",
               "Remove-EC2IBDistributionConfiguration",
               "Remove-EC2IBImage",
               "Remove-EC2IBImagePipeline",
               "Remove-EC2IBImageRecipe",
               "Remove-EC2IBInfrastructureConfiguration",
               "Get-EC2IBComponent",
               "Get-EC2IBComponentPolicy",
               "Get-EC2IBContainerRecipe",
               "Get-EC2IBContainerRecipePolicy",
               "Get-EC2IBDistributionConfiguration",
               "Get-EC2IBImage",
               "Get-EC2IBImagePipeline",
               "Get-EC2IBImagePolicy",
               "Get-EC2IBImageRecipe",
               "Get-EC2IBImageRecipePolicy",
               "Get-EC2IBInfrastructureConfiguration",
               "Import-EC2IBComponent",
               "Import-EC2IBVmImage",
               "Get-EC2IBComponentBuildVersionList",
               "Get-EC2IBComponentList",
               "Get-EC2IBContainerRecipeList",
               "Get-EC2IBDistributionConfigurationList",
               "Get-EC2IBImageBuildVersionList",
               "Get-EC2IBImagePackageList",
               "Get-EC2IBImagePipelineImageList",
               "Get-EC2IBImagePipelineList",
               "Get-EC2IBImageRecipeList",
               "Get-EC2IBImageList",
               "Get-EC2IBInfrastructureConfigurationList",
               "Get-EC2IBResourceTag",
               "Write-EC2IBComponentPolicy",
               "Write-EC2IBContainerRecipePolicy",
               "Write-EC2IBImagePolicy",
               "Write-EC2IBImageRecipePolicy",
               "Start-EC2IBImagePipelineExecution",
               "Add-EC2IBResourceTag",
               "Remove-EC2IBResourceTag",
               "Update-EC2IBDistributionConfiguration",
               "Update-EC2IBImagePipeline",
               "Update-EC2IBInfrastructureConfiguration")
}

_awsArgumentCompleterRegistration $EC2IB_SelectCompleters $EC2IB_SelectMap

