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
    /// Restores up to 10 dead-letter records in the specified queue. Restoring a record clears
    /// its dead-letter state and resets its receive count, so <a>ReceiveQueueRecords</a>
    /// can return it again, up to <c>MaxReceiveCount</c> times before it becomes a dead-letter
    /// record again. The result for each entry is reported individually in the response.
    /// 
    ///  
    /// <para>
    /// Restore records after you have corrected the condition that prevented your queue consumer
    /// from processing them.
    /// </para><para>
    /// Because the request can result in a combination of successful and unsuccessful entries,
    /// check the <c>Failed</c> list even when the call returns an HTTP status code of <c>200</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Restore", "KINDeadLetterQueueRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.RestoreDeadLetterQueueRecordsResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis RestoreDeadLetterQueueRecords API operation.", Operation = new[] {"RestoreDeadLetterQueueRecords"}, SelectReturnType = typeof(Amazon.Kinesis.Model.RestoreDeadLetterQueueRecordsResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.RestoreDeadLetterQueueRecordsResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.RestoreDeadLetterQueueRecordsResponse object containing multiple properties."
    )]
    public partial class RestoreKINDeadLetterQueueRecordCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Entry
        /// <summary>
        /// <para>
        /// <para>The dead-letter records to restore, identified by their receipt handles.</para><para />
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
        [Alias("Entries")]
        public Amazon.Kinesis.Model.RestoreDeadLetterQueueRecordsRequestEntry[] Entry { get; set; }
        #endregion
        
        #region Parameter QueueARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the queue whose dead-letter records are restored.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.RestoreDeadLetterQueueRecordsResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.RestoreDeadLetterQueueRecordsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QueueARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-KINDeadLetterQueueRecord (RestoreDeadLetterQueueRecords)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.RestoreDeadLetterQueueRecordsResponse, RestoreKINDeadLetterQueueRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Entry != null)
            {
                context.Entry = new List<Amazon.Kinesis.Model.RestoreDeadLetterQueueRecordsRequestEntry>(this.Entry);
            }
            #if MODULAR
            if (this.Entry == null && ParameterWasBound(nameof(this.Entry)))
            {
                WriteWarning("You are passing $null as a value for parameter Entry which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueueARN = this.QueueARN;
            #if MODULAR
            if (this.QueueARN == null && ParameterWasBound(nameof(this.QueueARN)))
            {
                WriteWarning("You are passing $null as a value for parameter QueueARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Kinesis.Model.RestoreDeadLetterQueueRecordsRequest();
            
            if (cmdletContext.Entry != null)
            {
                request.Entries = cmdletContext.Entry;
            }
            if (cmdletContext.QueueARN != null)
            {
                request.QueueARN = cmdletContext.QueueARN;
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
        
        private Amazon.Kinesis.Model.RestoreDeadLetterQueueRecordsResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.RestoreDeadLetterQueueRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "RestoreDeadLetterQueueRecords");
            try
            {
                return client.RestoreDeadLetterQueueRecordsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Kinesis.Model.RestoreDeadLetterQueueRecordsRequestEntry> Entry { get; set; }
            public System.String QueueARN { get; set; }
            public System.Func<Amazon.Kinesis.Model.RestoreDeadLetterQueueRecordsResponse, RestoreKINDeadLetterQueueRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
