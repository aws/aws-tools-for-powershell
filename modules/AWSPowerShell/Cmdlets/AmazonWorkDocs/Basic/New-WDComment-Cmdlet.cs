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
    /// Adds a new comment to the specified document version.
    /// </summary>
    [Cmdlet("New", "WDComment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkDocs.Model.Comment")]
    [AWSCmdlet("Invokes the CreateComment operation against Amazon WorkDocs.", Operation = new[] {"CreateComment"})]
    [AWSCmdletOutput("Amazon.WorkDocs.Model.Comment",
        "This cmdlet returns a Comment object.",
        "The service call response (type Amazon.WorkDocs.Model.CreateCommentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewWDCommentCmdlet : AmazonWorkDocsClientCmdlet, IExecutor
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
        
        #region Parameter DocumentId
        /// <summary>
        /// <para>
        /// <para>The ID of the document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DocumentId { get; set; }
        #endregion
        
        #region Parameter NotifyCollaborator
        /// <summary>
        /// <para>
        /// <para>Set this parameter to TRUE to send an email out to the document collaborators after
        /// the comment is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NotifyCollaborators")]
        public System.Boolean NotifyCollaborator { get; set; }
        #endregion
        
        #region Parameter ParentId
        /// <summary>
        /// <para>
        /// <para>The ID of the parent comment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ParentId { get; set; }
        #endregion
        
        #region Parameter Text
        /// <summary>
        /// <para>
        /// <para>The text of the comment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Text { get; set; }
        #endregion
        
        #region Parameter ThreadId
        /// <summary>
        /// <para>
        /// <para>The ID of the root comment in the thread.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ThreadId { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// <para>The ID of the document version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.WorkDocs.CommentVisibilityType")]
        public Amazon.WorkDocs.CommentVisibilityType Visibility { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VersionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WDComment (CreateComment)"))
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
            context.DocumentId = this.DocumentId;
            if (ParameterWasBound("NotifyCollaborator"))
                context.NotifyCollaborators = this.NotifyCollaborator;
            context.ParentId = this.ParentId;
            context.Text = this.Text;
            context.ThreadId = this.ThreadId;
            context.VersionId = this.VersionId;
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
            if (cmdletContext.NotifyCollaborators != null)
            {
                request.NotifyCollaborators = cmdletContext.NotifyCollaborators.Value;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Comment;
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
        
        private Amazon.WorkDocs.Model.CreateCommentResponse CallAWSServiceOperation(IAmazonWorkDocs client, Amazon.WorkDocs.Model.CreateCommentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkDocs", "CreateComment");
            #if DESKTOP
            return client.CreateComment(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateCommentAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AuthenticationToken { get; set; }
            public System.String DocumentId { get; set; }
            public System.Boolean? NotifyCollaborators { get; set; }
            public System.String ParentId { get; set; }
            public System.String Text { get; set; }
            public System.String ThreadId { get; set; }
            public System.String VersionId { get; set; }
            public Amazon.WorkDocs.CommentVisibilityType Visibility { get; set; }
        }
        
    }
}
