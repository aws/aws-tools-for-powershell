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
    /// Translates input text from the source language to the target language. It is not necessary
    /// to use English (en) as either the source or the target language but not all language
    /// combinations are supported by Amazon Translate. For more information, see <a href="http://docs.aws.amazon.com/translate/latest/dg/pairs.html">Supported
    /// Language Pairs</a>.
    /// 
    ///  <ul><li><para>
    /// Arabic (ar)
    /// </para></li><li><para>
    /// Chinese (Simplified) (zh)
    /// </para></li><li><para>
    /// Chinese (Traditional) (zh-TW)
    /// </para></li><li><para>
    /// Czech (cs)
    /// </para></li><li><para>
    /// Danish (da)
    /// </para></li><li><para>
    /// Dutch (nl)
    /// </para></li><li><para>
    /// English (en)
    /// </para></li><li><para>
    /// Finnish (fi)
    /// </para></li><li><para>
    /// French (fr)
    /// </para></li><li><para>
    /// German (de)
    /// </para></li><li><para>
    /// Hebrew (he)
    /// </para></li><li><para>
    /// Indonesian (id)
    /// </para></li><li><para>
    /// Italian (it)
    /// </para></li><li><para>
    /// Japanese (ja)
    /// </para></li><li><para>
    /// Korean (ko)
    /// </para></li><li><para>
    /// Polish (pl)
    /// </para></li><li><para>
    /// Portuguese (pt)
    /// </para></li><li><para>
    /// Russian (ru)
    /// </para></li><li><para>
    /// Spanish (es)
    /// </para></li><li><para>
    /// Swedish (sv)
    /// </para></li><li><para>
    /// Turkish (tr)
    /// </para></li></ul><para>
    /// To have Amazon Translate determine the source language of your text, you can specify
    /// <code>auto</code> in the <code>SourceLanguageCode</code> field. If you specify <code>auto</code>,
    /// Amazon Translate will call Amazon Comprehend to determine the source language.
    /// </para>
    /// </summary>
    [Cmdlet("ConvertTo", "TRNTargetLanguage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Translate.Model.TranslateTextResponse")]
    [AWSCmdlet("Calls the Amazon Translate TranslateText API operation.", Operation = new[] {"TranslateText"}, SelectReturnType = typeof(Amazon.Translate.Model.TranslateTextResponse))]
    [AWSCmdletOutput("Amazon.Translate.Model.TranslateTextResponse",
        "This cmdlet returns an Amazon.Translate.Model.TranslateTextResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ConvertToTRNTargetLanguageCmdlet : AmazonTranslateClientCmdlet, IExecutor
    {
        
        #region Parameter SourceLanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code for the language of the source text. The language must be a language
        /// supported by Amazon Translate. </para><para>To have Amazon Translate determine the source language of your text, you can specify
        /// <code>auto</code> in the <code>SourceLanguageCode</code> field. If you specify <code>auto</code>,
        /// Amazon Translate will call Amazon Comprehend to determine the source language.</para>
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
        /// <para>The language code requested for the language of the target text. The language must
        /// be a language supported by Amazon Translate.</para>
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
        /// <para>The TerminologyNames list that is taken as input to the TranslateText request. This
        /// has a minimum length of 0 and a maximum length of 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TerminologyNames")]
        public System.String[] TerminologyName { get; set; }
        #endregion
        
        #region Parameter Text
        /// <summary>
        /// <para>
        /// <para>The text to translate. The text string can be a maximum of 5,000 bytes long. Depending
        /// on your character set, this may be fewer than 5,000 characters.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Text parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Text' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Text' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetLanguageCode), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "ConvertTo-TRNTargetLanguage (TranslateText)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Translate.Model.TranslateTextResponse, ConvertToTRNTargetLanguageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Text;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            public System.String SourceLanguageCode { get; set; }
            public System.String TargetLanguageCode { get; set; }
            public List<System.String> TerminologyName { get; set; }
            public System.String Text { get; set; }
            public System.Func<Amazon.Translate.Model.TranslateTextResponse, ConvertToTRNTargetLanguageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
