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
using Amazon.EKS;
using Amazon.EKS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Creates a managed capability resource for an Amazon EKS cluster.
    /// 
    ///  
    /// <para>
    /// Capabilities provide fully managed capabilities to build and scale with Kubernetes.
    /// When you create a capability, Amazon EKSprovisions and manages the infrastructure
    /// required to run the capability outside of your cluster. This approach reduces operational
    /// overhead and preserves cluster resources.
    /// </para><para>
    /// You can only create one Capability of each type on a given Amazon EKS cluster. Valid
    /// types are Argo CD for declarative GitOps deployment, Amazon Web Services Controllers
    /// for Kubernetes (ACK) for resource management, and Kube Resource Orchestrator (KRO)
    /// for Kubernetes custom resource orchestration.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/capabilities.html">EKS
    /// Capabilities</a> in the <i>Amazon EKS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EKSCapability", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.Capability")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes CreateCapability API operation.", Operation = new[] {"CreateCapability"}, SelectReturnType = typeof(Amazon.EKS.Model.CreateCapabilityResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.Capability or Amazon.EKS.Model.CreateCapabilityResponse",
        "This cmdlet returns an Amazon.EKS.Model.Capability object.",
        "The service call response (type Amazon.EKS.Model.CreateCapabilityResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEKSCapabilityCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CapabilityName
        /// <summary>
        /// <para>
        /// <para>A unique name for the capability. The name must be unique within your cluster and
        /// can contain alphanumeric characters, hyphens, and underscores.</para>
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
        public System.String CapabilityName { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. This token is valid for 24 hours after creation. If you retry a request
        /// with the same client request token and the same parameters after the original request
        /// has completed successfully, the result of the original request is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon EKS cluster where you want to create the capability.</para>
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
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter DeletePropagationPolicy
        /// <summary>
        /// <para>
        /// <para>Specifies how Kubernetes resources managed by the capability should be handled when
        /// the capability is deleted. Currently, the only supported value is <c>RETAIN</c> which
        /// retains all Kubernetes resources managed by the capability when the capability is
        /// deleted.</para><para>Because resources are retained, all Kubernetes resources created by the capability
        /// should be deleted from the cluster before deleting the capability itself. After the
        /// capability is deleted, these resources become difficult to manage because the controller
        /// is no longer available.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EKS.CapabilityDeletePropagationPolicy")]
        public Amazon.EKS.CapabilityDeletePropagationPolicy DeletePropagationPolicy { get; set; }
        #endregion
        
        #region Parameter AwsIdc_IdcInstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM Identity CenterIAM; Identity Center instance
        /// to use for authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ArgoCd_AwsIdc_IdcInstanceArn")]
        public System.String AwsIdc_IdcInstanceArn { get; set; }
        #endregion
        
        #region Parameter AwsIdc_IdcRegion
        /// <summary>
        /// <para>
        /// <para>The Region where your IAM Identity CenterIAM; Identity Center instance is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ArgoCd_AwsIdc_IdcRegion")]
        public System.String AwsIdc_IdcRegion { get; set; }
        #endregion
        
        #region Parameter ArgoCd_Namespace
        /// <summary>
        /// <para>
        /// <para>The Kubernetes namespace where Argo CD resources will be created. If not specified,
        /// the default namespace is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ArgoCd_Namespace")]
        public System.String ArgoCd_Namespace { get; set; }
        #endregion
        
        #region Parameter ArgoCd_RbacRoleMapping
        /// <summary>
        /// <para>
        /// <para>A list of role mappings that define which IAM Identity CenterIAM; Identity Center
        /// users or groups have which Argo CD roles. Each mapping associates an Argo CD role
        /// (<c>ADMIN</c>, <c>EDITOR</c>, or <c>VIEWER</c>) with one or more IAM Identity CenterIAM;
        /// Identity Center identities.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ArgoCd_RbacRoleMappings")]
        public Amazon.EKS.Model.ArgoCdRoleMapping[] ArgoCd_RbacRoleMapping { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that the capability uses to interact
        /// with Amazon Web Services services. This role must have a trust policy that allows
        /// the EKS service principal to assume it, and it must have the necessary permissions
        /// for the capability type you're creating.</para><para>For ACK capabilities, the role needs permissions to manage the resources you want
        /// to control through Kubernetes. For Argo CD capabilities, the role needs permissions
        /// to access Git repositories and Secrets Manager. For KRO capabilities, the role needs
        /// permissions based on the resources you'll be orchestrating.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
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
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of capability to create. Valid values are:</para><ul><li><para><c>ACK</c> – Amazon Web Services Controllers for Kubernetes (ACK), which lets you
        /// manage resources directly from Kubernetes.</para></li><li><para><c>ARGOCD</c> – Argo CD for GitOps-based continuous delivery.</para></li><li><para><c>KRO</c> – Kube Resource Orchestrator (KRO) for composing and managing custom Kubernetes
        /// resources.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EKS.CapabilityType")]
        public Amazon.EKS.CapabilityType Type { get; set; }
        #endregion
        
        #region Parameter NetworkAccess_VpceId
        /// <summary>
        /// <para>
        /// <para>A list of VPC endpoint IDs to associate with the managed Argo CD API server endpoint.
        /// Each VPC endpoint provides private connectivity from a specific VPC to the Argo CD
        /// server. You can specify multiple VPC endpoint IDs to enable access from multiple VPCs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ArgoCd_NetworkAccess_VpceIds")]
        public System.String[] NetworkAccess_VpceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Capability'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.CreateCapabilityResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.CreateCapabilityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Capability";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CapabilityName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EKSCapability (CreateCapability)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.CreateCapabilityResponse, NewEKSCapabilityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapabilityName = this.CapabilityName;
            #if MODULAR
            if (this.CapabilityName == null && ParameterWasBound(nameof(this.CapabilityName)))
            {
                WriteWarning("You are passing $null as a value for parameter CapabilityName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AwsIdc_IdcInstanceArn = this.AwsIdc_IdcInstanceArn;
            context.AwsIdc_IdcRegion = this.AwsIdc_IdcRegion;
            context.ArgoCd_Namespace = this.ArgoCd_Namespace;
            if (this.NetworkAccess_VpceId != null)
            {
                context.NetworkAccess_VpceId = new List<System.String>(this.NetworkAccess_VpceId);
            }
            if (this.ArgoCd_RbacRoleMapping != null)
            {
                context.ArgoCd_RbacRoleMapping = new List<Amazon.EKS.Model.ArgoCdRoleMapping>(this.ArgoCd_RbacRoleMapping);
            }
            context.DeletePropagationPolicy = this.DeletePropagationPolicy;
            #if MODULAR
            if (this.DeletePropagationPolicy == null && ParameterWasBound(nameof(this.DeletePropagationPolicy)))
            {
                WriteWarning("You are passing $null as a value for parameter DeletePropagationPolicy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EKS.Model.CreateCapabilityRequest();
            
            if (cmdletContext.CapabilityName != null)
            {
                request.CapabilityName = cmdletContext.CapabilityName;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.EKS.Model.CapabilityConfigurationRequest();
            Amazon.EKS.Model.ArgoCdConfigRequest requestConfiguration_configuration_ArgoCd = null;
            
             // populate ArgoCd
            var requestConfiguration_configuration_ArgoCdIsNull = true;
            requestConfiguration_configuration_ArgoCd = new Amazon.EKS.Model.ArgoCdConfigRequest();
            System.String requestConfiguration_configuration_ArgoCd_argoCd_Namespace = null;
            if (cmdletContext.ArgoCd_Namespace != null)
            {
                requestConfiguration_configuration_ArgoCd_argoCd_Namespace = cmdletContext.ArgoCd_Namespace;
            }
            if (requestConfiguration_configuration_ArgoCd_argoCd_Namespace != null)
            {
                requestConfiguration_configuration_ArgoCd.Namespace = requestConfiguration_configuration_ArgoCd_argoCd_Namespace;
                requestConfiguration_configuration_ArgoCdIsNull = false;
            }
            List<Amazon.EKS.Model.ArgoCdRoleMapping> requestConfiguration_configuration_ArgoCd_argoCd_RbacRoleMapping = null;
            if (cmdletContext.ArgoCd_RbacRoleMapping != null)
            {
                requestConfiguration_configuration_ArgoCd_argoCd_RbacRoleMapping = cmdletContext.ArgoCd_RbacRoleMapping;
            }
            if (requestConfiguration_configuration_ArgoCd_argoCd_RbacRoleMapping != null)
            {
                requestConfiguration_configuration_ArgoCd.RbacRoleMappings = requestConfiguration_configuration_ArgoCd_argoCd_RbacRoleMapping;
                requestConfiguration_configuration_ArgoCdIsNull = false;
            }
            Amazon.EKS.Model.ArgoCdNetworkAccessConfigRequest requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_NetworkAccess = null;
            
             // populate NetworkAccess
            var requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_NetworkAccessIsNull = true;
            requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_NetworkAccess = new Amazon.EKS.Model.ArgoCdNetworkAccessConfigRequest();
            List<System.String> requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_NetworkAccess_networkAccess_VpceId = null;
            if (cmdletContext.NetworkAccess_VpceId != null)
            {
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_NetworkAccess_networkAccess_VpceId = cmdletContext.NetworkAccess_VpceId;
            }
            if (requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_NetworkAccess_networkAccess_VpceId != null)
            {
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_NetworkAccess.VpceIds = requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_NetworkAccess_networkAccess_VpceId;
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_NetworkAccessIsNull = false;
            }
             // determine if requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_NetworkAccess should be set to null
            if (requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_NetworkAccessIsNull)
            {
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_NetworkAccess = null;
            }
            if (requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_NetworkAccess != null)
            {
                requestConfiguration_configuration_ArgoCd.NetworkAccess = requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_NetworkAccess;
                requestConfiguration_configuration_ArgoCdIsNull = false;
            }
            Amazon.EKS.Model.ArgoCdAwsIdcConfigRequest requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc = null;
            
             // populate AwsIdc
            var requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdcIsNull = true;
            requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc = new Amazon.EKS.Model.ArgoCdAwsIdcConfigRequest();
            System.String requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc_awsIdc_IdcInstanceArn = null;
            if (cmdletContext.AwsIdc_IdcInstanceArn != null)
            {
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc_awsIdc_IdcInstanceArn = cmdletContext.AwsIdc_IdcInstanceArn;
            }
            if (requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc_awsIdc_IdcInstanceArn != null)
            {
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc.IdcInstanceArn = requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc_awsIdc_IdcInstanceArn;
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdcIsNull = false;
            }
            System.String requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc_awsIdc_IdcRegion = null;
            if (cmdletContext.AwsIdc_IdcRegion != null)
            {
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc_awsIdc_IdcRegion = cmdletContext.AwsIdc_IdcRegion;
            }
            if (requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc_awsIdc_IdcRegion != null)
            {
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc.IdcRegion = requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc_awsIdc_IdcRegion;
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdcIsNull = false;
            }
             // determine if requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc should be set to null
            if (requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdcIsNull)
            {
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc = null;
            }
            if (requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc != null)
            {
                requestConfiguration_configuration_ArgoCd.AwsIdc = requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_AwsIdc;
                requestConfiguration_configuration_ArgoCdIsNull = false;
            }
             // determine if requestConfiguration_configuration_ArgoCd should be set to null
            if (requestConfiguration_configuration_ArgoCdIsNull)
            {
                requestConfiguration_configuration_ArgoCd = null;
            }
            if (requestConfiguration_configuration_ArgoCd != null)
            {
                request.Configuration.ArgoCd = requestConfiguration_configuration_ArgoCd;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.DeletePropagationPolicy != null)
            {
                request.DeletePropagationPolicy = cmdletContext.DeletePropagationPolicy;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.EKS.Model.CreateCapabilityResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.CreateCapabilityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "CreateCapability");
            try
            {
                return client.CreateCapabilityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CapabilityName { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String ClusterName { get; set; }
            public System.String AwsIdc_IdcInstanceArn { get; set; }
            public System.String AwsIdc_IdcRegion { get; set; }
            public System.String ArgoCd_Namespace { get; set; }
            public List<System.String> NetworkAccess_VpceId { get; set; }
            public List<Amazon.EKS.Model.ArgoCdRoleMapping> ArgoCd_RbacRoleMapping { get; set; }
            public Amazon.EKS.CapabilityDeletePropagationPolicy DeletePropagationPolicy { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.EKS.CapabilityType Type { get; set; }
            public System.Func<Amazon.EKS.Model.CreateCapabilityResponse, NewEKSCapabilityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Capability;
        }
        
    }
}
