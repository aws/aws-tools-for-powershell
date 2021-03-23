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
    /// Allows you to purchase a reserved cache node offering. Reserved nodes are not eligible
    /// for cancellation and are non-refundable. For more information, see <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/reserved-nodes.html">Managing
    /// Costs with Reserved Nodes</a> for Redis or <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/mem-ug/reserved-nodes.html">Managing
    /// Costs with Reserved Nodes</a> for Memcached.
    /// </summary>
    [Cmdlet("Request", "ECReservedCacheNodesOffering", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ReservedCacheNode")]
    [AWSCmdlet("Calls the Amazon ElastiCache PurchaseReservedCacheNodesOffering API operation.", Operation = new[] {"PurchaseReservedCacheNodesOffering"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.PurchaseReservedCacheNodesOfferingResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReservedCacheNode or Amazon.ElastiCache.Model.PurchaseReservedCacheNodesOfferingResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.ReservedCacheNode object.",
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
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.Int32? CacheNodeCount { get; set; }
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
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ReservedCacheNodesOfferingId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to be added to this resource. A tag is a key-value pair. A tag key
        /// must be accompanied by a tag value, although null is accepted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElastiCache.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReservedCacheNode'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.PurchaseReservedCacheNodesOfferingResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.PurchaseReservedCacheNodesOfferingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReservedCacheNode";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReservedCacheNodesOfferingId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReservedCacheNodesOfferingId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReservedCacheNodesOfferingId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReservedCacheNodesOfferingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-ECReservedCacheNodesOffering (PurchaseReservedCacheNodesOffering)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.PurchaseReservedCacheNodesOfferingResponse, RequestECReservedCacheNodesOfferingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReservedCacheNodesOfferingId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CacheNodeCount = this.CacheNodeCount;
            context.ReservedCacheNodeId = this.ReservedCacheNodeId;
            context.ReservedCacheNodesOfferingId = this.ReservedCacheNodesOfferingId;
            #if MODULAR
            if (this.ReservedCacheNodesOfferingId == null && ParameterWasBound(nameof(this.ReservedCacheNodesOfferingId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReservedCacheNodesOfferingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElastiCache.Model.Tag>(this.Tag);
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ElastiCache.Model.PurchaseReservedCacheNodesOfferingResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.PurchaseReservedCacheNodesOfferingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "PurchaseReservedCacheNodesOffering");
            try
            {
                #if DESKTOP
                return client.PurchaseReservedCacheNodesOffering(request);
                #elif CORECLR
                return client.PurchaseReservedCacheNodesOfferingAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? CacheNodeCount { get; set; }
            public System.String ReservedCacheNodeId { get; set; }
            public System.String ReservedCacheNodesOfferingId { get; set; }
            public List<Amazon.ElastiCache.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ElastiCache.Model.PurchaseReservedCacheNodesOfferingResponse, RequestECReservedCacheNodesOfferingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReservedCacheNode;
        }
        
    }
}
