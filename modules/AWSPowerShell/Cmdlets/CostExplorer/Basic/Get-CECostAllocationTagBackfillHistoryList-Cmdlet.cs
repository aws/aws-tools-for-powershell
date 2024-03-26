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
    /// Retrieves a list of your historical cost allocation tag backfill requests.
    /// </summary>
    [Cmdlet("Get", "CECostAllocationTagBackfillHistoryList")]
    [OutputType("Amazon.CostExplorer.Model.CostAllocationTagBackfillRequest")]
    [AWSCmdlet("Calls the AWS Cost Explorer ListCostAllocationTagBackfillHistory API operation.", Operation = new[] {"ListCostAllocationTagBackfillHistory"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.ListCostAllocationTagBackfillHistoryResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.CostAllocationTagBackfillRequest or Amazon.CostExplorer.Model.ListCostAllocationTagBackfillHistoryResponse",
        "This cmdlet returns a collection of Amazon.CostExplorer.Model.CostAllocationTagBackfillRequest objects.",
        "The service call response (type Amazon.CostExplorer.Model.ListCostAllocationTagBackfillHistoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCECostAllocationTagBackfillHistoryListCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of objects that are returned for this request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The token to retrieve the next set of results. Amazon Web Services provides the token
        /// when the response from a previous call has more results than the maximum page size.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BackfillRequests'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.ListCostAllocationTagBackfillHistoryResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.ListCostAllocationTagBackfillHistoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BackfillRequests";
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
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.ListCostAllocationTagBackfillHistoryResponse, GetCECostAllocationTagBackfillHistoryListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            // create request
            var request = new Amazon.CostExplorer.Model.ListCostAllocationTagBackfillHistoryRequest();
            
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
        
        private Amazon.CostExplorer.Model.ListCostAllocationTagBackfillHistoryResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.ListCostAllocationTagBackfillHistoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "ListCostAllocationTagBackfillHistory");
            try
            {
                #if DESKTOP
                return client.ListCostAllocationTagBackfillHistory(request);
                #elif CORECLR
                return client.ListCostAllocationTagBackfillHistoryAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CostExplorer.Model.ListCostAllocationTagBackfillHistoryResponse, GetCECostAllocationTagBackfillHistoryListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BackfillRequests;
        }
        
    }
}
