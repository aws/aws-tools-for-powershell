/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a Client VPN endpoint. A Client VPN endpoint is the resource you create and
    /// configure to enable and manage client VPN sessions. It is the destination endpoint
    /// at which all client VPN sessions are terminated.
    /// </summary>
    [Cmdlet("New", "EC2ClientVpnEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateClientVpnEndpointResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CreateClientVpnEndpoint API operation.", Operation = new[] {"CreateClientVpnEndpoint"})]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateClientVpnEndpointResponse",
        "This cmdlet returns a Amazon.EC2.Model.CreateClientVpnEndpointResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2ClientVpnEndpointCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AuthenticationOption
        /// <summary>
        /// <para>
        /// <para>Information about the authentication method to be used to authenticate clients.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AuthenticationOptions")]
        public Amazon.EC2.Model.ClientVpnAuthenticationRequest[] AuthenticationOption { get; set; }
        #endregion
        
        #region Parameter ClientCidrBlock
        /// <summary>
        /// <para>
        /// <para>The IPv4 address range, in CIDR notation, from which to assign client IP addresses.
        /// The address range cannot overlap with the local CIDR of the VPC in which the associated
        /// subnet is located, or the routes that you add manually. The address range cannot be
        /// changed after the Client VPN endpoint has been created. The CIDR block should be /22
        /// or greater.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientCidrBlock { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure the idempotency of the request.
        /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Run_Instance_Idempotency.html">
        /// How to Ensure Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter ConnectionLogOptions_CloudwatchLogGroup
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch Logs log group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConnectionLogOptions_CloudwatchLogGroup { get; set; }
        #endregion
        
        #region Parameter ConnectionLogOptions_CloudwatchLogStream
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch Logs log stream to which the connection data is published.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConnectionLogOptions_CloudwatchLogStream { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A brief description of the Client VPN endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DnsServer
        /// <summary>
        /// <para>
        /// <para>Information about the DNS servers to be used for DNS resolution. A Client VPN endpoint
        /// can have up to two DNS servers. If no DNS server is specified, the DNS address of
        /// the VPC that is to be associated with Client VPN endpoint is used as the DNS server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DnsServers")]
        public System.String[] DnsServer { get; set; }
        #endregion
        
        #region Parameter ConnectionLogOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether connection logging is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ConnectionLogOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter ServerCertificateArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the server certificate. For more information, see the <a href="acm/latest/userguide/acm-overview.html">AWS
        /// Certificate Manager User Guide</a> .</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ServerCertificateArn { get; set; }
        #endregion
        
        #region Parameter TransportProtocol
        /// <summary>
        /// <para>
        /// <para>The transport protocol to be used by the VPN session.</para><para>Default value: <code>udp</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.TransportProtocol")]
        public Amazon.EC2.TransportProtocol TransportProtocol { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ServerCertificateArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2ClientVpnEndpoint (CreateClientVpnEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.AuthenticationOption != null)
            {
                context.AuthenticationOptions = new List<Amazon.EC2.Model.ClientVpnAuthenticationRequest>(this.AuthenticationOption);
            }
            context.ClientCidrBlock = this.ClientCidrBlock;
            context.ClientToken = this.ClientToken;
            context.ConnectionLogOptions_CloudwatchLogGroup = this.ConnectionLogOptions_CloudwatchLogGroup;
            context.ConnectionLogOptions_CloudwatchLogStream = this.ConnectionLogOptions_CloudwatchLogStream;
            if (ParameterWasBound("ConnectionLogOptions_Enabled"))
                context.ConnectionLogOptions_Enabled = this.ConnectionLogOptions_Enabled;
            context.Description = this.Description;
            if (this.DnsServer != null)
            {
                context.DnsServers = new List<System.String>(this.DnsServer);
            }
            context.ServerCertificateArn = this.ServerCertificateArn;
            context.TransportProtocol = this.TransportProtocol;
            
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
            var request = new Amazon.EC2.Model.CreateClientVpnEndpointRequest();
            
            if (cmdletContext.AuthenticationOptions != null)
            {
                request.AuthenticationOptions = cmdletContext.AuthenticationOptions;
            }
            if (cmdletContext.ClientCidrBlock != null)
            {
                request.ClientCidrBlock = cmdletContext.ClientCidrBlock;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ConnectionLogOptions
            bool requestConnectionLogOptionsIsNull = true;
            request.ConnectionLogOptions = new Amazon.EC2.Model.ConnectionLogOptions();
            System.String requestConnectionLogOptions_connectionLogOptions_CloudwatchLogGroup = null;
            if (cmdletContext.ConnectionLogOptions_CloudwatchLogGroup != null)
            {
                requestConnectionLogOptions_connectionLogOptions_CloudwatchLogGroup = cmdletContext.ConnectionLogOptions_CloudwatchLogGroup;
            }
            if (requestConnectionLogOptions_connectionLogOptions_CloudwatchLogGroup != null)
            {
                request.ConnectionLogOptions.CloudwatchLogGroup = requestConnectionLogOptions_connectionLogOptions_CloudwatchLogGroup;
                requestConnectionLogOptionsIsNull = false;
            }
            System.String requestConnectionLogOptions_connectionLogOptions_CloudwatchLogStream = null;
            if (cmdletContext.ConnectionLogOptions_CloudwatchLogStream != null)
            {
                requestConnectionLogOptions_connectionLogOptions_CloudwatchLogStream = cmdletContext.ConnectionLogOptions_CloudwatchLogStream;
            }
            if (requestConnectionLogOptions_connectionLogOptions_CloudwatchLogStream != null)
            {
                request.ConnectionLogOptions.CloudwatchLogStream = requestConnectionLogOptions_connectionLogOptions_CloudwatchLogStream;
                requestConnectionLogOptionsIsNull = false;
            }
            System.Boolean? requestConnectionLogOptions_connectionLogOptions_Enabled = null;
            if (cmdletContext.ConnectionLogOptions_Enabled != null)
            {
                requestConnectionLogOptions_connectionLogOptions_Enabled = cmdletContext.ConnectionLogOptions_Enabled.Value;
            }
            if (requestConnectionLogOptions_connectionLogOptions_Enabled != null)
            {
                request.ConnectionLogOptions.Enabled = requestConnectionLogOptions_connectionLogOptions_Enabled.Value;
                requestConnectionLogOptionsIsNull = false;
            }
             // determine if request.ConnectionLogOptions should be set to null
            if (requestConnectionLogOptionsIsNull)
            {
                request.ConnectionLogOptions = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DnsServers != null)
            {
                request.DnsServers = cmdletContext.DnsServers;
            }
            if (cmdletContext.ServerCertificateArn != null)
            {
                request.ServerCertificateArn = cmdletContext.ServerCertificateArn;
            }
            if (cmdletContext.TransportProtocol != null)
            {
                request.TransportProtocol = cmdletContext.TransportProtocol;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.EC2.Model.CreateClientVpnEndpointResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateClientVpnEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateClientVpnEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateClientVpnEndpoint(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateClientVpnEndpointAsync(request);
                return task.Result;
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
            public List<Amazon.EC2.Model.ClientVpnAuthenticationRequest> AuthenticationOptions { get; set; }
            public System.String ClientCidrBlock { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ConnectionLogOptions_CloudwatchLogGroup { get; set; }
            public System.String ConnectionLogOptions_CloudwatchLogStream { get; set; }
            public System.Boolean? ConnectionLogOptions_Enabled { get; set; }
            public System.String Description { get; set; }
            public List<System.String> DnsServers { get; set; }
            public System.String ServerCertificateArn { get; set; }
            public Amazon.EC2.TransportProtocol TransportProtocol { get; set; }
        }
        
    }
}
