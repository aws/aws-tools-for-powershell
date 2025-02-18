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

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Release an allocation within an IPAM pool. The Region you use should be the IPAM pool
    /// locale. The locale is the Amazon Web Services Region where this IPAM pool is available
    /// for allocations. You can only use this action to release manual allocations. To remove
    /// an allocation for a resource without deleting the resource, set its monitored state
    /// to false using <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_ModifyIpamResourceCidr.html">ModifyIpamResourceCidr</a>.
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/release-alloc-ipam.html">Release
    /// an allocation</a> in the <i>Amazon VPC IPAM User Guide</i>. 
    /// 
    ///  <note><para>
    /// All EC2 API actions follow an <a href="https://docs.aws.amazon.com/ec2/latest/devguide/eventual-consistency.html">eventual
    /// consistency</a> model.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "EC2IpamPoolAllocation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ReleaseIpamPoolAllocation API operation.", Operation = new[] {"ReleaseIpamPoolAllocation"}, SelectReturnType = typeof(Amazon.EC2.Model.ReleaseIpamPoolAllocationResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.ReleaseIpamPoolAllocationResponse",
        "This cmdlet returns a collection of System.Boolean objects.",
        "The service call response (type Amazon.EC2.Model.ReleaseIpamPoolAllocationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveEC2IpamPoolAllocationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Cidr
        /// <summary>
        /// <para>
        /// <para>The CIDR of the allocation you want to release.</para>
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
        public System.String Cidr { get; set; }
        #endregion
        
        #region Parameter IpamPoolAllocationId
        /// <summary>
        /// <para>
        /// <para>The ID of the allocation.</para>
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
        public System.String IpamPoolAllocationId { get; set; }
        #endregion
        
        #region Parameter IpamPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the IPAM pool which contains the allocation you want to release.</para>
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
        public System.String IpamPoolId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Success'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ReleaseIpamPoolAllocationResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ReleaseIpamPoolAllocationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Success";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IpamPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2IpamPoolAllocation (ReleaseIpamPoolAllocation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ReleaseIpamPoolAllocationResponse, RemoveEC2IpamPoolAllocationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Cidr = this.Cidr;
            #if MODULAR
            if (this.Cidr == null && ParameterWasBound(nameof(this.Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IpamPoolAllocationId = this.IpamPoolAllocationId;
            #if MODULAR
            if (this.IpamPoolAllocationId == null && ParameterWasBound(nameof(this.IpamPoolAllocationId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamPoolAllocationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IpamPoolId = this.IpamPoolId;
            #if MODULAR
            if (this.IpamPoolId == null && ParameterWasBound(nameof(this.IpamPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ReleaseIpamPoolAllocationRequest();
            
            if (cmdletContext.Cidr != null)
            {
                request.Cidr = cmdletContext.Cidr;
            }
            if (cmdletContext.IpamPoolAllocationId != null)
            {
                request.IpamPoolAllocationId = cmdletContext.IpamPoolAllocationId;
            }
            if (cmdletContext.IpamPoolId != null)
            {
                request.IpamPoolId = cmdletContext.IpamPoolId;
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
        
        private Amazon.EC2.Model.ReleaseIpamPoolAllocationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ReleaseIpamPoolAllocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ReleaseIpamPoolAllocation");
            try
            {
                return client.ReleaseIpamPoolAllocationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Cidr { get; set; }
            public System.String IpamPoolAllocationId { get; set; }
            public System.String IpamPoolId { get; set; }
            public System.Func<Amazon.EC2.Model.ReleaseIpamPoolAllocationResponse, RemoveEC2IpamPoolAllocationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Success;
        }
        
    }
}
