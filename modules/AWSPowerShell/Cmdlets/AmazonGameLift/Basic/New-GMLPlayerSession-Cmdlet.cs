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
    /// Adds a group of players to a game session. This action is useful with a team matching
    /// feature. Before players can be added, a game session must have an <code>ACTIVE</code>
    /// status, have a creation policy of <code>ALLOW_ALL</code>, and have an open player
    /// slot. To add a single player to a game session, use <a>CreatePlayerSession</a>.
    /// 
    ///  
    /// <para>
    /// To create player sessions, specify a game session ID, a list of player IDs, and optionally
    /// a set of player data strings. If successful, the players are added to the game session
    /// and a set of new <a>PlayerSession</a> objects is returned. Player sessions cannot
    /// be updated.
    /// </para><para><i>Available in Amazon GameLift Local.</i></para><para>
    /// Player-session-related operations include:
    /// </para><ul><li><para><a>CreatePlayerSession</a></para></li><li><para><a>CreatePlayerSessions</a></para></li><li><para><a>DescribePlayerSessions</a></para></li><li><para>
    /// Game session placements
    /// </para><ul><li><para><a>StartGameSessionPlacement</a></para></li><li><para><a>DescribeGameSessionPlacement</a></para></li><li><para><a>StopGameSessionPlacement</a></para></li></ul></li></ul>
    /// </summary>
    [Cmdlet("New", "GMLPlayerSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.PlayerSession")]
    [AWSCmdlet("Invokes the CreatePlayerSessions operation against Amazon GameLift Service.", Operation = new[] {"CreatePlayerSessions"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.PlayerSession",
        "This cmdlet returns a collection of PlayerSession objects.",
        "The service call response (type Amazon.GameLift.Model.CreatePlayerSessionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLPlayerSessionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter GameSessionId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for the game session to add players to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GameSessionId { get; set; }
        #endregion
        
        #region Parameter PlayerDataMap
        /// <summary>
        /// <para>
        /// <para>Map of string pairs, each specifying a player ID and a set of developer-defined information
        /// related to the player. Amazon GameLift does not use this data, so it can be formatted
        /// as needed for use in the game. Player data strings for player IDs not included in
        /// the <code>PlayerIds</code> parameter are ignored. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable PlayerDataMap { get; set; }
        #endregion
        
        #region Parameter PlayerId
        /// <summary>
        /// <para>
        /// <para>List of unique identifiers for the players to be added.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlayerIds")]
        public System.String[] PlayerId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GameSessionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLPlayerSession (CreatePlayerSessions)"))
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
            
            context.GameSessionId = this.GameSessionId;
            if (this.PlayerDataMap != null)
            {
                context.PlayerDataMap = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.PlayerDataMap.Keys)
                {
                    context.PlayerDataMap.Add((String)hashKey, (String)(this.PlayerDataMap[hashKey]));
                }
            }
            if (this.PlayerId != null)
            {
                context.PlayerIds = new List<System.String>(this.PlayerId);
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
            var request = new Amazon.GameLift.Model.CreatePlayerSessionsRequest();
            
            if (cmdletContext.GameSessionId != null)
            {
                request.GameSessionId = cmdletContext.GameSessionId;
            }
            if (cmdletContext.PlayerDataMap != null)
            {
                request.PlayerDataMap = cmdletContext.PlayerDataMap;
            }
            if (cmdletContext.PlayerIds != null)
            {
                request.PlayerIds = cmdletContext.PlayerIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.PlayerSessions;
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
        
        private Amazon.GameLift.Model.CreatePlayerSessionsResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreatePlayerSessionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "CreatePlayerSessions");
            #if DESKTOP
            return client.CreatePlayerSessions(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreatePlayerSessionsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String GameSessionId { get; set; }
            public Dictionary<System.String, System.String> PlayerDataMap { get; set; }
            public List<System.String> PlayerIds { get; set; }
        }
        
    }
}
