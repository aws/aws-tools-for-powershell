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
    /// Updates the record distribution strategy for the specified Amazon Kinesis Data Streams
    /// on-demand data stream. The record distribution strategy determines how Amazon Kinesis
    /// Data Streams distributes records across the shards in a stream.
    /// 
    ///  <note><para>
    /// You must specify the stream using the <c>StreamARN</c> parameter.
    /// </para></note><para>
    /// The record distribution strategy is a stream-level setting. You can switch between
    /// the following strategies at any time, and the change takes effect immediately without
    /// downtime, data loss, or disruption to producer or consumer applications:
    /// </para><ul><li><para><c>AUTO</c> – Amazon Kinesis Data Streams distributes records evenly across shards
    /// using service-managed algorithms, and ignores any partition key and <c>ExplicitHashKey</c>
    /// that a producer provides. Use this strategy for stateless workloads that do not require
    /// partition-key ordering.
    /// </para></li><li><para><c>USER_PARTITION_KEY</c> – Producers must provide a partition key, and Amazon Kinesis
    /// Data Streams uses the partition key to determine shard placement. Records that share
    /// a partition key are sent to the same shard. This is the default strategy.
    /// </para></li></ul><para>
    /// This operation is only supported for data streams that use the on-demand capacity
    /// mode. Provisioned capacity mode streams do not support the record distribution strategy
    /// setting. Attempting to set <c>AUTO</c> on a provisioned stream results in an <c>InvalidArgumentException</c>.
    /// </para><para>
    /// New records that arrive after the change are distributed according to the new strategy.
    /// Records already in the stream keep their original shard assignments and are not redistributed.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KINStreamRecordDistributionStrategy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis UpdateStreamRecordDistributionStrategy API operation.", Operation = new[] {"UpdateStreamRecordDistributionStrategy"}, SelectReturnType = typeof(Amazon.Kinesis.Model.UpdateStreamRecordDistributionStrategyResponse))]
    [AWSCmdletOutput("None or Amazon.Kinesis.Model.UpdateStreamRecordDistributionStrategyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Kinesis.Model.UpdateStreamRecordDistributionStrategyResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateKINStreamRecordDistributionStrategyCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RecordDistributionStrategy
        /// <summary>
        /// <para>
        /// <para>The record distribution strategy to apply to the stream. Specify one of the following
        /// values:</para><ul><li><para><c>AUTO</c> – Amazon Kinesis Data Streams distributes records evenly across shards
        /// and ignores any partition key and <c>ExplicitHashKey</c> that producers supply.</para></li><li><para><c>USER_PARTITION_KEY</c> – Producers must supply a partition key, which Amazon Kinesis
        /// Data Streams uses to determine shard placement. This is the default.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Kinesis.RecordDistributionStrategy")]
        public Amazon.Kinesis.RecordDistributionStrategy RecordDistributionStrategy { get; set; }
        #endregion
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the stream to update.</para>
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
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamId
        /// <summary>
        /// <para>
        /// <para>Not Implemented. Reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.UpdateStreamRecordDistributionStrategyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StreamARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KINStreamRecordDistributionStrategy (UpdateStreamRecordDistributionStrategy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.UpdateStreamRecordDistributionStrategyResponse, UpdateKINStreamRecordDistributionStrategyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RecordDistributionStrategy = this.RecordDistributionStrategy;
            #if MODULAR
            if (this.RecordDistributionStrategy == null && ParameterWasBound(nameof(this.RecordDistributionStrategy)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordDistributionStrategy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamARN = this.StreamARN;
            #if MODULAR
            if (this.StreamARN == null && ParameterWasBound(nameof(this.StreamARN)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamId = this.StreamId;
            
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
            var request = new Amazon.Kinesis.Model.UpdateStreamRecordDistributionStrategyRequest();
            
            if (cmdletContext.RecordDistributionStrategy != null)
            {
                request.RecordDistributionStrategy = cmdletContext.RecordDistributionStrategy;
            }
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            if (cmdletContext.StreamId != null)
            {
                request.StreamId = cmdletContext.StreamId;
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
        
        private Amazon.Kinesis.Model.UpdateStreamRecordDistributionStrategyResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.UpdateStreamRecordDistributionStrategyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "UpdateStreamRecordDistributionStrategy");
            try
            {
                return client.UpdateStreamRecordDistributionStrategyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Kinesis.RecordDistributionStrategy RecordDistributionStrategy { get; set; }
            public System.String StreamARN { get; set; }
            public System.String StreamId { get; set; }
            public System.Func<Amazon.Kinesis.Model.UpdateStreamRecordDistributionStrategyResponse, UpdateKINStreamRecordDistributionStrategyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
