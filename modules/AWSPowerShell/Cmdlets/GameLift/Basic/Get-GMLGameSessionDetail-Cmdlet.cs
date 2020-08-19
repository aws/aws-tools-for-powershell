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
    /// Retrieves properties, including the protection policy in force, for one or more game
    /// sessions. This operation can be used in several ways: (1) provide a <code>GameSessionId</code>
    /// or <code>GameSessionArn</code> to request details for a specific game session; (2)
    /// provide either a <code>FleetId</code> or an <code>AliasId</code> to request properties
    /// for all game sessions running on a fleet. 
    /// 
    ///  
    /// <para>
    /// To get game session record(s), specify just one of the following: game session ID,
    /// fleet ID, or alias ID. You can filter this request by game session status. Use the
    /// pagination parameters to retrieve results as a set of sequential pages. If successful,
    /// a <a>GameSessionDetail</a> object is returned for each session matching the request.
    /// </para><ul><li><para><a>CreateGameSession</a></para></li><li><para><a>DescribeGameSessions</a></para></li><li><para><a>DescribeGameSessionDetails</a></para></li><li><para><a>SearchGameSessions</a></para></li><li><para><a>UpdateGameSession</a></para></li><li><para><a>GetGameSessionLogUrl</a></para></li><li><para>
    /// Game session placements
    /// </para><ul><li><para><a>StartGameSessionPlacement</a></para></li><li><para><a>DescribeGameSessionPlacement</a></para></li><li><para><a>StopGameSessionPlacement</a></para></li></ul></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GMLGameSessionDetail")]
    [OutputType("Amazon.GameLift.Model.GameSessionDetail")]
    [AWSCmdlet("Calls the Amazon GameLift Service DescribeGameSessionDetails API operation.", Operation = new[] {"DescribeGameSessionDetails"}, SelectReturnType = typeof(Amazon.GameLift.Model.DescribeGameSessionDetailsResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSessionDetail or Amazon.GameLift.Model.DescribeGameSessionDetailsResponse",
        "This cmdlet returns a collection of Amazon.GameLift.Model.GameSessionDetail objects.",
        "The service call response (type Amazon.GameLift.Model.DescribeGameSessionDetailsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGMLGameSessionDetailCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter AliasId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for an alias associated with the fleet to retrieve all game sessions
        /// for. You can use either the alias ID or ARN value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AliasId { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a fleet to retrieve all game sessions active on the fleet.
        /// You can use either the fleet ID or ARN value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter GameSessionId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the game session to retrieve. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GameSessionId { get; set; }
        #endregion
        
        #region Parameter StatusFilter
        /// <summary>
        /// <para>
        /// <para>Game session status to filter results on. Possible game session statuses include <code>ACTIVE</code>,
        /// <code>TERMINATED</code>, <code>ACTIVATING</code> and <code>TERMINATING</code> (the
        /// last two are transitory). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StatusFilter { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return. Use this parameter with <code>NextToken</code>
        /// to get results as a set of sequential pages.</para>
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
        /// that is returned with a previous call to this operation. To start at the beginning
        /// of the result set, do not specify a value.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GameSessionDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.DescribeGameSessionDetailsResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.DescribeGameSessionDetailsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GameSessionDetails";
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
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.DescribeGameSessionDetailsResponse, GetGMLGameSessionDetailCmdlet>(Select) ??
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
            context.AliasId = this.AliasId;
            context.FleetId = this.FleetId;
            context.GameSessionId = this.GameSessionId;
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
            context.StatusFilter = this.StatusFilter;
            
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
            var request = new Amazon.GameLift.Model.DescribeGameSessionDetailsRequest();
            
            if (cmdletContext.AliasId != null)
            {
                request.AliasId = cmdletContext.AliasId;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.GameSessionId != null)
            {
                request.GameSessionId = cmdletContext.GameSessionId;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.StatusFilter != null)
            {
                request.StatusFilter = cmdletContext.StatusFilter;
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
            var request = new Amazon.GameLift.Model.DescribeGameSessionDetailsRequest();
            if (cmdletContext.AliasId != null)
            {
                request.AliasId = cmdletContext.AliasId;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.GameSessionId != null)
            {
                request.GameSessionId = cmdletContext.GameSessionId;
            }
            if (cmdletContext.StatusFilter != null)
            {
                request.StatusFilter = cmdletContext.StatusFilter;
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
                    int _receivedThisCall = response.GameSessionDetails.Count;
                    
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
        
        private Amazon.GameLift.Model.DescribeGameSessionDetailsResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.DescribeGameSessionDetailsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "DescribeGameSessionDetails");
            try
            {
                #if DESKTOP
                return client.DescribeGameSessionDetails(request);
                #elif CORECLR
                return client.DescribeGameSessionDetailsAsync(request).GetAwaiter().GetResult();
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
            public System.String FleetId { get; set; }
            public System.String GameSessionId { get; set; }
            public int? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.String StatusFilter { get; set; }
            public System.Func<Amazon.GameLift.Model.DescribeGameSessionDetailsResponse, GetGMLGameSessionDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameSessionDetails;
        }
        
    }
}
