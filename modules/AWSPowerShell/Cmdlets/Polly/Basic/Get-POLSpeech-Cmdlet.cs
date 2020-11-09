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
using Amazon.Polly;
using Amazon.Polly.Model;

namespace Amazon.PowerShell.Cmdlets.POL
{
    /// <summary>
    /// Synthesizes UTF-8 input, plain text or SSML, to a stream of bytes. SSML input must
    /// be valid, well-formed SSML. Some alphabets might not be available with all the voices
    /// (for example, Cyrillic might not be read at all by English voices) unless phoneme
    /// mapping is used. For more information, see <a href="https://docs.aws.amazon.com/polly/latest/dg/how-text-to-speech-works.html">How
    /// it Works</a>.
    /// </summary>
    [Cmdlet("Get", "POLSpeech")]
    [OutputType("Amazon.Polly.Model.SynthesizeSpeechResponse")]
    [AWSCmdlet("Calls the Amazon Polly SynthesizeSpeech API operation.", Operation = new[] {"SynthesizeSpeech"}, SelectReturnType = typeof(Amazon.Polly.Model.SynthesizeSpeechResponse))]
    [AWSCmdletOutput("Amazon.Polly.Model.SynthesizeSpeechResponse",
        "This cmdlet returns an Amazon.Polly.Model.SynthesizeSpeechResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPOLSpeechCmdlet : AmazonPollyClientCmdlet, IExecutor
    {
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>Specifies the engine (<code>standard</code> or <code>neural</code>) for Amazon Polly
        /// to use when processing input text for speech synthesis. For information on Amazon
        /// Polly voices and which voices are available in standard-only, NTTS-only, and both
        /// standard and NTTS formats, see <a href="https://docs.aws.amazon.com/polly/latest/dg/voicelist.html">Available
        /// Voices</a>.</para><para><b>NTTS-only voices</b></para><para>When using NTTS-only voices such as Kevin (en-US), this parameter is required and
        /// must be set to <code>neural</code>. If the engine is not specified, or is set to <code>standard</code>,
        /// this will result in an error. </para><para>Type: String</para><para>Valid Values: <code>standard</code> | <code>neural</code></para><para>Required: Yes</para><para><b>Standard voices</b></para><para>For standard voices, this is not required; the engine parameter defaults to <code>standard</code>.
        /// If the engine is not specified, or is set to <code>standard</code> and an NTTS-only
        /// voice is selected, this will result in an error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Polly.Engine")]
        public Amazon.Polly.Engine Engine { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>Optional language code for the Synthesize Speech request. This is only necessary if
        /// using a bilingual voice, such as Aditi, which can be used for either Indian English
        /// (en-IN) or Hindi (hi-IN). </para><para>If a bilingual voice is used and no language code is specified, Amazon Polly will
        /// use the default language of the bilingual voice. The default language for any voice
        /// is the one returned by the <a href="https://docs.aws.amazon.com/polly/latest/dg/API_DescribeVoices.html">DescribeVoices</a>
        /// operation for the <code>LanguageCode</code> parameter. For example, if no language
        /// code is specified, Aditi will use Indian English rather than Hindi.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Polly.LanguageCode")]
        public Amazon.Polly.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter LexiconName
        /// <summary>
        /// <para>
        /// <para>List of one or more pronunciation lexicon names you want the service to apply during
        /// synthesis. Lexicons are applied only if the language of the lexicon is the same as
        /// the language of the voice. For information about storing lexicons, see <a href="https://docs.aws.amazon.com/polly/latest/dg/API_PutLexicon.html">PutLexicon</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LexiconNames")]
        public System.String[] LexiconName { get; set; }
        #endregion
        
        #region Parameter OutputFormat
        /// <summary>
        /// <para>
        /// <para> The format in which the returned output will be encoded. For audio stream, this will
        /// be mp3, ogg_vorbis, or pcm. For speech marks, this will be json. </para><para>When pcm is used, the content returned is audio/pcm in a signed 16-bit, 1 channel
        /// (mono), little-endian format. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Polly.OutputFormat")]
        public Amazon.Polly.OutputFormat OutputFormat { get; set; }
        #endregion
        
        #region Parameter SampleRate
        /// <summary>
        /// <para>
        /// <para>The audio frequency specified in Hz.</para><para>The valid values for mp3 and ogg_vorbis are "8000", "16000", "22050", and "24000".
        /// The default value for standard voices is "22050". The default value for neural voices
        /// is "24000".</para><para>Valid values for pcm are "8000" and "16000" The default value is "16000". </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SampleRate { get; set; }
        #endregion
        
        #region Parameter SpeechMarkType
        /// <summary>
        /// <para>
        /// <para>The type of speech marks returned for the input text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SpeechMarkTypes")]
        public System.String[] SpeechMarkType { get; set; }
        #endregion
        
        #region Parameter Text
        /// <summary>
        /// <para>
        /// <para> Input text to synthesize. If you specify <code>ssml</code> as the <code>TextType</code>,
        /// follow the SSML format for the input text. </para>
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
        
        #region Parameter TextType
        /// <summary>
        /// <para>
        /// <para> Specifies whether the input text is plain text or SSML. The default value is plain
        /// text. For more information, see <a href="https://docs.aws.amazon.com/polly/latest/dg/ssml.html">Using
        /// SSML</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Polly.TextType")]
        public Amazon.Polly.TextType TextType { get; set; }
        #endregion
        
        #region Parameter VoiceId
        /// <summary>
        /// <para>
        /// <para> Voice ID to use for the synthesis. You can get a list of available voice IDs by calling
        /// the <a href="https://docs.aws.amazon.com/polly/latest/dg/API_DescribeVoices.html">DescribeVoices</a>
        /// operation. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Polly.VoiceId")]
        public Amazon.Polly.VoiceId VoiceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Polly.Model.SynthesizeSpeechResponse).
        /// Specifying the name of a property of type Amazon.Polly.Model.SynthesizeSpeechResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Polly.Model.SynthesizeSpeechResponse, GetPOLSpeechCmdlet>(Select) ??
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
            context.Engine = this.Engine;
            context.LanguageCode = this.LanguageCode;
            if (this.LexiconName != null)
            {
                context.LexiconName = new List<System.String>(this.LexiconName);
            }
            context.OutputFormat = this.OutputFormat;
            #if MODULAR
            if (this.OutputFormat == null && ParameterWasBound(nameof(this.OutputFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SampleRate = this.SampleRate;
            if (this.SpeechMarkType != null)
            {
                context.SpeechMarkType = new List<System.String>(this.SpeechMarkType);
            }
            context.Text = this.Text;
            #if MODULAR
            if (this.Text == null && ParameterWasBound(nameof(this.Text)))
            {
                WriteWarning("You are passing $null as a value for parameter Text which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TextType = this.TextType;
            context.VoiceId = this.VoiceId;
            #if MODULAR
            if (this.VoiceId == null && ParameterWasBound(nameof(this.VoiceId)))
            {
                WriteWarning("You are passing $null as a value for parameter VoiceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Polly.Model.SynthesizeSpeechRequest();
            
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.LexiconName != null)
            {
                request.LexiconNames = cmdletContext.LexiconName;
            }
            if (cmdletContext.OutputFormat != null)
            {
                request.OutputFormat = cmdletContext.OutputFormat;
            }
            if (cmdletContext.SampleRate != null)
            {
                request.SampleRate = cmdletContext.SampleRate;
            }
            if (cmdletContext.SpeechMarkType != null)
            {
                request.SpeechMarkTypes = cmdletContext.SpeechMarkType;
            }
            if (cmdletContext.Text != null)
            {
                request.Text = cmdletContext.Text;
            }
            if (cmdletContext.TextType != null)
            {
                request.TextType = cmdletContext.TextType;
            }
            if (cmdletContext.VoiceId != null)
            {
                request.VoiceId = cmdletContext.VoiceId;
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
        
        private Amazon.Polly.Model.SynthesizeSpeechResponse CallAWSServiceOperation(IAmazonPolly client, Amazon.Polly.Model.SynthesizeSpeechRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Polly", "SynthesizeSpeech");
            try
            {
                #if DESKTOP
                return client.SynthesizeSpeech(request);
                #elif CORECLR
                return client.SynthesizeSpeechAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Polly.Engine Engine { get; set; }
            public Amazon.Polly.LanguageCode LanguageCode { get; set; }
            public List<System.String> LexiconName { get; set; }
            public Amazon.Polly.OutputFormat OutputFormat { get; set; }
            public System.String SampleRate { get; set; }
            public List<System.String> SpeechMarkType { get; set; }
            public System.String Text { get; set; }
            public Amazon.Polly.TextType TextType { get; set; }
            public Amazon.Polly.VoiceId VoiceId { get; set; }
            public System.Func<Amazon.Polly.Model.SynthesizeSpeechResponse, GetPOLSpeechCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
