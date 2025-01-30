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
using Amazon.AuditManager;
using Amazon.AuditManager.Model;

namespace Amazon.PowerShell.Cmdlets.AUDM
{
    /// <summary>
    /// Removes the specified Amazon Web Services account as a delegated administrator for
    /// Audit Manager. 
    /// 
    ///  
    /// <para>
    /// When you remove a delegated administrator from your Audit Manager settings, you continue
    /// to have access to the evidence that you previously collected under that account. This
    /// is also the case when you deregister a delegated administrator from Organizations.
    /// However, Audit Manager stops collecting and attaching evidence to that delegated administrator
    /// account moving forward.
    /// </para><important><para>
    /// Keep in mind the following cleanup task if you use evidence finder:
    /// </para><para>
    /// Before you use your management account to remove a delegated administrator, make sure
    /// that the current delegated administrator account signs in to Audit Manager and disables
    /// evidence finder first. Disabling evidence finder automatically deletes the event data
    /// store that was created in their account when they enabled evidence finder. If this
    /// task isn’t completed, the event data store remains in their account. In this case,
    /// we recommend that the original delegated administrator goes to CloudTrail Lake and
    /// manually <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/query-eds-disable-termination.html">deletes
    /// the event data store</a>.
    /// </para><para>
    /// This cleanup task is necessary to ensure that you don't end up with multiple event
    /// data stores. Audit Manager ignores an unused event data store after you remove or
    /// change a delegated administrator account. However, the unused event data store continues
    /// to incur storage costs from CloudTrail Lake if you don't delete it.
    /// </para></important><para>
    /// When you deregister a delegated administrator account for Audit Manager, the data
    /// for that account isn’t deleted. If you want to delete resource data for a delegated
    /// administrator account, you must perform that task separately before you deregister
    /// the account. Either, you can do this in the Audit Manager console. Or, you can use
    /// one of the delete API operations that are provided by Audit Manager. 
    /// </para><para>
    /// To delete your Audit Manager resource data, see the following instructions: 
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/audit-manager/latest/APIReference/API_DeleteAssessment.html">DeleteAssessment</a>
    /// (see also: <a href="https://docs.aws.amazon.com/audit-manager/latest/userguide/delete-assessment.html">Deleting
    /// an assessment</a> in the <i>Audit Manager User Guide</i>)
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/audit-manager/latest/APIReference/API_DeleteAssessmentFramework.html">DeleteAssessmentFramework</a>
    /// (see also: <a href="https://docs.aws.amazon.com/audit-manager/latest/userguide/delete-custom-framework.html">Deleting
    /// a custom framework</a> in the <i>Audit Manager User Guide</i>)
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/audit-manager/latest/APIReference/API_DeleteAssessmentFrameworkShare.html">DeleteAssessmentFrameworkShare</a>
    /// (see also: <a href="https://docs.aws.amazon.com/audit-manager/latest/userguide/deleting-shared-framework-requests.html">Deleting
    /// a share request</a> in the <i>Audit Manager User Guide</i>)
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/audit-manager/latest/APIReference/API_DeleteAssessmentReport.html">DeleteAssessmentReport</a>
    /// (see also: <a href="https://docs.aws.amazon.com/audit-manager/latest/userguide/generate-assessment-report.html#delete-assessment-report-steps">Deleting
    /// an assessment report</a> in the <i>Audit Manager User Guide</i>)
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/audit-manager/latest/APIReference/API_DeleteControl.html">DeleteControl</a>
    /// (see also: <a href="https://docs.aws.amazon.com/audit-manager/latest/userguide/delete-controls.html">Deleting
    /// a custom control</a> in the <i>Audit Manager User Guide</i>)
    /// </para></li></ul><para>
    /// At this time, Audit Manager doesn't provide an option to delete evidence for a specific
    /// delegated administrator. Instead, when your management account deregisters Audit Manager,
    /// we perform a cleanup for the current delegated administrator account at the time of
    /// deregistration.
    /// </para>
    /// </summary>
    [Cmdlet("Unregister", "AUDMOrganizationAdminAccount", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Audit Manager DeregisterOrganizationAdminAccount API operation.", Operation = new[] {"DeregisterOrganizationAdminAccount"}, SelectReturnType = typeof(Amazon.AuditManager.Model.DeregisterOrganizationAdminAccountResponse))]
    [AWSCmdletOutput("None or Amazon.AuditManager.Model.DeregisterOrganizationAdminAccountResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AuditManager.Model.DeregisterOrganizationAdminAccountResponse) be returned by specifying '-Select *'."
    )]
    public partial class UnregisterAUDMOrganizationAdminAccountCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdminAccountId
        /// <summary>
        /// <para>
        /// <para> The identifier for the administrator account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AdminAccountId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.DeregisterOrganizationAdminAccountResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AdminAccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AdminAccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AdminAccountId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AdminAccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-AUDMOrganizationAdminAccount (DeregisterOrganizationAdminAccount)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.DeregisterOrganizationAdminAccountResponse, UnregisterAUDMOrganizationAdminAccountCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AdminAccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AdminAccountId = this.AdminAccountId;
            
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
            var request = new Amazon.AuditManager.Model.DeregisterOrganizationAdminAccountRequest();
            
            if (cmdletContext.AdminAccountId != null)
            {
                request.AdminAccountId = cmdletContext.AdminAccountId;
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
        
        private Amazon.AuditManager.Model.DeregisterOrganizationAdminAccountResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.DeregisterOrganizationAdminAccountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "DeregisterOrganizationAdminAccount");
            try
            {
                #if DESKTOP
                return client.DeregisterOrganizationAdminAccount(request);
                #elif CORECLR
                return client.DeregisterOrganizationAdminAccountAsync(request).GetAwaiter().GetResult();
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
            public System.String AdminAccountId { get; set; }
            public System.Func<Amazon.AuditManager.Model.DeregisterOrganizationAdminAccountResponse, UnregisterAUDMOrganizationAdminAccountCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
