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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Lists all batch inference jobs in the account. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/batch-inference-view.html">View
    /// details about a batch inference job</a>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "BDRModelInvocationJobList")]
    [OutputType("Amazon.Bedrock.Model.ModelInvocationJobSummary")]
    [AWSCmdlet("Calls the Amazon Bedrock ListModelInvocationJobs API operation.", Operation = new[] {"ListModelInvocationJobs"}, SelectReturnType = typeof(Amazon.Bedrock.Model.ListModelInvocationJobsResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.ModelInvocationJobSummary or Amazon.Bedrock.Model.ListModelInvocationJobsResponse",
        "This cmdlet returns a collection of Amazon.Bedrock.Model.ModelInvocationJobSummary objects.",
        "The service call response (type Amazon.Bedrock.Model.ListModelInvocationJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBDRModelInvocationJobListCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NameContain
        /// <summary>
        /// <para>
        /// <para>Specify a string to filter for batch inference jobs whose names contain the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NameContains")]
        public System.String NameContain { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>An attribute by which to sort the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Bedrock.SortJobsBy")]
        public Amazon.Bedrock.SortJobsBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>Specifies whether to sort the results by ascending or descending order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Bedrock.SortOrder")]
        public Amazon.Bedrock.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter StatusEqual
        /// <summary>
        /// <para>
        /// <para>Specify a status to filter for batch inference jobs whose statuses match the string
        /// you specify.</para><para>The following statuses are possible:</para><ul><li><para>Submitted – This job has been submitted to a queue for validation.</para></li><li><para>Validating – This job is being validated for the requirements described in <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/batch-inference-data.html">Format
        /// and upload your batch inference data</a>. The criteria include the following:</para><ul><li><para>Your IAM service role has access to the Amazon S3 buckets containing your files.</para></li><li><para>Your files are .jsonl files and each individual record is a JSON object in the correct
        /// format. Note that validation doesn't check if the <c>modelInput</c> value matches
        /// the request body for the model.</para></li><li><para>Your files fulfill the requirements for file size and number of records. For more
        /// information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/quotas.html">Quotas
        /// for Amazon Bedrock</a>.</para></li></ul></li><li><para>Scheduled – This job has been validated and is now in a queue. The job will automatically
        /// start when it reaches its turn.</para></li><li><para>Expired – This job timed out because it was scheduled but didn't begin before the
        /// set timeout duration. Submit a new job request.</para></li><li><para>InProgress – This job has begun. You can start viewing the results in the output S3
        /// location.</para></li><li><para>Completed – This job has successfully completed. View the output files in the output
        /// S3 location.</para></li><li><para>PartiallyCompleted – This job has partially completed. Not all of your records could
        /// be processed in time. View the output files in the output S3 location.</para></li><li><para>Failed – This job has failed. Check the failure message for any further details. For
        /// further assistance, reach out to the <a href="https://console.aws.amazon.com/support/home/">Amazon
        /// Web Services Support Center</a>.</para></li><li><para>Stopped – This job was stopped by a user.</para></li><li><para>Stopping – This job is being stopped by a user.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StatusEquals")]
        [AWSConstantClassSource("Amazon.Bedrock.ModelInvocationJobStatus")]
        public Amazon.Bedrock.ModelInvocationJobStatus StatusEqual { get; set; }
        #endregion
        
        #region Parameter SubmitTimeAfter
        /// <summary>
        /// <para>
        /// <para>Specify a time to filter for batch inference jobs that were submitted after the time
        /// you specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? SubmitTimeAfter { get; set; }
        #endregion
        
        #region Parameter SubmitTimeBefore
        /// <summary>
        /// <para>
        /// <para>Specify a time to filter for batch inference jobs that were submitted before the time
        /// you specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? SubmitTimeBefore { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return. If there are more results than the number
        /// that you specify, a <c>nextToken</c> value is returned. Use the <c>nextToken</c> in
        /// a request to return the next batch of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If there were more results than the value you specified in the <c>maxResults</c> field
        /// in a previous <c>ListModelInvocationJobs</c> request, the response would have returned
        /// a <c>nextToken</c> value. To see the next batch of results, send the <c>nextToken</c>
        /// value in another request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InvocationJobSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.ListModelInvocationJobsResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.ListModelInvocationJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvocationJobSummaries";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.ListModelInvocationJobsResponse, GetBDRModelInvocationJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NameContain = this.NameContain;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Bedrock.Model.ListModelInvocationJobsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NameContain != null)
            {
                request.NameContains = cmdletContext.NameContain;
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
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Bedrock.Model.ListModelInvocationJobsResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.ListModelInvocationJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "ListModelInvocationJobs");
            try
            {
                #if DESKTOP
                return client.ListModelInvocationJobs(request);
                #elif CORECLR
                return client.ListModelInvocationJobsAsync(request).GetAwaiter().GetResult();
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
            public System.String NameContain { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Bedrock.SortJobsBy SortBy { get; set; }
            public Amazon.Bedrock.SortOrder SortOrder { get; set; }
            public Amazon.Bedrock.ModelInvocationJobStatus StatusEqual { get; set; }
            public System.DateTime? SubmitTimeAfter { get; set; }
            public System.DateTime? SubmitTimeBefore { get; set; }
            public System.Func<Amazon.Bedrock.Model.ListModelInvocationJobsResponse, GetBDRModelInvocationJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvocationJobSummaries;
        }
        
    }
}
