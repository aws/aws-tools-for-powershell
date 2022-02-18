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
    /// Creates a multiplayer game session for players in a specific fleet location. This
    /// operation prompts an available server process to start a game session and retrieves
    /// connection information for the new game session. As an alternative, consider using
    /// the GameLift game session placement feature with 
    /// 
    ///  
    /// <para>
    /// with <a>StartGameSessionPlacement</a>, which uses FleetIQ algorithms and queues to
    /// optimize the placement process.
    /// </para><para>
    /// When creating a game session, you specify exactly where you want to place it and provide
    /// a set of game session configuration settings. The fleet must be in <code>ACTIVE</code>
    /// status before a game session can be created in it. 
    /// </para><para>
    /// This operation can be used in the following ways: 
    /// </para><ul><li><para>
    /// To create a game session on an instance in a fleet's home Region, provide a fleet
    /// or alias ID along with your game session configuration. 
    /// </para></li><li><para>
    /// To create a game session on an instance in a fleet's remote location, provide a fleet
    /// or alias ID and a location name, along with your game session configuration. 
    /// </para></li></ul><para>
    /// If successful, a workflow is initiated to start a new game session. A <code>GameSession</code>
    /// object is returned containing the game session configuration and status. When the
    /// status is <code>ACTIVE</code>, game session connection information is provided and
    /// player sessions can be created for the game session. By default, newly created game
    /// sessions are open to new players. You can restrict new player access by using <a>UpdateGameSession</a>
    /// to change the game session's player session creation policy.
    /// </para><para>
    /// Game session logs are retained for all active game sessions for 14 days. To access
    /// the logs, call <a>GetGameSessionLogUrl</a> to download the log files.
    /// </para><para><i>Available in Amazon Web Services Local.</i></para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-api.html#gamelift-sdk-server-startsession">Start
    /// a game session</a></para><para><b>Related actions</b></para><para><a>CreateGameSession</a> | <a>DescribeGameSessions</a> | <a>DescribeGameSessionDetails</a>
    /// | <a>SearchGameSessions</a> | <a>UpdateGameSession</a> | <a>GetGameSessionLogUrl</a>
    /// | <a>StartGameSessionPlacement</a> | <a>DescribeGameSessionPlacement</a> | <a>StopGameSessionPlacement</a>
    /// | <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/reference-awssdk.html#reference-awssdk-resources-fleets">All
    /// APIs by task</a></para>
    /// </summary>
    [Cmdlet("New", "GMLGameSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameSession")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreateGameSession API operation.", Operation = new[] {"CreateGameSession"}, SelectReturnType = typeof(Amazon.GameLift.Model.CreateGameSessionResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSession or Amazon.GameLift.Model.CreateGameSessionResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GameSession object.",
        "The service call response (type Amazon.GameLift.Model.CreateGameSessionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLGameSessionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter AliasId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the alias associated with the fleet to create a game session
        /// in. You can use either the alias ID or ARN value. Each request must reference either
        /// a fleet ID or alias ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AliasId { get; set; }
        #endregion
        
        #region Parameter CreatorId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a player or entity creating the game session. This parameter
        /// is required when requesting a new game session on a fleet with a resource creation
        /// limit policy. This type of policy limits the number of concurrent active game sessions
        /// that one player can create within a certain time span. GameLift uses the CreatorId
        /// to evaluate the new request against the policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatorId { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the fleet to create a game session in. You can use either
        /// the fleet ID or ARN value. Each request must reference either a fleet ID or alias
        /// ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter GameProperty
        /// <summary>
        /// <para>
        /// <para>A set of custom properties for a game session, formatted as key:value pairs. These
        /// properties are passed to a game server process in the <a>GameSession</a> object with
        /// a request to start a new game session (see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-api.html#gamelift-sdk-server-startsession">Start
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
        /// data is passed to a game server process in the <a>GameSession</a> object with a request
        /// to start a new game session (see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-api.html#gamelift-sdk-server-startsession">Start
        /// a Game Session</a>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameSessionData { get; set; }
        #endregion
        
        #region Parameter GameSessionId
        /// <summary>
        /// <para>
        /// <para><i>This parameter is no longer preferred. Please use <code>IdempotencyToken</code>
        /// instead.</i> Custom string that uniquely identifies a request for a new game session.
        /// Maximum token length is 48 characters. If provided, this string is included in the
        /// new game session's ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameSessionId { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>Custom string that uniquely identifies the new game session request. This is useful
        /// for ensuring that game session requests with the same idempotency token are processed
        /// only once. Subsequent requests with the same string return the original <code>GameSession</code>
        /// object, with an updated status. Maximum token length is 48 characters. If provided,
        /// this string is included in the new game session's ID. A game session ARN has the following
        /// format: <code>arn:aws:gamelift:&lt;region&gt;::gamesession/&lt;fleet ID&gt;/&lt;custom
        /// ID string or idempotency token&gt;</code>. Idempotency tokens remain in use for 30
        /// days after a game session has ended; game session objects are retained for this time
        /// period and then deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <para>A fleet's remote location to place the new game session in. If this parameter is not
        /// set, the new game session is placed in the fleet's home Region. Specify a remote location
        /// with an Amazon Web Services Region code such as <code>us-west-2</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location { get; set; }
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A descriptive label that is associated with a game session. Session names do not need
        /// to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GameSession'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.CreateGameSessionResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.CreateGameSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GameSession";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLGameSession (CreateGameSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.CreateGameSessionResponse, NewGMLGameSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AliasId = this.AliasId;
            context.CreatorId = this.CreatorId;
            context.FleetId = this.FleetId;
            if (this.GameProperty != null)
            {
                context.GameProperty = new List<Amazon.GameLift.Model.GameProperty>(this.GameProperty);
            }
            context.GameSessionData = this.GameSessionData;
            context.GameSessionId = this.GameSessionId;
            context.IdempotencyToken = this.IdempotencyToken;
            context.Location = this.Location;
            context.MaximumPlayerSessionCount = this.MaximumPlayerSessionCount;
            #if MODULAR
            if (this.MaximumPlayerSessionCount == null && ParameterWasBound(nameof(this.MaximumPlayerSessionCount)))
            {
                WriteWarning("You are passing $null as a value for parameter MaximumPlayerSessionCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            
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
            var request = new Amazon.GameLift.Model.CreateGameSessionRequest();
            
            if (cmdletContext.AliasId != null)
            {
                request.AliasId = cmdletContext.AliasId;
            }
            if (cmdletContext.CreatorId != null)
            {
                request.CreatorId = cmdletContext.CreatorId;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.GameProperty != null)
            {
                request.GameProperties = cmdletContext.GameProperty;
            }
            if (cmdletContext.GameSessionData != null)
            {
                request.GameSessionData = cmdletContext.GameSessionData;
            }
            if (cmdletContext.GameSessionId != null)
            {
                request.GameSessionId = cmdletContext.GameSessionId;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.Location != null)
            {
                request.Location = cmdletContext.Location;
            }
            if (cmdletContext.MaximumPlayerSessionCount != null)
            {
                request.MaximumPlayerSessionCount = cmdletContext.MaximumPlayerSessionCount.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.GameLift.Model.CreateGameSessionResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateGameSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "CreateGameSession");
            try
            {
                #if DESKTOP
                return client.CreateGameSession(request);
                #elif CORECLR
                return client.CreateGameSessionAsync(request).GetAwaiter().GetResult();
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
            public System.String AliasId { get; set; }
            public System.String CreatorId { get; set; }
            public System.String FleetId { get; set; }
            public List<Amazon.GameLift.Model.GameProperty> GameProperty { get; set; }
            public System.String GameSessionData { get; set; }
            public System.String GameSessionId { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String Location { get; set; }
            public System.Int32? MaximumPlayerSessionCount { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.GameLift.Model.CreateGameSessionResponse, NewGMLGameSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameSession;
        }
        
    }
}
