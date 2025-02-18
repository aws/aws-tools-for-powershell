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
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Amazon.PowerShell.Cmdlets.SQS
{
    /// <summary>
    /// Returns a list of your queues that have the <c>RedrivePolicy</c> queue attribute configured
    /// with a dead-letter queue.
    /// 
    ///  
    /// <para>
    ///  The <c>ListDeadLetterSourceQueues</c> methods supports pagination. Set parameter
    /// <c>MaxResults</c> in the request to specify the maximum number of results to be returned
    /// in the response. If you do not set <c>MaxResults</c>, the response includes a maximum
    /// of 1,000 results. If you set <c>MaxResults</c> and there are additional results to
    /// display, the response includes a value for <c>NextToken</c>. Use <c>NextToken</c>
    /// as a parameter in your next request to <c>ListDeadLetterSourceQueues</c> to receive
    /// the next page of results. 
    /// </para><para>
    /// For more information about using dead-letter queues, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-dead-letter-queues.html">Using
    /// Amazon SQS Dead-Letter Queues</a> in the <i>Amazon SQS Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SQSDeadLetterSourceQueue")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service (SQS) ListDeadLetterSourceQueues API operation.", Operation = new[] {"ListDeadLetterSourceQueues"}, SelectReturnType = typeof(Amazon.SQS.Model.ListDeadLetterSourceQueuesResponse), LegacyAlias="Get-SQSDeadLetterSourceQueues")]
    [AWSCmdletOutput("System.String or Amazon.SQS.Model.ListDeadLetterSourceQueuesResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.SQS.Model.ListDeadLetterSourceQueuesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSQSDeadLetterSourceQueueCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of a dead-letter queue.</para><para>Queue URLs and names are case-sensitive.</para>
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
        public System.String QueueUrl { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of results to include in the response. Value range is 1 to 1000. You
        /// must set <c>MaxResults</c> to receive a value for <c>NextToken</c> in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Pagination token to request the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'QueueUrls'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SQS.Model.ListDeadLetterSourceQueuesResponse).
        /// Specifying the name of a property of type Amazon.SQS.Model.ListDeadLetterSourceQueuesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "QueueUrls";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SQS.Model.ListDeadLetterSourceQueuesResponse, GetSQSDeadLetterSourceQueueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.QueueUrl = this.QueueUrl;
            #if MODULAR
            if (this.QueueUrl == null && ParameterWasBound(nameof(this.QueueUrl)))
            {
                WriteWarning("You are passing $null as a value for parameter QueueUrl which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SQS.Model.ListDeadLetterSourceQueuesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.QueueUrl != null)
            {
                request.QueueUrl = cmdletContext.QueueUrl;
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
        
        private Amazon.SQS.Model.ListDeadLetterSourceQueuesResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.ListDeadLetterSourceQueuesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service (SQS)", "ListDeadLetterSourceQueues");
            try
            {
                return client.ListDeadLetterSourceQueuesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String QueueUrl { get; set; }
            public System.Func<Amazon.SQS.Model.ListDeadLetterSourceQueuesResponse, GetSQSDeadLetterSourceQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QueueUrls;
        }
        
    }
}
