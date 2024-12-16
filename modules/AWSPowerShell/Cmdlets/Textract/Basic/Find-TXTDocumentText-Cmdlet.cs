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
using Amazon.Textract;
using Amazon.Textract.Model;

namespace Amazon.PowerShell.Cmdlets.TXT
{
    /// <summary>
    /// Detects text in the input document. Amazon Textract can detect lines of text and the
    /// words that make up a line of text. The input document must be in one of the following
    /// image formats: JPEG, PNG, PDF, or TIFF. <c>DetectDocumentText</c> returns the detected
    /// text in an array of <a>Block</a> objects. 
    /// 
    ///  
    /// <para>
    /// Each document page has as an associated <c>Block</c> of type PAGE. Each PAGE <c>Block</c>
    /// object is the parent of LINE <c>Block</c> objects that represent the lines of detected
    /// text on a page. A LINE <c>Block</c> object is a parent for each word that makes up
    /// the line. Words are represented by <c>Block</c> objects of type WORD.
    /// </para><para><c>DetectDocumentText</c> is a synchronous operation. To analyze documents asynchronously,
    /// use <a>StartDocumentTextDetection</a>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/textract/latest/dg/how-it-works-detecting.html">Document
    /// Text Detection</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Find", "TXTDocumentText")]
    [OutputType("Amazon.Textract.Model.Block")]
    [AWSCmdlet("Calls the Amazon Textract DetectDocumentText API operation.", Operation = new[] {"DetectDocumentText"}, SelectReturnType = typeof(Amazon.Textract.Model.DetectDocumentTextResponse))]
    [AWSCmdletOutput("Amazon.Textract.Model.Block or Amazon.Textract.Model.DetectDocumentTextResponse",
        "This cmdlet returns a collection of Amazon.Textract.Model.Block objects.",
        "The service call response (type Amazon.Textract.Model.DetectDocumentTextResponse) can be returned by specifying '-Select *'."
    )]
    public partial class FindTXTDocumentTextCmdlet : AmazonTextractClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket. Note that the # character is not valid in the file name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Document_S3Object_Bucket")]
        public System.String S3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter Document_Byte
        /// <summary>
        /// <para>
        /// <para>A blob of base64-encoded document bytes. The maximum size of a document that's provided
        /// in a blob of bytes is 5 MB. The document bytes must be in PNG or JPEG format.</para><para>If you're using an AWS SDK to call Amazon Textract, you might not need to base64-encode
        /// image bytes passed using the <c>Bytes</c> field. </para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Document_Bytes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Document_Byte { get; set; }
        #endregion
        
        #region Parameter S3Object_Name
        /// <summary>
        /// <para>
        /// <para>The file name of the input document. Synchronous operations can use image files that
        /// are in JPEG or PNG format. Asynchronous operations also support PDF and TIFF format
        /// files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Document_S3Object_Name")]
        public System.String S3Object_Name { get; set; }
        #endregion
        
        #region Parameter S3Object_Version
        /// <summary>
        /// <para>
        /// <para>If the bucket has versioning enabled, you can specify the object version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Document_S3Object_Version")]
        public System.String S3Object_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Blocks'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Textract.Model.DetectDocumentTextResponse).
        /// Specifying the name of a property of type Amazon.Textract.Model.DetectDocumentTextResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Blocks";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Textract.Model.DetectDocumentTextResponse, FindTXTDocumentTextCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Document_Byte = this.Document_Byte;
            context.S3Object_Bucket = this.S3Object_Bucket;
            context.S3Object_Name = this.S3Object_Name;
            context.S3Object_Version = this.S3Object_Version;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Document_ByteStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Textract.Model.DetectDocumentTextRequest();
                
                
                 // populate Document
                var requestDocumentIsNull = true;
                request.Document = new Amazon.Textract.Model.Document();
                System.IO.MemoryStream requestDocument_document_Byte = null;
                if (cmdletContext.Document_Byte != null)
                {
                    _Document_ByteStream = new System.IO.MemoryStream(cmdletContext.Document_Byte);
                    requestDocument_document_Byte = _Document_ByteStream;
                }
                if (requestDocument_document_Byte != null)
                {
                    request.Document.Bytes = requestDocument_document_Byte;
                    requestDocumentIsNull = false;
                }
                Amazon.Textract.Model.S3Object requestDocument_document_S3Object = null;
                
                 // populate S3Object
                var requestDocument_document_S3ObjectIsNull = true;
                requestDocument_document_S3Object = new Amazon.Textract.Model.S3Object();
                System.String requestDocument_document_S3Object_s3Object_Bucket = null;
                if (cmdletContext.S3Object_Bucket != null)
                {
                    requestDocument_document_S3Object_s3Object_Bucket = cmdletContext.S3Object_Bucket;
                }
                if (requestDocument_document_S3Object_s3Object_Bucket != null)
                {
                    requestDocument_document_S3Object.Bucket = requestDocument_document_S3Object_s3Object_Bucket;
                    requestDocument_document_S3ObjectIsNull = false;
                }
                System.String requestDocument_document_S3Object_s3Object_Name = null;
                if (cmdletContext.S3Object_Name != null)
                {
                    requestDocument_document_S3Object_s3Object_Name = cmdletContext.S3Object_Name;
                }
                if (requestDocument_document_S3Object_s3Object_Name != null)
                {
                    requestDocument_document_S3Object.Name = requestDocument_document_S3Object_s3Object_Name;
                    requestDocument_document_S3ObjectIsNull = false;
                }
                System.String requestDocument_document_S3Object_s3Object_Version = null;
                if (cmdletContext.S3Object_Version != null)
                {
                    requestDocument_document_S3Object_s3Object_Version = cmdletContext.S3Object_Version;
                }
                if (requestDocument_document_S3Object_s3Object_Version != null)
                {
                    requestDocument_document_S3Object.Version = requestDocument_document_S3Object_s3Object_Version;
                    requestDocument_document_S3ObjectIsNull = false;
                }
                 // determine if requestDocument_document_S3Object should be set to null
                if (requestDocument_document_S3ObjectIsNull)
                {
                    requestDocument_document_S3Object = null;
                }
                if (requestDocument_document_S3Object != null)
                {
                    request.Document.S3Object = requestDocument_document_S3Object;
                    requestDocumentIsNull = false;
                }
                 // determine if request.Document should be set to null
                if (requestDocumentIsNull)
                {
                    request.Document = null;
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
                if( _Document_ByteStream != null)
                {
                    _Document_ByteStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Textract.Model.DetectDocumentTextResponse CallAWSServiceOperation(IAmazonTextract client, Amazon.Textract.Model.DetectDocumentTextRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Textract", "DetectDocumentText");
            try
            {
                #if DESKTOP
                return client.DetectDocumentText(request);
                #elif CORECLR
                return client.DetectDocumentTextAsync(request).GetAwaiter().GetResult();
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
            public byte[] Document_Byte { get; set; }
            public System.String S3Object_Bucket { get; set; }
            public System.String S3Object_Name { get; set; }
            public System.String S3Object_Version { get; set; }
            public System.Func<Amazon.Textract.Model.DetectDocumentTextResponse, FindTXTDocumentTextCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Blocks;
        }
        
    }
}
