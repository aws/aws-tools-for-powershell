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
using Amazon.CodeGuruReviewer;
using Amazon.CodeGuruReviewer.Model;

namespace Amazon.PowerShell.Cmdlets.CGR
{
    /// <summary>
    /// Use to create a code review with a <a href="https://docs.aws.amazon.com/codeguru/latest/reviewer-api/API_CodeReviewType.html">CodeReviewType</a>
    /// of <c>RepositoryAnalysis</c>. This type of code review analyzes all code under a specified
    /// branch in an associated repository. <c>PullRequest</c> code reviews are automatically
    /// triggered by a pull request.
    /// </summary>
    [Cmdlet("New", "CGRCodeReview", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeGuruReviewer.Model.CodeReview")]
    [AWSCmdlet("Calls the Amazon CodeGuru Reviewer CreateCodeReview API operation.", Operation = new[] {"CreateCodeReview"}, SelectReturnType = typeof(Amazon.CodeGuruReviewer.Model.CreateCodeReviewResponse))]
    [AWSCmdletOutput("Amazon.CodeGuruReviewer.Model.CodeReview or Amazon.CodeGuruReviewer.Model.CreateCodeReviewResponse",
        "This cmdlet returns an Amazon.CodeGuruReviewer.Model.CodeReview object.",
        "The service call response (type Amazon.CodeGuruReviewer.Model.CreateCodeReviewResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCGRCodeReviewCmdlet : AmazonCodeGuruReviewerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Type_AnalysisType
        /// <summary>
        /// <para>
        /// <para>They types of analysis performed during a repository analysis or a pull request review.
        /// You can specify either <c>Security</c>, <c>CodeQuality</c>, or both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Type_AnalysisTypes")]
        public System.String[] Type_AnalysisType { get; set; }
        #endregion
        
        #region Parameter Type_RepositoryAnalysis_RepositoryHead_BranchName
        /// <summary>
        /// <para>
        /// <para>The name of the branch in an associated repository. The <c>RepositoryHeadSourceCodeType</c>
        /// specifies the tip of this branch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RepositoryHead_BranchName")]
        public System.String Type_RepositoryAnalysis_RepositoryHead_BranchName { get; set; }
        #endregion
        
        #region Parameter Type_RepositoryAnalysis_SourceCodeType_RepositoryHead_BranchName
        /// <summary>
        /// <para>
        /// <para>The name of the branch in an associated repository. The <c>RepositoryHeadSourceCodeType</c>
        /// specifies the tip of this branch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceCodeType_RepositoryHead_BranchName")]
        public System.String Type_RepositoryAnalysis_SourceCodeType_RepositoryHead_BranchName { get; set; }
        #endregion
        
        #region Parameter Details_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket used for associating a new S3 repository. It must begin
        /// with <c>codeguru-reviewer-</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_BucketName")]
        public System.String Details_BucketName { get; set; }
        #endregion
        
        #region Parameter CodeArtifacts_BuildArtifactsObjectKey
        /// <summary>
        /// <para>
        /// <para>The S3 object key for a build artifacts .zip file that contains .jar or .class files.
        /// This is required for a code review with security analysis. For more information, see
        /// <a href="https://docs.aws.amazon.com/codeguru/latest/reviewer-ug/working-with-cicd.html">Create
        /// code reviews with GitHub Actions</a> in the <i>Amazon CodeGuru Reviewer User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts_BuildArtifactsObjectKey")]
        public System.String CodeArtifacts_BuildArtifactsObjectKey { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Amazon CodeGuru Reviewer uses this value to prevent the accidental creation of duplicate
        /// code reviews if there are failures and retries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter BranchDiff_DestinationBranchName
        /// <summary>
        /// <para>
        /// <para>The destination branch for a diff in an associated repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Type_RepositoryAnalysis_SourceCodeType_BranchDiff_DestinationBranchName")]
        public System.String BranchDiff_DestinationBranchName { get; set; }
        #endregion
        
        #region Parameter CommitDiff_DestinationCommit
        /// <summary>
        /// <para>
        /// <para>The SHA of the destination commit used to generate a commit diff. This field is required
        /// for a pull request code review.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Type_RepositoryAnalysis_SourceCodeType_CommitDiff_DestinationCommit")]
        public System.String CommitDiff_DestinationCommit { get; set; }
        #endregion
        
        #region Parameter CommitDiff_MergeBaseCommit
        /// <summary>
        /// <para>
        /// <para>The SHA of the merge base of a commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Type_RepositoryAnalysis_SourceCodeType_CommitDiff_MergeBaseCommit")]
        public System.String CommitDiff_MergeBaseCommit { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the code review. The name of each code review in your Amazon Web Services
        /// account must be unique.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter EventInfo_Name
        /// <summary>
        /// <para>
        /// <para>The name of the event. The possible names are <c>pull_request</c>, <c>workflow_dispatch</c>,
        /// <c>schedule</c>, and <c>push</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo_Name")]
        public System.String EventInfo_Name { get; set; }
        #endregion
        
        #region Parameter S3BucketRepository_Name
        /// <summary>
        /// <para>
        /// <para>The name of the repository when the <c>ProviderType</c> is <c>S3Bucket</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Name")]
        public System.String S3BucketRepository_Name { get; set; }
        #endregion
        
        #region Parameter RepositoryAssociationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the <a href="https://docs.aws.amazon.com/codeguru/latest/reviewer-api/API_RepositoryAssociation.html">RepositoryAssociation</a>
        /// object. You can retrieve this ARN by calling <a href="https://docs.aws.amazon.com/codeguru/latest/reviewer-api/API_ListRepositoryAssociations.html">ListRepositoryAssociations</a>.</para><para>A code review can only be created on an associated repository. This is the ARN of
        /// the associated repository.</para>
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
        public System.String RepositoryAssociationArn { get; set; }
        #endregion
        
        #region Parameter RequestMetadata_Requester
        /// <summary>
        /// <para>
        /// <para>An identifier, such as a name or account ID, that is associated with the requester.
        /// The <c>Requester</c> is used to capture the <c>author/actor</c> name of the event
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Type_RepositoryAnalysis_SourceCodeType_RequestMetadata_Requester")]
        public System.String RequestMetadata_Requester { get; set; }
        #endregion
        
        #region Parameter RequestMetadata_RequestId
        /// <summary>
        /// <para>
        /// <para>The ID of the request. This is required for a pull request code review.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Type_RepositoryAnalysis_SourceCodeType_RequestMetadata_RequestId")]
        public System.String RequestMetadata_RequestId { get; set; }
        #endregion
        
        #region Parameter BranchDiff_SourceBranchName
        /// <summary>
        /// <para>
        /// <para>The source branch for a diff in an associated repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Type_RepositoryAnalysis_SourceCodeType_BranchDiff_SourceBranchName")]
        public System.String BranchDiff_SourceBranchName { get; set; }
        #endregion
        
        #region Parameter CodeArtifacts_SourceCodeArtifactsObjectKey
        /// <summary>
        /// <para>
        /// <para>The S3 object key for a source code .zip file. This is required for all code reviews.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts_SourceCodeArtifactsObjectKey")]
        public System.String CodeArtifacts_SourceCodeArtifactsObjectKey { get; set; }
        #endregion
        
        #region Parameter CommitDiff_SourceCommit
        /// <summary>
        /// <para>
        /// <para>The SHA of the source commit used to generate a commit diff. This field is required
        /// for a pull request code review.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Type_RepositoryAnalysis_SourceCodeType_CommitDiff_SourceCommit")]
        public System.String CommitDiff_SourceCommit { get; set; }
        #endregion
        
        #region Parameter EventInfo_State
        /// <summary>
        /// <para>
        /// <para>The state of an event. The state might be open, closed, or another state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo_State")]
        public System.String EventInfo_State { get; set; }
        #endregion
        
        #region Parameter RequestMetadata_VendorName
        /// <summary>
        /// <para>
        /// <para>The name of the repository vendor used to upload code to an S3 bucket for a CI/CD
        /// code review. For example, if code and artifacts are uploaded to an S3 bucket for a
        /// CI/CD code review by GitHub scripts from a GitHub repository, then the repository
        /// association's <c>ProviderType</c> is <c>S3Bucket</c> and the CI/CD repository vendor
        /// name is GitHub. For more information, see the definition for <c>ProviderType</c> in
        /// <a href="https://docs.aws.amazon.com/codeguru/latest/reviewer-api/API_RepositoryAssociation.html">RepositoryAssociation</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Type_RepositoryAnalysis_SourceCodeType_RequestMetadata_VendorName")]
        [AWSConstantClassSource("Amazon.CodeGuruReviewer.VendorName")]
        public Amazon.CodeGuruReviewer.VendorName RequestMetadata_VendorName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CodeReview'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeGuruReviewer.Model.CreateCodeReviewResponse).
        /// Specifying the name of a property of type Amazon.CodeGuruReviewer.Model.CreateCodeReviewResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CodeReview";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CGRCodeReview (CreateCodeReview)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeGuruReviewer.Model.CreateCodeReviewResponse, NewCGRCodeReviewCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RepositoryAssociationArn = this.RepositoryAssociationArn;
            #if MODULAR
            if (this.RepositoryAssociationArn == null && ParameterWasBound(nameof(this.RepositoryAssociationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RepositoryAssociationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Type_AnalysisType != null)
            {
                context.Type_AnalysisType = new List<System.String>(this.Type_AnalysisType);
            }
            context.Type_RepositoryAnalysis_RepositoryHead_BranchName = this.Type_RepositoryAnalysis_RepositoryHead_BranchName;
            context.BranchDiff_DestinationBranchName = this.BranchDiff_DestinationBranchName;
            context.BranchDiff_SourceBranchName = this.BranchDiff_SourceBranchName;
            context.CommitDiff_DestinationCommit = this.CommitDiff_DestinationCommit;
            context.CommitDiff_MergeBaseCommit = this.CommitDiff_MergeBaseCommit;
            context.CommitDiff_SourceCommit = this.CommitDiff_SourceCommit;
            context.Type_RepositoryAnalysis_SourceCodeType_RepositoryHead_BranchName = this.Type_RepositoryAnalysis_SourceCodeType_RepositoryHead_BranchName;
            context.EventInfo_Name = this.EventInfo_Name;
            context.EventInfo_State = this.EventInfo_State;
            context.RequestMetadata_Requester = this.RequestMetadata_Requester;
            context.RequestMetadata_RequestId = this.RequestMetadata_RequestId;
            context.RequestMetadata_VendorName = this.RequestMetadata_VendorName;
            context.Details_BucketName = this.Details_BucketName;
            context.CodeArtifacts_BuildArtifactsObjectKey = this.CodeArtifacts_BuildArtifactsObjectKey;
            context.CodeArtifacts_SourceCodeArtifactsObjectKey = this.CodeArtifacts_SourceCodeArtifactsObjectKey;
            context.S3BucketRepository_Name = this.S3BucketRepository_Name;
            
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
            var request = new Amazon.CodeGuruReviewer.Model.CreateCodeReviewRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RepositoryAssociationArn != null)
            {
                request.RepositoryAssociationArn = cmdletContext.RepositoryAssociationArn;
            }
            
             // populate Type
            var requestTypeIsNull = true;
            request.Type = new Amazon.CodeGuruReviewer.Model.CodeReviewType();
            List<System.String> requestType_type_AnalysisType = null;
            if (cmdletContext.Type_AnalysisType != null)
            {
                requestType_type_AnalysisType = cmdletContext.Type_AnalysisType;
            }
            if (requestType_type_AnalysisType != null)
            {
                request.Type.AnalysisTypes = requestType_type_AnalysisType;
                requestTypeIsNull = false;
            }
            Amazon.CodeGuruReviewer.Model.RepositoryAnalysis requestType_type_RepositoryAnalysis = null;
            
             // populate RepositoryAnalysis
            var requestType_type_RepositoryAnalysisIsNull = true;
            requestType_type_RepositoryAnalysis = new Amazon.CodeGuruReviewer.Model.RepositoryAnalysis();
            Amazon.CodeGuruReviewer.Model.RepositoryHeadSourceCodeType requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead = null;
            
             // populate RepositoryHead
            var requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHeadIsNull = true;
            requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead = new Amazon.CodeGuruReviewer.Model.RepositoryHeadSourceCodeType();
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead_type_RepositoryAnalysis_RepositoryHead_BranchName = null;
            if (cmdletContext.Type_RepositoryAnalysis_RepositoryHead_BranchName != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead_type_RepositoryAnalysis_RepositoryHead_BranchName = cmdletContext.Type_RepositoryAnalysis_RepositoryHead_BranchName;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead_type_RepositoryAnalysis_RepositoryHead_BranchName != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead.BranchName = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead_type_RepositoryAnalysis_RepositoryHead_BranchName;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHeadIsNull = false;
            }
             // determine if requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead should be set to null
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHeadIsNull)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead = null;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead != null)
            {
                requestType_type_RepositoryAnalysis.RepositoryHead = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead;
                requestType_type_RepositoryAnalysisIsNull = false;
            }
            Amazon.CodeGuruReviewer.Model.SourceCodeType requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType = null;
            
             // populate SourceCodeType
            var requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeTypeIsNull = true;
            requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType = new Amazon.CodeGuruReviewer.Model.SourceCodeType();
            Amazon.CodeGuruReviewer.Model.RepositoryHeadSourceCodeType requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RepositoryHead = null;
            
             // populate RepositoryHead
            var requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RepositoryHeadIsNull = true;
            requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RepositoryHead = new Amazon.CodeGuruReviewer.Model.RepositoryHeadSourceCodeType();
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RepositoryHead_type_RepositoryAnalysis_SourceCodeType_RepositoryHead_BranchName = null;
            if (cmdletContext.Type_RepositoryAnalysis_SourceCodeType_RepositoryHead_BranchName != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RepositoryHead_type_RepositoryAnalysis_SourceCodeType_RepositoryHead_BranchName = cmdletContext.Type_RepositoryAnalysis_SourceCodeType_RepositoryHead_BranchName;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RepositoryHead_type_RepositoryAnalysis_SourceCodeType_RepositoryHead_BranchName != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RepositoryHead.BranchName = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RepositoryHead_type_RepositoryAnalysis_SourceCodeType_RepositoryHead_BranchName;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RepositoryHeadIsNull = false;
            }
             // determine if requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RepositoryHead should be set to null
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RepositoryHeadIsNull)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RepositoryHead = null;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RepositoryHead != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType.RepositoryHead = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RepositoryHead;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeTypeIsNull = false;
            }
            Amazon.CodeGuruReviewer.Model.BranchDiffSourceCodeType requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff = null;
            
             // populate BranchDiff
            var requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiffIsNull = true;
            requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff = new Amazon.CodeGuruReviewer.Model.BranchDiffSourceCodeType();
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff_branchDiff_DestinationBranchName = null;
            if (cmdletContext.BranchDiff_DestinationBranchName != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff_branchDiff_DestinationBranchName = cmdletContext.BranchDiff_DestinationBranchName;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff_branchDiff_DestinationBranchName != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff.DestinationBranchName = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff_branchDiff_DestinationBranchName;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiffIsNull = false;
            }
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff_branchDiff_SourceBranchName = null;
            if (cmdletContext.BranchDiff_SourceBranchName != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff_branchDiff_SourceBranchName = cmdletContext.BranchDiff_SourceBranchName;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff_branchDiff_SourceBranchName != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff.SourceBranchName = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff_branchDiff_SourceBranchName;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiffIsNull = false;
            }
             // determine if requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff should be set to null
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiffIsNull)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff = null;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType.BranchDiff = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_BranchDiff;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeTypeIsNull = false;
            }
            Amazon.CodeGuruReviewer.Model.S3BucketRepository requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository = null;
            
             // populate S3BucketRepository
            var requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepositoryIsNull = true;
            requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository = new Amazon.CodeGuruReviewer.Model.S3BucketRepository();
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_s3BucketRepository_Name = null;
            if (cmdletContext.S3BucketRepository_Name != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_s3BucketRepository_Name = cmdletContext.S3BucketRepository_Name;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_s3BucketRepository_Name != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository.Name = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_s3BucketRepository_Name;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepositoryIsNull = false;
            }
            Amazon.CodeGuruReviewer.Model.S3RepositoryDetails requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details = null;
            
             // populate Details
            var requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_DetailsIsNull = true;
            requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details = new Amazon.CodeGuruReviewer.Model.S3RepositoryDetails();
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_details_BucketName = null;
            if (cmdletContext.Details_BucketName != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_details_BucketName = cmdletContext.Details_BucketName;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_details_BucketName != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details.BucketName = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_details_BucketName;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_DetailsIsNull = false;
            }
            Amazon.CodeGuruReviewer.Model.CodeArtifacts requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts = null;
            
             // populate CodeArtifacts
            var requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifactsIsNull = true;
            requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts = new Amazon.CodeGuruReviewer.Model.CodeArtifacts();
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts_codeArtifacts_BuildArtifactsObjectKey = null;
            if (cmdletContext.CodeArtifacts_BuildArtifactsObjectKey != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts_codeArtifacts_BuildArtifactsObjectKey = cmdletContext.CodeArtifacts_BuildArtifactsObjectKey;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts_codeArtifacts_BuildArtifactsObjectKey != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts.BuildArtifactsObjectKey = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts_codeArtifacts_BuildArtifactsObjectKey;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifactsIsNull = false;
            }
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts_codeArtifacts_SourceCodeArtifactsObjectKey = null;
            if (cmdletContext.CodeArtifacts_SourceCodeArtifactsObjectKey != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts_codeArtifacts_SourceCodeArtifactsObjectKey = cmdletContext.CodeArtifacts_SourceCodeArtifactsObjectKey;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts_codeArtifacts_SourceCodeArtifactsObjectKey != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts.SourceCodeArtifactsObjectKey = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts_codeArtifacts_SourceCodeArtifactsObjectKey;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifactsIsNull = false;
            }
             // determine if requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts should be set to null
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifactsIsNull)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts = null;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details.CodeArtifacts = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details_CodeArtifacts;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_DetailsIsNull = false;
            }
             // determine if requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details should be set to null
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_DetailsIsNull)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details = null;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository.Details = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository_Details;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepositoryIsNull = false;
            }
             // determine if requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository should be set to null
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepositoryIsNull)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository = null;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType.S3BucketRepository = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_S3BucketRepository;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeTypeIsNull = false;
            }
            Amazon.CodeGuruReviewer.Model.CommitDiffSourceCodeType requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff = null;
            
             // populate CommitDiff
            var requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiffIsNull = true;
            requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff = new Amazon.CodeGuruReviewer.Model.CommitDiffSourceCodeType();
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff_commitDiff_DestinationCommit = null;
            if (cmdletContext.CommitDiff_DestinationCommit != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff_commitDiff_DestinationCommit = cmdletContext.CommitDiff_DestinationCommit;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff_commitDiff_DestinationCommit != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff.DestinationCommit = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff_commitDiff_DestinationCommit;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiffIsNull = false;
            }
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff_commitDiff_MergeBaseCommit = null;
            if (cmdletContext.CommitDiff_MergeBaseCommit != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff_commitDiff_MergeBaseCommit = cmdletContext.CommitDiff_MergeBaseCommit;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff_commitDiff_MergeBaseCommit != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff.MergeBaseCommit = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff_commitDiff_MergeBaseCommit;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiffIsNull = false;
            }
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff_commitDiff_SourceCommit = null;
            if (cmdletContext.CommitDiff_SourceCommit != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff_commitDiff_SourceCommit = cmdletContext.CommitDiff_SourceCommit;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff_commitDiff_SourceCommit != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff.SourceCommit = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff_commitDiff_SourceCommit;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiffIsNull = false;
            }
             // determine if requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff should be set to null
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiffIsNull)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff = null;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType.CommitDiff = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_CommitDiff;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeTypeIsNull = false;
            }
            Amazon.CodeGuruReviewer.Model.RequestMetadata requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata = null;
            
             // populate RequestMetadata
            var requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadataIsNull = true;
            requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata = new Amazon.CodeGuruReviewer.Model.RequestMetadata();
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_requestMetadata_Requester = null;
            if (cmdletContext.RequestMetadata_Requester != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_requestMetadata_Requester = cmdletContext.RequestMetadata_Requester;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_requestMetadata_Requester != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata.Requester = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_requestMetadata_Requester;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadataIsNull = false;
            }
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_requestMetadata_RequestId = null;
            if (cmdletContext.RequestMetadata_RequestId != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_requestMetadata_RequestId = cmdletContext.RequestMetadata_RequestId;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_requestMetadata_RequestId != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata.RequestId = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_requestMetadata_RequestId;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadataIsNull = false;
            }
            Amazon.CodeGuruReviewer.VendorName requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_requestMetadata_VendorName = null;
            if (cmdletContext.RequestMetadata_VendorName != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_requestMetadata_VendorName = cmdletContext.RequestMetadata_VendorName;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_requestMetadata_VendorName != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata.VendorName = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_requestMetadata_VendorName;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadataIsNull = false;
            }
            Amazon.CodeGuruReviewer.Model.EventInfo requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo = null;
            
             // populate EventInfo
            var requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfoIsNull = true;
            requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo = new Amazon.CodeGuruReviewer.Model.EventInfo();
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo_eventInfo_Name = null;
            if (cmdletContext.EventInfo_Name != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo_eventInfo_Name = cmdletContext.EventInfo_Name;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo_eventInfo_Name != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo.Name = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo_eventInfo_Name;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfoIsNull = false;
            }
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo_eventInfo_State = null;
            if (cmdletContext.EventInfo_State != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo_eventInfo_State = cmdletContext.EventInfo_State;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo_eventInfo_State != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo.State = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo_eventInfo_State;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfoIsNull = false;
            }
             // determine if requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo should be set to null
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfoIsNull)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo = null;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata.EventInfo = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_type_RepositoryAnalysis_SourceCodeType_RequestMetadata_EventInfo;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadataIsNull = false;
            }
             // determine if requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata should be set to null
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadataIsNull)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata = null;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType.RequestMetadata = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType_type_RepositoryAnalysis_SourceCodeType_RequestMetadata;
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeTypeIsNull = false;
            }
             // determine if requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType should be set to null
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeTypeIsNull)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType = null;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType != null)
            {
                requestType_type_RepositoryAnalysis.SourceCodeType = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_SourceCodeType;
                requestType_type_RepositoryAnalysisIsNull = false;
            }
             // determine if requestType_type_RepositoryAnalysis should be set to null
            if (requestType_type_RepositoryAnalysisIsNull)
            {
                requestType_type_RepositoryAnalysis = null;
            }
            if (requestType_type_RepositoryAnalysis != null)
            {
                request.Type.RepositoryAnalysis = requestType_type_RepositoryAnalysis;
                requestTypeIsNull = false;
            }
             // determine if request.Type should be set to null
            if (requestTypeIsNull)
            {
                request.Type = null;
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
        
        private Amazon.CodeGuruReviewer.Model.CreateCodeReviewResponse CallAWSServiceOperation(IAmazonCodeGuruReviewer client, Amazon.CodeGuruReviewer.Model.CreateCodeReviewRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CodeGuru Reviewer", "CreateCodeReview");
            try
            {
                #if DESKTOP
                return client.CreateCodeReview(request);
                #elif CORECLR
                return client.CreateCodeReviewAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String Name { get; set; }
            public System.String RepositoryAssociationArn { get; set; }
            public List<System.String> Type_AnalysisType { get; set; }
            public System.String Type_RepositoryAnalysis_RepositoryHead_BranchName { get; set; }
            public System.String BranchDiff_DestinationBranchName { get; set; }
            public System.String BranchDiff_SourceBranchName { get; set; }
            public System.String CommitDiff_DestinationCommit { get; set; }
            public System.String CommitDiff_MergeBaseCommit { get; set; }
            public System.String CommitDiff_SourceCommit { get; set; }
            public System.String Type_RepositoryAnalysis_SourceCodeType_RepositoryHead_BranchName { get; set; }
            public System.String EventInfo_Name { get; set; }
            public System.String EventInfo_State { get; set; }
            public System.String RequestMetadata_Requester { get; set; }
            public System.String RequestMetadata_RequestId { get; set; }
            public Amazon.CodeGuruReviewer.VendorName RequestMetadata_VendorName { get; set; }
            public System.String Details_BucketName { get; set; }
            public System.String CodeArtifacts_BuildArtifactsObjectKey { get; set; }
            public System.String CodeArtifacts_SourceCodeArtifactsObjectKey { get; set; }
            public System.String S3BucketRepository_Name { get; set; }
            public System.Func<Amazon.CodeGuruReviewer.Model.CreateCodeReviewResponse, NewCGRCodeReviewCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CodeReview;
        }
        
    }
}
