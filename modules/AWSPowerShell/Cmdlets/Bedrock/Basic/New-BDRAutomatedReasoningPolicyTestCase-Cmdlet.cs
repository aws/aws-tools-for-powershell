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
    /// Creates a test for an Automated Reasoning policy. Tests validate that your policy
    /// works as expected by providing sample inputs and expected outcomes. Use tests to verify
    /// policy behavior before deploying to production.
    /// </summary>
    [Cmdlet("New", "BDRAutomatedReasoningPolicyTestCase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyTestCaseResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock CreateAutomatedReasoningPolicyTestCase API operation.", Operation = new[] {"CreateAutomatedReasoningPolicyTestCase"}, SelectReturnType = typeof(Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyTestCaseResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyTestCaseResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyTestCaseResponse object containing multiple properties."
    )]
    public partial class NewBDRAutomatedReasoningPolicyTestCaseCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, Amazon Bedrock ignores the
        /// request, but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ConfidenceThreshold
        /// <summary>
        /// <para>
        /// <para>The minimum confidence level for logic validation. Content that meets the threshold
        /// is considered a high-confidence finding that can be validated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? ConfidenceThreshold { get; set; }
        #endregion
        
        #region Parameter ExpectedAggregatedFindingsResult
        /// <summary>
        /// <para>
        /// <para>The expected result of the Automated Reasoning check. Valid values include: , TOO_COMPLEX,
        /// and NO_TRANSLATIONS.</para><ul><li><para><c>VALID</c> - The claims are true. The claims are implied by the premises and the
        /// Automated Reasoning policy. Given the Automated Reasoning policy and premises, it
        /// is not possible for these claims to be false. In other words, there are no alternative
        /// answers that are true that contradict the claims.</para></li><li><para><c>INVALID</c> - The claims are false. The claims are not implied by the premises
        /// and Automated Reasoning policy. Furthermore, there exists different claims that are
        /// consistent with the premises and Automated Reasoning policy.</para></li><li><para><c>SATISFIABLE</c> - The claims can be true or false. It depends on what assumptions
        /// are made for the claim to be implied from the premises and Automated Reasoning policy
        /// rules. In this situation, different assumptions can make input claims false and alternative
        /// claims true.</para></li><li><para><c>IMPOSSIBLE</c> - Automated Reasoning can’t make a statement about the claims.
        /// This can happen if the premises are logically incorrect, or if there is a conflict
        /// within the Automated Reasoning policy itself.</para></li><li><para><c>TRANSLATION_AMBIGUOUS</c> - Detected an ambiguity in the translation meant it
        /// would be unsound to continue with validity checking. Additional context or follow-up
        /// questions might be needed to get translation to succeed.</para></li><li><para><c>TOO_COMPLEX</c> - The input contains too much information for Automated Reasoning
        /// to process within its latency limits.</para></li><li><para><c>NO_TRANSLATIONS</c> - Identifies that some or all of the input prompt wasn't translated
        /// into logic. This can happen if the input isn't relevant to the Automated Reasoning
        /// policy, or if the policy doesn't have variables to model relevant input. If Automated
        /// Reasoning can't translate anything, you get a single <c>NO_TRANSLATIONS</c> finding.
        /// You might also see a <c>NO_TRANSLATIONS</c> (along with other findings) if some part
        /// of the validation isn't translated.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Bedrock.AutomatedReasoningCheckResult")]
        public Amazon.Bedrock.AutomatedReasoningCheckResult ExpectedAggregatedFindingsResult { get; set; }
        #endregion
        
        #region Parameter GuardContent
        /// <summary>
        /// <para>
        /// <para>The output content that's validated by the Automated Reasoning policy. This represents
        /// the foundation model response that will be checked for accuracy.</para>
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
        public System.String GuardContent { get; set; }
        #endregion
        
        #region Parameter PolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Automated Reasoning policy for which to create
        /// the test.</para>
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
        
        #region Parameter QueryContent
        /// <summary>
        /// <para>
        /// <para>The input query or prompt that generated the content. This provides context for the
        /// validation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryContent { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyTestCaseResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyTestCaseResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BDRAutomatedReasoningPolicyTestCase (CreateAutomatedReasoningPolicyTestCase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyTestCaseResponse, NewBDRAutomatedReasoningPolicyTestCaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.ConfidenceThreshold = this.ConfidenceThreshold;
            context.ExpectedAggregatedFindingsResult = this.ExpectedAggregatedFindingsResult;
            #if MODULAR
            if (this.ExpectedAggregatedFindingsResult == null && ParameterWasBound(nameof(this.ExpectedAggregatedFindingsResult)))
            {
                WriteWarning("You are passing $null as a value for parameter ExpectedAggregatedFindingsResult which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GuardContent = this.GuardContent;
            #if MODULAR
            if (this.GuardContent == null && ParameterWasBound(nameof(this.GuardContent)))
            {
                WriteWarning("You are passing $null as a value for parameter GuardContent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyArn = this.PolicyArn;
            #if MODULAR
            if (this.PolicyArn == null && ParameterWasBound(nameof(this.PolicyArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryContent = this.QueryContent;
            
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
            var request = new Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyTestCaseRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ConfidenceThreshold != null)
            {
                request.ConfidenceThreshold = cmdletContext.ConfidenceThreshold.Value;
            }
            if (cmdletContext.ExpectedAggregatedFindingsResult != null)
            {
                request.ExpectedAggregatedFindingsResult = cmdletContext.ExpectedAggregatedFindingsResult;
            }
            if (cmdletContext.GuardContent != null)
            {
                request.GuardContent = cmdletContext.GuardContent;
            }
            if (cmdletContext.PolicyArn != null)
            {
                request.PolicyArn = cmdletContext.PolicyArn;
            }
            if (cmdletContext.QueryContent != null)
            {
                request.QueryContent = cmdletContext.QueryContent;
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
        
        private Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyTestCaseResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyTestCaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "CreateAutomatedReasoningPolicyTestCase");
            try
            {
                return client.CreateAutomatedReasoningPolicyTestCaseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Double? ConfidenceThreshold { get; set; }
            public Amazon.Bedrock.AutomatedReasoningCheckResult ExpectedAggregatedFindingsResult { get; set; }
            public System.String GuardContent { get; set; }
            public System.String PolicyArn { get; set; }
            public System.String QueryContent { get; set; }
            public System.Func<Amazon.Bedrock.Model.CreateAutomatedReasoningPolicyTestCaseResponse, NewBDRAutomatedReasoningPolicyTestCaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
