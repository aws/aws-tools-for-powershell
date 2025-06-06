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
using Amazon.BedrockAgentRuntime;
using Amazon.BedrockAgentRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.BAR
{
    /// <summary>
    /// Starts an execution of an Amazon Bedrock flow. Unlike flows that run until completion
    /// or time out after five minutes, flow executions let you run flows asynchronously for
    /// longer durations. Flow executions also yield control so that your application can
    /// perform other tasks.
    /// 
    ///  
    /// <para>
    /// This operation returns an Amazon Resource Name (ARN) that you can use to track and
    /// manage your flow execution.
    /// </para><note><para>
    /// Flow executions is in preview release for Amazon Bedrock and is subject to change.
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "BARFlowExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Runtime StartFlowExecution API operation.", Operation = new[] {"StartFlowExecution"}, SelectReturnType = typeof(Amazon.BedrockAgentRuntime.Model.StartFlowExecutionResponse))]
    [AWSCmdletOutput("System.String or Amazon.BedrockAgentRuntime.Model.StartFlowExecutionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BedrockAgentRuntime.Model.StartFlowExecutionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartBARFlowExecutionCmdlet : AmazonBedrockAgentRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FlowAliasIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the flow alias to use for the flow execution.</para>
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
        public System.String FlowAliasIdentifier { get; set; }
        #endregion
        
        #region Parameter FlowExecutionName
        /// <summary>
        /// <para>
        /// <para>The unique name for the flow execution. If you don't provide one, a system-generated
        /// name is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FlowExecutionName { get; set; }
        #endregion
        
        #region Parameter FlowIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the flow to execute.</para>
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
        public System.String FlowIdentifier { get; set; }
        #endregion
        
        #region Parameter Input
        /// <summary>
        /// <para>
        /// <para>The input data required for the flow execution. This must match the input schema defined
        /// in the flow.</para>
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
        [Alias("Inputs")]
        public Amazon.BedrockAgentRuntime.Model.FlowInput[] Input { get; set; }
        #endregion
        
        #region Parameter PerformanceConfig_Latency
        /// <summary>
        /// <para>
        /// <para>To use a latency-optimized version of the model, set to <c>optimized</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelPerformanceConfiguration_PerformanceConfig_Latency")]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.PerformanceConfigLatency")]
        public Amazon.BedrockAgentRuntime.PerformanceConfigLatency PerformanceConfig_Latency { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExecutionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentRuntime.Model.StartFlowExecutionResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentRuntime.Model.StartFlowExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExecutionArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FlowIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FlowIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FlowIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FlowIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BARFlowExecution (StartFlowExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentRuntime.Model.StartFlowExecutionResponse, StartBARFlowExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FlowIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FlowAliasIdentifier = this.FlowAliasIdentifier;
            #if MODULAR
            if (this.FlowAliasIdentifier == null && ParameterWasBound(nameof(this.FlowAliasIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowAliasIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FlowExecutionName = this.FlowExecutionName;
            context.FlowIdentifier = this.FlowIdentifier;
            #if MODULAR
            if (this.FlowIdentifier == null && ParameterWasBound(nameof(this.FlowIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Input != null)
            {
                context.Input = new List<Amazon.BedrockAgentRuntime.Model.FlowInput>(this.Input);
            }
            #if MODULAR
            if (this.Input == null && ParameterWasBound(nameof(this.Input)))
            {
                WriteWarning("You are passing $null as a value for parameter Input which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PerformanceConfig_Latency = this.PerformanceConfig_Latency;
            
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
            var request = new Amazon.BedrockAgentRuntime.Model.StartFlowExecutionRequest();
            
            if (cmdletContext.FlowAliasIdentifier != null)
            {
                request.FlowAliasIdentifier = cmdletContext.FlowAliasIdentifier;
            }
            if (cmdletContext.FlowExecutionName != null)
            {
                request.FlowExecutionName = cmdletContext.FlowExecutionName;
            }
            if (cmdletContext.FlowIdentifier != null)
            {
                request.FlowIdentifier = cmdletContext.FlowIdentifier;
            }
            if (cmdletContext.Input != null)
            {
                request.Inputs = cmdletContext.Input;
            }
            
             // populate ModelPerformanceConfiguration
            var requestModelPerformanceConfigurationIsNull = true;
            request.ModelPerformanceConfiguration = new Amazon.BedrockAgentRuntime.Model.ModelPerformanceConfiguration();
            Amazon.BedrockAgentRuntime.Model.PerformanceConfiguration requestModelPerformanceConfiguration_modelPerformanceConfiguration_PerformanceConfig = null;
            
             // populate PerformanceConfig
            var requestModelPerformanceConfiguration_modelPerformanceConfiguration_PerformanceConfigIsNull = true;
            requestModelPerformanceConfiguration_modelPerformanceConfiguration_PerformanceConfig = new Amazon.BedrockAgentRuntime.Model.PerformanceConfiguration();
            Amazon.BedrockAgentRuntime.PerformanceConfigLatency requestModelPerformanceConfiguration_modelPerformanceConfiguration_PerformanceConfig_performanceConfig_Latency = null;
            if (cmdletContext.PerformanceConfig_Latency != null)
            {
                requestModelPerformanceConfiguration_modelPerformanceConfiguration_PerformanceConfig_performanceConfig_Latency = cmdletContext.PerformanceConfig_Latency;
            }
            if (requestModelPerformanceConfiguration_modelPerformanceConfiguration_PerformanceConfig_performanceConfig_Latency != null)
            {
                requestModelPerformanceConfiguration_modelPerformanceConfiguration_PerformanceConfig.Latency = requestModelPerformanceConfiguration_modelPerformanceConfiguration_PerformanceConfig_performanceConfig_Latency;
                requestModelPerformanceConfiguration_modelPerformanceConfiguration_PerformanceConfigIsNull = false;
            }
             // determine if requestModelPerformanceConfiguration_modelPerformanceConfiguration_PerformanceConfig should be set to null
            if (requestModelPerformanceConfiguration_modelPerformanceConfiguration_PerformanceConfigIsNull)
            {
                requestModelPerformanceConfiguration_modelPerformanceConfiguration_PerformanceConfig = null;
            }
            if (requestModelPerformanceConfiguration_modelPerformanceConfiguration_PerformanceConfig != null)
            {
                request.ModelPerformanceConfiguration.PerformanceConfig = requestModelPerformanceConfiguration_modelPerformanceConfiguration_PerformanceConfig;
                requestModelPerformanceConfigurationIsNull = false;
            }
             // determine if request.ModelPerformanceConfiguration should be set to null
            if (requestModelPerformanceConfigurationIsNull)
            {
                request.ModelPerformanceConfiguration = null;
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
        
        private Amazon.BedrockAgentRuntime.Model.StartFlowExecutionResponse CallAWSServiceOperation(IAmazonBedrockAgentRuntime client, Amazon.BedrockAgentRuntime.Model.StartFlowExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Runtime", "StartFlowExecution");
            try
            {
                #if DESKTOP
                return client.StartFlowExecution(request);
                #elif CORECLR
                return client.StartFlowExecutionAsync(request).GetAwaiter().GetResult();
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
            public System.String FlowAliasIdentifier { get; set; }
            public System.String FlowExecutionName { get; set; }
            public System.String FlowIdentifier { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.FlowInput> Input { get; set; }
            public Amazon.BedrockAgentRuntime.PerformanceConfigLatency PerformanceConfig_Latency { get; set; }
            public System.Func<Amazon.BedrockAgentRuntime.Model.StartFlowExecutionResponse, StartBARFlowExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExecutionArn;
        }
        
    }
}
