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
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;

namespace Amazon.PowerShell.Cmdlets.CC
{
    /// <summary>
    /// Updates the content of an approval rule template. You can change the number of required
    /// approvals, the membership of the approval rule, and whether an approval pool is defined.
    /// </summary>
    [Cmdlet("Update", "CCApprovalRuleTemplateContent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeCommit.Model.ApprovalRuleTemplate")]
    [AWSCmdlet("Calls the AWS CodeCommit UpdateApprovalRuleTemplateContent API operation.", Operation = new[] {"UpdateApprovalRuleTemplateContent"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.UpdateApprovalRuleTemplateContentResponse))]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.ApprovalRuleTemplate or Amazon.CodeCommit.Model.UpdateApprovalRuleTemplateContentResponse",
        "This cmdlet returns an Amazon.CodeCommit.Model.ApprovalRuleTemplate object.",
        "The service call response (type Amazon.CodeCommit.Model.UpdateApprovalRuleTemplateContentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCCApprovalRuleTemplateContentCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApprovalRuleTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the approval rule template where you want to update the content of the
        /// rule. </para>
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
        public System.String ApprovalRuleTemplateName { get; set; }
        #endregion
        
        #region Parameter ExistingRuleContentSha256
        /// <summary>
        /// <para>
        /// <para>The SHA-256 hash signature for the content of the approval rule. You can retrieve
        /// this information by using <a>GetPullRequest</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExistingRuleContentSha256 { get; set; }
        #endregion
        
        #region Parameter NewRuleContent
        /// <summary>
        /// <para>
        /// <para>The content that replaces the existing content of the rule. Content statements must
        /// be complete. You cannot provide only the changes.</para>
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
        public System.String NewRuleContent { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApprovalRuleTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.UpdateApprovalRuleTemplateContentResponse).
        /// Specifying the name of a property of type Amazon.CodeCommit.Model.UpdateApprovalRuleTemplateContentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApprovalRuleTemplate";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NewRuleContent parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NewRuleContent' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NewRuleContent' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApprovalRuleTemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CCApprovalRuleTemplateContent (UpdateApprovalRuleTemplateContent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.UpdateApprovalRuleTemplateContentResponse, UpdateCCApprovalRuleTemplateContentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NewRuleContent;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApprovalRuleTemplateName = this.ApprovalRuleTemplateName;
            #if MODULAR
            if (this.ApprovalRuleTemplateName == null && ParameterWasBound(nameof(this.ApprovalRuleTemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApprovalRuleTemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExistingRuleContentSha256 = this.ExistingRuleContentSha256;
            context.NewRuleContent = this.NewRuleContent;
            #if MODULAR
            if (this.NewRuleContent == null && ParameterWasBound(nameof(this.NewRuleContent)))
            {
                WriteWarning("You are passing $null as a value for parameter NewRuleContent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeCommit.Model.UpdateApprovalRuleTemplateContentRequest();
            
            if (cmdletContext.ApprovalRuleTemplateName != null)
            {
                request.ApprovalRuleTemplateName = cmdletContext.ApprovalRuleTemplateName;
            }
            if (cmdletContext.ExistingRuleContentSha256 != null)
            {
                request.ExistingRuleContentSha256 = cmdletContext.ExistingRuleContentSha256;
            }
            if (cmdletContext.NewRuleContent != null)
            {
                request.NewRuleContent = cmdletContext.NewRuleContent;
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
        
        private Amazon.CodeCommit.Model.UpdateApprovalRuleTemplateContentResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.UpdateApprovalRuleTemplateContentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "UpdateApprovalRuleTemplateContent");
            try
            {
                #if DESKTOP
                return client.UpdateApprovalRuleTemplateContent(request);
                #elif CORECLR
                return client.UpdateApprovalRuleTemplateContentAsync(request).GetAwaiter().GetResult();
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
            public System.String ApprovalRuleTemplateName { get; set; }
            public System.String ExistingRuleContentSha256 { get; set; }
            public System.String NewRuleContent { get; set; }
            public System.Func<Amazon.CodeCommit.Model.UpdateApprovalRuleTemplateContentResponse, UpdateCCApprovalRuleTemplateContentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApprovalRuleTemplate;
        }
        
    }
}
