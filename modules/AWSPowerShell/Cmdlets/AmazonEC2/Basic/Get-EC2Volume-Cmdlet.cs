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
    /// Describes the specified EBS volumes.
    /// 
    ///  
    /// <para>
    /// If you are describing a long list of volumes, you can paginate the output to make
    /// the list more manageable. The <code>MaxResults</code> parameter sets the maximum number
    /// of results returned in a single page. If the list of results exceeds your <code>MaxResults</code>
    /// value, then that number of results is returned along with a <code>NextToken</code>
    /// value that can be passed to a subsequent <code>DescribeVolumes</code> request to retrieve
    /// the remaining results.
    /// </para><para>
    /// For more information about EBS volumes, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSVolumes.html">Amazon
    /// EBS Volumes</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2Volume")]
    [OutputType("Amazon.EC2.Model.Volume")]
    [AWSCmdlet("Invokes the DescribeVolumes operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeVolumes"})]
    [AWSCmdletOutput("Amazon.EC2.Model.Volume",
        "This cmdlet returns a collection of Volume objects.",
        "The service call response (type Amazon.EC2.Model.DescribeVolumesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetEC2VolumeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>attachment.attach-time</code> - The time stamp when the attachment initiated.</para></li><li><para><code>attachment.delete-on-termination</code> - Whether the volume is deleted on instance
        /// termination.</para></li><li><para><code>attachment.device</code> - The device name that is exposed to the instance (for
        /// example, <code>/dev/sda1</code>).</para></li><li><para><code>attachment.instance-id</code> - The ID of the instance the volume is attached
        /// to.</para></li><li><para><code>attachment.status</code> - The attachment state (<code>attaching</code> | <code>attached</code>
        /// | <code>detaching</code> | <code>detached</code>).</para></li><li><para><code>availability-zone</code> - The Availability Zone in which the volume was created.</para></li><li><para><code>create-time</code> - The time stamp when the volume was created.</para></li><li><para><code>encrypted</code> - The encryption status of the volume.</para></li><li><para><code>size</code> - The size of the volume, in GiB.</para></li><li><para><code>snapshot-id</code> - The snapshot from which the volume was created.</para></li><li><para><code>status</code> - The status of the volume (<code>creating</code> | <code>available</code>
        /// | <code>in-use</code> | <code>deleting</code> | <code>deleted</code> | <code>error</code>).</para></li><li><para><code>tag</code>:<i>key</i>=<i>value</i> - The key/value combination of a tag assigned
        /// to the resource.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. This filter is independent
        /// of the <code>tag-value</code> filter. For example, if you use both the filter "tag-key=Purpose"
        /// and the filter "tag-value=X", you get any resources assigned both the tag key Purpose
        /// (regardless of what the tag's value is), and the tag value X (regardless of what the
        /// tag's key is). If you want to list only resources where Purpose is X, see the <code>tag</code>:<i>key</i>=<i>value</i>
        /// filter.</para></li><li><para><code>tag-value</code> - The value of a tag assigned to the resource. This filter
        /// is independent of the <code>tag-key</code> filter.</para></li><li><para><code>volume-id</code> - The volume ID.</para></li><li><para><code>volume-type</code> - The Amazon EBS volume type. This can be <code>gp2</code>
        /// for General Purpose (SSD) volumes, <code>io1</code> for Provisioned IOPS (SSD) volumes,
        /// or <code>standard</code> for Magnetic volumes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more volume IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("VolumeIds")]
        public System.String[] VolumeId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum number of volume results returned by <code>DescribeVolumes</code> in paginated
        /// output. When this parameter is used, <code>DescribeVolumes</code> only returns <code>MaxResults</code>
        /// results in a single page along with a <code>NextToken</code> response element. The
        /// remaining results of the initial request can be seen by sending another <code>DescribeVolumes</code>
        /// request with the returned <code>NextToken</code> value. This value can be between
        /// 5 and 1000; if <code>MaxResults</code> is given a value larger than 1000, only 1000
        /// results are returned. If this parameter is not used, then <code>DescribeVolumes</code>
        /// returns all results. You cannot specify this parameter and the volume IDs parameter
        /// in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The <code>NextToken</code> value returned from a previous paginated <code>DescribeVolumes</code>
        /// request where <code>MaxResults</code> was used and the results exceeded the value
        /// of that parameter. Pagination continues from the end of the previous results that
        /// returned the <code>NextToken</code> value. This value is <code>null</code> when there
        /// are no more results to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.VolumeId != null)
            {
                context.VolumeIds = new List<System.String>(this.VolumeId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeVolumesRequest();
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.VolumeIds != null)
            {
                request.VolumeIds = cmdletContext.VolumeIds;
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
                        
                        var response = client.DescribeVolumes(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Volumes;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Volumes.Count;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> VolumeIds { get; set; }
        }
        
    }
}
