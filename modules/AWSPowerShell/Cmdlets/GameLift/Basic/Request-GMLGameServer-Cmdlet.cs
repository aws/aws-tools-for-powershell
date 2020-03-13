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
    /// <b>This action is part of Amazon GameLift FleetIQ with game server groups, which
    /// is in preview release and is subject to change.</b><para>
    /// Locates an available game server and temporarily reserves it to host gameplay and
    /// players. This action is called by a game client or client service (such as a matchmaker)
    /// to request hosting resources for a new game session. In response, GameLift FleetIQ
    /// searches for an available game server in the specified game server group, places the
    /// game server in "claimed" status for 60 seconds, and returns connection information
    /// back to the requester so that players can connect to the game server. 
    /// </para><para>
    /// There are two ways you can claim a game server. For the first option, you provide
    /// a game server group ID only, which prompts GameLift FleetIQ to search for an available
    /// game server in the specified group and claim it. With this option, GameLift FleetIQ
    /// attempts to consolidate gameplay on as few instances as possible to minimize hosting
    /// costs. For the second option, you request a specific game server by its ID. This option
    /// results in a less efficient claiming process because it does not take advantage of
    /// consolidation and may fail if the requested game server is unavailable. 
    /// </para><para>
    /// To claim a game server, identify a game server group and (optionally) a game server
    /// ID. If your game requires that game data be provided to the game server at the start
    /// of a game, such as a game map or player information, you can provide it in your claim
    /// request. 
    /// </para><para>
    /// When a game server is successfully claimed, connection information is returned. A
    /// claimed game server's utilization status remains AVAILABLE, while the claim status
    /// is set to CLAIMED for up to 60 seconds. This time period allows the game server to
    /// be prompted to update its status to UTILIZED (using <a>UpdateGameServer</a>). If the
    /// game server's status is not updated within 60 seconds, the game server reverts to
    /// unclaimed status and is available to be claimed by another request.
    /// </para><para>
    /// If you try to claim a specific game server, this request will fail in the following
    /// cases: (1) if the game server utilization status is UTILIZED, (2) if the game server
    /// claim status is CLAIMED, or (3) if the instance that the game server is running on
    /// is flagged as draining.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gsg-intro.html">GameLift
    /// FleetIQ Guide</a></para><para><b>Related operations</b></para><ul><li><para><a>RegisterGameServer</a></para></li><li><para><a>ListGameServers</a></para></li><li><para><a>ClaimGameServer</a></para></li><li><para><a>DescribeGameServer</a></para></li><li><para><a>UpdateGameServer</a></para></li><li><para><a>DeregisterGameServer</a></para></li></ul>
    /// </summary>
    [Cmdlet("Request", "GMLGameServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameServer")]
    [AWSCmdlet("Calls the Amazon GameLift Service ClaimGameServer API operation.", Operation = new[] {"ClaimGameServer"}, SelectReturnType = typeof(Amazon.GameLift.Model.ClaimGameServerResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameServer or Amazon.GameLift.Model.ClaimGameServerResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GameServer object.",
        "The service call response (type Amazon.GameLift.Model.ClaimGameServerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RequestGMLGameServerCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter GameServerData
        /// <summary>
        /// <para>
        /// <para>A set of custom game server properties, formatted as a single string value, to be
        /// passed to the claimed game server. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameServerData { get; set; }
        #endregion
        
        #region Parameter GameServerGroupName
        /// <summary>
        /// <para>
        /// <para>An identifier for the game server group. When claiming a specific game server, this
        /// is the game server group whether the game server is located. When requesting that
        /// GameLift FleetIQ locate an available game server, this is the game server group to
        /// search on. You can use either the <a>GameServerGroup</a> name or ARN value.</para>
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
        
        #region Parameter GameServerId
        /// <summary>
        /// <para>
        /// <para>A custom string that uniquely identifies the game server to claim. If this parameter
        /// is left empty, GameLift FleetIQ searches for an available game server in the specified
        /// game server group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameServerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GameServer'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.ClaimGameServerResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.ClaimGameServerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GameServer";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GameServerGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-GMLGameServer (ClaimGameServer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.ClaimGameServerResponse, RequestGMLGameServerCmdlet>(Select) ??
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
            context.GameServerData = this.GameServerData;
            context.GameServerGroupName = this.GameServerGroupName;
            #if MODULAR
            if (this.GameServerGroupName == null && ParameterWasBound(nameof(this.GameServerGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter GameServerGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GameServerId = this.GameServerId;
            
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
            var request = new Amazon.GameLift.Model.ClaimGameServerRequest();
            
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
        
        private Amazon.GameLift.Model.ClaimGameServerResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.ClaimGameServerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "ClaimGameServer");
            try
            {
                #if DESKTOP
                return client.ClaimGameServer(request);
                #elif CORECLR
                return client.ClaimGameServerAsync(request).GetAwaiter().GetResult();
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
            public System.String GameServerData { get; set; }
            public System.String GameServerGroupName { get; set; }
            public System.String GameServerId { get; set; }
            public System.Func<Amazon.GameLift.Model.ClaimGameServerResponse, RequestGMLGameServerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameServer;
        }
        
    }
}
