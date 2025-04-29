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
using Amazon.CodeGuruReviewer;
using Amazon.CodeGuruReviewer.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CGR
{
    /// <summary>
    /// Use to associate an Amazon Web Services CodeCommit repository or a repository managed
    /// by Amazon Web Services CodeStar Connections with Amazon CodeGuru Reviewer. When you
    /// associate a repository, CodeGuru Reviewer reviews source code changes in the repository's
    /// pull requests and provides automatic recommendations. You can view recommendations
    /// using the CodeGuru Reviewer console. For more information, see <a href="https://docs.aws.amazon.com/codeguru/latest/reviewer-ug/recommendations.html">Recommendations
    /// in Amazon CodeGuru Reviewer</a> in the <i>Amazon CodeGuru Reviewer User Guide.</i><para>
    /// If you associate a CodeCommit or S3 repository, it must be in the same Amazon Web
    /// Services Region and Amazon Web Services account where its CodeGuru Reviewer code reviews
    /// are configured.
    /// </para><para>
    /// Bitbucket and GitHub Enterprise Server repositories are managed by Amazon Web Services
    /// CodeStar Connections to connect to CodeGuru Reviewer. For more information, see <a href="https://docs.aws.amazon.com/codeguru/latest/reviewer-ug/getting-started-associate-repository.html">Associate
    /// a repository</a> in the <i>Amazon CodeGuru Reviewer User Guide.</i></para><note><para>
    /// You cannot use the CodeGuru Reviewer SDK or the Amazon Web Services CLI to associate
    /// a GitHub repository with Amazon CodeGuru Reviewer. To associate a GitHub repository,
    /// use the console. For more information, see <a href="https://docs.aws.amazon.com/codeguru/latest/reviewer-ug/getting-started-with-guru.html">Getting
    /// started with CodeGuru Reviewer</a> in the <i>CodeGuru Reviewer User Guide.</i></para></note>
    /// </summary>
    [Cmdlet("Register", "CGRRepository", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeGuruReviewer.Model.RepositoryAssociation")]
    [AWSCmdlet("Calls the Amazon CodeGuru Reviewer AssociateRepository API operation.", Operation = new[] {"AssociateRepository"}, SelectReturnType = typeof(Amazon.CodeGuruReviewer.Model.AssociateRepositoryResponse))]
    [AWSCmdletOutput("Amazon.CodeGuruReviewer.Model.RepositoryAssociation or Amazon.CodeGuruReviewer.Model.AssociateRepositoryResponse",
        "This cmdlet returns an Amazon.CodeGuruReviewer.Model.RepositoryAssociation object.",
        "The service call response (type Amazon.CodeGuruReviewer.Model.AssociateRepositoryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterCGRRepositoryCmdlet : AmazonCodeGuruReviewerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter S3Bucket_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket used for associating a new S3 repository. It must begin
        /// with <c>codeguru-reviewer-</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Repository_S3Bucket_BucketName")]
        public System.String S3Bucket_BucketName { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Amazon CodeGuru Reviewer uses this value to prevent the accidental creation of duplicate
        /// repository associations if there are failures and retries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Bitbucket_ConnectionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Amazon Web Services CodeStar Connections connection.
        /// Its format is <c>arn:aws:codestar-connections:region-id:aws-account_id:connection/connection-id</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/codestar-connections/latest/APIReference/API_Connection.html">Connection</a>
        /// in the <i>Amazon Web Services CodeStar Connections API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Repository_Bitbucket_ConnectionArn")]
        public System.String Bitbucket_ConnectionArn { get; set; }
        #endregion
        
        #region Parameter GitHubEnterpriseServer_ConnectionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Amazon Web Services CodeStar Connections connection.
        /// Its format is <c>arn:aws:codestar-connections:region-id:aws-account_id:connection/connection-id</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/codestar-connections/latest/APIReference/API_Connection.html">Connection</a>
        /// in the <i>Amazon Web Services CodeStar Connections API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Repository_GitHubEnterpriseServer_ConnectionArn")]
        public System.String GitHubEnterpriseServer_ConnectionArn { get; set; }
        #endregion
        
        #region Parameter KMSKeyDetails_EncryptionOption
        /// <summary>
        /// <para>
        /// <para>The encryption option for a repository association. It is either owned by Amazon Web
        /// Services Key Management Service (KMS) (<c>AWS_OWNED_CMK</c>) or customer managed (<c>CUSTOMER_MANAGED_CMK</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeGuruReviewer.EncryptionOption")]
        public Amazon.CodeGuruReviewer.EncryptionOption KMSKeyDetails_EncryptionOption { get; set; }
        #endregion
        
        #region Parameter KMSKeyDetails_KMSKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services KMS key that is associated with a repository association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KMSKeyDetails_KMSKeyId { get; set; }
        #endregion
        
        #region Parameter Bitbucket_Name
        /// <summary>
        /// <para>
        /// <para>The name of the third party source repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Repository_Bitbucket_Name")]
        public System.String Bitbucket_Name { get; set; }
        #endregion
        
        #region Parameter CodeCommit_Name
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Web Services CodeCommit repository. For more information, see
        /// <a href="https://docs.aws.amazon.com/codecommit/latest/APIReference/API_GetRepository.html#CodeCommit-GetRepository-request-repositoryName">repositoryName</a>
        /// in the <i>Amazon Web Services CodeCommit API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("Repository_CodeCommit_Name")]
        public System.String CodeCommit_Name { get; set; }
        #endregion
        
        #region Parameter GitHubEnterpriseServer_Name
        /// <summary>
        /// <para>
        /// <para>The name of the third party source repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Repository_GitHubEnterpriseServer_Name")]
        public System.String GitHubEnterpriseServer_Name { get; set; }
        #endregion
        
        #region Parameter S3Bucket_Name
        /// <summary>
        /// <para>
        /// <para>The name of the repository in the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Repository_S3Bucket_Name")]
        public System.String S3Bucket_Name { get; set; }
        #endregion
        
        #region Parameter Bitbucket_Owner
        /// <summary>
        /// <para>
        /// <para>The owner of the repository. For a GitHub, GitHub Enterprise, or Bitbucket repository,
        /// this is the username for the account that owns the repository. For an S3 repository,
        /// this can be the username or Amazon Web Services account ID </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Repository_Bitbucket_Owner")]
        public System.String Bitbucket_Owner { get; set; }
        #endregion
        
        #region Parameter GitHubEnterpriseServer_Owner
        /// <summary>
        /// <para>
        /// <para>The owner of the repository. For a GitHub, GitHub Enterprise, or Bitbucket repository,
        /// this is the username for the account that owns the repository. For an S3 repository,
        /// this can be the username or Amazon Web Services account ID </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Repository_GitHubEnterpriseServer_Owner")]
        public System.String GitHubEnterpriseServer_Owner { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs used to tag an associated repository. A tag is a custom
        /// attribute label with two parts:</para><ul><li><para>A <i>tag key</i> (for example, <c>CostCenter</c>, <c>Environment</c>, <c>Project</c>,
        /// or <c>Secret</c>). Tag keys are case sensitive.</para></li><li><para>An optional field known as a <i>tag value</i> (for example, <c>111122223333</c>, <c>Production</c>,
        /// or a team name). Omitting the tag value is the same as using an empty string. Like
        /// tag keys, tag values are case sensitive.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RepositoryAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeGuruReviewer.Model.AssociateRepositoryResponse).
        /// Specifying the name of a property of type Amazon.CodeGuruReviewer.Model.AssociateRepositoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RepositoryAssociation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CodeCommit_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-CGRRepository (AssociateRepository)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeGuruReviewer.Model.AssociateRepositoryResponse, RegisterCGRRepositoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.KMSKeyDetails_EncryptionOption = this.KMSKeyDetails_EncryptionOption;
            context.KMSKeyDetails_KMSKeyId = this.KMSKeyDetails_KMSKeyId;
            context.Bitbucket_ConnectionArn = this.Bitbucket_ConnectionArn;
            context.Bitbucket_Name = this.Bitbucket_Name;
            context.Bitbucket_Owner = this.Bitbucket_Owner;
            context.CodeCommit_Name = this.CodeCommit_Name;
            context.GitHubEnterpriseServer_ConnectionArn = this.GitHubEnterpriseServer_ConnectionArn;
            context.GitHubEnterpriseServer_Name = this.GitHubEnterpriseServer_Name;
            context.GitHubEnterpriseServer_Owner = this.GitHubEnterpriseServer_Owner;
            context.S3Bucket_BucketName = this.S3Bucket_BucketName;
            context.S3Bucket_Name = this.S3Bucket_Name;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.CodeGuruReviewer.Model.AssociateRepositoryRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate KMSKeyDetails
            var requestKMSKeyDetailsIsNull = true;
            request.KMSKeyDetails = new Amazon.CodeGuruReviewer.Model.KMSKeyDetails();
            Amazon.CodeGuruReviewer.EncryptionOption requestKMSKeyDetails_kMSKeyDetails_EncryptionOption = null;
            if (cmdletContext.KMSKeyDetails_EncryptionOption != null)
            {
                requestKMSKeyDetails_kMSKeyDetails_EncryptionOption = cmdletContext.KMSKeyDetails_EncryptionOption;
            }
            if (requestKMSKeyDetails_kMSKeyDetails_EncryptionOption != null)
            {
                request.KMSKeyDetails.EncryptionOption = requestKMSKeyDetails_kMSKeyDetails_EncryptionOption;
                requestKMSKeyDetailsIsNull = false;
            }
            System.String requestKMSKeyDetails_kMSKeyDetails_KMSKeyId = null;
            if (cmdletContext.KMSKeyDetails_KMSKeyId != null)
            {
                requestKMSKeyDetails_kMSKeyDetails_KMSKeyId = cmdletContext.KMSKeyDetails_KMSKeyId;
            }
            if (requestKMSKeyDetails_kMSKeyDetails_KMSKeyId != null)
            {
                request.KMSKeyDetails.KMSKeyId = requestKMSKeyDetails_kMSKeyDetails_KMSKeyId;
                requestKMSKeyDetailsIsNull = false;
            }
             // determine if request.KMSKeyDetails should be set to null
            if (requestKMSKeyDetailsIsNull)
            {
                request.KMSKeyDetails = null;
            }
            
             // populate Repository
            var requestRepositoryIsNull = true;
            request.Repository = new Amazon.CodeGuruReviewer.Model.Repository();
            Amazon.CodeGuruReviewer.Model.CodeCommitRepository requestRepository_repository_CodeCommit = null;
            
             // populate CodeCommit
            var requestRepository_repository_CodeCommitIsNull = true;
            requestRepository_repository_CodeCommit = new Amazon.CodeGuruReviewer.Model.CodeCommitRepository();
            System.String requestRepository_repository_CodeCommit_codeCommit_Name = null;
            if (cmdletContext.CodeCommit_Name != null)
            {
                requestRepository_repository_CodeCommit_codeCommit_Name = cmdletContext.CodeCommit_Name;
            }
            if (requestRepository_repository_CodeCommit_codeCommit_Name != null)
            {
                requestRepository_repository_CodeCommit.Name = requestRepository_repository_CodeCommit_codeCommit_Name;
                requestRepository_repository_CodeCommitIsNull = false;
            }
             // determine if requestRepository_repository_CodeCommit should be set to null
            if (requestRepository_repository_CodeCommitIsNull)
            {
                requestRepository_repository_CodeCommit = null;
            }
            if (requestRepository_repository_CodeCommit != null)
            {
                request.Repository.CodeCommit = requestRepository_repository_CodeCommit;
                requestRepositoryIsNull = false;
            }
            Amazon.CodeGuruReviewer.Model.S3Repository requestRepository_repository_S3Bucket = null;
            
             // populate S3Bucket
            var requestRepository_repository_S3BucketIsNull = true;
            requestRepository_repository_S3Bucket = new Amazon.CodeGuruReviewer.Model.S3Repository();
            System.String requestRepository_repository_S3Bucket_s3Bucket_BucketName = null;
            if (cmdletContext.S3Bucket_BucketName != null)
            {
                requestRepository_repository_S3Bucket_s3Bucket_BucketName = cmdletContext.S3Bucket_BucketName;
            }
            if (requestRepository_repository_S3Bucket_s3Bucket_BucketName != null)
            {
                requestRepository_repository_S3Bucket.BucketName = requestRepository_repository_S3Bucket_s3Bucket_BucketName;
                requestRepository_repository_S3BucketIsNull = false;
            }
            System.String requestRepository_repository_S3Bucket_s3Bucket_Name = null;
            if (cmdletContext.S3Bucket_Name != null)
            {
                requestRepository_repository_S3Bucket_s3Bucket_Name = cmdletContext.S3Bucket_Name;
            }
            if (requestRepository_repository_S3Bucket_s3Bucket_Name != null)
            {
                requestRepository_repository_S3Bucket.Name = requestRepository_repository_S3Bucket_s3Bucket_Name;
                requestRepository_repository_S3BucketIsNull = false;
            }
             // determine if requestRepository_repository_S3Bucket should be set to null
            if (requestRepository_repository_S3BucketIsNull)
            {
                requestRepository_repository_S3Bucket = null;
            }
            if (requestRepository_repository_S3Bucket != null)
            {
                request.Repository.S3Bucket = requestRepository_repository_S3Bucket;
                requestRepositoryIsNull = false;
            }
            Amazon.CodeGuruReviewer.Model.ThirdPartySourceRepository requestRepository_repository_Bitbucket = null;
            
             // populate Bitbucket
            var requestRepository_repository_BitbucketIsNull = true;
            requestRepository_repository_Bitbucket = new Amazon.CodeGuruReviewer.Model.ThirdPartySourceRepository();
            System.String requestRepository_repository_Bitbucket_bitbucket_ConnectionArn = null;
            if (cmdletContext.Bitbucket_ConnectionArn != null)
            {
                requestRepository_repository_Bitbucket_bitbucket_ConnectionArn = cmdletContext.Bitbucket_ConnectionArn;
            }
            if (requestRepository_repository_Bitbucket_bitbucket_ConnectionArn != null)
            {
                requestRepository_repository_Bitbucket.ConnectionArn = requestRepository_repository_Bitbucket_bitbucket_ConnectionArn;
                requestRepository_repository_BitbucketIsNull = false;
            }
            System.String requestRepository_repository_Bitbucket_bitbucket_Name = null;
            if (cmdletContext.Bitbucket_Name != null)
            {
                requestRepository_repository_Bitbucket_bitbucket_Name = cmdletContext.Bitbucket_Name;
            }
            if (requestRepository_repository_Bitbucket_bitbucket_Name != null)
            {
                requestRepository_repository_Bitbucket.Name = requestRepository_repository_Bitbucket_bitbucket_Name;
                requestRepository_repository_BitbucketIsNull = false;
            }
            System.String requestRepository_repository_Bitbucket_bitbucket_Owner = null;
            if (cmdletContext.Bitbucket_Owner != null)
            {
                requestRepository_repository_Bitbucket_bitbucket_Owner = cmdletContext.Bitbucket_Owner;
            }
            if (requestRepository_repository_Bitbucket_bitbucket_Owner != null)
            {
                requestRepository_repository_Bitbucket.Owner = requestRepository_repository_Bitbucket_bitbucket_Owner;
                requestRepository_repository_BitbucketIsNull = false;
            }
             // determine if requestRepository_repository_Bitbucket should be set to null
            if (requestRepository_repository_BitbucketIsNull)
            {
                requestRepository_repository_Bitbucket = null;
            }
            if (requestRepository_repository_Bitbucket != null)
            {
                request.Repository.Bitbucket = requestRepository_repository_Bitbucket;
                requestRepositoryIsNull = false;
            }
            Amazon.CodeGuruReviewer.Model.ThirdPartySourceRepository requestRepository_repository_GitHubEnterpriseServer = null;
            
             // populate GitHubEnterpriseServer
            var requestRepository_repository_GitHubEnterpriseServerIsNull = true;
            requestRepository_repository_GitHubEnterpriseServer = new Amazon.CodeGuruReviewer.Model.ThirdPartySourceRepository();
            System.String requestRepository_repository_GitHubEnterpriseServer_gitHubEnterpriseServer_ConnectionArn = null;
            if (cmdletContext.GitHubEnterpriseServer_ConnectionArn != null)
            {
                requestRepository_repository_GitHubEnterpriseServer_gitHubEnterpriseServer_ConnectionArn = cmdletContext.GitHubEnterpriseServer_ConnectionArn;
            }
            if (requestRepository_repository_GitHubEnterpriseServer_gitHubEnterpriseServer_ConnectionArn != null)
            {
                requestRepository_repository_GitHubEnterpriseServer.ConnectionArn = requestRepository_repository_GitHubEnterpriseServer_gitHubEnterpriseServer_ConnectionArn;
                requestRepository_repository_GitHubEnterpriseServerIsNull = false;
            }
            System.String requestRepository_repository_GitHubEnterpriseServer_gitHubEnterpriseServer_Name = null;
            if (cmdletContext.GitHubEnterpriseServer_Name != null)
            {
                requestRepository_repository_GitHubEnterpriseServer_gitHubEnterpriseServer_Name = cmdletContext.GitHubEnterpriseServer_Name;
            }
            if (requestRepository_repository_GitHubEnterpriseServer_gitHubEnterpriseServer_Name != null)
            {
                requestRepository_repository_GitHubEnterpriseServer.Name = requestRepository_repository_GitHubEnterpriseServer_gitHubEnterpriseServer_Name;
                requestRepository_repository_GitHubEnterpriseServerIsNull = false;
            }
            System.String requestRepository_repository_GitHubEnterpriseServer_gitHubEnterpriseServer_Owner = null;
            if (cmdletContext.GitHubEnterpriseServer_Owner != null)
            {
                requestRepository_repository_GitHubEnterpriseServer_gitHubEnterpriseServer_Owner = cmdletContext.GitHubEnterpriseServer_Owner;
            }
            if (requestRepository_repository_GitHubEnterpriseServer_gitHubEnterpriseServer_Owner != null)
            {
                requestRepository_repository_GitHubEnterpriseServer.Owner = requestRepository_repository_GitHubEnterpriseServer_gitHubEnterpriseServer_Owner;
                requestRepository_repository_GitHubEnterpriseServerIsNull = false;
            }
             // determine if requestRepository_repository_GitHubEnterpriseServer should be set to null
            if (requestRepository_repository_GitHubEnterpriseServerIsNull)
            {
                requestRepository_repository_GitHubEnterpriseServer = null;
            }
            if (requestRepository_repository_GitHubEnterpriseServer != null)
            {
                request.Repository.GitHubEnterpriseServer = requestRepository_repository_GitHubEnterpriseServer;
                requestRepositoryIsNull = false;
            }
             // determine if request.Repository should be set to null
            if (requestRepositoryIsNull)
            {
                request.Repository = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.CodeGuruReviewer.Model.AssociateRepositoryResponse CallAWSServiceOperation(IAmazonCodeGuruReviewer client, Amazon.CodeGuruReviewer.Model.AssociateRepositoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CodeGuru Reviewer", "AssociateRepository");
            try
            {
                return client.AssociateRepositoryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.CodeGuruReviewer.EncryptionOption KMSKeyDetails_EncryptionOption { get; set; }
            public System.String KMSKeyDetails_KMSKeyId { get; set; }
            public System.String Bitbucket_ConnectionArn { get; set; }
            public System.String Bitbucket_Name { get; set; }
            public System.String Bitbucket_Owner { get; set; }
            public System.String CodeCommit_Name { get; set; }
            public System.String GitHubEnterpriseServer_ConnectionArn { get; set; }
            public System.String GitHubEnterpriseServer_Name { get; set; }
            public System.String GitHubEnterpriseServer_Owner { get; set; }
            public System.String S3Bucket_BucketName { get; set; }
            public System.String S3Bucket_Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CodeGuruReviewer.Model.AssociateRepositoryResponse, RegisterCGRRepositoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RepositoryAssociation;
        }
        
    }
}
