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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Starts a Contact Lens post-call analytics job for the specified contact. This API
    /// runs Conversational Analytics post-contact analysis on a voice recording that is already
    /// attached to the contact, generating transcription, sentiment analysis, redaction,
    /// and summarization results based on the provided configuration.
    /// 
    ///  <important><para>
    /// A voice recording must already be attached to the contact before calling this API.
    /// Use <c>CreateAttachedFile</c> to attach a recording from an S3 source URI.
    /// </para></important><note><para>
    /// For example, you can call <c>CreateContact</c>, then <c>CreateAttachedFile</c>, then
    /// <c>StartContactConversationalAnalyticsJob</c> to create a contact, attach a recording,
    /// and run post-call analytics.
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "CONNContactConversationalAnalyticsJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.StartContactConversationalAnalyticsJobResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service StartContactConversationalAnalyticsJob API operation.", Operation = new[] {"StartContactConversationalAnalyticsJob"}, SelectReturnType = typeof(Amazon.Connect.Model.StartContactConversationalAnalyticsJobResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.StartContactConversationalAnalyticsJobResponse",
        "This cmdlet returns an Amazon.Connect.Model.StartContactConversationalAnalyticsJobResponse object containing multiple properties."
    )]
    public partial class StartCONNContactConversationalAnalyticsJobCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnalyticsMode
        /// <summary>
        /// <para>
        /// <para>The analytics modes to run for the contact. Valid values: <c>PostContact</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AnalyticsModes")]
        public System.String[] AnalyticsMode { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_RedactionConfiguration_Behavior
        /// <summary>
        /// <para>
        /// <para>Controls whether redaction is applied to the analytics output. Valid values: <c>Enable</c>
        /// | <c>Disable</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.Behavior")]
        public Amazon.Connect.Behavior AnalyticsConfiguration_RedactionConfiguration_Behavior { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_RulesConfiguration_Behavior
        /// <summary>
        /// <para>
        /// <para>Controls whether Contact Lens rules are evaluated for the contact. Valid values: <c>Enable</c>
        /// | <c>Disable</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.Behavior")]
        public Amazon.Connect.Behavior AnalyticsConfiguration_RulesConfiguration_Behavior { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_SentimentConfiguration_Behavior
        /// <summary>
        /// <para>
        /// <para>Controls whether sentiment analysis is applied to the analytics output. Valid values:
        /// <c>Enable</c> | <c>Disable</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.Behavior")]
        public Amazon.Connect.Behavior AnalyticsConfiguration_SentimentConfiguration_Behavior { get; set; }
        #endregion
        
        #region Parameter ContactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the contact in this instance of Connect Customer. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ContactId { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_RedactionConfiguration_Entity
        /// <summary>
        /// <para>
        /// <para>The list of PII entity types to redact from the transcript (for example, <c>NAME</c>,
        /// <c>ADDRESS</c>, <c>CREDIT_DEBIT_NUMBER</c>).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalyticsConfiguration_RedactionConfiguration_Entities")]
        public System.String[] AnalyticsConfiguration_RedactionConfiguration_Entity { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Connect Customer instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_LanguageConfiguration_LanguageLocale
        /// <summary>
        /// <para>
        /// <para>The language locale setting for conversational analytics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnalyticsConfiguration_LanguageConfiguration_LanguageLocale { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_RedactionConfiguration_MaskMode
        /// <summary>
        /// <para>
        /// <para>The masking mode that determines how redacted content is replaced in the output. Valid
        /// values: <c>PII</c> (replaces with the literal string [PII]) | <c>EntityType</c> (replaces
        /// with the entity type name, for example [NAME]).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.MaskMode")]
        public Amazon.Connect.MaskMode AnalyticsConfiguration_RedactionConfiguration_MaskMode { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_RedactionConfiguration_Policy
        /// <summary>
        /// <para>
        /// <para>The redaction output policy that determines which versions of the transcript are stored.
        /// Valid values: <c>None</c> | <c>RedactedOnly</c> | <c>RedactedAndOriginal</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.Policy")]
        public Amazon.Connect.Policy AnalyticsConfiguration_RedactionConfiguration_Policy { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_SummaryConfiguration_SummaryMode
        /// <summary>
        /// <para>
        /// <para>The summary modes that determine what type of summarization is generated. Valid values:
        /// <c>PostContact</c> | <c>AutomatedInteraction</c> | <c>ContactChain</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AnalyticsConfiguration_SummaryConfiguration_SummaryModes")]
        public System.String[] AnalyticsConfiguration_SummaryConfiguration_SummaryMode { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.StartContactConversationalAnalyticsJobResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.StartContactConversationalAnalyticsJobResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.ContactId),
                nameof(this.InstanceId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CONNContactConversationalAnalyticsJob (StartContactConversationalAnalyticsJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.StartContactConversationalAnalyticsJobResponse, StartCONNContactConversationalAnalyticsJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnalyticsConfiguration_LanguageConfiguration_LanguageLocale = this.AnalyticsConfiguration_LanguageConfiguration_LanguageLocale;
            context.AnalyticsConfiguration_RedactionConfiguration_Behavior = this.AnalyticsConfiguration_RedactionConfiguration_Behavior;
            #if MODULAR
            if (this.AnalyticsConfiguration_RedactionConfiguration_Behavior == null && ParameterWasBound(nameof(this.AnalyticsConfiguration_RedactionConfiguration_Behavior)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalyticsConfiguration_RedactionConfiguration_Behavior which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AnalyticsConfiguration_RedactionConfiguration_Entity != null)
            {
                context.AnalyticsConfiguration_RedactionConfiguration_Entity = new List<System.String>(this.AnalyticsConfiguration_RedactionConfiguration_Entity);
            }
            context.AnalyticsConfiguration_RedactionConfiguration_MaskMode = this.AnalyticsConfiguration_RedactionConfiguration_MaskMode;
            context.AnalyticsConfiguration_RedactionConfiguration_Policy = this.AnalyticsConfiguration_RedactionConfiguration_Policy;
            #if MODULAR
            if (this.AnalyticsConfiguration_RedactionConfiguration_Policy == null && ParameterWasBound(nameof(this.AnalyticsConfiguration_RedactionConfiguration_Policy)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalyticsConfiguration_RedactionConfiguration_Policy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnalyticsConfiguration_RulesConfiguration_Behavior = this.AnalyticsConfiguration_RulesConfiguration_Behavior;
            context.AnalyticsConfiguration_SentimentConfiguration_Behavior = this.AnalyticsConfiguration_SentimentConfiguration_Behavior;
            #if MODULAR
            if (this.AnalyticsConfiguration_SentimentConfiguration_Behavior == null && ParameterWasBound(nameof(this.AnalyticsConfiguration_SentimentConfiguration_Behavior)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalyticsConfiguration_SentimentConfiguration_Behavior which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AnalyticsConfiguration_SummaryConfiguration_SummaryMode != null)
            {
                context.AnalyticsConfiguration_SummaryConfiguration_SummaryMode = new List<System.String>(this.AnalyticsConfiguration_SummaryConfiguration_SummaryMode);
            }
            #if MODULAR
            if (this.AnalyticsConfiguration_SummaryConfiguration_SummaryMode == null && ParameterWasBound(nameof(this.AnalyticsConfiguration_SummaryConfiguration_SummaryMode)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalyticsConfiguration_SummaryConfiguration_SummaryMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AnalyticsMode != null)
            {
                context.AnalyticsMode = new List<System.String>(this.AnalyticsMode);
            }
            #if MODULAR
            if (this.AnalyticsMode == null && ParameterWasBound(nameof(this.AnalyticsMode)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalyticsMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.ContactId = this.ContactId;
            #if MODULAR
            if (this.ContactId == null && ParameterWasBound(nameof(this.ContactId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Connect.Model.StartContactConversationalAnalyticsJobRequest();
            
            
             // populate AnalyticsConfiguration
            var requestAnalyticsConfigurationIsNull = true;
            request.AnalyticsConfiguration = new Amazon.Connect.Model.AnalyticsConfiguration();
            Amazon.Connect.Model.LanguageConfiguration requestAnalyticsConfiguration_analyticsConfiguration_LanguageConfiguration = null;
            
             // populate LanguageConfiguration
            var requestAnalyticsConfiguration_analyticsConfiguration_LanguageConfigurationIsNull = true;
            requestAnalyticsConfiguration_analyticsConfiguration_LanguageConfiguration = new Amazon.Connect.Model.LanguageConfiguration();
            System.String requestAnalyticsConfiguration_analyticsConfiguration_LanguageConfiguration_analyticsConfiguration_LanguageConfiguration_LanguageLocale = null;
            if (cmdletContext.AnalyticsConfiguration_LanguageConfiguration_LanguageLocale != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_LanguageConfiguration_analyticsConfiguration_LanguageConfiguration_LanguageLocale = cmdletContext.AnalyticsConfiguration_LanguageConfiguration_LanguageLocale;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_LanguageConfiguration_analyticsConfiguration_LanguageConfiguration_LanguageLocale != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_LanguageConfiguration.LanguageLocale = requestAnalyticsConfiguration_analyticsConfiguration_LanguageConfiguration_analyticsConfiguration_LanguageConfiguration_LanguageLocale;
                requestAnalyticsConfiguration_analyticsConfiguration_LanguageConfigurationIsNull = false;
            }
             // determine if requestAnalyticsConfiguration_analyticsConfiguration_LanguageConfiguration should be set to null
            if (requestAnalyticsConfiguration_analyticsConfiguration_LanguageConfigurationIsNull)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_LanguageConfiguration = null;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_LanguageConfiguration != null)
            {
                request.AnalyticsConfiguration.LanguageConfiguration = requestAnalyticsConfiguration_analyticsConfiguration_LanguageConfiguration;
                requestAnalyticsConfigurationIsNull = false;
            }
            Amazon.Connect.Model.RulesConfiguration requestAnalyticsConfiguration_analyticsConfiguration_RulesConfiguration = null;
            
             // populate RulesConfiguration
            var requestAnalyticsConfiguration_analyticsConfiguration_RulesConfigurationIsNull = true;
            requestAnalyticsConfiguration_analyticsConfiguration_RulesConfiguration = new Amazon.Connect.Model.RulesConfiguration();
            Amazon.Connect.Behavior requestAnalyticsConfiguration_analyticsConfiguration_RulesConfiguration_analyticsConfiguration_RulesConfiguration_Behavior = null;
            if (cmdletContext.AnalyticsConfiguration_RulesConfiguration_Behavior != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_RulesConfiguration_analyticsConfiguration_RulesConfiguration_Behavior = cmdletContext.AnalyticsConfiguration_RulesConfiguration_Behavior;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_RulesConfiguration_analyticsConfiguration_RulesConfiguration_Behavior != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_RulesConfiguration.Behavior = requestAnalyticsConfiguration_analyticsConfiguration_RulesConfiguration_analyticsConfiguration_RulesConfiguration_Behavior;
                requestAnalyticsConfiguration_analyticsConfiguration_RulesConfigurationIsNull = false;
            }
             // determine if requestAnalyticsConfiguration_analyticsConfiguration_RulesConfiguration should be set to null
            if (requestAnalyticsConfiguration_analyticsConfiguration_RulesConfigurationIsNull)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_RulesConfiguration = null;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_RulesConfiguration != null)
            {
                request.AnalyticsConfiguration.RulesConfiguration = requestAnalyticsConfiguration_analyticsConfiguration_RulesConfiguration;
                requestAnalyticsConfigurationIsNull = false;
            }
            Amazon.Connect.Model.SentimentConfiguration requestAnalyticsConfiguration_analyticsConfiguration_SentimentConfiguration = null;
            
             // populate SentimentConfiguration
            var requestAnalyticsConfiguration_analyticsConfiguration_SentimentConfigurationIsNull = true;
            requestAnalyticsConfiguration_analyticsConfiguration_SentimentConfiguration = new Amazon.Connect.Model.SentimentConfiguration();
            Amazon.Connect.Behavior requestAnalyticsConfiguration_analyticsConfiguration_SentimentConfiguration_analyticsConfiguration_SentimentConfiguration_Behavior = null;
            if (cmdletContext.AnalyticsConfiguration_SentimentConfiguration_Behavior != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_SentimentConfiguration_analyticsConfiguration_SentimentConfiguration_Behavior = cmdletContext.AnalyticsConfiguration_SentimentConfiguration_Behavior;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_SentimentConfiguration_analyticsConfiguration_SentimentConfiguration_Behavior != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_SentimentConfiguration.Behavior = requestAnalyticsConfiguration_analyticsConfiguration_SentimentConfiguration_analyticsConfiguration_SentimentConfiguration_Behavior;
                requestAnalyticsConfiguration_analyticsConfiguration_SentimentConfigurationIsNull = false;
            }
             // determine if requestAnalyticsConfiguration_analyticsConfiguration_SentimentConfiguration should be set to null
            if (requestAnalyticsConfiguration_analyticsConfiguration_SentimentConfigurationIsNull)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_SentimentConfiguration = null;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_SentimentConfiguration != null)
            {
                request.AnalyticsConfiguration.SentimentConfiguration = requestAnalyticsConfiguration_analyticsConfiguration_SentimentConfiguration;
                requestAnalyticsConfigurationIsNull = false;
            }
            Amazon.Connect.Model.SummaryConfiguration requestAnalyticsConfiguration_analyticsConfiguration_SummaryConfiguration = null;
            
             // populate SummaryConfiguration
            var requestAnalyticsConfiguration_analyticsConfiguration_SummaryConfigurationIsNull = true;
            requestAnalyticsConfiguration_analyticsConfiguration_SummaryConfiguration = new Amazon.Connect.Model.SummaryConfiguration();
            List<System.String> requestAnalyticsConfiguration_analyticsConfiguration_SummaryConfiguration_analyticsConfiguration_SummaryConfiguration_SummaryMode = null;
            if (cmdletContext.AnalyticsConfiguration_SummaryConfiguration_SummaryMode != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_SummaryConfiguration_analyticsConfiguration_SummaryConfiguration_SummaryMode = cmdletContext.AnalyticsConfiguration_SummaryConfiguration_SummaryMode;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_SummaryConfiguration_analyticsConfiguration_SummaryConfiguration_SummaryMode != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_SummaryConfiguration.SummaryModes = requestAnalyticsConfiguration_analyticsConfiguration_SummaryConfiguration_analyticsConfiguration_SummaryConfiguration_SummaryMode;
                requestAnalyticsConfiguration_analyticsConfiguration_SummaryConfigurationIsNull = false;
            }
             // determine if requestAnalyticsConfiguration_analyticsConfiguration_SummaryConfiguration should be set to null
            if (requestAnalyticsConfiguration_analyticsConfiguration_SummaryConfigurationIsNull)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_SummaryConfiguration = null;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_SummaryConfiguration != null)
            {
                request.AnalyticsConfiguration.SummaryConfiguration = requestAnalyticsConfiguration_analyticsConfiguration_SummaryConfiguration;
                requestAnalyticsConfigurationIsNull = false;
            }
            Amazon.Connect.Model.RedactionConfiguration requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration = null;
            
             // populate RedactionConfiguration
            var requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfigurationIsNull = true;
            requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration = new Amazon.Connect.Model.RedactionConfiguration();
            Amazon.Connect.Behavior requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_Behavior = null;
            if (cmdletContext.AnalyticsConfiguration_RedactionConfiguration_Behavior != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_Behavior = cmdletContext.AnalyticsConfiguration_RedactionConfiguration_Behavior;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_Behavior != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration.Behavior = requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_Behavior;
                requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfigurationIsNull = false;
            }
            List<System.String> requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_Entity = null;
            if (cmdletContext.AnalyticsConfiguration_RedactionConfiguration_Entity != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_Entity = cmdletContext.AnalyticsConfiguration_RedactionConfiguration_Entity;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_Entity != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration.Entities = requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_Entity;
                requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfigurationIsNull = false;
            }
            Amazon.Connect.MaskMode requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_MaskMode = null;
            if (cmdletContext.AnalyticsConfiguration_RedactionConfiguration_MaskMode != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_MaskMode = cmdletContext.AnalyticsConfiguration_RedactionConfiguration_MaskMode;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_MaskMode != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration.MaskMode = requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_MaskMode;
                requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfigurationIsNull = false;
            }
            Amazon.Connect.Policy requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_Policy = null;
            if (cmdletContext.AnalyticsConfiguration_RedactionConfiguration_Policy != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_Policy = cmdletContext.AnalyticsConfiguration_RedactionConfiguration_Policy;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_Policy != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration.Policy = requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration_analyticsConfiguration_RedactionConfiguration_Policy;
                requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfigurationIsNull = false;
            }
             // determine if requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration should be set to null
            if (requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfigurationIsNull)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration = null;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration != null)
            {
                request.AnalyticsConfiguration.RedactionConfiguration = requestAnalyticsConfiguration_analyticsConfiguration_RedactionConfiguration;
                requestAnalyticsConfigurationIsNull = false;
            }
             // determine if request.AnalyticsConfiguration should be set to null
            if (requestAnalyticsConfigurationIsNull)
            {
                request.AnalyticsConfiguration = null;
            }
            if (cmdletContext.AnalyticsMode != null)
            {
                request.AnalyticsModes = cmdletContext.AnalyticsMode;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ContactId != null)
            {
                request.ContactId = cmdletContext.ContactId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
        
        private Amazon.Connect.Model.StartContactConversationalAnalyticsJobResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.StartContactConversationalAnalyticsJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "StartContactConversationalAnalyticsJob");
            try
            {
                return client.StartContactConversationalAnalyticsJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AnalyticsConfiguration_LanguageConfiguration_LanguageLocale { get; set; }
            public Amazon.Connect.Behavior AnalyticsConfiguration_RedactionConfiguration_Behavior { get; set; }
            public List<System.String> AnalyticsConfiguration_RedactionConfiguration_Entity { get; set; }
            public Amazon.Connect.MaskMode AnalyticsConfiguration_RedactionConfiguration_MaskMode { get; set; }
            public Amazon.Connect.Policy AnalyticsConfiguration_RedactionConfiguration_Policy { get; set; }
            public Amazon.Connect.Behavior AnalyticsConfiguration_RulesConfiguration_Behavior { get; set; }
            public Amazon.Connect.Behavior AnalyticsConfiguration_SentimentConfiguration_Behavior { get; set; }
            public List<System.String> AnalyticsConfiguration_SummaryConfiguration_SummaryMode { get; set; }
            public List<System.String> AnalyticsMode { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ContactId { get; set; }
            public System.String InstanceId { get; set; }
            public System.Func<Amazon.Connect.Model.StartContactConversationalAnalyticsJobResponse, StartCONNContactConversationalAnalyticsJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
