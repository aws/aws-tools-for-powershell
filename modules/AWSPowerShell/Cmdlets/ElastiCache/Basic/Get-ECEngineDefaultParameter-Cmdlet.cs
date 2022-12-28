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
    /// Returns the default engine and system parameter information for the specified cache
    /// engine.
    /// </summary>
    [Cmdlet("Get", "ECEngineDefaultParameter")]
    [OutputType("Amazon.ElastiCache.Model.EngineDefaults")]
    [AWSCmdlet("Calls the Amazon ElastiCache DescribeEngineDefaultParameters API operation.", Operation = new[] {"DescribeEngineDefaultParameters"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.DescribeEngineDefaultParametersResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.EngineDefaults or Amazon.ElastiCache.Model.DescribeEngineDefaultParametersResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.EngineDefaults object.",
        "The service call response (type Amazon.ElastiCache.Model.DescribeEngineDefaultParametersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetECEngineDefaultParameterCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter CacheParameterGroupFamily
        /// <summary>
        /// <para>
        /// <para>The name of the cache parameter group family.</para><para>Valid values are: <code>memcached1.4</code> | <code>memcached1.5</code> | <code>memcached1.6</code>
        /// | <code>redis2.6</code> | <code>redis2.8</code> | <code>redis3.2</code> | <code>redis4.0</code>
        /// | <code>redis5.0</code> | <code>redis6.x</code> | <code>redis6.2</code> | <code>redis7</code></para>
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
        public System.String CacheParameterGroupFamily { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional marker returned from a prior request. Use this marker for pagination of
        /// results from this operation. If this parameter is specified, the response includes
        /// only records beyond the marker, up to the value specified by <code>MaxRecords</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRecords")]
        public System.Int32? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EngineDefaults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.DescribeEngineDefaultParametersResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.DescribeEngineDefaultParametersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EngineDefaults";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CacheParameterGroupFamily parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CacheParameterGroupFamily' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CacheParameterGroupFamily' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.DescribeEngineDefaultParametersResponse, GetECEngineDefaultParameterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CacheParameterGroupFamily;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CacheParameterGroupFamily = this.CacheParameterGroupFamily;
            #if MODULAR
            if (this.CacheParameterGroupFamily == null && ParameterWasBound(nameof(this.CacheParameterGroupFamily)))
            {
                WriteWarning("You are passing $null as a value for parameter CacheParameterGroupFamily which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            
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
            var request = new Amazon.ElastiCache.Model.DescribeEngineDefaultParametersRequest();
            
            if (cmdletContext.CacheParameterGroupFamily != null)
            {
                request.CacheParameterGroupFamily = cmdletContext.CacheParameterGroupFamily;
            }
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = cmdletContext.MaxRecord.Value;
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
        
        private Amazon.ElastiCache.Model.DescribeEngineDefaultParametersResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.DescribeEngineDefaultParametersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "DescribeEngineDefaultParameters");
            try
            {
                #if DESKTOP
                return client.DescribeEngineDefaultParameters(request);
                #elif CORECLR
                return client.DescribeEngineDefaultParametersAsync(request).GetAwaiter().GetResult();
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
            public System.String CacheParameterGroupFamily { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxRecord { get; set; }
            public System.Func<Amazon.ElastiCache.Model.DescribeEngineDefaultParametersResponse, GetECEngineDefaultParameterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EngineDefaults;
        }
        
    }
}
