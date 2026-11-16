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
    /// Submits an event (conversation turns, structured data, or a PDF document stored in
    /// Amazon S3) to a session in a space.
    /// 
    ///  
    /// <para>
    /// The operation returns as soon as the event is saved. <c>GetEvent</c> and <c>ListEvents</c>
    /// return it immediately. <c>SearchEvents</c> returns it after it's indexed. <c>SearchMemories</c>
    /// returns memories extracted from it only after a strategy's extraction trigger fires
    /// and the memories are indexed.
    /// </para><para>
    /// If the space uses a customer managed AWS KMS key, the call can also fail because of
    /// the key. It fails with <c>AccessDeniedException</c> if you aren't allowed to use the
    /// key, and with <c>ThrottlingException</c> if AWS KMS throttles the request. It fails
    /// with <c>ValidationException</c> if the key is disabled, pending deletion, or deleted.
    /// </para>
    /// </summary>
    [Cmdlet("New", "OSMEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchMemory.Model.EventDetail")]
    [AWSCmdlet("Calls the Amazon OpenSearch Memory CreateEvent API operation.", Operation = new[] {"CreateEvent"}, SelectReturnType = typeof(Amazon.OpenSearchMemory.Model.CreateEventResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchMemory.Model.EventDetail or Amazon.OpenSearchMemory.Model.CreateEventResponse",
        "This cmdlet returns an Amazon.OpenSearchMemory.Model.EventDetail object.",
        "The service call response (type Amazon.OpenSearchMemory.Model.CreateEventResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewOSMEventCmdlet : AmazonOpenSearchMemoryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActorId
        /// <summary>
        /// <para>
        /// <para>The ID of the actor (end user or agent) that the event belongs to.</para>
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
        
        #region Parameter Payload_Blob_ContentType
        /// <summary>
        /// <para>
        /// <para>The document's media type. Only <c>application/pdf</c> is supported. Any other value
        /// fails with <c>ValidationException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchMemory.BlobContentType")]
        public Amazon.OpenSearchMemory.BlobContentType Payload_Blob_ContentType { get; set; }
        #endregion
        
        #region Parameter EventTimestamp
        /// <summary>
        /// <para>
        /// <para>When the event occurred. The default is the time that the service receives the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EventTimestamp { get; set; }
        #endregion
        
        #region Parameter Infer
        /// <summary>
        /// <para>
        /// <para>Specifies whether to extract memories from this event. The default is <c>true</c>.
        /// Set it to <c>false</c> to store the event without extraction: the service skips strategies
        /// that infer memories, and still indexes the event's turns for <c>SearchEvents</c>.
        /// A document submitted as a <c>blob</c> is still extracted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Infer { get; set; }
        #endregion
        
        #region Parameter Payload_StructuredData_Source_Json
        /// <summary>
        /// <para>
        /// <para>The structured content, as a JSON object of at most 1 MiB when serialized as UTF-8,
        /// nested at most 10 levels deep.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject Payload_StructuredData_Source_Json { get; set; }
        #endregion
        
        #region Parameter Payload_Conversational_Unified_Source_Object_Message
        /// <summary>
        /// <para>
        /// <para>The conversation turns, in order. The order matters for extraction.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Conversational_Unified_Source_Object_Messages")]
        public Amazon.OpenSearchMemory.Model.Message[] Payload_Conversational_Unified_Source_Object_Message { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>Metadata tags to store with the event. Memories derived from the event carry the same
        /// tags. Keys that begin with <c>x-amz-</c>, the keys <c>documentS3Source</c> and <c>documentS3Url</c>,
        /// and other keys that the service uses internally are reserved: a request that sets
        /// one fails with <c>ValidationException</c>, and the message names the key.</para><para>A space can use at most 50 distinct metadata keys across all of its events and memories.
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
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The session the event belongs to. Send every event of one conversation with the same
        /// session ID, so that <c>SUMMARY</c> strategies summarize the conversation as one session.
        /// If you omit it, the service generates a session ID and returns it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter SpaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the space that owns the event, for example <c>sp-02864597b164</c>.</para>
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
        
        #region Parameter Payload_Blob_Source_S3Location_Uri
        /// <summary>
        /// <para>
        /// <para>The object's S3 URI, for example <c>s3://bucket/key</c>. The bucket must be in the
        /// space's Region. You need <c>s3:GetObject</c> on the object, and <c>kms:Decrypt</c>
        /// on its key if the object uses SSE-KMS. The event doesn't store the object itself.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Payload_Blob_Source_S3Location_Uri { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that makes the request idempotent. Within 2 hours
        /// of the first request, a retry with the same token and the same request, including
        /// the same <c>sessionId</c>, returns the same event. If you omit <c>sessionId</c>, the
        /// service generates a new one on each attempt, so a retry fails with <c>ConflictException</c>.
        /// Reusing the token with different request content also fails with <c>ConflictException</c>.
        /// <c>eventTimestamp</c> isn't compared. After 2 hours, the token starts a new event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Event'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchMemory.Model.CreateEventResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchMemory.Model.CreateEventResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Event";
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
                nameof(this.SpaceId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OSMEvent (CreateEvent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchMemory.Model.CreateEventResponse, NewOSMEventCmdlet>(Select) ??
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
            context.EventTimestamp = this.EventTimestamp;
            context.Infer = this.Infer;
            if (this.Metadata != null)
            {
                context.Metadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Metadata.Keys)
                {
                    context.Metadata.Add((String)hashKey, (System.String)(this.Metadata[hashKey]));
                }
            }
            context.Payload_Blob_ContentType = this.Payload_Blob_ContentType;
            context.Payload_Blob_Source_S3Location_Uri = this.Payload_Blob_Source_S3Location_Uri;
            if (this.Payload_Conversational_Unified_Source_Object_Message != null)
            {
                context.Payload_Conversational_Unified_Source_Object_Message = new List<Amazon.OpenSearchMemory.Model.Message>(this.Payload_Conversational_Unified_Source_Object_Message);
            }
            context.Payload_StructuredData_Source_Json = this.Payload_StructuredData_Source_Json;
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
            var request = new Amazon.OpenSearchMemory.Model.CreateEventRequest();
            
            if (cmdletContext.ActorId != null)
            {
                request.ActorId = cmdletContext.ActorId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EventTimestamp != null)
            {
                request.EventTimestamp = cmdletContext.EventTimestamp.Value;
            }
            if (cmdletContext.Infer != null)
            {
                request.Infer = cmdletContext.Infer.Value;
            }
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            
             // populate Payload
            var requestPayloadIsNull = true;
            request.Payload = new Amazon.OpenSearchMemory.Model.EventPayload();
            Amazon.OpenSearchMemory.Model.ConversationalPayload requestPayload_payload_Conversational = null;
            
             // populate Conversational
            var requestPayload_payload_ConversationalIsNull = true;
            requestPayload_payload_Conversational = new Amazon.OpenSearchMemory.Model.ConversationalPayload();
            Amazon.OpenSearchMemory.Model.UnifiedConversational requestPayload_payload_Conversational_payload_Conversational_Unified = null;
            
             // populate Unified
            var requestPayload_payload_Conversational_payload_Conversational_UnifiedIsNull = true;
            requestPayload_payload_Conversational_payload_Conversational_Unified = new Amazon.OpenSearchMemory.Model.UnifiedConversational();
            Amazon.OpenSearchMemory.Model.UnifiedConversationalSource requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source = null;
            
             // populate Source
            var requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_SourceIsNull = true;
            requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source = new Amazon.OpenSearchMemory.Model.UnifiedConversationalSource();
            Amazon.OpenSearchMemory.Model.UnifiedConversationalObject requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source_payload_Conversational_Unified_Source_Object = null;
            
             // populate Object
            var requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source_payload_Conversational_Unified_Source_ObjectIsNull = true;
            requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source_payload_Conversational_Unified_Source_Object = new Amazon.OpenSearchMemory.Model.UnifiedConversationalObject();
            List<Amazon.OpenSearchMemory.Model.Message> requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source_payload_Conversational_Unified_Source_Object_payload_Conversational_Unified_Source_Object_Message = null;
            if (cmdletContext.Payload_Conversational_Unified_Source_Object_Message != null)
            {
                requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source_payload_Conversational_Unified_Source_Object_payload_Conversational_Unified_Source_Object_Message = cmdletContext.Payload_Conversational_Unified_Source_Object_Message;
            }
            if (requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source_payload_Conversational_Unified_Source_Object_payload_Conversational_Unified_Source_Object_Message != null)
            {
                requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source_payload_Conversational_Unified_Source_Object.Messages = requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source_payload_Conversational_Unified_Source_Object_payload_Conversational_Unified_Source_Object_Message;
                requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source_payload_Conversational_Unified_Source_ObjectIsNull = false;
            }
             // determine if requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source_payload_Conversational_Unified_Source_Object should be set to null
            if (requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source_payload_Conversational_Unified_Source_ObjectIsNull)
            {
                requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source_payload_Conversational_Unified_Source_Object = null;
            }
            if (requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source_payload_Conversational_Unified_Source_Object != null)
            {
                requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source.Object = requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source_payload_Conversational_Unified_Source_Object;
                requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_SourceIsNull = false;
            }
             // determine if requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source should be set to null
            if (requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_SourceIsNull)
            {
                requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source = null;
            }
            if (requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source != null)
            {
                requestPayload_payload_Conversational_payload_Conversational_Unified.Source = requestPayload_payload_Conversational_payload_Conversational_Unified_payload_Conversational_Unified_Source;
                requestPayload_payload_Conversational_payload_Conversational_UnifiedIsNull = false;
            }
             // determine if requestPayload_payload_Conversational_payload_Conversational_Unified should be set to null
            if (requestPayload_payload_Conversational_payload_Conversational_UnifiedIsNull)
            {
                requestPayload_payload_Conversational_payload_Conversational_Unified = null;
            }
            if (requestPayload_payload_Conversational_payload_Conversational_Unified != null)
            {
                requestPayload_payload_Conversational.Unified = requestPayload_payload_Conversational_payload_Conversational_Unified;
                requestPayload_payload_ConversationalIsNull = false;
            }
             // determine if requestPayload_payload_Conversational should be set to null
            if (requestPayload_payload_ConversationalIsNull)
            {
                requestPayload_payload_Conversational = null;
            }
            if (requestPayload_payload_Conversational != null)
            {
                request.Payload.Conversational = requestPayload_payload_Conversational;
                requestPayloadIsNull = false;
            }
            Amazon.OpenSearchMemory.Model.StructuredDataPayload requestPayload_payload_StructuredData = null;
            
             // populate StructuredData
            var requestPayload_payload_StructuredDataIsNull = true;
            requestPayload_payload_StructuredData = new Amazon.OpenSearchMemory.Model.StructuredDataPayload();
            Amazon.OpenSearchMemory.Model.StructuredDataSource requestPayload_payload_StructuredData_payload_StructuredData_Source = null;
            
             // populate Source
            var requestPayload_payload_StructuredData_payload_StructuredData_SourceIsNull = true;
            requestPayload_payload_StructuredData_payload_StructuredData_Source = new Amazon.OpenSearchMemory.Model.StructuredDataSource();
            Amazon.Runtime.Documents.Document? requestPayload_payload_StructuredData_payload_StructuredData_Source_payload_StructuredData_Source_Json = null;
            if (cmdletContext.Payload_StructuredData_Source_Json != null)
            {
                requestPayload_payload_StructuredData_payload_StructuredData_Source_payload_StructuredData_Source_Json = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Payload_StructuredData_Source_Json);
            }
            if (requestPayload_payload_StructuredData_payload_StructuredData_Source_payload_StructuredData_Source_Json != null)
            {
                requestPayload_payload_StructuredData_payload_StructuredData_Source.Json = requestPayload_payload_StructuredData_payload_StructuredData_Source_payload_StructuredData_Source_Json.Value;
                requestPayload_payload_StructuredData_payload_StructuredData_SourceIsNull = false;
            }
             // determine if requestPayload_payload_StructuredData_payload_StructuredData_Source should be set to null
            if (requestPayload_payload_StructuredData_payload_StructuredData_SourceIsNull)
            {
                requestPayload_payload_StructuredData_payload_StructuredData_Source = null;
            }
            if (requestPayload_payload_StructuredData_payload_StructuredData_Source != null)
            {
                requestPayload_payload_StructuredData.Source = requestPayload_payload_StructuredData_payload_StructuredData_Source;
                requestPayload_payload_StructuredDataIsNull = false;
            }
             // determine if requestPayload_payload_StructuredData should be set to null
            if (requestPayload_payload_StructuredDataIsNull)
            {
                requestPayload_payload_StructuredData = null;
            }
            if (requestPayload_payload_StructuredData != null)
            {
                request.Payload.StructuredData = requestPayload_payload_StructuredData;
                requestPayloadIsNull = false;
            }
            Amazon.OpenSearchMemory.Model.BlobPayload requestPayload_payload_Blob = null;
            
             // populate Blob
            var requestPayload_payload_BlobIsNull = true;
            requestPayload_payload_Blob = new Amazon.OpenSearchMemory.Model.BlobPayload();
            Amazon.OpenSearchMemory.BlobContentType requestPayload_payload_Blob_payload_Blob_ContentType = null;
            if (cmdletContext.Payload_Blob_ContentType != null)
            {
                requestPayload_payload_Blob_payload_Blob_ContentType = cmdletContext.Payload_Blob_ContentType;
            }
            if (requestPayload_payload_Blob_payload_Blob_ContentType != null)
            {
                requestPayload_payload_Blob.ContentType = requestPayload_payload_Blob_payload_Blob_ContentType;
                requestPayload_payload_BlobIsNull = false;
            }
            Amazon.OpenSearchMemory.Model.BlobSource requestPayload_payload_Blob_payload_Blob_Source = null;
            
             // populate Source
            var requestPayload_payload_Blob_payload_Blob_SourceIsNull = true;
            requestPayload_payload_Blob_payload_Blob_Source = new Amazon.OpenSearchMemory.Model.BlobSource();
            Amazon.OpenSearchMemory.Model.S3Location requestPayload_payload_Blob_payload_Blob_Source_payload_Blob_Source_S3Location = null;
            
             // populate S3Location
            var requestPayload_payload_Blob_payload_Blob_Source_payload_Blob_Source_S3LocationIsNull = true;
            requestPayload_payload_Blob_payload_Blob_Source_payload_Blob_Source_S3Location = new Amazon.OpenSearchMemory.Model.S3Location();
            System.String requestPayload_payload_Blob_payload_Blob_Source_payload_Blob_Source_S3Location_payload_Blob_Source_S3Location_Uri = null;
            if (cmdletContext.Payload_Blob_Source_S3Location_Uri != null)
            {
                requestPayload_payload_Blob_payload_Blob_Source_payload_Blob_Source_S3Location_payload_Blob_Source_S3Location_Uri = cmdletContext.Payload_Blob_Source_S3Location_Uri;
            }
            if (requestPayload_payload_Blob_payload_Blob_Source_payload_Blob_Source_S3Location_payload_Blob_Source_S3Location_Uri != null)
            {
                requestPayload_payload_Blob_payload_Blob_Source_payload_Blob_Source_S3Location.Uri = requestPayload_payload_Blob_payload_Blob_Source_payload_Blob_Source_S3Location_payload_Blob_Source_S3Location_Uri;
                requestPayload_payload_Blob_payload_Blob_Source_payload_Blob_Source_S3LocationIsNull = false;
            }
             // determine if requestPayload_payload_Blob_payload_Blob_Source_payload_Blob_Source_S3Location should be set to null
            if (requestPayload_payload_Blob_payload_Blob_Source_payload_Blob_Source_S3LocationIsNull)
            {
                requestPayload_payload_Blob_payload_Blob_Source_payload_Blob_Source_S3Location = null;
            }
            if (requestPayload_payload_Blob_payload_Blob_Source_payload_Blob_Source_S3Location != null)
            {
                requestPayload_payload_Blob_payload_Blob_Source.S3Location = requestPayload_payload_Blob_payload_Blob_Source_payload_Blob_Source_S3Location;
                requestPayload_payload_Blob_payload_Blob_SourceIsNull = false;
            }
             // determine if requestPayload_payload_Blob_payload_Blob_Source should be set to null
            if (requestPayload_payload_Blob_payload_Blob_SourceIsNull)
            {
                requestPayload_payload_Blob_payload_Blob_Source = null;
            }
            if (requestPayload_payload_Blob_payload_Blob_Source != null)
            {
                requestPayload_payload_Blob.Source = requestPayload_payload_Blob_payload_Blob_Source;
                requestPayload_payload_BlobIsNull = false;
            }
             // determine if requestPayload_payload_Blob should be set to null
            if (requestPayload_payload_BlobIsNull)
            {
                requestPayload_payload_Blob = null;
            }
            if (requestPayload_payload_Blob != null)
            {
                request.Payload.Blob = requestPayload_payload_Blob;
                requestPayloadIsNull = false;
            }
             // determine if request.Payload should be set to null
            if (requestPayloadIsNull)
            {
                request.Payload = null;
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
        
        private Amazon.OpenSearchMemory.Model.CreateEventResponse CallAWSServiceOperation(IAmazonOpenSearchMemory client, Amazon.OpenSearchMemory.Model.CreateEventRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Memory", "CreateEvent");
            try
            {
                return client.CreateEventAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? EventTimestamp { get; set; }
            public System.Boolean? Infer { get; set; }
            public Dictionary<System.String, System.String> Metadata { get; set; }
            public Amazon.OpenSearchMemory.BlobContentType Payload_Blob_ContentType { get; set; }
            public System.String Payload_Blob_Source_S3Location_Uri { get; set; }
            public List<Amazon.OpenSearchMemory.Model.Message> Payload_Conversational_Unified_Source_Object_Message { get; set; }
            public System.Management.Automation.PSObject Payload_StructuredData_Source_Json { get; set; }
            public System.String SessionId { get; set; }
            public System.String SpaceId { get; set; }
            public System.Func<Amazon.OpenSearchMemory.Model.CreateEventResponse, NewOSMEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Event;
        }
        
    }
}
