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
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// Updates the configuration of an existing bot.
    /// </summary>
    [Cmdlet("Update", "LMBV2Bot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelsV2.Model.UpdateBotResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 UpdateBot API operation.", Operation = new[] {"UpdateBot"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.UpdateBotResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.UpdateBotResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.UpdateBotResponse object containing multiple properties."
    )]
    public partial class UpdateLMBV2BotCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the bot to update. This identifier is returned by the <a href="https://docs.aws.amazon.com/lexv2/latest/APIReference/API_CreateBot.html">CreateBot</a>
        /// operation.</para>
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
        public System.String BotId { get; set; }
        #endregion
        
        #region Parameter BotMember
        /// <summary>
        /// <para>
        /// <para>The list of bot members in the network associated with the update action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BotMembers")]
        public Amazon.LexModelsV2.Model.BotMember[] BotMember { get; set; }
        #endregion
        
        #region Parameter BotName
        /// <summary>
        /// <para>
        /// <para>The new name of the bot. The name must be unique in the account that creates the bot.</para>
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
        public System.String BotName { get; set; }
        #endregion
        
        #region Parameter BotType
        /// <summary>
        /// <para>
        /// <para>The type of the bot to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.BotType")]
        public Amazon.LexModelsV2.BotType BotType { get; set; }
        #endregion
        
        #region Parameter DataPrivacy_ChildDirected
        /// <summary>
        /// <para>
        /// <para>For each Amazon Lex bot created with the Amazon Lex Model Building Service, you must
        /// specify whether your use of Amazon Lex is related to a website, program, or other
        /// application that is directed or targeted, in whole or in part, to children under age
        /// 13 and subject to the Children's Online Privacy Protection Act (COPPA) by specifying
        /// <c>true</c> or <c>false</c> in the <c>childDirected</c> field. By specifying <c>true</c>
        /// in the <c>childDirected</c> field, you confirm that your use of Amazon Lex <b>is</b>
        /// related to a website, program, or other application that is directed or targeted,
        /// in whole or in part, to children under age 13 and subject to COPPA. By specifying
        /// <c>false</c> in the <c>childDirected</c> field, you confirm that your use of Amazon
        /// Lex <b>is not</b> related to a website, program, or other application that is directed
        /// or targeted, in whole or in part, to children under age 13 and subject to COPPA. You
        /// may not specify a default value for the <c>childDirected</c> field that does not accurately
        /// reflect whether your use of Amazon Lex is related to a website, program, or other
        /// application that is directed or targeted, in whole or in part, to children under age
        /// 13 and subject to COPPA. If your use of Amazon Lex relates to a website, program,
        /// or other application that is directed in whole or in part, to children under age 13,
        /// you must obtain any required verifiable parental consent under COPPA. For information
        /// regarding the use of Amazon Lex in connection with websites, programs, or other applications
        /// that are directed or targeted, in whole or in part, to children under age 13, see
        /// the <a href="http://aws.amazon.com/lex/faqs#data-security">Amazon Lex FAQ</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? DataPrivacy_ChildDirected { get; set; }
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
        
        #region Parameter ErrorLogSettings_Enabled
        /// <summary>
        /// <para>
        /// <para>Settings parameters for the error logs, when it is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ErrorLogSettings_Enabled { get; set; }
        #endregion
        
        #region Parameter IdleSessionTTLInSecond
        /// <summary>
        /// <para>
        /// <para>The time, in seconds, that Amazon Lex should keep information about a user's conversation
        /// with the bot.</para><para>A user interaction remains active for the amount of time specified. If no conversation
        /// occurs during this time, the session expires and Amazon Lex deletes any data provided
        /// before the timeout.</para><para>You can specify between 60 (1 minute) and 86,400 (24 hours) seconds.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("IdleSessionTTLInSeconds")]
        public System.Int32? IdleSessionTTLInSecond { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that has permissions to access the bot.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.UpdateBotResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.UpdateBotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BotId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BotId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BotId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BotId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMBV2Bot (UpdateBot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.UpdateBotResponse, UpdateLMBV2BotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BotId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BotId = this.BotId;
            #if MODULAR
            if (this.BotId == null && ParameterWasBound(nameof(this.BotId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.BotMember != null)
            {
                context.BotMember = new List<Amazon.LexModelsV2.Model.BotMember>(this.BotMember);
            }
            context.BotName = this.BotName;
            #if MODULAR
            if (this.BotName == null && ParameterWasBound(nameof(this.BotName)))
            {
                WriteWarning("You are passing $null as a value for parameter BotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotType = this.BotType;
            context.DataPrivacy_ChildDirected = this.DataPrivacy_ChildDirected;
            #if MODULAR
            if (this.DataPrivacy_ChildDirected == null && ParameterWasBound(nameof(this.DataPrivacy_ChildDirected)))
            {
                WriteWarning("You are passing $null as a value for parameter DataPrivacy_ChildDirected which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.ErrorLogSettings_Enabled = this.ErrorLogSettings_Enabled;
            context.IdleSessionTTLInSecond = this.IdleSessionTTLInSecond;
            #if MODULAR
            if (this.IdleSessionTTLInSecond == null && ParameterWasBound(nameof(this.IdleSessionTTLInSecond)))
            {
                WriteWarning("You are passing $null as a value for parameter IdleSessionTTLInSecond which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LexModelsV2.Model.UpdateBotRequest();
            
            if (cmdletContext.BotId != null)
            {
                request.BotId = cmdletContext.BotId;
            }
            if (cmdletContext.BotMember != null)
            {
                request.BotMembers = cmdletContext.BotMember;
            }
            if (cmdletContext.BotName != null)
            {
                request.BotName = cmdletContext.BotName;
            }
            if (cmdletContext.BotType != null)
            {
                request.BotType = cmdletContext.BotType;
            }
            
             // populate DataPrivacy
            var requestDataPrivacyIsNull = true;
            request.DataPrivacy = new Amazon.LexModelsV2.Model.DataPrivacy();
            System.Boolean? requestDataPrivacy_dataPrivacy_ChildDirected = null;
            if (cmdletContext.DataPrivacy_ChildDirected != null)
            {
                requestDataPrivacy_dataPrivacy_ChildDirected = cmdletContext.DataPrivacy_ChildDirected.Value;
            }
            if (requestDataPrivacy_dataPrivacy_ChildDirected != null)
            {
                request.DataPrivacy.ChildDirected = requestDataPrivacy_dataPrivacy_ChildDirected.Value;
                requestDataPrivacyIsNull = false;
            }
             // determine if request.DataPrivacy should be set to null
            if (requestDataPrivacyIsNull)
            {
                request.DataPrivacy = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate ErrorLogSettings
            var requestErrorLogSettingsIsNull = true;
            request.ErrorLogSettings = new Amazon.LexModelsV2.Model.ErrorLogSettings();
            System.Boolean? requestErrorLogSettings_errorLogSettings_Enabled = null;
            if (cmdletContext.ErrorLogSettings_Enabled != null)
            {
                requestErrorLogSettings_errorLogSettings_Enabled = cmdletContext.ErrorLogSettings_Enabled.Value;
            }
            if (requestErrorLogSettings_errorLogSettings_Enabled != null)
            {
                request.ErrorLogSettings.Enabled = requestErrorLogSettings_errorLogSettings_Enabled.Value;
                requestErrorLogSettingsIsNull = false;
            }
             // determine if request.ErrorLogSettings should be set to null
            if (requestErrorLogSettingsIsNull)
            {
                request.ErrorLogSettings = null;
            }
            if (cmdletContext.IdleSessionTTLInSecond != null)
            {
                request.IdleSessionTTLInSeconds = cmdletContext.IdleSessionTTLInSecond.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.LexModelsV2.Model.UpdateBotResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.UpdateBotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "UpdateBot");
            try
            {
                #if DESKTOP
                return client.UpdateBot(request);
                #elif CORECLR
                return client.UpdateBotAsync(request).GetAwaiter().GetResult();
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
            public System.String BotId { get; set; }
            public List<Amazon.LexModelsV2.Model.BotMember> BotMember { get; set; }
            public System.String BotName { get; set; }
            public Amazon.LexModelsV2.BotType BotType { get; set; }
            public System.Boolean? DataPrivacy_ChildDirected { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? ErrorLogSettings_Enabled { get; set; }
            public System.Int32? IdleSessionTTLInSecond { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.UpdateBotResponse, UpdateLMBV2BotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
