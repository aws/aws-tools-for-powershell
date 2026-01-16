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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates details about a specific evaluation form version in the specified Amazon Connect
    /// instance. Question and section identifiers cannot be duplicated within the same evaluation
    /// form.
    /// 
    ///  
    /// <para>
    /// This operation does not support partial updates. Instead it does a full update of
    /// evaluation form content.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CONNEvaluationForm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.UpdateEvaluationFormResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateEvaluationForm API operation.", Operation = new[] {"UpdateEvaluationForm"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateEvaluationFormResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.UpdateEvaluationFormResponse",
        "This cmdlet returns an Amazon.Connect.Model.UpdateEvaluationFormResponse object containing multiple properties."
    )]
    public partial class UpdateCONNEvaluationFormCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AsDraft
        /// <summary>
        /// <para>
        /// <para>A boolean flag indicating whether to update evaluation form to draft state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AsDraft { get; set; }
        #endregion
        
        #region Parameter TargetConfiguration_ContactInteractionType
        /// <summary>
        /// <para>
        /// <para>The contact interaction type for this evaluation form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.ContactInteractionType")]
        public Amazon.Connect.ContactInteractionType TargetConfiguration_ContactInteractionType { get; set; }
        #endregion
        
        #region Parameter CreateNewVersion
        /// <summary>
        /// <para>
        /// <para>A flag indicating whether the operation must create a new version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CreateNewVersion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the evaluation form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ReviewConfiguration_EligibilityDay
        /// <summary>
        /// <para>
        /// <para>Number of days during which a request for review can be submitted for evaluations
        /// created from this form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReviewConfiguration_EligibilityDays")]
        public System.Int32? ReviewConfiguration_EligibilityDay { get; set; }
        #endregion
        
        #region Parameter AutoEvaluationConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>When automated evaluation is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoEvaluationConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter EvaluationFormId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the evaluation form.</para>
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
        public System.String EvaluationFormId { get; set; }
        #endregion
        
        #region Parameter EvaluationFormVersion
        /// <summary>
        /// <para>
        /// <para>A version of the evaluation form to update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? EvaluationFormVersion { get; set; }
        #endregion
        
        #region Parameter LanguageConfiguration_FormLanguage
        /// <summary>
        /// <para>
        /// <para>The language for the evaluation form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.EvaluationFormLanguageCode")]
        public Amazon.Connect.EvaluationFormLanguageCode LanguageConfiguration_FormLanguage { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
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
        
        #region Parameter Item
        /// <summary>
        /// <para>
        /// <para>Items that are part of the evaluation form. The total number of sections and questions
        /// must not exceed 100 each. Questions must be contained in a section.</para>
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
        [Alias("Items")]
        public Amazon.Connect.Model.EvaluationFormItem[] Item { get; set; }
        #endregion
        
        #region Parameter ScoringStrategy_Mode
        /// <summary>
        /// <para>
        /// <para>The scoring mode of the evaluation form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.EvaluationFormScoringMode")]
        public Amazon.Connect.EvaluationFormScoringMode ScoringStrategy_Mode { get; set; }
        #endregion
        
        #region Parameter ReviewConfiguration_ReviewNotificationRecipient
        /// <summary>
        /// <para>
        /// <para>List of recipients who should be notified when a review is requested.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReviewConfiguration_ReviewNotificationRecipients")]
        public Amazon.Connect.Model.EvaluationReviewNotificationRecipient[] ReviewConfiguration_ReviewNotificationRecipient { get; set; }
        #endregion
        
        #region Parameter ScoringStrategy_Status
        /// <summary>
        /// <para>
        /// <para>The scoring status of the evaluation form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.EvaluationFormScoringStatus")]
        public Amazon.Connect.EvaluationFormScoringStatus ScoringStrategy_Status { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>A title of the evaluation form.</para>
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
        public System.String Title { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateEvaluationFormResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.UpdateEvaluationFormResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EvaluationFormId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EvaluationFormId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EvaluationFormId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EvaluationFormId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNEvaluationForm (UpdateEvaluationForm)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateEvaluationFormResponse, UpdateCONNEvaluationFormCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EvaluationFormId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AsDraft = this.AsDraft;
            context.AutoEvaluationConfiguration_Enabled = this.AutoEvaluationConfiguration_Enabled;
            context.ClientToken = this.ClientToken;
            context.CreateNewVersion = this.CreateNewVersion;
            context.Description = this.Description;
            context.EvaluationFormId = this.EvaluationFormId;
            #if MODULAR
            if (this.EvaluationFormId == null && ParameterWasBound(nameof(this.EvaluationFormId)))
            {
                WriteWarning("You are passing $null as a value for parameter EvaluationFormId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EvaluationFormVersion = this.EvaluationFormVersion;
            #if MODULAR
            if (this.EvaluationFormVersion == null && ParameterWasBound(nameof(this.EvaluationFormVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter EvaluationFormVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Item != null)
            {
                context.Item = new List<Amazon.Connect.Model.EvaluationFormItem>(this.Item);
            }
            #if MODULAR
            if (this.Item == null && ParameterWasBound(nameof(this.Item)))
            {
                WriteWarning("You are passing $null as a value for parameter Item which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LanguageConfiguration_FormLanguage = this.LanguageConfiguration_FormLanguage;
            context.ReviewConfiguration_EligibilityDay = this.ReviewConfiguration_EligibilityDay;
            if (this.ReviewConfiguration_ReviewNotificationRecipient != null)
            {
                context.ReviewConfiguration_ReviewNotificationRecipient = new List<Amazon.Connect.Model.EvaluationReviewNotificationRecipient>(this.ReviewConfiguration_ReviewNotificationRecipient);
            }
            context.ScoringStrategy_Mode = this.ScoringStrategy_Mode;
            context.ScoringStrategy_Status = this.ScoringStrategy_Status;
            context.TargetConfiguration_ContactInteractionType = this.TargetConfiguration_ContactInteractionType;
            context.Title = this.Title;
            #if MODULAR
            if (this.Title == null && ParameterWasBound(nameof(this.Title)))
            {
                WriteWarning("You are passing $null as a value for parameter Title which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.UpdateEvaluationFormRequest();
            
            if (cmdletContext.AsDraft != null)
            {
                request.AsDraft = cmdletContext.AsDraft.Value;
            }
            
             // populate AutoEvaluationConfiguration
            var requestAutoEvaluationConfigurationIsNull = true;
            request.AutoEvaluationConfiguration = new Amazon.Connect.Model.EvaluationFormAutoEvaluationConfiguration();
            System.Boolean? requestAutoEvaluationConfiguration_autoEvaluationConfiguration_Enabled = null;
            if (cmdletContext.AutoEvaluationConfiguration_Enabled != null)
            {
                requestAutoEvaluationConfiguration_autoEvaluationConfiguration_Enabled = cmdletContext.AutoEvaluationConfiguration_Enabled.Value;
            }
            if (requestAutoEvaluationConfiguration_autoEvaluationConfiguration_Enabled != null)
            {
                request.AutoEvaluationConfiguration.Enabled = requestAutoEvaluationConfiguration_autoEvaluationConfiguration_Enabled.Value;
                requestAutoEvaluationConfigurationIsNull = false;
            }
             // determine if request.AutoEvaluationConfiguration should be set to null
            if (requestAutoEvaluationConfigurationIsNull)
            {
                request.AutoEvaluationConfiguration = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CreateNewVersion != null)
            {
                request.CreateNewVersion = cmdletContext.CreateNewVersion.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EvaluationFormId != null)
            {
                request.EvaluationFormId = cmdletContext.EvaluationFormId;
            }
            if (cmdletContext.EvaluationFormVersion != null)
            {
                request.EvaluationFormVersion = cmdletContext.EvaluationFormVersion.Value;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Item != null)
            {
                request.Items = cmdletContext.Item;
            }
            
             // populate LanguageConfiguration
            var requestLanguageConfigurationIsNull = true;
            request.LanguageConfiguration = new Amazon.Connect.Model.EvaluationFormLanguageConfiguration();
            Amazon.Connect.EvaluationFormLanguageCode requestLanguageConfiguration_languageConfiguration_FormLanguage = null;
            if (cmdletContext.LanguageConfiguration_FormLanguage != null)
            {
                requestLanguageConfiguration_languageConfiguration_FormLanguage = cmdletContext.LanguageConfiguration_FormLanguage;
            }
            if (requestLanguageConfiguration_languageConfiguration_FormLanguage != null)
            {
                request.LanguageConfiguration.FormLanguage = requestLanguageConfiguration_languageConfiguration_FormLanguage;
                requestLanguageConfigurationIsNull = false;
            }
             // determine if request.LanguageConfiguration should be set to null
            if (requestLanguageConfigurationIsNull)
            {
                request.LanguageConfiguration = null;
            }
            
             // populate ReviewConfiguration
            var requestReviewConfigurationIsNull = true;
            request.ReviewConfiguration = new Amazon.Connect.Model.EvaluationReviewConfiguration();
            System.Int32? requestReviewConfiguration_reviewConfiguration_EligibilityDay = null;
            if (cmdletContext.ReviewConfiguration_EligibilityDay != null)
            {
                requestReviewConfiguration_reviewConfiguration_EligibilityDay = cmdletContext.ReviewConfiguration_EligibilityDay.Value;
            }
            if (requestReviewConfiguration_reviewConfiguration_EligibilityDay != null)
            {
                request.ReviewConfiguration.EligibilityDays = requestReviewConfiguration_reviewConfiguration_EligibilityDay.Value;
                requestReviewConfigurationIsNull = false;
            }
            List<Amazon.Connect.Model.EvaluationReviewNotificationRecipient> requestReviewConfiguration_reviewConfiguration_ReviewNotificationRecipient = null;
            if (cmdletContext.ReviewConfiguration_ReviewNotificationRecipient != null)
            {
                requestReviewConfiguration_reviewConfiguration_ReviewNotificationRecipient = cmdletContext.ReviewConfiguration_ReviewNotificationRecipient;
            }
            if (requestReviewConfiguration_reviewConfiguration_ReviewNotificationRecipient != null)
            {
                request.ReviewConfiguration.ReviewNotificationRecipients = requestReviewConfiguration_reviewConfiguration_ReviewNotificationRecipient;
                requestReviewConfigurationIsNull = false;
            }
             // determine if request.ReviewConfiguration should be set to null
            if (requestReviewConfigurationIsNull)
            {
                request.ReviewConfiguration = null;
            }
            
             // populate ScoringStrategy
            var requestScoringStrategyIsNull = true;
            request.ScoringStrategy = new Amazon.Connect.Model.EvaluationFormScoringStrategy();
            Amazon.Connect.EvaluationFormScoringMode requestScoringStrategy_scoringStrategy_Mode = null;
            if (cmdletContext.ScoringStrategy_Mode != null)
            {
                requestScoringStrategy_scoringStrategy_Mode = cmdletContext.ScoringStrategy_Mode;
            }
            if (requestScoringStrategy_scoringStrategy_Mode != null)
            {
                request.ScoringStrategy.Mode = requestScoringStrategy_scoringStrategy_Mode;
                requestScoringStrategyIsNull = false;
            }
            Amazon.Connect.EvaluationFormScoringStatus requestScoringStrategy_scoringStrategy_Status = null;
            if (cmdletContext.ScoringStrategy_Status != null)
            {
                requestScoringStrategy_scoringStrategy_Status = cmdletContext.ScoringStrategy_Status;
            }
            if (requestScoringStrategy_scoringStrategy_Status != null)
            {
                request.ScoringStrategy.Status = requestScoringStrategy_scoringStrategy_Status;
                requestScoringStrategyIsNull = false;
            }
             // determine if request.ScoringStrategy should be set to null
            if (requestScoringStrategyIsNull)
            {
                request.ScoringStrategy = null;
            }
            
             // populate TargetConfiguration
            var requestTargetConfigurationIsNull = true;
            request.TargetConfiguration = new Amazon.Connect.Model.EvaluationFormTargetConfiguration();
            Amazon.Connect.ContactInteractionType requestTargetConfiguration_targetConfiguration_ContactInteractionType = null;
            if (cmdletContext.TargetConfiguration_ContactInteractionType != null)
            {
                requestTargetConfiguration_targetConfiguration_ContactInteractionType = cmdletContext.TargetConfiguration_ContactInteractionType;
            }
            if (requestTargetConfiguration_targetConfiguration_ContactInteractionType != null)
            {
                request.TargetConfiguration.ContactInteractionType = requestTargetConfiguration_targetConfiguration_ContactInteractionType;
                requestTargetConfigurationIsNull = false;
            }
             // determine if request.TargetConfiguration should be set to null
            if (requestTargetConfigurationIsNull)
            {
                request.TargetConfiguration = null;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
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
        
        private Amazon.Connect.Model.UpdateEvaluationFormResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateEvaluationFormRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateEvaluationForm");
            try
            {
                #if DESKTOP
                return client.UpdateEvaluationForm(request);
                #elif CORECLR
                return client.UpdateEvaluationFormAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AsDraft { get; set; }
            public System.Boolean? AutoEvaluationConfiguration_Enabled { get; set; }
            public System.String ClientToken { get; set; }
            public System.Boolean? CreateNewVersion { get; set; }
            public System.String Description { get; set; }
            public System.String EvaluationFormId { get; set; }
            public System.Int32? EvaluationFormVersion { get; set; }
            public System.String InstanceId { get; set; }
            public List<Amazon.Connect.Model.EvaluationFormItem> Item { get; set; }
            public Amazon.Connect.EvaluationFormLanguageCode LanguageConfiguration_FormLanguage { get; set; }
            public System.Int32? ReviewConfiguration_EligibilityDay { get; set; }
            public List<Amazon.Connect.Model.EvaluationReviewNotificationRecipient> ReviewConfiguration_ReviewNotificationRecipient { get; set; }
            public Amazon.Connect.EvaluationFormScoringMode ScoringStrategy_Mode { get; set; }
            public Amazon.Connect.EvaluationFormScoringStatus ScoringStrategy_Status { get; set; }
            public Amazon.Connect.ContactInteractionType TargetConfiguration_ContactInteractionType { get; set; }
            public System.String Title { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateEvaluationFormResponse, UpdateCONNEvaluationFormCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
