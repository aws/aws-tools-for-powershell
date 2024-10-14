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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Renders the UI template so that you can preview the worker's experience.
    /// </summary>
    [Cmdlet("Invoke", "SMUiTemplateRendering", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.RenderUiTemplateResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service RenderUiTemplate API operation.", Operation = new[] {"RenderUiTemplate"}, SelectReturnType = typeof(Amazon.SageMaker.Model.RenderUiTemplateResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.RenderUiTemplateResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.RenderUiTemplateResponse object containing multiple properties."
    )]
    public partial class InvokeSMUiTemplateRenderingCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter UiTemplate_Content
        /// <summary>
        /// <para>
        /// <para>The content of the Liquid template for the worker user interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String UiTemplate_Content { get; set; }
        #endregion
        
        #region Parameter HumanTaskUiArn
        /// <summary>
        /// <para>
        /// <para>The <c>HumanTaskUiArn</c> of the worker UI that you want to render. Do not provide
        /// a <c>HumanTaskUiArn</c> if you use the <c>UiTemplate</c> parameter.</para><para>See a list of available Human Ui Amazon Resource Names (ARNs) in <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_UiConfig.html">UiConfig</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HumanTaskUiArn { get; set; }
        #endregion
        
        #region Parameter Task_Input
        /// <summary>
        /// <para>
        /// <para>A JSON object that contains values for the variables defined in the template. It is
        /// made available to the template under the substitution variable <c>task.input</c>.
        /// For example, if you define a variable <c>task.input.text</c> in your template, you
        /// can supply the variable in the JSON object as <c>"text": "sample text"</c>.</para>
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
        public System.String Task_Input { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that has access to the S3 objects that are used by
        /// the template.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.RenderUiTemplateResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.RenderUiTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UiTemplate_Content parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UiTemplate_Content' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UiTemplate_Content' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SMUiTemplateRendering (RenderUiTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.RenderUiTemplateResponse, InvokeSMUiTemplateRenderingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UiTemplate_Content;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HumanTaskUiArn = this.HumanTaskUiArn;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Task_Input = this.Task_Input;
            #if MODULAR
            if (this.Task_Input == null && ParameterWasBound(nameof(this.Task_Input)))
            {
                WriteWarning("You are passing $null as a value for parameter Task_Input which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UiTemplate_Content = this.UiTemplate_Content;
            
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
            var request = new Amazon.SageMaker.Model.RenderUiTemplateRequest();
            
            if (cmdletContext.HumanTaskUiArn != null)
            {
                request.HumanTaskUiArn = cmdletContext.HumanTaskUiArn;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate Task
            var requestTaskIsNull = true;
            request.Task = new Amazon.SageMaker.Model.RenderableTask();
            System.String requestTask_task_Input = null;
            if (cmdletContext.Task_Input != null)
            {
                requestTask_task_Input = cmdletContext.Task_Input;
            }
            if (requestTask_task_Input != null)
            {
                request.Task.Input = requestTask_task_Input;
                requestTaskIsNull = false;
            }
             // determine if request.Task should be set to null
            if (requestTaskIsNull)
            {
                request.Task = null;
            }
            
             // populate UiTemplate
            var requestUiTemplateIsNull = true;
            request.UiTemplate = new Amazon.SageMaker.Model.UiTemplate();
            System.String requestUiTemplate_uiTemplate_Content = null;
            if (cmdletContext.UiTemplate_Content != null)
            {
                requestUiTemplate_uiTemplate_Content = cmdletContext.UiTemplate_Content;
            }
            if (requestUiTemplate_uiTemplate_Content != null)
            {
                request.UiTemplate.Content = requestUiTemplate_uiTemplate_Content;
                requestUiTemplateIsNull = false;
            }
             // determine if request.UiTemplate should be set to null
            if (requestUiTemplateIsNull)
            {
                request.UiTemplate = null;
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
        
        private Amazon.SageMaker.Model.RenderUiTemplateResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.RenderUiTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "RenderUiTemplate");
            try
            {
                #if DESKTOP
                return client.RenderUiTemplate(request);
                #elif CORECLR
                return client.RenderUiTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String HumanTaskUiArn { get; set; }
            public System.String RoleArn { get; set; }
            public System.String Task_Input { get; set; }
            public System.String UiTemplate_Content { get; set; }
            public System.Func<Amazon.SageMaker.Model.RenderUiTemplateResponse, InvokeSMUiTemplateRenderingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
