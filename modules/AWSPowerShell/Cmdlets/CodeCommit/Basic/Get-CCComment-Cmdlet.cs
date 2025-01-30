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
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;

namespace Amazon.PowerShell.Cmdlets.CC
{
    /// <summary>
    /// Returns the content of a comment made on a change, file, or commit in a repository.
    /// 
    /// 
    ///  <note><para>
    /// Reaction counts might include numbers from user identities who were deleted after
    /// the reaction was made. For a count of reactions from active identities, use GetCommentReactions.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CCComment")]
    [OutputType("Amazon.CodeCommit.Model.Comment")]
    [AWSCmdlet("Calls the AWS CodeCommit GetComment API operation.", Operation = new[] {"GetComment"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.GetCommentResponse))]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.Comment or Amazon.CodeCommit.Model.GetCommentResponse",
        "This cmdlet returns an Amazon.CodeCommit.Model.Comment object.",
        "The service call response (type Amazon.CodeCommit.Model.GetCommentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCCCommentCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CommentId
        /// <summary>
        /// <para>
        /// <para>The unique, system-generated ID of the comment. To get this ID, use <a>GetCommentsForComparedCommit</a>
        /// or <a>GetCommentsForPullRequest</a>.</para>
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
        public System.String CommentId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Comment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.GetCommentResponse).
        /// Specifying the name of a property of type Amazon.CodeCommit.Model.GetCommentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Comment";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CommentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CommentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CommentId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.GetCommentResponse, GetCCCommentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CommentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CommentId = this.CommentId;
            #if MODULAR
            if (this.CommentId == null && ParameterWasBound(nameof(this.CommentId)))
            {
                WriteWarning("You are passing $null as a value for parameter CommentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CodeCommit.Model.GetCommentRequest();
            
            if (cmdletContext.CommentId != null)
            {
                request.CommentId = cmdletContext.CommentId;
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
        
        private Amazon.CodeCommit.Model.GetCommentResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.GetCommentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "GetComment");
            try
            {
                #if DESKTOP
                return client.GetComment(request);
                #elif CORECLR
                return client.GetCommentAsync(request).GetAwaiter().GetResult();
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
            public System.String CommentId { get; set; }
            public System.Func<Amazon.CodeCommit.Model.GetCommentResponse, GetCCCommentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Comment;
        }
        
    }
}
