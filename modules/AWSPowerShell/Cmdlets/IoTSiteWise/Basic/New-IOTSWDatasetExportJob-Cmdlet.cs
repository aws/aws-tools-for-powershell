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
    /// Starts an asynchronous job that exports dataset and time-series data from a workspace
    /// to Amazon S3. The operation returns a jobId immediately; poll DescribeDatasetExportJob
    /// to track progress and ListDatasetExportJobs to enumerate a workspace's jobs.
    /// </summary>
    [Cmdlet("New", "IOTSWDatasetExportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.CreateDatasetExportJobResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise CreateDatasetExportJob API operation.", Operation = new[] {"CreateDatasetExportJob"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.CreateDatasetExportJobResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.CreateDatasetExportJobResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.CreateDatasetExportJobResponse object containing multiple properties."
    )]
    public partial class NewIOTSWDatasetExportJobCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Input_Dataset_DatasetId
        /// <summary>
        /// <para>
        /// &lt;p&gt;The unique identifier for the dataset.&lt;/p&gt;
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Dataset_DatasetId { get; set; }
        #endregion
        
        #region Parameter DestinationS3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI where output clips will be written.</para>
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
        public System.String DestinationS3Uri { get; set; }
        #endregion
        
        #region Parameter Input_Dataset_ExportDataType
        /// <summary>
        /// <para>
        /// &lt;p&gt;The optional subset of data types
        /// to export. If omitted, all data types are exported.&lt;/p&gt;
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Dataset_ExportDataTypes")]
        public System.String[] Input_Dataset_ExportDataType { get; set; }
        #endregion
        
        #region Parameter Input_Dataset_TrimSettings_EndTime_OffsetInNano
        /// <summary>
        /// <para>
        /// <para>The nanosecond offset from <c>timeInSeconds</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Dataset_TrimSettings_EndTime_OffsetInNanos")]
        public System.Int32? Input_Dataset_TrimSettings_EndTime_OffsetInNano { get; set; }
        #endregion
        
        #region Parameter Input_Dataset_TrimSettings_StartTime_OffsetInNano
        /// <summary>
        /// <para>
        /// <para>The nanosecond offset from <c>timeInSeconds</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Dataset_TrimSettings_StartTime_OffsetInNanos")]
        public System.Int32? Input_Dataset_TrimSettings_StartTime_OffsetInNano { get; set; }
        #endregion
        
        #region Parameter ErrorReportLocation_S3Uri
        /// <summary>
        /// <para>
        /// &lt;p&gt;The S3 URI prefix for the error report.&lt;/p&gt;
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
        public System.String ErrorReportLocation_S3Uri { get; set; }
        #endregion
        
        #region Parameter Input_Dataset_TrimSettings_EndTime_TimeInSecond
        /// <summary>
        /// <para>
        /// <para>The timestamp date, in seconds, in the Unix epoch format. Fractional nanosecond data
        /// is provided by <c>offsetInNanos</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Dataset_TrimSettings_EndTime_TimeInSeconds")]
        public System.Int64? Input_Dataset_TrimSettings_EndTime_TimeInSecond { get; set; }
        #endregion
        
        #region Parameter Input_Dataset_TrimSettings_StartTime_TimeInSecond
        /// <summary>
        /// <para>
        /// <para>The timestamp date, in seconds, in the Unix epoch format. Fractional nanosecond data
        /// is provided by <c>offsetInNanos</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Dataset_TrimSettings_StartTime_TimeInSeconds")]
        public System.Int64? Input_Dataset_TrimSettings_StartTime_TimeInSecond { get; set; }
        #endregion
        
        #region Parameter Input_Timesery
        /// <summary>
        /// <para>
        /// &lt;p&gt;List of individual timeseries items
        /// to process.&lt;/p&gt;
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_Timeseries")]
        public Amazon.IoTSiteWise.Model.TimeseriesItem[] Input_Timesery { get; set; }
        #endregion
        
        #region Parameter WorkspaceName
        /// <summary>
        /// <para>
        /// <para>The name of the workspace in which to create the dataset export job.</para>
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
        public System.String WorkspaceName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. The AWS SDKs and CLI populate this automatically.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.CreateDatasetExportJobResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.CreateDatasetExportJobResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkspaceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTSWDatasetExportJob (CreateDatasetExportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.CreateDatasetExportJobResponse, NewIOTSWDatasetExportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DestinationS3Uri = this.DestinationS3Uri;
            #if MODULAR
            if (this.DestinationS3Uri == null && ParameterWasBound(nameof(this.DestinationS3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationS3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ErrorReportLocation_S3Uri = this.ErrorReportLocation_S3Uri;
            #if MODULAR
            if (this.ErrorReportLocation_S3Uri == null && ParameterWasBound(nameof(this.ErrorReportLocation_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter ErrorReportLocation_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Input_Dataset_DatasetId = this.Input_Dataset_DatasetId;
            if (this.Input_Dataset_ExportDataType != null)
            {
                context.Input_Dataset_ExportDataType = new List<System.String>(this.Input_Dataset_ExportDataType);
            }
            context.Input_Dataset_TrimSettings_EndTime_OffsetInNano = this.Input_Dataset_TrimSettings_EndTime_OffsetInNano;
            context.Input_Dataset_TrimSettings_EndTime_TimeInSecond = this.Input_Dataset_TrimSettings_EndTime_TimeInSecond;
            context.Input_Dataset_TrimSettings_StartTime_OffsetInNano = this.Input_Dataset_TrimSettings_StartTime_OffsetInNano;
            context.Input_Dataset_TrimSettings_StartTime_TimeInSecond = this.Input_Dataset_TrimSettings_StartTime_TimeInSecond;
            if (this.Input_Timesery != null)
            {
                context.Input_Timesery = new List<Amazon.IoTSiteWise.Model.TimeseriesItem>(this.Input_Timesery);
            }
            context.WorkspaceName = this.WorkspaceName;
            #if MODULAR
            if (this.WorkspaceName == null && ParameterWasBound(nameof(this.WorkspaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkspaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTSiteWise.Model.CreateDatasetExportJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DestinationS3Uri != null)
            {
                request.DestinationS3Uri = cmdletContext.DestinationS3Uri;
            }
            
             // populate ErrorReportLocation
            var requestErrorReportLocationIsNull = true;
            request.ErrorReportLocation = new Amazon.IoTSiteWise.Model.ExportErrorReportLocation();
            System.String requestErrorReportLocation_errorReportLocation_S3Uri = null;
            if (cmdletContext.ErrorReportLocation_S3Uri != null)
            {
                requestErrorReportLocation_errorReportLocation_S3Uri = cmdletContext.ErrorReportLocation_S3Uri;
            }
            if (requestErrorReportLocation_errorReportLocation_S3Uri != null)
            {
                request.ErrorReportLocation.S3Uri = requestErrorReportLocation_errorReportLocation_S3Uri;
                requestErrorReportLocationIsNull = false;
            }
             // determine if request.ErrorReportLocation should be set to null
            if (requestErrorReportLocationIsNull)
            {
                request.ErrorReportLocation = null;
            }
            
             // populate Input
            var requestInputIsNull = true;
            request.Input = new Amazon.IoTSiteWise.Model.ProcessingInput();
            List<Amazon.IoTSiteWise.Model.TimeseriesItem> requestInput_input_Timesery = null;
            if (cmdletContext.Input_Timesery != null)
            {
                requestInput_input_Timesery = cmdletContext.Input_Timesery;
            }
            if (requestInput_input_Timesery != null)
            {
                request.Input.Timeseries = requestInput_input_Timesery;
                requestInputIsNull = false;
            }
            Amazon.IoTSiteWise.Model.DatasetItem requestInput_input_Dataset = null;
            
             // populate Dataset
            var requestInput_input_DatasetIsNull = true;
            requestInput_input_Dataset = new Amazon.IoTSiteWise.Model.DatasetItem();
            System.String requestInput_input_Dataset_input_Dataset_DatasetId = null;
            if (cmdletContext.Input_Dataset_DatasetId != null)
            {
                requestInput_input_Dataset_input_Dataset_DatasetId = cmdletContext.Input_Dataset_DatasetId;
            }
            if (requestInput_input_Dataset_input_Dataset_DatasetId != null)
            {
                requestInput_input_Dataset.DatasetId = requestInput_input_Dataset_input_Dataset_DatasetId;
                requestInput_input_DatasetIsNull = false;
            }
            List<System.String> requestInput_input_Dataset_input_Dataset_ExportDataType = null;
            if (cmdletContext.Input_Dataset_ExportDataType != null)
            {
                requestInput_input_Dataset_input_Dataset_ExportDataType = cmdletContext.Input_Dataset_ExportDataType;
            }
            if (requestInput_input_Dataset_input_Dataset_ExportDataType != null)
            {
                requestInput_input_Dataset.ExportDataTypes = requestInput_input_Dataset_input_Dataset_ExportDataType;
                requestInput_input_DatasetIsNull = false;
            }
            Amazon.IoTSiteWise.Model.TrimSettings requestInput_input_Dataset_input_Dataset_TrimSettings = null;
            
             // populate TrimSettings
            var requestInput_input_Dataset_input_Dataset_TrimSettingsIsNull = true;
            requestInput_input_Dataset_input_Dataset_TrimSettings = new Amazon.IoTSiteWise.Model.TrimSettings();
            Amazon.IoTSiteWise.Model.TimeInNanos requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime = null;
            
             // populate EndTime
            var requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTimeIsNull = true;
            requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime = new Amazon.IoTSiteWise.Model.TimeInNanos();
            System.Int32? requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime_input_Dataset_TrimSettings_EndTime_OffsetInNano = null;
            if (cmdletContext.Input_Dataset_TrimSettings_EndTime_OffsetInNano != null)
            {
                requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime_input_Dataset_TrimSettings_EndTime_OffsetInNano = cmdletContext.Input_Dataset_TrimSettings_EndTime_OffsetInNano.Value;
            }
            if (requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime_input_Dataset_TrimSettings_EndTime_OffsetInNano != null)
            {
                requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime.OffsetInNanos = requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime_input_Dataset_TrimSettings_EndTime_OffsetInNano.Value;
                requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTimeIsNull = false;
            }
            System.Int64? requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime_input_Dataset_TrimSettings_EndTime_TimeInSecond = null;
            if (cmdletContext.Input_Dataset_TrimSettings_EndTime_TimeInSecond != null)
            {
                requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime_input_Dataset_TrimSettings_EndTime_TimeInSecond = cmdletContext.Input_Dataset_TrimSettings_EndTime_TimeInSecond.Value;
            }
            if (requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime_input_Dataset_TrimSettings_EndTime_TimeInSecond != null)
            {
                requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime.TimeInSeconds = requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime_input_Dataset_TrimSettings_EndTime_TimeInSecond.Value;
                requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTimeIsNull = false;
            }
             // determine if requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime should be set to null
            if (requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTimeIsNull)
            {
                requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime = null;
            }
            if (requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime != null)
            {
                requestInput_input_Dataset_input_Dataset_TrimSettings.EndTime = requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_EndTime;
                requestInput_input_Dataset_input_Dataset_TrimSettingsIsNull = false;
            }
            Amazon.IoTSiteWise.Model.TimeInNanos requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime = null;
            
             // populate StartTime
            var requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTimeIsNull = true;
            requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime = new Amazon.IoTSiteWise.Model.TimeInNanos();
            System.Int32? requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime_input_Dataset_TrimSettings_StartTime_OffsetInNano = null;
            if (cmdletContext.Input_Dataset_TrimSettings_StartTime_OffsetInNano != null)
            {
                requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime_input_Dataset_TrimSettings_StartTime_OffsetInNano = cmdletContext.Input_Dataset_TrimSettings_StartTime_OffsetInNano.Value;
            }
            if (requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime_input_Dataset_TrimSettings_StartTime_OffsetInNano != null)
            {
                requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime.OffsetInNanos = requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime_input_Dataset_TrimSettings_StartTime_OffsetInNano.Value;
                requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTimeIsNull = false;
            }
            System.Int64? requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime_input_Dataset_TrimSettings_StartTime_TimeInSecond = null;
            if (cmdletContext.Input_Dataset_TrimSettings_StartTime_TimeInSecond != null)
            {
                requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime_input_Dataset_TrimSettings_StartTime_TimeInSecond = cmdletContext.Input_Dataset_TrimSettings_StartTime_TimeInSecond.Value;
            }
            if (requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime_input_Dataset_TrimSettings_StartTime_TimeInSecond != null)
            {
                requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime.TimeInSeconds = requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime_input_Dataset_TrimSettings_StartTime_TimeInSecond.Value;
                requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTimeIsNull = false;
            }
             // determine if requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime should be set to null
            if (requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTimeIsNull)
            {
                requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime = null;
            }
            if (requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime != null)
            {
                requestInput_input_Dataset_input_Dataset_TrimSettings.StartTime = requestInput_input_Dataset_input_Dataset_TrimSettings_input_Dataset_TrimSettings_StartTime;
                requestInput_input_Dataset_input_Dataset_TrimSettingsIsNull = false;
            }
             // determine if requestInput_input_Dataset_input_Dataset_TrimSettings should be set to null
            if (requestInput_input_Dataset_input_Dataset_TrimSettingsIsNull)
            {
                requestInput_input_Dataset_input_Dataset_TrimSettings = null;
            }
            if (requestInput_input_Dataset_input_Dataset_TrimSettings != null)
            {
                requestInput_input_Dataset.TrimSettings = requestInput_input_Dataset_input_Dataset_TrimSettings;
                requestInput_input_DatasetIsNull = false;
            }
             // determine if requestInput_input_Dataset should be set to null
            if (requestInput_input_DatasetIsNull)
            {
                requestInput_input_Dataset = null;
            }
            if (requestInput_input_Dataset != null)
            {
                request.Input.Dataset = requestInput_input_Dataset;
                requestInputIsNull = false;
            }
             // determine if request.Input should be set to null
            if (requestInputIsNull)
            {
                request.Input = null;
            }
            if (cmdletContext.WorkspaceName != null)
            {
                request.WorkspaceName = cmdletContext.WorkspaceName;
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
        
        private Amazon.IoTSiteWise.Model.CreateDatasetExportJobResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.CreateDatasetExportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "CreateDatasetExportJob");
            try
            {
                return client.CreateDatasetExportJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DestinationS3Uri { get; set; }
            public System.String ErrorReportLocation_S3Uri { get; set; }
            public System.String Input_Dataset_DatasetId { get; set; }
            public List<System.String> Input_Dataset_ExportDataType { get; set; }
            public System.Int32? Input_Dataset_TrimSettings_EndTime_OffsetInNano { get; set; }
            public System.Int64? Input_Dataset_TrimSettings_EndTime_TimeInSecond { get; set; }
            public System.Int32? Input_Dataset_TrimSettings_StartTime_OffsetInNano { get; set; }
            public System.Int64? Input_Dataset_TrimSettings_StartTime_TimeInSecond { get; set; }
            public List<Amazon.IoTSiteWise.Model.TimeseriesItem> Input_Timesery { get; set; }
            public System.String WorkspaceName { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.CreateDatasetExportJobResponse, NewIOTSWDatasetExportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
