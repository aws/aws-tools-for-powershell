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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Defines a job to ingest data to IoT SiteWise from Amazon S3. For more information,
    /// see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/CreateBulkImportJob.html">Create
    /// a bulk import job (CLI)</a> in the <i>Amazon Simple Storage Service User Guide</i>.
    /// 
    ///  <important><para>
    /// Before you create a bulk import job, you must enable IoT SiteWise warm tier or IoT
    /// SiteWise cold tier. For more information about how to configure storage settings,
    /// see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/APIReference/API_PutStorageConfiguration.html">PutStorageConfiguration</a>.
    /// </para><para>
    /// Bulk import is designed to store historical data to IoT SiteWise. It does not trigger
    /// computations or notifications on IoT SiteWise warm or cold tier storage.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "IOTSWBulkImportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.CreateBulkImportJobResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise CreateBulkImportJob API operation.", Operation = new[] {"CreateBulkImportJob"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.CreateBulkImportJobResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.CreateBulkImportJobResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.CreateBulkImportJobResponse object containing multiple properties."
    )]
    public partial class NewIOTSWBulkImportJobCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdaptiveIngestion
        /// <summary>
        /// <para>
        /// <para>If set to true, ingest new data into IoT SiteWise storage. Measurements with notifications,
        /// metrics and transforms are computed. If set to false, historical data is ingested
        /// into IoT SiteWise as is.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AdaptiveIngestion { get; set; }
        #endregion
        
        #region Parameter ErrorReportLocation_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket to which errors associated with the bulk import job
        /// are sent.</para>
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
        public System.String ErrorReportLocation_Bucket { get; set; }
        #endregion
        
        #region Parameter Csv_ColumnName
        /// <summary>
        /// <para>
        /// <para>The column names specified in the .csv file.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfiguration_FileFormat_Csv_ColumnNames")]
        public System.String[] Csv_ColumnName { get; set; }
        #endregion
        
        #region Parameter DeleteFilesAfterImport
        /// <summary>
        /// <para>
        /// <para>If set to true, your data files is deleted from S3, after ingestion into IoT SiteWise
        /// storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeleteFilesAfterImport { get; set; }
        #endregion
        
        #region Parameter File
        /// <summary>
        /// <para>
        /// <para>The files in the specified Amazon S3 bucket that contain your data.</para><para />
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
        [Alias("Files")]
        public Amazon.IoTSiteWise.Model.File[] File { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The unique name that helps identify the job request.</para>
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
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter JobRoleArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">ARN</a>
        /// of the IAM role that allows IoT SiteWise to read Amazon S3 data.</para>
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
        public System.String JobRoleArn { get; set; }
        #endregion
        
        #region Parameter FileFormat_Parquet
        /// <summary>
        /// <para>
        /// <para>The file is in parquet format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfiguration_FileFormat_Parquet")]
        public Amazon.IoTSiteWise.Model.Parquet FileFormat_Parquet { get; set; }
        #endregion
        
        #region Parameter ErrorReportLocation_Prefix
        /// <summary>
        /// <para>
        /// <para>Amazon S3 uses the prefix as a folder name to organize data in the bucket. Each Amazon
        /// S3 object has a key that is its unique identifier in the bucket. Each object in a
        /// bucket has exactly one key. The prefix must end with a forward slash (/). For more
        /// information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-prefixes.html">Organizing
        /// objects using prefixes</a> in the <i>Amazon Simple Storage Service User Guide</i>.</para>
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
        public System.String ErrorReportLocation_Prefix { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.CreateBulkImportJobResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.CreateBulkImportJobResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTSWBulkImportJob (CreateBulkImportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.CreateBulkImportJobResponse, NewIOTSWBulkImportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdaptiveIngestion = this.AdaptiveIngestion;
            context.DeleteFilesAfterImport = this.DeleteFilesAfterImport;
            context.ErrorReportLocation_Bucket = this.ErrorReportLocation_Bucket;
            #if MODULAR
            if (this.ErrorReportLocation_Bucket == null && ParameterWasBound(nameof(this.ErrorReportLocation_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter ErrorReportLocation_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ErrorReportLocation_Prefix = this.ErrorReportLocation_Prefix;
            #if MODULAR
            if (this.ErrorReportLocation_Prefix == null && ParameterWasBound(nameof(this.ErrorReportLocation_Prefix)))
            {
                WriteWarning("You are passing $null as a value for parameter ErrorReportLocation_Prefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.File != null)
            {
                context.File = new List<Amazon.IoTSiteWise.Model.File>(this.File);
            }
            #if MODULAR
            if (this.File == null && ParameterWasBound(nameof(this.File)))
            {
                WriteWarning("You are passing $null as a value for parameter File which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Csv_ColumnName != null)
            {
                context.Csv_ColumnName = new List<System.String>(this.Csv_ColumnName);
            }
            context.FileFormat_Parquet = this.FileFormat_Parquet;
            context.JobName = this.JobName;
            #if MODULAR
            if (this.JobName == null && ParameterWasBound(nameof(this.JobName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobRoleArn = this.JobRoleArn;
            #if MODULAR
            if (this.JobRoleArn == null && ParameterWasBound(nameof(this.JobRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter JobRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTSiteWise.Model.CreateBulkImportJobRequest();
            
            if (cmdletContext.AdaptiveIngestion != null)
            {
                request.AdaptiveIngestion = cmdletContext.AdaptiveIngestion.Value;
            }
            if (cmdletContext.DeleteFilesAfterImport != null)
            {
                request.DeleteFilesAfterImport = cmdletContext.DeleteFilesAfterImport.Value;
            }
            
             // populate ErrorReportLocation
            var requestErrorReportLocationIsNull = true;
            request.ErrorReportLocation = new Amazon.IoTSiteWise.Model.ErrorReportLocation();
            System.String requestErrorReportLocation_errorReportLocation_Bucket = null;
            if (cmdletContext.ErrorReportLocation_Bucket != null)
            {
                requestErrorReportLocation_errorReportLocation_Bucket = cmdletContext.ErrorReportLocation_Bucket;
            }
            if (requestErrorReportLocation_errorReportLocation_Bucket != null)
            {
                request.ErrorReportLocation.Bucket = requestErrorReportLocation_errorReportLocation_Bucket;
                requestErrorReportLocationIsNull = false;
            }
            System.String requestErrorReportLocation_errorReportLocation_Prefix = null;
            if (cmdletContext.ErrorReportLocation_Prefix != null)
            {
                requestErrorReportLocation_errorReportLocation_Prefix = cmdletContext.ErrorReportLocation_Prefix;
            }
            if (requestErrorReportLocation_errorReportLocation_Prefix != null)
            {
                request.ErrorReportLocation.Prefix = requestErrorReportLocation_errorReportLocation_Prefix;
                requestErrorReportLocationIsNull = false;
            }
             // determine if request.ErrorReportLocation should be set to null
            if (requestErrorReportLocationIsNull)
            {
                request.ErrorReportLocation = null;
            }
            if (cmdletContext.File != null)
            {
                request.Files = cmdletContext.File;
            }
            
             // populate JobConfiguration
            var requestJobConfigurationIsNull = true;
            request.JobConfiguration = new Amazon.IoTSiteWise.Model.JobConfiguration();
            Amazon.IoTSiteWise.Model.FileFormat requestJobConfiguration_jobConfiguration_FileFormat = null;
            
             // populate FileFormat
            var requestJobConfiguration_jobConfiguration_FileFormatIsNull = true;
            requestJobConfiguration_jobConfiguration_FileFormat = new Amazon.IoTSiteWise.Model.FileFormat();
            Amazon.IoTSiteWise.Model.Parquet requestJobConfiguration_jobConfiguration_FileFormat_fileFormat_Parquet = null;
            if (cmdletContext.FileFormat_Parquet != null)
            {
                requestJobConfiguration_jobConfiguration_FileFormat_fileFormat_Parquet = cmdletContext.FileFormat_Parquet;
            }
            if (requestJobConfiguration_jobConfiguration_FileFormat_fileFormat_Parquet != null)
            {
                requestJobConfiguration_jobConfiguration_FileFormat.Parquet = requestJobConfiguration_jobConfiguration_FileFormat_fileFormat_Parquet;
                requestJobConfiguration_jobConfiguration_FileFormatIsNull = false;
            }
            Amazon.IoTSiteWise.Model.Csv requestJobConfiguration_jobConfiguration_FileFormat_jobConfiguration_FileFormat_Csv = null;
            
             // populate Csv
            var requestJobConfiguration_jobConfiguration_FileFormat_jobConfiguration_FileFormat_CsvIsNull = true;
            requestJobConfiguration_jobConfiguration_FileFormat_jobConfiguration_FileFormat_Csv = new Amazon.IoTSiteWise.Model.Csv();
            List<System.String> requestJobConfiguration_jobConfiguration_FileFormat_jobConfiguration_FileFormat_Csv_csv_ColumnName = null;
            if (cmdletContext.Csv_ColumnName != null)
            {
                requestJobConfiguration_jobConfiguration_FileFormat_jobConfiguration_FileFormat_Csv_csv_ColumnName = cmdletContext.Csv_ColumnName;
            }
            if (requestJobConfiguration_jobConfiguration_FileFormat_jobConfiguration_FileFormat_Csv_csv_ColumnName != null)
            {
                requestJobConfiguration_jobConfiguration_FileFormat_jobConfiguration_FileFormat_Csv.ColumnNames = requestJobConfiguration_jobConfiguration_FileFormat_jobConfiguration_FileFormat_Csv_csv_ColumnName;
                requestJobConfiguration_jobConfiguration_FileFormat_jobConfiguration_FileFormat_CsvIsNull = false;
            }
             // determine if requestJobConfiguration_jobConfiguration_FileFormat_jobConfiguration_FileFormat_Csv should be set to null
            if (requestJobConfiguration_jobConfiguration_FileFormat_jobConfiguration_FileFormat_CsvIsNull)
            {
                requestJobConfiguration_jobConfiguration_FileFormat_jobConfiguration_FileFormat_Csv = null;
            }
            if (requestJobConfiguration_jobConfiguration_FileFormat_jobConfiguration_FileFormat_Csv != null)
            {
                requestJobConfiguration_jobConfiguration_FileFormat.Csv = requestJobConfiguration_jobConfiguration_FileFormat_jobConfiguration_FileFormat_Csv;
                requestJobConfiguration_jobConfiguration_FileFormatIsNull = false;
            }
             // determine if requestJobConfiguration_jobConfiguration_FileFormat should be set to null
            if (requestJobConfiguration_jobConfiguration_FileFormatIsNull)
            {
                requestJobConfiguration_jobConfiguration_FileFormat = null;
            }
            if (requestJobConfiguration_jobConfiguration_FileFormat != null)
            {
                request.JobConfiguration.FileFormat = requestJobConfiguration_jobConfiguration_FileFormat;
                requestJobConfigurationIsNull = false;
            }
             // determine if request.JobConfiguration should be set to null
            if (requestJobConfigurationIsNull)
            {
                request.JobConfiguration = null;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.JobRoleArn != null)
            {
                request.JobRoleArn = cmdletContext.JobRoleArn;
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
        
        private Amazon.IoTSiteWise.Model.CreateBulkImportJobResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.CreateBulkImportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "CreateBulkImportJob");
            try
            {
                return client.CreateBulkImportJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AdaptiveIngestion { get; set; }
            public System.Boolean? DeleteFilesAfterImport { get; set; }
            public System.String ErrorReportLocation_Bucket { get; set; }
            public System.String ErrorReportLocation_Prefix { get; set; }
            public List<Amazon.IoTSiteWise.Model.File> File { get; set; }
            public List<System.String> Csv_ColumnName { get; set; }
            public Amazon.IoTSiteWise.Model.Parquet FileFormat_Parquet { get; set; }
            public System.String JobName { get; set; }
            public System.String JobRoleArn { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.CreateBulkImportJobResponse, NewIOTSWBulkImportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
