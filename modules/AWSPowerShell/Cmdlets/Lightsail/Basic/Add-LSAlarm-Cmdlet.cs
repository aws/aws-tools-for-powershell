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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Creates or updates an alarm, and associates it with the specified metric.
    /// 
    ///  
    /// <para>
    /// An alarm is used to monitor a single metric for one of your resources. When a metric
    /// condition is met, the alarm can notify you by email, SMS text message, and a banner
    /// displayed on the Amazon Lightsail console. For more information, see <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-alarms">Alarms
    /// in Amazon Lightsail</a>.
    /// </para><para>
    /// When this action creates an alarm, the alarm state is immediately set to <code>INSUFFICIENT_DATA</code>.
    /// The alarm is then evaluated and its state is set appropriately. Any actions associated
    /// with the new state are then executed.
    /// </para><para>
    /// When you update an existing alarm, its state is left unchanged, but the update completely
    /// overwrites the previous configuration of the alarm. The alarm is then evaluated with
    /// the updated configuration.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "LSAlarm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail PutAlarm API operation.", Operation = new[] {"PutAlarm"}, SelectReturnType = typeof(Amazon.Lightsail.Model.PutAlarmResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.PutAlarmResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.PutAlarmResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddLSAlarmCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter AlarmName
        /// <summary>
        /// <para>
        /// <para>The name for the alarm. Specify the name of an existing alarm to update, and overwrite
        /// the previous configuration of the alarm.</para>
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
        /// <para>The arithmetic operation to use when comparing the specified statistic to the threshold.
        /// The specified statistic value is used as the first operand.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Lightsail.ComparisonOperator")]
        public Amazon.Lightsail.ComparisonOperator ComparisonOperator { get; set; }
        #endregion
        
        #region Parameter ContactProtocol
        /// <summary>
        /// <para>
        /// <para>The contact protocols to use for the alarm, such as <code>Email</code>, <code>SMS</code>
        /// (text messaging), or both.</para><para>A notification is sent via the specified contact protocol if notifications are enabled
        /// for the alarm, and when the alarm is triggered.</para><para>A notification is not sent if a contact protocol is not specified, if the specified
        /// contact protocol is not configured in the AWS Region, or if notifications are not
        /// enabled for the alarm using the <code>notificationEnabled</code> paramater.</para><para>Use the <code>CreateContactMethod</code> action to configure a contact protocol in
        /// an AWS Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContactProtocols")]
        public System.String[] ContactProtocol { get; set; }
        #endregion
        
        #region Parameter DatapointsToAlarm
        /// <summary>
        /// <para>
        /// <para>The number of data points that must be not within the specified threshold to trigger
        /// the alarm. If you are setting an "M out of N" alarm, this value (<code>datapointsToAlarm</code>)
        /// is the M.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DatapointsToAlarm { get; set; }
        #endregion
        
        #region Parameter EvaluationPeriod
        /// <summary>
        /// <para>
        /// <para>The number of most recent periods over which data is compared to the specified threshold.
        /// If you are setting an "M out of N" alarm, this value (<code>evaluationPeriods</code>)
        /// is the N.</para><para>If you are setting an alarm that requires that a number of consecutive data points
        /// be breaching to trigger the alarm, this value specifies the rolling period of time
        /// in which data points are evaluated.</para><para>Each evaluation period is five minutes long. For example, specify an evaluation period
        /// of 24 to evaluate a metric over a rolling period of two hours.</para><para>You can specify a minimum valuation period of 1 (5 minutes), and a maximum evaluation
        /// period of 288 (24 hours).</para>
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
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the metric to associate with the alarm.</para><para>You can configure up to two alarms per metric.</para><para>The following metrics are available for each resource type:</para><ul><li><para><b>Instances</b>: <code>BurstCapacityPercentage</code>, <code>BurstCapacityTime</code>,
        /// <code>CPUUtilization</code>, <code>NetworkIn</code>, <code>NetworkOut</code>, <code>StatusCheckFailed</code>,
        /// <code>StatusCheckFailed_Instance</code>, and <code>StatusCheckFailed_System</code>.</para></li><li><para><b>Load balancers</b>: <code>ClientTLSNegotiationErrorCount</code>, <code>HealthyHostCount</code>,
        /// <code>UnhealthyHostCount</code>, <code>HTTPCode_LB_4XX_Count</code>, <code>HTTPCode_LB_5XX_Count</code>,
        /// <code>HTTPCode_Instance_2XX_Count</code>, <code>HTTPCode_Instance_3XX_Count</code>,
        /// <code>HTTPCode_Instance_4XX_Count</code>, <code>HTTPCode_Instance_5XX_Count</code>,
        /// <code>InstanceResponseTime</code>, <code>RejectedConnectionCount</code>, and <code>RequestCount</code>.</para></li><li><para><b>Relational databases</b>: <code>CPUUtilization</code>, <code>DatabaseConnections</code>,
        /// <code>DiskQueueDepth</code>, <code>FreeStorageSpace</code>, <code>NetworkReceiveThroughput</code>,
        /// and <code>NetworkTransmitThroughput</code>.</para></li></ul><para>For more information about these metrics, see <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-resource-health-metrics#available-metrics">Metrics
        /// available in Lightsail</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Lightsail.MetricName")]
        public Amazon.Lightsail.MetricName MetricName { get; set; }
        #endregion
        
        #region Parameter MonitoredResourceName
        /// <summary>
        /// <para>
        /// <para>The name of the Lightsail resource that will be monitored.</para><para>Instances, load balancers, and relational databases are the only Lightsail resources
        /// that can currently be monitored by alarms.</para>
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
        public System.String MonitoredResourceName { get; set; }
        #endregion
        
        #region Parameter NotificationEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether the alarm is enabled.</para><para>Notifications are enabled by default if you don't specify this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NotificationEnabled { get; set; }
        #endregion
        
        #region Parameter NotificationTrigger
        /// <summary>
        /// <para>
        /// <para>The alarm states that trigger a notification.</para><para>An alarm has the following possible states:</para><ul><li><para><code>ALARM</code> - The metric is outside of the defined threshold.</para></li><li><para><code>INSUFFICIENT_DATA</code> - The alarm has just started, the metric is not available,
        /// or not enough data is available for the metric to determine the alarm state.</para></li><li><para><code>OK</code> - The metric is within the defined threshold.</para></li></ul><para>When you specify a notification trigger, the <code>ALARM</code> state must be specified.
        /// The <code>INSUFFICIENT_DATA</code> and <code>OK</code> states can be specified in
        /// addition to the <code>ALARM</code> state.</para><ul><li><para>If you specify <code>OK</code> as an alarm trigger, a notification is sent when the
        /// alarm switches from an <code>ALARM</code> or <code>INSUFFICIENT_DATA</code> alarm
        /// state to an <code>OK</code> state. This can be thought of as an <i>all clear</i> alarm
        /// notification.</para></li><li><para>If you specify <code>INSUFFICIENT_DATA</code> as the alarm trigger, a notification
        /// is sent when the alarm switches from an <code>OK</code> or <code>ALARM</code> alarm
        /// state to an <code>INSUFFICIENT_DATA</code> state.</para></li></ul><para>The notification trigger defaults to <code>ALARM</code> if you don't specify this
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotificationTriggers")]
        public System.String[] NotificationTrigger { get; set; }
        #endregion
        
        #region Parameter Threshold
        /// <summary>
        /// <para>
        /// <para>The value against which the specified statistic is compared.</para>
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
        /// <para>Sets how this alarm will handle missing data points.</para><para>An alarm can treat missing data in the following ways:</para><ul><li><para><code>breaching</code> - Assume the missing data is not within the threshold. Missing
        /// data counts towards the number of times the metric is not within the threshold.</para></li><li><para><code>notBreaching</code> - Assume the missing data is within the threshold. Missing
        /// data does not count towards the number of times the metric is not within the threshold.</para></li><li><para><code>ignore</code> - Ignore the missing data. Maintains the current alarm state.</para></li><li><para><code>missing</code> - Missing data is treated as missing.</para></li></ul><para>If <code>treatMissingData</code> is not specified, the default behavior of <code>missing</code>
        /// is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lightsail.TreatMissingData")]
        public Amazon.Lightsail.TreatMissingData TreatMissingData { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.PutAlarmResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.PutAlarmResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operations";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-LSAlarm (PutAlarm)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.PutAlarmResponse, AddLSAlarmCmdlet>(Select) ??
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
            if (this.ContactProtocol != null)
            {
                context.ContactProtocol = new List<System.String>(this.ContactProtocol);
            }
            context.DatapointsToAlarm = this.DatapointsToAlarm;
            context.EvaluationPeriod = this.EvaluationPeriod;
            #if MODULAR
            if (this.EvaluationPeriod == null && ParameterWasBound(nameof(this.EvaluationPeriod)))
            {
                WriteWarning("You are passing $null as a value for parameter EvaluationPeriod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetricName = this.MetricName;
            #if MODULAR
            if (this.MetricName == null && ParameterWasBound(nameof(this.MetricName)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MonitoredResourceName = this.MonitoredResourceName;
            #if MODULAR
            if (this.MonitoredResourceName == null && ParameterWasBound(nameof(this.MonitoredResourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter MonitoredResourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NotificationEnabled = this.NotificationEnabled;
            if (this.NotificationTrigger != null)
            {
                context.NotificationTrigger = new List<System.String>(this.NotificationTrigger);
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
            var request = new Amazon.Lightsail.Model.PutAlarmRequest();
            
            if (cmdletContext.AlarmName != null)
            {
                request.AlarmName = cmdletContext.AlarmName;
            }
            if (cmdletContext.ComparisonOperator != null)
            {
                request.ComparisonOperator = cmdletContext.ComparisonOperator;
            }
            if (cmdletContext.ContactProtocol != null)
            {
                request.ContactProtocols = cmdletContext.ContactProtocol;
            }
            if (cmdletContext.DatapointsToAlarm != null)
            {
                request.DatapointsToAlarm = cmdletContext.DatapointsToAlarm.Value;
            }
            if (cmdletContext.EvaluationPeriod != null)
            {
                request.EvaluationPeriods = cmdletContext.EvaluationPeriod.Value;
            }
            if (cmdletContext.MetricName != null)
            {
                request.MetricName = cmdletContext.MetricName;
            }
            if (cmdletContext.MonitoredResourceName != null)
            {
                request.MonitoredResourceName = cmdletContext.MonitoredResourceName;
            }
            if (cmdletContext.NotificationEnabled != null)
            {
                request.NotificationEnabled = cmdletContext.NotificationEnabled.Value;
            }
            if (cmdletContext.NotificationTrigger != null)
            {
                request.NotificationTriggers = cmdletContext.NotificationTrigger;
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
        
        private Amazon.Lightsail.Model.PutAlarmResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.PutAlarmRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "PutAlarm");
            try
            {
                #if DESKTOP
                return client.PutAlarm(request);
                #elif CORECLR
                return client.PutAlarmAsync(request).GetAwaiter().GetResult();
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
            public System.String AlarmName { get; set; }
            public Amazon.Lightsail.ComparisonOperator ComparisonOperator { get; set; }
            public List<System.String> ContactProtocol { get; set; }
            public System.Int32? DatapointsToAlarm { get; set; }
            public System.Int32? EvaluationPeriod { get; set; }
            public Amazon.Lightsail.MetricName MetricName { get; set; }
            public System.String MonitoredResourceName { get; set; }
            public System.Boolean? NotificationEnabled { get; set; }
            public List<System.String> NotificationTrigger { get; set; }
            public System.Double? Threshold { get; set; }
            public Amazon.Lightsail.TreatMissingData TreatMissingData { get; set; }
            public System.Func<Amazon.Lightsail.Model.PutAlarmResponse, AddLSAlarmCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operations;
        }
        
    }
}
