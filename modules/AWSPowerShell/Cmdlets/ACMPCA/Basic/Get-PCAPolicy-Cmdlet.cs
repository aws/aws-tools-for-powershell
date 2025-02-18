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
using Amazon.ACMPCA;
using Amazon.ACMPCA.Model;

namespace Amazon.PowerShell.Cmdlets.PCA
{
    /// <summary>
    /// Retrieves the resource-based policy attached to a private CA. If either the private
    /// CA resource or the policy cannot be found, this action returns a <c>ResourceNotFoundException</c>.
    /// 
    /// 
    ///  
    /// <para>
    /// The policy can be attached or updated with <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_PutPolicy.html">PutPolicy</a>
    /// and removed with <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_DeletePolicy.html">DeletePolicy</a>.
    /// </para><para><b>About Policies</b></para><ul><li><para>
    /// A policy grants access on a private CA to an Amazon Web Services customer account,
    /// to Amazon Web Services Organizations, or to an Amazon Web Services Organizations unit.
    /// Policies are under the control of a CA administrator. For more information, see <a href="https://docs.aws.amazon.com/privateca/latest/userguide/pca-rbp.html">Using a
    /// Resource Based Policy with Amazon Web Services Private CA</a>.
    /// </para></li><li><para>
    /// A policy permits a user of Certificate Manager (ACM) to issue ACM certificates signed
    /// by a CA in another account.
    /// </para></li><li><para>
    /// For ACM to manage automatic renewal of these certificates, the ACM user must configure
    /// a Service Linked Role (SLR). The SLR allows the ACM service to assume the identity
    /// of the user, subject to confirmation against the Amazon Web Services Private CA policy.
    /// For more information, see <a href="https://docs.aws.amazon.com/acm/latest/userguide/acm-slr.html">Using
    /// a Service Linked Role with ACM</a>.
    /// </para></li><li><para>
    /// Updates made in Amazon Web Services Resource Manager (RAM) are reflected in policies.
    /// For more information, see <a href="https://docs.aws.amazon.com/privateca/latest/userguide/pca-ram.html">Attach
    /// a Policy for Cross-Account Access</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "PCAPolicy")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority GetPolicy API operation.", Operation = new[] {"GetPolicy"}, SelectReturnType = typeof(Amazon.ACMPCA.Model.GetPolicyResponse))]
    [AWSCmdletOutput("System.String or Amazon.ACMPCA.Model.GetPolicyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ACMPCA.Model.GetPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPCAPolicyCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// Amazon.ACMPCA.Model.GetPolicyRequest.ResourceArn
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Policy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ACMPCA.Model.GetPolicyResponse).
        /// Specifying the name of a property of type Amazon.ACMPCA.Model.GetPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Policy";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ACMPCA.Model.GetPolicyResponse, GetPCAPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ACMPCA.Model.GetPolicyRequest();
            
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
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
        
        private Amazon.ACMPCA.Model.GetPolicyResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.GetPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "GetPolicy");
            try
            {
                return client.GetPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.ACMPCA.Model.GetPolicyResponse, GetPCAPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Policy;
        }
        
    }
}
