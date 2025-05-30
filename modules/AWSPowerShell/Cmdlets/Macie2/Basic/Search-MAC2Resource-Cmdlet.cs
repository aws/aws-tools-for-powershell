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
using System.Threading;
using Amazon.Macie2;
using Amazon.Macie2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Retrieves (queries) statistical data and other information about Amazon Web Services
    /// resources that Amazon Macie monitors and analyzes for an account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Search", "MAC2Resource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Macie2.Model.MatchingResource")]
    [AWSCmdlet("Calls the Amazon Macie 2 SearchResources API operation.", Operation = new[] {"SearchResources"}, SelectReturnType = typeof(Amazon.Macie2.Model.SearchResourcesResponse))]
    [AWSCmdletOutput("Amazon.Macie2.Model.MatchingResource or Amazon.Macie2.Model.SearchResourcesResponse",
        "This cmdlet returns a collection of Amazon.Macie2.Model.MatchingResource objects.",
        "The service call response (type Amazon.Macie2.Model.SearchResourcesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SearchMAC2ResourceCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Excludes_And
        /// <summary>
        /// <para>
        /// <para>An array of objects, one for each property- or tag-based condition that includes or
        /// excludes resources from the query results. If you specify more than one condition,
        /// Amazon Macie uses AND logic to join the conditions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BucketCriteria_Excludes_And")]
        public Amazon.Macie2.Model.SearchResourcesCriteria[] Excludes_And { get; set; }
        #endregion
        
        #region Parameter Includes_And
        /// <summary>
        /// <para>
        /// <para>An array of objects, one for each property- or tag-based condition that includes or
        /// excludes resources from the query results. If you specify more than one condition,
        /// Amazon Macie uses AND logic to join the conditions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BucketCriteria_Includes_And")]
        public Amazon.Macie2.Model.SearchResourcesCriteria[] Includes_And { get; set; }
        #endregion
        
        #region Parameter SortCriteria_AttributeName
        /// <summary>
        /// <para>
        /// <para>The property to sort the results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Macie2.SearchResourcesSortAttributeName")]
        public Amazon.Macie2.SearchResourcesSortAttributeName SortCriteria_AttributeName { get; set; }
        #endregion
        
        #region Parameter SortCriteria_OrderBy
        /// <summary>
        /// <para>
        /// <para>The sort order to apply to the results, based on the value for the property specified
        /// by the attributeName property. Valid values are: ASC, sort the results in ascending
        /// order; and, DESC, sort the results in descending order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Macie2.OrderBy")]
        public Amazon.Macie2.OrderBy SortCriteria_OrderBy { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to include in each page of the response. The default value
        /// is 50.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The nextToken string that specifies which page of results to return in a paginated
        /// response.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MatchingResources'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.SearchResourcesResponse).
        /// Specifying the name of a property of type Amazon.Macie2.Model.SearchResourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MatchingResources";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SortCriteria_AttributeName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-MAC2Resource (SearchResources)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.SearchResourcesResponse, SearchMAC2ResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Excludes_And != null)
            {
                context.Excludes_And = new List<Amazon.Macie2.Model.SearchResourcesCriteria>(this.Excludes_And);
            }
            if (this.Includes_And != null)
            {
                context.Includes_And = new List<Amazon.Macie2.Model.SearchResourcesCriteria>(this.Includes_And);
            }
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.SortCriteria_AttributeName = this.SortCriteria_AttributeName;
            context.SortCriteria_OrderBy = this.SortCriteria_OrderBy;
            
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
            var request = new Amazon.Macie2.Model.SearchResourcesRequest();
            
            
             // populate BucketCriteria
            var requestBucketCriteriaIsNull = true;
            request.BucketCriteria = new Amazon.Macie2.Model.SearchResourcesBucketCriteria();
            Amazon.Macie2.Model.SearchResourcesCriteriaBlock requestBucketCriteria_bucketCriteria_Excludes = null;
            
             // populate Excludes
            var requestBucketCriteria_bucketCriteria_ExcludesIsNull = true;
            requestBucketCriteria_bucketCriteria_Excludes = new Amazon.Macie2.Model.SearchResourcesCriteriaBlock();
            List<Amazon.Macie2.Model.SearchResourcesCriteria> requestBucketCriteria_bucketCriteria_Excludes_excludes_And = null;
            if (cmdletContext.Excludes_And != null)
            {
                requestBucketCriteria_bucketCriteria_Excludes_excludes_And = cmdletContext.Excludes_And;
            }
            if (requestBucketCriteria_bucketCriteria_Excludes_excludes_And != null)
            {
                requestBucketCriteria_bucketCriteria_Excludes.And = requestBucketCriteria_bucketCriteria_Excludes_excludes_And;
                requestBucketCriteria_bucketCriteria_ExcludesIsNull = false;
            }
             // determine if requestBucketCriteria_bucketCriteria_Excludes should be set to null
            if (requestBucketCriteria_bucketCriteria_ExcludesIsNull)
            {
                requestBucketCriteria_bucketCriteria_Excludes = null;
            }
            if (requestBucketCriteria_bucketCriteria_Excludes != null)
            {
                request.BucketCriteria.Excludes = requestBucketCriteria_bucketCriteria_Excludes;
                requestBucketCriteriaIsNull = false;
            }
            Amazon.Macie2.Model.SearchResourcesCriteriaBlock requestBucketCriteria_bucketCriteria_Includes = null;
            
             // populate Includes
            var requestBucketCriteria_bucketCriteria_IncludesIsNull = true;
            requestBucketCriteria_bucketCriteria_Includes = new Amazon.Macie2.Model.SearchResourcesCriteriaBlock();
            List<Amazon.Macie2.Model.SearchResourcesCriteria> requestBucketCriteria_bucketCriteria_Includes_includes_And = null;
            if (cmdletContext.Includes_And != null)
            {
                requestBucketCriteria_bucketCriteria_Includes_includes_And = cmdletContext.Includes_And;
            }
            if (requestBucketCriteria_bucketCriteria_Includes_includes_And != null)
            {
                requestBucketCriteria_bucketCriteria_Includes.And = requestBucketCriteria_bucketCriteria_Includes_includes_And;
                requestBucketCriteria_bucketCriteria_IncludesIsNull = false;
            }
             // determine if requestBucketCriteria_bucketCriteria_Includes should be set to null
            if (requestBucketCriteria_bucketCriteria_IncludesIsNull)
            {
                requestBucketCriteria_bucketCriteria_Includes = null;
            }
            if (requestBucketCriteria_bucketCriteria_Includes != null)
            {
                request.BucketCriteria.Includes = requestBucketCriteria_bucketCriteria_Includes;
                requestBucketCriteriaIsNull = false;
            }
             // determine if request.BucketCriteria should be set to null
            if (requestBucketCriteriaIsNull)
            {
                request.BucketCriteria = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate SortCriteria
            var requestSortCriteriaIsNull = true;
            request.SortCriteria = new Amazon.Macie2.Model.SearchResourcesSortCriteria();
            Amazon.Macie2.SearchResourcesSortAttributeName requestSortCriteria_sortCriteria_AttributeName = null;
            if (cmdletContext.SortCriteria_AttributeName != null)
            {
                requestSortCriteria_sortCriteria_AttributeName = cmdletContext.SortCriteria_AttributeName;
            }
            if (requestSortCriteria_sortCriteria_AttributeName != null)
            {
                request.SortCriteria.AttributeName = requestSortCriteria_sortCriteria_AttributeName;
                requestSortCriteriaIsNull = false;
            }
            Amazon.Macie2.OrderBy requestSortCriteria_sortCriteria_OrderBy = null;
            if (cmdletContext.SortCriteria_OrderBy != null)
            {
                requestSortCriteria_sortCriteria_OrderBy = cmdletContext.SortCriteria_OrderBy;
            }
            if (requestSortCriteria_sortCriteria_OrderBy != null)
            {
                request.SortCriteria.OrderBy = requestSortCriteria_sortCriteria_OrderBy;
                requestSortCriteriaIsNull = false;
            }
             // determine if request.SortCriteria should be set to null
            if (requestSortCriteriaIsNull)
            {
                request.SortCriteria = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
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
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.Macie2.Model.SearchResourcesResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.SearchResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "SearchResources");
            try
            {
                return client.SearchResourcesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Macie2.Model.SearchResourcesCriteria> Excludes_And { get; set; }
            public List<Amazon.Macie2.Model.SearchResourcesCriteria> Includes_And { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Macie2.SearchResourcesSortAttributeName SortCriteria_AttributeName { get; set; }
            public Amazon.Macie2.OrderBy SortCriteria_OrderBy { get; set; }
            public System.Func<Amazon.Macie2.Model.SearchResourcesResponse, SearchMAC2ResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MatchingResources;
        }
        
    }
}
