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
    /// Analyzes and accumulates test report values for the specified test reports.
    /// </summary>
    [Cmdlet("Get", "CBReportGroupTrend")]
    [OutputType("Amazon.CodeBuild.Model.GetReportGroupTrendResponse")]
    [AWSCmdlet("Calls the AWS CodeBuild GetReportGroupTrend API operation.", Operation = new[] {"GetReportGroupTrend"}, SelectReturnType = typeof(Amazon.CodeBuild.Model.GetReportGroupTrendResponse))]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.GetReportGroupTrendResponse",
        "This cmdlet returns an Amazon.CodeBuild.Model.GetReportGroupTrendResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCBReportGroupTrendCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NumOfReport
        /// <summary>
        /// <para>
        /// <para>The number of reports to analyze. This operation always retrieves the most recent
        /// reports.</para><para>If this parameter is omitted, the most recent 100 reports are analyzed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumOfReports")]
        public System.Int32? NumOfReport { get; set; }
        #endregion
        
        #region Parameter ReportGroupArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the report group that contains the reports to analyze.</para>
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
        public System.String ReportGroupArn { get; set; }
        #endregion
        
        #region Parameter TrendField
        /// <summary>
        /// <para>
        /// <para>The test report value to accumulate. This must be one of the following values:</para><dl><dt>Test reports:</dt><dd><dl><dt>DURATION</dt><dd><para>Accumulate the test run times for the specified reports.</para></dd><dt>PASS_RATE</dt><dd><para>Accumulate the percentage of tests that passed for the specified test reports.</para></dd><dt>TOTAL</dt><dd><para>Accumulate the total number of tests for the specified test reports.</para></dd></dl></dd></dl><dl><dt>Code coverage reports:</dt><dd><dl><dt>BRANCH_COVERAGE</dt><dd><para>Accumulate the branch coverage percentages for the specified test reports.</para></dd><dt>BRANCHES_COVERED</dt><dd><para>Accumulate the branches covered values for the specified test reports.</para></dd><dt>BRANCHES_MISSED</dt><dd><para>Accumulate the branches missed values for the specified test reports.</para></dd><dt>LINE_COVERAGE</dt><dd><para>Accumulate the line coverage percentages for the specified test reports.</para></dd><dt>LINES_COVERED</dt><dd><para>Accumulate the lines covered values for the specified test reports.</para></dd><dt>LINES_MISSED</dt><dd><para>Accumulate the lines not covered values for the specified test reports.</para></dd></dl></dd></dl>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeBuild.ReportGroupTrendFieldType")]
        public Amazon.CodeBuild.ReportGroupTrendFieldType TrendField { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeBuild.Model.GetReportGroupTrendResponse).
        /// Specifying the name of a property of type Amazon.CodeBuild.Model.GetReportGroupTrendResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.CodeBuild.Model.GetReportGroupTrendResponse, GetCBReportGroupTrendCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NumOfReport = this.NumOfReport;
            context.ReportGroupArn = this.ReportGroupArn;
            #if MODULAR
            if (this.ReportGroupArn == null && ParameterWasBound(nameof(this.ReportGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrendField = this.TrendField;
            #if MODULAR
            if (this.TrendField == null && ParameterWasBound(nameof(this.TrendField)))
            {
                WriteWarning("You are passing $null as a value for parameter TrendField which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeBuild.Model.GetReportGroupTrendRequest();
            
            if (cmdletContext.NumOfReport != null)
            {
                request.NumOfReports = cmdletContext.NumOfReport.Value;
            }
            if (cmdletContext.ReportGroupArn != null)
            {
                request.ReportGroupArn = cmdletContext.ReportGroupArn;
            }
            if (cmdletContext.TrendField != null)
            {
                request.TrendField = cmdletContext.TrendField;
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
        
        private Amazon.CodeBuild.Model.GetReportGroupTrendResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.GetReportGroupTrendRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "GetReportGroupTrend");
            try
            {
                #if DESKTOP
                return client.GetReportGroupTrend(request);
                #elif CORECLR
                return client.GetReportGroupTrendAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? NumOfReport { get; set; }
            public System.String ReportGroupArn { get; set; }
            public Amazon.CodeBuild.ReportGroupTrendFieldType TrendField { get; set; }
            public System.Func<Amazon.CodeBuild.Model.GetReportGroupTrendResponse, GetCBReportGroupTrendCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
