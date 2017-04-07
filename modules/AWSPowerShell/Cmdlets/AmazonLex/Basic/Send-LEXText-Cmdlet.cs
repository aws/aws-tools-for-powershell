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
        
        #region Parameter SessionAttribute
        /// <summary>
        /// <para>
        /// <para> By using session attributes, a client application can pass contextual information
        /// in the request to Amazon Lex For example, </para><ul><li><para>In Getting Started Exercise 1, the example bot uses the <code>price</code> session
        /// attribute to maintain the price of the flowers ordered (for example, "Price":25).
        /// The code hook (the Lambda function) sets this attribute based on the type of flowers
        /// ordered. For more information, see <a href="http://docs.aws.amazon.com/lex/latest/dg/gs-bp-details-after-lambda.html">Review
        /// the Details of Information Flow</a>. </para></li><li><para>In the BookTrip bot exercise, the bot uses the <code>currentReservation</code> session
        /// attribute to maintain slot data during the in-progress conversation to book a hotel
        /// or book a car. For more information, see <a href="http://docs.aws.amazon.com/lex/latest/dg/book-trip-detail-flow.html">Details
        /// of Information Flow</a>. </para></li><li><para>You might use the session attributes (key, value pairs) to track the requestID of
        /// user requests.</para></li></ul><para> Amazon Lex simply passes these session attributes to the Lambda functions configured
        /// for the intent.</para><para>In your Lambda function, you can also use the session attributes for initialization
        /// and customization (prompts and response cards). Some examples are:</para><ul><li><para> Initialization - In a pizza ordering bot, if you can pass the user location as a
        /// session attribute (for example, <code>"Location" : "111 Maple street"</code>), then
        /// your Lambda function might use this information to determine the closest pizzeria
        /// to place the order (perhaps to set the storeAddress slot value). </para></li><li><para> Personalize prompts - For example, you can configure prompts to refer to the user
        /// name. (For example, "Hey [FirstName], what toppings would you like?"). You can pass
        /// the user name as a session attribute (<code>"FirstName" : "Joe"</code>) so that Amazon
        /// Lex can substitute the placeholder to provide a personalize prompt to the user ("Hey
        /// Joe, what toppings would you like?"). </para></li></ul><note><para> Amazon Lex does not persist session attributes. </para><para> If you configure a code hook for the intent, Amazon Lex passes the incoming session
        /// attributes to the Lambda function. If you want Amazon Lex to return these session
        /// attributes back to the client, the Lambda function must return them. </para><para> If there is no code hook configured for the intent, Amazon Lex simply returns the
        /// session attributes back to the client application. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SessionAttributes")]
        public System.Collections.Hashtable SessionAttribute { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The ID of the client application user. The application developer decides the user
        /// IDs. At runtime, each request must include the user ID. Typically, each of your application
        /// users should have a unique ID. Note the following considerations: </para><ul><li><para> If you want a user to start a conversation on one device and continue the conversation
        /// on another device, you might choose a user-specific identifier, such as a login or
        /// Amazon Cognito user ID (assuming your application is using Amazon Cognito). </para></li><li><para> If you want the same user to be able to have two independent conversations on two
        /// different devices, you might choose a device-specific identifier, such as device ID,
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
            
            context.BotAlias = this.BotAlias;
            context.BotName = this.BotName;
            context.InputText = this.InputText;
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
        
        private static Amazon.Lex.Model.PostTextResponse CallAWSServiceOperation(IAmazonLex client, Amazon.Lex.Model.PostTextRequest request)
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
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String BotAlias { get; set; }
            public System.String BotName { get; set; }
            public System.String InputText { get; set; }
            public Dictionary<System.String, System.String> SessionAttributes { get; set; }
            public System.String UserId { get; set; }
        }
        
    }
}
