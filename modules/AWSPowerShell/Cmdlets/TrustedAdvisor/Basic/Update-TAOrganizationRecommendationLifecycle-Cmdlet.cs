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
using Amazon.TrustedAdvisor;
using Amazon.TrustedAdvisor.Model;

namespace Amazon.PowerShell.Cmdlets.TA
{
    /// <summary>
    /// Update the lifecycle of a Recommendation within an Organization. This API only supports
    /// prioritized recommendations and updates global priority recommendations, eliminating
    /// the need to call the API in each AWS Region.
    /// </summary>
    [Cmdlet("Update", "TAOrganizationRecommendationLifecycle", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Trusted Advisor UpdateOrganizationRecommendationLifecycle API operation.", Operation = new[] {"UpdateOrganizationRecommendationLifecycle"}, SelectReturnType = typeof(Amazon.TrustedAdvisor.Model.UpdateOrganizationRecommendationLifecycleResponse))]
    [AWSCmdletOutput("None or Amazon.TrustedAdvisor.Model.UpdateOrganizationRecommendationLifecycleResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.TrustedAdvisor.Model.UpdateOrganizationRecommendationLifecycleResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateTAOrganizationRecommendationLifecycleCmdlet : AmazonTrustedAdvisorClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LifecycleStage
        /// <summary>
        /// <para>
        /// <para>The new lifecycle stage</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.TrustedAdvisor.UpdateRecommendationLifecycleStage")]
        public Amazon.TrustedAdvisor.UpdateRecommendationLifecycleStage LifecycleStage { get; set; }
        #endregion
        
        #region Parameter OrganizationRecommendationIdentifier
        /// <summary>
        /// <para>
        /// <para>The Recommendation identifier for AWS Trusted Advisor Priority recommendations</para>
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
        public System.String OrganizationRecommendationIdentifier { get; set; }
        #endregion
        
        #region Parameter UpdateReason
        /// <summary>
        /// <para>
        /// <para>Reason for the lifecycle stage change</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdateReason { get; set; }
        #endregion
        
        #region Parameter UpdateReasonCode
        /// <summary>
        /// <para>
        /// <para>Reason code for the lifecycle state change</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TrustedAdvisor.UpdateRecommendationLifecycleStageReasonCode")]
        public Amazon.TrustedAdvisor.UpdateRecommendationLifecycleStageReasonCode UpdateReasonCode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TrustedAdvisor.Model.UpdateOrganizationRecommendationLifecycleResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OrganizationRecommendationIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OrganizationRecommendationIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OrganizationRecommendationIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OrganizationRecommendationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TAOrganizationRecommendationLifecycle (UpdateOrganizationRecommendationLifecycle)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TrustedAdvisor.Model.UpdateOrganizationRecommendationLifecycleResponse, UpdateTAOrganizationRecommendationLifecycleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OrganizationRecommendationIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LifecycleStage = this.LifecycleStage;
            #if MODULAR
            if (this.LifecycleStage == null && ParameterWasBound(nameof(this.LifecycleStage)))
            {
                WriteWarning("You are passing $null as a value for parameter LifecycleStage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OrganizationRecommendationIdentifier = this.OrganizationRecommendationIdentifier;
            #if MODULAR
            if (this.OrganizationRecommendationIdentifier == null && ParameterWasBound(nameof(this.OrganizationRecommendationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationRecommendationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UpdateReason = this.UpdateReason;
            context.UpdateReasonCode = this.UpdateReasonCode;
            
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
            var request = new Amazon.TrustedAdvisor.Model.UpdateOrganizationRecommendationLifecycleRequest();
            
            if (cmdletContext.LifecycleStage != null)
            {
                request.LifecycleStage = cmdletContext.LifecycleStage;
            }
            if (cmdletContext.OrganizationRecommendationIdentifier != null)
            {
                request.OrganizationRecommendationIdentifier = cmdletContext.OrganizationRecommendationIdentifier;
            }
            if (cmdletContext.UpdateReason != null)
            {
                request.UpdateReason = cmdletContext.UpdateReason;
            }
            if (cmdletContext.UpdateReasonCode != null)
            {
                request.UpdateReasonCode = cmdletContext.UpdateReasonCode;
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
        
        private Amazon.TrustedAdvisor.Model.UpdateOrganizationRecommendationLifecycleResponse CallAWSServiceOperation(IAmazonTrustedAdvisor client, Amazon.TrustedAdvisor.Model.UpdateOrganizationRecommendationLifecycleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Trusted Advisor", "UpdateOrganizationRecommendationLifecycle");
            try
            {
                #if DESKTOP
                return client.UpdateOrganizationRecommendationLifecycle(request);
                #elif CORECLR
                return client.UpdateOrganizationRecommendationLifecycleAsync(request).GetAwaiter().GetResult();
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
            public Amazon.TrustedAdvisor.UpdateRecommendationLifecycleStage LifecycleStage { get; set; }
            public System.String OrganizationRecommendationIdentifier { get; set; }
            public System.String UpdateReason { get; set; }
            public Amazon.TrustedAdvisor.UpdateRecommendationLifecycleStageReasonCode UpdateReasonCode { get; set; }
            public System.Func<Amazon.TrustedAdvisor.Model.UpdateOrganizationRecommendationLifecycleResponse, UpdateTAOrganizationRecommendationLifecycleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
