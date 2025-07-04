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
using Amazon.KinesisFirehose;
using Amazon.KinesisFirehose.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KINF
{
    /// <summary>
    /// Lists your Firehose streams in alphabetical order of their names.
    /// 
    ///  
    /// <para>
    /// The number of Firehose streams might be too large to return using a single call to
    /// <c>ListDeliveryStreams</c>. You can limit the number of Firehose streams returned,
    /// using the <c>Limit</c> parameter. To determine whether there are more delivery streams
    /// to list, check the value of <c>HasMoreDeliveryStreams</c> in the output. If there
    /// are more Firehose streams to list, you can request them by calling this operation
    /// again and setting the <c>ExclusiveStartDeliveryStreamName</c> parameter to the name
    /// of the last Firehose stream returned in the last call.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINFDeliveryStreamList")]
    [OutputType("Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Firehose ListDeliveryStreams API operation.", Operation = new[] {"ListDeliveryStreams"}, SelectReturnType = typeof(Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse))]
    [AWSCmdletOutput("Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse",
        "This cmdlet returns an Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse object containing multiple properties."
    )]
    public partial class GetKINFDeliveryStreamListCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeliveryStreamType
        /// <summary>
        /// <para>
        /// <para>The Firehose stream type. This can be one of the following values:</para><ul><li><para><c>DirectPut</c>: Provider applications access the Firehose stream directly.</para></li><li><para><c>KinesisStreamAsSource</c>: The Firehose stream uses a Kinesis data stream as a
        /// source.</para></li></ul><para>This parameter is optional. If this parameter is omitted, Firehose streams of all
        /// types are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.DeliveryStreamType")]
        public Amazon.KinesisFirehose.DeliveryStreamType DeliveryStreamType { get; set; }
        #endregion
        
        #region Parameter ExclusiveStartDeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>The list of Firehose streams returned by this call to <c>ListDeliveryStreams</c> will
        /// start with the Firehose stream whose name comes alphabetically immediately after the
        /// name you specify in <c>ExclusiveStartDeliveryStreamName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExclusiveStartDeliveryStreamName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of Firehose streams to list. The default value is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse).
        /// Specifying the name of a property of type Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse, GetKINFDeliveryStreamListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeliveryStreamType = this.DeliveryStreamType;
            context.ExclusiveStartDeliveryStreamName = this.ExclusiveStartDeliveryStreamName;
            context.Limit = this.Limit;
            
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
            var request = new Amazon.KinesisFirehose.Model.ListDeliveryStreamsRequest();
            
            if (cmdletContext.DeliveryStreamType != null)
            {
                request.DeliveryStreamType = cmdletContext.DeliveryStreamType;
            }
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
        
        private Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse CallAWSServiceOperation(IAmazonKinesisFirehose client, Amazon.KinesisFirehose.Model.ListDeliveryStreamsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Firehose", "ListDeliveryStreams");
            try
            {
                return client.ListDeliveryStreamsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.KinesisFirehose.DeliveryStreamType DeliveryStreamType { get; set; }
            public System.String ExclusiveStartDeliveryStreamName { get; set; }
            public System.Int32? Limit { get; set; }
            public System.Func<Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse, GetKINFDeliveryStreamListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
