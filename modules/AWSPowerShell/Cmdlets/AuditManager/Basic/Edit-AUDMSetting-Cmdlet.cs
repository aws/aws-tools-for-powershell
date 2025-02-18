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
    /// Updates Audit Manager settings for the current account.
    /// </summary>
    [Cmdlet("Edit", "AUDMSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AuditManager.Model.Settings")]
    [AWSCmdlet("Calls the AWS Audit Manager UpdateSettings API operation.", Operation = new[] {"UpdateSettings"}, SelectReturnType = typeof(Amazon.AuditManager.Model.UpdateSettingsResponse))]
    [AWSCmdletOutput("Amazon.AuditManager.Model.Settings or Amazon.AuditManager.Model.UpdateSettingsResponse",
        "This cmdlet returns an Amazon.AuditManager.Model.Settings object.",
        "The service call response (type Amazon.AuditManager.Model.UpdateSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditAUDMSettingCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DefaultProcessOwner
        /// <summary>
        /// <para>
        /// <para> A list of the default audit owners. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultProcessOwners")]
        public Amazon.AuditManager.Model.Role[] DefaultProcessOwner { get; set; }
        #endregion
        
        #region Parameter DeregistrationPolicy_DeleteResource
        /// <summary>
        /// <para>
        /// <para>Specifies which Audit Manager data will be deleted when you deregister Audit Manager.</para><ul><li><para>If you set the value to <c>ALL</c>, all of your data is deleted within seven days
        /// of deregistration.</para></li><li><para>If you set the value to <c>DEFAULT</c>, none of your data is deleted at the time of
        /// deregistration. However, keep in mind that the Audit Manager data retention policy
        /// still applies. As a result, any evidence data will be deleted two years after its
        /// creation date. Your other Audit Manager resources will continue to exist indefinitely.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeregistrationPolicy_DeleteResources")]
        [AWSConstantClassSource("Amazon.AuditManager.DeleteResources")]
        public Amazon.AuditManager.DeleteResources DeregistrationPolicy_DeleteResource { get; set; }
        #endregion
        
        #region Parameter DefaultAssessmentReportsDestination_Destination
        /// <summary>
        /// <para>
        /// <para> The destination bucket where Audit Manager stores assessment reports. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultAssessmentReportsDestination_Destination { get; set; }
        #endregion
        
        #region Parameter DefaultExportDestination_Destination
        /// <summary>
        /// <para>
        /// <para>The destination bucket where Audit Manager stores exported files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultExportDestination_Destination { get; set; }
        #endregion
        
        #region Parameter DefaultAssessmentReportsDestination_DestinationType
        /// <summary>
        /// <para>
        /// <para> The destination type, such as Amazon S3. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AuditManager.AssessmentReportDestinationType")]
        public Amazon.AuditManager.AssessmentReportDestinationType DefaultAssessmentReportsDestination_DestinationType { get; set; }
        #endregion
        
        #region Parameter DefaultExportDestination_DestinationType
        /// <summary>
        /// <para>
        /// <para>The destination type, such as Amazon S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AuditManager.ExportDestinationType")]
        public Amazon.AuditManager.ExportDestinationType DefaultExportDestination_DestinationType { get; set; }
        #endregion
        
        #region Parameter EvidenceFinderEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether the evidence finder feature is enabled. Change this attribute to
        /// enable or disable evidence finder.</para><important><para>When you use this attribute to disable evidence finder, Audit Manager deletes the
        /// event data store that’s used to query your evidence data. As a result, you can’t re-enable
        /// evidence finder and use the feature again. Your only alternative is to <a href="https://docs.aws.amazon.com/audit-manager/latest/APIReference/API_DeregisterAccount.html">deregister</a>
        /// and then <a href="https://docs.aws.amazon.com/audit-manager/latest/APIReference/API_RegisterAccount.html">re-register</a>
        /// Audit Manager. </para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EvidenceFinderEnabled { get; set; }
        #endregion
        
        #region Parameter KmsKey
        /// <summary>
        /// <para>
        /// <para> The KMS key details. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKey { get; set; }
        #endregion
        
        #region Parameter SnsTopic
        /// <summary>
        /// <para>
        /// <para> The Amazon Simple Notification Service (Amazon SNS) topic that Audit Manager sends
        /// notifications to. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnsTopic { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Settings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.UpdateSettingsResponse).
        /// Specifying the name of a property of type Amazon.AuditManager.Model.UpdateSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Settings";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-AUDMSetting (UpdateSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.UpdateSettingsResponse, EditAUDMSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DefaultAssessmentReportsDestination_Destination = this.DefaultAssessmentReportsDestination_Destination;
            context.DefaultAssessmentReportsDestination_DestinationType = this.DefaultAssessmentReportsDestination_DestinationType;
            context.DefaultExportDestination_Destination = this.DefaultExportDestination_Destination;
            context.DefaultExportDestination_DestinationType = this.DefaultExportDestination_DestinationType;
            if (this.DefaultProcessOwner != null)
            {
                context.DefaultProcessOwner = new List<Amazon.AuditManager.Model.Role>(this.DefaultProcessOwner);
            }
            context.DeregistrationPolicy_DeleteResource = this.DeregistrationPolicy_DeleteResource;
            context.EvidenceFinderEnabled = this.EvidenceFinderEnabled;
            context.KmsKey = this.KmsKey;
            context.SnsTopic = this.SnsTopic;
            
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
            var request = new Amazon.AuditManager.Model.UpdateSettingsRequest();
            
            
             // populate DefaultAssessmentReportsDestination
            var requestDefaultAssessmentReportsDestinationIsNull = true;
            request.DefaultAssessmentReportsDestination = new Amazon.AuditManager.Model.AssessmentReportsDestination();
            System.String requestDefaultAssessmentReportsDestination_defaultAssessmentReportsDestination_Destination = null;
            if (cmdletContext.DefaultAssessmentReportsDestination_Destination != null)
            {
                requestDefaultAssessmentReportsDestination_defaultAssessmentReportsDestination_Destination = cmdletContext.DefaultAssessmentReportsDestination_Destination;
            }
            if (requestDefaultAssessmentReportsDestination_defaultAssessmentReportsDestination_Destination != null)
            {
                request.DefaultAssessmentReportsDestination.Destination = requestDefaultAssessmentReportsDestination_defaultAssessmentReportsDestination_Destination;
                requestDefaultAssessmentReportsDestinationIsNull = false;
            }
            Amazon.AuditManager.AssessmentReportDestinationType requestDefaultAssessmentReportsDestination_defaultAssessmentReportsDestination_DestinationType = null;
            if (cmdletContext.DefaultAssessmentReportsDestination_DestinationType != null)
            {
                requestDefaultAssessmentReportsDestination_defaultAssessmentReportsDestination_DestinationType = cmdletContext.DefaultAssessmentReportsDestination_DestinationType;
            }
            if (requestDefaultAssessmentReportsDestination_defaultAssessmentReportsDestination_DestinationType != null)
            {
                request.DefaultAssessmentReportsDestination.DestinationType = requestDefaultAssessmentReportsDestination_defaultAssessmentReportsDestination_DestinationType;
                requestDefaultAssessmentReportsDestinationIsNull = false;
            }
             // determine if request.DefaultAssessmentReportsDestination should be set to null
            if (requestDefaultAssessmentReportsDestinationIsNull)
            {
                request.DefaultAssessmentReportsDestination = null;
            }
            
             // populate DefaultExportDestination
            var requestDefaultExportDestinationIsNull = true;
            request.DefaultExportDestination = new Amazon.AuditManager.Model.DefaultExportDestination();
            System.String requestDefaultExportDestination_defaultExportDestination_Destination = null;
            if (cmdletContext.DefaultExportDestination_Destination != null)
            {
                requestDefaultExportDestination_defaultExportDestination_Destination = cmdletContext.DefaultExportDestination_Destination;
            }
            if (requestDefaultExportDestination_defaultExportDestination_Destination != null)
            {
                request.DefaultExportDestination.Destination = requestDefaultExportDestination_defaultExportDestination_Destination;
                requestDefaultExportDestinationIsNull = false;
            }
            Amazon.AuditManager.ExportDestinationType requestDefaultExportDestination_defaultExportDestination_DestinationType = null;
            if (cmdletContext.DefaultExportDestination_DestinationType != null)
            {
                requestDefaultExportDestination_defaultExportDestination_DestinationType = cmdletContext.DefaultExportDestination_DestinationType;
            }
            if (requestDefaultExportDestination_defaultExportDestination_DestinationType != null)
            {
                request.DefaultExportDestination.DestinationType = requestDefaultExportDestination_defaultExportDestination_DestinationType;
                requestDefaultExportDestinationIsNull = false;
            }
             // determine if request.DefaultExportDestination should be set to null
            if (requestDefaultExportDestinationIsNull)
            {
                request.DefaultExportDestination = null;
            }
            if (cmdletContext.DefaultProcessOwner != null)
            {
                request.DefaultProcessOwners = cmdletContext.DefaultProcessOwner;
            }
            
             // populate DeregistrationPolicy
            var requestDeregistrationPolicyIsNull = true;
            request.DeregistrationPolicy = new Amazon.AuditManager.Model.DeregistrationPolicy();
            Amazon.AuditManager.DeleteResources requestDeregistrationPolicy_deregistrationPolicy_DeleteResource = null;
            if (cmdletContext.DeregistrationPolicy_DeleteResource != null)
            {
                requestDeregistrationPolicy_deregistrationPolicy_DeleteResource = cmdletContext.DeregistrationPolicy_DeleteResource;
            }
            if (requestDeregistrationPolicy_deregistrationPolicy_DeleteResource != null)
            {
                request.DeregistrationPolicy.DeleteResources = requestDeregistrationPolicy_deregistrationPolicy_DeleteResource;
                requestDeregistrationPolicyIsNull = false;
            }
             // determine if request.DeregistrationPolicy should be set to null
            if (requestDeregistrationPolicyIsNull)
            {
                request.DeregistrationPolicy = null;
            }
            if (cmdletContext.EvidenceFinderEnabled != null)
            {
                request.EvidenceFinderEnabled = cmdletContext.EvidenceFinderEnabled.Value;
            }
            if (cmdletContext.KmsKey != null)
            {
                request.KmsKey = cmdletContext.KmsKey;
            }
            if (cmdletContext.SnsTopic != null)
            {
                request.SnsTopic = cmdletContext.SnsTopic;
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
        
        private Amazon.AuditManager.Model.UpdateSettingsResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.UpdateSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "UpdateSettings");
            try
            {
                return client.UpdateSettingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DefaultAssessmentReportsDestination_Destination { get; set; }
            public Amazon.AuditManager.AssessmentReportDestinationType DefaultAssessmentReportsDestination_DestinationType { get; set; }
            public System.String DefaultExportDestination_Destination { get; set; }
            public Amazon.AuditManager.ExportDestinationType DefaultExportDestination_DestinationType { get; set; }
            public List<Amazon.AuditManager.Model.Role> DefaultProcessOwner { get; set; }
            public Amazon.AuditManager.DeleteResources DeregistrationPolicy_DeleteResource { get; set; }
            public System.Boolean? EvidenceFinderEnabled { get; set; }
            public System.String KmsKey { get; set; }
            public System.String SnsTopic { get; set; }
            public System.Func<Amazon.AuditManager.Model.UpdateSettingsResponse, EditAUDMSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Settings;
        }
        
    }
}
