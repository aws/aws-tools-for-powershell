/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Inspector;
using Amazon.Inspector.Model;

namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Produces an assessment report that includes detailed and comprehensive results of
    /// a specified assessment run.
    /// </summary>
    [Cmdlet("Get", "INSAssessmentReport")]
    [OutputType("Amazon.Inspector.Model.GetAssessmentReportResponse")]
    [AWSCmdlet("Calls the Amazon Inspector GetAssessmentReport API operation.", Operation = new[] {"GetAssessmentReport"})]
    [AWSCmdletOutput("Amazon.Inspector.Model.GetAssessmentReportResponse",
        "This cmdlet returns a Amazon.Inspector.Model.GetAssessmentReportResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetINSAssessmentReportCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        #region Parameter AssessmentRunArn
        /// <summary>
        /// <para>
        /// <para>The ARN that specifies the assessment run for which you want to generate a report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AssessmentRunArn { get; set; }
        #endregion
        
        #region Parameter ReportFileFormat
        /// <summary>
        /// <para>
        /// <para>Specifies the file format (html or pdf) of the assessment report that you want to
        /// generate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Inspector.ReportFileFormat")]
        public Amazon.Inspector.ReportFileFormat ReportFileFormat { get; set; }
        #endregion
        
        #region Parameter ReportType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of the assessment report that you want to generate. There are two
        /// types of assessment reports: a finding report and a full report. For more information,
        /// see <a href="http://docs.aws.amazon.com/inspector/latest/userguide/inspector_reports.html">Assessment
        /// Reports</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Inspector.ReportType")]
        public Amazon.Inspector.ReportType ReportType { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AssessmentRunArn = this.AssessmentRunArn;
            context.ReportFileFormat = this.ReportFileFormat;
            context.ReportType = this.ReportType;
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                #if DESKTOP
                return client.GetAssessmentReport(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetAssessmentReportAsync(request);
                return task.Result;
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
            public System.String AssessmentRunArn { get; set; }
            public Amazon.Inspector.ReportFileFormat ReportFileFormat { get; set; }
            public Amazon.Inspector.ReportType ReportType { get; set; }
        }
        
    }
}
