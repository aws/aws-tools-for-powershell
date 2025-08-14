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
using Amazon.BCMRecommendedActions;
using Amazon.BCMRecommendedActions.Model;

namespace Amazon.PowerShell.Cmdlets.BCMRA
{
    /// <summary>
    /// Returns a list of recommended actions that match the filter criteria.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "BCMRARecommendedActionList")]
    [OutputType("Amazon.BCMRecommendedActions.Model.RecommendedAction")]
    [AWSCmdlet("Calls the AWS Billing And Cost Management Recommended Actions ListRecommendedActions API operation.", Operation = new[] {"ListRecommendedActions"}, SelectReturnType = typeof(Amazon.BCMRecommendedActions.Model.ListRecommendedActionsResponse))]
    [AWSCmdletOutput("Amazon.BCMRecommendedActions.Model.RecommendedAction or Amazon.BCMRecommendedActions.Model.ListRecommendedActionsResponse",
        "This cmdlet returns a collection of Amazon.BCMRecommendedActions.Model.RecommendedAction objects.",
        "The service call response (type Amazon.BCMRecommendedActions.Model.ListRecommendedActionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBCMRARecommendedActionListCmdlet : AmazonBCMRecommendedActionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_Action
        /// <summary>
        /// <para>
        /// <para>A list of action filters that define criteria for filtering results. Each filter specifies
        /// a key, match option, and corresponding values to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Actions")]
        public Amazon.BCMRecommendedActions.Model.ActionFilter[] Filter_Action { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that indicates the next set of results that you want to retrieve.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecommendedActions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BCMRecommendedActions.Model.ListRecommendedActionsResponse).
        /// Specifying the name of a property of type Amazon.BCMRecommendedActions.Model.ListRecommendedActionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecommendedActions";
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
                context.Select = CreateSelectDelegate<Amazon.BCMRecommendedActions.Model.ListRecommendedActionsResponse, GetBCMRARecommendedActionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter_Action != null)
            {
                context.Filter_Action = new List<Amazon.BCMRecommendedActions.Model.ActionFilter>(this.Filter_Action);
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
            var request = new Amazon.BCMRecommendedActions.Model.ListRecommendedActionsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.BCMRecommendedActions.Model.RequestFilter();
            List<Amazon.BCMRecommendedActions.Model.ActionFilter> requestFilter_filter_Action = null;
            if (cmdletContext.Filter_Action != null)
            {
                requestFilter_filter_Action = cmdletContext.Filter_Action;
            }
            if (requestFilter_filter_Action != null)
            {
                request.Filter.Actions = requestFilter_filter_Action;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
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
        
        private Amazon.BCMRecommendedActions.Model.ListRecommendedActionsResponse CallAWSServiceOperation(IAmazonBCMRecommendedActions client, Amazon.BCMRecommendedActions.Model.ListRecommendedActionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Billing And Cost Management Recommended Actions", "ListRecommendedActions");
            try
            {
                #if DESKTOP
                return client.ListRecommendedActions(request);
                #elif CORECLR
                return client.ListRecommendedActionsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.BCMRecommendedActions.Model.ActionFilter> Filter_Action { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.BCMRecommendedActions.Model.ListRecommendedActionsResponse, GetBCMRARecommendedActionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecommendedActions;
        }
        
    }
}
