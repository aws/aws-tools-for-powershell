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
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GD
{
    /// <summary>
    /// This API is currently available as a preview. During the preview, you can initiate
    /// up to 10 investigations per account per day, with a total limit of 100 investigations
    /// per account. This feature is available in the following Amazon Web Services Regions:
    /// US East (N. Virginia), US East (Ohio), US West (Oregon), Canada (Central), Europe
    /// (Frankfurt), Europe (Ireland), Europe (London), Europe (Paris), Europe (Stockholm),
    /// and Asia Pacific (Tokyo).
    /// 
    ///  
    /// <para>
    /// Initiates a GuardDuty investigation that automatically analyzes security findings,
    /// correlates related activity, performs account-level analysis, and produces a structured
    /// investigation summary with recommended next steps.
    /// </para><para>
    /// Only the administrator account can create an investigation. Member accounts don't
    /// have permission to create investigations from their accounts.
    /// </para><para>
    /// To use this operation, the <c>AI_ANALYST</c> feature must be enabled on your detector.
    /// </para><para>
    /// This feature uses Amazon Bedrock models that leverage Cross-Region Inference (CRIS),
    /// which automatically selects the optimal Amazon Web Services Region within your geography
    /// to process the investigation analysis and generate the investigation report. This
    /// maximizes available compute resources, model availability, and delivers the best customer
    /// experience. Your data remains stored only in the Region where the investigation request
    /// originates, however, investigation data and summary results may be processed outside
    /// that Region. All data is transmitted encrypted across Amazon's secure network. For
    /// more information, see <a href="https://docs.aws.amazon.com/guardduty/latest/ug/guardduty-investigation.html">GuardDuty
    /// Investigation</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GDInvestigation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon GuardDuty CreateInvestigation API operation.", Operation = new[] {"CreateInvestigation"}, SelectReturnType = typeof(Amazon.GuardDuty.Model.CreateInvestigationResponse))]
    [AWSCmdletOutput("System.String or Amazon.GuardDuty.Model.CreateInvestigationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GuardDuty.Model.CreateInvestigationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGDInvestigationCmdlet : AmazonGuardDutyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DetectorId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the GuardDuty detector for the account in which the investigation
        /// is created.</para><para>To find the <c>detectorId</c> in the current Region, see the Settings page in the
        /// GuardDuty console, or run the <a href="https://docs.aws.amazon.com/guardduty/latest/APIReference/API_ListDetectors.html">ListDetectors</a>
        /// API.</para>
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
        public System.String DetectorId { get; set; }
        #endregion
        
        #region Parameter TriggerPrompt
        /// <summary>
        /// <para>
        /// <para>A natural-language description of what to investigate. For example:</para><ul><li><para><c>"Investigate finding 1ab2c3d4e5f6a7b8c9d0e1f2a3b4c5d6 in account 123456789012"</c></para></li><li><para><c>"Analyze findings in account with id 123456789012"</c></para></li><li><para><c>"Analyze findings in my organization"</c></para></li></ul>
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
        public System.String TriggerPrompt { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The idempotency token for the create request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InvestigationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GuardDuty.Model.CreateInvestigationResponse).
        /// Specifying the name of a property of type Amazon.GuardDuty.Model.CreateInvestigationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvestigationId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DetectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GDInvestigation (CreateInvestigation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GuardDuty.Model.CreateInvestigationResponse, NewGDInvestigationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DetectorId = this.DetectorId;
            #if MODULAR
            if (this.DetectorId == null && ParameterWasBound(nameof(this.DetectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TriggerPrompt = this.TriggerPrompt;
            #if MODULAR
            if (this.TriggerPrompt == null && ParameterWasBound(nameof(this.TriggerPrompt)))
            {
                WriteWarning("You are passing $null as a value for parameter TriggerPrompt which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GuardDuty.Model.CreateInvestigationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DetectorId != null)
            {
                request.DetectorId = cmdletContext.DetectorId;
            }
            if (cmdletContext.TriggerPrompt != null)
            {
                request.TriggerPrompt = cmdletContext.TriggerPrompt;
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
        
        private Amazon.GuardDuty.Model.CreateInvestigationResponse CallAWSServiceOperation(IAmazonGuardDuty client, Amazon.GuardDuty.Model.CreateInvestigationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GuardDuty", "CreateInvestigation");
            try
            {
                return client.CreateInvestigationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DetectorId { get; set; }
            public System.String TriggerPrompt { get; set; }
            public System.Func<Amazon.GuardDuty.Model.CreateInvestigationResponse, NewGDInvestigationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvestigationId;
        }
        
    }
}
