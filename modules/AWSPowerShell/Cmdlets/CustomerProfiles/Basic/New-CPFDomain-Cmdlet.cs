/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using System.Threading;
using Amazon.CustomerProfiles;
using Amazon.CustomerProfiles.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CPF
{
    /// <summary>
    /// Creates a domain, which is a container for all customer data, such as customer profile
    /// attributes, object types, profile keys, and encryption keys. You can create multiple
    /// domains, and each domain can have multiple third-party integrations.
    /// 
    ///  
    /// <para>
    /// Each Amazon Connect instance can be associated with only one domain. Multiple Amazon
    /// Connect instances can be associated with one domain.
    /// </para><para>
    /// Use this API or <a href="https://docs.aws.amazon.com/customerprofiles/latest/APIReference/API_UpdateDomain.html">UpdateDomain</a>
    /// to enable <a href="https://docs.aws.amazon.com/customerprofiles/latest/APIReference/API_GetMatches.html">identity
    /// resolution</a>: set <c>Matching</c> to true.
    /// </para><para>
    /// To prevent cross-service impersonation when you call this API, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/cross-service-confused-deputy-prevention.html">Cross-service
    /// confused deputy prevention</a> for sample policies that you should apply. 
    /// </para><note><para>
    /// It is not possible to associate a Customer Profiles domain with an Amazon Connect
    /// Instance directly from the API. If you would like to create a domain and associate
    /// a Customer Profiles domain, use the Amazon Connect admin website. For more information,
    /// see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/enable-customer-profiles.html#enable-customer-profiles-step1">Enable
    /// Customer Profiles</a>.
    /// </para><para>
    /// Each Amazon Connect instance can be associated with only one domain. Multiple Amazon
    /// Connect instances can be associated with one domain.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "CPFDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CustomerProfiles.Model.CreateDomainResponse")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles CreateDomain API operation.", Operation = new[] {"CreateDomain"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.CreateDomainResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.CreateDomainResponse",
        "This cmdlet returns an Amazon.CustomerProfiles.Model.CreateDomainResponse object containing multiple properties."
    )]
    public partial class NewCPFDomainCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttributeTypesSelector_Address
        /// <summary>
        /// <para>
        /// <para>The <c>Address</c> type. You can choose from <c>Address</c>, <c>BusinessAddress</c>,
        /// <c>MaillingAddress</c>, and <c>ShippingAddress</c>.</para><para>You only can use the Address type in the <c>MatchingRule</c>. For example, if you
        /// want to match profile based on <c>BusinessAddress.City</c> or <c>MaillingAddress.City</c>,
        /// you need to choose the <c>BusinessAddress</c> and the <c>MaillingAddress</c> to represent
        /// the Address type and specify the <c>Address.City</c> on the matching rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuleBasedMatching_AttributeTypesSelector_Address")]
        public System.String[] AttributeTypesSelector_Address { get; set; }
        #endregion
        
        #region Parameter AttributeTypesSelector_AttributeMatchingModel
        /// <summary>
        /// <para>
        /// <para>Configures the <c>AttributeMatchingModel</c>, you can either choose <c>ONE_TO_ONE</c>
        /// or <c>MANY_TO_MANY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuleBasedMatching_AttributeTypesSelector_AttributeMatchingModel")]
        [AWSConstantClassSource("Amazon.CustomerProfiles.AttributeMatchingModel")]
        public Amazon.CustomerProfiles.AttributeMatchingModel AttributeTypesSelector_AttributeMatchingModel { get; set; }
        #endregion
        
        #region Parameter ConflictResolution_ConflictResolvingModel
        /// <summary>
        /// <para>
        /// <para>How the auto-merging process should resolve conflicts between different profiles.</para><ul><li><para><c>RECENCY</c>: Uses the data that was most recently updated.</para></li><li><para><c>SOURCE</c>: Uses the data from a specific source. For example, if a company has
        /// been aquired or two departments have merged, data from the specified source is used.
        /// If two duplicate profiles are from the same source, then <c>RECENCY</c> is used again.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Matching_AutoMerging_ConflictResolution_ConflictResolvingModel")]
        [AWSConstantClassSource("Amazon.CustomerProfiles.ConflictResolvingModel")]
        public Amazon.CustomerProfiles.ConflictResolvingModel ConflictResolution_ConflictResolvingModel { get; set; }
        #endregion
        
        #region Parameter RuleBasedMatching_ConflictResolution_ConflictResolvingModel
        /// <summary>
        /// <para>
        /// <para>How the auto-merging process should resolve conflicts between different profiles.</para><ul><li><para><c>RECENCY</c>: Uses the data that was most recently updated.</para></li><li><para><c>SOURCE</c>: Uses the data from a specific source. For example, if a company has
        /// been aquired or two departments have merged, data from the specified source is used.
        /// If two duplicate profiles are from the same source, then <c>RECENCY</c> is used again.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CustomerProfiles.ConflictResolvingModel")]
        public Amazon.CustomerProfiles.ConflictResolvingModel RuleBasedMatching_ConflictResolution_ConflictResolvingModel { get; set; }
        #endregion
        
        #region Parameter JobSchedule_DayOfTheWeek
        /// <summary>
        /// <para>
        /// <para>The day when the Identity Resolution Job should run every week.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Matching_JobSchedule_DayOfTheWeek")]
        [AWSConstantClassSource("Amazon.CustomerProfiles.JobScheduleDayOfTheWeek")]
        public Amazon.CustomerProfiles.JobScheduleDayOfTheWeek JobSchedule_DayOfTheWeek { get; set; }
        #endregion
        
        #region Parameter DeadLetterQueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the SQS dead letter queue, which is used for reporting errors associated
        /// with ingesting data from third party applications. You must set up a policy on the
        /// DeadLetterQueue for the SendMessage operation to enable Amazon Connect Customer Profiles
        /// to send messages to the DeadLetterQueue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeadLetterQueueUrl { get; set; }
        #endregion
        
        #region Parameter DefaultEncryptionKey
        /// <summary>
        /// <para>
        /// <para>The default encryption key, which is an AWS managed key, is used when no specific
        /// type of encryption key is specified. It is used to encrypt all data before it is placed
        /// in permanent or semi-permanent storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultEncryptionKey { get; set; }
        #endregion
        
        #region Parameter DefaultExpirationDay
        /// <summary>
        /// <para>
        /// <para>The default number of days until the data within the domain expires.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DefaultExpirationDays")]
        public System.Int32? DefaultExpirationDay { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The unique name of the domain.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter AttributeTypesSelector_EmailAddress
        /// <summary>
        /// <para>
        /// <para>The <c>Email</c> type. You can choose from <c>EmailAddress</c>, <c>BusinessEmailAddress</c>
        /// and <c>PersonalEmailAddress</c>.</para><para>You only can use the <c>EmailAddress</c> type in the <c>MatchingRule</c>. For example,
        /// if you want to match profile based on <c>PersonalEmailAddress</c> or <c>BusinessEmailAddress</c>,
        /// you need to choose the <c>PersonalEmailAddress</c> and the <c>BusinessEmailAddress</c>
        /// to represent the <c>EmailAddress</c> type and only specify the <c>EmailAddress</c>
        /// on the matching rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuleBasedMatching_AttributeTypesSelector_EmailAddress")]
        public System.String[] AttributeTypesSelector_EmailAddress { get; set; }
        #endregion
        
        #region Parameter AutoMerging_Enabled
        /// <summary>
        /// <para>
        /// <para>The flag that enables the auto-merging of duplicate profiles.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Matching_AutoMerging_Enabled")]
        public System.Boolean? AutoMerging_Enabled { get; set; }
        #endregion
        
        #region Parameter Matching_Enabled
        /// <summary>
        /// <para>
        /// <para>The flag that enables the matching process of duplicate profiles.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Matching_Enabled { get; set; }
        #endregion
        
        #region Parameter RuleBasedMatching_Enabled
        /// <summary>
        /// <para>
        /// <para>The flag that enables the rule-based matching process of duplicate profiles.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RuleBasedMatching_Enabled { get; set; }
        #endregion
        
        #region Parameter Consolidation_MatchingAttributesList
        /// <summary>
        /// <para>
        /// <para>A list of matching criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Matching_AutoMerging_Consolidation_MatchingAttributesList")]
        public System.String[][] Consolidation_MatchingAttributesList { get; set; }
        #endregion
        
        #region Parameter RuleBasedMatching_MatchingRule
        /// <summary>
        /// <para>
        /// <para>Configures how the rule-based matching process should match profiles. You can have
        /// up to 15 <c>MatchingRule</c> in the <c>MatchingRules</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuleBasedMatching_MatchingRules")]
        public Amazon.CustomerProfiles.Model.MatchingRule[] RuleBasedMatching_MatchingRule { get; set; }
        #endregion
        
        #region Parameter RuleBasedMatching_MaxAllowedRuleLevelForMatching
        /// <summary>
        /// <para>
        /// <para>Indicates the maximum allowed rule level.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RuleBasedMatching_MaxAllowedRuleLevelForMatching { get; set; }
        #endregion
        
        #region Parameter RuleBasedMatching_MaxAllowedRuleLevelForMerging
        /// <summary>
        /// <para>
        /// <para><a href="https://docs.aws.amazon.com/customerprofiles/latest/APIReference/API_MatchingRule.html">MatchingRule</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RuleBasedMatching_MaxAllowedRuleLevelForMerging { get; set; }
        #endregion
        
        #region Parameter AutoMerging_MinAllowedConfidenceScoreForMerging
        /// <summary>
        /// <para>
        /// <para>A number between 0 and 1 that represents the minimum confidence score required for
        /// profiles within a matching group to be merged during the auto-merge process. A higher
        /// score means higher similarity required to merge profiles. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Matching_AutoMerging_MinAllowedConfidenceScoreForMerging")]
        public System.Double? AutoMerging_MinAllowedConfidenceScoreForMerging { get; set; }
        #endregion
        
        #region Parameter AttributeTypesSelector_PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The <c>PhoneNumber</c> type. You can choose from <c>PhoneNumber</c>, <c>HomePhoneNumber</c>,
        /// and <c>MobilePhoneNumber</c>.</para><para>You only can use the <c>PhoneNumber</c> type in the <c>MatchingRule</c>. For example,
        /// if you want to match a profile based on <c>Phone</c> or <c>HomePhone</c>, you need
        /// to choose the <c>Phone</c> and the <c>HomePhone</c> to represent the <c>PhoneNumber</c>
        /// type and only specify the <c>PhoneNumber</c> on the matching rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuleBasedMatching_AttributeTypesSelector_PhoneNumber")]
        public System.String[] AttributeTypesSelector_PhoneNumber { get; set; }
        #endregion
        
        #region Parameter S3Exporting_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket where Identity Resolution Jobs write result files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Matching_ExportingConfig_S3Exporting_S3BucketName")]
        public System.String S3Exporting_S3BucketName { get; set; }
        #endregion
        
        #region Parameter RuleBasedMatching_ExportingConfig_S3Exporting_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket where Identity Resolution Jobs write result files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuleBasedMatching_ExportingConfig_S3Exporting_S3BucketName { get; set; }
        #endregion
        
        #region Parameter S3Exporting_S3KeyName
        /// <summary>
        /// <para>
        /// <para>The S3 key name of the location where Identity Resolution Jobs write result files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Matching_ExportingConfig_S3Exporting_S3KeyName")]
        public System.String S3Exporting_S3KeyName { get; set; }
        #endregion
        
        #region Parameter RuleBasedMatching_ExportingConfig_S3Exporting_S3KeyName
        /// <summary>
        /// <para>
        /// <para>The S3 key name of the location where Identity Resolution Jobs write result files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuleBasedMatching_ExportingConfig_S3Exporting_S3KeyName { get; set; }
        #endregion
        
        #region Parameter ConflictResolution_SourceName
        /// <summary>
        /// <para>
        /// <para>The <c>ObjectType</c> name that is used to resolve profile merging conflicts when
        /// choosing <c>SOURCE</c> as the <c>ConflictResolvingModel</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Matching_AutoMerging_ConflictResolution_SourceName")]
        public System.String ConflictResolution_SourceName { get; set; }
        #endregion
        
        #region Parameter RuleBasedMatching_ConflictResolution_SourceName
        /// <summary>
        /// <para>
        /// <para>The <c>ObjectType</c> name that is used to resolve profile merging conflicts when
        /// choosing <c>SOURCE</c> as the <c>ConflictResolvingModel</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuleBasedMatching_ConflictResolution_SourceName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter JobSchedule_Time
        /// <summary>
        /// <para>
        /// <para>The time when the Identity Resolution Job should run every week.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Matching_JobSchedule_Time")]
        public System.String JobSchedule_Time { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.CreateDomainResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.CreateDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CPFDomain (CreateDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.CreateDomainResponse, NewCPFDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeadLetterQueueUrl = this.DeadLetterQueueUrl;
            context.DefaultEncryptionKey = this.DefaultEncryptionKey;
            context.DefaultExpirationDay = this.DefaultExpirationDay;
            #if MODULAR
            if (this.DefaultExpirationDay == null && ParameterWasBound(nameof(this.DefaultExpirationDay)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultExpirationDay which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConflictResolution_ConflictResolvingModel = this.ConflictResolution_ConflictResolvingModel;
            context.ConflictResolution_SourceName = this.ConflictResolution_SourceName;
            if (this.Consolidation_MatchingAttributesList != null)
            {
                context.Consolidation_MatchingAttributesList = new List<List<System.String>>();
                foreach (var innerList in this.Consolidation_MatchingAttributesList)
                {
                    context.Consolidation_MatchingAttributesList.Add(new List<System.String>(innerList));
                }
            }
            context.AutoMerging_Enabled = this.AutoMerging_Enabled;
            context.AutoMerging_MinAllowedConfidenceScoreForMerging = this.AutoMerging_MinAllowedConfidenceScoreForMerging;
            context.Matching_Enabled = this.Matching_Enabled;
            context.S3Exporting_S3BucketName = this.S3Exporting_S3BucketName;
            context.S3Exporting_S3KeyName = this.S3Exporting_S3KeyName;
            context.JobSchedule_DayOfTheWeek = this.JobSchedule_DayOfTheWeek;
            context.JobSchedule_Time = this.JobSchedule_Time;
            if (this.AttributeTypesSelector_Address != null)
            {
                context.AttributeTypesSelector_Address = new List<System.String>(this.AttributeTypesSelector_Address);
            }
            context.AttributeTypesSelector_AttributeMatchingModel = this.AttributeTypesSelector_AttributeMatchingModel;
            if (this.AttributeTypesSelector_EmailAddress != null)
            {
                context.AttributeTypesSelector_EmailAddress = new List<System.String>(this.AttributeTypesSelector_EmailAddress);
            }
            if (this.AttributeTypesSelector_PhoneNumber != null)
            {
                context.AttributeTypesSelector_PhoneNumber = new List<System.String>(this.AttributeTypesSelector_PhoneNumber);
            }
            context.RuleBasedMatching_ConflictResolution_ConflictResolvingModel = this.RuleBasedMatching_ConflictResolution_ConflictResolvingModel;
            context.RuleBasedMatching_ConflictResolution_SourceName = this.RuleBasedMatching_ConflictResolution_SourceName;
            context.RuleBasedMatching_Enabled = this.RuleBasedMatching_Enabled;
            context.RuleBasedMatching_ExportingConfig_S3Exporting_S3BucketName = this.RuleBasedMatching_ExportingConfig_S3Exporting_S3BucketName;
            context.RuleBasedMatching_ExportingConfig_S3Exporting_S3KeyName = this.RuleBasedMatching_ExportingConfig_S3Exporting_S3KeyName;
            if (this.RuleBasedMatching_MatchingRule != null)
            {
                context.RuleBasedMatching_MatchingRule = new List<Amazon.CustomerProfiles.Model.MatchingRule>(this.RuleBasedMatching_MatchingRule);
            }
            context.RuleBasedMatching_MaxAllowedRuleLevelForMatching = this.RuleBasedMatching_MaxAllowedRuleLevelForMatching;
            context.RuleBasedMatching_MaxAllowedRuleLevelForMerging = this.RuleBasedMatching_MaxAllowedRuleLevelForMerging;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CustomerProfiles.Model.CreateDomainRequest();
            
            if (cmdletContext.DeadLetterQueueUrl != null)
            {
                request.DeadLetterQueueUrl = cmdletContext.DeadLetterQueueUrl;
            }
            if (cmdletContext.DefaultEncryptionKey != null)
            {
                request.DefaultEncryptionKey = cmdletContext.DefaultEncryptionKey;
            }
            if (cmdletContext.DefaultExpirationDay != null)
            {
                request.DefaultExpirationDays = cmdletContext.DefaultExpirationDay.Value;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate Matching
            var requestMatchingIsNull = true;
            request.Matching = new Amazon.CustomerProfiles.Model.MatchingRequest();
            System.Boolean? requestMatching_matching_Enabled = null;
            if (cmdletContext.Matching_Enabled != null)
            {
                requestMatching_matching_Enabled = cmdletContext.Matching_Enabled.Value;
            }
            if (requestMatching_matching_Enabled != null)
            {
                request.Matching.Enabled = requestMatching_matching_Enabled.Value;
                requestMatchingIsNull = false;
            }
            Amazon.CustomerProfiles.Model.ExportingConfig requestMatching_matching_ExportingConfig = null;
            
             // populate ExportingConfig
            var requestMatching_matching_ExportingConfigIsNull = true;
            requestMatching_matching_ExportingConfig = new Amazon.CustomerProfiles.Model.ExportingConfig();
            Amazon.CustomerProfiles.Model.S3ExportingConfig requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting = null;
            
             // populate S3Exporting
            var requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3ExportingIsNull = true;
            requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting = new Amazon.CustomerProfiles.Model.S3ExportingConfig();
            System.String requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting_s3Exporting_S3BucketName = null;
            if (cmdletContext.S3Exporting_S3BucketName != null)
            {
                requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting_s3Exporting_S3BucketName = cmdletContext.S3Exporting_S3BucketName;
            }
            if (requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting_s3Exporting_S3BucketName != null)
            {
                requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting.S3BucketName = requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting_s3Exporting_S3BucketName;
                requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3ExportingIsNull = false;
            }
            System.String requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting_s3Exporting_S3KeyName = null;
            if (cmdletContext.S3Exporting_S3KeyName != null)
            {
                requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting_s3Exporting_S3KeyName = cmdletContext.S3Exporting_S3KeyName;
            }
            if (requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting_s3Exporting_S3KeyName != null)
            {
                requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting.S3KeyName = requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting_s3Exporting_S3KeyName;
                requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3ExportingIsNull = false;
            }
             // determine if requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting should be set to null
            if (requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3ExportingIsNull)
            {
                requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting = null;
            }
            if (requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting != null)
            {
                requestMatching_matching_ExportingConfig.S3Exporting = requestMatching_matching_ExportingConfig_matching_ExportingConfig_S3Exporting;
                requestMatching_matching_ExportingConfigIsNull = false;
            }
             // determine if requestMatching_matching_ExportingConfig should be set to null
            if (requestMatching_matching_ExportingConfigIsNull)
            {
                requestMatching_matching_ExportingConfig = null;
            }
            if (requestMatching_matching_ExportingConfig != null)
            {
                request.Matching.ExportingConfig = requestMatching_matching_ExportingConfig;
                requestMatchingIsNull = false;
            }
            Amazon.CustomerProfiles.Model.JobSchedule requestMatching_matching_JobSchedule = null;
            
             // populate JobSchedule
            var requestMatching_matching_JobScheduleIsNull = true;
            requestMatching_matching_JobSchedule = new Amazon.CustomerProfiles.Model.JobSchedule();
            Amazon.CustomerProfiles.JobScheduleDayOfTheWeek requestMatching_matching_JobSchedule_jobSchedule_DayOfTheWeek = null;
            if (cmdletContext.JobSchedule_DayOfTheWeek != null)
            {
                requestMatching_matching_JobSchedule_jobSchedule_DayOfTheWeek = cmdletContext.JobSchedule_DayOfTheWeek;
            }
            if (requestMatching_matching_JobSchedule_jobSchedule_DayOfTheWeek != null)
            {
                requestMatching_matching_JobSchedule.DayOfTheWeek = requestMatching_matching_JobSchedule_jobSchedule_DayOfTheWeek;
                requestMatching_matching_JobScheduleIsNull = false;
            }
            System.String requestMatching_matching_JobSchedule_jobSchedule_Time = null;
            if (cmdletContext.JobSchedule_Time != null)
            {
                requestMatching_matching_JobSchedule_jobSchedule_Time = cmdletContext.JobSchedule_Time;
            }
            if (requestMatching_matching_JobSchedule_jobSchedule_Time != null)
            {
                requestMatching_matching_JobSchedule.Time = requestMatching_matching_JobSchedule_jobSchedule_Time;
                requestMatching_matching_JobScheduleIsNull = false;
            }
             // determine if requestMatching_matching_JobSchedule should be set to null
            if (requestMatching_matching_JobScheduleIsNull)
            {
                requestMatching_matching_JobSchedule = null;
            }
            if (requestMatching_matching_JobSchedule != null)
            {
                request.Matching.JobSchedule = requestMatching_matching_JobSchedule;
                requestMatchingIsNull = false;
            }
            Amazon.CustomerProfiles.Model.AutoMerging requestMatching_matching_AutoMerging = null;
            
             // populate AutoMerging
            var requestMatching_matching_AutoMergingIsNull = true;
            requestMatching_matching_AutoMerging = new Amazon.CustomerProfiles.Model.AutoMerging();
            System.Boolean? requestMatching_matching_AutoMerging_autoMerging_Enabled = null;
            if (cmdletContext.AutoMerging_Enabled != null)
            {
                requestMatching_matching_AutoMerging_autoMerging_Enabled = cmdletContext.AutoMerging_Enabled.Value;
            }
            if (requestMatching_matching_AutoMerging_autoMerging_Enabled != null)
            {
                requestMatching_matching_AutoMerging.Enabled = requestMatching_matching_AutoMerging_autoMerging_Enabled.Value;
                requestMatching_matching_AutoMergingIsNull = false;
            }
            System.Double? requestMatching_matching_AutoMerging_autoMerging_MinAllowedConfidenceScoreForMerging = null;
            if (cmdletContext.AutoMerging_MinAllowedConfidenceScoreForMerging != null)
            {
                requestMatching_matching_AutoMerging_autoMerging_MinAllowedConfidenceScoreForMerging = cmdletContext.AutoMerging_MinAllowedConfidenceScoreForMerging.Value;
            }
            if (requestMatching_matching_AutoMerging_autoMerging_MinAllowedConfidenceScoreForMerging != null)
            {
                requestMatching_matching_AutoMerging.MinAllowedConfidenceScoreForMerging = requestMatching_matching_AutoMerging_autoMerging_MinAllowedConfidenceScoreForMerging.Value;
                requestMatching_matching_AutoMergingIsNull = false;
            }
            Amazon.CustomerProfiles.Model.Consolidation requestMatching_matching_AutoMerging_matching_AutoMerging_Consolidation = null;
            
             // populate Consolidation
            var requestMatching_matching_AutoMerging_matching_AutoMerging_ConsolidationIsNull = true;
            requestMatching_matching_AutoMerging_matching_AutoMerging_Consolidation = new Amazon.CustomerProfiles.Model.Consolidation();
            List<List<System.String>> requestMatching_matching_AutoMerging_matching_AutoMerging_Consolidation_consolidation_MatchingAttributesList = null;
            if (cmdletContext.Consolidation_MatchingAttributesList != null)
            {
                requestMatching_matching_AutoMerging_matching_AutoMerging_Consolidation_consolidation_MatchingAttributesList = cmdletContext.Consolidation_MatchingAttributesList;
            }
            if (requestMatching_matching_AutoMerging_matching_AutoMerging_Consolidation_consolidation_MatchingAttributesList != null)
            {
                requestMatching_matching_AutoMerging_matching_AutoMerging_Consolidation.MatchingAttributesList = requestMatching_matching_AutoMerging_matching_AutoMerging_Consolidation_consolidation_MatchingAttributesList;
                requestMatching_matching_AutoMerging_matching_AutoMerging_ConsolidationIsNull = false;
            }
             // determine if requestMatching_matching_AutoMerging_matching_AutoMerging_Consolidation should be set to null
            if (requestMatching_matching_AutoMerging_matching_AutoMerging_ConsolidationIsNull)
            {
                requestMatching_matching_AutoMerging_matching_AutoMerging_Consolidation = null;
            }
            if (requestMatching_matching_AutoMerging_matching_AutoMerging_Consolidation != null)
            {
                requestMatching_matching_AutoMerging.Consolidation = requestMatching_matching_AutoMerging_matching_AutoMerging_Consolidation;
                requestMatching_matching_AutoMergingIsNull = false;
            }
            Amazon.CustomerProfiles.Model.ConflictResolution requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution = null;
            
             // populate ConflictResolution
            var requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolutionIsNull = true;
            requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution = new Amazon.CustomerProfiles.Model.ConflictResolution();
            Amazon.CustomerProfiles.ConflictResolvingModel requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution_conflictResolution_ConflictResolvingModel = null;
            if (cmdletContext.ConflictResolution_ConflictResolvingModel != null)
            {
                requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution_conflictResolution_ConflictResolvingModel = cmdletContext.ConflictResolution_ConflictResolvingModel;
            }
            if (requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution_conflictResolution_ConflictResolvingModel != null)
            {
                requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution.ConflictResolvingModel = requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution_conflictResolution_ConflictResolvingModel;
                requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolutionIsNull = false;
            }
            System.String requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution_conflictResolution_SourceName = null;
            if (cmdletContext.ConflictResolution_SourceName != null)
            {
                requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution_conflictResolution_SourceName = cmdletContext.ConflictResolution_SourceName;
            }
            if (requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution_conflictResolution_SourceName != null)
            {
                requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution.SourceName = requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution_conflictResolution_SourceName;
                requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolutionIsNull = false;
            }
             // determine if requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution should be set to null
            if (requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolutionIsNull)
            {
                requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution = null;
            }
            if (requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution != null)
            {
                requestMatching_matching_AutoMerging.ConflictResolution = requestMatching_matching_AutoMerging_matching_AutoMerging_ConflictResolution;
                requestMatching_matching_AutoMergingIsNull = false;
            }
             // determine if requestMatching_matching_AutoMerging should be set to null
            if (requestMatching_matching_AutoMergingIsNull)
            {
                requestMatching_matching_AutoMerging = null;
            }
            if (requestMatching_matching_AutoMerging != null)
            {
                request.Matching.AutoMerging = requestMatching_matching_AutoMerging;
                requestMatchingIsNull = false;
            }
             // determine if request.Matching should be set to null
            if (requestMatchingIsNull)
            {
                request.Matching = null;
            }
            
             // populate RuleBasedMatching
            var requestRuleBasedMatchingIsNull = true;
            request.RuleBasedMatching = new Amazon.CustomerProfiles.Model.RuleBasedMatchingRequest();
            System.Boolean? requestRuleBasedMatching_ruleBasedMatching_Enabled = null;
            if (cmdletContext.RuleBasedMatching_Enabled != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_Enabled = cmdletContext.RuleBasedMatching_Enabled.Value;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_Enabled != null)
            {
                request.RuleBasedMatching.Enabled = requestRuleBasedMatching_ruleBasedMatching_Enabled.Value;
                requestRuleBasedMatchingIsNull = false;
            }
            List<Amazon.CustomerProfiles.Model.MatchingRule> requestRuleBasedMatching_ruleBasedMatching_MatchingRule = null;
            if (cmdletContext.RuleBasedMatching_MatchingRule != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_MatchingRule = cmdletContext.RuleBasedMatching_MatchingRule;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_MatchingRule != null)
            {
                request.RuleBasedMatching.MatchingRules = requestRuleBasedMatching_ruleBasedMatching_MatchingRule;
                requestRuleBasedMatchingIsNull = false;
            }
            System.Int32? requestRuleBasedMatching_ruleBasedMatching_MaxAllowedRuleLevelForMatching = null;
            if (cmdletContext.RuleBasedMatching_MaxAllowedRuleLevelForMatching != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_MaxAllowedRuleLevelForMatching = cmdletContext.RuleBasedMatching_MaxAllowedRuleLevelForMatching.Value;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_MaxAllowedRuleLevelForMatching != null)
            {
                request.RuleBasedMatching.MaxAllowedRuleLevelForMatching = requestRuleBasedMatching_ruleBasedMatching_MaxAllowedRuleLevelForMatching.Value;
                requestRuleBasedMatchingIsNull = false;
            }
            System.Int32? requestRuleBasedMatching_ruleBasedMatching_MaxAllowedRuleLevelForMerging = null;
            if (cmdletContext.RuleBasedMatching_MaxAllowedRuleLevelForMerging != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_MaxAllowedRuleLevelForMerging = cmdletContext.RuleBasedMatching_MaxAllowedRuleLevelForMerging.Value;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_MaxAllowedRuleLevelForMerging != null)
            {
                request.RuleBasedMatching.MaxAllowedRuleLevelForMerging = requestRuleBasedMatching_ruleBasedMatching_MaxAllowedRuleLevelForMerging.Value;
                requestRuleBasedMatchingIsNull = false;
            }
            Amazon.CustomerProfiles.Model.ExportingConfig requestRuleBasedMatching_ruleBasedMatching_ExportingConfig = null;
            
             // populate ExportingConfig
            var requestRuleBasedMatching_ruleBasedMatching_ExportingConfigIsNull = true;
            requestRuleBasedMatching_ruleBasedMatching_ExportingConfig = new Amazon.CustomerProfiles.Model.ExportingConfig();
            Amazon.CustomerProfiles.Model.S3ExportingConfig requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting = null;
            
             // populate S3Exporting
            var requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3ExportingIsNull = true;
            requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting = new Amazon.CustomerProfiles.Model.S3ExportingConfig();
            System.String requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting_ruleBasedMatching_ExportingConfig_S3Exporting_S3BucketName = null;
            if (cmdletContext.RuleBasedMatching_ExportingConfig_S3Exporting_S3BucketName != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting_ruleBasedMatching_ExportingConfig_S3Exporting_S3BucketName = cmdletContext.RuleBasedMatching_ExportingConfig_S3Exporting_S3BucketName;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting_ruleBasedMatching_ExportingConfig_S3Exporting_S3BucketName != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting.S3BucketName = requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting_ruleBasedMatching_ExportingConfig_S3Exporting_S3BucketName;
                requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3ExportingIsNull = false;
            }
            System.String requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting_ruleBasedMatching_ExportingConfig_S3Exporting_S3KeyName = null;
            if (cmdletContext.RuleBasedMatching_ExportingConfig_S3Exporting_S3KeyName != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting_ruleBasedMatching_ExportingConfig_S3Exporting_S3KeyName = cmdletContext.RuleBasedMatching_ExportingConfig_S3Exporting_S3KeyName;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting_ruleBasedMatching_ExportingConfig_S3Exporting_S3KeyName != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting.S3KeyName = requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting_ruleBasedMatching_ExportingConfig_S3Exporting_S3KeyName;
                requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3ExportingIsNull = false;
            }
             // determine if requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting should be set to null
            if (requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3ExportingIsNull)
            {
                requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting = null;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_ExportingConfig.S3Exporting = requestRuleBasedMatching_ruleBasedMatching_ExportingConfig_ruleBasedMatching_ExportingConfig_S3Exporting;
                requestRuleBasedMatching_ruleBasedMatching_ExportingConfigIsNull = false;
            }
             // determine if requestRuleBasedMatching_ruleBasedMatching_ExportingConfig should be set to null
            if (requestRuleBasedMatching_ruleBasedMatching_ExportingConfigIsNull)
            {
                requestRuleBasedMatching_ruleBasedMatching_ExportingConfig = null;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_ExportingConfig != null)
            {
                request.RuleBasedMatching.ExportingConfig = requestRuleBasedMatching_ruleBasedMatching_ExportingConfig;
                requestRuleBasedMatchingIsNull = false;
            }
            Amazon.CustomerProfiles.Model.ConflictResolution requestRuleBasedMatching_ruleBasedMatching_ConflictResolution = null;
            
             // populate ConflictResolution
            var requestRuleBasedMatching_ruleBasedMatching_ConflictResolutionIsNull = true;
            requestRuleBasedMatching_ruleBasedMatching_ConflictResolution = new Amazon.CustomerProfiles.Model.ConflictResolution();
            Amazon.CustomerProfiles.ConflictResolvingModel requestRuleBasedMatching_ruleBasedMatching_ConflictResolution_ruleBasedMatching_ConflictResolution_ConflictResolvingModel = null;
            if (cmdletContext.RuleBasedMatching_ConflictResolution_ConflictResolvingModel != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_ConflictResolution_ruleBasedMatching_ConflictResolution_ConflictResolvingModel = cmdletContext.RuleBasedMatching_ConflictResolution_ConflictResolvingModel;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_ConflictResolution_ruleBasedMatching_ConflictResolution_ConflictResolvingModel != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_ConflictResolution.ConflictResolvingModel = requestRuleBasedMatching_ruleBasedMatching_ConflictResolution_ruleBasedMatching_ConflictResolution_ConflictResolvingModel;
                requestRuleBasedMatching_ruleBasedMatching_ConflictResolutionIsNull = false;
            }
            System.String requestRuleBasedMatching_ruleBasedMatching_ConflictResolution_ruleBasedMatching_ConflictResolution_SourceName = null;
            if (cmdletContext.RuleBasedMatching_ConflictResolution_SourceName != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_ConflictResolution_ruleBasedMatching_ConflictResolution_SourceName = cmdletContext.RuleBasedMatching_ConflictResolution_SourceName;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_ConflictResolution_ruleBasedMatching_ConflictResolution_SourceName != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_ConflictResolution.SourceName = requestRuleBasedMatching_ruleBasedMatching_ConflictResolution_ruleBasedMatching_ConflictResolution_SourceName;
                requestRuleBasedMatching_ruleBasedMatching_ConflictResolutionIsNull = false;
            }
             // determine if requestRuleBasedMatching_ruleBasedMatching_ConflictResolution should be set to null
            if (requestRuleBasedMatching_ruleBasedMatching_ConflictResolutionIsNull)
            {
                requestRuleBasedMatching_ruleBasedMatching_ConflictResolution = null;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_ConflictResolution != null)
            {
                request.RuleBasedMatching.ConflictResolution = requestRuleBasedMatching_ruleBasedMatching_ConflictResolution;
                requestRuleBasedMatchingIsNull = false;
            }
            Amazon.CustomerProfiles.Model.AttributeTypesSelector requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector = null;
            
             // populate AttributeTypesSelector
            var requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelectorIsNull = true;
            requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector = new Amazon.CustomerProfiles.Model.AttributeTypesSelector();
            List<System.String> requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_Address = null;
            if (cmdletContext.AttributeTypesSelector_Address != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_Address = cmdletContext.AttributeTypesSelector_Address;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_Address != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector.Address = requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_Address;
                requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelectorIsNull = false;
            }
            Amazon.CustomerProfiles.AttributeMatchingModel requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_AttributeMatchingModel = null;
            if (cmdletContext.AttributeTypesSelector_AttributeMatchingModel != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_AttributeMatchingModel = cmdletContext.AttributeTypesSelector_AttributeMatchingModel;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_AttributeMatchingModel != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector.AttributeMatchingModel = requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_AttributeMatchingModel;
                requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelectorIsNull = false;
            }
            List<System.String> requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_EmailAddress = null;
            if (cmdletContext.AttributeTypesSelector_EmailAddress != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_EmailAddress = cmdletContext.AttributeTypesSelector_EmailAddress;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_EmailAddress != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector.EmailAddress = requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_EmailAddress;
                requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelectorIsNull = false;
            }
            List<System.String> requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_PhoneNumber = null;
            if (cmdletContext.AttributeTypesSelector_PhoneNumber != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_PhoneNumber = cmdletContext.AttributeTypesSelector_PhoneNumber;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_PhoneNumber != null)
            {
                requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector.PhoneNumber = requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector_attributeTypesSelector_PhoneNumber;
                requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelectorIsNull = false;
            }
             // determine if requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector should be set to null
            if (requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelectorIsNull)
            {
                requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector = null;
            }
            if (requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector != null)
            {
                request.RuleBasedMatching.AttributeTypesSelector = requestRuleBasedMatching_ruleBasedMatching_AttributeTypesSelector;
                requestRuleBasedMatchingIsNull = false;
            }
             // determine if request.RuleBasedMatching should be set to null
            if (requestRuleBasedMatchingIsNull)
            {
                request.RuleBasedMatching = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CustomerProfiles.Model.CreateDomainResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.CreateDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "CreateDomain");
            try
            {
                return client.CreateDomainAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String DeadLetterQueueUrl { get; set; }
            public System.String DefaultEncryptionKey { get; set; }
            public System.Int32? DefaultExpirationDay { get; set; }
            public System.String DomainName { get; set; }
            public Amazon.CustomerProfiles.ConflictResolvingModel ConflictResolution_ConflictResolvingModel { get; set; }
            public System.String ConflictResolution_SourceName { get; set; }
            public List<List<System.String>> Consolidation_MatchingAttributesList { get; set; }
            public System.Boolean? AutoMerging_Enabled { get; set; }
            public System.Double? AutoMerging_MinAllowedConfidenceScoreForMerging { get; set; }
            public System.Boolean? Matching_Enabled { get; set; }
            public System.String S3Exporting_S3BucketName { get; set; }
            public System.String S3Exporting_S3KeyName { get; set; }
            public Amazon.CustomerProfiles.JobScheduleDayOfTheWeek JobSchedule_DayOfTheWeek { get; set; }
            public System.String JobSchedule_Time { get; set; }
            public List<System.String> AttributeTypesSelector_Address { get; set; }
            public Amazon.CustomerProfiles.AttributeMatchingModel AttributeTypesSelector_AttributeMatchingModel { get; set; }
            public List<System.String> AttributeTypesSelector_EmailAddress { get; set; }
            public List<System.String> AttributeTypesSelector_PhoneNumber { get; set; }
            public Amazon.CustomerProfiles.ConflictResolvingModel RuleBasedMatching_ConflictResolution_ConflictResolvingModel { get; set; }
            public System.String RuleBasedMatching_ConflictResolution_SourceName { get; set; }
            public System.Boolean? RuleBasedMatching_Enabled { get; set; }
            public System.String RuleBasedMatching_ExportingConfig_S3Exporting_S3BucketName { get; set; }
            public System.String RuleBasedMatching_ExportingConfig_S3Exporting_S3KeyName { get; set; }
            public List<Amazon.CustomerProfiles.Model.MatchingRule> RuleBasedMatching_MatchingRule { get; set; }
            public System.Int32? RuleBasedMatching_MaxAllowedRuleLevelForMatching { get; set; }
            public System.Int32? RuleBasedMatching_MaxAllowedRuleLevelForMerging { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.CreateDomainResponse, NewCPFDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
