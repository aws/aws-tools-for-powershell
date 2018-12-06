/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the Amazon Translate TranslateText API operation.", Operation = new[] {"TranslateText"})]
    [AWSCmdletOutput("Amazon.Translate.Model.TranslateTextResponse",
        "This cmdlet returns a Amazon.Translate.Model.TranslateTextResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
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
        [System.Management.Automation.Parameter]
        public System.String SourceLanguageCode { get; set; }
        #endregion
        
        #region Parameter TargetLanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code requested for the language of the target text. The language must
        /// be a language supported by Amazon Translate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetLanguageCode { get; set; }
        #endregion
        
        #region Parameter TerminologyName
        /// <summary>
        /// <para>
        /// <para>The TerminologyNames list that is taken as input to the TranslateText request. This
        /// has a minimum length of 0 and a maximum length of 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Text { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TargetLanguageCode", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "ConvertTo-TRNTargetLanguage (TranslateText)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.SourceLanguageCode = this.SourceLanguageCode;
            context.TargetLanguageCode = this.TargetLanguageCode;
            if (this.TerminologyName != null)
            {
                context.TerminologyNames = new List<System.String>(this.TerminologyName);
            }
            context.Text = this.Text;
            
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
            if (cmdletContext.TerminologyNames != null)
            {
                request.TerminologyNames = cmdletContext.TerminologyNames;
            }
            if (cmdletContext.Text != null)
            {
                request.Text = cmdletContext.Text;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.TranslateTextAsync(request);
                return task.Result;
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
            public List<System.String> TerminologyNames { get; set; }
            public System.String Text { get; set; }
        }
        
    }
}
