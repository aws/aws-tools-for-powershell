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
    /// Validates a pipeline configuration without creating the pipeline. This operation checks
    /// the configuration for syntax errors and compatibility issues.
    /// </summary>
    [Cmdlet("Test", "CWOADMNTelemetryPipelineConfiguration")]
    [OutputType("Amazon.ObservabilityAdmin.Model.ValidationError")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service ValidateTelemetryPipelineConfiguration API operation.", Operation = new[] {"ValidateTelemetryPipelineConfiguration"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.ValidateTelemetryPipelineConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ObservabilityAdmin.Model.ValidationError or Amazon.ObservabilityAdmin.Model.ValidateTelemetryPipelineConfigurationResponse",
        "This cmdlet returns a collection of Amazon.ObservabilityAdmin.Model.ValidationError objects.",
        "The service call response (type Amazon.ObservabilityAdmin.Model.ValidateTelemetryPipelineConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class TestCWOADMNTelemetryPipelineConfigurationCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Configuration_Body
        /// <summary>
        /// <para>
        /// <para>The pipeline configuration body that defines the data processing rules and transformations.</para>
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
        public System.String Configuration_Body { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Errors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.ValidateTelemetryPipelineConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ObservabilityAdmin.Model.ValidateTelemetryPipelineConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Errors";
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
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.ValidateTelemetryPipelineConfigurationResponse, TestCWOADMNTelemetryPipelineConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Configuration_Body = this.Configuration_Body;
            #if MODULAR
            if (this.Configuration_Body == null && ParameterWasBound(nameof(this.Configuration_Body)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration_Body which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ObservabilityAdmin.Model.ValidateTelemetryPipelineConfigurationRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.ObservabilityAdmin.Model.TelemetryPipelineConfiguration();
            System.String requestConfiguration_configuration_Body = null;
            if (cmdletContext.Configuration_Body != null)
            {
                requestConfiguration_configuration_Body = cmdletContext.Configuration_Body;
            }
            if (requestConfiguration_configuration_Body != null)
            {
                request.Configuration.Body = requestConfiguration_configuration_Body;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
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
        
        private Amazon.ObservabilityAdmin.Model.ValidateTelemetryPipelineConfigurationResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.ValidateTelemetryPipelineConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "ValidateTelemetryPipelineConfiguration");
            try
            {
                return client.ValidateTelemetryPipelineConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Configuration_Body { get; set; }
            public System.Func<Amazon.ObservabilityAdmin.Model.ValidateTelemetryPipelineConfigurationResponse, TestCWOADMNTelemetryPipelineConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Errors;
        }
        
    }
}
