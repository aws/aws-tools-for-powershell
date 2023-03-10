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
using Amazon.LexRuntimeV2;
using Amazon.LexRuntimeV2.Model;

namespace Amazon.PowerShell.Cmdlets.LRSV2
{
    /// <summary>
    /// Sends user input to Amazon Lex V2. Client applications use this API to send requests
    /// to Amazon Lex V2 at runtime. Amazon Lex V2 then interprets the user input using the
    /// machine learning model that it build for the bot.
    /// 
    ///  
    /// <para>
    /// In response, Amazon Lex V2 returns the next message to convey to the user and an optional
    /// response card to display.
    /// </para><para>
    /// If the optional post-fulfillment response is specified, the messages are returned
    /// as follows. For more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/API_PostFulfillmentStatusSpecification.html">PostFulfillmentStatusSpecification</a>.
    /// </para><ul><li><para><b>Success message</b> - Returned if the Lambda function completes successfully and
    /// the intent state is fulfilled or ready fulfillment if the message is present.
    /// </para></li><li><para><b>Failed message</b> - The failed message is returned if the Lambda function throws
    /// an exception or if the Lambda function returns a failed intent state without a message.
    /// </para></li><li><para><b>Timeout message</b> - If you don't configure a timeout message and a timeout,
    /// and the Lambda function doesn't return within 30 seconds, the timeout message is returned.
    /// If you configure a timeout, the timeout message is returned when the period times
    /// out. 
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/streaming-progress.html#progress-complete.html">Completion
    /// message</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Send", "LRSV2Text", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexRuntimeV2.Model.RecognizeTextResponse")]
    [AWSCmdlet("Calls the Amazon Lex Runtime V2 RecognizeText API operation.", Operation = new[] {"RecognizeText"}, SelectReturnType = typeof(Amazon.LexRuntimeV2.Model.RecognizeTextResponse))]
    [AWSCmdletOutput("Amazon.LexRuntimeV2.Model.RecognizeTextResponse",
        "This cmdlet returns an Amazon.LexRuntimeV2.Model.RecognizeTextResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendLRSV2TextCmdlet : AmazonLexRuntimeV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter SessionStateValue_ActiveContext
        /// <summary>
        /// <para>
        /// <para>One or more contexts that indicate to Amazon Lex V2 the context of a request. When
        /// a context is active, Amazon Lex V2 considers intents with the matching context as
        /// a trigger as the next intent in a session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionStateValue_ActiveContexts")]
        public Amazon.LexRuntimeV2.Model.ActiveContext[] SessionStateValue_ActiveContext { get; set; }
        #endregion
        
        #region Parameter BotAliasId
        /// <summary>
        /// <para>
        /// <para>The alias identifier in use for the bot that processes the request.</para>
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
        public System.String BotAliasId { get; set; }
        #endregion
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The identifier of the bot that processes the request.</para>
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
        
        #region Parameter Intent_ConfirmationState
        /// <summary>
        /// <para>
        /// <para>Contains information about whether fulfillment of the intent has been confirmed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionStateValue_Intent_ConfirmationState")]
        [AWSConstantClassSource("Amazon.LexRuntimeV2.ConfirmationState")]
        public Amazon.LexRuntimeV2.ConfirmationState Intent_ConfirmationState { get; set; }
        #endregion
        
        #region Parameter LocaleId
        /// <summary>
        /// <para>
        /// <para>The locale where the session is in use.</para>
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
        
        #region Parameter Intent_Name
        /// <summary>
        /// <para>
        /// <para>The name of the intent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionStateValue_Intent_Name")]
        public System.String Intent_Name { get; set; }
        #endregion
        
        #region Parameter SessionStateValue_OriginatingRequestId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a specific request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionStateValue_OriginatingRequestId { get; set; }
        #endregion
        
        #region Parameter RequestAttribute
        /// <summary>
        /// <para>
        /// <para>Request-specific information passed between the client application and Amazon Lex
        /// V2 </para><para>The namespace <code>x-amz-lex:</code> is reserved for special attributes. Don't create
        /// any request attributes with the prefix <code>x-amz-lex:</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestAttributes")]
        public System.Collections.Hashtable RequestAttribute { get; set; }
        #endregion
        
        #region Parameter SessionStateValue_SessionAttribute
        /// <summary>
        /// <para>
        /// <para>Map of key/value pairs representing session-specific context information. It contains
        /// application information passed between Amazon Lex V2 and a client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionStateValue_SessionAttributes")]
        public System.Collections.Hashtable SessionStateValue_SessionAttribute { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the user session that is having the conversation.</para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter DialogAction_SlotElicitationStyle
        /// <summary>
        /// <para>
        /// <para>Configures the slot to use spell-by-letter or spell-by-word style. When you use a
        /// style on a slot, users can spell out their input to make it clear to your bot.</para><ul><li><para>Spell by letter - "b" "o" "b"</para></li><li><para>Spell by word - "b as in boy" "o as in oscar" "b as in boy"</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/using-spelling.html">
        /// Using spelling to enter slot values </a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionStateValue_DialogAction_SlotElicitationStyle")]
        [AWSConstantClassSource("Amazon.LexRuntimeV2.StyleType")]
        public Amazon.LexRuntimeV2.StyleType DialogAction_SlotElicitationStyle { get; set; }
        #endregion
        
        #region Parameter RuntimeHints_SlotHint
        /// <summary>
        /// <para>
        /// <para>A list of the slots in the intent that should have runtime hints added, and the phrases
        /// that should be added for each slot.</para><para>The first level of the <code>slotHints</code> map is the name of the intent. The second
        /// level is the name of the slot within the intent. For more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/using-hints.html">Using
        /// hints to improve accuracy</a>.</para><para>The intent name and slot name must exist.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionStateValue_RuntimeHints_SlotHints")]
        public System.Collections.Hashtable RuntimeHints_SlotHint { get; set; }
        #endregion
        
        #region Parameter Intent_Slot
        /// <summary>
        /// <para>
        /// <para>A map of all of the slots for the intent. The name of the slot maps to the value of
        /// the slot. If a slot has not been filled, the value is null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionStateValue_Intent_Slots")]
        public System.Collections.Hashtable Intent_Slot { get; set; }
        #endregion
        
        #region Parameter DialogAction_SlotToElicit
        /// <summary>
        /// <para>
        /// <para>The name of the slot that should be elicited from the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionStateValue_DialogAction_SlotToElicit")]
        public System.String DialogAction_SlotToElicit { get; set; }
        #endregion
        
        #region Parameter Intent_State
        /// <summary>
        /// <para>
        /// <para>Contains fulfillment information for the intent. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionStateValue_Intent_State")]
        [AWSConstantClassSource("Amazon.LexRuntimeV2.IntentState")]
        public Amazon.LexRuntimeV2.IntentState Intent_State { get; set; }
        #endregion
        
        #region Parameter DialogAction_SubSlotToElicit
        /// <summary>
        /// <para>
        /// <para>The name of the constituent sub slot of the composite slot specified in slotToElicit
        /// that should be elicited from the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionStateValue_DialogAction_SubSlotToElicit")]
        public Amazon.LexRuntimeV2.Model.ElicitSubSlot DialogAction_SubSlotToElicit { get; set; }
        #endregion
        
        #region Parameter Text
        /// <summary>
        /// <para>
        /// <para>The text that the user entered. Amazon Lex V2 interprets this text.</para>
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
        public System.String Text { get; set; }
        #endregion
        
        #region Parameter DialogAction_Type
        /// <summary>
        /// <para>
        /// <para>The next action that the bot should take in its interaction with the user. The possible
        /// values are:</para><ul><li><para><code>Close</code> - Indicates that there will not be a response from the user. For
        /// example, the statement "Your order has been placed" does not require a response.</para></li><li><para><code>ConfirmIntent</code> - The next action is asking the user if the intent is
        /// complete and ready to be fulfilled. This is a yes/no question such as "Place the order?"</para></li><li><para><code>Delegate</code> - The next action is determined by Amazon Lex V2.</para></li><li><para><code>ElicitIntent</code> - The next action is to elicit an intent from the user.</para></li><li><para><code>ElicitSlot</code> - The next action is to elicit a slot value from the user.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionStateValue_DialogAction_Type")]
        [AWSConstantClassSource("Amazon.LexRuntimeV2.DialogActionType")]
        public Amazon.LexRuntimeV2.DialogActionType DialogAction_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexRuntimeV2.Model.RecognizeTextResponse).
        /// Specifying the name of a property of type Amazon.LexRuntimeV2.Model.RecognizeTextResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Text parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Text' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Text' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-LRSV2Text (RecognizeText)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexRuntimeV2.Model.RecognizeTextResponse, SendLRSV2TextCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Text;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BotAliasId = this.BotAliasId;
            #if MODULAR
            if (this.BotAliasId == null && ParameterWasBound(nameof(this.BotAliasId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotAliasId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotId = this.BotId;
            #if MODULAR
            if (this.BotId == null && ParameterWasBound(nameof(this.BotId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LocaleId = this.LocaleId;
            #if MODULAR
            if (this.LocaleId == null && ParameterWasBound(nameof(this.LocaleId)))
            {
                WriteWarning("You are passing $null as a value for parameter LocaleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RequestAttribute != null)
            {
                context.RequestAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestAttribute.Keys)
                {
                    context.RequestAttribute.Add((String)hashKey, (String)(this.RequestAttribute[hashKey]));
                }
            }
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SessionStateValue_ActiveContext != null)
            {
                context.SessionStateValue_ActiveContext = new List<Amazon.LexRuntimeV2.Model.ActiveContext>(this.SessionStateValue_ActiveContext);
            }
            context.DialogAction_SlotElicitationStyle = this.DialogAction_SlotElicitationStyle;
            context.DialogAction_SlotToElicit = this.DialogAction_SlotToElicit;
            context.DialogAction_SubSlotToElicit = this.DialogAction_SubSlotToElicit;
            context.DialogAction_Type = this.DialogAction_Type;
            context.Intent_ConfirmationState = this.Intent_ConfirmationState;
            context.Intent_Name = this.Intent_Name;
            if (this.Intent_Slot != null)
            {
                context.Intent_Slot = new Dictionary<System.String, Amazon.LexRuntimeV2.Model.Slot>(StringComparer.Ordinal);
                foreach (var hashKey in this.Intent_Slot.Keys)
                {
                    context.Intent_Slot.Add((String)hashKey, (Slot)(this.Intent_Slot[hashKey]));
                }
            }
            context.Intent_State = this.Intent_State;
            context.SessionStateValue_OriginatingRequestId = this.SessionStateValue_OriginatingRequestId;
            if (this.RuntimeHints_SlotHint != null)
            {
                context.RuntimeHints_SlotHint = new Dictionary<System.String, Dictionary<System.String, Amazon.LexRuntimeV2.Model.RuntimeHintDetails>>(StringComparer.Ordinal);
                foreach (var hashKey in this.RuntimeHints_SlotHint.Keys)
                {
                    context.RuntimeHints_SlotHint.Add((String)hashKey, (Dictionary<String,RuntimeHintDetails>)(this.RuntimeHints_SlotHint[hashKey]));
                }
            }
            if (this.SessionStateValue_SessionAttribute != null)
            {
                context.SessionStateValue_SessionAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SessionStateValue_SessionAttribute.Keys)
                {
                    context.SessionStateValue_SessionAttribute.Add((String)hashKey, (String)(this.SessionStateValue_SessionAttribute[hashKey]));
                }
            }
            context.Text = this.Text;
            #if MODULAR
            if (this.Text == null && ParameterWasBound(nameof(this.Text)))
            {
                WriteWarning("You are passing $null as a value for parameter Text which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LexRuntimeV2.Model.RecognizeTextRequest();
            
            if (cmdletContext.BotAliasId != null)
            {
                request.BotAliasId = cmdletContext.BotAliasId;
            }
            if (cmdletContext.BotId != null)
            {
                request.BotId = cmdletContext.BotId;
            }
            if (cmdletContext.LocaleId != null)
            {
                request.LocaleId = cmdletContext.LocaleId;
            }
            if (cmdletContext.RequestAttribute != null)
            {
                request.RequestAttributes = cmdletContext.RequestAttribute;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            
             // populate SessionStateValue
            var requestSessionStateValueIsNull = true;
            request.SessionStateValue = new Amazon.LexRuntimeV2.Model.SessionState();
            List<Amazon.LexRuntimeV2.Model.ActiveContext> requestSessionStateValue_sessionStateValue_ActiveContext = null;
            if (cmdletContext.SessionStateValue_ActiveContext != null)
            {
                requestSessionStateValue_sessionStateValue_ActiveContext = cmdletContext.SessionStateValue_ActiveContext;
            }
            if (requestSessionStateValue_sessionStateValue_ActiveContext != null)
            {
                request.SessionStateValue.ActiveContexts = requestSessionStateValue_sessionStateValue_ActiveContext;
                requestSessionStateValueIsNull = false;
            }
            System.String requestSessionStateValue_sessionStateValue_OriginatingRequestId = null;
            if (cmdletContext.SessionStateValue_OriginatingRequestId != null)
            {
                requestSessionStateValue_sessionStateValue_OriginatingRequestId = cmdletContext.SessionStateValue_OriginatingRequestId;
            }
            if (requestSessionStateValue_sessionStateValue_OriginatingRequestId != null)
            {
                request.SessionStateValue.OriginatingRequestId = requestSessionStateValue_sessionStateValue_OriginatingRequestId;
                requestSessionStateValueIsNull = false;
            }
            Dictionary<System.String, System.String> requestSessionStateValue_sessionStateValue_SessionAttribute = null;
            if (cmdletContext.SessionStateValue_SessionAttribute != null)
            {
                requestSessionStateValue_sessionStateValue_SessionAttribute = cmdletContext.SessionStateValue_SessionAttribute;
            }
            if (requestSessionStateValue_sessionStateValue_SessionAttribute != null)
            {
                request.SessionStateValue.SessionAttributes = requestSessionStateValue_sessionStateValue_SessionAttribute;
                requestSessionStateValueIsNull = false;
            }
            Amazon.LexRuntimeV2.Model.RuntimeHints requestSessionStateValue_sessionStateValue_RuntimeHints = null;
            
             // populate RuntimeHints
            var requestSessionStateValue_sessionStateValue_RuntimeHintsIsNull = true;
            requestSessionStateValue_sessionStateValue_RuntimeHints = new Amazon.LexRuntimeV2.Model.RuntimeHints();
            Dictionary<System.String, Dictionary<System.String, Amazon.LexRuntimeV2.Model.RuntimeHintDetails>> requestSessionStateValue_sessionStateValue_RuntimeHints_runtimeHints_SlotHint = null;
            if (cmdletContext.RuntimeHints_SlotHint != null)
            {
                requestSessionStateValue_sessionStateValue_RuntimeHints_runtimeHints_SlotHint = cmdletContext.RuntimeHints_SlotHint;
            }
            if (requestSessionStateValue_sessionStateValue_RuntimeHints_runtimeHints_SlotHint != null)
            {
                requestSessionStateValue_sessionStateValue_RuntimeHints.SlotHints = requestSessionStateValue_sessionStateValue_RuntimeHints_runtimeHints_SlotHint;
                requestSessionStateValue_sessionStateValue_RuntimeHintsIsNull = false;
            }
             // determine if requestSessionStateValue_sessionStateValue_RuntimeHints should be set to null
            if (requestSessionStateValue_sessionStateValue_RuntimeHintsIsNull)
            {
                requestSessionStateValue_sessionStateValue_RuntimeHints = null;
            }
            if (requestSessionStateValue_sessionStateValue_RuntimeHints != null)
            {
                request.SessionStateValue.RuntimeHints = requestSessionStateValue_sessionStateValue_RuntimeHints;
                requestSessionStateValueIsNull = false;
            }
            Amazon.LexRuntimeV2.Model.DialogAction requestSessionStateValue_sessionStateValue_DialogAction = null;
            
             // populate DialogAction
            var requestSessionStateValue_sessionStateValue_DialogActionIsNull = true;
            requestSessionStateValue_sessionStateValue_DialogAction = new Amazon.LexRuntimeV2.Model.DialogAction();
            Amazon.LexRuntimeV2.StyleType requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_SlotElicitationStyle = null;
            if (cmdletContext.DialogAction_SlotElicitationStyle != null)
            {
                requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_SlotElicitationStyle = cmdletContext.DialogAction_SlotElicitationStyle;
            }
            if (requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_SlotElicitationStyle != null)
            {
                requestSessionStateValue_sessionStateValue_DialogAction.SlotElicitationStyle = requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_SlotElicitationStyle;
                requestSessionStateValue_sessionStateValue_DialogActionIsNull = false;
            }
            System.String requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_SlotToElicit = null;
            if (cmdletContext.DialogAction_SlotToElicit != null)
            {
                requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_SlotToElicit = cmdletContext.DialogAction_SlotToElicit;
            }
            if (requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_SlotToElicit != null)
            {
                requestSessionStateValue_sessionStateValue_DialogAction.SlotToElicit = requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_SlotToElicit;
                requestSessionStateValue_sessionStateValue_DialogActionIsNull = false;
            }
            Amazon.LexRuntimeV2.Model.ElicitSubSlot requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_SubSlotToElicit = null;
            if (cmdletContext.DialogAction_SubSlotToElicit != null)
            {
                requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_SubSlotToElicit = cmdletContext.DialogAction_SubSlotToElicit;
            }
            if (requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_SubSlotToElicit != null)
            {
                requestSessionStateValue_sessionStateValue_DialogAction.SubSlotToElicit = requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_SubSlotToElicit;
                requestSessionStateValue_sessionStateValue_DialogActionIsNull = false;
            }
            Amazon.LexRuntimeV2.DialogActionType requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_Type = null;
            if (cmdletContext.DialogAction_Type != null)
            {
                requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_Type = cmdletContext.DialogAction_Type;
            }
            if (requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_Type != null)
            {
                requestSessionStateValue_sessionStateValue_DialogAction.Type = requestSessionStateValue_sessionStateValue_DialogAction_dialogAction_Type;
                requestSessionStateValue_sessionStateValue_DialogActionIsNull = false;
            }
             // determine if requestSessionStateValue_sessionStateValue_DialogAction should be set to null
            if (requestSessionStateValue_sessionStateValue_DialogActionIsNull)
            {
                requestSessionStateValue_sessionStateValue_DialogAction = null;
            }
            if (requestSessionStateValue_sessionStateValue_DialogAction != null)
            {
                request.SessionStateValue.DialogAction = requestSessionStateValue_sessionStateValue_DialogAction;
                requestSessionStateValueIsNull = false;
            }
            Amazon.LexRuntimeV2.Model.Intent requestSessionStateValue_sessionStateValue_Intent = null;
            
             // populate Intent
            var requestSessionStateValue_sessionStateValue_IntentIsNull = true;
            requestSessionStateValue_sessionStateValue_Intent = new Amazon.LexRuntimeV2.Model.Intent();
            Amazon.LexRuntimeV2.ConfirmationState requestSessionStateValue_sessionStateValue_Intent_intent_ConfirmationState = null;
            if (cmdletContext.Intent_ConfirmationState != null)
            {
                requestSessionStateValue_sessionStateValue_Intent_intent_ConfirmationState = cmdletContext.Intent_ConfirmationState;
            }
            if (requestSessionStateValue_sessionStateValue_Intent_intent_ConfirmationState != null)
            {
                requestSessionStateValue_sessionStateValue_Intent.ConfirmationState = requestSessionStateValue_sessionStateValue_Intent_intent_ConfirmationState;
                requestSessionStateValue_sessionStateValue_IntentIsNull = false;
            }
            System.String requestSessionStateValue_sessionStateValue_Intent_intent_Name = null;
            if (cmdletContext.Intent_Name != null)
            {
                requestSessionStateValue_sessionStateValue_Intent_intent_Name = cmdletContext.Intent_Name;
            }
            if (requestSessionStateValue_sessionStateValue_Intent_intent_Name != null)
            {
                requestSessionStateValue_sessionStateValue_Intent.Name = requestSessionStateValue_sessionStateValue_Intent_intent_Name;
                requestSessionStateValue_sessionStateValue_IntentIsNull = false;
            }
            Dictionary<System.String, Amazon.LexRuntimeV2.Model.Slot> requestSessionStateValue_sessionStateValue_Intent_intent_Slot = null;
            if (cmdletContext.Intent_Slot != null)
            {
                requestSessionStateValue_sessionStateValue_Intent_intent_Slot = cmdletContext.Intent_Slot;
            }
            if (requestSessionStateValue_sessionStateValue_Intent_intent_Slot != null)
            {
                requestSessionStateValue_sessionStateValue_Intent.Slots = requestSessionStateValue_sessionStateValue_Intent_intent_Slot;
                requestSessionStateValue_sessionStateValue_IntentIsNull = false;
            }
            Amazon.LexRuntimeV2.IntentState requestSessionStateValue_sessionStateValue_Intent_intent_State = null;
            if (cmdletContext.Intent_State != null)
            {
                requestSessionStateValue_sessionStateValue_Intent_intent_State = cmdletContext.Intent_State;
            }
            if (requestSessionStateValue_sessionStateValue_Intent_intent_State != null)
            {
                requestSessionStateValue_sessionStateValue_Intent.State = requestSessionStateValue_sessionStateValue_Intent_intent_State;
                requestSessionStateValue_sessionStateValue_IntentIsNull = false;
            }
             // determine if requestSessionStateValue_sessionStateValue_Intent should be set to null
            if (requestSessionStateValue_sessionStateValue_IntentIsNull)
            {
                requestSessionStateValue_sessionStateValue_Intent = null;
            }
            if (requestSessionStateValue_sessionStateValue_Intent != null)
            {
                request.SessionStateValue.Intent = requestSessionStateValue_sessionStateValue_Intent;
                requestSessionStateValueIsNull = false;
            }
             // determine if request.SessionStateValue should be set to null
            if (requestSessionStateValueIsNull)
            {
                request.SessionStateValue = null;
            }
            if (cmdletContext.Text != null)
            {
                request.Text = cmdletContext.Text;
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
        
        private Amazon.LexRuntimeV2.Model.RecognizeTextResponse CallAWSServiceOperation(IAmazonLexRuntimeV2 client, Amazon.LexRuntimeV2.Model.RecognizeTextRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Runtime V2", "RecognizeText");
            try
            {
                #if DESKTOP
                return client.RecognizeText(request);
                #elif CORECLR
                return client.RecognizeTextAsync(request).GetAwaiter().GetResult();
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
            public System.String BotAliasId { get; set; }
            public System.String BotId { get; set; }
            public System.String LocaleId { get; set; }
            public Dictionary<System.String, System.String> RequestAttribute { get; set; }
            public System.String SessionId { get; set; }
            public List<Amazon.LexRuntimeV2.Model.ActiveContext> SessionStateValue_ActiveContext { get; set; }
            public Amazon.LexRuntimeV2.StyleType DialogAction_SlotElicitationStyle { get; set; }
            public System.String DialogAction_SlotToElicit { get; set; }
            public Amazon.LexRuntimeV2.Model.ElicitSubSlot DialogAction_SubSlotToElicit { get; set; }
            public Amazon.LexRuntimeV2.DialogActionType DialogAction_Type { get; set; }
            public Amazon.LexRuntimeV2.ConfirmationState Intent_ConfirmationState { get; set; }
            public System.String Intent_Name { get; set; }
            public Dictionary<System.String, Amazon.LexRuntimeV2.Model.Slot> Intent_Slot { get; set; }
            public Amazon.LexRuntimeV2.IntentState Intent_State { get; set; }
            public System.String SessionStateValue_OriginatingRequestId { get; set; }
            public Dictionary<System.String, Dictionary<System.String, Amazon.LexRuntimeV2.Model.RuntimeHintDetails>> RuntimeHints_SlotHint { get; set; }
            public Dictionary<System.String, System.String> SessionStateValue_SessionAttribute { get; set; }
            public System.String Text { get; set; }
            public System.Func<Amazon.LexRuntimeV2.Model.RecognizeTextResponse, SendLRSV2TextCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
