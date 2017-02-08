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
    /// Sends user input text to Amazon Lex at runtime. Amazon Lex uses the machine learning
    /// model that the service built for the application to interpret user input. 
    /// 
    ///  
    /// <para>
    ///  In response, Amazon Lex returns the next message to convey to the user (based on
    /// the context of the user interaction) and whether to expect a user response to the
    /// message (<code>dialogState</code>). For example, consider the following response messages:
    /// 
    /// </para><ul><li><para>
    /// "What pizza toppings would you like?" – In this case, the <code>dialogState</code>
    /// would be <code>ElicitSlot</code> (that is, a user response is expected). 
    /// </para></li><li><para>
    /// "Your order has been placed." – In this case, Amazon Lex returns one of the following
    /// <code>dialogState</code> values depending on how the intent fulfillment is configured
    /// (see <code>fulfillmentActivity</code> in <code>CreateIntent</code>): 
    /// </para><ul><li><para><code>FulFilled</code> – The intent fulfillment is configured through a Lambda function.
    /// 
    /// </para></li><li><para><code>ReadyForFulfilment</code> – The intent's <code>fulfillmentActivity</code> is
    /// to simply return the intent data back to the client application. 
    /// </para></li></ul></li></ul>
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
        
        #region Parameter InputText
        /// <summary>
        /// <para>
        /// <para>Text user entered (Amazon Lex interprets this text).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String InputText { get; set; }
        #endregion
        
        #region Parameter SessionAttribute
        /// <summary>
        /// <para>
        /// <para> A session represents the dialog between a user and Amazon Lex. At runtime, a client
        /// application can pass contextual information (session attributes) in the request. For
        /// example, <code>"FirstName" : "Joe"</code>. Amazon Lex passes these session attributes
        /// to the AWS Lambda functions configured for the intent (see <code>dialogCodeHook</code>
        /// and <code>fulfillmentActivity.codeHook</code> in <code>CreateIntent</code>). </para><para>In your Lambda function, you can use the session attributes for customization. Some
        /// examples are:</para><ul><li><para> In a pizza ordering application, if you can pass user location as a session attribute
        /// (for example, <code>"Location" : "111 Maple street"</code>), your Lambda function
        /// might use this information to determine the closest pizzeria to place the order. </para></li><li><para> Use session attributes to personalize prompts. For example, you pass in user name
        /// as a session attribute (<code>"FirstName" : "Joe"</code>), you might configure subsequent
        /// prompts to refer to this attribute, as <code>$session.FirstName"</code>. At runtime,
        /// Amazon Lex substitutes a real value when it generates a prompt, such as "Hello Joe,
        /// what would you like to order?" </para></li></ul><note><para> Amazon Lex does not persist session attributes. </para><para> If the intent is configured without a Lambda function to process the intent (that
        /// is, the client application to process the intent), Amazon Lex simply returns the session
        /// attributes back to the client application. </para><para> If the intent is configured with a Lambda function to process the intent, Amazon
        /// Lex passes the incoming session attributes to the Lambda function. The Lambda function
        /// must return these session attributes if you want Amazon Lex to return them back to
        /// the client. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SessionAttributes")]
        public System.Collections.Hashtable SessionAttribute { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>User ID of your client application. Typically, each of your application users should
        /// have a unique ID. Note the following considerations: </para><ul><li><para> If you want a user to start a conversation on one mobile device and continue the
        /// conversation on another device, you might choose a user-specific identifier, such
        /// as a login or Amazon Cognito user ID (assuming your application is using Amazon Cognito).
        /// </para></li><li><para> If you want the same user to be able to have two independent conversations on two
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
