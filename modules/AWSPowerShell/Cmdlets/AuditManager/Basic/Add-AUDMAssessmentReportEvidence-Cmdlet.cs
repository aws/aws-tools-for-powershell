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
using Amazon.AuditManager;
using Amazon.AuditManager.Model;

namespace Amazon.PowerShell.Cmdlets.AUDM
{
    /// <summary>
    /// Associates a list of evidence to an assessment report in an Audit Manager assessment.
    /// </summary>
    [Cmdlet("Add", "AUDMAssessmentReportEvidence", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AuditManager.Model.BatchAssociateAssessmentReportEvidenceResponse")]
    [AWSCmdlet("Calls the AWS Audit Manager BatchAssociateAssessmentReportEvidence API operation.", Operation = new[] {"BatchAssociateAssessmentReportEvidence"}, SelectReturnType = typeof(Amazon.AuditManager.Model.BatchAssociateAssessmentReportEvidenceResponse))]
    [AWSCmdletOutput("Amazon.AuditManager.Model.BatchAssociateAssessmentReportEvidenceResponse",
        "This cmdlet returns an Amazon.AuditManager.Model.BatchAssociateAssessmentReportEvidenceResponse object containing multiple properties."
    )]
    public partial class AddAUDMAssessmentReportEvidenceCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssessmentId
        /// <summary>
        /// <para>
        /// <para> The identifier for the assessment. </para>
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
        
        #region Parameter EvidenceFolderId
        /// <summary>
        /// <para>
        /// <para> The identifier for the folder that the evidence is stored in. </para>
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
        public System.String EvidenceFolderId { get; set; }
        #endregion
        
        #region Parameter EvidenceId
        /// <summary>
        /// <para>
        /// <para> The list of evidence identifiers. </para>
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
        [Alias("EvidenceIds")]
        public System.String[] EvidenceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.BatchAssociateAssessmentReportEvidenceResponse).
        /// Specifying the name of a property of type Amazon.AuditManager.Model.BatchAssociateAssessmentReportEvidenceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EvidenceFolderId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-AUDMAssessmentReportEvidence (BatchAssociateAssessmentReportEvidence)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.BatchAssociateAssessmentReportEvidenceResponse, AddAUDMAssessmentReportEvidenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssessmentId = this.AssessmentId;
            #if MODULAR
            if (this.AssessmentId == null && ParameterWasBound(nameof(this.AssessmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssessmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EvidenceFolderId = this.EvidenceFolderId;
            #if MODULAR
            if (this.EvidenceFolderId == null && ParameterWasBound(nameof(this.EvidenceFolderId)))
            {
                WriteWarning("You are passing $null as a value for parameter EvidenceFolderId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EvidenceId != null)
            {
                context.EvidenceId = new List<System.String>(this.EvidenceId);
            }
            #if MODULAR
            if (this.EvidenceId == null && ParameterWasBound(nameof(this.EvidenceId)))
            {
                WriteWarning("You are passing $null as a value for parameter EvidenceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AuditManager.Model.BatchAssociateAssessmentReportEvidenceRequest();
            
            if (cmdletContext.AssessmentId != null)
            {
                request.AssessmentId = cmdletContext.AssessmentId;
            }
            if (cmdletContext.EvidenceFolderId != null)
            {
                request.EvidenceFolderId = cmdletContext.EvidenceFolderId;
            }
            if (cmdletContext.EvidenceId != null)
            {
                request.EvidenceIds = cmdletContext.EvidenceId;
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
        
        private Amazon.AuditManager.Model.BatchAssociateAssessmentReportEvidenceResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.BatchAssociateAssessmentReportEvidenceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "BatchAssociateAssessmentReportEvidence");
            try
            {
                return client.BatchAssociateAssessmentReportEvidenceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EvidenceFolderId { get; set; }
            public List<System.String> EvidenceId { get; set; }
            public System.Func<Amazon.AuditManager.Model.BatchAssociateAssessmentReportEvidenceResponse, AddAUDMAssessmentReportEvidenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
