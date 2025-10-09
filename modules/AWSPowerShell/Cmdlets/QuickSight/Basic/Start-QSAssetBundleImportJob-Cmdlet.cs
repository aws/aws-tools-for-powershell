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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Starts an Asset Bundle import job.
    /// 
    ///  
    /// <para>
    /// An Asset Bundle import job imports specified Amazon Quick Sight assets into an Amazon
    /// Quick Sight account. You can also choose to import a naming prefix and specified configuration
    /// overrides. The assets that are contained in the bundle file that you provide are used
    /// to create or update a new or existing asset in your Amazon Quick Sight account. Each
    /// Amazon Quick Sight account can run up to 5 import jobs concurrently.
    /// </para><para>
    /// The API caller must have the necessary <c>"create"</c>, <c>"describe"</c>, and <c>"update"</c>
    /// permissions in their IAM role to access each resource type that is contained in the
    /// bundle file before the resources can be imported.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "QSAssetBundleImportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.StartAssetBundleImportJobResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight StartAssetBundleImportJob API operation.", Operation = new[] {"StartAssetBundleImportJob"}, SelectReturnType = typeof(Amazon.QuickSight.Model.StartAssetBundleImportJobResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.StartAssetBundleImportJobResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.StartAssetBundleImportJobResponse object containing multiple properties."
    )]
    public partial class StartQSAssetBundleImportJobCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OverrideParameters_Analyses
        /// <summary>
        /// <para>
        /// <para>A list of overrides for any <c>Analysis</c> resources that are present in the asset
        /// bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QuickSight.Model.AssetBundleImportJobAnalysisOverrideParameters[] OverrideParameters_Analyses { get; set; }
        #endregion
        
        #region Parameter OverridePermissions_Analyses
        /// <summary>
        /// <para>
        /// <para>A list of permissions overrides for any <c>Analysis</c> resources that are present
        /// in the asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QuickSight.Model.AssetBundleImportJobAnalysisOverridePermissions[] OverridePermissions_Analyses { get; set; }
        #endregion
        
        #region Parameter OverrideTags_Analyses
        /// <summary>
        /// <para>
        /// <para>A list of tag overrides for any <c>Analysis</c> resources that are present in the
        /// asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QuickSight.Model.AssetBundleImportJobAnalysisOverrideTags[] OverrideTags_Analyses { get; set; }
        #endregion
        
        #region Parameter AssetBundleImportJobId
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
        public System.String AssetBundleImportJobId { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account to import assets into. </para>
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
        
        #region Parameter AssetBundleImportSource_Body
        /// <summary>
        /// <para>
        /// <para>The bytes of the base64 encoded asset bundle import zip file. This file can't exceed
        /// 20 MB. If the size of the file that you want to upload is more than 20 MB, add the
        /// file to your Amazon S3 bucket and use <c>S3Uri</c> of the file for this operation.</para><para>If you are calling the API operations from the Amazon Web Services SDK for Java, JavaScript,
        /// Python, or PHP, the SDK encodes base64 automatically to allow the direct setting of
        /// the zip file's bytes. If you are using an SDK for a different language or receiving
        /// related errors, try to base64 encode your data.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] AssetBundleImportSource_Body { get; set; }
        #endregion
        
        #region Parameter OverrideParameters_Dashboard
        /// <summary>
        /// <para>
        /// <para>A list of overrides for any <c>Dashboard</c> resources that are present in the asset
        /// bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideParameters_Dashboards")]
        public Amazon.QuickSight.Model.AssetBundleImportJobDashboardOverrideParameters[] OverrideParameters_Dashboard { get; set; }
        #endregion
        
        #region Parameter OverridePermissions_Dashboard
        /// <summary>
        /// <para>
        /// <para>A list of permissions overrides for any <c>Dashboard</c> resources that are present
        /// in the asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverridePermissions_Dashboards")]
        public Amazon.QuickSight.Model.AssetBundleImportJobDashboardOverridePermissions[] OverridePermissions_Dashboard { get; set; }
        #endregion
        
        #region Parameter OverrideTags_Dashboard
        /// <summary>
        /// <para>
        /// <para>A list of tag overrides for any <c>Dashboard</c> resources that are present in the
        /// asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideTags_Dashboards")]
        public Amazon.QuickSight.Model.AssetBundleImportJobDashboardOverrideTags[] OverrideTags_Dashboard { get; set; }
        #endregion
        
        #region Parameter OverrideParameters_DataSet
        /// <summary>
        /// <para>
        /// <para>A list of overrides for any <c>DataSet</c> resources that are present in the asset
        /// bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideParameters_DataSets")]
        public Amazon.QuickSight.Model.AssetBundleImportJobDataSetOverrideParameters[] OverrideParameters_DataSet { get; set; }
        #endregion
        
        #region Parameter OverridePermissions_DataSet
        /// <summary>
        /// <para>
        /// <para>A list of permissions overrides for any <c>DataSet</c> resources that are present
        /// in the asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverridePermissions_DataSets")]
        public Amazon.QuickSight.Model.AssetBundleImportJobDataSetOverridePermissions[] OverridePermissions_DataSet { get; set; }
        #endregion
        
        #region Parameter OverrideTags_DataSet
        /// <summary>
        /// <para>
        /// <para>A list of tag overrides for any <c>DataSet</c> resources that are present in the asset
        /// bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideTags_DataSets")]
        public Amazon.QuickSight.Model.AssetBundleImportJobDataSetOverrideTags[] OverrideTags_DataSet { get; set; }
        #endregion
        
        #region Parameter OverrideParameters_DataSource
        /// <summary>
        /// <para>
        /// <para> A list of overrides for any <c>DataSource</c> resources that are present in the asset
        /// bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideParameters_DataSources")]
        public Amazon.QuickSight.Model.AssetBundleImportJobDataSourceOverrideParameters[] OverrideParameters_DataSource { get; set; }
        #endregion
        
        #region Parameter OverridePermissions_DataSource
        /// <summary>
        /// <para>
        /// <para>A list of permissions overrides for any <c>DataSource</c> resources that are present
        /// in the asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverridePermissions_DataSources")]
        public Amazon.QuickSight.Model.AssetBundleImportJobDataSourceOverridePermissions[] OverridePermissions_DataSource { get; set; }
        #endregion
        
        #region Parameter OverrideTags_DataSource
        /// <summary>
        /// <para>
        /// <para>A list of tag overrides for any <c>DataSource</c> resources that are present in the
        /// asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideTags_DataSources")]
        public Amazon.QuickSight.Model.AssetBundleImportJobDataSourceOverrideTags[] OverrideTags_DataSource { get; set; }
        #endregion
        
        #region Parameter FailureAction
        /// <summary>
        /// <para>
        /// <para>The failure action for the import job.</para><para>If you choose <c>ROLLBACK</c>, failed import jobs will attempt to undo any asset changes
        /// caused by the failed job.</para><para>If you choose <c>DO_NOTHING</c>, failed import jobs will not attempt to roll back
        /// any asset changes caused by the failed job, possibly keeping the Amazon Quick Sight
        /// account in an inconsistent state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.AssetBundleImportFailureAction")]
        public Amazon.QuickSight.AssetBundleImportFailureAction FailureAction { get; set; }
        #endregion
        
        #region Parameter OverrideParameters_Folder
        /// <summary>
        /// <para>
        /// <para>A list of overrides for any <c>Folder</c> resources that are present in the asset
        /// bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideParameters_Folders")]
        public Amazon.QuickSight.Model.AssetBundleImportJobFolderOverrideParameters[] OverrideParameters_Folder { get; set; }
        #endregion
        
        #region Parameter OverridePermissions_Folder
        /// <summary>
        /// <para>
        /// <para>A list of permissions for the folders that you want to apply overrides to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverridePermissions_Folders")]
        public Amazon.QuickSight.Model.AssetBundleImportJobFolderOverridePermissions[] OverridePermissions_Folder { get; set; }
        #endregion
        
        #region Parameter OverrideTags_Folder
        /// <summary>
        /// <para>
        /// <para>A list of tag overrides for any <c>Folder</c> resources that are present in the asset
        /// bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideTags_Folders")]
        public Amazon.QuickSight.Model.AssetBundleImportJobFolderOverrideTags[] OverrideTags_Folder { get; set; }
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
        [Alias("OverrideParameters_ResourceIdOverrideConfiguration_PrefixForAllResources")]
        public System.String ResourceIdOverrideConfiguration_PrefixForAllResource { get; set; }
        #endregion
        
        #region Parameter OverrideParameters_RefreshSchedule
        /// <summary>
        /// <para>
        /// <para>A list of overrides for any <c>RefreshSchedule</c> resources that are present in the
        /// asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideParameters_RefreshSchedules")]
        public Amazon.QuickSight.Model.AssetBundleImportJobRefreshScheduleOverrideParameters[] OverrideParameters_RefreshSchedule { get; set; }
        #endregion
        
        #region Parameter AssetBundleImportSource_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI for an asset bundle import file that exists in an Amazon S3 bucket
        /// that the caller has read access to. The file must be a zip format file and can't exceed
        /// 1 GB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssetBundleImportSource_S3Uri { get; set; }
        #endregion
        
        #region Parameter OverrideValidationStrategy_StrictModeForAllResource
        /// <summary>
        /// <para>
        /// <para>A Boolean value that indicates whether to import all analyses and dashboards under
        /// strict or lenient mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideValidationStrategy_StrictModeForAllResources")]
        public System.Boolean? OverrideValidationStrategy_StrictModeForAllResource { get; set; }
        #endregion
        
        #region Parameter OverrideParameters_Theme
        /// <summary>
        /// <para>
        /// <para>A list of overrides for any <c>Theme</c> resources that are present in the asset bundle
        /// that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideParameters_Themes")]
        public Amazon.QuickSight.Model.AssetBundleImportJobThemeOverrideParameters[] OverrideParameters_Theme { get; set; }
        #endregion
        
        #region Parameter OverridePermissions_Theme
        /// <summary>
        /// <para>
        /// <para>A list of permissions overrides for any <c>Theme</c> resources that are present in
        /// the asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverridePermissions_Themes")]
        public Amazon.QuickSight.Model.AssetBundleImportJobThemeOverridePermissions[] OverridePermissions_Theme { get; set; }
        #endregion
        
        #region Parameter OverrideTags_Theme
        /// <summary>
        /// <para>
        /// <para>A list of tag overrides for any <c>Theme</c> resources that are present in the asset
        /// bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideTags_Themes")]
        public Amazon.QuickSight.Model.AssetBundleImportJobThemeOverrideTags[] OverrideTags_Theme { get; set; }
        #endregion
        
        #region Parameter OverrideParameters_VPCConnection
        /// <summary>
        /// <para>
        /// <para>A list of overrides for any <c>VPCConnection</c> resources that are present in the
        /// asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideParameters_VPCConnections")]
        public Amazon.QuickSight.Model.AssetBundleImportJobVPCConnectionOverrideParameters[] OverrideParameters_VPCConnection { get; set; }
        #endregion
        
        #region Parameter OverrideTags_VPCConnection
        /// <summary>
        /// <para>
        /// <para>A list of tag overrides for any <c>VPCConnection</c> resources that are present in
        /// the asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideTags_VPCConnections")]
        public Amazon.QuickSight.Model.AssetBundleImportJobVPCConnectionOverrideTags[] OverrideTags_VPCConnection { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.StartAssetBundleImportJobResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.StartAssetBundleImportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AssetBundleImportJobId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AssetBundleImportJobId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AssetBundleImportJobId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-QSAssetBundleImportJob (StartAssetBundleImportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.StartAssetBundleImportJobResponse, StartQSAssetBundleImportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AssetBundleImportJobId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssetBundleImportJobId = this.AssetBundleImportJobId;
            #if MODULAR
            if (this.AssetBundleImportJobId == null && ParameterWasBound(nameof(this.AssetBundleImportJobId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetBundleImportJobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssetBundleImportSource_Body = this.AssetBundleImportSource_Body;
            context.AssetBundleImportSource_S3Uri = this.AssetBundleImportSource_S3Uri;
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FailureAction = this.FailureAction;
            if (this.OverrideParameters_Analyses != null)
            {
                context.OverrideParameters_Analyses = new List<Amazon.QuickSight.Model.AssetBundleImportJobAnalysisOverrideParameters>(this.OverrideParameters_Analyses);
            }
            if (this.OverrideParameters_Dashboard != null)
            {
                context.OverrideParameters_Dashboard = new List<Amazon.QuickSight.Model.AssetBundleImportJobDashboardOverrideParameters>(this.OverrideParameters_Dashboard);
            }
            if (this.OverrideParameters_DataSet != null)
            {
                context.OverrideParameters_DataSet = new List<Amazon.QuickSight.Model.AssetBundleImportJobDataSetOverrideParameters>(this.OverrideParameters_DataSet);
            }
            if (this.OverrideParameters_DataSource != null)
            {
                context.OverrideParameters_DataSource = new List<Amazon.QuickSight.Model.AssetBundleImportJobDataSourceOverrideParameters>(this.OverrideParameters_DataSource);
            }
            if (this.OverrideParameters_Folder != null)
            {
                context.OverrideParameters_Folder = new List<Amazon.QuickSight.Model.AssetBundleImportJobFolderOverrideParameters>(this.OverrideParameters_Folder);
            }
            if (this.OverrideParameters_RefreshSchedule != null)
            {
                context.OverrideParameters_RefreshSchedule = new List<Amazon.QuickSight.Model.AssetBundleImportJobRefreshScheduleOverrideParameters>(this.OverrideParameters_RefreshSchedule);
            }
            context.ResourceIdOverrideConfiguration_PrefixForAllResource = this.ResourceIdOverrideConfiguration_PrefixForAllResource;
            if (this.OverrideParameters_Theme != null)
            {
                context.OverrideParameters_Theme = new List<Amazon.QuickSight.Model.AssetBundleImportJobThemeOverrideParameters>(this.OverrideParameters_Theme);
            }
            if (this.OverrideParameters_VPCConnection != null)
            {
                context.OverrideParameters_VPCConnection = new List<Amazon.QuickSight.Model.AssetBundleImportJobVPCConnectionOverrideParameters>(this.OverrideParameters_VPCConnection);
            }
            if (this.OverridePermissions_Analyses != null)
            {
                context.OverridePermissions_Analyses = new List<Amazon.QuickSight.Model.AssetBundleImportJobAnalysisOverridePermissions>(this.OverridePermissions_Analyses);
            }
            if (this.OverridePermissions_Dashboard != null)
            {
                context.OverridePermissions_Dashboard = new List<Amazon.QuickSight.Model.AssetBundleImportJobDashboardOverridePermissions>(this.OverridePermissions_Dashboard);
            }
            if (this.OverridePermissions_DataSet != null)
            {
                context.OverridePermissions_DataSet = new List<Amazon.QuickSight.Model.AssetBundleImportJobDataSetOverridePermissions>(this.OverridePermissions_DataSet);
            }
            if (this.OverridePermissions_DataSource != null)
            {
                context.OverridePermissions_DataSource = new List<Amazon.QuickSight.Model.AssetBundleImportJobDataSourceOverridePermissions>(this.OverridePermissions_DataSource);
            }
            if (this.OverridePermissions_Folder != null)
            {
                context.OverridePermissions_Folder = new List<Amazon.QuickSight.Model.AssetBundleImportJobFolderOverridePermissions>(this.OverridePermissions_Folder);
            }
            if (this.OverridePermissions_Theme != null)
            {
                context.OverridePermissions_Theme = new List<Amazon.QuickSight.Model.AssetBundleImportJobThemeOverridePermissions>(this.OverridePermissions_Theme);
            }
            if (this.OverrideTags_Analyses != null)
            {
                context.OverrideTags_Analyses = new List<Amazon.QuickSight.Model.AssetBundleImportJobAnalysisOverrideTags>(this.OverrideTags_Analyses);
            }
            if (this.OverrideTags_Dashboard != null)
            {
                context.OverrideTags_Dashboard = new List<Amazon.QuickSight.Model.AssetBundleImportJobDashboardOverrideTags>(this.OverrideTags_Dashboard);
            }
            if (this.OverrideTags_DataSet != null)
            {
                context.OverrideTags_DataSet = new List<Amazon.QuickSight.Model.AssetBundleImportJobDataSetOverrideTags>(this.OverrideTags_DataSet);
            }
            if (this.OverrideTags_DataSource != null)
            {
                context.OverrideTags_DataSource = new List<Amazon.QuickSight.Model.AssetBundleImportJobDataSourceOverrideTags>(this.OverrideTags_DataSource);
            }
            if (this.OverrideTags_Folder != null)
            {
                context.OverrideTags_Folder = new List<Amazon.QuickSight.Model.AssetBundleImportJobFolderOverrideTags>(this.OverrideTags_Folder);
            }
            if (this.OverrideTags_Theme != null)
            {
                context.OverrideTags_Theme = new List<Amazon.QuickSight.Model.AssetBundleImportJobThemeOverrideTags>(this.OverrideTags_Theme);
            }
            if (this.OverrideTags_VPCConnection != null)
            {
                context.OverrideTags_VPCConnection = new List<Amazon.QuickSight.Model.AssetBundleImportJobVPCConnectionOverrideTags>(this.OverrideTags_VPCConnection);
            }
            context.OverrideValidationStrategy_StrictModeForAllResource = this.OverrideValidationStrategy_StrictModeForAllResource;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _AssetBundleImportSource_BodyStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.QuickSight.Model.StartAssetBundleImportJobRequest();
                
                if (cmdletContext.AssetBundleImportJobId != null)
                {
                    request.AssetBundleImportJobId = cmdletContext.AssetBundleImportJobId;
                }
                
                 // populate AssetBundleImportSource
                var requestAssetBundleImportSourceIsNull = true;
                request.AssetBundleImportSource = new Amazon.QuickSight.Model.AssetBundleImportSource();
                System.IO.MemoryStream requestAssetBundleImportSource_assetBundleImportSource_Body = null;
                if (cmdletContext.AssetBundleImportSource_Body != null)
                {
                    _AssetBundleImportSource_BodyStream = new System.IO.MemoryStream(cmdletContext.AssetBundleImportSource_Body);
                    requestAssetBundleImportSource_assetBundleImportSource_Body = _AssetBundleImportSource_BodyStream;
                }
                if (requestAssetBundleImportSource_assetBundleImportSource_Body != null)
                {
                    request.AssetBundleImportSource.Body = requestAssetBundleImportSource_assetBundleImportSource_Body;
                    requestAssetBundleImportSourceIsNull = false;
                }
                System.String requestAssetBundleImportSource_assetBundleImportSource_S3Uri = null;
                if (cmdletContext.AssetBundleImportSource_S3Uri != null)
                {
                    requestAssetBundleImportSource_assetBundleImportSource_S3Uri = cmdletContext.AssetBundleImportSource_S3Uri;
                }
                if (requestAssetBundleImportSource_assetBundleImportSource_S3Uri != null)
                {
                    request.AssetBundleImportSource.S3Uri = requestAssetBundleImportSource_assetBundleImportSource_S3Uri;
                    requestAssetBundleImportSourceIsNull = false;
                }
                 // determine if request.AssetBundleImportSource should be set to null
                if (requestAssetBundleImportSourceIsNull)
                {
                    request.AssetBundleImportSource = null;
                }
                if (cmdletContext.AwsAccountId != null)
                {
                    request.AwsAccountId = cmdletContext.AwsAccountId;
                }
                if (cmdletContext.FailureAction != null)
                {
                    request.FailureAction = cmdletContext.FailureAction;
                }
                
                 // populate OverrideParameters
                var requestOverrideParametersIsNull = true;
                request.OverrideParameters = new Amazon.QuickSight.Model.AssetBundleImportJobOverrideParameters();
                List<Amazon.QuickSight.Model.AssetBundleImportJobAnalysisOverrideParameters> requestOverrideParameters_overrideParameters_Analyses = null;
                if (cmdletContext.OverrideParameters_Analyses != null)
                {
                    requestOverrideParameters_overrideParameters_Analyses = cmdletContext.OverrideParameters_Analyses;
                }
                if (requestOverrideParameters_overrideParameters_Analyses != null)
                {
                    request.OverrideParameters.Analyses = requestOverrideParameters_overrideParameters_Analyses;
                    requestOverrideParametersIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobDashboardOverrideParameters> requestOverrideParameters_overrideParameters_Dashboard = null;
                if (cmdletContext.OverrideParameters_Dashboard != null)
                {
                    requestOverrideParameters_overrideParameters_Dashboard = cmdletContext.OverrideParameters_Dashboard;
                }
                if (requestOverrideParameters_overrideParameters_Dashboard != null)
                {
                    request.OverrideParameters.Dashboards = requestOverrideParameters_overrideParameters_Dashboard;
                    requestOverrideParametersIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobDataSetOverrideParameters> requestOverrideParameters_overrideParameters_DataSet = null;
                if (cmdletContext.OverrideParameters_DataSet != null)
                {
                    requestOverrideParameters_overrideParameters_DataSet = cmdletContext.OverrideParameters_DataSet;
                }
                if (requestOverrideParameters_overrideParameters_DataSet != null)
                {
                    request.OverrideParameters.DataSets = requestOverrideParameters_overrideParameters_DataSet;
                    requestOverrideParametersIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobDataSourceOverrideParameters> requestOverrideParameters_overrideParameters_DataSource = null;
                if (cmdletContext.OverrideParameters_DataSource != null)
                {
                    requestOverrideParameters_overrideParameters_DataSource = cmdletContext.OverrideParameters_DataSource;
                }
                if (requestOverrideParameters_overrideParameters_DataSource != null)
                {
                    request.OverrideParameters.DataSources = requestOverrideParameters_overrideParameters_DataSource;
                    requestOverrideParametersIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobFolderOverrideParameters> requestOverrideParameters_overrideParameters_Folder = null;
                if (cmdletContext.OverrideParameters_Folder != null)
                {
                    requestOverrideParameters_overrideParameters_Folder = cmdletContext.OverrideParameters_Folder;
                }
                if (requestOverrideParameters_overrideParameters_Folder != null)
                {
                    request.OverrideParameters.Folders = requestOverrideParameters_overrideParameters_Folder;
                    requestOverrideParametersIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobRefreshScheduleOverrideParameters> requestOverrideParameters_overrideParameters_RefreshSchedule = null;
                if (cmdletContext.OverrideParameters_RefreshSchedule != null)
                {
                    requestOverrideParameters_overrideParameters_RefreshSchedule = cmdletContext.OverrideParameters_RefreshSchedule;
                }
                if (requestOverrideParameters_overrideParameters_RefreshSchedule != null)
                {
                    request.OverrideParameters.RefreshSchedules = requestOverrideParameters_overrideParameters_RefreshSchedule;
                    requestOverrideParametersIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobThemeOverrideParameters> requestOverrideParameters_overrideParameters_Theme = null;
                if (cmdletContext.OverrideParameters_Theme != null)
                {
                    requestOverrideParameters_overrideParameters_Theme = cmdletContext.OverrideParameters_Theme;
                }
                if (requestOverrideParameters_overrideParameters_Theme != null)
                {
                    request.OverrideParameters.Themes = requestOverrideParameters_overrideParameters_Theme;
                    requestOverrideParametersIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobVPCConnectionOverrideParameters> requestOverrideParameters_overrideParameters_VPCConnection = null;
                if (cmdletContext.OverrideParameters_VPCConnection != null)
                {
                    requestOverrideParameters_overrideParameters_VPCConnection = cmdletContext.OverrideParameters_VPCConnection;
                }
                if (requestOverrideParameters_overrideParameters_VPCConnection != null)
                {
                    request.OverrideParameters.VPCConnections = requestOverrideParameters_overrideParameters_VPCConnection;
                    requestOverrideParametersIsNull = false;
                }
                Amazon.QuickSight.Model.AssetBundleImportJobResourceIdOverrideConfiguration requestOverrideParameters_overrideParameters_ResourceIdOverrideConfiguration = null;
                
                 // populate ResourceIdOverrideConfiguration
                var requestOverrideParameters_overrideParameters_ResourceIdOverrideConfigurationIsNull = true;
                requestOverrideParameters_overrideParameters_ResourceIdOverrideConfiguration = new Amazon.QuickSight.Model.AssetBundleImportJobResourceIdOverrideConfiguration();
                System.String requestOverrideParameters_overrideParameters_ResourceIdOverrideConfiguration_resourceIdOverrideConfiguration_PrefixForAllResource = null;
                if (cmdletContext.ResourceIdOverrideConfiguration_PrefixForAllResource != null)
                {
                    requestOverrideParameters_overrideParameters_ResourceIdOverrideConfiguration_resourceIdOverrideConfiguration_PrefixForAllResource = cmdletContext.ResourceIdOverrideConfiguration_PrefixForAllResource;
                }
                if (requestOverrideParameters_overrideParameters_ResourceIdOverrideConfiguration_resourceIdOverrideConfiguration_PrefixForAllResource != null)
                {
                    requestOverrideParameters_overrideParameters_ResourceIdOverrideConfiguration.PrefixForAllResources = requestOverrideParameters_overrideParameters_ResourceIdOverrideConfiguration_resourceIdOverrideConfiguration_PrefixForAllResource;
                    requestOverrideParameters_overrideParameters_ResourceIdOverrideConfigurationIsNull = false;
                }
                 // determine if requestOverrideParameters_overrideParameters_ResourceIdOverrideConfiguration should be set to null
                if (requestOverrideParameters_overrideParameters_ResourceIdOverrideConfigurationIsNull)
                {
                    requestOverrideParameters_overrideParameters_ResourceIdOverrideConfiguration = null;
                }
                if (requestOverrideParameters_overrideParameters_ResourceIdOverrideConfiguration != null)
                {
                    request.OverrideParameters.ResourceIdOverrideConfiguration = requestOverrideParameters_overrideParameters_ResourceIdOverrideConfiguration;
                    requestOverrideParametersIsNull = false;
                }
                 // determine if request.OverrideParameters should be set to null
                if (requestOverrideParametersIsNull)
                {
                    request.OverrideParameters = null;
                }
                
                 // populate OverridePermissions
                var requestOverridePermissionsIsNull = true;
                request.OverridePermissions = new Amazon.QuickSight.Model.AssetBundleImportJobOverridePermissions();
                List<Amazon.QuickSight.Model.AssetBundleImportJobAnalysisOverridePermissions> requestOverridePermissions_overridePermissions_Analyses = null;
                if (cmdletContext.OverridePermissions_Analyses != null)
                {
                    requestOverridePermissions_overridePermissions_Analyses = cmdletContext.OverridePermissions_Analyses;
                }
                if (requestOverridePermissions_overridePermissions_Analyses != null)
                {
                    request.OverridePermissions.Analyses = requestOverridePermissions_overridePermissions_Analyses;
                    requestOverridePermissionsIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobDashboardOverridePermissions> requestOverridePermissions_overridePermissions_Dashboard = null;
                if (cmdletContext.OverridePermissions_Dashboard != null)
                {
                    requestOverridePermissions_overridePermissions_Dashboard = cmdletContext.OverridePermissions_Dashboard;
                }
                if (requestOverridePermissions_overridePermissions_Dashboard != null)
                {
                    request.OverridePermissions.Dashboards = requestOverridePermissions_overridePermissions_Dashboard;
                    requestOverridePermissionsIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobDataSetOverridePermissions> requestOverridePermissions_overridePermissions_DataSet = null;
                if (cmdletContext.OverridePermissions_DataSet != null)
                {
                    requestOverridePermissions_overridePermissions_DataSet = cmdletContext.OverridePermissions_DataSet;
                }
                if (requestOverridePermissions_overridePermissions_DataSet != null)
                {
                    request.OverridePermissions.DataSets = requestOverridePermissions_overridePermissions_DataSet;
                    requestOverridePermissionsIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobDataSourceOverridePermissions> requestOverridePermissions_overridePermissions_DataSource = null;
                if (cmdletContext.OverridePermissions_DataSource != null)
                {
                    requestOverridePermissions_overridePermissions_DataSource = cmdletContext.OverridePermissions_DataSource;
                }
                if (requestOverridePermissions_overridePermissions_DataSource != null)
                {
                    request.OverridePermissions.DataSources = requestOverridePermissions_overridePermissions_DataSource;
                    requestOverridePermissionsIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobFolderOverridePermissions> requestOverridePermissions_overridePermissions_Folder = null;
                if (cmdletContext.OverridePermissions_Folder != null)
                {
                    requestOverridePermissions_overridePermissions_Folder = cmdletContext.OverridePermissions_Folder;
                }
                if (requestOverridePermissions_overridePermissions_Folder != null)
                {
                    request.OverridePermissions.Folders = requestOverridePermissions_overridePermissions_Folder;
                    requestOverridePermissionsIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobThemeOverridePermissions> requestOverridePermissions_overridePermissions_Theme = null;
                if (cmdletContext.OverridePermissions_Theme != null)
                {
                    requestOverridePermissions_overridePermissions_Theme = cmdletContext.OverridePermissions_Theme;
                }
                if (requestOverridePermissions_overridePermissions_Theme != null)
                {
                    request.OverridePermissions.Themes = requestOverridePermissions_overridePermissions_Theme;
                    requestOverridePermissionsIsNull = false;
                }
                 // determine if request.OverridePermissions should be set to null
                if (requestOverridePermissionsIsNull)
                {
                    request.OverridePermissions = null;
                }
                
                 // populate OverrideTags
                var requestOverrideTagsIsNull = true;
                request.OverrideTags = new Amazon.QuickSight.Model.AssetBundleImportJobOverrideTags();
                List<Amazon.QuickSight.Model.AssetBundleImportJobAnalysisOverrideTags> requestOverrideTags_overrideTags_Analyses = null;
                if (cmdletContext.OverrideTags_Analyses != null)
                {
                    requestOverrideTags_overrideTags_Analyses = cmdletContext.OverrideTags_Analyses;
                }
                if (requestOverrideTags_overrideTags_Analyses != null)
                {
                    request.OverrideTags.Analyses = requestOverrideTags_overrideTags_Analyses;
                    requestOverrideTagsIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobDashboardOverrideTags> requestOverrideTags_overrideTags_Dashboard = null;
                if (cmdletContext.OverrideTags_Dashboard != null)
                {
                    requestOverrideTags_overrideTags_Dashboard = cmdletContext.OverrideTags_Dashboard;
                }
                if (requestOverrideTags_overrideTags_Dashboard != null)
                {
                    request.OverrideTags.Dashboards = requestOverrideTags_overrideTags_Dashboard;
                    requestOverrideTagsIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobDataSetOverrideTags> requestOverrideTags_overrideTags_DataSet = null;
                if (cmdletContext.OverrideTags_DataSet != null)
                {
                    requestOverrideTags_overrideTags_DataSet = cmdletContext.OverrideTags_DataSet;
                }
                if (requestOverrideTags_overrideTags_DataSet != null)
                {
                    request.OverrideTags.DataSets = requestOverrideTags_overrideTags_DataSet;
                    requestOverrideTagsIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobDataSourceOverrideTags> requestOverrideTags_overrideTags_DataSource = null;
                if (cmdletContext.OverrideTags_DataSource != null)
                {
                    requestOverrideTags_overrideTags_DataSource = cmdletContext.OverrideTags_DataSource;
                }
                if (requestOverrideTags_overrideTags_DataSource != null)
                {
                    request.OverrideTags.DataSources = requestOverrideTags_overrideTags_DataSource;
                    requestOverrideTagsIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobFolderOverrideTags> requestOverrideTags_overrideTags_Folder = null;
                if (cmdletContext.OverrideTags_Folder != null)
                {
                    requestOverrideTags_overrideTags_Folder = cmdletContext.OverrideTags_Folder;
                }
                if (requestOverrideTags_overrideTags_Folder != null)
                {
                    request.OverrideTags.Folders = requestOverrideTags_overrideTags_Folder;
                    requestOverrideTagsIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobThemeOverrideTags> requestOverrideTags_overrideTags_Theme = null;
                if (cmdletContext.OverrideTags_Theme != null)
                {
                    requestOverrideTags_overrideTags_Theme = cmdletContext.OverrideTags_Theme;
                }
                if (requestOverrideTags_overrideTags_Theme != null)
                {
                    request.OverrideTags.Themes = requestOverrideTags_overrideTags_Theme;
                    requestOverrideTagsIsNull = false;
                }
                List<Amazon.QuickSight.Model.AssetBundleImportJobVPCConnectionOverrideTags> requestOverrideTags_overrideTags_VPCConnection = null;
                if (cmdletContext.OverrideTags_VPCConnection != null)
                {
                    requestOverrideTags_overrideTags_VPCConnection = cmdletContext.OverrideTags_VPCConnection;
                }
                if (requestOverrideTags_overrideTags_VPCConnection != null)
                {
                    request.OverrideTags.VPCConnections = requestOverrideTags_overrideTags_VPCConnection;
                    requestOverrideTagsIsNull = false;
                }
                 // determine if request.OverrideTags should be set to null
                if (requestOverrideTagsIsNull)
                {
                    request.OverrideTags = null;
                }
                
                 // populate OverrideValidationStrategy
                var requestOverrideValidationStrategyIsNull = true;
                request.OverrideValidationStrategy = new Amazon.QuickSight.Model.AssetBundleImportJobOverrideValidationStrategy();
                System.Boolean? requestOverrideValidationStrategy_overrideValidationStrategy_StrictModeForAllResource = null;
                if (cmdletContext.OverrideValidationStrategy_StrictModeForAllResource != null)
                {
                    requestOverrideValidationStrategy_overrideValidationStrategy_StrictModeForAllResource = cmdletContext.OverrideValidationStrategy_StrictModeForAllResource.Value;
                }
                if (requestOverrideValidationStrategy_overrideValidationStrategy_StrictModeForAllResource != null)
                {
                    request.OverrideValidationStrategy.StrictModeForAllResources = requestOverrideValidationStrategy_overrideValidationStrategy_StrictModeForAllResource.Value;
                    requestOverrideValidationStrategyIsNull = false;
                }
                 // determine if request.OverrideValidationStrategy should be set to null
                if (requestOverrideValidationStrategyIsNull)
                {
                    request.OverrideValidationStrategy = null;
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
            finally
            {
                if( _AssetBundleImportSource_BodyStream != null)
                {
                    _AssetBundleImportSource_BodyStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.QuickSight.Model.StartAssetBundleImportJobResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.StartAssetBundleImportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "StartAssetBundleImportJob");
            try
            {
                #if DESKTOP
                return client.StartAssetBundleImportJob(request);
                #elif CORECLR
                return client.StartAssetBundleImportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String AssetBundleImportJobId { get; set; }
            public byte[] AssetBundleImportSource_Body { get; set; }
            public System.String AssetBundleImportSource_S3Uri { get; set; }
            public System.String AwsAccountId { get; set; }
            public Amazon.QuickSight.AssetBundleImportFailureAction FailureAction { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobAnalysisOverrideParameters> OverrideParameters_Analyses { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobDashboardOverrideParameters> OverrideParameters_Dashboard { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobDataSetOverrideParameters> OverrideParameters_DataSet { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobDataSourceOverrideParameters> OverrideParameters_DataSource { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobFolderOverrideParameters> OverrideParameters_Folder { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobRefreshScheduleOverrideParameters> OverrideParameters_RefreshSchedule { get; set; }
            public System.String ResourceIdOverrideConfiguration_PrefixForAllResource { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobThemeOverrideParameters> OverrideParameters_Theme { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobVPCConnectionOverrideParameters> OverrideParameters_VPCConnection { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobAnalysisOverridePermissions> OverridePermissions_Analyses { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobDashboardOverridePermissions> OverridePermissions_Dashboard { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobDataSetOverridePermissions> OverridePermissions_DataSet { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobDataSourceOverridePermissions> OverridePermissions_DataSource { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobFolderOverridePermissions> OverridePermissions_Folder { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobThemeOverridePermissions> OverridePermissions_Theme { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobAnalysisOverrideTags> OverrideTags_Analyses { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobDashboardOverrideTags> OverrideTags_Dashboard { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobDataSetOverrideTags> OverrideTags_DataSet { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobDataSourceOverrideTags> OverrideTags_DataSource { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobFolderOverrideTags> OverrideTags_Folder { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobThemeOverrideTags> OverrideTags_Theme { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobVPCConnectionOverrideTags> OverrideTags_VPCConnection { get; set; }
            public System.Boolean? OverrideValidationStrategy_StrictModeForAllResource { get; set; }
            public System.Func<Amazon.QuickSight.Model.StartAssetBundleImportJobResponse, StartQSAssetBundleImportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
