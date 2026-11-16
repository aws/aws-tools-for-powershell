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
    /// Writes a memory that you have already formed, without extracting it from events. The
    /// service embeds the text as given and stores it as a memory of the named strategy.
    /// To have the service extract memories from conversation turns, use <c>CreateEvent</c>
    /// instead.
    /// 
    ///  
    /// <para>
    /// The operation returns before the memory is searchable. The returned <c>memoryId</c>
    /// is final, but until the memory is indexed, <c>GetMemory</c>, <c>UpdateMemory</c>,
    /// and <c>DeleteMemory</c> return <c>ResourceNotFoundException</c> for it.
    /// </para><para>
    /// If the request would exceed the service's rate for embedding requests, it fails with
    /// <c>ThrottlingException</c>. Retry with exponential backoff.
    /// </para><para>
    /// If the space uses a customer managed AWS KMS key, the call can also fail because of
    /// the key. It fails with <c>AccessDeniedException</c> if you aren't allowed to use the
    /// key, and with <c>ThrottlingException</c> if AWS KMS throttles the request. It fails
    /// with <c>ValidationException</c> if the key is disabled, pending deletion, or deleted.
    /// </para>
    /// </summary>
    [Cmdlet("New", "OSMMemory", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchMemory.Model.CreateMemoryDetail")]
    [AWSCmdlet("Calls the Amazon OpenSearch Memory CreateMemory API operation.", Operation = new[] {"CreateMemory"}, SelectReturnType = typeof(Amazon.OpenSearchMemory.Model.CreateMemoryResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchMemory.Model.CreateMemoryDetail or Amazon.OpenSearchMemory.Model.CreateMemoryResponse",
        "This cmdlet returns an Amazon.OpenSearchMemory.Model.CreateMemoryDetail object.",
        "The service call response (type Amazon.OpenSearchMemory.Model.CreateMemoryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewOSMMemoryCmdlet : AmazonOpenSearchMemoryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActorId
        /// <summary>
        /// <para>
        /// <para>The actor (end user or agent) that owns the memory.</para>
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
        public System.String ActorId { get; set; }
        #endregion
        
        #region Parameter Content
        /// <summary>
        /// <para>
        /// <para>The memory text, stored and embedded as provided.</para>
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
        public System.String Content { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>Metadata tags to store with the memory. Keys that begin with <c>x-amz-</c>, the key
        /// <c>documentS3Source</c>, and other keys that the service uses internally are reserved:
        /// a request that sets one fails with <c>ValidationException</c>, and the message names
        /// the key.</para><para>A space can use at most 50 distinct metadata keys across all of its events and memories.
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the strategy that the memory belongs to. The space must already declare
        /// the strategy, and the memory's type comes from that strategy. The name must be 1 to
        /// 64 characters: letters, digits, periods, hyphens, and underscores, starting with a
        /// letter or digit.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The session that the memory belongs to. If you omit it, the service generates a session
        /// ID and returns it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionId { get; set; }
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that makes the request idempotent. Within 2 hours
        /// of the first request, a retry with the same token returns the same <c>memoryId</c>
        /// instead of creating a second memory. Reusing the token with a different <c>name</c>,
        /// <c>content</c>, <c>metadata</c>, <c>actorId</c>, or <c>sessionId</c> fails with <c>ConflictException</c>.
        /// If you omit <c>sessionId</c>, a retry with the same token gets the same session. If
        /// you omit the token, each call creates a new memory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Memory'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchMemory.Model.CreateMemoryResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchMemory.Model.CreateMemoryResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.ActorId),
                nameof(this.SpaceId),
                nameof(this.Name)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OSMMemory (CreateMemory)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchMemory.Model.CreateMemoryResponse, NewOSMMemoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActorId = this.ActorId;
            #if MODULAR
            if (this.ActorId == null && ParameterWasBound(nameof(this.ActorId)))
            {
                WriteWarning("You are passing $null as a value for parameter ActorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Content = this.Content;
            #if MODULAR
            if (this.Content == null && ParameterWasBound(nameof(this.Content)))
            {
                WriteWarning("You are passing $null as a value for parameter Content which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionId = this.SessionId;
            context.SpaceId = this.SpaceId;
            #if MODULAR
            if (this.SpaceId == null && ParameterWasBound(nameof(this.SpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter SpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.OpenSearchMemory.Model.CreateMemoryRequest();
            
            if (cmdletContext.ActorId != null)
            {
                request.ActorId = cmdletContext.ActorId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Content != null)
            {
                request.Content = cmdletContext.Content;
            }
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            if (cmdletContext.SpaceId != null)
            {
                request.SpaceId = cmdletContext.SpaceId;
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
        
        private Amazon.OpenSearchMemory.Model.CreateMemoryResponse CallAWSServiceOperation(IAmazonOpenSearchMemory client, Amazon.OpenSearchMemory.Model.CreateMemoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Memory", "CreateMemory");
            try
            {
                return client.CreateMemoryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Content { get; set; }
            public Dictionary<System.String, System.String> Metadata { get; set; }
            public System.String Name { get; set; }
            public System.String SessionId { get; set; }
            public System.String SpaceId { get; set; }
            public System.Func<Amazon.OpenSearchMemory.Model.CreateMemoryResponse, NewOSMMemoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Memory;
        }
        
    }
}
