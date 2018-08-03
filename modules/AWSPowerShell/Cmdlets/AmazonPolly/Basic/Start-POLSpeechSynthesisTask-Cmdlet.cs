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
using Amazon.Polly;
using Amazon.Polly.Model;

namespace Amazon.PowerShell.Cmdlets.POL
{
    /// <summary>
    /// Allows the creation of an asynchronous synthesis task, by starting a new <code>SpeechSynthesisTask</code>.
    /// This operation requires all the standard information needed for speech synthesis,
    /// plus the name of an Amazon S3 bucket for the service to store the output of the synthesis
    /// task and two optional parameters (OutputS3KeyPrefix and SnsTopicArn). Once the synthesis
    /// task is created, this operation will return a SpeechSynthesisTask object, which will
    /// include an identifier of this task as well as the current status.
    /// </summary>
    [Cmdlet("Start", "POLSpeechSynthesisTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Polly.Model.SynthesisTask")]
    [AWSCmdlet("Calls the Amazon Polly StartSpeechSynthesisTask API operation.", Operation = new[] {"StartSpeechSynthesisTask"})]
    [AWSCmdletOutput("Amazon.Polly.Model.SynthesisTask",
        "This cmdlet returns a SynthesisTask object.",
        "The service call response (type Amazon.Polly.Model.StartSpeechSynthesisTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartPOLSpeechSynthesisTaskCmdlet : AmazonPollyClientCmdlet, IExecutor
    {
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>Optional language code for the Speech Synthesis request. This is only necessary if
        /// using a bilingual voice, such as Aditi, which can be used for either Indian English
        /// (en-IN) or Hindi (hi-IN). </para><para>If a bilingual voice is used and no language code is specified, Amazon Polly will
        /// use the default language of the bilingual voice. The default language for any voice
        /// is the one returned by the <a href="https://docs.aws.amazon.com/polly/latest/dg/API_DescribeVoices.html">DescribeVoices</a>
        /// operation for the <code>LanguageCode</code> parameter. For example, if no language
        /// code is specified, Aditi will use Indian English rather than Hindi.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Polly.LanguageCode")]
        public Amazon.Polly.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter LexiconName
        /// <summary>
        /// <para>
        /// <para>List of one or more pronunciation lexicon names you want the service to apply during
        /// synthesis. Lexicons are applied only if the language of the lexicon is the same as
        /// the language of the voice. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LexiconNames")]
        public System.String[] LexiconName { get; set; }
        #endregion
        
        #region Parameter OutputFormat
        /// <summary>
        /// <para>
        /// <para>The format in which the returned output will be encoded. For audio stream, this will
        /// be mp3, ogg_vorbis, or pcm. For speech marks, this will be json. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Polly.OutputFormat")]
        public Amazon.Polly.OutputFormat OutputFormat { get; set; }
        #endregion
        
        #region Parameter OutputS3BucketName
        /// <summary>
        /// <para>
        /// <para>Amazon S3 bucket name to which the output file will be saved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OutputS3BucketName { get; set; }
        #endregion
        
        #region Parameter OutputS3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 key prefix for the output speech file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OutputS3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter SampleRate
        /// <summary>
        /// <para>
        /// <para>The audio frequency specified in Hz.</para><para>The valid values for mp3 and ogg_vorbis are "8000", "16000", and "22050". The default
        /// value is "22050".</para><para>Valid values for pcm are "8000" and "16000" The default value is "16000". </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SampleRate { get; set; }
        #endregion
        
        #region Parameter SnsTopicArn
        /// <summary>
        /// <para>
        /// <para>ARN for the SNS topic optionally used for providing status notification for a speech
        /// synthesis task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SnsTopicArn { get; set; }
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
        /// <para>The input text to synthesize. If you specify ssml as the TextType, follow the SSML
        /// format for the input text. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Text { get; set; }
        #endregion
        
        #region Parameter TextType
        /// <summary>
        /// <para>
        /// <para>Specifies whether the input text is plain text or SSML. The default value is plain
        /// text. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Polly.TextType")]
        public Amazon.Polly.TextType TextType { get; set; }
        #endregion
        
        #region Parameter VoiceId
        /// <summary>
        /// <para>
        /// <para>Voice ID to use for the synthesis. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Polly.VoiceId")]
        public Amazon.Polly.VoiceId VoiceId { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-POLSpeechSynthesisTask (StartSpeechSynthesisTask)"))
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
            
            context.LanguageCode = this.LanguageCode;
            if (this.LexiconName != null)
            {
                context.LexiconNames = new List<System.String>(this.LexiconName);
            }
            context.OutputFormat = this.OutputFormat;
            context.OutputS3BucketName = this.OutputS3BucketName;
            context.OutputS3KeyPrefix = this.OutputS3KeyPrefix;
            context.SampleRate = this.SampleRate;
            context.SnsTopicArn = this.SnsTopicArn;
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
            var request = new Amazon.Polly.Model.StartSpeechSynthesisTaskRequest();
            
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.LexiconNames != null)
            {
                request.LexiconNames = cmdletContext.LexiconNames;
            }
            if (cmdletContext.OutputFormat != null)
            {
                request.OutputFormat = cmdletContext.OutputFormat;
            }
            if (cmdletContext.OutputS3BucketName != null)
            {
                request.OutputS3BucketName = cmdletContext.OutputS3BucketName;
            }
            if (cmdletContext.OutputS3KeyPrefix != null)
            {
                request.OutputS3KeyPrefix = cmdletContext.OutputS3KeyPrefix;
            }
            if (cmdletContext.SampleRate != null)
            {
                request.SampleRate = cmdletContext.SampleRate;
            }
            if (cmdletContext.SnsTopicArn != null)
            {
                request.SnsTopicArn = cmdletContext.SnsTopicArn;
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
                object pipelineOutput = response.SynthesisTask;
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
        
        private Amazon.Polly.Model.StartSpeechSynthesisTaskResponse CallAWSServiceOperation(IAmazonPolly client, Amazon.Polly.Model.StartSpeechSynthesisTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Polly", "StartSpeechSynthesisTask");
            try
            {
                #if DESKTOP
                return client.StartSpeechSynthesisTask(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StartSpeechSynthesisTaskAsync(request);
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
            public Amazon.Polly.LanguageCode LanguageCode { get; set; }
            public List<System.String> LexiconNames { get; set; }
            public Amazon.Polly.OutputFormat OutputFormat { get; set; }
            public System.String OutputS3BucketName { get; set; }
            public System.String OutputS3KeyPrefix { get; set; }
            public System.String SampleRate { get; set; }
            public System.String SnsTopicArn { get; set; }
            public List<System.String> SpeechMarkTypes { get; set; }
            public System.String Text { get; set; }
            public Amazon.Polly.TextType TextType { get; set; }
            public Amazon.Polly.VoiceId VoiceId { get; set; }
        }
        
    }
}
