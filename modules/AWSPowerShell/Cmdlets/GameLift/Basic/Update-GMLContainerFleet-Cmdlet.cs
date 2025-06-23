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
    /// Updates the properties of a managed container fleet. Depending on the properties being
    /// updated, this operation might initiate a fleet deployment. You can track deployments
    /// for a fleet using <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_DescribeFleetDeployment.html">https://docs.aws.amazon.com/gamelift/latest/apireference/API_DescribeFleetDeployment.html</a>.
    /// 
    ///  
    /// <para><b>Request options</b></para><para>
    /// As with CreateContainerFleet, many fleet properties use common defaults or are calculated
    /// based on the fleet's container group definitions. 
    /// </para><ul><li><para>
    /// Update fleet properties that result in a fleet deployment. Include only those properties
    /// that you want to change. Specify deployment configuration settings.
    /// </para></li><li><para>
    /// Update fleet properties that don't result in a fleet deployment. Include only those
    /// properties that you want to change.
    /// </para></li></ul><para>
    /// Changes to the following properties initiate a fleet deployment: 
    /// </para><ul><li><para><c>GameServerContainerGroupDefinition</c></para></li><li><para><c>PerInstanceContainerGroupDefinition</c></para></li><li><para><c>GameServerContainerGroupsPerInstance</c></para></li><li><para><c>InstanceInboundPermissions</c></para></li><li><para><c>InstanceConnectionPortRange</c></para></li><li><para><c>LogConfiguration</c></para></li></ul><para><b>Results</b></para><para>
    /// If successful, this operation updates the container fleet resource, and might initiate
    /// a new deployment of fleet resources using the deployment configuration provided. A
    /// deployment replaces existing fleet instances with new instances that are deployed
    /// with the updated fleet properties. The fleet is placed in <c>UPDATING</c> status until
    /// the deployment is complete, then return to <c>ACTIVE</c>. 
    /// </para><para>
    /// You can have only one update deployment active at a time for a fleet. If a second
    /// update request initiates a deployment while another deployment is in progress, the
    /// first deployment is cancelled.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "GMLContainerFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.ContainerFleet")]
    [AWSCmdlet("Calls the Amazon GameLift Service UpdateContainerFleet API operation.", Operation = new[] {"UpdateContainerFleet"}, SelectReturnType = typeof(Amazon.GameLift.Model.UpdateContainerFleetResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.ContainerFleet or Amazon.GameLift.Model.UpdateContainerFleetResponse",
        "This cmdlet returns an Amazon.GameLift.Model.ContainerFleet object.",
        "The service call response (type Amazon.GameLift.Model.UpdateContainerFleetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateGMLContainerFleetCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A meaningful description of the container fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the container fleet to update. You can use either the fleet
        /// ID or ARN value.</para>
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
        public System.String FleetId { get; set; }
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
        /// <para>The name or ARN value of a new game server container group definition to deploy on
        /// the fleet. If you're updating the fleet to a specific version of a container group
        /// definition, use the ARN value and include the version number. If you're updating the
        /// fleet to the latest version of a container group definition, you can use the name
        /// value. You can't remove a fleet's game server container group definition, you can
        /// only update or replace it with another definition.</para><para>Update a container group definition by calling <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_UpdateContainerGroupDefinition.html">UpdateContainerGroupDefinition</a>.
        /// This operation creates a <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_ContainerGroupDefinition.html">ContainerGroupDefinition</a>
        /// resource with an incremented version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameServerContainerGroupDefinitionName { get; set; }
        #endregion
        
        #region Parameter GameServerContainerGroupsPerInstance
        /// <summary>
        /// <para>
        /// <para>The number of times to replicate the game server container group on each fleet instance.
        /// By default, Amazon GameLift calculates the maximum number of game server container
        /// groups that can fit on each instance. You can remove this property value to use the
        /// calculated value, or set it manually. If you set this number manually, Amazon GameLift
        /// uses your value as long as it's less than the calculated maximum.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? GameServerContainerGroupsPerInstance { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_ImpairmentStrategy
        /// <summary>
        /// <para>
        /// <para>Determines what actions to take if a deployment fails. If the fleet is multi-location,
        /// this strategy applies across all fleet locations. With a rollback strategy, updated
        /// fleet instances are rolled back to the last successful deployment. Alternatively,
        /// you can maintain a few impaired containers for the purpose of debugging, while all
        /// other tasks return to the last successful deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.DeploymentImpairmentStrategy")]
        public Amazon.GameLift.DeploymentImpairmentStrategy DeploymentConfiguration_ImpairmentStrategy { get; set; }
        #endregion
        
        #region Parameter InstanceInboundPermissionAuthorization
        /// <summary>
        /// <para>
        /// <para>A set of ports to add to the container fleet's inbound permissions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceInboundPermissionAuthorizations")]
        public Amazon.GameLift.Model.IpPermission[] InstanceInboundPermissionAuthorization { get; set; }
        #endregion
        
        #region Parameter InstanceInboundPermissionRevocation
        /// <summary>
        /// <para>
        /// <para>A set of ports to remove from the container fleet's inbound permissions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceInboundPermissionRevocations")]
        public Amazon.GameLift.Model.IpPermission[] InstanceInboundPermissionRevocation { get; set; }
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
        /// <para>The name of an Amazon Web Services CloudWatch metric group to add this fleet to. </para><para />
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
        
        #region Parameter DeploymentConfiguration_MinimumHealthyPercentage
        /// <summary>
        /// <para>
        /// <para>Sets a minimum level of healthy tasks to maintain during deployment activity. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DeploymentConfiguration_MinimumHealthyPercentage { get; set; }
        #endregion
        
        #region Parameter NewGameSessionProtectionPolicy
        /// <summary>
        /// <para>
        /// <para>The game session protection policy to apply to all new game sessions that are started
        /// in this fleet. Game sessions that already exist are not affected. </para>
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
        /// a <c>CreateGameSession</c> request, Amazon GameLift checks that the player (identified
        /// by <c>CreatorId</c>) has created fewer than game session limit in the specified time
        /// period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? GameSessionCreationLimitPolicy_NewGameSessionsPerCreator { get; set; }
        #endregion
        
        #region Parameter PerInstanceContainerGroupDefinitionName
        /// <summary>
        /// <para>
        /// <para>The name or ARN value of a new per-instance container group definition to deploy on
        /// the fleet. If you're updating the fleet to a specific version of a container group
        /// definition, use the ARN value and include the version number. If you're updating the
        /// fleet to the latest version of a container group definition, you can use the name
        /// value.</para><para>Update a container group definition by calling <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_UpdateContainerGroupDefinition.html">UpdateContainerGroupDefinition</a>.
        /// This operation creates a <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_ContainerGroupDefinition.html">ContainerGroupDefinition</a>
        /// resource with an incremented version. </para><para>To remove a fleet's per-instance container group definition, leave this parameter
        /// empty and use the parameter <c>RemoveAttributes</c>.</para>
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
        
        #region Parameter DeploymentConfiguration_ProtectionStrategy
        /// <summary>
        /// <para>
        /// <para>Determines how fleet deployment activity affects active game sessions on the fleet.
        /// With protection, a deployment honors game session protection, and delays actions that
        /// would interrupt a protected active game session until the game session ends. Without
        /// protection, deployment activity can shut down all running tasks, including active
        /// game sessions, regardless of game session protection. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.DeploymentProtectionStrategy")]
        public Amazon.GameLift.DeploymentProtectionStrategy DeploymentConfiguration_ProtectionStrategy { get; set; }
        #endregion
        
        #region Parameter RemoveAttribute
        /// <summary>
        /// <para>
        /// <para>If set, this update removes a fleet's per-instance container group definition. You
        /// can't remove a fleet's game server container group definition.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveAttributes")]
        public System.String[] RemoveAttribute { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.UpdateContainerFleetResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.UpdateContainerFleetResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FleetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLContainerFleet (UpdateContainerFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.UpdateContainerFleetResponse, UpdateGMLContainerFleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeploymentConfiguration_ImpairmentStrategy = this.DeploymentConfiguration_ImpairmentStrategy;
            context.DeploymentConfiguration_MinimumHealthyPercentage = this.DeploymentConfiguration_MinimumHealthyPercentage;
            context.DeploymentConfiguration_ProtectionStrategy = this.DeploymentConfiguration_ProtectionStrategy;
            context.Description = this.Description;
            context.FleetId = this.FleetId;
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GameServerContainerGroupDefinitionName = this.GameServerContainerGroupDefinitionName;
            context.GameServerContainerGroupsPerInstance = this.GameServerContainerGroupsPerInstance;
            context.GameSessionCreationLimitPolicy_NewGameSessionsPerCreator = this.GameSessionCreationLimitPolicy_NewGameSessionsPerCreator;
            context.GameSessionCreationLimitPolicy_PolicyPeriodInMinute = this.GameSessionCreationLimitPolicy_PolicyPeriodInMinute;
            context.InstanceConnectionPortRange_FromPort = this.InstanceConnectionPortRange_FromPort;
            context.InstanceConnectionPortRange_ToPort = this.InstanceConnectionPortRange_ToPort;
            if (this.InstanceInboundPermissionAuthorization != null)
            {
                context.InstanceInboundPermissionAuthorization = new List<Amazon.GameLift.Model.IpPermission>(this.InstanceInboundPermissionAuthorization);
            }
            if (this.InstanceInboundPermissionRevocation != null)
            {
                context.InstanceInboundPermissionRevocation = new List<Amazon.GameLift.Model.IpPermission>(this.InstanceInboundPermissionRevocation);
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
            if (this.RemoveAttribute != null)
            {
                context.RemoveAttribute = new List<System.String>(this.RemoveAttribute);
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
            var request = new Amazon.GameLift.Model.UpdateContainerFleetRequest();
            
            
             // populate DeploymentConfiguration
            var requestDeploymentConfigurationIsNull = true;
            request.DeploymentConfiguration = new Amazon.GameLift.Model.DeploymentConfiguration();
            Amazon.GameLift.DeploymentImpairmentStrategy requestDeploymentConfiguration_deploymentConfiguration_ImpairmentStrategy = null;
            if (cmdletContext.DeploymentConfiguration_ImpairmentStrategy != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_ImpairmentStrategy = cmdletContext.DeploymentConfiguration_ImpairmentStrategy;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_ImpairmentStrategy != null)
            {
                request.DeploymentConfiguration.ImpairmentStrategy = requestDeploymentConfiguration_deploymentConfiguration_ImpairmentStrategy;
                requestDeploymentConfigurationIsNull = false;
            }
            System.Int32? requestDeploymentConfiguration_deploymentConfiguration_MinimumHealthyPercentage = null;
            if (cmdletContext.DeploymentConfiguration_MinimumHealthyPercentage != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_MinimumHealthyPercentage = cmdletContext.DeploymentConfiguration_MinimumHealthyPercentage.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_MinimumHealthyPercentage != null)
            {
                request.DeploymentConfiguration.MinimumHealthyPercentage = requestDeploymentConfiguration_deploymentConfiguration_MinimumHealthyPercentage.Value;
                requestDeploymentConfigurationIsNull = false;
            }
            Amazon.GameLift.DeploymentProtectionStrategy requestDeploymentConfiguration_deploymentConfiguration_ProtectionStrategy = null;
            if (cmdletContext.DeploymentConfiguration_ProtectionStrategy != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_ProtectionStrategy = cmdletContext.DeploymentConfiguration_ProtectionStrategy;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_ProtectionStrategy != null)
            {
                request.DeploymentConfiguration.ProtectionStrategy = requestDeploymentConfiguration_deploymentConfiguration_ProtectionStrategy;
                requestDeploymentConfigurationIsNull = false;
            }
             // determine if request.DeploymentConfiguration should be set to null
            if (requestDeploymentConfigurationIsNull)
            {
                request.DeploymentConfiguration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
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
            if (cmdletContext.InstanceInboundPermissionAuthorization != null)
            {
                request.InstanceInboundPermissionAuthorizations = cmdletContext.InstanceInboundPermissionAuthorization;
            }
            if (cmdletContext.InstanceInboundPermissionRevocation != null)
            {
                request.InstanceInboundPermissionRevocations = cmdletContext.InstanceInboundPermissionRevocation;
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
            if (cmdletContext.RemoveAttribute != null)
            {
                request.RemoveAttributes = cmdletContext.RemoveAttribute;
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
        
        private Amazon.GameLift.Model.UpdateContainerFleetResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.UpdateContainerFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "UpdateContainerFleet");
            try
            {
                return client.UpdateContainerFleetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.GameLift.DeploymentImpairmentStrategy DeploymentConfiguration_ImpairmentStrategy { get; set; }
            public System.Int32? DeploymentConfiguration_MinimumHealthyPercentage { get; set; }
            public Amazon.GameLift.DeploymentProtectionStrategy DeploymentConfiguration_ProtectionStrategy { get; set; }
            public System.String Description { get; set; }
            public System.String FleetId { get; set; }
            public System.String GameServerContainerGroupDefinitionName { get; set; }
            public System.Int32? GameServerContainerGroupsPerInstance { get; set; }
            public System.Int32? GameSessionCreationLimitPolicy_NewGameSessionsPerCreator { get; set; }
            public System.Int32? GameSessionCreationLimitPolicy_PolicyPeriodInMinute { get; set; }
            public System.Int32? InstanceConnectionPortRange_FromPort { get; set; }
            public System.Int32? InstanceConnectionPortRange_ToPort { get; set; }
            public List<Amazon.GameLift.Model.IpPermission> InstanceInboundPermissionAuthorization { get; set; }
            public List<Amazon.GameLift.Model.IpPermission> InstanceInboundPermissionRevocation { get; set; }
            public Amazon.GameLift.LogDestination LogConfiguration_LogDestination { get; set; }
            public System.String LogConfiguration_LogGroupArn { get; set; }
            public System.String LogConfiguration_S3BucketName { get; set; }
            public List<System.String> MetricGroup { get; set; }
            public Amazon.GameLift.ProtectionPolicy NewGameSessionProtectionPolicy { get; set; }
            public System.String PerInstanceContainerGroupDefinitionName { get; set; }
            public List<System.String> RemoveAttribute { get; set; }
            public System.Func<Amazon.GameLift.Model.UpdateContainerFleetResponse, UpdateGMLContainerFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContainerFleet;
        }
        
    }
}
