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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Returns the description of specific Amazon FSx for OpenZFS snapshots, if a <c>SnapshotIds</c>
    /// value is provided. Otherwise, this operation returns all snapshots owned by your Amazon
    /// Web Services account in the Amazon Web Services Region of the endpoint that you're
    /// calling.
    /// 
    ///  
    /// <para>
    /// When retrieving all snapshots, you can optionally specify the <c>MaxResults</c> parameter
    /// to limit the number of snapshots in a response. If more backups remain, Amazon FSx
    /// returns a <c>NextToken</c> value in the response. In this case, send a later request
    /// with the <c>NextToken</c> request parameter set to the value of <c>NextToken</c> from
    /// the last response. 
    /// </para><para>
    /// Use this operation in an iterative process to retrieve a list of your snapshots. <c>DescribeSnapshots</c>
    /// is called first without a <c>NextToken</c> value. Then the operation continues to
    /// be called with the <c>NextToken</c> parameter set to the value of the last <c>NextToken</c>
    /// value until a response has no <c>NextToken</c> value.
    /// </para><para>
    /// When using this operation, keep the following in mind:
    /// </para><ul><li><para>
    /// The operation might return fewer than the <c>MaxResults</c> value of snapshot descriptions
    /// while still including a <c>NextToken</c> value.
    /// </para></li><li><para>
    /// The order of snapshots returned in the response of one <c>DescribeSnapshots</c> call
    /// and the order of backups returned across the responses of a multi-call iteration is
    /// unspecified. 
    /// </para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "FSXSnapshot")]
    [OutputType("Amazon.FSx.Model.Snapshot")]
    [AWSCmdlet("Calls the Amazon FSx DescribeSnapshots API operation.", Operation = new[] {"DescribeSnapshots"}, SelectReturnType = typeof(Amazon.FSx.Model.DescribeSnapshotsResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.Snapshot or Amazon.FSx.Model.DescribeSnapshotsResponse",
        "This cmdlet returns a collection of Amazon.FSx.Model.Snapshot objects.",
        "The service call response (type Amazon.FSx.Model.DescribeSnapshotsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetFSXSnapshotCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters structure. The supported names are <c>file-system-id</c> or <c>volume-id</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.FSx.Model.SnapshotFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter IncludeShared
        /// <summary>
        /// <para>
        /// <para>Set to <c>false</c> (default) if you want to only see the snapshots owned by your
        /// Amazon Web Services account. Set to <c>true</c> if you want to see the snapshots in
        /// your account and the ones shared with you from another account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeShared { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>The IDs of the snapshots that you want to retrieve. This parameter value overrides
        /// any filters. If any IDs aren't found, a <c>SnapshotNotFound</c> error occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnapshotIds")]
        public System.String[] SnapshotId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Snapshots'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.DescribeSnapshotsResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.DescribeSnapshotsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Snapshots";
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
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.DescribeSnapshotsResponse, GetFSXSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.FSx.Model.SnapshotFilter>(this.Filter);
            }
            context.IncludeShared = this.IncludeShared;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.SnapshotId != null)
            {
                context.SnapshotId = new List<System.String>(this.SnapshotId);
            }
            
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
            var request = new Amazon.FSx.Model.DescribeSnapshotsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.IncludeShared != null)
            {
                request.IncludeShared = cmdletContext.IncludeShared.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SnapshotId != null)
            {
                request.SnapshotIds = cmdletContext.SnapshotId;
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
        
        private Amazon.FSx.Model.DescribeSnapshotsResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.DescribeSnapshotsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "DescribeSnapshots");
            try
            {
                return client.DescribeSnapshotsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.FSx.Model.SnapshotFilter> Filter { get; set; }
            public System.Boolean? IncludeShared { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> SnapshotId { get; set; }
            public System.Func<Amazon.FSx.Model.DescribeSnapshotsResponse, GetFSXSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Snapshots;
        }
        
    }
}
