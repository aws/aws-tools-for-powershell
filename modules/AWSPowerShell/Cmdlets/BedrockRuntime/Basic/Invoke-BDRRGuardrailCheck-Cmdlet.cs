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
using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDRR
{
    /// <summary>
    /// Evaluates messages against inline guardrail checks. You specify the check configurations
    /// directly in the request, and Amazon Bedrock returns per-check results with severity
    /// or confidence scores.
    /// </summary>
    [Cmdlet("Invoke", "BDRRGuardrailCheck", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockRuntime.Model.InvokeGuardrailChecksResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Runtime InvokeGuardrailChecks API operation.", Operation = new[] {"InvokeGuardrailChecks"}, SelectReturnType = typeof(Amazon.BedrockRuntime.Model.InvokeGuardrailChecksResponse))]
    [AWSCmdletOutput("Amazon.BedrockRuntime.Model.InvokeGuardrailChecksResponse",
        "This cmdlet returns an Amazon.BedrockRuntime.Model.InvokeGuardrailChecksResponse object containing multiple properties."
    )]
    public partial class InvokeBDRRGuardrailCheckCmdlet : AmazonBedrockRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Checks_ContentFilter_Category
        /// <summary>
        /// <para>
        /// <para>The content filter categories to evaluate.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Checks_ContentFilter_Categories")]
        public Amazon.BedrockRuntime.Model.GuardrailChecksContentFilterCategoryConfig[] Checks_ContentFilter_Category { get; set; }
        #endregion
        
        #region Parameter Checks_PromptAttack_Category
        /// <summary>
        /// <para>
        /// <para>The prompt attack categories to evaluate.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Checks_PromptAttack_Categories")]
        public Amazon.BedrockRuntime.Model.GuardrailChecksPromptAttackCategoryConfig[] Checks_PromptAttack_Category { get; set; }
        #endregion
        
        #region Parameter Checks_SensitiveInformation_Entity
        /// <summary>
        /// <para>
        /// <para>The sensitive information entity types to detect.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Checks_SensitiveInformation_Entities")]
        public Amazon.BedrockRuntime.Model.GuardrailChecksSensitiveInformationEntityConfig[] Checks_SensitiveInformation_Entity { get; set; }
        #endregion
        
        #region Parameter Message
        /// <summary>
        /// <para>
        /// <para>The messages to evaluate against the specified guardrail checks. Each message includes
        /// a role and one or more content blocks.</para><para />
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
        [Alias("Messages")]
        public Amazon.BedrockRuntime.Model.GuardrailChecksMessage[] Message { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockRuntime.Model.InvokeGuardrailChecksResponse).
        /// Specifying the name of a property of type Amazon.BedrockRuntime.Model.InvokeGuardrailChecksResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BDRRGuardrailCheck (InvokeGuardrailChecks)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockRuntime.Model.InvokeGuardrailChecksResponse, InvokeBDRRGuardrailCheckCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Checks_ContentFilter_Category != null)
            {
                context.Checks_ContentFilter_Category = new List<Amazon.BedrockRuntime.Model.GuardrailChecksContentFilterCategoryConfig>(this.Checks_ContentFilter_Category);
            }
            if (this.Checks_PromptAttack_Category != null)
            {
                context.Checks_PromptAttack_Category = new List<Amazon.BedrockRuntime.Model.GuardrailChecksPromptAttackCategoryConfig>(this.Checks_PromptAttack_Category);
            }
            if (this.Checks_SensitiveInformation_Entity != null)
            {
                context.Checks_SensitiveInformation_Entity = new List<Amazon.BedrockRuntime.Model.GuardrailChecksSensitiveInformationEntityConfig>(this.Checks_SensitiveInformation_Entity);
            }
            if (this.Message != null)
            {
                context.Message = new List<Amazon.BedrockRuntime.Model.GuardrailChecksMessage>(this.Message);
            }
            #if MODULAR
            if (this.Message == null && ParameterWasBound(nameof(this.Message)))
            {
                WriteWarning("You are passing $null as a value for parameter Message which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockRuntime.Model.InvokeGuardrailChecksRequest();
            
            
             // populate Checks
            var requestChecksIsNull = true;
            request.Checks = new Amazon.BedrockRuntime.Model.GuardrailChecksConfig();
            Amazon.BedrockRuntime.Model.GuardrailChecksContentFilterConfig requestChecks_checks_ContentFilter = null;
            
             // populate ContentFilter
            var requestChecks_checks_ContentFilterIsNull = true;
            requestChecks_checks_ContentFilter = new Amazon.BedrockRuntime.Model.GuardrailChecksContentFilterConfig();
            List<Amazon.BedrockRuntime.Model.GuardrailChecksContentFilterCategoryConfig> requestChecks_checks_ContentFilter_checks_ContentFilter_Category = null;
            if (cmdletContext.Checks_ContentFilter_Category != null)
            {
                requestChecks_checks_ContentFilter_checks_ContentFilter_Category = cmdletContext.Checks_ContentFilter_Category;
            }
            if (requestChecks_checks_ContentFilter_checks_ContentFilter_Category != null)
            {
                requestChecks_checks_ContentFilter.Categories = requestChecks_checks_ContentFilter_checks_ContentFilter_Category;
                requestChecks_checks_ContentFilterIsNull = false;
            }
             // determine if requestChecks_checks_ContentFilter should be set to null
            if (requestChecks_checks_ContentFilterIsNull)
            {
                requestChecks_checks_ContentFilter = null;
            }
            if (requestChecks_checks_ContentFilter != null)
            {
                request.Checks.ContentFilter = requestChecks_checks_ContentFilter;
                requestChecksIsNull = false;
            }
            Amazon.BedrockRuntime.Model.GuardrailChecksPromptAttackConfig requestChecks_checks_PromptAttack = null;
            
             // populate PromptAttack
            var requestChecks_checks_PromptAttackIsNull = true;
            requestChecks_checks_PromptAttack = new Amazon.BedrockRuntime.Model.GuardrailChecksPromptAttackConfig();
            List<Amazon.BedrockRuntime.Model.GuardrailChecksPromptAttackCategoryConfig> requestChecks_checks_PromptAttack_checks_PromptAttack_Category = null;
            if (cmdletContext.Checks_PromptAttack_Category != null)
            {
                requestChecks_checks_PromptAttack_checks_PromptAttack_Category = cmdletContext.Checks_PromptAttack_Category;
            }
            if (requestChecks_checks_PromptAttack_checks_PromptAttack_Category != null)
            {
                requestChecks_checks_PromptAttack.Categories = requestChecks_checks_PromptAttack_checks_PromptAttack_Category;
                requestChecks_checks_PromptAttackIsNull = false;
            }
             // determine if requestChecks_checks_PromptAttack should be set to null
            if (requestChecks_checks_PromptAttackIsNull)
            {
                requestChecks_checks_PromptAttack = null;
            }
            if (requestChecks_checks_PromptAttack != null)
            {
                request.Checks.PromptAttack = requestChecks_checks_PromptAttack;
                requestChecksIsNull = false;
            }
            Amazon.BedrockRuntime.Model.GuardrailChecksSensitiveInformationConfig requestChecks_checks_SensitiveInformation = null;
            
             // populate SensitiveInformation
            var requestChecks_checks_SensitiveInformationIsNull = true;
            requestChecks_checks_SensitiveInformation = new Amazon.BedrockRuntime.Model.GuardrailChecksSensitiveInformationConfig();
            List<Amazon.BedrockRuntime.Model.GuardrailChecksSensitiveInformationEntityConfig> requestChecks_checks_SensitiveInformation_checks_SensitiveInformation_Entity = null;
            if (cmdletContext.Checks_SensitiveInformation_Entity != null)
            {
                requestChecks_checks_SensitiveInformation_checks_SensitiveInformation_Entity = cmdletContext.Checks_SensitiveInformation_Entity;
            }
            if (requestChecks_checks_SensitiveInformation_checks_SensitiveInformation_Entity != null)
            {
                requestChecks_checks_SensitiveInformation.Entities = requestChecks_checks_SensitiveInformation_checks_SensitiveInformation_Entity;
                requestChecks_checks_SensitiveInformationIsNull = false;
            }
             // determine if requestChecks_checks_SensitiveInformation should be set to null
            if (requestChecks_checks_SensitiveInformationIsNull)
            {
                requestChecks_checks_SensitiveInformation = null;
            }
            if (requestChecks_checks_SensitiveInformation != null)
            {
                request.Checks.SensitiveInformation = requestChecks_checks_SensitiveInformation;
                requestChecksIsNull = false;
            }
             // determine if request.Checks should be set to null
            if (requestChecksIsNull)
            {
                request.Checks = null;
            }
            if (cmdletContext.Message != null)
            {
                request.Messages = cmdletContext.Message;
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
        
        private Amazon.BedrockRuntime.Model.InvokeGuardrailChecksResponse CallAWSServiceOperation(IAmazonBedrockRuntime client, Amazon.BedrockRuntime.Model.InvokeGuardrailChecksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Runtime", "InvokeGuardrailChecks");
            try
            {
                return client.InvokeGuardrailChecksAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.BedrockRuntime.Model.GuardrailChecksContentFilterCategoryConfig> Checks_ContentFilter_Category { get; set; }
            public List<Amazon.BedrockRuntime.Model.GuardrailChecksPromptAttackCategoryConfig> Checks_PromptAttack_Category { get; set; }
            public List<Amazon.BedrockRuntime.Model.GuardrailChecksSensitiveInformationEntityConfig> Checks_SensitiveInformation_Entity { get; set; }
            public List<Amazon.BedrockRuntime.Model.GuardrailChecksMessage> Message { get; set; }
            public System.Func<Amazon.BedrockRuntime.Model.InvokeGuardrailChecksResponse, InvokeBDRRGuardrailCheckCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
