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
    /// The <i>ListTagsForResource</i> action lists all cost allocation tags currently on
    /// the named resource. A <i>cost allocation tag</i> is a key-value pair where the key
    /// is case-sensitive and the value is optional. Cost allocation tags can be used to categorize
    /// and track your AWS costs.
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
    public class GetECTagCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceName
        /// <summary>
        /// <para>
        /// <para>The name of the resource for which you want the list of tags, for example <code>arn:aws:elasticache:us-west-2:0123456789:cluster:myCluster</code>.</para>
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
            
            context.ResourceName = this.ResourceName;
            
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
                var response = client.ListTagsForResource(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ResourceName { get; set; }
        }
        
    }
}
