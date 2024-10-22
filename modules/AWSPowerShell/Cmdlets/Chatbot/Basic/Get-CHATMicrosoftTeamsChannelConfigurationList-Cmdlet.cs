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
    /// Lists all AWS Chatbot Microsoft Teams channel configurations in an AWS account.
    /// </summary>
    [Cmdlet("Get", "CHATMicrosoftTeamsChannelConfigurationList")]
    [OutputType("Amazon.Chatbot.Model.TeamsChannelConfiguration")]
    [AWSCmdlet("Calls the AWS Chatbot ListMicrosoftTeamsChannelConfigurations API operation.", Operation = new[] {"ListMicrosoftTeamsChannelConfigurations"}, SelectReturnType = typeof(Amazon.Chatbot.Model.ListMicrosoftTeamsChannelConfigurationsResponse))]
    [AWSCmdletOutput("Amazon.Chatbot.Model.TeamsChannelConfiguration or Amazon.Chatbot.Model.ListMicrosoftTeamsChannelConfigurationsResponse",
        "This cmdlet returns a collection of Amazon.Chatbot.Model.TeamsChannelConfiguration objects.",
        "The service call response (type Amazon.Chatbot.Model.ListMicrosoftTeamsChannelConfigurationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCHATMicrosoftTeamsChannelConfigurationListCmdlet : AmazonChatbotClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TeamId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to include in the response. If more results exist than
        /// the specified MaxResults value, a token is included in the response so that the remaining
        /// results can be retrieved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An optional token returned from a prior request. Use this token for pagination of
        /// results from this action. If this parameter is specified, the response includes only
        /// results beyond the token, up to the value specified by MaxResults.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TeamChannelConfigurations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chatbot.Model.ListMicrosoftTeamsChannelConfigurationsResponse).
        /// Specifying the name of a property of type Amazon.Chatbot.Model.ListMicrosoftTeamsChannelConfigurationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TeamChannelConfigurations";
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
                context.Select = CreateSelectDelegate<Amazon.Chatbot.Model.ListMicrosoftTeamsChannelConfigurationsResponse, GetCHATMicrosoftTeamsChannelConfigurationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.TeamId = this.TeamId;
            
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
            var request = new Amazon.Chatbot.Model.ListMicrosoftTeamsChannelConfigurationsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.TeamId != null)
            {
                request.TeamId = cmdletContext.TeamId;
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
        
        private Amazon.Chatbot.Model.ListMicrosoftTeamsChannelConfigurationsResponse CallAWSServiceOperation(IAmazonChatbot client, Amazon.Chatbot.Model.ListMicrosoftTeamsChannelConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Chatbot", "ListMicrosoftTeamsChannelConfigurations");
            try
            {
                #if DESKTOP
                return client.ListMicrosoftTeamsChannelConfigurations(request);
                #elif CORECLR
                return client.ListMicrosoftTeamsChannelConfigurationsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String TeamId { get; set; }
            public System.Func<Amazon.Chatbot.Model.ListMicrosoftTeamsChannelConfigurationsResponse, GetCHATMicrosoftTeamsChannelConfigurationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TeamChannelConfigurations;
        }
        
    }
}
