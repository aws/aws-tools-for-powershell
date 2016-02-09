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
    /// Retrieves properties for one or more player sessions. This action can be used in several
    /// ways: (1) provide a <i>PlayerSessionId</i> parameter to request properties for a specific
    /// player session; (2) provide a <i>GameSessionId</i> parameter to request properties
    /// for all player sessions in the specified game session; (3) provide a <i>PlayerId</i>
    /// parameter to request properties for all player sessions of a specified player. 
    /// 
    ///  
    /// <para>
    /// To get game session record(s), specify only one of the following: a player session
    /// ID, a game session ID, or a player ID. You can filter this request by player session
    /// status. Use the pagination parameters to retrieve results as a set of sequential pages.
    /// If successful, a <a>PlayerSession</a> object is returned for each session matching
    /// the request.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "GMLPlayerSession")]
    [OutputType("Amazon.GameLift.Model.PlayerSession")]
    [AWSCmdlet("Invokes the DescribePlayerSessions operation against Amazon GameLift Service.", Operation = new[] {"DescribePlayerSessions"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.PlayerSession",
        "This cmdlet returns a collection of PlayerSession objects.",
        "The service call response (type Amazon.GameLift.Model.DescribePlayerSessionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetGMLPlayerSessionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter GameSessionId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a game session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameSessionId { get; set; }
        #endregion
        
        #region Parameter PlayerId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a player.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PlayerId { get; set; }
        #endregion
        
        #region Parameter PlayerSessionId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a player session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PlayerSessionId { get; set; }
        #endregion
        
        #region Parameter PlayerSessionStatusFilter
        /// <summary>
        /// <para>
        /// <para>Player session status to filter results on. Possible player session states include:
        /// <ul><li>RESERVED: The player session request has been received, but the player has
        /// not yet connected to the game server and/or been validated. </li><li>ACTIVE: The player
        /// has been validated by the game server and is currently connected.</li><li>COMPLETED:
        /// The player connection has been dropped.</li><li>TIMEDOUT: A player session request
        /// was received, but the player did not connect and/or was not validated within the time-out
        /// limit (60 seconds).</li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PlayerSessionStatusFilter { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>Maximum number of results to return. You can use this parameter with <i>NextToken</i>
        /// to get results as a set of sequential pages. If a player session ID is specified,
        /// this parameter is ignored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Token indicating the start of the next sequential page of results. Use the token that
        /// is returned with a previous call to this action. To specify the start of the result
        /// set, do not specify a value. If a player session ID is specified, this parameter is
        /// ignored.</para>
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
            
            context.GameSessionId = this.GameSessionId;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            context.PlayerId = this.PlayerId;
            context.PlayerSessionId = this.PlayerSessionId;
            context.PlayerSessionStatusFilter = this.PlayerSessionStatusFilter;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.GameLift.Model.DescribePlayerSessionsRequest();
            if (cmdletContext.GameSessionId != null)
            {
                request.GameSessionId = cmdletContext.GameSessionId;
            }
            if (cmdletContext.PlayerId != null)
            {
                request.PlayerId = cmdletContext.PlayerId;
            }
            if (cmdletContext.PlayerSessionId != null)
            {
                request.PlayerSessionId = cmdletContext.PlayerSessionId;
            }
            if (cmdletContext.PlayerSessionStatusFilter != null)
            {
                request.PlayerSessionStatusFilter = cmdletContext.PlayerSessionStatusFilter;
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
                        
                        var response = client.DescribePlayerSessions(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.PlayerSessions;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.PlayerSessions.Count;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String GameSessionId { get; set; }
            public int? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.String PlayerId { get; set; }
            public System.String PlayerSessionId { get; set; }
            public System.String PlayerSessionStatusFilter { get; set; }
        }
        
    }
}
