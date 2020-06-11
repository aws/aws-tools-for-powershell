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
using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;

namespace Amazon.PowerShell.Cmdlets.TRS
{
    /// <summary>
    /// Creates a new custom vocabulary that you can use to change how Amazon Transcribe Medical
    /// transcribes your audio file.
    /// </summary>
    [Cmdlet("New", "TRSMedicalVocabulary", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.CreateMedicalVocabularyResponse")]
    [AWSCmdlet("Calls the Amazon Transcribe Service CreateMedicalVocabulary API operation.", Operation = new[] {"CreateMedicalVocabulary"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.CreateMedicalVocabularyResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.CreateMedicalVocabularyResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.CreateMedicalVocabularyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewTRSMedicalVocabularyCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code for the language used for the entries in your custom vocabulary.
        /// The language code of your custom vocabulary must match the language code of your transcription
        /// job. US English (en-US) is the only language code available for Amazon Transcribe
        /// Medical.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.TranscribeService.LanguageCode")]
        public Amazon.TranscribeService.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter VocabularyFileUri
        /// <summary>
        /// <para>
        /// <para>The location in Amazon S3 of the text file you use to define your custom vocabulary.
        /// The URI must be in the same AWS Region as the resource that you're calling. Enter
        /// information about your <code>VocabularyFileUri</code> in the following format:</para><para><code> https://s3.&lt;aws-region&gt;.amazonaws.com/&lt;bucket-name&gt;/&lt;keyprefix&gt;/&lt;objectkey&gt;
        /// </code></para><para>The following is an example URI for a vocabulary file that is stored in Amazon S3:</para><para><code>https://s3.us-east-1.amazonaws.com/AWSDOC-EXAMPLE-BUCKET/vocab.txt</code></para><para>For more information about Amazon S3 object names, see <a href="http://docs.aws.amazon.com/AmazonS3/latest/dev/UsingMetadata.html#object-keys">Object
        /// Keys</a> in the <i>Amazon S3 Developer Guide</i>.</para><para>For more information about custom vocabularies, see <a href="http://docs.aws.amazon.com/transcribe/latest/dg/how-it-works.html#how-vocabulary-med">Medical
        /// Custom Vocabularies</a>.</para>
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
        public System.String VocabularyFileUri { get; set; }
        #endregion
        
        #region Parameter VocabularyName
        /// <summary>
        /// <para>
        /// <para>The name of the custom vocabulary. This case-sensitive name must be unique within
        /// an AWS account. If you try to create a vocabulary with the same name as a previous
        /// vocabulary, you get a <code>ConflictException</code> error.</para>
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
        public System.String VocabularyName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TranscribeService.Model.CreateMedicalVocabularyResponse).
        /// Specifying the name of a property of type Amazon.TranscribeService.Model.CreateMedicalVocabularyResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VocabularyName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TRSMedicalVocabulary (CreateMedicalVocabulary)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.CreateMedicalVocabularyResponse, NewTRSMedicalVocabularyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LanguageCode = this.LanguageCode;
            #if MODULAR
            if (this.LanguageCode == null && ParameterWasBound(nameof(this.LanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter LanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VocabularyFileUri = this.VocabularyFileUri;
            #if MODULAR
            if (this.VocabularyFileUri == null && ParameterWasBound(nameof(this.VocabularyFileUri)))
            {
                WriteWarning("You are passing $null as a value for parameter VocabularyFileUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VocabularyName = this.VocabularyName;
            #if MODULAR
            if (this.VocabularyName == null && ParameterWasBound(nameof(this.VocabularyName)))
            {
                WriteWarning("You are passing $null as a value for parameter VocabularyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.TranscribeService.Model.CreateMedicalVocabularyRequest();
            
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.VocabularyFileUri != null)
            {
                request.VocabularyFileUri = cmdletContext.VocabularyFileUri;
            }
            if (cmdletContext.VocabularyName != null)
            {
                request.VocabularyName = cmdletContext.VocabularyName;
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
        
        private Amazon.TranscribeService.Model.CreateMedicalVocabularyResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.CreateMedicalVocabularyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "CreateMedicalVocabulary");
            try
            {
                #if DESKTOP
                return client.CreateMedicalVocabulary(request);
                #elif CORECLR
                return client.CreateMedicalVocabularyAsync(request).GetAwaiter().GetResult();
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
            public System.String VocabularyFileUri { get; set; }
            public System.String VocabularyName { get; set; }
            public System.Func<Amazon.TranscribeService.Model.CreateMedicalVocabularyResponse, NewTRSMedicalVocabularyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
