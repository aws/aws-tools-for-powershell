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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Creates an Amazon Q in Connect message template. The name of the message template
    /// has to be unique for each knowledge base. The channel subtype of the message template
    /// is immutable and cannot be modified after creation. After the message template is
    /// created, you can use the <c>$LATEST</c> qualifier to reference the created message
    /// template.
    /// </summary>
    [Cmdlet("New", "QCMessageTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.MessageTemplateData")]
    [AWSCmdlet("Calls the Amazon Q Connect CreateMessageTemplate API operation.", Operation = new[] {"CreateMessageTemplate"}, SelectReturnType = typeof(Amazon.QConnect.Model.CreateMessageTemplateResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.MessageTemplateData or Amazon.QConnect.Model.CreateMessageTemplateResponse",
        "This cmdlet returns an Amazon.QConnect.Model.MessageTemplateData object.",
        "The service call response (type Amazon.QConnect.Model.CreateMessageTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewQCMessageTemplateCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CustomerProfileAttributes_AccountNumber
        /// <summary>
        /// <para>
        /// <para>A unique account number that you have given to the customer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_AccountNumber")]
        public System.String CustomerProfileAttributes_AccountNumber { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_AdditionalInformation
        /// <summary>
        /// <para>
        /// <para>Any additional information relevant to the customer's profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_AdditionalInformation")]
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
        [Alias("DefaultAttributes_SystemAttributes_CustomerEndpoint_Address")]
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
        [Alias("DefaultAttributes_SystemAttributes_SystemEndpoint_Address")]
        public System.String SystemEndpoint_Address { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Address1
        /// <summary>
        /// <para>
        /// <para>The first line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_Address1")]
        public System.String CustomerProfileAttributes_Address1 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Address2
        /// <summary>
        /// <para>
        /// <para>The second line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_Address2")]
        public System.String CustomerProfileAttributes_Address2 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Address3
        /// <summary>
        /// <para>
        /// <para>The third line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_Address3")]
        public System.String CustomerProfileAttributes_Address3 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Address4
        /// <summary>
        /// <para>
        /// <para>The fourth line of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_Address4")]
        public System.String CustomerProfileAttributes_Address4 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingAddress1
        /// <summary>
        /// <para>
        /// <para>The first line of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_BillingAddress1")]
        public System.String CustomerProfileAttributes_BillingAddress1 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingAddress2
        /// <summary>
        /// <para>
        /// <para>The second line of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_BillingAddress2")]
        public System.String CustomerProfileAttributes_BillingAddress2 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingAddress3
        /// <summary>
        /// <para>
        /// <para>The third line of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_BillingAddress3")]
        public System.String CustomerProfileAttributes_BillingAddress3 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingAddress4
        /// <summary>
        /// <para>
        /// <para>The fourth line of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_BillingAddress4")]
        public System.String CustomerProfileAttributes_BillingAddress4 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingCity
        /// <summary>
        /// <para>
        /// <para>The city of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_BillingCity")]
        public System.String CustomerProfileAttributes_BillingCity { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingCountry
        /// <summary>
        /// <para>
        /// <para>The country of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_BillingCountry")]
        public System.String CustomerProfileAttributes_BillingCountry { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingCounty
        /// <summary>
        /// <para>
        /// <para>The county of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_BillingCounty")]
        public System.String CustomerProfileAttributes_BillingCounty { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingPostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_BillingPostalCode")]
        public System.String CustomerProfileAttributes_BillingPostalCode { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingProvince
        /// <summary>
        /// <para>
        /// <para>The province of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_BillingProvince")]
        public System.String CustomerProfileAttributes_BillingProvince { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BillingState
        /// <summary>
        /// <para>
        /// <para>The state of a customer’s billing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_BillingState")]
        public System.String CustomerProfileAttributes_BillingState { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BirthDate
        /// <summary>
        /// <para>
        /// <para>The customer's birth date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_BirthDate")]
        public System.String CustomerProfileAttributes_BirthDate { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BusinessEmailAddress
        /// <summary>
        /// <para>
        /// <para>The customer's business email address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_BusinessEmailAddress")]
        public System.String CustomerProfileAttributes_BusinessEmailAddress { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BusinessName
        /// <summary>
        /// <para>
        /// <para>The name of the customer's business.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_BusinessName")]
        public System.String CustomerProfileAttributes_BusinessName { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_BusinessPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The customer's business phone number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_BusinessPhoneNumber")]
        public System.String CustomerProfileAttributes_BusinessPhoneNumber { get; set; }
        #endregion
        
        #region Parameter ChannelSubtype
        /// <summary>
        /// <para>
        /// <para>The channel subtype this message template applies to.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QConnect.ChannelSubtype")]
        public Amazon.QConnect.ChannelSubtype ChannelSubtype { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_City
        /// <summary>
        /// <para>
        /// <para>The city in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_City")]
        public System.String CustomerProfileAttributes_City { get; set; }
        #endregion
        
        #region Parameter Html_Content
        /// <summary>
        /// <para>
        /// <para>The content of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Email_Body_Html_Content")]
        public System.String Html_Content { get; set; }
        #endregion
        
        #region Parameter Content_Email_Body_PlainText_Content
        /// <summary>
        /// <para>
        /// <para>The content of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Email_Body_PlainText_Content { get; set; }
        #endregion
        
        #region Parameter Content_Sms_Body_PlainText_Content
        /// <summary>
        /// <para>
        /// <para>The content of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Sms_Body_PlainText_Content { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Country
        /// <summary>
        /// <para>
        /// <para>The country in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_Country")]
        public System.String CustomerProfileAttributes_Country { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_County
        /// <summary>
        /// <para>
        /// <para>The county in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_County")]
        public System.String CustomerProfileAttributes_County { get; set; }
        #endregion
        
        #region Parameter GroupingConfiguration_Criterion
        /// <summary>
        /// <para>
        /// <para>The criteria used for grouping Amazon Q in Connect users.</para><para>The following is the list of supported criteria values.</para><ul><li><para><c>RoutingProfileArn</c>: Grouping the users by their <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_RoutingProfile.html">Amazon
        /// Connect routing profile ARN</a>. User should have <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_SearchRoutingProfiles.html">SearchRoutingProfile</a>
        /// and <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_DescribeRoutingProfile.html">DescribeRoutingProfile</a>
        /// permissions when setting criteria to this value.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupingConfiguration_Criteria")]
        public System.String GroupingConfiguration_Criterion { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Custom
        /// <summary>
        /// <para>
        /// <para>The custom attributes in customer profile attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_Custom")]
        public System.Collections.Hashtable CustomerProfileAttributes_Custom { get; set; }
        #endregion
        
        #region Parameter DefaultAttributes_CustomAttribute
        /// <summary>
        /// <para>
        /// <para>The custom attributes that are used with the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomAttributes")]
        public System.Collections.Hashtable DefaultAttributes_CustomAttribute { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_EmailAddress
        /// <summary>
        /// <para>
        /// <para>The customer's email address, which has not been specified as a personal or business
        /// address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_EmailAddress")]
        public System.String CustomerProfileAttributes_EmailAddress { get; set; }
        #endregion
        
        #region Parameter AgentAttributes_FirstName
        /// <summary>
        /// <para>
        /// <para>The agent’s first name as entered in their Amazon Connect user account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_AgentAttributes_FirstName")]
        public System.String AgentAttributes_FirstName { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_FirstName
        /// <summary>
        /// <para>
        /// <para>The customer's first name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_FirstName")]
        public System.String CustomerProfileAttributes_FirstName { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Gender
        /// <summary>
        /// <para>
        /// <para>The customer's gender.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_Gender")]
        public System.String CustomerProfileAttributes_Gender { get; set; }
        #endregion
        
        #region Parameter Email_Header
        /// <summary>
        /// <para>
        /// <para>The email headers to include in email messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Email_Headers")]
        public Amazon.QConnect.Model.EmailHeader[] Email_Header { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_HomePhoneNumber
        /// <summary>
        /// <para>
        /// <para>The customer's mobile phone number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_HomePhoneNumber")]
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>The language code value for the language in which the quick response is written. The
        /// supported language codes include <c>de_DE</c>, <c>en_US</c>, <c>es_ES</c>, <c>fr_FR</c>,
        /// <c>id_ID</c>, <c>it_IT</c>, <c>ja_JP</c>, <c>ko_KR</c>, <c>pt_BR</c>, <c>zh_CN</c>,
        /// <c>zh_TW</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Language { get; set; }
        #endregion
        
        #region Parameter AgentAttributes_LastName
        /// <summary>
        /// <para>
        /// <para>The agent’s last name as entered in their Amazon Connect user account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_AgentAttributes_LastName")]
        public System.String AgentAttributes_LastName { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_LastName
        /// <summary>
        /// <para>
        /// <para>The customer's last name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_LastName")]
        public System.String CustomerProfileAttributes_LastName { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingAddress1
        /// <summary>
        /// <para>
        /// <para>The first line of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_MailingAddress1")]
        public System.String CustomerProfileAttributes_MailingAddress1 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingAddress2
        /// <summary>
        /// <para>
        /// <para>The second line of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_MailingAddress2")]
        public System.String CustomerProfileAttributes_MailingAddress2 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingAddress3
        /// <summary>
        /// <para>
        /// <para>The third line of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_MailingAddress3")]
        public System.String CustomerProfileAttributes_MailingAddress3 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingAddress4
        /// <summary>
        /// <para>
        /// <para>The fourth line of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_MailingAddress4")]
        public System.String CustomerProfileAttributes_MailingAddress4 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingCity
        /// <summary>
        /// <para>
        /// <para>The city of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_MailingCity")]
        public System.String CustomerProfileAttributes_MailingCity { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingCountry
        /// <summary>
        /// <para>
        /// <para>The country of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_MailingCountry")]
        public System.String CustomerProfileAttributes_MailingCountry { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingCounty
        /// <summary>
        /// <para>
        /// <para>The county of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_MailingCounty")]
        public System.String CustomerProfileAttributes_MailingCounty { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingPostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_MailingPostalCode")]
        public System.String CustomerProfileAttributes_MailingPostalCode { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingProvince
        /// <summary>
        /// <para>
        /// <para>The province of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_MailingProvince")]
        public System.String CustomerProfileAttributes_MailingProvince { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MailingState
        /// <summary>
        /// <para>
        /// <para>The state of a customer’s mailing address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_MailingState")]
        public System.String CustomerProfileAttributes_MailingState { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MiddleName
        /// <summary>
        /// <para>
        /// <para>The customer's middle name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_MiddleName")]
        public System.String CustomerProfileAttributes_MiddleName { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_MobilePhoneNumber
        /// <summary>
        /// <para>
        /// <para>The customer's mobile phone number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_MobilePhoneNumber")]
        public System.String CustomerProfileAttributes_MobilePhoneNumber { get; set; }
        #endregion
        
        #region Parameter SystemAttributes_Name
        /// <summary>
        /// <para>
        /// <para>The name of the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_SystemAttributes_Name")]
        public System.String SystemAttributes_Name { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the message template.</para>
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
        
        #region Parameter CustomerProfileAttributes_PartyType
        /// <summary>
        /// <para>
        /// <para>The customer's party type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_PartyType")]
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
        [Alias("DefaultAttributes_CustomerProfileAttributes_PhoneNumber")]
        public System.String CustomerProfileAttributes_PhoneNumber { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_PostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code of a customer address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_PostalCode")]
        public System.String CustomerProfileAttributes_PostalCode { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ProfileARN
        /// <summary>
        /// <para>
        /// <para>The ARN of a customer profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_ProfileARN")]
        public System.String CustomerProfileAttributes_ProfileARN { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ProfileId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of a customer profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_ProfileId")]
        public System.String CustomerProfileAttributes_ProfileId { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_Province
        /// <summary>
        /// <para>
        /// <para>The province in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_Province")]
        public System.String CustomerProfileAttributes_Province { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingAddress1
        /// <summary>
        /// <para>
        /// <para>The first line of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_ShippingAddress1")]
        public System.String CustomerProfileAttributes_ShippingAddress1 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingAddress2
        /// <summary>
        /// <para>
        /// <para>The second line of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_ShippingAddress2")]
        public System.String CustomerProfileAttributes_ShippingAddress2 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingAddress3
        /// <summary>
        /// <para>
        /// <para>The third line of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_ShippingAddress3")]
        public System.String CustomerProfileAttributes_ShippingAddress3 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingAddress4
        /// <summary>
        /// <para>
        /// <para>The fourth line of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_ShippingAddress4")]
        public System.String CustomerProfileAttributes_ShippingAddress4 { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingCity
        /// <summary>
        /// <para>
        /// <para>The city of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_ShippingCity")]
        public System.String CustomerProfileAttributes_ShippingCity { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingCountry
        /// <summary>
        /// <para>
        /// <para>The country of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_ShippingCountry")]
        public System.String CustomerProfileAttributes_ShippingCountry { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingCounty
        /// <summary>
        /// <para>
        /// <para>The county of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_ShippingCounty")]
        public System.String CustomerProfileAttributes_ShippingCounty { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingPostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_ShippingPostalCode")]
        public System.String CustomerProfileAttributes_ShippingPostalCode { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingProvince
        /// <summary>
        /// <para>
        /// <para>The province of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_ShippingProvince")]
        public System.String CustomerProfileAttributes_ShippingProvince { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_ShippingState
        /// <summary>
        /// <para>
        /// <para>The state of a customer’s shipping address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_ShippingState")]
        public System.String CustomerProfileAttributes_ShippingState { get; set; }
        #endregion
        
        #region Parameter CustomerProfileAttributes_State
        /// <summary>
        /// <para>
        /// <para>The state in which a customer lives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultAttributes_CustomerProfileAttributes_State")]
        public System.String CustomerProfileAttributes_State { get; set; }
        #endregion
        
        #region Parameter Email_Subject
        /// <summary>
        /// <para>
        /// <para>The subject line, or title, to use in email messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Email_Subject")]
        public System.String Email_Subject { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter GroupingConfiguration_Value
        /// <summary>
        /// <para>
        /// <para>The list of values that define different groups of Amazon Q in Connect users.</para><ul><li><para>When setting <c>criteria</c> to <c>RoutingProfileArn</c>, you need to provide a list
        /// of ARNs of <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_RoutingProfile.html">Amazon
        /// Connect routing profiles</a> as values of this parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupingConfiguration_Values")]
        public System.String[] GroupingConfiguration_Value { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="http://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.CreateMessageTemplateResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.CreateMessageTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageTemplate";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QCMessageTemplate (CreateMessageTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.CreateMessageTemplateResponse, NewQCMessageTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelSubtype = this.ChannelSubtype;
            #if MODULAR
            if (this.ChannelSubtype == null && ParameterWasBound(nameof(this.ChannelSubtype)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelSubtype which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Html_Content = this.Html_Content;
            context.Content_Email_Body_PlainText_Content = this.Content_Email_Body_PlainText_Content;
            if (this.Email_Header != null)
            {
                context.Email_Header = new List<Amazon.QConnect.Model.EmailHeader>(this.Email_Header);
            }
            context.Email_Subject = this.Email_Subject;
            context.Content_Sms_Body_PlainText_Content = this.Content_Sms_Body_PlainText_Content;
            context.AgentAttributes_FirstName = this.AgentAttributes_FirstName;
            context.AgentAttributes_LastName = this.AgentAttributes_LastName;
            if (this.DefaultAttributes_CustomAttribute != null)
            {
                context.DefaultAttributes_CustomAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DefaultAttributes_CustomAttribute.Keys)
                {
                    context.DefaultAttributes_CustomAttribute.Add((String)hashKey, (System.String)(this.DefaultAttributes_CustomAttribute[hashKey]));
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
            context.Description = this.Description;
            context.GroupingConfiguration_Criterion = this.GroupingConfiguration_Criterion;
            if (this.GroupingConfiguration_Value != null)
            {
                context.GroupingConfiguration_Value = new List<System.String>(this.GroupingConfiguration_Value);
            }
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Language = this.Language;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.QConnect.Model.CreateMessageTemplateRequest();
            
            if (cmdletContext.ChannelSubtype != null)
            {
                request.ChannelSubtype = cmdletContext.ChannelSubtype;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Content
            var requestContentIsNull = true;
            request.Content = new Amazon.QConnect.Model.MessageTemplateContentProvider();
            Amazon.QConnect.Model.SMSMessageTemplateContent requestContent_content_Sms = null;
            
             // populate Sms
            var requestContent_content_SmsIsNull = true;
            requestContent_content_Sms = new Amazon.QConnect.Model.SMSMessageTemplateContent();
            Amazon.QConnect.Model.SMSMessageTemplateContentBody requestContent_content_Sms_content_Sms_Body = null;
            
             // populate Body
            var requestContent_content_Sms_content_Sms_BodyIsNull = true;
            requestContent_content_Sms_content_Sms_Body = new Amazon.QConnect.Model.SMSMessageTemplateContentBody();
            Amazon.QConnect.Model.MessageTemplateBodyContentProvider requestContent_content_Sms_content_Sms_Body_content_Sms_Body_PlainText = null;
            
             // populate PlainText
            var requestContent_content_Sms_content_Sms_Body_content_Sms_Body_PlainTextIsNull = true;
            requestContent_content_Sms_content_Sms_Body_content_Sms_Body_PlainText = new Amazon.QConnect.Model.MessageTemplateBodyContentProvider();
            System.String requestContent_content_Sms_content_Sms_Body_content_Sms_Body_PlainText_content_Sms_Body_PlainText_Content = null;
            if (cmdletContext.Content_Sms_Body_PlainText_Content != null)
            {
                requestContent_content_Sms_content_Sms_Body_content_Sms_Body_PlainText_content_Sms_Body_PlainText_Content = cmdletContext.Content_Sms_Body_PlainText_Content;
            }
            if (requestContent_content_Sms_content_Sms_Body_content_Sms_Body_PlainText_content_Sms_Body_PlainText_Content != null)
            {
                requestContent_content_Sms_content_Sms_Body_content_Sms_Body_PlainText.Content = requestContent_content_Sms_content_Sms_Body_content_Sms_Body_PlainText_content_Sms_Body_PlainText_Content;
                requestContent_content_Sms_content_Sms_Body_content_Sms_Body_PlainTextIsNull = false;
            }
             // determine if requestContent_content_Sms_content_Sms_Body_content_Sms_Body_PlainText should be set to null
            if (requestContent_content_Sms_content_Sms_Body_content_Sms_Body_PlainTextIsNull)
            {
                requestContent_content_Sms_content_Sms_Body_content_Sms_Body_PlainText = null;
            }
            if (requestContent_content_Sms_content_Sms_Body_content_Sms_Body_PlainText != null)
            {
                requestContent_content_Sms_content_Sms_Body.PlainText = requestContent_content_Sms_content_Sms_Body_content_Sms_Body_PlainText;
                requestContent_content_Sms_content_Sms_BodyIsNull = false;
            }
             // determine if requestContent_content_Sms_content_Sms_Body should be set to null
            if (requestContent_content_Sms_content_Sms_BodyIsNull)
            {
                requestContent_content_Sms_content_Sms_Body = null;
            }
            if (requestContent_content_Sms_content_Sms_Body != null)
            {
                requestContent_content_Sms.Body = requestContent_content_Sms_content_Sms_Body;
                requestContent_content_SmsIsNull = false;
            }
             // determine if requestContent_content_Sms should be set to null
            if (requestContent_content_SmsIsNull)
            {
                requestContent_content_Sms = null;
            }
            if (requestContent_content_Sms != null)
            {
                request.Content.Sms = requestContent_content_Sms;
                requestContentIsNull = false;
            }
            Amazon.QConnect.Model.EmailMessageTemplateContent requestContent_content_Email = null;
            
             // populate Email
            var requestContent_content_EmailIsNull = true;
            requestContent_content_Email = new Amazon.QConnect.Model.EmailMessageTemplateContent();
            List<Amazon.QConnect.Model.EmailHeader> requestContent_content_Email_email_Header = null;
            if (cmdletContext.Email_Header != null)
            {
                requestContent_content_Email_email_Header = cmdletContext.Email_Header;
            }
            if (requestContent_content_Email_email_Header != null)
            {
                requestContent_content_Email.Headers = requestContent_content_Email_email_Header;
                requestContent_content_EmailIsNull = false;
            }
            System.String requestContent_content_Email_email_Subject = null;
            if (cmdletContext.Email_Subject != null)
            {
                requestContent_content_Email_email_Subject = cmdletContext.Email_Subject;
            }
            if (requestContent_content_Email_email_Subject != null)
            {
                requestContent_content_Email.Subject = requestContent_content_Email_email_Subject;
                requestContent_content_EmailIsNull = false;
            }
            Amazon.QConnect.Model.EmailMessageTemplateContentBody requestContent_content_Email_content_Email_Body = null;
            
             // populate Body
            var requestContent_content_Email_content_Email_BodyIsNull = true;
            requestContent_content_Email_content_Email_Body = new Amazon.QConnect.Model.EmailMessageTemplateContentBody();
            Amazon.QConnect.Model.MessageTemplateBodyContentProvider requestContent_content_Email_content_Email_Body_content_Email_Body_Html = null;
            
             // populate Html
            var requestContent_content_Email_content_Email_Body_content_Email_Body_HtmlIsNull = true;
            requestContent_content_Email_content_Email_Body_content_Email_Body_Html = new Amazon.QConnect.Model.MessageTemplateBodyContentProvider();
            System.String requestContent_content_Email_content_Email_Body_content_Email_Body_Html_html_Content = null;
            if (cmdletContext.Html_Content != null)
            {
                requestContent_content_Email_content_Email_Body_content_Email_Body_Html_html_Content = cmdletContext.Html_Content;
            }
            if (requestContent_content_Email_content_Email_Body_content_Email_Body_Html_html_Content != null)
            {
                requestContent_content_Email_content_Email_Body_content_Email_Body_Html.Content = requestContent_content_Email_content_Email_Body_content_Email_Body_Html_html_Content;
                requestContent_content_Email_content_Email_Body_content_Email_Body_HtmlIsNull = false;
            }
             // determine if requestContent_content_Email_content_Email_Body_content_Email_Body_Html should be set to null
            if (requestContent_content_Email_content_Email_Body_content_Email_Body_HtmlIsNull)
            {
                requestContent_content_Email_content_Email_Body_content_Email_Body_Html = null;
            }
            if (requestContent_content_Email_content_Email_Body_content_Email_Body_Html != null)
            {
                requestContent_content_Email_content_Email_Body.Html = requestContent_content_Email_content_Email_Body_content_Email_Body_Html;
                requestContent_content_Email_content_Email_BodyIsNull = false;
            }
            Amazon.QConnect.Model.MessageTemplateBodyContentProvider requestContent_content_Email_content_Email_Body_content_Email_Body_PlainText = null;
            
             // populate PlainText
            var requestContent_content_Email_content_Email_Body_content_Email_Body_PlainTextIsNull = true;
            requestContent_content_Email_content_Email_Body_content_Email_Body_PlainText = new Amazon.QConnect.Model.MessageTemplateBodyContentProvider();
            System.String requestContent_content_Email_content_Email_Body_content_Email_Body_PlainText_content_Email_Body_PlainText_Content = null;
            if (cmdletContext.Content_Email_Body_PlainText_Content != null)
            {
                requestContent_content_Email_content_Email_Body_content_Email_Body_PlainText_content_Email_Body_PlainText_Content = cmdletContext.Content_Email_Body_PlainText_Content;
            }
            if (requestContent_content_Email_content_Email_Body_content_Email_Body_PlainText_content_Email_Body_PlainText_Content != null)
            {
                requestContent_content_Email_content_Email_Body_content_Email_Body_PlainText.Content = requestContent_content_Email_content_Email_Body_content_Email_Body_PlainText_content_Email_Body_PlainText_Content;
                requestContent_content_Email_content_Email_Body_content_Email_Body_PlainTextIsNull = false;
            }
             // determine if requestContent_content_Email_content_Email_Body_content_Email_Body_PlainText should be set to null
            if (requestContent_content_Email_content_Email_Body_content_Email_Body_PlainTextIsNull)
            {
                requestContent_content_Email_content_Email_Body_content_Email_Body_PlainText = null;
            }
            if (requestContent_content_Email_content_Email_Body_content_Email_Body_PlainText != null)
            {
                requestContent_content_Email_content_Email_Body.PlainText = requestContent_content_Email_content_Email_Body_content_Email_Body_PlainText;
                requestContent_content_Email_content_Email_BodyIsNull = false;
            }
             // determine if requestContent_content_Email_content_Email_Body should be set to null
            if (requestContent_content_Email_content_Email_BodyIsNull)
            {
                requestContent_content_Email_content_Email_Body = null;
            }
            if (requestContent_content_Email_content_Email_Body != null)
            {
                requestContent_content_Email.Body = requestContent_content_Email_content_Email_Body;
                requestContent_content_EmailIsNull = false;
            }
             // determine if requestContent_content_Email should be set to null
            if (requestContent_content_EmailIsNull)
            {
                requestContent_content_Email = null;
            }
            if (requestContent_content_Email != null)
            {
                request.Content.Email = requestContent_content_Email;
                requestContentIsNull = false;
            }
             // determine if request.Content should be set to null
            if (requestContentIsNull)
            {
                request.Content = null;
            }
            
             // populate DefaultAttributes
            var requestDefaultAttributesIsNull = true;
            request.DefaultAttributes = new Amazon.QConnect.Model.MessageTemplateAttributes();
            Dictionary<System.String, System.String> requestDefaultAttributes_defaultAttributes_CustomAttribute = null;
            if (cmdletContext.DefaultAttributes_CustomAttribute != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomAttribute = cmdletContext.DefaultAttributes_CustomAttribute;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomAttribute != null)
            {
                request.DefaultAttributes.CustomAttributes = requestDefaultAttributes_defaultAttributes_CustomAttribute;
                requestDefaultAttributesIsNull = false;
            }
            Amazon.QConnect.Model.AgentAttributes requestDefaultAttributes_defaultAttributes_AgentAttributes = null;
            
             // populate AgentAttributes
            var requestDefaultAttributes_defaultAttributes_AgentAttributesIsNull = true;
            requestDefaultAttributes_defaultAttributes_AgentAttributes = new Amazon.QConnect.Model.AgentAttributes();
            System.String requestDefaultAttributes_defaultAttributes_AgentAttributes_agentAttributes_FirstName = null;
            if (cmdletContext.AgentAttributes_FirstName != null)
            {
                requestDefaultAttributes_defaultAttributes_AgentAttributes_agentAttributes_FirstName = cmdletContext.AgentAttributes_FirstName;
            }
            if (requestDefaultAttributes_defaultAttributes_AgentAttributes_agentAttributes_FirstName != null)
            {
                requestDefaultAttributes_defaultAttributes_AgentAttributes.FirstName = requestDefaultAttributes_defaultAttributes_AgentAttributes_agentAttributes_FirstName;
                requestDefaultAttributes_defaultAttributes_AgentAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_AgentAttributes_agentAttributes_LastName = null;
            if (cmdletContext.AgentAttributes_LastName != null)
            {
                requestDefaultAttributes_defaultAttributes_AgentAttributes_agentAttributes_LastName = cmdletContext.AgentAttributes_LastName;
            }
            if (requestDefaultAttributes_defaultAttributes_AgentAttributes_agentAttributes_LastName != null)
            {
                requestDefaultAttributes_defaultAttributes_AgentAttributes.LastName = requestDefaultAttributes_defaultAttributes_AgentAttributes_agentAttributes_LastName;
                requestDefaultAttributes_defaultAttributes_AgentAttributesIsNull = false;
            }
             // determine if requestDefaultAttributes_defaultAttributes_AgentAttributes should be set to null
            if (requestDefaultAttributes_defaultAttributes_AgentAttributesIsNull)
            {
                requestDefaultAttributes_defaultAttributes_AgentAttributes = null;
            }
            if (requestDefaultAttributes_defaultAttributes_AgentAttributes != null)
            {
                request.DefaultAttributes.AgentAttributes = requestDefaultAttributes_defaultAttributes_AgentAttributes;
                requestDefaultAttributesIsNull = false;
            }
            Amazon.QConnect.Model.SystemAttributes requestDefaultAttributes_defaultAttributes_SystemAttributes = null;
            
             // populate SystemAttributes
            var requestDefaultAttributes_defaultAttributes_SystemAttributesIsNull = true;
            requestDefaultAttributes_defaultAttributes_SystemAttributes = new Amazon.QConnect.Model.SystemAttributes();
            System.String requestDefaultAttributes_defaultAttributes_SystemAttributes_systemAttributes_Name = null;
            if (cmdletContext.SystemAttributes_Name != null)
            {
                requestDefaultAttributes_defaultAttributes_SystemAttributes_systemAttributes_Name = cmdletContext.SystemAttributes_Name;
            }
            if (requestDefaultAttributes_defaultAttributes_SystemAttributes_systemAttributes_Name != null)
            {
                requestDefaultAttributes_defaultAttributes_SystemAttributes.Name = requestDefaultAttributes_defaultAttributes_SystemAttributes_systemAttributes_Name;
                requestDefaultAttributes_defaultAttributes_SystemAttributesIsNull = false;
            }
            Amazon.QConnect.Model.SystemEndpointAttributes requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_CustomerEndpoint = null;
            
             // populate CustomerEndpoint
            var requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_CustomerEndpointIsNull = true;
            requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_CustomerEndpoint = new Amazon.QConnect.Model.SystemEndpointAttributes();
            System.String requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_CustomerEndpoint_customerEndpoint_Address = null;
            if (cmdletContext.CustomerEndpoint_Address != null)
            {
                requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_CustomerEndpoint_customerEndpoint_Address = cmdletContext.CustomerEndpoint_Address;
            }
            if (requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_CustomerEndpoint_customerEndpoint_Address != null)
            {
                requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_CustomerEndpoint.Address = requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_CustomerEndpoint_customerEndpoint_Address;
                requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_CustomerEndpointIsNull = false;
            }
             // determine if requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_CustomerEndpoint should be set to null
            if (requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_CustomerEndpointIsNull)
            {
                requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_CustomerEndpoint = null;
            }
            if (requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_CustomerEndpoint != null)
            {
                requestDefaultAttributes_defaultAttributes_SystemAttributes.CustomerEndpoint = requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_CustomerEndpoint;
                requestDefaultAttributes_defaultAttributes_SystemAttributesIsNull = false;
            }
            Amazon.QConnect.Model.SystemEndpointAttributes requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_SystemEndpoint = null;
            
             // populate SystemEndpoint
            var requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_SystemEndpointIsNull = true;
            requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_SystemEndpoint = new Amazon.QConnect.Model.SystemEndpointAttributes();
            System.String requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_SystemEndpoint_systemEndpoint_Address = null;
            if (cmdletContext.SystemEndpoint_Address != null)
            {
                requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_SystemEndpoint_systemEndpoint_Address = cmdletContext.SystemEndpoint_Address;
            }
            if (requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_SystemEndpoint_systemEndpoint_Address != null)
            {
                requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_SystemEndpoint.Address = requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_SystemEndpoint_systemEndpoint_Address;
                requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_SystemEndpointIsNull = false;
            }
             // determine if requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_SystemEndpoint should be set to null
            if (requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_SystemEndpointIsNull)
            {
                requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_SystemEndpoint = null;
            }
            if (requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_SystemEndpoint != null)
            {
                requestDefaultAttributes_defaultAttributes_SystemAttributes.SystemEndpoint = requestDefaultAttributes_defaultAttributes_SystemAttributes_defaultAttributes_SystemAttributes_SystemEndpoint;
                requestDefaultAttributes_defaultAttributes_SystemAttributesIsNull = false;
            }
             // determine if requestDefaultAttributes_defaultAttributes_SystemAttributes should be set to null
            if (requestDefaultAttributes_defaultAttributes_SystemAttributesIsNull)
            {
                requestDefaultAttributes_defaultAttributes_SystemAttributes = null;
            }
            if (requestDefaultAttributes_defaultAttributes_SystemAttributes != null)
            {
                request.DefaultAttributes.SystemAttributes = requestDefaultAttributes_defaultAttributes_SystemAttributes;
                requestDefaultAttributesIsNull = false;
            }
            Amazon.QConnect.Model.CustomerProfileAttributes requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes = null;
            
             // populate CustomerProfileAttributes
            var requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = true;
            requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes = new Amazon.QConnect.Model.CustomerProfileAttributes();
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_AccountNumber = null;
            if (cmdletContext.CustomerProfileAttributes_AccountNumber != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_AccountNumber = cmdletContext.CustomerProfileAttributes_AccountNumber;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_AccountNumber != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.AccountNumber = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_AccountNumber;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_AdditionalInformation = null;
            if (cmdletContext.CustomerProfileAttributes_AdditionalInformation != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_AdditionalInformation = cmdletContext.CustomerProfileAttributes_AdditionalInformation;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_AdditionalInformation != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.AdditionalInformation = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_AdditionalInformation;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address1 = null;
            if (cmdletContext.CustomerProfileAttributes_Address1 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address1 = cmdletContext.CustomerProfileAttributes_Address1;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address1 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.Address1 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address1;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address2 = null;
            if (cmdletContext.CustomerProfileAttributes_Address2 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address2 = cmdletContext.CustomerProfileAttributes_Address2;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address2 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.Address2 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address2;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address3 = null;
            if (cmdletContext.CustomerProfileAttributes_Address3 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address3 = cmdletContext.CustomerProfileAttributes_Address3;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address3 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.Address3 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address3;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address4 = null;
            if (cmdletContext.CustomerProfileAttributes_Address4 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address4 = cmdletContext.CustomerProfileAttributes_Address4;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address4 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.Address4 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Address4;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress1 = null;
            if (cmdletContext.CustomerProfileAttributes_BillingAddress1 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress1 = cmdletContext.CustomerProfileAttributes_BillingAddress1;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress1 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.BillingAddress1 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress1;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress2 = null;
            if (cmdletContext.CustomerProfileAttributes_BillingAddress2 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress2 = cmdletContext.CustomerProfileAttributes_BillingAddress2;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress2 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.BillingAddress2 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress2;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress3 = null;
            if (cmdletContext.CustomerProfileAttributes_BillingAddress3 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress3 = cmdletContext.CustomerProfileAttributes_BillingAddress3;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress3 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.BillingAddress3 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress3;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress4 = null;
            if (cmdletContext.CustomerProfileAttributes_BillingAddress4 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress4 = cmdletContext.CustomerProfileAttributes_BillingAddress4;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress4 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.BillingAddress4 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingAddress4;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingCity = null;
            if (cmdletContext.CustomerProfileAttributes_BillingCity != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingCity = cmdletContext.CustomerProfileAttributes_BillingCity;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingCity != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.BillingCity = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingCity;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingCountry = null;
            if (cmdletContext.CustomerProfileAttributes_BillingCountry != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingCountry = cmdletContext.CustomerProfileAttributes_BillingCountry;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingCountry != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.BillingCountry = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingCountry;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingCounty = null;
            if (cmdletContext.CustomerProfileAttributes_BillingCounty != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingCounty = cmdletContext.CustomerProfileAttributes_BillingCounty;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingCounty != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.BillingCounty = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingCounty;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingPostalCode = null;
            if (cmdletContext.CustomerProfileAttributes_BillingPostalCode != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingPostalCode = cmdletContext.CustomerProfileAttributes_BillingPostalCode;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingPostalCode != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.BillingPostalCode = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingPostalCode;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingProvince = null;
            if (cmdletContext.CustomerProfileAttributes_BillingProvince != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingProvince = cmdletContext.CustomerProfileAttributes_BillingProvince;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingProvince != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.BillingProvince = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingProvince;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingState = null;
            if (cmdletContext.CustomerProfileAttributes_BillingState != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingState = cmdletContext.CustomerProfileAttributes_BillingState;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingState != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.BillingState = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BillingState;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BirthDate = null;
            if (cmdletContext.CustomerProfileAttributes_BirthDate != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BirthDate = cmdletContext.CustomerProfileAttributes_BirthDate;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BirthDate != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.BirthDate = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BirthDate;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BusinessEmailAddress = null;
            if (cmdletContext.CustomerProfileAttributes_BusinessEmailAddress != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BusinessEmailAddress = cmdletContext.CustomerProfileAttributes_BusinessEmailAddress;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BusinessEmailAddress != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.BusinessEmailAddress = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BusinessEmailAddress;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BusinessName = null;
            if (cmdletContext.CustomerProfileAttributes_BusinessName != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BusinessName = cmdletContext.CustomerProfileAttributes_BusinessName;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BusinessName != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.BusinessName = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BusinessName;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BusinessPhoneNumber = null;
            if (cmdletContext.CustomerProfileAttributes_BusinessPhoneNumber != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BusinessPhoneNumber = cmdletContext.CustomerProfileAttributes_BusinessPhoneNumber;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BusinessPhoneNumber != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.BusinessPhoneNumber = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_BusinessPhoneNumber;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_City = null;
            if (cmdletContext.CustomerProfileAttributes_City != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_City = cmdletContext.CustomerProfileAttributes_City;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_City != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.City = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_City;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Country = null;
            if (cmdletContext.CustomerProfileAttributes_Country != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Country = cmdletContext.CustomerProfileAttributes_Country;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Country != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.Country = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Country;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_County = null;
            if (cmdletContext.CustomerProfileAttributes_County != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_County = cmdletContext.CustomerProfileAttributes_County;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_County != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.County = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_County;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            Dictionary<System.String, System.String> requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Custom = null;
            if (cmdletContext.CustomerProfileAttributes_Custom != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Custom = cmdletContext.CustomerProfileAttributes_Custom;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Custom != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.Custom = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Custom;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_EmailAddress = null;
            if (cmdletContext.CustomerProfileAttributes_EmailAddress != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_EmailAddress = cmdletContext.CustomerProfileAttributes_EmailAddress;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_EmailAddress != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.EmailAddress = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_EmailAddress;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_FirstName = null;
            if (cmdletContext.CustomerProfileAttributes_FirstName != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_FirstName = cmdletContext.CustomerProfileAttributes_FirstName;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_FirstName != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.FirstName = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_FirstName;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Gender = null;
            if (cmdletContext.CustomerProfileAttributes_Gender != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Gender = cmdletContext.CustomerProfileAttributes_Gender;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Gender != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.Gender = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Gender;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_HomePhoneNumber = null;
            if (cmdletContext.CustomerProfileAttributes_HomePhoneNumber != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_HomePhoneNumber = cmdletContext.CustomerProfileAttributes_HomePhoneNumber;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_HomePhoneNumber != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.HomePhoneNumber = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_HomePhoneNumber;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_LastName = null;
            if (cmdletContext.CustomerProfileAttributes_LastName != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_LastName = cmdletContext.CustomerProfileAttributes_LastName;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_LastName != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.LastName = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_LastName;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress1 = null;
            if (cmdletContext.CustomerProfileAttributes_MailingAddress1 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress1 = cmdletContext.CustomerProfileAttributes_MailingAddress1;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress1 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.MailingAddress1 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress1;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress2 = null;
            if (cmdletContext.CustomerProfileAttributes_MailingAddress2 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress2 = cmdletContext.CustomerProfileAttributes_MailingAddress2;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress2 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.MailingAddress2 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress2;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress3 = null;
            if (cmdletContext.CustomerProfileAttributes_MailingAddress3 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress3 = cmdletContext.CustomerProfileAttributes_MailingAddress3;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress3 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.MailingAddress3 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress3;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress4 = null;
            if (cmdletContext.CustomerProfileAttributes_MailingAddress4 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress4 = cmdletContext.CustomerProfileAttributes_MailingAddress4;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress4 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.MailingAddress4 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingAddress4;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingCity = null;
            if (cmdletContext.CustomerProfileAttributes_MailingCity != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingCity = cmdletContext.CustomerProfileAttributes_MailingCity;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingCity != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.MailingCity = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingCity;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingCountry = null;
            if (cmdletContext.CustomerProfileAttributes_MailingCountry != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingCountry = cmdletContext.CustomerProfileAttributes_MailingCountry;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingCountry != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.MailingCountry = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingCountry;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingCounty = null;
            if (cmdletContext.CustomerProfileAttributes_MailingCounty != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingCounty = cmdletContext.CustomerProfileAttributes_MailingCounty;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingCounty != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.MailingCounty = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingCounty;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingPostalCode = null;
            if (cmdletContext.CustomerProfileAttributes_MailingPostalCode != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingPostalCode = cmdletContext.CustomerProfileAttributes_MailingPostalCode;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingPostalCode != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.MailingPostalCode = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingPostalCode;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingProvince = null;
            if (cmdletContext.CustomerProfileAttributes_MailingProvince != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingProvince = cmdletContext.CustomerProfileAttributes_MailingProvince;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingProvince != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.MailingProvince = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingProvince;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingState = null;
            if (cmdletContext.CustomerProfileAttributes_MailingState != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingState = cmdletContext.CustomerProfileAttributes_MailingState;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingState != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.MailingState = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MailingState;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MiddleName = null;
            if (cmdletContext.CustomerProfileAttributes_MiddleName != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MiddleName = cmdletContext.CustomerProfileAttributes_MiddleName;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MiddleName != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.MiddleName = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MiddleName;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MobilePhoneNumber = null;
            if (cmdletContext.CustomerProfileAttributes_MobilePhoneNumber != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MobilePhoneNumber = cmdletContext.CustomerProfileAttributes_MobilePhoneNumber;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MobilePhoneNumber != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.MobilePhoneNumber = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_MobilePhoneNumber;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_PartyType = null;
            if (cmdletContext.CustomerProfileAttributes_PartyType != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_PartyType = cmdletContext.CustomerProfileAttributes_PartyType;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_PartyType != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.PartyType = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_PartyType;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_PhoneNumber = null;
            if (cmdletContext.CustomerProfileAttributes_PhoneNumber != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_PhoneNumber = cmdletContext.CustomerProfileAttributes_PhoneNumber;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_PhoneNumber != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.PhoneNumber = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_PhoneNumber;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_PostalCode = null;
            if (cmdletContext.CustomerProfileAttributes_PostalCode != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_PostalCode = cmdletContext.CustomerProfileAttributes_PostalCode;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_PostalCode != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.PostalCode = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_PostalCode;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ProfileARN = null;
            if (cmdletContext.CustomerProfileAttributes_ProfileARN != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ProfileARN = cmdletContext.CustomerProfileAttributes_ProfileARN;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ProfileARN != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.ProfileARN = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ProfileARN;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ProfileId = null;
            if (cmdletContext.CustomerProfileAttributes_ProfileId != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ProfileId = cmdletContext.CustomerProfileAttributes_ProfileId;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ProfileId != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.ProfileId = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ProfileId;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Province = null;
            if (cmdletContext.CustomerProfileAttributes_Province != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Province = cmdletContext.CustomerProfileAttributes_Province;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Province != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.Province = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_Province;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress1 = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingAddress1 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress1 = cmdletContext.CustomerProfileAttributes_ShippingAddress1;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress1 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.ShippingAddress1 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress1;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress2 = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingAddress2 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress2 = cmdletContext.CustomerProfileAttributes_ShippingAddress2;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress2 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.ShippingAddress2 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress2;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress3 = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingAddress3 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress3 = cmdletContext.CustomerProfileAttributes_ShippingAddress3;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress3 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.ShippingAddress3 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress3;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress4 = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingAddress4 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress4 = cmdletContext.CustomerProfileAttributes_ShippingAddress4;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress4 != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.ShippingAddress4 = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingAddress4;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCity = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingCity != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCity = cmdletContext.CustomerProfileAttributes_ShippingCity;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCity != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.ShippingCity = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCity;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCountry = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingCountry != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCountry = cmdletContext.CustomerProfileAttributes_ShippingCountry;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCountry != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.ShippingCountry = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCountry;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCounty = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingCounty != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCounty = cmdletContext.CustomerProfileAttributes_ShippingCounty;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCounty != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.ShippingCounty = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingCounty;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingPostalCode = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingPostalCode != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingPostalCode = cmdletContext.CustomerProfileAttributes_ShippingPostalCode;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingPostalCode != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.ShippingPostalCode = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingPostalCode;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingProvince = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingProvince != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingProvince = cmdletContext.CustomerProfileAttributes_ShippingProvince;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingProvince != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.ShippingProvince = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingProvince;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingState = null;
            if (cmdletContext.CustomerProfileAttributes_ShippingState != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingState = cmdletContext.CustomerProfileAttributes_ShippingState;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingState != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.ShippingState = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_ShippingState;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
            System.String requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_State = null;
            if (cmdletContext.CustomerProfileAttributes_State != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_State = cmdletContext.CustomerProfileAttributes_State;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_State != null)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes.State = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes_customerProfileAttributes_State;
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull = false;
            }
             // determine if requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes should be set to null
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributesIsNull)
            {
                requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes = null;
            }
            if (requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes != null)
            {
                request.DefaultAttributes.CustomerProfileAttributes = requestDefaultAttributes_defaultAttributes_CustomerProfileAttributes;
                requestDefaultAttributesIsNull = false;
            }
             // determine if request.DefaultAttributes should be set to null
            if (requestDefaultAttributesIsNull)
            {
                request.DefaultAttributes = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate GroupingConfiguration
            var requestGroupingConfigurationIsNull = true;
            request.GroupingConfiguration = new Amazon.QConnect.Model.GroupingConfiguration();
            System.String requestGroupingConfiguration_groupingConfiguration_Criterion = null;
            if (cmdletContext.GroupingConfiguration_Criterion != null)
            {
                requestGroupingConfiguration_groupingConfiguration_Criterion = cmdletContext.GroupingConfiguration_Criterion;
            }
            if (requestGroupingConfiguration_groupingConfiguration_Criterion != null)
            {
                request.GroupingConfiguration.Criteria = requestGroupingConfiguration_groupingConfiguration_Criterion;
                requestGroupingConfigurationIsNull = false;
            }
            List<System.String> requestGroupingConfiguration_groupingConfiguration_Value = null;
            if (cmdletContext.GroupingConfiguration_Value != null)
            {
                requestGroupingConfiguration_groupingConfiguration_Value = cmdletContext.GroupingConfiguration_Value;
            }
            if (requestGroupingConfiguration_groupingConfiguration_Value != null)
            {
                request.GroupingConfiguration.Values = requestGroupingConfiguration_groupingConfiguration_Value;
                requestGroupingConfigurationIsNull = false;
            }
             // determine if request.GroupingConfiguration should be set to null
            if (requestGroupingConfigurationIsNull)
            {
                request.GroupingConfiguration = null;
            }
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
            }
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.QConnect.Model.CreateMessageTemplateResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.CreateMessageTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "CreateMessageTemplate");
            try
            {
                return client.CreateMessageTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.QConnect.ChannelSubtype ChannelSubtype { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Html_Content { get; set; }
            public System.String Content_Email_Body_PlainText_Content { get; set; }
            public List<Amazon.QConnect.Model.EmailHeader> Email_Header { get; set; }
            public System.String Email_Subject { get; set; }
            public System.String Content_Sms_Body_PlainText_Content { get; set; }
            public System.String AgentAttributes_FirstName { get; set; }
            public System.String AgentAttributes_LastName { get; set; }
            public Dictionary<System.String, System.String> DefaultAttributes_CustomAttribute { get; set; }
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
            public System.String Description { get; set; }
            public System.String GroupingConfiguration_Criterion { get; set; }
            public List<System.String> GroupingConfiguration_Value { get; set; }
            public System.String KnowledgeBaseId { get; set; }
            public System.String Language { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.QConnect.Model.CreateMessageTemplateResponse, NewQCMessageTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageTemplate;
        }
        
    }
}
