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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Specify the load-based auto scaling configuration for a specified layer. For more
    /// information, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-autoscaling.html">Managing
    /// Load with Time-based and Load-based Instances</a>.
    /// 
    ///  <note><para>
    /// To use load-based auto scaling, you must create a set of load-based auto scaling instances.
    /// Load-based auto scaling operates only on the instances from that set, so you must
    /// ensure that you have created enough instances to handle the maximum anticipated load.
    /// </para></note><para><b>Required Permissions</b>: To use this action, an IAM user must have a Manage permissions
    /// level for the stack, or an attached policy that explicitly grants permissions. For
    /// more information on user permissions, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "OPSLoadBasedAutoScaling", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS OpsWorks SetLoadBasedAutoScaling API operation.", Operation = new[] {"SetLoadBasedAutoScaling"}, SelectReturnType = typeof(Amazon.OpsWorks.Model.SetLoadBasedAutoScalingResponse))]
    [AWSCmdletOutput("None or Amazon.OpsWorks.Model.SetLoadBasedAutoScalingResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.OpsWorks.Model.SetLoadBasedAutoScalingResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetOPSLoadBasedAutoScalingCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DownScaling_Alarm
        /// <summary>
        /// <para>
        /// <para>Custom CloudWatch auto scaling alarms, to be used as thresholds. This parameter takes
        /// a list of up to five alarm names, which are case sensitive and must be in the same
        /// region as the stack.</para><note><para>To use custom alarms, you must update your service role to allow <c>cloudwatch:DescribeAlarms</c>.
        /// You can either have OpsWorks Stacks update the role for you when you first use this
        /// feature or you can edit the role manually. For more information, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-servicerole.html">Allowing
        /// OpsWorks Stacks to Act on Your Behalf</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DownScaling_Alarms")]
        public System.String[] DownScaling_Alarm { get; set; }
        #endregion
        
        #region Parameter UpScaling_Alarm
        /// <summary>
        /// <para>
        /// <para>Custom CloudWatch auto scaling alarms, to be used as thresholds. This parameter takes
        /// a list of up to five alarm names, which are case sensitive and must be in the same
        /// region as the stack.</para><note><para>To use custom alarms, you must update your service role to allow <c>cloudwatch:DescribeAlarms</c>.
        /// You can either have OpsWorks Stacks update the role for you when you first use this
        /// feature or you can edit the role manually. For more information, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-servicerole.html">Allowing
        /// OpsWorks Stacks to Act on Your Behalf</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpScaling_Alarms")]
        public System.String[] UpScaling_Alarm { get; set; }
        #endregion
        
        #region Parameter DownScaling_CpuThreshold
        /// <summary>
        /// <para>
        /// <para>The CPU utilization threshold, as a percent of the available CPU. A value of -1 disables
        /// the threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? DownScaling_CpuThreshold { get; set; }
        #endregion
        
        #region Parameter UpScaling_CpuThreshold
        /// <summary>
        /// <para>
        /// <para>The CPU utilization threshold, as a percent of the available CPU. A value of -1 disables
        /// the threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? UpScaling_CpuThreshold { get; set; }
        #endregion
        
        #region Parameter Enable
        /// <summary>
        /// <para>
        /// <para>Enables load-based auto scaling for the layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enable { get; set; }
        #endregion
        
        #region Parameter DownScaling_IgnoreMetricsTime
        /// <summary>
        /// <para>
        /// <para>The amount of time (in minutes) after a scaling event occurs that OpsWorks Stacks
        /// should ignore metrics and suppress additional scaling events. For example, OpsWorks
        /// Stacks adds new instances following an upscaling event but the instances won't start
        /// reducing the load until they have been booted and configured. There is no point in
        /// raising additional scaling events during that operation, which typically takes several
        /// minutes. <c>IgnoreMetricsTime</c> allows you to direct OpsWorks Stacks to suppress
        /// scaling events long enough to get the new instances online.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DownScaling_IgnoreMetricsTime { get; set; }
        #endregion
        
        #region Parameter UpScaling_IgnoreMetricsTime
        /// <summary>
        /// <para>
        /// <para>The amount of time (in minutes) after a scaling event occurs that OpsWorks Stacks
        /// should ignore metrics and suppress additional scaling events. For example, OpsWorks
        /// Stacks adds new instances following an upscaling event but the instances won't start
        /// reducing the load until they have been booted and configured. There is no point in
        /// raising additional scaling events during that operation, which typically takes several
        /// minutes. <c>IgnoreMetricsTime</c> allows you to direct OpsWorks Stacks to suppress
        /// scaling events long enough to get the new instances online.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UpScaling_IgnoreMetricsTime { get; set; }
        #endregion
        
        #region Parameter DownScaling_InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of instances to add or remove when the load exceeds a threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DownScaling_InstanceCount { get; set; }
        #endregion
        
        #region Parameter UpScaling_InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of instances to add or remove when the load exceeds a threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UpScaling_InstanceCount { get; set; }
        #endregion
        
        #region Parameter LayerId
        /// <summary>
        /// <para>
        /// <para>The layer ID.</para>
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
        public System.String LayerId { get; set; }
        #endregion
        
        #region Parameter DownScaling_LoadThreshold
        /// <summary>
        /// <para>
        /// <para>The load threshold. A value of -1 disables the threshold. For more information about
        /// how load is computed, see <a href="http://en.wikipedia.org/wiki/Load_%28computing%29">Load
        /// (computing)</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? DownScaling_LoadThreshold { get; set; }
        #endregion
        
        #region Parameter UpScaling_LoadThreshold
        /// <summary>
        /// <para>
        /// <para>The load threshold. A value of -1 disables the threshold. For more information about
        /// how load is computed, see <a href="http://en.wikipedia.org/wiki/Load_%28computing%29">Load
        /// (computing)</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? UpScaling_LoadThreshold { get; set; }
        #endregion
        
        #region Parameter DownScaling_MemoryThreshold
        /// <summary>
        /// <para>
        /// <para>The memory utilization threshold, as a percent of the available memory. A value of
        /// -1 disables the threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? DownScaling_MemoryThreshold { get; set; }
        #endregion
        
        #region Parameter UpScaling_MemoryThreshold
        /// <summary>
        /// <para>
        /// <para>The memory utilization threshold, as a percent of the available memory. A value of
        /// -1 disables the threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? UpScaling_MemoryThreshold { get; set; }
        #endregion
        
        #region Parameter DownScaling_ThresholdsWaitTime
        /// <summary>
        /// <para>
        /// <para>The amount of time, in minutes, that the load must exceed a threshold before more
        /// instances are added or removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DownScaling_ThresholdsWaitTime { get; set; }
        #endregion
        
        #region Parameter UpScaling_ThresholdsWaitTime
        /// <summary>
        /// <para>
        /// <para>The amount of time, in minutes, that the load must exceed a threshold before more
        /// instances are added or removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UpScaling_ThresholdsWaitTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorks.Model.SetLoadBasedAutoScalingResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LayerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-OPSLoadBasedAutoScaling (SetLoadBasedAutoScaling)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorks.Model.SetLoadBasedAutoScalingResponse, SetOPSLoadBasedAutoScalingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DownScaling_Alarm != null)
            {
                context.DownScaling_Alarm = new List<System.String>(this.DownScaling_Alarm);
            }
            context.DownScaling_CpuThreshold = this.DownScaling_CpuThreshold;
            context.DownScaling_IgnoreMetricsTime = this.DownScaling_IgnoreMetricsTime;
            context.DownScaling_InstanceCount = this.DownScaling_InstanceCount;
            context.DownScaling_LoadThreshold = this.DownScaling_LoadThreshold;
            context.DownScaling_MemoryThreshold = this.DownScaling_MemoryThreshold;
            context.DownScaling_ThresholdsWaitTime = this.DownScaling_ThresholdsWaitTime;
            context.Enable = this.Enable;
            context.LayerId = this.LayerId;
            #if MODULAR
            if (this.LayerId == null && ParameterWasBound(nameof(this.LayerId)))
            {
                WriteWarning("You are passing $null as a value for parameter LayerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UpScaling_Alarm != null)
            {
                context.UpScaling_Alarm = new List<System.String>(this.UpScaling_Alarm);
            }
            context.UpScaling_CpuThreshold = this.UpScaling_CpuThreshold;
            context.UpScaling_IgnoreMetricsTime = this.UpScaling_IgnoreMetricsTime;
            context.UpScaling_InstanceCount = this.UpScaling_InstanceCount;
            context.UpScaling_LoadThreshold = this.UpScaling_LoadThreshold;
            context.UpScaling_MemoryThreshold = this.UpScaling_MemoryThreshold;
            context.UpScaling_ThresholdsWaitTime = this.UpScaling_ThresholdsWaitTime;
            
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
            var request = new Amazon.OpsWorks.Model.SetLoadBasedAutoScalingRequest();
            
            
             // populate DownScaling
            var requestDownScalingIsNull = true;
            request.DownScaling = new Amazon.OpsWorks.Model.AutoScalingThresholds();
            List<System.String> requestDownScaling_downScaling_Alarm = null;
            if (cmdletContext.DownScaling_Alarm != null)
            {
                requestDownScaling_downScaling_Alarm = cmdletContext.DownScaling_Alarm;
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
            var requestUpScalingIsNull = true;
            request.UpScaling = new Amazon.OpsWorks.Model.AutoScalingThresholds();
            List<System.String> requestUpScaling_upScaling_Alarm = null;
            if (cmdletContext.UpScaling_Alarm != null)
            {
                requestUpScaling_upScaling_Alarm = cmdletContext.UpScaling_Alarm;
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
        
        private Amazon.OpsWorks.Model.SetLoadBasedAutoScalingResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.SetLoadBasedAutoScalingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "SetLoadBasedAutoScaling");
            try
            {
                #if DESKTOP
                return client.SetLoadBasedAutoScaling(request);
                #elif CORECLR
                return client.SetLoadBasedAutoScalingAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> DownScaling_Alarm { get; set; }
            public System.Double? DownScaling_CpuThreshold { get; set; }
            public System.Int32? DownScaling_IgnoreMetricsTime { get; set; }
            public System.Int32? DownScaling_InstanceCount { get; set; }
            public System.Double? DownScaling_LoadThreshold { get; set; }
            public System.Double? DownScaling_MemoryThreshold { get; set; }
            public System.Int32? DownScaling_ThresholdsWaitTime { get; set; }
            public System.Boolean? Enable { get; set; }
            public System.String LayerId { get; set; }
            public List<System.String> UpScaling_Alarm { get; set; }
            public System.Double? UpScaling_CpuThreshold { get; set; }
            public System.Int32? UpScaling_IgnoreMetricsTime { get; set; }
            public System.Int32? UpScaling_InstanceCount { get; set; }
            public System.Double? UpScaling_LoadThreshold { get; set; }
            public System.Double? UpScaling_MemoryThreshold { get; set; }
            public System.Int32? UpScaling_ThresholdsWaitTime { get; set; }
            public System.Func<Amazon.OpsWorks.Model.SetLoadBasedAutoScalingResponse, SetOPSLoadBasedAutoScalingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
