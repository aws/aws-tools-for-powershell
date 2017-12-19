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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Creates or updates an alarm and associates it with the specified metric. Optionally,
    /// this operation can associate one or more Amazon SNS resources with the alarm.
    /// 
    ///  
    /// <para>
    /// When this operation creates an alarm, the alarm state is immediately set to <code>INSUFFICIENT_DATA</code>.
    /// The alarm is evaluated and its state is set appropriately. Any actions associated
    /// with the state are then executed.
    /// </para><para>
    /// When you update an existing alarm, its state is left unchanged, but the update completely
    /// overwrites the previous configuration of the alarm.
    /// </para><para>
    /// If you are an IAM user, you must have Amazon EC2 permissions for some operations:
    /// </para><ul><li><para><code>iam:CreateServiceLinkedRole</code> for all alarms with EC2 actions
    /// </para></li><li><para><code>ec2:DescribeInstanceStatus</code> and <code>ec2:DescribeInstances</code> for
    /// all alarms on EC2 instance status metrics
    /// </para></li><li><para><code>ec2:StopInstances</code> for alarms with stop actions
    /// </para></li><li><para><code>ec2:TerminateInstances</code> for alarms with terminate actions
    /// </para></li><li><para><code>ec2:DescribeInstanceRecoveryAttribute</code> and <code>ec2:RecoverInstances</code>
    /// for alarms with recover actions
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
    /// You must create at least one stop, terminate, or reboot alarm using either the Amazon
    /// EC2 or CloudWatch consoles to create the <b>EC2ActionsAccess</b> IAM role. After this
    /// IAM role is created, you can create stop, terminate, or reboot alarms using a command-line
    /// interface or API.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWMetricAlarm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon CloudWatch PutMetricAlarm API operation.", Operation = new[] {"PutMetricAlarm"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AlarmName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CloudWatch.Model.PutMetricAlarmResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCWMetricAlarmCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        #region Parameter ActionsEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether actions should be executed during any changes to the alarm state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ActionsEnabled { get; set; }
        #endregion
        
        #region Parameter AlarmAction
        /// <summary>
        /// <para>
        /// <para>The actions to execute when this alarm transitions to the <code>ALARM</code> state
        /// from any other state. Each action is specified as an Amazon Resource Name (ARN).</para><para>Valid Values: arn:aws:automate:<i>region</i>:ec2:stop | arn:aws:automate:<i>region</i>:ec2:terminate
        /// | arn:aws:automate:<i>region</i>:ec2:recover | arn:aws:sns:<i>region</i>:<i>account-id</i>:<i>sns-topic-name</i>
        /// | arn:aws:autoscaling:<i>region</i>:<i>account-id</i>:scalingPolicy:<i>policy-id</i>
        /// autoScalingGroupName/<i>group-friendly-name</i>:policyName/<i>policy-friendly-name</i></para><para>Valid Values (for use with IAM roles): arn:aws:swf:<i>region</i>:{<i>account-id</i>}:action/actions/AWS_EC2.InstanceId.Stop/1.0
        /// | arn:aws:swf:<i>region</i>:{<i>account-id</i>}:action/actions/AWS_EC2.InstanceId.Terminate/1.0
        /// | arn:aws:swf:<i>region</i>:{<i>account-id</i>}:action/actions/AWS_EC2.InstanceId.Reboot/1.0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AlarmActions")]
        public System.String[] AlarmAction { get; set; }
        #endregion
        
        #region Parameter AlarmDescription
        /// <summary>
        /// <para>
        /// <para>The description for the alarm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String AlarmDescription { get; set; }
        #endregion
        
        #region Parameter AlarmName
        /// <summary>
        /// <para>
        /// <para>The name for the alarm. This name must be unique within the AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AlarmName { get; set; }
        #endregion
        
        #region Parameter ComparisonOperator
        /// <summary>
        /// <para>
        /// <para> The arithmetic operation to use when comparing the specified statistic and threshold.
        /// The specified statistic value is used as the first operand.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudWatch.ComparisonOperator")]
        public Amazon.CloudWatch.ComparisonOperator ComparisonOperator { get; set; }
        #endregion
        
        #region Parameter DatapointsToAlarm
        /// <summary>
        /// <para>
        /// <para>The number of datapoints that must be breaching to trigger the alarm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DatapointsToAlarm { get; set; }
        #endregion
        
        #region Parameter Dimension
        /// <summary>
        /// <para>
        /// <para>The dimensions for the metric associated with the alarm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        /// available. For more information, see <a href="http://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/AlarmThatSendsEmail.html#percentiles-with-low-samples">Percentile-Based
        /// CloudWatch Alarms and Low Data Samples</a>.</para><para>Valid Values: <code>evaluate | ignore</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EvaluateLowSampleCountPercentile { get; set; }
        #endregion
        
        #region Parameter EvaluationPeriod
        /// <summary>
        /// <para>
        /// <para>The number of periods over which data is compared to the specified threshold. An alarm's
        /// total current evaluation period can be no longer than one day, so this number multiplied
        /// by <code>Period</code> cannot be more than 86,400 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EvaluationPeriods")]
        public System.Int32 EvaluationPeriod { get; set; }
        #endregion
        
        #region Parameter ExtendedStatistic
        /// <summary>
        /// <para>
        /// <para>The percentile statistic for the metric associated with the alarm. Specify a value
        /// between p0.0 and p100. When you call <code>PutMetricAlarm</code>, you must specify
        /// either <code>Statistic</code> or <code>ExtendedStatistic,</code> but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExtendedStatistic { get; set; }
        #endregion
        
        #region Parameter InsufficientDataAction
        /// <summary>
        /// <para>
        /// <para>The actions to execute when this alarm transitions to the <code>INSUFFICIENT_DATA</code>
        /// state from any other state. Each action is specified as an Amazon Resource Name (ARN).</para><para>Valid Values: arn:aws:automate:<i>region</i>:ec2:stop | arn:aws:automate:<i>region</i>:ec2:terminate
        /// | arn:aws:automate:<i>region</i>:ec2:recover | arn:aws:sns:<i>region</i>:<i>account-id</i>:<i>sns-topic-name</i>
        /// | arn:aws:autoscaling:<i>region</i>:<i>account-id</i>:scalingPolicy:<i>policy-id</i>
        /// autoScalingGroupName/<i>group-friendly-name</i>:policyName/<i>policy-friendly-name</i></para><para>Valid Values (for use with IAM roles): arn:aws:swf:<i>region</i>:{<i>account-id</i>}:action/actions/AWS_EC2.InstanceId.Stop/1.0
        /// | arn:aws:swf:<i>region</i>:{<i>account-id</i>}:action/actions/AWS_EC2.InstanceId.Terminate/1.0
        /// | arn:aws:swf:<i>region</i>:{<i>account-id</i>}:action/actions/AWS_EC2.InstanceId.Reboot/1.0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InsufficientDataActions")]
        public System.String[] InsufficientDataAction { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>The name for the metric associated with the alarm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricName { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace for the metric associated with the alarm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter OKAction
        /// <summary>
        /// <para>
        /// <para>The actions to execute when this alarm transitions to an <code>OK</code> state from
        /// any other state. Each action is specified as an Amazon Resource Name (ARN).</para><para>Valid Values: arn:aws:automate:<i>region</i>:ec2:stop | arn:aws:automate:<i>region</i>:ec2:terminate
        /// | arn:aws:automate:<i>region</i>:ec2:recover | arn:aws:sns:<i>region</i>:<i>account-id</i>:<i>sns-topic-name</i>
        /// | arn:aws:autoscaling:<i>region</i>:<i>account-id</i>:scalingPolicy:<i>policy-id</i>
        /// autoScalingGroupName/<i>group-friendly-name</i>:policyName/<i>policy-friendly-name</i></para><para>Valid Values (for use with IAM roles): arn:aws:swf:<i>region</i>:{<i>account-id</i>}:action/actions/AWS_EC2.InstanceId.Stop/1.0
        /// | arn:aws:swf:<i>region</i>:{<i>account-id</i>}:action/actions/AWS_EC2.InstanceId.Terminate/1.0
        /// | arn:aws:swf:<i>region</i>:{<i>account-id</i>}:action/actions/AWS_EC2.InstanceId.Reboot/1.0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OKActions")]
        public System.String[] OKAction { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para>The period, in seconds, over which the specified statistic is applied. Valid values
        /// are 10, 30, and any multiple of 60.</para><para>Be sure to specify 10 or 30 only for metrics that are stored by a <code>PutMetricData</code>
        /// call with a <code>StorageResolution</code> of 1. If you specify a Period of 10 or
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
        [System.Management.Automation.Parameter]
        public System.Int32 Period { get; set; }
        #endregion
        
        #region Parameter Statistic
        /// <summary>
        /// <para>
        /// <para>The statistic for the metric associated with the alarm, other than percentile. For
        /// percentile statistics, use <code>ExtendedStatistic</code>. When you call <code>PutMetricAlarm</code>,
        /// you must specify either <code>Statistic</code> or <code>ExtendedStatistic,</code>
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudWatch.Statistic")]
        public Amazon.CloudWatch.Statistic Statistic { get; set; }
        #endregion
        
        #region Parameter Threshold
        /// <summary>
        /// <para>
        /// <para>The value against which the specified statistic is compared.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double Threshold { get; set; }
        #endregion
        
        #region Parameter TreatMissingData
        /// <summary>
        /// <para>
        /// <para> Sets how this alarm is to handle missing data points. If <code>TreatMissingData</code>
        /// is omitted, the default behavior of <code>missing</code> is used. For more information,
        /// see <a href="http://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/AlarmThatSendsEmail.html#alarms-and-missing-data">Configuring
        /// How CloudWatch Alarms Treats Missing Data</a>.</para><para>Valid Values: <code>breaching | notBreaching | ignore | missing</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TreatMissingData { get; set; }
        #endregion
        
        #region Parameter Unit
        /// <summary>
        /// <para>
        /// <para>The unit of measure for the statistic. For example, the units for the Amazon EC2 NetworkIn
        /// metric are Bytes because NetworkIn tracks the number of bytes that an instance receives
        /// on all network interfaces. You can also specify a unit when you create a custom metric.
        /// Units help provide conceptual meaning to your data. Metric data points that specify
        /// a unit of measure, such as Percent, are aggregated separately.</para><para>If you specify a unit, you must use a unit that is appropriate for the metric. Otherwise,
        /// the CloudWatch alarm can get stuck in the <code>INSUFFICIENT DATA</code> state. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudWatch.StandardUnit")]
        public Amazon.CloudWatch.StandardUnit Unit { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the AlarmName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AlarmName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWMetricAlarm (PutMetricAlarm)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("ActionsEnabled"))
                context.ActionsEnabled = this.ActionsEnabled;
            if (this.AlarmAction != null)
            {
                context.AlarmActions = new List<System.String>(this.AlarmAction);
            }
            context.AlarmDescription = this.AlarmDescription;
            context.AlarmName = this.AlarmName;
            context.ComparisonOperator = this.ComparisonOperator;
            if (ParameterWasBound("DatapointsToAlarm"))
                context.DatapointsToAlarm = this.DatapointsToAlarm;
            if (this.Dimension != null)
            {
                context.Dimensions = new List<Amazon.CloudWatch.Model.Dimension>(this.Dimension);
            }
            context.EvaluateLowSampleCountPercentile = this.EvaluateLowSampleCountPercentile;
            if (ParameterWasBound("EvaluationPeriod"))
                context.EvaluationPeriods = this.EvaluationPeriod;
            context.ExtendedStatistic = this.ExtendedStatistic;
            if (this.InsufficientDataAction != null)
            {
                context.InsufficientDataActions = new List<System.String>(this.InsufficientDataAction);
            }
            context.MetricName = this.MetricName;
            context.Namespace = this.Namespace;
            if (this.OKAction != null)
            {
                context.OKActions = new List<System.String>(this.OKAction);
            }
            if (ParameterWasBound("Period"))
                context.Period = this.Period;
            context.Statistic = this.Statistic;
            if (ParameterWasBound("Threshold"))
                context.Threshold = this.Threshold;
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
            if (cmdletContext.AlarmActions != null)
            {
                request.AlarmActions = cmdletContext.AlarmActions;
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
            if (cmdletContext.Dimensions != null)
            {
                request.Dimensions = cmdletContext.Dimensions;
            }
            if (cmdletContext.EvaluateLowSampleCountPercentile != null)
            {
                request.EvaluateLowSampleCountPercentile = cmdletContext.EvaluateLowSampleCountPercentile;
            }
            if (cmdletContext.EvaluationPeriods != null)
            {
                request.EvaluationPeriods = cmdletContext.EvaluationPeriods.Value;
            }
            if (cmdletContext.ExtendedStatistic != null)
            {
                request.ExtendedStatistic = cmdletContext.ExtendedStatistic;
            }
            if (cmdletContext.InsufficientDataActions != null)
            {
                request.InsufficientDataActions = cmdletContext.InsufficientDataActions;
            }
            if (cmdletContext.MetricName != null)
            {
                request.MetricName = cmdletContext.MetricName;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.OKActions != null)
            {
                request.OKActions = cmdletContext.OKActions;
            }
            if (cmdletContext.Period != null)
            {
                request.Period = cmdletContext.Period.Value;
            }
            if (cmdletContext.Statistic != null)
            {
                request.Statistic = cmdletContext.Statistic;
            }
            if (cmdletContext.Threshold != null)
            {
                request.Threshold = cmdletContext.Threshold.Value;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.AlarmName;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutMetricAlarmAsync(request);
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
            public System.Boolean? ActionsEnabled { get; set; }
            public List<System.String> AlarmActions { get; set; }
            public System.String AlarmDescription { get; set; }
            public System.String AlarmName { get; set; }
            public Amazon.CloudWatch.ComparisonOperator ComparisonOperator { get; set; }
            public System.Int32? DatapointsToAlarm { get; set; }
            public List<Amazon.CloudWatch.Model.Dimension> Dimensions { get; set; }
            public System.String EvaluateLowSampleCountPercentile { get; set; }
            public System.Int32? EvaluationPeriods { get; set; }
            public System.String ExtendedStatistic { get; set; }
            public List<System.String> InsufficientDataActions { get; set; }
            public System.String MetricName { get; set; }
            public System.String Namespace { get; set; }
            public List<System.String> OKActions { get; set; }
            public System.Int32? Period { get; set; }
            public Amazon.CloudWatch.Statistic Statistic { get; set; }
            public System.Double? Threshold { get; set; }
            public System.String TreatMissingData { get; set; }
            public Amazon.CloudWatch.StandardUnit Unit { get; set; }
        }
        
    }
}
