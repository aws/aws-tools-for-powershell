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
    /// Creates an intent or replaces an existing intent.
    /// 
    ///  
    /// <para>
    /// To define the interaction between the user and your bot, you use one or more intents.
    /// For a pizza ordering bot, for example, you would create an <code>OrderPizza</code>
    /// intent. 
    /// </para><para>
    /// To create an intent or replace an existing intent, you must provide the following:
    /// </para><ul><li><para>
    /// Intent name. For example, <code>OrderPizza</code>.
    /// </para></li><li><para>
    /// Sample utterances. For example, "Can I order a pizza, please." and "I want to order
    /// a pizza."
    /// </para></li><li><para>
    /// Information to be gathered. You specify slot types for the information that your bot
    /// will request from the user. You can specify standard slot types, such as a date or
    /// a time, or custom slot types such as the size and crust of a pizza.
    /// </para></li><li><para>
    /// How the intent will be fulfilled. You can provide a Lambda function or configure the
    /// intent to return the intent information to the client application. If you use a Lambda
    /// function, when all of the intent information is available, Amazon Lex invokes your
    /// Lambda function. If you configure your intent to return the intent information to
    /// the client application. 
    /// </para></li></ul><para>
    /// You can specify other optional information in the request, such as:
    /// </para><ul><li><para>
    /// A confirmation prompt to ask the user to confirm an intent. For example, "Shall I
    /// order your pizza?"
    /// </para></li><li><para>
    /// A conclusion statement to send to the user after the intent has been fulfilled. For
    /// example, "I placed your pizza order."
    /// </para></li><li><para>
    /// A follow-up prompt that asks the user for additional activity. For example, asking
    /// "Do you want to order a drink with your pizza?"
    /// </para></li></ul><para>
    /// If you specify an existing intent name to update the intent, Amazon Lex replaces the
    /// values in the <code>$LATEST</code> version of the intent with the values in the request.
    /// Amazon Lex removes fields that you don't provide in the request. If you don't specify
    /// the required fields, Amazon Lex throws an exception. When you update the <code>$LATEST</code>
    /// version of an intent, the <code>status</code> field of any bot that uses the <code>$LATEST</code>
    /// version of the intent is set to <code>NOT_BUILT</code>.
    /// </para><para>
    /// For more information, see <a>how-it-works</a>.
    /// </para><para>
    /// This operation requires permissions for the <code>lex:PutIntent</code> action.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "LMBIntent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelBuildingService.Model.PutIntentResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building Service PutIntent API operation.", Operation = new[] {"PutIntent"}, SelectReturnType = typeof(Amazon.LexModelBuildingService.Model.PutIntentResponse))]
    [AWSCmdletOutput("Amazon.LexModelBuildingService.Model.PutIntentResponse",
        "This cmdlet returns an Amazon.LexModelBuildingService.Model.PutIntentResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteLMBIntentCmdlet : AmazonLexModelBuildingServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Checksum
        /// <summary>
        /// <para>
        /// <para>Identifies a specific revision of the <code>$LATEST</code> version.</para><para>When you create a new intent, leave the <code>checksum</code> field blank. If you
        /// specify a checksum you get a <code>BadRequestException</code> exception.</para><para>When you want to update a intent, set the <code>checksum</code> field to the checksum
        /// of the most recent revision of the <code>$LATEST</code> version. If you don't specify
        /// the <code> checksum</code> field, or if the checksum does not match the <code>$LATEST</code>
        /// version, you get a <code>PreconditionFailedException</code> exception.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Checksum { get; set; }
        #endregion
        
        #region Parameter ConclusionStatement
        /// <summary>
        /// <para>
        /// <para> The statement that you want Amazon Lex to convey to the user after the intent is
        /// successfully fulfilled by the Lambda function. </para><para>This element is relevant only if you provide a Lambda function in the <code>fulfillmentActivity</code>.
        /// If you return the intent to the client application, you can't specify this element.</para><note><para>The <code>followUpPrompt</code> and <code>conclusionStatement</code> are mutually
        /// exclusive. You can specify only one.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LexModelBuildingService.Model.Statement ConclusionStatement { get; set; }
        #endregion
        
        #region Parameter CreateVersion
        /// <summary>
        /// <para>
        /// <para>When set to <code>true</code> a new numbered version of the intent is created. This
        /// is the same as calling the <code>CreateIntentVersion</code> operation. If you do not
        /// specify <code>createVersion</code>, the default is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CreateVersion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the intent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InputContext
        /// <summary>
        /// <para>
        /// <para>An array of <code>InputContext</code> objects that lists the contexts that must be
        /// active for Amazon Lex to choose the intent in a conversation with the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputContexts")]
        public Amazon.LexModelBuildingService.Model.InputContext[] InputContext { get; set; }
        #endregion
        
        #region Parameter KendraConfiguration_KendraIndex
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Kendra index that you want the AMAZON.KendraSearchIntent
        /// intent to search. The index must be in the same account and Region as the Amazon Lex
        /// bot. If the Amazon Kendra index does not exist, you get an exception when you call
        /// the <code>PutIntent</code> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KendraConfiguration_KendraIndex { get; set; }
        #endregion
        
        #region Parameter ConfirmationPrompt_MaxAttempt
        /// <summary>
        /// <para>
        /// <para>The number of times to prompt the user for information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfirmationPrompt_MaxAttempts")]
        public System.Int32? ConfirmationPrompt_MaxAttempt { get; set; }
        #endregion
        
        #region Parameter Prompt_MaxAttempt
        /// <summary>
        /// <para>
        /// <para>The number of times to prompt the user for information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FollowUpPrompt_Prompt_MaxAttempts")]
        public System.Int32? Prompt_MaxAttempt { get; set; }
        #endregion
        
        #region Parameter ConfirmationPrompt_Message
        /// <summary>
        /// <para>
        /// <para>An array of objects, each of which provides a message string and its type. You can
        /// specify the message string in plain text or in Speech Synthesis Markup Language (SSML).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfirmationPrompt_Messages")]
        public Amazon.LexModelBuildingService.Model.Message[] ConfirmationPrompt_Message { get; set; }
        #endregion
        
        #region Parameter Prompt_Message
        /// <summary>
        /// <para>
        /// <para>An array of objects, each of which provides a message string and its type. You can
        /// specify the message string in plain text or in Speech Synthesis Markup Language (SSML).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FollowUpPrompt_Prompt_Messages")]
        public Amazon.LexModelBuildingService.Model.Message[] Prompt_Message { get; set; }
        #endregion
        
        #region Parameter DialogCodeHook_MessageVersion
        /// <summary>
        /// <para>
        /// <para>The version of the request-response that you want Amazon Lex to use to invoke your
        /// Lambda function. For more information, see <a>using-lambda</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DialogCodeHook_MessageVersion { get; set; }
        #endregion
        
        #region Parameter CodeHook_MessageVersion
        /// <summary>
        /// <para>
        /// <para>The version of the request-response that you want Amazon Lex to use to invoke your
        /// Lambda function. For more information, see <a>using-lambda</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentActivity_CodeHook_MessageVersion")]
        public System.String CodeHook_MessageVersion { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the intent. The name is <i>not</i> case sensitive. </para><para>The name can't match a built-in intent name, or a built-in intent name with "AMAZON."
        /// removed. For example, because there is a built-in intent called <code>AMAZON.HelpIntent</code>,
        /// you can't create a custom intent called <code>HelpIntent</code>.</para><para>For a list of built-in intents, see <a href="https://developer.amazon.com/public/solutions/alexa/alexa-skills-kit/docs/built-in-intent-ref/standard-intents">Standard
        /// Built-in Intents</a> in the <i>Alexa Skills Kit</i>.</para>
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
        
        #region Parameter OutputContext
        /// <summary>
        /// <para>
        /// <para>An array of <code>OutputContext</code> objects that lists the contexts that the intent
        /// activates when the intent is fulfilled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputContexts")]
        public Amazon.LexModelBuildingService.Model.OutputContext[] OutputContext { get; set; }
        #endregion
        
        #region Parameter ParentIntentSignature
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the built-in intent to base this intent on. To find the signature
        /// for an intent, see <a href="https://developer.amazon.com/public/solutions/alexa/alexa-skills-kit/docs/built-in-intent-ref/standard-intents">Standard
        /// Built-in Intents</a> in the <i>Alexa Skills Kit</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentIntentSignature { get; set; }
        #endregion
        
        #region Parameter KendraConfiguration_QueryFilterString
        /// <summary>
        /// <para>
        /// <para>A query filter that Amazon Lex sends to Amazon Kendra to filter the response from
        /// the query. The filter is in the format defined by Amazon Kendra. For more information,
        /// see <a href="http://docs.aws.amazon.com/kendra/latest/dg/filtering.html">Filtering
        /// queries</a>.</para><para>You can override this filter string with a new filter string at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KendraConfiguration_QueryFilterString { get; set; }
        #endregion
        
        #region Parameter FollowUpPrompt_RejectionStatement
        /// <summary>
        /// <para>
        /// <para>If the user answers "no" to the question defined in the <code>prompt</code> field,
        /// Amazon Lex responds with this statement to acknowledge that the intent was canceled.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LexModelBuildingService.Model.Statement FollowUpPrompt_RejectionStatement { get; set; }
        #endregion
        
        #region Parameter RejectionStatement
        /// <summary>
        /// <para>
        /// <para>When the user answers "no" to the question defined in <code>confirmationPrompt</code>,
        /// Amazon Lex responds with this statement to acknowledge that the intent was canceled.
        /// </para><note><para>You must provide both the <code>rejectionStatement</code> and the <code>confirmationPrompt</code>,
        /// or neither.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LexModelBuildingService.Model.Statement RejectionStatement { get; set; }
        #endregion
        
        #region Parameter ConfirmationPrompt_ResponseCard
        /// <summary>
        /// <para>
        /// <para>A response card. Amazon Lex uses this prompt at runtime, in the <code>PostText</code>
        /// API response. It substitutes session attributes and slot values for placeholders in
        /// the response card. For more information, see <a>ex-resp-card</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfirmationPrompt_ResponseCard { get; set; }
        #endregion
        
        #region Parameter Prompt_ResponseCard
        /// <summary>
        /// <para>
        /// <para>A response card. Amazon Lex uses this prompt at runtime, in the <code>PostText</code>
        /// API response. It substitutes session attributes and slot values for placeholders in
        /// the response card. For more information, see <a>ex-resp-card</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FollowUpPrompt_Prompt_ResponseCard")]
        public System.String Prompt_ResponseCard { get; set; }
        #endregion
        
        #region Parameter KendraConfiguration_Role
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that has permission to search the Amazon
        /// Kendra index. The role must be in the same account and Region as the Amazon Lex bot.
        /// If the role does not exist, you get an exception when you call the <code>PutIntent</code>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KendraConfiguration_Role { get; set; }
        #endregion
        
        #region Parameter SampleUtterance
        /// <summary>
        /// <para>
        /// <para>An array of utterances (strings) that a user might say to signal the intent. For example,
        /// "I want {PizzaSize} pizza", "Order {Quantity} {PizzaSize} pizzas". </para><para>In each utterance, a slot name is enclosed in curly braces. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SampleUtterances")]
        public System.String[] SampleUtterance { get; set; }
        #endregion
        
        #region Parameter Slot
        /// <summary>
        /// <para>
        /// <para>An array of intent slots. At runtime, Amazon Lex elicits required slot values from
        /// the user using prompts defined in the slots. For more information, see <a>how-it-works</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Slots")]
        public Amazon.LexModelBuildingService.Model.Slot[] Slot { get; set; }
        #endregion
        
        #region Parameter FulfillmentActivity_Type
        /// <summary>
        /// <para>
        /// <para> How the intent should be fulfilled, either by running a Lambda function or by returning
        /// the slot data to the client application. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelBuildingService.FulfillmentActivityType")]
        public Amazon.LexModelBuildingService.FulfillmentActivityType FulfillmentActivity_Type { get; set; }
        #endregion
        
        #region Parameter DialogCodeHook_Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DialogCodeHook_Uri { get; set; }
        #endregion
        
        #region Parameter CodeHook_Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FulfillmentActivity_CodeHook_Uri")]
        public System.String CodeHook_Uri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelBuildingService.Model.PutIntentResponse).
        /// Specifying the name of a property of type Amazon.LexModelBuildingService.Model.PutIntentResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-LMBIntent (PutIntent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelBuildingService.Model.PutIntentResponse, WriteLMBIntentCmdlet>(Select) ??
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
            context.Checksum = this.Checksum;
            context.ConclusionStatement = this.ConclusionStatement;
            context.ConfirmationPrompt_MaxAttempt = this.ConfirmationPrompt_MaxAttempt;
            if (this.ConfirmationPrompt_Message != null)
            {
                context.ConfirmationPrompt_Message = new List<Amazon.LexModelBuildingService.Model.Message>(this.ConfirmationPrompt_Message);
            }
            context.ConfirmationPrompt_ResponseCard = this.ConfirmationPrompt_ResponseCard;
            context.CreateVersion = this.CreateVersion;
            context.Description = this.Description;
            context.DialogCodeHook_MessageVersion = this.DialogCodeHook_MessageVersion;
            context.DialogCodeHook_Uri = this.DialogCodeHook_Uri;
            context.Prompt_MaxAttempt = this.Prompt_MaxAttempt;
            if (this.Prompt_Message != null)
            {
                context.Prompt_Message = new List<Amazon.LexModelBuildingService.Model.Message>(this.Prompt_Message);
            }
            context.Prompt_ResponseCard = this.Prompt_ResponseCard;
            context.FollowUpPrompt_RejectionStatement = this.FollowUpPrompt_RejectionStatement;
            context.CodeHook_MessageVersion = this.CodeHook_MessageVersion;
            context.CodeHook_Uri = this.CodeHook_Uri;
            context.FulfillmentActivity_Type = this.FulfillmentActivity_Type;
            if (this.InputContext != null)
            {
                context.InputContext = new List<Amazon.LexModelBuildingService.Model.InputContext>(this.InputContext);
            }
            context.KendraConfiguration_KendraIndex = this.KendraConfiguration_KendraIndex;
            context.KendraConfiguration_QueryFilterString = this.KendraConfiguration_QueryFilterString;
            context.KendraConfiguration_Role = this.KendraConfiguration_Role;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OutputContext != null)
            {
                context.OutputContext = new List<Amazon.LexModelBuildingService.Model.OutputContext>(this.OutputContext);
            }
            context.ParentIntentSignature = this.ParentIntentSignature;
            context.RejectionStatement = this.RejectionStatement;
            if (this.SampleUtterance != null)
            {
                context.SampleUtterance = new List<System.String>(this.SampleUtterance);
            }
            if (this.Slot != null)
            {
                context.Slot = new List<Amazon.LexModelBuildingService.Model.Slot>(this.Slot);
            }
            
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
            var request = new Amazon.LexModelBuildingService.Model.PutIntentRequest();
            
            if (cmdletContext.Checksum != null)
            {
                request.Checksum = cmdletContext.Checksum;
            }
            if (cmdletContext.ConclusionStatement != null)
            {
                request.ConclusionStatement = cmdletContext.ConclusionStatement;
            }
            
             // populate ConfirmationPrompt
            var requestConfirmationPromptIsNull = true;
            request.ConfirmationPrompt = new Amazon.LexModelBuildingService.Model.Prompt();
            System.Int32? requestConfirmationPrompt_confirmationPrompt_MaxAttempt = null;
            if (cmdletContext.ConfirmationPrompt_MaxAttempt != null)
            {
                requestConfirmationPrompt_confirmationPrompt_MaxAttempt = cmdletContext.ConfirmationPrompt_MaxAttempt.Value;
            }
            if (requestConfirmationPrompt_confirmationPrompt_MaxAttempt != null)
            {
                request.ConfirmationPrompt.MaxAttempts = requestConfirmationPrompt_confirmationPrompt_MaxAttempt.Value;
                requestConfirmationPromptIsNull = false;
            }
            List<Amazon.LexModelBuildingService.Model.Message> requestConfirmationPrompt_confirmationPrompt_Message = null;
            if (cmdletContext.ConfirmationPrompt_Message != null)
            {
                requestConfirmationPrompt_confirmationPrompt_Message = cmdletContext.ConfirmationPrompt_Message;
            }
            if (requestConfirmationPrompt_confirmationPrompt_Message != null)
            {
                request.ConfirmationPrompt.Messages = requestConfirmationPrompt_confirmationPrompt_Message;
                requestConfirmationPromptIsNull = false;
            }
            System.String requestConfirmationPrompt_confirmationPrompt_ResponseCard = null;
            if (cmdletContext.ConfirmationPrompt_ResponseCard != null)
            {
                requestConfirmationPrompt_confirmationPrompt_ResponseCard = cmdletContext.ConfirmationPrompt_ResponseCard;
            }
            if (requestConfirmationPrompt_confirmationPrompt_ResponseCard != null)
            {
                request.ConfirmationPrompt.ResponseCard = requestConfirmationPrompt_confirmationPrompt_ResponseCard;
                requestConfirmationPromptIsNull = false;
            }
             // determine if request.ConfirmationPrompt should be set to null
            if (requestConfirmationPromptIsNull)
            {
                request.ConfirmationPrompt = null;
            }
            if (cmdletContext.CreateVersion != null)
            {
                request.CreateVersion = cmdletContext.CreateVersion.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate DialogCodeHook
            var requestDialogCodeHookIsNull = true;
            request.DialogCodeHook = new Amazon.LexModelBuildingService.Model.CodeHook();
            System.String requestDialogCodeHook_dialogCodeHook_MessageVersion = null;
            if (cmdletContext.DialogCodeHook_MessageVersion != null)
            {
                requestDialogCodeHook_dialogCodeHook_MessageVersion = cmdletContext.DialogCodeHook_MessageVersion;
            }
            if (requestDialogCodeHook_dialogCodeHook_MessageVersion != null)
            {
                request.DialogCodeHook.MessageVersion = requestDialogCodeHook_dialogCodeHook_MessageVersion;
                requestDialogCodeHookIsNull = false;
            }
            System.String requestDialogCodeHook_dialogCodeHook_Uri = null;
            if (cmdletContext.DialogCodeHook_Uri != null)
            {
                requestDialogCodeHook_dialogCodeHook_Uri = cmdletContext.DialogCodeHook_Uri;
            }
            if (requestDialogCodeHook_dialogCodeHook_Uri != null)
            {
                request.DialogCodeHook.Uri = requestDialogCodeHook_dialogCodeHook_Uri;
                requestDialogCodeHookIsNull = false;
            }
             // determine if request.DialogCodeHook should be set to null
            if (requestDialogCodeHookIsNull)
            {
                request.DialogCodeHook = null;
            }
            
             // populate FollowUpPrompt
            var requestFollowUpPromptIsNull = true;
            request.FollowUpPrompt = new Amazon.LexModelBuildingService.Model.FollowUpPrompt();
            Amazon.LexModelBuildingService.Model.Statement requestFollowUpPrompt_followUpPrompt_RejectionStatement = null;
            if (cmdletContext.FollowUpPrompt_RejectionStatement != null)
            {
                requestFollowUpPrompt_followUpPrompt_RejectionStatement = cmdletContext.FollowUpPrompt_RejectionStatement;
            }
            if (requestFollowUpPrompt_followUpPrompt_RejectionStatement != null)
            {
                request.FollowUpPrompt.RejectionStatement = requestFollowUpPrompt_followUpPrompt_RejectionStatement;
                requestFollowUpPromptIsNull = false;
            }
            Amazon.LexModelBuildingService.Model.Prompt requestFollowUpPrompt_followUpPrompt_Prompt = null;
            
             // populate Prompt
            var requestFollowUpPrompt_followUpPrompt_PromptIsNull = true;
            requestFollowUpPrompt_followUpPrompt_Prompt = new Amazon.LexModelBuildingService.Model.Prompt();
            System.Int32? requestFollowUpPrompt_followUpPrompt_Prompt_prompt_MaxAttempt = null;
            if (cmdletContext.Prompt_MaxAttempt != null)
            {
                requestFollowUpPrompt_followUpPrompt_Prompt_prompt_MaxAttempt = cmdletContext.Prompt_MaxAttempt.Value;
            }
            if (requestFollowUpPrompt_followUpPrompt_Prompt_prompt_MaxAttempt != null)
            {
                requestFollowUpPrompt_followUpPrompt_Prompt.MaxAttempts = requestFollowUpPrompt_followUpPrompt_Prompt_prompt_MaxAttempt.Value;
                requestFollowUpPrompt_followUpPrompt_PromptIsNull = false;
            }
            List<Amazon.LexModelBuildingService.Model.Message> requestFollowUpPrompt_followUpPrompt_Prompt_prompt_Message = null;
            if (cmdletContext.Prompt_Message != null)
            {
                requestFollowUpPrompt_followUpPrompt_Prompt_prompt_Message = cmdletContext.Prompt_Message;
            }
            if (requestFollowUpPrompt_followUpPrompt_Prompt_prompt_Message != null)
            {
                requestFollowUpPrompt_followUpPrompt_Prompt.Messages = requestFollowUpPrompt_followUpPrompt_Prompt_prompt_Message;
                requestFollowUpPrompt_followUpPrompt_PromptIsNull = false;
            }
            System.String requestFollowUpPrompt_followUpPrompt_Prompt_prompt_ResponseCard = null;
            if (cmdletContext.Prompt_ResponseCard != null)
            {
                requestFollowUpPrompt_followUpPrompt_Prompt_prompt_ResponseCard = cmdletContext.Prompt_ResponseCard;
            }
            if (requestFollowUpPrompt_followUpPrompt_Prompt_prompt_ResponseCard != null)
            {
                requestFollowUpPrompt_followUpPrompt_Prompt.ResponseCard = requestFollowUpPrompt_followUpPrompt_Prompt_prompt_ResponseCard;
                requestFollowUpPrompt_followUpPrompt_PromptIsNull = false;
            }
             // determine if requestFollowUpPrompt_followUpPrompt_Prompt should be set to null
            if (requestFollowUpPrompt_followUpPrompt_PromptIsNull)
            {
                requestFollowUpPrompt_followUpPrompt_Prompt = null;
            }
            if (requestFollowUpPrompt_followUpPrompt_Prompt != null)
            {
                request.FollowUpPrompt.Prompt = requestFollowUpPrompt_followUpPrompt_Prompt;
                requestFollowUpPromptIsNull = false;
            }
             // determine if request.FollowUpPrompt should be set to null
            if (requestFollowUpPromptIsNull)
            {
                request.FollowUpPrompt = null;
            }
            
             // populate FulfillmentActivity
            var requestFulfillmentActivityIsNull = true;
            request.FulfillmentActivity = new Amazon.LexModelBuildingService.Model.FulfillmentActivity();
            Amazon.LexModelBuildingService.FulfillmentActivityType requestFulfillmentActivity_fulfillmentActivity_Type = null;
            if (cmdletContext.FulfillmentActivity_Type != null)
            {
                requestFulfillmentActivity_fulfillmentActivity_Type = cmdletContext.FulfillmentActivity_Type;
            }
            if (requestFulfillmentActivity_fulfillmentActivity_Type != null)
            {
                request.FulfillmentActivity.Type = requestFulfillmentActivity_fulfillmentActivity_Type;
                requestFulfillmentActivityIsNull = false;
            }
            Amazon.LexModelBuildingService.Model.CodeHook requestFulfillmentActivity_fulfillmentActivity_CodeHook = null;
            
             // populate CodeHook
            var requestFulfillmentActivity_fulfillmentActivity_CodeHookIsNull = true;
            requestFulfillmentActivity_fulfillmentActivity_CodeHook = new Amazon.LexModelBuildingService.Model.CodeHook();
            System.String requestFulfillmentActivity_fulfillmentActivity_CodeHook_codeHook_MessageVersion = null;
            if (cmdletContext.CodeHook_MessageVersion != null)
            {
                requestFulfillmentActivity_fulfillmentActivity_CodeHook_codeHook_MessageVersion = cmdletContext.CodeHook_MessageVersion;
            }
            if (requestFulfillmentActivity_fulfillmentActivity_CodeHook_codeHook_MessageVersion != null)
            {
                requestFulfillmentActivity_fulfillmentActivity_CodeHook.MessageVersion = requestFulfillmentActivity_fulfillmentActivity_CodeHook_codeHook_MessageVersion;
                requestFulfillmentActivity_fulfillmentActivity_CodeHookIsNull = false;
            }
            System.String requestFulfillmentActivity_fulfillmentActivity_CodeHook_codeHook_Uri = null;
            if (cmdletContext.CodeHook_Uri != null)
            {
                requestFulfillmentActivity_fulfillmentActivity_CodeHook_codeHook_Uri = cmdletContext.CodeHook_Uri;
            }
            if (requestFulfillmentActivity_fulfillmentActivity_CodeHook_codeHook_Uri != null)
            {
                requestFulfillmentActivity_fulfillmentActivity_CodeHook.Uri = requestFulfillmentActivity_fulfillmentActivity_CodeHook_codeHook_Uri;
                requestFulfillmentActivity_fulfillmentActivity_CodeHookIsNull = false;
            }
             // determine if requestFulfillmentActivity_fulfillmentActivity_CodeHook should be set to null
            if (requestFulfillmentActivity_fulfillmentActivity_CodeHookIsNull)
            {
                requestFulfillmentActivity_fulfillmentActivity_CodeHook = null;
            }
            if (requestFulfillmentActivity_fulfillmentActivity_CodeHook != null)
            {
                request.FulfillmentActivity.CodeHook = requestFulfillmentActivity_fulfillmentActivity_CodeHook;
                requestFulfillmentActivityIsNull = false;
            }
             // determine if request.FulfillmentActivity should be set to null
            if (requestFulfillmentActivityIsNull)
            {
                request.FulfillmentActivity = null;
            }
            if (cmdletContext.InputContext != null)
            {
                request.InputContexts = cmdletContext.InputContext;
            }
            
             // populate KendraConfiguration
            var requestKendraConfigurationIsNull = true;
            request.KendraConfiguration = new Amazon.LexModelBuildingService.Model.KendraConfiguration();
            System.String requestKendraConfiguration_kendraConfiguration_KendraIndex = null;
            if (cmdletContext.KendraConfiguration_KendraIndex != null)
            {
                requestKendraConfiguration_kendraConfiguration_KendraIndex = cmdletContext.KendraConfiguration_KendraIndex;
            }
            if (requestKendraConfiguration_kendraConfiguration_KendraIndex != null)
            {
                request.KendraConfiguration.KendraIndex = requestKendraConfiguration_kendraConfiguration_KendraIndex;
                requestKendraConfigurationIsNull = false;
            }
            System.String requestKendraConfiguration_kendraConfiguration_QueryFilterString = null;
            if (cmdletContext.KendraConfiguration_QueryFilterString != null)
            {
                requestKendraConfiguration_kendraConfiguration_QueryFilterString = cmdletContext.KendraConfiguration_QueryFilterString;
            }
            if (requestKendraConfiguration_kendraConfiguration_QueryFilterString != null)
            {
                request.KendraConfiguration.QueryFilterString = requestKendraConfiguration_kendraConfiguration_QueryFilterString;
                requestKendraConfigurationIsNull = false;
            }
            System.String requestKendraConfiguration_kendraConfiguration_Role = null;
            if (cmdletContext.KendraConfiguration_Role != null)
            {
                requestKendraConfiguration_kendraConfiguration_Role = cmdletContext.KendraConfiguration_Role;
            }
            if (requestKendraConfiguration_kendraConfiguration_Role != null)
            {
                request.KendraConfiguration.Role = requestKendraConfiguration_kendraConfiguration_Role;
                requestKendraConfigurationIsNull = false;
            }
             // determine if request.KendraConfiguration should be set to null
            if (requestKendraConfigurationIsNull)
            {
                request.KendraConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OutputContext != null)
            {
                request.OutputContexts = cmdletContext.OutputContext;
            }
            if (cmdletContext.ParentIntentSignature != null)
            {
                request.ParentIntentSignature = cmdletContext.ParentIntentSignature;
            }
            if (cmdletContext.RejectionStatement != null)
            {
                request.RejectionStatement = cmdletContext.RejectionStatement;
            }
            if (cmdletContext.SampleUtterance != null)
            {
                request.SampleUtterances = cmdletContext.SampleUtterance;
            }
            if (cmdletContext.Slot != null)
            {
                request.Slots = cmdletContext.Slot;
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
        
        private Amazon.LexModelBuildingService.Model.PutIntentResponse CallAWSServiceOperation(IAmazonLexModelBuildingService client, Amazon.LexModelBuildingService.Model.PutIntentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building Service", "PutIntent");
            try
            {
                #if DESKTOP
                return client.PutIntent(request);
                #elif CORECLR
                return client.PutIntentAsync(request).GetAwaiter().GetResult();
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
            public System.String Checksum { get; set; }
            public Amazon.LexModelBuildingService.Model.Statement ConclusionStatement { get; set; }
            public System.Int32? ConfirmationPrompt_MaxAttempt { get; set; }
            public List<Amazon.LexModelBuildingService.Model.Message> ConfirmationPrompt_Message { get; set; }
            public System.String ConfirmationPrompt_ResponseCard { get; set; }
            public System.Boolean? CreateVersion { get; set; }
            public System.String Description { get; set; }
            public System.String DialogCodeHook_MessageVersion { get; set; }
            public System.String DialogCodeHook_Uri { get; set; }
            public System.Int32? Prompt_MaxAttempt { get; set; }
            public List<Amazon.LexModelBuildingService.Model.Message> Prompt_Message { get; set; }
            public System.String Prompt_ResponseCard { get; set; }
            public Amazon.LexModelBuildingService.Model.Statement FollowUpPrompt_RejectionStatement { get; set; }
            public System.String CodeHook_MessageVersion { get; set; }
            public System.String CodeHook_Uri { get; set; }
            public Amazon.LexModelBuildingService.FulfillmentActivityType FulfillmentActivity_Type { get; set; }
            public List<Amazon.LexModelBuildingService.Model.InputContext> InputContext { get; set; }
            public System.String KendraConfiguration_KendraIndex { get; set; }
            public System.String KendraConfiguration_QueryFilterString { get; set; }
            public System.String KendraConfiguration_Role { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.LexModelBuildingService.Model.OutputContext> OutputContext { get; set; }
            public System.String ParentIntentSignature { get; set; }
            public Amazon.LexModelBuildingService.Model.Statement RejectionStatement { get; set; }
            public List<System.String> SampleUtterance { get; set; }
            public List<Amazon.LexModelBuildingService.Model.Slot> Slot { get; set; }
            public System.Func<Amazon.LexModelBuildingService.Model.PutIntentResponse, WriteLMBIntentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
