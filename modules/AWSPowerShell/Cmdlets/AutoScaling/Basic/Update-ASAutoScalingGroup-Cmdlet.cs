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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// <b>We strongly recommend that all Auto Scaling groups use launch templates to ensure
    /// full functionality for Amazon EC2 Auto Scaling and Amazon EC2.</b><para>
    /// Updates the configuration for the specified Auto Scaling group.
    /// </para><para>
    /// To update an Auto Scaling group, specify the name of the group and the property that
    /// you want to change. Any properties that you don't specify are not changed by this
    /// update request. The new settings take effect on any scaling activities after this
    /// call returns. 
    /// </para><para>
    /// If you associate a new launch configuration or template with an Auto Scaling group,
    /// all new instances will get the updated configuration. Existing instances continue
    /// to run with the configuration that they were originally launched with. When you update
    /// a group to specify a mixed instances policy instead of a launch configuration or template,
    /// existing instances may be replaced to match the new purchasing options that you specified
    /// in the policy. For example, if the group currently has 100% On-Demand capacity and
    /// the policy specifies 50% Spot capacity, this means that half of your instances will
    /// be gradually terminated and relaunched as Spot Instances. When replacing instances,
    /// Amazon EC2 Auto Scaling launches new instances before terminating the old ones, so
    /// that updating your group does not compromise the performance or availability of your
    /// application.
    /// </para><para>
    /// Note the following about changing <code>DesiredCapacity</code>, <code>MaxSize</code>,
    /// or <code>MinSize</code>:
    /// </para><ul><li><para>
    /// If a scale-in activity occurs as a result of a new <code>DesiredCapacity</code> value
    /// that is lower than the current size of the group, the Auto Scaling group uses its
    /// termination policy to determine which instances to terminate.
    /// </para></li><li><para>
    /// If you specify a new value for <code>MinSize</code> without specifying a value for
    /// <code>DesiredCapacity</code>, and the new <code>MinSize</code> is larger than the
    /// current size of the group, this sets the group's <code>DesiredCapacity</code> to the
    /// new <code>MinSize</code> value.
    /// </para></li><li><para>
    /// If you specify a new value for <code>MaxSize</code> without specifying a value for
    /// <code>DesiredCapacity</code>, and the new <code>MaxSize</code> is smaller than the
    /// current size of the group, this sets the group's <code>DesiredCapacity</code> to the
    /// new <code>MaxSize</code> value.
    /// </para></li></ul><para>
    /// To see which properties have been set, call the <a>DescribeAutoScalingGroups</a> API.
    /// To view the scaling policies for an Auto Scaling group, call the <a>DescribePolicies</a>
    /// API. If the group has scaling policies, you can update them by calling the <a>PutScalingPolicy</a>
    /// API.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "ASAutoScalingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Auto Scaling UpdateAutoScalingGroup API operation.", Operation = new[] {"UpdateAutoScalingGroup"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.UpdateAutoScalingGroupResponse))]
    [AWSCmdletOutput("None or Amazon.AutoScaling.Model.UpdateAutoScalingGroupResponse",
        "This cmdlet does not generate any output." +
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
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>One or more Availability Zones for the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter CapacityRebalance
        /// <summary>
        /// <para>
        /// <para>Enables or disables Capacity Rebalancing. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-capacity-rebalancing.html">Use
        /// Capacity Rebalancing to handle Amazon EC2 Spot Interruptions</a> in the <i>Amazon
        /// EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CapacityRebalance { get; set; }
        #endregion
        
        #region Parameter Context
        /// <summary>
        /// <para>
        /// <para>Reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context { get; set; }
        #endregion
        
        #region Parameter DefaultCooldown
        /// <summary>
        /// <para>
        /// <para><i>Only needed if you use simple scaling policies.</i></para><para>The amount of time, in seconds, between one scaling activity ending and another one
        /// starting due to simple scaling policies. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/Cooldown.html">Scaling
        /// cooldowns for Amazon EC2 Auto Scaling</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DefaultCooldown { get; set; }
        #endregion
        
        #region Parameter DefaultInstanceWarmup
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, until a newly launched instance can contribute to
        /// the Amazon CloudWatch metrics. This delay lets an instance finish initializing before
        /// Amazon EC2 Auto Scaling aggregates instance metrics, resulting in more reliable usage
        /// data. Set this value equal to the amount of time that it takes for resource consumption
        /// to become stable after an instance reaches the <code>InService</code> state. For more
        /// information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-default-instance-warmup.html">Set
        /// the default instance warmup for an Auto Scaling group</a> in the <i>Amazon EC2 Auto
        /// Scaling User Guide</i>.</para><important><para>To manage your warm-up settings at the group level, we recommend that you set the
        /// default instance warmup, <i>even if its value is set to 0 seconds</i>. This also optimizes
        /// the performance of scaling policies that scale continuously, such as target tracking
        /// and step scaling policies. </para><para>If you need to remove a value that you previously set, include the property but specify
        /// <code>-1</code> for the value. However, we strongly recommend keeping the default
        /// instance warmup enabled by specifying a minimum value of <code>0</code>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DefaultInstanceWarmup { get; set; }
        #endregion
        
        #region Parameter DesiredCapacity
        /// <summary>
        /// <para>
        /// <para>The desired capacity is the initial capacity of the Auto Scaling group after this
        /// operation completes and the capacity it attempts to maintain. This number must be
        /// greater than or equal to the minimum size of the group and less than or equal to the
        /// maximum size of the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        public System.Int32? DesiredCapacity { get; set; }
        #endregion
        
        #region Parameter DesiredCapacityType
        /// <summary>
        /// <para>
        /// <para>The unit of measurement for the value specified for desired capacity. Amazon EC2 Auto
        /// Scaling supports <code>DesiredCapacityType</code> for attribute-based instance type
        /// selection only. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/create-asg-instance-type-requirements.html">Creating
        /// an Auto Scaling group using attribute-based instance type selection</a> in the <i>Amazon
        /// EC2 Auto Scaling User Guide</i>.</para><para>By default, Amazon EC2 Auto Scaling specifies <code>units</code>, which translates
        /// into number of instances.</para><para>Valid values: <code>units</code> | <code>vcpu</code> | <code>memory-mib</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DesiredCapacityType { get; set; }
        #endregion
        
        #region Parameter HealthCheckGracePeriod
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that Amazon EC2 Auto Scaling waits before checking
        /// the health status of an EC2 instance that has come into service and marking it unhealthy
        /// due to a failed health check. This is useful if your instances do not immediately
        /// pass their health checks after they enter the <code>InService</code> state. For more
        /// information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/health-check-grace-period.html">Set
        /// the health check grace period for an Auto Scaling group</a> in the <i>Amazon EC2 Auto
        /// Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthCheckGracePeriod { get; set; }
        #endregion
        
        #region Parameter HealthCheckType
        /// <summary>
        /// <para>
        /// <para>Determines whether any additional health checks are performed on the instances in
        /// this group. Amazon EC2 health checks are always on.</para><para>The valid values are <code>EC2</code> (default), <code>ELB</code>, and <code>VPC_LATTICE</code>.
        /// The <code>VPC_LATTICE</code> health check type is reserved for use with VPC Lattice,
        /// which is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HealthCheckType { get; set; }
        #endregion
        
        #region Parameter LaunchConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of the launch configuration. If you specify <code>LaunchConfigurationName</code>
        /// in your update request, you can't specify <code>LaunchTemplate</code> or <code>MixedInstancesPolicy</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String LaunchConfigurationName { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateId
        /// <summary>
        /// <para>
        /// <para>The ID of the launch template. To get the template ID, use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeLaunchTemplates.html">DescribeLaunchTemplates</a>
        /// API operation. New launch templates can be created using the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateLaunchTemplate.html">CreateLaunchTemplate</a>
        /// API. </para><para>Conditional: You must specify either a <code>LaunchTemplateId</code> or a <code>LaunchTemplateName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_LaunchTemplateId { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the launch template. To get the template name, use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeLaunchTemplates.html">DescribeLaunchTemplates</a>
        /// API operation. New launch templates can be created using the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateLaunchTemplate.html">CreateLaunchTemplate</a>
        /// API. </para><para>Conditional: You must specify either a <code>LaunchTemplateId</code> or a <code>LaunchTemplateName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_LaunchTemplateName { get; set; }
        #endregion
        
        #region Parameter MaxInstanceLifetime
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time, in seconds, that an instance can be in service. The default
        /// is null. If specified, the value must be either 0 or a number equal to or greater
        /// than 86,400 seconds (1 day). To clear a previously set value, specify a new value
        /// of 0. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-max-instance-lifetime.html">Replacing
        /// Auto Scaling instances based on maximum instance lifetime</a> in the <i>Amazon EC2
        /// Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxInstanceLifetime { get; set; }
        #endregion
        
        #region Parameter MaxSize
        /// <summary>
        /// <para>
        /// <para>The maximum size of the Auto Scaling group.</para><note><para>With a mixed instances policy that uses instance weighting, Amazon EC2 Auto Scaling
        /// may need to go above <code>MaxSize</code> to meet your capacity requirements. In this
        /// event, Amazon EC2 Auto Scaling will never go above <code>MaxSize</code> by more than
        /// your largest instance weight (weights that define how many units each instance contributes
        /// to the desired capacity of the group).</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxSize { get; set; }
        #endregion
        
        #region Parameter MinSize
        /// <summary>
        /// <para>
        /// <para>The minimum size of the Auto Scaling group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinSize { get; set; }
        #endregion
        
        #region Parameter MixedInstancesPolicy
        /// <summary>
        /// <para>
        /// <para>The mixed instances policy. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-mixed-instances-groups.html">Auto
        /// Scaling groups with multiple instance types and purchase options</a> in the <i>Amazon
        /// EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AutoScaling.Model.MixedInstancesPolicy MixedInstancesPolicy { get; set; }
        #endregion
        
        #region Parameter NewInstancesProtectedFromScaleIn
        /// <summary>
        /// <para>
        /// <para>Indicates whether newly launched instances are protected from termination by Amazon
        /// EC2 Auto Scaling when scaling in. For more information about preventing instances
        /// from terminating on scale in, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-instance-protection.html">Using
        /// instance scale-in protection</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NewInstancesProtectedFromScaleIn { get; set; }
        #endregion
        
        #region Parameter PlacementGroup
        /// <summary>
        /// <para>
        /// <para>The name of an existing placement group into which to launch your instances. For more
        /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/placement-groups.html">Placement
        /// groups</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>.</para><note><para>A <i>cluster</i> placement group is a logical grouping of instances within a single
        /// Availability Zone. You cannot specify multiple Availability Zones and a cluster placement
        /// group. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PlacementGroup { get; set; }
        #endregion
        
        #region Parameter ServiceLinkedRoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the service-linked role that the Auto Scaling group
        /// uses to call other Amazon Web Services on your behalf. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/autoscaling-service-linked-role.html">Service-linked
        /// roles</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceLinkedRoleARN { get; set; }
        #endregion
        
        #region Parameter TerminationPolicy
        /// <summary>
        /// <para>
        /// <para>A policy or a list of policies that are used to select the instances to terminate.
        /// The policies are executed in the order that you list them. For more information, see
        /// <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-termination-policies.html">Work
        /// with Amazon EC2 Auto Scaling termination policies</a> in the <i>Amazon EC2 Auto Scaling
        /// User Guide</i>.</para><para>Valid values: <code>Default</code> | <code>AllocationStrategy</code> | <code>ClosestToNextInstanceHour</code>
        /// | <code>NewestInstance</code> | <code>OldestInstance</code> | <code>OldestLaunchConfiguration</code>
        /// | <code>OldestLaunchTemplate</code> | <code>arn:aws:lambda:region:account-id:function:my-function:my-alias</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TerminationPolicies")]
        public System.String[] TerminationPolicy { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The version number, <code>$Latest</code>, or <code>$Default</code>. To get the version
        /// number, use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeLaunchTemplateVersions.html">DescribeLaunchTemplateVersions</a>
        /// API operation. New launch template versions can be created using the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateLaunchTemplateVersion.html">CreateLaunchTemplateVersion</a>
        /// API. If the value is <code>$Latest</code>, Amazon EC2 Auto Scaling selects the latest
        /// version of the launch template when launching instances. If the value is <code>$Default</code>,
        /// Amazon EC2 Auto Scaling selects the default version of the launch template when launching
        /// instances. The default value is <code>$Default</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_Version { get; set; }
        #endregion
        
        #region Parameter VPCZoneIdentifier
        /// <summary>
        /// <para>
        /// <para>A comma-separated list of subnet IDs for a virtual private cloud (VPC). If you specify
        /// <code>VPCZoneIdentifier</code> with <code>AvailabilityZones</code>, the subnets that
        /// you specify must reside in those Availability Zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VPCZoneIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.UpdateAutoScalingGroupResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AutoScalingGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AutoScalingGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AutoScalingGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoScalingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ASAutoScalingGroup (UpdateAutoScalingGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.UpdateAutoScalingGroupResponse, UpdateASAutoScalingGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AutoScalingGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            #if MODULAR
            if (this.AutoScalingGroupName == null && ParameterWasBound(nameof(this.AutoScalingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZone = new List<System.String>(this.AvailabilityZone);
            }
            context.CapacityRebalance = this.CapacityRebalance;
            context.Context = this.Context;
            context.DefaultCooldown = this.DefaultCooldown;
            context.DefaultInstanceWarmup = this.DefaultInstanceWarmup;
            context.DesiredCapacity = this.DesiredCapacity;
            context.DesiredCapacityType = this.DesiredCapacityType;
            context.HealthCheckGracePeriod = this.HealthCheckGracePeriod;
            context.HealthCheckType = this.HealthCheckType;
            context.LaunchConfigurationName = this.LaunchConfigurationName;
            context.LaunchTemplate_LaunchTemplateId = this.LaunchTemplate_LaunchTemplateId;
            context.LaunchTemplate_LaunchTemplateName = this.LaunchTemplate_LaunchTemplateName;
            context.LaunchTemplate_Version = this.LaunchTemplate_Version;
            context.MaxInstanceLifetime = this.MaxInstanceLifetime;
            context.MaxSize = this.MaxSize;
            context.MinSize = this.MinSize;
            context.MixedInstancesPolicy = this.MixedInstancesPolicy;
            context.NewInstancesProtectedFromScaleIn = this.NewInstancesProtectedFromScaleIn;
            context.PlacementGroup = this.PlacementGroup;
            context.ServiceLinkedRoleARN = this.ServiceLinkedRoleARN;
            if (this.TerminationPolicy != null)
            {
                context.TerminationPolicy = new List<System.String>(this.TerminationPolicy);
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
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZones = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.CapacityRebalance != null)
            {
                request.CapacityRebalance = cmdletContext.CapacityRebalance.Value;
            }
            if (cmdletContext.Context != null)
            {
                request.Context = cmdletContext.Context;
            }
            if (cmdletContext.DefaultCooldown != null)
            {
                request.DefaultCooldown = cmdletContext.DefaultCooldown.Value;
            }
            if (cmdletContext.DefaultInstanceWarmup != null)
            {
                request.DefaultInstanceWarmup = cmdletContext.DefaultInstanceWarmup.Value;
            }
            if (cmdletContext.DesiredCapacity != null)
            {
                request.DesiredCapacity = cmdletContext.DesiredCapacity.Value;
            }
            if (cmdletContext.DesiredCapacityType != null)
            {
                request.DesiredCapacityType = cmdletContext.DesiredCapacityType;
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
            
             // populate LaunchTemplate
            var requestLaunchTemplateIsNull = true;
            request.LaunchTemplate = new Amazon.AutoScaling.Model.LaunchTemplateSpecification();
            System.String requestLaunchTemplate_launchTemplate_LaunchTemplateId = null;
            if (cmdletContext.LaunchTemplate_LaunchTemplateId != null)
            {
                requestLaunchTemplate_launchTemplate_LaunchTemplateId = cmdletContext.LaunchTemplate_LaunchTemplateId;
            }
            if (requestLaunchTemplate_launchTemplate_LaunchTemplateId != null)
            {
                request.LaunchTemplate.LaunchTemplateId = requestLaunchTemplate_launchTemplate_LaunchTemplateId;
                requestLaunchTemplateIsNull = false;
            }
            System.String requestLaunchTemplate_launchTemplate_LaunchTemplateName = null;
            if (cmdletContext.LaunchTemplate_LaunchTemplateName != null)
            {
                requestLaunchTemplate_launchTemplate_LaunchTemplateName = cmdletContext.LaunchTemplate_LaunchTemplateName;
            }
            if (requestLaunchTemplate_launchTemplate_LaunchTemplateName != null)
            {
                request.LaunchTemplate.LaunchTemplateName = requestLaunchTemplate_launchTemplate_LaunchTemplateName;
                requestLaunchTemplateIsNull = false;
            }
            System.String requestLaunchTemplate_launchTemplate_Version = null;
            if (cmdletContext.LaunchTemplate_Version != null)
            {
                requestLaunchTemplate_launchTemplate_Version = cmdletContext.LaunchTemplate_Version;
            }
            if (requestLaunchTemplate_launchTemplate_Version != null)
            {
                request.LaunchTemplate.Version = requestLaunchTemplate_launchTemplate_Version;
                requestLaunchTemplateIsNull = false;
            }
             // determine if request.LaunchTemplate should be set to null
            if (requestLaunchTemplateIsNull)
            {
                request.LaunchTemplate = null;
            }
            if (cmdletContext.MaxInstanceLifetime != null)
            {
                request.MaxInstanceLifetime = cmdletContext.MaxInstanceLifetime.Value;
            }
            if (cmdletContext.MaxSize != null)
            {
                request.MaxSize = cmdletContext.MaxSize.Value;
            }
            if (cmdletContext.MinSize != null)
            {
                request.MinSize = cmdletContext.MinSize.Value;
            }
            if (cmdletContext.MixedInstancesPolicy != null)
            {
                request.MixedInstancesPolicy = cmdletContext.MixedInstancesPolicy;
            }
            if (cmdletContext.NewInstancesProtectedFromScaleIn != null)
            {
                request.NewInstancesProtectedFromScaleIn = cmdletContext.NewInstancesProtectedFromScaleIn.Value;
            }
            if (cmdletContext.PlacementGroup != null)
            {
                request.PlacementGroup = cmdletContext.PlacementGroup;
            }
            if (cmdletContext.ServiceLinkedRoleARN != null)
            {
                request.ServiceLinkedRoleARN = cmdletContext.ServiceLinkedRoleARN;
            }
            if (cmdletContext.TerminationPolicy != null)
            {
                request.TerminationPolicies = cmdletContext.TerminationPolicy;
            }
            if (cmdletContext.VPCZoneIdentifier != null)
            {
                request.VPCZoneIdentifier = cmdletContext.VPCZoneIdentifier;
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
        
        private Amazon.AutoScaling.Model.UpdateAutoScalingGroupResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.UpdateAutoScalingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "UpdateAutoScalingGroup");
            try
            {
                #if DESKTOP
                return client.UpdateAutoScalingGroup(request);
                #elif CORECLR
                return client.UpdateAutoScalingGroupAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AvailabilityZone { get; set; }
            public System.Boolean? CapacityRebalance { get; set; }
            public System.String Context { get; set; }
            public System.Int32? DefaultCooldown { get; set; }
            public System.Int32? DefaultInstanceWarmup { get; set; }
            public System.Int32? DesiredCapacity { get; set; }
            public System.String DesiredCapacityType { get; set; }
            public System.Int32? HealthCheckGracePeriod { get; set; }
            public System.String HealthCheckType { get; set; }
            public System.String LaunchConfigurationName { get; set; }
            public System.String LaunchTemplate_LaunchTemplateId { get; set; }
            public System.String LaunchTemplate_LaunchTemplateName { get; set; }
            public System.String LaunchTemplate_Version { get; set; }
            public System.Int32? MaxInstanceLifetime { get; set; }
            public System.Int32? MaxSize { get; set; }
            public System.Int32? MinSize { get; set; }
            public Amazon.AutoScaling.Model.MixedInstancesPolicy MixedInstancesPolicy { get; set; }
            public System.Boolean? NewInstancesProtectedFromScaleIn { get; set; }
            public System.String PlacementGroup { get; set; }
            public System.String ServiceLinkedRoleARN { get; set; }
            public List<System.String> TerminationPolicy { get; set; }
            public System.String VPCZoneIdentifier { get; set; }
            public System.Func<Amazon.AutoScaling.Model.UpdateAutoScalingGroupResponse, UpdateASAutoScalingGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
