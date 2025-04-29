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
using Amazon.VPCLattice;
using Amazon.VPCLattice.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.VPCL
{
    /// <summary>
    /// Updates the specified resource configuration.
    /// </summary>
    [Cmdlet("Update", "VPCLResourceConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VPCLattice.Model.UpdateResourceConfigurationResponse")]
    [AWSCmdlet("Calls the VPC Lattice UpdateResourceConfiguration API operation.", Operation = new[] {"UpdateResourceConfiguration"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.UpdateResourceConfigurationResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.UpdateResourceConfigurationResponse",
        "This cmdlet returns an Amazon.VPCLattice.Model.UpdateResourceConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateVPCLResourceConfigurationCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AllowAssociationToShareableServiceNetwork
        /// <summary>
        /// <para>
        /// <para>Indicates whether to add the resource configuration to service networks that are shared
        /// with other accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowAssociationToShareableServiceNetwork { get; set; }
        #endregion
        
        #region Parameter ArnResource_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfigurationDefinition_ArnResource_Arn")]
        public System.String ArnResource_Arn { get; set; }
        #endregion
        
        #region Parameter DnsResource_DomainName
        /// <summary>
        /// <para>
        /// <para>The domain name of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfigurationDefinition_DnsResource_DomainName")]
        public System.String DnsResource_DomainName { get; set; }
        #endregion
        
        #region Parameter IpResource_IpAddress
        /// <summary>
        /// <para>
        /// <para>The IP address of the IP resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfigurationDefinition_IpResource_IpAddress")]
        public System.String IpResource_IpAddress { get; set; }
        #endregion
        
        #region Parameter DnsResource_IpAddressType
        /// <summary>
        /// <para>
        /// <para>The type of IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfigurationDefinition_DnsResource_IpAddressType")]
        [AWSConstantClassSource("Amazon.VPCLattice.ResourceConfigurationIpAddressType")]
        public Amazon.VPCLattice.ResourceConfigurationIpAddressType DnsResource_IpAddressType { get; set; }
        #endregion
        
        #region Parameter PortRange
        /// <summary>
        /// <para>
        /// <para>The TCP port ranges that a consumer can use to access a resource configuration. You
        /// can separate port ranges with a comma. Example: 1-65535 or 1,2,22-30</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PortRanges")]
        public System.String[] PortRange { get; set; }
        #endregion
        
        #region Parameter ResourceConfigurationIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the resource configuration.</para>
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
        public System.String ResourceConfigurationIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.UpdateResourceConfigurationResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.UpdateResourceConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceConfigurationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-VPCLResourceConfiguration (UpdateResourceConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.UpdateResourceConfigurationResponse, UpdateVPCLResourceConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllowAssociationToShareableServiceNetwork = this.AllowAssociationToShareableServiceNetwork;
            if (this.PortRange != null)
            {
                context.PortRange = new List<System.String>(this.PortRange);
            }
            context.ArnResource_Arn = this.ArnResource_Arn;
            context.DnsResource_DomainName = this.DnsResource_DomainName;
            context.DnsResource_IpAddressType = this.DnsResource_IpAddressType;
            context.IpResource_IpAddress = this.IpResource_IpAddress;
            context.ResourceConfigurationIdentifier = this.ResourceConfigurationIdentifier;
            #if MODULAR
            if (this.ResourceConfigurationIdentifier == null && ParameterWasBound(nameof(this.ResourceConfigurationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceConfigurationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VPCLattice.Model.UpdateResourceConfigurationRequest();
            
            if (cmdletContext.AllowAssociationToShareableServiceNetwork != null)
            {
                request.AllowAssociationToShareableServiceNetwork = cmdletContext.AllowAssociationToShareableServiceNetwork.Value;
            }
            if (cmdletContext.PortRange != null)
            {
                request.PortRanges = cmdletContext.PortRange;
            }
            
             // populate ResourceConfigurationDefinition
            var requestResourceConfigurationDefinitionIsNull = true;
            request.ResourceConfigurationDefinition = new Amazon.VPCLattice.Model.ResourceConfigurationDefinition();
            Amazon.VPCLattice.Model.ArnResource requestResourceConfigurationDefinition_resourceConfigurationDefinition_ArnResource = null;
            
             // populate ArnResource
            var requestResourceConfigurationDefinition_resourceConfigurationDefinition_ArnResourceIsNull = true;
            requestResourceConfigurationDefinition_resourceConfigurationDefinition_ArnResource = new Amazon.VPCLattice.Model.ArnResource();
            System.String requestResourceConfigurationDefinition_resourceConfigurationDefinition_ArnResource_arnResource_Arn = null;
            if (cmdletContext.ArnResource_Arn != null)
            {
                requestResourceConfigurationDefinition_resourceConfigurationDefinition_ArnResource_arnResource_Arn = cmdletContext.ArnResource_Arn;
            }
            if (requestResourceConfigurationDefinition_resourceConfigurationDefinition_ArnResource_arnResource_Arn != null)
            {
                requestResourceConfigurationDefinition_resourceConfigurationDefinition_ArnResource.Arn = requestResourceConfigurationDefinition_resourceConfigurationDefinition_ArnResource_arnResource_Arn;
                requestResourceConfigurationDefinition_resourceConfigurationDefinition_ArnResourceIsNull = false;
            }
             // determine if requestResourceConfigurationDefinition_resourceConfigurationDefinition_ArnResource should be set to null
            if (requestResourceConfigurationDefinition_resourceConfigurationDefinition_ArnResourceIsNull)
            {
                requestResourceConfigurationDefinition_resourceConfigurationDefinition_ArnResource = null;
            }
            if (requestResourceConfigurationDefinition_resourceConfigurationDefinition_ArnResource != null)
            {
                request.ResourceConfigurationDefinition.ArnResource = requestResourceConfigurationDefinition_resourceConfigurationDefinition_ArnResource;
                requestResourceConfigurationDefinitionIsNull = false;
            }
            Amazon.VPCLattice.Model.IpResource requestResourceConfigurationDefinition_resourceConfigurationDefinition_IpResource = null;
            
             // populate IpResource
            var requestResourceConfigurationDefinition_resourceConfigurationDefinition_IpResourceIsNull = true;
            requestResourceConfigurationDefinition_resourceConfigurationDefinition_IpResource = new Amazon.VPCLattice.Model.IpResource();
            System.String requestResourceConfigurationDefinition_resourceConfigurationDefinition_IpResource_ipResource_IpAddress = null;
            if (cmdletContext.IpResource_IpAddress != null)
            {
                requestResourceConfigurationDefinition_resourceConfigurationDefinition_IpResource_ipResource_IpAddress = cmdletContext.IpResource_IpAddress;
            }
            if (requestResourceConfigurationDefinition_resourceConfigurationDefinition_IpResource_ipResource_IpAddress != null)
            {
                requestResourceConfigurationDefinition_resourceConfigurationDefinition_IpResource.IpAddress = requestResourceConfigurationDefinition_resourceConfigurationDefinition_IpResource_ipResource_IpAddress;
                requestResourceConfigurationDefinition_resourceConfigurationDefinition_IpResourceIsNull = false;
            }
             // determine if requestResourceConfigurationDefinition_resourceConfigurationDefinition_IpResource should be set to null
            if (requestResourceConfigurationDefinition_resourceConfigurationDefinition_IpResourceIsNull)
            {
                requestResourceConfigurationDefinition_resourceConfigurationDefinition_IpResource = null;
            }
            if (requestResourceConfigurationDefinition_resourceConfigurationDefinition_IpResource != null)
            {
                request.ResourceConfigurationDefinition.IpResource = requestResourceConfigurationDefinition_resourceConfigurationDefinition_IpResource;
                requestResourceConfigurationDefinitionIsNull = false;
            }
            Amazon.VPCLattice.Model.DnsResource requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource = null;
            
             // populate DnsResource
            var requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResourceIsNull = true;
            requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource = new Amazon.VPCLattice.Model.DnsResource();
            System.String requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource_dnsResource_DomainName = null;
            if (cmdletContext.DnsResource_DomainName != null)
            {
                requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource_dnsResource_DomainName = cmdletContext.DnsResource_DomainName;
            }
            if (requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource_dnsResource_DomainName != null)
            {
                requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource.DomainName = requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource_dnsResource_DomainName;
                requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResourceIsNull = false;
            }
            Amazon.VPCLattice.ResourceConfigurationIpAddressType requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource_dnsResource_IpAddressType = null;
            if (cmdletContext.DnsResource_IpAddressType != null)
            {
                requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource_dnsResource_IpAddressType = cmdletContext.DnsResource_IpAddressType;
            }
            if (requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource_dnsResource_IpAddressType != null)
            {
                requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource.IpAddressType = requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource_dnsResource_IpAddressType;
                requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResourceIsNull = false;
            }
             // determine if requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource should be set to null
            if (requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResourceIsNull)
            {
                requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource = null;
            }
            if (requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource != null)
            {
                request.ResourceConfigurationDefinition.DnsResource = requestResourceConfigurationDefinition_resourceConfigurationDefinition_DnsResource;
                requestResourceConfigurationDefinitionIsNull = false;
            }
             // determine if request.ResourceConfigurationDefinition should be set to null
            if (requestResourceConfigurationDefinitionIsNull)
            {
                request.ResourceConfigurationDefinition = null;
            }
            if (cmdletContext.ResourceConfigurationIdentifier != null)
            {
                request.ResourceConfigurationIdentifier = cmdletContext.ResourceConfigurationIdentifier;
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
        
        private Amazon.VPCLattice.Model.UpdateResourceConfigurationResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.UpdateResourceConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "UpdateResourceConfiguration");
            try
            {
                return client.UpdateResourceConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AllowAssociationToShareableServiceNetwork { get; set; }
            public List<System.String> PortRange { get; set; }
            public System.String ArnResource_Arn { get; set; }
            public System.String DnsResource_DomainName { get; set; }
            public Amazon.VPCLattice.ResourceConfigurationIpAddressType DnsResource_IpAddressType { get; set; }
            public System.String IpResource_IpAddress { get; set; }
            public System.String ResourceConfigurationIdentifier { get; set; }
            public System.Func<Amazon.VPCLattice.Model.UpdateResourceConfigurationResponse, UpdateVPCLResourceConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
