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
    /// Creates a template for approval rules that can then be associated with one or more
    /// repositories in your AWS account. When you associate a template with a repository,
    /// AWS CodeCommit creates an approval rule that matches the conditions of the template
    /// for all pull requests that meet the conditions of the template. For more information,
    /// see <a>AssociateApprovalRuleTemplateWithRepository</a>.
    /// </summary>
    [Cmdlet("New", "CCApprovalRuleTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeCommit.Model.ApprovalRuleTemplate")]
    [AWSCmdlet("Calls the AWS CodeCommit CreateApprovalRuleTemplate API operation.", Operation = new[] {"CreateApprovalRuleTemplate"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.CreateApprovalRuleTemplateResponse))]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.ApprovalRuleTemplate or Amazon.CodeCommit.Model.CreateApprovalRuleTemplateResponse",
        "This cmdlet returns an Amazon.CodeCommit.Model.ApprovalRuleTemplate object.",
        "The service call response (type Amazon.CodeCommit.Model.CreateApprovalRuleTemplateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCCApprovalRuleTemplateCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        #region Parameter ApprovalRuleTemplateContent
        /// <summary>
        /// <para>
        /// <para>The content of the approval rule that is created on pull requests in associated repositories.
        /// If you specify one or more destination references (branches), approval rules are created
        /// in an associated repository only if their destination references (branches) match
        /// those specified in the template.</para><note><para>When you create the content of the approval rule template, you can specify approvers
        /// in an approval pool in one of two ways:</para><ul><li><para><b>CodeCommitApprovers</b>: This option only requires an AWS account and a resource.
        /// It can be used for both IAM users and federated access users whose name matches the
        /// provided resource name. This is a very powerful option that offers a great deal of
        /// flexibility. For example, if you specify the AWS account <i>123456789012</i> and <i>Mary_Major</i>,
        /// all of the following are counted as approvals coming from that user:</para><ul><li><para>An IAM user in the account (arn:aws:iam::<i>123456789012</i>:user/<i>Mary_Major</i>)</para></li><li><para>A federated user identified in IAM as Mary_Major (arn:aws:sts::<i>123456789012</i>:federated-user/<i>Mary_Major</i>)</para></li></ul><para>This option does not recognize an active session of someone assuming the role of CodeCommitReview
        /// with a role session name of <i>Mary_Major</i> (arn:aws:sts::<i>123456789012</i>:assumed-role/CodeCommitReview/<i>Mary_Major</i>)
        /// unless you include a wildcard (*Mary_Major).</para></li><li><para><b>Fully qualified ARN</b>: This option allows you to specify the fully qualified
        /// Amazon Resource Name (ARN) of the IAM user or role. </para></li></ul><para>For more information about IAM ARNs, wildcards, and formats, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html">IAM
        /// Identifiers</a> in the <i>IAM User Guide</i>.</para></note>
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
        public System.String ApprovalRuleTemplateContent { get; set; }
        #endregion
        
        #region Parameter ApprovalRuleTemplateDescription
        /// <summary>
        /// <para>
        /// <para>The description of the approval rule template. Consider providing a description that
        /// explains what this template does and when it might be appropriate to associate it
        /// with repositories.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApprovalRuleTemplateDescription { get; set; }
        #endregion
        
        #region Parameter ApprovalRuleTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the approval rule template. Provide descriptive names, because this name
        /// is applied to the approval rules created automatically in associated repositories.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApprovalRuleTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.CreateApprovalRuleTemplateResponse).
        /// Specifying the name of a property of type Amazon.CodeCommit.Model.CreateApprovalRuleTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApprovalRuleTemplate";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApprovalRuleTemplateContent parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApprovalRuleTemplateContent' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApprovalRuleTemplateContent' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CCApprovalRuleTemplate (CreateApprovalRuleTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.CreateApprovalRuleTemplateResponse, NewCCApprovalRuleTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApprovalRuleTemplateContent;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApprovalRuleTemplateContent = this.ApprovalRuleTemplateContent;
            #if MODULAR
            if (this.ApprovalRuleTemplateContent == null && ParameterWasBound(nameof(this.ApprovalRuleTemplateContent)))
            {
                WriteWarning("You are passing $null as a value for parameter ApprovalRuleTemplateContent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApprovalRuleTemplateDescription = this.ApprovalRuleTemplateDescription;
            context.ApprovalRuleTemplateName = this.ApprovalRuleTemplateName;
            #if MODULAR
            if (this.ApprovalRuleTemplateName == null && ParameterWasBound(nameof(this.ApprovalRuleTemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApprovalRuleTemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeCommit.Model.CreateApprovalRuleTemplateRequest();
            
            if (cmdletContext.ApprovalRuleTemplateContent != null)
            {
                request.ApprovalRuleTemplateContent = cmdletContext.ApprovalRuleTemplateContent;
            }
            if (cmdletContext.ApprovalRuleTemplateDescription != null)
            {
                request.ApprovalRuleTemplateDescription = cmdletContext.ApprovalRuleTemplateDescription;
            }
            if (cmdletContext.ApprovalRuleTemplateName != null)
            {
                request.ApprovalRuleTemplateName = cmdletContext.ApprovalRuleTemplateName;
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
        
        private Amazon.CodeCommit.Model.CreateApprovalRuleTemplateResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.CreateApprovalRuleTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "CreateApprovalRuleTemplate");
            try
            {
                #if DESKTOP
                return client.CreateApprovalRuleTemplate(request);
                #elif CORECLR
                return client.CreateApprovalRuleTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String ApprovalRuleTemplateContent { get; set; }
            public System.String ApprovalRuleTemplateDescription { get; set; }
            public System.String ApprovalRuleTemplateName { get; set; }
            public System.Func<Amazon.CodeCommit.Model.CreateApprovalRuleTemplateResponse, NewCCApprovalRuleTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApprovalRuleTemplate;
        }
        
    }
}
