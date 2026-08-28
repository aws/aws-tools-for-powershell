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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Submits content directly for ingestion to generate long-term memory records in a AgentCore
    /// Memory resource.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have the <c>bedrock-agentcore:IngestData</c> permission.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "BACIngestion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer IngestData API operation.", Operation = new[] {"IngestData"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.IngestDataResponse))]
    [AWSCmdletOutput("System.String or Amazon.BedrockAgentCore.Model.IngestDataResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BedrockAgentCore.Model.IngestDataResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartBACIngestionCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActorId
        /// <summary>
        /// <para>
        /// <para>The identifier of the actor associated with this content. An actor represents an entity
        /// that participates in sessions and generates content.</para>
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
        
        #region Parameter ContentTimestamp
        /// <summary>
        /// <para>
        /// <para>The timestamp of when the content occurred.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? ContentTimestamp { get; set; }
        #endregion
        
        #region Parameter MemoryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the AgentCore Memory resource to ingest content into.</para>
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
        /// <para>The key-value metadata to attach to the content.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Metadata { get; set; }
        #endregion
        
        #region Parameter ExtractionConfig_NamespaceVariable
        /// <summary>
        /// <para>
        /// <para>A map of <c>namespaceKeys</c> to their values. The service substitutes these values
        /// into <c>namespaceTemplates</c> during long-term memory extraction to control namespace
        /// hierarchy.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExtractionConfig_NamespaceVariables")]
        public System.Collections.Hashtable ExtractionConfig_NamespaceVariable { get; set; }
        #endregion
        
        #region Parameter Source_Inline_Payload
        /// <summary>
        /// <para>
        /// <para>The list of content payload items to ingest.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.BedrockAgentCore.Model.IngestPayloadType[] Source_Inline_Payload { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the session that the content belongs to. If not provided, a session
        /// identifier is generated and returned in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, AgentCore ignores the request,
        /// but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SessionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.IngestDataResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.IngestDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SessionId";
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
                nameof(this.MemoryId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BACIngestion (IngestData)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.IngestDataResponse, StartBACIngestionCmdlet>(Select) ??
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
            context.ContentTimestamp = this.ContentTimestamp;
            #if MODULAR
            if (this.ContentTimestamp == null && ParameterWasBound(nameof(this.ContentTimestamp)))
            {
                WriteWarning("You are passing $null as a value for parameter ContentTimestamp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ExtractionConfig_NamespaceVariable != null)
            {
                context.ExtractionConfig_NamespaceVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ExtractionConfig_NamespaceVariable.Keys)
                {
                    context.ExtractionConfig_NamespaceVariable.Add((String)hashKey, (System.String)(this.ExtractionConfig_NamespaceVariable[hashKey]));
                }
            }
            context.MemoryId = this.MemoryId;
            #if MODULAR
            if (this.MemoryId == null && ParameterWasBound(nameof(this.MemoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter MemoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Metadata != null)
            {
                context.Metadata = new Dictionary<System.String, Amazon.BedrockAgentCore.Model.MetadataValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.Metadata.Keys)
                {
                    context.Metadata.Add((String)hashKey, (Amazon.BedrockAgentCore.Model.MetadataValue)(this.Metadata[hashKey]));
                }
            }
            context.SessionId = this.SessionId;
            if (this.Source_Inline_Payload != null)
            {
                context.Source_Inline_Payload = new List<Amazon.BedrockAgentCore.Model.IngestPayloadType>(this.Source_Inline_Payload);
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
            var request = new Amazon.BedrockAgentCore.Model.IngestDataRequest();
            
            if (cmdletContext.ActorId != null)
            {
                request.ActorId = cmdletContext.ActorId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ContentTimestamp != null)
            {
                request.ContentTimestamp = cmdletContext.ContentTimestamp.Value;
            }
            
             // populate ExtractionConfig
            var requestExtractionConfigIsNull = true;
            request.ExtractionConfig = new Amazon.BedrockAgentCore.Model.ExtractionConfig();
            Dictionary<System.String, System.String> requestExtractionConfig_extractionConfig_NamespaceVariable = null;
            if (cmdletContext.ExtractionConfig_NamespaceVariable != null)
            {
                requestExtractionConfig_extractionConfig_NamespaceVariable = cmdletContext.ExtractionConfig_NamespaceVariable;
            }
            if (requestExtractionConfig_extractionConfig_NamespaceVariable != null)
            {
                request.ExtractionConfig.NamespaceVariables = requestExtractionConfig_extractionConfig_NamespaceVariable;
                requestExtractionConfigIsNull = false;
            }
             // determine if request.ExtractionConfig should be set to null
            if (requestExtractionConfigIsNull)
            {
                request.ExtractionConfig = null;
            }
            if (cmdletContext.MemoryId != null)
            {
                request.MemoryId = cmdletContext.MemoryId;
            }
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.BedrockAgentCore.Model.ContentSource();
            Amazon.BedrockAgentCore.Model.InlineMemoryContent requestSource_source_Inline = null;
            
             // populate Inline
            var requestSource_source_InlineIsNull = true;
            requestSource_source_Inline = new Amazon.BedrockAgentCore.Model.InlineMemoryContent();
            List<Amazon.BedrockAgentCore.Model.IngestPayloadType> requestSource_source_Inline_source_Inline_Payload = null;
            if (cmdletContext.Source_Inline_Payload != null)
            {
                requestSource_source_Inline_source_Inline_Payload = cmdletContext.Source_Inline_Payload;
            }
            if (requestSource_source_Inline_source_Inline_Payload != null)
            {
                requestSource_source_Inline.Payload = requestSource_source_Inline_source_Inline_Payload;
                requestSource_source_InlineIsNull = false;
            }
             // determine if requestSource_source_Inline should be set to null
            if (requestSource_source_InlineIsNull)
            {
                requestSource_source_Inline = null;
            }
            if (requestSource_source_Inline != null)
            {
                request.Source.Inline = requestSource_source_Inline;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
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
        
        private Amazon.BedrockAgentCore.Model.IngestDataResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.IngestDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "IngestData");
            try
            {
                return client.IngestDataAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? ContentTimestamp { get; set; }
            public Dictionary<System.String, System.String> ExtractionConfig_NamespaceVariable { get; set; }
            public System.String MemoryId { get; set; }
            public Dictionary<System.String, Amazon.BedrockAgentCore.Model.MetadataValue> Metadata { get; set; }
            public System.String SessionId { get; set; }
            public List<Amazon.BedrockAgentCore.Model.IngestPayloadType> Source_Inline_Payload { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.IngestDataResponse, StartBACIngestionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SessionId;
        }
        
    }
}
