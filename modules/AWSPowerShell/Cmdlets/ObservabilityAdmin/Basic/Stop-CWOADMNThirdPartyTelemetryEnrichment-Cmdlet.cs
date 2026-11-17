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
using Amazon.ObservabilityAdmin;
using Amazon.ObservabilityAdmin.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWOADMN
{
    /// <summary>
    /// Stops a third-party telemetry enrichment. CloudWatch stops adding resource metadata
    /// from the third-party telemetry source to your telemetry.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have the <c>config:DeleteServiceLinkedConfigurationRecorder</c>
    /// permission.
    /// </para>
    /// </summary>
    [Cmdlet("Stop", "CWOADMNThirdPartyTelemetryEnrichment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ObservabilityAdmin.Model.StopThirdPartyTelemetryEnrichmentResponse")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service StopThirdPartyTelemetryEnrichment API operation.", Operation = new[] {"StopThirdPartyTelemetryEnrichment"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.StopThirdPartyTelemetryEnrichmentResponse))]
    [AWSCmdletOutput("Amazon.ObservabilityAdmin.Model.StopThirdPartyTelemetryEnrichmentResponse",
        "This cmdlet returns an Amazon.ObservabilityAdmin.Model.StopThirdPartyTelemetryEnrichmentResponse object containing multiple properties."
    )]
    public partial class StopCWOADMNThirdPartyTelemetryEnrichmentCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TelemetryEnrichmentIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the enrichment to stop. You can specify one of the following:</para><ul><li><para>The name of the enrichment.</para></li><li><para>The Amazon Resource Name (ARN) of the enrichment.</para></li></ul>
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
        public System.String TelemetryEnrichmentIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.StopThirdPartyTelemetryEnrichmentResponse).
        /// Specifying the name of a property of type Amazon.ObservabilityAdmin.Model.StopThirdPartyTelemetryEnrichmentResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TelemetryEnrichmentIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-CWOADMNThirdPartyTelemetryEnrichment (StopThirdPartyTelemetryEnrichment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.StopThirdPartyTelemetryEnrichmentResponse, StopCWOADMNThirdPartyTelemetryEnrichmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TelemetryEnrichmentIdentifier = this.TelemetryEnrichmentIdentifier;
            #if MODULAR
            if (this.TelemetryEnrichmentIdentifier == null && ParameterWasBound(nameof(this.TelemetryEnrichmentIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter TelemetryEnrichmentIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ObservabilityAdmin.Model.StopThirdPartyTelemetryEnrichmentRequest();
            
            if (cmdletContext.TelemetryEnrichmentIdentifier != null)
            {
                request.TelemetryEnrichmentIdentifier = cmdletContext.TelemetryEnrichmentIdentifier;
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
        
        private Amazon.ObservabilityAdmin.Model.StopThirdPartyTelemetryEnrichmentResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.StopThirdPartyTelemetryEnrichmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "StopThirdPartyTelemetryEnrichment");
            try
            {
                return client.StopThirdPartyTelemetryEnrichmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String TelemetryEnrichmentIdentifier { get; set; }
            public System.Func<Amazon.ObservabilityAdmin.Model.StopThirdPartyTelemetryEnrichmentResponse, StopCWOADMNThirdPartyTelemetryEnrichmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
