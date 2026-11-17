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
    /// Receives up to 10 dead-letter records from the specified queue. Each queue has built-in
    /// dead-letter handling: when a record has been received <c>MaxReceiveCount</c> times
    /// without being acknowledged, it becomes a dead-letter record, which usually means your
    /// queue consumer could not process it. The dead-letter record stays in the same queue,
    /// and <a>ReceiveQueueRecords</a> no longer returns it.
    /// 
    ///  
    /// <para>
    /// Dead-letter records carry the same data and partition key as when they were first
    /// delivered, and are returned with a receipt handle. Use the receipt handle to acknowledge
    /// the record with <a>AcknowledgeDeadLetterQueueRecords</a>, which discards it, to change
    /// its visibility with <a>UpdateDeadLetterQueueRecordsVisibility</a>, or to restore it
    /// with <a>RestoreDeadLetterQueueRecords</a>, which returns it to the normal receive
    /// path so that <a>ReceiveQueueRecords</a> can return it again.
    /// </para><para>
    /// Use this operation to inspect the records your queue consumer could not process, so
    /// you can correct the cause and then either acknowledge or restore them.
    /// </para><para>
    /// A queue delivers dead-letter records while it is in the <c>ACTIVE</c> state.
    /// </para>
    /// </summary>
    [Cmdlet("Receive", "KINDeadLetterQueueRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.QueueRecord")]
    [AWSCmdlet("Calls the Amazon Kinesis ReceiveDeadLetterQueueRecords API operation.", Operation = new[] {"ReceiveDeadLetterQueueRecords"}, SelectReturnType = typeof(Amazon.Kinesis.Model.ReceiveDeadLetterQueueRecordsResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.QueueRecord or Amazon.Kinesis.Model.ReceiveDeadLetterQueueRecordsResponse",
        "This cmdlet returns a collection of Amazon.Kinesis.Model.QueueRecord objects.",
        "The service call response (type Amazon.Kinesis.Model.ReceiveDeadLetterQueueRecordsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ReceiveKINDeadLetterQueueRecordCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter QueueARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the queue whose dead-letter records are received.</para>
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
        /// <para>The maximum number of records to return. The queue never returns more dead-letter
        /// records than this value, and might return fewer. The default is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'QueueRecords'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.ReceiveDeadLetterQueueRecordsResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.ReceiveDeadLetterQueueRecordsResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Receive-KINDeadLetterQueueRecord (ReceiveDeadLetterQueueRecords)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.ReceiveDeadLetterQueueRecordsResponse, ReceiveKINDeadLetterQueueRecordCmdlet>(Select) ??
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
            var request = new Amazon.Kinesis.Model.ReceiveDeadLetterQueueRecordsRequest();
            
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
        
        private Amazon.Kinesis.Model.ReceiveDeadLetterQueueRecordsResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.ReceiveDeadLetterQueueRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "ReceiveDeadLetterQueueRecords");
            try
            {
                return client.ReceiveDeadLetterQueueRecordsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Kinesis.Model.ReceiveDeadLetterQueueRecordsResponse, ReceiveKINDeadLetterQueueRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QueueRecords;
        }
        
    }
}
