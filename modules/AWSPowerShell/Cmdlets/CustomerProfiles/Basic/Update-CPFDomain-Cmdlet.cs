/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CustomerProfiles;
using Amazon.CustomerProfiles.Model;

namespace Amazon.PowerShell.Cmdlets.CPF
{
    /// <summary>
    /// Updates the properties of a domain, including creating or selecting a dead letter
    /// queue or an encryption key.
    /// 
    ///  
    /// <para>
    /// After a domain is created, the name can’t be changed.
    /// </para><para>
    /// Use this API or <a href="https://docs.aws.amazon.com/customerprofiles/latest/APIReference/API_CreateDomain.html">CreateDomain</a>
    /// to enable <a href="https://docs.aws.amazon.com/customerprofiles/latest/APIReference/API_GetMatches.html">identity
    /// resolution</a>: set <code>Matching</code> to true. 
    /// </para><para>
    /// To prevent cross-service impersonation when you call this API, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/cross-service-confused-deputy-prevention.html">Cross-service
    /// confused deputy prevention</a> for sample policies that you should apply. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CPFDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CustomerProfiles.Model.UpdateDomainResponse")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles UpdateDomain API operation.", Operation = new[] {"UpdateDomain"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.UpdateDomainResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.UpdateDomainResponse",
        "This cmdlet returns an Amazon.CustomerProfiles.Model.UpdateDomainResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCPFDomainCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        #region Parameter ConflictResolution_ConflictResolvingModel
        /// <summary>
        /// <para>
        /// <para>How the auto-merging process should resolve conflicts between different profiles.</para><ul><li><para><code>RECENCY</code>: Uses the data that was most recently updated.</para></li><li><para><code>SOURCE</code>: Uses the data from a specific source. For example, if a company
        /// has been aquired or two departments have merged, data from the specified source is
        /// used. If two duplicate profiles are from the same source, then <code>RECENCY</code>
        /// is used again.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Matching_AutoMerging_ConflictResolution_ConflictResolvingModel")]
        [AWSConstantClassSource("Amazon.CustomerProfiles.ConflictResolvingModel")]
        public Amazon.CustomerProfiles.ConflictResolvingModel ConflictResolution_ConflictResolvingModel { get; set; }
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
        /// with ingesting data from third party applications. If specified as an empty string,
        /// it will clear any existing value. You must set up a policy on the DeadLetterQueue
        /// for the SendMessage operation to enable Amazon Connect Customer Profiles to send messages
        /// to the DeadLetterQueue.</para>
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
        /// in permanent or semi-permanent storage. If specified as an empty string, it will clear
        /// any existing value.</para>
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter ConflictResolution_SourceName
        /// <summary>
        /// <para>
        /// <para>The <code>ObjectType</code> name that is used to resolve profile merging conflicts
        /// when choosing <code>SOURCE</code> as the <code>ConflictResolvingModel</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Matching_AutoMerging_ConflictResolution_SourceName")]
        public System.String ConflictResolution_SourceName { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.UpdateDomainResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.UpdateDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CPFDomain (UpdateDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.UpdateDomainResponse, UpdateCPFDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeadLetterQueueUrl = this.DeadLetterQueueUrl;
            context.DefaultEncryptionKey = this.DefaultEncryptionKey;
            context.DefaultExpirationDay = this.DefaultExpirationDay;
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
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.CustomerProfiles.Model.UpdateDomainRequest();
            
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
        
        private Amazon.CustomerProfiles.Model.UpdateDomainResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.UpdateDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "UpdateDomain");
            try
            {
                #if DESKTOP
                return client.UpdateDomain(request);
                #elif CORECLR
                return client.UpdateDomainAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.UpdateDomainResponse, UpdateCPFDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
