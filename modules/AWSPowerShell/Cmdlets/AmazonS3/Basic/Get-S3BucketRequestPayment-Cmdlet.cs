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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Returns the request payment configuration of a bucket.
    /// </summary>
    [Cmdlet("Get", "S3BucketRequestPayment")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service GetBucketRequestPayment API operation.", Operation = new[] {"GetBucketRequestPayment"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.S3.Model.GetBucketRequestPaymentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetS3BucketRequestPaymentCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter UseAccelerateEndpoint
        /// <summary>
        /// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.
        /// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). 
        /// </summary>
        [Parameter]
        public SwitchParameter UseAccelerateEndpoint { get; set; }
        
        #endregion
        
        #region Parameter UseDualstackEndpoint
        /// <summary>
        /// Configures the request to Amazon S3 to use the dualstack endpoint for a region.
        /// S3 supports dualstack endpoints which return both IPv6 and IPv4 values.
        /// The dualstack mode of Amazon S3 cannot be used with accelerate mode.
        /// </summary>
        [Parameter]
        public SwitchParameter UseDualstackEndpoint { get; set; }
        
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
            
            context.BucketName = this.BucketName;
            
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
            var request = new Amazon.S3.Model.GetBucketRequestPaymentRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Payer;
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
        
        private Amazon.S3.Model.GetBucketRequestPaymentResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.GetBucketRequestPaymentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service", "GetBucketRequestPayment");
            try
            {
                #if DESKTOP
                return client.GetBucketRequestPayment(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetBucketRequestPaymentAsync(request);
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
            public System.String BucketName { get; set; }
        }
        
    }
}
