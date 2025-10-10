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
            ($_ -eq "New-CFCachePolicy/CookiesConfig_CookieBehavior") -Or
            ($_ -eq "Update-CFCachePolicy/CookiesConfig_CookieBehavior")
        }
        {
            $v = "all","allExcept","none","whitelist"
            break
        }

        # Amazon.CloudFront.CachePolicyHeaderBehavior
        {
            ($_ -eq "New-CFCachePolicy/HeadersConfig_HeaderBehavior") -Or
            ($_ -eq "Update-CFCachePolicy/HeadersConfig_HeaderBehavior")
        }
        {
            $v = "none","whitelist"
            break
        }

        # Amazon.CloudFront.CachePolicyQueryStringBehavior
        {
            ($_ -eq "New-CFCachePolicy/QueryStringsConfig_QueryStringBehavior") -Or
            ($_ -eq "Update-CFCachePolicy/QueryStringsConfig_QueryStringBehavior")
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
            ($_ -eq "New-CFDistribution/ViewerCertificate_CertificateSource") -Or
            ($_ -eq "New-CFDistributionWithTag/ViewerCertificate_CertificateSource") -Or
            ($_ -eq "Update-CFDistribution/ViewerCertificate_CertificateSource")
        }
        {
            $v = "acm","cloudfront","iam"
            break
        }

        # Amazon.CloudFront.CertificateTransparencyLoggingPreference
        {
            ($_ -eq "New-CFDistributionTenant/ManagedCertificateRequest_CertificateTransparencyLoggingPreference") -Or
            ($_ -eq "Update-CFDistributionTenant/ManagedCertificateRequest_CertificateTransparencyLoggingPreference")
        }
        {
            $v = "disabled","enabled"
            break
        }

        # Amazon.CloudFront.ConnectionMode
        {
            ($_ -eq "Get-CFDistributionsByConnectionMode/ConnectionMode") -Or
            ($_ -eq "New-CFDistribution/DistributionConfig_ConnectionMode") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfig_ConnectionMode") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_ConnectionMode")
        }
        {
            $v = "direct","tenant-only"
            break
        }

        # Amazon.CloudFront.ContinuousDeploymentPolicyType
        {
            ($_ -eq "New-CFContinuousDeploymentPolicy/TrafficConfig_Type") -Or
            ($_ -eq "Update-CFContinuousDeploymentPolicy/TrafficConfig_Type")
        }
        {
            $v = "SingleHeader","SingleWeight"
            break
        }

        # Amazon.CloudFront.CustomizationActionType
        {
            ($_ -eq "New-CFDistributionTenant/WebAcl_Action") -Or
            ($_ -eq "Update-CFDistributionTenant/WebAcl_Action")
        }
        {
            $v = "disable","override"
            break
        }

        # Amazon.CloudFront.FrameOptionsList
        {
            ($_ -eq "New-CFResponseHeadersPolicy/FrameOptions_FrameOption") -Or
            ($_ -eq "Update-CFResponseHeadersPolicy/FrameOptions_FrameOption")
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
            $v = "cloudfront-js-1.0","cloudfront-js-2.0"
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
            ($_ -eq "New-CFDistribution/GeoRestriction_RestrictionType") -Or
            ($_ -eq "New-CFDistributionWithTag/GeoRestriction_RestrictionType") -Or
            ($_ -eq "Update-CFDistribution/GeoRestriction_RestrictionType") -Or
            ($_ -eq "New-CFDistributionTenant/GeoRestrictions_RestrictionType") -Or
            ($_ -eq "Update-CFDistributionTenant/GeoRestrictions_RestrictionType")
        }
        {
            $v = "blacklist","none","whitelist"
            break
        }

        # Amazon.CloudFront.HttpVersion
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_HttpVersion") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfig_HttpVersion") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_HttpVersion")
        }
        {
            $v = "http1.1","http2","http2and3","http3"
            break
        }

        # Amazon.CloudFront.ImportSourceType
        "New-CFKeyValueStore/ImportSource_SourceType"
        {
            $v = "S3"
            break
        }

        # Amazon.CloudFront.ItemSelection
        {
            ($_ -eq "New-CFDistribution/Cookies_Forward") -Or
            ($_ -eq "New-CFDistributionWithTag/Cookies_Forward") -Or
            ($_ -eq "Update-CFDistribution/Cookies_Forward")
        }
        {
            $v = "all","none","whitelist"
            break
        }

        # Amazon.CloudFront.MinimumProtocolVersion
        {
            ($_ -eq "New-CFDistribution/ViewerCertificate_MinimumProtocolVersion") -Or
            ($_ -eq "New-CFDistributionWithTag/ViewerCertificate_MinimumProtocolVersion") -Or
            ($_ -eq "Update-CFDistribution/ViewerCertificate_MinimumProtocolVersion")
        }
        {
            $v = "SSLv3","TLSv1","TLSv1.1_2016","TLSv1.2_2018","TLSv1.2_2019","TLSv1.2_2021","TLSv1.2_2025","TLSv1.3_2025","TLSv1_2016"
            break
        }

        # Amazon.CloudFront.OriginAccessControlOriginTypes
        {
            ($_ -eq "New-CFOriginAccessControl/OriginAccessControlConfig_OriginAccessControlOriginType") -Or
            ($_ -eq "Update-CFOriginAccessControl/OriginAccessControlConfig_OriginAccessControlOriginType")
        }
        {
            $v = "lambda","mediapackagev2","mediastore","s3"
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

        # Amazon.CloudFront.OriginProtocolPolicy
        {
            ($_ -eq "New-CFVpcOrigin/VpcOriginEndpointConfig_OriginProtocolPolicy") -Or
            ($_ -eq "Update-CFVpcOrigin/VpcOriginEndpointConfig_OriginProtocolPolicy")
        }
        {
            $v = "http-only","https-only","match-viewer"
            break
        }

        # Amazon.CloudFront.OriginRequestPolicyCookieBehavior
        {
            ($_ -eq "New-CFOriginRequestPolicy/CookiesConfig_CookieBehavior") -Or
            ($_ -eq "Update-CFOriginRequestPolicy/CookiesConfig_CookieBehavior")
        }
        {
            $v = "all","allExcept","none","whitelist"
            break
        }

        # Amazon.CloudFront.OriginRequestPolicyHeaderBehavior
        {
            ($_ -eq "New-CFOriginRequestPolicy/HeadersConfig_HeaderBehavior") -Or
            ($_ -eq "Update-CFOriginRequestPolicy/HeadersConfig_HeaderBehavior")
        }
        {
            $v = "allExcept","allViewer","allViewerAndWhitelistCloudFront","none","whitelist"
            break
        }

        # Amazon.CloudFront.OriginRequestPolicyQueryStringBehavior
        {
            ($_ -eq "New-CFOriginRequestPolicy/QueryStringsConfig_QueryStringBehavior") -Or
            ($_ -eq "Update-CFOriginRequestPolicy/QueryStringsConfig_QueryStringBehavior")
        }
        {
            $v = "all","allExcept","none","whitelist"
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
            ($_ -eq "New-CFDistributionWithTag/DistributionConfig_PriceClass") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_PriceClass") -Or
            ($_ -eq "New-CFStreamingDistribution/StreamingDistributionConfig_PriceClass") -Or
            ($_ -eq "New-CFStreamingDistributionWithTag/StreamingDistributionConfig_PriceClass") -Or
            ($_ -eq "Update-CFStreamingDistribution/StreamingDistributionConfig_PriceClass")
        }
        {
            $v = "None","PriceClass_100","PriceClass_200","PriceClass_All"
            break
        }

        # Amazon.CloudFront.RealtimeMetricsSubscriptionStatus
        "New-CFMonitoringSubscription/RealtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus"
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.CloudFront.ReferrerPolicyList
        {
            ($_ -eq "New-CFResponseHeadersPolicy/ReferrerPolicy_ReferrerPolicy") -Or
            ($_ -eq "Update-CFResponseHeadersPolicy/ReferrerPolicy_ReferrerPolicy")
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
            ($_ -eq "New-CFDistribution/ViewerCertificate_SSLSupportMethod") -Or
            ($_ -eq "New-CFDistributionWithTag/ViewerCertificate_SSLSupportMethod") -Or
            ($_ -eq "Update-CFDistribution/ViewerCertificate_SSLSupportMethod")
        }
        {
            $v = "sni-only","static-ip","vip"
            break
        }

        # Amazon.CloudFront.ValidationTokenHost
        {
            ($_ -eq "New-CFDistributionTenant/ManagedCertificateRequest_ValidationTokenHost") -Or
            ($_ -eq "Update-CFDistributionTenant/ManagedCertificateRequest_ValidationTokenHost")
        }
        {
            $v = "cloudfront","self-hosted"
            break
        }

        # Amazon.CloudFront.ViewerProtocolPolicy
        {
            ($_ -eq "New-CFDistribution/DefaultCacheBehavior_ViewerProtocolPolicy") -Or
            ($_ -eq "New-CFDistributionWithTag/DefaultCacheBehavior_ViewerProtocolPolicy") -Or
            ($_ -eq "Update-CFDistribution/DefaultCacheBehavior_ViewerProtocolPolicy")
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
    "ConnectionMode"=@("Get-CFDistributionsByConnectionMode")
    "Cookies_Forward"=@("New-CFDistribution","New-CFDistributionWithTag","Update-CFDistribution")
    "CookiesConfig_CookieBehavior"=@("New-CFCachePolicy","New-CFOriginRequestPolicy","Update-CFCachePolicy","Update-CFOriginRequestPolicy")
    "DefaultCacheBehavior_ViewerProtocolPolicy"=@("New-CFDistribution","New-CFDistributionWithTag","Update-CFDistribution")
    "DistributionConfig_ConnectionMode"=@("New-CFDistribution","New-CFDistributionWithTag","Update-CFDistribution")
    "DistributionConfig_HttpVersion"=@("New-CFDistribution","New-CFDistributionWithTag","Update-CFDistribution")
    "DistributionConfig_PriceClass"=@("New-CFDistribution","New-CFDistributionWithTag","Update-CFDistribution")
    "FrameOptions_FrameOption"=@("New-CFResponseHeadersPolicy","Update-CFResponseHeadersPolicy")
    "FunctionConfig_Runtime"=@("New-CFFunction","Update-CFFunction")
    "GeoRestriction_RestrictionType"=@("New-CFDistribution","New-CFDistributionWithTag","Update-CFDistribution")
    "GeoRestrictions_RestrictionType"=@("New-CFDistributionTenant","Update-CFDistributionTenant")
    "HeadersConfig_HeaderBehavior"=@("New-CFCachePolicy","New-CFOriginRequestPolicy","Update-CFCachePolicy","Update-CFOriginRequestPolicy")
    "ImportSource_SourceType"=@("New-CFKeyValueStore")
    "ManagedCertificateRequest_CertificateTransparencyLoggingPreference"=@("New-CFDistributionTenant","Update-CFDistributionTenant")
    "ManagedCertificateRequest_ValidationTokenHost"=@("New-CFDistributionTenant","Update-CFDistributionTenant")
    "OriginAccessControlConfig_OriginAccessControlOriginType"=@("New-CFOriginAccessControl","Update-CFOriginAccessControl")
    "OriginAccessControlConfig_SigningBehavior"=@("New-CFOriginAccessControl","Update-CFOriginAccessControl")
    "OriginAccessControlConfig_SigningProtocol"=@("New-CFOriginAccessControl","Update-CFOriginAccessControl")
    "QueryStringsConfig_QueryStringBehavior"=@("New-CFCachePolicy","New-CFOriginRequestPolicy","Update-CFCachePolicy","Update-CFOriginRequestPolicy")
    "RealtimeMetricsSubscriptionConfig_RealtimeMetricsSubscriptionStatus"=@("New-CFMonitoringSubscription")
    "ReferrerPolicy_ReferrerPolicy"=@("New-CFResponseHeadersPolicy","Update-CFResponseHeadersPolicy")
    "Stage"=@("Get-CFFunction","Get-CFFunctionList","Get-CFFunctionSummary","Test-CFFunction")
    "StreamingDistributionConfig_PriceClass"=@("New-CFStreamingDistribution","New-CFStreamingDistributionWithTag","Update-CFStreamingDistribution")
    "TrafficConfig_Type"=@("New-CFContinuousDeploymentPolicy","Update-CFContinuousDeploymentPolicy")
    "Type"=@("Get-CFCachePolicyList","Get-CFOriginRequestPolicyList","Get-CFResponseHeadersPolicyList")
    "ViewerCertificate_CertificateSource"=@("New-CFDistribution","New-CFDistributionWithTag","Update-CFDistribution")
    "ViewerCertificate_MinimumProtocolVersion"=@("New-CFDistribution","New-CFDistributionWithTag","Update-CFDistribution")
    "ViewerCertificate_SSLSupportMethod"=@("New-CFDistribution","New-CFDistributionWithTag","Update-CFDistribution")
    "VpcOriginEndpointConfig_OriginProtocolPolicy"=@("New-CFVpcOrigin","Update-CFVpcOrigin")
    "WebAcl_Action"=@("New-CFDistributionTenant","Update-CFDistributionTenant")
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
               "Add-CFDistributionTenantWebACL",
               "Add-CFDistributionWebACL",
               "Copy-CFDistribution",
               "New-CFAnycastIpList",
               "New-CFCachePolicy",
               "New-CFCloudFrontOriginAccessIdentity",
               "New-CFConnectionGroup",
               "New-CFContinuousDeploymentPolicy",
               "New-CFDistribution",
               "New-CFDistributionTenant",
               "New-CFDistributionWithTag",
               "New-CFFieldLevelEncryptionConfig",
               "New-CFFieldLevelEncryptionProfile",
               "New-CFFunction",
               "New-CFInvalidation",
               "New-CFInvalidationForDistributionTenant",
               "New-CFKeyGroup",
               "New-CFKeyValueStore",
               "New-CFMonitoringSubscription",
               "New-CFOriginAccessControl",
               "New-CFOriginRequestPolicy",
               "New-CFPublicKey",
               "New-CFRealtimeLogConfig",
               "New-CFResponseHeadersPolicy",
               "New-CFStreamingDistribution",
               "New-CFStreamingDistributionWithTag",
               "New-CFVpcOrigin",
               "Remove-CFAnycastIpList",
               "Remove-CFCachePolicy",
               "Remove-CFCloudFrontOriginAccessIdentity",
               "Remove-CFConnectionGroup",
               "Remove-CFContinuousDeploymentPolicy",
               "Remove-CFDistribution",
               "Remove-CFDistributionTenant",
               "Remove-CFFieldLevelEncryptionConfig",
               "Remove-CFFieldLevelEncryptionProfile",
               "Remove-CFFunction",
               "Remove-CFKeyGroup",
               "Remove-CFKeyValueStore",
               "Remove-CFMonitoringSubscription",
               "Remove-CFOriginAccessControl",
               "Remove-CFOriginRequestPolicy",
               "Remove-CFPublicKey",
               "Remove-CFRealtimeLogConfig",
               "Remove-CFResponseHeadersPolicy",
               "Remove-CFStreamingDistribution",
               "Remove-CFVpcOrigin",
               "Get-CFFunctionSummary",
               "Get-CFKeyValueStore",
               "Remove-CFDistributionTenantWebACL",
               "Remove-CFDistributionWebACL",
               "Get-CFAnycastIpList",
               "Get-CFCachePolicy",
               "Get-CFCachePolicyConfig",
               "Get-CFCloudFrontOriginAccessIdentity",
               "Get-CFCloudFrontOriginAccessIdentityConfig",
               "Get-CFConnectionGroup",
               "Get-CFConnectionGroupByRoutingEndpoint",
               "Get-CFContinuousDeploymentPolicy",
               "Get-CFContinuousDeploymentPolicyConfig",
               "Get-CFDistribution",
               "Get-CFDistributionConfig",
               "Get-CFDistributionTenant",
               "Get-CFDistributionTenantByDomain",
               "Get-CFFieldLevelEncryption",
               "Get-CFFieldLevelEncryptionConfig",
               "Get-CFFieldLevelEncryptionProfile",
               "Get-CFFieldLevelEncryptionProfileConfig",
               "Get-CFFunction",
               "Get-CFInvalidation",
               "Get-CFInvalidationForDistributionTenant",
               "Get-CFKeyGroup",
               "Get-CFKeyGroupConfig",
               "Get-CFManagedCertificateDetail",
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
               "Get-CFVpcOrigin",
               "Get-CFAnycastIpListList",
               "Get-CFCachePolicyList",
               "Get-CFCloudFrontOriginAccessIdentityList",
               "Get-CFConflictingAlias",
               "Get-CFConnectionGroupList",
               "Get-CFContinuousDeploymentPolicyList",
               "Get-CFDistributionList",
               "Get-CFDistributionsByAnycastIpListId",
               "Get-CFDistributionsByCachePolicyId",
               "Get-CFDistributionsByConnectionMode",
               "Get-CFDistributionsByKeyGroup",
               "Get-CFDistributionsByOriginRequestPolicyId",
               "Get-CFDistributionsByRealtimeLogConfig",
               "Get-CFDistributionsByResponseHeadersPolicyId",
               "Get-CFDistributionsByVpcOriginId",
               "Get-CFDistributionListByWebACLId",
               "Get-CFDistributionTenantList",
               "Get-CFDistributionTenantsByCustomization",
               "Get-CFDomainConflict",
               "Get-CFFieldLevelEncryptionConfigList",
               "Get-CFFieldLevelEncryptionProfileList",
               "Get-CFFunctionList",
               "Get-CFInvalidationList",
               "Get-CFInvalidationsForDistributionTenant",
               "Get-CFKeyGroupList",
               "Get-CFKeyValueStoreListItem",
               "Get-CFOriginAccessControlList",
               "Get-CFOriginRequestPolicyList",
               "Get-CFPublicKeyList",
               "Get-CFRealtimeLogConfigList",
               "Get-CFResponseHeadersPolicyList",
               "Get-CFStreamingDistributionList",
               "Get-CFResourceTag",
               "Get-CFVpcOriginList",
               "Publish-CFFunction",
               "Add-CFResourceTag",
               "Test-CFFunction",
               "Remove-CFResourceTag",
               "Update-CFCachePolicy",
               "Update-CFCloudFrontOriginAccessIdentity",
               "Update-CFConnectionGroup",
               "Update-CFContinuousDeploymentPolicy",
               "Update-CFDistribution",
               "Update-CFDistributionTenant",
               "Update-CFDistributionWithStagingConfig",
               "Update-CFDomainAssociation",
               "Update-CFFieldLevelEncryptionConfig",
               "Update-CFFieldLevelEncryptionProfile",
               "Update-CFFunction",
               "Update-CFKeyGroup",
               "Update-CFKeyValueStore",
               "Update-CFOriginAccessControl",
               "Update-CFOriginRequestPolicy",
               "Update-CFPublicKey",
               "Update-CFRealtimeLogConfig",
               "Update-CFResponseHeadersPolicy",
               "Update-CFStreamingDistribution",
               "Update-CFVpcOrigin",
               "Test-CFDnsConfiguration",
               "New-CFSignedCookie",
               "New-CFSignedUrl")
}

_awsArgumentCompleterRegistration $CF_SelectCompleters $CF_SelectMap

