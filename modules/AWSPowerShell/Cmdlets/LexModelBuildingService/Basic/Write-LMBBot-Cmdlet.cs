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
using Amazon.LexModelBuildingService;
using Amazon.LexModelBuildingService.Model;

namespace Amazon.PowerShell.Cmdlets.LMB
{
    /// <summary>
    /// Creates an Amazon Lex conversational bot or replaces an existing bot. When you create
    /// or update a bot you are only required to specify a name, a locale, and whether the
    /// bot is directed toward children under age 13. You can use this to add intents later,
    /// or to remove intents from an existing bot. When you create a bot with the minimum
    /// information, the bot is created or updated but Amazon Lex returns the <code /> response
    /// <code>FAILED</code>. You can build the bot after you add one or more intents. For
    /// more information about Amazon Lex bots, see <a>how-it-works</a>. 
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
    /// information, see <a>security-iam</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "LMBBot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelBuildingService.Model.PutBotResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building Service PutBot API operation.", Operation = new[] {"PutBot"}, SelectReturnType = typeof(Amazon.LexModelBuildingService.Model.PutBotResponse))]
    [AWSCmdletOutput("Amazon.LexModelBuildingService.Model.PutBotResponse",
        "This cmdlet returns an Amazon.LexModelBuildingService.Model.PutBotResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
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
        /// slot.</para><para>If you have defined a fallback intent the abort statement will not be sent to the
        /// user, the fallback intent is used instead. For more information, see <a href="https://docs.aws.amazon.com/lex/latest/dg/built-in-intent-fallback.html">
        /// AMAZON.FallbackIntent</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? ChildDirected { get; set; }
        #endregion
        
        #region Parameter CreateVersion
        /// <summary>
        /// <para>
        /// <para>When set to <code>true</code> a new numbered version of the bot is created. This is
        /// the same as calling the <code>CreateBotVersion</code> operation. If you don't specify
        /// <code>createVersion</code>, the default is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CreateVersion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the bot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DetectSentiment
        /// <summary>
        /// <para>
        /// <para>When set to <code>true</code> user utterances are sent to Amazon Comprehend for sentiment
        /// analysis. If you don't specify <code>detectSentiment</code>, the default is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DetectSentiment { get; set; }
        #endregion
        
        #region Parameter EnableModelImprovement
        /// <summary>
        /// <para>
        /// <para>Set to <code>true</code> to enable the use of a new natural language understanding
        /// (NLU) model. Using the new NLU may improve the performance of your bot. </para><para>When you set the <code>enableModelImprovements</code> parameter to <code>true</code>
        /// you can use the <code>nluIntentConfidenceThreshold</code> parameter to configure confidence
        /// scores. For more information, see <a href="https://docs.aws.amazon.com/lex/latest/dg/confidence-scores.html">Confidence
        /// Scores</a>.</para><para>You can only set the <code>enableModelImprovements</code> parameter in certain Regions.
        /// If you set the parameter to <code>true</code>, your bot will use the new NLU. If you
        /// set the parameter to <code>false</code>, your bot will continue to use the original
        /// NLU. If you set the parameter to <code>false</code> after setting it to <code>true</code>,
        /// your bot will return to the original NLU.</para><para>The Regions where you can set the <code>enableModelImprovements</code> parameter to
        /// <code>true</code> are:</para><ul><li><para>US East (N. Virginia) (us-east-1)</para></li><li><para>US West (Oregon) (us-west-2)</para></li><li><para>Asia Pacific (Sydney) (ap-southeast-2)</para></li><li><para>EU (Ireland) (eu-west-1)</para></li></ul><para>In other Regions, the <code>enableModelImprovements</code> parameter is set to <code>true</code>
        /// by default. In these Regions setting the parameter to <code>false</code> throws a
        /// <code>ValidationException</code> exception.</para><ul><li><para>Asia Pacific (Singapore) (ap-southeast-1)</para></li><li><para>Asia Pacific (Tokyo) (ap-northeast-1)</para></li><li><para>EU (Frankfurt) (eu-central-1)</para></li><li><para>EU (London) (eu-west-2)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableModelImprovements")]
        public System.Boolean? EnableModelImprovement { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdleSessionTTLInSeconds")]
        public System.Int32? IdleSessionTTLInSecond { get; set; }
        #endregion
        
        #region Parameter Intent
        /// <summary>
        /// <para>
        /// <para>An array of <code>Intent</code> objects. Each intent represents a command that a user
        /// can express. For example, a pizza ordering bot might support an OrderPizza intent.
        /// For more information, see <a>how-it-works</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LexModelBuildingService.Locale")]
        public Amazon.LexModelBuildingService.Locale Locale { get; set; }
        #endregion
        
        #region Parameter ClarificationPrompt_MaxAttempt
        /// <summary>
        /// <para>
        /// <para>The number of times to prompt the user for information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClarificationPrompt_MaxAttempts")]
        public System.Int32? ClarificationPrompt_MaxAttempt { get; set; }
        #endregion
        
        #region Parameter ClarificationPrompt_Message
        /// <summary>
        /// <para>
        /// <para>An array of objects, each of which provides a message string and its type. You can
        /// specify the message string in plain text or in Speech Synthesis Markup Language (SSML).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClarificationPrompt_Messages")]
        public Amazon.LexModelBuildingService.Model.Message[] ClarificationPrompt_Message { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the bot. The name is <i>not</i> case sensitive. </para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NluIntentConfidenceThreshold
        /// <summary>
        /// <para>
        /// <para>Determines the threshold where Amazon Lex will insert the <code>AMAZON.FallbackIntent</code>,
        /// <code>AMAZON.KendraSearchIntent</code>, or both when returning alternative intents
        /// in a <a href="https://docs.aws.amazon.com/lex/latest/dg/API_runtime_PostContent.html">PostContent</a>
        /// or <a href="https://docs.aws.amazon.com/lex/latest/dg/API_runtime_PostText.html">PostText</a>
        /// response. <code>AMAZON.FallbackIntent</code> and <code>AMAZON.KendraSearchIntent</code>
        /// are only inserted if they are configured for the bot.</para><para>You must set the <code>enableModelImprovements</code> parameter to <code>true</code>
        /// to use confidence scores.</para><para>For example, suppose a bot is configured with the confidence threshold of 0.80 and
        /// the <code>AMAZON.FallbackIntent</code>. Amazon Lex returns three alternative intents
        /// with the following confidence scores: IntentA (0.70), IntentB (0.60), IntentC (0.50).
        /// The response from the <code>PostText</code> operation would be:</para><ul><li><para>AMAZON.FallbackIntent</para></li><li><para>IntentA</para></li><li><para>IntentB</para></li><li><para>IntentC</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? NluIntentConfidenceThreshold { get; set; }
        #endregion
        
        #region Parameter ProcessBehavior
        /// <summary>
        /// <para>
        /// <para>If you set the <code>processBehavior</code> element to <code>BUILD</code>, Amazon
        /// Lex builds the bot so that it can be run. If you set the element to <code>SAVE</code>
        /// Amazon Lex saves the bot, but doesn't build it. </para><para>If you don't specify this value, the default value is <code>BUILD</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClarificationPrompt_ResponseCard { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to add to the bot. You can only add tags when you create a bot, you
        /// can't use the <code>PutBot</code> operation to update the tags on a bot. To update
        /// tags, use the <code>TagResource</code> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.LexModelBuildingService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VoiceId
        /// <summary>
        /// <para>
        /// <para>The Amazon Polly voice ID that you want Amazon Lex to use for voice interactions with
        /// the user. The locale configured for the voice must match the locale of the bot. For
        /// more information, see <a href="https://docs.aws.amazon.com/polly/latest/dg/voicelist.html">Voices
        /// in Amazon Polly</a> in the <i>Amazon Polly Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VoiceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelBuildingService.Model.PutBotResponse).
        /// Specifying the name of a property of type Amazon.LexModelBuildingService.Model.PutBotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-LMBBot (PutBot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelBuildingService.Model.PutBotResponse, WriteLMBBotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AbortStatement = this.AbortStatement;
            context.Checksum = this.Checksum;
            context.ChildDirected = this.ChildDirected;
            #if MODULAR
            if (this.ChildDirected == null && ParameterWasBound(nameof(this.ChildDirected)))
            {
                WriteWarning("You are passing $null as a value for parameter ChildDirected which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClarificationPrompt_MaxAttempt = this.ClarificationPrompt_MaxAttempt;
            if (this.ClarificationPrompt_Message != null)
            {
                context.ClarificationPrompt_Message = new List<Amazon.LexModelBuildingService.Model.Message>(this.ClarificationPrompt_Message);
            }
            context.ClarificationPrompt_ResponseCard = this.ClarificationPrompt_ResponseCard;
            context.CreateVersion = this.CreateVersion;
            context.Description = this.Description;
            context.DetectSentiment = this.DetectSentiment;
            context.EnableModelImprovement = this.EnableModelImprovement;
            context.IdleSessionTTLInSecond = this.IdleSessionTTLInSecond;
            if (this.Intent != null)
            {
                context.Intent = new List<Amazon.LexModelBuildingService.Model.Intent>(this.Intent);
            }
            context.Locale = this.Locale;
            #if MODULAR
            if (this.Locale == null && ParameterWasBound(nameof(this.Locale)))
            {
                WriteWarning("You are passing $null as a value for parameter Locale which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NluIntentConfidenceThreshold = this.NluIntentConfidenceThreshold;
            context.ProcessBehavior = this.ProcessBehavior;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.LexModelBuildingService.Model.Tag>(this.Tag);
            }
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
            var requestClarificationPromptIsNull = true;
            request.ClarificationPrompt = new Amazon.LexModelBuildingService.Model.Prompt();
            System.Int32? requestClarificationPrompt_clarificationPrompt_MaxAttempt = null;
            if (cmdletContext.ClarificationPrompt_MaxAttempt != null)
            {
                requestClarificationPrompt_clarificationPrompt_MaxAttempt = cmdletContext.ClarificationPrompt_MaxAttempt.Value;
            }
            if (requestClarificationPrompt_clarificationPrompt_MaxAttempt != null)
            {
                request.ClarificationPrompt.MaxAttempts = requestClarificationPrompt_clarificationPrompt_MaxAttempt.Value;
                requestClarificationPromptIsNull = false;
            }
            List<Amazon.LexModelBuildingService.Model.Message> requestClarificationPrompt_clarificationPrompt_Message = null;
            if (cmdletContext.ClarificationPrompt_Message != null)
            {
                requestClarificationPrompt_clarificationPrompt_Message = cmdletContext.ClarificationPrompt_Message;
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
            if (cmdletContext.CreateVersion != null)
            {
                request.CreateVersion = cmdletContext.CreateVersion.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DetectSentiment != null)
            {
                request.DetectSentiment = cmdletContext.DetectSentiment.Value;
            }
            if (cmdletContext.EnableModelImprovement != null)
            {
                request.EnableModelImprovements = cmdletContext.EnableModelImprovement.Value;
            }
            if (cmdletContext.IdleSessionTTLInSecond != null)
            {
                request.IdleSessionTTLInSeconds = cmdletContext.IdleSessionTTLInSecond.Value;
            }
            if (cmdletContext.Intent != null)
            {
                request.Intents = cmdletContext.Intent;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NluIntentConfidenceThreshold != null)
            {
                request.NluIntentConfidenceThreshold = cmdletContext.NluIntentConfidenceThreshold.Value;
            }
            if (cmdletContext.ProcessBehavior != null)
            {
                request.ProcessBehavior = cmdletContext.ProcessBehavior;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VoiceId != null)
            {
                request.VoiceId = cmdletContext.VoiceId;
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
        
        private Amazon.LexModelBuildingService.Model.PutBotResponse CallAWSServiceOperation(IAmazonLexModelBuildingService client, Amazon.LexModelBuildingService.Model.PutBotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building Service", "PutBot");
            try
            {
                #if DESKTOP
                return client.PutBot(request);
                #elif CORECLR
                return client.PutBotAsync(request).GetAwaiter().GetResult();
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
            public Amazon.LexModelBuildingService.Model.Statement AbortStatement { get; set; }
            public System.String Checksum { get; set; }
            public System.Boolean? ChildDirected { get; set; }
            public System.Int32? ClarificationPrompt_MaxAttempt { get; set; }
            public List<Amazon.LexModelBuildingService.Model.Message> ClarificationPrompt_Message { get; set; }
            public System.String ClarificationPrompt_ResponseCard { get; set; }
            public System.Boolean? CreateVersion { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? DetectSentiment { get; set; }
            public System.Boolean? EnableModelImprovement { get; set; }
            public System.Int32? IdleSessionTTLInSecond { get; set; }
            public List<Amazon.LexModelBuildingService.Model.Intent> Intent { get; set; }
            public Amazon.LexModelBuildingService.Locale Locale { get; set; }
            public System.String Name { get; set; }
            public System.Double? NluIntentConfidenceThreshold { get; set; }
            public Amazon.LexModelBuildingService.ProcessBehavior ProcessBehavior { get; set; }
            public List<Amazon.LexModelBuildingService.Model.Tag> Tag { get; set; }
            public System.String VoiceId { get; set; }
            public System.Func<Amazon.LexModelBuildingService.Model.PutBotResponse, WriteLMBBotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
