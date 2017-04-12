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
    /// Creates a multiplayer game session for players. This action creates a game session
    /// record and assigns an available server process in the specified fleet to host the
    /// game session. A fleet must have an <code>ACTIVE</code> status before a game session
    /// can be created in it.
    /// 
    ///  
    /// <para>
    /// To create a game session, specify either fleet ID or alias ID and indicate a maximum
    /// number of players to allow in the game session. You can also provide a name and game-specific
    /// properties for this game session. If successful, a <a>GameSession</a> object is returned
    /// containing game session properties, including a game session ID with the custom string
    /// you provided.
    /// </para><para><b>Idempotency tokens.</b> You can add a token that uniquely identifies game session
    /// requests. This is useful for ensuring that game session requests are idempotent. Multiple
    /// requests with the same idempotency token are processed only once; subsequent requests
    /// return the original result. All response values are the same with the exception of
    /// game session status, which may change.
    /// </para><para><b>Resource creation limits.</b> If you are creating a game session on a fleet with
    /// a resource creation limit policy in force, then you must specify a creator ID. Without
    /// this ID, Amazon GameLift has no way to evaluate the policy for this new game session
    /// request.
    /// </para><para>
    ///  By default, newly created game sessions allow new players to join. Use <a>UpdateGameSession</a>
    /// to change the game session's player session creation policy.
    /// </para><para><i>Available in Amazon GameLift Local.</i></para>
    /// </summary>
    [Cmdlet("New", "GMLGameSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameSession")]
    [AWSCmdlet("Invokes the CreateGameSession operation against Amazon GameLift Service.", Operation = new[] {"CreateGameSession"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSession",
        "This cmdlet returns a GameSession object.",
        "The service call response (type Amazon.GameLift.Model.CreateGameSessionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLGameSessionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter AliasId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for an alias associated with the fleet to create a game session
        /// in. Each request must reference either a fleet ID or alias ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AliasId { get; set; }
        #endregion
        
        #region Parameter CreatorId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a player or entity creating the game session. This ID is used
        /// to enforce a resource protection policy (if one exists) that limits the number of
        /// concurrent active game sessions one player can have.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CreatorId { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a fleet to create a game session in. Each request must reference
        /// either a fleet ID or alias ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FleetId { get; set; }
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
        
        #region Parameter GameSessionId
        /// <summary>
        /// <para>
        /// <para><i>This parameter is no longer preferred. Please use <code>IdempotencyToken</code>
        /// instead.</i> Custom string that uniquely identifies a request for a new game session.
        /// Maximum token length is 48 characters. If provided, this string is included in the
        /// new game session's ID. (A game session ID has the following format: <code>arn:aws:gamelift:&lt;region&gt;::gamesession/&lt;fleet
        /// ID&gt;/&lt;custom ID string or idempotency token&gt;</code>.) </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameSessionId { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>Custom string that uniquely identifies a request for a new game session. Maximum token
        /// length is 48 characters. If provided, this string is included in the new game session's
        /// ID. (A game session ID has the following format: <code>arn:aws:gamelift:&lt;region&gt;::gamesession/&lt;fleet
        /// ID&gt;/&lt;custom ID string or idempotency token&gt;</code>.) </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IdempotencyToken { get; set; }
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Descriptive label that is associated with a game session. Session names do not need
        /// to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLGameSession (CreateGameSession)"))
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
            
            context.AliasId = this.AliasId;
            context.CreatorId = this.CreatorId;
            context.FleetId = this.FleetId;
            if (this.GameProperty != null)
            {
                context.GameProperties = new List<Amazon.GameLift.Model.GameProperty>(this.GameProperty);
            }
            context.GameSessionId = this.GameSessionId;
            context.IdempotencyToken = this.IdempotencyToken;
            if (ParameterWasBound("MaximumPlayerSessionCount"))
                context.MaximumPlayerSessionCount = this.MaximumPlayerSessionCount;
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
            if (cmdletContext.GameProperties != null)
            {
                request.GameProperties = cmdletContext.GameProperties;
            }
            if (cmdletContext.GameSessionId != null)
            {
                request.GameSessionId = cmdletContext.GameSessionId;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GameSession;
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
        
        private static Amazon.GameLift.Model.CreateGameSessionResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateGameSessionRequest request)
        {
            #if DESKTOP
            return client.CreateGameSession(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateGameSessionAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AliasId { get; set; }
            public System.String CreatorId { get; set; }
            public System.String FleetId { get; set; }
            public List<Amazon.GameLift.Model.GameProperty> GameProperties { get; set; }
            public System.String GameSessionId { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.Int32? MaximumPlayerSessionCount { get; set; }
            public System.String Name { get; set; }
        }
        
    }
}
