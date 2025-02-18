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
    /// Create an IP address pool for Amazon VPC IP Address Manager (IPAM). In IPAM, a pool
    /// is a collection of contiguous IP addresses CIDRs. Pools enable you to organize your
    /// IP addresses according to your routing and security needs. For example, if you have
    /// separate routing and security needs for development and production applications, you
    /// can create a pool for each.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/create-top-ipam.html">Create
    /// a top-level pool</a> in the <i>Amazon VPC IPAM User Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2IpamPool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.IpamPool")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateIpamPool API operation.", Operation = new[] {"CreateIpamPool"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateIpamPoolResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IpamPool or Amazon.EC2.Model.CreateIpamPoolResponse",
        "This cmdlet returns an Amazon.EC2.Model.IpamPool object.",
        "The service call response (type Amazon.EC2.Model.CreateIpamPoolResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2IpamPoolCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AddressFamily
        /// <summary>
        /// <para>
        /// <para>The IP protocol assigned to this IPAM pool. You must choose either IPv4 or IPv6 protocol
        /// for a pool.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.AddressFamily")]
        public Amazon.EC2.AddressFamily AddressFamily { get; set; }
        #endregion
        
        #region Parameter AllocationDefaultNetmaskLength
        /// <summary>
        /// <para>
        /// <para>The default netmask length for allocations added to this pool. If, for example, the
        /// CIDR assigned to this pool is 10.0.0.0/8 and you enter 16 here, new allocations will
        /// default to 10.0.0.0/16.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AllocationDefaultNetmaskLength { get; set; }
        #endregion
        
        #region Parameter AllocationMaxNetmaskLength
        /// <summary>
        /// <para>
        /// <para>The maximum netmask length possible for CIDR allocations in this IPAM pool to be compliant.
        /// The maximum netmask length must be greater than the minimum netmask length. Possible
        /// netmask lengths for IPv4 addresses are 0 - 32. Possible netmask lengths for IPv6 addresses
        /// are 0 - 128.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AllocationMaxNetmaskLength { get; set; }
        #endregion
        
        #region Parameter AllocationMinNetmaskLength
        /// <summary>
        /// <para>
        /// <para>The minimum netmask length required for CIDR allocations in this IPAM pool to be compliant.
        /// The minimum netmask length must be less than the maximum netmask length. Possible
        /// netmask lengths for IPv4 addresses are 0 - 32. Possible netmask lengths for IPv6 addresses
        /// are 0 - 128.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AllocationMinNetmaskLength { get; set; }
        #endregion
        
        #region Parameter AllocationResourceTag
        /// <summary>
        /// <para>
        /// <para>Tags that are required for resources that use CIDRs from this IPAM pool. Resources
        /// that do not have these tags will not be allowed to allocate space from the pool. If
        /// the resources have their tags changed after they have allocated space or if the allocation
        /// tagging requirements are changed on the pool, the resource may be marked as noncompliant.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllocationResourceTags")]
        public Amazon.EC2.Model.RequestIpamResourceTag[] AllocationResourceTag { get; set; }
        #endregion
        
        #region Parameter AutoImport
        /// <summary>
        /// <para>
        /// <para>If selected, IPAM will continuously look for resources within the CIDR range of this
        /// pool and automatically import them as allocations into your IPAM. The CIDRs that will
        /// be allocated for these resources must not already be allocated to other resources
        /// in order for the import to succeed. IPAM will import a CIDR regardless of its compliance
        /// with the pool's allocation rules, so a resource might be imported and subsequently
        /// marked as noncompliant. If IPAM discovers multiple CIDRs that overlap, IPAM will import
        /// the largest CIDR only. If IPAM discovers multiple CIDRs with matching CIDRs, IPAM
        /// will randomly import one of them only. </para><para>A locale must be set on the pool for this feature to work.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoImport { get; set; }
        #endregion
        
        #region Parameter AwsService
        /// <summary>
        /// <para>
        /// <para>Limits which service in Amazon Web Services that the pool can be used in. "ec2", for
        /// example, allows users to use space for Elastic IP addresses and VPCs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.IpamPoolAwsService")]
        public Amazon.EC2.IpamPoolAwsService AwsService { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the IPAM pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IpamScopeId
        /// <summary>
        /// <para>
        /// <para>The ID of the scope in which you would like to create the IPAM pool.</para>
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
        public System.String IpamScopeId { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The locale for the pool should be one of the following:</para><ul><li><para>An Amazon Web Services Region where you want this IPAM pool to be available for allocations.</para></li><li><para>The network border group for an Amazon Web Services Local Zone where you want this
        /// IPAM pool to be available for allocations (<a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-byoip.html#byoip-zone-avail">supported
        /// Local Zones</a>). This option is only available for IPAM IPv4 pools in the public
        /// scope.</para></li></ul><para>Possible values: Any Amazon Web Services Region or supported Amazon Web Services Local
        /// Zone. Default is <c>none</c> and means any locale.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Locale { get; set; }
        #endregion
        
        #region Parameter PublicIpSource
        /// <summary>
        /// <para>
        /// <para>The IP address source for pools in the public scope. Only used for provisioning IP
        /// address CIDRs to pools in the public scope. Default is <c>byoip</c>. For more information,
        /// see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/intro-create-ipv6-pools.html">Create
        /// IPv6 pools</a> in the <i>Amazon VPC IPAM User Guide</i>. By default, you can add only
        /// one Amazon-provided IPv6 CIDR block to a top-level IPv6 pool if PublicIpSource is
        /// <c>amazon</c>. For information on increasing the default limit, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/quotas-ipam.html">
        /// Quotas for your IPAM</a> in the <i>Amazon VPC IPAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.IpamPoolPublicIpSource")]
        public Amazon.EC2.IpamPoolPublicIpSource PublicIpSource { get; set; }
        #endregion
        
        #region Parameter PubliclyAdvertisable
        /// <summary>
        /// <para>
        /// <para>Determines if the pool is publicly advertisable. The request can only contain <c>PubliclyAdvertisable</c>
        /// if <c>AddressFamily</c> is <c>ipv6</c> and <c>PublicIpSource</c> is <c>byoip</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAdvertisable { get; set; }
        #endregion
        
        #region Parameter SourceResource_ResourceId
        /// <summary>
        /// <para>
        /// <para>The source resource ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceResource_ResourceId { get; set; }
        #endregion
        
        #region Parameter SourceResource_ResourceOwner
        /// <summary>
        /// <para>
        /// <para>The source resource owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceResource_ResourceOwner { get; set; }
        #endregion
        
        #region Parameter SourceResource_ResourceRegion
        /// <summary>
        /// <para>
        /// <para>The source resource Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceResource_ResourceRegion { get; set; }
        #endregion
        
        #region Parameter SourceResource_ResourceType
        /// <summary>
        /// <para>
        /// <para>The source resource type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.IpamPoolSourceResourceType")]
        public Amazon.EC2.IpamPoolSourceResourceType SourceResource_ResourceType { get; set; }
        #endregion
        
        #region Parameter SourceIpamPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the source IPAM pool. Use this option to create a pool within an existing
        /// pool. Note that the CIDR you provision for the pool within the source pool must be
        /// available in the source pool's CIDR range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceIpamPoolId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The key/value combination of a tag assigned to the resource. Use the tag key in the
        /// filter name and the tag value as the filter value. For example, to find all resources
        /// that have a tag with the key <c>Owner</c> and the value <c>TeamA</c>, specify <c>tag:Owner</c>
        /// for the filter name and <c>TeamA</c> for the filter value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IpamPool'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateIpamPoolResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateIpamPoolResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IpamPool";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IpamScopeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2IpamPool (CreateIpamPool)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateIpamPoolResponse, NewEC2IpamPoolCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AddressFamily = this.AddressFamily;
            #if MODULAR
            if (this.AddressFamily == null && ParameterWasBound(nameof(this.AddressFamily)))
            {
                WriteWarning("You are passing $null as a value for parameter AddressFamily which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AllocationDefaultNetmaskLength = this.AllocationDefaultNetmaskLength;
            context.AllocationMaxNetmaskLength = this.AllocationMaxNetmaskLength;
            context.AllocationMinNetmaskLength = this.AllocationMinNetmaskLength;
            if (this.AllocationResourceTag != null)
            {
                context.AllocationResourceTag = new List<Amazon.EC2.Model.RequestIpamResourceTag>(this.AllocationResourceTag);
            }
            context.AutoImport = this.AutoImport;
            context.AwsService = this.AwsService;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.IpamScopeId = this.IpamScopeId;
            #if MODULAR
            if (this.IpamScopeId == null && ParameterWasBound(nameof(this.IpamScopeId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamScopeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Locale = this.Locale;
            context.PublicIpSource = this.PublicIpSource;
            context.PubliclyAdvertisable = this.PubliclyAdvertisable;
            context.SourceIpamPoolId = this.SourceIpamPoolId;
            context.SourceResource_ResourceId = this.SourceResource_ResourceId;
            context.SourceResource_ResourceOwner = this.SourceResource_ResourceOwner;
            context.SourceResource_ResourceRegion = this.SourceResource_ResourceRegion;
            context.SourceResource_ResourceType = this.SourceResource_ResourceType;
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
            var request = new Amazon.EC2.Model.CreateIpamPoolRequest();
            
            if (cmdletContext.AddressFamily != null)
            {
                request.AddressFamily = cmdletContext.AddressFamily;
            }
            if (cmdletContext.AllocationDefaultNetmaskLength != null)
            {
                request.AllocationDefaultNetmaskLength = cmdletContext.AllocationDefaultNetmaskLength.Value;
            }
            if (cmdletContext.AllocationMaxNetmaskLength != null)
            {
                request.AllocationMaxNetmaskLength = cmdletContext.AllocationMaxNetmaskLength.Value;
            }
            if (cmdletContext.AllocationMinNetmaskLength != null)
            {
                request.AllocationMinNetmaskLength = cmdletContext.AllocationMinNetmaskLength.Value;
            }
            if (cmdletContext.AllocationResourceTag != null)
            {
                request.AllocationResourceTags = cmdletContext.AllocationResourceTag;
            }
            if (cmdletContext.AutoImport != null)
            {
                request.AutoImport = cmdletContext.AutoImport.Value;
            }
            if (cmdletContext.AwsService != null)
            {
                request.AwsService = cmdletContext.AwsService;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IpamScopeId != null)
            {
                request.IpamScopeId = cmdletContext.IpamScopeId;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            if (cmdletContext.PublicIpSource != null)
            {
                request.PublicIpSource = cmdletContext.PublicIpSource;
            }
            if (cmdletContext.PubliclyAdvertisable != null)
            {
                request.PubliclyAdvertisable = cmdletContext.PubliclyAdvertisable.Value;
            }
            if (cmdletContext.SourceIpamPoolId != null)
            {
                request.SourceIpamPoolId = cmdletContext.SourceIpamPoolId;
            }
            
             // populate SourceResource
            var requestSourceResourceIsNull = true;
            request.SourceResource = new Amazon.EC2.Model.IpamPoolSourceResourceRequest();
            System.String requestSourceResource_sourceResource_ResourceId = null;
            if (cmdletContext.SourceResource_ResourceId != null)
            {
                requestSourceResource_sourceResource_ResourceId = cmdletContext.SourceResource_ResourceId;
            }
            if (requestSourceResource_sourceResource_ResourceId != null)
            {
                request.SourceResource.ResourceId = requestSourceResource_sourceResource_ResourceId;
                requestSourceResourceIsNull = false;
            }
            System.String requestSourceResource_sourceResource_ResourceOwner = null;
            if (cmdletContext.SourceResource_ResourceOwner != null)
            {
                requestSourceResource_sourceResource_ResourceOwner = cmdletContext.SourceResource_ResourceOwner;
            }
            if (requestSourceResource_sourceResource_ResourceOwner != null)
            {
                request.SourceResource.ResourceOwner = requestSourceResource_sourceResource_ResourceOwner;
                requestSourceResourceIsNull = false;
            }
            System.String requestSourceResource_sourceResource_ResourceRegion = null;
            if (cmdletContext.SourceResource_ResourceRegion != null)
            {
                requestSourceResource_sourceResource_ResourceRegion = cmdletContext.SourceResource_ResourceRegion;
            }
            if (requestSourceResource_sourceResource_ResourceRegion != null)
            {
                request.SourceResource.ResourceRegion = requestSourceResource_sourceResource_ResourceRegion;
                requestSourceResourceIsNull = false;
            }
            Amazon.EC2.IpamPoolSourceResourceType requestSourceResource_sourceResource_ResourceType = null;
            if (cmdletContext.SourceResource_ResourceType != null)
            {
                requestSourceResource_sourceResource_ResourceType = cmdletContext.SourceResource_ResourceType;
            }
            if (requestSourceResource_sourceResource_ResourceType != null)
            {
                request.SourceResource.ResourceType = requestSourceResource_sourceResource_ResourceType;
                requestSourceResourceIsNull = false;
            }
             // determine if request.SourceResource should be set to null
            if (requestSourceResourceIsNull)
            {
                request.SourceResource = null;
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
        
        private Amazon.EC2.Model.CreateIpamPoolResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateIpamPoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateIpamPool");
            try
            {
                return client.CreateIpamPoolAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.EC2.AddressFamily AddressFamily { get; set; }
            public System.Int32? AllocationDefaultNetmaskLength { get; set; }
            public System.Int32? AllocationMaxNetmaskLength { get; set; }
            public System.Int32? AllocationMinNetmaskLength { get; set; }
            public List<Amazon.EC2.Model.RequestIpamResourceTag> AllocationResourceTag { get; set; }
            public System.Boolean? AutoImport { get; set; }
            public Amazon.EC2.IpamPoolAwsService AwsService { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String IpamScopeId { get; set; }
            public System.String Locale { get; set; }
            public Amazon.EC2.IpamPoolPublicIpSource PublicIpSource { get; set; }
            public System.Boolean? PubliclyAdvertisable { get; set; }
            public System.String SourceIpamPoolId { get; set; }
            public System.String SourceResource_ResourceId { get; set; }
            public System.String SourceResource_ResourceOwner { get; set; }
            public System.String SourceResource_ResourceRegion { get; set; }
            public Amazon.EC2.IpamPoolSourceResourceType SourceResource_ResourceType { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateIpamPoolResponse, NewEC2IpamPoolCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamPool;
        }
        
    }
}
