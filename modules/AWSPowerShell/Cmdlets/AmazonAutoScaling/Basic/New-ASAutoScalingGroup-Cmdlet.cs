/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// If you exceed your maximum limit of Auto Scaling groups, the call fails. For information
    /// about viewing this limit, see <a>DescribeAccountLimits</a>. For information about
    /// updating this limit, see <a href="http://docs.aws.amazon.com/autoscaling/ec2/userguide/as-account-limits.html">Auto
    /// Scaling Limits</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/autoscaling/ec2/userguide/AutoScalingGroup.html">Auto
    /// Scaling Groups</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ASAutoScalingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Auto Scaling CreateAutoScalingGroup API operation.", Operation = new[] {"CreateAutoScalingGroup"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AutoScalingGroupName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.AutoScaling.Model.CreateAutoScalingGroupResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewASAutoScalingGroupCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group. This name must be unique within the scope of your
        /// AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>One or more Availability Zones for the group. This parameter is optional if you specify
        /// one or more subnets.</para>
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
        /// scaling activity can start. The default is 300.</para><para>For more information, see <a href="http://docs.aws.amazon.com/autoscaling/ec2/userguide/Cooldown.html">Scaling
        /// Cooldowns</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DefaultCooldown { get; set; }
        #endregion
        
        #region Parameter DesiredCapacity
        /// <summary>
        /// <para>
        /// <para>The number of EC2 instances that should be running in the group. This number must
        /// be greater than or equal to the minimum size of the group and less than or equal to
        /// the maximum size of the group. If you do not specify a desired capacity, the default
        /// is the minimum size of the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DesiredCapacity { get; set; }
        #endregion
        
        #region Parameter HealthCheckGracePeriod
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that Amazon EC2 Auto Scaling waits before checking
        /// the health status of an EC2 instance that has come into service. During this time,
        /// any health check failures for the instance are ignored. The default is 0.</para><para>This parameter is required if you are adding an <code>ELB</code> health check.</para><para>For more information, see <a href="http://docs.aws.amazon.com/autoscaling/ec2/userguide/healthcheck.html">Health
        /// Checks</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthCheckGracePeriod { get; set; }
        #endregion
        
        #region Parameter HealthCheckType
        /// <summary>
        /// <para>
        /// <para>The service to use for the health checks. The valid values are <code>EC2</code> and
        /// <code>ELB</code>.</para><para>By default, health checks use Amazon EC2 instance status checks to determine the health
        /// of an instance. For more information, see <a href="http://docs.aws.amazon.com/autoscaling/ec2/userguide/healthcheck.html">Health
        /// Checks</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheckType { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance used to create a launch configuration for the group. This parameter,
        /// a launch configuration, a launch template, or a mixed instances policy must be specified.</para><para>When you specify an ID of an instance, Amazon EC2 Auto Scaling creates a new launch
        /// configuration and associates it with the group. This launch configuration derives
        /// its attributes from the specified instance, except for the block device mapping.</para><para>For more information, see <a href="http://docs.aws.amazon.com/autoscaling/ec2/userguide/create-asg-from-instance.html">Create
        /// an Auto Scaling Group Using an EC2 Instance</a> in the <i>Amazon EC2 Auto Scaling
        /// User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter LaunchConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of the launch configuration. This parameter, a launch template, a mixed instances
        /// policy, or an EC2 instance must be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String LaunchConfigurationName { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateId
        /// <summary>
        /// <para>
        /// <para>The ID of the launch template. You must specify either a template ID or a template
        /// name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchTemplate_LaunchTemplateId { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the launch template. You must specify either a template name or a template
        /// ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchTemplate_LaunchTemplateName { get; set; }
        #endregion
        
        #region Parameter LifecycleHookSpecificationList
        /// <summary>
        /// <para>
        /// <para>One or more lifecycle hooks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.AutoScaling.Model.LifecycleHookSpecification[] LifecycleHookSpecificationList { get; set; }
        #endregion
        
        #region Parameter LoadBalancerName
        /// <summary>
        /// <para>
        /// <para>One or more Classic Load Balancers. To specify an Application Load Balancer, use <code>TargetGroupARNs</code>
        /// instead.</para><para>For more information, see <a href="http://docs.aws.amazon.com/autoscaling/ec2/userguide/create-asg-from-instance.html">Using
        /// a Load Balancer With an Auto Scaling Group</a> in the <i>Amazon EC2 Auto Scaling User
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LoadBalancerNames")]
        public System.String[] LoadBalancerName { get; set; }
        #endregion
        
        #region Parameter MaxSize
        /// <summary>
        /// <para>
        /// <para>The maximum size of the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.Int32 MaxSize { get; set; }
        #endregion
        
        #region Parameter MinSize
        /// <summary>
        /// <para>
        /// <para>The minimum size of the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.Int32 MinSize { get; set; }
        #endregion
        
        #region Parameter MixedInstancesPolicy
        /// <summary>
        /// <para>
        /// <para>The mixed instances policy to use to launch instances. This parameter, a launch template,
        /// a launch configuration, or an EC2 instance must be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.AutoScaling.Model.MixedInstancesPolicy MixedInstancesPolicy { get; set; }
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
        /// <para>The name of the placement group into which to launch your instances, if any. For more
        /// information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/placement-groups.html">Placement
        /// Groups</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PlacementGroup { get; set; }
        #endregion
        
        #region Parameter ServiceLinkedRoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the service-linked role that the Auto Scaling group
        /// uses to call other AWS services on your behalf. By default, Amazon EC2 Auto Scaling
        /// uses a service-linked role named AWSServiceRoleForAutoScaling, which it creates if
        /// it does not exist.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceLinkedRoleARN { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags.</para><para>For more information, see <a href="http://docs.aws.amazon.com/autoscaling/ec2/userguide/autoscaling-tagging.html">Tagging
        /// Auto Scaling Groups and Instances</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.AutoScaling.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetGroupARNs
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARN) of the target groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] TargetGroupARNs { get; set; }
        #endregion
        
        #region Parameter TerminationPolicy
        /// <summary>
        /// <para>
        /// <para>One or more termination policies used to select the instance to terminate. These policies
        /// are executed in the order that they are listed.</para><para>For more information, see <a href="http://docs.aws.amazon.com/autoscaling/ec2/userguide/as-instance-termination.html">Controlling
        /// Which Instances Auto Scaling Terminates During Scale In</a> in the <i>Auto Scaling
        /// User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TerminationPolicies")]
        public System.String[] TerminationPolicy { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The version number, <code>$Latest</code>, or <code>$Default</code>. If the value is
        /// <code>$Latest</code>, Amazon EC2 Auto Scaling selects the latest version of the launch
        /// template when launching instances. If the value is <code>$Default</code>, Amazon EC2
        /// Auto Scaling selects the default version of the launch template when launching instances.
        /// The default value is <code>$Default</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchTemplate_Version { get; set; }
        #endregion
        
        #region Parameter VPCZoneIdentifier
        /// <summary>
        /// <para>
        /// <para>A comma-separated list of subnet identifiers for your virtual private cloud (VPC).</para><para>If you specify subnets and Availability Zones with this call, ensure that the subnets'
        /// Availability Zones match the Availability Zones specified.</para><para>For more information, see <a href="http://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-in-vpc.html">Launching
        /// Auto Scaling Instances in a VPC</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASAutoScalingGroup (CreateAutoScalingGroup)"))
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
            context.InstanceId = this.InstanceId;
            context.LaunchConfigurationName = this.LaunchConfigurationName;
            context.LaunchTemplate_LaunchTemplateId = this.LaunchTemplate_LaunchTemplateId;
            context.LaunchTemplate_LaunchTemplateName = this.LaunchTemplate_LaunchTemplateName;
            context.LaunchTemplate_Version = this.LaunchTemplate_Version;
            if (this.LifecycleHookSpecificationList != null)
            {
                context.LifecycleHookSpecificationList = new List<Amazon.AutoScaling.Model.LifecycleHookSpecification>(this.LifecycleHookSpecificationList);
            }
            if (this.LoadBalancerName != null)
            {
                context.LoadBalancerNames = new List<System.String>(this.LoadBalancerName);
            }
            if (ParameterWasBound("MaxSize"))
                context.MaxSize = this.MaxSize;
            if (ParameterWasBound("MinSize"))
                context.MinSize = this.MinSize;
            context.MixedInstancesPolicy = this.MixedInstancesPolicy;
            if (ParameterWasBound("NewInstancesProtectedFromScaleIn"))
                context.NewInstancesProtectedFromScaleIn = this.NewInstancesProtectedFromScaleIn;
            context.PlacementGroup = this.PlacementGroup;
            context.ServiceLinkedRoleARN = this.ServiceLinkedRoleARN;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.AutoScaling.Model.Tag>(this.Tag);
            }
            if (this.TargetGroupARNs != null)
            {
                context.TargetGroupARNs = new List<System.String>(this.TargetGroupARNs);
            }
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
            var request = new Amazon.AutoScaling.Model.CreateAutoScalingGroupRequest();
            
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
            
             // populate LaunchTemplate
            bool requestLaunchTemplateIsNull = true;
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
            if (cmdletContext.LifecycleHookSpecificationList != null)
            {
                request.LifecycleHookSpecificationList = cmdletContext.LifecycleHookSpecificationList;
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
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.TargetGroupARNs != null)
            {
                request.TargetGroupARNs = cmdletContext.TargetGroupARNs;
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
        
        private Amazon.AutoScaling.Model.CreateAutoScalingGroupResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.CreateAutoScalingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Auto Scaling", "CreateAutoScalingGroup");
            try
            {
                #if DESKTOP
                return client.CreateAutoScalingGroup(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateAutoScalingGroupAsync(request);
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
            public System.String InstanceId { get; set; }
            public System.String LaunchConfigurationName { get; set; }
            public System.String LaunchTemplate_LaunchTemplateId { get; set; }
            public System.String LaunchTemplate_LaunchTemplateName { get; set; }
            public System.String LaunchTemplate_Version { get; set; }
            public List<Amazon.AutoScaling.Model.LifecycleHookSpecification> LifecycleHookSpecificationList { get; set; }
            public List<System.String> LoadBalancerNames { get; set; }
            public System.Int32? MaxSize { get; set; }
            public System.Int32? MinSize { get; set; }
            public Amazon.AutoScaling.Model.MixedInstancesPolicy MixedInstancesPolicy { get; set; }
            public System.Boolean? NewInstancesProtectedFromScaleIn { get; set; }
            public System.String PlacementGroup { get; set; }
            public System.String ServiceLinkedRoleARN { get; set; }
            public List<Amazon.AutoScaling.Model.Tag> Tags { get; set; }
            public List<System.String> TargetGroupARNs { get; set; }
            public List<System.String> TerminationPolicies { get; set; }
            public System.String VPCZoneIdentifier { get; set; }
        }
        
    }
}
