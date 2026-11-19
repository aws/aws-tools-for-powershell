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
using Amazon.Polly;
using Amazon.Polly.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.POL
{
    /// <summary>
    /// Creates a custom voice from recordings of a speaker and returns it in <c>pending</c>
    /// status. Use <c>GetVoice</c> to check the status. When the status is <c>active</c>,
    /// you can use the voice ID in <c>SynthesizeSpeech</c>, <c>StartSpeechSynthesisTask</c>,
    /// and <c>StartSpeechSynthesisStream</c>.
    /// 
    ///  
    /// <para>
    /// The <c>custom-voice-max-count</c> service quota limits the number of custom voices
    /// in your account in each Region. If you reach the quota, the request fails with <c>ServiceQuotaExceededException</c>.
    /// </para><para>
    /// This operation requires permissions to perform the <c>polly:CreateVoice</c> action.
    /// You also need <c>s3:GetObject</c> permission on each recording that you specify by
    /// <c>S3Url</c>. If you specify a customer managed key, you also need <c>kms:DescribeKey</c>,
    /// <c>kms:GenerateDataKey</c>, and <c>kms:Decrypt</c> permissions on the key. If you
    /// specify <c>Tags</c>, you also need the <c>polly:TagResource</c> permission.
    /// </para>
    /// </summary>
    [Cmdlet("New", "POLVoice", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Polly.Model.Voice")]
    [AWSCmdlet("Calls the Amazon Polly CreateVoice API operation.", Operation = new[] {"CreateVoice"}, SelectReturnType = typeof(Amazon.Polly.Model.CreateVoiceResponse))]
    [AWSCmdletOutput("Amazon.Polly.Model.Voice or Amazon.Polly.Model.CreateVoiceResponse",
        "This cmdlet returns an Amazon.Polly.Model.Voice object.",
        "The service call response (type Amazon.Polly.Model.CreateVoiceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPOLVoiceCmdlet : AmazonPollyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CustomerManagedEncryption_EncryptionContext
        /// <summary>
        /// <para>
        /// <para>The key-value pairs that Amazon Polly includes as the encryption context when it encrypts
        /// or decrypts the voice with the key. You can use these pairs in key policy conditions.
        /// Don't use keys that start with <c>aws:</c>, which are reserved.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable CustomerManagedEncryption_EncryptionContext { get; set; }
        #endregion
        
        #region Parameter CustomerManagedEncryption_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the key. The key must be a symmetric encryption
        /// key in the same Amazon Web Services Region as the voice. To create the voice, you
        /// need <c>kms:DescribeKey</c>, <c>kms:GenerateDataKey</c>, and <c>kms:Decrypt</c> permissions
        /// on the key. To synthesize speech with the voice, you need <c>kms:Decrypt</c> permission
        /// on the key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerManagedEncryption_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language of the recordings, for example, <c>en-US</c>. Amazon Polly doesn't detect
        /// the language from the recordings.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Polly.CustomVoiceLanguageCode")]
        public Amazon.Polly.CustomVoiceLanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the voice. Use the name to identify the voice in your application. The
        /// name can contain letters, digits, hyphens, and underscores, and can be up to 64 characters
        /// long. The name doesn't have to be unique. The name isn't the voice ID, which Amazon
        /// Polly assigns.</para>
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
        
        #region Parameter VoiceCreationData_Recording
        /// <summary>
        /// <para>
        /// <para>The recordings of the speaker. Each recording specifies its audio format and its audio
        /// source.</para><para />
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
        [Alias("VoiceCreationData_Recordings")]
        public Amazon.Polly.Model.Recording[] VoiceCreationData_Recording { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that you apply to the voice to help you categorize and organize it. Each
        /// tag consists of a key and an optional value, both of which you define.</para><para />
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
        
        #region Parameter TermsAccepted
        /// <summary>
        /// <para>
        /// <para>Confirms the following two statements:</para><ul><li><para>"I confirm that I have obtained all necessary consents required under any applicable
        /// laws and regulations, including biometric privacy laws, from the owner of this voice
        /// to clone these voice samples."</para></li><li><para>"I confirm that I will not use the generated content for any illegal, fraudulent,
        /// or harmful purpose and reaffirm my obligation to abide by the AWS Service Terms, Biometric
        /// Notice and Consent Terms, AWS Responsible AI Policy, and AWS Acceptable Use Policy."</para></li></ul><para>You can read the <a href="https://aws.amazon.com/service-terms/">AWS Service Terms</a>,
        /// the <a href="https://aws.amazon.com/legal/biometric-notice-and-consent-terms/">Biometric
        /// Notice and Consent Terms</a>, the <a href="https://aws.amazon.com/ai/responsible-ai/policy/">AWS
        /// Responsible AI Policy</a>, and the <a href="https://aws.amazon.com/aup/">AWS Acceptable
        /// Use Policy</a> on the Amazon Web Services website.</para><para>You must set this parameter to <c>true</c> to create a voice. Otherwise, the request
        /// fails with <c>ValidationException</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? TermsAccepted { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you don't specify a client token, the Amazon Web Services SDKs generate
        /// one for you. If you retry a request that succeeded with the same client token and
        /// the same parameters, Amazon Polly returns the voice that the first request created
        /// and doesn't create a second voice.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Voice'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Polly.Model.CreateVoiceResponse).
        /// Specifying the name of a property of type Amazon.Polly.Model.CreateVoiceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Voice";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-POLVoice (CreateVoice)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Polly.Model.CreateVoiceResponse, NewPOLVoiceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.CustomerManagedEncryption_EncryptionContext != null)
            {
                context.CustomerManagedEncryption_EncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomerManagedEncryption_EncryptionContext.Keys)
                {
                    context.CustomerManagedEncryption_EncryptionContext.Add((String)hashKey, (System.String)(this.CustomerManagedEncryption_EncryptionContext[hashKey]));
                }
            }
            context.CustomerManagedEncryption_KmsKeyArn = this.CustomerManagedEncryption_KmsKeyArn;
            context.LanguageCode = this.LanguageCode;
            #if MODULAR
            if (this.LanguageCode == null && ParameterWasBound(nameof(this.LanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter LanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TermsAccepted = this.TermsAccepted;
            #if MODULAR
            if (this.TermsAccepted == null && ParameterWasBound(nameof(this.TermsAccepted)))
            {
                WriteWarning("You are passing $null as a value for parameter TermsAccepted which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VoiceCreationData_Recording != null)
            {
                context.VoiceCreationData_Recording = new List<Amazon.Polly.Model.Recording>(this.VoiceCreationData_Recording);
            }
            #if MODULAR
            if (this.VoiceCreationData_Recording == null && ParameterWasBound(nameof(this.VoiceCreationData_Recording)))
            {
                WriteWarning("You are passing $null as a value for parameter VoiceCreationData_Recording which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Polly.Model.CreateVoiceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate CustomerManagedEncryption
            var requestCustomerManagedEncryptionIsNull = true;
            request.CustomerManagedEncryption = new Amazon.Polly.Model.CustomerManagedEncryption();
            Dictionary<System.String, System.String> requestCustomerManagedEncryption_customerManagedEncryption_EncryptionContext = null;
            if (cmdletContext.CustomerManagedEncryption_EncryptionContext != null)
            {
                requestCustomerManagedEncryption_customerManagedEncryption_EncryptionContext = cmdletContext.CustomerManagedEncryption_EncryptionContext;
            }
            if (requestCustomerManagedEncryption_customerManagedEncryption_EncryptionContext != null)
            {
                request.CustomerManagedEncryption.EncryptionContext = requestCustomerManagedEncryption_customerManagedEncryption_EncryptionContext;
                requestCustomerManagedEncryptionIsNull = false;
            }
            System.String requestCustomerManagedEncryption_customerManagedEncryption_KmsKeyArn = null;
            if (cmdletContext.CustomerManagedEncryption_KmsKeyArn != null)
            {
                requestCustomerManagedEncryption_customerManagedEncryption_KmsKeyArn = cmdletContext.CustomerManagedEncryption_KmsKeyArn;
            }
            if (requestCustomerManagedEncryption_customerManagedEncryption_KmsKeyArn != null)
            {
                request.CustomerManagedEncryption.KmsKeyArn = requestCustomerManagedEncryption_customerManagedEncryption_KmsKeyArn;
                requestCustomerManagedEncryptionIsNull = false;
            }
             // determine if request.CustomerManagedEncryption should be set to null
            if (requestCustomerManagedEncryptionIsNull)
            {
                request.CustomerManagedEncryption = null;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TermsAccepted != null)
            {
                request.TermsAccepted = cmdletContext.TermsAccepted.Value;
            }
            
             // populate VoiceCreationData
            var requestVoiceCreationDataIsNull = true;
            request.VoiceCreationData = new Amazon.Polly.Model.VoiceCreationData();
            List<Amazon.Polly.Model.Recording> requestVoiceCreationData_voiceCreationData_Recording = null;
            if (cmdletContext.VoiceCreationData_Recording != null)
            {
                requestVoiceCreationData_voiceCreationData_Recording = cmdletContext.VoiceCreationData_Recording;
            }
            if (requestVoiceCreationData_voiceCreationData_Recording != null)
            {
                request.VoiceCreationData.Recordings = requestVoiceCreationData_voiceCreationData_Recording;
                requestVoiceCreationDataIsNull = false;
            }
             // determine if request.VoiceCreationData should be set to null
            if (requestVoiceCreationDataIsNull)
            {
                request.VoiceCreationData = null;
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
        
        private Amazon.Polly.Model.CreateVoiceResponse CallAWSServiceOperation(IAmazonPolly client, Amazon.Polly.Model.CreateVoiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Polly", "CreateVoice");
            try
            {
                return client.CreateVoiceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Dictionary<System.String, System.String> CustomerManagedEncryption_EncryptionContext { get; set; }
            public System.String CustomerManagedEncryption_KmsKeyArn { get; set; }
            public Amazon.Polly.CustomVoiceLanguageCode LanguageCode { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Boolean? TermsAccepted { get; set; }
            public List<Amazon.Polly.Model.Recording> VoiceCreationData_Recording { get; set; }
            public System.Func<Amazon.Polly.Model.CreateVoiceResponse, NewPOLVoiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Voice;
        }
        
    }
}
