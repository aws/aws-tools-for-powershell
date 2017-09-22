/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Sends user input (text-only) to Amazon Lex. Client applications can use this API to
    /// send requests to Amazon Lex at runtime. Amazon Lex then interprets the user input
    /// using the machine learning model it built for the bot. 
    /// 
    ///  
    /// <para>
    ///  In response, Amazon Lex returns the next <code>message</code> to convey to the user
    /// an optional <code>responseCard</code> to display. Consider the following example messages:
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
    /// In addition to the <code>message</code>, Amazon Lex provides additional context about
    /// the message in the response that you might use to enhance client behavior, for example,
    /// to display the appropriate client user interface. These are the <code>slotToElicit</code>,
    /// <code>dialogState</code>, <code>intentName</code>, and <code>slots</code> fields in
    /// the response. Consider the following examples: 
    /// </para><ul><li><para>
    /// If the message is to elicit slot data, Amazon Lex returns the following context information:
    /// </para><ul><li><para><code>dialogState</code> set to ElicitSlot 
    /// </para></li><li><para><code>intentName</code> set to the intent name in the current context 
    /// </para></li><li><para><code>slotToElicit</code> set to the slot name for which the <code>message</code>
    /// is eliciting information 
    /// </para></li><li><para><code>slots</code> set to a map of slots, configured for the intent, with currently
    /// known values 
    /// </para></li></ul></li><li><para>
    ///  If the message is a confirmation prompt, the <code>dialogState</code> is set to ConfirmIntent
    /// and <code>SlotToElicit</code> is set to null. 
    /// </para></li><li><para>
    /// If the message is a clarification prompt (configured for the intent) that indicates
    /// that user intent is not understood, the <code>dialogState</code> is set to ElicitIntent
    /// and <code>slotToElicit</code> is set to null. 
    /// </para></li></ul><para>
    ///  In addition, Amazon Lex also returns your application-specific <code>sessionAttributes</code>.
    /// For more information, see <a href="http://docs.aws.amazon.com/lex/latest/dg/context-mgmt.html">Managing
    /// Conversation Context</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Send", "LEXText")]
    [OutputType("Amazon.Lex.Model.PostTextResponse")]
    [AWSCmdlet("Invokes the PostText operation against Amazon Lex.", Operation = new[] {"PostText"})]
    [AWSCmdletOutput("Amazon.Lex.Model.PostTextResponse",
        "This cmdlet returns a Amazon.Lex.Model.PostTextResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendLEXTextCmdlet : AmazonLexClientCmdlet, IExecutor
    {
        
        #region Parameter BotAlias
        /// <summary>
        /// <para>
        /// <para>The alias of the Amazon Lex bot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BotAlias { get; set; }
        #endregion
        
        #region Parameter BotName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Lex bot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BotName { get; set; }
        #endregion
        
        #region Parameter InputText
        /// <summary>
        /// <para>
        /// <para>The text that the user entered (Amazon Lex interprets this text).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String InputText { get; set; }
        #endregion
        
        #region Parameter RequestAttribute
        /// <summary>
        /// <para>
        /// <para>Request-specific information passed between Amazon Lex and a client application.</para><para>The namespace <code>x-amz-lex:</code> is reserved for special attributes. Don't create
        /// any request attributes with the prefix <code>x-amz-lex:</code>.</para><para>For more information, see <a href="http://docs.aws.amazon.com/lex/latest/dg/context-mgmt.html#context-mgmt-request-attribs">Setting
        /// Request Attributes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RequestAttributes")]
        public System.Collections.Hashtable RequestAttribute { get; set; }
        #endregion
        
        #region Parameter SessionAttribute
        /// <summary>
        /// <para>
        /// <para>Application-specific information passed between Amazon Lex and a client application.</para><para>For more information, see <a href="http://docs.aws.amazon.com/lex/latest/dg/context-mgmt.html#context-mgmt-session-attribs">Setting
        /// Session Attributes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SessionAttributes")]
        public System.Collections.Hashtable SessionAttribute { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The ID of the client application user. Amazon Lex uses this to identify a user's conversation
        /// with your bot. At runtime, each request must contain the <code>userID</code> field.</para><para>To decide the user ID to use for your application, consider the following factors.</para><ul><li><para>The <code>userID</code> field must not contain any personally identifiable information
        /// of the user, for example, name, personal identification numbers, or other end user
        /// personal information.</para></li><li><para>If you want a user to start a conversation on one device and continue on another device,
        /// use a user-specific identifier.</para></li><li><para>If you want the same user to be able to have two independent conversations on two
        /// different devices, choose a device-specific identifier.</para></li><li><para>A user can't have two independent conversations with two different versions of the
        /// same bot. For example, a user can't have a conversation with the PROD and BETA versions
        /// of the same bot. If you anticipate that a user will need to have conversation with
        /// two different versions, for example, while testing, include the bot alias in the user
        /// ID to separate the two conversations.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String UserId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.BotAlias = this.BotAlias;
            context.BotName = this.BotName;
            context.InputText = this.InputText;
            if (this.RequestAttribute != null)
            {
                context.RequestAttributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestAttribute.Keys)
                {
                    context.RequestAttributes.Add((String)hashKey, (String)(this.RequestAttribute[hashKey]));
                }
            }
            if (this.SessionAttribute != null)
            {
                context.SessionAttributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SessionAttribute.Keys)
                {
                    context.SessionAttributes.Add((String)hashKey, (String)(this.SessionAttribute[hashKey]));
                }
            }
            context.UserId = this.UserId;
            
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
            if (cmdletContext.RequestAttributes != null)
            {
                request.RequestAttributes = cmdletContext.RequestAttributes;
            }
            if (cmdletContext.SessionAttributes != null)
            {
                request.SessionAttributes = cmdletContext.SessionAttributes;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                #if DESKTOP
                return client.PostText(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PostTextAsync(request);
                return task.Result;
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
            public System.String BotAlias { get; set; }
            public System.String BotName { get; set; }
            public System.String InputText { get; set; }
            public Dictionary<System.String, System.String> RequestAttributes { get; set; }
            public Dictionary<System.String, System.String> SessionAttributes { get; set; }
            public System.String UserId { get; set; }
        }
        
    }
}
