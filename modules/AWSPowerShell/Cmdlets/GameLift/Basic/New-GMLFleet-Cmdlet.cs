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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Creates a fleet of compute resources to host your game servers. Use this operation
    /// to set up the following types of fleets based on compute type: 
    /// 
    ///  
    /// <para><b>Managed EC2 fleet</b></para><para>
    /// An EC2 fleet is a set of Amazon Elastic Compute Cloud (Amazon EC2) instances. Your
    /// game server build is deployed to each fleet instance. Amazon GameLift manages the
    /// fleet's instances and controls the lifecycle of game server processes, which host
    /// game sessions for players. EC2 fleets can have instances in multiple locations. Each
    /// instance in the fleet is designated a <c>Compute</c>.
    /// </para><para>
    /// To create an EC2 fleet, provide these required parameters:
    /// </para><ul><li><para>
    /// Either <c>BuildId</c> or <c>ScriptId</c></para></li><li><para><c>ComputeType</c> set to <c>EC2</c> (the default value)
    /// </para></li><li><para><c>EC2InboundPermissions</c></para></li><li><para><c>EC2InstanceType</c></para></li><li><para><c>FleetType</c></para></li><li><para><c>Name</c></para></li><li><para><c>RuntimeConfiguration</c> with at least one <c>ServerProcesses</c> configuration
    /// </para></li></ul><para>
    /// If successful, this operation creates a new fleet resource and places it in <c>NEW</c>
    /// status while Amazon GameLift initiates the <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-creating-all.html#fleets-creation-workflow">fleet
    /// creation workflow</a>. To debug your fleet, fetch logs, view performance metrics or
    /// other actions on the fleet, create a development fleet with port 22/3389 open. As
    /// a best practice, we recommend opening ports for remote access only when you need them
    /// and closing them when you're finished. 
    /// </para><para>
    /// When the fleet status is ACTIVE, you can adjust capacity settings and turn autoscaling
    /// on/off for each location.
    /// </para><para><b>Anywhere fleet</b></para><para>
    /// An Anywhere fleet represents compute resources that are not owned or managed by Amazon
    /// GameLift. You might create an Anywhere fleet with your local machine for testing,
    /// or use one to host game servers with on-premises hardware or other game hosting solutions.
    /// 
    /// </para><para>
    /// To create an Anywhere fleet, provide these required parameters:
    /// </para><ul><li><para><c>ComputeType</c> set to <c>ANYWHERE</c></para></li><li><para><c>Locations</c> specifying a custom location
    /// </para></li><li><para><c>Name</c></para></li></ul><para>
    /// If successful, this operation creates a new fleet resource and places it in <c>ACTIVE</c>
    /// status. You can register computes with a fleet in <c>ACTIVE</c> status. 
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-intro.html">Setting
    /// up fleets</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-creating-debug.html#fleets-creating-debug-creation">Debug
    /// fleet creation issues</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-intro.html">Multi-location
    /// fleets</a></para>
    /// </summary>
    [Cmdlet("New", "GMLFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.FleetAttributes")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreateFleet API operation.", Operation = new[] {"CreateFleet"}, SelectReturnType = typeof(Amazon.GameLift.Model.CreateFleetResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.FleetAttributes or Amazon.GameLift.Model.CreateFleetResponse",
        "This cmdlet returns an Amazon.GameLift.Model.FleetAttributes object.",
        "The service call response (type Amazon.GameLift.Model.CreateFleetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGMLFleetCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BuildId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for a custom game server build to be deployed to a fleet with
        /// compute type <c>EC2</c>. You can use either the build ID or ARN. The build must be
        /// uploaded to Amazon GameLift and in <c>READY</c> status. This fleet property can't
        /// be changed after the fleet is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BuildId { get; set; }
        #endregion
        
        #region Parameter CertificateConfiguration_CertificateType
        /// <summary>
        /// <para>
        /// <para>Indicates whether a TLS/SSL certificate is generated for a fleet. </para><para>Valid values include: </para><ul><li><para><b>GENERATED</b> - Generate a TLS/SSL certificate for this fleet.</para></li><li><para><b>DISABLED</b> - (default) Do not generate a TLS/SSL certificate for this fleet.
        /// </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.CertificateType")]
        public Amazon.GameLift.CertificateType CertificateConfiguration_CertificateType { get; set; }
        #endregion
        
        #region Parameter ComputeType
        /// <summary>
        /// <para>
        /// <para>The type of compute resource used to host your game servers. </para><ul><li><para><c>EC2</c> – The game server build is deployed to Amazon EC2 instances for cloud
        /// hosting. This is the default setting.</para></li><li><para><c>ANYWHERE</c> – Game servers and supporting software are deployed to compute resources
        /// that you provide and manage. With this compute type, you can also set the <c>AnywhereConfiguration</c>
        /// parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.ComputeType")]
        public Amazon.GameLift.ComputeType ComputeType { get; set; }
        #endregion
        
        #region Parameter AnywhereConfiguration_Cost
        /// <summary>
        /// <para>
        /// <para>The cost to run your fleet per hour. Amazon GameLift uses the provided cost of your
        /// fleet to balance usage in queues. For more information about queues, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/queues-intro.html">Setting
        /// up queues</a> in the <i>Amazon GameLift Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnywhereConfiguration_Cost { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EC2InboundPermission
        /// <summary>
        /// <para>
        /// <para>The IP address ranges and port settings that allow inbound traffic to access game
        /// server processes and other processes on this fleet. Set this parameter for managed
        /// EC2 fleets. You can leave this parameter empty when creating the fleet, but you must
        /// call <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_UpdateFleetPortSettings">https://docs.aws.amazon.com/gamelift/latest/apireference/API_UpdateFleetPortSettings</a>
        /// to set it before players can connect to game sessions. As a best practice, we recommend
        /// opening ports for remote access only when you need them and closing them when you're
        /// finished. For Realtime Servers fleets, Amazon GameLift automatically sets TCP and
        /// UDP ranges.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EC2InboundPermissions")]
        public Amazon.GameLift.Model.IpPermission[] EC2InboundPermission { get; set; }
        #endregion
        
        #region Parameter EC2InstanceType
        /// <summary>
        /// <para>
        /// <para>The Amazon GameLift-supported Amazon EC2 instance type to use with managed EC2 fleets.
        /// Instance type determines the computing resources that will be used to host your game
        /// servers, including CPU, memory, storage, and networking capacity. See <a href="http://aws.amazon.com/ec2/instance-types/">Amazon
        /// Elastic Compute Cloud Instance Types</a> for detailed descriptions of Amazon EC2 instance
        /// types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.EC2InstanceType")]
        public Amazon.GameLift.EC2InstanceType EC2InstanceType { get; set; }
        #endregion
        
        #region Parameter FleetType
        /// <summary>
        /// <para>
        /// <para>Indicates whether to use On-Demand or Spot instances for this fleet. By default, this
        /// property is set to <c>ON_DEMAND</c>. Learn more about when to use <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-ec2-instances.html#gamelift-ec2-instances-spot">
        /// On-Demand versus Spot Instances</a>. This fleet property can't be changed after the
        /// fleet is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.FleetType")]
        public Amazon.GameLift.FleetType FleetType { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration_GameSessionActivationTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time (in seconds) allowed to launch a new game session and have
        /// it report ready to host players. During this time, the game session is in status <c>ACTIVATING</c>.
        /// If the game session does not become active before the timeout, it is ended and the
        /// game session status is changed to <c>TERMINATED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuntimeConfiguration_GameSessionActivationTimeoutSeconds")]
        public System.Int32? RuntimeConfiguration_GameSessionActivationTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter InstanceRoleArn
        /// <summary>
        /// <para>
        /// <para>A unique identifier for an IAM role that manages access to your Amazon Web Services
        /// services. With an instance role ARN set, any application that runs on an instance
        /// in this fleet can assume the role, including install scripts, server processes, and
        /// daemons (background processes). Create a role or look up a role's ARN by using the
        /// <a href="https://console.aws.amazon.com/iam/">IAM dashboard</a> in the Amazon Web
        /// Services Management Console. Learn more about using on-box credentials for your game
        /// servers at <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-resources.html">
        /// Access external resources from a game server</a>. This fleet property can't be changed
        /// after the fleet is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceRoleArn { get; set; }
        #endregion
        
        #region Parameter InstanceRoleCredentialsProvider
        /// <summary>
        /// <para>
        /// <para>Prompts Amazon GameLift to generate a shared credentials file for the IAM role that's
        /// defined in <c>InstanceRoleArn</c>. The shared credentials file is stored on each fleet
        /// instance and refreshed as needed. Use shared credentials for applications that are
        /// deployed along with the game server executable, if the game server is integrated with
        /// server SDK version 5.x. For more information about using shared credentials, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-resources.html">
        /// Communicate with other Amazon Web Services resources from your fleets</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.InstanceRoleCredentialsProvider")]
        public Amazon.GameLift.InstanceRoleCredentialsProvider InstanceRoleCredentialsProvider { get; set; }
        #endregion
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <para>A set of remote locations to deploy additional instances to and manage as a multi-location
        /// fleet. Use this parameter when creating a fleet in Amazon Web Services Regions that
        /// support multiple locations. You can add any Amazon Web Services Region or Local Zone
        /// that's supported by Amazon GameLift. Provide a list of one or more Amazon Web Services
        /// Region codes, such as <c>us-west-2</c>, or Local Zone names. When using this parameter,
        /// Amazon GameLift requires you to include your home location in the request. For a list
        /// of supported Regions and Local Zones, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-regions.html">
        /// Amazon GameLift service locations</a> for managed hosting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Locations")]
        public Amazon.GameLift.Model.LocationConfiguration[] Location { get; set; }
        #endregion
        
        #region Parameter LogPath
        /// <summary>
        /// <para>
        /// <para><b>This parameter is no longer used.</b> To specify where Amazon GameLift should
        /// store log files once a server process shuts down, use the Amazon GameLift server API
        /// <c>ProcessReady()</c> and specify one or more directory paths in <c>logParameters</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-api.html#gamelift-sdk-server-initialize">Initialize
        /// the server process</a> in the <i>Amazon GameLift Developer Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogPaths")]
        public System.String[] LogPath { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration_MaxConcurrentGameSessionActivation
        /// <summary>
        /// <para>
        /// <para>The number of game sessions in status <c>ACTIVATING</c> to allow on an instance or
        /// compute. This setting limits the instance resources that can be used for new game
        /// activations at any one time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuntimeConfiguration_MaxConcurrentGameSessionActivations")]
        public System.Int32? RuntimeConfiguration_MaxConcurrentGameSessionActivation { get; set; }
        #endregion
        
        #region Parameter MetricGroup
        /// <summary>
        /// <para>
        /// <para>The name of an Amazon Web Services CloudWatch metric group to add this fleet to. A
        /// metric group is used to aggregate the metrics for multiple fleets. You can specify
        /// an existing metric group name or set a new name to create a new metric group. A fleet
        /// can be included in only one metric group at a time. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricGroups")]
        public System.String[] MetricGroup { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A descriptive label that is associated with a fleet. Fleet names do not need to be
        /// unique.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NewGameSessionProtectionPolicy
        /// <summary>
        /// <para>
        /// <para>The status of termination protection for active game sessions on the fleet. By default,
        /// this property is set to <c>NoProtection</c>. You can also set game session protection
        /// for an individual game session by calling <a href="gamelift/latest/apireference/API_UpdateGameSession.html">UpdateGameSession</a>.</para><ul><li><para><b>NoProtection</b> - Game sessions can be terminated during active gameplay as a
        /// result of a scale-down event. </para></li><li><para><b>FullProtection</b> - Game sessions in <c>ACTIVE</c> status cannot be terminated
        /// during a scale-down event.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.ProtectionPolicy")]
        public Amazon.GameLift.ProtectionPolicy NewGameSessionProtectionPolicy { get; set; }
        #endregion
        
        #region Parameter ResourceCreationLimitPolicy_NewGameSessionsPerCreator
        /// <summary>
        /// <para>
        /// <para>A policy that puts limits on the number of game sessions that a player can create
        /// within a specified span of time. With this policy, you can control players' ability
        /// to consume available resources.</para><para>The policy is evaluated when a player tries to create a new game session. On receiving
        /// a <c>CreateGameSession</c> request, Amazon GameLift checks that the player (identified
        /// by <c>CreatorId</c>) has created fewer than game session limit in the specified time
        /// period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ResourceCreationLimitPolicy_NewGameSessionsPerCreator { get; set; }
        #endregion
        
        #region Parameter PeerVpcAwsAccountId
        /// <summary>
        /// <para>
        /// <para>Used when peering your Amazon GameLift fleet with a VPC, the unique identifier for
        /// the Amazon Web Services account that owns the VPC. You can find your account ID in
        /// the Amazon Web Services Management Console under account settings. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PeerVpcAwsAccountId { get; set; }
        #endregion
        
        #region Parameter PeerVpcId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a VPC with resources to be accessed by your Amazon GameLift
        /// fleet. The VPC must be in the same Region as your fleet. To look up a VPC ID, use
        /// the <a href="https://console.aws.amazon.com/vpc/">VPC Dashboard</a> in the Amazon
        /// Web Services Management Console. Learn more about VPC peering in <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/vpc-peering.html">VPC
        /// Peering with Amazon GameLift Fleets</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PeerVpcId { get; set; }
        #endregion
        
        #region Parameter ResourceCreationLimitPolicy_PolicyPeriodInMinute
        /// <summary>
        /// <para>
        /// <para>The time span used in evaluating the resource creation limit policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceCreationLimitPolicy_PolicyPeriodInMinutes")]
        public System.Int32? ResourceCreationLimitPolicy_PolicyPeriodInMinute { get; set; }
        #endregion
        
        #region Parameter ScriptId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for a Realtime configuration script to be deployed to a fleet
        /// with compute type <c>EC2</c>. You can use either the script ID or ARN. Scripts must
        /// be uploaded to Amazon GameLift prior to creating the fleet. This fleet property can't
        /// be changed after the fleet is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScriptId { get; set; }
        #endregion
        
        #region Parameter ServerLaunchParameter
        /// <summary>
        /// <para>
        /// <para><b>This parameter is no longer used.</b> Specify server launch parameters using the
        /// <c>RuntimeConfiguration</c> parameter. Requests that use this parameter instead continue
        /// to be valid.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServerLaunchParameters")]
        public System.String ServerLaunchParameter { get; set; }
        #endregion
        
        #region Parameter ServerLaunchPath
        /// <summary>
        /// <para>
        /// <para><b>This parameter is no longer used.</b> Specify a server launch path using the <c>RuntimeConfiguration</c>
        /// parameter. Requests that use this parameter instead continue to be valid.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerLaunchPath { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration_ServerProcess
        /// <summary>
        /// <para>
        /// <para>A collection of server process configurations that identify what server processes
        /// to run on fleet computes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuntimeConfiguration_ServerProcesses")]
        public Amazon.GameLift.Model.ServerProcess[] RuntimeConfiguration_ServerProcess { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of labels to assign to the new fleet resource. Tags are developer-defined key-value
        /// pairs. Tagging Amazon Web Services resources are useful for resource management, access
        /// management and cost allocation. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">
        /// Tagging Amazon Web Services Resources</a> in the <i>Amazon Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.GameLift.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FleetAttributes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.CreateFleetResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.CreateFleetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FleetAttributes";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BuildId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BuildId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BuildId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLFleet (CreateFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.CreateFleetResponse, NewGMLFleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BuildId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AnywhereConfiguration_Cost = this.AnywhereConfiguration_Cost;
            context.BuildId = this.BuildId;
            context.CertificateConfiguration_CertificateType = this.CertificateConfiguration_CertificateType;
            context.ComputeType = this.ComputeType;
            context.Description = this.Description;
            if (this.EC2InboundPermission != null)
            {
                context.EC2InboundPermission = new List<Amazon.GameLift.Model.IpPermission>(this.EC2InboundPermission);
            }
            context.EC2InstanceType = this.EC2InstanceType;
            context.FleetType = this.FleetType;
            context.InstanceRoleArn = this.InstanceRoleArn;
            context.InstanceRoleCredentialsProvider = this.InstanceRoleCredentialsProvider;
            if (this.Location != null)
            {
                context.Location = new List<Amazon.GameLift.Model.LocationConfiguration>(this.Location);
            }
            if (this.LogPath != null)
            {
                context.LogPath = new List<System.String>(this.LogPath);
            }
            if (this.MetricGroup != null)
            {
                context.MetricGroup = new List<System.String>(this.MetricGroup);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewGameSessionProtectionPolicy = this.NewGameSessionProtectionPolicy;
            context.PeerVpcAwsAccountId = this.PeerVpcAwsAccountId;
            context.PeerVpcId = this.PeerVpcId;
            context.ResourceCreationLimitPolicy_NewGameSessionsPerCreator = this.ResourceCreationLimitPolicy_NewGameSessionsPerCreator;
            context.ResourceCreationLimitPolicy_PolicyPeriodInMinute = this.ResourceCreationLimitPolicy_PolicyPeriodInMinute;
            context.RuntimeConfiguration_GameSessionActivationTimeoutSecond = this.RuntimeConfiguration_GameSessionActivationTimeoutSecond;
            context.RuntimeConfiguration_MaxConcurrentGameSessionActivation = this.RuntimeConfiguration_MaxConcurrentGameSessionActivation;
            if (this.RuntimeConfiguration_ServerProcess != null)
            {
                context.RuntimeConfiguration_ServerProcess = new List<Amazon.GameLift.Model.ServerProcess>(this.RuntimeConfiguration_ServerProcess);
            }
            context.ScriptId = this.ScriptId;
            context.ServerLaunchParameter = this.ServerLaunchParameter;
            context.ServerLaunchPath = this.ServerLaunchPath;
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
            var request = new Amazon.GameLift.Model.CreateFleetRequest();
            
            
             // populate AnywhereConfiguration
            var requestAnywhereConfigurationIsNull = true;
            request.AnywhereConfiguration = new Amazon.GameLift.Model.AnywhereConfiguration();
            System.String requestAnywhereConfiguration_anywhereConfiguration_Cost = null;
            if (cmdletContext.AnywhereConfiguration_Cost != null)
            {
                requestAnywhereConfiguration_anywhereConfiguration_Cost = cmdletContext.AnywhereConfiguration_Cost;
            }
            if (requestAnywhereConfiguration_anywhereConfiguration_Cost != null)
            {
                request.AnywhereConfiguration.Cost = requestAnywhereConfiguration_anywhereConfiguration_Cost;
                requestAnywhereConfigurationIsNull = false;
            }
             // determine if request.AnywhereConfiguration should be set to null
            if (requestAnywhereConfigurationIsNull)
            {
                request.AnywhereConfiguration = null;
            }
            if (cmdletContext.BuildId != null)
            {
                request.BuildId = cmdletContext.BuildId;
            }
            
             // populate CertificateConfiguration
            var requestCertificateConfigurationIsNull = true;
            request.CertificateConfiguration = new Amazon.GameLift.Model.CertificateConfiguration();
            Amazon.GameLift.CertificateType requestCertificateConfiguration_certificateConfiguration_CertificateType = null;
            if (cmdletContext.CertificateConfiguration_CertificateType != null)
            {
                requestCertificateConfiguration_certificateConfiguration_CertificateType = cmdletContext.CertificateConfiguration_CertificateType;
            }
            if (requestCertificateConfiguration_certificateConfiguration_CertificateType != null)
            {
                request.CertificateConfiguration.CertificateType = requestCertificateConfiguration_certificateConfiguration_CertificateType;
                requestCertificateConfigurationIsNull = false;
            }
             // determine if request.CertificateConfiguration should be set to null
            if (requestCertificateConfigurationIsNull)
            {
                request.CertificateConfiguration = null;
            }
            if (cmdletContext.ComputeType != null)
            {
                request.ComputeType = cmdletContext.ComputeType;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EC2InboundPermission != null)
            {
                request.EC2InboundPermissions = cmdletContext.EC2InboundPermission;
            }
            if (cmdletContext.EC2InstanceType != null)
            {
                request.EC2InstanceType = cmdletContext.EC2InstanceType;
            }
            if (cmdletContext.FleetType != null)
            {
                request.FleetType = cmdletContext.FleetType;
            }
            if (cmdletContext.InstanceRoleArn != null)
            {
                request.InstanceRoleArn = cmdletContext.InstanceRoleArn;
            }
            if (cmdletContext.InstanceRoleCredentialsProvider != null)
            {
                request.InstanceRoleCredentialsProvider = cmdletContext.InstanceRoleCredentialsProvider;
            }
            if (cmdletContext.Location != null)
            {
                request.Locations = cmdletContext.Location;
            }
            if (cmdletContext.LogPath != null)
            {
                request.LogPaths = cmdletContext.LogPath;
            }
            if (cmdletContext.MetricGroup != null)
            {
                request.MetricGroups = cmdletContext.MetricGroup;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NewGameSessionProtectionPolicy != null)
            {
                request.NewGameSessionProtectionPolicy = cmdletContext.NewGameSessionProtectionPolicy;
            }
            if (cmdletContext.PeerVpcAwsAccountId != null)
            {
                request.PeerVpcAwsAccountId = cmdletContext.PeerVpcAwsAccountId;
            }
            if (cmdletContext.PeerVpcId != null)
            {
                request.PeerVpcId = cmdletContext.PeerVpcId;
            }
            
             // populate ResourceCreationLimitPolicy
            var requestResourceCreationLimitPolicyIsNull = true;
            request.ResourceCreationLimitPolicy = new Amazon.GameLift.Model.ResourceCreationLimitPolicy();
            System.Int32? requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_NewGameSessionsPerCreator = null;
            if (cmdletContext.ResourceCreationLimitPolicy_NewGameSessionsPerCreator != null)
            {
                requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_NewGameSessionsPerCreator = cmdletContext.ResourceCreationLimitPolicy_NewGameSessionsPerCreator.Value;
            }
            if (requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_NewGameSessionsPerCreator != null)
            {
                request.ResourceCreationLimitPolicy.NewGameSessionsPerCreator = requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_NewGameSessionsPerCreator.Value;
                requestResourceCreationLimitPolicyIsNull = false;
            }
            System.Int32? requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_PolicyPeriodInMinute = null;
            if (cmdletContext.ResourceCreationLimitPolicy_PolicyPeriodInMinute != null)
            {
                requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_PolicyPeriodInMinute = cmdletContext.ResourceCreationLimitPolicy_PolicyPeriodInMinute.Value;
            }
            if (requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_PolicyPeriodInMinute != null)
            {
                request.ResourceCreationLimitPolicy.PolicyPeriodInMinutes = requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_PolicyPeriodInMinute.Value;
                requestResourceCreationLimitPolicyIsNull = false;
            }
             // determine if request.ResourceCreationLimitPolicy should be set to null
            if (requestResourceCreationLimitPolicyIsNull)
            {
                request.ResourceCreationLimitPolicy = null;
            }
            
             // populate RuntimeConfiguration
            var requestRuntimeConfigurationIsNull = true;
            request.RuntimeConfiguration = new Amazon.GameLift.Model.RuntimeConfiguration();
            System.Int32? requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond = null;
            if (cmdletContext.RuntimeConfiguration_GameSessionActivationTimeoutSecond != null)
            {
                requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond = cmdletContext.RuntimeConfiguration_GameSessionActivationTimeoutSecond.Value;
            }
            if (requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond != null)
            {
                request.RuntimeConfiguration.GameSessionActivationTimeoutSeconds = requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond.Value;
                requestRuntimeConfigurationIsNull = false;
            }
            System.Int32? requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation = null;
            if (cmdletContext.RuntimeConfiguration_MaxConcurrentGameSessionActivation != null)
            {
                requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation = cmdletContext.RuntimeConfiguration_MaxConcurrentGameSessionActivation.Value;
            }
            if (requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation != null)
            {
                request.RuntimeConfiguration.MaxConcurrentGameSessionActivations = requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation.Value;
                requestRuntimeConfigurationIsNull = false;
            }
            List<Amazon.GameLift.Model.ServerProcess> requestRuntimeConfiguration_runtimeConfiguration_ServerProcess = null;
            if (cmdletContext.RuntimeConfiguration_ServerProcess != null)
            {
                requestRuntimeConfiguration_runtimeConfiguration_ServerProcess = cmdletContext.RuntimeConfiguration_ServerProcess;
            }
            if (requestRuntimeConfiguration_runtimeConfiguration_ServerProcess != null)
            {
                request.RuntimeConfiguration.ServerProcesses = requestRuntimeConfiguration_runtimeConfiguration_ServerProcess;
                requestRuntimeConfigurationIsNull = false;
            }
             // determine if request.RuntimeConfiguration should be set to null
            if (requestRuntimeConfigurationIsNull)
            {
                request.RuntimeConfiguration = null;
            }
            if (cmdletContext.ScriptId != null)
            {
                request.ScriptId = cmdletContext.ScriptId;
            }
            if (cmdletContext.ServerLaunchParameter != null)
            {
                request.ServerLaunchParameters = cmdletContext.ServerLaunchParameter;
            }
            if (cmdletContext.ServerLaunchPath != null)
            {
                request.ServerLaunchPath = cmdletContext.ServerLaunchPath;
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
        
        private Amazon.GameLift.Model.CreateFleetResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "CreateFleet");
            try
            {
                #if DESKTOP
                return client.CreateFleet(request);
                #elif CORECLR
                return client.CreateFleetAsync(request).GetAwaiter().GetResult();
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
            public System.String AnywhereConfiguration_Cost { get; set; }
            public System.String BuildId { get; set; }
            public Amazon.GameLift.CertificateType CertificateConfiguration_CertificateType { get; set; }
            public Amazon.GameLift.ComputeType ComputeType { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.GameLift.Model.IpPermission> EC2InboundPermission { get; set; }
            public Amazon.GameLift.EC2InstanceType EC2InstanceType { get; set; }
            public Amazon.GameLift.FleetType FleetType { get; set; }
            public System.String InstanceRoleArn { get; set; }
            public Amazon.GameLift.InstanceRoleCredentialsProvider InstanceRoleCredentialsProvider { get; set; }
            public List<Amazon.GameLift.Model.LocationConfiguration> Location { get; set; }
            public List<System.String> LogPath { get; set; }
            public List<System.String> MetricGroup { get; set; }
            public System.String Name { get; set; }
            public Amazon.GameLift.ProtectionPolicy NewGameSessionProtectionPolicy { get; set; }
            public System.String PeerVpcAwsAccountId { get; set; }
            public System.String PeerVpcId { get; set; }
            public System.Int32? ResourceCreationLimitPolicy_NewGameSessionsPerCreator { get; set; }
            public System.Int32? ResourceCreationLimitPolicy_PolicyPeriodInMinute { get; set; }
            public System.Int32? RuntimeConfiguration_GameSessionActivationTimeoutSecond { get; set; }
            public System.Int32? RuntimeConfiguration_MaxConcurrentGameSessionActivation { get; set; }
            public List<Amazon.GameLift.Model.ServerProcess> RuntimeConfiguration_ServerProcess { get; set; }
            public System.String ScriptId { get; set; }
            public System.String ServerLaunchParameter { get; set; }
            public System.String ServerLaunchPath { get; set; }
            public List<Amazon.GameLift.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.GameLift.Model.CreateFleetResponse, NewGMLFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FleetAttributes;
        }
        
    }
}
