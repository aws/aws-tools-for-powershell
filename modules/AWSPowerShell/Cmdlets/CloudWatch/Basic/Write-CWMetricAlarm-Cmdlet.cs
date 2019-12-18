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
    /// Creates or updates an alarm and associates it with the specified metric, metric math
    /// expression, or anomaly detection model.
    /// 
    ///  
    /// <para>
    /// Alarms based on anomaly detection models cannot have Auto Scaling actions.
    /// </para><para>
    /// When this operation creates an alarm, the alarm state is immediately set to <code>INSUFFICIENT_DATA</code>.
    /// The alarm is then evaluated and its state is set appropriately. Any actions associated
    /// with the new state are then executed.
    /// </para><para>
    /// When you update an existing alarm, its state is left unchanged, but the update completely
    /// overwrites the previous configuration of the alarm.
    /// </para><para>
    /// If you are an IAM user, you must have Amazon EC2 permissions for some alarm operations:
    /// </para><ul><li><para><code>iam:CreateServiceLinkedRole</code> for all alarms with EC2 actions
    /// </para></li><li><para><code>ec2:DescribeInstanceStatus</code> and <code>ec2:DescribeInstances</code> for
    /// all alarms on EC2 instance status metrics
    /// </para></li><li><para><code>ec2:StopInstances</code> for alarms with stop actions
    /// </para></li><li><para><code>ec2:TerminateInstances</code> for alarms with terminate actions
    /// </para></li><li><para>
    /// No specific permissions are needed for alarms with recover actions
    /// </para></li></ul><para>
    /// If you have read/write permissions for Amazon CloudWatch but not for Amazon EC2, you
    /// can still create an alarm, but the stop or terminate actions are not performed. However,
    /// if you are later granted the required permissions, the alarm actions that you created
    /// earlier are performed.
    /// </para><para>
    /// If you are using an IAM role (for example, an EC2 instance profile), you cannot stop
    /// or terminate the instance using alarm actions. However, you can still see the alarm
    /// state and perform any other actions such as Amazon SNS notifications or Auto Scaling
    /// policies.
    /// </para><para>
    /// If you are using temporary security credentials granted using AWS STS, you cannot
    /// stop or terminate an EC2 instance using alarm actions.
    /// </para><para>
    /// The first time you create an alarm in the AWS Management Console, the CLI, or by using
    /// the PutMetricAlarm API, CloudWatch creates the necessary service-linked role for you.
    /// The service-linked role is called <code>AWSServiceRoleForCloudWatchEvents</code>.
    /// For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_terms-and-concepts.html#iam-term-service-linked-role">AWS
    /// service-linked role</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWMetricAlarm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch PutMetricAlarm API operation.", Operation = new[] {"PutMetricAlarm"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.PutMetricAlarmResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatch.Model.PutMetricAlarmResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatch.Model.PutMetricAlarmResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCWMetricAlarmCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        #region Parameter ActionsEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether actions should be executed during any changes to the alarm state.
        /// The default is <code>TRUE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ActionsEnabled { get; set; }
        #endregion
        
        #region Parameter AlarmAction
        /// <summary>
        /// <para>
        /// <para>The actions to execute when this alarm transitions to the <code>ALARM</code> state
        /// from any other state. Each action is specified as an Amazon Resource Name (ARN).</para><para>Valid Values: <code>arn:aws:automate:<i>region</i>:ec2:stop</code> | <code>arn:aws:automate:<i>region</i>:ec2:terminate</code>
        /// | <code>arn:aws:automate:<i>region</i>:ec2:recover</code> | <code>arn:aws:automate:<i>region</i>:ec2:reboot</code>
        /// | <code>arn:aws:sns:<i>region</i>:<i>account-id</i>:<i>sns-topic-name</i></code>
        /// | <code>arn:aws:autoscaling:<i>region</i>:<i>account-id</i>:scalingPolicy:<i>policy-id</i>autoScalingGroupName/<i>group-friendly-name</i>:policyName/<i>policy-friendly-name</i></code></para><para>Valid Values (for use with IAM roles): <code>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Stop/1.0</code>
        /// | <code>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Terminate/1.0</code>
        /// | <code>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Reboot/1.0</code></para>
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
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String AlarmDescription { get; set; }
        #endregion
        
        #region Parameter AlarmName
        /// <summary>
        /// <para>
        /// <para>The name for the alarm. This name must be unique within your AWS account.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AlarmName { get; set; }
        #endregion
        
        #region Parameter ComparisonOperator
        /// <summary>
        /// <para>
        /// <para> The arithmetic operation to use when comparing the specified statistic and threshold.
        /// The specified statistic value is used as the first operand.</para><para>The values <code>LessThanLowerOrGreaterThanUpperThreshold</code>, <code>LessThanLowerThreshold</code>,
        /// and <code>GreaterThanUpperThreshold</code> are used only for alarms based on anomaly
        /// detection models.</para>
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
        
        #region Parameter DatapointsToAlarm
        /// <summary>
        /// <para>
        /// <para>The number of data points that must be breaching to trigger the alarm. This is used
        /// only if you are setting an "M out of N" alarm. In that case, this value is the M.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/AlarmThatSendsEmail.html#alarm-evaluation">Evaluating
        /// an Alarm</a> in the <i>Amazon CloudWatch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DatapointsToAlarm { get; set; }
        #endregion
        
        #region Parameter Dimension
        /// <summary>
        /// <para>
        /// <para>The dimensions for the metric specified in <code>MetricName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Dimensions")]
        public Amazon.CloudWatch.Model.Dimension[] Dimension { get; set; }
        #endregion
        
        #region Parameter EvaluateLowSampleCountPercentile
        /// <summary>
        /// <para>
        /// <para> Used only for alarms based on percentiles. If you specify <code>ignore</code>, the
        /// alarm state does not change during periods with too few data points to be statistically
        /// significant. If you specify <code>evaluate</code> or omit this parameter, the alarm
        /// is always evaluated and possibly changes state no matter how many data points are
        /// available. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/AlarmThatSendsEmail.html#percentiles-with-low-samples">Percentile-Based
        /// CloudWatch Alarms and Low Data Samples</a>.</para><para>Valid Values: <code>evaluate | ignore</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EvaluateLowSampleCountPercentile { get; set; }
        #endregion
        
        #region Parameter EvaluationPeriod
        /// <summary>
        /// <para>
        /// <para>The number of periods over which data is compared to the specified threshold. If you
        /// are setting an alarm that requires that a number of consecutive data points be breaching
        /// to trigger the alarm, this value specifies that number. If you are setting an "M out
        /// of N" alarm, this value is the N.</para><para>An alarm's total current evaluation period can be no longer than one day, so this
        /// number multiplied by <code>Period</code> cannot be more than 86,400 seconds.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("EvaluationPeriods")]
        public System.Int32? EvaluationPeriod { get; set; }
        #endregion
        
        #region Parameter ExtendedStatistic
        /// <summary>
        /// <para>
        /// <para>The percentile statistic for the metric specified in <code>MetricName</code>. Specify
        /// a value between p0.0 and p100. When you call <code>PutMetricAlarm</code> and specify
        /// a <code>MetricName</code>, you must specify either <code>Statistic</code> or <code>ExtendedStatistic,</code>
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExtendedStatistic { get; set; }
        #endregion
        
        #region Parameter InsufficientDataAction
        /// <summary>
        /// <para>
        /// <para>The actions to execute when this alarm transitions to the <code>INSUFFICIENT_DATA</code>
        /// state from any other state. Each action is specified as an Amazon Resource Name (ARN).</para><para>Valid Values: <code>arn:aws:automate:<i>region</i>:ec2:stop</code> | <code>arn:aws:automate:<i>region</i>:ec2:terminate</code>
        /// | <code>arn:aws:automate:<i>region</i>:ec2:recover</code> | <code>arn:aws:automate:<i>region</i>:ec2:reboot</code>
        /// | <code>arn:aws:sns:<i>region</i>:<i>account-id</i>:<i>sns-topic-name</i></code>
        /// | <code>arn:aws:autoscaling:<i>region</i>:<i>account-id</i>:scalingPolicy:<i>policy-id</i>autoScalingGroupName/<i>group-friendly-name</i>:policyName/<i>policy-friendly-name</i></code></para><para>Valid Values (for use with IAM roles): <code>&gt;arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Stop/1.0</code>
        /// | <code>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Terminate/1.0</code>
        /// | <code>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Reboot/1.0</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InsufficientDataActions")]
        public System.String[] InsufficientDataAction { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>The name for the metric associated with the alarm. For each <code>PutMetricAlarm</code>
        /// operation, you must specify either <code>MetricName</code> or a <code>Metrics</code>
        /// array.</para><para>If you are creating an alarm based on a math expression, you cannot specify this parameter,
        /// or any of the <code>Dimensions</code>, <code>Period</code>, <code>Namespace</code>,
        /// <code>Statistic</code>, or <code>ExtendedStatistic</code> parameters. Instead, you
        /// specify all this information in the <code>Metrics</code> array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricName { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>An array of <code>MetricDataQuery</code> structures that enable you to create an alarm
        /// based on the result of a metric math expression. For each <code>PutMetricAlarm</code>
        /// operation, you must specify either <code>MetricName</code> or a <code>Metrics</code>
        /// array.</para><para>Each item in the <code>Metrics</code> array either retrieves a metric or performs
        /// a math expression.</para><para>One item in the <code>Metrics</code> array is the expression that the alarm watches.
        /// You designate this expression by setting <code>ReturnValue</code> to true for this
        /// object in the array. For more information, see <a>MetricDataQuery</a>.</para><para>If you use the <code>Metrics</code> parameter, you cannot include the <code>MetricName</code>,
        /// <code>Dimensions</code>, <code>Period</code>, <code>Namespace</code>, <code>Statistic</code>,
        /// or <code>ExtendedStatistic</code> parameters of <code>PutMetricAlarm</code> in the
        /// same operation. Instead, you retrieve the metrics you are using in your math expression
        /// as part of the <code>Metrics</code> array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Metrics")]
        public Amazon.CloudWatch.Model.MetricDataQuery[] Metric { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace for the metric associated specified in <code>MetricName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter OKAction
        /// <summary>
        /// <para>
        /// <para>The actions to execute when this alarm transitions to an <code>OK</code> state from
        /// any other state. Each action is specified as an Amazon Resource Name (ARN).</para><para>Valid Values: <code>arn:aws:automate:<i>region</i>:ec2:stop</code> | <code>arn:aws:automate:<i>region</i>:ec2:terminate</code>
        /// | <code>arn:aws:automate:<i>region</i>:ec2:recover</code> | <code>arn:aws:automate:<i>region</i>:ec2:reboot</code>
        /// | <code>arn:aws:sns:<i>region</i>:<i>account-id</i>:<i>sns-topic-name</i></code>
        /// | <code>arn:aws:autoscaling:<i>region</i>:<i>account-id</i>:scalingPolicy:<i>policy-id</i>autoScalingGroupName/<i>group-friendly-name</i>:policyName/<i>policy-friendly-name</i></code></para><para>Valid Values (for use with IAM roles): <code>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Stop/1.0</code>
        /// | <code>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Terminate/1.0</code>
        /// | <code>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Reboot/1.0</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OKActions")]
        public System.String[] OKAction { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para>The length, in seconds, used each time the metric specified in <code>MetricName</code>
        /// is evaluated. Valid values are 10, 30, and any multiple of 60.</para><para><code>Period</code> is required for alarms based on static thresholds. If you are
        /// creating an alarm based on a metric math expression, you specify the period for each
        /// metric within the objects in the <code>Metrics</code> array.</para><para>Be sure to specify 10 or 30 only for metrics that are stored by a <code>PutMetricData</code>
        /// call with a <code>StorageResolution</code> of 1. If you specify a period of 10 or
        /// 30 for a metric that does not have sub-minute resolution, the alarm still attempts
        /// to gather data at the period rate that you specify. In this case, it does not receive
        /// data for the attempts that do not correspond to a one-minute data resolution, and
        /// the alarm may often lapse into INSUFFICENT_DATA status. Specifying 10 or 30 also sets
        /// this alarm as a high-resolution alarm, which has a higher charge than other alarms.
        /// For more information about pricing, see <a href="https://aws.amazon.com/cloudwatch/pricing/">Amazon
        /// CloudWatch Pricing</a>.</para><para>An alarm's total current evaluation period can be no longer than one day, so <code>Period</code>
        /// multiplied by <code>EvaluationPeriods</code> cannot be more than 86,400 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Period { get; set; }
        #endregion
        
        #region Parameter Statistic
        /// <summary>
        /// <para>
        /// <para>The statistic for the metric specified in <code>MetricName</code>, other than percentile.
        /// For percentile statistics, use <code>ExtendedStatistic</code>. When you call <code>PutMetricAlarm</code>
        /// and specify a <code>MetricName</code>, you must specify either <code>Statistic</code>
        /// or <code>ExtendedStatistic,</code> but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatch.Statistic")]
        public Amazon.CloudWatch.Statistic Statistic { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to associate with the alarm. You can associate as many as
        /// 50 tags with an alarm.</para><para>Tags can help you organize and categorize your resources. You can also use them to
        /// scope user permissions, by granting a user permission to access or change only resources
        /// with certain tag values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CloudWatch.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Threshold
        /// <summary>
        /// <para>
        /// <para>The value against which the specified statistic is compared.</para><para>This parameter is required for alarms based on static thresholds, but should not be
        /// used for alarms based on anomaly detection models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Threshold { get; set; }
        #endregion
        
        #region Parameter ThresholdMetricId
        /// <summary>
        /// <para>
        /// <para>If this is an alarm based on an anomaly detection model, make this value match the
        /// ID of the <code>ANOMALY_DETECTION_BAND</code> function.</para><para>For an example of how to use this parameter, see the <b>Anomaly Detection Model Alarm</b>
        /// example on this page.</para><para>If your alarm uses this parameter, it cannot have Auto Scaling actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ThresholdMetricId { get; set; }
        #endregion
        
        #region Parameter TreatMissingData
        /// <summary>
        /// <para>
        /// <para> Sets how this alarm is to handle missing data points. If <code>TreatMissingData</code>
        /// is omitted, the default behavior of <code>missing</code> is used. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/AlarmThatSendsEmail.html#alarms-and-missing-data">Configuring
        /// How CloudWatch Alarms Treats Missing Data</a>.</para><para>Valid Values: <code>breaching | notBreaching | ignore | missing</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TreatMissingData { get; set; }
        #endregion
        
        #region Parameter Unit
        /// <summary>
        /// <para>
        /// <para>The unit of measure for the statistic. For example, the units for the Amazon EC2 NetworkIn
        /// metric are Bytes because NetworkIn tracks the number of bytes that an instance receives
        /// on all network interfaces. You can also specify a unit when you create a custom metric.
        /// Units help provide conceptual meaning to your data. Metric data points that specify
        /// a unit of measure, such as Percent, are aggregated separately.</para><para>If you don't specify <code>Unit</code>, CloudWatch retrieves all unit types that have
        /// been published for the metric and attempts to evaluate the alarm. Usually metrics
        /// are published with only one unit, so the alarm will work as intended.</para><para>However, if the metric is published with multiple types of units and you don't specify
        /// a unit, the alarm's behavior is not defined and will behave un-predictably.</para><para>We recommend omitting <code>Unit</code> so that you don't inadvertently specify an
        /// incorrect unit that is not published for this metric. Doing so causes the alarm to
        /// be stuck in the <code>INSUFFICIENT DATA</code> state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatch.StandardUnit")]
        public Amazon.CloudWatch.StandardUnit Unit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.PutMetricAlarmResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AlarmName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWMetricAlarm (PutMetricAlarm)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.PutMetricAlarmResponse, WriteCWMetricAlarmCmdlet>(Select) ??
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
            context.DatapointsToAlarm = this.DatapointsToAlarm;
            if (this.Dimension != null)
            {
                context.Dimension = new List<Amazon.CloudWatch.Model.Dimension>(this.Dimension);
            }
            context.EvaluateLowSampleCountPercentile = this.EvaluateLowSampleCountPercentile;
            context.EvaluationPeriod = this.EvaluationPeriod;
            #if MODULAR
            if (this.EvaluationPeriod == null && ParameterWasBound(nameof(this.EvaluationPeriod)))
            {
                WriteWarning("You are passing $null as a value for parameter EvaluationPeriod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExtendedStatistic = this.ExtendedStatistic;
            if (this.InsufficientDataAction != null)
            {
                context.InsufficientDataAction = new List<System.String>(this.InsufficientDataAction);
            }
            context.MetricName = this.MetricName;
            if (this.Metric != null)
            {
                context.Metric = new List<Amazon.CloudWatch.Model.MetricDataQuery>(this.Metric);
            }
            context.Namespace = this.Namespace;
            if (this.OKAction != null)
            {
                context.OKAction = new List<System.String>(this.OKAction);
            }
            context.Period = this.Period;
            context.Statistic = this.Statistic;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CloudWatch.Model.Tag>(this.Tag);
            }
            context.Threshold = this.Threshold;
            context.ThresholdMetricId = this.ThresholdMetricId;
            context.TreatMissingData = this.TreatMissingData;
            context.Unit = this.Unit;
            
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
            var request = new Amazon.CloudWatch.Model.PutMetricAlarmRequest();
            
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
            if (cmdletContext.DatapointsToAlarm != null)
            {
                request.DatapointsToAlarm = cmdletContext.DatapointsToAlarm.Value;
            }
            if (cmdletContext.Dimension != null)
            {
                request.Dimensions = cmdletContext.Dimension;
            }
            if (cmdletContext.EvaluateLowSampleCountPercentile != null)
            {
                request.EvaluateLowSampleCountPercentile = cmdletContext.EvaluateLowSampleCountPercentile;
            }
            if (cmdletContext.EvaluationPeriod != null)
            {
                request.EvaluationPeriods = cmdletContext.EvaluationPeriod.Value;
            }
            if (cmdletContext.ExtendedStatistic != null)
            {
                request.ExtendedStatistic = cmdletContext.ExtendedStatistic;
            }
            if (cmdletContext.InsufficientDataAction != null)
            {
                request.InsufficientDataActions = cmdletContext.InsufficientDataAction;
            }
            if (cmdletContext.MetricName != null)
            {
                request.MetricName = cmdletContext.MetricName;
            }
            if (cmdletContext.Metric != null)
            {
                request.Metrics = cmdletContext.Metric;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.OKAction != null)
            {
                request.OKActions = cmdletContext.OKAction;
            }
            if (cmdletContext.Period != null)
            {
                request.Period = cmdletContext.Period.Value;
            }
            if (cmdletContext.Statistic != null)
            {
                request.Statistic = cmdletContext.Statistic;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Threshold != null)
            {
                request.Threshold = cmdletContext.Threshold.Value;
            }
            if (cmdletContext.ThresholdMetricId != null)
            {
                request.ThresholdMetricId = cmdletContext.ThresholdMetricId;
            }
            if (cmdletContext.TreatMissingData != null)
            {
                request.TreatMissingData = cmdletContext.TreatMissingData;
            }
            if (cmdletContext.Unit != null)
            {
                request.Unit = cmdletContext.Unit;
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
        
        private Amazon.CloudWatch.Model.PutMetricAlarmResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.PutMetricAlarmRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "PutMetricAlarm");
            try
            {
                #if DESKTOP
                return client.PutMetricAlarm(request);
                #elif CORECLR
                return client.PutMetricAlarmAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ActionsEnabled { get; set; }
            public List<System.String> AlarmAction { get; set; }
            public System.String AlarmDescription { get; set; }
            public System.String AlarmName { get; set; }
            public Amazon.CloudWatch.ComparisonOperator ComparisonOperator { get; set; }
            public System.Int32? DatapointsToAlarm { get; set; }
            public List<Amazon.CloudWatch.Model.Dimension> Dimension { get; set; }
            public System.String EvaluateLowSampleCountPercentile { get; set; }
            public System.Int32? EvaluationPeriod { get; set; }
            public System.String ExtendedStatistic { get; set; }
            public List<System.String> InsufficientDataAction { get; set; }
            public System.String MetricName { get; set; }
            public List<Amazon.CloudWatch.Model.MetricDataQuery> Metric { get; set; }
            public System.String Namespace { get; set; }
            public List<System.String> OKAction { get; set; }
            public System.Int32? Period { get; set; }
            public Amazon.CloudWatch.Statistic Statistic { get; set; }
            public List<Amazon.CloudWatch.Model.Tag> Tag { get; set; }
            public System.Double? Threshold { get; set; }
            public System.String ThresholdMetricId { get; set; }
            public System.String TreatMissingData { get; set; }
            public Amazon.CloudWatch.StandardUnit Unit { get; set; }
            public System.Func<Amazon.CloudWatch.Model.PutMetricAlarmResponse, WriteCWMetricAlarmCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
