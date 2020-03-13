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
    /// Creates a new fleet to run your game servers. whether they are custom game builds
    /// or Realtime Servers with game-specific script. A fleet is a set of Amazon Elastic
    /// Compute Cloud (Amazon EC2) instances, each of which can host multiple game sessions.
    /// When creating a fleet, you choose the hardware specifications, set some configuration
    /// options, and specify the game server to deploy on the new fleet. 
    /// 
    ///  
    /// <para>
    /// To create a new fleet, provide the following: (1) a fleet name, (2) an EC2 instance
    /// type and fleet type (spot or on-demand), (3) the build ID for your game build or script
    /// ID if using Realtime Servers, and (4) a runtime configuration, which determines how
    /// game servers will run on each instance in the fleet. 
    /// </para><para>
    /// If the <code>CreateFleet</code> call is successful, Amazon GameLift performs the following
    /// tasks. You can track the process of a fleet by checking the fleet status or by monitoring
    /// fleet creation events:
    /// </para><ul><li><para>
    /// Creates a fleet resource. Status: <code>NEW</code>.
    /// </para></li><li><para>
    /// Begins writing events to the fleet event log, which can be accessed in the Amazon
    /// GameLift console.
    /// </para></li><li><para>
    /// Sets the fleet's target capacity to 1 (desired instances), which triggers Amazon GameLift
    /// to start one new EC2 instance.
    /// </para></li><li><para>
    /// Downloads the game build or Realtime script to the new instance and installs it. Statuses:
    /// <code>DOWNLOADING</code>, <code>VALIDATING</code>, <code>BUILDING</code>. 
    /// </para></li><li><para>
    /// Starts launching server processes on the instance. If the fleet is configured to run
    /// multiple server processes per instance, Amazon GameLift staggers each process launch
    /// by a few seconds. Status: <code>ACTIVATING</code>.
    /// </para></li><li><para>
    /// Sets the fleet's status to <code>ACTIVE</code> as soon as one server process is ready
    /// to host a game session.
    /// </para></li></ul><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-intro.html">Setting
    /// Up Fleets</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-creating-debug.html#fleets-creating-debug-creation">Debug
    /// Fleet Creation Issues</a></para><para><b>Related operations</b></para><ul><li><para><a>CreateFleet</a></para></li><li><para><a>ListFleets</a></para></li><li><para><a>DeleteFleet</a></para></li><li><para><a>DescribeFleetAttributes</a></para></li><li><para><a>UpdateFleetAttributes</a></para></li><li><para><a>StartFleetActions</a> or <a>StopFleetActions</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "GMLFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.FleetAttributes")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreateFleet API operation.", Operation = new[] {"CreateFleet"}, SelectReturnType = typeof(Amazon.GameLift.Model.CreateFleetResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.FleetAttributes or Amazon.GameLift.Model.CreateFleetResponse",
        "This cmdlet returns an Amazon.GameLift.Model.FleetAttributes object.",
        "The service call response (type Amazon.GameLift.Model.CreateFleetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLFleetCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter BuildId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a build to be deployed on the new fleet. You can use either
        /// the build ID or ARN value. The custom game server build must have been successfully
        /// uploaded to Amazon GameLift and be in a <code>READY</code> status. This fleet setting
        /// cannot be changed once the fleet is created. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BuildId { get; set; }
        #endregion
        
        #region Parameter CertificateConfiguration_CertificateType
        /// <summary>
        /// <para>
        /// <para>Indicates whether a TLS/SSL certificate was generated for a fleet. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.CertificateType")]
        public Amazon.GameLift.CertificateType CertificateConfiguration_CertificateType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A human-readable description of a fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EC2InboundPermission
        /// <summary>
        /// <para>
        /// <para>Range of IP addresses and port settings that permit inbound traffic to access game
        /// sessions that are running on the fleet. For fleets using a custom game build, this
        /// parameter is required before game sessions running on the fleet can accept connections.
        /// For Realtime Servers fleets, Amazon GameLift automatically sets TCP and UDP ranges
        /// for use by the Realtime servers. You can specify multiple permission settings or add
        /// more by updating the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EC2InboundPermissions")]
        public Amazon.GameLift.Model.IpPermission[] EC2InboundPermission { get; set; }
        #endregion
        
        #region Parameter EC2InstanceType
        /// <summary>
        /// <para>
        /// <para>The name of an EC2 instance type that is supported in Amazon GameLift. A fleet instance
        /// type determines the computing resources of each instance in the fleet, including CPU,
        /// memory, storage, and networking capacity. Amazon GameLift supports the following EC2
        /// instance types. See <a href="http://aws.amazon.com/ec2/instance-types/">Amazon EC2
        /// Instance Types</a> for detailed descriptions.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GameLift.EC2InstanceType")]
        public Amazon.GameLift.EC2InstanceType EC2InstanceType { get; set; }
        #endregion
        
        #region Parameter FleetType
        /// <summary>
        /// <para>
        /// <para>Indicates whether to use On-Demand instances or Spot instances for this fleet. If
        /// empty, the default is <code>ON_DEMAND</code>. Both categories of instances use identical
        /// hardware and configurations based on the instance type selected for this fleet. Learn
        /// more about <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-ec2-instances.html#gamelift-ec2-instances-spot">
        /// On-Demand versus Spot Instances</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.FleetType")]
        public Amazon.GameLift.FleetType FleetType { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration_GameSessionActivationTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time (in seconds) that a game session can remain in status <code>ACTIVATING</code>.
        /// If the game session is not active before the timeout, activation is terminated and
        /// the game session status is changed to <code>TERMINATED</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuntimeConfiguration_GameSessionActivationTimeoutSeconds")]
        public System.Int32? RuntimeConfiguration_GameSessionActivationTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter InstanceRoleArn
        /// <summary>
        /// <para>
        /// <para>A unique identifier for an AWS IAM role that manages access to your AWS services.
        /// With an instance role ARN set, any application that runs on an instance in this fleet
        /// can assume the role, including install scripts, server processes, and daemons (background
        /// processes). Create a role or look up a role's ARN from the <a href="https://console.aws.amazon.com/iam/">IAM
        /// dashboard</a> in the AWS Management Console. Learn more about using on-box credentials
        /// for your game servers at <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-resources.html">
        /// Access external resources from a game server</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceRoleArn { get; set; }
        #endregion
        
        #region Parameter LogPath
        /// <summary>
        /// <para>
        /// <para>This parameter is no longer used. Instead, to specify where Amazon GameLift should
        /// store log files once a server process shuts down, use the Amazon GameLift server API
        /// <code>ProcessReady()</code> and specify one or more directory paths in <code>logParameters</code>.
        /// See more information in the <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-api-ref.html#gamelift-sdk-server-api-ref-dataypes-process">Server
        /// API Reference</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogPaths")]
        public System.String[] LogPath { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration_MaxConcurrentGameSessionActivation
        /// <summary>
        /// <para>
        /// <para>The maximum number of game sessions with status <code>ACTIVATING</code> to allow on
        /// an instance simultaneously. This setting limits the amount of instance resources that
        /// can be used for new game activations at any one time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuntimeConfiguration_MaxConcurrentGameSessionActivations")]
        public System.Int32? RuntimeConfiguration_MaxConcurrentGameSessionActivation { get; set; }
        #endregion
        
        #region Parameter MetricGroup
        /// <summary>
        /// <para>
        /// <para>The name of an Amazon CloudWatch metric group to add this fleet to. A metric group
        /// aggregates the metrics for all fleets in the group. Specify an existing metric group
        /// name, or provide a new name to create a new metric group. A fleet can only be included
        /// in one metric group at a time. </para>
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
        /// <para>A game session protection policy to apply to all instances in this fleet. If this
        /// parameter is not set, instances in this fleet default to no protection. You can change
        /// a fleet's protection policy using <a>UpdateFleetAttributes</a>, but this change will
        /// only affect sessions created after the policy change. You can also set protection
        /// for individual instances using <a>UpdateGameSession</a>.</para><ul><li><para><b>NoProtection</b> - The game session can be terminated during a scale-down event.</para></li><li><para><b>FullProtection</b> - If the game session is in an <code>ACTIVE</code> status,
        /// it cannot be terminated during a scale-down event.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.ProtectionPolicy")]
        public Amazon.GameLift.ProtectionPolicy NewGameSessionProtectionPolicy { get; set; }
        #endregion
        
        #region Parameter ResourceCreationLimitPolicy_NewGameSessionsPerCreator
        /// <summary>
        /// <para>
        /// <para>The maximum number of game sessions that an individual can create during the policy
        /// period. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ResourceCreationLimitPolicy_NewGameSessionsPerCreator { get; set; }
        #endregion
        
        #region Parameter PeerVpcAwsAccountId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the AWS account with the VPC that you want to peer your Amazon
        /// GameLift fleet with. You can find your account ID in the AWS Management Console under
        /// account settings. </para>
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
        /// the <a href="https://console.aws.amazon.com/vpc/">VPC Dashboard</a> in the AWS Management
        /// Console. Learn more about VPC peering in <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/vpc-peering.html">VPC
        /// Peering with Amazon GameLift Fleets</a>. </para>
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
        /// <para>A unique identifier for a Realtime script to be deployed on the new fleet. You can
        /// use either the script ID or ARN value. The Realtime script must have been successfully
        /// uploaded to Amazon GameLift. This fleet setting cannot be changed once the fleet is
        /// created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScriptId { get; set; }
        #endregion
        
        #region Parameter ServerLaunchParameter
        /// <summary>
        /// <para>
        /// <para>This parameter is no longer used. Instead, specify server launch parameters in the
        /// <code>RuntimeConfiguration</code> parameter. (Requests that specify a server launch
        /// path and launch parameters instead of a runtime configuration will continue to work.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServerLaunchParameters")]
        public System.String ServerLaunchParameter { get; set; }
        #endregion
        
        #region Parameter ServerLaunchPath
        /// <summary>
        /// <para>
        /// <para>This parameter is no longer used. Instead, specify a server launch path using the
        /// <code>RuntimeConfiguration</code> parameter. Requests that specify a server launch
        /// path and launch parameters instead of a runtime configuration will continue to work.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerLaunchPath { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration_ServerProcess
        /// <summary>
        /// <para>
        /// <para>A collection of server process configurations that describe which server processes
        /// to run on each instance in a fleet.</para>
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
        /// pairs. Tagging AWS resources are useful for resource management, access management
        /// and cost allocation. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">
        /// Tagging AWS Resources</a> in the <i>AWS General Reference</i>. Once the resource is
        /// created, you can use <a>TagResource</a>, <a>UntagResource</a>, and <a>ListTagsForResource</a>
        /// to add, remove, and view tags. The maximum tag limit may be lower than stated. See
        /// the AWS General Reference for actual tagging limits.</para>
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
            context.BuildId = this.BuildId;
            context.CertificateConfiguration_CertificateType = this.CertificateConfiguration_CertificateType;
            context.Description = this.Description;
            if (this.EC2InboundPermission != null)
            {
                context.EC2InboundPermission = new List<Amazon.GameLift.Model.IpPermission>(this.EC2InboundPermission);
            }
            context.EC2InstanceType = this.EC2InstanceType;
            #if MODULAR
            if (this.EC2InstanceType == null && ParameterWasBound(nameof(this.EC2InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter EC2InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FleetType = this.FleetType;
            context.InstanceRoleArn = this.InstanceRoleArn;
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
            public System.String BuildId { get; set; }
            public Amazon.GameLift.CertificateType CertificateConfiguration_CertificateType { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.GameLift.Model.IpPermission> EC2InboundPermission { get; set; }
            public Amazon.GameLift.EC2InstanceType EC2InstanceType { get; set; }
            public Amazon.GameLift.FleetType FleetType { get; set; }
            public System.String InstanceRoleArn { get; set; }
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
