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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Creates a new document classification request to analyze a single document in real-time,
    /// using a previously created and trained custom model and an endpoint.
    /// 
    ///  
    /// <para>
    /// You can input plain text or you can upload a single-page input document (text, PDF,
    /// Word, or image). 
    /// </para><para>
    /// If the system detects errors while processing a page in the input document, the API
    /// response includes an entry in <code>Errors</code> that describes the errors.
    /// </para><para>
    /// If the system detects a document-level error in your input document, the API returns
    /// an <code>InvalidRequestException</code> error response. For details about this exception,
    /// see <a href="https://docs.aws.amazon.com/comprehend/latest/dg/idp-inputs-sync-err.html">
    /// Errors in semi-structured documents</a> in the Comprehend Developer Guide. 
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "COMPDocumentClassification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Comprehend.Model.DocumentClass")]
    [AWSCmdlet("Calls the Amazon Comprehend ClassifyDocument API operation.", Operation = new[] {"ClassifyDocument"}, SelectReturnType = typeof(Amazon.Comprehend.Model.ClassifyDocumentResponse))]
    [AWSCmdletOutput("Amazon.Comprehend.Model.DocumentClass or Amazon.Comprehend.Model.ClassifyDocumentResponse",
        "This cmdlet returns a collection of Amazon.Comprehend.Model.DocumentClass objects.",
        "The service call response (type Amazon.Comprehend.Model.ClassifyDocumentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeCOMPDocumentClassificationCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        #region Parameter Byte
        /// <summary>
        /// <para>
        /// <para>Use the <code>Bytes</code> parameter to input a text, PDF, Word or image file. You
        /// can also use the <code>Bytes</code> parameter to input an Amazon Textract <code>DetectDocumentText</code>
        /// or <code>AnalyzeDocument</code> output file.</para><para>Provide the input document as a sequence of base64-encoded bytes. If your code uses
        /// an Amazon Web Services SDK to classify documents, the SDK may encode the document
        /// file bytes for you. </para><para>The maximum length of this field depends on the input document type. For details,
        /// see <a href="https://docs.aws.amazon.com/comprehend/latest/dg/idp-inputs-sync.html">
        /// Inputs for real-time custom analysis</a> in the Comprehend Developer Guide. </para><para>If you use the <code>Bytes</code> parameter, do not use the <code>Text</code> parameter.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Bytes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Byte { get; set; }
        #endregion
        
        #region Parameter DocumentReaderConfig_DocumentReadAction
        /// <summary>
        /// <para>
        /// <para>This field defines the Amazon Textract API operation that Amazon Comprehend uses to
        /// extract text from PDF files and image files. Enter one of the following values:</para><ul><li><para><code>TEXTRACT_DETECT_DOCUMENT_TEXT</code> - The Amazon Comprehend service uses the
        /// <code>DetectDocumentText</code> API operation. </para></li><li><para><code>TEXTRACT_ANALYZE_DOCUMENT</code> - The Amazon Comprehend service uses the <code>AnalyzeDocument</code>
        /// API operation. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.DocumentReadAction")]
        public Amazon.Comprehend.DocumentReadAction DocumentReaderConfig_DocumentReadAction { get; set; }
        #endregion
        
        #region Parameter DocumentReaderConfig_DocumentReadMode
        /// <summary>
        /// <para>
        /// <para>Determines the text extraction actions for PDF files. Enter one of the following values:</para><ul><li><para><code>SERVICE_DEFAULT</code> - use the Amazon Comprehend service defaults for PDF
        /// files.</para></li><li><para><code>FORCE_DOCUMENT_READ_ACTION</code> - Amazon Comprehend uses the Textract API
        /// specified by DocumentReadAction for all PDF files, including digital PDF files. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.DocumentReadMode")]
        public Amazon.Comprehend.DocumentReadMode DocumentReaderConfig_DocumentReadMode { get; set; }
        #endregion
        
        #region Parameter EndpointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the endpoint. For information about endpoints,
        /// see <a href="https://docs.aws.amazon.com/comprehend/latest/dg/manage-endpoints.html">Managing
        /// endpoints</a>.</para>
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
        public System.String EndpointArn { get; set; }
        #endregion
        
        #region Parameter DocumentReaderConfig_FeatureType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of Amazon Textract features to apply. If you chose <code>TEXTRACT_ANALYZE_DOCUMENT</code>
        /// as the read action, you must specify one or both of the following values:</para><ul><li><para><code>TABLES</code> - Returns information about any tables that are detected in the
        /// input document. </para></li><li><para><code>FORMS</code> - Returns information and the data from any forms that are detected
        /// in the input document. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentReaderConfig_FeatureTypes")]
        public System.String[] DocumentReaderConfig_FeatureType { get; set; }
        #endregion
        
        #region Parameter Text
        /// <summary>
        /// <para>
        /// <para>The document text to be analyzed. If you enter text using this parameter, do not use
        /// the <code>Bytes</code> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Text { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Classes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Comprehend.Model.ClassifyDocumentResponse).
        /// Specifying the name of a property of type Amazon.Comprehend.Model.ClassifyDocumentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Classes";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-COMPDocumentClassification (ClassifyDocument)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.ClassifyDocumentResponse, InvokeCOMPDocumentClassificationCmdlet>(Select) ??
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
            context.Byte = this.Byte;
            context.DocumentReaderConfig_DocumentReadAction = this.DocumentReaderConfig_DocumentReadAction;
            context.DocumentReaderConfig_DocumentReadMode = this.DocumentReaderConfig_DocumentReadMode;
            if (this.DocumentReaderConfig_FeatureType != null)
            {
                context.DocumentReaderConfig_FeatureType = new List<System.String>(this.DocumentReaderConfig_FeatureType);
            }
            context.EndpointArn = this.EndpointArn;
            #if MODULAR
            if (this.EndpointArn == null && ParameterWasBound(nameof(this.EndpointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Text = this.Text;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _ByteStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Comprehend.Model.ClassifyDocumentRequest();
                
                if (cmdletContext.Byte != null)
                {
                    _ByteStream = new System.IO.MemoryStream(cmdletContext.Byte);
                    request.Bytes = _ByteStream;
                }
                
                 // populate DocumentReaderConfig
                var requestDocumentReaderConfigIsNull = true;
                request.DocumentReaderConfig = new Amazon.Comprehend.Model.DocumentReaderConfig();
                Amazon.Comprehend.DocumentReadAction requestDocumentReaderConfig_documentReaderConfig_DocumentReadAction = null;
                if (cmdletContext.DocumentReaderConfig_DocumentReadAction != null)
                {
                    requestDocumentReaderConfig_documentReaderConfig_DocumentReadAction = cmdletContext.DocumentReaderConfig_DocumentReadAction;
                }
                if (requestDocumentReaderConfig_documentReaderConfig_DocumentReadAction != null)
                {
                    request.DocumentReaderConfig.DocumentReadAction = requestDocumentReaderConfig_documentReaderConfig_DocumentReadAction;
                    requestDocumentReaderConfigIsNull = false;
                }
                Amazon.Comprehend.DocumentReadMode requestDocumentReaderConfig_documentReaderConfig_DocumentReadMode = null;
                if (cmdletContext.DocumentReaderConfig_DocumentReadMode != null)
                {
                    requestDocumentReaderConfig_documentReaderConfig_DocumentReadMode = cmdletContext.DocumentReaderConfig_DocumentReadMode;
                }
                if (requestDocumentReaderConfig_documentReaderConfig_DocumentReadMode != null)
                {
                    request.DocumentReaderConfig.DocumentReadMode = requestDocumentReaderConfig_documentReaderConfig_DocumentReadMode;
                    requestDocumentReaderConfigIsNull = false;
                }
                List<System.String> requestDocumentReaderConfig_documentReaderConfig_FeatureType = null;
                if (cmdletContext.DocumentReaderConfig_FeatureType != null)
                {
                    requestDocumentReaderConfig_documentReaderConfig_FeatureType = cmdletContext.DocumentReaderConfig_FeatureType;
                }
                if (requestDocumentReaderConfig_documentReaderConfig_FeatureType != null)
                {
                    request.DocumentReaderConfig.FeatureTypes = requestDocumentReaderConfig_documentReaderConfig_FeatureType;
                    requestDocumentReaderConfigIsNull = false;
                }
                 // determine if request.DocumentReaderConfig should be set to null
                if (requestDocumentReaderConfigIsNull)
                {
                    request.DocumentReaderConfig = null;
                }
                if (cmdletContext.EndpointArn != null)
                {
                    request.EndpointArn = cmdletContext.EndpointArn;
                }
                if (cmdletContext.Text != null)
                {
                    request.Text = cmdletContext.Text;
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
            finally
            {
                if( _ByteStream != null)
                {
                    _ByteStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Comprehend.Model.ClassifyDocumentResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.ClassifyDocumentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "ClassifyDocument");
            try
            {
                #if DESKTOP
                return client.ClassifyDocument(request);
                #elif CORECLR
                return client.ClassifyDocumentAsync(request).GetAwaiter().GetResult();
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
            public byte[] Byte { get; set; }
            public Amazon.Comprehend.DocumentReadAction DocumentReaderConfig_DocumentReadAction { get; set; }
            public Amazon.Comprehend.DocumentReadMode DocumentReaderConfig_DocumentReadMode { get; set; }
            public List<System.String> DocumentReaderConfig_FeatureType { get; set; }
            public System.String EndpointArn { get; set; }
            public System.String Text { get; set; }
            public System.Func<Amazon.Comprehend.Model.ClassifyDocumentResponse, InvokeCOMPDocumentClassificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Classes;
        }
        
    }
}
