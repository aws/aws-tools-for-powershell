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

# Argument completions for service Partner Central Selling API


$PC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.PartnerCentralSelling.AwsFundingUsed
        {
            ($_ -eq "Invoke-PCCreateOpportunity/Marketing_AwsFundingUsed") -Or
            ($_ -eq "Update-PCOpportunity/Marketing_AwsFundingUsed")
        }
        {
            $v = "No","Yes"
            break
        }

        # Amazon.PartnerCentralSelling.AwsPartition
        {
            ($_ -eq "Invoke-PCCreateOpportunity/Project_AwsPartition") -Or
            ($_ -eq "Update-PCOpportunity/Project_AwsPartition")
        }
        {
            $v = "aws-eusc"
            break
        }

        # Amazon.PartnerCentralSelling.ClosedLostReason
        {
            ($_ -eq "Invoke-PCCreateOpportunity/LifeCycle_ClosedLostReason") -Or
            ($_ -eq "Update-PCOpportunity/LifeCycle_ClosedLostReason")
        }
        {
            $v = "Customer Deficiency","Customer Experience","Delay / Cancellation of Project","Financial/Commercial","Legal / Tax / Regulatory","Lost to Competitor - Google","Lost to Competitor - Microsoft","Lost to Competitor - Other","Lost to Competitor - SoftLayer","Lost to Competitor - VMWare","No Opportunity","On Premises Deployment","Other","Partner Gap","People/Relationship/Governance","Price","Product/Technology","Security / Compliance","Technical Limitations"
            break
        }

        # Amazon.PartnerCentralSelling.CompetitorName
        {
            ($_ -eq "Invoke-PCCreateOpportunity/Project_CompetitorName") -Or
            ($_ -eq "Update-PCOpportunity/Project_CompetitorName")
        }
        {
            $v = "*Other","Akamai","AliCloud","Co-location","Google Cloud Platform","IBM Softlayer","Microsoft Azure","No Competition","On-Prem","Oracle Cloud","Other- Cost Optimization"
            break
        }

        # Amazon.PartnerCentralSelling.CountryCode
        {
            ($_ -eq "Invoke-PCCreateOpportunity/Address_CountryCode") -Or
            ($_ -eq "New-PCEngagementContext/Address_CountryCode") -Or
            ($_ -eq "Update-PCEngagementContext/Address_CountryCode") -Or
            ($_ -eq "Update-PCOpportunity/Address_CountryCode") -Or
            ($_ -eq "New-PCEngagementContext/Customer_CountryCode") -Or
            ($_ -eq "Update-PCEngagementContext/Customer_CountryCode") -Or
            ($_ -eq "Invoke-PCCreateEngagementInvitation/Invitation_Payload_OpportunityInvitation_Customer_CountryCode") -Or
            ($_ -eq "Invoke-PCCreateEngagementInvitation/LeadInvitation_Customer_CountryCode")
        }
        {
            $v = "AD","AE","AF","AG","AI","AL","AM","AN","AO","AQ","AR","AS","AT","AU","AW","AX","AZ","BA","BB","BD","BE","BF","BG","BH","BI","BJ","BL","BM","BN","BO","BQ","BR","BS","BT","BV","BW","BY","BZ","CA","CC","CD","CF","CG","CH","CI","CK","CL","CM","CN","CO","CR","CU","CV","CW","CX","CY","CZ","DE","DJ","DK","DM","DO","DZ","EC","EE","EG","EH","ER","ES","ET","FI","FJ","FK","FM","FO","FR","GA","GB","GD","GE","GF","GG","GH","GI","GL","GM","GN","GP","GQ","GR","GS","GT","GU","GW","GY","HK","HM","HN","HR","HT","HU","ID","IE","IL","IM","IN","IO","IQ","IR","IS","IT","JE","JM","JO","JP","KE","KG","KH","KI","KM","KN","KR","KW","KY","KZ","LA","LB","LC","LI","LK","LR","LS","LT","LU","LV","LY","MA","MC","MD","ME","MF","MG","MH","MK","ML","MM","MN","MO","MP","MQ","MR","MS","MT","MU","MV","MW","MX","MY","MZ","NA","NC","NE","NF","NG","NI","NL","NO","NP","NR","NU","NZ","OM","PA","PE","PF","PG","PH","PK","PL","PM","PN","PR","PS","PT","PW","PY","QA","RE","RO","RS","RU","RW","SA","SB","SC","SD","SE","SG","SH","SI","SJ","SK","SL","SM","SN","SO","SR","SS","ST","SV","SX","SY","SZ","TC","TD","TF","TG","TH","TJ","TK","TL","TM","TN","TO","TR","TT","TV","TW","TZ","UA","UG","UM","US","UY","UZ","VA","VC","VE","VG","VI","VN","VU","WF","WS","YE","YT","ZA","ZM","ZW"
            break
        }

        # Amazon.PartnerCentralSelling.CurrencyCode
        {
            ($_ -eq "Invoke-PCCreateOpportunity/Value_CurrencyCode") -Or
            ($_ -eq "Update-PCOpportunity/Value_CurrencyCode")
        }
        {
            $v = "AED","AFN","ALL","AMD","ANG","AOA","ARS","AUD","AWG","AZN","BAM","BBD","BDT","BGN","BHD","BIF","BMD","BND","BOB","BOV","BRL","BSD","BTN","BWP","BYN","BZD","CAD","CDF","CHE","CHF","CHW","CLF","CLP","CNY","COP","COU","CRC","CUC","CUP","CVE","CZK","DJF","DKK","DOP","DZD","EGP","ERN","ETB","EUR","FJD","FKP","GBP","GEL","GHS","GIP","GMD","GNF","GTQ","GYD","HKD","HNL","HRK","HTG","HUF","IDR","ILS","INR","IQD","IRR","ISK","JMD","JOD","JPY","KES","KGS","KHR","KMF","KPW","KRW","KWD","KYD","KZT","LAK","LBP","LKR","LRD","LSL","LYD","MAD","MDL","MGA","MKD","MMK","MNT","MOP","MRU","MUR","MVR","MWK","MXN","MXV","MYR","MZN","NAD","NGN","NIO","NOK","NPR","NZD","OMR","PAB","PEN","PGK","PHP","PKR","PLN","PYG","QAR","RON","RSD","RUB","RWF","SAR","SBD","SCR","SDG","SEK","SGD","SHP","SLL","SOS","SRD","SSP","STN","SVC","SYP","SZL","THB","TJS","TMT","TND","TOP","TRY","TTD","TWD","TZS","UAH","UGX","USD","USN","UYI","UYU","UZS","VEF","VND","VUV","WST","XAF","XCD","XDR","XOF","XPF","XSU","XUA","YER","ZAR","ZMW","ZWL"
            break
        }

        # Amazon.PartnerCentralSelling.EngagementContextType
        {
            ($_ -eq "New-PCEngagementContext/Type") -Or
            ($_ -eq "Update-PCEngagementContext/Type")
        }
        {
            $v = "CustomerProject","Lead"
            break
        }

        # Amazon.PartnerCentralSelling.EngagementSortName
        "Get-PCEngagementList/Sort_SortBy"
        {
            $v = "CreatedDate"
            break
        }

        # Amazon.PartnerCentralSelling.Industry
        {
            ($_ -eq "Invoke-PCCreateOpportunity/Account_Industry") -Or
            ($_ -eq "Update-PCOpportunity/Account_Industry") -Or
            ($_ -eq "Invoke-PCCreateEngagementInvitation/Invitation_Payload_OpportunityInvitation_Customer_Industry") -Or
            ($_ -eq "New-PCEngagementContext/Lead_Customer_Industry") -Or
            ($_ -eq "Update-PCEngagementContext/Lead_Customer_Industry") -Or
            ($_ -eq "Invoke-PCCreateEngagementInvitation/LeadInvitation_Customer_Industry") -Or
            ($_ -eq "New-PCEngagementContext/Payload_CustomerProject_Customer_Industry") -Or
            ($_ -eq "Update-PCEngagementContext/Payload_CustomerProject_Customer_Industry")
        }
        {
            $v = "Aerospace","Agriculture","Automotive","Computers and Electronics","Consumer Goods","Education","Energy - Oil and Gas","Energy - Power and Utilities","Financial Services","Gaming","Government","Healthcare","Hospitality","Life Sciences","Manufacturing","Marketing and Advertising","Media and Entertainment","Mining","Non-Profit Organization","Other","Professional Services","Real Estate and Construction","Retail","Software and Internet","Telecommunications","Transportation and Logistics","Travel","Wholesale and Distribution"
            break
        }

        # Amazon.PartnerCentralSelling.ListTasksSortName
        {
            ($_ -eq "Get-PCEngagementByAcceptingInvitationTaskList/Sort_SortBy") -Or
            ($_ -eq "Get-PCEngagementFromOpportunityTaskList/Sort_SortBy") -Or
            ($_ -eq "Get-PCOpportunityFromEngagementTaskList/Sort_SortBy")
        }
        {
            $v = "StartTime"
            break
        }

        # Amazon.PartnerCentralSelling.MarketingSource
        {
            ($_ -eq "Invoke-PCCreateOpportunity/Marketing_Source") -Or
            ($_ -eq "Update-PCOpportunity/Marketing_Source")
        }
        {
            $v = "Marketing Activity","None"
            break
        }

        # Amazon.PartnerCentralSelling.MarketSegment
        {
            ($_ -eq "Invoke-PCCreateEngagementInvitation/Customer_MarketSegment") -Or
            ($_ -eq "New-PCEngagementContext/Customer_MarketSegment") -Or
            ($_ -eq "Update-PCEngagementContext/Customer_MarketSegment")
        }
        {
            $v = "Enterprise","Large","Medium","Micro","Small"
            break
        }

        # Amazon.PartnerCentralSelling.NationalSecurity
        {
            ($_ -eq "Invoke-PCCreateOpportunity/NationalSecurity") -Or
            ($_ -eq "Update-PCOpportunity/NationalSecurity")
        }
        {
            $v = "No","Yes"
            break
        }

        # Amazon.PartnerCentralSelling.OpportunityEngagementInvitationSortName
        "Get-PCEngagementInvitationList/Sort_SortBy"
        {
            $v = "InvitationDate"
            break
        }

        # Amazon.PartnerCentralSelling.OpportunityOrigin
        "Invoke-PCCreateOpportunity/Origin"
        {
            $v = "AWS Referral","Partner Referral"
            break
        }

        # Amazon.PartnerCentralSelling.OpportunitySortName
        "Get-PCOpportunityList/Sort_SortBy"
        {
            $v = "CreatedDate","CustomerCompanyName","Identifier","LastModifiedDate"
            break
        }

        # Amazon.PartnerCentralSelling.OpportunityType
        {
            ($_ -eq "Invoke-PCCreateOpportunity/OpportunityType") -Or
            ($_ -eq "Update-PCOpportunity/OpportunityType")
        }
        {
            $v = "Expansion","Flat Renewal","Net New Business"
            break
        }

        # Amazon.PartnerCentralSelling.ParticipantType
        "Get-PCEngagementInvitationList/ParticipantType"
        {
            $v = "RECEIVER","SENDER"
            break
        }

        # Amazon.PartnerCentralSelling.RelatedEntityType
        {
            ($_ -eq "Invoke-PCAssociateOpportunity/RelatedEntityType") -Or
            ($_ -eq "Invoke-PCDisassociateOpportunity/RelatedEntityType")
        }
        {
            $v = "AwsMarketplaceOffers","AwsMarketplaceOfferSets","AwsProducts","Solutions"
            break
        }

        # Amazon.PartnerCentralSelling.ResourceSnapshotJobStatus
        "Get-PCResourceSnapshotJobList/Status"
        {
            $v = "Running","Stopped"
            break
        }

        # Amazon.PartnerCentralSelling.ResourceType
        {
            ($_ -eq "Get-PCEngagementResourceAssociationList/ResourceType") -Or
            ($_ -eq "Get-PCResourceSnapshot/ResourceType") -Or
            ($_ -eq "Get-PCResourceSnapshotList/ResourceType") -Or
            ($_ -eq "Invoke-PCResourceSnapshot/ResourceType") -Or
            ($_ -eq "Invoke-PCResourceSnapshotJob/ResourceType")
        }
        {
            $v = "Opportunity"
            break
        }

        # Amazon.PartnerCentralSelling.RevenueModel
        {
            ($_ -eq "Invoke-PCCreateOpportunity/SoftwareRevenue_DeliveryModel") -Or
            ($_ -eq "Update-PCOpportunity/SoftwareRevenue_DeliveryModel")
        }
        {
            $v = "Contract","Pay-as-you-go","Subscription"
            break
        }

        # Amazon.PartnerCentralSelling.ReviewStatus
        {
            ($_ -eq "Invoke-PCCreateOpportunity/LifeCycle_ReviewStatus") -Or
            ($_ -eq "Update-PCOpportunity/LifeCycle_ReviewStatus")
        }
        {
            $v = "Action Required","Approved","In review","Pending Submission","Rejected","Submitted"
            break
        }

        # Amazon.PartnerCentralSelling.SalesInvolvementType
        {
            ($_ -eq "Invoke-PCStartEngagementFromOpportunityTask/AwsSubmission_InvolvementType") -Or
            ($_ -eq "Submit-PCOpportunity/InvolvementType")
        }
        {
            $v = "Co-Sell","For Visibility Only"
            break
        }

        # Amazon.PartnerCentralSelling.SolutionSortName
        "Get-PCSolutionList/Sort_SortBy"
        {
            $v = "Category","CreatedDate","Identifier","Name","Status"
            break
        }

        # Amazon.PartnerCentralSelling.SortBy
        "Get-PCResourceSnapshotJobList/Sort_SortBy"
        {
            $v = "CreatedDate"
            break
        }

        # Amazon.PartnerCentralSelling.SortOrder
        {
            ($_ -eq "Get-PCEngagementByAcceptingInvitationTaskList/Sort_SortOrder") -Or
            ($_ -eq "Get-PCEngagementFromOpportunityTaskList/Sort_SortOrder") -Or
            ($_ -eq "Get-PCEngagementInvitationList/Sort_SortOrder") -Or
            ($_ -eq "Get-PCEngagementList/Sort_SortOrder") -Or
            ($_ -eq "Get-PCOpportunityFromEngagementTaskList/Sort_SortOrder") -Or
            ($_ -eq "Get-PCOpportunityList/Sort_SortOrder") -Or
            ($_ -eq "Get-PCResourceSnapshotJobList/Sort_SortOrder") -Or
            ($_ -eq "Get-PCSolutionList/Sort_SortOrder")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.PartnerCentralSelling.Stage
        {
            ($_ -eq "Invoke-PCCreateOpportunity/LifeCycle_Stage") -Or
            ($_ -eq "Update-PCOpportunity/LifeCycle_Stage")
        }
        {
            $v = "Business Validation","Closed Lost","Committed","Launched","Prospect","Qualified","Technical Validation"
            break
        }

        # Amazon.PartnerCentralSelling.Visibility
        {
            ($_ -eq "Invoke-PCStartEngagementFromOpportunityTask/AwsSubmission_Visibility") -Or
            ($_ -eq "Submit-PCOpportunity/Visibility")
        }
        {
            $v = "Full","Limited"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$PC_map = @{
    "Account_Industry"=@("Invoke-PCCreateOpportunity","Update-PCOpportunity")
    "Address_CountryCode"=@("Invoke-PCCreateOpportunity","New-PCEngagementContext","Update-PCEngagementContext","Update-PCOpportunity")
    "AwsSubmission_InvolvementType"=@("Invoke-PCStartEngagementFromOpportunityTask")
    "AwsSubmission_Visibility"=@("Invoke-PCStartEngagementFromOpportunityTask")
    "Customer_CountryCode"=@("New-PCEngagementContext","Update-PCEngagementContext")
    "Customer_MarketSegment"=@("Invoke-PCCreateEngagementInvitation","New-PCEngagementContext","Update-PCEngagementContext")
    "Invitation_Payload_OpportunityInvitation_Customer_CountryCode"=@("Invoke-PCCreateEngagementInvitation")
    "Invitation_Payload_OpportunityInvitation_Customer_Industry"=@("Invoke-PCCreateEngagementInvitation")
    "InvolvementType"=@("Submit-PCOpportunity")
    "Lead_Customer_Industry"=@("New-PCEngagementContext","Update-PCEngagementContext")
    "LeadInvitation_Customer_CountryCode"=@("Invoke-PCCreateEngagementInvitation")
    "LeadInvitation_Customer_Industry"=@("Invoke-PCCreateEngagementInvitation")
    "LifeCycle_ClosedLostReason"=@("Invoke-PCCreateOpportunity","Update-PCOpportunity")
    "LifeCycle_ReviewStatus"=@("Invoke-PCCreateOpportunity","Update-PCOpportunity")
    "LifeCycle_Stage"=@("Invoke-PCCreateOpportunity","Update-PCOpportunity")
    "Marketing_AwsFundingUsed"=@("Invoke-PCCreateOpportunity","Update-PCOpportunity")
    "Marketing_Source"=@("Invoke-PCCreateOpportunity","Update-PCOpportunity")
    "NationalSecurity"=@("Invoke-PCCreateOpportunity","Update-PCOpportunity")
    "OpportunityType"=@("Invoke-PCCreateOpportunity","Update-PCOpportunity")
    "Origin"=@("Invoke-PCCreateOpportunity")
    "ParticipantType"=@("Get-PCEngagementInvitationList")
    "Payload_CustomerProject_Customer_Industry"=@("New-PCEngagementContext","Update-PCEngagementContext")
    "Project_AwsPartition"=@("Invoke-PCCreateOpportunity","Update-PCOpportunity")
    "Project_CompetitorName"=@("Invoke-PCCreateOpportunity","Update-PCOpportunity")
    "RelatedEntityType"=@("Invoke-PCAssociateOpportunity","Invoke-PCDisassociateOpportunity")
    "ResourceType"=@("Get-PCEngagementResourceAssociationList","Get-PCResourceSnapshot","Get-PCResourceSnapshotList","Invoke-PCResourceSnapshot","Invoke-PCResourceSnapshotJob")
    "SoftwareRevenue_DeliveryModel"=@("Invoke-PCCreateOpportunity","Update-PCOpportunity")
    "Sort_SortBy"=@("Get-PCEngagementByAcceptingInvitationTaskList","Get-PCEngagementFromOpportunityTaskList","Get-PCEngagementInvitationList","Get-PCEngagementList","Get-PCOpportunityFromEngagementTaskList","Get-PCOpportunityList","Get-PCResourceSnapshotJobList","Get-PCSolutionList")
    "Sort_SortOrder"=@("Get-PCEngagementByAcceptingInvitationTaskList","Get-PCEngagementFromOpportunityTaskList","Get-PCEngagementInvitationList","Get-PCEngagementList","Get-PCOpportunityFromEngagementTaskList","Get-PCOpportunityList","Get-PCResourceSnapshotJobList","Get-PCSolutionList")
    "Status"=@("Get-PCResourceSnapshotJobList")
    "Type"=@("New-PCEngagementContext","Update-PCEngagementContext")
    "Value_CurrencyCode"=@("Invoke-PCCreateOpportunity","Update-PCOpportunity")
    "Visibility"=@("Submit-PCOpportunity")
}

_awsArgumentCompleterRegistration $PC_Completers $PC_map

$PC_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.PC.$($commandName.Replace('-', ''))Cmdlet]"
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

$PC_SelectMap = @{
    "Select"=@("Invoke-PCAcceptEngagementInvitation",
               "Invoke-PCAssignOpportunity",
               "Invoke-PCAssociateOpportunity",
               "Invoke-PCCreateEngagement",
               "New-PCEngagementContext",
               "Invoke-PCCreateEngagementInvitation",
               "Invoke-PCCreateOpportunity",
               "Invoke-PCResourceSnapshot",
               "Invoke-PCResourceSnapshotJob",
               "Remove-PCResourceSnapshotJob",
               "Invoke-PCDisassociateOpportunity",
               "Get-PCAwsOpportunitySummary",
               "Get-PCEngagement",
               "Get-PCEngagementInvitation",
               "Get-PCOpportunity",
               "Get-PCResourceSnapshot",
               "Get-PCResourceSnapshotJob",
               "Get-PCSellingSystemSetting",
               "Get-PCEngagementByAcceptingInvitationTaskList",
               "Get-PCEngagementFromOpportunityTaskList",
               "Get-PCEngagementInvitationList",
               "Get-PCEngagementMemberList",
               "Get-PCEngagementResourceAssociationList",
               "Get-PCEngagementList",
               "Get-PCOpportunityList",
               "Get-PCOpportunityFromEngagementTaskList",
               "Get-PCResourceSnapshotJobList",
               "Get-PCResourceSnapshotList",
               "Get-PCSolutionList",
               "Get-PCResourceTag",
               "Write-PCSellingSystemSetting",
               "Invoke-PCRejectEngagementInvitation",
               "Invoke-PCStartEngagementByAcceptingInvitationTask",
               "Invoke-PCStartEngagementFromOpportunityTask",
               "Start-PCOpportunityFromEngagementTask",
               "Start-PCResourceSnapshotJob",
               "Stop-PCResourceSnapshotJob",
               "Submit-PCOpportunity",
               "Add-PCResourceTag",
               "Remove-PCResourceTag",
               "Update-PCEngagementContext",
               "Update-PCOpportunity")
}

_awsArgumentCompleterRegistration $PC_SelectCompleters $PC_SelectMap

