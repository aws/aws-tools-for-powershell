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
    /// Uses FlexMatch to create a game match for a group of players based on custom matchmaking
    /// rules. With games that use Amazon GameLift managed hosting, this operation also triggers
    /// Amazon GameLift to find hosting resources and start a new game session for the new
    /// match. Each matchmaking request includes information on one or more players and specifies
    /// the FlexMatch matchmaker to use. When a request is for multiple players, FlexMatch
    /// attempts to build a match that includes all players in the request, placing them in
    /// the same team and finding additional players as needed to fill the match. 
    /// 
    ///  
    /// <para>
    /// To start matchmaking, provide a unique ticket ID, specify a matchmaking configuration,
    /// and include the players to be matched. You must also include any player attributes
    /// that are required by the matchmaking configuration's rule set. If successful, a matchmaking
    /// ticket is returned with status set to <c>QUEUED</c>. 
    /// </para><para>
    /// Track matchmaking events to respond as needed and acquire game session connection
    /// information for successfully completed matches. Ticket status updates are tracked
    /// using event notification through Amazon Simple Notification Service, which is defined
    /// in the matchmaking configuration.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-client.html">
    /// Add FlexMatch to a game client</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-notification.html">
    /// Set Up FlexMatch event notification</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/gamelift-match.html">
    /// How Amazon GameLift FlexMatch works</a></para>
    /// </summary>
    [Cmdlet("Start", "GMLMatchmaking", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.MatchmakingTicket")]
    [AWSCmdlet("Calls the Amazon GameLift Service StartMatchmaking API operation.", Operation = new[] {"StartMatchmaking"}, SelectReturnType = typeof(Amazon.GameLift.Model.StartMatchmakingResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.MatchmakingTicket or Amazon.GameLift.Model.StartMatchmakingResponse",
        "This cmdlet returns an Amazon.GameLift.Model.MatchmakingTicket object.",
        "The service call response (type Amazon.GameLift.Model.StartMatchmakingResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartGMLMatchmakingCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigurationName
        /// <summary>
        /// <para>
        /// <para>Name of the matchmaking configuration to use for this request. Matchmaking configurations
        /// must exist in the same Region as this request. You can use either the configuration
        /// name or ARN value.</para>
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
        public System.String ConfigurationName { get; set; }
        #endregion
        
        #region Parameter Player
        /// <summary>
        /// <para>
        /// <para>Information on each player to be matched. This information must include a player ID,
        /// and may contain player attributes and latency data to be used in the matchmaking process.
        /// After a successful match, <c>Player</c> objects contain the name of the team the player
        /// is assigned to.</para><para>You can include up to 10 <c>Players</c> in a <c>StartMatchmaking</c> request.</para>
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
        [Alias("Players")]
        public Amazon.GameLift.Model.Player[] Player { get; set; }
        #endregion
        
        #region Parameter TicketId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a matchmaking ticket. If no ticket ID is specified here, Amazon
        /// GameLift will generate one in the form of a UUID. Use this identifier to track the
        /// matchmaking ticket status and retrieve match results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TicketId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MatchmakingTicket'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.StartMatchmakingResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.StartMatchmakingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MatchmakingTicket";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-GMLMatchmaking (StartMatchmaking)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.StartMatchmakingResponse, StartGMLMatchmakingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationName = this.ConfigurationName;
            #if MODULAR
            if (this.ConfigurationName == null && ParameterWasBound(nameof(this.ConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Player != null)
            {
                context.Player = new List<Amazon.GameLift.Model.Player>(this.Player);
            }
            #if MODULAR
            if (this.Player == null && ParameterWasBound(nameof(this.Player)))
            {
                WriteWarning("You are passing $null as a value for parameter Player which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TicketId = this.TicketId;
            
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
            var request = new Amazon.GameLift.Model.StartMatchmakingRequest();
            
            if (cmdletContext.ConfigurationName != null)
            {
                request.ConfigurationName = cmdletContext.ConfigurationName;
            }
            if (cmdletContext.Player != null)
            {
                request.Players = cmdletContext.Player;
            }
            if (cmdletContext.TicketId != null)
            {
                request.TicketId = cmdletContext.TicketId;
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
        
        private Amazon.GameLift.Model.StartMatchmakingResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.StartMatchmakingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "StartMatchmaking");
            try
            {
                #if DESKTOP
                return client.StartMatchmaking(request);
                #elif CORECLR
                return client.StartMatchmakingAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigurationName { get; set; }
            public List<Amazon.GameLift.Model.Player> Player { get; set; }
            public System.String TicketId { get; set; }
            public System.Func<Amazon.GameLift.Model.StartMatchmakingResponse, StartGMLMatchmakingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MatchmakingTicket;
        }
        
    }
}
