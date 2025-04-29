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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Updates the bandwidth rate limits of a gateway. You can update both the upload and
    /// download bandwidth rate limit or specify only one of the two. If you don't set a bandwidth
    /// rate limit, the existing rate limit remains. This operation is supported only for
    /// the stored volume, cached volume, and tape gateway types. To update bandwidth rate
    /// limits for S3 file gateways, use <a>UpdateBandwidthRateLimitSchedule</a>.
    /// 
    ///  
    /// <para>
    /// By default, a gateway's bandwidth rate limits are not set. If you don't set any limit,
    /// the gateway does not have any limitations on its bandwidth usage and could potentially
    /// use the maximum available bandwidth.
    /// </para><para>
    /// To specify which gateway to update, use the Amazon Resource Name (ARN) of the gateway
    /// in your request.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SGBandwidthRateLimit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Storage Gateway UpdateBandwidthRateLimit API operation.", Operation = new[] {"UpdateBandwidthRateLimit"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.UpdateBandwidthRateLimitResponse))]
    [AWSCmdletOutput("System.String or Amazon.StorageGateway.Model.UpdateBandwidthRateLimitResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.StorageGateway.Model.UpdateBandwidthRateLimitResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSGBandwidthRateLimitCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AverageDownloadRateLimitInBitsPerSec
        /// <summary>
        /// <para>
        /// <para>The average download bandwidth rate limit in bits per second.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.Int64? AverageDownloadRateLimitInBitsPerSec { get; set; }
        #endregion
        
        #region Parameter AverageUploadRateLimitInBitsPerSec
        /// <summary>
        /// <para>
        /// <para>The average upload bandwidth rate limit in bits per second.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.Int64? AverageUploadRateLimitInBitsPerSec { get; set; }
        #endregion
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GatewayARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.UpdateBandwidthRateLimitResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.UpdateBandwidthRateLimitResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GatewayARN";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SGBandwidthRateLimit (UpdateBandwidthRateLimit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.UpdateBandwidthRateLimitResponse, UpdateSGBandwidthRateLimitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AverageDownloadRateLimitInBitsPerSec = this.AverageDownloadRateLimitInBitsPerSec;
            context.AverageUploadRateLimitInBitsPerSec = this.AverageUploadRateLimitInBitsPerSec;
            context.GatewayARN = this.GatewayARN;
            #if MODULAR
            if (this.GatewayARN == null && ParameterWasBound(nameof(this.GatewayARN)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StorageGateway.Model.UpdateBandwidthRateLimitRequest();
            
            if (cmdletContext.AverageDownloadRateLimitInBitsPerSec != null)
            {
                request.AverageDownloadRateLimitInBitsPerSec = cmdletContext.AverageDownloadRateLimitInBitsPerSec.Value;
            }
            if (cmdletContext.AverageUploadRateLimitInBitsPerSec != null)
            {
                request.AverageUploadRateLimitInBitsPerSec = cmdletContext.AverageUploadRateLimitInBitsPerSec.Value;
            }
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
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
        
        private Amazon.StorageGateway.Model.UpdateBandwidthRateLimitResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.UpdateBandwidthRateLimitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "UpdateBandwidthRateLimit");
            try
            {
                return client.UpdateBandwidthRateLimitAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int64? AverageDownloadRateLimitInBitsPerSec { get; set; }
            public System.Int64? AverageUploadRateLimitInBitsPerSec { get; set; }
            public System.String GatewayARN { get; set; }
            public System.Func<Amazon.StorageGateway.Model.UpdateBandwidthRateLimitResponse, UpdateSGBandwidthRateLimitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GatewayARN;
        }
        
    }
}
