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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Renders the Amazon Q in Connect message template based on the attribute values provided
    /// and generates the message content. For any variable present in the message template,
    /// if the attribute value is neither provided in the attribute request parameter nor
    /// the default attribute of the message template, the rendered message content will keep
    /// the variable placeholder as it is and return the attribute keys that are missing.
    /// </summary>
    [Cmdlet("Invoke", "QCMessageTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.RenderMessageTemplateResponse")]
    [AWSCmdlet("Calls the Amazon Q Connect RenderMessageTemplate API operation.", Operation = new[] {"RenderMessageTemplate"}, SelectReturnType = typeof(Amazon.QConnect.Model.RenderMessageTemplateResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.RenderMessageTemplateResponse",
        "This cmdlet returns an Amazon.QConnect.Model.RenderMessageTemplateResponse object containing multiple properties."
    )]
    public partial class InvokeQCMessageTemplateCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CustomerProfileAttributes_AccountNumber
        /// <summary>
        /// <para>
        /// <para>A unique account number that you have given to the customer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_AccountNumber")]
        public System.String CustomerProfileAttributes_AccountNumber { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_AdditionalInformation
        /// <summary>
        /// <para>
        /// <para>Any additional information relevant to the customer's profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_AdditionalInformation")]
        public System.String CustomerProfileAttributes_AdditionalInformation { get; set; }
        #endregion
        
        #region Parameter CustomerEndpoint_Address
        /// <summary>
        /// <para>
        /// <para>The customer's phone number if used with <c>customerEndpoint</c>, or the number the
        /// customer dialed to call your contact center if used with <c>systemEndpoint</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_SystemAttributes_CustomerEndpoint_Address")]
        public System.String CustomerEndpoint_Address { get; set; }
        #endregion
        
        #region Parameter SystemEndpoint_Address
        /// <summary>
        /// <para>
        /// <para>The customer's phone number if used with <c>customerEndpoint</c>, or the number the
        /// customer dialed to call your contact center if used with <c>systemEndpoint</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_SystemAttributes_SystemEndpoint_Address")]
        public System.String SystemEndpoint_Address { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Address1
        /// <summary>
        /// <para>
        /// <para>The first line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_Address1")]
        public System.String CustomerProfileAttributes_Address1 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Address2
        /// <summary>
        /// <para>
        /// <para>The second line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_Address2")]
        public System.String CustomerProfileAttributes_Address2 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Address3
        /// <summary>
        /// <para>
        /// <para>The third line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_Address3")]
        public System.String CustomerProfileAttributes_Address3 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Address4
        /// <summary>
        /// <para>
        /// <para>The fourth line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_Address4")]
        public System.String CustomerProfileAttributes_Address4 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingAddress1
        /// <summary>
        /// <para>
        /// <para>The first line of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_BillingAddress1")]
        public System.String CustomerProfileAttributes_BillingAddress1 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingAddress2
        /// <summary>
        /// <para>
        /// <para>The second line of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_BillingAddress2")]
        public System.String CustomerProfileAttributes_BillingAddress2 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingAddress3
        /// <summary>
        /// <para>
        /// <para>The third line of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_BillingAddress3")]
        public System.String CustomerProfileAttributes_BillingAddress3 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingAddress4
        /// <summary>
        /// <para>
        /// <para>The fourth line of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_BillingAddress4")]
        public System.String CustomerProfileAttributes_BillingAddress4 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingCity
        /// <summary>
        /// <para>
        /// <para>The city of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_BillingCity")]
        public System.String CustomerProfileAttributes_BillingCity { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingCountry
        /// <summary>
        /// <para>
        /// <para>The country of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_BillingCountry")]
        public System.String CustomerProfileAttributes_BillingCountry { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingCounty
        /// <summary>
        /// <para>
        /// <para>The county of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_BillingCounty")]
        public System.String CustomerProfileAttributes_BillingCounty { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingPostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_BillingPostalCode")]
        public System.String CustomerProfileAttributes_BillingPostalCode { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingProvince
        /// <summary>
        /// <para>
        /// <para>The province of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_BillingProvince")]
        public System.String CustomerProfileAttributes_BillingProvince { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingState
        /// <summary>
        /// <para>
        /// <para>The state of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_BillingState")]
        public System.String CustomerProfileAttributes_BillingState { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BirthDate
        /// <summary>
        /// <para>
        /// <para>The customer's birth date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_BirthDate")]
        public System.String CustomerProfileAttributes_BirthDate { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BusinessEmailAddress
        /// <summary>
        /// <para>
        /// <para>The customer's business email address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_BusinessEmailAddress")]
        public System.String CustomerProfileAttributes_BusinessEmailAddress { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BusinessName
        /// <summary>
        /// <para>
        /// <para>The name of the customer's business.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_BusinessName")]
        public System.String CustomerProfileAttributes_BusinessName { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BusinessPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The customer's business phone number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_BusinessPhoneNumber")]
        public System.String CustomerProfileAttributes_BusinessPhoneNumber { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_City
        /// <summary>
        /// <para>
        /// <para>The city in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_City")]
        public System.String CustomerProfileAttributes_City { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Country
        /// <summary>
        /// <para>
        /// <para>The country in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_Country")]
        public System.String CustomerProfileAttributes_Country { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_County
        /// <summary>
        /// <para>
        /// <para>The county in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_County")]
        public System.String CustomerProfileAttributes_County { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Custom
        /// <summary>
        /// <para>
        /// <para>The custom attributes in customer profile attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_Custom")]
        public System.Collections.Hashtable CustomerProfileAttributes_Custom { get; set; }
        #endregion
        
        #region Parameter Attributes_CustomAttribute
        /// <summary>
        /// <para>
        /// <para>The custom attributes that are used with the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomAttributes")]
        public System.Collections.Hashtable Attributes_CustomAttribute { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_EmailAddress
        /// <summary>
        /// <para>
        /// <para>The customer's email address, which has not been specified as a personal or business
        /// address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_EmailAddress")]
        public System.String CustomerProfileAttributes_EmailAddress { get; set; }
        #endregion
        
        #region Parameter AgentAttributes_FirstName
        /// <summary>
        /// <para>
        /// <para>The agent’s first name as entered in their Amazon Connect user account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_AgentAttributes_FirstName")]
        public System.String AgentAttributes_FirstName { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_FirstName
        /// <summary>
        /// <para>
        /// <para>The customer's first name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_FirstName")]
        public System.String CustomerProfileAttributes_FirstName { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Gender
        /// <summary>
        /// <para>
        /// <para>The customer's gender.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_Gender")]
        public System.String CustomerProfileAttributes_Gender { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_HomePhoneNumber
        /// <summary>
        /// <para>
        /// <para>The customer's mobile phone number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_HomePhoneNumber")]
        public System.String CustomerProfileAttributes_HomePhoneNumber { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The identifier of the knowledge base. Can be either the ID or the ARN. URLs cannot
        /// contain the ARN.</para>
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
        public System.String KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter AgentAttributes_LastName
        /// <summary>
        /// <para>
        /// <para>The agent’s last name as entered in their Amazon Connect user account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_AgentAttributes_LastName")]
        public System.String AgentAttributes_LastName { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_LastName
        /// <summary>
        /// <para>
        /// <para>The customer's last name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_LastName")]
        public System.String CustomerProfileAttributes_LastName { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingAddress1
        /// <summary>
        /// <para>
        /// <para>The first line of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_MailingAddress1")]
        public System.String CustomerProfileAttributes_MailingAddress1 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingAddress2
        /// <summary>
        /// <para>
        /// <para>The second line of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_MailingAddress2")]
        public System.String CustomerProfileAttributes_MailingAddress2 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingAddress3
        /// <summary>
        /// <para>
        /// <para>The third line of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_MailingAddress3")]
        public System.String CustomerProfileAttributes_MailingAddress3 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingAddress4
        /// <summary>
        /// <para>
        /// <para>The fourth line of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_MailingAddress4")]
        public System.String CustomerProfileAttributes_MailingAddress4 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingCity
        /// <summary>
        /// <para>
        /// <para>The city of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_MailingCity")]
        public System.String CustomerProfileAttributes_MailingCity { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingCountry
        /// <summary>
        /// <para>
        /// <para>The country of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_MailingCountry")]
        public System.String CustomerProfileAttributes_MailingCountry { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingCounty
        /// <summary>
        /// <para>
        /// <para>The county of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_MailingCounty")]
        public System.String CustomerProfileAttributes_MailingCounty { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingPostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_MailingPostalCode")]
        public System.String CustomerProfileAttributes_MailingPostalCode { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingProvince
        /// <summary>
        /// <para>
        /// <para>The province of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_MailingProvince")]
        public System.String CustomerProfileAttributes_MailingProvince { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingState
        /// <summary>
        /// <para>
        /// <para>The state of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_MailingState")]
        public System.String CustomerProfileAttributes_MailingState { get; set; }
        #endregion
        
        #region Parameter MessageTemplateId
        /// <summary>
        /// <para>
        /// <para>The identifier of the message template. Can be either the ID or the ARN.</para>
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
        public System.String MessageTemplateId { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MiddleName
        /// <summary>
        /// <para>
        /// <para>The customer's middle name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_MiddleName")]
        public System.String CustomerProfileAttributes_MiddleName { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MobilePhoneNumber
        /// <summary>
        /// <para>
        /// <para>The customer's mobile phone number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_MobilePhoneNumber")]
        public System.String CustomerProfileAttributes_MobilePhoneNumber { get; set; }
        #endregion
        
        #region Parameter SystemAttributes_Name
        /// <summary>
        /// <para>
        /// <para>The name of the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_SystemAttributes_Name")]
        public System.String SystemAttributes_Name { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_PartyType
        /// <summary>
        /// <para>
        /// <para>The customer's party type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_PartyType")]
        public System.String CustomerProfileAttributes_PartyType { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The customer's phone number, which has not been specified as a mobile, home, or business
        /// number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_PhoneNumber")]
        public System.String CustomerProfileAttributes_PhoneNumber { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_PostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_PostalCode")]
        public System.String CustomerProfileAttributes_PostalCode { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ProfileARN
        /// <summary>
        /// <para>
        /// <para>The ARN of a customer profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_ProfileARN")]
        public System.String CustomerProfileAttributes_ProfileARN { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ProfileId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of a customer profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_ProfileId")]
        public System.String CustomerProfileAttributes_ProfileId { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Province
        /// <summary>
        /// <para>
        /// <para>The province in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_Province")]
        public System.String CustomerProfileAttributes_Province { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingAddress1
        /// <summary>
        /// <para>
        /// <para>The first line of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_ShippingAddress1")]
        public System.String CustomerProfileAttributes_ShippingAddress1 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingAddress2
        /// <summary>
        /// <para>
        /// <para>The second line of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_ShippingAddress2")]
        public System.String CustomerProfileAttributes_ShippingAddress2 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingAddress3
        /// <summary>
        /// <para>
        /// <para>The third line of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_ShippingAddress3")]
        public System.String CustomerProfileAttributes_ShippingAddress3 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingAddress4
        /// <summary>
        /// <para>
        /// <para>The fourth line of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_ShippingAddress4")]
        public System.String CustomerProfileAttributes_ShippingAddress4 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingCity
        /// <summary>
        /// <para>
        /// <para>The city of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_ShippingCity")]
        public System.String CustomerProfileAttributes_ShippingCity { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingCountry
        /// <summary>
        /// <para>
        /// <para>The country of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_ShippingCountry")]
        public System.String CustomerProfileAttributes_ShippingCountry { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingCounty
        /// <summary>
        /// <para>
        /// <para>The county of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_ShippingCounty")]
        public System.String CustomerProfileAttributes_ShippingCounty { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingPostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_ShippingPostalCode")]
        public System.String CustomerProfileAttributes_ShippingPostalCode { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingProvince
        /// <summary>
        /// <para>
        /// <para>The province of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_ShippingProvince")]
        public System.String CustomerProfileAttributes_ShippingProvince { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingState
        /// <summary>
        /// <para>
        /// <para>The state of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_ShippingState")]
        public System.String CustomerProfileAttributes_ShippingState { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_State
        /// <summary>
        /// <para>
        /// <para>The state in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes_CustomerProfileAttributes_State")]
        public System.String CustomerProfileAttributes_State { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.RenderMessageTemplateResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.RenderMessageTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MessageTemplateId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MessageTemplateId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MessageTemplateId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MessageTemplateId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-QCMessageTemplate (RenderMessageTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.RenderMessageTemplateResponse, InvokeQCMessageTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MessageTemplateId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AgentAttributes_FirstName = this.AgentAttributes_FirstName;
            context.AgentAttributes_LastName = this.AgentAttributes_LastName;
            if (this.Attributes_CustomAttribute != null)
            {
                context.Attributes_CustomAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attributes_CustomAttribute.Keys)
                {
                    context.Attributes_CustomAttribute.Add((String)hashKey, (System.String)(this.Attributes_CustomAttribute[hashKey]));
                }
            }
            context.CustomerProfileAttributes_AccountNumber = this.CustomerProfileAttributes_AccountNumber;
            context.CustomerProfileAttributes_AdditionalInformation = this.CustomerProfileAttributes_AdditionalInformation;
            context.CustomerProfileAttributes_Address1 = this.CustomerProfileAttributes_Address1;
            context.CustomerProfileAttributes_Address2 = this.CustomerProfileAttributes_Address2;
            context.CustomerProfileAttributes_Address3 = this.CustomerProfileAttributes_Address3;
            context.CustomerProfileAttributes_Address4 = this.CustomerProfileAttributes_Address4;
            context.CustomerProfileAttributes_BillingAddress1 = this.CustomerProfileAttributes_BillingAddress1;
            context.CustomerProfileAttributes_BillingAddress2 = this.CustomerProfileAttributes_BillingAddress2;
            context.CustomerProfileAttributes_BillingAddress3 = this.CustomerProfileAttributes_BillingAddress3;
            context.CustomerProfileAttributes_BillingAddress4 = this.CustomerProfileAttributes_BillingAddress4;
            context.CustomerProfileAttributes_BillingCity = this.CustomerProfileAttributes_BillingCity;
            context.CustomerProfileAttributes_BillingCountry = this.CustomerProfileAttributes_BillingCountry;
            context.CustomerProfileAttributes_BillingCounty = this.CustomerProfileAttributes_BillingCounty;
            context.CustomerProfileAttributes_BillingPostalCode = this.CustomerProfileAttributes_BillingPostalCode;
            context.CustomerProfileAttributes_BillingProvince = this.CustomerProfileAttributes_BillingProvince;
            context.CustomerProfileAttributes_BillingState = this.CustomerProfileAttributes_BillingState;
            context.CustomerProfileAttributes_BirthDate = this.CustomerProfileAttributes_BirthDate;
            context.CustomerProfileAttributes_BusinessEmailAddress = this.CustomerProfileAttributes_BusinessEmailAddress;
            context.CustomerProfileAttributes_BusinessName = this.CustomerProfileAttributes_BusinessName;
            context.CustomerProfileAttributes_BusinessPhoneNumber = this.CustomerProfileAttributes_BusinessPhoneNumber;
            context.CustomerProfileAttributes_City = this.CustomerProfileAttributes_City;
            context.CustomerProfileAttributes_Country = this.CustomerProfileAttributes_Country;
            context.CustomerProfileAttributes_County = this.CustomerProfileAttributes_County;
            if (this.CustomerProfileAttributes_Custom != null)
            {
                context.CustomerProfileAttributes_Custom = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomerProfileAttributes_Custom.Keys)
                {
                    context.CustomerProfileAttributes_Custom.Add((String)hashKey, (System.String)(this.CustomerProfileAttributes_Custom[hashKey]));
                }
            }
            context.CustomerProfileAttributes_EmailAddress = this.CustomerProfileAttributes_EmailAddress;
            context.CustomerProfileAttributes_FirstName = this.CustomerProfileAttributes_FirstName;
            context.CustomerProfileAttributes_Gender = this.CustomerProfileAttributes_Gender;
            context.CustomerProfileAttributes_HomePhoneNumber = this.CustomerProfileAttributes_HomePhoneNumber;
            context.CustomerProfileAttributes_LastName = this.CustomerProfileAttributes_LastName;
            context.CustomerProfileAttributes_MailingAddress1 = this.CustomerProfileAttributes_MailingAddress1;
            context.CustomerProfileAttributes_MailingAddress2 = this.CustomerProfileAttributes_MailingAddress2;
            context.CustomerProfileAttributes_MailingAddress3 = this.CustomerProfileAttributes_MailingAddress3;
            context.CustomerProfileAttributes_MailingAddress4 = this.CustomerProfileAttributes_MailingAddress4;
            context.CustomerProfileAttributes_MailingCity = this.CustomerProfileAttributes_MailingCity;
            context.CustomerProfileAttributes_MailingCountry = this.CustomerProfileAttributes_MailingCountry;
            context.CustomerProfileAttributes_MailingCounty = this.CustomerProfileAttributes_MailingCounty;
            context.CustomerProfileAttributes_MailingPostalCode = this.CustomerProfileAttributes_MailingPostalCode;
            context.CustomerProfileAttributes_MailingProvince = this.CustomerProfileAttributes_MailingProvince;
            context.CustomerProfileAttributes_MailingState = this.CustomerProfileAttributes_MailingState;
            context.CustomerProfileAttributes_MiddleName = this.CustomerProfileAttributes_MiddleName;
            context.CustomerProfileAttributes_MobilePhoneNumber = this.CustomerProfileAttributes_MobilePhoneNumber;
            context.CustomerProfileAttributes_PartyType = this.CustomerProfileAttributes_PartyType;
            context.CustomerProfileAttributes_PhoneNumber = this.CustomerProfileAttributes_PhoneNumber;
            context.CustomerProfileAttributes_PostalCode = this.CustomerProfileAttributes_PostalCode;
            context.CustomerProfileAttributes_ProfileARN = this.CustomerProfileAttributes_ProfileARN;
            context.CustomerProfileAttributes_ProfileId = this.CustomerProfileAttributes_ProfileId;
            context.CustomerProfileAttributes_Province = this.CustomerProfileAttributes_Province;
            context.CustomerProfileAttributes_ShippingAddress1 = this.CustomerProfileAttributes_ShippingAddress1;
            context.CustomerProfileAttributes_ShippingAddress2 = this.CustomerProfileAttributes_ShippingAddress2;
            context.CustomerProfileAttributes_ShippingAddress3 = this.CustomerProfileAttributes_ShippingAddress3;
            context.CustomerProfileAttributes_ShippingAddress4 = this.CustomerProfileAttributes_ShippingAddress4;
            context.CustomerProfileAttributes_ShippingCity = this.CustomerProfileAttributes_ShippingCity;
            context.CustomerProfileAttributes_ShippingCountry = this.CustomerProfileAttributes_ShippingCountry;
            context.CustomerProfileAttributes_ShippingCounty = this.CustomerProfileAttributes_ShippingCounty;
            context.CustomerProfileAttributes_ShippingPostalCode = this.CustomerProfileAttributes_ShippingPostalCode;
            context.CustomerProfileAttributes_ShippingProvince = this.CustomerProfileAttributes_ShippingProvince;
            context.CustomerProfileAttributes_ShippingState = this.CustomerProfileAttributes_ShippingState;
            context.CustomerProfileAttributes_State = this.CustomerProfileAttributes_State;
            context.CustomerEndpoint_Address = this.CustomerEndpoint_Address;
            context.SystemAttributes_Name = this.SystemAttributes_Name;
            context.SystemEndpoint_Address = this.SystemEndpoint_Address;
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MessageTemplateId = this.MessageTemplateId;
            #if MODULAR
            if (this.MessageTemplateId == null && ParameterWasBound(nameof(this.MessageTemplateId)))
            {
                WriteWarning("You are passing $null as a value for parameter MessageTemplateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QConnect.Model.RenderMessageTemplateRequest();
            
            
             // populate Attributes
            var requestAttributesIsNull = true;
            request.Attributes = new Amazon.QConnect.Model.MessageTemplateAttributes();
            Dictionary<System.String, System.String> requestAttributes_attributes_CustomAttribute = null;
            if (cmdletContext.Attributes_CustomAttribute != null)
            {
                requestAttributes_attributes_CustomAttribute = cmdletContext.Attributes_CustomAttribute;
            }
            if (requestAttributes_attributes_CustomAttribute != null)
            {
                request.Attributes.CustomAttributes = requestAttributes_attributes_CustomAttribute;
                requestAttributesIsNull = false;
            }
            Amazon.QConnect.Model.AgentAttributes requestAttributes_attributes_AgentAttributes = null;
            
             // populate AgentAttributes
            var requestAttributes_attributes_AgentAttributesIsNull = true;
            requestAttributes_attributes_AgentAttributes = new Amazon.QConnect.Model.AgentAttributes();
            System.String requestAttributes_attributes_AgentAttributes_agentAttributes_FirstName = null;
            if (cmdletContext.AgentAttributes_FirstName != null)
            {
                requestAttributes_attributes_AgentAttributes_agentAttributes_FirstName = cmdletContext.AgentAttributes_FirstName;
            }
            if (requestAttributes_attributes_AgentAttributes_agentAttributes_FirstName != null)
            {
                requestAttributes_attributes_AgentAttributes.FirstName = requestAttributes_attributes_AgentAttributes_agentAttributes_FirstName;
                requestAttributes_attributes_AgentAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_AgentAttributes_agentAttributes_LastName = null;
            if (cmdletContext.AgentAttributes_LastName != null)
            {
                requestAttributes_attributes_AgentAttributes_agentAttributes_LastName = cmdletContext.AgentAttributes_LastName;
            }
            if (requestAttributes_attributes_AgentAttributes_agentAttributes_LastName != null)
            {
                requestAttributes_attributes_AgentAttributes.LastName = requestAttributes_attributes_AgentAttributes_agentAttributes_LastName;
                requestAttributes_attributes_AgentAttributesIsNull = false;
            }
             // determine if requestAttributes_attributes_AgentAttributes should be set to null
            if (requestAttributes_attributes_AgentAttributesIsNull)
            {
                requestAttributes_attributes_AgentAttributes = null;
            }
            if (requestAttributes_attributes_AgentAttributes != null)
            {
                request.Attributes.AgentAttributes = requestAttributes_attributes_AgentAttributes;
                requestAttributesIsNull = false;
            }
            Amazon.QConnect.Model.SystemAttributes requestAttributes_attributes_SystemAttributes = null;
            
             // populate SystemAttributes
            var requestAttributes_attributes_SystemAttributesIsNull = true;
            requestAttributes_attributes_SystemAttributes = new Amazon.QConnect.Model.SystemAttributes();
            System.String requestAttributes_attributes_SystemAttributes_systemAttributes_Name = null;
            if (cmdletContext.SystemAttributes_Name != null)
            {
                requestAttributes_attributes_SystemAttributes_systemAttributes_Name = cmdletContext.SystemAttributes_Name;
            }
            if (requestAttributes_attributes_SystemAttributes_systemAttributes_Name != null)
            {
                requestAttributes_attributes_SystemAttributes.Name = requestAttributes_attributes_SystemAttributes_systemAttributes_Name;
                requestAttributes_attributes_SystemAttributesIsNull = false;
            }
            Amazon.QConnect.Model.SystemEndpointAttributes requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_CustomerEndpoint = null;
            
             // populate CustomerEndpoint
            var requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_CustomerEndpointIsNull = true;
            requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_CustomerEndpoint = new Amazon.QConnect.Model.SystemEndpointAttributes();
            System.String requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_CustomerEndpoint_customerEndpoint_Address = null;
            if (cmdletContext.CustomerEndpoint_Address != null)
            {
                requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_CustomerEndpoint_customerEndpoint_Address = cmdletContext.CustomerEndpoint_Address;
            }
            if (requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_CustomerEndpoint_customerEndpoint_Address != null)
            {
                requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_CustomerEndpoint.Address = requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_CustomerEndpoint_customerEndpoint_Address;
                requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_CustomerEndpointIsNull = false;
            }
             // determine if requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_CustomerEndpoint should be set to null
            if (requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_CustomerEndpointIsNull)
            {
                requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_CustomerEndpoint = null;
            }
            if (requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_CustomerEndpoint != null)
            {
                requestAttributes_attributes_SystemAttributes.CustomerEndpoint = requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_CustomerEndpoint;
                requestAttributes_attributes_SystemAttributesIsNull = false;
            }
            Amazon.QConnect.Model.SystemEndpointAttributes requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_SystemEndpoint = null;
            
             // populate SystemEndpoint
            var requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_SystemEndpointIsNull = true;
            requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_SystemEndpoint = new Amazon.QConnect.Model.SystemEndpointAttributes();
            System.String requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_SystemEndpoint_systemEndpoint_Address = null;
            if (cmdletContext.SystemEndpoint_Address != null)
            {
                requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_SystemEndpoint_systemEndpoint_Address = cmdletContext.SystemEndpoint_Address;
            }
            if (requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_SystemEndpoint_systemEndpoint_Address != null)
            {
                requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_SystemEndpoint.Address = requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_SystemEndpoint_systemEndpoint_Address;
                requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_SystemEndpointIsNull = false;
            }
             // determine if requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_SystemEndpoint should be set to null
            if (requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_SystemEndpointIsNull)
            {
                requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_SystemEndpoint = null;
            }
            if (requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_SystemEndpoint != null)
            {
                requestAttributes_attributes_SystemAttributes.SystemEndpoint = requestAttributes_attributes_SystemAttributes_attributes_SystemAttributes_SystemEndpoint;
                requestAttributes_attributes_SystemAttributesIsNull = false;
            }
             // determine if requestAttributes_attributes_SystemAttributes should be set to null
            if (requestAttributes_attributes_SystemAttributesIsNull)
            {
                requestAttributes_attributes_SystemAttributes = null;
            }
            if (requestAttributes_attributes_SystemAttributes != null)
            {
                request.Attributes.SystemAttributes = requestAttributes_attributes_SystemAttributes;
                requestAttributesIsNull = false;
            }
            Amazon.QConnect.Model.CustomerProfileAttributes requestAttributes_attributes_CustomerProfileAttributes = null;
            
             // populate CustomerProfileAttributes
            var requestAttributes_attributes_CustomerProfileAttributesIsNull = true;
            requestAttributes_attributes_CustomerProfileAttributes = new Amazon.QConnect.Model.CustomerProfileAttributes();
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_AccountNumber = null;
            if (cmdletContext.CustomerProfileAttributes_AccountNumber != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_AccountNumber = cmdletContext.CustomerProfileAttributes_AccountNumber;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_AccountNumber != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.AccountNumber = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_AccountNumber;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_AdditionalInformation = null;
            if (cmdletContext.CustomerProfileAttributes_AdditionalInformation != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_AdditionalInformation = cmdletContext.CustomerProfileAttributes_AdditionalInformation;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_AdditionalInformation != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.AdditionalInformation = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_AdditionalInformation;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address1 = null;
            if (cmdletContext.CustomerProfileAttributes_Address1 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address1 = cmdletContext.CustomerProfileAttributes_Address1;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address1 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.Address1 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address1;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address2 = null;
            if (cmdletContext.CustomerProfileAttributes_Address2 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address2 = cmdletContext.CustomerProfileAttributes_Address2;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address2 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.Address2 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address2;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address3 = null;
            if (cmdletContext.CustomerProfileAttributes_Address3 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address3 = cmdletContext.CustomerProfileAttributes_Address3;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address3 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.Address3 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address3;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address4 = null;
            if (cmdletContext.CustomerProfileAttributes_Address4 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address4 = cmdletContext.CustomerProfileAttributes_Address4;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address4 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.Address4 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Address4;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress1 = null;
            if (cmdletContext.CustomerProfileAttributes_BillingAddress1 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress1 = cmdletContext.CustomerProfileAttributes_BillingAddress1;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress1 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.BillingAddress1 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress1;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress2 = null;
            if (cmdletContext.CustomerProfileAttributes_BillingAddress2 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress2 = cmdletContext.CustomerProfileAttributes_BillingAddress2;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress2 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.BillingAddress2 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress2;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress3 = null;
            if (cmdletContext.CustomerProfileAttributes_BillingAddress3 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress3 = cmdletContext.CustomerProfileAttributes_BillingAddress3;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress3 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.BillingAddress3 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress3;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress4 = null;
            if (cmdletContext.CustomerProfileAttributes_BillingAddress4 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress4 = cmdletContext.CustomerProfileAttributes_BillingAddress4;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress4 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.BillingAddress4 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress4;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingCity = null;
            if (cmdletContext.CustomerProfileAttributes_BillingCity != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingCity = cmdletContext.CustomerProfileAttributes_BillingCity;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingCity != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.BillingCity = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingCity;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingCountry = null;
            if (cmdletContext.CustomerProfileAttributes_BillingCountry != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingCountry = cmdletContext.CustomerProfileAttributes_BillingCountry;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingCountry != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.BillingCountry = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingCountry;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingCounty = null;
            if (cmdletContext.CustomerProfileAttributes_BillingCounty != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingCounty = cmdletContext.CustomerProfileAttributes_BillingCounty;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingCounty != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.BillingCounty = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingCounty;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingPostalCode = null;
            if (cmdletContext.CustomerProfileAttributes_BillingPostalCode != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingPostalCode = cmdletContext.CustomerProfileAttributes_BillingPostalCode;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingPostalCode != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.BillingPostalCode = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingPostalCode;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingProvince = null;
            if (cmdletContext.CustomerProfileAttributes_BillingProvince != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingProvince = cmdletContext.CustomerProfileAttributes_BillingProvince;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingProvince != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.BillingProvince = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingProvince;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingState = null;
            if (cmdletContext.CustomerProfileAttributes_BillingState != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingState = cmdletContext.CustomerProfileAttributes_BillingState;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingState != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.BillingState = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BillingState;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BirthDate = null;
            if (cmdletContext.CustomerProfileAttributes_BirthDate != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BirthDate = cmdletContext.CustomerProfileAttributes_BirthDate;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BirthDate != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.BirthDate = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BirthDate;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BusinessEmailAddress = null;
            if (cmdletContext.CustomerProfileAttributes_BusinessEmailAddress != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BusinessEmailAddress = cmdletContext.CustomerProfileAttributes_BusinessEmailAddress;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BusinessEmailAddress != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.BusinessEmailAddress = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BusinessEmailAddress;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BusinessName = null;
            if (cmdletContext.CustomerProfileAttributes_BusinessName != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BusinessName = cmdletContext.CustomerProfileAttributes_BusinessName;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BusinessName != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.BusinessName = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BusinessName;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BusinessPhoneNumber = null;
            if (cmdletContext.CustomerProfileAttributes_BusinessPhoneNumber != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BusinessPhoneNumber = cmdletContext.CustomerProfileAttributes_BusinessPhoneNumber;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BusinessPhoneNumber != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.BusinessPhoneNumber = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_BusinessPhoneNumber;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_City = null;
            if (cmdletContext.CustomerProfileAttributes_City != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_City = cmdletContext.CustomerProfileAttributes_City;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_City != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.City = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_City;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Country = null;
            if (cmdletContext.CustomerProfileAttributes_Country != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Country = cmdletContext.CustomerProfileAttributes_Country;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Country != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.Country = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Country;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_County = null;
            if (cmdletContext.CustomerProfileAttributes_County != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_County = cmdletContext.CustomerProfileAttributes_County;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_County != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.County = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_County;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            Dictionary<System.String, System.String> requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Custom = null;
            if (cmdletContext.CustomerProfileAttributes_Custom != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Custom = cmdletContext.CustomerProfileAttributes_Custom;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Custom != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.Custom = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Custom;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_EmailAddress = null;
            if (cmdletContext.CustomerProfileAttributes_EmailAddress != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_EmailAddress = cmdletContext.CustomerProfileAttributes_EmailAddress;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_EmailAddress != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.EmailAddress = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_EmailAddress;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_FirstName = null;
            if (cmdletContext.CustomerProfileAttributes_FirstName != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_FirstName = cmdletContext.CustomerProfileAttributes_FirstName;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_FirstName != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.FirstName = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_FirstName;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Gender = null;
            if (cmdletContext.CustomerProfileAttributes_Gender != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Gender = cmdletContext.CustomerProfileAttributes_Gender;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Gender != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.Gender = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Gender;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_HomePhoneNumber = null;
            if (cmdletContext.CustomerProfileAttributes_HomePhoneNumber != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_HomePhoneNumber = cmdletContext.CustomerProfileAttributes_HomePhoneNumber;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_HomePhoneNumber != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.HomePhoneNumber = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_HomePhoneNumber;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_LastName = null;
            if (cmdletContext.CustomerProfileAttributes_LastName != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_LastName = cmdletContext.CustomerProfileAttributes_LastName;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_LastName != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.LastName = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_LastName;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress1 = null;
            if (cmdletContext.CustomerProfileAttributes_MailingAddress1 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress1 = cmdletContext.CustomerProfileAttributes_MailingAddress1;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress1 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.MailingAddress1 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress1;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress2 = null;
            if (cmdletContext.CustomerProfileAttributes_MailingAddress2 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress2 = cmdletContext.CustomerProfileAttributes_MailingAddress2;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress2 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.MailingAddress2 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress2;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress3 = null;
            if (cmdletContext.CustomerProfileAttributes_MailingAddress3 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress3 = cmdletContext.CustomerProfileAttributes_MailingAddress3;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress3 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.MailingAddress3 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress3;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress4 = null;
            if (cmdletContext.CustomerProfileAttributes_MailingAddress4 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress4 = cmdletContext.CustomerProfileAttributes_MailingAddress4;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress4 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.MailingAddress4 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress4;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingCity = null;
            if (cmdletContext.CustomerProfileAttributes_MailingCity != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingCity = cmdletContext.CustomerProfileAttributes_MailingCity;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingCity != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.MailingCity = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingCity;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingCountry = null;
            if (cmdletContext.CustomerProfileAttributes_MailingCountry != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingCountry = cmdletContext.CustomerProfileAttributes_MailingCountry;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingCountry != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.MailingCountry = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingCountry;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingCounty = null;
            if (cmdletContext.CustomerProfileAttributes_MailingCounty != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingCounty = cmdletContext.CustomerProfileAttributes_MailingCounty;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingCounty != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.MailingCounty = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingCounty;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingPostalCode = null;
            if (cmdletContext.CustomerProfileAttributes_MailingPostalCode != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingPostalCode = cmdletContext.CustomerProfileAttributes_MailingPostalCode;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingPostalCode != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.MailingPostalCode = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingPostalCode;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingProvince = null;
            if (cmdletContext.CustomerProfileAttributes_MailingProvince != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingProvince = cmdletContext.CustomerProfileAttributes_MailingProvince;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingProvince != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.MailingProvince = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingProvince;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingState = null;
            if (cmdletContext.CustomerProfileAttributes_MailingState != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingState = cmdletContext.CustomerProfileAttributes_MailingState;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingState != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.MailingState = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MailingState;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MiddleName = null;
            if (cmdletContext.CustomerProfileAttributes_MiddleName != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MiddleName = cmdletContext.CustomerProfileAttributes_MiddleName;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MiddleName != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.MiddleName = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MiddleName;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MobilePhoneNumber = null;
            if (cmdletContext.CustomerProfileAttributes_MobilePhoneNumber != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MobilePhoneNumber = cmdletContext.CustomerProfileAttributes_MobilePhoneNumber;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MobilePhoneNumber != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.MobilePhoneNumber = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_MobilePhoneNumber;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_PartyType = null;
            if (cmdletContext.CustomerProfileAttributes_PartyType != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_PartyType = cmdletContext.CustomerProfileAttributes_PartyType;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_PartyType != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.PartyType = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_PartyType;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_PhoneNumber = null;
            if (cmdletContext.CustomerProfileAttributes_PhoneNumber != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_PhoneNumber = cmdletContext.CustomerProfileAttributes_PhoneNumber;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_PhoneNumber != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.PhoneNumber = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_PhoneNumber;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_PostalCode = null;
            if (cmdletContext.CustomerProfileAttributes_PostalCode != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_PostalCode = cmdletContext.CustomerProfileAttributes_PostalCode;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_PostalCode != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.PostalCode = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_PostalCode;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ProfileARN = null;
            if (cmdletContext.CustomerProfileAttributes_ProfileARN != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ProfileARN = cmdletContext.CustomerProfileAttributes_ProfileARN;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ProfileARN != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.ProfileARN = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ProfileARN;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ProfileId = null;
            if (cmdletContext.CustomerProfileAttributes_ProfileId != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ProfileId = cmdletContext.CustomerProfileAttributes_ProfileId;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ProfileId != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.ProfileId = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ProfileId;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Province = null;
            if (cmdletContext.CustomerProfileAttributes_Province != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Province = cmdletContext.CustomerProfileAttributes_Province;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Province != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.Province = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_Province;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress1 = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingAddress1 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress1 = cmdletContext.CustomerProfileAttributes_ShippingAddress1;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress1 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.ShippingAddress1 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress1;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress2 = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingAddress2 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress2 = cmdletContext.CustomerProfileAttributes_ShippingAddress2;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress2 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.ShippingAddress2 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress2;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress3 = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingAddress3 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress3 = cmdletContext.CustomerProfileAttributes_ShippingAddress3;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress3 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.ShippingAddress3 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress3;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress4 = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingAddress4 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress4 = cmdletContext.CustomerProfileAttributes_ShippingAddress4;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress4 != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.ShippingAddress4 = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress4;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCity = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingCity != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCity = cmdletContext.CustomerProfileAttributes_ShippingCity;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCity != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.ShippingCity = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCity;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCountry = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingCountry != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCountry = cmdletContext.CustomerProfileAttributes_ShippingCountry;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCountry != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.ShippingCountry = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCountry;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCounty = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingCounty != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCounty = cmdletContext.CustomerProfileAttributes_ShippingCounty;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCounty != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.ShippingCounty = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCounty;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingPostalCode = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingPostalCode != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingPostalCode = cmdletContext.CustomerProfileAttributes_ShippingPostalCode;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingPostalCode != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.ShippingPostalCode = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingPostalCode;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingProvince = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingProvince != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingProvince = cmdletContext.CustomerProfileAttributes_ShippingProvince;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingProvince != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.ShippingProvince = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingProvince;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingState = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingState != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingState = cmdletContext.CustomerProfileAttributes_ShippingState;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingState != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.ShippingState = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_ShippingState;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_State = null;
            if (cmdletContext.CustomerProfileAttributes_State != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_State = cmdletContext.CustomerProfileAttributes_State;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_State != null)
            {
                requestAttributes_attributes_CustomerProfileAttributes.State = requestAttributes_attributes_CustomerProfileAttributes_customerProfileAttributes_State;
                requestAttributes_attributes_CustomerProfileAttributesIsNull = false;
            }
             // determine if requestAttributes_attributes_CustomerProfileAttributes should be set to null
            if (requestAttributes_attributes_CustomerProfileAttributesIsNull)
            {
                requestAttributes_attributes_CustomerProfileAttributes = null;
            }
            if (requestAttributes_attributes_CustomerProfileAttributes != null)
            {
                request.Attributes.CustomerProfileAttributes = requestAttributes_attributes_CustomerProfileAttributes;
                requestAttributesIsNull = false;
            }
             // determine if request.Attributes should be set to null
            if (requestAttributesIsNull)
            {
                request.Attributes = null;
            }
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
            }
            if (cmdletContext.MessageTemplateId != null)
            {
                request.MessageTemplateId = cmdletContext.MessageTemplateId;
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
        
        private Amazon.QConnect.Model.RenderMessageTemplateResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.RenderMessageTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "RenderMessageTemplate");
            try
            {
                #if DESKTOP
                return client.RenderMessageTemplate(request);
                #elif CORECLR
                return client.RenderMessageTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String AgentAttributes_FirstName { get; set; }
            public System.String AgentAttributes_LastName { get; set; }
            public Dictionary<System.String, System.String> Attributes_CustomAttribute { get; set; }
            public System.String CustomerProfileAttributes_AccountNumber { get; set; }
            public System.String CustomerProfileAttributes_AdditionalInformation { get; set; }
            public System.String CustomerProfileAttributes_Address1 { get; set; }
            public System.String CustomerProfileAttributes_Address2 { get; set; }
            public System.String CustomerProfileAttributes_Address3 { get; set; }
            public System.String CustomerProfileAttributes_Address4 { get; set; }
            public System.String CustomerProfileAttributes_BillingAddress1 { get; set; }
            public System.String CustomerProfileAttributes_BillingAddress2 { get; set; }
            public System.String CustomerProfileAttributes_BillingAddress3 { get; set; }
            public System.String CustomerProfileAttributes_BillingAddress4 { get; set; }
            public System.String CustomerProfileAttributes_BillingCity { get; set; }
            public System.String CustomerProfileAttributes_BillingCountry { get; set; }
            public System.String CustomerProfileAttributes_BillingCounty { get; set; }
            public System.String CustomerProfileAttributes_BillingPostalCode { get; set; }
            public System.String CustomerProfileAttributes_BillingProvince { get; set; }
            public System.String CustomerProfileAttributes_BillingState { get; set; }
            public System.String CustomerProfileAttributes_BirthDate { get; set; }
            public System.String CustomerProfileAttributes_BusinessEmailAddress { get; set; }
            public System.String CustomerProfileAttributes_BusinessName { get; set; }
            public System.String CustomerProfileAttributes_BusinessPhoneNumber { get; set; }
            public System.String CustomerProfileAttributes_City { get; set; }
            public System.String CustomerProfileAttributes_Country { get; set; }
            public System.String CustomerProfileAttributes_County { get; set; }
            public Dictionary<System.String, System.String> CustomerProfileAttributes_Custom { get; set; }
            public System.String CustomerProfileAttributes_EmailAddress { get; set; }
            public System.String CustomerProfileAttributes_FirstName { get; set; }
            public System.String CustomerProfileAttributes_Gender { get; set; }
            public System.String CustomerProfileAttributes_HomePhoneNumber { get; set; }
            public System.String CustomerProfileAttributes_LastName { get; set; }
            public System.String CustomerProfileAttributes_MailingAddress1 { get; set; }
            public System.String CustomerProfileAttributes_MailingAddress2 { get; set; }
            public System.String CustomerProfileAttributes_MailingAddress3 { get; set; }
            public System.String CustomerProfileAttributes_MailingAddress4 { get; set; }
            public System.String CustomerProfileAttributes_MailingCity { get; set; }
            public System.String CustomerProfileAttributes_MailingCountry { get; set; }
            public System.String CustomerProfileAttributes_MailingCounty { get; set; }
            public System.String CustomerProfileAttributes_MailingPostalCode { get; set; }
            public System.String CustomerProfileAttributes_MailingProvince { get; set; }
            public System.String CustomerProfileAttributes_MailingState { get; set; }
            public System.String CustomerProfileAttributes_MiddleName { get; set; }
            public System.String CustomerProfileAttributes_MobilePhoneNumber { get; set; }
            public System.String CustomerProfileAttributes_PartyType { get; set; }
            public System.String CustomerProfileAttributes_PhoneNumber { get; set; }
            public System.String CustomerProfileAttributes_PostalCode { get; set; }
            public System.String CustomerProfileAttributes_ProfileARN { get; set; }
            public System.String CustomerProfileAttributes_ProfileId { get; set; }
            public System.String CustomerProfileAttributes_Province { get; set; }
            public System.String CustomerProfileAttributes_ShippingAddress1 { get; set; }
            public System.String CustomerProfileAttributes_ShippingAddress2 { get; set; }
            public System.String CustomerProfileAttributes_ShippingAddress3 { get; set; }
            public System.String CustomerProfileAttributes_ShippingAddress4 { get; set; }
            public System.String CustomerProfileAttributes_ShippingCity { get; set; }
            public System.String CustomerProfileAttributes_ShippingCountry { get; set; }
            public System.String CustomerProfileAttributes_ShippingCounty { get; set; }
            public System.String CustomerProfileAttributes_ShippingPostalCode { get; set; }
            public System.String CustomerProfileAttributes_ShippingProvince { get; set; }
            public System.String CustomerProfileAttributes_ShippingState { get; set; }
            public System.String CustomerProfileAttributes_State { get; set; }
            public System.String CustomerEndpoint_Address { get; set; }
            public System.String SystemAttributes_Name { get; set; }
            public System.String SystemEndpoint_Address { get; set; }
            public System.String KnowledgeBaseId { get; set; }
            public System.String MessageTemplateId { get; set; }
            public System.Func<Amazon.QConnect.Model.RenderMessageTemplateResponse, InvokeQCMessageTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
