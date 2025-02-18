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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Gets the reason that a specified health check failed most recently.
    /// </summary>
    [Cmdlet("Get", "R53HealthCheckLastFailureReason")]
    [OutputType("Amazon.Route53.Model.HealthCheckObservation")]
    [AWSCmdlet("Calls the Amazon Route 53 GetHealthCheckLastFailureReason API operation.", Operation = new[] {"GetHealthCheckLastFailureReason"}, SelectReturnType = typeof(Amazon.Route53.Model.GetHealthCheckLastFailureReasonResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.HealthCheckObservation or Amazon.Route53.Model.GetHealthCheckLastFailureReasonResponse",
        "This cmdlet returns a collection of Amazon.Route53.Model.HealthCheckObservation objects.",
        "The service call response (type Amazon.Route53.Model.GetHealthCheckLastFailureReasonResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetR53HealthCheckLastFailureReasonCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter HealthCheckId
        /// <summary>
        /// <para>
        /// <para>The ID for the health check for which you want the last failure reason. When you created
        /// the health check, <c>CreateHealthCheck</c> returned the ID in the response, in the
        /// <c>HealthCheckId</c> element.</para><note><para>If you want to get the last failure reason for a calculated health check, you must
        /// use the Amazon Route 53 console or the CloudWatch console. You can't use <c>GetHealthCheckLastFailureReason</c>
        /// for a calculated health check.</para></note>
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
        public System.String HealthCheckId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HealthCheckObservations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.GetHealthCheckLastFailureReasonResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.GetHealthCheckLastFailureReasonResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HealthCheckObservations";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.GetHealthCheckLastFailureReasonResponse, GetR53HealthCheckLastFailureReasonCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HealthCheckId = this.HealthCheckId;
            #if MODULAR
            if (this.HealthCheckId == null && ParameterWasBound(nameof(this.HealthCheckId)))
            {
                WriteWarning("You are passing $null as a value for parameter HealthCheckId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53.Model.GetHealthCheckLastFailureReasonRequest();
            
            if (cmdletContext.HealthCheckId != null)
            {
                request.HealthCheckId = cmdletContext.HealthCheckId;
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
        
        private Amazon.Route53.Model.GetHealthCheckLastFailureReasonResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.GetHealthCheckLastFailureReasonRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "GetHealthCheckLastFailureReason");
            try
            {
                return client.GetHealthCheckLastFailureReasonAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String HealthCheckId { get; set; }
            public System.Func<Amazon.Route53.Model.GetHealthCheckLastFailureReasonResponse, GetR53HealthCheckLastFailureReasonCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HealthCheckObservations;
        }
        
    }
}
