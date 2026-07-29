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
    /// Retrieves video data for a specific time range.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "IOTSWCaptureData")]
    [OutputType("Amazon.IoTSiteWise.Model.GetCaptureDataResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise GetCaptureData API operation.", Operation = new[] {"GetCaptureData"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.GetCaptureDataResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.GetCaptureDataResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.GetCaptureDataResponse object containing multiple properties."
    )]
    public partial class GetIOTSWCaptureDataCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FormatSettings_FramesPerSecond
        /// <summary>
        /// <para>
        /// &lt;p&gt;The target frame rate for the
        /// output.&lt;/p&gt;
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? FormatSettings_FramesPerSecond { get; set; }
        #endregion
        
        #region Parameter FormatSettings_HeightInPixel
        /// <summary>
        /// <para>
        /// &lt;p&gt;The target height of the output,
        /// in pixels.&lt;/p&gt;
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormatSettings_HeightInPixels")]
        public System.Int32? FormatSettings_HeightInPixel { get; set; }
        #endregion
        
        #region Parameter EndTime_OffsetInNano
        /// <summary>
        /// <para>
        /// <para>The nanosecond offset from <c>timeInSeconds</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndTime_OffsetInNanos")]
        public System.Int32? EndTime_OffsetInNano { get; set; }
        #endregion
        
        #region Parameter StartTime_OffsetInNano
        /// <summary>
        /// <para>
        /// <para>The nanosecond offset from <c>timeInSeconds</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StartTime_OffsetInNanos")]
        public System.Int32? StartTime_OffsetInNano { get; set; }
        #endregion
        
        #region Parameter PropertyAlias
        /// <summary>
        /// <para>
        /// <para>The property alias that identifies the capture source. Mutually exclusive with timeSeriesId.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PropertyAlias { get; set; }
        #endregion
        
        #region Parameter EndTime_TimeInSecond
        /// <summary>
        /// <para>
        /// <para>The timestamp date, in seconds, in the Unix epoch format. Fractional nanosecond data
        /// is provided by <c>offsetInNanos</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("EndTime_TimeInSeconds")]
        public System.Int64? EndTime_TimeInSecond { get; set; }
        #endregion
        
        #region Parameter StartTime_TimeInSecond
        /// <summary>
        /// <para>
        /// <para>The timestamp date, in seconds, in the Unix epoch format. Fractional nanosecond data
        /// is provided by <c>offsetInNanos</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("StartTime_TimeInSeconds")]
        public System.Int64? StartTime_TimeInSecond { get; set; }
        #endregion
        
        #region Parameter TimeSeriesId
        /// <summary>
        /// <para>
        /// <para>The time series ID that identifies the capture source. Mutually exclusive with propertyAlias.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TimeSeriesId { get; set; }
        #endregion
        
        #region Parameter FormatSettings_WidthInPixel
        /// <summary>
        /// <para>
        /// &lt;p&gt;The target width of the output,
        /// in pixels.&lt;/p&gt;
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormatSettings_WidthInPixels")]
        public System.Int32? FormatSettings_WidthInPixel { get; set; }
        #endregion
        
        #region Parameter WorkspaceName
        /// <summary>
        /// <para>
        /// <para>The name of the workspace that contains the capture source.</para>
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
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token from a previous response used to continue retrieving data.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.GetCaptureDataResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.GetCaptureDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.GetCaptureDataResponse, GetIOTSWCaptureDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime_OffsetInNano = this.EndTime_OffsetInNano;
            context.EndTime_TimeInSecond = this.EndTime_TimeInSecond;
            #if MODULAR
            if (this.EndTime_TimeInSecond == null && ParameterWasBound(nameof(this.EndTime_TimeInSecond)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime_TimeInSecond which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FormatSettings_FramesPerSecond = this.FormatSettings_FramesPerSecond;
            context.FormatSettings_HeightInPixel = this.FormatSettings_HeightInPixel;
            context.FormatSettings_WidthInPixel = this.FormatSettings_WidthInPixel;
            context.NextToken = this.NextToken;
            context.PropertyAlias = this.PropertyAlias;
            context.StartTime_OffsetInNano = this.StartTime_OffsetInNano;
            context.StartTime_TimeInSecond = this.StartTime_TimeInSecond;
            #if MODULAR
            if (this.StartTime_TimeInSecond == null && ParameterWasBound(nameof(this.StartTime_TimeInSecond)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTime_TimeInSecond which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeSeriesId = this.TimeSeriesId;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.IoTSiteWise.Model.GetCaptureDataRequest();
            
            
             // populate EndTime
            var requestEndTimeIsNull = true;
            request.EndTime = new Amazon.IoTSiteWise.Model.TimeInNanos();
            System.Int32? requestEndTime_endTime_OffsetInNano = null;
            if (cmdletContext.EndTime_OffsetInNano != null)
            {
                requestEndTime_endTime_OffsetInNano = cmdletContext.EndTime_OffsetInNano.Value;
            }
            if (requestEndTime_endTime_OffsetInNano != null)
            {
                request.EndTime.OffsetInNanos = requestEndTime_endTime_OffsetInNano.Value;
                requestEndTimeIsNull = false;
            }
            System.Int64? requestEndTime_endTime_TimeInSecond = null;
            if (cmdletContext.EndTime_TimeInSecond != null)
            {
                requestEndTime_endTime_TimeInSecond = cmdletContext.EndTime_TimeInSecond.Value;
            }
            if (requestEndTime_endTime_TimeInSecond != null)
            {
                request.EndTime.TimeInSeconds = requestEndTime_endTime_TimeInSecond.Value;
                requestEndTimeIsNull = false;
            }
             // determine if request.EndTime should be set to null
            if (requestEndTimeIsNull)
            {
                request.EndTime = null;
            }
            
             // populate FormatSettings
            var requestFormatSettingsIsNull = true;
            request.FormatSettings = new Amazon.IoTSiteWise.Model.FormatSettings();
            System.Int32? requestFormatSettings_formatSettings_FramesPerSecond = null;
            if (cmdletContext.FormatSettings_FramesPerSecond != null)
            {
                requestFormatSettings_formatSettings_FramesPerSecond = cmdletContext.FormatSettings_FramesPerSecond.Value;
            }
            if (requestFormatSettings_formatSettings_FramesPerSecond != null)
            {
                request.FormatSettings.FramesPerSecond = requestFormatSettings_formatSettings_FramesPerSecond.Value;
                requestFormatSettingsIsNull = false;
            }
            System.Int32? requestFormatSettings_formatSettings_HeightInPixel = null;
            if (cmdletContext.FormatSettings_HeightInPixel != null)
            {
                requestFormatSettings_formatSettings_HeightInPixel = cmdletContext.FormatSettings_HeightInPixel.Value;
            }
            if (requestFormatSettings_formatSettings_HeightInPixel != null)
            {
                request.FormatSettings.HeightInPixels = requestFormatSettings_formatSettings_HeightInPixel.Value;
                requestFormatSettingsIsNull = false;
            }
            System.Int32? requestFormatSettings_formatSettings_WidthInPixel = null;
            if (cmdletContext.FormatSettings_WidthInPixel != null)
            {
                requestFormatSettings_formatSettings_WidthInPixel = cmdletContext.FormatSettings_WidthInPixel.Value;
            }
            if (requestFormatSettings_formatSettings_WidthInPixel != null)
            {
                request.FormatSettings.WidthInPixels = requestFormatSettings_formatSettings_WidthInPixel.Value;
                requestFormatSettingsIsNull = false;
            }
             // determine if request.FormatSettings should be set to null
            if (requestFormatSettingsIsNull)
            {
                request.FormatSettings = null;
            }
            if (cmdletContext.PropertyAlias != null)
            {
                request.PropertyAlias = cmdletContext.PropertyAlias;
            }
            
             // populate StartTime
            var requestStartTimeIsNull = true;
            request.StartTime = new Amazon.IoTSiteWise.Model.TimeInNanos();
            System.Int32? requestStartTime_startTime_OffsetInNano = null;
            if (cmdletContext.StartTime_OffsetInNano != null)
            {
                requestStartTime_startTime_OffsetInNano = cmdletContext.StartTime_OffsetInNano.Value;
            }
            if (requestStartTime_startTime_OffsetInNano != null)
            {
                request.StartTime.OffsetInNanos = requestStartTime_startTime_OffsetInNano.Value;
                requestStartTimeIsNull = false;
            }
            System.Int64? requestStartTime_startTime_TimeInSecond = null;
            if (cmdletContext.StartTime_TimeInSecond != null)
            {
                requestStartTime_startTime_TimeInSecond = cmdletContext.StartTime_TimeInSecond.Value;
            }
            if (requestStartTime_startTime_TimeInSecond != null)
            {
                request.StartTime.TimeInSeconds = requestStartTime_startTime_TimeInSecond.Value;
                requestStartTimeIsNull = false;
            }
             // determine if request.StartTime should be set to null
            if (requestStartTimeIsNull)
            {
                request.StartTime = null;
            }
            if (cmdletContext.TimeSeriesId != null)
            {
                request.TimeSeriesId = cmdletContext.TimeSeriesId;
            }
            if (cmdletContext.WorkspaceName != null)
            {
                request.WorkspaceName = cmdletContext.WorkspaceName;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.IoTSiteWise.Model.GetCaptureDataResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.GetCaptureDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "GetCaptureData");
            try
            {
                return client.GetCaptureDataAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? EndTime_OffsetInNano { get; set; }
            public System.Int64? EndTime_TimeInSecond { get; set; }
            public System.Int32? FormatSettings_FramesPerSecond { get; set; }
            public System.Int32? FormatSettings_HeightInPixel { get; set; }
            public System.Int32? FormatSettings_WidthInPixel { get; set; }
            public System.String NextToken { get; set; }
            public System.String PropertyAlias { get; set; }
            public System.Int32? StartTime_OffsetInNano { get; set; }
            public System.Int64? StartTime_TimeInSecond { get; set; }
            public System.String TimeSeriesId { get; set; }
            public System.String WorkspaceName { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.GetCaptureDataResponse, GetIOTSWCaptureDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
