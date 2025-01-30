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
using Amazon.Imagebuilder;
using Amazon.Imagebuilder.Model;

namespace Amazon.PowerShell.Cmdlets.EC2IB
{
    /// <summary>
    /// Pauses or resumes image creation when the associated workflow runs a <c>WaitForAction</c>
    /// step.
    /// </summary>
    [Cmdlet("Send", "EC2IBWorkflowStepAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Imagebuilder.Model.SendWorkflowStepActionResponse")]
    [AWSCmdlet("Calls the EC2 Image Builder SendWorkflowStepAction API operation.", Operation = new[] {"SendWorkflowStepAction"}, SelectReturnType = typeof(Amazon.Imagebuilder.Model.SendWorkflowStepActionResponse))]
    [AWSCmdletOutput("Amazon.Imagebuilder.Model.SendWorkflowStepActionResponse",
        "This cmdlet returns an Amazon.Imagebuilder.Model.SendWorkflowStepActionResponse object containing multiple properties."
    )]
    public partial class SendEC2IBWorkflowStepActionCmdlet : AmazonImagebuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The action for the image creation process to take while a workflow <c>WaitForAction</c>
        /// step waits for an asynchronous action to complete.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Imagebuilder.WorkflowStepActionType")]
        public Amazon.Imagebuilder.WorkflowStepActionType Action { get; set; }
        #endregion
        
        #region Parameter ImageBuildVersionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the image build version to send action for.</para>
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
        public System.String ImageBuildVersionArn { get; set; }
        #endregion
        
        #region Parameter Reason
        /// <summary>
        /// <para>
        /// <para>The reason why this action is sent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Reason { get; set; }
        #endregion
        
        #region Parameter StepExecutionId
        /// <summary>
        /// <para>
        /// <para>Uniquely identifies the workflow step that sent the step action.</para>
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
        public System.String StepExecutionId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure idempotency of the request.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a> in the <i>Amazon EC2 API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Imagebuilder.Model.SendWorkflowStepActionResponse).
        /// Specifying the name of a property of type Amazon.Imagebuilder.Model.SendWorkflowStepActionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StepExecutionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StepExecutionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StepExecutionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StepExecutionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-EC2IBWorkflowStepAction (SendWorkflowStepAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Imagebuilder.Model.SendWorkflowStepActionResponse, SendEC2IBWorkflowStepActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StepExecutionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Action = this.Action;
            #if MODULAR
            if (this.Action == null && ParameterWasBound(nameof(this.Action)))
            {
                WriteWarning("You are passing $null as a value for parameter Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.ImageBuildVersionArn = this.ImageBuildVersionArn;
            #if MODULAR
            if (this.ImageBuildVersionArn == null && ParameterWasBound(nameof(this.ImageBuildVersionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageBuildVersionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Reason = this.Reason;
            context.StepExecutionId = this.StepExecutionId;
            #if MODULAR
            if (this.StepExecutionId == null && ParameterWasBound(nameof(this.StepExecutionId)))
            {
                WriteWarning("You are passing $null as a value for parameter StepExecutionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Imagebuilder.Model.SendWorkflowStepActionRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ImageBuildVersionArn != null)
            {
                request.ImageBuildVersionArn = cmdletContext.ImageBuildVersionArn;
            }
            if (cmdletContext.Reason != null)
            {
                request.Reason = cmdletContext.Reason;
            }
            if (cmdletContext.StepExecutionId != null)
            {
                request.StepExecutionId = cmdletContext.StepExecutionId;
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
        
        private Amazon.Imagebuilder.Model.SendWorkflowStepActionResponse CallAWSServiceOperation(IAmazonImagebuilder client, Amazon.Imagebuilder.Model.SendWorkflowStepActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EC2 Image Builder", "SendWorkflowStepAction");
            try
            {
                #if DESKTOP
                return client.SendWorkflowStepAction(request);
                #elif CORECLR
                return client.SendWorkflowStepActionAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Imagebuilder.WorkflowStepActionType Action { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ImageBuildVersionArn { get; set; }
            public System.String Reason { get; set; }
            public System.String StepExecutionId { get; set; }
            public System.Func<Amazon.Imagebuilder.Model.SendWorkflowStepActionResponse, SendEC2IBWorkflowStepActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
