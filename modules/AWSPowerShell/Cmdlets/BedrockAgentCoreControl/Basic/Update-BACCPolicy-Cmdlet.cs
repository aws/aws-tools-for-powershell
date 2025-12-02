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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Updates an existing policy within the AgentCore Policy system. This operation allows
    /// modification of the policy description and definition while maintaining the policy's
    /// identity. The updated policy is validated against the Cedar schema before being applied.
    /// This is an asynchronous operation. Use the <c>GetPolicy</c> operation to poll the
    /// <c>status</c> field to track completion.
    /// </summary>
    [Cmdlet("Update", "BACCPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.UpdatePolicyResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer UpdatePolicy API operation.", Operation = new[] {"UpdatePolicy"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.UpdatePolicyResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.UpdatePolicyResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.UpdatePolicyResponse object containing multiple properties."
    )]
    public partial class UpdateBACCPolicyCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The new human-readable description for the policy. This optional field allows updating
        /// the policy's documentation while keeping the same policy logic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter PolicyEngineId
        /// <summary>
        /// <para>
        /// <para>The identifier of the policy engine that manages the policy to be updated. This ensures
        /// the policy is updated within the correct policy engine context.</para>
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
        public System.String PolicyEngineId { get; set; }
        #endregion
        
        #region Parameter PolicyId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the policy to be updated. This must be a valid policy ID
        /// that exists within the specified policy engine.</para>
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
        public System.String PolicyId { get; set; }
        #endregion
        
        #region Parameter Cedar_Statement
        /// <summary>
        /// <para>
        /// <para>The Cedar policy statement that defines the authorization logic. This statement follows
        /// Cedar syntax and specifies principals, actions, resources, and conditions that determine
        /// when access should be allowed or denied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_Cedar_Statement")]
        public System.String Cedar_Statement { get; set; }
        #endregion
        
        #region Parameter ValidationMode
        /// <summary>
        /// <para>
        /// <para>The validation mode for the policy update. Determines how Cedar analyzer validation
        /// results are handled during policy updates. FAIL_ON_ANY_FINDINGS runs the Cedar analyzer
        /// and fails the update if validation issues are detected, ensuring the policy conforms
        /// to the Cedar schema and tool context. IGNORE_ALL_FINDINGS runs the Cedar analyzer
        /// but allows updates despite validation warnings. Use FAIL_ON_ANY_FINDINGS to ensure
        /// policy correctness during updates, especially when modifying policy logic or conditions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.PolicyValidationMode")]
        public Amazon.BedrockAgentCoreControl.PolicyValidationMode ValidationMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.UpdatePolicyResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.UpdatePolicyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyEngineId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BACCPolicy (UpdatePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.UpdatePolicyResponse, UpdateBACCPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Cedar_Statement = this.Cedar_Statement;
            context.Description = this.Description;
            context.PolicyEngineId = this.PolicyEngineId;
            #if MODULAR
            if (this.PolicyEngineId == null && ParameterWasBound(nameof(this.PolicyEngineId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyEngineId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyId = this.PolicyId;
            #if MODULAR
            if (this.PolicyId == null && ParameterWasBound(nameof(this.PolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ValidationMode = this.ValidationMode;
            
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
            var request = new Amazon.BedrockAgentCoreControl.Model.UpdatePolicyRequest();
            
            
             // populate Definition
            var requestDefinitionIsNull = true;
            request.Definition = new Amazon.BedrockAgentCoreControl.Model.PolicyDefinition();
            Amazon.BedrockAgentCoreControl.Model.CedarPolicy requestDefinition_definition_Cedar = null;
            
             // populate Cedar
            var requestDefinition_definition_CedarIsNull = true;
            requestDefinition_definition_Cedar = new Amazon.BedrockAgentCoreControl.Model.CedarPolicy();
            System.String requestDefinition_definition_Cedar_cedar_Statement = null;
            if (cmdletContext.Cedar_Statement != null)
            {
                requestDefinition_definition_Cedar_cedar_Statement = cmdletContext.Cedar_Statement;
            }
            if (requestDefinition_definition_Cedar_cedar_Statement != null)
            {
                requestDefinition_definition_Cedar.Statement = requestDefinition_definition_Cedar_cedar_Statement;
                requestDefinition_definition_CedarIsNull = false;
            }
             // determine if requestDefinition_definition_Cedar should be set to null
            if (requestDefinition_definition_CedarIsNull)
            {
                requestDefinition_definition_Cedar = null;
            }
            if (requestDefinition_definition_Cedar != null)
            {
                request.Definition.Cedar = requestDefinition_definition_Cedar;
                requestDefinitionIsNull = false;
            }
             // determine if request.Definition should be set to null
            if (requestDefinitionIsNull)
            {
                request.Definition = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.PolicyEngineId != null)
            {
                request.PolicyEngineId = cmdletContext.PolicyEngineId;
            }
            if (cmdletContext.PolicyId != null)
            {
                request.PolicyId = cmdletContext.PolicyId;
            }
            if (cmdletContext.ValidationMode != null)
            {
                request.ValidationMode = cmdletContext.ValidationMode;
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
        
        private Amazon.BedrockAgentCoreControl.Model.UpdatePolicyResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.UpdatePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "UpdatePolicy");
            try
            {
                return client.UpdatePolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Cedar_Statement { get; set; }
            public System.String Description { get; set; }
            public System.String PolicyEngineId { get; set; }
            public System.String PolicyId { get; set; }
            public Amazon.BedrockAgentCoreControl.PolicyValidationMode ValidationMode { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.UpdatePolicyResponse, UpdateBACCPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
