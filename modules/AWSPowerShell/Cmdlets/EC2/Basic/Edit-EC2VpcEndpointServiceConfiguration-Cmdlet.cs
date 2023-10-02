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
    /// Modifies the attributes of your VPC endpoint service configuration. You can change
    /// the Network Load Balancers or Gateway Load Balancers for your service, and you can
    /// specify whether acceptance is required for requests to connect to your endpoint service
    /// through an interface VPC endpoint.
    /// 
    ///  
    /// <para>
    /// If you set or modify the private DNS name, you must prove that you own the private
    /// DNS domain name.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2VpcEndpointServiceConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVpcEndpointServiceConfiguration API operation.", Operation = new[] {"ModifyVpcEndpointServiceConfiguration"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVpcEndpointServiceConfigurationResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.ModifyVpcEndpointServiceConfigurationResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.EC2.Model.ModifyVpcEndpointServiceConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2VpcEndpointServiceConfigurationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceptanceRequired
        /// <summary>
        /// <para>
        /// <para>Indicates whether requests to create an endpoint to your service must be accepted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AcceptanceRequired { get; set; }
        #endregion
        
        #region Parameter AddGatewayLoadBalancerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of Gateway Load Balancers to add to your service
        /// configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddGatewayLoadBalancerArns")]
        public System.String[] AddGatewayLoadBalancerArn { get; set; }
        #endregion
        
        #region Parameter AddNetworkLoadBalancerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of Network Load Balancers to add to your service
        /// configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddNetworkLoadBalancerArns")]
        public System.String[] AddNetworkLoadBalancerArn { get; set; }
        #endregion
        
        #region Parameter AddSupportedIpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address types to add to your service configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddSupportedIpAddressTypes")]
        public System.String[] AddSupportedIpAddressType { get; set; }
        #endregion
        
        #region Parameter PrivateDnsName
        /// <summary>
        /// <para>
        /// <para>(Interface endpoint configuration) The private DNS name to assign to the endpoint
        /// service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrivateDnsName { get; set; }
        #endregion
        
        #region Parameter RemoveGatewayLoadBalancerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of Gateway Load Balancers to remove from your service
        /// configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveGatewayLoadBalancerArns")]
        public System.String[] RemoveGatewayLoadBalancerArn { get; set; }
        #endregion
        
        #region Parameter RemoveNetworkLoadBalancerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of Network Load Balancers to remove from your service
        /// configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveNetworkLoadBalancerArns")]
        public System.String[] RemoveNetworkLoadBalancerArn { get; set; }
        #endregion
        
        #region Parameter RemovePrivateDnsName
        /// <summary>
        /// <para>
        /// <para>(Interface endpoint configuration) Removes the private DNS name of the endpoint service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RemovePrivateDnsName { get; set; }
        #endregion
        
        #region Parameter RemoveSupportedIpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address types to remove from your service configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveSupportedIpAddressTypes")]
        public System.String[] RemoveSupportedIpAddressType { get; set; }
        #endregion
        
        #region Parameter ServiceId
        /// <summary>
        /// <para>
        /// <para>The ID of the service.</para>
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
        public System.String ServiceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Return'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVpcEndpointServiceConfigurationResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyVpcEndpointServiceConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Return";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServiceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServiceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServiceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VpcEndpointServiceConfiguration (ModifyVpcEndpointServiceConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVpcEndpointServiceConfigurationResponse, EditEC2VpcEndpointServiceConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServiceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AcceptanceRequired = this.AcceptanceRequired;
            if (this.AddGatewayLoadBalancerArn != null)
            {
                context.AddGatewayLoadBalancerArn = new List<System.String>(this.AddGatewayLoadBalancerArn);
            }
            if (this.AddNetworkLoadBalancerArn != null)
            {
                context.AddNetworkLoadBalancerArn = new List<System.String>(this.AddNetworkLoadBalancerArn);
            }
            if (this.AddSupportedIpAddressType != null)
            {
                context.AddSupportedIpAddressType = new List<System.String>(this.AddSupportedIpAddressType);
            }
            context.PrivateDnsName = this.PrivateDnsName;
            if (this.RemoveGatewayLoadBalancerArn != null)
            {
                context.RemoveGatewayLoadBalancerArn = new List<System.String>(this.RemoveGatewayLoadBalancerArn);
            }
            if (this.RemoveNetworkLoadBalancerArn != null)
            {
                context.RemoveNetworkLoadBalancerArn = new List<System.String>(this.RemoveNetworkLoadBalancerArn);
            }
            context.RemovePrivateDnsName = this.RemovePrivateDnsName;
            if (this.RemoveSupportedIpAddressType != null)
            {
                context.RemoveSupportedIpAddressType = new List<System.String>(this.RemoveSupportedIpAddressType);
            }
            context.ServiceId = this.ServiceId;
            #if MODULAR
            if (this.ServiceId == null && ParameterWasBound(nameof(this.ServiceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyVpcEndpointServiceConfigurationRequest();
            
            if (cmdletContext.AcceptanceRequired != null)
            {
                request.AcceptanceRequired = cmdletContext.AcceptanceRequired.Value;
            }
            if (cmdletContext.AddGatewayLoadBalancerArn != null)
            {
                request.AddGatewayLoadBalancerArns = cmdletContext.AddGatewayLoadBalancerArn;
            }
            if (cmdletContext.AddNetworkLoadBalancerArn != null)
            {
                request.AddNetworkLoadBalancerArns = cmdletContext.AddNetworkLoadBalancerArn;
            }
            if (cmdletContext.AddSupportedIpAddressType != null)
            {
                request.AddSupportedIpAddressTypes = cmdletContext.AddSupportedIpAddressType;
            }
            if (cmdletContext.PrivateDnsName != null)
            {
                request.PrivateDnsName = cmdletContext.PrivateDnsName;
            }
            if (cmdletContext.RemoveGatewayLoadBalancerArn != null)
            {
                request.RemoveGatewayLoadBalancerArns = cmdletContext.RemoveGatewayLoadBalancerArn;
            }
            if (cmdletContext.RemoveNetworkLoadBalancerArn != null)
            {
                request.RemoveNetworkLoadBalancerArns = cmdletContext.RemoveNetworkLoadBalancerArn;
            }
            if (cmdletContext.RemovePrivateDnsName != null)
            {
                request.RemovePrivateDnsName = cmdletContext.RemovePrivateDnsName.Value;
            }
            if (cmdletContext.RemoveSupportedIpAddressType != null)
            {
                request.RemoveSupportedIpAddressTypes = cmdletContext.RemoveSupportedIpAddressType;
            }
            if (cmdletContext.ServiceId != null)
            {
                request.ServiceId = cmdletContext.ServiceId;
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
        
        private Amazon.EC2.Model.ModifyVpcEndpointServiceConfigurationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVpcEndpointServiceConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVpcEndpointServiceConfiguration");
            try
            {
                #if DESKTOP
                return client.ModifyVpcEndpointServiceConfiguration(request);
                #elif CORECLR
                return client.ModifyVpcEndpointServiceConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AcceptanceRequired { get; set; }
            public List<System.String> AddGatewayLoadBalancerArn { get; set; }
            public List<System.String> AddNetworkLoadBalancerArn { get; set; }
            public List<System.String> AddSupportedIpAddressType { get; set; }
            public System.String PrivateDnsName { get; set; }
            public List<System.String> RemoveGatewayLoadBalancerArn { get; set; }
            public List<System.String> RemoveNetworkLoadBalancerArn { get; set; }
            public System.Boolean? RemovePrivateDnsName { get; set; }
            public List<System.String> RemoveSupportedIpAddressType { get; set; }
            public System.String ServiceId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVpcEndpointServiceConfigurationResponse, EditEC2VpcEndpointServiceConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Return;
        }
        
    }
}
