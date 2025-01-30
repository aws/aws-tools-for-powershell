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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Updates a notebook instance lifecycle configuration created with the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateNotebookInstanceLifecycleConfig.html">CreateNotebookInstanceLifecycleConfig</a>
    /// API.
    /// </summary>
    [Cmdlet("Update", "SMNotebookInstanceLifecycleConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateNotebookInstanceLifecycleConfig API operation.", Operation = new[] {"UpdateNotebookInstanceLifecycleConfig"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateNotebookInstanceLifecycleConfigResponse))]
    [AWSCmdletOutput("None or Amazon.SageMaker.Model.UpdateNotebookInstanceLifecycleConfigResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SageMaker.Model.UpdateNotebookInstanceLifecycleConfigResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSMNotebookInstanceLifecycleConfigCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NotebookInstanceLifecycleConfigName
        /// <summary>
        /// <para>
        /// <para>The name of the lifecycle configuration.</para>
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
        public System.String NotebookInstanceLifecycleConfigName { get; set; }
        #endregion
        
        #region Parameter OnCreate
        /// <summary>
        /// <para>
        /// <para>The shell script that runs only once, when you create a notebook instance. The shell
        /// script must be a base64-encoded string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SageMaker.Model.NotebookInstanceLifecycleHook[] OnCreate { get; set; }
        #endregion
        
        #region Parameter OnStart
        /// <summary>
        /// <para>
        /// <para>The shell script that runs every time you start a notebook instance, including when
        /// you create the notebook instance. The shell script must be a base64-encoded string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SageMaker.Model.NotebookInstanceLifecycleHook[] OnStart { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateNotebookInstanceLifecycleConfigResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NotebookInstanceLifecycleConfigName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NotebookInstanceLifecycleConfigName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NotebookInstanceLifecycleConfigName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NotebookInstanceLifecycleConfigName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMNotebookInstanceLifecycleConfig (UpdateNotebookInstanceLifecycleConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateNotebookInstanceLifecycleConfigResponse, UpdateSMNotebookInstanceLifecycleConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NotebookInstanceLifecycleConfigName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.NotebookInstanceLifecycleConfigName = this.NotebookInstanceLifecycleConfigName;
            #if MODULAR
            if (this.NotebookInstanceLifecycleConfigName == null && ParameterWasBound(nameof(this.NotebookInstanceLifecycleConfigName)))
            {
                WriteWarning("You are passing $null as a value for parameter NotebookInstanceLifecycleConfigName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OnCreate != null)
            {
                context.OnCreate = new List<Amazon.SageMaker.Model.NotebookInstanceLifecycleHook>(this.OnCreate);
            }
            if (this.OnStart != null)
            {
                context.OnStart = new List<Amazon.SageMaker.Model.NotebookInstanceLifecycleHook>(this.OnStart);
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
            var request = new Amazon.SageMaker.Model.UpdateNotebookInstanceLifecycleConfigRequest();
            
            if (cmdletContext.NotebookInstanceLifecycleConfigName != null)
            {
                request.NotebookInstanceLifecycleConfigName = cmdletContext.NotebookInstanceLifecycleConfigName;
            }
            if (cmdletContext.OnCreate != null)
            {
                request.OnCreate = cmdletContext.OnCreate;
            }
            if (cmdletContext.OnStart != null)
            {
                request.OnStart = cmdletContext.OnStart;
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
        
        private Amazon.SageMaker.Model.UpdateNotebookInstanceLifecycleConfigResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateNotebookInstanceLifecycleConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateNotebookInstanceLifecycleConfig");
            try
            {
                #if DESKTOP
                return client.UpdateNotebookInstanceLifecycleConfig(request);
                #elif CORECLR
                return client.UpdateNotebookInstanceLifecycleConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String NotebookInstanceLifecycleConfigName { get; set; }
            public List<Amazon.SageMaker.Model.NotebookInstanceLifecycleHook> OnCreate { get; set; }
            public List<Amazon.SageMaker.Model.NotebookInstanceLifecycleHook> OnStart { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateNotebookInstanceLifecycleConfigResponse, UpdateSMNotebookInstanceLifecycleConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
