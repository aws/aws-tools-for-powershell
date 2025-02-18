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
using Amazon.NeptuneGraph;
using Amazon.NeptuneGraph.Model;

namespace Amazon.PowerShell.Cmdlets.NEPTG
{
    /// <summary>
    /// Lists private endpoints for a specified Neptune Analytics graph.
    /// </summary>
    [Cmdlet("Get", "NEPTGPrivateGraphEndpointList")]
    [OutputType("Amazon.NeptuneGraph.Model.PrivateGraphEndpointSummary")]
    [AWSCmdlet("Calls the Amazon Neptune Graph ListPrivateGraphEndpoints API operation.", Operation = new[] {"ListPrivateGraphEndpoints"}, SelectReturnType = typeof(Amazon.NeptuneGraph.Model.ListPrivateGraphEndpointsResponse))]
    [AWSCmdletOutput("Amazon.NeptuneGraph.Model.PrivateGraphEndpointSummary or Amazon.NeptuneGraph.Model.ListPrivateGraphEndpointsResponse",
        "This cmdlet returns a collection of Amazon.NeptuneGraph.Model.PrivateGraphEndpointSummary objects.",
        "The service call response (type Amazon.NeptuneGraph.Model.ListPrivateGraphEndpointsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetNEPTGPrivateGraphEndpointListCmdlet : AmazonNeptuneGraphClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GraphIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Neptune Analytics graph.</para>
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
        public System.String GraphIdentifier { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The total number of records to return in the command's output.</para><para>If the total number of records available is more than the value specified, <c>nextToken</c>
        /// is provided in the command's output. To resume pagination, provide the <c>nextToken</c>
        /// output value in the <c>nextToken</c> argument of a subsequent command. Do not use
        /// the <c>nextToken</c> response element directly outside of the Amazon CLI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Pagination token used to paginate output.</para><para>When this value is provided as input, the service returns results from where the previous
        /// response left off. When this value is present in output, it indicates that there are
        /// more results to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PrivateGraphEndpoints'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NeptuneGraph.Model.ListPrivateGraphEndpointsResponse).
        /// Specifying the name of a property of type Amazon.NeptuneGraph.Model.ListPrivateGraphEndpointsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PrivateGraphEndpoints";
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
                context.Select = CreateSelectDelegate<Amazon.NeptuneGraph.Model.ListPrivateGraphEndpointsResponse, GetNEPTGPrivateGraphEndpointListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GraphIdentifier = this.GraphIdentifier;
            #if MODULAR
            if (this.GraphIdentifier == null && ParameterWasBound(nameof(this.GraphIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GraphIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.NeptuneGraph.Model.ListPrivateGraphEndpointsRequest();
            
            if (cmdletContext.GraphIdentifier != null)
            {
                request.GraphIdentifier = cmdletContext.GraphIdentifier;
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
        
        private Amazon.NeptuneGraph.Model.ListPrivateGraphEndpointsResponse CallAWSServiceOperation(IAmazonNeptuneGraph client, Amazon.NeptuneGraph.Model.ListPrivateGraphEndpointsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune Graph", "ListPrivateGraphEndpoints");
            try
            {
                return client.ListPrivateGraphEndpointsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GraphIdentifier { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.NeptuneGraph.Model.ListPrivateGraphEndpointsResponse, GetNEPTGPrivateGraphEndpointListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PrivateGraphEndpoints;
        }
        
    }
}
