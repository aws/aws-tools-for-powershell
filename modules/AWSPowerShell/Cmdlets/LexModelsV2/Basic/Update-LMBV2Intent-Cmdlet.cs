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
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// Updates the settings for an intent.
    /// </summary>
    [Cmdlet("Update", "LMBV2Intent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelsV2.Model.UpdateIntentResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 UpdateIntent API operation.", Operation = new[] {"UpdateIntent"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.UpdateIntentResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.UpdateIntentResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.UpdateIntentResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLMBV2IntentCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        #region Parameter ClosingResponse_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntentClosingSetting_ClosingResponse_AllowInterrupt")]
        public System.Boolean? ClosingResponse_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter DeclinationResponse_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntentConfirmationSetting_DeclinationResponse_AllowInterrupt")]
        public System.Boolean? DeclinationResponse_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter PromptSpecification_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech prompt from the bot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntentConfirmationSetting_PromptSpecification_AllowInterrupt")]
        public System.Boolean? PromptSpecification_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The identifier of the bot that contains the intent.</para>
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
        public System.String BotId { get; set; }
        #endregion
        
        #region Parameter BotVersion
        /// <summary>
        /// <para>
        /// <para>The version of the bot that contains the intent. Must be <code>DRAFT</code>.</para>
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
        public System.String BotVersion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The new description of the intent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DialogCodeHook_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables the dialog code hook so that it processes user requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DialogCodeHook_Enabled { get; set; }
        #endregion
        
        #region Parameter FulfillmentCodeHook_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether a Lambda function should be invoked to fulfill a specific intent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? FulfillmentCodeHook_Enabled { get; set; }
        #endregion
        
        #region Parameter InputContext
        /// <summary>
        /// <para>
        /// <para>A new list of contexts that must be active in order for Amazon Lex to consider the
        /// intent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputContexts")]
        public Amazon.LexModelsV2.Model.InputContext[] InputContext { get; set; }
        #endregion
        
        #region Parameter IntentId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the intent to update.</para>
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
        public System.String IntentId { get; set; }
        #endregion
        
        #region Parameter IntentName
        /// <summary>
        /// <para>
        /// <para>The new name for the intent.</para>
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
        public System.String IntentName { get; set; }
        #endregion
        
        #region Parameter KendraConfiguration_KendraIndex
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Kendra index that you want the AMAZON.KendraSearchIntent
        /// intent to search. The index must be in the same account and Region as the Amazon Lex
        /// bot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KendraConfiguration_KendraIndex { get; set; }
        #endregion
        
        #region Parameter LocaleId
        /// <summary>
        /// <para>
        /// <para>The identifier of the language and locale where this intent is used. The string must
        /// match one of the supported locales. For more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/how-languages.html">Supported
        /// languages</a>.</para>
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
        public System.String LocaleId { get; set; }
        #endregion
        
        #region Parameter PromptSpecification_MaxRetry
        /// <summary>
        /// <para>
        /// <para>The maximum number of times the bot tries to elicit a resonse from the user using
        /// this prompt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntentConfirmationSetting_PromptSpecification_MaxRetries")]
        public System.Int32? PromptSpecification_MaxRetry { get; set; }
        #endregion
        
        #region Parameter ClosingResponse_MessageGroup
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntentClosingSetting_ClosingResponse_MessageGroups")]
        public Amazon.LexModelsV2.Model.MessageGroup[] ClosingResponse_MessageGroup { get; set; }
        #endregion
        
        #region Parameter DeclinationResponse_MessageGroup
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntentConfirmationSetting_DeclinationResponse_MessageGroups")]
        public Amazon.LexModelsV2.Model.MessageGroup[] DeclinationResponse_MessageGroup { get; set; }
        #endregion
        
        #region Parameter PromptSpecification_MessageGroup
        /// <summary>
        /// <para>
        /// <para>A collection of messages that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual message to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntentConfirmationSetting_PromptSpecification_MessageGroups")]
        public Amazon.LexModelsV2.Model.MessageGroup[] PromptSpecification_MessageGroup { get; set; }
        #endregion
        
        #region Parameter OutputContext
        /// <summary>
        /// <para>
        /// <para>A new list of contexts that Amazon Lex activates when the intent is fulfilled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputContexts")]
        public Amazon.LexModelsV2.Model.OutputContext[] OutputContext { get; set; }
        #endregion
        
        #region Parameter ParentIntentSignature
        /// <summary>
        /// <para>
        /// <para>The signature of the new built-in intent to use as the parent of this intent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentIntentSignature { get; set; }
        #endregion
        
        #region Parameter KendraConfiguration_QueryFilterString
        /// <summary>
        /// <para>
        /// <para>A query filter that Amazon Lex sends to Amazon Kendra to filter the response from
        /// a query. The filter is in the format defined by Amazon Kendra. For more information,
        /// see <a href="https://docs.aws.amazon.com/kendra/latest/dg/filtering.html">Filtering
        /// queries</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KendraConfiguration_QueryFilterString { get; set; }
        #endregion
        
        #region Parameter KendraConfiguration_QueryFilterStringEnabled
        /// <summary>
        /// <para>
        /// <para>Determines whether the AMAZON.KendraSearchIntent intent uses a custom query string
        /// to query the Amazon Kendra index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KendraConfiguration_QueryFilterStringEnabled { get; set; }
        #endregion
        
        #region Parameter SampleUtterance
        /// <summary>
        /// <para>
        /// <para>New utterances used to invoke the intent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SampleUtterances")]
        public Amazon.LexModelsV2.Model.SampleUtterance[] SampleUtterance { get; set; }
        #endregion
        
        #region Parameter SlotPriority
        /// <summary>
        /// <para>
        /// <para>A new list of slots and their priorities that are contained by the intent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SlotPriorities")]
        public Amazon.LexModelsV2.Model.SlotPriority[] SlotPriority { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.UpdateIntentResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.UpdateIntentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IntentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IntentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IntentId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IntentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMBV2Intent (UpdateIntent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.UpdateIntentResponse, UpdateLMBV2IntentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IntentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BotId = this.BotId;
            #if MODULAR
            if (this.BotId == null && ParameterWasBound(nameof(this.BotId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotVersion = this.BotVersion;
            #if MODULAR
            if (this.BotVersion == null && ParameterWasBound(nameof(this.BotVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter BotVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.DialogCodeHook_Enabled = this.DialogCodeHook_Enabled;
            context.FulfillmentCodeHook_Enabled = this.FulfillmentCodeHook_Enabled;
            if (this.InputContext != null)
            {
                context.InputContext = new List<Amazon.LexModelsV2.Model.InputContext>(this.InputContext);
            }
            context.ClosingResponse_AllowInterrupt = this.ClosingResponse_AllowInterrupt;
            if (this.ClosingResponse_MessageGroup != null)
            {
                context.ClosingResponse_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.ClosingResponse_MessageGroup);
            }
            context.DeclinationResponse_AllowInterrupt = this.DeclinationResponse_AllowInterrupt;
            if (this.DeclinationResponse_MessageGroup != null)
            {
                context.DeclinationResponse_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.DeclinationResponse_MessageGroup);
            }
            context.PromptSpecification_AllowInterrupt = this.PromptSpecification_AllowInterrupt;
            context.PromptSpecification_MaxRetry = this.PromptSpecification_MaxRetry;
            if (this.PromptSpecification_MessageGroup != null)
            {
                context.PromptSpecification_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.PromptSpecification_MessageGroup);
            }
            context.IntentId = this.IntentId;
            #if MODULAR
            if (this.IntentId == null && ParameterWasBound(nameof(this.IntentId)))
            {
                WriteWarning("You are passing $null as a value for parameter IntentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IntentName = this.IntentName;
            #if MODULAR
            if (this.IntentName == null && ParameterWasBound(nameof(this.IntentName)))
            {
                WriteWarning("You are passing $null as a value for parameter IntentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KendraConfiguration_KendraIndex = this.KendraConfiguration_KendraIndex;
            context.KendraConfiguration_QueryFilterString = this.KendraConfiguration_QueryFilterString;
            context.KendraConfiguration_QueryFilterStringEnabled = this.KendraConfiguration_QueryFilterStringEnabled;
            context.LocaleId = this.LocaleId;
            #if MODULAR
            if (this.LocaleId == null && ParameterWasBound(nameof(this.LocaleId)))
            {
                WriteWarning("You are passing $null as a value for parameter LocaleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OutputContext != null)
            {
                context.OutputContext = new List<Amazon.LexModelsV2.Model.OutputContext>(this.OutputContext);
            }
            context.ParentIntentSignature = this.ParentIntentSignature;
            if (this.SampleUtterance != null)
            {
                context.SampleUtterance = new List<Amazon.LexModelsV2.Model.SampleUtterance>(this.SampleUtterance);
            }
            if (this.SlotPriority != null)
            {
                context.SlotPriority = new List<Amazon.LexModelsV2.Model.SlotPriority>(this.SlotPriority);
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
            var request = new Amazon.LexModelsV2.Model.UpdateIntentRequest();
            
            if (cmdletContext.BotId != null)
            {
                request.BotId = cmdletContext.BotId;
            }
            if (cmdletContext.BotVersion != null)
            {
                request.BotVersion = cmdletContext.BotVersion;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate DialogCodeHook
            var requestDialogCodeHookIsNull = true;
            request.DialogCodeHook = new Amazon.LexModelsV2.Model.DialogCodeHookSettings();
            System.Boolean? requestDialogCodeHook_dialogCodeHook_Enabled = null;
            if (cmdletContext.DialogCodeHook_Enabled != null)
            {
                requestDialogCodeHook_dialogCodeHook_Enabled = cmdletContext.DialogCodeHook_Enabled.Value;
            }
            if (requestDialogCodeHook_dialogCodeHook_Enabled != null)
            {
                request.DialogCodeHook.Enabled = requestDialogCodeHook_dialogCodeHook_Enabled.Value;
                requestDialogCodeHookIsNull = false;
            }
             // determine if request.DialogCodeHook should be set to null
            if (requestDialogCodeHookIsNull)
            {
                request.DialogCodeHook = null;
            }
            
             // populate FulfillmentCodeHook
            var requestFulfillmentCodeHookIsNull = true;
            request.FulfillmentCodeHook = new Amazon.LexModelsV2.Model.FulfillmentCodeHookSettings();
            System.Boolean? requestFulfillmentCodeHook_fulfillmentCodeHook_Enabled = null;
            if (cmdletContext.FulfillmentCodeHook_Enabled != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_Enabled = cmdletContext.FulfillmentCodeHook_Enabled.Value;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_Enabled != null)
            {
                request.FulfillmentCodeHook.Enabled = requestFulfillmentCodeHook_fulfillmentCodeHook_Enabled.Value;
                requestFulfillmentCodeHookIsNull = false;
            }
             // determine if request.FulfillmentCodeHook should be set to null
            if (requestFulfillmentCodeHookIsNull)
            {
                request.FulfillmentCodeHook = null;
            }
            if (cmdletContext.InputContext != null)
            {
                request.InputContexts = cmdletContext.InputContext;
            }
            
             // populate IntentClosingSetting
            var requestIntentClosingSettingIsNull = true;
            request.IntentClosingSetting = new Amazon.LexModelsV2.Model.IntentClosingSetting();
            Amazon.LexModelsV2.Model.ResponseSpecification requestIntentClosingSetting_intentClosingSetting_ClosingResponse = null;
            
             // populate ClosingResponse
            var requestIntentClosingSetting_intentClosingSetting_ClosingResponseIsNull = true;
            requestIntentClosingSetting_intentClosingSetting_ClosingResponse = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestIntentClosingSetting_intentClosingSetting_ClosingResponse_closingResponse_AllowInterrupt = null;
            if (cmdletContext.ClosingResponse_AllowInterrupt != null)
            {
                requestIntentClosingSetting_intentClosingSetting_ClosingResponse_closingResponse_AllowInterrupt = cmdletContext.ClosingResponse_AllowInterrupt.Value;
            }
            if (requestIntentClosingSetting_intentClosingSetting_ClosingResponse_closingResponse_AllowInterrupt != null)
            {
                requestIntentClosingSetting_intentClosingSetting_ClosingResponse.AllowInterrupt = requestIntentClosingSetting_intentClosingSetting_ClosingResponse_closingResponse_AllowInterrupt.Value;
                requestIntentClosingSetting_intentClosingSetting_ClosingResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestIntentClosingSetting_intentClosingSetting_ClosingResponse_closingResponse_MessageGroup = null;
            if (cmdletContext.ClosingResponse_MessageGroup != null)
            {
                requestIntentClosingSetting_intentClosingSetting_ClosingResponse_closingResponse_MessageGroup = cmdletContext.ClosingResponse_MessageGroup;
            }
            if (requestIntentClosingSetting_intentClosingSetting_ClosingResponse_closingResponse_MessageGroup != null)
            {
                requestIntentClosingSetting_intentClosingSetting_ClosingResponse.MessageGroups = requestIntentClosingSetting_intentClosingSetting_ClosingResponse_closingResponse_MessageGroup;
                requestIntentClosingSetting_intentClosingSetting_ClosingResponseIsNull = false;
            }
             // determine if requestIntentClosingSetting_intentClosingSetting_ClosingResponse should be set to null
            if (requestIntentClosingSetting_intentClosingSetting_ClosingResponseIsNull)
            {
                requestIntentClosingSetting_intentClosingSetting_ClosingResponse = null;
            }
            if (requestIntentClosingSetting_intentClosingSetting_ClosingResponse != null)
            {
                request.IntentClosingSetting.ClosingResponse = requestIntentClosingSetting_intentClosingSetting_ClosingResponse;
                requestIntentClosingSettingIsNull = false;
            }
             // determine if request.IntentClosingSetting should be set to null
            if (requestIntentClosingSettingIsNull)
            {
                request.IntentClosingSetting = null;
            }
            
             // populate IntentConfirmationSetting
            var requestIntentConfirmationSettingIsNull = true;
            request.IntentConfirmationSetting = new Amazon.LexModelsV2.Model.IntentConfirmationSetting();
            Amazon.LexModelsV2.Model.ResponseSpecification requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse = null;
            
             // populate DeclinationResponse
            var requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponseIsNull = true;
            requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse_declinationResponse_AllowInterrupt = null;
            if (cmdletContext.DeclinationResponse_AllowInterrupt != null)
            {
                requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse_declinationResponse_AllowInterrupt = cmdletContext.DeclinationResponse_AllowInterrupt.Value;
            }
            if (requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse_declinationResponse_AllowInterrupt != null)
            {
                requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse.AllowInterrupt = requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse_declinationResponse_AllowInterrupt.Value;
                requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse_declinationResponse_MessageGroup = null;
            if (cmdletContext.DeclinationResponse_MessageGroup != null)
            {
                requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse_declinationResponse_MessageGroup = cmdletContext.DeclinationResponse_MessageGroup;
            }
            if (requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse_declinationResponse_MessageGroup != null)
            {
                requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse.MessageGroups = requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse_declinationResponse_MessageGroup;
                requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponseIsNull = false;
            }
             // determine if requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse should be set to null
            if (requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponseIsNull)
            {
                requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse = null;
            }
            if (requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse != null)
            {
                request.IntentConfirmationSetting.DeclinationResponse = requestIntentConfirmationSetting_intentConfirmationSetting_DeclinationResponse;
                requestIntentConfirmationSettingIsNull = false;
            }
            Amazon.LexModelsV2.Model.PromptSpecification requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification = null;
            
             // populate PromptSpecification
            var requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecificationIsNull = true;
            requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification = new Amazon.LexModelsV2.Model.PromptSpecification();
            System.Boolean? requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_AllowInterrupt = null;
            if (cmdletContext.PromptSpecification_AllowInterrupt != null)
            {
                requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_AllowInterrupt = cmdletContext.PromptSpecification_AllowInterrupt.Value;
            }
            if (requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_AllowInterrupt != null)
            {
                requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification.AllowInterrupt = requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_AllowInterrupt.Value;
                requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecificationIsNull = false;
            }
            System.Int32? requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_MaxRetry = null;
            if (cmdletContext.PromptSpecification_MaxRetry != null)
            {
                requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_MaxRetry = cmdletContext.PromptSpecification_MaxRetry.Value;
            }
            if (requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_MaxRetry != null)
            {
                requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification.MaxRetries = requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_MaxRetry.Value;
                requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecificationIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_MessageGroup = null;
            if (cmdletContext.PromptSpecification_MessageGroup != null)
            {
                requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_MessageGroup = cmdletContext.PromptSpecification_MessageGroup;
            }
            if (requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_MessageGroup != null)
            {
                requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification.MessageGroups = requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_MessageGroup;
                requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecificationIsNull = false;
            }
             // determine if requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification should be set to null
            if (requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecificationIsNull)
            {
                requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification = null;
            }
            if (requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification != null)
            {
                request.IntentConfirmationSetting.PromptSpecification = requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification;
                requestIntentConfirmationSettingIsNull = false;
            }
             // determine if request.IntentConfirmationSetting should be set to null
            if (requestIntentConfirmationSettingIsNull)
            {
                request.IntentConfirmationSetting = null;
            }
            if (cmdletContext.IntentId != null)
            {
                request.IntentId = cmdletContext.IntentId;
            }
            if (cmdletContext.IntentName != null)
            {
                request.IntentName = cmdletContext.IntentName;
            }
            
             // populate KendraConfiguration
            var requestKendraConfigurationIsNull = true;
            request.KendraConfiguration = new Amazon.LexModelsV2.Model.KendraConfiguration();
            System.String requestKendraConfiguration_kendraConfiguration_KendraIndex = null;
            if (cmdletContext.KendraConfiguration_KendraIndex != null)
            {
                requestKendraConfiguration_kendraConfiguration_KendraIndex = cmdletContext.KendraConfiguration_KendraIndex;
            }
            if (requestKendraConfiguration_kendraConfiguration_KendraIndex != null)
            {
                request.KendraConfiguration.KendraIndex = requestKendraConfiguration_kendraConfiguration_KendraIndex;
                requestKendraConfigurationIsNull = false;
            }
            System.String requestKendraConfiguration_kendraConfiguration_QueryFilterString = null;
            if (cmdletContext.KendraConfiguration_QueryFilterString != null)
            {
                requestKendraConfiguration_kendraConfiguration_QueryFilterString = cmdletContext.KendraConfiguration_QueryFilterString;
            }
            if (requestKendraConfiguration_kendraConfiguration_QueryFilterString != null)
            {
                request.KendraConfiguration.QueryFilterString = requestKendraConfiguration_kendraConfiguration_QueryFilterString;
                requestKendraConfigurationIsNull = false;
            }
            System.Boolean? requestKendraConfiguration_kendraConfiguration_QueryFilterStringEnabled = null;
            if (cmdletContext.KendraConfiguration_QueryFilterStringEnabled != null)
            {
                requestKendraConfiguration_kendraConfiguration_QueryFilterStringEnabled = cmdletContext.KendraConfiguration_QueryFilterStringEnabled.Value;
            }
            if (requestKendraConfiguration_kendraConfiguration_QueryFilterStringEnabled != null)
            {
                request.KendraConfiguration.QueryFilterStringEnabled = requestKendraConfiguration_kendraConfiguration_QueryFilterStringEnabled.Value;
                requestKendraConfigurationIsNull = false;
            }
             // determine if request.KendraConfiguration should be set to null
            if (requestKendraConfigurationIsNull)
            {
                request.KendraConfiguration = null;
            }
            if (cmdletContext.LocaleId != null)
            {
                request.LocaleId = cmdletContext.LocaleId;
            }
            if (cmdletContext.OutputContext != null)
            {
                request.OutputContexts = cmdletContext.OutputContext;
            }
            if (cmdletContext.ParentIntentSignature != null)
            {
                request.ParentIntentSignature = cmdletContext.ParentIntentSignature;
            }
            if (cmdletContext.SampleUtterance != null)
            {
                request.SampleUtterances = cmdletContext.SampleUtterance;
            }
            if (cmdletContext.SlotPriority != null)
            {
                request.SlotPriorities = cmdletContext.SlotPriority;
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
        
        private Amazon.LexModelsV2.Model.UpdateIntentResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.UpdateIntentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "UpdateIntent");
            try
            {
                #if DESKTOP
                return client.UpdateIntent(request);
                #elif CORECLR
                return client.UpdateIntentAsync(request).GetAwaiter().GetResult();
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
            public System.String BotId { get; set; }
            public System.String BotVersion { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? DialogCodeHook_Enabled { get; set; }
            public System.Boolean? FulfillmentCodeHook_Enabled { get; set; }
            public List<Amazon.LexModelsV2.Model.InputContext> InputContext { get; set; }
            public System.Boolean? ClosingResponse_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> ClosingResponse_MessageGroup { get; set; }
            public System.Boolean? DeclinationResponse_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> DeclinationResponse_MessageGroup { get; set; }
            public System.Boolean? PromptSpecification_AllowInterrupt { get; set; }
            public System.Int32? PromptSpecification_MaxRetry { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> PromptSpecification_MessageGroup { get; set; }
            public System.String IntentId { get; set; }
            public System.String IntentName { get; set; }
            public System.String KendraConfiguration_KendraIndex { get; set; }
            public System.String KendraConfiguration_QueryFilterString { get; set; }
            public System.Boolean? KendraConfiguration_QueryFilterStringEnabled { get; set; }
            public System.String LocaleId { get; set; }
            public List<Amazon.LexModelsV2.Model.OutputContext> OutputContext { get; set; }
            public System.String ParentIntentSignature { get; set; }
            public List<Amazon.LexModelsV2.Model.SampleUtterance> SampleUtterance { get; set; }
            public List<Amazon.LexModelsV2.Model.SlotPriority> SlotPriority { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.UpdateIntentResponse, UpdateLMBV2IntentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
