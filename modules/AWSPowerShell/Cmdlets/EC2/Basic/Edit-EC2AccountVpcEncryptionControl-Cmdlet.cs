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
    /// Modifies the account-level VPC Encryption Control configuration. This sets the encryption
    /// control mode and resource exclusions that apply to the VPCs in your account. VPC Encryption
    /// Control enables you to enforce encryption for all data in transit within and between
    /// VPCs to meet compliance requirements.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/vpc-encryption-controls.html">Enforce
    /// VPC encryption in transit</a> in the <i>Amazon VPC User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2AccountVpcEncryptionControl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.AccountVpcEncryptionControl")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyAccountVpcEncryptionControl API operation.", Operation = new[] {"ModifyAccountVpcEncryptionControl"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyAccountVpcEncryptionControlResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.AccountVpcEncryptionControl or Amazon.EC2.Model.ModifyAccountVpcEncryptionControlResponse",
        "This cmdlet returns an Amazon.EC2.Model.AccountVpcEncryptionControl object.",
        "The service call response (type Amazon.EC2.Model.ModifyAccountVpcEncryptionControlResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2AccountVpcEncryptionControlCmdlet : AmazonEC2ClientCmdlet, IExecutor
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
        
        #region Parameter EgressOnlyInternetGateway
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude egress-only internet gateway resource from account-level
        /// encryption enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput EgressOnlyInternetGateway { get; set; }
        #endregion
        
        #region Parameter ElasticFileSystem
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude Elastic File System service from account-level encryption
        /// enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput ElasticFileSystem { get; set; }
        #endregion
        
        #region Parameter InternetGateway
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude internet gateway resource from account-level encryption
        /// enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput InternetGateway { get; set; }
        #endregion
        
        #region Parameter Lambda
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude Lambda service from account-level encryption enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput Lambda { get; set; }
        #endregion
        
        #region Parameter Mode
        /// <summary>
        /// <para>
        /// <para>The encryption mode for the account encryption control configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.AccountVpcEncryptionControlMode")]
        public Amazon.EC2.AccountVpcEncryptionControlMode Mode { get; set; }
        #endregion
        
        #region Parameter NatGateway
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude NAT gateway resource from account-level encryption enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput NatGateway { get; set; }
        #endregion
        
        #region Parameter VirtualPrivateGateway
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude virtual private gateway resource from account-level encryption
        /// enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput VirtualPrivateGateway { get; set; }
        #endregion
        
        #region Parameter VpcLattice
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude VPC Lattice service from account-level encryption enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput VpcLattice { get; set; }
        #endregion
        
        #region Parameter VpcPeering
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude VPC peering connection resource from account-level encryption
        /// enforcement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VpcEncryptionControlExclusionStateInput")]
        public Amazon.EC2.VpcEncryptionControlExclusionStateInput VpcPeering { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccountVpcEncryptionControl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyAccountVpcEncryptionControlResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyAccountVpcEncryptionControlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccountVpcEncryptionControl";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2AccountVpcEncryptionControl (ModifyAccountVpcEncryptionControl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyAccountVpcEncryptionControlResponse, EditEC2AccountVpcEncryptionControlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.EgressOnlyInternetGateway = this.EgressOnlyInternetGateway;
            context.ElasticFileSystem = this.ElasticFileSystem;
            context.InternetGateway = this.InternetGateway;
            context.Lambda = this.Lambda;
            context.Mode = this.Mode;
            context.NatGateway = this.NatGateway;
            context.VirtualPrivateGateway = this.VirtualPrivateGateway;
            context.VpcLattice = this.VpcLattice;
            context.VpcPeering = this.VpcPeering;
            
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
            var request = new Amazon.EC2.Model.ModifyAccountVpcEncryptionControlRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.EgressOnlyInternetGateway != null)
            {
                request.EgressOnlyInternetGateway = cmdletContext.EgressOnlyInternetGateway;
            }
            if (cmdletContext.ElasticFileSystem != null)
            {
                request.ElasticFileSystem = cmdletContext.ElasticFileSystem;
            }
            if (cmdletContext.InternetGateway != null)
            {
                request.InternetGateway = cmdletContext.InternetGateway;
            }
            if (cmdletContext.Lambda != null)
            {
                request.Lambda = cmdletContext.Lambda;
            }
            if (cmdletContext.Mode != null)
            {
                request.Mode = cmdletContext.Mode;
            }
            if (cmdletContext.NatGateway != null)
            {
                request.NatGateway = cmdletContext.NatGateway;
            }
            if (cmdletContext.VirtualPrivateGateway != null)
            {
                request.VirtualPrivateGateway = cmdletContext.VirtualPrivateGateway;
            }
            if (cmdletContext.VpcLattice != null)
            {
                request.VpcLattice = cmdletContext.VpcLattice;
            }
            if (cmdletContext.VpcPeering != null)
            {
                request.VpcPeering = cmdletContext.VpcPeering;
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
        
        private Amazon.EC2.Model.ModifyAccountVpcEncryptionControlResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyAccountVpcEncryptionControlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyAccountVpcEncryptionControl");
            try
            {
                return client.ModifyAccountVpcEncryptionControlAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput EgressOnlyInternetGateway { get; set; }
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput ElasticFileSystem { get; set; }
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput InternetGateway { get; set; }
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput Lambda { get; set; }
            public Amazon.EC2.AccountVpcEncryptionControlMode Mode { get; set; }
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput NatGateway { get; set; }
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput VirtualPrivateGateway { get; set; }
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput VpcLattice { get; set; }
            public Amazon.EC2.VpcEncryptionControlExclusionStateInput VpcPeering { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyAccountVpcEncryptionControlResponse, EditEC2AccountVpcEncryptionControlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccountVpcEncryptionControl;
        }
        
    }
}
