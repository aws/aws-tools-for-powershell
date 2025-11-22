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
using Amazon.ComputeOptimizerAutomation;
using Amazon.ComputeOptimizerAutomation.Model;

namespace Amazon.PowerShell.Cmdlets.COA
{
    /// <summary>
    /// Provides a summary of recommended actions based on specified filters. 
    /// 
    ///  <note><para>
    /// Management accounts and delegated administrators can retrieve recommended actions
    /// that include associated member accounts. You can associate a member account using
    /// <c>AssociateAccounts</c>.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "COARecommendedActionSummaryList")]
    [OutputType("Amazon.ComputeOptimizerAutomation.Model.RecommendedActionSummary")]
    [AWSCmdlet("Calls the Compute Optimizer Automation Service ListRecommendedActionSummaries API operation.", Operation = new[] {"ListRecommendedActionSummaries"}, SelectReturnType = typeof(Amazon.ComputeOptimizerAutomation.Model.ListRecommendedActionSummariesResponse))]
    [AWSCmdletOutput("Amazon.ComputeOptimizerAutomation.Model.RecommendedActionSummary or Amazon.ComputeOptimizerAutomation.Model.ListRecommendedActionSummariesResponse",
        "This cmdlet returns a collection of Amazon.ComputeOptimizerAutomation.Model.RecommendedActionSummary objects.",
        "The service call response (type Amazon.ComputeOptimizerAutomation.Model.ListRecommendedActionSummariesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCOARecommendedActionSummaryListCmdlet : AmazonComputeOptimizerAutomationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>A list of filters to apply when retrieving recommended action summaries. Filters can
        /// be based on resource type, action type, account ID, and other criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.ComputeOptimizerAutomation.Model.RecommendedActionFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of recommended action summaries to return in a single response.
        /// Valid range is 1-1000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token used for pagination to retrieve the next set of results when the response
        /// is truncated.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecommendedActionSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComputeOptimizerAutomation.Model.ListRecommendedActionSummariesResponse).
        /// Specifying the name of a property of type Amazon.ComputeOptimizerAutomation.Model.ListRecommendedActionSummariesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecommendedActionSummaries";
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
                context.Select = CreateSelectDelegate<Amazon.ComputeOptimizerAutomation.Model.ListRecommendedActionSummariesResponse, GetCOARecommendedActionSummaryListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.ComputeOptimizerAutomation.Model.RecommendedActionFilter>(this.Filter);
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
            var request = new Amazon.ComputeOptimizerAutomation.Model.ListRecommendedActionSummariesRequest();
            
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
        
        private Amazon.ComputeOptimizerAutomation.Model.ListRecommendedActionSummariesResponse CallAWSServiceOperation(IAmazonComputeOptimizerAutomation client, Amazon.ComputeOptimizerAutomation.Model.ListRecommendedActionSummariesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Compute Optimizer Automation Service", "ListRecommendedActionSummaries");
            try
            {
                #if DESKTOP
                return client.ListRecommendedActionSummaries(request);
                #elif CORECLR
                return client.ListRecommendedActionSummariesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ComputeOptimizerAutomation.Model.RecommendedActionFilter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ComputeOptimizerAutomation.Model.ListRecommendedActionSummariesResponse, GetCOARecommendedActionSummaryListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecommendedActionSummaries;
        }
        
    }
}
