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
    /// Returns information about a specific serverless cache. If no identifier is specified,
    /// then the API returns information on all the serverless caches belonging to this Amazon
    /// Web Services account.
    /// </summary>
    [Cmdlet("Get", "ECServerlessCache")]
    [OutputType("Amazon.ElastiCache.Model.ServerlessCache")]
    [AWSCmdlet("Calls the Amazon ElastiCache DescribeServerlessCaches API operation.", Operation = new[] {"DescribeServerlessCaches"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.DescribeServerlessCachesResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ServerlessCache or Amazon.ElastiCache.Model.DescribeServerlessCachesResponse",
        "This cmdlet returns a collection of Amazon.ElastiCache.Model.ServerlessCache objects.",
        "The service call response (type Amazon.ElastiCache.Model.DescribeServerlessCachesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetECServerlessCacheCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ServerlessCacheName
        /// <summary>
        /// <para>
        /// <para>The identifier for the serverless cache. If this parameter is specified, only information
        /// about that specific serverless cache is returned. Default: NULL</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ServerlessCacheName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of records in the response. If more records exist than the specified
        /// max-records value, the next token is included in the response so that remaining results
        /// can be retrieved. The default is 50.</para>
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
        /// beyond the marker, up to the value specified by MaxResults.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServerlessCaches'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.DescribeServerlessCachesResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.DescribeServerlessCachesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServerlessCaches";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServerlessCacheName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServerlessCacheName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServerlessCacheName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.DescribeServerlessCachesResponse, GetECServerlessCacheCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServerlessCacheName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ServerlessCacheName = this.ServerlessCacheName;
            
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
            var request = new Amazon.ElastiCache.Model.DescribeServerlessCachesRequest();
            
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
        
        private Amazon.ElastiCache.Model.DescribeServerlessCachesResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.DescribeServerlessCachesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "DescribeServerlessCaches");
            try
            {
                #if DESKTOP
                return client.DescribeServerlessCaches(request);
                #elif CORECLR
                return client.DescribeServerlessCachesAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ElastiCache.Model.DescribeServerlessCachesResponse, GetECServerlessCacheCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServerlessCaches;
        }
        
    }
}
