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
    /// Terminates and cleans up a workflow run, stopping all associated acts and sessions.
    /// </summary>
    [Cmdlet("Remove", "NOVAWorkflowRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.NovaAct.WorkflowRunStatus")]
    [AWSCmdlet("Calls the Amazon Nova Act DeleteWorkflowRun API operation.", Operation = new[] {"DeleteWorkflowRun"}, SelectReturnType = typeof(Amazon.NovaAct.Model.DeleteWorkflowRunResponse))]
    [AWSCmdletOutput("Amazon.NovaAct.WorkflowRunStatus or Amazon.NovaAct.Model.DeleteWorkflowRunResponse",
        "This cmdlet returns an Amazon.NovaAct.WorkflowRunStatus object.",
        "The service call response (type Amazon.NovaAct.Model.DeleteWorkflowRunResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveNOVAWorkflowRunCmdlet : AmazonNovaActClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter WorkflowDefinitionName
        /// <summary>
        /// <para>
        /// <para>The name of the workflow definition containing the workflow run.</para>
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
        /// <para>The unique identifier of the workflow run to delete.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NovaAct.Model.DeleteWorkflowRunResponse).
        /// Specifying the name of a property of type Amazon.NovaAct.Model.DeleteWorkflowRunResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkflowRunId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-NOVAWorkflowRun (DeleteWorkflowRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NovaAct.Model.DeleteWorkflowRunResponse, RemoveNOVAWorkflowRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.NovaAct.Model.DeleteWorkflowRunRequest();
            
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
        
        private Amazon.NovaAct.Model.DeleteWorkflowRunResponse CallAWSServiceOperation(IAmazonNovaAct client, Amazon.NovaAct.Model.DeleteWorkflowRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Nova Act", "DeleteWorkflowRun");
            try
            {
                return client.DeleteWorkflowRunAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String WorkflowDefinitionName { get; set; }
            public System.String WorkflowRunId { get; set; }
            public System.Func<Amazon.NovaAct.Model.DeleteWorkflowRunResponse, RemoveNOVAWorkflowRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
