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
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CC
{
    /// <summary>
    /// Posts a comment on the comparison between two commits.
    /// </summary>
    [Cmdlet("Send", "CCCommentForComparedCommit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeCommit.Model.PostCommentForComparedCommitResponse")]
    [AWSCmdlet("Calls the AWS CodeCommit PostCommentForComparedCommit API operation.", Operation = new[] {"PostCommentForComparedCommit"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.PostCommentForComparedCommitResponse))]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.PostCommentForComparedCommitResponse",
        "This cmdlet returns an Amazon.CodeCommit.Model.PostCommentForComparedCommitResponse object containing multiple properties."
    )]
    public partial class SendCCCommentForComparedCommitCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AfterCommitId
        /// <summary>
        /// <para>
        /// <para>To establish the directionality of the comparison, the full commit ID of the after
        /// commit.</para>
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
        public System.String AfterCommitId { get; set; }
        #endregion
        
        #region Parameter BeforeCommitId
        /// <summary>
        /// <para>
        /// <para>To establish the directionality of the comparison, the full commit ID of the before
        /// commit. Required for commenting on any commit unless that commit is the initial commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BeforeCommitId { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, client-generated idempotency token that, when provided in a request, ensures
        /// the request cannot be repeated with a changed parameter. If a request is received
        /// with the same parameters and a token is included, the request returns information
        /// about the initial request that used that token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Content
        /// <summary>
        /// <para>
        /// <para>The content of the comment you want to make.</para>
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
        public System.String Content { get; set; }
        #endregion
        
        #region Parameter Location_FilePath
        /// <summary>
        /// <para>
        /// <para>The name of the file being compared, including its extension and subdirectory, if
        /// any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location_FilePath { get; set; }
        #endregion
        
        #region Parameter Location_FilePosition
        /// <summary>
        /// <para>
        /// <para>The position of a change in a compared file, in line number format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Location_FilePosition { get; set; }
        #endregion
        
        #region Parameter Location_RelativeFileVersion
        /// <summary>
        /// <para>
        /// <para>In a comparison of commits or a pull request, whether the change is in the before
        /// or after of that comparison.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.PostCommentForComparedCommitResponse).
        /// Specifying the name of a property of type Amazon.CodeCommit.Model.PostCommentForComparedCommitResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AfterCommitId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-CCCommentForComparedCommit (PostCommentForComparedCommit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.PostCommentForComparedCommitResponse, SendCCCommentForComparedCommitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AfterCommitId = this.AfterCommitId;
            #if MODULAR
            if (this.AfterCommitId == null && ParameterWasBound(nameof(this.AfterCommitId)))
            {
                WriteWarning("You are passing $null as a value for parameter AfterCommitId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BeforeCommitId = this.BeforeCommitId;
            context.ClientRequestToken = this.ClientRequestToken;
            context.Content = this.Content;
            #if MODULAR
            if (this.Content == null && ParameterWasBound(nameof(this.Content)))
            {
                WriteWarning("You are passing $null as a value for parameter Content which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Location_FilePath = this.Location_FilePath;
            context.Location_FilePosition = this.Location_FilePosition;
            context.Location_RelativeFileVersion = this.Location_RelativeFileVersion;
            context.RepositoryName = this.RepositoryName;
            #if MODULAR
            if (this.RepositoryName == null && ParameterWasBound(nameof(this.RepositoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter RepositoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var requestLocationIsNull = true;
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
        
        private Amazon.CodeCommit.Model.PostCommentForComparedCommitResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.PostCommentForComparedCommitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "PostCommentForComparedCommit");
            try
            {
                return client.PostCommentForComparedCommitAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.CodeCommit.Model.PostCommentForComparedCommitResponse, SendCCCommentForComparedCommitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
