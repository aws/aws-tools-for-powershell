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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the specified Client VPN endpoint. Modifying the DNS server resets existing
    /// client connections.
    /// </summary>
    [Cmdlet("Edit", "EC2ClientVpnEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyClientVpnEndpoint API operation.", Operation = new[] {"ModifyClientVpnEndpoint"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyClientVpnEndpointResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.ModifyClientVpnEndpointResponse",
        "This cmdlet returns a collection of System.Boolean objects.",
        "The service call response (type Amazon.EC2.Model.ModifyClientVpnEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2ClientVpnEndpointCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientLoginBannerOptions_BannerText
        /// <summary>
        /// <para>
        /// <para>Customizable text that will be displayed in a banner on Amazon Web Services provided
        /// clients when a VPN session is established. UTF-8 encoded characters only. Maximum
        /// of 1400 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientLoginBannerOptions_BannerText { get; set; }
        #endregion
        
        #region Parameter ClientVpnEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the Client VPN endpoint to modify.</para>
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
        public System.String ClientVpnEndpointId { get; set; }
        #endregion
        
        #region Parameter ConnectionLogOptions_CloudwatchLogGroup
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch Logs log group. Required if connection logging is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionLogOptions_CloudwatchLogGroup { get; set; }
        #endregion
        
        #region Parameter ConnectionLogOptions_CloudwatchLogStream
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch Logs log stream to which the connection data is published.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionLogOptions_CloudwatchLogStream { get; set; }
        #endregion
        
        #region Parameter DnsServers_CustomDnsServer
        /// <summary>
        /// <para>
        /// <para>The IPv4 address range, in CIDR notation, of the DNS servers to be used. You can specify
        /// up to two DNS servers. Ensure that the DNS servers can be reached by the clients.
        /// The specified values overwrite the existing values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DnsServers_CustomDnsServers")]
        public System.String[] DnsServers_CustomDnsServer { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A brief description of the Client VPN endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisconnectOnSessionTimeout
        /// <summary>
        /// <para>
        /// <para>Indicates whether the client VPN session is disconnected after the maximum timeout
        /// specified in <c>sessionTimeoutHours</c> is reached. If <c>true</c>, users are prompted
        /// to reconnect client VPN. If <c>false</c>, client VPN attempts to reconnect automatically.
        /// The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisconnectOnSessionTimeout { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter ClientConnectOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether client connect options are enabled. The default is <c>false</c>
        /// (not enabled).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ClientConnectOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter ClientLoginBannerOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Enable or disable a customizable text banner that will be displayed on Amazon Web
        /// Services provided clients when a VPN session is established.</para><para>Valid values: <c>true | false</c></para><para>Default value: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ClientLoginBannerOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter ConnectionLogOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether connection logging is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectionLogOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter DnsServers_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether DNS servers should be used. Specify <c>False</c> to delete the existing
        /// DNS servers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DnsServers_Enabled { get; set; }
        #endregion
        
        #region Parameter ClientRouteEnforcementOptions_Enforced
        /// <summary>
        /// <para>
        /// <para>Enable or disable Client Route Enforcement. The state can either be <c>true</c> (enabled)
        /// or <c>false</c> (disabled). The default is <c>false</c>.</para><para>Valid values: <c>true | false</c></para><para>Default value: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ClientRouteEnforcementOptions_Enforced { get; set; }
        #endregion
        
        #region Parameter ClientConnectOptions_LambdaFunctionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Lambda function used for connection authorization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientConnectOptions_LambdaFunctionArn { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The IDs of one or more security groups to apply to the target network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SelfServicePortal
        /// <summary>
        /// <para>
        /// <para>Specify whether to enable the self-service portal for the Client VPN endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.SelfServicePortal")]
        public Amazon.EC2.SelfServicePortal SelfServicePortal { get; set; }
        #endregion
        
        #region Parameter ServerCertificateArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the server certificate to be used. The server certificate must be provisioned
        /// in Certificate Manager (ACM).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerCertificateArn { get; set; }
        #endregion
        
        #region Parameter SessionTimeoutHour
        /// <summary>
        /// <para>
        /// <para>The maximum VPN session duration time in hours.</para><para>Valid values: <c>8 | 10 | 12 | 24</c></para><para>Default value: <c>24</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionTimeoutHours")]
        public System.Int32? SessionTimeoutHour { get; set; }
        #endregion
        
        #region Parameter SplitTunnel
        /// <summary>
        /// <para>
        /// <para>Indicates whether the VPN is split-tunnel.</para><para>For information about split-tunnel VPN endpoints, see <a href="https://docs.aws.amazon.com/vpn/latest/clientvpn-admin/split-tunnel-vpn.html">Split-tunnel
        /// Client VPN endpoint</a> in the <i>Client VPN Administrator Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SplitTunnel { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC to associate with the Client VPN endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcId { get; set; }
        #endregion
        
        #region Parameter VpnPort
        /// <summary>
        /// <para>
        /// <para>The port number to assign to the Client VPN endpoint for TCP and UDP traffic.</para><para>Valid Values: <c>443</c> | <c>1194</c></para><para>Default Value: <c>443</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? VpnPort { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Return'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyClientVpnEndpointResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyClientVpnEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Return";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClientVpnEndpointId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2ClientVpnEndpoint (ModifyClientVpnEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyClientVpnEndpointResponse, EditEC2ClientVpnEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientConnectOptions_Enabled = this.ClientConnectOptions_Enabled;
            context.ClientConnectOptions_LambdaFunctionArn = this.ClientConnectOptions_LambdaFunctionArn;
            context.ClientLoginBannerOptions_BannerText = this.ClientLoginBannerOptions_BannerText;
            context.ClientLoginBannerOptions_Enabled = this.ClientLoginBannerOptions_Enabled;
            context.ClientRouteEnforcementOptions_Enforced = this.ClientRouteEnforcementOptions_Enforced;
            context.ClientVpnEndpointId = this.ClientVpnEndpointId;
            #if MODULAR
            if (this.ClientVpnEndpointId == null && ParameterWasBound(nameof(this.ClientVpnEndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientVpnEndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConnectionLogOptions_CloudwatchLogGroup = this.ConnectionLogOptions_CloudwatchLogGroup;
            context.ConnectionLogOptions_CloudwatchLogStream = this.ConnectionLogOptions_CloudwatchLogStream;
            context.ConnectionLogOptions_Enabled = this.ConnectionLogOptions_Enabled;
            context.Description = this.Description;
            context.DisconnectOnSessionTimeout = this.DisconnectOnSessionTimeout;
            if (this.DnsServers_CustomDnsServer != null)
            {
                context.DnsServers_CustomDnsServer = new List<System.String>(this.DnsServers_CustomDnsServer);
            }
            context.DnsServers_Enabled = this.DnsServers_Enabled;
            context.DryRun = this.DryRun;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            context.SelfServicePortal = this.SelfServicePortal;
            context.ServerCertificateArn = this.ServerCertificateArn;
            context.SessionTimeoutHour = this.SessionTimeoutHour;
            context.SplitTunnel = this.SplitTunnel;
            context.VpcId = this.VpcId;
            context.VpnPort = this.VpnPort;
            
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
            var request = new Amazon.EC2.Model.ModifyClientVpnEndpointRequest();
            
            
             // populate ClientConnectOptions
            var requestClientConnectOptionsIsNull = true;
            request.ClientConnectOptions = new Amazon.EC2.Model.ClientConnectOptions();
            System.Boolean? requestClientConnectOptions_clientConnectOptions_Enabled = null;
            if (cmdletContext.ClientConnectOptions_Enabled != null)
            {
                requestClientConnectOptions_clientConnectOptions_Enabled = cmdletContext.ClientConnectOptions_Enabled.Value;
            }
            if (requestClientConnectOptions_clientConnectOptions_Enabled != null)
            {
                request.ClientConnectOptions.Enabled = requestClientConnectOptions_clientConnectOptions_Enabled.Value;
                requestClientConnectOptionsIsNull = false;
            }
            System.String requestClientConnectOptions_clientConnectOptions_LambdaFunctionArn = null;
            if (cmdletContext.ClientConnectOptions_LambdaFunctionArn != null)
            {
                requestClientConnectOptions_clientConnectOptions_LambdaFunctionArn = cmdletContext.ClientConnectOptions_LambdaFunctionArn;
            }
            if (requestClientConnectOptions_clientConnectOptions_LambdaFunctionArn != null)
            {
                request.ClientConnectOptions.LambdaFunctionArn = requestClientConnectOptions_clientConnectOptions_LambdaFunctionArn;
                requestClientConnectOptionsIsNull = false;
            }
             // determine if request.ClientConnectOptions should be set to null
            if (requestClientConnectOptionsIsNull)
            {
                request.ClientConnectOptions = null;
            }
            
             // populate ClientLoginBannerOptions
            var requestClientLoginBannerOptionsIsNull = true;
            request.ClientLoginBannerOptions = new Amazon.EC2.Model.ClientLoginBannerOptions();
            System.String requestClientLoginBannerOptions_clientLoginBannerOptions_BannerText = null;
            if (cmdletContext.ClientLoginBannerOptions_BannerText != null)
            {
                requestClientLoginBannerOptions_clientLoginBannerOptions_BannerText = cmdletContext.ClientLoginBannerOptions_BannerText;
            }
            if (requestClientLoginBannerOptions_clientLoginBannerOptions_BannerText != null)
            {
                request.ClientLoginBannerOptions.BannerText = requestClientLoginBannerOptions_clientLoginBannerOptions_BannerText;
                requestClientLoginBannerOptionsIsNull = false;
            }
            System.Boolean? requestClientLoginBannerOptions_clientLoginBannerOptions_Enabled = null;
            if (cmdletContext.ClientLoginBannerOptions_Enabled != null)
            {
                requestClientLoginBannerOptions_clientLoginBannerOptions_Enabled = cmdletContext.ClientLoginBannerOptions_Enabled.Value;
            }
            if (requestClientLoginBannerOptions_clientLoginBannerOptions_Enabled != null)
            {
                request.ClientLoginBannerOptions.Enabled = requestClientLoginBannerOptions_clientLoginBannerOptions_Enabled.Value;
                requestClientLoginBannerOptionsIsNull = false;
            }
             // determine if request.ClientLoginBannerOptions should be set to null
            if (requestClientLoginBannerOptionsIsNull)
            {
                request.ClientLoginBannerOptions = null;
            }
            
             // populate ClientRouteEnforcementOptions
            var requestClientRouteEnforcementOptionsIsNull = true;
            request.ClientRouteEnforcementOptions = new Amazon.EC2.Model.ClientRouteEnforcementOptions();
            System.Boolean? requestClientRouteEnforcementOptions_clientRouteEnforcementOptions_Enforced = null;
            if (cmdletContext.ClientRouteEnforcementOptions_Enforced != null)
            {
                requestClientRouteEnforcementOptions_clientRouteEnforcementOptions_Enforced = cmdletContext.ClientRouteEnforcementOptions_Enforced.Value;
            }
            if (requestClientRouteEnforcementOptions_clientRouteEnforcementOptions_Enforced != null)
            {
                request.ClientRouteEnforcementOptions.Enforced = requestClientRouteEnforcementOptions_clientRouteEnforcementOptions_Enforced.Value;
                requestClientRouteEnforcementOptionsIsNull = false;
            }
             // determine if request.ClientRouteEnforcementOptions should be set to null
            if (requestClientRouteEnforcementOptionsIsNull)
            {
                request.ClientRouteEnforcementOptions = null;
            }
            if (cmdletContext.ClientVpnEndpointId != null)
            {
                request.ClientVpnEndpointId = cmdletContext.ClientVpnEndpointId;
            }
            
             // populate ConnectionLogOptions
            var requestConnectionLogOptionsIsNull = true;
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
            if (cmdletContext.DisconnectOnSessionTimeout != null)
            {
                request.DisconnectOnSessionTimeout = cmdletContext.DisconnectOnSessionTimeout.Value;
            }
            
             // populate DnsServers
            var requestDnsServersIsNull = true;
            request.DnsServers = new Amazon.EC2.Model.DnsServersOptionsModifyStructure();
            List<System.String> requestDnsServers_dnsServers_CustomDnsServer = null;
            if (cmdletContext.DnsServers_CustomDnsServer != null)
            {
                requestDnsServers_dnsServers_CustomDnsServer = cmdletContext.DnsServers_CustomDnsServer;
            }
            if (requestDnsServers_dnsServers_CustomDnsServer != null)
            {
                request.DnsServers.CustomDnsServers = requestDnsServers_dnsServers_CustomDnsServer;
                requestDnsServersIsNull = false;
            }
            System.Boolean? requestDnsServers_dnsServers_Enabled = null;
            if (cmdletContext.DnsServers_Enabled != null)
            {
                requestDnsServers_dnsServers_Enabled = cmdletContext.DnsServers_Enabled.Value;
            }
            if (requestDnsServers_dnsServers_Enabled != null)
            {
                request.DnsServers.Enabled = requestDnsServers_dnsServers_Enabled.Value;
                requestDnsServersIsNull = false;
            }
             // determine if request.DnsServers should be set to null
            if (requestDnsServersIsNull)
            {
                request.DnsServers = null;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.SelfServicePortal != null)
            {
                request.SelfServicePortal = cmdletContext.SelfServicePortal;
            }
            if (cmdletContext.ServerCertificateArn != null)
            {
                request.ServerCertificateArn = cmdletContext.ServerCertificateArn;
            }
            if (cmdletContext.SessionTimeoutHour != null)
            {
                request.SessionTimeoutHours = cmdletContext.SessionTimeoutHour.Value;
            }
            if (cmdletContext.SplitTunnel != null)
            {
                request.SplitTunnel = cmdletContext.SplitTunnel.Value;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
            }
            if (cmdletContext.VpnPort != null)
            {
                request.VpnPort = cmdletContext.VpnPort.Value;
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
        
        private Amazon.EC2.Model.ModifyClientVpnEndpointResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyClientVpnEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyClientVpnEndpoint");
            try
            {
                return client.ModifyClientVpnEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? ClientConnectOptions_Enabled { get; set; }
            public System.String ClientConnectOptions_LambdaFunctionArn { get; set; }
            public System.String ClientLoginBannerOptions_BannerText { get; set; }
            public System.Boolean? ClientLoginBannerOptions_Enabled { get; set; }
            public System.Boolean? ClientRouteEnforcementOptions_Enforced { get; set; }
            public System.String ClientVpnEndpointId { get; set; }
            public System.String ConnectionLogOptions_CloudwatchLogGroup { get; set; }
            public System.String ConnectionLogOptions_CloudwatchLogStream { get; set; }
            public System.Boolean? ConnectionLogOptions_Enabled { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? DisconnectOnSessionTimeout { get; set; }
            public List<System.String> DnsServers_CustomDnsServer { get; set; }
            public System.Boolean? DnsServers_Enabled { get; set; }
            public System.Boolean? DryRun { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public Amazon.EC2.SelfServicePortal SelfServicePortal { get; set; }
            public System.String ServerCertificateArn { get; set; }
            public System.Int32? SessionTimeoutHour { get; set; }
            public System.Boolean? SplitTunnel { get; set; }
            public System.String VpcId { get; set; }
            public System.Int32? VpnPort { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyClientVpnEndpointResponse, EditEC2ClientVpnEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Return;
        }
        
    }
}
