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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Creates a new endpoint for an application or updates the settings and attributes of
    /// an existing endpoint for an application. You can also use this operation to define
    /// custom attributes for an endpoint. If an update includes one or more values for a
    /// custom attribute, Amazon Pinpoint replaces (overwrites) any existing values with the
    /// new values.
    /// </summary>
    [Cmdlet("Update", "PINEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.MessageBody")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateEndpoint API operation.", Operation = new[] {"UpdateEndpoint"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateEndpointResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.MessageBody or Amazon.Pinpoint.Model.UpdateEndpointResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.MessageBody object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateEndpointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINEndpointCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndpointRequest_Address
        /// <summary>
        /// <para>
        /// <para>The destination address for messages or push notifications that you send to the endpoint.
        /// The address varies by channel. For a push-notification channel, use the token provided
        /// by the push notification service, such as an Apple Push Notification service (APNs)
        /// device token or a Firebase Cloud Messaging (FCM) registration token. For the SMS channel,
        /// use a phone number in E.164 format, such as +12065550100. For the email channel, use
        /// an email address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointRequest_Address { get; set; }
        #endregion
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the application. This identifier is displayed as the <b>Project
        /// ID</b> on the Amazon Pinpoint console.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter Demographic_AppVersion
        /// <summary>
        /// <para>
        /// <para>The version of the app that's associated with the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Demographic_AppVersion")]
        public System.String Demographic_AppVersion { get; set; }
        #endregion
        
        #region Parameter EndpointRequest_Attribute
        /// <summary>
        /// <para>
        /// <para>One or more custom attributes that describe the endpoint by associating a name with
        /// an array of values. For example, the value of a custom attribute named Interests might
        /// be: ["Science", "Music", "Travel"]. You can use these attributes as filter criteria
        /// when you create segments. Attribute names are case sensitive.</para><para>An attribute name can contain up to 50 characters. An attribute value can contain
        /// up to 100 characters. When you define the name of a custom attribute, avoid using
        /// the following characters: number sign (#), colon (:), question mark (?), backslash
        /// (\), and slash (/). The Amazon Pinpoint console can't display attribute names that
        /// contain these characters. This restriction doesn't apply to attribute values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Attributes")]
        public System.Collections.Hashtable EndpointRequest_Attribute { get; set; }
        #endregion
        
        #region Parameter EndpointRequest_ChannelType
        /// <summary>
        /// <para>
        /// <para>The channel to use when sending messages or push notifications to the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Pinpoint.ChannelType")]
        public Amazon.Pinpoint.ChannelType EndpointRequest_ChannelType { get; set; }
        #endregion
        
        #region Parameter Location_City
        /// <summary>
        /// <para>
        /// <para>The name of the city where the endpoint is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Location_City")]
        public System.String Location_City { get; set; }
        #endregion
        
        #region Parameter Location_Country
        /// <summary>
        /// <para>
        /// <para>The two-character code, in ISO 3166-1 alpha-2 format, for the country or region where
        /// the endpoint is located. For example, US for the United States.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Location_Country")]
        public System.String Location_Country { get; set; }
        #endregion
        
        #region Parameter EndpointRequest_EffectiveDate
        /// <summary>
        /// <para>
        /// <para>The date and time, in ISO 8601 format, when the endpoint is updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointRequest_EffectiveDate { get; set; }
        #endregion
        
        #region Parameter EndpointId
        /// <summary>
        /// <para>
        /// <para>The case insensitive unique identifier for the endpoint. The identifier can't contain
        /// <code>$</code>, <code>{</code> or <code>}</code>.</para>
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
        public System.String EndpointId { get; set; }
        #endregion
        
        #region Parameter EndpointRequest_EndpointStatus
        /// <summary>
        /// <para>
        /// <para>Specifies whether to send messages or push notifications to the endpoint. Valid values
        /// are: ACTIVE, messages are sent to the endpoint; and, INACTIVE, messages aren’t sent
        /// to the endpoint.</para><para>Amazon Pinpoint automatically sets this value to ACTIVE when you create an endpoint
        /// or update an existing endpoint. Amazon Pinpoint automatically sets this value to INACTIVE
        /// if you update another endpoint that has the same address specified by the Address
        /// property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointRequest_EndpointStatus { get; set; }
        #endregion
        
        #region Parameter Location_Latitude
        /// <summary>
        /// <para>
        /// <para>The latitude coordinate of the endpoint location, rounded to one decimal place.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Location_Latitude")]
        public System.Double? Location_Latitude { get; set; }
        #endregion
        
        #region Parameter Demographic_Locale
        /// <summary>
        /// <para>
        /// <para>The locale of the endpoint, in the following format: the ISO 639-1 alpha-2 code, followed
        /// by an underscore (_), followed by an ISO 3166-1 alpha-2 value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Demographic_Locale")]
        public System.String Demographic_Locale { get; set; }
        #endregion
        
        #region Parameter Location_Longitude
        /// <summary>
        /// <para>
        /// <para>The longitude coordinate of the endpoint location, rounded to one decimal place.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Location_Longitude")]
        public System.Double? Location_Longitude { get; set; }
        #endregion
        
        #region Parameter Demographic_Make
        /// <summary>
        /// <para>
        /// <para>The manufacturer of the endpoint device, such as apple or samsung.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Demographic_Make")]
        public System.String Demographic_Make { get; set; }
        #endregion
        
        #region Parameter EndpointRequest_Metric
        /// <summary>
        /// <para>
        /// <para>One or more custom metrics that your app reports to Amazon Pinpoint for the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Metrics")]
        public System.Collections.Hashtable EndpointRequest_Metric { get; set; }
        #endregion
        
        #region Parameter Demographic_Model
        /// <summary>
        /// <para>
        /// <para>The model name or number of the endpoint device, such as iPhone or SM-G900F.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Demographic_Model")]
        public System.String Demographic_Model { get; set; }
        #endregion
        
        #region Parameter Demographic_ModelVersion
        /// <summary>
        /// <para>
        /// <para>The model version of the endpoint device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Demographic_ModelVersion")]
        public System.String Demographic_ModelVersion { get; set; }
        #endregion
        
        #region Parameter EndpointRequest_OptOut
        /// <summary>
        /// <para>
        /// <para>Specifies whether the user who's associated with the endpoint has opted out of receiving
        /// messages and push notifications from you. Possible values are: ALL, the user has opted
        /// out and doesn't want to receive any messages or push notifications; and, NONE, the
        /// user hasn't opted out and wants to receive all messages and push notifications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointRequest_OptOut { get; set; }
        #endregion
        
        #region Parameter Demographic_Platform
        /// <summary>
        /// <para>
        /// <para>The platform of the endpoint device, such as ios.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Demographic_Platform")]
        public System.String Demographic_Platform { get; set; }
        #endregion
        
        #region Parameter Demographic_PlatformVersion
        /// <summary>
        /// <para>
        /// <para>The platform version of the endpoint device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Demographic_PlatformVersion")]
        public System.String Demographic_PlatformVersion { get; set; }
        #endregion
        
        #region Parameter Location_PostalCode
        /// <summary>
        /// <para>
        /// <para>The postal or ZIP code for the area where the endpoint is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Location_PostalCode")]
        public System.String Location_PostalCode { get; set; }
        #endregion
        
        #region Parameter Location_Region
        /// <summary>
        /// <para>
        /// <para>The name of the region where the endpoint is located. For locations in the United
        /// States, this value is the name of a state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Location_Region")]
        public System.String Location_Region { get; set; }
        #endregion
        
        #region Parameter EndpointRequest_RequestId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the most recent request to update the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointRequest_RequestId { get; set; }
        #endregion
        
        #region Parameter Demographic_Timezone
        /// <summary>
        /// <para>
        /// <para>The time zone of the endpoint, specified as a tz database name value, such as America/Los_Angeles.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_Demographic_Timezone")]
        public System.String Demographic_Timezone { get; set; }
        #endregion
        
        #region Parameter User_UserAttribute
        /// <summary>
        /// <para>
        /// <para>One or more custom attributes that describe the user by associating a name with an
        /// array of values. For example, the value of an attribute named Interests might be:
        /// ["Science", "Music", "Travel"]. You can use these attributes as filter criteria when
        /// you create segments. Attribute names are case sensitive.</para><para>An attribute name can contain up to 50 characters. An attribute value can contain
        /// up to 100 characters. When you define the name of a custom attribute, avoid using
        /// the following characters: number sign (#), colon (:), question mark (?), backslash
        /// (\), and slash (/). The Amazon Pinpoint console can't display attribute names that
        /// contain these characters. This restriction doesn't apply to attribute values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_User_UserAttributes")]
        public System.Collections.Hashtable User_UserAttribute { get; set; }
        #endregion
        
        #region Parameter User_UserId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointRequest_User_UserId")]
        public System.String User_UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageBody'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateEndpointResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageBody";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINEndpoint (UpdateEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateEndpointResponse, UpdatePINEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointId = this.EndpointId;
            #if MODULAR
            if (this.EndpointId == null && ParameterWasBound(nameof(this.EndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointRequest_Address = this.EndpointRequest_Address;
            if (this.EndpointRequest_Attribute != null)
            {
                context.EndpointRequest_Attribute = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.EndpointRequest_Attribute.Keys)
                {
                    object hashValue = this.EndpointRequest_Attribute[hashKey];
                    if (hashValue == null)
                    {
                        context.EndpointRequest_Attribute.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.EndpointRequest_Attribute.Add((String)hashKey, valueSet);
                }
            }
            context.EndpointRequest_ChannelType = this.EndpointRequest_ChannelType;
            context.Demographic_AppVersion = this.Demographic_AppVersion;
            context.Demographic_Locale = this.Demographic_Locale;
            context.Demographic_Make = this.Demographic_Make;
            context.Demographic_Model = this.Demographic_Model;
            context.Demographic_ModelVersion = this.Demographic_ModelVersion;
            context.Demographic_Platform = this.Demographic_Platform;
            context.Demographic_PlatformVersion = this.Demographic_PlatformVersion;
            context.Demographic_Timezone = this.Demographic_Timezone;
            context.EndpointRequest_EffectiveDate = this.EndpointRequest_EffectiveDate;
            context.EndpointRequest_EndpointStatus = this.EndpointRequest_EndpointStatus;
            context.Location_City = this.Location_City;
            context.Location_Country = this.Location_Country;
            context.Location_Latitude = this.Location_Latitude;
            context.Location_Longitude = this.Location_Longitude;
            context.Location_PostalCode = this.Location_PostalCode;
            context.Location_Region = this.Location_Region;
            if (this.EndpointRequest_Metric != null)
            {
                context.EndpointRequest_Metric = new Dictionary<System.String, System.Double>(StringComparer.Ordinal);
                foreach (var hashKey in this.EndpointRequest_Metric.Keys)
                {
                    context.EndpointRequest_Metric.Add((String)hashKey, (Double)(this.EndpointRequest_Metric[hashKey]));
                }
            }
            context.EndpointRequest_OptOut = this.EndpointRequest_OptOut;
            context.EndpointRequest_RequestId = this.EndpointRequest_RequestId;
            if (this.User_UserAttribute != null)
            {
                context.User_UserAttribute = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.User_UserAttribute.Keys)
                {
                    object hashValue = this.User_UserAttribute[hashKey];
                    if (hashValue == null)
                    {
                        context.User_UserAttribute.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.User_UserAttribute.Add((String)hashKey, valueSet);
                }
            }
            context.User_UserId = this.User_UserId;
            
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
            var request = new Amazon.Pinpoint.Model.UpdateEndpointRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.EndpointId != null)
            {
                request.EndpointId = cmdletContext.EndpointId;
            }
            
             // populate EndpointRequest
            var requestEndpointRequestIsNull = true;
            request.EndpointRequest = new Amazon.Pinpoint.Model.EndpointRequest();
            System.String requestEndpointRequest_endpointRequest_Address = null;
            if (cmdletContext.EndpointRequest_Address != null)
            {
                requestEndpointRequest_endpointRequest_Address = cmdletContext.EndpointRequest_Address;
            }
            if (requestEndpointRequest_endpointRequest_Address != null)
            {
                request.EndpointRequest.Address = requestEndpointRequest_endpointRequest_Address;
                requestEndpointRequestIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestEndpointRequest_endpointRequest_Attribute = null;
            if (cmdletContext.EndpointRequest_Attribute != null)
            {
                requestEndpointRequest_endpointRequest_Attribute = cmdletContext.EndpointRequest_Attribute;
            }
            if (requestEndpointRequest_endpointRequest_Attribute != null)
            {
                request.EndpointRequest.Attributes = requestEndpointRequest_endpointRequest_Attribute;
                requestEndpointRequestIsNull = false;
            }
            Amazon.Pinpoint.ChannelType requestEndpointRequest_endpointRequest_ChannelType = null;
            if (cmdletContext.EndpointRequest_ChannelType != null)
            {
                requestEndpointRequest_endpointRequest_ChannelType = cmdletContext.EndpointRequest_ChannelType;
            }
            if (requestEndpointRequest_endpointRequest_ChannelType != null)
            {
                request.EndpointRequest.ChannelType = requestEndpointRequest_endpointRequest_ChannelType;
                requestEndpointRequestIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_EffectiveDate = null;
            if (cmdletContext.EndpointRequest_EffectiveDate != null)
            {
                requestEndpointRequest_endpointRequest_EffectiveDate = cmdletContext.EndpointRequest_EffectiveDate;
            }
            if (requestEndpointRequest_endpointRequest_EffectiveDate != null)
            {
                request.EndpointRequest.EffectiveDate = requestEndpointRequest_endpointRequest_EffectiveDate;
                requestEndpointRequestIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_EndpointStatus = null;
            if (cmdletContext.EndpointRequest_EndpointStatus != null)
            {
                requestEndpointRequest_endpointRequest_EndpointStatus = cmdletContext.EndpointRequest_EndpointStatus;
            }
            if (requestEndpointRequest_endpointRequest_EndpointStatus != null)
            {
                request.EndpointRequest.EndpointStatus = requestEndpointRequest_endpointRequest_EndpointStatus;
                requestEndpointRequestIsNull = false;
            }
            Dictionary<System.String, System.Double> requestEndpointRequest_endpointRequest_Metric = null;
            if (cmdletContext.EndpointRequest_Metric != null)
            {
                requestEndpointRequest_endpointRequest_Metric = cmdletContext.EndpointRequest_Metric;
            }
            if (requestEndpointRequest_endpointRequest_Metric != null)
            {
                request.EndpointRequest.Metrics = requestEndpointRequest_endpointRequest_Metric;
                requestEndpointRequestIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_OptOut = null;
            if (cmdletContext.EndpointRequest_OptOut != null)
            {
                requestEndpointRequest_endpointRequest_OptOut = cmdletContext.EndpointRequest_OptOut;
            }
            if (requestEndpointRequest_endpointRequest_OptOut != null)
            {
                request.EndpointRequest.OptOut = requestEndpointRequest_endpointRequest_OptOut;
                requestEndpointRequestIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_RequestId = null;
            if (cmdletContext.EndpointRequest_RequestId != null)
            {
                requestEndpointRequest_endpointRequest_RequestId = cmdletContext.EndpointRequest_RequestId;
            }
            if (requestEndpointRequest_endpointRequest_RequestId != null)
            {
                request.EndpointRequest.RequestId = requestEndpointRequest_endpointRequest_RequestId;
                requestEndpointRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.EndpointUser requestEndpointRequest_endpointRequest_User = null;
            
             // populate User
            var requestEndpointRequest_endpointRequest_UserIsNull = true;
            requestEndpointRequest_endpointRequest_User = new Amazon.Pinpoint.Model.EndpointUser();
            Dictionary<System.String, List<System.String>> requestEndpointRequest_endpointRequest_User_user_UserAttribute = null;
            if (cmdletContext.User_UserAttribute != null)
            {
                requestEndpointRequest_endpointRequest_User_user_UserAttribute = cmdletContext.User_UserAttribute;
            }
            if (requestEndpointRequest_endpointRequest_User_user_UserAttribute != null)
            {
                requestEndpointRequest_endpointRequest_User.UserAttributes = requestEndpointRequest_endpointRequest_User_user_UserAttribute;
                requestEndpointRequest_endpointRequest_UserIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_User_user_UserId = null;
            if (cmdletContext.User_UserId != null)
            {
                requestEndpointRequest_endpointRequest_User_user_UserId = cmdletContext.User_UserId;
            }
            if (requestEndpointRequest_endpointRequest_User_user_UserId != null)
            {
                requestEndpointRequest_endpointRequest_User.UserId = requestEndpointRequest_endpointRequest_User_user_UserId;
                requestEndpointRequest_endpointRequest_UserIsNull = false;
            }
             // determine if requestEndpointRequest_endpointRequest_User should be set to null
            if (requestEndpointRequest_endpointRequest_UserIsNull)
            {
                requestEndpointRequest_endpointRequest_User = null;
            }
            if (requestEndpointRequest_endpointRequest_User != null)
            {
                request.EndpointRequest.User = requestEndpointRequest_endpointRequest_User;
                requestEndpointRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.EndpointLocation requestEndpointRequest_endpointRequest_Location = null;
            
             // populate Location
            var requestEndpointRequest_endpointRequest_LocationIsNull = true;
            requestEndpointRequest_endpointRequest_Location = new Amazon.Pinpoint.Model.EndpointLocation();
            System.String requestEndpointRequest_endpointRequest_Location_location_City = null;
            if (cmdletContext.Location_City != null)
            {
                requestEndpointRequest_endpointRequest_Location_location_City = cmdletContext.Location_City;
            }
            if (requestEndpointRequest_endpointRequest_Location_location_City != null)
            {
                requestEndpointRequest_endpointRequest_Location.City = requestEndpointRequest_endpointRequest_Location_location_City;
                requestEndpointRequest_endpointRequest_LocationIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Location_location_Country = null;
            if (cmdletContext.Location_Country != null)
            {
                requestEndpointRequest_endpointRequest_Location_location_Country = cmdletContext.Location_Country;
            }
            if (requestEndpointRequest_endpointRequest_Location_location_Country != null)
            {
                requestEndpointRequest_endpointRequest_Location.Country = requestEndpointRequest_endpointRequest_Location_location_Country;
                requestEndpointRequest_endpointRequest_LocationIsNull = false;
            }
            System.Double? requestEndpointRequest_endpointRequest_Location_location_Latitude = null;
            if (cmdletContext.Location_Latitude != null)
            {
                requestEndpointRequest_endpointRequest_Location_location_Latitude = cmdletContext.Location_Latitude.Value;
            }
            if (requestEndpointRequest_endpointRequest_Location_location_Latitude != null)
            {
                requestEndpointRequest_endpointRequest_Location.Latitude = requestEndpointRequest_endpointRequest_Location_location_Latitude.Value;
                requestEndpointRequest_endpointRequest_LocationIsNull = false;
            }
            System.Double? requestEndpointRequest_endpointRequest_Location_location_Longitude = null;
            if (cmdletContext.Location_Longitude != null)
            {
                requestEndpointRequest_endpointRequest_Location_location_Longitude = cmdletContext.Location_Longitude.Value;
            }
            if (requestEndpointRequest_endpointRequest_Location_location_Longitude != null)
            {
                requestEndpointRequest_endpointRequest_Location.Longitude = requestEndpointRequest_endpointRequest_Location_location_Longitude.Value;
                requestEndpointRequest_endpointRequest_LocationIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Location_location_PostalCode = null;
            if (cmdletContext.Location_PostalCode != null)
            {
                requestEndpointRequest_endpointRequest_Location_location_PostalCode = cmdletContext.Location_PostalCode;
            }
            if (requestEndpointRequest_endpointRequest_Location_location_PostalCode != null)
            {
                requestEndpointRequest_endpointRequest_Location.PostalCode = requestEndpointRequest_endpointRequest_Location_location_PostalCode;
                requestEndpointRequest_endpointRequest_LocationIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Location_location_Region = null;
            if (cmdletContext.Location_Region != null)
            {
                requestEndpointRequest_endpointRequest_Location_location_Region = cmdletContext.Location_Region;
            }
            if (requestEndpointRequest_endpointRequest_Location_location_Region != null)
            {
                requestEndpointRequest_endpointRequest_Location.Region = requestEndpointRequest_endpointRequest_Location_location_Region;
                requestEndpointRequest_endpointRequest_LocationIsNull = false;
            }
             // determine if requestEndpointRequest_endpointRequest_Location should be set to null
            if (requestEndpointRequest_endpointRequest_LocationIsNull)
            {
                requestEndpointRequest_endpointRequest_Location = null;
            }
            if (requestEndpointRequest_endpointRequest_Location != null)
            {
                request.EndpointRequest.Location = requestEndpointRequest_endpointRequest_Location;
                requestEndpointRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.EndpointDemographic requestEndpointRequest_endpointRequest_Demographic = null;
            
             // populate Demographic
            var requestEndpointRequest_endpointRequest_DemographicIsNull = true;
            requestEndpointRequest_endpointRequest_Demographic = new Amazon.Pinpoint.Model.EndpointDemographic();
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_AppVersion = null;
            if (cmdletContext.Demographic_AppVersion != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_AppVersion = cmdletContext.Demographic_AppVersion;
            }
            if (requestEndpointRequest_endpointRequest_Demographic_demographic_AppVersion != null)
            {
                requestEndpointRequest_endpointRequest_Demographic.AppVersion = requestEndpointRequest_endpointRequest_Demographic_demographic_AppVersion;
                requestEndpointRequest_endpointRequest_DemographicIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_Locale = null;
            if (cmdletContext.Demographic_Locale != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_Locale = cmdletContext.Demographic_Locale;
            }
            if (requestEndpointRequest_endpointRequest_Demographic_demographic_Locale != null)
            {
                requestEndpointRequest_endpointRequest_Demographic.Locale = requestEndpointRequest_endpointRequest_Demographic_demographic_Locale;
                requestEndpointRequest_endpointRequest_DemographicIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_Make = null;
            if (cmdletContext.Demographic_Make != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_Make = cmdletContext.Demographic_Make;
            }
            if (requestEndpointRequest_endpointRequest_Demographic_demographic_Make != null)
            {
                requestEndpointRequest_endpointRequest_Demographic.Make = requestEndpointRequest_endpointRequest_Demographic_demographic_Make;
                requestEndpointRequest_endpointRequest_DemographicIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_Model = null;
            if (cmdletContext.Demographic_Model != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_Model = cmdletContext.Demographic_Model;
            }
            if (requestEndpointRequest_endpointRequest_Demographic_demographic_Model != null)
            {
                requestEndpointRequest_endpointRequest_Demographic.Model = requestEndpointRequest_endpointRequest_Demographic_demographic_Model;
                requestEndpointRequest_endpointRequest_DemographicIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_ModelVersion = null;
            if (cmdletContext.Demographic_ModelVersion != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_ModelVersion = cmdletContext.Demographic_ModelVersion;
            }
            if (requestEndpointRequest_endpointRequest_Demographic_demographic_ModelVersion != null)
            {
                requestEndpointRequest_endpointRequest_Demographic.ModelVersion = requestEndpointRequest_endpointRequest_Demographic_demographic_ModelVersion;
                requestEndpointRequest_endpointRequest_DemographicIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_Platform = null;
            if (cmdletContext.Demographic_Platform != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_Platform = cmdletContext.Demographic_Platform;
            }
            if (requestEndpointRequest_endpointRequest_Demographic_demographic_Platform != null)
            {
                requestEndpointRequest_endpointRequest_Demographic.Platform = requestEndpointRequest_endpointRequest_Demographic_demographic_Platform;
                requestEndpointRequest_endpointRequest_DemographicIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_PlatformVersion = null;
            if (cmdletContext.Demographic_PlatformVersion != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_PlatformVersion = cmdletContext.Demographic_PlatformVersion;
            }
            if (requestEndpointRequest_endpointRequest_Demographic_demographic_PlatformVersion != null)
            {
                requestEndpointRequest_endpointRequest_Demographic.PlatformVersion = requestEndpointRequest_endpointRequest_Demographic_demographic_PlatformVersion;
                requestEndpointRequest_endpointRequest_DemographicIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_Timezone = null;
            if (cmdletContext.Demographic_Timezone != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_Timezone = cmdletContext.Demographic_Timezone;
            }
            if (requestEndpointRequest_endpointRequest_Demographic_demographic_Timezone != null)
            {
                requestEndpointRequest_endpointRequest_Demographic.Timezone = requestEndpointRequest_endpointRequest_Demographic_demographic_Timezone;
                requestEndpointRequest_endpointRequest_DemographicIsNull = false;
            }
             // determine if requestEndpointRequest_endpointRequest_Demographic should be set to null
            if (requestEndpointRequest_endpointRequest_DemographicIsNull)
            {
                requestEndpointRequest_endpointRequest_Demographic = null;
            }
            if (requestEndpointRequest_endpointRequest_Demographic != null)
            {
                request.EndpointRequest.Demographic = requestEndpointRequest_endpointRequest_Demographic;
                requestEndpointRequestIsNull = false;
            }
             // determine if request.EndpointRequest should be set to null
            if (requestEndpointRequestIsNull)
            {
                request.EndpointRequest = null;
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
        
        private Amazon.Pinpoint.Model.UpdateEndpointResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateEndpoint");
            try
            {
                #if DESKTOP
                return client.UpdateEndpoint(request);
                #elif CORECLR
                return client.UpdateEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String EndpointId { get; set; }
            public System.String EndpointRequest_Address { get; set; }
            public Dictionary<System.String, List<System.String>> EndpointRequest_Attribute { get; set; }
            public Amazon.Pinpoint.ChannelType EndpointRequest_ChannelType { get; set; }
            public System.String Demographic_AppVersion { get; set; }
            public System.String Demographic_Locale { get; set; }
            public System.String Demographic_Make { get; set; }
            public System.String Demographic_Model { get; set; }
            public System.String Demographic_ModelVersion { get; set; }
            public System.String Demographic_Platform { get; set; }
            public System.String Demographic_PlatformVersion { get; set; }
            public System.String Demographic_Timezone { get; set; }
            public System.String EndpointRequest_EffectiveDate { get; set; }
            public System.String EndpointRequest_EndpointStatus { get; set; }
            public System.String Location_City { get; set; }
            public System.String Location_Country { get; set; }
            public System.Double? Location_Latitude { get; set; }
            public System.Double? Location_Longitude { get; set; }
            public System.String Location_PostalCode { get; set; }
            public System.String Location_Region { get; set; }
            public Dictionary<System.String, System.Double> EndpointRequest_Metric { get; set; }
            public System.String EndpointRequest_OptOut { get; set; }
            public System.String EndpointRequest_RequestId { get; set; }
            public Dictionary<System.String, List<System.String>> User_UserAttribute { get; set; }
            public System.String User_UserId { get; set; }
            public System.Func<Amazon.Pinpoint.Model.UpdateEndpointResponse, UpdatePINEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageBody;
        }
        
    }
}
