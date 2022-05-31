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
    /// Updates an existing custom vocabulary filter with a new list of words. The new list
    /// you provide overwrites all previous entries; you cannot append new terms onto an existing
    /// vocabulary filter.
    /// </summary>
    [Cmdlet("Update", "TRSVocabularyFilter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.UpdateVocabularyFilterResponse")]
    [AWSCmdlet("Calls the Amazon Transcribe Service UpdateVocabularyFilter API operation.", Operation = new[] {"UpdateVocabularyFilter"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.UpdateVocabularyFilterResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.UpdateVocabularyFilterResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.UpdateVocabularyFilterResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateTRSVocabularyFilterCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        #region Parameter VocabularyFilterFileUri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location of the text file that contains your custom vocabulary filter
        /// terms. The URI must be located in the same Amazon Web Services Region as the resource
        /// you're calling.</para><para>Here's an example URI path: <code>s3://DOC-EXAMPLE-BUCKET/my-vocab-filter-file.txt</code></para><para>Note that if you include <code>VocabularyFilterFileUri</code> in your request, you
        /// cannot use <code>Words</code>; you must choose one or the other.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VocabularyFilterFileUri { get; set; }
        #endregion
        
        #region Parameter VocabularyFilterName
        /// <summary>
        /// <para>
        /// <para>The name of the custom vocabulary filter you want to update. Vocabulary filter names
        /// are case sensitive.</para>
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
        /// <para>Use this parameter if you want to update your vocabulary filter by including all desired
        /// terms, as comma-separated values, within your request. The other option for updating
        /// your vocabulary filter is to save your entries in a text file and upload them to an
        /// Amazon S3 bucket, then specify the location of your file using the <code>VocabularyFilterFileUri</code>
        /// parameter.</para><para>Note that if you include <code>Words</code> in your request, you cannot use <code>VocabularyFilterFileUri</code>;
        /// you must choose one or the other.</para><para>Each language has a character set that contains all allowed characters for that specific
        /// language. If you use unsupported characters, your vocabulary filter request fails.
        /// Refer to <a href="https://docs.aws.amazon.com/transcribe/latest/dg/charsets.html">Character
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TranscribeService.Model.UpdateVocabularyFilterResponse).
        /// Specifying the name of a property of type Amazon.TranscribeService.Model.UpdateVocabularyFilterResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VocabularyFilterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TRSVocabularyFilter (UpdateVocabularyFilter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.UpdateVocabularyFilterResponse, UpdateTRSVocabularyFilterCmdlet>(Select) ??
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
            var request = new Amazon.TranscribeService.Model.UpdateVocabularyFilterRequest();
            
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
        
        private Amazon.TranscribeService.Model.UpdateVocabularyFilterResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.UpdateVocabularyFilterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "UpdateVocabularyFilter");
            try
            {
                #if DESKTOP
                return client.UpdateVocabularyFilter(request);
                #elif CORECLR
                return client.UpdateVocabularyFilterAsync(request).GetAwaiter().GetResult();
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
            public System.String VocabularyFilterFileUri { get; set; }
            public System.String VocabularyFilterName { get; set; }
            public List<System.String> Word { get; set; }
            public System.Func<Amazon.TranscribeService.Model.UpdateVocabularyFilterResponse, UpdateTRSVocabularyFilterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
