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
    /// Retrieves an array of Cost Category names and values incurred cost.
    /// 
    ///  <note><para>
    /// If some Cost Category names and values are not associated with any cost, they will
    /// not be returned by this API.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CECostCategory")]
    [OutputType("Amazon.CostExplorer.Model.GetCostCategoriesResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer GetCostCategories API operation.", Operation = new[] {"GetCostCategories"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.GetCostCategoriesResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.GetCostCategoriesResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.GetCostCategoriesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCECostCategoryCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CostCategoryName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CostCategoryName { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.Expression Filter { get; set; }
        #endregion
        
        #region Parameter SearchString
        /// <summary>
        /// <para>
        /// <para>The value that you want to search the filter values for.</para><para>If you don't specify a <c>CostCategoryName</c>, <c>SearchString</c> is used to filter
        /// Cost Category names that match the <c>SearchString</c> pattern. If you specify a <c>CostCategoryName</c>,
        /// <c>SearchString</c> is used to filter Cost Category values that match the <c>SearchString</c>
        /// pattern.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SearchString { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The value that you sort the data by.</para><para>The key represents the cost and usage metrics. The following values are supported:</para><ul><li><para><c>BlendedCost</c></para></li><li><para><c>UnblendedCost</c></para></li><li><para><c>AmortizedCost</c></para></li><li><para><c>NetAmortizedCost</c></para></li><li><para><c>NetUnblendedCost</c></para></li><li><para><c>UsageQuantity</c></para></li><li><para><c>NormalizedUsageAmount</c></para></li></ul><para>The supported key values for the <c>SortOrder</c> value are <c>ASCENDING</c> and <c>DESCENDING</c>.</para><para>When you use the <c>SortBy</c> value, the <c>NextPageToken</c> and <c>SearchString</c>
        /// key values aren't supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.SortDefinition[] SortBy { get; set; }
        #endregion
        
        #region Parameter TimePeriod
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>This field is only used when the <c>SortBy</c> value is provided in the request.</para><para>The maximum number of objects that are returned for this request. If <c>MaxResults</c>
        /// isn't specified with the <c>SortBy</c> value, the request returns 1000 results as
        /// the default value for this parameter.</para><para>For <c>GetCostCategories</c>, MaxResults has an upper quota of 1000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextPageToken
        /// <summary>
        /// <para>
        /// <para>If the number of objects that are still available for retrieval exceeds the quota,
        /// Amazon Web Services returns a NextPageToken value in the response. To retrieve the
        /// next batch of objects, provide the NextPageToken from the previous call in your next
        /// request.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.GetCostCategoriesResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.GetCostCategoriesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.GetCostCategoriesResponse, GetCECostCategoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CostCategoryName = this.CostCategoryName;
            context.Filter = this.Filter;
            context.MaxResult = this.MaxResult;
            context.NextPageToken = this.NextPageToken;
            context.SearchString = this.SearchString;
            if (this.SortBy != null)
            {
                context.SortBy = new List<Amazon.CostExplorer.Model.SortDefinition>(this.SortBy);
            }
            context.TimePeriod = this.TimePeriod;
            #if MODULAR
            if (this.TimePeriod == null && ParameterWasBound(nameof(this.TimePeriod)))
            {
                WriteWarning("You are passing $null as a value for parameter TimePeriod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CostExplorer.Model.GetCostCategoriesRequest();
            
            if (cmdletContext.CostCategoryName != null)
            {
                request.CostCategoryName = cmdletContext.CostCategoryName;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SearchString != null)
            {
                request.SearchString = cmdletContext.SearchString;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.TimePeriod != null)
            {
                request.TimePeriod = cmdletContext.TimePeriod;
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
        
        private Amazon.CostExplorer.Model.GetCostCategoriesResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.GetCostCategoriesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "GetCostCategories");
            try
            {
                #if DESKTOP
                return client.GetCostCategories(request);
                #elif CORECLR
                return client.GetCostCategoriesAsync(request).GetAwaiter().GetResult();
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
            public System.String CostCategoryName { get; set; }
            public Amazon.CostExplorer.Model.Expression Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextPageToken { get; set; }
            public System.String SearchString { get; set; }
            public List<Amazon.CostExplorer.Model.SortDefinition> SortBy { get; set; }
            public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
            public System.Func<Amazon.CostExplorer.Model.GetCostCategoriesResponse, GetCECostCategoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
