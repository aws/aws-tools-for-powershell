/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Creates a deployment group to which application revisions are deployed.
    /// </summary>
    [Cmdlet("New", "CDDeploymentGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CodeDeploy CreateDeploymentGroup API operation.", Operation = new[] {"CreateDeploymentGroup"}, SelectReturnType = typeof(Amazon.CodeDeploy.Model.CreateDeploymentGroupResponse))]
    [AWSCmdletOutput("System.String or Amazon.CodeDeploy.Model.CreateDeploymentGroupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CodeDeploy.Model.CreateDeploymentGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCDDeploymentGroupCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GreenFleetProvisioningOptionAction
        /// <summary>
        /// <para>
        /// <para>The method used to add instances to a replacement environment.</para><ul><li><para><c>DISCOVER_EXISTING</c>: Use instances that already exist or will be created manually.</para></li><li><para><c>COPY_AUTO_SCALING_GROUP</c>: Use settings from a specified Auto Scaling group
        /// to define and create instances in a new Auto Scaling group.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlueGreenDeploymentConfiguration_GreenFleetProvisioningOption_Action","GreenFleetProvisioningOption_Action")]
        [AWSConstantClassSource("Amazon.CodeDeploy.GreenFleetProvisioningAction")]
        public Amazon.CodeDeploy.GreenFleetProvisioningAction GreenFleetProvisioningOptionAction { get; set; }
        #endregion
        
        #region Parameter OnSuccessBlueInstanceTerminationAction
        /// <summary>
        /// <para>
        /// <para>The action to take on instances in the original environment after a successful blue/green
        /// deployment.</para><ul><li><para><c>TERMINATE</c>: Instances are terminated after a specified wait time.</para></li><li><para><c>KEEP_ALIVE</c>: Instances are left running after they are deregistered from the
        /// load balancer and removed from the deployment group.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_Action","TerminateBlueInstancesOnDeploymentSuccess_Action")]
        [AWSConstantClassSource("Amazon.CodeDeploy.InstanceAction")]
        public Amazon.CodeDeploy.InstanceAction OnSuccessBlueInstanceTerminationAction { get; set; }
        #endregion
        
        #region Parameter DeploymentReadyOptionTimeoutAction
        /// <summary>
        /// <para>
        /// <para>Information about when to reroute traffic from an original environment to a replacement
        /// environment in a blue/green deployment.</para><ul><li><para>CONTINUE_DEPLOYMENT: Register new instances with the load balancer immediately after
        /// the new application revision is installed on the instances in the replacement environment.</para></li><li><para>STOP_DEPLOYMENT: Do not register new instances with a load balancer unless traffic
        /// rerouting is started using <a>ContinueDeployment</a>. If traffic rerouting is not
        /// started before the end of the specified wait period, the deployment status is changed
        /// to Stopped.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlueGreenDeploymentConfiguration_DeploymentReadyOption_ActionOnTimeout","DeploymentReadyOption_ActionOnTimeout")]
        [AWSConstantClassSource("Amazon.CodeDeploy.DeploymentReadyAction")]
        public Amazon.CodeDeploy.DeploymentReadyAction DeploymentReadyOptionTimeoutAction { get; set; }
        #endregion
        
        #region Parameter AlarmConfiguration_Alarm
        /// <summary>
        /// <para>
        /// <para>A list of alarms configured for the deployment or deployment group. A maximum of 10
        /// alarms can be added.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlarmConfiguration_Alarms")]
        public Amazon.CodeDeploy.Model.Alarm[] AlarmConfiguration_Alarm { get; set; }
        #endregion
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of an CodeDeploy application associated with the user or Amazon Web Services
        /// account.</para>
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
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter AutoScalingGroup
        /// <summary>
        /// <para>
        /// <para>A list of associated Amazon EC2 Auto Scaling groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingGroups")]
        public System.String[] AutoScalingGroup { get; set; }
        #endregion
        
        #region Parameter DeploymentConfigName
        /// <summary>
        /// <para>
        /// <para>If specified, the deployment configuration name can be either one of the predefined
        /// configurations provided with CodeDeploy or a custom deployment configuration that
        /// you create by calling the create deployment configuration operation.</para><para><c>CodeDeployDefault.OneAtATime</c> is the default deployment configuration. It is
        /// used if a configuration isn't specified for the deployment or deployment group.</para><para>For more information about the predefined deployment configurations in CodeDeploy,
        /// see <a href="https://docs.aws.amazon.com/codedeploy/latest/userguide/deployment-configurations.html">Working
        /// with Deployment Configurations in CodeDeploy</a> in the <i>CodeDeploy User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeploymentConfigName { get; set; }
        #endregion
        
        #region Parameter DeploymentGroupName
        /// <summary>
        /// <para>
        /// <para>The name of a new deployment group for the specified application.</para>
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
        public System.String DeploymentGroupName { get; set; }
        #endregion
        
        #region Parameter DeploymentStyleOption
        /// <summary>
        /// <para>
        /// <para>Indicates whether to route deployment traffic behind a load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentStyle_DeploymentOption")]
        [AWSConstantClassSource("Amazon.CodeDeploy.DeploymentOption")]
        public Amazon.CodeDeploy.DeploymentOption DeploymentStyleOption { get; set; }
        #endregion
        
        #region Parameter DeploymentStyleType
        /// <summary>
        /// <para>
        /// <para>Indicates whether to run an in-place deployment or a blue/green deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentStyle_DeploymentType")]
        [AWSConstantClassSource("Amazon.CodeDeploy.DeploymentType")]
        public Amazon.CodeDeploy.DeploymentType DeploymentStyleType { get; set; }
        #endregion
        
        #region Parameter Ec2TagFilter
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 tags on which to filter. The deployment group includes Amazon EC2 instances
        /// with any of the specified tags. Cannot be used in the same call as ec2TagSet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ec2TagFilters")]
        public Amazon.CodeDeploy.Model.EC2TagFilter[] Ec2TagFilter { get; set; }
        #endregion
        
        #region Parameter Ec2TagSetList
        /// <summary>
        /// <para>
        /// <para>A list that contains other lists of Amazon EC2 instance tag groups. For an instance
        /// to be included in the deployment group, it must be identified by all of the tag groups
        /// in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CodeDeploy.Model.EC2TagFilter[][] Ec2TagSetList { get; set; }
        #endregion
        
        #region Parameter EcsService
        /// <summary>
        /// <para>
        /// <para> The target Amazon ECS services in the deployment group. This applies only to deployment
        /// groups that use the Amazon ECS compute platform. A target Amazon ECS service is specified
        /// as an Amazon ECS cluster and service name pair using the format <c>&lt;clustername&gt;:&lt;servicename&gt;</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EcsServices")]
        public Amazon.CodeDeploy.Model.ECSService[] EcsService { get; set; }
        #endregion
        
        #region Parameter LoadBalancerInfoList
        /// <summary>
        /// <para>
        /// <para>An array that contains information about the load balancers to use for load balancing
        /// in a deployment. If you're using Classic Load Balancers, specify those load balancers
        /// in this array. </para><note><para>You can add up to 10 load balancers to the array.</para></note><note><para>If you're using Application Load Balancers or Network Load Balancers, use the <c>targetGroupInfoList</c>
        /// array instead of this one.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancerInfo_ElbInfoList")]
        public Amazon.CodeDeploy.Model.ELBInfo[] LoadBalancerInfoList { get; set; }
        #endregion
        
        #region Parameter AlarmConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether the alarm configuration is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AlarmConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter AutoRollbackConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether a defined automatic rollback configuration is currently enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoRollbackConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter AutoRollbackConfiguration_Event
        /// <summary>
        /// <para>
        /// <para>The event type or types that trigger a rollback.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoRollbackConfiguration_Events")]
        public System.String[] AutoRollbackConfiguration_Event { get; set; }
        #endregion
        
        #region Parameter AlarmConfiguration_IgnorePollAlarmFailure
        /// <summary>
        /// <para>
        /// <para>Indicates whether a deployment should continue if information about the current state
        /// of alarms cannot be retrieved from Amazon CloudWatch. The default value is false.</para><ul><li><para><c>true</c>: The deployment proceeds even if alarm status information can't be retrieved
        /// from Amazon CloudWatch.</para></li><li><para><c>false</c>: The deployment stops if alarm status information can't be retrieved
        /// from Amazon CloudWatch.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AlarmConfiguration_IgnorePollAlarmFailure { get; set; }
        #endregion
        
        #region Parameter OnPremisesInstanceTagFilter
        /// <summary>
        /// <para>
        /// <para>The on-premises instance tags on which to filter. The deployment group includes on-premises
        /// instances with any of the specified tags. Cannot be used in the same call as <c>OnPremisesTagSet</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnPremisesInstanceTagFilters")]
        public Amazon.CodeDeploy.Model.TagFilter[] OnPremisesInstanceTagFilter { get; set; }
        #endregion
        
        #region Parameter OnPremisesTagSetList
        /// <summary>
        /// <para>
        /// <para>A list that contains other lists of on-premises instance tag groups. For an instance
        /// to be included in the deployment group, it must be identified by all of the tag groups
        /// in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CodeDeploy.Model.TagFilter[][] OnPremisesTagSetList { get; set; }
        #endregion
        
        #region Parameter OutdatedInstancesStrategy
        /// <summary>
        /// <para>
        /// <para>Indicates what happens when new Amazon EC2 instances are launched mid-deployment and
        /// do not receive the deployed application revision.</para><para>If this option is set to <c>UPDATE</c> or is unspecified, CodeDeploy initiates one
        /// or more 'auto-update outdated instances' deployments to apply the deployed application
        /// revision to the new Amazon EC2 instances.</para><para>If this option is set to <c>IGNORE</c>, CodeDeploy does not initiate a deployment
        /// to update the new Amazon EC2 instances. This may result in instances having different
        /// revisions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeDeploy.OutdatedInstancesStrategy")]
        public Amazon.CodeDeploy.OutdatedInstancesStrategy OutdatedInstancesStrategy { get; set; }
        #endregion
        
        #region Parameter ServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>A service role Amazon Resource Name (ARN) that allows CodeDeploy to act on the user's
        /// behalf when interacting with Amazon Web Services services.</para>
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
        public System.String ServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> The metadata that you apply to CodeDeploy deployment groups to help you organize
        /// and categorize them. Each tag consists of a key and an optional value, both of which
        /// you define. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CodeDeploy.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter LoadBalancerInfo_TargetGroupInfoList
        /// <summary>
        /// <para>
        /// <para>An array that contains information about the target groups to use for load balancing
        /// in a deployment. If you're using Application Load Balancers and Network Load Balancers,
        /// specify their associated target groups in this array.</para><note><para>You can add up to 10 target groups to the array.</para></note><note><para>If you're using Classic Load Balancers, use the <c>elbInfoList</c> array instead of
        /// this one.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CodeDeploy.Model.TargetGroupInfo[] LoadBalancerInfo_TargetGroupInfoList { get; set; }
        #endregion
        
        #region Parameter LoadBalancerInfo_TargetGroupPairInfoList
        /// <summary>
        /// <para>
        /// <para> The target group pair information. This is an array of <c>TargeGroupPairInfo</c>
        /// objects with a maximum size of one. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CodeDeploy.Model.TargetGroupPairInfo[] LoadBalancerInfo_TargetGroupPairInfoList { get; set; }
        #endregion
        
        #region Parameter TerminationHookEnabled
        /// <summary>
        /// <para>
        /// <para>This parameter only applies if you are using CodeDeploy with Amazon EC2 Auto Scaling.
        /// For more information, see <a href="https://docs.aws.amazon.com/codedeploy/latest/userguide/integrations-aws-auto-scaling.html">Integrating
        /// CodeDeploy with Amazon EC2 Auto Scaling</a> in the <i>CodeDeploy User Guide</i>.</para><para>Set <c>terminationHookEnabled</c> to <c>true</c> to have CodeDeploy install a termination
        /// hook into your Auto Scaling group when you create a deployment group. When this hook
        /// is installed, CodeDeploy will perform termination deployments.</para><para>For information about termination deployments, see <a href="https://docs.aws.amazon.com/codedeploy/latest/userguide/integrations-aws-auto-scaling.html#integrations-aws-auto-scaling-behaviors-hook-enable">Enabling
        /// termination deployments during Auto Scaling scale-in events</a> in the <i>CodeDeploy
        /// User Guide</i>.</para><para>For more information about Auto Scaling scale-in events, see the <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-lifecycle.html#as-lifecycle-scale-in">Scale
        /// in</a> topic in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TerminationHookEnabled { get; set; }
        #endregion
        
        #region Parameter OnSuccessBlueInstanceTerminationWaitTime
        /// <summary>
        /// <para>
        /// <para>For an Amazon EC2 deployment, the number of minutes to wait after a successful blue/green
        /// deployment before terminating instances from the original environment.</para><para> For an Amazon ECS deployment, the number of minutes before deleting the original
        /// (blue) task set. During an Amazon ECS deployment, CodeDeploy shifts traffic from the
        /// original (blue) task set to a replacement (green) task set. </para><para> The maximum setting is 2880 minutes (2 days). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_TerminationWaitTimeInMinutes","TerminateBlueInstancesOnDeploymentSuccess_TerminationWaitTimeInMinute")]
        public System.Int32? OnSuccessBlueInstanceTerminationWaitTime { get; set; }
        #endregion
        
        #region Parameter TriggerConfiguration
        /// <summary>
        /// <para>
        /// <para>Information about triggers to create when the deployment group is created. For examples,
        /// see <a href="https://docs.aws.amazon.com/codedeploy/latest/userguide/how-to-notify-sns.html">Create
        /// a Trigger for an CodeDeploy Event</a> in the <i>CodeDeploy User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TriggerConfigurations")]
        public Amazon.CodeDeploy.Model.TriggerConfig[] TriggerConfiguration { get; set; }
        #endregion
        
        #region Parameter DeploymentReadyOptionWaitTime
        /// <summary>
        /// <para>
        /// <para>The number of minutes to wait before the status of a blue/green deployment is changed
        /// to Stopped if rerouting is not started manually. Applies only to the <c>STOP_DEPLOYMENT</c>
        /// option for <c>actionOnTimeout</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlueGreenDeploymentConfiguration_DeploymentReadyOption_WaitTimeInMinutes","DeploymentReadyOption_WaitTimeInMinute")]
        public System.Int32? DeploymentReadyOptionWaitTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DeploymentGroupId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeDeploy.Model.CreateDeploymentGroupResponse).
        /// Specifying the name of a property of type Amazon.CodeDeploy.Model.CreateDeploymentGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DeploymentGroupId";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CDDeploymentGroup (CreateDeploymentGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeDeploy.Model.CreateDeploymentGroupResponse, NewCDDeploymentGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AlarmConfiguration_Alarm != null)
            {
                context.AlarmConfiguration_Alarm = new List<Amazon.CodeDeploy.Model.Alarm>(this.AlarmConfiguration_Alarm);
            }
            context.AlarmConfiguration_Enabled = this.AlarmConfiguration_Enabled;
            context.AlarmConfiguration_IgnorePollAlarmFailure = this.AlarmConfiguration_IgnorePollAlarmFailure;
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoRollbackConfiguration_Enabled = this.AutoRollbackConfiguration_Enabled;
            if (this.AutoRollbackConfiguration_Event != null)
            {
                context.AutoRollbackConfiguration_Event = new List<System.String>(this.AutoRollbackConfiguration_Event);
            }
            if (this.AutoScalingGroup != null)
            {
                context.AutoScalingGroup = new List<System.String>(this.AutoScalingGroup);
            }
            context.DeploymentReadyOptionTimeoutAction = this.DeploymentReadyOptionTimeoutAction;
            context.DeploymentReadyOptionWaitTime = this.DeploymentReadyOptionWaitTime;
            context.GreenFleetProvisioningOptionAction = this.GreenFleetProvisioningOptionAction;
            context.OnSuccessBlueInstanceTerminationAction = this.OnSuccessBlueInstanceTerminationAction;
            context.OnSuccessBlueInstanceTerminationWaitTime = this.OnSuccessBlueInstanceTerminationWaitTime;
            context.DeploymentConfigName = this.DeploymentConfigName;
            context.DeploymentGroupName = this.DeploymentGroupName;
            #if MODULAR
            if (this.DeploymentGroupName == null && ParameterWasBound(nameof(this.DeploymentGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeploymentStyleOption = this.DeploymentStyleOption;
            context.DeploymentStyleType = this.DeploymentStyleType;
            if (this.Ec2TagFilter != null)
            {
                context.Ec2TagFilter = new List<Amazon.CodeDeploy.Model.EC2TagFilter>(this.Ec2TagFilter);
            }
            if (this.Ec2TagSetList != null)
            {
                context.Ec2TagSetList = new List<List<Amazon.CodeDeploy.Model.EC2TagFilter>>();
                foreach (var innerList in this.Ec2TagSetList)
                {
                    context.Ec2TagSetList.Add(new List<Amazon.CodeDeploy.Model.EC2TagFilter>(innerList));
                }
            }
            if (this.EcsService != null)
            {
                context.EcsService = new List<Amazon.CodeDeploy.Model.ECSService>(this.EcsService);
            }
            if (this.LoadBalancerInfoList != null)
            {
                context.LoadBalancerInfoList = new List<Amazon.CodeDeploy.Model.ELBInfo>(this.LoadBalancerInfoList);
            }
            if (this.LoadBalancerInfo_TargetGroupInfoList != null)
            {
                context.LoadBalancerInfo_TargetGroupInfoList = new List<Amazon.CodeDeploy.Model.TargetGroupInfo>(this.LoadBalancerInfo_TargetGroupInfoList);
            }
            if (this.LoadBalancerInfo_TargetGroupPairInfoList != null)
            {
                context.LoadBalancerInfo_TargetGroupPairInfoList = new List<Amazon.CodeDeploy.Model.TargetGroupPairInfo>(this.LoadBalancerInfo_TargetGroupPairInfoList);
            }
            if (this.OnPremisesInstanceTagFilter != null)
            {
                context.OnPremisesInstanceTagFilter = new List<Amazon.CodeDeploy.Model.TagFilter>(this.OnPremisesInstanceTagFilter);
            }
            if (this.OnPremisesTagSetList != null)
            {
                context.OnPremisesTagSetList = new List<List<Amazon.CodeDeploy.Model.TagFilter>>();
                foreach (var innerList in this.OnPremisesTagSetList)
                {
                    context.OnPremisesTagSetList.Add(new List<Amazon.CodeDeploy.Model.TagFilter>(innerList));
                }
            }
            context.OutdatedInstancesStrategy = this.OutdatedInstancesStrategy;
            context.ServiceRoleArn = this.ServiceRoleArn;
            #if MODULAR
            if (this.ServiceRoleArn == null && ParameterWasBound(nameof(this.ServiceRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CodeDeploy.Model.Tag>(this.Tag);
            }
            context.TerminationHookEnabled = this.TerminationHookEnabled;
            if (this.TriggerConfiguration != null)
            {
                context.TriggerConfiguration = new List<Amazon.CodeDeploy.Model.TriggerConfig>(this.TriggerConfiguration);
            }
            
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
            var request = new Amazon.CodeDeploy.Model.CreateDeploymentGroupRequest();
            
            
             // populate AlarmConfiguration
            var requestAlarmConfigurationIsNull = true;
            request.AlarmConfiguration = new Amazon.CodeDeploy.Model.AlarmConfiguration();
            List<Amazon.CodeDeploy.Model.Alarm> requestAlarmConfiguration_alarmConfiguration_Alarm = null;
            if (cmdletContext.AlarmConfiguration_Alarm != null)
            {
                requestAlarmConfiguration_alarmConfiguration_Alarm = cmdletContext.AlarmConfiguration_Alarm;
            }
            if (requestAlarmConfiguration_alarmConfiguration_Alarm != null)
            {
                request.AlarmConfiguration.Alarms = requestAlarmConfiguration_alarmConfiguration_Alarm;
                requestAlarmConfigurationIsNull = false;
            }
            System.Boolean? requestAlarmConfiguration_alarmConfiguration_Enabled = null;
            if (cmdletContext.AlarmConfiguration_Enabled != null)
            {
                requestAlarmConfiguration_alarmConfiguration_Enabled = cmdletContext.AlarmConfiguration_Enabled.Value;
            }
            if (requestAlarmConfiguration_alarmConfiguration_Enabled != null)
            {
                request.AlarmConfiguration.Enabled = requestAlarmConfiguration_alarmConfiguration_Enabled.Value;
                requestAlarmConfigurationIsNull = false;
            }
            System.Boolean? requestAlarmConfiguration_alarmConfiguration_IgnorePollAlarmFailure = null;
            if (cmdletContext.AlarmConfiguration_IgnorePollAlarmFailure != null)
            {
                requestAlarmConfiguration_alarmConfiguration_IgnorePollAlarmFailure = cmdletContext.AlarmConfiguration_IgnorePollAlarmFailure.Value;
            }
            if (requestAlarmConfiguration_alarmConfiguration_IgnorePollAlarmFailure != null)
            {
                request.AlarmConfiguration.IgnorePollAlarmFailure = requestAlarmConfiguration_alarmConfiguration_IgnorePollAlarmFailure.Value;
                requestAlarmConfigurationIsNull = false;
            }
             // determine if request.AlarmConfiguration should be set to null
            if (requestAlarmConfigurationIsNull)
            {
                request.AlarmConfiguration = null;
            }
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            
             // populate AutoRollbackConfiguration
            var requestAutoRollbackConfigurationIsNull = true;
            request.AutoRollbackConfiguration = new Amazon.CodeDeploy.Model.AutoRollbackConfiguration();
            System.Boolean? requestAutoRollbackConfiguration_autoRollbackConfiguration_Enabled = null;
            if (cmdletContext.AutoRollbackConfiguration_Enabled != null)
            {
                requestAutoRollbackConfiguration_autoRollbackConfiguration_Enabled = cmdletContext.AutoRollbackConfiguration_Enabled.Value;
            }
            if (requestAutoRollbackConfiguration_autoRollbackConfiguration_Enabled != null)
            {
                request.AutoRollbackConfiguration.Enabled = requestAutoRollbackConfiguration_autoRollbackConfiguration_Enabled.Value;
                requestAutoRollbackConfigurationIsNull = false;
            }
            List<System.String> requestAutoRollbackConfiguration_autoRollbackConfiguration_Event = null;
            if (cmdletContext.AutoRollbackConfiguration_Event != null)
            {
                requestAutoRollbackConfiguration_autoRollbackConfiguration_Event = cmdletContext.AutoRollbackConfiguration_Event;
            }
            if (requestAutoRollbackConfiguration_autoRollbackConfiguration_Event != null)
            {
                request.AutoRollbackConfiguration.Events = requestAutoRollbackConfiguration_autoRollbackConfiguration_Event;
                requestAutoRollbackConfigurationIsNull = false;
            }
             // determine if request.AutoRollbackConfiguration should be set to null
            if (requestAutoRollbackConfigurationIsNull)
            {
                request.AutoRollbackConfiguration = null;
            }
            if (cmdletContext.AutoScalingGroup != null)
            {
                request.AutoScalingGroups = cmdletContext.AutoScalingGroup;
            }
            
             // populate BlueGreenDeploymentConfiguration
            var requestBlueGreenDeploymentConfigurationIsNull = true;
            request.BlueGreenDeploymentConfiguration = new Amazon.CodeDeploy.Model.BlueGreenDeploymentConfiguration();
            Amazon.CodeDeploy.Model.GreenFleetProvisioningOption requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption = null;
            
             // populate GreenFleetProvisioningOption
            var requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOptionIsNull = true;
            requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption = new Amazon.CodeDeploy.Model.GreenFleetProvisioningOption();
            Amazon.CodeDeploy.GreenFleetProvisioningAction requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption_greenFleetProvisioningOptionAction = null;
            if (cmdletContext.GreenFleetProvisioningOptionAction != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption_greenFleetProvisioningOptionAction = cmdletContext.GreenFleetProvisioningOptionAction;
            }
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption_greenFleetProvisioningOptionAction != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption.Action = requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption_greenFleetProvisioningOptionAction;
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOptionIsNull = false;
            }
             // determine if requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption should be set to null
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOptionIsNull)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption = null;
            }
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption != null)
            {
                request.BlueGreenDeploymentConfiguration.GreenFleetProvisioningOption = requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption;
                requestBlueGreenDeploymentConfigurationIsNull = false;
            }
            Amazon.CodeDeploy.Model.DeploymentReadyOption requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption = null;
            
             // populate DeploymentReadyOption
            var requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOptionIsNull = true;
            requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption = new Amazon.CodeDeploy.Model.DeploymentReadyOption();
            Amazon.CodeDeploy.DeploymentReadyAction requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOptionTimeoutAction = null;
            if (cmdletContext.DeploymentReadyOptionTimeoutAction != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOptionTimeoutAction = cmdletContext.DeploymentReadyOptionTimeoutAction;
            }
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOptionTimeoutAction != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption.ActionOnTimeout = requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOptionTimeoutAction;
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOptionIsNull = false;
            }
            System.Int32? requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOptionWaitTime = null;
            if (cmdletContext.DeploymentReadyOptionWaitTime != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOptionWaitTime = cmdletContext.DeploymentReadyOptionWaitTime.Value;
            }
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOptionWaitTime != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption.WaitTimeInMinutes = requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOptionWaitTime.Value;
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOptionIsNull = false;
            }
             // determine if requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption should be set to null
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOptionIsNull)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption = null;
            }
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption != null)
            {
                request.BlueGreenDeploymentConfiguration.DeploymentReadyOption = requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption;
                requestBlueGreenDeploymentConfigurationIsNull = false;
            }
            Amazon.CodeDeploy.Model.BlueInstanceTerminationOption requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess = null;
            
             // populate TerminateBlueInstancesOnDeploymentSuccess
            var requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccessIsNull = true;
            requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess = new Amazon.CodeDeploy.Model.BlueInstanceTerminationOption();
            Amazon.CodeDeploy.InstanceAction requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_onSuccessBlueInstanceTerminationAction = null;
            if (cmdletContext.OnSuccessBlueInstanceTerminationAction != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_onSuccessBlueInstanceTerminationAction = cmdletContext.OnSuccessBlueInstanceTerminationAction;
            }
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_onSuccessBlueInstanceTerminationAction != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess.Action = requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_onSuccessBlueInstanceTerminationAction;
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccessIsNull = false;
            }
            System.Int32? requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_onSuccessBlueInstanceTerminationWaitTime = null;
            if (cmdletContext.OnSuccessBlueInstanceTerminationWaitTime != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_onSuccessBlueInstanceTerminationWaitTime = cmdletContext.OnSuccessBlueInstanceTerminationWaitTime.Value;
            }
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_onSuccessBlueInstanceTerminationWaitTime != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess.TerminationWaitTimeInMinutes = requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_onSuccessBlueInstanceTerminationWaitTime.Value;
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccessIsNull = false;
            }
             // determine if requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess should be set to null
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccessIsNull)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess = null;
            }
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess != null)
            {
                request.BlueGreenDeploymentConfiguration.TerminateBlueInstancesOnDeploymentSuccess = requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess;
                requestBlueGreenDeploymentConfigurationIsNull = false;
            }
             // determine if request.BlueGreenDeploymentConfiguration should be set to null
            if (requestBlueGreenDeploymentConfigurationIsNull)
            {
                request.BlueGreenDeploymentConfiguration = null;
            }
            if (cmdletContext.DeploymentConfigName != null)
            {
                request.DeploymentConfigName = cmdletContext.DeploymentConfigName;
            }
            if (cmdletContext.DeploymentGroupName != null)
            {
                request.DeploymentGroupName = cmdletContext.DeploymentGroupName;
            }
            
             // populate DeploymentStyle
            var requestDeploymentStyleIsNull = true;
            request.DeploymentStyle = new Amazon.CodeDeploy.Model.DeploymentStyle();
            Amazon.CodeDeploy.DeploymentOption requestDeploymentStyle_deploymentStyleOption = null;
            if (cmdletContext.DeploymentStyleOption != null)
            {
                requestDeploymentStyle_deploymentStyleOption = cmdletContext.DeploymentStyleOption;
            }
            if (requestDeploymentStyle_deploymentStyleOption != null)
            {
                request.DeploymentStyle.DeploymentOption = requestDeploymentStyle_deploymentStyleOption;
                requestDeploymentStyleIsNull = false;
            }
            Amazon.CodeDeploy.DeploymentType requestDeploymentStyle_deploymentStyleType = null;
            if (cmdletContext.DeploymentStyleType != null)
            {
                requestDeploymentStyle_deploymentStyleType = cmdletContext.DeploymentStyleType;
            }
            if (requestDeploymentStyle_deploymentStyleType != null)
            {
                request.DeploymentStyle.DeploymentType = requestDeploymentStyle_deploymentStyleType;
                requestDeploymentStyleIsNull = false;
            }
             // determine if request.DeploymentStyle should be set to null
            if (requestDeploymentStyleIsNull)
            {
                request.DeploymentStyle = null;
            }
            if (cmdletContext.Ec2TagFilter != null)
            {
                request.Ec2TagFilters = cmdletContext.Ec2TagFilter;
            }
            
             // populate Ec2TagSet
            var requestEc2TagSetIsNull = true;
            request.Ec2TagSet = new Amazon.CodeDeploy.Model.EC2TagSet();
            List<List<Amazon.CodeDeploy.Model.EC2TagFilter>> requestEc2TagSet_ec2TagSetList = null;
            if (cmdletContext.Ec2TagSetList != null)
            {
                requestEc2TagSet_ec2TagSetList = cmdletContext.Ec2TagSetList;
            }
            if (requestEc2TagSet_ec2TagSetList != null)
            {
                request.Ec2TagSet.Ec2TagSetList = requestEc2TagSet_ec2TagSetList;
                requestEc2TagSetIsNull = false;
            }
             // determine if request.Ec2TagSet should be set to null
            if (requestEc2TagSetIsNull)
            {
                request.Ec2TagSet = null;
            }
            if (cmdletContext.EcsService != null)
            {
                request.EcsServices = cmdletContext.EcsService;
            }
            
             // populate LoadBalancerInfo
            var requestLoadBalancerInfoIsNull = true;
            request.LoadBalancerInfo = new Amazon.CodeDeploy.Model.LoadBalancerInfo();
            List<Amazon.CodeDeploy.Model.ELBInfo> requestLoadBalancerInfo_loadBalancerInfoList = null;
            if (cmdletContext.LoadBalancerInfoList != null)
            {
                requestLoadBalancerInfo_loadBalancerInfoList = cmdletContext.LoadBalancerInfoList;
            }
            if (requestLoadBalancerInfo_loadBalancerInfoList != null)
            {
                request.LoadBalancerInfo.ElbInfoList = requestLoadBalancerInfo_loadBalancerInfoList;
                requestLoadBalancerInfoIsNull = false;
            }
            List<Amazon.CodeDeploy.Model.TargetGroupInfo> requestLoadBalancerInfo_loadBalancerInfo_TargetGroupInfoList = null;
            if (cmdletContext.LoadBalancerInfo_TargetGroupInfoList != null)
            {
                requestLoadBalancerInfo_loadBalancerInfo_TargetGroupInfoList = cmdletContext.LoadBalancerInfo_TargetGroupInfoList;
            }
            if (requestLoadBalancerInfo_loadBalancerInfo_TargetGroupInfoList != null)
            {
                request.LoadBalancerInfo.TargetGroupInfoList = requestLoadBalancerInfo_loadBalancerInfo_TargetGroupInfoList;
                requestLoadBalancerInfoIsNull = false;
            }
            List<Amazon.CodeDeploy.Model.TargetGroupPairInfo> requestLoadBalancerInfo_loadBalancerInfo_TargetGroupPairInfoList = null;
            if (cmdletContext.LoadBalancerInfo_TargetGroupPairInfoList != null)
            {
                requestLoadBalancerInfo_loadBalancerInfo_TargetGroupPairInfoList = cmdletContext.LoadBalancerInfo_TargetGroupPairInfoList;
            }
            if (requestLoadBalancerInfo_loadBalancerInfo_TargetGroupPairInfoList != null)
            {
                request.LoadBalancerInfo.TargetGroupPairInfoList = requestLoadBalancerInfo_loadBalancerInfo_TargetGroupPairInfoList;
                requestLoadBalancerInfoIsNull = false;
            }
             // determine if request.LoadBalancerInfo should be set to null
            if (requestLoadBalancerInfoIsNull)
            {
                request.LoadBalancerInfo = null;
            }
            if (cmdletContext.OnPremisesInstanceTagFilter != null)
            {
                request.OnPremisesInstanceTagFilters = cmdletContext.OnPremisesInstanceTagFilter;
            }
            
             // populate OnPremisesTagSet
            var requestOnPremisesTagSetIsNull = true;
            request.OnPremisesTagSet = new Amazon.CodeDeploy.Model.OnPremisesTagSet();
            List<List<Amazon.CodeDeploy.Model.TagFilter>> requestOnPremisesTagSet_onPremisesTagSetList = null;
            if (cmdletContext.OnPremisesTagSetList != null)
            {
                requestOnPremisesTagSet_onPremisesTagSetList = cmdletContext.OnPremisesTagSetList;
            }
            if (requestOnPremisesTagSet_onPremisesTagSetList != null)
            {
                request.OnPremisesTagSet.OnPremisesTagSetList = requestOnPremisesTagSet_onPremisesTagSetList;
                requestOnPremisesTagSetIsNull = false;
            }
             // determine if request.OnPremisesTagSet should be set to null
            if (requestOnPremisesTagSetIsNull)
            {
                request.OnPremisesTagSet = null;
            }
            if (cmdletContext.OutdatedInstancesStrategy != null)
            {
                request.OutdatedInstancesStrategy = cmdletContext.OutdatedInstancesStrategy;
            }
            if (cmdletContext.ServiceRoleArn != null)
            {
                request.ServiceRoleArn = cmdletContext.ServiceRoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TerminationHookEnabled != null)
            {
                request.TerminationHookEnabled = cmdletContext.TerminationHookEnabled.Value;
            }
            if (cmdletContext.TriggerConfiguration != null)
            {
                request.TriggerConfigurations = cmdletContext.TriggerConfiguration;
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
        
        private Amazon.CodeDeploy.Model.CreateDeploymentGroupResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.CreateDeploymentGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeDeploy", "CreateDeploymentGroup");
            try
            {
                return client.CreateDeploymentGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.CodeDeploy.Model.Alarm> AlarmConfiguration_Alarm { get; set; }
            public System.Boolean? AlarmConfiguration_Enabled { get; set; }
            public System.Boolean? AlarmConfiguration_IgnorePollAlarmFailure { get; set; }
            public System.String ApplicationName { get; set; }
            public System.Boolean? AutoRollbackConfiguration_Enabled { get; set; }
            public List<System.String> AutoRollbackConfiguration_Event { get; set; }
            public List<System.String> AutoScalingGroup { get; set; }
            public Amazon.CodeDeploy.DeploymentReadyAction DeploymentReadyOptionTimeoutAction { get; set; }
            public System.Int32? DeploymentReadyOptionWaitTime { get; set; }
            public Amazon.CodeDeploy.GreenFleetProvisioningAction GreenFleetProvisioningOptionAction { get; set; }
            public Amazon.CodeDeploy.InstanceAction OnSuccessBlueInstanceTerminationAction { get; set; }
            public System.Int32? OnSuccessBlueInstanceTerminationWaitTime { get; set; }
            public System.String DeploymentConfigName { get; set; }
            public System.String DeploymentGroupName { get; set; }
            public Amazon.CodeDeploy.DeploymentOption DeploymentStyleOption { get; set; }
            public Amazon.CodeDeploy.DeploymentType DeploymentStyleType { get; set; }
            public List<Amazon.CodeDeploy.Model.EC2TagFilter> Ec2TagFilter { get; set; }
            public List<List<Amazon.CodeDeploy.Model.EC2TagFilter>> Ec2TagSetList { get; set; }
            public List<Amazon.CodeDeploy.Model.ECSService> EcsService { get; set; }
            public List<Amazon.CodeDeploy.Model.ELBInfo> LoadBalancerInfoList { get; set; }
            public List<Amazon.CodeDeploy.Model.TargetGroupInfo> LoadBalancerInfo_TargetGroupInfoList { get; set; }
            public List<Amazon.CodeDeploy.Model.TargetGroupPairInfo> LoadBalancerInfo_TargetGroupPairInfoList { get; set; }
            public List<Amazon.CodeDeploy.Model.TagFilter> OnPremisesInstanceTagFilter { get; set; }
            public List<List<Amazon.CodeDeploy.Model.TagFilter>> OnPremisesTagSetList { get; set; }
            public Amazon.CodeDeploy.OutdatedInstancesStrategy OutdatedInstancesStrategy { get; set; }
            public System.String ServiceRoleArn { get; set; }
            public List<Amazon.CodeDeploy.Model.Tag> Tag { get; set; }
            public System.Boolean? TerminationHookEnabled { get; set; }
            public List<Amazon.CodeDeploy.Model.TriggerConfig> TriggerConfiguration { get; set; }
            public System.Func<Amazon.CodeDeploy.Model.CreateDeploymentGroupResponse, NewCDDeploymentGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeploymentGroupId;
        }
        
    }
}
