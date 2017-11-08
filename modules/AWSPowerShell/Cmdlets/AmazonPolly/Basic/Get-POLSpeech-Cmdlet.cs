/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// mapping is used. For more information, see <a href="http://docs.aws.amazon.com/polly/latest/dg/how-text-to-speech-works.html">How
    /// it Works</a>.
    /// </summary>
    [Cmdlet("Get", "POLSpeech")]
    [OutputType("Amazon.Polly.Model.SynthesizeSpeechResponse")]
    [AWSCmdlet("Calls the Amazon Polly SynthesizeSpeech API operation.", Operation = new[] {"SynthesizeSpeech"})]
    [AWSCmdletOutput("Amazon.Polly.Model.SynthesizeSpeechResponse",
        "This cmdlet returns a Amazon.Polly.Model.SynthesizeSpeechResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPOLSpeechCmdlet : AmazonPollyClientCmdlet, IExecutor
    {
        
        #region Parameter LexiconName
        /// <summary>
        /// <para>
        /// <para>List of one or more pronunciation lexicon names you want the service to apply during
        /// synthesis. Lexicons are applied only if the language of the lexicon is the same as
        /// the language of the voice. For information about storing lexicons, see <a href="http://docs.aws.amazon.com/polly/latest/dg/API_PutLexicon.html">PutLexicon</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LexiconNames")]
        public System.String[] LexiconName { get; set; }
        #endregion
        
        #region Parameter OutputFormat
        /// <summary>
        /// <para>
        /// <para> The format in which the returned output will be encoded. For audio stream, this will
        /// be mp3, ogg_vorbis, or pcm. For speech marks, this will be json. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Polly.OutputFormat")]
        public Amazon.Polly.OutputFormat OutputFormat { get; set; }
        #endregion
        
        #region Parameter SampleRate
        /// <summary>
        /// <para>
        /// <para> The audio frequency specified in Hz. </para><para>The valid values for <code>mp3</code> and <code>ogg_vorbis</code> are "8000", "16000",
        /// and "22050". The default value is "22050". </para><para> Valid values for <code>pcm</code> are "8000" and "16000" The default value is "16000".
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SampleRate { get; set; }
        #endregion
        
        #region Parameter SpeechMarkType
        /// <summary>
        /// <para>
        /// <para>The type of speech marks returned for the input text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Text { get; set; }
        #endregion
        
        #region Parameter TextType
        /// <summary>
        /// <para>
        /// <para> Specifies whether the input text is plain text or SSML. The default value is plain
        /// text. For more information, see <a href="http://docs.aws.amazon.com/polly/latest/dg/ssml.html">Using
        /// SSML</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Polly.TextType")]
        public Amazon.Polly.TextType TextType { get; set; }
        #endregion
        
        #region Parameter VoiceId
        /// <summary>
        /// <para>
        /// <para> Voice ID to use for the synthesis. You can get a list of available voice IDs by calling
        /// the <a href="http://docs.aws.amazon.com/polly/latest/dg/API_DescribeVoices.html">DescribeVoices</a>
        /// operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Polly.VoiceId")]
        public Amazon.Polly.VoiceId VoiceId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.LexiconName != null)
            {
                context.LexiconNames = new List<System.String>(this.LexiconName);
            }
            context.OutputFormat = this.OutputFormat;
            context.SampleRate = this.SampleRate;
            if (this.SpeechMarkType != null)
            {
                context.SpeechMarkTypes = new List<System.String>(this.SpeechMarkType);
            }
            context.Text = this.Text;
            context.TextType = this.TextType;
            context.VoiceId = this.VoiceId;
            
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
            
            if (cmdletContext.LexiconNames != null)
            {
                request.LexiconNames = cmdletContext.LexiconNames;
            }
            if (cmdletContext.OutputFormat != null)
            {
                request.OutputFormat = cmdletContext.OutputFormat;
            }
            if (cmdletContext.SampleRate != null)
            {
                request.SampleRate = cmdletContext.SampleRate;
            }
            if (cmdletContext.SpeechMarkTypes != null)
            {
                request.SpeechMarkTypes = cmdletContext.SpeechMarkTypes;
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
        
        private Amazon.Polly.Model.SynthesizeSpeechResponse CallAWSServiceOperation(IAmazonPolly client, Amazon.Polly.Model.SynthesizeSpeechRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Polly", "SynthesizeSpeech");
            try
            {
                #if DESKTOP
                return client.SynthesizeSpeech(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SynthesizeSpeechAsync(request);
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
            public List<System.String> LexiconNames { get; set; }
            public Amazon.Polly.OutputFormat OutputFormat { get; set; }
            public System.String SampleRate { get; set; }
            public List<System.String> SpeechMarkTypes { get; set; }
            public System.String Text { get; set; }
            public Amazon.Polly.TextType TextType { get; set; }
            public Amazon.Polly.VoiceId VoiceId { get; set; }
        }
        
    }
}
