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
    /// Updates the configuration attributes of the specified queue. You can change the queue's
    /// visibility timeout, its dead-letter handling configuration, or both.
    /// 
    ///  
    /// <para>
    /// A new visibility timeout applies to records received after the update completes. Records
    /// that are already in flight keep the visibility timeout they were received with. To
    /// change the visibility timeout of a record that is already in flight, use <a>UpdateQueueRecordsVisibility</a>.
    /// </para><para><c>UpdateQueue</c> is an asynchronous operation. Upon receiving an <c>UpdateQueue</c>
    /// request, Amazon Kinesis Data Streams sets the <c>QueueStatus</c> to <c>UPDATING</c>,
    /// and sets it back to <c>ACTIVE</c> when the update is complete. You can continue to
    /// receive and acknowledge records while the queue is <c>UPDATING</c>.
    /// </para><para>
    /// You can't change the data stream or the starting position of a queue after you create
    /// it. To read from a different stream or position, create a new queue.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KINQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.QueueDescription")]
    [AWSCmdlet("Calls the Amazon Kinesis UpdateQueue API operation.", Operation = new[] {"UpdateQueue"}, SelectReturnType = typeof(Amazon.Kinesis.Model.UpdateQueueResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.QueueDescription or Amazon.Kinesis.Model.UpdateQueueResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.QueueDescription object.",
        "The service call response (type Amazon.Kinesis.Model.UpdateQueueResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateKINQueueCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter QueueAttributes_DeadLetterConfiguration_MaxReceiveCount
        /// <summary>
        /// <para>
        /// <para>The number of times a record can be received without being acknowledged before it
        /// becomes a dead-letter record. Required when <c>TargetType</c> is <c>BUILT_IN</c>.
        /// A queue that you create without <c>DeadLetterConfiguration</c> gets a <c>MaxReceiveCount</c>
        /// of 6.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? QueueAttributes_DeadLetterConfiguration_MaxReceiveCount { get; set; }
        #endregion
        
        #region Parameter QueueARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the queue to update.</para>
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
        
        #region Parameter QueueAttributes_DeadLetterConfiguration_TargetType
        /// <summary>
        /// <para>
        /// <para>Whether dead-letter handling is enabled for the queue. <c>BUILT_IN</c> enables it:
        /// when a record has been received <c>MaxReceiveCount</c> times without being acknowledged,
        /// it becomes a dead-letter record and <a>ReceiveQueueRecords</a> no longer returns it.
        /// <c>NONE</c> disables it, and an unacknowledged record continues to be redelivered
        /// until it is acknowledged or its retention period ends.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kinesis.TargetType")]
        public Amazon.Kinesis.TargetType QueueAttributes_DeadLetterConfiguration_TargetType { get; set; }
        #endregion
        
        #region Parameter QueueAttributes_VisibilityTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds, that a record is in flight and not visible to any consumer
        /// instance after it is received. A record that is not acknowledged before this duration
        /// elapses becomes visible in the queue again and can be received by any consumer instance.
        /// If you omit this attribute when you create a queue, the queue uses 30 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueueAttributes_VisibilityTimeoutSeconds")]
        public System.Int32? QueueAttributes_VisibilityTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'QueueDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.UpdateQueueResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.UpdateQueueResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "QueueDescription";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KINQueue (UpdateQueue)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.UpdateQueueResponse, UpdateKINQueueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.QueueARN = this.QueueARN;
            #if MODULAR
            if (this.QueueARN == null && ParameterWasBound(nameof(this.QueueARN)))
            {
                WriteWarning("You are passing $null as a value for parameter QueueARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueueAttributes_DeadLetterConfiguration_MaxReceiveCount = this.QueueAttributes_DeadLetterConfiguration_MaxReceiveCount;
            context.QueueAttributes_DeadLetterConfiguration_TargetType = this.QueueAttributes_DeadLetterConfiguration_TargetType;
            context.QueueAttributes_VisibilityTimeoutSecond = this.QueueAttributes_VisibilityTimeoutSecond;
            
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
            var request = new Amazon.Kinesis.Model.UpdateQueueRequest();
            
            if (cmdletContext.QueueARN != null)
            {
                request.QueueARN = cmdletContext.QueueARN;
            }
            
             // populate QueueAttributes
            var requestQueueAttributesIsNull = true;
            request.QueueAttributes = new Amazon.Kinesis.Model.QueueAttributes();
            System.Int32? requestQueueAttributes_queueAttributes_VisibilityTimeoutSecond = null;
            if (cmdletContext.QueueAttributes_VisibilityTimeoutSecond != null)
            {
                requestQueueAttributes_queueAttributes_VisibilityTimeoutSecond = cmdletContext.QueueAttributes_VisibilityTimeoutSecond.Value;
            }
            if (requestQueueAttributes_queueAttributes_VisibilityTimeoutSecond != null)
            {
                request.QueueAttributes.VisibilityTimeoutSeconds = requestQueueAttributes_queueAttributes_VisibilityTimeoutSecond.Value;
                requestQueueAttributesIsNull = false;
            }
            Amazon.Kinesis.Model.DeadLetterConfiguration requestQueueAttributes_queueAttributes_DeadLetterConfiguration = null;
            
             // populate DeadLetterConfiguration
            var requestQueueAttributes_queueAttributes_DeadLetterConfigurationIsNull = true;
            requestQueueAttributes_queueAttributes_DeadLetterConfiguration = new Amazon.Kinesis.Model.DeadLetterConfiguration();
            System.Int32? requestQueueAttributes_queueAttributes_DeadLetterConfiguration_queueAttributes_DeadLetterConfiguration_MaxReceiveCount = null;
            if (cmdletContext.QueueAttributes_DeadLetterConfiguration_MaxReceiveCount != null)
            {
                requestQueueAttributes_queueAttributes_DeadLetterConfiguration_queueAttributes_DeadLetterConfiguration_MaxReceiveCount = cmdletContext.QueueAttributes_DeadLetterConfiguration_MaxReceiveCount.Value;
            }
            if (requestQueueAttributes_queueAttributes_DeadLetterConfiguration_queueAttributes_DeadLetterConfiguration_MaxReceiveCount != null)
            {
                requestQueueAttributes_queueAttributes_DeadLetterConfiguration.MaxReceiveCount = requestQueueAttributes_queueAttributes_DeadLetterConfiguration_queueAttributes_DeadLetterConfiguration_MaxReceiveCount.Value;
                requestQueueAttributes_queueAttributes_DeadLetterConfigurationIsNull = false;
            }
            Amazon.Kinesis.TargetType requestQueueAttributes_queueAttributes_DeadLetterConfiguration_queueAttributes_DeadLetterConfiguration_TargetType = null;
            if (cmdletContext.QueueAttributes_DeadLetterConfiguration_TargetType != null)
            {
                requestQueueAttributes_queueAttributes_DeadLetterConfiguration_queueAttributes_DeadLetterConfiguration_TargetType = cmdletContext.QueueAttributes_DeadLetterConfiguration_TargetType;
            }
            if (requestQueueAttributes_queueAttributes_DeadLetterConfiguration_queueAttributes_DeadLetterConfiguration_TargetType != null)
            {
                requestQueueAttributes_queueAttributes_DeadLetterConfiguration.TargetType = requestQueueAttributes_queueAttributes_DeadLetterConfiguration_queueAttributes_DeadLetterConfiguration_TargetType;
                requestQueueAttributes_queueAttributes_DeadLetterConfigurationIsNull = false;
            }
             // determine if requestQueueAttributes_queueAttributes_DeadLetterConfiguration should be set to null
            if (requestQueueAttributes_queueAttributes_DeadLetterConfigurationIsNull)
            {
                requestQueueAttributes_queueAttributes_DeadLetterConfiguration = null;
            }
            if (requestQueueAttributes_queueAttributes_DeadLetterConfiguration != null)
            {
                request.QueueAttributes.DeadLetterConfiguration = requestQueueAttributes_queueAttributes_DeadLetterConfiguration;
                requestQueueAttributesIsNull = false;
            }
             // determine if request.QueueAttributes should be set to null
            if (requestQueueAttributesIsNull)
            {
                request.QueueAttributes = null;
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
        
        private Amazon.Kinesis.Model.UpdateQueueResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.UpdateQueueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "UpdateQueue");
            try
            {
                return client.UpdateQueueAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String QueueARN { get; set; }
            public System.Int32? QueueAttributes_DeadLetterConfiguration_MaxReceiveCount { get; set; }
            public Amazon.Kinesis.TargetType QueueAttributes_DeadLetterConfiguration_TargetType { get; set; }
            public System.Int32? QueueAttributes_VisibilityTimeoutSecond { get; set; }
            public System.Func<Amazon.Kinesis.Model.UpdateQueueResponse, UpdateKINQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QueueDescription;
        }
        
    }
}
