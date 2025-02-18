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

namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Retrieves (queries) statistical data and other information about Amazon Web Services
    /// resources that Amazon Macie monitors and analyzes for an account.
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
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The nextToken string that specifies which page of results to return in a paginated
        /// response.</para>
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
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
            // create request
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
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Macie2.SearchResourcesSortAttributeName SortCriteria_AttributeName { get; set; }
            public Amazon.Macie2.OrderBy SortCriteria_OrderBy { get; set; }
            public System.Func<Amazon.Macie2.Model.SearchResourcesResponse, SearchMAC2ResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MatchingResources;
        }
        
    }
}
