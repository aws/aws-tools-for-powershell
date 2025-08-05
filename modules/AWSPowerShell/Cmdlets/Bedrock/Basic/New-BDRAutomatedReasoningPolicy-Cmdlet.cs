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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Creates an Automated Reasoning policy for Amazon Bedrock Guardrails. Automated Reasoning
    /// policies use mathematical techniques to detect hallucinations, suggest corrections,
    /// and highlight unstated assumptions in the responses of your GenAI application.
    /// 
    ///  
    /// <para>
    /// To create a policy, you upload a source document that describes the rules that you're
    /// encoding. Automated Reasoning extracts important concepts from the source document
    /// that will become variables in the policy and infers policy rules.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BDRAutomatedReasoningPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock CreateAutomatedReasoningPolicy API operation.", Operation = new[] {"CreateAutomatedReasoningPolicy"}, SelectReturnType = typeof(Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyResponse object containing multiple properties."
    )]
    public partial class NewBDRAutomatedReasoningPolicyCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than once. If this token matches a previous request, Amazon Bedrock ignores the request
        /// but doesn't return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the Automated Reasoning policy. Use this to provide context about
        /// the policy's purpose and the types of validations it performs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A unique name for the Automated Reasoning policy. The name must be between 1 and 63
        /// characters and can contain letters, numbers, hyphens, and underscores.</para>
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
        
        #region Parameter PolicyDefinition_Rule
        /// <summary>
        /// <para>
        /// <para>The formal logic rules extracted from the source document. Rules define the logical
        /// constraints that determine whether model responses are valid, invalid, or satisfiable.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDefinition_Rules")]
        public Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionRule[] PolicyDefinition_Rule { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to associate with the Automated Reasoning policy. Tags help you organize
        /// and manage your policies.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Bedrock.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter PolicyDefinition_Type
        /// <summary>
        /// <para>
        /// <para>The custom user-defined vairable types used in the policy. Types are enum-based variable
        /// types that provide additional context beyond the predefined variable types.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// for accurate translation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BDRAutomatedReasoningPolicy (CreateAutomatedReasoningPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyResponse, NewBDRAutomatedReasoningPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Bedrock.Model.Tag>(this.Tag);
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
            var request = new Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate PolicyDefinition
            var requestPolicyDefinitionIsNull = true;
            request.PolicyDefinition = new Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinition();
            List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionRule> requestPolicyDefinition_policyDefinition_Rule = null;
            if (cmdletContext.PolicyDefinition_Rule != null)
            {
                requestPolicyDefinition_policyDefinition_Rule = cmdletContext.PolicyDefinition_Rule;
            }
            if (requestPolicyDefinition_policyDefinition_Rule != null)
            {
                request.PolicyDefinition.Rules = requestPolicyDefinition_policyDefinition_Rule;
                requestPolicyDefinitionIsNull = false;
            }
            List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionType> requestPolicyDefinition_policyDefinition_Type = null;
            if (cmdletContext.PolicyDefinition_Type != null)
            {
                requestPolicyDefinition_policyDefinition_Type = cmdletContext.PolicyDefinition_Type;
            }
            if (requestPolicyDefinition_policyDefinition_Type != null)
            {
                request.PolicyDefinition.Types = requestPolicyDefinition_policyDefinition_Type;
                requestPolicyDefinitionIsNull = false;
            }
            List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionVariable> requestPolicyDefinition_policyDefinition_Variable = null;
            if (cmdletContext.PolicyDefinition_Variable != null)
            {
                requestPolicyDefinition_policyDefinition_Variable = cmdletContext.PolicyDefinition_Variable;
            }
            if (requestPolicyDefinition_policyDefinition_Variable != null)
            {
                request.PolicyDefinition.Variables = requestPolicyDefinition_policyDefinition_Variable;
                requestPolicyDefinitionIsNull = false;
            }
            System.String requestPolicyDefinition_policyDefinition_Version = null;
            if (cmdletContext.PolicyDefinition_Version != null)
            {
                requestPolicyDefinition_policyDefinition_Version = cmdletContext.PolicyDefinition_Version;
            }
            if (requestPolicyDefinition_policyDefinition_Version != null)
            {
                request.PolicyDefinition.Version = requestPolicyDefinition_policyDefinition_Version;
                requestPolicyDefinitionIsNull = false;
            }
             // determine if request.PolicyDefinition should be set to null
            if (requestPolicyDefinitionIsNull)
            {
                request.PolicyDefinition = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "CreateAutomatedReasoningPolicy");
            try
            {
                return client.CreateAutomatedReasoningPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionRule> PolicyDefinition_Rule { get; set; }
            public List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionType> PolicyDefinition_Type { get; set; }
            public List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionVariable> PolicyDefinition_Variable { get; set; }
            public System.String PolicyDefinition_Version { get; set; }
            public List<Amazon.Bedrock.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyResponse, NewBDRAutomatedReasoningPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
