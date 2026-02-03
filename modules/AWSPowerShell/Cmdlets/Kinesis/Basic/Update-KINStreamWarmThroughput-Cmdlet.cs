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
    /// Updates the warm throughput configuration for the specified Amazon Kinesis Data Streams
    /// on-demand data stream. This operation allows you to proactively scale your on-demand
    /// data stream to a specified throughput level, enabling better performance for sudden
    /// traffic spikes. 
    /// 
    ///  <note><para>
    /// When invoking this API, you must use either the <c>StreamARN</c> or the <c>StreamName</c>
    /// parameter, or both. It is recommended that you use the <c>StreamARN</c> input parameter
    /// when you invoke this API.
    /// </para></note><para>
    /// Updating the warm throughput is an asynchronous operation. Upon receiving the request,
    /// Kinesis Data Streams returns immediately and sets the status of the stream to <c>UPDATING</c>.
    /// After the update is complete, Kinesis Data Streams sets the status of the stream back
    /// to <c>ACTIVE</c>. Depending on the size of the stream, the scaling action could take
    /// a few minutes to complete. You can continue to read and write data to your stream
    /// while its status is <c>UPDATING</c>.
    /// </para><para>
    /// This operation is only supported for data streams with the on-demand capacity mode
    /// in accounts that have <c>MinimumThroughputBillingCommitment</c> enabled. Provisioned
    /// capacity mode streams do not support warm throughput configuration.
    /// </para><para>
    /// This operation has the following default limits. By default, you cannot do the following:
    /// </para><ul><li><para>
    /// Scale to more than 10 GiBps for an on-demand stream.
    /// </para></li><li><para>
    /// This API has a call limit of 5 transactions per second (TPS) for each Amazon Web Services
    /// account. TPS over 5 will initiate the <c>LimitExceededException</c>.
    /// </para></li></ul><para>
    /// For the default limits for an Amazon Web Services account, see <a href="https://docs.aws.amazon.com/kinesis/latest/dev/service-sizes-and-limits.html">Streams
    /// Limits</a> in the <i>Amazon Kinesis Data Streams Developer Guide</i>. To request an
    /// increase in the call rate limit, the shard limit for this API, or your overall shard
    /// limit, use the <a href="https://console.aws.amazon.com/support/v1#/case/create?issueType=service-limit-increase&amp;limitType=service-code-kinesis">limits
    /// form</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KINStreamWarmThroughput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.UpdateStreamWarmThroughputResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis UpdateStreamWarmThroughput API operation.", Operation = new[] {"UpdateStreamWarmThroughput"}, SelectReturnType = typeof(Amazon.Kinesis.Model.UpdateStreamWarmThroughputResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.UpdateStreamWarmThroughputResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.UpdateStreamWarmThroughputResponse object containing multiple properties."
    )]
    public partial class UpdateKINStreamWarmThroughputCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the stream to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter WarmThroughputMiBp
        /// <summary>
        /// <para>
        /// <para>The target warm throughput in MB/s that the stream should be scaled to handle. This
        /// represents the throughput capacity that will be immediately available for write operations.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("WarmThroughputMiBps")]
        public System.Int32? WarmThroughputMiBp { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.UpdateStreamWarmThroughputResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.UpdateStreamWarmThroughputResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WarmThroughputMiBp), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KINStreamWarmThroughput (UpdateStreamWarmThroughput)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.UpdateStreamWarmThroughputResponse, UpdateKINStreamWarmThroughputCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.StreamARN = this.StreamARN;
            context.StreamId = this.StreamId;
            context.StreamName = this.StreamName;
            context.WarmThroughputMiBp = this.WarmThroughputMiBp;
            #if MODULAR
            if (this.WarmThroughputMiBp == null && ParameterWasBound(nameof(this.WarmThroughputMiBp)))
            {
                WriteWarning("You are passing $null as a value for parameter WarmThroughputMiBp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Kinesis.Model.UpdateStreamWarmThroughputRequest();
            
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            if (cmdletContext.StreamId != null)
            {
                request.StreamId = cmdletContext.StreamId;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
            }
            if (cmdletContext.WarmThroughputMiBp != null)
            {
                request.WarmThroughputMiBps = cmdletContext.WarmThroughputMiBp.Value;
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
        
        private Amazon.Kinesis.Model.UpdateStreamWarmThroughputResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.UpdateStreamWarmThroughputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "UpdateStreamWarmThroughput");
            try
            {
                return client.UpdateStreamWarmThroughputAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String StreamARN { get; set; }
            public System.String StreamId { get; set; }
            public System.String StreamName { get; set; }
            public System.Int32? WarmThroughputMiBp { get; set; }
            public System.Func<Amazon.Kinesis.Model.UpdateStreamWarmThroughputResponse, UpdateKINStreamWarmThroughputCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
