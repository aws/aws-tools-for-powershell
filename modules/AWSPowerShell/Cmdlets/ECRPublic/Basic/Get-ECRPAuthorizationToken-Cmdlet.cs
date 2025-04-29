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
using Amazon.ECRPublic;
using Amazon.ECRPublic.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ECRP
{
    /// <summary>
    /// Retrieves an authorization token. An authorization token represents your IAM authentication
    /// credentials. You can use it to access any Amazon ECR registry that your IAM principal
    /// has access to. The authorization token is valid for 12 hours. This API requires the
    /// <c>ecr-public:GetAuthorizationToken</c> and <c>sts:GetServiceBearerToken</c> permissions.
    /// </summary>
    [Cmdlet("Get", "ECRPAuthorizationToken")]
    [OutputType("Amazon.ECRPublic.Model.AuthorizationData")]
    [AWSCmdlet("Calls the Amazon Elastic Container Registry Public GetAuthorizationToken API operation.", Operation = new[] {"GetAuthorizationToken"}, SelectReturnType = typeof(Amazon.ECRPublic.Model.GetAuthorizationTokenResponse))]
    [AWSCmdletOutput("Amazon.ECRPublic.Model.AuthorizationData or Amazon.ECRPublic.Model.GetAuthorizationTokenResponse",
        "This cmdlet returns an Amazon.ECRPublic.Model.AuthorizationData object.",
        "The service call response (type Amazon.ECRPublic.Model.GetAuthorizationTokenResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetECRPAuthorizationTokenCmdlet : AmazonECRPublicClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AuthorizationData'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECRPublic.Model.GetAuthorizationTokenResponse).
        /// Specifying the name of a property of type Amazon.ECRPublic.Model.GetAuthorizationTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AuthorizationData";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECRPublic.Model.GetAuthorizationTokenResponse, GetECRPAuthorizationTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            
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
            var request = new Amazon.ECRPublic.Model.GetAuthorizationTokenRequest();
            
            
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
        
        private Amazon.ECRPublic.Model.GetAuthorizationTokenResponse CallAWSServiceOperation(IAmazonECRPublic client, Amazon.ECRPublic.Model.GetAuthorizationTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Registry Public", "GetAuthorizationToken");
            try
            {
                return client.GetAuthorizationTokenAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ECRPublic.Model.GetAuthorizationTokenResponse, GetECRPAuthorizationTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AuthorizationData;
        }
        
    }
}
