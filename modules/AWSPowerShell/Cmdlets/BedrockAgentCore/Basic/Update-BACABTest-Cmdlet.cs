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
using System.Threading;
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Updates an A/B test's configuration, including variants, traffic allocation, evaluation
    /// settings, or execution status.
    /// </summary>
    [Cmdlet("Update", "BACABTest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.UpdateABTestResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer UpdateABTest API operation.", Operation = new[] {"UpdateABTest"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.UpdateABTestResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.UpdateABTestResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.UpdateABTestResponse object containing multiple properties."
    )]
    public partial class UpdateBACABTestCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AbTestId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the A/B test to update.</para>
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
        public System.String AbTestId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description of the A/B test.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExecutionStatus
        /// <summary>
        /// <para>
        /// <para>The updated execution status to enable or disable the A/B test.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.ABTestExecutionStatus")]
        public Amazon.BedrockAgentCore.ABTestExecutionStatus ExecutionStatus { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated name of the A/B test.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter EvaluationConfig_OnlineEvaluationConfigArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a single online evaluation configuration to use
        /// for both variants.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EvaluationConfig_OnlineEvaluationConfigArn { get; set; }
        #endregion
        
        #region Parameter EvaluationConfig_PerVariantOnlineEvaluationConfig
        /// <summary>
        /// <para>
        /// <para>Per-variant online evaluation configurations, allowing different evaluation settings
        /// for each variant.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.BedrockAgentCore.Model.PerVariantOnlineEvaluationConfig[] EvaluationConfig_PerVariantOnlineEvaluationConfig { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The updated IAM role ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter GatewayFilter_TargetPath
        /// <summary>
        /// <para>
        /// <para>A list of target path patterns to include in the A/B test.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GatewayFilter_TargetPaths")]
        public System.String[] GatewayFilter_TargetPath { get; set; }
        #endregion
        
        #region Parameter Variant
        /// <summary>
        /// <para>
        /// <para>The updated list of variants.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Variants")]
        public Amazon.BedrockAgentCore.Model.Variant[] Variant { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If this token matches a previous request, the service ignores the request,
        /// but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.UpdateABTestResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.UpdateABTestResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AbTestId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BACABTest (UpdateABTest)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.UpdateABTestResponse, UpdateBACABTestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AbTestId = this.AbTestId;
            #if MODULAR
            if (this.AbTestId == null && ParameterWasBound(nameof(this.AbTestId)))
            {
                WriteWarning("You are passing $null as a value for parameter AbTestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.EvaluationConfig_OnlineEvaluationConfigArn = this.EvaluationConfig_OnlineEvaluationConfigArn;
            if (this.EvaluationConfig_PerVariantOnlineEvaluationConfig != null)
            {
                context.EvaluationConfig_PerVariantOnlineEvaluationConfig = new List<Amazon.BedrockAgentCore.Model.PerVariantOnlineEvaluationConfig>(this.EvaluationConfig_PerVariantOnlineEvaluationConfig);
            }
            context.ExecutionStatus = this.ExecutionStatus;
            if (this.GatewayFilter_TargetPath != null)
            {
                context.GatewayFilter_TargetPath = new List<System.String>(this.GatewayFilter_TargetPath);
            }
            context.Name = this.Name;
            context.RoleArn = this.RoleArn;
            if (this.Variant != null)
            {
                context.Variant = new List<Amazon.BedrockAgentCore.Model.Variant>(this.Variant);
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
            var request = new Amazon.BedrockAgentCore.Model.UpdateABTestRequest();
            
            if (cmdletContext.AbTestId != null)
            {
                request.AbTestId = cmdletContext.AbTestId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate EvaluationConfig
            var requestEvaluationConfigIsNull = true;
            request.EvaluationConfig = new Amazon.BedrockAgentCore.Model.ABTestEvaluationConfig();
            System.String requestEvaluationConfig_evaluationConfig_OnlineEvaluationConfigArn = null;
            if (cmdletContext.EvaluationConfig_OnlineEvaluationConfigArn != null)
            {
                requestEvaluationConfig_evaluationConfig_OnlineEvaluationConfigArn = cmdletContext.EvaluationConfig_OnlineEvaluationConfigArn;
            }
            if (requestEvaluationConfig_evaluationConfig_OnlineEvaluationConfigArn != null)
            {
                request.EvaluationConfig.OnlineEvaluationConfigArn = requestEvaluationConfig_evaluationConfig_OnlineEvaluationConfigArn;
                requestEvaluationConfigIsNull = false;
            }
            List<Amazon.BedrockAgentCore.Model.PerVariantOnlineEvaluationConfig> requestEvaluationConfig_evaluationConfig_PerVariantOnlineEvaluationConfig = null;
            if (cmdletContext.EvaluationConfig_PerVariantOnlineEvaluationConfig != null)
            {
                requestEvaluationConfig_evaluationConfig_PerVariantOnlineEvaluationConfig = cmdletContext.EvaluationConfig_PerVariantOnlineEvaluationConfig;
            }
            if (requestEvaluationConfig_evaluationConfig_PerVariantOnlineEvaluationConfig != null)
            {
                request.EvaluationConfig.PerVariantOnlineEvaluationConfig = requestEvaluationConfig_evaluationConfig_PerVariantOnlineEvaluationConfig;
                requestEvaluationConfigIsNull = false;
            }
             // determine if request.EvaluationConfig should be set to null
            if (requestEvaluationConfigIsNull)
            {
                request.EvaluationConfig = null;
            }
            if (cmdletContext.ExecutionStatus != null)
            {
                request.ExecutionStatus = cmdletContext.ExecutionStatus;
            }
            
             // populate GatewayFilter
            var requestGatewayFilterIsNull = true;
            request.GatewayFilter = new Amazon.BedrockAgentCore.Model.GatewayFilter();
            List<System.String> requestGatewayFilter_gatewayFilter_TargetPath = null;
            if (cmdletContext.GatewayFilter_TargetPath != null)
            {
                requestGatewayFilter_gatewayFilter_TargetPath = cmdletContext.GatewayFilter_TargetPath;
            }
            if (requestGatewayFilter_gatewayFilter_TargetPath != null)
            {
                request.GatewayFilter.TargetPaths = requestGatewayFilter_gatewayFilter_TargetPath;
                requestGatewayFilterIsNull = false;
            }
             // determine if request.GatewayFilter should be set to null
            if (requestGatewayFilterIsNull)
            {
                request.GatewayFilter = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Variant != null)
            {
                request.Variants = cmdletContext.Variant;
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
        
        private Amazon.BedrockAgentCore.Model.UpdateABTestResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.UpdateABTestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "UpdateABTest");
            try
            {
                return client.UpdateABTestAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AbTestId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String EvaluationConfig_OnlineEvaluationConfigArn { get; set; }
            public List<Amazon.BedrockAgentCore.Model.PerVariantOnlineEvaluationConfig> EvaluationConfig_PerVariantOnlineEvaluationConfig { get; set; }
            public Amazon.BedrockAgentCore.ABTestExecutionStatus ExecutionStatus { get; set; }
            public List<System.String> GatewayFilter_TargetPath { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.BedrockAgentCore.Model.Variant> Variant { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.UpdateABTestResponse, UpdateBACABTestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
