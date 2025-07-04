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
using Amazon.LookoutMetrics;
using Amazon.LookoutMetrics.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LOM
{
    /// <summary>
    /// Get feedback for an anomaly group.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "LOMFeedback")]
    [OutputType("Amazon.LookoutMetrics.Model.TimeSeriesFeedback")]
    [AWSCmdlet("Calls the Amazon Lookout for Metrics GetFeedback API operation.", Operation = new[] {"GetFeedback"}, SelectReturnType = typeof(Amazon.LookoutMetrics.Model.GetFeedbackResponse))]
    [AWSCmdletOutput("Amazon.LookoutMetrics.Model.TimeSeriesFeedback or Amazon.LookoutMetrics.Model.GetFeedbackResponse",
        "This cmdlet returns a collection of Amazon.LookoutMetrics.Model.TimeSeriesFeedback objects.",
        "The service call response (type Amazon.LookoutMetrics.Model.GetFeedbackResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLOMFeedbackCmdlet : AmazonLookoutMetricsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnomalyDetectorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the anomaly detector.</para>
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
        public System.String AnomalyDetectorArn { get; set; }
        #endregion
        
        #region Parameter AnomalyGroupTimeSeriesFeedback_AnomalyGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the anomaly group.</para>
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
        public System.String AnomalyGroupTimeSeriesFeedback_AnomalyGroupId { get; set; }
        #endregion
        
        #region Parameter AnomalyGroupTimeSeriesFeedback_TimeSeriesId
        /// <summary>
        /// <para>
        /// <para>The ID of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnomalyGroupTimeSeriesFeedback_TimeSeriesId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Specify the pagination token that's returned by a previous request to retrieve the
        /// next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnomalyGroupTimeSeriesFeedback'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutMetrics.Model.GetFeedbackResponse).
        /// Specifying the name of a property of type Amazon.LookoutMetrics.Model.GetFeedbackResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnomalyGroupTimeSeriesFeedback";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
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
                context.Select = CreateSelectDelegate<Amazon.LookoutMetrics.Model.GetFeedbackResponse, GetLOMFeedbackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnomalyDetectorArn = this.AnomalyDetectorArn;
            #if MODULAR
            if (this.AnomalyDetectorArn == null && ParameterWasBound(nameof(this.AnomalyDetectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyDetectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnomalyGroupTimeSeriesFeedback_AnomalyGroupId = this.AnomalyGroupTimeSeriesFeedback_AnomalyGroupId;
            #if MODULAR
            if (this.AnomalyGroupTimeSeriesFeedback_AnomalyGroupId == null && ParameterWasBound(nameof(this.AnomalyGroupTimeSeriesFeedback_AnomalyGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyGroupTimeSeriesFeedback_AnomalyGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnomalyGroupTimeSeriesFeedback_TimeSeriesId = this.AnomalyGroupTimeSeriesFeedback_TimeSeriesId;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.LookoutMetrics.Model.GetFeedbackRequest();
            
            if (cmdletContext.AnomalyDetectorArn != null)
            {
                request.AnomalyDetectorArn = cmdletContext.AnomalyDetectorArn;
            }
            
             // populate AnomalyGroupTimeSeriesFeedback
            var requestAnomalyGroupTimeSeriesFeedbackIsNull = true;
            request.AnomalyGroupTimeSeriesFeedback = new Amazon.LookoutMetrics.Model.AnomalyGroupTimeSeries();
            System.String requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_AnomalyGroupId = null;
            if (cmdletContext.AnomalyGroupTimeSeriesFeedback_AnomalyGroupId != null)
            {
                requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_AnomalyGroupId = cmdletContext.AnomalyGroupTimeSeriesFeedback_AnomalyGroupId;
            }
            if (requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_AnomalyGroupId != null)
            {
                request.AnomalyGroupTimeSeriesFeedback.AnomalyGroupId = requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_AnomalyGroupId;
                requestAnomalyGroupTimeSeriesFeedbackIsNull = false;
            }
            System.String requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_TimeSeriesId = null;
            if (cmdletContext.AnomalyGroupTimeSeriesFeedback_TimeSeriesId != null)
            {
                requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_TimeSeriesId = cmdletContext.AnomalyGroupTimeSeriesFeedback_TimeSeriesId;
            }
            if (requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_TimeSeriesId != null)
            {
                request.AnomalyGroupTimeSeriesFeedback.TimeSeriesId = requestAnomalyGroupTimeSeriesFeedback_anomalyGroupTimeSeriesFeedback_TimeSeriesId;
                requestAnomalyGroupTimeSeriesFeedbackIsNull = false;
            }
             // determine if request.AnomalyGroupTimeSeriesFeedback should be set to null
            if (requestAnomalyGroupTimeSeriesFeedbackIsNull)
            {
                request.AnomalyGroupTimeSeriesFeedback = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
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
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.LookoutMetrics.Model.GetFeedbackResponse CallAWSServiceOperation(IAmazonLookoutMetrics client, Amazon.LookoutMetrics.Model.GetFeedbackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Metrics", "GetFeedback");
            try
            {
                return client.GetFeedbackAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AnomalyDetectorArn { get; set; }
            public System.String AnomalyGroupTimeSeriesFeedback_AnomalyGroupId { get; set; }
            public System.String AnomalyGroupTimeSeriesFeedback_TimeSeriesId { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.LookoutMetrics.Model.GetFeedbackResponse, GetLOMFeedbackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnomalyGroupTimeSeriesFeedback;
        }
        
    }
}
