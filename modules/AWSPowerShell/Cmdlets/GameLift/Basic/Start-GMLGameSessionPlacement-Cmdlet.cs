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
    /// Makes a request to start a new game session using a game session queue. When processing
    /// a placement request, Amazon GameLift looks for the best possible available resource
    /// to host the game session, based on how the queue is configured to prioritize factors
    /// such as resource cost, latency, and location. After selecting an available resource,
    /// Amazon GameLift prompts the resource to start a game session. A placement request
    /// can include a list of players to create a set of player sessions. The request can
    /// also include information to pass to the new game session, such as to specify a game
    /// map or other options.
    /// 
    ///  
    /// <para><b>Request options</b></para><para>
    /// Use this operation to make the following types of requests. 
    /// </para><ul><li><para>
    /// Request a placement using the queue's default prioritization process (see the default
    /// prioritization described in <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_PriorityConfiguration.html">PriorityConfiguration</a>).
    /// Include these required parameters:
    /// </para><ul><li><para><c>GameSessionQueueName</c></para></li><li><para><c>MaximumPlayerSessionCount</c></para></li><li><para><c>PlacementID</c></para></li></ul></li><li><para>
    /// Request a placement and prioritize based on latency. Include these parameters:
    /// </para><ul><li><para>
    /// Required parameters <c>GameSessionQueueName</c>, <c>MaximumPlayerSessionCount</c>,
    /// <c>PlacementID</c>.
    /// </para></li><li><para><c>PlayerLatencies</c>. Include a set of latency values for destinations in the queue.
    /// When a request includes latency data, Amazon GameLift automatically reorder the queue's
    /// locations priority list based on lowest available latency values. If a request includes
    /// latency data for multiple players, Amazon GameLift calculates each location's average
    /// latency for all players and reorders to find the lowest latency across all players.
    /// </para></li><li><para>
    /// Don't include <c>PriorityConfigurationOverride</c>.
    /// </para></li></ul><ul><li><para>
    /// Prioritize based on a custom list of locations. If you're using a queue that's configured
    /// to prioritize location first (see <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_PriorityConfiguration.html">PriorityConfiguration</a>
    /// for game session queues), you can optionally use the <i>PriorityConfigurationOverride</i>
    /// parameter to substitute a different location priority list for this placement request.
    /// Amazon GameLift searches each location on the priority override list to find an available
    /// hosting resource for the new game session. Specify a fallback strategy to use in the
    /// event that Amazon GameLift fails to place the game session in any of the locations
    /// on the override list. 
    /// </para></li></ul></li><li><para>
    /// Request a placement and prioritized based on a custom list of locations. 
    /// </para></li><li><para>
    /// You can request new player sessions for a group of players. Include the <i>DesiredPlayerSessions</i>
    /// parameter and include at minimum a unique player ID for each. You can also include
    /// player-specific data to pass to the new game session. 
    /// </para></li></ul><para><b>Result</b></para><para>
    /// If successful, this operation generates a new game session placement request and adds
    /// it to the game session queue for processing. You can track the status of individual
    /// placement requests by calling <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_DescribeGameSessionPlacement.html">DescribeGameSessionPlacement</a>
    /// or by monitoring queue notifications. When the request status is <c>FULFILLED</c>,
    /// a new game session has started and the placement request is updated with connection
    /// information for the game session (IP address and port). If the request included player
    /// session data, Amazon GameLift creates a player session for each player ID in the request.
    /// </para><para>
    /// The request results in a <c>InvalidRequestException</c> in the following situations:
    /// </para><ul><li><para>
    /// If the request includes both <i>PlayerLatencies</i> and <i>PriorityConfigurationOverride</i>
    /// parameters.
    /// </para></li><li><para>
    /// If the request includes the <i>PriorityConfigurationOverride</i> parameter and specifies
    /// a queue that doesn't prioritize locations.
    /// </para></li></ul><para>
    /// Amazon GameLift continues to retry each placement request until it reaches the queue's
    /// timeout setting. If a request times out, you can resubmit the request to the same
    /// queue or try a different queue. 
    /// </para>
    /// </summary>
    [Cmdlet("Start", "GMLGameSessionPlacement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameSessionPlacement")]
    [AWSCmdlet("Calls the Amazon GameLift Service StartGameSessionPlacement API operation.", Operation = new[] {"StartGameSessionPlacement"}, SelectReturnType = typeof(Amazon.GameLift.Model.StartGameSessionPlacementResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSessionPlacement or Amazon.GameLift.Model.StartGameSessionPlacementResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GameSessionPlacement object.",
        "The service call response (type Amazon.GameLift.Model.StartGameSessionPlacementResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartGMLGameSessionPlacementCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DesiredPlayerSession
        /// <summary>
        /// <para>
        /// <para>Set of information on each player to create a player session for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DesiredPlayerSessions")]
        public Amazon.GameLift.Model.DesiredPlayerSession[] DesiredPlayerSession { get; set; }
        #endregion
        
        #region Parameter GameProperty
        /// <summary>
        /// <para>
        /// <para>A set of key-value pairs that can store custom data in a game session. For example:
        /// <c>{"Key": "difficulty", "Value": "novice"}</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GameProperties")]
        public Amazon.GameLift.Model.GameProperty[] GameProperty { get; set; }
        #endregion
        
        #region Parameter GameSessionData
        /// <summary>
        /// <para>
        /// <para>A set of custom game session properties, formatted as a single string value. This
        /// data is passed to a game server process with a request to start a new game session.
        /// For more information, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-api.html#gamelift-sdk-server-startsession">Start
        /// a game session</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameSessionData { get; set; }
        #endregion
        
        #region Parameter GameSessionName
        /// <summary>
        /// <para>
        /// <para>A descriptive label that is associated with a game session. Session names do not need
        /// to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GameSessionName { get; set; }
        #endregion
        
        #region Parameter GameSessionQueueName
        /// <summary>
        /// <para>
        /// <para>Name of the queue to use to place the new game session. You can use either the queue
        /// name or ARN value. </para>
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
        public System.String GameSessionQueueName { get; set; }
        #endregion
        
        #region Parameter PriorityConfigurationOverride_LocationOrder
        /// <summary>
        /// <para>
        /// <para>A prioritized list of hosting locations. The list can include Amazon Web Services
        /// Regions (such as <c>us-west-2</c>), local zones, and custom locations (for Anywhere
        /// fleets). Each location must be listed only once. For details, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-regions.html">Amazon
        /// GameLift service locations.</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PriorityConfigurationOverride_LocationOrder { get; set; }
        #endregion
        
        #region Parameter MaximumPlayerSessionCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of players that can be connected simultaneously to the game session.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? MaximumPlayerSessionCount { get; set; }
        #endregion
        
        #region Parameter PriorityConfigurationOverride_PlacementFallbackStrategy
        /// <summary>
        /// <para>
        /// <para>Instructions for how to proceed if placement fails in every location on the priority
        /// override list. Valid strategies include: </para><ul><li><para><c>DEFAULT_AFTER_SINGLE_PASS</c> -- After attempting to place a new game session
        /// in every location on the priority override list, try to place a game session in queue's
        /// other locations. This is the default behavior.</para></li><li><para><c>NONE</c> -- Limit placements to locations on the priority override list only.
        /// </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.PlacementFallbackStrategy")]
        public Amazon.GameLift.PlacementFallbackStrategy PriorityConfigurationOverride_PlacementFallbackStrategy { get; set; }
        #endregion
        
        #region Parameter PlacementId
        /// <summary>
        /// <para>
        /// <para>A unique identifier to assign to the new game session placement. This value is developer-defined.
        /// The value must be unique across all Regions and cannot be reused.</para>
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
        public System.String PlacementId { get; set; }
        #endregion
        
        #region Parameter PlayerLatency
        /// <summary>
        /// <para>
        /// <para>A set of values, expressed in milliseconds, that indicates the amount of latency that
        /// a player experiences when connected to Amazon Web Services Regions. This information
        /// is used to try to place the new game session where it can offer the best possible
        /// gameplay experience for the players. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlayerLatencies")]
        public Amazon.GameLift.Model.PlayerLatency[] PlayerLatency { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GameSessionPlacement'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.StartGameSessionPlacementResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.StartGameSessionPlacementResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GameSessionPlacement";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GameSessionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-GMLGameSessionPlacement (StartGameSessionPlacement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.StartGameSessionPlacementResponse, StartGMLGameSessionPlacementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DesiredPlayerSession != null)
            {
                context.DesiredPlayerSession = new List<Amazon.GameLift.Model.DesiredPlayerSession>(this.DesiredPlayerSession);
            }
            if (this.GameProperty != null)
            {
                context.GameProperty = new List<Amazon.GameLift.Model.GameProperty>(this.GameProperty);
            }
            context.GameSessionData = this.GameSessionData;
            context.GameSessionName = this.GameSessionName;
            context.GameSessionQueueName = this.GameSessionQueueName;
            #if MODULAR
            if (this.GameSessionQueueName == null && ParameterWasBound(nameof(this.GameSessionQueueName)))
            {
                WriteWarning("You are passing $null as a value for parameter GameSessionQueueName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaximumPlayerSessionCount = this.MaximumPlayerSessionCount;
            #if MODULAR
            if (this.MaximumPlayerSessionCount == null && ParameterWasBound(nameof(this.MaximumPlayerSessionCount)))
            {
                WriteWarning("You are passing $null as a value for parameter MaximumPlayerSessionCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PlacementId = this.PlacementId;
            #if MODULAR
            if (this.PlacementId == null && ParameterWasBound(nameof(this.PlacementId)))
            {
                WriteWarning("You are passing $null as a value for parameter PlacementId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PlayerLatency != null)
            {
                context.PlayerLatency = new List<Amazon.GameLift.Model.PlayerLatency>(this.PlayerLatency);
            }
            if (this.PriorityConfigurationOverride_LocationOrder != null)
            {
                context.PriorityConfigurationOverride_LocationOrder = new List<System.String>(this.PriorityConfigurationOverride_LocationOrder);
            }
            context.PriorityConfigurationOverride_PlacementFallbackStrategy = this.PriorityConfigurationOverride_PlacementFallbackStrategy;
            
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
            
            if (cmdletContext.DesiredPlayerSession != null)
            {
                request.DesiredPlayerSessions = cmdletContext.DesiredPlayerSession;
            }
            if (cmdletContext.GameProperty != null)
            {
                request.GameProperties = cmdletContext.GameProperty;
            }
            if (cmdletContext.GameSessionData != null)
            {
                request.GameSessionData = cmdletContext.GameSessionData;
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
            if (cmdletContext.PlayerLatency != null)
            {
                request.PlayerLatencies = cmdletContext.PlayerLatency;
            }
            
             // populate PriorityConfigurationOverride
            var requestPriorityConfigurationOverrideIsNull = true;
            request.PriorityConfigurationOverride = new Amazon.GameLift.Model.PriorityConfigurationOverride();
            List<System.String> requestPriorityConfigurationOverride_priorityConfigurationOverride_LocationOrder = null;
            if (cmdletContext.PriorityConfigurationOverride_LocationOrder != null)
            {
                requestPriorityConfigurationOverride_priorityConfigurationOverride_LocationOrder = cmdletContext.PriorityConfigurationOverride_LocationOrder;
            }
            if (requestPriorityConfigurationOverride_priorityConfigurationOverride_LocationOrder != null)
            {
                request.PriorityConfigurationOverride.LocationOrder = requestPriorityConfigurationOverride_priorityConfigurationOverride_LocationOrder;
                requestPriorityConfigurationOverrideIsNull = false;
            }
            Amazon.GameLift.PlacementFallbackStrategy requestPriorityConfigurationOverride_priorityConfigurationOverride_PlacementFallbackStrategy = null;
            if (cmdletContext.PriorityConfigurationOverride_PlacementFallbackStrategy != null)
            {
                requestPriorityConfigurationOverride_priorityConfigurationOverride_PlacementFallbackStrategy = cmdletContext.PriorityConfigurationOverride_PlacementFallbackStrategy;
            }
            if (requestPriorityConfigurationOverride_priorityConfigurationOverride_PlacementFallbackStrategy != null)
            {
                request.PriorityConfigurationOverride.PlacementFallbackStrategy = requestPriorityConfigurationOverride_priorityConfigurationOverride_PlacementFallbackStrategy;
                requestPriorityConfigurationOverrideIsNull = false;
            }
             // determine if request.PriorityConfigurationOverride should be set to null
            if (requestPriorityConfigurationOverrideIsNull)
            {
                request.PriorityConfigurationOverride = null;
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
        
        private Amazon.GameLift.Model.StartGameSessionPlacementResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.StartGameSessionPlacementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "StartGameSessionPlacement");
            try
            {
                return client.StartGameSessionPlacementAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.GameLift.Model.DesiredPlayerSession> DesiredPlayerSession { get; set; }
            public List<Amazon.GameLift.Model.GameProperty> GameProperty { get; set; }
            public System.String GameSessionData { get; set; }
            public System.String GameSessionName { get; set; }
            public System.String GameSessionQueueName { get; set; }
            public System.Int32? MaximumPlayerSessionCount { get; set; }
            public System.String PlacementId { get; set; }
            public List<Amazon.GameLift.Model.PlayerLatency> PlayerLatency { get; set; }
            public List<System.String> PriorityConfigurationOverride_LocationOrder { get; set; }
            public Amazon.GameLift.PlacementFallbackStrategy PriorityConfigurationOverride_PlacementFallbackStrategy { get; set; }
            public System.Func<Amazon.GameLift.Model.StartGameSessionPlacementResponse, StartGMLGameSessionPlacementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameSessionPlacement;
        }
        
    }
}
