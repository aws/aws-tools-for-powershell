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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
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
    [Cmdlet("Get", "DDBStream")]
    [OutputType("Amazon.DynamoDBv2.Model.StreamDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB DescribeStream API operation.", Operation = new[] {"DescribeStream"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.DescribeStreamResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.StreamDescription or Amazon.DynamoDBv2.Model.DescribeStreamResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.StreamDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.DescribeStreamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDDBStreamCmdlet : AmazonDynamoDBStreamsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter ShardFilter_ShardId
        /// <summary>
        /// <para>
        /// <para>Contains the <c>shardId</c> of the parent shard for which you are requesting child
        /// shards.</para><para><i>Sample request:</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShardFilter_ShardId { get; set; }
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
        
        #region Parameter ShardFilter_Type
        /// <summary>
        /// <para>
        /// <para>Contains the type of filter to be applied on the <c>DescribeStream</c> API. Currently,
        /// the only value this parameter accepts is <c>CHILD_SHARDS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ShardFilterType")]
        public Amazon.DynamoDBv2.ShardFilterType ShardFilter_Type { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.DescribeStreamResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.DescribeStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StreamDescription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StreamArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StreamArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StreamArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.DescribeStreamResponse, GetDDBStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StreamArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExclusiveStartShardId = this.ExclusiveStartShardId;
            context.Limit = this.Limit;
            context.ShardFilter_ShardId = this.ShardFilter_ShardId;
            context.ShardFilter_Type = this.ShardFilter_Type;
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
            var request = new Amazon.DynamoDBv2.Model.DescribeStreamRequest();
            
            if (cmdletContext.ExclusiveStartShardId != null)
            {
                request.ExclusiveStartShardId = cmdletContext.ExclusiveStartShardId;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            
             // populate ShardFilter
            var requestShardFilterIsNull = true;
            request.ShardFilter = new Amazon.DynamoDBv2.Model.ShardFilter();
            System.String requestShardFilter_shardFilter_ShardId = null;
            if (cmdletContext.ShardFilter_ShardId != null)
            {
                requestShardFilter_shardFilter_ShardId = cmdletContext.ShardFilter_ShardId;
            }
            if (requestShardFilter_shardFilter_ShardId != null)
            {
                request.ShardFilter.ShardId = requestShardFilter_shardFilter_ShardId;
                requestShardFilterIsNull = false;
            }
            Amazon.DynamoDBv2.ShardFilterType requestShardFilter_shardFilter_Type = null;
            if (cmdletContext.ShardFilter_Type != null)
            {
                requestShardFilter_shardFilter_Type = cmdletContext.ShardFilter_Type;
            }
            if (requestShardFilter_shardFilter_Type != null)
            {
                request.ShardFilter.Type = requestShardFilter_shardFilter_Type;
                requestShardFilterIsNull = false;
            }
             // determine if request.ShardFilter should be set to null
            if (requestShardFilterIsNull)
            {
                request.ShardFilter = null;
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
        
        private Amazon.DynamoDBv2.Model.DescribeStreamResponse CallAWSServiceOperation(IAmazonDynamoDBStreams client, Amazon.DynamoDBv2.Model.DescribeStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "DescribeStream");
            try
            {
                #if DESKTOP
                return client.DescribeStream(request);
                #elif CORECLR
                return client.DescribeStreamAsync(request).GetAwaiter().GetResult();
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
            public System.String ExclusiveStartShardId { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String ShardFilter_ShardId { get; set; }
            public Amazon.DynamoDBv2.ShardFilterType ShardFilter_Type { get; set; }
            public System.String StreamArn { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.DescribeStreamResponse, GetDDBStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StreamDescription;
        }
        
    }
}
