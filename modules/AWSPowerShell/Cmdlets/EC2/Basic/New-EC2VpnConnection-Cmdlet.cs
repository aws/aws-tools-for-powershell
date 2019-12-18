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
    /// Creates a VPN connection between an existing virtual private gateway and a VPN customer
    /// gateway. The supported connection type is <code>ipsec.1</code>.
    /// 
    ///  
    /// <para>
    /// The response includes information that you need to give to your network administrator
    /// to configure your customer gateway.
    /// </para><important><para>
    /// We strongly recommend that you use HTTPS when calling this operation because the response
    /// contains sensitive cryptographic information for configuring your customer gateway.
    /// </para></important><para>
    /// If you decide to shut down your VPN connection for any reason and later create a new
    /// VPN connection, you must reconfigure your customer gateway with the new information
    /// returned from this call.
    /// </para><para>
    /// This is an idempotent operation. If you perform the operation more than once, Amazon
    /// EC2 doesn't return an error.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpn/latest/s2svpn/VPC_VPN.html">AWS
    /// Site-to-Site VPN</a> in the <i>AWS Site-to-Site VPN User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2VpnConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VpnConnection")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateVpnConnection API operation.", Operation = new[] {"CreateVpnConnection"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateVpnConnectionResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VpnConnection or Amazon.EC2.Model.CreateVpnConnectionResponse",
        "This cmdlet returns an Amazon.EC2.Model.VpnConnection object.",
        "The service call response (type Amazon.EC2.Model.CreateVpnConnectionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2VpnConnectionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter CustomerGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the customer gateway.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String CustomerGatewayId { get; set; }
        #endregion
        
        #region Parameter Options_EnableAcceleration
        /// <summary>
        /// <para>
        /// <para>Indicate whether to enable acceleration for the VPN connection.</para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Options_EnableAcceleration { get; set; }
        #endregion
        
        #region Parameter Options_StaticRoutesOnly
        /// <summary>
        /// <para>
        /// <para>Indicate whether the VPN connection uses static routes only. If you are creating a
        /// VPN connection for a device that does not support BGP, you must specify <code>true</code>.
        /// Use <a>CreateVpnConnectionRoute</a> to create a static route.</para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        [Alias("StaticRoutesOnly")]
        public System.Boolean? Options_StaticRoutesOnly { get; set; }
        #endregion
        
        #region Parameter TransitGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway. If you specify a transit gateway, you cannot specify
        /// a virtual private gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransitGatewayId { get; set; }
        #endregion
        
        #region Parameter Options_TunnelOption
        /// <summary>
        /// <para>
        /// <para>The tunnel options for the VPN connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Options_TunnelOptions")]
        public Amazon.EC2.Model.VpnTunnelOptionsSpecification[] Options_TunnelOption { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of VPN connection (<code>ipsec.1</code>).</para>
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
        public System.String Type { get; set; }
        #endregion
        
        #region Parameter VpnGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual private gateway. If you specify a virtual private gateway, you
        /// cannot specify a transit gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String VpnGatewayId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpnConnection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateVpnConnectionResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateVpnConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpnConnection";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Type parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Type' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Type' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpnGatewayId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2VpnConnection (CreateVpnConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateVpnConnectionResponse, NewEC2VpnConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Type;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CustomerGatewayId = this.CustomerGatewayId;
            #if MODULAR
            if (this.CustomerGatewayId == null && ParameterWasBound(nameof(this.CustomerGatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomerGatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Options_EnableAcceleration = this.Options_EnableAcceleration;
            context.Options_StaticRoutesOnly = this.Options_StaticRoutesOnly;
            if (this.Options_TunnelOption != null)
            {
                context.Options_TunnelOption = new List<Amazon.EC2.Model.VpnTunnelOptionsSpecification>(this.Options_TunnelOption);
            }
            context.TransitGatewayId = this.TransitGatewayId;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpnGatewayId = this.VpnGatewayId;
            
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
            var request = new Amazon.EC2.Model.CreateVpnConnectionRequest();
            
            if (cmdletContext.CustomerGatewayId != null)
            {
                request.CustomerGatewayId = cmdletContext.CustomerGatewayId;
            }
            
             // populate Options
            var requestOptionsIsNull = true;
            request.Options = new Amazon.EC2.Model.VpnConnectionOptionsSpecification();
            System.Boolean? requestOptions_options_EnableAcceleration = null;
            if (cmdletContext.Options_EnableAcceleration != null)
            {
                requestOptions_options_EnableAcceleration = cmdletContext.Options_EnableAcceleration.Value;
            }
            if (requestOptions_options_EnableAcceleration != null)
            {
                request.Options.EnableAcceleration = requestOptions_options_EnableAcceleration.Value;
                requestOptionsIsNull = false;
            }
            System.Boolean? requestOptions_options_StaticRoutesOnly = null;
            if (cmdletContext.Options_StaticRoutesOnly != null)
            {
                requestOptions_options_StaticRoutesOnly = cmdletContext.Options_StaticRoutesOnly.Value;
            }
            if (requestOptions_options_StaticRoutesOnly != null)
            {
                request.Options.StaticRoutesOnly = requestOptions_options_StaticRoutesOnly.Value;
                requestOptionsIsNull = false;
            }
            List<Amazon.EC2.Model.VpnTunnelOptionsSpecification> requestOptions_options_TunnelOption = null;
            if (cmdletContext.Options_TunnelOption != null)
            {
                requestOptions_options_TunnelOption = cmdletContext.Options_TunnelOption;
            }
            if (requestOptions_options_TunnelOption != null)
            {
                request.Options.TunnelOptions = requestOptions_options_TunnelOption;
                requestOptionsIsNull = false;
            }
             // determine if request.Options should be set to null
            if (requestOptionsIsNull)
            {
                request.Options = null;
            }
            if (cmdletContext.TransitGatewayId != null)
            {
                request.TransitGatewayId = cmdletContext.TransitGatewayId;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.VpnGatewayId != null)
            {
                request.VpnGatewayId = cmdletContext.VpnGatewayId;
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
        
        private Amazon.EC2.Model.CreateVpnConnectionResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateVpnConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateVpnConnection");
            try
            {
                #if DESKTOP
                return client.CreateVpnConnection(request);
                #elif CORECLR
                return client.CreateVpnConnectionAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomerGatewayId { get; set; }
            public System.Boolean? Options_EnableAcceleration { get; set; }
            public System.Boolean? Options_StaticRoutesOnly { get; set; }
            public List<Amazon.EC2.Model.VpnTunnelOptionsSpecification> Options_TunnelOption { get; set; }
            public System.String TransitGatewayId { get; set; }
            public System.String Type { get; set; }
            public System.String VpnGatewayId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateVpnConnectionResponse, NewEC2VpnConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpnConnection;
        }
        
    }
}
