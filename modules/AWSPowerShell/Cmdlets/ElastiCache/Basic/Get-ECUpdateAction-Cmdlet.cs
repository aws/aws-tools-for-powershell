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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Returns details of the update actions<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "ECUpdateAction")]
    [OutputType("Amazon.ElastiCache.Model.UpdateAction")]
    [AWSCmdlet("Calls the Amazon ElastiCache DescribeUpdateActions API operation.", Operation = new[] {"DescribeUpdateActions"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.DescribeUpdateActionsResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.UpdateAction or Amazon.ElastiCache.Model.DescribeUpdateActionsResponse",
        "This cmdlet returns a collection of Amazon.ElastiCache.Model.UpdateAction objects.",
        "The service call response (type Amazon.ElastiCache.Model.DescribeUpdateActionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetECUpdateActionCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CacheClusterId
        /// <summary>
        /// <para>
        /// <para>The cache cluster IDs</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheClusterIds")]
        public System.String[] CacheClusterId { get; set; }
        #endregion
        
        #region Parameter ServiceUpdateTimeRange_EndTime
        /// <summary>
        /// <para>
        /// <para>The end time of the time range filter</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ServiceUpdateTimeRange_EndTime { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The Elasticache engine to which the update applies. Either Valkey, Redis OSS or Memcached.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The replication group IDs</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplicationGroupIds")]
        public System.String[] ReplicationGroupId { get; set; }
        #endregion
        
        #region Parameter ServiceUpdateName
        /// <summary>
        /// <para>
        /// <para>The unique ID of the service update</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ServiceUpdateName { get; set; }
        #endregion
        
        #region Parameter ServiceUpdateStatus
        /// <summary>
        /// <para>
        /// <para>The status of the service update</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ServiceUpdateStatus { get; set; }
        #endregion
        
        #region Parameter ShowNodeLevelUpdateStatus
        /// <summary>
        /// <para>
        /// <para>Dictates whether to include node level update status in the response </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ShowNodeLevelUpdateStatus { get; set; }
        #endregion
        
        #region Parameter ServiceUpdateTimeRange_StartTime
        /// <summary>
        /// <para>
        /// <para>The start time of the time range filter</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ServiceUpdateTimeRange_StartTime { get; set; }
        #endregion
        
        #region Parameter UpdateActionStatus
        /// <summary>
        /// <para>
        /// <para>The status of the update action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] UpdateActionStatus { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional marker returned from a prior request. Use this marker for pagination of
        /// results from this operation. If this parameter is specified, the response includes
        /// only records beyond the marker, up to the value specified by <c>MaxRecords</c>.</para>
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
        /// <para>The maximum number of records to include in the response</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxRecords")]
        public int? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UpdateActions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.DescribeUpdateActionsResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.DescribeUpdateActionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UpdateActions";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.DescribeUpdateActionsResponse, GetECUpdateActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CacheClusterId != null)
            {
                context.CacheClusterId = new List<System.String>(this.CacheClusterId);
            }
            context.Engine = this.Engine;
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxRecord)) && this.MaxRecord.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxRecord parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxRecord" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            if (this.ReplicationGroupId != null)
            {
                context.ReplicationGroupId = new List<System.String>(this.ReplicationGroupId);
            }
            context.ServiceUpdateName = this.ServiceUpdateName;
            if (this.ServiceUpdateStatus != null)
            {
                context.ServiceUpdateStatus = new List<System.String>(this.ServiceUpdateStatus);
            }
            context.ServiceUpdateTimeRange_EndTime = this.ServiceUpdateTimeRange_EndTime;
            context.ServiceUpdateTimeRange_StartTime = this.ServiceUpdateTimeRange_StartTime;
            context.ShowNodeLevelUpdateStatus = this.ShowNodeLevelUpdateStatus;
            if (this.UpdateActionStatus != null)
            {
                context.UpdateActionStatus = new List<System.String>(this.UpdateActionStatus);
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
            var request = new Amazon.ElastiCache.Model.DescribeUpdateActionsRequest();
            
            if (cmdletContext.CacheClusterId != null)
            {
                request.CacheClusterIds = cmdletContext.CacheClusterId;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxRecord.Value);
            }
            if (cmdletContext.ReplicationGroupId != null)
            {
                request.ReplicationGroupIds = cmdletContext.ReplicationGroupId;
            }
            if (cmdletContext.ServiceUpdateName != null)
            {
                request.ServiceUpdateName = cmdletContext.ServiceUpdateName;
            }
            if (cmdletContext.ServiceUpdateStatus != null)
            {
                request.ServiceUpdateStatus = cmdletContext.ServiceUpdateStatus;
            }
            
             // populate ServiceUpdateTimeRange
            var requestServiceUpdateTimeRangeIsNull = true;
            request.ServiceUpdateTimeRange = new Amazon.ElastiCache.Model.TimeRangeFilter();
            System.DateTime? requestServiceUpdateTimeRange_serviceUpdateTimeRange_EndTime = null;
            if (cmdletContext.ServiceUpdateTimeRange_EndTime != null)
            {
                requestServiceUpdateTimeRange_serviceUpdateTimeRange_EndTime = cmdletContext.ServiceUpdateTimeRange_EndTime.Value;
            }
            if (requestServiceUpdateTimeRange_serviceUpdateTimeRange_EndTime != null)
            {
                request.ServiceUpdateTimeRange.EndTime = requestServiceUpdateTimeRange_serviceUpdateTimeRange_EndTime.Value;
                requestServiceUpdateTimeRangeIsNull = false;
            }
            System.DateTime? requestServiceUpdateTimeRange_serviceUpdateTimeRange_StartTime = null;
            if (cmdletContext.ServiceUpdateTimeRange_StartTime != null)
            {
                requestServiceUpdateTimeRange_serviceUpdateTimeRange_StartTime = cmdletContext.ServiceUpdateTimeRange_StartTime.Value;
            }
            if (requestServiceUpdateTimeRange_serviceUpdateTimeRange_StartTime != null)
            {
                request.ServiceUpdateTimeRange.StartTime = requestServiceUpdateTimeRange_serviceUpdateTimeRange_StartTime.Value;
                requestServiceUpdateTimeRangeIsNull = false;
            }
             // determine if request.ServiceUpdateTimeRange should be set to null
            if (requestServiceUpdateTimeRangeIsNull)
            {
                request.ServiceUpdateTimeRange = null;
            }
            if (cmdletContext.ShowNodeLevelUpdateStatus != null)
            {
                request.ShowNodeLevelUpdateStatus = cmdletContext.ShowNodeLevelUpdateStatus.Value;
            }
            if (cmdletContext.UpdateActionStatus != null)
            {
                request.UpdateActionStatus = cmdletContext.UpdateActionStatus;
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
            var request = new Amazon.ElastiCache.Model.DescribeUpdateActionsRequest();
            if (cmdletContext.CacheClusterId != null)
            {
                request.CacheClusterIds = cmdletContext.CacheClusterId;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.ReplicationGroupId != null)
            {
                request.ReplicationGroupIds = cmdletContext.ReplicationGroupId;
            }
            if (cmdletContext.ServiceUpdateName != null)
            {
                request.ServiceUpdateName = cmdletContext.ServiceUpdateName;
            }
            if (cmdletContext.ServiceUpdateStatus != null)
            {
                request.ServiceUpdateStatus = cmdletContext.ServiceUpdateStatus;
            }
            
             // populate ServiceUpdateTimeRange
            var requestServiceUpdateTimeRangeIsNull = true;
            request.ServiceUpdateTimeRange = new Amazon.ElastiCache.Model.TimeRangeFilter();
            System.DateTime? requestServiceUpdateTimeRange_serviceUpdateTimeRange_EndTime = null;
            if (cmdletContext.ServiceUpdateTimeRange_EndTime != null)
            {
                requestServiceUpdateTimeRange_serviceUpdateTimeRange_EndTime = cmdletContext.ServiceUpdateTimeRange_EndTime.Value;
            }
            if (requestServiceUpdateTimeRange_serviceUpdateTimeRange_EndTime != null)
            {
                request.ServiceUpdateTimeRange.EndTime = requestServiceUpdateTimeRange_serviceUpdateTimeRange_EndTime.Value;
                requestServiceUpdateTimeRangeIsNull = false;
            }
            System.DateTime? requestServiceUpdateTimeRange_serviceUpdateTimeRange_StartTime = null;
            if (cmdletContext.ServiceUpdateTimeRange_StartTime != null)
            {
                requestServiceUpdateTimeRange_serviceUpdateTimeRange_StartTime = cmdletContext.ServiceUpdateTimeRange_StartTime.Value;
            }
            if (requestServiceUpdateTimeRange_serviceUpdateTimeRange_StartTime != null)
            {
                request.ServiceUpdateTimeRange.StartTime = requestServiceUpdateTimeRange_serviceUpdateTimeRange_StartTime.Value;
                requestServiceUpdateTimeRangeIsNull = false;
            }
             // determine if request.ServiceUpdateTimeRange should be set to null
            if (requestServiceUpdateTimeRangeIsNull)
            {
                request.ServiceUpdateTimeRange = null;
            }
            if (cmdletContext.ShowNodeLevelUpdateStatus != null)
            {
                request.ShowNodeLevelUpdateStatus = cmdletContext.ShowNodeLevelUpdateStatus.Value;
            }
            if (cmdletContext.UpdateActionStatus != null)
            {
                request.UpdateActionStatus = cmdletContext.UpdateActionStatus;
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
                _emitLimit = cmdletContext.MaxRecord;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                if (_emitLimit.HasValue)
                {
                    request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
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
                    int _receivedThisCall = response.UpdateActions?.Count ?? 0;
                    
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
        
        private Amazon.ElastiCache.Model.DescribeUpdateActionsResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.DescribeUpdateActionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "DescribeUpdateActions");
            try
            {
                #if DESKTOP
                return client.DescribeUpdateActions(request);
                #elif CORECLR
                return client.DescribeUpdateActionsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CacheClusterId { get; set; }
            public System.String Engine { get; set; }
            public System.String Marker { get; set; }
            public int? MaxRecord { get; set; }
            public List<System.String> ReplicationGroupId { get; set; }
            public System.String ServiceUpdateName { get; set; }
            public List<System.String> ServiceUpdateStatus { get; set; }
            public System.DateTime? ServiceUpdateTimeRange_EndTime { get; set; }
            public System.DateTime? ServiceUpdateTimeRange_StartTime { get; set; }
            public System.Boolean? ShowNodeLevelUpdateStatus { get; set; }
            public List<System.String> UpdateActionStatus { get; set; }
            public System.Func<Amazon.ElastiCache.Model.DescribeUpdateActionsResponse, GetECUpdateActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UpdateActions;
        }
        
    }
}
