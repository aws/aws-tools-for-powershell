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
    /// Returns information about serverless cache snapshots. By default, this API lists all
    /// of the customer’s serverless cache snapshots. It can also describe a single serverless
    /// cache snapshot, or the snapshots associated with a particular serverless cache. Available
    /// for Valkey, Redis OSS and Serverless Memcached only.
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
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An optional marker returned from a prior request to support pagination of results
        /// from this operation. If this parameter is specified, the response includes only records
        /// beyond the marker, up to the value specified by max-results. Available for Valkey,
        /// Redis OSS and Serverless Memcached only.</para>
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
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
            // create request
            var request = new Amazon.ElastiCache.Model.DescribeServerlessCacheSnapshotsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
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
                #if DESKTOP
                return client.DescribeServerlessCacheSnapshots(request);
                #elif CORECLR
                return client.DescribeServerlessCacheSnapshotsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ServerlessCacheName { get; set; }
            public System.String ServerlessCacheSnapshotName { get; set; }
            public System.String SnapshotType { get; set; }
            public System.Func<Amazon.ElastiCache.Model.DescribeServerlessCacheSnapshotsResponse, GetECServerlessCacheSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServerlessCacheSnapshots;
        }
        
    }
}
