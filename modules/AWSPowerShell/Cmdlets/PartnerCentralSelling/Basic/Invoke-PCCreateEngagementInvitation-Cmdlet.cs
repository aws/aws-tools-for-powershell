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
        
        #region Parameter Customer_CompanyName
        /// <summary>
        /// <para>
        /// <para>Represents the name of the customer’s company associated with the Engagement Invitation.
        /// This field is used to identify the customer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_OpportunityInvitation_Customer_CompanyName")]
        public System.String Customer_CompanyName { get; set; }
        #endregion
        
        #region Parameter Customer_CountryCode
        /// <summary>
        /// <para>
        /// <para>Indicates the country in which the customer’s company operates. This field is useful
        /// for understanding regional requirements or compliance needs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_OpportunityInvitation_Customer_CountryCode")]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.CountryCode")]
        public Amazon.PartnerCentralSelling.CountryCode Customer_CountryCode { get; set; }
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
        
        #region Parameter Customer_Industry
        /// <summary>
        /// <para>
        /// <para>Specifies the industry to which the customer’s company belongs. This field helps categorize
        /// the opportunity based on the customer’s business sector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_OpportunityInvitation_Customer_Industry")]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.Industry")]
        public Amazon.PartnerCentralSelling.Industry Customer_Industry { get; set; }
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
        
        #region Parameter Customer_WebsiteUrl
        /// <summary>
        /// <para>
        /// <para>Provides the website URL of the customer’s company. This field helps partners verify
        /// the legitimacy and size of the customer organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invitation_Payload_OpportunityInvitation_Customer_WebsiteUrl")]
        public System.String Customer_WebsiteUrl { get; set; }
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
            context.Customer_CompanyName = this.Customer_CompanyName;
            context.Customer_CountryCode = this.Customer_CountryCode;
            context.Customer_Industry = this.Customer_Industry;
            context.Customer_WebsiteUrl = this.Customer_WebsiteUrl;
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
            Amazon.PartnerCentralSelling.Model.Payload requestInvitation_invitation_Payload = null;
            
             // populate Payload
            requestInvitation_invitation_Payload = new Amazon.PartnerCentralSelling.Model.Payload();
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
            System.String requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_CompanyName = null;
            if (cmdletContext.Customer_CompanyName != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_CompanyName = cmdletContext.Customer_CompanyName;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_CompanyName != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer.CompanyName = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_CompanyName;
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_CustomerIsNull = false;
            }
            Amazon.PartnerCentralSelling.CountryCode requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_CountryCode = null;
            if (cmdletContext.Customer_CountryCode != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_CountryCode = cmdletContext.Customer_CountryCode;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_CountryCode != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer.CountryCode = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_CountryCode;
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_CustomerIsNull = false;
            }
            Amazon.PartnerCentralSelling.Industry requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_Industry = null;
            if (cmdletContext.Customer_Industry != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_Industry = cmdletContext.Customer_Industry;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_Industry != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer.Industry = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_Industry;
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_CustomerIsNull = false;
            }
            System.String requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_WebsiteUrl = null;
            if (cmdletContext.Customer_WebsiteUrl != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_WebsiteUrl = cmdletContext.Customer_WebsiteUrl;
            }
            if (requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_WebsiteUrl != null)
            {
                requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer.WebsiteUrl = requestInvitation_invitation_Payload_invitation_Payload_OpportunityInvitation_invitation_Payload_OpportunityInvitation_Customer_customer_WebsiteUrl;
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
            }
            if (requestInvitation_invitation_Payload != null)
            {
                request.Invitation.Payload = requestInvitation_invitation_Payload;
                requestInvitationIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.Receiver requestInvitation_invitation_Receiver = null;
            
             // populate Receiver
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
            }
            if (requestInvitation_invitation_Receiver != null)
            {
                request.Invitation.Receiver = requestInvitation_invitation_Receiver;
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
            public System.String Customer_CompanyName { get; set; }
            public Amazon.PartnerCentralSelling.CountryCode Customer_CountryCode { get; set; }
            public Amazon.PartnerCentralSelling.Industry Customer_Industry { get; set; }
            public System.String Customer_WebsiteUrl { get; set; }
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
