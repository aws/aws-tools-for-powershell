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
using Amazon.WorkDocs;
using Amazon.WorkDocs.Model;

namespace Amazon.PowerShell.Cmdlets.WD
{
    /// <summary>
    /// Creates a new document object and version object.
    /// 
    ///  
    /// <para>
    /// The client specifies the parent folder ID and name of the document to upload. The
    /// ID is optionally specified when creating a new version of an existing document. This
    /// is the first step to upload a document. Next, upload the document to the URL returned
    /// from the call, and then call <a>UpdateDocumentVersion</a>.
    /// </para><para>
    /// To cancel the document upload, call <a>AbortDocumentVersionUpload</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "WDDocumentVersionUpload", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkDocs.Model.InitiateDocumentVersionUploadResponse")]
    [AWSCmdlet("Calls the Amazon WorkDocs InitiateDocumentVersionUpload API operation.", Operation = new[] {"InitiateDocumentVersionUpload"}, SelectReturnType = typeof(Amazon.WorkDocs.Model.InitiateDocumentVersionUploadResponse))]
    [AWSCmdletOutput("Amazon.WorkDocs.Model.InitiateDocumentVersionUploadResponse",
        "This cmdlet returns an Amazon.WorkDocs.Model.InitiateDocumentVersionUploadResponse object containing multiple properties."
    )]
    public partial class StartWDDocumentVersionUploadCmdlet : AmazonWorkDocsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AuthenticationToken
        /// <summary>
        /// <para>
        /// <para>Amazon WorkDocs authentication token. Not required when using Amazon Web Services
        /// administrator credentials to access the API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthenticationToken { get; set; }
        #endregion
        
        #region Parameter ContentCreatedTimestamp
        /// <summary>
        /// <para>
        /// <para>The timestamp when the content of the document was originally created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ContentCreatedTimestamp { get; set; }
        #endregion
        
        #region Parameter ContentModifiedTimestamp
        /// <summary>
        /// <para>
        /// <para>The timestamp when the content of the document was modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ContentModifiedTimestamp { get; set; }
        #endregion
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The content type of the document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter DocumentSizeInByte
        /// <summary>
        /// <para>
        /// <para>The size of the document, in bytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentSizeInBytes")]
        public System.Int64? DocumentSizeInByte { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ParentFolderId
        /// <summary>
        /// <para>
        /// <para>The ID of the parent folder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentFolderId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkDocs.Model.InitiateDocumentVersionUploadResponse).
        /// Specifying the name of a property of type Amazon.WorkDocs.Model.InitiateDocumentVersionUploadResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-WDDocumentVersionUpload (InitiateDocumentVersionUpload)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkDocs.Model.InitiateDocumentVersionUploadResponse, StartWDDocumentVersionUploadCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthenticationToken = this.AuthenticationToken;
            context.ContentCreatedTimestamp = this.ContentCreatedTimestamp;
            context.ContentModifiedTimestamp = this.ContentModifiedTimestamp;
            context.ContentType = this.ContentType;
            context.DocumentSizeInByte = this.DocumentSizeInByte;
            context.Id = this.Id;
            context.Name = this.Name;
            context.ParentFolderId = this.ParentFolderId;
            
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
            var request = new Amazon.WorkDocs.Model.InitiateDocumentVersionUploadRequest();
            
            if (cmdletContext.AuthenticationToken != null)
            {
                request.AuthenticationToken = cmdletContext.AuthenticationToken;
            }
            if (cmdletContext.ContentCreatedTimestamp != null)
            {
                request.ContentCreatedTimestamp = cmdletContext.ContentCreatedTimestamp.Value;
            }
            if (cmdletContext.ContentModifiedTimestamp != null)
            {
                request.ContentModifiedTimestamp = cmdletContext.ContentModifiedTimestamp.Value;
            }
            if (cmdletContext.ContentType != null)
            {
                request.ContentType = cmdletContext.ContentType;
            }
            if (cmdletContext.DocumentSizeInByte != null)
            {
                request.DocumentSizeInBytes = cmdletContext.DocumentSizeInByte.Value;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ParentFolderId != null)
            {
                request.ParentFolderId = cmdletContext.ParentFolderId;
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
        
        private Amazon.WorkDocs.Model.InitiateDocumentVersionUploadResponse CallAWSServiceOperation(IAmazonWorkDocs client, Amazon.WorkDocs.Model.InitiateDocumentVersionUploadRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkDocs", "InitiateDocumentVersionUpload");
            try
            {
                return client.InitiateDocumentVersionUploadAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AuthenticationToken { get; set; }
            public System.DateTime? ContentCreatedTimestamp { get; set; }
            public System.DateTime? ContentModifiedTimestamp { get; set; }
            public System.String ContentType { get; set; }
            public System.Int64? DocumentSizeInByte { get; set; }
            public System.String Id { get; set; }
            public System.String Name { get; set; }
            public System.String ParentFolderId { get; set; }
            public System.Func<Amazon.WorkDocs.Model.InitiateDocumentVersionUploadResponse, StartWDDocumentVersionUploadCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
