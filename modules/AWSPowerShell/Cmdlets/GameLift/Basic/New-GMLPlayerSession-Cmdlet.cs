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
    /// Reserves open slots in a game session for a group of players. New player sessions
    /// can be created in any game session with an open slot that is in <code>ACTIVE</code>
    /// status and has a player creation policy of <code>ACCEPT_ALL</code>. To add a single
    /// player to a game session, use <a>CreatePlayerSession</a>. 
    /// 
    ///  
    /// <para>
    /// To create player sessions, specify a game session ID and a list of player IDs. Optionally,
    /// provide a set of player data for each player ID. 
    /// </para><para>
    /// If successful, a slot is reserved in the game session for each player, and new <a>PlayerSession</a>
    /// objects are returned with player session IDs. Each player references their player
    /// session ID when sending a connection request to the game session, and the game server
    /// can use it to validate the player reservation with the GameLift service. Player sessions
    /// cannot be updated.
    /// </para><para>
    /// The maximum number of players per game session is 200. It is not adjustable. 
    /// </para><para><i>Available in Amazon GameLift Local.</i></para><para><b>Related actions</b></para><para><a>CreatePlayerSession</a> | <a>CreatePlayerSessions</a> | <a>DescribePlayerSessions</a>
    /// | <a>StartGameSessionPlacement</a> | <a>DescribeGameSessionPlacement</a> | <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/reference-awssdk.html#reference-awssdk-resources-fleets">All
    /// APIs by task</a></para>
    /// </summary>
    [Cmdlet("New", "GMLPlayerSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.PlayerSession")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreatePlayerSessions API operation.", Operation = new[] {"CreatePlayerSessions"}, SelectReturnType = typeof(Amazon.GameLift.Model.CreatePlayerSessionsResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.PlayerSession or Amazon.GameLift.Model.CreatePlayerSessionsResponse",
        "This cmdlet returns a collection of Amazon.GameLift.Model.PlayerSession objects.",
        "The service call response (type Amazon.GameLift.Model.CreatePlayerSessionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLPlayerSessionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter GameSessionId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the game session to add players to.</para>
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
        public System.String GameSessionId { get; set; }
        #endregion
        
        #region Parameter PlayerDataMap
        /// <summary>
        /// <para>
        /// <para>Map of string pairs, each specifying a player ID and a set of developer-defined information
        /// related to the player. Amazon GameLift does not use this data, so it can be formatted
        /// as needed for use in the game. Any player data strings for player IDs that are not
        /// included in the <code>PlayerIds</code> parameter are ignored. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable PlayerDataMap { get; set; }
        #endregion
        
        #region Parameter PlayerId
        /// <summary>
        /// <para>
        /// <para>List of unique identifiers for the players to be added.</para>
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
        [Alias("PlayerIds")]
        public System.String[] PlayerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PlayerSessions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.CreatePlayerSessionsResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.CreatePlayerSessionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PlayerSessions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GameSessionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GameSessionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GameSessionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GameSessionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLPlayerSession (CreatePlayerSessions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.CreatePlayerSessionsResponse, NewGMLPlayerSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GameSessionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GameSessionId = this.GameSessionId;
            #if MODULAR
            if (this.GameSessionId == null && ParameterWasBound(nameof(this.GameSessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter GameSessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
                context.PlayerId = new List<System.String>(this.PlayerId);
            }
            #if MODULAR
            if (this.PlayerId == null && ParameterWasBound(nameof(this.PlayerId)))
            {
                WriteWarning("You are passing $null as a value for parameter PlayerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            if (cmdletContext.PlayerId != null)
            {
                request.PlayerIds = cmdletContext.PlayerId;
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
        
        private Amazon.GameLift.Model.CreatePlayerSessionsResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreatePlayerSessionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "CreatePlayerSessions");
            try
            {
                #if DESKTOP
                return client.CreatePlayerSessions(request);
                #elif CORECLR
                return client.CreatePlayerSessionsAsync(request).GetAwaiter().GetResult();
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
            public System.String GameSessionId { get; set; }
            public Dictionary<System.String, System.String> PlayerDataMap { get; set; }
            public List<System.String> PlayerId { get; set; }
            public System.Func<Amazon.GameLift.Model.CreatePlayerSessionsResponse, NewGMLPlayerSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PlayerSessions;
        }
        
    }
}
