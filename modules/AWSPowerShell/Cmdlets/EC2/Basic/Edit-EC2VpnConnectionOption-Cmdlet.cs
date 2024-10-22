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
    /// Modifies the connection options for your Site-to-Site VPN connection.
    /// 
    ///  
    /// <para>
    /// When you modify the VPN connection options, the VPN endpoint IP addresses on the Amazon
    /// Web Services side do not change, and the tunnel options do not change. Your VPN connection
    /// will be temporarily unavailable for a brief period while the VPN connection is updated.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2VpnConnectionOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VpnConnection")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVpnConnectionOptions API operation.", Operation = new[] {"ModifyVpnConnectionOptions"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVpnConnectionOptionsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VpnConnection or Amazon.EC2.Model.ModifyVpnConnectionOptionsResponse",
        "This cmdlet returns an Amazon.EC2.Model.VpnConnection object.",
        "The service call response (type Amazon.EC2.Model.ModifyVpnConnectionOptionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2VpnConnectionOptionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LocalIpv4NetworkCidr
        /// <summary>
        /// <para>
        /// <para>The IPv4 CIDR on the customer gateway (on-premises) side of the VPN connection.</para><para>Default: <c>0.0.0.0/0</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LocalIpv4NetworkCidr { get; set; }
        #endregion
        
        #region Parameter LocalIpv6NetworkCidr
        /// <summary>
        /// <para>
        /// <para>The IPv6 CIDR on the customer gateway (on-premises) side of the VPN connection.</para><para>Default: <c>::/0</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LocalIpv6NetworkCidr { get; set; }
        #endregion
        
        #region Parameter RemoteIpv4NetworkCidr
        /// <summary>
        /// <para>
        /// <para>The IPv4 CIDR on the Amazon Web Services side of the VPN connection.</para><para>Default: <c>0.0.0.0/0</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RemoteIpv4NetworkCidr { get; set; }
        #endregion
        
        #region Parameter RemoteIpv6NetworkCidr
        /// <summary>
        /// <para>
        /// <para>The IPv6 CIDR on the Amazon Web Services side of the VPN connection.</para><para>Default: <c>::/0</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RemoteIpv6NetworkCidr { get; set; }
        #endregion
        
        #region Parameter VpnConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the Site-to-Site VPN connection. </para>
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
        public System.String VpnConnectionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpnConnection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVpnConnectionOptionsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyVpnConnectionOptionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpnConnection";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpnConnectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VpnConnectionOption (ModifyVpnConnectionOptions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVpnConnectionOptionsResponse, EditEC2VpnConnectionOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LocalIpv4NetworkCidr = this.LocalIpv4NetworkCidr;
            context.LocalIpv6NetworkCidr = this.LocalIpv6NetworkCidr;
            context.RemoteIpv4NetworkCidr = this.RemoteIpv4NetworkCidr;
            context.RemoteIpv6NetworkCidr = this.RemoteIpv6NetworkCidr;
            context.VpnConnectionId = this.VpnConnectionId;
            #if MODULAR
            if (this.VpnConnectionId == null && ParameterWasBound(nameof(this.VpnConnectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpnConnectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyVpnConnectionOptionsRequest();
            
            if (cmdletContext.LocalIpv4NetworkCidr != null)
            {
                request.LocalIpv4NetworkCidr = cmdletContext.LocalIpv4NetworkCidr;
            }
            if (cmdletContext.LocalIpv6NetworkCidr != null)
            {
                request.LocalIpv6NetworkCidr = cmdletContext.LocalIpv6NetworkCidr;
            }
            if (cmdletContext.RemoteIpv4NetworkCidr != null)
            {
                request.RemoteIpv4NetworkCidr = cmdletContext.RemoteIpv4NetworkCidr;
            }
            if (cmdletContext.RemoteIpv6NetworkCidr != null)
            {
                request.RemoteIpv6NetworkCidr = cmdletContext.RemoteIpv6NetworkCidr;
            }
            if (cmdletContext.VpnConnectionId != null)
            {
                request.VpnConnectionId = cmdletContext.VpnConnectionId;
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
        
        private Amazon.EC2.Model.ModifyVpnConnectionOptionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVpnConnectionOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVpnConnectionOptions");
            try
            {
                #if DESKTOP
                return client.ModifyVpnConnectionOptions(request);
                #elif CORECLR
                return client.ModifyVpnConnectionOptionsAsync(request).GetAwaiter().GetResult();
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
            public System.String LocalIpv4NetworkCidr { get; set; }
            public System.String LocalIpv6NetworkCidr { get; set; }
            public System.String RemoteIpv4NetworkCidr { get; set; }
            public System.String RemoteIpv6NetworkCidr { get; set; }
            public System.String VpnConnectionId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVpnConnectionOptionsResponse, EditEC2VpnConnectionOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpnConnection;
        }
        
    }
}
