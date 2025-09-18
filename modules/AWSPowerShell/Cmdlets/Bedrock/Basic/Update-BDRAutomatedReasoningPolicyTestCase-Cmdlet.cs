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
    /// Updates an existing Automated Reasoning policy test. You can modify the content, query,
    /// expected result, and confidence threshold.
    /// </summary>
    [Cmdlet("Update", "BDRAutomatedReasoningPolicyTestCase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyTestCaseResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock UpdateAutomatedReasoningPolicyTestCase API operation.", Operation = new[] {"UpdateAutomatedReasoningPolicyTestCase"}, SelectReturnType = typeof(Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyTestCaseResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyTestCaseResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyTestCaseResponse object containing multiple properties."
    )]
    public partial class UpdateBDRAutomatedReasoningPolicyTestCaseCmdlet : AmazonBedrockClientCmdlet, IExecutor
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
        /// <para>The updated minimum confidence level for logic validation. If null is provided, the
        /// threshold will be removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? ConfidenceThreshold { get; set; }
        #endregion
        
        #region Parameter ExpectedAggregatedFindingsResult
        /// <summary>
        /// <para>
        /// <para>The updated expected result of the Automated Reasoning check.</para>
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
        /// <para>The updated content to be validated by the Automated Reasoning policy.</para>
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
        
        #region Parameter LastUpdatedAt
        /// <summary>
        /// <para>
        /// <para>The timestamp when the test was last updated. This is used as a concurrency token
        /// to prevent conflicting modifications.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? LastUpdatedAt { get; set; }
        #endregion
        
        #region Parameter PolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Automated Reasoning policy that contains the
        /// test.</para>
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
        /// <para>The updated input query or prompt that generated the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryContent { get; set; }
        #endregion
        
        #region Parameter TestCaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the test to update.</para>
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
        public System.String TestCaseId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyTestCaseResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyTestCaseResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TestCaseId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BDRAutomatedReasoningPolicyTestCase (UpdateAutomatedReasoningPolicyTestCase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyTestCaseResponse, UpdateBDRAutomatedReasoningPolicyTestCaseCmdlet>(Select) ??
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
            context.LastUpdatedAt = this.LastUpdatedAt;
            #if MODULAR
            if (this.LastUpdatedAt == null && ParameterWasBound(nameof(this.LastUpdatedAt)))
            {
                WriteWarning("You are passing $null as a value for parameter LastUpdatedAt which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.TestCaseId = this.TestCaseId;
            #if MODULAR
            if (this.TestCaseId == null && ParameterWasBound(nameof(this.TestCaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter TestCaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyTestCaseRequest();
            
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
            if (cmdletContext.LastUpdatedAt != null)
            {
                request.LastUpdatedAt = cmdletContext.LastUpdatedAt.Value;
            }
            if (cmdletContext.PolicyArn != null)
            {
                request.PolicyArn = cmdletContext.PolicyArn;
            }
            if (cmdletContext.QueryContent != null)
            {
                request.QueryContent = cmdletContext.QueryContent;
            }
            if (cmdletContext.TestCaseId != null)
            {
                request.TestCaseId = cmdletContext.TestCaseId;
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
        
        private Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyTestCaseResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyTestCaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "UpdateAutomatedReasoningPolicyTestCase");
            try
            {
                return client.UpdateAutomatedReasoningPolicyTestCaseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? LastUpdatedAt { get; set; }
            public System.String PolicyArn { get; set; }
            public System.String QueryContent { get; set; }
            public System.String TestCaseId { get; set; }
            public System.Func<Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyTestCaseResponse, UpdateBDRAutomatedReasoningPolicyTestCaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
