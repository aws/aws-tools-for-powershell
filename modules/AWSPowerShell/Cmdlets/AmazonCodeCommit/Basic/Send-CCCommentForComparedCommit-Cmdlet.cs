/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;

namespace Amazon.PowerShell.Cmdlets.CC
{
    /// <summary>
    /// Posts a comment on the comparison between two commits.
    /// </summary>
    [Cmdlet("Send", "CCCommentForComparedCommit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeCommit.Model.PostCommentForComparedCommitResponse")]
    [AWSCmdlet("Calls the AWS CodeCommit PostCommentForComparedCommit API operation.", Operation = new[] {"PostCommentForComparedCommit"})]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.PostCommentForComparedCommitResponse",
        "This cmdlet returns a Amazon.CodeCommit.Model.PostCommentForComparedCommitResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendCCCommentForComparedCommitCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        #region Parameter AfterCommitId
        /// <summary>
        /// <para>
        /// <para>To establish the directionality of the comparison, the full commit ID of the 'after'
        /// commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AfterCommitId { get; set; }
        #endregion
        
        #region Parameter BeforeCommitId
        /// <summary>
        /// <para>
        /// <para>To establish the directionality of the comparison, the full commit ID of the 'before'
        /// commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BeforeCommitId { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, client-generated idempotency token that when provided in a request, ensures
        /// the request cannot be repeated with a changed parameter. If a request is received
        /// with the same parameters and a token is included, the request will return information
        /// about the initial request that used that token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Content
        /// <summary>
        /// <para>
        /// <para>The content of the comment you want to make.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Content { get; set; }
        #endregion
        
        #region Parameter Location_FilePath
        /// <summary>
        /// <para>
        /// <para>The name of the file being compared, including its extension and subdirectory, if
        /// any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Location_FilePath { get; set; }
        #endregion
        
        #region Parameter Location_FilePosition
        /// <summary>
        /// <para>
        /// <para>The position of a change within a compared file, in line number format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 Location_FilePosition { get; set; }
        #endregion
        
        #region Parameter Location_RelativeFileVersion
        /// <summary>
        /// <para>
        /// <para>In a comparison of commits or a pull request, whether the change is in the 'before'
        /// or 'after' of that comparison.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeCommit.RelativeFileVersionEnum")]
        public Amazon.CodeCommit.RelativeFileVersionEnum Location_RelativeFileVersion { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository where you want to post a comment on the comparison between
        /// commits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RepositoryName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AfterCommitId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-CCCommentForComparedCommit (PostCommentForComparedCommit)"))
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
            
            context.AfterCommitId = this.AfterCommitId;
            context.BeforeCommitId = this.BeforeCommitId;
            context.ClientRequestToken = this.ClientRequestToken;
            context.Content = this.Content;
            context.Location_FilePath = this.Location_FilePath;
            if (ParameterWasBound("Location_FilePosition"))
                context.Location_FilePosition = this.Location_FilePosition;
            context.Location_RelativeFileVersion = this.Location_RelativeFileVersion;
            context.RepositoryName = this.RepositoryName;
            
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
            var request = new Amazon.CodeCommit.Model.PostCommentForComparedCommitRequest();
            
            if (cmdletContext.AfterCommitId != null)
            {
                request.AfterCommitId = cmdletContext.AfterCommitId;
            }
            if (cmdletContext.BeforeCommitId != null)
            {
                request.BeforeCommitId = cmdletContext.BeforeCommitId;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Content != null)
            {
                request.Content = cmdletContext.Content;
            }
            
             // populate Location
            bool requestLocationIsNull = true;
            request.Location = new Amazon.CodeCommit.Model.Location();
            System.String requestLocation_location_FilePath = null;
            if (cmdletContext.Location_FilePath != null)
            {
                requestLocation_location_FilePath = cmdletContext.Location_FilePath;
            }
            if (requestLocation_location_FilePath != null)
            {
                request.Location.FilePath = requestLocation_location_FilePath;
                requestLocationIsNull = false;
            }
            System.Int64? requestLocation_location_FilePosition = null;
            if (cmdletContext.Location_FilePosition != null)
            {
                requestLocation_location_FilePosition = cmdletContext.Location_FilePosition.Value;
            }
            if (requestLocation_location_FilePosition != null)
            {
                request.Location.FilePosition = requestLocation_location_FilePosition.Value;
                requestLocationIsNull = false;
            }
            Amazon.CodeCommit.RelativeFileVersionEnum requestLocation_location_RelativeFileVersion = null;
            if (cmdletContext.Location_RelativeFileVersion != null)
            {
                requestLocation_location_RelativeFileVersion = cmdletContext.Location_RelativeFileVersion;
            }
            if (requestLocation_location_RelativeFileVersion != null)
            {
                request.Location.RelativeFileVersion = requestLocation_location_RelativeFileVersion;
                requestLocationIsNull = false;
            }
             // determine if request.Location should be set to null
            if (requestLocationIsNull)
            {
                request.Location = null;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
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
        
        private Amazon.CodeCommit.Model.PostCommentForComparedCommitResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.PostCommentForComparedCommitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "PostCommentForComparedCommit");
            try
            {
                #if DESKTOP
                return client.PostCommentForComparedCommit(request);
                #elif CORECLR
                return client.PostCommentForComparedCommitAsync(request).GetAwaiter().GetResult();
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
            public System.String AfterCommitId { get; set; }
            public System.String BeforeCommitId { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String Content { get; set; }
            public System.String Location_FilePath { get; set; }
            public System.Int64? Location_FilePosition { get; set; }
            public Amazon.CodeCommit.RelativeFileVersionEnum Location_RelativeFileVersion { get; set; }
            public System.String RepositoryName { get; set; }
        }
        
    }
}
