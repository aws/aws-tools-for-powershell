/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Allocate a CIDR from an IPAM pool. The Region you use should be the IPAM pool locale.
    /// The locale is the Amazon Web Services Region where this IPAM pool is available for
    /// allocations.
    /// 
    ///  
    /// <para>
    /// In IPAM, an allocation is a CIDR assignment from an IPAM pool to another IPAM pool
    /// or to a resource. For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/allocate-cidrs-ipam.html">Allocate
    /// CIDRs</a> in the <i>Amazon VPC IPAM User Guide</i>.
    /// </para><note><para>
    /// This action creates an allocation with strong consistency. The returned CIDR will
    /// not overlap with any other allocations from the same pool.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "EC2IpamPoolCidr", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.IpamPoolAllocation")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AllocateIpamPoolCidr API operation.", Operation = new[] {"AllocateIpamPoolCidr"}, SelectReturnType = typeof(Amazon.EC2.Model.AllocateIpamPoolCidrResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IpamPoolAllocation or Amazon.EC2.Model.AllocateIpamPoolCidrResponse",
        "This cmdlet returns an Amazon.EC2.Model.IpamPoolAllocation object.",
        "The service call response (type Amazon.EC2.Model.AllocateIpamPoolCidrResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2IpamPoolCidrCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowedCidr
        /// <summary>
        /// <para>
        /// <para>Include a particular CIDR range that can be returned by the pool. Allowed CIDRs are
        /// only allowed if using netmask length for allocation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedCidrs")]
        public System.String[] AllowedCidr { get; set; }
        #endregion
        
        #region Parameter Cidr
        /// <summary>
        /// <para>
        /// <para>The CIDR you would like to allocate from the IPAM pool. Note the following:</para><ul><li><para>If there is no DefaultNetmaskLength allocation rule set on the pool, you must specify
        /// either the NetmaskLength or the CIDR.</para></li><li><para>If the DefaultNetmaskLength allocation rule is set on the pool, you can specify either
        /// the NetmaskLength or the CIDR and the DefaultNetmaskLength allocation rule will be
        /// ignored.</para></li></ul><para>Possible values: Any available IPv4 or IPv6 CIDR.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Cidr { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the allocation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisallowedCidr
        /// <summary>
        /// <para>
        /// <para>Exclude a particular CIDR range from being returned by the pool. Disallowed CIDRs
        /// are only allowed if using netmask length for allocation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DisallowedCidrs")]
        public System.String[] DisallowedCidr { get; set; }
        #endregion
        
        #region Parameter IpamPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the IPAM pool from which you would like to allocate a CIDR.</para>
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
        
        #region Parameter NetmaskLength
        /// <summary>
        /// <para>
        /// <para>The netmask length of the CIDR you would like to allocate from the IPAM pool. Note
        /// the following:</para><ul><li><para>If there is no DefaultNetmaskLength allocation rule set on the pool, you must specify
        /// either the NetmaskLength or the CIDR.</para></li><li><para>If the DefaultNetmaskLength allocation rule is set on the pool, you can specify either
        /// the NetmaskLength or the CIDR and the DefaultNetmaskLength allocation rule will be
        /// ignored.</para></li></ul><para>Possible netmask lengths for IPv4 addresses are 0 - 32. Possible netmask lengths for
        /// IPv6 addresses are 0 - 128.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NetmaskLength { get; set; }
        #endregion
        
        #region Parameter PreviewNextCidr
        /// <summary>
        /// <para>
        /// <para>A preview of the next available CIDR in a pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PreviewNextCidr { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IpamPoolAllocation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AllocateIpamPoolCidrResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AllocateIpamPoolCidrResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IpamPoolAllocation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IpamPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2IpamPoolCidr (AllocateIpamPoolCidr)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AllocateIpamPoolCidrResponse, NewEC2IpamPoolCidrCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllowedCidr != null)
            {
                context.AllowedCidr = new List<System.String>(this.AllowedCidr);
            }
            context.Cidr = this.Cidr;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            if (this.DisallowedCidr != null)
            {
                context.DisallowedCidr = new List<System.String>(this.DisallowedCidr);
            }
            context.IpamPoolId = this.IpamPoolId;
            #if MODULAR
            if (this.IpamPoolId == null && ParameterWasBound(nameof(this.IpamPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetmaskLength = this.NetmaskLength;
            context.PreviewNextCidr = this.PreviewNextCidr;
            
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
            var request = new Amazon.EC2.Model.AllocateIpamPoolCidrRequest();
            
            if (cmdletContext.AllowedCidr != null)
            {
                request.AllowedCidrs = cmdletContext.AllowedCidr;
            }
            if (cmdletContext.Cidr != null)
            {
                request.Cidr = cmdletContext.Cidr;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisallowedCidr != null)
            {
                request.DisallowedCidrs = cmdletContext.DisallowedCidr;
            }
            if (cmdletContext.IpamPoolId != null)
            {
                request.IpamPoolId = cmdletContext.IpamPoolId;
            }
            if (cmdletContext.NetmaskLength != null)
            {
                request.NetmaskLength = cmdletContext.NetmaskLength.Value;
            }
            if (cmdletContext.PreviewNextCidr != null)
            {
                request.PreviewNextCidr = cmdletContext.PreviewNextCidr.Value;
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
        
        private Amazon.EC2.Model.AllocateIpamPoolCidrResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AllocateIpamPoolCidrRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AllocateIpamPoolCidr");
            try
            {
                #if DESKTOP
                return client.AllocateIpamPoolCidr(request);
                #elif CORECLR
                return client.AllocateIpamPoolCidrAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AllowedCidr { get; set; }
            public System.String Cidr { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public List<System.String> DisallowedCidr { get; set; }
            public System.String IpamPoolId { get; set; }
            public System.Int32? NetmaskLength { get; set; }
            public System.Boolean? PreviewNextCidr { get; set; }
            public System.Func<Amazon.EC2.Model.AllocateIpamPoolCidrResponse, NewEC2IpamPoolCidrCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamPoolAllocation;
        }
        
    }
}
