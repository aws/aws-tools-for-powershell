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
    /// Appends a successor certificate authority (CA) to your cluster, beginning the CA rotation
    /// process.
    /// 
    ///  
    /// <para>
    /// A cluster certificate authority is the root of trust for your cluster's control plane.
    /// It signs the certificates that secure communication between the Kubernetes API server
    /// and its clients, and its public certificate is distributed to your cluster's trust
    /// bundle so that worker nodes and clients can verify the API server's identity. Each
    /// cluster can have at most two certificate authorities at a time: the outgoing CA that's
    /// currently signing (its <c>signingStatus</c> is <c>IN_USE</c>) and one successor CA
    /// (<c>signingStatus</c> of <c>NOT_USED</c>) that you can later activate to complete
    /// the rotation.
    /// </para><para>
    /// Appending a successor CA adds its public certificate to the cluster's trust bundle
    /// so that the cluster trusts both CAs simultaneously (the dual trust period), but it
    /// doesn't begin signing certificates. Amazon EKS then distributes the successor CA to
    /// the Amazon Web Services managed components in your cluster; you can track this through
    /// the CA's <c>distributionStatus</c>. The successor CA can't be activated until its
    /// <c>distributionStatus</c> is <c>COMPLETE</c>. To activate it as the cluster's signer,
    /// use <a href="https://docs.aws.amazon.com/eks/latest/APIReference/API_ActivateCertificateAuthority.html"><c>ActivateCertificateAuthority</c></a>. This is an asynchronous operation that returns
    /// an <c>update</c> object. If you don't append a successor CA yourself, Amazon EKS appends
    /// one automatically before the outgoing CA approaches expiration.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/certificate-authority-rotation.html">Rotate
    /// the Amazon EKS cluster certificate authority</a> in the <i>Amazon EKS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EKSCertificateAuthority", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.CreateCertificateAuthorityResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes CreateCertificateAuthority API operation.", Operation = new[] {"CreateCertificateAuthority"}, SelectReturnType = typeof(Amazon.EKS.Model.CreateCertificateAuthorityResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.CreateCertificateAuthorityResponse",
        "This cmdlet returns an Amazon.EKS.Model.CreateCertificateAuthorityResponse object containing multiple properties."
    )]
    public partial class NewEKSCertificateAuthorityCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.CreateCertificateAuthorityResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.CreateCertificateAuthorityResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EKSCertificateAuthority (CreateCertificateAuthority)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.CreateCertificateAuthorityResponse, NewEKSCertificateAuthorityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.EKS.Model.CreateCertificateAuthorityRequest();
            
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
        
        private Amazon.EKS.Model.CreateCertificateAuthorityResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.CreateCertificateAuthorityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "CreateCertificateAuthority");
            try
            {
                return client.CreateCertificateAuthorityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String ClusterName { get; set; }
            public System.Func<Amazon.EKS.Model.CreateCertificateAuthorityResponse, NewEKSCertificateAuthorityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
