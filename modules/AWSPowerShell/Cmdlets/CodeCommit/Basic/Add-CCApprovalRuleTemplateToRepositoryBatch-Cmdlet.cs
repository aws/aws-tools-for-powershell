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

namespace Amazon.PowerShell.Cmdlets.CC
{
    /// <summary>
    /// Creates an association between an approval rule template and one or more specified
    /// repositories.
    /// </summary>
    [Cmdlet("Add", "CCApprovalRuleTemplateToRepositoryBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeCommit.Model.BatchAssociateApprovalRuleTemplateWithRepositoriesResponse")]
    [AWSCmdlet("Calls the AWS CodeCommit BatchAssociateApprovalRuleTemplateWithRepositories API operation.", Operation = new[] {"BatchAssociateApprovalRuleTemplateWithRepositories"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.BatchAssociateApprovalRuleTemplateWithRepositoriesResponse))]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.BatchAssociateApprovalRuleTemplateWithRepositoriesResponse",
        "This cmdlet returns an Amazon.CodeCommit.Model.BatchAssociateApprovalRuleTemplateWithRepositoriesResponse object containing multiple properties."
    )]
    public partial class AddCCApprovalRuleTemplateToRepositoryBatchCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApprovalRuleTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the template you want to associate with one or more repositories.</para>
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
        public System.String ApprovalRuleTemplateName { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The names of the repositories you want to associate with the template.</para><note><para>The length constraint limit is for each string in the array. The array itself can
        /// be empty.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RepositoryNames")]
        public System.String[] RepositoryName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.BatchAssociateApprovalRuleTemplateWithRepositoriesResponse).
        /// Specifying the name of a property of type Amazon.CodeCommit.Model.BatchAssociateApprovalRuleTemplateWithRepositoriesResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApprovalRuleTemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-CCApprovalRuleTemplateToRepositoryBatch (BatchAssociateApprovalRuleTemplateWithRepositories)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.BatchAssociateApprovalRuleTemplateWithRepositoriesResponse, AddCCApprovalRuleTemplateToRepositoryBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApprovalRuleTemplateName = this.ApprovalRuleTemplateName;
            #if MODULAR
            if (this.ApprovalRuleTemplateName == null && ParameterWasBound(nameof(this.ApprovalRuleTemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApprovalRuleTemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RepositoryName != null)
            {
                context.RepositoryName = new List<System.String>(this.RepositoryName);
            }
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
            var request = new Amazon.CodeCommit.Model.BatchAssociateApprovalRuleTemplateWithRepositoriesRequest();
            
            if (cmdletContext.ApprovalRuleTemplateName != null)
            {
                request.ApprovalRuleTemplateName = cmdletContext.ApprovalRuleTemplateName;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryNames = cmdletContext.RepositoryName;
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
        
        private Amazon.CodeCommit.Model.BatchAssociateApprovalRuleTemplateWithRepositoriesResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.BatchAssociateApprovalRuleTemplateWithRepositoriesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "BatchAssociateApprovalRuleTemplateWithRepositories");
            try
            {
                return client.BatchAssociateApprovalRuleTemplateWithRepositoriesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApprovalRuleTemplateName { get; set; }
            public List<System.String> RepositoryName { get; set; }
            public System.Func<Amazon.CodeCommit.Model.BatchAssociateApprovalRuleTemplateWithRepositoriesResponse, AddCCApprovalRuleTemplateToRepositoryBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
