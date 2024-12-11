/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Returns information about the bandwidth rate limit schedule of a gateway. By default,
    /// gateways do not have bandwidth rate limit schedules, which means no bandwidth rate
    /// limiting is in effect. This operation is supported only for volume, tape and S3 file
    /// gateways. FSx file gateways do not support bandwidth rate limits.
    /// 
    ///  
    /// <para>
    /// This operation returns information about a gateway's bandwidth rate limit schedule.
    /// A bandwidth rate limit schedule consists of one or more bandwidth rate limit intervals.
    /// A bandwidth rate limit interval defines a period of time on one or more days of the
    /// week, during which bandwidth rate limits are specified for uploading, downloading,
    /// or both. 
    /// </para><para>
    ///  A bandwidth rate limit interval consists of one or more days of the week, a start
    /// hour and minute, an ending hour and minute, and bandwidth rate limits for uploading
    /// and downloading 
    /// </para><para>
    ///  If no bandwidth rate limit schedule intervals are set for the gateway, this operation
    /// returns an empty response. To specify which gateway to describe, use the Amazon Resource
    /// Name (ARN) of the gateway in your request.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SGBandwidthRateLimitSchedule")]
    [OutputType("Amazon.StorageGateway.Model.DescribeBandwidthRateLimitScheduleResponse")]
    [AWSCmdlet("Calls the AWS Storage Gateway DescribeBandwidthRateLimitSchedule API operation.", Operation = new[] {"DescribeBandwidthRateLimitSchedule"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.DescribeBandwidthRateLimitScheduleResponse))]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.DescribeBandwidthRateLimitScheduleResponse",
        "This cmdlet returns an Amazon.StorageGateway.Model.DescribeBandwidthRateLimitScheduleResponse object containing multiple properties."
    )]
    public partial class GetSGBandwidthRateLimitScheduleCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.DescribeBandwidthRateLimitScheduleResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.DescribeBandwidthRateLimitScheduleResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.DescribeBandwidthRateLimitScheduleResponse, GetSGBandwidthRateLimitScheduleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.StorageGateway.Model.DescribeBandwidthRateLimitScheduleRequest();
            
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
        
        private Amazon.StorageGateway.Model.DescribeBandwidthRateLimitScheduleResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.DescribeBandwidthRateLimitScheduleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "DescribeBandwidthRateLimitSchedule");
            try
            {
                #if DESKTOP
                return client.DescribeBandwidthRateLimitSchedule(request);
                #elif CORECLR
                return client.DescribeBandwidthRateLimitScheduleAsync(request).GetAwaiter().GetResult();
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
            public System.String GatewayARN { get; set; }
            public System.Func<Amazon.StorageGateway.Model.DescribeBandwidthRateLimitScheduleResponse, GetSGBandwidthRateLimitScheduleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
