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
    /// Sets aside (overrides) all approval rule requirements for a specified pull request.
    /// </summary>
    [Cmdlet("Skip", "CCPullRequestApprovalRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS CodeCommit OverridePullRequestApprovalRules API operation.", Operation = new[] {"OverridePullRequestApprovalRules"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.OverridePullRequestApprovalRulesResponse))]
    [AWSCmdletOutput("None or Amazon.CodeCommit.Model.OverridePullRequestApprovalRulesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CodeCommit.Model.OverridePullRequestApprovalRulesResponse) be returned by specifying '-Select *'."
    )]
    public partial class SkipCCPullRequestApprovalRuleCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OverrideStatus
        /// <summary>
        /// <para>
        /// <para>Whether you want to set aside approval rule requirements for the pull request (OVERRIDE)
        /// or revoke a previous override and apply approval rule requirements (REVOKE). REVOKE
        /// status is not stored.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeCommit.OverrideStatus")]
        public Amazon.CodeCommit.OverrideStatus OverrideStatus { get; set; }
        #endregion
        
        #region Parameter PullRequestId
        /// <summary>
        /// <para>
        /// <para>The system-generated ID of the pull request for which you want to override all approval
        /// rule requirements. To get this information, use <a>GetPullRequest</a>.</para>
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
        public System.String PullRequestId { get; set; }
        #endregion
        
        #region Parameter RevisionId
        /// <summary>
        /// <para>
        /// <para>The system-generated ID of the most recent revision of the pull request. You cannot
        /// override approval rules for anything but the most recent revision of a pull request.
        /// To get the revision ID, use GetPullRequest.</para>
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
        public System.String RevisionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.OverridePullRequestApprovalRulesResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PullRequestId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Skip-CCPullRequestApprovalRule (OverridePullRequestApprovalRules)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.OverridePullRequestApprovalRulesResponse, SkipCCPullRequestApprovalRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OverrideStatus = this.OverrideStatus;
            #if MODULAR
            if (this.OverrideStatus == null && ParameterWasBound(nameof(this.OverrideStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter OverrideStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PullRequestId = this.PullRequestId;
            #if MODULAR
            if (this.PullRequestId == null && ParameterWasBound(nameof(this.PullRequestId)))
            {
                WriteWarning("You are passing $null as a value for parameter PullRequestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RevisionId = this.RevisionId;
            #if MODULAR
            if (this.RevisionId == null && ParameterWasBound(nameof(this.RevisionId)))
            {
                WriteWarning("You are passing $null as a value for parameter RevisionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeCommit.Model.OverridePullRequestApprovalRulesRequest();
            
            if (cmdletContext.OverrideStatus != null)
            {
                request.OverrideStatus = cmdletContext.OverrideStatus;
            }
            if (cmdletContext.PullRequestId != null)
            {
                request.PullRequestId = cmdletContext.PullRequestId;
            }
            if (cmdletContext.RevisionId != null)
            {
                request.RevisionId = cmdletContext.RevisionId;
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
        
        private Amazon.CodeCommit.Model.OverridePullRequestApprovalRulesResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.OverridePullRequestApprovalRulesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "OverridePullRequestApprovalRules");
            try
            {
                #if DESKTOP
                return client.OverridePullRequestApprovalRules(request);
                #elif CORECLR
                return client.OverridePullRequestApprovalRulesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CodeCommit.OverrideStatus OverrideStatus { get; set; }
            public System.String PullRequestId { get; set; }
            public System.String RevisionId { get; set; }
            public System.Func<Amazon.CodeCommit.Model.OverridePullRequestApprovalRulesResponse, SkipCCPullRequestApprovalRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
