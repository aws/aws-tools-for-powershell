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
    /// Creates a new custom vocabulary filter.
    /// 
    ///  
    /// <para>
    /// You can use custom vocabulary filters to mask, delete, or flag specific words from
    /// your transcript. Custom vocabulary filters are commonly used to mask profanity in
    /// transcripts.
    /// </para><para>
    /// Each language has a character set that contains all allowed characters for that specific
    /// language. If you use unsupported characters, your custom vocabulary filter request
    /// fails. Refer to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/charsets.html">Character
    /// Sets for Custom Vocabularies</a> to get the character set for your language.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/vocabulary-filtering.html">Vocabulary
    /// filtering</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "TRSVocabularyFilter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.CreateVocabularyFilterResponse")]
    [AWSCmdlet("Calls the Amazon Transcribe Service CreateVocabularyFilter API operation.", Operation = new[] {"CreateVocabularyFilter"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.CreateVocabularyFilterResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.CreateVocabularyFilterResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.CreateVocabularyFilterResponse object containing multiple properties."
    )]
    public partial class NewTRSVocabularyFilterCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that has permissions to access the Amazon
        /// S3 bucket that contains your input files (in this case, your custom vocabulary filter).
        /// If the role that you specify doesn’t have the appropriate permissions to access the
        /// specified Amazon S3 location, your request fails.</para><para>IAM role ARNs have the format <c>arn:partition:iam::account:role/role-name-with-path</c>.
        /// For example: <c>arn:aws:iam::111122223333:role/Admin</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html#identifiers-arns">IAM
        /// ARNs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code that represents the language of the entries in your vocabulary filter.
        /// Each custom vocabulary filter must contain terms in only one language.</para><para>A custom vocabulary filter can only be used to transcribe files in the same language
        /// as the filter. For example, if you create a custom vocabulary filter using US English
        /// (<c>en-US</c>), you can only apply this filter to files that contain English audio.</para><para>For a list of supported languages and their associated language codes, refer to the
        /// <a href="https://docs.aws.amazon.com/transcribe/latest/dg/supported-languages.html">Supported
        /// languages</a> table.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Adds one or more custom tags, each in the form of a key:value pair, to a new custom
        /// vocabulary filter at the time you create this new vocabulary filter.</para><para>To learn more about using tags with Amazon Transcribe, refer to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/tagging.html">Tagging
        /// resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.TranscribeService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VocabularyFilterFileUri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location of the text file that contains your custom vocabulary filter
        /// terms. The URI must be located in the same Amazon Web Services Region as the resource
        /// you're calling.</para><para>Here's an example URI path: <c>s3://DOC-EXAMPLE-BUCKET/my-vocab-filter-file.txt</c></para><para>Note that if you include <c>VocabularyFilterFileUri</c> in your request, you cannot
        /// use <c>Words</c>; you must choose one or the other.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VocabularyFilterFileUri { get; set; }
        #endregion
        
        #region Parameter VocabularyFilterName
        /// <summary>
        /// <para>
        /// <para>A unique name, chosen by you, for your new custom vocabulary filter.</para><para>This name is case sensitive, cannot contain spaces, and must be unique within an Amazon
        /// Web Services account. If you try to create a new custom vocabulary filter with the
        /// same name as an existing custom vocabulary filter, you get a <c>ConflictException</c>
        /// error.</para>
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
        public System.String VocabularyFilterName { get; set; }
        #endregion
        
        #region Parameter Word
        /// <summary>
        /// <para>
        /// <para>Use this parameter if you want to create your custom vocabulary filter by including
        /// all desired terms, as comma-separated values, within your request. The other option
        /// for creating your vocabulary filter is to save your entries in a text file and upload
        /// them to an Amazon S3 bucket, then specify the location of your file using the <c>VocabularyFilterFileUri</c>
        /// parameter.</para><para>Note that if you include <c>Words</c> in your request, you cannot use <c>VocabularyFilterFileUri</c>;
        /// you must choose one or the other.</para><para>Each language has a character set that contains all allowed characters for that specific
        /// language. If you use unsupported characters, your custom vocabulary filter request
        /// fails. Refer to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/charsets.html">Character
        /// Sets for Custom Vocabularies</a> to get the character set for your language.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Words")]
        public System.String[] Word { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TranscribeService.Model.CreateVocabularyFilterResponse).
        /// Specifying the name of a property of type Amazon.TranscribeService.Model.CreateVocabularyFilterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VocabularyFilterName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VocabularyFilterName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VocabularyFilterName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VocabularyFilterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TRSVocabularyFilter (CreateVocabularyFilter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.CreateVocabularyFilterResponse, NewTRSVocabularyFilterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VocabularyFilterName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            context.LanguageCode = this.LanguageCode;
            #if MODULAR
            if (this.LanguageCode == null && ParameterWasBound(nameof(this.LanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter LanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.TranscribeService.Model.Tag>(this.Tag);
            }
            context.VocabularyFilterFileUri = this.VocabularyFilterFileUri;
            context.VocabularyFilterName = this.VocabularyFilterName;
            #if MODULAR
            if (this.VocabularyFilterName == null && ParameterWasBound(nameof(this.VocabularyFilterName)))
            {
                WriteWarning("You are passing $null as a value for parameter VocabularyFilterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Word != null)
            {
                context.Word = new List<System.String>(this.Word);
            }
            
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
            var request = new Amazon.TranscribeService.Model.CreateVocabularyFilterRequest();
            
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VocabularyFilterFileUri != null)
            {
                request.VocabularyFilterFileUri = cmdletContext.VocabularyFilterFileUri;
            }
            if (cmdletContext.VocabularyFilterName != null)
            {
                request.VocabularyFilterName = cmdletContext.VocabularyFilterName;
            }
            if (cmdletContext.Word != null)
            {
                request.Words = cmdletContext.Word;
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
        
        private Amazon.TranscribeService.Model.CreateVocabularyFilterResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.CreateVocabularyFilterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "CreateVocabularyFilter");
            try
            {
                #if DESKTOP
                return client.CreateVocabularyFilter(request);
                #elif CORECLR
                return client.CreateVocabularyFilterAsync(request).GetAwaiter().GetResult();
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
            public System.String DataAccessRoleArn { get; set; }
            public Amazon.TranscribeService.LanguageCode LanguageCode { get; set; }
            public List<Amazon.TranscribeService.Model.Tag> Tag { get; set; }
            public System.String VocabularyFilterFileUri { get; set; }
            public System.String VocabularyFilterName { get; set; }
            public List<System.String> Word { get; set; }
            public System.Func<Amazon.TranscribeService.Model.CreateVocabularyFilterResponse, NewTRSVocabularyFilterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
