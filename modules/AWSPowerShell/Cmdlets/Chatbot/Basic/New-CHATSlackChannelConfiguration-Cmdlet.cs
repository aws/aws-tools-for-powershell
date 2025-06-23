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
using System.Threading;
using Amazon.Chatbot;
using Amazon.Chatbot.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CHAT
{
    /// <summary>
    /// Creates an AWS Chatbot confugration for Slack.
    /// </summary>
    [Cmdlet("New", "CHATSlackChannelConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chatbot.Model.SlackChannelConfiguration")]
    [AWSCmdlet("Calls the AWS Chatbot CreateSlackChannelConfiguration API operation.", Operation = new[] {"CreateSlackChannelConfiguration"}, SelectReturnType = typeof(Amazon.Chatbot.Model.CreateSlackChannelConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Chatbot.Model.SlackChannelConfiguration or Amazon.Chatbot.Model.CreateSlackChannelConfigurationResponse",
        "This cmdlet returns an Amazon.Chatbot.Model.SlackChannelConfiguration object.",
        "The service call response (type Amazon.Chatbot.Model.CreateSlackChannelConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCHATSlackChannelConfigurationCmdlet : AmazonChatbotClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// <c>AdministratorAccess</c> policy is applied by default if this is not set. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        
        #region Parameter SlackChannelId
        /// <summary>
        /// <para>
        /// <para>The ID of the Slack channel.</para><para>To get this ID, open Slack, right click on the channel name in the left pane, then
        /// choose Copy Link. The channel ID is the 9-character string at the end of the URL.
        /// For example, ABCBBLZZZ. </para>
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
        public System.String SlackChannelId { get; set; }
        #endregion
        
        #region Parameter SlackChannelName
        /// <summary>
        /// <para>
        /// <para>The name of the Slack channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SlackChannelName { get; set; }
        #endregion
        
        #region Parameter SlackTeamId
        /// <summary>
        /// <para>
        /// <para>The ID of the Slack workspace authorized with AWS Chatbot.</para>
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
        public System.String SlackTeamId { get; set; }
        #endregion
        
        #region Parameter SnsTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the SNS topics that deliver notifications to AWS
        /// Chatbot.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// pairs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Chatbot.Model.Tag[] Tag { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chatbot.Model.CreateSlackChannelConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Chatbot.Model.CreateSlackChannelConfigurationResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHATSlackChannelConfiguration (CreateSlackChannelConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chatbot.Model.CreateSlackChannelConfigurationResponse, NewCHATSlackChannelConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.SlackChannelId = this.SlackChannelId;
            #if MODULAR
            if (this.SlackChannelId == null && ParameterWasBound(nameof(this.SlackChannelId)))
            {
                WriteWarning("You are passing $null as a value for parameter SlackChannelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SlackChannelName = this.SlackChannelName;
            context.SlackTeamId = this.SlackTeamId;
            #if MODULAR
            if (this.SlackTeamId == null && ParameterWasBound(nameof(this.SlackTeamId)))
            {
                WriteWarning("You are passing $null as a value for parameter SlackTeamId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SnsTopicArn != null)
            {
                context.SnsTopicArn = new List<System.String>(this.SnsTopicArn);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Chatbot.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.Chatbot.Model.CreateSlackChannelConfigurationRequest();
            
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
            if (cmdletContext.SlackChannelId != null)
            {
                request.SlackChannelId = cmdletContext.SlackChannelId;
            }
            if (cmdletContext.SlackChannelName != null)
            {
                request.SlackChannelName = cmdletContext.SlackChannelName;
            }
            if (cmdletContext.SlackTeamId != null)
            {
                request.SlackTeamId = cmdletContext.SlackTeamId;
            }
            if (cmdletContext.SnsTopicArn != null)
            {
                request.SnsTopicArns = cmdletContext.SnsTopicArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Chatbot.Model.CreateSlackChannelConfigurationResponse CallAWSServiceOperation(IAmazonChatbot client, Amazon.Chatbot.Model.CreateSlackChannelConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Chatbot", "CreateSlackChannelConfiguration");
            try
            {
                return client.CreateSlackChannelConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfigurationName { get; set; }
            public List<System.String> GuardrailPolicyArn { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String LoggingLevel { get; set; }
            public System.String SlackChannelId { get; set; }
            public System.String SlackChannelName { get; set; }
            public System.String SlackTeamId { get; set; }
            public List<System.String> SnsTopicArn { get; set; }
            public List<Amazon.Chatbot.Model.Tag> Tag { get; set; }
            public System.Boolean? UserAuthorizationRequired { get; set; }
            public System.Func<Amazon.Chatbot.Model.CreateSlackChannelConfigurationResponse, NewCHATSlackChannelConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChannelConfiguration;
        }
        
    }
}
