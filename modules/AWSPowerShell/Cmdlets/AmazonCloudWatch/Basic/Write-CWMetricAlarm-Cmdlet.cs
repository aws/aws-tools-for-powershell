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
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWMetricAlarm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutMetricAlarm operation against Amazon CloudWatch.", Operation = new[] {"PutMetricAlarm"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AlarmName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type PutMetricAlarmResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteCWMetricAlarmCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> Indicates whether or not actions should be executed during any changes to the alarm's
        /// state. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean ActionsEnabled { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The list of actions to execute when this alarm transitions into an <code>ALARM</code>
        /// state from any other state. Each action is specified as an Amazon Resource Number
        /// (ARN). Currently the only action supported is publishing to an Amazon SNS topic or
        /// an Amazon Auto Scaling policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AlarmActions")]
        public System.String[] AlarmAction { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The description for the alarm. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String AlarmDescription { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The descriptive name for the alarm. This name must be unique within the user's AWS
        /// account </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String AlarmName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The arithmetic operation to use when comparing the specified <code>Statistic</code>
        /// and <code>Threshold</code>. The specified <code>Statistic</code> value is used as
        /// the first operand. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public ComparisonOperator ComparisonOperator { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The dimensions for the alarm's associated metric. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Dimensions")]
        public Amazon.CloudWatch.Model.Dimension[] Dimension { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The number of periods over which data is compared to the specified threshold. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EvaluationPeriods")]
        public Int32 EvaluationPeriod { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The list of actions to execute when this alarm transitions into an <code>INSUFFICIENT_DATA</code>
        /// state from any other state. Each action is specified as an Amazon Resource Number
        /// (ARN). Currently the only action supported is publishing to an Amazon SNS topic or
        /// an Amazon Auto Scaling policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InsufficientDataActions")]
        public System.String[] InsufficientDataAction { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name for the alarm's associated metric. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String MetricName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The namespace for the alarm's associated metric. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String Namespace { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The list of actions to execute when this alarm transitions into an <code>OK</code>
        /// state from any other state. Each action is specified as an Amazon Resource Number
        /// (ARN). Currently the only action supported is publishing to an Amazon SNS topic or
        /// an Amazon Auto Scaling policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OKActions")]
        public System.String[] OKAction { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The period in seconds over which the specified statistic is applied. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Period { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The statistic to apply to the alarm's associated metric. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Statistic Statistic { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The value against which the specified statistic is compared. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Double Threshold { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The unit for the alarm's associated metric. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public StandardUnit Unit { get; set; }
        
        /// <summary>
        /// Returns the value passed to the AlarmName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
                context.AlarmActions = new List<String>(this.AlarmAction);
            }
            context.AlarmDescription = this.AlarmDescription;
            context.AlarmName = this.AlarmName;
            context.ComparisonOperator = this.ComparisonOperator;
            if (this.Dimension != null)
            {
                context.Dimensions = new List<Dimension>(this.Dimension);
            }
            if (ParameterWasBound("EvaluationPeriod"))
                context.EvaluationPeriods = this.EvaluationPeriod;
            if (this.InsufficientDataAction != null)
            {
                context.InsufficientDataActions = new List<String>(this.InsufficientDataAction);
            }
            context.MetricName = this.MetricName;
            context.Namespace = this.Namespace;
            if (this.OKAction != null)
            {
                context.OKActions = new List<String>(this.OKAction);
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
            var request = new PutMetricAlarmRequest();
            
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
            public Boolean? ActionsEnabled { get; set; }
            public List<String> AlarmActions { get; set; }
            public String AlarmDescription { get; set; }
            public String AlarmName { get; set; }
            public ComparisonOperator ComparisonOperator { get; set; }
            public List<Dimension> Dimensions { get; set; }
            public Int32? EvaluationPeriods { get; set; }
            public List<String> InsufficientDataActions { get; set; }
            public String MetricName { get; set; }
            public String Namespace { get; set; }
            public List<String> OKActions { get; set; }
            public Int32? Period { get; set; }
            public Statistic Statistic { get; set; }
            public Double? Threshold { get; set; }
            public StandardUnit Unit { get; set; }
        }
        
    }
}
