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
    /// Accept a VPC peering connection request. To accept a request, the VPC peering connection
    /// must be in the <c>pending-acceptance</c> state, and you must be the owner of the peer
    /// VPC. Use <a>DescribeVpcPeeringConnections</a> to view your outstanding VPC peering
    /// connection requests.
    /// 
    ///  
    /// <para>
    /// For an inter-Region VPC peering connection request, you must accept the VPC peering
    /// connection in the Region of the accepter VPC.
    /// </para>
    /// </summary>
    [Cmdlet("Approve", "EC2VpcPeeringConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VpcPeeringConnection")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AcceptVpcPeeringConnection API operation.", Operation = new[] {"AcceptVpcPeeringConnection"}, SelectReturnType = typeof(Amazon.EC2.Model.AcceptVpcPeeringConnectionResponse), LegacyAlias="Confirm-EC2VpcPeeringConnection")]
    [AWSCmdletOutput("Amazon.EC2.Model.VpcPeeringConnection or Amazon.EC2.Model.AcceptVpcPeeringConnectionResponse",
        "This cmdlet returns an Amazon.EC2.Model.VpcPeeringConnection object.",
        "The service call response (type Amazon.EC2.Model.AcceptVpcPeeringConnectionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ApproveEC2VpcPeeringConnectionCmdlet : AmazonEC2ClientCmdlet, IExecutor
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
        
        #region Parameter VpcPeeringConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC peering connection. You must specify this parameter in the request.</para>
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
        public System.String VpcPeeringConnectionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcPeeringConnection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AcceptVpcPeeringConnectionResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AcceptVpcPeeringConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcPeeringConnection";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpcPeeringConnectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Approve-EC2VpcPeeringConnection (AcceptVpcPeeringConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AcceptVpcPeeringConnectionResponse, ApproveEC2VpcPeeringConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.VpcPeeringConnectionId = this.VpcPeeringConnectionId;
            #if MODULAR
            if (this.VpcPeeringConnectionId == null && ParameterWasBound(nameof(this.VpcPeeringConnectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcPeeringConnectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.AcceptVpcPeeringConnectionRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.VpcPeeringConnectionId != null)
            {
                request.VpcPeeringConnectionId = cmdletContext.VpcPeeringConnectionId;
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
        
        private Amazon.EC2.Model.AcceptVpcPeeringConnectionResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AcceptVpcPeeringConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AcceptVpcPeeringConnection");
            try
            {
                return client.AcceptVpcPeeringConnectionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String VpcPeeringConnectionId { get; set; }
            public System.Func<Amazon.EC2.Model.AcceptVpcPeeringConnectionResponse, ApproveEC2VpcPeeringConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcPeeringConnection;
        }
        
    }
}
