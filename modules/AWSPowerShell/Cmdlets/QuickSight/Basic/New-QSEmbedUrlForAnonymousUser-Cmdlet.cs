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
    /// Generates an embed URL that you can use to embed an Amazon QuickSight dashboard or
    /// visual in your website, without having to register any reader users. Before you use
    /// this action, make sure that you have configured the dashboards and permissions.
    /// 
    ///  
    /// <para>
    /// The following rules apply to the generated URL:
    /// </para><ul><li><para>
    /// It contains a temporary bearer token. It is valid for 5 minutes after it is generated.
    /// Once redeemed within this period, it cannot be re-used again.
    /// </para></li><li><para>
    /// The URL validity period should not be confused with the actual session lifetime that
    /// can be customized using the <c><a href="https://docs.aws.amazon.com/quicksight/latest/APIReference/API_GenerateEmbedUrlForAnonymousUser.html#QS-GenerateEmbedUrlForAnonymousUser-request-SessionLifetimeInMinutes">SessionLifetimeInMinutes</a></c> parameter. The resulting user session is valid for 15 minutes (minimum) to 10
    /// hours (maximum). The default session duration is 10 hours.
    /// </para></li><li><para>
    /// You are charged only when the URL is used or there is interaction with Amazon QuickSight.
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/embedded-analytics.html">Embedded
    /// Analytics</a> in the <i>Amazon QuickSight User Guide</i>.
    /// </para><para>
    /// For more information about the high-level steps for embedding and for an interactive
    /// demo of the ways you can customize embedding, visit the <a href="https://docs.aws.amazon.com/quicksight/latest/user/quicksight-dev-portal.html">Amazon
    /// QuickSight Developer Portal</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "QSEmbedUrlForAnonymousUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon QuickSight GenerateEmbedUrlForAnonymousUser API operation.", Operation = new[] {"GenerateEmbedUrlForAnonymousUser"}, SelectReturnType = typeof(Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse))]
    [AWSCmdletOutput("System.String or Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewQSEmbedUrlForAnonymousUserCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AllowedDomain
        /// <summary>
        /// <para>
        /// <para>The domains that you want to add to the allow list for access to the generated URL
        /// that is then embedded. This optional parameter overrides the static domains that are
        /// configured in the Manage QuickSight menu in the QuickSight console. Instead, it allows
        /// only the domains that you include in this parameter. You can list up to three domains
        /// or subdomains in each API call.</para><para>To include all subdomains under a specific domain to the allow list, use <c>*</c>.
        /// For example, <c>https://*.sapp.amazon.com</c> includes all subdomains under <c>https://sapp.amazon.com</c>.</para><para />
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
        
        #region Parameter AuthorizedResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) for the QuickSight resources that the user is authorized
        /// to access during the lifetime of the session.</para><para>If you choose <c>Dashboard</c> embedding experience, pass the list of dashboard ARNs
        /// in the account that you want the user to be able to view.</para><para>If you want to make changes to the theme of your embedded content, pass a list of
        /// theme ARNs that the anonymous users need access to.</para><para>Currently, you can pass up to 25 theme ARNs in each API call.</para><para />
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
        [Alias("AuthorizedResourceArns")]
        public System.String[] AuthorizedResourceArn { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID for the Amazon Web Services account that contains the dashboard that you're
        /// embedding.</para>
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
        
        #region Parameter Dashboard_DisabledFeature
        /// <summary>
        /// <para>
        /// <para>A list of all disabled features of a specified anonymous dashboard.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_Dashboard_DisabledFeatures")]
        public System.String[] Dashboard_DisabledFeature { get; set; }
        #endregion
        
        #region Parameter SharedView_Enabled
        /// <summary>
        /// <para>
        /// <para>The shared view settings of an embedded dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_Dashboard_FeatureConfigurations_SharedView_Enabled")]
        public System.Boolean? SharedView_Enabled { get; set; }
        #endregion
        
        #region Parameter Dashboard_EnabledFeature
        /// <summary>
        /// <para>
        /// <para>A list of all enabled features of a specified anonymous dashboard.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_Dashboard_EnabledFeatures")]
        public System.String[] Dashboard_EnabledFeature { get; set; }
        #endregion
        
        #region Parameter Dashboard_InitialDashboardId
        /// <summary>
        /// <para>
        /// <para>The dashboard ID for the dashboard that you want the user to see first. This ID is
        /// included in the output URL. When the URL in response is accessed, QuickSight renders
        /// this dashboard.</para><para>The Amazon Resource Name (ARN) of this dashboard must be included in the <c>AuthorizedResourceArns</c>
        /// parameter. Otherwise, the request will fail with <c>InvalidParameterValueException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_Dashboard_InitialDashboardId")]
        public System.String Dashboard_InitialDashboardId { get; set; }
        #endregion
        
        #region Parameter GenerativeQnA_InitialTopicId
        /// <summary>
        /// <para>
        /// <para>The QuickSight Q topic ID of the new reader experience topic that you want the anonymous
        /// user to see first. This ID is included in the output URL. When the URL in response
        /// is accessed, QuickSight renders the Generative Q&amp;A experience with this new reader
        /// experience topic pre selected.</para><para>The Amazon Resource Name (ARN) of this Q new reader experience topic must be included
        /// in the <c>AuthorizedResourceArns</c> parameter. Otherwise, the request fails with
        /// an <c>InvalidParameterValueException</c> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_GenerativeQnA_InitialTopicId")]
        public System.String GenerativeQnA_InitialTopicId { get; set; }
        #endregion
        
        #region Parameter QSearchBar_InitialTopicId
        /// <summary>
        /// <para>
        /// <para>The QuickSight Q topic ID of the legacy topic that you want the anonymous user to
        /// see first. This ID is included in the output URL. When the URL in response is accessed,
        /// QuickSight renders the Q search bar with this legacy topic pre-selected.</para><para>The Amazon Resource Name (ARN) of this Q legacy topic must be included in the <c>AuthorizedResourceArns</c>
        /// parameter. Otherwise, the request fails with an <c>InvalidParameterValueException</c>
        /// error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExperienceConfiguration_QSearchBar_InitialTopicId")]
        public System.String QSearchBar_InitialTopicId { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The QuickSight namespace that the anonymous user virtually belongs to. If you are
        /// not using an Amazon QuickSight custom namespace, set this to <c>default</c>.</para>
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
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter SessionLifetimeInMinute
        /// <summary>
        /// <para>
        /// <para>How many minutes the session is valid. The session lifetime must be in [15-600] minutes
        /// range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionLifetimeInMinutes")]
        public System.Int64? SessionLifetimeInMinute { get; set; }
        #endregion
        
        #region Parameter SessionTag
        /// <summary>
        /// <para>
        /// <para>The session tags used for row-level security. Before you use this parameter, make
        /// sure that you have configured the relevant datasets using the <c>DataSet$RowLevelPermissionTagConfiguration</c>
        /// parameter so that session tags can be used to provide row-level security.</para><para>These are not the tags used for the Amazon Web Services resource tagging feature.
        /// For more information, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/quicksight-dev-rls-tags.html">Using
        /// Row-Level Security (RLS) with Tags</a>in the <i>Amazon QuickSight User Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionTags")]
        public Amazon.QuickSight.Model.SessionTag[] SessionTag { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSEmbedUrlForAnonymousUser (GenerateEmbedUrlForAnonymousUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse, NewQSEmbedUrlForAnonymousUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllowedDomain != null)
            {
                context.AllowedDomain = new List<System.String>(this.AllowedDomain);
            }
            if (this.AuthorizedResourceArn != null)
            {
                context.AuthorizedResourceArn = new List<System.String>(this.AuthorizedResourceArn);
            }
            #if MODULAR
            if (this.AuthorizedResourceArn == null && ParameterWasBound(nameof(this.AuthorizedResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizedResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Dashboard_DisabledFeature != null)
            {
                context.Dashboard_DisabledFeature = new List<System.String>(this.Dashboard_DisabledFeature);
            }
            if (this.Dashboard_EnabledFeature != null)
            {
                context.Dashboard_EnabledFeature = new List<System.String>(this.Dashboard_EnabledFeature);
            }
            context.SharedView_Enabled = this.SharedView_Enabled;
            context.Dashboard_InitialDashboardId = this.Dashboard_InitialDashboardId;
            context.InitialDashboardVisualId_DashboardId = this.InitialDashboardVisualId_DashboardId;
            context.InitialDashboardVisualId_SheetId = this.InitialDashboardVisualId_SheetId;
            context.InitialDashboardVisualId_VisualId = this.InitialDashboardVisualId_VisualId;
            context.GenerativeQnA_InitialTopicId = this.GenerativeQnA_InitialTopicId;
            context.QSearchBar_InitialTopicId = this.QSearchBar_InitialTopicId;
            context.Namespace = this.Namespace;
            #if MODULAR
            if (this.Namespace == null && ParameterWasBound(nameof(this.Namespace)))
            {
                WriteWarning("You are passing $null as a value for parameter Namespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionLifetimeInMinute = this.SessionLifetimeInMinute;
            if (this.SessionTag != null)
            {
                context.SessionTag = new List<Amazon.QuickSight.Model.SessionTag>(this.SessionTag);
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
            var request = new Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserRequest();
            
            if (cmdletContext.AllowedDomain != null)
            {
                request.AllowedDomains = cmdletContext.AllowedDomain;
            }
            if (cmdletContext.AuthorizedResourceArn != null)
            {
                request.AuthorizedResourceArns = cmdletContext.AuthorizedResourceArn;
            }
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            
             // populate ExperienceConfiguration
            var requestExperienceConfigurationIsNull = true;
            request.ExperienceConfiguration = new Amazon.QuickSight.Model.AnonymousUserEmbeddingExperienceConfiguration();
            Amazon.QuickSight.Model.AnonymousUserDashboardVisualEmbeddingConfiguration requestExperienceConfiguration_experienceConfiguration_DashboardVisual = null;
            
             // populate DashboardVisual
            var requestExperienceConfiguration_experienceConfiguration_DashboardVisualIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_DashboardVisual = new Amazon.QuickSight.Model.AnonymousUserDashboardVisualEmbeddingConfiguration();
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
                requestExperienceConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.AnonymousUserGenerativeQnAEmbeddingConfiguration requestExperienceConfiguration_experienceConfiguration_GenerativeQnA = null;
            
             // populate GenerativeQnA
            var requestExperienceConfiguration_experienceConfiguration_GenerativeQnAIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_GenerativeQnA = new Amazon.QuickSight.Model.AnonymousUserGenerativeQnAEmbeddingConfiguration();
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
                requestExperienceConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.AnonymousUserQSearchBarEmbeddingConfiguration requestExperienceConfiguration_experienceConfiguration_QSearchBar = null;
            
             // populate QSearchBar
            var requestExperienceConfiguration_experienceConfiguration_QSearchBarIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_QSearchBar = new Amazon.QuickSight.Model.AnonymousUserQSearchBarEmbeddingConfiguration();
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
                requestExperienceConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.AnonymousUserDashboardEmbeddingConfiguration requestExperienceConfiguration_experienceConfiguration_Dashboard = null;
            
             // populate Dashboard
            var requestExperienceConfiguration_experienceConfiguration_DashboardIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_Dashboard = new Amazon.QuickSight.Model.AnonymousUserDashboardEmbeddingConfiguration();
            List<System.String> requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_DisabledFeature = null;
            if (cmdletContext.Dashboard_DisabledFeature != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_DisabledFeature = cmdletContext.Dashboard_DisabledFeature;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_DisabledFeature != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard.DisabledFeatures = requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_DisabledFeature;
                requestExperienceConfiguration_experienceConfiguration_DashboardIsNull = false;
            }
            List<System.String> requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_EnabledFeature = null;
            if (cmdletContext.Dashboard_EnabledFeature != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_EnabledFeature = cmdletContext.Dashboard_EnabledFeature;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_EnabledFeature != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard.EnabledFeatures = requestExperienceConfiguration_experienceConfiguration_Dashboard_dashboard_EnabledFeature;
                requestExperienceConfiguration_experienceConfiguration_DashboardIsNull = false;
            }
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
            Amazon.QuickSight.Model.AnonymousUserDashboardFeatureConfigurations requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations = null;
            
             // populate FeatureConfigurations
            var requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurationsIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations = new Amazon.QuickSight.Model.AnonymousUserDashboardFeatureConfigurations();
            Amazon.QuickSight.Model.SharedViewConfigurations requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView = null;
            
             // populate SharedView
            var requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedViewIsNull = true;
            requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView = new Amazon.QuickSight.Model.SharedViewConfigurations();
            System.Boolean? requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView_sharedView_Enabled = null;
            if (cmdletContext.SharedView_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView_sharedView_Enabled = cmdletContext.SharedView_Enabled.Value;
            }
            if (requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView_sharedView_Enabled != null)
            {
                requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView.Enabled = requestExperienceConfiguration_experienceConfiguration_Dashboard_experienceConfiguration_Dashboard_FeatureConfigurations_experienceConfiguration_Dashboard_FeatureConfigurations_SharedView_sharedView_Enabled.Value;
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
                requestExperienceConfigurationIsNull = false;
            }
             // determine if request.ExperienceConfiguration should be set to null
            if (requestExperienceConfigurationIsNull)
            {
                request.ExperienceConfiguration = null;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.SessionLifetimeInMinute != null)
            {
                request.SessionLifetimeInMinutes = cmdletContext.SessionLifetimeInMinute.Value;
            }
            if (cmdletContext.SessionTag != null)
            {
                request.SessionTags = cmdletContext.SessionTag;
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
        
        private Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "GenerateEmbedUrlForAnonymousUser");
            try
            {
                return client.GenerateEmbedUrlForAnonymousUserAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AuthorizedResourceArn { get; set; }
            public System.String AwsAccountId { get; set; }
            public List<System.String> Dashboard_DisabledFeature { get; set; }
            public List<System.String> Dashboard_EnabledFeature { get; set; }
            public System.Boolean? SharedView_Enabled { get; set; }
            public System.String Dashboard_InitialDashboardId { get; set; }
            public System.String InitialDashboardVisualId_DashboardId { get; set; }
            public System.String InitialDashboardVisualId_SheetId { get; set; }
            public System.String InitialDashboardVisualId_VisualId { get; set; }
            public System.String GenerativeQnA_InitialTopicId { get; set; }
            public System.String QSearchBar_InitialTopicId { get; set; }
            public System.String Namespace { get; set; }
            public System.Int64? SessionLifetimeInMinute { get; set; }
            public List<Amazon.QuickSight.Model.SessionTag> SessionTag { get; set; }
            public System.Func<Amazon.QuickSight.Model.GenerateEmbedUrlForAnonymousUserResponse, NewQSEmbedUrlForAnonymousUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EmbedUrl;
        }
        
    }
}
