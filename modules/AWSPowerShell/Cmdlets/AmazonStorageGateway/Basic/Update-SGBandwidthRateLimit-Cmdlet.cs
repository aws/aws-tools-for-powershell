/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// This operation updates the bandwidth rate limits of a gateway. You can update both
    /// the upload and download bandwidth rate limit or specify only one of the two. If you
    /// don't set a bandwidth rate limit, the existing rate limit remains.
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
    [AWSCmdlet("Invokes the UpdateBandwidthRateLimit operation against AWS Storage Gateway.", Operation = new[] {"UpdateBandwidthRateLimit"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type UpdateBandwidthRateLimitResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateSGBandwidthRateLimitCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The average download bandwidth rate limit in bits per second.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public Int64 AverageDownloadRateLimitInBitsPerSec { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The average upload bandwidth rate limit in bits per second.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public Int64 AverageUploadRateLimitInBitsPerSec { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String GatewayARN { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GatewayARN", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SGBandwidthRateLimit (UpdateBandwidthRateLimit)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("AverageDownloadRateLimitInBitsPerSec"))
                context.AverageDownloadRateLimitInBitsPerSec = this.AverageDownloadRateLimitInBitsPerSec;
            if (ParameterWasBound("AverageUploadRateLimitInBitsPerSec"))
                context.AverageUploadRateLimitInBitsPerSec = this.AverageUploadRateLimitInBitsPerSec;
            context.GatewayARN = this.GatewayARN;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateBandwidthRateLimitRequest();
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateBandwidthRateLimit(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GatewayARN;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public Int64? AverageDownloadRateLimitInBitsPerSec { get; set; }
            public Int64? AverageUploadRateLimitInBitsPerSec { get; set; }
            public String GatewayARN { get; set; }
        }
        
    }
}
