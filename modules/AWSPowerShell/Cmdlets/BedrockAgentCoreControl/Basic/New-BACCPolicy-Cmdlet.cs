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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Creates a policy within the AgentCore Policy system. Policies provide real-time, deterministic
    /// control over agentic interactions with AgentCore Gateway. Using the Cedar policy language,
    /// you can define fine-grained policies that specify which interactions with Gateway
    /// tools are permitted based on input parameters and OAuth claims, ensuring agents operate
    /// within defined boundaries and business rules. The policy is validated during creation
    /// against the Cedar schema generated from the Gateway's tools' input schemas, which
    /// defines the available tools, their parameters, and expected data types. This is an
    /// asynchronous operation. Use the <a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/devguide/API_GetPolicy.html">GetPolicy</a>
    /// operation to poll the <c>status</c> field to track completion.
    /// </summary>
    [Cmdlet("New", "BACCPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.CreatePolicyResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer CreatePolicy API operation.", Operation = new[] {"CreatePolicy"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.CreatePolicyResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.CreatePolicyResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.CreatePolicyResponse object containing multiple properties."
    )]
    public partial class NewBACCPolicyCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A human-readable description of the policy's purpose and functionality (1-4,096 characters).
        /// This helps policy administrators understand the policy's intent, business rules, and
        /// operational scope. Use this field to document why the policy exists, what business
        /// requirement it addresses, and any special considerations for maintenance. Clear descriptions
        /// are essential for policy governance, auditing, and troubleshooting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The customer-assigned immutable name for the policy. Must be unique within the account.
        /// This name is used for policy identification and cannot be changed after creation.</para>
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
        
        #region Parameter PolicyEngineId
        /// <summary>
        /// <para>
        /// <para>The identifier of the policy engine which contains this policy. Policy engines group
        /// related policies and provide the execution context for policy evaluation.</para>
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
        /// <para>The validation mode for the policy creation. Determines how Cedar analyzer validation
        /// results are handled during policy creation. FAIL_ON_ANY_FINDINGS (default) runs the
        /// Cedar analyzer to validate the policy against the Cedar schema and tool context, failing
        /// creation if the analyzer detects any validation issues to ensure strict conformance.
        /// IGNORE_ALL_FINDINGS runs the Cedar analyzer but allows policy creation even if validation
        /// issues are detected, useful for testing or when the policy schema is evolving. Use
        /// FAIL_ON_ANY_FINDINGS for production policies to ensure correctness, and IGNORE_ALL_FINDINGS
        /// only when you understand and accept the analyzer findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.PolicyValidationMode")]
        public Amazon.BedrockAgentCoreControl.PolicyValidationMode ValidationMode { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure the idempotency of the request. The
        /// AWS SDK automatically generates this token, so you don't need to provide it in most
        /// cases. If you retry a request with the same client token, the service returns the
        /// same response without creating a duplicate policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.CreatePolicyResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.CreatePolicyResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyEngineId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACCPolicy (CreatePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.CreatePolicyResponse, NewBACCPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Cedar_Statement = this.Cedar_Statement;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyEngineId = this.PolicyEngineId;
            #if MODULAR
            if (this.PolicyEngineId == null && ParameterWasBound(nameof(this.PolicyEngineId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyEngineId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCoreControl.Model.CreatePolicyRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PolicyEngineId != null)
            {
                request.PolicyEngineId = cmdletContext.PolicyEngineId;
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
        
        private Amazon.BedrockAgentCoreControl.Model.CreatePolicyResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.CreatePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "CreatePolicy");
            try
            {
                #if DESKTOP
                return client.CreatePolicy(request);
                #elif CORECLR
                return client.CreatePolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Cedar_Statement { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String PolicyEngineId { get; set; }
            public Amazon.BedrockAgentCoreControl.PolicyValidationMode ValidationMode { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.CreatePolicyResponse, NewBACCPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
