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
using System.Threading;
using Amazon.GameLift;
using Amazon.GameLift.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Finds new players to fill open slots in currently running game sessions. The backfill
    /// match process is essentially identical to the process of forming new matches. Backfill
    /// requests use the same matchmaker that was used to make the original match, and they
    /// provide matchmaking data for all players currently in the game session. FlexMatch
    /// uses this information to select new players so that backfilled match continues to
    /// meet the original match requirements. 
    /// 
    ///  
    /// <para>
    /// When using FlexMatch with Amazon GameLift managed hosting, you can request a backfill
    /// match from a client service by calling this operation with a <c>GameSessions</c> ID.
    /// You also have the option of making backfill requests directly from your game server.
    /// In response to a request, FlexMatch creates player sessions for the new players, updates
    /// the <c>GameSession</c> resource, and sends updated matchmaking data to the game server.
    /// You can request a backfill match at any point after a game session is started. Each
    /// game session can have only one active backfill request at a time; a subsequent request
    /// automatically replaces the earlier request.
    /// </para><para>
    /// When using FlexMatch as a standalone component, request a backfill match by calling
    /// this operation without a game session identifier. As with newly formed matches, matchmaking
    /// results are returned in a matchmaking event so that your game can update the game
    /// session that is being backfilled.
    /// </para><para>
    /// To request a backfill match, specify a unique ticket ID, the original matchmaking
    /// configuration, and matchmaking data for all current players in the game session being
    /// backfilled. Optionally, specify the <c>GameSession</c> ARN. If successful, a match
    /// backfill ticket is created and returned with status set to QUEUED. Track the status
    /// of backfill tickets using the same method for tracking tickets for new matches.
    /// </para><para>
    /// Only game sessions created by FlexMatch are supported for match backfill.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-backfill.html">
    /// Backfill existing games with FlexMatch</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-events.html">
    /// Matchmaking events</a> (reference)
    /// </para><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/gamelift-match.html">
    /// How Amazon GameLift FlexMatch works</a></para>
    /// </summary>
    [Cmdlet("Start", "GMLMatchBackfill", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.MatchmakingTicket")]
    [AWSCmdlet("Calls the Amazon GameLift Service StartMatchBackfill API operation.", Operation = new[] {"StartMatchBackfill"}, SelectReturnType = typeof(Amazon.GameLift.Model.StartMatchBackfillResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.MatchmakingTicket or Amazon.GameLift.Model.StartMatchBackfillResponse",
        "This cmdlet returns an Amazon.GameLift.Model.MatchmakingTicket object.",
        "The service call response (type Amazon.GameLift.Model.StartMatchBackfillResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartGMLMatchBackfillCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigurationName
        /// <summary>
        /// <para>
        /// <para>Name of the matchmaker to use for this request. You can use either the configuration
        /// name or ARN value. The ARN of the matchmaker that was used with the original game
        /// session is listed in the <c>GameSession</c> object, <c>MatchmakerData</c> property.</para>
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
        public System.String ConfigurationName { get; set; }
        #endregion
        
        #region Parameter GameSessionArn
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the game session. Use the game session ID. When using FlexMatch
        /// as a standalone matchmaking solution, this parameter is not needed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GameSessionArn { get; set; }
        #endregion
        
        #region Parameter Player
        /// <summary>
        /// <para>
        /// <para>Match information on all players that are currently assigned to the game session.
        /// This information is used by the matchmaker to find new players and add them to the
        /// existing game.</para><para>You can include up to 199 <c>Players</c> in a <c>StartMatchBackfill</c> request.</para><ul><li><para>PlayerID, PlayerAttributes, Team -- This information is maintained in the <c>GameSession</c>
        /// object, <c>MatchmakerData</c> property, for all players who are currently assigned
        /// to the game session. The matchmaker data is in JSON syntax, formatted as a string.
        /// For more details, see <a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-server.html#match-server-data">
        /// Match Data</a>. </para><para>The backfill request must specify the team membership for every player. Do not specify
        /// team if you are not using backfill.</para></li><li><para>LatencyInMs -- If the matchmaker uses player latency, include a latency value, in
        /// milliseconds, for the Region that the game session is currently in. Do not include
        /// latency values for any other Region.</para></li></ul>
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
        /// match backfill ticket status and retrieve match results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TicketId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MatchmakingTicket'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.StartMatchBackfillResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.StartMatchBackfillResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GameSessionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-GMLMatchBackfill (StartMatchBackfill)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.StartMatchBackfillResponse, StartGMLMatchBackfillCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationName = this.ConfigurationName;
            #if MODULAR
            if (this.ConfigurationName == null && ParameterWasBound(nameof(this.ConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GameSessionArn = this.GameSessionArn;
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
            var request = new Amazon.GameLift.Model.StartMatchBackfillRequest();
            
            if (cmdletContext.ConfigurationName != null)
            {
                request.ConfigurationName = cmdletContext.ConfigurationName;
            }
            if (cmdletContext.GameSessionArn != null)
            {
                request.GameSessionArn = cmdletContext.GameSessionArn;
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
        
        private Amazon.GameLift.Model.StartMatchBackfillResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.StartMatchBackfillRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "StartMatchBackfill");
            try
            {
                return client.StartMatchBackfillAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GameSessionArn { get; set; }
            public List<Amazon.GameLift.Model.Player> Player { get; set; }
            public System.String TicketId { get; set; }
            public System.Func<Amazon.GameLift.Model.StartMatchBackfillResponse, StartGMLMatchBackfillCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MatchmakingTicket;
        }
        
    }
}
