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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the encryption control configuration for a VPC. You can update the encryption
    /// mode and exclusion settings for various gateway types and peering connections.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/vpc-encryption-controls.html">Enforce
    /// VPC encryption in transit</a> in the <i>Amazon VPC User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2VpcEncryptionControl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VpcEncryptionControl")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVpcEncryptionControl API operation.", Operation = new[] {"ModifyVpcEncryptionControl"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVpcEncryptionControlResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VpcEncryptionControl or Amazon.EC2.Model.ModifyVpcEncryptionControlResponse",
        "This cmdlet returns an Amazon.EC2.Model.VpcEncryptionControl object.",
        "The service call response (type Amazon.EC2.Model.ModifyVpcEncryptionControlResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2VpcEncryptionControlCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter EgressOnlyInternetGatewayExclusion
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude egress-only internet gateway traffic from encryption
        /// enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput EgressOnlyInternetGatewayExclusion { get; set; }
        #endregion
        
        #region Parameter ElasticFileSystemExclusion
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude Elastic File System traffic from encryption enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput ElasticFileSystemExclusion { get; set; }
        #endregion
        
        #region Parameter InternetGatewayExclusion
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude internet gateway traffic from encryption enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput InternetGatewayExclusion { get; set; }
        #endregion
        
        #region Parameter LambdaExclusion
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude Lambda function traffic from encryption enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput LambdaExclusion { get; set; }
        #endregion
        
        #region Parameter Mode
        /// <summary>
        /// <para>
        /// <para>The encryption mode for the VPC Encryption Control configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlMode")]
        public Amazon.EC2.VpcEncryptionControlMode Mode { get; set; }
        #endregion
        
        #region Parameter NatGatewayExclusion
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude NAT gateway traffic from encryption enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput NatGatewayExclusion { get; set; }
        #endregion
        
        #region Parameter VirtualPrivateGatewayExclusion
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude virtual private gateway traffic from encryption enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput VirtualPrivateGatewayExclusion { get; set; }
        #endregion
        
        #region Parameter VpcEncryptionControlId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC Encryption Control resource to modify.</para>
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
        public System.String VpcEncryptionControlId { get; set; }
        #endregion
        
        #region Parameter VpcLatticeExclusion
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude VPC Lattice traffic from encryption enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput VpcLatticeExclusion { get; set; }
        #endregion
        
        #region Parameter VpcPeeringExclusion
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude VPC peering connection traffic from encryption enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput VpcPeeringExclusion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcEncryptionControl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVpcEncryptionControlResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyVpcEncryptionControlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcEncryptionControl";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VpcEncryptionControl (ModifyVpcEncryptionControl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVpcEncryptionControlResponse, EditEC2VpcEncryptionControlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.EgressOnlyInternetGatewayExclusion = this.EgressOnlyInternetGatewayExclusion;
            context.ElasticFileSystemExclusion = this.ElasticFileSystemExclusion;
            context.InternetGatewayExclusion = this.InternetGatewayExclusion;
            context.LambdaExclusion = this.LambdaExclusion;
            context.Mode = this.Mode;
            context.NatGatewayExclusion = this.NatGatewayExclusion;
            context.VirtualPrivateGatewayExclusion = this.VirtualPrivateGatewayExclusion;
            context.VpcEncryptionControlId = this.VpcEncryptionControlId;
            #if MODULAR
            if (this.VpcEncryptionControlId == null && ParameterWasBound(nameof(this.VpcEncryptionControlId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcEncryptionControlId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpcLatticeExclusion = this.VpcLatticeExclusion;
            context.VpcPeeringExclusion = this.VpcPeeringExclusion;
            
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
            var request = new Amazon.EC2.Model.ModifyVpcEncryptionControlRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.EgressOnlyInternetGatewayExclusion != null)
            {
                request.EgressOnlyInternetGatewayExclusion = cmdletContext.EgressOnlyInternetGatewayExclusion;
            }
            if (cmdletContext.ElasticFileSystemExclusion != null)
            {
                request.ElasticFileSystemExclusion = cmdletContext.ElasticFileSystemExclusion;
            }
            if (cmdletContext.InternetGatewayExclusion != null)
            {
                request.InternetGatewayExclusion = cmdletContext.InternetGatewayExclusion;
            }
            if (cmdletContext.LambdaExclusion != null)
            {
                request.LambdaExclusion = cmdletContext.LambdaExclusion;
            }
            if (cmdletContext.Mode != null)
            {
                request.Mode = cmdletContext.Mode;
            }
            if (cmdletContext.NatGatewayExclusion != null)
            {
                request.NatGatewayExclusion = cmdletContext.NatGatewayExclusion;
            }
            if (cmdletContext.VirtualPrivateGatewayExclusion != null)
            {
                request.VirtualPrivateGatewayExclusion = cmdletContext.VirtualPrivateGatewayExclusion;
            }
            if (cmdletContext.VpcEncryptionControlId != null)
            {
                request.VpcEncryptionControlId = cmdletContext.VpcEncryptionControlId;
            }
            if (cmdletContext.VpcLatticeExclusion != null)
            {
                request.VpcLatticeExclusion = cmdletContext.VpcLatticeExclusion;
            }
            if (cmdletContext.VpcPeeringExclusion != null)
            {
                request.VpcPeeringExclusion = cmdletContext.VpcPeeringExclusion;
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
        
        private Amazon.EC2.Model.ModifyVpcEncryptionControlResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVpcEncryptionControlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVpcEncryptionControl");
            try
            {
                return client.ModifyVpcEncryptionControlAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput EgressOnlyInternetGatewayExclusion { get; set; }
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput ElasticFileSystemExclusion { get; set; }
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput InternetGatewayExclusion { get; set; }
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput LambdaExclusion { get; set; }
            public Amazon.EC2.VpcEncryptionControlMode Mode { get; set; }
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput NatGatewayExclusion { get; set; }
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput VirtualPrivateGatewayExclusion { get; set; }
            public System.String VpcEncryptionControlId { get; set; }
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput VpcLatticeExclusion { get; set; }
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput VpcPeeringExclusion { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVpcEncryptionControlResponse, EditEC2VpcEncryptionControlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcEncryptionControl;
        }
        
    }
}
