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
    /// Retrieves build records for all builds associated with the AWS account in use. You
    /// can limit results to builds in a specific state using the <code>Status</code> parameter.
    /// Use the pagination parameters to retrieve results in a set of sequential pages. 
    /// 
    ///  <note><para>
    /// Build records are not listed in any particular order.
    /// </para></note><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "GMLBuild")]
    [OutputType("Amazon.GameLift.Model.Build")]
    [AWSCmdlet("Invokes the ListBuilds operation against Amazon GameLift Service.", Operation = new[] {"ListBuilds"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.Build",
        "This cmdlet returns a collection of Build objects.",
        "The service call response (type Amazon.GameLift.Model.ListBuildsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetGMLBuildCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Build state to filter results by. To retrieve all builds, leave this parameter empty.
        /// Possible build states include the following: <ul><li><b>INITIALIZED</b> – A new build
        /// has been defined, but no files have been uploaded. You cannot create fleets for builds
        /// that are in this state. When a build is successfully created, the build state is set
        /// to this value. </li><li><b>READY</b> – The game build has been successfully uploaded.
        /// You can now create new fleets for this build.</li><li><b>FAILED</b> – The game build
        /// upload failed. You cannot create new fleets for this build. </li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GameLift.BuildStatus")]
        public Amazon.GameLift.BuildStatus Status { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>Maximum number of results to return. Use this parameter with <code>NextToken</code>
        /// to get results as a set of sequential pages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("MaxItems")]
        public int Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Token indicating the start of the next sequential page of results. Use the token that
        /// is returned with a previous call to this action. To specify the start of the result
        /// set, do not specify a value.</para>
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
            
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            context.Status = this.Status;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.GameLift.Model.ListBuildsRequest();
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
                        object pipelineOutput = response.Builds;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Builds.Count;
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
        
        private static Amazon.GameLift.Model.ListBuildsResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.ListBuildsRequest request)
        {
            return client.ListBuilds(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public int? Limit { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.GameLift.BuildStatus Status { get; set; }
        }
        
    }
}
