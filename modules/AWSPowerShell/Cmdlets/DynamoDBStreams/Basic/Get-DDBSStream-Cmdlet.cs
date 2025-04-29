/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.DynamoDBStreams;
using Amazon.DynamoDBStreams.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DDBS
{
    /// <summary>
    /// Returns information about a stream, including the current status of the stream, its
    /// Amazon Resource Name (ARN), the composition of its shards, and its corresponding DynamoDB
    /// table.
    /// 
    ///  <note><para>
    /// You can call <c>DescribeStream</c> at a maximum rate of 10 times per second.
    /// </para></note><para>
    /// Each shard in the stream has a <c>SequenceNumberRange</c> associated with it. If the
    /// <c>SequenceNumberRange</c> has a <c>StartingSequenceNumber</c> but no <c>EndingSequenceNumber</c>,
    /// then the shard is still open (able to receive more stream records). If both <c>StartingSequenceNumber</c>
    /// and <c>EndingSequenceNumber</c> are present, then that shard is closed and can no
    /// longer receive more data.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DDBSStream")]
    [OutputType("Amazon.DynamoDBStreams.Model.StreamDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB Streams DescribeStream API operation.", Operation = new[] {"DescribeStream"}, SelectReturnType = typeof(Amazon.DynamoDBStreams.Model.DescribeStreamResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBStreams.Model.StreamDescription or Amazon.DynamoDBStreams.Model.DescribeStreamResponse",
        "This cmdlet returns an Amazon.DynamoDBStreams.Model.StreamDescription object.",
        "The service call response (type Amazon.DynamoDBStreams.Model.DescribeStreamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDDBSStreamCmdlet : AmazonDynamoDBStreamsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExclusiveStartShardId
        /// <summary>
        /// <para>
        /// <para>The shard ID of the first item that this operation will evaluate. Use the value that
        /// was returned for <c>LastEvaluatedShardId</c> in the previous operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String ExclusiveStartShardId { get; set; }
        #endregion
        
        #region Parameter StreamArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the stream.</para>
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
        public System.String StreamArn { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of shard objects to return. The upper limit is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StreamDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBStreams.Model.DescribeStreamResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBStreams.Model.DescribeStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StreamDescription";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBStreams.Model.DescribeStreamResponse, GetDDBSStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExclusiveStartShardId = this.ExclusiveStartShardId;
            context.Limit = this.Limit;
            context.StreamArn = this.StreamArn;
            #if MODULAR
            if (this.StreamArn == null && ParameterWasBound(nameof(this.StreamArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DynamoDBStreams.Model.DescribeStreamRequest();
            
            if (cmdletContext.ExclusiveStartShardId != null)
            {
                request.ExclusiveStartShardId = cmdletContext.ExclusiveStartShardId;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.StreamArn != null)
            {
                request.StreamArn = cmdletContext.StreamArn;
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
        
        private Amazon.DynamoDBStreams.Model.DescribeStreamResponse CallAWSServiceOperation(IAmazonDynamoDBStreams client, Amazon.DynamoDBStreams.Model.DescribeStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB Streams", "DescribeStream");
            try
            {
                return client.DescribeStreamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ExclusiveStartShardId { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String StreamArn { get; set; }
            public System.Func<Amazon.DynamoDBStreams.Model.DescribeStreamResponse, GetDDBSStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StreamDescription;
        }
        
    }
}
