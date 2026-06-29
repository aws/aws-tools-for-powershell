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
    /// Creates or updates a log alarm. A log alarm evaluates the results of a CloudWatch
    /// Logs scheduled query against the configured threshold and comparison operator to determine
    /// its state.
    /// 
    ///  
    /// <para>
    /// When you create a log alarm, the operation creates a service-managed CloudWatch Logs
    /// scheduled query that runs the query string you provide on the schedule you configure.
    /// Each scheduled query execution returns one or more aggregated values determined by
    /// the <c>AggregationExpression</c>, and each aggregated value is compared against the
    /// alarm <c>Threshold</c> to determine the alarm state. The alarm uses M-out-of-N evaluation:
    /// if <c>QueryResultsToAlarm</c> out of the most recent <c>QueryResultsToEvaluate</c>
    /// query results breach the threshold, the alarm transitions to <c>ALARM</c>.
    /// </para><para>
    /// Log alarms support the alarm states (<c>OK</c>, <c>ALARM</c>, <c>INSUFFICIENT_DATA</c>).
    /// Configure transition actions using <c>OKActions</c>, <c>AlarmActions</c>, and <c>InsufficientDataActions</c>.
    /// </para><para>
    /// If you call this operation with the name of an existing log alarm, the operation replaces
    /// the previous configuration of that alarm.
    /// </para><para><b>Permissions</b></para><para>
    /// To create or update a log alarm, you must have the <c>cloudwatch:PutLogAlarm</c> permission.
    /// The IAM role specified in <c>ScheduledQueryRoleARN</c> must grant the CloudWatch Alarms
    /// service permission to execute scheduled queries on the specified log groups. If you
    /// set <c>ActionLogLineCount</c>, the role specified in <c>ActionLogLineRoleArn</c> must
    /// grant permission to retrieve log events for inclusion in alarm notifications.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLogAlarm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch PutLogAlarm API operation.", Operation = new[] {"PutLogAlarm"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.PutLogAlarmResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatch.Model.PutLogAlarmResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatch.Model.PutLogAlarmResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCWLogAlarmCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActionLogLineCount
        /// <summary>
        /// <para>
        /// <para>The number of log lines from the most recent scheduled query execution to include
        /// in alarm action notifications. Valid range is 0 through 50. The default is 0, which
        /// means no log lines are included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ActionLogLineCount { get; set; }
        #endregion
        
        #region Parameter ActionLogLineRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that CloudWatch assumes to retrieve
        /// log events for inclusion in alarm action notifications. Required when <c>ActionLogLineCount</c>
        /// is greater than 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActionLogLineRoleArn { get; set; }
        #endregion
        
        #region Parameter ActionsEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether actions should be executed during any changes to the alarm state.
        /// The default is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ActionsEnabled { get; set; }
        #endregion
        
        #region Parameter ScheduledQueryConfiguration_AggregationExpression
        /// <summary>
        /// <para>
        /// <para>The expression that defines how to aggregate query results into one or more scalar
        /// values for alarm evaluation. For example, <c>count(*)</c> or <c>avg(latency) by host
        /// | sort desc</c>. Length constraints: minimum 1 character, maximum 2048 characters.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ScheduledQueryConfiguration_AggregationExpression { get; set; }
        #endregion
        
        #region Parameter AlarmAction
        /// <summary>
        /// <para>
        /// <para>The actions to execute when this alarm transitions to the <c>ALARM</c> state from
        /// any other state. Each action is specified as an Amazon Resource Name (ARN).</para><para>Valid Values:</para><para><b>Amazon SNS actions:</b></para><para><c>arn:aws:sns:<i>region</i>:<i>account-id</i>:<i>sns-topic-name</i></c></para><para><b>Lambda actions:</b></para><ul><li><para>Invoke the latest version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i></c></para></li><li><para>Invoke a specific version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>version-number</i></c></para></li><li><para>Invoke a function by using an alias Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>alias-name</i></c></para></li></ul><para><b>Systems Manager actions:</b></para><para><c>arn:aws:ssm:<i>region</i>:<i>account-id</i>:opsitem:<i>severity</i></c></para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlarmActions")]
        public System.String[] AlarmAction { get; set; }
        #endregion
        
        #region Parameter AlarmDescription
        /// <summary>
        /// <para>
        /// <para>The description for the alarm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AlarmDescription { get; set; }
        #endregion
        
        #region Parameter AlarmName
        /// <summary>
        /// <para>
        /// <para>The name for the alarm. This name must be unique within the Amazon Web Services account
        /// and Region.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AlarmName { get; set; }
        #endregion
        
        #region Parameter ComparisonOperator
        /// <summary>
        /// <para>
        /// <para>The arithmetic operation to use when comparing the aggregated query result and the
        /// threshold. The aggregated query result is used as the first operand. Valid values
        /// are <c>GreaterThanThreshold</c>, <c>GreaterThanOrEqualToThreshold</c>, <c>LessThanThreshold</c>,
        /// and <c>LessThanOrEqualToThreshold</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatch.ComparisonOperator")]
        public Amazon.CloudWatch.ComparisonOperator ComparisonOperator { get; set; }
        #endregion
        
        #region Parameter ScheduledQueryConfiguration_ScheduleConfiguration_EndTimeOffset
        /// <summary>
        /// <para>
        /// <para>The offset, in seconds, before the scheduled execution time at which the query time
        /// range ends. Must be non-negative and less than <c>StartTimeOffset</c>. The default
        /// is 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ScheduledQueryConfiguration_ScheduleConfiguration_EndTimeOffset { get; set; }
        #endregion
        
        #region Parameter InsufficientDataAction
        /// <summary>
        /// <para>
        /// <para>The actions to execute when this alarm transitions to the <c>INSUFFICIENT_DATA</c>
        /// state from any other state. Each action is specified as an Amazon Resource Name (ARN).</para><para>Valid Values:</para><para><b>Amazon SNS actions:</b></para><para><c>arn:aws:sns:<i>region</i>:<i>account-id</i>:<i>sns-topic-name</i></c></para><para><b>Lambda actions:</b></para><ul><li><para>Invoke the latest version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i></c></para></li><li><para>Invoke a specific version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>version-number</i></c></para></li><li><para>Invoke a function by using an alias Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>alias-name</i></c></para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InsufficientDataActions")]
        public System.String[] InsufficientDataAction { get; set; }
        #endregion
        
        #region Parameter ScheduledQueryConfiguration_LogGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The log groups to query. Each entry can be a log group name or ARN. Use the ARN form
        /// when querying log groups in a different account (for example, when running cross-account
        /// queries from a monitoring account). The list must contain between 1 and 50 entries.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScheduledQueryConfiguration_LogGroupIdentifiers")]
        public System.String[] ScheduledQueryConfiguration_LogGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter OKAction
        /// <summary>
        /// <para>
        /// <para>The actions to execute when this alarm transitions to the <c>OK</c> state from any
        /// other state. Each action is specified as an Amazon Resource Name (ARN).</para><para>Valid Values:</para><para><b>Amazon SNS actions:</b></para><para><c>arn:aws:sns:<i>region</i>:<i>account-id</i>:<i>sns-topic-name</i></c></para><para><b>Lambda actions:</b></para><ul><li><para>Invoke the latest version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i></c></para></li><li><para>Invoke a specific version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>version-number</i></c></para></li><li><para>Invoke a function by using an alias Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>alias-name</i></c></para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OKActions")]
        public System.String[] OKAction { get; set; }
        #endregion
        
        #region Parameter ScheduledQueryConfiguration_QueryARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the CloudWatch Logs scheduled query that the alarm
        /// uses. This field is populated in <c>DescribeAlarms</c> responses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduledQueryConfiguration_QueryARN { get; set; }
        #endregion
        
        #region Parameter QueryResultsToAlarm
        /// <summary>
        /// <para>
        /// <para>The number of query results, out of the most recent <c>QueryResultsToEvaluate</c>
        /// results, that must breach the threshold to trigger the alarm to transition to <c>ALARM</c>
        /// (the M in M-of-N evaluation). Must be less than or equal to <c>QueryResultsToEvaluate</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? QueryResultsToAlarm { get; set; }
        #endregion
        
        #region Parameter QueryResultsToEvaluate
        /// <summary>
        /// <para>
        /// <para>The number of most recent scheduled query results to evaluate against the threshold
        /// (the N in M-of-N evaluation). Valid range is 1 through 100.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? QueryResultsToEvaluate { get; set; }
        #endregion
        
        #region Parameter ScheduledQueryConfiguration_QueryString
        /// <summary>
        /// <para>
        /// <para>The CloudWatch Logs query to execute on each scheduled run. Length constraints: maximum
        /// of 10,000 characters.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ScheduledQueryConfiguration_QueryString { get; set; }
        #endregion
        
        #region Parameter ScheduledQueryConfiguration_ScheduledQueryRoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that CloudWatch assumes when executing
        /// the scheduled query against the configured log groups.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ScheduledQueryConfiguration_ScheduledQueryRoleARN { get; set; }
        #endregion
        
        #region Parameter ScheduledQueryConfiguration_ScheduleConfiguration_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>The schedule expression that defines how often the underlying CloudWatch Logs scheduled
        /// query runs. Specify a <c>rate()</c> expression, for example <c>rate(5 minutes)</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ScheduledQueryConfiguration_ScheduleConfiguration_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter ScheduledQueryConfiguration_ScheduleConfiguration_StartTimeOffset
        /// <summary>
        /// <para>
        /// <para>The offset, in seconds, before the scheduled execution time at which the query time
        /// range begins. For example, an offset of 360 (6 minutes) on a query running at 12:05:00
        /// starts the query time range at 11:59:00.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ScheduledQueryConfiguration_ScheduleConfiguration_StartTimeOffset { get; set; }
        #endregion
        
        #region Parameter ScheduledQueryConfiguration_Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to associate with the underlying scheduled query resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScheduledQueryConfiguration_Tags")]
        public Amazon.CloudWatch.Model.Tag[] ScheduledQueryConfiguration_Tag { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to associate with the alarm. You can use tags to categorize
        /// and manage your alarms.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CloudWatch.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Threshold
        /// <summary>
        /// <para>
        /// <para>The value to compare with the aggregated query result.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Double? Threshold { get; set; }
        #endregion
        
        #region Parameter TreatMissingData
        /// <summary>
        /// <para>
        /// <para>Sets how this alarm is to handle missing data points. Valid values are <c>breaching</c>,
        /// <c>notBreaching</c>, <c>ignore</c>, and <c>missing</c>. If this parameter is omitted,
        /// the default behavior of <c>missing</c> is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TreatMissingData { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.PutLogAlarmResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AlarmName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLogAlarm (PutLogAlarm)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.PutLogAlarmResponse, WriteCWLogAlarmCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActionLogLineCount = this.ActionLogLineCount;
            context.ActionLogLineRoleArn = this.ActionLogLineRoleArn;
            context.ActionsEnabled = this.ActionsEnabled;
            if (this.AlarmAction != null)
            {
                context.AlarmAction = new List<System.String>(this.AlarmAction);
            }
            context.AlarmDescription = this.AlarmDescription;
            context.AlarmName = this.AlarmName;
            #if MODULAR
            if (this.AlarmName == null && ParameterWasBound(nameof(this.AlarmName)))
            {
                WriteWarning("You are passing $null as a value for parameter AlarmName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComparisonOperator = this.ComparisonOperator;
            #if MODULAR
            if (this.ComparisonOperator == null && ParameterWasBound(nameof(this.ComparisonOperator)))
            {
                WriteWarning("You are passing $null as a value for parameter ComparisonOperator which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InsufficientDataAction != null)
            {
                context.InsufficientDataAction = new List<System.String>(this.InsufficientDataAction);
            }
            if (this.OKAction != null)
            {
                context.OKAction = new List<System.String>(this.OKAction);
            }
            context.QueryResultsToAlarm = this.QueryResultsToAlarm;
            #if MODULAR
            if (this.QueryResultsToAlarm == null && ParameterWasBound(nameof(this.QueryResultsToAlarm)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryResultsToAlarm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryResultsToEvaluate = this.QueryResultsToEvaluate;
            #if MODULAR
            if (this.QueryResultsToEvaluate == null && ParameterWasBound(nameof(this.QueryResultsToEvaluate)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryResultsToEvaluate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduledQueryConfiguration_AggregationExpression = this.ScheduledQueryConfiguration_AggregationExpression;
            #if MODULAR
            if (this.ScheduledQueryConfiguration_AggregationExpression == null && ParameterWasBound(nameof(this.ScheduledQueryConfiguration_AggregationExpression)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduledQueryConfiguration_AggregationExpression which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ScheduledQueryConfiguration_LogGroupIdentifier != null)
            {
                context.ScheduledQueryConfiguration_LogGroupIdentifier = new List<System.String>(this.ScheduledQueryConfiguration_LogGroupIdentifier);
            }
            context.ScheduledQueryConfiguration_QueryARN = this.ScheduledQueryConfiguration_QueryARN;
            context.ScheduledQueryConfiguration_QueryString = this.ScheduledQueryConfiguration_QueryString;
            #if MODULAR
            if (this.ScheduledQueryConfiguration_QueryString == null && ParameterWasBound(nameof(this.ScheduledQueryConfiguration_QueryString)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduledQueryConfiguration_QueryString which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduledQueryConfiguration_ScheduleConfiguration_EndTimeOffset = this.ScheduledQueryConfiguration_ScheduleConfiguration_EndTimeOffset;
            context.ScheduledQueryConfiguration_ScheduleConfiguration_ScheduleExpression = this.ScheduledQueryConfiguration_ScheduleConfiguration_ScheduleExpression;
            #if MODULAR
            if (this.ScheduledQueryConfiguration_ScheduleConfiguration_ScheduleExpression == null && ParameterWasBound(nameof(this.ScheduledQueryConfiguration_ScheduleConfiguration_ScheduleExpression)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduledQueryConfiguration_ScheduleConfiguration_ScheduleExpression which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduledQueryConfiguration_ScheduleConfiguration_StartTimeOffset = this.ScheduledQueryConfiguration_ScheduleConfiguration_StartTimeOffset;
            context.ScheduledQueryConfiguration_ScheduledQueryRoleARN = this.ScheduledQueryConfiguration_ScheduledQueryRoleARN;
            #if MODULAR
            if (this.ScheduledQueryConfiguration_ScheduledQueryRoleARN == null && ParameterWasBound(nameof(this.ScheduledQueryConfiguration_ScheduledQueryRoleARN)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduledQueryConfiguration_ScheduledQueryRoleARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ScheduledQueryConfiguration_Tag != null)
            {
                context.ScheduledQueryConfiguration_Tag = new List<Amazon.CloudWatch.Model.Tag>(this.ScheduledQueryConfiguration_Tag);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CloudWatch.Model.Tag>(this.Tag);
            }
            context.Threshold = this.Threshold;
            #if MODULAR
            if (this.Threshold == null && ParameterWasBound(nameof(this.Threshold)))
            {
                WriteWarning("You are passing $null as a value for parameter Threshold which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TreatMissingData = this.TreatMissingData;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudWatch.Model.PutLogAlarmRequest();
            
            if (cmdletContext.ActionLogLineCount != null)
            {
                request.ActionLogLineCount = cmdletContext.ActionLogLineCount.Value;
            }
            if (cmdletContext.ActionLogLineRoleArn != null)
            {
                request.ActionLogLineRoleArn = cmdletContext.ActionLogLineRoleArn;
            }
            if (cmdletContext.ActionsEnabled != null)
            {
                request.ActionsEnabled = cmdletContext.ActionsEnabled.Value;
            }
            if (cmdletContext.AlarmAction != null)
            {
                request.AlarmActions = cmdletContext.AlarmAction;
            }
            if (cmdletContext.AlarmDescription != null)
            {
                request.AlarmDescription = cmdletContext.AlarmDescription;
            }
            if (cmdletContext.AlarmName != null)
            {
                request.AlarmName = cmdletContext.AlarmName;
            }
            if (cmdletContext.ComparisonOperator != null)
            {
                request.ComparisonOperator = cmdletContext.ComparisonOperator;
            }
            if (cmdletContext.InsufficientDataAction != null)
            {
                request.InsufficientDataActions = cmdletContext.InsufficientDataAction;
            }
            if (cmdletContext.OKAction != null)
            {
                request.OKActions = cmdletContext.OKAction;
            }
            if (cmdletContext.QueryResultsToAlarm != null)
            {
                request.QueryResultsToAlarm = cmdletContext.QueryResultsToAlarm.Value;
            }
            if (cmdletContext.QueryResultsToEvaluate != null)
            {
                request.QueryResultsToEvaluate = cmdletContext.QueryResultsToEvaluate.Value;
            }
            
             // populate ScheduledQueryConfiguration
            var requestScheduledQueryConfigurationIsNull = true;
            request.ScheduledQueryConfiguration = new Amazon.CloudWatch.Model.ScheduledQueryConfiguration();
            System.String requestScheduledQueryConfiguration_scheduledQueryConfiguration_AggregationExpression = null;
            if (cmdletContext.ScheduledQueryConfiguration_AggregationExpression != null)
            {
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_AggregationExpression = cmdletContext.ScheduledQueryConfiguration_AggregationExpression;
            }
            if (requestScheduledQueryConfiguration_scheduledQueryConfiguration_AggregationExpression != null)
            {
                request.ScheduledQueryConfiguration.AggregationExpression = requestScheduledQueryConfiguration_scheduledQueryConfiguration_AggregationExpression;
                requestScheduledQueryConfigurationIsNull = false;
            }
            List<System.String> requestScheduledQueryConfiguration_scheduledQueryConfiguration_LogGroupIdentifier = null;
            if (cmdletContext.ScheduledQueryConfiguration_LogGroupIdentifier != null)
            {
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_LogGroupIdentifier = cmdletContext.ScheduledQueryConfiguration_LogGroupIdentifier;
            }
            if (requestScheduledQueryConfiguration_scheduledQueryConfiguration_LogGroupIdentifier != null)
            {
                request.ScheduledQueryConfiguration.LogGroupIdentifiers = requestScheduledQueryConfiguration_scheduledQueryConfiguration_LogGroupIdentifier;
                requestScheduledQueryConfigurationIsNull = false;
            }
            System.String requestScheduledQueryConfiguration_scheduledQueryConfiguration_QueryARN = null;
            if (cmdletContext.ScheduledQueryConfiguration_QueryARN != null)
            {
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_QueryARN = cmdletContext.ScheduledQueryConfiguration_QueryARN;
            }
            if (requestScheduledQueryConfiguration_scheduledQueryConfiguration_QueryARN != null)
            {
                request.ScheduledQueryConfiguration.QueryARN = requestScheduledQueryConfiguration_scheduledQueryConfiguration_QueryARN;
                requestScheduledQueryConfigurationIsNull = false;
            }
            System.String requestScheduledQueryConfiguration_scheduledQueryConfiguration_QueryString = null;
            if (cmdletContext.ScheduledQueryConfiguration_QueryString != null)
            {
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_QueryString = cmdletContext.ScheduledQueryConfiguration_QueryString;
            }
            if (requestScheduledQueryConfiguration_scheduledQueryConfiguration_QueryString != null)
            {
                request.ScheduledQueryConfiguration.QueryString = requestScheduledQueryConfiguration_scheduledQueryConfiguration_QueryString;
                requestScheduledQueryConfigurationIsNull = false;
            }
            System.String requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduledQueryRoleARN = null;
            if (cmdletContext.ScheduledQueryConfiguration_ScheduledQueryRoleARN != null)
            {
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduledQueryRoleARN = cmdletContext.ScheduledQueryConfiguration_ScheduledQueryRoleARN;
            }
            if (requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduledQueryRoleARN != null)
            {
                request.ScheduledQueryConfiguration.ScheduledQueryRoleARN = requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduledQueryRoleARN;
                requestScheduledQueryConfigurationIsNull = false;
            }
            List<Amazon.CloudWatch.Model.Tag> requestScheduledQueryConfiguration_scheduledQueryConfiguration_Tag = null;
            if (cmdletContext.ScheduledQueryConfiguration_Tag != null)
            {
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_Tag = cmdletContext.ScheduledQueryConfiguration_Tag;
            }
            if (requestScheduledQueryConfiguration_scheduledQueryConfiguration_Tag != null)
            {
                request.ScheduledQueryConfiguration.Tags = requestScheduledQueryConfiguration_scheduledQueryConfiguration_Tag;
                requestScheduledQueryConfigurationIsNull = false;
            }
            Amazon.CloudWatch.Model.ScheduleConfiguration requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration = null;
            
             // populate ScheduleConfiguration
            var requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfigurationIsNull = true;
            requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration = new Amazon.CloudWatch.Model.ScheduleConfiguration();
            System.Int64? requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_EndTimeOffset = null;
            if (cmdletContext.ScheduledQueryConfiguration_ScheduleConfiguration_EndTimeOffset != null)
            {
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_EndTimeOffset = cmdletContext.ScheduledQueryConfiguration_ScheduleConfiguration_EndTimeOffset.Value;
            }
            if (requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_EndTimeOffset != null)
            {
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration.EndTimeOffset = requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_EndTimeOffset.Value;
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfigurationIsNull = false;
            }
            System.String requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_ScheduleExpression = null;
            if (cmdletContext.ScheduledQueryConfiguration_ScheduleConfiguration_ScheduleExpression != null)
            {
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_ScheduleExpression = cmdletContext.ScheduledQueryConfiguration_ScheduleConfiguration_ScheduleExpression;
            }
            if (requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_ScheduleExpression != null)
            {
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration.ScheduleExpression = requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_ScheduleExpression;
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfigurationIsNull = false;
            }
            System.Int64? requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_StartTimeOffset = null;
            if (cmdletContext.ScheduledQueryConfiguration_ScheduleConfiguration_StartTimeOffset != null)
            {
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_StartTimeOffset = cmdletContext.ScheduledQueryConfiguration_ScheduleConfiguration_StartTimeOffset.Value;
            }
            if (requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_StartTimeOffset != null)
            {
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration.StartTimeOffset = requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_scheduledQueryConfiguration_ScheduleConfiguration_StartTimeOffset.Value;
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfigurationIsNull = false;
            }
             // determine if requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration should be set to null
            if (requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfigurationIsNull)
            {
                requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration = null;
            }
            if (requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration != null)
            {
                request.ScheduledQueryConfiguration.ScheduleConfiguration = requestScheduledQueryConfiguration_scheduledQueryConfiguration_ScheduleConfiguration;
                requestScheduledQueryConfigurationIsNull = false;
            }
             // determine if request.ScheduledQueryConfiguration should be set to null
            if (requestScheduledQueryConfigurationIsNull)
            {
                request.ScheduledQueryConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Threshold != null)
            {
                request.Threshold = cmdletContext.Threshold.Value;
            }
            if (cmdletContext.TreatMissingData != null)
            {
                request.TreatMissingData = cmdletContext.TreatMissingData;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CloudWatch.Model.PutLogAlarmResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.PutLogAlarmRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "PutLogAlarm");
            try
            {
                return client.PutLogAlarmAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? ActionLogLineCount { get; set; }
            public System.String ActionLogLineRoleArn { get; set; }
            public System.Boolean? ActionsEnabled { get; set; }
            public List<System.String> AlarmAction { get; set; }
            public System.String AlarmDescription { get; set; }
            public System.String AlarmName { get; set; }
            public Amazon.CloudWatch.ComparisonOperator ComparisonOperator { get; set; }
            public List<System.String> InsufficientDataAction { get; set; }
            public List<System.String> OKAction { get; set; }
            public System.Int32? QueryResultsToAlarm { get; set; }
            public System.Int32? QueryResultsToEvaluate { get; set; }
            public System.String ScheduledQueryConfiguration_AggregationExpression { get; set; }
            public List<System.String> ScheduledQueryConfiguration_LogGroupIdentifier { get; set; }
            public System.String ScheduledQueryConfiguration_QueryARN { get; set; }
            public System.String ScheduledQueryConfiguration_QueryString { get; set; }
            public System.Int64? ScheduledQueryConfiguration_ScheduleConfiguration_EndTimeOffset { get; set; }
            public System.String ScheduledQueryConfiguration_ScheduleConfiguration_ScheduleExpression { get; set; }
            public System.Int64? ScheduledQueryConfiguration_ScheduleConfiguration_StartTimeOffset { get; set; }
            public System.String ScheduledQueryConfiguration_ScheduledQueryRoleARN { get; set; }
            public List<Amazon.CloudWatch.Model.Tag> ScheduledQueryConfiguration_Tag { get; set; }
            public List<Amazon.CloudWatch.Model.Tag> Tag { get; set; }
            public System.Double? Threshold { get; set; }
            public System.String TreatMissingData { get; set; }
            public System.Func<Amazon.CloudWatch.Model.PutLogAlarmResponse, WriteCWLogAlarmCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
