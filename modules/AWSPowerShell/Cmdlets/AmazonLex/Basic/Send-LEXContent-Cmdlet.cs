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
    /// Sends user input (text or speech) to Amazon Lex. Clients use this API to send requests
    /// to Amazon Lex at runtime. Amazon Lex interprets the user input using the machine learning
    /// model that it built for the bot. 
    /// 
    ///  
    /// <para>
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
    [AWSCmdlet("Invokes the PostContent operation against Amazon Lex.", Operation = new[] {"PostContent"})]
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
        /// <para> You pass this values as the <code>Content-Type</code> HTTP header. </para><para> Indicates the audio format or text. The header value must start with one of the following
        /// prefixes: </para><ul><li><para>PCM format</para><ul><li><para>audio/l16; rate=16000; channels=1</para></li><li><para>audio/x-l16; sample-rate=16000; channel-count=1</para></li></ul></li><li><para>Opus format</para><ul><li><para>audio/x-cbr-opus-with-preamble; preamble-size=0; bit-rate=1; frame-size-milliseconds=1.1</para></li></ul></li><li><para>Text format</para><ul><li><para>text/plain; charset=utf-8</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter InputStream
        /// <summary>
        /// <para>
        /// <para> User input in PCM or Opus audio format or text format as described in the <code>Content-Type</code>
        /// HTTP header. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.IO.Stream InputStream { get; set; }
        #endregion
        
        #region Parameter SessionAttribute
        /// <summary>
        /// <para>
        /// <para>You pass this value in the <code>x-amz-lex-session-attributes</code> HTTP header.
        /// The value must be map (keys and values must be strings) that is JSON serialized and
        /// then base64 encoded.</para><para> A session represents dialog between a user and Amazon Lex. At runtime, a client application
        /// can pass contextual information, in the request to Amazon Lex. For example, </para><ul><li><para>You might use session attributes to track the requestID of user requests.</para></li><li><para>In Getting Started Exercise 1, the example bot uses the price session attribute to
        /// maintain the price of flowers ordered (for example, "price":25). The code hook (Lambda
        /// function) sets this attribute based on the type of flowers ordered. For more information,
        /// see <a href="http://docs.aws.amazon.com/lex/latest/dg/gs-bp-details-after-lambda.html">Review
        /// the Details of Information Flow</a>. </para></li><li><para>In the BookTrip bot exercise, the bot uses the <code>currentReservation</code> session
        /// attribute to maintains the slot data during the in-progress conversation to book a
        /// hotel or book a car. For more information, see <a href="http://docs.aws.amazon.com/lex/latest/dg/book-trip-detail-flow.html">Details
        /// of Information Flow</a>. </para></li></ul><para> Amazon Lex passes these session attributes to the Lambda functions configured for
        /// the intent In the your Lambda function, you can use the session attributes for initialization
        /// and customization (prompts). Some examples are: </para><ul><li><para> Initialization - In a pizza ordering bot, if you pass user location (for example,
        /// <code>"Location : 111 Maple Street"</code>), then your Lambda function might use this
        /// information to determine the closest pizzeria to place the order (and perhaps set
        /// the storeAddress slot value as well). </para><para> Personalized prompts - For example, you can configure prompts to refer to the user
        /// by name (for example, "Hey [firstName], what toppings would you like?"). You can pass
        /// the user's name as a session attribute ("firstName": "Joe") so that Amazon Lex can
        /// substitute the placeholder to provide a personalized prompt to the user ("Hey Joe,
        /// what toppings would you like?"). </para></li></ul><note><para> Amazon Lex does not persist session attributes. </para><para> If you configured a code hook for the intent, Amazon Lex passes the incoming session
        /// attributes to the Lambda function. The Lambda function must return these session attributes
        /// if you want Amazon Lex to return them to the client. </para><para> If there is no code hook configured for the intent Amazon Lex simply returns the
        /// session attributes to the client application. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SessionAttributes")]
        public System.String SessionAttribute { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>ID of the client application user. Typically, each of your application users should
        /// have a unique ID. The application developer decides the user IDs. At runtime, each
        /// request must include the user ID. Note the following considerations:</para><ul><li><para> If you want a user to start conversation on one device and continue the conversation
        /// on another device, you might choose a user-specific identifier, such as the user's
        /// login, or Amazon Cognito user ID (assuming your application is using Amazon Cognito).
        /// </para></li><li><para> If you want the same user to be able to have two independent conversations on two
        /// different devices, you might choose device-specific identifier, such as device ID,
        /// or some globally unique identifier. </para></li></ul>
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
        
        private static Amazon.Lex.Model.PostContentResponse CallAWSServiceOperation(IAmazonLex client, Amazon.Lex.Model.PostContentRequest request)
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
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Accept { get; set; }
            public System.String BotAlias { get; set; }
            public System.String BotName { get; set; }
            public System.String ContentType { get; set; }
            public System.IO.Stream InputStream { get; set; }
            public System.String SessionAttributes { get; set; }
            public System.String UserId { get; set; }
        }
        
    }
}
