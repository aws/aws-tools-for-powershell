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
    /// Makes a request to start a new game session using a game session queue. When processing
    /// a placement request in a queue, Amazon GameLift finds the best possible available
    /// resource to host the game session and prompts the resource to start the game session.
    /// 
    /// 
    ///  
    /// <para><b>Request options</b></para><para>
    /// Call this API with the following minimum parameters: <i>GameSessionQueueName</i>,
    /// <i>MaximumPlayerSessionCount</i>, and <i>PlacementID</i>. You can also include game
    /// session data (data formatted as strings) or game properties (data formatted as key-value
    /// pairs) to pass to the new game session.
    /// </para><ul><li><para>
    /// You can change how Amazon GameLift chooses a hosting resource for the new game session.
    /// Prioritizing resources for game session placements is defined when you configure a
    /// game session queue. You can use the default prioritization process or specify a custom
    /// process by providing a <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_PriorityConfiguration.html">
    /// PriorityConfiguration</a> when you create or update a queue.
    /// </para><ul><li><para>
    /// Prioritize based on resource cost and location, using the queue's configured priority
    /// settings. Call this API with the minimum parameters.
    /// </para></li><li><para>
    /// Prioritize based on latency. Include a set of values for <i>PlayerLatencies</i>. You
    /// can provide latency data with or without player session data. This option instructs
    /// Amazon GameLift to reorder the queue's prioritized locations list based on the latency
    /// data. If latency data is provided for multiple players, Amazon GameLift calculates
    /// each location's average latency for all players and reorders to find the lowest latency
    /// across all players. Don't include latency data if you're providing a custom list of
    /// locations.
    /// </para></li><li><para>
    /// Prioritize based on a custom list of locations. If you're using a queue that's configured
    /// to prioritize location first (see <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_PriorityConfiguration.html">PriorityConfiguration</a>
    /// for game session queues), use the <i>PriorityConfigurationOverride</i> parameter to
    /// substitute a different location list for this placement request. When prioritizing
    /// placements by location, Amazon GameLift searches each location in prioritized order
    /// to find an available hosting resource for the new game session. You can choose whether
    /// to use the override list for the first placement attempt only or for all attempts.
    /// </para></li></ul></li><li><para>
    /// You can request new player sessions for a group of players. Include the <i>DesiredPlayerSessions</i>
    /// parameter and include at minimum a unique player ID for each. You can also include
    /// player-specific data to pass to the new game session. 
    /// </para></li></ul><para><b>Result</b></para><para>
    /// If successful, this request generates a new game session placement request and adds
    /// it to the game session queue for Amazon GameLift to process in turn. You can track
    /// the status of individual placement requests by calling <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_DescribeGameSessionPlacement.html">DescribeGameSessionPlacement</a>.
    /// A new game session is running if the status is <c>FULFILLED</c> and the request returns
    /// the game session connection information (IP address and port). If you include player
    /// session data, Amazon GameLift creates a player session for each player ID in the request.
    /// </para><para>
    /// The request results in a <c>BadRequestException</c> in the following situations:
    /// </para><ul><li><para>
    /// If the request includes both <i>PlayerLatencies</i> and <i>PriorityConfigurationOverride</i>
    /// parameters.
    /// </para></li><li><para>
    /// If the request includes the <i>PriorityConfigurationOverride</i> parameter and designates
    /// a queue doesn't prioritize locations.
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
        /// <para>Instructions for how to use the override list if the first round of placement attempts
        /// fails. The first round is a failure if Amazon GameLift searches all listed locations,
        /// in all of the queue's destinations, without finding an available hosting resource
        /// for a new game session. Valid strategies include: </para><ul><li><para><c>DEFAULT_AFTER_SINGLE_PASS</c> -- After the first round of placement attempts,
        /// discard the override list and use the queue's default location priority list. Continue
        /// to use the queue's default list until the placement request times out.</para></li><li><para><c>NONE</c> -- Continue to use the override list for all rounds of placement attempts
        /// until the placement request times out.</para></li></ul>
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
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
                #if DESKTOP
                return client.StartGameSessionPlacement(request);
                #elif CORECLR
                return client.StartGameSessionPlacementAsync(request).GetAwaiter().GetResult();
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
