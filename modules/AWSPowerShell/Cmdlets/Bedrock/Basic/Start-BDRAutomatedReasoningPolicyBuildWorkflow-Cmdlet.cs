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
    /// Starts a new build workflow for an Automated Reasoning policy. This initiates the
    /// process of analyzing source documents and generating policy rules, variables, and
    /// types.
    /// </summary>
    [Cmdlet("Start", "BDRAutomatedReasoningPolicyBuildWorkflow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Bedrock.Model.StartAutomatedReasoningPolicyBuildWorkflowResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock StartAutomatedReasoningPolicyBuildWorkflow API operation.", Operation = new[] {"StartAutomatedReasoningPolicyBuildWorkflow"}, SelectReturnType = typeof(Amazon.Bedrock.Model.StartAutomatedReasoningPolicyBuildWorkflowResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.StartAutomatedReasoningPolicyBuildWorkflowResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.StartAutomatedReasoningPolicyBuildWorkflowResponse object containing multiple properties."
    )]
    public partial class StartBDRAutomatedReasoningPolicyBuildWorkflowCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PolicyRepairAssets_Annotation
        /// <summary>
        /// <para>
        /// <para>Specific annotations or modifications to apply during the policy repair process, such
        /// as rule corrections or variable updates.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceContent_WorkflowContent_PolicyRepairAssets_Annotations")]
        public Amazon.Bedrock.Model.AutomatedReasoningPolicyAnnotation[] PolicyRepairAssets_Annotation { get; set; }
        #endregion
        
        #region Parameter BuildWorkflowType
        /// <summary>
        /// <para>
        /// <para>The type of build workflow to start (e.g., DOCUMENT_INGESTION for processing new documents,
        /// POLICY_REPAIR for fixing existing policies).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Bedrock.AutomatedReasoningPolicyBuildWorkflowType")]
        public Amazon.Bedrock.AutomatedReasoningPolicyBuildWorkflowType BuildWorkflowType { get; set; }
        #endregion
        
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
        
        #region Parameter WorkflowContent_Document
        /// <summary>
        /// <para>
        /// <para>The list of documents to be processed in a document ingestion workflow.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceContent_WorkflowContent_Documents")]
        public Amazon.Bedrock.Model.AutomatedReasoningPolicyBuildWorkflowDocument[] WorkflowContent_Document { get; set; }
        #endregion
        
        #region Parameter PolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Automated Reasoning policy for which to start
        /// the build workflow.</para>
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
        /// constraints that determine whether model responses are valid, invalid, or satisfiable.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceContent_PolicyDefinition_Rules")]
        public Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionRule[] PolicyDefinition_Rule { get; set; }
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
        [Alias("SourceContent_PolicyDefinition_Types")]
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
        [Alias("SourceContent_PolicyDefinition_Variables")]
        public Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionVariable[] PolicyDefinition_Variable { get; set; }
        #endregion
        
        #region Parameter PolicyDefinition_Version
        /// <summary>
        /// <para>
        /// <para>The version of the policy definition format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceContent_PolicyDefinition_Version")]
        public System.String PolicyDefinition_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.StartAutomatedReasoningPolicyBuildWorkflowResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.StartAutomatedReasoningPolicyBuildWorkflowResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BDRAutomatedReasoningPolicyBuildWorkflow (StartAutomatedReasoningPolicyBuildWorkflow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.StartAutomatedReasoningPolicyBuildWorkflowResponse, StartBDRAutomatedReasoningPolicyBuildWorkflowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BuildWorkflowType = this.BuildWorkflowType;
            #if MODULAR
            if (this.BuildWorkflowType == null && ParameterWasBound(nameof(this.BuildWorkflowType)))
            {
                WriteWarning("You are passing $null as a value for parameter BuildWorkflowType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
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
            if (this.WorkflowContent_Document != null)
            {
                context.WorkflowContent_Document = new List<Amazon.Bedrock.Model.AutomatedReasoningPolicyBuildWorkflowDocument>(this.WorkflowContent_Document);
            }
            if (this.PolicyRepairAssets_Annotation != null)
            {
                context.PolicyRepairAssets_Annotation = new List<Amazon.Bedrock.Model.AutomatedReasoningPolicyAnnotation>(this.PolicyRepairAssets_Annotation);
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
            var request = new Amazon.Bedrock.Model.StartAutomatedReasoningPolicyBuildWorkflowRequest();
            
            if (cmdletContext.BuildWorkflowType != null)
            {
                request.BuildWorkflowType = cmdletContext.BuildWorkflowType;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.PolicyArn != null)
            {
                request.PolicyArn = cmdletContext.PolicyArn;
            }
            
             // populate SourceContent
            request.SourceContent = new Amazon.Bedrock.Model.AutomatedReasoningPolicyBuildWorkflowSource();
            Amazon.Bedrock.Model.AutomatedReasoningPolicyWorkflowTypeContent requestSourceContent_sourceContent_WorkflowContent = null;
            
             // populate WorkflowContent
            var requestSourceContent_sourceContent_WorkflowContentIsNull = true;
            requestSourceContent_sourceContent_WorkflowContent = new Amazon.Bedrock.Model.AutomatedReasoningPolicyWorkflowTypeContent();
            List<Amazon.Bedrock.Model.AutomatedReasoningPolicyBuildWorkflowDocument> requestSourceContent_sourceContent_WorkflowContent_workflowContent_Document = null;
            if (cmdletContext.WorkflowContent_Document != null)
            {
                requestSourceContent_sourceContent_WorkflowContent_workflowContent_Document = cmdletContext.WorkflowContent_Document;
            }
            if (requestSourceContent_sourceContent_WorkflowContent_workflowContent_Document != null)
            {
                requestSourceContent_sourceContent_WorkflowContent.Documents = requestSourceContent_sourceContent_WorkflowContent_workflowContent_Document;
                requestSourceContent_sourceContent_WorkflowContentIsNull = false;
            }
            Amazon.Bedrock.Model.AutomatedReasoningPolicyBuildWorkflowRepairContent requestSourceContent_sourceContent_WorkflowContent_sourceContent_WorkflowContent_PolicyRepairAssets = null;
            
             // populate PolicyRepairAssets
            var requestSourceContent_sourceContent_WorkflowContent_sourceContent_WorkflowContent_PolicyRepairAssetsIsNull = true;
            requestSourceContent_sourceContent_WorkflowContent_sourceContent_WorkflowContent_PolicyRepairAssets = new Amazon.Bedrock.Model.AutomatedReasoningPolicyBuildWorkflowRepairContent();
            List<Amazon.Bedrock.Model.AutomatedReasoningPolicyAnnotation> requestSourceContent_sourceContent_WorkflowContent_sourceContent_WorkflowContent_PolicyRepairAssets_policyRepairAssets_Annotation = null;
            if (cmdletContext.PolicyRepairAssets_Annotation != null)
            {
                requestSourceContent_sourceContent_WorkflowContent_sourceContent_WorkflowContent_PolicyRepairAssets_policyRepairAssets_Annotation = cmdletContext.PolicyRepairAssets_Annotation;
            }
            if (requestSourceContent_sourceContent_WorkflowContent_sourceContent_WorkflowContent_PolicyRepairAssets_policyRepairAssets_Annotation != null)
            {
                requestSourceContent_sourceContent_WorkflowContent_sourceContent_WorkflowContent_PolicyRepairAssets.Annotations = requestSourceContent_sourceContent_WorkflowContent_sourceContent_WorkflowContent_PolicyRepairAssets_policyRepairAssets_Annotation;
                requestSourceContent_sourceContent_WorkflowContent_sourceContent_WorkflowContent_PolicyRepairAssetsIsNull = false;
            }
             // determine if requestSourceContent_sourceContent_WorkflowContent_sourceContent_WorkflowContent_PolicyRepairAssets should be set to null
            if (requestSourceContent_sourceContent_WorkflowContent_sourceContent_WorkflowContent_PolicyRepairAssetsIsNull)
            {
                requestSourceContent_sourceContent_WorkflowContent_sourceContent_WorkflowContent_PolicyRepairAssets = null;
            }
            if (requestSourceContent_sourceContent_WorkflowContent_sourceContent_WorkflowContent_PolicyRepairAssets != null)
            {
                requestSourceContent_sourceContent_WorkflowContent.PolicyRepairAssets = requestSourceContent_sourceContent_WorkflowContent_sourceContent_WorkflowContent_PolicyRepairAssets;
                requestSourceContent_sourceContent_WorkflowContentIsNull = false;
            }
             // determine if requestSourceContent_sourceContent_WorkflowContent should be set to null
            if (requestSourceContent_sourceContent_WorkflowContentIsNull)
            {
                requestSourceContent_sourceContent_WorkflowContent = null;
            }
            if (requestSourceContent_sourceContent_WorkflowContent != null)
            {
                request.SourceContent.WorkflowContent = requestSourceContent_sourceContent_WorkflowContent;
            }
            Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinition requestSourceContent_sourceContent_PolicyDefinition = null;
            
             // populate PolicyDefinition
            var requestSourceContent_sourceContent_PolicyDefinitionIsNull = true;
            requestSourceContent_sourceContent_PolicyDefinition = new Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinition();
            List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionRule> requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Rule = null;
            if (cmdletContext.PolicyDefinition_Rule != null)
            {
                requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Rule = cmdletContext.PolicyDefinition_Rule;
            }
            if (requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Rule != null)
            {
                requestSourceContent_sourceContent_PolicyDefinition.Rules = requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Rule;
                requestSourceContent_sourceContent_PolicyDefinitionIsNull = false;
            }
            List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionType> requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Type = null;
            if (cmdletContext.PolicyDefinition_Type != null)
            {
                requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Type = cmdletContext.PolicyDefinition_Type;
            }
            if (requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Type != null)
            {
                requestSourceContent_sourceContent_PolicyDefinition.Types = requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Type;
                requestSourceContent_sourceContent_PolicyDefinitionIsNull = false;
            }
            List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionVariable> requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Variable = null;
            if (cmdletContext.PolicyDefinition_Variable != null)
            {
                requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Variable = cmdletContext.PolicyDefinition_Variable;
            }
            if (requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Variable != null)
            {
                requestSourceContent_sourceContent_PolicyDefinition.Variables = requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Variable;
                requestSourceContent_sourceContent_PolicyDefinitionIsNull = false;
            }
            System.String requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Version = null;
            if (cmdletContext.PolicyDefinition_Version != null)
            {
                requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Version = cmdletContext.PolicyDefinition_Version;
            }
            if (requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Version != null)
            {
                requestSourceContent_sourceContent_PolicyDefinition.Version = requestSourceContent_sourceContent_PolicyDefinition_policyDefinition_Version;
                requestSourceContent_sourceContent_PolicyDefinitionIsNull = false;
            }
             // determine if requestSourceContent_sourceContent_PolicyDefinition should be set to null
            if (requestSourceContent_sourceContent_PolicyDefinitionIsNull)
            {
                requestSourceContent_sourceContent_PolicyDefinition = null;
            }
            if (requestSourceContent_sourceContent_PolicyDefinition != null)
            {
                request.SourceContent.PolicyDefinition = requestSourceContent_sourceContent_PolicyDefinition;
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
        
        private Amazon.Bedrock.Model.StartAutomatedReasoningPolicyBuildWorkflowResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.StartAutomatedReasoningPolicyBuildWorkflowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "StartAutomatedReasoningPolicyBuildWorkflow");
            try
            {
                return client.StartAutomatedReasoningPolicyBuildWorkflowAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Bedrock.AutomatedReasoningPolicyBuildWorkflowType BuildWorkflowType { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String PolicyArn { get; set; }
            public List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionRule> PolicyDefinition_Rule { get; set; }
            public List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionType> PolicyDefinition_Type { get; set; }
            public List<Amazon.Bedrock.Model.AutomatedReasoningPolicyDefinitionVariable> PolicyDefinition_Variable { get; set; }
            public System.String PolicyDefinition_Version { get; set; }
            public List<Amazon.Bedrock.Model.AutomatedReasoningPolicyBuildWorkflowDocument> WorkflowContent_Document { get; set; }
            public List<Amazon.Bedrock.Model.AutomatedReasoningPolicyAnnotation> PolicyRepairAssets_Annotation { get; set; }
            public System.Func<Amazon.Bedrock.Model.StartAutomatedReasoningPolicyBuildWorkflowResponse, StartBDRAutomatedReasoningPolicyBuildWorkflowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
