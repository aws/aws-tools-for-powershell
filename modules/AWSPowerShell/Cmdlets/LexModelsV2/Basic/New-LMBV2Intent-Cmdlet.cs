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
    /// Creates an intent.
    /// 
    ///  
    /// <para>
    /// To define the interaction between the user and your bot, you define one or more intents.
    /// For example, for a pizza ordering bot you would create an <code>OrderPizza</code>
    /// intent.
    /// </para><para>
    /// When you create an intent, you must provide a name. You can optionally provide the
    /// following:
    /// </para><ul><li><para>
    /// Sample utterances. For example, "I want to order a pizza" and "Can I order a pizza."
    /// You can't provide utterances for built-in intents.
    /// </para></li><li><para>
    /// Information to be gathered. You specify slots for the information that you bot requests
    /// from the user. You can specify standard slot types, such as date and time, or custom
    /// slot types for your application.
    /// </para></li><li><para>
    /// How the intent is fulfilled. You can provide a Lambda function or configure the intent
    /// to return the intent information to your client application. If you use a Lambda function,
    /// Amazon Lex invokes the function when all of the intent information is available.
    /// </para></li><li><para>
    /// A confirmation prompt to send to the user to confirm an intent. For example, "Shall
    /// I order your pizza?"
    /// </para></li><li><para>
    /// A conclusion statement to send to the user after the intent is fulfilled. For example,
    /// "I ordered your pizza."
    /// </para></li><li><para>
    /// A follow-up prompt that asks the user for additional activity. For example, "Do you
    /// want a drink with your pizza?"
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "LMBV2Intent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelsV2.Model.CreateIntentResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 CreateIntent API operation.", Operation = new[] {"CreateIntent"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.CreateIntentResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.CreateIntentResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.CreateIntentResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLMBV2IntentCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        #region Parameter FulfillmentUpdatesSpecification_Active
        /// <summary>
        /// <para>
        /// <para>Determines whether fulfillment updates are sent to the user. When this field is true,
        /// updates are sent.</para><para>If the <code>active</code> field is set to true, the <code>startResponse</code>, <code>updateResponse</code>,
        /// and <code>timeoutInSeconds</code> fields are required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentCodeHook_FulfillmentUpdatesSpecification_Active")]
        public System.Boolean? FulfillmentUpdatesSpecification_Active { get; set; }
        #endregion
        
        #region Parameter IntentClosingSetting_Active
        /// <summary>
        /// <para>
        /// <para>Specifies whether an intent's closing response is used. When this field is false,
        /// the closing response isn't sent to the user. If the <code>active</code> field isn't
        /// specified, the default is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IntentClosingSetting_Active { get; set; }
        #endregion
        
        #region Parameter IntentConfirmationSetting_Active
        /// <summary>
        /// <para>
        /// <para>Specifies whether the intent's confirmation is sent to the user. When this field is
        /// false, confirmation and declination responses aren't sent. If the <code>active</code>
        /// field isn't specified, the default is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IntentConfirmationSetting_Active { get; set; }
        #endregion
        
        #region Parameter StartResponse_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Determines whether the user can interrupt the start message while it is playing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse_AllowInterrupt")]
        public System.Boolean? StartResponse_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter UpdateResponse_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Determines whether the user can interrupt an update message while it is playing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse_AllowInterrupt")]
        public System.Boolean? UpdateResponse_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter FailureResponse_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse_AllowInterrupt")]
        public System.Boolean? FailureResponse_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter SuccessResponse_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse_AllowInterrupt")]
        public System.Boolean? SuccessResponse_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter TimeoutResponse_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse_AllowInterrupt")]
        public System.Boolean? TimeoutResponse_AllowInterrupt { get; set; }
        #endregion
        
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
        /// <para>The identifier of the bot associated with this intent.</para>
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
        /// <para>The identifier of the version of the bot associated with this intent.</para>
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
        
        #region Parameter StartResponse_DelayInSecond
        /// <summary>
        /// <para>
        /// <para>The delay between when the Lambda fulfillment function starts running and the start
        /// message is played. If the Lambda function returns before the delay is over, the start
        /// message isn't played.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse_DelayInSeconds")]
        public System.Int32? StartResponse_DelayInSecond { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the intent. Use the description to help identify the intent in lists.</para>
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
        
        #region Parameter UpdateResponse_FrequencyInSecond
        /// <summary>
        /// <para>
        /// <para>The frequency that a message is sent to the user. When the period ends, Amazon Lex
        /// chooses a message from the message groups and plays it to the user. If the fulfillment
        /// Lambda returns before the first period ends, an update message is not played to the
        /// user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse_FrequencyInSeconds")]
        public System.Int32? UpdateResponse_FrequencyInSecond { get; set; }
        #endregion
        
        #region Parameter InputContext
        /// <summary>
        /// <para>
        /// <para>A list of contexts that must be active for this intent to be considered by Amazon
        /// Lex.</para><para>When an intent has an input context list, Amazon Lex only considers using the intent
        /// in an interaction with the user when the specified contexts are included in the active
        /// context list for the session. If the contexts are not active, then Amazon Lex will
        /// not use the intent.</para><para>A context can be automatically activated using the <code>outputContexts</code> property
        /// or it can be set at runtime.</para><para> For example, if there are two intents with different input contexts that respond
        /// to the same utterances, only the intent with the active context will respond.</para><para>An intent may have up to 5 input contexts. If an intent has multiple input contexts,
        /// all of the contexts must be active to consider the intent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputContexts")]
        public Amazon.LexModelsV2.Model.InputContext[] InputContext { get; set; }
        #endregion
        
        #region Parameter IntentName
        /// <summary>
        /// <para>
        /// <para>The name of the intent. Intent names must be unique in the locale that contains the
        /// intent and cannot match the name of any built-in intent.</para>
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
        /// <para>The identifier of the language and locale where this intent is used. All of the bots,
        /// slot types, and slots used by the intent must have the same locale. For more information,
        /// see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/how-languages.html">Supported
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
        /// <para>The maximum number of times the bot tries to elicit a response from the user using
        /// this prompt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntentConfirmationSetting_PromptSpecification_MaxRetries")]
        public System.Int32? PromptSpecification_MaxRetry { get; set; }
        #endregion
        
        #region Parameter StartResponse_MessageGroup
        /// <summary>
        /// <para>
        /// <para>One to 5 message groups that contain start messages. Amazon Lex chooses one of the
        /// messages to play to the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse_MessageGroups")]
        public Amazon.LexModelsV2.Model.MessageGroup[] StartResponse_MessageGroup { get; set; }
        #endregion
        
        #region Parameter UpdateResponse_MessageGroup
        /// <summary>
        /// <para>
        /// <para>One to 5 message groups that contain update messages. Amazon Lex chooses one of the
        /// messages to play to the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse_MessageGroups")]
        public Amazon.LexModelsV2.Model.MessageGroup[] UpdateResponse_MessageGroup { get; set; }
        #endregion
        
        #region Parameter FailureResponse_MessageGroup
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse_MessageGroups")]
        public Amazon.LexModelsV2.Model.MessageGroup[] FailureResponse_MessageGroup { get; set; }
        #endregion
        
        #region Parameter SuccessResponse_MessageGroup
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse_MessageGroups")]
        public Amazon.LexModelsV2.Model.MessageGroup[] SuccessResponse_MessageGroup { get; set; }
        #endregion
        
        #region Parameter TimeoutResponse_MessageGroup
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse_MessageGroups")]
        public Amazon.LexModelsV2.Model.MessageGroup[] TimeoutResponse_MessageGroup { get; set; }
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
        
        #region Parameter PromptSpecification_MessageSelectionStrategy
        /// <summary>
        /// <para>
        /// <para>Indicates how a message is selected from a message group among retries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntentConfirmationSetting_PromptSpecification_MessageSelectionStrategy")]
        [AWSConstantClassSource("Amazon.LexModelsV2.MessageSelectionStrategy")]
        public Amazon.LexModelsV2.MessageSelectionStrategy PromptSpecification_MessageSelectionStrategy { get; set; }
        #endregion
        
        #region Parameter OutputContext
        /// <summary>
        /// <para>
        /// <para>A lists of contexts that the intent activates when it is fulfilled.</para><para>You can use an output context to indicate the intents that Amazon Lex should consider
        /// for the next turn of the conversation with a customer. </para><para>When you use the <code>outputContextsList</code> property, all of the contexts specified
        /// in the list are activated when the intent is fulfilled. You can set up to 10 output
        /// contexts. You can also set the number of conversation turns that the context should
        /// be active, or the length of time that the context should be active.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputContexts")]
        public Amazon.LexModelsV2.Model.OutputContext[] OutputContext { get; set; }
        #endregion
        
        #region Parameter ParentIntentSignature
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the built-in intent to base this intent on.</para>
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
        /// <para>An array of strings that a user might say to signal the intent. For example, "I want
        /// a pizza", or "I want a {PizzaSize} pizza". </para><para>In an utterance, slot names are enclosed in curly braces ("{", "}") to indicate where
        /// they should be displayed in the utterance shown to the user.. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SampleUtterances")]
        public Amazon.LexModelsV2.Model.SampleUtterance[] SampleUtterance { get; set; }
        #endregion
        
        #region Parameter FulfillmentUpdatesSpecification_TimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The length of time that the fulfillment Lambda function should run before it times
        /// out.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentCodeHook_FulfillmentUpdatesSpecification_TimeoutInSeconds")]
        public System.Int32? FulfillmentUpdatesSpecification_TimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.CreateIntentResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.CreateIntentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IntentName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IntentName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IntentName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IntentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LMBV2Intent (CreateIntent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.CreateIntentResponse, NewLMBV2IntentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IntentName;
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
            context.FulfillmentUpdatesSpecification_Active = this.FulfillmentUpdatesSpecification_Active;
            context.StartResponse_AllowInterrupt = this.StartResponse_AllowInterrupt;
            context.StartResponse_DelayInSecond = this.StartResponse_DelayInSecond;
            if (this.StartResponse_MessageGroup != null)
            {
                context.StartResponse_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.StartResponse_MessageGroup);
            }
            context.FulfillmentUpdatesSpecification_TimeoutInSecond = this.FulfillmentUpdatesSpecification_TimeoutInSecond;
            context.UpdateResponse_AllowInterrupt = this.UpdateResponse_AllowInterrupt;
            context.UpdateResponse_FrequencyInSecond = this.UpdateResponse_FrequencyInSecond;
            if (this.UpdateResponse_MessageGroup != null)
            {
                context.UpdateResponse_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.UpdateResponse_MessageGroup);
            }
            context.FailureResponse_AllowInterrupt = this.FailureResponse_AllowInterrupt;
            if (this.FailureResponse_MessageGroup != null)
            {
                context.FailureResponse_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.FailureResponse_MessageGroup);
            }
            context.SuccessResponse_AllowInterrupt = this.SuccessResponse_AllowInterrupt;
            if (this.SuccessResponse_MessageGroup != null)
            {
                context.SuccessResponse_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.SuccessResponse_MessageGroup);
            }
            context.TimeoutResponse_AllowInterrupt = this.TimeoutResponse_AllowInterrupt;
            if (this.TimeoutResponse_MessageGroup != null)
            {
                context.TimeoutResponse_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.TimeoutResponse_MessageGroup);
            }
            if (this.InputContext != null)
            {
                context.InputContext = new List<Amazon.LexModelsV2.Model.InputContext>(this.InputContext);
            }
            context.IntentClosingSetting_Active = this.IntentClosingSetting_Active;
            context.ClosingResponse_AllowInterrupt = this.ClosingResponse_AllowInterrupt;
            if (this.ClosingResponse_MessageGroup != null)
            {
                context.ClosingResponse_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.ClosingResponse_MessageGroup);
            }
            context.IntentConfirmationSetting_Active = this.IntentConfirmationSetting_Active;
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
            context.PromptSpecification_MessageSelectionStrategy = this.PromptSpecification_MessageSelectionStrategy;
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
            var request = new Amazon.LexModelsV2.Model.CreateIntentRequest();
            
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
            Amazon.LexModelsV2.Model.PostFulfillmentStatusSpecification requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification = null;
            
             // populate PostFulfillmentStatusSpecification
            var requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecificationIsNull = true;
            requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification = new Amazon.LexModelsV2.Model.PostFulfillmentStatusSpecification();
            Amazon.LexModelsV2.Model.ResponseSpecification requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse = null;
            
             // populate FailureResponse
            var requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponseIsNull = true;
            requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse_failureResponse_AllowInterrupt = null;
            if (cmdletContext.FailureResponse_AllowInterrupt != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse_failureResponse_AllowInterrupt = cmdletContext.FailureResponse_AllowInterrupt.Value;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse_failureResponse_AllowInterrupt != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse.AllowInterrupt = requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse_failureResponse_AllowInterrupt.Value;
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse_failureResponse_MessageGroup = null;
            if (cmdletContext.FailureResponse_MessageGroup != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse_failureResponse_MessageGroup = cmdletContext.FailureResponse_MessageGroup;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse_failureResponse_MessageGroup != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse.MessageGroups = requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse_failureResponse_MessageGroup;
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponseIsNull = false;
            }
             // determine if requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse should be set to null
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponseIsNull)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse = null;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification.FailureResponse = requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureResponse;
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.ResponseSpecification requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse = null;
            
             // populate SuccessResponse
            var requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponseIsNull = true;
            requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse_successResponse_AllowInterrupt = null;
            if (cmdletContext.SuccessResponse_AllowInterrupt != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse_successResponse_AllowInterrupt = cmdletContext.SuccessResponse_AllowInterrupt.Value;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse_successResponse_AllowInterrupt != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse.AllowInterrupt = requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse_successResponse_AllowInterrupt.Value;
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse_successResponse_MessageGroup = null;
            if (cmdletContext.SuccessResponse_MessageGroup != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse_successResponse_MessageGroup = cmdletContext.SuccessResponse_MessageGroup;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse_successResponse_MessageGroup != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse.MessageGroups = requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse_successResponse_MessageGroup;
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponseIsNull = false;
            }
             // determine if requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse should be set to null
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponseIsNull)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse = null;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification.SuccessResponse = requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessResponse;
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.ResponseSpecification requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse = null;
            
             // populate TimeoutResponse
            var requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponseIsNull = true;
            requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse_timeoutResponse_AllowInterrupt = null;
            if (cmdletContext.TimeoutResponse_AllowInterrupt != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse_timeoutResponse_AllowInterrupt = cmdletContext.TimeoutResponse_AllowInterrupt.Value;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse_timeoutResponse_AllowInterrupt != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse.AllowInterrupt = requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse_timeoutResponse_AllowInterrupt.Value;
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse_timeoutResponse_MessageGroup = null;
            if (cmdletContext.TimeoutResponse_MessageGroup != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse_timeoutResponse_MessageGroup = cmdletContext.TimeoutResponse_MessageGroup;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse_timeoutResponse_MessageGroup != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse.MessageGroups = requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse_timeoutResponse_MessageGroup;
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponseIsNull = false;
            }
             // determine if requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse should be set to null
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponseIsNull)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse = null;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification.TimeoutResponse = requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification_fulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutResponse;
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecificationIsNull = false;
            }
             // determine if requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification should be set to null
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecificationIsNull)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification = null;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification != null)
            {
                request.FulfillmentCodeHook.PostFulfillmentStatusSpecification = requestFulfillmentCodeHook_fulfillmentCodeHook_PostFulfillmentStatusSpecification;
                requestFulfillmentCodeHookIsNull = false;
            }
            Amazon.LexModelsV2.Model.FulfillmentUpdatesSpecification requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification = null;
            
             // populate FulfillmentUpdatesSpecification
            var requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecificationIsNull = true;
            requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification = new Amazon.LexModelsV2.Model.FulfillmentUpdatesSpecification();
            System.Boolean? requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentUpdatesSpecification_Active = null;
            if (cmdletContext.FulfillmentUpdatesSpecification_Active != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentUpdatesSpecification_Active = cmdletContext.FulfillmentUpdatesSpecification_Active.Value;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentUpdatesSpecification_Active != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification.Active = requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentUpdatesSpecification_Active.Value;
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecificationIsNull = false;
            }
            System.Int32? requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentUpdatesSpecification_TimeoutInSecond = null;
            if (cmdletContext.FulfillmentUpdatesSpecification_TimeoutInSecond != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentUpdatesSpecification_TimeoutInSecond = cmdletContext.FulfillmentUpdatesSpecification_TimeoutInSecond.Value;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentUpdatesSpecification_TimeoutInSecond != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification.TimeoutInSeconds = requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentUpdatesSpecification_TimeoutInSecond.Value;
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.FulfillmentStartResponseSpecification requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse = null;
            
             // populate StartResponse
            var requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponseIsNull = true;
            requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse = new Amazon.LexModelsV2.Model.FulfillmentStartResponseSpecification();
            System.Boolean? requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse_startResponse_AllowInterrupt = null;
            if (cmdletContext.StartResponse_AllowInterrupt != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse_startResponse_AllowInterrupt = cmdletContext.StartResponse_AllowInterrupt.Value;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse_startResponse_AllowInterrupt != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse.AllowInterrupt = requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse_startResponse_AllowInterrupt.Value;
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponseIsNull = false;
            }
            System.Int32? requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse_startResponse_DelayInSecond = null;
            if (cmdletContext.StartResponse_DelayInSecond != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse_startResponse_DelayInSecond = cmdletContext.StartResponse_DelayInSecond.Value;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse_startResponse_DelayInSecond != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse.DelayInSeconds = requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse_startResponse_DelayInSecond.Value;
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse_startResponse_MessageGroup = null;
            if (cmdletContext.StartResponse_MessageGroup != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse_startResponse_MessageGroup = cmdletContext.StartResponse_MessageGroup;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse_startResponse_MessageGroup != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse.MessageGroups = requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse_startResponse_MessageGroup;
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponseIsNull = false;
            }
             // determine if requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse should be set to null
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponseIsNull)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse = null;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification.StartResponse = requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_StartResponse;
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.FulfillmentUpdateResponseSpecification requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse = null;
            
             // populate UpdateResponse
            var requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponseIsNull = true;
            requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse = new Amazon.LexModelsV2.Model.FulfillmentUpdateResponseSpecification();
            System.Boolean? requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse_updateResponse_AllowInterrupt = null;
            if (cmdletContext.UpdateResponse_AllowInterrupt != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse_updateResponse_AllowInterrupt = cmdletContext.UpdateResponse_AllowInterrupt.Value;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse_updateResponse_AllowInterrupt != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse.AllowInterrupt = requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse_updateResponse_AllowInterrupt.Value;
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponseIsNull = false;
            }
            System.Int32? requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse_updateResponse_FrequencyInSecond = null;
            if (cmdletContext.UpdateResponse_FrequencyInSecond != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse_updateResponse_FrequencyInSecond = cmdletContext.UpdateResponse_FrequencyInSecond.Value;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse_updateResponse_FrequencyInSecond != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse.FrequencyInSeconds = requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse_updateResponse_FrequencyInSecond.Value;
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse_updateResponse_MessageGroup = null;
            if (cmdletContext.UpdateResponse_MessageGroup != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse_updateResponse_MessageGroup = cmdletContext.UpdateResponse_MessageGroup;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse_updateResponse_MessageGroup != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse.MessageGroups = requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse_updateResponse_MessageGroup;
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponseIsNull = false;
            }
             // determine if requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse should be set to null
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponseIsNull)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse = null;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse != null)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification.UpdateResponse = requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification_fulfillmentCodeHook_FulfillmentUpdatesSpecification_UpdateResponse;
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecificationIsNull = false;
            }
             // determine if requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification should be set to null
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecificationIsNull)
            {
                requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification = null;
            }
            if (requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification != null)
            {
                request.FulfillmentCodeHook.FulfillmentUpdatesSpecification = requestFulfillmentCodeHook_fulfillmentCodeHook_FulfillmentUpdatesSpecification;
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
            System.Boolean? requestIntentClosingSetting_intentClosingSetting_Active = null;
            if (cmdletContext.IntentClosingSetting_Active != null)
            {
                requestIntentClosingSetting_intentClosingSetting_Active = cmdletContext.IntentClosingSetting_Active.Value;
            }
            if (requestIntentClosingSetting_intentClosingSetting_Active != null)
            {
                request.IntentClosingSetting.Active = requestIntentClosingSetting_intentClosingSetting_Active.Value;
                requestIntentClosingSettingIsNull = false;
            }
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
            System.Boolean? requestIntentConfirmationSetting_intentConfirmationSetting_Active = null;
            if (cmdletContext.IntentConfirmationSetting_Active != null)
            {
                requestIntentConfirmationSetting_intentConfirmationSetting_Active = cmdletContext.IntentConfirmationSetting_Active.Value;
            }
            if (requestIntentConfirmationSetting_intentConfirmationSetting_Active != null)
            {
                request.IntentConfirmationSetting.Active = requestIntentConfirmationSetting_intentConfirmationSetting_Active.Value;
                requestIntentConfirmationSettingIsNull = false;
            }
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
            Amazon.LexModelsV2.MessageSelectionStrategy requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_MessageSelectionStrategy = null;
            if (cmdletContext.PromptSpecification_MessageSelectionStrategy != null)
            {
                requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_MessageSelectionStrategy = cmdletContext.PromptSpecification_MessageSelectionStrategy;
            }
            if (requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_MessageSelectionStrategy != null)
            {
                requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification.MessageSelectionStrategy = requestIntentConfirmationSetting_intentConfirmationSetting_PromptSpecification_promptSpecification_MessageSelectionStrategy;
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
        
        private Amazon.LexModelsV2.Model.CreateIntentResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.CreateIntentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "CreateIntent");
            try
            {
                #if DESKTOP
                return client.CreateIntent(request);
                #elif CORECLR
                return client.CreateIntentAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? FulfillmentUpdatesSpecification_Active { get; set; }
            public System.Boolean? StartResponse_AllowInterrupt { get; set; }
            public System.Int32? StartResponse_DelayInSecond { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> StartResponse_MessageGroup { get; set; }
            public System.Int32? FulfillmentUpdatesSpecification_TimeoutInSecond { get; set; }
            public System.Boolean? UpdateResponse_AllowInterrupt { get; set; }
            public System.Int32? UpdateResponse_FrequencyInSecond { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> UpdateResponse_MessageGroup { get; set; }
            public System.Boolean? FailureResponse_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> FailureResponse_MessageGroup { get; set; }
            public System.Boolean? SuccessResponse_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> SuccessResponse_MessageGroup { get; set; }
            public System.Boolean? TimeoutResponse_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> TimeoutResponse_MessageGroup { get; set; }
            public List<Amazon.LexModelsV2.Model.InputContext> InputContext { get; set; }
            public System.Boolean? IntentClosingSetting_Active { get; set; }
            public System.Boolean? ClosingResponse_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> ClosingResponse_MessageGroup { get; set; }
            public System.Boolean? IntentConfirmationSetting_Active { get; set; }
            public System.Boolean? DeclinationResponse_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> DeclinationResponse_MessageGroup { get; set; }
            public System.Boolean? PromptSpecification_AllowInterrupt { get; set; }
            public System.Int32? PromptSpecification_MaxRetry { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> PromptSpecification_MessageGroup { get; set; }
            public Amazon.LexModelsV2.MessageSelectionStrategy PromptSpecification_MessageSelectionStrategy { get; set; }
            public System.String IntentName { get; set; }
            public System.String KendraConfiguration_KendraIndex { get; set; }
            public System.String KendraConfiguration_QueryFilterString { get; set; }
            public System.Boolean? KendraConfiguration_QueryFilterStringEnabled { get; set; }
            public System.String LocaleId { get; set; }
            public List<Amazon.LexModelsV2.Model.OutputContext> OutputContext { get; set; }
            public System.String ParentIntentSignature { get; set; }
            public List<Amazon.LexModelsV2.Model.SampleUtterance> SampleUtterance { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.CreateIntentResponse, NewLMBV2IntentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
