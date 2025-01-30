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
using Amazon.XRay;
using Amazon.XRay.Model;

namespace Amazon.PowerShell.Cmdlets.XR
{
    /// <summary>
    /// Retrieves the current destination of data sent to <c>PutTraceSegments</c> and <i>OpenTelemetry</i>
    /// API. The Transaction Search feature requires a CloudWatchLogs destination. For more
    /// information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-Transaction-Search.html">Transaction
    /// Search</a> and <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-OpenTelemetry-Sections.html">OpenTelemetry</a>.
    /// </summary>
    [Cmdlet("Get", "XRTraceSegmentDestination")]
    [OutputType("Amazon.XRay.Model.GetTraceSegmentDestinationResponse")]
    [AWSCmdlet("Calls the AWS X-Ray GetTraceSegmentDestination API operation.", Operation = new[] {"GetTraceSegmentDestination"}, SelectReturnType = typeof(Amazon.XRay.Model.GetTraceSegmentDestinationResponse))]
    [AWSCmdletOutput("Amazon.XRay.Model.GetTraceSegmentDestinationResponse",
        "This cmdlet returns an Amazon.XRay.Model.GetTraceSegmentDestinationResponse object containing multiple properties."
    )]
    public partial class GetXRTraceSegmentDestinationCmdlet : AmazonXRayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.XRay.Model.GetTraceSegmentDestinationResponse).
        /// Specifying the name of a property of type Amazon.XRay.Model.GetTraceSegmentDestinationResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.XRay.Model.GetTraceSegmentDestinationResponse, GetXRTraceSegmentDestinationCmdlet>(Select) ??
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
            var request = new Amazon.XRay.Model.GetTraceSegmentDestinationRequest();
            
            
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
        
        private Amazon.XRay.Model.GetTraceSegmentDestinationResponse CallAWSServiceOperation(IAmazonXRay client, Amazon.XRay.Model.GetTraceSegmentDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS X-Ray", "GetTraceSegmentDestination");
            try
            {
                #if DESKTOP
                return client.GetTraceSegmentDestination(request);
                #elif CORECLR
                return client.GetTraceSegmentDestinationAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.XRay.Model.GetTraceSegmentDestinationResponse, GetXRTraceSegmentDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
