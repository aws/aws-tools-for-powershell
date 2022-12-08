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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns a list of proactive resource evaluations.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFGResourceEvaluationList")]
    [OutputType("Amazon.ConfigService.Model.ResourceEvaluation")]
    [AWSCmdlet("Calls the AWS Config ListResourceEvaluations API operation.", Operation = new[] {"ListResourceEvaluations"}, SelectReturnType = typeof(Amazon.ConfigService.Model.ListResourceEvaluationsResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ResourceEvaluation or Amazon.ConfigService.Model.ListResourceEvaluationsResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.ResourceEvaluation objects.",
        "The service call response (type Amazon.ConfigService.Model.ListResourceEvaluationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFGResourceEvaluationListCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter TimeWindow_EndTime
        /// <summary>
        /// <para>
        /// <para>The end time of an execution. The end time must be after the start date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_TimeWindow_EndTime")]
        public System.DateTime? TimeWindow_EndTime { get; set; }
        #endregion
        
        #region Parameter Filters_EvaluationContextIdentifier
        /// <summary>
        /// <para>
        /// <para>Filters evaluations for a given infrastructure deployment. For example: CFN Stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_EvaluationContextIdentifier { get; set; }
        #endregion
        
        #region Parameter Filters_EvaluationMode
        /// <summary>
        /// <para>
        /// <para>Filters all resource evaluations results based on an evaluation mode. the valid value
        /// for this API is <code>Proactive</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConfigService.EvaluationMode")]
        public Amazon.ConfigService.EvaluationMode Filters_EvaluationMode { get; set; }
        #endregion
        
        #region Parameter TimeWindow_StartTime
        /// <summary>
        /// <para>
        /// <para>The start time of an execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_TimeWindow_StartTime")]
        public System.DateTime? TimeWindow_StartTime { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of evaluations returned on each page. The default is 10. You cannot
        /// specify a number greater than 100. If you specify 0, Config uses the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>nextToken</code> string returned on a previous page that you use to get
        /// the next page of results in a paginated response.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceEvaluations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.ListResourceEvaluationsResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.ListResourceEvaluationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceEvaluations";
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
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.ListResourceEvaluationsResponse, GetCFGResourceEvaluationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filters_EvaluationContextIdentifier = this.Filters_EvaluationContextIdentifier;
            context.Filters_EvaluationMode = this.Filters_EvaluationMode;
            context.TimeWindow_EndTime = this.TimeWindow_EndTime;
            context.TimeWindow_StartTime = this.TimeWindow_StartTime;
            context.Limit = this.Limit;
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
            var request = new Amazon.ConfigService.Model.ListResourceEvaluationsRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.ConfigService.Model.ResourceEvaluationFilters();
            System.String requestFilters_filters_EvaluationContextIdentifier = null;
            if (cmdletContext.Filters_EvaluationContextIdentifier != null)
            {
                requestFilters_filters_EvaluationContextIdentifier = cmdletContext.Filters_EvaluationContextIdentifier;
            }
            if (requestFilters_filters_EvaluationContextIdentifier != null)
            {
                request.Filters.EvaluationContextIdentifier = requestFilters_filters_EvaluationContextIdentifier;
                requestFiltersIsNull = false;
            }
            Amazon.ConfigService.EvaluationMode requestFilters_filters_EvaluationMode = null;
            if (cmdletContext.Filters_EvaluationMode != null)
            {
                requestFilters_filters_EvaluationMode = cmdletContext.Filters_EvaluationMode;
            }
            if (requestFilters_filters_EvaluationMode != null)
            {
                request.Filters.EvaluationMode = requestFilters_filters_EvaluationMode;
                requestFiltersIsNull = false;
            }
            Amazon.ConfigService.Model.TimeWindow requestFilters_filters_TimeWindow = null;
            
             // populate TimeWindow
            var requestFilters_filters_TimeWindowIsNull = true;
            requestFilters_filters_TimeWindow = new Amazon.ConfigService.Model.TimeWindow();
            System.DateTime? requestFilters_filters_TimeWindow_timeWindow_EndTime = null;
            if (cmdletContext.TimeWindow_EndTime != null)
            {
                requestFilters_filters_TimeWindow_timeWindow_EndTime = cmdletContext.TimeWindow_EndTime.Value;
            }
            if (requestFilters_filters_TimeWindow_timeWindow_EndTime != null)
            {
                requestFilters_filters_TimeWindow.EndTime = requestFilters_filters_TimeWindow_timeWindow_EndTime.Value;
                requestFilters_filters_TimeWindowIsNull = false;
            }
            System.DateTime? requestFilters_filters_TimeWindow_timeWindow_StartTime = null;
            if (cmdletContext.TimeWindow_StartTime != null)
            {
                requestFilters_filters_TimeWindow_timeWindow_StartTime = cmdletContext.TimeWindow_StartTime.Value;
            }
            if (requestFilters_filters_TimeWindow_timeWindow_StartTime != null)
            {
                requestFilters_filters_TimeWindow.StartTime = requestFilters_filters_TimeWindow_timeWindow_StartTime.Value;
                requestFilters_filters_TimeWindowIsNull = false;
            }
             // determine if requestFilters_filters_TimeWindow should be set to null
            if (requestFilters_filters_TimeWindowIsNull)
            {
                requestFilters_filters_TimeWindow = null;
            }
            if (requestFilters_filters_TimeWindow != null)
            {
                request.Filters.TimeWindow = requestFilters_filters_TimeWindow;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
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
        
        private Amazon.ConfigService.Model.ListResourceEvaluationsResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.ListResourceEvaluationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "ListResourceEvaluations");
            try
            {
                #if DESKTOP
                return client.ListResourceEvaluations(request);
                #elif CORECLR
                return client.ListResourceEvaluationsAsync(request).GetAwaiter().GetResult();
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
            public System.String Filters_EvaluationContextIdentifier { get; set; }
            public Amazon.ConfigService.EvaluationMode Filters_EvaluationMode { get; set; }
            public System.DateTime? TimeWindow_EndTime { get; set; }
            public System.DateTime? TimeWindow_StartTime { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ConfigService.Model.ListResourceEvaluationsResponse, GetCFGResourceEvaluationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceEvaluations;
        }
        
    }
}
