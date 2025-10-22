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
using Amazon.RTBFabric;
using Amazon.RTBFabric.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RTB
{
    /// <summary>
    /// Creates a responder gateway.
    /// </summary>
    [Cmdlet("New", "RTBResponderGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RTBFabric.Model.CreateResponderGatewayResponse")]
    [AWSCmdlet("Calls the Amazon RTBFabric CreateResponderGateway API operation.", Operation = new[] {"CreateResponderGateway"}, SelectReturnType = typeof(Amazon.RTBFabric.Model.CreateResponderGatewayResponse))]
    [AWSCmdletOutput("Amazon.RTBFabric.Model.CreateResponderGatewayResponse",
        "This cmdlet returns an Amazon.RTBFabric.Model.CreateResponderGatewayResponse object containing multiple properties."
    )]
    public partial class NewRTBResponderGatewayCmdlet : AmazonRTBFabricClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutoScalingGroups_AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The names of the auto scaling group.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedEndpointConfiguration_AutoScalingGroups_AutoScalingGroupNames")]
        public System.String[] AutoScalingGroups_AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter TrustStoreConfiguration_CertificateAuthorityCertificate
        /// <summary>
        /// <para>
        /// <para>The certificate authority certificate.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrustStoreConfiguration_CertificateAuthorityCertificates")]
        public System.String[] TrustStoreConfiguration_CertificateAuthorityCertificate { get; set; }
        #endregion
        
        #region Parameter EksEndpoints_ClusterApiServerCaCertificateChain
        /// <summary>
        /// <para>
        /// <para>The CA certificate chain of the cluster API server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedEndpointConfiguration_EksEndpoints_ClusterApiServerCaCertificateChain")]
        public System.String EksEndpoints_ClusterApiServerCaCertificateChain { get; set; }
        #endregion
        
        #region Parameter EksEndpoints_ClusterApiServerEndpointUri
        /// <summary>
        /// <para>
        /// <para>The URI of the cluster API server endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedEndpointConfiguration_EksEndpoints_ClusterApiServerEndpointUri")]
        public System.String EksEndpoints_ClusterApiServerEndpointUri { get; set; }
        #endregion
        
        #region Parameter EksEndpoints_ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedEndpointConfiguration_EksEndpoints_ClusterName")]
        public System.String EksEndpoints_ClusterName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description for the responder gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The domain name for the responder gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter EksEndpoints_EndpointsResourceName
        /// <summary>
        /// <para>
        /// <para>The name of the endpoint resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedEndpointConfiguration_EksEndpoints_EndpointsResourceName")]
        public System.String EksEndpoints_EndpointsResourceName { get; set; }
        #endregion
        
        #region Parameter EksEndpoints_EndpointsResourceNamespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the endpoint resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedEndpointConfiguration_EksEndpoints_EndpointsResourceNamespace")]
        public System.String EksEndpoints_EndpointsResourceNamespace { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The networking port to use.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The networking protocol to use.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.RTBFabric.Protocol")]
        public Amazon.RTBFabric.Protocol Protocol { get; set; }
        #endregion
        
        #region Parameter AutoScalingGroups_RoleArn
        /// <summary>
        /// <para>
        /// <para>The role ARN of the auto scaling group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedEndpointConfiguration_AutoScalingGroups_RoleArn")]
        public System.String AutoScalingGroups_RoleArn { get; set; }
        #endregion
        
        #region Parameter EksEndpoints_RoleArn
        /// <summary>
        /// <para>
        /// <para>The role ARN for the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedEndpointConfiguration_EksEndpoints_RoleArn")]
        public System.String EksEndpoints_RoleArn { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The unique identifiers of the security groups.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The unique identifiers of the subnets.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of the key-value pairs of the tag or tags to assign to the resource.</para><para />
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
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Virtual Private Cloud (VPC).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String VpcId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The unique client token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RTBFabric.Model.CreateResponderGatewayResponse).
        /// Specifying the name of a property of type Amazon.RTBFabric.Model.CreateResponderGatewayResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RTBResponderGateway (CreateResponderGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RTBFabric.Model.CreateResponderGatewayResponse, NewRTBResponderGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DomainName = this.DomainName;
            if (this.AutoScalingGroups_AutoScalingGroupName != null)
            {
                context.AutoScalingGroups_AutoScalingGroupName = new List<System.String>(this.AutoScalingGroups_AutoScalingGroupName);
            }
            context.AutoScalingGroups_RoleArn = this.AutoScalingGroups_RoleArn;
            context.EksEndpoints_ClusterApiServerCaCertificateChain = this.EksEndpoints_ClusterApiServerCaCertificateChain;
            context.EksEndpoints_ClusterApiServerEndpointUri = this.EksEndpoints_ClusterApiServerEndpointUri;
            context.EksEndpoints_ClusterName = this.EksEndpoints_ClusterName;
            context.EksEndpoints_EndpointsResourceName = this.EksEndpoints_EndpointsResourceName;
            context.EksEndpoints_EndpointsResourceNamespace = this.EksEndpoints_EndpointsResourceNamespace;
            context.EksEndpoints_RoleArn = this.EksEndpoints_RoleArn;
            context.Port = this.Port;
            #if MODULAR
            if (this.Port == null && ParameterWasBound(nameof(this.Port)))
            {
                WriteWarning("You are passing $null as a value for parameter Port which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Protocol = this.Protocol;
            #if MODULAR
            if (this.Protocol == null && ParameterWasBound(nameof(this.Protocol)))
            {
                WriteWarning("You are passing $null as a value for parameter Protocol which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            #if MODULAR
            if (this.SecurityGroupId == null && ParameterWasBound(nameof(this.SecurityGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecurityGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            #if MODULAR
            if (this.SubnetId == null && ParameterWasBound(nameof(this.SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            if (this.TrustStoreConfiguration_CertificateAuthorityCertificate != null)
            {
                context.TrustStoreConfiguration_CertificateAuthorityCertificate = new List<System.String>(this.TrustStoreConfiguration_CertificateAuthorityCertificate);
            }
            context.VpcId = this.VpcId;
            #if MODULAR
            if (this.VpcId == null && ParameterWasBound(nameof(this.VpcId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RTBFabric.Model.CreateResponderGatewayRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate ManagedEndpointConfiguration
            var requestManagedEndpointConfigurationIsNull = true;
            request.ManagedEndpointConfiguration = new Amazon.RTBFabric.Model.ManagedEndpointConfiguration();
            Amazon.RTBFabric.Model.AutoScalingGroupsConfiguration requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups = null;
            
             // populate AutoScalingGroups
            var requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroupsIsNull = true;
            requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups = new Amazon.RTBFabric.Model.AutoScalingGroupsConfiguration();
            List<System.String> requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups_autoScalingGroups_AutoScalingGroupName = null;
            if (cmdletContext.AutoScalingGroups_AutoScalingGroupName != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups_autoScalingGroups_AutoScalingGroupName = cmdletContext.AutoScalingGroups_AutoScalingGroupName;
            }
            if (requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups_autoScalingGroups_AutoScalingGroupName != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups.AutoScalingGroupNames = requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups_autoScalingGroups_AutoScalingGroupName;
                requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroupsIsNull = false;
            }
            System.String requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups_autoScalingGroups_RoleArn = null;
            if (cmdletContext.AutoScalingGroups_RoleArn != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups_autoScalingGroups_RoleArn = cmdletContext.AutoScalingGroups_RoleArn;
            }
            if (requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups_autoScalingGroups_RoleArn != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups.RoleArn = requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups_autoScalingGroups_RoleArn;
                requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroupsIsNull = false;
            }
             // determine if requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups should be set to null
            if (requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroupsIsNull)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups = null;
            }
            if (requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups != null)
            {
                request.ManagedEndpointConfiguration.AutoScalingGroups = requestManagedEndpointConfiguration_managedEndpointConfiguration_AutoScalingGroups;
                requestManagedEndpointConfigurationIsNull = false;
            }
            Amazon.RTBFabric.Model.EksEndpointsConfiguration requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints = null;
            
             // populate EksEndpoints
            var requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpointsIsNull = true;
            requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints = new Amazon.RTBFabric.Model.EksEndpointsConfiguration();
            System.String requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_ClusterApiServerCaCertificateChain = null;
            if (cmdletContext.EksEndpoints_ClusterApiServerCaCertificateChain != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_ClusterApiServerCaCertificateChain = cmdletContext.EksEndpoints_ClusterApiServerCaCertificateChain;
            }
            if (requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_ClusterApiServerCaCertificateChain != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints.ClusterApiServerCaCertificateChain = requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_ClusterApiServerCaCertificateChain;
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpointsIsNull = false;
            }
            System.String requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_ClusterApiServerEndpointUri = null;
            if (cmdletContext.EksEndpoints_ClusterApiServerEndpointUri != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_ClusterApiServerEndpointUri = cmdletContext.EksEndpoints_ClusterApiServerEndpointUri;
            }
            if (requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_ClusterApiServerEndpointUri != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints.ClusterApiServerEndpointUri = requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_ClusterApiServerEndpointUri;
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpointsIsNull = false;
            }
            System.String requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_ClusterName = null;
            if (cmdletContext.EksEndpoints_ClusterName != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_ClusterName = cmdletContext.EksEndpoints_ClusterName;
            }
            if (requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_ClusterName != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints.ClusterName = requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_ClusterName;
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpointsIsNull = false;
            }
            System.String requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_EndpointsResourceName = null;
            if (cmdletContext.EksEndpoints_EndpointsResourceName != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_EndpointsResourceName = cmdletContext.EksEndpoints_EndpointsResourceName;
            }
            if (requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_EndpointsResourceName != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints.EndpointsResourceName = requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_EndpointsResourceName;
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpointsIsNull = false;
            }
            System.String requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_EndpointsResourceNamespace = null;
            if (cmdletContext.EksEndpoints_EndpointsResourceNamespace != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_EndpointsResourceNamespace = cmdletContext.EksEndpoints_EndpointsResourceNamespace;
            }
            if (requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_EndpointsResourceNamespace != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints.EndpointsResourceNamespace = requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_EndpointsResourceNamespace;
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpointsIsNull = false;
            }
            System.String requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_RoleArn = null;
            if (cmdletContext.EksEndpoints_RoleArn != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_RoleArn = cmdletContext.EksEndpoints_RoleArn;
            }
            if (requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_RoleArn != null)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints.RoleArn = requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints_eksEndpoints_RoleArn;
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpointsIsNull = false;
            }
             // determine if requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints should be set to null
            if (requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpointsIsNull)
            {
                requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints = null;
            }
            if (requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints != null)
            {
                request.ManagedEndpointConfiguration.EksEndpoints = requestManagedEndpointConfiguration_managedEndpointConfiguration_EksEndpoints;
                requestManagedEndpointConfigurationIsNull = false;
            }
             // determine if request.ManagedEndpointConfiguration should be set to null
            if (requestManagedEndpointConfigurationIsNull)
            {
                request.ManagedEndpointConfiguration = null;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TrustStoreConfiguration
            var requestTrustStoreConfigurationIsNull = true;
            request.TrustStoreConfiguration = new Amazon.RTBFabric.Model.TrustStoreConfiguration();
            List<System.String> requestTrustStoreConfiguration_trustStoreConfiguration_CertificateAuthorityCertificate = null;
            if (cmdletContext.TrustStoreConfiguration_CertificateAuthorityCertificate != null)
            {
                requestTrustStoreConfiguration_trustStoreConfiguration_CertificateAuthorityCertificate = cmdletContext.TrustStoreConfiguration_CertificateAuthorityCertificate;
            }
            if (requestTrustStoreConfiguration_trustStoreConfiguration_CertificateAuthorityCertificate != null)
            {
                request.TrustStoreConfiguration.CertificateAuthorityCertificates = requestTrustStoreConfiguration_trustStoreConfiguration_CertificateAuthorityCertificate;
                requestTrustStoreConfigurationIsNull = false;
            }
             // determine if request.TrustStoreConfiguration should be set to null
            if (requestTrustStoreConfigurationIsNull)
            {
                request.TrustStoreConfiguration = null;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
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
        
        private Amazon.RTBFabric.Model.CreateResponderGatewayResponse CallAWSServiceOperation(IAmazonRTBFabric client, Amazon.RTBFabric.Model.CreateResponderGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon RTBFabric", "CreateResponderGateway");
            try
            {
                return client.CreateResponderGatewayAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String DomainName { get; set; }
            public List<System.String> AutoScalingGroups_AutoScalingGroupName { get; set; }
            public System.String AutoScalingGroups_RoleArn { get; set; }
            public System.String EksEndpoints_ClusterApiServerCaCertificateChain { get; set; }
            public System.String EksEndpoints_ClusterApiServerEndpointUri { get; set; }
            public System.String EksEndpoints_ClusterName { get; set; }
            public System.String EksEndpoints_EndpointsResourceName { get; set; }
            public System.String EksEndpoints_EndpointsResourceNamespace { get; set; }
            public System.String EksEndpoints_RoleArn { get; set; }
            public System.Int32? Port { get; set; }
            public Amazon.RTBFabric.Protocol Protocol { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public List<System.String> SubnetId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<System.String> TrustStoreConfiguration_CertificateAuthorityCertificate { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.RTBFabric.Model.CreateResponderGatewayResponse, NewRTBResponderGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
