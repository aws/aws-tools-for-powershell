/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Finds new players to fill open slots in an existing game session. This operation can
    /// be used to add players to matched games that start with fewer than the maximum number
    /// of players or to replace players when they drop out. By backfilling with the same
    /// matchmaker used to create the original match, you ensure that new players meet the
    /// match criteria and maintain a consistent experience throughout the game session. You
    /// can backfill a match anytime after a game session has been created. 
    /// 
    ///  
    /// <para>
    /// To request a match backfill, specify a unique ticket ID, the existing game session's
    /// ARN, a matchmaking configuration, and a set of data that describes all current players
    /// in the game session. If successful, a match backfill ticket is created and returned
    /// with status set to QUEUED. The ticket is placed in the matchmaker's ticket pool and
    /// processed. Track the status of the ticket to respond as needed. For more detail how
    /// to set up backfilling, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/match-backfill.html">
    /// Backfill Existing Games with FlexMatch</a>. 
    /// </para><para>
    /// The process of finding backfill matches is essentially identical to the initial matchmaking
    /// process. The matchmaker searches the pool and groups tickets together to form potential
    /// matches, allowing only one backfill ticket per potential match. Once the a match is
    /// formed, the matchmaker creates player sessions for the new players. All tickets in
    /// the match are updated with the game session's connection information, and the <a>GameSession</a>
    /// object is updated to include matchmaker data on the new players. For more detail on
    /// how match backfill requests are processed, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/match-intro.html">
    /// How Amazon GameLift FlexMatch Works</a>. 
    /// </para><ul><li><para><a>StartMatchmaking</a></para></li><li><para><a>DescribeMatchmaking</a></para></li><li><para><a>StopMatchmaking</a></para></li><li><para><a>AcceptMatch</a></para></li><li><para><a>StartMatchBackfill</a></para></li></ul>
    /// </summary>
    [Cmdlet("Start", "GMLMatchBackfill", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.MatchmakingTicket")]
    [AWSCmdlet("Calls the Amazon GameLift Service StartMatchBackfill API operation.", Operation = new[] {"StartMatchBackfill"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.MatchmakingTicket",
        "This cmdlet returns a MatchmakingTicket object.",
        "The service call response (type Amazon.GameLift.Model.StartMatchBackfillResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartGMLMatchBackfillCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationName
        /// <summary>
        /// <para>
        /// <para>Name of the matchmaker to use for this request. The name of the matchmaker that was
        /// used with the original game session is listed in the <a>GameSession</a> object, <code>MatchmakerData</code>
        /// property. This property contains a matchmaking configuration ARN value, which includes
        /// the matchmaker name. (In the ARN value "arn:aws:gamelift:us-west-2:111122223333:matchmakingconfiguration/MM-4v4",
        /// the matchmaking configuration name is "MM-4v4".) Use only the name for this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationName { get; set; }
        #endregion
        
        #region Parameter GameSessionArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (<a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/s3-arn-format.html">ARN</a>)
        /// that is assigned to a game session and uniquely identifies it. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String GameSessionArn { get; set; }
        #endregion
        
        #region Parameter Player
        /// <summary>
        /// <para>
        /// <para>Match information on all players that are currently assigned to the game session.
        /// This information is used by the matchmaker to find new players and add them to the
        /// existing game.</para><ul><li><para>PlayerID, PlayerAttributes, Team -\\- This information is maintained in the <a>GameSession</a>
        /// object, <code>MatchmakerData</code> property, for all players who are currently assigned
        /// to the game session. The matchmaker data is in JSON syntax, formatted as a string.
        /// For more details, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/match-server.html#match-server-data">
        /// Match Data</a>. </para></li><li><para>LatencyInMs -\\- If the matchmaker uses player latency, include a latency value, in
        /// milliseconds, for the region that the game session is currently in. Do not include
        /// latency values for any other region.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Players")]
        public Amazon.GameLift.Model.Player[] Player { get; set; }
        #endregion
        
        #region Parameter TicketId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a matchmaking ticket. If no ticket ID is specified here, Amazon
        /// GameLift will generate one in the form of a UUID. Use this identifier to track the
        /// match backfill ticket status and retrieve match results.</para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GameSessionArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-GMLMatchBackfill (StartMatchBackfill)"))
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
            context.GameSessionArn = this.GameSessionArn;
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
            var request = new Amazon.GameLift.Model.StartMatchBackfillRequest();
            
            if (cmdletContext.ConfigurationName != null)
            {
                request.ConfigurationName = cmdletContext.ConfigurationName;
            }
            if (cmdletContext.GameSessionArn != null)
            {
                request.GameSessionArn = cmdletContext.GameSessionArn;
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
        
        private Amazon.GameLift.Model.StartMatchBackfillResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.StartMatchBackfillRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "StartMatchBackfill");
            try
            {
                #if DESKTOP
                return client.StartMatchBackfill(request);
                #elif CORECLR
                return client.StartMatchBackfillAsync(request).GetAwaiter().GetResult();
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
            public System.String GameSessionArn { get; set; }
            public List<Amazon.GameLift.Model.Player> Players { get; set; }
            public System.String TicketId { get; set; }
        }
        
    }
}
