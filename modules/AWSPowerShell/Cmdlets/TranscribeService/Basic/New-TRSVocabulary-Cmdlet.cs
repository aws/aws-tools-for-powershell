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
    /// Creates a new custom vocabulary that you can use to change the way Amazon Transcribe
    /// handles transcription of an audio file.
    /// </summary>
    [Cmdlet("New", "TRSVocabulary", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.CreateVocabularyResponse")]
    [AWSCmdlet("Calls the Amazon Transcribe Service CreateVocabulary API operation.", Operation = new[] {"CreateVocabulary"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.CreateVocabularyResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.CreateVocabularyResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.CreateVocabularyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewTRSVocabularyCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code of the vocabulary entries. For a list of languages and their corresponding
        /// language codes, see <a>table-language-matrix</a>.</para>
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
        
        #region Parameter Phrase
        /// <summary>
        /// <para>
        /// <para>An array of strings that contains the vocabulary entries. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Phrases")]
        public System.String[] Phrase { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Adds one or more tags, each in the form of a key:value pair, to a new Amazon Transcribe
        /// vocabulary at the time you create this new vocabulary.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.TranscribeService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VocabularyFileUri
        /// <summary>
        /// <para>
        /// <para>The S3 location of the text file that contains the definition of the custom vocabulary.
        /// The URI must be in the same region as the API endpoint that you are calling. The general
        /// form is:</para><para><code>https://s3.&lt;Amazon Web Services-region&gt;.amazonaws.com/&lt;AWSDOC-EXAMPLE-BUCKET&gt;/&lt;keyprefix&gt;/&lt;objectkey&gt;
        /// </code></para><para>For example:</para><para><code>https://s3.us-east-1.amazonaws.com/AWSDOC-EXAMPLE-BUCKET/vocab.txt</code></para><para>For more information about S3 object names, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingMetadata.html#object-keys">Object
        /// Keys</a> in the <i>Amazon S3 Developer Guide</i>.</para><para>For more information about custom vocabularies, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/custom-vocabulary.html">Custom
        /// vocabularies</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VocabularyFileUri { get; set; }
        #endregion
        
        #region Parameter VocabularyName
        /// <summary>
        /// <para>
        /// <para>The name of the vocabulary. The name must be unique within an Amazon Web Services
        /// account. The name is case sensitive. If you try to create a vocabulary with the same
        /// name as a previous vocabulary you will receive a <code>ConflictException</code> error.</para>
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
        public System.String VocabularyName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TranscribeService.Model.CreateVocabularyResponse).
        /// Specifying the name of a property of type Amazon.TranscribeService.Model.CreateVocabularyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VocabularyName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VocabularyName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VocabularyName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VocabularyName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TRSVocabulary (CreateVocabulary)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.CreateVocabularyResponse, NewTRSVocabularyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VocabularyName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LanguageCode = this.LanguageCode;
            #if MODULAR
            if (this.LanguageCode == null && ParameterWasBound(nameof(this.LanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter LanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Phrase != null)
            {
                context.Phrase = new List<System.String>(this.Phrase);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.TranscribeService.Model.Tag>(this.Tag);
            }
            context.VocabularyFileUri = this.VocabularyFileUri;
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
            var request = new Amazon.TranscribeService.Model.CreateVocabularyRequest();
            
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.Phrase != null)
            {
                request.Phrases = cmdletContext.Phrase;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.TranscribeService.Model.CreateVocabularyResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.CreateVocabularyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "CreateVocabulary");
            try
            {
                #if DESKTOP
                return client.CreateVocabulary(request);
                #elif CORECLR
                return client.CreateVocabularyAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Phrase { get; set; }
            public List<Amazon.TranscribeService.Model.Tag> Tag { get; set; }
            public System.String VocabularyFileUri { get; set; }
            public System.String VocabularyName { get; set; }
            public System.Func<Amazon.TranscribeService.Model.CreateVocabularyResponse, NewTRSVocabularyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
