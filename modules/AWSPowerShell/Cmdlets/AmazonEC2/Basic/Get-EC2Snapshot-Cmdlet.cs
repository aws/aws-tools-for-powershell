/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Describes one or more of the EBS snapshots available to you. Available snapshots include
    /// public snapshots available for any AWS account to launch, private snapshots that you
    /// own, and private snapshots owned by another AWS account but for which you've been
    /// given explicit create volume permissions.
    /// 
    ///  
    /// <para>
    /// The create volume permissions fall into the following categories:
    /// </para><ul><li><para><i>public</i>: The owner of the snapshot granted create volume permissions for the
    /// snapshot to the <code>all</code> group. All AWS accounts have create volume permissions
    /// for these snapshots.
    /// </para></li><li><para><i>explicit</i>: The owner of the snapshot granted create volume permissions to a
    /// specific AWS account.
    /// </para></li><li><para><i>implicit</i>: An AWS account has implicit create volume permissions for all snapshots
    /// it owns.
    /// </para></li></ul><para>
    /// The list of snapshots returned can be modified by specifying snapshot IDs, snapshot
    /// owners, or AWS accounts with create volume permissions. If no options are specified,
    /// Amazon EC2 returns all snapshots for which you have create volume permissions.
    /// </para><para>
    /// If you specify one or more snapshot IDs, only snapshots that have the specified IDs
    /// are returned. If you specify an invalid snapshot ID, an error is returned. If you
    /// specify a snapshot ID for which you do not have access, it is not included in the
    /// returned results.
    /// </para><para>
    /// If you specify one or more snapshot owners using the <code>OwnerIds</code> option,
    /// only snapshots from the specified owners and for which you have access are returned.
    /// The results can include the AWS account IDs of the specified owners, <code>amazon</code>
    /// for snapshots owned by Amazon, or <code>self</code> for snapshots that you own.
    /// </para><para>
    /// If you specify a list of restorable users, only snapshots with create snapshot permissions
    /// for those users are returned. You can specify AWS account IDs (if you own the snapshots),
    /// <code>self</code> for snapshots for which you own or have explicit permissions, or
    /// <code>all</code> for public snapshots.
    /// </para><para>
    /// If you are describing a long list of snapshots, you can paginate the output to make
    /// the list more manageable. The <code>MaxResults</code> parameter sets the maximum number
    /// of results returned in a single page. If the list of results exceeds your <code>MaxResults</code>
    /// value, then that number of results is returned along with a <code>NextToken</code>
    /// value that can be passed to a subsequent <code>DescribeSnapshots</code> request to
    /// retrieve the remaining results.
    /// </para><para>
    /// For more information about EBS snapshots, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSSnapshots.html">Amazon
    /// EBS Snapshots</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "EC2Snapshot")]
    [OutputType("Amazon.EC2.Model.Snapshot")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DescribeSnapshots API operation.", Operation = new[] {"DescribeSnapshots"})]
    [AWSCmdletOutput("Amazon.EC2.Model.Snapshot",
        "This cmdlet returns a collection of Snapshot objects.",
        "The service call response (type Amazon.EC2.Model.DescribeSnapshotsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetEC2SnapshotCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>description</code> - A description of the snapshot.</para></li><li><para><code>owner-alias</code> - Value from an Amazon-maintained list (<code>amazon</code>
        /// | <code>aws-marketplace</code> | <code>microsoft</code>) of snapshot owners. Not to
        /// be confused with the user-configured AWS account alias, which is set from the IAM
        /// console.</para></li><li><para><code>owner-id</code> - The ID of the AWS account that owns the snapshot.</para></li><li><para><code>progress</code> - The progress of the snapshot, as a percentage (for example,
        /// 80%).</para></li><li><para><code>snapshot-id</code> - The snapshot ID.</para></li><li><para><code>start-time</code> - The time stamp when the snapshot was initiated.</para></li><li><para><code>status</code> - The status of the snapshot (<code>pending</code> | <code>completed</code>
        /// | <code>error</code>).</para></li><li><para><code>tag</code>:<i>key</i>=<i>value</i> - The key/value combination of a tag assigned
        /// to the resource. Specify the key of the tag in the filter name and the value of the
        /// tag in the filter value. For example, for the tag Purpose=X, specify <code>tag:Purpose</code>
        /// for the filter name and <code>X</code> for the filter value.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. This filter is
        /// independent of the <code>tag-value</code> filter. For example, if you use both the
        /// filter "tag-key=Purpose" and the filter "tag-value=X", you get any resources assigned
        /// both the tag key Purpose (regardless of what the tag's value is), and the tag value
        /// X (regardless of what the tag's key is). If you want to list only resources where
        /// Purpose is X, see the <code>tag</code>:<i>key</i>=<i>value</i> filter.</para></li><li><para><code>tag-value</code> - The value of a tag assigned to the resource. This filter
        /// is independent of the <code>tag-key</code> filter.</para></li><li><para><code>volume-id</code> - The ID of the volume the snapshot is for.</para></li><li><para><code>volume-size</code> - The size of the volume, in GiB.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter OwnerId
        /// <summary>
        /// <para>
        /// <para>Returns the snapshots owned by the specified owner. Multiple owners can be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("OwnerIds")]
        public System.String[] OwnerId { get; set; }
        #endregion
        
        #region Parameter RestorableByUserId
        /// <summary>
        /// <para>
        /// <para>One or more AWS accounts IDs that can create volumes from the snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("RestorableByUserIds")]
        public System.String[] RestorableByUserId { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>One or more snapshot IDs.</para><para>Default: Describes snapshots for which you have launch permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
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
        /// value. This value can be between 5 and 1000; if <code>MaxResults</code> is given a
        /// value larger than 1000, only 1000 results are returned. If this parameter is not used,
        /// then <code>DescribeSnapshots</code> returns all results. You cannot specify this parameter
        /// and the snapshot IDs parameter in the same request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
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
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.OwnerId != null)
            {
                context.OwnerIds = new List<System.String>(this.OwnerId);
            }
            if (this.RestorableByUserId != null)
            {
                context.RestorableByUserIds = new List<System.String>(this.RestorableByUserId);
            }
            if (this.SnapshotId != null)
            {
                context.SnapshotIds = new List<System.String>(this.SnapshotId);
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
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeSnapshotsRequest();
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.OwnerIds != null)
            {
                request.OwnerIds = cmdletContext.OwnerIds;
            }
            if (cmdletContext.RestorableByUserIds != null)
            {
                request.RestorableByUserIds = cmdletContext.RestorableByUserIds;
            }
            if (cmdletContext.SnapshotIds != null)
            {
                request.SnapshotIds = cmdletContext.SnapshotIds;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.MaxResults);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Snapshots;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Snapshots.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.EC2.Model.DescribeSnapshotsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeSnapshotsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeSnapshots");
            try
            {
                #if DESKTOP
                return client.DescribeSnapshots(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeSnapshotsAsync(request);
                return task.Result;
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
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> OwnerIds { get; set; }
            public List<System.String> RestorableByUserIds { get; set; }
            public List<System.String> SnapshotIds { get; set; }
        }
        
    }
}
