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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates an EC2 Instance Connect Endpoint.
    /// 
    ///  
    /// <para>
    /// An EC2 Instance Connect Endpoint allows you to connect to an instance, without requiring
    /// the instance to have a public IPv4 or public IPv6 address. For more information, see
    /// <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Connect-using-EC2-Instance-Connect-Endpoint.html">Connect
    /// to your instances using EC2 Instance Connect Endpoint</a> in the <i>Amazon EC2 User
    /// Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2InstanceConnectEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Ec2InstanceConnectEndpoint")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateInstanceConnectEndpoint API operation.", Operation = new[] {"CreateInstanceConnectEndpoint"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateInstanceConnectEndpointResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Ec2InstanceConnectEndpoint or Amazon.EC2.Model.CreateInstanceConnectEndpointResponse",
        "This cmdlet returns an Amazon.EC2.Model.Ec2InstanceConnectEndpoint object.",
        "The service call response (type Amazon.EC2.Model.CreateInstanceConnectEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2InstanceConnectEndpointCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address type of the endpoint.</para><para>If no value is specified, the default value is determined by the IP address type of
        /// the subnet:</para><ul><li><para><c>dualstack</c> - If the subnet has both IPv4 and IPv6 CIDRs</para></li><li><para><c>ipv4</c> - If the subnet has only IPv4 CIDRs</para></li><li><para><c>ipv6</c> - If the subnet has only IPv6 CIDRs</para></li></ul><note><para><c>PreserveClientIp</c> is only supported on IPv4 EC2 Instance Connect Endpoints.
        /// To use <c>PreserveClientIp</c>, the value for <c>IpAddressType</c> must be <c>ipv4</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.IpAddressType")]
        public Amazon.EC2.IpAddressType IpAddressType { get; set; }
        #endregion
        
        #region Parameter PreserveClientIp
        /// <summary>
        /// <para>
        /// <para>Indicates whether the client IP address is preserved as the source. The following
        /// are the possible values.</para><ul><li><para><c>true</c> - Use the client IP address as the source.</para></li><li><para><c>false</c> - Use the network interface IP address as the source.</para></li></ul><note><para><c>PreserveClientIp</c> is only supported on IPv4 EC2 Instance Connect Endpoints.
        /// To use <c>PreserveClientIp</c>, the value for <c>IpAddressType</c> must be <c>ipv4</c>.</para></note><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PreserveClientIp { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>One or more security groups to associate with the endpoint. If you don't specify a
        /// security group, the default security group for your VPC will be associated with the
        /// endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet in which to create the EC2 Instance Connect Endpoint.</para>
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
        public System.String SubnetId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the EC2 Instance Connect Endpoint during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceConnectEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateInstanceConnectEndpointResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateInstanceConnectEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceConnectEndpoint";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SubnetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SubnetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SubnetId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubnetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2InstanceConnectEndpoint (CreateInstanceConnectEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateInstanceConnectEndpointResponse, NewEC2InstanceConnectEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SubnetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.IpAddressType = this.IpAddressType;
            context.PreserveClientIp = this.PreserveClientIp;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            context.SubnetId = this.SubnetId;
            #if MODULAR
            if (this.SubnetId == null && ParameterWasBound(nameof(this.SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            
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
            var request = new Amazon.EC2.Model.CreateInstanceConnectEndpointRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.IpAddressType != null)
            {
                request.IpAddressType = cmdletContext.IpAddressType;
            }
            if (cmdletContext.PreserveClientIp != null)
            {
                request.PreserveClientIp = cmdletContext.PreserveClientIp.Value;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreateInstanceConnectEndpointResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateInstanceConnectEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateInstanceConnectEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateInstanceConnectEndpoint(request);
                #elif CORECLR
                return client.CreateInstanceConnectEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Amazon.EC2.IpAddressType IpAddressType { get; set; }
            public System.Boolean? PreserveClientIp { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public System.String SubnetId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateInstanceConnectEndpointResponse, NewEC2InstanceConnectEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceConnectEndpoint;
        }
        
    }
}
