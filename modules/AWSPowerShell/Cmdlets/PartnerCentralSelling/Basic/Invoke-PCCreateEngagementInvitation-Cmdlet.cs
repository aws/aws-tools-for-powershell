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
using Amazon.PartnerCentralSelling;
using Amazon.PartnerCentralSelling.Model;

namespace Amazon.PowerShell.Cmdlets.PC
{
    /// <summary>
    /// This action creates an invitation from a sender to a single receiver to join an engagement.
    /// </summary>
    [Cmdlet("Invoke", "PCCreateEngagementInvitation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralSelling.Model.CreateEngagementInvitationResponse")]
    [AWSCmdlet("Calls the Partner Central Selling API CreateEngagementInvitation API operation.", Operation = new[] {"CreateEngagementInvitation"}, SelectReturnType = typeof(Amazon.PartnerCentralSelling.Model.CreateEngagementInvitationResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralSelling.Model.CreateEngagementInvitationResponse",
        "This cmdlet returns an Amazon.PartnerCentralSelling.Model.CreateEngagementInvitationResponse object containing multiple properties."
    )]
    public partial class InvokePCCreateEngagementInvitationCmdlet : AmazonPartnerCentralSellingClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Account_Alias
        /// <summary>
        /// <para>
        /// <para>Represents the alias of the partner account receiving the Engagement Invitation, making
        /// it easier to identify and track the recipient in reports or logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Receiver_Account_Alias")]
        public System.String Account_Alias { get; set; }
        #endregion
        
        #region Parameter Account_AwsAccountId
        /// <summary>
        /// <para>
        /// <para>Indicates the AWS account ID of the partner who received the Engagement Invitation.
        /// This is a unique identifier for managing engagements with specific AWS accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Receiver_Account_AwsAccountId")]
        public System.String Account_AwsAccountId { get; set; }
        #endregion
        
        #region Parameter Customer_AwsMaturity
        /// <summary>
        /// <para>
        /// <para>Indicates the customer's level of experience and adoption with AWS services. This
        /// assessment helps partners understand the customer's cloud maturity and tailor their
        /// engagement approach accordingly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_LeadInvitation_Customer_AwsMaturity")]
        public System.String Customer_AwsMaturity { get; set; }
        #endregion
        
        #region Parameter Project_BusinessProblem
        /// <summary>
        /// <para>
        /// <para>Describes the business problem that the project aims to solve. This information is
        /// crucial for understanding the project’s goals and objectives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_OpportunityInvitation_Project_BusinessProblem")]
        public System.String Project_BusinessProblem { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para> Specifies the catalog related to the engagement. Accepted values are <c>AWS</c> and
        /// <c>Sandbox</c>, which determine the environment in which the engagement is managed.
        /// </para>
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
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter LeadInvitation_Customer_CompanyName
        /// <summary>
        /// <para>
        /// <para>The name of the customer company associated with the lead invitation. This field identifies
        /// the target organization for the lead engagement opportunity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_LeadInvitation_Customer_CompanyName")]
        public System.String LeadInvitation_Customer_CompanyName { get; set; }
        #endregion
        
        #region Parameter Invitation_Payload_OpportunityInvitation_Customer_CompanyName
        /// <summary>
        /// <para>
        /// <para>Represents the name of the customer’s company associated with the Engagement Invitation.
        /// This field is used to identify the customer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_CompanyName")]
        public System.String Invitation_Payload_OpportunityInvitation_Customer_CompanyName { get; set; }
        #endregion
        
        #region Parameter Interaction_ContactBusinessTitle
        /// <summary>
        /// <para>
        /// <para>The business title or job role of the customer contact involved in the lead interaction.
        /// This helps partners identify the decision-making level and engagement approach for
        /// the lead.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_LeadInvitation_Interaction_ContactBusinessTitle")]
        public System.String Interaction_ContactBusinessTitle { get; set; }
        #endregion
        
        #region Parameter LeadInvitation_Customer_CountryCode
        /// <summary>
        /// <para>
        /// <para>The country code indicating the geographic location of the customer company. This
        /// information helps partners understand regional requirements and assess their ability
        /// to serve the customer effectively.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_LeadInvitation_Customer_CountryCode")]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.CountryCode")]
        public Amazon.PartnerCentralSelling.CountryCode LeadInvitation_Customer_CountryCode { get; set; }
        #endregion
        
        #region Parameter Invitation_Payload_OpportunityInvitation_Customer_CountryCode
        /// <summary>
        /// <para>
        /// <para>Indicates the country in which the customer’s company operates. This field is useful
        /// for understanding regional requirements or compliance needs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_CountryCode")]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.CountryCode")]
        public Amazon.PartnerCentralSelling.CountryCode Invitation_Payload_OpportunityInvitation_Customer_CountryCode { get; set; }
        #endregion
        
        #region Parameter EngagementIdentifier
        /// <summary>
        /// <para>
        /// <para> The unique identifier of the <c>Engagement</c> associated with the invitation. This
        /// parameter ensures the invitation is created within the correct <c>Engagement</c> context.
        /// </para>
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
        public System.String EngagementIdentifier { get; set; }
        #endregion
        
        #region Parameter Project_ExpectedCustomerSpend
        /// <summary>
        /// <para>
        /// <para>Contains revenue estimates for the partner related to the project. This field provides
        /// an idea of the financial potential of the opportunity for the partner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_OpportunityInvitation_Project_ExpectedCustomerSpend")]
        public Amazon.PartnerCentralSelling.Model.ExpectedCustomerSpend[] Project_ExpectedCustomerSpend { get; set; }
        #endregion
        
        #region Parameter LeadInvitation_Customer_Industry
        /// <summary>
        /// <para>
        /// <para>Specifies the industry sector of the customer company associated with the lead invitation.
        /// This categorization helps partners understand the customer's business context and
        /// assess solution fit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_LeadInvitation_Customer_Industry")]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.Industry")]
        public Amazon.PartnerCentralSelling.Industry LeadInvitation_Customer_Industry { get; set; }
        #endregion
        
        #region Parameter Invitation_Payload_OpportunityInvitation_Customer_Industry
        /// <summary>
        /// <para>
        /// <para>Specifies the industry to which the customer’s company belongs. This field helps categorize
        /// the opportunity based on the customer’s business sector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_Industry")]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.Industry")]
        public Amazon.PartnerCentralSelling.Industry Invitation_Payload_OpportunityInvitation_Customer_Industry { get; set; }
        #endregion
        
        #region Parameter Customer_MarketSegment
        /// <summary>
        /// <para>
        /// <para>Specifies the market segment classification of the customer, such as enterprise, mid-market,
        /// or small business. This segmentation helps partners determine the appropriate solution
        /// complexity and engagement strategy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_LeadInvitation_Customer_MarketSegment")]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.MarketSegment")]
        public Amazon.PartnerCentralSelling.MarketSegment Customer_MarketSegment { get; set; }
        #endregion
        
        #region Parameter Invitation_Message
        /// <summary>
        /// <para>
        /// <para> A message accompanying the invitation. </para>
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
        public System.String Invitation_Message { get; set; }
        #endregion
        
        #region Parameter OpportunityInvitation_ReceiverResponsibility
        /// <summary>
        /// <para>
        /// <para>Outlines the responsibilities or expectations of the receiver in the context of the
        /// invitation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_OpportunityInvitation_ReceiverResponsibilities")]
        public System.String[] OpportunityInvitation_ReceiverResponsibility { get; set; }
        #endregion
        
        #region Parameter OpportunityInvitation_SenderContact
        /// <summary>
        /// <para>
        /// <para>Represents the contact details of the AWS representatives involved in sending the
        /// Engagement Invitation. These contacts are opportunity stakeholders.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_OpportunityInvitation_SenderContacts")]
        public Amazon.PartnerCentralSelling.Model.SenderContact[] OpportunityInvitation_SenderContact { get; set; }
        #endregion
        
        #region Parameter Interaction_SourceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the specific source that generated the lead interaction.
        /// This provides traceability to the original lead generation activity for reference
        /// and follow-up purposes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_LeadInvitation_Interaction_SourceId")]
        public System.String Interaction_SourceId { get; set; }
        #endregion
        
        #region Parameter Interaction_SourceName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the source that generated the lead interaction. This human-readable
        /// identifier helps partners understand the specific lead generation channel or campaign
        /// that created the opportunity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_LeadInvitation_Interaction_SourceName")]
        public System.String Interaction_SourceName { get; set; }
        #endregion
        
        #region Parameter Interaction_SourceType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of source that generated the lead interaction, such as "Event",
        /// "Website", or "Campaign". This helps partners understand the lead generation channel
        /// and assess lead quality based on the source type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_LeadInvitation_Interaction_SourceType")]
        public System.String Interaction_SourceType { get; set; }
        #endregion
        
        #region Parameter Project_TargetCompletionDate
        /// <summary>
        /// <para>
        /// <para>Specifies the estimated date of project completion. This field helps track the project
        /// timeline and manage expectations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_OpportunityInvitation_Project_TargetCompletionDate")]
        public System.String Project_TargetCompletionDate { get; set; }
        #endregion
        
        #region Parameter Project_Title
        /// <summary>
        /// <para>
        /// <para>Specifies the title of the project. This title helps partners quickly identify and
        /// understand the focus of the project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_OpportunityInvitation_Project_Title")]
        public System.String Project_Title { get; set; }
        #endregion
        
        #region Parameter Interaction_Usecase
        /// <summary>
        /// <para>
        /// <para>Describes the specific use case or business scenario associated with the lead interaction.
        /// This information helps partners understand the customer's interests and potential
        /// solution requirements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_LeadInvitation_Interaction_Usecase")]
        public System.String Interaction_Usecase { get; set; }
        #endregion
        
        #region Parameter LeadInvitation_Customer_WebsiteUrl
        /// <summary>
        /// <para>
        /// <para>The website URL of the customer company. This provides additional context about the
        /// customer organization and helps partners verify company details and assess business
        /// size and legitimacy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_LeadInvitation_Customer_WebsiteUrl")]
        public System.String LeadInvitation_Customer_WebsiteUrl { get; set; }
        #endregion
        
        #region Parameter Invitation_Payload_OpportunityInvitation_Customer_WebsiteUrl
        /// <summary>
        /// <para>
        /// <para>Provides the website URL of the customer’s company. This field helps partners verify
        /// the legitimacy and size of the customer organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_WebsiteUrl")]
        public System.String Invitation_Payload_OpportunityInvitation_Customer_WebsiteUrl { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> Specifies a unique, client-generated UUID to ensure that the request is handled exactly
        /// once. This token helps prevent duplicate invitation creations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralSelling.Model.CreateEngagementInvitationResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralSelling.Model.CreateEngagementInvitationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EngagementIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EngagementIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EngagementIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EngagementIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-PCCreateEngagementInvitation (CreateEngagementInvitation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralSelling.Model.CreateEngagementInvitationResponse, InvokePCCreateEngagementInvitationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EngagementIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.EngagementIdentifier = this.EngagementIdentifier;
            #if MODULAR
            if (this.EngagementIdentifier == null && ParameterWasBound(nameof(this.EngagementIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EngagementIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Invitation_Message = this.Invitation_Message;
            #if MODULAR
            if (this.Invitation_Message == null && ParameterWasBound(nameof(this.Invitation_Message)))
            {
                WriteWarning("You are passing $null as a value for parameter Invitation_Message which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Customer_AwsMaturity = this.Customer_AwsMaturity;
            context.LeadInvitation_Customer_CompanyName = this.LeadInvitation_Customer_CompanyName;
            context.LeadInvitation_Customer_CountryCode = this.LeadInvitation_Customer_CountryCode;
            context.LeadInvitation_Customer_Industry = this.LeadInvitation_Customer_Industry;
            context.Customer_MarketSegment = this.Customer_MarketSegment;
            context.LeadInvitation_Customer_WebsiteUrl = this.LeadInvitation_Customer_WebsiteUrl;
            context.Interaction_ContactBusinessTitle = this.Interaction_ContactBusinessTitle;
            context.Interaction_SourceId = this.Interaction_SourceId;
            context.Interaction_SourceName = this.Interaction_SourceName;
            context.Interaction_SourceType = this.Interaction_SourceType;
            context.Interaction_Usecase = this.Interaction_Usecase;
            context.Invitation_Payload_OpportunityInvitation_Customer_CompanyName = this.Invitation_Payload_OpportunityInvitation_Customer_CompanyName;
            context.Invitation_Payload_OpportunityInvitation_Customer_CountryCode = this.Invitation_Payload_OpportunityInvitation_Customer_CountryCode;
            context.Invitation_Payload_OpportunityInvitation_Customer_Industry = this.Invitation_Payload_OpportunityInvitation_Customer_Industry;
            context.Invitation_Payload_OpportunityInvitation_Customer_WebsiteUrl = this.Invitation_Payload_OpportunityInvitation_Customer_WebsiteUrl;
            context.Project_BusinessProblem = this.Project_BusinessProblem;
            if (this.Project_ExpectedCustomerSpend != null)
            {
                context.Project_ExpectedCustomerSpend = new List<Amazon.PartnerCentralSelling.Model.ExpectedCustomerSpend>(this.Project_ExpectedCustomerSpend);
            }
            context.Project_TargetCompletionDate = this.Project_TargetCompletionDate;
            context.Project_Title = this.Project_Title;
            if (this.OpportunityInvitation_ReceiverResponsibility != null)
            {
                context.OpportunityInvitation_ReceiverResponsibility = new List<System.String>(this.OpportunityInvitation_ReceiverResponsibility);
            }
            if (this.OpportunityInvitation_SenderContact != null)
            {
                context.OpportunityInvitation_SenderContact = new List<Amazon.PartnerCentralSelling.Model.SenderContact>(this.OpportunityInvitation_SenderContact);
            }
            context.Account_Alias = this.Account_Alias;
            context.Account_AwsAccountId = this.Account_AwsAccountId;
            
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
            var request = new Amazon.PartnerCentralSelling.Model.CreateEngagementInvitationRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EngagementIdentifier != null)
            {
                request.EngagementIdentifier = cmdletContext.EngagementIdentifier;
            }
            
             // populate Invitation
            var requestInvitationIsNull = true;
            request.Invitation = new Amazon.PartnerCentralSelling.Model.Invitation();
            System.String requestInvitation_invitation_Message = null;
            if (cmdletContext.Invitation_Message != null)
            {
                requestInvitation_invitation_Message = cmdletContext.Invitation_Message;
            }
            if (requestInvitation_invitation_Message != null)
            {
                request.Invitation.Message = requestInvitation_invitation_Message;
                requestInvitationIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.Receiver requestInvitation_invitation_Receiver = null;
            
             // populate Receiver
            var requestInvitation_invitation_ReceiverIsNull = true;
            requestInvitation_invitation_Receiver = new Amazon.PartnerCentralSelling.Model.Receiver();
            Amazon.PartnerCentralSelling.Model.AccountReceiver requestInvitation_invitation_Receiver_invitation_Receiver_Account = null;
            
             // populate Account
            var requestInvitation_invitation_Receiver_invitation_Receiver_AccountIsNull = true;
            requestInvitation_invitation_Receiver_invitation_Receiver_Account = new Amazon.PartnerCentralSelling.Model.AccountReceiver();
            System.String requestInvitation_invitation_Receiver_invitation_Receiver_Account_account_Alias = null;
            if (cmdletContext.Account_Alias != null)
            {
                requestInvitation_invitation_Receiver_invitation_Receiver_Account_account_Alias = cmdletContext.Account_Alias;
            }
            if (requestInvitation_invitation_Receiver_invitation_Receiver_Account_account_Alias != null)
            {
                requestInvitation_invitation_Receiver_invitation_Receiver_Account.Alias = requestInvitation_invitation_Receiver_invitation_Receiver_Account_account_Alias;
                requestInvitation_invitation_Receiver_invitation_Receiver_AccountIsNull = false;
            }
            System.String requestInvitation_invitation_Receiver_invitation_Receiver_Account_account_AwsAccountId = null;
            if (cmdletContext.Account_AwsAccountId != null)
            {
                requestInvitation_invitation_Receiver_invitation_Receiver_Account_account_AwsAccountId = cmdletContext.Account_AwsAccountId;
            }
            if (requestInvitation_invitation_Receiver_invitation_Receiver_Account_account_AwsAccountId != null)
            {
                requestInvitation_invitation_Receiver_invitation_Receiver_Account.AwsAccountId = requestInvitation_invitation_Receiver_invitation_Receiver_Account_account_AwsAccountId;
                requestInvitation_invitation_Receiver_invitation_Receiver_AccountIsNull = false;
            }
             // determine if requestInvitation_invitation_Receiver_invitation_Receiver_Account should be set to null
            if (requestInvitation_invitation_Receiver_invitation_Receiver_AccountIsNull)
            {
                requestInvitation_invitation_Receiver_invitation_Receiver_Account = null;
            }
            if (requestInvitation_invitation_Receiver_invitation_Receiver_Account != null)
            {
                requestInvitation_invitation_Receiver.Account = requestInvitation_invitation_Receiver_invitation_Receiver_Account;
                requestInvitation_invitation_ReceiverIsNull = false;
            }
             // determine if requestInvitation_invitation_Receiver should be set to null
            if (requestInvitation_invitation_ReceiverIsNull)
            {
                requestInvitation_invitation_Receiver = null;
            }
            if (requestInvitation_invitation_Receiver != null)
            {
                request.Invitation.Receiver = requestInvitation_invitation_Receiver;
                requestInvitationIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.Payload requestInvitation_invitation_Payload = null;
            
             // populate Payload
            var requestInvitation_invitation_PayloadIsNull = true;
            requestInvitation_invitation_Payload = new Amazon.PartnerCentralSelling.Model.Payload();
            Amazon.PartnerCentralSelling.Model.LeadInvitationPayload requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation = null;
            
             // populate LeadInvitation
            var requestInvitation_invitation_Payload_invitation_Payload_LeadInvitationIsNull = true;
            requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation = new Amazon.PartnerCentralSelling.Model.LeadInvitationPayload();
            Amazon.PartnerCentralSelling.Model.LeadInvitationInteraction requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction = null;
            
             // populate Interaction
            var requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_InteractionIsNull = true;
            requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction = new Amazon.PartnerCentralSelling.Model.LeadInvitationInteraction();
            System.String requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_ContactBusinessTitle = null;
            if (cmdletContext.Interaction_ContactBusinessTitle != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_ContactBusinessTitle = cmdletContext.Interaction_ContactBusinessTitle;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_ContactBusinessTitle != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction.ContactBusinessTitle = requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_ContactBusinessTitle;
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_InteractionIsNull = false;
            }
            System.String requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_SourceId = null;
            if (cmdletContext.Interaction_SourceId != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_SourceId = cmdletContext.Interaction_SourceId;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_SourceId != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction.SourceId = requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_SourceId;
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_InteractionIsNull = false;
            }
            System.String requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_SourceName = null;
            if (cmdletContext.Interaction_SourceName != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_SourceName = cmdletContext.Interaction_SourceName;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_SourceName != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction.SourceName = requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_SourceName;
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_InteractionIsNull = false;
            }
            System.String requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_SourceType = null;
            if (cmdletContext.Interaction_SourceType != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_SourceType = cmdletContext.Interaction_SourceType;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_SourceType != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction.SourceType = requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_SourceType;
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_InteractionIsNull = false;
            }
            System.String requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_Usecase = null;
            if (cmdletContext.Interaction_Usecase != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_Usecase = cmdletContext.Interaction_Usecase;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_Usecase != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction.Usecase = requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction_interaction_Usecase;
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_InteractionIsNull = false;
            }
             // determine if requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction should be set to null
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_InteractionIsNull)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction = null;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation.Interaction = requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Interaction;
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitationIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.LeadInvitationCustomer requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer = null;
            
             // populate Customer
            var requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_CustomerIsNull = true;
            requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer = new Amazon.PartnerCentralSelling.Model.LeadInvitationCustomer();
            System.String requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_customer_AwsMaturity = null;
            if (cmdletContext.Customer_AwsMaturity != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_customer_AwsMaturity = cmdletContext.Customer_AwsMaturity;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_customer_AwsMaturity != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer.AwsMaturity = requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_customer_AwsMaturity;
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_CustomerIsNull = false;
            }
            System.String requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_CompanyName = null;
            if (cmdletContext.LeadInvitation_Customer_CompanyName != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_CompanyName = cmdletContext.LeadInvitation_Customer_CompanyName;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_CompanyName != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer.CompanyName = requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_CompanyName;
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_CustomerIsNull = false;
            }
            Amazon.PartnerCentralSelling.CountryCode requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_CountryCode = null;
            if (cmdletContext.LeadInvitation_Customer_CountryCode != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_CountryCode = cmdletContext.LeadInvitation_Customer_CountryCode;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_CountryCode != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer.CountryCode = requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_CountryCode;
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_CustomerIsNull = false;
            }
            Amazon.PartnerCentralSelling.Industry requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_Industry = null;
            if (cmdletContext.LeadInvitation_Customer_Industry != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_Industry = cmdletContext.LeadInvitation_Customer_Industry;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_Industry != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer.Industry = requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_Industry;
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_CustomerIsNull = false;
            }
            Amazon.PartnerCentralSelling.MarketSegment requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_customer_MarketSegment = null;
            if (cmdletContext.Customer_MarketSegment != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_customer_MarketSegment = cmdletContext.Customer_MarketSegment;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_customer_MarketSegment != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer.MarketSegment = requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_customer_MarketSegment;
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_CustomerIsNull = false;
            }
            System.String requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_WebsiteUrl = null;
            if (cmdletContext.LeadInvitation_Customer_WebsiteUrl != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_WebsiteUrl = cmdletContext.LeadInvitation_Customer_WebsiteUrl;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_WebsiteUrl != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer.WebsiteUrl = requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer_leadInvitation_Customer_WebsiteUrl;
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_CustomerIsNull = false;
            }
             // determine if requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer should be set to null
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_CustomerIsNull)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer = null;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation.Customer = requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation_invitation_Payload_LeadInvitation_Customer;
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitationIsNull = false;
            }
             // determine if requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation should be set to null
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitationIsNull)
            {
                requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation = null;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation != null)
            {
                requestInvitation_invitation_Payload.LeadInvitation = requestInvitation_invitation_Payload_invitation_Payload_LeadInvitation;
                requestInvitation_invitation_PayloadIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.OpportunityInvitationPayload requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation = null;
            
             // populate OpportunityInvitation
            var requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitationIsNull = true;
            requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation = new Amazon.PartnerCentralSelling.Model.OpportunityInvitationPayload();
            List<System.String> requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_opportunityInvitation_ReceiverResponsibility = null;
            if (cmdletContext.OpportunityInvitation_ReceiverResponsibility != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_opportunityInvitation_ReceiverResponsibility = cmdletContext.OpportunityInvitation_ReceiverResponsibility;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_opportunityInvitation_ReceiverResponsibility != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation.ReceiverResponsibilities = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_opportunityInvitation_ReceiverResponsibility;
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitationIsNull = false;
            }
            List<Amazon.PartnerCentralSelling.Model.SenderContact> requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_opportunityInvitation_SenderContact = null;
            if (cmdletContext.OpportunityInvitation_SenderContact != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_opportunityInvitation_SenderContact = cmdletContext.OpportunityInvitation_SenderContact;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_opportunityInvitation_SenderContact != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation.SenderContacts = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_opportunityInvitation_SenderContact;
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitationIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.EngagementCustomer requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer = null;
            
             // populate Customer
            var requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_CustomerIsNull = true;
            requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer = new Amazon.PartnerCentralSelling.Model.EngagementCustomer();
            System.String requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_CompanyName = null;
            if (cmdletContext.Invitation_Payload_OpportunityInvitation_Customer_CompanyName != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_CompanyName = cmdletContext.Invitation_Payload_OpportunityInvitation_Customer_CompanyName;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_CompanyName != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer.CompanyName = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_CompanyName;
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_CustomerIsNull = false;
            }
            Amazon.PartnerCentralSelling.CountryCode requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_CountryCode = null;
            if (cmdletContext.Invitation_Payload_OpportunityInvitation_Customer_CountryCode != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_CountryCode = cmdletContext.Invitation_Payload_OpportunityInvitation_Customer_CountryCode;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_CountryCode != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer.CountryCode = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_CountryCode;
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_CustomerIsNull = false;
            }
            Amazon.PartnerCentralSelling.Industry requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_Industry = null;
            if (cmdletContext.Invitation_Payload_OpportunityInvitation_Customer_Industry != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_Industry = cmdletContext.Invitation_Payload_OpportunityInvitation_Customer_Industry;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_Industry != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer.Industry = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_Industry;
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_CustomerIsNull = false;
            }
            System.String requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_WebsiteUrl = null;
            if (cmdletContext.Invitation_Payload_OpportunityInvitation_Customer_WebsiteUrl != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_WebsiteUrl = cmdletContext.Invitation_Payload_OpportunityInvitation_Customer_WebsiteUrl;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_WebsiteUrl != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer.WebsiteUrl = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_invitation_Payload_OpportunityInvitation_Customer_WebsiteUrl;
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_CustomerIsNull = false;
            }
             // determine if requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer should be set to null
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_CustomerIsNull)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer = null;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation.Customer = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer;
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitationIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.ProjectDetails requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project = null;
            
             // populate Project
            var requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_ProjectIsNull = true;
            requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project = new Amazon.PartnerCentralSelling.Model.ProjectDetails();
            System.String requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_BusinessProblem = null;
            if (cmdletContext.Project_BusinessProblem != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_BusinessProblem = cmdletContext.Project_BusinessProblem;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_BusinessProblem != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project.BusinessProblem = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_BusinessProblem;
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_ProjectIsNull = false;
            }
            List<Amazon.PartnerCentralSelling.Model.ExpectedCustomerSpend> requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_ExpectedCustomerSpend = null;
            if (cmdletContext.Project_ExpectedCustomerSpend != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_ExpectedCustomerSpend = cmdletContext.Project_ExpectedCustomerSpend;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_ExpectedCustomerSpend != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project.ExpectedCustomerSpend = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_ExpectedCustomerSpend;
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_ProjectIsNull = false;
            }
            System.String requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_TargetCompletionDate = null;
            if (cmdletContext.Project_TargetCompletionDate != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_TargetCompletionDate = cmdletContext.Project_TargetCompletionDate;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_TargetCompletionDate != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project.TargetCompletionDate = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_TargetCompletionDate;
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_ProjectIsNull = false;
            }
            System.String requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_Title = null;
            if (cmdletContext.Project_Title != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_Title = cmdletContext.Project_Title;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_Title != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project.Title = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project_project_Title;
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_ProjectIsNull = false;
            }
             // determine if requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project should be set to null
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_ProjectIsNull)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project = null;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation.Project = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Project;
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitationIsNull = false;
            }
             // determine if requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation should be set to null
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitationIsNull)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation = null;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation != null)
            {
                requestInvitation_invitation_Payload.OpportunityInvitation = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation;
                requestInvitation_invitation_PayloadIsNull = false;
            }
             // determine if requestInvitation_invitation_Payload should be set to null
            if (requestInvitation_invitation_PayloadIsNull)
            {
                requestInvitation_invitation_Payload = null;
            }
            if (requestInvitation_invitation_Payload != null)
            {
                request.Invitation.Payload = requestInvitation_invitation_Payload;
                requestInvitationIsNull = false;
            }
             // determine if request.Invitation should be set to null
            if (requestInvitationIsNull)
            {
                request.Invitation = null;
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
        
        private Amazon.PartnerCentralSelling.Model.CreateEngagementInvitationResponse CallAWSServiceOperation(IAmazonPartnerCentralSelling client, Amazon.PartnerCentralSelling.Model.CreateEngagementInvitationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Selling API", "CreateEngagementInvitation");
            try
            {
                #if DESKTOP
                return client.CreateEngagementInvitation(request);
                #elif CORECLR
                return client.CreateEngagementInvitationAsync(request).GetAwaiter().GetResult();
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
            public System.String Catalog { get; set; }
            public System.String ClientToken { get; set; }
            public System.String EngagementIdentifier { get; set; }
            public System.String Invitation_Message { get; set; }
            public System.String Customer_AwsMaturity { get; set; }
            public System.String LeadInvitation_Customer_CompanyName { get; set; }
            public Amazon.PartnerCentralSelling.CountryCode LeadInvitation_Customer_CountryCode { get; set; }
            public Amazon.PartnerCentralSelling.Industry LeadInvitation_Customer_Industry { get; set; }
            public Amazon.PartnerCentralSelling.MarketSegment Customer_MarketSegment { get; set; }
            public System.String LeadInvitation_Customer_WebsiteUrl { get; set; }
            public System.String Interaction_ContactBusinessTitle { get; set; }
            public System.String Interaction_SourceId { get; set; }
            public System.String Interaction_SourceName { get; set; }
            public System.String Interaction_SourceType { get; set; }
            public System.String Interaction_Usecase { get; set; }
            public System.String Invitation_Payload_OpportunityInvitation_Customer_CompanyName { get; set; }
            public Amazon.PartnerCentralSelling.CountryCode Invitation_Payload_OpportunityInvitation_Customer_CountryCode { get; set; }
            public Amazon.PartnerCentralSelling.Industry Invitation_Payload_OpportunityInvitation_Customer_Industry { get; set; }
            public System.String Invitation_Payload_OpportunityInvitation_Customer_WebsiteUrl { get; set; }
            public System.String Project_BusinessProblem { get; set; }
            public List<Amazon.PartnerCentralSelling.Model.ExpectedCustomerSpend> Project_ExpectedCustomerSpend { get; set; }
            public System.String Project_TargetCompletionDate { get; set; }
            public System.String Project_Title { get; set; }
            public List<System.String> OpportunityInvitation_ReceiverResponsibility { get; set; }
            public List<Amazon.PartnerCentralSelling.Model.SenderContact> OpportunityInvitation_SenderContact { get; set; }
            public System.String Account_Alias { get; set; }
            public System.String Account_AwsAccountId { get; set; }
            public System.Func<Amazon.PartnerCentralSelling.Model.CreateEngagementInvitationResponse, InvokePCCreateEngagementInvitationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
