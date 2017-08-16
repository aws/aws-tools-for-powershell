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
    /// Reboots some, or all, of the cache nodes within a provisioned cache cluster. This
    /// operation applies any modified cache parameter groups to the cache cluster. The reboot
    /// operation takes place as soon as possible, and results in a momentary outage to the
    /// cache cluster. During the reboot, the cache cluster status is set to REBOOTING.
    /// 
    ///  
    /// <para>
    /// The reboot causes the contents of the cache (for each cache node being rebooted) to
    /// be lost.
    /// </para><para>
    /// When the reboot is complete, a cache cluster event is created.
    /// </para>
    /// </summary>
    [Cmdlet("Restart", "ECCacheCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.CacheCluster")]
    [AWSCmdlet("Invokes the RebootCacheCluster operation against Amazon ElastiCache.", Operation = new[] {"RebootCacheCluster"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.CacheCluster",
        "This cmdlet returns a CacheCluster object.",
        "The service call response (type Amazon.ElastiCache.Model.RebootCacheClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RestartECCacheClusterCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter CacheClusterId
        /// <summary>
        /// <para>
        /// <para>The cache cluster identifier. This parameter is stored as a lowercase string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CacheClusterId { get; set; }
        #endregion
        
        #region Parameter CacheNodeIdsToReboot
        /// <summary>
        /// <para>
        /// <para>A list of cache node IDs to reboot. A node ID is a numeric identifier (0001, 0002,
        /// etc.). To reboot an entire cache cluster, specify all of the cache node IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String[] CacheNodeIdsToReboot { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CacheClusterId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restart-ECCacheCluster (RebootCacheCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CacheClusterId = this.CacheClusterId;
            if (this.CacheNodeIdsToReboot != null)
            {
                context.CacheNodeIdsToReboot = new List<System.String>(this.CacheNodeIdsToReboot);
            }
            
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
            var request = new Amazon.ElastiCache.Model.RebootCacheClusterRequest();
            
            if (cmdletContext.CacheClusterId != null)
            {
                request.CacheClusterId = cmdletContext.CacheClusterId;
            }
            if (cmdletContext.CacheNodeIdsToReboot != null)
            {
                request.CacheNodeIdsToReboot = cmdletContext.CacheNodeIdsToReboot;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.ElastiCache.Model.RebootCacheClusterResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.RebootCacheClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "RebootCacheCluster");
            try
            {
                #if DESKTOP
                return client.RebootCacheCluster(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RebootCacheClusterAsync(request);
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
            public System.String CacheClusterId { get; set; }
            public List<System.String> CacheNodeIdsToReboot { get; set; }
        }
        
    }
}
