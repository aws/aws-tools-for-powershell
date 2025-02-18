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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Get a list of cost allocation tags. All inputs in the API are optional and serve as
    /// filters. By default, all cost allocation tags are returned.
    /// </summary>
    [Cmdlet("Get", "CECostAllocationTagList")]
    [OutputType("Amazon.CostExplorer.Model.CostAllocationTag")]
    [AWSCmdlet("Calls the AWS Cost Explorer ListCostAllocationTags API operation.", Operation = new[] {"ListCostAllocationTags"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.ListCostAllocationTagsResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.CostAllocationTag or Amazon.CostExplorer.Model.ListCostAllocationTagsResponse",
        "This cmdlet returns a collection of Amazon.CostExplorer.Model.CostAllocationTag objects.",
        "The service call response (type Amazon.CostExplorer.Model.ListCostAllocationTagsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCECostAllocationTagListCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of cost allocation tag keys that are returned for this request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.CostAllocationTagStatus")]
        public Amazon.CostExplorer.CostAllocationTagStatus Status { get; set; }
        #endregion
        
        #region Parameter TagKey
        /// <summary>
        /// <para>
        /// <para>The list of cost allocation tag keys that are returned for this request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagKeys")]
        public System.String[] TagKey { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of <c>CostAllocationTag</c> object that are returned for this request. The
        /// <c>AWSGenerated</c> type tags are tags that Amazon Web Services defines and applies
        /// to support Amazon Web Services resources for cost allocation purposes. The <c>UserDefined</c>
        /// type tags are tags that you define, create, and apply to resources. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.CostAllocationTagType")]
        public Amazon.CostExplorer.CostAllocationTagType Type { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of objects that are returned for this request. By default, the
        /// request returns 100 results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next set of results. Amazon Web Services provides the token
        /// when the response from a previous call has more results than the maximum page size.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CostAllocationTags'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.ListCostAllocationTagsResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.ListCostAllocationTagsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CostAllocationTags";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.ListCostAllocationTagsResponse, GetCECostAllocationTagListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Status = this.Status;
            if (this.TagKey != null)
            {
                context.TagKey = new List<System.String>(this.TagKey);
            }
            context.Type = this.Type;
            
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
            var request = new Amazon.CostExplorer.Model.ListCostAllocationTagsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.TagKey != null)
            {
                request.TagKeys = cmdletContext.TagKey;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.CostExplorer.Model.ListCostAllocationTagsResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.ListCostAllocationTagsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "ListCostAllocationTags");
            try
            {
                return client.ListCostAllocationTagsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.CostExplorer.CostAllocationTagStatus Status { get; set; }
            public List<System.String> TagKey { get; set; }
            public Amazon.CostExplorer.CostAllocationTagType Type { get; set; }
            public System.Func<Amazon.CostExplorer.Model.ListCostAllocationTagsResponse, GetCECostAllocationTagListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CostAllocationTags;
        }
        
    }
}
