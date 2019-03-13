/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// To get the description of a registered consumer, provide the ARN of the consumer.
    /// Alternatively, you can provide the ARN of the data stream and the name you gave the
    /// consumer when you registered it. You may also provide all three parameters, as long
    /// as they don't conflict with each other. If you don't know the name or ARN of the consumer
    /// that you want to describe, you can use the <a>ListStreamConsumers</a> operation to
    /// get a list of the descriptions of all the consumers that are currently registered
    /// with a given data stream.
    /// 
    ///  
    /// <para>
    /// This operation has a limit of 20 transactions per second per account.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINStreamConsumer")]
    [OutputType("Amazon.Kinesis.Model.ConsumerDescription")]
    [AWSCmdlet("Calls the Amazon Kinesis DescribeStreamConsumer API operation.", Operation = new[] {"DescribeStreamConsumer"})]
    [AWSCmdletOutput("Amazon.Kinesis.Model.ConsumerDescription",
        "This cmdlet returns a ConsumerDescription object.",
        "The service call response (type Amazon.Kinesis.Model.DescribeStreamConsumerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetKINStreamConsumerCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter ConsumerARN
        /// <summary>
        /// <para>
        /// <para>The ARN returned by Kinesis Data Streams when you registered the consumer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ConsumerARN { get; set; }
        #endregion
        
        #region Parameter ConsumerName
        /// <summary>
        /// <para>
        /// <para>The name that you gave to the consumer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConsumerName { get; set; }
        #endregion
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Kinesis data stream that the consumer is registered with. For more
        /// information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-kinesis-streams">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StreamARN { get; set; }
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
            
            context.ConsumerARN = this.ConsumerARN;
            context.ConsumerName = this.ConsumerName;
            context.StreamARN = this.StreamARN;
            
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
            var request = new Amazon.Kinesis.Model.DescribeStreamConsumerRequest();
            
            if (cmdletContext.ConsumerARN != null)
            {
                request.ConsumerARN = cmdletContext.ConsumerARN;
            }
            if (cmdletContext.ConsumerName != null)
            {
                request.ConsumerName = cmdletContext.ConsumerName;
            }
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ConsumerDescription;
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
        
        private Amazon.Kinesis.Model.DescribeStreamConsumerResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.DescribeStreamConsumerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "DescribeStreamConsumer");
            try
            {
                #if DESKTOP
                return client.DescribeStreamConsumer(request);
                #elif CORECLR
                return client.DescribeStreamConsumerAsync(request).GetAwaiter().GetResult();
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
            public System.String ConsumerARN { get; set; }
            public System.String ConsumerName { get; set; }
            public System.String StreamARN { get; set; }
        }
        
    }
}
