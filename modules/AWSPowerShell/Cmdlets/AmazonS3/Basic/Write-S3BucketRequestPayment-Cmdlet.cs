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
    /// Sets the request payment configuration for a bucket. By default, the bucket owner
    /// pays for downloads from the bucket. This configuration parameter enables the bucket
    /// owner (only) to specify that the person requesting the download will be charged for
    /// the download. Documentation on requester pays buckets can be found at http://docs.aws.amazon.com/AmazonS3/latest/dev/RequesterPaysBuckets.html
    /// </summary>
    [Cmdlet("Write", "S3BucketRequestPayment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutBucketRequestPayment operation against Amazon Simple Storage Service.", Operation = new[] {"PutBucketRequestPayment"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the BucketName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.S3.Model.PutBucketRequestPaymentResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteS3BucketRequestPaymentCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket to set payment config.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter RequestPaymentConfiguration_Payer
        /// <summary>
        /// <para>
        /// Specifies who pays for the download and request fees.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RequestPaymentConfiguration_Payer { get; set; }
        #endregion
        
        #region Parameter UseAccelerateEndpoint
        /// <summary>
        /// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.
        /// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). 
        /// </summary>
        [Parameter]
        public SwitchParameter UseAccelerateEndpoint { get; set; }
        
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the BucketName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BucketName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketRequestPayment (PutBucketRequestPayment)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.BucketName = this.BucketName;
            context.RequestPaymentConfiguration_Payer = this.RequestPaymentConfiguration_Payer;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.S3.Model.PutBucketRequestPaymentRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            
             // populate RequestPaymentConfiguration
            bool requestRequestPaymentConfigurationIsNull = true;
            request.RequestPaymentConfiguration = new Amazon.S3.Model.RequestPaymentConfiguration();
            System.String requestRequestPaymentConfiguration_requestPaymentConfiguration_Payer = null;
            if (cmdletContext.RequestPaymentConfiguration_Payer != null)
            {
                requestRequestPaymentConfiguration_requestPaymentConfiguration_Payer = cmdletContext.RequestPaymentConfiguration_Payer;
            }
            if (requestRequestPaymentConfiguration_requestPaymentConfiguration_Payer != null)
            {
                request.RequestPaymentConfiguration.Payer = requestRequestPaymentConfiguration_requestPaymentConfiguration_Payer;
                requestRequestPaymentConfigurationIsNull = false;
            }
             // determine if request.RequestPaymentConfiguration should be set to null
            if (requestRequestPaymentConfigurationIsNull)
            {
                request.RequestPaymentConfiguration = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PutBucketRequestPayment(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.BucketName;
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
            public System.String BucketName { get; set; }
            public System.String RequestPaymentConfiguration_Payer { get; set; }
        }
        
    }
}
