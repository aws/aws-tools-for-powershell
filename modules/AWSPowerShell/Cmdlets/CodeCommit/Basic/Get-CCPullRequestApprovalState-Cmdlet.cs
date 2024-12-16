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
    /// Gets information about the approval states for a specified pull request. Approval
    /// states only apply to pull requests that have one or more approval rules applied to
    /// them.
    /// </summary>
    [Cmdlet("Get", "CCPullRequestApprovalState")]
    [OutputType("Amazon.CodeCommit.Model.Approval")]
    [AWSCmdlet("Calls the AWS CodeCommit GetPullRequestApprovalStates API operation.", Operation = new[] {"GetPullRequestApprovalStates"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.GetPullRequestApprovalStatesResponse))]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.Approval or Amazon.CodeCommit.Model.GetPullRequestApprovalStatesResponse",
        "This cmdlet returns a collection of Amazon.CodeCommit.Model.Approval objects.",
        "The service call response (type Amazon.CodeCommit.Model.GetPullRequestApprovalStatesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCCPullRequestApprovalStateCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PullRequestId
        /// <summary>
        /// <para>
        /// <para>The system-generated ID for the pull request.</para>
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
        /// <para>The system-generated ID for the pull request revision.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Approvals'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.GetPullRequestApprovalStatesResponse).
        /// Specifying the name of a property of type Amazon.CodeCommit.Model.GetPullRequestApprovalStatesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Approvals";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.GetPullRequestApprovalStatesResponse, GetCCPullRequestApprovalStateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.CodeCommit.Model.GetPullRequestApprovalStatesRequest();
            
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
        
        private Amazon.CodeCommit.Model.GetPullRequestApprovalStatesResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.GetPullRequestApprovalStatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "GetPullRequestApprovalStates");
            try
            {
                #if DESKTOP
                return client.GetPullRequestApprovalStates(request);
                #elif CORECLR
                return client.GetPullRequestApprovalStatesAsync(request).GetAwaiter().GetResult();
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
            public System.String PullRequestId { get; set; }
            public System.String RevisionId { get; set; }
            public System.Func<Amazon.CodeCommit.Model.GetPullRequestApprovalStatesResponse, GetCCPullRequestApprovalStateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Approvals;
        }
        
    }
}
