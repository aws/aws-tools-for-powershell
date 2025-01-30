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
using Amazon.WellArchitected;
using Amazon.WellArchitected.Model;

namespace Amazon.PowerShell.Cmdlets.WAT
{
    /// <summary>
    /// Update whether the Amazon Web Services account is opted into organization sharing
    /// and discovery integration features.
    /// </summary>
    [Cmdlet("Update", "WATGlobalSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Well-Architected Tool UpdateGlobalSettings API operation.", Operation = new[] {"UpdateGlobalSettings"}, SelectReturnType = typeof(Amazon.WellArchitected.Model.UpdateGlobalSettingsResponse))]
    [AWSCmdletOutput("None or Amazon.WellArchitected.Model.UpdateGlobalSettingsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WellArchitected.Model.UpdateGlobalSettingsResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateWATGlobalSettingCmdlet : AmazonWellArchitectedClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DiscoveryIntegrationStatus
        /// <summary>
        /// <para>
        /// <para>The status of discovery support settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.DiscoveryIntegrationStatus")]
        public Amazon.WellArchitected.DiscoveryIntegrationStatus DiscoveryIntegrationStatus { get; set; }
        #endregion
        
        #region Parameter JiraConfiguration_IntegrationStatus
        /// <summary>
        /// <para>
        /// <para>Account-level: Configuration status of the Jira integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.IntegrationStatusInput")]
        public Amazon.WellArchitected.IntegrationStatusInput JiraConfiguration_IntegrationStatus { get; set; }
        #endregion
        
        #region Parameter JiraConfiguration_IssueManagementStatus
        /// <summary>
        /// <para>
        /// <para>Account-level: Jira issue management status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.AccountJiraIssueManagementStatus")]
        public Amazon.WellArchitected.AccountJiraIssueManagementStatus JiraConfiguration_IssueManagementStatus { get; set; }
        #endregion
        
        #region Parameter JiraConfiguration_IssueManagementType
        /// <summary>
        /// <para>
        /// <para>Account-level: Jira issue management type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.IssueManagementType")]
        public Amazon.WellArchitected.IssueManagementType JiraConfiguration_IssueManagementType { get; set; }
        #endregion
        
        #region Parameter JiraConfiguration_JiraProjectKey
        /// <summary>
        /// <para>
        /// <para>Account-level: Jira project key to sync workloads to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JiraConfiguration_JiraProjectKey { get; set; }
        #endregion
        
        #region Parameter OrganizationSharingStatus
        /// <summary>
        /// <para>
        /// <para>The status of organization sharing settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.OrganizationSharingStatus")]
        public Amazon.WellArchitected.OrganizationSharingStatus OrganizationSharingStatus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WellArchitected.Model.UpdateGlobalSettingsResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WATGlobalSetting (UpdateGlobalSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WellArchitected.Model.UpdateGlobalSettingsResponse, UpdateWATGlobalSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DiscoveryIntegrationStatus = this.DiscoveryIntegrationStatus;
            context.JiraConfiguration_IntegrationStatus = this.JiraConfiguration_IntegrationStatus;
            context.JiraConfiguration_IssueManagementStatus = this.JiraConfiguration_IssueManagementStatus;
            context.JiraConfiguration_IssueManagementType = this.JiraConfiguration_IssueManagementType;
            context.JiraConfiguration_JiraProjectKey = this.JiraConfiguration_JiraProjectKey;
            context.OrganizationSharingStatus = this.OrganizationSharingStatus;
            
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
            var request = new Amazon.WellArchitected.Model.UpdateGlobalSettingsRequest();
            
            if (cmdletContext.DiscoveryIntegrationStatus != null)
            {
                request.DiscoveryIntegrationStatus = cmdletContext.DiscoveryIntegrationStatus;
            }
            
             // populate JiraConfiguration
            var requestJiraConfigurationIsNull = true;
            request.JiraConfiguration = new Amazon.WellArchitected.Model.AccountJiraConfigurationInput();
            Amazon.WellArchitected.IntegrationStatusInput requestJiraConfiguration_jiraConfiguration_IntegrationStatus = null;
            if (cmdletContext.JiraConfiguration_IntegrationStatus != null)
            {
                requestJiraConfiguration_jiraConfiguration_IntegrationStatus = cmdletContext.JiraConfiguration_IntegrationStatus;
            }
            if (requestJiraConfiguration_jiraConfiguration_IntegrationStatus != null)
            {
                request.JiraConfiguration.IntegrationStatus = requestJiraConfiguration_jiraConfiguration_IntegrationStatus;
                requestJiraConfigurationIsNull = false;
            }
            Amazon.WellArchitected.AccountJiraIssueManagementStatus requestJiraConfiguration_jiraConfiguration_IssueManagementStatus = null;
            if (cmdletContext.JiraConfiguration_IssueManagementStatus != null)
            {
                requestJiraConfiguration_jiraConfiguration_IssueManagementStatus = cmdletContext.JiraConfiguration_IssueManagementStatus;
            }
            if (requestJiraConfiguration_jiraConfiguration_IssueManagementStatus != null)
            {
                request.JiraConfiguration.IssueManagementStatus = requestJiraConfiguration_jiraConfiguration_IssueManagementStatus;
                requestJiraConfigurationIsNull = false;
            }
            Amazon.WellArchitected.IssueManagementType requestJiraConfiguration_jiraConfiguration_IssueManagementType = null;
            if (cmdletContext.JiraConfiguration_IssueManagementType != null)
            {
                requestJiraConfiguration_jiraConfiguration_IssueManagementType = cmdletContext.JiraConfiguration_IssueManagementType;
            }
            if (requestJiraConfiguration_jiraConfiguration_IssueManagementType != null)
            {
                request.JiraConfiguration.IssueManagementType = requestJiraConfiguration_jiraConfiguration_IssueManagementType;
                requestJiraConfigurationIsNull = false;
            }
            System.String requestJiraConfiguration_jiraConfiguration_JiraProjectKey = null;
            if (cmdletContext.JiraConfiguration_JiraProjectKey != null)
            {
                requestJiraConfiguration_jiraConfiguration_JiraProjectKey = cmdletContext.JiraConfiguration_JiraProjectKey;
            }
            if (requestJiraConfiguration_jiraConfiguration_JiraProjectKey != null)
            {
                request.JiraConfiguration.JiraProjectKey = requestJiraConfiguration_jiraConfiguration_JiraProjectKey;
                requestJiraConfigurationIsNull = false;
            }
             // determine if request.JiraConfiguration should be set to null
            if (requestJiraConfigurationIsNull)
            {
                request.JiraConfiguration = null;
            }
            if (cmdletContext.OrganizationSharingStatus != null)
            {
                request.OrganizationSharingStatus = cmdletContext.OrganizationSharingStatus;
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
        
        private Amazon.WellArchitected.Model.UpdateGlobalSettingsResponse CallAWSServiceOperation(IAmazonWellArchitected client, Amazon.WellArchitected.Model.UpdateGlobalSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Well-Architected Tool", "UpdateGlobalSettings");
            try
            {
                #if DESKTOP
                return client.UpdateGlobalSettings(request);
                #elif CORECLR
                return client.UpdateGlobalSettingsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.WellArchitected.DiscoveryIntegrationStatus DiscoveryIntegrationStatus { get; set; }
            public Amazon.WellArchitected.IntegrationStatusInput JiraConfiguration_IntegrationStatus { get; set; }
            public Amazon.WellArchitected.AccountJiraIssueManagementStatus JiraConfiguration_IssueManagementStatus { get; set; }
            public Amazon.WellArchitected.IssueManagementType JiraConfiguration_IssueManagementType { get; set; }
            public System.String JiraConfiguration_JiraProjectKey { get; set; }
            public Amazon.WellArchitected.OrganizationSharingStatus OrganizationSharingStatus { get; set; }
            public System.Func<Amazon.WellArchitected.Model.UpdateGlobalSettingsResponse, UpdateWATGlobalSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
