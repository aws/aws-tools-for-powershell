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
    /// Describes the specified Scheduled Instances or all your Scheduled Instances.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2ScheduledInstance")]
    [OutputType("Amazon.EC2.Model.ScheduledInstance")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeScheduledInstances API operation.", Operation = new[] {"DescribeScheduledInstances"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeScheduledInstancesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ScheduledInstance or Amazon.EC2.Model.DescribeScheduledInstancesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.ScheduledInstance objects.",
        "The service call response (type Amazon.EC2.Model.DescribeScheduledInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2ScheduledInstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter SlotStartTimeRange_UtcEarliestTime
        /// <summary>
        /// <para>
        /// <para>The earliest date and time, in UTC, for the Scheduled Instance to start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? SlotStartTimeRange_UtcEarliestTime { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><code>availability-zone</code> - The Availability Zone (for example, <code>us-west-2a</code>).</para></li><li><para><code>instance-type</code> - The instance type (for example, <code>c4.large</code>).</para></li><li><para><code>platform</code> - The platform (<code>Linux/UNIX</code> or <code>Windows</code>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter SlotStartTimeRange_UtcLatestTime
        /// <summary>
        /// <para>
        /// <para>The latest date and time, in UTC, for the Scheduled Instance to start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? SlotStartTimeRange_UtcLatestTime { get; set; }
        #endregion
        
        #region Parameter ScheduledInstanceId
        /// <summary>
        /// <para>
        /// <para>The Scheduled Instance IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScheduledInstanceIds")]
        public System.String[] ScheduledInstanceId { get; set; }
        #endregion
        
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use SlotStartTimeRange_UtcEarliestTime instead.")]
        public System.DateTime? SlotStartTimeRange_EarliestTime { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use SlotStartTimeRange_UtcLatestTime instead.")]
        public System.DateTime? SlotStartTimeRange_LatestTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. This value can be between
        /// 5 and 300. The default value is 100. To retrieve the remaining results, make another
        /// call with the returned <code>NextToken</code> value.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScheduledInstanceSet'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeScheduledInstancesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeScheduledInstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScheduledInstanceSet";
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
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeScheduledInstancesResponse, GetEC2ScheduledInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            if (this.ScheduledInstanceId != null)
            {
                context.ScheduledInstanceId = new List<System.String>(this.ScheduledInstanceId);
            }
            context.SlotStartTimeRange_UtcEarliestTime = this.SlotStartTimeRange_UtcEarliestTime;
            context.SlotStartTimeRange_UtcLatestTime = this.SlotStartTimeRange_UtcLatestTime;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SlotStartTimeRange_EarliestTime = this.SlotStartTimeRange_EarliestTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SlotStartTimeRange_LatestTime = this.SlotStartTimeRange_LatestTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeScheduledInstancesRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.ScheduledInstanceId != null)
            {
                request.ScheduledInstanceIds = cmdletContext.ScheduledInstanceId;
            }
            
             // populate SlotStartTimeRange
            var requestSlotStartTimeRangeIsNull = true;
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
                    throw new System.ArgumentException("Parameters SlotStartTimeRange_EarliestTime and SlotStartTimeRange_UtcEarliestTime are mutually exclusive.", nameof(this.SlotStartTimeRange_EarliestTime));
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
                    throw new System.ArgumentException("Parameters SlotStartTimeRange_LatestTime and SlotStartTimeRange_UtcLatestTime are mutually exclusive.", nameof(this.SlotStartTimeRange_LatestTime));
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeScheduledInstancesRequest();
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.ScheduledInstanceId != null)
            {
                request.ScheduledInstanceIds = cmdletContext.ScheduledInstanceId;
            }
            
             // populate SlotStartTimeRange
            var requestSlotStartTimeRangeIsNull = true;
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
                    throw new System.ArgumentException("Parameters SlotStartTimeRange_EarliestTime and SlotStartTimeRange_UtcEarliestTime are mutually exclusive.", nameof(this.SlotStartTimeRange_EarliestTime));
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
                    throw new System.ArgumentException("Parameters SlotStartTimeRange_LatestTime and SlotStartTimeRange_UtcLatestTime are mutually exclusive.", nameof(this.SlotStartTimeRange_LatestTime));
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
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
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
                    int _receivedThisCall = response.ScheduledInstanceSet.Count;
                    
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
        
        private Amazon.EC2.Model.DescribeScheduledInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeScheduledInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeScheduledInstances");
            try
            {
                #if DESKTOP
                return client.DescribeScheduledInstances(request);
                #elif CORECLR
                return client.DescribeScheduledInstancesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ScheduledInstanceId { get; set; }
            public System.DateTime? SlotStartTimeRange_UtcEarliestTime { get; set; }
            public System.DateTime? SlotStartTimeRange_UtcLatestTime { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? SlotStartTimeRange_EarliestTime { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? SlotStartTimeRange_LatestTime { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeScheduledInstancesResponse, GetEC2ScheduledInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScheduledInstanceSet;
        }
        
    }
}
