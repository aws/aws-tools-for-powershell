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
    /// Returns an array of reports.
    /// </summary>
    [Cmdlet("Get", "CBReportBatch")]
    [OutputType("Amazon.CodeBuild.Model.Report")]
    [AWSCmdlet("Calls the AWS CodeBuild BatchGetReports API operation.", Operation = new[] {"BatchGetReports"}, SelectReturnType = typeof(Amazon.CodeBuild.Model.BatchGetReportsResponse))]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.Report or Amazon.CodeBuild.Model.BatchGetReportsResponse",
        "This cmdlet returns a collection of Amazon.CodeBuild.Model.Report objects.",
        "The service call response (type Amazon.CodeBuild.Model.BatchGetReportsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCBReportBatchCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        #region Parameter ReportArn
        /// <summary>
        /// <para>
        /// <para> An array of ARNs that identify the <code>Report</code> objects to return. </para>
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
        [Alias("ReportArns")]
        public System.String[] ReportArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Reports'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeBuild.Model.BatchGetReportsResponse).
        /// Specifying the name of a property of type Amazon.CodeBuild.Model.BatchGetReportsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Reports";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeBuild.Model.BatchGetReportsResponse, GetCBReportBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ReportArn != null)
            {
                context.ReportArn = new List<System.String>(this.ReportArn);
            }
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
            // create request
            var request = new Amazon.CodeBuild.Model.BatchGetReportsRequest();
            
            if (cmdletContext.ReportArn != null)
            {
                request.ReportArns = cmdletContext.ReportArn;
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
        
        private Amazon.CodeBuild.Model.BatchGetReportsResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.BatchGetReportsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "BatchGetReports");
            try
            {
                #if DESKTOP
                return client.BatchGetReports(request);
                #elif CORECLR
                return client.BatchGetReportsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ReportArn { get; set; }
            public System.Func<Amazon.CodeBuild.Model.BatchGetReportsResponse, GetCBReportBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Reports;
        }
        
    }
}
