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
using Amazon.DevOpsAgent;
using Amazon.DevOpsAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOPS
{
    /// <summary>
    /// Creates a Private Connection to a target resource.
    /// </summary>
    [Cmdlet("New", "DOPSPrivateConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DevOpsAgent.Model.CreatePrivateConnectionResponse")]
    [AWSCmdlet("Calls the AWS DevOps Agent Service CreatePrivateConnection API operation.", Operation = new[] {"CreatePrivateConnection"}, SelectReturnType = typeof(Amazon.DevOpsAgent.Model.CreatePrivateConnectionResponse))]
    [AWSCmdletOutput("Amazon.DevOpsAgent.Model.CreatePrivateConnectionResponse",
        "This cmdlet returns an Amazon.DevOpsAgent.Model.CreatePrivateConnectionResponse object containing multiple properties."
    )]
    public partial class NewDOPSPrivateConnectionCmdlet : AmazonDevOpsAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Mode_SelfManaged_Certificate
        /// <summary>
        /// <para>
        /// <para>Certificate for the Private Connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Mode_SelfManaged_Certificate { get; set; }
        #endregion
        
        #region Parameter Mode_ServiceManaged_Certificate
        /// <summary>
        /// <para>
        /// <para>Certificate for the Private Connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Mode_ServiceManaged_Certificate { get; set; }
        #endregion
        
        #region Parameter Mode_ServiceManaged_HostAddress
        /// <summary>
        /// <para>
        /// <para>IP address or DNS name of the target resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Mode_ServiceManaged_HostAddress { get; set; }
        #endregion
        
        #region Parameter Mode_ServiceManaged_IpAddressType
        /// <summary>
        /// <para>
        /// <para>IP address type of the service-managed Resource Gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DevOpsAgent.IpAddressType")]
        public Amazon.DevOpsAgent.IpAddressType Mode_ServiceManaged_IpAddressType { get; set; }
        #endregion
        
        #region Parameter Mode_ServiceManaged_Ipv4AddressesPerEni
        /// <summary>
        /// <para>
        /// <para>Number of IPv4 addresses in each ENI for the service-managed Resource Gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Mode_ServiceManaged_Ipv4AddressesPerEni { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Unique name for this Private Connection within the account.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Mode_ServiceManaged_PortRange
        /// <summary>
        /// <para>
        /// <para>TCP port ranges that a consumer can use to access the resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Mode_ServiceManaged_PortRanges")]
        public System.String[] Mode_ServiceManaged_PortRange { get; set; }
        #endregion
        
        #region Parameter Mode_SelfManaged_ResourceConfigurationId
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the resource configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Mode_SelfManaged_ResourceConfigurationId { get; set; }
        #endregion
        
        #region Parameter Mode_ServiceManaged_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>Security groups to attach to the service-managed Resource Gateway. If not specified,
        /// a default security group is created.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Mode_ServiceManaged_SecurityGroupIds")]
        public System.String[] Mode_ServiceManaged_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Mode_ServiceManaged_SubnetId
        /// <summary>
        /// <para>
        /// <para>Subnets that the service-managed Resource Gateway will span.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Mode_ServiceManaged_SubnetIds")]
        public System.String[] Mode_ServiceManaged_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to add to the Private Connection at creation time.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Mode_ServiceManaged_VpcId
        /// <summary>
        /// <para>
        /// <para>VPC to create the service-managed Resource Gateway in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Mode_ServiceManaged_VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsAgent.Model.CreatePrivateConnectionResponse).
        /// Specifying the name of a property of type Amazon.DevOpsAgent.Model.CreatePrivateConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DOPSPrivateConnection (CreatePrivateConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsAgent.Model.CreatePrivateConnectionResponse, NewDOPSPrivateConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Mode_SelfManaged_Certificate = this.Mode_SelfManaged_Certificate;
            context.Mode_SelfManaged_ResourceConfigurationId = this.Mode_SelfManaged_ResourceConfigurationId;
            context.Mode_ServiceManaged_Certificate = this.Mode_ServiceManaged_Certificate;
            context.Mode_ServiceManaged_HostAddress = this.Mode_ServiceManaged_HostAddress;
            context.Mode_ServiceManaged_IpAddressType = this.Mode_ServiceManaged_IpAddressType;
            context.Mode_ServiceManaged_Ipv4AddressesPerEni = this.Mode_ServiceManaged_Ipv4AddressesPerEni;
            if (this.Mode_ServiceManaged_PortRange != null)
            {
                context.Mode_ServiceManaged_PortRange = new List<System.String>(this.Mode_ServiceManaged_PortRange);
            }
            if (this.Mode_ServiceManaged_SecurityGroupId != null)
            {
                context.Mode_ServiceManaged_SecurityGroupId = new List<System.String>(this.Mode_ServiceManaged_SecurityGroupId);
            }
            if (this.Mode_ServiceManaged_SubnetId != null)
            {
                context.Mode_ServiceManaged_SubnetId = new List<System.String>(this.Mode_ServiceManaged_SubnetId);
            }
            context.Mode_ServiceManaged_VpcId = this.Mode_ServiceManaged_VpcId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.DevOpsAgent.Model.CreatePrivateConnectionRequest();
            
            
             // populate Mode
            var requestModeIsNull = true;
            request.Mode = new Amazon.DevOpsAgent.Model.PrivateConnectionMode();
            Amazon.DevOpsAgent.Model.SelfManagedInput requestMode_mode_SelfManaged = null;
            
             // populate SelfManaged
            var requestMode_mode_SelfManagedIsNull = true;
            requestMode_mode_SelfManaged = new Amazon.DevOpsAgent.Model.SelfManagedInput();
            System.String requestMode_mode_SelfManaged_mode_SelfManaged_Certificate = null;
            if (cmdletContext.Mode_SelfManaged_Certificate != null)
            {
                requestMode_mode_SelfManaged_mode_SelfManaged_Certificate = cmdletContext.Mode_SelfManaged_Certificate;
            }
            if (requestMode_mode_SelfManaged_mode_SelfManaged_Certificate != null)
            {
                requestMode_mode_SelfManaged.Certificate = requestMode_mode_SelfManaged_mode_SelfManaged_Certificate;
                requestMode_mode_SelfManagedIsNull = false;
            }
            System.String requestMode_mode_SelfManaged_mode_SelfManaged_ResourceConfigurationId = null;
            if (cmdletContext.Mode_SelfManaged_ResourceConfigurationId != null)
            {
                requestMode_mode_SelfManaged_mode_SelfManaged_ResourceConfigurationId = cmdletContext.Mode_SelfManaged_ResourceConfigurationId;
            }
            if (requestMode_mode_SelfManaged_mode_SelfManaged_ResourceConfigurationId != null)
            {
                requestMode_mode_SelfManaged.ResourceConfigurationId = requestMode_mode_SelfManaged_mode_SelfManaged_ResourceConfigurationId;
                requestMode_mode_SelfManagedIsNull = false;
            }
             // determine if requestMode_mode_SelfManaged should be set to null
            if (requestMode_mode_SelfManagedIsNull)
            {
                requestMode_mode_SelfManaged = null;
            }
            if (requestMode_mode_SelfManaged != null)
            {
                request.Mode.SelfManaged = requestMode_mode_SelfManaged;
                requestModeIsNull = false;
            }
            Amazon.DevOpsAgent.Model.ServiceManagedInput requestMode_mode_ServiceManaged = null;
            
             // populate ServiceManaged
            var requestMode_mode_ServiceManagedIsNull = true;
            requestMode_mode_ServiceManaged = new Amazon.DevOpsAgent.Model.ServiceManagedInput();
            System.String requestMode_mode_ServiceManaged_mode_ServiceManaged_Certificate = null;
            if (cmdletContext.Mode_ServiceManaged_Certificate != null)
            {
                requestMode_mode_ServiceManaged_mode_ServiceManaged_Certificate = cmdletContext.Mode_ServiceManaged_Certificate;
            }
            if (requestMode_mode_ServiceManaged_mode_ServiceManaged_Certificate != null)
            {
                requestMode_mode_ServiceManaged.Certificate = requestMode_mode_ServiceManaged_mode_ServiceManaged_Certificate;
                requestMode_mode_ServiceManagedIsNull = false;
            }
            System.String requestMode_mode_ServiceManaged_mode_ServiceManaged_HostAddress = null;
            if (cmdletContext.Mode_ServiceManaged_HostAddress != null)
            {
                requestMode_mode_ServiceManaged_mode_ServiceManaged_HostAddress = cmdletContext.Mode_ServiceManaged_HostAddress;
            }
            if (requestMode_mode_ServiceManaged_mode_ServiceManaged_HostAddress != null)
            {
                requestMode_mode_ServiceManaged.HostAddress = requestMode_mode_ServiceManaged_mode_ServiceManaged_HostAddress;
                requestMode_mode_ServiceManagedIsNull = false;
            }
            Amazon.DevOpsAgent.IpAddressType requestMode_mode_ServiceManaged_mode_ServiceManaged_IpAddressType = null;
            if (cmdletContext.Mode_ServiceManaged_IpAddressType != null)
            {
                requestMode_mode_ServiceManaged_mode_ServiceManaged_IpAddressType = cmdletContext.Mode_ServiceManaged_IpAddressType;
            }
            if (requestMode_mode_ServiceManaged_mode_ServiceManaged_IpAddressType != null)
            {
                requestMode_mode_ServiceManaged.IpAddressType = requestMode_mode_ServiceManaged_mode_ServiceManaged_IpAddressType;
                requestMode_mode_ServiceManagedIsNull = false;
            }
            System.Int32? requestMode_mode_ServiceManaged_mode_ServiceManaged_Ipv4AddressesPerEni = null;
            if (cmdletContext.Mode_ServiceManaged_Ipv4AddressesPerEni != null)
            {
                requestMode_mode_ServiceManaged_mode_ServiceManaged_Ipv4AddressesPerEni = cmdletContext.Mode_ServiceManaged_Ipv4AddressesPerEni.Value;
            }
            if (requestMode_mode_ServiceManaged_mode_ServiceManaged_Ipv4AddressesPerEni != null)
            {
                requestMode_mode_ServiceManaged.Ipv4AddressesPerEni = requestMode_mode_ServiceManaged_mode_ServiceManaged_Ipv4AddressesPerEni.Value;
                requestMode_mode_ServiceManagedIsNull = false;
            }
            List<System.String> requestMode_mode_ServiceManaged_mode_ServiceManaged_PortRange = null;
            if (cmdletContext.Mode_ServiceManaged_PortRange != null)
            {
                requestMode_mode_ServiceManaged_mode_ServiceManaged_PortRange = cmdletContext.Mode_ServiceManaged_PortRange;
            }
            if (requestMode_mode_ServiceManaged_mode_ServiceManaged_PortRange != null)
            {
                requestMode_mode_ServiceManaged.PortRanges = requestMode_mode_ServiceManaged_mode_ServiceManaged_PortRange;
                requestMode_mode_ServiceManagedIsNull = false;
            }
            List<System.String> requestMode_mode_ServiceManaged_mode_ServiceManaged_SecurityGroupId = null;
            if (cmdletContext.Mode_ServiceManaged_SecurityGroupId != null)
            {
                requestMode_mode_ServiceManaged_mode_ServiceManaged_SecurityGroupId = cmdletContext.Mode_ServiceManaged_SecurityGroupId;
            }
            if (requestMode_mode_ServiceManaged_mode_ServiceManaged_SecurityGroupId != null)
            {
                requestMode_mode_ServiceManaged.SecurityGroupIds = requestMode_mode_ServiceManaged_mode_ServiceManaged_SecurityGroupId;
                requestMode_mode_ServiceManagedIsNull = false;
            }
            List<System.String> requestMode_mode_ServiceManaged_mode_ServiceManaged_SubnetId = null;
            if (cmdletContext.Mode_ServiceManaged_SubnetId != null)
            {
                requestMode_mode_ServiceManaged_mode_ServiceManaged_SubnetId = cmdletContext.Mode_ServiceManaged_SubnetId;
            }
            if (requestMode_mode_ServiceManaged_mode_ServiceManaged_SubnetId != null)
            {
                requestMode_mode_ServiceManaged.SubnetIds = requestMode_mode_ServiceManaged_mode_ServiceManaged_SubnetId;
                requestMode_mode_ServiceManagedIsNull = false;
            }
            System.String requestMode_mode_ServiceManaged_mode_ServiceManaged_VpcId = null;
            if (cmdletContext.Mode_ServiceManaged_VpcId != null)
            {
                requestMode_mode_ServiceManaged_mode_ServiceManaged_VpcId = cmdletContext.Mode_ServiceManaged_VpcId;
            }
            if (requestMode_mode_ServiceManaged_mode_ServiceManaged_VpcId != null)
            {
                requestMode_mode_ServiceManaged.VpcId = requestMode_mode_ServiceManaged_mode_ServiceManaged_VpcId;
                requestMode_mode_ServiceManagedIsNull = false;
            }
             // determine if requestMode_mode_ServiceManaged should be set to null
            if (requestMode_mode_ServiceManagedIsNull)
            {
                requestMode_mode_ServiceManaged = null;
            }
            if (requestMode_mode_ServiceManaged != null)
            {
                request.Mode.ServiceManaged = requestMode_mode_ServiceManaged;
                requestModeIsNull = false;
            }
             // determine if request.Mode should be set to null
            if (requestModeIsNull)
            {
                request.Mode = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.DevOpsAgent.Model.CreatePrivateConnectionResponse CallAWSServiceOperation(IAmazonDevOpsAgent client, Amazon.DevOpsAgent.Model.CreatePrivateConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DevOps Agent Service", "CreatePrivateConnection");
            try
            {
                return client.CreatePrivateConnectionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Mode_SelfManaged_Certificate { get; set; }
            public System.String Mode_SelfManaged_ResourceConfigurationId { get; set; }
            public System.String Mode_ServiceManaged_Certificate { get; set; }
            public System.String Mode_ServiceManaged_HostAddress { get; set; }
            public Amazon.DevOpsAgent.IpAddressType Mode_ServiceManaged_IpAddressType { get; set; }
            public System.Int32? Mode_ServiceManaged_Ipv4AddressesPerEni { get; set; }
            public List<System.String> Mode_ServiceManaged_PortRange { get; set; }
            public List<System.String> Mode_ServiceManaged_SecurityGroupId { get; set; }
            public List<System.String> Mode_ServiceManaged_SubnetId { get; set; }
            public System.String Mode_ServiceManaged_VpcId { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.DevOpsAgent.Model.CreatePrivateConnectionResponse, NewDOPSPrivateConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
