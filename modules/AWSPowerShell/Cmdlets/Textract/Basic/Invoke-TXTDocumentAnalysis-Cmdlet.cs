/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Textract;
using Amazon.Textract.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TXT
{
    /// <summary>
    /// Analyzes an input document for relationships between detected items. 
    /// 
    ///  
    /// <para>
    /// The types of information returned are as follows: 
    /// </para><ul><li><para>
    /// Form data (key-value pairs). The related information is returned in two <a>Block</a>
    /// objects, each of type <c>KEY_VALUE_SET</c>: a KEY <c>Block</c> object and a VALUE
    /// <c>Block</c> object. For example, <i>Name: Ana Silva Carolina</i> contains a key and
    /// value. <i>Name:</i> is the key. <i>Ana Silva Carolina</i> is the value.
    /// </para></li><li><para>
    /// Table and table cell data. A TABLE <c>Block</c> object contains information about
    /// a detected table. A CELL <c>Block</c> object is returned for each cell in a table.
    /// </para></li><li><para>
    /// Lines and words of text. A LINE <c>Block</c> object contains one or more WORD <c>Block</c>
    /// objects. All lines and words that are detected in the document are returned (including
    /// text that doesn't have a relationship with the value of <c>FeatureTypes</c>). 
    /// </para></li><li><para>
    /// Signatures. A SIGNATURE <c>Block</c> object contains the location information of a
    /// signature in a document. If used in conjunction with forms or tables, a signature
    /// can be given a Key-Value pairing or be detected in the cell of a table.
    /// </para></li><li><para>
    /// Query. A QUERY Block object contains the query text, alias and link to the associated
    /// Query results block object.
    /// </para></li><li><para>
    /// Query Result. A QUERY_RESULT Block object contains the answer to the query and an
    /// ID that connects it to the query asked. This Block also contains a confidence score.
    /// </para></li></ul><para>
    /// Selection elements such as check boxes and option buttons (radio buttons) can be detected
    /// in form data and in tables. A SELECTION_ELEMENT <c>Block</c> object contains information
    /// about a selection element, including the selection status.
    /// </para><para>
    /// You can choose which type of analysis to perform by specifying the <c>FeatureTypes</c>
    /// list. 
    /// </para><para>
    /// The output is returned in a list of <c>Block</c> objects.
    /// </para><para><c>AnalyzeDocument</c> is a synchronous operation. To analyze documents asynchronously,
    /// use <a>StartDocumentAnalysis</a>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/textract/latest/dg/how-it-works-analyzing.html">Document
    /// Text Analysis</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "TXTDocumentAnalysis", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Textract.Model.Block")]
    [AWSCmdlet("Calls the Amazon Textract AnalyzeDocument API operation.", Operation = new[] {"AnalyzeDocument"}, SelectReturnType = typeof(Amazon.Textract.Model.AnalyzeDocumentResponse))]
    [AWSCmdletOutput("Amazon.Textract.Model.Block or Amazon.Textract.Model.AnalyzeDocumentResponse",
        "This cmdlet returns a collection of Amazon.Textract.Model.Block objects.",
        "The service call response (type Amazon.Textract.Model.AnalyzeDocumentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeTXTDocumentAnalysisCmdlet : AmazonTextractClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdaptersConfig_Adapter
        /// <summary>
        /// <para>
        /// <para>A list of adapters to be used when analyzing the specified document.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdaptersConfig_Adapters")]
        public Amazon.Textract.Model.Adapter[] AdaptersConfig_Adapter { get; set; }
        #endregion
        
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
        
        #region Parameter DataAttributes_ContentClassifier
        /// <summary>
        /// <para>
        /// <para>Sets whether the input image is free of personally identifiable information or adult
        /// content.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HumanLoopConfig_DataAttributes_ContentClassifiers")]
        public System.String[] DataAttributes_ContentClassifier { get; set; }
        #endregion
        
        #region Parameter FeatureType
        /// <summary>
        /// <para>
        /// <para>A list of the types of analysis to perform. Add TABLES to the list to return information
        /// about the tables that are detected in the input document. Add FORMS to return detected
        /// form data. Add SIGNATURES to return the locations of detected signatures. Add LAYOUT
        /// to the list to return information about the layout of the document. All lines and
        /// words detected in the document are included in the response (including text that isn't
        /// related to the value of <c>FeatureTypes</c>). </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FeatureTypes")]
        public System.String[] FeatureType { get; set; }
        #endregion
        
        #region Parameter HumanLoopConfig_FlowDefinitionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the flow definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HumanLoopConfig_FlowDefinitionArn { get; set; }
        #endregion
        
        #region Parameter HumanLoopConfig_HumanLoopName
        /// <summary>
        /// <para>
        /// <para>The name of the human workflow used for this image. This should be kept unique within
        /// a region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HumanLoopConfig_HumanLoopName { get; set; }
        #endregion
        
        #region Parameter S3Object_Name
        /// <summary>
        /// <para>
        /// <para>The file name of the input document. Image files may be in PDF, TIFF, JPEG, or PNG
        /// format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Document_S3Object_Name")]
        public System.String S3Object_Name { get; set; }
        #endregion
        
        #region Parameter QueriesConfig_Query
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueriesConfig_Queries")]
        public Amazon.Textract.Model.Query[] QueriesConfig_Query { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Textract.Model.AnalyzeDocumentResponse).
        /// Specifying the name of a property of type Amazon.Textract.Model.AnalyzeDocumentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Blocks";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-TXTDocumentAnalysis (AnalyzeDocument)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Textract.Model.AnalyzeDocumentResponse, InvokeTXTDocumentAnalysisCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdaptersConfig_Adapter != null)
            {
                context.AdaptersConfig_Adapter = new List<Amazon.Textract.Model.Adapter>(this.AdaptersConfig_Adapter);
            }
            context.Document_Byte = this.Document_Byte;
            context.S3Object_Bucket = this.S3Object_Bucket;
            context.S3Object_Name = this.S3Object_Name;
            context.S3Object_Version = this.S3Object_Version;
            if (this.FeatureType != null)
            {
                context.FeatureType = new List<System.String>(this.FeatureType);
            }
            #if MODULAR
            if (this.FeatureType == null && ParameterWasBound(nameof(this.FeatureType)))
            {
                WriteWarning("You are passing $null as a value for parameter FeatureType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DataAttributes_ContentClassifier != null)
            {
                context.DataAttributes_ContentClassifier = new List<System.String>(this.DataAttributes_ContentClassifier);
            }
            context.HumanLoopConfig_FlowDefinitionArn = this.HumanLoopConfig_FlowDefinitionArn;
            context.HumanLoopConfig_HumanLoopName = this.HumanLoopConfig_HumanLoopName;
            if (this.QueriesConfig_Query != null)
            {
                context.QueriesConfig_Query = new List<Amazon.Textract.Model.Query>(this.QueriesConfig_Query);
            }
            
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
                var request = new Amazon.Textract.Model.AnalyzeDocumentRequest();
                
                
                 // populate AdaptersConfig
                var requestAdaptersConfigIsNull = true;
                request.AdaptersConfig = new Amazon.Textract.Model.AdaptersConfig();
                List<Amazon.Textract.Model.Adapter> requestAdaptersConfig_adaptersConfig_Adapter = null;
                if (cmdletContext.AdaptersConfig_Adapter != null)
                {
                    requestAdaptersConfig_adaptersConfig_Adapter = cmdletContext.AdaptersConfig_Adapter;
                }
                if (requestAdaptersConfig_adaptersConfig_Adapter != null)
                {
                    request.AdaptersConfig.Adapters = requestAdaptersConfig_adaptersConfig_Adapter;
                    requestAdaptersConfigIsNull = false;
                }
                 // determine if request.AdaptersConfig should be set to null
                if (requestAdaptersConfigIsNull)
                {
                    request.AdaptersConfig = null;
                }
                
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
                if (cmdletContext.FeatureType != null)
                {
                    request.FeatureTypes = cmdletContext.FeatureType;
                }
                
                 // populate HumanLoopConfig
                var requestHumanLoopConfigIsNull = true;
                request.HumanLoopConfig = new Amazon.Textract.Model.HumanLoopConfig();
                System.String requestHumanLoopConfig_humanLoopConfig_FlowDefinitionArn = null;
                if (cmdletContext.HumanLoopConfig_FlowDefinitionArn != null)
                {
                    requestHumanLoopConfig_humanLoopConfig_FlowDefinitionArn = cmdletContext.HumanLoopConfig_FlowDefinitionArn;
                }
                if (requestHumanLoopConfig_humanLoopConfig_FlowDefinitionArn != null)
                {
                    request.HumanLoopConfig.FlowDefinitionArn = requestHumanLoopConfig_humanLoopConfig_FlowDefinitionArn;
                    requestHumanLoopConfigIsNull = false;
                }
                System.String requestHumanLoopConfig_humanLoopConfig_HumanLoopName = null;
                if (cmdletContext.HumanLoopConfig_HumanLoopName != null)
                {
                    requestHumanLoopConfig_humanLoopConfig_HumanLoopName = cmdletContext.HumanLoopConfig_HumanLoopName;
                }
                if (requestHumanLoopConfig_humanLoopConfig_HumanLoopName != null)
                {
                    request.HumanLoopConfig.HumanLoopName = requestHumanLoopConfig_humanLoopConfig_HumanLoopName;
                    requestHumanLoopConfigIsNull = false;
                }
                Amazon.Textract.Model.HumanLoopDataAttributes requestHumanLoopConfig_humanLoopConfig_DataAttributes = null;
                
                 // populate DataAttributes
                var requestHumanLoopConfig_humanLoopConfig_DataAttributesIsNull = true;
                requestHumanLoopConfig_humanLoopConfig_DataAttributes = new Amazon.Textract.Model.HumanLoopDataAttributes();
                List<System.String> requestHumanLoopConfig_humanLoopConfig_DataAttributes_dataAttributes_ContentClassifier = null;
                if (cmdletContext.DataAttributes_ContentClassifier != null)
                {
                    requestHumanLoopConfig_humanLoopConfig_DataAttributes_dataAttributes_ContentClassifier = cmdletContext.DataAttributes_ContentClassifier;
                }
                if (requestHumanLoopConfig_humanLoopConfig_DataAttributes_dataAttributes_ContentClassifier != null)
                {
                    requestHumanLoopConfig_humanLoopConfig_DataAttributes.ContentClassifiers = requestHumanLoopConfig_humanLoopConfig_DataAttributes_dataAttributes_ContentClassifier;
                    requestHumanLoopConfig_humanLoopConfig_DataAttributesIsNull = false;
                }
                 // determine if requestHumanLoopConfig_humanLoopConfig_DataAttributes should be set to null
                if (requestHumanLoopConfig_humanLoopConfig_DataAttributesIsNull)
                {
                    requestHumanLoopConfig_humanLoopConfig_DataAttributes = null;
                }
                if (requestHumanLoopConfig_humanLoopConfig_DataAttributes != null)
                {
                    request.HumanLoopConfig.DataAttributes = requestHumanLoopConfig_humanLoopConfig_DataAttributes;
                    requestHumanLoopConfigIsNull = false;
                }
                 // determine if request.HumanLoopConfig should be set to null
                if (requestHumanLoopConfigIsNull)
                {
                    request.HumanLoopConfig = null;
                }
                
                 // populate QueriesConfig
                var requestQueriesConfigIsNull = true;
                request.QueriesConfig = new Amazon.Textract.Model.QueriesConfig();
                List<Amazon.Textract.Model.Query> requestQueriesConfig_queriesConfig_Query = null;
                if (cmdletContext.QueriesConfig_Query != null)
                {
                    requestQueriesConfig_queriesConfig_Query = cmdletContext.QueriesConfig_Query;
                }
                if (requestQueriesConfig_queriesConfig_Query != null)
                {
                    request.QueriesConfig.Queries = requestQueriesConfig_queriesConfig_Query;
                    requestQueriesConfigIsNull = false;
                }
                 // determine if request.QueriesConfig should be set to null
                if (requestQueriesConfigIsNull)
                {
                    request.QueriesConfig = null;
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
        
        private Amazon.Textract.Model.AnalyzeDocumentResponse CallAWSServiceOperation(IAmazonTextract client, Amazon.Textract.Model.AnalyzeDocumentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Textract", "AnalyzeDocument");
            try
            {
                return client.AnalyzeDocumentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Textract.Model.Adapter> AdaptersConfig_Adapter { get; set; }
            public byte[] Document_Byte { get; set; }
            public System.String S3Object_Bucket { get; set; }
            public System.String S3Object_Name { get; set; }
            public System.String S3Object_Version { get; set; }
            public List<System.String> FeatureType { get; set; }
            public List<System.String> DataAttributes_ContentClassifier { get; set; }
            public System.String HumanLoopConfig_FlowDefinitionArn { get; set; }
            public System.String HumanLoopConfig_HumanLoopName { get; set; }
            public List<Amazon.Textract.Model.Query> QueriesConfig_Query { get; set; }
            public System.Func<Amazon.Textract.Model.AnalyzeDocumentResponse, InvokeTXTDocumentAnalysisCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Blocks;
        }
        
    }
}
