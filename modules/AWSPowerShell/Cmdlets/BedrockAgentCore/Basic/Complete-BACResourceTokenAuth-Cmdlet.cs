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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Confirms the user authentication session for obtaining OAuth2.0 tokens for a resource.
    /// </summary>
    [Cmdlet("Complete", "BACResourceTokenAuth", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer CompleteResourceTokenAuth API operation.", Operation = new[] {"CompleteResourceTokenAuth"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.CompleteResourceTokenAuthResponse))]
    [AWSCmdletOutput("None or Amazon.BedrockAgentCore.Model.CompleteResourceTokenAuthResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.BedrockAgentCore.Model.CompleteResourceTokenAuthResponse) be returned by specifying '-Select *'."
    )]
    public partial class CompleteBACResourceTokenAuthCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SessionUri
        /// <summary>
        /// <para>
        /// <para>Unique identifier for the user's authentication session for retrieving OAuth2 tokens.
        /// This ID tracks the authorization flow state across multiple requests and responses
        /// during the OAuth2 authentication process.</para>
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
        public System.String SessionUri { get; set; }
        #endregion
        
        #region Parameter UserIdentifier_UserId
        /// <summary>
        /// <para>
        /// <para>The ID of the user for whom you have retrieved a workload access token for</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserIdentifier_UserId { get; set; }
        #endregion
        
        #region Parameter UserIdentifier_UserToken
        /// <summary>
        /// <para>
        /// <para>The OAuth2.0 token issued by the user’s identity provider</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserIdentifier_UserToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.CompleteResourceTokenAuthResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SessionUri parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SessionUri' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SessionUri' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SessionUri), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Complete-BACResourceTokenAuth (CompleteResourceTokenAuth)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.CompleteResourceTokenAuthResponse, CompleteBACResourceTokenAuthCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SessionUri;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SessionUri = this.SessionUri;
            #if MODULAR
            if (this.SessionUri == null && ParameterWasBound(nameof(this.SessionUri)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserIdentifier_UserId = this.UserIdentifier_UserId;
            context.UserIdentifier_UserToken = this.UserIdentifier_UserToken;
            
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
            var request = new Amazon.BedrockAgentCore.Model.CompleteResourceTokenAuthRequest();
            
            if (cmdletContext.SessionUri != null)
            {
                request.SessionUri = cmdletContext.SessionUri;
            }
            
             // populate UserIdentifier
            var requestUserIdentifierIsNull = true;
            request.UserIdentifier = new Amazon.BedrockAgentCore.Model.UserIdentifier();
            System.String requestUserIdentifier_userIdentifier_UserId = null;
            if (cmdletContext.UserIdentifier_UserId != null)
            {
                requestUserIdentifier_userIdentifier_UserId = cmdletContext.UserIdentifier_UserId;
            }
            if (requestUserIdentifier_userIdentifier_UserId != null)
            {
                request.UserIdentifier.UserId = requestUserIdentifier_userIdentifier_UserId;
                requestUserIdentifierIsNull = false;
            }
            System.String requestUserIdentifier_userIdentifier_UserToken = null;
            if (cmdletContext.UserIdentifier_UserToken != null)
            {
                requestUserIdentifier_userIdentifier_UserToken = cmdletContext.UserIdentifier_UserToken;
            }
            if (requestUserIdentifier_userIdentifier_UserToken != null)
            {
                request.UserIdentifier.UserToken = requestUserIdentifier_userIdentifier_UserToken;
                requestUserIdentifierIsNull = false;
            }
             // determine if request.UserIdentifier should be set to null
            if (requestUserIdentifierIsNull)
            {
                request.UserIdentifier = null;
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
        
        private Amazon.BedrockAgentCore.Model.CompleteResourceTokenAuthResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.CompleteResourceTokenAuthRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "CompleteResourceTokenAuth");
            try
            {
                #if DESKTOP
                return client.CompleteResourceTokenAuth(request);
                #elif CORECLR
                return client.CompleteResourceTokenAuthAsync(request).GetAwaiter().GetResult();
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
            public System.String SessionUri { get; set; }
            public System.String UserIdentifier_UserId { get; set; }
            public System.String UserIdentifier_UserToken { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.CompleteResourceTokenAuthResponse, CompleteBACResourceTokenAuthCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
