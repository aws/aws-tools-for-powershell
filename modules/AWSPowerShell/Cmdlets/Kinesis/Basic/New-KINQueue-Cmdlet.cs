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
    /// Creates a queue on the specified data stream. A queue delivers records from the stream
    /// to a queue consumer, tracks the delivery state of each record, and redelivers any
    /// record that is not acknowledged before its visibility timeout expires.
    /// 
    ///  
    /// <para>
    /// A queue does not extend how long the stream keeps a record. When a record reaches
    /// the end of the data stream's retention period, the queue stops delivering it.
    /// </para><para>
    /// Your queue consumer calls <a>ReceiveQueueRecords</a> to receive up to 10 records at
    /// a time. After it processes records, it calls <a>AcknowledgeQueueRecords</a> so the
    /// queue does not deliver them again.
    /// </para><para>
    /// Queues are supported only on data streams in on-demand capacity mode.
    /// </para><para>
    /// Creating a queue does not change how producers write to the stream, and it does not
    /// change how existing stream consumers read from it. A queue counts as a registered
    /// consumer on the stream and shares the stream's registered consumer limit with enhanced
    /// fan-out consumers: 20 on On-demand Standard and 50 on On-demand Advantage.
    /// </para><para>
    /// Use <c>StartingPosition</c> to set the position in the stream where delivery begins.
    /// The default is <c>LATEST</c>.
    /// </para><para><c>CreateQueue</c> is an asynchronous operation. Upon receiving a <c>CreateQueue</c>
    /// request, Amazon Kinesis Data Streams immediately returns a queue description with
    /// a <c>QueueStatus</c> of <c>CREATING</c>. After the queue is created, Kinesis Data
    /// Streams sets the <c>QueueStatus</c> to <c>ACTIVE</c>. You can begin receiving records
    /// after the queue is <c>ACTIVE</c>. Use <a>DescribeQueue</a> to check the status of
    /// the queue.
    /// </para><para>
    /// Each queue has built-in dead-letter handling. When a record has been received <c>MaxReceiveCount</c>
    /// times without being acknowledged, it becomes a dead-letter record, and <a>ReceiveQueueRecords</a>
    /// no longer returns it. You work with dead-letter records through a separate set of
    /// operations that use the same queue ARN: <a>ReceiveDeadLetterQueueRecords</a>, <a>AcknowledgeDeadLetterQueueRecords</a>,
    /// <a>UpdateDeadLetterQueueRecordsVisibility</a>, and <a>RestoreDeadLetterQueueRecords</a>.
    /// </para><para>
    /// Dead-letter handling is enabled by default, with a <c>MaxReceiveCount</c> of 6. To
    /// use a different value, or to turn dead-letter handling off, specify <c>DeadLetterConfiguration</c>
    /// in <c>QueueAttributes</c>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KINQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.QueueDescription")]
    [AWSCmdlet("Calls the Amazon Kinesis CreateQueue API operation.", Operation = new[] {"CreateQueue"}, SelectReturnType = typeof(Amazon.Kinesis.Model.CreateQueueResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.QueueDescription or Amazon.Kinesis.Model.CreateQueueResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.QueueDescription object.",
        "The service call response (type Amazon.Kinesis.Model.CreateQueueResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewKINQueueCmdlet : AmazonKinesisClientCmdlet, IExecutor
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
        
        #region Parameter QueueName
        /// <summary>
        /// <para>
        /// <para>A name for the queue. The name is scoped to the Amazon Web Services account and Region
        /// used by the request, so two queues in different accounts, or in the same account and
        /// different Regions, can have the same name.</para>
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
        public System.String QueueName { get; set; }
        #endregion
        
        #region Parameter StreamConfigurationList
        /// <summary>
        /// <para>
        /// <para>The data stream the queue delivers records from, and the position in that stream where
        /// delivery begins. The list must contain exactly one entry, because a queue delivers
        /// records from a single data stream.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Kinesis.Model.QueueStreamConfiguration[] StreamConfigurationList { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of up to 50 key-value pairs to apply to the queue. You can also add, change,
        /// and remove tags after the queue is created with <a>TagResource</a> and <a>UntagResource</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.CreateQueueResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.CreateQueueResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QueueName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KINQueue (CreateQueue)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.CreateQueueResponse, NewKINQueueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.QueueAttributes_DeadLetterConfiguration_MaxReceiveCount = this.QueueAttributes_DeadLetterConfiguration_MaxReceiveCount;
            context.QueueAttributes_DeadLetterConfiguration_TargetType = this.QueueAttributes_DeadLetterConfiguration_TargetType;
            context.QueueAttributes_VisibilityTimeoutSecond = this.QueueAttributes_VisibilityTimeoutSecond;
            context.QueueName = this.QueueName;
            #if MODULAR
            if (this.QueueName == null && ParameterWasBound(nameof(this.QueueName)))
            {
                WriteWarning("You are passing $null as a value for parameter QueueName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StreamConfigurationList != null)
            {
                context.StreamConfigurationList = new List<Amazon.Kinesis.Model.QueueStreamConfiguration>(this.StreamConfigurationList);
            }
            #if MODULAR
            if (this.StreamConfigurationList == null && ParameterWasBound(nameof(this.StreamConfigurationList)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamConfigurationList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.Kinesis.Model.CreateQueueRequest();
            
            
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
            if (cmdletContext.QueueName != null)
            {
                request.QueueName = cmdletContext.QueueName;
            }
            if (cmdletContext.StreamConfigurationList != null)
            {
                request.StreamConfigurationList = cmdletContext.StreamConfigurationList;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Kinesis.Model.CreateQueueResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.CreateQueueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "CreateQueue");
            try
            {
                return client.CreateQueueAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? QueueAttributes_DeadLetterConfiguration_MaxReceiveCount { get; set; }
            public Amazon.Kinesis.TargetType QueueAttributes_DeadLetterConfiguration_TargetType { get; set; }
            public System.Int32? QueueAttributes_VisibilityTimeoutSecond { get; set; }
            public System.String QueueName { get; set; }
            public List<Amazon.Kinesis.Model.QueueStreamConfiguration> StreamConfigurationList { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Kinesis.Model.CreateQueueResponse, NewKINQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QueueDescription;
        }
        
    }
}
