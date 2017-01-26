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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Changes information about a deployment group.
    /// </summary>
    [Cmdlet("Update", "CDDeploymentGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeDeploy.Model.AutoScalingGroup")]
    [AWSCmdlet("Invokes the UpdateDeploymentGroup operation against AWS CodeDeploy.", Operation = new[] {"UpdateDeploymentGroup"})]
    [AWSCmdletOutput("Amazon.CodeDeploy.Model.AutoScalingGroup",
        "This cmdlet returns a collection of AutoScalingGroup objects.",
        "The service call response (type Amazon.CodeDeploy.Model.UpdateDeploymentGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCDDeploymentGroupCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        #region Parameter GreenFleetProvisioningOption_Action
        /// <summary>
        /// <para>
        /// <para>The method used to add instances to a replacement environment.</para><ul><li><para>DISCOVER_EXISTING: Use instances that already exist or will be created manually.</para></li><li><para>COPY_AUTO_SCALING_GROUP: Use settings from a specified Auto Scaling group to define
        /// and create instances in a new Auto Scaling group.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BlueGreenDeploymentConfiguration_GreenFleetProvisioningOption_Action")]
        [AWSConstantClassSource("Amazon.CodeDeploy.GreenFleetProvisioningAction")]
        public Amazon.CodeDeploy.GreenFleetProvisioningAction GreenFleetProvisioningOption_Action { get; set; }
        #endregion
        
        #region Parameter TerminateBlueInstancesOnDeploymentSuccess_Action
        /// <summary>
        /// <para>
        /// <para>The action to take on instances in the original environment after a successful blue/green
        /// deployment.</para><ul><li><para>TERMINATE: Instances are terminated after a specified wait time.</para></li><li><para>KEEP_ALIVE: Instances are left running after they are deregistered from the load balancer
        /// and removed from the deployment group.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_Action")]
        [AWSConstantClassSource("Amazon.CodeDeploy.InstanceAction")]
        public Amazon.CodeDeploy.InstanceAction TerminateBlueInstancesOnDeploymentSuccess_Action { get; set; }
        #endregion
        
        #region Parameter DeploymentReadyOption_ActionOnTimeout
        /// <summary>
        /// <para>
        /// <para>Information about when to reroute traffic from an original environment to a replacement
        /// environment in a blue/green deployment.</para><ul><li><para>CONTINUE_DEPLOYMENT: Register new instances with the load balancer immediately after
        /// the new application revision is installed on the instances in the replacement environment.</para></li><li><para>STOP_DEPLOYMENT: Do not register new instances with load balancer unless traffic is
        /// rerouted manually. If traffic is not rerouted manually before the end of the specified
        /// wait period, the deployment status is changed to Stopped.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BlueGreenDeploymentConfiguration_DeploymentReadyOption_ActionOnTimeout")]
        [AWSConstantClassSource("Amazon.CodeDeploy.DeploymentReadyAction")]
        public Amazon.CodeDeploy.DeploymentReadyAction DeploymentReadyOption_ActionOnTimeout { get; set; }
        #endregion
        
        #region Parameter AlarmConfiguration_Alarm
        /// <summary>
        /// <para>
        /// <para>A list of alarms configured for the deployment group. A maximum of 10 alarms can be
        /// added to a deployment group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AlarmConfiguration_Alarms")]
        public Amazon.CodeDeploy.Model.Alarm[] AlarmConfiguration_Alarm { get; set; }
        #endregion
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The application name corresponding to the deployment group to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter AutoScalingGroup
        /// <summary>
        /// <para>
        /// <para>The replacement list of Auto Scaling groups to be included in the deployment group,
        /// if you want to change them. To keep the Auto Scaling groups, enter their names. To
        /// remove Auto Scaling groups, do not enter any Auto Scaling group names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AutoScalingGroups")]
        public System.String[] AutoScalingGroup { get; set; }
        #endregion
        
        #region Parameter CurrentDeploymentGroupName
        /// <summary>
        /// <para>
        /// <para>The current name of the deployment group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CurrentDeploymentGroupName { get; set; }
        #endregion
        
        #region Parameter DeploymentConfigName
        /// <summary>
        /// <para>
        /// <para>The replacement deployment configuration name to use, if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeploymentConfigName { get; set; }
        #endregion
        
        #region Parameter DeploymentStyle_DeploymentOption
        /// <summary>
        /// <para>
        /// <para>Indicates whether to route deployment traffic behind a load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeDeploy.DeploymentOption")]
        public Amazon.CodeDeploy.DeploymentOption DeploymentStyle_DeploymentOption { get; set; }
        #endregion
        
        #region Parameter DeploymentStyle_DeploymentType
        /// <summary>
        /// <para>
        /// <para>Indicates whether to run a standard deployment or a blue/green deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeDeploy.DeploymentType")]
        public Amazon.CodeDeploy.DeploymentType DeploymentStyle_DeploymentType { get; set; }
        #endregion
        
        #region Parameter Ec2TagFilter
        /// <summary>
        /// <para>
        /// <para>The replacement set of Amazon EC2 tags on which to filter, if you want to change them.
        /// To keep the existing tags, enter their names. To remove tags, do not enter any tag
        /// names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Ec2TagFilters")]
        public Amazon.CodeDeploy.Model.EC2TagFilter[] Ec2TagFilter { get; set; }
        #endregion
        
        #region Parameter LoadBalancerInfo_ElbInfoList
        /// <summary>
        /// <para>
        /// <para>An array containing information about the load balancer in Elastic Load Balancing
        /// to use in a blue/green deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CodeDeploy.Model.ELBInfo[] LoadBalancerInfo_ElbInfoList { get; set; }
        #endregion
        
        #region Parameter AlarmConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether the alarm configuration is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AlarmConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter AutoRollbackConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether a defined automatic rollback configuration is currently enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AutoRollbackConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter AutoRollbackConfiguration_Event
        /// <summary>
        /// <para>
        /// <para>The event type or types that trigger a rollback.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AutoRollbackConfiguration_Events")]
        public System.String[] AutoRollbackConfiguration_Event { get; set; }
        #endregion
        
        #region Parameter AlarmConfiguration_IgnorePollAlarmFailure
        /// <summary>
        /// <para>
        /// <para>Indicates whether a deployment should continue if information about the current state
        /// of alarms cannot be retrieved from Amazon CloudWatch. The default value is false.</para><ul><li><para>true: The deployment will proceed even if alarm status information can't be retrieved
        /// from Amazon CloudWatch.</para></li><li><para>false: The deployment will stop if alarm status information can't be retrieved from
        /// Amazon CloudWatch.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AlarmConfiguration_IgnorePollAlarmFailure { get; set; }
        #endregion
        
        #region Parameter NewDeploymentGroupName
        /// <summary>
        /// <para>
        /// <para>The new name of the deployment group, if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewDeploymentGroupName { get; set; }
        #endregion
        
        #region Parameter OnPremisesInstanceTagFilter
        /// <summary>
        /// <para>
        /// <para>The replacement set of on-premises instance tags on which to filter, if you want to
        /// change them. To keep the existing tags, enter their names. To remove tags, do not
        /// enter any tag names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OnPremisesInstanceTagFilters")]
        public Amazon.CodeDeploy.Model.TagFilter[] OnPremisesInstanceTagFilter { get; set; }
        #endregion
        
        #region Parameter ServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>A replacement ARN for the service role, if you want to change it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter TerminateBlueInstancesOnDeploymentSuccess_TerminationWaitTimeInMinute
        /// <summary>
        /// <para>
        /// <para>The number of minutes to wait after a successful blue/green deployment before terminating
        /// instances from the original environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_TerminationWaitTimeInMinutes")]
        public System.Int32 TerminateBlueInstancesOnDeploymentSuccess_TerminationWaitTimeInMinute { get; set; }
        #endregion
        
        #region Parameter TriggerConfiguration
        /// <summary>
        /// <para>
        /// <para>Information about triggers to change when the deployment group is updated. For examples,
        /// see <a href="http://docs.aws.amazon.com/codedeploy/latest/userguide/how-to-notify-edit.html">Modify
        /// Triggers in an AWS CodeDeploy Deployment Group</a> in the AWS CodeDeploy User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TriggerConfigurations")]
        public Amazon.CodeDeploy.Model.TriggerConfig[] TriggerConfiguration { get; set; }
        #endregion
        
        #region Parameter DeploymentReadyOption_WaitTimeInMinute
        /// <summary>
        /// <para>
        /// <para>The number of minutes to wait before the status of a blue/green deployment changed
        /// to Stopped if rerouting is not started manually. Applies only to the STOP_DEPLOYMENT
        /// option for actionOnTimeout</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BlueGreenDeploymentConfiguration_DeploymentReadyOption_WaitTimeInMinutes")]
        public System.Int32 DeploymentReadyOption_WaitTimeInMinute { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CDDeploymentGroup (UpdateDeploymentGroup)"))
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
            
            if (this.AlarmConfiguration_Alarm != null)
            {
                context.AlarmConfiguration_Alarms = new List<Amazon.CodeDeploy.Model.Alarm>(this.AlarmConfiguration_Alarm);
            }
            if (ParameterWasBound("AlarmConfiguration_Enabled"))
                context.AlarmConfiguration_Enabled = this.AlarmConfiguration_Enabled;
            if (ParameterWasBound("AlarmConfiguration_IgnorePollAlarmFailure"))
                context.AlarmConfiguration_IgnorePollAlarmFailure = this.AlarmConfiguration_IgnorePollAlarmFailure;
            context.ApplicationName = this.ApplicationName;
            if (ParameterWasBound("AutoRollbackConfiguration_Enabled"))
                context.AutoRollbackConfiguration_Enabled = this.AutoRollbackConfiguration_Enabled;
            if (this.AutoRollbackConfiguration_Event != null)
            {
                context.AutoRollbackConfiguration_Events = new List<System.String>(this.AutoRollbackConfiguration_Event);
            }
            if (this.AutoScalingGroup != null)
            {
                context.AutoScalingGroups = new List<System.String>(this.AutoScalingGroup);
            }
            context.BlueGreenDeploymentConfiguration_DeploymentReadyOption_ActionOnTimeout = this.DeploymentReadyOption_ActionOnTimeout;
            if (ParameterWasBound("DeploymentReadyOption_WaitTimeInMinute"))
                context.BlueGreenDeploymentConfiguration_DeploymentReadyOption_WaitTimeInMinutes = this.DeploymentReadyOption_WaitTimeInMinute;
            context.BlueGreenDeploymentConfiguration_GreenFleetProvisioningOption_Action = this.GreenFleetProvisioningOption_Action;
            context.BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_Action = this.TerminateBlueInstancesOnDeploymentSuccess_Action;
            if (ParameterWasBound("TerminateBlueInstancesOnDeploymentSuccess_TerminationWaitTimeInMinute"))
                context.BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_TerminationWaitTimeInMinutes = this.TerminateBlueInstancesOnDeploymentSuccess_TerminationWaitTimeInMinute;
            context.CurrentDeploymentGroupName = this.CurrentDeploymentGroupName;
            context.DeploymentConfigName = this.DeploymentConfigName;
            context.DeploymentStyle_DeploymentOption = this.DeploymentStyle_DeploymentOption;
            context.DeploymentStyle_DeploymentType = this.DeploymentStyle_DeploymentType;
            if (this.Ec2TagFilter != null)
            {
                context.Ec2TagFilters = new List<Amazon.CodeDeploy.Model.EC2TagFilter>(this.Ec2TagFilter);
            }
            if (this.LoadBalancerInfo_ElbInfoList != null)
            {
                context.LoadBalancerInfo_ElbInfoList = new List<Amazon.CodeDeploy.Model.ELBInfo>(this.LoadBalancerInfo_ElbInfoList);
            }
            context.NewDeploymentGroupName = this.NewDeploymentGroupName;
            if (this.OnPremisesInstanceTagFilter != null)
            {
                context.OnPremisesInstanceTagFilters = new List<Amazon.CodeDeploy.Model.TagFilter>(this.OnPremisesInstanceTagFilter);
            }
            context.ServiceRoleArn = this.ServiceRoleArn;
            if (this.TriggerConfiguration != null)
            {
                context.TriggerConfigurations = new List<Amazon.CodeDeploy.Model.TriggerConfig>(this.TriggerConfiguration);
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
            var request = new Amazon.CodeDeploy.Model.UpdateDeploymentGroupRequest();
            
            
             // populate AlarmConfiguration
            bool requestAlarmConfigurationIsNull = true;
            request.AlarmConfiguration = new Amazon.CodeDeploy.Model.AlarmConfiguration();
            List<Amazon.CodeDeploy.Model.Alarm> requestAlarmConfiguration_alarmConfiguration_Alarm = null;
            if (cmdletContext.AlarmConfiguration_Alarms != null)
            {
                requestAlarmConfiguration_alarmConfiguration_Alarm = cmdletContext.AlarmConfiguration_Alarms;
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
            bool requestAutoRollbackConfigurationIsNull = true;
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
            if (cmdletContext.AutoRollbackConfiguration_Events != null)
            {
                requestAutoRollbackConfiguration_autoRollbackConfiguration_Event = cmdletContext.AutoRollbackConfiguration_Events;
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
            if (cmdletContext.AutoScalingGroups != null)
            {
                request.AutoScalingGroups = cmdletContext.AutoScalingGroups;
            }
            
             // populate BlueGreenDeploymentConfiguration
            bool requestBlueGreenDeploymentConfigurationIsNull = true;
            request.BlueGreenDeploymentConfiguration = new Amazon.CodeDeploy.Model.BlueGreenDeploymentConfiguration();
            Amazon.CodeDeploy.Model.GreenFleetProvisioningOption requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption = null;
            
             // populate GreenFleetProvisioningOption
            bool requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOptionIsNull = true;
            requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption = new Amazon.CodeDeploy.Model.GreenFleetProvisioningOption();
            Amazon.CodeDeploy.GreenFleetProvisioningAction requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption_greenFleetProvisioningOption_Action = null;
            if (cmdletContext.BlueGreenDeploymentConfiguration_GreenFleetProvisioningOption_Action != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption_greenFleetProvisioningOption_Action = cmdletContext.BlueGreenDeploymentConfiguration_GreenFleetProvisioningOption_Action;
            }
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption_greenFleetProvisioningOption_Action != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption.Action = requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_GreenFleetProvisioningOption_greenFleetProvisioningOption_Action;
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
            bool requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOptionIsNull = true;
            requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption = new Amazon.CodeDeploy.Model.DeploymentReadyOption();
            Amazon.CodeDeploy.DeploymentReadyAction requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOption_ActionOnTimeout = null;
            if (cmdletContext.BlueGreenDeploymentConfiguration_DeploymentReadyOption_ActionOnTimeout != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOption_ActionOnTimeout = cmdletContext.BlueGreenDeploymentConfiguration_DeploymentReadyOption_ActionOnTimeout;
            }
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOption_ActionOnTimeout != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption.ActionOnTimeout = requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOption_ActionOnTimeout;
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOptionIsNull = false;
            }
            System.Int32? requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOption_WaitTimeInMinute = null;
            if (cmdletContext.BlueGreenDeploymentConfiguration_DeploymentReadyOption_WaitTimeInMinutes != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOption_WaitTimeInMinute = cmdletContext.BlueGreenDeploymentConfiguration_DeploymentReadyOption_WaitTimeInMinutes.Value;
            }
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOption_WaitTimeInMinute != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption.WaitTimeInMinutes = requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_DeploymentReadyOption_deploymentReadyOption_WaitTimeInMinute.Value;
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
            bool requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccessIsNull = true;
            requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess = new Amazon.CodeDeploy.Model.BlueInstanceTerminationOption();
            Amazon.CodeDeploy.InstanceAction requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_terminateBlueInstancesOnDeploymentSuccess_Action = null;
            if (cmdletContext.BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_Action != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_terminateBlueInstancesOnDeploymentSuccess_Action = cmdletContext.BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_Action;
            }
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_terminateBlueInstancesOnDeploymentSuccess_Action != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess.Action = requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_terminateBlueInstancesOnDeploymentSuccess_Action;
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccessIsNull = false;
            }
            System.Int32? requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_terminateBlueInstancesOnDeploymentSuccess_TerminationWaitTimeInMinute = null;
            if (cmdletContext.BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_TerminationWaitTimeInMinutes != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_terminateBlueInstancesOnDeploymentSuccess_TerminationWaitTimeInMinute = cmdletContext.BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_TerminationWaitTimeInMinutes.Value;
            }
            if (requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_terminateBlueInstancesOnDeploymentSuccess_TerminationWaitTimeInMinute != null)
            {
                requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess.TerminationWaitTimeInMinutes = requestBlueGreenDeploymentConfiguration_blueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_terminateBlueInstancesOnDeploymentSuccess_TerminationWaitTimeInMinute.Value;
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
            if (cmdletContext.CurrentDeploymentGroupName != null)
            {
                request.CurrentDeploymentGroupName = cmdletContext.CurrentDeploymentGroupName;
            }
            if (cmdletContext.DeploymentConfigName != null)
            {
                request.DeploymentConfigName = cmdletContext.DeploymentConfigName;
            }
            
             // populate DeploymentStyle
            bool requestDeploymentStyleIsNull = true;
            request.DeploymentStyle = new Amazon.CodeDeploy.Model.DeploymentStyle();
            Amazon.CodeDeploy.DeploymentOption requestDeploymentStyle_deploymentStyle_DeploymentOption = null;
            if (cmdletContext.DeploymentStyle_DeploymentOption != null)
            {
                requestDeploymentStyle_deploymentStyle_DeploymentOption = cmdletContext.DeploymentStyle_DeploymentOption;
            }
            if (requestDeploymentStyle_deploymentStyle_DeploymentOption != null)
            {
                request.DeploymentStyle.DeploymentOption = requestDeploymentStyle_deploymentStyle_DeploymentOption;
                requestDeploymentStyleIsNull = false;
            }
            Amazon.CodeDeploy.DeploymentType requestDeploymentStyle_deploymentStyle_DeploymentType = null;
            if (cmdletContext.DeploymentStyle_DeploymentType != null)
            {
                requestDeploymentStyle_deploymentStyle_DeploymentType = cmdletContext.DeploymentStyle_DeploymentType;
            }
            if (requestDeploymentStyle_deploymentStyle_DeploymentType != null)
            {
                request.DeploymentStyle.DeploymentType = requestDeploymentStyle_deploymentStyle_DeploymentType;
                requestDeploymentStyleIsNull = false;
            }
             // determine if request.DeploymentStyle should be set to null
            if (requestDeploymentStyleIsNull)
            {
                request.DeploymentStyle = null;
            }
            if (cmdletContext.Ec2TagFilters != null)
            {
                request.Ec2TagFilters = cmdletContext.Ec2TagFilters;
            }
            
             // populate LoadBalancerInfo
            bool requestLoadBalancerInfoIsNull = true;
            request.LoadBalancerInfo = new Amazon.CodeDeploy.Model.LoadBalancerInfo();
            List<Amazon.CodeDeploy.Model.ELBInfo> requestLoadBalancerInfo_loadBalancerInfo_ElbInfoList = null;
            if (cmdletContext.LoadBalancerInfo_ElbInfoList != null)
            {
                requestLoadBalancerInfo_loadBalancerInfo_ElbInfoList = cmdletContext.LoadBalancerInfo_ElbInfoList;
            }
            if (requestLoadBalancerInfo_loadBalancerInfo_ElbInfoList != null)
            {
                request.LoadBalancerInfo.ElbInfoList = requestLoadBalancerInfo_loadBalancerInfo_ElbInfoList;
                requestLoadBalancerInfoIsNull = false;
            }
             // determine if request.LoadBalancerInfo should be set to null
            if (requestLoadBalancerInfoIsNull)
            {
                request.LoadBalancerInfo = null;
            }
            if (cmdletContext.NewDeploymentGroupName != null)
            {
                request.NewDeploymentGroupName = cmdletContext.NewDeploymentGroupName;
            }
            if (cmdletContext.OnPremisesInstanceTagFilters != null)
            {
                request.OnPremisesInstanceTagFilters = cmdletContext.OnPremisesInstanceTagFilters;
            }
            if (cmdletContext.ServiceRoleArn != null)
            {
                request.ServiceRoleArn = cmdletContext.ServiceRoleArn;
            }
            if (cmdletContext.TriggerConfigurations != null)
            {
                request.TriggerConfigurations = cmdletContext.TriggerConfigurations;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.HooksNotCleanedUp;
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
        
        private static Amazon.CodeDeploy.Model.UpdateDeploymentGroupResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.UpdateDeploymentGroupRequest request)
        {
            #if DESKTOP
            return client.UpdateDeploymentGroup(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateDeploymentGroupAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.CodeDeploy.Model.Alarm> AlarmConfiguration_Alarms { get; set; }
            public System.Boolean? AlarmConfiguration_Enabled { get; set; }
            public System.Boolean? AlarmConfiguration_IgnorePollAlarmFailure { get; set; }
            public System.String ApplicationName { get; set; }
            public System.Boolean? AutoRollbackConfiguration_Enabled { get; set; }
            public List<System.String> AutoRollbackConfiguration_Events { get; set; }
            public List<System.String> AutoScalingGroups { get; set; }
            public Amazon.CodeDeploy.DeploymentReadyAction BlueGreenDeploymentConfiguration_DeploymentReadyOption_ActionOnTimeout { get; set; }
            public System.Int32? BlueGreenDeploymentConfiguration_DeploymentReadyOption_WaitTimeInMinutes { get; set; }
            public Amazon.CodeDeploy.GreenFleetProvisioningAction BlueGreenDeploymentConfiguration_GreenFleetProvisioningOption_Action { get; set; }
            public Amazon.CodeDeploy.InstanceAction BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_Action { get; set; }
            public System.Int32? BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_TerminationWaitTimeInMinutes { get; set; }
            public System.String CurrentDeploymentGroupName { get; set; }
            public System.String DeploymentConfigName { get; set; }
            public Amazon.CodeDeploy.DeploymentOption DeploymentStyle_DeploymentOption { get; set; }
            public Amazon.CodeDeploy.DeploymentType DeploymentStyle_DeploymentType { get; set; }
            public List<Amazon.CodeDeploy.Model.EC2TagFilter> Ec2TagFilters { get; set; }
            public List<Amazon.CodeDeploy.Model.ELBInfo> LoadBalancerInfo_ElbInfoList { get; set; }
            public System.String NewDeploymentGroupName { get; set; }
            public List<Amazon.CodeDeploy.Model.TagFilter> OnPremisesInstanceTagFilters { get; set; }
            public System.String ServiceRoleArn { get; set; }
            public List<Amazon.CodeDeploy.Model.TriggerConfig> TriggerConfigurations { get; set; }
        }
        
    }
}
