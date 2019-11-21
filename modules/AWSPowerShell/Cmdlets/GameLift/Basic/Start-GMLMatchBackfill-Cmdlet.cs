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
    /// processed. Track the status of the ticket to respond as needed. 
    /// </para><para>
    /// The process of finding backfill matches is essentially identical to the initial matchmaking
    /// process. The matchmaker searches the pool and groups tickets together to form potential
    /// matches, allowing only one backfill ticket per potential match. Once the a match is
    /// formed, the matchmaker creates player sessions for the new players. All tickets in
    /// the match are updated with the game session's connection information, and the <a>GameSession</a>
    /// object is updated to include matchmaker data on the new players. For more detail on
    /// how match backfill requests are processed, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-match.html">
    /// How Amazon GameLift FlexMatch Works</a>. 
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/match-backfill.html">
    /// Backfill Existing Games with FlexMatch</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-match.html">
    /// How GameLift FlexMatch Works</a></para><para><b>Related operations</b></para><ul><li><para><a>StartMatchmaking</a></para></li><li><para><a>DescribeMatchmaking</a></para></li><li><para><a>StopMatchmaking</a></para></li><li><para><a>AcceptMatch</a></para></li><li><para><a>StartMatchBackfill</a></para></li></ul>
    /// </summary>
    [Cmdlet("Start", "GMLMatchBackfill", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.MatchmakingTicket")]
    [AWSCmdlet("Calls the Amazon GameLift Service StartMatchBackfill API operation.", Operation = new[] {"StartMatchBackfill"}, SelectReturnType = typeof(Amazon.GameLift.Model.StartMatchBackfillResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.MatchmakingTicket or Amazon.GameLift.Model.StartMatchBackfillResponse",
        "This cmdlet returns an Amazon.GameLift.Model.MatchmakingTicket object.",
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
        /// <para>Amazon Resource Name (<a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/s3-arn-format.html">ARN</a>)
        /// that is assigned to a game session and uniquely identifies it. </para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GameSessionArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GameSessionArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GameSessionArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GameSessionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-GMLMatchBackfill (StartMatchBackfill)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.StartMatchBackfillResponse, StartGMLMatchBackfillCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GameSessionArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConfigurationName = this.ConfigurationName;
            #if MODULAR
            if (this.ConfigurationName == null && ParameterWasBound(nameof(this.ConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GameSessionArn = this.GameSessionArn;
            #if MODULAR
            if (this.GameSessionArn == null && ParameterWasBound(nameof(this.GameSessionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter GameSessionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            public List<Amazon.GameLift.Model.Player> Player { get; set; }
            public System.String TicketId { get; set; }
            public System.Func<Amazon.GameLift.Model.StartMatchBackfillResponse, StartGMLMatchBackfillCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MatchmakingTicket;
        }
        
    }
}
