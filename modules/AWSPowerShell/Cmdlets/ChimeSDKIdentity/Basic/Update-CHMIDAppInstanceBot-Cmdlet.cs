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
using Amazon.ChimeSDKIdentity;
using Amazon.ChimeSDKIdentity.Model;

namespace Amazon.PowerShell.Cmdlets.CHMID
{
    /// <summary>
    /// Updates the name and metadata of an <c>AppInstanceBot</c>.
    /// </summary>
    [Cmdlet("Update", "CHMIDAppInstanceBot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Chime SDK Identity UpdateAppInstanceBot API operation.", Operation = new[] {"UpdateAppInstanceBot"}, SelectReturnType = typeof(Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceBotResponse))]
    [AWSCmdletOutput("System.String or Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceBotResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceBotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCHMIDAppInstanceBotCmdlet : AmazonChimeSDKIdentityClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppInstanceBotArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the <c>AppInstanceBot</c>.</para>
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
        public System.String AppInstanceBotArn { get; set; }
        #endregion
        
        #region Parameter Lex_LexBotAliasArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Lex V2 bot's alias. The ARN uses this format: <c>arn:aws:lex:REGION:ACCOUNT:bot-alias/MYBOTID/MYBOTALIAS</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Lex_LocaleId")]
        public System.String Lex_LocaleId { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>The metadata of the <c>AppInstanceBot</c>.</para>
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
        public System.String Metadata { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the <c>AppInstanceBot</c>.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceBotResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceBotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AppInstanceBotArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AppInstanceBotArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AppInstanceBotArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AppInstanceBotArn' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppInstanceBotArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHMIDAppInstanceBot (UpdateAppInstanceBot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceBotResponse, UpdateCHMIDAppInstanceBotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AppInstanceBotArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppInstanceBotArn = this.AppInstanceBotArn;
            #if MODULAR
            if (this.AppInstanceBotArn == null && ParameterWasBound(nameof(this.AppInstanceBotArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppInstanceBotArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InvokedBy_StandardMessage = this.InvokedBy_StandardMessage;
            context.InvokedBy_TargetedMessage = this.InvokedBy_TargetedMessage;
            context.Lex_LexBotAliasArn = this.Lex_LexBotAliasArn;
            context.Lex_LocaleId = this.Lex_LocaleId;
            context.Lex_RespondsTo = this.Lex_RespondsTo;
            context.Lex_WelcomeIntent = this.Lex_WelcomeIntent;
            context.Metadata = this.Metadata;
            #if MODULAR
            if (this.Metadata == null && ParameterWasBound(nameof(this.Metadata)))
            {
                WriteWarning("You are passing $null as a value for parameter Metadata which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceBotRequest();
            
            if (cmdletContext.AppInstanceBotArn != null)
            {
                request.AppInstanceBotArn = cmdletContext.AppInstanceBotArn;
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
        
        private Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceBotResponse CallAWSServiceOperation(IAmazonChimeSDKIdentity client, Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceBotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Identity", "UpdateAppInstanceBot");
            try
            {
                #if DESKTOP
                return client.UpdateAppInstanceBot(request);
                #elif CORECLR
                return client.UpdateAppInstanceBotAsync(request).GetAwaiter().GetResult();
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
            public System.String AppInstanceBotArn { get; set; }
            public Amazon.ChimeSDKIdentity.StandardMessages InvokedBy_StandardMessage { get; set; }
            public Amazon.ChimeSDKIdentity.TargetedMessages InvokedBy_TargetedMessage { get; set; }
            public System.String Lex_LexBotAliasArn { get; set; }
            public System.String Lex_LocaleId { get; set; }
            public Amazon.ChimeSDKIdentity.RespondsTo Lex_RespondsTo { get; set; }
            public System.String Lex_WelcomeIntent { get; set; }
            public System.String Metadata { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.ChimeSDKIdentity.Model.UpdateAppInstanceBotResponse, UpdateCHMIDAppInstanceBotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AppInstanceBotArn;
        }
        
    }
}
