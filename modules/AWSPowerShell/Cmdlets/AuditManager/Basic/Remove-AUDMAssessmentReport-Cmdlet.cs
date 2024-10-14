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
using Amazon.AuditManager;
using Amazon.AuditManager.Model;

namespace Amazon.PowerShell.Cmdlets.AUDM
{
    /// <summary>
    /// Deletes an assessment report in Audit Manager. 
    /// 
    ///  
    /// <para>
    /// When you run the <c>DeleteAssessmentReport</c> operation, Audit Manager attempts to
    /// delete the following data:
    /// </para><ol><li><para>
    /// The specified assessment report that’s stored in your S3 bucket
    /// </para></li><li><para>
    /// The associated metadata that’s stored in Audit Manager
    /// </para></li></ol><para>
    /// If Audit Manager can’t access the assessment report in your S3 bucket, the report
    /// isn’t deleted. In this event, the <c>DeleteAssessmentReport</c> operation doesn’t
    /// fail. Instead, it proceeds to delete the associated metadata only. You must then delete
    /// the assessment report from the S3 bucket yourself. 
    /// </para><para>
    /// This scenario happens when Audit Manager receives a <c>403 (Forbidden)</c> or <c>404
    /// (Not Found)</c> error from Amazon S3. To avoid this, make sure that your S3 bucket
    /// is available, and that you configured the correct permissions for Audit Manager to
    /// delete resources in your S3 bucket. For an example permissions policy that you can
    /// use, see <a href="https://docs.aws.amazon.com/audit-manager/latest/userguide/security_iam_id-based-policy-examples.html#full-administrator-access-assessment-report-destination">Assessment
    /// report destination permissions</a> in the <i>Audit Manager User Guide</i>. For information
    /// about the issues that could cause a <c>403 (Forbidden)</c> or <c>404 (Not Found</c>)
    /// error from Amazon S3, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/ErrorResponses.html#ErrorCodeList">List
    /// of Error Codes</a> in the <i>Amazon Simple Storage Service API Reference</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "AUDMAssessmentReport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Audit Manager DeleteAssessmentReport API operation.", Operation = new[] {"DeleteAssessmentReport"}, SelectReturnType = typeof(Amazon.AuditManager.Model.DeleteAssessmentReportResponse))]
    [AWSCmdletOutput("None or Amazon.AuditManager.Model.DeleteAssessmentReportResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AuditManager.Model.DeleteAssessmentReportResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveAUDMAssessmentReportCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssessmentId
        /// <summary>
        /// <para>
        /// <para> The unique identifier for the assessment. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AssessmentId { get; set; }
        #endregion
        
        #region Parameter AssessmentReportId
        /// <summary>
        /// <para>
        /// <para> The unique identifier for the assessment report. </para>
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
        public System.String AssessmentReportId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.DeleteAssessmentReportResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AssessmentReportId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AssessmentReportId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AssessmentReportId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssessmentReportId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-AUDMAssessmentReport (DeleteAssessmentReport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.DeleteAssessmentReportResponse, RemoveAUDMAssessmentReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AssessmentReportId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssessmentId = this.AssessmentId;
            #if MODULAR
            if (this.AssessmentId == null && ParameterWasBound(nameof(this.AssessmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssessmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssessmentReportId = this.AssessmentReportId;
            #if MODULAR
            if (this.AssessmentReportId == null && ParameterWasBound(nameof(this.AssessmentReportId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssessmentReportId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AuditManager.Model.DeleteAssessmentReportRequest();
            
            if (cmdletContext.AssessmentId != null)
            {
                request.AssessmentId = cmdletContext.AssessmentId;
            }
            if (cmdletContext.AssessmentReportId != null)
            {
                request.AssessmentReportId = cmdletContext.AssessmentReportId;
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
        
        private Amazon.AuditManager.Model.DeleteAssessmentReportResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.DeleteAssessmentReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "DeleteAssessmentReport");
            try
            {
                #if DESKTOP
                return client.DeleteAssessmentReport(request);
                #elif CORECLR
                return client.DeleteAssessmentReportAsync(request).GetAwaiter().GetResult();
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
            public System.String AssessmentId { get; set; }
            public System.String AssessmentReportId { get; set; }
            public System.Func<Amazon.AuditManager.Model.DeleteAssessmentReportResponse, RemoveAUDMAssessmentReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
