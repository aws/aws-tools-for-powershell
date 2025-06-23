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
    /// Starts an Asset Bundle export job.
    /// 
    ///  
    /// <para>
    /// An Asset Bundle export job exports specified Amazon QuickSight assets. You can also
    /// choose to export any asset dependencies in the same job. Export jobs run asynchronously
    /// and can be polled with a <c>DescribeAssetBundleExportJob</c> API call. When a job
    /// is successfully completed, a download URL that contains the exported assets is returned.
    /// The URL is valid for 5 minutes and can be refreshed with a <c>DescribeAssetBundleExportJob</c>
    /// API call. Each Amazon QuickSight account can run up to 5 export jobs concurrently.
    /// </para><para>
    /// The API caller must have the necessary permissions in their IAM role to access each
    /// resource before the resources can be exported.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "QSAssetBundleExportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.StartAssetBundleExportJobResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight StartAssetBundleExportJob API operation.", Operation = new[] {"StartAssetBundleExportJob"}, SelectReturnType = typeof(Amazon.QuickSight.Model.StartAssetBundleExportJobResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.StartAssetBundleExportJobResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.StartAssetBundleExportJobResponse object containing multiple properties."
    )]
    public partial class StartQSAssetBundleExportJobCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CloudFormationOverridePropertyConfiguration_Analyses
        /// <summary>
        /// <para>
        /// <para>An optional list of structures that control how <c>Analysis</c> resources are parameterized
        /// in the returned CloudFormation template.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QuickSight.Model.AssetBundleExportJobAnalysisOverrideProperties[] CloudFormationOverridePropertyConfiguration_Analyses { get; set; }
        #endregion
        
        #region Parameter AssetBundleExportJobId
        /// <summary>
        /// <para>
        /// <para>The ID of the job. This ID is unique while the job is running. After the job is completed,
        /// you can reuse this ID for another job.</para>
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
        public System.String AssetBundleExportJobId { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account to export assets from.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter CloudFormationOverridePropertyConfiguration_Dashboard
        /// <summary>
        /// <para>
        /// <para>An optional list of structures that control how <c>Dashboard</c> resources are parameterized
        /// in the returned CloudFormation template.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudFormationOverridePropertyConfiguration_Dashboards")]
        public Amazon.QuickSight.Model.AssetBundleExportJobDashboardOverrideProperties[] CloudFormationOverridePropertyConfiguration_Dashboard { get; set; }
        #endregion
        
        #region Parameter CloudFormationOverridePropertyConfiguration_DataSet
        /// <summary>
        /// <para>
        /// <para>An optional list of structures that control how <c>DataSet</c> resources are parameterized
        /// in the returned CloudFormation template.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudFormationOverridePropertyConfiguration_DataSets")]
        public Amazon.QuickSight.Model.AssetBundleExportJobDataSetOverrideProperties[] CloudFormationOverridePropertyConfiguration_DataSet { get; set; }
        #endregion
        
        #region Parameter CloudFormationOverridePropertyConfiguration_DataSource
        /// <summary>
        /// <para>
        /// <para>An optional list of structures that control how <c>DataSource</c> resources are parameterized
        /// in the returned CloudFormation template.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudFormationOverridePropertyConfiguration_DataSources")]
        public Amazon.QuickSight.Model.AssetBundleExportJobDataSourceOverrideProperties[] CloudFormationOverridePropertyConfiguration_DataSource { get; set; }
        #endregion
        
        #region Parameter ExportFormat
        /// <summary>
        /// <para>
        /// <para>The export data format.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.AssetBundleExportFormat")]
        public Amazon.QuickSight.AssetBundleExportFormat ExportFormat { get; set; }
        #endregion
        
        #region Parameter CloudFormationOverridePropertyConfiguration_Folder
        /// <summary>
        /// <para>
        /// <para>An optional list of structures that controls how <c>Folder</c> resources are parameterized
        /// in the returned CloudFormation template.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudFormationOverridePropertyConfiguration_Folders")]
        public Amazon.QuickSight.Model.AssetBundleExportJobFolderOverrideProperties[] CloudFormationOverridePropertyConfiguration_Folder { get; set; }
        #endregion
        
        #region Parameter IncludeAllDependency
        /// <summary>
        /// <para>
        /// <para>A Boolean that determines whether all dependencies of each resource ARN are recursively
        /// exported with the job. For example, say you provided a Dashboard ARN to the <c>ResourceArns</c>
        /// parameter. If you set <c>IncludeAllDependencies</c> to <c>TRUE</c>, any theme, dataset,
        /// and data source resource that is a dependency of the dashboard is also exported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeAllDependencies")]
        public System.Boolean? IncludeAllDependency { get; set; }
        #endregion
        
        #region Parameter IncludeFolderMember
        /// <summary>
        /// <para>
        /// <para>A setting that indicates whether you want to include folder assets. You can also use
        /// this setting to recusrsively include all subfolders of an exported folder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeFolderMembers")]
        [AWSConstantClassSource("Amazon.QuickSight.IncludeFolderMembers")]
        public Amazon.QuickSight.IncludeFolderMembers IncludeFolderMember { get; set; }
        #endregion
        
        #region Parameter IncludeFolderMembership
        /// <summary>
        /// <para>
        /// <para>A Boolean that determines if the exported asset carries over information about the
        /// folders that the asset is a member of. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeFolderMemberships")]
        public System.Boolean? IncludeFolderMembership { get; set; }
        #endregion
        
        #region Parameter IncludePermission
        /// <summary>
        /// <para>
        /// <para>A Boolean that determines whether all permissions for each resource ARN are exported
        /// with the job. If you set <c>IncludePermissions</c> to <c>TRUE</c>, any permissions
        /// associated with each resource are exported. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludePermissions")]
        public System.Boolean? IncludePermission { get; set; }
        #endregion
        
        #region Parameter IncludeTag
        /// <summary>
        /// <para>
        /// <para> A Boolean that determines whether all tags for each resource ARN are exported with
        /// the job. If you set <c>IncludeTags</c> to <c>TRUE</c>, any tags associated with each
        /// resource are exported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeTags")]
        public System.Boolean? IncludeTag { get; set; }
        #endregion
        
        #region Parameter ResourceIdOverrideConfiguration_PrefixForAllResource
        /// <summary>
        /// <para>
        /// <para>An option to request a CloudFormation variable for a prefix to be prepended to each
        /// resource's ID before import. The prefix is only added to the asset IDs and does not
        /// change the name of the asset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudFormationOverridePropertyConfiguration_ResourceIdOverrideConfiguration_PrefixForAllResources")]
        public System.Boolean? ResourceIdOverrideConfiguration_PrefixForAllResource { get; set; }
        #endregion
        
        #region Parameter CloudFormationOverridePropertyConfiguration_RefreshSchedule
        /// <summary>
        /// <para>
        /// <para>An optional list of structures that control how <c>RefreshSchedule</c> resources are
        /// parameterized in the returned CloudFormation template.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudFormationOverridePropertyConfiguration_RefreshSchedules")]
        public Amazon.QuickSight.Model.AssetBundleExportJobRefreshScheduleOverrideProperties[] CloudFormationOverridePropertyConfiguration_RefreshSchedule { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>An array of resource ARNs to export. The following resources are supported.</para><ul><li><para><c>Analysis</c></para></li><li><para><c>Dashboard</c></para></li><li><para><c>DataSet</c></para></li><li><para><c>DataSource</c></para></li><li><para><c>RefreshSchedule</c></para></li><li><para><c>Theme</c></para></li><li><para><c>VPCConnection</c></para></li></ul><para>The API caller must have the necessary permissions in their IAM role to access each
        /// resource before the resources can be exported.</para><para />
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
        [Alias("ResourceArns")]
        public System.String[] ResourceArn { get; set; }
        #endregion
        
        #region Parameter ValidationStrategy_StrictModeForAllResource
        /// <summary>
        /// <para>
        /// <para>A Boolean value that indicates whether to export resources under strict or lenient
        /// mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValidationStrategy_StrictModeForAllResources")]
        public System.Boolean? ValidationStrategy_StrictModeForAllResource { get; set; }
        #endregion
        
        #region Parameter CloudFormationOverridePropertyConfiguration_Theme
        /// <summary>
        /// <para>
        /// <para>An optional list of structures that control how <c>Theme</c> resources are parameterized
        /// in the returned CloudFormation template.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudFormationOverridePropertyConfiguration_Themes")]
        public Amazon.QuickSight.Model.AssetBundleExportJobThemeOverrideProperties[] CloudFormationOverridePropertyConfiguration_Theme { get; set; }
        #endregion
        
        #region Parameter CloudFormationOverridePropertyConfiguration_VPCConnection
        /// <summary>
        /// <para>
        /// <para>An optional list of structures that control how <c>VPCConnection</c> resources are
        /// parameterized in the returned CloudFormation template.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudFormationOverridePropertyConfiguration_VPCConnections")]
        public Amazon.QuickSight.Model.AssetBundleExportJobVPCConnectionOverrideProperties[] CloudFormationOverridePropertyConfiguration_VPCConnection { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.StartAssetBundleExportJobResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.StartAssetBundleExportJobResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-QSAssetBundleExportJob (StartAssetBundleExportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.StartAssetBundleExportJobResponse, StartQSAssetBundleExportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssetBundleExportJobId = this.AssetBundleExportJobId;
            #if MODULAR
            if (this.AssetBundleExportJobId == null && ParameterWasBound(nameof(this.AssetBundleExportJobId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetBundleExportJobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CloudFormationOverridePropertyConfiguration_Analyses != null)
            {
                context.CloudFormationOverridePropertyConfiguration_Analyses = new List<Amazon.QuickSight.Model.AssetBundleExportJobAnalysisOverrideProperties>(this.CloudFormationOverridePropertyConfiguration_Analyses);
            }
            if (this.CloudFormationOverridePropertyConfiguration_Dashboard != null)
            {
                context.CloudFormationOverridePropertyConfiguration_Dashboard = new List<Amazon.QuickSight.Model.AssetBundleExportJobDashboardOverrideProperties>(this.CloudFormationOverridePropertyConfiguration_Dashboard);
            }
            if (this.CloudFormationOverridePropertyConfiguration_DataSet != null)
            {
                context.CloudFormationOverridePropertyConfiguration_DataSet = new List<Amazon.QuickSight.Model.AssetBundleExportJobDataSetOverrideProperties>(this.CloudFormationOverridePropertyConfiguration_DataSet);
            }
            if (this.CloudFormationOverridePropertyConfiguration_DataSource != null)
            {
                context.CloudFormationOverridePropertyConfiguration_DataSource = new List<Amazon.QuickSight.Model.AssetBundleExportJobDataSourceOverrideProperties>(this.CloudFormationOverridePropertyConfiguration_DataSource);
            }
            if (this.CloudFormationOverridePropertyConfiguration_Folder != null)
            {
                context.CloudFormationOverridePropertyConfiguration_Folder = new List<Amazon.QuickSight.Model.AssetBundleExportJobFolderOverrideProperties>(this.CloudFormationOverridePropertyConfiguration_Folder);
            }
            if (this.CloudFormationOverridePropertyConfiguration_RefreshSchedule != null)
            {
                context.CloudFormationOverridePropertyConfiguration_RefreshSchedule = new List<Amazon.QuickSight.Model.AssetBundleExportJobRefreshScheduleOverrideProperties>(this.CloudFormationOverridePropertyConfiguration_RefreshSchedule);
            }
            context.ResourceIdOverrideConfiguration_PrefixForAllResource = this.ResourceIdOverrideConfiguration_PrefixForAllResource;
            if (this.CloudFormationOverridePropertyConfiguration_Theme != null)
            {
                context.CloudFormationOverridePropertyConfiguration_Theme = new List<Amazon.QuickSight.Model.AssetBundleExportJobThemeOverrideProperties>(this.CloudFormationOverridePropertyConfiguration_Theme);
            }
            if (this.CloudFormationOverridePropertyConfiguration_VPCConnection != null)
            {
                context.CloudFormationOverridePropertyConfiguration_VPCConnection = new List<Amazon.QuickSight.Model.AssetBundleExportJobVPCConnectionOverrideProperties>(this.CloudFormationOverridePropertyConfiguration_VPCConnection);
            }
            context.ExportFormat = this.ExportFormat;
            #if MODULAR
            if (this.ExportFormat == null && ParameterWasBound(nameof(this.ExportFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IncludeAllDependency = this.IncludeAllDependency;
            context.IncludeFolderMember = this.IncludeFolderMember;
            context.IncludeFolderMembership = this.IncludeFolderMembership;
            context.IncludePermission = this.IncludePermission;
            context.IncludeTag = this.IncludeTag;
            if (this.ResourceArn != null)
            {
                context.ResourceArn = new List<System.String>(this.ResourceArn);
            }
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ValidationStrategy_StrictModeForAllResource = this.ValidationStrategy_StrictModeForAllResource;
            
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
            var request = new Amazon.QuickSight.Model.StartAssetBundleExportJobRequest();
            
            if (cmdletContext.AssetBundleExportJobId != null)
            {
                request.AssetBundleExportJobId = cmdletContext.AssetBundleExportJobId;
            }
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            
             // populate CloudFormationOverridePropertyConfiguration
            var requestCloudFormationOverridePropertyConfigurationIsNull = true;
            request.CloudFormationOverridePropertyConfiguration = new Amazon.QuickSight.Model.AssetBundleCloudFormationOverridePropertyConfiguration();
            List<Amazon.QuickSight.Model.AssetBundleExportJobAnalysisOverrideProperties> requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Analyses = null;
            if (cmdletContext.CloudFormationOverridePropertyConfiguration_Analyses != null)
            {
                requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Analyses = cmdletContext.CloudFormationOverridePropertyConfiguration_Analyses;
            }
            if (requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Analyses != null)
            {
                request.CloudFormationOverridePropertyConfiguration.Analyses = requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Analyses;
                requestCloudFormationOverridePropertyConfigurationIsNull = false;
            }
            List<Amazon.QuickSight.Model.AssetBundleExportJobDashboardOverrideProperties> requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Dashboard = null;
            if (cmdletContext.CloudFormationOverridePropertyConfiguration_Dashboard != null)
            {
                requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Dashboard = cmdletContext.CloudFormationOverridePropertyConfiguration_Dashboard;
            }
            if (requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Dashboard != null)
            {
                request.CloudFormationOverridePropertyConfiguration.Dashboards = requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Dashboard;
                requestCloudFormationOverridePropertyConfigurationIsNull = false;
            }
            List<Amazon.QuickSight.Model.AssetBundleExportJobDataSetOverrideProperties> requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_DataSet = null;
            if (cmdletContext.CloudFormationOverridePropertyConfiguration_DataSet != null)
            {
                requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_DataSet = cmdletContext.CloudFormationOverridePropertyConfiguration_DataSet;
            }
            if (requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_DataSet != null)
            {
                request.CloudFormationOverridePropertyConfiguration.DataSets = requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_DataSet;
                requestCloudFormationOverridePropertyConfigurationIsNull = false;
            }
            List<Amazon.QuickSight.Model.AssetBundleExportJobDataSourceOverrideProperties> requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_DataSource = null;
            if (cmdletContext.CloudFormationOverridePropertyConfiguration_DataSource != null)
            {
                requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_DataSource = cmdletContext.CloudFormationOverridePropertyConfiguration_DataSource;
            }
            if (requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_DataSource != null)
            {
                request.CloudFormationOverridePropertyConfiguration.DataSources = requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_DataSource;
                requestCloudFormationOverridePropertyConfigurationIsNull = false;
            }
            List<Amazon.QuickSight.Model.AssetBundleExportJobFolderOverrideProperties> requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Folder = null;
            if (cmdletContext.CloudFormationOverridePropertyConfiguration_Folder != null)
            {
                requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Folder = cmdletContext.CloudFormationOverridePropertyConfiguration_Folder;
            }
            if (requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Folder != null)
            {
                request.CloudFormationOverridePropertyConfiguration.Folders = requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Folder;
                requestCloudFormationOverridePropertyConfigurationIsNull = false;
            }
            List<Amazon.QuickSight.Model.AssetBundleExportJobRefreshScheduleOverrideProperties> requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_RefreshSchedule = null;
            if (cmdletContext.CloudFormationOverridePropertyConfiguration_RefreshSchedule != null)
            {
                requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_RefreshSchedule = cmdletContext.CloudFormationOverridePropertyConfiguration_RefreshSchedule;
            }
            if (requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_RefreshSchedule != null)
            {
                request.CloudFormationOverridePropertyConfiguration.RefreshSchedules = requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_RefreshSchedule;
                requestCloudFormationOverridePropertyConfigurationIsNull = false;
            }
            List<Amazon.QuickSight.Model.AssetBundleExportJobThemeOverrideProperties> requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Theme = null;
            if (cmdletContext.CloudFormationOverridePropertyConfiguration_Theme != null)
            {
                requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Theme = cmdletContext.CloudFormationOverridePropertyConfiguration_Theme;
            }
            if (requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Theme != null)
            {
                request.CloudFormationOverridePropertyConfiguration.Themes = requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_Theme;
                requestCloudFormationOverridePropertyConfigurationIsNull = false;
            }
            List<Amazon.QuickSight.Model.AssetBundleExportJobVPCConnectionOverrideProperties> requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_VPCConnection = null;
            if (cmdletContext.CloudFormationOverridePropertyConfiguration_VPCConnection != null)
            {
                requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_VPCConnection = cmdletContext.CloudFormationOverridePropertyConfiguration_VPCConnection;
            }
            if (requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_VPCConnection != null)
            {
                request.CloudFormationOverridePropertyConfiguration.VPCConnections = requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_VPCConnection;
                requestCloudFormationOverridePropertyConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.AssetBundleExportJobResourceIdOverrideConfiguration requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_ResourceIdOverrideConfiguration = null;
            
             // populate ResourceIdOverrideConfiguration
            var requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_ResourceIdOverrideConfigurationIsNull = true;
            requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_ResourceIdOverrideConfiguration = new Amazon.QuickSight.Model.AssetBundleExportJobResourceIdOverrideConfiguration();
            System.Boolean? requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_ResourceIdOverrideConfiguration_resourceIdOverrideConfiguration_PrefixForAllResource = null;
            if (cmdletContext.ResourceIdOverrideConfiguration_PrefixForAllResource != null)
            {
                requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_ResourceIdOverrideConfiguration_resourceIdOverrideConfiguration_PrefixForAllResource = cmdletContext.ResourceIdOverrideConfiguration_PrefixForAllResource.Value;
            }
            if (requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_ResourceIdOverrideConfiguration_resourceIdOverrideConfiguration_PrefixForAllResource != null)
            {
                requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_ResourceIdOverrideConfiguration.PrefixForAllResources = requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_ResourceIdOverrideConfiguration_resourceIdOverrideConfiguration_PrefixForAllResource.Value;
                requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_ResourceIdOverrideConfigurationIsNull = false;
            }
             // determine if requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_ResourceIdOverrideConfiguration should be set to null
            if (requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_ResourceIdOverrideConfigurationIsNull)
            {
                requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_ResourceIdOverrideConfiguration = null;
            }
            if (requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_ResourceIdOverrideConfiguration != null)
            {
                request.CloudFormationOverridePropertyConfiguration.ResourceIdOverrideConfiguration = requestCloudFormationOverridePropertyConfiguration_cloudFormationOverridePropertyConfiguration_ResourceIdOverrideConfiguration;
                requestCloudFormationOverridePropertyConfigurationIsNull = false;
            }
             // determine if request.CloudFormationOverridePropertyConfiguration should be set to null
            if (requestCloudFormationOverridePropertyConfigurationIsNull)
            {
                request.CloudFormationOverridePropertyConfiguration = null;
            }
            if (cmdletContext.ExportFormat != null)
            {
                request.ExportFormat = cmdletContext.ExportFormat;
            }
            if (cmdletContext.IncludeAllDependency != null)
            {
                request.IncludeAllDependencies = cmdletContext.IncludeAllDependency.Value;
            }
            if (cmdletContext.IncludeFolderMember != null)
            {
                request.IncludeFolderMembers = cmdletContext.IncludeFolderMember;
            }
            if (cmdletContext.IncludeFolderMembership != null)
            {
                request.IncludeFolderMemberships = cmdletContext.IncludeFolderMembership.Value;
            }
            if (cmdletContext.IncludePermission != null)
            {
                request.IncludePermissions = cmdletContext.IncludePermission.Value;
            }
            if (cmdletContext.IncludeTag != null)
            {
                request.IncludeTags = cmdletContext.IncludeTag.Value;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArns = cmdletContext.ResourceArn;
            }
            
             // populate ValidationStrategy
            var requestValidationStrategyIsNull = true;
            request.ValidationStrategy = new Amazon.QuickSight.Model.AssetBundleExportJobValidationStrategy();
            System.Boolean? requestValidationStrategy_validationStrategy_StrictModeForAllResource = null;
            if (cmdletContext.ValidationStrategy_StrictModeForAllResource != null)
            {
                requestValidationStrategy_validationStrategy_StrictModeForAllResource = cmdletContext.ValidationStrategy_StrictModeForAllResource.Value;
            }
            if (requestValidationStrategy_validationStrategy_StrictModeForAllResource != null)
            {
                request.ValidationStrategy.StrictModeForAllResources = requestValidationStrategy_validationStrategy_StrictModeForAllResource.Value;
                requestValidationStrategyIsNull = false;
            }
             // determine if request.ValidationStrategy should be set to null
            if (requestValidationStrategyIsNull)
            {
                request.ValidationStrategy = null;
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
        
        private Amazon.QuickSight.Model.StartAssetBundleExportJobResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.StartAssetBundleExportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "StartAssetBundleExportJob");
            try
            {
                return client.StartAssetBundleExportJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssetBundleExportJobId { get; set; }
            public System.String AwsAccountId { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleExportJobAnalysisOverrideProperties> CloudFormationOverridePropertyConfiguration_Analyses { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleExportJobDashboardOverrideProperties> CloudFormationOverridePropertyConfiguration_Dashboard { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleExportJobDataSetOverrideProperties> CloudFormationOverridePropertyConfiguration_DataSet { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleExportJobDataSourceOverrideProperties> CloudFormationOverridePropertyConfiguration_DataSource { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleExportJobFolderOverrideProperties> CloudFormationOverridePropertyConfiguration_Folder { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleExportJobRefreshScheduleOverrideProperties> CloudFormationOverridePropertyConfiguration_RefreshSchedule { get; set; }
            public System.Boolean? ResourceIdOverrideConfiguration_PrefixForAllResource { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleExportJobThemeOverrideProperties> CloudFormationOverridePropertyConfiguration_Theme { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleExportJobVPCConnectionOverrideProperties> CloudFormationOverridePropertyConfiguration_VPCConnection { get; set; }
            public Amazon.QuickSight.AssetBundleExportFormat ExportFormat { get; set; }
            public System.Boolean? IncludeAllDependency { get; set; }
            public Amazon.QuickSight.IncludeFolderMembers IncludeFolderMember { get; set; }
            public System.Boolean? IncludeFolderMembership { get; set; }
            public System.Boolean? IncludePermission { get; set; }
            public System.Boolean? IncludeTag { get; set; }
            public List<System.String> ResourceArn { get; set; }
            public System.Boolean? ValidationStrategy_StrictModeForAllResource { get; set; }
            public System.Func<Amazon.QuickSight.Model.StartAssetBundleExportJobResponse, StartQSAssetBundleExportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
