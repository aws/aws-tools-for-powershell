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
using Amazon.Lex;
using Amazon.Lex.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LEX
{
    /// <summary>
    /// Sends user input to Amazon Lex. Client applications can use this API to send requests
    /// to Amazon Lex at runtime. Amazon Lex then interprets the user input using the machine
    /// learning model it built for the bot. 
    /// 
    ///  
    /// <para>
    ///  In response, Amazon Lex returns the next <c>message</c> to convey to the user an
    /// optional <c>responseCard</c> to display. Consider the following example messages:
    /// 
    /// </para><ul><li><para>
    ///  For a user input "I would like a pizza", Amazon Lex might return a response with
    /// a message eliciting slot data (for example, PizzaSize): "What size pizza would you
    /// like?" 
    /// </para></li><li><para>
    ///  After the user provides all of the pizza order information, Amazon Lex might return
    /// a response with a message to obtain user confirmation "Proceed with the pizza order?".
    /// 
    /// </para></li><li><para>
    ///  After the user replies to a confirmation prompt with a "yes", Amazon Lex might return
    /// a conclusion statement: "Thank you, your cheese pizza has been ordered.". 
    /// </para></li></ul><para>
    ///  Not all Amazon Lex messages require a user response. For example, a conclusion statement
    /// does not require a response. Some messages require only a "yes" or "no" user response.
    /// In addition to the <c>message</c>, Amazon Lex provides additional context about the
    /// message in the response that you might use to enhance client behavior, for example,
    /// to display the appropriate client user interface. These are the <c>slotToElicit</c>,
    /// <c>dialogState</c>, <c>intentName</c>, and <c>slots</c> fields in the response. Consider
    /// the following examples: 
    /// </para><ul><li><para>
    /// If the message is to elicit slot data, Amazon Lex returns the following context information:
    /// </para><ul><li><para><c>dialogState</c> set to ElicitSlot 
    /// </para></li><li><para><c>intentName</c> set to the intent name in the current context 
    /// </para></li><li><para><c>slotToElicit</c> set to the slot name for which the <c>message</c> is eliciting
    /// information 
    /// </para></li><li><para><c>slots</c> set to a map of slots, configured for the intent, with currently known
    /// values 
    /// </para></li></ul></li><li><para>
    ///  If the message is a confirmation prompt, the <c>dialogState</c> is set to ConfirmIntent
    /// and <c>SlotToElicit</c> is set to null. 
    /// </para></li><li><para>
    /// If the message is a clarification prompt (configured for the intent) that indicates
    /// that user intent is not understood, the <c>dialogState</c> is set to ElicitIntent
    /// and <c>slotToElicit</c> is set to null. 
    /// </para></li></ul><para>
    ///  In addition, Amazon Lex also returns your application-specific <c>sessionAttributes</c>.
    /// For more information, see <a href="https://docs.aws.amazon.com/lex/latest/dg/context-mgmt.html">Managing
    /// Conversation Context</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Send", "LEXText")]
    [OutputType("Amazon.Lex.Model.PostTextResponse")]
    [AWSCmdlet("Calls the Amazon Lex PostText API operation.", Operation = new[] {"PostText"}, SelectReturnType = typeof(Amazon.Lex.Model.PostTextResponse))]
    [AWSCmdletOutput("Amazon.Lex.Model.PostTextResponse",
        "This cmdlet returns an Amazon.Lex.Model.PostTextResponse object containing multiple properties."
    )]
    public partial class SendLEXTextCmdlet : AmazonLexClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActiveContext
        /// <summary>
        /// <para>
        /// <para>A list of contexts active for the request. A context can be activated when a previous
        /// intent is fulfilled, or by including the context in the request,</para><para>If you don't specify a list of contexts, Amazon Lex will use the current list of contexts
        /// for the session. If you specify an empty list, all contexts for the session are cleared.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActiveContexts")]
        public Amazon.Lex.Model.ActiveContext[] ActiveContext { get; set; }
        #endregion
        
        #region Parameter BotAlias
        /// <summary>
        /// <para>
        /// <para>The alias of the Amazon Lex bot.</para>
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
        /// <para>The name of the Amazon Lex bot.</para>
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
        public System.String BotName { get; set; }
        #endregion
        
        #region Parameter InputText
        /// <summary>
        /// <para>
        /// <para>The text that the user entered (Amazon Lex interprets this text).</para>
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
        public System.String InputText { get; set; }
        #endregion
        
        #region Parameter RequestAttribute
        /// <summary>
        /// <para>
        /// <para>Request-specific information passed between Amazon Lex and a client application.</para><para>The namespace <c>x-amz-lex:</c> is reserved for special attributes. Don't create any
        /// request attributes with the prefix <c>x-amz-lex:</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/lex/latest/dg/context-mgmt.html#context-mgmt-request-attribs">Setting
        /// Request Attributes</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestAttributes")]
        public System.Collections.Hashtable RequestAttribute { get; set; }
        #endregion
        
        #region Parameter SessionAttribute
        /// <summary>
        /// <para>
        /// <para>Application-specific information passed between Amazon Lex and a client application.</para><para>For more information, see <a href="https://docs.aws.amazon.com/lex/latest/dg/context-mgmt.html#context-mgmt-session-attribs">Setting
        /// Session Attributes</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionAttributes")]
        public System.Collections.Hashtable SessionAttribute { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The ID of the client application user. Amazon Lex uses this to identify a user's conversation
        /// with your bot. At runtime, each request must contain the <c>userID</c> field.</para><para>To decide the user ID to use for your application, consider the following factors.</para><ul><li><para>The <c>userID</c> field must not contain any personally identifiable information of
        /// the user, for example, name, personal identification numbers, or other end user personal
        /// information.</para></li><li><para>If you want a user to start a conversation on one device and continue on another device,
        /// use a user-specific identifier.</para></li><li><para>If you want the same user to be able to have two independent conversations on two
        /// different devices, choose a device-specific identifier.</para></li><li><para>A user can't have two independent conversations with two different versions of the
        /// same bot. For example, a user can't have a conversation with the PROD and BETA versions
        /// of the same bot. If you anticipate that a user will need to have conversation with
        /// two different versions, for example, while testing, include the bot alias in the user
        /// ID to separate the two conversations.</para></li></ul>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lex.Model.PostTextResponse).
        /// Specifying the name of a property of type Amazon.Lex.Model.PostTextResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lex.Model.PostTextResponse, SendLEXTextCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.InputText = this.InputText;
            #if MODULAR
            if (this.InputText == null && ParameterWasBound(nameof(this.InputText)))
            {
                WriteWarning("You are passing $null as a value for parameter InputText which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RequestAttribute != null)
            {
                context.RequestAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestAttribute.Keys)
                {
                    context.RequestAttribute.Add((String)hashKey, (System.String)(this.RequestAttribute[hashKey]));
                }
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
            var request = new Amazon.Lex.Model.PostTextRequest();
            
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
            if (cmdletContext.InputText != null)
            {
                request.InputText = cmdletContext.InputText;
            }
            if (cmdletContext.RequestAttribute != null)
            {
                request.RequestAttributes = cmdletContext.RequestAttribute;
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
        
        private Amazon.Lex.Model.PostTextResponse CallAWSServiceOperation(IAmazonLex client, Amazon.Lex.Model.PostTextRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex", "PostText");
            try
            {
                return client.PostTextAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Lex.Model.ActiveContext> ActiveContext { get; set; }
            public System.String BotAlias { get; set; }
            public System.String BotName { get; set; }
            public System.String InputText { get; set; }
            public Dictionary<System.String, System.String> RequestAttribute { get; set; }
            public Dictionary<System.String, System.String> SessionAttribute { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.Lex.Model.PostTextResponse, SendLEXTextCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
