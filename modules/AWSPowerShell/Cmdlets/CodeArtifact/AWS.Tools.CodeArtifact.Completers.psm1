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

# Argument completions for service AWS CodeArtifact


$CA_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CodeArtifact.AllowPublish
        {
            ($_ -eq "Get-CAPackageList/Publish") -Or
            ($_ -eq "Write-CAPackageOriginConfiguration/Restrictions_Publish")
        }
        {
            $v = "ALLOW","BLOCK"
            break
        }

        # Amazon.CodeArtifact.AllowUpstream
        {
            ($_ -eq "Write-CAPackageOriginConfiguration/Restrictions_Upstream") -Or
            ($_ -eq "Get-CAPackageList/Upstream")
        }
        {
            $v = "ALLOW","BLOCK"
            break
        }

        # Amazon.CodeArtifact.PackageFormat
        {
            ($_ -eq "Copy-CAPackageVersion/Format") -Or
            ($_ -eq "Get-CAAssociatedPackageGroup/Format") -Or
            ($_ -eq "Get-CAPackage/Format") -Or
            ($_ -eq "Get-CAPackageList/Format") -Or
            ($_ -eq "Get-CAPackageVersion/Format") -Or
            ($_ -eq "Get-CAPackageVersionAsset/Format") -Or
            ($_ -eq "Get-CAPackageVersionAssetList/Format") -Or
            ($_ -eq "Get-CAPackageVersionDependencyList/Format") -Or
            ($_ -eq "Get-CAPackageVersionList/Format") -Or
            ($_ -eq "Get-CAPackageVersionReadme/Format") -Or
            ($_ -eq "Get-CARepositoryEndpoint/Format") -Or
            ($_ -eq "Publish-CAPackageVersion/Format") -Or
            ($_ -eq "Remove-CAPackage/Format") -Or
            ($_ -eq "Remove-CAPackageVersion/Format") -Or
            ($_ -eq "Unpublish-CAPackageVersion/Format") -Or
            ($_ -eq "Update-CAPackageVersionsStatus/Format") -Or
            ($_ -eq "Write-CAPackageOriginConfiguration/Format")
        }
        {
            $v = "cargo","generic","maven","npm","nuget","pypi","ruby","swift"
            break
        }

        # Amazon.CodeArtifact.PackageGroupOriginRestrictionType
        "Get-CAAllowedRepositoriesForGroupList/OriginRestrictionType"
        {
            $v = "EXTERNAL_UPSTREAM","INTERNAL_UPSTREAM","PUBLISH"
            break
        }

        # Amazon.CodeArtifact.PackageVersionOriginType
        "Get-CAPackageVersionList/OriginType"
        {
            $v = "EXTERNAL","INTERNAL","UNKNOWN"
            break
        }

        # Amazon.CodeArtifact.PackageVersionSortType
        "Get-CAPackageVersionList/SortBy"
        {
            $v = "PUBLISHED_TIME"
            break
        }

        # Amazon.CodeArtifact.PackageVersionStatus
        {
            ($_ -eq "Remove-CAPackageVersion/ExpectedStatus") -Or
            ($_ -eq "Unpublish-CAPackageVersion/ExpectedStatus") -Or
            ($_ -eq "Update-CAPackageVersionsStatus/ExpectedStatus") -Or
            ($_ -eq "Get-CAPackageVersionList/Status") -Or
            ($_ -eq "Update-CAPackageVersionsStatus/TargetStatus")
        }
        {
            $v = "Archived","Deleted","Disposed","Published","Unfinished","Unlisted"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CA_map = @{
    "ExpectedStatus"=@("Remove-CAPackageVersion","Unpublish-CAPackageVersion","Update-CAPackageVersionsStatus")
    "Format"=@("Copy-CAPackageVersion","Get-CAAssociatedPackageGroup","Get-CAPackage","Get-CAPackageList","Get-CAPackageVersion","Get-CAPackageVersionAsset","Get-CAPackageVersionAssetList","Get-CAPackageVersionDependencyList","Get-CAPackageVersionList","Get-CAPackageVersionReadme","Get-CARepositoryEndpoint","Publish-CAPackageVersion","Remove-CAPackage","Remove-CAPackageVersion","Unpublish-CAPackageVersion","Update-CAPackageVersionsStatus","Write-CAPackageOriginConfiguration")
    "OriginRestrictionType"=@("Get-CAAllowedRepositoriesForGroupList")
    "OriginType"=@("Get-CAPackageVersionList")
    "Publish"=@("Get-CAPackageList")
    "Restrictions_Publish"=@("Write-CAPackageOriginConfiguration")
    "Restrictions_Upstream"=@("Write-CAPackageOriginConfiguration")
    "SortBy"=@("Get-CAPackageVersionList")
    "Status"=@("Get-CAPackageVersionList")
    "TargetStatus"=@("Update-CAPackageVersionsStatus")
    "Upstream"=@("Get-CAPackageList")
}

_awsArgumentCompleterRegistration $CA_Completers $CA_map

$CA_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CA.$($commandName.Replace('-', ''))Cmdlet]"
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

$CA_SelectMap = @{
    "Select"=@("Connect-CAExternalConnection",
               "Copy-CAPackageVersion",
               "New-CADomain",
               "New-CAPackageGroup",
               "New-CARepository",
               "Remove-CADomain",
               "Remove-CADomainPermissionsPolicy",
               "Remove-CAPackage",
               "Remove-CAPackageGroup",
               "Remove-CAPackageVersion",
               "Remove-CARepository",
               "Remove-CARepositoryPermissionsPolicy",
               "Get-CADomain",
               "Get-CAPackage",
               "Get-CAPackageGroup",
               "Get-CAPackageVersion",
               "Get-CARepository",
               "Disconnect-CAExternalConnection",
               "Unpublish-CAPackageVersion",
               "Get-CAAssociatedPackageGroup",
               "Get-CAAuthorizationToken",
               "Get-CADomainPermissionsPolicy",
               "Get-CAPackageVersionAsset",
               "Get-CAPackageVersionReadme",
               "Get-CARepositoryEndpoint",
               "Get-CARepositoryPermissionsPolicy",
               "Get-CAAllowedRepositoriesForGroupList",
               "Get-CAAssociatedPackageList",
               "Get-CADomainList",
               "Get-CAPackageGroupList",
               "Get-CAPackageList",
               "Get-CAPackageVersionAssetList",
               "Get-CAPackageVersionDependencyList",
               "Get-CAPackageVersionList",
               "Get-CARepositoryList",
               "Get-CARepositoriesInDomainList",
               "Get-CASubPackageGroupList",
               "Get-CAResourceTag",
               "Publish-CAPackageVersion",
               "Write-CADomainPermissionsPolicy",
               "Write-CAPackageOriginConfiguration",
               "Write-CARepositoryPermissionsPolicy",
               "Add-CAResourceTag",
               "Remove-CAResourceTag",
               "Update-CAPackageGroup",
               "Update-CAPackageGroupOriginConfiguration",
               "Update-CAPackageVersionsStatus",
               "Update-CARepository")
}

_awsArgumentCompleterRegistration $CA_SelectCompleters $CA_SelectMap

