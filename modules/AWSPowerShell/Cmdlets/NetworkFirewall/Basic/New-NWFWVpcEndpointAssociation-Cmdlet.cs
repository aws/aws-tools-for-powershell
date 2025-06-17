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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Creates a firewall endpoint for an Network Firewall firewall. This type of firewall
    /// endpoint is independent of the firewall endpoints that you specify in the <c>Firewall</c>
    /// itself, and you define it in addition to those endpoints after the firewall has been
    /// created. You can define a VPC endpoint association using a different VPC than the
    /// one you used in the firewall specifications.
    /// </summary>
    [Cmdlet("New", "NWFWVpcEndpointAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.CreateVpcEndpointAssociationResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall CreateVpcEndpointAssociation API operation.", Operation = new[] {"CreateVpcEndpointAssociation"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.CreateVpcEndpointAssociationResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.CreateVpcEndpointAssociationResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.CreateVpcEndpointAssociationResponse object containing multiple properties."
    )]
    public partial class NewNWFWVpcEndpointAssociationCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the VPC endpoint association. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FirewallArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the firewall.</para>
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
        public System.String FirewallArn { get; set; }
        #endregion
        
        #region Parameter SubnetMapping_IPAddressType
        /// <summary>
        /// <para>
        /// <para>The subnet's IP address type. You can't change the IP address type after you create
        /// the subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.IPAddressType")]
        public Amazon.NetworkFirewall.IPAddressType SubnetMapping_IPAddressType { get; set; }
        #endregion
        
        #region Parameter SubnetMapping_SubnetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the subnet. </para>
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
        public System.String SubnetMapping_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key:value pairs to associate with the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.NetworkFirewall.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the VPC where you want to create a firewall endpoint. </para>
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
        public System.String VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.CreateVpcEndpointAssociationResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.CreateVpcEndpointAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FirewallArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FirewallArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FirewallArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpcId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NWFWVpcEndpointAssociation (CreateVpcEndpointAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.CreateVpcEndpointAssociationResponse, NewNWFWVpcEndpointAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FirewallArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.FirewallArn = this.FirewallArn;
            #if MODULAR
            if (this.FirewallArn == null && ParameterWasBound(nameof(this.FirewallArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubnetMapping_IPAddressType = this.SubnetMapping_IPAddressType;
            context.SubnetMapping_SubnetId = this.SubnetMapping_SubnetId;
            #if MODULAR
            if (this.SubnetMapping_SubnetId == null && ParameterWasBound(nameof(this.SubnetMapping_SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetMapping_SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.NetworkFirewall.Model.Tag>(this.Tag);
            }
            context.VpcId = this.VpcId;
            #if MODULAR
            if (this.VpcId == null && ParameterWasBound(nameof(this.VpcId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkFirewall.Model.CreateVpcEndpointAssociationRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FirewallArn != null)
            {
                request.FirewallArn = cmdletContext.FirewallArn;
            }
            
             // populate SubnetMapping
            var requestSubnetMappingIsNull = true;
            request.SubnetMapping = new Amazon.NetworkFirewall.Model.SubnetMapping();
            Amazon.NetworkFirewall.IPAddressType requestSubnetMapping_subnetMapping_IPAddressType = null;
            if (cmdletContext.SubnetMapping_IPAddressType != null)
            {
                requestSubnetMapping_subnetMapping_IPAddressType = cmdletContext.SubnetMapping_IPAddressType;
            }
            if (requestSubnetMapping_subnetMapping_IPAddressType != null)
            {
                request.SubnetMapping.IPAddressType = requestSubnetMapping_subnetMapping_IPAddressType;
                requestSubnetMappingIsNull = false;
            }
            System.String requestSubnetMapping_subnetMapping_SubnetId = null;
            if (cmdletContext.SubnetMapping_SubnetId != null)
            {
                requestSubnetMapping_subnetMapping_SubnetId = cmdletContext.SubnetMapping_SubnetId;
            }
            if (requestSubnetMapping_subnetMapping_SubnetId != null)
            {
                request.SubnetMapping.SubnetId = requestSubnetMapping_subnetMapping_SubnetId;
                requestSubnetMappingIsNull = false;
            }
             // determine if request.SubnetMapping should be set to null
            if (requestSubnetMappingIsNull)
            {
                request.SubnetMapping = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
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
        
        private Amazon.NetworkFirewall.Model.CreateVpcEndpointAssociationResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.CreateVpcEndpointAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "CreateVpcEndpointAssociation");
            try
            {
                #if DESKTOP
                return client.CreateVpcEndpointAssociation(request);
                #elif CORECLR
                return client.CreateVpcEndpointAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String FirewallArn { get; set; }
            public Amazon.NetworkFirewall.IPAddressType SubnetMapping_IPAddressType { get; set; }
            public System.String SubnetMapping_SubnetId { get; set; }
            public List<Amazon.NetworkFirewall.Model.Tag> Tag { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.CreateVpcEndpointAssociationResponse, NewNWFWVpcEndpointAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
