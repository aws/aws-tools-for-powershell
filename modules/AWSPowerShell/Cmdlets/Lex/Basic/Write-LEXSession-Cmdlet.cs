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
using Amazon.Lex;
using Amazon.Lex.Model;

namespace Amazon.PowerShell.Cmdlets.LEX
{
    /// <summary>
    /// Creates a new session or modifies an existing session with an Amazon Lex bot. Use
    /// this operation to enable your application to set the state of the bot.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/lex/latest/dg/how-session-api.html">Managing
    /// Sessions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "LEXSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lex.Model.PutSessionResponse")]
    [AWSCmdlet("Calls the Amazon Lex PutSession API operation.", Operation = new[] {"PutSession"}, SelectReturnType = typeof(Amazon.Lex.Model.PutSessionResponse))]
    [AWSCmdletOutput("Amazon.Lex.Model.PutSessionResponse",
        "This cmdlet returns an Amazon.Lex.Model.PutSessionResponse object containing multiple properties."
    )]
    public partial class WriteLEXSessionCmdlet : AmazonLexClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Accept
        /// <summary>
        /// <para>
        /// <para>The message that Amazon Lex returns in the response can be either text or speech based
        /// depending on the value of this field.</para><ul><li><para>If the value is <c>text/plain; charset=utf-8</c>, Amazon Lex returns text in the response.</para></li><li><para>If the value begins with <c>audio/</c>, Amazon Lex returns speech in the response.
        /// Amazon Lex uses Amazon Polly to generate the speech in the configuration that you
        /// specify. For example, if you specify <c>audio/mpeg</c> as the value, Amazon Lex returns
        /// speech in the MPEG format.</para></li><li><para>If the value is <c>audio/pcm</c>, the speech is returned as <c>audio/pcm</c> in 16-bit,
        /// little endian format.</para></li><li><para>The following are the accepted values:</para><ul><li><para><c>audio/mpeg</c></para></li><li><para><c>audio/ogg</c></para></li><li><para><c>audio/pcm</c></para></li><li><para><c>audio/*</c> (defaults to mpeg)</para></li><li><para><c>text/plain; charset=utf-8</c></para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Accept { get; set; }
        #endregion
        
        #region Parameter ActiveContext
        /// <summary>
        /// <para>
        /// <para>A list of contexts active for the request. A context can be activated when a previous
        /// intent is fulfilled, or by including the context in the request,</para><para>If you don't specify a list of contexts, Amazon Lex will use the current list of contexts
        /// for the session. If you specify an empty list, all contexts for the session are cleared.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActiveContexts")]
        public Amazon.Lex.Model.ActiveContext[] ActiveContext { get; set; }
        #endregion
        
        #region Parameter BotAlias
        /// <summary>
        /// <para>
        /// <para>The alias in use for the bot that contains the session data.</para>
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
        public System.String BotAlias { get; set; }
        #endregion
        
        #region Parameter BotName
        /// <summary>
        /// <para>
        /// <para>The name of the bot that contains the session data.</para>
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
        public System.String BotName { get; set; }
        #endregion
        
        #region Parameter DialogAction_FulfillmentState
        /// <summary>
        /// <para>
        /// <para>The fulfillment state of the intent. The possible values are:</para><ul><li><para><c>Failed</c> - The Lambda function associated with the intent failed to fulfill
        /// the intent.</para></li><li><para><c>Fulfilled</c> - The intent has fulfilled by the Lambda function associated with
        /// the intent. </para></li><li><para><c>ReadyForFulfillment</c> - All of the information necessary for the intent is present
        /// and the intent ready to be fulfilled by the client application.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lex.FulfillmentState")]
        public Amazon.Lex.FulfillmentState DialogAction_FulfillmentState { get; set; }
        #endregion
        
        #region Parameter DialogAction_IntentName
        /// <summary>
        /// <para>
        /// <para>The name of the intent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DialogAction_IntentName { get; set; }
        #endregion
        
        #region Parameter DialogAction_Message
        /// <summary>
        /// <para>
        /// <para>The message that should be shown to the user. If you don't specify a message, Amazon
        /// Lex will use the message configured for the intent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DialogAction_Message { get; set; }
        #endregion
        
        #region Parameter DialogAction_MessageFormat
        /// <summary>
        /// <para>
        /// <ul><li><para><c>PlainText</c> - The message contains plain UTF-8 text.</para></li><li><para><c>CustomPayload</c> - The message is a custom format for the client.</para></li><li><para><c>SSML</c> - The message contains text formatted for voice output.</para></li><li><para><c>Composite</c> - The message contains an escaped JSON object containing one or
        /// more messages. For more information, see <a href="https://docs.aws.amazon.com/lex/latest/dg/howitworks-manage-prompts.html">Message
        /// Groups</a>. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lex.MessageFormatType")]
        public Amazon.Lex.MessageFormatType DialogAction_MessageFormat { get; set; }
        #endregion
        
        #region Parameter RecentIntentSummaryView
        /// <summary>
        /// <para>
        /// <para>A summary of the recent intents for the bot. You can use the intent summary view to
        /// set a checkpoint label on an intent and modify attributes of intents. You can also
        /// use it to remove or add intent summary objects to the list.</para><para>An intent that you modify or add to the list must make sense for the bot. For example,
        /// the intent name must be valid for the bot. You must provide valid values for:</para><ul><li><para><c>intentName</c></para></li><li><para>slot names</para></li><li><para><c>slotToElict</c></para></li></ul><para>If you send the <c>recentIntentSummaryView</c> parameter in a <c>PutSession</c> request,
        /// the contents of the new summary view replaces the old summary view. For example, if
        /// a <c>GetSession</c> request returns three intents in the summary view and you call
        /// <c>PutSession</c> with one intent in the summary view, the next call to <c>GetSession</c>
        /// will only return one intent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Lex.Model.IntentSummary[] RecentIntentSummaryView { get; set; }
        #endregion
        
        #region Parameter SessionAttribute
        /// <summary>
        /// <para>
        /// <para>Map of key/value pairs representing the session-specific context information. It contains
        /// application information passed between Amazon Lex and a client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionAttributes")]
        public System.Collections.Hashtable SessionAttribute { get; set; }
        #endregion
        
        #region Parameter DialogAction_Slot
        /// <summary>
        /// <para>
        /// <para>Map of the slots that have been gathered and their values. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DialogAction_Slots")]
        public System.Collections.Hashtable DialogAction_Slot { get; set; }
        #endregion
        
        #region Parameter DialogAction_SlotToElicit
        /// <summary>
        /// <para>
        /// <para>The name of the slot that should be elicited from the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DialogAction_SlotToElicit { get; set; }
        #endregion
        
        #region Parameter DialogAction_Type
        /// <summary>
        /// <para>
        /// <para>The next action that the bot should take in its interaction with the user. The possible
        /// values are:</para><ul><li><para><c>ConfirmIntent</c> - The next action is asking the user if the intent is complete
        /// and ready to be fulfilled. This is a yes/no question such as "Place the order?"</para></li><li><para><c>Close</c> - Indicates that the there will not be a response from the user. For
        /// example, the statement "Your order has been placed" does not require a response.</para></li><li><para><c>Delegate</c> - The next action is determined by Amazon Lex.</para></li><li><para><c>ElicitIntent</c> - The next action is to determine the intent that the user wants
        /// to fulfill.</para></li><li><para><c>ElicitSlot</c> - The next action is to elicit a slot value from the user.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lex.DialogActionType")]
        public Amazon.Lex.DialogActionType DialogAction_Type { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The ID of the client application user. Amazon Lex uses this to identify a user's conversation
        /// with your bot. </para>
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
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lex.Model.PutSessionResponse).
        /// Specifying the name of a property of type Amazon.Lex.Model.PutSessionResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BotName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-LEXSession (PutSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lex.Model.PutSessionResponse, WriteLEXSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Accept = this.Accept;
            if (this.ActiveContext != null)
            {
                context.ActiveContext = new List<Amazon.Lex.Model.ActiveContext>(this.ActiveContext);
            }
            context.BotAlias = this.BotAlias;
            #if MODULAR
            if (this.BotAlias == null && ParameterWasBound(nameof(this.BotAlias)))
            {
                WriteWarning("You are passing $null as a value for parameter BotAlias which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotName = this.BotName;
            #if MODULAR
            if (this.BotName == null && ParameterWasBound(nameof(this.BotName)))
            {
                WriteWarning("You are passing $null as a value for parameter BotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DialogAction_FulfillmentState = this.DialogAction_FulfillmentState;
            context.DialogAction_IntentName = this.DialogAction_IntentName;
            context.DialogAction_Message = this.DialogAction_Message;
            context.DialogAction_MessageFormat = this.DialogAction_MessageFormat;
            if (this.DialogAction_Slot != null)
            {
                context.DialogAction_Slot = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DialogAction_Slot.Keys)
                {
                    context.DialogAction_Slot.Add((String)hashKey, (System.String)(this.DialogAction_Slot[hashKey]));
                }
            }
            context.DialogAction_SlotToElicit = this.DialogAction_SlotToElicit;
            context.DialogAction_Type = this.DialogAction_Type;
            if (this.RecentIntentSummaryView != null)
            {
                context.RecentIntentSummaryView = new List<Amazon.Lex.Model.IntentSummary>(this.RecentIntentSummaryView);
            }
            if (this.SessionAttribute != null)
            {
                context.SessionAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SessionAttribute.Keys)
                {
                    context.SessionAttribute.Add((String)hashKey, (System.String)(this.SessionAttribute[hashKey]));
                }
            }
            context.UserId = this.UserId;
            #if MODULAR
            if (this.UserId == null && ParameterWasBound(nameof(this.UserId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lex.Model.PutSessionRequest();
            
            if (cmdletContext.Accept != null)
            {
                request.Accept = cmdletContext.Accept;
            }
            if (cmdletContext.ActiveContext != null)
            {
                request.ActiveContexts = cmdletContext.ActiveContext;
            }
            if (cmdletContext.BotAlias != null)
            {
                request.BotAlias = cmdletContext.BotAlias;
            }
            if (cmdletContext.BotName != null)
            {
                request.BotName = cmdletContext.BotName;
            }
            
             // populate DialogAction
            var requestDialogActionIsNull = true;
            request.DialogAction = new Amazon.Lex.Model.DialogAction();
            Amazon.Lex.FulfillmentState requestDialogAction_dialogAction_FulfillmentState = null;
            if (cmdletContext.DialogAction_FulfillmentState != null)
            {
                requestDialogAction_dialogAction_FulfillmentState = cmdletContext.DialogAction_FulfillmentState;
            }
            if (requestDialogAction_dialogAction_FulfillmentState != null)
            {
                request.DialogAction.FulfillmentState = requestDialogAction_dialogAction_FulfillmentState;
                requestDialogActionIsNull = false;
            }
            System.String requestDialogAction_dialogAction_IntentName = null;
            if (cmdletContext.DialogAction_IntentName != null)
            {
                requestDialogAction_dialogAction_IntentName = cmdletContext.DialogAction_IntentName;
            }
            if (requestDialogAction_dialogAction_IntentName != null)
            {
                request.DialogAction.IntentName = requestDialogAction_dialogAction_IntentName;
                requestDialogActionIsNull = false;
            }
            System.String requestDialogAction_dialogAction_Message = null;
            if (cmdletContext.DialogAction_Message != null)
            {
                requestDialogAction_dialogAction_Message = cmdletContext.DialogAction_Message;
            }
            if (requestDialogAction_dialogAction_Message != null)
            {
                request.DialogAction.Message = requestDialogAction_dialogAction_Message;
                requestDialogActionIsNull = false;
            }
            Amazon.Lex.MessageFormatType requestDialogAction_dialogAction_MessageFormat = null;
            if (cmdletContext.DialogAction_MessageFormat != null)
            {
                requestDialogAction_dialogAction_MessageFormat = cmdletContext.DialogAction_MessageFormat;
            }
            if (requestDialogAction_dialogAction_MessageFormat != null)
            {
                request.DialogAction.MessageFormat = requestDialogAction_dialogAction_MessageFormat;
                requestDialogActionIsNull = false;
            }
            Dictionary<System.String, System.String> requestDialogAction_dialogAction_Slot = null;
            if (cmdletContext.DialogAction_Slot != null)
            {
                requestDialogAction_dialogAction_Slot = cmdletContext.DialogAction_Slot;
            }
            if (requestDialogAction_dialogAction_Slot != null)
            {
                request.DialogAction.Slots = requestDialogAction_dialogAction_Slot;
                requestDialogActionIsNull = false;
            }
            System.String requestDialogAction_dialogAction_SlotToElicit = null;
            if (cmdletContext.DialogAction_SlotToElicit != null)
            {
                requestDialogAction_dialogAction_SlotToElicit = cmdletContext.DialogAction_SlotToElicit;
            }
            if (requestDialogAction_dialogAction_SlotToElicit != null)
            {
                request.DialogAction.SlotToElicit = requestDialogAction_dialogAction_SlotToElicit;
                requestDialogActionIsNull = false;
            }
            Amazon.Lex.DialogActionType requestDialogAction_dialogAction_Type = null;
            if (cmdletContext.DialogAction_Type != null)
            {
                requestDialogAction_dialogAction_Type = cmdletContext.DialogAction_Type;
            }
            if (requestDialogAction_dialogAction_Type != null)
            {
                request.DialogAction.Type = requestDialogAction_dialogAction_Type;
                requestDialogActionIsNull = false;
            }
             // determine if request.DialogAction should be set to null
            if (requestDialogActionIsNull)
            {
                request.DialogAction = null;
            }
            if (cmdletContext.RecentIntentSummaryView != null)
            {
                request.RecentIntentSummaryView = cmdletContext.RecentIntentSummaryView;
            }
            if (cmdletContext.SessionAttribute != null)
            {
                request.SessionAttributes = cmdletContext.SessionAttribute;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
        
        private Amazon.Lex.Model.PutSessionResponse CallAWSServiceOperation(IAmazonLex client, Amazon.Lex.Model.PutSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex", "PutSession");
            try
            {
                #if DESKTOP
                return client.PutSession(request);
                #elif CORECLR
                return client.PutSessionAsync(request).GetAwaiter().GetResult();
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
            public System.String Accept { get; set; }
            public List<Amazon.Lex.Model.ActiveContext> ActiveContext { get; set; }
            public System.String BotAlias { get; set; }
            public System.String BotName { get; set; }
            public Amazon.Lex.FulfillmentState DialogAction_FulfillmentState { get; set; }
            public System.String DialogAction_IntentName { get; set; }
            public System.String DialogAction_Message { get; set; }
            public Amazon.Lex.MessageFormatType DialogAction_MessageFormat { get; set; }
            public Dictionary<System.String, System.String> DialogAction_Slot { get; set; }
            public System.String DialogAction_SlotToElicit { get; set; }
            public Amazon.Lex.DialogActionType DialogAction_Type { get; set; }
            public List<Amazon.Lex.Model.IntentSummary> RecentIntentSummaryView { get; set; }
            public Dictionary<System.String, System.String> SessionAttribute { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.Lex.Model.PutSessionResponse, WriteLEXSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
