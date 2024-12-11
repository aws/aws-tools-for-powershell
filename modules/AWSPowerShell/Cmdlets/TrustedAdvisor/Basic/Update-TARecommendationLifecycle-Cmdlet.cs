/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Update the lifecyle of a Recommendation. This API only supports prioritized recommendations.
    /// </summary>
    [Cmdlet("Update", "TARecommendationLifecycle", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Trusted Advisor UpdateRecommendationLifecycle API operation.", Operation = new[] {"UpdateRecommendationLifecycle"}, SelectReturnType = typeof(Amazon.TrustedAdvisor.Model.UpdateRecommendationLifecycleResponse))]
    [AWSCmdletOutput("None or Amazon.TrustedAdvisor.Model.UpdateRecommendationLifecycleResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.TrustedAdvisor.Model.UpdateRecommendationLifecycleResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateTARecommendationLifecycleCmdlet : AmazonTrustedAdvisorClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter RecommendationIdentifier
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
        public System.String RecommendationIdentifier { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TrustedAdvisor.Model.UpdateRecommendationLifecycleResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecommendationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TARecommendationLifecycle (UpdateRecommendationLifecycle)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TrustedAdvisor.Model.UpdateRecommendationLifecycleResponse, UpdateTARecommendationLifecycleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LifecycleStage = this.LifecycleStage;
            #if MODULAR
            if (this.LifecycleStage == null && ParameterWasBound(nameof(this.LifecycleStage)))
            {
                WriteWarning("You are passing $null as a value for parameter LifecycleStage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecommendationIdentifier = this.RecommendationIdentifier;
            #if MODULAR
            if (this.RecommendationIdentifier == null && ParameterWasBound(nameof(this.RecommendationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter RecommendationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.TrustedAdvisor.Model.UpdateRecommendationLifecycleRequest();
            
            if (cmdletContext.LifecycleStage != null)
            {
                request.LifecycleStage = cmdletContext.LifecycleStage;
            }
            if (cmdletContext.RecommendationIdentifier != null)
            {
                request.RecommendationIdentifier = cmdletContext.RecommendationIdentifier;
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
        
        private Amazon.TrustedAdvisor.Model.UpdateRecommendationLifecycleResponse CallAWSServiceOperation(IAmazonTrustedAdvisor client, Amazon.TrustedAdvisor.Model.UpdateRecommendationLifecycleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Trusted Advisor", "UpdateRecommendationLifecycle");
            try
            {
                #if DESKTOP
                return client.UpdateRecommendationLifecycle(request);
                #elif CORECLR
                return client.UpdateRecommendationLifecycleAsync(request).GetAwaiter().GetResult();
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
            public System.String RecommendationIdentifier { get; set; }
            public System.String UpdateReason { get; set; }
            public Amazon.TrustedAdvisor.UpdateRecommendationLifecycleStageReasonCode UpdateReasonCode { get; set; }
            public System.Func<Amazon.TrustedAdvisor.Model.UpdateRecommendationLifecycleResponse, UpdateTARecommendationLifecycleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
