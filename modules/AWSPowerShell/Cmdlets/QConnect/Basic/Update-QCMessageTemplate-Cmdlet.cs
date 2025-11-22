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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Updates the Amazon Q in Connect message template. Partial update is supported. If
    /// any field is not supplied, it will remain unchanged for the message template that
    /// is referenced by the <c>$LATEST</c> qualifier. Any modification will only apply to
    /// the message template that is referenced by the <c>$LATEST</c> qualifier. The fields
    /// for all available versions will remain unchanged.
    /// </summary>
    [Cmdlet("Update", "QCMessageTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.MessageTemplateData")]
    [AWSCmdlet("Calls the Amazon Q Connect UpdateMessageTemplate API operation.", Operation = new[] {"UpdateMessageTemplate"}, SelectReturnType = typeof(Amazon.QConnect.Model.UpdateMessageTemplateResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.MessageTemplateData or Amazon.QConnect.Model.UpdateMessageTemplateResponse",
        "This cmdlet returns an Amazon.QConnect.Model.MessageTemplateData object.",
        "The service call response (type Amazon.QConnect.Model.UpdateMessageTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateQCMessageTemplateCmdlet : AmazonQConnectClientCmdlet, IExecutor
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
        [Alias("DefaultAttributes_CustomerProfileAttributes_AccountNumber")]
        public System.String CustomerProfileAttributes_AccountNumber { get; set; }
        #endregion
        
        #region Parameter Adm_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if a recipient taps a push notification that is based on the message
        /// template. Valid values are:</para><ul><li><para><c>OPEN_APP</c> - Your app opens or it becomes the foreground app if it was sent
        /// to the background. This is the default action.</para></li><li><para><c>DEEP_LINK</c> - Your app opens and displays a designated user interface in the
        /// app. This action uses the deep-linking features of the Android platform.</para></li><li><para><c>URL</c> - The default mobile browser on the recipient's device opens and loads
        /// the web page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Adm_Action")]
        [AWSConstantClassSource("Amazon.QConnect.PushMessageAction")]
        public Amazon.QConnect.PushMessageAction Adm_Action { get; set; }
        #endregion
        
        #region Parameter Apns_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if a recipient taps a push notification that is based on the message
        /// template. Valid values are:</para><ul><li><para><c>OPEN_APP</c> - Your app opens or it becomes the foreground app if it was sent
        /// to the background. This is the default action.</para></li><li><para><c>DEEP_LINK</c> - Your app opens and displays a designated user interface in the
        /// app. This action uses the deep-linking features of the iOS platform.</para></li><li><para><c>URL</c> - The default mobile browser on the recipient's device opens and loads
        /// the web page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Apns_Action")]
        [AWSConstantClassSource("Amazon.QConnect.PushMessageAction")]
        public Amazon.QConnect.PushMessageAction Apns_Action { get; set; }
        #endregion
        
        #region Parameter Baidu_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if a recipient taps a push notification that is based on the message
        /// template. Valid values are:</para><ul><li><para><c>OPEN_APP</c> - Your app opens or it becomes the foreground app if it was sent
        /// to the background. This is the default action.</para></li><li><para><c>DEEP_LINK</c> - Your app opens and displays a designated user interface in the
        /// app. This action uses the deep-linking features of the Android platform.</para></li><li><para><c>URL</c> - The default mobile browser on the recipient's device opens and loads
        /// the web page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Baidu_Action")]
        [AWSConstantClassSource("Amazon.QConnect.PushMessageAction")]
        public Amazon.QConnect.PushMessageAction Baidu_Action { get; set; }
        #endregion
        
        #region Parameter Fcm_Action
        /// <summary>
        /// <para>
        /// <para>The action to occur if a recipient taps a push notification that is based on the message
        /// template. Valid values are:</para><ul><li><para><c>OPEN_APP</c> - Your app opens or it becomes the foreground app if it was sent
        /// to the background. This is the default action.</para></li><li><para><c>DEEP_LINK</c> - Your app opens and displays a designated user interface in the
        /// app. This action uses the deep-linking features of the Android platform.</para></li><li><para><c>URL</c> - The default mobile browser on the recipient's device opens and loads
        /// the web page at a URL that you specify.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Fcm_Action")]
        [AWSConstantClassSource("Amazon.QConnect.PushMessageAction")]
        public Amazon.QConnect.PushMessageAction Fcm_Action { get; set; }
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
        
        #region Parameter WhatsApp_BusinessAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the End User Messaging WhatsApp Business Account to associate with this
        /// template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_WhatsApp_BusinessAccountId")]
        public System.String WhatsApp_BusinessAccountId { get; set; }
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
        
        #region Parameter WhatsApp_Component
        /// <summary>
        /// <para>
        /// <para>The list of component mapping from WhatsApp template parameters to Message Template
        /// attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_WhatsApp_Components")]
        public System.String[] WhatsApp_Component { get; set; }
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
        
        #region Parameter Content_Push_Adm_Body_Content
        /// <summary>
        /// <para>
        /// <para>The content of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Push_Adm_Body_Content { get; set; }
        #endregion
        
        #region Parameter Content_Push_Adm_RawContent_Content
        /// <summary>
        /// <para>
        /// <para>The content of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Push_Adm_RawContent_Content { get; set; }
        #endregion
        
        #region Parameter Content_Push_Apns_Body_Content
        /// <summary>
        /// <para>
        /// <para>The content of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Push_Apns_Body_Content { get; set; }
        #endregion
        
        #region Parameter Content_Push_Apns_RawContent_Content
        /// <summary>
        /// <para>
        /// <para>The content of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Push_Apns_RawContent_Content { get; set; }
        #endregion
        
        #region Parameter Content_Push_Baidu_Body_Content
        /// <summary>
        /// <para>
        /// <para>The content of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Push_Baidu_Body_Content { get; set; }
        #endregion
        
        #region Parameter Content_Push_Baidu_RawContent_Content
        /// <summary>
        /// <para>
        /// <para>The content of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Push_Baidu_RawContent_Content { get; set; }
        #endregion
        
        #region Parameter Content_Push_Fcm_Body_Content
        /// <summary>
        /// <para>
        /// <para>The content of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Push_Fcm_Body_Content { get; set; }
        #endregion
        
        #region Parameter Content_Push_Fcm_RawContent_Content
        /// <summary>
        /// <para>
        /// <para>The content of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Push_Fcm_RawContent_Content { get; set; }
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
        
        #region Parameter WhatsApp_Data
        /// <summary>
        /// <para>
        /// <para>The data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_WhatsApp_Data")]
        public System.String WhatsApp_Data { get; set; }
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
        
        #region Parameter Adm_ImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the large icon image to display in the content view of a push notification
        /// that's based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Adm_ImageIconUrl")]
        public System.String Adm_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter Baidu_ImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the large icon image to display in the content view of a push notification
        /// that's based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Baidu_ImageIconUrl")]
        public System.String Baidu_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter Fcm_ImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the large icon image to display in the content view of a push notification
        /// that's based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Fcm_ImageIconUrl")]
        public System.String Fcm_ImageIconUrl { get; set; }
        #endregion
        
        #region Parameter Adm_ImageUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image to display in a push notification that's based on the message
        /// template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Adm_ImageUrl")]
        public System.String Adm_ImageUrl { get; set; }
        #endregion
        
        #region Parameter Baidu_ImageUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image to display in a push notification that's based on the message
        /// template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Baidu_ImageUrl")]
        public System.String Baidu_ImageUrl { get; set; }
        #endregion
        
        #region Parameter Fcm_ImageUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image to display in a push notification that's based on the message
        /// template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Fcm_ImageUrl")]
        public System.String Fcm_ImageUrl { get; set; }
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
        
        #region Parameter Apns_MediaUrl
        /// <summary>
        /// <para>
        /// <para>The URL of an image or video to display in push notifications that are based on the
        /// message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Apns_MediaUrl")]
        public System.String Apns_MediaUrl { get; set; }
        #endregion
        
        #region Parameter MessageTemplateId
        /// <summary>
        /// <para>
        /// <para>The identifier of the message template. Can be either the ID or the ARN. It cannot
        /// contain any qualifier.</para>
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
        
        #region Parameter Adm_SmallImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the small icon image to display in the status bar and the content view
        /// of a push notification that's based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Adm_SmallImageIconUrl")]
        public System.String Adm_SmallImageIconUrl { get; set; }
        #endregion
        
        #region Parameter Baidu_SmallImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the small icon image to display in the status bar and the content view
        /// of a push notification that's based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Baidu_SmallImageIconUrl")]
        public System.String Baidu_SmallImageIconUrl { get; set; }
        #endregion
        
        #region Parameter Fcm_SmallImageIconUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the small icon image to display in the status bar and the content view
        /// of a push notification that's based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Fcm_SmallImageIconUrl")]
        public System.String Fcm_SmallImageIconUrl { get; set; }
        #endregion
        
        #region Parameter Adm_Sound
        /// <summary>
        /// <para>
        /// <para>The sound to play when a recipient receives a push notification that's based on the
        /// message template. You can use the default stream or specify the file name of a sound
        /// resource that's bundled in your app. On an Android platform, the sound file must reside
        /// in <c>/res/raw/</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Adm_Sound")]
        public System.String Adm_Sound { get; set; }
        #endregion
        
        #region Parameter Apns_Sound
        /// <summary>
        /// <para>
        /// <para>The key for the sound to play when the recipient receives a push notification that's
        /// based on the message template. The value for this key is the name of a sound file
        /// in your app's main bundle or the <c>Library/Sounds</c> folder in your app's data container.
        /// If the sound file can't be found or you specify <c>default</c> for the value, the
        /// system plays the default alert sound.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Apns_Sound")]
        public System.String Apns_Sound { get; set; }
        #endregion
        
        #region Parameter Baidu_Sound
        /// <summary>
        /// <para>
        /// <para>The sound to play when a recipient receives a push notification that's based on the
        /// message template. You can use the default stream or specify the file name of a sound
        /// resource that's bundled in your app. On an Android platform, the sound file must reside
        /// in <c>/res/raw/</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Baidu_Sound")]
        public System.String Baidu_Sound { get; set; }
        #endregion
        
        #region Parameter Fcm_Sound
        /// <summary>
        /// <para>
        /// <para>The sound to play when a recipient receives a push notification that's based on the
        /// message template. You can use the default stream or specify the file name of a sound
        /// resource that's bundled in your app. On an Android platform, the sound file must reside
        /// in <c>/res/raw/</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Fcm_Sound")]
        public System.String Fcm_Sound { get; set; }
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
        
        #region Parameter WhatsApp_TemplateId
        /// <summary>
        /// <para>
        /// <para>The WhatsApp template ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_WhatsApp_TemplateId")]
        public System.String WhatsApp_TemplateId { get; set; }
        #endregion
        
        #region Parameter Adm_Title
        /// <summary>
        /// <para>
        /// <para>The title to use in a push notification that's based on the message template. This
        /// title appears above the notification message on a recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Adm_Title")]
        public System.String Adm_Title { get; set; }
        #endregion
        
        #region Parameter Apns_Title
        /// <summary>
        /// <para>
        /// <para>The title to use in a push notification that's based on the message template. This
        /// title appears above the notification message on a recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Apns_Title")]
        public System.String Apns_Title { get; set; }
        #endregion
        
        #region Parameter Baidu_Title
        /// <summary>
        /// <para>
        /// <para>The title to use in a push notification that's based on the message template. This
        /// title appears above the notification message on a recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Baidu_Title")]
        public System.String Baidu_Title { get; set; }
        #endregion
        
        #region Parameter Fcm_Title
        /// <summary>
        /// <para>
        /// <para>The title to use in a push notification that's based on the message template. This
        /// title appears above the notification message on a recipient's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Fcm_Title")]
        public System.String Fcm_Title { get; set; }
        #endregion
        
        #region Parameter Adm_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in a recipient's default mobile browser, if a recipient taps a push
        /// notification that's based on the message template and the value of the <c>action</c>
        /// property is <c>URL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Adm_Url")]
        public System.String Adm_Url { get; set; }
        #endregion
        
        #region Parameter Apns_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in a recipient's default mobile browser, if a recipient taps a push
        /// notification that's based on the message template and the value of the <c>action</c>
        /// property is <c>URL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Apns_Url")]
        public System.String Apns_Url { get; set; }
        #endregion
        
        #region Parameter Baidu_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in a recipient's default mobile browser, if a recipient taps a push
        /// notification that's based on the message template and the value of the <c>action</c>
        /// property is <c>URL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Baidu_Url")]
        public System.String Baidu_Url { get; set; }
        #endregion
        
        #region Parameter Fcm_Url
        /// <summary>
        /// <para>
        /// <para>The URL to open in a recipient's default mobile browser, if a recipient taps a push
        /// notification that's based on the message template and the value of the <c>action</c>
        /// property is <c>URL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Push_Fcm_Url")]
        public System.String Fcm_Url { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.UpdateMessageTemplateResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.UpdateMessageTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageTemplate";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QCMessageTemplate (UpdateMessageTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.UpdateMessageTemplateResponse, UpdateQCMessageTemplateCmdlet>(Select) ??
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
            context.Html_Content = this.Html_Content;
            context.Content_Email_Body_PlainText_Content = this.Content_Email_Body_PlainText_Content;
            if (this.Email_Header != null)
            {
                context.Email_Header = new List<Amazon.QConnect.Model.EmailHeader>(this.Email_Header);
            }
            context.Email_Subject = this.Email_Subject;
            context.Adm_Action = this.Adm_Action;
            context.Content_Push_Adm_Body_Content = this.Content_Push_Adm_Body_Content;
            context.Adm_ImageIconUrl = this.Adm_ImageIconUrl;
            context.Adm_ImageUrl = this.Adm_ImageUrl;
            context.Content_Push_Adm_RawContent_Content = this.Content_Push_Adm_RawContent_Content;
            context.Adm_SmallImageIconUrl = this.Adm_SmallImageIconUrl;
            context.Adm_Sound = this.Adm_Sound;
            context.Adm_Title = this.Adm_Title;
            context.Adm_Url = this.Adm_Url;
            context.Apns_Action = this.Apns_Action;
            context.Content_Push_Apns_Body_Content = this.Content_Push_Apns_Body_Content;
            context.Apns_MediaUrl = this.Apns_MediaUrl;
            context.Content_Push_Apns_RawContent_Content = this.Content_Push_Apns_RawContent_Content;
            context.Apns_Sound = this.Apns_Sound;
            context.Apns_Title = this.Apns_Title;
            context.Apns_Url = this.Apns_Url;
            context.Baidu_Action = this.Baidu_Action;
            context.Content_Push_Baidu_Body_Content = this.Content_Push_Baidu_Body_Content;
            context.Baidu_ImageIconUrl = this.Baidu_ImageIconUrl;
            context.Baidu_ImageUrl = this.Baidu_ImageUrl;
            context.Content_Push_Baidu_RawContent_Content = this.Content_Push_Baidu_RawContent_Content;
            context.Baidu_SmallImageIconUrl = this.Baidu_SmallImageIconUrl;
            context.Baidu_Sound = this.Baidu_Sound;
            context.Baidu_Title = this.Baidu_Title;
            context.Baidu_Url = this.Baidu_Url;
            context.Fcm_Action = this.Fcm_Action;
            context.Content_Push_Fcm_Body_Content = this.Content_Push_Fcm_Body_Content;
            context.Fcm_ImageIconUrl = this.Fcm_ImageIconUrl;
            context.Fcm_ImageUrl = this.Fcm_ImageUrl;
            context.Content_Push_Fcm_RawContent_Content = this.Content_Push_Fcm_RawContent_Content;
            context.Fcm_SmallImageIconUrl = this.Fcm_SmallImageIconUrl;
            context.Fcm_Sound = this.Fcm_Sound;
            context.Fcm_Title = this.Fcm_Title;
            context.Fcm_Url = this.Fcm_Url;
            context.Content_Sms_Body_PlainText_Content = this.Content_Sms_Body_PlainText_Content;
            context.WhatsApp_Data = this.WhatsApp_Data;
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
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Language = this.Language;
            context.MessageTemplateId = this.MessageTemplateId;
            #if MODULAR
            if (this.MessageTemplateId == null && ParameterWasBound(nameof(this.MessageTemplateId)))
            {
                WriteWarning("You are passing $null as a value for parameter MessageTemplateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WhatsApp_BusinessAccountId = this.WhatsApp_BusinessAccountId;
            if (this.WhatsApp_Component != null)
            {
                context.WhatsApp_Component = new List<System.String>(this.WhatsApp_Component);
            }
            context.WhatsApp_TemplateId = this.WhatsApp_TemplateId;
            
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
            var request = new Amazon.QConnect.Model.UpdateMessageTemplateRequest();
            
            
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
            Amazon.QConnect.Model.WhatsAppMessageTemplateContent requestContent_content_WhatsApp = null;
            
             // populate WhatsApp
            var requestContent_content_WhatsAppIsNull = true;
            requestContent_content_WhatsApp = new Amazon.QConnect.Model.WhatsAppMessageTemplateContent();
            System.String requestContent_content_WhatsApp_whatsApp_Data = null;
            if (cmdletContext.WhatsApp_Data != null)
            {
                requestContent_content_WhatsApp_whatsApp_Data = cmdletContext.WhatsApp_Data;
            }
            if (requestContent_content_WhatsApp_whatsApp_Data != null)
            {
                requestContent_content_WhatsApp.Data = requestContent_content_WhatsApp_whatsApp_Data;
                requestContent_content_WhatsAppIsNull = false;
            }
             // determine if requestContent_content_WhatsApp should be set to null
            if (requestContent_content_WhatsAppIsNull)
            {
                requestContent_content_WhatsApp = null;
            }
            if (requestContent_content_WhatsApp != null)
            {
                request.Content.WhatsApp = requestContent_content_WhatsApp;
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
            Amazon.QConnect.Model.PushMessageTemplateContent requestContent_content_Push = null;
            
             // populate Push
            var requestContent_content_PushIsNull = true;
            requestContent_content_Push = new Amazon.QConnect.Model.PushMessageTemplateContent();
            Amazon.QConnect.Model.PushAPNSMessageTemplateContent requestContent_content_Push_content_Push_Apns = null;
            
             // populate Apns
            var requestContent_content_Push_content_Push_ApnsIsNull = true;
            requestContent_content_Push_content_Push_Apns = new Amazon.QConnect.Model.PushAPNSMessageTemplateContent();
            Amazon.QConnect.PushMessageAction requestContent_content_Push_content_Push_Apns_apns_Action = null;
            if (cmdletContext.Apns_Action != null)
            {
                requestContent_content_Push_content_Push_Apns_apns_Action = cmdletContext.Apns_Action;
            }
            if (requestContent_content_Push_content_Push_Apns_apns_Action != null)
            {
                requestContent_content_Push_content_Push_Apns.Action = requestContent_content_Push_content_Push_Apns_apns_Action;
                requestContent_content_Push_content_Push_ApnsIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Apns_apns_MediaUrl = null;
            if (cmdletContext.Apns_MediaUrl != null)
            {
                requestContent_content_Push_content_Push_Apns_apns_MediaUrl = cmdletContext.Apns_MediaUrl;
            }
            if (requestContent_content_Push_content_Push_Apns_apns_MediaUrl != null)
            {
                requestContent_content_Push_content_Push_Apns.MediaUrl = requestContent_content_Push_content_Push_Apns_apns_MediaUrl;
                requestContent_content_Push_content_Push_ApnsIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Apns_apns_Sound = null;
            if (cmdletContext.Apns_Sound != null)
            {
                requestContent_content_Push_content_Push_Apns_apns_Sound = cmdletContext.Apns_Sound;
            }
            if (requestContent_content_Push_content_Push_Apns_apns_Sound != null)
            {
                requestContent_content_Push_content_Push_Apns.Sound = requestContent_content_Push_content_Push_Apns_apns_Sound;
                requestContent_content_Push_content_Push_ApnsIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Apns_apns_Title = null;
            if (cmdletContext.Apns_Title != null)
            {
                requestContent_content_Push_content_Push_Apns_apns_Title = cmdletContext.Apns_Title;
            }
            if (requestContent_content_Push_content_Push_Apns_apns_Title != null)
            {
                requestContent_content_Push_content_Push_Apns.Title = requestContent_content_Push_content_Push_Apns_apns_Title;
                requestContent_content_Push_content_Push_ApnsIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Apns_apns_Url = null;
            if (cmdletContext.Apns_Url != null)
            {
                requestContent_content_Push_content_Push_Apns_apns_Url = cmdletContext.Apns_Url;
            }
            if (requestContent_content_Push_content_Push_Apns_apns_Url != null)
            {
                requestContent_content_Push_content_Push_Apns.Url = requestContent_content_Push_content_Push_Apns_apns_Url;
                requestContent_content_Push_content_Push_ApnsIsNull = false;
            }
            Amazon.QConnect.Model.MessageTemplateBodyContentProvider requestContent_content_Push_content_Push_Apns_content_Push_Apns_Body = null;
            
             // populate Body
            var requestContent_content_Push_content_Push_Apns_content_Push_Apns_BodyIsNull = true;
            requestContent_content_Push_content_Push_Apns_content_Push_Apns_Body = new Amazon.QConnect.Model.MessageTemplateBodyContentProvider();
            System.String requestContent_content_Push_content_Push_Apns_content_Push_Apns_Body_content_Push_Apns_Body_Content = null;
            if (cmdletContext.Content_Push_Apns_Body_Content != null)
            {
                requestContent_content_Push_content_Push_Apns_content_Push_Apns_Body_content_Push_Apns_Body_Content = cmdletContext.Content_Push_Apns_Body_Content;
            }
            if (requestContent_content_Push_content_Push_Apns_content_Push_Apns_Body_content_Push_Apns_Body_Content != null)
            {
                requestContent_content_Push_content_Push_Apns_content_Push_Apns_Body.Content = requestContent_content_Push_content_Push_Apns_content_Push_Apns_Body_content_Push_Apns_Body_Content;
                requestContent_content_Push_content_Push_Apns_content_Push_Apns_BodyIsNull = false;
            }
             // determine if requestContent_content_Push_content_Push_Apns_content_Push_Apns_Body should be set to null
            if (requestContent_content_Push_content_Push_Apns_content_Push_Apns_BodyIsNull)
            {
                requestContent_content_Push_content_Push_Apns_content_Push_Apns_Body = null;
            }
            if (requestContent_content_Push_content_Push_Apns_content_Push_Apns_Body != null)
            {
                requestContent_content_Push_content_Push_Apns.Body = requestContent_content_Push_content_Push_Apns_content_Push_Apns_Body;
                requestContent_content_Push_content_Push_ApnsIsNull = false;
            }
            Amazon.QConnect.Model.MessageTemplateBodyContentProvider requestContent_content_Push_content_Push_Apns_content_Push_Apns_RawContent = null;
            
             // populate RawContent
            var requestContent_content_Push_content_Push_Apns_content_Push_Apns_RawContentIsNull = true;
            requestContent_content_Push_content_Push_Apns_content_Push_Apns_RawContent = new Amazon.QConnect.Model.MessageTemplateBodyContentProvider();
            System.String requestContent_content_Push_content_Push_Apns_content_Push_Apns_RawContent_content_Push_Apns_RawContent_Content = null;
            if (cmdletContext.Content_Push_Apns_RawContent_Content != null)
            {
                requestContent_content_Push_content_Push_Apns_content_Push_Apns_RawContent_content_Push_Apns_RawContent_Content = cmdletContext.Content_Push_Apns_RawContent_Content;
            }
            if (requestContent_content_Push_content_Push_Apns_content_Push_Apns_RawContent_content_Push_Apns_RawContent_Content != null)
            {
                requestContent_content_Push_content_Push_Apns_content_Push_Apns_RawContent.Content = requestContent_content_Push_content_Push_Apns_content_Push_Apns_RawContent_content_Push_Apns_RawContent_Content;
                requestContent_content_Push_content_Push_Apns_content_Push_Apns_RawContentIsNull = false;
            }
             // determine if requestContent_content_Push_content_Push_Apns_content_Push_Apns_RawContent should be set to null
            if (requestContent_content_Push_content_Push_Apns_content_Push_Apns_RawContentIsNull)
            {
                requestContent_content_Push_content_Push_Apns_content_Push_Apns_RawContent = null;
            }
            if (requestContent_content_Push_content_Push_Apns_content_Push_Apns_RawContent != null)
            {
                requestContent_content_Push_content_Push_Apns.RawContent = requestContent_content_Push_content_Push_Apns_content_Push_Apns_RawContent;
                requestContent_content_Push_content_Push_ApnsIsNull = false;
            }
             // determine if requestContent_content_Push_content_Push_Apns should be set to null
            if (requestContent_content_Push_content_Push_ApnsIsNull)
            {
                requestContent_content_Push_content_Push_Apns = null;
            }
            if (requestContent_content_Push_content_Push_Apns != null)
            {
                requestContent_content_Push.Apns = requestContent_content_Push_content_Push_Apns;
                requestContent_content_PushIsNull = false;
            }
            Amazon.QConnect.Model.PushADMMessageTemplateContent requestContent_content_Push_content_Push_Adm = null;
            
             // populate Adm
            var requestContent_content_Push_content_Push_AdmIsNull = true;
            requestContent_content_Push_content_Push_Adm = new Amazon.QConnect.Model.PushADMMessageTemplateContent();
            Amazon.QConnect.PushMessageAction requestContent_content_Push_content_Push_Adm_adm_Action = null;
            if (cmdletContext.Adm_Action != null)
            {
                requestContent_content_Push_content_Push_Adm_adm_Action = cmdletContext.Adm_Action;
            }
            if (requestContent_content_Push_content_Push_Adm_adm_Action != null)
            {
                requestContent_content_Push_content_Push_Adm.Action = requestContent_content_Push_content_Push_Adm_adm_Action;
                requestContent_content_Push_content_Push_AdmIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Adm_adm_ImageIconUrl = null;
            if (cmdletContext.Adm_ImageIconUrl != null)
            {
                requestContent_content_Push_content_Push_Adm_adm_ImageIconUrl = cmdletContext.Adm_ImageIconUrl;
            }
            if (requestContent_content_Push_content_Push_Adm_adm_ImageIconUrl != null)
            {
                requestContent_content_Push_content_Push_Adm.ImageIconUrl = requestContent_content_Push_content_Push_Adm_adm_ImageIconUrl;
                requestContent_content_Push_content_Push_AdmIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Adm_adm_ImageUrl = null;
            if (cmdletContext.Adm_ImageUrl != null)
            {
                requestContent_content_Push_content_Push_Adm_adm_ImageUrl = cmdletContext.Adm_ImageUrl;
            }
            if (requestContent_content_Push_content_Push_Adm_adm_ImageUrl != null)
            {
                requestContent_content_Push_content_Push_Adm.ImageUrl = requestContent_content_Push_content_Push_Adm_adm_ImageUrl;
                requestContent_content_Push_content_Push_AdmIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Adm_adm_SmallImageIconUrl = null;
            if (cmdletContext.Adm_SmallImageIconUrl != null)
            {
                requestContent_content_Push_content_Push_Adm_adm_SmallImageIconUrl = cmdletContext.Adm_SmallImageIconUrl;
            }
            if (requestContent_content_Push_content_Push_Adm_adm_SmallImageIconUrl != null)
            {
                requestContent_content_Push_content_Push_Adm.SmallImageIconUrl = requestContent_content_Push_content_Push_Adm_adm_SmallImageIconUrl;
                requestContent_content_Push_content_Push_AdmIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Adm_adm_Sound = null;
            if (cmdletContext.Adm_Sound != null)
            {
                requestContent_content_Push_content_Push_Adm_adm_Sound = cmdletContext.Adm_Sound;
            }
            if (requestContent_content_Push_content_Push_Adm_adm_Sound != null)
            {
                requestContent_content_Push_content_Push_Adm.Sound = requestContent_content_Push_content_Push_Adm_adm_Sound;
                requestContent_content_Push_content_Push_AdmIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Adm_adm_Title = null;
            if (cmdletContext.Adm_Title != null)
            {
                requestContent_content_Push_content_Push_Adm_adm_Title = cmdletContext.Adm_Title;
            }
            if (requestContent_content_Push_content_Push_Adm_adm_Title != null)
            {
                requestContent_content_Push_content_Push_Adm.Title = requestContent_content_Push_content_Push_Adm_adm_Title;
                requestContent_content_Push_content_Push_AdmIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Adm_adm_Url = null;
            if (cmdletContext.Adm_Url != null)
            {
                requestContent_content_Push_content_Push_Adm_adm_Url = cmdletContext.Adm_Url;
            }
            if (requestContent_content_Push_content_Push_Adm_adm_Url != null)
            {
                requestContent_content_Push_content_Push_Adm.Url = requestContent_content_Push_content_Push_Adm_adm_Url;
                requestContent_content_Push_content_Push_AdmIsNull = false;
            }
            Amazon.QConnect.Model.MessageTemplateBodyContentProvider requestContent_content_Push_content_Push_Adm_content_Push_Adm_Body = null;
            
             // populate Body
            var requestContent_content_Push_content_Push_Adm_content_Push_Adm_BodyIsNull = true;
            requestContent_content_Push_content_Push_Adm_content_Push_Adm_Body = new Amazon.QConnect.Model.MessageTemplateBodyContentProvider();
            System.String requestContent_content_Push_content_Push_Adm_content_Push_Adm_Body_content_Push_Adm_Body_Content = null;
            if (cmdletContext.Content_Push_Adm_Body_Content != null)
            {
                requestContent_content_Push_content_Push_Adm_content_Push_Adm_Body_content_Push_Adm_Body_Content = cmdletContext.Content_Push_Adm_Body_Content;
            }
            if (requestContent_content_Push_content_Push_Adm_content_Push_Adm_Body_content_Push_Adm_Body_Content != null)
            {
                requestContent_content_Push_content_Push_Adm_content_Push_Adm_Body.Content = requestContent_content_Push_content_Push_Adm_content_Push_Adm_Body_content_Push_Adm_Body_Content;
                requestContent_content_Push_content_Push_Adm_content_Push_Adm_BodyIsNull = false;
            }
             // determine if requestContent_content_Push_content_Push_Adm_content_Push_Adm_Body should be set to null
            if (requestContent_content_Push_content_Push_Adm_content_Push_Adm_BodyIsNull)
            {
                requestContent_content_Push_content_Push_Adm_content_Push_Adm_Body = null;
            }
            if (requestContent_content_Push_content_Push_Adm_content_Push_Adm_Body != null)
            {
                requestContent_content_Push_content_Push_Adm.Body = requestContent_content_Push_content_Push_Adm_content_Push_Adm_Body;
                requestContent_content_Push_content_Push_AdmIsNull = false;
            }
            Amazon.QConnect.Model.MessageTemplateBodyContentProvider requestContent_content_Push_content_Push_Adm_content_Push_Adm_RawContent = null;
            
             // populate RawContent
            var requestContent_content_Push_content_Push_Adm_content_Push_Adm_RawContentIsNull = true;
            requestContent_content_Push_content_Push_Adm_content_Push_Adm_RawContent = new Amazon.QConnect.Model.MessageTemplateBodyContentProvider();
            System.String requestContent_content_Push_content_Push_Adm_content_Push_Adm_RawContent_content_Push_Adm_RawContent_Content = null;
            if (cmdletContext.Content_Push_Adm_RawContent_Content != null)
            {
                requestContent_content_Push_content_Push_Adm_content_Push_Adm_RawContent_content_Push_Adm_RawContent_Content = cmdletContext.Content_Push_Adm_RawContent_Content;
            }
            if (requestContent_content_Push_content_Push_Adm_content_Push_Adm_RawContent_content_Push_Adm_RawContent_Content != null)
            {
                requestContent_content_Push_content_Push_Adm_content_Push_Adm_RawContent.Content = requestContent_content_Push_content_Push_Adm_content_Push_Adm_RawContent_content_Push_Adm_RawContent_Content;
                requestContent_content_Push_content_Push_Adm_content_Push_Adm_RawContentIsNull = false;
            }
             // determine if requestContent_content_Push_content_Push_Adm_content_Push_Adm_RawContent should be set to null
            if (requestContent_content_Push_content_Push_Adm_content_Push_Adm_RawContentIsNull)
            {
                requestContent_content_Push_content_Push_Adm_content_Push_Adm_RawContent = null;
            }
            if (requestContent_content_Push_content_Push_Adm_content_Push_Adm_RawContent != null)
            {
                requestContent_content_Push_content_Push_Adm.RawContent = requestContent_content_Push_content_Push_Adm_content_Push_Adm_RawContent;
                requestContent_content_Push_content_Push_AdmIsNull = false;
            }
             // determine if requestContent_content_Push_content_Push_Adm should be set to null
            if (requestContent_content_Push_content_Push_AdmIsNull)
            {
                requestContent_content_Push_content_Push_Adm = null;
            }
            if (requestContent_content_Push_content_Push_Adm != null)
            {
                requestContent_content_Push.Adm = requestContent_content_Push_content_Push_Adm;
                requestContent_content_PushIsNull = false;
            }
            Amazon.QConnect.Model.PushBaiduMessageTemplateContent requestContent_content_Push_content_Push_Baidu = null;
            
             // populate Baidu
            var requestContent_content_Push_content_Push_BaiduIsNull = true;
            requestContent_content_Push_content_Push_Baidu = new Amazon.QConnect.Model.PushBaiduMessageTemplateContent();
            Amazon.QConnect.PushMessageAction requestContent_content_Push_content_Push_Baidu_baidu_Action = null;
            if (cmdletContext.Baidu_Action != null)
            {
                requestContent_content_Push_content_Push_Baidu_baidu_Action = cmdletContext.Baidu_Action;
            }
            if (requestContent_content_Push_content_Push_Baidu_baidu_Action != null)
            {
                requestContent_content_Push_content_Push_Baidu.Action = requestContent_content_Push_content_Push_Baidu_baidu_Action;
                requestContent_content_Push_content_Push_BaiduIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Baidu_baidu_ImageIconUrl = null;
            if (cmdletContext.Baidu_ImageIconUrl != null)
            {
                requestContent_content_Push_content_Push_Baidu_baidu_ImageIconUrl = cmdletContext.Baidu_ImageIconUrl;
            }
            if (requestContent_content_Push_content_Push_Baidu_baidu_ImageIconUrl != null)
            {
                requestContent_content_Push_content_Push_Baidu.ImageIconUrl = requestContent_content_Push_content_Push_Baidu_baidu_ImageIconUrl;
                requestContent_content_Push_content_Push_BaiduIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Baidu_baidu_ImageUrl = null;
            if (cmdletContext.Baidu_ImageUrl != null)
            {
                requestContent_content_Push_content_Push_Baidu_baidu_ImageUrl = cmdletContext.Baidu_ImageUrl;
            }
            if (requestContent_content_Push_content_Push_Baidu_baidu_ImageUrl != null)
            {
                requestContent_content_Push_content_Push_Baidu.ImageUrl = requestContent_content_Push_content_Push_Baidu_baidu_ImageUrl;
                requestContent_content_Push_content_Push_BaiduIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Baidu_baidu_SmallImageIconUrl = null;
            if (cmdletContext.Baidu_SmallImageIconUrl != null)
            {
                requestContent_content_Push_content_Push_Baidu_baidu_SmallImageIconUrl = cmdletContext.Baidu_SmallImageIconUrl;
            }
            if (requestContent_content_Push_content_Push_Baidu_baidu_SmallImageIconUrl != null)
            {
                requestContent_content_Push_content_Push_Baidu.SmallImageIconUrl = requestContent_content_Push_content_Push_Baidu_baidu_SmallImageIconUrl;
                requestContent_content_Push_content_Push_BaiduIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Baidu_baidu_Sound = null;
            if (cmdletContext.Baidu_Sound != null)
            {
                requestContent_content_Push_content_Push_Baidu_baidu_Sound = cmdletContext.Baidu_Sound;
            }
            if (requestContent_content_Push_content_Push_Baidu_baidu_Sound != null)
            {
                requestContent_content_Push_content_Push_Baidu.Sound = requestContent_content_Push_content_Push_Baidu_baidu_Sound;
                requestContent_content_Push_content_Push_BaiduIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Baidu_baidu_Title = null;
            if (cmdletContext.Baidu_Title != null)
            {
                requestContent_content_Push_content_Push_Baidu_baidu_Title = cmdletContext.Baidu_Title;
            }
            if (requestContent_content_Push_content_Push_Baidu_baidu_Title != null)
            {
                requestContent_content_Push_content_Push_Baidu.Title = requestContent_content_Push_content_Push_Baidu_baidu_Title;
                requestContent_content_Push_content_Push_BaiduIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Baidu_baidu_Url = null;
            if (cmdletContext.Baidu_Url != null)
            {
                requestContent_content_Push_content_Push_Baidu_baidu_Url = cmdletContext.Baidu_Url;
            }
            if (requestContent_content_Push_content_Push_Baidu_baidu_Url != null)
            {
                requestContent_content_Push_content_Push_Baidu.Url = requestContent_content_Push_content_Push_Baidu_baidu_Url;
                requestContent_content_Push_content_Push_BaiduIsNull = false;
            }
            Amazon.QConnect.Model.MessageTemplateBodyContentProvider requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_Body = null;
            
             // populate Body
            var requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_BodyIsNull = true;
            requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_Body = new Amazon.QConnect.Model.MessageTemplateBodyContentProvider();
            System.String requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_Body_content_Push_Baidu_Body_Content = null;
            if (cmdletContext.Content_Push_Baidu_Body_Content != null)
            {
                requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_Body_content_Push_Baidu_Body_Content = cmdletContext.Content_Push_Baidu_Body_Content;
            }
            if (requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_Body_content_Push_Baidu_Body_Content != null)
            {
                requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_Body.Content = requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_Body_content_Push_Baidu_Body_Content;
                requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_BodyIsNull = false;
            }
             // determine if requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_Body should be set to null
            if (requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_BodyIsNull)
            {
                requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_Body = null;
            }
            if (requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_Body != null)
            {
                requestContent_content_Push_content_Push_Baidu.Body = requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_Body;
                requestContent_content_Push_content_Push_BaiduIsNull = false;
            }
            Amazon.QConnect.Model.MessageTemplateBodyContentProvider requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_RawContent = null;
            
             // populate RawContent
            var requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_RawContentIsNull = true;
            requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_RawContent = new Amazon.QConnect.Model.MessageTemplateBodyContentProvider();
            System.String requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_RawContent_content_Push_Baidu_RawContent_Content = null;
            if (cmdletContext.Content_Push_Baidu_RawContent_Content != null)
            {
                requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_RawContent_content_Push_Baidu_RawContent_Content = cmdletContext.Content_Push_Baidu_RawContent_Content;
            }
            if (requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_RawContent_content_Push_Baidu_RawContent_Content != null)
            {
                requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_RawContent.Content = requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_RawContent_content_Push_Baidu_RawContent_Content;
                requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_RawContentIsNull = false;
            }
             // determine if requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_RawContent should be set to null
            if (requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_RawContentIsNull)
            {
                requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_RawContent = null;
            }
            if (requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_RawContent != null)
            {
                requestContent_content_Push_content_Push_Baidu.RawContent = requestContent_content_Push_content_Push_Baidu_content_Push_Baidu_RawContent;
                requestContent_content_Push_content_Push_BaiduIsNull = false;
            }
             // determine if requestContent_content_Push_content_Push_Baidu should be set to null
            if (requestContent_content_Push_content_Push_BaiduIsNull)
            {
                requestContent_content_Push_content_Push_Baidu = null;
            }
            if (requestContent_content_Push_content_Push_Baidu != null)
            {
                requestContent_content_Push.Baidu = requestContent_content_Push_content_Push_Baidu;
                requestContent_content_PushIsNull = false;
            }
            Amazon.QConnect.Model.PushFCMMessageTemplateContent requestContent_content_Push_content_Push_Fcm = null;
            
             // populate Fcm
            var requestContent_content_Push_content_Push_FcmIsNull = true;
            requestContent_content_Push_content_Push_Fcm = new Amazon.QConnect.Model.PushFCMMessageTemplateContent();
            Amazon.QConnect.PushMessageAction requestContent_content_Push_content_Push_Fcm_fcm_Action = null;
            if (cmdletContext.Fcm_Action != null)
            {
                requestContent_content_Push_content_Push_Fcm_fcm_Action = cmdletContext.Fcm_Action;
            }
            if (requestContent_content_Push_content_Push_Fcm_fcm_Action != null)
            {
                requestContent_content_Push_content_Push_Fcm.Action = requestContent_content_Push_content_Push_Fcm_fcm_Action;
                requestContent_content_Push_content_Push_FcmIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Fcm_fcm_ImageIconUrl = null;
            if (cmdletContext.Fcm_ImageIconUrl != null)
            {
                requestContent_content_Push_content_Push_Fcm_fcm_ImageIconUrl = cmdletContext.Fcm_ImageIconUrl;
            }
            if (requestContent_content_Push_content_Push_Fcm_fcm_ImageIconUrl != null)
            {
                requestContent_content_Push_content_Push_Fcm.ImageIconUrl = requestContent_content_Push_content_Push_Fcm_fcm_ImageIconUrl;
                requestContent_content_Push_content_Push_FcmIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Fcm_fcm_ImageUrl = null;
            if (cmdletContext.Fcm_ImageUrl != null)
            {
                requestContent_content_Push_content_Push_Fcm_fcm_ImageUrl = cmdletContext.Fcm_ImageUrl;
            }
            if (requestContent_content_Push_content_Push_Fcm_fcm_ImageUrl != null)
            {
                requestContent_content_Push_content_Push_Fcm.ImageUrl = requestContent_content_Push_content_Push_Fcm_fcm_ImageUrl;
                requestContent_content_Push_content_Push_FcmIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Fcm_fcm_SmallImageIconUrl = null;
            if (cmdletContext.Fcm_SmallImageIconUrl != null)
            {
                requestContent_content_Push_content_Push_Fcm_fcm_SmallImageIconUrl = cmdletContext.Fcm_SmallImageIconUrl;
            }
            if (requestContent_content_Push_content_Push_Fcm_fcm_SmallImageIconUrl != null)
            {
                requestContent_content_Push_content_Push_Fcm.SmallImageIconUrl = requestContent_content_Push_content_Push_Fcm_fcm_SmallImageIconUrl;
                requestContent_content_Push_content_Push_FcmIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Fcm_fcm_Sound = null;
            if (cmdletContext.Fcm_Sound != null)
            {
                requestContent_content_Push_content_Push_Fcm_fcm_Sound = cmdletContext.Fcm_Sound;
            }
            if (requestContent_content_Push_content_Push_Fcm_fcm_Sound != null)
            {
                requestContent_content_Push_content_Push_Fcm.Sound = requestContent_content_Push_content_Push_Fcm_fcm_Sound;
                requestContent_content_Push_content_Push_FcmIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Fcm_fcm_Title = null;
            if (cmdletContext.Fcm_Title != null)
            {
                requestContent_content_Push_content_Push_Fcm_fcm_Title = cmdletContext.Fcm_Title;
            }
            if (requestContent_content_Push_content_Push_Fcm_fcm_Title != null)
            {
                requestContent_content_Push_content_Push_Fcm.Title = requestContent_content_Push_content_Push_Fcm_fcm_Title;
                requestContent_content_Push_content_Push_FcmIsNull = false;
            }
            System.String requestContent_content_Push_content_Push_Fcm_fcm_Url = null;
            if (cmdletContext.Fcm_Url != null)
            {
                requestContent_content_Push_content_Push_Fcm_fcm_Url = cmdletContext.Fcm_Url;
            }
            if (requestContent_content_Push_content_Push_Fcm_fcm_Url != null)
            {
                requestContent_content_Push_content_Push_Fcm.Url = requestContent_content_Push_content_Push_Fcm_fcm_Url;
                requestContent_content_Push_content_Push_FcmIsNull = false;
            }
            Amazon.QConnect.Model.MessageTemplateBodyContentProvider requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_Body = null;
            
             // populate Body
            var requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_BodyIsNull = true;
            requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_Body = new Amazon.QConnect.Model.MessageTemplateBodyContentProvider();
            System.String requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_Body_content_Push_Fcm_Body_Content = null;
            if (cmdletContext.Content_Push_Fcm_Body_Content != null)
            {
                requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_Body_content_Push_Fcm_Body_Content = cmdletContext.Content_Push_Fcm_Body_Content;
            }
            if (requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_Body_content_Push_Fcm_Body_Content != null)
            {
                requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_Body.Content = requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_Body_content_Push_Fcm_Body_Content;
                requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_BodyIsNull = false;
            }
             // determine if requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_Body should be set to null
            if (requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_BodyIsNull)
            {
                requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_Body = null;
            }
            if (requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_Body != null)
            {
                requestContent_content_Push_content_Push_Fcm.Body = requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_Body;
                requestContent_content_Push_content_Push_FcmIsNull = false;
            }
            Amazon.QConnect.Model.MessageTemplateBodyContentProvider requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_RawContent = null;
            
             // populate RawContent
            var requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_RawContentIsNull = true;
            requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_RawContent = new Amazon.QConnect.Model.MessageTemplateBodyContentProvider();
            System.String requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_RawContent_content_Push_Fcm_RawContent_Content = null;
            if (cmdletContext.Content_Push_Fcm_RawContent_Content != null)
            {
                requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_RawContent_content_Push_Fcm_RawContent_Content = cmdletContext.Content_Push_Fcm_RawContent_Content;
            }
            if (requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_RawContent_content_Push_Fcm_RawContent_Content != null)
            {
                requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_RawContent.Content = requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_RawContent_content_Push_Fcm_RawContent_Content;
                requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_RawContentIsNull = false;
            }
             // determine if requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_RawContent should be set to null
            if (requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_RawContentIsNull)
            {
                requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_RawContent = null;
            }
            if (requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_RawContent != null)
            {
                requestContent_content_Push_content_Push_Fcm.RawContent = requestContent_content_Push_content_Push_Fcm_content_Push_Fcm_RawContent;
                requestContent_content_Push_content_Push_FcmIsNull = false;
            }
             // determine if requestContent_content_Push_content_Push_Fcm should be set to null
            if (requestContent_content_Push_content_Push_FcmIsNull)
            {
                requestContent_content_Push_content_Push_Fcm = null;
            }
            if (requestContent_content_Push_content_Push_Fcm != null)
            {
                requestContent_content_Push.Fcm = requestContent_content_Push_content_Push_Fcm;
                requestContent_content_PushIsNull = false;
            }
             // determine if requestContent_content_Push should be set to null
            if (requestContent_content_PushIsNull)
            {
                requestContent_content_Push = null;
            }
            if (requestContent_content_Push != null)
            {
                request.Content.Push = requestContent_content_Push;
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
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
            }
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
            }
            if (cmdletContext.MessageTemplateId != null)
            {
                request.MessageTemplateId = cmdletContext.MessageTemplateId;
            }
            
             // populate SourceConfiguration
            var requestSourceConfigurationIsNull = true;
            request.SourceConfiguration = new Amazon.QConnect.Model.MessageTemplateSourceConfiguration();
            Amazon.QConnect.Model.WhatsAppMessageTemplateSourceConfiguration requestSourceConfiguration_sourceConfiguration_WhatsApp = null;
            
             // populate WhatsApp
            var requestSourceConfiguration_sourceConfiguration_WhatsAppIsNull = true;
            requestSourceConfiguration_sourceConfiguration_WhatsApp = new Amazon.QConnect.Model.WhatsAppMessageTemplateSourceConfiguration();
            System.String requestSourceConfiguration_sourceConfiguration_WhatsApp_whatsApp_BusinessAccountId = null;
            if (cmdletContext.WhatsApp_BusinessAccountId != null)
            {
                requestSourceConfiguration_sourceConfiguration_WhatsApp_whatsApp_BusinessAccountId = cmdletContext.WhatsApp_BusinessAccountId;
            }
            if (requestSourceConfiguration_sourceConfiguration_WhatsApp_whatsApp_BusinessAccountId != null)
            {
                requestSourceConfiguration_sourceConfiguration_WhatsApp.BusinessAccountId = requestSourceConfiguration_sourceConfiguration_WhatsApp_whatsApp_BusinessAccountId;
                requestSourceConfiguration_sourceConfiguration_WhatsAppIsNull = false;
            }
            List<System.String> requestSourceConfiguration_sourceConfiguration_WhatsApp_whatsApp_Component = null;
            if (cmdletContext.WhatsApp_Component != null)
            {
                requestSourceConfiguration_sourceConfiguration_WhatsApp_whatsApp_Component = cmdletContext.WhatsApp_Component;
            }
            if (requestSourceConfiguration_sourceConfiguration_WhatsApp_whatsApp_Component != null)
            {
                requestSourceConfiguration_sourceConfiguration_WhatsApp.Components = requestSourceConfiguration_sourceConfiguration_WhatsApp_whatsApp_Component;
                requestSourceConfiguration_sourceConfiguration_WhatsAppIsNull = false;
            }
            System.String requestSourceConfiguration_sourceConfiguration_WhatsApp_whatsApp_TemplateId = null;
            if (cmdletContext.WhatsApp_TemplateId != null)
            {
                requestSourceConfiguration_sourceConfiguration_WhatsApp_whatsApp_TemplateId = cmdletContext.WhatsApp_TemplateId;
            }
            if (requestSourceConfiguration_sourceConfiguration_WhatsApp_whatsApp_TemplateId != null)
            {
                requestSourceConfiguration_sourceConfiguration_WhatsApp.TemplateId = requestSourceConfiguration_sourceConfiguration_WhatsApp_whatsApp_TemplateId;
                requestSourceConfiguration_sourceConfiguration_WhatsAppIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_WhatsApp should be set to null
            if (requestSourceConfiguration_sourceConfiguration_WhatsAppIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_WhatsApp = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_WhatsApp != null)
            {
                request.SourceConfiguration.WhatsApp = requestSourceConfiguration_sourceConfiguration_WhatsApp;
                requestSourceConfigurationIsNull = false;
            }
             // determine if request.SourceConfiguration should be set to null
            if (requestSourceConfigurationIsNull)
            {
                request.SourceConfiguration = null;
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
        
        private Amazon.QConnect.Model.UpdateMessageTemplateResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.UpdateMessageTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "UpdateMessageTemplate");
            try
            {
                #if DESKTOP
                return client.UpdateMessageTemplate(request);
                #elif CORECLR
                return client.UpdateMessageTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String Html_Content { get; set; }
            public System.String Content_Email_Body_PlainText_Content { get; set; }
            public List<Amazon.QConnect.Model.EmailHeader> Email_Header { get; set; }
            public System.String Email_Subject { get; set; }
            public Amazon.QConnect.PushMessageAction Adm_Action { get; set; }
            public System.String Content_Push_Adm_Body_Content { get; set; }
            public System.String Adm_ImageIconUrl { get; set; }
            public System.String Adm_ImageUrl { get; set; }
            public System.String Content_Push_Adm_RawContent_Content { get; set; }
            public System.String Adm_SmallImageIconUrl { get; set; }
            public System.String Adm_Sound { get; set; }
            public System.String Adm_Title { get; set; }
            public System.String Adm_Url { get; set; }
            public Amazon.QConnect.PushMessageAction Apns_Action { get; set; }
            public System.String Content_Push_Apns_Body_Content { get; set; }
            public System.String Apns_MediaUrl { get; set; }
            public System.String Content_Push_Apns_RawContent_Content { get; set; }
            public System.String Apns_Sound { get; set; }
            public System.String Apns_Title { get; set; }
            public System.String Apns_Url { get; set; }
            public Amazon.QConnect.PushMessageAction Baidu_Action { get; set; }
            public System.String Content_Push_Baidu_Body_Content { get; set; }
            public System.String Baidu_ImageIconUrl { get; set; }
            public System.String Baidu_ImageUrl { get; set; }
            public System.String Content_Push_Baidu_RawContent_Content { get; set; }
            public System.String Baidu_SmallImageIconUrl { get; set; }
            public System.String Baidu_Sound { get; set; }
            public System.String Baidu_Title { get; set; }
            public System.String Baidu_Url { get; set; }
            public Amazon.QConnect.PushMessageAction Fcm_Action { get; set; }
            public System.String Content_Push_Fcm_Body_Content { get; set; }
            public System.String Fcm_ImageIconUrl { get; set; }
            public System.String Fcm_ImageUrl { get; set; }
            public System.String Content_Push_Fcm_RawContent_Content { get; set; }
            public System.String Fcm_SmallImageIconUrl { get; set; }
            public System.String Fcm_Sound { get; set; }
            public System.String Fcm_Title { get; set; }
            public System.String Fcm_Url { get; set; }
            public System.String Content_Sms_Body_PlainText_Content { get; set; }
            public System.String WhatsApp_Data { get; set; }
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
            public System.String KnowledgeBaseId { get; set; }
            public System.String Language { get; set; }
            public System.String MessageTemplateId { get; set; }
            public System.String WhatsApp_BusinessAccountId { get; set; }
            public List<System.String> WhatsApp_Component { get; set; }
            public System.String WhatsApp_TemplateId { get; set; }
            public System.Func<Amazon.QConnect.Model.UpdateMessageTemplateResponse, UpdateQCMessageTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageTemplate;
        }
        
    }
}
