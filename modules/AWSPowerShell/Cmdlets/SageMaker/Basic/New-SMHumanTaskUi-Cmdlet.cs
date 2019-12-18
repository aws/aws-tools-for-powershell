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
    /// Defines the settings you will use for the human review workflow user interface. Reviewers
    /// will see a three-panel interface with an instruction area, the item to review, and
    /// an input area.
    /// </summary>
    [Cmdlet("New", "SMHumanTaskUi", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateHumanTaskUi API operation.", Operation = new[] {"CreateHumanTaskUi"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateHumanTaskUiResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateHumanTaskUiResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateHumanTaskUiResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMHumanTaskUiCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter UiTemplate_Content
        /// <summary>
        /// <para>
        /// <para>The content of the Liquid template for the worker user interface.</para>
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
        public System.String UiTemplate_Content { get; set; }
        #endregion
        
        #region Parameter HumanTaskUiName
        /// <summary>
        /// <para>
        /// <para>The name of the user interface you are creating.</para>
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
        public System.String HumanTaskUiName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs that contain metadata to help you categorize and organize
        /// a human review workflow user interface. Each tag consists of a key and a value, both
        /// of which you define.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HumanTaskUiArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateHumanTaskUiResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateHumanTaskUiResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HumanTaskUiArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the HumanTaskUiName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^HumanTaskUiName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^HumanTaskUiName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HumanTaskUiName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMHumanTaskUi (CreateHumanTaskUi)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateHumanTaskUiResponse, NewSMHumanTaskUiCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.HumanTaskUiName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HumanTaskUiName = this.HumanTaskUiName;
            #if MODULAR
            if (this.HumanTaskUiName == null && ParameterWasBound(nameof(this.HumanTaskUiName)))
            {
                WriteWarning("You are passing $null as a value for parameter HumanTaskUiName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.UiTemplate_Content = this.UiTemplate_Content;
            #if MODULAR
            if (this.UiTemplate_Content == null && ParameterWasBound(nameof(this.UiTemplate_Content)))
            {
                WriteWarning("You are passing $null as a value for parameter UiTemplate_Content which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.CreateHumanTaskUiRequest();
            
            if (cmdletContext.HumanTaskUiName != null)
            {
                request.HumanTaskUiName = cmdletContext.HumanTaskUiName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SageMaker.Model.CreateHumanTaskUiResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateHumanTaskUiRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateHumanTaskUi");
            try
            {
                #if DESKTOP
                return client.CreateHumanTaskUi(request);
                #elif CORECLR
                return client.CreateHumanTaskUiAsync(request).GetAwaiter().GetResult();
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
            public System.String HumanTaskUiName { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.String UiTemplate_Content { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateHumanTaskUiResponse, NewSMHumanTaskUiCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HumanTaskUiArn;
        }
        
    }
}
