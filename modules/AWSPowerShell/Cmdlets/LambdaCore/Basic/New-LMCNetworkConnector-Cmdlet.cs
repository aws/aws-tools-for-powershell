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
using Amazon.LambdaCore;
using Amazon.LambdaCore.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LMC
{
    /// <summary>
    /// Creates a network connector that enables Lambda compute resources to route outbound
    /// traffic through your Amazon VPC. The network connector provisions elastic network
    /// interfaces (ENIs) in the subnets you specify, providing a managed network path to
    /// private resources such as databases, caches, and internal APIs.
    /// 
    ///  
    /// <para>
    /// This operation is asynchronous. The network connector starts in <c>PENDING</c> state
    /// while ENIs are provisioned in your VPC (provisioning typically takes up to 10 minutes).
    /// Use <c>GetNetworkConnector</c> to poll the connector state until it reaches <c>ACTIVE</c>.
    /// Once active, you can attach the connector to Lambda MicroVMs at run time using the
    /// <c>egressNetworkConnectors</c> parameter on <c>RunMicroVm</c>.
    /// </para><para>
    /// This operation is idempotent when you provide a <c>ClientToken</c> — if you retry
    /// a request that completed successfully using the same client token, the operation returns
    /// the existing connector without creating a duplicate.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LMCNetworkConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LambdaCore.Model.CreateNetworkConnectorResponse")]
    [AWSCmdlet("Calls the AWS Lambda Core CreateNetworkConnector API operation.", Operation = new[] {"CreateNetworkConnector"}, SelectReturnType = typeof(Amazon.LambdaCore.Model.CreateNetworkConnectorResponse))]
    [AWSCmdletOutput("Amazon.LambdaCore.Model.CreateNetworkConnectorResponse",
        "This cmdlet returns an Amazon.LambdaCore.Model.CreateNetworkConnectorResponse object containing multiple properties."
    )]
    public partial class NewLMCNetworkConnectorCmdlet : AmazonLambdaCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Configuration_VpcEgressConfiguration_AssociatedComputeResourceType
        /// <summary>
        /// <para>
        /// <para>The types of Lambda compute resources that can use this connector. Currently, only
        /// <c>MicroVm</c> is supported.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_VpcEgressConfiguration_AssociatedComputeResourceTypes")]
        public System.String[] Configuration_VpcEgressConfiguration_AssociatedComputeResourceType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A unique name for the network connector within your account and Region. You can use
        /// the name to identify the connector in subsequent API calls.</para>
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
        
        #region Parameter Configuration_VpcEgressConfiguration_NetworkProtocol
        /// <summary>
        /// <para>
        /// <para>The network protocol for the connector. Specify <c>IPv4</c> for IPv4-only networking,
        /// or <c>DualStack</c> for both IPv4 and IPv6.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaCore.NetworkProtocol")]
        public Amazon.LambdaCore.NetworkProtocol Configuration_VpcEgressConfiguration_NetworkProtocol { get; set; }
        #endregion
        
        #region Parameter OperatorRole
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that Lambda assumes to manage elastic network interfaces in
        /// your VPC. This role must have permissions for <c>ec2:CreateNetworkInterface</c>, <c>ec2:DeleteNetworkInterface</c>,
        /// and related describe operations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperatorRole { get; set; }
        #endregion
        
        #region Parameter Configuration_VpcEgressConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The IDs of the VPC security groups to attach to the ENIs. Specify 0 to 5 security
        /// groups. All security groups must be in the same VPC as the subnets.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_VpcEgressConfiguration_SecurityGroupIds")]
        public System.String[] Configuration_VpcEgressConfiguration_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Configuration_VpcEgressConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>The IDs of the VPC subnets where Lambda provisions elastic network interfaces (ENIs).
        /// Specify 1 to 16 subnets. All subnets must be in the same VPC.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_VpcEgressConfiguration_SubnetIds")]
        public System.String[] Configuration_VpcEgressConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of key-value pairs to associate with the network connector for organization,
        /// cost allocation, or access control.</para><para />
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you retry a request with the same client token, the API returns the
        /// existing connector without creating a duplicate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LambdaCore.Model.CreateNetworkConnectorResponse).
        /// Specifying the name of a property of type Amazon.LambdaCore.Model.CreateNetworkConnectorResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LMCNetworkConnector (CreateNetworkConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LambdaCore.Model.CreateNetworkConnectorResponse, NewLMCNetworkConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.Configuration_VpcEgressConfiguration_AssociatedComputeResourceType != null)
            {
                context.Configuration_VpcEgressConfiguration_AssociatedComputeResourceType = new List<System.String>(this.Configuration_VpcEgressConfiguration_AssociatedComputeResourceType);
            }
            context.Configuration_VpcEgressConfiguration_NetworkProtocol = this.Configuration_VpcEgressConfiguration_NetworkProtocol;
            if (this.Configuration_VpcEgressConfiguration_SecurityGroupId != null)
            {
                context.Configuration_VpcEgressConfiguration_SecurityGroupId = new List<System.String>(this.Configuration_VpcEgressConfiguration_SecurityGroupId);
            }
            if (this.Configuration_VpcEgressConfiguration_SubnetId != null)
            {
                context.Configuration_VpcEgressConfiguration_SubnetId = new List<System.String>(this.Configuration_VpcEgressConfiguration_SubnetId);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OperatorRole = this.OperatorRole;
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
            var request = new Amazon.LambdaCore.Model.CreateNetworkConnectorRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.LambdaCore.Model.NetworkConnectorConfiguration();
            Amazon.LambdaCore.Model.NetworkConnectorVpcEgressConfiguration requestConfiguration_configuration_VpcEgressConfiguration = null;
            
             // populate VpcEgressConfiguration
            var requestConfiguration_configuration_VpcEgressConfigurationIsNull = true;
            requestConfiguration_configuration_VpcEgressConfiguration = new Amazon.LambdaCore.Model.NetworkConnectorVpcEgressConfiguration();
            List<System.String> requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_AssociatedComputeResourceType = null;
            if (cmdletContext.Configuration_VpcEgressConfiguration_AssociatedComputeResourceType != null)
            {
                requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_AssociatedComputeResourceType = cmdletContext.Configuration_VpcEgressConfiguration_AssociatedComputeResourceType;
            }
            if (requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_AssociatedComputeResourceType != null)
            {
                requestConfiguration_configuration_VpcEgressConfiguration.AssociatedComputeResourceTypes = requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_AssociatedComputeResourceType;
                requestConfiguration_configuration_VpcEgressConfigurationIsNull = false;
            }
            Amazon.LambdaCore.NetworkProtocol requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_NetworkProtocol = null;
            if (cmdletContext.Configuration_VpcEgressConfiguration_NetworkProtocol != null)
            {
                requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_NetworkProtocol = cmdletContext.Configuration_VpcEgressConfiguration_NetworkProtocol;
            }
            if (requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_NetworkProtocol != null)
            {
                requestConfiguration_configuration_VpcEgressConfiguration.NetworkProtocol = requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_NetworkProtocol;
                requestConfiguration_configuration_VpcEgressConfigurationIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_SecurityGroupId = null;
            if (cmdletContext.Configuration_VpcEgressConfiguration_SecurityGroupId != null)
            {
                requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_SecurityGroupId = cmdletContext.Configuration_VpcEgressConfiguration_SecurityGroupId;
            }
            if (requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_SecurityGroupId != null)
            {
                requestConfiguration_configuration_VpcEgressConfiguration.SecurityGroupIds = requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_SecurityGroupId;
                requestConfiguration_configuration_VpcEgressConfigurationIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_SubnetId = null;
            if (cmdletContext.Configuration_VpcEgressConfiguration_SubnetId != null)
            {
                requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_SubnetId = cmdletContext.Configuration_VpcEgressConfiguration_SubnetId;
            }
            if (requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_SubnetId != null)
            {
                requestConfiguration_configuration_VpcEgressConfiguration.SubnetIds = requestConfiguration_configuration_VpcEgressConfiguration_configuration_VpcEgressConfiguration_SubnetId;
                requestConfiguration_configuration_VpcEgressConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_VpcEgressConfiguration should be set to null
            if (requestConfiguration_configuration_VpcEgressConfigurationIsNull)
            {
                requestConfiguration_configuration_VpcEgressConfiguration = null;
            }
            if (requestConfiguration_configuration_VpcEgressConfiguration != null)
            {
                request.Configuration.VpcEgressConfiguration = requestConfiguration_configuration_VpcEgressConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OperatorRole != null)
            {
                request.OperatorRole = cmdletContext.OperatorRole;
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
        
        private Amazon.LambdaCore.Model.CreateNetworkConnectorResponse CallAWSServiceOperation(IAmazonLambdaCore client, Amazon.LambdaCore.Model.CreateNetworkConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda Core", "CreateNetworkConnector");
            try
            {
                return client.CreateNetworkConnectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Configuration_VpcEgressConfiguration_AssociatedComputeResourceType { get; set; }
            public Amazon.LambdaCore.NetworkProtocol Configuration_VpcEgressConfiguration_NetworkProtocol { get; set; }
            public List<System.String> Configuration_VpcEgressConfiguration_SecurityGroupId { get; set; }
            public List<System.String> Configuration_VpcEgressConfiguration_SubnetId { get; set; }
            public System.String Name { get; set; }
            public System.String OperatorRole { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.LambdaCore.Model.CreateNetworkConnectorResponse, NewLMCNetworkConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
