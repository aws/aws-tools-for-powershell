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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Returns information about reserved cache nodes for this account, or about a specified
    /// reserved cache node.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "ECReservedCacheNode")]
    [OutputType("Amazon.ElastiCache.Model.ReservedCacheNode")]
    [AWSCmdlet("Calls the Amazon ElastiCache DescribeReservedCacheNodes API operation.", Operation = new[] {"DescribeReservedCacheNodes"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReservedCacheNode",
        "This cmdlet returns a collection of ReservedCacheNode objects.",
        "The service call response (type Amazon.ElastiCache.Model.DescribeReservedCacheNodesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type System.String)"
    )]
    public partial class GetECReservedCacheNodeCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter CacheNodeType
        /// <summary>
        /// <para>
        /// <para>The cache node type filter value. Use this parameter to show only those reservations
        /// matching the specified cache node type.</para><para>The following node types are supported by ElastiCache. Generally speaking, the current
        /// generation types provide more memory and computational power at lower cost when compared
        /// to their equivalent previous generation counterparts.</para><ul><li><para>General purpose:</para><ul><li><para>Current generation: </para><para><b>T2 node types:</b><code>cache.t2.micro</code>, <code>cache.t2.small</code>, <code>cache.t2.medium</code></para><para><b>M3 node types:</b><code>cache.m3.medium</code>, <code>cache.m3.large</code>,
        /// <code>cache.m3.xlarge</code>, <code>cache.m3.2xlarge</code></para><para><b>M4 node types:</b><code>cache.m4.large</code>, <code>cache.m4.xlarge</code>,
        /// <code>cache.m4.2xlarge</code>, <code>cache.m4.4xlarge</code>, <code>cache.m4.10xlarge</code></para></li><li><para>Previous generation: (not recommended)</para><para><b>T1 node types:</b><code>cache.t1.micro</code></para><para><b>M1 node types:</b><code>cache.m1.small</code>, <code>cache.m1.medium</code>,
        /// <code>cache.m1.large</code>, <code>cache.m1.xlarge</code></para></li></ul></li><li><para>Compute optimized:</para><ul><li><para>Previous generation: (not recommended)</para><para><b>C1 node types:</b><code>cache.c1.xlarge</code></para></li></ul></li><li><para>Memory optimized:</para><ul><li><para>Current generation: </para><para><b>R3 node types:</b><code>cache.r3.large</code>, <code>cache.r3.xlarge</code>,
        /// <code>cache.r3.2xlarge</code>, <code>cache.r3.4xlarge</code>, <code>cache.r3.8xlarge</code></para><para><b>R4 node types;</b><code>cache.r4.large</code>, <code>cache.r4.xlarge</code>,
        /// <code>cache.r4.2xlarge</code>, <code>cache.r4.4xlarge</code>, <code>cache.r4.8xlarge</code>,
        /// <code>cache.r4.16xlarge</code></para></li><li><para>Previous generation: (not recommended)</para><para><b>M2 node types:</b><code>cache.m2.xlarge</code>, <code>cache.m2.2xlarge</code>,
        /// <code>cache.m2.4xlarge</code></para></li></ul></li></ul><para><b>Notes:</b></para><ul><li><para>All T2 instances are created in an Amazon Virtual Private Cloud (Amazon VPC).</para></li><li><para>Redis (cluster mode disabled): Redis backup/restore is not supported on T1 and T2
        /// instances. </para></li><li><para>Redis (cluster mode enabled): Backup/restore is not supported on T1 instances.</para></li><li><para>Redis Append-only files (AOF) functionality is not supported for T1 or T2 instances.</para></li></ul><para>For a complete listing of node types and specifications, see:</para><ul><li><para><a href="http://aws.amazon.com/elasticache/details">Amazon ElastiCache Product Features
        /// and Details</a></para></li><li><para><a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/mem-ug/ParameterGroups.Memcached.html#ParameterGroups.Memcached.NodeSpecific">Cache
        /// Node Type-Specific Parameters for Memcached</a></para></li><li><para><a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/ParameterGroups.Redis.html#ParameterGroups.Redis.NodeSpecific">Cache
        /// Node Type-Specific Parameters for Redis</a></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String CacheNodeType { get; set; }
        #endregion
        
        #region Parameter Duration
        /// <summary>
        /// <para>
        /// <para>The duration filter value, specified in years or seconds. Use this parameter to show
        /// only reservations for this duration.</para><para>Valid Values: <code>1 | 3 | 31536000 | 94608000</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Duration { get; set; }
        #endregion
        
        #region Parameter OfferingType
        /// <summary>
        /// <para>
        /// <para>The offering type filter value. Use this parameter to show only the available offerings
        /// matching the specified offering type.</para><para>Valid values: <code>"Light Utilization"|"Medium Utilization"|"Heavy Utilization"</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OfferingType { get; set; }
        #endregion
        
        #region Parameter ProductDescription
        /// <summary>
        /// <para>
        /// <para>The product description filter value. Use this parameter to show only those reservations
        /// matching the specified product description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProductDescription { get; set; }
        #endregion
        
        #region Parameter ReservedCacheNodeId
        /// <summary>
        /// <para>
        /// <para>The reserved cache node identifier filter value. Use this parameter to show only the
        /// reservation that matches the specified reservation ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReservedCacheNodeId { get; set; }
        #endregion
        
        #region Parameter ReservedCacheNodesOfferingId
        /// <summary>
        /// <para>
        /// <para>The offering identifier filter value. Use this parameter to show only purchased reservations
        /// matching the specified offering identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String ReservedCacheNodesOfferingId { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional marker returned from a prior request. Use this marker for pagination of
        /// results from this operation. If this parameter is specified, the response includes
        /// only records beyond the marker, up to the value specified by <code>MaxRecords</code>.</para>
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
        /// <para>The maximum number of records to include in the response. If more records exist than
        /// the specified <code>MaxRecords</code> value, a marker is included in the response
        /// so that the remaining results can be retrieved.</para><para>Default: 100</para><para>Constraints: minimum 20; maximum 100.</para>
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
            
            context.CacheNodeType = this.CacheNodeType;
            context.Duration = this.Duration;
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxRecord"))
                context.MaxRecords = this.MaxRecord;
            context.OfferingType = this.OfferingType;
            context.ProductDescription = this.ProductDescription;
            context.ReservedCacheNodeId = this.ReservedCacheNodeId;
            context.ReservedCacheNodesOfferingId = this.ReservedCacheNodesOfferingId;
            
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
            var request = new Amazon.ElastiCache.Model.DescribeReservedCacheNodesRequest();
            if (cmdletContext.CacheNodeType != null)
            {
                request.CacheNodeType = cmdletContext.CacheNodeType;
            }
            if (cmdletContext.Duration != null)
            {
                request.Duration = cmdletContext.Duration;
            }
            if (cmdletContext.OfferingType != null)
            {
                request.OfferingType = cmdletContext.OfferingType;
            }
            if (cmdletContext.ProductDescription != null)
            {
                request.ProductDescription = cmdletContext.ProductDescription;
            }
            if (cmdletContext.ReservedCacheNodeId != null)
            {
                request.ReservedCacheNodeId = cmdletContext.ReservedCacheNodeId;
            }
            if (cmdletContext.ReservedCacheNodesOfferingId != null)
            {
                request.ReservedCacheNodesOfferingId = cmdletContext.ReservedCacheNodesOfferingId;
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
            bool _userControllingPaging = ParameterWasBound("Marker");
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    if (_emitLimit.HasValue)
                    {
                        request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.ReservedCacheNodes;
                        notes = new Dictionary<string, object>();
                        notes["Marker"] = response.Marker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.ReservedCacheNodes.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.Marker;
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
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
                
            }
            finally
            {
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ElastiCache.Model.DescribeReservedCacheNodesResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.DescribeReservedCacheNodesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "DescribeReservedCacheNodes");
            try
            {
                #if DESKTOP
                return client.DescribeReservedCacheNodes(request);
                #elif CORECLR
                return client.DescribeReservedCacheNodesAsync(request).GetAwaiter().GetResult();
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
            public System.String CacheNodeType { get; set; }
            public System.String Duration { get; set; }
            public System.String Marker { get; set; }
            public int? MaxRecords { get; set; }
            public System.String OfferingType { get; set; }
            public System.String ProductDescription { get; set; }
            public System.String ReservedCacheNodeId { get; set; }
            public System.String ReservedCacheNodesOfferingId { get; set; }
        }
        
    }
}
