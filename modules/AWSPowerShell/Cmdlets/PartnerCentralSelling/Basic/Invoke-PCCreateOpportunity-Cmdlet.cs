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
    /// Creates an <c>Opportunity</c> record in Partner Central. Use this operation to create
    /// a potential business opportunity for submission to Amazon Web Services. Creating an
    /// opportunity sets <c>Lifecycle.ReviewStatus</c> to <c>Pending Submission</c>.
    /// 
    ///  
    /// <para>
    /// To submit an opportunity, follow these steps:
    /// </para><ol><li><para>
    /// To create the opportunity, use <c>CreateOpportunity</c>.
    /// </para></li><li><para>
    /// To associate a solution with the opportunity, use <c>AssociateOpportunity</c>.
    /// </para></li><li><para>
    /// To start the engagement with AWS, use <c>StartEngagementFromOpportunity</c>.
    /// </para></li></ol><para>
    /// After submission, you can't edit the opportunity until the review is complete. But
    /// opportunities in the <c>Pending Submission</c> state must have complete details. You
    /// can update the opportunity while it's in the <c>Pending Submission</c> state.
    /// </para><para>
    /// There's a set of mandatory fields to create opportunities, but consider providing
    /// optional fields to enrich the opportunity record.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "PCCreateOpportunity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Partner Central Selling API CreateOpportunity API operation.", Operation = new[] {"CreateOpportunity"}, SelectReturnType = typeof(Amazon.PartnerCentralSelling.Model.CreateOpportunityResponse))]
    [AWSCmdletOutput("System.String or Amazon.PartnerCentralSelling.Model.CreateOpportunityResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.PartnerCentralSelling.Model.CreateOpportunityResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokePCCreateOpportunityCmdlet : AmazonPartnerCentralSellingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Project_AdditionalComment
        /// <summary>
        /// <para>
        /// <para>Captures additional comments or information for the <c>Opportunity</c> that weren't
        /// captured in other fields.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Project_AdditionalComments")]
        public System.String Project_AdditionalComment { get; set; }
        #endregion
        
        #region Parameter Value_Amount
        /// <summary>
        /// <para>
        /// <para>Specifies the payment amount.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SoftwareRevenue_Value_Amount")]
        public System.String Value_Amount { get; set; }
        #endregion
        
        #region Parameter Project_ApnProgram
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Partner Network (APN) program that influenced the <c>Opportunity</c>.
        /// APN programs refer to specific partner programs or initiatives that can impact the
        /// <c>Opportunity</c>.</para><para>Valid values: <c>APN Immersion Days | APN Solution Space | ATO (Authority to Operate)
        /// | AWS Marketplace Campaign | IS Immersion Day SFID Program | ISV Workload Migration
        /// | Migration Acceleration Program | P3 | Partner Launch Initiative | Partner Opportunity
        /// Acceleration Funded | The Next Smart | VMware Cloud on AWS | Well-Architected | Windows
        /// | Workspaces/AppStream Accelerator Program | WWPS NDPP</c></para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Project_ApnPrograms")]
        public System.String[] Project_ApnProgram { get; set; }
        #endregion
        
        #region Parameter Account_AwsAccountId
        /// <summary>
        /// <para>
        /// <para>Specifies the <c>Customer</c> Amazon Web Services account ID associated with the <c>Opportunity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_Account_AwsAccountId")]
        public System.String Account_AwsAccountId { get; set; }
        #endregion
        
        #region Parameter Marketing_AwsFundingUsed
        /// <summary>
        /// <para>
        /// <para>Indicates if the <c>Opportunity</c> is a marketing development fund (MDF) funded activity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.AwsFundingUsed")]
        public Amazon.PartnerCentralSelling.AwsFundingUsed Marketing_AwsFundingUsed { get; set; }
        #endregion
        
        #region Parameter Project_AwsPartition
        /// <summary>
        /// <para>
        /// <para>AWS partition where the opportunity will be deployed. Possible values: <c>aws-eusc</c>
        /// for AWS European Sovereign Cloud, <c>null</c> for all other partitions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.AwsPartition")]
        public Amazon.PartnerCentralSelling.AwsPartition Project_AwsPartition { get; set; }
        #endregion
        
        #region Parameter Marketing_CampaignName
        /// <summary>
        /// <para>
        /// <para>Specifies the <c>Opportunity</c> marketing campaign code. The Amazon Web Services
        /// campaign code is a reference to specific marketing initiatives, promotions, or activities.
        /// This field captures the identifier used to track and categorize the <c>Opportunity</c>
        /// within marketing campaigns. If you don't have a campaign code, contact your Amazon
        /// Web Services point of contact to obtain one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Marketing_CampaignName { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>Specifies the catalog associated with the request. This field takes a string value
        /// from a predefined list: <c>AWS</c> or <c>Sandbox</c>. The catalog determines which
        /// environment the opportunity is created in. Use <c>AWS</c> to create opportunities
        /// in the Amazon Web Services catalog, and <c>Sandbox</c> for testing in secure, isolated
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
        
        #region Parameter Marketing_Channel
        /// <summary>
        /// <para>
        /// <para>Specifies the <c>Opportunity</c>'s channel that the marketing activity is associated
        /// with or was contacted through. This field provides information about the specific
        /// marketing channel that contributed to the generation of the lead or contact.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Marketing_Channels")]
        public System.String[] Marketing_Channel { get; set; }
        #endregion
        
        #region Parameter Address_City
        /// <summary>
        /// <para>
        /// <para>Specifies the end <c>Customer</c>'s city associated with the <c>Opportunity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_Account_Address_City")]
        public System.String Address_City { get; set; }
        #endregion
        
        #region Parameter LifeCycle_ClosedLostReason
        /// <summary>
        /// <para>
        /// <para>Specifies the reason code when an opportunity is marked as <i>Closed Lost</i>. When
        /// you select an appropriate reason code, you communicate the context for closing the
        /// <c>Opportunity</c>, and aid in accurate reports and analysis of opportunity outcomes.
        /// The possible values are:</para><ul><li><para>Customer Deficiency: The customer lacked necessary resources or capabilities.</para></li><li><para>Delay/Cancellation of Project: The project was delayed or canceled.</para></li><li><para>Legal/Tax/Regulatory: Legal, tax, or regulatory issues prevented progress.</para></li><li><para>Lost to Competitor—Google: The opportunity was lost to Google.</para></li><li><para>Lost to Competitor—Microsoft: The opportunity was lost to Microsoft.</para></li><li><para>Lost to Competitor—SoftLayer: The opportunity was lost to SoftLayer.</para></li><li><para>Lost to Competitor—VMWare: The opportunity was lost to VMWare.</para></li><li><para>Lost to Competitor—Other: The opportunity was lost to a competitor not listed above.</para></li><li><para>No Opportunity: There was no opportunity to pursue.</para></li><li><para>On Premises Deployment: The customer chose an on-premises solution.</para></li><li><para>Partner Gap: The partner lacked necessary resources or capabilities.</para></li><li><para>Price: The price was not competitive or acceptable to the customer.</para></li><li><para>Security/Compliance: Security or compliance issues prevented progress.</para></li><li><para>Technical Limitations: Technical limitations prevented progress.</para></li><li><para>Customer Experience: Issues related to the customer's experience impacted the decision.</para></li><li><para>Other: Any reason not covered by the other values.</para></li><li><para>People/Relationship/Governance: Issues related to people, relationships, or governance.</para></li><li><para>Product/Technology: Issues related to the product or technology.</para></li><li><para>Financial/Commercial: Financial or commercial issues impacted the decision.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.ClosedLostReason")]
        public Amazon.PartnerCentralSelling.ClosedLostReason LifeCycle_ClosedLostReason { get; set; }
        #endregion
        
        #region Parameter Account_CompanyName
        /// <summary>
        /// <para>
        /// <para>Specifies the end <c>Customer</c>'s company name associated with the <c>Opportunity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("Customer_Account_CompanyName")]
        public System.String Account_CompanyName { get; set; }
        #endregion
        
        #region Parameter Project_CompetitorName
        /// <summary>
        /// <para>
        /// <para>Name of the <c>Opportunity</c>'s competitor (if any). Use <c>Other</c> to submit a
        /// value not in the picklist.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.CompetitorName")]
        public Amazon.PartnerCentralSelling.CompetitorName Project_CompetitorName { get; set; }
        #endregion
        
        #region Parameter Customer_Contact
        /// <summary>
        /// <para>
        /// <para>Represents the contact details for individuals associated with the customer of the
        /// <c>Opportunity</c>. This field captures relevant contacts, including decision-makers,
        /// influencers, and technical stakeholders within the customer organization. These contacts
        /// are key to progressing the opportunity.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_Contacts")]
        public Amazon.PartnerCentralSelling.Model.Contact[] Customer_Contact { get; set; }
        #endregion
        
        #region Parameter Address_CountryCode
        /// <summary>
        /// <para>
        /// <para>Specifies the end <c>Customer</c>'s country associated with the <c>Opportunity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_Account_Address_CountryCode")]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.CountryCode")]
        public Amazon.PartnerCentralSelling.CountryCode Address_CountryCode { get; set; }
        #endregion
        
        #region Parameter Value_CurrencyCode
        /// <summary>
        /// <para>
        /// <para>Specifies the payment currency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SoftwareRevenue_Value_CurrencyCode")]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.CurrencyCode")]
        public Amazon.PartnerCentralSelling.CurrencyCode Value_CurrencyCode { get; set; }
        #endregion
        
        #region Parameter Project_CustomerBusinessProblem
        /// <summary>
        /// <para>
        /// <para>Describes the problem the end customer has, and how the partner is helping. Utilize
        /// this field to provide a concise narrative that outlines the customer's business challenge
        /// or issue. Elaborate on how the partner's solution or offerings align to resolve the
        /// customer's business problem. Include relevant information about the partner's value
        /// proposition, unique selling points, and expertise to tackle the issue. Offer insights
        /// on how the proposed solution meets the customer's needs and provides value. Use concise
        /// language and precise descriptions to convey the context and significance of the <c>Opportunity</c>.
        /// The content in this field helps Amazon Web Services understand the nature of the <c>Opportunity</c>
        /// and the strategic fit of the partner's solution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Project_CustomerBusinessProblem { get; set; }
        #endregion
        
        #region Parameter Project_CustomerUseCase
        /// <summary>
        /// <para>
        /// <para>Specifies the proposed solution focus or type of workload for the Opportunity. This
        /// field captures the primary use case or objective of the proposed solution, and provides
        /// context and clarity to the addressed workload.</para><para>Valid values: <c>AI Machine Learning and Analytics | Archiving | Big Data: Data Warehouse/Data
        /// Integration/ETL/Data Lake/BI | Blockchain | Business Applications: Mainframe Modernization
        /// | Business Applications &amp; Contact Center | Business Applications &amp; SAP Production
        /// | Centralized Operations Management | Cloud Management Tools | Cloud Management Tools
        /// &amp; DevOps with Continuous Integration &amp; Continuous Delivery (CICD) | Configuration,
        /// Compliance &amp; Auditing | Connected Services | Containers &amp; Serverless | Content
        /// Delivery &amp; Edge Services | Database | Edge Computing/End User Computing | Energy
        /// | Enterprise Governance &amp; Controls | Enterprise Resource Planning | Financial
        /// Services | Healthcare and Life Sciences | High Performance Computing | Hybrid Application
        /// Platform | Industrial Software | IOT | Manufacturing, Supply Chain and Operations
        /// | Media &amp; High performance computing (HPC) | Migration/Database Migration | Monitoring,
        /// logging and performance | Monitoring &amp; Observability | Networking | Outpost |
        /// SAP | Security &amp; Compliance | Storage &amp; Backup | Training | VMC | VMWare |
        /// Web development &amp; DevOps</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Project_CustomerUseCase { get; set; }
        #endregion
        
        #region Parameter SoftwareRevenue_DeliveryModel
        /// <summary>
        /// <para>
        /// <para>Specifies the customer's intended payment type agreement or procurement method to
        /// acquire the solution or service outlined in the <c>Opportunity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.RevenueModel")]
        public Amazon.PartnerCentralSelling.RevenueModel SoftwareRevenue_DeliveryModel { get; set; }
        #endregion
        
        #region Parameter Project_DeliveryModel
        /// <summary>
        /// <para>
        /// <para>Specifies the deployment or consumption model for your solution or service in the
        /// <c>Opportunity</c>'s context. You can select multiple options.</para><para>Options' descriptions from the <c>Delivery Model</c> field are:</para><ul><li><para>SaaS or PaaS: Your Amazon Web Services based solution deployed as SaaS or PaaS in
        /// your Amazon Web Services environment.</para></li><li><para>BYOL or AMI: Your Amazon Web Services based solution deployed as BYOL or AMI in the
        /// end customer's Amazon Web Services environment.</para></li><li><para>Managed Services: The end customer's Amazon Web Services business management (For
        /// example: Consulting, design, implementation, billing support, cost optimization, technical
        /// support).</para></li><li><para>Professional Services: Offerings to help enterprise end customers achieve specific
        /// business outcomes for enterprise cloud adoption (For example: Advisory or transformation
        /// planning).</para></li><li><para>Resell: Amazon Web Services accounts and billing management for your customers.</para></li><li><para>Other: Delivery model not described above.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Project_DeliveryModels")]
        public System.String[] Project_DeliveryModel { get; set; }
        #endregion
        
        #region Parameter Account_Dun
        /// <summary>
        /// <para>
        /// <para>Indicates the <c>Customer</c> DUNS number, if available.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_Account_Duns")]
        public System.String Account_Dun { get; set; }
        #endregion
        
        #region Parameter SoftwareRevenue_EffectiveDate
        /// <summary>
        /// <para>
        /// <para>Specifies the <c>Opportunity</c>'s customer engagement start date for the contract's
        /// effectiveness.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SoftwareRevenue_EffectiveDate { get; set; }
        #endregion
        
        #region Parameter Project_ExpectedCustomerSpend
        /// <summary>
        /// <para>
        /// <para>Represents the estimated amount that the customer is expected to spend on AWS services
        /// related to the opportunity. This helps in evaluating the potential financial value
        /// of the opportunity for AWS.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.PartnerCentralSelling.Model.ExpectedCustomerSpend[] Project_ExpectedCustomerSpend { get; set; }
        #endregion
        
        #region Parameter SoftwareRevenue_ExpirationDate
        /// <summary>
        /// <para>
        /// <para>Specifies the expiration date for the contract between the customer and Amazon Web
        /// Services partner. It signifies the termination date of the agreed-upon engagement
        /// period between both parties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SoftwareRevenue_ExpirationDate { get; set; }
        #endregion
        
        #region Parameter Account_Industry
        /// <summary>
        /// <para>
        /// <para>Specifies the industry the end <c>Customer</c> belongs to that's associated with the
        /// <c>Opportunity</c>. It refers to the category or sector where the customer's business
        /// operates. This is a required field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_Account_Industry")]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.Industry")]
        public Amazon.PartnerCentralSelling.Industry Account_Industry { get; set; }
        #endregion
        
        #region Parameter NationalSecurity
        /// <summary>
        /// <para>
        /// <para>Indicates whether the <c>Opportunity</c> pertains to a national security project.
        /// This field must be set to <c>true</c> only when the customer's industry is <i>Government</i>.
        /// Additional privacy and security measures apply during the review and management process
        /// for opportunities marked as <c>NationalSecurity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.NationalSecurity")]
        public Amazon.PartnerCentralSelling.NationalSecurity NationalSecurity { get; set; }
        #endregion
        
        #region Parameter LifeCycle_NextStep
        /// <summary>
        /// <para>
        /// <para>Specifies the upcoming actions or tasks for the <c>Opportunity</c>. Use this field
        /// to communicate with Amazon Web Services about the next actions required for the <c>Opportunity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LifeCycle_NextSteps")]
        public System.String LifeCycle_NextStep { get; set; }
        #endregion
        
        #region Parameter LifeCycle_NextStepsHistory
        /// <summary>
        /// <para>
        /// <para>Captures a chronological record of the next steps or actions planned or taken for
        /// the current opportunity, along with the timestamp.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.PartnerCentralSelling.Model.NextStepsHistory[] LifeCycle_NextStepsHistory { get; set; }
        #endregion
        
        #region Parameter OpportunityTeam
        /// <summary>
        /// <para>
        /// <para>Represents the internal team handling the opportunity. Specify collaborating members
        /// of this opportunity who are within the partner's organization.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.PartnerCentralSelling.Model.Contact[] OpportunityTeam { get; set; }
        #endregion
        
        #region Parameter OpportunityType
        /// <summary>
        /// <para>
        /// <para>Specifies the opportunity type as a renewal, new, or expansion.</para><para>Opportunity types:</para><ul><li><para>New opportunity: Represents a new business opportunity with a potential customer that's
        /// not previously engaged with your solutions or services.</para></li><li><para>Renewal opportunity: Represents an opportunity to renew an existing contract or subscription
        /// with a current customer, ensuring continuity of service.</para></li><li><para>Expansion opportunity: Represents an opportunity to expand the scope of an existing
        /// contract or subscription, either by adding new services or increasing the volume of
        /// existing services for a current customer.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.OpportunityType")]
        public Amazon.PartnerCentralSelling.OpportunityType OpportunityType { get; set; }
        #endregion
        
        #region Parameter Origin
        /// <summary>
        /// <para>
        /// <para>Specifies the origin of the opportunity, indicating if it was sourced from Amazon
        /// Web Services or the partner. For all opportunities created with <c>Catalog: AWS</c>,
        /// this field must only be <c>Partner Referral</c>. However, when using <c>Catalog: Sandbox</c>,
        /// you can set this field to <c>AWS Referral</c> to simulate Amazon Web Services referral
        /// creation. This allows Amazon Web Services-originated flows testing in the sandbox
        /// catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.OpportunityOrigin")]
        public Amazon.PartnerCentralSelling.OpportunityOrigin Origin { get; set; }
        #endregion
        
        #region Parameter Project_OtherCompetitorName
        /// <summary>
        /// <para>
        /// <para>Only allowed when <c>CompetitorNames</c> has <c>Other</c> selected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Project_OtherCompetitorNames")]
        public System.String Project_OtherCompetitorName { get; set; }
        #endregion
        
        #region Parameter Account_OtherIndustry
        /// <summary>
        /// <para>
        /// <para>Specifies the end <c>Customer</c>'s industry associated with the <c>Opportunity</c>,
        /// when the selected value in the <c>Industry</c> field is <c>Other</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_Account_OtherIndustry")]
        public System.String Account_OtherIndustry { get; set; }
        #endregion
        
        #region Parameter Project_OtherSolutionDescription
        /// <summary>
        /// <para>
        /// <para>Specifies the offered solution for the customer's business problem when the <c> RelatedEntityIdentifiers.Solutions</c>
        /// field value is <c>Other</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Project_OtherSolutionDescription { get; set; }
        #endregion
        
        #region Parameter PartnerOpportunityIdentifier
        /// <summary>
        /// <para>
        /// <para>Specifies the opportunity's unique identifier in the partner's CRM system. This value
        /// is essential to track and reconcile because it's included in the outbound payload
        /// to the partner.</para><para>This field allows partners to link an opportunity to their CRM, which helps to ensure
        /// seamless integration and accurate synchronization between the Partner Central API
        /// and the partner's internal systems.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PartnerOpportunityIdentifier { get; set; }
        #endregion
        
        #region Parameter Address_PostalCode
        /// <summary>
        /// <para>
        /// <para>Specifies the end <c>Customer</c>'s postal code associated with the <c>Opportunity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_Account_Address_PostalCode")]
        public System.String Address_PostalCode { get; set; }
        #endregion
        
        #region Parameter PrimaryNeedsFromAw
        /// <summary>
        /// <para>
        /// <para>Identifies the type of support the partner needs from Amazon Web Services.</para><para>Valid values:</para><ul><li><para>Cosell—Architectural Validation: Confirmation from Amazon Web Services that the partner's
        /// proposed solution architecture is aligned with Amazon Web Services best practices
        /// and poses minimal architectural risks.</para></li><li><para>Cosell—Business Presentation: Request Amazon Web Services seller's participation in
        /// a joint customer presentation.</para></li><li><para>Cosell—Competitive Information: Access to Amazon Web Services competitive resources
        /// and support for the partner's proposed solution.</para></li><li><para>Cosell—Pricing Assistance: Connect with an Amazon Web Services seller for support
        /// situations where a partner may be receiving an upfront discount on a service (for
        /// example: EDP deals).</para></li><li><para>Cosell—Technical Consultation: Connect with an Amazon Web Services Solutions Architect
        /// to address the partner's questions about the proposed solution.</para></li><li><para>Cosell—Total Cost of Ownership Evaluation: Assistance with quoting different cost
        /// savings of proposed solutions on Amazon Web Services versus on-premises or a traditional
        /// hosting environment.</para></li><li><para>Cosell—Deal Support: Request Amazon Web Services seller's support to progress the
        /// opportunity (for example: joint customer call, strategic positioning).</para></li><li><para>Cosell—Support for Public Tender/RFx: Opportunity related to the public sector where
        /// the partner needs Amazon Web Services RFx support.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrimaryNeedsFromAws")]
        public System.String[] PrimaryNeedsFromAw { get; set; }
        #endregion
        
        #region Parameter Project_RelatedOpportunityIdentifier
        /// <summary>
        /// <para>
        /// <para>Specifies the current opportunity's parent opportunity identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Project_RelatedOpportunityIdentifier { get; set; }
        #endregion
        
        #region Parameter LifeCycle_ReviewComment
        /// <summary>
        /// <para>
        /// <para>Contains detailed feedback from Amazon Web Services when requesting additional information
        /// from partners. Provides specific guidance on what partners need to provide or clarify
        /// for opportunity validation, complementing the <c>ReviewStatusReason</c> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LifeCycle_ReviewComments")]
        public System.String LifeCycle_ReviewComment { get; set; }
        #endregion
        
        #region Parameter LifeCycle_ReviewStatus
        /// <summary>
        /// <para>
        /// <para>Indicates the review status of an opportunity referred by a partner. This field is
        /// read-only and only applicable for partner referrals. The possible values are:</para><ul><li><para>Pending Submission: Not submitted for validation (editable).</para></li><li><para>Submitted: Submitted for validation, and Amazon Web Services hasn't reviewed it (read-only).</para></li><li><para>In Review: Amazon Web Services is validating (read-only).</para></li><li><para>Action Required: Issues that Amazon Web Services highlights need to be addressed.
        /// Partners should use the <c>UpdateOpportunity</c> API action to update the opportunity
        /// and helps to ensure that all required changes are made. Only the following fields
        /// are editable when the <c>Lifecycle.ReviewStatus</c> is <c>Action Required</c>:</para><ul><li><para>Customer.Account.Address.City</para></li><li><para>Customer.Account.Address.CountryCode</para></li><li><para>Customer.Account.Address.PostalCode</para></li><li><para>Customer.Account.Address.StateOrRegion</para></li><li><para>Customer.Account.Address.StreetAddress</para></li><li><para>Customer.Account.WebsiteUrl</para></li><li><para>LifeCycle.TargetCloseDate</para></li><li><para>Project.ExpectedMonthlyAWSRevenue.Amount</para></li><li><para>Project.ExpectedMonthlyAWSRevenue.CurrencyCode</para></li><li><para>Project.CustomerBusinessProblem</para></li><li><para>PartnerOpportunityIdentifier</para></li></ul><para>After updates, the opportunity re-enters the validation phase. This process repeats
        /// until all issues are resolved, and the opportunity's <c>Lifecycle.ReviewStatus</c>
        /// is set to <c>Approved</c> or <c>Rejected</c>.</para></li><li><para>Approved: Validated and converted into the Amazon Web Services seller's pipeline (editable).</para></li><li><para>Rejected: Disqualified (read-only).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.ReviewStatus")]
        public Amazon.PartnerCentralSelling.ReviewStatus LifeCycle_ReviewStatus { get; set; }
        #endregion
        
        #region Parameter LifeCycle_ReviewStatusReason
        /// <summary>
        /// <para>
        /// <para>Code indicating the validation decision during the Amazon Web Services opportunity
        /// review. Applies when status is <c>Rejected</c> or <c>Action Required</c>. Used to
        /// document validation results for AWS Partner Referrals and indicate when additional
        /// information is needed from partners as part of the APN Customer Engagement (ACE) program.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LifeCycle_ReviewStatusReason { get; set; }
        #endregion
        
        #region Parameter Project_SalesActivity
        /// <summary>
        /// <para>
        /// <para>Specifies the <c>Opportunity</c>'s sales activities conducted with the end customer.
        /// These activities help drive Amazon Web Services assignment priority.</para><para>Valid values:</para><ul><li><para>Initialized discussions with customer: Initial conversations with the customer to
        /// understand their needs and introduce your solution.</para></li><li><para>Customer has shown interest in solution: After initial discussions, the customer is
        /// interested in your solution.</para></li><li><para>Conducted POC/demo: You conducted a proof of concept (POC) or demonstration of the
        /// solution for the customer.</para></li><li><para>In evaluation/planning stage: The customer is evaluating the solution and planning
        /// potential implementation.</para></li><li><para>Agreed on solution to Business Problem: Both parties agree on how the solution addresses
        /// the customer's business problem.</para></li><li><para>Completed Action Plan: A detailed action plan is complete and outlines the steps for
        /// implementation.</para></li><li><para>Finalized Deployment Need: Both parties agree with and finalized the deployment needs.</para></li><li><para>SOW Signed: Both parties signed a statement of work (SOW), and formalize the agreement
        /// and detail the project scope and deliverables.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Project_SalesActivities")]
        public System.String[] Project_SalesActivity { get; set; }
        #endregion
        
        #region Parameter Marketing_Source
        /// <summary>
        /// <para>
        /// <para>Indicates if the <c>Opportunity</c> was sourced from an Amazon Web Services marketing
        /// activity. Use the value <c>Marketing Activity</c>. Use <c>None</c> if it's not associated
        /// with an Amazon Web Services marketing activity. This field helps Amazon Web Services
        /// track the return on marketing investments and enables better distribution of marketing
        /// budgets among partners.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.MarketingSource")]
        public Amazon.PartnerCentralSelling.MarketingSource Marketing_Source { get; set; }
        #endregion
        
        #region Parameter LifeCycle_Stage
        /// <summary>
        /// <para>
        /// <para>Specifies the current stage of the <c>Opportunity</c>'s lifecycle as it maps to Amazon
        /// Web Services stages from the current stage in the partner CRM. This field provides
        /// a translated value of the stage, and offers insight into the <c>Opportunity</c>'s
        /// progression in the sales cycle, according to Amazon Web Services definitions.</para><note><para>A lead and a prospect must be further matured to a <c>Qualified</c> opportunity before
        /// submission. Opportunities that were closed/lost before submission aren't suitable
        /// for submission.</para></note><para>The descriptions of each sales stage are:</para><ul><li><para>Prospect: Amazon Web Services identifies the opportunity. It can be active (Comes
        /// directly from the end customer through a lead) or latent (Your account team believes
        /// it exists based on research, account plans, sales plays).</para></li><li><para>Qualified: Your account team engaged with the customer to discuss viability and requirements.
        /// The customer agreed that the opportunity is real, of interest, and may solve business/technical
        /// needs.</para></li><li><para>Technical Validation: All parties understand the implementation plan.</para></li><li><para>Business Validation: Pricing was proposed, and all parties agree to the steps to close.</para></li><li><para>Committed: The customer signed the contract, but Amazon Web Services hasn't started
        /// billing.</para></li><li><para>Launched: The workload is complete, and Amazon Web Services has started billing.</para></li><li><para>Closed Lost: The opportunity is lost, and there are no steps to move forward.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.Stage")]
        public Amazon.PartnerCentralSelling.Stage LifeCycle_Stage { get; set; }
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
        [Alias("Customer_Account_Address_StateOrRegion")]
        public System.String Address_StateOrRegion { get; set; }
        #endregion
        
        #region Parameter Address_StreetAddress
        /// <summary>
        /// <para>
        /// <para>Specifies the end <c>Customer</c>'s street address associated with the <c>Opportunity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_Account_Address_StreetAddress")]
        public System.String Address_StreetAddress { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of the key-value pairs of the tag or tags to assign.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.PartnerCentralSelling.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter LifeCycle_TargetCloseDate
        /// <summary>
        /// <para>
        /// <para>Specifies the date when Amazon Web Services expects to start significant billing,
        /// when the project finishes, and when it moves into production. This field informs the
        /// Amazon Web Services seller about when the opportunity launches and starts to incur
        /// Amazon Web Services usage.</para><para>Ensure the <c>Target Close Date</c> isn't in the past.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LifeCycle_TargetCloseDate { get; set; }
        #endregion
        
        #region Parameter Project_Title
        /// <summary>
        /// <para>
        /// <para>Specifies the <c>Opportunity</c>'s title or name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Project_Title { get; set; }
        #endregion
        
        #region Parameter Marketing_UseCase
        /// <summary>
        /// <para>
        /// <para>Specifies the marketing activity use case or purpose that led to the <c>Opportunity</c>'s
        /// creation or contact. This field captures the context or marketing activity's execution's
        /// intention and the direct correlation to the generated opportunity or contact. Must
        /// be empty when <c>Marketing.AWSFundingUsed = No</c>.</para><para>Valid values: <c>AI/ML | Analytics | Application Integration | Blockchain | Business
        /// Applications | Cloud Financial Management | Compute | Containers | Customer Engagement
        /// | Databases | Developer Tools | End User Computing | Front End Web &amp; Mobile |
        /// Game Tech | IoT | Management &amp; Governance | Media Services | Migration &amp; Transfer
        /// | Networking &amp; Content Delivery | Quantum Technologies | Robotics | Satellite
        /// | Security | Serverless | Storage | VR &amp; AR</c></para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Marketing_UseCases")]
        public System.String[] Marketing_UseCase { get; set; }
        #endregion
        
        #region Parameter Account_WebsiteUrl
        /// <summary>
        /// <para>
        /// <para>Specifies the end customer's company website URL associated with the <c>Opportunity</c>.
        /// This value is crucial to map the customer within the Amazon Web Services CRM system.
        /// This field is required in all cases except when the opportunity is related to national
        /// security.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customer_Account_WebsiteUrl")]
        public System.String Account_WebsiteUrl { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Required to be unique, and should be unchanging, it can be randomly generated or a
        /// meaningful string.</para><para>Default: None</para><para>Best practice: To help ensure uniqueness and avoid conflicts, use a Universally Unique
        /// Identifier (UUID) as the <c>ClientToken</c>. You can use standard libraries from most
        /// programming languages to generate this. If you use the same client token, the API
        /// returns the following error: "Conflicting client token submitted for a new request
        /// body."</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Id'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralSelling.Model.CreateOpportunityResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralSelling.Model.CreateOpportunityResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Account_CompanyName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-PCCreateOpportunity (CreateOpportunity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralSelling.Model.CreateOpportunityResponse, InvokePCCreateOpportunityCmdlet>(Select) ??
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
            context.Address_City = this.Address_City;
            context.Address_CountryCode = this.Address_CountryCode;
            context.Address_PostalCode = this.Address_PostalCode;
            context.Address_StateOrRegion = this.Address_StateOrRegion;
            context.Address_StreetAddress = this.Address_StreetAddress;
            context.Account_AwsAccountId = this.Account_AwsAccountId;
            context.Account_CompanyName = this.Account_CompanyName;
            context.Account_Dun = this.Account_Dun;
            context.Account_Industry = this.Account_Industry;
            context.Account_OtherIndustry = this.Account_OtherIndustry;
            context.Account_WebsiteUrl = this.Account_WebsiteUrl;
            if (this.Customer_Contact != null)
            {
                context.Customer_Contact = new List<Amazon.PartnerCentralSelling.Model.Contact>(this.Customer_Contact);
            }
            context.LifeCycle_ClosedLostReason = this.LifeCycle_ClosedLostReason;
            context.LifeCycle_NextStep = this.LifeCycle_NextStep;
            if (this.LifeCycle_NextStepsHistory != null)
            {
                context.LifeCycle_NextStepsHistory = new List<Amazon.PartnerCentralSelling.Model.NextStepsHistory>(this.LifeCycle_NextStepsHistory);
            }
            context.LifeCycle_ReviewComment = this.LifeCycle_ReviewComment;
            context.LifeCycle_ReviewStatus = this.LifeCycle_ReviewStatus;
            context.LifeCycle_ReviewStatusReason = this.LifeCycle_ReviewStatusReason;
            context.LifeCycle_Stage = this.LifeCycle_Stage;
            context.LifeCycle_TargetCloseDate = this.LifeCycle_TargetCloseDate;
            context.Marketing_AwsFundingUsed = this.Marketing_AwsFundingUsed;
            context.Marketing_CampaignName = this.Marketing_CampaignName;
            if (this.Marketing_Channel != null)
            {
                context.Marketing_Channel = new List<System.String>(this.Marketing_Channel);
            }
            context.Marketing_Source = this.Marketing_Source;
            if (this.Marketing_UseCase != null)
            {
                context.Marketing_UseCase = new List<System.String>(this.Marketing_UseCase);
            }
            context.NationalSecurity = this.NationalSecurity;
            if (this.OpportunityTeam != null)
            {
                context.OpportunityTeam = new List<Amazon.PartnerCentralSelling.Model.Contact>(this.OpportunityTeam);
            }
            context.OpportunityType = this.OpportunityType;
            context.Origin = this.Origin;
            context.PartnerOpportunityIdentifier = this.PartnerOpportunityIdentifier;
            if (this.PrimaryNeedsFromAw != null)
            {
                context.PrimaryNeedsFromAw = new List<System.String>(this.PrimaryNeedsFromAw);
            }
            context.Project_AdditionalComment = this.Project_AdditionalComment;
            if (this.Project_ApnProgram != null)
            {
                context.Project_ApnProgram = new List<System.String>(this.Project_ApnProgram);
            }
            context.Project_AwsPartition = this.Project_AwsPartition;
            context.Project_CompetitorName = this.Project_CompetitorName;
            context.Project_CustomerBusinessProblem = this.Project_CustomerBusinessProblem;
            context.Project_CustomerUseCase = this.Project_CustomerUseCase;
            if (this.Project_DeliveryModel != null)
            {
                context.Project_DeliveryModel = new List<System.String>(this.Project_DeliveryModel);
            }
            if (this.Project_ExpectedCustomerSpend != null)
            {
                context.Project_ExpectedCustomerSpend = new List<Amazon.PartnerCentralSelling.Model.ExpectedCustomerSpend>(this.Project_ExpectedCustomerSpend);
            }
            context.Project_OtherCompetitorName = this.Project_OtherCompetitorName;
            context.Project_OtherSolutionDescription = this.Project_OtherSolutionDescription;
            context.Project_RelatedOpportunityIdentifier = this.Project_RelatedOpportunityIdentifier;
            if (this.Project_SalesActivity != null)
            {
                context.Project_SalesActivity = new List<System.String>(this.Project_SalesActivity);
            }
            context.Project_Title = this.Project_Title;
            context.SoftwareRevenue_DeliveryModel = this.SoftwareRevenue_DeliveryModel;
            context.SoftwareRevenue_EffectiveDate = this.SoftwareRevenue_EffectiveDate;
            context.SoftwareRevenue_ExpirationDate = this.SoftwareRevenue_ExpirationDate;
            context.Value_Amount = this.Value_Amount;
            context.Value_CurrencyCode = this.Value_CurrencyCode;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.PartnerCentralSelling.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.PartnerCentralSelling.Model.CreateOpportunityRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Customer
            var requestCustomerIsNull = true;
            request.Customer = new Amazon.PartnerCentralSelling.Model.Customer();
            List<Amazon.PartnerCentralSelling.Model.Contact> requestCustomer_customer_Contact = null;
            if (cmdletContext.Customer_Contact != null)
            {
                requestCustomer_customer_Contact = cmdletContext.Customer_Contact;
            }
            if (requestCustomer_customer_Contact != null)
            {
                request.Customer.Contacts = requestCustomer_customer_Contact;
                requestCustomerIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.Account requestCustomer_customer_Account = null;
            
             // populate Account
            var requestCustomer_customer_AccountIsNull = true;
            requestCustomer_customer_Account = new Amazon.PartnerCentralSelling.Model.Account();
            System.String requestCustomer_customer_Account_account_AwsAccountId = null;
            if (cmdletContext.Account_AwsAccountId != null)
            {
                requestCustomer_customer_Account_account_AwsAccountId = cmdletContext.Account_AwsAccountId;
            }
            if (requestCustomer_customer_Account_account_AwsAccountId != null)
            {
                requestCustomer_customer_Account.AwsAccountId = requestCustomer_customer_Account_account_AwsAccountId;
                requestCustomer_customer_AccountIsNull = false;
            }
            System.String requestCustomer_customer_Account_account_CompanyName = null;
            if (cmdletContext.Account_CompanyName != null)
            {
                requestCustomer_customer_Account_account_CompanyName = cmdletContext.Account_CompanyName;
            }
            if (requestCustomer_customer_Account_account_CompanyName != null)
            {
                requestCustomer_customer_Account.CompanyName = requestCustomer_customer_Account_account_CompanyName;
                requestCustomer_customer_AccountIsNull = false;
            }
            System.String requestCustomer_customer_Account_account_Dun = null;
            if (cmdletContext.Account_Dun != null)
            {
                requestCustomer_customer_Account_account_Dun = cmdletContext.Account_Dun;
            }
            if (requestCustomer_customer_Account_account_Dun != null)
            {
                requestCustomer_customer_Account.Duns = requestCustomer_customer_Account_account_Dun;
                requestCustomer_customer_AccountIsNull = false;
            }
            Amazon.PartnerCentralSelling.Industry requestCustomer_customer_Account_account_Industry = null;
            if (cmdletContext.Account_Industry != null)
            {
                requestCustomer_customer_Account_account_Industry = cmdletContext.Account_Industry;
            }
            if (requestCustomer_customer_Account_account_Industry != null)
            {
                requestCustomer_customer_Account.Industry = requestCustomer_customer_Account_account_Industry;
                requestCustomer_customer_AccountIsNull = false;
            }
            System.String requestCustomer_customer_Account_account_OtherIndustry = null;
            if (cmdletContext.Account_OtherIndustry != null)
            {
                requestCustomer_customer_Account_account_OtherIndustry = cmdletContext.Account_OtherIndustry;
            }
            if (requestCustomer_customer_Account_account_OtherIndustry != null)
            {
                requestCustomer_customer_Account.OtherIndustry = requestCustomer_customer_Account_account_OtherIndustry;
                requestCustomer_customer_AccountIsNull = false;
            }
            System.String requestCustomer_customer_Account_account_WebsiteUrl = null;
            if (cmdletContext.Account_WebsiteUrl != null)
            {
                requestCustomer_customer_Account_account_WebsiteUrl = cmdletContext.Account_WebsiteUrl;
            }
            if (requestCustomer_customer_Account_account_WebsiteUrl != null)
            {
                requestCustomer_customer_Account.WebsiteUrl = requestCustomer_customer_Account_account_WebsiteUrl;
                requestCustomer_customer_AccountIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.Address requestCustomer_customer_Account_customer_Account_Address = null;
            
             // populate Address
            var requestCustomer_customer_Account_customer_Account_AddressIsNull = true;
            requestCustomer_customer_Account_customer_Account_Address = new Amazon.PartnerCentralSelling.Model.Address();
            System.String requestCustomer_customer_Account_customer_Account_Address_address_City = null;
            if (cmdletContext.Address_City != null)
            {
                requestCustomer_customer_Account_customer_Account_Address_address_City = cmdletContext.Address_City;
            }
            if (requestCustomer_customer_Account_customer_Account_Address_address_City != null)
            {
                requestCustomer_customer_Account_customer_Account_Address.City = requestCustomer_customer_Account_customer_Account_Address_address_City;
                requestCustomer_customer_Account_customer_Account_AddressIsNull = false;
            }
            Amazon.PartnerCentralSelling.CountryCode requestCustomer_customer_Account_customer_Account_Address_address_CountryCode = null;
            if (cmdletContext.Address_CountryCode != null)
            {
                requestCustomer_customer_Account_customer_Account_Address_address_CountryCode = cmdletContext.Address_CountryCode;
            }
            if (requestCustomer_customer_Account_customer_Account_Address_address_CountryCode != null)
            {
                requestCustomer_customer_Account_customer_Account_Address.CountryCode = requestCustomer_customer_Account_customer_Account_Address_address_CountryCode;
                requestCustomer_customer_Account_customer_Account_AddressIsNull = false;
            }
            System.String requestCustomer_customer_Account_customer_Account_Address_address_PostalCode = null;
            if (cmdletContext.Address_PostalCode != null)
            {
                requestCustomer_customer_Account_customer_Account_Address_address_PostalCode = cmdletContext.Address_PostalCode;
            }
            if (requestCustomer_customer_Account_customer_Account_Address_address_PostalCode != null)
            {
                requestCustomer_customer_Account_customer_Account_Address.PostalCode = requestCustomer_customer_Account_customer_Account_Address_address_PostalCode;
                requestCustomer_customer_Account_customer_Account_AddressIsNull = false;
            }
            System.String requestCustomer_customer_Account_customer_Account_Address_address_StateOrRegion = null;
            if (cmdletContext.Address_StateOrRegion != null)
            {
                requestCustomer_customer_Account_customer_Account_Address_address_StateOrRegion = cmdletContext.Address_StateOrRegion;
            }
            if (requestCustomer_customer_Account_customer_Account_Address_address_StateOrRegion != null)
            {
                requestCustomer_customer_Account_customer_Account_Address.StateOrRegion = requestCustomer_customer_Account_customer_Account_Address_address_StateOrRegion;
                requestCustomer_customer_Account_customer_Account_AddressIsNull = false;
            }
            System.String requestCustomer_customer_Account_customer_Account_Address_address_StreetAddress = null;
            if (cmdletContext.Address_StreetAddress != null)
            {
                requestCustomer_customer_Account_customer_Account_Address_address_StreetAddress = cmdletContext.Address_StreetAddress;
            }
            if (requestCustomer_customer_Account_customer_Account_Address_address_StreetAddress != null)
            {
                requestCustomer_customer_Account_customer_Account_Address.StreetAddress = requestCustomer_customer_Account_customer_Account_Address_address_StreetAddress;
                requestCustomer_customer_Account_customer_Account_AddressIsNull = false;
            }
             // determine if requestCustomer_customer_Account_customer_Account_Address should be set to null
            if (requestCustomer_customer_Account_customer_Account_AddressIsNull)
            {
                requestCustomer_customer_Account_customer_Account_Address = null;
            }
            if (requestCustomer_customer_Account_customer_Account_Address != null)
            {
                requestCustomer_customer_Account.Address = requestCustomer_customer_Account_customer_Account_Address;
                requestCustomer_customer_AccountIsNull = false;
            }
             // determine if requestCustomer_customer_Account should be set to null
            if (requestCustomer_customer_AccountIsNull)
            {
                requestCustomer_customer_Account = null;
            }
            if (requestCustomer_customer_Account != null)
            {
                request.Customer.Account = requestCustomer_customer_Account;
                requestCustomerIsNull = false;
            }
             // determine if request.Customer should be set to null
            if (requestCustomerIsNull)
            {
                request.Customer = null;
            }
            
             // populate LifeCycle
            var requestLifeCycleIsNull = true;
            request.LifeCycle = new Amazon.PartnerCentralSelling.Model.LifeCycle();
            Amazon.PartnerCentralSelling.ClosedLostReason requestLifeCycle_lifeCycle_ClosedLostReason = null;
            if (cmdletContext.LifeCycle_ClosedLostReason != null)
            {
                requestLifeCycle_lifeCycle_ClosedLostReason = cmdletContext.LifeCycle_ClosedLostReason;
            }
            if (requestLifeCycle_lifeCycle_ClosedLostReason != null)
            {
                request.LifeCycle.ClosedLostReason = requestLifeCycle_lifeCycle_ClosedLostReason;
                requestLifeCycleIsNull = false;
            }
            System.String requestLifeCycle_lifeCycle_NextStep = null;
            if (cmdletContext.LifeCycle_NextStep != null)
            {
                requestLifeCycle_lifeCycle_NextStep = cmdletContext.LifeCycle_NextStep;
            }
            if (requestLifeCycle_lifeCycle_NextStep != null)
            {
                request.LifeCycle.NextSteps = requestLifeCycle_lifeCycle_NextStep;
                requestLifeCycleIsNull = false;
            }
            List<Amazon.PartnerCentralSelling.Model.NextStepsHistory> requestLifeCycle_lifeCycle_NextStepsHistory = null;
            if (cmdletContext.LifeCycle_NextStepsHistory != null)
            {
                requestLifeCycle_lifeCycle_NextStepsHistory = cmdletContext.LifeCycle_NextStepsHistory;
            }
            if (requestLifeCycle_lifeCycle_NextStepsHistory != null)
            {
                request.LifeCycle.NextStepsHistory = requestLifeCycle_lifeCycle_NextStepsHistory;
                requestLifeCycleIsNull = false;
            }
            System.String requestLifeCycle_lifeCycle_ReviewComment = null;
            if (cmdletContext.LifeCycle_ReviewComment != null)
            {
                requestLifeCycle_lifeCycle_ReviewComment = cmdletContext.LifeCycle_ReviewComment;
            }
            if (requestLifeCycle_lifeCycle_ReviewComment != null)
            {
                request.LifeCycle.ReviewComments = requestLifeCycle_lifeCycle_ReviewComment;
                requestLifeCycleIsNull = false;
            }
            Amazon.PartnerCentralSelling.ReviewStatus requestLifeCycle_lifeCycle_ReviewStatus = null;
            if (cmdletContext.LifeCycle_ReviewStatus != null)
            {
                requestLifeCycle_lifeCycle_ReviewStatus = cmdletContext.LifeCycle_ReviewStatus;
            }
            if (requestLifeCycle_lifeCycle_ReviewStatus != null)
            {
                request.LifeCycle.ReviewStatus = requestLifeCycle_lifeCycle_ReviewStatus;
                requestLifeCycleIsNull = false;
            }
            System.String requestLifeCycle_lifeCycle_ReviewStatusReason = null;
            if (cmdletContext.LifeCycle_ReviewStatusReason != null)
            {
                requestLifeCycle_lifeCycle_ReviewStatusReason = cmdletContext.LifeCycle_ReviewStatusReason;
            }
            if (requestLifeCycle_lifeCycle_ReviewStatusReason != null)
            {
                request.LifeCycle.ReviewStatusReason = requestLifeCycle_lifeCycle_ReviewStatusReason;
                requestLifeCycleIsNull = false;
            }
            Amazon.PartnerCentralSelling.Stage requestLifeCycle_lifeCycle_Stage = null;
            if (cmdletContext.LifeCycle_Stage != null)
            {
                requestLifeCycle_lifeCycle_Stage = cmdletContext.LifeCycle_Stage;
            }
            if (requestLifeCycle_lifeCycle_Stage != null)
            {
                request.LifeCycle.Stage = requestLifeCycle_lifeCycle_Stage;
                requestLifeCycleIsNull = false;
            }
            System.String requestLifeCycle_lifeCycle_TargetCloseDate = null;
            if (cmdletContext.LifeCycle_TargetCloseDate != null)
            {
                requestLifeCycle_lifeCycle_TargetCloseDate = cmdletContext.LifeCycle_TargetCloseDate;
            }
            if (requestLifeCycle_lifeCycle_TargetCloseDate != null)
            {
                request.LifeCycle.TargetCloseDate = requestLifeCycle_lifeCycle_TargetCloseDate;
                requestLifeCycleIsNull = false;
            }
             // determine if request.LifeCycle should be set to null
            if (requestLifeCycleIsNull)
            {
                request.LifeCycle = null;
            }
            
             // populate Marketing
            var requestMarketingIsNull = true;
            request.Marketing = new Amazon.PartnerCentralSelling.Model.Marketing();
            Amazon.PartnerCentralSelling.AwsFundingUsed requestMarketing_marketing_AwsFundingUsed = null;
            if (cmdletContext.Marketing_AwsFundingUsed != null)
            {
                requestMarketing_marketing_AwsFundingUsed = cmdletContext.Marketing_AwsFundingUsed;
            }
            if (requestMarketing_marketing_AwsFundingUsed != null)
            {
                request.Marketing.AwsFundingUsed = requestMarketing_marketing_AwsFundingUsed;
                requestMarketingIsNull = false;
            }
            System.String requestMarketing_marketing_CampaignName = null;
            if (cmdletContext.Marketing_CampaignName != null)
            {
                requestMarketing_marketing_CampaignName = cmdletContext.Marketing_CampaignName;
            }
            if (requestMarketing_marketing_CampaignName != null)
            {
                request.Marketing.CampaignName = requestMarketing_marketing_CampaignName;
                requestMarketingIsNull = false;
            }
            List<System.String> requestMarketing_marketing_Channel = null;
            if (cmdletContext.Marketing_Channel != null)
            {
                requestMarketing_marketing_Channel = cmdletContext.Marketing_Channel;
            }
            if (requestMarketing_marketing_Channel != null)
            {
                request.Marketing.Channels = requestMarketing_marketing_Channel;
                requestMarketingIsNull = false;
            }
            Amazon.PartnerCentralSelling.MarketingSource requestMarketing_marketing_Source = null;
            if (cmdletContext.Marketing_Source != null)
            {
                requestMarketing_marketing_Source = cmdletContext.Marketing_Source;
            }
            if (requestMarketing_marketing_Source != null)
            {
                request.Marketing.Source = requestMarketing_marketing_Source;
                requestMarketingIsNull = false;
            }
            List<System.String> requestMarketing_marketing_UseCase = null;
            if (cmdletContext.Marketing_UseCase != null)
            {
                requestMarketing_marketing_UseCase = cmdletContext.Marketing_UseCase;
            }
            if (requestMarketing_marketing_UseCase != null)
            {
                request.Marketing.UseCases = requestMarketing_marketing_UseCase;
                requestMarketingIsNull = false;
            }
             // determine if request.Marketing should be set to null
            if (requestMarketingIsNull)
            {
                request.Marketing = null;
            }
            if (cmdletContext.NationalSecurity != null)
            {
                request.NationalSecurity = cmdletContext.NationalSecurity;
            }
            if (cmdletContext.OpportunityTeam != null)
            {
                request.OpportunityTeam = cmdletContext.OpportunityTeam;
            }
            if (cmdletContext.OpportunityType != null)
            {
                request.OpportunityType = cmdletContext.OpportunityType;
            }
            if (cmdletContext.Origin != null)
            {
                request.Origin = cmdletContext.Origin;
            }
            if (cmdletContext.PartnerOpportunityIdentifier != null)
            {
                request.PartnerOpportunityIdentifier = cmdletContext.PartnerOpportunityIdentifier;
            }
            if (cmdletContext.PrimaryNeedsFromAw != null)
            {
                request.PrimaryNeedsFromAws = cmdletContext.PrimaryNeedsFromAw;
            }
            
             // populate Project
            var requestProjectIsNull = true;
            request.Project = new Amazon.PartnerCentralSelling.Model.Project();
            System.String requestProject_project_AdditionalComment = null;
            if (cmdletContext.Project_AdditionalComment != null)
            {
                requestProject_project_AdditionalComment = cmdletContext.Project_AdditionalComment;
            }
            if (requestProject_project_AdditionalComment != null)
            {
                request.Project.AdditionalComments = requestProject_project_AdditionalComment;
                requestProjectIsNull = false;
            }
            List<System.String> requestProject_project_ApnProgram = null;
            if (cmdletContext.Project_ApnProgram != null)
            {
                requestProject_project_ApnProgram = cmdletContext.Project_ApnProgram;
            }
            if (requestProject_project_ApnProgram != null)
            {
                request.Project.ApnPrograms = requestProject_project_ApnProgram;
                requestProjectIsNull = false;
            }
            Amazon.PartnerCentralSelling.AwsPartition requestProject_project_AwsPartition = null;
            if (cmdletContext.Project_AwsPartition != null)
            {
                requestProject_project_AwsPartition = cmdletContext.Project_AwsPartition;
            }
            if (requestProject_project_AwsPartition != null)
            {
                request.Project.AwsPartition = requestProject_project_AwsPartition;
                requestProjectIsNull = false;
            }
            Amazon.PartnerCentralSelling.CompetitorName requestProject_project_CompetitorName = null;
            if (cmdletContext.Project_CompetitorName != null)
            {
                requestProject_project_CompetitorName = cmdletContext.Project_CompetitorName;
            }
            if (requestProject_project_CompetitorName != null)
            {
                request.Project.CompetitorName = requestProject_project_CompetitorName;
                requestProjectIsNull = false;
            }
            System.String requestProject_project_CustomerBusinessProblem = null;
            if (cmdletContext.Project_CustomerBusinessProblem != null)
            {
                requestProject_project_CustomerBusinessProblem = cmdletContext.Project_CustomerBusinessProblem;
            }
            if (requestProject_project_CustomerBusinessProblem != null)
            {
                request.Project.CustomerBusinessProblem = requestProject_project_CustomerBusinessProblem;
                requestProjectIsNull = false;
            }
            System.String requestProject_project_CustomerUseCase = null;
            if (cmdletContext.Project_CustomerUseCase != null)
            {
                requestProject_project_CustomerUseCase = cmdletContext.Project_CustomerUseCase;
            }
            if (requestProject_project_CustomerUseCase != null)
            {
                request.Project.CustomerUseCase = requestProject_project_CustomerUseCase;
                requestProjectIsNull = false;
            }
            List<System.String> requestProject_project_DeliveryModel = null;
            if (cmdletContext.Project_DeliveryModel != null)
            {
                requestProject_project_DeliveryModel = cmdletContext.Project_DeliveryModel;
            }
            if (requestProject_project_DeliveryModel != null)
            {
                request.Project.DeliveryModels = requestProject_project_DeliveryModel;
                requestProjectIsNull = false;
            }
            List<Amazon.PartnerCentralSelling.Model.ExpectedCustomerSpend> requestProject_project_ExpectedCustomerSpend = null;
            if (cmdletContext.Project_ExpectedCustomerSpend != null)
            {
                requestProject_project_ExpectedCustomerSpend = cmdletContext.Project_ExpectedCustomerSpend;
            }
            if (requestProject_project_ExpectedCustomerSpend != null)
            {
                request.Project.ExpectedCustomerSpend = requestProject_project_ExpectedCustomerSpend;
                requestProjectIsNull = false;
            }
            System.String requestProject_project_OtherCompetitorName = null;
            if (cmdletContext.Project_OtherCompetitorName != null)
            {
                requestProject_project_OtherCompetitorName = cmdletContext.Project_OtherCompetitorName;
            }
            if (requestProject_project_OtherCompetitorName != null)
            {
                request.Project.OtherCompetitorNames = requestProject_project_OtherCompetitorName;
                requestProjectIsNull = false;
            }
            System.String requestProject_project_OtherSolutionDescription = null;
            if (cmdletContext.Project_OtherSolutionDescription != null)
            {
                requestProject_project_OtherSolutionDescription = cmdletContext.Project_OtherSolutionDescription;
            }
            if (requestProject_project_OtherSolutionDescription != null)
            {
                request.Project.OtherSolutionDescription = requestProject_project_OtherSolutionDescription;
                requestProjectIsNull = false;
            }
            System.String requestProject_project_RelatedOpportunityIdentifier = null;
            if (cmdletContext.Project_RelatedOpportunityIdentifier != null)
            {
                requestProject_project_RelatedOpportunityIdentifier = cmdletContext.Project_RelatedOpportunityIdentifier;
            }
            if (requestProject_project_RelatedOpportunityIdentifier != null)
            {
                request.Project.RelatedOpportunityIdentifier = requestProject_project_RelatedOpportunityIdentifier;
                requestProjectIsNull = false;
            }
            List<System.String> requestProject_project_SalesActivity = null;
            if (cmdletContext.Project_SalesActivity != null)
            {
                requestProject_project_SalesActivity = cmdletContext.Project_SalesActivity;
            }
            if (requestProject_project_SalesActivity != null)
            {
                request.Project.SalesActivities = requestProject_project_SalesActivity;
                requestProjectIsNull = false;
            }
            System.String requestProject_project_Title = null;
            if (cmdletContext.Project_Title != null)
            {
                requestProject_project_Title = cmdletContext.Project_Title;
            }
            if (requestProject_project_Title != null)
            {
                request.Project.Title = requestProject_project_Title;
                requestProjectIsNull = false;
            }
             // determine if request.Project should be set to null
            if (requestProjectIsNull)
            {
                request.Project = null;
            }
            
             // populate SoftwareRevenue
            var requestSoftwareRevenueIsNull = true;
            request.SoftwareRevenue = new Amazon.PartnerCentralSelling.Model.SoftwareRevenue();
            Amazon.PartnerCentralSelling.RevenueModel requestSoftwareRevenue_softwareRevenue_DeliveryModel = null;
            if (cmdletContext.SoftwareRevenue_DeliveryModel != null)
            {
                requestSoftwareRevenue_softwareRevenue_DeliveryModel = cmdletContext.SoftwareRevenue_DeliveryModel;
            }
            if (requestSoftwareRevenue_softwareRevenue_DeliveryModel != null)
            {
                request.SoftwareRevenue.DeliveryModel = requestSoftwareRevenue_softwareRevenue_DeliveryModel;
                requestSoftwareRevenueIsNull = false;
            }
            System.String requestSoftwareRevenue_softwareRevenue_EffectiveDate = null;
            if (cmdletContext.SoftwareRevenue_EffectiveDate != null)
            {
                requestSoftwareRevenue_softwareRevenue_EffectiveDate = cmdletContext.SoftwareRevenue_EffectiveDate;
            }
            if (requestSoftwareRevenue_softwareRevenue_EffectiveDate != null)
            {
                request.SoftwareRevenue.EffectiveDate = requestSoftwareRevenue_softwareRevenue_EffectiveDate;
                requestSoftwareRevenueIsNull = false;
            }
            System.String requestSoftwareRevenue_softwareRevenue_ExpirationDate = null;
            if (cmdletContext.SoftwareRevenue_ExpirationDate != null)
            {
                requestSoftwareRevenue_softwareRevenue_ExpirationDate = cmdletContext.SoftwareRevenue_ExpirationDate;
            }
            if (requestSoftwareRevenue_softwareRevenue_ExpirationDate != null)
            {
                request.SoftwareRevenue.ExpirationDate = requestSoftwareRevenue_softwareRevenue_ExpirationDate;
                requestSoftwareRevenueIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.MonetaryValue requestSoftwareRevenue_softwareRevenue_Value = null;
            
             // populate Value
            var requestSoftwareRevenue_softwareRevenue_ValueIsNull = true;
            requestSoftwareRevenue_softwareRevenue_Value = new Amazon.PartnerCentralSelling.Model.MonetaryValue();
            System.String requestSoftwareRevenue_softwareRevenue_Value_value_Amount = null;
            if (cmdletContext.Value_Amount != null)
            {
                requestSoftwareRevenue_softwareRevenue_Value_value_Amount = cmdletContext.Value_Amount;
            }
            if (requestSoftwareRevenue_softwareRevenue_Value_value_Amount != null)
            {
                requestSoftwareRevenue_softwareRevenue_Value.Amount = requestSoftwareRevenue_softwareRevenue_Value_value_Amount;
                requestSoftwareRevenue_softwareRevenue_ValueIsNull = false;
            }
            Amazon.PartnerCentralSelling.CurrencyCode requestSoftwareRevenue_softwareRevenue_Value_value_CurrencyCode = null;
            if (cmdletContext.Value_CurrencyCode != null)
            {
                requestSoftwareRevenue_softwareRevenue_Value_value_CurrencyCode = cmdletContext.Value_CurrencyCode;
            }
            if (requestSoftwareRevenue_softwareRevenue_Value_value_CurrencyCode != null)
            {
                requestSoftwareRevenue_softwareRevenue_Value.CurrencyCode = requestSoftwareRevenue_softwareRevenue_Value_value_CurrencyCode;
                requestSoftwareRevenue_softwareRevenue_ValueIsNull = false;
            }
             // determine if requestSoftwareRevenue_softwareRevenue_Value should be set to null
            if (requestSoftwareRevenue_softwareRevenue_ValueIsNull)
            {
                requestSoftwareRevenue_softwareRevenue_Value = null;
            }
            if (requestSoftwareRevenue_softwareRevenue_Value != null)
            {
                request.SoftwareRevenue.Value = requestSoftwareRevenue_softwareRevenue_Value;
                requestSoftwareRevenueIsNull = false;
            }
             // determine if request.SoftwareRevenue should be set to null
            if (requestSoftwareRevenueIsNull)
            {
                request.SoftwareRevenue = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.PartnerCentralSelling.Model.CreateOpportunityResponse CallAWSServiceOperation(IAmazonPartnerCentralSelling client, Amazon.PartnerCentralSelling.Model.CreateOpportunityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Selling API", "CreateOpportunity");
            try
            {
                return client.CreateOpportunityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Address_City { get; set; }
            public Amazon.PartnerCentralSelling.CountryCode Address_CountryCode { get; set; }
            public System.String Address_PostalCode { get; set; }
            public System.String Address_StateOrRegion { get; set; }
            public System.String Address_StreetAddress { get; set; }
            public System.String Account_AwsAccountId { get; set; }
            public System.String Account_CompanyName { get; set; }
            public System.String Account_Dun { get; set; }
            public Amazon.PartnerCentralSelling.Industry Account_Industry { get; set; }
            public System.String Account_OtherIndustry { get; set; }
            public System.String Account_WebsiteUrl { get; set; }
            public List<Amazon.PartnerCentralSelling.Model.Contact> Customer_Contact { get; set; }
            public Amazon.PartnerCentralSelling.ClosedLostReason LifeCycle_ClosedLostReason { get; set; }
            public System.String LifeCycle_NextStep { get; set; }
            public List<Amazon.PartnerCentralSelling.Model.NextStepsHistory> LifeCycle_NextStepsHistory { get; set; }
            public System.String LifeCycle_ReviewComment { get; set; }
            public Amazon.PartnerCentralSelling.ReviewStatus LifeCycle_ReviewStatus { get; set; }
            public System.String LifeCycle_ReviewStatusReason { get; set; }
            public Amazon.PartnerCentralSelling.Stage LifeCycle_Stage { get; set; }
            public System.String LifeCycle_TargetCloseDate { get; set; }
            public Amazon.PartnerCentralSelling.AwsFundingUsed Marketing_AwsFundingUsed { get; set; }
            public System.String Marketing_CampaignName { get; set; }
            public List<System.String> Marketing_Channel { get; set; }
            public Amazon.PartnerCentralSelling.MarketingSource Marketing_Source { get; set; }
            public List<System.String> Marketing_UseCase { get; set; }
            public Amazon.PartnerCentralSelling.NationalSecurity NationalSecurity { get; set; }
            public List<Amazon.PartnerCentralSelling.Model.Contact> OpportunityTeam { get; set; }
            public Amazon.PartnerCentralSelling.OpportunityType OpportunityType { get; set; }
            public Amazon.PartnerCentralSelling.OpportunityOrigin Origin { get; set; }
            public System.String PartnerOpportunityIdentifier { get; set; }
            public List<System.String> PrimaryNeedsFromAw { get; set; }
            public System.String Project_AdditionalComment { get; set; }
            public List<System.String> Project_ApnProgram { get; set; }
            public Amazon.PartnerCentralSelling.AwsPartition Project_AwsPartition { get; set; }
            public Amazon.PartnerCentralSelling.CompetitorName Project_CompetitorName { get; set; }
            public System.String Project_CustomerBusinessProblem { get; set; }
            public System.String Project_CustomerUseCase { get; set; }
            public List<System.String> Project_DeliveryModel { get; set; }
            public List<Amazon.PartnerCentralSelling.Model.ExpectedCustomerSpend> Project_ExpectedCustomerSpend { get; set; }
            public System.String Project_OtherCompetitorName { get; set; }
            public System.String Project_OtherSolutionDescription { get; set; }
            public System.String Project_RelatedOpportunityIdentifier { get; set; }
            public List<System.String> Project_SalesActivity { get; set; }
            public System.String Project_Title { get; set; }
            public Amazon.PartnerCentralSelling.RevenueModel SoftwareRevenue_DeliveryModel { get; set; }
            public System.String SoftwareRevenue_EffectiveDate { get; set; }
            public System.String SoftwareRevenue_ExpirationDate { get; set; }
            public System.String Value_Amount { get; set; }
            public Amazon.PartnerCentralSelling.CurrencyCode Value_CurrencyCode { get; set; }
            public List<Amazon.PartnerCentralSelling.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.PartnerCentralSelling.Model.CreateOpportunityResponse, InvokePCCreateOpportunityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Id;
        }
        
    }
}
