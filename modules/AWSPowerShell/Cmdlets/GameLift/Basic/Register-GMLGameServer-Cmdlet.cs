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
    /// <b>This operation is used with the Amazon GameLift FleetIQ solution and game server
    /// groups.</b><para>
    /// Creates a new game server resource and notifies Amazon GameLift FleetIQ that the game
    /// server is ready to host gameplay and players. This operation is called by a game server
    /// process that is running on an instance in a game server group. Registering game servers
    /// enables Amazon GameLift FleetIQ to track available game servers and enables game clients
    /// and services to claim a game server for a new game session. 
    /// </para><para>
    /// To register a game server, identify the game server group and instance where the game
    /// server is running, and provide a unique identifier for the game server. You can also
    /// include connection and game server data.
    /// </para><para>
    /// Once a game server is successfully registered, it is put in status <c>AVAILABLE</c>.
    /// A request to register a game server may fail if the instance it is running on is in
    /// the process of shutting down as part of instance balancing or scale-down activity.
    /// 
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/fleetiqguide/gsg-intro.html">Amazon
    /// GameLift FleetIQ Guide</a></para>
    /// </summary>
    [Cmdlet("Register", "GMLGameServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameServer")]
    [AWSCmdlet("Calls the Amazon GameLift Service RegisterGameServer API operation.", Operation = new[] {"RegisterGameServer"}, SelectReturnType = typeof(Amazon.GameLift.Model.RegisterGameServerResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameServer or Amazon.GameLift.Model.RegisterGameServerResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GameServer object.",
        "The service call response (type Amazon.GameLift.Model.RegisterGameServerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterGMLGameServerCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectionInfo
        /// <summary>
        /// <para>
        /// <para>Information that is needed to make inbound client connections to the game server.
        /// This might include the IP address and port, DNS name, and other information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionInfo { get; set; }
        #endregion
        
        #region Parameter GameServerData
        /// <summary>
        /// <para>
        /// <para>A set of custom game server properties, formatted as a single string value. This data
        /// is passed to a game client or service when it requests information on game servers.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameServerData { get; set; }
        #endregion
        
        #region Parameter GameServerGroupName
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the game server group where the game server is running.</para>
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
        public System.String GameServerGroupName { get; set; }
        #endregion
        
        #region Parameter GameServerId
        /// <summary>
        /// <para>
        /// <para>A custom string that uniquely identifies the game server to register. Game server
        /// IDs are developer-defined and must be unique across all game server groups in your
        /// Amazon Web Services account.</para>
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
        public System.String GameServerId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the instance where the game server is running. This ID is
        /// available in the instance metadata. EC2 instance IDs use a 17-character format, for
        /// example: <c>i-1234567890abcdef0</c>.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GameServer'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.RegisterGameServerResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.RegisterGameServerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GameServer";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GameServerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-GMLGameServer (RegisterGameServer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.RegisterGameServerResponse, RegisterGMLGameServerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectionInfo = this.ConnectionInfo;
            context.GameServerData = this.GameServerData;
            context.GameServerGroupName = this.GameServerGroupName;
            #if MODULAR
            if (this.GameServerGroupName == null && ParameterWasBound(nameof(this.GameServerGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter GameServerGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GameServerId = this.GameServerId;
            #if MODULAR
            if (this.GameServerId == null && ParameterWasBound(nameof(this.GameServerId)))
            {
                WriteWarning("You are passing $null as a value for parameter GameServerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.GameLift.Model.RegisterGameServerRequest();
            
            if (cmdletContext.ConnectionInfo != null)
            {
                request.ConnectionInfo = cmdletContext.ConnectionInfo;
            }
            if (cmdletContext.GameServerData != null)
            {
                request.GameServerData = cmdletContext.GameServerData;
            }
            if (cmdletContext.GameServerGroupName != null)
            {
                request.GameServerGroupName = cmdletContext.GameServerGroupName;
            }
            if (cmdletContext.GameServerId != null)
            {
                request.GameServerId = cmdletContext.GameServerId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
        
        private Amazon.GameLift.Model.RegisterGameServerResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.RegisterGameServerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "RegisterGameServer");
            try
            {
                #if DESKTOP
                return client.RegisterGameServer(request);
                #elif CORECLR
                return client.RegisterGameServerAsync(request).GetAwaiter().GetResult();
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
            public System.String ConnectionInfo { get; set; }
            public System.String GameServerData { get; set; }
            public System.String GameServerGroupName { get; set; }
            public System.String GameServerId { get; set; }
            public System.String InstanceId { get; set; }
            public System.Func<Amazon.GameLift.Model.RegisterGameServerResponse, RegisterGMLGameServerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameServer;
        }
        
    }
}
