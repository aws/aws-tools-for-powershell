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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Creates or updates an alarm and associates it with the specified metric, metric math
    /// expression, anomaly detection model, or Metrics Insights query. For more information
    /// about using a Metrics Insights query for an alarm, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/Create_Metrics_Insights_Alarm.html">Create
    /// alarms on Metrics Insights queries</a>.
    /// 
    ///  
    /// <para>
    /// Alarms based on anomaly detection models cannot have Auto Scaling actions.
    /// </para><para>
    /// When this operation creates an alarm, the alarm state is immediately set to <c>INSUFFICIENT_DATA</c>.
    /// The alarm is then evaluated and its state is set appropriately. Any actions associated
    /// with the new state are then executed.
    /// </para><para>
    /// When you update an existing alarm, its state is left unchanged, but the update completely
    /// overwrites the previous configuration of the alarm.
    /// </para><para>
    /// If you are an IAM user, you must have Amazon EC2 permissions for some alarm operations:
    /// </para><ul><li><para>
    /// The <c>iam:CreateServiceLinkedRole</c> permission for all alarms with EC2 actions
    /// </para></li><li><para>
    /// The <c>iam:CreateServiceLinkedRole</c> permissions to create an alarm with Systems
    /// Manager OpsItem or response plan actions.
    /// </para></li></ul><para>
    /// The first time you create an alarm in the Amazon Web Services Management Console,
    /// the CLI, or by using the PutMetricAlarm API, CloudWatch creates the necessary service-linked
    /// role for you. The service-linked roles are called <c>AWSServiceRoleForCloudWatchEvents</c>
    /// and <c>AWSServiceRoleForCloudWatchAlarms_ActionSSM</c>. For more information, see
    /// <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_terms-and-concepts.html#iam-term-service-linked-role">Amazon
    /// Web Services service-linked role</a>.
    /// </para><para>
    /// Each <c>PutMetricAlarm</c> action has a maximum uncompressed payload of 120 KB.
    /// </para><para><b>Cross-account alarms</b></para><para>
    /// You can set an alarm on metrics in the current account, or in another account. To
    /// create a cross-account alarm that watches a metric in a different account, you must
    /// have completed the following pre-requisites:
    /// </para><ul><li><para>
    /// The account where the metrics are located (the <i>sharing account</i>) must already
    /// have a sharing role named <b>CloudWatch-CrossAccountSharingRole</b>. If it does not
    /// already have this role, you must create it using the instructions in <b>Set up a sharing
    /// account</b> in <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/Cross-Account-Cross-Region.html#enable-cross-account-cross-Region">
    /// Cross-account cross-Region CloudWatch console</a>. The policy for that role must grant
    /// access to the ID of the account where you are creating the alarm. 
    /// </para></li><li><para>
    /// The account where you are creating the alarm (the <i>monitoring account</i>) must
    /// already have a service-linked role named <b>AWSServiceRoleForCloudWatchCrossAccount</b>
    /// to allow CloudWatch to assume the sharing role in the sharing account. If it does
    /// not, you must create it following the directions in <b>Set up a monitoring account</b>
    /// in <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/Cross-Account-Cross-Region.html#enable-cross-account-cross-Region">
    /// Cross-account cross-Region CloudWatch console</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Write", "CWMetricAlarm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch PutMetricAlarm API operation.", Operation = new[] {"PutMetricAlarm"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.PutMetricAlarmResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatch.Model.PutMetricAlarmResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatch.Model.PutMetricAlarmResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCWMetricAlarmCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActionsEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether actions should be executed during any changes to the alarm state.
        /// The default is <c>TRUE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ActionsEnabled { get; set; }
        #endregion
        
        #region Parameter AlarmAction
        /// <summary>
        /// <para>
        /// <para>The actions to execute when this alarm transitions to the <c>ALARM</c> state from
        /// any other state. Each action is specified as an Amazon Resource Name (ARN). Valid
        /// values:</para><para><b>EC2 actions:</b></para><ul><li><para><c>arn:aws:automate:<i>region</i>:ec2:stop</c></para></li><li><para><c>arn:aws:automate:<i>region</i>:ec2:terminate</c></para></li><li><para><c>arn:aws:automate:<i>region</i>:ec2:reboot</c></para></li><li><para><c>arn:aws:automate:<i>region</i>:ec2:recover</c></para></li><li><para><c>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Stop/1.0</c></para></li><li><para><c>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Terminate/1.0</c></para></li><li><para><c>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Reboot/1.0</c></para></li><li><para><c>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Recover/1.0</c></para></li></ul><para><b>Autoscaling action:</b></para><ul><li><para><c>arn:aws:autoscaling:<i>region</i>:<i>account-id</i>:scalingPolicy:<i>policy-id</i>:autoScalingGroupName/<i>group-friendly-name</i>:policyName/<i>policy-friendly-name</i></c></para></li></ul><para><b>Lambda actions:</b></para><ul><li><para>Invoke the latest version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i></c></para></li><li><para>Invoke a specific version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>version-number</i></c></para></li><li><para>Invoke a function by using an alias Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>alias-name</i></c></para></li></ul><para><b>SNS notification action:</b></para><ul><li><para><c>arn:aws:sns:<i>region</i>:<i>account-id</i>:<i>sns-topic-name</i></c></para></li></ul><para><b>SSM integration actions:</b></para><ul><li><para><c>arn:aws:ssm:<i>region</i>:<i>account-id</i>:opsitem:<i>severity</i>#CATEGORY=<i>category-name</i></c></para></li><li><para><c>arn:aws:ssm-incidents::<i>account-id</i>:responseplan/<i>response-plan-name</i></c></para></li></ul><para><b>Start a Amazon Q Developer operational investigation</b></para><para><c>arn:aws:aiops:<i>region</i>:<i>account-id</i>:investigation-group:<i>investigation-group-id</i></c></para>
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
        /// <para>The name for the alarm. This name must be unique within the Region.</para><para>The name must contain only UTF-8 characters, and can't contain ASCII control characters</para>
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
        /// The specified statistic value is used as the first operand.</para><para>The values <c>LessThanLowerOrGreaterThanUpperThreshold</c>, <c>LessThanLowerThreshold</c>,
        /// and <c>GreaterThanUpperThreshold</c> are used only for alarms based on anomaly detection
        /// models.</para>
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
        /// <para>The dimensions for the metric specified in <c>MetricName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Dimensions")]
        public Amazon.CloudWatch.Model.Dimension[] Dimension { get; set; }
        #endregion
        
        #region Parameter EvaluateLowSampleCountPercentile
        /// <summary>
        /// <para>
        /// <para> Used only for alarms based on percentiles. If you specify <c>ignore</c>, the alarm
        /// state does not change during periods with too few data points to be statistically
        /// significant. If you specify <c>evaluate</c> or omit this parameter, the alarm is always
        /// evaluated and possibly changes state no matter how many data points are available.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/AlarmThatSendsEmail.html#percentiles-with-low-samples">Percentile-Based
        /// CloudWatch Alarms and Low Data Samples</a>.</para><para>Valid Values: <c>evaluate | ignore</c></para>
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
        /// of N" alarm, this value is the N.</para>
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
        /// <para>The extended statistic for the metric specified in <c>MetricName</c>. When you call
        /// <c>PutMetricAlarm</c> and specify a <c>MetricName</c>, you must specify either <c>Statistic</c>
        /// or <c>ExtendedStatistic</c> but not both.</para><para>If you specify <c>ExtendedStatistic</c>, the following are valid values:</para><ul><li><para><c>p90</c></para></li><li><para><c>tm90</c></para></li><li><para><c>tc90</c></para></li><li><para><c>ts90</c></para></li><li><para><c>wm90</c></para></li><li><para><c>IQM</c></para></li><li><para><c>PR(<i>n</i>:<i>m</i>)</c> where n and m are values of the metric</para></li><li><para><c>TC(<i>X</i>%:<i>X</i>%)</c> where X is between 10 and 90 inclusive.</para></li><li><para><c>TM(<i>X</i>%:<i>X</i>%)</c> where X is between 10 and 90 inclusive.</para></li><li><para><c>TS(<i>X</i>%:<i>X</i>%)</c> where X is between 10 and 90 inclusive.</para></li><li><para><c>WM(<i>X</i>%:<i>X</i>%)</c> where X is between 10 and 90 inclusive.</para></li></ul><para>For more information about these extended statistics, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/Statistics-definitions.html">CloudWatch
        /// statistics definitions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExtendedStatistic { get; set; }
        #endregion
        
        #region Parameter InsufficientDataAction
        /// <summary>
        /// <para>
        /// <para>The actions to execute when this alarm transitions to the <c>INSUFFICIENT_DATA</c>
        /// state from any other state. Each action is specified as an Amazon Resource Name (ARN).
        /// Valid values:</para><para><b>EC2 actions:</b></para><ul><li><para><c>arn:aws:automate:<i>region</i>:ec2:stop</c></para></li><li><para><c>arn:aws:automate:<i>region</i>:ec2:terminate</c></para></li><li><para><c>arn:aws:automate:<i>region</i>:ec2:reboot</c></para></li><li><para><c>arn:aws:automate:<i>region</i>:ec2:recover</c></para></li><li><para><c>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Stop/1.0</c></para></li><li><para><c>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Terminate/1.0</c></para></li><li><para><c>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Reboot/1.0</c></para></li><li><para><c>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Recover/1.0</c></para></li></ul><para><b>Autoscaling action:</b></para><ul><li><para><c>arn:aws:autoscaling:<i>region</i>:<i>account-id</i>:scalingPolicy:<i>policy-id</i>:autoScalingGroupName/<i>group-friendly-name</i>:policyName/<i>policy-friendly-name</i></c></para></li></ul><para><b>Lambda actions:</b></para><ul><li><para>Invoke the latest version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i></c></para></li><li><para>Invoke a specific version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>version-number</i></c></para></li><li><para>Invoke a function by using an alias Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>alias-name</i></c></para></li></ul><para><b>SNS notification action:</b></para><ul><li><para><c>arn:aws:sns:<i>region</i>:<i>account-id</i>:<i>sns-topic-name</i></c></para></li></ul><para><b>SSM integration actions:</b></para><ul><li><para><c>arn:aws:ssm:<i>region</i>:<i>account-id</i>:opsitem:<i>severity</i>#CATEGORY=<i>category-name</i></c></para></li><li><para><c>arn:aws:ssm-incidents::<i>account-id</i>:responseplan/<i>response-plan-name</i></c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InsufficientDataActions")]
        public System.String[] InsufficientDataAction { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>The name for the metric associated with the alarm. For each <c>PutMetricAlarm</c>
        /// operation, you must specify either <c>MetricName</c> or a <c>Metrics</c> array.</para><para>If you are creating an alarm based on a math expression, you cannot specify this parameter,
        /// or any of the <c>Namespace</c>, <c>Dimensions</c>, <c>Period</c>, <c>Unit</c>, <c>Statistic</c>,
        /// or <c>ExtendedStatistic</c> parameters. Instead, you specify all this information
        /// in the <c>Metrics</c> array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricName { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>An array of <c>MetricDataQuery</c> structures that enable you to create an alarm based
        /// on the result of a metric math expression. For each <c>PutMetricAlarm</c> operation,
        /// you must specify either <c>MetricName</c> or a <c>Metrics</c> array.</para><para>Each item in the <c>Metrics</c> array either retrieves a metric or performs a math
        /// expression.</para><para>One item in the <c>Metrics</c> array is the expression that the alarm watches. You
        /// designate this expression by setting <c>ReturnData</c> to true for this object in
        /// the array. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_MetricDataQuery.html">MetricDataQuery</a>.</para><para>If you use the <c>Metrics</c> parameter, you cannot include the <c>Namespace</c>,
        /// <c>MetricName</c>, <c>Dimensions</c>, <c>Period</c>, <c>Unit</c>, <c>Statistic</c>,
        /// or <c>ExtendedStatistic</c> parameters of <c>PutMetricAlarm</c> in the same operation.
        /// Instead, you retrieve the metrics you are using in your math expression as part of
        /// the <c>Metrics</c> array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Metrics")]
        public Amazon.CloudWatch.Model.MetricDataQuery[] Metric { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace for the metric associated specified in <c>MetricName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter OKAction
        /// <summary>
        /// <para>
        /// <para>The actions to execute when this alarm transitions to an <c>OK</c> state from any
        /// other state. Each action is specified as an Amazon Resource Name (ARN). Valid values:</para><para><b>EC2 actions:</b></para><ul><li><para><c>arn:aws:automate:<i>region</i>:ec2:stop</c></para></li><li><para><c>arn:aws:automate:<i>region</i>:ec2:terminate</c></para></li><li><para><c>arn:aws:automate:<i>region</i>:ec2:reboot</c></para></li><li><para><c>arn:aws:automate:<i>region</i>:ec2:recover</c></para></li><li><para><c>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Stop/1.0</c></para></li><li><para><c>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Terminate/1.0</c></para></li><li><para><c>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Reboot/1.0</c></para></li><li><para><c>arn:aws:swf:<i>region</i>:<i>account-id</i>:action/actions/AWS_EC2.InstanceId.Recover/1.0</c></para></li></ul><para><b>Autoscaling action:</b></para><ul><li><para><c>arn:aws:autoscaling:<i>region</i>:<i>account-id</i>:scalingPolicy:<i>policy-id</i>:autoScalingGroupName/<i>group-friendly-name</i>:policyName/<i>policy-friendly-name</i></c></para></li></ul><para><b>Lambda actions:</b></para><ul><li><para>Invoke the latest version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i></c></para></li><li><para>Invoke a specific version of a Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>version-number</i></c></para></li><li><para>Invoke a function by using an alias Lambda function: <c>arn:aws:lambda:<i>region</i>:<i>account-id</i>:function:<i>function-name</i>:<i>alias-name</i></c></para></li></ul><para><b>SNS notification action:</b></para><ul><li><para><c>arn:aws:sns:<i>region</i>:<i>account-id</i>:<i>sns-topic-name</i></c></para></li></ul><para><b>SSM integration actions:</b></para><ul><li><para><c>arn:aws:ssm:<i>region</i>:<i>account-id</i>:opsitem:<i>severity</i>#CATEGORY=<i>category-name</i></c></para></li><li><para><c>arn:aws:ssm-incidents::<i>account-id</i>:responseplan/<i>response-plan-name</i></c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OKActions")]
        public System.String[] OKAction { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para>The length, in seconds, used each time the metric specified in <c>MetricName</c> is
        /// evaluated. Valid values are 10, 20, 30, and any multiple of 60.</para><para><c>Period</c> is required for alarms based on static thresholds. If you are creating
        /// an alarm based on a metric math expression, you specify the period for each metric
        /// within the objects in the <c>Metrics</c> array.</para><para>Be sure to specify 10, 20, or 30 only for metrics that are stored by a <c>PutMetricData</c>
        /// call with a <c>StorageResolution</c> of 1. If you specify a period of 10, 20, or 30
        /// for a metric that does not have sub-minute resolution, the alarm still attempts to
        /// gather data at the period rate that you specify. In this case, it does not receive
        /// data for the attempts that do not correspond to a one-minute data resolution, and
        /// the alarm might often lapse into INSUFFICENT_DATA status. Specifying 10, 20, or 30
        /// also sets this alarm as a high-resolution alarm, which has a higher charge than other
        /// alarms. For more information about pricing, see <a href="https://aws.amazon.com/cloudwatch/pricing/">Amazon
        /// CloudWatch Pricing</a>.</para><para>An alarm's total current evaluation period can be no longer than seven days, so <c>Period</c>
        /// multiplied by <c>EvaluationPeriods</c> can't be more than 604,800 seconds. For alarms
        /// with a period of less than one hour (3,600 seconds), the total evaluation period can't
        /// be longer than one day (86,400 seconds).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Period { get; set; }
        #endregion
        
        #region Parameter Statistic
        /// <summary>
        /// <para>
        /// <para>The statistic for the metric specified in <c>MetricName</c>, other than percentile.
        /// For percentile statistics, use <c>ExtendedStatistic</c>. When you call <c>PutMetricAlarm</c>
        /// and specify a <c>MetricName</c>, you must specify either <c>Statistic</c> or <c>ExtendedStatistic,</c>
        /// but not both.</para>
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
        /// 50 tags with an alarm. To be able to associate tags with the alarm when you create
        /// the alarm, you must have the <c>cloudwatch:TagResource</c> permission.</para><para>Tags can help you organize and categorize your resources. You can also use them to
        /// scope user permissions by granting a user permission to access or change only resources
        /// with certain tag values.</para><para>If you are using this operation to update an existing alarm, any tags you specify
        /// in this parameter are ignored. To change the tags of an existing alarm, use <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_TagResource.html">TagResource</a>
        /// or <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_UntagResource.html">UntagResource</a>.</para><para>To use this field to set tags for an alarm when you create it, you must be signed
        /// on with both the <c>cloudwatch:PutMetricAlarm</c> and <c>cloudwatch:TagResource</c>
        /// permissions.</para>
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
        /// ID of the <c>ANOMALY_DETECTION_BAND</c> function.</para><para>For an example of how to use this parameter, see the <b>Anomaly Detection Model Alarm</b>
        /// example on this page.</para><para>If your alarm uses this parameter, it cannot have Auto Scaling actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ThresholdMetricId { get; set; }
        #endregion
        
        #region Parameter TreatMissingData
        /// <summary>
        /// <para>
        /// <para> Sets how this alarm is to handle missing data points. If <c>TreatMissingData</c>
        /// is omitted, the default behavior of <c>missing</c> is used. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/AlarmThatSendsEmail.html#alarms-and-missing-data">Configuring
        /// How CloudWatch Alarms Treats Missing Data</a>.</para><para>Valid Values: <c>breaching | notBreaching | ignore | missing</c></para><note><para>Alarms that evaluate metrics in the <c>AWS/DynamoDB</c> namespace always <c>ignore</c>
        /// missing data even if you choose a different option for <c>TreatMissingData</c>. When
        /// an <c>AWS/DynamoDB</c> metric has missing data, alarms that evaluate that metric remain
        /// in their current state.</para></note>
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
        /// a unit of measure, such as Percent, are aggregated separately. If you are creating
        /// an alarm based on a metric math expression, you can specify the unit for each metric
        /// (if needed) within the objects in the <c>Metrics</c> array.</para><para>If you don't specify <c>Unit</c>, CloudWatch retrieves all unit types that have been
        /// published for the metric and attempts to evaluate the alarm. Usually, metrics are
        /// published with only one unit, so the alarm works as intended.</para><para>However, if the metric is published with multiple types of units and you don't specify
        /// a unit, the alarm's behavior is not defined and it behaves unpredictably.</para><para>We recommend omitting <c>Unit</c> so that you don't inadvertently specify an incorrect
        /// unit that is not published for this metric. Doing so causes the alarm to be stuck
        /// in the <c>INSUFFICIENT DATA</c> state.</para>
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
            this._AWSSignerType = "v4";
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
