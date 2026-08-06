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
    /// Updates the status of a registry record as part of the registry's curation workflow,
    /// for example to approve or reject a record that is pending approval, or to deprecate
    /// an approved record so that it is no longer discoverable
    /// </summary>
    [Cmdlet("Update", "AGRCRegistryRecordStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AgentRegistryControl.Model.UpdateRegistryRecordStatusResponse")]
    [AWSCmdlet("Calls the Agent Registry Control UpdateRegistryRecordStatus API operation.", Operation = new[] {"UpdateRegistryRecordStatus"}, SelectReturnType = typeof(Amazon.AgentRegistryControl.Model.UpdateRegistryRecordStatusResponse))]
    [AWSCmdletOutput("Amazon.AgentRegistryControl.Model.UpdateRegistryRecordStatusResponse",
        "This cmdlet returns an Amazon.AgentRegistryControl.Model.UpdateRegistryRecordStatusResponse object containing multiple properties."
    )]
    public partial class UpdateAGRCRegistryRecordStatusCmdlet : AmazonAgentRegistryControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RecordId
        /// <summary>
        /// <para>
        /// <para>The identifier of the registry record to update the status of (ARN or ID)</para>
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
        public System.String RecordId { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the registry containing the record (ARN or ID)</para>
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
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The target status for the registry record</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AgentRegistryControl.RegistryRecordStatus")]
        public Amazon.AgentRegistryControl.RegistryRecordStatus Status { get; set; }
        #endregion
        
        #region Parameter StatusReason
        /// <summary>
        /// <para>
        /// <para>The reason for the status change, for example why the record was approved, rejected,
        /// or deprecated</para>
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
        public System.String StatusReason { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AgentRegistryControl.Model.UpdateRegistryRecordStatusResponse).
        /// Specifying the name of a property of type Amazon.AgentRegistryControl.Model.UpdateRegistryRecordStatusResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.RecordId),
                nameof(this.RegistryId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AGRCRegistryRecordStatus (UpdateRegistryRecordStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AgentRegistryControl.Model.UpdateRegistryRecordStatusResponse, UpdateAGRCRegistryRecordStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RecordId = this.RecordId;
            #if MODULAR
            if (this.RecordId == null && ParameterWasBound(nameof(this.RecordId)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RegistryId = this.RegistryId;
            #if MODULAR
            if (this.RegistryId == null && ParameterWasBound(nameof(this.RegistryId)))
            {
                WriteWarning("You are passing $null as a value for parameter RegistryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Status = this.Status;
            #if MODULAR
            if (this.Status == null && ParameterWasBound(nameof(this.Status)))
            {
                WriteWarning("You are passing $null as a value for parameter Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StatusReason = this.StatusReason;
            #if MODULAR
            if (this.StatusReason == null && ParameterWasBound(nameof(this.StatusReason)))
            {
                WriteWarning("You are passing $null as a value for parameter StatusReason which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AgentRegistryControl.Model.UpdateRegistryRecordStatusRequest();
            
            if (cmdletContext.RecordId != null)
            {
                request.RecordId = cmdletContext.RecordId;
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryId = cmdletContext.RegistryId;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.StatusReason != null)
            {
                request.StatusReason = cmdletContext.StatusReason;
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
        
        private Amazon.AgentRegistryControl.Model.UpdateRegistryRecordStatusResponse CallAWSServiceOperation(IAmazonAgentRegistryControl client, Amazon.AgentRegistryControl.Model.UpdateRegistryRecordStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agent Registry Control", "UpdateRegistryRecordStatus");
            try
            {
                return client.UpdateRegistryRecordStatusAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String RecordId { get; set; }
            public System.String RegistryId { get; set; }
            public Amazon.AgentRegistryControl.RegistryRecordStatus Status { get; set; }
            public System.String StatusReason { get; set; }
            public System.Func<Amazon.AgentRegistryControl.Model.UpdateRegistryRecordStatusResponse, UpdateAGRCRegistryRecordStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
