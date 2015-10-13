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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Specify the load-based auto scaling configuration for a specified layer. For more
    /// information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-autoscaling.html">Managing
    /// Load with Time-based and Load-based Instances</a>.
    /// 
    ///  <note><para>
    /// To use load-based auto scaling, you must create a set of load-based auto scaling instances.
    /// Load-based auto scaling operates only on the instances from that set, so you must
    /// ensure that you have created enough instances to handle the maximum anticipated load.
    /// </para></note><para><b>Required Permissions</b>: To use this action, an IAM user must have a Manage permissions
    /// level for the stack, or an attached policy that explicitly grants permissions. For
    /// more information on user permissions, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "OPSLoadBasedAutoScaling", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the SetLoadBasedAutoScaling operation against AWS OpsWorks.", Operation = new[] {"SetLoadBasedAutoScaling"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the LayerId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.OpsWorks.Model.SetLoadBasedAutoScalingResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SetOPSLoadBasedAutoScalingCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Custom Cloudwatch auto scaling alarms, to be used as thresholds. This parameter takes
        /// a list of up to five alarm names, which are case sensitive and must be in the same
        /// region as the stack.</para><note>To use custom alarms, you must update your service role to allow <code>cloudwatch:DescribeAlarms</code>.
        /// You can either have AWS OpsWorks update the role for you when you first use this feature
        /// or you can edit the role manually. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-servicerole.html">Allowing
        /// AWS OpsWorks to Act on Your Behalf</a>.</note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DownScaling_Alarms")]
        public System.String[] DownScaling_Alarm { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Custom Cloudwatch auto scaling alarms, to be used as thresholds. This parameter takes
        /// a list of up to five alarm names, which are case sensitive and must be in the same
        /// region as the stack.</para><note>To use custom alarms, you must update your service role to allow <code>cloudwatch:DescribeAlarms</code>.
        /// You can either have AWS OpsWorks update the role for you when you first use this feature
        /// or you can edit the role manually. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-servicerole.html">Allowing
        /// AWS OpsWorks to Act on Your Behalf</a>.</note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UpScaling_Alarms")]
        public System.String[] UpScaling_Alarm { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The CPU utilization threshold, as a percent of the available CPU.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double DownScaling_CpuThreshold { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The CPU utilization threshold, as a percent of the available CPU.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double UpScaling_CpuThreshold { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Enables load-based auto scaling for the layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Boolean Enable { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The amount of time (in minutes) after a scaling event occurs that AWS OpsWorks should
        /// ignore metrics and suppress additional scaling events. For example, AWS OpsWorks adds
        /// new instances following an upscaling event but the instances won't start reducing
        /// the load until they have been booted and configured. There is no point in raising
        /// additional scaling events during that operation, which typically takes several minutes.
        /// <code>IgnoreMetricsTime</code> allows you to direct AWS OpsWorks to suppress scaling
        /// events long enough to get the new instances online.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DownScaling_IgnoreMetricsTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The amount of time (in minutes) after a scaling event occurs that AWS OpsWorks should
        /// ignore metrics and suppress additional scaling events. For example, AWS OpsWorks adds
        /// new instances following an upscaling event but the instances won't start reducing
        /// the load until they have been booted and configured. There is no point in raising
        /// additional scaling events during that operation, which typically takes several minutes.
        /// <code>IgnoreMetricsTime</code> allows you to direct AWS OpsWorks to suppress scaling
        /// events long enough to get the new instances online.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 UpScaling_IgnoreMetricsTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of instances to add or remove when the load exceeds a threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DownScaling_InstanceCount { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of instances to add or remove when the load exceeds a threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 UpScaling_InstanceCount { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The layer ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LayerId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The load threshold. For more information about how load is computed, see <a href="http://en.wikipedia.org/wiki/Load_%28computing%29">Load
        /// (computing)</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double DownScaling_LoadThreshold { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The load threshold. For more information about how load is computed, see <a href="http://en.wikipedia.org/wiki/Load_%28computing%29">Load
        /// (computing)</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double UpScaling_LoadThreshold { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The memory utilization threshold, as a percent of the available memory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double DownScaling_MemoryThreshold { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The memory utilization threshold, as a percent of the available memory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double UpScaling_MemoryThreshold { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The amount of time, in minutes, that the load must exceed a threshold before more
        /// instances are added or removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DownScaling_ThresholdsWaitTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The amount of time, in minutes, that the load must exceed a threshold before more
        /// instances are added or removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 UpScaling_ThresholdsWaitTime { get; set; }
        
        /// <summary>
        /// Returns the value passed to the LayerId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LayerId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-OPSLoadBasedAutoScaling (SetLoadBasedAutoScaling)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.DownScaling_Alarm != null)
            {
                context.DownScaling_Alarms = new List<System.String>(this.DownScaling_Alarm);
            }
            if (ParameterWasBound("DownScaling_CpuThreshold"))
                context.DownScaling_CpuThreshold = this.DownScaling_CpuThreshold;
            if (ParameterWasBound("DownScaling_IgnoreMetricsTime"))
                context.DownScaling_IgnoreMetricsTime = this.DownScaling_IgnoreMetricsTime;
            if (ParameterWasBound("DownScaling_InstanceCount"))
                context.DownScaling_InstanceCount = this.DownScaling_InstanceCount;
            if (ParameterWasBound("DownScaling_LoadThreshold"))
                context.DownScaling_LoadThreshold = this.DownScaling_LoadThreshold;
            if (ParameterWasBound("DownScaling_MemoryThreshold"))
                context.DownScaling_MemoryThreshold = this.DownScaling_MemoryThreshold;
            if (ParameterWasBound("DownScaling_ThresholdsWaitTime"))
                context.DownScaling_ThresholdsWaitTime = this.DownScaling_ThresholdsWaitTime;
            if (ParameterWasBound("Enable"))
                context.Enable = this.Enable;
            context.LayerId = this.LayerId;
            if (this.UpScaling_Alarm != null)
            {
                context.UpScaling_Alarms = new List<System.String>(this.UpScaling_Alarm);
            }
            if (ParameterWasBound("UpScaling_CpuThreshold"))
                context.UpScaling_CpuThreshold = this.UpScaling_CpuThreshold;
            if (ParameterWasBound("UpScaling_IgnoreMetricsTime"))
                context.UpScaling_IgnoreMetricsTime = this.UpScaling_IgnoreMetricsTime;
            if (ParameterWasBound("UpScaling_InstanceCount"))
                context.UpScaling_InstanceCount = this.UpScaling_InstanceCount;
            if (ParameterWasBound("UpScaling_LoadThreshold"))
                context.UpScaling_LoadThreshold = this.UpScaling_LoadThreshold;
            if (ParameterWasBound("UpScaling_MemoryThreshold"))
                context.UpScaling_MemoryThreshold = this.UpScaling_MemoryThreshold;
            if (ParameterWasBound("UpScaling_ThresholdsWaitTime"))
                context.UpScaling_ThresholdsWaitTime = this.UpScaling_ThresholdsWaitTime;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.OpsWorks.Model.SetLoadBasedAutoScalingRequest();
            
            
             // populate DownScaling
            bool requestDownScalingIsNull = true;
            request.DownScaling = new Amazon.OpsWorks.Model.AutoScalingThresholds();
            List<System.String> requestDownScaling_downScaling_Alarm = null;
            if (cmdletContext.DownScaling_Alarms != null)
            {
                requestDownScaling_downScaling_Alarm = cmdletContext.DownScaling_Alarms;
            }
            if (requestDownScaling_downScaling_Alarm != null)
            {
                request.DownScaling.Alarms = requestDownScaling_downScaling_Alarm;
                requestDownScalingIsNull = false;
            }
            System.Double? requestDownScaling_downScaling_CpuThreshold = null;
            if (cmdletContext.DownScaling_CpuThreshold != null)
            {
                requestDownScaling_downScaling_CpuThreshold = cmdletContext.DownScaling_CpuThreshold.Value;
            }
            if (requestDownScaling_downScaling_CpuThreshold != null)
            {
                request.DownScaling.CpuThreshold = requestDownScaling_downScaling_CpuThreshold.Value;
                requestDownScalingIsNull = false;
            }
            System.Int32? requestDownScaling_downScaling_IgnoreMetricsTime = null;
            if (cmdletContext.DownScaling_IgnoreMetricsTime != null)
            {
                requestDownScaling_downScaling_IgnoreMetricsTime = cmdletContext.DownScaling_IgnoreMetricsTime.Value;
            }
            if (requestDownScaling_downScaling_IgnoreMetricsTime != null)
            {
                request.DownScaling.IgnoreMetricsTime = requestDownScaling_downScaling_IgnoreMetricsTime.Value;
                requestDownScalingIsNull = false;
            }
            System.Int32? requestDownScaling_downScaling_InstanceCount = null;
            if (cmdletContext.DownScaling_InstanceCount != null)
            {
                requestDownScaling_downScaling_InstanceCount = cmdletContext.DownScaling_InstanceCount.Value;
            }
            if (requestDownScaling_downScaling_InstanceCount != null)
            {
                request.DownScaling.InstanceCount = requestDownScaling_downScaling_InstanceCount.Value;
                requestDownScalingIsNull = false;
            }
            System.Double? requestDownScaling_downScaling_LoadThreshold = null;
            if (cmdletContext.DownScaling_LoadThreshold != null)
            {
                requestDownScaling_downScaling_LoadThreshold = cmdletContext.DownScaling_LoadThreshold.Value;
            }
            if (requestDownScaling_downScaling_LoadThreshold != null)
            {
                request.DownScaling.LoadThreshold = requestDownScaling_downScaling_LoadThreshold.Value;
                requestDownScalingIsNull = false;
            }
            System.Double? requestDownScaling_downScaling_MemoryThreshold = null;
            if (cmdletContext.DownScaling_MemoryThreshold != null)
            {
                requestDownScaling_downScaling_MemoryThreshold = cmdletContext.DownScaling_MemoryThreshold.Value;
            }
            if (requestDownScaling_downScaling_MemoryThreshold != null)
            {
                request.DownScaling.MemoryThreshold = requestDownScaling_downScaling_MemoryThreshold.Value;
                requestDownScalingIsNull = false;
            }
            System.Int32? requestDownScaling_downScaling_ThresholdsWaitTime = null;
            if (cmdletContext.DownScaling_ThresholdsWaitTime != null)
            {
                requestDownScaling_downScaling_ThresholdsWaitTime = cmdletContext.DownScaling_ThresholdsWaitTime.Value;
            }
            if (requestDownScaling_downScaling_ThresholdsWaitTime != null)
            {
                request.DownScaling.ThresholdsWaitTime = requestDownScaling_downScaling_ThresholdsWaitTime.Value;
                requestDownScalingIsNull = false;
            }
             // determine if request.DownScaling should be set to null
            if (requestDownScalingIsNull)
            {
                request.DownScaling = null;
            }
            if (cmdletContext.Enable != null)
            {
                request.Enable = cmdletContext.Enable.Value;
            }
            if (cmdletContext.LayerId != null)
            {
                request.LayerId = cmdletContext.LayerId;
            }
            
             // populate UpScaling
            bool requestUpScalingIsNull = true;
            request.UpScaling = new Amazon.OpsWorks.Model.AutoScalingThresholds();
            List<System.String> requestUpScaling_upScaling_Alarm = null;
            if (cmdletContext.UpScaling_Alarms != null)
            {
                requestUpScaling_upScaling_Alarm = cmdletContext.UpScaling_Alarms;
            }
            if (requestUpScaling_upScaling_Alarm != null)
            {
                request.UpScaling.Alarms = requestUpScaling_upScaling_Alarm;
                requestUpScalingIsNull = false;
            }
            System.Double? requestUpScaling_upScaling_CpuThreshold = null;
            if (cmdletContext.UpScaling_CpuThreshold != null)
            {
                requestUpScaling_upScaling_CpuThreshold = cmdletContext.UpScaling_CpuThreshold.Value;
            }
            if (requestUpScaling_upScaling_CpuThreshold != null)
            {
                request.UpScaling.CpuThreshold = requestUpScaling_upScaling_CpuThreshold.Value;
                requestUpScalingIsNull = false;
            }
            System.Int32? requestUpScaling_upScaling_IgnoreMetricsTime = null;
            if (cmdletContext.UpScaling_IgnoreMetricsTime != null)
            {
                requestUpScaling_upScaling_IgnoreMetricsTime = cmdletContext.UpScaling_IgnoreMetricsTime.Value;
            }
            if (requestUpScaling_upScaling_IgnoreMetricsTime != null)
            {
                request.UpScaling.IgnoreMetricsTime = requestUpScaling_upScaling_IgnoreMetricsTime.Value;
                requestUpScalingIsNull = false;
            }
            System.Int32? requestUpScaling_upScaling_InstanceCount = null;
            if (cmdletContext.UpScaling_InstanceCount != null)
            {
                requestUpScaling_upScaling_InstanceCount = cmdletContext.UpScaling_InstanceCount.Value;
            }
            if (requestUpScaling_upScaling_InstanceCount != null)
            {
                request.UpScaling.InstanceCount = requestUpScaling_upScaling_InstanceCount.Value;
                requestUpScalingIsNull = false;
            }
            System.Double? requestUpScaling_upScaling_LoadThreshold = null;
            if (cmdletContext.UpScaling_LoadThreshold != null)
            {
                requestUpScaling_upScaling_LoadThreshold = cmdletContext.UpScaling_LoadThreshold.Value;
            }
            if (requestUpScaling_upScaling_LoadThreshold != null)
            {
                request.UpScaling.LoadThreshold = requestUpScaling_upScaling_LoadThreshold.Value;
                requestUpScalingIsNull = false;
            }
            System.Double? requestUpScaling_upScaling_MemoryThreshold = null;
            if (cmdletContext.UpScaling_MemoryThreshold != null)
            {
                requestUpScaling_upScaling_MemoryThreshold = cmdletContext.UpScaling_MemoryThreshold.Value;
            }
            if (requestUpScaling_upScaling_MemoryThreshold != null)
            {
                request.UpScaling.MemoryThreshold = requestUpScaling_upScaling_MemoryThreshold.Value;
                requestUpScalingIsNull = false;
            }
            System.Int32? requestUpScaling_upScaling_ThresholdsWaitTime = null;
            if (cmdletContext.UpScaling_ThresholdsWaitTime != null)
            {
                requestUpScaling_upScaling_ThresholdsWaitTime = cmdletContext.UpScaling_ThresholdsWaitTime.Value;
            }
            if (requestUpScaling_upScaling_ThresholdsWaitTime != null)
            {
                request.UpScaling.ThresholdsWaitTime = requestUpScaling_upScaling_ThresholdsWaitTime.Value;
                requestUpScalingIsNull = false;
            }
             // determine if request.UpScaling should be set to null
            if (requestUpScalingIsNull)
            {
                request.UpScaling = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.SetLoadBasedAutoScaling(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.LayerId;
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
            public List<System.String> DownScaling_Alarms { get; set; }
            public System.Double? DownScaling_CpuThreshold { get; set; }
            public System.Int32? DownScaling_IgnoreMetricsTime { get; set; }
            public System.Int32? DownScaling_InstanceCount { get; set; }
            public System.Double? DownScaling_LoadThreshold { get; set; }
            public System.Double? DownScaling_MemoryThreshold { get; set; }
            public System.Int32? DownScaling_ThresholdsWaitTime { get; set; }
            public System.Boolean? Enable { get; set; }
            public System.String LayerId { get; set; }
            public List<System.String> UpScaling_Alarms { get; set; }
            public System.Double? UpScaling_CpuThreshold { get; set; }
            public System.Int32? UpScaling_IgnoreMetricsTime { get; set; }
            public System.Int32? UpScaling_InstanceCount { get; set; }
            public System.Double? UpScaling_LoadThreshold { get; set; }
            public System.Double? UpScaling_MemoryThreshold { get; set; }
            public System.Int32? UpScaling_ThresholdsWaitTime { get; set; }
        }
        
    }
}
