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
    /// Returns a Microsoft Teams channel configuration in an AWS account.
    /// </summary>
    [Cmdlet("Get", "CHATMicrosoftTeamsChannelConfiguration")]
    [OutputType("Amazon.Chatbot.Model.TeamsChannelConfiguration")]
    [AWSCmdlet("Calls the AWS Chatbot GetMicrosoftTeamsChannelConfiguration API operation.", Operation = new[] {"GetMicrosoftTeamsChannelConfiguration"}, SelectReturnType = typeof(Amazon.Chatbot.Model.GetMicrosoftTeamsChannelConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Chatbot.Model.TeamsChannelConfiguration or Amazon.Chatbot.Model.GetMicrosoftTeamsChannelConfigurationResponse",
        "This cmdlet returns an Amazon.Chatbot.Model.TeamsChannelConfiguration object.",
        "The service call response (type Amazon.Chatbot.Model.GetMicrosoftTeamsChannelConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCHATMicrosoftTeamsChannelConfigurationCmdlet : AmazonChatbotClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChatConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the MicrosoftTeamsChannelConfiguration to retrieve.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChannelConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chatbot.Model.GetMicrosoftTeamsChannelConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Chatbot.Model.GetMicrosoftTeamsChannelConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChannelConfiguration";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chatbot.Model.GetMicrosoftTeamsChannelConfigurationResponse, GetCHATMicrosoftTeamsChannelConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChatConfigurationArn = this.ChatConfigurationArn;
            #if MODULAR
            if (this.ChatConfigurationArn == null && ParameterWasBound(nameof(this.ChatConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ChatConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Chatbot.Model.GetMicrosoftTeamsChannelConfigurationRequest();
            
            if (cmdletContext.ChatConfigurationArn != null)
            {
                request.ChatConfigurationArn = cmdletContext.ChatConfigurationArn;
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
        
        private Amazon.Chatbot.Model.GetMicrosoftTeamsChannelConfigurationResponse CallAWSServiceOperation(IAmazonChatbot client, Amazon.Chatbot.Model.GetMicrosoftTeamsChannelConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Chatbot", "GetMicrosoftTeamsChannelConfiguration");
            try
            {
                #if DESKTOP
                return client.GetMicrosoftTeamsChannelConfiguration(request);
                #elif CORECLR
                return client.GetMicrosoftTeamsChannelConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Chatbot.Model.GetMicrosoftTeamsChannelConfigurationResponse, GetCHATMicrosoftTeamsChannelConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChannelConfiguration;
        }
        
    }
}
