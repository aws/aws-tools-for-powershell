/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// This operation updates the contact information for a particular domain. Information
    /// for at least one contact (registrant, administrator, or technical) must be supplied
    /// for update.
    /// 
    ///  
    /// <para>
    /// If the update is successful, this method returns an operation ID that you can use
    /// to track the progress and completion of the action. If the request is not completed
    /// successfully, the domain registrant will be notified by email.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "R53DDomainContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateDomainContact operation against AWS Route 53 Domains.", Operation = new[] {"UpdateDomainContact"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Route53Domains.Model.UpdateDomainContactResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateR53DDomainContactCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>First line of the contact's address.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AdminContact_AddressLine1 { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>First line of the contact's address.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegistrantContact_AddressLine1 { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>First line of the contact's address.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TechContact_AddressLine1 { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Second line of contact's address, if any.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AdminContact_AddressLine2 { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Second line of contact's address, if any.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegistrantContact_AddressLine2 { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Second line of contact's address, if any.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TechContact_AddressLine2 { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The city of the contact's address.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AdminContact_City { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The city of the contact's address.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegistrantContact_City { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The city of the contact's address.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TechContact_City { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Indicates whether the contact is a person, company, association, or public organization.
        /// If you choose an option other than <code>PERSON</code>, you must enter an organization
        /// name, and you can't enable privacy protection for the contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Valid values: <code>PERSON</code> | <code>COMPANY</code> | <code>ASSOCIATION</code>
        /// | <code>PUBLIC_BODY</code></para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Route53Domains.ContactType AdminContact_ContactType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Indicates whether the contact is a person, company, association, or public organization.
        /// If you choose an option other than <code>PERSON</code>, you must enter an organization
        /// name, and you can't enable privacy protection for the contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Valid values: <code>PERSON</code> | <code>COMPANY</code> | <code>ASSOCIATION</code>
        /// | <code>PUBLIC_BODY</code></para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Route53Domains.ContactType RegistrantContact_ContactType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Indicates whether the contact is a person, company, association, or public organization.
        /// If you choose an option other than <code>PERSON</code>, you must enter an organization
        /// name, and you can't enable privacy protection for the contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Valid values: <code>PERSON</code> | <code>COMPANY</code> | <code>ASSOCIATION</code>
        /// | <code>PUBLIC_BODY</code></para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Route53Domains.ContactType TechContact_ContactType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Code for the country of the contact's address.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Route53Domains.CountryCode AdminContact_CountryCode { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Code for the country of the contact's address.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Route53Domains.CountryCode RegistrantContact_CountryCode { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Code for the country of the contact's address.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Route53Domains.CountryCode TechContact_CountryCode { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of a domain.</para><para>Type: String</para><para>Default: None</para><para>Constraints: The domain name can contain only the letters a through z, the numbers
        /// 0 through 9, and hyphen (-). Internationalized Domain Names are not supported.</para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Email address of the contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 254 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AdminContact_Email { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Email address of the contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 254 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegistrantContact_Email { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Email address of the contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 254 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TechContact_Email { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of name-value pairs for parameters required by certain top-level domains.</para><para>Type: Complex</para><para>Default: None</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Children: <code>Name</code>, <code>Value</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AdminContact_ExtraParams")]
        public Amazon.Route53Domains.Model.ExtraParam[] AdminContact_ExtraParam { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of name-value pairs for parameters required by certain top-level domains.</para><para>Type: Complex</para><para>Default: None</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Children: <code>Name</code>, <code>Value</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RegistrantContact_ExtraParams")]
        public Amazon.Route53Domains.Model.ExtraParam[] RegistrantContact_ExtraParam { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of name-value pairs for parameters required by certain top-level domains.</para><para>Type: Complex</para><para>Default: None</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Children: <code>Name</code>, <code>Value</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TechContact_ExtraParams")]
        public Amazon.Route53Domains.Model.ExtraParam[] TechContact_ExtraParam { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Fax number of the contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Phone number must be specified in the format "+[country dialing code].[number
        /// including any area code]". For example, a US phone number might appear as <code>"+1.1234567890"</code>.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AdminContact_Fax { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Fax number of the contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Phone number must be specified in the format "+[country dialing code].[number
        /// including any area code]". For example, a US phone number might appear as <code>"+1.1234567890"</code>.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegistrantContact_Fax { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Fax number of the contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Phone number must be specified in the format "+[country dialing code].[number
        /// including any area code]". For example, a US phone number might appear as <code>"+1.1234567890"</code>.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TechContact_Fax { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>First name of contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AdminContact_FirstName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>First name of contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegistrantContact_FirstName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>First name of contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TechContact_FirstName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Last name of contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AdminContact_LastName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Last name of contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegistrantContact_LastName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Last name of contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TechContact_LastName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Name of the organization for contact types other than <code>PERSON</code>.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters. Contact type must not be <code>PERSON</code>.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AdminContact_OrganizationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Name of the organization for contact types other than <code>PERSON</code>.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters. Contact type must not be <code>PERSON</code>.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegistrantContact_OrganizationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Name of the organization for contact types other than <code>PERSON</code>.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters. Contact type must not be <code>PERSON</code>.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TechContact_OrganizationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The phone number of the contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Phone number must be specified in the format "+[country dialing code].[number
        /// including any area code&gt;]". For example, a US phone number might appear as <code>"+1.1234567890"</code>.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AdminContact_PhoneNumber { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The phone number of the contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Phone number must be specified in the format "+[country dialing code].[number
        /// including any area code&gt;]". For example, a US phone number might appear as <code>"+1.1234567890"</code>.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegistrantContact_PhoneNumber { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The phone number of the contact.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Phone number must be specified in the format "+[country dialing code].[number
        /// including any area code&gt;]". For example, a US phone number might appear as <code>"+1.1234567890"</code>.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: Yes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TechContact_PhoneNumber { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The state or province of the contact's city.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AdminContact_State { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The state or province of the contact's city.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegistrantContact_State { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The state or province of the contact's city.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TechContact_State { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The zip or postal code of the contact's address.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AdminContact_ZipCode { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The zip or postal code of the contact's address.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegistrantContact_ZipCode { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The zip or postal code of the contact's address.</para><para>Type: String</para><para>Default: None</para><para>Constraints: Maximum 255 characters.</para><para>Parents: <code>RegistrantContact</code>, <code>AdminContact</code>, <code>TechContact</code></para><para>Required: No</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TechContact_ZipCode { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53DDomainContact (UpdateDomainContact)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AdminContact_AddressLine1 = this.AdminContact_AddressLine1;
            context.AdminContact_AddressLine2 = this.AdminContact_AddressLine2;
            context.AdminContact_City = this.AdminContact_City;
            context.AdminContact_ContactType = this.AdminContact_ContactType;
            context.AdminContact_CountryCode = this.AdminContact_CountryCode;
            context.AdminContact_Email = this.AdminContact_Email;
            if (this.AdminContact_ExtraParam != null)
            {
                context.AdminContact_ExtraParams = new List<Amazon.Route53Domains.Model.ExtraParam>(this.AdminContact_ExtraParam);
            }
            context.AdminContact_Fax = this.AdminContact_Fax;
            context.AdminContact_FirstName = this.AdminContact_FirstName;
            context.AdminContact_LastName = this.AdminContact_LastName;
            context.AdminContact_OrganizationName = this.AdminContact_OrganizationName;
            context.AdminContact_PhoneNumber = this.AdminContact_PhoneNumber;
            context.AdminContact_State = this.AdminContact_State;
            context.AdminContact_ZipCode = this.AdminContact_ZipCode;
            context.DomainName = this.DomainName;
            context.RegistrantContact_AddressLine1 = this.RegistrantContact_AddressLine1;
            context.RegistrantContact_AddressLine2 = this.RegistrantContact_AddressLine2;
            context.RegistrantContact_City = this.RegistrantContact_City;
            context.RegistrantContact_ContactType = this.RegistrantContact_ContactType;
            context.RegistrantContact_CountryCode = this.RegistrantContact_CountryCode;
            context.RegistrantContact_Email = this.RegistrantContact_Email;
            if (this.RegistrantContact_ExtraParam != null)
            {
                context.RegistrantContact_ExtraParams = new List<Amazon.Route53Domains.Model.ExtraParam>(this.RegistrantContact_ExtraParam);
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
                context.TechContact_ExtraParams = new List<Amazon.Route53Domains.Model.ExtraParam>(this.TechContact_ExtraParam);
            }
            context.TechContact_Fax = this.TechContact_Fax;
            context.TechContact_FirstName = this.TechContact_FirstName;
            context.TechContact_LastName = this.TechContact_LastName;
            context.TechContact_OrganizationName = this.TechContact_OrganizationName;
            context.TechContact_PhoneNumber = this.TechContact_PhoneNumber;
            context.TechContact_State = this.TechContact_State;
            context.TechContact_ZipCode = this.TechContact_ZipCode;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53Domains.Model.UpdateDomainContactRequest();
            
            
             // populate AdminContact
            bool requestAdminContactIsNull = true;
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
            if (cmdletContext.AdminContact_ExtraParams != null)
            {
                requestAdminContact_adminContact_ExtraParam = cmdletContext.AdminContact_ExtraParams;
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
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate RegistrantContact
            bool requestRegistrantContactIsNull = true;
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
            if (cmdletContext.RegistrantContact_ExtraParams != null)
            {
                requestRegistrantContact_registrantContact_ExtraParam = cmdletContext.RegistrantContact_ExtraParams;
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
            bool requestTechContactIsNull = true;
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
            if (cmdletContext.TechContact_ExtraParams != null)
            {
                requestTechContact_techContact_ExtraParam = cmdletContext.TechContact_ExtraParams;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateDomainContact(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.OperationId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AdminContact_AddressLine1 { get; set; }
            public System.String AdminContact_AddressLine2 { get; set; }
            public System.String AdminContact_City { get; set; }
            public Amazon.Route53Domains.ContactType AdminContact_ContactType { get; set; }
            public Amazon.Route53Domains.CountryCode AdminContact_CountryCode { get; set; }
            public System.String AdminContact_Email { get; set; }
            public List<Amazon.Route53Domains.Model.ExtraParam> AdminContact_ExtraParams { get; set; }
            public System.String AdminContact_Fax { get; set; }
            public System.String AdminContact_FirstName { get; set; }
            public System.String AdminContact_LastName { get; set; }
            public System.String AdminContact_OrganizationName { get; set; }
            public System.String AdminContact_PhoneNumber { get; set; }
            public System.String AdminContact_State { get; set; }
            public System.String AdminContact_ZipCode { get; set; }
            public System.String DomainName { get; set; }
            public System.String RegistrantContact_AddressLine1 { get; set; }
            public System.String RegistrantContact_AddressLine2 { get; set; }
            public System.String RegistrantContact_City { get; set; }
            public Amazon.Route53Domains.ContactType RegistrantContact_ContactType { get; set; }
            public Amazon.Route53Domains.CountryCode RegistrantContact_CountryCode { get; set; }
            public System.String RegistrantContact_Email { get; set; }
            public List<Amazon.Route53Domains.Model.ExtraParam> RegistrantContact_ExtraParams { get; set; }
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
            public List<Amazon.Route53Domains.Model.ExtraParam> TechContact_ExtraParams { get; set; }
            public System.String TechContact_Fax { get; set; }
            public System.String TechContact_FirstName { get; set; }
            public System.String TechContact_LastName { get; set; }
            public System.String TechContact_OrganizationName { get; set; }
            public System.String TechContact_PhoneNumber { get; set; }
            public System.String TechContact_State { get; set; }
            public System.String TechContact_ZipCode { get; set; }
        }
        
    }
}
