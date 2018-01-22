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
using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;

namespace Amazon.PowerShell.Cmdlets.TRS
{
    /// <summary>
    /// Starts an asynchronous job to transcribe speech to text.
    /// </summary>
    [Cmdlet("Start", "TRSTranscriptionJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.TranscriptionJob")]
    [AWSCmdlet("Calls the Amazon Transcribe Service StartTranscriptionJob API operation.", Operation = new[] {"StartTranscriptionJob"})]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.TranscriptionJob",
        "This cmdlet returns a TranscriptionJob object.",
        "The service call response (type Amazon.TranscribeService.Model.StartTranscriptionJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartTRSTranscriptionJobCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code for the language used in the input media file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.TranscribeService.LanguageCode")]
        public Amazon.TranscribeService.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter Media_MediaFileUri
        /// <summary>
        /// <para>
        /// <para>The S3 location of the input media file. The general form is:</para><para><code> https://&lt;aws-region&gt;.amazonaws.com/&lt;bucket-name&gt;/&lt;keyprefix&gt;/&lt;objectkey&gt;
        /// </code></para><para>For example:</para><para><code>https://s3-us-west-2.amazonaws.com/examplebucket/example.mp4</code></para><para><code>https://s3-us-west-2.amazonaws.com/examplebucket/mediadocs/example.mp4</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Media_MediaFileUri { get; set; }
        #endregion
        
        #region Parameter MediaFormat
        /// <summary>
        /// <para>
        /// <para>The format of the input media file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.TranscribeService.MediaFormat")]
        public Amazon.TranscribeService.MediaFormat MediaFormat { get; set; }
        #endregion
        
        #region Parameter MediaSampleRateHertz
        /// <summary>
        /// <para>
        /// <para>The sample rate, in Hertz, of the audio track in the input media file. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MediaSampleRateHertz { get; set; }
        #endregion
        
        #region Parameter TranscriptionJobName
        /// <summary>
        /// <para>
        /// <para>The name of the job. The name must be unique within an AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TranscriptionJobName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TranscriptionJobName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-TRSTranscriptionJob (StartTranscriptionJob)"))
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
            context.Media_MediaFileUri = this.Media_MediaFileUri;
            context.MediaFormat = this.MediaFormat;
            if (ParameterWasBound("MediaSampleRateHertz"))
                context.MediaSampleRateHertz = this.MediaSampleRateHertz;
            context.TranscriptionJobName = this.TranscriptionJobName;
            
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
            var request = new Amazon.TranscribeService.Model.StartTranscriptionJobRequest();
            
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            
             // populate Media
            bool requestMediaIsNull = true;
            request.Media = new Amazon.TranscribeService.Model.Media();
            System.String requestMedia_media_MediaFileUri = null;
            if (cmdletContext.Media_MediaFileUri != null)
            {
                requestMedia_media_MediaFileUri = cmdletContext.Media_MediaFileUri;
            }
            if (requestMedia_media_MediaFileUri != null)
            {
                request.Media.MediaFileUri = requestMedia_media_MediaFileUri;
                requestMediaIsNull = false;
            }
             // determine if request.Media should be set to null
            if (requestMediaIsNull)
            {
                request.Media = null;
            }
            if (cmdletContext.MediaFormat != null)
            {
                request.MediaFormat = cmdletContext.MediaFormat;
            }
            if (cmdletContext.MediaSampleRateHertz != null)
            {
                request.MediaSampleRateHertz = cmdletContext.MediaSampleRateHertz.Value;
            }
            if (cmdletContext.TranscriptionJobName != null)
            {
                request.TranscriptionJobName = cmdletContext.TranscriptionJobName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TranscriptionJob;
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
        
        private Amazon.TranscribeService.Model.StartTranscriptionJobResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.StartTranscriptionJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "StartTranscriptionJob");
            try
            {
                #if DESKTOP
                return client.StartTranscriptionJob(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StartTranscriptionJobAsync(request);
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
            public Amazon.TranscribeService.LanguageCode LanguageCode { get; set; }
            public System.String Media_MediaFileUri { get; set; }
            public Amazon.TranscribeService.MediaFormat MediaFormat { get; set; }
            public System.Int32? MediaSampleRateHertz { get; set; }
            public System.String TranscriptionJobName { get; set; }
        }
        
    }
}
