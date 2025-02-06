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
using Amazon.OpenSearchServerless;
using Amazon.OpenSearchServerless.Model;

namespace Amazon.PowerShell.Cmdlets.OSS
{
    /// <summary>
    /// Lists all OpenSearch Serverless collections. For more information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/serverless-manage.html">Creating
    /// and managing Amazon OpenSearch Serverless collections</a>.
    /// 
    ///  <note><para>
    /// Make sure to include an empty request body {} if you don't include any collection
    /// filters in the request.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "OSSCollectionList")]
    [OutputType("Amazon.OpenSearchServerless.Model.CollectionSummary")]
    [AWSCmdlet("Calls the OpenSearch Serverless ListCollections API operation.", Operation = new[] {"ListCollections"}, SelectReturnType = typeof(Amazon.OpenSearchServerless.Model.ListCollectionsResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchServerless.Model.CollectionSummary or Amazon.OpenSearchServerless.Model.ListCollectionsResponse",
        "This cmdlet returns a collection of Amazon.OpenSearchServerless.Model.CollectionSummary objects.",
        "The service call response (type Amazon.OpenSearchServerless.Model.ListCollectionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetOSSCollectionListCmdlet : AmazonOpenSearchServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CollectionFilters_Name
        /// <summary>
        /// <para>
        /// <para>The name of the collection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CollectionFilters_Name { get; set; }
        #endregion
        
        #region Parameter CollectionFilters_Status
        /// <summary>
        /// <para>
        /// <para>The current status of the collection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchServerless.CollectionStatus")]
        public Amazon.OpenSearchServerless.CollectionStatus CollectionFilters_Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return. Default is 20. You can use <c>nextToken</c>
        /// to get the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If your initial <c>ListCollections</c> operation returns a <c>nextToken</c>, you can
        /// include the returned <c>nextToken</c> in subsequent <c>ListCollections</c> operations,
        /// which returns results in the next page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CollectionSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchServerless.Model.ListCollectionsResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchServerless.Model.ListCollectionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CollectionSummaries";
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
                context.Select = CreateSelectDelegate<Amazon.OpenSearchServerless.Model.ListCollectionsResponse, GetOSSCollectionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CollectionFilters_Name = this.CollectionFilters_Name;
            context.CollectionFilters_Status = this.CollectionFilters_Status;
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
            // create request
            var request = new Amazon.OpenSearchServerless.Model.ListCollectionsRequest();
            
            
             // populate CollectionFilters
            var requestCollectionFiltersIsNull = true;
            request.CollectionFilters = new Amazon.OpenSearchServerless.Model.CollectionFilters();
            System.String requestCollectionFilters_collectionFilters_Name = null;
            if (cmdletContext.CollectionFilters_Name != null)
            {
                requestCollectionFilters_collectionFilters_Name = cmdletContext.CollectionFilters_Name;
            }
            if (requestCollectionFilters_collectionFilters_Name != null)
            {
                request.CollectionFilters.Name = requestCollectionFilters_collectionFilters_Name;
                requestCollectionFiltersIsNull = false;
            }
            Amazon.OpenSearchServerless.CollectionStatus requestCollectionFilters_collectionFilters_Status = null;
            if (cmdletContext.CollectionFilters_Status != null)
            {
                requestCollectionFilters_collectionFilters_Status = cmdletContext.CollectionFilters_Status;
            }
            if (requestCollectionFilters_collectionFilters_Status != null)
            {
                request.CollectionFilters.Status = requestCollectionFilters_collectionFilters_Status;
                requestCollectionFiltersIsNull = false;
            }
             // determine if request.CollectionFilters should be set to null
            if (requestCollectionFiltersIsNull)
            {
                request.CollectionFilters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.OpenSearchServerless.Model.ListCollectionsResponse CallAWSServiceOperation(IAmazonOpenSearchServerless client, Amazon.OpenSearchServerless.Model.ListCollectionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "OpenSearch Serverless", "ListCollections");
            try
            {
                #if DESKTOP
                return client.ListCollections(request);
                #elif CORECLR
                return client.ListCollectionsAsync(request).GetAwaiter().GetResult();
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
            public System.String CollectionFilters_Name { get; set; }
            public Amazon.OpenSearchServerless.CollectionStatus CollectionFilters_Status { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.OpenSearchServerless.Model.ListCollectionsResponse, GetOSSCollectionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CollectionSummaries;
        }
        
    }
}
