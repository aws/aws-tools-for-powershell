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
using Amazon.NovaAct;
using Amazon.NovaAct.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NOVA
{
    /// <summary>
    /// Updates an existing act's configuration, status, or error information.
    /// </summary>
    [Cmdlet("Update", "NOVAAct", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Nova Act UpdateAct API operation.", Operation = new[] {"UpdateAct"}, SelectReturnType = typeof(Amazon.NovaAct.Model.UpdateActResponse))]
    [AWSCmdletOutput("None or Amazon.NovaAct.Model.UpdateActResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.NovaAct.Model.UpdateActResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateNOVAActCmdlet : AmazonNovaActClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the act to update.</para>
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
        public System.String ActId { get; set; }
        #endregion
        
        #region Parameter Error_Message
        /// <summary>
        /// <para>
        /// <para>A human-readable description of the error that occurred.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Error_Message { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the session containing the act.</para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The new status to set for the act.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.NovaAct.ActStatus")]
        public Amazon.NovaAct.ActStatus Status { get; set; }
        #endregion
        
        #region Parameter Error_Type
        /// <summary>
        /// <para>
        /// <para>The type or category of error that occurred.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Error_Type { get; set; }
        #endregion
        
        #region Parameter WorkflowDefinitionName
        /// <summary>
        /// <para>
        /// <para>The name of the workflow definition containing the act.</para>
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
        public System.String WorkflowDefinitionName { get; set; }
        #endregion
        
        #region Parameter WorkflowRunId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the workflow run containing the act.</para>
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
        public System.String WorkflowRunId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NovaAct.Model.UpdateActResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ActId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NOVAAct (UpdateAct)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NovaAct.Model.UpdateActResponse, UpdateNOVAActCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActId = this.ActId;
            #if MODULAR
            if (this.ActId == null && ParameterWasBound(nameof(this.ActId)))
            {
                WriteWarning("You are passing $null as a value for parameter ActId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Error_Message = this.Error_Message;
            context.Error_Type = this.Error_Type;
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Status = this.Status;
            #if MODULAR
            if (this.Status == null && ParameterWasBound(nameof(this.Status)))
            {
                WriteWarning("You are passing $null as a value for parameter Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowDefinitionName = this.WorkflowDefinitionName;
            #if MODULAR
            if (this.WorkflowDefinitionName == null && ParameterWasBound(nameof(this.WorkflowDefinitionName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowDefinitionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowRunId = this.WorkflowRunId;
            #if MODULAR
            if (this.WorkflowRunId == null && ParameterWasBound(nameof(this.WorkflowRunId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowRunId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NovaAct.Model.UpdateActRequest();
            
            if (cmdletContext.ActId != null)
            {
                request.ActId = cmdletContext.ActId;
            }
            
             // populate Error
            var requestErrorIsNull = true;
            request.Error = new Amazon.NovaAct.Model.ActError();
            System.String requestError_error_Message = null;
            if (cmdletContext.Error_Message != null)
            {
                requestError_error_Message = cmdletContext.Error_Message;
            }
            if (requestError_error_Message != null)
            {
                request.Error.Message = requestError_error_Message;
                requestErrorIsNull = false;
            }
            System.String requestError_error_Type = null;
            if (cmdletContext.Error_Type != null)
            {
                requestError_error_Type = cmdletContext.Error_Type;
            }
            if (requestError_error_Type != null)
            {
                request.Error.Type = requestError_error_Type;
                requestErrorIsNull = false;
            }
             // determine if request.Error should be set to null
            if (requestErrorIsNull)
            {
                request.Error = null;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.WorkflowDefinitionName != null)
            {
                request.WorkflowDefinitionName = cmdletContext.WorkflowDefinitionName;
            }
            if (cmdletContext.WorkflowRunId != null)
            {
                request.WorkflowRunId = cmdletContext.WorkflowRunId;
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
        
        private Amazon.NovaAct.Model.UpdateActResponse CallAWSServiceOperation(IAmazonNovaAct client, Amazon.NovaAct.Model.UpdateActRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Nova Act", "UpdateAct");
            try
            {
                return client.UpdateActAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ActId { get; set; }
            public System.String Error_Message { get; set; }
            public System.String Error_Type { get; set; }
            public System.String SessionId { get; set; }
            public Amazon.NovaAct.ActStatus Status { get; set; }
            public System.String WorkflowDefinitionName { get; set; }
            public System.String WorkflowRunId { get; set; }
            public System.Func<Amazon.NovaAct.Model.UpdateActResponse, UpdateNOVAActCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
