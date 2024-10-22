/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CustomerProfiles;
using Amazon.CustomerProfiles.Model;

namespace Amazon.PowerShell.Cmdlets.CPF
{
    /// <summary>
    /// Updates the properties of a profile. The ProfileId is required for updating a customer
    /// profile.
    /// 
    ///  
    /// <para>
    /// When calling the UpdateProfile API, specifying an empty string value means that any
    /// existing value will be removed. Not specifying a string value means that any value
    /// already there will be kept.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CPFProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles UpdateProfile API operation.", Operation = new[] {"UpdateProfile"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.UpdateProfileResponse))]
    [AWSCmdletOutput("System.String or Amazon.CustomerProfiles.Model.UpdateProfileResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CustomerProfiles.Model.UpdateProfileResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCPFProfileCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountNumber
        /// <summary>
        /// <para>
        /// <para>An account number that you have given to the customer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountNumber { get; set; }
        #endregion
        
        #region Parameter AdditionalInformation
        /// <summary>
        /// <para>
        /// <para>Any additional information relevant to the customer’s profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalInformation { get; set; }
        #endregion
        
        #region Parameter Address_Address1
        /// <summary>
        /// <para>
        /// <para>The first line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_Address1 { get; set; }
        #endregion
        
        #region Parameter BillingAddress_Address1
        /// <summary>
        /// <para>
        /// <para>The first line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingAddress_Address1 { get; set; }
        #endregion
        
        #region Parameter MailingAddress_Address1
        /// <summary>
        /// <para>
        /// <para>The first line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MailingAddress_Address1 { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Address1
        /// <summary>
        /// <para>
        /// <para>The first line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Address1 { get; set; }
        #endregion
        
        #region Parameter Address_Address2
        /// <summary>
        /// <para>
        /// <para>The second line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_Address2 { get; set; }
        #endregion
        
        #region Parameter BillingAddress_Address2
        /// <summary>
        /// <para>
        /// <para>The second line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingAddress_Address2 { get; set; }
        #endregion
        
        #region Parameter MailingAddress_Address2
        /// <summary>
        /// <para>
        /// <para>The second line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MailingAddress_Address2 { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Address2
        /// <summary>
        /// <para>
        /// <para>The second line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Address2 { get; set; }
        #endregion
        
        #region Parameter Address_Address3
        /// <summary>
        /// <para>
        /// <para>The third line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_Address3 { get; set; }
        #endregion
        
        #region Parameter BillingAddress_Address3
        /// <summary>
        /// <para>
        /// <para>The third line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingAddress_Address3 { get; set; }
        #endregion
        
        #region Parameter MailingAddress_Address3
        /// <summary>
        /// <para>
        /// <para>The third line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MailingAddress_Address3 { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Address3
        /// <summary>
        /// <para>
        /// <para>The third line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Address3 { get; set; }
        #endregion
        
        #region Parameter Address_Address4
        /// <summary>
        /// <para>
        /// <para>The fourth line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_Address4 { get; set; }
        #endregion
        
        #region Parameter BillingAddress_Address4
        /// <summary>
        /// <para>
        /// <para>The fourth line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingAddress_Address4 { get; set; }
        #endregion
        
        #region Parameter MailingAddress_Address4
        /// <summary>
        /// <para>
        /// <para>The fourth line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MailingAddress_Address4 { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Address4
        /// <summary>
        /// <para>
        /// <para>The fourth line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Address4 { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A key value pair of attributes of a customer profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter BirthDate
        /// <summary>
        /// <para>
        /// <para>The customer’s birth date. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BirthDate { get; set; }
        #endregion
        
        #region Parameter BusinessEmailAddress
        /// <summary>
        /// <para>
        /// <para>The customer’s business email address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BusinessEmailAddress { get; set; }
        #endregion
        
        #region Parameter BusinessName
        /// <summary>
        /// <para>
        /// <para>The name of the customer’s business.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BusinessName { get; set; }
        #endregion
        
        #region Parameter BusinessPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The customer’s business phone number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BusinessPhoneNumber { get; set; }
        #endregion
        
        #region Parameter Address_City
        /// <summary>
        /// <para>
        /// <para>The city in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_City { get; set; }
        #endregion
        
        #region Parameter BillingAddress_City
        /// <summary>
        /// <para>
        /// <para>The city in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingAddress_City { get; set; }
        #endregion
        
        #region Parameter MailingAddress_City
        /// <summary>
        /// <para>
        /// <para>The city in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MailingAddress_City { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_City
        /// <summary>
        /// <para>
        /// <para>The city in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_City { get; set; }
        #endregion
        
        #region Parameter Address_Country
        /// <summary>
        /// <para>
        /// <para>The country in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_Country { get; set; }
        #endregion
        
        #region Parameter BillingAddress_Country
        /// <summary>
        /// <para>
        /// <para>The country in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingAddress_Country { get; set; }
        #endregion
        
        #region Parameter MailingAddress_Country
        /// <summary>
        /// <para>
        /// <para>The country in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MailingAddress_Country { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Country
        /// <summary>
        /// <para>
        /// <para>The country in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Country { get; set; }
        #endregion
        
        #region Parameter Address_County
        /// <summary>
        /// <para>
        /// <para>The county in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_County { get; set; }
        #endregion
        
        #region Parameter BillingAddress_County
        /// <summary>
        /// <para>
        /// <para>The county in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingAddress_County { get; set; }
        #endregion
        
        #region Parameter MailingAddress_County
        /// <summary>
        /// <para>
        /// <para>The county in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MailingAddress_County { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_County
        /// <summary>
        /// <para>
        /// <para>The county in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_County { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The unique name of the domain.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter EmailAddress
        /// <summary>
        /// <para>
        /// <para>The customer’s email address, which has not been specified as a personal or business
        /// address. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailAddress { get; set; }
        #endregion
        
        #region Parameter FirstName
        /// <summary>
        /// <para>
        /// <para>The customer’s first name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirstName { get; set; }
        #endregion
        
        #region Parameter Gender
        /// <summary>
        /// <para>
        /// <para>The gender with which the customer identifies. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CustomerProfiles.Gender")]
        public Amazon.CustomerProfiles.Gender Gender { get; set; }
        #endregion
        
        #region Parameter GenderString
        /// <summary>
        /// <para>
        /// <para>An alternative to <c>Gender</c> which accepts any string as input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GenderString { get; set; }
        #endregion
        
        #region Parameter HomePhoneNumber
        /// <summary>
        /// <para>
        /// <para>The customer’s home phone number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HomePhoneNumber { get; set; }
        #endregion
        
        #region Parameter LastName
        /// <summary>
        /// <para>
        /// <para>The customer’s last name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LastName { get; set; }
        #endregion
        
        #region Parameter MiddleName
        /// <summary>
        /// <para>
        /// <para>The customer’s middle name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MiddleName { get; set; }
        #endregion
        
        #region Parameter MobilePhoneNumber
        /// <summary>
        /// <para>
        /// <para>The customer’s mobile phone number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MobilePhoneNumber { get; set; }
        #endregion
        
        #region Parameter PartyType
        /// <summary>
        /// <para>
        /// <para>The type of profile used to describe the customer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CustomerProfiles.PartyType")]
        public Amazon.CustomerProfiles.PartyType PartyType { get; set; }
        #endregion
        
        #region Parameter PartyTypeString
        /// <summary>
        /// <para>
        /// <para>An alternative to <c>PartyType</c> which accepts any string as input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PartyTypeString { get; set; }
        #endregion
        
        #region Parameter PersonalEmailAddress
        /// <summary>
        /// <para>
        /// <para>The customer’s personal email address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PersonalEmailAddress { get; set; }
        #endregion
        
        #region Parameter PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The customer’s phone number, which has not been specified as a mobile, home, or business
        /// number. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PhoneNumber { get; set; }
        #endregion
        
        #region Parameter Address_PostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_PostalCode { get; set; }
        #endregion
        
        #region Parameter BillingAddress_PostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingAddress_PostalCode { get; set; }
        #endregion
        
        #region Parameter MailingAddress_PostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MailingAddress_PostalCode { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_PostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_PostalCode { get; set; }
        #endregion
        
        #region Parameter ProfileId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of a customer profile.</para>
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
        public System.String ProfileId { get; set; }
        #endregion
        
        #region Parameter Address_Province
        /// <summary>
        /// <para>
        /// <para>The province in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_Province { get; set; }
        #endregion
        
        #region Parameter BillingAddress_Province
        /// <summary>
        /// <para>
        /// <para>The province in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingAddress_Province { get; set; }
        #endregion
        
        #region Parameter MailingAddress_Province
        /// <summary>
        /// <para>
        /// <para>The province in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MailingAddress_Province { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Province
        /// <summary>
        /// <para>
        /// <para>The province in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Province { get; set; }
        #endregion
        
        #region Parameter Address_State
        /// <summary>
        /// <para>
        /// <para>The state in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_State { get; set; }
        #endregion
        
        #region Parameter BillingAddress_State
        /// <summary>
        /// <para>
        /// <para>The state in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingAddress_State { get; set; }
        #endregion
        
        #region Parameter MailingAddress_State
        /// <summary>
        /// <para>
        /// <para>The state in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MailingAddress_State { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_State
        /// <summary>
        /// <para>
        /// <para>The state in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_State { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProfileId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.UpdateProfileResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.UpdateProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProfileId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProfileId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CPFProfile (UpdateProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.UpdateProfileResponse, UpdateCPFProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountNumber = this.AccountNumber;
            context.AdditionalInformation = this.AdditionalInformation;
            context.Address_Address1 = this.Address_Address1;
            context.Address_Address2 = this.Address_Address2;
            context.Address_Address3 = this.Address_Address3;
            context.Address_Address4 = this.Address_Address4;
            context.Address_City = this.Address_City;
            context.Address_Country = this.Address_Country;
            context.Address_County = this.Address_County;
            context.Address_PostalCode = this.Address_PostalCode;
            context.Address_Province = this.Address_Province;
            context.Address_State = this.Address_State;
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            context.BillingAddress_Address1 = this.BillingAddress_Address1;
            context.BillingAddress_Address2 = this.BillingAddress_Address2;
            context.BillingAddress_Address3 = this.BillingAddress_Address3;
            context.BillingAddress_Address4 = this.BillingAddress_Address4;
            context.BillingAddress_City = this.BillingAddress_City;
            context.BillingAddress_Country = this.BillingAddress_Country;
            context.BillingAddress_County = this.BillingAddress_County;
            context.BillingAddress_PostalCode = this.BillingAddress_PostalCode;
            context.BillingAddress_Province = this.BillingAddress_Province;
            context.BillingAddress_State = this.BillingAddress_State;
            context.BirthDate = this.BirthDate;
            context.BusinessEmailAddress = this.BusinessEmailAddress;
            context.BusinessName = this.BusinessName;
            context.BusinessPhoneNumber = this.BusinessPhoneNumber;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailAddress = this.EmailAddress;
            context.FirstName = this.FirstName;
            context.Gender = this.Gender;
            context.GenderString = this.GenderString;
            context.HomePhoneNumber = this.HomePhoneNumber;
            context.LastName = this.LastName;
            context.MailingAddress_Address1 = this.MailingAddress_Address1;
            context.MailingAddress_Address2 = this.MailingAddress_Address2;
            context.MailingAddress_Address3 = this.MailingAddress_Address3;
            context.MailingAddress_Address4 = this.MailingAddress_Address4;
            context.MailingAddress_City = this.MailingAddress_City;
            context.MailingAddress_Country = this.MailingAddress_Country;
            context.MailingAddress_County = this.MailingAddress_County;
            context.MailingAddress_PostalCode = this.MailingAddress_PostalCode;
            context.MailingAddress_Province = this.MailingAddress_Province;
            context.MailingAddress_State = this.MailingAddress_State;
            context.MiddleName = this.MiddleName;
            context.MobilePhoneNumber = this.MobilePhoneNumber;
            context.PartyType = this.PartyType;
            context.PartyTypeString = this.PartyTypeString;
            context.PersonalEmailAddress = this.PersonalEmailAddress;
            context.PhoneNumber = this.PhoneNumber;
            context.ProfileId = this.ProfileId;
            #if MODULAR
            if (this.ProfileId == null && ParameterWasBound(nameof(this.ProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShippingAddress_Address1 = this.ShippingAddress_Address1;
            context.ShippingAddress_Address2 = this.ShippingAddress_Address2;
            context.ShippingAddress_Address3 = this.ShippingAddress_Address3;
            context.ShippingAddress_Address4 = this.ShippingAddress_Address4;
            context.ShippingAddress_City = this.ShippingAddress_City;
            context.ShippingAddress_Country = this.ShippingAddress_Country;
            context.ShippingAddress_County = this.ShippingAddress_County;
            context.ShippingAddress_PostalCode = this.ShippingAddress_PostalCode;
            context.ShippingAddress_Province = this.ShippingAddress_Province;
            context.ShippingAddress_State = this.ShippingAddress_State;
            
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
            var request = new Amazon.CustomerProfiles.Model.UpdateProfileRequest();
            
            if (cmdletContext.AccountNumber != null)
            {
                request.AccountNumber = cmdletContext.AccountNumber;
            }
            if (cmdletContext.AdditionalInformation != null)
            {
                request.AdditionalInformation = cmdletContext.AdditionalInformation;
            }
            
             // populate Address
            var requestAddressIsNull = true;
            request.Address = new Amazon.CustomerProfiles.Model.UpdateAddress();
            System.String requestAddress_address_Address1 = null;
            if (cmdletContext.Address_Address1 != null)
            {
                requestAddress_address_Address1 = cmdletContext.Address_Address1;
            }
            if (requestAddress_address_Address1 != null)
            {
                request.Address.Address1 = requestAddress_address_Address1;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_Address2 = null;
            if (cmdletContext.Address_Address2 != null)
            {
                requestAddress_address_Address2 = cmdletContext.Address_Address2;
            }
            if (requestAddress_address_Address2 != null)
            {
                request.Address.Address2 = requestAddress_address_Address2;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_Address3 = null;
            if (cmdletContext.Address_Address3 != null)
            {
                requestAddress_address_Address3 = cmdletContext.Address_Address3;
            }
            if (requestAddress_address_Address3 != null)
            {
                request.Address.Address3 = requestAddress_address_Address3;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_Address4 = null;
            if (cmdletContext.Address_Address4 != null)
            {
                requestAddress_address_Address4 = cmdletContext.Address_Address4;
            }
            if (requestAddress_address_Address4 != null)
            {
                request.Address.Address4 = requestAddress_address_Address4;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_City = null;
            if (cmdletContext.Address_City != null)
            {
                requestAddress_address_City = cmdletContext.Address_City;
            }
            if (requestAddress_address_City != null)
            {
                request.Address.City = requestAddress_address_City;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_Country = null;
            if (cmdletContext.Address_Country != null)
            {
                requestAddress_address_Country = cmdletContext.Address_Country;
            }
            if (requestAddress_address_Country != null)
            {
                request.Address.Country = requestAddress_address_Country;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_County = null;
            if (cmdletContext.Address_County != null)
            {
                requestAddress_address_County = cmdletContext.Address_County;
            }
            if (requestAddress_address_County != null)
            {
                request.Address.County = requestAddress_address_County;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_PostalCode = null;
            if (cmdletContext.Address_PostalCode != null)
            {
                requestAddress_address_PostalCode = cmdletContext.Address_PostalCode;
            }
            if (requestAddress_address_PostalCode != null)
            {
                request.Address.PostalCode = requestAddress_address_PostalCode;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_Province = null;
            if (cmdletContext.Address_Province != null)
            {
                requestAddress_address_Province = cmdletContext.Address_Province;
            }
            if (requestAddress_address_Province != null)
            {
                request.Address.Province = requestAddress_address_Province;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_State = null;
            if (cmdletContext.Address_State != null)
            {
                requestAddress_address_State = cmdletContext.Address_State;
            }
            if (requestAddress_address_State != null)
            {
                request.Address.State = requestAddress_address_State;
                requestAddressIsNull = false;
            }
             // determine if request.Address should be set to null
            if (requestAddressIsNull)
            {
                request.Address = null;
            }
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            
             // populate BillingAddress
            var requestBillingAddressIsNull = true;
            request.BillingAddress = new Amazon.CustomerProfiles.Model.UpdateAddress();
            System.String requestBillingAddress_billingAddress_Address1 = null;
            if (cmdletContext.BillingAddress_Address1 != null)
            {
                requestBillingAddress_billingAddress_Address1 = cmdletContext.BillingAddress_Address1;
            }
            if (requestBillingAddress_billingAddress_Address1 != null)
            {
                request.BillingAddress.Address1 = requestBillingAddress_billingAddress_Address1;
                requestBillingAddressIsNull = false;
            }
            System.String requestBillingAddress_billingAddress_Address2 = null;
            if (cmdletContext.BillingAddress_Address2 != null)
            {
                requestBillingAddress_billingAddress_Address2 = cmdletContext.BillingAddress_Address2;
            }
            if (requestBillingAddress_billingAddress_Address2 != null)
            {
                request.BillingAddress.Address2 = requestBillingAddress_billingAddress_Address2;
                requestBillingAddressIsNull = false;
            }
            System.String requestBillingAddress_billingAddress_Address3 = null;
            if (cmdletContext.BillingAddress_Address3 != null)
            {
                requestBillingAddress_billingAddress_Address3 = cmdletContext.BillingAddress_Address3;
            }
            if (requestBillingAddress_billingAddress_Address3 != null)
            {
                request.BillingAddress.Address3 = requestBillingAddress_billingAddress_Address3;
                requestBillingAddressIsNull = false;
            }
            System.String requestBillingAddress_billingAddress_Address4 = null;
            if (cmdletContext.BillingAddress_Address4 != null)
            {
                requestBillingAddress_billingAddress_Address4 = cmdletContext.BillingAddress_Address4;
            }
            if (requestBillingAddress_billingAddress_Address4 != null)
            {
                request.BillingAddress.Address4 = requestBillingAddress_billingAddress_Address4;
                requestBillingAddressIsNull = false;
            }
            System.String requestBillingAddress_billingAddress_City = null;
            if (cmdletContext.BillingAddress_City != null)
            {
                requestBillingAddress_billingAddress_City = cmdletContext.BillingAddress_City;
            }
            if (requestBillingAddress_billingAddress_City != null)
            {
                request.BillingAddress.City = requestBillingAddress_billingAddress_City;
                requestBillingAddressIsNull = false;
            }
            System.String requestBillingAddress_billingAddress_Country = null;
            if (cmdletContext.BillingAddress_Country != null)
            {
                requestBillingAddress_billingAddress_Country = cmdletContext.BillingAddress_Country;
            }
            if (requestBillingAddress_billingAddress_Country != null)
            {
                request.BillingAddress.Country = requestBillingAddress_billingAddress_Country;
                requestBillingAddressIsNull = false;
            }
            System.String requestBillingAddress_billingAddress_County = null;
            if (cmdletContext.BillingAddress_County != null)
            {
                requestBillingAddress_billingAddress_County = cmdletContext.BillingAddress_County;
            }
            if (requestBillingAddress_billingAddress_County != null)
            {
                request.BillingAddress.County = requestBillingAddress_billingAddress_County;
                requestBillingAddressIsNull = false;
            }
            System.String requestBillingAddress_billingAddress_PostalCode = null;
            if (cmdletContext.BillingAddress_PostalCode != null)
            {
                requestBillingAddress_billingAddress_PostalCode = cmdletContext.BillingAddress_PostalCode;
            }
            if (requestBillingAddress_billingAddress_PostalCode != null)
            {
                request.BillingAddress.PostalCode = requestBillingAddress_billingAddress_PostalCode;
                requestBillingAddressIsNull = false;
            }
            System.String requestBillingAddress_billingAddress_Province = null;
            if (cmdletContext.BillingAddress_Province != null)
            {
                requestBillingAddress_billingAddress_Province = cmdletContext.BillingAddress_Province;
            }
            if (requestBillingAddress_billingAddress_Province != null)
            {
                request.BillingAddress.Province = requestBillingAddress_billingAddress_Province;
                requestBillingAddressIsNull = false;
            }
            System.String requestBillingAddress_billingAddress_State = null;
            if (cmdletContext.BillingAddress_State != null)
            {
                requestBillingAddress_billingAddress_State = cmdletContext.BillingAddress_State;
            }
            if (requestBillingAddress_billingAddress_State != null)
            {
                request.BillingAddress.State = requestBillingAddress_billingAddress_State;
                requestBillingAddressIsNull = false;
            }
             // determine if request.BillingAddress should be set to null
            if (requestBillingAddressIsNull)
            {
                request.BillingAddress = null;
            }
            if (cmdletContext.BirthDate != null)
            {
                request.BirthDate = cmdletContext.BirthDate;
            }
            if (cmdletContext.BusinessEmailAddress != null)
            {
                request.BusinessEmailAddress = cmdletContext.BusinessEmailAddress;
            }
            if (cmdletContext.BusinessName != null)
            {
                request.BusinessName = cmdletContext.BusinessName;
            }
            if (cmdletContext.BusinessPhoneNumber != null)
            {
                request.BusinessPhoneNumber = cmdletContext.BusinessPhoneNumber;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.EmailAddress != null)
            {
                request.EmailAddress = cmdletContext.EmailAddress;
            }
            if (cmdletContext.FirstName != null)
            {
                request.FirstName = cmdletContext.FirstName;
            }
            if (cmdletContext.Gender != null)
            {
                request.Gender = cmdletContext.Gender;
            }
            if (cmdletContext.GenderString != null)
            {
                request.GenderString = cmdletContext.GenderString;
            }
            if (cmdletContext.HomePhoneNumber != null)
            {
                request.HomePhoneNumber = cmdletContext.HomePhoneNumber;
            }
            if (cmdletContext.LastName != null)
            {
                request.LastName = cmdletContext.LastName;
            }
            
             // populate MailingAddress
            var requestMailingAddressIsNull = true;
            request.MailingAddress = new Amazon.CustomerProfiles.Model.UpdateAddress();
            System.String requestMailingAddress_mailingAddress_Address1 = null;
            if (cmdletContext.MailingAddress_Address1 != null)
            {
                requestMailingAddress_mailingAddress_Address1 = cmdletContext.MailingAddress_Address1;
            }
            if (requestMailingAddress_mailingAddress_Address1 != null)
            {
                request.MailingAddress.Address1 = requestMailingAddress_mailingAddress_Address1;
                requestMailingAddressIsNull = false;
            }
            System.String requestMailingAddress_mailingAddress_Address2 = null;
            if (cmdletContext.MailingAddress_Address2 != null)
            {
                requestMailingAddress_mailingAddress_Address2 = cmdletContext.MailingAddress_Address2;
            }
            if (requestMailingAddress_mailingAddress_Address2 != null)
            {
                request.MailingAddress.Address2 = requestMailingAddress_mailingAddress_Address2;
                requestMailingAddressIsNull = false;
            }
            System.String requestMailingAddress_mailingAddress_Address3 = null;
            if (cmdletContext.MailingAddress_Address3 != null)
            {
                requestMailingAddress_mailingAddress_Address3 = cmdletContext.MailingAddress_Address3;
            }
            if (requestMailingAddress_mailingAddress_Address3 != null)
            {
                request.MailingAddress.Address3 = requestMailingAddress_mailingAddress_Address3;
                requestMailingAddressIsNull = false;
            }
            System.String requestMailingAddress_mailingAddress_Address4 = null;
            if (cmdletContext.MailingAddress_Address4 != null)
            {
                requestMailingAddress_mailingAddress_Address4 = cmdletContext.MailingAddress_Address4;
            }
            if (requestMailingAddress_mailingAddress_Address4 != null)
            {
                request.MailingAddress.Address4 = requestMailingAddress_mailingAddress_Address4;
                requestMailingAddressIsNull = false;
            }
            System.String requestMailingAddress_mailingAddress_City = null;
            if (cmdletContext.MailingAddress_City != null)
            {
                requestMailingAddress_mailingAddress_City = cmdletContext.MailingAddress_City;
            }
            if (requestMailingAddress_mailingAddress_City != null)
            {
                request.MailingAddress.City = requestMailingAddress_mailingAddress_City;
                requestMailingAddressIsNull = false;
            }
            System.String requestMailingAddress_mailingAddress_Country = null;
            if (cmdletContext.MailingAddress_Country != null)
            {
                requestMailingAddress_mailingAddress_Country = cmdletContext.MailingAddress_Country;
            }
            if (requestMailingAddress_mailingAddress_Country != null)
            {
                request.MailingAddress.Country = requestMailingAddress_mailingAddress_Country;
                requestMailingAddressIsNull = false;
            }
            System.String requestMailingAddress_mailingAddress_County = null;
            if (cmdletContext.MailingAddress_County != null)
            {
                requestMailingAddress_mailingAddress_County = cmdletContext.MailingAddress_County;
            }
            if (requestMailingAddress_mailingAddress_County != null)
            {
                request.MailingAddress.County = requestMailingAddress_mailingAddress_County;
                requestMailingAddressIsNull = false;
            }
            System.String requestMailingAddress_mailingAddress_PostalCode = null;
            if (cmdletContext.MailingAddress_PostalCode != null)
            {
                requestMailingAddress_mailingAddress_PostalCode = cmdletContext.MailingAddress_PostalCode;
            }
            if (requestMailingAddress_mailingAddress_PostalCode != null)
            {
                request.MailingAddress.PostalCode = requestMailingAddress_mailingAddress_PostalCode;
                requestMailingAddressIsNull = false;
            }
            System.String requestMailingAddress_mailingAddress_Province = null;
            if (cmdletContext.MailingAddress_Province != null)
            {
                requestMailingAddress_mailingAddress_Province = cmdletContext.MailingAddress_Province;
            }
            if (requestMailingAddress_mailingAddress_Province != null)
            {
                request.MailingAddress.Province = requestMailingAddress_mailingAddress_Province;
                requestMailingAddressIsNull = false;
            }
            System.String requestMailingAddress_mailingAddress_State = null;
            if (cmdletContext.MailingAddress_State != null)
            {
                requestMailingAddress_mailingAddress_State = cmdletContext.MailingAddress_State;
            }
            if (requestMailingAddress_mailingAddress_State != null)
            {
                request.MailingAddress.State = requestMailingAddress_mailingAddress_State;
                requestMailingAddressIsNull = false;
            }
             // determine if request.MailingAddress should be set to null
            if (requestMailingAddressIsNull)
            {
                request.MailingAddress = null;
            }
            if (cmdletContext.MiddleName != null)
            {
                request.MiddleName = cmdletContext.MiddleName;
            }
            if (cmdletContext.MobilePhoneNumber != null)
            {
                request.MobilePhoneNumber = cmdletContext.MobilePhoneNumber;
            }
            if (cmdletContext.PartyType != null)
            {
                request.PartyType = cmdletContext.PartyType;
            }
            if (cmdletContext.PartyTypeString != null)
            {
                request.PartyTypeString = cmdletContext.PartyTypeString;
            }
            if (cmdletContext.PersonalEmailAddress != null)
            {
                request.PersonalEmailAddress = cmdletContext.PersonalEmailAddress;
            }
            if (cmdletContext.PhoneNumber != null)
            {
                request.PhoneNumber = cmdletContext.PhoneNumber;
            }
            if (cmdletContext.ProfileId != null)
            {
                request.ProfileId = cmdletContext.ProfileId;
            }
            
             // populate ShippingAddress
            var requestShippingAddressIsNull = true;
            request.ShippingAddress = new Amazon.CustomerProfiles.Model.UpdateAddress();
            System.String requestShippingAddress_shippingAddress_Address1 = null;
            if (cmdletContext.ShippingAddress_Address1 != null)
            {
                requestShippingAddress_shippingAddress_Address1 = cmdletContext.ShippingAddress_Address1;
            }
            if (requestShippingAddress_shippingAddress_Address1 != null)
            {
                request.ShippingAddress.Address1 = requestShippingAddress_shippingAddress_Address1;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Address2 = null;
            if (cmdletContext.ShippingAddress_Address2 != null)
            {
                requestShippingAddress_shippingAddress_Address2 = cmdletContext.ShippingAddress_Address2;
            }
            if (requestShippingAddress_shippingAddress_Address2 != null)
            {
                request.ShippingAddress.Address2 = requestShippingAddress_shippingAddress_Address2;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Address3 = null;
            if (cmdletContext.ShippingAddress_Address3 != null)
            {
                requestShippingAddress_shippingAddress_Address3 = cmdletContext.ShippingAddress_Address3;
            }
            if (requestShippingAddress_shippingAddress_Address3 != null)
            {
                request.ShippingAddress.Address3 = requestShippingAddress_shippingAddress_Address3;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Address4 = null;
            if (cmdletContext.ShippingAddress_Address4 != null)
            {
                requestShippingAddress_shippingAddress_Address4 = cmdletContext.ShippingAddress_Address4;
            }
            if (requestShippingAddress_shippingAddress_Address4 != null)
            {
                request.ShippingAddress.Address4 = requestShippingAddress_shippingAddress_Address4;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_City = null;
            if (cmdletContext.ShippingAddress_City != null)
            {
                requestShippingAddress_shippingAddress_City = cmdletContext.ShippingAddress_City;
            }
            if (requestShippingAddress_shippingAddress_City != null)
            {
                request.ShippingAddress.City = requestShippingAddress_shippingAddress_City;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Country = null;
            if (cmdletContext.ShippingAddress_Country != null)
            {
                requestShippingAddress_shippingAddress_Country = cmdletContext.ShippingAddress_Country;
            }
            if (requestShippingAddress_shippingAddress_Country != null)
            {
                request.ShippingAddress.Country = requestShippingAddress_shippingAddress_Country;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_County = null;
            if (cmdletContext.ShippingAddress_County != null)
            {
                requestShippingAddress_shippingAddress_County = cmdletContext.ShippingAddress_County;
            }
            if (requestShippingAddress_shippingAddress_County != null)
            {
                request.ShippingAddress.County = requestShippingAddress_shippingAddress_County;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_PostalCode = null;
            if (cmdletContext.ShippingAddress_PostalCode != null)
            {
                requestShippingAddress_shippingAddress_PostalCode = cmdletContext.ShippingAddress_PostalCode;
            }
            if (requestShippingAddress_shippingAddress_PostalCode != null)
            {
                request.ShippingAddress.PostalCode = requestShippingAddress_shippingAddress_PostalCode;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Province = null;
            if (cmdletContext.ShippingAddress_Province != null)
            {
                requestShippingAddress_shippingAddress_Province = cmdletContext.ShippingAddress_Province;
            }
            if (requestShippingAddress_shippingAddress_Province != null)
            {
                request.ShippingAddress.Province = requestShippingAddress_shippingAddress_Province;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_State = null;
            if (cmdletContext.ShippingAddress_State != null)
            {
                requestShippingAddress_shippingAddress_State = cmdletContext.ShippingAddress_State;
            }
            if (requestShippingAddress_shippingAddress_State != null)
            {
                request.ShippingAddress.State = requestShippingAddress_shippingAddress_State;
                requestShippingAddressIsNull = false;
            }
             // determine if request.ShippingAddress should be set to null
            if (requestShippingAddressIsNull)
            {
                request.ShippingAddress = null;
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
        
        private Amazon.CustomerProfiles.Model.UpdateProfileResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.UpdateProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "UpdateProfile");
            try
            {
                #if DESKTOP
                return client.UpdateProfile(request);
                #elif CORECLR
                return client.UpdateProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountNumber { get; set; }
            public System.String AdditionalInformation { get; set; }
            public System.String Address_Address1 { get; set; }
            public System.String Address_Address2 { get; set; }
            public System.String Address_Address3 { get; set; }
            public System.String Address_Address4 { get; set; }
            public System.String Address_City { get; set; }
            public System.String Address_Country { get; set; }
            public System.String Address_County { get; set; }
            public System.String Address_PostalCode { get; set; }
            public System.String Address_Province { get; set; }
            public System.String Address_State { get; set; }
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String BillingAddress_Address1 { get; set; }
            public System.String BillingAddress_Address2 { get; set; }
            public System.String BillingAddress_Address3 { get; set; }
            public System.String BillingAddress_Address4 { get; set; }
            public System.String BillingAddress_City { get; set; }
            public System.String BillingAddress_Country { get; set; }
            public System.String BillingAddress_County { get; set; }
            public System.String BillingAddress_PostalCode { get; set; }
            public System.String BillingAddress_Province { get; set; }
            public System.String BillingAddress_State { get; set; }
            public System.String BirthDate { get; set; }
            public System.String BusinessEmailAddress { get; set; }
            public System.String BusinessName { get; set; }
            public System.String BusinessPhoneNumber { get; set; }
            public System.String DomainName { get; set; }
            public System.String EmailAddress { get; set; }
            public System.String FirstName { get; set; }
            public Amazon.CustomerProfiles.Gender Gender { get; set; }
            public System.String GenderString { get; set; }
            public System.String HomePhoneNumber { get; set; }
            public System.String LastName { get; set; }
            public System.String MailingAddress_Address1 { get; set; }
            public System.String MailingAddress_Address2 { get; set; }
            public System.String MailingAddress_Address3 { get; set; }
            public System.String MailingAddress_Address4 { get; set; }
            public System.String MailingAddress_City { get; set; }
            public System.String MailingAddress_Country { get; set; }
            public System.String MailingAddress_County { get; set; }
            public System.String MailingAddress_PostalCode { get; set; }
            public System.String MailingAddress_Province { get; set; }
            public System.String MailingAddress_State { get; set; }
            public System.String MiddleName { get; set; }
            public System.String MobilePhoneNumber { get; set; }
            public Amazon.CustomerProfiles.PartyType PartyType { get; set; }
            public System.String PartyTypeString { get; set; }
            public System.String PersonalEmailAddress { get; set; }
            public System.String PhoneNumber { get; set; }
            public System.String ProfileId { get; set; }
            public System.String ShippingAddress_Address1 { get; set; }
            public System.String ShippingAddress_Address2 { get; set; }
            public System.String ShippingAddress_Address3 { get; set; }
            public System.String ShippingAddress_Address4 { get; set; }
            public System.String ShippingAddress_City { get; set; }
            public System.String ShippingAddress_Country { get; set; }
            public System.String ShippingAddress_County { get; set; }
            public System.String ShippingAddress_PostalCode { get; set; }
            public System.String ShippingAddress_Province { get; set; }
            public System.String ShippingAddress_State { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.UpdateProfileResponse, UpdateCPFProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProfileId;
        }
        
    }
}
