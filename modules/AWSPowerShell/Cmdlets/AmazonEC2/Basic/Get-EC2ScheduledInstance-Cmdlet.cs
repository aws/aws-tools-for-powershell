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
    /// Describes one or more of your Scheduled Instances.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "EC2ScheduledInstance")]
    [OutputType("Amazon.EC2.Model.ScheduledInstance")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DescribeScheduledInstances API operation.", Operation = new[] {"DescribeScheduledInstances"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ScheduledInstance",
        "This cmdlet returns a collection of ScheduledInstance objects.",
        "The service call response (type Amazon.EC2.Model.DescribeScheduledInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetEC2ScheduledInstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter SlotStartTimeRange_EarliestTime
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use EarliestTimeUtc instead. Setting either EarliestTime
        /// or EarliestTimeUtc results in both EarliestTime and EarliestTimeUtc being assigned,
        /// the latest assignment to either one of the two property is reflected in the value
        /// of both. EarliestTime is provided for backwards compatibility only and assigning a
        /// non-Utc DateTime to it results in the wrong timestamp being passed to the service.</para><para>The earliest date and time, in UTC, for the Scheduled Instance to start.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed t" +
            "o the service, use SlotStartTimeRange_UtcEarliestTime instead.")]
        public System.DateTime SlotStartTimeRange_EarliestTime { get; set; }
        #endregion
        
        #region Parameter SlotStartTimeRange_UtcEarliestTime
        /// <summary>
        /// <para>
        /// <para>The earliest date and time, in UTC, for the Scheduled Instance to start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime SlotStartTimeRange_UtcEarliestTime { get; set; }
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
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use LatestTimeUtc instead. Setting either LatestTime or
        /// LatestTimeUtc results in both LatestTime and LatestTimeUtc being assigned, the latest
        /// assignment to either one of the two property is reflected in the value of both. LatestTime
        /// is provided for backwards compatibility only and assigning a non-Utc DateTime to it
        /// results in the wrong timestamp being passed to the service.</para><para>The latest date and time, in UTC, for the Scheduled Instance to start.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed t" +
            "o the service, use SlotStartTimeRange_UtcLatestTime instead.")]
        public System.DateTime SlotStartTimeRange_LatestTime { get; set; }
        #endregion
        
        #region Parameter SlotStartTimeRange_UtcLatestTime
        /// <summary>
        /// <para>
        /// <para>The latest date and time, in UTC, for the Scheduled Instance to start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime SlotStartTimeRange_UtcLatestTime { get; set; }
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
        /// <para>The token for the next set of results.</para>
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
            if (this.ScheduledInstanceId != null)
            {
                context.ScheduledInstanceIds = new List<System.String>(this.ScheduledInstanceId);
            }
            if (ParameterWasBound("SlotStartTimeRange_UtcEarliestTime"))
                context.SlotStartTimeRange_UtcEarliestTime = this.SlotStartTimeRange_UtcEarliestTime;
            if (ParameterWasBound("SlotStartTimeRange_UtcLatestTime"))
                context.SlotStartTimeRange_UtcLatestTime = this.SlotStartTimeRange_UtcLatestTime;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("SlotStartTimeRange_EarliestTime"))
                context.SlotStartTimeRange_EarliestTime = this.SlotStartTimeRange_EarliestTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("SlotStartTimeRange_LatestTime"))
                context.SlotStartTimeRange_LatestTime = this.SlotStartTimeRange_LatestTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            System.DateTime? requestSlotStartTimeRange_slotStartTimeRange_UtcEarliestTime = null;
            if (cmdletContext.SlotStartTimeRange_UtcEarliestTime != null)
            {
                requestSlotStartTimeRange_slotStartTimeRange_UtcEarliestTime = cmdletContext.SlotStartTimeRange_UtcEarliestTime.Value;
            }
            if (requestSlotStartTimeRange_slotStartTimeRange_UtcEarliestTime != null)
            {
                request.SlotStartTimeRange.EarliestTimeUtc = requestSlotStartTimeRange_slotStartTimeRange_UtcEarliestTime.Value;
                requestSlotStartTimeRangeIsNull = false;
            }
            System.DateTime? requestSlotStartTimeRange_slotStartTimeRange_UtcLatestTime = null;
            if (cmdletContext.SlotStartTimeRange_UtcLatestTime != null)
            {
                requestSlotStartTimeRange_slotStartTimeRange_UtcLatestTime = cmdletContext.SlotStartTimeRange_UtcLatestTime.Value;
            }
            if (requestSlotStartTimeRange_slotStartTimeRange_UtcLatestTime != null)
            {
                request.SlotStartTimeRange.LatestTimeUtc = requestSlotStartTimeRange_slotStartTimeRange_UtcLatestTime.Value;
                requestSlotStartTimeRangeIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.DateTime? requestSlotStartTimeRange_slotStartTimeRange_EarliestTime = null;
            if (cmdletContext.SlotStartTimeRange_EarliestTime != null)
            {
                if (cmdletContext.SlotStartTimeRange_UtcEarliestTime != null)
                {
                    throw new ArgumentException("Parameters SlotStartTimeRange_EarliestTime and SlotStartTimeRange_UtcEarliestTime are mutually exclusive.");
                }
                requestSlotStartTimeRange_slotStartTimeRange_EarliestTime = cmdletContext.SlotStartTimeRange_EarliestTime.Value;
            }
            if (requestSlotStartTimeRange_slotStartTimeRange_EarliestTime != null)
            {
                request.SlotStartTimeRange.EarliestTime = requestSlotStartTimeRange_slotStartTimeRange_EarliestTime.Value;
                requestSlotStartTimeRangeIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.DateTime? requestSlotStartTimeRange_slotStartTimeRange_LatestTime = null;
            if (cmdletContext.SlotStartTimeRange_LatestTime != null)
            {
                if (cmdletContext.SlotStartTimeRange_UtcLatestTime != null)
                {
                    throw new ArgumentException("Parameters SlotStartTimeRange_LatestTime and SlotStartTimeRange_UtcLatestTime are mutually exclusive.");
                }
                requestSlotStartTimeRange_slotStartTimeRange_LatestTime = cmdletContext.SlotStartTimeRange_LatestTime.Value;
            }
            if (requestSlotStartTimeRange_slotStartTimeRange_LatestTime != null)
            {
                request.SlotStartTimeRange.LatestTime = requestSlotStartTimeRange_slotStartTimeRange_LatestTime.Value;
                requestSlotStartTimeRangeIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
        
        private Amazon.EC2.Model.DescribeScheduledInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeScheduledInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeScheduledInstances");
            try
            {
                #if DESKTOP
                return client.DescribeScheduledInstances(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeScheduledInstancesAsync(request);
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
            public List<System.String> ScheduledInstanceIds { get; set; }
            public System.DateTime? SlotStartTimeRange_UtcEarliestTime { get; set; }
            public System.DateTime? SlotStartTimeRange_UtcLatestTime { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? SlotStartTimeRange_EarliestTime { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? SlotStartTimeRange_LatestTime { get; set; }
        }
        
    }
}
