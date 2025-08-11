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
    /// Creates a default subnet with a size <c>/20</c> IPv4 CIDR block in the specified Availability
    /// Zone in your default VPC. You can have only one default subnet per Availability Zone.
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/work-with-default-vpc.html#create-default-subnet">Create
    /// a default subnet</a> in the <i>Amazon VPC User Guide</i>.
    /// </summary>
    [Cmdlet("New", "EC2DefaultSubnet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Subnet")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateDefaultSubnet API operation.", Operation = new[] {"CreateDefaultSubnet"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateDefaultSubnetResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Subnet or Amazon.EC2.Model.CreateDefaultSubnetResponse",
        "This cmdlet returns an Amazon.EC2.Model.Subnet object.",
        "The service call response (type Amazon.EC2.Model.CreateDefaultSubnetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2DefaultSubnetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone in which to create the default subnet.</para><para>Either <c>AvailabilityZone</c> or <c>AvailabilityZoneId</c> must be specified, but
        /// not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the Availability Zone.</para><para>Either <c>AvailabilityZone</c> or <c>AvailabilityZoneId</c> must be specified, but
        /// not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZoneId { get; set; }
        #endregion
        
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
        
        #region Parameter Ipv6Native
        /// <summary>
        /// <para>
        /// <para>Indicates whether to create an IPv6 only subnet. If you already have a default subnet
        /// for this Availability Zone, you must delete it before you can create an IPv6 only
        /// subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Ipv6Native { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Subnet'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateDefaultSubnetResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateDefaultSubnetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Subnet";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AvailabilityZone), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2DefaultSubnet (CreateDefaultSubnet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateDefaultSubnetResponse, NewEC2DefaultSubnetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilityZone = this.AvailabilityZone;
            context.AvailabilityZoneId = this.AvailabilityZoneId;
            context.DryRun = this.DryRun;
            context.Ipv6Native = this.Ipv6Native;
            
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
            var request = new Amazon.EC2.Model.CreateDefaultSubnetRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.AvailabilityZoneId != null)
            {
                request.AvailabilityZoneId = cmdletContext.AvailabilityZoneId;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.Ipv6Native != null)
            {
                request.Ipv6Native = cmdletContext.Ipv6Native.Value;
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
        
        private Amazon.EC2.Model.CreateDefaultSubnetResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateDefaultSubnetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateDefaultSubnet");
            try
            {
                return client.CreateDefaultSubnetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AvailabilityZone { get; set; }
            public System.String AvailabilityZoneId { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.Boolean? Ipv6Native { get; set; }
            public System.Func<Amazon.EC2.Model.CreateDefaultSubnetResponse, NewEC2DefaultSubnetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Subnet;
        }
        
    }
}
