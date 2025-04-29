/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Retrieves the specified alarms. You can filter the results by specifying a prefix
    /// for the alarm name, the alarm state, or a prefix for any action.
    /// 
    ///  
    /// <para>
    /// To use this operation and return information about composite alarms, you must be signed
    /// on with the <c>cloudwatch:DescribeAlarms</c> permission that is scoped to <c>*</c>.
    /// You can't return information about composite alarms if your <c>cloudwatch:DescribeAlarms</c>
    /// permission has a narrower scope.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWAlarm")]
    [OutputType("Amazon.CloudWatch.Model.DescribeAlarmsResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch DescribeAlarms API operation.", Operation = new[] {"DescribeAlarms"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.DescribeAlarmsResponse))]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.DescribeAlarmsResponse",
        "This cmdlet returns an Amazon.CloudWatch.Model.DescribeAlarmsResponse object containing multiple properties."
    )]
    public partial class GetCWAlarmCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// all alarms that have names that start with this prefix.</para><para>If this parameter is specified, you cannot specify <c>AlarmNames</c>.</para>
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
        /// or composite alarms. If you omit this parameter, only metric alarms are returned,
        /// even if composite alarms exist in the account.</para><para>For example, if you omit this parameter or specify <c>MetricAlarms</c>, the operation
        /// returns only a list of metric alarms. It does not return any composite alarms, even
        /// if composite alarms exist in the account.</para><para>If you specify <c>CompositeAlarms</c>, the operation returns only a list of composite
        /// alarms, and does not return any metric alarms.</para>
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
        /// the metric alarms and composite alarms referenced in the <c>AlarmRule</c> field of
        /// the composite alarm that you specify in <c>ChildrenOfAlarmName</c>. Information about
        /// the composite alarm that you name in <c>ChildrenOfAlarmName</c> is not returned.</para><para>If you specify <c>ChildrenOfAlarmName</c>, you cannot specify any other parameters
        /// in the request except for <c>MaxRecords</c> and <c>NextToken</c>. If you do so, you
        /// receive a validation error.</para><note><para>Only the <c>Alarm Name</c>, <c>ARN</c>, <c>StateValue</c> (OK/ALARM/INSUFFICIENT_DATA),
        /// and <c>StateUpdatedTimestamp</c> information are returned by this operation when you
        /// use this parameter. To get complete information about these alarms, perform another
        /// <c>DescribeAlarms</c> operation and specify the parent alarm names in the <c>AlarmNames</c>
        /// parameter.</para></note>
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
        /// These are the composite alarms that have <c>AlarmRule</c> parameters that reference
        /// the alarm named in <c>ParentsOfAlarmName</c>. Information about the alarm that you
        /// specify in <c>ParentsOfAlarmName</c> is not returned.</para><para>If you specify <c>ParentsOfAlarmName</c>, you cannot specify any other parameters
        /// in the request except for <c>MaxRecords</c> and <c>NextToken</c>. If you do so, you
        /// receive a validation error.</para><note><para>Only the Alarm Name and ARN are returned by this operation when you use this parameter.
        /// To get complete information about these alarms, perform another <c>DescribeAlarms</c>
        /// operation and specify the parent alarm names in the <c>AlarmNames</c> parameter.</para></note>
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
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRecords")]
        public System.Int32? MaxRecord { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token returned by a previous call to indicate that there is more data available.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.DescribeAlarmsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.DescribeAlarmsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.DescribeAlarmsResponse, GetCWAlarmCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.NextToken = this.NextToken;
            context.ParentsOfAlarmName = this.ParentsOfAlarmName;
            context.StateValue = this.StateValue;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
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
                request.MaxRecords = cmdletContext.MaxRecord.Value;
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
                return client.DescribeAlarmsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MaxRecord { get; set; }
            public System.String NextToken { get; set; }
            public System.String ParentsOfAlarmName { get; set; }
            public Amazon.CloudWatch.StateValue StateValue { get; set; }
            public System.Func<Amazon.CloudWatch.Model.DescribeAlarmsResponse, GetCWAlarmCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
