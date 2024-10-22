/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Translate;
using Amazon.Translate.Model;

namespace Amazon.PowerShell.Cmdlets.TRN
{
    /// <summary>
    /// Translates input text from the source language to the target language. For a list
    /// of available languages and language codes, see <a href="https://docs.aws.amazon.com/translate/latest/dg/what-is-languages.html">Supported
    /// languages</a>.
    /// </summary>
    [Cmdlet("ConvertTo", "TRNTargetLanguage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Translate.Model.TranslateTextResponse")]
    [AWSCmdlet("Calls the Amazon Translate TranslateText API operation.", Operation = new[] {"TranslateText"}, SelectReturnType = typeof(Amazon.Translate.Model.TranslateTextResponse))]
    [AWSCmdletOutput("Amazon.Translate.Model.TranslateTextResponse",
        "This cmdlet returns an Amazon.Translate.Model.TranslateTextResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ConvertToTRNTargetLanguageCmdlet : AmazonTranslateClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// <para>The language code for the language of the source text. For a list of language codes,
        /// see <a href="https://docs.aws.amazon.com/translate/latest/dg/what-is-languages.html">Supported
        /// languages</a>.</para><para>To have Amazon Translate determine the source language of your text, you can specify
        /// <c>auto</c> in the <c>SourceLanguageCode</c> field. If you specify <c>auto</c>, Amazon
        /// Translate will call <a href="https://docs.aws.amazon.com/comprehend/latest/dg/comprehend-general.html">Amazon
        /// Comprehend</a> to determine the source language.</para><note><para>If you specify <c>auto</c>, you must send the <c>TranslateText</c> request in a region
        /// that supports Amazon Comprehend. Otherwise, the request returns an error indicating
        /// that autodetect is not supported. </para></note>
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
        /// <para>The language code requested for the language of the target text. For a list of language
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
        
        #region Parameter Text
        /// <summary>
        /// <para>
        /// <para>The text to translate. The text string can be a maximum of 10,000 bytes long. Depending
        /// on your character set, this may be fewer than 10,000 characters.</para>
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
        public System.String Text { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Translate.Model.TranslateTextResponse).
        /// Specifying the name of a property of type Amazon.Translate.Model.TranslateTextResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetLanguageCode), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "ConvertTo-TRNTargetLanguage (TranslateText)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Translate.Model.TranslateTextResponse, ConvertToTRNTargetLanguageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.Text = this.Text;
            #if MODULAR
            if (this.Text == null && ParameterWasBound(nameof(this.Text)))
            {
                WriteWarning("You are passing $null as a value for parameter Text which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Translate.Model.TranslateTextRequest();
            
            
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
            if (cmdletContext.Text != null)
            {
                request.Text = cmdletContext.Text;
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
        
        private Amazon.Translate.Model.TranslateTextResponse CallAWSServiceOperation(IAmazonTranslate client, Amazon.Translate.Model.TranslateTextRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Translate", "TranslateText");
            try
            {
                #if DESKTOP
                return client.TranslateText(request);
                #elif CORECLR
                return client.TranslateTextAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public Amazon.Translate.Brevity Settings_Brevity { get; set; }
            public Amazon.Translate.Formality Settings_Formality { get; set; }
            public Amazon.Translate.Profanity Settings_Profanity { get; set; }
            public System.String SourceLanguageCode { get; set; }
            public System.String TargetLanguageCode { get; set; }
            public List<System.String> TerminologyName { get; set; }
            public System.String Text { get; set; }
            public System.Func<Amazon.Translate.Model.TranslateTextResponse, ConvertToTRNTargetLanguageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
