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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Creates a new fleet to run your game servers. A fleet is a set of Amazon Elastic Compute
    /// Cloud (Amazon EC2) instances, each of which can run multiple server processes to host
    /// game sessions. You configure a fleet to create instances with certain hardware specifications
    /// (see <a href="http://aws.amazon.com/ec2/instance-types/">Amazon EC2 Instance Types</a>
    /// for more information), and deploy a specified game build to each instance. A newly
    /// created fleet passes through several statuses; once it reaches the <code>ACTIVE</code>
    /// status, it can begin hosting game sessions.
    /// 
    ///  
    /// <para>
    /// To create a new fleet, you must specify the following: (1) fleet name, (2) build ID
    /// of an uploaded game build, (3) an EC2 instance type, and (4) a runtime configuration
    /// that describes which server processes to run on each instance in the fleet. (Although
    /// the runtime configuration is not a required parameter, the fleet cannot be successfully
    /// created without it.) You can also configure the new fleet with the following settings:
    /// fleet description, access permissions for inbound traffic, fleet-wide game session
    /// protection, and resource creation limit. If you use Amazon CloudWatch for metrics,
    /// you can add the new fleet to a metric group, which allows you to view aggregated metrics
    /// for a set of fleets. Once you specify a metric group, the new fleet's metrics are
    /// included in the metric group's data.
    /// </para><para>
    /// If the CreateFleet call is successful, Amazon GameLift performs the following tasks:
    /// </para><ul><li><para>
    /// Creates a fleet record and sets the status to <code>NEW</code> (followed by other
    /// statuses as the fleet is activated).
    /// </para></li><li><para>
    /// Sets the fleet's capacity to 1 "desired", which causes Amazon GameLift to start one
    /// new EC2 instance.
    /// </para></li><li><para>
    /// Starts launching server processes on the instance. If the fleet is configured to run
    /// multiple server processes per instance, Amazon GameLift staggers each launch by a
    /// few seconds.
    /// </para></li><li><para>
    /// Begins writing events to the fleet event log, which can be accessed in the Amazon
    /// GameLift console.
    /// </para></li><li><para>
    /// Sets the fleet's status to <code>ACTIVE</code> once one server process in the fleet
    /// is ready to host a game session.
    /// </para></li></ul><para>
    /// After a fleet is created, use the following actions to change fleet properties and
    /// configuration:
    /// </para><ul><li><para><a>UpdateFleetAttributes</a> -- Update fleet metadata, including name and description.
    /// </para></li><li><para><a>UpdateFleetCapacity</a> -- Increase or decrease the number of instances you want
    /// the fleet to maintain.
    /// </para></li><li><para><a>UpdateFleetPortSettings</a> -- Change the IP address and port ranges that allow
    /// access to incoming traffic.
    /// </para></li><li><para><a>UpdateRuntimeConfiguration</a> -- Change how server processes are launched in
    /// the fleet, including launch path, launch parameters, and the number of concurrent
    /// processes.
    /// </para></li><li><para><a>PutScalingPolicy</a> -- Create or update rules that are used to set the fleet's
    /// capacity (autoscaling).
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "GMLFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.FleetAttributes")]
    [AWSCmdlet("Invokes the CreateFleet operation against Amazon GameLift Service.", Operation = new[] {"CreateFleet"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.FleetAttributes",
        "This cmdlet returns a FleetAttributes object.",
        "The service call response (type Amazon.GameLift.Model.CreateFleetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLFleetCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter BuildId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a build to be deployed on the new fleet. The build must have
        /// been successfully uploaded to Amazon GameLift and be in a <code>READY</code> status.
        /// This fleet setting cannot be changed once the fleet is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BuildId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Human-readable description of a fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EC2InboundPermission
        /// <summary>
        /// <para>
        /// <para>Range of IP addresses and port settings that permit inbound traffic to access server
        /// processes running on the fleet. If no inbound permissions are set, including both
        /// IP address range and port range, the server processes in the fleet cannot accept connections.
        /// You can specify one or more sets of permissions for a fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EC2InboundPermissions")]
        public Amazon.GameLift.Model.IpPermission[] EC2InboundPermission { get; set; }
        #endregion
        
        #region Parameter EC2InstanceType
        /// <summary>
        /// <para>
        /// <para>Name of an EC2 instance type that is supported in Amazon GameLift. A fleet instance
        /// type determines the computing resources of each instance in the fleet, including CPU,
        /// memory, storage, and networking capacity. Amazon GameLift supports the following EC2
        /// instance types. See <a href="http://aws.amazon.com/ec2/instance-types/">Amazon EC2
        /// Instance Types</a> for detailed descriptions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GameLift.EC2InstanceType")]
        public Amazon.GameLift.EC2InstanceType EC2InstanceType { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration_GameSessionActivationTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>Maximum amount of time (in seconds) that a game session can remain in status ACTIVATING.
        /// If the game session is not active before the timeout, activation is terminated and
        /// the game session status is changed to TERMINATED.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RuntimeConfiguration_GameSessionActivationTimeoutSeconds")]
        public System.Int32 RuntimeConfiguration_GameSessionActivationTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter LogPath
        /// <summary>
        /// <para>
        /// <para>This parameter is no longer used. Instead, to specify where Amazon GameLift should
        /// store log files once a server process shuts down, use the Amazon GameLift server API
        /// <code>ProcessReady()</code> and specify one or more directory paths in <code>logParameters</code>.
        /// See more information in the <a href="http://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-api-ref.html#gamelift-sdk-server-api-ref-dataypes-process">Server
        /// API Reference</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LogPaths")]
        public System.String[] LogPath { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration_MaxConcurrentGameSessionActivation
        /// <summary>
        /// <para>
        /// <para>Maximum number of game sessions with status ACTIVATING to allow on an instance simultaneously.
        /// This setting limits the amount of instance resources that can be used for new game
        /// activations at any one time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RuntimeConfiguration_MaxConcurrentGameSessionActivations")]
        public System.Int32 RuntimeConfiguration_MaxConcurrentGameSessionActivation { get; set; }
        #endregion
        
        #region Parameter MetricGroup
        /// <summary>
        /// <para>
        /// <para>Names of metric groups to add this fleet to. Use an existing metric group name to
        /// add this fleet to the group, or use a new name to create a new metric group. Currently,
        /// a fleet can only be included in one metric group at a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MetricGroups")]
        public System.String[] MetricGroup { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Descriptive label that is associated with a fleet. Fleet names do not need to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NewGameSessionProtectionPolicy
        /// <summary>
        /// <para>
        /// <para>Game session protection policy to apply to all instances in this fleet. If this parameter
        /// is not set, instances in this fleet default to no protection. You can change a fleet's
        /// protection policy using UpdateFleetAttributes, but this change will only affect sessions
        /// created after the policy change. You can also set protection for individual instances
        /// using <a>UpdateGameSession</a>.</para><ul><li><para><b>NoProtection</b> – The game session can be terminated during a scale-down event.</para></li><li><para><b>FullProtection</b> – If the game session is in an <code>ACTIVE</code> status,
        /// it cannot be terminated during a scale-down event.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GameLift.ProtectionPolicy")]
        public Amazon.GameLift.ProtectionPolicy NewGameSessionProtectionPolicy { get; set; }
        #endregion
        
        #region Parameter ResourceCreationLimitPolicy_NewGameSessionsPerCreator
        /// <summary>
        /// <para>
        /// <para>Maximum number of game sessions that an individual can create during the policy period.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ResourceCreationLimitPolicy_NewGameSessionsPerCreator { get; set; }
        #endregion
        
        #region Parameter ResourceCreationLimitPolicy_PolicyPeriodInMinute
        /// <summary>
        /// <para>
        /// <para>Time span used in evaluating the resource creation limit policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceCreationLimitPolicy_PolicyPeriodInMinutes")]
        public System.Int32 ResourceCreationLimitPolicy_PolicyPeriodInMinute { get; set; }
        #endregion
        
        #region Parameter ServerLaunchParameter
        /// <summary>
        /// <para>
        /// <para>This parameter is no longer used. Instead, specify server launch parameters in the
        /// <code>RuntimeConfiguration</code> parameter. (Requests that specify a server launch
        /// path and launch parameters instead of a runtime configuration will continue to work.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ServerLaunchParameters")]
        public System.String ServerLaunchParameter { get; set; }
        #endregion
        
        #region Parameter ServerLaunchPath
        /// <summary>
        /// <para>
        /// <para>This parameter is no longer used. Instead, specify a server launch path using the
        /// <code>RuntimeConfiguration</code> parameter. (Requests that specify a server launch
        /// path and launch parameters instead of a runtime configuration will continue to work.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServerLaunchPath { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration_ServerProcess
        /// <summary>
        /// <para>
        /// <para>Collection of server process configurations that describe which server processes to
        /// run on each instance in a fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RuntimeConfiguration_ServerProcesses")]
        public Amazon.GameLift.Model.ServerProcess[] RuntimeConfiguration_ServerProcess { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLFleet (CreateFleet)"))
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
            
            context.BuildId = this.BuildId;
            context.Description = this.Description;
            if (this.EC2InboundPermission != null)
            {
                context.EC2InboundPermissions = new List<Amazon.GameLift.Model.IpPermission>(this.EC2InboundPermission);
            }
            context.EC2InstanceType = this.EC2InstanceType;
            if (this.LogPath != null)
            {
                context.LogPaths = new List<System.String>(this.LogPath);
            }
            if (this.MetricGroup != null)
            {
                context.MetricGroups = new List<System.String>(this.MetricGroup);
            }
            context.Name = this.Name;
            context.NewGameSessionProtectionPolicy = this.NewGameSessionProtectionPolicy;
            if (ParameterWasBound("ResourceCreationLimitPolicy_NewGameSessionsPerCreator"))
                context.ResourceCreationLimitPolicy_NewGameSessionsPerCreator = this.ResourceCreationLimitPolicy_NewGameSessionsPerCreator;
            if (ParameterWasBound("ResourceCreationLimitPolicy_PolicyPeriodInMinute"))
                context.ResourceCreationLimitPolicy_PolicyPeriodInMinutes = this.ResourceCreationLimitPolicy_PolicyPeriodInMinute;
            if (ParameterWasBound("RuntimeConfiguration_GameSessionActivationTimeoutSecond"))
                context.RuntimeConfiguration_GameSessionActivationTimeoutSeconds = this.RuntimeConfiguration_GameSessionActivationTimeoutSecond;
            if (ParameterWasBound("RuntimeConfiguration_MaxConcurrentGameSessionActivation"))
                context.RuntimeConfiguration_MaxConcurrentGameSessionActivations = this.RuntimeConfiguration_MaxConcurrentGameSessionActivation;
            if (this.RuntimeConfiguration_ServerProcess != null)
            {
                context.RuntimeConfiguration_ServerProcesses = new List<Amazon.GameLift.Model.ServerProcess>(this.RuntimeConfiguration_ServerProcess);
            }
            context.ServerLaunchParameters = this.ServerLaunchParameter;
            context.ServerLaunchPath = this.ServerLaunchPath;
            
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
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EC2InboundPermissions != null)
            {
                request.EC2InboundPermissions = cmdletContext.EC2InboundPermissions;
            }
            if (cmdletContext.EC2InstanceType != null)
            {
                request.EC2InstanceType = cmdletContext.EC2InstanceType;
            }
            if (cmdletContext.LogPaths != null)
            {
                request.LogPaths = cmdletContext.LogPaths;
            }
            if (cmdletContext.MetricGroups != null)
            {
                request.MetricGroups = cmdletContext.MetricGroups;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NewGameSessionProtectionPolicy != null)
            {
                request.NewGameSessionProtectionPolicy = cmdletContext.NewGameSessionProtectionPolicy;
            }
            
             // populate ResourceCreationLimitPolicy
            bool requestResourceCreationLimitPolicyIsNull = true;
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
            if (cmdletContext.ResourceCreationLimitPolicy_PolicyPeriodInMinutes != null)
            {
                requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_PolicyPeriodInMinute = cmdletContext.ResourceCreationLimitPolicy_PolicyPeriodInMinutes.Value;
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
            bool requestRuntimeConfigurationIsNull = true;
            request.RuntimeConfiguration = new Amazon.GameLift.Model.RuntimeConfiguration();
            System.Int32? requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond = null;
            if (cmdletContext.RuntimeConfiguration_GameSessionActivationTimeoutSeconds != null)
            {
                requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond = cmdletContext.RuntimeConfiguration_GameSessionActivationTimeoutSeconds.Value;
            }
            if (requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond != null)
            {
                request.RuntimeConfiguration.GameSessionActivationTimeoutSeconds = requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond.Value;
                requestRuntimeConfigurationIsNull = false;
            }
            System.Int32? requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation = null;
            if (cmdletContext.RuntimeConfiguration_MaxConcurrentGameSessionActivations != null)
            {
                requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation = cmdletContext.RuntimeConfiguration_MaxConcurrentGameSessionActivations.Value;
            }
            if (requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation != null)
            {
                request.RuntimeConfiguration.MaxConcurrentGameSessionActivations = requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation.Value;
                requestRuntimeConfigurationIsNull = false;
            }
            List<Amazon.GameLift.Model.ServerProcess> requestRuntimeConfiguration_runtimeConfiguration_ServerProcess = null;
            if (cmdletContext.RuntimeConfiguration_ServerProcesses != null)
            {
                requestRuntimeConfiguration_runtimeConfiguration_ServerProcess = cmdletContext.RuntimeConfiguration_ServerProcesses;
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
            if (cmdletContext.ServerLaunchParameters != null)
            {
                request.ServerLaunchParameters = cmdletContext.ServerLaunchParameters;
            }
            if (cmdletContext.ServerLaunchPath != null)
            {
                request.ServerLaunchPath = cmdletContext.ServerLaunchPath;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.FleetAttributes;
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
        
        private Amazon.GameLift.Model.CreateFleetResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "CreateFleet");
            #if DESKTOP
            return client.CreateFleet(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateFleetAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String BuildId { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.GameLift.Model.IpPermission> EC2InboundPermissions { get; set; }
            public Amazon.GameLift.EC2InstanceType EC2InstanceType { get; set; }
            public List<System.String> LogPaths { get; set; }
            public List<System.String> MetricGroups { get; set; }
            public System.String Name { get; set; }
            public Amazon.GameLift.ProtectionPolicy NewGameSessionProtectionPolicy { get; set; }
            public System.Int32? ResourceCreationLimitPolicy_NewGameSessionsPerCreator { get; set; }
            public System.Int32? ResourceCreationLimitPolicy_PolicyPeriodInMinutes { get; set; }
            public System.Int32? RuntimeConfiguration_GameSessionActivationTimeoutSeconds { get; set; }
            public System.Int32? RuntimeConfiguration_MaxConcurrentGameSessionActivations { get; set; }
            public List<Amazon.GameLift.Model.ServerProcess> RuntimeConfiguration_ServerProcesses { get; set; }
            public System.String ServerLaunchParameters { get; set; }
            public System.String ServerLaunchPath { get; set; }
        }
        
    }
}
