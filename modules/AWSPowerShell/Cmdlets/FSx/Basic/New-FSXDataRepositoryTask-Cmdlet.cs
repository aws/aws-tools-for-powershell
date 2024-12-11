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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Creates an Amazon FSx for Lustre data repository task. A <c>CreateDataRepositoryTask</c>
    /// operation will fail if a data repository is not linked to the FSx file system.
    /// 
    ///  
    /// <para>
    /// You use import and export data repository tasks to perform bulk operations between
    /// your FSx for Lustre file system and its linked data repositories. An example of a
    /// data repository task is exporting any data and metadata changes, including POSIX metadata,
    /// to files, directories, and symbolic links (symlinks) from your FSx file system to
    /// a linked data repository.
    /// </para><para>
    /// You use release data repository tasks to release data from your file system for files
    /// that are exported to S3. The metadata of released files remains on the file system
    /// so users or applications can still access released files by reading the files again,
    /// which will restore data from Amazon S3 to the FSx for Lustre file system.
    /// </para><para>
    /// To learn more about data repository tasks, see <a href="https://docs.aws.amazon.com/fsx/latest/LustreGuide/data-repository-tasks.html">Data
    /// Repository Tasks</a>. To learn more about linking a data repository to your file system,
    /// see <a href="https://docs.aws.amazon.com/fsx/latest/LustreGuide/create-dra-linked-data-repo.html">Linking
    /// your file system to an S3 bucket</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "FSXDataRepositoryTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.DataRepositoryTask")]
    [AWSCmdlet("Calls the Amazon FSx CreateDataRepositoryTask API operation.", Operation = new[] {"CreateDataRepositoryTask"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateDataRepositoryTaskResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.DataRepositoryTask or Amazon.FSx.Model.CreateDataRepositoryTaskResponse",
        "This cmdlet returns an Amazon.FSx.Model.DataRepositoryTask object.",
        "The service call response (type Amazon.FSx.Model.CreateDataRepositoryTaskResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewFSXDataRepositoryTaskCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CapacityToRelease
        /// <summary>
        /// <para>
        /// <para>Specifies the amount of data to release, in GiB, by an Amazon File Cache <c>AUTO_RELEASE_DATA</c>
        /// task that automatically releases files from the cache.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CapacityToRelease { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Report_Enabled
        /// <summary>
        /// <para>
        /// <para>Set <c>Enabled</c> to <c>True</c> to generate a <c>CompletionReport</c> when the task
        /// completes. If set to <c>true</c>, then you need to provide a report <c>Scope</c>,
        /// <c>Path</c>, and <c>Format</c>. Set <c>Enabled</c> to <c>False</c> if you do not want
        /// a <c>CompletionReport</c> generated when the task completes.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? Report_Enabled { get; set; }
        #endregion
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter Report_Format
        /// <summary>
        /// <para>
        /// <para>Required if <c>Enabled</c> is set to <c>true</c>. Specifies the format of the <c>CompletionReport</c>.
        /// <c>REPORT_CSV_20191124</c> is the only format currently supported. When <c>Format</c>
        /// is set to <c>REPORT_CSV_20191124</c>, the <c>CompletionReport</c> is provided in CSV
        /// format, and is delivered to <c>{path}/task-{id}/failures.csv</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.ReportFormat")]
        public Amazon.FSx.ReportFormat Report_Format { get; set; }
        #endregion
        
        #region Parameter Report_Path
        /// <summary>
        /// <para>
        /// <para>Required if <c>Enabled</c> is set to <c>true</c>. Specifies the location of the report
        /// on the file system's linked S3 data repository. An absolute path that defines where
        /// the completion report will be stored in the destination location. The <c>Path</c>
        /// you provide must be located within the file system’s ExportPath. An example <c>Path</c>
        /// value is "s3://amzn-s3-demo-bucket/myExportPath/optionalPrefix". The report provides
        /// the following information for each file in the report: FilePath, FileStatus, and ErrorCode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Report_Path { get; set; }
        #endregion
        
        #region Parameter Path
        /// <summary>
        /// <para>
        /// <para>A list of paths for the data repository task to use when the task is processed. If
        /// a path that you provide isn't valid, the task fails. If you don't provide paths, the
        /// default behavior is to export all files to S3 (for export tasks), import all files
        /// from S3 (for import tasks), or release all exported files that meet the last accessed
        /// time criteria (for release tasks).</para><ul><li><para>For export tasks, the list contains paths on the FSx for Lustre file system from which
        /// the files are exported to the Amazon S3 bucket. The default path is the file system
        /// root directory. The paths you provide need to be relative to the mount point of the
        /// file system. If the mount point is <c>/mnt/fsx</c> and <c>/mnt/fsx/path1</c> is a
        /// directory or file on the file system you want to export, then the path to provide
        /// is <c>path1</c>.</para></li><li><para>For import tasks, the list contains paths in the Amazon S3 bucket from which POSIX
        /// metadata changes are imported to the FSx for Lustre file system. The path can be an
        /// S3 bucket or prefix in the format <c>s3://bucket-name/prefix</c> (where <c>prefix</c>
        /// is optional).</para></li><li><para>For release tasks, the list contains directory or file paths on the FSx for Lustre
        /// file system from which to release exported files. If a directory is specified, files
        /// within the directory are released. If a file path is specified, only that file is
        /// released. To release all exported files in the file system, specify a forward slash
        /// (/) as the path.</para><note><para>A file must also meet the last accessed time criteria specified in for the file to
        /// be released.</para></note></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Paths")]
        public System.String[] Path { get; set; }
        #endregion
        
        #region Parameter Report_Scope
        /// <summary>
        /// <para>
        /// <para>Required if <c>Enabled</c> is set to <c>true</c>. Specifies the scope of the <c>CompletionReport</c>;
        /// <c>FAILED_FILES_ONLY</c> is the only scope currently supported. When <c>Scope</c>
        /// is set to <c>FAILED_FILES_ONLY</c>, the <c>CompletionReport</c> only contains information
        /// about files that the data repository task failed to process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.ReportScope")]
        public Amazon.FSx.ReportScope Report_Scope { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.FSx.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>Specifies the type of data repository task to create.</para><ul><li><para><c>EXPORT_TO_REPOSITORY</c> tasks export from your Amazon FSx for Lustre file system
        /// to a linked data repository.</para></li><li><para><c>IMPORT_METADATA_FROM_REPOSITORY</c> tasks import metadata changes from a linked
        /// S3 bucket to your Amazon FSx for Lustre file system.</para></li><li><para><c>RELEASE_DATA_FROM_FILESYSTEM</c> tasks release files in your Amazon FSx for Lustre
        /// file system that have been exported to a linked S3 bucket and that meet your specified
        /// release criteria.</para></li><li><para><c>AUTO_RELEASE_DATA</c> tasks automatically release files from an Amazon File Cache
        /// resource.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FSx.DataRepositoryTaskType")]
        public Amazon.FSx.DataRepositoryTaskType Type { get; set; }
        #endregion
        
        #region Parameter DurationSinceLastAccess_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of time used by the <c>Value</c> parameter to determine if a file can be
        /// released, based on when it was last accessed. <c>DAYS</c> is the only supported value.
        /// This is a required parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReleaseConfiguration_DurationSinceLastAccess_Unit")]
        [AWSConstantClassSource("Amazon.FSx.Unit")]
        public Amazon.FSx.Unit DurationSinceLastAccess_Unit { get; set; }
        #endregion
        
        #region Parameter DurationSinceLastAccess_Value
        /// <summary>
        /// <para>
        /// <para>An integer that represents the minimum amount of time (in days) since a file was last
        /// accessed in the file system. Only exported files with a <c>MAX(atime, ctime, mtime)</c>
        /// timestamp that is more than this amount of time in the past (relative to the task
        /// create time) will be released. The default of <c>Value</c> is <c>0</c>. This is a
        /// required parameter.</para><note><para>If an exported file meets the last accessed time criteria, its file or directory path
        /// must also be specified in the <c>Paths</c> parameter of the operation in order for
        /// the file to be released.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReleaseConfiguration_DurationSinceLastAccess_Value")]
        public System.Int64? DurationSinceLastAccess_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataRepositoryTask'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CreateDataRepositoryTaskResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CreateDataRepositoryTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataRepositoryTask";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FileSystemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXDataRepositoryTask (CreateDataRepositoryTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CreateDataRepositoryTaskResponse, NewFSXDataRepositoryTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapacityToRelease = this.CapacityToRelease;
            context.ClientRequestToken = this.ClientRequestToken;
            context.FileSystemId = this.FileSystemId;
            #if MODULAR
            if (this.FileSystemId == null && ParameterWasBound(nameof(this.FileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Path != null)
            {
                context.Path = new List<System.String>(this.Path);
            }
            context.DurationSinceLastAccess_Unit = this.DurationSinceLastAccess_Unit;
            context.DurationSinceLastAccess_Value = this.DurationSinceLastAccess_Value;
            context.Report_Enabled = this.Report_Enabled;
            #if MODULAR
            if (this.Report_Enabled == null && ParameterWasBound(nameof(this.Report_Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter Report_Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Report_Format = this.Report_Format;
            context.Report_Path = this.Report_Path;
            context.Report_Scope = this.Report_Scope;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.FSx.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FSx.Model.CreateDataRepositoryTaskRequest();
            
            if (cmdletContext.CapacityToRelease != null)
            {
                request.CapacityToRelease = cmdletContext.CapacityToRelease.Value;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            if (cmdletContext.Path != null)
            {
                request.Paths = cmdletContext.Path;
            }
            
             // populate ReleaseConfiguration
            var requestReleaseConfigurationIsNull = true;
            request.ReleaseConfiguration = new Amazon.FSx.Model.ReleaseConfiguration();
            Amazon.FSx.Model.DurationSinceLastAccess requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess = null;
            
             // populate DurationSinceLastAccess
            var requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccessIsNull = true;
            requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess = new Amazon.FSx.Model.DurationSinceLastAccess();
            Amazon.FSx.Unit requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess_durationSinceLastAccess_Unit = null;
            if (cmdletContext.DurationSinceLastAccess_Unit != null)
            {
                requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess_durationSinceLastAccess_Unit = cmdletContext.DurationSinceLastAccess_Unit;
            }
            if (requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess_durationSinceLastAccess_Unit != null)
            {
                requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess.Unit = requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess_durationSinceLastAccess_Unit;
                requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccessIsNull = false;
            }
            System.Int64? requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess_durationSinceLastAccess_Value = null;
            if (cmdletContext.DurationSinceLastAccess_Value != null)
            {
                requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess_durationSinceLastAccess_Value = cmdletContext.DurationSinceLastAccess_Value.Value;
            }
            if (requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess_durationSinceLastAccess_Value != null)
            {
                requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess.Value = requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess_durationSinceLastAccess_Value.Value;
                requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccessIsNull = false;
            }
             // determine if requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess should be set to null
            if (requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccessIsNull)
            {
                requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess = null;
            }
            if (requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess != null)
            {
                request.ReleaseConfiguration.DurationSinceLastAccess = requestReleaseConfiguration_releaseConfiguration_DurationSinceLastAccess;
                requestReleaseConfigurationIsNull = false;
            }
             // determine if request.ReleaseConfiguration should be set to null
            if (requestReleaseConfigurationIsNull)
            {
                request.ReleaseConfiguration = null;
            }
            
             // populate Report
            var requestReportIsNull = true;
            request.Report = new Amazon.FSx.Model.CompletionReport();
            System.Boolean? requestReport_report_Enabled = null;
            if (cmdletContext.Report_Enabled != null)
            {
                requestReport_report_Enabled = cmdletContext.Report_Enabled.Value;
            }
            if (requestReport_report_Enabled != null)
            {
                request.Report.Enabled = requestReport_report_Enabled.Value;
                requestReportIsNull = false;
            }
            Amazon.FSx.ReportFormat requestReport_report_Format = null;
            if (cmdletContext.Report_Format != null)
            {
                requestReport_report_Format = cmdletContext.Report_Format;
            }
            if (requestReport_report_Format != null)
            {
                request.Report.Format = requestReport_report_Format;
                requestReportIsNull = false;
            }
            System.String requestReport_report_Path = null;
            if (cmdletContext.Report_Path != null)
            {
                requestReport_report_Path = cmdletContext.Report_Path;
            }
            if (requestReport_report_Path != null)
            {
                request.Report.Path = requestReport_report_Path;
                requestReportIsNull = false;
            }
            Amazon.FSx.ReportScope requestReport_report_Scope = null;
            if (cmdletContext.Report_Scope != null)
            {
                requestReport_report_Scope = cmdletContext.Report_Scope;
            }
            if (requestReport_report_Scope != null)
            {
                request.Report.Scope = requestReport_report_Scope;
                requestReportIsNull = false;
            }
             // determine if request.Report should be set to null
            if (requestReportIsNull)
            {
                request.Report = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.FSx.Model.CreateDataRepositoryTaskResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateDataRepositoryTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateDataRepositoryTask");
            try
            {
                #if DESKTOP
                return client.CreateDataRepositoryTask(request);
                #elif CORECLR
                return client.CreateDataRepositoryTaskAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? CapacityToRelease { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String FileSystemId { get; set; }
            public List<System.String> Path { get; set; }
            public Amazon.FSx.Unit DurationSinceLastAccess_Unit { get; set; }
            public System.Int64? DurationSinceLastAccess_Value { get; set; }
            public System.Boolean? Report_Enabled { get; set; }
            public Amazon.FSx.ReportFormat Report_Format { get; set; }
            public System.String Report_Path { get; set; }
            public Amazon.FSx.ReportScope Report_Scope { get; set; }
            public List<Amazon.FSx.Model.Tag> Tag { get; set; }
            public Amazon.FSx.DataRepositoryTaskType Type { get; set; }
            public System.Func<Amazon.FSx.Model.CreateDataRepositoryTaskResponse, NewFSXDataRepositoryTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataRepositoryTask;
        }
        
    }
}
