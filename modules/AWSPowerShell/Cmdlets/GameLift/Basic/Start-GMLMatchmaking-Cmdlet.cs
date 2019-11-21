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
    /// Uses FlexMatch to create a game match for a group of players based on custom matchmaking
    /// rules, and starts a new game for the matched players. Each matchmaking request specifies
    /// the type of match to build (team configuration, rules for an acceptable match, etc.).
    /// The request also specifies the players to find a match for and where to host the new
    /// game session for optimal performance. A matchmaking request might start with a single
    /// player or a group of players who want to play together. FlexMatch finds additional
    /// players as needed to fill the match. Match type, rules, and the queue used to place
    /// a new game session are defined in a <code>MatchmakingConfiguration</code>. 
    /// 
    ///  
    /// <para>
    /// To start matchmaking, provide a unique ticket ID, specify a matchmaking configuration,
    /// and include the players to be matched. You must also include a set of player attributes
    /// relevant for the matchmaking configuration. If successful, a matchmaking ticket is
    /// returned with status set to <code>QUEUED</code>. Track the status of the ticket to
    /// respond as needed and acquire game session connection information for successfully
    /// completed matches.
    /// </para><para><b>Tracking ticket status</b> -- A couple of options are available for tracking the
    /// status of matchmaking requests: 
    /// </para><ul><li><para>
    /// Polling -- Call <code>DescribeMatchmaking</code>. This operation returns the full
    /// ticket object, including current status and (for completed tickets) game session connection
    /// info. We recommend polling no more than once every 10 seconds.
    /// </para></li><li><para>
    /// Notifications -- Get event notifications for changes in ticket status using Amazon
    /// Simple Notification Service (SNS). Notifications are easy to set up (see <a>CreateMatchmakingConfiguration</a>)
    /// and typically deliver match status changes faster and more efficiently than polling.
    /// We recommend that you use polling to back up to notifications (since delivery is not
    /// guaranteed) and call <code>DescribeMatchmaking</code> only when notifications are
    /// not received within 30 seconds.
    /// </para></li></ul><para><b>Processing a matchmaking request</b> -- FlexMatch handles a matchmaking request
    /// as follows: 
    /// </para><ol><li><para>
    /// Your client code submits a <code>StartMatchmaking</code> request for one or more players
    /// and tracks the status of the request ticket. 
    /// </para></li><li><para>
    /// FlexMatch uses this ticket and others in process to build an acceptable match. When
    /// a potential match is identified, all tickets in the proposed match are advanced to
    /// the next status. 
    /// </para></li><li><para>
    /// If the match requires player acceptance (set in the matchmaking configuration), the
    /// tickets move into status <code>REQUIRES_ACCEPTANCE</code>. This status triggers your
    /// client code to solicit acceptance from all players in every ticket involved in the
    /// match, and then call <a>AcceptMatch</a> for each player. If any player rejects or
    /// fails to accept the match before a specified timeout, the proposed match is dropped
    /// (see <code>AcceptMatch</code> for more details).
    /// </para></li><li><para>
    /// Once a match is proposed and accepted, the matchmaking tickets move into status <code>PLACING</code>.
    /// FlexMatch locates resources for a new game session using the game session queue (set
    /// in the matchmaking configuration) and creates the game session based on the match
    /// data. 
    /// </para></li><li><para>
    /// When the match is successfully placed, the matchmaking tickets move into <code>COMPLETED</code>
    /// status. Connection information (including game session endpoint and player session)
    /// is added to the matchmaking tickets. Matched players can use the connection information
    /// to join the game. 
    /// </para></li></ol><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/match-client.html">
    /// Add FlexMatch to a Game Client</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/match-notification.html">
    /// Set Up FlexMatch Event Notification</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/match-tasks.html">
    /// FlexMatch Integration Roadmap</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-match.html">
    /// How GameLift FlexMatch Works</a></para><para><b>Related operations</b></para><ul><li><para><a>StartMatchmaking</a></para></li><li><para><a>DescribeMatchmaking</a></para></li><li><para><a>StopMatchmaking</a></para></li><li><para><a>AcceptMatch</a></para></li><li><para><a>StartMatchBackfill</a></para></li></ul>
    /// </summary>
    [Cmdlet("Start", "GMLMatchmaking", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.MatchmakingTicket")]
    [AWSCmdlet("Calls the Amazon GameLift Service StartMatchmaking API operation.", Operation = new[] {"StartMatchmaking"}, SelectReturnType = typeof(Amazon.GameLift.Model.StartMatchmakingResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.MatchmakingTicket or Amazon.GameLift.Model.StartMatchmakingResponse",
        "This cmdlet returns an Amazon.GameLift.Model.MatchmakingTicket object.",
        "The service call response (type Amazon.GameLift.Model.StartMatchmakingResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartGMLMatchmakingCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationName
        /// <summary>
        /// <para>
        /// <para>Name of the matchmaking configuration to use for this request. Matchmaking configurations
        /// must exist in the same region as this request.</para>
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
        /// After a successful match, <code>Player</code> objects contain the name of the team
        /// the player is assigned to.</para>
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
        /// <para>Unique identifier for a matchmaking ticket. If no ticket ID is specified here, Amazon
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConfigurationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConfigurationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConfigurationName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-GMLMatchmaking (StartMatchmaking)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.StartMatchmakingResponse, StartGMLMatchmakingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConfigurationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
