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
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;

namespace Amazon.PowerShell.Cmdlets.ES
{
    /// <summary>
    /// Describe Elasticsearch Limits for a given InstanceType and ElasticsearchVersion.
    /// When modifying existing Domain, specify the <code><a>DomainName</a></code> to know
    /// what Limits are supported for modifying.
    /// </summary>
    [Cmdlet("Get", "ESInstanceTypeLimit")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the DescribeElasticsearchInstanceTypeLimits operation against Amazon Elasticsearch.", Operation = new[] {"DescribeElasticsearchInstanceTypeLimits"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.Elasticsearch.Model.DescribeElasticsearchInstanceTypeLimitsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetESInstanceTypeLimitCmdlet : AmazonElasticsearchClientCmdlet, IExecutor
    {
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para> DomainName represents the name of the Domain that we are trying to modify. This should
        /// be present only if we are querying for Elasticsearch <code><a>Limits</a></code>
        /// for existing domain. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter ElasticsearchVersion
        /// <summary>
        /// <para>
        /// <para> Version of Elasticsearch for which <code><a>Limits</a></code> are needed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ElasticsearchVersion { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para> The instance type for an Elasticsearch cluster for which Elasticsearch <code><a>Limits</a></code> are needed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Elasticsearch.ESPartitionInstanceType")]
        public Amazon.Elasticsearch.ESPartitionInstanceType InstanceType { get; set; }
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
            
            context.DomainName = this.DomainName;
            context.ElasticsearchVersion = this.ElasticsearchVersion;
            context.InstanceType = this.InstanceType;
            
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
            var request = new Amazon.Elasticsearch.Model.DescribeElasticsearchInstanceTypeLimitsRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.ElasticsearchVersion != null)
            {
                request.ElasticsearchVersion = cmdletContext.ElasticsearchVersion;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.LimitsByRole;
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
        
        #region AWS Service Operation Call
        
        private Amazon.Elasticsearch.Model.DescribeElasticsearchInstanceTypeLimitsResponse CallAWSServiceOperation(IAmazonElasticsearch client, Amazon.Elasticsearch.Model.DescribeElasticsearchInstanceTypeLimitsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elasticsearch", "DescribeElasticsearchInstanceTypeLimits");
            try
            {
                #if DESKTOP
                return client.DescribeElasticsearchInstanceTypeLimits(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeElasticsearchInstanceTypeLimitsAsync(request);
                return task.Result;
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
            public System.String DomainName { get; set; }
            public System.String ElasticsearchVersion { get; set; }
            public Amazon.Elasticsearch.ESPartitionInstanceType InstanceType { get; set; }
        }
        
    }
}
