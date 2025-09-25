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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// <b>This operation is used with the Amazon GameLift Servers FleetIQ solution and game
    /// server groups.</b><para>
    /// Creates a Amazon GameLift Servers FleetIQ game server group for managing game hosting
    /// on a collection of Amazon Elastic Compute Cloud instances for game hosting. This operation
    /// creates the game server group, creates an Auto Scaling group in your Amazon Web Services
    /// account, and establishes a link between the two groups. You can view the status of
    /// your game server groups in the Amazon GameLift Servers console. Game server group
    /// metrics and events are emitted to Amazon CloudWatch.
    /// </para><para>
    /// Before creating a new game server group, you must have the following: 
    /// </para><ul><li><para>
    /// An Amazon Elastic Compute Cloud launch template that specifies how to launch Amazon
    /// Elastic Compute Cloud instances with your game server build. For more information,
    /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-launch-templates.html">
    /// Launching an Instance from a Launch Template</a> in the <i>Amazon Elastic Compute
    /// Cloud User Guide</i>. 
    /// </para></li><li><para>
    /// An IAM role that extends limited access to your Amazon Web Services account to allow
    /// Amazon GameLift Servers FleetIQ to create and interact with the Auto Scaling group.
    /// For more information, see <a href="https://docs.aws.amazon.com/gamelift/latest/fleetiqguide/gsg-iam-permissions-roles.html">Create
    /// IAM roles for cross-service interaction</a> in the <i>Amazon GameLift Servers FleetIQ
    /// Developer Guide</i>.
    /// </para></li></ul><para>
    /// To create a new game server group, specify a unique group name, IAM role and Amazon
    /// Elastic Compute Cloud launch template, and provide a list of instance types that can
    /// be used in the group. You must also set initial maximum and minimum limits on the
    /// group's instance count. You can optionally set an Auto Scaling policy with target
    /// tracking based on a Amazon GameLift Servers FleetIQ metric.
    /// </para><para>
    /// Once the game server group and corresponding Auto Scaling group are created, you have
    /// full access to change the Auto Scaling group's configuration as needed. Several properties
    /// that are set when creating a game server group, including maximum/minimum size and
    /// auto-scaling policy settings, must be updated directly in the Auto Scaling group.
    /// Keep in mind that some Auto Scaling group properties are periodically updated by Amazon
    /// GameLift Servers FleetIQ as part of its balancing activities to optimize for availability
    /// and cost.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/fleetiqguide/gsg-intro.html">Amazon
    /// GameLift Servers FleetIQ Guide</a></para>
    /// </summary>
    [Cmdlet("New", "GMLGameServerGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameServerGroup")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreateGameServerGroup API operation.", Operation = new[] {"CreateGameServerGroup"}, SelectReturnType = typeof(Amazon.GameLift.Model.CreateGameServerGroupResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameServerGroup or Amazon.GameLift.Model.CreateGameServerGroupResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GameServerGroup object.",
        "The service call response (type Amazon.GameLift.Model.CreateGameServerGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGMLGameServerGroupCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BalancingStrategy
        /// <summary>
        /// <para>
        /// <para>Indicates how Amazon GameLift Servers FleetIQ balances the use of Spot Instances and
        /// On-Demand Instances in the game server group. Method options include the following:</para><ul><li><para><c>SPOT_ONLY</c> - Only Spot Instances are used in the game server group. If Spot
        /// Instances are unavailable or not viable for game hosting, the game server group provides
        /// no hosting capacity until Spot Instances can again be used. Until then, no new instances
        /// are started, and the existing nonviable Spot Instances are terminated (after current
        /// gameplay ends) and are not replaced.</para></li><li><para><c>SPOT_PREFERRED</c> - (default value) Spot Instances are used whenever available
        /// in the game server group. If Spot Instances are unavailable, the game server group
        /// continues to provide hosting capacity by falling back to On-Demand Instances. Existing
        /// nonviable Spot Instances are terminated (after current gameplay ends) and are replaced
        /// with new On-Demand Instances.</para></li><li><para><c>ON_DEMAND_ONLY</c> - Only On-Demand Instances are used in the game server group.
        /// No Spot Instances are used, even when available, while this balancing strategy is
        /// in force.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.BalancingStrategy")]
        public Amazon.GameLift.BalancingStrategy BalancingStrategy { get; set; }
        #endregion
        
        #region Parameter AutoScalingPolicy_EstimatedInstanceWarmup
        /// <summary>
        /// <para>
        /// <para>Length of time, in seconds, it takes for a new instance to start new game server processes
        /// and register with Amazon GameLift Servers FleetIQ. Specifying a warm-up time can be
        /// useful, particularly with game servers that take a long time to start up, because
        /// it avoids prematurely starting new instances. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AutoScalingPolicy_EstimatedInstanceWarmup { get; set; }
        #endregion
        
        #region Parameter GameServerGroupName
        /// <summary>
        /// <para>
        /// <para>An identifier for the new game server group. This value is used to generate unique
        /// ARN identifiers for the Amazon EC2 Auto Scaling group and the Amazon GameLift Servers
        /// FleetIQ game server group. The name must be unique per Region per Amazon Web Services
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
        public System.String GameServerGroupName { get; set; }
        #endregion
        
        #region Parameter GameServerProtectionPolicy
        /// <summary>
        /// <para>
        /// <para>A flag that indicates whether instances in the game server group are protected from
        /// early termination. Unprotected instances that have active game servers running might
        /// be terminated during a scale-down event, causing players to be dropped from the game.
        /// Protected instances cannot be terminated while there are active game servers running
        /// except in the event of a forced game server group deletion (see ). An exception to
        /// this is with Spot Instances, which can be terminated by Amazon Web Services regardless
        /// of protection status. This property is set to <c>NO_PROTECTION</c> by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.GameServerProtectionPolicy")]
        public Amazon.GameLift.GameServerProtectionPolicy GameServerProtectionPolicy { get; set; }
        #endregion
        
        #region Parameter InstanceDefinition
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 instance types and sizes to use in the Auto Scaling group. The instance
        /// definitions must specify at least two different instance types that are supported
        /// by Amazon GameLift Servers FleetIQ. For more information on instance types, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">EC2
        /// Instance Types</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>. You can
        /// optionally specify capacity weighting for each instance type. If no weight value is
        /// specified for an instance type, it is set to the default value "1". For more information
        /// about capacity weighting, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-instance-weighting.html">
        /// Instance Weighting for Amazon EC2 Auto Scaling</a> in the Amazon EC2 Auto Scaling
        /// User Guide.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("InstanceDefinitions")]
        public Amazon.GameLift.Model.InstanceDefinition[] InstanceDefinition { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for an existing Amazon EC2 launch template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_LaunchTemplateId { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateName
        /// <summary>
        /// <para>
        /// <para>A readable identifier for an existing Amazon EC2 launch template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_LaunchTemplateName { get; set; }
        #endregion
        
        #region Parameter MaxSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of instances allowed in the Amazon EC2 Auto Scaling group. During
        /// automatic scaling events, Amazon GameLift Servers FleetIQ and EC2 do not scale up
        /// the group above this maximum. After the Auto Scaling group is created, update this
        /// value directly in the Auto Scaling group using the Amazon Web Services console or
        /// APIs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? MaxSize { get; set; }
        #endregion
        
        #region Parameter MinSize
        /// <summary>
        /// <para>
        /// <para>The minimum number of instances allowed in the Amazon EC2 Auto Scaling group. During
        /// automatic scaling events, Amazon GameLift Servers FleetIQ and Amazon EC2 do not scale
        /// down the group below this minimum. In production, this value should be set to at least
        /// 1. After the Auto Scaling group is created, update this value directly in the Auto
        /// Scaling group using the Amazon Web Services console or APIs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? MinSize { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (<a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/s3-arn-format.html">ARN</a>)
        /// for an IAM role that allows Amazon GameLift Servers to access your Amazon EC2 Auto
        /// Scaling groups.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of labels to assign to the new game server group resource. Tags are developer-defined
        /// key-value pairs. Tagging Amazon Web Services resources is useful for resource management,
        /// access management, and cost allocation. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">
        /// Tagging Amazon Web Services Resources</a> in the <i>Amazon Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.GameLift.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetTrackingConfiguration_TargetValue
        /// <summary>
        /// <para>
        /// <para>Desired value to use with a game server group target-based scaling policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingPolicy_TargetTrackingConfiguration_TargetValue")]
        public System.Double? TargetTrackingConfiguration_TargetValue { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The version of the Amazon EC2 launch template to use. If no version is specified,
        /// the default version will be used. With Amazon EC2, you can specify a default version
        /// for a launch template. If none is set, the default is the first version created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_Version { get; set; }
        #endregion
        
        #region Parameter VpcSubnet
        /// <summary>
        /// <para>
        /// <para>A list of virtual private cloud (VPC) subnets to use with instances in the game server
        /// group. By default, all Amazon GameLift Servers FleetIQ-supported Availability Zones
        /// are used. You can use this parameter to specify VPCs that you've set up. This property
        /// cannot be updated after the game server group is created, and the corresponding Auto
        /// Scaling group will always use the property value that is set with this request, even
        /// if the Auto Scaling group is updated directly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSubnets")]
        public System.String[] VpcSubnet { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GameServerGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.CreateGameServerGroupResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.CreateGameServerGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GameServerGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GameServerGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GameServerGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GameServerGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GameServerGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLGameServerGroup (CreateGameServerGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.CreateGameServerGroupResponse, NewGMLGameServerGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GameServerGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoScalingPolicy_EstimatedInstanceWarmup = this.AutoScalingPolicy_EstimatedInstanceWarmup;
            context.TargetTrackingConfiguration_TargetValue = this.TargetTrackingConfiguration_TargetValue;
            context.BalancingStrategy = this.BalancingStrategy;
            context.GameServerGroupName = this.GameServerGroupName;
            #if MODULAR
            if (this.GameServerGroupName == null && ParameterWasBound(nameof(this.GameServerGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter GameServerGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GameServerProtectionPolicy = this.GameServerProtectionPolicy;
            if (this.InstanceDefinition != null)
            {
                context.InstanceDefinition = new List<Amazon.GameLift.Model.InstanceDefinition>(this.InstanceDefinition);
            }
            #if MODULAR
            if (this.InstanceDefinition == null && ParameterWasBound(nameof(this.InstanceDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LaunchTemplate_LaunchTemplateId = this.LaunchTemplate_LaunchTemplateId;
            context.LaunchTemplate_LaunchTemplateName = this.LaunchTemplate_LaunchTemplateName;
            context.LaunchTemplate_Version = this.LaunchTemplate_Version;
            context.MaxSize = this.MaxSize;
            #if MODULAR
            if (this.MaxSize == null && ParameterWasBound(nameof(this.MaxSize)))
            {
                WriteWarning("You are passing $null as a value for parameter MaxSize which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinSize = this.MinSize;
            #if MODULAR
            if (this.MinSize == null && ParameterWasBound(nameof(this.MinSize)))
            {
                WriteWarning("You are passing $null as a value for parameter MinSize which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.GameLift.Model.Tag>(this.Tag);
            }
            if (this.VpcSubnet != null)
            {
                context.VpcSubnet = new List<System.String>(this.VpcSubnet);
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
            var request = new Amazon.GameLift.Model.CreateGameServerGroupRequest();
            
            
             // populate AutoScalingPolicy
            var requestAutoScalingPolicyIsNull = true;
            request.AutoScalingPolicy = new Amazon.GameLift.Model.GameServerGroupAutoScalingPolicy();
            System.Int32? requestAutoScalingPolicy_autoScalingPolicy_EstimatedInstanceWarmup = null;
            if (cmdletContext.AutoScalingPolicy_EstimatedInstanceWarmup != null)
            {
                requestAutoScalingPolicy_autoScalingPolicy_EstimatedInstanceWarmup = cmdletContext.AutoScalingPolicy_EstimatedInstanceWarmup.Value;
            }
            if (requestAutoScalingPolicy_autoScalingPolicy_EstimatedInstanceWarmup != null)
            {
                request.AutoScalingPolicy.EstimatedInstanceWarmup = requestAutoScalingPolicy_autoScalingPolicy_EstimatedInstanceWarmup.Value;
                requestAutoScalingPolicyIsNull = false;
            }
            Amazon.GameLift.Model.TargetTrackingConfiguration requestAutoScalingPolicy_autoScalingPolicy_TargetTrackingConfiguration = null;
            
             // populate TargetTrackingConfiguration
            var requestAutoScalingPolicy_autoScalingPolicy_TargetTrackingConfigurationIsNull = true;
            requestAutoScalingPolicy_autoScalingPolicy_TargetTrackingConfiguration = new Amazon.GameLift.Model.TargetTrackingConfiguration();
            System.Double? requestAutoScalingPolicy_autoScalingPolicy_TargetTrackingConfiguration_targetTrackingConfiguration_TargetValue = null;
            if (cmdletContext.TargetTrackingConfiguration_TargetValue != null)
            {
                requestAutoScalingPolicy_autoScalingPolicy_TargetTrackingConfiguration_targetTrackingConfiguration_TargetValue = cmdletContext.TargetTrackingConfiguration_TargetValue.Value;
            }
            if (requestAutoScalingPolicy_autoScalingPolicy_TargetTrackingConfiguration_targetTrackingConfiguration_TargetValue != null)
            {
                requestAutoScalingPolicy_autoScalingPolicy_TargetTrackingConfiguration.TargetValue = requestAutoScalingPolicy_autoScalingPolicy_TargetTrackingConfiguration_targetTrackingConfiguration_TargetValue.Value;
                requestAutoScalingPolicy_autoScalingPolicy_TargetTrackingConfigurationIsNull = false;
            }
             // determine if requestAutoScalingPolicy_autoScalingPolicy_TargetTrackingConfiguration should be set to null
            if (requestAutoScalingPolicy_autoScalingPolicy_TargetTrackingConfigurationIsNull)
            {
                requestAutoScalingPolicy_autoScalingPolicy_TargetTrackingConfiguration = null;
            }
            if (requestAutoScalingPolicy_autoScalingPolicy_TargetTrackingConfiguration != null)
            {
                request.AutoScalingPolicy.TargetTrackingConfiguration = requestAutoScalingPolicy_autoScalingPolicy_TargetTrackingConfiguration;
                requestAutoScalingPolicyIsNull = false;
            }
             // determine if request.AutoScalingPolicy should be set to null
            if (requestAutoScalingPolicyIsNull)
            {
                request.AutoScalingPolicy = null;
            }
            if (cmdletContext.BalancingStrategy != null)
            {
                request.BalancingStrategy = cmdletContext.BalancingStrategy;
            }
            if (cmdletContext.GameServerGroupName != null)
            {
                request.GameServerGroupName = cmdletContext.GameServerGroupName;
            }
            if (cmdletContext.GameServerProtectionPolicy != null)
            {
                request.GameServerProtectionPolicy = cmdletContext.GameServerProtectionPolicy;
            }
            if (cmdletContext.InstanceDefinition != null)
            {
                request.InstanceDefinitions = cmdletContext.InstanceDefinition;
            }
            
             // populate LaunchTemplate
            var requestLaunchTemplateIsNull = true;
            request.LaunchTemplate = new Amazon.GameLift.Model.LaunchTemplateSpecification();
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
            if (cmdletContext.MaxSize != null)
            {
                request.MaxSize = cmdletContext.MaxSize.Value;
            }
            if (cmdletContext.MinSize != null)
            {
                request.MinSize = cmdletContext.MinSize.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VpcSubnet != null)
            {
                request.VpcSubnets = cmdletContext.VpcSubnet;
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
        
        private Amazon.GameLift.Model.CreateGameServerGroupResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateGameServerGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "CreateGameServerGroup");
            try
            {
                #if DESKTOP
                return client.CreateGameServerGroup(request);
                #elif CORECLR
                return client.CreateGameServerGroupAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? AutoScalingPolicy_EstimatedInstanceWarmup { get; set; }
            public System.Double? TargetTrackingConfiguration_TargetValue { get; set; }
            public Amazon.GameLift.BalancingStrategy BalancingStrategy { get; set; }
            public System.String GameServerGroupName { get; set; }
            public Amazon.GameLift.GameServerProtectionPolicy GameServerProtectionPolicy { get; set; }
            public List<Amazon.GameLift.Model.InstanceDefinition> InstanceDefinition { get; set; }
            public System.String LaunchTemplate_LaunchTemplateId { get; set; }
            public System.String LaunchTemplate_LaunchTemplateName { get; set; }
            public System.String LaunchTemplate_Version { get; set; }
            public System.Int32? MaxSize { get; set; }
            public System.Int32? MinSize { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.GameLift.Model.Tag> Tag { get; set; }
            public List<System.String> VpcSubnet { get; set; }
            public System.Func<Amazon.GameLift.Model.CreateGameServerGroupResponse, NewGMLGameServerGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameServerGroup;
        }
        
    }
}
