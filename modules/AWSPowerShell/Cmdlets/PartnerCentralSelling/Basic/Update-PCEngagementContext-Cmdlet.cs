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
    /// Updates the context information for an existing engagement with new or modified data.
    /// </summary>
    [Cmdlet("Update", "PCEngagementContext", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralSelling.Model.UpdateEngagementContextResponse")]
    [AWSCmdlet("Calls the Partner Central Selling API UpdateEngagementContext API operation.", Operation = new[] {"UpdateEngagementContext"}, SelectReturnType = typeof(Amazon.PartnerCentralSelling.Model.UpdateEngagementContextResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralSelling.Model.UpdateEngagementContextResponse",
        "This cmdlet returns an Amazon.PartnerCentralSelling.Model.UpdateEngagementContextResponse object containing multiple properties."
    )]
    public partial class UpdatePCEngagementContextCmdlet : AmazonPartnerCentralSellingClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Customer_AwsMaturity
        /// <summary>
        /// <para>
        /// <para>Indicates the customer's level of experience and adoption with AWS services. This
        /// assessment helps determine the appropriate engagement approach and solution complexity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Customer_AwsMaturity")]
        public System.String Customer_AwsMaturity { get; set; }
        #endregion
        
        #region Parameter Project_BusinessProblem
        /// <summary>
        /// <para>
        /// <para>A description of the business problem the project aims to solve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_CustomerProject_Project_BusinessProblem")]
        public System.String Project_BusinessProblem { get; set; }
        #endregion
        
        #region Parameter Interaction_BusinessProblem
        /// <summary>
        /// <para>
        /// <para>Describes the business problem or challenge that the customer discussed during the
        /// interaction. This information helps qualify the lead and identify appropriate solutions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Interaction_BusinessProblem")]
        public System.String Interaction_BusinessProblem { get; set; }
        #endregion
        
        #region Parameter Contact_BusinessTitle
        /// <summary>
        /// <para>
        /// <para>The lead contact's business title or job role associated with the engagement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Interaction_Contact_BusinessTitle")]
        public System.String Contact_BusinessTitle { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>Specifies the catalog associated with the engagement context update request. This
        /// field takes a string value from a predefined list: <c>AWS</c> or <c>Sandbox</c>. The
        /// catalog determines which environment the engagement context is updated in.</para>
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
        
        #region Parameter Address_City
        /// <summary>
        /// <para>
        /// <para>Specifies the end <c>Customer</c>'s city associated with the <c>Opportunity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Customer_Address_City")]
        public System.String Address_City { get; set; }
        #endregion
        
        #region Parameter Payload_CustomerProject_Customer_CompanyName
        /// <summary>
        /// <para>
        /// <para>Represents the name of the customer’s company associated with the Engagement Invitation.
        /// This field is used to identify the customer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_CompanyName")]
        public System.String Payload_CustomerProject_Customer_CompanyName { get; set; }
        #endregion
        
        #region Parameter Lead_Customer_CompanyName
        /// <summary>
        /// <para>
        /// <para>The name of the lead customer's company. This field is essential for identifying and
        /// tracking the customer organization associated with the lead.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Customer_CompanyName")]
        public System.String Lead_Customer_CompanyName { get; set; }
        #endregion
        
        #region Parameter ContextIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the specific engagement context to be updated. This ensures
        /// that the correct context within the engagement is modified.</para>
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
        public System.String ContextIdentifier { get; set; }
        #endregion
        
        #region Parameter Customer_CountryCode
        /// <summary>
        /// <para>
        /// <para>Indicates the country in which the customer’s company operates. This field is useful
        /// for understanding regional requirements or compliance needs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_CustomerProject_Customer_CountryCode")]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.CountryCode")]
        public Amazon.PartnerCentralSelling.CountryCode Customer_CountryCode { get; set; }
        #endregion
        
        #region Parameter Address_CountryCode
        /// <summary>
        /// <para>
        /// <para>Specifies the end <c>Customer</c>'s country associated with the <c>Opportunity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Customer_Address_CountryCode")]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.CountryCode")]
        public Amazon.PartnerCentralSelling.CountryCode Address_CountryCode { get; set; }
        #endregion
        
        #region Parameter Interaction_CustomerAction
        /// <summary>
        /// <para>
        /// <para>Describes the action taken by the customer during or as a result of the interaction,
        /// such as requesting information, scheduling a meeting, or expressing interest in a
        /// solution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Interaction_CustomerAction")]
        public System.String Interaction_CustomerAction { get; set; }
        #endregion
        
        #region Parameter Contact_Email
        /// <summary>
        /// <para>
        /// <para>The lead contact's email address associated with the engagement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Interaction_Contact_Email")]
        public System.String Contact_Email { get; set; }
        #endregion
        
        #region Parameter EngagementIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the <c>Engagement</c> containing the context to be updated.
        /// This parameter ensures the context update is applied to the correct engagement.</para>
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
        public System.String EngagementIdentifier { get; set; }
        #endregion
        
        #region Parameter EngagementLastModifiedAt
        /// <summary>
        /// <para>
        /// <para>The timestamp when the engagement was last modified, used for optimistic concurrency
        /// control. This helps prevent conflicts when multiple users attempt to update the same
        /// engagement simultaneously.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EngagementLastModifiedAt { get; set; }
        #endregion
        
        #region Parameter Contact_FirstName
        /// <summary>
        /// <para>
        /// <para>The lead contact's first name associated with the engagement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Interaction_Contact_FirstName")]
        public System.String Contact_FirstName { get; set; }
        #endregion
        
        #region Parameter Payload_CustomerProject_Customer_Industry
        /// <summary>
        /// <para>
        /// <para>Specifies the industry to which the customer’s company belongs. This field helps categorize
        /// the opportunity based on the customer’s business sector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_Industry")]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.Industry")]
        public Amazon.PartnerCentralSelling.Industry Payload_CustomerProject_Customer_Industry { get; set; }
        #endregion
        
        #region Parameter Lead_Customer_Industry
        /// <summary>
        /// <para>
        /// <para>Specifies the industry sector to which the lead customer's company belongs. This categorization
        /// helps in understanding the customer's business context and tailoring appropriate solutions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Customer_Industry")]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.Industry")]
        public Amazon.PartnerCentralSelling.Industry Lead_Customer_Industry { get; set; }
        #endregion
        
        #region Parameter Interaction_InteractionDate
        /// <summary>
        /// <para>
        /// <para>The date and time when the lead interaction occurred, in ISO 8601 format (UTC). This
        /// timestamp helps track the chronology of lead engagement activities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Interaction_InteractionDate")]
        public System.DateTime? Interaction_InteractionDate { get; set; }
        #endregion
        
        #region Parameter Contact_LastName
        /// <summary>
        /// <para>
        /// <para>The lead contact's last name associated with the engagement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Interaction_Contact_LastName")]
        public System.String Contact_LastName { get; set; }
        #endregion
        
        #region Parameter Customer_MarketSegment
        /// <summary>
        /// <para>
        /// <para>Specifies the market segment classification of the lead customer, such as enterprise,
        /// mid-market, or small business. This segmentation helps in targeting appropriate solutions
        /// and engagement strategies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Customer_MarketSegment")]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.MarketSegment")]
        public Amazon.PartnerCentralSelling.MarketSegment Customer_MarketSegment { get; set; }
        #endregion
        
        #region Parameter Contact_Phone
        /// <summary>
        /// <para>
        /// <para>The lead contact's phone number associated with the engagement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Interaction_Contact_Phone")]
        public System.String Contact_Phone { get; set; }
        #endregion
        
        #region Parameter Address_PostalCode
        /// <summary>
        /// <para>
        /// <para>Specifies the end <c>Customer</c>'s postal code associated with the <c>Opportunity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Customer_Address_PostalCode")]
        public System.String Address_PostalCode { get; set; }
        #endregion
        
        #region Parameter Lead_QualificationStatus
        /// <summary>
        /// <para>
        /// <para>The updated qualification status of the lead.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_QualificationStatus")]
        public System.String Lead_QualificationStatus { get; set; }
        #endregion
        
        #region Parameter Interaction_SourceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the specific source that generated the lead interaction.
        /// This ID provides traceability back to the original lead generation activity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Interaction_SourceId")]
        public System.String Interaction_SourceId { get; set; }
        #endregion
        
        #region Parameter Interaction_SourceName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the source that generated the lead interaction, providing
        /// a human-readable identifier for the lead generation channel or activity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Interaction_SourceName")]
        public System.String Interaction_SourceName { get; set; }
        #endregion
        
        #region Parameter Interaction_SourceType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of source that generated the lead interaction, such as "Event",
        /// "Website", "Referral", or "Campaign". This categorization helps track lead generation
        /// effectiveness across different channels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Interaction_SourceType")]
        public System.String Interaction_SourceType { get; set; }
        #endregion
        
        #region Parameter Address_StateOrRegion
        /// <summary>
        /// <para>
        /// <para>Specifies the end <c>Customer</c>'s state or region associated with the <c>Opportunity</c>.</para><para>Valid values: <c>Alabama | Alaska | American Samoa | Arizona | Arkansas | California
        /// | Colorado | Connecticut | Delaware | Dist. of Columbia | Federated States of Micronesia
        /// | Florida | Georgia | Guam | Hawaii | Idaho | Illinois | Indiana | Iowa | Kansas |
        /// Kentucky | Louisiana | Maine | Marshall Islands | Maryland | Massachusetts | Michigan
        /// | Minnesota | Mississippi | Missouri | Montana | Nebraska | Nevada | New Hampshire
        /// | New Jersey | New Mexico | New York | North Carolina | North Dakota | Northern Mariana
        /// Islands | Ohio | Oklahoma | Oregon | Palau | Pennsylvania | Puerto Rico | Rhode Island
        /// | South Carolina | South Dakota | Tennessee | Texas | Utah | Vermont | Virginia |
        /// Virgin Islands | Washington | West Virginia | Wisconsin | Wyoming | APO/AE | AFO/FPO
        /// | FPO, AP</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Customer_Address_StateOrRegion")]
        public System.String Address_StateOrRegion { get; set; }
        #endregion
        
        #region Parameter Project_TargetCompletionDate
        /// <summary>
        /// <para>
        /// <para>The target completion date for the customer's project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_CustomerProject_Project_TargetCompletionDate")]
        public System.String Project_TargetCompletionDate { get; set; }
        #endregion
        
        #region Parameter Project_Title
        /// <summary>
        /// <para>
        /// <para>The title of the project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_CustomerProject_Project_Title")]
        public System.String Project_Title { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>Specifies the type of context being updated within the engagement. This field determines
        /// the structure and content of the context payload being modified.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.EngagementContextType")]
        public Amazon.PartnerCentralSelling.EngagementContextType Type { get; set; }
        #endregion
        
        #region Parameter Interaction_Usecase
        /// <summary>
        /// <para>
        /// <para>Describes the specific use case or business scenario discussed during the lead interaction.
        /// This helps categorize the customer's interests and potential solutions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Interaction_Usecase")]
        public System.String Interaction_Usecase { get; set; }
        #endregion
        
        #region Parameter Payload_CustomerProject_Customer_WebsiteUrl
        /// <summary>
        /// <para>
        /// <para>Provides the website URL of the customer’s company. This field helps partners verify
        /// the legitimacy and size of the customer organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_WebsiteUrl")]
        public System.String Payload_CustomerProject_Customer_WebsiteUrl { get; set; }
        #endregion
        
        #region Parameter Lead_Customer_WebsiteUrl
        /// <summary>
        /// <para>
        /// <para>The website URL of the lead customer's company. This provides additional context about
        /// the customer organization and helps verify company legitimacy and size.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Customer_WebsiteUrl")]
        public System.String Lead_Customer_WebsiteUrl { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralSelling.Model.UpdateEngagementContextResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralSelling.Model.UpdateEngagementContextResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.ContextIdentifier),
                nameof(this.EngagementIdentifier)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PCEngagementContext (UpdateEngagementContext)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralSelling.Model.UpdateEngagementContextResponse, UpdatePCEngagementContextCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContextIdentifier = this.ContextIdentifier;
            #if MODULAR
            if (this.ContextIdentifier == null && ParameterWasBound(nameof(this.ContextIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ContextIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EngagementIdentifier = this.EngagementIdentifier;
            #if MODULAR
            if (this.EngagementIdentifier == null && ParameterWasBound(nameof(this.EngagementIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EngagementIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EngagementLastModifiedAt = this.EngagementLastModifiedAt;
            #if MODULAR
            if (this.EngagementLastModifiedAt == null && ParameterWasBound(nameof(this.EngagementLastModifiedAt)))
            {
                WriteWarning("You are passing $null as a value for parameter EngagementLastModifiedAt which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Payload_CustomerProject_Customer_CompanyName = this.Payload_CustomerProject_Customer_CompanyName;
            context.Customer_CountryCode = this.Customer_CountryCode;
            context.Payload_CustomerProject_Customer_Industry = this.Payload_CustomerProject_Customer_Industry;
            context.Payload_CustomerProject_Customer_WebsiteUrl = this.Payload_CustomerProject_Customer_WebsiteUrl;
            context.Project_BusinessProblem = this.Project_BusinessProblem;
            context.Project_TargetCompletionDate = this.Project_TargetCompletionDate;
            context.Project_Title = this.Project_Title;
            context.Address_City = this.Address_City;
            context.Address_CountryCode = this.Address_CountryCode;
            context.Address_PostalCode = this.Address_PostalCode;
            context.Address_StateOrRegion = this.Address_StateOrRegion;
            context.Customer_AwsMaturity = this.Customer_AwsMaturity;
            context.Lead_Customer_CompanyName = this.Lead_Customer_CompanyName;
            context.Lead_Customer_Industry = this.Lead_Customer_Industry;
            context.Customer_MarketSegment = this.Customer_MarketSegment;
            context.Lead_Customer_WebsiteUrl = this.Lead_Customer_WebsiteUrl;
            context.Interaction_BusinessProblem = this.Interaction_BusinessProblem;
            context.Contact_BusinessTitle = this.Contact_BusinessTitle;
            context.Contact_Email = this.Contact_Email;
            context.Contact_FirstName = this.Contact_FirstName;
            context.Contact_LastName = this.Contact_LastName;
            context.Contact_Phone = this.Contact_Phone;
            context.Interaction_CustomerAction = this.Interaction_CustomerAction;
            context.Interaction_InteractionDate = this.Interaction_InteractionDate;
            context.Interaction_SourceId = this.Interaction_SourceId;
            context.Interaction_SourceName = this.Interaction_SourceName;
            context.Interaction_SourceType = this.Interaction_SourceType;
            context.Interaction_Usecase = this.Interaction_Usecase;
            context.Lead_QualificationStatus = this.Lead_QualificationStatus;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PartnerCentralSelling.Model.UpdateEngagementContextRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ContextIdentifier != null)
            {
                request.ContextIdentifier = cmdletContext.ContextIdentifier;
            }
            if (cmdletContext.EngagementIdentifier != null)
            {
                request.EngagementIdentifier = cmdletContext.EngagementIdentifier;
            }
            if (cmdletContext.EngagementLastModifiedAt != null)
            {
                request.EngagementLastModifiedAt = cmdletContext.EngagementLastModifiedAt.Value;
            }
            
             // populate Payload
            var requestPayloadIsNull = true;
            request.Payload = new Amazon.PartnerCentralSelling.Model.UpdateEngagementContextPayload();
            Amazon.PartnerCentralSelling.Model.CustomerProjectsContext requestPayload_payload_CustomerProject = null;
            
             // populate CustomerProject
            var requestPayload_payload_CustomerProjectIsNull = true;
            requestPayload_payload_CustomerProject = new Amazon.PartnerCentralSelling.Model.CustomerProjectsContext();
            Amazon.PartnerCentralSelling.Model.EngagementCustomerProjectDetails requestPayload_payload_CustomerProject_payload_CustomerProject_Project = null;
            
             // populate Project
            var requestPayload_payload_CustomerProject_payload_CustomerProject_ProjectIsNull = true;
            requestPayload_payload_CustomerProject_payload_CustomerProject_Project = new Amazon.PartnerCentralSelling.Model.EngagementCustomerProjectDetails();
            System.String requestPayload_payload_CustomerProject_payload_CustomerProject_Project_project_BusinessProblem = null;
            if (cmdletContext.Project_BusinessProblem != null)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Project_project_BusinessProblem = cmdletContext.Project_BusinessProblem;
            }
            if (requestPayload_payload_CustomerProject_payload_CustomerProject_Project_project_BusinessProblem != null)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Project.BusinessProblem = requestPayload_payload_CustomerProject_payload_CustomerProject_Project_project_BusinessProblem;
                requestPayload_payload_CustomerProject_payload_CustomerProject_ProjectIsNull = false;
            }
            System.String requestPayload_payload_CustomerProject_payload_CustomerProject_Project_project_TargetCompletionDate = null;
            if (cmdletContext.Project_TargetCompletionDate != null)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Project_project_TargetCompletionDate = cmdletContext.Project_TargetCompletionDate;
            }
            if (requestPayload_payload_CustomerProject_payload_CustomerProject_Project_project_TargetCompletionDate != null)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Project.TargetCompletionDate = requestPayload_payload_CustomerProject_payload_CustomerProject_Project_project_TargetCompletionDate;
                requestPayload_payload_CustomerProject_payload_CustomerProject_ProjectIsNull = false;
            }
            System.String requestPayload_payload_CustomerProject_payload_CustomerProject_Project_project_Title = null;
            if (cmdletContext.Project_Title != null)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Project_project_Title = cmdletContext.Project_Title;
            }
            if (requestPayload_payload_CustomerProject_payload_CustomerProject_Project_project_Title != null)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Project.Title = requestPayload_payload_CustomerProject_payload_CustomerProject_Project_project_Title;
                requestPayload_payload_CustomerProject_payload_CustomerProject_ProjectIsNull = false;
            }
             // determine if requestPayload_payload_CustomerProject_payload_CustomerProject_Project should be set to null
            if (requestPayload_payload_CustomerProject_payload_CustomerProject_ProjectIsNull)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Project = null;
            }
            if (requestPayload_payload_CustomerProject_payload_CustomerProject_Project != null)
            {
                requestPayload_payload_CustomerProject.Project = requestPayload_payload_CustomerProject_payload_CustomerProject_Project;
                requestPayload_payload_CustomerProjectIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.EngagementCustomer requestPayload_payload_CustomerProject_payload_CustomerProject_Customer = null;
            
             // populate Customer
            var requestPayload_payload_CustomerProject_payload_CustomerProject_CustomerIsNull = true;
            requestPayload_payload_CustomerProject_payload_CustomerProject_Customer = new Amazon.PartnerCentralSelling.Model.EngagementCustomer();
            System.String requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_payload_CustomerProject_Customer_CompanyName = null;
            if (cmdletContext.Payload_CustomerProject_Customer_CompanyName != null)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_payload_CustomerProject_Customer_CompanyName = cmdletContext.Payload_CustomerProject_Customer_CompanyName;
            }
            if (requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_payload_CustomerProject_Customer_CompanyName != null)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Customer.CompanyName = requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_payload_CustomerProject_Customer_CompanyName;
                requestPayload_payload_CustomerProject_payload_CustomerProject_CustomerIsNull = false;
            }
            Amazon.PartnerCentralSelling.CountryCode requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_customer_CountryCode = null;
            if (cmdletContext.Customer_CountryCode != null)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_customer_CountryCode = cmdletContext.Customer_CountryCode;
            }
            if (requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_customer_CountryCode != null)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Customer.CountryCode = requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_customer_CountryCode;
                requestPayload_payload_CustomerProject_payload_CustomerProject_CustomerIsNull = false;
            }
            Amazon.PartnerCentralSelling.Industry requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_payload_CustomerProject_Customer_Industry = null;
            if (cmdletContext.Payload_CustomerProject_Customer_Industry != null)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_payload_CustomerProject_Customer_Industry = cmdletContext.Payload_CustomerProject_Customer_Industry;
            }
            if (requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_payload_CustomerProject_Customer_Industry != null)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Customer.Industry = requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_payload_CustomerProject_Customer_Industry;
                requestPayload_payload_CustomerProject_payload_CustomerProject_CustomerIsNull = false;
            }
            System.String requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_payload_CustomerProject_Customer_WebsiteUrl = null;
            if (cmdletContext.Payload_CustomerProject_Customer_WebsiteUrl != null)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_payload_CustomerProject_Customer_WebsiteUrl = cmdletContext.Payload_CustomerProject_Customer_WebsiteUrl;
            }
            if (requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_payload_CustomerProject_Customer_WebsiteUrl != null)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Customer.WebsiteUrl = requestPayload_payload_CustomerProject_payload_CustomerProject_Customer_payload_CustomerProject_Customer_WebsiteUrl;
                requestPayload_payload_CustomerProject_payload_CustomerProject_CustomerIsNull = false;
            }
             // determine if requestPayload_payload_CustomerProject_payload_CustomerProject_Customer should be set to null
            if (requestPayload_payload_CustomerProject_payload_CustomerProject_CustomerIsNull)
            {
                requestPayload_payload_CustomerProject_payload_CustomerProject_Customer = null;
            }
            if (requestPayload_payload_CustomerProject_payload_CustomerProject_Customer != null)
            {
                requestPayload_payload_CustomerProject.Customer = requestPayload_payload_CustomerProject_payload_CustomerProject_Customer;
                requestPayload_payload_CustomerProjectIsNull = false;
            }
             // determine if requestPayload_payload_CustomerProject should be set to null
            if (requestPayload_payload_CustomerProjectIsNull)
            {
                requestPayload_payload_CustomerProject = null;
            }
            if (requestPayload_payload_CustomerProject != null)
            {
                request.Payload.CustomerProject = requestPayload_payload_CustomerProject;
                requestPayloadIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.UpdateLeadContext requestPayload_payload_Lead = null;
            
             // populate Lead
            var requestPayload_payload_LeadIsNull = true;
            requestPayload_payload_Lead = new Amazon.PartnerCentralSelling.Model.UpdateLeadContext();
            System.String requestPayload_payload_Lead_lead_QualificationStatus = null;
            if (cmdletContext.Lead_QualificationStatus != null)
            {
                requestPayload_payload_Lead_lead_QualificationStatus = cmdletContext.Lead_QualificationStatus;
            }
            if (requestPayload_payload_Lead_lead_QualificationStatus != null)
            {
                requestPayload_payload_Lead.QualificationStatus = requestPayload_payload_Lead_lead_QualificationStatus;
                requestPayload_payload_LeadIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.LeadCustomer requestPayload_payload_Lead_payload_Lead_Customer = null;
            
             // populate Customer
            var requestPayload_payload_Lead_payload_Lead_CustomerIsNull = true;
            requestPayload_payload_Lead_payload_Lead_Customer = new Amazon.PartnerCentralSelling.Model.LeadCustomer();
            System.String requestPayload_payload_Lead_payload_Lead_Customer_customer_AwsMaturity = null;
            if (cmdletContext.Customer_AwsMaturity != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer_customer_AwsMaturity = cmdletContext.Customer_AwsMaturity;
            }
            if (requestPayload_payload_Lead_payload_Lead_Customer_customer_AwsMaturity != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer.AwsMaturity = requestPayload_payload_Lead_payload_Lead_Customer_customer_AwsMaturity;
                requestPayload_payload_Lead_payload_Lead_CustomerIsNull = false;
            }
            System.String requestPayload_payload_Lead_payload_Lead_Customer_lead_Customer_CompanyName = null;
            if (cmdletContext.Lead_Customer_CompanyName != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer_lead_Customer_CompanyName = cmdletContext.Lead_Customer_CompanyName;
            }
            if (requestPayload_payload_Lead_payload_Lead_Customer_lead_Customer_CompanyName != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer.CompanyName = requestPayload_payload_Lead_payload_Lead_Customer_lead_Customer_CompanyName;
                requestPayload_payload_Lead_payload_Lead_CustomerIsNull = false;
            }
            Amazon.PartnerCentralSelling.Industry requestPayload_payload_Lead_payload_Lead_Customer_lead_Customer_Industry = null;
            if (cmdletContext.Lead_Customer_Industry != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer_lead_Customer_Industry = cmdletContext.Lead_Customer_Industry;
            }
            if (requestPayload_payload_Lead_payload_Lead_Customer_lead_Customer_Industry != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer.Industry = requestPayload_payload_Lead_payload_Lead_Customer_lead_Customer_Industry;
                requestPayload_payload_Lead_payload_Lead_CustomerIsNull = false;
            }
            Amazon.PartnerCentralSelling.MarketSegment requestPayload_payload_Lead_payload_Lead_Customer_customer_MarketSegment = null;
            if (cmdletContext.Customer_MarketSegment != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer_customer_MarketSegment = cmdletContext.Customer_MarketSegment;
            }
            if (requestPayload_payload_Lead_payload_Lead_Customer_customer_MarketSegment != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer.MarketSegment = requestPayload_payload_Lead_payload_Lead_Customer_customer_MarketSegment;
                requestPayload_payload_Lead_payload_Lead_CustomerIsNull = false;
            }
            System.String requestPayload_payload_Lead_payload_Lead_Customer_lead_Customer_WebsiteUrl = null;
            if (cmdletContext.Lead_Customer_WebsiteUrl != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer_lead_Customer_WebsiteUrl = cmdletContext.Lead_Customer_WebsiteUrl;
            }
            if (requestPayload_payload_Lead_payload_Lead_Customer_lead_Customer_WebsiteUrl != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer.WebsiteUrl = requestPayload_payload_Lead_payload_Lead_Customer_lead_Customer_WebsiteUrl;
                requestPayload_payload_Lead_payload_Lead_CustomerIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.AddressSummary requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address = null;
            
             // populate Address
            var requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_AddressIsNull = true;
            requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address = new Amazon.PartnerCentralSelling.Model.AddressSummary();
            System.String requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_City = null;
            if (cmdletContext.Address_City != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_City = cmdletContext.Address_City;
            }
            if (requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_City != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address.City = requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_City;
                requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_AddressIsNull = false;
            }
            Amazon.PartnerCentralSelling.CountryCode requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_CountryCode = null;
            if (cmdletContext.Address_CountryCode != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_CountryCode = cmdletContext.Address_CountryCode;
            }
            if (requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_CountryCode != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address.CountryCode = requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_CountryCode;
                requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_AddressIsNull = false;
            }
            System.String requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_PostalCode = null;
            if (cmdletContext.Address_PostalCode != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_PostalCode = cmdletContext.Address_PostalCode;
            }
            if (requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_PostalCode != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address.PostalCode = requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_PostalCode;
                requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_AddressIsNull = false;
            }
            System.String requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_StateOrRegion = null;
            if (cmdletContext.Address_StateOrRegion != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_StateOrRegion = cmdletContext.Address_StateOrRegion;
            }
            if (requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_StateOrRegion != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address.StateOrRegion = requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address_address_StateOrRegion;
                requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_AddressIsNull = false;
            }
             // determine if requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address should be set to null
            if (requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_AddressIsNull)
            {
                requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address = null;
            }
            if (requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address != null)
            {
                requestPayload_payload_Lead_payload_Lead_Customer.Address = requestPayload_payload_Lead_payload_Lead_Customer_payload_Lead_Customer_Address;
                requestPayload_payload_Lead_payload_Lead_CustomerIsNull = false;
            }
             // determine if requestPayload_payload_Lead_payload_Lead_Customer should be set to null
            if (requestPayload_payload_Lead_payload_Lead_CustomerIsNull)
            {
                requestPayload_payload_Lead_payload_Lead_Customer = null;
            }
            if (requestPayload_payload_Lead_payload_Lead_Customer != null)
            {
                requestPayload_payload_Lead.Customer = requestPayload_payload_Lead_payload_Lead_Customer;
                requestPayload_payload_LeadIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.LeadInteraction requestPayload_payload_Lead_payload_Lead_Interaction = null;
            
             // populate Interaction
            var requestPayload_payload_Lead_payload_Lead_InteractionIsNull = true;
            requestPayload_payload_Lead_payload_Lead_Interaction = new Amazon.PartnerCentralSelling.Model.LeadInteraction();
            System.String requestPayload_payload_Lead_payload_Lead_Interaction_interaction_BusinessProblem = null;
            if (cmdletContext.Interaction_BusinessProblem != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_interaction_BusinessProblem = cmdletContext.Interaction_BusinessProblem;
            }
            if (requestPayload_payload_Lead_payload_Lead_Interaction_interaction_BusinessProblem != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction.BusinessProblem = requestPayload_payload_Lead_payload_Lead_Interaction_interaction_BusinessProblem;
                requestPayload_payload_Lead_payload_Lead_InteractionIsNull = false;
            }
            System.String requestPayload_payload_Lead_payload_Lead_Interaction_interaction_CustomerAction = null;
            if (cmdletContext.Interaction_CustomerAction != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_interaction_CustomerAction = cmdletContext.Interaction_CustomerAction;
            }
            if (requestPayload_payload_Lead_payload_Lead_Interaction_interaction_CustomerAction != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction.CustomerAction = requestPayload_payload_Lead_payload_Lead_Interaction_interaction_CustomerAction;
                requestPayload_payload_Lead_payload_Lead_InteractionIsNull = false;
            }
            System.DateTime? requestPayload_payload_Lead_payload_Lead_Interaction_interaction_InteractionDate = null;
            if (cmdletContext.Interaction_InteractionDate != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_interaction_InteractionDate = cmdletContext.Interaction_InteractionDate.Value;
            }
            if (requestPayload_payload_Lead_payload_Lead_Interaction_interaction_InteractionDate != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction.InteractionDate = requestPayload_payload_Lead_payload_Lead_Interaction_interaction_InteractionDate.Value;
                requestPayload_payload_Lead_payload_Lead_InteractionIsNull = false;
            }
            System.String requestPayload_payload_Lead_payload_Lead_Interaction_interaction_SourceId = null;
            if (cmdletContext.Interaction_SourceId != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_interaction_SourceId = cmdletContext.Interaction_SourceId;
            }
            if (requestPayload_payload_Lead_payload_Lead_Interaction_interaction_SourceId != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction.SourceId = requestPayload_payload_Lead_payload_Lead_Interaction_interaction_SourceId;
                requestPayload_payload_Lead_payload_Lead_InteractionIsNull = false;
            }
            System.String requestPayload_payload_Lead_payload_Lead_Interaction_interaction_SourceName = null;
            if (cmdletContext.Interaction_SourceName != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_interaction_SourceName = cmdletContext.Interaction_SourceName;
            }
            if (requestPayload_payload_Lead_payload_Lead_Interaction_interaction_SourceName != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction.SourceName = requestPayload_payload_Lead_payload_Lead_Interaction_interaction_SourceName;
                requestPayload_payload_Lead_payload_Lead_InteractionIsNull = false;
            }
            System.String requestPayload_payload_Lead_payload_Lead_Interaction_interaction_SourceType = null;
            if (cmdletContext.Interaction_SourceType != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_interaction_SourceType = cmdletContext.Interaction_SourceType;
            }
            if (requestPayload_payload_Lead_payload_Lead_Interaction_interaction_SourceType != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction.SourceType = requestPayload_payload_Lead_payload_Lead_Interaction_interaction_SourceType;
                requestPayload_payload_Lead_payload_Lead_InteractionIsNull = false;
            }
            System.String requestPayload_payload_Lead_payload_Lead_Interaction_interaction_Usecase = null;
            if (cmdletContext.Interaction_Usecase != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_interaction_Usecase = cmdletContext.Interaction_Usecase;
            }
            if (requestPayload_payload_Lead_payload_Lead_Interaction_interaction_Usecase != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction.Usecase = requestPayload_payload_Lead_payload_Lead_Interaction_interaction_Usecase;
                requestPayload_payload_Lead_payload_Lead_InteractionIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.LeadContact requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact = null;
            
             // populate Contact
            var requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_ContactIsNull = true;
            requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact = new Amazon.PartnerCentralSelling.Model.LeadContact();
            System.String requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_BusinessTitle = null;
            if (cmdletContext.Contact_BusinessTitle != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_BusinessTitle = cmdletContext.Contact_BusinessTitle;
            }
            if (requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_BusinessTitle != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact.BusinessTitle = requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_BusinessTitle;
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_ContactIsNull = false;
            }
            System.String requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_Email = null;
            if (cmdletContext.Contact_Email != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_Email = cmdletContext.Contact_Email;
            }
            if (requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_Email != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact.Email = requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_Email;
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_ContactIsNull = false;
            }
            System.String requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_FirstName = null;
            if (cmdletContext.Contact_FirstName != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_FirstName = cmdletContext.Contact_FirstName;
            }
            if (requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_FirstName != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact.FirstName = requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_FirstName;
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_ContactIsNull = false;
            }
            System.String requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_LastName = null;
            if (cmdletContext.Contact_LastName != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_LastName = cmdletContext.Contact_LastName;
            }
            if (requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_LastName != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact.LastName = requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_LastName;
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_ContactIsNull = false;
            }
            System.String requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_Phone = null;
            if (cmdletContext.Contact_Phone != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_Phone = cmdletContext.Contact_Phone;
            }
            if (requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_Phone != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact.Phone = requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact_contact_Phone;
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_ContactIsNull = false;
            }
             // determine if requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact should be set to null
            if (requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_ContactIsNull)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact = null;
            }
            if (requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact != null)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction.Contact = requestPayload_payload_Lead_payload_Lead_Interaction_payload_Lead_Interaction_Contact;
                requestPayload_payload_Lead_payload_Lead_InteractionIsNull = false;
            }
             // determine if requestPayload_payload_Lead_payload_Lead_Interaction should be set to null
            if (requestPayload_payload_Lead_payload_Lead_InteractionIsNull)
            {
                requestPayload_payload_Lead_payload_Lead_Interaction = null;
            }
            if (requestPayload_payload_Lead_payload_Lead_Interaction != null)
            {
                requestPayload_payload_Lead.Interaction = requestPayload_payload_Lead_payload_Lead_Interaction;
                requestPayload_payload_LeadIsNull = false;
            }
             // determine if requestPayload_payload_Lead should be set to null
            if (requestPayload_payload_LeadIsNull)
            {
                requestPayload_payload_Lead = null;
            }
            if (requestPayload_payload_Lead != null)
            {
                request.Payload.Lead = requestPayload_payload_Lead;
                requestPayloadIsNull = false;
            }
             // determine if request.Payload should be set to null
            if (requestPayloadIsNull)
            {
                request.Payload = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.PartnerCentralSelling.Model.UpdateEngagementContextResponse CallAWSServiceOperation(IAmazonPartnerCentralSelling client, Amazon.PartnerCentralSelling.Model.UpdateEngagementContextRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Selling API", "UpdateEngagementContext");
            try
            {
                #if DESKTOP
                return client.UpdateEngagementContext(request);
                #elif CORECLR
                return client.UpdateEngagementContextAsync(request).GetAwaiter().GetResult();
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
            public System.String ContextIdentifier { get; set; }
            public System.String EngagementIdentifier { get; set; }
            public System.DateTime? EngagementLastModifiedAt { get; set; }
            public System.String Payload_CustomerProject_Customer_CompanyName { get; set; }
            public Amazon.PartnerCentralSelling.CountryCode Customer_CountryCode { get; set; }
            public Amazon.PartnerCentralSelling.Industry Payload_CustomerProject_Customer_Industry { get; set; }
            public System.String Payload_CustomerProject_Customer_WebsiteUrl { get; set; }
            public System.String Project_BusinessProblem { get; set; }
            public System.String Project_TargetCompletionDate { get; set; }
            public System.String Project_Title { get; set; }
            public System.String Address_City { get; set; }
            public Amazon.PartnerCentralSelling.CountryCode Address_CountryCode { get; set; }
            public System.String Address_PostalCode { get; set; }
            public System.String Address_StateOrRegion { get; set; }
            public System.String Customer_AwsMaturity { get; set; }
            public System.String Lead_Customer_CompanyName { get; set; }
            public Amazon.PartnerCentralSelling.Industry Lead_Customer_Industry { get; set; }
            public Amazon.PartnerCentralSelling.MarketSegment Customer_MarketSegment { get; set; }
            public System.String Lead_Customer_WebsiteUrl { get; set; }
            public System.String Interaction_BusinessProblem { get; set; }
            public System.String Contact_BusinessTitle { get; set; }
            public System.String Contact_Email { get; set; }
            public System.String Contact_FirstName { get; set; }
            public System.String Contact_LastName { get; set; }
            public System.String Contact_Phone { get; set; }
            public System.String Interaction_CustomerAction { get; set; }
            public System.DateTime? Interaction_InteractionDate { get; set; }
            public System.String Interaction_SourceId { get; set; }
            public System.String Interaction_SourceName { get; set; }
            public System.String Interaction_SourceType { get; set; }
            public System.String Interaction_Usecase { get; set; }
            public System.String Lead_QualificationStatus { get; set; }
            public Amazon.PartnerCentralSelling.EngagementContextType Type { get; set; }
            public System.Func<Amazon.PartnerCentralSelling.Model.UpdateEngagementContextResponse, UpdatePCEngagementContextCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
