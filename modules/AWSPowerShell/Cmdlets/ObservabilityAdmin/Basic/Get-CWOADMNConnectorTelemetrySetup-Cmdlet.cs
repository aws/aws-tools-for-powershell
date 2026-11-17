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
    /// Generates the artifacts that you use to create the infrastructure in your cloud provider
    /// that delivers the telemetry declared in the connector's telemetry manifest. This operation
    /// doesn't change any resources in your cloud provider or in Amazon Web Services.
    /// </summary>
    [Cmdlet("Get", "CWOADMNConnectorTelemetrySetup")]
    [OutputType("Amazon.ObservabilityAdmin.Model.GetConnectorTelemetrySetupResponse")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service GetConnectorTelemetrySetup API operation.", Operation = new[] {"GetConnectorTelemetrySetup"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.GetConnectorTelemetrySetupResponse))]
    [AWSCmdletOutput("Amazon.ObservabilityAdmin.Model.GetConnectorTelemetrySetupResponse",
        "This cmdlet returns an Amazon.ObservabilityAdmin.Model.GetConnectorTelemetrySetupResponse object containing multiple properties."
    )]
    public partial class GetCWOADMNConnectorTelemetrySetupCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectorIdentifier
        /// <summary>
        /// <para>
        /// <para>The connector whose telemetry manifest you want to generate the setup from. Specify
        /// one of the following:</para><ul><li><para>The Amazon Resource Name (ARN) of the connector</para></li><li><para>The ID of the connector</para></li></ul>
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
        public System.String ConnectorIdentifier { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>The format of the setup artifacts. If you omit this value, the service uses the default
        /// format for the connector's provider (<c>BICEP</c> for an Azure connector). If the
        /// provider doesn't support the format, the service returns a <c>ValidationException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ObservabilityAdmin.SetupFormat")]
        public Amazon.ObservabilityAdmin.SetupFormat Format { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.GetConnectorTelemetrySetupResponse).
        /// Specifying the name of a property of type Amazon.ObservabilityAdmin.Model.GetConnectorTelemetrySetupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.GetConnectorTelemetrySetupResponse, GetCWOADMNConnectorTelemetrySetupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectorIdentifier = this.ConnectorIdentifier;
            #if MODULAR
            if (this.ConnectorIdentifier == null && ParameterWasBound(nameof(this.ConnectorIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Format = this.Format;
            
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
            var request = new Amazon.ObservabilityAdmin.Model.GetConnectorTelemetrySetupRequest();
            
            if (cmdletContext.ConnectorIdentifier != null)
            {
                request.ConnectorIdentifier = cmdletContext.ConnectorIdentifier;
            }
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
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
        
        private Amazon.ObservabilityAdmin.Model.GetConnectorTelemetrySetupResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.GetConnectorTelemetrySetupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "GetConnectorTelemetrySetup");
            try
            {
                return client.GetConnectorTelemetrySetupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectorIdentifier { get; set; }
            public Amazon.ObservabilityAdmin.SetupFormat Format { get; set; }
            public System.Func<Amazon.ObservabilityAdmin.Model.GetConnectorTelemetrySetupResponse, GetCWOADMNConnectorTelemetrySetupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
