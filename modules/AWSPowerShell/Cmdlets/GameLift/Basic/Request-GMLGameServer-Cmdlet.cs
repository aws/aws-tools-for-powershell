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
    /// <b>This operation is used with the Amazon GameLift FleetIQ solution and game server
    /// groups.</b><para>
    /// Locates an available game server and temporarily reserves it to host gameplay and
    /// players. This operation is called from a game client or client service (such as a
    /// matchmaker) to request hosting resources for a new game session. In response, Amazon
    /// GameLift FleetIQ locates an available game server, places it in <c>CLAIMED</c> status
    /// for 60 seconds, and returns connection information that players can use to connect
    /// to the game server. 
    /// </para><para>
    /// To claim a game server, identify a game server group. You can also specify a game
    /// server ID, although this approach bypasses Amazon GameLift FleetIQ placement optimization.
    /// Optionally, include game data to pass to the game server at the start of a game session,
    /// such as a game map or player information. Add filter options to further restrict how
    /// a game server is chosen, such as only allowing game servers on <c>ACTIVE</c> instances
    /// to be claimed.
    /// </para><para>
    /// When a game server is successfully claimed, connection information is returned. A
    /// claimed game server's utilization status remains <c>AVAILABLE</c> while the claim
    /// status is set to <c>CLAIMED</c> for up to 60 seconds. This time period gives the game
    /// server time to update its status to <c>UTILIZED</c> after players join. If the game
    /// server's status is not updated within 60 seconds, the game server reverts to unclaimed
    /// status and is available to be claimed by another request. The claim time period is
    /// a fixed value and is not configurable.
    /// </para><para>
    /// If you try to claim a specific game server, this request will fail in the following
    /// cases:
    /// </para><ul><li><para>
    /// If the game server utilization status is <c>UTILIZED</c>.
    /// </para></li><li><para>
    /// If the game server claim status is <c>CLAIMED</c>.
    /// </para></li><li><para>
    /// If the game server is running on an instance in <c>DRAINING</c> status and the provided
    /// filter option does not allow placing on <c>DRAINING</c> instances.
    /// </para></li></ul><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/fleetiqguide/gsg-intro.html">Amazon
    /// GameLift FleetIQ Guide</a></para>
    /// </summary>
    [Cmdlet("Request", "GMLGameServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameServer")]
    [AWSCmdlet("Calls the Amazon GameLift Service ClaimGameServer API operation.", Operation = new[] {"ClaimGameServer"}, SelectReturnType = typeof(Amazon.GameLift.Model.ClaimGameServerResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameServer or Amazon.GameLift.Model.ClaimGameServerResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GameServer object.",
        "The service call response (type Amazon.GameLift.Model.ClaimGameServerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RequestGMLGameServerCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// <para>A unique identifier for the game server group where the game server is running. If
        /// you are not specifying a game server to claim, this value identifies where you want
        /// Amazon GameLift FleetIQ to look for an available game server to claim. </para>
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
        /// is left empty, Amazon GameLift FleetIQ searches for an available game server in the
        /// specified game server group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameServerId { get; set; }
        #endregion
        
        #region Parameter FilterOption_InstanceStatus
        /// <summary>
        /// <para>
        /// <para>List of instance statuses that game servers may be claimed on. If provided, the list
        /// must contain the <c>ACTIVE</c> status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterOption_InstanceStatuses")]
        public System.String[] FilterOption_InstanceStatus { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-GMLGameServer (ClaimGameServer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.ClaimGameServerResponse, RequestGMLGameServerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.FilterOption_InstanceStatus != null)
            {
                context.FilterOption_InstanceStatus = new List<System.String>(this.FilterOption_InstanceStatus);
            }
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
            
            
             // populate FilterOption
            var requestFilterOptionIsNull = true;
            request.FilterOption = new Amazon.GameLift.Model.ClaimFilterOption();
            List<System.String> requestFilterOption_filterOption_InstanceStatus = null;
            if (cmdletContext.FilterOption_InstanceStatus != null)
            {
                requestFilterOption_filterOption_InstanceStatus = cmdletContext.FilterOption_InstanceStatus;
            }
            if (requestFilterOption_filterOption_InstanceStatus != null)
            {
                request.FilterOption.InstanceStatuses = requestFilterOption_filterOption_InstanceStatus;
                requestFilterOptionIsNull = false;
            }
             // determine if request.FilterOption should be set to null
            if (requestFilterOptionIsNull)
            {
                request.FilterOption = null;
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
            public List<System.String> FilterOption_InstanceStatus { get; set; }
            public System.String GameServerData { get; set; }
            public System.String GameServerGroupName { get; set; }
            public System.String GameServerId { get; set; }
            public System.Func<Amazon.GameLift.Model.ClaimGameServerResponse, RequestGMLGameServerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameServer;
        }
        
    }
}
