/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Sends user input (text or speech) to Amazon Lex. Clients use this API to send text
    /// and audio requests to Amazon Lex at runtime. Amazon Lex interprets the user input
    /// using the machine learning model that it built for the bot. 
    /// 
    ///  
    /// <para>
    /// The <code>PostContent</code> operation supports audio input at 8kHz and 16kHz. You
    /// can use 8kHz audio to achieve higher speech recognition accuracy in telephone audio
    /// applications. 
    /// </para><para>
    ///  In response, Amazon Lex returns the next message to convey to the user. Consider
    /// the following example messages: 
    /// </para><ul><li><para>
    ///  For a user input "I would like a pizza," Amazon Lex might return a response with
    /// a message eliciting slot data (for example, <code>PizzaSize</code>): "What size pizza
    /// would you like?". 
    /// </para></li><li><para>
    ///  After the user provides all of the pizza order information, Amazon Lex might return
    /// a response with a message to get user confirmation: "Order the pizza?". 
    /// </para></li><li><para>
    ///  After the user replies "Yes" to the confirmation prompt, Amazon Lex might return
    /// a conclusion statement: "Thank you, your cheese pizza has been ordered.". 
    /// </para></li></ul><para>
    ///  Not all Amazon Lex messages require a response from the user. For example, conclusion
    /// statements do not require a response. Some messages require only a yes or no response.
    /// In addition to the <code>message</code>, Amazon Lex provides additional context about
    /// the message in the response that you can use to enhance client behavior, such as displaying
    /// the appropriate client user interface. Consider the following examples: 
    /// </para><ul><li><para>
    ///  If the message is to elicit slot data, Amazon Lex returns the following context information:
    /// 
    /// </para><ul><li><para><code>x-amz-lex-dialog-state</code> header set to <code>ElicitSlot</code></para></li><li><para><code>x-amz-lex-intent-name</code> header set to the intent name in the current context
    /// 
    /// </para></li><li><para><code>x-amz-lex-slot-to-elicit</code> header set to the slot name for which the <code>message</code>
    /// is eliciting information 
    /// </para></li><li><para><code>x-amz-lex-slots</code> header set to a map of slots configured for the intent
    /// with their current values 
    /// </para></li></ul></li><li><para>
    ///  If the message is a confirmation prompt, the <code>x-amz-lex-dialog-state</code>
    /// header is set to <code>Confirmation</code> and the <code>x-amz-lex-slot-to-elicit</code>
    /// header is omitted. 
    /// </para></li><li><para>
    ///  If the message is a clarification prompt configured for the intent, indicating that
    /// the user intent is not understood, the <code>x-amz-dialog-state</code> header is set
    /// to <code>ElicitIntent</code> and the <code>x-amz-slot-to-elicit</code> header is omitted.
    /// 
    /// </para></li></ul><para>
    ///  In addition, Amazon Lex also returns your application-specific <code>sessionAttributes</code>.
    /// For more information, see <a href="http://docs.aws.amazon.com/lex/latest/dg/context-mgmt.html">Managing
    /// Conversation Context</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Send", "LEXContent")]
    [OutputType("Amazon.Lex.Model.PostContentResponse")]
    [AWSCmdlet("Calls the Amazon Lex PostContent API operation.", Operation = new[] {"PostContent"})]
    [AWSCmdletOutput("Amazon.Lex.Model.PostContentResponse",
        "This cmdlet returns a Amazon.Lex.Model.PostContentResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendLEXContentCmdlet : AmazonLexClientCmdlet, IExecutor
    {
        
        #region Parameter Accept
        /// <summary>
        /// <para>
        /// <para> You pass this value as the <code>Accept</code> HTTP header. </para><para> The message Amazon Lex returns in the response can be either text or speech based
        /// on the <code>Accept</code> HTTP header value in the request. </para><ul><li><para> If the value is <code>text/plain; charset=utf-8</code>, Amazon Lex returns text in
        /// the response. </para></li><li><para> If the value begins with <code>audio/</code>, Amazon Lex returns speech in the response.
        /// Amazon Lex uses Amazon Polly to generate the speech (using the configuration you specified
        /// in the <code>Accept</code> header). For example, if you specify <code>audio/mpeg</code>
        /// as the value, Amazon Lex returns speech in the MPEG format.</para><para>The following are the accepted values:</para><ul><li><para>audio/mpeg</para></li><li><para>audio/ogg</para></li><li><para>audio/pcm</para></li><li><para>text/plain; charset=utf-8</para></li><li><para>audio/* (defaults to mpeg)</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Accept { get; set; }
        #endregion
        
        #region Parameter BotAlias
        /// <summary>
        /// <para>
        /// <para>Alias of the Amazon Lex bot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BotAlias { get; set; }
        #endregion
        
        #region Parameter BotName
        /// <summary>
        /// <para>
        /// <para>Name of the Amazon Lex bot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BotName { get; set; }
        #endregion
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para> You pass this value as the <code>Content-Type</code> HTTP header. </para><para> Indicates the audio format or text. The header value must start with one of the following
        /// prefixes: </para><ul><li><para>PCM format, audio data must be in little-endian byte order.</para><ul><li><para>audio/l16; rate=16000; channels=1</para></li><li><para>audio/x-l16; sample-rate=16000; channel-count=1</para></li><li><para>audio/lpcm; sample-rate=8000; sample-size-bits=16; channel-count=1; is-big-endian=false
        /// </para></li></ul></li><li><para>Opus format</para><ul><li><para>audio/x-cbr-opus-with-preamble; preamble-size=0; bit-rate=256000; frame-size-milliseconds=4</para></li></ul></li><li><para>Text format</para><ul><li><para>text/plain; charset=utf-8</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter InputStream
        /// <summary>
        /// <para>
        /// <para> User input in PCM or Opus audio format or text format as described in the <code>Content-Type</code>
        /// HTTP header. </para><para>You can stream audio data to Amazon Lex or you can create a local buffer that captures
        /// all of the audio data before sending. In general, you get better performance if you
        /// stream audio data rather than buffering the data locally.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.IO.Stream InputStream { get; set; }
        #endregion
        
        #region Parameter RequestAttribute
        /// <summary>
        /// <para>
        /// <para>You pass this value as the <code>x-amz-lex-request-attributes</code> HTTP header.</para><para>Request-specific information passed between Amazon Lex and a client application. The
        /// value must be a JSON serialized and base64 encoded map with string keys and values.
        /// The total size of the <code>requestAttributes</code> and <code>sessionAttributes</code>
        /// headers is limited to 12 KB.</para><para>The namespace <code>x-amz-lex:</code> is reserved for special attributes. Don't create
        /// any request attributes with the prefix <code>x-amz-lex:</code>.</para><para>For more information, see <a href="http://docs.aws.amazon.com/lex/latest/dg/context-mgmt.html#context-mgmt-request-attribs">Setting
        /// Request Attributes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RequestAttributes")]
        public System.String RequestAttribute { get; set; }
        #endregion
        
        #region Parameter SessionAttribute
        /// <summary>
        /// <para>
        /// <para>You pass this value as the <code>x-amz-lex-session-attributes</code> HTTP header.</para><para>Application-specific information passed between Amazon Lex and a client application.
        /// The value must be a JSON serialized and base64 encoded map with string keys and values.
        /// The total size of the <code>sessionAttributes</code> and <code>requestAttributes</code>
        /// headers is limited to 12 KB.</para><para>For more information, see <a href="http://docs.aws.amazon.com/lex/latest/dg/context-mgmt.html#context-mgmt-session-attribs">Setting
        /// Session Attributes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SessionAttributes")]
        public System.String SessionAttribute { get; set; }
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
            
            context.Accept = this.Accept;
            context.BotAlias = this.BotAlias;
            context.BotName = this.BotName;
            context.ContentType = this.ContentType;
            context.InputStream = this.InputStream;
            context.RequestAttributes = this.RequestAttribute;
            context.SessionAttributes = this.SessionAttribute;
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
            var request = new Amazon.Lex.Model.PostContentRequest();
            
            if (cmdletContext.Accept != null)
            {
                request.Accept = cmdletContext.Accept;
            }
            if (cmdletContext.BotAlias != null)
            {
                request.BotAlias = cmdletContext.BotAlias;
            }
            if (cmdletContext.BotName != null)
            {
                request.BotName = cmdletContext.BotName;
            }
            if (cmdletContext.ContentType != null)
            {
                request.ContentType = cmdletContext.ContentType;
            }
            if (cmdletContext.InputStream != null)
            {
                request.InputStream = cmdletContext.InputStream;
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
        
        private Amazon.Lex.Model.PostContentResponse CallAWSServiceOperation(IAmazonLex client, Amazon.Lex.Model.PostContentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex", "PostContent");
            try
            {
                #if DESKTOP
                return client.PostContent(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PostContentAsync(request);
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
            public System.String Accept { get; set; }
            public System.String BotAlias { get; set; }
            public System.String BotName { get; set; }
            public System.String ContentType { get; set; }
            public System.IO.Stream InputStream { get; set; }
            public System.String RequestAttributes { get; set; }
            public System.String SessionAttributes { get; set; }
            public System.String UserId { get; set; }
        }
        
    }
}
