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
using Amazon.Translate;
using Amazon.Translate.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TRN
{
    /// <summary>
    /// Translates the input document from the source language to the target language. This
    /// synchronous operation supports text, HTML, or Word documents as the input document.
    /// <c>TranslateDocument</c> supports translations from English to any supported language,
    /// and from any supported language to English. Therefore, specify either the source language
    /// code or the target language code as “en” (English). 
    /// 
    ///  
    /// <para>
    ///  If you set the <c>Formality</c> parameter, the request will fail if the target language
    /// does not support formality. For a list of target languages that support formality,
    /// see <a href="https://docs.aws.amazon.com/translate/latest/dg/customizing-translations-formality.html">Setting
    /// formality</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("ConvertTo", "TRNDocument", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Translate.Model.TranslateDocumentResponse")]
    [AWSCmdlet("Calls the Amazon Translate TranslateDocument API operation.", Operation = new[] {"TranslateDocument"}, SelectReturnType = typeof(Amazon.Translate.Model.TranslateDocumentResponse))]
    [AWSCmdletOutput("Amazon.Translate.Model.TranslateDocumentResponse",
        "This cmdlet returns an Amazon.Translate.Model.TranslateDocumentResponse object containing multiple properties."
    )]
    public partial class ConvertToTRNDocumentCmdlet : AmazonTranslateClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Settings_Brevity
        /// <summary>
        /// <para>
        /// <para>When you turn on brevity, Amazon Translate reduces the length of the translation output
        /// for most translations (when compared with the same translation with brevity turned
        /// off). By default, brevity is turned off.</para><para>If you turn on brevity for a translation request with an unsupported language pair,
        /// the translation proceeds with the brevity setting turned off.</para><para>For the language pairs that brevity supports, see <a href="https://docs.aws.amazon.com/translate/latest/dg/customizing-translations-brevity">Using
        /// brevity</a> in the Amazon Translate Developer Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Translate.Brevity")]
        public Amazon.Translate.Brevity Settings_Brevity { get; set; }
        #endregion
        
        #region Parameter Document_Content
        /// <summary>
        /// <para>
        /// <para>The <c>Content</c>field type is Binary large object (blob). This object contains the
        /// document content converted into base64-encoded binary data. If you use one of the
        /// AWS SDKs, the SDK performs the Base64-encoding on this field before sending the request.
        /// </para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Document_Content { get; set; }
        #endregion
        
        #region Parameter Document_ContentType
        /// <summary>
        /// <para>
        /// <para>Describes the format of the document. You can specify one of the following:</para><ul><li><para><c>text/html</c> - The input data consists of HTML content. Amazon Translate translates
        /// only the text in the HTML element.</para></li><li><para><c>text/plain</c> - The input data consists of unformatted text. Amazon Translate
        /// translates every character in the content. </para></li><li><para><c>application/vnd.openxmlformats-officedocument.wordprocessingml.document</c> -
        /// The input data consists of a Word document (.docx).</para></li></ul>
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
        public System.String Document_ContentType { get; set; }
        #endregion
        
        #region Parameter Settings_Formality
        /// <summary>
        /// <para>
        /// <para>You can specify the desired level of formality for translations to supported target
        /// languages. The formality setting controls the level of formal language usage (also
        /// known as <a href="https://en.wikipedia.org/wiki/Register_(sociolinguistics)">register</a>)
        /// in the translation output. You can set the value to informal or formal. If you don't
        /// specify a value for formality, or if the target language doesn't support formality,
        /// the translation will ignore the formality setting.</para><para> If you specify multiple target languages for the job, translate ignores the formality
        /// setting for any unsupported target language.</para><para>For a list of target languages that support formality, see <a href="https://docs.aws.amazon.com/translate/latest/dg/customizing-translations-formality.html#customizing-translations-formality-languages">Supported
        /// languages</a> in the Amazon Translate Developer Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Translate.Formality")]
        public Amazon.Translate.Formality Settings_Formality { get; set; }
        #endregion
        
        #region Parameter Settings_Profanity
        /// <summary>
        /// <para>
        /// <para>You can enable the profanity setting if you want to mask profane words and phrases
        /// in your translation output.</para><para>To mask profane words and phrases, Amazon Translate replaces them with the grawlix
        /// string “?$#@$“. This 5-character sequence is used for each profane word or phrase,
        /// regardless of the length or number of words.</para><para>Amazon Translate doesn't detect profanity in all of its supported languages. For languages
        /// that don't support profanity detection, see <a href="https://docs.aws.amazon.com/translate/latest/dg/customizing-translations-profanity.html#customizing-translations-profanity-languages">Unsupported
        /// languages</a> in the Amazon Translate Developer Guide.</para><para>If you specify multiple target languages for the job, all the target languages must
        /// support profanity masking. If any of the target languages don't support profanity
        /// masking, the translation job won't mask profanity for any target language.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Translate.Profanity")]
        public Amazon.Translate.Profanity Settings_Profanity { get; set; }
        #endregion
        
        #region Parameter SourceLanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code for the language of the source text. For a list of supported language
        /// codes, see <a href="https://docs.aws.amazon.com/translate/latest/dg/what-is-languages.html">Supported
        /// languages</a>.</para><para>To have Amazon Translate determine the source language of your text, you can specify
        /// <c>auto</c> in the <c>SourceLanguageCode</c> field. If you specify <c>auto</c>, Amazon
        /// Translate will call <a href="https://docs.aws.amazon.com/comprehend/latest/dg/comprehend-general.html">Amazon
        /// Comprehend</a> to determine the source language.</para><note><para>If you specify <c>auto</c>, you must send the <c>TranslateDocument</c> request in
        /// a region that supports Amazon Comprehend. Otherwise, the request returns an error
        /// indicating that autodetect is not supported. </para></note>
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
        public System.String SourceLanguageCode { get; set; }
        #endregion
        
        #region Parameter TargetLanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code requested for the translated document. For a list of supported language
        /// codes, see <a href="https://docs.aws.amazon.com/translate/latest/dg/what-is-languages.html">Supported
        /// languages</a>.</para>
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
        public System.String TargetLanguageCode { get; set; }
        #endregion
        
        #region Parameter TerminologyName
        /// <summary>
        /// <para>
        /// <para>The name of a terminology list file to add to the translation job. This file provides
        /// source terms and the desired translation for each term. A terminology list can contain
        /// a maximum of 256 terms. You can use one custom terminology resource in your translation
        /// request.</para><para>Use the <a>ListTerminologies</a> operation to get the available terminology lists.</para><para>For more information about custom terminology lists, see <a href="https://docs.aws.amazon.com/translate/latest/dg/how-custom-terminology.html">Custom
        /// terminology</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TerminologyNames")]
        public System.String[] TerminologyName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Translate.Model.TranslateDocumentResponse).
        /// Specifying the name of a property of type Amazon.Translate.Model.TranslateDocumentResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetLanguageCode), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "ConvertTo-TRNDocument (TranslateDocument)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Translate.Model.TranslateDocumentResponse, ConvertToTRNDocumentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Document_Content = this.Document_Content;
            #if MODULAR
            if (this.Document_Content == null && ParameterWasBound(nameof(this.Document_Content)))
            {
                WriteWarning("You are passing $null as a value for parameter Document_Content which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Document_ContentType = this.Document_ContentType;
            #if MODULAR
            if (this.Document_ContentType == null && ParameterWasBound(nameof(this.Document_ContentType)))
            {
                WriteWarning("You are passing $null as a value for parameter Document_ContentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Settings_Brevity = this.Settings_Brevity;
            context.Settings_Formality = this.Settings_Formality;
            context.Settings_Profanity = this.Settings_Profanity;
            context.SourceLanguageCode = this.SourceLanguageCode;
            #if MODULAR
            if (this.SourceLanguageCode == null && ParameterWasBound(nameof(this.SourceLanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceLanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetLanguageCode = this.TargetLanguageCode;
            #if MODULAR
            if (this.TargetLanguageCode == null && ParameterWasBound(nameof(this.TargetLanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetLanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TerminologyName != null)
            {
                context.TerminologyName = new List<System.String>(this.TerminologyName);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Document_ContentStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Translate.Model.TranslateDocumentRequest();
                
                
                 // populate Document
                var requestDocumentIsNull = true;
                request.Document = new Amazon.Translate.Model.Document();
                System.IO.MemoryStream requestDocument_document_Content = null;
                if (cmdletContext.Document_Content != null)
                {
                    _Document_ContentStream = new System.IO.MemoryStream(cmdletContext.Document_Content);
                    requestDocument_document_Content = _Document_ContentStream;
                }
                if (requestDocument_document_Content != null)
                {
                    request.Document.Content = requestDocument_document_Content;
                    requestDocumentIsNull = false;
                }
                System.String requestDocument_document_ContentType = null;
                if (cmdletContext.Document_ContentType != null)
                {
                    requestDocument_document_ContentType = cmdletContext.Document_ContentType;
                }
                if (requestDocument_document_ContentType != null)
                {
                    request.Document.ContentType = requestDocument_document_ContentType;
                    requestDocumentIsNull = false;
                }
                 // determine if request.Document should be set to null
                if (requestDocumentIsNull)
                {
                    request.Document = null;
                }
                
                 // populate Settings
                var requestSettingsIsNull = true;
                request.Settings = new Amazon.Translate.Model.TranslationSettings();
                Amazon.Translate.Brevity requestSettings_settings_Brevity = null;
                if (cmdletContext.Settings_Brevity != null)
                {
                    requestSettings_settings_Brevity = cmdletContext.Settings_Brevity;
                }
                if (requestSettings_settings_Brevity != null)
                {
                    request.Settings.Brevity = requestSettings_settings_Brevity;
                    requestSettingsIsNull = false;
                }
                Amazon.Translate.Formality requestSettings_settings_Formality = null;
                if (cmdletContext.Settings_Formality != null)
                {
                    requestSettings_settings_Formality = cmdletContext.Settings_Formality;
                }
                if (requestSettings_settings_Formality != null)
                {
                    request.Settings.Formality = requestSettings_settings_Formality;
                    requestSettingsIsNull = false;
                }
                Amazon.Translate.Profanity requestSettings_settings_Profanity = null;
                if (cmdletContext.Settings_Profanity != null)
                {
                    requestSettings_settings_Profanity = cmdletContext.Settings_Profanity;
                }
                if (requestSettings_settings_Profanity != null)
                {
                    request.Settings.Profanity = requestSettings_settings_Profanity;
                    requestSettingsIsNull = false;
                }
                 // determine if request.Settings should be set to null
                if (requestSettingsIsNull)
                {
                    request.Settings = null;
                }
                if (cmdletContext.SourceLanguageCode != null)
                {
                    request.SourceLanguageCode = cmdletContext.SourceLanguageCode;
                }
                if (cmdletContext.TargetLanguageCode != null)
                {
                    request.TargetLanguageCode = cmdletContext.TargetLanguageCode;
                }
                if (cmdletContext.TerminologyName != null)
                {
                    request.TerminologyNames = cmdletContext.TerminologyName;
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
            finally
            {
                if( _Document_ContentStream != null)
                {
                    _Document_ContentStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Translate.Model.TranslateDocumentResponse CallAWSServiceOperation(IAmazonTranslate client, Amazon.Translate.Model.TranslateDocumentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Translate", "TranslateDocument");
            try
            {
                return client.TranslateDocumentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public byte[] Document_Content { get; set; }
            public System.String Document_ContentType { get; set; }
            public Amazon.Translate.Brevity Settings_Brevity { get; set; }
            public Amazon.Translate.Formality Settings_Formality { get; set; }
            public Amazon.Translate.Profanity Settings_Profanity { get; set; }
            public System.String SourceLanguageCode { get; set; }
            public System.String TargetLanguageCode { get; set; }
            public List<System.String> TerminologyName { get; set; }
            public System.Func<Amazon.Translate.Model.TranslateDocumentResponse, ConvertToTRNDocumentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
