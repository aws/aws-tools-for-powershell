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
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Amazon.PowerShell.Cmdlets.SQS
{
    /// <summary>
    /// Returns a list of your queues in the current region. The response includes a maximum
    /// of 1,000 results. If you specify a value for the optional <c>QueueNamePrefix</c> parameter,
    /// only queues with a name that begins with the specified value are returned.
    /// 
    ///  
    /// <para>
    ///  The <c>listQueues</c> methods supports pagination. Set parameter <c>MaxResults</c>
    /// in the request to specify the maximum number of results to be returned in the response.
    /// If you do not set <c>MaxResults</c>, the response includes a maximum of 1,000 results.
    /// If you set <c>MaxResults</c> and there are additional results to display, the response
    /// includes a value for <c>NextToken</c>. Use <c>NextToken</c> as a parameter in your
    /// next request to <c>listQueues</c> to receive the next page of results. 
    /// </para><note><para>
    /// Cross-account permissions don't apply to this action. For more information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-customer-managed-policy-examples.html#grant-cross-account-permissions-to-role-and-user-name">Grant
    /// cross-account permissions to a role and a username</a> in the <i>Amazon SQS Developer
    /// Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "SQSQueue")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service (SQS) ListQueues API operation.", Operation = new[] {"ListQueues"}, SelectReturnType = typeof(Amazon.SQS.Model.ListQueuesResponse))]
    [AWSCmdletOutput("System.String or Amazon.SQS.Model.ListQueuesResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.SQS.Model.ListQueuesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSQSQueueCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter QueueNamePrefix
        /// <summary>
        /// <para>
        /// <para>A string to use for filtering the list results. Only those queues whose name begins
        /// with the specified string are returned.</para><para>Queue URLs and names are case-sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String QueueNamePrefix { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SQS.Model.ListQueuesResponse).
        /// Specifying the name of a property of type Amazon.SQS.Model.ListQueuesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "QueueUrls";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the QueueNamePrefix parameter.
        /// The -PassThru parameter is deprecated, use -Select '^QueueNamePrefix' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^QueueNamePrefix' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SQS.Model.ListQueuesResponse, GetSQSQueueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.QueueNamePrefix;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.QueueNamePrefix = this.QueueNamePrefix;
            
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
            var request = new Amazon.SQS.Model.ListQueuesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.QueueNamePrefix != null)
            {
                request.QueueNamePrefix = cmdletContext.QueueNamePrefix;
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
        
        private Amazon.SQS.Model.ListQueuesResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.ListQueuesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service (SQS)", "ListQueues");
            try
            {
                #if DESKTOP
                return client.ListQueues(request);
                #elif CORECLR
                return client.ListQueuesAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.String QueueNamePrefix { get; set; }
            public System.Func<Amazon.SQS.Model.ListQueuesResponse, GetSQSQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QueueUrls;
        }
        
    }
}
