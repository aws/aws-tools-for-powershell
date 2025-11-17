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
using Amazon.MWAAServerless;
using Amazon.MWAAServerless.Model;

namespace Amazon.PowerShell.Cmdlets.MWAAS
{
    /// <summary>
    /// Stops a running workflow execution. This operation terminates all running tasks and
    /// prevents new tasks from starting. Amazon Managed Workflows for Apache Airflow Serverless
    /// gracefully shuts down the workflow execution by stopping task scheduling and terminating
    /// active ECS worker containers. The operation transitions the workflow run to a <c>STOPPING</c>
    /// state and then to <c>STOPPED</c> once all cleanup is complete. In-flight tasks may
    /// complete or be terminated depending on their current execution state.
    /// </summary>
    [Cmdlet("Stop", "MWAASWorkflowRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MWAAServerless.Model.StopWorkflowRunResponse")]
    [AWSCmdlet("Calls the AmazonMWAAServerless StopWorkflowRun API operation.", Operation = new[] {"StopWorkflowRun"}, SelectReturnType = typeof(Amazon.MWAAServerless.Model.StopWorkflowRunResponse))]
    [AWSCmdletOutput("Amazon.MWAAServerless.Model.StopWorkflowRunResponse",
        "This cmdlet returns an Amazon.MWAAServerless.Model.StopWorkflowRunResponse object containing multiple properties."
    )]
    public partial class StopMWAASWorkflowRunCmdlet : AmazonMWAAServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RunId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the workflow run to stop.</para>
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
        public System.String RunId { get; set; }
        #endregion
        
        #region Parameter WorkflowArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the workflow that contains the run you want to stop.</para>
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
        public System.String WorkflowArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MWAAServerless.Model.StopWorkflowRunResponse).
        /// Specifying the name of a property of type Amazon.MWAAServerless.Model.StopWorkflowRunResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.RunId),
                nameof(this.WorkflowArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-MWAASWorkflowRun (StopWorkflowRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MWAAServerless.Model.StopWorkflowRunResponse, StopMWAASWorkflowRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RunId = this.RunId;
            #if MODULAR
            if (this.RunId == null && ParameterWasBound(nameof(this.RunId)))
            {
                WriteWarning("You are passing $null as a value for parameter RunId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowArn = this.WorkflowArn;
            #if MODULAR
            if (this.WorkflowArn == null && ParameterWasBound(nameof(this.WorkflowArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MWAAServerless.Model.StopWorkflowRunRequest();
            
            if (cmdletContext.RunId != null)
            {
                request.RunId = cmdletContext.RunId;
            }
            if (cmdletContext.WorkflowArn != null)
            {
                request.WorkflowArn = cmdletContext.WorkflowArn;
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
        
        private Amazon.MWAAServerless.Model.StopWorkflowRunResponse CallAWSServiceOperation(IAmazonMWAAServerless client, Amazon.MWAAServerless.Model.StopWorkflowRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonMWAAServerless", "StopWorkflowRun");
            try
            {
                #if DESKTOP
                return client.StopWorkflowRun(request);
                #elif CORECLR
                return client.StopWorkflowRunAsync(request).GetAwaiter().GetResult();
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
            public System.String RunId { get; set; }
            public System.String WorkflowArn { get; set; }
            public System.Func<Amazon.MWAAServerless.Model.StopWorkflowRunResponse, StopMWAASWorkflowRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
