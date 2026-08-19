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
using Amazon.EKS;
using Amazon.EKS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Activates a successor certificate authority (CA) as the signing certificate authority
    /// for your cluster, completing a CA rotation.
    /// 
    ///  
    /// <para>
    /// When you activate a successor CA, Amazon EKS promotes it to be the cluster's signer
    /// (its <c>signingStatus</c> becomes <c>IN_USE</c>) and the outgoing CA is retired (<c>NOT_USED</c>).
    /// The outgoing CA remains in the cluster's trust bundle but no longer signs certificates.
    /// The successor CA you activate must already be present on the cluster and fully distributed
    /// (its <c>distributionStatus</c> must be <c>COMPLETE</c>). This is an asynchronous operation
    /// that returns an <c>update</c> object you can track with <a href="https://docs.aws.amazon.com/eks/latest/APIReference/API_DescribeUpdate.html"><c>DescribeUpdate</c></a>.
    /// </para><para>
    /// Before you activate the successor CA, make sure the worker nodes you manage and your
    /// external clients have been updated to trust it, so they maintain connectivity to the
    /// API server after activation. For a limited period after activation, CA rollback is
    /// available to revert to the outgoing CA if needed. If you don't activate the successor
    /// CA yourself, Amazon EKS activates it automatically as the expiration deadline approaches.
    /// For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/certificate-authority-rotation.html">Rotate
    /// the Amazon EKS cluster certificate authority</a> in the <i>Amazon EKS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "EKSCertificateAuthority", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.ActivateCertificateAuthorityResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes ActivateCertificateAuthority API operation.", Operation = new[] {"ActivateCertificateAuthority"}, SelectReturnType = typeof(Amazon.EKS.Model.ActivateCertificateAuthorityResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.ActivateCertificateAuthorityResponse",
        "This cmdlet returns an Amazon.EKS.Model.ActivateCertificateAuthorityResponse object containing multiple properties."
    )]
    public partial class EnableEKSCertificateAuthorityCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CertificateAuthorityId
        /// <summary>
        /// <para>
        /// <para>The ID of the certificate authority to activate as the cluster's signing certificate
        /// authority. This certificate authority must already exist on the cluster and have a
        /// <c>distributionStatus</c> of <c>COMPLETE</c>.</para>
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
        public System.String CertificateAuthorityId { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of your cluster.</para>
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
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.ActivateCertificateAuthorityResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.ActivateCertificateAuthorityResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateAuthorityId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-EKSCertificateAuthority (ActivateCertificateAuthority)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.ActivateCertificateAuthorityResponse, EnableEKSCertificateAuthorityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificateAuthorityId = this.CertificateAuthorityId;
            #if MODULAR
            if (this.CertificateAuthorityId == null && ParameterWasBound(nameof(this.CertificateAuthorityId)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateAuthorityId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EKS.Model.ActivateCertificateAuthorityRequest();
            
            if (cmdletContext.CertificateAuthorityId != null)
            {
                request.CertificateAuthorityId = cmdletContext.CertificateAuthorityId;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
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
        
        private Amazon.EKS.Model.ActivateCertificateAuthorityResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.ActivateCertificateAuthorityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "ActivateCertificateAuthority");
            try
            {
                return client.ActivateCertificateAuthorityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CertificateAuthorityId { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String ClusterName { get; set; }
            public System.Func<Amazon.EKS.Model.ActivateCertificateAuthorityResponse, EnableEKSCertificateAuthorityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
