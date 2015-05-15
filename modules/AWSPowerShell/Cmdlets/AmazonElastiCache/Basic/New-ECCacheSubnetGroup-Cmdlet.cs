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
    /// The <i>CreateCacheSubnetGroup</i> action creates a new cache subnet group.
    /// 
    ///  
    /// <para>
    /// Use this parameter only when you are creating a cluster in an Amazon Virtual Private
    /// Cloud (VPC).
    /// </para>
    /// </summary>
    [Cmdlet("New", "ECCacheSubnetGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.CacheSubnetGroup")]
    [AWSCmdlet("Invokes the CreateCacheSubnetGroup operation against Amazon ElastiCache.", Operation = new[] {"CreateCacheSubnetGroup"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.CacheSubnetGroup",
        "This cmdlet returns a CacheSubnetGroup object.",
        "The service call response (type CreateCacheSubnetGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewECCacheSubnetGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A description for the cache subnet group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String CacheSubnetGroupDescription { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A name for the cache subnet group. This value is stored as a lowercase string.</para><para>Constraints: Must contain no more than 255 alphanumeric characters or hyphens.</para><para>Example: <code>mysubnetgroup</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String CacheSubnetGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of VPC subnet IDs for the cache subnet group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CacheSubnetGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECCacheSubnetGroup (CreateCacheSubnetGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CacheSubnetGroupDescription = this.CacheSubnetGroupDescription;
            context.CacheSubnetGroupName = this.CacheSubnetGroupName;
            if (this.SubnetId != null)
            {
                context.SubnetIds = new List<String>(this.SubnetId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateCacheSubnetGroupRequest();
            
            if (cmdletContext.CacheSubnetGroupDescription != null)
            {
                request.CacheSubnetGroupDescription = cmdletContext.CacheSubnetGroupDescription;
            }
            if (cmdletContext.CacheSubnetGroupName != null)
            {
                request.CacheSubnetGroupName = cmdletContext.CacheSubnetGroupName;
            }
            if (cmdletContext.SubnetIds != null)
            {
                request.SubnetIds = cmdletContext.SubnetIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateCacheSubnetGroup(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CacheSubnetGroup;
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
            public String CacheSubnetGroupDescription { get; set; }
            public String CacheSubnetGroupName { get; set; }
            public List<String> SubnetIds { get; set; }
        }
        
    }
}
