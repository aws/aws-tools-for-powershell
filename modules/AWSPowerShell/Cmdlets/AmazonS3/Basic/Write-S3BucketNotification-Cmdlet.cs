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
    /// Enables notifications of specified events for a bucket.
    /// </summary>
    [Cmdlet("Write", "S3BucketNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutBucketNotification operation against Amazon Simple Storage Service.", Operation = new[] {"PutBucketNotification"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the BucketName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.S3.Model.PutBucketNotificationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteS3BucketNotificationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionConfiguration
        /// <summary>
        /// <para>
        /// LambdaFunctionConfigurations are configuration for 
        /// Amazon S3 events to be sent to an Amazon Lambda cloud function.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LambdaFunctionConfigurations")]
        public Amazon.S3.Model.LambdaFunctionConfiguration[] LambdaFunctionConfiguration { get; set; }
        #endregion
        
        #region Parameter QueueConfiguration
        /// <summary>
        /// <para>
        /// QueueConfigurations are configuration for Amazon S3 
        /// events to be sent to Amazon SQS queues.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("QueueConfigurations")]
        public Amazon.S3.Model.QueueConfiguration[] QueueConfiguration { get; set; }
        #endregion
        
        #region Parameter TopicConfiguration
        /// <summary>
        /// <para>
        /// TopicConfigurations are configuration for Amazon S3 
        /// events to be sent to Amazon SNS topics.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TopicConfigurations")]
        public Amazon.S3.Model.TopicConfiguration[] TopicConfiguration { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketNotification (PutBucketNotification)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.BucketName = this.BucketName;
            if (this.TopicConfiguration != null)
            {
                context.TopicConfigurations = new List<Amazon.S3.Model.TopicConfiguration>(this.TopicConfiguration);
            }
            if (this.QueueConfiguration != null)
            {
                context.QueueConfigurations = new List<Amazon.S3.Model.QueueConfiguration>(this.QueueConfiguration);
            }
            if (this.LambdaFunctionConfiguration != null)
            {
                context.LambdaFunctionConfigurations = new List<Amazon.S3.Model.LambdaFunctionConfiguration>(this.LambdaFunctionConfiguration);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.S3.Model.PutBucketNotificationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.TopicConfigurations != null)
            {
                request.TopicConfigurations = cmdletContext.TopicConfigurations;
            }
            if (cmdletContext.QueueConfigurations != null)
            {
                request.QueueConfigurations = cmdletContext.QueueConfigurations;
            }
            if (cmdletContext.LambdaFunctionConfigurations != null)
            {
                request.LambdaFunctionConfigurations = cmdletContext.LambdaFunctionConfigurations;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private static Amazon.S3.Model.PutBucketNotificationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutBucketNotificationRequest request)
        {
            return client.PutBucketNotification(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String BucketName { get; set; }
            public List<Amazon.S3.Model.TopicConfiguration> TopicConfigurations { get; set; }
            public List<Amazon.S3.Model.QueueConfiguration> QueueConfigurations { get; set; }
            public List<Amazon.S3.Model.LambdaFunctionConfiguration> LambdaFunctionConfigurations { get; set; }
        }
        
    }
}
