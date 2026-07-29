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
    /// Creates an asynchronous enrichment job to analyze time-series sensor data. The operation
    /// returns immediately with job details while processing continues in the background.
    /// 
    ///  <h2>Idempotency</h2><para>
    /// Include a clientToken to make the operation idempotent. If you submit the same request
    /// with the same token within the idempotency window, you receive the original job details
    /// without creating a duplicate.
    /// </para><h2>Prerequisites</h2><para>
    /// Before creating a job, ensure:
    /// </para><ul><li>The workspace is in ACTIVE state (not being deleted)</li><li>You have IAM
    /// permissions for the workspace, dataset, and time-series resources</li><li>You have
    /// KMS Decrypt permission on the workspace's customer-managed encryption key</li><li>No
    /// duplicate job (same workspace, dataset, property, and job type) is currently running</li></ul><h2>Workflow</h2><ol><li>Submit the job with configuration specifying which
    /// video data to analyze and the time range</li><li>Capture the jobId from the response</li><li>Use DescribeEnrichmentJob to monitor progress and check job status</li><li>When
    /// status reaches a terminal state (COMPLETED, FAILED, TIMED_OUT, CANCELLED), check results</li><li>For COMPLETED jobs, query IoT SiteWise for semantic search on video events</li></ol><h2>Error Handling</h2><ul><li>ConflictingOperationException: A duplicate
    /// job is already running for the same configuration</li><li>InvalidRequestException:
    /// Invalid parameters (e.g., both timeSeriesId and propertyAlias specified)</li><li>AccessDeniedException:
    /// Insufficient IAM or KMS permissions</li><li>LimitExceededException: Too many concurrent
    /// jobs or requests</li></ul>
    /// </summary>
    [Cmdlet("New", "IOTSWEnrichmentJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.CreateEnrichmentJobResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise CreateEnrichmentJob API operation.", Operation = new[] {"CreateEnrichmentJob"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.CreateEnrichmentJobResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.CreateEnrichmentJobResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.CreateEnrichmentJobResponse object containing multiple properties."
    )]
    public partial class NewIOTSWEnrichmentJobCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter JobConfiguration_EventDetection_DatasetId
        /// <summary>
        /// <para>
        /// &lt;p&gt;The IoT SiteWise dataset ID containing
        /// the video time-series data to analyze. Query IoT SiteWise to discover available datasets
        /// in your workspace.&lt;/p&gt;
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobConfiguration_EventDetection_DatasetId { get; set; }
        #endregion
        
        #region Parameter JobConfiguration_EventDetection_TrimSettings_EndTime_OffsetInNano
        /// <summary>
        /// <para>
        /// <para>The nanosecond offset from <c>timeInSeconds</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfiguration_EventDetection_TrimSettings_EndTime_OffsetInNanos")]
        public System.Int32? JobConfiguration_EventDetection_TrimSettings_EndTime_OffsetInNano { get; set; }
        #endregion
        
        #region Parameter JobConfiguration_EventDetection_TrimSettings_StartTime_OffsetInNano
        /// <summary>
        /// <para>
        /// <para>The nanosecond offset from <c>timeInSeconds</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfiguration_EventDetection_TrimSettings_StartTime_OffsetInNanos")]
        public System.Int32? JobConfiguration_EventDetection_TrimSettings_StartTime_OffsetInNano { get; set; }
        #endregion
        
        #region Parameter JobConfiguration_EventDetection_PropertyAlias
        /// <summary>
        /// <para>
        /// &lt;p&gt;Human-readable alias for the video
        /// time series to analyze (e.g., /camera/warehouse/zone-a). Specify either propertyAlias
        /// or timeSeriesId, but not both. Use this when you have configured friendly aliases
        /// in IoT SiteWise for better readability.&lt;/p&gt;
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobConfiguration_EventDetection_PropertyAlias { get; set; }
        #endregion
        
        #region Parameter JobConfiguration_EventDetection_TrimSettings_EndTime_TimeInSecond
        /// <summary>
        /// <para>
        /// <para>The timestamp date, in seconds, in the Unix epoch format. Fractional nanosecond data
        /// is provided by <c>offsetInNanos</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfiguration_EventDetection_TrimSettings_EndTime_TimeInSeconds")]
        public System.Int64? JobConfiguration_EventDetection_TrimSettings_EndTime_TimeInSecond { get; set; }
        #endregion
        
        #region Parameter JobConfiguration_EventDetection_TrimSettings_StartTime_TimeInSecond
        /// <summary>
        /// <para>
        /// <para>The timestamp date, in seconds, in the Unix epoch format. Fractional nanosecond data
        /// is provided by <c>offsetInNanos</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfiguration_EventDetection_TrimSettings_StartTime_TimeInSeconds")]
        public System.Int64? JobConfiguration_EventDetection_TrimSettings_StartTime_TimeInSecond { get; set; }
        #endregion
        
        #region Parameter JobConfiguration_EventDetection_TimeSeriesId
        /// <summary>
        /// <para>
        /// &lt;p&gt;Unique system identifier for the
        /// video time series to analyze. Specify either timeSeriesId or propertyAlias, but not
        /// both. Use this when you have the system-generated time series identifier from IoT
        /// SiteWise.&lt;/p&gt;
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobConfiguration_EventDetection_TimeSeriesId { get; set; }
        #endregion
        
        #region Parameter WorkspaceName
        /// <summary>
        /// <para>
        /// <para>The name of the IoT SiteWise workspace containing the video data to analyze.</para>
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
        public System.String WorkspaceName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Optional unique token that makes the operation idempotent. If you submit the same
        /// request with the same token within the idempotency window, the service returns the
        /// original job without creating a duplicate. Use a UUID or timestamp-based token for
        /// each unique request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.CreateEnrichmentJobResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.CreateEnrichmentJobResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTSWEnrichmentJob (CreateEnrichmentJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.CreateEnrichmentJobResponse, NewIOTSWEnrichmentJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.JobConfiguration_EventDetection_DatasetId = this.JobConfiguration_EventDetection_DatasetId;
            context.JobConfiguration_EventDetection_PropertyAlias = this.JobConfiguration_EventDetection_PropertyAlias;
            context.JobConfiguration_EventDetection_TimeSeriesId = this.JobConfiguration_EventDetection_TimeSeriesId;
            context.JobConfiguration_EventDetection_TrimSettings_EndTime_OffsetInNano = this.JobConfiguration_EventDetection_TrimSettings_EndTime_OffsetInNano;
            context.JobConfiguration_EventDetection_TrimSettings_EndTime_TimeInSecond = this.JobConfiguration_EventDetection_TrimSettings_EndTime_TimeInSecond;
            context.JobConfiguration_EventDetection_TrimSettings_StartTime_OffsetInNano = this.JobConfiguration_EventDetection_TrimSettings_StartTime_OffsetInNano;
            context.JobConfiguration_EventDetection_TrimSettings_StartTime_TimeInSecond = this.JobConfiguration_EventDetection_TrimSettings_StartTime_TimeInSecond;
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
            var request = new Amazon.IoTSiteWise.Model.CreateEnrichmentJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate JobConfiguration
            var requestJobConfigurationIsNull = true;
            request.JobConfiguration = new Amazon.IoTSiteWise.Model.EnrichmentJobConfiguration();
            Amazon.IoTSiteWise.Model.EventDetection requestJobConfiguration_jobConfiguration_EventDetection = null;
            
             // populate EventDetection
            var requestJobConfiguration_jobConfiguration_EventDetectionIsNull = true;
            requestJobConfiguration_jobConfiguration_EventDetection = new Amazon.IoTSiteWise.Model.EventDetection();
            System.String requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_DatasetId = null;
            if (cmdletContext.JobConfiguration_EventDetection_DatasetId != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_DatasetId = cmdletContext.JobConfiguration_EventDetection_DatasetId;
            }
            if (requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_DatasetId != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection.DatasetId = requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_DatasetId;
                requestJobConfiguration_jobConfiguration_EventDetectionIsNull = false;
            }
            System.String requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_PropertyAlias = null;
            if (cmdletContext.JobConfiguration_EventDetection_PropertyAlias != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_PropertyAlias = cmdletContext.JobConfiguration_EventDetection_PropertyAlias;
            }
            if (requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_PropertyAlias != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection.PropertyAlias = requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_PropertyAlias;
                requestJobConfiguration_jobConfiguration_EventDetectionIsNull = false;
            }
            System.String requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TimeSeriesId = null;
            if (cmdletContext.JobConfiguration_EventDetection_TimeSeriesId != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TimeSeriesId = cmdletContext.JobConfiguration_EventDetection_TimeSeriesId;
            }
            if (requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TimeSeriesId != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection.TimeSeriesId = requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TimeSeriesId;
                requestJobConfiguration_jobConfiguration_EventDetectionIsNull = false;
            }
            Amazon.IoTSiteWise.Model.EnrichmentTrimSettings requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings = null;
            
             // populate TrimSettings
            var requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettingsIsNull = true;
            requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings = new Amazon.IoTSiteWise.Model.EnrichmentTrimSettings();
            Amazon.IoTSiteWise.Model.TimeInNanos requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime = null;
            
             // populate EndTime
            var requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTimeIsNull = true;
            requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime = new Amazon.IoTSiteWise.Model.TimeInNanos();
            System.Int32? requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime_jobConfiguration_EventDetection_TrimSettings_EndTime_OffsetInNano = null;
            if (cmdletContext.JobConfiguration_EventDetection_TrimSettings_EndTime_OffsetInNano != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime_jobConfiguration_EventDetection_TrimSettings_EndTime_OffsetInNano = cmdletContext.JobConfiguration_EventDetection_TrimSettings_EndTime_OffsetInNano.Value;
            }
            if (requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime_jobConfiguration_EventDetection_TrimSettings_EndTime_OffsetInNano != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime.OffsetInNanos = requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime_jobConfiguration_EventDetection_TrimSettings_EndTime_OffsetInNano.Value;
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTimeIsNull = false;
            }
            System.Int64? requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime_jobConfiguration_EventDetection_TrimSettings_EndTime_TimeInSecond = null;
            if (cmdletContext.JobConfiguration_EventDetection_TrimSettings_EndTime_TimeInSecond != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime_jobConfiguration_EventDetection_TrimSettings_EndTime_TimeInSecond = cmdletContext.JobConfiguration_EventDetection_TrimSettings_EndTime_TimeInSecond.Value;
            }
            if (requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime_jobConfiguration_EventDetection_TrimSettings_EndTime_TimeInSecond != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime.TimeInSeconds = requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime_jobConfiguration_EventDetection_TrimSettings_EndTime_TimeInSecond.Value;
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTimeIsNull = false;
            }
             // determine if requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime should be set to null
            if (requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTimeIsNull)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime = null;
            }
            if (requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings.EndTime = requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_EndTime;
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettingsIsNull = false;
            }
            Amazon.IoTSiteWise.Model.TimeInNanos requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime = null;
            
             // populate StartTime
            var requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTimeIsNull = true;
            requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime = new Amazon.IoTSiteWise.Model.TimeInNanos();
            System.Int32? requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime_jobConfiguration_EventDetection_TrimSettings_StartTime_OffsetInNano = null;
            if (cmdletContext.JobConfiguration_EventDetection_TrimSettings_StartTime_OffsetInNano != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime_jobConfiguration_EventDetection_TrimSettings_StartTime_OffsetInNano = cmdletContext.JobConfiguration_EventDetection_TrimSettings_StartTime_OffsetInNano.Value;
            }
            if (requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime_jobConfiguration_EventDetection_TrimSettings_StartTime_OffsetInNano != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime.OffsetInNanos = requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime_jobConfiguration_EventDetection_TrimSettings_StartTime_OffsetInNano.Value;
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTimeIsNull = false;
            }
            System.Int64? requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime_jobConfiguration_EventDetection_TrimSettings_StartTime_TimeInSecond = null;
            if (cmdletContext.JobConfiguration_EventDetection_TrimSettings_StartTime_TimeInSecond != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime_jobConfiguration_EventDetection_TrimSettings_StartTime_TimeInSecond = cmdletContext.JobConfiguration_EventDetection_TrimSettings_StartTime_TimeInSecond.Value;
            }
            if (requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime_jobConfiguration_EventDetection_TrimSettings_StartTime_TimeInSecond != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime.TimeInSeconds = requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime_jobConfiguration_EventDetection_TrimSettings_StartTime_TimeInSecond.Value;
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTimeIsNull = false;
            }
             // determine if requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime should be set to null
            if (requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTimeIsNull)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime = null;
            }
            if (requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings.StartTime = requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings_jobConfiguration_EventDetection_TrimSettings_StartTime;
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettingsIsNull = false;
            }
             // determine if requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings should be set to null
            if (requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettingsIsNull)
            {
                requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings = null;
            }
            if (requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings != null)
            {
                requestJobConfiguration_jobConfiguration_EventDetection.TrimSettings = requestJobConfiguration_jobConfiguration_EventDetection_jobConfiguration_EventDetection_TrimSettings;
                requestJobConfiguration_jobConfiguration_EventDetectionIsNull = false;
            }
             // determine if requestJobConfiguration_jobConfiguration_EventDetection should be set to null
            if (requestJobConfiguration_jobConfiguration_EventDetectionIsNull)
            {
                requestJobConfiguration_jobConfiguration_EventDetection = null;
            }
            if (requestJobConfiguration_jobConfiguration_EventDetection != null)
            {
                request.JobConfiguration.EventDetection = requestJobConfiguration_jobConfiguration_EventDetection;
                requestJobConfigurationIsNull = false;
            }
             // determine if request.JobConfiguration should be set to null
            if (requestJobConfigurationIsNull)
            {
                request.JobConfiguration = null;
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
        
        private Amazon.IoTSiteWise.Model.CreateEnrichmentJobResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.CreateEnrichmentJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "CreateEnrichmentJob");
            try
            {
                return client.CreateEnrichmentJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String JobConfiguration_EventDetection_DatasetId { get; set; }
            public System.String JobConfiguration_EventDetection_PropertyAlias { get; set; }
            public System.String JobConfiguration_EventDetection_TimeSeriesId { get; set; }
            public System.Int32? JobConfiguration_EventDetection_TrimSettings_EndTime_OffsetInNano { get; set; }
            public System.Int64? JobConfiguration_EventDetection_TrimSettings_EndTime_TimeInSecond { get; set; }
            public System.Int32? JobConfiguration_EventDetection_TrimSettings_StartTime_OffsetInNano { get; set; }
            public System.Int64? JobConfiguration_EventDetection_TrimSettings_StartTime_TimeInSecond { get; set; }
            public System.String WorkspaceName { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.CreateEnrichmentJobResponse, NewIOTSWEnrichmentJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
