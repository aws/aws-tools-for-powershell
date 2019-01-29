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
    /// Describes the status of one or more instances. By default, only running instances
    /// are described, unless you specifically indicate to return the status of all instances.
    /// 
    ///  
    /// <para>
    /// Instance status includes the following components:
    /// </para><ul><li><para><b>Status checks</b> - Amazon EC2 performs status checks on running EC2 instances
    /// to identify hardware and software issues. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/monitoring-system-instance-status-check.html">Status
    /// Checks for Your Instances</a> and <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/TroubleshootingInstances.html">Troubleshooting
    /// Instances with Failed Status Checks</a> in the <i>Amazon Elastic Compute Cloud User
    /// Guide</i>.
    /// </para></li><li><para><b>Scheduled events</b> - Amazon EC2 can schedule events (such as reboot, stop, or
    /// terminate) for your instances related to hardware issues, software updates, or system
    /// maintenance. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/monitoring-instances-status-check_sched.html">Scheduled
    /// Events for Your Instances</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para></li><li><para><b>Instance state</b> - You can manage your instances from the moment you launch
    /// them through their termination. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-instance-lifecycle.html">Instance
    /// Lifecycle</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para></li></ul><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "EC2InstanceStatus")]
    [OutputType("Amazon.EC2.Model.InstanceStatus")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DescribeInstanceStatus API operation.", Operation = new[] {"DescribeInstanceStatus"})]
    [AWSCmdletOutput("Amazon.EC2.Model.InstanceStatus",
        "This cmdlet returns a collection of InstanceStatus objects.",
        "The service call response (type Amazon.EC2.Model.DescribeInstanceStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetEC2InstanceStatusCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>availability-zone</code> - The Availability Zone of the instance.</para></li><li><para><code>event.code</code> - The code for the scheduled event (<code>instance-reboot</code>
        /// | <code>system-reboot</code> | <code>system-maintenance</code> | <code>instance-retirement</code>
        /// | <code>instance-stop</code>).</para></li><li><para><code>event.description</code> - A description of the event.</para></li><li><para><code>event.not-after</code> - The latest end time for the scheduled event (for example,
        /// <code>2014-09-15T17:15:20.000Z</code>).</para></li><li><para><code>event.not-before</code> - The earliest start time for the scheduled event (for
        /// example, <code>2014-09-15T17:15:20.000Z</code>).</para></li><li><para><code>instance-state-code</code> - The code for the instance state, as a 16-bit unsigned
        /// integer. The high byte is used for internal purposes and should be ignored. The low
        /// byte is set based on the state represented. The valid values are 0 (pending), 16 (running),
        /// 32 (shutting-down), 48 (terminated), 64 (stopping), and 80 (stopped).</para></li><li><para><code>instance-state-name</code> - The state of the instance (<code>pending</code>
        /// | <code>running</code> | <code>shutting-down</code> | <code>terminated</code> | <code>stopping</code>
        /// | <code>stopped</code>).</para></li><li><para><code>instance-status.reachability</code> - Filters on instance status where the
        /// name is <code>reachability</code> (<code>passed</code> | <code>failed</code> | <code>initializing</code>
        /// | <code>insufficient-data</code>).</para></li><li><para><code>instance-status.status</code> - The status of the instance (<code>ok</code>
        /// | <code>impaired</code> | <code>initializing</code> | <code>insufficient-data</code>
        /// | <code>not-applicable</code>).</para></li><li><para><code>system-status.reachability</code> - Filters on system status where the name
        /// is <code>reachability</code> (<code>passed</code> | <code>failed</code> | <code>initializing</code>
        /// | <code>insufficient-data</code>).</para></li><li><para><code>system-status.status</code> - The system status of the instance (<code>ok</code>
        /// | <code>impaired</code> | <code>initializing</code> | <code>insufficient-data</code>
        /// | <code>not-applicable</code>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter IncludeAllInstance
        /// <summary>
        /// <para>
        /// <para>When <code>true</code>, includes the health status for all instances. When <code>false</code>,
        /// includes the health status for running instances only.</para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IncludeAllInstances")]
        public System.Boolean IncludeAllInstance { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>One or more instance IDs.</para><para>Default: Describes all your instances.</para><para>Constraints: Maximum 100 explicitly specified instance IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("InstanceIds")]
        public object[] InstanceId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. To retrieve the remaining
        /// results, make another call with the returned <code>NextToken</code> value. This value
        /// can be between 5 and 1000. You cannot specify this parameter and the instance IDs
        /// parameter in the same call.</para>
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
        /// <para>The token to retrieve the next page of results.</para>
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
            if (ParameterWasBound("IncludeAllInstance"))
                context.IncludeAllInstances = this.IncludeAllInstance;
            if (this.InstanceId != null)
            {
                context.InstanceIds = AmazonEC2Helper.InstanceParamToIDs(this.InstanceId);
            }
            
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
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
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeInstanceStatusRequest();
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.IncludeAllInstances != null)
            {
                request.IncludeAllInstances = cmdletContext.IncludeAllInstances.Value;
            }
            if (cmdletContext.InstanceIds != null)
            {
                request.InstanceIds = cmdletContext.InstanceIds;
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
                        object pipelineOutput = response.InstanceStatuses;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.InstanceStatuses.Count;
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
        
        private Amazon.EC2.Model.DescribeInstanceStatusResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeInstanceStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeInstanceStatus");
            try
            {
                #if DESKTOP
                return client.DescribeInstanceStatus(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeInstanceStatusAsync(request);
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
            public System.Boolean? IncludeAllInstances { get; set; }
            public List<System.String> InstanceIds { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
