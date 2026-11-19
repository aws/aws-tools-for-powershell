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
    /// Edits a campaign in place. Partial update: an omitted field is left unchanged, which
    /// is the standard meaning of an `Update` verb — a full replacement would be a `Put`.
    /// Change-only, with no way to clear a field back to empty, because the campaign's file
    /// members cannot round-trip: they are written as an `s3://` reference and read back
    /// as a URL or as metadata, so a replacement payload could not resend an unchanged recipient
    /// list without re-uploading it. Refused while an activation task runs (`CAMPAIGN_ACTIVATION_IN_PROGRESS`)
    /// and once the campaign is completed (`CAMPAIGN_COMPLETED`, the UTC date is after its
    /// `EndOn`). Last-writer-wins, with no concurrency token: this is low-contention metadata
    /// owned by one partner.
    /// </summary>
    [Cmdlet("Update", "PCMGCampaign", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Partner Central Marketing API UpdateCampaign API operation.", Operation = new[] {"UpdateCampaign"}, SelectReturnType = typeof(Amazon.PartnerCentralMarketing.Model.UpdateCampaignResponse))]
    [AWSCmdletOutput("System.String or Amazon.PartnerCentralMarketing.Model.UpdateCampaignResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.PartnerCentralMarketing.Model.UpdateCampaignResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePCMGCampaignCmdlet : AmazonPartnerCentralMarketingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EstimatedBudget_Amount
        /// <summary>
        /// <para>
        /// The amount, as a decimal string with at most two
        /// decimal places.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EstimatedBudget_Amount { get; set; }
        #endregion
        
        #region Parameter TotalBudget_Amount
        /// <summary>
        /// <para>
        /// The amount, as a decimal string with at most two
        /// decimal places.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TotalBudget_Amount { get; set; }
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
        
        #region Parameter TargetAudience_CompanySize
        /// <summary>
        /// <para>
        /// Target company sizes.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAudience_CompanySizes")]
        public System.String[] TargetAudience_CompanySize { get; set; }
        #endregion
        
        #region Parameter TargetAudience_Country
        /// <summary>
        /// <para>
        /// Target countries, as ISO 3166-1 alpha-2 codes.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAudience_Countries")]
        public System.String[] TargetAudience_Country { get; set; }
        #endregion
        
        #region Parameter EstimatedBudget_CurrencyCode
        /// <summary>
        /// <para>
        /// The ISO 4217 currency the amount is denominated
        /// in.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EstimatedBudget_CurrencyCode { get; set; }
        #endregion
        
        #region Parameter TotalBudget_CurrencyCode
        /// <summary>
        /// <para>
        /// The ISO 4217 currency the amount is denominated
        /// in.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TotalBudget_CurrencyCode { get; set; }
        #endregion
        
        #region Parameter EmailTargetEngagementGroupId
        /// <summary>
        /// <para>
        /// Engagement groups whose
        /// contacts the campaign's emails will also go to (see `CreateCampaign`). Replaces the
        /// stored list; never clears it. 
        /// &lt;para&gt;
        /// As on `CreateCampaign`: each group once (`INVALID_VALUE` otherwise), not checked against
        /// your groups when saved, and resolved at Start where the stage can (`ENGAGEMENT_GROUPS_UNAVAILABLE`
        /// where it can't).
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailTargetEngagementGroupIds")]
        public System.String[] EmailTargetEngagementGroupId { get; set; }
        #endregion
        
        #region Parameter EndOn
        /// <summary>
        /// <para>
        /// The last day of the campaign's run window, inclusive
        /// and in UTC. Editable only while the campaign is open, like everything else here: once
        /// the stored `EndOn` has passed the campaign is completed and this update is refused
        /// (`CAMPAIGN_COMPLETED`). Refused with `ValidationException` (`INVALID_VALUE`) when
        /// it is in the past, or earlier than the day of a scheduled send on one of the campaign's
        /// assets: move or cancel that send first. Setting it to today ends the campaign at the
        /// next UTC midnight.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndOn { get; set; }
        #endregion
        
        #region Parameter TargetAudience_Industry
        /// <summary>
        /// <para>
        /// Target industries.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAudience_Industries")]
        public System.String[] TargetAudience_Industry { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The display name.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PartnerAddress
        /// <summary>
        /// <para>
        /// Sets or replaces the partner's postal address.
        /// Replaces, never clears.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PartnerAddress { get; set; }
        #endregion
        
        #region Parameter PrivacyPolicyUrl
        /// <summary>
        /// <para>
        /// Sets or replaces the URL of the partner's
        /// privacy policy. Replaces, never clears.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrivacyPolicyUrl { get; set; }
        #endregion
        
        #region Parameter EmailTarget_S3Uri
        /// <summary>
        /// <para>
        /// The `s3://` location of the file.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailTarget_S3Uri { get; set; }
        #endregion
        
        #region Parameter PartnerBadge_S3Uri
        /// <summary>
        /// <para>
        /// The `s3://` location of the file.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PartnerBadge_S3Uri { get; set; }
        #endregion
        
        #region Parameter SenderEmail
        /// <summary>
        /// <para>
        /// Sets or replaces the address the campaign's
        /// emails are sent from. Checked by the same three rules as on `CreateCampaign`, with
        /// the same codes, but only when it differs, ignoring case, from the stored sender: re-sending
        /// the stored one is not checked, and `StartCampaignAssetActivationTask` re-checks it
        /// before an email activates. 
        /// &lt;para&gt;
        /// Replaces, never clears: like every member of this operation, an omitted value leaves
        /// the sender as it was, and there is no way to remove one once set.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SenderEmail { get; set; }
        #endregion
        
        #region Parameter SocialConnection
        /// <summary>
        /// <para>
        /// Sets the account the campaign's social
        /// posts publish from, per platform. Each platform named replaces that platform's choice;
        /// a platform not named keeps its own. Replaces, never clears. 
        /// &lt;para&gt;
        /// Not checked against your connections here: a connection can be deleted at any time,
        /// so the activation checks the choice. See `Campaign$SocialConnections`.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SocialConnections")]
        public System.Collections.Hashtable SocialConnection { get; set; }
        #endregion
        
        #region Parameter StartOn
        /// <summary>
        /// <para>
        /// The first day of the campaign's run window. Not
        /// after `EndOn` (`ValidationException`, `INVALID_VALUE`).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartOn { get; set; }
        #endregion
        
        #region Parameter EmailTarget_VersionId
        /// <summary>
        /// <para>
        /// The version of the object to take: the `VersionId`
        /// the staging upload returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailTarget_VersionId { get; set; }
        #endregion
        
        #region Parameter PartnerBadge_VersionId
        /// <summary>
        /// <para>
        /// The version of the object to take: the `VersionId`
        /// the staging upload returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PartnerBadge_VersionId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// Idempotency token. Accepted and not stored:
        /// this is a change-only partial update with last-writer-wins, so re-applying the same
        /// call produces the same result and the same response. There is nothing a replay cache
        /// would protect.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Id'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralMarketing.Model.UpdateCampaignResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralMarketing.Model.UpdateCampaignResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Id";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CampaignIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PCMGCampaign (UpdateCampaign)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralMarketing.Model.UpdateCampaignResponse, UpdatePCMGCampaignCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.EmailTarget_S3Uri = this.EmailTarget_S3Uri;
            context.EmailTarget_VersionId = this.EmailTarget_VersionId;
            if (this.EmailTargetEngagementGroupId != null)
            {
                context.EmailTargetEngagementGroupId = new List<System.String>(this.EmailTargetEngagementGroupId);
            }
            context.EndOn = this.EndOn;
            context.EstimatedBudget_Amount = this.EstimatedBudget_Amount;
            context.EstimatedBudget_CurrencyCode = this.EstimatedBudget_CurrencyCode;
            context.Name = this.Name;
            context.PartnerAddress = this.PartnerAddress;
            context.PartnerBadge_S3Uri = this.PartnerBadge_S3Uri;
            context.PartnerBadge_VersionId = this.PartnerBadge_VersionId;
            context.PrivacyPolicyUrl = this.PrivacyPolicyUrl;
            context.SenderEmail = this.SenderEmail;
            if (this.SocialConnection != null)
            {
                context.SocialConnection = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.SocialConnection.Keys)
                {
                    object hashValue = this.SocialConnection[hashKey];
                    if (hashValue == null)
                    {
                        context.SocialConnection.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.SocialConnection.Add((String)hashKey, valueSet);
                }
            }
            context.StartOn = this.StartOn;
            if (this.TargetAudience_CompanySize != null)
            {
                context.TargetAudience_CompanySize = new List<System.String>(this.TargetAudience_CompanySize);
            }
            if (this.TargetAudience_Country != null)
            {
                context.TargetAudience_Country = new List<System.String>(this.TargetAudience_Country);
            }
            if (this.TargetAudience_Industry != null)
            {
                context.TargetAudience_Industry = new List<System.String>(this.TargetAudience_Industry);
            }
            context.TotalBudget_Amount = this.TotalBudget_Amount;
            context.TotalBudget_CurrencyCode = this.TotalBudget_CurrencyCode;
            
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
            var request = new Amazon.PartnerCentralMarketing.Model.UpdateCampaignRequest();
            
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
            
             // populate EmailTarget
            var requestEmailTargetIsNull = true;
            request.EmailTarget = new Amazon.PartnerCentralMarketing.Model.FileRef();
            System.String requestEmailTarget_emailTarget_S3Uri = null;
            if (cmdletContext.EmailTarget_S3Uri != null)
            {
                requestEmailTarget_emailTarget_S3Uri = cmdletContext.EmailTarget_S3Uri;
            }
            if (requestEmailTarget_emailTarget_S3Uri != null)
            {
                request.EmailTarget.S3Uri = requestEmailTarget_emailTarget_S3Uri;
                requestEmailTargetIsNull = false;
            }
            System.String requestEmailTarget_emailTarget_VersionId = null;
            if (cmdletContext.EmailTarget_VersionId != null)
            {
                requestEmailTarget_emailTarget_VersionId = cmdletContext.EmailTarget_VersionId;
            }
            if (requestEmailTarget_emailTarget_VersionId != null)
            {
                request.EmailTarget.VersionId = requestEmailTarget_emailTarget_VersionId;
                requestEmailTargetIsNull = false;
            }
             // determine if request.EmailTarget should be set to null
            if (requestEmailTargetIsNull)
            {
                request.EmailTarget = null;
            }
            if (cmdletContext.EmailTargetEngagementGroupId != null)
            {
                request.EmailTargetEngagementGroupIds = cmdletContext.EmailTargetEngagementGroupId;
            }
            if (cmdletContext.EndOn != null)
            {
                request.EndOn = cmdletContext.EndOn;
            }
            
             // populate EstimatedBudget
            var requestEstimatedBudgetIsNull = true;
            request.EstimatedBudget = new Amazon.PartnerCentralMarketing.Model.MonetaryValue();
            System.String requestEstimatedBudget_estimatedBudget_Amount = null;
            if (cmdletContext.EstimatedBudget_Amount != null)
            {
                requestEstimatedBudget_estimatedBudget_Amount = cmdletContext.EstimatedBudget_Amount;
            }
            if (requestEstimatedBudget_estimatedBudget_Amount != null)
            {
                request.EstimatedBudget.Amount = requestEstimatedBudget_estimatedBudget_Amount;
                requestEstimatedBudgetIsNull = false;
            }
            System.String requestEstimatedBudget_estimatedBudget_CurrencyCode = null;
            if (cmdletContext.EstimatedBudget_CurrencyCode != null)
            {
                requestEstimatedBudget_estimatedBudget_CurrencyCode = cmdletContext.EstimatedBudget_CurrencyCode;
            }
            if (requestEstimatedBudget_estimatedBudget_CurrencyCode != null)
            {
                request.EstimatedBudget.CurrencyCode = requestEstimatedBudget_estimatedBudget_CurrencyCode;
                requestEstimatedBudgetIsNull = false;
            }
             // determine if request.EstimatedBudget should be set to null
            if (requestEstimatedBudgetIsNull)
            {
                request.EstimatedBudget = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PartnerAddress != null)
            {
                request.PartnerAddress = cmdletContext.PartnerAddress;
            }
            
             // populate PartnerBadge
            var requestPartnerBadgeIsNull = true;
            request.PartnerBadge = new Amazon.PartnerCentralMarketing.Model.FileRef();
            System.String requestPartnerBadge_partnerBadge_S3Uri = null;
            if (cmdletContext.PartnerBadge_S3Uri != null)
            {
                requestPartnerBadge_partnerBadge_S3Uri = cmdletContext.PartnerBadge_S3Uri;
            }
            if (requestPartnerBadge_partnerBadge_S3Uri != null)
            {
                request.PartnerBadge.S3Uri = requestPartnerBadge_partnerBadge_S3Uri;
                requestPartnerBadgeIsNull = false;
            }
            System.String requestPartnerBadge_partnerBadge_VersionId = null;
            if (cmdletContext.PartnerBadge_VersionId != null)
            {
                requestPartnerBadge_partnerBadge_VersionId = cmdletContext.PartnerBadge_VersionId;
            }
            if (requestPartnerBadge_partnerBadge_VersionId != null)
            {
                request.PartnerBadge.VersionId = requestPartnerBadge_partnerBadge_VersionId;
                requestPartnerBadgeIsNull = false;
            }
             // determine if request.PartnerBadge should be set to null
            if (requestPartnerBadgeIsNull)
            {
                request.PartnerBadge = null;
            }
            if (cmdletContext.PrivacyPolicyUrl != null)
            {
                request.PrivacyPolicyUrl = cmdletContext.PrivacyPolicyUrl;
            }
            if (cmdletContext.SenderEmail != null)
            {
                request.SenderEmail = cmdletContext.SenderEmail;
            }
            if (cmdletContext.SocialConnection != null)
            {
                request.SocialConnections = cmdletContext.SocialConnection;
            }
            if (cmdletContext.StartOn != null)
            {
                request.StartOn = cmdletContext.StartOn;
            }
            
             // populate TargetAudience
            var requestTargetAudienceIsNull = true;
            request.TargetAudience = new Amazon.PartnerCentralMarketing.Model.TargetAudience();
            List<System.String> requestTargetAudience_targetAudience_CompanySize = null;
            if (cmdletContext.TargetAudience_CompanySize != null)
            {
                requestTargetAudience_targetAudience_CompanySize = cmdletContext.TargetAudience_CompanySize;
            }
            if (requestTargetAudience_targetAudience_CompanySize != null)
            {
                request.TargetAudience.CompanySizes = requestTargetAudience_targetAudience_CompanySize;
                requestTargetAudienceIsNull = false;
            }
            List<System.String> requestTargetAudience_targetAudience_Country = null;
            if (cmdletContext.TargetAudience_Country != null)
            {
                requestTargetAudience_targetAudience_Country = cmdletContext.TargetAudience_Country;
            }
            if (requestTargetAudience_targetAudience_Country != null)
            {
                request.TargetAudience.Countries = requestTargetAudience_targetAudience_Country;
                requestTargetAudienceIsNull = false;
            }
            List<System.String> requestTargetAudience_targetAudience_Industry = null;
            if (cmdletContext.TargetAudience_Industry != null)
            {
                requestTargetAudience_targetAudience_Industry = cmdletContext.TargetAudience_Industry;
            }
            if (requestTargetAudience_targetAudience_Industry != null)
            {
                request.TargetAudience.Industries = requestTargetAudience_targetAudience_Industry;
                requestTargetAudienceIsNull = false;
            }
             // determine if request.TargetAudience should be set to null
            if (requestTargetAudienceIsNull)
            {
                request.TargetAudience = null;
            }
            
             // populate TotalBudget
            var requestTotalBudgetIsNull = true;
            request.TotalBudget = new Amazon.PartnerCentralMarketing.Model.MonetaryValue();
            System.String requestTotalBudget_totalBudget_Amount = null;
            if (cmdletContext.TotalBudget_Amount != null)
            {
                requestTotalBudget_totalBudget_Amount = cmdletContext.TotalBudget_Amount;
            }
            if (requestTotalBudget_totalBudget_Amount != null)
            {
                request.TotalBudget.Amount = requestTotalBudget_totalBudget_Amount;
                requestTotalBudgetIsNull = false;
            }
            System.String requestTotalBudget_totalBudget_CurrencyCode = null;
            if (cmdletContext.TotalBudget_CurrencyCode != null)
            {
                requestTotalBudget_totalBudget_CurrencyCode = cmdletContext.TotalBudget_CurrencyCode;
            }
            if (requestTotalBudget_totalBudget_CurrencyCode != null)
            {
                request.TotalBudget.CurrencyCode = requestTotalBudget_totalBudget_CurrencyCode;
                requestTotalBudgetIsNull = false;
            }
             // determine if request.TotalBudget should be set to null
            if (requestTotalBudgetIsNull)
            {
                request.TotalBudget = null;
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
        
        private Amazon.PartnerCentralMarketing.Model.UpdateCampaignResponse CallAWSServiceOperation(IAmazonPartnerCentralMarketing client, Amazon.PartnerCentralMarketing.Model.UpdateCampaignRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Marketing API", "UpdateCampaign");
            try
            {
                return client.UpdateCampaignAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CampaignIdentifier { get; set; }
            public Amazon.PartnerCentralMarketing.Catalog Catalog { get; set; }
            public System.String ClientToken { get; set; }
            public System.String EmailTarget_S3Uri { get; set; }
            public System.String EmailTarget_VersionId { get; set; }
            public List<System.String> EmailTargetEngagementGroupId { get; set; }
            public System.String EndOn { get; set; }
            public System.String EstimatedBudget_Amount { get; set; }
            public System.String EstimatedBudget_CurrencyCode { get; set; }
            public System.String Name { get; set; }
            public System.String PartnerAddress { get; set; }
            public System.String PartnerBadge_S3Uri { get; set; }
            public System.String PartnerBadge_VersionId { get; set; }
            public System.String PrivacyPolicyUrl { get; set; }
            public System.String SenderEmail { get; set; }
            public Dictionary<System.String, List<System.String>> SocialConnection { get; set; }
            public System.String StartOn { get; set; }
            public List<System.String> TargetAudience_CompanySize { get; set; }
            public List<System.String> TargetAudience_Country { get; set; }
            public List<System.String> TargetAudience_Industry { get; set; }
            public System.String TotalBudget_Amount { get; set; }
            public System.String TotalBudget_CurrencyCode { get; set; }
            public System.Func<Amazon.PartnerCentralMarketing.Model.UpdateCampaignResponse, UpdatePCMGCampaignCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Id;
        }
        
    }
}
