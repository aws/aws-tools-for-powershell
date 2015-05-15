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
    /// The <i>DeleteCacheCluster</i> action deletes a previously provisioned cache cluster.
    /// <i>DeleteCacheCluster</i> deletes all associated cache nodes, node endpoints and the
    /// cache cluster itself. When you receive a successful response from this action, Amazon
    /// ElastiCache immediately begins deleting the cache cluster; you cannot cancel or revert
    /// this action.
    /// 
    ///  
    /// <para>
    /// This API cannot be used to delete a cache cluster that is the last read replica of
    /// a replication group that has Multi-AZ mode enabled.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "ECCacheCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ElastiCache.Model.CacheCluster")]
    [AWSCmdlet("Invokes the DeleteCacheCluster operation against Amazon ElastiCache.", Operation = new[] {"DeleteCacheCluster"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.CacheCluster",
        "This cmdlet returns a CacheCluster object.",
        "The service call response (type DeleteCacheClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RemoveECCacheClusterCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The cache cluster identifier for the cluster to be deleted. This parameter is not
        /// case sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String CacheClusterId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The user-supplied name of a final cache cluster snapshot. This is the unique name
        /// that identifies the snapshot. ElastiCache creates the snapshot, and then deletes the
        /// cache cluster immediately afterward.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String FinalSnapshotIdentifier { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CacheClusterId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-ECCacheCluster (DeleteCacheCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CacheClusterId = this.CacheClusterId;
            context.FinalSnapshotIdentifier = this.FinalSnapshotIdentifier;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DeleteCacheClusterRequest();
            
            if (cmdletContext.CacheClusterId != null)
            {
                request.CacheClusterId = cmdletContext.CacheClusterId;
            }
            if (cmdletContext.FinalSnapshotIdentifier != null)
            {
                request.FinalSnapshotIdentifier = cmdletContext.FinalSnapshotIdentifier;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DeleteCacheCluster(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CacheCluster;
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
            public String CacheClusterId { get; set; }
            public String FinalSnapshotIdentifier { get; set; }
        }
        
    }
}
