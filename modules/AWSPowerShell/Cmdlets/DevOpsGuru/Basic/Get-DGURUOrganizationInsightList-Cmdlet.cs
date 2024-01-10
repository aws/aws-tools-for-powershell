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
using Amazon.DevOpsGuru;
using Amazon.DevOpsGuru.Model;

namespace Amazon.PowerShell.Cmdlets.DGURU
{
    /// <summary>
    /// Returns a list of insights associated with the account or OU Id.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DGURUOrganizationInsightList")]
    [OutputType("Amazon.DevOpsGuru.Model.ListOrganizationInsightsResponse")]
    [AWSCmdlet("Calls the Amazon DevOps Guru ListOrganizationInsights API operation.", Operation = new[] {"ListOrganizationInsights"}, SelectReturnType = typeof(Amazon.DevOpsGuru.Model.ListOrganizationInsightsResponse))]
    [AWSCmdletOutput("Amazon.DevOpsGuru.Model.ListOrganizationInsightsResponse",
        "This cmdlet returns an Amazon.DevOpsGuru.Model.ListOrganizationInsightsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDGURUOrganizationInsightListCmdlet : AmazonDevOpsGuruClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountIds")]
        public System.String[] AccountId { get; set; }
        #endregion
        
        #region Parameter StartTimeRange_FromTime
        /// <summary>
        /// <para>
        /// <para> The start time of the time range. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StatusFilter_Any_StartTimeRange_FromTime")]
        public System.DateTime? StartTimeRange_FromTime { get; set; }
        #endregion
        
        #region Parameter EndTimeRange_FromTime
        /// <summary>
        /// <para>
        /// <para> The earliest end time in the time range. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StatusFilter_Closed_EndTimeRange_FromTime")]
        public System.DateTime? EndTimeRange_FromTime { get; set; }
        #endregion
        
        #region Parameter OrganizationalUnitId
        /// <summary>
        /// <para>
        /// <para>The ID of the organizational unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationalUnitIds")]
        public System.String[] OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter StartTimeRange_ToTime
        /// <summary>
        /// <para>
        /// <para> The end time of the time range. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StatusFilter_Any_StartTimeRange_ToTime")]
        public System.DateTime? StartTimeRange_ToTime { get; set; }
        #endregion
        
        #region Parameter EndTimeRange_ToTime
        /// <summary>
        /// <para>
        /// <para> The latest end time in the time range. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StatusFilter_Closed_EndTimeRange_ToTime")]
        public System.DateTime? EndTimeRange_ToTime { get; set; }
        #endregion
        
        #region Parameter Any_Type
        /// <summary>
        /// <para>
        /// <para> Use to filter for either <c>REACTIVE</c> or <c>PROACTIVE</c> insights. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StatusFilter_Any_Type")]
        [AWSConstantClassSource("Amazon.DevOpsGuru.InsightType")]
        public Amazon.DevOpsGuru.InsightType Any_Type { get; set; }
        #endregion
        
        #region Parameter Closed_Type
        /// <summary>
        /// <para>
        /// <para> Use to filter for either <c>REACTIVE</c> or <c>PROACTIVE</c> insights. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StatusFilter_Closed_Type")]
        [AWSConstantClassSource("Amazon.DevOpsGuru.InsightType")]
        public Amazon.DevOpsGuru.InsightType Closed_Type { get; set; }
        #endregion
        
        #region Parameter Ongoing_Type
        /// <summary>
        /// <para>
        /// <para> Use to filter for either <c>REACTIVE</c> or <c>PROACTIVE</c> insights. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StatusFilter_Ongoing_Type")]
        [AWSConstantClassSource("Amazon.DevOpsGuru.InsightType")]
        public Amazon.DevOpsGuru.InsightType Ongoing_Type { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with a single call. To retrieve the remaining
        /// results, make another call with the returned <c>nextToken</c> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token to use to retrieve the next page of results for this operation.
        /// If this value is null, it retrieves the first page.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsGuru.Model.ListOrganizationInsightsResponse).
        /// Specifying the name of a property of type Amazon.DevOpsGuru.Model.ListOrganizationInsightsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.DevOpsGuru.Model.ListOrganizationInsightsResponse, GetDGURUOrganizationInsightListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountId != null)
            {
                context.AccountId = new List<System.String>(this.AccountId);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.OrganizationalUnitId != null)
            {
                context.OrganizationalUnitId = new List<System.String>(this.OrganizationalUnitId);
            }
            context.StartTimeRange_FromTime = this.StartTimeRange_FromTime;
            context.StartTimeRange_ToTime = this.StartTimeRange_ToTime;
            context.Any_Type = this.Any_Type;
            context.EndTimeRange_FromTime = this.EndTimeRange_FromTime;
            context.EndTimeRange_ToTime = this.EndTimeRange_ToTime;
            context.Closed_Type = this.Closed_Type;
            context.Ongoing_Type = this.Ongoing_Type;
            
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
            var request = new Amazon.DevOpsGuru.Model.ListOrganizationInsightsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountIds = cmdletContext.AccountId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.OrganizationalUnitId != null)
            {
                request.OrganizationalUnitIds = cmdletContext.OrganizationalUnitId;
            }
            
             // populate StatusFilter
            var requestStatusFilterIsNull = true;
            request.StatusFilter = new Amazon.DevOpsGuru.Model.ListInsightsStatusFilter();
            Amazon.DevOpsGuru.Model.ListInsightsOngoingStatusFilter requestStatusFilter_statusFilter_Ongoing = null;
            
             // populate Ongoing
            var requestStatusFilter_statusFilter_OngoingIsNull = true;
            requestStatusFilter_statusFilter_Ongoing = new Amazon.DevOpsGuru.Model.ListInsightsOngoingStatusFilter();
            Amazon.DevOpsGuru.InsightType requestStatusFilter_statusFilter_Ongoing_ongoing_Type = null;
            if (cmdletContext.Ongoing_Type != null)
            {
                requestStatusFilter_statusFilter_Ongoing_ongoing_Type = cmdletContext.Ongoing_Type;
            }
            if (requestStatusFilter_statusFilter_Ongoing_ongoing_Type != null)
            {
                requestStatusFilter_statusFilter_Ongoing.Type = requestStatusFilter_statusFilter_Ongoing_ongoing_Type;
                requestStatusFilter_statusFilter_OngoingIsNull = false;
            }
             // determine if requestStatusFilter_statusFilter_Ongoing should be set to null
            if (requestStatusFilter_statusFilter_OngoingIsNull)
            {
                requestStatusFilter_statusFilter_Ongoing = null;
            }
            if (requestStatusFilter_statusFilter_Ongoing != null)
            {
                request.StatusFilter.Ongoing = requestStatusFilter_statusFilter_Ongoing;
                requestStatusFilterIsNull = false;
            }
            Amazon.DevOpsGuru.Model.ListInsightsAnyStatusFilter requestStatusFilter_statusFilter_Any = null;
            
             // populate Any
            var requestStatusFilter_statusFilter_AnyIsNull = true;
            requestStatusFilter_statusFilter_Any = new Amazon.DevOpsGuru.Model.ListInsightsAnyStatusFilter();
            Amazon.DevOpsGuru.InsightType requestStatusFilter_statusFilter_Any_any_Type = null;
            if (cmdletContext.Any_Type != null)
            {
                requestStatusFilter_statusFilter_Any_any_Type = cmdletContext.Any_Type;
            }
            if (requestStatusFilter_statusFilter_Any_any_Type != null)
            {
                requestStatusFilter_statusFilter_Any.Type = requestStatusFilter_statusFilter_Any_any_Type;
                requestStatusFilter_statusFilter_AnyIsNull = false;
            }
            Amazon.DevOpsGuru.Model.StartTimeRange requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange = null;
            
             // populate StartTimeRange
            var requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRangeIsNull = true;
            requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange = new Amazon.DevOpsGuru.Model.StartTimeRange();
            System.DateTime? requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange_startTimeRange_FromTime = null;
            if (cmdletContext.StartTimeRange_FromTime != null)
            {
                requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange_startTimeRange_FromTime = cmdletContext.StartTimeRange_FromTime.Value;
            }
            if (requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange_startTimeRange_FromTime != null)
            {
                requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange.FromTime = requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange_startTimeRange_FromTime.Value;
                requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRangeIsNull = false;
            }
            System.DateTime? requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange_startTimeRange_ToTime = null;
            if (cmdletContext.StartTimeRange_ToTime != null)
            {
                requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange_startTimeRange_ToTime = cmdletContext.StartTimeRange_ToTime.Value;
            }
            if (requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange_startTimeRange_ToTime != null)
            {
                requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange.ToTime = requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange_startTimeRange_ToTime.Value;
                requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRangeIsNull = false;
            }
             // determine if requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange should be set to null
            if (requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRangeIsNull)
            {
                requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange = null;
            }
            if (requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange != null)
            {
                requestStatusFilter_statusFilter_Any.StartTimeRange = requestStatusFilter_statusFilter_Any_statusFilter_Any_StartTimeRange;
                requestStatusFilter_statusFilter_AnyIsNull = false;
            }
             // determine if requestStatusFilter_statusFilter_Any should be set to null
            if (requestStatusFilter_statusFilter_AnyIsNull)
            {
                requestStatusFilter_statusFilter_Any = null;
            }
            if (requestStatusFilter_statusFilter_Any != null)
            {
                request.StatusFilter.Any = requestStatusFilter_statusFilter_Any;
                requestStatusFilterIsNull = false;
            }
            Amazon.DevOpsGuru.Model.ListInsightsClosedStatusFilter requestStatusFilter_statusFilter_Closed = null;
            
             // populate Closed
            var requestStatusFilter_statusFilter_ClosedIsNull = true;
            requestStatusFilter_statusFilter_Closed = new Amazon.DevOpsGuru.Model.ListInsightsClosedStatusFilter();
            Amazon.DevOpsGuru.InsightType requestStatusFilter_statusFilter_Closed_closed_Type = null;
            if (cmdletContext.Closed_Type != null)
            {
                requestStatusFilter_statusFilter_Closed_closed_Type = cmdletContext.Closed_Type;
            }
            if (requestStatusFilter_statusFilter_Closed_closed_Type != null)
            {
                requestStatusFilter_statusFilter_Closed.Type = requestStatusFilter_statusFilter_Closed_closed_Type;
                requestStatusFilter_statusFilter_ClosedIsNull = false;
            }
            Amazon.DevOpsGuru.Model.EndTimeRange requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange = null;
            
             // populate EndTimeRange
            var requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRangeIsNull = true;
            requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange = new Amazon.DevOpsGuru.Model.EndTimeRange();
            System.DateTime? requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange_endTimeRange_FromTime = null;
            if (cmdletContext.EndTimeRange_FromTime != null)
            {
                requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange_endTimeRange_FromTime = cmdletContext.EndTimeRange_FromTime.Value;
            }
            if (requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange_endTimeRange_FromTime != null)
            {
                requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange.FromTime = requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange_endTimeRange_FromTime.Value;
                requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRangeIsNull = false;
            }
            System.DateTime? requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange_endTimeRange_ToTime = null;
            if (cmdletContext.EndTimeRange_ToTime != null)
            {
                requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange_endTimeRange_ToTime = cmdletContext.EndTimeRange_ToTime.Value;
            }
            if (requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange_endTimeRange_ToTime != null)
            {
                requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange.ToTime = requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange_endTimeRange_ToTime.Value;
                requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRangeIsNull = false;
            }
             // determine if requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange should be set to null
            if (requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRangeIsNull)
            {
                requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange = null;
            }
            if (requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange != null)
            {
                requestStatusFilter_statusFilter_Closed.EndTimeRange = requestStatusFilter_statusFilter_Closed_statusFilter_Closed_EndTimeRange;
                requestStatusFilter_statusFilter_ClosedIsNull = false;
            }
             // determine if requestStatusFilter_statusFilter_Closed should be set to null
            if (requestStatusFilter_statusFilter_ClosedIsNull)
            {
                requestStatusFilter_statusFilter_Closed = null;
            }
            if (requestStatusFilter_statusFilter_Closed != null)
            {
                request.StatusFilter.Closed = requestStatusFilter_statusFilter_Closed;
                requestStatusFilterIsNull = false;
            }
             // determine if request.StatusFilter should be set to null
            if (requestStatusFilterIsNull)
            {
                request.StatusFilter = null;
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
        
        private Amazon.DevOpsGuru.Model.ListOrganizationInsightsResponse CallAWSServiceOperation(IAmazonDevOpsGuru client, Amazon.DevOpsGuru.Model.ListOrganizationInsightsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DevOps Guru", "ListOrganizationInsights");
            try
            {
                #if DESKTOP
                return client.ListOrganizationInsights(request);
                #elif CORECLR
                return client.ListOrganizationInsightsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AccountId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> OrganizationalUnitId { get; set; }
            public System.DateTime? StartTimeRange_FromTime { get; set; }
            public System.DateTime? StartTimeRange_ToTime { get; set; }
            public Amazon.DevOpsGuru.InsightType Any_Type { get; set; }
            public System.DateTime? EndTimeRange_FromTime { get; set; }
            public System.DateTime? EndTimeRange_ToTime { get; set; }
            public Amazon.DevOpsGuru.InsightType Closed_Type { get; set; }
            public Amazon.DevOpsGuru.InsightType Ongoing_Type { get; set; }
            public System.Func<Amazon.DevOpsGuru.Model.ListOrganizationInsightsResponse, GetDGURUOrganizationInsightListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
