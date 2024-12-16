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
using Amazon.Chatbot;
using Amazon.Chatbot.Model;

namespace Amazon.PowerShell.Cmdlets.CHAT
{
    /// <summary>
    /// Creates an AWS Chatbot configuration for Microsoft Teams.
    /// </summary>
    [Cmdlet("New", "CHATMicrosoftTeamsChannelConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chatbot.Model.TeamsChannelConfiguration")]
    [AWSCmdlet("Calls the AWS Chatbot CreateMicrosoftTeamsChannelConfiguration API operation.", Operation = new[] {"CreateMicrosoftTeamsChannelConfiguration"}, SelectReturnType = typeof(Amazon.Chatbot.Model.CreateMicrosoftTeamsChannelConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Chatbot.Model.TeamsChannelConfiguration or Amazon.Chatbot.Model.CreateMicrosoftTeamsChannelConfigurationResponse",
        "This cmdlet returns an Amazon.Chatbot.Model.TeamsChannelConfiguration object.",
        "The service call response (type Amazon.Chatbot.Model.CreateMicrosoftTeamsChannelConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCHATMicrosoftTeamsChannelConfigurationCmdlet : AmazonChatbotClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChannelId
        /// <summary>
        /// <para>
        /// <para>The ID of the Microsoft Teams channel.</para>
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
        public System.String ChannelId { get; set; }
        #endregion
        
        #region Parameter ChannelName
        /// <summary>
        /// <para>
        /// <para>The name of the Microsoft Teams channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelName { get; set; }
        #endregion
        
        #region Parameter ConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration.</para>
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
        public System.String ConfigurationName { get; set; }
        #endregion
        
        #region Parameter GuardrailPolicyArn
        /// <summary>
        /// <para>
        /// <para>The list of IAM policy ARNs that are applied as channel guardrails. The AWS managed
        /// <c>AdministratorAccess</c> policy is applied by default if this is not set. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GuardrailPolicyArns")]
        public System.String[] GuardrailPolicyArn { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>A user-defined role that AWS Chatbot assumes. This is not the service-linked role.</para><para>For more information, see <a href="https://docs.aws.amazon.com/chatbot/latest/adminguide/chatbot-iam-policies.html">IAM
        /// policies for AWS Chatbot</a> in the <i> AWS Chatbot Administrator Guide</i>. </para>
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
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter LoggingLevel
        /// <summary>
        /// <para>
        /// <para>Logging levels include <c>ERROR</c>, <c>INFO</c>, or <c>NONE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingLevel { get; set; }
        #endregion
        
        #region Parameter SnsTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the SNS topics that deliver notifications to AWS
        /// Chatbot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnsTopicArns")]
        public System.String[] SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of tags assigned to a resource. A tag is a string-to-string map of key-value
        /// pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Chatbot.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TeamId
        /// <summary>
        /// <para>
        /// <para> The ID of the Microsoft Teams authorized with AWS Chatbot.</para><para>To get the team ID, you must perform the initial authorization flow with Microsoft
        /// Teams in the AWS Chatbot console. Then you can copy and paste the team ID from the
        /// console. For more information, see <a href="https://docs.aws.amazon.com/chatbot/latest/adminguide/teams-setup.html#teams-client-setup">Step
        /// 1: Configure a Microsoft Teams client</a> in the <i> AWS Chatbot Administrator Guide</i>.
        /// </para>
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
        public System.String TeamId { get; set; }
        #endregion
        
        #region Parameter TeamName
        /// <summary>
        /// <para>
        /// <para>The name of the Microsoft Teams Team.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TeamName { get; set; }
        #endregion
        
        #region Parameter TenantId
        /// <summary>
        /// <para>
        /// <para>The ID of the Microsoft Teams tenant.</para>
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
        public System.String TenantId { get; set; }
        #endregion
        
        #region Parameter UserAuthorizationRequired
        /// <summary>
        /// <para>
        /// <para>Enables use of a user role requirement in your chat configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UserAuthorizationRequired { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChannelConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chatbot.Model.CreateMicrosoftTeamsChannelConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Chatbot.Model.CreateMicrosoftTeamsChannelConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChannelConfiguration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHATMicrosoftTeamsChannelConfiguration (CreateMicrosoftTeamsChannelConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chatbot.Model.CreateMicrosoftTeamsChannelConfigurationResponse, NewCHATMicrosoftTeamsChannelConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelId = this.ChannelId;
            #if MODULAR
            if (this.ChannelId == null && ParameterWasBound(nameof(this.ChannelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelName = this.ChannelName;
            context.ConfigurationName = this.ConfigurationName;
            #if MODULAR
            if (this.ConfigurationName == null && ParameterWasBound(nameof(this.ConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.GuardrailPolicyArn != null)
            {
                context.GuardrailPolicyArn = new List<System.String>(this.GuardrailPolicyArn);
            }
            context.IamRoleArn = this.IamRoleArn;
            #if MODULAR
            if (this.IamRoleArn == null && ParameterWasBound(nameof(this.IamRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IamRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoggingLevel = this.LoggingLevel;
            if (this.SnsTopicArn != null)
            {
                context.SnsTopicArn = new List<System.String>(this.SnsTopicArn);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Chatbot.Model.Tag>(this.Tag);
            }
            context.TeamId = this.TeamId;
            #if MODULAR
            if (this.TeamId == null && ParameterWasBound(nameof(this.TeamId)))
            {
                WriteWarning("You are passing $null as a value for parameter TeamId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TeamName = this.TeamName;
            context.TenantId = this.TenantId;
            #if MODULAR
            if (this.TenantId == null && ParameterWasBound(nameof(this.TenantId)))
            {
                WriteWarning("You are passing $null as a value for parameter TenantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserAuthorizationRequired = this.UserAuthorizationRequired;
            
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
            var request = new Amazon.Chatbot.Model.CreateMicrosoftTeamsChannelConfigurationRequest();
            
            if (cmdletContext.ChannelId != null)
            {
                request.ChannelId = cmdletContext.ChannelId;
            }
            if (cmdletContext.ChannelName != null)
            {
                request.ChannelName = cmdletContext.ChannelName;
            }
            if (cmdletContext.ConfigurationName != null)
            {
                request.ConfigurationName = cmdletContext.ConfigurationName;
            }
            if (cmdletContext.GuardrailPolicyArn != null)
            {
                request.GuardrailPolicyArns = cmdletContext.GuardrailPolicyArn;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.LoggingLevel != null)
            {
                request.LoggingLevel = cmdletContext.LoggingLevel;
            }
            if (cmdletContext.SnsTopicArn != null)
            {
                request.SnsTopicArns = cmdletContext.SnsTopicArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TeamId != null)
            {
                request.TeamId = cmdletContext.TeamId;
            }
            if (cmdletContext.TeamName != null)
            {
                request.TeamName = cmdletContext.TeamName;
            }
            if (cmdletContext.TenantId != null)
            {
                request.TenantId = cmdletContext.TenantId;
            }
            if (cmdletContext.UserAuthorizationRequired != null)
            {
                request.UserAuthorizationRequired = cmdletContext.UserAuthorizationRequired.Value;
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
        
        private Amazon.Chatbot.Model.CreateMicrosoftTeamsChannelConfigurationResponse CallAWSServiceOperation(IAmazonChatbot client, Amazon.Chatbot.Model.CreateMicrosoftTeamsChannelConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Chatbot", "CreateMicrosoftTeamsChannelConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateMicrosoftTeamsChannelConfiguration(request);
                #elif CORECLR
                return client.CreateMicrosoftTeamsChannelConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ChannelId { get; set; }
            public System.String ChannelName { get; set; }
            public System.String ConfigurationName { get; set; }
            public List<System.String> GuardrailPolicyArn { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String LoggingLevel { get; set; }
            public List<System.String> SnsTopicArn { get; set; }
            public List<Amazon.Chatbot.Model.Tag> Tag { get; set; }
            public System.String TeamId { get; set; }
            public System.String TeamName { get; set; }
            public System.String TenantId { get; set; }
            public System.Boolean? UserAuthorizationRequired { get; set; }
            public System.Func<Amazon.Chatbot.Model.CreateMicrosoftTeamsChannelConfigurationResponse, NewCHATMicrosoftTeamsChannelConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChannelConfiguration;
        }
        
    }
}
