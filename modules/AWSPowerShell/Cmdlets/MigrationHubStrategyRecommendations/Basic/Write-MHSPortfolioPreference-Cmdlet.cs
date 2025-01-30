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
using Amazon.MigrationHubStrategyRecommendations;
using Amazon.MigrationHubStrategyRecommendations.Model;

namespace Amazon.PowerShell.Cmdlets.MHS
{
    /// <summary>
    /// Saves the specified migration and modernization preferences.
    /// </summary>
    [Cmdlet("Write", "MHSPortfolioPreference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Migration Hub Strategy Recommendations PutPortfolioPreferences API operation.", Operation = new[] {"PutPortfolioPreferences"}, SelectReturnType = typeof(Amazon.MigrationHubStrategyRecommendations.Model.PutPortfolioPreferencesResponse))]
    [AWSCmdletOutput("None or Amazon.MigrationHubStrategyRecommendations.Model.PutPortfolioPreferencesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MigrationHubStrategyRecommendations.Model.PutPortfolioPreferencesResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteMHSPortfolioPreferenceCmdlet : AmazonMigrationHubStrategyRecommendationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationMode
        /// <summary>
        /// <para>
        /// <para>The classification for application component types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubStrategyRecommendations.ApplicationMode")]
        public Amazon.MigrationHubStrategyRecommendations.ApplicationMode ApplicationMode { get; set; }
        #endregion
        
        #region Parameter DatabasePreferences_DatabaseManagementPreference
        /// <summary>
        /// <para>
        /// <para> Specifies whether you're interested in self-managed databases or databases managed
        /// by AWS. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubStrategyRecommendations.DatabaseManagementPreference")]
        public Amazon.MigrationHubStrategyRecommendations.DatabaseManagementPreference DatabasePreferences_DatabaseManagementPreference { get; set; }
        #endregion
        
        #region Parameter BusinessGoals_LicenseCostReduction
        /// <summary>
        /// <para>
        /// <para> Business goal to reduce license costs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrioritizeBusinessGoals_BusinessGoals_LicenseCostReduction")]
        public System.Int32? BusinessGoals_LicenseCostReduction { get; set; }
        #endregion
        
        #region Parameter BusinessGoals_ModernizeInfrastructureWithCloudNativeTechnology
        /// <summary>
        /// <para>
        /// <para> Business goal to modernize infrastructure by moving to cloud native technologies.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrioritizeBusinessGoals_BusinessGoals_ModernizeInfrastructureWithCloudNativeTechnologies")]
        public System.Int32? BusinessGoals_ModernizeInfrastructureWithCloudNativeTechnology { get; set; }
        #endregion
        
        #region Parameter BusinessGoals_ReduceOperationalOverheadWithManagedService
        /// <summary>
        /// <para>
        /// <para> Business goal to reduce the operational overhead on the team by moving into managed
        /// services. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrioritizeBusinessGoals_BusinessGoals_ReduceOperationalOverheadWithManagedServices")]
        public System.Int32? BusinessGoals_ReduceOperationalOverheadWithManagedService { get; set; }
        #endregion
        
        #region Parameter BusinessGoals_SpeedOfMigration
        /// <summary>
        /// <para>
        /// <para> Business goal to achieve migration at a fast pace. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrioritizeBusinessGoals_BusinessGoals_SpeedOfMigration")]
        public System.Int32? BusinessGoals_SpeedOfMigration { get; set; }
        #endregion
        
        #region Parameter Heterogeneous_TargetDatabaseEngine
        /// <summary>
        /// <para>
        /// <para> The target database engine for heterogeneous database migration preference. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatabasePreferences_DatabaseMigrationPreference_Heterogeneous_TargetDatabaseEngine")]
        public System.String[] Heterogeneous_TargetDatabaseEngine { get; set; }
        #endregion
        
        #region Parameter Homogeneous_TargetDatabaseEngine
        /// <summary>
        /// <para>
        /// <para> The target database engine for homogeneous database migration preferences. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatabasePreferences_DatabaseMigrationPreference_Homogeneous_TargetDatabaseEngine")]
        public System.String[] Homogeneous_TargetDatabaseEngine { get; set; }
        #endregion
        
        #region Parameter NoPreference_TargetDatabaseEngine
        /// <summary>
        /// <para>
        /// <para> The target database engine for database migration preference that you specify. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatabasePreferences_DatabaseMigrationPreference_NoPreference_TargetDatabaseEngine")]
        public System.String[] NoPreference_TargetDatabaseEngine { get; set; }
        #endregion
        
        #region Parameter AwsManagedResources_TargetDestination
        /// <summary>
        /// <para>
        /// <para> The choice of application destination that you specify. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationPreferences_ManagementPreference_AwsManagedResources_TargetDestination")]
        public System.String[] AwsManagedResources_TargetDestination { get; set; }
        #endregion
        
        #region Parameter NoPreference_TargetDestination
        /// <summary>
        /// <para>
        /// <para> The choice of application destination that you specify. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationPreferences_ManagementPreference_NoPreference_TargetDestination")]
        public System.String[] NoPreference_TargetDestination { get; set; }
        #endregion
        
        #region Parameter SelfManageResources_TargetDestination
        /// <summary>
        /// <para>
        /// <para> Self-managed resources target destination. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationPreferences_ManagementPreference_SelfManageResources_TargetDestination")]
        public System.String[] SelfManageResources_TargetDestination { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubStrategyRecommendations.Model.PutPortfolioPreferencesResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-MHSPortfolioPreference (PutPortfolioPreferences)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHubStrategyRecommendations.Model.PutPortfolioPreferencesResponse, WriteMHSPortfolioPreferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationMode = this.ApplicationMode;
            if (this.AwsManagedResources_TargetDestination != null)
            {
                context.AwsManagedResources_TargetDestination = new List<System.String>(this.AwsManagedResources_TargetDestination);
            }
            if (this.NoPreference_TargetDestination != null)
            {
                context.NoPreference_TargetDestination = new List<System.String>(this.NoPreference_TargetDestination);
            }
            if (this.SelfManageResources_TargetDestination != null)
            {
                context.SelfManageResources_TargetDestination = new List<System.String>(this.SelfManageResources_TargetDestination);
            }
            context.DatabasePreferences_DatabaseManagementPreference = this.DatabasePreferences_DatabaseManagementPreference;
            if (this.Heterogeneous_TargetDatabaseEngine != null)
            {
                context.Heterogeneous_TargetDatabaseEngine = new List<System.String>(this.Heterogeneous_TargetDatabaseEngine);
            }
            if (this.Homogeneous_TargetDatabaseEngine != null)
            {
                context.Homogeneous_TargetDatabaseEngine = new List<System.String>(this.Homogeneous_TargetDatabaseEngine);
            }
            if (this.NoPreference_TargetDatabaseEngine != null)
            {
                context.NoPreference_TargetDatabaseEngine = new List<System.String>(this.NoPreference_TargetDatabaseEngine);
            }
            context.BusinessGoals_LicenseCostReduction = this.BusinessGoals_LicenseCostReduction;
            context.BusinessGoals_ModernizeInfrastructureWithCloudNativeTechnology = this.BusinessGoals_ModernizeInfrastructureWithCloudNativeTechnology;
            context.BusinessGoals_ReduceOperationalOverheadWithManagedService = this.BusinessGoals_ReduceOperationalOverheadWithManagedService;
            context.BusinessGoals_SpeedOfMigration = this.BusinessGoals_SpeedOfMigration;
            
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
            var request = new Amazon.MigrationHubStrategyRecommendations.Model.PutPortfolioPreferencesRequest();
            
            if (cmdletContext.ApplicationMode != null)
            {
                request.ApplicationMode = cmdletContext.ApplicationMode;
            }
            
             // populate ApplicationPreferences
            var requestApplicationPreferencesIsNull = true;
            request.ApplicationPreferences = new Amazon.MigrationHubStrategyRecommendations.Model.ApplicationPreferences();
            Amazon.MigrationHubStrategyRecommendations.Model.ManagementPreference requestApplicationPreferences_applicationPreferences_ManagementPreference = null;
            
             // populate ManagementPreference
            var requestApplicationPreferences_applicationPreferences_ManagementPreferenceIsNull = true;
            requestApplicationPreferences_applicationPreferences_ManagementPreference = new Amazon.MigrationHubStrategyRecommendations.Model.ManagementPreference();
            Amazon.MigrationHubStrategyRecommendations.Model.AwsManagedResources requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_AwsManagedResources = null;
            
             // populate AwsManagedResources
            var requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_AwsManagedResourcesIsNull = true;
            requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_AwsManagedResources = new Amazon.MigrationHubStrategyRecommendations.Model.AwsManagedResources();
            List<System.String> requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_AwsManagedResources_awsManagedResources_TargetDestination = null;
            if (cmdletContext.AwsManagedResources_TargetDestination != null)
            {
                requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_AwsManagedResources_awsManagedResources_TargetDestination = cmdletContext.AwsManagedResources_TargetDestination;
            }
            if (requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_AwsManagedResources_awsManagedResources_TargetDestination != null)
            {
                requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_AwsManagedResources.TargetDestination = requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_AwsManagedResources_awsManagedResources_TargetDestination;
                requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_AwsManagedResourcesIsNull = false;
            }
             // determine if requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_AwsManagedResources should be set to null
            if (requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_AwsManagedResourcesIsNull)
            {
                requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_AwsManagedResources = null;
            }
            if (requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_AwsManagedResources != null)
            {
                requestApplicationPreferences_applicationPreferences_ManagementPreference.AwsManagedResources = requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_AwsManagedResources;
                requestApplicationPreferences_applicationPreferences_ManagementPreferenceIsNull = false;
            }
            Amazon.MigrationHubStrategyRecommendations.Model.NoManagementPreference requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_NoPreference = null;
            
             // populate NoPreference
            var requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_NoPreferenceIsNull = true;
            requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_NoPreference = new Amazon.MigrationHubStrategyRecommendations.Model.NoManagementPreference();
            List<System.String> requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_NoPreference_noPreference_TargetDestination = null;
            if (cmdletContext.NoPreference_TargetDestination != null)
            {
                requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_NoPreference_noPreference_TargetDestination = cmdletContext.NoPreference_TargetDestination;
            }
            if (requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_NoPreference_noPreference_TargetDestination != null)
            {
                requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_NoPreference.TargetDestination = requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_NoPreference_noPreference_TargetDestination;
                requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_NoPreferenceIsNull = false;
            }
             // determine if requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_NoPreference should be set to null
            if (requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_NoPreferenceIsNull)
            {
                requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_NoPreference = null;
            }
            if (requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_NoPreference != null)
            {
                requestApplicationPreferences_applicationPreferences_ManagementPreference.NoPreference = requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_NoPreference;
                requestApplicationPreferences_applicationPreferences_ManagementPreferenceIsNull = false;
            }
            Amazon.MigrationHubStrategyRecommendations.Model.SelfManageResources requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_SelfManageResources = null;
            
             // populate SelfManageResources
            var requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_SelfManageResourcesIsNull = true;
            requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_SelfManageResources = new Amazon.MigrationHubStrategyRecommendations.Model.SelfManageResources();
            List<System.String> requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_SelfManageResources_selfManageResources_TargetDestination = null;
            if (cmdletContext.SelfManageResources_TargetDestination != null)
            {
                requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_SelfManageResources_selfManageResources_TargetDestination = cmdletContext.SelfManageResources_TargetDestination;
            }
            if (requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_SelfManageResources_selfManageResources_TargetDestination != null)
            {
                requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_SelfManageResources.TargetDestination = requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_SelfManageResources_selfManageResources_TargetDestination;
                requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_SelfManageResourcesIsNull = false;
            }
             // determine if requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_SelfManageResources should be set to null
            if (requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_SelfManageResourcesIsNull)
            {
                requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_SelfManageResources = null;
            }
            if (requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_SelfManageResources != null)
            {
                requestApplicationPreferences_applicationPreferences_ManagementPreference.SelfManageResources = requestApplicationPreferences_applicationPreferences_ManagementPreference_applicationPreferences_ManagementPreference_SelfManageResources;
                requestApplicationPreferences_applicationPreferences_ManagementPreferenceIsNull = false;
            }
             // determine if requestApplicationPreferences_applicationPreferences_ManagementPreference should be set to null
            if (requestApplicationPreferences_applicationPreferences_ManagementPreferenceIsNull)
            {
                requestApplicationPreferences_applicationPreferences_ManagementPreference = null;
            }
            if (requestApplicationPreferences_applicationPreferences_ManagementPreference != null)
            {
                request.ApplicationPreferences.ManagementPreference = requestApplicationPreferences_applicationPreferences_ManagementPreference;
                requestApplicationPreferencesIsNull = false;
            }
             // determine if request.ApplicationPreferences should be set to null
            if (requestApplicationPreferencesIsNull)
            {
                request.ApplicationPreferences = null;
            }
            
             // populate DatabasePreferences
            var requestDatabasePreferencesIsNull = true;
            request.DatabasePreferences = new Amazon.MigrationHubStrategyRecommendations.Model.DatabasePreferences();
            Amazon.MigrationHubStrategyRecommendations.DatabaseManagementPreference requestDatabasePreferences_databasePreferences_DatabaseManagementPreference = null;
            if (cmdletContext.DatabasePreferences_DatabaseManagementPreference != null)
            {
                requestDatabasePreferences_databasePreferences_DatabaseManagementPreference = cmdletContext.DatabasePreferences_DatabaseManagementPreference;
            }
            if (requestDatabasePreferences_databasePreferences_DatabaseManagementPreference != null)
            {
                request.DatabasePreferences.DatabaseManagementPreference = requestDatabasePreferences_databasePreferences_DatabaseManagementPreference;
                requestDatabasePreferencesIsNull = false;
            }
            Amazon.MigrationHubStrategyRecommendations.Model.DatabaseMigrationPreference requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference = null;
            
             // populate DatabaseMigrationPreference
            var requestDatabasePreferences_databasePreferences_DatabaseMigrationPreferenceIsNull = true;
            requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference = new Amazon.MigrationHubStrategyRecommendations.Model.DatabaseMigrationPreference();
            Amazon.MigrationHubStrategyRecommendations.Model.Heterogeneous requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Heterogeneous = null;
            
             // populate Heterogeneous
            var requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_HeterogeneousIsNull = true;
            requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Heterogeneous = new Amazon.MigrationHubStrategyRecommendations.Model.Heterogeneous();
            List<System.String> requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Heterogeneous_heterogeneous_TargetDatabaseEngine = null;
            if (cmdletContext.Heterogeneous_TargetDatabaseEngine != null)
            {
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Heterogeneous_heterogeneous_TargetDatabaseEngine = cmdletContext.Heterogeneous_TargetDatabaseEngine;
            }
            if (requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Heterogeneous_heterogeneous_TargetDatabaseEngine != null)
            {
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Heterogeneous.TargetDatabaseEngine = requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Heterogeneous_heterogeneous_TargetDatabaseEngine;
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_HeterogeneousIsNull = false;
            }
             // determine if requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Heterogeneous should be set to null
            if (requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_HeterogeneousIsNull)
            {
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Heterogeneous = null;
            }
            if (requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Heterogeneous != null)
            {
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference.Heterogeneous = requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Heterogeneous;
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreferenceIsNull = false;
            }
            Amazon.MigrationHubStrategyRecommendations.Model.Homogeneous requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Homogeneous = null;
            
             // populate Homogeneous
            var requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_HomogeneousIsNull = true;
            requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Homogeneous = new Amazon.MigrationHubStrategyRecommendations.Model.Homogeneous();
            List<System.String> requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Homogeneous_homogeneous_TargetDatabaseEngine = null;
            if (cmdletContext.Homogeneous_TargetDatabaseEngine != null)
            {
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Homogeneous_homogeneous_TargetDatabaseEngine = cmdletContext.Homogeneous_TargetDatabaseEngine;
            }
            if (requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Homogeneous_homogeneous_TargetDatabaseEngine != null)
            {
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Homogeneous.TargetDatabaseEngine = requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Homogeneous_homogeneous_TargetDatabaseEngine;
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_HomogeneousIsNull = false;
            }
             // determine if requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Homogeneous should be set to null
            if (requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_HomogeneousIsNull)
            {
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Homogeneous = null;
            }
            if (requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Homogeneous != null)
            {
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference.Homogeneous = requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_Homogeneous;
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreferenceIsNull = false;
            }
            Amazon.MigrationHubStrategyRecommendations.Model.NoDatabaseMigrationPreference requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_NoPreference = null;
            
             // populate NoPreference
            var requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_NoPreferenceIsNull = true;
            requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_NoPreference = new Amazon.MigrationHubStrategyRecommendations.Model.NoDatabaseMigrationPreference();
            List<System.String> requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_NoPreference_noPreference_TargetDatabaseEngine = null;
            if (cmdletContext.NoPreference_TargetDatabaseEngine != null)
            {
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_NoPreference_noPreference_TargetDatabaseEngine = cmdletContext.NoPreference_TargetDatabaseEngine;
            }
            if (requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_NoPreference_noPreference_TargetDatabaseEngine != null)
            {
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_NoPreference.TargetDatabaseEngine = requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_NoPreference_noPreference_TargetDatabaseEngine;
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_NoPreferenceIsNull = false;
            }
             // determine if requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_NoPreference should be set to null
            if (requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_NoPreferenceIsNull)
            {
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_NoPreference = null;
            }
            if (requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_NoPreference != null)
            {
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference.NoPreference = requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference_databasePreferences_DatabaseMigrationPreference_NoPreference;
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreferenceIsNull = false;
            }
             // determine if requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference should be set to null
            if (requestDatabasePreferences_databasePreferences_DatabaseMigrationPreferenceIsNull)
            {
                requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference = null;
            }
            if (requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference != null)
            {
                request.DatabasePreferences.DatabaseMigrationPreference = requestDatabasePreferences_databasePreferences_DatabaseMigrationPreference;
                requestDatabasePreferencesIsNull = false;
            }
             // determine if request.DatabasePreferences should be set to null
            if (requestDatabasePreferencesIsNull)
            {
                request.DatabasePreferences = null;
            }
            
             // populate PrioritizeBusinessGoals
            var requestPrioritizeBusinessGoalsIsNull = true;
            request.PrioritizeBusinessGoals = new Amazon.MigrationHubStrategyRecommendations.Model.PrioritizeBusinessGoals();
            Amazon.MigrationHubStrategyRecommendations.Model.BusinessGoals requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals = null;
            
             // populate BusinessGoals
            var requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoalsIsNull = true;
            requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals = new Amazon.MigrationHubStrategyRecommendations.Model.BusinessGoals();
            System.Int32? requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_LicenseCostReduction = null;
            if (cmdletContext.BusinessGoals_LicenseCostReduction != null)
            {
                requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_LicenseCostReduction = cmdletContext.BusinessGoals_LicenseCostReduction.Value;
            }
            if (requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_LicenseCostReduction != null)
            {
                requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals.LicenseCostReduction = requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_LicenseCostReduction.Value;
                requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoalsIsNull = false;
            }
            System.Int32? requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_ModernizeInfrastructureWithCloudNativeTechnology = null;
            if (cmdletContext.BusinessGoals_ModernizeInfrastructureWithCloudNativeTechnology != null)
            {
                requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_ModernizeInfrastructureWithCloudNativeTechnology = cmdletContext.BusinessGoals_ModernizeInfrastructureWithCloudNativeTechnology.Value;
            }
            if (requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_ModernizeInfrastructureWithCloudNativeTechnology != null)
            {
                requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals.ModernizeInfrastructureWithCloudNativeTechnologies = requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_ModernizeInfrastructureWithCloudNativeTechnology.Value;
                requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoalsIsNull = false;
            }
            System.Int32? requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_ReduceOperationalOverheadWithManagedService = null;
            if (cmdletContext.BusinessGoals_ReduceOperationalOverheadWithManagedService != null)
            {
                requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_ReduceOperationalOverheadWithManagedService = cmdletContext.BusinessGoals_ReduceOperationalOverheadWithManagedService.Value;
            }
            if (requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_ReduceOperationalOverheadWithManagedService != null)
            {
                requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals.ReduceOperationalOverheadWithManagedServices = requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_ReduceOperationalOverheadWithManagedService.Value;
                requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoalsIsNull = false;
            }
            System.Int32? requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_SpeedOfMigration = null;
            if (cmdletContext.BusinessGoals_SpeedOfMigration != null)
            {
                requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_SpeedOfMigration = cmdletContext.BusinessGoals_SpeedOfMigration.Value;
            }
            if (requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_SpeedOfMigration != null)
            {
                requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals.SpeedOfMigration = requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals_businessGoals_SpeedOfMigration.Value;
                requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoalsIsNull = false;
            }
             // determine if requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals should be set to null
            if (requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoalsIsNull)
            {
                requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals = null;
            }
            if (requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals != null)
            {
                request.PrioritizeBusinessGoals.BusinessGoals = requestPrioritizeBusinessGoals_prioritizeBusinessGoals_BusinessGoals;
                requestPrioritizeBusinessGoalsIsNull = false;
            }
             // determine if request.PrioritizeBusinessGoals should be set to null
            if (requestPrioritizeBusinessGoalsIsNull)
            {
                request.PrioritizeBusinessGoals = null;
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
        
        private Amazon.MigrationHubStrategyRecommendations.Model.PutPortfolioPreferencesResponse CallAWSServiceOperation(IAmazonMigrationHubStrategyRecommendations client, Amazon.MigrationHubStrategyRecommendations.Model.PutPortfolioPreferencesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Migration Hub Strategy Recommendations", "PutPortfolioPreferences");
            try
            {
                #if DESKTOP
                return client.PutPortfolioPreferences(request);
                #elif CORECLR
                return client.PutPortfolioPreferencesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.MigrationHubStrategyRecommendations.ApplicationMode ApplicationMode { get; set; }
            public List<System.String> AwsManagedResources_TargetDestination { get; set; }
            public List<System.String> NoPreference_TargetDestination { get; set; }
            public List<System.String> SelfManageResources_TargetDestination { get; set; }
            public Amazon.MigrationHubStrategyRecommendations.DatabaseManagementPreference DatabasePreferences_DatabaseManagementPreference { get; set; }
            public List<System.String> Heterogeneous_TargetDatabaseEngine { get; set; }
            public List<System.String> Homogeneous_TargetDatabaseEngine { get; set; }
            public List<System.String> NoPreference_TargetDatabaseEngine { get; set; }
            public System.Int32? BusinessGoals_LicenseCostReduction { get; set; }
            public System.Int32? BusinessGoals_ModernizeInfrastructureWithCloudNativeTechnology { get; set; }
            public System.Int32? BusinessGoals_ReduceOperationalOverheadWithManagedService { get; set; }
            public System.Int32? BusinessGoals_SpeedOfMigration { get; set; }
            public System.Func<Amazon.MigrationHubStrategyRecommendations.Model.PutPortfolioPreferencesResponse, WriteMHSPortfolioPreferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
