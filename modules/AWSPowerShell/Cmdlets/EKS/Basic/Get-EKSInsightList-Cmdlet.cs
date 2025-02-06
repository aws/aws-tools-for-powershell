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
using Amazon.EKS;
using Amazon.EKS.Model;

namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Returns a list of all insights checked for against the specified cluster. You can
    /// filter which insights are returned by category, associated Kubernetes version, and
    /// status.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EKSInsightList")]
    [OutputType("Amazon.EKS.Model.InsightSummary")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes ListInsights API operation.", Operation = new[] {"ListInsights"}, SelectReturnType = typeof(Amazon.EKS.Model.ListInsightsResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.InsightSummary or Amazon.EKS.Model.ListInsightsResponse",
        "This cmdlet returns a collection of Amazon.EKS.Model.InsightSummary objects.",
        "The service call response (type Amazon.EKS.Model.ListInsightsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEKSInsightListCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_Category
        /// <summary>
        /// <para>
        /// <para>The categories to use to filter insights.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Categories")]
        public System.String[] Filter_Category { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon EKS cluster associated with the insights.</para>
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
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter Filter_KubernetesVersion
        /// <summary>
        /// <para>
        /// <para>The Kubernetes versions to use to filter the insights.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_KubernetesVersions")]
        public System.String[] Filter_KubernetesVersion { get; set; }
        #endregion
        
        #region Parameter Filter_Status
        /// <summary>
        /// <para>
        /// <para>The statuses to use to filter the insights. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Statuses")]
        public System.String[] Filter_Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of identity provider configurations returned by <c>ListInsights</c>
        /// in paginated output. When you use this parameter, <c>ListInsights</c> returns only
        /// <c>maxResults</c> results in a single page along with a <c>nextToken</c> response
        /// element. You can see the remaining results of the initial request by sending another
        /// <c>ListInsights</c> request with the returned <c>nextToken</c> value. This value can
        /// be between 1 and 100. If you don't use this parameter, <c>ListInsights</c> returns
        /// up to 100 results and a <c>nextToken</c> value, if applicable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>nextToken</c> value returned from a previous paginated <c>ListInsights</c>
        /// request. When the results of a <c>ListInsights</c> request exceed <c>maxResults</c>,
        /// you can use this value to retrieve the next page of results. This value is <c>null</c>
        /// when there are no more results to return.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Insights'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.ListInsightsResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.ListInsightsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Insights";
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
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.ListInsightsResponse, GetEKSInsightListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Filter_Category != null)
            {
                context.Filter_Category = new List<System.String>(this.Filter_Category);
            }
            if (this.Filter_KubernetesVersion != null)
            {
                context.Filter_KubernetesVersion = new List<System.String>(this.Filter_KubernetesVersion);
            }
            if (this.Filter_Status != null)
            {
                context.Filter_Status = new List<System.String>(this.Filter_Status);
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
            var request = new Amazon.EKS.Model.ListInsightsRequest();
            
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.EKS.Model.InsightsFilter();
            List<System.String> requestFilter_filter_Category = null;
            if (cmdletContext.Filter_Category != null)
            {
                requestFilter_filter_Category = cmdletContext.Filter_Category;
            }
            if (requestFilter_filter_Category != null)
            {
                request.Filter.Categories = requestFilter_filter_Category;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_KubernetesVersion = null;
            if (cmdletContext.Filter_KubernetesVersion != null)
            {
                requestFilter_filter_KubernetesVersion = cmdletContext.Filter_KubernetesVersion;
            }
            if (requestFilter_filter_KubernetesVersion != null)
            {
                request.Filter.KubernetesVersions = requestFilter_filter_KubernetesVersion;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Statuses = requestFilter_filter_Status;
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
        
        private Amazon.EKS.Model.ListInsightsResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.ListInsightsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "ListInsights");
            try
            {
                #if DESKTOP
                return client.ListInsights(request);
                #elif CORECLR
                return client.ListInsightsAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterName { get; set; }
            public List<System.String> Filter_Category { get; set; }
            public List<System.String> Filter_KubernetesVersion { get; set; }
            public List<System.String> Filter_Status { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.EKS.Model.ListInsightsResponse, GetEKSInsightListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Insights;
        }
        
    }
}
