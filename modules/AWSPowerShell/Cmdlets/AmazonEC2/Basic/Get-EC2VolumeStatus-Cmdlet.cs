/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Describes the status of the specified volumes. Volume status provides the result of
    /// the checks performed on your volumes to determine events that can impair the performance
    /// of your volumes. The performance of a volume can be affected if an issue occurs on
    /// the volume's underlying host. If the volume's underlying host experiences a power
    /// outage or system issue, after the system is restored, there could be data inconsistencies
    /// on the volume. Volume events notify you if this occurs. Volume actions notify you
    /// if any action needs to be taken in response to the event.
    /// 
    ///  
    /// <para>
    /// The <code>DescribeVolumeStatus</code> operation provides the following information
    /// about the specified volumes:
    /// </para><para><i>Status</i>: Reflects the current status of the volume. The possible values are
    /// <code>ok</code>, <code>impaired</code> , <code>warning</code>, or <code>insufficient-data</code>.
    /// If all checks pass, the overall status of the volume is <code>ok</code>. If the check
    /// fails, the overall status is <code>impaired</code>. If the status is <code>insufficient-data</code>,
    /// then the checks may still be taking place on your volume at the time. We recommend
    /// that you retry the request. For more information about volume status, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/monitoring-volume-status.html">Monitoring
    /// the Status of Your Volumes</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para><para><i>Events</i>: Reflect the cause of a volume status and may require you to take action.
    /// For example, if your volume returns an <code>impaired</code> status, then the volume
    /// event might be <code>potential-data-inconsistency</code>. This means that your volume
    /// has been affected by an issue with the underlying host, has all I/O operations disabled,
    /// and may have inconsistent data.
    /// </para><para><i>Actions</i>: Reflect the actions you may have to take in response to an event.
    /// For example, if the status of the volume is <code>impaired</code> and the volume event
    /// shows <code>potential-data-inconsistency</code>, then the action shows <code>enable-volume-io</code>.
    /// This means that you may want to enable the I/O operations for the volume by calling
    /// the <a>EnableVolumeIO</a> action and then check the volume for data consistency.
    /// </para><para>
    /// Volume status is based on the volume status checks, and does not reflect the volume
    /// state. Therefore, volume status does not indicate volumes in the <code>error</code>
    /// state (for example, when a volume is incapable of accepting I/O.)
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "EC2VolumeStatus")]
    [OutputType("Amazon.EC2.Model.VolumeStatusItem")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DescribeVolumeStatus API operation.", Operation = new[] {"DescribeVolumeStatus"})]
    [AWSCmdletOutput("Amazon.EC2.Model.VolumeStatusItem",
        "This cmdlet returns a collection of VolumeStatusItem objects.",
        "The service call response (type Amazon.EC2.Model.DescribeVolumeStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetEC2VolumeStatusCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>action.code</code> - The action code for the event (for example, <code>enable-volume-io</code>).</para></li><li><para><code>action.description</code> - A description of the action.</para></li><li><para><code>action.event-id</code> - The event ID associated with the action.</para></li><li><para><code>availability-zone</code> - The Availability Zone of the instance.</para></li><li><para><code>event.description</code> - A description of the event.</para></li><li><para><code>event.event-id</code> - The event ID.</para></li><li><para><code>event.event-type</code> - The event type (for <code>io-enabled</code>: <code>passed</code>
        /// | <code>failed</code>; for <code>io-performance</code>: <code>io-performance:degraded</code>
        /// | <code>io-performance:severely-degraded</code> | <code>io-performance:stalled</code>).</para></li><li><para><code>event.not-after</code> - The latest end time for the event.</para></li><li><para><code>event.not-before</code> - The earliest start time for the event.</para></li><li><para><code>volume-status.details-name</code> - The cause for <code>volume-status.status</code>
        /// (<code>io-enabled</code> | <code>io-performance</code>).</para></li><li><para><code>volume-status.details-status</code> - The status of <code>volume-status.details-name</code>
        /// (for <code>io-enabled</code>: <code>passed</code> | <code>failed</code>; for <code>io-performance</code>:
        /// <code>normal</code> | <code>degraded</code> | <code>severely-degraded</code> | <code>stalled</code>).</para></li><li><para><code>volume-status.status</code> - The status of the volume (<code>ok</code> | <code>impaired</code>
        /// | <code>warning</code> | <code>insufficient-data</code>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter VolumeId
        /// <summary>
        /// <para>
        /// <para>One or more volume IDs.</para><para>Default: Describes all your volumes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("VolumeIds")]
        public System.String[] VolumeId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of volume results returned by <code>DescribeVolumeStatus</code>
        /// in paginated output. When this parameter is used, the request only returns <code>MaxResults</code>
        /// results in a single page along with a <code>NextToken</code> response element. The
        /// remaining results of the initial request can be seen by sending another request with
        /// the returned <code>NextToken</code> value. This value can be between 5 and 1000; if
        /// <code>MaxResults</code> is given a value larger than 1000, only 1000 results are returned.
        /// If this parameter is not used, then <code>DescribeVolumeStatus</code> returns all
        /// results. You cannot specify this parameter and the volume IDs parameter in the same
        /// request.</para>
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
        /// <para>The <code>NextToken</code> value to include in a future <code>DescribeVolumeStatus</code>
        /// request. When the results of the request exceed <code>MaxResults</code>, this value
        /// can be used to retrieve the next page of results. This value is <code>null</code>
        /// when there are no more results to return.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
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
            if (this.VolumeId != null)
            {
                context.VolumeIds = new List<System.String>(this.VolumeId);
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
            var request = new Amazon.EC2.Model.DescribeVolumeStatusRequest();
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
            bool _userControllingPaging = ParameterWasBound("NextToken") || ParameterWasBound("MaxResult");
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
                        object pipelineOutput = response.VolumeStatuses;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.VolumeStatuses.Count;
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
        
        private Amazon.EC2.Model.DescribeVolumeStatusResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeVolumeStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeVolumeStatus");
            try
            {
                #if DESKTOP
                return client.DescribeVolumeStatus(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeVolumeStatusAsync(request);
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
            public List<System.String> VolumeIds { get; set; }
        }
        
    }
}
