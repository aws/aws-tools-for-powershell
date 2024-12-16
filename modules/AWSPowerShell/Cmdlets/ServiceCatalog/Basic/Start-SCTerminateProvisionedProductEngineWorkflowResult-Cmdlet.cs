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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Notifies the result of the terminate engine execution.
    /// </summary>
    [Cmdlet("Start", "SCTerminateProvisionedProductEngineWorkflowResult", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Service Catalog NotifyTerminateProvisionedProductEngineWorkflowResult API operation.", Operation = new[] {"NotifyTerminateProvisionedProductEngineWorkflowResult"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.NotifyTerminateProvisionedProductEngineWorkflowResultResponse))]
    [AWSCmdletOutput("None or Amazon.ServiceCatalog.Model.NotifyTerminateProvisionedProductEngineWorkflowResultResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ServiceCatalog.Model.NotifyTerminateProvisionedProductEngineWorkflowResultResponse) be returned by specifying '-Select *'."
    )]
    public partial class StartSCTerminateProvisionedProductEngineWorkflowResultCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FailureReason
        /// <summary>
        /// <para>
        /// <para> The reason why the terminate engine execution failed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FailureReason { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para> The idempotency token that identifies the terminate engine execution. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter RecordId
        /// <summary>
        /// <para>
        /// <para> The identifier of the record. </para>
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
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para> The status of the terminate engine execution. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ServiceCatalog.EngineWorkflowStatus")]
        public Amazon.ServiceCatalog.EngineWorkflowStatus Status { get; set; }
        #endregion
        
        #region Parameter WorkflowToken
        /// <summary>
        /// <para>
        /// <para> The encrypted contents of the terminate engine execution payload that Service Catalog
        /// sends after the Terraform product terminate workflow starts. </para>
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
        public System.String WorkflowToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.NotifyTerminateProvisionedProductEngineWorkflowResultResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecordId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SCTerminateProvisionedProductEngineWorkflowResult (NotifyTerminateProvisionedProductEngineWorkflowResult)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.NotifyTerminateProvisionedProductEngineWorkflowResultResponse, StartSCTerminateProvisionedProductEngineWorkflowResultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FailureReason = this.FailureReason;
            context.IdempotencyToken = this.IdempotencyToken;
            context.RecordId = this.RecordId;
            #if MODULAR
            if (this.RecordId == null && ParameterWasBound(nameof(this.RecordId)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Status = this.Status;
            #if MODULAR
            if (this.Status == null && ParameterWasBound(nameof(this.Status)))
            {
                WriteWarning("You are passing $null as a value for parameter Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowToken = this.WorkflowToken;
            #if MODULAR
            if (this.WorkflowToken == null && ParameterWasBound(nameof(this.WorkflowToken)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ServiceCatalog.Model.NotifyTerminateProvisionedProductEngineWorkflowResultRequest();
            
            if (cmdletContext.FailureReason != null)
            {
                request.FailureReason = cmdletContext.FailureReason;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.RecordId != null)
            {
                request.RecordId = cmdletContext.RecordId;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.WorkflowToken != null)
            {
                request.WorkflowToken = cmdletContext.WorkflowToken;
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
        
        private Amazon.ServiceCatalog.Model.NotifyTerminateProvisionedProductEngineWorkflowResultResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.NotifyTerminateProvisionedProductEngineWorkflowResultRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "NotifyTerminateProvisionedProductEngineWorkflowResult");
            try
            {
                #if DESKTOP
                return client.NotifyTerminateProvisionedProductEngineWorkflowResult(request);
                #elif CORECLR
                return client.NotifyTerminateProvisionedProductEngineWorkflowResultAsync(request).GetAwaiter().GetResult();
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
            public System.String FailureReason { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String RecordId { get; set; }
            public Amazon.ServiceCatalog.EngineWorkflowStatus Status { get; set; }
            public System.String WorkflowToken { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.NotifyTerminateProvisionedProductEngineWorkflowResultResponse, StartSCTerminateProvisionedProductEngineWorkflowResultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
