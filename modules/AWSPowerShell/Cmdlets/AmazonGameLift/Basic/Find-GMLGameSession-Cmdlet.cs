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
    /// Retrieves a set of game sessions that match a set of search criteria and sorts them
    /// in a specified order. A game session search is limited to a single fleet. Search results
    /// include only game sessions that are in <code>ACTIVE</code> status. If you need to
    /// retrieve game sessions with a status other than active, use <a>DescribeGameSessions</a>.
    /// If you need to retrieve the protection policy for each game session, use <a>DescribeGameSessionDetails</a>.
    /// 
    ///  
    /// <para>
    /// You can search or sort by the following game session attributes:
    /// </para><ul><li><para><b>gameSessionId</b> -- Unique identifier for the game session. You can use either
    /// a <code>GameSessionId</code> or <code>GameSessionArn</code> value. 
    /// </para></li><li><para><b>gameSessionName</b> -- Name assigned to a game session. This value is set when
    /// requesting a new game session with <a>CreateGameSession</a> or updating with <a>UpdateGameSession</a>.
    /// Game session names do not need to be unique to a game session.
    /// </para></li><li><para><b>creationTimeMillis</b> -- Value indicating when a game session was created. It
    /// is expressed in Unix time as milliseconds.
    /// </para></li><li><para><b>playerSessionCount</b> -- Number of players currently connected to a game session.
    /// This value changes rapidly as players join the session or drop out.
    /// </para></li><li><para><b>maximumSessions</b> -- Maximum number of player sessions allowed for a game session.
    /// This value is set when requesting a new game session with <a>CreateGameSession</a>
    /// or updating with <a>UpdateGameSession</a>.
    /// </para></li><li><para><b>hasAvailablePlayerSessions</b> -- Boolean value indicating whether a game session
    /// has reached its maximum number of players. When searching with this attribute, the
    /// search value must be <code>true</code> or <code>false</code>. It is highly recommended
    /// that all search requests include this filter attribute to optimize search performance
    /// and return only sessions that players can join. 
    /// </para></li></ul><para>
    /// To search or sort, specify either a fleet ID or an alias ID, and provide a search
    /// filter expression, a sort expression, or both. Use the pagination parameters to retrieve
    /// results as a set of sequential pages. If successful, a collection of <a>GameSession</a>
    /// objects matching the request is returned.
    /// </para><note><para>
    /// Returned values for <code>playerSessionCount</code> and <code>hasAvailablePlayerSessions</code>
    /// change quickly as players join sessions and others drop out. Results should be considered
    /// a snapshot in time. Be sure to refresh search results often, and handle sessions that
    /// fill up before a player can join. 
    /// </para></note><para>
    /// Game-session-related operations include:
    /// </para><ul><li><para><a>CreateGameSession</a></para></li><li><para><a>DescribeGameSessions</a></para></li><li><para><a>DescribeGameSessionDetails</a></para></li><li><para><a>SearchGameSessions</a></para></li><li><para><a>UpdateGameSession</a></para></li><li><para><a>GetGameSessionLogUrl</a></para></li><li><para>
    /// Game session placements
    /// </para><ul><li><para><a>StartGameSessionPlacement</a></para></li><li><para><a>DescribeGameSessionPlacement</a></para></li><li><para><a>StopGameSessionPlacement</a></para></li></ul></li></ul><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Find", "GMLGameSession")]
    [OutputType("Amazon.GameLift.Model.GameSession")]
    [AWSCmdlet("Calls the Amazon GameLift Service SearchGameSessions API operation.", Operation = new[] {"SearchGameSessions"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSession",
        "This cmdlet returns a collection of GameSession objects.",
        "The service call response (type Amazon.GameLift.Model.SearchGameSessionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class FindGMLGameSessionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter AliasId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for an alias associated with the fleet to search for active game
        /// sessions. Each request must reference either a fleet ID or alias ID, but not both.</para>
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
        /// <code>gameSessionId</code>, <code>creationTimeMillis</code>, <code>playerSessionCount</code>,
        /// <code>maximumSessions</code>, <code>hasAvailablePlayerSessions</code>.</para></li><li><para><b>Comparator</b> -- Valid comparators are: <code>=</code>, <code>&lt;&gt;</code>,
        /// <code>&lt;</code>, <code>&gt;</code>, <code>&lt;=</code>, <code>&gt;=</code>. </para></li><li><para><b>Value</b> -- Value to be searched for. Values can be numbers, boolean values (true/false)
        /// or strings. String values are case sensitive, enclosed in single quotes. Special characters
        /// must be escaped. Boolean and string values can only be used with the comparators <code>=</code>
        /// and <code>&lt;&gt;</code>. For example, the following filter expression searches on
        /// <code>gameSessionName</code>: "<code>FilterExpression": "gameSessionName = 'Matt\\'s
        /// Awesome Game 1'"</code>. </para></li></ul><para>To chain multiple conditions in a single expression, use the logical keywords <code>AND</code>,
        /// <code>OR</code>, and <code>NOT</code> and parentheses as needed. For example: <code>x
        /// AND y AND NOT z</code>, <code>NOT (x OR y)</code>.</para><para>Session search evaluates conditions from left to right using the following precedence
        /// rules:</para><ol><li><para><code>=</code>, <code>&lt;&gt;</code>, <code>&lt;</code>, <code>&gt;</code>, <code>&lt;=</code>,
        /// <code>&gt;=</code></para></li><li><para>Parentheses</para></li><li><para>NOT</para></li><li><para>AND</para></li><li><para>OR</para></li></ol><para>For example, this filter expression retrieves game sessions hosting at least ten players
        /// that have an open player slot: <code>"maximumSessions&gt;=10 AND hasAvailablePlayerSessions=true"</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FilterExpression { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a fleet to search for active game sessions. Each request must
        /// reference either a fleet ID or alias ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter SortExpression
        /// <summary>
        /// <para>
        /// <para>Instructions on how to sort the search results. If no sort expression is included,
        /// the request returns results in random order. A sort expression consists of the following
        /// elements:</para><ul><li><para><b>Operand</b> -- Name of a game session attribute. Valid values are <code>gameSessionName</code>,
        /// <code>gameSessionId</code>, <code>creationTimeMillis</code>, <code>playerSessionCount</code>,
        /// <code>maximumSessions</code>, <code>hasAvailablePlayerSessions</code>.</para></li><li><para><b>Order</b> -- Valid sort orders are <code>ASC</code> (ascending) and <code>DESC</code>
        /// (descending).</para></li></ul><para>For example, this sort expression returns the oldest active sessions first: <code>"SortExpression":
        /// "creationTimeMillis ASC"</code>. Results with a null value for the sort operand are
        /// returned at the end of the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SortExpression { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>Maximum number of results to return. Use this parameter with <code>NextToken</code>
        /// to get results as a set of sequential pages. The maximum number of results returned
        /// is 20, even if this value is not set or is set higher than 20. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int Limit { get; set; }
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
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AliasId = this.AliasId;
            context.FilterExpression = this.FilterExpression;
            context.FleetId = this.FleetId;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            context.SortExpression = this.SortExpression;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
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
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.Limit))
            {
                _emitLimit = cmdletContext.Limit;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.Limit);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.GameSessions;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.GameSessions.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SearchGameSessionsAsync(request);
                return task.Result;
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
        }
        
    }
}
