/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the Amazon SageMaker Service RenderUiTemplate API operation.", Operation = new[] {"RenderUiTemplate"})]
    [AWSCmdletOutput("Amazon.SageMaker.Model.RenderUiTemplateResponse",
        "This cmdlet returns a Amazon.SageMaker.Model.RenderUiTemplateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeSMUiTemplateRenderingCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter UiTemplate_Content
        /// <summary>
        /// <para>
        /// <para>The content of the Liquid template for the worker user interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String UiTemplate_Content { get; set; }
        #endregion
        
        #region Parameter Task_Input
        /// <summary>
        /// <para>
        /// <para>A JSON object that contains values for the variables defined in the template. It is
        /// made available to the template under the substitution variable <code>task.input</code>.
        /// For example, if you define a variable <code>task.input.text</code> in your template,
        /// you can supply the variable in the JSON object as <code>"text": "sample text"</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Task_Input { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that has access to the S3 objects that are used by
        /// the template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RoleArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SMUiTemplateRendering (RenderUiTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.RoleArn = this.RoleArn;
            context.Task_Input = this.Task_Input;
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
            
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate Task
            bool requestTaskIsNull = true;
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
            bool requestUiTemplateIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RenderUiTemplateAsync(request);
                return task.Result;
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
            public System.String RoleArn { get; set; }
            public System.String Task_Input { get; set; }
            public System.String UiTemplate_Content { get; set; }
        }
        
    }
}
