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
using Amazon.ManagedGrafana;
using Amazon.ManagedGrafana.Model;

namespace Amazon.PowerShell.Cmdlets.MGRF
{
    /// <summary>
    /// Creates a <i>workspace</i>. In a workspace, you can create Grafana dashboards and
    /// visualizations to analyze your metrics, logs, and traces. You don't have to build,
    /// package, or deploy any hardware to run the Grafana server.
    /// 
    ///  
    /// <para>
    /// Don't use <code>CreateWorkspace</code> to modify an existing workspace. Instead, use
    /// <a href="https://docs.aws.amazon.com/grafana/latest/APIReference/API_UpdateWorkspace.html">UpdateWorkspace</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "MGRFWorkspace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ManagedGrafana.Model.WorkspaceDescription")]
    [AWSCmdlet("Calls the Amazon Managed Grafana CreateWorkspace API operation.", Operation = new[] {"CreateWorkspace"}, SelectReturnType = typeof(Amazon.ManagedGrafana.Model.CreateWorkspaceResponse))]
    [AWSCmdletOutput("Amazon.ManagedGrafana.Model.WorkspaceDescription or Amazon.ManagedGrafana.Model.CreateWorkspaceResponse",
        "This cmdlet returns an Amazon.ManagedGrafana.Model.WorkspaceDescription object.",
        "The service call response (type Amazon.ManagedGrafana.Model.CreateWorkspaceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMGRFWorkspaceCmdlet : AmazonManagedGrafanaClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter AccountAccessType
        /// <summary>
        /// <para>
        /// <para>Specifies whether the workspace can access Amazon Web Services resources in this Amazon
        /// Web Services account only, or whether it can also access Amazon Web Services resources
        /// in other accounts in the same organization. If you specify <code>ORGANIZATION</code>,
        /// you must specify which organizational units the workspace can access in the <code>workspaceOrganizationalUnits</code>
        /// parameter.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ManagedGrafana.AccountAccessType")]
        public Amazon.ManagedGrafana.AccountAccessType AccountAccessType { get; set; }
        #endregion
        
        #region Parameter AuthenticationProvider
        /// <summary>
        /// <para>
        /// <para>Specifies whether this workspace uses SAML 2.0, IAM Identity Center (successor to
        /// Single Sign-On), or both to authenticate users for using the Grafana console within
        /// a workspace. For more information, see <a href="https://docs.aws.amazon.com/grafana/latest/userguide/authentication-in-AMG.html">User
        /// authentication in Amazon Managed Grafana</a>.</para>
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
        [Alias("AuthenticationProviders")]
        public System.String[] AuthenticationProvider { get; set; }
        #endregion
        
        #region Parameter Configuration
        /// <summary>
        /// <para>
        /// <para>The configuration string for the workspace that you create. For more information about
        /// the format and configuration options available, see <a href="https://docs.aws.amazon.com/grafana/latest/userguide/AMG-configure-workspace.html">Working
        /// in your Grafana workspace</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration { get; set; }
        #endregion
        
        #region Parameter OrganizationRoleName
        /// <summary>
        /// <para>
        /// <para>The name of an IAM role that already exists to use with Organizations to access Amazon
        /// Web Services data sources and notification channels in other accounts in an organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationRoleName { get; set; }
        #endregion
        
        #region Parameter PermissionType
        /// <summary>
        /// <para>
        /// <para>When creating a workspace through the Amazon Web Services API, CLI or Amazon Web Services
        /// CloudFormation, you must manage IAM roles and provision the permissions that the workspace
        /// needs to use Amazon Web Services data sources and notification channels.</para><para>You must also specify a <code>workspaceRoleArn</code> for a role that you will manage
        /// for the workspace to use when accessing those datasources and notification channels.</para><para>The ability for Amazon Managed Grafana to create and update IAM roles on behalf of
        /// the user is supported only in the Amazon Managed Grafana console, where this value
        /// may be set to <code>SERVICE_MANAGED</code>.</para><note><para>Use only the <code>CUSTOMER_MANAGED</code> permission type when creating a workspace
        /// with the API, CLI or Amazon Web Services CloudFormation. </para></note><para>For more information, see <a href="https://docs.aws.amazon.com/grafana/latest/userguide/AMG-manage-permissions.html">Amazon
        /// Managed Grafana permissions and policies for Amazon Web Services data sources and
        /// notification channels</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ManagedGrafana.PermissionType")]
        public Amazon.ManagedGrafana.PermissionType PermissionType { get; set; }
        #endregion
        
        #region Parameter NetworkAccessControl_PrefixListId
        /// <summary>
        /// <para>
        /// <para>An array of prefix list IDs. A prefix list is a list of CIDR ranges of IP addresses.
        /// The IP addresses specified are allowed to access your workspace. If the list is not
        /// included in the configuration then no IP addresses will be allowed to access the workspace.
        /// You create a prefix list using the Amazon VPC console.</para><para>Prefix list IDs have the format <code>pl-<i>1a2b3c4d</i></code>.</para><para>For more information about prefix lists, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/managed-prefix-lists.html">Group
        /// CIDR blocks using managed prefix lists</a>in the <i>Amazon Virtual Private Cloud User
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkAccessControl_PrefixListIds")]
        public System.String[] NetworkAccessControl_PrefixListId { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The list of Amazon EC2 security group IDs attached to the Amazon VPC for your Grafana
        /// workspace to connect. Duplicates not allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfiguration_SecurityGroupIds")]
        public System.String[] VpcConfiguration_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name of the CloudFormation stack set to use to generate IAM roles to be used for
        /// this workspace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StackSetName { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>The list of Amazon EC2 subnet IDs created in the Amazon VPC for your Grafana workspace
        /// to connect. Duplicates not allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfiguration_SubnetIds")]
        public System.String[] VpcConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of tags associated with the workspace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter NetworkAccessControl_VpceId
        /// <summary>
        /// <para>
        /// <para>An array of Amazon VPC endpoint IDs for the workspace. You can create VPC endpoints
        /// to your Amazon Managed Grafana workspace for access from within a VPC. If a <code>NetworkAccessConfiguration</code>
        /// is specified then only VPC endpoints specified here will be allowed to access the
        /// workspace.</para><para>VPC endpoint IDs have the format <code>vpce-<i>1a2b3c4d</i></code>.</para><para>For more information about creating an interface VPC endpoint, see <a href="https://docs.aws.amazon.com/grafana/latest/userguide/VPC-endpoints">Interface
        /// VPC endpoints</a> in the <i>Amazon Managed Grafana User Guide</i>.</para><note><para>The only VPC endpoints that can be specified here are interface VPC endpoints for
        /// Grafana workspaces (using the <code>com.amazonaws.[region].grafana-workspace</code>
        /// service endpoint). Other VPC endpoints will be ignored.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkAccessControl_VpceIds")]
        public System.String[] NetworkAccessControl_VpceId { get; set; }
        #endregion
        
        #region Parameter WorkspaceDataSource
        /// <summary>
        /// <para>
        /// <para>This parameter is for internal use only, and should not be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkspaceDataSources")]
        public System.String[] WorkspaceDataSource { get; set; }
        #endregion
        
        #region Parameter WorkspaceDescription
        /// <summary>
        /// <para>
        /// <para>A description for the workspace. This is used only to help you identify this workspace.</para><para>Pattern: <code>^[\\p{L}\\p{Z}\\p{N}\\p{P}]{0,2048}$</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkspaceDescription { get; set; }
        #endregion
        
        #region Parameter WorkspaceName
        /// <summary>
        /// <para>
        /// <para>The name for the workspace. It does not have to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkspaceName { get; set; }
        #endregion
        
        #region Parameter WorkspaceNotificationDestination
        /// <summary>
        /// <para>
        /// <para>Specify the Amazon Web Services notification channels that you plan to use in this
        /// workspace. Specifying these data sources here enables Amazon Managed Grafana to create
        /// IAM roles and permissions that allow Amazon Managed Grafana to use these channels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkspaceNotificationDestinations")]
        public System.String[] WorkspaceNotificationDestination { get; set; }
        #endregion
        
        #region Parameter WorkspaceOrganizationalUnit
        /// <summary>
        /// <para>
        /// <para>Specifies the organizational units that this workspace is allowed to use data sources
        /// from, if this workspace is in an account that is part of an organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkspaceOrganizationalUnits")]
        public System.String[] WorkspaceOrganizationalUnit { get; set; }
        #endregion
        
        #region Parameter WorkspaceRoleArn
        /// <summary>
        /// <para>
        /// <para>Specified the IAM role that grants permissions to the Amazon Web Services resources
        /// that the workspace will view data from, including both data sources and notification
        /// channels. You are responsible for managing the permissions for this role as new data
        /// sources or notification channels are added. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkspaceRoleArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive, user-provided identifier to ensure the idempotency of the
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Workspace'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedGrafana.Model.CreateWorkspaceResponse).
        /// Specifying the name of a property of type Amazon.ManagedGrafana.Model.CreateWorkspaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Workspace";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MGRFWorkspace (CreateWorkspace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ManagedGrafana.Model.CreateWorkspaceResponse, NewMGRFWorkspaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountAccessType = this.AccountAccessType;
            #if MODULAR
            if (this.AccountAccessType == null && ParameterWasBound(nameof(this.AccountAccessType)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountAccessType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AuthenticationProvider != null)
            {
                context.AuthenticationProvider = new List<System.String>(this.AuthenticationProvider);
            }
            #if MODULAR
            if (this.AuthenticationProvider == null && ParameterWasBound(nameof(this.AuthenticationProvider)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthenticationProvider which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Configuration = this.Configuration;
            if (this.NetworkAccessControl_PrefixListId != null)
            {
                context.NetworkAccessControl_PrefixListId = new List<System.String>(this.NetworkAccessControl_PrefixListId);
            }
            if (this.NetworkAccessControl_VpceId != null)
            {
                context.NetworkAccessControl_VpceId = new List<System.String>(this.NetworkAccessControl_VpceId);
            }
            context.OrganizationRoleName = this.OrganizationRoleName;
            context.PermissionType = this.PermissionType;
            #if MODULAR
            if (this.PermissionType == null && ParameterWasBound(nameof(this.PermissionType)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StackSetName = this.StackSetName;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            if (this.VpcConfiguration_SecurityGroupId != null)
            {
                context.VpcConfiguration_SecurityGroupId = new List<System.String>(this.VpcConfiguration_SecurityGroupId);
            }
            if (this.VpcConfiguration_SubnetId != null)
            {
                context.VpcConfiguration_SubnetId = new List<System.String>(this.VpcConfiguration_SubnetId);
            }
            if (this.WorkspaceDataSource != null)
            {
                context.WorkspaceDataSource = new List<System.String>(this.WorkspaceDataSource);
            }
            context.WorkspaceDescription = this.WorkspaceDescription;
            context.WorkspaceName = this.WorkspaceName;
            if (this.WorkspaceNotificationDestination != null)
            {
                context.WorkspaceNotificationDestination = new List<System.String>(this.WorkspaceNotificationDestination);
            }
            if (this.WorkspaceOrganizationalUnit != null)
            {
                context.WorkspaceOrganizationalUnit = new List<System.String>(this.WorkspaceOrganizationalUnit);
            }
            context.WorkspaceRoleArn = this.WorkspaceRoleArn;
            
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
            var request = new Amazon.ManagedGrafana.Model.CreateWorkspaceRequest();
            
            if (cmdletContext.AccountAccessType != null)
            {
                request.AccountAccessType = cmdletContext.AccountAccessType;
            }
            if (cmdletContext.AuthenticationProvider != null)
            {
                request.AuthenticationProviders = cmdletContext.AuthenticationProvider;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Configuration != null)
            {
                request.Configuration = cmdletContext.Configuration;
            }
            
             // populate NetworkAccessControl
            var requestNetworkAccessControlIsNull = true;
            request.NetworkAccessControl = new Amazon.ManagedGrafana.Model.NetworkAccessConfiguration();
            List<System.String> requestNetworkAccessControl_networkAccessControl_PrefixListId = null;
            if (cmdletContext.NetworkAccessControl_PrefixListId != null)
            {
                requestNetworkAccessControl_networkAccessControl_PrefixListId = cmdletContext.NetworkAccessControl_PrefixListId;
            }
            if (requestNetworkAccessControl_networkAccessControl_PrefixListId != null)
            {
                request.NetworkAccessControl.PrefixListIds = requestNetworkAccessControl_networkAccessControl_PrefixListId;
                requestNetworkAccessControlIsNull = false;
            }
            List<System.String> requestNetworkAccessControl_networkAccessControl_VpceId = null;
            if (cmdletContext.NetworkAccessControl_VpceId != null)
            {
                requestNetworkAccessControl_networkAccessControl_VpceId = cmdletContext.NetworkAccessControl_VpceId;
            }
            if (requestNetworkAccessControl_networkAccessControl_VpceId != null)
            {
                request.NetworkAccessControl.VpceIds = requestNetworkAccessControl_networkAccessControl_VpceId;
                requestNetworkAccessControlIsNull = false;
            }
             // determine if request.NetworkAccessControl should be set to null
            if (requestNetworkAccessControlIsNull)
            {
                request.NetworkAccessControl = null;
            }
            if (cmdletContext.OrganizationRoleName != null)
            {
                request.OrganizationRoleName = cmdletContext.OrganizationRoleName;
            }
            if (cmdletContext.PermissionType != null)
            {
                request.PermissionType = cmdletContext.PermissionType;
            }
            if (cmdletContext.StackSetName != null)
            {
                request.StackSetName = cmdletContext.StackSetName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate VpcConfiguration
            var requestVpcConfigurationIsNull = true;
            request.VpcConfiguration = new Amazon.ManagedGrafana.Model.VpcConfiguration();
            List<System.String> requestVpcConfiguration_vpcConfiguration_SecurityGroupId = null;
            if (cmdletContext.VpcConfiguration_SecurityGroupId != null)
            {
                requestVpcConfiguration_vpcConfiguration_SecurityGroupId = cmdletContext.VpcConfiguration_SecurityGroupId;
            }
            if (requestVpcConfiguration_vpcConfiguration_SecurityGroupId != null)
            {
                request.VpcConfiguration.SecurityGroupIds = requestVpcConfiguration_vpcConfiguration_SecurityGroupId;
                requestVpcConfigurationIsNull = false;
            }
            List<System.String> requestVpcConfiguration_vpcConfiguration_SubnetId = null;
            if (cmdletContext.VpcConfiguration_SubnetId != null)
            {
                requestVpcConfiguration_vpcConfiguration_SubnetId = cmdletContext.VpcConfiguration_SubnetId;
            }
            if (requestVpcConfiguration_vpcConfiguration_SubnetId != null)
            {
                request.VpcConfiguration.SubnetIds = requestVpcConfiguration_vpcConfiguration_SubnetId;
                requestVpcConfigurationIsNull = false;
            }
             // determine if request.VpcConfiguration should be set to null
            if (requestVpcConfigurationIsNull)
            {
                request.VpcConfiguration = null;
            }
            if (cmdletContext.WorkspaceDataSource != null)
            {
                request.WorkspaceDataSources = cmdletContext.WorkspaceDataSource;
            }
            if (cmdletContext.WorkspaceDescription != null)
            {
                request.WorkspaceDescription = cmdletContext.WorkspaceDescription;
            }
            if (cmdletContext.WorkspaceName != null)
            {
                request.WorkspaceName = cmdletContext.WorkspaceName;
            }
            if (cmdletContext.WorkspaceNotificationDestination != null)
            {
                request.WorkspaceNotificationDestinations = cmdletContext.WorkspaceNotificationDestination;
            }
            if (cmdletContext.WorkspaceOrganizationalUnit != null)
            {
                request.WorkspaceOrganizationalUnits = cmdletContext.WorkspaceOrganizationalUnit;
            }
            if (cmdletContext.WorkspaceRoleArn != null)
            {
                request.WorkspaceRoleArn = cmdletContext.WorkspaceRoleArn;
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
        
        private Amazon.ManagedGrafana.Model.CreateWorkspaceResponse CallAWSServiceOperation(IAmazonManagedGrafana client, Amazon.ManagedGrafana.Model.CreateWorkspaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Grafana", "CreateWorkspace");
            try
            {
                #if DESKTOP
                return client.CreateWorkspace(request);
                #elif CORECLR
                return client.CreateWorkspaceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ManagedGrafana.AccountAccessType AccountAccessType { get; set; }
            public List<System.String> AuthenticationProvider { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Configuration { get; set; }
            public List<System.String> NetworkAccessControl_PrefixListId { get; set; }
            public List<System.String> NetworkAccessControl_VpceId { get; set; }
            public System.String OrganizationRoleName { get; set; }
            public Amazon.ManagedGrafana.PermissionType PermissionType { get; set; }
            public System.String StackSetName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<System.String> VpcConfiguration_SecurityGroupId { get; set; }
            public List<System.String> VpcConfiguration_SubnetId { get; set; }
            public List<System.String> WorkspaceDataSource { get; set; }
            public System.String WorkspaceDescription { get; set; }
            public System.String WorkspaceName { get; set; }
            public List<System.String> WorkspaceNotificationDestination { get; set; }
            public List<System.String> WorkspaceOrganizationalUnit { get; set; }
            public System.String WorkspaceRoleArn { get; set; }
            public System.Func<Amazon.ManagedGrafana.Model.CreateWorkspaceResponse, NewMGRFWorkspaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Workspace;
        }
        
    }
}
