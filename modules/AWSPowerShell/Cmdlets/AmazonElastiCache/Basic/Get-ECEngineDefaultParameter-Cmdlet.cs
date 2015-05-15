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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// The <i>DescribeEngineDefaultParameters</i> action returns the default engine and system
    /// parameter information for the specified cache engine.
    /// </summary>
    [Cmdlet("Get", "ECEngineDefaultParameter")]
    [OutputType("Amazon.ElastiCache.Model.EngineDefaults")]
    [AWSCmdlet("Invokes the DescribeEngineDefaultParameters operation against Amazon ElastiCache.", Operation = new[] {"DescribeEngineDefaultParameters"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.EngineDefaults",
        "This cmdlet returns a EngineDefaults object.",
        "The service call response (type DescribeEngineDefaultParametersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetECEngineDefaultParameterCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of the cache parameter group family. Valid values are: <code>memcached1.4</code>
        /// | <code>redis2.6</code> | <code>redis2.8</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String CacheParameterGroupFamily { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An optional marker returned from a prior request. Use this marker for pagination of
        /// results from this action. If this parameter is specified, the response includes only
        /// records beyond the marker, up to the value specified by <i>MaxRecords</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public String Marker { get; set; }
        
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
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CacheParameterGroupFamily = this.CacheParameterGroupFamily;
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxRecord"))
                context.MaxRecords = this.MaxRecord;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeEngineDefaultParametersRequest();
            
            if (cmdletContext.CacheParameterGroupFamily != null)
            {
                request.CacheParameterGroupFamily = cmdletContext.CacheParameterGroupFamily;
            }
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxRecords != null)
            {
                request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxRecords.Value);
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeEngineDefaultParameters(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.EngineDefaults;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String CacheParameterGroupFamily { get; set; }
            public String Marker { get; set; }
            public int? MaxRecords { get; set; }
        }
        
    }
}
