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
    /// Lists all cost allocation tags currently on the named resource. A <code>cost allocation
    /// tag</code> is a key-value pair where the key is case-sensitive and the value is optional.
    /// You can use cost allocation tags to categorize and track your AWS costs.
    /// 
    ///  
    /// <para>
    /// You can have a maximum of 10 cost allocation tags on an ElastiCache resource. For
    /// more information, see <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/UserGuide/BestPractices.html">Using
    /// Cost Allocation Tags in Amazon ElastiCache</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ECTag")]
    [OutputType("Amazon.ElastiCache.Model.Tag")]
    [AWSCmdlet("Invokes the ListTagsForResource operation against Amazon ElastiCache.", Operation = new[] {"ListTagsForResource"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.Tag",
        "This cmdlet returns a collection of Tag objects.",
        "The service call response (type Amazon.ElastiCache.Model.ListTagsForResourceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetECTagCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceName
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resource for which you want the list of tags,
        /// for example <code>arn:aws:elasticache:us-west-2:0123456789:cluster:myCluster</code>
        /// or <code>arn:aws:elasticache:us-west-2:0123456789:snapshot:mySnapshot</code>.</para><para>For more information about ARNs, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ResourceName { get; set; }
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
            
            context.ResourceName = this.ResourceName;
            
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
            var request = new Amazon.ElastiCache.Model.ListTagsForResourceRequest();
            
            if (cmdletContext.ResourceName != null)
            {
                request.ResourceName = cmdletContext.ResourceName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TagList;
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
        
        private static Amazon.ElastiCache.Model.ListTagsForResourceResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.ListTagsForResourceRequest request)
        {
            #if DESKTOP
            return client.ListTagsForResource(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ListTagsForResourceAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ResourceName { get; set; }
        }
        
    }
}
