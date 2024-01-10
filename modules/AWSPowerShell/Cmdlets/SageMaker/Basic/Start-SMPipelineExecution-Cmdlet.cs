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
    /// Starts a pipeline execution.
    /// </summary>
    [Cmdlet("Start", "SMPipelineExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service StartPipelineExecution API operation.", Operation = new[] {"StartPipelineExecution"}, SelectReturnType = typeof(Amazon.SageMaker.Model.StartPipelineExecutionResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.StartPipelineExecutionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.StartPipelineExecutionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartSMPipelineExecutionCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the operation. An idempotent operation completes no more than once.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ParallelismConfiguration_MaxParallelExecutionStep
        /// <summary>
        /// <para>
        /// <para>The max number of steps that can be executed in parallel. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ParallelismConfiguration_MaxParallelExecutionSteps")]
        public System.Int32? ParallelismConfiguration_MaxParallelExecutionStep { get; set; }
        #endregion
        
        #region Parameter PipelineExecutionDescription
        /// <summary>
        /// <para>
        /// <para>The description of the pipeline execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PipelineExecutionDescription { get; set; }
        #endregion
        
        #region Parameter PipelineExecutionDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the pipeline execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PipelineExecutionDisplayName { get; set; }
        #endregion
        
        #region Parameter PipelineName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the pipeline.</para>
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
        public System.String PipelineName { get; set; }
        #endregion
        
        #region Parameter PipelineParameter
        /// <summary>
        /// <para>
        /// <para>Contains a list of pipeline parameters. This list can be empty. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PipelineParameters")]
        public Amazon.SageMaker.Model.Parameter[] PipelineParameter { get; set; }
        #endregion
        
        #region Parameter SelectiveExecutionConfig_SelectedStep
        /// <summary>
        /// <para>
        /// <para>A list of pipeline steps to run. All step(s) in all path(s) between two selected steps
        /// should be included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SelectiveExecutionConfig_SelectedSteps")]
        public Amazon.SageMaker.Model.SelectedStep[] SelectiveExecutionConfig_SelectedStep { get; set; }
        #endregion
        
        #region Parameter SelectiveExecutionConfig_SourcePipelineExecutionArn
        /// <summary>
        /// <para>
        /// <para>The ARN from a reference execution of the current pipeline. Used to copy input collaterals
        /// needed for the selected steps to run. The execution status of the pipeline can be
        /// either <c>Failed</c> or <c>Success</c>.</para><para>This field is required if the steps you specify for <c>SelectedSteps</c> depend on
        /// output collaterals from any non-specified pipeline steps. For more information, see
        /// <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/pipelines-selective-ex.html">Selective
        /// Execution for Pipeline Steps</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SelectiveExecutionConfig_SourcePipelineExecutionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PipelineExecutionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.StartPipelineExecutionResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.StartPipelineExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PipelineExecutionArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PipelineName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PipelineName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PipelineName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PipelineName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SMPipelineExecution (StartPipelineExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.StartPipelineExecutionResponse, StartSMPipelineExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PipelineName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.ParallelismConfiguration_MaxParallelExecutionStep = this.ParallelismConfiguration_MaxParallelExecutionStep;
            context.PipelineExecutionDescription = this.PipelineExecutionDescription;
            context.PipelineExecutionDisplayName = this.PipelineExecutionDisplayName;
            context.PipelineName = this.PipelineName;
            #if MODULAR
            if (this.PipelineName == null && ParameterWasBound(nameof(this.PipelineName)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PipelineParameter != null)
            {
                context.PipelineParameter = new List<Amazon.SageMaker.Model.Parameter>(this.PipelineParameter);
            }
            if (this.SelectiveExecutionConfig_SelectedStep != null)
            {
                context.SelectiveExecutionConfig_SelectedStep = new List<Amazon.SageMaker.Model.SelectedStep>(this.SelectiveExecutionConfig_SelectedStep);
            }
            context.SelectiveExecutionConfig_SourcePipelineExecutionArn = this.SelectiveExecutionConfig_SourcePipelineExecutionArn;
            
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
            var request = new Amazon.SageMaker.Model.StartPipelineExecutionRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate ParallelismConfiguration
            var requestParallelismConfigurationIsNull = true;
            request.ParallelismConfiguration = new Amazon.SageMaker.Model.ParallelismConfiguration();
            System.Int32? requestParallelismConfiguration_parallelismConfiguration_MaxParallelExecutionStep = null;
            if (cmdletContext.ParallelismConfiguration_MaxParallelExecutionStep != null)
            {
                requestParallelismConfiguration_parallelismConfiguration_MaxParallelExecutionStep = cmdletContext.ParallelismConfiguration_MaxParallelExecutionStep.Value;
            }
            if (requestParallelismConfiguration_parallelismConfiguration_MaxParallelExecutionStep != null)
            {
                request.ParallelismConfiguration.MaxParallelExecutionSteps = requestParallelismConfiguration_parallelismConfiguration_MaxParallelExecutionStep.Value;
                requestParallelismConfigurationIsNull = false;
            }
             // determine if request.ParallelismConfiguration should be set to null
            if (requestParallelismConfigurationIsNull)
            {
                request.ParallelismConfiguration = null;
            }
            if (cmdletContext.PipelineExecutionDescription != null)
            {
                request.PipelineExecutionDescription = cmdletContext.PipelineExecutionDescription;
            }
            if (cmdletContext.PipelineExecutionDisplayName != null)
            {
                request.PipelineExecutionDisplayName = cmdletContext.PipelineExecutionDisplayName;
            }
            if (cmdletContext.PipelineName != null)
            {
                request.PipelineName = cmdletContext.PipelineName;
            }
            if (cmdletContext.PipelineParameter != null)
            {
                request.PipelineParameters = cmdletContext.PipelineParameter;
            }
            
             // populate SelectiveExecutionConfig
            var requestSelectiveExecutionConfigIsNull = true;
            request.SelectiveExecutionConfig = new Amazon.SageMaker.Model.SelectiveExecutionConfig();
            List<Amazon.SageMaker.Model.SelectedStep> requestSelectiveExecutionConfig_selectiveExecutionConfig_SelectedStep = null;
            if (cmdletContext.SelectiveExecutionConfig_SelectedStep != null)
            {
                requestSelectiveExecutionConfig_selectiveExecutionConfig_SelectedStep = cmdletContext.SelectiveExecutionConfig_SelectedStep;
            }
            if (requestSelectiveExecutionConfig_selectiveExecutionConfig_SelectedStep != null)
            {
                request.SelectiveExecutionConfig.SelectedSteps = requestSelectiveExecutionConfig_selectiveExecutionConfig_SelectedStep;
                requestSelectiveExecutionConfigIsNull = false;
            }
            System.String requestSelectiveExecutionConfig_selectiveExecutionConfig_SourcePipelineExecutionArn = null;
            if (cmdletContext.SelectiveExecutionConfig_SourcePipelineExecutionArn != null)
            {
                requestSelectiveExecutionConfig_selectiveExecutionConfig_SourcePipelineExecutionArn = cmdletContext.SelectiveExecutionConfig_SourcePipelineExecutionArn;
            }
            if (requestSelectiveExecutionConfig_selectiveExecutionConfig_SourcePipelineExecutionArn != null)
            {
                request.SelectiveExecutionConfig.SourcePipelineExecutionArn = requestSelectiveExecutionConfig_selectiveExecutionConfig_SourcePipelineExecutionArn;
                requestSelectiveExecutionConfigIsNull = false;
            }
             // determine if request.SelectiveExecutionConfig should be set to null
            if (requestSelectiveExecutionConfigIsNull)
            {
                request.SelectiveExecutionConfig = null;
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
        
        private Amazon.SageMaker.Model.StartPipelineExecutionResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.StartPipelineExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "StartPipelineExecution");
            try
            {
                #if DESKTOP
                return client.StartPipelineExecution(request);
                #elif CORECLR
                return client.StartPipelineExecutionAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.Int32? ParallelismConfiguration_MaxParallelExecutionStep { get; set; }
            public System.String PipelineExecutionDescription { get; set; }
            public System.String PipelineExecutionDisplayName { get; set; }
            public System.String PipelineName { get; set; }
            public List<Amazon.SageMaker.Model.Parameter> PipelineParameter { get; set; }
            public List<Amazon.SageMaker.Model.SelectedStep> SelectiveExecutionConfig_SelectedStep { get; set; }
            public System.String SelectiveExecutionConfig_SourcePipelineExecutionArn { get; set; }
            public System.Func<Amazon.SageMaker.Model.StartPipelineExecutionResponse, StartSMPipelineExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PipelineExecutionArn;
        }
        
    }
}
