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
    /// Modifies the specified Client VPN endpoint. You can only modify an endpoint's server
    /// certificate information, client connection logging information, DNS server, and description.
    /// Modifying the DNS server resets existing client connections.
    /// </summary>
    [Cmdlet("Edit", "EC2ClientVpnEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud ModifyClientVpnEndpoint API operation.", Operation = new[] {"ModifyClientVpnEndpoint"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
        "The service call response (type Amazon.EC2.Model.ModifyClientVpnEndpointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2ClientVpnEndpointCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter ClientVpnEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the Client VPN endpoint to modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ClientVpnEndpointId { get; set; }
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
        
        #region Parameter DnsServers_CustomDnsServer
        /// <summary>
        /// <para>
        /// <para>The IPv4 address range, in CIDR notation, of the DNS servers to be used. You can specify
        /// up to two DNS servers. Ensure that the DNS servers can be reached by the clients.
        /// The specified values overwrite the existing values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DnsServers_CustomDnsServers")]
        public System.String[] DnsServers_CustomDnsServer { get; set; }
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
        
        #region Parameter ConnectionLogOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether connection logging is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ConnectionLogOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter DnsServers_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether DNS servers should be used. Specify <code>False</code> to delete
        /// the existing DNS servers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DnsServers_Enabled { get; set; }
        #endregion
        
        #region Parameter ServerCertificateArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the server certificate to be used. The server certificate must be provisioned
        /// in AWS Certificate Manager (ACM).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServerCertificateArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClientVpnEndpointId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2ClientVpnEndpoint (ModifyClientVpnEndpoint)"))
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
            
            context.ClientVpnEndpointId = this.ClientVpnEndpointId;
            context.ConnectionLogOptions_CloudwatchLogGroup = this.ConnectionLogOptions_CloudwatchLogGroup;
            context.ConnectionLogOptions_CloudwatchLogStream = this.ConnectionLogOptions_CloudwatchLogStream;
            if (ParameterWasBound("ConnectionLogOptions_Enabled"))
                context.ConnectionLogOptions_Enabled = this.ConnectionLogOptions_Enabled;
            context.Description = this.Description;
            if (this.DnsServers_CustomDnsServer != null)
            {
                context.DnsServers_CustomDnsServers = new List<System.String>(this.DnsServers_CustomDnsServer);
            }
            if (ParameterWasBound("DnsServers_Enabled"))
                context.DnsServers_Enabled = this.DnsServers_Enabled;
            context.ServerCertificateArn = this.ServerCertificateArn;
            
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
            
            if (cmdletContext.ClientVpnEndpointId != null)
            {
                request.ClientVpnEndpointId = cmdletContext.ClientVpnEndpointId;
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
            
             // populate DnsServers
            bool requestDnsServersIsNull = true;
            request.DnsServers = new Amazon.EC2.Model.DnsServersOptionsModifyStructure();
            List<System.String> requestDnsServers_dnsServers_CustomDnsServer = null;
            if (cmdletContext.DnsServers_CustomDnsServers != null)
            {
                requestDnsServers_dnsServers_CustomDnsServer = cmdletContext.DnsServers_CustomDnsServers;
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
            if (cmdletContext.ServerCertificateArn != null)
            {
                request.ServerCertificateArn = cmdletContext.ServerCertificateArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Return;
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
        
        private Amazon.EC2.Model.ModifyClientVpnEndpointResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyClientVpnEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ModifyClientVpnEndpoint");
            try
            {
                #if DESKTOP
                return client.ModifyClientVpnEndpoint(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyClientVpnEndpointAsync(request);
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
            public System.String ClientVpnEndpointId { get; set; }
            public System.String ConnectionLogOptions_CloudwatchLogGroup { get; set; }
            public System.String ConnectionLogOptions_CloudwatchLogStream { get; set; }
            public System.Boolean? ConnectionLogOptions_Enabled { get; set; }
            public System.String Description { get; set; }
            public List<System.String> DnsServers_CustomDnsServers { get; set; }
            public System.Boolean? DnsServers_Enabled { get; set; }
            public System.String ServerCertificateArn { get; set; }
        }
        
    }
}
