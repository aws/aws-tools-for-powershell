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
    /// Analyzes an input document for financially related relationships between text.
    /// 
    ///  
    /// <para>
    /// Information is returned as <code>ExpenseDocuments</code> and seperated as follows.
    /// </para><ul><li><para><code>LineItemGroups</code>- A data set containing <code>LineItems</code> which store
    /// information about the lines of text, such as an item purchased and its price on a
    /// receipt.
    /// </para></li><li><para><code>SummaryFields</code>- Contains all other information a receipt, such as header
    /// information or the vendors name.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Invoke", "TXTExpenseAnalysis", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Textract.Model.ExpenseDocument")]
    [AWSCmdlet("Calls the Amazon Textract AnalyzeExpense API operation.", Operation = new[] {"AnalyzeExpense"}, SelectReturnType = typeof(Amazon.Textract.Model.AnalyzeExpenseResponse))]
    [AWSCmdletOutput("Amazon.Textract.Model.ExpenseDocument or Amazon.Textract.Model.AnalyzeExpenseResponse",
        "This cmdlet returns a collection of Amazon.Textract.Model.ExpenseDocument objects.",
        "The service call response (type Amazon.Textract.Model.AnalyzeExpenseResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeTXTExpenseAnalysisCmdlet : AmazonTextractClientCmdlet, IExecutor
    {
        
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
        /// image bytes passed using the <code>Bytes</code> field. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExpenseDocuments'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Textract.Model.AnalyzeExpenseResponse).
        /// Specifying the name of a property of type Amazon.Textract.Model.AnalyzeExpenseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExpenseDocuments";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-TXTExpenseAnalysis (AnalyzeExpense)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Textract.Model.AnalyzeExpenseResponse, InvokeTXTExpenseAnalysisCmdlet>(Select) ??
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
                var request = new Amazon.Textract.Model.AnalyzeExpenseRequest();
                
                
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
        
        private Amazon.Textract.Model.AnalyzeExpenseResponse CallAWSServiceOperation(IAmazonTextract client, Amazon.Textract.Model.AnalyzeExpenseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Textract", "AnalyzeExpense");
            try
            {
                #if DESKTOP
                return client.AnalyzeExpense(request);
                #elif CORECLR
                return client.AnalyzeExpenseAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Textract.Model.AnalyzeExpenseResponse, InvokeTXTExpenseAnalysisCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExpenseDocuments;
        }
        
    }
}
