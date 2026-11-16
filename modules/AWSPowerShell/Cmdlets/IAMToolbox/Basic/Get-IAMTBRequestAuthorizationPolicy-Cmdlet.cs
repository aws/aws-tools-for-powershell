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
using Amazon.IAMToolbox;
using Amazon.IAMToolbox.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IAMTB
{
    /// <summary>
    /// Retrieves a policy that was evaluated for a specific access denied request. The operation
    /// returns the structured JSON document of the policy that was captured with the original
    /// authorization request. It doesn't retrieve the current version of the policy.
    /// 
    ///  
    /// <para>
    /// For some AWS services and policy types, the returned policy document includes all
    /// actions relevant to the service that processed the denied request, but might omit
    /// actions for other services.
    /// </para><para>
    /// Specify the authorization ID from the access denied error message and the policy URI
    /// returned by <c>GetRequestAuthorizationDetails</c> for the same authorization ID.
    /// </para><para>
    /// Access depends on the account and organization recorded for the principal that made
    /// the denied request. If an organization was recorded, the calling principal must belong
    /// to that organization. Otherwise, the calling principal must belong to the recorded
    /// account.
    /// </para><para>
    /// To use this operation, you must have the <c>iam:GetRequestAuthorizationPolicy</c>
    /// permission.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IAMTBRequestAuthorizationPolicy")]
    [OutputType("Amazon.Runtime.Documents.Document")]
    [AWSCmdlet("Calls the IAM Toolbox (Preview) GetRequestAuthorizationPolicy API operation.", Operation = new[] {"GetRequestAuthorizationPolicy"}, SelectReturnType = typeof(Amazon.IAMToolbox.Model.GetRequestAuthorizationPolicyResponse))]
    [AWSCmdletOutput("Amazon.Runtime.Documents.Document or Amazon.IAMToolbox.Model.GetRequestAuthorizationPolicyResponse",
        "This cmdlet returns an Amazon.Runtime.Documents.Document object.",
        "The service call response (type Amazon.IAMToolbox.Model.GetRequestAuthorizationPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIAMTBRequestAuthorizationPolicyCmdlet : AmazonIAMToolboxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AuthorizationId
        /// <summary>
        /// <para>
        /// <para>The authorization ID received in the access denied error message. This ID identifies
        /// the request whose evaluated policy you want to retrieve.</para>
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
        public System.String AuthorizationId { get; set; }
        #endregion
        
        #region Parameter PolicyUri
        /// <summary>
        /// <para>
        /// <para>The URI of the policy to retrieve. Use the <c>uri</c> value from the <c>policies</c>
        /// list returned by <c>GetRequestAuthorizationDetails</c> for the same authorization
        /// ID.</para>
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
        public System.String PolicyUri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PolicyDocument'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IAMToolbox.Model.GetRequestAuthorizationPolicyResponse).
        /// Specifying the name of a property of type Amazon.IAMToolbox.Model.GetRequestAuthorizationPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PolicyDocument";
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
                context.Select = CreateSelectDelegate<Amazon.IAMToolbox.Model.GetRequestAuthorizationPolicyResponse, GetIAMTBRequestAuthorizationPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthorizationId = this.AuthorizationId;
            #if MODULAR
            if (this.AuthorizationId == null && ParameterWasBound(nameof(this.AuthorizationId)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyUri = this.PolicyUri;
            #if MODULAR
            if (this.PolicyUri == null && ParameterWasBound(nameof(this.PolicyUri)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IAMToolbox.Model.GetRequestAuthorizationPolicyRequest();
            
            if (cmdletContext.AuthorizationId != null)
            {
                request.AuthorizationId = cmdletContext.AuthorizationId;
            }
            if (cmdletContext.PolicyUri != null)
            {
                request.PolicyUri = cmdletContext.PolicyUri;
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
        
        private Amazon.IAMToolbox.Model.GetRequestAuthorizationPolicyResponse CallAWSServiceOperation(IAmazonIAMToolbox client, Amazon.IAMToolbox.Model.GetRequestAuthorizationPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "IAM Toolbox (Preview)", "GetRequestAuthorizationPolicy");
            try
            {
                return client.GetRequestAuthorizationPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AuthorizationId { get; set; }
            public System.String PolicyUri { get; set; }
            public System.Func<Amazon.IAMToolbox.Model.GetRequestAuthorizationPolicyResponse, GetIAMTBRequestAuthorizationPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PolicyDocument;
        }
        
    }
}
