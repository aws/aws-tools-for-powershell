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
    /// Adds one or more pieces of evidence to a control in an Audit Manager assessment. 
    /// 
    ///  
    /// <para>
    /// You can import manual evidence from any S3 bucket by specifying the S3 URI of the
    /// object. You can also upload a file from your browser, or enter plain text in response
    /// to a risk assessment question. 
    /// </para><para>
    /// The following restrictions apply to this action:
    /// </para><ul><li><para><c>manualEvidence</c> can be only one of the following: <c>evidenceFileName</c>,
    /// <c>s3ResourcePath</c>, or <c>textResponse</c></para></li><li><para>
    /// Maximum size of an individual evidence file: 100 MB
    /// </para></li><li><para>
    /// Number of daily manual evidence uploads per control: 100
    /// </para></li><li><para>
    /// Supported file formats: See <a href="https://docs.aws.amazon.com/audit-manager/latest/userguide/upload-evidence.html#supported-manual-evidence-files">Supported
    /// file types for manual evidence</a> in the <i>Audit Manager User Guide</i></para></li></ul><para>
    /// For more information about Audit Manager service restrictions, see <a href="https://docs.aws.amazon.com/audit-manager/latest/userguide/service-quotas.html">Quotas
    /// and restrictions for Audit Manager</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "AUDMEvidenceToAssessmentControl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AuditManager.Model.BatchImportEvidenceToAssessmentControlError")]
    [AWSCmdlet("Calls the AWS Audit Manager BatchImportEvidenceToAssessmentControl API operation.", Operation = new[] {"BatchImportEvidenceToAssessmentControl"}, SelectReturnType = typeof(Amazon.AuditManager.Model.BatchImportEvidenceToAssessmentControlResponse))]
    [AWSCmdletOutput("Amazon.AuditManager.Model.BatchImportEvidenceToAssessmentControlError or Amazon.AuditManager.Model.BatchImportEvidenceToAssessmentControlResponse",
        "This cmdlet returns a collection of Amazon.AuditManager.Model.BatchImportEvidenceToAssessmentControlError objects.",
        "The service call response (type Amazon.AuditManager.Model.BatchImportEvidenceToAssessmentControlResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddAUDMEvidenceToAssessmentControlCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter ControlId
        /// <summary>
        /// <para>
        /// <para> The identifier for the control. </para>
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
        public System.String ControlId { get; set; }
        #endregion
        
        #region Parameter ControlSetId
        /// <summary>
        /// <para>
        /// <para> The identifier for the control set. </para>
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
        public System.String ControlSetId { get; set; }
        #endregion
        
        #region Parameter ManualEvidence
        /// <summary>
        /// <para>
        /// <para> The list of manual evidence objects. </para>
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
        public Amazon.AuditManager.Model.ManualEvidence[] ManualEvidence { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Errors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.BatchImportEvidenceToAssessmentControlResponse).
        /// Specifying the name of a property of type Amazon.AuditManager.Model.BatchImportEvidenceToAssessmentControlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Errors";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ControlId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ControlId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ControlId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ControlId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-AUDMEvidenceToAssessmentControl (BatchImportEvidenceToAssessmentControl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.BatchImportEvidenceToAssessmentControlResponse, AddAUDMEvidenceToAssessmentControlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ControlId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssessmentId = this.AssessmentId;
            #if MODULAR
            if (this.AssessmentId == null && ParameterWasBound(nameof(this.AssessmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssessmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ControlId = this.ControlId;
            #if MODULAR
            if (this.ControlId == null && ParameterWasBound(nameof(this.ControlId)))
            {
                WriteWarning("You are passing $null as a value for parameter ControlId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ControlSetId = this.ControlSetId;
            #if MODULAR
            if (this.ControlSetId == null && ParameterWasBound(nameof(this.ControlSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter ControlSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ManualEvidence != null)
            {
                context.ManualEvidence = new List<Amazon.AuditManager.Model.ManualEvidence>(this.ManualEvidence);
            }
            #if MODULAR
            if (this.ManualEvidence == null && ParameterWasBound(nameof(this.ManualEvidence)))
            {
                WriteWarning("You are passing $null as a value for parameter ManualEvidence which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AuditManager.Model.BatchImportEvidenceToAssessmentControlRequest();
            
            if (cmdletContext.AssessmentId != null)
            {
                request.AssessmentId = cmdletContext.AssessmentId;
            }
            if (cmdletContext.ControlId != null)
            {
                request.ControlId = cmdletContext.ControlId;
            }
            if (cmdletContext.ControlSetId != null)
            {
                request.ControlSetId = cmdletContext.ControlSetId;
            }
            if (cmdletContext.ManualEvidence != null)
            {
                request.ManualEvidence = cmdletContext.ManualEvidence;
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
        
        private Amazon.AuditManager.Model.BatchImportEvidenceToAssessmentControlResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.BatchImportEvidenceToAssessmentControlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "BatchImportEvidenceToAssessmentControl");
            try
            {
                #if DESKTOP
                return client.BatchImportEvidenceToAssessmentControl(request);
                #elif CORECLR
                return client.BatchImportEvidenceToAssessmentControlAsync(request).GetAwaiter().GetResult();
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
            public System.String ControlId { get; set; }
            public System.String ControlSetId { get; set; }
            public List<Amazon.AuditManager.Model.ManualEvidence> ManualEvidence { get; set; }
            public System.Func<Amazon.AuditManager.Model.BatchImportEvidenceToAssessmentControlResponse, AddAUDMEvidenceToAssessmentControlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Errors;
        }
        
    }
}
