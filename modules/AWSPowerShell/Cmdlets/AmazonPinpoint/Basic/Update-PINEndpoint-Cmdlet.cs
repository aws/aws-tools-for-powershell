/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Use to update an endpoint.
    /// </summary>
    [Cmdlet("Update", "PINEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.MessageBody")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateEndpoint API operation.", Operation = new[] {"UpdateEndpoint"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.MessageBody",
        "This cmdlet returns a MessageBody object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateEndpointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINEndpointCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter EndpointRequest_Address
        /// <summary>
        /// <para>
        /// The address or token of the endpoint as provided
        /// by your push provider (e.g. DeviceToken or RegistrationId).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EndpointRequest_Address { get; set; }
        #endregion
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter Demographic_AppVersion
        /// <summary>
        /// <para>
        /// The version of the application associated with
        /// the endpoint.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Demographic_AppVersion")]
        public System.String Demographic_AppVersion { get; set; }
        #endregion
        
        #region Parameter EndpointRequest_Attribute
        /// <summary>
        /// <para>
        /// Custom attributes that your app reports to
        /// Amazon Pinpoint. You can use these attributes as selection criteria when you create
        /// a segment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Attributes")]
        public System.Collections.Hashtable EndpointRequest_Attribute { get; set; }
        #endregion
        
        #region Parameter EndpointRequest_ChannelType
        /// <summary>
        /// <para>
        /// The channel type.Valid values: GCM | APNS
        /// | SMS | EMAIL
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Pinpoint.ChannelType")]
        public Amazon.Pinpoint.ChannelType EndpointRequest_ChannelType { get; set; }
        #endregion
        
        #region Parameter Location_City
        /// <summary>
        /// <para>
        /// The city where the endpoint is located.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Location_City")]
        public System.String Location_City { get; set; }
        #endregion
        
        #region Parameter Location_Country
        /// <summary>
        /// <para>
        /// Country according to ISO 3166-1 Alpha-2 codes.
        /// For example, US.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Location_Country")]
        public System.String Location_Country { get; set; }
        #endregion
        
        #region Parameter EndpointRequest_EffectiveDate
        /// <summary>
        /// <para>
        /// The last time the endpoint was updated.
        /// Provided in ISO 8601 format.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EndpointRequest_EffectiveDate { get; set; }
        #endregion
        
        #region Parameter EndpointId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EndpointId { get; set; }
        #endregion
        
        #region Parameter EndpointRequest_EndpointStatus
        /// <summary>
        /// <para>
        /// The endpoint status. Can be either ACTIVE
        /// or INACTIVE. Will be set to INACTIVE if a delivery fails. Will be set to ACTIVE if
        /// the address is updated.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EndpointRequest_EndpointStatus { get; set; }
        #endregion
        
        #region Parameter Location_Latitude
        /// <summary>
        /// <para>
        /// The latitude of the endpoint location. Rounded
        /// to one decimal (Roughly corresponding to a mile).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Location_Latitude")]
        public System.Double Location_Latitude { get; set; }
        #endregion
        
        #region Parameter Demographic_Locale
        /// <summary>
        /// <para>
        /// The endpoint locale in the following format: The
        /// ISO 639-1 alpha-2 code, followed by an underscore, followed by an ISO 3166-1 alpha-2
        /// value.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Demographic_Locale")]
        public System.String Demographic_Locale { get; set; }
        #endregion
        
        #region Parameter Location_Longitude
        /// <summary>
        /// <para>
        /// The longitude of the endpoint location. Rounded
        /// to one decimal (Roughly corresponding to a mile).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Location_Longitude")]
        public System.Double Location_Longitude { get; set; }
        #endregion
        
        #region Parameter Demographic_Make
        /// <summary>
        /// <para>
        /// The endpoint make, such as such as Apple or Samsung.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Demographic_Make")]
        public System.String Demographic_Make { get; set; }
        #endregion
        
        #region Parameter EndpointRequest_Metric
        /// <summary>
        /// <para>
        /// Custom metrics that your app reports to Amazon
        /// Pinpoint.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Metrics")]
        public System.Collections.Hashtable EndpointRequest_Metric { get; set; }
        #endregion
        
        #region Parameter Demographic_Model
        /// <summary>
        /// <para>
        /// The endpoint model, such as iPhone.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Demographic_Model")]
        public System.String Demographic_Model { get; set; }
        #endregion
        
        #region Parameter Demographic_ModelVersion
        /// <summary>
        /// <para>
        /// The endpoint model version.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Demographic_ModelVersion")]
        public System.String Demographic_ModelVersion { get; set; }
        #endregion
        
        #region Parameter EndpointRequest_OptOut
        /// <summary>
        /// <para>
        /// Indicates whether a user has opted out of receiving
        /// messages with one of the following values:ALL - User has opted out of all messages.NONE
        /// - Users has not opted out and receives all messages.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EndpointRequest_OptOut { get; set; }
        #endregion
        
        #region Parameter Demographic_Platform
        /// <summary>
        /// <para>
        /// The endpoint platform, such as ios or android.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Demographic_Platform")]
        public System.String Demographic_Platform { get; set; }
        #endregion
        
        #region Parameter Demographic_PlatformVersion
        /// <summary>
        /// <para>
        /// The endpoint platform version.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Demographic_PlatformVersion")]
        public System.String Demographic_PlatformVersion { get; set; }
        #endregion
        
        #region Parameter Location_PostalCode
        /// <summary>
        /// <para>
        /// The postal code or zip code of the endpoint.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Location_PostalCode")]
        public System.String Location_PostalCode { get; set; }
        #endregion
        
        #region Parameter Location_Region
        /// <summary>
        /// <para>
        /// The region of the endpoint location. For example,
        /// corresponds to a state in US.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Location_Region")]
        public System.String Location_Region { get; set; }
        #endregion
        
        #region Parameter EndpointRequest_RequestId
        /// <summary>
        /// <para>
        /// The unique ID for the most recent request to
        /// update the endpoint.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EndpointRequest_RequestId { get; set; }
        #endregion
        
        #region Parameter Demographic_Timezone
        /// <summary>
        /// <para>
        /// The timezone of the endpoint. Specified as a
        /// tz database value, such as Americas/Los_Angeles.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_Demographic_Timezone")]
        public System.String Demographic_Timezone { get; set; }
        #endregion
        
        #region Parameter User_UserAttribute
        /// <summary>
        /// <para>
        /// Custom attributes specific to the user.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_User_UserAttributes")]
        public System.Collections.Hashtable User_UserAttribute { get; set; }
        #endregion
        
        #region Parameter User_UserId
        /// <summary>
        /// <para>
        /// The unique ID of the user.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointRequest_User_UserId")]
        public System.String User_UserId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINEndpoint (UpdateEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ApplicationId = this.ApplicationId;
            context.EndpointId = this.EndpointId;
            context.EndpointRequest_Address = this.EndpointRequest_Address;
            if (this.EndpointRequest_Attribute != null)
            {
                context.EndpointRequest_Attributes = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.EndpointRequest_Attribute.Keys)
                {
                    object hashValue = this.EndpointRequest_Attribute[hashKey];
                    if (hashValue == null)
                    {
                        context.EndpointRequest_Attributes.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.EndpointRequest_Attributes.Add((String)hashKey, valueSet);
                }
            }
            context.EndpointRequest_ChannelType = this.EndpointRequest_ChannelType;
            context.EndpointRequest_Demographic_AppVersion = this.Demographic_AppVersion;
            context.EndpointRequest_Demographic_Locale = this.Demographic_Locale;
            context.EndpointRequest_Demographic_Make = this.Demographic_Make;
            context.EndpointRequest_Demographic_Model = this.Demographic_Model;
            context.EndpointRequest_Demographic_ModelVersion = this.Demographic_ModelVersion;
            context.EndpointRequest_Demographic_Platform = this.Demographic_Platform;
            context.EndpointRequest_Demographic_PlatformVersion = this.Demographic_PlatformVersion;
            context.EndpointRequest_Demographic_Timezone = this.Demographic_Timezone;
            context.EndpointRequest_EffectiveDate = this.EndpointRequest_EffectiveDate;
            context.EndpointRequest_EndpointStatus = this.EndpointRequest_EndpointStatus;
            context.EndpointRequest_Location_City = this.Location_City;
            context.EndpointRequest_Location_Country = this.Location_Country;
            if (ParameterWasBound("Location_Latitude"))
                context.EndpointRequest_Location_Latitude = this.Location_Latitude;
            if (ParameterWasBound("Location_Longitude"))
                context.EndpointRequest_Location_Longitude = this.Location_Longitude;
            context.EndpointRequest_Location_PostalCode = this.Location_PostalCode;
            context.EndpointRequest_Location_Region = this.Location_Region;
            if (this.EndpointRequest_Metric != null)
            {
                context.EndpointRequest_Metrics = new Dictionary<System.String, System.Double>(StringComparer.Ordinal);
                foreach (var hashKey in this.EndpointRequest_Metric.Keys)
                {
                    context.EndpointRequest_Metrics.Add((String)hashKey, (Double)(this.EndpointRequest_Metric[hashKey]));
                }
            }
            context.EndpointRequest_OptOut = this.EndpointRequest_OptOut;
            context.EndpointRequest_RequestId = this.EndpointRequest_RequestId;
            if (this.User_UserAttribute != null)
            {
                context.EndpointRequest_User_UserAttributes = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.User_UserAttribute.Keys)
                {
                    object hashValue = this.User_UserAttribute[hashKey];
                    if (hashValue == null)
                    {
                        context.EndpointRequest_User_UserAttributes.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.EndpointRequest_User_UserAttributes.Add((String)hashKey, valueSet);
                }
            }
            context.EndpointRequest_User_UserId = this.User_UserId;
            
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
            bool requestEndpointRequestIsNull = true;
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
            if (cmdletContext.EndpointRequest_Attributes != null)
            {
                requestEndpointRequest_endpointRequest_Attribute = cmdletContext.EndpointRequest_Attributes;
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
            if (cmdletContext.EndpointRequest_Metrics != null)
            {
                requestEndpointRequest_endpointRequest_Metric = cmdletContext.EndpointRequest_Metrics;
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
            bool requestEndpointRequest_endpointRequest_UserIsNull = true;
            requestEndpointRequest_endpointRequest_User = new Amazon.Pinpoint.Model.EndpointUser();
            Dictionary<System.String, List<System.String>> requestEndpointRequest_endpointRequest_User_user_UserAttribute = null;
            if (cmdletContext.EndpointRequest_User_UserAttributes != null)
            {
                requestEndpointRequest_endpointRequest_User_user_UserAttribute = cmdletContext.EndpointRequest_User_UserAttributes;
            }
            if (requestEndpointRequest_endpointRequest_User_user_UserAttribute != null)
            {
                requestEndpointRequest_endpointRequest_User.UserAttributes = requestEndpointRequest_endpointRequest_User_user_UserAttribute;
                requestEndpointRequest_endpointRequest_UserIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_User_user_UserId = null;
            if (cmdletContext.EndpointRequest_User_UserId != null)
            {
                requestEndpointRequest_endpointRequest_User_user_UserId = cmdletContext.EndpointRequest_User_UserId;
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
            bool requestEndpointRequest_endpointRequest_LocationIsNull = true;
            requestEndpointRequest_endpointRequest_Location = new Amazon.Pinpoint.Model.EndpointLocation();
            System.String requestEndpointRequest_endpointRequest_Location_location_City = null;
            if (cmdletContext.EndpointRequest_Location_City != null)
            {
                requestEndpointRequest_endpointRequest_Location_location_City = cmdletContext.EndpointRequest_Location_City;
            }
            if (requestEndpointRequest_endpointRequest_Location_location_City != null)
            {
                requestEndpointRequest_endpointRequest_Location.City = requestEndpointRequest_endpointRequest_Location_location_City;
                requestEndpointRequest_endpointRequest_LocationIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Location_location_Country = null;
            if (cmdletContext.EndpointRequest_Location_Country != null)
            {
                requestEndpointRequest_endpointRequest_Location_location_Country = cmdletContext.EndpointRequest_Location_Country;
            }
            if (requestEndpointRequest_endpointRequest_Location_location_Country != null)
            {
                requestEndpointRequest_endpointRequest_Location.Country = requestEndpointRequest_endpointRequest_Location_location_Country;
                requestEndpointRequest_endpointRequest_LocationIsNull = false;
            }
            System.Double? requestEndpointRequest_endpointRequest_Location_location_Latitude = null;
            if (cmdletContext.EndpointRequest_Location_Latitude != null)
            {
                requestEndpointRequest_endpointRequest_Location_location_Latitude = cmdletContext.EndpointRequest_Location_Latitude.Value;
            }
            if (requestEndpointRequest_endpointRequest_Location_location_Latitude != null)
            {
                requestEndpointRequest_endpointRequest_Location.Latitude = requestEndpointRequest_endpointRequest_Location_location_Latitude.Value;
                requestEndpointRequest_endpointRequest_LocationIsNull = false;
            }
            System.Double? requestEndpointRequest_endpointRequest_Location_location_Longitude = null;
            if (cmdletContext.EndpointRequest_Location_Longitude != null)
            {
                requestEndpointRequest_endpointRequest_Location_location_Longitude = cmdletContext.EndpointRequest_Location_Longitude.Value;
            }
            if (requestEndpointRequest_endpointRequest_Location_location_Longitude != null)
            {
                requestEndpointRequest_endpointRequest_Location.Longitude = requestEndpointRequest_endpointRequest_Location_location_Longitude.Value;
                requestEndpointRequest_endpointRequest_LocationIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Location_location_PostalCode = null;
            if (cmdletContext.EndpointRequest_Location_PostalCode != null)
            {
                requestEndpointRequest_endpointRequest_Location_location_PostalCode = cmdletContext.EndpointRequest_Location_PostalCode;
            }
            if (requestEndpointRequest_endpointRequest_Location_location_PostalCode != null)
            {
                requestEndpointRequest_endpointRequest_Location.PostalCode = requestEndpointRequest_endpointRequest_Location_location_PostalCode;
                requestEndpointRequest_endpointRequest_LocationIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Location_location_Region = null;
            if (cmdletContext.EndpointRequest_Location_Region != null)
            {
                requestEndpointRequest_endpointRequest_Location_location_Region = cmdletContext.EndpointRequest_Location_Region;
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
            bool requestEndpointRequest_endpointRequest_DemographicIsNull = true;
            requestEndpointRequest_endpointRequest_Demographic = new Amazon.Pinpoint.Model.EndpointDemographic();
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_AppVersion = null;
            if (cmdletContext.EndpointRequest_Demographic_AppVersion != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_AppVersion = cmdletContext.EndpointRequest_Demographic_AppVersion;
            }
            if (requestEndpointRequest_endpointRequest_Demographic_demographic_AppVersion != null)
            {
                requestEndpointRequest_endpointRequest_Demographic.AppVersion = requestEndpointRequest_endpointRequest_Demographic_demographic_AppVersion;
                requestEndpointRequest_endpointRequest_DemographicIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_Locale = null;
            if (cmdletContext.EndpointRequest_Demographic_Locale != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_Locale = cmdletContext.EndpointRequest_Demographic_Locale;
            }
            if (requestEndpointRequest_endpointRequest_Demographic_demographic_Locale != null)
            {
                requestEndpointRequest_endpointRequest_Demographic.Locale = requestEndpointRequest_endpointRequest_Demographic_demographic_Locale;
                requestEndpointRequest_endpointRequest_DemographicIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_Make = null;
            if (cmdletContext.EndpointRequest_Demographic_Make != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_Make = cmdletContext.EndpointRequest_Demographic_Make;
            }
            if (requestEndpointRequest_endpointRequest_Demographic_demographic_Make != null)
            {
                requestEndpointRequest_endpointRequest_Demographic.Make = requestEndpointRequest_endpointRequest_Demographic_demographic_Make;
                requestEndpointRequest_endpointRequest_DemographicIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_Model = null;
            if (cmdletContext.EndpointRequest_Demographic_Model != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_Model = cmdletContext.EndpointRequest_Demographic_Model;
            }
            if (requestEndpointRequest_endpointRequest_Demographic_demographic_Model != null)
            {
                requestEndpointRequest_endpointRequest_Demographic.Model = requestEndpointRequest_endpointRequest_Demographic_demographic_Model;
                requestEndpointRequest_endpointRequest_DemographicIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_ModelVersion = null;
            if (cmdletContext.EndpointRequest_Demographic_ModelVersion != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_ModelVersion = cmdletContext.EndpointRequest_Demographic_ModelVersion;
            }
            if (requestEndpointRequest_endpointRequest_Demographic_demographic_ModelVersion != null)
            {
                requestEndpointRequest_endpointRequest_Demographic.ModelVersion = requestEndpointRequest_endpointRequest_Demographic_demographic_ModelVersion;
                requestEndpointRequest_endpointRequest_DemographicIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_Platform = null;
            if (cmdletContext.EndpointRequest_Demographic_Platform != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_Platform = cmdletContext.EndpointRequest_Demographic_Platform;
            }
            if (requestEndpointRequest_endpointRequest_Demographic_demographic_Platform != null)
            {
                requestEndpointRequest_endpointRequest_Demographic.Platform = requestEndpointRequest_endpointRequest_Demographic_demographic_Platform;
                requestEndpointRequest_endpointRequest_DemographicIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_PlatformVersion = null;
            if (cmdletContext.EndpointRequest_Demographic_PlatformVersion != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_PlatformVersion = cmdletContext.EndpointRequest_Demographic_PlatformVersion;
            }
            if (requestEndpointRequest_endpointRequest_Demographic_demographic_PlatformVersion != null)
            {
                requestEndpointRequest_endpointRequest_Demographic.PlatformVersion = requestEndpointRequest_endpointRequest_Demographic_demographic_PlatformVersion;
                requestEndpointRequest_endpointRequest_DemographicIsNull = false;
            }
            System.String requestEndpointRequest_endpointRequest_Demographic_demographic_Timezone = null;
            if (cmdletContext.EndpointRequest_Demographic_Timezone != null)
            {
                requestEndpointRequest_endpointRequest_Demographic_demographic_Timezone = cmdletContext.EndpointRequest_Demographic_Timezone;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.MessageBody;
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
        
        #region AWS Service Operation Call
        
        private Amazon.Pinpoint.Model.UpdateEndpointResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateEndpoint");
            try
            {
                #if DESKTOP
                return client.UpdateEndpoint(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateEndpointAsync(request);
                return task.Result;
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
            public Dictionary<System.String, List<System.String>> EndpointRequest_Attributes { get; set; }
            public Amazon.Pinpoint.ChannelType EndpointRequest_ChannelType { get; set; }
            public System.String EndpointRequest_Demographic_AppVersion { get; set; }
            public System.String EndpointRequest_Demographic_Locale { get; set; }
            public System.String EndpointRequest_Demographic_Make { get; set; }
            public System.String EndpointRequest_Demographic_Model { get; set; }
            public System.String EndpointRequest_Demographic_ModelVersion { get; set; }
            public System.String EndpointRequest_Demographic_Platform { get; set; }
            public System.String EndpointRequest_Demographic_PlatformVersion { get; set; }
            public System.String EndpointRequest_Demographic_Timezone { get; set; }
            public System.String EndpointRequest_EffectiveDate { get; set; }
            public System.String EndpointRequest_EndpointStatus { get; set; }
            public System.String EndpointRequest_Location_City { get; set; }
            public System.String EndpointRequest_Location_Country { get; set; }
            public System.Double? EndpointRequest_Location_Latitude { get; set; }
            public System.Double? EndpointRequest_Location_Longitude { get; set; }
            public System.String EndpointRequest_Location_PostalCode { get; set; }
            public System.String EndpointRequest_Location_Region { get; set; }
            public Dictionary<System.String, System.Double> EndpointRequest_Metrics { get; set; }
            public System.String EndpointRequest_OptOut { get; set; }
            public System.String EndpointRequest_RequestId { get; set; }
            public Dictionary<System.String, List<System.String>> EndpointRequest_User_UserAttributes { get; set; }
            public System.String EndpointRequest_User_UserId { get; set; }
        }
        
    }
}
