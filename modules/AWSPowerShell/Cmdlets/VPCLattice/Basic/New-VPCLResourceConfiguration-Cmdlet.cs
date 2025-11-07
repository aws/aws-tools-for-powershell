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
    /// Creates a resource configuration. A resource configuration defines a specific resource.
    /// You can associate a resource configuration with a service network or a VPC endpoint.
    /// </summary>
    [Cmdlet("New", "VPCLResourceConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VPCLattice.Model.CreateResourceConfigurationResponse")]
    [AWSCmdlet("Calls the VPC Lattice CreateResourceConfiguration API operation.", Operation = new[] {"CreateResourceConfiguration"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.CreateResourceConfigurationResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.CreateResourceConfigurationResponse",
        "This cmdlet returns an Amazon.VPCLattice.Model.CreateResourceConfigurationResponse object containing multiple properties."
    )]
    public partial class NewVPCLResourceConfigurationCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AllowAssociationToShareableServiceNetwork
        /// <summary>
        /// <para>
        /// <para>(SINGLE, GROUP, ARN) Specifies whether the resource configuration can be associated
        /// with a sharable service network. The default is false.</para>
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
        
        #region Parameter CustomDomainName
        /// <summary>
        /// <para>
        /// <para> A custom domain name for your resource configuration. Additionally, provide a DomainVerificationID
        /// to prove your ownership of a domain. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomDomainName { get; set; }
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
        
        #region Parameter DomainVerificationIdentifier
        /// <summary>
        /// <para>
        /// <para> The domain verification ID of your verified custom domain name. If you don't provide
        /// an ID, you must configure the DNS settings yourself. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainVerificationIdentifier { get; set; }
        #endregion
        
        #region Parameter GroupDomain
        /// <summary>
        /// <para>
        /// <para> (GROUP) The group domain for a group resource configuration. Any domains that you
        /// create for the child resource are subdomains of the group domain. Child resources
        /// inherit the verification status of the domain. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GroupDomain { get; set; }
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
        /// <para>The type of IP address. Dualstack is currently not supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfigurationDefinition_DnsResource_IpAddressType")]
        [AWSConstantClassSource("Amazon.VPCLattice.ResourceConfigurationIpAddressType")]
        public Amazon.VPCLattice.ResourceConfigurationIpAddressType DnsResource_IpAddressType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the resource configuration. The name must be unique within the account.
        /// The valid characters are a-z, 0-9, and hyphens (-). You can't use a hyphen as the
        /// first or last character, or immediately after another hyphen.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PortRange
        /// <summary>
        /// <para>
        /// <para>(SINGLE, GROUP, CHILD) The TCP port ranges that a consumer can use to access a resource
        /// configuration (for example: 1-65535). You can separate port ranges using commas (for
        /// example: 1,2,22-30).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PortRanges")]
        public System.String[] PortRange { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>(SINGLE, GROUP) The protocol accepted by the resource configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.VPCLattice.ProtocolType")]
        public Amazon.VPCLattice.ProtocolType Protocol { get; set; }
        #endregion
        
        #region Parameter ResourceConfigurationGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>(CHILD) The ID or ARN of the parent resource configuration of type <c>GROUP</c>. This
        /// is used to associate a child resource configuration with a group resource configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceConfigurationGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter ResourceGatewayIdentifier
        /// <summary>
        /// <para>
        /// <para>(SINGLE, GROUP, ARN) The ID or ARN of the resource gateway used to connect to the
        /// resource configuration. For a child resource configuration, this value is inherited
        /// from the parent resource configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceGatewayIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for the resource configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of resource configuration. A resource configuration can be one of the following
        /// types:</para><ul><li><para><b>SINGLE</b> - A single resource.</para></li><li><para><b>GROUP</b> - A group of resources. You must create a group resource configuration
        /// before you create a child resource configuration.</para></li><li><para><b>CHILD</b> - A single resource that is part of a group resource configuration.</para></li><li><para><b>ARN</b> - An Amazon Web Services resource.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.VPCLattice.ResourceConfigurationType")]
        public Amazon.VPCLattice.ResourceConfigurationType Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you retry a request that completed successfully using the same client
        /// token and parameters, the retry succeeds without performing any actions. If the parameters
        /// aren't identical, the retry fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.CreateResourceConfigurationResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.CreateResourceConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-VPCLResourceConfiguration (CreateResourceConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.CreateResourceConfigurationResponse, NewVPCLResourceConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllowAssociationToShareableServiceNetwork = this.AllowAssociationToShareableServiceNetwork;
            context.ClientToken = this.ClientToken;
            context.CustomDomainName = this.CustomDomainName;
            context.DomainVerificationIdentifier = this.DomainVerificationIdentifier;
            context.GroupDomain = this.GroupDomain;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PortRange != null)
            {
                context.PortRange = new List<System.String>(this.PortRange);
            }
            context.Protocol = this.Protocol;
            context.ArnResource_Arn = this.ArnResource_Arn;
            context.DnsResource_DomainName = this.DnsResource_DomainName;
            context.DnsResource_IpAddressType = this.DnsResource_IpAddressType;
            context.IpResource_IpAddress = this.IpResource_IpAddress;
            context.ResourceConfigurationGroupIdentifier = this.ResourceConfigurationGroupIdentifier;
            context.ResourceGatewayIdentifier = this.ResourceGatewayIdentifier;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VPCLattice.Model.CreateResourceConfigurationRequest();
            
            if (cmdletContext.AllowAssociationToShareableServiceNetwork != null)
            {
                request.AllowAssociationToShareableServiceNetwork = cmdletContext.AllowAssociationToShareableServiceNetwork.Value;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CustomDomainName != null)
            {
                request.CustomDomainName = cmdletContext.CustomDomainName;
            }
            if (cmdletContext.DomainVerificationIdentifier != null)
            {
                request.DomainVerificationIdentifier = cmdletContext.DomainVerificationIdentifier;
            }
            if (cmdletContext.GroupDomain != null)
            {
                request.GroupDomain = cmdletContext.GroupDomain;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PortRange != null)
            {
                request.PortRanges = cmdletContext.PortRange;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
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
            if (cmdletContext.ResourceConfigurationGroupIdentifier != null)
            {
                request.ResourceConfigurationGroupIdentifier = cmdletContext.ResourceConfigurationGroupIdentifier;
            }
            if (cmdletContext.ResourceGatewayIdentifier != null)
            {
                request.ResourceGatewayIdentifier = cmdletContext.ResourceGatewayIdentifier;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.VPCLattice.Model.CreateResourceConfigurationResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.CreateResourceConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "CreateResourceConfiguration");
            try
            {
                return client.CreateResourceConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String CustomDomainName { get; set; }
            public System.String DomainVerificationIdentifier { get; set; }
            public System.String GroupDomain { get; set; }
            public System.String Name { get; set; }
            public List<System.String> PortRange { get; set; }
            public Amazon.VPCLattice.ProtocolType Protocol { get; set; }
            public System.String ArnResource_Arn { get; set; }
            public System.String DnsResource_DomainName { get; set; }
            public Amazon.VPCLattice.ResourceConfigurationIpAddressType DnsResource_IpAddressType { get; set; }
            public System.String IpResource_IpAddress { get; set; }
            public System.String ResourceConfigurationGroupIdentifier { get; set; }
            public System.String ResourceGatewayIdentifier { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.VPCLattice.ResourceConfigurationType Type { get; set; }
            public System.Func<Amazon.VPCLattice.Model.CreateResourceConfigurationResponse, NewVPCLResourceConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
