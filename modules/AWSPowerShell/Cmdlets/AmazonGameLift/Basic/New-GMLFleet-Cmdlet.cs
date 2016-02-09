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
    /// Creates a new fleet to host game servers. A fleet consists of a set of Amazon Elastic
    /// Compute Cloud (Amazon EC2) instances of a certain type, which defines the CPU, memory,
    /// storage, and networking capacity of each host in the fleet. See <a href="https://aws.amazon.com/ec2/instance-types/">Amazon
    /// EC2 Instance Types</a> for more information. Each instance in the fleet hosts a game
    /// server created from the specified game build. Once a fleet is in an ACTIVE state,
    /// it can begin hosting game sessions.
    /// 
    ///  
    /// <para>
    /// To create a new fleet, provide a name and the EC2 instance type for the new fleet,
    /// and specify the build and server launch path. Builds must be in a READY state before
    /// they can be used to build fleets. When configuring the new fleet, you can optionally
    /// (1) provide a set of launch parameters to be passed to a game server when activated;
    /// (2) limit incoming traffic to a specified range of IP addresses and port numbers;
    /// and (3) configure Amazon GameLift to store game session logs by specifying the path
    /// to the logs stored in your game server files. If the call is successful, Amazon GameLift
    /// performs the following tasks:
    /// </para><ul><li>Creates a fleet record and sets the state to NEW.</li><li>Sets the fleet's
    /// capacity to 1 "desired" and 1 "active" EC2 instance count.</li><li>Creates an EC2
    /// instance and begins the process of initializing the fleet and activating a game server
    /// on the instance.</li><li>Begins writing events to the fleet event log, which can
    /// be accessed in the GameLift console.</li></ul><para>
    /// Once a fleet is created, use the following actions to change certain fleet properties
    /// (server launch parameters and log paths cannot be changed):
    /// </para><ul><li><a>UpdateFleetAttributes</a> -- Update fleet metadata, including name and
    /// description.</li><li><a>UpdateFleetCapacity</a> -- Increase or decrease the number
    /// of instances you want the fleet to maintain.</li><li><a>UpdateFleetPortSettings</a>
    /// -- Change the IP addresses and ports that allow access to incoming traffic.</li></ul>
    /// </summary>
    [Cmdlet("New", "GMLFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.FleetAttributes")]
    [AWSCmdlet("Invokes the CreateFleet operation against Amazon GameLift Service.", Operation = new[] {"CreateFleet"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.FleetAttributes",
        "This cmdlet returns a FleetAttributes object.",
        "The service call response (type Amazon.GameLift.Model.CreateFleetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewGMLFleetCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter BuildId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for the build you want the new fleet to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BuildId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Human-readable description of the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EC2InboundPermission
        /// <summary>
        /// <para>
        /// <para>Access limits for incoming traffic. Setting these values limits game server access
        /// to incoming traffic using specified IP ranges and port numbers. Some ports in a range
        /// may be restricted. You can provide one or more sets of permissions for the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EC2InboundPermissions")]
        public Amazon.GameLift.Model.IpPermission[] EC2InboundPermission { get; set; }
        #endregion
        
        #region Parameter EC2InstanceType
        /// <summary>
        /// <para>
        /// <para>Type of EC2 instances used in the fleet. EC2 instance types define the CPU, memory,
        /// storage, and networking capacity of the fleetaposs hosts. Amazon GameLift supports
        /// the EC2 instance types listed below. See <a href="https://aws.amazon.com/ec2/instance-types/">Amazon
        /// EC2 Instance Types</a> for detailed descriptions of each.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GameLift.EC2InstanceType")]
        public Amazon.GameLift.EC2InstanceType EC2InstanceType { get; set; }
        #endregion
        
        #region Parameter LogPath
        /// <summary>
        /// <para>
        /// <para>Path to game-session log files generated by your game server. Once a game session
        /// has been terminated, Amazon GameLift captures and stores the logs on Amazon S3. Use
        /// the GameLift console to access the stored logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LogPaths")]
        public System.String[] LogPath { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Descriptive label associated with this fleet. Fleet names do not need to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ServerLaunchParameter
        /// <summary>
        /// <para>
        /// <para>Parameters required to launch your game server. These parameters should be expressed
        /// as a string of command-line parameters. Example: "+sv_port 33435 +start_lobby".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ServerLaunchParameters")]
        public System.String ServerLaunchParameter { get; set; }
        #endregion
        
        #region Parameter ServerLaunchPath
        /// <summary>
        /// <para>
        /// <para>Path to the launch executable for the game server. A game server is built into a <code>C:\game</code>
        /// drive. This value must be expressed as <code>C:\game\[launchpath]</code>. Example:
        /// If, when built, your game server files are in a folder called "MyGame", your log path
        /// should be <code>C:\game\MyGame\server.exe</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServerLaunchPath { get; set; }
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
            context.Name = this.Name;
            context.ServerLaunchParameters = this.ServerLaunchParameter;
            context.ServerLaunchPath = this.ServerLaunchPath;
            
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
                var response = client.CreateFleet(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String BuildId { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.GameLift.Model.IpPermission> EC2InboundPermissions { get; set; }
            public Amazon.GameLift.EC2InstanceType EC2InstanceType { get; set; }
            public List<System.String> LogPaths { get; set; }
            public System.String Name { get; set; }
            public System.String ServerLaunchParameters { get; set; }
            public System.String ServerLaunchPath { get; set; }
        }
        
    }
}
