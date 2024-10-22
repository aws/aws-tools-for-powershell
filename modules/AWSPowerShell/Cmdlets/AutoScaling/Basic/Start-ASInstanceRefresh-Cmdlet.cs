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
    /// Starts an instance refresh.
    /// 
    ///  
    /// <para>
    /// This operation is part of the <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-instance-refresh.html">instance
    /// refresh feature</a> in Amazon EC2 Auto Scaling, which helps you update instances in
    /// your Auto Scaling group. This feature is helpful, for example, when you have a new
    /// AMI or a new user data script. You just need to create a new launch template that
    /// specifies the new AMI or user data script. Then start an instance refresh to immediately
    /// begin the process of updating instances in the group. 
    /// </para><para>
    /// If successful, the request's response contains a unique ID that you can use to track
    /// the progress of the instance refresh. To query its status, call the <a>DescribeInstanceRefreshes</a>
    /// API. To describe the instance refreshes that have already run, call the <a>DescribeInstanceRefreshes</a>
    /// API. To cancel an instance refresh that is in progress, use the <a>CancelInstanceRefresh</a>
    /// API. 
    /// </para><para>
    /// An instance refresh might fail for several reasons, such as EC2 launch failures, misconfigured
    /// health checks, or not ignoring or allowing the termination of instances that are in
    /// <c>Standby</c> state or protected from scale in. You can monitor for failed EC2 launches
    /// using the scaling activities. To find the scaling activities, call the <a>DescribeScalingActivities</a>
    /// API.
    /// </para><para>
    /// If you enable auto rollback, your Auto Scaling group will be rolled back automatically
    /// when the instance refresh fails. You can enable this feature before starting an instance
    /// refresh by specifying the <c>AutoRollback</c> property in the instance refresh preferences.
    /// Otherwise, to roll back an instance refresh before it finishes, use the <a>RollbackInstanceRefresh</a>
    /// API. 
    /// </para>
    /// </summary>
    [Cmdlet("Start", "ASInstanceRefresh", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Auto Scaling StartInstanceRefresh API operation.", Operation = new[] {"StartInstanceRefresh"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.StartInstanceRefreshResponse))]
    [AWSCmdletOutput("System.String or Amazon.AutoScaling.Model.StartInstanceRefreshResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AutoScaling.Model.StartInstanceRefreshResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartASInstanceRefreshCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AlarmSpecification_Alarm
        /// <summary>
        /// <para>
        /// <para>The names of one or more CloudWatch alarms to monitor for the instance refresh. You
        /// can specify up to 10 alarms.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_AlarmSpecification_Alarms")]
        public System.String[] AlarmSpecification_Alarm { get; set; }
        #endregion
        
        #region Parameter Preferences_AutoRollback
        /// <summary>
        /// <para>
        /// <para>(Optional) Indicates whether to roll back the Auto Scaling group to its previous configuration
        /// if the instance refresh fails or a CloudWatch alarm threshold is met. The default
        /// is <c>false</c>.</para><para>A rollback is not supported in the following situations: </para><ul><li><para>There is no desired configuration specified for the instance refresh.</para></li><li><para>The Auto Scaling group has a launch template that uses an Amazon Web Services Systems
        /// Manager parameter instead of an AMI ID for the <c>ImageId</c> property.</para></li><li><para>The Auto Scaling group uses the launch template's <c>$Latest</c> or <c>$Default</c>
        /// version.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/instance-refresh-rollback.html">Undo
        /// changes with a rollback</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Preferences_AutoRollback { get; set; }
        #endregion
        
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
        
        #region Parameter Preferences_CheckpointDelay
        /// <summary>
        /// <para>
        /// <para>(Optional) The amount of time, in seconds, to wait after a checkpoint before continuing.
        /// This property is optional, but if you specify a value for it, you must also specify
        /// a value for <c>CheckpointPercentages</c>. If you specify a value for <c>CheckpointPercentages</c>
        /// and not for <c>CheckpointDelay</c>, the <c>CheckpointDelay</c> defaults to <c>3600</c>
        /// (1 hour). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Preferences_CheckpointDelay { get; set; }
        #endregion
        
        #region Parameter Preferences_CheckpointPercentage
        /// <summary>
        /// <para>
        /// <para>(Optional) Threshold values for each checkpoint in ascending order. Each number must
        /// be unique. To replace all instances in the Auto Scaling group, the last number in
        /// the array must be <c>100</c>.</para><para>For usage examples, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-adding-checkpoints-instance-refresh.html">Add
        /// checkpoints to an instance refresh</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_CheckpointPercentages")]
        public System.Int32[] Preferences_CheckpointPercentage { get; set; }
        #endregion
        
        #region Parameter Preferences_InstanceWarmup
        /// <summary>
        /// <para>
        /// <para>A time period, in seconds, during which an instance refresh waits before moving on
        /// to replacing the next instance after a new instance enters the <c>InService</c> state.</para><para>This property is not required for normal usage. Instead, use the <c>DefaultInstanceWarmup</c>
        /// property of the Auto Scaling group. The <c>InstanceWarmup</c> and <c>DefaultInstanceWarmup</c>
        /// properties work the same way. Only specify this property if you must override the
        /// <c>DefaultInstanceWarmup</c> property. </para><para> If you do not specify this property, the instance warmup by default is the value
        /// of the <c>DefaultInstanceWarmup</c> property, if defined (which is recommended in
        /// all cases), or the <c>HealthCheckGracePeriod</c> property otherwise.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Preferences_InstanceWarmup { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateId
        /// <summary>
        /// <para>
        /// <para>The ID of the launch template. To get the template ID, use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeLaunchTemplates.html">DescribeLaunchTemplates</a>
        /// API operation. New launch templates can be created using the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateLaunchTemplate.html">CreateLaunchTemplate</a>
        /// API. </para><para>Conditional: You must specify either a <c>LaunchTemplateId</c> or a <c>LaunchTemplateName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DesiredConfiguration_LaunchTemplate_LaunchTemplateId")]
        public System.String LaunchTemplate_LaunchTemplateId { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the launch template. To get the template name, use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeLaunchTemplates.html">DescribeLaunchTemplates</a>
        /// API operation. New launch templates can be created using the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateLaunchTemplate.html">CreateLaunchTemplate</a>
        /// API. </para><para>Conditional: You must specify either a <c>LaunchTemplateId</c> or a <c>LaunchTemplateName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DesiredConfiguration_LaunchTemplate_LaunchTemplateName")]
        public System.String LaunchTemplate_LaunchTemplateName { get; set; }
        #endregion
        
        #region Parameter Preferences_MaxHealthyPercentage
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum percentage of the group that can be in service and healthy,
        /// or pending, to support your workload when replacing instances. The value is expressed
        /// as a percentage of the desired capacity of the Auto Scaling group. Value range is
        /// 100 to 200.</para><para>If you specify <c>MaxHealthyPercentage</c>, you must also specify <c>MinHealthyPercentage</c>,
        /// and the difference between them cannot be greater than 100. A larger range increases
        /// the number of instances that can be replaced at the same time.</para><para>If you do not specify this property, the default is 100 percent, or the percentage
        /// set in the instance maintenance policy for the Auto Scaling group, if defined.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Preferences_MaxHealthyPercentage { get; set; }
        #endregion
        
        #region Parameter Preferences_MinHealthyPercentage
        /// <summary>
        /// <para>
        /// <para>Specifies the minimum percentage of the group to keep in service, healthy, and ready
        /// to use to support your workload to allow the operation to continue. The value is expressed
        /// as a percentage of the desired capacity of the Auto Scaling group. Value range is
        /// 0 to 100.</para><para>If you do not specify this property, the default is 90 percent, or the percentage
        /// set in the instance maintenance policy for the Auto Scaling group, if defined.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Preferences_MinHealthyPercentage { get; set; }
        #endregion
        
        #region Parameter DesiredConfiguration_MixedInstancesPolicy
        /// <summary>
        /// <para>
        /// <para>Use this structure to launch multiple instance types and On-Demand Instances and Spot
        /// Instances within a single Auto Scaling group.</para><para>A mixed instances policy contains information that Amazon EC2 Auto Scaling can use
        /// to launch instances and help optimize your costs. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-mixed-instances-groups.html">Auto
        /// Scaling groups with multiple instance types and purchase options</a> in the <i>Amazon
        /// EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AutoScaling.Model.MixedInstancesPolicy DesiredConfiguration_MixedInstancesPolicy { get; set; }
        #endregion
        
        #region Parameter Preferences_ScaleInProtectedInstance
        /// <summary>
        /// <para>
        /// <para>Choose the behavior that you want Amazon EC2 Auto Scaling to use if instances protected
        /// from scale in are found. </para><para>The following lists the valid values:</para><dl><dt>Refresh</dt><dd><para>Amazon EC2 Auto Scaling replaces instances that are protected from scale in.</para></dd><dt>Ignore</dt><dd><para>Amazon EC2 Auto Scaling ignores instances that are protected from scale in and continues
        /// to replace instances that are not protected.</para></dd><dt>Wait (default)</dt><dd><para>Amazon EC2 Auto Scaling waits one hour for you to remove scale-in protection. Otherwise,
        /// the instance refresh will fail.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_ScaleInProtectedInstances")]
        [AWSConstantClassSource("Amazon.AutoScaling.ScaleInProtectedInstances")]
        public Amazon.AutoScaling.ScaleInProtectedInstances Preferences_ScaleInProtectedInstance { get; set; }
        #endregion
        
        #region Parameter Preferences_SkipMatching
        /// <summary>
        /// <para>
        /// <para>(Optional) Indicates whether skip matching is enabled. If enabled (<c>true</c>), then
        /// Amazon EC2 Auto Scaling skips replacing instances that match the desired configuration.
        /// If no desired configuration is specified, then it skips replacing instances that have
        /// the same launch template and instance types that the Auto Scaling group was using
        /// before the start of the instance refresh. The default is <c>false</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-instance-refresh-skip-matching.html">Use
        /// an instance refresh with skip matching</a> in the <i>Amazon EC2 Auto Scaling User
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Preferences_SkipMatching { get; set; }
        #endregion
        
        #region Parameter Preferences_StandbyInstance
        /// <summary>
        /// <para>
        /// <para>Choose the behavior that you want Amazon EC2 Auto Scaling to use if instances in <c>Standby</c>
        /// state are found.</para><para>The following lists the valid values:</para><dl><dt>Terminate</dt><dd><para>Amazon EC2 Auto Scaling terminates instances that are in <c>Standby</c>.</para></dd><dt>Ignore</dt><dd><para>Amazon EC2 Auto Scaling ignores instances that are in <c>Standby</c> and continues
        /// to replace instances that are in the <c>InService</c> state.</para></dd><dt>Wait (default)</dt><dd><para>Amazon EC2 Auto Scaling waits one hour for you to return the instances to service.
        /// Otherwise, the instance refresh will fail.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_StandbyInstances")]
        [AWSConstantClassSource("Amazon.AutoScaling.StandbyInstances")]
        public Amazon.AutoScaling.StandbyInstances Preferences_StandbyInstance { get; set; }
        #endregion
        
        #region Parameter Strategy
        /// <summary>
        /// <para>
        /// <para>The strategy to use for the instance refresh. The only valid value is <c>Rolling</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AutoScaling.RefreshStrategy")]
        public Amazon.AutoScaling.RefreshStrategy Strategy { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The version number, <c>$Latest</c>, or <c>$Default</c>. To get the version number,
        /// use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeLaunchTemplateVersions.html">DescribeLaunchTemplateVersions</a>
        /// API operation. New launch template versions can be created using the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateLaunchTemplateVersion.html">CreateLaunchTemplateVersion</a>
        /// API. If the value is <c>$Latest</c>, Amazon EC2 Auto Scaling selects the latest version
        /// of the launch template when launching instances. If the value is <c>$Default</c>,
        /// Amazon EC2 Auto Scaling selects the default version of the launch template when launching
        /// instances. The default value is <c>$Default</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DesiredConfiguration_LaunchTemplate_Version")]
        public System.String LaunchTemplate_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceRefreshId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.StartInstanceRefreshResponse).
        /// Specifying the name of a property of type Amazon.AutoScaling.Model.StartInstanceRefreshResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceRefreshId";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ASInstanceRefresh (StartInstanceRefresh)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.StartInstanceRefreshResponse, StartASInstanceRefreshCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            #if MODULAR
            if (this.AutoScalingGroupName == null && ParameterWasBound(nameof(this.AutoScalingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LaunchTemplate_LaunchTemplateId = this.LaunchTemplate_LaunchTemplateId;
            context.LaunchTemplate_LaunchTemplateName = this.LaunchTemplate_LaunchTemplateName;
            context.LaunchTemplate_Version = this.LaunchTemplate_Version;
            context.DesiredConfiguration_MixedInstancesPolicy = this.DesiredConfiguration_MixedInstancesPolicy;
            if (this.AlarmSpecification_Alarm != null)
            {
                context.AlarmSpecification_Alarm = new List<System.String>(this.AlarmSpecification_Alarm);
            }
            context.Preferences_AutoRollback = this.Preferences_AutoRollback;
            context.Preferences_CheckpointDelay = this.Preferences_CheckpointDelay;
            if (this.Preferences_CheckpointPercentage != null)
            {
                context.Preferences_CheckpointPercentage = new List<System.Int32>(this.Preferences_CheckpointPercentage);
            }
            context.Preferences_InstanceWarmup = this.Preferences_InstanceWarmup;
            context.Preferences_MaxHealthyPercentage = this.Preferences_MaxHealthyPercentage;
            context.Preferences_MinHealthyPercentage = this.Preferences_MinHealthyPercentage;
            context.Preferences_ScaleInProtectedInstance = this.Preferences_ScaleInProtectedInstance;
            context.Preferences_SkipMatching = this.Preferences_SkipMatching;
            context.Preferences_StandbyInstance = this.Preferences_StandbyInstance;
            context.Strategy = this.Strategy;
            
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
            var request = new Amazon.AutoScaling.Model.StartInstanceRefreshRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            
             // populate DesiredConfiguration
            var requestDesiredConfigurationIsNull = true;
            request.DesiredConfiguration = new Amazon.AutoScaling.Model.DesiredConfiguration();
            Amazon.AutoScaling.Model.MixedInstancesPolicy requestDesiredConfiguration_desiredConfiguration_MixedInstancesPolicy = null;
            if (cmdletContext.DesiredConfiguration_MixedInstancesPolicy != null)
            {
                requestDesiredConfiguration_desiredConfiguration_MixedInstancesPolicy = cmdletContext.DesiredConfiguration_MixedInstancesPolicy;
            }
            if (requestDesiredConfiguration_desiredConfiguration_MixedInstancesPolicy != null)
            {
                request.DesiredConfiguration.MixedInstancesPolicy = requestDesiredConfiguration_desiredConfiguration_MixedInstancesPolicy;
                requestDesiredConfigurationIsNull = false;
            }
            Amazon.AutoScaling.Model.LaunchTemplateSpecification requestDesiredConfiguration_desiredConfiguration_LaunchTemplate = null;
            
             // populate LaunchTemplate
            var requestDesiredConfiguration_desiredConfiguration_LaunchTemplateIsNull = true;
            requestDesiredConfiguration_desiredConfiguration_LaunchTemplate = new Amazon.AutoScaling.Model.LaunchTemplateSpecification();
            System.String requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateId = null;
            if (cmdletContext.LaunchTemplate_LaunchTemplateId != null)
            {
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateId = cmdletContext.LaunchTemplate_LaunchTemplateId;
            }
            if (requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateId != null)
            {
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplate.LaunchTemplateId = requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateId;
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplateIsNull = false;
            }
            System.String requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateName = null;
            if (cmdletContext.LaunchTemplate_LaunchTemplateName != null)
            {
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateName = cmdletContext.LaunchTemplate_LaunchTemplateName;
            }
            if (requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateName != null)
            {
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplate.LaunchTemplateName = requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateName;
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplateIsNull = false;
            }
            System.String requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_Version = null;
            if (cmdletContext.LaunchTemplate_Version != null)
            {
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_Version = cmdletContext.LaunchTemplate_Version;
            }
            if (requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_Version != null)
            {
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplate.Version = requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_Version;
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplateIsNull = false;
            }
             // determine if requestDesiredConfiguration_desiredConfiguration_LaunchTemplate should be set to null
            if (requestDesiredConfiguration_desiredConfiguration_LaunchTemplateIsNull)
            {
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplate = null;
            }
            if (requestDesiredConfiguration_desiredConfiguration_LaunchTemplate != null)
            {
                request.DesiredConfiguration.LaunchTemplate = requestDesiredConfiguration_desiredConfiguration_LaunchTemplate;
                requestDesiredConfigurationIsNull = false;
            }
             // determine if request.DesiredConfiguration should be set to null
            if (requestDesiredConfigurationIsNull)
            {
                request.DesiredConfiguration = null;
            }
            
             // populate Preferences
            var requestPreferencesIsNull = true;
            request.Preferences = new Amazon.AutoScaling.Model.RefreshPreferences();
            System.Boolean? requestPreferences_preferences_AutoRollback = null;
            if (cmdletContext.Preferences_AutoRollback != null)
            {
                requestPreferences_preferences_AutoRollback = cmdletContext.Preferences_AutoRollback.Value;
            }
            if (requestPreferences_preferences_AutoRollback != null)
            {
                request.Preferences.AutoRollback = requestPreferences_preferences_AutoRollback.Value;
                requestPreferencesIsNull = false;
            }
            System.Int32? requestPreferences_preferences_CheckpointDelay = null;
            if (cmdletContext.Preferences_CheckpointDelay != null)
            {
                requestPreferences_preferences_CheckpointDelay = cmdletContext.Preferences_CheckpointDelay.Value;
            }
            if (requestPreferences_preferences_CheckpointDelay != null)
            {
                request.Preferences.CheckpointDelay = requestPreferences_preferences_CheckpointDelay.Value;
                requestPreferencesIsNull = false;
            }
            List<System.Int32> requestPreferences_preferences_CheckpointPercentage = null;
            if (cmdletContext.Preferences_CheckpointPercentage != null)
            {
                requestPreferences_preferences_CheckpointPercentage = cmdletContext.Preferences_CheckpointPercentage;
            }
            if (requestPreferences_preferences_CheckpointPercentage != null)
            {
                request.Preferences.CheckpointPercentages = requestPreferences_preferences_CheckpointPercentage;
                requestPreferencesIsNull = false;
            }
            System.Int32? requestPreferences_preferences_InstanceWarmup = null;
            if (cmdletContext.Preferences_InstanceWarmup != null)
            {
                requestPreferences_preferences_InstanceWarmup = cmdletContext.Preferences_InstanceWarmup.Value;
            }
            if (requestPreferences_preferences_InstanceWarmup != null)
            {
                request.Preferences.InstanceWarmup = requestPreferences_preferences_InstanceWarmup.Value;
                requestPreferencesIsNull = false;
            }
            System.Int32? requestPreferences_preferences_MaxHealthyPercentage = null;
            if (cmdletContext.Preferences_MaxHealthyPercentage != null)
            {
                requestPreferences_preferences_MaxHealthyPercentage = cmdletContext.Preferences_MaxHealthyPercentage.Value;
            }
            if (requestPreferences_preferences_MaxHealthyPercentage != null)
            {
                request.Preferences.MaxHealthyPercentage = requestPreferences_preferences_MaxHealthyPercentage.Value;
                requestPreferencesIsNull = false;
            }
            System.Int32? requestPreferences_preferences_MinHealthyPercentage = null;
            if (cmdletContext.Preferences_MinHealthyPercentage != null)
            {
                requestPreferences_preferences_MinHealthyPercentage = cmdletContext.Preferences_MinHealthyPercentage.Value;
            }
            if (requestPreferences_preferences_MinHealthyPercentage != null)
            {
                request.Preferences.MinHealthyPercentage = requestPreferences_preferences_MinHealthyPercentage.Value;
                requestPreferencesIsNull = false;
            }
            Amazon.AutoScaling.ScaleInProtectedInstances requestPreferences_preferences_ScaleInProtectedInstance = null;
            if (cmdletContext.Preferences_ScaleInProtectedInstance != null)
            {
                requestPreferences_preferences_ScaleInProtectedInstance = cmdletContext.Preferences_ScaleInProtectedInstance;
            }
            if (requestPreferences_preferences_ScaleInProtectedInstance != null)
            {
                request.Preferences.ScaleInProtectedInstances = requestPreferences_preferences_ScaleInProtectedInstance;
                requestPreferencesIsNull = false;
            }
            System.Boolean? requestPreferences_preferences_SkipMatching = null;
            if (cmdletContext.Preferences_SkipMatching != null)
            {
                requestPreferences_preferences_SkipMatching = cmdletContext.Preferences_SkipMatching.Value;
            }
            if (requestPreferences_preferences_SkipMatching != null)
            {
                request.Preferences.SkipMatching = requestPreferences_preferences_SkipMatching.Value;
                requestPreferencesIsNull = false;
            }
            Amazon.AutoScaling.StandbyInstances requestPreferences_preferences_StandbyInstance = null;
            if (cmdletContext.Preferences_StandbyInstance != null)
            {
                requestPreferences_preferences_StandbyInstance = cmdletContext.Preferences_StandbyInstance;
            }
            if (requestPreferences_preferences_StandbyInstance != null)
            {
                request.Preferences.StandbyInstances = requestPreferences_preferences_StandbyInstance;
                requestPreferencesIsNull = false;
            }
            Amazon.AutoScaling.Model.AlarmSpecification requestPreferences_preferences_AlarmSpecification = null;
            
             // populate AlarmSpecification
            var requestPreferences_preferences_AlarmSpecificationIsNull = true;
            requestPreferences_preferences_AlarmSpecification = new Amazon.AutoScaling.Model.AlarmSpecification();
            List<System.String> requestPreferences_preferences_AlarmSpecification_alarmSpecification_Alarm = null;
            if (cmdletContext.AlarmSpecification_Alarm != null)
            {
                requestPreferences_preferences_AlarmSpecification_alarmSpecification_Alarm = cmdletContext.AlarmSpecification_Alarm;
            }
            if (requestPreferences_preferences_AlarmSpecification_alarmSpecification_Alarm != null)
            {
                requestPreferences_preferences_AlarmSpecification.Alarms = requestPreferences_preferences_AlarmSpecification_alarmSpecification_Alarm;
                requestPreferences_preferences_AlarmSpecificationIsNull = false;
            }
             // determine if requestPreferences_preferences_AlarmSpecification should be set to null
            if (requestPreferences_preferences_AlarmSpecificationIsNull)
            {
                requestPreferences_preferences_AlarmSpecification = null;
            }
            if (requestPreferences_preferences_AlarmSpecification != null)
            {
                request.Preferences.AlarmSpecification = requestPreferences_preferences_AlarmSpecification;
                requestPreferencesIsNull = false;
            }
             // determine if request.Preferences should be set to null
            if (requestPreferencesIsNull)
            {
                request.Preferences = null;
            }
            if (cmdletContext.Strategy != null)
            {
                request.Strategy = cmdletContext.Strategy;
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
        
        private Amazon.AutoScaling.Model.StartInstanceRefreshResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.StartInstanceRefreshRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "StartInstanceRefresh");
            try
            {
                #if DESKTOP
                return client.StartInstanceRefresh(request);
                #elif CORECLR
                return client.StartInstanceRefreshAsync(request).GetAwaiter().GetResult();
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
            public System.String LaunchTemplate_LaunchTemplateId { get; set; }
            public System.String LaunchTemplate_LaunchTemplateName { get; set; }
            public System.String LaunchTemplate_Version { get; set; }
            public Amazon.AutoScaling.Model.MixedInstancesPolicy DesiredConfiguration_MixedInstancesPolicy { get; set; }
            public List<System.String> AlarmSpecification_Alarm { get; set; }
            public System.Boolean? Preferences_AutoRollback { get; set; }
            public System.Int32? Preferences_CheckpointDelay { get; set; }
            public List<System.Int32> Preferences_CheckpointPercentage { get; set; }
            public System.Int32? Preferences_InstanceWarmup { get; set; }
            public System.Int32? Preferences_MaxHealthyPercentage { get; set; }
            public System.Int32? Preferences_MinHealthyPercentage { get; set; }
            public Amazon.AutoScaling.ScaleInProtectedInstances Preferences_ScaleInProtectedInstance { get; set; }
            public System.Boolean? Preferences_SkipMatching { get; set; }
            public Amazon.AutoScaling.StandbyInstances Preferences_StandbyInstance { get; set; }
            public Amazon.AutoScaling.RefreshStrategy Strategy { get; set; }
            public System.Func<Amazon.AutoScaling.Model.StartInstanceRefreshResponse, StartASInstanceRefreshCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceRefreshId;
        }
        
    }
}
