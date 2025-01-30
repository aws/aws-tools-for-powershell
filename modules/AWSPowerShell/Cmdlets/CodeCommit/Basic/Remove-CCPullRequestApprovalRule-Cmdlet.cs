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
    /// Deletes an approval rule from a specified pull request. Approval rules can be deleted
    /// from a pull request only if the pull request is open, and if the approval rule was
    /// created specifically for a pull request and not generated from an approval rule template
    /// associated with the repository where the pull request was created. You cannot delete
    /// an approval rule from a merged or closed pull request.
    /// </summary>
    [Cmdlet("Remove", "CCPullRequestApprovalRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CodeCommit DeletePullRequestApprovalRule API operation.", Operation = new[] {"DeletePullRequestApprovalRule"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.DeletePullRequestApprovalRuleResponse))]
    [AWSCmdletOutput("System.String or Amazon.CodeCommit.Model.DeletePullRequestApprovalRuleResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CodeCommit.Model.DeletePullRequestApprovalRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveCCPullRequestApprovalRuleCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApprovalRuleName
        /// <summary>
        /// <para>
        /// <para>The name of the approval rule you want to delete.</para>
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
        public System.String ApprovalRuleName { get; set; }
        #endregion
        
        #region Parameter PullRequestId
        /// <summary>
        /// <para>
        /// <para>The system-generated ID of the pull request that contains the approval rule you want
        /// to delete.</para>
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
        public System.String PullRequestId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApprovalRuleId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.DeletePullRequestApprovalRuleResponse).
        /// Specifying the name of a property of type Amazon.CodeCommit.Model.DeletePullRequestApprovalRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApprovalRuleId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApprovalRuleName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApprovalRuleName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApprovalRuleName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApprovalRuleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CCPullRequestApprovalRule (DeletePullRequestApprovalRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.DeletePullRequestApprovalRuleResponse, RemoveCCPullRequestApprovalRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApprovalRuleName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApprovalRuleName = this.ApprovalRuleName;
            #if MODULAR
            if (this.ApprovalRuleName == null && ParameterWasBound(nameof(this.ApprovalRuleName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApprovalRuleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PullRequestId = this.PullRequestId;
            #if MODULAR
            if (this.PullRequestId == null && ParameterWasBound(nameof(this.PullRequestId)))
            {
                WriteWarning("You are passing $null as a value for parameter PullRequestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeCommit.Model.DeletePullRequestApprovalRuleRequest();
            
            if (cmdletContext.ApprovalRuleName != null)
            {
                request.ApprovalRuleName = cmdletContext.ApprovalRuleName;
            }
            if (cmdletContext.PullRequestId != null)
            {
                request.PullRequestId = cmdletContext.PullRequestId;
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
        
        private Amazon.CodeCommit.Model.DeletePullRequestApprovalRuleResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.DeletePullRequestApprovalRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "DeletePullRequestApprovalRule");
            try
            {
                #if DESKTOP
                return client.DeletePullRequestApprovalRule(request);
                #elif CORECLR
                return client.DeletePullRequestApprovalRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String ApprovalRuleName { get; set; }
            public System.String PullRequestId { get; set; }
            public System.Func<Amazon.CodeCommit.Model.DeletePullRequestApprovalRuleResponse, RemoveCCPullRequestApprovalRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApprovalRuleId;
        }
        
    }
}
