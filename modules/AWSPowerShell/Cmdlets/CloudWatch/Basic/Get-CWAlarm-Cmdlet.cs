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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Retrieves the specified alarms. You can filter the results by specifying a a prefix
    /// for the alarm name, the alarm state, or a prefix for any action.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWAlarm")]
    [OutputType("Amazon.CloudWatch.Model.MetricAlarm")]
    [AWSCmdlet("Calls the Amazon CloudWatch DescribeAlarms API operation.", Operation = new[] {"DescribeAlarms"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.DescribeAlarmsResponse))]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.MetricAlarm or Amazon.CloudWatch.Model.DescribeAlarmsResponse",
        "This cmdlet returns a collection of Amazon.CloudWatch.Model.MetricAlarm objects.",
        "The service call response (type Amazon.CloudWatch.Model.DescribeAlarmsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCWAlarmCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        #region Parameter ActionPrefix
        /// <summary>
        /// <para>
        /// <para>Use this parameter to filter the results of the operation to only those alarms that
        /// use a certain alarm action. For example, you could specify the ARN of an SNS topic
        /// to find all alarms that send notifications to that topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActionPrefix { get; set; }
        #endregion
        
        #region Parameter AlarmNamePrefix
        /// <summary>
        /// <para>
        /// <para>An alarm name prefix. If you specify this parameter, you receive information about
        /// all alarms that have names that start with this prefix.</para><para>If this parameter is specified, you cannot specify <code>AlarmNames</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AlarmNamePrefix { get; set; }
        #endregion
        
        #region Parameter AlarmName
        /// <summary>
        /// <para>
        /// <para>The names of the alarms to retrieve information about.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("AlarmNames")]
        public System.String[] AlarmName { get; set; }
        #endregion
        
        #region Parameter AlarmType
        /// <summary>
        /// <para>
        /// <para>Use this parameter to specify whether you want the operation to return metric alarms
        /// or composite alarms. If you omit this parameter, only metric alarms are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlarmTypes")]
        public System.String[] AlarmType { get; set; }
        #endregion
        
        #region Parameter ChildrenOfAlarmName
        /// <summary>
        /// <para>
        /// <para>If you use this parameter and specify the name of a composite alarm, the operation
        /// returns information about the "children" alarms of the alarm you specify. These are
        /// the metric alarms and composite alarms referenced in the <code>AlarmRule</code> field
        /// of the composite alarm that you specify in <code>ChildrenOfAlarmName</code>. Information
        /// about the composite alarm that you name in <code>ChildrenOfAlarmName</code> is not
        /// returned.</para><para>If you specify <code>ChildrenOfAlarmName</code>, you cannot specify any other parameters
        /// in the request except for <code>MaxRecords</code> and <code>NextToken</code>. If you
        /// do so, you will receive a validation error.</para><note><para>Only the <code>Alarm Name</code>, <code>ARN</code>, <code>StateValue</code> (OK/ALARM/INSUFFICIENT_DATA),
        /// and <code>StateUpdatedTimestamp</code> information are returned by this operation
        /// when you use this parameter. To get complete information about these alarms, perform
        /// another <code>DescribeAlarms</code> operation and specify the parent alarm names in
        /// the <code>AlarmNames</code> parameter.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChildrenOfAlarmName { get; set; }
        #endregion
        
        #region Parameter ParentsOfAlarmName
        /// <summary>
        /// <para>
        /// <para>If you use this parameter and specify the name of a metric or composite alarm, the
        /// operation returns information about the "parent" alarms of the alarm you specify.
        /// These are the composite alarms that have <code>AlarmRule</code> parameters that reference
        /// the alarm named in <code>ParentsOfAlarmName</code>. Information about the alarm that
        /// you specify in <code>ParentsOfAlarmName</code> is not returned.</para><para>If you specify <code>ParentsOfAlarmName</code>, you cannot specify any other parameters
        /// in the request except for <code>MaxRecords</code> and <code>NextToken</code>. If you
        /// do so, you will receive a validation error.</para><note><para>Only the Alarm Name and ARN are returned by this operation when you use this parameter.
        /// To get complete information about these alarms, perform another <code>DescribeAlarms</code>
        /// operation and specify the parent alarm names in the <code>AlarmNames</code> parameter.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentsOfAlarmName { get; set; }
        #endregion
        
        #region Parameter StateValue
        /// <summary>
        /// <para>
        /// <para>Specify this parameter to receive information only about alarms that are currently
        /// in the state that you specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatch.StateValue")]
        public Amazon.CloudWatch.StateValue StateValue { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number of alarm descriptions to retrieve.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxRecords")]
        public int? MaxRecord { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token returned by a previous call to indicate that there is more data available.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MetricAlarms'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.DescribeAlarmsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.DescribeAlarmsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MetricAlarms";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AlarmName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AlarmName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AlarmName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.DescribeAlarmsResponse, GetCWAlarmCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AlarmName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ActionPrefix = this.ActionPrefix;
            context.AlarmNamePrefix = this.AlarmNamePrefix;
            if (this.AlarmName != null)
            {
                context.AlarmName = new List<System.String>(this.AlarmName);
            }
            if (this.AlarmType != null)
            {
                context.AlarmType = new List<System.String>(this.AlarmType);
            }
            context.ChildrenOfAlarmName = this.ChildrenOfAlarmName;
            context.MaxRecord = this.MaxRecord;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxRecord)) && this.MaxRecord.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxRecord parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxRecord" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.ParentsOfAlarmName = this.ParentsOfAlarmName;
            context.StateValue = this.StateValue;
            
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
            var request = new Amazon.CloudWatch.Model.DescribeAlarmsRequest();
            
            if (cmdletContext.ActionPrefix != null)
            {
                request.ActionPrefix = cmdletContext.ActionPrefix;
            }
            if (cmdletContext.AlarmNamePrefix != null)
            {
                request.AlarmNamePrefix = cmdletContext.AlarmNamePrefix;
            }
            if (cmdletContext.AlarmName != null)
            {
                request.AlarmNames = cmdletContext.AlarmName;
            }
            if (cmdletContext.AlarmType != null)
            {
                request.AlarmTypes = cmdletContext.AlarmType;
            }
            if (cmdletContext.ChildrenOfAlarmName != null)
            {
                request.ChildrenOfAlarmName = cmdletContext.ChildrenOfAlarmName;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxRecord.Value);
            }
            if (cmdletContext.ParentsOfAlarmName != null)
            {
                request.ParentsOfAlarmName = cmdletContext.ParentsOfAlarmName;
            }
            if (cmdletContext.StateValue != null)
            {
                request.StateValue = cmdletContext.StateValue;
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
            var request = new Amazon.CloudWatch.Model.DescribeAlarmsRequest();
            if (cmdletContext.ActionPrefix != null)
            {
                request.ActionPrefix = cmdletContext.ActionPrefix;
            }
            if (cmdletContext.AlarmNamePrefix != null)
            {
                request.AlarmNamePrefix = cmdletContext.AlarmNamePrefix;
            }
            if (cmdletContext.AlarmName != null)
            {
                request.AlarmNames = cmdletContext.AlarmName;
            }
            if (cmdletContext.AlarmType != null)
            {
                request.AlarmTypes = cmdletContext.AlarmType;
            }
            if (cmdletContext.ChildrenOfAlarmName != null)
            {
                request.ChildrenOfAlarmName = cmdletContext.ChildrenOfAlarmName;
            }
            if (cmdletContext.ParentsOfAlarmName != null)
            {
                request.ParentsOfAlarmName = cmdletContext.ParentsOfAlarmName;
            }
            if (cmdletContext.StateValue != null)
            {
                request.StateValue = cmdletContext.StateValue;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxRecord.HasValue)
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxRecord;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(100, _emitLimit.Value);
                    request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
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
                    int _receivedThisCall = response.MetricAlarms.Count;
                    
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
        
        private Amazon.CloudWatch.Model.DescribeAlarmsResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.DescribeAlarmsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "DescribeAlarms");
            try
            {
                #if DESKTOP
                return client.DescribeAlarms(request);
                #elif CORECLR
                return client.DescribeAlarmsAsync(request).GetAwaiter().GetResult();
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
            public System.String ActionPrefix { get; set; }
            public System.String AlarmNamePrefix { get; set; }
            public List<System.String> AlarmName { get; set; }
            public List<System.String> AlarmType { get; set; }
            public System.String ChildrenOfAlarmName { get; set; }
            public int? MaxRecord { get; set; }
            public System.String NextToken { get; set; }
            public System.String ParentsOfAlarmName { get; set; }
            public Amazon.CloudWatch.StateValue StateValue { get; set; }
            public System.Func<Amazon.CloudWatch.Model.DescribeAlarmsResponse, GetCWAlarmCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MetricAlarms;
        }
        
    }
}
