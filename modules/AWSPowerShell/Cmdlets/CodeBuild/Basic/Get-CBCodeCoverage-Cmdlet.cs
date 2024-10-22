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
using Amazon.CodeBuild;
using Amazon.CodeBuild.Model;

namespace Amazon.PowerShell.Cmdlets.CB
{
    /// <summary>
    /// Retrieves one or more code coverage reports.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CBCodeCoverage")]
    [OutputType("Amazon.CodeBuild.Model.CodeCoverage")]
    [AWSCmdlet("Calls the AWS CodeBuild DescribeCodeCoverages API operation.", Operation = new[] {"DescribeCodeCoverages"}, SelectReturnType = typeof(Amazon.CodeBuild.Model.DescribeCodeCoveragesResponse))]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.CodeCoverage or Amazon.CodeBuild.Model.DescribeCodeCoveragesResponse",
        "This cmdlet returns a collection of Amazon.CodeBuild.Model.CodeCoverage objects.",
        "The service call response (type Amazon.CodeBuild.Model.DescribeCodeCoveragesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCBCodeCoverageCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MaxLineCoveragePercentage
        /// <summary>
        /// <para>
        /// <para>The maximum line coverage percentage to report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? MaxLineCoveragePercentage { get; set; }
        #endregion
        
        #region Parameter MinLineCoveragePercentage
        /// <summary>
        /// <para>
        /// <para>The minimum line coverage percentage to report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? MinLineCoveragePercentage { get; set; }
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
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>Specifies how the results are sorted. Possible values are:</para><dl><dt>FILE_PATH</dt><dd><para>The results are sorted by file path.</para></dd><dt>LINE_COVERAGE_PERCENTAGE</dt><dd><para>The results are sorted by the percentage of lines that are covered.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.ReportCodeCoverageSortByType")]
        public Amazon.CodeBuild.ReportCodeCoverageSortByType SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>Specifies if the results are sorted in ascending or descending order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.SortOrderType")]
        public Amazon.CodeBuild.SortOrderType SortOrder { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>nextToken</c> value returned from a previous call to <c>DescribeCodeCoverages</c>.
        /// This specifies the next item to return. To return the beginning of the list, exclude
        /// this parameter.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CodeCoverages'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeBuild.Model.DescribeCodeCoveragesResponse).
        /// Specifying the name of a property of type Amazon.CodeBuild.Model.DescribeCodeCoveragesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CodeCoverages";
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
                context.Select = CreateSelectDelegate<Amazon.CodeBuild.Model.DescribeCodeCoveragesResponse, GetCBCodeCoverageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxLineCoveragePercentage = this.MaxLineCoveragePercentage;
            context.MaxResult = this.MaxResult;
            context.MinLineCoveragePercentage = this.MinLineCoveragePercentage;
            context.NextToken = this.NextToken;
            context.ReportArn = this.ReportArn;
            #if MODULAR
            if (this.ReportArn == null && ParameterWasBound(nameof(this.ReportArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            
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
            var request = new Amazon.CodeBuild.Model.DescribeCodeCoveragesRequest();
            
            if (cmdletContext.MaxLineCoveragePercentage != null)
            {
                request.MaxLineCoveragePercentage = cmdletContext.MaxLineCoveragePercentage.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.MinLineCoveragePercentage != null)
            {
                request.MinLineCoveragePercentage = cmdletContext.MinLineCoveragePercentage.Value;
            }
            if (cmdletContext.ReportArn != null)
            {
                request.ReportArn = cmdletContext.ReportArn;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
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
        
        private Amazon.CodeBuild.Model.DescribeCodeCoveragesResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.DescribeCodeCoveragesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "DescribeCodeCoverages");
            try
            {
                #if DESKTOP
                return client.DescribeCodeCoverages(request);
                #elif CORECLR
                return client.DescribeCodeCoveragesAsync(request).GetAwaiter().GetResult();
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
            public System.Double? MaxLineCoveragePercentage { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.Double? MinLineCoveragePercentage { get; set; }
            public System.String NextToken { get; set; }
            public System.String ReportArn { get; set; }
            public Amazon.CodeBuild.ReportCodeCoverageSortByType SortBy { get; set; }
            public Amazon.CodeBuild.SortOrderType SortOrder { get; set; }
            public System.Func<Amazon.CodeBuild.Model.DescribeCodeCoveragesResponse, GetCBCodeCoverageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CodeCoverages;
        }
        
    }
}
