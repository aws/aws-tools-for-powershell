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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Updates information about the content.
    /// </summary>
    [Cmdlet("Update", "QCContent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.ContentData")]
    [AWSCmdlet("Calls the Amazon Q Connect UpdateContent API operation.", Operation = new[] {"UpdateContent"}, SelectReturnType = typeof(Amazon.QConnect.Model.UpdateContentResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.ContentData or Amazon.QConnect.Model.UpdateContentResponse",
        "This cmdlet returns an Amazon.QConnect.Model.ContentData object.",
        "The service call response (type Amazon.QConnect.Model.UpdateContentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateQCContentCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContentId
        /// <summary>
        /// <para>
        /// <para>The identifier of the content. Can be either the ID or the ARN. URLs cannot contain
        /// the ARN.</para>
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
        public System.String ContentId { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The identifier of the knowledge base. This should not be a QUICK_RESPONSES type knowledge
        /// base. Can be either the ID or the ARN</para>
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
        public System.String KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>A key/value map to store attributes without affecting tagging or recommendations.
        /// For example, when synchronizing data between an external system and Amazon Q in Connect,
        /// you can store an external version identifier as metadata to utilize for determining
        /// drift.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Metadata { get; set; }
        #endregion
        
        #region Parameter OverrideLinkOutUri
        /// <summary>
        /// <para>
        /// <para>The URI for the article. If the knowledge base has a templateUri, setting this argument
        /// overrides it for this piece of content. To remove an existing <c>overrideLinkOurUri</c>,
        /// exclude this argument and set <c>removeOverrideLinkOutUri</c> to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OverrideLinkOutUri { get; set; }
        #endregion
        
        #region Parameter RemoveOverrideLinkOutUri
        /// <summary>
        /// <para>
        /// <para>Unset the existing <c>overrideLinkOutUri</c> if it exists.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RemoveOverrideLinkOutUri { get; set; }
        #endregion
        
        #region Parameter RevisionId
        /// <summary>
        /// <para>
        /// <para>The <c>revisionId</c> of the content resource to update, taken from an earlier call
        /// to <c>GetContent</c>, <c>GetContentSummary</c>, <c>SearchContent</c>, or <c>ListContents</c>.
        /// If included, this argument acts as an optimistic lock to ensure content was not modified
        /// since it was last read. If it has been modified, this API throws a <c>PreconditionFailedException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionId { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>The title of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter UploadId
        /// <summary>
        /// <para>
        /// <para>A pointer to the uploaded asset. This value is returned by <a href="https://docs.aws.amazon.com/amazon-q-connect/latest/APIReference/API_StartContentUpload.html">StartContentUpload</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UploadId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Content'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.UpdateContentResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.UpdateContentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Content";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QCContent (UpdateContent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.UpdateContentResponse, UpdateQCContentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContentId = this.ContentId;
            #if MODULAR
            if (this.ContentId == null && ParameterWasBound(nameof(this.ContentId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Metadata != null)
            {
                context.Metadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Metadata.Keys)
                {
                    context.Metadata.Add((String)hashKey, (System.String)(this.Metadata[hashKey]));
                }
            }
            context.OverrideLinkOutUri = this.OverrideLinkOutUri;
            context.RemoveOverrideLinkOutUri = this.RemoveOverrideLinkOutUri;
            context.RevisionId = this.RevisionId;
            context.Title = this.Title;
            context.UploadId = this.UploadId;
            
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
            var request = new Amazon.QConnect.Model.UpdateContentRequest();
            
            if (cmdletContext.ContentId != null)
            {
                request.ContentId = cmdletContext.ContentId;
            }
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
            }
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            if (cmdletContext.OverrideLinkOutUri != null)
            {
                request.OverrideLinkOutUri = cmdletContext.OverrideLinkOutUri;
            }
            if (cmdletContext.RemoveOverrideLinkOutUri != null)
            {
                request.RemoveOverrideLinkOutUri = cmdletContext.RemoveOverrideLinkOutUri.Value;
            }
            if (cmdletContext.RevisionId != null)
            {
                request.RevisionId = cmdletContext.RevisionId;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
            }
            if (cmdletContext.UploadId != null)
            {
                request.UploadId = cmdletContext.UploadId;
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
        
        private Amazon.QConnect.Model.UpdateContentResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.UpdateContentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "UpdateContent");
            try
            {
                #if DESKTOP
                return client.UpdateContent(request);
                #elif CORECLR
                return client.UpdateContentAsync(request).GetAwaiter().GetResult();
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
            public System.String ContentId { get; set; }
            public System.String KnowledgeBaseId { get; set; }
            public Dictionary<System.String, System.String> Metadata { get; set; }
            public System.String OverrideLinkOutUri { get; set; }
            public System.Boolean? RemoveOverrideLinkOutUri { get; set; }
            public System.String RevisionId { get; set; }
            public System.String Title { get; set; }
            public System.String UploadId { get; set; }
            public System.Func<Amazon.QConnect.Model.UpdateContentResponse, UpdateQCContentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Content;
        }
        
    }
}
