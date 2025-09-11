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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Generates an embed URL that you can use to embed an QuickSight experience in your
    /// website. This action can be used for any type of user that is registered in an QuickSight
    /// account that uses IAM Identity Center for authentication. This API requires <a href="https://docs.aws.amazon.com/singlesignon/latest/userguide/trustedidentitypropagation-overview.html#types-identity-enhanced-iam-role-sessions">identity-enhanced
    /// IAM Role sessions</a> for the authenticated user that the API call is being made for.
    /// 
    ///  
    /// <para>
    /// This API uses <a href="https://docs.aws.amazon.com/singlesignon/latest/userguide/trustedidentitypropagation.html">trusted
    /// identity propagation</a> to ensure that an end user is authenticated and receives
    /// the embed URL that is specific to that user. The IAM Identity Center application that
    /// the user has logged into needs to have <a href="https://docs.aws.amazon.com/singlesignon/latest/userguide/trustedidentitypropagation-using-customermanagedapps-specify-trusted-apps.html">trusted
    /// Identity Propagation enabled for QuickSight</a> with the scope value set to <c>quicksight:read</c>.
    /// Before you use this action, make sure that you have configured the relevant QuickSight
    /// resource and permissions.
    /// </para>
    /// </summary>
    [Cmdlet("Initialize", "QSEmbedUrlForRegisteredUserWithIdentity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon QuickSight GenerateEmbedUrlForRegisteredUserWithIdentity API operation.", Operation = new[] {"GenerateEmbedUrlForRegisteredUserWithIdentity"}, SelectReturnType = typeof(Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserWithIdentityResponse))]
    [AWSCmdletOutput("System.String or Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserWithIdentityResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserWithIdentityResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InitializeQSEmbedUrlForRegisteredUserWithIdentityCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AllowedDomain
        /// <summary>
        /// <para>
        /// <para>A list of domains to be allowed to generate the embed URL.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedDomains")]
        public System.String[] AllowedDomain { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services registered user.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter InitialDashboardVisualId_DashboardId
        /// <summary>
        /// <para>
        /// <para>The ID of the dashboard that has the visual that you want to embed. The <c>DashboardId</c>
        /// can be found in the <c>IDs for developers</c> section of the <c>Embed visual</c> pane
        /// of the visual's on-visual menu of the QuickSight console. You can also get the <c>DashboardId</c>
        /// with a <c>ListDashboards</c> API operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_DashboardVisual_InitialDashboardVisualId_DashboardId")]
        public System.String InitialDashboardVisualId_DashboardId { get; set; }
        #endregion
        
        #region Parameter Dashboard_ExecutiveSummary_Enabled
        /// <summary>
        /// <para>
        /// <para>The executive summary settings of an embedded QuickSight console or dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary_Enabled")]
        public System.Boolean? Dashboard_ExecutiveSummary_Enabled { get; set; }
        #endregion
        
        #region Parameter Bookmarks_Enabled
        /// <summary>
        /// <para>
        /// <para>A Boolean value that determines whether a user can bookmark an embedded dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_Dashboard_FeatureConfigurations_Bookmarks_Enabled")]
        public System.Boolean? Bookmarks_Enabled { get; set; }
        #endregion
        
        #region Parameter Dashboard_RecentSnapshots_Enabled
        /// <summary>
        /// <para>
        /// <para>The recent snapshots configuration for an embedded QuickSight dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshots_Enabled")]
        public System.Boolean? Dashboard_RecentSnapshots_Enabled { get; set; }
        #endregion
        
        #region Parameter Dashboard_Schedules_Enabled
        /// <summary>
        /// <para>
        /// <para>The schedules configuration for an embedded QuickSight dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_Dashboard_FeatureConfigurations_Schedules_Enabled")]
        public System.Boolean? Dashboard_Schedules_Enabled { get; set; }
        #endregion
        
        #region Parameter ExperienceConfiguration_Dashboard_FeatureConfigurations_SharedView_Enabled
        /// <summary>
        /// <para>
        /// <para>The shared view settings of an embedded dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ExperienceConfiguration_Dashboard_FeatureConfigurations_SharedView_Enabled { get; set; }
        #endregion
        
        #region Parameter ExperienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_Enabled
        /// <summary>
        /// <para>
        /// <para>Determines if a QuickSight dashboard's state persistence settings are turned on or
        /// off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ExperienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_Enabled { get; set; }
        #endregion
        
        #region Parameter Dashboard_ThresholdAlerts_Enabled
        /// <summary>
        /// <para>
        /// <para>The threshold alerts configuration for an embedded QuickSight dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlerts_Enabled")]
        public System.Boolean? Dashboard_ThresholdAlerts_Enabled { get; set; }
        #endregion
        
        #region Parameter DataQnA_Enabled
        /// <summary>
        /// <para>
        /// <para>The generative Q&amp;A settings of an embedded QuickSight console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataQnA_Enabled")]
        public System.Boolean? DataQnA_Enabled { get; set; }
        #endregion
        
        #region Parameter DataStories_Enabled
        /// <summary>
        /// <para>
        /// <para>The data story settings of an embedded QuickSight console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataStories_Enabled")]
        public System.Boolean? DataStories_Enabled { get; set; }
        #endregion
        
        #region Parameter Console_ExecutiveSummary_Enabled
        /// <summary>
        /// <para>
        /// <para>The executive summary settings of an embedded QuickSight console or dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary_Enabled")]
        public System.Boolean? Console_ExecutiveSummary_Enabled { get; set; }
        #endregion
        
        #region Parameter GenerativeAuthoring_Enabled
        /// <summary>
        /// <para>
        /// <para>The generative BI authoring settings of an embedded QuickSight console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_GenerativeAuthoring_Enabled")]
        public System.Boolean? GenerativeAuthoring_Enabled { get; set; }
        #endregion
        
        #region Parameter Console_RecentSnapshots_Enabled
        /// <summary>
        /// <para>
        /// <para>The recent snapshots configuration for an embedded QuickSight dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshots_Enabled")]
        public System.Boolean? Console_RecentSnapshots_Enabled { get; set; }
        #endregion
        
        #region Parameter Console_Schedules_Enabled
        /// <summary>
        /// <para>
        /// <para>The schedules configuration for an embedded QuickSight dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_Schedules_Enabled")]
        public System.Boolean? Console_Schedules_Enabled { get; set; }
        #endregion
        
        #region Parameter ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_Enabled_SharedView_Enabled
        /// <summary>
        /// <para>
        /// <para>The shared view settings of an embedded dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_Enabled")]
        public System.Boolean? ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_Enabled_SharedView_Enabled { get; set; }
        #endregion
        
        #region Parameter ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_Enabled
        /// <summary>
        /// <para>
        /// <para>Determines if a QuickSight dashboard's state persistence settings are turned on or
        /// off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_Enabled { get; set; }
        #endregion
        
        #region Parameter Console_ThresholdAlerts_Enabled
        /// <summary>
        /// <para>
        /// <para>The threshold alerts configuration for an embedded QuickSight dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlerts_Enabled")]
        public System.Boolean? Console_ThresholdAlerts_Enabled { get; set; }
        #endregion
        
        #region Parameter Dashboard_InitialDashboardId
        /// <summary>
        /// <para>
        /// <para>The dashboard ID for the dashboard that you want the user to see first. This ID is
        /// included in the output URL. When the URL in response is accessed, QuickSight renders
        /// this dashboard if the user has permissions to view it.</para><para>If the user does not have permission to view this dashboard, they see a permissions
        /// error message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_Dashboard_InitialDashboardId")]
        public System.String Dashboard_InitialDashboardId { get; set; }
        #endregion
        
        #region Parameter QuickSightConsole_InitialPath
        /// <summary>
        /// <para>
        /// <para>The initial URL path for the QuickSight console. <c>InitialPath</c> is required.</para><para>The entry point URL is constrained to the following paths:</para><ul><li><para><c>/start</c></para></li><li><para><c>/start/analyses</c></para></li><li><para><c>/start/dashboards</c></para></li><li><para><c>/start/favorites</c></para></li><li><para><c>/dashboards/DashboardId</c>. <i>DashboardId</i> is the actual ID key from the
        /// QuickSight console URL of the dashboard.</para></li><li><para><c>/analyses/AnalysisId</c>. <i>AnalysisId</i> is the actual ID key from the QuickSight
        /// console URL of the analysis.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_QuickSightConsole_InitialPath")]
        public System.String QuickSightConsole_InitialPath { get; set; }
        #endregion
        
        #region Parameter GenerativeQnA_InitialTopicId
        /// <summary>
        /// <para>
        /// <para>The ID of the new Q reader experience topic that you want to make the starting topic
        /// in the Generative Q&amp;A experience. You can find a topic ID by navigating to the
        /// Topics pane in the QuickSight application and opening a topic. The ID is in the URL
        /// for the topic that you open.</para><para>If you don't specify an initial topic or you specify a legacy topic, a list of all
        /// shared new reader experience topics is shown in the Generative Q&amp;A experience
        /// for your readers. When you select an initial new reader experience topic, you can
        /// specify whether or not readers are allowed to select other new reader experience topics
        /// from the available ones in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_GenerativeQnA_InitialTopicId")]
        public System.String GenerativeQnA_InitialTopicId { get; set; }
        #endregion
        
        #region Parameter QSearchBar_InitialTopicId
        /// <summary>
        /// <para>
        /// <para>The ID of the legacy Q topic that you want to use as the starting topic in the Q search
        /// bar. To locate the topic ID of the topic that you want to use, open the <a href="https://quicksight.aws.amazon.com/">QuickSight
        /// console</a>, navigate to the <b>Topics</b> pane, and choose thre topic that you want
        /// to use. The <c>TopicID</c> is located in the URL of the topic that opens. When you
        /// select an initial topic, you can specify whether or not readers are allowed to select
        /// other topics from the list of available topics.</para><para>If you don't specify an initial topic or if you specify a new reader experience topic,
        /// a list of all shared legacy topics is shown in the Q bar. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_QSearchBar_InitialTopicId")]
        public System.String QSearchBar_InitialTopicId { get; set; }
        #endregion
        
        #region Parameter SessionLifetimeInMinute
        /// <summary>
        /// <para>
        /// <para>The validity of the session in minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionLifetimeInMinutes")]
        public System.Int64? SessionLifetimeInMinute { get; set; }
        #endregion
        
        #region Parameter InitialDashboardVisualId_SheetId
        /// <summary>
        /// <para>
        /// <para>The ID of the sheet that the has visual that you want to embed. The <c>SheetId</c>
        /// can be found in the <c>IDs for developers</c> section of the <c>Embed visual</c> pane
        /// of the visual's on-visual menu of the QuickSight console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_DashboardVisual_InitialDashboardVisualId_SheetId")]
        public System.String InitialDashboardVisualId_SheetId { get; set; }
        #endregion
        
        #region Parameter InitialDashboardVisualId_VisualId
        /// <summary>
        /// <para>
        /// <para>The ID of the visual that you want to embed. The <c>VisualID</c> can be found in the
        /// <c>IDs for developers</c> section of the <c>Embed visual</c> pane of the visual's
        /// on-visual menu of the QuickSight console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_DashboardVisual_InitialDashboardVisualId_VisualId")]
        public System.String InitialDashboardVisualId_VisualId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EmbedUrl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserWithIdentityResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserWithIdentityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EmbedUrl";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AwsAccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Initialize-QSEmbedUrlForRegisteredUserWithIdentity (GenerateEmbedUrlForRegisteredUserWithIdentity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserWithIdentityResponse, InitializeQSEmbedUrlForRegisteredUserWithIdentityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllowedDomain != null)
            {
                context.AllowedDomain = new List<System.String>(this.AllowedDomain);
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Dashboard_ExecutiveSummary_Enabled = this.Dashboard_ExecutiveSummary_Enabled;
            context.Bookmarks_Enabled = this.Bookmarks_Enabled;
            context.Dashboard_RecentSnapshots_Enabled = this.Dashboard_RecentSnapshots_Enabled;
            context.Dashboard_Schedules_Enabled = this.Dashboard_Schedules_Enabled;
            context.ExperienceConfiguration_Dashboard_FeatureConfigurations_SharedView_Enabled = this.ExperienceConfiguration_Dashboard_FeatureConfigurations_SharedView_Enabled;
            context.ExperienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_Enabled = this.ExperienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_Enabled;
            context.Dashboard_ThresholdAlerts_Enabled = this.Dashboard_ThresholdAlerts_Enabled;
            context.Dashboard_InitialDashboardId = this.Dashboard_InitialDashboardId;
            context.InitialDashboardVisualId_DashboardId = this.InitialDashboardVisualId_DashboardId;
            context.InitialDashboardVisualId_SheetId = this.InitialDashboardVisualId_SheetId;
            context.InitialDashboardVisualId_VisualId = this.InitialDashboardVisualId_VisualId;
            context.GenerativeQnA_InitialTopicId = this.GenerativeQnA_InitialTopicId;
            context.QSearchBar_InitialTopicId = this.QSearchBar_InitialTopicId;
            context.DataQnA_Enabled = this.DataQnA_Enabled;
            context.DataStories_Enabled = this.DataStories_Enabled;
            context.Console_ExecutiveSummary_Enabled = this.Console_ExecutiveSummary_Enabled;
            context.GenerativeAuthoring_Enabled = this.GenerativeAuthoring_Enabled;
            context.Console_RecentSnapshots_Enabled = this.Console_RecentSnapshots_Enabled;
            context.Console_Schedules_Enabled = this.Console_Schedules_Enabled;
            context.ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_Enabled_SharedView_Enabled = this.ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_Enabled_SharedView_Enabled;
            context.ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_Enabled = this.ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_Enabled;
            context.Console_ThresholdAlerts_Enabled = this.Console_ThresholdAlerts_Enabled;
            context.QuickSightConsole_InitialPath = this.QuickSightConsole_InitialPath;
            context.SessionLifetimeInMinute = this.SessionLifetimeInMinute;
            
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
            var request = new Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserWithIdentityRequest();
            
            if (cmdletContext.AllowedDomain != null)
            {
                request.AllowedDomains = cmdletContext.AllowedDomain;
            }
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            
             // populate ExperienceConfiguration
            request.ExperienceConfiguration = new Amazon.QuickSight.Model.RegisteredUserEmbeddingExperienceConfiguration();
            Amazon.QuickSight.Model.RegisteredUserDashboardVisualEmbeddingConfiguration requestExperienceConfiguration_experienceConfiguration_DashboardVisual = null;
            
             // populate DashboardVisual
            var requestExperienceConfiguration_experienceConfiguration_DashboardVisualIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_DashboardVisual = new Amazon.QuickSight.Model.RegisteredUserDashboardVisualEmbeddingConfiguration();
            Amazon.QuickSight.Model.DashboardVisualId requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId = null;
            
             // populate InitialDashboardVisualId
            var requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualIdIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId = new Amazon.QuickSight.Model.DashboardVisualId();
            System.String requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId_initialDashboardVisualId_DashboardId = null;
            if (cmdletContext.InitialDashboardVisualId_DashboardId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId_initialDashboardVisualId_DashboardId = cmdletContext.InitialDashboardVisualId_DashboardId;
            }
            if (requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId_initialDashboardVisualId_DashboardId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId.DashboardId = requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId_initialDashboardVisualId_DashboardId;
                requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualIdIsNull = false;
            }
            System.String requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId_initialDashboardVisualId_SheetId = null;
            if (cmdletContext.InitialDashboardVisualId_SheetId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId_initialDashboardVisualId_SheetId = cmdletContext.InitialDashboardVisualId_SheetId;
            }
            if (requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId_initialDashboardVisualId_SheetId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId.SheetId = requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId_initialDashboardVisualId_SheetId;
                requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualIdIsNull = false;
            }
            System.String requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId_initialDashboardVisualId_VisualId = null;
            if (cmdletContext.InitialDashboardVisualId_VisualId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId_initialDashboardVisualId_VisualId = cmdletContext.InitialDashboardVisualId_VisualId;
            }
            if (requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId_initialDashboardVisualId_VisualId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId.VisualId = requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId_initialDashboardVisualId_VisualId;
                requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualIdIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualIdIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_DashboardVisual.InitialDashboardVisualId = requestExperienceConfiguration_experienceConfiguration_DashboardVisual_experienceConfiguration_DashboardVisual_InitialDashboardVisualId;
                requestExperienceConfiguration_experienceConfiguration_DashboardVisualIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_DashboardVisual should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_DashboardVisualIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_DashboardVisual = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_DashboardVisual != null)
            {
                request.ExperienceConfiguration.DashboardVisual = requestExperienceConfiguration_experienceConfiguration_DashboardVisual;
            }
            Amazon.QuickSight.Model.RegisteredUserGenerativeQnAEmbeddingConfiguration requestExperienceConfiguration_experienceConfiguration_GenerativeQnA = null;
            
             // populate GenerativeQnA
            var requestExperienceConfiguration_experienceConfiguration_GenerativeQnAIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_GenerativeQnA = new Amazon.QuickSight.Model.RegisteredUserGenerativeQnAEmbeddingConfiguration();
            System.String requestExperienceConfiguration_experienceConfiguration_GenerativeQnA_generativeQnA_InitialTopicId = null;
            if (cmdletContext.GenerativeQnA_InitialTopicId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_GenerativeQnA_generativeQnA_InitialTopicId = cmdletContext.GenerativeQnA_InitialTopicId;
            }
            if (requestExperienceConfiguration_experienceConfiguration_GenerativeQnA_generativeQnA_InitialTopicId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_GenerativeQnA.InitialTopicId = requestExperienceConfiguration_experienceConfiguration_GenerativeQnA_generativeQnA_InitialTopicId;
                requestExperienceConfiguration_experienceConfiguration_GenerativeQnAIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_GenerativeQnA should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_GenerativeQnAIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_GenerativeQnA = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_GenerativeQnA != null)
            {
                request.ExperienceConfiguration.GenerativeQnA = requestExperienceConfiguration_experienceConfiguration_GenerativeQnA;
            }
            Amazon.QuickSight.Model.RegisteredUserQSearchBarEmbeddingConfiguration requestExperienceConfiguration_experienceConfiguration_QSearchBar = null;
            
             // populate QSearchBar
            var requestExperienceConfiguration_experienceConfiguration_QSearchBarIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QSearchBar = new Amazon.QuickSight.Model.RegisteredUserQSearchBarEmbeddingConfiguration();
            System.String requestExperienceConfiguration_experienceConfiguration_QSearchBar_qSearchBar_InitialTopicId = null;
            if (cmdletContext.QSearchBar_InitialTopicId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QSearchBar_qSearchBar_InitialTopicId = cmdletContext.QSearchBar_InitialTopicId;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QSearchBar_qSearchBar_InitialTopicId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QSearchBar.InitialTopicId = requestExperienceConfiguration_experienceConfiguration_QSearchBar_qSearchBar_InitialTopicId;
                requestExperienceConfiguration_experienceConfiguration_QSearchBarIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_QSearchBar should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_QSearchBarIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_QSearchBar = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QSearchBar != null)
            {
                request.ExperienceConfiguration.QSearchBar = requestExperienceConfiguration_experienceConfiguration_QSearchBar;
            }
            Amazon.QuickSight.Model.RegisteredUserDashboardEmbeddingConfiguration requestExperienceConfiguration_experienceConfiguration_Dashboard = null;
            
             // populate Dashboard
            var requestExperienceConfiguration_experienceConfiguration_DashboardIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_Dashboard = new Amazon.QuickSight.Model.RegisteredUserDashboardEmbeddingConfiguration();
            System.String requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_InitialDashboardId = null;
            if (cmdletContext.Dashboard_InitialDashboardId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_InitialDashboardId = cmdletContext.Dashboard_InitialDashboardId;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_InitialDashboardId != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard.InitialDashboardId = requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_InitialDashboardId;
                requestExperienceConfiguration_experienceConfiguration_DashboardIsNull = false;
            }
            Amazon.QuickSight.Model.RegisteredUserDashboardFeatureConfigurations requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations = null;
            
             // populate FeatureConfigurations
            var requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurationsIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations = new Amazon.QuickSight.Model.RegisteredUserDashboardFeatureConfigurations();
            Amazon.QuickSight.Model.AmazonQInQuickSightDashboardConfigurations requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight = null;
            
             // populate AmazonQInQuickSight
            var requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSightIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight = new Amazon.QuickSight.Model.AmazonQInQuickSightDashboardConfigurations();
            Amazon.QuickSight.Model.ExecutiveSummaryConfigurations requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary = null;
            
             // populate ExecutiveSummary
            var requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummaryIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary = new Amazon.QuickSight.Model.ExecutiveSummaryConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary_dashboard_ExecutiveSummary_Enabled = null;
            if (cmdletContext.Dashboard_ExecutiveSummary_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary_dashboard_ExecutiveSummary_Enabled = cmdletContext.Dashboard_ExecutiveSummary_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary_dashboard_ExecutiveSummary_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary.Enabled = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary_dashboard_ExecutiveSummary_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummaryIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummaryIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight.ExecutiveSummary = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary;
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSightIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSightIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations.AmazonQInQuickSight = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight;
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurationsIsNull = false;
            }
            Amazon.QuickSight.Model.BookmarksConfigurations requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Bookmarks = null;
            
             // populate Bookmarks
            var requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_BookmarksIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Bookmarks = new Amazon.QuickSight.Model.BookmarksConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Bookmarks_bookmarks_Enabled = null;
            if (cmdletContext.Bookmarks_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Bookmarks_bookmarks_Enabled = cmdletContext.Bookmarks_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Bookmarks_bookmarks_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Bookmarks.Enabled = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Bookmarks_bookmarks_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_BookmarksIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Bookmarks should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_BookmarksIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Bookmarks = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Bookmarks != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations.Bookmarks = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Bookmarks;
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurationsIsNull = false;
            }
            Amazon.QuickSight.Model.RecentSnapshotsConfigurations requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshots = null;
            
             // populate RecentSnapshots
            var requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshotsIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshots = new Amazon.QuickSight.Model.RecentSnapshotsConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshots_dashboard_RecentSnapshots_Enabled = null;
            if (cmdletContext.Dashboard_RecentSnapshots_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshots_dashboard_RecentSnapshots_Enabled = cmdletContext.Dashboard_RecentSnapshots_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshots_dashboard_RecentSnapshots_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshots.Enabled = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshots_dashboard_RecentSnapshots_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshotsIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshots should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshotsIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshots = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshots != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations.RecentSnapshots = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshots;
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurationsIsNull = false;
            }
            Amazon.QuickSight.Model.SchedulesConfigurations requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Schedules = null;
            
             // populate Schedules
            var requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SchedulesIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Schedules = new Amazon.QuickSight.Model.SchedulesConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Schedules_dashboard_Schedules_Enabled = null;
            if (cmdletContext.Dashboard_Schedules_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Schedules_dashboard_Schedules_Enabled = cmdletContext.Dashboard_Schedules_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Schedules_dashboard_Schedules_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Schedules.Enabled = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Schedules_dashboard_Schedules_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SchedulesIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Schedules should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SchedulesIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Schedules = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Schedules != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations.Schedules = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_Schedules;
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurationsIsNull = false;
            }
            Amazon.QuickSight.Model.SharedViewConfigurations requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView = null;
            
             // populate SharedView
            var requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedViewIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView = new Amazon.QuickSight.Model.SharedViewConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView_Enabled = null;
            if (cmdletContext.ExperienceConfiguration_Dashboard_FeatureConfigurations_SharedView_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView_Enabled = cmdletContext.ExperienceConfiguration_Dashboard_FeatureConfigurations_SharedView_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView.Enabled = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedViewIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedViewIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations.SharedView = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView;
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurationsIsNull = false;
            }
            Amazon.QuickSight.Model.StatePersistenceConfigurations requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence = null;
            
             // populate StatePersistence
            var requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistenceIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence = new Amazon.QuickSight.Model.StatePersistenceConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_Enabled = null;
            if (cmdletContext.ExperienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_Enabled = cmdletContext.ExperienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence.Enabled = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistenceIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistenceIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations.StatePersistence = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence;
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurationsIsNull = false;
            }
            Amazon.QuickSight.Model.ThresholdAlertsConfigurations requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlerts = null;
            
             // populate ThresholdAlerts
            var requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlertsIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlerts = new Amazon.QuickSight.Model.ThresholdAlertsConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlerts_dashboard_ThresholdAlerts_Enabled = null;
            if (cmdletContext.Dashboard_ThresholdAlerts_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlerts_dashboard_ThresholdAlerts_Enabled = cmdletContext.Dashboard_ThresholdAlerts_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlerts_dashboard_ThresholdAlerts_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlerts.Enabled = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlerts_dashboard_ThresholdAlerts_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlertsIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlerts should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlertsIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlerts = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlerts != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations.ThresholdAlerts = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlerts;
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurationsIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurationsIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard.FeatureConfigurations = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations;
                requestExperienceConfiguration_experienceConfiguration_DashboardIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_Dashboard should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_DashboardIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard != null)
            {
                request.ExperienceConfiguration.Dashboard = requestExperienceConfiguration_experienceConfiguration_Dashboard;
            }
            Amazon.QuickSight.Model.RegisteredUserQuickSightConsoleEmbeddingConfiguration requestExperienceConfiguration_experienceConfiguration_QuickSightConsole = null;
            
             // populate QuickSightConsole
            var requestExperienceConfiguration_experienceConfiguration_QuickSightConsoleIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QuickSightConsole = new Amazon.QuickSight.Model.RegisteredUserQuickSightConsoleEmbeddingConfiguration();
            System.String requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_quickSightConsole_InitialPath = null;
            if (cmdletContext.QuickSightConsole_InitialPath != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_quickSightConsole_InitialPath = cmdletContext.QuickSightConsole_InitialPath;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_quickSightConsole_InitialPath != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole.InitialPath = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_quickSightConsole_InitialPath;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsoleIsNull = false;
            }
            Amazon.QuickSight.Model.RegisteredUserConsoleFeatureConfigurations requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations = null;
            
             // populate FeatureConfigurations
            var requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurationsIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations = new Amazon.QuickSight.Model.RegisteredUserConsoleFeatureConfigurations();
            Amazon.QuickSight.Model.RecentSnapshotsConfigurations requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshots = null;
            
             // populate RecentSnapshots
            var requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshotsIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshots = new Amazon.QuickSight.Model.RecentSnapshotsConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshots_console_RecentSnapshots_Enabled = null;
            if (cmdletContext.Console_RecentSnapshots_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshots_console_RecentSnapshots_Enabled = cmdletContext.Console_RecentSnapshots_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshots_console_RecentSnapshots_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshots.Enabled = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshots_console_RecentSnapshots_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshotsIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshots should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshotsIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshots = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshots != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations.RecentSnapshots = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshots;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurationsIsNull = false;
            }
            Amazon.QuickSight.Model.SchedulesConfigurations requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_Schedules = null;
            
             // populate Schedules
            var requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SchedulesIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_Schedules = new Amazon.QuickSight.Model.SchedulesConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_Schedules_console_Schedules_Enabled = null;
            if (cmdletContext.Console_Schedules_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_Schedules_console_Schedules_Enabled = cmdletContext.Console_Schedules_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_Schedules_console_Schedules_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_Schedules.Enabled = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_Schedules_console_Schedules_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SchedulesIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_Schedules should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SchedulesIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_Schedules = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_Schedules != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations.Schedules = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_Schedules;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurationsIsNull = false;
            }
            Amazon.QuickSight.Model.SharedViewConfigurations requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView = null;
            
             // populate SharedView
            var requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedViewIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView = new Amazon.QuickSight.Model.SharedViewConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_Enabled_SharedView_Enabled = null;
            if (cmdletContext.ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_Enabled_SharedView_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_Enabled_SharedView_Enabled = cmdletContext.ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_Enabled_SharedView_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_Enabled_SharedView_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView.Enabled = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_Enabled_SharedView_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedViewIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedViewIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations.SharedView = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurationsIsNull = false;
            }
            Amazon.QuickSight.Model.StatePersistenceConfigurations requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence = null;
            
             // populate StatePersistence
            var requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistenceIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence = new Amazon.QuickSight.Model.StatePersistenceConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_Enabled = null;
            if (cmdletContext.ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_Enabled = cmdletContext.ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence.Enabled = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistenceIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistenceIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations.StatePersistence = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurationsIsNull = false;
            }
            Amazon.QuickSight.Model.ThresholdAlertsConfigurations requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlerts = null;
            
             // populate ThresholdAlerts
            var requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlertsIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlerts = new Amazon.QuickSight.Model.ThresholdAlertsConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlerts_console_ThresholdAlerts_Enabled = null;
            if (cmdletContext.Console_ThresholdAlerts_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlerts_console_ThresholdAlerts_Enabled = cmdletContext.Console_ThresholdAlerts_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlerts_console_ThresholdAlerts_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlerts.Enabled = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlerts_console_ThresholdAlerts_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlertsIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlerts should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlertsIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlerts = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlerts != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations.ThresholdAlerts = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlerts;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurationsIsNull = false;
            }
            Amazon.QuickSight.Model.AmazonQInQuickSightConsoleConfigurations requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight = null;
            
             // populate AmazonQInQuickSight
            var requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSightIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight = new Amazon.QuickSight.Model.AmazonQInQuickSightConsoleConfigurations();
            Amazon.QuickSight.Model.DataQnAConfigurations requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataQnA = null;
            
             // populate DataQnA
            var requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataQnAIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataQnA = new Amazon.QuickSight.Model.DataQnAConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataQnA_dataQnA_Enabled = null;
            if (cmdletContext.DataQnA_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataQnA_dataQnA_Enabled = cmdletContext.DataQnA_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataQnA_dataQnA_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataQnA.Enabled = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataQnA_dataQnA_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataQnAIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataQnA should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataQnAIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataQnA = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataQnA != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight.DataQnA = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataQnA;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSightIsNull = false;
            }
            Amazon.QuickSight.Model.DataStoriesConfigurations requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataStories = null;
            
             // populate DataStories
            var requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataStoriesIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataStories = new Amazon.QuickSight.Model.DataStoriesConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataStories_dataStories_Enabled = null;
            if (cmdletContext.DataStories_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataStories_dataStories_Enabled = cmdletContext.DataStories_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataStories_dataStories_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataStories.Enabled = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataStories_dataStories_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataStoriesIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataStories should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataStoriesIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataStories = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataStories != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight.DataStories = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_DataStories;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSightIsNull = false;
            }
            Amazon.QuickSight.Model.ExecutiveSummaryConfigurations requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary = null;
            
             // populate ExecutiveSummary
            var requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummaryIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary = new Amazon.QuickSight.Model.ExecutiveSummaryConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary_console_ExecutiveSummary_Enabled = null;
            if (cmdletContext.Console_ExecutiveSummary_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary_console_ExecutiveSummary_Enabled = cmdletContext.Console_ExecutiveSummary_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary_console_ExecutiveSummary_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary.Enabled = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary_console_ExecutiveSummary_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummaryIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummaryIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight.ExecutiveSummary = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSightIsNull = false;
            }
            Amazon.QuickSight.Model.GenerativeAuthoringConfigurations requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_GenerativeAuthoring = null;
            
             // populate GenerativeAuthoring
            var requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_GenerativeAuthoringIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_GenerativeAuthoring = new Amazon.QuickSight.Model.GenerativeAuthoringConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_GenerativeAuthoring_generativeAuthoring_Enabled = null;
            if (cmdletContext.GenerativeAuthoring_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_GenerativeAuthoring_generativeAuthoring_Enabled = cmdletContext.GenerativeAuthoring_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_GenerativeAuthoring_generativeAuthoring_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_GenerativeAuthoring.Enabled = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_GenerativeAuthoring_generativeAuthoring_Enabled.Value;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_GenerativeAuthoringIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_GenerativeAuthoring should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_GenerativeAuthoringIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_GenerativeAuthoring = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_GenerativeAuthoring != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight.GenerativeAuthoring = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_GenerativeAuthoring;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSightIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSightIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations.AmazonQInQuickSight = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations_experienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurationsIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurationsIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations != null)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole.FeatureConfigurations = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole_experienceConfiguration_QuickSightConsole_FeatureConfigurations;
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsoleIsNull = false;
            }
             // determine if requestExperienceConfiguration_experienceConfiguration_QuickSightConsole should be set to null
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsoleIsNull)
            {
                requestExperienceConfiguration_experienceConfiguration_QuickSightConsole = null;
            }
            if (requestExperienceConfiguration_experienceConfiguration_QuickSightConsole != null)
            {
                request.ExperienceConfiguration.QuickSightConsole = requestExperienceConfiguration_experienceConfiguration_QuickSightConsole;
            }
            if (cmdletContext.SessionLifetimeInMinute != null)
            {
                request.SessionLifetimeInMinutes = cmdletContext.SessionLifetimeInMinute.Value;
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
        
        private Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserWithIdentityResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserWithIdentityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "GenerateEmbedUrlForRegisteredUserWithIdentity");
            try
            {
                return client.GenerateEmbedUrlForRegisteredUserWithIdentityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AllowedDomain { get; set; }
            public System.String AwsAccountId { get; set; }
            public System.Boolean? Dashboard_ExecutiveSummary_Enabled { get; set; }
            public System.Boolean? Bookmarks_Enabled { get; set; }
            public System.Boolean? Dashboard_RecentSnapshots_Enabled { get; set; }
            public System.Boolean? Dashboard_Schedules_Enabled { get; set; }
            public System.Boolean? ExperienceConfiguration_Dashboard_FeatureConfigurations_SharedView_Enabled { get; set; }
            public System.Boolean? ExperienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_Enabled { get; set; }
            public System.Boolean? Dashboard_ThresholdAlerts_Enabled { get; set; }
            public System.String Dashboard_InitialDashboardId { get; set; }
            public System.String InitialDashboardVisualId_DashboardId { get; set; }
            public System.String InitialDashboardVisualId_SheetId { get; set; }
            public System.String InitialDashboardVisualId_VisualId { get; set; }
            public System.String GenerativeQnA_InitialTopicId { get; set; }
            public System.String QSearchBar_InitialTopicId { get; set; }
            public System.Boolean? DataQnA_Enabled { get; set; }
            public System.Boolean? DataStories_Enabled { get; set; }
            public System.Boolean? Console_ExecutiveSummary_Enabled { get; set; }
            public System.Boolean? GenerativeAuthoring_Enabled { get; set; }
            public System.Boolean? Console_RecentSnapshots_Enabled { get; set; }
            public System.Boolean? Console_Schedules_Enabled { get; set; }
            public System.Boolean? ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_Enabled_SharedView_Enabled { get; set; }
            public System.Boolean? ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_Enabled { get; set; }
            public System.Boolean? Console_ThresholdAlerts_Enabled { get; set; }
            public System.String QuickSightConsole_InitialPath { get; set; }
            public System.Int64? SessionLifetimeInMinute { get; set; }
            public System.Func<Amazon.QuickSight.Model.GenerateEmbedUrlForRegisteredUserWithIdentityResponse, InitializeQSEmbedUrlForRegisteredUserWithIdentityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EmbedUrl;
        }
        
    }
}
