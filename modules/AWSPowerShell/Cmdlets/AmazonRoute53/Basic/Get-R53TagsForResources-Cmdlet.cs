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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    
    /// </summary>
    [Cmdlet("Get", "R53TagsForResources")]
    [OutputType("Amazon.Route53.Model.ResourceTagSet")]
    [AWSCmdlet("Invokes the ListTagsForResources operation against AWS Route 53.", Operation = new[] {"ListTagsForResources"})]
    [AWSCmdletOutput("Amazon.Route53.Model.ResourceTagSet",
        "This cmdlet returns a collection of ResourceTagSet objects.",
        "The service call response (type ListTagsForResourcesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetR53TagsForResourcesCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A complex type that contains the ResourceId element for each resource for which you
        /// want to get a list of tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceIds")]
        public System.String[] ResourceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The type of the resources.</para><para>- The resource type for health checks is <code>healthcheck</code>.</para><para>- The resource type for hosted zones is <code>hostedzone</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public TagResourceType ResourceType { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ResourceType = this.ResourceType;
            if (this.ResourceId != null)
            {
                context.ResourceIds = new List<String>(this.ResourceId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ListTagsForResourcesRequest();
            
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            if (cmdletContext.ResourceIds != null)
            {
                request.ResourceIds = cmdletContext.ResourceIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListTagsForResources(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ResourceTagSets;
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
            public TagResourceType ResourceType { get; set; }
            public List<String> ResourceIds { get; set; }
        }
        
    }
}
