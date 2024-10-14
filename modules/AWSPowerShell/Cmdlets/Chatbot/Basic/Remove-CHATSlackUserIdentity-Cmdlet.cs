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
    /// Deletes a user level permission for a Slack channel configuration.
    /// </summary>
    [Cmdlet("Remove", "CHATSlackUserIdentity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Chatbot DeleteSlackUserIdentity API operation.", Operation = new[] {"DeleteSlackUserIdentity"}, SelectReturnType = typeof(Amazon.Chatbot.Model.DeleteSlackUserIdentityResponse))]
    [AWSCmdletOutput("None or Amazon.Chatbot.Model.DeleteSlackUserIdentityResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Chatbot.Model.DeleteSlackUserIdentityResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveCHATSlackUserIdentityCmdlet : AmazonChatbotClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChatConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SlackChannelConfiguration associated with the user identity to delete.</para>
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
        
        #region Parameter SlackUserId
        /// <summary>
        /// <para>
        /// <para>The ID of the user in Slack</para>
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
        public System.String SlackUserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chatbot.Model.DeleteSlackUserIdentityResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ChatConfigurationArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ChatConfigurationArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ChatConfigurationArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChatConfigurationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CHATSlackUserIdentity (DeleteSlackUserIdentity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chatbot.Model.DeleteSlackUserIdentityResponse, RemoveCHATSlackUserIdentityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ChatConfigurationArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChatConfigurationArn = this.ChatConfigurationArn;
            #if MODULAR
            if (this.ChatConfigurationArn == null && ParameterWasBound(nameof(this.ChatConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ChatConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SlackTeamId = this.SlackTeamId;
            #if MODULAR
            if (this.SlackTeamId == null && ParameterWasBound(nameof(this.SlackTeamId)))
            {
                WriteWarning("You are passing $null as a value for parameter SlackTeamId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SlackUserId = this.SlackUserId;
            #if MODULAR
            if (this.SlackUserId == null && ParameterWasBound(nameof(this.SlackUserId)))
            {
                WriteWarning("You are passing $null as a value for parameter SlackUserId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Chatbot.Model.DeleteSlackUserIdentityRequest();
            
            if (cmdletContext.ChatConfigurationArn != null)
            {
                request.ChatConfigurationArn = cmdletContext.ChatConfigurationArn;
            }
            if (cmdletContext.SlackTeamId != null)
            {
                request.SlackTeamId = cmdletContext.SlackTeamId;
            }
            if (cmdletContext.SlackUserId != null)
            {
                request.SlackUserId = cmdletContext.SlackUserId;
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
        
        private Amazon.Chatbot.Model.DeleteSlackUserIdentityResponse CallAWSServiceOperation(IAmazonChatbot client, Amazon.Chatbot.Model.DeleteSlackUserIdentityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Chatbot", "DeleteSlackUserIdentity");
            try
            {
                #if DESKTOP
                return client.DeleteSlackUserIdentity(request);
                #elif CORECLR
                return client.DeleteSlackUserIdentityAsync(request).GetAwaiter().GetResult();
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
            public System.String SlackTeamId { get; set; }
            public System.String SlackUserId { get; set; }
            public System.Func<Amazon.Chatbot.Model.DeleteSlackUserIdentityResponse, RemoveCHATSlackUserIdentityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
