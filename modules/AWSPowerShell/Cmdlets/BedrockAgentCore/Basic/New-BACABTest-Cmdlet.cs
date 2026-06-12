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
    /// Creates an A/B test for comparing agent configurations. A/B tests split traffic between
    /// a control variant and a treatment variant through a gateway, then evaluate performance
    /// using online evaluation configurations to determine which variant performs better.
    /// </summary>
    [Cmdlet("New", "BACABTest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.CreateABTestResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer CreateABTest API operation.", Operation = new[] {"CreateABTest"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.CreateABTestResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.CreateABTestResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.CreateABTestResponse object containing multiple properties."
    )]
    public partial class NewBACABTestCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the A/B test.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnableOnCreate
        /// <summary>
        /// <para>
        /// <para>Whether to enable the A/B test immediately upon creation. If true, traffic splitting
        /// begins automatically.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableOnCreate { get; set; }
        #endregion
        
        #region Parameter GatewayArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the gateway to use for traffic splitting.</para>
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
        public System.String GatewayArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the A/B test. Must be unique within your account.</para>
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
        /// <para>The IAM role ARN that grants permissions for the A/B test to access gateway and evaluation
        /// resources.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of tag keys and values to associate with the A/B test.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
        /// <para>The list of variants for the A/B test. Must contain exactly two variants: a control
        /// (C) and a treatment (T1), each with a configuration bundle or target reference and
        /// a traffic weight.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.CreateABTestResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.CreateABTestResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.Name),
                nameof(this.GatewayArn),
                nameof(this.RoleArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACABTest (CreateABTest)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.CreateABTestResponse, NewBACABTestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.EnableOnCreate = this.EnableOnCreate;
            context.EvaluationConfig_OnlineEvaluationConfigArn = this.EvaluationConfig_OnlineEvaluationConfigArn;
            if (this.EvaluationConfig_PerVariantOnlineEvaluationConfig != null)
            {
                context.EvaluationConfig_PerVariantOnlineEvaluationConfig = new List<Amazon.BedrockAgentCore.Model.PerVariantOnlineEvaluationConfig>(this.EvaluationConfig_PerVariantOnlineEvaluationConfig);
            }
            context.GatewayArn = this.GatewayArn;
            #if MODULAR
            if (this.GatewayArn == null && ParameterWasBound(nameof(this.GatewayArn)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.GatewayFilter_TargetPath != null)
            {
                context.GatewayFilter_TargetPath = new List<System.String>(this.GatewayFilter_TargetPath);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.Variant != null)
            {
                context.Variant = new List<Amazon.BedrockAgentCore.Model.Variant>(this.Variant);
            }
            #if MODULAR
            if (this.Variant == null && ParameterWasBound(nameof(this.Variant)))
            {
                WriteWarning("You are passing $null as a value for parameter Variant which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCore.Model.CreateABTestRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnableOnCreate != null)
            {
                request.EnableOnCreate = cmdletContext.EnableOnCreate.Value;
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
            if (cmdletContext.GatewayArn != null)
            {
                request.GatewayArn = cmdletContext.GatewayArn;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.BedrockAgentCore.Model.CreateABTestResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.CreateABTestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "CreateABTest");
            try
            {
                return client.CreateABTestAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? EnableOnCreate { get; set; }
            public System.String EvaluationConfig_OnlineEvaluationConfigArn { get; set; }
            public List<Amazon.BedrockAgentCore.Model.PerVariantOnlineEvaluationConfig> EvaluationConfig_PerVariantOnlineEvaluationConfig { get; set; }
            public System.String GatewayArn { get; set; }
            public List<System.String> GatewayFilter_TargetPath { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<Amazon.BedrockAgentCore.Model.Variant> Variant { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.CreateABTestResponse, NewBACABTestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
