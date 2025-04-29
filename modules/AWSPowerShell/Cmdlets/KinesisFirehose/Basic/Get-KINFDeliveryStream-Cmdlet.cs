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
    /// Describes the specified Firehose stream and its status. For example, after your Firehose
    /// stream is created, call <c>DescribeDeliveryStream</c> to see whether the Firehose
    /// stream is <c>ACTIVE</c> and therefore ready for data to be sent to it. 
    /// 
    ///  
    /// <para>
    /// If the status of a Firehose stream is <c>CREATING_FAILED</c>, this status doesn't
    /// change, and you can't invoke <a>CreateDeliveryStream</a> again on it. However, you
    /// can invoke the <a>DeleteDeliveryStream</a> operation to delete it. If the status is
    /// <c>DELETING_FAILED</c>, you can force deletion by invoking <a>DeleteDeliveryStream</a>
    /// again but with <a>DeleteDeliveryStreamInput$AllowForceDelete</a> set to true.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINFDeliveryStream")]
    [OutputType("Amazon.KinesisFirehose.Model.DeliveryStreamDescription")]
    [AWSCmdlet("Calls the Amazon Kinesis Firehose DescribeDeliveryStream API operation.", Operation = new[] {"DescribeDeliveryStream"}, SelectReturnType = typeof(Amazon.KinesisFirehose.Model.DescribeDeliveryStreamResponse))]
    [AWSCmdletOutput("Amazon.KinesisFirehose.Model.DeliveryStreamDescription or Amazon.KinesisFirehose.Model.DescribeDeliveryStreamResponse",
        "This cmdlet returns an Amazon.KinesisFirehose.Model.DeliveryStreamDescription object.",
        "The service call response (type Amazon.KinesisFirehose.Model.DescribeDeliveryStreamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetKINFDeliveryStreamCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the Firehose stream.</para>
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
        public System.String DeliveryStreamName { get; set; }
        #endregion
        
        #region Parameter ExclusiveStartDestinationId
        /// <summary>
        /// <para>
        /// <para>The ID of the destination to start returning the destination information. Firehose
        /// supports one destination per Firehose stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExclusiveStartDestinationId { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The limit on the number of destinations to return. You can have one destination per
        /// Firehose stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DeliveryStreamDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisFirehose.Model.DescribeDeliveryStreamResponse).
        /// Specifying the name of a property of type Amazon.KinesisFirehose.Model.DescribeDeliveryStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DeliveryStreamDescription";
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
                context.Select = CreateSelectDelegate<Amazon.KinesisFirehose.Model.DescribeDeliveryStreamResponse, GetKINFDeliveryStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeliveryStreamName = this.DeliveryStreamName;
            #if MODULAR
            if (this.DeliveryStreamName == null && ParameterWasBound(nameof(this.DeliveryStreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeliveryStreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExclusiveStartDestinationId = this.ExclusiveStartDestinationId;
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
        
        private Amazon.KinesisFirehose.Model.DescribeDeliveryStreamResponse CallAWSServiceOperation(IAmazonKinesisFirehose client, Amazon.KinesisFirehose.Model.DescribeDeliveryStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Firehose", "DescribeDeliveryStream");
            try
            {
                return client.DescribeDeliveryStreamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DeliveryStreamName { get; set; }
            public System.String ExclusiveStartDestinationId { get; set; }
            public System.Int32? Limit { get; set; }
            public System.Func<Amazon.KinesisFirehose.Model.DescribeDeliveryStreamResponse, GetKINFDeliveryStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeliveryStreamDescription;
        }
        
    }
}
