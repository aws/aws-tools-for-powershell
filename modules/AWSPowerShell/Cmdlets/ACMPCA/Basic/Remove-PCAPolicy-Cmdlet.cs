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
    /// Deletes the resource-based policy attached to a private CA. Deletion will remove any
    /// access that the policy has granted. If there is no policy attached to the private
    /// CA, this action will return successful.
    /// 
    ///  
    /// <para>
    /// If you delete a policy that was applied through Amazon Web Services Resource Access
    /// Manager (RAM), the CA will be removed from all shares in which it was included. 
    /// </para><para>
    /// The Certificate Manager Service Linked Role that the policy supports is not affected
    /// when you delete the policy. 
    /// </para><para>
    /// The current policy can be shown with <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_GetPolicy.html">GetPolicy</a>
    /// and updated with <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_PutPolicy.html">PutPolicy</a>.
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
    [Cmdlet("Remove", "PCAPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority DeletePolicy API operation.", Operation = new[] {"DeletePolicy"}, SelectReturnType = typeof(Amazon.ACMPCA.Model.DeletePolicyResponse))]
    [AWSCmdletOutput("None or Amazon.ACMPCA.Model.DeletePolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ACMPCA.Model.DeletePolicyResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemovePCAPolicyCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the private CA that will have its policy deleted.
        /// You can find the CA's ARN by calling the <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_ListCertificateAuthorities.html">ListCertificateAuthorities</a>
        /// action. The ARN value must have the form <c>arn:aws:acm-pca:region:account:certificate-authority/01234567-89ab-cdef-0123-0123456789ab</c>.
        /// </para>
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
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ACMPCA.Model.DeletePolicyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-PCAPolicy (DeletePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ACMPCA.Model.DeletePolicyResponse, RemovePCAPolicyCmdlet>(Select) ??
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
            var request = new Amazon.ACMPCA.Model.DeletePolicyRequest();
            
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
        
        private Amazon.ACMPCA.Model.DeletePolicyResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.DeletePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "DeletePolicy");
            try
            {
                return client.DeletePolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ACMPCA.Model.DeletePolicyResponse, RemovePCAPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
