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
using Amazon.KeyspacesStreams;
using Amazon.KeyspacesStreams.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KST
{
    /// <summary>
    /// Returns a shard iterator that serves as a bookmark for reading data from a specific
    /// position in an Amazon Keyspaces data stream's shard. The shard iterator specifies
    /// the shard position from which to start reading data records sequentially. You can
    /// specify whether to begin reading at the latest record, the oldest record, or at a
    /// particular sequence number within the shard.
    /// </summary>
    [Cmdlet("Get", "KSTShardIterator")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Keyspaces Streams GetShardIterator API operation.", Operation = new[] {"GetShardIterator"}, SelectReturnType = typeof(Amazon.KeyspacesStreams.Model.GetShardIteratorResponse))]
    [AWSCmdletOutput("System.String or Amazon.KeyspacesStreams.Model.GetShardIteratorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.KeyspacesStreams.Model.GetShardIteratorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetKSTShardIteratorCmdlet : AmazonKeyspacesStreamsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SequenceNumber
        /// <summary>
        /// <para>
        /// <para> The sequence number of the data record in the shard from which to start reading.
        /// Required if <c>ShardIteratorType</c> is <c>AT_SEQUENCE_NUMBER</c> or <c>AFTER_SEQUENCE_NUMBER</c>.
        /// This parameter is ignored for other iterator types. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SequenceNumber { get; set; }
        #endregion
        
        #region Parameter ShardId
        /// <summary>
        /// <para>
        /// <para> The identifier of the shard within the stream. The shard ID uniquely identifies a
        /// subset of the stream's data records that you want to access. </para>
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
        public System.String ShardId { get; set; }
        #endregion
        
        #region Parameter ShardIteratorType
        /// <summary>
        /// <para>
        /// <para> Determines how the shard iterator is positioned. Must be one of the following:</para><ul><li><para><c>TRIM_HORIZON</c> - Start reading at the last untrimmed record in the shard, which
        /// is the oldest data record in the shard.</para></li><li><para><c>AT_SEQUENCE_NUMBER</c> - Start reading exactly from the specified sequence number.</para></li><li><para><c>AFTER_SEQUENCE_NUMBER</c> - Start reading right after the specified sequence number.</para></li><li><para><c>LATEST</c> - Start reading just after the most recent record in the shard, so
        /// that you always read the most recent data.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KeyspacesStreams.ShardIteratorType")]
        public Amazon.KeyspacesStreams.ShardIteratorType ShardIteratorType { get; set; }
        #endregion
        
        #region Parameter StreamArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the stream for which to get the shard iterator.
        /// The ARN uniquely identifies the stream within Amazon Keyspaces. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String StreamArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ShardIterator'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyspacesStreams.Model.GetShardIteratorResponse).
        /// Specifying the name of a property of type Amazon.KeyspacesStreams.Model.GetShardIteratorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ShardIterator";
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
                context.Select = CreateSelectDelegate<Amazon.KeyspacesStreams.Model.GetShardIteratorResponse, GetKSTShardIteratorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SequenceNumber = this.SequenceNumber;
            context.ShardId = this.ShardId;
            #if MODULAR
            if (this.ShardId == null && ParameterWasBound(nameof(this.ShardId)))
            {
                WriteWarning("You are passing $null as a value for parameter ShardId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShardIteratorType = this.ShardIteratorType;
            #if MODULAR
            if (this.ShardIteratorType == null && ParameterWasBound(nameof(this.ShardIteratorType)))
            {
                WriteWarning("You are passing $null as a value for parameter ShardIteratorType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.KeyspacesStreams.Model.GetShardIteratorRequest();
            
            if (cmdletContext.SequenceNumber != null)
            {
                request.SequenceNumber = cmdletContext.SequenceNumber;
            }
            if (cmdletContext.ShardId != null)
            {
                request.ShardId = cmdletContext.ShardId;
            }
            if (cmdletContext.ShardIteratorType != null)
            {
                request.ShardIteratorType = cmdletContext.ShardIteratorType;
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
        
        private Amazon.KeyspacesStreams.Model.GetShardIteratorResponse CallAWSServiceOperation(IAmazonKeyspacesStreams client, Amazon.KeyspacesStreams.Model.GetShardIteratorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Keyspaces Streams", "GetShardIterator");
            try
            {
                return client.GetShardIteratorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String SequenceNumber { get; set; }
            public System.String ShardId { get; set; }
            public Amazon.KeyspacesStreams.ShardIteratorType ShardIteratorType { get; set; }
            public System.String StreamArn { get; set; }
            public System.Func<Amazon.KeyspacesStreams.Model.GetShardIteratorResponse, GetKSTShardIteratorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ShardIterator;
        }
        
    }
}
