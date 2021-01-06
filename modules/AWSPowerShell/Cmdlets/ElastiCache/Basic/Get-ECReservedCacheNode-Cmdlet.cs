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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Returns information about reserved cache nodes for this account, or about a specified
    /// reserved cache node.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "ECReservedCacheNode")]
    [OutputType("Amazon.ElastiCache.Model.ReservedCacheNode")]
    [AWSCmdlet("Calls the Amazon ElastiCache DescribeReservedCacheNodes API operation.", Operation = new[] {"DescribeReservedCacheNodes"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.DescribeReservedCacheNodesResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReservedCacheNode or Amazon.ElastiCache.Model.DescribeReservedCacheNodesResponse",
        "This cmdlet returns a collection of Amazon.ElastiCache.Model.ReservedCacheNode objects.",
        "The service call response (type Amazon.ElastiCache.Model.DescribeReservedCacheNodesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetECReservedCacheNodeCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter CacheNodeType
        /// <summary>
        /// <para>
        /// <para>The cache node type filter value. Use this parameter to show only those reservations
        /// matching the specified cache node type.</para><para>The following node types are supported by ElastiCache. Generally speaking, the current
        /// generation types provide more memory and computational power at lower cost when compared
        /// to their equivalent previous generation counterparts.</para><ul><li><para>General purpose:</para><ul><li><para>Current generation: </para><para><b>M6g node types</b> (available only for Redis engine version 5.0.6 onward and for
        /// Memcached engine version 1.5.16 onward).</para><para><code>cache.m6g.large</code>, <code>cache.m6g.xlarge</code>, <code>cache.m6g.2xlarge</code>,
        /// <code>cache.m6g.4xlarge</code>, <code>cache.m6g.8xlarge</code>, <code>cache.m6g.12xlarge</code>,
        /// <code>cache.m6g.16xlarge</code></para><note><para>For region availability, see <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/CacheNodes.SupportedTypes.html#CacheNodes.SupportedTypesByRegion">Supported
        /// Node Types</a></para></note><para><b>M5 node types:</b><code>cache.m5.large</code>, <code>cache.m5.xlarge</code>,
        /// <code>cache.m5.2xlarge</code>, <code>cache.m5.4xlarge</code>, <code>cache.m5.12xlarge</code>,
        /// <code>cache.m5.24xlarge</code></para><para><b>M4 node types:</b><code>cache.m4.large</code>, <code>cache.m4.xlarge</code>,
        /// <code>cache.m4.2xlarge</code>, <code>cache.m4.4xlarge</code>, <code>cache.m4.10xlarge</code></para><para><b>T3 node types:</b><code>cache.t3.micro</code>, <code>cache.t3.small</code>, <code>cache.t3.medium</code></para><para><b>T2 node types:</b><code>cache.t2.micro</code>, <code>cache.t2.small</code>, <code>cache.t2.medium</code></para></li><li><para>Previous generation: (not recommended)</para><para><b>T1 node types:</b><code>cache.t1.micro</code></para><para><b>M1 node types:</b><code>cache.m1.small</code>, <code>cache.m1.medium</code>,
        /// <code>cache.m1.large</code>, <code>cache.m1.xlarge</code></para><para><b>M3 node types:</b><code>cache.m3.medium</code>, <code>cache.m3.large</code>,
        /// <code>cache.m3.xlarge</code>, <code>cache.m3.2xlarge</code></para></li></ul></li><li><para>Compute optimized:</para><ul><li><para>Previous generation: (not recommended)</para><para><b>C1 node types:</b><code>cache.c1.xlarge</code></para></li></ul></li><li><para>Memory optimized:</para><ul><li><para>Current generation: </para><para><b>R6g node types</b> (available only for Redis engine version 5.0.6 onward and for
        /// Memcached engine version 1.5.16 onward).</para><para><code>cache.r6g.large</code>, <code>cache.r6g.xlarge</code>, <code>cache.r6g.2xlarge</code>,
        /// <code>cache.r6g.4xlarge</code>, <code>cache.r6g.8xlarge</code>, <code>cache.r6g.12xlarge</code>,
        /// <code>cache.r6g.16xlarge</code></para><note><para>For region availability, see <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/CacheNodes.SupportedTypes.html#CacheNodes.SupportedTypesByRegion">Supported
        /// Node Types</a></para></note><para><b>R5 node types:</b><code>cache.r5.large</code>, <code>cache.r5.xlarge</code>,
        /// <code>cache.r5.2xlarge</code>, <code>cache.r5.4xlarge</code>, <code>cache.r5.12xlarge</code>,
        /// <code>cache.r5.24xlarge</code></para><para><b>R4 node types:</b><code>cache.r4.large</code>, <code>cache.r4.xlarge</code>,
        /// <code>cache.r4.2xlarge</code>, <code>cache.r4.4xlarge</code>, <code>cache.r4.8xlarge</code>,
        /// <code>cache.r4.16xlarge</code></para></li><li><para>Previous generation: (not recommended)</para><para><b>M2 node types:</b><code>cache.m2.xlarge</code>, <code>cache.m2.2xlarge</code>,
        /// <code>cache.m2.4xlarge</code></para><para><b>R3 node types:</b><code>cache.r3.large</code>, <code>cache.r3.xlarge</code>,
        /// <code>cache.r3.2xlarge</code>, <code>cache.r3.4xlarge</code>, <code>cache.r3.8xlarge</code></para></li></ul></li></ul><para><b>Additional node type info</b></para><ul><li><para>All current generation instance types are created in Amazon VPC by default.</para></li><li><para>Redis append-only files (AOF) are not supported for T1 or T2 instances.</para></li><li><para>Redis Multi-AZ with automatic failover is not supported on T1 instances.</para></li><li><para>Redis configuration variables <code>appendonly</code> and <code>appendfsync</code>
        /// are not supported on Redis version 2.8.22 and later.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String CacheNodeType { get; set; }
        #endregion
        
        #region Parameter Duration
        /// <summary>
        /// <para>
        /// <para>The duration filter value, specified in years or seconds. Use this parameter to show
        /// only reservations for this duration.</para><para>Valid Values: <code>1 | 3 | 31536000 | 94608000</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Duration { get; set; }
        #endregion
        
        #region Parameter OfferingType
        /// <summary>
        /// <para>
        /// <para>The offering type filter value. Use this parameter to show only the available offerings
        /// matching the specified offering type.</para><para>Valid values: <code>"Light Utilization"|"Medium Utilization"|"Heavy Utilization"|"All
        /// Upfront"|"Partial Upfront"| "No Upfront"</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OfferingType { get; set; }
        #endregion
        
        #region Parameter ProductDescription
        /// <summary>
        /// <para>
        /// <para>The product description filter value. Use this parameter to show only those reservations
        /// matching the specified product description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// <br/>In order to manually control output pagination, use '-Marker $null' for the first call and '-Marker $AWSHistory.LastServiceResponse.Marker' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReservedCacheNodes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.DescribeReservedCacheNodesResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.DescribeReservedCacheNodesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReservedCacheNodes";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReservedCacheNodeId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReservedCacheNodeId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReservedCacheNodeId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.DescribeReservedCacheNodesResponse, GetECReservedCacheNodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReservedCacheNodeId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CacheNodeType = this.CacheNodeType;
            context.Duration = this.Duration;
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
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxRecord.Value);
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
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
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
                    int _receivedThisCall = response.ReservedCacheNodes.Count;
                    
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
            public int? MaxRecord { get; set; }
            public System.String OfferingType { get; set; }
            public System.String ProductDescription { get; set; }
            public System.String ReservedCacheNodeId { get; set; }
            public System.String ReservedCacheNodesOfferingId { get; set; }
            public System.Func<Amazon.ElastiCache.Model.DescribeReservedCacheNodesResponse, GetECReservedCacheNodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReservedCacheNodes;
        }
        
    }
}
