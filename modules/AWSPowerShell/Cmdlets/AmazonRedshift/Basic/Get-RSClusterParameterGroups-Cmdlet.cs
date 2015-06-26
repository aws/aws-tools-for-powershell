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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Returns a list of Amazon Redshift parameter groups, including parameter groups you
    /// created and the default parameter group. For each parameter group, the response includes
    /// the parameter group name, description, and parameter group family name. You can optionally
    /// specify a name to retrieve the description of a specific parameter group. 
    /// 
    ///  
    /// <para>
    ///  For more information about parameters and parameter groups, go to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-parameter-groups.html">Amazon
    /// Redshift Parameter Groups</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// 
    /// </para><para>
    /// If you specify both tag keys and tag values in the same request, Amazon Redshift returns
    /// all parameter groups that match any combination of the specified keys and values.
    /// For example, if you have <code>owner</code> and <code>environment</code> for tag keys,
    /// and <code>admin</code> and <code>test</code> for tag values, all parameter groups
    /// that have any combination of those values are returned.
    /// </para><para>
    /// If both tag keys and values are omitted from the request, parameter groups are returned
    /// regardless of whether they have tag keys or values associated with them.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "RSClusterParameterGroups")]
    [OutputType("Amazon.Redshift.Model.ClusterParameterGroup")]
    [AWSCmdlet("Invokes the DescribeClusterParameterGroups operation against Amazon Redshift.", Operation = new[] {"DescribeClusterParameterGroups"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.ClusterParameterGroup",
        "This cmdlet returns a collection of ClusterParameterGroup objects.",
        "The service call response (type DescribeClusterParameterGroupsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type String)"
    )]
    public class GetRSClusterParameterGroupsCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The name of a specific parameter group for which to return details. By default, details
        /// about all parameter groups and the default parameter group are returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String ParameterGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A tag key or keys for which you want to return all matching cluster parameter groups
        /// that are associated with the specified key or keys. For example, suppose that you
        /// have parameter groups that are tagged with keys called <code>owner</code> and <code>environment</code>.
        /// If you specify both of these tag keys in the request, Amazon Redshift returns a response
        /// with the parameter groups that have either or both of these tag keys associated with
        /// them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TagKeys")]
        public System.String[] TagKey { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A tag value or values for which you want to return all matching cluster parameter
        /// groups that are associated with the specified tag value or values. For example, suppose
        /// that you have parameter groups that are tagged with values called <code>admin</code>
        /// and <code>test</code>. If you specify both of these tag values in the request, Amazon
        /// Redshift returns a response with the parameter groups that have either or both of
        /// these tag values associated with them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TagValues")]
        public System.String[] TagValue { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> An optional parameter that specifies the starting point to return a set of response
        /// records. When the results of a <a>DescribeClusterParameterGroups</a> request exceed
        /// the value specified in <code>MaxRecords</code>, AWS returns a value in the <code>Marker</code>
        /// field of the response. You can retrieve the next set of response records by providing
        /// the returned marker value in the <code>Marker</code> parameter and retrying the request.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public String Marker { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The maximum number of response records to return in each call. If the number of remaining
        /// response records exceeds the specified <code>MaxRecords</code> value, a value is returned
        /// in a <code>marker</code> field of the response. You can retrieve the next set of records
        /// by retrying the command with the returned marker value. </para><para>Default: <code>100</code></para><para>Constraints: minimum 20, maximum 100.</para>
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
            
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxRecord"))
                context.MaxRecords = this.MaxRecord;
            context.ParameterGroupName = this.ParameterGroupName;
            if (this.TagKey != null)
            {
                context.TagKeys = new List<String>(this.TagKey);
            }
            if (this.TagValue != null)
            {
                context.TagValues = new List<String>(this.TagValue);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new DescribeClusterParameterGroupsRequest();
            if (cmdletContext.ParameterGroupName != null)
            {
                request.ParameterGroupName = cmdletContext.ParameterGroupName;
            }
            if (cmdletContext.TagKeys != null)
            {
                request.TagKeys = cmdletContext.TagKeys;
            }
            if (cmdletContext.TagValues != null)
            {
                request.TagValues = cmdletContext.TagValues;
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
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, we rely on the service
                // ignoring the set maximum and giving us 100 items back. We'll
                // make further calls to satisfy the user's request.
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
                        
                        var response = client.DescribeClusterParameterGroups(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.ParameterGroups;
                        notes = new Dictionary<string, object>();
                        notes["Marker"] = response.Marker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.ParameterGroups.Count;
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
                    // The service has a maximum page size of 100 and the user has set a retrieval limit.
                    // Deduce what's left to fetch and if less than one page update _emitLimit to fetch just
                    // what's left to match the user's request.
                    
                    var _remainingItems = _emitLimit - _retrievedSoFar;
                    if (_remainingItems < 100)
                    {
                        _emitLimit = _remainingItems;
                    }
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
            public String Marker { get; set; }
            public int? MaxRecords { get; set; }
            public String ParameterGroupName { get; set; }
            public List<String> TagKeys { get; set; }
            public List<String> TagValues { get; set; }
        }
        
    }
}
