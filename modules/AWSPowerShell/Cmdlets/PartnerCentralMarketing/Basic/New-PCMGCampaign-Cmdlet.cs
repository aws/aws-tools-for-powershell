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
    /// Creates a new marketing campaign. Returns the identity of the new campaign, not the
    /// campaign. Growing a response is backward compatible and shrinking one is not, and
    /// the caller's next step is a `GetCampaign` anyway — a write that supplies an audience
    /// cannot report its scan verdict, because that is decided after it commits.
    /// </summary>
    [Cmdlet("New", "PCMGCampaign", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralMarketing.Model.CreateCampaignResponse")]
    [AWSCmdlet("Calls the Partner Central Marketing API CreateCampaign API operation.", Operation = new[] {"CreateCampaign"}, SelectReturnType = typeof(Amazon.PartnerCentralMarketing.Model.CreateCampaignResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralMarketing.Model.CreateCampaignResponse",
        "This cmdlet returns an Amazon.PartnerCentralMarketing.Model.CreateCampaignResponse object containing multiple properties."
    )]
    public partial class NewPCMGCampaignCmdlet : AmazonPartnerCentralMarketingClientCmdlet, IExecutor
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
        
        #region Parameter CampaignTemplateId
        /// <summary>
        /// <para>
        /// The campaign template this campaign
        /// draws its assets from. 
        /// &lt;para&gt;
        /// Binds the campaign to a single source template: every asset must come from this template's
        /// asset templates, and one from another template is refused at `BatchCreateCampaignAsset`.
        /// Immutable once set. Every campaign has one: a campaign's language and its assets'
        /// blueprints both come from its template. 
        /// &lt;para&gt;
        /// Templates are AWS-authored and read-only — they are discovered through `SearchCampaignTemplates`
        /// and `GetCampaignTemplate`, and there is no create, update or delete operation for
        /// one. 
        /// &lt;para&gt;
        /// The template's id only: a campaign template has no ARN (DG-084). The member keeps
        /// the `&lt;Resource&gt;Id` name, which is the convention for referencing another resource
        /// from a body.
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
        public System.String CampaignTemplateId { get; set; }
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
        /// contacts the campaign's emails will also go to: the `Id`s `ListEngagementGroups` returns
        /// (AWS Partner Central Selling). 1–10, each named once. 
        /// &lt;para&gt;
        /// Each group is named once: a repeated id is refused with field code `INVALID_VALUE`.
        /// Not checked against your groups when saved. StartCampaignAssetActivationTask resolves
        /// them to recipients. On a stage that can't resolve groups yet, Start refuses an email
        /// while groups are set (`ENGAGEMENT_GROUPS_UNAVAILABLE`), rather than send to `EmailTarget`
        /// alone.
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
        /// and in UTC. Not in the past: the campaign completes at the UTC midnight after it (see
        /// `CampaignState`). A scheduled send must fall on or before it. Optional here, but required
        /// before any asset activates: until it is set, GetCampaign's `ActivationIssues` reports
        /// `END_ON_MISSING` and StartCampaignAssetActivationTask refuses (`CAMPAIGN_INCOMPLETE`).
        /// Set it with UpdateCampaign.
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PartnerAddress
        /// <summary>
        /// <para>
        /// The partner's physical postal address,
        /// shown in every email footer and as a landing page's contact line. Optional here: an
        /// email that shows it cannot activate until one is set. A landing page that shows it
        /// publishes it empty when it is unset, and a document's footer then prints the partner's
        /// name alone.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PartnerAddress { get; set; }
        #endregion
        
        #region Parameter PrivacyPolicyUrl
        /// <summary>
        /// <para>
        /// The URL of the partner's privacy policy,
        /// linked from every email and landing page footer. Optional here: a campaign whose emails
        /// or landing pages show it cannot activate them until one is set.
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
        /// The address every email of this campaign is
        /// sent from. 
        /// &lt;para&gt;
        /// Printable ASCII only, with no spaces or line breaks, or field code `PATTERN_MISMATCH`.
        /// Then three rules, all checked when the sender is set. Its domain must exactly match,
        /// ignoring case, the domain of the partner's alliance lead email in AWS Partner Central
        /// (a subdomain does not), or field code `SENDER_DOMAIN_NOT_ALLIANCE_LEAD`. Then, for
        /// a sender at example.com, DNS must hold the CNAME `dkim._domainkey.example.com` → `dkim._domainkey.md02.com`
        /// (field code `SENDER_DOMAIN_DKIM_MISSING`) and a DMARC record, one TXT `_dmarc.example.com`
        /// starting `v=DMARC1` with a `p` of `none`, `quarantine` or `reject` (field code `SENDER_DOMAIN_DMARC_MISSING`).
        /// Both DNS codes are reported together when both records are missing. 
        /// &lt;para&gt;
        /// A partner who can't satisfy them can't set a sender, so can't run email campaigns.
        /// A shared mail provider's domain, such as gmail.com, can't carry the records. Optional
        /// here: a campaign with no sender can be created and edited, but its email assets cannot
        /// be activated until one is set.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SenderEmail { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// Tags to apply at creation. Tag-on-create rather than
        /// create-then-tag is a Tagris requirement, not a convenience: it is what lets a tag-based
        /// access control policy govern the creation itself. A campaign created untagged and
        /// tagged a moment later is briefly outside any such policy. 
        /// &lt;para&gt;
        /// A key beginning `aws:` (any case) is reserved for AWS-applied system tags and is refused
        /// with `ValidationException`, as is a key repeated in the list; nothing is created.
        /// The tags are recorded before the campaign is written, so a create that cannot record
        /// them fails and creates nothing. A retry with the same `ClientToken` returns the campaign
        /// the first attempt created and does not re-apply tags — use `TagResource` to change
        /// them afterwards. `ListTagsForResource` returns them.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.PartnerCentralMarketing.Model.Tag[] Tag { get; set; }
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
        /// Idempotency token. Same token within 24h returns
        /// existing resource.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralMarketing.Model.CreateCampaignResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralMarketing.Model.CreateCampaignResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CampaignTemplateId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCMGCampaign (CreateCampaign)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralMarketing.Model.CreateCampaignResponse, NewPCMGCampaignCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CampaignTemplateId = this.CampaignTemplateId;
            #if MODULAR
            if (this.CampaignTemplateId == null && ParameterWasBound(nameof(this.CampaignTemplateId)))
            {
                WriteWarning("You are passing $null as a value for parameter CampaignTemplateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PartnerAddress = this.PartnerAddress;
            context.PartnerBadge_S3Uri = this.PartnerBadge_S3Uri;
            context.PartnerBadge_VersionId = this.PartnerBadge_VersionId;
            context.PrivacyPolicyUrl = this.PrivacyPolicyUrl;
            context.SenderEmail = this.SenderEmail;
            context.StartOn = this.StartOn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.PartnerCentralMarketing.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.PartnerCentralMarketing.Model.CreateCampaignRequest();
            
            if (cmdletContext.CampaignTemplateId != null)
            {
                request.CampaignTemplateId = cmdletContext.CampaignTemplateId;
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
            if (cmdletContext.StartOn != null)
            {
                request.StartOn = cmdletContext.StartOn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.PartnerCentralMarketing.Model.CreateCampaignResponse CallAWSServiceOperation(IAmazonPartnerCentralMarketing client, Amazon.PartnerCentralMarketing.Model.CreateCampaignRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Marketing API", "CreateCampaign");
            try
            {
                return client.CreateCampaignAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CampaignTemplateId { get; set; }
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
            public System.String StartOn { get; set; }
            public List<Amazon.PartnerCentralMarketing.Model.Tag> Tag { get; set; }
            public List<System.String> TargetAudience_CompanySize { get; set; }
            public List<System.String> TargetAudience_Country { get; set; }
            public List<System.String> TargetAudience_Industry { get; set; }
            public System.String TotalBudget_Amount { get; set; }
            public System.String TotalBudget_CurrencyCode { get; set; }
            public System.Func<Amazon.PartnerCentralMarketing.Model.CreateCampaignResponse, NewPCMGCampaignCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
