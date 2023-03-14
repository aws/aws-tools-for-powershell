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
    /// Modifies attributes of a specified VPC endpoint. The attributes that you can modify
    /// depend on the type of VPC endpoint (interface, gateway, or Gateway Load Balancer).
    /// For more information, see the <a href="https://docs.aws.amazon.com/vpc/latest/privatelink/">Amazon
    /// Web Services PrivateLink Guide</a>.
    /// </summary>
    [Cmdlet("Edit", "EC2VpcEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVpcEndpoint API operation.", Operation = new[] {"ModifyVpcEndpoint"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVpcEndpointResponse))]
    [AWSCmdletOutput("None or Amazon.EC2.Model.ModifyVpcEndpointResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.EC2.Model.ModifyVpcEndpointResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2VpcEndpointCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AddRouteTableId
        /// <summary>
        /// <para>
        /// <para>(Gateway endpoint) The IDs of the route tables to associate with the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddRouteTableIds")]
        public System.String[] AddRouteTableId { get; set; }
        #endregion
        
        #region Parameter AddSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>(Interface endpoint) The IDs of the security groups to associate with the network
        /// interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddSecurityGroupIds")]
        public System.String[] AddSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter AddSubnetId
        /// <summary>
        /// <para>
        /// <para>(Interface and Gateway Load Balancer endpoints) The IDs of the subnets in which to
        /// serve the endpoint. For a Gateway Load Balancer endpoint, you can specify only one
        /// subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddSubnetIds")]
        public System.String[] AddSubnetId { get; set; }
        #endregion
        
        #region Parameter DnsOptions_DnsRecordIpType
        /// <summary>
        /// <para>
        /// <para>The DNS records created for the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.DnsRecordIpType")]
        public Amazon.EC2.DnsRecordIpType DnsOptions_DnsRecordIpType { get; set; }
        #endregion
        
        #region Parameter IpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address type for the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.IpAddressType")]
        public Amazon.EC2.IpAddressType IpAddressType { get; set; }
        #endregion
        
        #region Parameter PolicyDocument
        /// <summary>
        /// <para>
        /// <para>(Interface and gateway endpoints) A policy to attach to the endpoint that controls
        /// access to the service. The policy must be in valid JSON format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyDocument { get; set; }
        #endregion
        
        #region Parameter PrivateDnsEnabled
        /// <summary>
        /// <para>
        /// <para>(Interface endpoint) Indicates whether a private hosted zone is associated with the
        /// VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PrivateDnsEnabled { get; set; }
        #endregion
        
        #region Parameter DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable private DNS only for inbound endpoints. This option is
        /// available only for services that support both gateway and interface endpoints. It
        /// routes traffic that originates from the VPC to the gateway endpoint and traffic that
        /// originates from on-premises to the interface endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint { get; set; }
        #endregion
        
        #region Parameter RemoveRouteTableId
        /// <summary>
        /// <para>
        /// <para>(Gateway endpoint) The IDs of the route tables to disassociate from the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveRouteTableIds")]
        public System.String[] RemoveRouteTableId { get; set; }
        #endregion
        
        #region Parameter RemoveSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>(Interface endpoint) The IDs of the security groups to disassociate from the network
        /// interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveSecurityGroupIds")]
        public System.String[] RemoveSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter RemoveSubnetId
        /// <summary>
        /// <para>
        /// <para>(Interface endpoint) The IDs of the subnets from which to remove the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveSubnetIds")]
        public System.String[] RemoveSubnetId { get; set; }
        #endregion
        
        #region Parameter ResetPolicy
        /// <summary>
        /// <para>
        /// <para>(Gateway endpoint) Specify <code>true</code> to reset the policy document to the default
        /// policy. The default policy allows full access to the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ResetPolicy { get; set; }
        #endregion
        
        #region Parameter VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the endpoint.</para>
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
        public System.String VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVpcEndpointResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VpcEndpointId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VpcEndpointId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VpcEndpointId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpcEndpointId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VpcEndpoint (ModifyVpcEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVpcEndpointResponse, EditEC2VpcEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VpcEndpointId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AddRouteTableId != null)
            {
                context.AddRouteTableId = new List<System.String>(this.AddRouteTableId);
            }
            if (this.AddSecurityGroupId != null)
            {
                context.AddSecurityGroupId = new List<System.String>(this.AddSecurityGroupId);
            }
            if (this.AddSubnetId != null)
            {
                context.AddSubnetId = new List<System.String>(this.AddSubnetId);
            }
            context.DnsOptions_DnsRecordIpType = this.DnsOptions_DnsRecordIpType;
            context.DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint = this.DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint;
            context.IpAddressType = this.IpAddressType;
            context.PolicyDocument = this.PolicyDocument;
            context.PrivateDnsEnabled = this.PrivateDnsEnabled;
            if (this.RemoveRouteTableId != null)
            {
                context.RemoveRouteTableId = new List<System.String>(this.RemoveRouteTableId);
            }
            if (this.RemoveSecurityGroupId != null)
            {
                context.RemoveSecurityGroupId = new List<System.String>(this.RemoveSecurityGroupId);
            }
            if (this.RemoveSubnetId != null)
            {
                context.RemoveSubnetId = new List<System.String>(this.RemoveSubnetId);
            }
            context.ResetPolicy = this.ResetPolicy;
            context.VpcEndpointId = this.VpcEndpointId;
            #if MODULAR
            if (this.VpcEndpointId == null && ParameterWasBound(nameof(this.VpcEndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcEndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyVpcEndpointRequest();
            
            if (cmdletContext.AddRouteTableId != null)
            {
                request.AddRouteTableIds = cmdletContext.AddRouteTableId;
            }
            if (cmdletContext.AddSecurityGroupId != null)
            {
                request.AddSecurityGroupIds = cmdletContext.AddSecurityGroupId;
            }
            if (cmdletContext.AddSubnetId != null)
            {
                request.AddSubnetIds = cmdletContext.AddSubnetId;
            }
            
             // populate DnsOptions
            var requestDnsOptionsIsNull = true;
            request.DnsOptions = new Amazon.EC2.Model.DnsOptionsSpecification();
            Amazon.EC2.DnsRecordIpType requestDnsOptions_dnsOptions_DnsRecordIpType = null;
            if (cmdletContext.DnsOptions_DnsRecordIpType != null)
            {
                requestDnsOptions_dnsOptions_DnsRecordIpType = cmdletContext.DnsOptions_DnsRecordIpType;
            }
            if (requestDnsOptions_dnsOptions_DnsRecordIpType != null)
            {
                request.DnsOptions.DnsRecordIpType = requestDnsOptions_dnsOptions_DnsRecordIpType;
                requestDnsOptionsIsNull = false;
            }
            System.Boolean? requestDnsOptions_dnsOptions_PrivateDnsOnlyForInboundResolverEndpoint = null;
            if (cmdletContext.DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint != null)
            {
                requestDnsOptions_dnsOptions_PrivateDnsOnlyForInboundResolverEndpoint = cmdletContext.DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint.Value;
            }
            if (requestDnsOptions_dnsOptions_PrivateDnsOnlyForInboundResolverEndpoint != null)
            {
                request.DnsOptions.PrivateDnsOnlyForInboundResolverEndpoint = requestDnsOptions_dnsOptions_PrivateDnsOnlyForInboundResolverEndpoint.Value;
                requestDnsOptionsIsNull = false;
            }
             // determine if request.DnsOptions should be set to null
            if (requestDnsOptionsIsNull)
            {
                request.DnsOptions = null;
            }
            if (cmdletContext.IpAddressType != null)
            {
                request.IpAddressType = cmdletContext.IpAddressType;
            }
            if (cmdletContext.PolicyDocument != null)
            {
                request.PolicyDocument = cmdletContext.PolicyDocument;
            }
            if (cmdletContext.PrivateDnsEnabled != null)
            {
                request.PrivateDnsEnabled = cmdletContext.PrivateDnsEnabled.Value;
            }
            if (cmdletContext.RemoveRouteTableId != null)
            {
                request.RemoveRouteTableIds = cmdletContext.RemoveRouteTableId;
            }
            if (cmdletContext.RemoveSecurityGroupId != null)
            {
                request.RemoveSecurityGroupIds = cmdletContext.RemoveSecurityGroupId;
            }
            if (cmdletContext.RemoveSubnetId != null)
            {
                request.RemoveSubnetIds = cmdletContext.RemoveSubnetId;
            }
            if (cmdletContext.ResetPolicy != null)
            {
                request.ResetPolicy = cmdletContext.ResetPolicy.Value;
            }
            if (cmdletContext.VpcEndpointId != null)
            {
                request.VpcEndpointId = cmdletContext.VpcEndpointId;
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
        
        private Amazon.EC2.Model.ModifyVpcEndpointResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVpcEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVpcEndpoint");
            try
            {
                #if DESKTOP
                return client.ModifyVpcEndpoint(request);
                #elif CORECLR
                return client.ModifyVpcEndpointAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AddRouteTableId { get; set; }
            public List<System.String> AddSecurityGroupId { get; set; }
            public List<System.String> AddSubnetId { get; set; }
            public Amazon.EC2.DnsRecordIpType DnsOptions_DnsRecordIpType { get; set; }
            public System.Boolean? DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint { get; set; }
            public Amazon.EC2.IpAddressType IpAddressType { get; set; }
            public System.String PolicyDocument { get; set; }
            public System.Boolean? PrivateDnsEnabled { get; set; }
            public List<System.String> RemoveRouteTableId { get; set; }
            public List<System.String> RemoveSecurityGroupId { get; set; }
            public List<System.String> RemoveSubnetId { get; set; }
            public System.Boolean? ResetPolicy { get; set; }
            public System.String VpcEndpointId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVpcEndpointResponse, EditEC2VpcEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
