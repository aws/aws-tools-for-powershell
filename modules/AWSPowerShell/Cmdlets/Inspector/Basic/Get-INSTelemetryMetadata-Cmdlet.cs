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
using Amazon.Inspector;
using Amazon.Inspector.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Information about the data that is collected for the specified assessment run.
    /// </summary>
    [Cmdlet("Get", "INSTelemetryMetadata")]
    [OutputType("Amazon.Inspector.Model.TelemetryMetadata")]
    [AWSCmdlet("Calls the Amazon Inspector GetTelemetryMetadata API operation.", Operation = new[] {"GetTelemetryMetadata"}, SelectReturnType = typeof(Amazon.Inspector.Model.GetTelemetryMetadataResponse))]
    [AWSCmdletOutput("Amazon.Inspector.Model.TelemetryMetadata or Amazon.Inspector.Model.GetTelemetryMetadataResponse",
        "This cmdlet returns a collection of Amazon.Inspector.Model.TelemetryMetadata objects.",
        "The service call response (type Amazon.Inspector.Model.GetTelemetryMetadataResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetINSTelemetryMetadataCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssessmentRunArn
        /// <summary>
        /// <para>
        /// <para>The ARN that specifies the assessment run that has the telemetry data that you want
        /// to obtain.</para>
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
        public System.String AssessmentRunArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TelemetryMetadata'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector.Model.GetTelemetryMetadataResponse).
        /// Specifying the name of a property of type Amazon.Inspector.Model.GetTelemetryMetadataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TelemetryMetadata";
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
                context.Select = CreateSelectDelegate<Amazon.Inspector.Model.GetTelemetryMetadataResponse, GetINSTelemetryMetadataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssessmentRunArn = this.AssessmentRunArn;
            #if MODULAR
            if (this.AssessmentRunArn == null && ParameterWasBound(nameof(this.AssessmentRunArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AssessmentRunArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Inspector.Model.GetTelemetryMetadataRequest();
            
            if (cmdletContext.AssessmentRunArn != null)
            {
                request.AssessmentRunArn = cmdletContext.AssessmentRunArn;
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
        
        private Amazon.Inspector.Model.GetTelemetryMetadataResponse CallAWSServiceOperation(IAmazonInspector client, Amazon.Inspector.Model.GetTelemetryMetadataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Inspector", "GetTelemetryMetadata");
            try
            {
                return client.GetTelemetryMetadataAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssessmentRunArn { get; set; }
            public System.Func<Amazon.Inspector.Model.GetTelemetryMetadataResponse, GetINSTelemetryMetadataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TelemetryMetadata;
        }
        
    }
}
