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

# Argument completions for service AWS Device Farm


$DF_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DeviceFarm.ArtifactCategory
        "Get-DFArtifactList/Type"
        {
            $v = "FILE","LOG","SCREENSHOT"
            break
        }

        # Amazon.DeviceFarm.BillingMethod
        {
            ($_ -eq "Get-DFDevicePoolCompatibility/Configuration_BillingMethod") -Or
            ($_ -eq "New-DFRemoteAccessSession/Configuration_BillingMethod") -Or
            ($_ -eq "Submit-DFTestRun/Configuration_BillingMethod")
        }
        {
            $v = "METERED","UNMETERED"
            break
        }

        # Amazon.DeviceFarm.DevicePoolType
        "Get-DFDevicePoolList/Type"
        {
            $v = "CURATED","PRIVATE"
            break
        }

        # Amazon.DeviceFarm.InteractionMode
        "New-DFRemoteAccessSession/InteractionMode"
        {
            $v = "INTERACTIVE","NO_VIDEO","VIDEO_ONLY"
            break
        }

        # Amazon.DeviceFarm.NetworkProfileType
        {
            ($_ -eq "Get-DFNetworkProfileList/Type") -Or
            ($_ -eq "New-DFNetworkProfile/Type") -Or
            ($_ -eq "Update-DFNetworkProfile/Type")
        }
        {
            $v = "CURATED","PRIVATE"
            break
        }

        # Amazon.DeviceFarm.TestGridSessionArtifactCategory
        "Get-DFTestGridSessionArtifactList/Type"
        {
            $v = "LOG","VIDEO"
            break
        }

        # Amazon.DeviceFarm.TestGridSessionStatus
        "Get-DFTestGridSessionList/Status"
        {
            $v = "ACTIVE","CLOSED","ERRORED"
            break
        }

        # Amazon.DeviceFarm.TestType
        {
            ($_ -eq "Get-DFDevicePoolCompatibility/Test_Type") -Or
            ($_ -eq "Submit-DFTestRun/Test_Type") -Or
            ($_ -eq "Get-DFDevicePoolCompatibility/TestType")
        }
        {
            $v = "APPIUM_JAVA_JUNIT","APPIUM_JAVA_TESTNG","APPIUM_NODE","APPIUM_PYTHON","APPIUM_RUBY","APPIUM_WEB_JAVA_JUNIT","APPIUM_WEB_JAVA_TESTNG","APPIUM_WEB_NODE","APPIUM_WEB_PYTHON","APPIUM_WEB_RUBY","BUILTIN_FUZZ","INSTRUMENTATION","XCTEST","XCTEST_UI"
            break
        }

        # Amazon.DeviceFarm.UploadType
        {
            ($_ -eq "Get-DFUploadList/Type") -Or
            ($_ -eq "New-DFUpload/Type")
        }
        {
            $v = "ANDROID_APP","APPIUM_JAVA_JUNIT_TEST_PACKAGE","APPIUM_JAVA_JUNIT_TEST_SPEC","APPIUM_JAVA_TESTNG_TEST_PACKAGE","APPIUM_JAVA_TESTNG_TEST_SPEC","APPIUM_NODE_TEST_PACKAGE","APPIUM_NODE_TEST_SPEC","APPIUM_PYTHON_TEST_PACKAGE","APPIUM_PYTHON_TEST_SPEC","APPIUM_RUBY_TEST_PACKAGE","APPIUM_RUBY_TEST_SPEC","APPIUM_WEB_JAVA_JUNIT_TEST_PACKAGE","APPIUM_WEB_JAVA_JUNIT_TEST_SPEC","APPIUM_WEB_JAVA_TESTNG_TEST_PACKAGE","APPIUM_WEB_JAVA_TESTNG_TEST_SPEC","APPIUM_WEB_NODE_TEST_PACKAGE","APPIUM_WEB_NODE_TEST_SPEC","APPIUM_WEB_PYTHON_TEST_PACKAGE","APPIUM_WEB_PYTHON_TEST_SPEC","APPIUM_WEB_RUBY_TEST_PACKAGE","APPIUM_WEB_RUBY_TEST_SPEC","CALABASH_TEST_PACKAGE","EXTERNAL_DATA","INSTRUMENTATION_TEST_PACKAGE","INSTRUMENTATION_TEST_SPEC","IOS_APP","UIAUTOMATION_TEST_PACKAGE","UIAUTOMATOR_TEST_PACKAGE","WEB_APP","XCTEST_TEST_PACKAGE","XCTEST_UI_TEST_PACKAGE","XCTEST_UI_TEST_SPEC"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DF_map = @{
    "Configuration_BillingMethod"=@("Get-DFDevicePoolCompatibility","New-DFRemoteAccessSession","Submit-DFTestRun")
    "InteractionMode"=@("New-DFRemoteAccessSession")
    "Status"=@("Get-DFTestGridSessionList")
    "Test_Type"=@("Get-DFDevicePoolCompatibility","Submit-DFTestRun")
    "TestType"=@("Get-DFDevicePoolCompatibility")
    "Type"=@("Get-DFArtifactList","Get-DFDevicePoolList","Get-DFNetworkProfileList","Get-DFTestGridSessionArtifactList","Get-DFUploadList","New-DFNetworkProfile","New-DFUpload","Update-DFNetworkProfile")
}

_awsArgumentCompleterRegistration $DF_Completers $DF_map

$DF_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.DF.$($commandName.Replace('-', ''))Cmdlet]"
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

$DF_SelectMap = @{
    "Select"=@("New-DFDevicePool",
               "New-DFInstanceProfile",
               "New-DFNetworkProfile",
               "New-DFProject",
               "New-DFRemoteAccessSession",
               "New-DFTestGridProject",
               "New-DFTestGridUrl",
               "New-DFUpload",
               "New-DFVPCEConfiguration",
               "Remove-DFDevicePool",
               "Remove-DFInstanceProfile",
               "Remove-DFNetworkProfile",
               "Remove-DFProject",
               "Remove-DFRemoteAccessSession",
               "Remove-DFRun",
               "Remove-DFTestGridProject",
               "Remove-DFUpload",
               "Remove-DFVPCEConfiguration",
               "Get-DFAccountSettingList",
               "Get-DFDevice",
               "Get-DFDeviceInstance",
               "Get-DFDevicePool",
               "Get-DFDevicePoolCompatibility",
               "Get-DFInstanceProfile",
               "Get-DFJob",
               "Get-DFNetworkProfile",
               "Get-DFOfferingStatus",
               "Get-DFProject",
               "Get-DFRemoteAccessSession",
               "Get-DFRun",
               "Get-DFSuite",
               "Get-DFTest",
               "Get-DFTestGridProject",
               "Get-DFTestGridSession",
               "Get-DFUpload",
               "Get-DFVPCEConfiguration",
               "Install-DFToRemoteAccessSession",
               "Get-DFArtifactList",
               "Get-DFDeviceInstanceList",
               "Get-DFDevicePoolList",
               "Get-DFDeviceList",
               "Get-DFInstanceProfileList",
               "Get-DFJobList",
               "Get-DFNetworkProfileList",
               "Get-DFOfferingPromotion",
               "Get-DFOffering",
               "Get-DFOfferingTransaction",
               "Get-DFProjectList",
               "Get-DFRemoteAccessSessionList",
               "Get-DFRunList",
               "Get-DFSampleList",
               "Get-DFSuiteList",
               "Get-DFResourceTag",
               "Get-DFTestGridProjectList",
               "Get-DFTestGridSessionActionList",
               "Get-DFTestGridSessionArtifactList",
               "Get-DFTestGridSessionList",
               "Get-DFTestList",
               "Get-DFUniqueProblemList",
               "Get-DFUploadList",
               "Get-DFVPCEConfigurationList",
               "New-DFOfferingPurchase",
               "New-DFOfferingRenewal",
               "Submit-DFTestRun",
               "Stop-DFJob",
               "Stop-DFRemoteAccessSession",
               "Stop-DFRun",
               "Add-DFResourceTag",
               "Remove-DFResourceTag",
               "Update-DFDeviceInstance",
               "Update-DFDevicePool",
               "Update-DFInstanceProfile",
               "Update-DFNetworkProfile",
               "Update-DFProject",
               "Update-DFTestGridProject",
               "Update-DFUpload",
               "Update-DFVPCEConfiguration")
}

_awsArgumentCompleterRegistration $DF_SelectCompleters $DF_SelectMap

