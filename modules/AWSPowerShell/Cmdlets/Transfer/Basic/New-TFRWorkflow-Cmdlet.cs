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
using Amazon.Transfer;
using Amazon.Transfer.Model;

namespace Amazon.PowerShell.Cmdlets.TFR
{
    /// <summary>
    /// Allows you to create a workflow with specified steps and step details the workflow
    /// invokes after file transfer completes. After creating a workflow, you can associate
    /// the workflow created with any transfer servers by specifying the <c>workflow-details</c>
    /// field in <c>CreateServer</c> and <c>UpdateServer</c> operations.
    /// </summary>
    [Cmdlet("New", "TFRWorkflow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP CreateWorkflow API operation.", Operation = new[] {"CreateWorkflow"}, SelectReturnType = typeof(Amazon.Transfer.Model.CreateWorkflowResponse))]
    [AWSCmdletOutput("System.String or Amazon.Transfer.Model.CreateWorkflowResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Transfer.Model.CreateWorkflowResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewTFRWorkflowCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A textual description for the workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter OnExceptionStep
        /// <summary>
        /// <para>
        /// <para>Specifies the steps (actions) to take if errors are encountered during execution of
        /// the workflow.</para><note><para>For custom steps, the Lambda function needs to send <c>FAILURE</c> to the call back
        /// API to kick off the exception steps. Additionally, if the Lambda does not send <c>SUCCESS</c>
        /// before it times out, the exception steps are executed.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnExceptionSteps")]
        public Amazon.Transfer.Model.WorkflowStep[] OnExceptionStep { get; set; }
        #endregion
        
        #region Parameter Step
        /// <summary>
        /// <para>
        /// <para>Specifies the details for the steps that are in the specified workflow.</para><para> The <c>TYPE</c> specifies which of the following actions is being taken for this
        /// step. </para><ul><li><para><b><c>COPY</c></b> - Copy the file to another location.</para></li><li><para><b><c>CUSTOM</c></b> - Perform a custom step with an Lambda function target.</para></li><li><para><b><c>DECRYPT</c></b> - Decrypt a file that was encrypted before it was uploaded.</para></li><li><para><b><c>DELETE</c></b> - Delete the file.</para></li><li><para><b><c>TAG</c></b> - Add a tag to the file.</para></li></ul><note><para> Currently, copying and tagging are supported only on S3. </para></note><para> For file location, you specify either the Amazon S3 bucket and key, or the Amazon
        /// EFS file system ID and path. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Steps")]
        public Amazon.Transfer.Model.WorkflowStep[] Step { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs that can be used to group and search for workflows. Tags are metadata
        /// attached to workflows for any purpose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Transfer.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WorkflowId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.CreateWorkflowResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.CreateWorkflowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WorkflowId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Description), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TFRWorkflow (CreateWorkflow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.CreateWorkflowResponse, NewTFRWorkflowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            if (this.OnExceptionStep != null)
            {
                context.OnExceptionStep = new List<Amazon.Transfer.Model.WorkflowStep>(this.OnExceptionStep);
            }
            if (this.Step != null)
            {
                context.Step = new List<Amazon.Transfer.Model.WorkflowStep>(this.Step);
            }
            #if MODULAR
            if (this.Step == null && ParameterWasBound(nameof(this.Step)))
            {
                WriteWarning("You are passing $null as a value for parameter Step which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Transfer.Model.Tag>(this.Tag);
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
            var request = new Amazon.Transfer.Model.CreateWorkflowRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.OnExceptionStep != null)
            {
                request.OnExceptionSteps = cmdletContext.OnExceptionStep;
            }
            if (cmdletContext.Step != null)
            {
                request.Steps = cmdletContext.Step;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Transfer.Model.CreateWorkflowResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.CreateWorkflowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "CreateWorkflow");
            try
            {
                #if DESKTOP
                return client.CreateWorkflow(request);
                #elif CORECLR
                return client.CreateWorkflowAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public List<Amazon.Transfer.Model.WorkflowStep> OnExceptionStep { get; set; }
            public List<Amazon.Transfer.Model.WorkflowStep> Step { get; set; }
            public List<Amazon.Transfer.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Transfer.Model.CreateWorkflowResponse, NewTFRWorkflowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WorkflowId;
        }
        
    }
}
