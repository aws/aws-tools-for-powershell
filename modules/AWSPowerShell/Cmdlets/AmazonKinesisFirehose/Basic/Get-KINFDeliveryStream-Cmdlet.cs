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
using Amazon.KinesisFirehose;
using Amazon.KinesisFirehose.Model;

namespace Amazon.PowerShell.Cmdlets.KINF
{
    /// <summary>
    /// Describes the specified delivery stream and gets the status. For example, after your
    /// delivery stream is created, call <a>DescribeDeliveryStream</a> to see if the delivery
    /// stream is <code>ACTIVE</code> and therefore ready for data to be sent to it.
    /// </summary>
    [Cmdlet("Get", "KINFDeliveryStream")]
    [OutputType("Amazon.KinesisFirehose.Model.DeliveryStreamDescription")]
    [AWSCmdlet("Invokes the DescribeDeliveryStream operation against Amazon Kinesis Firehose.", Operation = new[] {"DescribeDeliveryStream"})]
    [AWSCmdletOutput("Amazon.KinesisFirehose.Model.DeliveryStreamDescription",
        "This cmdlet returns a DeliveryStreamDescription object.",
        "The service call response (type Amazon.KinesisFirehose.Model.DescribeDeliveryStreamResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetKINFDeliveryStreamCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of the delivery stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeliveryStreamName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies the destination ID to start returning the destination information. Currently
        /// Amazon Kinesis Firehose supports one destination per delivery stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExclusiveStartDestinationId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The limit on the number of destinations to return. Currently, you can have one destination
        /// per delivery stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Limit { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DeliveryStreamName = this.DeliveryStreamName;
            context.ExclusiveStartDestinationId = this.ExclusiveStartDestinationId;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.KinesisFirehose.Model.DescribeDeliveryStreamRequest();
            
            if (cmdletContext.DeliveryStreamName != null)
            {
                request.DeliveryStreamName = cmdletContext.DeliveryStreamName;
            }
            if (cmdletContext.ExclusiveStartDestinationId != null)
            {
                request.ExclusiveStartDestinationId = cmdletContext.ExclusiveStartDestinationId;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeDeliveryStream(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DeliveryStreamDescription;
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
            public System.String DeliveryStreamName { get; set; }
            public System.String ExclusiveStartDestinationId { get; set; }
            public System.Int32? Limit { get; set; }
        }
        
    }
}
