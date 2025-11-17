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
    /// Deletes a workflow and all its versions. This operation permanently removes the workflow
    /// and cannot be undone. Amazon Managed Workflows for Apache Airflow Serverless ensures
    /// that all associated resources are properly cleaned up, including stopping any running
    /// executions, removing scheduled triggers, and cleaning up execution history. The deletion
    /// process respects the multi-tenant isolation boundaries and ensures that no residual
    /// data or configurations remain that could affect other customers or workflows.
    /// </summary>
    [Cmdlet("Remove", "MWAASWorkflow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.MWAAServerless.Model.DeleteWorkflowResponse")]
    [AWSCmdlet("Calls the AmazonMWAAServerless DeleteWorkflow API operation.", Operation = new[] {"DeleteWorkflow"}, SelectReturnType = typeof(Amazon.MWAAServerless.Model.DeleteWorkflowResponse))]
    [AWSCmdletOutput("Amazon.MWAAServerless.Model.DeleteWorkflowResponse",
        "This cmdlet returns an Amazon.MWAAServerless.Model.DeleteWorkflowResponse object containing multiple properties."
    )]
    public partial class RemoveMWAASWorkflowCmdlet : AmazonMWAAServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter WorkflowArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the workflow you want to delete.</para>
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
        public System.String WorkflowArn { get; set; }
        #endregion
        
        #region Parameter WorkflowVersion
        /// <summary>
        /// <para>
        /// <para>Optional. The specific version of the workflow to delete. If not specified, all versions
        /// of the workflow are deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkflowVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MWAAServerless.Model.DeleteWorkflowResponse).
        /// Specifying the name of a property of type Amazon.MWAAServerless.Model.DeleteWorkflowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkflowArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkflowArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkflowArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkflowArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-MWAASWorkflow (DeleteWorkflow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MWAAServerless.Model.DeleteWorkflowResponse, RemoveMWAASWorkflowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkflowArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.WorkflowArn = this.WorkflowArn;
            #if MODULAR
            if (this.WorkflowArn == null && ParameterWasBound(nameof(this.WorkflowArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowVersion = this.WorkflowVersion;
            
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
            var request = new Amazon.MWAAServerless.Model.DeleteWorkflowRequest();
            
            if (cmdletContext.WorkflowArn != null)
            {
                request.WorkflowArn = cmdletContext.WorkflowArn;
            }
            if (cmdletContext.WorkflowVersion != null)
            {
                request.WorkflowVersion = cmdletContext.WorkflowVersion;
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
        
        private Amazon.MWAAServerless.Model.DeleteWorkflowResponse CallAWSServiceOperation(IAmazonMWAAServerless client, Amazon.MWAAServerless.Model.DeleteWorkflowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonMWAAServerless", "DeleteWorkflow");
            try
            {
                #if DESKTOP
                return client.DeleteWorkflow(request);
                #elif CORECLR
                return client.DeleteWorkflowAsync(request).GetAwaiter().GetResult();
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
            public System.String WorkflowArn { get; set; }
            public System.String WorkflowVersion { get; set; }
            public System.Func<Amazon.MWAAServerless.Model.DeleteWorkflowResponse, RemoveMWAASWorkflowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
