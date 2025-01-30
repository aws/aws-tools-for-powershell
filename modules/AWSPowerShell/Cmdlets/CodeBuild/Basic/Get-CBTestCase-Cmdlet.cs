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
using Amazon.CodeBuild;
using Amazon.CodeBuild.Model;

namespace Amazon.PowerShell.Cmdlets.CB
{
    /// <summary>
    /// Returns a list of details about test cases for a report.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CBTestCase")]
    [OutputType("Amazon.CodeBuild.Model.TestCase")]
    [AWSCmdlet("Calls the AWS CodeBuild DescribeTestCases API operation.", Operation = new[] {"DescribeTestCases"}, SelectReturnType = typeof(Amazon.CodeBuild.Model.DescribeTestCasesResponse))]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.TestCase or Amazon.CodeBuild.Model.DescribeTestCasesResponse",
        "This cmdlet returns a collection of Amazon.CodeBuild.Model.TestCase objects.",
        "The service call response (type Amazon.CodeBuild.Model.DescribeTestCasesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCBTestCaseCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_Keyword
        /// <summary>
        /// <para>
        /// <para>A keyword that is used to filter on the <c>name</c> or the <c>prefix</c> of the test
        /// cases. Only test cases where the keyword is a substring of the <c>name</c> or the
        /// <c>prefix</c> will be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_Keyword { get; set; }
        #endregion
        
        #region Parameter ReportArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the report for which test cases are returned. </para>
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
        public System.String ReportArn { get; set; }
        #endregion
        
        #region Parameter Filter_Status
        /// <summary>
        /// <para>
        /// <para>The status used to filter test cases. A <c>TestCaseFilter</c> can have one status.
        /// Valid values are:</para><ul><li><para><c>SUCCEEDED</c></para></li><li><para><c>FAILED</c></para></li><li><para><c>ERROR</c></para></li><li><para><c>SKIPPED</c></para></li><li><para><c>UNKNOWN</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of paginated test cases returned per response. Use <c>nextToken</c>
        /// to iterate pages in the list of returned <c>TestCase</c> objects. The default value
        /// is 100. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> During a previous call, the maximum number of items that can be returned is the value
        /// specified in <c>maxResults</c>. If there more items in the list, then a unique string
        /// called a <i>nextToken</i> is returned. To get the next batch of items in the list,
        /// call this operation again, adding the next token to the call. To get all of the items
        /// in the list, keep calling this operation with each subsequent next token that is returned,
        /// until no more next tokens are returned. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TestCases'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeBuild.Model.DescribeTestCasesResponse).
        /// Specifying the name of a property of type Amazon.CodeBuild.Model.DescribeTestCasesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TestCases";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReportArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReportArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReportArn' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeBuild.Model.DescribeTestCasesResponse, GetCBTestCaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReportArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Filter_Keyword = this.Filter_Keyword;
            context.Filter_Status = this.Filter_Status;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ReportArn = this.ReportArn;
            #if MODULAR
            if (this.ReportArn == null && ParameterWasBound(nameof(this.ReportArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeBuild.Model.DescribeTestCasesRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.CodeBuild.Model.TestCaseFilter();
            System.String requestFilter_filter_Keyword = null;
            if (cmdletContext.Filter_Keyword != null)
            {
                requestFilter_filter_Keyword = cmdletContext.Filter_Keyword;
            }
            if (requestFilter_filter_Keyword != null)
            {
                request.Filter.Keyword = requestFilter_filter_Keyword;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Status = requestFilter_filter_Status;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ReportArn != null)
            {
                request.ReportArn = cmdletContext.ReportArn;
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
        
        private Amazon.CodeBuild.Model.DescribeTestCasesResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.DescribeTestCasesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "DescribeTestCases");
            try
            {
                #if DESKTOP
                return client.DescribeTestCases(request);
                #elif CORECLR
                return client.DescribeTestCasesAsync(request).GetAwaiter().GetResult();
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
            public System.String Filter_Keyword { get; set; }
            public System.String Filter_Status { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ReportArn { get; set; }
            public System.Func<Amazon.CodeBuild.Model.DescribeTestCasesResponse, GetCBTestCaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TestCases;
        }
        
    }
}
