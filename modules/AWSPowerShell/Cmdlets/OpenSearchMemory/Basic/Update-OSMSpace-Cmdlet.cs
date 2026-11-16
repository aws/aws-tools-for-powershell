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
    /// Updates a space's memory strategies, retention settings, or extraction model. Supply
    /// only the fields to change. Omitted fields keep their current values.
    /// 
    ///  
    /// <para>
    /// If the request changes the set of strategies, a strategy's configuration, a retention
    /// setting, or the extraction model, the space moves to <c>UPDATING</c>. When the change
    /// is complete, the space returns to <c>ACTIVE</c>, or moves to <c>FAILED</c> if the
    /// change can't be applied. While the space is <c>UPDATING</c>, <c>GetSpace</c> returns
    /// the previous configuration. A request that only changes strategy descriptions or repeats
    /// the values the space has stored is applied immediately and doesn't change the status.
    /// Sending a retention value that the space never set also moves the space to <c>UPDATING</c>,
    /// even one that matches the behavior without it, such as 90 for <c>eventExpiryDays</c>
    /// or 0 for <c>memoryExpiryDays</c>. A space that is <c>CREATING</c>, <c>UPDATING</c>,
    /// or <c>DELETING</c> can't be updated: the request fails with <c>ConflictException</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "OSMSpace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchMemory.Model.UpdateSpaceResponse")]
    [AWSCmdlet("Calls the Amazon OpenSearch Memory UpdateSpace API operation.", Operation = new[] {"UpdateSpace"}, SelectReturnType = typeof(Amazon.OpenSearchMemory.Model.UpdateSpaceResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchMemory.Model.UpdateSpaceResponse",
        "This cmdlet returns an Amazon.OpenSearchMemory.Model.UpdateSpaceResponse object containing multiple properties."
    )]
    public partial class UpdateOSMSpaceCmdlet : AmazonOpenSearchMemoryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EventExpiryDay
        /// <summary>
        /// <para>
        /// <para>How many days the space keeps each event, from 1 to 365. Omit it to leave the current
        /// value unchanged. Events already stored keep the expiry they were written with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventExpiryDays")]
        public System.Int32? EventExpiryDay { get; set; }
        #endregion
        
        #region Parameter ExtractionModelId
        /// <summary>
        /// <para>
        /// <para>The model that extracts and consolidates memories for every strategy in the space:
        /// <c>anthropic.claude-opus-5-5</c> or <c>anthropic.claude-haiku-5-5</c>. Omit it to
        /// leave the current value unchanged. Once set, it can't be cleared back to the service
        /// default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExtractionModelId { get; set; }
        #endregion
        
        #region Parameter MemoryExpiryDay
        /// <summary>
        /// <para>
        /// <para>How many days the space keeps each memory, from 0 to 3650. 0 means memories never
        /// expire. Omit it to leave the current value unchanged. You can't clear the setting.
        /// To make memories written from then on never expire, send 0. <c>GetSpace</c> then returns
        /// 0.</para><para>A change applies to memories written after it. Memories already stored keep the expiry
        /// they were written with. A memory the service rewrites later, such as a summary it
        /// keeps up to date, takes the setting in force at that rewrite. A change moves the space
        /// to <c>UPDATING</c>. Sending the value that the space has stored doesn't.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemoryExpiryDays")]
        public System.Int32? MemoryExpiryDay { get; set; }
        #endregion
        
        #region Parameter MemoryStrategy
        /// <summary>
        /// <para>
        /// <para>The complete new list of memory strategies. The service removes strategies that aren't
        /// in the list from the space. Removing a strategy stops extraction for it but doesn't
        /// delete its memories: they're kept, until they expire if the space sets <c>memoryExpiryDays</c>,
        /// and they're available again if you later add a strategy with the same <c>type</c>
        /// and <c>name</c>. To delete them, use <c>DeleteMemory</c> before you remove the strategy,
        /// or delete the space.</para><para>To keep a strategy, include it with the same <c>type</c> and <c>name</c> that <c>GetSpace</c>
        /// returns. For a kept strategy, any <c>configuration</c> member you omit keeps its current
        /// value. It doesn't return to the default, and you can't clear a member once it's set.
        /// Omit this field to leave the strategies unchanged. The list must name at least one
        /// strategy. You can't remove every strategy from a space with <c>UpdateSpace</c>.</para><para>The serialized list can be at most 384 KiB.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemoryStrategies")]
        public Amazon.OpenSearchMemory.Model.MemoryStrategy[] MemoryStrategy { get; set; }
        #endregion
        
        #region Parameter SpaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the space to update.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchMemory.Model.UpdateSpaceResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchMemory.Model.UpdateSpaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SpaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OSMSpace (UpdateSpace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchMemory.Model.UpdateSpaceResponse, UpdateOSMSpaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EventExpiryDay = this.EventExpiryDay;
            context.ExtractionModelId = this.ExtractionModelId;
            context.MemoryExpiryDay = this.MemoryExpiryDay;
            if (this.MemoryStrategy != null)
            {
                context.MemoryStrategy = new List<Amazon.OpenSearchMemory.Model.MemoryStrategy>(this.MemoryStrategy);
            }
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
            var request = new Amazon.OpenSearchMemory.Model.UpdateSpaceRequest();
            
            if (cmdletContext.EventExpiryDay != null)
            {
                request.EventExpiryDays = cmdletContext.EventExpiryDay.Value;
            }
            if (cmdletContext.ExtractionModelId != null)
            {
                request.ExtractionModelId = cmdletContext.ExtractionModelId;
            }
            if (cmdletContext.MemoryExpiryDay != null)
            {
                request.MemoryExpiryDays = cmdletContext.MemoryExpiryDay.Value;
            }
            if (cmdletContext.MemoryStrategy != null)
            {
                request.MemoryStrategies = cmdletContext.MemoryStrategy;
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
        
        private Amazon.OpenSearchMemory.Model.UpdateSpaceResponse CallAWSServiceOperation(IAmazonOpenSearchMemory client, Amazon.OpenSearchMemory.Model.UpdateSpaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Memory", "UpdateSpace");
            try
            {
                return client.UpdateSpaceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? EventExpiryDay { get; set; }
            public System.String ExtractionModelId { get; set; }
            public System.Int32? MemoryExpiryDay { get; set; }
            public List<Amazon.OpenSearchMemory.Model.MemoryStrategy> MemoryStrategy { get; set; }
            public System.String SpaceId { get; set; }
            public System.Func<Amazon.OpenSearchMemory.Model.UpdateSpaceResponse, UpdateOSMSpaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
