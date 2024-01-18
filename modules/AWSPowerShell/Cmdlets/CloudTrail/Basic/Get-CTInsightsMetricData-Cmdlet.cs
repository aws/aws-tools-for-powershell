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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Returns Insights metrics data for trails that have enabled Insights. The request must
    /// include the <c>EventSource</c>, <c>EventName</c>, and <c>InsightType</c> parameters.
    /// 
    ///  
    /// <para>
    /// If the <c>InsightType</c> is set to <c>ApiErrorRateInsight</c>, the request must also
    /// include the <c>ErrorCode</c> parameter.
    /// </para><para>
    /// The following are the available time periods for <c>ListInsightsMetricData</c>. Each
    /// cutoff is inclusive.
    /// </para><ul><li><para>
    /// Data points with a period of 60 seconds (1-minute) are available for 15 days.
    /// </para></li><li><para>
    /// Data points with a period of 300 seconds (5-minute) are available for 63 days.
    /// </para></li><li><para>
    /// Data points with a period of 3600 seconds (1 hour) are available for 90 days.
    /// </para></li></ul><para>
    /// Access to the <c>ListInsightsMetricData</c> API operation is linked to the <c>cloudtrail:LookupEvents</c>
    /// action. To use this operation, you must have permissions to perform the <c>cloudtrail:LookupEvents</c>
    /// action.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CTInsightsMetricData")]
    [OutputType("Amazon.CloudTrail.Model.ListInsightsMetricDataResponse")]
    [AWSCmdlet("Calls the AWS CloudTrail ListInsightsMetricData API operation.", Operation = new[] {"ListInsightsMetricData"}, SelectReturnType = typeof(Amazon.CloudTrail.Model.ListInsightsMetricDataResponse))]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.ListInsightsMetricDataResponse",
        "This cmdlet returns an Amazon.CloudTrail.Model.ListInsightsMetricDataResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCTInsightsMetricDataCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataType
        /// <summary>
        /// <para>
        /// <para>Type of datapoints to return. Valid values are <c>NonZeroData</c> and <c>FillWithZeros</c>.
        /// The default is <c>NonZeroData</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudTrail.InsightsMetricDataType")]
        public Amazon.CloudTrail.InsightsMetricDataType DataType { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>Specifies, in UTC, the end time for time-series data. The value specified is exclusive;
        /// results include data points up to the specified time stamp.</para><para>The default is the time of request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter ErrorCode
        /// <summary>
        /// <para>
        /// <para>Conditionally required if the <c>InsightType</c> parameter is set to <c>ApiErrorRateInsight</c>.</para><para>If returning metrics for the <c>ApiErrorRateInsight</c> Insights type, this is the
        /// error to retrieve data for. For example, <c>AccessDenied</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ErrorCode { get; set; }
        #endregion
        
        #region Parameter EventName
        /// <summary>
        /// <para>
        /// <para>The name of the event, typically the Amazon Web Services API on which unusual levels
        /// of activity were recorded.</para>
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
        public System.String EventName { get; set; }
        #endregion
        
        #region Parameter EventSource
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services service to which the request was made, such as <c>iam.amazonaws.com</c>
        /// or <c>s3.amazonaws.com</c>.</para>
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
        public System.String EventSource { get; set; }
        #endregion
        
        #region Parameter InsightType
        /// <summary>
        /// <para>
        /// <para>The type of CloudTrail Insights event, which is either <c>ApiCallRateInsight</c> or
        /// <c>ApiErrorRateInsight</c>. The <c>ApiCallRateInsight</c> Insights type analyzes write-only
        /// management API calls that are aggregated per minute against a baseline API call volume.
        /// The <c>ApiErrorRateInsight</c> Insights type analyzes management API calls that result
        /// in error codes.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudTrail.InsightType")]
        public Amazon.CloudTrail.InsightType InsightType { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para>Granularity of data to retrieve, in seconds. Valid values are <c>60</c>, <c>300</c>,
        /// and <c>3600</c>. If you specify any other value, you will get an error. The default
        /// is 3600 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Period { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>Specifies, in UTC, the start time for time-series data. The value specified is inclusive;
        /// results include data points with the specified time stamp.</para><para>The default is 90 days before the time of request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of datapoints to return. Valid values are integers from 1 to 21600.
        /// The default value is 21600.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Returned if all datapoints can't be returned in a single call. For example, due to
        /// reaching <c>MaxResults</c>.</para><para>Add this parameter to the request to continue retrieving results starting from the
        /// last evaluated point.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudTrail.Model.ListInsightsMetricDataResponse).
        /// Specifying the name of a property of type Amazon.CloudTrail.Model.ListInsightsMetricDataResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudTrail.Model.ListInsightsMetricDataResponse, GetCTInsightsMetricDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataType = this.DataType;
            context.EndTime = this.EndTime;
            context.ErrorCode = this.ErrorCode;
            context.EventName = this.EventName;
            #if MODULAR
            if (this.EventName == null && ParameterWasBound(nameof(this.EventName)))
            {
                WriteWarning("You are passing $null as a value for parameter EventName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventSource = this.EventSource;
            #if MODULAR
            if (this.EventSource == null && ParameterWasBound(nameof(this.EventSource)))
            {
                WriteWarning("You are passing $null as a value for parameter EventSource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InsightType = this.InsightType;
            #if MODULAR
            if (this.InsightType == null && ParameterWasBound(nameof(this.InsightType)))
            {
                WriteWarning("You are passing $null as a value for parameter InsightType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Period = this.Period;
            context.StartTime = this.StartTime;
            
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
            var request = new Amazon.CloudTrail.Model.ListInsightsMetricDataRequest();
            
            if (cmdletContext.DataType != null)
            {
                request.DataType = cmdletContext.DataType;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.ErrorCode != null)
            {
                request.ErrorCode = cmdletContext.ErrorCode;
            }
            if (cmdletContext.EventName != null)
            {
                request.EventName = cmdletContext.EventName;
            }
            if (cmdletContext.EventSource != null)
            {
                request.EventSource = cmdletContext.EventSource;
            }
            if (cmdletContext.InsightType != null)
            {
                request.InsightType = cmdletContext.InsightType;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Period != null)
            {
                request.Period = cmdletContext.Period.Value;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        private Amazon.CloudTrail.Model.ListInsightsMetricDataResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.ListInsightsMetricDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "ListInsightsMetricData");
            try
            {
                #if DESKTOP
                return client.ListInsightsMetricData(request);
                #elif CORECLR
                return client.ListInsightsMetricDataAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CloudTrail.InsightsMetricDataType DataType { get; set; }
            public System.DateTime? EndTime { get; set; }
            public System.String ErrorCode { get; set; }
            public System.String EventName { get; set; }
            public System.String EventSource { get; set; }
            public Amazon.CloudTrail.InsightType InsightType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Int32? Period { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.CloudTrail.Model.ListInsightsMetricDataResponse, GetCTInsightsMetricDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
