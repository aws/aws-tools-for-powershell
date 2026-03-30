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
    /// Adds a specific service association to an AgentSpace. It overwrites the existing association
    /// of the same service. Returns 201 Created on success.
    /// </summary>
    [Cmdlet("Add", "DOPSService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DevOpsAgent.Model.AssociateServiceResponse")]
    [AWSCmdlet("Calls the AWS DevOps Agent Service AssociateService API operation.", Operation = new[] {"AssociateService"}, SelectReturnType = typeof(Amazon.DevOpsAgent.Model.AssociateServiceResponse))]
    [AWSCmdletOutput("Amazon.DevOpsAgent.Model.AssociateServiceResponse",
        "This cmdlet returns an Amazon.DevOpsAgent.Model.AssociateServiceResponse object containing multiple properties."
    )]
    public partial class AddDOPSServiceCmdlet : AmazonDevOpsAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Configuration_Aws_AccountId
        /// <summary>
        /// <para>
        /// <para>AWS Account Id corresponding to provided resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Aws_AccountId { get; set; }
        #endregion
        
        #region Parameter Configuration_Mcpservernewrelic_AccountId
        /// <summary>
        /// <para>
        /// <para>New Relic Account ID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Mcpservernewrelic_AccountId { get; set; }
        #endregion
        
        #region Parameter Configuration_SourceAws_AccountId
        /// <summary>
        /// <para>
        /// <para>AWS Account Id corresponding to provided resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_SourceAws_AccountId { get; set; }
        #endregion
        
        #region Parameter Configuration_Aws_AccountType
        /// <summary>
        /// <para>
        /// <para>Account Type 'monitor' for AIDevOps monitoring.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DevOpsAgent.MonitorAccountType")]
        public Amazon.DevOpsAgent.MonitorAccountType Configuration_Aws_AccountType { get; set; }
        #endregion
        
        #region Parameter Configuration_SourceAws_AccountType
        /// <summary>
        /// <para>
        /// <para>Account Type 'source' for AIDevOps monitoring.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DevOpsAgent.SourceAccountType")]
        public Amazon.DevOpsAgent.SourceAccountType Configuration_SourceAws_AccountType { get; set; }
        #endregion
        
        #region Parameter AgentSpaceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the AgentSpace</para>
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
        public System.String AgentSpaceId { get; set; }
        #endregion
        
        #region Parameter Configuration_Aws_AssumableRoleArn
        /// <summary>
        /// <para>
        /// <para>Role ARN to be assumed by AIDevOps to operate on behalf of customer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Aws_AssumableRoleArn { get; set; }
        #endregion
        
        #region Parameter Configuration_SourceAws_AssumableRoleArn
        /// <summary>
        /// <para>
        /// <para>Role ARN to be assumed by AIDevOps to operate on behalf of customer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_SourceAws_AssumableRoleArn { get; set; }
        #endregion
        
        #region Parameter Configuration_Servicenow_AuthScope
        /// <summary>
        /// <para>
        /// <para>Scoped down authentication scopes for fine grained control</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Servicenow_AuthScopes")]
        public System.String[] Configuration_Servicenow_AuthScope { get; set; }
        #endregion
        
        #region Parameter Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelId
        /// <summary>
        /// <para>
        /// <para>MS Teams Channel ID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelId { get; set; }
        #endregion
        
        #region Parameter Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelId
        /// <summary>
        /// <para>
        /// <para>MS Teams Channel ID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelId { get; set; }
        #endregion
        
        #region Parameter Configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelId
        /// <summary>
        /// <para>
        /// <para>Slack channel ID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelId { get; set; }
        #endregion
        
        #region Parameter Configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelId
        /// <summary>
        /// <para>
        /// <para>Slack channel ID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelId { get; set; }
        #endregion
        
        #region Parameter Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelName
        /// <summary>
        /// <para>
        /// <para>MS Teams channel name</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelName { get; set; }
        #endregion
        
        #region Parameter Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelName
        /// <summary>
        /// <para>
        /// <para>MS Teams channel name</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelName { get; set; }
        #endregion
        
        #region Parameter Configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelName
        /// <summary>
        /// <para>
        /// <para>Slack channel name</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelName { get; set; }
        #endregion
        
        #region Parameter Configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelName
        /// <summary>
        /// <para>
        /// <para>Slack channel name</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelName { get; set; }
        #endregion
        
        #region Parameter Configuration_Pagerduty_CustomerEmail
        /// <summary>
        /// <para>
        /// <para>Email to be used in Pagerduty API header</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Pagerduty_CustomerEmail { get; set; }
        #endregion
        
        #region Parameter Configuration_Mcpservergrafana_Endpoint
        /// <summary>
        /// <para>
        /// <para>Grafana instance URL (e.g., https://your-instance.grafana.net)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Mcpservergrafana_Endpoint { get; set; }
        #endregion
        
        #region Parameter Configuration_Mcpservernewrelic_Endpoint
        /// <summary>
        /// <para>
        /// <para>MCP server endpoint URL (e.g., https://mcp.newrelic.com/mcp/)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Mcpservernewrelic_Endpoint { get; set; }
        #endregion
        
        #region Parameter Configuration_Dynatrace_EnvId
        /// <summary>
        /// <para>
        /// <para>Dynatrace environment id</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Dynatrace_EnvId { get; set; }
        #endregion
        
        #region Parameter Configuration_EventChannel
        /// <summary>
        /// <para>
        /// <para>Event Channel instance integration configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DevOpsAgent.Model.EventChannelConfiguration Configuration_EventChannel { get; set; }
        #endregion
        
        #region Parameter Configuration_SourceAws_ExternalId
        /// <summary>
        /// <para>
        /// <para>External ID for additional security when assuming the role. Used to prevent the confused
        /// deputy problem.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_SourceAws_ExternalId { get; set; }
        #endregion
        
        #region Parameter Configuration_Servicenow_InstanceId
        /// <summary>
        /// <para>
        /// <para>ServiceNow instance ID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Servicenow_InstanceId { get; set; }
        #endregion
        
        #region Parameter Configuration_Github_InstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>GitHub instance identifier (e.g., github.com or github.enterprise.com)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Github_InstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter Configuration_Gitlab_InstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>GitLab instance identifier (e.g., gitlab.com or e2e.gamma.dev.us-east-1.gitlab.falco.ai.aws.dev)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Gitlab_InstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter Configuration_Mcpservergrafana_OrganizationId
        /// <summary>
        /// <para>
        /// <para>The Grafana organization ID that can be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Mcpservergrafana_OrganizationId { get; set; }
        #endregion
        
        #region Parameter Configuration_Azuredevops_OrganizationName
        /// <summary>
        /// <para>
        /// <para>Azure DevOps organization name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Azuredevops_OrganizationName { get; set; }
        #endregion
        
        #region Parameter Configuration_Github_Owner
        /// <summary>
        /// <para>
        /// <para>The GitHub repository owner name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Github_Owner { get; set; }
        #endregion
        
        #region Parameter Configuration_Github_OwnerType
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DevOpsAgent.GithubRepoOwnerType")]
        public Amazon.DevOpsAgent.GithubRepoOwnerType Configuration_Github_OwnerType { get; set; }
        #endregion
        
        #region Parameter Configuration_Azuredevops_ProjectId
        /// <summary>
        /// <para>
        /// <para>Azure DevOps project ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Azuredevops_ProjectId { get; set; }
        #endregion
        
        #region Parameter Configuration_Gitlab_ProjectId
        /// <summary>
        /// <para>
        /// <para>GitLab numeric project ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Gitlab_ProjectId { get; set; }
        #endregion
        
        #region Parameter Configuration_Azuredevops_ProjectName
        /// <summary>
        /// <para>
        /// <para>Azure DevOps project name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Azuredevops_ProjectName { get; set; }
        #endregion
        
        #region Parameter Configuration_Gitlab_ProjectPath
        /// <summary>
        /// <para>
        /// <para>Full GitLab project path (e.g., namespace/project-name).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Gitlab_ProjectPath { get; set; }
        #endregion
        
        #region Parameter Configuration_Github_RepoId
        /// <summary>
        /// <para>
        /// <para>Associated Github repo ID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Github_RepoId { get; set; }
        #endregion
        
        #region Parameter Configuration_Github_RepoName
        /// <summary>
        /// <para>
        /// <para>Associated Github repo name</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Github_RepoName { get; set; }
        #endregion
        
        #region Parameter Configuration_Dynatrace_Resource
        /// <summary>
        /// <para>
        /// <para>List of Dynatrace resources to monitor</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Dynatrace_Resources")]
        public System.String[] Configuration_Dynatrace_Resource { get; set; }
        #endregion
        
        #region Parameter ServiceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the service.</para>
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
        public System.String ServiceId { get; set; }
        #endregion
        
        #region Parameter Configuration_Pagerduty_Service
        /// <summary>
        /// <para>
        /// <para>List of Pagerduty service available for the association.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Pagerduty_Services")]
        public System.String[] Configuration_Pagerduty_Service { get; set; }
        #endregion
        
        #region Parameter Configuration_Azure_SubscriptionId
        /// <summary>
        /// <para>
        /// <para>Azure subscription ID corresponding to provided resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Azure_SubscriptionId { get; set; }
        #endregion
        
        #region Parameter Configuration_Msteams_TeamId
        /// <summary>
        /// <para>
        /// <para>Associated MS Teams teams ID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Msteams_TeamId { get; set; }
        #endregion
        
        #region Parameter Configuration_Msteams_TeamName
        /// <summary>
        /// <para>
        /// <para>Associated MS Teams team name</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Msteams_TeamName { get; set; }
        #endregion
        
        #region Parameter Configuration_Mcpservergrafana_Tool
        /// <summary>
        /// <para>
        /// <para>List of MCP tools that can be used.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Mcpservergrafana_Tools")]
        public System.String[] Configuration_Mcpservergrafana_Tool { get; set; }
        #endregion
        
        #region Parameter Configuration_Slack_WorkspaceId
        /// <summary>
        /// <para>
        /// <para>Associated Slack workspace ID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Slack_WorkspaceId { get; set; }
        #endregion
        
        #region Parameter Configuration_Slack_WorkspaceName
        /// <summary>
        /// <para>
        /// <para>Associated Slack workspace name</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Slack_WorkspaceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsAgent.Model.AssociateServiceResponse).
        /// Specifying the name of a property of type Amazon.DevOpsAgent.Model.AssociateServiceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-DOPSService (AssociateService)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsAgent.Model.AssociateServiceResponse, AddDOPSServiceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentSpaceId = this.AgentSpaceId;
            #if MODULAR
            if (this.AgentSpaceId == null && ParameterWasBound(nameof(this.AgentSpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentSpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Configuration_Aws_AccountId = this.Configuration_Aws_AccountId;
            context.Configuration_Aws_AccountType = this.Configuration_Aws_AccountType;
            context.Configuration_Aws_AssumableRoleArn = this.Configuration_Aws_AssumableRoleArn;
            context.Configuration_Azure_SubscriptionId = this.Configuration_Azure_SubscriptionId;
            context.Configuration_Azuredevops_OrganizationName = this.Configuration_Azuredevops_OrganizationName;
            context.Configuration_Azuredevops_ProjectId = this.Configuration_Azuredevops_ProjectId;
            context.Configuration_Azuredevops_ProjectName = this.Configuration_Azuredevops_ProjectName;
            context.Configuration_Dynatrace_EnvId = this.Configuration_Dynatrace_EnvId;
            if (this.Configuration_Dynatrace_Resource != null)
            {
                context.Configuration_Dynatrace_Resource = new List<System.String>(this.Configuration_Dynatrace_Resource);
            }
            context.Configuration_EventChannel = this.Configuration_EventChannel;
            context.Configuration_Github_InstanceIdentifier = this.Configuration_Github_InstanceIdentifier;
            context.Configuration_Github_Owner = this.Configuration_Github_Owner;
            context.Configuration_Github_OwnerType = this.Configuration_Github_OwnerType;
            context.Configuration_Github_RepoId = this.Configuration_Github_RepoId;
            context.Configuration_Github_RepoName = this.Configuration_Github_RepoName;
            context.Configuration_Gitlab_InstanceIdentifier = this.Configuration_Gitlab_InstanceIdentifier;
            context.Configuration_Gitlab_ProjectId = this.Configuration_Gitlab_ProjectId;
            context.Configuration_Gitlab_ProjectPath = this.Configuration_Gitlab_ProjectPath;
            context.Configuration_Mcpservergrafana_Endpoint = this.Configuration_Mcpservergrafana_Endpoint;
            context.Configuration_Mcpservergrafana_OrganizationId = this.Configuration_Mcpservergrafana_OrganizationId;
            if (this.Configuration_Mcpservergrafana_Tool != null)
            {
                context.Configuration_Mcpservergrafana_Tool = new List<System.String>(this.Configuration_Mcpservergrafana_Tool);
            }
            context.Configuration_Mcpservernewrelic_AccountId = this.Configuration_Mcpservernewrelic_AccountId;
            context.Configuration_Mcpservernewrelic_Endpoint = this.Configuration_Mcpservernewrelic_Endpoint;
            context.Configuration_Msteams_TeamId = this.Configuration_Msteams_TeamId;
            context.Configuration_Msteams_TeamName = this.Configuration_Msteams_TeamName;
            context.Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelId = this.Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelId;
            context.Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelName = this.Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelName;
            context.Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelId = this.Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelId;
            context.Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelName = this.Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelName;
            context.Configuration_Pagerduty_CustomerEmail = this.Configuration_Pagerduty_CustomerEmail;
            if (this.Configuration_Pagerduty_Service != null)
            {
                context.Configuration_Pagerduty_Service = new List<System.String>(this.Configuration_Pagerduty_Service);
            }
            if (this.Configuration_Servicenow_AuthScope != null)
            {
                context.Configuration_Servicenow_AuthScope = new List<System.String>(this.Configuration_Servicenow_AuthScope);
            }
            context.Configuration_Servicenow_InstanceId = this.Configuration_Servicenow_InstanceId;
            context.Configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelId = this.Configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelId;
            context.Configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelName = this.Configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelName;
            context.Configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelId = this.Configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelId;
            context.Configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelName = this.Configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelName;
            context.Configuration_Slack_WorkspaceId = this.Configuration_Slack_WorkspaceId;
            context.Configuration_Slack_WorkspaceName = this.Configuration_Slack_WorkspaceName;
            context.Configuration_SourceAws_AccountId = this.Configuration_SourceAws_AccountId;
            context.Configuration_SourceAws_AccountType = this.Configuration_SourceAws_AccountType;
            context.Configuration_SourceAws_AssumableRoleArn = this.Configuration_SourceAws_AssumableRoleArn;
            context.Configuration_SourceAws_ExternalId = this.Configuration_SourceAws_ExternalId;
            context.ServiceId = this.ServiceId;
            #if MODULAR
            if (this.ServiceId == null && ParameterWasBound(nameof(this.ServiceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DevOpsAgent.Model.AssociateServiceRequest();
            
            if (cmdletContext.AgentSpaceId != null)
            {
                request.AgentSpaceId = cmdletContext.AgentSpaceId;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.DevOpsAgent.Model.ServiceConfiguration();
            Amazon.DevOpsAgent.Model.EventChannelConfiguration requestConfiguration_configuration_EventChannel = null;
            if (cmdletContext.Configuration_EventChannel != null)
            {
                requestConfiguration_configuration_EventChannel = cmdletContext.Configuration_EventChannel;
            }
            if (requestConfiguration_configuration_EventChannel != null)
            {
                request.Configuration.EventChannel = requestConfiguration_configuration_EventChannel;
                requestConfigurationIsNull = false;
            }
            Amazon.DevOpsAgent.Model.AzureConfiguration requestConfiguration_configuration_Azure = null;
            
             // populate Azure
            var requestConfiguration_configuration_AzureIsNull = true;
            requestConfiguration_configuration_Azure = new Amazon.DevOpsAgent.Model.AzureConfiguration();
            System.String requestConfiguration_configuration_Azure_configuration_Azure_SubscriptionId = null;
            if (cmdletContext.Configuration_Azure_SubscriptionId != null)
            {
                requestConfiguration_configuration_Azure_configuration_Azure_SubscriptionId = cmdletContext.Configuration_Azure_SubscriptionId;
            }
            if (requestConfiguration_configuration_Azure_configuration_Azure_SubscriptionId != null)
            {
                requestConfiguration_configuration_Azure.SubscriptionId = requestConfiguration_configuration_Azure_configuration_Azure_SubscriptionId;
                requestConfiguration_configuration_AzureIsNull = false;
            }
             // determine if requestConfiguration_configuration_Azure should be set to null
            if (requestConfiguration_configuration_AzureIsNull)
            {
                requestConfiguration_configuration_Azure = null;
            }
            if (requestConfiguration_configuration_Azure != null)
            {
                request.Configuration.Azure = requestConfiguration_configuration_Azure;
                requestConfigurationIsNull = false;
            }
            Amazon.DevOpsAgent.Model.DynatraceConfiguration requestConfiguration_configuration_Dynatrace = null;
            
             // populate Dynatrace
            var requestConfiguration_configuration_DynatraceIsNull = true;
            requestConfiguration_configuration_Dynatrace = new Amazon.DevOpsAgent.Model.DynatraceConfiguration();
            System.String requestConfiguration_configuration_Dynatrace_configuration_Dynatrace_EnvId = null;
            if (cmdletContext.Configuration_Dynatrace_EnvId != null)
            {
                requestConfiguration_configuration_Dynatrace_configuration_Dynatrace_EnvId = cmdletContext.Configuration_Dynatrace_EnvId;
            }
            if (requestConfiguration_configuration_Dynatrace_configuration_Dynatrace_EnvId != null)
            {
                requestConfiguration_configuration_Dynatrace.EnvId = requestConfiguration_configuration_Dynatrace_configuration_Dynatrace_EnvId;
                requestConfiguration_configuration_DynatraceIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_Dynatrace_configuration_Dynatrace_Resource = null;
            if (cmdletContext.Configuration_Dynatrace_Resource != null)
            {
                requestConfiguration_configuration_Dynatrace_configuration_Dynatrace_Resource = cmdletContext.Configuration_Dynatrace_Resource;
            }
            if (requestConfiguration_configuration_Dynatrace_configuration_Dynatrace_Resource != null)
            {
                requestConfiguration_configuration_Dynatrace.Resources = requestConfiguration_configuration_Dynatrace_configuration_Dynatrace_Resource;
                requestConfiguration_configuration_DynatraceIsNull = false;
            }
             // determine if requestConfiguration_configuration_Dynatrace should be set to null
            if (requestConfiguration_configuration_DynatraceIsNull)
            {
                requestConfiguration_configuration_Dynatrace = null;
            }
            if (requestConfiguration_configuration_Dynatrace != null)
            {
                request.Configuration.Dynatrace = requestConfiguration_configuration_Dynatrace;
                requestConfigurationIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerNewRelicConfiguration requestConfiguration_configuration_Mcpservernewrelic = null;
            
             // populate Mcpservernewrelic
            var requestConfiguration_configuration_McpservernewrelicIsNull = true;
            requestConfiguration_configuration_Mcpservernewrelic = new Amazon.DevOpsAgent.Model.MCPServerNewRelicConfiguration();
            System.String requestConfiguration_configuration_Mcpservernewrelic_configuration_Mcpservernewrelic_AccountId = null;
            if (cmdletContext.Configuration_Mcpservernewrelic_AccountId != null)
            {
                requestConfiguration_configuration_Mcpservernewrelic_configuration_Mcpservernewrelic_AccountId = cmdletContext.Configuration_Mcpservernewrelic_AccountId;
            }
            if (requestConfiguration_configuration_Mcpservernewrelic_configuration_Mcpservernewrelic_AccountId != null)
            {
                requestConfiguration_configuration_Mcpservernewrelic.AccountId = requestConfiguration_configuration_Mcpservernewrelic_configuration_Mcpservernewrelic_AccountId;
                requestConfiguration_configuration_McpservernewrelicIsNull = false;
            }
            System.String requestConfiguration_configuration_Mcpservernewrelic_configuration_Mcpservernewrelic_Endpoint = null;
            if (cmdletContext.Configuration_Mcpservernewrelic_Endpoint != null)
            {
                requestConfiguration_configuration_Mcpservernewrelic_configuration_Mcpservernewrelic_Endpoint = cmdletContext.Configuration_Mcpservernewrelic_Endpoint;
            }
            if (requestConfiguration_configuration_Mcpservernewrelic_configuration_Mcpservernewrelic_Endpoint != null)
            {
                requestConfiguration_configuration_Mcpservernewrelic.Endpoint = requestConfiguration_configuration_Mcpservernewrelic_configuration_Mcpservernewrelic_Endpoint;
                requestConfiguration_configuration_McpservernewrelicIsNull = false;
            }
             // determine if requestConfiguration_configuration_Mcpservernewrelic should be set to null
            if (requestConfiguration_configuration_McpservernewrelicIsNull)
            {
                requestConfiguration_configuration_Mcpservernewrelic = null;
            }
            if (requestConfiguration_configuration_Mcpservernewrelic != null)
            {
                request.Configuration.Mcpservernewrelic = requestConfiguration_configuration_Mcpservernewrelic;
                requestConfigurationIsNull = false;
            }
            Amazon.DevOpsAgent.Model.PagerDutyConfiguration requestConfiguration_configuration_Pagerduty = null;
            
             // populate Pagerduty
            var requestConfiguration_configuration_PagerdutyIsNull = true;
            requestConfiguration_configuration_Pagerduty = new Amazon.DevOpsAgent.Model.PagerDutyConfiguration();
            System.String requestConfiguration_configuration_Pagerduty_configuration_Pagerduty_CustomerEmail = null;
            if (cmdletContext.Configuration_Pagerduty_CustomerEmail != null)
            {
                requestConfiguration_configuration_Pagerduty_configuration_Pagerduty_CustomerEmail = cmdletContext.Configuration_Pagerduty_CustomerEmail;
            }
            if (requestConfiguration_configuration_Pagerduty_configuration_Pagerduty_CustomerEmail != null)
            {
                requestConfiguration_configuration_Pagerduty.CustomerEmail = requestConfiguration_configuration_Pagerduty_configuration_Pagerduty_CustomerEmail;
                requestConfiguration_configuration_PagerdutyIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_Pagerduty_configuration_Pagerduty_Service = null;
            if (cmdletContext.Configuration_Pagerduty_Service != null)
            {
                requestConfiguration_configuration_Pagerduty_configuration_Pagerduty_Service = cmdletContext.Configuration_Pagerduty_Service;
            }
            if (requestConfiguration_configuration_Pagerduty_configuration_Pagerduty_Service != null)
            {
                requestConfiguration_configuration_Pagerduty.Services = requestConfiguration_configuration_Pagerduty_configuration_Pagerduty_Service;
                requestConfiguration_configuration_PagerdutyIsNull = false;
            }
             // determine if requestConfiguration_configuration_Pagerduty should be set to null
            if (requestConfiguration_configuration_PagerdutyIsNull)
            {
                requestConfiguration_configuration_Pagerduty = null;
            }
            if (requestConfiguration_configuration_Pagerduty != null)
            {
                request.Configuration.Pagerduty = requestConfiguration_configuration_Pagerduty;
                requestConfigurationIsNull = false;
            }
            Amazon.DevOpsAgent.Model.ServiceNowConfiguration requestConfiguration_configuration_Servicenow = null;
            
             // populate Servicenow
            var requestConfiguration_configuration_ServicenowIsNull = true;
            requestConfiguration_configuration_Servicenow = new Amazon.DevOpsAgent.Model.ServiceNowConfiguration();
            List<System.String> requestConfiguration_configuration_Servicenow_configuration_Servicenow_AuthScope = null;
            if (cmdletContext.Configuration_Servicenow_AuthScope != null)
            {
                requestConfiguration_configuration_Servicenow_configuration_Servicenow_AuthScope = cmdletContext.Configuration_Servicenow_AuthScope;
            }
            if (requestConfiguration_configuration_Servicenow_configuration_Servicenow_AuthScope != null)
            {
                requestConfiguration_configuration_Servicenow.AuthScopes = requestConfiguration_configuration_Servicenow_configuration_Servicenow_AuthScope;
                requestConfiguration_configuration_ServicenowIsNull = false;
            }
            System.String requestConfiguration_configuration_Servicenow_configuration_Servicenow_InstanceId = null;
            if (cmdletContext.Configuration_Servicenow_InstanceId != null)
            {
                requestConfiguration_configuration_Servicenow_configuration_Servicenow_InstanceId = cmdletContext.Configuration_Servicenow_InstanceId;
            }
            if (requestConfiguration_configuration_Servicenow_configuration_Servicenow_InstanceId != null)
            {
                requestConfiguration_configuration_Servicenow.InstanceId = requestConfiguration_configuration_Servicenow_configuration_Servicenow_InstanceId;
                requestConfiguration_configuration_ServicenowIsNull = false;
            }
             // determine if requestConfiguration_configuration_Servicenow should be set to null
            if (requestConfiguration_configuration_ServicenowIsNull)
            {
                requestConfiguration_configuration_Servicenow = null;
            }
            if (requestConfiguration_configuration_Servicenow != null)
            {
                request.Configuration.Servicenow = requestConfiguration_configuration_Servicenow;
                requestConfigurationIsNull = false;
            }
            Amazon.DevOpsAgent.Model.AWSConfiguration requestConfiguration_configuration_Aws = null;
            
             // populate Aws
            var requestConfiguration_configuration_AwsIsNull = true;
            requestConfiguration_configuration_Aws = new Amazon.DevOpsAgent.Model.AWSConfiguration();
            System.String requestConfiguration_configuration_Aws_configuration_Aws_AccountId = null;
            if (cmdletContext.Configuration_Aws_AccountId != null)
            {
                requestConfiguration_configuration_Aws_configuration_Aws_AccountId = cmdletContext.Configuration_Aws_AccountId;
            }
            if (requestConfiguration_configuration_Aws_configuration_Aws_AccountId != null)
            {
                requestConfiguration_configuration_Aws.AccountId = requestConfiguration_configuration_Aws_configuration_Aws_AccountId;
                requestConfiguration_configuration_AwsIsNull = false;
            }
            Amazon.DevOpsAgent.MonitorAccountType requestConfiguration_configuration_Aws_configuration_Aws_AccountType = null;
            if (cmdletContext.Configuration_Aws_AccountType != null)
            {
                requestConfiguration_configuration_Aws_configuration_Aws_AccountType = cmdletContext.Configuration_Aws_AccountType;
            }
            if (requestConfiguration_configuration_Aws_configuration_Aws_AccountType != null)
            {
                requestConfiguration_configuration_Aws.AccountType = requestConfiguration_configuration_Aws_configuration_Aws_AccountType;
                requestConfiguration_configuration_AwsIsNull = false;
            }
            System.String requestConfiguration_configuration_Aws_configuration_Aws_AssumableRoleArn = null;
            if (cmdletContext.Configuration_Aws_AssumableRoleArn != null)
            {
                requestConfiguration_configuration_Aws_configuration_Aws_AssumableRoleArn = cmdletContext.Configuration_Aws_AssumableRoleArn;
            }
            if (requestConfiguration_configuration_Aws_configuration_Aws_AssumableRoleArn != null)
            {
                requestConfiguration_configuration_Aws.AssumableRoleArn = requestConfiguration_configuration_Aws_configuration_Aws_AssumableRoleArn;
                requestConfiguration_configuration_AwsIsNull = false;
            }
             // determine if requestConfiguration_configuration_Aws should be set to null
            if (requestConfiguration_configuration_AwsIsNull)
            {
                requestConfiguration_configuration_Aws = null;
            }
            if (requestConfiguration_configuration_Aws != null)
            {
                request.Configuration.Aws = requestConfiguration_configuration_Aws;
                requestConfigurationIsNull = false;
            }
            Amazon.DevOpsAgent.Model.AzureDevOpsConfiguration requestConfiguration_configuration_Azuredevops = null;
            
             // populate Azuredevops
            var requestConfiguration_configuration_AzuredevopsIsNull = true;
            requestConfiguration_configuration_Azuredevops = new Amazon.DevOpsAgent.Model.AzureDevOpsConfiguration();
            System.String requestConfiguration_configuration_Azuredevops_configuration_Azuredevops_OrganizationName = null;
            if (cmdletContext.Configuration_Azuredevops_OrganizationName != null)
            {
                requestConfiguration_configuration_Azuredevops_configuration_Azuredevops_OrganizationName = cmdletContext.Configuration_Azuredevops_OrganizationName;
            }
            if (requestConfiguration_configuration_Azuredevops_configuration_Azuredevops_OrganizationName != null)
            {
                requestConfiguration_configuration_Azuredevops.OrganizationName = requestConfiguration_configuration_Azuredevops_configuration_Azuredevops_OrganizationName;
                requestConfiguration_configuration_AzuredevopsIsNull = false;
            }
            System.String requestConfiguration_configuration_Azuredevops_configuration_Azuredevops_ProjectId = null;
            if (cmdletContext.Configuration_Azuredevops_ProjectId != null)
            {
                requestConfiguration_configuration_Azuredevops_configuration_Azuredevops_ProjectId = cmdletContext.Configuration_Azuredevops_ProjectId;
            }
            if (requestConfiguration_configuration_Azuredevops_configuration_Azuredevops_ProjectId != null)
            {
                requestConfiguration_configuration_Azuredevops.ProjectId = requestConfiguration_configuration_Azuredevops_configuration_Azuredevops_ProjectId;
                requestConfiguration_configuration_AzuredevopsIsNull = false;
            }
            System.String requestConfiguration_configuration_Azuredevops_configuration_Azuredevops_ProjectName = null;
            if (cmdletContext.Configuration_Azuredevops_ProjectName != null)
            {
                requestConfiguration_configuration_Azuredevops_configuration_Azuredevops_ProjectName = cmdletContext.Configuration_Azuredevops_ProjectName;
            }
            if (requestConfiguration_configuration_Azuredevops_configuration_Azuredevops_ProjectName != null)
            {
                requestConfiguration_configuration_Azuredevops.ProjectName = requestConfiguration_configuration_Azuredevops_configuration_Azuredevops_ProjectName;
                requestConfiguration_configuration_AzuredevopsIsNull = false;
            }
             // determine if requestConfiguration_configuration_Azuredevops should be set to null
            if (requestConfiguration_configuration_AzuredevopsIsNull)
            {
                requestConfiguration_configuration_Azuredevops = null;
            }
            if (requestConfiguration_configuration_Azuredevops != null)
            {
                request.Configuration.Azuredevops = requestConfiguration_configuration_Azuredevops;
                requestConfigurationIsNull = false;
            }
            Amazon.DevOpsAgent.Model.GitLabConfiguration requestConfiguration_configuration_Gitlab = null;
            
             // populate Gitlab
            var requestConfiguration_configuration_GitlabIsNull = true;
            requestConfiguration_configuration_Gitlab = new Amazon.DevOpsAgent.Model.GitLabConfiguration();
            System.String requestConfiguration_configuration_Gitlab_configuration_Gitlab_InstanceIdentifier = null;
            if (cmdletContext.Configuration_Gitlab_InstanceIdentifier != null)
            {
                requestConfiguration_configuration_Gitlab_configuration_Gitlab_InstanceIdentifier = cmdletContext.Configuration_Gitlab_InstanceIdentifier;
            }
            if (requestConfiguration_configuration_Gitlab_configuration_Gitlab_InstanceIdentifier != null)
            {
                requestConfiguration_configuration_Gitlab.InstanceIdentifier = requestConfiguration_configuration_Gitlab_configuration_Gitlab_InstanceIdentifier;
                requestConfiguration_configuration_GitlabIsNull = false;
            }
            System.String requestConfiguration_configuration_Gitlab_configuration_Gitlab_ProjectId = null;
            if (cmdletContext.Configuration_Gitlab_ProjectId != null)
            {
                requestConfiguration_configuration_Gitlab_configuration_Gitlab_ProjectId = cmdletContext.Configuration_Gitlab_ProjectId;
            }
            if (requestConfiguration_configuration_Gitlab_configuration_Gitlab_ProjectId != null)
            {
                requestConfiguration_configuration_Gitlab.ProjectId = requestConfiguration_configuration_Gitlab_configuration_Gitlab_ProjectId;
                requestConfiguration_configuration_GitlabIsNull = false;
            }
            System.String requestConfiguration_configuration_Gitlab_configuration_Gitlab_ProjectPath = null;
            if (cmdletContext.Configuration_Gitlab_ProjectPath != null)
            {
                requestConfiguration_configuration_Gitlab_configuration_Gitlab_ProjectPath = cmdletContext.Configuration_Gitlab_ProjectPath;
            }
            if (requestConfiguration_configuration_Gitlab_configuration_Gitlab_ProjectPath != null)
            {
                requestConfiguration_configuration_Gitlab.ProjectPath = requestConfiguration_configuration_Gitlab_configuration_Gitlab_ProjectPath;
                requestConfiguration_configuration_GitlabIsNull = false;
            }
             // determine if requestConfiguration_configuration_Gitlab should be set to null
            if (requestConfiguration_configuration_GitlabIsNull)
            {
                requestConfiguration_configuration_Gitlab = null;
            }
            if (requestConfiguration_configuration_Gitlab != null)
            {
                request.Configuration.Gitlab = requestConfiguration_configuration_Gitlab;
                requestConfigurationIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MCPServerGrafanaConfiguration requestConfiguration_configuration_Mcpservergrafana = null;
            
             // populate Mcpservergrafana
            var requestConfiguration_configuration_McpservergrafanaIsNull = true;
            requestConfiguration_configuration_Mcpservergrafana = new Amazon.DevOpsAgent.Model.MCPServerGrafanaConfiguration();
            System.String requestConfiguration_configuration_Mcpservergrafana_configuration_Mcpservergrafana_Endpoint = null;
            if (cmdletContext.Configuration_Mcpservergrafana_Endpoint != null)
            {
                requestConfiguration_configuration_Mcpservergrafana_configuration_Mcpservergrafana_Endpoint = cmdletContext.Configuration_Mcpservergrafana_Endpoint;
            }
            if (requestConfiguration_configuration_Mcpservergrafana_configuration_Mcpservergrafana_Endpoint != null)
            {
                requestConfiguration_configuration_Mcpservergrafana.Endpoint = requestConfiguration_configuration_Mcpservergrafana_configuration_Mcpservergrafana_Endpoint;
                requestConfiguration_configuration_McpservergrafanaIsNull = false;
            }
            System.String requestConfiguration_configuration_Mcpservergrafana_configuration_Mcpservergrafana_OrganizationId = null;
            if (cmdletContext.Configuration_Mcpservergrafana_OrganizationId != null)
            {
                requestConfiguration_configuration_Mcpservergrafana_configuration_Mcpservergrafana_OrganizationId = cmdletContext.Configuration_Mcpservergrafana_OrganizationId;
            }
            if (requestConfiguration_configuration_Mcpservergrafana_configuration_Mcpservergrafana_OrganizationId != null)
            {
                requestConfiguration_configuration_Mcpservergrafana.OrganizationId = requestConfiguration_configuration_Mcpservergrafana_configuration_Mcpservergrafana_OrganizationId;
                requestConfiguration_configuration_McpservergrafanaIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_Mcpservergrafana_configuration_Mcpservergrafana_Tool = null;
            if (cmdletContext.Configuration_Mcpservergrafana_Tool != null)
            {
                requestConfiguration_configuration_Mcpservergrafana_configuration_Mcpservergrafana_Tool = cmdletContext.Configuration_Mcpservergrafana_Tool;
            }
            if (requestConfiguration_configuration_Mcpservergrafana_configuration_Mcpservergrafana_Tool != null)
            {
                requestConfiguration_configuration_Mcpservergrafana.Tools = requestConfiguration_configuration_Mcpservergrafana_configuration_Mcpservergrafana_Tool;
                requestConfiguration_configuration_McpservergrafanaIsNull = false;
            }
             // determine if requestConfiguration_configuration_Mcpservergrafana should be set to null
            if (requestConfiguration_configuration_McpservergrafanaIsNull)
            {
                requestConfiguration_configuration_Mcpservergrafana = null;
            }
            if (requestConfiguration_configuration_Mcpservergrafana != null)
            {
                request.Configuration.Mcpservergrafana = requestConfiguration_configuration_Mcpservergrafana;
                requestConfigurationIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MSTeamsConfiguration requestConfiguration_configuration_Msteams = null;
            
             // populate Msteams
            var requestConfiguration_configuration_MsteamsIsNull = true;
            requestConfiguration_configuration_Msteams = new Amazon.DevOpsAgent.Model.MSTeamsConfiguration();
            System.String requestConfiguration_configuration_Msteams_configuration_Msteams_TeamId = null;
            if (cmdletContext.Configuration_Msteams_TeamId != null)
            {
                requestConfiguration_configuration_Msteams_configuration_Msteams_TeamId = cmdletContext.Configuration_Msteams_TeamId;
            }
            if (requestConfiguration_configuration_Msteams_configuration_Msteams_TeamId != null)
            {
                requestConfiguration_configuration_Msteams.TeamId = requestConfiguration_configuration_Msteams_configuration_Msteams_TeamId;
                requestConfiguration_configuration_MsteamsIsNull = false;
            }
            System.String requestConfiguration_configuration_Msteams_configuration_Msteams_TeamName = null;
            if (cmdletContext.Configuration_Msteams_TeamName != null)
            {
                requestConfiguration_configuration_Msteams_configuration_Msteams_TeamName = cmdletContext.Configuration_Msteams_TeamName;
            }
            if (requestConfiguration_configuration_Msteams_configuration_Msteams_TeamName != null)
            {
                requestConfiguration_configuration_Msteams.TeamName = requestConfiguration_configuration_Msteams_configuration_Msteams_TeamName;
                requestConfiguration_configuration_MsteamsIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MSTeamsTransmissionTarget requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget = null;
            
             // populate TransmissionTarget
            var requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTargetIsNull = true;
            requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget = new Amazon.DevOpsAgent.Model.MSTeamsTransmissionTarget();
            Amazon.DevOpsAgent.Model.MSTeamsChannel requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget = null;
            
             // populate OpsOncallTarget
            var requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTargetIsNull = true;
            requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget = new Amazon.DevOpsAgent.Model.MSTeamsChannel();
            System.String requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelId = null;
            if (cmdletContext.Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelId != null)
            {
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelId = cmdletContext.Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelId;
            }
            if (requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelId != null)
            {
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget.ChannelId = requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelId;
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTargetIsNull = false;
            }
            System.String requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelName = null;
            if (cmdletContext.Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelName != null)
            {
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelName = cmdletContext.Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelName;
            }
            if (requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelName != null)
            {
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget.ChannelName = requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelName;
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTargetIsNull = false;
            }
             // determine if requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget should be set to null
            if (requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTargetIsNull)
            {
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget = null;
            }
            if (requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget != null)
            {
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget.OpsOncallTarget = requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsOncallTarget;
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTargetIsNull = false;
            }
            Amazon.DevOpsAgent.Model.MSTeamsChannel requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget = null;
            
             // populate OpsSRETarget
            var requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETargetIsNull = true;
            requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget = new Amazon.DevOpsAgent.Model.MSTeamsChannel();
            System.String requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelId = null;
            if (cmdletContext.Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelId != null)
            {
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelId = cmdletContext.Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelId;
            }
            if (requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelId != null)
            {
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget.ChannelId = requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelId;
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETargetIsNull = false;
            }
            System.String requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelName = null;
            if (cmdletContext.Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelName != null)
            {
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelName = cmdletContext.Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelName;
            }
            if (requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelName != null)
            {
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget.ChannelName = requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelName;
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETargetIsNull = false;
            }
             // determine if requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget should be set to null
            if (requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETargetIsNull)
            {
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget = null;
            }
            if (requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget != null)
            {
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget.OpsSRETarget = requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget_configuration_Msteams_TransmissionTarget_OpsSRETarget;
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTargetIsNull = false;
            }
             // determine if requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget should be set to null
            if (requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTargetIsNull)
            {
                requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget = null;
            }
            if (requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget != null)
            {
                requestConfiguration_configuration_Msteams.TransmissionTarget = requestConfiguration_configuration_Msteams_configuration_Msteams_TransmissionTarget;
                requestConfiguration_configuration_MsteamsIsNull = false;
            }
             // determine if requestConfiguration_configuration_Msteams should be set to null
            if (requestConfiguration_configuration_MsteamsIsNull)
            {
                requestConfiguration_configuration_Msteams = null;
            }
            if (requestConfiguration_configuration_Msteams != null)
            {
                request.Configuration.Msteams = requestConfiguration_configuration_Msteams;
                requestConfigurationIsNull = false;
            }
            Amazon.DevOpsAgent.Model.SlackConfiguration requestConfiguration_configuration_Slack = null;
            
             // populate Slack
            var requestConfiguration_configuration_SlackIsNull = true;
            requestConfiguration_configuration_Slack = new Amazon.DevOpsAgent.Model.SlackConfiguration();
            System.String requestConfiguration_configuration_Slack_configuration_Slack_WorkspaceId = null;
            if (cmdletContext.Configuration_Slack_WorkspaceId != null)
            {
                requestConfiguration_configuration_Slack_configuration_Slack_WorkspaceId = cmdletContext.Configuration_Slack_WorkspaceId;
            }
            if (requestConfiguration_configuration_Slack_configuration_Slack_WorkspaceId != null)
            {
                requestConfiguration_configuration_Slack.WorkspaceId = requestConfiguration_configuration_Slack_configuration_Slack_WorkspaceId;
                requestConfiguration_configuration_SlackIsNull = false;
            }
            System.String requestConfiguration_configuration_Slack_configuration_Slack_WorkspaceName = null;
            if (cmdletContext.Configuration_Slack_WorkspaceName != null)
            {
                requestConfiguration_configuration_Slack_configuration_Slack_WorkspaceName = cmdletContext.Configuration_Slack_WorkspaceName;
            }
            if (requestConfiguration_configuration_Slack_configuration_Slack_WorkspaceName != null)
            {
                requestConfiguration_configuration_Slack.WorkspaceName = requestConfiguration_configuration_Slack_configuration_Slack_WorkspaceName;
                requestConfiguration_configuration_SlackIsNull = false;
            }
            Amazon.DevOpsAgent.Model.SlackTransmissionTarget requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget = null;
            
             // populate TransmissionTarget
            var requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTargetIsNull = true;
            requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget = new Amazon.DevOpsAgent.Model.SlackTransmissionTarget();
            Amazon.DevOpsAgent.Model.SlackChannel requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget = null;
            
             // populate OpsOncallTarget
            var requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTargetIsNull = true;
            requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget = new Amazon.DevOpsAgent.Model.SlackChannel();
            System.String requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelId = null;
            if (cmdletContext.Configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelId != null)
            {
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelId = cmdletContext.Configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelId;
            }
            if (requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelId != null)
            {
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget.ChannelId = requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelId;
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTargetIsNull = false;
            }
            System.String requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelName = null;
            if (cmdletContext.Configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelName != null)
            {
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelName = cmdletContext.Configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelName;
            }
            if (requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelName != null)
            {
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget.ChannelName = requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelName;
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTargetIsNull = false;
            }
             // determine if requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget should be set to null
            if (requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTargetIsNull)
            {
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget = null;
            }
            if (requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget != null)
            {
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget.OpsOncallTarget = requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsOncallTarget;
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTargetIsNull = false;
            }
            Amazon.DevOpsAgent.Model.SlackChannel requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget = null;
            
             // populate OpsSRETarget
            var requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETargetIsNull = true;
            requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget = new Amazon.DevOpsAgent.Model.SlackChannel();
            System.String requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget_configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelId = null;
            if (cmdletContext.Configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelId != null)
            {
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget_configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelId = cmdletContext.Configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelId;
            }
            if (requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget_configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelId != null)
            {
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget.ChannelId = requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget_configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelId;
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETargetIsNull = false;
            }
            System.String requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget_configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelName = null;
            if (cmdletContext.Configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelName != null)
            {
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget_configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelName = cmdletContext.Configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelName;
            }
            if (requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget_configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelName != null)
            {
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget.ChannelName = requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget_configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelName;
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETargetIsNull = false;
            }
             // determine if requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget should be set to null
            if (requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETargetIsNull)
            {
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget = null;
            }
            if (requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget != null)
            {
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget.OpsSRETarget = requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget_configuration_Slack_TransmissionTarget_OpsSRETarget;
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTargetIsNull = false;
            }
             // determine if requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget should be set to null
            if (requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTargetIsNull)
            {
                requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget = null;
            }
            if (requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget != null)
            {
                requestConfiguration_configuration_Slack.TransmissionTarget = requestConfiguration_configuration_Slack_configuration_Slack_TransmissionTarget;
                requestConfiguration_configuration_SlackIsNull = false;
            }
             // determine if requestConfiguration_configuration_Slack should be set to null
            if (requestConfiguration_configuration_SlackIsNull)
            {
                requestConfiguration_configuration_Slack = null;
            }
            if (requestConfiguration_configuration_Slack != null)
            {
                request.Configuration.Slack = requestConfiguration_configuration_Slack;
                requestConfigurationIsNull = false;
            }
            Amazon.DevOpsAgent.Model.SourceAwsConfiguration requestConfiguration_configuration_SourceAws = null;
            
             // populate SourceAws
            var requestConfiguration_configuration_SourceAwsIsNull = true;
            requestConfiguration_configuration_SourceAws = new Amazon.DevOpsAgent.Model.SourceAwsConfiguration();
            System.String requestConfiguration_configuration_SourceAws_configuration_SourceAws_AccountId = null;
            if (cmdletContext.Configuration_SourceAws_AccountId != null)
            {
                requestConfiguration_configuration_SourceAws_configuration_SourceAws_AccountId = cmdletContext.Configuration_SourceAws_AccountId;
            }
            if (requestConfiguration_configuration_SourceAws_configuration_SourceAws_AccountId != null)
            {
                requestConfiguration_configuration_SourceAws.AccountId = requestConfiguration_configuration_SourceAws_configuration_SourceAws_AccountId;
                requestConfiguration_configuration_SourceAwsIsNull = false;
            }
            Amazon.DevOpsAgent.SourceAccountType requestConfiguration_configuration_SourceAws_configuration_SourceAws_AccountType = null;
            if (cmdletContext.Configuration_SourceAws_AccountType != null)
            {
                requestConfiguration_configuration_SourceAws_configuration_SourceAws_AccountType = cmdletContext.Configuration_SourceAws_AccountType;
            }
            if (requestConfiguration_configuration_SourceAws_configuration_SourceAws_AccountType != null)
            {
                requestConfiguration_configuration_SourceAws.AccountType = requestConfiguration_configuration_SourceAws_configuration_SourceAws_AccountType;
                requestConfiguration_configuration_SourceAwsIsNull = false;
            }
            System.String requestConfiguration_configuration_SourceAws_configuration_SourceAws_AssumableRoleArn = null;
            if (cmdletContext.Configuration_SourceAws_AssumableRoleArn != null)
            {
                requestConfiguration_configuration_SourceAws_configuration_SourceAws_AssumableRoleArn = cmdletContext.Configuration_SourceAws_AssumableRoleArn;
            }
            if (requestConfiguration_configuration_SourceAws_configuration_SourceAws_AssumableRoleArn != null)
            {
                requestConfiguration_configuration_SourceAws.AssumableRoleArn = requestConfiguration_configuration_SourceAws_configuration_SourceAws_AssumableRoleArn;
                requestConfiguration_configuration_SourceAwsIsNull = false;
            }
            System.String requestConfiguration_configuration_SourceAws_configuration_SourceAws_ExternalId = null;
            if (cmdletContext.Configuration_SourceAws_ExternalId != null)
            {
                requestConfiguration_configuration_SourceAws_configuration_SourceAws_ExternalId = cmdletContext.Configuration_SourceAws_ExternalId;
            }
            if (requestConfiguration_configuration_SourceAws_configuration_SourceAws_ExternalId != null)
            {
                requestConfiguration_configuration_SourceAws.ExternalId = requestConfiguration_configuration_SourceAws_configuration_SourceAws_ExternalId;
                requestConfiguration_configuration_SourceAwsIsNull = false;
            }
             // determine if requestConfiguration_configuration_SourceAws should be set to null
            if (requestConfiguration_configuration_SourceAwsIsNull)
            {
                requestConfiguration_configuration_SourceAws = null;
            }
            if (requestConfiguration_configuration_SourceAws != null)
            {
                request.Configuration.SourceAws = requestConfiguration_configuration_SourceAws;
                requestConfigurationIsNull = false;
            }
            Amazon.DevOpsAgent.Model.GitHubConfiguration requestConfiguration_configuration_Github = null;
            
             // populate Github
            var requestConfiguration_configuration_GithubIsNull = true;
            requestConfiguration_configuration_Github = new Amazon.DevOpsAgent.Model.GitHubConfiguration();
            System.String requestConfiguration_configuration_Github_configuration_Github_InstanceIdentifier = null;
            if (cmdletContext.Configuration_Github_InstanceIdentifier != null)
            {
                requestConfiguration_configuration_Github_configuration_Github_InstanceIdentifier = cmdletContext.Configuration_Github_InstanceIdentifier;
            }
            if (requestConfiguration_configuration_Github_configuration_Github_InstanceIdentifier != null)
            {
                requestConfiguration_configuration_Github.InstanceIdentifier = requestConfiguration_configuration_Github_configuration_Github_InstanceIdentifier;
                requestConfiguration_configuration_GithubIsNull = false;
            }
            System.String requestConfiguration_configuration_Github_configuration_Github_Owner = null;
            if (cmdletContext.Configuration_Github_Owner != null)
            {
                requestConfiguration_configuration_Github_configuration_Github_Owner = cmdletContext.Configuration_Github_Owner;
            }
            if (requestConfiguration_configuration_Github_configuration_Github_Owner != null)
            {
                requestConfiguration_configuration_Github.Owner = requestConfiguration_configuration_Github_configuration_Github_Owner;
                requestConfiguration_configuration_GithubIsNull = false;
            }
            Amazon.DevOpsAgent.GithubRepoOwnerType requestConfiguration_configuration_Github_configuration_Github_OwnerType = null;
            if (cmdletContext.Configuration_Github_OwnerType != null)
            {
                requestConfiguration_configuration_Github_configuration_Github_OwnerType = cmdletContext.Configuration_Github_OwnerType;
            }
            if (requestConfiguration_configuration_Github_configuration_Github_OwnerType != null)
            {
                requestConfiguration_configuration_Github.OwnerType = requestConfiguration_configuration_Github_configuration_Github_OwnerType;
                requestConfiguration_configuration_GithubIsNull = false;
            }
            System.String requestConfiguration_configuration_Github_configuration_Github_RepoId = null;
            if (cmdletContext.Configuration_Github_RepoId != null)
            {
                requestConfiguration_configuration_Github_configuration_Github_RepoId = cmdletContext.Configuration_Github_RepoId;
            }
            if (requestConfiguration_configuration_Github_configuration_Github_RepoId != null)
            {
                requestConfiguration_configuration_Github.RepoId = requestConfiguration_configuration_Github_configuration_Github_RepoId;
                requestConfiguration_configuration_GithubIsNull = false;
            }
            System.String requestConfiguration_configuration_Github_configuration_Github_RepoName = null;
            if (cmdletContext.Configuration_Github_RepoName != null)
            {
                requestConfiguration_configuration_Github_configuration_Github_RepoName = cmdletContext.Configuration_Github_RepoName;
            }
            if (requestConfiguration_configuration_Github_configuration_Github_RepoName != null)
            {
                requestConfiguration_configuration_Github.RepoName = requestConfiguration_configuration_Github_configuration_Github_RepoName;
                requestConfiguration_configuration_GithubIsNull = false;
            }
             // determine if requestConfiguration_configuration_Github should be set to null
            if (requestConfiguration_configuration_GithubIsNull)
            {
                requestConfiguration_configuration_Github = null;
            }
            if (requestConfiguration_configuration_Github != null)
            {
                request.Configuration.Github = requestConfiguration_configuration_Github;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.ServiceId != null)
            {
                request.ServiceId = cmdletContext.ServiceId;
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
        
        private Amazon.DevOpsAgent.Model.AssociateServiceResponse CallAWSServiceOperation(IAmazonDevOpsAgent client, Amazon.DevOpsAgent.Model.AssociateServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DevOps Agent Service", "AssociateService");
            try
            {
                return client.AssociateServiceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentSpaceId { get; set; }
            public System.String Configuration_Aws_AccountId { get; set; }
            public Amazon.DevOpsAgent.MonitorAccountType Configuration_Aws_AccountType { get; set; }
            public System.String Configuration_Aws_AssumableRoleArn { get; set; }
            public System.String Configuration_Azure_SubscriptionId { get; set; }
            public System.String Configuration_Azuredevops_OrganizationName { get; set; }
            public System.String Configuration_Azuredevops_ProjectId { get; set; }
            public System.String Configuration_Azuredevops_ProjectName { get; set; }
            public System.String Configuration_Dynatrace_EnvId { get; set; }
            public List<System.String> Configuration_Dynatrace_Resource { get; set; }
            public Amazon.DevOpsAgent.Model.EventChannelConfiguration Configuration_EventChannel { get; set; }
            public System.String Configuration_Github_InstanceIdentifier { get; set; }
            public System.String Configuration_Github_Owner { get; set; }
            public Amazon.DevOpsAgent.GithubRepoOwnerType Configuration_Github_OwnerType { get; set; }
            public System.String Configuration_Github_RepoId { get; set; }
            public System.String Configuration_Github_RepoName { get; set; }
            public System.String Configuration_Gitlab_InstanceIdentifier { get; set; }
            public System.String Configuration_Gitlab_ProjectId { get; set; }
            public System.String Configuration_Gitlab_ProjectPath { get; set; }
            public System.String Configuration_Mcpservergrafana_Endpoint { get; set; }
            public System.String Configuration_Mcpservergrafana_OrganizationId { get; set; }
            public List<System.String> Configuration_Mcpservergrafana_Tool { get; set; }
            public System.String Configuration_Mcpservernewrelic_AccountId { get; set; }
            public System.String Configuration_Mcpservernewrelic_Endpoint { get; set; }
            public System.String Configuration_Msteams_TeamId { get; set; }
            public System.String Configuration_Msteams_TeamName { get; set; }
            public System.String Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelId { get; set; }
            public System.String Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelName { get; set; }
            public System.String Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelId { get; set; }
            public System.String Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelName { get; set; }
            public System.String Configuration_Pagerduty_CustomerEmail { get; set; }
            public List<System.String> Configuration_Pagerduty_Service { get; set; }
            public List<System.String> Configuration_Servicenow_AuthScope { get; set; }
            public System.String Configuration_Servicenow_InstanceId { get; set; }
            public System.String Configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelId { get; set; }
            public System.String Configuration_Slack_TransmissionTarget_OpsOncallTarget_ChannelName { get; set; }
            public System.String Configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelId { get; set; }
            public System.String Configuration_Slack_TransmissionTarget_OpsSRETarget_ChannelName { get; set; }
            public System.String Configuration_Slack_WorkspaceId { get; set; }
            public System.String Configuration_Slack_WorkspaceName { get; set; }
            public System.String Configuration_SourceAws_AccountId { get; set; }
            public Amazon.DevOpsAgent.SourceAccountType Configuration_SourceAws_AccountType { get; set; }
            public System.String Configuration_SourceAws_AssumableRoleArn { get; set; }
            public System.String Configuration_SourceAws_ExternalId { get; set; }
            public System.String ServiceId { get; set; }
            public System.Func<Amazon.DevOpsAgent.Model.AssociateServiceResponse, AddDOPSServiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
