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
using Amazon.AgentRegistryControl;
using Amazon.AgentRegistryControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AGRC
{
    /// <summary>
    /// Updates an existing registry. This operation uses PATCH semantics: specify only the
    /// fields you want to change, and omit the rest to leave them unchanged. Updates are
    /// applied asynchronously and the registry transitions to the UPDATING status while they
    /// are processed.
    /// </summary>
    [Cmdlet("Update", "AGRCRegistry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AgentRegistryControl.Model.UpdateRegistryResponse")]
    [AWSCmdlet("Calls the Agent Registry Control UpdateRegistry API operation.", Operation = new[] {"UpdateRegistry"}, SelectReturnType = typeof(Amazon.AgentRegistryControl.Model.UpdateRegistryResponse))]
    [AWSCmdletOutput("Amazon.AgentRegistryControl.Model.UpdateRegistryResponse",
        "This cmdlet returns an Amazon.AgentRegistryControl.Model.UpdateRegistryResponse object containing multiple properties."
    )]
    public partial class UpdateAGRCRegistryCmdlet : AmazonAgentRegistryControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience
        /// <summary>
        /// <para>
        /// <para>The audience values accepted during JWT validation. A token is rejected if none of
        /// its audience claims match.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience { get; set; }
        #endregion
        
        #region Parameter DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient
        /// <summary>
        /// <para>
        /// <para>The client identifiers accepted during JWT validation. A token is rejected if it was
        /// not issued to one of these clients.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClients")]
        public System.String[] DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient { get; set; }
        #endregion
        
        #region Parameter DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope
        /// <summary>
        /// <para>
        /// <para>The scopes accepted during JWT validation. A token is rejected if it does not carry
        /// one of these scopes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScopes")]
        public System.String[] DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope { get; set; }
        #endregion
        
        #region Parameter ApprovalConfiguration_OptionalValue_AutoApprovalRule
        /// <summary>
        /// <para>
        /// <para>The rules that determine which registry records are automatically approved on submission.
        /// When omitted or empty, submitted records require manual review.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApprovalConfiguration_OptionalValue_AutoApprovalRules")]
        public System.String[] ApprovalConfiguration_OptionalValue_AutoApprovalRule { get; set; }
        #endregion
        
        #region Parameter DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim
        /// <summary>
        /// <para>
        /// <para>Additional custom claim validations applied to the inbound JWT.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaims")]
        public Amazon.AgentRegistryControl.Model.CustomClaimValidationType[] DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim { get; set; }
        #endregion
        
        #region Parameter DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl
        /// <summary>
        /// <para>
        /// <para>The OpenID Connect discovery URL used to retrieve the identity provider's metadata
        /// and signing keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl { get; set; }
        #endregion
        
        #region Parameter DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address type used by the private endpoint, either IPV4 or IPV6.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AgentRegistryControl.EndpointIpAddressType")]
        public Amazon.AgentRegistryControl.EndpointIpAddressType DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated name of the registry</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Description_OptionalValue
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description_OptionalValue { get; set; }
        #endregion
        
        #region Parameter DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride
        /// <summary>
        /// <para>
        /// <para>Per-domain private endpoint overrides that route specific identity provider domains
        /// through distinct private endpoints.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverrides")]
        public Amazon.AgentRegistryControl.Model.PrivateEndpointOverride[] DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the registry to update (ARN or ID)</para>
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
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the VPC Lattice resource configuration, specified as a resource
        /// configuration ID or ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier { get; set; }
        #endregion
        
        #region Parameter DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain
        /// <summary>
        /// <para>
        /// <para>The routing domain used to resolve traffic through the private endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain { get; set; }
        #endregion
        
        #region Parameter DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the security groups associated with the private endpoint network
        /// interfaces.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupIds")]
        public System.String[] DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the subnets in which the private endpoint network interfaces are
        /// placed.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetIds")]
        public System.String[] DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId { get; set; }
        #endregion
        
        #region Parameter DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tags")]
        public System.Collections.Hashtable DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag { get; set; }
        #endregion
        
        #region Parameter DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the VPC in which the private endpoint is provisioned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AgentRegistryControl.Model.UpdateRegistryResponse).
        /// Specifying the name of a property of type Amazon.AgentRegistryControl.Model.UpdateRegistryResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RegistryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AGRCRegistry (UpdateRegistry)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AgentRegistryControl.Model.UpdateRegistryResponse, UpdateAGRCRegistryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ApprovalConfiguration_OptionalValue_AutoApprovalRule != null)
            {
                context.ApprovalConfiguration_OptionalValue_AutoApprovalRule = new List<System.String>(this.ApprovalConfiguration_OptionalValue_AutoApprovalRule);
            }
            context.Description_OptionalValue = this.Description_OptionalValue;
            if (this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience != null)
            {
                context.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience = new List<System.String>(this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience);
            }
            if (this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient != null)
            {
                context.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient = new List<System.String>(this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient);
            }
            if (this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope != null)
            {
                context.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope = new List<System.String>(this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope);
            }
            if (this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim != null)
            {
                context.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim = new List<Amazon.AgentRegistryControl.Model.CustomClaimValidationType>(this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim);
            }
            context.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl = this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl;
            context.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType = this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType;
            context.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain = this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain;
            if (this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId != null)
            {
                context.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId = new List<System.String>(this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId);
            }
            if (this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId != null)
            {
                context.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId = new List<System.String>(this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId);
            }
            if (this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag != null)
            {
                context.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag.Keys)
                {
                    context.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag.Add((String)hashKey, (System.String)(this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag[hashKey]));
                }
            }
            context.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier = this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier;
            context.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier = this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier;
            if (this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride != null)
            {
                context.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride = new List<Amazon.AgentRegistryControl.Model.PrivateEndpointOverride>(this.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride);
            }
            context.Name = this.Name;
            context.RegistryId = this.RegistryId;
            #if MODULAR
            if (this.RegistryId == null && ParameterWasBound(nameof(this.RegistryId)))
            {
                WriteWarning("You are passing $null as a value for parameter RegistryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AgentRegistryControl.Model.UpdateRegistryRequest();
            
            
             // populate ApprovalConfiguration
            var requestApprovalConfigurationIsNull = true;
            request.ApprovalConfiguration = new Amazon.AgentRegistryControl.Model.UpdatedApprovalConfiguration();
            Amazon.AgentRegistryControl.Model.ApprovalConfiguration requestApprovalConfiguration_approvalConfiguration_OptionalValue = null;
            
             // populate OptionalValue
            var requestApprovalConfiguration_approvalConfiguration_OptionalValueIsNull = true;
            requestApprovalConfiguration_approvalConfiguration_OptionalValue = new Amazon.AgentRegistryControl.Model.ApprovalConfiguration();
            List<System.String> requestApprovalConfiguration_approvalConfiguration_OptionalValue_approvalConfiguration_OptionalValue_AutoApprovalRule = null;
            if (cmdletContext.ApprovalConfiguration_OptionalValue_AutoApprovalRule != null)
            {
                requestApprovalConfiguration_approvalConfiguration_OptionalValue_approvalConfiguration_OptionalValue_AutoApprovalRule = cmdletContext.ApprovalConfiguration_OptionalValue_AutoApprovalRule;
            }
            if (requestApprovalConfiguration_approvalConfiguration_OptionalValue_approvalConfiguration_OptionalValue_AutoApprovalRule != null)
            {
                requestApprovalConfiguration_approvalConfiguration_OptionalValue.AutoApprovalRules = requestApprovalConfiguration_approvalConfiguration_OptionalValue_approvalConfiguration_OptionalValue_AutoApprovalRule;
                requestApprovalConfiguration_approvalConfiguration_OptionalValueIsNull = false;
            }
             // determine if requestApprovalConfiguration_approvalConfiguration_OptionalValue should be set to null
            if (requestApprovalConfiguration_approvalConfiguration_OptionalValueIsNull)
            {
                requestApprovalConfiguration_approvalConfiguration_OptionalValue = null;
            }
            if (requestApprovalConfiguration_approvalConfiguration_OptionalValue != null)
            {
                request.ApprovalConfiguration.OptionalValue = requestApprovalConfiguration_approvalConfiguration_OptionalValue;
                requestApprovalConfigurationIsNull = false;
            }
             // determine if request.ApprovalConfiguration should be set to null
            if (requestApprovalConfigurationIsNull)
            {
                request.ApprovalConfiguration = null;
            }
            
             // populate Description
            var requestDescriptionIsNull = true;
            request.Description = new Amazon.AgentRegistryControl.Model.UpdatedDescription();
            System.String requestDescription_description_OptionalValue = null;
            if (cmdletContext.Description_OptionalValue != null)
            {
                requestDescription_description_OptionalValue = cmdletContext.Description_OptionalValue;
            }
            if (requestDescription_description_OptionalValue != null)
            {
                request.Description.OptionalValue = requestDescription_description_OptionalValue;
                requestDescriptionIsNull = false;
            }
             // determine if request.Description should be set to null
            if (requestDescriptionIsNull)
            {
                request.Description = null;
            }
            
             // populate DiscoveryConfiguration
            var requestDiscoveryConfigurationIsNull = true;
            request.DiscoveryConfiguration = new Amazon.AgentRegistryControl.Model.UpdatedDiscoveryConfiguration();
            Amazon.AgentRegistryControl.Model.UpdatedAuthorizerConfiguration requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration = null;
            
             // populate AuthorizerConfiguration
            var requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfigurationIsNull = true;
            requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration = new Amazon.AgentRegistryControl.Model.UpdatedAuthorizerConfiguration();
            Amazon.AgentRegistryControl.Model.AuthorizerConfiguration requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue = null;
            
             // populate OptionalValue
            var requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValueIsNull = true;
            requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue = new Amazon.AgentRegistryControl.Model.AuthorizerConfiguration();
            Amazon.AgentRegistryControl.Model.CustomJWTAuthorizerConfiguration requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer = null;
            
             // populate CustomJWTAuthorizer
            var requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = true;
            requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer = new Amazon.AgentRegistryControl.Model.CustomJWTAuthorizerConfiguration();
            List<System.String> requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience = null;
            if (cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience = cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer.AllowedAudience = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = false;
            }
            List<System.String> requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient = null;
            if (cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient = cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer.AllowedClients = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = false;
            }
            List<System.String> requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope = null;
            if (cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope = cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer.AllowedScopes = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = false;
            }
            List<Amazon.AgentRegistryControl.Model.CustomClaimValidationType> requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim = null;
            if (cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim = cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer.CustomClaims = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = false;
            }
            System.String requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl = null;
            if (cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl = cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer.DiscoveryUrl = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = false;
            }
            List<Amazon.AgentRegistryControl.Model.PrivateEndpointOverride> requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride = null;
            if (cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride = cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer.PrivateEndpointOverrides = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.PrivateEndpoint requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint = null;
            
             // populate PrivateEndpoint
            var requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointIsNull = true;
            requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint = new Amazon.AgentRegistryControl.Model.PrivateEndpoint();
            Amazon.AgentRegistryControl.Model.SelfManagedLatticeResource requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource = null;
            
             // populate SelfManagedLatticeResource
            var requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResourceIsNull = true;
            requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource = new Amazon.AgentRegistryControl.Model.SelfManagedLatticeResource();
            System.String requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier = null;
            if (cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier = cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource.ResourceConfigurationIdentifier = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResourceIsNull = false;
            }
             // determine if requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource should be set to null
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResourceIsNull)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource = null;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint.SelfManagedLatticeResource = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointIsNull = false;
            }
            Amazon.AgentRegistryControl.Model.ManagedVpcResource requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource = null;
            
             // populate ManagedVpcResource
            var requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull = true;
            requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource = new Amazon.AgentRegistryControl.Model.ManagedVpcResource();
            Amazon.AgentRegistryControl.EndpointIpAddressType requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType = null;
            if (cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType = cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource.EndpointIpAddressType = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
            System.String requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain = null;
            if (cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain = cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource.RoutingDomain = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
            List<System.String> requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId = null;
            if (cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId = cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource.SecurityGroupIds = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
            List<System.String> requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId = null;
            if (cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId = cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource.SubnetIds = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
            Dictionary<System.String, System.String> requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag = null;
            if (cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag = cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource.Tags = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
            System.String requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier = null;
            if (cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier = cmdletContext.DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource.VpcIdentifier = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
             // determine if requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource should be set to null
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResourceIsNull)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource = null;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint.ManagedVpcResource = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointIsNull = false;
            }
             // determine if requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint should be set to null
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointIsNull)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint = null;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer.PrivateEndpoint = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull = false;
            }
             // determine if requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer should be set to null
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizerIsNull)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer = null;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue.CustomJWTAuthorizer = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_discoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValueIsNull = false;
            }
             // determine if requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue should be set to null
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValueIsNull)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue = null;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue != null)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration.OptionalValue = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration_discoveryConfiguration_AuthorizerConfiguration_OptionalValue;
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfigurationIsNull = false;
            }
             // determine if requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration should be set to null
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfigurationIsNull)
            {
                requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration = null;
            }
            if (requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration != null)
            {
                request.DiscoveryConfiguration.AuthorizerConfiguration = requestDiscoveryConfiguration_discoveryConfiguration_AuthorizerConfiguration;
                requestDiscoveryConfigurationIsNull = false;
            }
             // determine if request.DiscoveryConfiguration should be set to null
            if (requestDiscoveryConfigurationIsNull)
            {
                request.DiscoveryConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryId = cmdletContext.RegistryId;
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
        
        private Amazon.AgentRegistryControl.Model.UpdateRegistryResponse CallAWSServiceOperation(IAmazonAgentRegistryControl client, Amazon.AgentRegistryControl.Model.UpdateRegistryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agent Registry Control", "UpdateRegistry");
            try
            {
                return client.UpdateRegistryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> ApprovalConfiguration_OptionalValue_AutoApprovalRule { get; set; }
            public System.String Description_OptionalValue { get; set; }
            public List<System.String> DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedAudience { get; set; }
            public List<System.String> DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedClient { get; set; }
            public List<System.String> DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_AllowedScope { get; set; }
            public List<Amazon.AgentRegistryControl.Model.CustomClaimValidationType> DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_CustomClaim { get; set; }
            public System.String DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_DiscoveryUrl { get; set; }
            public Amazon.AgentRegistryControl.EndpointIpAddressType DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType { get; set; }
            public System.String DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_RoutingDomain { get; set; }
            public List<System.String> DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SecurityGroupId { get; set; }
            public List<System.String> DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_SubnetId { get; set; }
            public Dictionary<System.String, System.String> DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_Tag { get; set; }
            public System.String DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_VpcIdentifier { get; set; }
            public System.String DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier { get; set; }
            public List<Amazon.AgentRegistryControl.Model.PrivateEndpointOverride> DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpointOverride { get; set; }
            public System.String Name { get; set; }
            public System.String RegistryId { get; set; }
            public System.Func<Amazon.AgentRegistryControl.Model.UpdateRegistryResponse, UpdateAGRCRegistryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
