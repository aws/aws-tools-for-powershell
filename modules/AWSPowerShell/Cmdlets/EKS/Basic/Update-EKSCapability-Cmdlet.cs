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
using Amazon.EKS;
using Amazon.EKS.Model;

namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Updates the configuration of a managed capability in your Amazon EKS cluster. You
    /// can update the IAM role, configuration settings, and delete propagation policy for
    /// a capability.
    /// 
    ///  
    /// <para>
    /// When you update a capability, Amazon EKS applies the changes and may restart capability
    /// components as needed. The capability remains available during the update process,
    /// but some operations may be temporarily unavailable.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "EKSCapability", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.Update")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes UpdateCapability API operation.", Operation = new[] {"UpdateCapability"}, SelectReturnType = typeof(Amazon.EKS.Model.UpdateCapabilityResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.Update or Amazon.EKS.Model.UpdateCapabilityResponse",
        "This cmdlet returns an Amazon.EKS.Model.Update object.",
        "The service call response (type Amazon.EKS.Model.UpdateCapabilityResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEKSCapabilityCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RbacRoleMappings_AddOrUpdateRoleMapping
        /// <summary>
        /// <para>
        /// <para>A list of role mappings to add or update. If a mapping for the specified role already
        /// exists, it will be updated with the new identities. If it doesn't exist, a new mapping
        /// will be created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ArgoCd_RbacRoleMappings_AddOrUpdateRoleMappings")]
        public Amazon.EKS.Model.ArgoCdRoleMapping[] RbacRoleMappings_AddOrUpdateRoleMapping { get; set; }
        #endregion
        
        #region Parameter CapabilityName
        /// <summary>
        /// <para>
        /// <para>The name of the capability to update configuration for.</para>
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
        /// the request. This token is valid for 24 hours after creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon EKS cluster that contains the capability you want to update
        /// configuration for.</para>
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
        /// <para>The updated delete propagation policy for the capability. Currently, the only supported
        /// value is <c>RETAIN</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EKS.CapabilityDeletePropagationPolicy")]
        public Amazon.EKS.CapabilityDeletePropagationPolicy DeletePropagationPolicy { get; set; }
        #endregion
        
        #region Parameter RbacRoleMappings_RemoveRoleMapping
        /// <summary>
        /// <para>
        /// <para>A list of role mappings to remove from the RBAC configuration. Each mapping specifies
        /// an Argo CD role (<c>ADMIN</c>, <c>EDITOR</c>, or <c>VIEWER</c>) and the identities
        /// to remove from that role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ArgoCd_RbacRoleMappings_RemoveRoleMappings")]
        public Amazon.EKS.Model.ArgoCdRoleMapping[] RbacRoleMappings_RemoveRoleMapping { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that the capability uses to interact
        /// with Amazon Web Services services. If you specify a new role ARN, the capability will
        /// start using the new role for all subsequent operations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter NetworkAccess_VpceId
        /// <summary>
        /// <para>
        /// <para>A list of VPC endpoint IDs to associate with the managed Argo CD API server endpoint.
        /// Each VPC endpoint provides private connectivity from a specific VPC to the Argo CD
        /// server. You can specify multiple VPC endpoint IDs to enable access from multiple VPCs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ArgoCd_NetworkAccess_VpceIds")]
        public System.String[] NetworkAccess_VpceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Update'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.UpdateCapabilityResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.UpdateCapabilityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Update";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CapabilityName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EKSCapability (UpdateCapability)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.UpdateCapabilityResponse, UpdateEKSCapabilityCmdlet>(Select) ??
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
            if (this.NetworkAccess_VpceId != null)
            {
                context.NetworkAccess_VpceId = new List<System.String>(this.NetworkAccess_VpceId);
            }
            if (this.RbacRoleMappings_AddOrUpdateRoleMapping != null)
            {
                context.RbacRoleMappings_AddOrUpdateRoleMapping = new List<Amazon.EKS.Model.ArgoCdRoleMapping>(this.RbacRoleMappings_AddOrUpdateRoleMapping);
            }
            if (this.RbacRoleMappings_RemoveRoleMapping != null)
            {
                context.RbacRoleMappings_RemoveRoleMapping = new List<Amazon.EKS.Model.ArgoCdRoleMapping>(this.RbacRoleMappings_RemoveRoleMapping);
            }
            context.DeletePropagationPolicy = this.DeletePropagationPolicy;
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.EKS.Model.UpdateCapabilityRequest();
            
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
            request.Configuration = new Amazon.EKS.Model.UpdateCapabilityConfiguration();
            Amazon.EKS.Model.UpdateArgoCdConfig requestConfiguration_configuration_ArgoCd = null;
            
             // populate ArgoCd
            var requestConfiguration_configuration_ArgoCdIsNull = true;
            requestConfiguration_configuration_ArgoCd = new Amazon.EKS.Model.UpdateArgoCdConfig();
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
            Amazon.EKS.Model.UpdateRoleMappings requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings = null;
            
             // populate RbacRoleMappings
            var requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappingsIsNull = true;
            requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings = new Amazon.EKS.Model.UpdateRoleMappings();
            List<Amazon.EKS.Model.ArgoCdRoleMapping> requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings_rbacRoleMappings_AddOrUpdateRoleMapping = null;
            if (cmdletContext.RbacRoleMappings_AddOrUpdateRoleMapping != null)
            {
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings_rbacRoleMappings_AddOrUpdateRoleMapping = cmdletContext.RbacRoleMappings_AddOrUpdateRoleMapping;
            }
            if (requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings_rbacRoleMappings_AddOrUpdateRoleMapping != null)
            {
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings.AddOrUpdateRoleMappings = requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings_rbacRoleMappings_AddOrUpdateRoleMapping;
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappingsIsNull = false;
            }
            List<Amazon.EKS.Model.ArgoCdRoleMapping> requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings_rbacRoleMappings_RemoveRoleMapping = null;
            if (cmdletContext.RbacRoleMappings_RemoveRoleMapping != null)
            {
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings_rbacRoleMappings_RemoveRoleMapping = cmdletContext.RbacRoleMappings_RemoveRoleMapping;
            }
            if (requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings_rbacRoleMappings_RemoveRoleMapping != null)
            {
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings.RemoveRoleMappings = requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings_rbacRoleMappings_RemoveRoleMapping;
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappingsIsNull = false;
            }
             // determine if requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings should be set to null
            if (requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappingsIsNull)
            {
                requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings = null;
            }
            if (requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings != null)
            {
                requestConfiguration_configuration_ArgoCd.RbacRoleMappings = requestConfiguration_configuration_ArgoCd_configuration_ArgoCd_RbacRoleMappings;
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
        
        private Amazon.EKS.Model.UpdateCapabilityResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.UpdateCapabilityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "UpdateCapability");
            try
            {
                #if DESKTOP
                return client.UpdateCapability(request);
                #elif CORECLR
                return client.UpdateCapabilityAsync(request).GetAwaiter().GetResult();
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
            public System.String CapabilityName { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String ClusterName { get; set; }
            public List<System.String> NetworkAccess_VpceId { get; set; }
            public List<Amazon.EKS.Model.ArgoCdRoleMapping> RbacRoleMappings_AddOrUpdateRoleMapping { get; set; }
            public List<Amazon.EKS.Model.ArgoCdRoleMapping> RbacRoleMappings_RemoveRoleMapping { get; set; }
            public Amazon.EKS.CapabilityDeletePropagationPolicy DeletePropagationPolicy { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.EKS.Model.UpdateCapabilityResponse, UpdateEKSCapabilityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Update;
        }
        
    }
}
