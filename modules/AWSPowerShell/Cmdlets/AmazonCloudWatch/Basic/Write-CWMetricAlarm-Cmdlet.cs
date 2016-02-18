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
    /// Creates or updates an alarm and associates it with the specified Amazon CloudWatch
    /// metric. Optionally, this operation can associate one or more Amazon Simple Notification
    /// Service resources with the alarm. 
    /// 
    ///  
    /// <para>
    ///  When this operation creates an alarm, the alarm state is immediately set to <code>INSUFFICIENT_DATA</code>.
    /// The alarm is evaluated and its <code>StateValue</code> is set appropriately. Any actions
    /// associated with the <code>StateValue</code> is then executed. 
    /// </para><note> When updating an existing alarm, its <code>StateValue</code> is left unchanged.
    /// </note><note> If you are using an AWS Identity and Access Management (IAM) account
    /// to create or modify an alarm, you must have the following Amazon EC2 permissions:
    /// <ul><li><code>ec2:DescribeInstanceStatus</code> and <code>ec2:DescribeInstances</code>
    /// for all alarms on Amazon EC2 instance status metrics.</li><li><code>ec2:StopInstances</code>
    /// for alarms with stop actions.</li><li><code>ec2:TerminateInstances</code> for alarms
    /// with terminate actions.</li><li><code>ec2:DescribeInstanceRecoveryAttribute</code>,
    /// and <code>ec2:RecoverInstances</code> for alarms with recover actions.</li></ul><para>
    /// If you have read/write permissions for Amazon CloudWatch but not for Amazon EC2, you
    /// can still create an alarm but the stop or terminate actions won't be performed on
    /// the Amazon EC2 instance. However, if you are later granted permission to use the associated
    /// Amazon EC2 APIs, the alarm actions you created earlier will be performed. For more
    /// information about IAM permissions, see <a href="http://docs.aws.amazon.com//IAM/latest/UserGuide/PermissionsAndPolicies.html">Permissions
    /// and Policies</a> in <i>Using IAM</i>.
    /// </para><para>
    /// If you are using an IAM role (e.g., an Amazon EC2 instance profile), you cannot stop
    /// or terminate the instance using alarm actions. However, you can still see the alarm
    /// state and perform any other actions such as Amazon SNS notifications or Auto Scaling
    /// policies.
    /// </para><para>
    /// If you are using temporary security credentials granted using the AWS Security Token
    /// Service (AWS STS), you cannot stop or terminate an Amazon EC2 instance using alarm
    /// actions.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CWMetricAlarm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutMetricAlarm operation against Amazon CloudWatch.", Operation = new[] {"PutMetricAlarm"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AlarmName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CloudWatch.Model.PutMetricAlarmResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteCWMetricAlarmCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        #region Parameter ActionsEnabled
        /// <summary>
        /// <para>
        /// <para> Indicates whether or not actions should be executed during any changes to the alarm's
        /// state. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ActionsEnabled { get; set; }
        #endregion
        
        #region Parameter AlarmAction
        /// <summary>
        /// <para>
        /// <para> The list of actions to execute when this alarm transitions into an <code>ALARM</code>
        /// state from any other state. Each action is specified as an Amazon Resource Name (ARN).
        /// </para><para>Valid Values: arn:aws:automate:<i>region (e.g., us-east-1)</i>:ec2:stop | arn:aws:automate:<i>region
        /// (e.g., us-east-1)</i>:ec2:terminate | arn:aws:automate:<i>region (e.g., us-east-1)</i>:ec2:recover</para><para>Valid Values (for use with IAM roles): arn:aws:swf:us-east-1:{<i>customer-account</i>}:action/actions/AWS_EC2.InstanceId.Stop/1.0
        /// | arn:aws:swf:us-east-1:{<i>customer-account</i>}:action/actions/AWS_EC2.InstanceId.Terminate/1.0
        /// | arn:aws:swf:us-east-1:{<i>customer-account</i>}:action/actions/AWS_EC2.InstanceId.Reboot/1.0</para><para><b>Note:</b> You must create at least one stop, terminate, or reboot alarm using the
        /// Amazon EC2 or CloudWatch console to create the <b>EC2ActionsAccess</b> IAM role for
        /// the first time. After this IAM role is created, you can create stop, terminate, or
        /// reboot alarms using the CLI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AlarmActions")]
        public System.String[] AlarmAction { get; set; }
        #endregion
        
        #region Parameter AlarmDescription
        /// <summary>
        /// <para>
        /// <para> The description for the alarm. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String AlarmDescription { get; set; }
        #endregion
        
        #region Parameter AlarmName
        /// <summary>
        /// <para>
        /// <para> The descriptive name for the alarm. This name must be unique within the user's AWS
        /// account </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AlarmName { get; set; }
        #endregion
        
        #region Parameter ComparisonOperator
        /// <summary>
        /// <para>
        /// <para> The arithmetic operation to use when comparing the specified <code>Statistic</code>
        /// and <code>Threshold</code>. The specified <code>Statistic</code> value is used as
        /// the first operand. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudWatch.ComparisonOperator")]
        public Amazon.CloudWatch.ComparisonOperator ComparisonOperator { get; set; }
        #endregion
        
        #region Parameter Dimension
        /// <summary>
        /// <para>
        /// <para> The dimensions for the alarm's associated metric. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Dimensions")]
        public Amazon.CloudWatch.Model.Dimension[] Dimension { get; set; }
        #endregion
        
        #region Parameter EvaluationPeriod
        /// <summary>
        /// <para>
        /// <para> The number of periods over which data is compared to the specified threshold. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EvaluationPeriods")]
        public System.Int32 EvaluationPeriod { get; set; }
        #endregion
        
        #region Parameter InsufficientDataAction
        /// <summary>
        /// <para>
        /// <para> The list of actions to execute when this alarm transitions into an <code>INSUFFICIENT_DATA</code>
        /// state from any other state. Each action is specified as an Amazon Resource Name (ARN).
        /// </para><para>Valid Values: arn:aws:automate:<i>region (e.g., us-east-1)</i>:ec2:stop | arn:aws:automate:<i>region
        /// (e.g., us-east-1)</i>:ec2:terminate | arn:aws:automate:<i>region (e.g., us-east-1)</i>:ec2:recover</para><para>Valid Values (for use with IAM roles): arn:aws:swf:us-east-1:{<i>customer-account</i>}:action/actions/AWS_EC2.InstanceId.Stop/1.0
        /// | arn:aws:swf:us-east-1:{<i>customer-account</i>}:action/actions/AWS_EC2.InstanceId.Terminate/1.0
        /// | arn:aws:swf:us-east-1:{<i>customer-account</i>}:action/actions/AWS_EC2.InstanceId.Reboot/1.0</para><para><b>Note:</b> You must create at least one stop, terminate, or reboot alarm using the
        /// Amazon EC2 or CloudWatch console to create the <b>EC2ActionsAccess</b> IAM role for
        /// the first time. After this IAM role is created, you can create stop, terminate, or
        /// reboot alarms using the CLI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InsufficientDataActions")]
        public System.String[] InsufficientDataAction { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para> The name for the alarm's associated metric. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricName { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para> The namespace for the alarm's associated metric. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter OKAction
        /// <summary>
        /// <para>
        /// <para> The list of actions to execute when this alarm transitions into an <code>OK</code>
        /// state from any other state. Each action is specified as an Amazon Resource Name (ARN).
        /// </para><para>Valid Values: arn:aws:automate:<i>region (e.g., us-east-1)</i>:ec2:stop | arn:aws:automate:<i>region
        /// (e.g., us-east-1)</i>:ec2:terminate | arn:aws:automate:<i>region (e.g., us-east-1)</i>:ec2:recover</para><para>Valid Values (for use with IAM roles): arn:aws:swf:us-east-1:{<i>customer-account</i>}:action/actions/AWS_EC2.InstanceId.Stop/1.0
        /// | arn:aws:swf:us-east-1:{<i>customer-account</i>}:action/actions/AWS_EC2.InstanceId.Terminate/1.0
        /// | arn:aws:swf:us-east-1:{<i>customer-account</i>}:action/actions/AWS_EC2.InstanceId.Reboot/1.0</para><para><b>Note:</b> You must create at least one stop, terminate, or reboot alarm using the
        /// Amazon EC2 or CloudWatch console to create the <b>EC2ActionsAccess</b> IAM role for
        /// the first time. After this IAM role is created, you can create stop, terminate, or
        /// reboot alarms using the CLI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OKActions")]
        public System.String[] OKAction { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para> The period in seconds over which the specified statistic is applied. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Period { get; set; }
        #endregion
        
        #region Parameter Statistic
        /// <summary>
        /// <para>
        /// <para> The statistic to apply to the alarm's associated metric. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudWatch.Statistic")]
        public Amazon.CloudWatch.Statistic Statistic { get; set; }
        #endregion
        
        #region Parameter Threshold
        /// <summary>
        /// <para>
        /// <para> The value against which the specified statistic is compared. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double Threshold { get; set; }
        #endregion
        
        #region Parameter Unit
        /// <summary>
        /// <para>
        /// <para> The statistic's unit of measure. For example, the units for the Amazon EC2 NetworkIn
        /// metric are Bytes because NetworkIn tracks the number of bytes that an instance receives
        /// on all network interfaces. You can also specify a unit when you create a custom metric.
        /// Units help provide conceptual meaning to your data. Metric data points that specify
        /// a unit of measure, such as Percent, are aggregated separately. </para><para><b>Note:</b> If you specify a unit, you must use a unit that is appropriate for the
        /// metric. Otherwise, this can cause an Amazon CloudWatch alarm to get stuck in the INSUFFICIENT
        /// DATA state. </para>
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
            
            if (ParameterWasBound("ActionsEnabled"))
                context.ActionsEnabled = this.ActionsEnabled;
            if (this.AlarmAction != null)
            {
                context.AlarmActions = new List<System.String>(this.AlarmAction);
            }
            context.AlarmDescription = this.AlarmDescription;
            context.AlarmName = this.AlarmName;
            context.ComparisonOperator = this.ComparisonOperator;
            if (this.Dimension != null)
            {
                context.Dimensions = new List<Amazon.CloudWatch.Model.Dimension>(this.Dimension);
            }
            if (ParameterWasBound("EvaluationPeriod"))
                context.EvaluationPeriods = this.EvaluationPeriod;
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
            context.Unit = this.Unit;
            
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
            if (cmdletContext.Dimensions != null)
            {
                request.Dimensions = cmdletContext.Dimensions;
            }
            if (cmdletContext.EvaluationPeriods != null)
            {
                request.EvaluationPeriods = cmdletContext.EvaluationPeriods.Value;
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
            if (cmdletContext.Unit != null)
            {
                request.Unit = cmdletContext.Unit;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PutMetricAlarm(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Boolean? ActionsEnabled { get; set; }
            public List<System.String> AlarmActions { get; set; }
            public System.String AlarmDescription { get; set; }
            public System.String AlarmName { get; set; }
            public Amazon.CloudWatch.ComparisonOperator ComparisonOperator { get; set; }
            public List<Amazon.CloudWatch.Model.Dimension> Dimensions { get; set; }
            public System.Int32? EvaluationPeriods { get; set; }
            public List<System.String> InsufficientDataActions { get; set; }
            public System.String MetricName { get; set; }
            public System.String Namespace { get; set; }
            public List<System.String> OKActions { get; set; }
            public System.Int32? Period { get; set; }
            public Amazon.CloudWatch.Statistic Statistic { get; set; }
            public System.Double? Threshold { get; set; }
            public Amazon.CloudWatch.StandardUnit Unit { get; set; }
        }
        
    }
}
