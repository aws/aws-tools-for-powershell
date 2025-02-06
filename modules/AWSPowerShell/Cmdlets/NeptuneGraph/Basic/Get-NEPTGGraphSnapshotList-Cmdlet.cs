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
using Amazon.NeptuneGraph;
using Amazon.NeptuneGraph.Model;

namespace Amazon.PowerShell.Cmdlets.NEPTG
{
    /// <summary>
    /// Lists available snapshots of a specified Neptune Analytics graph.
    /// </summary>
    [Cmdlet("Get", "NEPTGGraphSnapshotList")]
    [OutputType("Amazon.NeptuneGraph.Model.GraphSnapshotSummary")]
    [AWSCmdlet("Calls the Amazon Neptune Graph ListGraphSnapshots API operation.", Operation = new[] {"ListGraphSnapshots"}, SelectReturnType = typeof(Amazon.NeptuneGraph.Model.ListGraphSnapshotsResponse))]
    [AWSCmdletOutput("Amazon.NeptuneGraph.Model.GraphSnapshotSummary or Amazon.NeptuneGraph.Model.ListGraphSnapshotsResponse",
        "This cmdlet returns a collection of Amazon.NeptuneGraph.Model.GraphSnapshotSummary objects.",
        "The service call response (type Amazon.NeptuneGraph.Model.ListGraphSnapshotsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetNEPTGGraphSnapshotListCmdlet : AmazonNeptuneGraphClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GraphIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Neptune Analytics graph.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GraphSnapshots'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NeptuneGraph.Model.ListGraphSnapshotsResponse).
        /// Specifying the name of a property of type Amazon.NeptuneGraph.Model.ListGraphSnapshotsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GraphSnapshots";
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
                context.Select = CreateSelectDelegate<Amazon.NeptuneGraph.Model.ListGraphSnapshotsResponse, GetNEPTGGraphSnapshotListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GraphIdentifier = this.GraphIdentifier;
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
            var request = new Amazon.NeptuneGraph.Model.ListGraphSnapshotsRequest();
            
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
        
        private Amazon.NeptuneGraph.Model.ListGraphSnapshotsResponse CallAWSServiceOperation(IAmazonNeptuneGraph client, Amazon.NeptuneGraph.Model.ListGraphSnapshotsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune Graph", "ListGraphSnapshots");
            try
            {
                #if DESKTOP
                return client.ListGraphSnapshots(request);
                #elif CORECLR
                return client.ListGraphSnapshotsAsync(request).GetAwaiter().GetResult();
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
            public System.String GraphIdentifier { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.NeptuneGraph.Model.ListGraphSnapshotsResponse, GetNEPTGGraphSnapshotListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GraphSnapshots;
        }
        
    }
}
