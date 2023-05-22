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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Starts an Asset Bundle import job.
    /// 
    ///  
    /// <para>
    /// An Asset Bundle import job imports specified Amazon QuickSight assets into an Amazon
    /// QuickSight account. You can also choose to import a naming prefix and specified configuration
    /// overrides. The assets that are contained in the bundle file that you provide are used
    /// to create or update a new or existing asset in your Amazon QuickSight account. Each
    /// Amazon QuickSight account can run up to 10 import jobs concurrently.
    /// </para><para>
    /// The API caller must have the necessary <code>"create"</code>, <code>"describe"</code>,
    /// and <code>"update"</code> permissions in their IAM role to access each resource type
    /// that is contained in the bundle file before the resources can be imported.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "QSAssetBundleImportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.StartAssetBundleImportJobResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight StartAssetBundleImportJob API operation.", Operation = new[] {"StartAssetBundleImportJob"}, SelectReturnType = typeof(Amazon.QuickSight.Model.StartAssetBundleImportJobResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.StartAssetBundleImportJobResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.StartAssetBundleImportJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartQSAssetBundleImportJobCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        #region Parameter OverrideParameters_Analyses
        /// <summary>
        /// <para>
        /// <para>A list of overrides for any <code>Analysis</code> resources that are present in the
        /// asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QuickSight.Model.AssetBundleImportJobAnalysisOverrideParameters[] OverrideParameters_Analyses { get; set; }
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
        /// <para>The bytes of the Base64 encoded asset bundle import zip file. This file can't exceed
        /// 20MB.</para><para>If you are calling the APIs from the Amazon Web Services Java, JavaScript, Python,
        /// or PHP SDKs, the SDK encodes Base64 automatically to allow the direct setting of the
        /// zip file's bytes. If you are using a SDK of a different language or are receiving
        /// related errors, try to Base64 encode your data.</para>
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
        /// <para>A list of overrides for any <code>Dashboard</code> resources that are present in the
        /// asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideParameters_Dashboards")]
        public Amazon.QuickSight.Model.AssetBundleImportJobDashboardOverrideParameters[] OverrideParameters_Dashboard { get; set; }
        #endregion
        
        #region Parameter OverrideParameters_DataSet
        /// <summary>
        /// <para>
        /// <para>A list of overrides for any <code>DataSet</code> resources that are present in the
        /// asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideParameters_DataSets")]
        public Amazon.QuickSight.Model.AssetBundleImportJobDataSetOverrideParameters[] OverrideParameters_DataSet { get; set; }
        #endregion
        
        #region Parameter OverrideParameters_DataSource
        /// <summary>
        /// <para>
        /// <para> A list of overrides for any <code>DataSource</code> resources that are present in
        /// the asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideParameters_DataSources")]
        public Amazon.QuickSight.Model.AssetBundleImportJobDataSourceOverrideParameters[] OverrideParameters_DataSource { get; set; }
        #endregion
        
        #region Parameter FailureAction
        /// <summary>
        /// <para>
        /// <para>The failure action for the import job.</para><para>If you choose <code>ROLLBACK</code>, failed import jobs will attempt to undo any asset
        /// changes caused by the failed job.</para><para>If you choose <code>DO_NOTHING</code>, failed import jobs will not attempt to roll
        /// back any asset changes caused by the failed job, possibly leaving the Amazon QuickSight
        /// account in an inconsistent state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.AssetBundleImportFailureAction")]
        public Amazon.QuickSight.AssetBundleImportFailureAction FailureAction { get; set; }
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
        /// <para>A list of overrides for any <code>RefreshSchedule</code> resources that are present
        /// in the asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideParameters_RefreshSchedules")]
        public Amazon.QuickSight.Model.AssetBundleImportJobRefreshScheduleOverrideParameters[] OverrideParameters_RefreshSchedule { get; set; }
        #endregion
        
        #region Parameter AssetBundleImportSource_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 uri for an asset bundle import file that exists in an Amazon S3 bucket
        /// that the caller has read access to. The file must be a zip format file and can't exceed
        /// 20MB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssetBundleImportSource_S3Uri { get; set; }
        #endregion
        
        #region Parameter OverrideParameters_Theme
        /// <summary>
        /// <para>
        /// <para>A list of overrides for any <code>Theme</code> resources that are present in the asset
        /// bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideParameters_Themes")]
        public Amazon.QuickSight.Model.AssetBundleImportJobThemeOverrideParameters[] OverrideParameters_Theme { get; set; }
        #endregion
        
        #region Parameter OverrideParameters_VPCConnection
        /// <summary>
        /// <para>
        /// <para>A list of overrides for any <code>VPCConnection</code> resources that are present
        /// in the asset bundle that is imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideParameters_VPCConnections")]
        public Amazon.QuickSight.Model.AssetBundleImportJobVPCConnectionOverrideParameters[] OverrideParameters_VPCConnection { get; set; }
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
            public List<Amazon.QuickSight.Model.AssetBundleImportJobRefreshScheduleOverrideParameters> OverrideParameters_RefreshSchedule { get; set; }
            public System.String ResourceIdOverrideConfiguration_PrefixForAllResource { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobThemeOverrideParameters> OverrideParameters_Theme { get; set; }
            public List<Amazon.QuickSight.Model.AssetBundleImportJobVPCConnectionOverrideParameters> OverrideParameters_VPCConnection { get; set; }
            public System.Func<Amazon.QuickSight.Model.StartAssetBundleImportJobResponse, StartQSAssetBundleImportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
