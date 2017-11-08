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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Updates the configuration for the specified Auto Scaling group.
    /// 
    ///  
    /// <para>
    /// The new settings take effect on any scaling activities after this call returns. Scaling
    /// activities that are currently in progress aren't affected.
    /// </para><para>
    /// To update an Auto Scaling group with a launch configuration with <code>InstanceMonitoring</code>
    /// set to <code>false</code>, you must first disable the collection of group metrics.
    /// Otherwise, you will get an error. If you have previously enabled the collection of
    /// group metrics, you can disable it using <a>DisableMetricsCollection</a>.
    /// </para><para>
    /// Note the following:
    /// </para><ul><li><para>
    /// If you specify a new value for <code>MinSize</code> without specifying a value for
    /// <code>DesiredCapacity</code>, and the new <code>MinSize</code> is larger than the
    /// current size of the group, we implicitly call <a>SetDesiredCapacity</a> to set the
    /// size of the group to the new value of <code>MinSize</code>.
    /// </para></li><li><para>
    /// If you specify a new value for <code>MaxSize</code> without specifying a value for
    /// <code>DesiredCapacity</code>, and the new <code>MaxSize</code> is smaller than the
    /// current size of the group, we implicitly call <a>SetDesiredCapacity</a> to set the
    /// size of the group to the new value of <code>MaxSize</code>.
    /// </para></li><li><para>
    /// All other optional parameters are left unchanged if not specified.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "ASAutoScalingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Auto Scaling UpdateAutoScalingGroup API operation.", Operation = new[] {"UpdateAutoScalingGroup"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AutoScalingGroupName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.AutoScaling.Model.UpdateAutoScalingGroupResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateASAutoScalingGroupCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>One or more Availability Zones for the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter DefaultCooldown
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, after a scaling activity completes before another
        /// scaling activity can start. The default is 300.</para><para>For more information, see <a href="http://docs.aws.amazon.com/autoscaling/latest/userguide/Cooldown.html">Auto
        /// Scaling Cooldowns</a> in the <i>Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DefaultCooldown { get; set; }
        #endregion
        
        #region Parameter DesiredCapacity
        /// <summary>
        /// <para>
        /// <para>The number of EC2 instances that should be running in the Auto Scaling group. This
        /// number must be greater than or equal to the minimum size of the group and less than
        /// or equal to the maximum size of the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        public System.Int32 DesiredCapacity { get; set; }
        #endregion
        
        #region Parameter HealthCheckGracePeriod
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that Auto Scaling waits before checking the health
        /// status of an EC2 instance that has come into service. The default is 0.</para><para>For more information, see <a href="http://docs.aws.amazon.com/autoscaling/latest/userguide/healthcheck.html">Health
        /// Checks</a> in the <i>Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthCheckGracePeriod { get; set; }
        #endregion
        
        #region Parameter HealthCheckType
        /// <summary>
        /// <para>
        /// <para>The service to use for the health checks. The valid values are <code>EC2</code> and
        /// <code>ELB</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheckType { get; set; }
        #endregion
        
        #region Parameter LaunchConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of the launch configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String LaunchConfigurationName { get; set; }
        #endregion
        
        #region Parameter MaxSize
        /// <summary>
        /// <para>
        /// <para>The maximum size of the Auto Scaling group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.Int32 MaxSize { get; set; }
        #endregion
        
        #region Parameter MinSize
        /// <summary>
        /// <para>
        /// <para>The minimum size of the Auto Scaling group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.Int32 MinSize { get; set; }
        #endregion
        
        #region Parameter NewInstancesProtectedFromScaleIn
        /// <summary>
        /// <para>
        /// <para>Indicates whether newly launched instances are protected from termination by Auto
        /// Scaling when scaling in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean NewInstancesProtectedFromScaleIn { get; set; }
        #endregion
        
        #region Parameter PlacementGroup
        /// <summary>
        /// <para>
        /// <para>The name of the placement group into which you'll launch your instances, if any. For
        /// more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/placement-groups.html">Placement
        /// Groups</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PlacementGroup { get; set; }
        #endregion
        
        #region Parameter TerminationPolicy
        /// <summary>
        /// <para>
        /// <para>A standalone termination policy or a list of termination policies used to select the
        /// instance to terminate. The policies are executed in the order that they are listed.</para><para>For more information, see <a href="http://docs.aws.amazon.com/autoscaling/latest/userguide/as-instance-termination.html">Controlling
        /// Which Instances Auto Scaling Terminates During Scale In</a> in the <i>Auto Scaling
        /// User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TerminationPolicies")]
        public System.String[] TerminationPolicy { get; set; }
        #endregion
        
        #region Parameter VPCZoneIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet, if you are launching into a VPC. You can specify several subnets
        /// in a comma-separated list.</para><para>When you specify <code>VPCZoneIdentifier</code> with <code>AvailabilityZones</code>,
        /// ensure that the subnets' Availability Zones match the values you specify for <code>AvailabilityZones</code>.</para><para>For more information, see <a href="http://docs.aws.amazon.com/autoscaling/latest/userguide/asg-in-vpc.html">Launching
        /// Auto Scaling Instances in a VPC</a> in the <i>Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VPCZoneIdentifier { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the AutoScalingGroupName parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AutoScalingGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ASAutoScalingGroup (UpdateAutoScalingGroup)"))
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
            
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZones = new List<System.String>(this.AvailabilityZone);
            }
            if (ParameterWasBound("DefaultCooldown"))
                context.DefaultCooldown = this.DefaultCooldown;
            if (ParameterWasBound("DesiredCapacity"))
                context.DesiredCapacity = this.DesiredCapacity;
            if (ParameterWasBound("HealthCheckGracePeriod"))
                context.HealthCheckGracePeriod = this.HealthCheckGracePeriod;
            context.HealthCheckType = this.HealthCheckType;
            context.LaunchConfigurationName = this.LaunchConfigurationName;
            if (ParameterWasBound("MaxSize"))
                context.MaxSize = this.MaxSize;
            if (ParameterWasBound("MinSize"))
                context.MinSize = this.MinSize;
            if (ParameterWasBound("NewInstancesProtectedFromScaleIn"))
                context.NewInstancesProtectedFromScaleIn = this.NewInstancesProtectedFromScaleIn;
            context.PlacementGroup = this.PlacementGroup;
            if (this.TerminationPolicy != null)
            {
                context.TerminationPolicies = new List<System.String>(this.TerminationPolicy);
            }
            context.VPCZoneIdentifier = this.VPCZoneIdentifier;
            
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
            var request = new Amazon.AutoScaling.Model.UpdateAutoScalingGroupRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.AvailabilityZones != null)
            {
                request.AvailabilityZones = cmdletContext.AvailabilityZones;
            }
            if (cmdletContext.DefaultCooldown != null)
            {
                request.DefaultCooldown = cmdletContext.DefaultCooldown.Value;
            }
            if (cmdletContext.DesiredCapacity != null)
            {
                request.DesiredCapacity = cmdletContext.DesiredCapacity.Value;
            }
            if (cmdletContext.HealthCheckGracePeriod != null)
            {
                request.HealthCheckGracePeriod = cmdletContext.HealthCheckGracePeriod.Value;
            }
            if (cmdletContext.HealthCheckType != null)
            {
                request.HealthCheckType = cmdletContext.HealthCheckType;
            }
            if (cmdletContext.LaunchConfigurationName != null)
            {
                request.LaunchConfigurationName = cmdletContext.LaunchConfigurationName;
            }
            if (cmdletContext.MaxSize != null)
            {
                request.MaxSize = cmdletContext.MaxSize.Value;
            }
            if (cmdletContext.MinSize != null)
            {
                request.MinSize = cmdletContext.MinSize.Value;
            }
            if (cmdletContext.NewInstancesProtectedFromScaleIn != null)
            {
                request.NewInstancesProtectedFromScaleIn = cmdletContext.NewInstancesProtectedFromScaleIn.Value;
            }
            if (cmdletContext.PlacementGroup != null)
            {
                request.PlacementGroup = cmdletContext.PlacementGroup;
            }
            if (cmdletContext.TerminationPolicies != null)
            {
                request.TerminationPolicies = cmdletContext.TerminationPolicies;
            }
            if (cmdletContext.VPCZoneIdentifier != null)
            {
                request.VPCZoneIdentifier = cmdletContext.VPCZoneIdentifier;
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
                    pipelineOutput = this.AutoScalingGroupName;
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
        
        private Amazon.AutoScaling.Model.UpdateAutoScalingGroupResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.UpdateAutoScalingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Auto Scaling", "UpdateAutoScalingGroup");
            try
            {
                #if DESKTOP
                return client.UpdateAutoScalingGroup(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateAutoScalingGroupAsync(request);
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
            public System.String AutoScalingGroupName { get; set; }
            public List<System.String> AvailabilityZones { get; set; }
            public System.Int32? DefaultCooldown { get; set; }
            public System.Int32? DesiredCapacity { get; set; }
            public System.Int32? HealthCheckGracePeriod { get; set; }
            public System.String HealthCheckType { get; set; }
            public System.String LaunchConfigurationName { get; set; }
            public System.Int32? MaxSize { get; set; }
            public System.Int32? MinSize { get; set; }
            public System.Boolean? NewInstancesProtectedFromScaleIn { get; set; }
            public System.String PlacementGroup { get; set; }
            public List<System.String> TerminationPolicies { get; set; }
            public System.String VPCZoneIdentifier { get; set; }
        }
        
    }
}
