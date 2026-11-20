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
using Amazon.AgentRegistryControl;
using Amazon.AgentRegistryControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AGRC
{
    /// <summary>
    /// Record the curator's decision (APPROVED or REJECTED) on a registry record's publisher
    /// association. A successful call returns an empty response. Repeating the decision the
    /// association already holds changes nothing; the same approvalStatus with a different
    /// approvalStatusReason updates the reason. If the caller has no publisher association
    /// for the registry record, the request fails with AccessDeniedException. A ConflictException
    /// (HTTP 409) means the association is not in a state that accepts the decision (e.g.
    /// not PENDING_APPROVAL/APPROVED/REJECTED) or it changed while the request was being
    /// applied; read it again before deciding whether to resubmit.
    /// </summary>
    [Cmdlet("Update", "AGRCPublisherAssociationApprovalStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Agent Registry Control UpdatePublisherAssociationApprovalStatus API operation.", Operation = new[] {"UpdatePublisherAssociationApprovalStatus"}, SelectReturnType = typeof(Amazon.AgentRegistryControl.Model.UpdatePublisherAssociationApprovalStatusResponse))]
    [AWSCmdletOutput("None or Amazon.AgentRegistryControl.Model.UpdatePublisherAssociationApprovalStatusResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AgentRegistryControl.Model.UpdatePublisherAssociationApprovalStatusResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateAGRCPublisherAssociationApprovalStatusCmdlet : AmazonAgentRegistryControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApprovalStatus
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AgentRegistryControl.AssociationApprovalStatus")]
        public Amazon.AgentRegistryControl.AssociationApprovalStatus ApprovalStatus { get; set; }
        #endregion
        
        #region Parameter ApprovalStatusReason
        /// <summary>
        /// <para>
        /// The curator's reason for the decision;
        /// may be empty.
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
        public System.String ApprovalStatusReason { get; set; }
        #endregion
        
        #region Parameter RecordArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String RecordArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AgentRegistryControl.Model.UpdatePublisherAssociationApprovalStatusResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecordArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AGRCPublisherAssociationApprovalStatus (UpdatePublisherAssociationApprovalStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AgentRegistryControl.Model.UpdatePublisherAssociationApprovalStatusResponse, UpdateAGRCPublisherAssociationApprovalStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApprovalStatus = this.ApprovalStatus;
            #if MODULAR
            if (this.ApprovalStatus == null && ParameterWasBound(nameof(this.ApprovalStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter ApprovalStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApprovalStatusReason = this.ApprovalStatusReason;
            #if MODULAR
            if (this.ApprovalStatusReason == null && ParameterWasBound(nameof(this.ApprovalStatusReason)))
            {
                WriteWarning("You are passing $null as a value for parameter ApprovalStatusReason which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecordArn = this.RecordArn;
            #if MODULAR
            if (this.RecordArn == null && ParameterWasBound(nameof(this.RecordArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AgentRegistryControl.Model.UpdatePublisherAssociationApprovalStatusRequest();
            
            if (cmdletContext.ApprovalStatus != null)
            {
                request.ApprovalStatus = cmdletContext.ApprovalStatus;
            }
            if (cmdletContext.ApprovalStatusReason != null)
            {
                request.ApprovalStatusReason = cmdletContext.ApprovalStatusReason;
            }
            if (cmdletContext.RecordArn != null)
            {
                request.RecordArn = cmdletContext.RecordArn;
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
        
        private Amazon.AgentRegistryControl.Model.UpdatePublisherAssociationApprovalStatusResponse CallAWSServiceOperation(IAmazonAgentRegistryControl client, Amazon.AgentRegistryControl.Model.UpdatePublisherAssociationApprovalStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agent Registry Control", "UpdatePublisherAssociationApprovalStatus");
            try
            {
                return client.UpdatePublisherAssociationApprovalStatusAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.AgentRegistryControl.AssociationApprovalStatus ApprovalStatus { get; set; }
            public System.String ApprovalStatusReason { get; set; }
            public System.String RecordArn { get; set; }
            public System.Func<Amazon.AgentRegistryControl.Model.UpdatePublisherAssociationApprovalStatusResponse, UpdateAGRCPublisherAssociationApprovalStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
