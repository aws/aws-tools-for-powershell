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
    /// Places a request for a new game session in a queue. When processing a placement request,
    /// Amazon GameLift searches for available resources on the queue's destinations, scanning
    /// each until it finds resources or the placement request times out.
    /// 
    ///  
    /// <para>
    /// A game session placement request can also request player sessions. When a new game
    /// session is successfully created, Amazon GameLift creates a player session for each
    /// player included in the request.
    /// </para><para>
    /// When placing a game session, by default Amazon GameLift tries each fleet in the order
    /// they are listed in the queue configuration. Ideally, a queue's destinations are listed
    /// in preference order.
    /// </para><para>
    /// Alternatively, when requesting a game session with players, you can also provide latency
    /// data for each player in relevant Regions. Latency data indicates the performance lag
    /// a player experiences when connected to a fleet in the Region. Amazon GameLift uses
    /// latency data to reorder the list of destinations to place the game session in a Region
    /// with minimal lag. If latency data is provided for multiple players, Amazon GameLift
    /// calculates each Region's average lag for all players and reorders to get the best
    /// game play across all players. 
    /// </para><para>
    /// To place a new game session request, specify the following:
    /// </para><ul><li><para>
    /// The queue name and a set of game session properties and settings
    /// </para></li><li><para>
    /// A unique ID (such as a UUID) for the placement. You use this ID to track the status
    /// of the placement request
    /// </para></li><li><para>
    /// (Optional) A set of player data and a unique player ID for each player that you are
    /// joining to the new game session (player data is optional, but if you include it, you
    /// must also provide a unique ID for each player)
    /// </para></li><li><para>
    /// Latency data for all players (if you want to optimize game play for the players)
    /// </para></li></ul><para>
    /// If successful, a new game session placement is created.
    /// </para><para>
    /// To track the status of a placement request, call <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_DescribeGameSessionPlacement.html">DescribeGameSessionPlacement</a>
    /// and check the request's status. If the status is <code>FULFILLED</code>, a new game
    /// session has been created and a game session ARN and Region are referenced. If the
    /// placement request times out, you can resubmit the request or retry it with a different
    /// queue. 
    /// </para>
    /// </summary>
    [Cmdlet("Start", "GMLGameSessionPlacement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameSessionPlacement")]
    [AWSCmdlet("Calls the Amazon GameLift Service StartGameSessionPlacement API operation.", Operation = new[] {"StartGameSessionPlacement"}, SelectReturnType = typeof(Amazon.GameLift.Model.StartGameSessionPlacementResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSessionPlacement or Amazon.GameLift.Model.StartGameSessionPlacementResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GameSessionPlacement object.",
        "The service call response (type Amazon.GameLift.Model.StartGameSessionPlacementResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartGMLGameSessionPlacementCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
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
        /// <para>A set of custom properties for a game session, formatted as key:value pairs. These
        /// properties are passed to a game server process with a request to start a new game
        /// session (see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-api.html#gamelift-sdk-server-startsession">Start
        /// a Game Session</a>).</para>
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
        /// data is passed to a game server process in the <code>GameSession</code> object with
        /// a request to start a new game session (see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-api.html#gamelift-sdk-server-startsession">Start
        /// a Game Session</a>).</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GameSessionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GameSessionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GameSessionName' instead. This parameter will be removed in a future version.")]
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.StartGameSessionPlacementResponse, StartGMLGameSessionPlacementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GameSessionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            public System.Func<Amazon.GameLift.Model.StartGameSessionPlacementResponse, StartGMLGameSessionPlacementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameSessionPlacement;
        }
        
    }
}
