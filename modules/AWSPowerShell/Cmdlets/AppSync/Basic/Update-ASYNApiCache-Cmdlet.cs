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
using Amazon.AppSync;
using Amazon.AppSync.Model;

namespace Amazon.PowerShell.Cmdlets.ASYN
{
    /// <summary>
    /// Updates the cache for the GraphQL API.
    /// </summary>
    [Cmdlet("Update", "ASYNApiCache", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppSync.Model.ApiCache")]
    [AWSCmdlet("Calls the AWS AppSync UpdateApiCache API operation.", Operation = new[] {"UpdateApiCache"}, SelectReturnType = typeof(Amazon.AppSync.Model.UpdateApiCacheResponse))]
    [AWSCmdletOutput("Amazon.AppSync.Model.ApiCache or Amazon.AppSync.Model.UpdateApiCacheResponse",
        "This cmdlet returns an Amazon.AppSync.Model.ApiCache object.",
        "The service call response (type Amazon.AppSync.Model.UpdateApiCacheResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateASYNApiCacheCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApiCachingBehavior
        /// <summary>
        /// <para>
        /// <para>Caching behavior.</para><ul><li><para><b>FULL_REQUEST_CACHING</b>: All requests are fully cached.</para></li><li><para><b>PER_RESOLVER_CACHING</b>: Individual resolvers that you specify are cached.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AppSync.ApiCachingBehavior")]
        public Amazon.AppSync.ApiCachingBehavior ApiCachingBehavior { get; set; }
        #endregion
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The GraphQL API ID.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter HealthMetricsConfig
        /// <summary>
        /// <para>
        /// <para>Controls how cache health metrics will be emitted to CloudWatch. Cache health metrics
        /// include:</para><ul><li><para>NetworkBandwidthOutAllowanceExceeded: The network packets dropped because the throughput
        /// exceeded the aggregated bandwidth limit. This is useful for diagnosing bottlenecks
        /// in a cache configuration.</para></li><li><para>EngineCPUUtilization: The CPU utilization (percentage) allocated to the Redis process.
        /// This is useful for diagnosing bottlenecks in a cache configuration.</para></li></ul><para>Metrics will be recorded by API ID. You can set the value to <c>ENABLED</c> or <c>DISABLED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppSync.CacheHealthMetricsConfig")]
        public Amazon.AppSync.CacheHealthMetricsConfig HealthMetricsConfig { get; set; }
        #endregion
        
        #region Parameter Ttl
        /// <summary>
        /// <para>
        /// <para>TTL in seconds for cache entries.</para><para>Valid values are 1–3,600 seconds.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? Ttl { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The cache instance type. Valid values are </para><ul><li><para><c>SMALL</c></para></li><li><para><c>MEDIUM</c></para></li><li><para><c>LARGE</c></para></li><li><para><c>XLARGE</c></para></li><li><para><c>LARGE_2X</c></para></li><li><para><c>LARGE_4X</c></para></li><li><para><c>LARGE_8X</c> (not available in all regions)</para></li><li><para><c>LARGE_12X</c></para></li></ul><para>Historically, instance types were identified by an EC2-style value. As of July 2020,
        /// this is deprecated, and the generic identifiers above should be used.</para><para>The following legacy instance types are available, but their use is discouraged:</para><ul><li><para><b>T2_SMALL</b>: A t2.small instance type.</para></li><li><para><b>T2_MEDIUM</b>: A t2.medium instance type.</para></li><li><para><b>R4_LARGE</b>: A r4.large instance type.</para></li><li><para><b>R4_XLARGE</b>: A r4.xlarge instance type.</para></li><li><para><b>R4_2XLARGE</b>: A r4.2xlarge instance type.</para></li><li><para><b>R4_4XLARGE</b>: A r4.4xlarge instance type.</para></li><li><para><b>R4_8XLARGE</b>: A r4.8xlarge instance type.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AppSync.ApiCacheType")]
        public Amazon.AppSync.ApiCacheType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApiCache'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppSync.Model.UpdateApiCacheResponse).
        /// Specifying the name of a property of type Amazon.AppSync.Model.UpdateApiCacheResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApiCache";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApiId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ASYNApiCache (UpdateApiCache)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppSync.Model.UpdateApiCacheResponse, UpdateASYNApiCacheCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiCachingBehavior = this.ApiCachingBehavior;
            #if MODULAR
            if (this.ApiCachingBehavior == null && ParameterWasBound(nameof(this.ApiCachingBehavior)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiCachingBehavior which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApiId = this.ApiId;
            #if MODULAR
            if (this.ApiId == null && ParameterWasBound(nameof(this.ApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HealthMetricsConfig = this.HealthMetricsConfig;
            context.Ttl = this.Ttl;
            #if MODULAR
            if (this.Ttl == null && ParameterWasBound(nameof(this.Ttl)))
            {
                WriteWarning("You are passing $null as a value for parameter Ttl which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.AppSync.Model.UpdateApiCacheRequest();
            
            if (cmdletContext.ApiCachingBehavior != null)
            {
                request.ApiCachingBehavior = cmdletContext.ApiCachingBehavior;
            }
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            if (cmdletContext.HealthMetricsConfig != null)
            {
                request.HealthMetricsConfig = cmdletContext.HealthMetricsConfig;
            }
            if (cmdletContext.Ttl != null)
            {
                request.Ttl = cmdletContext.Ttl.Value;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.AppSync.Model.UpdateApiCacheResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.UpdateApiCacheRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "UpdateApiCache");
            try
            {
                return client.UpdateApiCacheAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.AppSync.ApiCachingBehavior ApiCachingBehavior { get; set; }
            public System.String ApiId { get; set; }
            public Amazon.AppSync.CacheHealthMetricsConfig HealthMetricsConfig { get; set; }
            public System.Int64? Ttl { get; set; }
            public Amazon.AppSync.ApiCacheType Type { get; set; }
            public System.Func<Amazon.AppSync.Model.UpdateApiCacheResponse, UpdateASYNApiCacheCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApiCache;
        }
        
    }
}
