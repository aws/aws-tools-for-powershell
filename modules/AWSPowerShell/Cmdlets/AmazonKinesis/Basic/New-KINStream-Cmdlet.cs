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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Creates a Amazon Kinesis stream. A stream captures and transports data records that
    /// are continuously emitted from different data sources or <i>producers</i>. Scale-out
    /// within an Amazon Kinesis stream is explicitly supported by means of shards, which
    /// are uniquely identified groups of data records in an Amazon Kinesis stream.
    /// 
    ///  
    /// <para>
    /// You specify and control the number of shards that a stream is composed of. Each shard
    /// can support reads up to 5 transactions per second, up to a maximum data read total
    /// of 2 MB per second. Each shard can support writes up to 1,000 records per second,
    /// up to a maximum data write total of 1 MB per second. You can add shards to a stream
    /// if the amount of data input increases and you can remove shards if the amount of data
    /// input decreases.
    /// </para><para>
    /// The stream name identifies the stream. The name is scoped to the AWS account used
    /// by the application. It is also scoped by region. That is, two streams in two different
    /// accounts can have the same name, and two streams in the same account, but in two different
    /// regions, can have the same name. 
    /// </para><para><code>CreateStream</code> is an asynchronous operation. Upon receiving a <code>CreateStream</code>
    /// request, Amazon Kinesis immediately returns and sets the stream status to <code>CREATING</code>.
    /// After the stream is created, Amazon Kinesis sets the stream status to <code>ACTIVE</code>.
    /// You should perform read and write operations only on an <code>ACTIVE</code> stream.
    /// 
    /// </para><para>
    /// You receive a <code>LimitExceededException</code> when making a <code>CreateStream</code>
    /// request if you try to do one of the following:
    /// </para><ul><li>Have more than five streams in the <code>CREATING</code> state at any point
    /// in time.</li><li>Create more shards than are authorized for your account.</li></ul><para>
    /// For the default shard limit for an AWS account, see <a href="http://docs.aws.amazon.com/kinesis/latest/dev/service-sizes-and-limits.html">Amazon
    /// Kinesis Limits</a>. If you need to increase this limit, <a href="http://docs.aws.amazon.com/general/latest/gr/aws_service_limits.html">contact
    /// AWS Support</a>.
    /// </para><para>
    /// You can use <code>DescribeStream</code> to check the stream status, which is returned
    /// in <code>StreamStatus</code>.
    /// </para><para><a>CreateStream</a> has a limit of 5 transactions per second per account.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KINStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the CreateStream operation against AWS Kinesis.", Operation = new[] {"CreateStream"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the StreamName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Kinesis.Model.CreateStreamResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewKINStreamCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The number of shards that the stream will use. The throughput of the stream is a function
        /// of the number of shards; more shards are required for greater provisioned throughput.</para><para>DefaultShardLimit;</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Int32 ShardCount { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A name to identify the stream. The stream name is scoped to the AWS account used by
        /// the application that creates the stream. It is also scoped by region. That is, two
        /// streams in two different AWS accounts can have the same name, and two streams in the
        /// same AWS account, but in two different regions, can have the same name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        
        /// <summary>
        /// Returns the value passed to the StreamName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StreamName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KINStream (CreateStream)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("ShardCount"))
                context.ShardCount = this.ShardCount;
            context.StreamName = this.StreamName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Kinesis.Model.CreateStreamRequest();
            
            if (cmdletContext.ShardCount != null)
            {
                request.ShardCount = cmdletContext.ShardCount.Value;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateStream(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.StreamName;
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
            public System.Int32? ShardCount { get; set; }
            public System.String StreamName { get; set; }
        }
        
    }
}
