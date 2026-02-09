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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a secondary subnet in a secondary network.
    /// 
    ///  
    /// <para>
    /// A secondary subnet CIDR block must not overlap with the CIDR block of an existing
    /// secondary subnet in the secondary network. After you create a secondary subnet, you
    /// can't change its CIDR block.
    /// </para><para>
    /// The allowed size for a secondary subnet CIDR block is between /28 netmask (16 IP addresses)
    /// and /12 netmask (1,048,576 IP addresses). Amazon reserves the first four IP addresses
    /// and the last IP address in each secondary subnet for internal use.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2SecondarySubnet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.SecondarySubnet")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateSecondarySubnet API operation.", Operation = new[] {"CreateSecondarySubnet"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateSecondarySubnetResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.SecondarySubnet or Amazon.EC2.Model.CreateSecondarySubnetResponse",
        "This cmdlet returns an Amazon.EC2.Model.SecondarySubnet object.",
        "The service call response (type Amazon.EC2.Model.CreateSecondarySubnetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2SecondarySubnetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone for the secondary subnet. You cannot specify both <c>AvailabilityZone</c>
        /// and <c>AvailabilityZoneId</c> in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the Availability Zone for the secondary subnet. This option is preferred
        /// over <c>AvailabilityZone</c> as it provides a consistent identifier across Amazon
        /// Web Services accounts. You cannot specify both <c>AvailabilityZone</c> and <c>AvailabilityZoneId</c>
        /// in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter Ipv4CidrBlock
        /// <summary>
        /// <para>
        /// <para>The IPv4 CIDR block for the secondary subnet. The CIDR block size must be between
        /// /12 and /28.</para>
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
        public System.String Ipv4CidrBlock { get; set; }
        #endregion
        
        #region Parameter SecondaryNetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the secondary network in which to create the secondary subnet.</para>
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
        public System.String SecondaryNetworkId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the secondary subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensure
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SecondarySubnet'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateSecondarySubnetResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateSecondarySubnetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SecondarySubnet";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SecondaryNetworkId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2SecondarySubnet (CreateSecondarySubnet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateSecondarySubnetResponse, NewEC2SecondarySubnetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilityZone = this.AvailabilityZone;
            context.AvailabilityZoneId = this.AvailabilityZoneId;
            context.ClientToken = this.ClientToken;
            context.Ipv4CidrBlock = this.Ipv4CidrBlock;
            #if MODULAR
            if (this.Ipv4CidrBlock == null && ParameterWasBound(nameof(this.Ipv4CidrBlock)))
            {
                WriteWarning("You are passing $null as a value for parameter Ipv4CidrBlock which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecondaryNetworkId = this.SecondaryNetworkId;
            #if MODULAR
            if (this.SecondaryNetworkId == null && ParameterWasBound(nameof(this.SecondaryNetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecondaryNetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            
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
            var request = new Amazon.EC2.Model.CreateSecondarySubnetRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.AvailabilityZoneId != null)
            {
                request.AvailabilityZoneId = cmdletContext.AvailabilityZoneId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Ipv4CidrBlock != null)
            {
                request.Ipv4CidrBlock = cmdletContext.Ipv4CidrBlock;
            }
            if (cmdletContext.SecondaryNetworkId != null)
            {
                request.SecondaryNetworkId = cmdletContext.SecondaryNetworkId;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreateSecondarySubnetResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateSecondarySubnetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateSecondarySubnet");
            try
            {
                #if DESKTOP
                return client.CreateSecondarySubnet(request);
                #elif CORECLR
                return client.CreateSecondarySubnetAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.String ClientToken { get; set; }
            public System.String Ipv4CidrBlock { get; set; }
            public System.String SecondaryNetworkId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateSecondarySubnetResponse, NewEC2SecondarySubnetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SecondarySubnet;
        }
        
    }
}
