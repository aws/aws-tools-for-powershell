/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.OpenSearchMemory;
using Amazon.OpenSearchMemory.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OSM
{
    /// <summary>
    /// Updates a memory in place. Supply only the fields to change. Omitted fields keep their
    /// stored values. A request must supply <c>content</c> or <c>metadata</c>, or it fails
    /// with <c>ValidationException</c>. Supplying <c>content</c> re-embeds the memory. A
    /// change to metadata alone doesn't.
    /// 
    ///  
    /// <para>
    /// The memory keeps its <c>memoryId</c> across updates. Shortly after an update, searches
    /// stop returning the previous content.
    /// </para><para><c>memoryType</c> can't be changed. To change it, delete the memory and create a
    /// new one.
    /// </para><para>
    /// A memory past its expiry (set from the space's <c>memoryExpiryDays</c> when the memory
    /// is written) reads as not found: the operation fails with <c>ResourceNotFoundException</c>
    /// and changes nothing. An update does not move the expiry.
    /// </para><para>
    /// Concurrent updates to one memory are last-writer-wins. There is no version check.
    /// To avoid lost updates, serialize your updates to a memory.
    /// </para><para>
    /// If you supply <c>content</c> and the request would exceed the service's rate for embedding
    /// requests, it fails with <c>ThrottlingException</c>. Retry with exponential backoff.
    /// </para><para>
    /// If the space uses a customer managed AWS KMS key, the call can also fail because of
    /// the key. It fails with <c>AccessDeniedException</c> if you aren't allowed to use the
    /// key, and with <c>ThrottlingException</c> if AWS KMS throttles the request. It fails
    /// with <c>ValidationException</c> if the key is disabled, pending deletion, or deleted.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "OSMMemory", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchMemory.Model.Memory")]
    [AWSCmdlet("Calls the Amazon OpenSearch Memory UpdateMemory API operation.", Operation = new[] {"UpdateMemory"}, SelectReturnType = typeof(Amazon.OpenSearchMemory.Model.UpdateMemoryResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchMemory.Model.Memory or Amazon.OpenSearchMemory.Model.UpdateMemoryResponse",
        "This cmdlet returns an Amazon.OpenSearchMemory.Model.Memory object.",
        "The service call response (type Amazon.OpenSearchMemory.Model.UpdateMemoryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateOSMMemoryCmdlet : AmazonOpenSearchMemoryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActorId
        /// <summary>
        /// <para>
        /// <para>The ID of the actor that the memory must belong to. Omit it to skip this check. If
        /// it doesn't match the stored memory, the call fails with <c>ResourceNotFoundException</c>,
        /// as if the memory did not exist.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActorId { get; set; }
        #endregion
        
        #region Parameter Content
        /// <summary>
        /// <para>
        /// <para>Replacement memory text. Supplying it re-embeds the memory. Omit to leave the text
        /// unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content { get; set; }
        #endregion
        
        #region Parameter MemoryId
        /// <summary>
        /// <para>
        /// <para>The ID of the memory to update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MemoryId { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>The metadata tags to apply. By default this map replaces the stored metadata, and
        /// any key not present is removed. Set <c>metadataMode</c> to <c>MERGE</c> to keep the
        /// keys you don't supply. Limits apply to the resulting metadata, not to the request.
        /// Keys that begin with <c>x-amz-</c> and the key <c>documentS3Source</c> are reserved:
        /// a request that sets one fails with <c>ValidationException</c>.</para><para>A space can use at most 50 distinct metadata keys across all of its events and memories.
        /// A request that would add a key beyond that fails with <c>ValidationException</c>.
        /// Reuse an existing key instead.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Metadata { get; set; }
        #endregion
        
        #region Parameter MetadataMode
        /// <summary>
        /// <para>
        /// <para>How <c>metadata</c> combines with what is stored. The default is <c>REPLACE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchMemory.MetadataMode")]
        public Amazon.OpenSearchMemory.MetadataMode MetadataMode { get; set; }
        #endregion
        
        #region Parameter SpaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the space that owns the memory, for example <c>sp-02864597b164</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SpaceId { get; set; }
        #endregion
        
        #region Parameter StrategyName
        /// <summary>
        /// <para>
        /// <para>The name of the strategy that the memory must belong to. Omit it to skip this check.
        /// If it doesn't match the stored memory, the call fails with <c>ResourceNotFoundException</c>,
        /// as if the memory did not exist.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StrategyName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Memory'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchMemory.Model.UpdateMemoryResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchMemory.Model.UpdateMemoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Memory";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MemoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OSMMemory (UpdateMemory)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchMemory.Model.UpdateMemoryResponse, UpdateOSMMemoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActorId = this.ActorId;
            context.Content = this.Content;
            context.MemoryId = this.MemoryId;
            #if MODULAR
            if (this.MemoryId == null && ParameterWasBound(nameof(this.MemoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter MemoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Metadata != null)
            {
                context.Metadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Metadata.Keys)
                {
                    context.Metadata.Add((String)hashKey, (System.String)(this.Metadata[hashKey]));
                }
            }
            context.MetadataMode = this.MetadataMode;
            context.SpaceId = this.SpaceId;
            #if MODULAR
            if (this.SpaceId == null && ParameterWasBound(nameof(this.SpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter SpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StrategyName = this.StrategyName;
            
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
            var request = new Amazon.OpenSearchMemory.Model.UpdateMemoryRequest();
            
            if (cmdletContext.ActorId != null)
            {
                request.ActorId = cmdletContext.ActorId;
            }
            if (cmdletContext.Content != null)
            {
                request.Content = cmdletContext.Content;
            }
            if (cmdletContext.MemoryId != null)
            {
                request.MemoryId = cmdletContext.MemoryId;
            }
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            if (cmdletContext.MetadataMode != null)
            {
                request.MetadataMode = cmdletContext.MetadataMode;
            }
            if (cmdletContext.SpaceId != null)
            {
                request.SpaceId = cmdletContext.SpaceId;
            }
            if (cmdletContext.StrategyName != null)
            {
                request.StrategyName = cmdletContext.StrategyName;
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
        
        private Amazon.OpenSearchMemory.Model.UpdateMemoryResponse CallAWSServiceOperation(IAmazonOpenSearchMemory client, Amazon.OpenSearchMemory.Model.UpdateMemoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Memory", "UpdateMemory");
            try
            {
                return client.UpdateMemoryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ActorId { get; set; }
            public System.String Content { get; set; }
            public System.String MemoryId { get; set; }
            public Dictionary<System.String, System.String> Metadata { get; set; }
            public Amazon.OpenSearchMemory.MetadataMode MetadataMode { get; set; }
            public System.String SpaceId { get; set; }
            public System.String StrategyName { get; set; }
            public System.Func<Amazon.OpenSearchMemory.Model.UpdateMemoryResponse, UpdateOSMMemoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Memory;
        }
        
    }
}
