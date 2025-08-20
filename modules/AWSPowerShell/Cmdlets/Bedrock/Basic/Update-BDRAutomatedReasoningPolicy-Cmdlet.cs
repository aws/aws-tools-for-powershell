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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Updates an existing Automated Reasoning policy with new rules, variables, or configuration.
    /// This creates a new version of the policy while preserving the previous version.
    /// </summary>
    [Cmdlet("Update", "BDRAutomatedReasoningPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock UpdateAutomatedReasoningPolicy API operation.", Operation = new[] {"UpdateAutomatedReasoningPolicy"}, SelectReturnType = typeof(Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyResponse object containing multiple properties."
    )]
    public partial class UpdateBDRAutomatedReasoningPolicyCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description for the Automated Reasoning policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated name for the Automated Reasoning policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Automated Reasoning policy to update. This must
        /// be the ARN of a draft policy.</para>
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
        public System.String PolicyArn { get; set; }
        #endregion
        
        #region Parameter PolicyDefinition_Rule
        /// <summary>
        /// <para>
        /// <para>The formal logic rules extracted from the source document. Rules define the logical
        /// constraints that determine whether model responses are valid, invalid, or satisfiable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDefinition_Rules")]
        public Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionRule[] PolicyDefinition_Rule { get; set; }
        #endregion
        
        #region Parameter PolicyDefinition_Type
        /// <summary>
        /// <para>
        /// <para>The custom user-defined vairable types used in the policy. Types are enum-based variable
        /// types that provide additional context beyond the predefined variable types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDefinition_Types")]
        public Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionType[] PolicyDefinition_Type { get; set; }
        #endregion
        
        #region Parameter PolicyDefinition_Variable
        /// <summary>
        /// <para>
        /// <para>The variables that represent concepts in the policy. Variables can have values assigned
        /// when translating natural language into formal logic. Their descriptions are crucial
        /// for accurate translation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDefinition_Variables")]
        public Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionVariable[] PolicyDefinition_Variable { get; set; }
        #endregion
        
        #region Parameter PolicyDefinition_Version
        /// <summary>
        /// <para>
        /// <para>The version of the policy definition format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyDefinition_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PolicyArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PolicyArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PolicyArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BDRAutomatedReasoningPolicy (UpdateAutomatedReasoningPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyResponse, UpdateBDRAutomatedReasoningPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PolicyArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.Name = this.Name;
            context.PolicyArn = this.PolicyArn;
            #if MODULAR
            if (this.PolicyArn == null && ParameterWasBound(nameof(this.PolicyArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PolicyDefinition_Rule != null)
            {
                context.PolicyDefinition_Rule = new List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionRule>(this.PolicyDefinition_Rule);
            }
            if (this.PolicyDefinition_Type != null)
            {
                context.PolicyDefinition_Type = new List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionType>(this.PolicyDefinition_Type);
            }
            if (this.PolicyDefinition_Variable != null)
            {
                context.PolicyDefinition_Variable = new List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionVariable>(this.PolicyDefinition_Variable);
            }
            context.PolicyDefinition_Version = this.PolicyDefinition_Version;
            
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
            var request = new Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PolicyArn != null)
            {
                request.PolicyArn = cmdletContext.PolicyArn;
            }
            
             // populate PolicyDefinition
            request.PolicyDefinition = new Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinition();
            List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionRule> requestPolicyDefinition_policyDefinition_Rule = null;
            if (cmdletContext.PolicyDefinition_Rule != null)
            {
                requestPolicyDefinition_policyDefinition_Rule = cmdletContext.PolicyDefinition_Rule;
            }
            if (requestPolicyDefinition_policyDefinition_Rule != null)
            {
                request.PolicyDefinition.Rules = requestPolicyDefinition_policyDefinition_Rule;
            }
            List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionType> requestPolicyDefinition_policyDefinition_Type = null;
            if (cmdletContext.PolicyDefinition_Type != null)
            {
                requestPolicyDefinition_policyDefinition_Type = cmdletContext.PolicyDefinition_Type;
            }
            if (requestPolicyDefinition_policyDefinition_Type != null)
            {
                request.PolicyDefinition.Types = requestPolicyDefinition_policyDefinition_Type;
            }
            List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionVariable> requestPolicyDefinition_policyDefinition_Variable = null;
            if (cmdletContext.PolicyDefinition_Variable != null)
            {
                requestPolicyDefinition_policyDefinition_Variable = cmdletContext.PolicyDefinition_Variable;
            }
            if (requestPolicyDefinition_policyDefinition_Variable != null)
            {
                request.PolicyDefinition.Variables = requestPolicyDefinition_policyDefinition_Variable;
            }
            System.String requestPolicyDefinition_policyDefinition_Version = null;
            if (cmdletContext.PolicyDefinition_Version != null)
            {
                requestPolicyDefinition_policyDefinition_Version = cmdletContext.PolicyDefinition_Version;
            }
            if (requestPolicyDefinition_policyDefinition_Version != null)
            {
                request.PolicyDefinition.Version = requestPolicyDefinition_policyDefinition_Version;
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
        
        private Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "UpdateAutomatedReasoningPolicy");
            try
            {
                #if DESKTOP
                return client.UpdateAutomatedReasoningPolicy(request);
                #elif CORECLR
                return client.UpdateAutomatedReasoningPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String PolicyArn { get; set; }
            public List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionRule> PolicyDefinition_Rule { get; set; }
            public List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionType> PolicyDefinition_Type { get; set; }
            public List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionVariable> PolicyDefinition_Variable { get; set; }
            public System.String PolicyDefinition_Version { get; set; }
            public System.Func<Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyResponse, UpdateBDRAutomatedReasoningPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
