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
using Amazon.WorkDocs;
using Amazon.WorkDocs.Model;

namespace Amazon.PowerShell.Cmdlets.WD
{
    /// <summary>
    /// Adds a new comment to the specified document version.
    /// </summary>
    [Cmdlet("New", "WDComment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkDocs.Model.Comment")]
    [AWSCmdlet("Calls the Amazon WorkDocs CreateComment API operation.", Operation = new[] {"CreateComment"}, SelectReturnType = typeof(Amazon.WorkDocs.Model.CreateCommentResponse))]
    [AWSCmdletOutput("Amazon.WorkDocs.Model.Comment or Amazon.WorkDocs.Model.CreateCommentResponse",
        "This cmdlet returns an Amazon.WorkDocs.Model.Comment object.",
        "The service call response (type Amazon.WorkDocs.Model.CreateCommentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewWDCommentCmdlet : AmazonWorkDocsClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter DocumentId
        /// <summary>
        /// <para>
        /// <para>The ID of the document.</para>
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
        public System.String DocumentId { get; set; }
        #endregion
        
        #region Parameter NotifyCollaborator
        /// <summary>
        /// <para>
        /// <para>Set this parameter to TRUE to send an email out to the document collaborators after
        /// the comment is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotifyCollaborators")]
        public System.Boolean? NotifyCollaborator { get; set; }
        #endregion
        
        #region Parameter ParentId
        /// <summary>
        /// <para>
        /// <para>The ID of the parent comment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentId { get; set; }
        #endregion
        
        #region Parameter Text
        /// <summary>
        /// <para>
        /// <para>The text of the comment.</para>
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
        public System.String Text { get; set; }
        #endregion
        
        #region Parameter ThreadId
        /// <summary>
        /// <para>
        /// <para>The ID of the root comment in the thread.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ThreadId { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// <para>The ID of the document version.</para>
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
        public System.String VersionId { get; set; }
        #endregion
        
        #region Parameter Visibility
        /// <summary>
        /// <para>
        /// <para>The visibility of the comment. Options are either PRIVATE, where the comment is visible
        /// only to the comment author and document owner and co-owners, or PUBLIC, where the
        /// comment is visible to document owners, co-owners, and contributors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkDocs.CommentVisibilityType")]
        public Amazon.WorkDocs.CommentVisibilityType Visibility { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Comment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkDocs.Model.CreateCommentResponse).
        /// Specifying the name of a property of type Amazon.WorkDocs.Model.CreateCommentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Comment";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VersionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WDComment (CreateComment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkDocs.Model.CreateCommentResponse, NewWDCommentCmdlet>(Select) ??
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
            context.AuthenticationToken = this.AuthenticationToken;
            context.DocumentId = this.DocumentId;
            #if MODULAR
            if (this.DocumentId == null && ParameterWasBound(nameof(this.DocumentId)))
            {
                WriteWarning("You are passing $null as a value for parameter DocumentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NotifyCollaborator = this.NotifyCollaborator;
            context.ParentId = this.ParentId;
            context.Text = this.Text;
            #if MODULAR
            if (this.Text == null && ParameterWasBound(nameof(this.Text)))
            {
                WriteWarning("You are passing $null as a value for parameter Text which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ThreadId = this.ThreadId;
            context.VersionId = this.VersionId;
            #if MODULAR
            if (this.VersionId == null && ParameterWasBound(nameof(this.VersionId)))
            {
                WriteWarning("You are passing $null as a value for parameter VersionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Visibility = this.Visibility;
            
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
            var request = new Amazon.WorkDocs.Model.CreateCommentRequest();
            
            if (cmdletContext.AuthenticationToken != null)
            {
                request.AuthenticationToken = cmdletContext.AuthenticationToken;
            }
            if (cmdletContext.DocumentId != null)
            {
                request.DocumentId = cmdletContext.DocumentId;
            }
            if (cmdletContext.NotifyCollaborator != null)
            {
                request.NotifyCollaborators = cmdletContext.NotifyCollaborator.Value;
            }
            if (cmdletContext.ParentId != null)
            {
                request.ParentId = cmdletContext.ParentId;
            }
            if (cmdletContext.Text != null)
            {
                request.Text = cmdletContext.Text;
            }
            if (cmdletContext.ThreadId != null)
            {
                request.ThreadId = cmdletContext.ThreadId;
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
            }
            if (cmdletContext.Visibility != null)
            {
                request.Visibility = cmdletContext.Visibility;
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
        
        private Amazon.WorkDocs.Model.CreateCommentResponse CallAWSServiceOperation(IAmazonWorkDocs client, Amazon.WorkDocs.Model.CreateCommentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkDocs", "CreateComment");
            try
            {
                #if DESKTOP
                return client.CreateComment(request);
                #elif CORECLR
                return client.CreateCommentAsync(request).GetAwaiter().GetResult();
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
            public System.String DocumentId { get; set; }
            public System.Boolean? NotifyCollaborator { get; set; }
            public System.String ParentId { get; set; }
            public System.String Text { get; set; }
            public System.String ThreadId { get; set; }
            public System.String VersionId { get; set; }
            public Amazon.WorkDocs.CommentVisibilityType Visibility { get; set; }
            public System.Func<Amazon.WorkDocs.Model.CreateCommentResponse, NewWDCommentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Comment;
        }
        
    }
}
