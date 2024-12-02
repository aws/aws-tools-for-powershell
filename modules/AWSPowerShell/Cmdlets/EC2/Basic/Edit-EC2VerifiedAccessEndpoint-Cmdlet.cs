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
    /// Modifies the configuration of the specified Amazon Web Services Verified Access endpoint.
    /// </summary>
    [Cmdlet("Edit", "EC2VerifiedAccessEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VerifiedAccessEndpoint")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVerifiedAccessEndpoint API operation.", Operation = new[] {"ModifyVerifiedAccessEndpoint"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVerifiedAccessEndpointResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VerifiedAccessEndpoint or Amazon.EC2.Model.ModifyVerifiedAccessEndpointResponse",
        "This cmdlet returns an Amazon.EC2.Model.VerifiedAccessEndpoint object.",
        "The service call response (type Amazon.EC2.Model.ModifyVerifiedAccessEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2VerifiedAccessEndpointCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the Verified Access endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter LoadBalancerOptions_Port
        /// <summary>
        /// <para>
        /// <para>The IP port number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoadBalancerOptions_Port { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceOptions_Port
        /// <summary>
        /// <para>
        /// <para>The IP port number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NetworkInterfaceOptions_Port { get; set; }
        #endregion
        
        #region Parameter RdsOptions_Port
        /// <summary>
        /// <para>
        /// <para>The port.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RdsOptions_Port { get; set; }
        #endregion
        
        #region Parameter CidrOptions_PortRange
        /// <summary>
        /// <para>
        /// <para>The port ranges.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CidrOptions_PortRanges")]
        public Amazon.EC2.Model.ModifyVerifiedAccessEndpointPortRange[] CidrOptions_PortRange { get; set; }
        #endregion
        
        #region Parameter LoadBalancerOptions_PortRange
        /// <summary>
        /// <para>
        /// <para>The port ranges.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancerOptions_PortRanges")]
        public Amazon.EC2.Model.ModifyVerifiedAccessEndpointPortRange[] LoadBalancerOptions_PortRange { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceOptions_PortRange
        /// <summary>
        /// <para>
        /// <para>The port ranges.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkInterfaceOptions_PortRanges")]
        public Amazon.EC2.Model.ModifyVerifiedAccessEndpointPortRange[] NetworkInterfaceOptions_PortRange { get; set; }
        #endregion
        
        #region Parameter LoadBalancerOptions_Protocol
        /// <summary>
        /// <para>
        /// <para>The IP protocol.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VerifiedAccessEndpointProtocol")]
        public Amazon.EC2.VerifiedAccessEndpointProtocol LoadBalancerOptions_Protocol { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceOptions_Protocol
        /// <summary>
        /// <para>
        /// <para>The IP protocol.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.VerifiedAccessEndpointProtocol")]
        public Amazon.EC2.VerifiedAccessEndpointProtocol NetworkInterfaceOptions_Protocol { get; set; }
        #endregion
        
        #region Parameter RdsOptions_RdsEndpoint
        /// <summary>
        /// <para>
        /// <para>The RDS endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RdsOptions_RdsEndpoint { get; set; }
        #endregion
        
        #region Parameter LoadBalancerOptions_SubnetId
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancerOptions_SubnetIds")]
        public System.String[] LoadBalancerOptions_SubnetId { get; set; }
        #endregion
        
        #region Parameter RdsOptions_SubnetId
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RdsOptions_SubnetIds")]
        public System.String[] RdsOptions_SubnetId { get; set; }
        #endregion
        
        #region Parameter VerifiedAccessEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the Verified Access endpoint.</para>
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
        public System.String VerifiedAccessEndpointId { get; set; }
        #endregion
        
        #region Parameter VerifiedAccessGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the Verified Access group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VerifiedAccessGroupId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive token that you provide to ensure idempotency of your modification
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VerifiedAccessEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVerifiedAccessEndpointResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyVerifiedAccessEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VerifiedAccessEndpoint";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VerifiedAccessEndpointId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VerifiedAccessEndpointId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VerifiedAccessEndpointId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VerifiedAccessEndpointId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VerifiedAccessEndpoint (ModifyVerifiedAccessEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVerifiedAccessEndpointResponse, EditEC2VerifiedAccessEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VerifiedAccessEndpointId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.CidrOptions_PortRange != null)
            {
                context.CidrOptions_PortRange = new List<Amazon.EC2.Model.ModifyVerifiedAccessEndpointPortRange>(this.CidrOptions_PortRange);
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.LoadBalancerOptions_Port = this.LoadBalancerOptions_Port;
            if (this.LoadBalancerOptions_PortRange != null)
            {
                context.LoadBalancerOptions_PortRange = new List<Amazon.EC2.Model.ModifyVerifiedAccessEndpointPortRange>(this.LoadBalancerOptions_PortRange);
            }
            context.LoadBalancerOptions_Protocol = this.LoadBalancerOptions_Protocol;
            if (this.LoadBalancerOptions_SubnetId != null)
            {
                context.LoadBalancerOptions_SubnetId = new List<System.String>(this.LoadBalancerOptions_SubnetId);
            }
            context.NetworkInterfaceOptions_Port = this.NetworkInterfaceOptions_Port;
            if (this.NetworkInterfaceOptions_PortRange != null)
            {
                context.NetworkInterfaceOptions_PortRange = new List<Amazon.EC2.Model.ModifyVerifiedAccessEndpointPortRange>(this.NetworkInterfaceOptions_PortRange);
            }
            context.NetworkInterfaceOptions_Protocol = this.NetworkInterfaceOptions_Protocol;
            context.RdsOptions_Port = this.RdsOptions_Port;
            context.RdsOptions_RdsEndpoint = this.RdsOptions_RdsEndpoint;
            if (this.RdsOptions_SubnetId != null)
            {
                context.RdsOptions_SubnetId = new List<System.String>(this.RdsOptions_SubnetId);
            }
            context.VerifiedAccessEndpointId = this.VerifiedAccessEndpointId;
            #if MODULAR
            if (this.VerifiedAccessEndpointId == null && ParameterWasBound(nameof(this.VerifiedAccessEndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter VerifiedAccessEndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VerifiedAccessGroupId = this.VerifiedAccessGroupId;
            
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
            var request = new Amazon.EC2.Model.ModifyVerifiedAccessEndpointRequest();
            
            
             // populate CidrOptions
            var requestCidrOptionsIsNull = true;
            request.CidrOptions = new Amazon.EC2.Model.ModifyVerifiedAccessEndpointCidrOptions();
            List<Amazon.EC2.Model.ModifyVerifiedAccessEndpointPortRange> requestCidrOptions_cidrOptions_PortRange = null;
            if (cmdletContext.CidrOptions_PortRange != null)
            {
                requestCidrOptions_cidrOptions_PortRange = cmdletContext.CidrOptions_PortRange;
            }
            if (requestCidrOptions_cidrOptions_PortRange != null)
            {
                request.CidrOptions.PortRanges = requestCidrOptions_cidrOptions_PortRange;
                requestCidrOptionsIsNull = false;
            }
             // determine if request.CidrOptions should be set to null
            if (requestCidrOptionsIsNull)
            {
                request.CidrOptions = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate LoadBalancerOptions
            var requestLoadBalancerOptionsIsNull = true;
            request.LoadBalancerOptions = new Amazon.EC2.Model.ModifyVerifiedAccessEndpointLoadBalancerOptions();
            System.Int32? requestLoadBalancerOptions_loadBalancerOptions_Port = null;
            if (cmdletContext.LoadBalancerOptions_Port != null)
            {
                requestLoadBalancerOptions_loadBalancerOptions_Port = cmdletContext.LoadBalancerOptions_Port.Value;
            }
            if (requestLoadBalancerOptions_loadBalancerOptions_Port != null)
            {
                request.LoadBalancerOptions.Port = requestLoadBalancerOptions_loadBalancerOptions_Port.Value;
                requestLoadBalancerOptionsIsNull = false;
            }
            List<Amazon.EC2.Model.ModifyVerifiedAccessEndpointPortRange> requestLoadBalancerOptions_loadBalancerOptions_PortRange = null;
            if (cmdletContext.LoadBalancerOptions_PortRange != null)
            {
                requestLoadBalancerOptions_loadBalancerOptions_PortRange = cmdletContext.LoadBalancerOptions_PortRange;
            }
            if (requestLoadBalancerOptions_loadBalancerOptions_PortRange != null)
            {
                request.LoadBalancerOptions.PortRanges = requestLoadBalancerOptions_loadBalancerOptions_PortRange;
                requestLoadBalancerOptionsIsNull = false;
            }
            Amazon.EC2.VerifiedAccessEndpointProtocol requestLoadBalancerOptions_loadBalancerOptions_Protocol = null;
            if (cmdletContext.LoadBalancerOptions_Protocol != null)
            {
                requestLoadBalancerOptions_loadBalancerOptions_Protocol = cmdletContext.LoadBalancerOptions_Protocol;
            }
            if (requestLoadBalancerOptions_loadBalancerOptions_Protocol != null)
            {
                request.LoadBalancerOptions.Protocol = requestLoadBalancerOptions_loadBalancerOptions_Protocol;
                requestLoadBalancerOptionsIsNull = false;
            }
            List<System.String> requestLoadBalancerOptions_loadBalancerOptions_SubnetId = null;
            if (cmdletContext.LoadBalancerOptions_SubnetId != null)
            {
                requestLoadBalancerOptions_loadBalancerOptions_SubnetId = cmdletContext.LoadBalancerOptions_SubnetId;
            }
            if (requestLoadBalancerOptions_loadBalancerOptions_SubnetId != null)
            {
                request.LoadBalancerOptions.SubnetIds = requestLoadBalancerOptions_loadBalancerOptions_SubnetId;
                requestLoadBalancerOptionsIsNull = false;
            }
             // determine if request.LoadBalancerOptions should be set to null
            if (requestLoadBalancerOptionsIsNull)
            {
                request.LoadBalancerOptions = null;
            }
            
             // populate NetworkInterfaceOptions
            var requestNetworkInterfaceOptionsIsNull = true;
            request.NetworkInterfaceOptions = new Amazon.EC2.Model.ModifyVerifiedAccessEndpointEniOptions();
            System.Int32? requestNetworkInterfaceOptions_networkInterfaceOptions_Port = null;
            if (cmdletContext.NetworkInterfaceOptions_Port != null)
            {
                requestNetworkInterfaceOptions_networkInterfaceOptions_Port = cmdletContext.NetworkInterfaceOptions_Port.Value;
            }
            if (requestNetworkInterfaceOptions_networkInterfaceOptions_Port != null)
            {
                request.NetworkInterfaceOptions.Port = requestNetworkInterfaceOptions_networkInterfaceOptions_Port.Value;
                requestNetworkInterfaceOptionsIsNull = false;
            }
            List<Amazon.EC2.Model.ModifyVerifiedAccessEndpointPortRange> requestNetworkInterfaceOptions_networkInterfaceOptions_PortRange = null;
            if (cmdletContext.NetworkInterfaceOptions_PortRange != null)
            {
                requestNetworkInterfaceOptions_networkInterfaceOptions_PortRange = cmdletContext.NetworkInterfaceOptions_PortRange;
            }
            if (requestNetworkInterfaceOptions_networkInterfaceOptions_PortRange != null)
            {
                request.NetworkInterfaceOptions.PortRanges = requestNetworkInterfaceOptions_networkInterfaceOptions_PortRange;
                requestNetworkInterfaceOptionsIsNull = false;
            }
            Amazon.EC2.VerifiedAccessEndpointProtocol requestNetworkInterfaceOptions_networkInterfaceOptions_Protocol = null;
            if (cmdletContext.NetworkInterfaceOptions_Protocol != null)
            {
                requestNetworkInterfaceOptions_networkInterfaceOptions_Protocol = cmdletContext.NetworkInterfaceOptions_Protocol;
            }
            if (requestNetworkInterfaceOptions_networkInterfaceOptions_Protocol != null)
            {
                request.NetworkInterfaceOptions.Protocol = requestNetworkInterfaceOptions_networkInterfaceOptions_Protocol;
                requestNetworkInterfaceOptionsIsNull = false;
            }
             // determine if request.NetworkInterfaceOptions should be set to null
            if (requestNetworkInterfaceOptionsIsNull)
            {
                request.NetworkInterfaceOptions = null;
            }
            
             // populate RdsOptions
            var requestRdsOptionsIsNull = true;
            request.RdsOptions = new Amazon.EC2.Model.ModifyVerifiedAccessEndpointRdsOptions();
            System.Int32? requestRdsOptions_rdsOptions_Port = null;
            if (cmdletContext.RdsOptions_Port != null)
            {
                requestRdsOptions_rdsOptions_Port = cmdletContext.RdsOptions_Port.Value;
            }
            if (requestRdsOptions_rdsOptions_Port != null)
            {
                request.RdsOptions.Port = requestRdsOptions_rdsOptions_Port.Value;
                requestRdsOptionsIsNull = false;
            }
            System.String requestRdsOptions_rdsOptions_RdsEndpoint = null;
            if (cmdletContext.RdsOptions_RdsEndpoint != null)
            {
                requestRdsOptions_rdsOptions_RdsEndpoint = cmdletContext.RdsOptions_RdsEndpoint;
            }
            if (requestRdsOptions_rdsOptions_RdsEndpoint != null)
            {
                request.RdsOptions.RdsEndpoint = requestRdsOptions_rdsOptions_RdsEndpoint;
                requestRdsOptionsIsNull = false;
            }
            List<System.String> requestRdsOptions_rdsOptions_SubnetId = null;
            if (cmdletContext.RdsOptions_SubnetId != null)
            {
                requestRdsOptions_rdsOptions_SubnetId = cmdletContext.RdsOptions_SubnetId;
            }
            if (requestRdsOptions_rdsOptions_SubnetId != null)
            {
                request.RdsOptions.SubnetIds = requestRdsOptions_rdsOptions_SubnetId;
                requestRdsOptionsIsNull = false;
            }
             // determine if request.RdsOptions should be set to null
            if (requestRdsOptionsIsNull)
            {
                request.RdsOptions = null;
            }
            if (cmdletContext.VerifiedAccessEndpointId != null)
            {
                request.VerifiedAccessEndpointId = cmdletContext.VerifiedAccessEndpointId;
            }
            if (cmdletContext.VerifiedAccessGroupId != null)
            {
                request.VerifiedAccessGroupId = cmdletContext.VerifiedAccessGroupId;
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
        
        private Amazon.EC2.Model.ModifyVerifiedAccessEndpointResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVerifiedAccessEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVerifiedAccessEndpoint");
            try
            {
                #if DESKTOP
                return client.ModifyVerifiedAccessEndpoint(request);
                #elif CORECLR
                return client.ModifyVerifiedAccessEndpointAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.ModifyVerifiedAccessEndpointPortRange> CidrOptions_PortRange { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.Int32? LoadBalancerOptions_Port { get; set; }
            public List<Amazon.EC2.Model.ModifyVerifiedAccessEndpointPortRange> LoadBalancerOptions_PortRange { get; set; }
            public Amazon.EC2.VerifiedAccessEndpointProtocol LoadBalancerOptions_Protocol { get; set; }
            public List<System.String> LoadBalancerOptions_SubnetId { get; set; }
            public System.Int32? NetworkInterfaceOptions_Port { get; set; }
            public List<Amazon.EC2.Model.ModifyVerifiedAccessEndpointPortRange> NetworkInterfaceOptions_PortRange { get; set; }
            public Amazon.EC2.VerifiedAccessEndpointProtocol NetworkInterfaceOptions_Protocol { get; set; }
            public System.Int32? RdsOptions_Port { get; set; }
            public System.String RdsOptions_RdsEndpoint { get; set; }
            public List<System.String> RdsOptions_SubnetId { get; set; }
            public System.String VerifiedAccessEndpointId { get; set; }
            public System.String VerifiedAccessGroupId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVerifiedAccessEndpointResponse, EditEC2VerifiedAccessEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VerifiedAccessEndpoint;
        }
        
    }
}
