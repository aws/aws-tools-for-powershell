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
using Amazon.PartnerCentralSelling;
using Amazon.PartnerCentralSelling.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PC
{
    /// <summary>
    /// Creates a new context within an existing engagement. This action allows you to add
    /// contextual information such as customer projects or documents to an engagement, providing
    /// additional details that help facilitate collaboration between engagement members.
    /// </summary>
    [Cmdlet("New", "PCEngagementContext", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralSelling.Model.CreateEngagementContextResponse")]
    [AWSCmdlet("Calls the Partner Central Selling API CreateEngagementContext API operation.", Operation = new[] {"CreateEngagementContext"}, SelectReturnType = typeof(Amazon.PartnerCentralSelling.Model.CreateEngagementContextResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralSelling.Model.CreateEngagementContextResponse",
        "This cmdlet returns an Amazon.PartnerCentralSelling.Model.CreateEngagementContextResponse object containing multiple properties."
    )]
    public partial class NewPCEngagementContextCmdlet : AmazonPartnerCentralSellingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>Specifies the catalog associated with the engagement context request. This field takes
        /// a string value from a predefined list: <c>AWS</c> or <c>Sandbox</c>. The catalog determines
        /// which environment the engagement context is created in. Use <c>AWS</c> to create contexts
        /// in the production environment, and <c>Sandbox</c> for testing in secure, isolated
        /// environments.</para>
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
        
        #region Parameter EngagementIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the <c>Engagement</c> for which the context is being created.
        /// This parameter ensures the context is associated with the correct engagement and provides
        /// the necessary linkage between the engagement and its contextual information.</para>
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
        
        #region Parameter Lead_Interaction
        /// <summary>
        /// <para>
        /// <para>An array of interactions that have occurred with the lead, providing a history of
        /// communications, meetings, and other engagement activities related to the lead.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_Interactions")]
        public Amazon.PartnerCentralSelling.Model.LeadInteraction[] Lead_Interaction { get; set; }
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
        /// <para>Indicates the current qualification status of the lead, such as whether it has been
        /// qualified, disqualified, or is still under evaluation. This helps track the lead's
        /// progression through the qualification process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_Lead_QualificationStatus")]
        public System.String Lead_QualificationStatus { get; set; }
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
        /// <para>Specifies the type of context being created for the engagement. This field determines
        /// the structure and content of the context payload. Valid values include <c>CustomerProject</c>
        /// for customer project-related contexts. The type field ensures that the context is
        /// properly categorized and processed according to its intended purpose.</para>
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier provided by the client to ensure that the request
        /// is handled exactly once. This token helps prevent duplicate context creations and
        /// must not exceed sixty-four alphanumeric characters. Use a UUID or other unique string
        /// to ensure idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralSelling.Model.CreateEngagementContextResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralSelling.Model.CreateEngagementContextResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EngagementIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCEngagementContext (CreateEngagementContext)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralSelling.Model.CreateEngagementContextResponse, NewPCEngagementContextCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            if (this.Lead_Interaction != null)
            {
                context.Lead_Interaction = new List<Amazon.PartnerCentralSelling.Model.LeadInteraction>(this.Lead_Interaction);
            }
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
            var request = new Amazon.PartnerCentralSelling.Model.CreateEngagementContextRequest();
            
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
            
             // populate Payload
            var requestPayloadIsNull = true;
            request.Payload = new Amazon.PartnerCentralSelling.Model.EngagementContextPayload();
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
            Amazon.PartnerCentralSelling.Model.LeadContext requestPayload_payload_Lead = null;
            
             // populate Lead
            var requestPayload_payload_LeadIsNull = true;
            requestPayload_payload_Lead = new Amazon.PartnerCentralSelling.Model.LeadContext();
            List<Amazon.PartnerCentralSelling.Model.LeadInteraction> requestPayload_payload_Lead_lead_Interaction = null;
            if (cmdletContext.Lead_Interaction != null)
            {
                requestPayload_payload_Lead_lead_Interaction = cmdletContext.Lead_Interaction;
            }
            if (requestPayload_payload_Lead_lead_Interaction != null)
            {
                requestPayload_payload_Lead.Interactions = requestPayload_payload_Lead_lead_Interaction;
                requestPayload_payload_LeadIsNull = false;
            }
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
        
        private Amazon.PartnerCentralSelling.Model.CreateEngagementContextResponse CallAWSServiceOperation(IAmazonPartnerCentralSelling client, Amazon.PartnerCentralSelling.Model.CreateEngagementContextRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Selling API", "CreateEngagementContext");
            try
            {
                return client.CreateEngagementContextAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.PartnerCentralSelling.Model.LeadInteraction> Lead_Interaction { get; set; }
            public System.String Lead_QualificationStatus { get; set; }
            public Amazon.PartnerCentralSelling.EngagementContextType Type { get; set; }
            public System.Func<Amazon.PartnerCentralSelling.Model.CreateEngagementContextResponse, NewPCEngagementContextCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
