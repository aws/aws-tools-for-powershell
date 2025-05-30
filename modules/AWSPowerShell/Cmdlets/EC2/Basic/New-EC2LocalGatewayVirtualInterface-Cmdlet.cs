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
    /// Create a virtual interface for a local gateway.
    /// </summary>
    [Cmdlet("New", "EC2LocalGatewayVirtualInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.LocalGatewayVirtualInterface")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateLocalGatewayVirtualInterface API operation.", Operation = new[] {"CreateLocalGatewayVirtualInterface"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.LocalGatewayVirtualInterface or Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceResponse",
        "This cmdlet returns an Amazon.EC2.Model.LocalGatewayVirtualInterface object.",
        "The service call response (type Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2LocalGatewayVirtualInterfaceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LocalAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the local gateway virtual interface on the Outpost side.
        /// Only IPv4 is supported.</para>
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
        public System.String LocalAddress { get; set; }
        #endregion
        
        #region Parameter LocalGatewayVirtualInterfaceGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the local gateway virtual interface group.</para>
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
        public System.String LocalGatewayVirtualInterfaceGroupId { get; set; }
        #endregion
        
        #region Parameter OutpostLagId
        /// <summary>
        /// <para>
        /// <para>References the Link Aggregation Group (LAG) that connects the Outpost to on-premises
        /// network devices.</para>
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
        public System.String OutpostLagId { get; set; }
        #endregion
        
        #region Parameter PeerAddress
        /// <summary>
        /// <para>
        /// <para>The peer IP address for the local gateway virtual interface. Only IPv4 is supported.</para>
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
        public System.String PeerAddress { get; set; }
        #endregion
        
        #region Parameter PeerBgpAsn
        /// <summary>
        /// <para>
        /// <para>The Autonomous System Number (ASN) of the Border Gateway Protocol (BGP) peer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PeerBgpAsn { get; set; }
        #endregion
        
        #region Parameter PeerBgpAsnExtended
        /// <summary>
        /// <para>
        /// <para>The extended 32-bit ASN of the BGP peer for use with larger ASN values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? PeerBgpAsnExtended { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to a resource when the local gateway virtual interface is being
        /// created. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Vlan
        /// <summary>
        /// <para>
        /// <para>The virtual local area network (VLAN) used for the local gateway virtual interface.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Vlan { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LocalGatewayVirtualInterface'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LocalGatewayVirtualInterface";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LocalGatewayVirtualInterfaceGroupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LocalGatewayVirtualInterfaceGroupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LocalGatewayVirtualInterfaceGroupId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LocalGatewayVirtualInterfaceGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2LocalGatewayVirtualInterface (CreateLocalGatewayVirtualInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceResponse, NewEC2LocalGatewayVirtualInterfaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LocalGatewayVirtualInterfaceGroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LocalAddress = this.LocalAddress;
            #if MODULAR
            if (this.LocalAddress == null && ParameterWasBound(nameof(this.LocalAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter LocalAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LocalGatewayVirtualInterfaceGroupId = this.LocalGatewayVirtualInterfaceGroupId;
            #if MODULAR
            if (this.LocalGatewayVirtualInterfaceGroupId == null && ParameterWasBound(nameof(this.LocalGatewayVirtualInterfaceGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter LocalGatewayVirtualInterfaceGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutpostLagId = this.OutpostLagId;
            #if MODULAR
            if (this.OutpostLagId == null && ParameterWasBound(nameof(this.OutpostLagId)))
            {
                WriteWarning("You are passing $null as a value for parameter OutpostLagId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PeerAddress = this.PeerAddress;
            #if MODULAR
            if (this.PeerAddress == null && ParameterWasBound(nameof(this.PeerAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter PeerAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PeerBgpAsn = this.PeerBgpAsn;
            context.PeerBgpAsnExtended = this.PeerBgpAsnExtended;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.Vlan = this.Vlan;
            #if MODULAR
            if (this.Vlan == null && ParameterWasBound(nameof(this.Vlan)))
            {
                WriteWarning("You are passing $null as a value for parameter Vlan which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceRequest();
            
            if (cmdletContext.LocalAddress != null)
            {
                request.LocalAddress = cmdletContext.LocalAddress;
            }
            if (cmdletContext.LocalGatewayVirtualInterfaceGroupId != null)
            {
                request.LocalGatewayVirtualInterfaceGroupId = cmdletContext.LocalGatewayVirtualInterfaceGroupId;
            }
            if (cmdletContext.OutpostLagId != null)
            {
                request.OutpostLagId = cmdletContext.OutpostLagId;
            }
            if (cmdletContext.PeerAddress != null)
            {
                request.PeerAddress = cmdletContext.PeerAddress;
            }
            if (cmdletContext.PeerBgpAsn != null)
            {
                request.PeerBgpAsn = cmdletContext.PeerBgpAsn.Value;
            }
            if (cmdletContext.PeerBgpAsnExtended != null)
            {
                request.PeerBgpAsnExtended = cmdletContext.PeerBgpAsnExtended.Value;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.Vlan != null)
            {
                request.Vlan = cmdletContext.Vlan.Value;
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
        
        private Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateLocalGatewayVirtualInterface");
            try
            {
                #if DESKTOP
                return client.CreateLocalGatewayVirtualInterface(request);
                #elif CORECLR
                return client.CreateLocalGatewayVirtualInterfaceAsync(request).GetAwaiter().GetResult();
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
            public System.String LocalAddress { get; set; }
            public System.String LocalGatewayVirtualInterfaceGroupId { get; set; }
            public System.String OutpostLagId { get; set; }
            public System.String PeerAddress { get; set; }
            public System.Int32? PeerBgpAsn { get; set; }
            public System.Int64? PeerBgpAsnExtended { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Int32? Vlan { get; set; }
            public System.Func<Amazon.EC2.Model.CreateLocalGatewayVirtualInterfaceResponse, NewEC2LocalGatewayVirtualInterfaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LocalGatewayVirtualInterface;
        }
        
    }
}
