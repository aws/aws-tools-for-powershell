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
using Amazon.Inspector;
using Amazon.Inspector.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Produces an assessment report that includes detailed and comprehensive results of
    /// a specified assessment run.
    /// </summary>
    [Cmdlet("Get", "INSAssessmentReport")]
    [OutputType("Amazon.Inspector.Model.GetAssessmentReportResponse")]
    [AWSCmdlet("Calls the Amazon Inspector GetAssessmentReport API operation.", Operation = new[] {"GetAssessmentReport"}, SelectReturnType = typeof(Amazon.Inspector.Model.GetAssessmentReportResponse))]
    [AWSCmdletOutput("Amazon.Inspector.Model.GetAssessmentReportResponse",
        "This cmdlet returns an Amazon.Inspector.Model.GetAssessmentReportResponse object containing multiple properties."
    )]
    public partial class GetINSAssessmentReportCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssessmentRunArn
        /// <summary>
        /// <para>
        /// <para>The ARN that specifies the assessment run for which you want to generate a report.</para>
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
        public System.String AssessmentRunArn { get; set; }
        #endregion
        
        #region Parameter ReportFileFormat
        /// <summary>
        /// <para>
        /// <para>Specifies the file format (html or pdf) of the assessment report that you want to
        /// generate.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Inspector.ReportFileFormat")]
        public Amazon.Inspector.ReportFileFormat ReportFileFormat { get; set; }
        #endregion
        
        #region Parameter ReportType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of the assessment report that you want to generate. There are two
        /// types of assessment reports: a finding report and a full report. For more information,
        /// see <a href="https://docs.aws.amazon.com/inspector/latest/userguide/inspector_reports.html">Assessment
        /// Reports</a>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Inspector.ReportType")]
        public Amazon.Inspector.ReportType ReportType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector.Model.GetAssessmentReportResponse).
        /// Specifying the name of a property of type Amazon.Inspector.Model.GetAssessmentReportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Inspector.Model.GetAssessmentReportResponse, GetINSAssessmentReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssessmentRunArn = this.AssessmentRunArn;
            #if MODULAR
            if (this.AssessmentRunArn == null && ParameterWasBound(nameof(this.AssessmentRunArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AssessmentRunArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReportFileFormat = this.ReportFileFormat;
            #if MODULAR
            if (this.ReportFileFormat == null && ParameterWasBound(nameof(this.ReportFileFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportFileFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReportType = this.ReportType;
            #if MODULAR
            if (this.ReportType == null && ParameterWasBound(nameof(this.ReportType)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Inspector.Model.GetAssessmentReportRequest();
            
            if (cmdletContext.AssessmentRunArn != null)
            {
                request.AssessmentRunArn = cmdletContext.AssessmentRunArn;
            }
            if (cmdletContext.ReportFileFormat != null)
            {
                request.ReportFileFormat = cmdletContext.ReportFileFormat;
            }
            if (cmdletContext.ReportType != null)
            {
                request.ReportType = cmdletContext.ReportType;
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
        
        private Amazon.Inspector.Model.GetAssessmentReportResponse CallAWSServiceOperation(IAmazonInspector client, Amazon.Inspector.Model.GetAssessmentReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Inspector", "GetAssessmentReport");
            try
            {
                return client.GetAssessmentReportAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssessmentRunArn { get; set; }
            public Amazon.Inspector.ReportFileFormat ReportFileFormat { get; set; }
            public Amazon.Inspector.ReportType ReportType { get; set; }
            public System.Func<Amazon.Inspector.Model.GetAssessmentReportResponse, GetINSAssessmentReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
