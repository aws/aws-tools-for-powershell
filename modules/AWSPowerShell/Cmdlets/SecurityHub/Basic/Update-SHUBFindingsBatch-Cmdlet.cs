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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Used by Security Hub customers to update information about their investigation into
    /// a finding. Requested by administrator accounts or member accounts. Administrator accounts
    /// can update findings for their account and their member accounts. Member accounts can
    /// update findings for their account.
    /// 
    ///  
    /// <para>
    /// Updates from <c>BatchUpdateFindings</c> don't affect the value of <c>UpdatedAt</c>
    /// for a finding.
    /// </para><para>
    /// Administrator and member accounts can use <c>BatchUpdateFindings</c> to update the
    /// following finding fields and objects.
    /// </para><ul><li><para><c>Confidence</c></para></li><li><para><c>Criticality</c></para></li><li><para><c>Note</c></para></li><li><para><c>RelatedFindings</c></para></li><li><para><c>Severity</c></para></li><li><para><c>Types</c></para></li><li><para><c>UserDefinedFields</c></para></li><li><para><c>VerificationState</c></para></li><li><para><c>Workflow</c></para></li></ul><para>
    /// You can configure IAM policies to restrict access to fields and field values. For
    /// example, you might not want member accounts to be able to suppress findings or change
    /// the finding severity. See <a href="https://docs.aws.amazon.com/securityhub/latest/userguide/finding-update-batchupdatefindings.html#batchupdatefindings-configure-access">Configuring
    /// access to BatchUpdateFindings</a> in the <i>Security Hub User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SHUBFindingsBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityHub.Model.BatchUpdateFindingsResponse")]
    [AWSCmdlet("Calls the AWS Security Hub BatchUpdateFindings API operation.", Operation = new[] {"BatchUpdateFindings"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.BatchUpdateFindingsResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.BatchUpdateFindingsResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.BatchUpdateFindingsResponse object containing multiple properties."
    )]
    public partial class UpdateSHUBFindingsBatchCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Confidence
        /// <summary>
        /// <para>
        /// <para>The updated value for the finding confidence. Confidence is defined as the likelihood
        /// that a finding accurately identifies the behavior or issue that it was intended to
        /// identify.</para><para>Confidence is scored on a 0-100 basis using a ratio scale, where 0 means zero percent
        /// confidence and 100 means 100 percent confidence.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Confidence { get; set; }
        #endregion
        
        #region Parameter Criticality
        /// <summary>
        /// <para>
        /// <para>The updated value for the level of importance assigned to the resources associated
        /// with the findings.</para><para>A score of 0 means that the underlying resources have no criticality, and a score
        /// of 100 is reserved for the most critical resources. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Criticality { get; set; }
        #endregion
        
        #region Parameter FindingIdentifier
        /// <summary>
        /// <para>
        /// <para>The list of findings to update. <c>BatchUpdateFindings</c> can be used to update up
        /// to 100 findings at a time.</para><para>For each finding, the list provides the finding identifier and the ARN of the finding
        /// provider.</para>
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
        [Alias("FindingIdentifiers")]
        public Amazon.SecurityHub.Model.AwsSecurityFindingIdentifier[] FindingIdentifier { get; set; }
        #endregion
        
        #region Parameter Severity_Label
        /// <summary>
        /// <para>
        /// <para>The severity value of the finding. The allowed values are the following.</para><ul><li><para><c>INFORMATIONAL</c> - No issue was found.</para></li><li><para><c>LOW</c> - The issue does not require action on its own.</para></li><li><para><c>MEDIUM</c> - The issue must be addressed but not urgently.</para></li><li><para><c>HIGH</c> - The issue must be addressed as a priority.</para></li><li><para><c>CRITICAL</c> - The issue must be remediated immediately to avoid it escalating.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.SeverityLabel")]
        public Amazon.SecurityHub.SeverityLabel Severity_Label { get; set; }
        #endregion
        
        #region Parameter Severity_Normalized
        /// <summary>
        /// <para>
        /// <para>The normalized severity for the finding. This attribute is to be deprecated in favor
        /// of <c>Label</c>.</para><para>If you provide <c>Normalized</c> and don't provide <c>Label</c>, <c>Label</c> is set
        /// automatically as follows.</para><ul><li><para>0 - <c>INFORMATIONAL</c></para></li><li><para>1–39 - <c>LOW</c></para></li><li><para>40–69 - <c>MEDIUM</c></para></li><li><para>70–89 - <c>HIGH</c></para></li><li><para>90–100 - <c>CRITICAL</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Severity_Normalized { get; set; }
        #endregion
        
        #region Parameter Severity_Product
        /// <summary>
        /// <para>
        /// <para>The native severity as defined by the Amazon Web Services service or integrated partner
        /// product that generated the finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Severity_Product { get; set; }
        #endregion
        
        #region Parameter RelatedFinding
        /// <summary>
        /// <para>
        /// <para>A list of findings that are related to the updated findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RelatedFindings")]
        public Amazon.SecurityHub.Model.RelatedFinding[] RelatedFinding { get; set; }
        #endregion
        
        #region Parameter Workflow_Status
        /// <summary>
        /// <para>
        /// <para>The status of the investigation into the finding. The workflow status is specific
        /// to an individual finding. It does not affect the generation of new findings. For example,
        /// setting the workflow status to <c>SUPPRESSED</c> or <c>RESOLVED</c> does not prevent
        /// a new finding for the same issue.</para><para>The allowed values are the following.</para><ul><li><para><c>NEW</c> - The initial state of a finding, before it is reviewed.</para><para>Security Hub also resets <c>WorkFlowStatus</c> from <c>NOTIFIED</c> or <c>RESOLVED</c>
        /// to <c>NEW</c> in the following cases:</para><ul><li><para>The record state changes from <c>ARCHIVED</c> to <c>ACTIVE</c>.</para></li><li><para>The compliance status changes from <c>PASSED</c> to either <c>WARNING</c>, <c>FAILED</c>,
        /// or <c>NOT_AVAILABLE</c>.</para></li></ul></li><li><para><c>NOTIFIED</c> - Indicates that you notified the resource owner about the security
        /// issue. Used when the initial reviewer is not the resource owner, and needs intervention
        /// from the resource owner.</para></li><li><para><c>RESOLVED</c> - The finding was reviewed and remediated and is now considered resolved.</para></li><li><para><c>SUPPRESSED</c> - Indicates that you reviewed the finding and don't believe that
        /// any action is needed. The finding is no longer updated.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.WorkflowStatus")]
        public Amazon.SecurityHub.WorkflowStatus Workflow_Status { get; set; }
        #endregion
        
        #region Parameter Note_Text
        /// <summary>
        /// <para>
        /// <para>The updated note text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Note_Text { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>One or more finding types in the format of namespace/category/classifier that classify
        /// a finding.</para><para>Valid namespace values are as follows.</para><ul><li><para>Software and Configuration Checks</para></li><li><para>TTPs</para></li><li><para>Effects</para></li><li><para>Unusual Behaviors</para></li><li><para>Sensitive Data Identifications </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Types")]
        public System.String[] Type { get; set; }
        #endregion
        
        #region Parameter Note_UpdatedBy
        /// <summary>
        /// <para>
        /// <para>The principal that updated the note.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Note_UpdatedBy { get; set; }
        #endregion
        
        #region Parameter UserDefinedField
        /// <summary>
        /// <para>
        /// <para>A list of name/value string pairs associated with the finding. These are custom, user-defined
        /// fields added to a finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserDefinedFields")]
        public System.Collections.Hashtable UserDefinedField { get; set; }
        #endregion
        
        #region Parameter VerificationState
        /// <summary>
        /// <para>
        /// <para>Indicates the veracity of a finding.</para><para>The available values for <c>VerificationState</c> are as follows.</para><ul><li><para><c>UNKNOWN</c> – The default disposition of a security finding</para></li><li><para><c>TRUE_POSITIVE</c> – The security finding is confirmed</para></li><li><para><c>FALSE_POSITIVE</c> – The security finding was determined to be a false alarm</para></li><li><para><c>BENIGN_POSITIVE</c> – A special case of <c>TRUE_POSITIVE</c> where the finding
        /// doesn't pose any threat, is expected, or both</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.VerificationState")]
        public Amazon.SecurityHub.VerificationState VerificationState { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.BatchUpdateFindingsResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.BatchUpdateFindingsResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SHUBFindingsBatch (BatchUpdateFindings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.BatchUpdateFindingsResponse, UpdateSHUBFindingsBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Confidence = this.Confidence;
            context.Criticality = this.Criticality;
            if (this.FindingIdentifier != null)
            {
                context.FindingIdentifier = new List<Amazon.SecurityHub.Model.AwsSecurityFindingIdentifier>(this.FindingIdentifier);
            }
            #if MODULAR
            if (this.FindingIdentifier == null && ParameterWasBound(nameof(this.FindingIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter FindingIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Note_Text = this.Note_Text;
            context.Note_UpdatedBy = this.Note_UpdatedBy;
            if (this.RelatedFinding != null)
            {
                context.RelatedFinding = new List<Amazon.SecurityHub.Model.RelatedFinding>(this.RelatedFinding);
            }
            context.Severity_Label = this.Severity_Label;
            context.Severity_Normalized = this.Severity_Normalized;
            context.Severity_Product = this.Severity_Product;
            if (this.Type != null)
            {
                context.Type = new List<System.String>(this.Type);
            }
            if (this.UserDefinedField != null)
            {
                context.UserDefinedField = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.UserDefinedField.Keys)
                {
                    context.UserDefinedField.Add((String)hashKey, (System.String)(this.UserDefinedField[hashKey]));
                }
            }
            context.VerificationState = this.VerificationState;
            context.Workflow_Status = this.Workflow_Status;
            
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
            var request = new Amazon.SecurityHub.Model.BatchUpdateFindingsRequest();
            
            if (cmdletContext.Confidence != null)
            {
                request.Confidence = cmdletContext.Confidence.Value;
            }
            if (cmdletContext.Criticality != null)
            {
                request.Criticality = cmdletContext.Criticality.Value;
            }
            if (cmdletContext.FindingIdentifier != null)
            {
                request.FindingIdentifiers = cmdletContext.FindingIdentifier;
            }
            
             // populate Note
            var requestNoteIsNull = true;
            request.Note = new Amazon.SecurityHub.Model.NoteUpdate();
            System.String requestNote_note_Text = null;
            if (cmdletContext.Note_Text != null)
            {
                requestNote_note_Text = cmdletContext.Note_Text;
            }
            if (requestNote_note_Text != null)
            {
                request.Note.Text = requestNote_note_Text;
                requestNoteIsNull = false;
            }
            System.String requestNote_note_UpdatedBy = null;
            if (cmdletContext.Note_UpdatedBy != null)
            {
                requestNote_note_UpdatedBy = cmdletContext.Note_UpdatedBy;
            }
            if (requestNote_note_UpdatedBy != null)
            {
                request.Note.UpdatedBy = requestNote_note_UpdatedBy;
                requestNoteIsNull = false;
            }
             // determine if request.Note should be set to null
            if (requestNoteIsNull)
            {
                request.Note = null;
            }
            if (cmdletContext.RelatedFinding != null)
            {
                request.RelatedFindings = cmdletContext.RelatedFinding;
            }
            
             // populate Severity
            var requestSeverityIsNull = true;
            request.Severity = new Amazon.SecurityHub.Model.SeverityUpdate();
            Amazon.SecurityHub.SeverityLabel requestSeverity_severity_Label = null;
            if (cmdletContext.Severity_Label != null)
            {
                requestSeverity_severity_Label = cmdletContext.Severity_Label;
            }
            if (requestSeverity_severity_Label != null)
            {
                request.Severity.Label = requestSeverity_severity_Label;
                requestSeverityIsNull = false;
            }
            System.Int32? requestSeverity_severity_Normalized = null;
            if (cmdletContext.Severity_Normalized != null)
            {
                requestSeverity_severity_Normalized = cmdletContext.Severity_Normalized.Value;
            }
            if (requestSeverity_severity_Normalized != null)
            {
                request.Severity.Normalized = requestSeverity_severity_Normalized.Value;
                requestSeverityIsNull = false;
            }
            System.Double? requestSeverity_severity_Product = null;
            if (cmdletContext.Severity_Product != null)
            {
                requestSeverity_severity_Product = cmdletContext.Severity_Product.Value;
            }
            if (requestSeverity_severity_Product != null)
            {
                request.Severity.Product = requestSeverity_severity_Product.Value;
                requestSeverityIsNull = false;
            }
             // determine if request.Severity should be set to null
            if (requestSeverityIsNull)
            {
                request.Severity = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Types = cmdletContext.Type;
            }
            if (cmdletContext.UserDefinedField != null)
            {
                request.UserDefinedFields = cmdletContext.UserDefinedField;
            }
            if (cmdletContext.VerificationState != null)
            {
                request.VerificationState = cmdletContext.VerificationState;
            }
            
             // populate Workflow
            var requestWorkflowIsNull = true;
            request.Workflow = new Amazon.SecurityHub.Model.WorkflowUpdate();
            Amazon.SecurityHub.WorkflowStatus requestWorkflow_workflow_Status = null;
            if (cmdletContext.Workflow_Status != null)
            {
                requestWorkflow_workflow_Status = cmdletContext.Workflow_Status;
            }
            if (requestWorkflow_workflow_Status != null)
            {
                request.Workflow.Status = requestWorkflow_workflow_Status;
                requestWorkflowIsNull = false;
            }
             // determine if request.Workflow should be set to null
            if (requestWorkflowIsNull)
            {
                request.Workflow = null;
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
        
        private Amazon.SecurityHub.Model.BatchUpdateFindingsResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.BatchUpdateFindingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "BatchUpdateFindings");
            try
            {
                #if DESKTOP
                return client.BatchUpdateFindings(request);
                #elif CORECLR
                return client.BatchUpdateFindingsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? Confidence { get; set; }
            public System.Int32? Criticality { get; set; }
            public List<Amazon.SecurityHub.Model.AwsSecurityFindingIdentifier> FindingIdentifier { get; set; }
            public System.String Note_Text { get; set; }
            public System.String Note_UpdatedBy { get; set; }
            public List<Amazon.SecurityHub.Model.RelatedFinding> RelatedFinding { get; set; }
            public Amazon.SecurityHub.SeverityLabel Severity_Label { get; set; }
            public System.Int32? Severity_Normalized { get; set; }
            public System.Double? Severity_Product { get; set; }
            public List<System.String> Type { get; set; }
            public Dictionary<System.String, System.String> UserDefinedField { get; set; }
            public Amazon.SecurityHub.VerificationState VerificationState { get; set; }
            public Amazon.SecurityHub.WorkflowStatus Workflow_Status { get; set; }
            public System.Func<Amazon.SecurityHub.Model.BatchUpdateFindingsResponse, UpdateSHUBFindingsBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
