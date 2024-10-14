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
    /// Stops an inference experiment.
    /// </summary>
    [Cmdlet("Stop", "SMInferenceExperiment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service StopInferenceExperiment API operation.", Operation = new[] {"StopInferenceExperiment"}, SelectReturnType = typeof(Amazon.SageMaker.Model.StopInferenceExperimentResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.StopInferenceExperimentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.StopInferenceExperimentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StopSMInferenceExperimentCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DesiredModelVariant
        /// <summary>
        /// <para>
        /// <para> An array of <c>ModelVariantConfig</c> objects. There is one for each variant that
        /// you want to deploy after the inference experiment stops. Each <c>ModelVariantConfig</c>
        /// describes the infrastructure configuration for deploying the corresponding variant.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DesiredModelVariants")]
        public Amazon.SageMaker.Model.ModelVariantConfig[] DesiredModelVariant { get; set; }
        #endregion
        
        #region Parameter DesiredState
        /// <summary>
        /// <para>
        /// <para> The desired state of the experiment after stopping. The possible states are the following:
        /// </para><ul><li><para><c>Completed</c>: The experiment completed successfully</para></li><li><para><c>Cancelled</c>: The experiment was canceled</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.InferenceExperimentStopDesiredState")]
        public Amazon.SageMaker.InferenceExperimentStopDesiredState DesiredState { get; set; }
        #endregion
        
        #region Parameter ModelVariantAction
        /// <summary>
        /// <para>
        /// <para> Array of key-value pairs, with names of variants mapped to actions. The possible
        /// actions are the following: </para><ul><li><para><c>Promote</c> - Promote the shadow variant to a production variant</para></li><li><para><c>Remove</c> - Delete the variant</para></li><li><para><c>Retain</c> - Keep the variant as it is</para></li></ul>
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
        [Alias("ModelVariantActions")]
        public System.Collections.Hashtable ModelVariantAction { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the inference experiment to stop.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Reason
        /// <summary>
        /// <para>
        /// <para>The reason for stopping the experiment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Reason { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InferenceExperimentArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.StopInferenceExperimentResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.StopInferenceExperimentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InferenceExperimentArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-SMInferenceExperiment (StopInferenceExperiment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.StopInferenceExperimentResponse, StopSMInferenceExperimentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.DesiredModelVariant != null)
            {
                context.DesiredModelVariant = new List<Amazon.SageMaker.Model.ModelVariantConfig>(this.DesiredModelVariant);
            }
            context.DesiredState = this.DesiredState;
            if (this.ModelVariantAction != null)
            {
                context.ModelVariantAction = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ModelVariantAction.Keys)
                {
                    context.ModelVariantAction.Add((String)hashKey, (System.String)(this.ModelVariantAction[hashKey]));
                }
            }
            #if MODULAR
            if (this.ModelVariantAction == null && ParameterWasBound(nameof(this.ModelVariantAction)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelVariantAction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Reason = this.Reason;
            
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
            var request = new Amazon.SageMaker.Model.StopInferenceExperimentRequest();
            
            if (cmdletContext.DesiredModelVariant != null)
            {
                request.DesiredModelVariants = cmdletContext.DesiredModelVariant;
            }
            if (cmdletContext.DesiredState != null)
            {
                request.DesiredState = cmdletContext.DesiredState;
            }
            if (cmdletContext.ModelVariantAction != null)
            {
                request.ModelVariantActions = cmdletContext.ModelVariantAction;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Reason != null)
            {
                request.Reason = cmdletContext.Reason;
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
        
        private Amazon.SageMaker.Model.StopInferenceExperimentResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.StopInferenceExperimentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "StopInferenceExperiment");
            try
            {
                #if DESKTOP
                return client.StopInferenceExperiment(request);
                #elif CORECLR
                return client.StopInferenceExperimentAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SageMaker.Model.ModelVariantConfig> DesiredModelVariant { get; set; }
            public Amazon.SageMaker.InferenceExperimentStopDesiredState DesiredState { get; set; }
            public Dictionary<System.String, System.String> ModelVariantAction { get; set; }
            public System.String Name { get; set; }
            public System.String Reason { get; set; }
            public System.Func<Amazon.SageMaker.Model.StopInferenceExperimentResponse, StopSMInferenceExperimentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InferenceExperimentArn;
        }
        
    }
}
