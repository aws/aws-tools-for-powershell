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
    /// Lists your delivery streams.
    /// 
    ///  
    /// <para>
    /// The number of delivery streams might be too large to return using a single call to
    /// <a>ListDeliveryStreams</a>. You can limit the number of delivery streams returned,
    /// using the <code>Limit</code> parameter. To determine whether there are more delivery
    /// streams to list, check the value of <code>HasMoreDeliveryStreams</code> in the output.
    /// If there are more delivery streams to list, you can request them by specifying the
    /// name of the last delivery stream returned in the call in the <code>ExclusiveStartDeliveryStreamName</code>
    /// parameter of a subsequent call.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINFDeliveryStreamList")]
    [OutputType("Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse")]
    [AWSCmdlet("Invokes the ListDeliveryStreams operation against Amazon Kinesis Firehose.", Operation = new[] {"ListDeliveryStreams"})]
    [AWSCmdletOutput("Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse",
        "This cmdlet returns a Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetKINFDeliveryStreamListCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        
        #region Parameter ExclusiveStartDeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the delivery stream to start the list with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExclusiveStartDeliveryStreamName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of delivery streams to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Limit { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ExclusiveStartDeliveryStreamName = this.ExclusiveStartDeliveryStreamName;
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
            var request = new Amazon.KinesisFirehose.Model.ListDeliveryStreamsRequest();
            
            if (cmdletContext.ExclusiveStartDeliveryStreamName != null)
            {
                request.ExclusiveStartDeliveryStreamName = cmdletContext.ExclusiveStartDeliveryStreamName;
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
                var response = client.ListDeliveryStreams(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ExclusiveStartDeliveryStreamName { get; set; }
            public System.Int32? Limit { get; set; }
        }
        
    }
}
