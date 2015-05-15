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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Returns a list of the available DB engines.
    /// </summary>
    [Cmdlet("Get", "RDSDBEngineVersion")]
    [OutputType("Amazon.RDS.Model.DBEngineVersion")]
    [AWSCmdlet("Invokes the DescribeDBEngineVersions operation against Amazon Relational Database Service.", Operation = new[] {"DescribeDBEngineVersions"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBEngineVersion",
        "This cmdlet returns a collection of DBEngineVersion objects.",
        "The service call response (type DescribeDBEngineVersionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type String)"
    )]
    public class GetRDSDBEngineVersionCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The name of a specific DB parameter group family to return details for. </para><para>Constraints:</para><ul><li>Must be 1 to 255 alphanumeric characters</li><li>First character must be
        /// a letter</li><li>Cannot end with a hyphen or contain two consecutive hyphens</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String DBParameterGroupFamily { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Indicates that only the default version of the specified engine or engine and major
        /// version combination is returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean DefaultOnly { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The database engine to return. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String Engine { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The database engine version to return. </para><para>Example: <code>5.1.49</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String EngineVersion { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Not currently supported. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.RDS.Model.Filter[] Filter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If this parameter is specified, and if the requested engine supports the CharacterSetName
        /// parameter for CreateDBInstance, the response includes a list of supported character
        /// sets for each engine version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean ListSupportedCharacterSets { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> An optional pagination token provided by a previous request. If this parameter is
        /// specified, the response includes only records beyond the marker, up to the value specified
        /// by <code>MaxRecords</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public String Marker { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The maximum number of records to include in the response. If more than the <code>MaxRecords</code>
        /// value is available, a pagination token called a marker is included in the response
        /// so that the following results can be retrieved. </para><para>Default: 100</para><para>Constraints: minimum 20, maximum 100</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxRecords")]
        public int MaxRecord { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DBParameterGroupFamily = this.DBParameterGroupFamily;
            if (ParameterWasBound("DefaultOnly"))
                context.DefaultOnly = this.DefaultOnly;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            if (this.Filter != null)
            {
                context.Filters = new List<Filter>(this.Filter);
            }
            if (ParameterWasBound("ListSupportedCharacterSets"))
                context.ListSupportedCharacterSets = this.ListSupportedCharacterSets;
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxRecord"))
                context.MaxRecords = this.MaxRecord;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new DescribeDBEngineVersionsRequest();
            if (cmdletContext.DBParameterGroupFamily != null)
            {
                request.DBParameterGroupFamily = cmdletContext.DBParameterGroupFamily;
            }
            if (cmdletContext.DefaultOnly != null)
            {
                request.DefaultOnly = cmdletContext.DefaultOnly.Value;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.ListSupportedCharacterSets != null)
            {
                request.ListSupportedCharacterSets = cmdletContext.ListSupportedCharacterSets.Value;
            }
            
            // Initialize loop variants and commence piping
            String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxRecords))
            {
                _emitLimit = cmdletContext.MaxRecords;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.Marker) || AutoIterationHelpers.HasValue(cmdletContext.MaxRecords);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = client.DescribeDBEngineVersions(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.DBEngineVersions;
                        notes = new Dictionary<string, object>();
                        notes["Marker"] = response.Marker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.DBEngineVersions.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.Marker;
                        
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
            public String DBParameterGroupFamily { get; set; }
            public Boolean? DefaultOnly { get; set; }
            public String Engine { get; set; }
            public String EngineVersion { get; set; }
            public List<Filter> Filters { get; set; }
            public Boolean? ListSupportedCharacterSets { get; set; }
            public String Marker { get; set; }
            public int? MaxRecords { get; set; }
        }
        
    }
}
