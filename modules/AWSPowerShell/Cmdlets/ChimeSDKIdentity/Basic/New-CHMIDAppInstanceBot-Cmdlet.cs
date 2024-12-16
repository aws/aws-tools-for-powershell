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
using Amazon.ChimeSDKIdentity;
using Amazon.ChimeSDKIdentity.Model;

namespace Amazon.PowerShell.Cmdlets.CHMID
{
    /// <summary>
    /// Creates a bot under an Amazon Chime <c>AppInstance</c>. The request consists of a
    /// unique <c>Configuration</c> and <c>Name</c> for that bot.
    /// </summary>
    [Cmdlet("New", "CHMIDAppInstanceBot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Chime SDK Identity CreateAppInstanceBot API operation.", Operation = new[] {"CreateAppInstanceBot"}, SelectReturnType = typeof(Amazon.ChimeSDKIdentity.Model.CreateAppInstanceBotResponse))]
    [AWSCmdletOutput("System.String or Amazon.ChimeSDKIdentity.Model.CreateAppInstanceBotResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ChimeSDKIdentity.Model.CreateAppInstanceBotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCHMIDAppInstanceBotCmdlet : AmazonChimeSDKIdentityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppInstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the <c>AppInstance</c> request.</para>
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
        public System.String AppInstanceArn { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The unique ID for the client making the request. Use different tokens for different
        /// <c>AppInstanceBots</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Lex_LexBotAliasArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Lex V2 bot's alias. The ARN uses this format: <c>arn:aws:lex:REGION:ACCOUNT:bot-alias/MYBOTID/MYBOTALIAS</c></para>
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
        [Alias("Configuration_Lex_LexBotAliasArn")]
        public System.String Lex_LexBotAliasArn { get; set; }
        #endregion
        
        #region Parameter Lex_LocaleId
        /// <summary>
        /// <para>
        /// <para>Identifies the Amazon Lex V2 bot's language and locale. The string must match one
        /// of the supported locales in Amazon Lex V2. All of the intents, slot types, and slots
        /// used in the bot must have the same locale. For more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/how-languages.html">Supported
        /// languages</a> in the <i>Amazon Lex V2 Developer Guide</i>.</para>
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
        [Alias("Configuration_Lex_LocaleId")]
        public System.String Lex_LocaleId { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>The request metadata. Limited to a 1KB string in UTF-8.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Metadata { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The user's name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Lex_RespondsTo
        /// <summary>
        /// <para>
        /// <important><para><b>Deprecated</b>. Use <c>InvokedBy</c> instead.</para></important><para>Determines whether the Amazon Lex V2 bot responds to all standard messages. Control
        /// messages are not supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Lex_RespondsTo")]
        [AWSConstantClassSource("Amazon.ChimeSDKIdentity.RespondsTo")]
        public Amazon.ChimeSDKIdentity.RespondsTo Lex_RespondsTo { get; set; }
        #endregion
        
        #region Parameter InvokedBy_StandardMessage
        /// <summary>
        /// <para>
        /// <para>Sets standard messages as the bot trigger. For standard messages:</para><ul><li><para><c>ALL</c>: The bot processes all standard messages.</para></li><li><para><c>AUTO</c>: The bot responds to ALL messages when the channel has one other non-hidden
        /// member, and responds to MENTIONS when the channel has more than one other non-hidden
        /// member.</para></li><li><para><c>MENTIONS</c>: The bot processes all standard messages that have a message attribute
        /// with <c>CHIME.mentions</c> and a value of the bot ARN.</para></li><li><para><c>NONE</c>: The bot processes no standard messages.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Lex_InvokedBy_StandardMessages")]
        [AWSConstantClassSource("Amazon.ChimeSDKIdentity.StandardMessages")]
        public Amazon.ChimeSDKIdentity.StandardMessages InvokedBy_StandardMessage { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags assigned to the <c>AppInstanceBot</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ChimeSDKIdentity.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter InvokedBy_TargetedMessage
        /// <summary>
        /// <para>
        /// <para>Sets targeted messages as the bot trigger. For targeted messages:</para><ul><li><para><c>ALL</c>: The bot processes all <c>TargetedMessages</c> sent to it. The bot then
        /// responds with a targeted message back to the sender. </para></li><li><para><c>NONE</c>: The bot processes no targeted messages.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Lex_InvokedBy_TargetedMessages")]
        [AWSConstantClassSource("Amazon.ChimeSDKIdentity.TargetedMessages")]
        public Amazon.ChimeSDKIdentity.TargetedMessages InvokedBy_TargetedMessage { get; set; }
        #endregion
        
        #region Parameter Lex_WelcomeIntent
        /// <summary>
        /// <para>
        /// <para>The name of the welcome intent configured in the Amazon Lex V2 bot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Lex_WelcomeIntent")]
        public System.String Lex_WelcomeIntent { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AppInstanceBotArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKIdentity.Model.CreateAppInstanceBotResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKIdentity.Model.CreateAppInstanceBotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AppInstanceBotArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppInstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMIDAppInstanceBot (CreateAppInstanceBot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKIdentity.Model.CreateAppInstanceBotResponse, NewCHMIDAppInstanceBotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppInstanceArn = this.AppInstanceArn;
            #if MODULAR
            if (this.AppInstanceArn == null && ParameterWasBound(nameof(this.AppInstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppInstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.InvokedBy_StandardMessage = this.InvokedBy_StandardMessage;
            context.InvokedBy_TargetedMessage = this.InvokedBy_TargetedMessage;
            context.Lex_LexBotAliasArn = this.Lex_LexBotAliasArn;
            #if MODULAR
            if (this.Lex_LexBotAliasArn == null && ParameterWasBound(nameof(this.Lex_LexBotAliasArn)))
            {
                WriteWarning("You are passing $null as a value for parameter Lex_LexBotAliasArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Lex_LocaleId = this.Lex_LocaleId;
            #if MODULAR
            if (this.Lex_LocaleId == null && ParameterWasBound(nameof(this.Lex_LocaleId)))
            {
                WriteWarning("You are passing $null as a value for parameter Lex_LocaleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Lex_RespondsTo = this.Lex_RespondsTo;
            context.Lex_WelcomeIntent = this.Lex_WelcomeIntent;
            context.Metadata = this.Metadata;
            context.Name = this.Name;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ChimeSDKIdentity.Model.Tag>(this.Tag);
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
            var request = new Amazon.ChimeSDKIdentity.Model.CreateAppInstanceBotRequest();
            
            if (cmdletContext.AppInstanceArn != null)
            {
                request.AppInstanceArn = cmdletContext.AppInstanceArn;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.ChimeSDKIdentity.Model.Configuration();
            Amazon.ChimeSDKIdentity.Model.LexConfiguration requestConfiguration_configuration_Lex = null;
            
             // populate Lex
            var requestConfiguration_configuration_LexIsNull = true;
            requestConfiguration_configuration_Lex = new Amazon.ChimeSDKIdentity.Model.LexConfiguration();
            System.String requestConfiguration_configuration_Lex_lex_LexBotAliasArn = null;
            if (cmdletContext.Lex_LexBotAliasArn != null)
            {
                requestConfiguration_configuration_Lex_lex_LexBotAliasArn = cmdletContext.Lex_LexBotAliasArn;
            }
            if (requestConfiguration_configuration_Lex_lex_LexBotAliasArn != null)
            {
                requestConfiguration_configuration_Lex.LexBotAliasArn = requestConfiguration_configuration_Lex_lex_LexBotAliasArn;
                requestConfiguration_configuration_LexIsNull = false;
            }
            System.String requestConfiguration_configuration_Lex_lex_LocaleId = null;
            if (cmdletContext.Lex_LocaleId != null)
            {
                requestConfiguration_configuration_Lex_lex_LocaleId = cmdletContext.Lex_LocaleId;
            }
            if (requestConfiguration_configuration_Lex_lex_LocaleId != null)
            {
                requestConfiguration_configuration_Lex.LocaleId = requestConfiguration_configuration_Lex_lex_LocaleId;
                requestConfiguration_configuration_LexIsNull = false;
            }
            Amazon.ChimeSDKIdentity.RespondsTo requestConfiguration_configuration_Lex_lex_RespondsTo = null;
            if (cmdletContext.Lex_RespondsTo != null)
            {
                requestConfiguration_configuration_Lex_lex_RespondsTo = cmdletContext.Lex_RespondsTo;
            }
            if (requestConfiguration_configuration_Lex_lex_RespondsTo != null)
            {
                requestConfiguration_configuration_Lex.RespondsTo = requestConfiguration_configuration_Lex_lex_RespondsTo;
                requestConfiguration_configuration_LexIsNull = false;
            }
            System.String requestConfiguration_configuration_Lex_lex_WelcomeIntent = null;
            if (cmdletContext.Lex_WelcomeIntent != null)
            {
                requestConfiguration_configuration_Lex_lex_WelcomeIntent = cmdletContext.Lex_WelcomeIntent;
            }
            if (requestConfiguration_configuration_Lex_lex_WelcomeIntent != null)
            {
                requestConfiguration_configuration_Lex.WelcomeIntent = requestConfiguration_configuration_Lex_lex_WelcomeIntent;
                requestConfiguration_configuration_LexIsNull = false;
            }
            Amazon.ChimeSDKIdentity.Model.InvokedBy requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy = null;
            
             // populate InvokedBy
            var requestConfiguration_configuration_Lex_configuration_Lex_InvokedByIsNull = true;
            requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy = new Amazon.ChimeSDKIdentity.Model.InvokedBy();
            Amazon.ChimeSDKIdentity.StandardMessages requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy_invokedBy_StandardMessage = null;
            if (cmdletContext.InvokedBy_StandardMessage != null)
            {
                requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy_invokedBy_StandardMessage = cmdletContext.InvokedBy_StandardMessage;
            }
            if (requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy_invokedBy_StandardMessage != null)
            {
                requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy.StandardMessages = requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy_invokedBy_StandardMessage;
                requestConfiguration_configuration_Lex_configuration_Lex_InvokedByIsNull = false;
            }
            Amazon.ChimeSDKIdentity.TargetedMessages requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy_invokedBy_TargetedMessage = null;
            if (cmdletContext.InvokedBy_TargetedMessage != null)
            {
                requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy_invokedBy_TargetedMessage = cmdletContext.InvokedBy_TargetedMessage;
            }
            if (requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy_invokedBy_TargetedMessage != null)
            {
                requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy.TargetedMessages = requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy_invokedBy_TargetedMessage;
                requestConfiguration_configuration_Lex_configuration_Lex_InvokedByIsNull = false;
            }
             // determine if requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy should be set to null
            if (requestConfiguration_configuration_Lex_configuration_Lex_InvokedByIsNull)
            {
                requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy = null;
            }
            if (requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy != null)
            {
                requestConfiguration_configuration_Lex.InvokedBy = requestConfiguration_configuration_Lex_configuration_Lex_InvokedBy;
                requestConfiguration_configuration_LexIsNull = false;
            }
             // determine if requestConfiguration_configuration_Lex should be set to null
            if (requestConfiguration_configuration_LexIsNull)
            {
                requestConfiguration_configuration_Lex = null;
            }
            if (requestConfiguration_configuration_Lex != null)
            {
                request.Configuration.Lex = requestConfiguration_configuration_Lex;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ChimeSDKIdentity.Model.CreateAppInstanceBotResponse CallAWSServiceOperation(IAmazonChimeSDKIdentity client, Amazon.ChimeSDKIdentity.Model.CreateAppInstanceBotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Identity", "CreateAppInstanceBot");
            try
            {
                #if DESKTOP
                return client.CreateAppInstanceBot(request);
                #elif CORECLR
                return client.CreateAppInstanceBotAsync(request).GetAwaiter().GetResult();
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
            public System.String AppInstanceArn { get; set; }
            public System.String ClientRequestToken { get; set; }
            public Amazon.ChimeSDKIdentity.StandardMessages InvokedBy_StandardMessage { get; set; }
            public Amazon.ChimeSDKIdentity.TargetedMessages InvokedBy_TargetedMessage { get; set; }
            public System.String Lex_LexBotAliasArn { get; set; }
            public System.String Lex_LocaleId { get; set; }
            public Amazon.ChimeSDKIdentity.RespondsTo Lex_RespondsTo { get; set; }
            public System.String Lex_WelcomeIntent { get; set; }
            public System.String Metadata { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.ChimeSDKIdentity.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ChimeSDKIdentity.Model.CreateAppInstanceBotResponse, NewCHMIDAppInstanceBotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AppInstanceBotArn;
        }
        
    }
}
