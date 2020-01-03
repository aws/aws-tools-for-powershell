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
    /// Retrieves all active game sessions that match a set of search criteria and sorts them
    /// in a specified order. You can search or sort by the following game session attributes:
    /// 
    ///  <ul><li><para><b>gameSessionId</b> -- A unique identifier for the game session. You can use either
    /// a <code>GameSessionId</code> or <code>GameSessionArn</code> value. 
    /// </para></li><li><para><b>gameSessionName</b> -- Name assigned to a game session. This value is set when
    /// requesting a new game session with <a>CreateGameSession</a> or updating with <a>UpdateGameSession</a>.
    /// Game session names do not need to be unique to a game session.
    /// </para></li><li><para><b>gameSessionProperties</b> -- Custom data defined in a game session's <code>GameProperty</code>
    /// parameter. <code>GameProperty</code> values are stored as key:value pairs; the filter
    /// expression must indicate the key and a string to search the data values for. For example,
    /// to search for game sessions with custom data containing the key:value pair "gameMode:brawl",
    /// specify the following: <code>gameSessionProperties.gameMode = "brawl"</code>. All
    /// custom data values are searched as strings.
    /// </para></li><li><para><b>maximumSessions</b> -- Maximum number of player sessions allowed for a game session.
    /// This value is set when requesting a new game session with <a>CreateGameSession</a>
    /// or updating with <a>UpdateGameSession</a>.
    /// </para></li><li><para><b>creationTimeMillis</b> -- Value indicating when a game session was created. It
    /// is expressed in Unix time as milliseconds.
    /// </para></li><li><para><b>playerSessionCount</b> -- Number of players currently connected to a game session.
    /// This value changes rapidly as players join the session or drop out.
    /// </para></li><li><para><b>hasAvailablePlayerSessions</b> -- Boolean value indicating whether a game session
    /// has reached its maximum number of players. It is highly recommended that all search
    /// requests include this filter attribute to optimize search performance and return only
    /// sessions that players can join. 
    /// </para></li></ul><note><para>
    /// Returned values for <code>playerSessionCount</code> and <code>hasAvailablePlayerSessions</code>
    /// change quickly as players join sessions and others drop out. Results should be considered
    /// a snapshot in time. Be sure to refresh search results often, and handle sessions that
    /// fill up before a player can join. 
    /// </para></note><para>
    /// To search or sort, specify either a fleet ID or an alias ID, and provide a search
    /// filter expression, a sort expression, or both. If successful, a collection of <a>GameSession</a>
    /// objects matching the request is returned. Use the pagination parameters to retrieve
    /// results as a set of sequential pages. 
    /// </para><para>
    /// You can search for game sessions one fleet at a time only. To find game sessions across
    /// multiple fleets, you must search each fleet separately and combine the results. This
    /// search feature finds only game sessions that are in <code>ACTIVE</code> status. To
    /// locate games in statuses other than active, use <a>DescribeGameSessionDetails</a>.
    /// </para><ul><li><para><a>CreateGameSession</a></para></li><li><para><a>DescribeGameSessions</a></para></li><li><para><a>DescribeGameSessionDetails</a></para></li><li><para><a>SearchGameSessions</a></para></li><li><para><a>UpdateGameSession</a></para></li><li><para><a>GetGameSessionLogUrl</a></para></li><li><para>
    /// Game session placements
    /// </para><ul><li><para><a>StartGameSessionPlacement</a></para></li><li><para><a>DescribeGameSessionPlacement</a></para></li><li><para><a>StopGameSessionPlacement</a></para></li></ul></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Find", "GMLGameSession")]
    [OutputType("Amazon.GameLift.Model.GameSession")]
    [AWSCmdlet("Calls the Amazon GameLift Service SearchGameSessions API operation.", Operation = new[] {"SearchGameSessions"}, SelectReturnType = typeof(Amazon.GameLift.Model.SearchGameSessionsResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSession or Amazon.GameLift.Model.SearchGameSessionsResponse",
        "This cmdlet returns a collection of Amazon.GameLift.Model.GameSession objects.",
        "The service call response (type Amazon.GameLift.Model.SearchGameSessionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class FindGMLGameSessionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter AliasId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for an alias associated with the fleet to search for active game
        /// sessions. You can use either the alias ID or ARN value. Each request must reference
        /// either a fleet ID or alias ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AliasId { get; set; }
        #endregion
        
        #region Parameter FilterExpression
        /// <summary>
        /// <para>
        /// <para>String containing the search criteria for the session search. If no filter expression
        /// is included, the request returns results for all game sessions in the fleet that are
        /// in <code>ACTIVE</code> status.</para><para>A filter expression can contain one or multiple conditions. Each condition consists
        /// of the following:</para><ul><li><para><b>Operand</b> -- Name of a game session attribute. Valid values are <code>gameSessionName</code>,
        /// <code>gameSessionId</code>, <code>gameSessionProperties</code>, <code>maximumSessions</code>,
        /// <code>creationTimeMillis</code>, <code>playerSessionCount</code>, <code>hasAvailablePlayerSessions</code>.</para></li><li><para><b>Comparator</b> -- Valid comparators are: <code>=</code>, <code>&lt;&gt;</code>,
        /// <code>&lt;</code>, <code>&gt;</code>, <code>&lt;=</code>, <code>&gt;=</code>. </para></li><li><para><b>Value</b> -- Value to be searched for. Values may be numbers, boolean values (true/false)
        /// or strings depending on the operand. String values are case sensitive and must be
        /// enclosed in single quotes. Special characters must be escaped. Boolean and string
        /// values can only be used with the comparators <code>=</code> and <code>&lt;&gt;</code>.
        /// For example, the following filter expression searches on <code>gameSessionName</code>:
        /// "<code>FilterExpression": "gameSessionName = 'Matt\\'s Awesome Game 1'"</code>. </para></li></ul><para>To chain multiple conditions in a single expression, use the logical keywords <code>AND</code>,
        /// <code>OR</code>, and <code>NOT</code> and parentheses as needed. For example: <code>x
        /// AND y AND NOT z</code>, <code>NOT (x OR y)</code>.</para><para>Session search evaluates conditions from left to right using the following precedence
        /// rules:</para><ol><li><para><code>=</code>, <code>&lt;&gt;</code>, <code>&lt;</code>, <code>&gt;</code>, <code>&lt;=</code>,
        /// <code>&gt;=</code></para></li><li><para>Parentheses</para></li><li><para>NOT</para></li><li><para>AND</para></li><li><para>OR</para></li></ol><para>For example, this filter expression retrieves game sessions hosting at least ten players
        /// that have an open player slot: <code>"maximumSessions&gt;=10 AND hasAvailablePlayerSessions=true"</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterExpression { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a fleet to search for active game sessions. You can use either
        /// the fleet ID or ARN value. Each request must reference either a fleet ID or alias
        /// ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter SortExpression
        /// <summary>
        /// <para>
        /// <para>Instructions on how to sort the search results. If no sort expression is included,
        /// the request returns results in random order. A sort expression consists of the following
        /// elements:</para><ul><li><para><b>Operand</b> -- Name of a game session attribute. Valid values are <code>gameSessionName</code>,
        /// <code>gameSessionId</code>, <code>gameSessionProperties</code>, <code>maximumSessions</code>,
        /// <code>creationTimeMillis</code>, <code>playerSessionCount</code>, <code>hasAvailablePlayerSessions</code>.</para></li><li><para><b>Order</b> -- Valid sort orders are <code>ASC</code> (ascending) and <code>DESC</code>
        /// (descending).</para></li></ul><para>For example, this sort expression returns the oldest active sessions first: <code>"SortExpression":
        /// "creationTimeMillis ASC"</code>. Results with a null value for the sort operand are
        /// returned at the end of the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SortExpression { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return. Use this parameter with <code>NextToken</code>
        /// to get results as a set of sequential pages. The maximum number of results returned
        /// is 20, even if this value is not set or is set higher than 20. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Token that indicates the start of the next sequential page of results. Use the token
        /// that is returned with a previous call to this action. To start at the beginning of
        /// the result set, do not specify a value.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GameSessions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.SearchGameSessionsResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.SearchGameSessionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GameSessions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FleetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FleetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FleetId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.SearchGameSessionsResponse, FindGMLGameSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FleetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AliasId = this.AliasId;
            context.FilterExpression = this.FilterExpression;
            context.FleetId = this.FleetId;
            context.Limit = this.Limit;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.Limit)) && this.Limit.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the Limit parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing Limit" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.SortExpression = this.SortExpression;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.GameLift.Model.SearchGameSessionsRequest();
            
            if (cmdletContext.AliasId != null)
            {
                request.AliasId = cmdletContext.AliasId;
            }
            if (cmdletContext.FilterExpression != null)
            {
                request.FilterExpression = cmdletContext.FilterExpression;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.SortExpression != null)
            {
                request.SortExpression = cmdletContext.SortExpression;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.GameLift.Model.SearchGameSessionsRequest();
            if (cmdletContext.AliasId != null)
            {
                request.AliasId = cmdletContext.AliasId;
            }
            if (cmdletContext.FilterExpression != null)
            {
                request.FilterExpression = cmdletContext.FilterExpression;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.SortExpression != null)
            {
                request.SortExpression = cmdletContext.SortExpression;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.Limit))
            {
                _emitLimit = cmdletContext.Limit;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                }
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    int _receivedThisCall = response.GameSessions.Count;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.GameLift.Model.SearchGameSessionsResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.SearchGameSessionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "SearchGameSessions");
            try
            {
                #if DESKTOP
                return client.SearchGameSessions(request);
                #elif CORECLR
                return client.SearchGameSessionsAsync(request).GetAwaiter().GetResult();
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
            public System.String FilterExpression { get; set; }
            public System.String FleetId { get; set; }
            public int? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.String SortExpression { get; set; }
            public System.Func<Amazon.GameLift.Model.SearchGameSessionsResponse, FindGMLGameSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameSessions;
        }
        
    }
}
