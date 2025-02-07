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
using Amazon.ObservabilityAdmin;
using Amazon.ObservabilityAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.CWOADMN
{
    /// <summary>
    /// This returns the onboarding status of the telemetry configuration feature for the
    /// organization. It can only be called by a Management Account of an AWS Organization
    /// or an assigned Delegated Admin Account of AWS CloudWatch telemetry config.
    /// </summary>
    [Cmdlet("Get", "CWOADMNTelemetryEvaluationStatusForOrganization")]
    [OutputType("Amazon.ObservabilityAdmin.Model.GetTelemetryEvaluationStatusForOrganizationResponse")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service GetTelemetryEvaluationStatusForOrganization API operation.", Operation = new[] {"GetTelemetryEvaluationStatusForOrganization"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.GetTelemetryEvaluationStatusForOrganizationResponse))]
    [AWSCmdletOutput("Amazon.ObservabilityAdmin.Model.GetTelemetryEvaluationStatusForOrganizationResponse",
        "This cmdlet returns an Amazon.ObservabilityAdmin.Model.GetTelemetryEvaluationStatusForOrganizationResponse object containing multiple properties."
    )]
    public partial class GetCWOADMNTelemetryEvaluationStatusForOrganizationCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.GetTelemetryEvaluationStatusForOrganizationResponse).
        /// Specifying the name of a property of type Amazon.ObservabilityAdmin.Model.GetTelemetryEvaluationStatusForOrganizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.GetTelemetryEvaluationStatusForOrganizationResponse, GetCWOADMNTelemetryEvaluationStatusForOrganizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.ObservabilityAdmin.Model.GetTelemetryEvaluationStatusForOrganizationRequest();
            
            
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
        
        private Amazon.ObservabilityAdmin.Model.GetTelemetryEvaluationStatusForOrganizationResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.GetTelemetryEvaluationStatusForOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "GetTelemetryEvaluationStatusForOrganization");
            try
            {
                #if DESKTOP
                return client.GetTelemetryEvaluationStatusForOrganization(request);
                #elif CORECLR
                return client.GetTelemetryEvaluationStatusForOrganizationAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ObservabilityAdmin.Model.GetTelemetryEvaluationStatusForOrganizationResponse, GetCWOADMNTelemetryEvaluationStatusForOrganizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
