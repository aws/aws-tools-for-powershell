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
    /// Updates a Amazon Chime webhook configuration.
    /// </summary>
    [Cmdlet("Update", "CHATChimeWebhookConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chatbot.Model.ChimeWebhookConfiguration")]
    [AWSCmdlet("Calls the AWS Chatbot UpdateChimeWebhookConfiguration API operation.", Operation = new[] {"UpdateChimeWebhookConfiguration"}, SelectReturnType = typeof(Amazon.Chatbot.Model.UpdateChimeWebhookConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Chatbot.Model.ChimeWebhookConfiguration or Amazon.Chatbot.Model.UpdateChimeWebhookConfigurationResponse",
        "This cmdlet returns an Amazon.Chatbot.Model.ChimeWebhookConfiguration object.",
        "The service call response (type Amazon.Chatbot.Model.UpdateChimeWebhookConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCHATChimeWebhookConfigurationCmdlet : AmazonChatbotClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChatConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the ChimeWebhookConfiguration to update.</para>
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
        public System.String ChatConfigurationArn { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>A user-defined role that AWS Chatbot assumes. This is not the service-linked role.</para><para>For more information, see <a href="https://docs.aws.amazon.com/chatbot/latest/adminguide/chatbot-iam-policies.html">IAM
        /// policies for AWS Chatbot</a> in the <i> AWS Chatbot Administrator Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// <para>The ARNs of the SNS topics that deliver notifications to AWS Chatbot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnsTopicArns")]
        public System.String[] SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter WebhookDescription
        /// <summary>
        /// <para>
        /// <para>A description of the webhook. We recommend using the convention <c>RoomName/WebhookName</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/chatbot/latest/adminguide/chime-setup.html">Tutorial:
        /// Get started with Amazon Chime</a> in the <i> AWS Chatbot Administrator Guide</i>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WebhookDescription { get; set; }
        #endregion
        
        #region Parameter WebhookUrl
        /// <summary>
        /// <para>
        /// <para>The URL for the Amazon Chime webhook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WebhookUrl { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WebhookConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chatbot.Model.UpdateChimeWebhookConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Chatbot.Model.UpdateChimeWebhookConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WebhookConfiguration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChatConfigurationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHATChimeWebhookConfiguration (UpdateChimeWebhookConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chatbot.Model.UpdateChimeWebhookConfigurationResponse, UpdateCHATChimeWebhookConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChatConfigurationArn = this.ChatConfigurationArn;
            #if MODULAR
            if (this.ChatConfigurationArn == null && ParameterWasBound(nameof(this.ChatConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ChatConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IamRoleArn = this.IamRoleArn;
            context.LoggingLevel = this.LoggingLevel;
            if (this.SnsTopicArn != null)
            {
                context.SnsTopicArn = new List<System.String>(this.SnsTopicArn);
            }
            context.WebhookDescription = this.WebhookDescription;
            context.WebhookUrl = this.WebhookUrl;
            
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
            var request = new Amazon.Chatbot.Model.UpdateChimeWebhookConfigurationRequest();
            
            if (cmdletContext.ChatConfigurationArn != null)
            {
                request.ChatConfigurationArn = cmdletContext.ChatConfigurationArn;
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
            if (cmdletContext.WebhookDescription != null)
            {
                request.WebhookDescription = cmdletContext.WebhookDescription;
            }
            if (cmdletContext.WebhookUrl != null)
            {
                request.WebhookUrl = cmdletContext.WebhookUrl;
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
        
        private Amazon.Chatbot.Model.UpdateChimeWebhookConfigurationResponse CallAWSServiceOperation(IAmazonChatbot client, Amazon.Chatbot.Model.UpdateChimeWebhookConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Chatbot", "UpdateChimeWebhookConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateChimeWebhookConfiguration(request);
                #elif CORECLR
                return client.UpdateChimeWebhookConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ChatConfigurationArn { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String LoggingLevel { get; set; }
            public List<System.String> SnsTopicArn { get; set; }
            public System.String WebhookDescription { get; set; }
            public System.String WebhookUrl { get; set; }
            public System.Func<Amazon.Chatbot.Model.UpdateChimeWebhookConfigurationResponse, UpdateCHATChimeWebhookConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WebhookConfiguration;
        }
        
    }
}
