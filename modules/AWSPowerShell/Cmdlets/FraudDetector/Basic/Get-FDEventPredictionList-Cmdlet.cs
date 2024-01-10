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
using Amazon.FraudDetector;
using Amazon.FraudDetector.Model;

namespace Amazon.PowerShell.Cmdlets.FD
{
    /// <summary>
    /// Gets a list of past predictions. The list can be filtered by detector ID, detector
    /// version ID, event ID, event type, or by specifying a time period. If filter is not
    /// specified, the most recent prediction is returned.
    /// 
    ///  
    /// <para>
    /// For example, the following filter lists all past predictions for <c>xyz</c> event
    /// type - <c>{ "eventType":{ "value": "xyz" }” } </c></para><para>
    /// This is a paginated API. If you provide a null <c>maxResults</c>, this action will
    /// retrieve a maximum of 10 records per page. If you provide a <c>maxResults</c>, the
    /// value must be between 50 and 100. To get the next page results, provide the <c>nextToken</c>
    /// from the response as part of your request. A null <c>nextToken</c> fetches the records
    /// from the beginning. 
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "FDEventPredictionList")]
    [OutputType("Amazon.FraudDetector.Model.EventPredictionSummary")]
    [AWSCmdlet("Calls the Amazon Fraud Detector ListEventPredictions API operation.", Operation = new[] {"ListEventPredictions"}, SelectReturnType = typeof(Amazon.FraudDetector.Model.ListEventPredictionsResponse))]
    [AWSCmdletOutput("Amazon.FraudDetector.Model.EventPredictionSummary or Amazon.FraudDetector.Model.ListEventPredictionsResponse",
        "This cmdlet returns a collection of Amazon.FraudDetector.Model.EventPredictionSummary objects.",
        "The service call response (type Amazon.FraudDetector.Model.ListEventPredictionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetFDEventPredictionListCmdlet : AmazonFraudDetectorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PredictionTimeRange_EndTime
        /// <summary>
        /// <para>
        /// <para> The end time of the time period for when the predictions were generated. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PredictionTimeRange_EndTime { get; set; }
        #endregion
        
        #region Parameter PredictionTimeRange_StartTime
        /// <summary>
        /// <para>
        /// <para> The start time of the time period for when the predictions were generated. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PredictionTimeRange_StartTime { get; set; }
        #endregion
        
        #region Parameter DetectorId_Value
        /// <summary>
        /// <para>
        /// <para> A statement containing a resource property and a value to specify filter condition.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DetectorId_Value { get; set; }
        #endregion
        
        #region Parameter DetectorVersionId_Value
        /// <summary>
        /// <para>
        /// <para> A statement containing a resource property and a value to specify filter condition.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DetectorVersionId_Value { get; set; }
        #endregion
        
        #region Parameter EventId_Value
        /// <summary>
        /// <para>
        /// <para> A statement containing a resource property and a value to specify filter condition.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventId_Value { get; set; }
        #endregion
        
        #region Parameter EventType_Value
        /// <summary>
        /// <para>
        /// <para> A statement containing a resource property and a value to specify filter condition.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventType_Value { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of predictions to return for the request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> Identifies the next page of results to return. Use the token to make the call again
        /// to retrieve the next page. Keep all other arguments unchanged. Each pagination token
        /// expires after 24 hours. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventPredictionSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FraudDetector.Model.ListEventPredictionsResponse).
        /// Specifying the name of a property of type Amazon.FraudDetector.Model.ListEventPredictionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventPredictionSummaries";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FraudDetector.Model.ListEventPredictionsResponse, GetFDEventPredictionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DetectorId_Value = this.DetectorId_Value;
            context.DetectorVersionId_Value = this.DetectorVersionId_Value;
            context.EventId_Value = this.EventId_Value;
            context.EventType_Value = this.EventType_Value;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.PredictionTimeRange_EndTime = this.PredictionTimeRange_EndTime;
            context.PredictionTimeRange_StartTime = this.PredictionTimeRange_StartTime;
            
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
            var request = new Amazon.FraudDetector.Model.ListEventPredictionsRequest();
            
            
             // populate DetectorId
            var requestDetectorIdIsNull = true;
            request.DetectorId = new Amazon.FraudDetector.Model.FilterCondition();
            System.String requestDetectorId_detectorId_Value = null;
            if (cmdletContext.DetectorId_Value != null)
            {
                requestDetectorId_detectorId_Value = cmdletContext.DetectorId_Value;
            }
            if (requestDetectorId_detectorId_Value != null)
            {
                request.DetectorId.Value = requestDetectorId_detectorId_Value;
                requestDetectorIdIsNull = false;
            }
             // determine if request.DetectorId should be set to null
            if (requestDetectorIdIsNull)
            {
                request.DetectorId = null;
            }
            
             // populate DetectorVersionId
            var requestDetectorVersionIdIsNull = true;
            request.DetectorVersionId = new Amazon.FraudDetector.Model.FilterCondition();
            System.String requestDetectorVersionId_detectorVersionId_Value = null;
            if (cmdletContext.DetectorVersionId_Value != null)
            {
                requestDetectorVersionId_detectorVersionId_Value = cmdletContext.DetectorVersionId_Value;
            }
            if (requestDetectorVersionId_detectorVersionId_Value != null)
            {
                request.DetectorVersionId.Value = requestDetectorVersionId_detectorVersionId_Value;
                requestDetectorVersionIdIsNull = false;
            }
             // determine if request.DetectorVersionId should be set to null
            if (requestDetectorVersionIdIsNull)
            {
                request.DetectorVersionId = null;
            }
            
             // populate EventId
            var requestEventIdIsNull = true;
            request.EventId = new Amazon.FraudDetector.Model.FilterCondition();
            System.String requestEventId_eventId_Value = null;
            if (cmdletContext.EventId_Value != null)
            {
                requestEventId_eventId_Value = cmdletContext.EventId_Value;
            }
            if (requestEventId_eventId_Value != null)
            {
                request.EventId.Value = requestEventId_eventId_Value;
                requestEventIdIsNull = false;
            }
             // determine if request.EventId should be set to null
            if (requestEventIdIsNull)
            {
                request.EventId = null;
            }
            
             // populate EventType
            var requestEventTypeIsNull = true;
            request.EventType = new Amazon.FraudDetector.Model.FilterCondition();
            System.String requestEventType_eventType_Value = null;
            if (cmdletContext.EventType_Value != null)
            {
                requestEventType_eventType_Value = cmdletContext.EventType_Value;
            }
            if (requestEventType_eventType_Value != null)
            {
                request.EventType.Value = requestEventType_eventType_Value;
                requestEventTypeIsNull = false;
            }
             // determine if request.EventType should be set to null
            if (requestEventTypeIsNull)
            {
                request.EventType = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate PredictionTimeRange
            var requestPredictionTimeRangeIsNull = true;
            request.PredictionTimeRange = new Amazon.FraudDetector.Model.PredictionTimeRange();
            System.String requestPredictionTimeRange_predictionTimeRange_EndTime = null;
            if (cmdletContext.PredictionTimeRange_EndTime != null)
            {
                requestPredictionTimeRange_predictionTimeRange_EndTime = cmdletContext.PredictionTimeRange_EndTime;
            }
            if (requestPredictionTimeRange_predictionTimeRange_EndTime != null)
            {
                request.PredictionTimeRange.EndTime = requestPredictionTimeRange_predictionTimeRange_EndTime;
                requestPredictionTimeRangeIsNull = false;
            }
            System.String requestPredictionTimeRange_predictionTimeRange_StartTime = null;
            if (cmdletContext.PredictionTimeRange_StartTime != null)
            {
                requestPredictionTimeRange_predictionTimeRange_StartTime = cmdletContext.PredictionTimeRange_StartTime;
            }
            if (requestPredictionTimeRange_predictionTimeRange_StartTime != null)
            {
                request.PredictionTimeRange.StartTime = requestPredictionTimeRange_predictionTimeRange_StartTime;
                requestPredictionTimeRangeIsNull = false;
            }
             // determine if request.PredictionTimeRange should be set to null
            if (requestPredictionTimeRangeIsNull)
            {
                request.PredictionTimeRange = null;
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
        
        private Amazon.FraudDetector.Model.ListEventPredictionsResponse CallAWSServiceOperation(IAmazonFraudDetector client, Amazon.FraudDetector.Model.ListEventPredictionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Fraud Detector", "ListEventPredictions");
            try
            {
                #if DESKTOP
                return client.ListEventPredictions(request);
                #elif CORECLR
                return client.ListEventPredictionsAsync(request).GetAwaiter().GetResult();
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
            public System.String DetectorId_Value { get; set; }
            public System.String DetectorVersionId_Value { get; set; }
            public System.String EventId_Value { get; set; }
            public System.String EventType_Value { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String PredictionTimeRange_EndTime { get; set; }
            public System.String PredictionTimeRange_StartTime { get; set; }
            public System.Func<Amazon.FraudDetector.Model.ListEventPredictionsResponse, GetFDEventPredictionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventPredictionSummaries;
        }
        
    }
}
