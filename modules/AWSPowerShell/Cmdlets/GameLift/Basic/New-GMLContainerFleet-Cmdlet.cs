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
using Amazon.GameLift;
using Amazon.GameLift.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Creates a managed fleet of Amazon Elastic Compute Cloud (Amazon EC2) instances to
    /// host your containerized game servers. Use this operation to define how to deploy a
    /// container architecture onto each fleet instance and configure fleet settings. You
    /// can create a container fleet in any Amazon Web Services Regions that Amazon GameLift
    /// Servers supports for multi-location fleets. A container fleet can be deployed to a
    /// single location or multiple locations. Container fleets are deployed with Amazon Linux
    /// 2023 as the instance operating system.
    /// 
    ///  
    /// <para>
    /// Define the fleet's container architecture using container group definitions. Each
    /// fleet can have one of the following container group types:
    /// </para><ul><li><para>
    /// The game server container group runs your game server build and dependent software.
    /// Amazon GameLift Servers deploys one or more replicas of this container group to each
    /// fleet instance. The number of replicas depends on the computing capabilities of the
    /// fleet instance in use. 
    /// </para></li><li><para>
    /// An optional per-instance container group might be used to run other software that
    /// only needs to run once per instance, such as background services, logging, or test
    /// processes. One per-instance container group is deployed to each fleet instance. 
    /// </para></li></ul><para>
    /// Each container group can include the definition for one or more containers. A container
    /// definition specifies a container image that is stored in an Amazon Elastic Container
    /// Registry (Amazon ECR) public or private repository.
    /// </para><para><b>Request options</b></para><para>
    /// Use this operation to make the following types of requests. Most fleet settings have
    /// default values, so you can create a working fleet with a minimal configuration and
    /// default values, which you can customize later.
    /// </para><ul><li><para>
    /// Create a fleet with no container groups. You can configure a container fleet and then
    /// add container group definitions later. In this scenario, no fleet instances are deployed,
    /// and the fleet can't host game sessions until you add a game server container group
    /// definition. Provide the following required parameter values:
    /// </para><ul><li><para><c>FleetRoleArn</c></para></li></ul></li><li><para>
    /// Create a fleet with a game server container group. Provide the following required
    /// parameter values:
    /// </para><ul><li><para><c>FleetRoleArn</c></para></li><li><para><c>GameServerContainerGroupDefinitionName</c></para></li></ul></li><li><para>
    /// Create a fleet with a game server container group and a per-instance container group.
    /// Provide the following required parameter values:
    /// </para><ul><li><para><c>FleetRoleArn</c></para></li><li><para><c>GameServerContainerGroupDefinitionName</c></para></li><li><para><c>PerInstanceContainerGroupDefinitionName</c></para></li></ul></li></ul><para><b>Results</b></para><para>
    /// If successful, this operation creates a new container fleet resource, places it in
    /// <c>PENDING</c> status, and initiates the <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-creating-all.html#fleets-creation-workflow">fleet
    /// creation workflow</a>. For fleets with container groups, this workflow starts a fleet
    /// deployment and transitions the status to <c>ACTIVE</c>. Fleets without a container
    /// group are placed in <c>CREATED</c> status.
    /// </para><para>
    /// You can update most of the properties of a fleet, including container group definitions,
    /// and deploy the update across all fleet instances. Use a fleet update to deploy a new
    /// game server version update across the container fleet. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "GMLContainerFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.ContainerFleet")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreateContainerFleet API operation.", Operation = new[] {"CreateContainerFleet"}, SelectReturnType = typeof(Amazon.GameLift.Model.CreateContainerFleetResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.ContainerFleet or Amazon.GameLift.Model.CreateContainerFleetResponse",
        "This cmdlet returns an Amazon.GameLift.Model.ContainerFleet object.",
        "The service call response (type Amazon.GameLift.Model.CreateContainerFleetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGMLContainerFleetCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BillingType
        /// <summary>
        /// <para>
        /// <para>Indicates whether to use On-Demand or Spot instances for this fleet. Learn more about
        /// when to use <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-ec2-instances.html#gamelift-ec2-instances-spot">
        /// On-Demand versus Spot Instances</a>. This fleet property can't be changed after the
        /// fleet is created.</para><para>By default, this property is set to <c>ON_DEMAND</c>.</para><para>You can't update this fleet property later.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.ContainerFleetBillingType")]
        public Amazon.GameLift.ContainerFleetBillingType BillingType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A meaningful description of the container fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FleetRoleArn
        /// <summary>
        /// <para>
        /// <para>The unique identifier for an Identity and Access Management (IAM) role with permissions
        /// to run your containers on resources that are managed by Amazon GameLift Servers. Use
        /// an IAM service role with the <c>GameLiftContainerFleetPolicy</c> managed policy attached.
        /// For more information, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/setting-up-role.html">Set
        /// up an IAM service role</a>. You can't change this fleet property after the fleet is
        /// created.</para><para>IAM role ARN values use the following pattern: <c>arn:aws:iam::[Amazon Web Services
        /// account]:role/[role name]</c>.</para>
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
        public System.String FleetRoleArn { get; set; }
        #endregion
        
        #region Parameter InstanceConnectionPortRange_FromPort
        /// <summary>
        /// <para>
        /// <para>Starting value for the port range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceConnectionPortRange_FromPort { get; set; }
        #endregion
        
        #region Parameter GameServerContainerGroupDefinitionName
        /// <summary>
        /// <para>
        /// <para>A container group definition resource that describes how to deploy containers with
        /// your game server build and support software onto each fleet instance. You can specify
        /// the container group definition's name to use the latest version. Alternatively, provide
        /// an ARN value with a specific version number.</para><para>Create a container group definition by calling <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_CreateContainerGroupDefinition.html">CreateContainerGroupDefinition</a>.
        /// This operation creates a <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_ContainerGroupDefinition.html">ContainerGroupDefinition</a>
        /// resource. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameServerContainerGroupDefinitionName { get; set; }
        #endregion
        
        #region Parameter GameServerContainerGroupsPerInstance
        /// <summary>
        /// <para>
        /// <para>The number of times to replicate the game server container group on each fleet instance.
        /// </para><para>By default, Amazon GameLift Servers calculates the maximum number of game server container
        /// groups that can fit on each instance. This calculation is based on the CPU and memory
        /// resources of the fleet's instance type). To use the calculated maximum, don't set
        /// this parameter. If you set this number manually, Amazon GameLift Servers uses your
        /// value as long as it's less than the calculated maximum.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? GameServerContainerGroupsPerInstance { get; set; }
        #endregion
        
        #region Parameter InstanceInboundPermission
        /// <summary>
        /// <para>
        /// <para>The IP address ranges and port settings that allow inbound traffic to access game
        /// server processes and other processes on this fleet. As a best practice, when remotely
        /// accessing a fleet instance, we recommend opening ports only when you need them and
        /// closing them when you're finished.</para><para>By default, Amazon GameLift Servers calculates an optimal port range based on your
        /// fleet configuration. To use the calculated range, don't set this parameter. The values
        /// are:</para><ul><li><para>Protocol: UDP</para></li><li><para>Port range: 4192 to a number calculated based on your fleet configuration. Amazon
        /// GameLift Servers uses the following formula: <c>4192 + [# of game server container
        /// groups per fleet instance] * [# of container ports in the game server container group
        /// definition] + [# of container ports in the game server container group definition]</c></para></li></ul><para>You can also choose to manually set this parameter. When manually setting this parameter,
        /// you must use port numbers that match the fleet's connection port range.</para><note><para>If you set values manually, Amazon GameLift Servers no longer calculates a port range
        /// for you, even if you later remove the manual settings. </para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceInboundPermissions")]
        public Amazon.GameLift.Model.IpPermission[] InstanceInboundPermission { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 instance type to use for all instances in the fleet. For multi-location
        /// fleets, the instance type must be available in the home region and all remote locations.
        /// Instance type determines the computing resources and processing power that's available
        /// to host your game servers. This includes including CPU, memory, storage, and networking
        /// capacity. </para><para>By default, Amazon GameLift Servers selects an instance type that fits the needs of
        /// your container groups and is available in all selected fleet locations. You can also
        /// choose to manually set this parameter. See <a href="http://aws.amazon.com/ec2/instance-types/">Amazon
        /// Elastic Compute Cloud Instance Types</a> for detailed descriptions of Amazon EC2 instance
        /// types.</para><para>You can't update this fleet property later.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <para>A set of locations to deploy container fleet instances to. You can add any Amazon
        /// Web Services Region or Local Zone that's supported by Amazon GameLift Servers. Provide
        /// a list of one or more Amazon Web Services Region codes, such as <c>us-west-2</c>,
        /// or Local Zone names. Also include the fleet's home Region, which is the Amazon Web
        /// Services Region where the fleet is created. For a list of supported Regions and Local
        /// Zones, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-regions.html">
        /// Amazon GameLift Servers service locations</a> for managed hosting.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Locations")]
        public Amazon.GameLift.Model.LocationConfiguration[] Location { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_LogDestination
        /// <summary>
        /// <para>
        /// <para>The type of log collection to use for a fleet.</para><ul><li><para><c>CLOUDWATCH</c> -- (default value) Send logs to an Amazon CloudWatch log group
        /// that you define. Each container emits a log stream, which is organized in the log
        /// group. </para></li><li><para><c>S3</c> -- Store logs in an Amazon S3 bucket that you define. This bucket must
        /// reside in the fleet's home Amazon Web Services Region.</para></li><li><para><c>NONE</c> -- Don't collect container logs.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.LogDestination")]
        public Amazon.GameLift.LogDestination LogConfiguration_LogDestination { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_LogGroupArn
        /// <summary>
        /// <para>
        /// <para>If log destination is <c>CLOUDWATCH</c>, logs are sent to the specified log group
        /// in Amazon CloudWatch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogConfiguration_LogGroupArn { get; set; }
        #endregion
        
        #region Parameter MetricGroup
        /// <summary>
        /// <para>
        /// <para>The name of an Amazon Web Services CloudWatch metric group to add this fleet to. You
        /// can use a metric group to aggregate metrics for multiple fleets. You can specify an
        /// existing metric group name or use a new name to create a new metric group. Each fleet
        /// can have only one metric group, but you can change this value at any time. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricGroups")]
        public System.String[] MetricGroup { get; set; }
        #endregion
        
        #region Parameter NewGameSessionProtectionPolicy
        /// <summary>
        /// <para>
        /// <para>Determines whether Amazon GameLift Servers can shut down game sessions on the fleet
        /// that are actively running and hosting players. Amazon GameLift Servers might prompt
        /// an instance shutdown when scaling down fleet capacity or when retiring unhealthy instances.
        /// You can also set game session protection for individual game sessions using <a href="gamelift/latest/apireference/API_UpdateGameSession.html">UpdateGameSession</a>.</para><ul><li><para><b>NoProtection</b> -- Game sessions can be shut down during active gameplay. </para></li><li><para><b>FullProtection</b> -- Game sessions in <c>ACTIVE</c> status can't be shut down.</para></li></ul><para>By default, this property is set to <c>NoProtection</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.ProtectionPolicy")]
        public Amazon.GameLift.ProtectionPolicy NewGameSessionProtectionPolicy { get; set; }
        #endregion
        
        #region Parameter GameSessionCreationLimitPolicy_NewGameSessionsPerCreator
        /// <summary>
        /// <para>
        /// <para>A policy that puts limits on the number of game sessions that a player can create
        /// within a specified span of time. With this policy, you can control players' ability
        /// to consume available resources.</para><para>The policy evaluates when a player tries to create a new game session. On receiving
        /// a <c>CreateGameSession</c> request, Amazon GameLift Servers checks that the player
        /// (identified by <c>CreatorId</c>) has created fewer than game session limit in the
        /// specified time period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? GameSessionCreationLimitPolicy_NewGameSessionsPerCreator { get; set; }
        #endregion
        
        #region Parameter PerInstanceContainerGroupDefinitionName
        /// <summary>
        /// <para>
        /// <para>The name of a container group definition resource that describes a set of axillary
        /// software. A fleet instance has one process for executables in this container group.
        /// A per-instance container group is optional. You can update the fleet to add or remove
        /// a per-instance container group at any time. You can specify the container group definition's
        /// name to use the latest version. Alternatively, provide an ARN value with a specific
        /// version number. </para><para>Create a container group definition by calling <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_CreateContainerGroupDefinition.html">https://docs.aws.amazon.com/gamelift/latest/apireference/API_CreateContainerGroupDefinition.html</a>.
        /// This operation creates a <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_ContainerGroupDefinition.html">https://docs.aws.amazon.com/gamelift/latest/apireference/API_ContainerGroupDefinition.html</a>
        /// resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerInstanceContainerGroupDefinitionName { get; set; }
        #endregion
        
        #region Parameter GameSessionCreationLimitPolicy_PolicyPeriodInMinute
        /// <summary>
        /// <para>
        /// <para>The time span used in evaluating the resource creation limit policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GameSessionCreationLimitPolicy_PolicyPeriodInMinutes")]
        public System.Int32? GameSessionCreationLimitPolicy_PolicyPeriodInMinute { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_S3BucketName
        /// <summary>
        /// <para>
        /// <para>If log destination is <c>S3</c>, logs are sent to the specified Amazon S3 bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogConfiguration_S3BucketName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of labels to assign to the new fleet resource. Tags are developer-defined key-value
        /// pairs. Tagging Amazon Web Services resources are useful for resource management, access
        /// management and cost allocation. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">
        /// Tagging Amazon Web Services Resources</a> in the <i>Amazon Web Services General Reference</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.GameLift.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter InstanceConnectionPortRange_ToPort
        /// <summary>
        /// <para>
        /// <para>Ending value for the port. Port numbers are end-inclusive. This value must be equal
        /// to or greater than <c>FromPort</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceConnectionPortRange_ToPort { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContainerFleet'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.CreateContainerFleetResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.CreateContainerFleetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContainerFleet";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FleetRoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLContainerFleet (CreateContainerFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.CreateContainerFleetResponse, NewGMLContainerFleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BillingType = this.BillingType;
            context.Description = this.Description;
            context.FleetRoleArn = this.FleetRoleArn;
            #if MODULAR
            if (this.FleetRoleArn == null && ParameterWasBound(nameof(this.FleetRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GameServerContainerGroupDefinitionName = this.GameServerContainerGroupDefinitionName;
            context.GameServerContainerGroupsPerInstance = this.GameServerContainerGroupsPerInstance;
            context.GameSessionCreationLimitPolicy_NewGameSessionsPerCreator = this.GameSessionCreationLimitPolicy_NewGameSessionsPerCreator;
            context.GameSessionCreationLimitPolicy_PolicyPeriodInMinute = this.GameSessionCreationLimitPolicy_PolicyPeriodInMinute;
            context.InstanceConnectionPortRange_FromPort = this.InstanceConnectionPortRange_FromPort;
            context.InstanceConnectionPortRange_ToPort = this.InstanceConnectionPortRange_ToPort;
            if (this.InstanceInboundPermission != null)
            {
                context.InstanceInboundPermission = new List<Amazon.GameLift.Model.IpPermission>(this.InstanceInboundPermission);
            }
            context.InstanceType = this.InstanceType;
            if (this.Location != null)
            {
                context.Location = new List<Amazon.GameLift.Model.LocationConfiguration>(this.Location);
            }
            context.LogConfiguration_LogDestination = this.LogConfiguration_LogDestination;
            context.LogConfiguration_LogGroupArn = this.LogConfiguration_LogGroupArn;
            context.LogConfiguration_S3BucketName = this.LogConfiguration_S3BucketName;
            if (this.MetricGroup != null)
            {
                context.MetricGroup = new List<System.String>(this.MetricGroup);
            }
            context.NewGameSessionProtectionPolicy = this.NewGameSessionProtectionPolicy;
            context.PerInstanceContainerGroupDefinitionName = this.PerInstanceContainerGroupDefinitionName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.GameLift.Model.Tag>(this.Tag);
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
            var request = new Amazon.GameLift.Model.CreateContainerFleetRequest();
            
            if (cmdletContext.BillingType != null)
            {
                request.BillingType = cmdletContext.BillingType;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FleetRoleArn != null)
            {
                request.FleetRoleArn = cmdletContext.FleetRoleArn;
            }
            if (cmdletContext.GameServerContainerGroupDefinitionName != null)
            {
                request.GameServerContainerGroupDefinitionName = cmdletContext.GameServerContainerGroupDefinitionName;
            }
            if (cmdletContext.GameServerContainerGroupsPerInstance != null)
            {
                request.GameServerContainerGroupsPerInstance = cmdletContext.GameServerContainerGroupsPerInstance.Value;
            }
            
             // populate GameSessionCreationLimitPolicy
            var requestGameSessionCreationLimitPolicyIsNull = true;
            request.GameSessionCreationLimitPolicy = new Amazon.GameLift.Model.GameSessionCreationLimitPolicy();
            System.Int32? requestGameSessionCreationLimitPolicy_gameSessionCreationLimitPolicy_NewGameSessionsPerCreator = null;
            if (cmdletContext.GameSessionCreationLimitPolicy_NewGameSessionsPerCreator != null)
            {
                requestGameSessionCreationLimitPolicy_gameSessionCreationLimitPolicy_NewGameSessionsPerCreator = cmdletContext.GameSessionCreationLimitPolicy_NewGameSessionsPerCreator.Value;
            }
            if (requestGameSessionCreationLimitPolicy_gameSessionCreationLimitPolicy_NewGameSessionsPerCreator != null)
            {
                request.GameSessionCreationLimitPolicy.NewGameSessionsPerCreator = requestGameSessionCreationLimitPolicy_gameSessionCreationLimitPolicy_NewGameSessionsPerCreator.Value;
                requestGameSessionCreationLimitPolicyIsNull = false;
            }
            System.Int32? requestGameSessionCreationLimitPolicy_gameSessionCreationLimitPolicy_PolicyPeriodInMinute = null;
            if (cmdletContext.GameSessionCreationLimitPolicy_PolicyPeriodInMinute != null)
            {
                requestGameSessionCreationLimitPolicy_gameSessionCreationLimitPolicy_PolicyPeriodInMinute = cmdletContext.GameSessionCreationLimitPolicy_PolicyPeriodInMinute.Value;
            }
            if (requestGameSessionCreationLimitPolicy_gameSessionCreationLimitPolicy_PolicyPeriodInMinute != null)
            {
                request.GameSessionCreationLimitPolicy.PolicyPeriodInMinutes = requestGameSessionCreationLimitPolicy_gameSessionCreationLimitPolicy_PolicyPeriodInMinute.Value;
                requestGameSessionCreationLimitPolicyIsNull = false;
            }
             // determine if request.GameSessionCreationLimitPolicy should be set to null
            if (requestGameSessionCreationLimitPolicyIsNull)
            {
                request.GameSessionCreationLimitPolicy = null;
            }
            
             // populate InstanceConnectionPortRange
            var requestInstanceConnectionPortRangeIsNull = true;
            request.InstanceConnectionPortRange = new Amazon.GameLift.Model.ConnectionPortRange();
            System.Int32? requestInstanceConnectionPortRange_instanceConnectionPortRange_FromPort = null;
            if (cmdletContext.InstanceConnectionPortRange_FromPort != null)
            {
                requestInstanceConnectionPortRange_instanceConnectionPortRange_FromPort = cmdletContext.InstanceConnectionPortRange_FromPort.Value;
            }
            if (requestInstanceConnectionPortRange_instanceConnectionPortRange_FromPort != null)
            {
                request.InstanceConnectionPortRange.FromPort = requestInstanceConnectionPortRange_instanceConnectionPortRange_FromPort.Value;
                requestInstanceConnectionPortRangeIsNull = false;
            }
            System.Int32? requestInstanceConnectionPortRange_instanceConnectionPortRange_ToPort = null;
            if (cmdletContext.InstanceConnectionPortRange_ToPort != null)
            {
                requestInstanceConnectionPortRange_instanceConnectionPortRange_ToPort = cmdletContext.InstanceConnectionPortRange_ToPort.Value;
            }
            if (requestInstanceConnectionPortRange_instanceConnectionPortRange_ToPort != null)
            {
                request.InstanceConnectionPortRange.ToPort = requestInstanceConnectionPortRange_instanceConnectionPortRange_ToPort.Value;
                requestInstanceConnectionPortRangeIsNull = false;
            }
             // determine if request.InstanceConnectionPortRange should be set to null
            if (requestInstanceConnectionPortRangeIsNull)
            {
                request.InstanceConnectionPortRange = null;
            }
            if (cmdletContext.InstanceInboundPermission != null)
            {
                request.InstanceInboundPermissions = cmdletContext.InstanceInboundPermission;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.Location != null)
            {
                request.Locations = cmdletContext.Location;
            }
            
             // populate LogConfiguration
            var requestLogConfigurationIsNull = true;
            request.LogConfiguration = new Amazon.GameLift.Model.LogConfiguration();
            Amazon.GameLift.LogDestination requestLogConfiguration_logConfiguration_LogDestination = null;
            if (cmdletContext.LogConfiguration_LogDestination != null)
            {
                requestLogConfiguration_logConfiguration_LogDestination = cmdletContext.LogConfiguration_LogDestination;
            }
            if (requestLogConfiguration_logConfiguration_LogDestination != null)
            {
                request.LogConfiguration.LogDestination = requestLogConfiguration_logConfiguration_LogDestination;
                requestLogConfigurationIsNull = false;
            }
            System.String requestLogConfiguration_logConfiguration_LogGroupArn = null;
            if (cmdletContext.LogConfiguration_LogGroupArn != null)
            {
                requestLogConfiguration_logConfiguration_LogGroupArn = cmdletContext.LogConfiguration_LogGroupArn;
            }
            if (requestLogConfiguration_logConfiguration_LogGroupArn != null)
            {
                request.LogConfiguration.LogGroupArn = requestLogConfiguration_logConfiguration_LogGroupArn;
                requestLogConfigurationIsNull = false;
            }
            System.String requestLogConfiguration_logConfiguration_S3BucketName = null;
            if (cmdletContext.LogConfiguration_S3BucketName != null)
            {
                requestLogConfiguration_logConfiguration_S3BucketName = cmdletContext.LogConfiguration_S3BucketName;
            }
            if (requestLogConfiguration_logConfiguration_S3BucketName != null)
            {
                request.LogConfiguration.S3BucketName = requestLogConfiguration_logConfiguration_S3BucketName;
                requestLogConfigurationIsNull = false;
            }
             // determine if request.LogConfiguration should be set to null
            if (requestLogConfigurationIsNull)
            {
                request.LogConfiguration = null;
            }
            if (cmdletContext.MetricGroup != null)
            {
                request.MetricGroups = cmdletContext.MetricGroup;
            }
            if (cmdletContext.NewGameSessionProtectionPolicy != null)
            {
                request.NewGameSessionProtectionPolicy = cmdletContext.NewGameSessionProtectionPolicy;
            }
            if (cmdletContext.PerInstanceContainerGroupDefinitionName != null)
            {
                request.PerInstanceContainerGroupDefinitionName = cmdletContext.PerInstanceContainerGroupDefinitionName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.GameLift.Model.CreateContainerFleetResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateContainerFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "CreateContainerFleet");
            try
            {
                return client.CreateContainerFleetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.GameLift.ContainerFleetBillingType BillingType { get; set; }
            public System.String Description { get; set; }
            public System.String FleetRoleArn { get; set; }
            public System.String GameServerContainerGroupDefinitionName { get; set; }
            public System.Int32? GameServerContainerGroupsPerInstance { get; set; }
            public System.Int32? GameSessionCreationLimitPolicy_NewGameSessionsPerCreator { get; set; }
            public System.Int32? GameSessionCreationLimitPolicy_PolicyPeriodInMinute { get; set; }
            public System.Int32? InstanceConnectionPortRange_FromPort { get; set; }
            public System.Int32? InstanceConnectionPortRange_ToPort { get; set; }
            public List<Amazon.GameLift.Model.IpPermission> InstanceInboundPermission { get; set; }
            public System.String InstanceType { get; set; }
            public List<Amazon.GameLift.Model.LocationConfiguration> Location { get; set; }
            public Amazon.GameLift.LogDestination LogConfiguration_LogDestination { get; set; }
            public System.String LogConfiguration_LogGroupArn { get; set; }
            public System.String LogConfiguration_S3BucketName { get; set; }
            public List<System.String> MetricGroup { get; set; }
            public Amazon.GameLift.ProtectionPolicy NewGameSessionProtectionPolicy { get; set; }
            public System.String PerInstanceContainerGroupDefinitionName { get; set; }
            public List<Amazon.GameLift.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.GameLift.Model.CreateContainerFleetResponse, NewGMLContainerFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContainerFleet;
        }
        
    }
}
