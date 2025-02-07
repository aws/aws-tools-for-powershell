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
    /// Allocates a Dedicated Host to your account. At a minimum, specify the supported instance
    /// type or instance family, the Availability Zone in which to allocate the host, and
    /// the number of hosts to allocate.
    /// </summary>
    [Cmdlet("New", "EC2Host", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AllocateHosts API operation.", Operation = new[] {"AllocateHosts"}, SelectReturnType = typeof(Amazon.EC2.Model.AllocateHostsResponse), LegacyAlias="New-EC2Hosts")]
    [AWSCmdletOutput("System.String or Amazon.EC2.Model.AllocateHostsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.EC2.Model.AllocateHostsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2HostCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssetId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Outpost hardware assets on which to allocate the Dedicated Hosts. Targeting
        /// specific hardware assets on an Outpost can help to minimize latency between your workloads.
        /// This parameter is supported only if you specify <b>OutpostArn</b>. If you are allocating
        /// the Dedicated Hosts in a Region, omit this parameter.</para><ul><li><para>If you specify this parameter, you can omit <b>Quantity</b>. In this case, Amazon
        /// EC2 allocates a Dedicated Host on each specified hardware asset.</para></li><li><para>If you specify both <b>AssetIds</b> and <b>Quantity</b>, then the value for <b>Quantity</b>
        /// must be equal to the number of asset IDs specified.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssetIds")]
        public System.String[] AssetId { get; set; }
        #endregion
        
        #region Parameter AutoPlacement
        /// <summary>
        /// <para>
        /// <para>Indicates whether the host accepts any untargeted instance launches that match its
        /// instance type configuration, or if it only accepts Host tenancy instance launches
        /// that specify its unique host ID. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/how-dedicated-hosts-work.html#dedicated-hosts-understanding">
        /// Understanding auto-placement and affinity</a> in the <i>Amazon EC2 User Guide</i>.</para><para>Default: <c>off</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.AutoPlacement")]
        public Amazon.EC2.AutoPlacement AutoPlacement { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone in which to allocate the Dedicated Host.</para>
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
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter HostMaintenance
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable or disable host maintenance for the Dedicated Host. For
        /// more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/dedicated-hosts-maintenance.html">Host
        /// maintenance</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.HostMaintenance")]
        public Amazon.EC2.HostMaintenance HostMaintenance { get; set; }
        #endregion
        
        #region Parameter HostRecovery
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable or disable host recovery for the Dedicated Host. Host
        /// recovery is disabled by default. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/dedicated-hosts-recovery.html">
        /// Host recovery</a> in the <i>Amazon EC2 User Guide</i>.</para><para>Default: <c>off</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.HostRecovery")]
        public Amazon.EC2.HostRecovery HostRecovery { get; set; }
        #endregion
        
        #region Parameter InstanceFamily
        /// <summary>
        /// <para>
        /// <para>Specifies the instance family to be supported by the Dedicated Hosts. If you specify
        /// an instance family, the Dedicated Hosts support multiple instance types within that
        /// instance family.</para><para>If you want the Dedicated Hosts to support a specific instance type only, omit this
        /// parameter and specify <b>InstanceType</b> instead. You cannot specify <b>InstanceFamily</b>
        /// and <b>InstanceType</b> in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceFamily { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>Specifies the instance type to be supported by the Dedicated Hosts. If you specify
        /// an instance type, the Dedicated Hosts support instances of the specified instance
        /// type only.</para><para>If you want the Dedicated Hosts to support multiple instance types in a specific instance
        /// family, omit this parameter and specify <b>InstanceFamily</b> instead. You cannot
        /// specify <b>InstanceType</b> and <b>InstanceFamily</b> in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter OutpostArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services Outpost on which to allocate
        /// the Dedicated Host. If you specify <b>OutpostArn</b>, you can optionally specify <b>AssetIds</b>.</para><para>If you are allocating the Dedicated Host in a Region, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutpostArn { get; set; }
        #endregion
        
        #region Parameter Quantity
        /// <summary>
        /// <para>
        /// <para>The number of Dedicated Hosts to allocate to your account with these parameters. If
        /// you are allocating the Dedicated Hosts on an Outpost, and you specify <b>AssetIds</b>,
        /// you can omit this parameter. In this case, Amazon EC2 allocates a Dedicated Host on
        /// each specified hardware asset. If you specify both <b>AssetIds</b> and <b>Quantity</b>,
        /// then the value that you specify for <b>Quantity</b> must be equal to the number of
        /// asset IDs specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Quantity { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the Dedicated Host during creation.</para>
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
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HostIds'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AllocateHostsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AllocateHostsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HostIds";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceType), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Host (AllocateHosts)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AllocateHostsResponse, NewEC2HostCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssetId != null)
            {
                context.AssetId = new List<System.String>(this.AssetId);
            }
            context.AutoPlacement = this.AutoPlacement;
            context.AvailabilityZone = this.AvailabilityZone;
            #if MODULAR
            if (this.AvailabilityZone == null && ParameterWasBound(nameof(this.AvailabilityZone)))
            {
                WriteWarning("You are passing $null as a value for parameter AvailabilityZone which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.HostMaintenance = this.HostMaintenance;
            context.HostRecovery = this.HostRecovery;
            context.InstanceFamily = this.InstanceFamily;
            context.InstanceType = this.InstanceType;
            context.OutpostArn = this.OutpostArn;
            context.Quantity = this.Quantity;
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
            var request = new Amazon.EC2.Model.AllocateHostsRequest();
            
            if (cmdletContext.AssetId != null)
            {
                request.AssetIds = cmdletContext.AssetId;
            }
            if (cmdletContext.AutoPlacement != null)
            {
                request.AutoPlacement = cmdletContext.AutoPlacement;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.HostMaintenance != null)
            {
                request.HostMaintenance = cmdletContext.HostMaintenance;
            }
            if (cmdletContext.HostRecovery != null)
            {
                request.HostRecovery = cmdletContext.HostRecovery;
            }
            if (cmdletContext.InstanceFamily != null)
            {
                request.InstanceFamily = cmdletContext.InstanceFamily;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.OutpostArn != null)
            {
                request.OutpostArn = cmdletContext.OutpostArn;
            }
            if (cmdletContext.Quantity != null)
            {
                request.Quantity = cmdletContext.Quantity.Value;
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
        
        private Amazon.EC2.Model.AllocateHostsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AllocateHostsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AllocateHosts");
            try
            {
                #if DESKTOP
                return client.AllocateHosts(request);
                #elif CORECLR
                return client.AllocateHostsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AssetId { get; set; }
            public Amazon.EC2.AutoPlacement AutoPlacement { get; set; }
            public System.String AvailabilityZone { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.EC2.HostMaintenance HostMaintenance { get; set; }
            public Amazon.EC2.HostRecovery HostRecovery { get; set; }
            public System.String InstanceFamily { get; set; }
            public System.String InstanceType { get; set; }
            public System.String OutpostArn { get; set; }
            public System.Int32? Quantity { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.AllocateHostsResponse, NewEC2HostCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HostIds;
        }
        
    }
}
