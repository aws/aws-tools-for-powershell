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
using Amazon.SimpleWorkflow;
using Amazon.SimpleWorkflow.Model;

namespace Amazon.PowerShell.Cmdlets.SWF
{
    /// <summary>
    /// Returns information about the specified workflow execution including its type and
    /// some statistics.
    /// 
    ///  <note><para>
    /// This operation is eventually consistent. The results are best effort and may not exactly
    /// reflect recent updates and changes.
    /// </para></note><para><b>Access Control</b></para><para>
    /// You can use IAM policies to control this action's access to Amazon SWF resources as
    /// follows:
    /// </para><ul><li><para>
    /// Use a <c>Resource</c> element with the domain name to limit the action to only specified
    /// domains.
    /// </para></li><li><para>
    /// Use an <c>Action</c> element to allow or deny permission to call this action.
    /// </para></li><li><para>
    /// You cannot use an IAM policy to constrain this action's parameters.
    /// </para></li></ul><para>
    /// If the caller doesn't have sufficient permissions to invoke the action, or the parameter
    /// values fall outside the specified constraints, the action fails. The associated event
    /// attribute's <c>cause</c> parameter is set to <c>OPERATION_NOT_PERMITTED</c>. For details
    /// and example IAM policies, see <a href="https://docs.aws.amazon.com/amazonswf/latest/developerguide/swf-dev-iam.html">Using
    /// IAM to Manage Access to Amazon SWF Workflows</a> in the <i>Amazon SWF Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SWFWorkflowExecution")]
    [OutputType("Amazon.SimpleWorkflow.Model.WorkflowExecutionDetail")]
    [AWSCmdlet("Calls the AWS Simple Workflow Service (SWF) DescribeWorkflowExecution API operation.", Operation = new[] {"DescribeWorkflowExecution"}, SelectReturnType = typeof(Amazon.SimpleWorkflow.Model.DescribeWorkflowExecutionResponse))]
    [AWSCmdletOutput("Amazon.SimpleWorkflow.Model.WorkflowExecutionDetail or Amazon.SimpleWorkflow.Model.DescribeWorkflowExecutionResponse",
        "This cmdlet returns an Amazon.SimpleWorkflow.Model.WorkflowExecutionDetail object.",
        "The service call response (type Amazon.SimpleWorkflow.Model.DescribeWorkflowExecutionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSWFWorkflowExecutionCmdlet : AmazonSimpleWorkflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain containing the workflow execution.</para>
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
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter Execution_RunId
        /// <summary>
        /// <para>
        /// <para>A system-generated unique identifier for the workflow execution.</para>
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
        public System.String Execution_RunId { get; set; }
        #endregion
        
        #region Parameter Execution_WorkflowId
        /// <summary>
        /// <para>
        /// <para>The user defined identifier associated with the workflow execution.</para>
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
        public System.String Execution_WorkflowId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WorkflowExecutionDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleWorkflow.Model.DescribeWorkflowExecutionResponse).
        /// Specifying the name of a property of type Amazon.SimpleWorkflow.Model.DescribeWorkflowExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WorkflowExecutionDetail";
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
                context.Select = CreateSelectDelegate<Amazon.SimpleWorkflow.Model.DescribeWorkflowExecutionResponse, GetSWFWorkflowExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Execution_RunId = this.Execution_RunId;
            #if MODULAR
            if (this.Execution_RunId == null && ParameterWasBound(nameof(this.Execution_RunId)))
            {
                WriteWarning("You are passing $null as a value for parameter Execution_RunId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Execution_WorkflowId = this.Execution_WorkflowId;
            #if MODULAR
            if (this.Execution_WorkflowId == null && ParameterWasBound(nameof(this.Execution_WorkflowId)))
            {
                WriteWarning("You are passing $null as a value for parameter Execution_WorkflowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleWorkflow.Model.DescribeWorkflowExecutionRequest();
            
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            
             // populate Execution
            var requestExecutionIsNull = true;
            request.Execution = new Amazon.SimpleWorkflow.Model.WorkflowExecution();
            System.String requestExecution_execution_RunId = null;
            if (cmdletContext.Execution_RunId != null)
            {
                requestExecution_execution_RunId = cmdletContext.Execution_RunId;
            }
            if (requestExecution_execution_RunId != null)
            {
                request.Execution.RunId = requestExecution_execution_RunId;
                requestExecutionIsNull = false;
            }
            System.String requestExecution_execution_WorkflowId = null;
            if (cmdletContext.Execution_WorkflowId != null)
            {
                requestExecution_execution_WorkflowId = cmdletContext.Execution_WorkflowId;
            }
            if (requestExecution_execution_WorkflowId != null)
            {
                request.Execution.WorkflowId = requestExecution_execution_WorkflowId;
                requestExecutionIsNull = false;
            }
             // determine if request.Execution should be set to null
            if (requestExecutionIsNull)
            {
                request.Execution = null;
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
        
        private Amazon.SimpleWorkflow.Model.DescribeWorkflowExecutionResponse CallAWSServiceOperation(IAmazonSimpleWorkflow client, Amazon.SimpleWorkflow.Model.DescribeWorkflowExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Simple Workflow Service (SWF)", "DescribeWorkflowExecution");
            try
            {
                #if DESKTOP
                return client.DescribeWorkflowExecution(request);
                #elif CORECLR
                return client.DescribeWorkflowExecutionAsync(request).GetAwaiter().GetResult();
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
            public System.String Domain { get; set; }
            public System.String Execution_RunId { get; set; }
            public System.String Execution_WorkflowId { get; set; }
            public System.Func<Amazon.SimpleWorkflow.Model.DescribeWorkflowExecutionResponse, GetSWFWorkflowExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WorkflowExecutionDetail;
        }
        
    }
}
