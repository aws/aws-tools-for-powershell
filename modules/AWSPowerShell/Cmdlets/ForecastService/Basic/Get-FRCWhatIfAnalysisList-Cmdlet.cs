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
using Amazon.ForecastService;
using Amazon.ForecastService.Model;

namespace Amazon.PowerShell.Cmdlets.FRC
{
    /// <summary>
    /// Returns a list of what-if analyses created using the <a>CreateWhatIfAnalysis</a> operation.
    /// For each what-if analysis, this operation returns a summary of its properties, including
    /// its Amazon Resource Name (ARN). You can retrieve the complete set of properties by
    /// using the what-if analysis ARN with the <a>DescribeWhatIfAnalysis</a> operation.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "FRCWhatIfAnalysisList")]
    [OutputType("Amazon.ForecastService.Model.WhatIfAnalysisSummary")]
    [AWSCmdlet("Calls the Amazon Forecast Service ListWhatIfAnalyses API operation.", Operation = new[] {"ListWhatIfAnalyses"}, SelectReturnType = typeof(Amazon.ForecastService.Model.ListWhatIfAnalysesResponse))]
    [AWSCmdletOutput("Amazon.ForecastService.Model.WhatIfAnalysisSummary or Amazon.ForecastService.Model.ListWhatIfAnalysesResponse",
        "This cmdlet returns a collection of Amazon.ForecastService.Model.WhatIfAnalysisSummary objects.",
        "The service call response (type Amazon.ForecastService.Model.ListWhatIfAnalysesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetFRCWhatIfAnalysisListCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>An array of filters. For each filter, you provide a condition and a match statement.
        /// The condition is either <code>IS</code> or <code>IS_NOT</code>, which specifies whether
        /// to include or exclude the what-if analysis jobs that match the statement from the
        /// list, respectively. The match statement consists of a key and a value.</para><para><b>Filter properties</b></para><ul><li><para><code>Condition</code> - The condition to apply. Valid values are <code>IS</code>
        /// and <code>IS_NOT</code>. To include the what-if analysis jobs that match the statement,
        /// specify <code>IS</code>. To exclude matching what-if analysis jobs, specify <code>IS_NOT</code>.</para></li><li><para><code>Key</code> - The name of the parameter to filter on. Valid values are <code>WhatIfAnalysisArn</code>
        /// and <code>Status</code>.</para></li><li><para><code>Value</code> - The value to match.</para></li></ul><para>For example, to list all jobs that export a forecast named <i>electricityWhatIf</i>,
        /// specify the following filter:</para><para><code>"Filters": [ { "Condition": "IS", "Key": "WhatIfAnalysisArn", "Value": "arn:aws:forecast:us-west-2:&lt;acct-id&gt;:forecast/electricityWhatIf"
        /// } ]</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.ForecastService.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The number of items to return in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the result of the previous request was truncated, the response includes a <code>NextToken</code>.
        /// To retrieve the next set of results, use the token in the next request. Tokens expire
        /// after 24 hours.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WhatIfAnalyses'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.ListWhatIfAnalysesResponse).
        /// Specifying the name of a property of type Amazon.ForecastService.Model.ListWhatIfAnalysesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WhatIfAnalyses";
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.ListWhatIfAnalysesResponse, GetFRCWhatIfAnalysisListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.ForecastService.Model.Filter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
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
            var request = new Amazon.ForecastService.Model.ListWhatIfAnalysesRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.ForecastService.Model.ListWhatIfAnalysesResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.ListWhatIfAnalysesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "ListWhatIfAnalyses");
            try
            {
                #if DESKTOP
                return client.ListWhatIfAnalyses(request);
                #elif CORECLR
                return client.ListWhatIfAnalysesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ForecastService.Model.Filter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ForecastService.Model.ListWhatIfAnalysesResponse, GetFRCWhatIfAnalysisListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WhatIfAnalyses;
        }
        
    }
}
