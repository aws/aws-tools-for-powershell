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

# Argument completions for service Migration Hub Strategy Recommendations


$MHS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MigrationHubStrategyRecommendations.ApplicationComponentCriteria
        "Get-MHSApplicationComponentList/ApplicationComponentCriteria"
        {
            $v = "ANALYSIS_STATUS","APP_NAME","APP_TYPE","DESTINATION","ERROR_CATEGORY","NOT_DEFINED","SERVER_ID","STRATEGY"
            break
        }

        # Amazon.MigrationHubStrategyRecommendations.ApplicationMode
        "Write-MHSPortfolioPreference/ApplicationMode"
        {
            $v = "ALL","KNOWN","UNKNOWN"
            break
        }

        # Amazon.MigrationHubStrategyRecommendations.AppType
        "Update-MHSApplicationComponentConfig/AppType"
        {
            $v = "Cassandra","DB2","Dotnet","DotnetCore","DotNetFramework","IBM WebSphere","IIS","Java","JBoss","Maria DB","Mongo DB","MySQL","Oracle","Oracle WebLogic","Other","PostgreSQLServer","Spring","SQLServer","Sybase","Tomcat","Unknown","Visual Basic"
            break
        }

        # Amazon.MigrationHubStrategyRecommendations.AssessmentDataSourceType
        "Start-MHSAssessment/AssessmentDataSourceType"
        {
            $v = "ApplicationDiscoveryService","ManualImport","StrategyRecommendationsApplicationDataCollector"
            break
        }

        # Amazon.MigrationHubStrategyRecommendations.DatabaseManagementPreference
        "Write-MHSPortfolioPreference/DatabasePreferences_DatabaseManagementPreference"
        {
            $v = "AWS-managed","No preference","Self-manage"
            break
        }

        # Amazon.MigrationHubStrategyRecommendations.DataSourceType
        "Start-MHSImportFileTask/DataSourceType"
        {
            $v = "ApplicationDiscoveryService","Import","MPA","StrategyRecommendationsApplicationDataCollector"
            break
        }

        # Amazon.MigrationHubStrategyRecommendations.InclusionStatus
        "Update-MHSApplicationComponentConfig/InclusionStatus"
        {
            $v = "excludeFromAssessment","includeInAssessment"
            break
        }

        # Amazon.MigrationHubStrategyRecommendations.OutputFormat
        "Start-MHSRecommendationReportGeneration/OutputFormat"
        {
            $v = "Excel","Json"
            break
        }

        # Amazon.MigrationHubStrategyRecommendations.ServerCriteria
        "Get-MHSServerList/ServerCriteria"
        {
            $v = "ANALYSIS_STATUS","DESTINATION","ERROR_CATEGORY","NOT_DEFINED","OS_NAME","SERVER_ID","STRATEGY"
            break
        }

        # Amazon.MigrationHubStrategyRecommendations.SortOrder
        {
            ($_ -eq "Get-MHSAnalyzableServerList/Sort") -Or
            ($_ -eq "Get-MHSApplicationComponentList/Sort") -Or
            ($_ -eq "Get-MHSServerList/Sort")
        }
        {
            $v = "ASC","DESC"
            break
        }

        # Amazon.MigrationHubStrategyRecommendations.Strategy
        {
            ($_ -eq "Update-MHSApplicationComponentConfig/StrategyOption_Strategy") -Or
            ($_ -eq "Update-MHSServerConfig/StrategyOption_Strategy")
        }
        {
            $v = "Refactor","Rehost","Relocate","Replatform","Repurchase","Retain","Retirement"
            break
        }

        # Amazon.MigrationHubStrategyRecommendations.TargetDestination
        {
            ($_ -eq "Update-MHSApplicationComponentConfig/StrategyOption_TargetDestination") -Or
            ($_ -eq "Update-MHSServerConfig/StrategyOption_TargetDestination")
        }
        {
            $v = "Amazon DocumentDB","Amazon DynamoDB","Amazon Elastic Cloud Compute (EC2)","Amazon Elastic Container Service (ECS)","Amazon Elastic Kubernetes Service (EKS)","Amazon Relational Database Service","Amazon Relational Database Service on MySQL","Amazon Relational Database Service on PostgreSQL","Aurora MySQL","Aurora PostgreSQL","AWS Elastic BeanStalk","AWS Fargate","Babelfish for Aurora PostgreSQL","None specified"
            break
        }

        # Amazon.MigrationHubStrategyRecommendations.TransformationToolName
        {
            ($_ -eq "Update-MHSApplicationComponentConfig/StrategyOption_ToolName") -Or
            ($_ -eq "Update-MHSServerConfig/StrategyOption_ToolName")
        }
        {
            $v = "App2Container","Application Migration Service","Database Migration Service","End of Support Migration","In Place Operating System Upgrade","Native SQL Server Backup/Restore","Porting Assistant For .NET","Schema Conversion Tool","Strategy Recommendation Support","Windows Web Application Migration Assistant"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$MHS_map = @{
    "ApplicationComponentCriteria"=@("Get-MHSApplicationComponentList")
    "ApplicationMode"=@("Write-MHSPortfolioPreference")
    "AppType"=@("Update-MHSApplicationComponentConfig")
    "AssessmentDataSourceType"=@("Start-MHSAssessment")
    "DatabasePreferences_DatabaseManagementPreference"=@("Write-MHSPortfolioPreference")
    "DataSourceType"=@("Start-MHSImportFileTask")
    "InclusionStatus"=@("Update-MHSApplicationComponentConfig")
    "OutputFormat"=@("Start-MHSRecommendationReportGeneration")
    "ServerCriteria"=@("Get-MHSServerList")
    "Sort"=@("Get-MHSAnalyzableServerList","Get-MHSApplicationComponentList","Get-MHSServerList")
    "StrategyOption_Strategy"=@("Update-MHSApplicationComponentConfig","Update-MHSServerConfig")
    "StrategyOption_TargetDestination"=@("Update-MHSApplicationComponentConfig","Update-MHSServerConfig")
    "StrategyOption_ToolName"=@("Update-MHSApplicationComponentConfig","Update-MHSServerConfig")
}

_awsArgumentCompleterRegistration $MHS_Completers $MHS_map

$MHS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.MHS.$($commandName.Replace('-', ''))Cmdlet]"
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

$MHS_SelectMap = @{
    "Select"=@("Get-MHSApplicationComponentDetail",
               "Get-MHSApplicationComponentStrategy",
               "Get-MHSAssessment",
               "Get-MHSImportFileTask",
               "Get-MHSLatestAssessmentId",
               "Get-MHSPortfolioPreference",
               "Get-MHSPortfolioSummary",
               "Get-MHSRecommendationReportDetail",
               "Get-MHSServerDetail",
               "Get-MHSServerStrategy",
               "Get-MHSAnalyzableServerList",
               "Get-MHSApplicationComponentList",
               "Get-MHSCollectorList",
               "Get-MHSImportFileTaskList",
               "Get-MHSServerList",
               "Write-MHSPortfolioPreference",
               "Start-MHSAssessment",
               "Start-MHSImportFileTask",
               "Start-MHSRecommendationReportGeneration",
               "Stop-MHSAssessment",
               "Update-MHSApplicationComponentConfig",
               "Update-MHSServerConfig")
}

_awsArgumentCompleterRegistration $MHS_SelectCompleters $MHS_SelectMap

