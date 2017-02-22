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
    /// Places a request for a new game session in a queue (see <a>CreateGameSessionQueue</a>).
    /// When processing a placement request, Amazon GameLift attempts to create a new game
    /// session on one of the fleets associated with the queue. If no resources are available,
    /// Amazon GameLift tries again with another and so on until resources are found or the
    /// placement request times out. A game session placement request can also request player
    /// sessions. When a new game session is successfully created, Amazon GameLift creates
    /// a player session for each player included in the request.
    /// 
    ///  
    /// <para>
    /// When placing a game session, by default Amazon GameLift tries each fleet in the order
    /// they are listed in the queue configuration. Ideally, a queue's destinations are listed
    /// in preference order. Alternatively, when requesting a game session with players, you
    /// can also provide latency data for each player in relevant regions. Latency data indicates
    /// the performance lag a player experiences when connected to a fleet in the region.
    /// Amazon GameLift uses latency data to reorder the list of destinations to place the
    /// game session in a region with minimal lag. If latency data is provided for multiple
    /// players, Amazon GameLift calculates each region's average lag for all players and
    /// reorders to get the best game play across all players. 
    /// </para><para>
    /// To place a new game session request, specify the queue name and a set of game session
    /// properties and settings. Also provide a unique ID (such as a UUID) for the placement.
    /// You'll use this ID to track the status of the placement request. Optionally, provide
    /// a set of IDs and player data for each player you want to join to the new game session.
    /// To optimize game play for the players, also provide latency data for all players.
    /// If successful, a new game session placement is created. To track the status of a placement
    /// request, call <a>DescribeGameSessionPlacement</a> and check the request's status.
    /// If the status is Fulfilled, a new game session has been created and a game session
    /// ARN and region are referenced. If the placement request times out, you have the option
    /// of resubmitting the request or retrying it with a different queue. 
    /// </para>
    /// </summary>
    [Cmdlet("Start", "GMLGameSessionPlacement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameSessionPlacement")]
    [AWSCmdlet("Invokes the StartGameSessionPlacement operation against Amazon GameLift Service.", Operation = new[] {"StartGameSessionPlacement"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSessionPlacement",
        "This cmdlet returns a GameSessionPlacement object.",
        "The service call response (type Amazon.GameLift.Model.StartGameSessionPlacementResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartGMLGameSessionPlacementCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter DesiredPlayerSession
        /// <summary>
        /// <para>
        /// <para>Set of information on each player to create a player session for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DesiredPlayerSessions")]
        public Amazon.GameLift.Model.DesiredPlayerSession[] DesiredPlayerSession { get; set; }
        #endregion
        
        #region Parameter GameProperty
        /// <summary>
        /// <para>
        /// <para>Set of developer-defined properties for a game session. These properties are passed
        /// to the server process hosting the game session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GameProperties")]
        public Amazon.GameLift.Model.GameProperty[] GameProperty { get; set; }
        #endregion
        
        #region Parameter GameSessionName
        /// <summary>
        /// <para>
        /// <para>Descriptive label that is associated with a game session. Session names do not need
        /// to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String GameSessionName { get; set; }
        #endregion
        
        #region Parameter GameSessionQueueName
        /// <summary>
        /// <para>
        /// <para>Name of the queue to use to place the new game session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GameSessionQueueName { get; set; }
        #endregion
        
        #region Parameter MaximumPlayerSessionCount
        /// <summary>
        /// <para>
        /// <para>Maximum number of players that can be connected simultaneously to the game session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MaximumPlayerSessionCount { get; set; }
        #endregion
        
        #region Parameter PlacementId
        /// <summary>
        /// <para>
        /// <para>Unique identifier to assign to the new game session placement. This value is developer-defined.
        /// The value must be unique across all regions and cannot be reused unless you are resubmitting
        /// a cancelled or timed-out placement request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PlacementId { get; set; }
        #endregion
        
        #region Parameter PlayerLatency
        /// <summary>
        /// <para>
        /// <para>Set of values, expressed in milliseconds, indicating the amount of latency that players
        /// experience when connected to AWS regions. This information is relevant when requesting
        /// player sessions. Latency information provided for player IDs not included in <i>DesiredPlayerSessions</i>
        /// are ignored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PlayerLatencies")]
        public Amazon.GameLift.Model.PlayerLatency[] PlayerLatency { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GameSessionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-GMLGameSessionPlacement (StartGameSessionPlacement)"))
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
            
            if (this.DesiredPlayerSession != null)
            {
                context.DesiredPlayerSessions = new List<Amazon.GameLift.Model.DesiredPlayerSession>(this.DesiredPlayerSession);
            }
            if (this.GameProperty != null)
            {
                context.GameProperties = new List<Amazon.GameLift.Model.GameProperty>(this.GameProperty);
            }
            context.GameSessionName = this.GameSessionName;
            context.GameSessionQueueName = this.GameSessionQueueName;
            if (ParameterWasBound("MaximumPlayerSessionCount"))
                context.MaximumPlayerSessionCount = this.MaximumPlayerSessionCount;
            context.PlacementId = this.PlacementId;
            if (this.PlayerLatency != null)
            {
                context.PlayerLatencies = new List<Amazon.GameLift.Model.PlayerLatency>(this.PlayerLatency);
            }
            
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
            var request = new Amazon.GameLift.Model.StartGameSessionPlacementRequest();
            
            if (cmdletContext.DesiredPlayerSessions != null)
            {
                request.DesiredPlayerSessions = cmdletContext.DesiredPlayerSessions;
            }
            if (cmdletContext.GameProperties != null)
            {
                request.GameProperties = cmdletContext.GameProperties;
            }
            if (cmdletContext.GameSessionName != null)
            {
                request.GameSessionName = cmdletContext.GameSessionName;
            }
            if (cmdletContext.GameSessionQueueName != null)
            {
                request.GameSessionQueueName = cmdletContext.GameSessionQueueName;
            }
            if (cmdletContext.MaximumPlayerSessionCount != null)
            {
                request.MaximumPlayerSessionCount = cmdletContext.MaximumPlayerSessionCount.Value;
            }
            if (cmdletContext.PlacementId != null)
            {
                request.PlacementId = cmdletContext.PlacementId;
            }
            if (cmdletContext.PlayerLatencies != null)
            {
                request.PlayerLatencies = cmdletContext.PlayerLatencies;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GameSessionPlacement;
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
        
        private static Amazon.GameLift.Model.StartGameSessionPlacementResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.StartGameSessionPlacementRequest request)
        {
            #if DESKTOP
            return client.StartGameSessionPlacement(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.StartGameSessionPlacementAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.GameLift.Model.DesiredPlayerSession> DesiredPlayerSessions { get; set; }
            public List<Amazon.GameLift.Model.GameProperty> GameProperties { get; set; }
            public System.String GameSessionName { get; set; }
            public System.String GameSessionQueueName { get; set; }
            public System.Int32? MaximumPlayerSessionCount { get; set; }
            public System.String PlacementId { get; set; }
            public List<Amazon.GameLift.Model.PlayerLatency> PlayerLatencies { get; set; }
        }
        
    }
}
