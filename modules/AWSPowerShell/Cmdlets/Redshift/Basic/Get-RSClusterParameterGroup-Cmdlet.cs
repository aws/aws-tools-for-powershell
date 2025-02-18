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
using System.Threading;
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
    ///  For more information about parameters and parameter groups, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-parameter-groups.html">Amazon
    /// Redshift Parameter Groups</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// </para><para>
    /// If you specify both tag keys and tag values in the same request, Amazon Redshift returns
    /// all parameter groups that match any combination of the specified keys and values.
    /// For example, if you have <c>owner</c> and <c>environment</c> for tag keys, and <c>admin</c>
    /// and <c>test</c> for tag values, all parameter groups that have any combination of
    /// those values are returned.
    /// </para><para>
    /// If both tag keys and values are omitted from the request, parameter groups are returned
    /// regardless of whether they have tag keys or values associated with them.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RSClusterParameterGroup")]
    [OutputType("Amazon.Redshift.Model.ClusterParameterGroup")]
    [AWSCmdlet("Calls the Amazon Redshift DescribeClusterParameterGroups API operation.", Operation = new[] {"DescribeClusterParameterGroups"}, SelectReturnType = typeof(Amazon.Redshift.Model.DescribeClusterParameterGroupsResponse), LegacyAlias="Get-RSClusterParameterGroups")]
    [AWSCmdletOutput("Amazon.Redshift.Model.ClusterParameterGroup or Amazon.Redshift.Model.DescribeClusterParameterGroupsResponse",
        "This cmdlet returns a collection of Amazon.Redshift.Model.ClusterParameterGroup objects.",
        "The service call response (type Amazon.Redshift.Model.DescribeClusterParameterGroupsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRSClusterParameterGroupCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of a specific parameter group for which to return details. By default, details
        /// about all parameter groups and the default parameter group are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ParameterGroupName { get; set; }
        #endregion
        
        #region Parameter TagKey
        /// <summary>
        /// <para>
        /// <para>A tag key or keys for which you want to return all matching cluster parameter groups
        /// that are associated with the specified key or keys. For example, suppose that you
        /// have parameter groups that are tagged with keys called <c>owner</c> and <c>environment</c>.
        /// If you specify both of these tag keys in the request, Amazon Redshift returns a response
        /// with the parameter groups that have either or both of these tag keys associated with
        /// them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagKeys")]
        public System.String[] TagKey { get; set; }
        #endregion
        
        #region Parameter TagValue
        /// <summary>
        /// <para>
        /// <para>A tag value or values for which you want to return all matching cluster parameter
        /// groups that are associated with the specified tag value or values. For example, suppose
        /// that you have parameter groups that are tagged with values called <c>admin</c> and
        /// <c>test</c>. If you specify both of these tag values in the request, Amazon Redshift
        /// returns a response with the parameter groups that have either or both of these tag
        /// values associated with them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagValues")]
        public System.String[] TagValue { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional parameter that specifies the starting point to return a set of response
        /// records. When the results of a <a>DescribeClusterParameterGroups</a> request exceed
        /// the value specified in <c>MaxRecords</c>, Amazon Web Services returns a value in the
        /// <c>Marker</c> field of the response. You can retrieve the next set of response records
        /// by providing the returned marker value in the <c>Marker</c> parameter and retrying
        /// the request. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number of response records to return in each call. If the number of remaining
        /// response records exceeds the specified <c>MaxRecords</c> value, a value is returned
        /// in a <c>marker</c> field of the response. You can retrieve the next set of records
        /// by retrying the command with the returned marker value. </para><para>Default: <c>100</c></para><para>Constraints: minimum 20, maximum 100.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>100</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxRecords")]
        public int? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ParameterGroups'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.DescribeClusterParameterGroupsResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.DescribeClusterParameterGroupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ParameterGroups";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.DescribeClusterParameterGroupsResponse, GetRSClusterParameterGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            #if MODULAR
            if (!ParameterWasBound(nameof(this.MaxRecord)))
            {
                WriteVerbose("MaxRecord parameter unset, using default value of '100'");
                context.MaxRecord = 100;
            }
            #endif
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxRecord)) && this.MaxRecord.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxRecord parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxRecord" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.ParameterGroupName = this.ParameterGroupName;
            if (this.TagKey != null)
            {
                context.TagKey = new List<System.String>(this.TagKey);
            }
            if (this.TagValue != null)
            {
                context.TagValue = new List<System.String>(this.TagValue);
            }
            
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Redshift.Model.DescribeClusterParameterGroupsRequest();
            
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxRecord.Value);
            }
            if (cmdletContext.ParameterGroupName != null)
            {
                request.ParameterGroupName = cmdletContext.ParameterGroupName;
            }
            if (cmdletContext.TagKey != null)
            {
                request.TagKeys = cmdletContext.TagKey;
            }
            if (cmdletContext.TagValue != null)
            {
                request.TagValues = cmdletContext.TagValue;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Redshift.Model.DescribeClusterParameterGroupsRequest();
            if (cmdletContext.ParameterGroupName != null)
            {
                request.ParameterGroupName = cmdletContext.ParameterGroupName;
            }
            if (cmdletContext.TagKey != null)
            {
                request.TagKeys = cmdletContext.TagKey;
            }
            if (cmdletContext.TagValue != null)
            {
                request.TagValues = cmdletContext.TagValue;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextToken = cmdletContext.Marker;
            }
            if (cmdletContext.MaxRecord.HasValue)
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxRecord;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(100, _emitLimit.Value);
                    request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                else if (!ParameterWasBound(nameof(this.MaxRecord)))
                {
                    request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(100);
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
                    int _receivedThisCall = response.ParameterGroups?.Count ?? 0;
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.Redshift.Model.DescribeClusterParameterGroupsResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.DescribeClusterParameterGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "DescribeClusterParameterGroups");
            try
            {
                return client.DescribeClusterParameterGroupsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Marker { get; set; }
            public int? MaxRecord { get; set; }
            public System.String ParameterGroupName { get; set; }
            public List<System.String> TagKey { get; set; }
            public List<System.String> TagValue { get; set; }
            public System.Func<Amazon.Redshift.Model.DescribeClusterParameterGroupsResponse, GetRSClusterParameterGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ParameterGroups;
        }
        
    }
}
