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
using Amazon.LexModelBuildingService;
using Amazon.LexModelBuildingService.Model;

namespace Amazon.PowerShell.Cmdlets.LMB
{
    /// <summary>
    /// Creates an Amazon Lex conversational bot or replaces an existing bot. When you create
    /// or update a bot you are only required to specify a name. You can use this to add intents
    /// later, or to remove intents from an existing bot. When you create a bot with a name
    /// only, the bot is created or updated but Amazon Lex returns the <code /> response <code>FAILED</code>.
    /// You can build the bot after you add one or more intents. For more information about
    /// Amazon Lex bots, see <a>how-it-works</a>. 
    /// 
    ///  
    /// <para>
    /// If you specify the name of an existing bot, the fields in the request replace the
    /// existing values in the <code>$LATEST</code> version of the bot. Amazon Lex removes
    /// any fields that you don't provide values for in the request, except for the <code>idleTTLInSeconds</code>
    /// and <code>privacySettings</code> fields, which are set to their default values. If
    /// you don't specify values for required fields, Amazon Lex throws an exception.
    /// </para><para>
    /// This operation requires permissions for the <code>lex:PutBot</code> action. For more
    /// information, see <a>auth-and-access-control</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "LMBBot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelBuildingService.Model.PutBotResponse")]
    [AWSCmdlet("Invokes the PutBot operation against Amazon Lex Model Building Service.", Operation = new[] {"PutBot"})]
    [AWSCmdletOutput("Amazon.LexModelBuildingService.Model.PutBotResponse",
        "This cmdlet returns a Amazon.LexModelBuildingService.Model.PutBotResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteLMBBotCmdlet : AmazonLexModelBuildingServiceClientCmdlet, IExecutor
    {
        
        #region Parameter AbortStatement
        /// <summary>
        /// <para>
        /// <para>When Amazon Lex can't understand the user's input in context, it tries to elicit the
        /// information a few times. After that, Amazon Lex sends the message defined in <code>abortStatement</code>
        /// to the user, and then aborts the conversation. To set the number of retries, use the
        /// <code>valueElicitationPrompt</code> field for the slot type. </para><para>For example, in a pizza ordering bot, Amazon Lex might ask a user "What type of crust
        /// would you like?" If the user's response is not one of the expected responses (for
        /// example, "thin crust, "deep dish," etc.), Amazon Lex tries to elicit a correct response
        /// a few more times. </para><para>For example, in a pizza ordering application, <code>OrderPizza</code> might be one
        /// of the intents. This intent might require the <code>CrustType</code> slot. You specify
        /// the <code>valueElicitationPrompt</code> field when you create the <code>CrustType</code>
        /// slot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.LexModelBuildingService.Model.Statement AbortStatement { get; set; }
        #endregion
        
        #region Parameter Checksum
        /// <summary>
        /// <para>
        /// <para>Identifies a specific revision of the <code>$LATEST</code> version.</para><para>When you create a new bot, leave the <code>checksum</code> field blank. If you specify
        /// a checksum you get a <code>BadRequestException</code> exception.</para><para>When you want to update a bot, set the <code>checksum</code> field to the checksum
        /// of the most recent revision of the <code>$LATEST</code> version. If you don't specify
        /// the <code> checksum</code> field, or if the checksum does not match the <code>$LATEST</code>
        /// version, you get a <code>PreconditionFailedException</code> exception.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Checksum { get; set; }
        #endregion
        
        #region Parameter ChildDirected
        /// <summary>
        /// <para>
        /// <para>For each Amazon Lex bot created with the Amazon Lex Model Building Service, you must
        /// specify whether your use of Amazon Lex is related to a website, program, or other
        /// application that is directed or targeted, in whole or in part, to children under age
        /// 13 and subject to the Children's Online Privacy Protection Act (COPPA) by specifying
        /// <code>true</code> or <code>false</code> in the <code>childDirected</code> field. By
        /// specifying <code>true</code> in the <code>childDirected</code> field, you confirm
        /// that your use of Amazon Lex <b>is</b> related to a website, program, or other application
        /// that is directed or targeted, in whole or in part, to children under age 13 and subject
        /// to COPPA. By specifying <code>false</code> in the <code>childDirected</code> field,
        /// you confirm that your use of Amazon Lex <b>is not</b> related to a website, program,
        /// or other application that is directed or targeted, in whole or in part, to children
        /// under age 13 and subject to COPPA. You may not specify a default value for the <code>childDirected</code>
        /// field that does not accurately reflect whether your use of Amazon Lex is related to
        /// a website, program, or other application that is directed or targeted, in whole or
        /// in part, to children under age 13 and subject to COPPA.</para><para>If your use of Amazon Lex relates to a website, program, or other application that
        /// is directed in whole or in part, to children under age 13, you must obtain any required
        /// verifiable parental consent under COPPA. For information regarding the use of Amazon
        /// Lex in connection with websites, programs, or other applications that are directed
        /// or targeted, in whole or in part, to children under age 13, see the <a href="https://aws.amazon.com/lex/faqs#data-security">Amazon
        /// Lex FAQ.</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ChildDirected { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the bot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IdleSessionTTLInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time in seconds that Amazon Lex retains the data gathered in a conversation.</para><para>A user interaction session remains active for the amount of time specified. If no
        /// conversation occurs during this time, the session expires and Amazon Lex deletes any
        /// data provided before the timeout.</para><para>For example, suppose that a user chooses the OrderPizza intent, but gets sidetracked
        /// halfway through placing an order. If the user doesn't complete the order within the
        /// specified time, Amazon Lex discards the slot information that it gathered, and the
        /// user must start over.</para><para>If you don't include the <code>idleSessionTTLInSeconds</code> element in a <code>PutBot</code>
        /// operation request, Amazon Lex uses the default value. This is also true if the request
        /// replaces an existing bot.</para><para>The default is 300 seconds (5 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IdleSessionTTLInSeconds")]
        public System.Int32 IdleSessionTTLInSecond { get; set; }
        #endregion
        
        #region Parameter Intent
        /// <summary>
        /// <para>
        /// <para>An array of <code>Intent</code> objects. Each intent represents a command that a user
        /// can express. For example, a pizza ordering bot might support an OrderPizza intent.
        /// For more information, see <a>how-it-works</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Intents")]
        public Amazon.LexModelBuildingService.Model.Intent[] Intent { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para> Specifies the target locale for the bot. Any intent used in the bot must be compatible
        /// with the locale of the bot. </para><para>The default is <code>en-US</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.LexModelBuildingService.Locale")]
        public Amazon.LexModelBuildingService.Locale Locale { get; set; }
        #endregion
        
        #region Parameter ClarificationPrompt_MaxAttempt
        /// <summary>
        /// <para>
        /// <para>The number of times to prompt the user for information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ClarificationPrompt_MaxAttempts")]
        public System.Int32 ClarificationPrompt_MaxAttempt { get; set; }
        #endregion
        
        #region Parameter ClarificationPrompt_Message
        /// <summary>
        /// <para>
        /// <para>An array of objects, each of which provides a message string and its type. You can
        /// specify the message string in plain text or in Speech Synthesis Markup Language (SSML).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ClarificationPrompt_Messages")]
        public Amazon.LexModelBuildingService.Model.Message[] ClarificationPrompt_Message { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the bot. The name is <i>not</i> case sensitive. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProcessBehavior
        /// <summary>
        /// <para>
        /// <para>If you set the <code>processBehavior</code> element to <code>Build</code>, Amazon
        /// Lex builds the bot so that it can be run. If you set the element to <code>Save</code>Amazon
        /// Lex saves the bot, but doesn't build it. </para><para>If you don't specify this value, the default value is <code>Save</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.LexModelBuildingService.ProcessBehavior")]
        public Amazon.LexModelBuildingService.ProcessBehavior ProcessBehavior { get; set; }
        #endregion
        
        #region Parameter ClarificationPrompt_ResponseCard
        /// <summary>
        /// <para>
        /// <para>A response card. Amazon Lex uses this prompt at runtime, in the <code>PostText</code>
        /// API response. It substitutes session attributes and slot values for placeholders in
        /// the response card. For more information, see <a>ex-resp-card</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClarificationPrompt_ResponseCard { get; set; }
        #endregion
        
        #region Parameter VoiceId
        /// <summary>
        /// <para>
        /// <para>The Amazon Polly voice ID that you want Amazon Lex to use for voice interactions with
        /// the user. The locale configured for the voice must match the locale of the bot. For
        /// more information, see <a href="http://docs.aws.amazon.com/polly/latest/dg/voicelist.html">Available
        /// Voices</a> in the <i>Amazon Polly Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VoiceId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-LMBBot (PutBot)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AbortStatement = this.AbortStatement;
            context.Checksum = this.Checksum;
            if (ParameterWasBound("ChildDirected"))
                context.ChildDirected = this.ChildDirected;
            if (ParameterWasBound("ClarificationPrompt_MaxAttempt"))
                context.ClarificationPrompt_MaxAttempts = this.ClarificationPrompt_MaxAttempt;
            if (this.ClarificationPrompt_Message != null)
            {
                context.ClarificationPrompt_Messages = new List<Amazon.LexModelBuildingService.Model.Message>(this.ClarificationPrompt_Message);
            }
            context.ClarificationPrompt_ResponseCard = this.ClarificationPrompt_ResponseCard;
            context.Description = this.Description;
            if (ParameterWasBound("IdleSessionTTLInSecond"))
                context.IdleSessionTTLInSeconds = this.IdleSessionTTLInSecond;
            if (this.Intent != null)
            {
                context.Intents = new List<Amazon.LexModelBuildingService.Model.Intent>(this.Intent);
            }
            context.Locale = this.Locale;
            context.Name = this.Name;
            context.ProcessBehavior = this.ProcessBehavior;
            context.VoiceId = this.VoiceId;
            
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
            var request = new Amazon.LexModelBuildingService.Model.PutBotRequest();
            
            if (cmdletContext.AbortStatement != null)
            {
                request.AbortStatement = cmdletContext.AbortStatement;
            }
            if (cmdletContext.Checksum != null)
            {
                request.Checksum = cmdletContext.Checksum;
            }
            if (cmdletContext.ChildDirected != null)
            {
                request.ChildDirected = cmdletContext.ChildDirected.Value;
            }
            
             // populate ClarificationPrompt
            bool requestClarificationPromptIsNull = true;
            request.ClarificationPrompt = new Amazon.LexModelBuildingService.Model.Prompt();
            System.Int32? requestClarificationPrompt_clarificationPrompt_MaxAttempt = null;
            if (cmdletContext.ClarificationPrompt_MaxAttempts != null)
            {
                requestClarificationPrompt_clarificationPrompt_MaxAttempt = cmdletContext.ClarificationPrompt_MaxAttempts.Value;
            }
            if (requestClarificationPrompt_clarificationPrompt_MaxAttempt != null)
            {
                request.ClarificationPrompt.MaxAttempts = requestClarificationPrompt_clarificationPrompt_MaxAttempt.Value;
                requestClarificationPromptIsNull = false;
            }
            List<Amazon.LexModelBuildingService.Model.Message> requestClarificationPrompt_clarificationPrompt_Message = null;
            if (cmdletContext.ClarificationPrompt_Messages != null)
            {
                requestClarificationPrompt_clarificationPrompt_Message = cmdletContext.ClarificationPrompt_Messages;
            }
            if (requestClarificationPrompt_clarificationPrompt_Message != null)
            {
                request.ClarificationPrompt.Messages = requestClarificationPrompt_clarificationPrompt_Message;
                requestClarificationPromptIsNull = false;
            }
            System.String requestClarificationPrompt_clarificationPrompt_ResponseCard = null;
            if (cmdletContext.ClarificationPrompt_ResponseCard != null)
            {
                requestClarificationPrompt_clarificationPrompt_ResponseCard = cmdletContext.ClarificationPrompt_ResponseCard;
            }
            if (requestClarificationPrompt_clarificationPrompt_ResponseCard != null)
            {
                request.ClarificationPrompt.ResponseCard = requestClarificationPrompt_clarificationPrompt_ResponseCard;
                requestClarificationPromptIsNull = false;
            }
             // determine if request.ClarificationPrompt should be set to null
            if (requestClarificationPromptIsNull)
            {
                request.ClarificationPrompt = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IdleSessionTTLInSeconds != null)
            {
                request.IdleSessionTTLInSeconds = cmdletContext.IdleSessionTTLInSeconds.Value;
            }
            if (cmdletContext.Intents != null)
            {
                request.Intents = cmdletContext.Intents;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProcessBehavior != null)
            {
                request.ProcessBehavior = cmdletContext.ProcessBehavior;
            }
            if (cmdletContext.VoiceId != null)
            {
                request.VoiceId = cmdletContext.VoiceId;
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
        
        private Amazon.LexModelBuildingService.Model.PutBotResponse CallAWSServiceOperation(IAmazonLexModelBuildingService client, Amazon.LexModelBuildingService.Model.PutBotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building Service", "PutBot");
            #if DESKTOP
            return client.PutBot(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PutBotAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Amazon.LexModelBuildingService.Model.Statement AbortStatement { get; set; }
            public System.String Checksum { get; set; }
            public System.Boolean? ChildDirected { get; set; }
            public System.Int32? ClarificationPrompt_MaxAttempts { get; set; }
            public List<Amazon.LexModelBuildingService.Model.Message> ClarificationPrompt_Messages { get; set; }
            public System.String ClarificationPrompt_ResponseCard { get; set; }
            public System.String Description { get; set; }
            public System.Int32? IdleSessionTTLInSeconds { get; set; }
            public List<Amazon.LexModelBuildingService.Model.Intent> Intents { get; set; }
            public Amazon.LexModelBuildingService.Locale Locale { get; set; }
            public System.String Name { get; set; }
            public Amazon.LexModelBuildingService.ProcessBehavior ProcessBehavior { get; set; }
            public System.String VoiceId { get; set; }
        }
        
    }
}
