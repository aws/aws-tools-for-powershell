/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.DocDB;
using Amazon.DocDB.Model;

namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Returns a list of the available DB engines.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "DOCDBEngineVersion")]
    [OutputType("Amazon.DocDB.Model.DBEngineVersion")]
    [AWSCmdlet("Calls the Amazon DocumentDB DescribeDBEngineVersions API operation.", Operation = new[] {"DescribeDBEngineVersions"})]
    [AWSCmdletOutput("Amazon.DocDB.Model.DBEngineVersion",
        "This cmdlet returns a collection of DBEngineVersion objects.",
        "The service call response (type Amazon.DocDB.Model.DescribeDBEngineVersionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type System.String)"
    )]
    public partial class GetDOCDBEngineVersionCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        #region Parameter DBParameterGroupFamily
        /// <summary>
        /// <para>
        /// <para>The name of a specific DB parameter group family to return details for.</para><para>Constraints:</para><ul><li><para>If provided, must match an existing <code>DBParameterGroupFamily</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DBParameterGroupFamily { get; set; }
        #endregion
        
        #region Parameter DefaultOnly
        /// <summary>
        /// <para>
        /// <para>Indicates that only the default version of the specified engine or engine and major
        /// version combination is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DefaultOnly { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The database engine to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The database engine version to return.</para><para>Example: <code>5.1.49</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>This parameter is not currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.DocDB.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter ListSupportedCharacterSet
        /// <summary>
        /// <para>
        /// <para>If this parameter is specified and the requested engine supports the <code>CharacterSetName</code>
        /// parameter for <code>CreateDBInstance</code>, the response includes a list of supported
        /// character sets for each engine version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ListSupportedCharacterSets")]
        public System.Boolean ListSupportedCharacterSet { get; set; }
        #endregion
        
        #region Parameter ListSupportedTimezone
        /// <summary>
        /// <para>
        /// <para>If this parameter is specified and the requested engine supports the <code>TimeZone</code>
        /// parameter for <code>CreateDBInstance</code>, the response includes a list of supported
        /// time zones for each engine version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ListSupportedTimezones")]
        public System.Boolean ListSupportedTimezone { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional pagination token provided by a previous request. If this parameter is
        /// specified, the response includes only records beyond the marker, up to the value specified
        /// by <code>MaxRecords</code>.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.Marker, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para> The maximum number of records to include in the response. If more records exist than
        /// the specified <code>MaxRecords</code> value, a pagination token (marker) is included
        /// in the response so that the remaining results can be retrieved.</para><para>Default: 100</para><para>Constraints: Minimum 20, maximum 100.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxRecords")]
        public int MaxRecord { get; set; }
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
            
            context.DBParameterGroupFamily = this.DBParameterGroupFamily;
            if (ParameterWasBound("DefaultOnly"))
                context.DefaultOnly = this.DefaultOnly;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.DocDB.Model.Filter>(this.Filter);
            }
            if (ParameterWasBound("ListSupportedCharacterSet"))
                context.ListSupportedCharacterSets = this.ListSupportedCharacterSet;
            if (ParameterWasBound("ListSupportedTimezone"))
                context.ListSupportedTimezones = this.ListSupportedTimezone;
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxRecord"))
                context.MaxRecords = this.MaxRecord;
            
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
            var request = new Amazon.DocDB.Model.DescribeDBEngineVersionsRequest();
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
            if (cmdletContext.ListSupportedTimezones != null)
            {
                request.ListSupportedTimezones = cmdletContext.ListSupportedTimezones.Value;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
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
            bool _userControllingPaging = ParameterWasBound("Marker") || ParameterWasBound("MaxRecord");
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
                        
                        var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.DocDB.Model.DescribeDBEngineVersionsResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.DescribeDBEngineVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB", "DescribeDBEngineVersions");
            try
            {
                #if DESKTOP
                return client.DescribeDBEngineVersions(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeDBEngineVersionsAsync(request);
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
            public System.String DBParameterGroupFamily { get; set; }
            public System.Boolean? DefaultOnly { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public List<Amazon.DocDB.Model.Filter> Filters { get; set; }
            public System.Boolean? ListSupportedCharacterSets { get; set; }
            public System.Boolean? ListSupportedTimezones { get; set; }
            public System.String Marker { get; set; }
            public int? MaxRecords { get; set; }
        }
        
    }
}
