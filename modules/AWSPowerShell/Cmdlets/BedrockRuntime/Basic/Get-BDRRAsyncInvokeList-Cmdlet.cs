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
using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDRR
{
    /// <summary>
    /// Lists asynchronous invocations.
    /// </summary>
    [Cmdlet("Get", "BDRRAsyncInvokeList")]
    [OutputType("Amazon.BedrockRuntime.Model.AsyncInvokeSummary")]
    [AWSCmdlet("Calls the Amazon Bedrock Runtime ListAsyncInvokes API operation.", Operation = new[] {"ListAsyncInvokes"}, SelectReturnType = typeof(Amazon.BedrockRuntime.Model.ListAsyncInvokesResponse))]
    [AWSCmdletOutput("Amazon.BedrockRuntime.Model.AsyncInvokeSummary or Amazon.BedrockRuntime.Model.ListAsyncInvokesResponse",
        "This cmdlet returns a collection of Amazon.BedrockRuntime.Model.AsyncInvokeSummary objects.",
        "The service call response (type Amazon.BedrockRuntime.Model.ListAsyncInvokesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBDRRAsyncInvokeListCmdlet : AmazonBedrockRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>How to sort the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockRuntime.SortAsyncInvocationBy")]
        public Amazon.BedrockRuntime.SortAsyncInvocationBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The sorting order for the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockRuntime.SortOrder")]
        public Amazon.BedrockRuntime.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter StatusEqual
        /// <summary>
        /// <para>
        /// <para>Filter invocations by status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StatusEquals")]
        [AWSConstantClassSource("Amazon.BedrockRuntime.AsyncInvokeStatus")]
        public Amazon.BedrockRuntime.AsyncInvokeStatus StatusEqual { get; set; }
        #endregion
        
        #region Parameter SubmitTimeAfter
        /// <summary>
        /// <para>
        /// <para>Include invocations submitted after this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? SubmitTimeAfter { get; set; }
        #endregion
        
        #region Parameter SubmitTimeBefore
        /// <summary>
        /// <para>
        /// <para>Include invocations submitted before this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? SubmitTimeBefore { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of invocations to return in one page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Specify the pagination token from a previous request to retrieve the next page of
        /// results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AsyncInvokeSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockRuntime.Model.ListAsyncInvokesResponse).
        /// Specifying the name of a property of type Amazon.BedrockRuntime.Model.ListAsyncInvokesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AsyncInvokeSummaries";
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
                context.Select = CreateSelectDelegate<Amazon.BedrockRuntime.Model.ListAsyncInvokesResponse, GetBDRRAsyncInvokeListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            context.StatusEqual = this.StatusEqual;
            context.SubmitTimeAfter = this.SubmitTimeAfter;
            context.SubmitTimeBefore = this.SubmitTimeBefore;
            
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
            var request = new Amazon.BedrockRuntime.Model.ListAsyncInvokesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            if (cmdletContext.StatusEqual != null)
            {
                request.StatusEquals = cmdletContext.StatusEqual;
            }
            if (cmdletContext.SubmitTimeAfter != null)
            {
                request.SubmitTimeAfter = cmdletContext.SubmitTimeAfter.Value;
            }
            if (cmdletContext.SubmitTimeBefore != null)
            {
                request.SubmitTimeBefore = cmdletContext.SubmitTimeBefore.Value;
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
        
        private Amazon.BedrockRuntime.Model.ListAsyncInvokesResponse CallAWSServiceOperation(IAmazonBedrockRuntime client, Amazon.BedrockRuntime.Model.ListAsyncInvokesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Runtime", "ListAsyncInvokes");
            try
            {
                return client.ListAsyncInvokesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.BedrockRuntime.SortAsyncInvocationBy SortBy { get; set; }
            public Amazon.BedrockRuntime.SortOrder SortOrder { get; set; }
            public Amazon.BedrockRuntime.AsyncInvokeStatus StatusEqual { get; set; }
            public System.DateTime? SubmitTimeAfter { get; set; }
            public System.DateTime? SubmitTimeBefore { get; set; }
            public System.Func<Amazon.BedrockRuntime.Model.ListAsyncInvokesResponse, GetBDRRAsyncInvokeListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AsyncInvokeSummaries;
        }
        
    }
}
