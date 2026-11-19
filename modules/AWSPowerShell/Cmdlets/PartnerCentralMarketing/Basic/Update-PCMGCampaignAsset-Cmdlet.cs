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
using Amazon.PartnerCentralMarketing;
using Amazon.PartnerCentralMarketing.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PCMG
{
    /// <summary>
    /// Updates an asset's field values, layout or send time. Refused with `ConflictException`
    /// while the campaign's running activation task still owns the asset (`ASSET_START_IN_PROGRESS`),
    /// and for a live email or social post (`ASSET_ALREADY_ACTIVE`): deactivate it first.
    /// </summary>
    [Cmdlet("Update", "PCMGCampaignAsset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralMarketing.Model.UpdateCampaignAssetResponse")]
    [AWSCmdlet("Calls the Partner Central Marketing API UpdateCampaignAsset API operation.", Operation = new[] {"UpdateCampaignAsset"}, SelectReturnType = typeof(Amazon.PartnerCentralMarketing.Model.UpdateCampaignAssetResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralMarketing.Model.UpdateCampaignAssetResponse",
        "This cmdlet returns an Amazon.PartnerCentralMarketing.Model.UpdateCampaignAssetResponse object containing multiple properties."
    )]
    public partial class UpdatePCMGCampaignAssetCmdlet : AmazonPartnerCentralMarketingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CampaignAssetIdentifier
        /// <summary>
        /// <para>
        /// The asset identifier.
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
        public System.String CampaignAssetIdentifier { get; set; }
        #endregion
        
        #region Parameter CampaignIdentifier
        /// <summary>
        /// <para>
        /// The campaign identifier.
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
        public System.String CampaignIdentifier { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// The catalog (AWS or Sandbox).
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralMarketing.Catalog")]
        public Amazon.PartnerCentralMarketing.Catalog Catalog { get; set; }
        #endregion
        
        #region Parameter FieldValue
        /// <summary>
        /// <para>
        /// Value-only updates to the asset's pinned template
        /// fields, keyed by FieldId. The field schema (labels, descriptions, constraints, placeholders,
        /// image defaults) is service-owned and pinned at instantiation, so clients send only
        /// the values they are changing. Fields omitted keep their stored values; send the entry
        /// with `Value` omitted to clear one. Named `FieldValues` to match the member it edits
        /// on `CampaignAsset`, which is the same concept read back. It was `templateFieldUpdates`;
        /// the two names for one concept were the defect, not the length.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FieldValues")]
        public Amazon.PartnerCentralMarketing.Model.FieldValueInput[] FieldValue { get; set; }
        #endregion
        
        #region Parameter Layout
        /// <summary>
        /// <para>
        /// Selects a multi-layout asset's layout: one of the
        /// values in `CampaignAsset.layout.options`. PATCH: omitted leaves the selection unchanged,
        /// and there is no way to clear it. A value that is not one of the asset's options —
        /// or any value on a single-layout asset — is a plain `ValidationException`, and nothing
        /// in the call is applied. Every pinned field stays writable whichever layout is selected.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Layout { get; set; }
        #endregion
        
        #region Parameter ScheduledSendAt
        /// <summary>
        /// <para>
        /// The send time, with `SendMode: SCHEDULED`
        /// and only then. See `SendMode`. Must be at least an hour out (`SEND_WINDOW_TOO_SOON`),
        /// unless it is the time already stored: resending the stored mode and time changes nothing
        /// and is accepted, so a form that always resubmits does not trip the window. Must also
        /// fall on or before the campaign's `EndOn` (by the end of that UTC day): refused with
        /// `ValidationException` (`INVALID_VALUE`) otherwise, so nothing is scheduled to send
        /// after the campaign completes. Was `scheduleDate`, a `YYYY-MM-DD` string. Retyped because
        /// a date alone cannot express a send *time*, which is the whole point of a schedule
        /// — and because the resource already spelled the same concept `ScheduledSendAt` on the
        /// activation responses. Two spellings of one concept on one resource was the defect.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ScheduledSendAt { get; set; }
        #endregion
        
        #region Parameter SendMode
        /// <summary>
        /// <para>
        /// When a **sendable** asset (`EMAIL`, `SOCIAL_POST`)
        /// sends: on activation, or at `ScheduledSendAt`. A mode beside a value rather than a
        /// union, on purpose: `ScheduledSendAt` stays a plain `Timestamp`, and the precedent
        /// is EventBridge Scheduler's `FlexibleTimeWindow { Mode, MaximumWindowInMinutes }`.
        /// The pair is checked as one, and a request where they disagree is refused with `ValidationException`
        /// (`INVALID_VALUE`, naming the member) and applies nothing: - `SCHEDULED` requires `ScheduledSendAt`;
        /// a reschedule resends `SCHEDULED` with the new time; - `ON_ACTIVATION` forbids `ScheduledSendAt`,
        /// and drops any time already stored; - `ScheduledSendAt` without `SendMode` is refused.
        /// PATCH: omitted leaves both unchanged. Until a mode is chosen the asset reports `SEND_MODE_MISSING`
        /// and does not activate: no default, because an unchosen send mails the real audience.
        /// Rejected with `ValidationException` (`NOT_SUPPORTED_FOR_CATEGORY`) for a category
        /// that has no send (`LANDING_PAGE`, `DOCUMENT`, `BANNER_AD`). Like every other edit,
        /// it reaches the delivery platform at the asset's next activation, and a live email
        /// or social post refuses it (`ASSET_ALREADY_ACTIVE`): deactivate first.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralMarketing.SendMode")]
        public Amazon.PartnerCentralMarketing.SendMode SendMode { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// Idempotency token. Retry-safety only — this
        /// is **not** a concurrency token, and sequential edits to one field are last-writer-wins.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralMarketing.Model.UpdateCampaignAssetResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralMarketing.Model.UpdateCampaignAssetResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CampaignAssetIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PCMGCampaignAsset (UpdateCampaignAsset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralMarketing.Model.UpdateCampaignAssetResponse, UpdatePCMGCampaignAssetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CampaignAssetIdentifier = this.CampaignAssetIdentifier;
            #if MODULAR
            if (this.CampaignAssetIdentifier == null && ParameterWasBound(nameof(this.CampaignAssetIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter CampaignAssetIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CampaignIdentifier = this.CampaignIdentifier;
            #if MODULAR
            if (this.CampaignIdentifier == null && ParameterWasBound(nameof(this.CampaignIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter CampaignIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            if (this.FieldValue != null)
            {
                context.FieldValue = new List<Amazon.PartnerCentralMarketing.Model.FieldValueInput>(this.FieldValue);
            }
            context.Layout = this.Layout;
            context.ScheduledSendAt = this.ScheduledSendAt;
            context.SendMode = this.SendMode;
            
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
            var request = new Amazon.PartnerCentralMarketing.Model.UpdateCampaignAssetRequest();
            
            if (cmdletContext.CampaignAssetIdentifier != null)
            {
                request.CampaignAssetIdentifier = cmdletContext.CampaignAssetIdentifier;
            }
            if (cmdletContext.CampaignIdentifier != null)
            {
                request.CampaignIdentifier = cmdletContext.CampaignIdentifier;
            }
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.FieldValue != null)
            {
                request.FieldValues = cmdletContext.FieldValue;
            }
            if (cmdletContext.Layout != null)
            {
                request.Layout = cmdletContext.Layout;
            }
            if (cmdletContext.ScheduledSendAt != null)
            {
                request.ScheduledSendAt = cmdletContext.ScheduledSendAt.Value;
            }
            if (cmdletContext.SendMode != null)
            {
                request.SendMode = cmdletContext.SendMode;
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
        
        private Amazon.PartnerCentralMarketing.Model.UpdateCampaignAssetResponse CallAWSServiceOperation(IAmazonPartnerCentralMarketing client, Amazon.PartnerCentralMarketing.Model.UpdateCampaignAssetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Marketing API", "UpdateCampaignAsset");
            try
            {
                return client.UpdateCampaignAssetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CampaignAssetIdentifier { get; set; }
            public System.String CampaignIdentifier { get; set; }
            public Amazon.PartnerCentralMarketing.Catalog Catalog { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.PartnerCentralMarketing.Model.FieldValueInput> FieldValue { get; set; }
            public System.String Layout { get; set; }
            public System.DateTime? ScheduledSendAt { get; set; }
            public Amazon.PartnerCentralMarketing.SendMode SendMode { get; set; }
            public System.Func<Amazon.PartnerCentralMarketing.Model.UpdateCampaignAssetResponse, UpdatePCMGCampaignAssetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
