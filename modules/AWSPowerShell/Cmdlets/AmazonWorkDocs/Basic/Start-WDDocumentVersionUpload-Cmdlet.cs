/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the Amazon WorkDocs InitiateDocumentVersionUpload API operation.", Operation = new[] {"InitiateDocumentVersionUpload"})]
    [AWSCmdletOutput("Amazon.WorkDocs.Model.InitiateDocumentVersionUploadResponse",
        "This cmdlet returns a Amazon.WorkDocs.Model.InitiateDocumentVersionUploadResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartWDDocumentVersionUploadCmdlet : AmazonWorkDocsClientCmdlet, IExecutor
    {
        
        #region Parameter AuthenticationToken
        /// <summary>
        /// <para>
        /// <para>Amazon WorkDocs authentication token. This field should not be set when using administrative
        /// API actions, as in accessing the API using AWS credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AuthenticationToken { get; set; }
        #endregion
        
        #region Parameter ContentCreatedTimestamp
        /// <summary>
        /// <para>
        /// <para>The time stamp when the content of the document was originally created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ContentCreatedTimestamp { get; set; }
        #endregion
        
        #region Parameter ContentModifiedTimestamp
        /// <summary>
        /// <para>
        /// <para>The time stamp when the content of the document was modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ContentModifiedTimestamp { get; set; }
        #endregion
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The content type of the document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter DocumentSizeInByte
        /// <summary>
        /// <para>
        /// <para>The size of the document, in bytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DocumentSizeInBytes")]
        public System.Int64 DocumentSizeInByte { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ParentFolderId
        /// <summary>
        /// <para>
        /// <para>The ID of the parent folder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ParentFolderId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Id", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-WDDocumentVersionUpload (InitiateDocumentVersionUpload)"))
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
            
            context.AuthenticationToken = this.AuthenticationToken;
            if (ParameterWasBound("ContentCreatedTimestamp"))
                context.ContentCreatedTimestamp = this.ContentCreatedTimestamp;
            if (ParameterWasBound("ContentModifiedTimestamp"))
                context.ContentModifiedTimestamp = this.ContentModifiedTimestamp;
            context.ContentType = this.ContentType;
            if (ParameterWasBound("DocumentSizeInByte"))
                context.DocumentSizeInBytes = this.DocumentSizeInByte;
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
            if (cmdletContext.DocumentSizeInBytes != null)
            {
                request.DocumentSizeInBytes = cmdletContext.DocumentSizeInBytes.Value;
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
        
        private Amazon.WorkDocs.Model.InitiateDocumentVersionUploadResponse CallAWSServiceOperation(IAmazonWorkDocs client, Amazon.WorkDocs.Model.InitiateDocumentVersionUploadRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkDocs", "InitiateDocumentVersionUpload");
            try
            {
                #if DESKTOP
                return client.InitiateDocumentVersionUpload(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.InitiateDocumentVersionUploadAsync(request);
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
            public System.String AuthenticationToken { get; set; }
            public System.DateTime? ContentCreatedTimestamp { get; set; }
            public System.DateTime? ContentModifiedTimestamp { get; set; }
            public System.String ContentType { get; set; }
            public System.Int64? DocumentSizeInBytes { get; set; }
            public System.String Id { get; set; }
            public System.String Name { get; set; }
            public System.String ParentFolderId { get; set; }
        }
        
    }
}
