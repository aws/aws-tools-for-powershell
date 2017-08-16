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
    /// Returns the bandwidth rate limits of a gateway. By default, these limits are not set,
    /// which means no bandwidth rate limiting is in effect.
    /// 
    ///  
    /// <para>
    /// This operation only returns a value for a bandwidth rate limit only if the limit is
    /// set. If no limits are set for the gateway, then this operation returns only the gateway
    /// ARN in the response body. To specify which gateway to describe, use the Amazon Resource
    /// Name (ARN) of the gateway in your request.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SGBandwidthRateLimit")]
    [OutputType("Amazon.StorageGateway.Model.DescribeBandwidthRateLimitResponse")]
    [AWSCmdlet("Invokes the DescribeBandwidthRateLimit operation against AWS Storage Gateway.", Operation = new[] {"DescribeBandwidthRateLimit"})]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.DescribeBandwidthRateLimitResponse",
        "This cmdlet returns a Amazon.StorageGateway.Model.DescribeBandwidthRateLimitResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSGBandwidthRateLimitCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GatewayARN { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.GatewayARN = this.GatewayARN;
            
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
            var request = new Amazon.StorageGateway.Model.DescribeBandwidthRateLimitRequest();
            
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        #region AWS Service Operation Call
        
        private Amazon.StorageGateway.Model.DescribeBandwidthRateLimitResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.DescribeBandwidthRateLimitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "DescribeBandwidthRateLimit");
            try
            {
                #if DESKTOP
                return client.DescribeBandwidthRateLimit(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeBandwidthRateLimitAsync(request);
                return task.Result;
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
        }
        
    }
}
