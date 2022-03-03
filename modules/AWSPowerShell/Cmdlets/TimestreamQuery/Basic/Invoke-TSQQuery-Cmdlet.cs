/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.TimestreamQuery;
using Amazon.TimestreamQuery.Model;

namespace Amazon.PowerShell.Cmdlets.TSQ
{
    /// <summary>
    /// <code>Query</code> is a synchronous operation that enables you to run a query against
    /// your Amazon Timestream data. <code>Query</code> will time out after 60 seconds. You
    /// must update the default timeout in the SDK to support a timeout of 60 seconds. See
    /// the <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/code-samples.run-query.html">code
    /// sample</a> for details. 
    /// 
    ///  
    /// <para>
    /// Your query request will fail in the following cases:
    /// </para><ul><li><para>
    ///  If you submit a <code>Query</code> request with the same client token outside of
    /// the 5-minute idempotency window. 
    /// </para></li><li><para>
    ///  If you submit a <code>Query</code> request with the same client token, but change
    /// other parameters, within the 5-minute idempotency window. 
    /// </para></li><li><para>
    ///  If the size of the row (including the query metadata) exceeds 1 MB, then the query
    /// will fail with the following error message: 
    /// </para><para><code>Query aborted as max page response size has been exceeded by the output result
    /// row</code></para></li><li><para>
    ///  If the IAM principal of the query initiator and the result reader are not the same
    /// and/or the query initiator and the result reader do not have the same query string
    /// in the query requests, the query will fail with an <code>Invalid pagination token</code>
    /// error. 
    /// </para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Invoke", "TSQQuery")]
    [OutputType("Amazon.TimestreamQuery.Model.Row")]
    [AWSCmdlet("Calls the Amazon Timestream Query Query API operation.", Operation = new[] {"Query"}, SelectReturnType = typeof(Amazon.TimestreamQuery.Model.QueryResponse))]
    [AWSCmdletOutput("Amazon.TimestreamQuery.Model.Row or Amazon.TimestreamQuery.Model.QueryResponse",
        "This cmdlet returns a collection of Amazon.TimestreamQuery.Model.Row objects.",
        "The service call response (type Amazon.TimestreamQuery.Model.QueryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeTSQQueryCmdlet : AmazonTimestreamQueryClientCmdlet, IExecutor
    {
        
        #region Parameter MaxRow
        /// <summary>
        /// <para>
        /// <para> The total number of rows to be returned in the <code>Query</code> output. The initial
        /// run of <code>Query</code> with a <code>MaxRows</code> value specified will return
        /// the result set of the query in two cases: </para><ul><li><para>The size of the result is less than <code>1MB</code>.</para></li><li><para>The number of rows in the result set is less than the value of <code>maxRows</code>.</para></li></ul><para>Otherwise, the initial invocation of <code>Query</code> only returns a <code>NextToken</code>,
        /// which can then be used in subsequent calls to fetch the result set. To resume pagination,
        /// provide the <code>NextToken</code> value in the subsequent command.</para><para>If the row size is large (e.g. a row has many columns), Timestream may return fewer
        /// rows to keep the response size from exceeding the 1 MB limit. If <code>MaxRows</code>
        /// is not provided, Timestream will send the necessary number of rows to meet the 1 MB
        /// limit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRows")]
        public System.Int32? MaxRow { get; set; }
        #endregion
        
        #region Parameter QueryString
        /// <summary>
        /// <para>
        /// <para> The query to be run by Timestream. </para>
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
        public System.String QueryString { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> Unique, case-sensitive string of up to 64 ASCII characters specified when a <code>Query</code>
        /// request is made. Providing a <code>ClientToken</code> makes the call to <code>Query</code><i>idempotent</i>. This means that running the same query repeatedly will produce
        /// the same result. In other words, making multiple identical <code>Query</code> requests
        /// has the same effect as making a single request. When using <code>ClientToken</code>
        /// in a query, note the following: </para><ul><li><para> If the Query API is instantiated without a <code>ClientToken</code>, the Query SDK
        /// generates a <code>ClientToken</code> on your behalf.</para></li><li><para>If the <code>Query</code> invocation only contains the <code>ClientToken</code> but
        /// does not include a <code>NextToken</code>, that invocation of <code>Query</code> is
        /// assumed to be a new query run.</para></li><li><para>If the invocation contains <code>NextToken</code>, that particular invocation is assumed
        /// to be a subsequent invocation of a prior call to the Query API, and a result set is
        /// returned.</para></li><li><para> After 4 hours, any request with the same <code>ClientToken</code> is treated as a
        /// new request. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> A pagination token used to return a set of results. When the <code>Query</code> API
        /// is invoked using <code>NextToken</code>, that particular invocation is assumed to
        /// be a subsequent invocation of a prior call to <code>Query</code>, and a result set
        /// is returned. However, if the <code>Query</code> invocation only contains the <code>ClientToken</code>,
        /// that invocation of <code>Query</code> is assumed to be a new query run. </para><para>Note the following when using NextToken in a query:</para><ul><li><para>A pagination token can be used for up to five <code>Query</code> invocations, OR for
        /// a duration of up to 1 hour – whichever comes first.</para></li><li><para>Using the same <code>NextToken</code> will return the same set of records. To keep
        /// paginating through the result set, you must to use the most recent <code>nextToken</code>.</para></li><li><para>Suppose a <code>Query</code> invocation returns two <code>NextToken</code> values,
        /// <code>TokenA</code> and <code>TokenB</code>. If <code>TokenB</code> is used in a subsequent
        /// <code>Query</code> invocation, then <code>TokenA</code> is invalidated and cannot
        /// be reused.</para></li><li><para>To request a previous result set from a query after pagination has begun, you must
        /// re-invoke the Query API.</para></li><li><para>The latest <code>NextToken</code> should be used to paginate until <code>null</code>
        /// is returned, at which point a new <code>NextToken</code> should be used.</para></li><li><para> If the IAM principal of the query initiator and the result reader are not the same
        /// and/or the query initiator and the result reader do not have the same query string
        /// in the query requests, the query will fail with an <code>Invalid pagination token</code>
        /// error. </para></li></ul>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Rows'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamQuery.Model.QueryResponse).
        /// Specifying the name of a property of type Amazon.TimestreamQuery.Model.QueryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Rows";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the QueryString parameter.
        /// The -PassThru parameter is deprecated, use -Select '^QueryString' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^QueryString' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamQuery.Model.QueryResponse, InvokeTSQQueryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.QueryString;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.MaxRow = this.MaxRow;
            context.NextToken = this.NextToken;
            context.QueryString = this.QueryString;
            #if MODULAR
            if (this.QueryString == null && ParameterWasBound(nameof(this.QueryString)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryString which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.TimestreamQuery.Model.QueryRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.MaxRow != null)
            {
                request.MaxRows = cmdletContext.MaxRow.Value;
            }
            if (cmdletContext.QueryString != null)
            {
                request.QueryString = cmdletContext.QueryString;
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
        
        private Amazon.TimestreamQuery.Model.QueryResponse CallAWSServiceOperation(IAmazonTimestreamQuery client, Amazon.TimestreamQuery.Model.QueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream Query", "Query");
            try
            {
                #if DESKTOP
                return client.Query(request);
                #elif CORECLR
                return client.QueryAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Int32? MaxRow { get; set; }
            public System.String NextToken { get; set; }
            public System.String QueryString { get; set; }
            public System.Func<Amazon.TimestreamQuery.Model.QueryResponse, InvokeTSQQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Rows;
        }
        
    }
}
