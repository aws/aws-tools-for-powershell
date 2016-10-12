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
    /// Allows you to purchase a reserved cache node offering.
    /// </summary>
    [Cmdlet("Request", "ECReservedCacheNodesOffering", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ReservedCacheNode")]
    [AWSCmdlet("Invokes the PurchaseReservedCacheNodesOffering operation against Amazon ElastiCache.", Operation = new[] {"PurchaseReservedCacheNodesOffering"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReservedCacheNode",
        "This cmdlet returns a ReservedCacheNode object.",
        "The service call response (type Amazon.ElastiCache.Model.PurchaseReservedCacheNodesOfferingResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RequestECReservedCacheNodesOfferingCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter CacheNodeCount
        /// <summary>
        /// <para>
        /// <para>The number of cache node instances to reserve.</para><para>Default: <code>1</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.Int32 CacheNodeCount { get; set; }
        #endregion
        
        #region Parameter ReservedCacheNodeId
        /// <summary>
        /// <para>
        /// <para>A customer-specified identifier to track this reservation.</para><note><para>The Reserved Cache Node ID is an unique customer-specified identifier to track this
        /// reservation. If this parameter is not specified, ElastiCache automatically generates
        /// an identifier for the reservation.</para></note><para>Example: myreservationID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String ReservedCacheNodeId { get; set; }
        #endregion
        
        #region Parameter ReservedCacheNodesOfferingId
        /// <summary>
        /// <para>
        /// <para>The ID of the reserved cache node offering to purchase.</para><para>Example: <code>438012d3-4052-4cc7-b2e3-8d3372e0e706</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReservedCacheNodesOfferingId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ReservedCacheNodesOfferingId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-ECReservedCacheNodesOffering (PurchaseReservedCacheNodesOffering)"))
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
            
            if (ParameterWasBound("CacheNodeCount"))
                context.CacheNodeCount = this.CacheNodeCount;
            context.ReservedCacheNodeId = this.ReservedCacheNodeId;
            context.ReservedCacheNodesOfferingId = this.ReservedCacheNodesOfferingId;
            
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
            var request = new Amazon.ElastiCache.Model.PurchaseReservedCacheNodesOfferingRequest();
            
            if (cmdletContext.CacheNodeCount != null)
            {
                request.CacheNodeCount = cmdletContext.CacheNodeCount.Value;
            }
            if (cmdletContext.ReservedCacheNodeId != null)
            {
                request.ReservedCacheNodeId = cmdletContext.ReservedCacheNodeId;
            }
            if (cmdletContext.ReservedCacheNodesOfferingId != null)
            {
                request.ReservedCacheNodesOfferingId = cmdletContext.ReservedCacheNodesOfferingId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ReservedCacheNode;
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
        
        private static Amazon.ElastiCache.Model.PurchaseReservedCacheNodesOfferingResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.PurchaseReservedCacheNodesOfferingRequest request)
        {
            #if DESKTOP
            return client.PurchaseReservedCacheNodesOffering(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PurchaseReservedCacheNodesOfferingAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Int32? CacheNodeCount { get; set; }
            public System.String ReservedCacheNodeId { get; set; }
            public System.String ReservedCacheNodesOfferingId { get; set; }
        }
        
    }
}
