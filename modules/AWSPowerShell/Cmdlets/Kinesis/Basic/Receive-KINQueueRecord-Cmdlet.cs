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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Receives up to 10 records from the specified queue. Each record is returned with a
    /// receipt handle, which is the identifier you use to acknowledge the record or change
    /// its visibility.
    /// 
    ///  
    /// <para>
    /// A record returned by <c>ReceiveQueueRecords</c> becomes in flight: it is not visible
    /// to any consumer instance for the duration of its visibility timeout, so subsequent
    /// receive requests do not return it while your queue consumer processes it. Acknowledge
    /// the record with <a>AcknowledgeQueueRecords</a> when you finish processing it. A record
    /// that is not acknowledged before its visibility timeout expires becomes visible in
    /// the queue again and can be received by any consumer instance.
    /// </para><para>
    /// Use <c>WaitTimeSeconds</c> to control how long the call waits for a record to become
    /// visible before returning. If a record becomes visible sooner, the call returns sooner.
    /// If the wait time expires and no records are visible, the call returns an empty list
    /// of records.
    /// </para><para>
    /// Records are not necessarily received in the order they were written to the data stream.
    /// </para><para>
    /// A queue delivers records while it is in the <c>ACTIVE</c> state.
    /// </para><para>
    /// On rare occasions, a queue can deliver a record more than once. Design your queue
    /// consumer to be idempotent, so that processing the same record more than once is safe.
    /// </para>
    /// </summary>
    [Cmdlet("Receive", "KINQueueRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.QueueRecord")]
    [AWSCmdlet("Calls the Amazon Kinesis ReceiveQueueRecords API operation.", Operation = new[] {"ReceiveQueueRecords"}, SelectReturnType = typeof(Amazon.Kinesis.Model.ReceiveQueueRecordsResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.QueueRecord or Amazon.Kinesis.Model.ReceiveQueueRecordsResponse",
        "This cmdlet returns a collection of Amazon.Kinesis.Model.QueueRecord objects.",
        "The service call response (type Amazon.Kinesis.Model.ReceiveQueueRecordsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ReceiveKINQueueRecordCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter QueueARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the queue to receive records from.</para>
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
        public System.String QueueARN { get; set; }
        #endregion
        
        #region Parameter VisibilityTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds, that the records returned by this request are in flight
        /// and not visible to any consumer instance. If you do not specify this value, the queue's
        /// visibility timeout is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisibilityTimeoutSeconds")]
        public System.Int32? VisibilityTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter WaitTimeSecond
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds, that the call waits for a record to become visible before
        /// returning. The default is 9.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WaitTimeSeconds")]
        public System.Int32? WaitTimeSecond { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to return. The queue never returns more records than
        /// this value, and might return fewer. The default is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'QueueRecords'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.ReceiveQueueRecordsResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.ReceiveQueueRecordsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "QueueRecords";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QueueARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Receive-KINQueueRecord (ReceiveQueueRecords)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.ReceiveQueueRecordsResponse, ReceiveKINQueueRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Limit = this.Limit;
            context.QueueARN = this.QueueARN;
            #if MODULAR
            if (this.QueueARN == null && ParameterWasBound(nameof(this.QueueARN)))
            {
                WriteWarning("You are passing $null as a value for parameter QueueARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VisibilityTimeoutSecond = this.VisibilityTimeoutSecond;
            context.WaitTimeSecond = this.WaitTimeSecond;
            
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
            var request = new Amazon.Kinesis.Model.ReceiveQueueRecordsRequest();
            
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.QueueARN != null)
            {
                request.QueueARN = cmdletContext.QueueARN;
            }
            if (cmdletContext.VisibilityTimeoutSecond != null)
            {
                request.VisibilityTimeoutSeconds = cmdletContext.VisibilityTimeoutSecond.Value;
            }
            if (cmdletContext.WaitTimeSecond != null)
            {
                request.WaitTimeSeconds = cmdletContext.WaitTimeSecond.Value;
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
        
        private Amazon.Kinesis.Model.ReceiveQueueRecordsResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.ReceiveQueueRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "ReceiveQueueRecords");
            try
            {
                return client.ReceiveQueueRecordsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? Limit { get; set; }
            public System.String QueueARN { get; set; }
            public System.Int32? VisibilityTimeoutSecond { get; set; }
            public System.Int32? WaitTimeSecond { get; set; }
            public System.Func<Amazon.Kinesis.Model.ReceiveQueueRecordsResponse, ReceiveKINQueueRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QueueRecords;
        }
        
    }
}
