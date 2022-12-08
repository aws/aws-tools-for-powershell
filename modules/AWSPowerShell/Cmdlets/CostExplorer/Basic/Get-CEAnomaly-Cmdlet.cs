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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Retrieves all of the cost anomalies detected on your account during the time period
    /// that's specified by the <code>DateInterval</code> object.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CEAnomaly")]
    [OutputType("Amazon.CostExplorer.Model.Anomaly")]
    [AWSCmdlet("Calls the AWS Cost Explorer GetAnomalies API operation.", Operation = new[] {"GetAnomalies"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.GetAnomaliesResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.Anomaly or Amazon.CostExplorer.Model.GetAnomaliesResponse",
        "This cmdlet returns a collection of Amazon.CostExplorer.Model.Anomaly objects.",
        "The service call response (type Amazon.CostExplorer.Model.GetAnomaliesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCEAnomalyCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        #region Parameter DateInterval_EndDate
        /// <summary>
        /// <para>
        /// <para>The last date an anomaly was observed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DateInterval_EndDate { get; set; }
        #endregion
        
        #region Parameter TotalImpact_EndValue
        /// <summary>
        /// <para>
        /// <para>The upper bound dollar value that's used in the filter. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? TotalImpact_EndValue { get; set; }
        #endregion
        
        #region Parameter Feedback
        /// <summary>
        /// <para>
        /// <para>Filters anomaly results by the feedback field on the anomaly object. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.AnomalyFeedbackType")]
        public Amazon.CostExplorer.AnomalyFeedbackType Feedback { get; set; }
        #endregion
        
        #region Parameter MonitorArn
        /// <summary>
        /// <para>
        /// <para>Retrieves all of the cost anomalies detected for a specific cost anomaly monitor Amazon
        /// Resource Name (ARN). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitorArn { get; set; }
        #endregion
        
        #region Parameter TotalImpact_NumericOperator
        /// <summary>
        /// <para>
        /// <para>The comparing value that's used in the filter. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.NumericOperator")]
        public Amazon.CostExplorer.NumericOperator TotalImpact_NumericOperator { get; set; }
        #endregion
        
        #region Parameter DateInterval_StartDate
        /// <summary>
        /// <para>
        /// <para>The first date an anomaly was observed. </para>
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
        public System.String DateInterval_StartDate { get; set; }
        #endregion
        
        #region Parameter TotalImpact_StartValue
        /// <summary>
        /// <para>
        /// <para>The lower bound dollar value that's used in the filter. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? TotalImpact_StartValue { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The number of entries a paginated response contains. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextPageToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next set of results. Amazon Web Services provides the token
        /// when the response from a previous call has more results than the maximum page size.
        /// </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextPageToken $null' for the first call and '-NextPageToken $AWSHistory.LastServiceResponse.NextPageToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String NextPageToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Anomalies'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.GetAnomaliesResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.GetAnomaliesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Anomalies";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DateInterval_StartDate parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DateInterval_StartDate' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DateInterval_StartDate' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextPageToken
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.GetAnomaliesResponse, GetCEAnomalyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DateInterval_StartDate;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DateInterval_EndDate = this.DateInterval_EndDate;
            context.DateInterval_StartDate = this.DateInterval_StartDate;
            #if MODULAR
            if (this.DateInterval_StartDate == null && ParameterWasBound(nameof(this.DateInterval_StartDate)))
            {
                WriteWarning("You are passing $null as a value for parameter DateInterval_StartDate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Feedback = this.Feedback;
            context.MaxResult = this.MaxResult;
            context.MonitorArn = this.MonitorArn;
            context.NextPageToken = this.NextPageToken;
            context.TotalImpact_EndValue = this.TotalImpact_EndValue;
            context.TotalImpact_NumericOperator = this.TotalImpact_NumericOperator;
            context.TotalImpact_StartValue = this.TotalImpact_StartValue;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.CostExplorer.Model.GetAnomaliesRequest();
            
            
             // populate DateInterval
            var requestDateIntervalIsNull = true;
            request.DateInterval = new Amazon.CostExplorer.Model.AnomalyDateInterval();
            System.String requestDateInterval_dateInterval_EndDate = null;
            if (cmdletContext.DateInterval_EndDate != null)
            {
                requestDateInterval_dateInterval_EndDate = cmdletContext.DateInterval_EndDate;
            }
            if (requestDateInterval_dateInterval_EndDate != null)
            {
                request.DateInterval.EndDate = requestDateInterval_dateInterval_EndDate;
                requestDateIntervalIsNull = false;
            }
            System.String requestDateInterval_dateInterval_StartDate = null;
            if (cmdletContext.DateInterval_StartDate != null)
            {
                requestDateInterval_dateInterval_StartDate = cmdletContext.DateInterval_StartDate;
            }
            if (requestDateInterval_dateInterval_StartDate != null)
            {
                request.DateInterval.StartDate = requestDateInterval_dateInterval_StartDate;
                requestDateIntervalIsNull = false;
            }
             // determine if request.DateInterval should be set to null
            if (requestDateIntervalIsNull)
            {
                request.DateInterval = null;
            }
            if (cmdletContext.Feedback != null)
            {
                request.Feedback = cmdletContext.Feedback;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.MonitorArn != null)
            {
                request.MonitorArn = cmdletContext.MonitorArn;
            }
            
             // populate TotalImpact
            var requestTotalImpactIsNull = true;
            request.TotalImpact = new Amazon.CostExplorer.Model.TotalImpactFilter();
            System.Double? requestTotalImpact_totalImpact_EndValue = null;
            if (cmdletContext.TotalImpact_EndValue != null)
            {
                requestTotalImpact_totalImpact_EndValue = cmdletContext.TotalImpact_EndValue.Value;
            }
            if (requestTotalImpact_totalImpact_EndValue != null)
            {
                request.TotalImpact.EndValue = requestTotalImpact_totalImpact_EndValue.Value;
                requestTotalImpactIsNull = false;
            }
            Amazon.CostExplorer.NumericOperator requestTotalImpact_totalImpact_NumericOperator = null;
            if (cmdletContext.TotalImpact_NumericOperator != null)
            {
                requestTotalImpact_totalImpact_NumericOperator = cmdletContext.TotalImpact_NumericOperator;
            }
            if (requestTotalImpact_totalImpact_NumericOperator != null)
            {
                request.TotalImpact.NumericOperator = requestTotalImpact_totalImpact_NumericOperator;
                requestTotalImpactIsNull = false;
            }
            System.Double? requestTotalImpact_totalImpact_StartValue = null;
            if (cmdletContext.TotalImpact_StartValue != null)
            {
                requestTotalImpact_totalImpact_StartValue = cmdletContext.TotalImpact_StartValue.Value;
            }
            if (requestTotalImpact_totalImpact_StartValue != null)
            {
                request.TotalImpact.StartValue = requestTotalImpact_totalImpact_StartValue.Value;
                requestTotalImpactIsNull = false;
            }
             // determine if request.TotalImpact should be set to null
            if (requestTotalImpactIsNull)
            {
                request.TotalImpact = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextPageToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextPageToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextPageToken = _nextToken;
                
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
                    
                    _nextToken = response.NextPageToken;
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
        
        private Amazon.CostExplorer.Model.GetAnomaliesResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.GetAnomaliesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "GetAnomalies");
            try
            {
                #if DESKTOP
                return client.GetAnomalies(request);
                #elif CORECLR
                return client.GetAnomaliesAsync(request).GetAwaiter().GetResult();
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
            public System.String DateInterval_EndDate { get; set; }
            public System.String DateInterval_StartDate { get; set; }
            public Amazon.CostExplorer.AnomalyFeedbackType Feedback { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String MonitorArn { get; set; }
            public System.String NextPageToken { get; set; }
            public System.Double? TotalImpact_EndValue { get; set; }
            public Amazon.CostExplorer.NumericOperator TotalImpact_NumericOperator { get; set; }
            public System.Double? TotalImpact_StartValue { get; set; }
            public System.Func<Amazon.CostExplorer.Model.GetAnomaliesResponse, GetCEAnomalyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Anomalies;
        }
        
    }
}
