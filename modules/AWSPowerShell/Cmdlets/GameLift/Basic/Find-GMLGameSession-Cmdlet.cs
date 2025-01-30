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
    /// Retrieves all active game sessions that match a set of search criteria and sorts them
    /// into a specified order. 
    /// 
    ///  
    /// <para>
    /// This operation is not designed to continually track game session status because that
    /// practice can cause you to exceed your API limit and generate errors. Instead, configure
    /// an Amazon Simple Notification Service (Amazon SNS) topic to receive notifications
    /// from a matchmaker or a game session placement queue.
    /// </para><para>
    /// When searching for game sessions, you specify exactly where you want to search and
    /// provide a search filter expression, a sort expression, or both. A search request can
    /// search only one fleet, but it can search all of a fleet's locations. 
    /// </para><para>
    /// This operation can be used in the following ways: 
    /// </para><ul><li><para>
    /// To search all game sessions that are currently running on all locations in a fleet,
    /// provide a fleet or alias ID. This approach returns game sessions in the fleet's home
    /// Region and all remote locations that fit the search criteria.
    /// </para></li><li><para>
    /// To search all game sessions that are currently running on a specific fleet location,
    /// provide a fleet or alias ID and a location name. For location, you can specify a fleet's
    /// home Region or any remote location.
    /// </para></li></ul><para>
    /// Use the pagination parameters to retrieve results as a set of sequential pages. 
    /// </para><para>
    /// If successful, a <c>GameSession</c> object is returned for each game session that
    /// matches the request. Search finds game sessions that are in <c>ACTIVE</c> status only.
    /// To retrieve information on game sessions in other statuses, use <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_DescribeGameSessions.html">DescribeGameSessions</a>.
    /// </para><para>
    /// To set search and sort criteria, create a filter expression using the following game
    /// session attributes. For game session search examples, see the Examples section of
    /// this topic.
    /// </para><ul><li><para><b>gameSessionId</b> -- A unique identifier for the game session. You can use either
    /// a <c>GameSessionId</c> or <c>GameSessionArn</c> value. 
    /// </para></li><li><para><b>gameSessionName</b> -- Name assigned to a game session. Game session names do
    /// not need to be unique to a game session.
    /// </para></li><li><para><b>gameSessionProperties</b> -- A set of key-value pairs that can store custom data
    /// in a game session. For example: <c>{"Key": "difficulty", "Value": "novice"}</c>. The
    /// filter expression must specify the <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_GameProperty">https://docs.aws.amazon.com/gamelift/latest/apireference/API_GameProperty</a>
    /// -- a <c>Key</c> and a string <c>Value</c> to search for the game sessions.
    /// </para><para>
    /// For example, to search for the above key-value pair, specify the following search
    /// filter: <c>gameSessionProperties.difficulty = "novice"</c>. All game property values
    /// are searched as strings.
    /// </para><para>
    ///  For examples of searching game sessions, see the ones below, and also see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-client-api.html#game-properties-search">Search
    /// game sessions by game property</a>. 
    /// </para></li><li><para><b>maximumSessions</b> -- Maximum number of player sessions allowed for a game session.
    /// </para></li><li><para><b>creationTimeMillis</b> -- Value indicating when a game session was created. It
    /// is expressed in Unix time as milliseconds.
    /// </para></li><li><para><b>playerSessionCount</b> -- Number of players currently connected to a game session.
    /// This value changes rapidly as players join the session or drop out.
    /// </para></li><li><para><b>hasAvailablePlayerSessions</b> -- Boolean value indicating whether a game session
    /// has reached its maximum number of players. It is highly recommended that all search
    /// requests include this filter attribute to optimize search performance and return only
    /// sessions that players can join. 
    /// </para></li></ul><note><para>
    /// Returned values for <c>playerSessionCount</c> and <c>hasAvailablePlayerSessions</c>
    /// change quickly as players join sessions and others drop out. Results should be considered
    /// a snapshot in time. Be sure to refresh search results often, and handle sessions that
    /// fill up before a player can join. 
    /// </para></note><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/reference-awssdk.html#reference-awssdk-resources-fleets">All
    /// APIs by task</a></para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Find", "GMLGameSession")]
    [OutputType("Amazon.GameLift.Model.GameSession")]
    [AWSCmdlet("Calls the Amazon GameLift Service SearchGameSessions API operation.", Operation = new[] {"SearchGameSessions"}, SelectReturnType = typeof(Amazon.GameLift.Model.SearchGameSessionsResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSession or Amazon.GameLift.Model.SearchGameSessionsResponse",
        "This cmdlet returns a collection of Amazon.GameLift.Model.GameSession objects.",
        "The service call response (type Amazon.GameLift.Model.SearchGameSessionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class FindGMLGameSessionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AliasId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the alias associated with the fleet to search for active game
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
        /// in <c>ACTIVE</c> status.</para><para>A filter expression can contain one or multiple conditions. Each condition consists
        /// of the following:</para><ul><li><para><b>Operand</b> -- Name of a game session attribute. Valid values are <c>gameSessionName</c>,
        /// <c>gameSessionId</c>, <c>gameSessionProperties</c>, <c>maximumSessions</c>, <c>creationTimeMillis</c>,
        /// <c>playerSessionCount</c>, <c>hasAvailablePlayerSessions</c>.</para></li><li><para><b>Comparator</b> -- Valid comparators are: <c>=</c>, <c>&lt;&gt;</c>, <c>&lt;</c>,
        /// <c>&gt;</c>, <c>&lt;=</c>, <c>&gt;=</c>. </para></li><li><para><b>Value</b> -- Value to be searched for. Values may be numbers, boolean values (true/false)
        /// or strings depending on the operand. String values are case sensitive and must be
        /// enclosed in single quotes. Special characters must be escaped. Boolean and string
        /// values can only be used with the comparators <c>=</c> and <c>&lt;&gt;</c>. For example,
        /// the following filter expression searches on <c>gameSessionName</c>: "<c>FilterExpression":
        /// "gameSessionName = 'Matt\\'s Awesome Game 1'"</c>. </para></li></ul><para>To chain multiple conditions in a single expression, use the logical keywords <c>AND</c>,
        /// <c>OR</c>, and <c>NOT</c> and parentheses as needed. For example: <c>x AND y AND NOT
        /// z</c>, <c>NOT (x OR y)</c>.</para><para>Session search evaluates conditions from left to right using the following precedence
        /// rules:</para><ol><li><para><c>=</c>, <c>&lt;&gt;</c>, <c>&lt;</c>, <c>&gt;</c>, <c>&lt;=</c>, <c>&gt;=</c></para></li><li><para>Parentheses</para></li><li><para>NOT</para></li><li><para>AND</para></li><li><para>OR</para></li></ol><para>For example, this filter expression retrieves game sessions hosting at least ten players
        /// that have an open player slot: <c>"maximumSessions&gt;=10 AND hasAvailablePlayerSessions=true"</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterExpression { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the fleet to search for active game sessions. You can use
        /// either the fleet ID or ARN value. Each request must reference either a fleet ID or
        /// alias ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <para>A fleet location to search for game sessions. You can specify a fleet's home Region
        /// or a remote location. Use the Amazon Web Services Region code format, such as <c>us-west-2</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location { get; set; }
        #endregion
        
        #region Parameter SortExpression
        /// <summary>
        /// <para>
        /// <para>Instructions on how to sort the search results. If no sort expression is included,
        /// the request returns results in random order. A sort expression consists of the following
        /// elements:</para><ul><li><para><b>Operand</b> -- Name of a game session attribute. Valid values are <c>gameSessionName</c>,
        /// <c>gameSessionId</c>, <c>gameSessionProperties</c>, <c>maximumSessions</c>, <c>creationTimeMillis</c>,
        /// <c>playerSessionCount</c>, <c>hasAvailablePlayerSessions</c>.</para></li><li><para><b>Order</b> -- Valid sort orders are <c>ASC</c> (ascending) and <c>DESC</c> (descending).</para></li></ul><para>For example, this sort expression returns the oldest active sessions first: <c>"SortExpression":
        /// "creationTimeMillis ASC"</c>. Results with a null value for the sort operand are returned
        /// at the end of the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SortExpression { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return. Use this parameter with <c>NextToken</c>
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
        /// <para>A token that indicates the start of the next sequential page of results. Use the token
        /// that is returned with a previous call to this operation. To start at the beginning
        /// of the result set, do not specify a value.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
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
            this._AWSSignerType = "v4";
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
            context.Location = this.Location;
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
            if (cmdletContext.Location != null)
            {
                request.Location = cmdletContext.Location;
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
            if (cmdletContext.Location != null)
            {
                request.Location = cmdletContext.Location;
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
            if (cmdletContext.Limit.HasValue)
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
            public System.String Location { get; set; }
            public System.String NextToken { get; set; }
            public System.String SortExpression { get; set; }
            public System.Func<Amazon.GameLift.Model.SearchGameSessionsResponse, FindGMLGameSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameSessions;
        }
        
    }
}
