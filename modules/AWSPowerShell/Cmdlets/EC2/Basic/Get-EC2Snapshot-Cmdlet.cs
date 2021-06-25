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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the specified EBS snapshots available to you or all of the EBS snapshots
    /// available to you.
    /// 
    ///  
    /// <para>
    /// The snapshots available to you include public snapshots, private snapshots that you
    /// own, and private snapshots owned by other Amazon Web Services accounts for which you
    /// have explicit create volume permissions.
    /// </para><para>
    /// The create volume permissions fall into the following categories:
    /// </para><ul><li><para><i>public</i>: The owner of the snapshot granted create volume permissions for the
    /// snapshot to the <code>all</code> group. All Amazon Web Services accounts have create
    /// volume permissions for these snapshots.
    /// </para></li><li><para><i>explicit</i>: The owner of the snapshot granted create volume permissions to a
    /// specific Amazon Web Services account.
    /// </para></li><li><para><i>implicit</i>: An Amazon Web Services account has implicit create volume permissions
    /// for all snapshots it owns.
    /// </para></li></ul><para>
    /// The list of snapshots returned can be filtered by specifying snapshot IDs, snapshot
    /// owners, or Amazon Web Services accounts with create volume permissions. If no options
    /// are specified, Amazon EC2 returns all snapshots for which you have create volume permissions.
    /// </para><para>
    /// If you specify one or more snapshot IDs, only snapshots that have the specified IDs
    /// are returned. If you specify an invalid snapshot ID, an error is returned. If you
    /// specify a snapshot ID for which you do not have access, it is not included in the
    /// returned results.
    /// </para><para>
    /// If you specify one or more snapshot owners using the <code>OwnerIds</code> option,
    /// only snapshots from the specified owners and for which you have access are returned.
    /// The results can include the Amazon Web Services account IDs of the specified owners,
    /// <code>amazon</code> for snapshots owned by Amazon, or <code>self</code> for snapshots
    /// that you own.
    /// </para><para>
    /// If you specify a list of restorable users, only snapshots with create snapshot permissions
    /// for those users are returned. You can specify Amazon Web Services account IDs (if
    /// you own the snapshots), <code>self</code> for snapshots for which you own or have
    /// explicit permissions, or <code>all</code> for public snapshots.
    /// </para><para>
    /// If you are describing a long list of snapshots, we recommend that you paginate the
    /// output to make the list more manageable. The <code>MaxResults</code> parameter sets
    /// the maximum number of results returned in a single page. If the list of results exceeds
    /// your <code>MaxResults</code> value, then that number of results is returned along
    /// with a <code>NextToken</code> value that can be passed to a subsequent <code>DescribeSnapshots</code>
    /// request to retrieve the remaining results.
    /// </para><para>
    /// To get the state of fast snapshot restores for a snapshot, use <a>DescribeFastSnapshotRestores</a>.
    /// </para><para>
    /// For more information about EBS snapshots, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSSnapshots.html">Amazon
    /// EBS snapshots</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2Snapshot", DefaultParameterSetName="ByFilter")]
    [OutputType("Amazon.EC2.Model.Snapshot")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeSnapshots API operation.", Operation = new[] {"DescribeSnapshots"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeSnapshotsResponse), LegacyAlias="Get-EC2Snapshots")]
    [AWSCmdletOutput("Amazon.EC2.Model.Snapshot or Amazon.EC2.Model.DescribeSnapshotsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.Snapshot objects.",
        "The service call response (type Amazon.EC2.Model.DescribeSnapshotsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2SnapshotCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><code>description</code> - A description of the snapshot.</para></li><li><para><code>encrypted</code> - Indicates whether the snapshot is encrypted (<code>true</code>
        /// | <code>false</code>)</para></li><li><para><code>owner-alias</code> - The owner alias, from an Amazon-maintained list (<code>amazon</code>).
        /// This is not the user-configured Amazon Web Services account alias set using the IAM
        /// console. We recommend that you use the related parameter instead of this filter.</para></li><li><para><code>owner-id</code> - The Amazon Web Services account ID of the owner. We recommend
        /// that you use the related parameter instead of this filter.</para></li><li><para><code>progress</code> - The progress of the snapshot, as a percentage (for example,
        /// 80%).</para></li><li><para><code>snapshot-id</code> - The snapshot ID.</para></li><li><para><code>start-time</code> - The time stamp when the snapshot was initiated.</para></li><li><para><code>status</code> - The status of the snapshot (<code>pending</code> | <code>completed</code>
        /// | <code>error</code>).</para></li><li><para><code>tag</code>:&lt;key&gt; - The key/value combination of a tag assigned to the
        /// resource. Use the tag key in the filter name and the tag value as the filter value.
        /// For example, to find all resources that have a tag with the key <code>Owner</code>
        /// and the value <code>TeamA</code>, specify <code>tag:Owner</code> for the filter name
        /// and <code>TeamA</code> for the filter value.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. Use this filter
        /// to find all resources assigned a tag with a specific key, regardless of the tag value.</para></li><li><para><code>volume-id</code> - The ID of the volume the snapshot is for.</para></li><li><para><code>volume-size</code> - The size of the volume, in GiB.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = "ByFilter")]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter OwnerId
        /// <summary>
        /// <para>
        /// <para>Scopes the results to snapshots with the specified owners. You can specify a combination
        /// of Amazon Web Services account IDs, <code>self</code>, and <code>amazon</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = "ByFilter")]
        [Alias("OwnerIds")]
        public System.String[] OwnerId { get; set; }
        #endregion
        
        #region Parameter RestorableByUserId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Amazon Web Services accounts that can create volumes from the snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = "ByFilter")]
        [Alias("RestorableByUserIds")]
        public System.String[] RestorableByUserId { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>The snapshot IDs.</para><para>Default: Describes the snapshots for which you have create volume permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, ParameterSetName = "ByID")]
        [Alias("SnapshotIds")]
        public System.String[] SnapshotId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of snapshot results returned by <code>DescribeSnapshots</code>
        /// in paginated output. When this parameter is used, <code>DescribeSnapshots</code> only
        /// returns <code>MaxResults</code> results in a single page along with a <code>NextToken</code>
        /// response element. The remaining results of the initial request can be seen by sending
        /// another <code>DescribeSnapshots</code> request with the returned <code>NextToken</code>
        /// value. This value can be between 5 and 1,000; if <code>MaxResults</code> is given
        /// a value larger than 1,000, only 1,000 results are returned. If this parameter is not
        /// used, then <code>DescribeSnapshots</code> returns all results. You cannot specify
        /// this parameter and the snapshot IDs parameter in the same request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = "ByFilter")]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>NextToken</code> value returned from a previous paginated <code>DescribeSnapshots</code>
        /// request where <code>MaxResults</code> was used and the results exceeded the value
        /// of that parameter. Pagination continues from the end of the previous results that
        /// returned the <code>NextToken</code> value. This value is <code>null</code> when there
        /// are no more results to return.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = "ByFilter")]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Snapshots'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeSnapshotsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeSnapshotsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Snapshots";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SnapshotId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SnapshotId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SnapshotId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeSnapshotsResponse, GetEC2SnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SnapshotId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
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
            if (this.OwnerId != null)
            {
                context.OwnerId = new List<System.String>(this.OwnerId);
            }
            if (this.RestorableByUserId != null)
            {
                context.RestorableByUserId = new List<System.String>(this.RestorableByUserId);
            }
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
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeSnapshotsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.OwnerId != null)
            {
                request.OwnerIds = cmdletContext.OwnerId;
            }
            if (cmdletContext.RestorableByUserId != null)
            {
                request.RestorableByUserIds = cmdletContext.RestorableByUserId;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeSnapshotsRequest();
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.OwnerId != null)
            {
                request.OwnerIds = cmdletContext.OwnerId;
            }
            if (cmdletContext.RestorableByUserId != null)
            {
                request.RestorableByUserIds = cmdletContext.RestorableByUserId;
            }
            if (cmdletContext.SnapshotId != null)
            {
                request.SnapshotIds = cmdletContext.SnapshotId;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(1000, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                
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
                    int _receivedThisCall = response.Snapshots.Count;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.EC2.Model.DescribeSnapshotsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeSnapshotsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeSnapshots");
            try
            {
                #if DESKTOP
                return client.DescribeSnapshots(request);
                #elif CORECLR
                return client.DescribeSnapshotsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> OwnerId { get; set; }
            public List<System.String> RestorableByUserId { get; set; }
            public List<System.String> SnapshotId { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeSnapshotsResponse, GetEC2SnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Snapshots;
        }
        
    }
}
