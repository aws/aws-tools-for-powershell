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
using Amazon.EventBridgeV2;
using Amazon.EventBridgeV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EVBV2
{
    /// <summary>
    /// Updates an EventSource. Fields omitted from the request are left unchanged.
    /// </summary>
    [Cmdlet("Update", "EVBV2EventSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EventBridgeV2.Model.UpdateEventSourceResponse")]
    [AWSCmdlet("Calls the Amazon EventBridgeV2 UpdateEventSource API operation.", Operation = new[] {"UpdateEventSource"}, SelectReturnType = typeof(Amazon.EventBridgeV2.Model.UpdateEventSourceResponse))]
    [AWSCmdletOutput("Amazon.EventBridgeV2.Model.UpdateEventSourceResponse",
        "This cmdlet returns an Amazon.EventBridgeV2.Model.UpdateEventSourceResponse object containing multiple properties."
    )]
    public partial class UpdateEVBV2EventSourceCmdlet : AmazonEventBridgeV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Algorithm
        /// <summary>
        /// <para>
        /// <para>The hash algorithm the provider uses to compute the signature.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.WebhookHmacAlgorithm")]
        public Amazon.EventBridgeV2.WebhookHmacAlgorithm Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Algorithm { get; set; }
        #endregion
        
        #region Parameter Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the destination that receives events that could not be delivered. An Amazon
        /// SQS queue is the supported destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn { get; set; }
        #endregion
        
        #region Parameter Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the destination that receives events that could not be delivered. An Amazon
        /// SQS queue is the supported destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn { get; set; }
        #endregion
        
        #region Parameter Configuration_AwsServiceEventsConfiguration_AwsService
        /// <summary>
        /// <para>
        /// <para>A single AWS service source identifier, e.g. "aws.s3". Wildcards and lists are rejected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_AwsServiceEventsConfiguration_AwsService { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_DeduplicationConfiguration_DeduplicationType
        /// <summary>
        /// <para>
        /// <para>How duplicate events are detected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.WebhookDeduplicationType")]
        public Amazon.EventBridgeV2.WebhookDeduplicationType Configuration_WebhookEventsConfiguration_DeduplicationConfiguration_DeduplicationType { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Delimiter
        /// <summary>
        /// <para>
        /// <para>The separator between parts of the signature header value, for example a comma for
        /// a header value of t=1727816400,v1=&lt;signature&gt;, or a space when the header carries
        /// several signatures. Required when TimestampHttpHeader is the same header as SignatureHttpHeader.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Delimiter { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Free-text description. Used by every resource type that has one: event buses, subscribers,
        /// and event sources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Encoding
        /// <summary>
        /// <para>
        /// <para>How the provider encodes the signature in the header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.WebhookHmacEncoding")]
        public Amazon.EventBridgeV2.WebhookHmacEncoding Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Encoding { get; set; }
        #endregion
        
        #region Parameter EventSourceArn
        /// <summary>
        /// <para>
        /// <para>EventSource ARN: event-sourcev2/&lt;type&gt;/&lt;name&gt;/&lt;id&gt;. The type segment
        /// is set by the service (aws.service for AWS service events, aws.partner for partner
        /// events, webhook for webhook events) and is not part of the resource's name. The id
        /// segment is a 25-character identifier generated by the service.</para>
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
        public System.String EventSourceArn { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_LogConfiguration_IncludePayload
        /// <summary>
        /// <para>
        /// <para>Whether the customer event payload is embedded in log records. Defaults to ON_ERROR_ONLY.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.IncludePayload")]
        public Amazon.EventBridgeV2.IncludePayload Configuration_WebhookEventsConfiguration_LogConfiguration_IncludePayload { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>Optional. The AWS KMS key that encrypts the EventSource's secret in AWS Secrets Manager.
        /// Omit it to encrypt the secret with the AWS managed key aws/secretsmanager. A key you
        /// supply must be an enabled customer managed key in your account and Region. Changing
        /// it re-encrypts the secret under the new key. The previous key can still decrypt the
        /// stored versions until the credential is next rotated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_WebhookEventsConfiguration_KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_LogConfiguration_Level
        /// <summary>
        /// <para>
        /// <para>Minimum log level. Records below this level are not emitted. Defaults to OFF.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.LogLevel")]
        public Amazon.EventBridgeV2.LogLevel Configuration_WebhookEventsConfiguration_LogConfiguration_Level { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_MessageIdHttpHeader
        /// <summary>
        /// <para>
        /// <para>The name of the header that carries the message ID. Required when SignedMessageComposition
        /// is MESSAGE_ID_DOT_TIMESTAMP_DOT_BODY. Requests whose message ID contains a period
        /// (.) are rejected. Reserved names are rejected, as described on StaticTokenAuthConfiguration's
        /// TokenHttpHeader.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_MessageIdHttpHeader { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_MetadataHttpHeader
        /// <summary>
        /// <para>
        /// <para>The HTTP request headers to add to each event's metadata, up to 20. Header names are
        /// case-insensitive and can't repeat. Each header is added under its lowercase name.
        /// Omit the list to add no headers. Headers that carry credentials or that describe the
        /// network path, and the header that carries the static token, can't be listed.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_WebhookEventsConfiguration_MetadataHttpHeaders")]
        public System.String[] Configuration_WebhookEventsConfiguration_MetadataHttpHeader { get; set; }
        #endregion
        
        #region Parameter Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>Identifier of the AWS KMS customer managed key used to encrypt events: a key ID, key
        /// ARN, alias name, or alias ARN. When absent, events are encrypted with an AWS owned
        /// key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Configuration_PartnerEventsConfiguration_PartnerEventSourceArn
        /// <summary>
        /// <para>
        /// <para>ARN of the partner event source to forward. It is a partner-owned resource, so the
        /// account segment is empty: arn:aws:events:&lt;region&gt;::event-source/aws.partner/&lt;name&gt;.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_PartnerEventsConfiguration_PartnerEventSourceArn { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Password
        /// <summary>
        /// <para>
        /// <para>The password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Password { get; set; }
        #endregion
        
        #region Parameter Configuration_AwsServiceEventsConfiguration_Pattern
        /// <summary>
        /// <para>
        /// <para>A filter pattern, as a JSON string, that defines which of the service's events are
        /// forwarded to the event bus. Do not include source, account, or region as top-level
        /// fields. If no pattern is specified, all events from the service are forwarded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_AwsServiceEventsConfiguration_Pattern { get; set; }
        #endregion
        
        #region Parameter Configuration_PartnerEventsConfiguration_Pattern
        /// <summary>
        /// <para>
        /// <para>A filter pattern, as a JSON string, that defines which of the partner event source's
        /// events are forwarded to the event bus. If no pattern is specified, all events from
        /// the partner event source are forwarded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_PartnerEventsConfiguration_Pattern { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>IAM role the service assumes to put the webhook's events on the event bus. Must belong
        /// to the calling account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_WebhookEventsConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretEncoding
        /// <summary>
        /// <para>
        /// <para>How the secret is encoded. RAW uses the secret's characters as the signing key. BASE64
        /// decodes the secret first, as providers that follow the Standard Webhooks specification
        /// require. The default is RAW.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.WebhookSecretEncoding")]
        public Amazon.EventBridgeV2.WebhookSecretEncoding Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretEncoding { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretValue
        /// <summary>
        /// <para>
        /// <para>The signing key shared with the provider. If you omit it, EventBridge generates one.
        /// EventBridge stores the key only in AWS Secrets Manager and never returns it, including
        /// from DescribeEventSource. The key must be 16 to 512 bytes; with BASE64 SecretEncoding,
        /// this is measured after decoding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretValue { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_SecretValue
        /// <summary>
        /// <para>
        /// <para>The token the provider sends in the header. If you omit it, EventBridge generates
        /// one. EventBridge stores the token only in AWS Secrets Manager and never returns it,
        /// including from DescribeEventSource. EventBridge compares it against the entire header
        /// value, so a provider that sends Authorization: Bearer &lt;token&gt; needs SecretValue
        /// to include the "Bearer " prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_SecretValue { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignatureHttpHeader
        /// <summary>
        /// <para>
        /// <para>The name of the header that carries the signature, for example X-Hub-Signature-256.
        /// When TimestampHttpHeader names the same header, Delimiter, SignaturePrefix and TimestampPrefix
        /// are all required. Reserved names are rejected, as described on StaticTokenAuthConfiguration's
        /// TokenHttpHeader.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignatureHttpHeader { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignaturePrefix
        /// <summary>
        /// <para>
        /// <para>The text that precedes the signature in the header value, for example sha256=. Required
        /// when TimestampHttpHeader is the same header as SignatureHttpHeader.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignaturePrefix { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignedMessageComposition
        /// <summary>
        /// <para>
        /// <para>How the provider assembles the message it signs from the request.</para><ul><li><para>BODY - The request body alone. BODY provides no replay protection.</para></li><li><para>TIMESTAMP_DOT_BODY - &lt;timestamp&gt;.&lt;body&gt;. Requires TimestampHttpHeader.</para></li><li><para>MESSAGE_ID_DOT_TIMESTAMP_DOT_BODY - &lt;messageId&gt;.&lt;timestamp&gt;.&lt;body&gt;,
        /// as in the Standard Webhooks specification. Requires TimestampHttpHeader and MessageIdHttpHeader.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.WebhookSignedMessageComposition")]
        public Amazon.EventBridgeV2.WebhookSignedMessageComposition Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignedMessageComposition { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampHttpHeader
        /// <summary>
        /// <para>
        /// <para>The name of the header that carries the request timestamp. Required when SignedMessageComposition
        /// is TIMESTAMP_DOT_BODY or MESSAGE_ID_DOT_TIMESTAMP_DOT_BODY, or when TimestampToleranceInSeconds
        /// is set. Not allowed when SignedMessageComposition is BODY, because BODY does not sign
        /// the timestamp. Reserved names are rejected, as described on StaticTokenAuthConfiguration's
        /// TokenHttpHeader.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampHttpHeader { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampPrefix
        /// <summary>
        /// <para>
        /// <para>The text that precedes the timestamp in the header value, for example t=. Required
        /// when TimestampHttpHeader is the same header as SignatureHttpHeader.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampPrefix { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampToleranceInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum difference, in seconds, allowed between the request timestamp and the
        /// time EventBridge receives the request. Requests outside this window are rejected.
        /// The default is 300 seconds. Requires TimestampHttpHeader. Not allowed when SignedMessageComposition
        /// is BODY, because BODY does not sign the timestamp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampToleranceInSeconds")]
        public System.Int32? Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampToleranceInSecond { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_TokenHttpHeader
        /// <summary>
        /// <para>
        /// <para>The name of the header that carries the secret, for example X-Webhook-Secret. Reserved
        /// names are rejected: the names EventBridge's edge writes, such as Host and the X-Forwarded-*
        /// family, and the hop-by-hop and framing names an HTTP intermediary may rewrite, such
        /// as Connection and Content-Length. Authorization is allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_TokenHttpHeader { get; set; }
        #endregion
        
        #region Parameter Configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Username
        /// <summary>
        /// <para>
        /// <para>The username.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Username { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridgeV2.Model.UpdateEventSourceResponse).
        /// Specifying the name of a property of type Amazon.EventBridgeV2.Model.UpdateEventSourceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EventSourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EVBV2EventSource (UpdateEventSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridgeV2.Model.UpdateEventSourceResponse, UpdateEVBV2EventSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Configuration_AwsServiceEventsConfiguration_AwsService = this.Configuration_AwsServiceEventsConfiguration_AwsService;
            context.Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn = this.Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn;
            context.Configuration_AwsServiceEventsConfiguration_Pattern = this.Configuration_AwsServiceEventsConfiguration_Pattern;
            context.Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn = this.Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn;
            context.Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier = this.Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier;
            context.Configuration_PartnerEventsConfiguration_PartnerEventSourceArn = this.Configuration_PartnerEventsConfiguration_PartnerEventSourceArn;
            context.Configuration_PartnerEventsConfiguration_Pattern = this.Configuration_PartnerEventsConfiguration_Pattern;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Password = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Password;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Username = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Username;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Algorithm = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Algorithm;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Delimiter = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Delimiter;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Encoding = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Encoding;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_MessageIdHttpHeader = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_MessageIdHttpHeader;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretEncoding = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretEncoding;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretValue = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretValue;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignatureHttpHeader = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignatureHttpHeader;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignaturePrefix = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignaturePrefix;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignedMessageComposition = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignedMessageComposition;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampHttpHeader = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampHttpHeader;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampPrefix = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampPrefix;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampToleranceInSecond = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampToleranceInSecond;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_SecretValue = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_SecretValue;
            context.Configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_TokenHttpHeader = this.Configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_TokenHttpHeader;
            context.Configuration_WebhookEventsConfiguration_DeduplicationConfiguration_DeduplicationType = this.Configuration_WebhookEventsConfiguration_DeduplicationConfiguration_DeduplicationType;
            context.Configuration_WebhookEventsConfiguration_KmsKeyIdentifier = this.Configuration_WebhookEventsConfiguration_KmsKeyIdentifier;
            context.Configuration_WebhookEventsConfiguration_LogConfiguration_IncludePayload = this.Configuration_WebhookEventsConfiguration_LogConfiguration_IncludePayload;
            context.Configuration_WebhookEventsConfiguration_LogConfiguration_Level = this.Configuration_WebhookEventsConfiguration_LogConfiguration_Level;
            if (this.Configuration_WebhookEventsConfiguration_MetadataHttpHeader != null)
            {
                context.Configuration_WebhookEventsConfiguration_MetadataHttpHeader = new List<System.String>(this.Configuration_WebhookEventsConfiguration_MetadataHttpHeader);
            }
            context.Configuration_WebhookEventsConfiguration_RoleArn = this.Configuration_WebhookEventsConfiguration_RoleArn;
            context.Description = this.Description;
            context.EventSourceArn = this.EventSourceArn;
            #if MODULAR
            if (this.EventSourceArn == null && ParameterWasBound(nameof(this.EventSourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EventSourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EventBridgeV2.Model.UpdateEventSourceRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.EventBridgeV2.Model.EventSourceConfiguration();
            Amazon.EventBridgeV2.Model.AwsServiceEventsSourceConfiguration requestConfiguration_configuration_AwsServiceEventsConfiguration = null;
            
             // populate AwsServiceEventsConfiguration
            var requestConfiguration_configuration_AwsServiceEventsConfigurationIsNull = true;
            requestConfiguration_configuration_AwsServiceEventsConfiguration = new Amazon.EventBridgeV2.Model.AwsServiceEventsSourceConfiguration();
            System.String requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_AwsService = null;
            if (cmdletContext.Configuration_AwsServiceEventsConfiguration_AwsService != null)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_AwsService = cmdletContext.Configuration_AwsServiceEventsConfiguration_AwsService;
            }
            if (requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_AwsService != null)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration.AwsService = requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_AwsService;
                requestConfiguration_configuration_AwsServiceEventsConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_Pattern = null;
            if (cmdletContext.Configuration_AwsServiceEventsConfiguration_Pattern != null)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_Pattern = cmdletContext.Configuration_AwsServiceEventsConfiguration_Pattern;
            }
            if (requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_Pattern != null)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration.Pattern = requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_Pattern;
                requestConfiguration_configuration_AwsServiceEventsConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.OnFailureConfiguration requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration = null;
            
             // populate OnFailureConfiguration
            var requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfigurationIsNull = true;
            requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration = new Amazon.EventBridgeV2.Model.OnFailureConfiguration();
            System.String requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn = null;
            if (cmdletContext.Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn != null)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn = cmdletContext.Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn;
            }
            if (requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn != null)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration.Arn = requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn;
                requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration should be set to null
            if (requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfigurationIsNull)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration = null;
            }
            if (requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration != null)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration.OnFailureConfiguration = requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration;
                requestConfiguration_configuration_AwsServiceEventsConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_AwsServiceEventsConfiguration should be set to null
            if (requestConfiguration_configuration_AwsServiceEventsConfigurationIsNull)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration = null;
            }
            if (requestConfiguration_configuration_AwsServiceEventsConfiguration != null)
            {
                request.Configuration.AwsServiceEventsConfiguration = requestConfiguration_configuration_AwsServiceEventsConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.PartnerEventsSourceConfiguration requestConfiguration_configuration_PartnerEventsConfiguration = null;
            
             // populate PartnerEventsConfiguration
            var requestConfiguration_configuration_PartnerEventsConfigurationIsNull = true;
            requestConfiguration_configuration_PartnerEventsConfiguration = new Amazon.EventBridgeV2.Model.PartnerEventsSourceConfiguration();
            System.String requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier = null;
            if (cmdletContext.Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier = cmdletContext.Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier;
            }
            if (requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration.PartnerBusKmsKeyIdentifier = requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier;
                requestConfiguration_configuration_PartnerEventsConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerEventSourceArn = null;
            if (cmdletContext.Configuration_PartnerEventsConfiguration_PartnerEventSourceArn != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerEventSourceArn = cmdletContext.Configuration_PartnerEventsConfiguration_PartnerEventSourceArn;
            }
            if (requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerEventSourceArn != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration.PartnerEventSourceArn = requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerEventSourceArn;
                requestConfiguration_configuration_PartnerEventsConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_Pattern = null;
            if (cmdletContext.Configuration_PartnerEventsConfiguration_Pattern != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_Pattern = cmdletContext.Configuration_PartnerEventsConfiguration_Pattern;
            }
            if (requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_Pattern != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration.Pattern = requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_Pattern;
                requestConfiguration_configuration_PartnerEventsConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.OnFailureConfiguration requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration = null;
            
             // populate OnFailureConfiguration
            var requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfigurationIsNull = true;
            requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration = new Amazon.EventBridgeV2.Model.OnFailureConfiguration();
            System.String requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn = null;
            if (cmdletContext.Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn = cmdletContext.Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn;
            }
            if (requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration.Arn = requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn;
                requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration should be set to null
            if (requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfigurationIsNull)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration = null;
            }
            if (requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration.OnFailureConfiguration = requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration;
                requestConfiguration_configuration_PartnerEventsConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_PartnerEventsConfiguration should be set to null
            if (requestConfiguration_configuration_PartnerEventsConfigurationIsNull)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration = null;
            }
            if (requestConfiguration_configuration_PartnerEventsConfiguration != null)
            {
                request.Configuration.PartnerEventsConfiguration = requestConfiguration_configuration_PartnerEventsConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.WebhookEventsSourceConfiguration requestConfiguration_configuration_WebhookEventsConfiguration = null;
            
             // populate WebhookEventsConfiguration
            var requestConfiguration_configuration_WebhookEventsConfigurationIsNull = true;
            requestConfiguration_configuration_WebhookEventsConfiguration = new Amazon.EventBridgeV2.Model.WebhookEventsSourceConfiguration();
            System.String requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_KmsKeyIdentifier = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_KmsKeyIdentifier != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_KmsKeyIdentifier = cmdletContext.Configuration_WebhookEventsConfiguration_KmsKeyIdentifier;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_KmsKeyIdentifier != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration.KmsKeyIdentifier = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_KmsKeyIdentifier;
                requestConfiguration_configuration_WebhookEventsConfigurationIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_MetadataHttpHeader = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_MetadataHttpHeader != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_MetadataHttpHeader = cmdletContext.Configuration_WebhookEventsConfiguration_MetadataHttpHeader;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_MetadataHttpHeader != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration.MetadataHttpHeaders = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_MetadataHttpHeader;
                requestConfiguration_configuration_WebhookEventsConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_RoleArn = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_RoleArn != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_RoleArn = cmdletContext.Configuration_WebhookEventsConfiguration_RoleArn;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_RoleArn != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration.RoleArn = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_RoleArn;
                requestConfiguration_configuration_WebhookEventsConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.WebhookDeduplicationConfiguration requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfiguration = null;
            
             // populate DeduplicationConfiguration
            var requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfigurationIsNull = true;
            requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfiguration = new Amazon.EventBridgeV2.Model.WebhookDeduplicationConfiguration();
            Amazon.EventBridgeV2.WebhookDeduplicationType requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfiguration_DeduplicationType = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_DeduplicationConfiguration_DeduplicationType != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfiguration_DeduplicationType = cmdletContext.Configuration_WebhookEventsConfiguration_DeduplicationConfiguration_DeduplicationType;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfiguration_DeduplicationType != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfiguration.DeduplicationType = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfiguration_DeduplicationType;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfiguration should be set to null
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfigurationIsNull)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfiguration = null;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfiguration != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration.DeduplicationConfiguration = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_DeduplicationConfiguration;
                requestConfiguration_configuration_WebhookEventsConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.LogConfiguration requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration = null;
            
             // populate LogConfiguration
            var requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfigurationIsNull = true;
            requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration = new Amazon.EventBridgeV2.Model.LogConfiguration();
            Amazon.EventBridgeV2.IncludePayload requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_IncludePayload = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_LogConfiguration_IncludePayload != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_IncludePayload = cmdletContext.Configuration_WebhookEventsConfiguration_LogConfiguration_IncludePayload;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_IncludePayload != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration.IncludePayload = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_IncludePayload;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.LogLevel requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_Level = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_LogConfiguration_Level != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_Level = cmdletContext.Configuration_WebhookEventsConfiguration_LogConfiguration_Level;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_Level != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration.Level = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration_Level;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration should be set to null
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfigurationIsNull)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration = null;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration.LogConfiguration = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_LogConfiguration;
                requestConfiguration_configuration_WebhookEventsConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.WebhookAuthConfiguration requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration = null;
            
             // populate AuthConfiguration
            var requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfigurationIsNull = true;
            requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration = new Amazon.EventBridgeV2.Model.WebhookAuthConfiguration();
            Amazon.EventBridgeV2.Model.WebhookBasicHttpAuthConfiguration requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration = null;
            
             // populate BasicHttpAuthConfiguration
            var requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfigurationIsNull = true;
            requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration = new Amazon.EventBridgeV2.Model.WebhookBasicHttpAuthConfiguration();
            System.String requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Password = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Password != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Password = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Password;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Password != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration.Password = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Password;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Username = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Username != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Username = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Username;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Username != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration.Username = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Username;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration should be set to null
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfigurationIsNull)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration = null;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration.BasicHttpAuthConfiguration = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.WebhookStaticTokenAuthConfiguration requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration = null;
            
             // populate StaticTokenAuthConfiguration
            var requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfigurationIsNull = true;
            requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration = new Amazon.EventBridgeV2.Model.WebhookStaticTokenAuthConfiguration();
            System.String requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_SecretValue = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_SecretValue != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_SecretValue = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_SecretValue;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_SecretValue != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration.SecretValue = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_SecretValue;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_TokenHttpHeader = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_TokenHttpHeader != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_TokenHttpHeader = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_TokenHttpHeader;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_TokenHttpHeader != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration.TokenHttpHeader = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_TokenHttpHeader;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration should be set to null
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfigurationIsNull)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration = null;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration.StaticTokenAuthConfiguration = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.WebhookHmacAuthConfiguration requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration = null;
            
             // populate HmacAuthConfiguration
            var requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfigurationIsNull = true;
            requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration = new Amazon.EventBridgeV2.Model.WebhookHmacAuthConfiguration();
            Amazon.EventBridgeV2.WebhookHmacAlgorithm requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Algorithm = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Algorithm != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Algorithm = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Algorithm;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Algorithm != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration.Algorithm = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Algorithm;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Delimiter = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Delimiter != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Delimiter = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Delimiter;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Delimiter != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration.Delimiter = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Delimiter;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.WebhookHmacEncoding requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Encoding = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Encoding != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Encoding = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Encoding;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Encoding != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration.Encoding = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Encoding;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_MessageIdHttpHeader = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_MessageIdHttpHeader != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_MessageIdHttpHeader = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_MessageIdHttpHeader;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_MessageIdHttpHeader != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration.MessageIdHttpHeader = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_MessageIdHttpHeader;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.WebhookSecretEncoding requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretEncoding = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretEncoding != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretEncoding = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretEncoding;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretEncoding != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration.SecretEncoding = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretEncoding;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretValue = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretValue != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretValue = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretValue;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretValue != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration.SecretValue = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretValue;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignatureHttpHeader = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignatureHttpHeader != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignatureHttpHeader = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignatureHttpHeader;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignatureHttpHeader != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration.SignatureHttpHeader = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignatureHttpHeader;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignaturePrefix = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignaturePrefix != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignaturePrefix = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignaturePrefix;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignaturePrefix != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration.SignaturePrefix = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignaturePrefix;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.WebhookSignedMessageComposition requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignedMessageComposition = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignedMessageComposition != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignedMessageComposition = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignedMessageComposition;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignedMessageComposition != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration.SignedMessageComposition = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignedMessageComposition;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampHttpHeader = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampHttpHeader != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampHttpHeader = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampHttpHeader;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampHttpHeader != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration.TimestampHttpHeader = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampHttpHeader;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampPrefix = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampPrefix != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampPrefix = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampPrefix;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampPrefix != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration.TimestampPrefix = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampPrefix;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfigurationIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampToleranceInSecond = null;
            if (cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampToleranceInSecond != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampToleranceInSecond = cmdletContext.Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampToleranceInSecond.Value;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampToleranceInSecond != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration.TimestampToleranceInSeconds = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampToleranceInSecond.Value;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration should be set to null
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfigurationIsNull)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration = null;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration.HmacAuthConfiguration = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration;
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration should be set to null
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfigurationIsNull)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration = null;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration != null)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration.AuthConfiguration = requestConfiguration_configuration_WebhookEventsConfiguration_configuration_WebhookEventsConfiguration_AuthConfiguration;
                requestConfiguration_configuration_WebhookEventsConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_WebhookEventsConfiguration should be set to null
            if (requestConfiguration_configuration_WebhookEventsConfigurationIsNull)
            {
                requestConfiguration_configuration_WebhookEventsConfiguration = null;
            }
            if (requestConfiguration_configuration_WebhookEventsConfiguration != null)
            {
                request.Configuration.WebhookEventsConfiguration = requestConfiguration_configuration_WebhookEventsConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EventSourceArn != null)
            {
                request.EventSourceArn = cmdletContext.EventSourceArn;
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
        
        private Amazon.EventBridgeV2.Model.UpdateEventSourceResponse CallAWSServiceOperation(IAmazonEventBridgeV2 client, Amazon.EventBridgeV2.Model.UpdateEventSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridgeV2", "UpdateEventSource");
            try
            {
                return client.UpdateEventSourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Configuration_AwsServiceEventsConfiguration_AwsService { get; set; }
            public System.String Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn { get; set; }
            public System.String Configuration_AwsServiceEventsConfiguration_Pattern { get; set; }
            public System.String Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn { get; set; }
            public System.String Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier { get; set; }
            public System.String Configuration_PartnerEventsConfiguration_PartnerEventSourceArn { get; set; }
            public System.String Configuration_PartnerEventsConfiguration_Pattern { get; set; }
            public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Password { get; set; }
            public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_BasicHttpAuthConfiguration_Username { get; set; }
            public Amazon.EventBridgeV2.WebhookHmacAlgorithm Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Algorithm { get; set; }
            public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Delimiter { get; set; }
            public Amazon.EventBridgeV2.WebhookHmacEncoding Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_Encoding { get; set; }
            public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_MessageIdHttpHeader { get; set; }
            public Amazon.EventBridgeV2.WebhookSecretEncoding Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretEncoding { get; set; }
            public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SecretValue { get; set; }
            public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignatureHttpHeader { get; set; }
            public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignaturePrefix { get; set; }
            public Amazon.EventBridgeV2.WebhookSignedMessageComposition Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_SignedMessageComposition { get; set; }
            public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampHttpHeader { get; set; }
            public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampPrefix { get; set; }
            public System.Int32? Configuration_WebhookEventsConfiguration_AuthConfiguration_HmacAuthConfiguration_TimestampToleranceInSecond { get; set; }
            public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_SecretValue { get; set; }
            public System.String Configuration_WebhookEventsConfiguration_AuthConfiguration_StaticTokenAuthConfiguration_TokenHttpHeader { get; set; }
            public Amazon.EventBridgeV2.WebhookDeduplicationType Configuration_WebhookEventsConfiguration_DeduplicationConfiguration_DeduplicationType { get; set; }
            public System.String Configuration_WebhookEventsConfiguration_KmsKeyIdentifier { get; set; }
            public Amazon.EventBridgeV2.IncludePayload Configuration_WebhookEventsConfiguration_LogConfiguration_IncludePayload { get; set; }
            public Amazon.EventBridgeV2.LogLevel Configuration_WebhookEventsConfiguration_LogConfiguration_Level { get; set; }
            public List<System.String> Configuration_WebhookEventsConfiguration_MetadataHttpHeader { get; set; }
            public System.String Configuration_WebhookEventsConfiguration_RoleArn { get; set; }
            public System.String Description { get; set; }
            public System.String EventSourceArn { get; set; }
            public System.Func<Amazon.EventBridgeV2.Model.UpdateEventSourceResponse, UpdateEVBV2EventSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
