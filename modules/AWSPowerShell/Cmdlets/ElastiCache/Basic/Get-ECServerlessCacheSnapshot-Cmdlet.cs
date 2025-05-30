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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Returns information about serverless cache snapshots. By default, this API lists all
    /// of the customer’s serverless cache snapshots. It can also describe a single serverless
    /// cache snapshot, or the snapshots associated with a particular serverless cache. Available
    /// for Valkey, Redis OSS and Serverless Memcached only.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "ECServerlessCacheSnapshot")]
    [OutputType("Amazon.ElastiCache.Model.ServerlessCacheSnapshot")]
    [AWSCmdlet("Calls the Amazon ElastiCache DescribeServerlessCacheSnapshots API operation.", Operation = new[] {"DescribeServerlessCacheSnapshots"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.DescribeServerlessCacheSnapshotsResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ServerlessCacheSnapshot or Amazon.ElastiCache.Model.DescribeServerlessCacheSnapshotsResponse",
        "This cmdlet returns a collection of Amazon.ElastiCache.Model.ServerlessCacheSnapshot objects.",
        "The service call response (type Amazon.ElastiCache.Model.DescribeServerlessCacheSnapshotsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetECServerlessCacheSnapshotCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ServerlessCacheName
        /// <summary>
        /// <para>
        /// <para>The identifier of serverless cache. If this parameter is specified, only snapshots
        /// associated with that specific serverless cache are described. Available for Valkey,
        /// Redis OSS and Serverless Memcached only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ServerlessCacheName { get; set; }
        #endregion
        
        #region Parameter ServerlessCacheSnapshotName
        /// <summary>
        /// <para>
        /// <para>The identifier of the serverless cache’s snapshot. If this parameter is specified,
        /// only this snapshot is described. Available for Valkey, Redis OSS and Serverless Memcached
        /// only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerlessCacheSnapshotName { get; set; }
        #endregion
        
        #region Parameter SnapshotType
        /// <summary>
        /// <para>
        /// <para>The type of snapshot that is being described. Available for Valkey, Redis OSS and
        /// Serverless Memcached only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in the response. If more records exist than
        /// the specified max-results value, a market is included in the response so that remaining
        /// results can be retrieved. Available for Valkey, Redis OSS and Serverless Memcached
        /// only.The default is 50. The Validation Constraints are a maximum of 50.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An optional marker returned from a prior request to support pagination of results
        /// from this operation. If this parameter is specified, the response includes only records
        /// beyond the marker, up to the value specified by max-results. Available for Valkey,
        /// Redis OSS and Serverless Memcached only.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServerlessCacheSnapshots'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.DescribeServerlessCacheSnapshotsResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.DescribeServerlessCacheSnapshotsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServerlessCacheSnapshots";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.DescribeServerlessCacheSnapshotsResponse, GetECServerlessCacheSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.ServerlessCacheName = this.ServerlessCacheName;
            context.ServerlessCacheSnapshotName = this.ServerlessCacheSnapshotName;
            context.SnapshotType = this.SnapshotType;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ElastiCache.Model.DescribeServerlessCacheSnapshotsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.ServerlessCacheName != null)
            {
                request.ServerlessCacheName = cmdletContext.ServerlessCacheName;
            }
            if (cmdletContext.ServerlessCacheSnapshotName != null)
            {
                request.ServerlessCacheSnapshotName = cmdletContext.ServerlessCacheSnapshotName;
            }
            if (cmdletContext.SnapshotType != null)
            {
                request.SnapshotType = cmdletContext.SnapshotType;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
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
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ElastiCache.Model.DescribeServerlessCacheSnapshotsResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.DescribeServerlessCacheSnapshotsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "DescribeServerlessCacheSnapshots");
            try
            {
                return client.DescribeServerlessCacheSnapshotsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ServerlessCacheName { get; set; }
            public System.String ServerlessCacheSnapshotName { get; set; }
            public System.String SnapshotType { get; set; }
            public System.Func<Amazon.ElastiCache.Model.DescribeServerlessCacheSnapshotsResponse, GetECServerlessCacheSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServerlessCacheSnapshots;
        }
        
    }
}
