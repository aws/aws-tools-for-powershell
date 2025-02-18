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
using Amazon.CloudHSMV2;
using Amazon.CloudHSMV2.Model;

namespace Amazon.PowerShell.Cmdlets.HSM2
{
    /// <summary>
    /// Claims an CloudHSM cluster by submitting the cluster certificate issued by your issuing
    /// certificate authority (CA) and the CA's root certificate. Before you can claim a cluster,
    /// you must sign the cluster's certificate signing request (CSR) with your issuing CA.
    /// To get the cluster's CSR, use <a>DescribeClusters</a>.
    /// 
    ///  
    /// <para><b>Cross-account use:</b> No. You cannot perform this operation on an CloudHSM cluster
    /// in a different Amazon Web Services account.
    /// </para>
    /// </summary>
    [Cmdlet("Initialize", "HSM2Cluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudHSMV2.Model.InitializeClusterResponse")]
    [AWSCmdlet("Calls the AWS CloudHSM V2 InitializeCluster API operation.", Operation = new[] {"InitializeCluster"}, SelectReturnType = typeof(Amazon.CloudHSMV2.Model.InitializeClusterResponse))]
    [AWSCmdletOutput("Amazon.CloudHSMV2.Model.InitializeClusterResponse",
        "This cmdlet returns an Amazon.CloudHSMV2.Model.InitializeClusterResponse object containing multiple properties."
    )]
    public partial class InitializeHSM2ClusterCmdlet : AmazonCloudHSMV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>The identifier (ID) of the cluster that you are claiming. To find the cluster ID,
        /// use <a>DescribeClusters</a>.</para>
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
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter SignedCert
        /// <summary>
        /// <para>
        /// <para>The cluster certificate issued (signed) by your issuing certificate authority (CA).
        /// The certificate must be in PEM format and can contain a maximum of 5000 characters.</para>
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
        public System.String SignedCert { get; set; }
        #endregion
        
        #region Parameter TrustAnchor
        /// <summary>
        /// <para>
        /// <para>The issuing certificate of the issuing certificate authority (CA) that issued (signed)
        /// the cluster certificate. You must use a self-signed certificate. The certificate used
        /// to sign the HSM CSR must be directly available, and thus must be the root certificate.
        /// The certificate must be in PEM format and can contain a maximum of 5000 characters.</para>
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
        public System.String TrustAnchor { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudHSMV2.Model.InitializeClusterResponse).
        /// Specifying the name of a property of type Amazon.CloudHSMV2.Model.InitializeClusterResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Initialize-HSM2Cluster (InitializeCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudHSMV2.Model.InitializeClusterResponse, InitializeHSM2ClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterId = this.ClusterId;
            #if MODULAR
            if (this.ClusterId == null && ParameterWasBound(nameof(this.ClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SignedCert = this.SignedCert;
            #if MODULAR
            if (this.SignedCert == null && ParameterWasBound(nameof(this.SignedCert)))
            {
                WriteWarning("You are passing $null as a value for parameter SignedCert which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrustAnchor = this.TrustAnchor;
            #if MODULAR
            if (this.TrustAnchor == null && ParameterWasBound(nameof(this.TrustAnchor)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustAnchor which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudHSMV2.Model.InitializeClusterRequest();
            
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            if (cmdletContext.SignedCert != null)
            {
                request.SignedCert = cmdletContext.SignedCert;
            }
            if (cmdletContext.TrustAnchor != null)
            {
                request.TrustAnchor = cmdletContext.TrustAnchor;
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
        
        private Amazon.CloudHSMV2.Model.InitializeClusterResponse CallAWSServiceOperation(IAmazonCloudHSMV2 client, Amazon.CloudHSMV2.Model.InitializeClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudHSM V2", "InitializeCluster");
            try
            {
                return client.InitializeClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClusterId { get; set; }
            public System.String SignedCert { get; set; }
            public System.String TrustAnchor { get; set; }
            public System.Func<Amazon.CloudHSMV2.Model.InitializeClusterResponse, InitializeHSM2ClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
