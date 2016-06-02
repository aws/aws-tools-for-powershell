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
    /// Describes one or more of your Scheduled Instances.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "EC2ScheduledInstance")]
    [OutputType("Amazon.EC2.Model.ScheduledInstance")]
    [AWSCmdlet("Invokes the DescribeScheduledInstances operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeScheduledInstances"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ScheduledInstance",
        "This cmdlet returns a collection of ScheduledInstance objects.",
        "The service call response (type Amazon.EC2.Model.DescribeScheduledInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetEC2ScheduledInstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter SlotStartTimeRange_EarliestTime
        /// <summary>
        /// <para>
        /// <para>The earliest date and time, in UTC, for the Scheduled Instance to start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime SlotStartTimeRange_EarliestTime { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>availability-zone</code> - The Availability Zone (for example, <code>us-west-2a</code>).</para></li><li><para><code>instance-type</code> - The instance type (for example, <code>c4.large</code>).</para></li><li><para><code>network-platform</code> - The network platform (<code>EC2-Classic</code> or
        /// <code>EC2-VPC</code>).</para></li><li><para><code>platform</code> - The platform (<code>Linux/UNIX</code> or <code>Windows</code>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter SlotStartTimeRange_LatestTime
        /// <summary>
        /// <para>
        /// <para>The latest date and time, in UTC, for the Scheduled Instance to start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime SlotStartTimeRange_LatestTime { get; set; }
        #endregion
        
        #region Parameter ScheduledInstanceId
        /// <summary>
        /// <para>
        /// <para>One or more Scheduled Instance IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScheduledInstanceIds")]
        public System.String[] ScheduledInstanceId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. This value can be between
        /// 5 and 300. The default value is 100. To retrieve the remaining results, make another
        /// call with the returned <code>NextToken</code> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results.</para>
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
            
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.ScheduledInstanceId != null)
            {
                context.ScheduledInstanceIds = new List<System.String>(this.ScheduledInstanceId);
            }
            if (ParameterWasBound("SlotStartTimeRange_EarliestTime"))
                context.SlotStartTimeRange_EarliestTime = this.SlotStartTimeRange_EarliestTime;
            if (ParameterWasBound("SlotStartTimeRange_LatestTime"))
                context.SlotStartTimeRange_LatestTime = this.SlotStartTimeRange_LatestTime;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeScheduledInstancesRequest();
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.ScheduledInstanceIds != null)
            {
                request.ScheduledInstanceIds = cmdletContext.ScheduledInstanceIds;
            }
            
             // populate SlotStartTimeRange
            bool requestSlotStartTimeRangeIsNull = true;
            request.SlotStartTimeRange = new Amazon.EC2.Model.SlotStartTimeRangeRequest();
            System.DateTime? requestSlotStartTimeRange_slotStartTimeRange_EarliestTime = null;
            if (cmdletContext.SlotStartTimeRange_EarliestTime != null)
            {
                requestSlotStartTimeRange_slotStartTimeRange_EarliestTime = cmdletContext.SlotStartTimeRange_EarliestTime.Value;
            }
            if (requestSlotStartTimeRange_slotStartTimeRange_EarliestTime != null)
            {
                request.SlotStartTimeRange.EarliestTime = requestSlotStartTimeRange_slotStartTimeRange_EarliestTime.Value;
                requestSlotStartTimeRangeIsNull = false;
            }
            System.DateTime? requestSlotStartTimeRange_slotStartTimeRange_LatestTime = null;
            if (cmdletContext.SlotStartTimeRange_LatestTime != null)
            {
                requestSlotStartTimeRange_slotStartTimeRange_LatestTime = cmdletContext.SlotStartTimeRange_LatestTime.Value;
            }
            if (requestSlotStartTimeRange_slotStartTimeRange_LatestTime != null)
            {
                request.SlotStartTimeRange.LatestTime = requestSlotStartTimeRange_slotStartTimeRange_LatestTime.Value;
                requestSlotStartTimeRangeIsNull = false;
            }
             // determine if request.SlotStartTimeRange should be set to null
            if (requestSlotStartTimeRangeIsNull)
            {
                request.SlotStartTimeRange = null;
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
                        object pipelineOutput = response.ScheduledInstanceSet;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.ScheduledInstanceSet.Count;
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
        
        private static Amazon.EC2.Model.DescribeScheduledInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeScheduledInstancesRequest request)
        {
            return client.DescribeScheduledInstances(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> ScheduledInstanceIds { get; set; }
            public System.DateTime? SlotStartTimeRange_EarliestTime { get; set; }
            public System.DateTime? SlotStartTimeRange_LatestTime { get; set; }
        }
        
    }
}
