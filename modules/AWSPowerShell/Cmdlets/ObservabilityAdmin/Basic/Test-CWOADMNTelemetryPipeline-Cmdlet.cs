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
    /// Tests a pipeline configuration with sample records to validate data processing before
    /// deployment. This operation helps ensure your pipeline configuration works as expected.
    /// </summary>
    [Cmdlet("Test", "CWOADMNTelemetryPipeline")]
    [OutputType("Amazon.ObservabilityAdmin.Model.PipelineOutput")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service TestTelemetryPipeline API operation.", Operation = new[] {"TestTelemetryPipeline"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.TestTelemetryPipelineResponse))]
    [AWSCmdletOutput("Amazon.ObservabilityAdmin.Model.PipelineOutput or Amazon.ObservabilityAdmin.Model.TestTelemetryPipelineResponse",
        "This cmdlet returns a collection of Amazon.ObservabilityAdmin.Model.PipelineOutput objects.",
        "The service call response (type Amazon.ObservabilityAdmin.Model.TestTelemetryPipelineResponse) can be returned by specifying '-Select *'."
    )]
    public partial class TestCWOADMNTelemetryPipelineCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
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
        
        #region Parameter Record
        /// <summary>
        /// <para>
        /// <para>The sample records to process through the pipeline configuration for testing purposes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Records")]
        public Amazon.ObservabilityAdmin.Model.Record[] Record { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Results'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.TestTelemetryPipelineResponse).
        /// Specifying the name of a property of type Amazon.ObservabilityAdmin.Model.TestTelemetryPipelineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Results";
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
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.TestTelemetryPipelineResponse, TestCWOADMNTelemetryPipelineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Configuration_Body = this.Configuration_Body;
            #if MODULAR
            if (this.Configuration_Body == null && ParameterWasBound(nameof(this.Configuration_Body)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration_Body which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Record != null)
            {
                context.Record = new List<Amazon.ObservabilityAdmin.Model.Record>(this.Record);
            }
            #if MODULAR
            if (this.Record == null && ParameterWasBound(nameof(this.Record)))
            {
                WriteWarning("You are passing $null as a value for parameter Record which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ObservabilityAdmin.Model.TestTelemetryPipelineRequest();
            
            
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
            if (cmdletContext.Record != null)
            {
                request.Records = cmdletContext.Record;
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
        
        private Amazon.ObservabilityAdmin.Model.TestTelemetryPipelineResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.TestTelemetryPipelineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "TestTelemetryPipeline");
            try
            {
                return client.TestTelemetryPipelineAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ObservabilityAdmin.Model.Record> Record { get; set; }
            public System.Func<Amazon.ObservabilityAdmin.Model.TestTelemetryPipelineResponse, TestCWOADMNTelemetryPipelineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Results;
        }
        
    }
}
