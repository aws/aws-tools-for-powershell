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
    /// Lists all Microsoft Teams user identities with a mapped role.
    /// </summary>
    [Cmdlet("Get", "CHATMicrosoftTeamsUserIdentityList")]
    [OutputType("Amazon.Chatbot.Model.TeamsUserIdentity")]
    [AWSCmdlet("Calls the AWS Chatbot ListMicrosoftTeamsUserIdentities API operation.", Operation = new[] {"ListMicrosoftTeamsUserIdentities"}, SelectReturnType = typeof(Amazon.Chatbot.Model.ListMicrosoftTeamsUserIdentitiesResponse))]
    [AWSCmdletOutput("Amazon.Chatbot.Model.TeamsUserIdentity or Amazon.Chatbot.Model.ListMicrosoftTeamsUserIdentitiesResponse",
        "This cmdlet returns a collection of Amazon.Chatbot.Model.TeamsUserIdentity objects.",
        "The service call response (type Amazon.Chatbot.Model.ListMicrosoftTeamsUserIdentitiesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCHATMicrosoftTeamsUserIdentityListCmdlet : AmazonChatbotClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChatConfigurationArn
        /// <summary>
        /// <para>
        /// The ARN of the MicrosoftTeamsChannelConfiguration
        /// associated with the user identities to list.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ChatConfigurationArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// The maximum number of results to include in
        /// the response. If more results exist than the specified MaxResults value, a token is
        /// included in the response so that the remaining results can be retrieved.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// An optional token returned from a prior request.
        /// Use this token for pagination of results from this action. If this parameter is specified,
        /// the response includes only results beyond the token, up to the value specified by
        /// MaxResults.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TeamsUserIdentities'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chatbot.Model.ListMicrosoftTeamsUserIdentitiesResponse).
        /// Specifying the name of a property of type Amazon.Chatbot.Model.ListMicrosoftTeamsUserIdentitiesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TeamsUserIdentities";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chatbot.Model.ListMicrosoftTeamsUserIdentitiesResponse, GetCHATMicrosoftTeamsUserIdentityListCmdlet>(Select) ??
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
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Chatbot.Model.ListMicrosoftTeamsUserIdentitiesRequest();
            
            if (cmdletContext.ChatConfigurationArn != null)
            {
                request.ChatConfigurationArn = cmdletContext.ChatConfigurationArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.Chatbot.Model.ListMicrosoftTeamsUserIdentitiesResponse CallAWSServiceOperation(IAmazonChatbot client, Amazon.Chatbot.Model.ListMicrosoftTeamsUserIdentitiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Chatbot", "ListMicrosoftTeamsUserIdentities");
            try
            {
                #if DESKTOP
                return client.ListMicrosoftTeamsUserIdentities(request);
                #elif CORECLR
                return client.ListMicrosoftTeamsUserIdentitiesAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Chatbot.Model.ListMicrosoftTeamsUserIdentitiesResponse, GetCHATMicrosoftTeamsUserIdentityListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TeamsUserIdentities;
        }
        
    }
}
