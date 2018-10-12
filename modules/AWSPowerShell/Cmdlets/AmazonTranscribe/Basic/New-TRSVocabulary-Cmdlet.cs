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
    /// Creates a new custom vocabulary that you can use to change the way Amazon Transcribe
    /// handles transcription of an audio file. Note that vocabularies for en-AU, en-UK, and
    /// fr-CA languages that are in preview are not available. In the console, the vocabulary
    /// section will be greyed-out and SDK will return error message.
    /// </summary>
    [Cmdlet("New", "TRSVocabulary", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.CreateVocabularyResponse")]
    [AWSCmdlet("Calls the Amazon Transcribe Service CreateVocabulary API operation.", Operation = new[] {"CreateVocabulary"})]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.CreateVocabularyResponse",
        "This cmdlet returns a Amazon.TranscribeService.Model.CreateVocabularyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewTRSVocabularyCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code of the vocabulary entries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.TranscribeService.LanguageCode")]
        public Amazon.TranscribeService.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter Phras
        /// <summary>
        /// <para>
        /// <para>An array of strings that contains the vocabulary entries. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Phrases")]
        public System.String[] Phras { get; set; }
        #endregion
        
        #region Parameter VocabularyName
        /// <summary>
        /// <para>
        /// <para>The name of the vocabulary. The name must be unique within an AWS account. The name
        /// is case-sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VocabularyName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VocabularyName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TRSVocabulary (CreateVocabulary)"))
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
            if (this.Phras != null)
            {
                context.Phrases = new List<System.String>(this.Phras);
            }
            context.VocabularyName = this.VocabularyName;
            
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
            var request = new Amazon.TranscribeService.Model.CreateVocabularyRequest();
            
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.Phrases != null)
            {
                request.Phrases = cmdletContext.Phrases;
            }
            if (cmdletContext.VocabularyName != null)
            {
                request.VocabularyName = cmdletContext.VocabularyName;
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
        
        private Amazon.TranscribeService.Model.CreateVocabularyResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.CreateVocabularyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "CreateVocabulary");
            try
            {
                #if DESKTOP
                return client.CreateVocabulary(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateVocabularyAsync(request);
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
            public List<System.String> Phrases { get; set; }
            public System.String VocabularyName { get; set; }
        }
        
    }
}
