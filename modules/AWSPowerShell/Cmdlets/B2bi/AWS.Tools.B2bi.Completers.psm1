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

# Argument completions for service AWS B2B Data Interchange


$B2BI_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.B2bi.CapabilityDirection
        {
            ($_ -eq "New-B2BICapability/Edi_CapabilityDirection") -Or
            ($_ -eq "Update-B2BICapability/Edi_CapabilityDirection")
        }
        {
            $v = "INBOUND","OUTBOUND"
            break
        }

        # Amazon.B2bi.CapabilityType
        "New-B2BICapability/Type"
        {
            $v = "edi"
            break
        }

        # Amazon.B2bi.ConversionSourceFormat
        "Test-B2BIConversion/Source_FileFormat"
        {
            $v = "JSON","XML"
            break
        }

        # Amazon.B2bi.ConversionTargetFormat
        "Test-B2BIConversion/Target_FileFormat"
        {
            $v = "X12"
            break
        }

        # Amazon.B2bi.FileFormat
        {
            ($_ -eq "New-B2BITransformer/FileFormat") -Or
            ($_ -eq "Test-B2BIMapping/FileFormat") -Or
            ($_ -eq "Test-B2BIParsing/FileFormat") -Or
            ($_ -eq "Update-B2BITransformer/FileFormat")
        }
        {
            $v = "JSON","NOT_USED","XML"
            break
        }

        # Amazon.B2bi.FromFormat
        {
            ($_ -eq "New-B2BITransformer/InputConversion_FromFormat") -Or
            ($_ -eq "Update-B2BITransformer/InputConversion_FromFormat")
        }
        {
            $v = "X12"
            break
        }

        # Amazon.B2bi.LineTerminator
        {
            ($_ -eq "New-B2BIPartnership/WrapOptions_LineTerminator") -Or
            ($_ -eq "Update-B2BIPartnership/WrapOptions_LineTerminator")
        }
        {
            $v = "CR","CRLF","LF"
            break
        }

        # Amazon.B2bi.Logging
        "New-B2BIProfile/Logging"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.B2bi.MappingTemplateLanguage
        {
            ($_ -eq "New-B2BITransformer/Mapping_TemplateLanguage") -Or
            ($_ -eq "Update-B2BITransformer/Mapping_TemplateLanguage")
        }
        {
            $v = "JSONATA","XSLT"
            break
        }

        # Amazon.B2bi.MappingType
        {
            ($_ -eq "Get-B2BIGeneratedMapping/MappingType") -Or
            ($_ -eq "New-B2BIStarterMappingTemplate/MappingType")
        }
        {
            $v = "JSONATA","XSLT"
            break
        }

        # Amazon.B2bi.ToFormat
        {
            ($_ -eq "New-B2BITransformer/OutputConversion_ToFormat") -Or
            ($_ -eq "Update-B2BITransformer/OutputConversion_ToFormat")
        }
        {
            $v = "X12"
            break
        }

        # Amazon.B2bi.TransformerStatus
        "Update-B2BITransformer/Status"
        {
            $v = "active","inactive"
            break
        }

        # Amazon.B2bi.WrapFormat
        {
            ($_ -eq "New-B2BIPartnership/WrapOptions_WrapBy") -Or
            ($_ -eq "Update-B2BIPartnership/WrapOptions_WrapBy")
        }
        {
            $v = "LINE_LENGTH","ONE_LINE","SEGMENT"
            break
        }

        # Amazon.B2bi.X12FunctionalAcknowledgment
        {
            ($_ -eq "New-B2BIPartnership/AcknowledgmentOptions_FunctionalAcknowledgment") -Or
            ($_ -eq "Update-B2BIPartnership/AcknowledgmentOptions_FunctionalAcknowledgment")
        }
        {
            $v = "DO_NOT_GENERATE","GENERATE_ALL_SEGMENTS","GENERATE_WITHOUT_TRANSACTION_SET_RESPONSE_LOOP"
            break
        }

        # Amazon.B2bi.X12GS05TimeFormat
        {
            ($_ -eq "New-B2BIPartnership/Common_Gs05TimeFormat") -Or
            ($_ -eq "Update-B2BIPartnership/Common_Gs05TimeFormat")
        }
        {
            $v = "HHMM","HHMMSS","HHMMSSDD"
            break
        }

        # Amazon.B2bi.X12SplitBy
        {
            ($_ -eq "New-B2BITransformer/SplitOptions_SplitBy") -Or
            ($_ -eq "Test-B2BIParsing/SplitOptions_SplitBy") -Or
            ($_ -eq "Update-B2BITransformer/SplitOptions_SplitBy")
        }
        {
            $v = "NONE","TRANSACTION"
            break
        }

        # Amazon.B2bi.X12TechnicalAcknowledgment
        {
            ($_ -eq "New-B2BIPartnership/AcknowledgmentOptions_TechnicalAcknowledgment") -Or
            ($_ -eq "Update-B2BIPartnership/AcknowledgmentOptions_TechnicalAcknowledgment")
        }
        {
            $v = "DO_NOT_GENERATE","GENERATE_ALL_SEGMENTS"
            break
        }

        # Amazon.B2bi.X12TransactionSet
        {
            ($_ -eq "New-B2BITransformer/InputConversion_FormatOptions_X12_TransactionSet") -Or
            ($_ -eq "Update-B2BITransformer/InputConversion_FormatOptions_X12_TransactionSet") -Or
            ($_ -eq "New-B2BITransformer/OutputConversion_FormatOptions_X12_TransactionSet") -Or
            ($_ -eq "Update-B2BITransformer/OutputConversion_FormatOptions_X12_TransactionSet") -Or
            ($_ -eq "New-B2BIStarterMappingTemplate/X12_TransactionSet") -Or
            ($_ -eq "Test-B2BIConversion/X12_TransactionSet") -Or
            ($_ -eq "New-B2BICapability/X12Details_TransactionSet") -Or
            ($_ -eq "New-B2BITransformer/X12Details_TransactionSet") -Or
            ($_ -eq "Test-B2BIParsing/X12Details_TransactionSet") -Or
            ($_ -eq "Update-B2BICapability/X12Details_TransactionSet") -Or
            ($_ -eq "Update-B2BITransformer/X12Details_TransactionSet")
        }
        {
            $v = "X12_100","X12_101","X12_102","X12_103","X12_104","X12_105","X12_106","X12_107","X12_108","X12_109","X12_110","X12_111","X12_112","X12_113","X12_120","X12_121","X12_124","X12_125","X12_126","X12_127","X12_128","X12_129","X12_130","X12_131","X12_132","X12_133","X12_135","X12_138","X12_139","X12_140","X12_141","X12_142","X12_143","X12_144","X12_146","X12_147","X12_148","X12_149","X12_150","X12_151","X12_152","X12_153","X12_154","X12_155","X12_157","X12_158","X12_159","X12_160","X12_161","X12_163","X12_170","X12_175","X12_176","X12_179","X12_180","X12_185","X12_186","X12_187","X12_188","X12_189","X12_190","X12_191","X12_194","X12_195","X12_196","X12_197","X12_198","X12_199","X12_200","X12_201","X12_202","X12_203","X12_204","X12_205","X12_206","X12_210","X12_211","X12_212","X12_213","X12_214","X12_215","X12_216","X12_217","X12_218","X12_219","X12_220","X12_222","X12_223","X12_224","X12_225","X12_227","X12_228","X12_240","X12_242","X12_244","X12_245","X12_248","X12_249","X12_250","X12_251","X12_252","X12_255","X12_256","X12_259","X12_260","X12_261","X12_262","X12_263","X12_264","X12_265","X12_266","X12_267","X12_268","X12_269","X12_270","X12_270_X279","X12_271","X12_271_X279","X12_272","X12_273","X12_274","X12_275","X12_275_X210","X12_275_X211","X12_276","X12_276_X212","X12_277","X12_277_X212","X12_277_X214","X12_277_X364","X12_278","X12_278_X217","X12_280","X12_283","X12_284","X12_285","X12_286","X12_288","X12_290","X12_300","X12_301","X12_303","X12_304","X12_309","X12_310","X12_311","X12_312","X12_313","X12_315","X12_317","X12_319","X12_322","X12_323","X12_324","X12_325","X12_326","X12_350","X12_352","X12_353","X12_354","X12_355","X12_356","X12_357","X12_358","X12_361","X12_362","X12_404","X12_410","X12_412","X12_414","X12_417","X12_418","X12_419","X12_420","X12_421","X12_422","X12_423","X12_424","X12_425","X12_426","X12_429","X12_431","X12_432","X12_433","X12_434","X12_435","X12_436","X12_437","X12_440","X12_451","X12_452","X12_453","X12_455","X12_456","X12_460","X12_463","X12_466","X12_468","X12_470","X12_475","X12_485","X12_486","X12_490","X12_492","X12_494","X12_500","X12_501","X12_503","X12_504","X12_511","X12_517","X12_521","X12_527","X12_536","X12_540","X12_561","X12_567","X12_568","X12_601","X12_602","X12_620","X12_625","X12_650","X12_715","X12_753","X12_754","X12_805","X12_806","X12_810","X12_811","X12_812","X12_813","X12_814","X12_815","X12_816","X12_818","X12_819","X12_820","X12_820_X218","X12_820_X306","X12_821","X12_822","X12_823","X12_824","X12_824_X186","X12_826","X12_827","X12_828","X12_829","X12_830","X12_831","X12_832","X12_833","X12_834","X12_834_X220","X12_834_X307","X12_834_X318","X12_835","X12_835_X221","X12_836","X12_837","X12_837_X222","X12_837_X223","X12_837_X224","X12_837_X291","X12_837_X292","X12_837_X298","X12_838","X12_839","X12_840","X12_841","X12_842","X12_843","X12_844","X12_845","X12_846","X12_847","X12_848","X12_849","X12_850","X12_851","X12_852","X12_853","X12_854","X12_855","X12_856","X12_857","X12_858","X12_859","X12_860","X12_861","X12_862","X12_863","X12_864","X12_865","X12_866","X12_867","X12_868","X12_869","X12_870","X12_871","X12_872","X12_873","X12_874","X12_875","X12_876","X12_877","X12_878","X12_879","X12_880","X12_881","X12_882","X12_883","X12_884","X12_885","X12_886","X12_887","X12_888","X12_889","X12_891","X12_893","X12_894","X12_895","X12_896","X12_920","X12_924","X12_925","X12_926","X12_928","X12_940","X12_943","X12_944","X12_945","X12_947","X12_980","X12_990","X12_993","X12_996","X12_997","X12_998","X12_999","X12_999_X231"
            break
        }

        # Amazon.B2bi.X12Version
        {
            ($_ -eq "New-B2BITransformer/InputConversion_FormatOptions_X12_Version") -Or
            ($_ -eq "Update-B2BITransformer/InputConversion_FormatOptions_X12_Version") -Or
            ($_ -eq "New-B2BITransformer/OutputConversion_FormatOptions_X12_Version") -Or
            ($_ -eq "Update-B2BITransformer/OutputConversion_FormatOptions_X12_Version") -Or
            ($_ -eq "New-B2BIStarterMappingTemplate/X12_Version") -Or
            ($_ -eq "Test-B2BIConversion/X12_Version") -Or
            ($_ -eq "New-B2BICapability/X12Details_Version") -Or
            ($_ -eq "New-B2BITransformer/X12Details_Version") -Or
            ($_ -eq "Test-B2BIParsing/X12Details_Version") -Or
            ($_ -eq "Update-B2BICapability/X12Details_Version") -Or
            ($_ -eq "Update-B2BITransformer/X12Details_Version")
        }
        {
            $v = "VERSION_4010","VERSION_4030","VERSION_4050","VERSION_4060","VERSION_5010","VERSION_5010_HIPAA"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$B2BI_map = @{
    "AcknowledgmentOptions_FunctionalAcknowledgment"=@("New-B2BIPartnership","Update-B2BIPartnership")
    "AcknowledgmentOptions_TechnicalAcknowledgment"=@("New-B2BIPartnership","Update-B2BIPartnership")
    "Common_Gs05TimeFormat"=@("New-B2BIPartnership","Update-B2BIPartnership")
    "Edi_CapabilityDirection"=@("New-B2BICapability","Update-B2BICapability")
    "FileFormat"=@("New-B2BITransformer","Test-B2BIMapping","Test-B2BIParsing","Update-B2BITransformer")
    "InputConversion_FormatOptions_X12_TransactionSet"=@("New-B2BITransformer","Update-B2BITransformer")
    "InputConversion_FormatOptions_X12_Version"=@("New-B2BITransformer","Update-B2BITransformer")
    "InputConversion_FromFormat"=@("New-B2BITransformer","Update-B2BITransformer")
    "Logging"=@("New-B2BIProfile")
    "Mapping_TemplateLanguage"=@("New-B2BITransformer","Update-B2BITransformer")
    "MappingType"=@("Get-B2BIGeneratedMapping","New-B2BIStarterMappingTemplate")
    "OutputConversion_FormatOptions_X12_TransactionSet"=@("New-B2BITransformer","Update-B2BITransformer")
    "OutputConversion_FormatOptions_X12_Version"=@("New-B2BITransformer","Update-B2BITransformer")
    "OutputConversion_ToFormat"=@("New-B2BITransformer","Update-B2BITransformer")
    "Source_FileFormat"=@("Test-B2BIConversion")
    "SplitOptions_SplitBy"=@("New-B2BITransformer","Test-B2BIParsing","Update-B2BITransformer")
    "Status"=@("Update-B2BITransformer")
    "Target_FileFormat"=@("Test-B2BIConversion")
    "Type"=@("New-B2BICapability")
    "WrapOptions_LineTerminator"=@("New-B2BIPartnership","Update-B2BIPartnership")
    "WrapOptions_WrapBy"=@("New-B2BIPartnership","Update-B2BIPartnership")
    "X12_TransactionSet"=@("New-B2BIStarterMappingTemplate","Test-B2BIConversion")
    "X12_Version"=@("New-B2BIStarterMappingTemplate","Test-B2BIConversion")
    "X12Details_TransactionSet"=@("New-B2BICapability","New-B2BITransformer","Test-B2BIParsing","Update-B2BICapability","Update-B2BITransformer")
    "X12Details_Version"=@("New-B2BICapability","New-B2BITransformer","Test-B2BIParsing","Update-B2BICapability","Update-B2BITransformer")
}

_awsArgumentCompleterRegistration $B2BI_Completers $B2BI_map

$B2BI_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.B2BI.$($commandName.Replace('-', ''))Cmdlet]"
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

$B2BI_SelectMap = @{
    "Select"=@("New-B2BICapability",
               "New-B2BIPartnership",
               "New-B2BIProfile",
               "New-B2BIStarterMappingTemplate",
               "New-B2BITransformer",
               "Remove-B2BICapability",
               "Remove-B2BIPartnership",
               "Remove-B2BIProfile",
               "Remove-B2BITransformer",
               "Get-B2BIGeneratedMapping",
               "Get-B2BICapability",
               "Get-B2BIPartnership",
               "Get-B2BIProfile",
               "Get-B2BITransformer",
               "Get-B2BITransformerJob",
               "Get-B2BICapabilityList",
               "Get-B2BIPartnershipList",
               "Get-B2BIProfileList",
               "Get-B2BIResourceTag",
               "Get-B2BITransformerList",
               "Start-B2BITransformerJob",
               "Add-B2BIResourceTag",
               "Test-B2BIConversion",
               "Test-B2BIMapping",
               "Test-B2BIParsing",
               "Remove-B2BIResourceTag",
               "Update-B2BICapability",
               "Update-B2BIPartnership",
               "Update-B2BIProfile",
               "Update-B2BITransformer")
}

_awsArgumentCompleterRegistration $B2BI_SelectCompleters $B2BI_SelectMap

