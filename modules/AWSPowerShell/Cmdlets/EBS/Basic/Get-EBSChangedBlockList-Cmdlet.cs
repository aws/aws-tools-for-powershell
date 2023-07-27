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
using Amazon.EBS;
using Amazon.EBS.Model;

namespace Amazon.PowerShell.Cmdlets.EBS
{
    /// <summary>
    /// Returns information about the blocks that are different between two Amazon Elastic
    /// Block Store snapshots of the same volume/snapshot lineage.
    /// 
    ///  <note><para>
    /// You should always retry requests that receive server (<code>5xx</code>) error responses,
    /// and <code>ThrottlingException</code> and <code>RequestThrottledException</code> client
    /// error responses. For more information see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/error-retries.html">Error
    /// retries</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EBSChangedBlockList")]
    [OutputType("Amazon.EBS.Model.ChangedBlock")]
    [AWSCmdlet("Calls the Amazon EBS ListChangedBlocks API operation.", Operation = new[] {"ListChangedBlocks"}, SelectReturnType = typeof(Amazon.EBS.Model.ListChangedBlocksResponse))]
    [AWSCmdletOutput("Amazon.EBS.Model.ChangedBlock or Amazon.EBS.Model.ListChangedBlocksResponse",
        "This cmdlet returns a collection of Amazon.EBS.Model.ChangedBlock objects.",
        "The service call response (type Amazon.EBS.Model.ListChangedBlocksResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEBSChangedBlockListCmdlet : AmazonEBSClientCmdlet, IExecutor
    {
        
        #region Parameter FirstSnapshotId
        /// <summary>
        /// <para>
        /// <para>The ID of the first snapshot to use for the comparison.</para><important><para>The <code>FirstSnapshotID</code> parameter must be specified with a <code>SecondSnapshotId</code>
        /// parameter; otherwise, an error occurs.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirstSnapshotId { get; set; }
        #endregion
        
        #region Parameter SecondSnapshotId
        /// <summary>
        /// <para>
        /// <para>The ID of the second snapshot to use for the comparison.</para><important><para>The <code>SecondSnapshotId</code> parameter must be specified with a <code>FirstSnapshotID</code>
        /// parameter; otherwise, an error occurs.</para></important>
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
        public System.String SecondSnapshotId { get; set; }
        #endregion
        
        #region Parameter StartingBlockIndex
        /// <summary>
        /// <para>
        /// <para>The block index from which the comparison should start.</para><para>The list in the response will start from this block index or the next valid block
        /// index in the snapshots.</para><para>If you specify <b>NextToken</b>, then <b>StartingBlockIndex</b> is ignored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StartingBlockIndex { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of blocks to be returned by the request.</para><para>Even if additional blocks can be retrieved from the snapshot, the request can return
        /// less blocks than <b>MaxResults</b> or an empty array of blocks.</para><para>To retrieve the next set of blocks from the snapshot, make another request with the
        /// returned <b>NextToken</b> value. The value of <b>NextToken</b> is <code>null</code>
        /// when there are no more blocks to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to request the next page of results.</para><para>If you specify <b>NextToken</b>, then <b>StartingBlockIndex</b> is ignored.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChangedBlocks'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EBS.Model.ListChangedBlocksResponse).
        /// Specifying the name of a property of type Amazon.EBS.Model.ListChangedBlocksResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChangedBlocks";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SecondSnapshotId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SecondSnapshotId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SecondSnapshotId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EBS.Model.ListChangedBlocksResponse, GetEBSChangedBlockListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SecondSnapshotId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FirstSnapshotId = this.FirstSnapshotId;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SecondSnapshotId = this.SecondSnapshotId;
            #if MODULAR
            if (this.SecondSnapshotId == null && ParameterWasBound(nameof(this.SecondSnapshotId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecondSnapshotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartingBlockIndex = this.StartingBlockIndex;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.EBS.Model.ListChangedBlocksRequest();
            
            if (cmdletContext.FirstSnapshotId != null)
            {
                request.FirstSnapshotId = cmdletContext.FirstSnapshotId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SecondSnapshotId != null)
            {
                request.SecondSnapshotId = cmdletContext.SecondSnapshotId;
            }
            if (cmdletContext.StartingBlockIndex != null)
            {
                request.StartingBlockIndex = cmdletContext.StartingBlockIndex.Value;
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
        
        private Amazon.EBS.Model.ListChangedBlocksResponse CallAWSServiceOperation(IAmazonEBS client, Amazon.EBS.Model.ListChangedBlocksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EBS", "ListChangedBlocks");
            try
            {
                #if DESKTOP
                return client.ListChangedBlocks(request);
                #elif CORECLR
                return client.ListChangedBlocksAsync(request).GetAwaiter().GetResult();
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
            public System.String FirstSnapshotId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String SecondSnapshotId { get; set; }
            public System.Int32? StartingBlockIndex { get; set; }
            public System.Func<Amazon.EBS.Model.ListChangedBlocksResponse, GetEBSChangedBlockListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChangedBlocks;
        }
        
    }
}
