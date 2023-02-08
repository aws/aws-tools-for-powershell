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

# Argument completions for service Amazon CloudFront


$CF_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudFront.CachePolicyCookieBehavior
        {
            ($_ -eq "New-CFCachePolicy/CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_CookieBehavior") -Or
            ($_ -eq "Update-CFCachePolicy/CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_CookieBehavior")
        }
        {
            $v = "all","allExcept","none","whitelist"
            break
        }

        # Amazon.CloudFront.CachePolicyHeaderBehavior
        {
            ($_ -eq "New-CFCachePolicy/CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_HeaderBehavior") -Or
            ($_ -eq "Update-CFCachePolicy/CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_HeaderBehavior")
        }
        {
            $v = "none","whitelist"
            break
        }

        # Amazon.CloudFront.CachePolicyQueryStringBehavior
        {
            ($_ -eq "New-CFCachePolicy/CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStringBehavior") -Or
            ($_ -eq "Update-CFCachePolicy/CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStringBehavior")
        }
        {
            $v = "all","allExcept","none","whitelist"
            break
        }

        # Amazon.CloudFront.CachePolicyType
        "Get-CFCachePolicyList/Type"
        {
            $v = "custom","managed"
            break
        }

        # Amazon.CloudFront.CertificateSource
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_ViewerCertificate_CertificateSource") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_ViewerCertificate_CertificateSource") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CertificateSource")
        }
        {
            $v = "acm","cloudfront","iam"
            break
        }

        # Amazon.CloudFront.ContinuousDeploymentPolicyType
        {
            ($_ -eq "New-CFContinuousDeploymentPolicy/ContinuousDeploymentPolicyConfig_TrafficConfig_Type") -Or
            ($_ -eq "Update-CFContinuousDeploymentPolicy/ContinuousDeploymentPolicyConfig_TrafficConfig_Type")
        }
        {
            $v = "SingleHeader","SingleWeight"
            break
        }

        # Amazon.CloudFront.FrameOptionsList
        {
            ($_ -eq "New-CFResponseHeadersPolicy/ResponseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions_FrameOption") -Or
            ($_ -eq "Update-CFResponseHeadersPolicy/ResponseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions_FrameOption")
        }
        {
            $v = "DENY","SAMEORIGIN"
            break
        }

        # Amazon.CloudFront.FunctionRuntime
        {
            ($_ -eq "New-CFFunction/FunctionConfig_Runtime") -Or
            ($_ -eq "Update-CFFunction/FunctionConfig_Runtime")
        }
        {
            $v = "cloudfront-js-1.0"
            break
        }

        # Amazon.CloudFront.FunctionStage
        {
            ($_ -eq "Get-CFFunction/Stage") -Or
            ($_ -eq "Get-CFFunctionList/Stage") -Or
            ($_ -eq "Get-CFFunctionSummary/Stage") -Or
            ($_ -eq "Test-CFFunction/Stage")
        }
        {
            $v = "DEVELOPMENT","LIVE"
            break
        }

        # Amazon.CloudFront.GeoRestrictionType
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_Restrictions_GeoRestriction_RestrictionType") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_Restrictions_GeoRestriction_RestrictionType") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_RestrictionType")
        }
        {
            $v = "blacklist","none","whitelist"
            break
        }

        # Amazon.CloudFront.HttpVersion
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_HttpVersion") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_HttpVersion") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_HttpVersion")
        }
        {
            $v = "http1.1","http2","http2and3","http3"
            break
        }

        # Amazon.CloudFront.ItemSelection
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward")
        }
        {
            $v = "all","none","whitelist"
            break
        }

        # Amazon.CloudFront.MinimumProtocolVersion
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_ViewerCertificate_MinimumProtocolVersion") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_ViewerCertificate_MinimumProtocolVersion") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_ViewerCertificate_MinimumProtocolVersion")
        }
        {
            $v = "SSLv3","TLSv1","TLSv1.1_2016","TLSv1.2_2018","TLSv1.2_2019","TLSv1.2_2021","TLSv1_2016"
            break
        }

        # Amazon.CloudFront.OriginAccessControlOriginTypes
        {
            ($_ -eq "New-CFOriginAccessControl/OriginAccessControlConfig_OriginAccessControlOriginType") -Or
            ($_ -eq "Update-CFOriginAccessControl/OriginAccessControlConfig_OriginAccessControlOriginType")
        }
        {
            $v = "mediastore","s3"
            break
        }

        # Amazon.CloudFront.OriginAccessControlSigningBehaviors
        {
            ($_ -eq "New-CFOriginAccessControl/OriginAccessControlConfig_SigningBehavior") -Or
            ($_ -eq "Update-CFOriginAccessControl/OriginAccessControlConfig_SigningBehavior")
        }
        {
            $v = "always","never","no-override"
            break
        }

        # Amazon.CloudFront.OriginAccessControlSigningProtocols
        {
            ($_ -eq "New-CFOriginAccessControl/OriginAccessControlConfig_SigningProtocol") -Or
            ($_ -eq "Update-CFOriginAccessControl/OriginAccessControlConfig_SigningProtocol")
        }
        {
            $v = "sigv4"
            break
        }

        # Amazon.CloudFront.OriginRequestPolicyCookieBehavior
        {
            ($_ -eq "New-CFOriginRequestPolicy/OriginRequestPolicyConfig_CookiesConfig_CookieBehavior") -Or
            ($_ -eq "Update-CFOriginRequestPolicy/OriginRequestPolicyConfig_CookiesConfig_CookieBehavior")
        }
        {
            $v = "all","none","whitelist"
            break
        }

        # Amazon.CloudFront.OriginRequestPolicyHeaderBehavior
        {
            ($_ -eq "New-CFOriginRequestPolicy/OriginRequestPolicyConfig_HeadersConfig_HeaderBehavior") -Or
            ($_ -eq "Update-CFOriginRequestPolicy/OriginRequestPolicyConfig_HeadersConfig_HeaderBehavior")
        }
        {
            $v = "allViewer","allViewerAndWhitelistCloudFront","none","whitelist"
            break
        }

        # Amazon.CloudFront.OriginRequestPolicyQueryStringBehavior
        {
            ($_ -eq "New-CFOriginRequestPolicy/OriginRequestPolicyConfig_QueryStringsConfig_QueryStringBehavior") -Or
            ($_ -eq "Update-CFOriginRequestPolicy/OriginRequestPolicyConfig_QueryStringsConfig_QueryStringBehavior")
        }
        {
            $v = "all","none","whitelist"
            break
        }

        # Amazon.CloudFront.OriginRequestPolicyType
        "Get-CFOriginRequestPolicyList/Type"
        {
            $v = "custom","managed"
            break
        }

        # Amazon.CloudFront.PriceClass
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_PriceClass") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_PriceClass") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_PriceClass") -Or
            ($_ -eq "New-CFStreamingDistribution/StreamingDistributionConfig_PriceClass") -Or
            ($_ -eq "Update-CFStreamingDistribution/StreamingDistributionConfig_PriceClass") -Or
            ($_ -eq "New-CFStreamingDistributionWithTag/StreamingDistributionConfigWithTags_StreamingDistributionConfig_PriceClass")
        }
        {
            $v = "PriceClass_100","PriceClass_200","PriceClass_All"
            break
        }

        # Amazon.CloudFront.RealtimeMetricsSubscriptionStatus
        "New-CFMonitoringSubscription/MonitoringSubscription_RealtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus"
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.CloudFront.ReferrerPolicyList
        {
            ($_ -eq "New-CFResponseHeadersPolicy/ResponseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy_ReferrerPolicy") -Or
            ($_ -eq "Update-CFResponseHeadersPolicy/ResponseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy_ReferrerPolicy")
        }
        {
            $v = "no-referrer","no-referrer-when-downgrade","origin","origin-when-cross-origin","same-origin","strict-origin","strict-origin-when-cross-origin","unsafe-url"
            break
        }

        # Amazon.CloudFront.ResponseHeadersPolicyType
        "Get-CFResponseHeadersPolicyList/Type"
        {
            $v = "custom","managed"
            break
        }

        # Amazon.CloudFront.SSLSupportMethod
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_ViewerCertificate_SSLSupportMethod") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_ViewerCertificate_SSLSupportMethod") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_ViewerCertificate_SSLSupportMethod")
        }
        {
            $v = "sni-only","static-ip","vip"
            break
        }

        # Amazon.CloudFront.ViewerProtocolPolicy
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy")
        }
        {
            $v = "allow-all","https-only","redirect-to-https"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CF_map = @{
    "CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_CookiesConfig_CookieBehavior"=@("New-CFCachePolicy","Update-CFCachePolicy")
    "CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_HeadersConfig_HeaderBehavior"=@("New-CFCachePolicy","Update-CFCachePolicy")
    "CachePolicyConfig_ParametersInCacheKeyAndForwardedToOrigin_QueryStringsConfig_QueryStringBehavior"=@("New-CFCachePolicy","Update-CFCachePolicy")
    "ContinuousDeploymentPolicyConfig_TrafficConfig_Type"=@("New-CFContinuousDeploymentPolicy","Update-CFContinuousDeploymentPolicy")
    "DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfig_HttpVersion"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfig_PriceClass"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfig_Restrictions_GeoRestriction_RestrictionType"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfig_ViewerCertificate_CertificateSource"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfig_ViewerCertificate_MinimumProtocolVersion"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfig_ViewerCertificate_SSLSupportMethod"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward"=@("New-CFDistributionWithTag")
    "DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy"=@("New-CFDistributionWithTag")
    "DistributionConfigWithTags_DistributionConfig_HttpVersion"=@("New-CFDistributionWithTag")
    "DistributionConfigWithTags_DistributionConfig_PriceClass"=@("New-CFDistributionWithTag")
    "DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_RestrictionType"=@("New-CFDistributionWithTag")
    "DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CertificateSource"=@("New-CFDistributionWithTag")
    "DistributionConfigWithTags_DistributionConfig_ViewerCertificate_MinimumProtocolVersion"=@("New-CFDistributionWithTag")
    "DistributionConfigWithTags_DistributionConfig_ViewerCertificate_SSLSupportMethod"=@("New-CFDistributionWithTag")
    "FunctionConfig_Runtime"=@("New-CFFunction","Update-CFFunction")
    "MonitoringSubscription_RealtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus"=@("New-CFMonitoringSubscription")
    "OriginAccessControlConfig_OriginAccessControlOriginType"=@("New-CFOriginAccessControl","Update-CFOriginAccessControl")
    "OriginAccessControlConfig_SigningBehavior"=@("New-CFOriginAccessControl","Update-CFOriginAccessControl")
    "OriginAccessControlConfig_SigningProtocol"=@("New-CFOriginAccessControl","Update-CFOriginAccessControl")
    "OriginRequestPolicyConfig_CookiesConfig_CookieBehavior"=@("New-CFOriginRequestPolicy","Update-CFOriginRequestPolicy")
    "OriginRequestPolicyConfig_HeadersConfig_HeaderBehavior"=@("New-CFOriginRequestPolicy","Update-CFOriginRequestPolicy")
    "OriginRequestPolicyConfig_QueryStringsConfig_QueryStringBehavior"=@("New-CFOriginRequestPolicy","Update-CFOriginRequestPolicy")
    "ResponseHeadersPolicyConfig_SecurityHeadersConfig_FrameOptions_FrameOption"=@("New-CFResponseHeadersPolicy","Update-CFResponseHeadersPolicy")
    "ResponseHeadersPolicyConfig_SecurityHeadersConfig_ReferrerPolicy_ReferrerPolicy"=@("New-CFResponseHeadersPolicy","Update-CFResponseHeadersPolicy")
    "Stage"=@("Get-CFFunction","Get-CFFunctionList","Get-CFFunctionSummary","Test-CFFunction")
    "StreamingDistributionConfig_PriceClass"=@("New-CFStreamingDistribution","Update-CFStreamingDistribution")
    "StreamingDistributionConfigWithTags_StreamingDistributionConfig_PriceClass"=@("New-CFStreamingDistributionWithTag")
    "Type"=@("Get-CFCachePolicyList","Get-CFOriginRequestPolicyList","Get-CFResponseHeadersPolicyList")
}

_awsArgumentCompleterRegistration $CF_Completers $CF_map

$CF_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CF.$($commandName.Replace('-', ''))Cmdlet]"
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

$CF_SelectMap = @{
    "Select"=@("Move-CFAlias",
               "Copy-CFDistribution",
               "New-CFCachePolicy",
               "New-CFCloudFrontOriginAccessIdentity",
               "New-CFContinuousDeploymentPolicy",
               "New-CFDistribution",
               "New-CFDistributionWithTag",
               "New-CFFieldLevelEncryptionConfig",
               "New-CFFieldLevelEncryptionProfile",
               "New-CFFunction",
               "New-CFInvalidation",
               "New-CFKeyGroup",
               "New-CFMonitoringSubscription",
               "New-CFOriginAccessControl",
               "New-CFOriginRequestPolicy",
               "New-CFPublicKey",
               "New-CFRealtimeLogConfig",
               "New-CFResponseHeadersPolicy",
               "New-CFStreamingDistribution",
               "New-CFStreamingDistributionWithTag",
               "Remove-CFCachePolicy",
               "Remove-CFCloudFrontOriginAccessIdentity",
               "Remove-CFContinuousDeploymentPolicy",
               "Remove-CFDistribution",
               "Remove-CFFieldLevelEncryptionConfig",
               "Remove-CFFieldLevelEncryptionProfile",
               "Remove-CFFunction",
               "Remove-CFKeyGroup",
               "Remove-CFMonitoringSubscription",
               "Remove-CFOriginAccessControl",
               "Remove-CFOriginRequestPolicy",
               "Remove-CFPublicKey",
               "Remove-CFRealtimeLogConfig",
               "Remove-CFResponseHeadersPolicy",
               "Remove-CFStreamingDistribution",
               "Get-CFFunctionSummary",
               "Get-CFCachePolicy",
               "Get-CFCachePolicyConfig",
               "Get-CFCloudFrontOriginAccessIdentity",
               "Get-CFCloudFrontOriginAccessIdentityConfig",
               "Get-CFContinuousDeploymentPolicy",
               "Get-CFContinuousDeploymentPolicyConfig",
               "Get-CFDistribution",
               "Get-CFDistributionConfig",
               "Get-CFFieldLevelEncryption",
               "Get-CFFieldLevelEncryptionConfig",
               "Get-CFFieldLevelEncryptionProfile",
               "Get-CFFieldLevelEncryptionProfileConfig",
               "Get-CFFunction",
               "Get-CFInvalidation",
               "Get-CFKeyGroup",
               "Get-CFKeyGroupConfig",
               "Get-CFMonitoringSubscription",
               "Get-CFOriginAccessControl",
               "Get-CFOriginAccessControlConfig",
               "Get-CFOriginRequestPolicy",
               "Get-CFOriginRequestPolicyConfig",
               "Get-CFPublicKey",
               "Get-CFPublicKeyConfig",
               "Get-CFRealtimeLogConfig",
               "Get-CFResponseHeadersPolicy",
               "Get-CFResponseHeadersPolicyConfig",
               "Get-CFStreamingDistribution",
               "Get-CFStreamingDistributionConfig",
               "Get-CFCachePolicyList",
               "Get-CFCloudFrontOriginAccessIdentityList",
               "Get-CFConflictingAlias",
               "Get-CFContinuousDeploymentPolicyList",
               "Get-CFDistributionList",
               "Get-CFDistributionsByCachePolicyId",
               "Get-CFDistributionsByKeyGroup",
               "Get-CFDistributionsByOriginRequestPolicyId",
               "Get-CFDistributionsByRealtimeLogConfig",
               "Get-CFDistributionsByResponseHeadersPolicyId",
               "Get-CFDistributionListByWebACLId",
               "Get-CFFieldLevelEncryptionConfigList",
               "Get-CFFieldLevelEncryptionProfileList",
               "Get-CFFunctionList",
               "Get-CFInvalidationList",
               "Get-CFKeyGroupList",
               "Get-CFOriginAccessControlList",
               "Get-CFOriginRequestPolicyList",
               "Get-CFPublicKeyList",
               "Get-CFRealtimeLogConfigList",
               "Get-CFResponseHeadersPolicyList",
               "Get-CFStreamingDistributionList",
               "Get-CFResourceTag",
               "Publish-CFFunction",
               "Add-CFResourceTag",
               "Test-CFFunction",
               "Remove-CFResourceTag",
               "Update-CFCachePolicy",
               "Update-CFCloudFrontOriginAccessIdentity",
               "Update-CFContinuousDeploymentPolicy",
               "Update-CFDistribution",
               "Update-CFDistributionWithStagingConfig",
               "Update-CFFieldLevelEncryptionConfig",
               "Update-CFFieldLevelEncryptionProfile",
               "Update-CFFunction",
               "Update-CFKeyGroup",
               "Update-CFOriginAccessControl",
               "Update-CFOriginRequestPolicy",
               "Update-CFPublicKey",
               "Update-CFRealtimeLogConfig",
               "Update-CFResponseHeadersPolicy",
               "Update-CFStreamingDistribution",
               "New-CFSignedCookie",
               "New-CFSignedUrl")
}

_awsArgumentCompleterRegistration $CF_SelectCompleters $CF_SelectMap

