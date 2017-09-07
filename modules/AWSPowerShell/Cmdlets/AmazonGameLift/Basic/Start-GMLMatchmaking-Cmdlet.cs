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
    /// Uses FlexMatch to create a game match for a group of players based on custom matchmaking
    /// rules, and starts a new game for the matched players. Each matchmaking request specifies
    /// the type of match to build (team configuration, rules for an acceptable match, etc.).
    /// The request also specifies the players to find a match for and where to host the new
    /// game session for optimal performance. A matchmaking request might start with a single
    /// player or a group of players who want to play together. FlexMatch finds additional
    /// players as needed to fill the match. Match type, rules, and the queue used to place
    /// a new game session are defined in a <code>MatchmakingConfiguration</code>. For complete
    /// information on setting up and using FlexMatch, see the topic <a href="http://docs.aws.amazon.com/gamelift/latest/developerguide/match-intro.html">
    /// Adding FlexMatch to Your Game</a>.
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
    /// </para></li></ol><para>
    /// Matchmaking-related operations include:
    /// </para><ul><li><para><a>StartMatchmaking</a></para></li><li><para><a>DescribeMatchmaking</a></para></li><li><para><a>StopMatchmaking</a></para></li><li><para><a>AcceptMatch</a></para></li></ul>
    /// </summary>
    [Cmdlet("Start", "GMLMatchmaking", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.MatchmakingTicket")]
    [AWSCmdlet("Invokes the StartMatchmaking operation against Amazon GameLift Service.", Operation = new[] {"StartMatchmaking"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.MatchmakingTicket",
        "This cmdlet returns a MatchmakingTicket object.",
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
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
        [System.Management.Automation.Parameter]
        [Alias("Players")]
        public Amazon.GameLift.Model.Player[] Player { get; set; }
        #endregion
        
        #region Parameter TicketId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a matchmaking ticket. Use this identifier to track the matchmaking
        /// ticket status and retrieve match results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TicketId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ConfigurationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-GMLMatchmaking (StartMatchmaking)"))
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
            
            context.ConfigurationName = this.ConfigurationName;
            if (this.Player != null)
            {
                context.Players = new List<Amazon.GameLift.Model.Player>(this.Player);
            }
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
            if (cmdletContext.Players != null)
            {
                request.Players = cmdletContext.Players;
            }
            if (cmdletContext.TicketId != null)
            {
                request.TicketId = cmdletContext.TicketId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.MatchmakingTicket;
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
        
        private Amazon.GameLift.Model.StartMatchmakingResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.StartMatchmakingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "StartMatchmaking");
            try
            {
                #if DESKTOP
                return client.StartMatchmaking(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StartMatchmakingAsync(request);
                return task.Result;
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
            public List<Amazon.GameLift.Model.Player> Players { get; set; }
            public System.String TicketId { get; set; }
        }
        
    }
}
