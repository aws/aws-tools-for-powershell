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
using Amazon.MPA;
using Amazon.MPA.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MPA
{
    /// <summary>
    /// Updates an approval team. You can request to update the team description, approval
    /// threshold, and approvers in the team.
    /// 
    ///  <note><para><b>Updates require team approval</b></para><para>
    /// Updates to an active team must be approved by the team.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "MPAApprovalTeam", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Multi-party Approval UpdateApprovalTeam API operation.", Operation = new[] {"UpdateApprovalTeam"}, SelectReturnType = typeof(Amazon.MPA.Model.UpdateApprovalTeamResponse))]
    [AWSCmdletOutput("System.String or Amazon.MPA.Model.UpdateApprovalTeamResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MPA.Model.UpdateApprovalTeamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateMPAApprovalTeamCmdlet : AmazonMPAClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Approver
        /// <summary>
        /// <para>
        /// <para>An array of <c>ApprovalTeamRequestApprover</c> objects. Contains details for the approvers
        /// in the team.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Approvers")]
        public Amazon.MPA.Model.ApprovalTeamRequestApprover[] Approver { get; set; }
        #endregion
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) for the team.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Description for the team.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MofN_MinApprovalsRequired
        /// <summary>
        /// <para>
        /// <para>Minimum number of approvals (M) required for a total number of approvers (N).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApprovalStrategy_MofN_MinApprovalsRequired")]
        public System.Int32? MofN_MinApprovalsRequired { get; set; }
        #endregion
        
        #region Parameter UpdateAction
        /// <summary>
        /// <para>
        /// <para>A list of <c>UpdateAction</c> to perform when updating the team.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateActions")]
        public System.String[] UpdateAction { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VersionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MPA.Model.UpdateApprovalTeamResponse).
        /// Specifying the name of a property of type Amazon.MPA.Model.UpdateApprovalTeamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VersionId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MPAApprovalTeam (UpdateApprovalTeam)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MPA.Model.UpdateApprovalTeamResponse, UpdateMPAApprovalTeamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MofN_MinApprovalsRequired = this.MofN_MinApprovalsRequired;
            if (this.Approver != null)
            {
                context.Approver = new List<Amazon.MPA.Model.ApprovalTeamRequestApprover>(this.Approver);
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            if (this.UpdateAction != null)
            {
                context.UpdateAction = new List<System.String>(this.UpdateAction);
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
            var request = new Amazon.MPA.Model.UpdateApprovalTeamRequest();
            
            
             // populate ApprovalStrategy
            var requestApprovalStrategyIsNull = true;
            request.ApprovalStrategy = new Amazon.MPA.Model.ApprovalStrategy();
            Amazon.MPA.Model.MofNApprovalStrategy requestApprovalStrategy_approvalStrategy_MofN = null;
            
             // populate MofN
            var requestApprovalStrategy_approvalStrategy_MofNIsNull = true;
            requestApprovalStrategy_approvalStrategy_MofN = new Amazon.MPA.Model.MofNApprovalStrategy();
            System.Int32? requestApprovalStrategy_approvalStrategy_MofN_mofN_MinApprovalsRequired = null;
            if (cmdletContext.MofN_MinApprovalsRequired != null)
            {
                requestApprovalStrategy_approvalStrategy_MofN_mofN_MinApprovalsRequired = cmdletContext.MofN_MinApprovalsRequired.Value;
            }
            if (requestApprovalStrategy_approvalStrategy_MofN_mofN_MinApprovalsRequired != null)
            {
                requestApprovalStrategy_approvalStrategy_MofN.MinApprovalsRequired = requestApprovalStrategy_approvalStrategy_MofN_mofN_MinApprovalsRequired.Value;
                requestApprovalStrategy_approvalStrategy_MofNIsNull = false;
            }
             // determine if requestApprovalStrategy_approvalStrategy_MofN should be set to null
            if (requestApprovalStrategy_approvalStrategy_MofNIsNull)
            {
                requestApprovalStrategy_approvalStrategy_MofN = null;
            }
            if (requestApprovalStrategy_approvalStrategy_MofN != null)
            {
                request.ApprovalStrategy.MofN = requestApprovalStrategy_approvalStrategy_MofN;
                requestApprovalStrategyIsNull = false;
            }
             // determine if request.ApprovalStrategy should be set to null
            if (requestApprovalStrategyIsNull)
            {
                request.ApprovalStrategy = null;
            }
            if (cmdletContext.Approver != null)
            {
                request.Approvers = cmdletContext.Approver;
            }
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.UpdateAction != null)
            {
                request.UpdateActions = cmdletContext.UpdateAction;
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
        
        private Amazon.MPA.Model.UpdateApprovalTeamResponse CallAWSServiceOperation(IAmazonMPA client, Amazon.MPA.Model.UpdateApprovalTeamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Multi-party Approval", "UpdateApprovalTeam");
            try
            {
                return client.UpdateApprovalTeamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MofN_MinApprovalsRequired { get; set; }
            public List<Amazon.MPA.Model.ApprovalTeamRequestApprover> Approver { get; set; }
            public System.String Arn { get; set; }
            public System.String Description { get; set; }
            public List<System.String> UpdateAction { get; set; }
            public System.Func<Amazon.MPA.Model.UpdateApprovalTeamResponse, UpdateMPAApprovalTeamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VersionId;
        }
        
    }
}
