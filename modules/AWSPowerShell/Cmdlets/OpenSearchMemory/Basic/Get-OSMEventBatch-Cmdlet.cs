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
    /// Gets up to 10 events by ID, each as <c>GetEvent</c> returns it, including its payload.
    /// 
    ///  
    /// <para>
    /// If you supply <c>actorId</c> or <c>sessionId</c>, every requested event must match
    /// it. Each event has its own outcome. The operation reports an event that it can't return
    /// in <c>errors</c> instead of failing, with an error code named for the exception that
    /// <c>GetEvent</c> would return for it. The operation reports both an event that doesn't
    /// exist and an event outside the supplied scope as <c>RESOURCE_NOT_FOUND</c>.
    /// </para><para>
    /// The exception is the space's customer managed AWS KMS key: if it is disabled, pending
    /// deletion, can't be used for decryption, or was deleted, the whole call fails with
    /// <c>ValidationException</c>, as <c>GetEvent</c> does.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "OSMEventBatch")]
    [OutputType("Amazon.OpenSearchMemory.Model.BatchGetEventResponse")]
    [AWSCmdlet("Calls the Amazon OpenSearch Memory BatchGetEvent API operation.", Operation = new[] {"BatchGetEvent"}, SelectReturnType = typeof(Amazon.OpenSearchMemory.Model.BatchGetEventResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchMemory.Model.BatchGetEventResponse",
        "This cmdlet returns an Amazon.OpenSearchMemory.Model.BatchGetEventResponse object containing multiple properties."
    )]
    public partial class GetOSMEventBatchCmdlet : AmazonOpenSearchMemoryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActorId
        /// <summary>
        /// <para>
        /// <para>The actor that every requested event must belong to. Omit it to skip this check. The
        /// operation reports an event that doesn't match in <c>errors</c> as <c>RESOURCE_NOT_FOUND</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActorId { get; set; }
        #endregion
        
        #region Parameter EventId
        /// <summary>
        /// <para>
        /// <para>The IDs of the events to get: 1 to 10, without duplicates.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("EventIds")]
        public System.String[] EventId { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The session that every requested event must belong to. Omit it to skip this check.
        /// The operation reports an event that doesn't match in <c>errors</c> as <c>RESOURCE_NOT_FOUND</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter SpaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the space.</para>
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
        public System.String SpaceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchMemory.Model.BatchGetEventResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchMemory.Model.BatchGetEventResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchMemory.Model.BatchGetEventResponse, GetOSMEventBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActorId = this.ActorId;
            if (this.EventId != null)
            {
                context.EventId = new List<System.String>(this.EventId);
            }
            #if MODULAR
            if (this.EventId == null && ParameterWasBound(nameof(this.EventId)))
            {
                WriteWarning("You are passing $null as a value for parameter EventId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpenSearchMemory.Model.BatchGetEventRequest();
            
            if (cmdletContext.ActorId != null)
            {
                request.ActorId = cmdletContext.ActorId;
            }
            if (cmdletContext.EventId != null)
            {
                request.EventIds = cmdletContext.EventId;
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
        
        private Amazon.OpenSearchMemory.Model.BatchGetEventResponse CallAWSServiceOperation(IAmazonOpenSearchMemory client, Amazon.OpenSearchMemory.Model.BatchGetEventRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Memory", "BatchGetEvent");
            try
            {
                return client.BatchGetEventAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> EventId { get; set; }
            public System.String SessionId { get; set; }
            public System.String SpaceId { get; set; }
            public System.Func<Amazon.OpenSearchMemory.Model.BatchGetEventResponse, GetOSMEventBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
