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
using Amazon.Route53Domains;
using Amazon.Route53Domains.Model;

namespace Amazon.PowerShell.Cmdlets.R53D
{
    /// <summary>
    /// This operation registers a domain. For some top-level domains (TLDs), this operation
    /// requires extra parameters.
    /// 
    ///  
    /// <para>
    /// When you register a domain, Amazon Route 53 does the following:
    /// </para><ul><li><para>
    /// Creates a Route 53 hosted zone that has the same name as the domain. Route 53 assigns
    /// four name servers to your hosted zone and automatically updates your domain registration
    /// with the names of these name servers.
    /// </para></li><li><para>
    /// Enables auto renew, so your domain registration will renew automatically each year.
    /// We'll notify you in advance of the renewal date so you can choose whether to renew
    /// the registration.
    /// </para></li><li><para>
    /// Optionally enables privacy protection, so WHOIS queries return contact for the registrar
    /// or the phrase "REDACTED FOR PRIVACY", or "On behalf of &lt;domain name&gt; owner."
    /// If you don't enable privacy protection, WHOIS queries return the information that
    /// you entered for the administrative, registrant, and technical contacts.
    /// </para><note><para>
    /// While some domains may allow different privacy settings per contact, we recommend
    /// specifying the same privacy setting for all contacts.
    /// </para></note></li><li><para>
    /// If registration is successful, returns an operation ID that you can use to track the
    /// progress and completion of the action. If the request is not completed successfully,
    /// the domain registrant is notified by email.
    /// </para></li><li><para>
    /// Charges your Amazon Web Services account an amount based on the top-level domain.
    /// For more information, see <a href="http://aws.amazon.com/route53/pricing/">Amazon
    /// Route 53 Pricing</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Register", "R53DDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Route 53 Domains RegisterDomain API operation.", Operation = new[] {"RegisterDomain"}, SelectReturnType = typeof(Amazon.Route53Domains.Model.RegisterDomainResponse))]
    [AWSCmdletOutput("System.String or Amazon.Route53Domains.Model.RegisterDomainResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Route53Domains.Model.RegisterDomainResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterR53DDomainCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdminContact_AddressLine1
        /// <summary>
        /// <para>
        /// <para>First line of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminContact_AddressLine1 { get; set; }
        #endregion
        
        #region Parameter BillingContact_AddressLine1
        /// <summary>
        /// <para>
        /// <para>First line of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingContact_AddressLine1 { get; set; }
        #endregion
        
        #region Parameter RegistrantContact_AddressLine1
        /// <summary>
        /// <para>
        /// <para>First line of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrantContact_AddressLine1 { get; set; }
        #endregion
        
        #region Parameter TechContact_AddressLine1
        /// <summary>
        /// <para>
        /// <para>First line of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TechContact_AddressLine1 { get; set; }
        #endregion
        
        #region Parameter AdminContact_AddressLine2
        /// <summary>
        /// <para>
        /// <para>Second line of contact's address, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminContact_AddressLine2 { get; set; }
        #endregion
        
        #region Parameter BillingContact_AddressLine2
        /// <summary>
        /// <para>
        /// <para>Second line of contact's address, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingContact_AddressLine2 { get; set; }
        #endregion
        
        #region Parameter RegistrantContact_AddressLine2
        /// <summary>
        /// <para>
        /// <para>Second line of contact's address, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrantContact_AddressLine2 { get; set; }
        #endregion
        
        #region Parameter TechContact_AddressLine2
        /// <summary>
        /// <para>
        /// <para>Second line of contact's address, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TechContact_AddressLine2 { get; set; }
        #endregion
        
        #region Parameter AutoRenew
        /// <summary>
        /// <para>
        /// <para>Indicates whether the domain will be automatically renewed (<c>true</c>) or not (<c>false</c>).
        /// Auto renewal only takes effect after the account is charged.</para><para>Default: <c>true</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoRenew { get; set; }
        #endregion
        
        #region Parameter AdminContact_City
        /// <summary>
        /// <para>
        /// <para>The city of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminContact_City { get; set; }
        #endregion
        
        #region Parameter BillingContact_City
        /// <summary>
        /// <para>
        /// <para>The city of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingContact_City { get; set; }
        #endregion
        
        #region Parameter RegistrantContact_City
        /// <summary>
        /// <para>
        /// <para>The city of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrantContact_City { get; set; }
        #endregion
        
        #region Parameter TechContact_City
        /// <summary>
        /// <para>
        /// <para>The city of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TechContact_City { get; set; }
        #endregion
        
        #region Parameter AdminContact_ContactType
        /// <summary>
        /// <para>
        /// <para>Indicates whether the contact is a person, company, association, or public organization.
        /// Note the following:</para><ul><li><para>If you specify a value other than <c>PERSON</c>, you must also specify a value for
        /// <c>OrganizationName</c>.</para></li><li><para>For some TLDs, the privacy protection available depends on the value that you specify
        /// for <c>Contact Type</c>. For the privacy protection settings for your TLD, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html">Domains
        /// that You Can Register with Amazon Route 53</a> in the <i>Amazon Route 53 Developer
        /// Guide</i></para></li><li><para>For .es domains, the value of <c>ContactType</c> must be <c>PERSON</c> for all three
        /// contacts.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Domains.ContactType")]
        public Amazon.Route53Domains.ContactType AdminContact_ContactType { get; set; }
        #endregion
        
        #region Parameter BillingContact_ContactType
        /// <summary>
        /// <para>
        /// <para>Indicates whether the contact is a person, company, association, or public organization.
        /// Note the following:</para><ul><li><para>If you specify a value other than <c>PERSON</c>, you must also specify a value for
        /// <c>OrganizationName</c>.</para></li><li><para>For some TLDs, the privacy protection available depends on the value that you specify
        /// for <c>Contact Type</c>. For the privacy protection settings for your TLD, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html">Domains
        /// that You Can Register with Amazon Route 53</a> in the <i>Amazon Route 53 Developer
        /// Guide</i></para></li><li><para>For .es domains, the value of <c>ContactType</c> must be <c>PERSON</c> for all three
        /// contacts.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Domains.ContactType")]
        public Amazon.Route53Domains.ContactType BillingContact_ContactType { get; set; }
        #endregion
        
        #region Parameter RegistrantContact_ContactType
        /// <summary>
        /// <para>
        /// <para>Indicates whether the contact is a person, company, association, or public organization.
        /// Note the following:</para><ul><li><para>If you specify a value other than <c>PERSON</c>, you must also specify a value for
        /// <c>OrganizationName</c>.</para></li><li><para>For some TLDs, the privacy protection available depends on the value that you specify
        /// for <c>Contact Type</c>. For the privacy protection settings for your TLD, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html">Domains
        /// that You Can Register with Amazon Route 53</a> in the <i>Amazon Route 53 Developer
        /// Guide</i></para></li><li><para>For .es domains, the value of <c>ContactType</c> must be <c>PERSON</c> for all three
        /// contacts.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Domains.ContactType")]
        public Amazon.Route53Domains.ContactType RegistrantContact_ContactType { get; set; }
        #endregion
        
        #region Parameter TechContact_ContactType
        /// <summary>
        /// <para>
        /// <para>Indicates whether the contact is a person, company, association, or public organization.
        /// Note the following:</para><ul><li><para>If you specify a value other than <c>PERSON</c>, you must also specify a value for
        /// <c>OrganizationName</c>.</para></li><li><para>For some TLDs, the privacy protection available depends on the value that you specify
        /// for <c>Contact Type</c>. For the privacy protection settings for your TLD, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html">Domains
        /// that You Can Register with Amazon Route 53</a> in the <i>Amazon Route 53 Developer
        /// Guide</i></para></li><li><para>For .es domains, the value of <c>ContactType</c> must be <c>PERSON</c> for all three
        /// contacts.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Domains.ContactType")]
        public Amazon.Route53Domains.ContactType TechContact_ContactType { get; set; }
        #endregion
        
        #region Parameter AdminContact_CountryCode
        /// <summary>
        /// <para>
        /// <para>Code for the country of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Domains.CountryCode")]
        public Amazon.Route53Domains.CountryCode AdminContact_CountryCode { get; set; }
        #endregion
        
        #region Parameter BillingContact_CountryCode
        /// <summary>
        /// <para>
        /// <para>Code for the country of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Domains.CountryCode")]
        public Amazon.Route53Domains.CountryCode BillingContact_CountryCode { get; set; }
        #endregion
        
        #region Parameter RegistrantContact_CountryCode
        /// <summary>
        /// <para>
        /// <para>Code for the country of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Domains.CountryCode")]
        public Amazon.Route53Domains.CountryCode RegistrantContact_CountryCode { get; set; }
        #endregion
        
        #region Parameter TechContact_CountryCode
        /// <summary>
        /// <para>
        /// <para>Code for the country of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Domains.CountryCode")]
        public Amazon.Route53Domains.CountryCode TechContact_CountryCode { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The domain name that you want to register. The top-level domain (TLD), such as .com,
        /// must be a TLD that Route 53 supports. For a list of supported TLDs, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html">Domains
        /// that You Can Register with Amazon Route 53</a> in the <i>Amazon Route 53 Developer
        /// Guide</i>.</para><para>The domain name can contain only the following characters:</para><ul><li><para>Letters a through z. Domain names are not case sensitive.</para></li><li><para>Numbers 0 through 9.</para></li><li><para>Hyphen (-). You can't specify a hyphen at the beginning or end of a label. </para></li><li><para>Period (.) to separate the labels in the name, such as the <c>.</c> in <c>example.com</c>.</para></li></ul><para>Internationalized domain names are not supported for some top-level domains. To determine
        /// whether the TLD that you want to use supports internationalized domain names, see
        /// <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html">Domains
        /// that You Can Register with Amazon Route 53</a>. For more information, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/DomainNameFormat.html#domain-name-format-idns">Formatting
        /// Internationalized Domain Names</a>. </para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter DurationInYears
        /// <summary>
        /// <para>
        /// <para>The number of years that you want to register the domain for. Domains are registered
        /// for a minimum of one year. The maximum period depends on the top-level domain. For
        /// the range of valid values for your domain, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html">Domains
        /// that You Can Register with Amazon Route 53</a> in the <i>Amazon Route 53 Developer
        /// Guide</i>.</para><para>Default: 1</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? DurationInYears { get; set; }
        #endregion
        
        #region Parameter AdminContact_Email
        /// <summary>
        /// <para>
        /// <para>Email address of the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminContact_Email { get; set; }
        #endregion
        
        #region Parameter BillingContact_Email
        /// <summary>
        /// <para>
        /// <para>Email address of the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingContact_Email { get; set; }
        #endregion
        
        #region Parameter RegistrantContact_Email
        /// <summary>
        /// <para>
        /// <para>Email address of the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrantContact_Email { get; set; }
        #endregion
        
        #region Parameter TechContact_Email
        /// <summary>
        /// <para>
        /// <para>Email address of the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TechContact_Email { get; set; }
        #endregion
        
        #region Parameter AdminContact_ExtraParam
        /// <summary>
        /// <para>
        /// <para>A list of name-value pairs for parameters required by certain top-level domains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminContact_ExtraParams")]
        public Amazon.Route53Domains.Model.ExtraParam[] AdminContact_ExtraParam { get; set; }
        #endregion
        
        #region Parameter BillingContact_ExtraParam
        /// <summary>
        /// <para>
        /// <para>A list of name-value pairs for parameters required by certain top-level domains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BillingContact_ExtraParams")]
        public Amazon.Route53Domains.Model.ExtraParam[] BillingContact_ExtraParam { get; set; }
        #endregion
        
        #region Parameter RegistrantContact_ExtraParam
        /// <summary>
        /// <para>
        /// <para>A list of name-value pairs for parameters required by certain top-level domains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RegistrantContact_ExtraParams")]
        public Amazon.Route53Domains.Model.ExtraParam[] RegistrantContact_ExtraParam { get; set; }
        #endregion
        
        #region Parameter TechContact_ExtraParam
        /// <summary>
        /// <para>
        /// <para>A list of name-value pairs for parameters required by certain top-level domains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TechContact_ExtraParams")]
        public Amazon.Route53Domains.Model.ExtraParam[] TechContact_ExtraParam { get; set; }
        #endregion
        
        #region Parameter AdminContact_Fax
        /// <summary>
        /// <para>
        /// <para>Fax number of the contact.</para><para>Constraints: Phone number must be specified in the format "+[country dialing code].[number
        /// including any area code]". For example, a US phone number might appear as <c>"+1.1234567890"</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminContact_Fax { get; set; }
        #endregion
        
        #region Parameter BillingContact_Fax
        /// <summary>
        /// <para>
        /// <para>Fax number of the contact.</para><para>Constraints: Phone number must be specified in the format "+[country dialing code].[number
        /// including any area code]". For example, a US phone number might appear as <c>"+1.1234567890"</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingContact_Fax { get; set; }
        #endregion
        
        #region Parameter RegistrantContact_Fax
        /// <summary>
        /// <para>
        /// <para>Fax number of the contact.</para><para>Constraints: Phone number must be specified in the format "+[country dialing code].[number
        /// including any area code]". For example, a US phone number might appear as <c>"+1.1234567890"</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrantContact_Fax { get; set; }
        #endregion
        
        #region Parameter TechContact_Fax
        /// <summary>
        /// <para>
        /// <para>Fax number of the contact.</para><para>Constraints: Phone number must be specified in the format "+[country dialing code].[number
        /// including any area code]". For example, a US phone number might appear as <c>"+1.1234567890"</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TechContact_Fax { get; set; }
        #endregion
        
        #region Parameter AdminContact_FirstName
        /// <summary>
        /// <para>
        /// <para>First name of contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminContact_FirstName { get; set; }
        #endregion
        
        #region Parameter BillingContact_FirstName
        /// <summary>
        /// <para>
        /// <para>First name of contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingContact_FirstName { get; set; }
        #endregion
        
        #region Parameter RegistrantContact_FirstName
        /// <summary>
        /// <para>
        /// <para>First name of contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrantContact_FirstName { get; set; }
        #endregion
        
        #region Parameter TechContact_FirstName
        /// <summary>
        /// <para>
        /// <para>First name of contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TechContact_FirstName { get; set; }
        #endregion
        
        #region Parameter IdnLangCode
        /// <summary>
        /// <para>
        /// <para>Reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdnLangCode { get; set; }
        #endregion
        
        #region Parameter AdminContact_LastName
        /// <summary>
        /// <para>
        /// <para>Last name of contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminContact_LastName { get; set; }
        #endregion
        
        #region Parameter BillingContact_LastName
        /// <summary>
        /// <para>
        /// <para>Last name of contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingContact_LastName { get; set; }
        #endregion
        
        #region Parameter RegistrantContact_LastName
        /// <summary>
        /// <para>
        /// <para>Last name of contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrantContact_LastName { get; set; }
        #endregion
        
        #region Parameter TechContact_LastName
        /// <summary>
        /// <para>
        /// <para>Last name of contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TechContact_LastName { get; set; }
        #endregion
        
        #region Parameter AdminContact_OrganizationName
        /// <summary>
        /// <para>
        /// <para>Name of the organization for contact types other than <c>PERSON</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminContact_OrganizationName { get; set; }
        #endregion
        
        #region Parameter BillingContact_OrganizationName
        /// <summary>
        /// <para>
        /// <para>Name of the organization for contact types other than <c>PERSON</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingContact_OrganizationName { get; set; }
        #endregion
        
        #region Parameter RegistrantContact_OrganizationName
        /// <summary>
        /// <para>
        /// <para>Name of the organization for contact types other than <c>PERSON</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrantContact_OrganizationName { get; set; }
        #endregion
        
        #region Parameter TechContact_OrganizationName
        /// <summary>
        /// <para>
        /// <para>Name of the organization for contact types other than <c>PERSON</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TechContact_OrganizationName { get; set; }
        #endregion
        
        #region Parameter AdminContact_PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number of the contact.</para><para>Constraints: Phone number must be specified in the format "+[country dialing code].[number
        /// including any area code&gt;]". For example, a US phone number might appear as <c>"+1.1234567890"</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminContact_PhoneNumber { get; set; }
        #endregion
        
        #region Parameter BillingContact_PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number of the contact.</para><para>Constraints: Phone number must be specified in the format "+[country dialing code].[number
        /// including any area code&gt;]". For example, a US phone number might appear as <c>"+1.1234567890"</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingContact_PhoneNumber { get; set; }
        #endregion
        
        #region Parameter RegistrantContact_PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number of the contact.</para><para>Constraints: Phone number must be specified in the format "+[country dialing code].[number
        /// including any area code&gt;]". For example, a US phone number might appear as <c>"+1.1234567890"</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrantContact_PhoneNumber { get; set; }
        #endregion
        
        #region Parameter TechContact_PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number of the contact.</para><para>Constraints: Phone number must be specified in the format "+[country dialing code].[number
        /// including any area code&gt;]". For example, a US phone number might appear as <c>"+1.1234567890"</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TechContact_PhoneNumber { get; set; }
        #endregion
        
        #region Parameter PrivacyProtectAdminContact
        /// <summary>
        /// <para>
        /// <para>Whether you want to conceal contact information from WHOIS queries. If you specify
        /// <c>true</c>, WHOIS ("who is") queries return contact information either for Amazon
        /// Registrar or for our registrar associate, Gandi. If you specify <c>false</c>, WHOIS
        /// queries return the information that you entered for the admin contact.</para><note><para>You must specify the same privacy setting for the administrative, billing, registrant,
        /// and technical contacts.</para></note><para>Default: <c>true</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PrivacyProtectAdminContact { get; set; }
        #endregion
        
        #region Parameter PrivacyProtectBillingContact
        /// <summary>
        /// <para>
        /// <para>Whether you want to conceal contact information from WHOIS queries. If you specify
        /// <c>true</c>, WHOIS ("who is") queries return contact information either for Amazon
        /// Registrar or for our registrar associate, Gandi. If you specify <c>false</c>, WHOIS
        /// queries return the information that you entered for the billing contact.</para><note><para>You must specify the same privacy setting for the administrative, billing, registrant,
        /// and technical contacts.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PrivacyProtectBillingContact { get; set; }
        #endregion
        
        #region Parameter PrivacyProtectRegistrantContact
        /// <summary>
        /// <para>
        /// <para>Whether you want to conceal contact information from WHOIS queries. If you specify
        /// <c>true</c>, WHOIS ("who is") queries return contact information either for Amazon
        /// Registrar or for our registrar associate, Gandi. If you specify <c>false</c>, WHOIS
        /// queries return the information that you entered for the registrant contact (the domain
        /// owner).</para><note><para>You must specify the same privacy setting for the administrative, billing, registrant,
        /// and technical contacts.</para></note><para>Default: <c>true</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PrivacyProtectRegistrantContact { get; set; }
        #endregion
        
        #region Parameter PrivacyProtectTechContact
        /// <summary>
        /// <para>
        /// <para>Whether you want to conceal contact information from WHOIS queries. If you specify
        /// <c>true</c>, WHOIS ("who is") queries return contact information either for Amazon
        /// Registrar or for our registrar associate, Gandi. If you specify <c>false</c>, WHOIS
        /// queries return the information that you entered for the technical contact.</para><note><para>You must specify the same privacy setting for the administrative, billing, registrant,
        /// and technical contacts.</para></note><para>Default: <c>true</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PrivacyProtectTechContact { get; set; }
        #endregion
        
        #region Parameter AdminContact_State
        /// <summary>
        /// <para>
        /// <para>The state or province of the contact's city.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminContact_State { get; set; }
        #endregion
        
        #region Parameter BillingContact_State
        /// <summary>
        /// <para>
        /// <para>The state or province of the contact's city.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingContact_State { get; set; }
        #endregion
        
        #region Parameter RegistrantContact_State
        /// <summary>
        /// <para>
        /// <para>The state or province of the contact's city.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrantContact_State { get; set; }
        #endregion
        
        #region Parameter TechContact_State
        /// <summary>
        /// <para>
        /// <para>The state or province of the contact's city.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TechContact_State { get; set; }
        #endregion
        
        #region Parameter AdminContact_ZipCode
        /// <summary>
        /// <para>
        /// <para>The zip or postal code of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminContact_ZipCode { get; set; }
        #endregion
        
        #region Parameter BillingContact_ZipCode
        /// <summary>
        /// <para>
        /// <para>The zip or postal code of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingContact_ZipCode { get; set; }
        #endregion
        
        #region Parameter RegistrantContact_ZipCode
        /// <summary>
        /// <para>
        /// <para>The zip or postal code of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrantContact_ZipCode { get; set; }
        #endregion
        
        #region Parameter TechContact_ZipCode
        /// <summary>
        /// <para>
        /// <para>The zip or postal code of the contact's address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TechContact_ZipCode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Domains.Model.RegisterDomainResponse).
        /// Specifying the name of a property of type Amazon.Route53Domains.Model.RegisterDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-R53DDomain (RegisterDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Domains.Model.RegisterDomainResponse, RegisterR53DDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdminContact_AddressLine1 = this.AdminContact_AddressLine1;
            context.AdminContact_AddressLine2 = this.AdminContact_AddressLine2;
            context.AdminContact_City = this.AdminContact_City;
            context.AdminContact_ContactType = this.AdminContact_ContactType;
            context.AdminContact_CountryCode = this.AdminContact_CountryCode;
            context.AdminContact_Email = this.AdminContact_Email;
            if (this.AdminContact_ExtraParam != null)
            {
                context.AdminContact_ExtraParam = new List<Amazon.Route53Domains.Model.ExtraParam>(this.AdminContact_ExtraParam);
            }
            context.AdminContact_Fax = this.AdminContact_Fax;
            context.AdminContact_FirstName = this.AdminContact_FirstName;
            context.AdminContact_LastName = this.AdminContact_LastName;
            context.AdminContact_OrganizationName = this.AdminContact_OrganizationName;
            context.AdminContact_PhoneNumber = this.AdminContact_PhoneNumber;
            context.AdminContact_State = this.AdminContact_State;
            context.AdminContact_ZipCode = this.AdminContact_ZipCode;
            context.AutoRenew = this.AutoRenew;
            context.BillingContact_AddressLine1 = this.BillingContact_AddressLine1;
            context.BillingContact_AddressLine2 = this.BillingContact_AddressLine2;
            context.BillingContact_City = this.BillingContact_City;
            context.BillingContact_ContactType = this.BillingContact_ContactType;
            context.BillingContact_CountryCode = this.BillingContact_CountryCode;
            context.BillingContact_Email = this.BillingContact_Email;
            if (this.BillingContact_ExtraParam != null)
            {
                context.BillingContact_ExtraParam = new List<Amazon.Route53Domains.Model.ExtraParam>(this.BillingContact_ExtraParam);
            }
            context.BillingContact_Fax = this.BillingContact_Fax;
            context.BillingContact_FirstName = this.BillingContact_FirstName;
            context.BillingContact_LastName = this.BillingContact_LastName;
            context.BillingContact_OrganizationName = this.BillingContact_OrganizationName;
            context.BillingContact_PhoneNumber = this.BillingContact_PhoneNumber;
            context.BillingContact_State = this.BillingContact_State;
            context.BillingContact_ZipCode = this.BillingContact_ZipCode;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DurationInYears = this.DurationInYears;
            #if MODULAR
            if (this.DurationInYears == null && ParameterWasBound(nameof(this.DurationInYears)))
            {
                WriteWarning("You are passing $null as a value for parameter DurationInYears which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdnLangCode = this.IdnLangCode;
            context.PrivacyProtectAdminContact = this.PrivacyProtectAdminContact;
            context.PrivacyProtectBillingContact = this.PrivacyProtectBillingContact;
            context.PrivacyProtectRegistrantContact = this.PrivacyProtectRegistrantContact;
            context.PrivacyProtectTechContact = this.PrivacyProtectTechContact;
            context.RegistrantContact_AddressLine1 = this.RegistrantContact_AddressLine1;
            context.RegistrantContact_AddressLine2 = this.RegistrantContact_AddressLine2;
            context.RegistrantContact_City = this.RegistrantContact_City;
            context.RegistrantContact_ContactType = this.RegistrantContact_ContactType;
            context.RegistrantContact_CountryCode = this.RegistrantContact_CountryCode;
            context.RegistrantContact_Email = this.RegistrantContact_Email;
            if (this.RegistrantContact_ExtraParam != null)
            {
                context.RegistrantContact_ExtraParam = new List<Amazon.Route53Domains.Model.ExtraParam>(this.RegistrantContact_ExtraParam);
            }
            context.RegistrantContact_Fax = this.RegistrantContact_Fax;
            context.RegistrantContact_FirstName = this.RegistrantContact_FirstName;
            context.RegistrantContact_LastName = this.RegistrantContact_LastName;
            context.RegistrantContact_OrganizationName = this.RegistrantContact_OrganizationName;
            context.RegistrantContact_PhoneNumber = this.RegistrantContact_PhoneNumber;
            context.RegistrantContact_State = this.RegistrantContact_State;
            context.RegistrantContact_ZipCode = this.RegistrantContact_ZipCode;
            context.TechContact_AddressLine1 = this.TechContact_AddressLine1;
            context.TechContact_AddressLine2 = this.TechContact_AddressLine2;
            context.TechContact_City = this.TechContact_City;
            context.TechContact_ContactType = this.TechContact_ContactType;
            context.TechContact_CountryCode = this.TechContact_CountryCode;
            context.TechContact_Email = this.TechContact_Email;
            if (this.TechContact_ExtraParam != null)
            {
                context.TechContact_ExtraParam = new List<Amazon.Route53Domains.Model.ExtraParam>(this.TechContact_ExtraParam);
            }
            context.TechContact_Fax = this.TechContact_Fax;
            context.TechContact_FirstName = this.TechContact_FirstName;
            context.TechContact_LastName = this.TechContact_LastName;
            context.TechContact_OrganizationName = this.TechContact_OrganizationName;
            context.TechContact_PhoneNumber = this.TechContact_PhoneNumber;
            context.TechContact_State = this.TechContact_State;
            context.TechContact_ZipCode = this.TechContact_ZipCode;
            
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
            var request = new Amazon.Route53Domains.Model.RegisterDomainRequest();
            
            
             // populate AdminContact
            var requestAdminContactIsNull = true;
            request.AdminContact = new Amazon.Route53Domains.Model.ContactDetail();
            System.String requestAdminContact_adminContact_AddressLine1 = null;
            if (cmdletContext.AdminContact_AddressLine1 != null)
            {
                requestAdminContact_adminContact_AddressLine1 = cmdletContext.AdminContact_AddressLine1;
            }
            if (requestAdminContact_adminContact_AddressLine1 != null)
            {
                request.AdminContact.AddressLine1 = requestAdminContact_adminContact_AddressLine1;
                requestAdminContactIsNull = false;
            }
            System.String requestAdminContact_adminContact_AddressLine2 = null;
            if (cmdletContext.AdminContact_AddressLine2 != null)
            {
                requestAdminContact_adminContact_AddressLine2 = cmdletContext.AdminContact_AddressLine2;
            }
            if (requestAdminContact_adminContact_AddressLine2 != null)
            {
                request.AdminContact.AddressLine2 = requestAdminContact_adminContact_AddressLine2;
                requestAdminContactIsNull = false;
            }
            System.String requestAdminContact_adminContact_City = null;
            if (cmdletContext.AdminContact_City != null)
            {
                requestAdminContact_adminContact_City = cmdletContext.AdminContact_City;
            }
            if (requestAdminContact_adminContact_City != null)
            {
                request.AdminContact.City = requestAdminContact_adminContact_City;
                requestAdminContactIsNull = false;
            }
            Amazon.Route53Domains.ContactType requestAdminContact_adminContact_ContactType = null;
            if (cmdletContext.AdminContact_ContactType != null)
            {
                requestAdminContact_adminContact_ContactType = cmdletContext.AdminContact_ContactType;
            }
            if (requestAdminContact_adminContact_ContactType != null)
            {
                request.AdminContact.ContactType = requestAdminContact_adminContact_ContactType;
                requestAdminContactIsNull = false;
            }
            Amazon.Route53Domains.CountryCode requestAdminContact_adminContact_CountryCode = null;
            if (cmdletContext.AdminContact_CountryCode != null)
            {
                requestAdminContact_adminContact_CountryCode = cmdletContext.AdminContact_CountryCode;
            }
            if (requestAdminContact_adminContact_CountryCode != null)
            {
                request.AdminContact.CountryCode = requestAdminContact_adminContact_CountryCode;
                requestAdminContactIsNull = false;
            }
            System.String requestAdminContact_adminContact_Email = null;
            if (cmdletContext.AdminContact_Email != null)
            {
                requestAdminContact_adminContact_Email = cmdletContext.AdminContact_Email;
            }
            if (requestAdminContact_adminContact_Email != null)
            {
                request.AdminContact.Email = requestAdminContact_adminContact_Email;
                requestAdminContactIsNull = false;
            }
            List<Amazon.Route53Domains.Model.ExtraParam> requestAdminContact_adminContact_ExtraParam = null;
            if (cmdletContext.AdminContact_ExtraParam != null)
            {
                requestAdminContact_adminContact_ExtraParam = cmdletContext.AdminContact_ExtraParam;
            }
            if (requestAdminContact_adminContact_ExtraParam != null)
            {
                request.AdminContact.ExtraParams = requestAdminContact_adminContact_ExtraParam;
                requestAdminContactIsNull = false;
            }
            System.String requestAdminContact_adminContact_Fax = null;
            if (cmdletContext.AdminContact_Fax != null)
            {
                requestAdminContact_adminContact_Fax = cmdletContext.AdminContact_Fax;
            }
            if (requestAdminContact_adminContact_Fax != null)
            {
                request.AdminContact.Fax = requestAdminContact_adminContact_Fax;
                requestAdminContactIsNull = false;
            }
            System.String requestAdminContact_adminContact_FirstName = null;
            if (cmdletContext.AdminContact_FirstName != null)
            {
                requestAdminContact_adminContact_FirstName = cmdletContext.AdminContact_FirstName;
            }
            if (requestAdminContact_adminContact_FirstName != null)
            {
                request.AdminContact.FirstName = requestAdminContact_adminContact_FirstName;
                requestAdminContactIsNull = false;
            }
            System.String requestAdminContact_adminContact_LastName = null;
            if (cmdletContext.AdminContact_LastName != null)
            {
                requestAdminContact_adminContact_LastName = cmdletContext.AdminContact_LastName;
            }
            if (requestAdminContact_adminContact_LastName != null)
            {
                request.AdminContact.LastName = requestAdminContact_adminContact_LastName;
                requestAdminContactIsNull = false;
            }
            System.String requestAdminContact_adminContact_OrganizationName = null;
            if (cmdletContext.AdminContact_OrganizationName != null)
            {
                requestAdminContact_adminContact_OrganizationName = cmdletContext.AdminContact_OrganizationName;
            }
            if (requestAdminContact_adminContact_OrganizationName != null)
            {
                request.AdminContact.OrganizationName = requestAdminContact_adminContact_OrganizationName;
                requestAdminContactIsNull = false;
            }
            System.String requestAdminContact_adminContact_PhoneNumber = null;
            if (cmdletContext.AdminContact_PhoneNumber != null)
            {
                requestAdminContact_adminContact_PhoneNumber = cmdletContext.AdminContact_PhoneNumber;
            }
            if (requestAdminContact_adminContact_PhoneNumber != null)
            {
                request.AdminContact.PhoneNumber = requestAdminContact_adminContact_PhoneNumber;
                requestAdminContactIsNull = false;
            }
            System.String requestAdminContact_adminContact_State = null;
            if (cmdletContext.AdminContact_State != null)
            {
                requestAdminContact_adminContact_State = cmdletContext.AdminContact_State;
            }
            if (requestAdminContact_adminContact_State != null)
            {
                request.AdminContact.State = requestAdminContact_adminContact_State;
                requestAdminContactIsNull = false;
            }
            System.String requestAdminContact_adminContact_ZipCode = null;
            if (cmdletContext.AdminContact_ZipCode != null)
            {
                requestAdminContact_adminContact_ZipCode = cmdletContext.AdminContact_ZipCode;
            }
            if (requestAdminContact_adminContact_ZipCode != null)
            {
                request.AdminContact.ZipCode = requestAdminContact_adminContact_ZipCode;
                requestAdminContactIsNull = false;
            }
             // determine if request.AdminContact should be set to null
            if (requestAdminContactIsNull)
            {
                request.AdminContact = null;
            }
            if (cmdletContext.AutoRenew != null)
            {
                request.AutoRenew = cmdletContext.AutoRenew.Value;
            }
            
             // populate BillingContact
            var requestBillingContactIsNull = true;
            request.BillingContact = new Amazon.Route53Domains.Model.ContactDetail();
            System.String requestBillingContact_billingContact_AddressLine1 = null;
            if (cmdletContext.BillingContact_AddressLine1 != null)
            {
                requestBillingContact_billingContact_AddressLine1 = cmdletContext.BillingContact_AddressLine1;
            }
            if (requestBillingContact_billingContact_AddressLine1 != null)
            {
                request.BillingContact.AddressLine1 = requestBillingContact_billingContact_AddressLine1;
                requestBillingContactIsNull = false;
            }
            System.String requestBillingContact_billingContact_AddressLine2 = null;
            if (cmdletContext.BillingContact_AddressLine2 != null)
            {
                requestBillingContact_billingContact_AddressLine2 = cmdletContext.BillingContact_AddressLine2;
            }
            if (requestBillingContact_billingContact_AddressLine2 != null)
            {
                request.BillingContact.AddressLine2 = requestBillingContact_billingContact_AddressLine2;
                requestBillingContactIsNull = false;
            }
            System.String requestBillingContact_billingContact_City = null;
            if (cmdletContext.BillingContact_City != null)
            {
                requestBillingContact_billingContact_City = cmdletContext.BillingContact_City;
            }
            if (requestBillingContact_billingContact_City != null)
            {
                request.BillingContact.City = requestBillingContact_billingContact_City;
                requestBillingContactIsNull = false;
            }
            Amazon.Route53Domains.ContactType requestBillingContact_billingContact_ContactType = null;
            if (cmdletContext.BillingContact_ContactType != null)
            {
                requestBillingContact_billingContact_ContactType = cmdletContext.BillingContact_ContactType;
            }
            if (requestBillingContact_billingContact_ContactType != null)
            {
                request.BillingContact.ContactType = requestBillingContact_billingContact_ContactType;
                requestBillingContactIsNull = false;
            }
            Amazon.Route53Domains.CountryCode requestBillingContact_billingContact_CountryCode = null;
            if (cmdletContext.BillingContact_CountryCode != null)
            {
                requestBillingContact_billingContact_CountryCode = cmdletContext.BillingContact_CountryCode;
            }
            if (requestBillingContact_billingContact_CountryCode != null)
            {
                request.BillingContact.CountryCode = requestBillingContact_billingContact_CountryCode;
                requestBillingContactIsNull = false;
            }
            System.String requestBillingContact_billingContact_Email = null;
            if (cmdletContext.BillingContact_Email != null)
            {
                requestBillingContact_billingContact_Email = cmdletContext.BillingContact_Email;
            }
            if (requestBillingContact_billingContact_Email != null)
            {
                request.BillingContact.Email = requestBillingContact_billingContact_Email;
                requestBillingContactIsNull = false;
            }
            List<Amazon.Route53Domains.Model.ExtraParam> requestBillingContact_billingContact_ExtraParam = null;
            if (cmdletContext.BillingContact_ExtraParam != null)
            {
                requestBillingContact_billingContact_ExtraParam = cmdletContext.BillingContact_ExtraParam;
            }
            if (requestBillingContact_billingContact_ExtraParam != null)
            {
                request.BillingContact.ExtraParams = requestBillingContact_billingContact_ExtraParam;
                requestBillingContactIsNull = false;
            }
            System.String requestBillingContact_billingContact_Fax = null;
            if (cmdletContext.BillingContact_Fax != null)
            {
                requestBillingContact_billingContact_Fax = cmdletContext.BillingContact_Fax;
            }
            if (requestBillingContact_billingContact_Fax != null)
            {
                request.BillingContact.Fax = requestBillingContact_billingContact_Fax;
                requestBillingContactIsNull = false;
            }
            System.String requestBillingContact_billingContact_FirstName = null;
            if (cmdletContext.BillingContact_FirstName != null)
            {
                requestBillingContact_billingContact_FirstName = cmdletContext.BillingContact_FirstName;
            }
            if (requestBillingContact_billingContact_FirstName != null)
            {
                request.BillingContact.FirstName = requestBillingContact_billingContact_FirstName;
                requestBillingContactIsNull = false;
            }
            System.String requestBillingContact_billingContact_LastName = null;
            if (cmdletContext.BillingContact_LastName != null)
            {
                requestBillingContact_billingContact_LastName = cmdletContext.BillingContact_LastName;
            }
            if (requestBillingContact_billingContact_LastName != null)
            {
                request.BillingContact.LastName = requestBillingContact_billingContact_LastName;
                requestBillingContactIsNull = false;
            }
            System.String requestBillingContact_billingContact_OrganizationName = null;
            if (cmdletContext.BillingContact_OrganizationName != null)
            {
                requestBillingContact_billingContact_OrganizationName = cmdletContext.BillingContact_OrganizationName;
            }
            if (requestBillingContact_billingContact_OrganizationName != null)
            {
                request.BillingContact.OrganizationName = requestBillingContact_billingContact_OrganizationName;
                requestBillingContactIsNull = false;
            }
            System.String requestBillingContact_billingContact_PhoneNumber = null;
            if (cmdletContext.BillingContact_PhoneNumber != null)
            {
                requestBillingContact_billingContact_PhoneNumber = cmdletContext.BillingContact_PhoneNumber;
            }
            if (requestBillingContact_billingContact_PhoneNumber != null)
            {
                request.BillingContact.PhoneNumber = requestBillingContact_billingContact_PhoneNumber;
                requestBillingContactIsNull = false;
            }
            System.String requestBillingContact_billingContact_State = null;
            if (cmdletContext.BillingContact_State != null)
            {
                requestBillingContact_billingContact_State = cmdletContext.BillingContact_State;
            }
            if (requestBillingContact_billingContact_State != null)
            {
                request.BillingContact.State = requestBillingContact_billingContact_State;
                requestBillingContactIsNull = false;
            }
            System.String requestBillingContact_billingContact_ZipCode = null;
            if (cmdletContext.BillingContact_ZipCode != null)
            {
                requestBillingContact_billingContact_ZipCode = cmdletContext.BillingContact_ZipCode;
            }
            if (requestBillingContact_billingContact_ZipCode != null)
            {
                request.BillingContact.ZipCode = requestBillingContact_billingContact_ZipCode;
                requestBillingContactIsNull = false;
            }
             // determine if request.BillingContact should be set to null
            if (requestBillingContactIsNull)
            {
                request.BillingContact = null;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.DurationInYears != null)
            {
                request.DurationInYears = cmdletContext.DurationInYears.Value;
            }
            if (cmdletContext.IdnLangCode != null)
            {
                request.IdnLangCode = cmdletContext.IdnLangCode;
            }
            if (cmdletContext.PrivacyProtectAdminContact != null)
            {
                request.PrivacyProtectAdminContact = cmdletContext.PrivacyProtectAdminContact.Value;
            }
            if (cmdletContext.PrivacyProtectBillingContact != null)
            {
                request.PrivacyProtectBillingContact = cmdletContext.PrivacyProtectBillingContact.Value;
            }
            if (cmdletContext.PrivacyProtectRegistrantContact != null)
            {
                request.PrivacyProtectRegistrantContact = cmdletContext.PrivacyProtectRegistrantContact.Value;
            }
            if (cmdletContext.PrivacyProtectTechContact != null)
            {
                request.PrivacyProtectTechContact = cmdletContext.PrivacyProtectTechContact.Value;
            }
            
             // populate RegistrantContact
            var requestRegistrantContactIsNull = true;
            request.RegistrantContact = new Amazon.Route53Domains.Model.ContactDetail();
            System.String requestRegistrantContact_registrantContact_AddressLine1 = null;
            if (cmdletContext.RegistrantContact_AddressLine1 != null)
            {
                requestRegistrantContact_registrantContact_AddressLine1 = cmdletContext.RegistrantContact_AddressLine1;
            }
            if (requestRegistrantContact_registrantContact_AddressLine1 != null)
            {
                request.RegistrantContact.AddressLine1 = requestRegistrantContact_registrantContact_AddressLine1;
                requestRegistrantContactIsNull = false;
            }
            System.String requestRegistrantContact_registrantContact_AddressLine2 = null;
            if (cmdletContext.RegistrantContact_AddressLine2 != null)
            {
                requestRegistrantContact_registrantContact_AddressLine2 = cmdletContext.RegistrantContact_AddressLine2;
            }
            if (requestRegistrantContact_registrantContact_AddressLine2 != null)
            {
                request.RegistrantContact.AddressLine2 = requestRegistrantContact_registrantContact_AddressLine2;
                requestRegistrantContactIsNull = false;
            }
            System.String requestRegistrantContact_registrantContact_City = null;
            if (cmdletContext.RegistrantContact_City != null)
            {
                requestRegistrantContact_registrantContact_City = cmdletContext.RegistrantContact_City;
            }
            if (requestRegistrantContact_registrantContact_City != null)
            {
                request.RegistrantContact.City = requestRegistrantContact_registrantContact_City;
                requestRegistrantContactIsNull = false;
            }
            Amazon.Route53Domains.ContactType requestRegistrantContact_registrantContact_ContactType = null;
            if (cmdletContext.RegistrantContact_ContactType != null)
            {
                requestRegistrantContact_registrantContact_ContactType = cmdletContext.RegistrantContact_ContactType;
            }
            if (requestRegistrantContact_registrantContact_ContactType != null)
            {
                request.RegistrantContact.ContactType = requestRegistrantContact_registrantContact_ContactType;
                requestRegistrantContactIsNull = false;
            }
            Amazon.Route53Domains.CountryCode requestRegistrantContact_registrantContact_CountryCode = null;
            if (cmdletContext.RegistrantContact_CountryCode != null)
            {
                requestRegistrantContact_registrantContact_CountryCode = cmdletContext.RegistrantContact_CountryCode;
            }
            if (requestRegistrantContact_registrantContact_CountryCode != null)
            {
                request.RegistrantContact.CountryCode = requestRegistrantContact_registrantContact_CountryCode;
                requestRegistrantContactIsNull = false;
            }
            System.String requestRegistrantContact_registrantContact_Email = null;
            if (cmdletContext.RegistrantContact_Email != null)
            {
                requestRegistrantContact_registrantContact_Email = cmdletContext.RegistrantContact_Email;
            }
            if (requestRegistrantContact_registrantContact_Email != null)
            {
                request.RegistrantContact.Email = requestRegistrantContact_registrantContact_Email;
                requestRegistrantContactIsNull = false;
            }
            List<Amazon.Route53Domains.Model.ExtraParam> requestRegistrantContact_registrantContact_ExtraParam = null;
            if (cmdletContext.RegistrantContact_ExtraParam != null)
            {
                requestRegistrantContact_registrantContact_ExtraParam = cmdletContext.RegistrantContact_ExtraParam;
            }
            if (requestRegistrantContact_registrantContact_ExtraParam != null)
            {
                request.RegistrantContact.ExtraParams = requestRegistrantContact_registrantContact_ExtraParam;
                requestRegistrantContactIsNull = false;
            }
            System.String requestRegistrantContact_registrantContact_Fax = null;
            if (cmdletContext.RegistrantContact_Fax != null)
            {
                requestRegistrantContact_registrantContact_Fax = cmdletContext.RegistrantContact_Fax;
            }
            if (requestRegistrantContact_registrantContact_Fax != null)
            {
                request.RegistrantContact.Fax = requestRegistrantContact_registrantContact_Fax;
                requestRegistrantContactIsNull = false;
            }
            System.String requestRegistrantContact_registrantContact_FirstName = null;
            if (cmdletContext.RegistrantContact_FirstName != null)
            {
                requestRegistrantContact_registrantContact_FirstName = cmdletContext.RegistrantContact_FirstName;
            }
            if (requestRegistrantContact_registrantContact_FirstName != null)
            {
                request.RegistrantContact.FirstName = requestRegistrantContact_registrantContact_FirstName;
                requestRegistrantContactIsNull = false;
            }
            System.String requestRegistrantContact_registrantContact_LastName = null;
            if (cmdletContext.RegistrantContact_LastName != null)
            {
                requestRegistrantContact_registrantContact_LastName = cmdletContext.RegistrantContact_LastName;
            }
            if (requestRegistrantContact_registrantContact_LastName != null)
            {
                request.RegistrantContact.LastName = requestRegistrantContact_registrantContact_LastName;
                requestRegistrantContactIsNull = false;
            }
            System.String requestRegistrantContact_registrantContact_OrganizationName = null;
            if (cmdletContext.RegistrantContact_OrganizationName != null)
            {
                requestRegistrantContact_registrantContact_OrganizationName = cmdletContext.RegistrantContact_OrganizationName;
            }
            if (requestRegistrantContact_registrantContact_OrganizationName != null)
            {
                request.RegistrantContact.OrganizationName = requestRegistrantContact_registrantContact_OrganizationName;
                requestRegistrantContactIsNull = false;
            }
            System.String requestRegistrantContact_registrantContact_PhoneNumber = null;
            if (cmdletContext.RegistrantContact_PhoneNumber != null)
            {
                requestRegistrantContact_registrantContact_PhoneNumber = cmdletContext.RegistrantContact_PhoneNumber;
            }
            if (requestRegistrantContact_registrantContact_PhoneNumber != null)
            {
                request.RegistrantContact.PhoneNumber = requestRegistrantContact_registrantContact_PhoneNumber;
                requestRegistrantContactIsNull = false;
            }
            System.String requestRegistrantContact_registrantContact_State = null;
            if (cmdletContext.RegistrantContact_State != null)
            {
                requestRegistrantContact_registrantContact_State = cmdletContext.RegistrantContact_State;
            }
            if (requestRegistrantContact_registrantContact_State != null)
            {
                request.RegistrantContact.State = requestRegistrantContact_registrantContact_State;
                requestRegistrantContactIsNull = false;
            }
            System.String requestRegistrantContact_registrantContact_ZipCode = null;
            if (cmdletContext.RegistrantContact_ZipCode != null)
            {
                requestRegistrantContact_registrantContact_ZipCode = cmdletContext.RegistrantContact_ZipCode;
            }
            if (requestRegistrantContact_registrantContact_ZipCode != null)
            {
                request.RegistrantContact.ZipCode = requestRegistrantContact_registrantContact_ZipCode;
                requestRegistrantContactIsNull = false;
            }
             // determine if request.RegistrantContact should be set to null
            if (requestRegistrantContactIsNull)
            {
                request.RegistrantContact = null;
            }
            
             // populate TechContact
            var requestTechContactIsNull = true;
            request.TechContact = new Amazon.Route53Domains.Model.ContactDetail();
            System.String requestTechContact_techContact_AddressLine1 = null;
            if (cmdletContext.TechContact_AddressLine1 != null)
            {
                requestTechContact_techContact_AddressLine1 = cmdletContext.TechContact_AddressLine1;
            }
            if (requestTechContact_techContact_AddressLine1 != null)
            {
                request.TechContact.AddressLine1 = requestTechContact_techContact_AddressLine1;
                requestTechContactIsNull = false;
            }
            System.String requestTechContact_techContact_AddressLine2 = null;
            if (cmdletContext.TechContact_AddressLine2 != null)
            {
                requestTechContact_techContact_AddressLine2 = cmdletContext.TechContact_AddressLine2;
            }
            if (requestTechContact_techContact_AddressLine2 != null)
            {
                request.TechContact.AddressLine2 = requestTechContact_techContact_AddressLine2;
                requestTechContactIsNull = false;
            }
            System.String requestTechContact_techContact_City = null;
            if (cmdletContext.TechContact_City != null)
            {
                requestTechContact_techContact_City = cmdletContext.TechContact_City;
            }
            if (requestTechContact_techContact_City != null)
            {
                request.TechContact.City = requestTechContact_techContact_City;
                requestTechContactIsNull = false;
            }
            Amazon.Route53Domains.ContactType requestTechContact_techContact_ContactType = null;
            if (cmdletContext.TechContact_ContactType != null)
            {
                requestTechContact_techContact_ContactType = cmdletContext.TechContact_ContactType;
            }
            if (requestTechContact_techContact_ContactType != null)
            {
                request.TechContact.ContactType = requestTechContact_techContact_ContactType;
                requestTechContactIsNull = false;
            }
            Amazon.Route53Domains.CountryCode requestTechContact_techContact_CountryCode = null;
            if (cmdletContext.TechContact_CountryCode != null)
            {
                requestTechContact_techContact_CountryCode = cmdletContext.TechContact_CountryCode;
            }
            if (requestTechContact_techContact_CountryCode != null)
            {
                request.TechContact.CountryCode = requestTechContact_techContact_CountryCode;
                requestTechContactIsNull = false;
            }
            System.String requestTechContact_techContact_Email = null;
            if (cmdletContext.TechContact_Email != null)
            {
                requestTechContact_techContact_Email = cmdletContext.TechContact_Email;
            }
            if (requestTechContact_techContact_Email != null)
            {
                request.TechContact.Email = requestTechContact_techContact_Email;
                requestTechContactIsNull = false;
            }
            List<Amazon.Route53Domains.Model.ExtraParam> requestTechContact_techContact_ExtraParam = null;
            if (cmdletContext.TechContact_ExtraParam != null)
            {
                requestTechContact_techContact_ExtraParam = cmdletContext.TechContact_ExtraParam;
            }
            if (requestTechContact_techContact_ExtraParam != null)
            {
                request.TechContact.ExtraParams = requestTechContact_techContact_ExtraParam;
                requestTechContactIsNull = false;
            }
            System.String requestTechContact_techContact_Fax = null;
            if (cmdletContext.TechContact_Fax != null)
            {
                requestTechContact_techContact_Fax = cmdletContext.TechContact_Fax;
            }
            if (requestTechContact_techContact_Fax != null)
            {
                request.TechContact.Fax = requestTechContact_techContact_Fax;
                requestTechContactIsNull = false;
            }
            System.String requestTechContact_techContact_FirstName = null;
            if (cmdletContext.TechContact_FirstName != null)
            {
                requestTechContact_techContact_FirstName = cmdletContext.TechContact_FirstName;
            }
            if (requestTechContact_techContact_FirstName != null)
            {
                request.TechContact.FirstName = requestTechContact_techContact_FirstName;
                requestTechContactIsNull = false;
            }
            System.String requestTechContact_techContact_LastName = null;
            if (cmdletContext.TechContact_LastName != null)
            {
                requestTechContact_techContact_LastName = cmdletContext.TechContact_LastName;
            }
            if (requestTechContact_techContact_LastName != null)
            {
                request.TechContact.LastName = requestTechContact_techContact_LastName;
                requestTechContactIsNull = false;
            }
            System.String requestTechContact_techContact_OrganizationName = null;
            if (cmdletContext.TechContact_OrganizationName != null)
            {
                requestTechContact_techContact_OrganizationName = cmdletContext.TechContact_OrganizationName;
            }
            if (requestTechContact_techContact_OrganizationName != null)
            {
                request.TechContact.OrganizationName = requestTechContact_techContact_OrganizationName;
                requestTechContactIsNull = false;
            }
            System.String requestTechContact_techContact_PhoneNumber = null;
            if (cmdletContext.TechContact_PhoneNumber != null)
            {
                requestTechContact_techContact_PhoneNumber = cmdletContext.TechContact_PhoneNumber;
            }
            if (requestTechContact_techContact_PhoneNumber != null)
            {
                request.TechContact.PhoneNumber = requestTechContact_techContact_PhoneNumber;
                requestTechContactIsNull = false;
            }
            System.String requestTechContact_techContact_State = null;
            if (cmdletContext.TechContact_State != null)
            {
                requestTechContact_techContact_State = cmdletContext.TechContact_State;
            }
            if (requestTechContact_techContact_State != null)
            {
                request.TechContact.State = requestTechContact_techContact_State;
                requestTechContactIsNull = false;
            }
            System.String requestTechContact_techContact_ZipCode = null;
            if (cmdletContext.TechContact_ZipCode != null)
            {
                requestTechContact_techContact_ZipCode = cmdletContext.TechContact_ZipCode;
            }
            if (requestTechContact_techContact_ZipCode != null)
            {
                request.TechContact.ZipCode = requestTechContact_techContact_ZipCode;
                requestTechContactIsNull = false;
            }
             // determine if request.TechContact should be set to null
            if (requestTechContactIsNull)
            {
                request.TechContact = null;
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
        
        private Amazon.Route53Domains.Model.RegisterDomainResponse CallAWSServiceOperation(IAmazonRoute53Domains client, Amazon.Route53Domains.Model.RegisterDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Domains", "RegisterDomain");
            try
            {
                #if DESKTOP
                return client.RegisterDomain(request);
                #elif CORECLR
                return client.RegisterDomainAsync(request).GetAwaiter().GetResult();
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
            public System.String AdminContact_AddressLine1 { get; set; }
            public System.String AdminContact_AddressLine2 { get; set; }
            public System.String AdminContact_City { get; set; }
            public Amazon.Route53Domains.ContactType AdminContact_ContactType { get; set; }
            public Amazon.Route53Domains.CountryCode AdminContact_CountryCode { get; set; }
            public System.String AdminContact_Email { get; set; }
            public List<Amazon.Route53Domains.Model.ExtraParam> AdminContact_ExtraParam { get; set; }
            public System.String AdminContact_Fax { get; set; }
            public System.String AdminContact_FirstName { get; set; }
            public System.String AdminContact_LastName { get; set; }
            public System.String AdminContact_OrganizationName { get; set; }
            public System.String AdminContact_PhoneNumber { get; set; }
            public System.String AdminContact_State { get; set; }
            public System.String AdminContact_ZipCode { get; set; }
            public System.Boolean? AutoRenew { get; set; }
            public System.String BillingContact_AddressLine1 { get; set; }
            public System.String BillingContact_AddressLine2 { get; set; }
            public System.String BillingContact_City { get; set; }
            public Amazon.Route53Domains.ContactType BillingContact_ContactType { get; set; }
            public Amazon.Route53Domains.CountryCode BillingContact_CountryCode { get; set; }
            public System.String BillingContact_Email { get; set; }
            public List<Amazon.Route53Domains.Model.ExtraParam> BillingContact_ExtraParam { get; set; }
            public System.String BillingContact_Fax { get; set; }
            public System.String BillingContact_FirstName { get; set; }
            public System.String BillingContact_LastName { get; set; }
            public System.String BillingContact_OrganizationName { get; set; }
            public System.String BillingContact_PhoneNumber { get; set; }
            public System.String BillingContact_State { get; set; }
            public System.String BillingContact_ZipCode { get; set; }
            public System.String DomainName { get; set; }
            public System.Int32? DurationInYears { get; set; }
            public System.String IdnLangCode { get; set; }
            public System.Boolean? PrivacyProtectAdminContact { get; set; }
            public System.Boolean? PrivacyProtectBillingContact { get; set; }
            public System.Boolean? PrivacyProtectRegistrantContact { get; set; }
            public System.Boolean? PrivacyProtectTechContact { get; set; }
            public System.String RegistrantContact_AddressLine1 { get; set; }
            public System.String RegistrantContact_AddressLine2 { get; set; }
            public System.String RegistrantContact_City { get; set; }
            public Amazon.Route53Domains.ContactType RegistrantContact_ContactType { get; set; }
            public Amazon.Route53Domains.CountryCode RegistrantContact_CountryCode { get; set; }
            public System.String RegistrantContact_Email { get; set; }
            public List<Amazon.Route53Domains.Model.ExtraParam> RegistrantContact_ExtraParam { get; set; }
            public System.String RegistrantContact_Fax { get; set; }
            public System.String RegistrantContact_FirstName { get; set; }
            public System.String RegistrantContact_LastName { get; set; }
            public System.String RegistrantContact_OrganizationName { get; set; }
            public System.String RegistrantContact_PhoneNumber { get; set; }
            public System.String RegistrantContact_State { get; set; }
            public System.String RegistrantContact_ZipCode { get; set; }
            public System.String TechContact_AddressLine1 { get; set; }
            public System.String TechContact_AddressLine2 { get; set; }
            public System.String TechContact_City { get; set; }
            public Amazon.Route53Domains.ContactType TechContact_ContactType { get; set; }
            public Amazon.Route53Domains.CountryCode TechContact_CountryCode { get; set; }
            public System.String TechContact_Email { get; set; }
            public List<Amazon.Route53Domains.Model.ExtraParam> TechContact_ExtraParam { get; set; }
            public System.String TechContact_Fax { get; set; }
            public System.String TechContact_FirstName { get; set; }
            public System.String TechContact_LastName { get; set; }
            public System.String TechContact_OrganizationName { get; set; }
            public System.String TechContact_PhoneNumber { get; set; }
            public System.String TechContact_State { get; set; }
            public System.String TechContact_ZipCode { get; set; }
            public System.Func<Amazon.Route53Domains.Model.RegisterDomainResponse, RegisterR53DDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationId;
        }
        
    }
}
