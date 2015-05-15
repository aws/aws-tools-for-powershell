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
    /// Creates an Auto Scaling group with the specified name and attributes.
    /// 
    ///  
    /// <para>
    /// If you exceed your maximum limit of Auto Scaling groups, which by default is 20 per
    /// region, the call fails. For information about viewing and updating these limits, see
    /// <a>DescribeAccountLimits</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ASAutoScalingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the CreateAutoScalingGroup operation against Auto Scaling.", Operation = new[] {"CreateAutoScalingGroup"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AutoScalingGroupName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type CreateAutoScalingGroupResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewASAutoScalingGroupCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of the group. This name must be unique within the scope of your AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String AutoScalingGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more Availability Zones for the group. This parameter is optional if you specify
        /// subnets using the <code>VPCZoneIdentifier</code> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, after a scaling activity completes before another
        /// scaling activity can start.</para><para>If <code>DefaultCooldown</code> is not specified, the default value is 300. For more
        /// information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/Cooldown.html">Understanding
        /// Auto Scaling Cooldowns</a> in the <i>Auto Scaling Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 DefaultCooldown { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of EC2 instances that should be running in the group. This value must be
        /// greater than or equal to the minimum size of the group and less than or equal to the
        /// maximum size of the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 DesiredCapacity { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, after an EC2 instance comes into service that Auto
        /// Scaling starts checking its health. During this time, any health check failures for
        /// the instance are ignored.</para><para>This parameter is required if you are adding an <code>ELB</code> health check. Frequently,
        /// new instances need to warm up, briefly, before they can pass a health check. To provide
        /// ample warm-up time, set the health check grace period of the group to match the expected
        /// startup period of your application.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/as-add-elb-healthcheck.html">Add
        /// an Elastic Load Balancing Health Check to Your Auto Scaling Group</a> in the <i>Auto
        /// Scaling Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 HealthCheckGracePeriod { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The service to use for the health checks. The valid values are <code>EC2</code> and
        /// <code>ELB</code>.</para><para>By default, health checks use Amazon EC2 instance status checks to determine the health
        /// of an instance. For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/healthcheck.html">Health
        /// Checks</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String HealthCheckType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the EC2 instance used to create a launch configuration for the group. Alternatively,
        /// use the <code>LaunchConfigurationName</code> parameter to specify a launch configuration
        /// instead of an EC2 instance.</para><para>When you specify an ID of an instance, Auto Scaling creates a new launch configuration
        /// and associates it with the group. This launch configuration derives its attributes
        /// from the specified instance, with the exception of the block device mapping.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/create-asg-from-instance.html">Create
        /// an Auto Scaling Group from an EC2 Instance</a> in the <i>Auto Scaling Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String InstanceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the launch configuration. Alternatively, use the <code>InstanceId</code>
        /// parameter to specify an EC2 instance instead of a launch configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String LaunchConfigurationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more load balancers.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/US_SetUpASLBApp.html">Load
        /// Balance Your Auto Scaling Group</a> in the <i>Auto Scaling Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LoadBalancerNames")]
        public System.String[] LoadBalancerName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum size of the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public Int32 MaxSize { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The minimum size of the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public Int32 MinSize { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the placement group into which you'll launch your instances, if any. For
        /// more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/placement-groups.html">Placement
        /// Groups</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String PlacementGroup { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The tag to be created or updated. Each tag should be defined by its resource type,
        /// resource ID, key, value, and a propagate flag. Valid values: key=<i>value</i>, value=<i>value</i>,
        /// propagate=<i>true</i> or <i>false</i>. Value and propagate are optional parameters.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/ASTagging.html">Tagging
        /// Auto Scaling Groups and Instances</a> in the <i>Auto Scaling Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.AutoScaling.Model.Tag[] Tag { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more termination policies used to select the instance to terminate. These policies
        /// are executed in the order that they are listed.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/us-termination-policy.html">Choosing
        /// a Termination Policy for Your Auto Scaling Group</a> in the <i>Auto Scaling Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TerminationPolicies")]
        public System.String[] TerminationPolicy { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A comma-separated list of subnet identifiers for your virtual private cloud (VPC).</para><para>If you specify subnets and Availability Zones with this call, ensure that the subnets'
        /// Availability Zones match the Availability Zones specified.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/autoscalingsubnets.html">Auto
        /// Scaling and Amazon Virtual Private Cloud</a> in the <i>Auto Scaling Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String VPCZoneIdentifier { get; set; }
        
        /// <summary>
        /// Returns the value passed to the AutoScalingGroupName parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AutoScalingGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASAutoScalingGroup (CreateAutoScalingGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZones = new List<String>(this.AvailabilityZone);
            }
            if (ParameterWasBound("DefaultCooldown"))
                context.DefaultCooldown = this.DefaultCooldown;
            if (ParameterWasBound("DesiredCapacity"))
                context.DesiredCapacity = this.DesiredCapacity;
            if (ParameterWasBound("HealthCheckGracePeriod"))
                context.HealthCheckGracePeriod = this.HealthCheckGracePeriod;
            context.HealthCheckType = this.HealthCheckType;
            context.InstanceId = this.InstanceId;
            context.LaunchConfigurationName = this.LaunchConfigurationName;
            if (this.LoadBalancerName != null)
            {
                context.LoadBalancerNames = new List<String>(this.LoadBalancerName);
            }
            if (ParameterWasBound("MaxSize"))
                context.MaxSize = this.MaxSize;
            if (ParameterWasBound("MinSize"))
                context.MinSize = this.MinSize;
            context.PlacementGroup = this.PlacementGroup;
            if (this.Tag != null)
            {
                context.Tags = new List<Tag>(this.Tag);
            }
            if (this.TerminationPolicy != null)
            {
                context.TerminationPolicies = new List<String>(this.TerminationPolicy);
            }
            context.VPCZoneIdentifier = this.VPCZoneIdentifier;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateAutoScalingGroupRequest();
            
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
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.LaunchConfigurationName != null)
            {
                request.LaunchConfigurationName = cmdletContext.LaunchConfigurationName;
            }
            if (cmdletContext.LoadBalancerNames != null)
            {
                request.LoadBalancerNames = cmdletContext.LoadBalancerNames;
            }
            if (cmdletContext.MaxSize != null)
            {
                request.MaxSize = cmdletContext.MaxSize.Value;
            }
            if (cmdletContext.MinSize != null)
            {
                request.MinSize = cmdletContext.MinSize.Value;
            }
            if (cmdletContext.PlacementGroup != null)
            {
                request.PlacementGroup = cmdletContext.PlacementGroup;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
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
                var response = client.CreateAutoScalingGroup(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String AutoScalingGroupName { get; set; }
            public List<String> AvailabilityZones { get; set; }
            public Int32? DefaultCooldown { get; set; }
            public Int32? DesiredCapacity { get; set; }
            public Int32? HealthCheckGracePeriod { get; set; }
            public String HealthCheckType { get; set; }
            public String InstanceId { get; set; }
            public String LaunchConfigurationName { get; set; }
            public List<String> LoadBalancerNames { get; set; }
            public Int32? MaxSize { get; set; }
            public Int32? MinSize { get; set; }
            public String PlacementGroup { get; set; }
            public List<Tag> Tags { get; set; }
            public List<String> TerminationPolicies { get; set; }
            public String VPCZoneIdentifier { get; set; }
        }
        
    }
}
