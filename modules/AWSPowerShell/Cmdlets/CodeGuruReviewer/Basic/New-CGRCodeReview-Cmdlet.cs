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
    /// Use to create a code review for a repository analysis.
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
        
        #region Parameter RepositoryHead_BranchName
        /// <summary>
        /// <para>
        /// <para> The name of the branch in an associated repository. The <code>RepositoryHeadSourceCodeType</code>
        /// specifies the tip of this branch. </para>
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
        [Alias("Type_RepositoryAnalysis_RepositoryHead_BranchName")]
        public System.String RepositoryHead_BranchName { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para> Amazon CodeGuru Reviewer uses this value to prevent the accidental creation of duplicate
        /// code reviews if there are failures and retries. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The name of the code review. Each code review of the same code review type must have
        /// a unique name in your AWS account. </para>
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
        
        #region Parameter RepositoryAssociationArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the <a href="https://docs.aws.amazon.com/codeguru/latest/reviewer-api/API_RepositoryAssociation.html"><code>RepositoryAssociation</code></a> object. You can retrieve this ARN by calling
        /// <code>ListRepositories</code>. </para><para> A code review can only be created on an associated repository. This is the ARN of
        /// the associated repository. </para>
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
            context.RepositoryHead_BranchName = this.RepositoryHead_BranchName;
            #if MODULAR
            if (this.RepositoryHead_BranchName == null && ParameterWasBound(nameof(this.RepositoryHead_BranchName)))
            {
                WriteWarning("You are passing $null as a value for parameter RepositoryHead_BranchName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            Amazon.CodeGuruReviewer.Model.RepositoryAnalysis requestType_type_RepositoryAnalysis = null;
            
             // populate RepositoryAnalysis
            var requestType_type_RepositoryAnalysisIsNull = true;
            requestType_type_RepositoryAnalysis = new Amazon.CodeGuruReviewer.Model.RepositoryAnalysis();
            Amazon.CodeGuruReviewer.Model.RepositoryHeadSourceCodeType requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead = null;
            
             // populate RepositoryHead
            var requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHeadIsNull = true;
            requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead = new Amazon.CodeGuruReviewer.Model.RepositoryHeadSourceCodeType();
            System.String requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead_repositoryHead_BranchName = null;
            if (cmdletContext.RepositoryHead_BranchName != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead_repositoryHead_BranchName = cmdletContext.RepositoryHead_BranchName;
            }
            if (requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead_repositoryHead_BranchName != null)
            {
                requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead.BranchName = requestType_type_RepositoryAnalysis_type_RepositoryAnalysis_RepositoryHead_repositoryHead_BranchName;
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
            public System.String RepositoryHead_BranchName { get; set; }
            public System.Func<Amazon.CodeGuruReviewer.Model.CreateCodeReviewResponse, NewCGRCodeReviewCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CodeReview;
        }
        
    }
}
