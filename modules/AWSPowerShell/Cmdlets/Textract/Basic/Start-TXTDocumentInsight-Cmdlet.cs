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
using Amazon.Textract;
using Amazon.Textract.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TXT
{
    /// <summary>
    /// Starts an asynchronous job that analyzes a document using the configuration defined
    /// by a project or a set of blueprints. Use <a>GetDocumentInsights</a> to retrieve the
    /// results of the job.
    /// </summary>
    [Cmdlet("Start", "TXTDocumentInsight", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Textract StartDocumentInsights API operation.", Operation = new[] {"StartDocumentInsights"}, SelectReturnType = typeof(Amazon.Textract.Model.StartDocumentInsightsResponse))]
    [AWSCmdletOutput("System.String or Amazon.Textract.Model.StartDocumentInsightsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Textract.Model.StartDocumentInsightsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartTXTDocumentInsightCmdlet : AmazonTextractClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Blueprint
        /// <summary>
        /// <para>
        /// <para>The blueprints used to extract custom structured output from the document.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Blueprints")]
        public Amazon.Textract.Model.BlueprintItem[] Blueprint { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsEncryptionContext
        /// <summary>
        /// <para>
        /// <para>A set of key-value pairs that Amazon Textract includes as the AWS KMS encryption context
        /// when encrypting and decrypting the resource.</para><para>On <c>UpdateProject</c> and <c>UpdateBlueprint</c>, this member is the one exception
        /// to replacing a supplied configuration whole. If you omit it, the stored encryption
        /// context is kept. To clear a custom encryption context, specify an empty map (<c>{}</c>).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable EncryptionConfiguration_KmsEncryptionContext { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the AWS KMS key to use for encryption. This can be a key ID, key
        /// ARN, alias name, or alias ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ProjectArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the project whose configuration is used to analyze
        /// the document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProjectArn { get; set; }
        #endregion
        
        #region Parameter InputConfiguration_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI of the input document.</para>
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
        public System.String InputConfiguration_S3Uri { get; set; }
        #endregion
        
        #region Parameter OutputConfiguration_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI where the analysis results are written.</para>
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
        public System.String OutputConfiguration_S3Uri { get; set; }
        #endregion
        
        #region Parameter NotificationConfiguration_EventBridgeConfiguration_State
        /// <summary>
        /// <para>
        /// <para>Set to <c>ENABLED</c> to send events to an event bus, or <c>DISABLED</c> to not send
        /// them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Textract.State")]
        public Amazon.Textract.State NotificationConfiguration_EventBridgeConfiguration_State { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of tags (key-value pairs) to assign to the document insights job.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Textract.Model.StartDocumentInsightsResponse).
        /// Specifying the name of a property of type Amazon.Textract.Model.StartDocumentInsightsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobArn";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-TXTDocumentInsight (StartDocumentInsights)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Textract.Model.StartDocumentInsightsResponse, StartTXTDocumentInsightCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Blueprint != null)
            {
                context.Blueprint = new List<Amazon.Textract.Model.BlueprintItem>(this.Blueprint);
            }
            if (this.EncryptionConfiguration_KmsEncryptionContext != null)
            {
                context.EncryptionConfiguration_KmsEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EncryptionConfiguration_KmsEncryptionContext.Keys)
                {
                    context.EncryptionConfiguration_KmsEncryptionContext.Add((String)hashKey, (System.String)(this.EncryptionConfiguration_KmsEncryptionContext[hashKey]));
                }
            }
            context.EncryptionConfiguration_KmsKeyId = this.EncryptionConfiguration_KmsKeyId;
            context.InputConfiguration_S3Uri = this.InputConfiguration_S3Uri;
            #if MODULAR
            if (this.InputConfiguration_S3Uri == null && ParameterWasBound(nameof(this.InputConfiguration_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter InputConfiguration_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NotificationConfiguration_EventBridgeConfiguration_State = this.NotificationConfiguration_EventBridgeConfiguration_State;
            context.OutputConfiguration_S3Uri = this.OutputConfiguration_S3Uri;
            #if MODULAR
            if (this.OutputConfiguration_S3Uri == null && ParameterWasBound(nameof(this.OutputConfiguration_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfiguration_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectArn = this.ProjectArn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Textract.Model.StartDocumentInsightsRequest();
            
            if (cmdletContext.Blueprint != null)
            {
                request.Blueprints = cmdletContext.Blueprint;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.Textract.Model.EncryptionConfiguration();
            Dictionary<System.String, System.String> requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext = null;
            if (cmdletContext.EncryptionConfiguration_KmsEncryptionContext != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext = cmdletContext.EncryptionConfiguration_KmsEncryptionContext;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext != null)
            {
                request.EncryptionConfiguration.KmsEncryptionContext = requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext;
                requestEncryptionConfigurationIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyId != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = cmdletContext.EncryptionConfiguration_KmsKeyId;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId != null)
            {
                request.EncryptionConfiguration.KmsKeyId = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            
             // populate InputConfiguration
            var requestInputConfigurationIsNull = true;
            request.InputConfiguration = new Amazon.Textract.Model.InputConfiguration();
            System.String requestInputConfiguration_inputConfiguration_S3Uri = null;
            if (cmdletContext.InputConfiguration_S3Uri != null)
            {
                requestInputConfiguration_inputConfiguration_S3Uri = cmdletContext.InputConfiguration_S3Uri;
            }
            if (requestInputConfiguration_inputConfiguration_S3Uri != null)
            {
                request.InputConfiguration.S3Uri = requestInputConfiguration_inputConfiguration_S3Uri;
                requestInputConfigurationIsNull = false;
            }
             // determine if request.InputConfiguration should be set to null
            if (requestInputConfigurationIsNull)
            {
                request.InputConfiguration = null;
            }
            
             // populate NotificationConfiguration
            var requestNotificationConfigurationIsNull = true;
            request.NotificationConfiguration = new Amazon.Textract.Model.NotificationConfiguration();
            Amazon.Textract.Model.EventBridgeConfiguration requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration = null;
            
             // populate EventBridgeConfiguration
            var requestNotificationConfiguration_notificationConfiguration_EventBridgeConfigurationIsNull = true;
            requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration = new Amazon.Textract.Model.EventBridgeConfiguration();
            Amazon.Textract.State requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration_notificationConfiguration_EventBridgeConfiguration_State = null;
            if (cmdletContext.NotificationConfiguration_EventBridgeConfiguration_State != null)
            {
                requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration_notificationConfiguration_EventBridgeConfiguration_State = cmdletContext.NotificationConfiguration_EventBridgeConfiguration_State;
            }
            if (requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration_notificationConfiguration_EventBridgeConfiguration_State != null)
            {
                requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration.State = requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration_notificationConfiguration_EventBridgeConfiguration_State;
                requestNotificationConfiguration_notificationConfiguration_EventBridgeConfigurationIsNull = false;
            }
             // determine if requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration should be set to null
            if (requestNotificationConfiguration_notificationConfiguration_EventBridgeConfigurationIsNull)
            {
                requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration = null;
            }
            if (requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration != null)
            {
                request.NotificationConfiguration.EventBridgeConfiguration = requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration;
                requestNotificationConfigurationIsNull = false;
            }
             // determine if request.NotificationConfiguration should be set to null
            if (requestNotificationConfigurationIsNull)
            {
                request.NotificationConfiguration = null;
            }
            
             // populate OutputConfiguration
            var requestOutputConfigurationIsNull = true;
            request.OutputConfiguration = new Amazon.Textract.Model.OutputConfiguration();
            System.String requestOutputConfiguration_outputConfiguration_S3Uri = null;
            if (cmdletContext.OutputConfiguration_S3Uri != null)
            {
                requestOutputConfiguration_outputConfiguration_S3Uri = cmdletContext.OutputConfiguration_S3Uri;
            }
            if (requestOutputConfiguration_outputConfiguration_S3Uri != null)
            {
                request.OutputConfiguration.S3Uri = requestOutputConfiguration_outputConfiguration_S3Uri;
                requestOutputConfigurationIsNull = false;
            }
             // determine if request.OutputConfiguration should be set to null
            if (requestOutputConfigurationIsNull)
            {
                request.OutputConfiguration = null;
            }
            if (cmdletContext.ProjectArn != null)
            {
                request.ProjectArn = cmdletContext.ProjectArn;
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
        
        private Amazon.Textract.Model.StartDocumentInsightsResponse CallAWSServiceOperation(IAmazonTextract client, Amazon.Textract.Model.StartDocumentInsightsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Textract", "StartDocumentInsights");
            try
            {
                return client.StartDocumentInsightsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Textract.Model.BlueprintItem> Blueprint { get; set; }
            public Dictionary<System.String, System.String> EncryptionConfiguration_KmsEncryptionContext { get; set; }
            public System.String EncryptionConfiguration_KmsKeyId { get; set; }
            public System.String InputConfiguration_S3Uri { get; set; }
            public Amazon.Textract.State NotificationConfiguration_EventBridgeConfiguration_State { get; set; }
            public System.String OutputConfiguration_S3Uri { get; set; }
            public System.String ProjectArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Textract.Model.StartDocumentInsightsResponse, StartTXTDocumentInsightCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobArn;
        }
        
    }
}
