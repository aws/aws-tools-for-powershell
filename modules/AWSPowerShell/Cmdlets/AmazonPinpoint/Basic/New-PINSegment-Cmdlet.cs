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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Used to create or update a segment.
    /// </summary>
    [Cmdlet("New", "PINSegment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.SegmentResponse")]
    [AWSCmdlet("Invokes the CreateSegment operation against Amazon Pinpoint.", Operation = new[] {"CreateSegment"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.SegmentResponse",
        "This cmdlet returns a SegmentResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.CreateSegmentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPINSegmentCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter Dimensions_Attribute
        /// <summary>
        /// <para>
        /// Custom segment attributes.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Attributes")]
        public System.Collections.Hashtable Dimensions_Attribute { get; set; }
        #endregion
        
        #region Parameter AppVersion_DimensionType
        /// <summary>
        /// <para>
        /// The type of dimension:INCLUSIVE - Endpoints
        /// that match the criteria are included in the segment.EXCLUSIVE - Endpoints that match
        /// the criteria are excluded from the segment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_AppVersion_DimensionType")]
        [AWSConstantClassSource("Amazon.Pinpoint.DimensionType")]
        public Amazon.Pinpoint.DimensionType AppVersion_DimensionType { get; set; }
        #endregion
        
        #region Parameter Channel_DimensionType
        /// <summary>
        /// <para>
        /// The type of dimension:INCLUSIVE - Endpoints
        /// that match the criteria are included in the segment.EXCLUSIVE - Endpoints that match
        /// the criteria are excluded from the segment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Channel_DimensionType")]
        [AWSConstantClassSource("Amazon.Pinpoint.DimensionType")]
        public Amazon.Pinpoint.DimensionType Channel_DimensionType { get; set; }
        #endregion
        
        #region Parameter DeviceType_DimensionType
        /// <summary>
        /// <para>
        /// The type of dimension:INCLUSIVE - Endpoints
        /// that match the criteria are included in the segment.EXCLUSIVE - Endpoints that match
        /// the criteria are excluded from the segment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_DeviceType_DimensionType")]
        [AWSConstantClassSource("Amazon.Pinpoint.DimensionType")]
        public Amazon.Pinpoint.DimensionType DeviceType_DimensionType { get; set; }
        #endregion
        
        #region Parameter Make_DimensionType
        /// <summary>
        /// <para>
        /// The type of dimension:INCLUSIVE - Endpoints
        /// that match the criteria are included in the segment.EXCLUSIVE - Endpoints that match
        /// the criteria are excluded from the segment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Make_DimensionType")]
        [AWSConstantClassSource("Amazon.Pinpoint.DimensionType")]
        public Amazon.Pinpoint.DimensionType Make_DimensionType { get; set; }
        #endregion
        
        #region Parameter Model_DimensionType
        /// <summary>
        /// <para>
        /// The type of dimension:INCLUSIVE - Endpoints
        /// that match the criteria are included in the segment.EXCLUSIVE - Endpoints that match
        /// the criteria are excluded from the segment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Model_DimensionType")]
        [AWSConstantClassSource("Amazon.Pinpoint.DimensionType")]
        public Amazon.Pinpoint.DimensionType Model_DimensionType { get; set; }
        #endregion
        
        #region Parameter Platform_DimensionType
        /// <summary>
        /// <para>
        /// The type of dimension:INCLUSIVE - Endpoints
        /// that match the criteria are included in the segment.EXCLUSIVE - Endpoints that match
        /// the criteria are excluded from the segment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Platform_DimensionType")]
        [AWSConstantClassSource("Amazon.Pinpoint.DimensionType")]
        public Amazon.Pinpoint.DimensionType Platform_DimensionType { get; set; }
        #endregion
        
        #region Parameter Country_DimensionType
        /// <summary>
        /// <para>
        /// The type of dimension:INCLUSIVE - Endpoints
        /// that match the criteria are included in the segment.EXCLUSIVE - Endpoints that match
        /// the criteria are excluded from the segment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Location_Country_DimensionType")]
        [AWSConstantClassSource("Amazon.Pinpoint.DimensionType")]
        public Amazon.Pinpoint.DimensionType Country_DimensionType { get; set; }
        #endregion
        
        #region Parameter Recency_Duration
        /// <summary>
        /// <para>
        /// The length of time during which users have been
        /// active or inactive with your app.Valid values: HR_24, DAY_7, DAY_14, DAY_30
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Behavior_Recency_Duration")]
        [AWSConstantClassSource("Amazon.Pinpoint.Duration")]
        public Amazon.Pinpoint.Duration Recency_Duration { get; set; }
        #endregion
        
        #region Parameter WriteSegmentRequest_Name
        /// <summary>
        /// <para>
        /// The name of segment
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String WriteSegmentRequest_Name { get; set; }
        #endregion
        
        #region Parameter Recency_RecencyType
        /// <summary>
        /// <para>
        /// The recency dimension type:ACTIVE - Users
        /// who have used your app within the specified duration are included in the segment.INACTIVE
        /// - Users who have not used your app within the specified duration are included in the
        /// segment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Behavior_Recency_RecencyType")]
        [AWSConstantClassSource("Amazon.Pinpoint.RecencyType")]
        public Amazon.Pinpoint.RecencyType Recency_RecencyType { get; set; }
        #endregion
        
        #region Parameter Dimensions_UserAttribute
        /// <summary>
        /// <para>
        /// Custom segment user attributes.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_UserAttributes")]
        public System.Collections.Hashtable Dimensions_UserAttribute { get; set; }
        #endregion
        
        #region Parameter AppVersion_Value
        /// <summary>
        /// <para>
        /// The criteria values for the segment dimension.
        /// Endpoints with matching attribute values are included or excluded from the segment,
        /// depending on the setting for Type.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_AppVersion_Values")]
        public System.String[] AppVersion_Value { get; set; }
        #endregion
        
        #region Parameter Channel_Value
        /// <summary>
        /// <para>
        /// The criteria values for the segment dimension.
        /// Endpoints with matching attribute values are included or excluded from the segment,
        /// depending on the setting for Type.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Channel_Values")]
        public System.String[] Channel_Value { get; set; }
        #endregion
        
        #region Parameter DeviceType_Value
        /// <summary>
        /// <para>
        /// The criteria values for the segment dimension.
        /// Endpoints with matching attribute values are included or excluded from the segment,
        /// depending on the setting for Type.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_DeviceType_Values")]
        public System.String[] DeviceType_Value { get; set; }
        #endregion
        
        #region Parameter Make_Value
        /// <summary>
        /// <para>
        /// The criteria values for the segment dimension.
        /// Endpoints with matching attribute values are included or excluded from the segment,
        /// depending on the setting for Type.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Make_Values")]
        public System.String[] Make_Value { get; set; }
        #endregion
        
        #region Parameter Model_Value
        /// <summary>
        /// <para>
        /// The criteria values for the segment dimension.
        /// Endpoints with matching attribute values are included or excluded from the segment,
        /// depending on the setting for Type.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Model_Values")]
        public System.String[] Model_Value { get; set; }
        #endregion
        
        #region Parameter Platform_Value
        /// <summary>
        /// <para>
        /// The criteria values for the segment dimension.
        /// Endpoints with matching attribute values are included or excluded from the segment,
        /// depending on the setting for Type.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Platform_Values")]
        public System.String[] Platform_Value { get; set; }
        #endregion
        
        #region Parameter Country_Value
        /// <summary>
        /// <para>
        /// The criteria values for the segment dimension.
        /// Endpoints with matching attribute values are included or excluded from the segment,
        /// depending on the setting for Type.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteSegmentRequest_Dimensions_Location_Country_Values")]
        public System.String[] Country_Value { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINSegment (CreateSegment)"))
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
            if (this.Dimensions_Attribute != null)
            {
                context.WriteSegmentRequest_Dimensions_Attributes = new Dictionary<System.String, Amazon.Pinpoint.Model.AttributeDimension>(StringComparer.Ordinal);
                foreach (var hashKey in this.Dimensions_Attribute.Keys)
                {
                    context.WriteSegmentRequest_Dimensions_Attributes.Add((String)hashKey, (AttributeDimension)(this.Dimensions_Attribute[hashKey]));
                }
            }
            context.WriteSegmentRequest_Dimensions_Behavior_Recency_Duration = this.Recency_Duration;
            context.WriteSegmentRequest_Dimensions_Behavior_Recency_RecencyType = this.Recency_RecencyType;
            context.WriteSegmentRequest_Dimensions_Demographic_AppVersion_DimensionType = this.AppVersion_DimensionType;
            if (this.AppVersion_Value != null)
            {
                context.WriteSegmentRequest_Dimensions_Demographic_AppVersion_Values = new List<System.String>(this.AppVersion_Value);
            }
            context.WriteSegmentRequest_Dimensions_Demographic_Channel_DimensionType = this.Channel_DimensionType;
            if (this.Channel_Value != null)
            {
                context.WriteSegmentRequest_Dimensions_Demographic_Channel_Values = new List<System.String>(this.Channel_Value);
            }
            context.WriteSegmentRequest_Dimensions_Demographic_DeviceType_DimensionType = this.DeviceType_DimensionType;
            if (this.DeviceType_Value != null)
            {
                context.WriteSegmentRequest_Dimensions_Demographic_DeviceType_Values = new List<System.String>(this.DeviceType_Value);
            }
            context.WriteSegmentRequest_Dimensions_Demographic_Make_DimensionType = this.Make_DimensionType;
            if (this.Make_Value != null)
            {
                context.WriteSegmentRequest_Dimensions_Demographic_Make_Values = new List<System.String>(this.Make_Value);
            }
            context.WriteSegmentRequest_Dimensions_Demographic_Model_DimensionType = this.Model_DimensionType;
            if (this.Model_Value != null)
            {
                context.WriteSegmentRequest_Dimensions_Demographic_Model_Values = new List<System.String>(this.Model_Value);
            }
            context.WriteSegmentRequest_Dimensions_Demographic_Platform_DimensionType = this.Platform_DimensionType;
            if (this.Platform_Value != null)
            {
                context.WriteSegmentRequest_Dimensions_Demographic_Platform_Values = new List<System.String>(this.Platform_Value);
            }
            context.WriteSegmentRequest_Dimensions_Location_Country_DimensionType = this.Country_DimensionType;
            if (this.Country_Value != null)
            {
                context.WriteSegmentRequest_Dimensions_Location_Country_Values = new List<System.String>(this.Country_Value);
            }
            if (this.Dimensions_UserAttribute != null)
            {
                context.WriteSegmentRequest_Dimensions_UserAttributes = new Dictionary<System.String, Amazon.Pinpoint.Model.AttributeDimension>(StringComparer.Ordinal);
                foreach (var hashKey in this.Dimensions_UserAttribute.Keys)
                {
                    context.WriteSegmentRequest_Dimensions_UserAttributes.Add((String)hashKey, (AttributeDimension)(this.Dimensions_UserAttribute[hashKey]));
                }
            }
            context.WriteSegmentRequest_Name = this.WriteSegmentRequest_Name;
            
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
            var request = new Amazon.Pinpoint.Model.CreateSegmentRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate WriteSegmentRequest
            bool requestWriteSegmentRequestIsNull = true;
            request.WriteSegmentRequest = new Amazon.Pinpoint.Model.WriteSegmentRequest();
            System.String requestWriteSegmentRequest_writeSegmentRequest_Name = null;
            if (cmdletContext.WriteSegmentRequest_Name != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Name = cmdletContext.WriteSegmentRequest_Name;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Name != null)
            {
                request.WriteSegmentRequest.Name = requestWriteSegmentRequest_writeSegmentRequest_Name;
                requestWriteSegmentRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.SegmentDimensions requestWriteSegmentRequest_writeSegmentRequest_Dimensions = null;
            
             // populate Dimensions
            bool requestWriteSegmentRequest_writeSegmentRequest_DimensionsIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions = new Amazon.Pinpoint.Model.SegmentDimensions();
            Dictionary<System.String, Amazon.Pinpoint.Model.AttributeDimension> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_Attribute = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Attributes != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_Attribute = cmdletContext.WriteSegmentRequest_Dimensions_Attributes;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_Attribute != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions.Attributes = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_Attribute;
                requestWriteSegmentRequest_writeSegmentRequest_DimensionsIsNull = false;
            }
            Dictionary<System.String, Amazon.Pinpoint.Model.AttributeDimension> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_UserAttribute = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_UserAttributes != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_UserAttribute = cmdletContext.WriteSegmentRequest_Dimensions_UserAttributes;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_UserAttribute != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions.UserAttributes = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_UserAttribute;
                requestWriteSegmentRequest_writeSegmentRequest_DimensionsIsNull = false;
            }
            Amazon.Pinpoint.Model.SegmentBehaviors requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior = null;
            
             // populate Behavior
            bool requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_BehaviorIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior = new Amazon.Pinpoint.Model.SegmentBehaviors();
            Amazon.Pinpoint.Model.RecencyDimension requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency = null;
            
             // populate Recency
            bool requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_RecencyIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency = new Amazon.Pinpoint.Model.RecencyDimension();
            Amazon.Pinpoint.Duration requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency_recency_Duration = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Behavior_Recency_Duration != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency_recency_Duration = cmdletContext.WriteSegmentRequest_Dimensions_Behavior_Recency_Duration;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency_recency_Duration != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency.Duration = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency_recency_Duration;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_RecencyIsNull = false;
            }
            Amazon.Pinpoint.RecencyType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency_recency_RecencyType = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Behavior_Recency_RecencyType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency_recency_RecencyType = cmdletContext.WriteSegmentRequest_Dimensions_Behavior_Recency_RecencyType;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency_recency_RecencyType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency.RecencyType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency_recency_RecencyType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_RecencyIsNull = false;
            }
             // determine if requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency should be set to null
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_RecencyIsNull)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency = null;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior.Recency = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_BehaviorIsNull = false;
            }
             // determine if requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior should be set to null
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_BehaviorIsNull)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior = null;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions.Behavior = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior;
                requestWriteSegmentRequest_writeSegmentRequest_DimensionsIsNull = false;
            }
            Amazon.Pinpoint.Model.SegmentLocation requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location = null;
            
             // populate Location
            bool requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_LocationIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location = new Amazon.Pinpoint.Model.SegmentLocation();
            Amazon.Pinpoint.Model.SetDimension requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country = null;
            
             // populate Country
            bool requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_CountryIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country = new Amazon.Pinpoint.Model.SetDimension();
            Amazon.Pinpoint.DimensionType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country_country_DimensionType = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Location_Country_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country_country_DimensionType = cmdletContext.WriteSegmentRequest_Dimensions_Location_Country_DimensionType;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country_country_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country.DimensionType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country_country_DimensionType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_CountryIsNull = false;
            }
            List<System.String> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country_country_Value = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Location_Country_Values != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country_country_Value = cmdletContext.WriteSegmentRequest_Dimensions_Location_Country_Values;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country_country_Value != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country.Values = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country_country_Value;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_CountryIsNull = false;
            }
             // determine if requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country should be set to null
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_CountryIsNull)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country = null;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location.Country = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_LocationIsNull = false;
            }
             // determine if requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location should be set to null
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_LocationIsNull)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location = null;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions.Location = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location;
                requestWriteSegmentRequest_writeSegmentRequest_DimensionsIsNull = false;
            }
            Amazon.Pinpoint.Model.SegmentDemographics requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic = null;
            
             // populate Demographic
            bool requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_DemographicIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic = new Amazon.Pinpoint.Model.SegmentDemographics();
            Amazon.Pinpoint.Model.SetDimension requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion = null;
            
             // populate AppVersion
            bool requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersionIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion = new Amazon.Pinpoint.Model.SetDimension();
            Amazon.Pinpoint.DimensionType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion_appVersion_DimensionType = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Demographic_AppVersion_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion_appVersion_DimensionType = cmdletContext.WriteSegmentRequest_Dimensions_Demographic_AppVersion_DimensionType;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion_appVersion_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion.DimensionType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion_appVersion_DimensionType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersionIsNull = false;
            }
            List<System.String> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion_appVersion_Value = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Demographic_AppVersion_Values != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion_appVersion_Value = cmdletContext.WriteSegmentRequest_Dimensions_Demographic_AppVersion_Values;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion_appVersion_Value != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion.Values = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion_appVersion_Value;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersionIsNull = false;
            }
             // determine if requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion should be set to null
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersionIsNull)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion = null;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic.AppVersion = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_DemographicIsNull = false;
            }
            Amazon.Pinpoint.Model.SetDimension requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel = null;
            
             // populate Channel
            bool requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_ChannelIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel = new Amazon.Pinpoint.Model.SetDimension();
            Amazon.Pinpoint.DimensionType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel_channel_DimensionType = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Channel_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel_channel_DimensionType = cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Channel_DimensionType;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel_channel_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel.DimensionType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel_channel_DimensionType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_ChannelIsNull = false;
            }
            List<System.String> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel_channel_Value = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Channel_Values != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel_channel_Value = cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Channel_Values;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel_channel_Value != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel.Values = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel_channel_Value;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_ChannelIsNull = false;
            }
             // determine if requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel should be set to null
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_ChannelIsNull)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel = null;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic.Channel = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_DemographicIsNull = false;
            }
            Amazon.Pinpoint.Model.SetDimension requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType = null;
            
             // populate DeviceType
            bool requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceTypeIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType = new Amazon.Pinpoint.Model.SetDimension();
            Amazon.Pinpoint.DimensionType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType_deviceType_DimensionType = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Demographic_DeviceType_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType_deviceType_DimensionType = cmdletContext.WriteSegmentRequest_Dimensions_Demographic_DeviceType_DimensionType;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType_deviceType_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType.DimensionType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType_deviceType_DimensionType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceTypeIsNull = false;
            }
            List<System.String> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType_deviceType_Value = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Demographic_DeviceType_Values != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType_deviceType_Value = cmdletContext.WriteSegmentRequest_Dimensions_Demographic_DeviceType_Values;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType_deviceType_Value != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType.Values = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType_deviceType_Value;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceTypeIsNull = false;
            }
             // determine if requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType should be set to null
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceTypeIsNull)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType = null;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic.DeviceType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_DemographicIsNull = false;
            }
            Amazon.Pinpoint.Model.SetDimension requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make = null;
            
             // populate Make
            bool requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_MakeIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make = new Amazon.Pinpoint.Model.SetDimension();
            Amazon.Pinpoint.DimensionType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make_make_DimensionType = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Make_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make_make_DimensionType = cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Make_DimensionType;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make_make_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make.DimensionType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make_make_DimensionType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_MakeIsNull = false;
            }
            List<System.String> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make_make_Value = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Make_Values != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make_make_Value = cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Make_Values;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make_make_Value != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make.Values = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make_make_Value;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_MakeIsNull = false;
            }
             // determine if requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make should be set to null
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_MakeIsNull)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make = null;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic.Make = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_DemographicIsNull = false;
            }
            Amazon.Pinpoint.Model.SetDimension requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model = null;
            
             // populate Model
            bool requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_ModelIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model = new Amazon.Pinpoint.Model.SetDimension();
            Amazon.Pinpoint.DimensionType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model_model_DimensionType = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Model_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model_model_DimensionType = cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Model_DimensionType;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model_model_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model.DimensionType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model_model_DimensionType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_ModelIsNull = false;
            }
            List<System.String> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model_model_Value = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Model_Values != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model_model_Value = cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Model_Values;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model_model_Value != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model.Values = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model_model_Value;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_ModelIsNull = false;
            }
             // determine if requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model should be set to null
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_ModelIsNull)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model = null;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic.Model = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_DemographicIsNull = false;
            }
            Amazon.Pinpoint.Model.SetDimension requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform = null;
            
             // populate Platform
            bool requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_PlatformIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform = new Amazon.Pinpoint.Model.SetDimension();
            Amazon.Pinpoint.DimensionType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform_platform_DimensionType = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Platform_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform_platform_DimensionType = cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Platform_DimensionType;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform_platform_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform.DimensionType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform_platform_DimensionType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_PlatformIsNull = false;
            }
            List<System.String> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform_platform_Value = null;
            if (cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Platform_Values != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform_platform_Value = cmdletContext.WriteSegmentRequest_Dimensions_Demographic_Platform_Values;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform_platform_Value != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform.Values = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform_platform_Value;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_PlatformIsNull = false;
            }
             // determine if requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform should be set to null
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_PlatformIsNull)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform = null;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic.Platform = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_DemographicIsNull = false;
            }
             // determine if requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic should be set to null
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_DemographicIsNull)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic = null;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions.Demographic = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic;
                requestWriteSegmentRequest_writeSegmentRequest_DimensionsIsNull = false;
            }
             // determine if requestWriteSegmentRequest_writeSegmentRequest_Dimensions should be set to null
            if (requestWriteSegmentRequest_writeSegmentRequest_DimensionsIsNull)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions = null;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions != null)
            {
                request.WriteSegmentRequest.Dimensions = requestWriteSegmentRequest_writeSegmentRequest_Dimensions;
                requestWriteSegmentRequestIsNull = false;
            }
             // determine if request.WriteSegmentRequest should be set to null
            if (requestWriteSegmentRequestIsNull)
            {
                request.WriteSegmentRequest = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SegmentResponse;
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
        
        private Amazon.Pinpoint.Model.CreateSegmentResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.CreateSegmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "CreateSegment");
            try
            {
                #if DESKTOP
                return client.CreateSegment(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateSegmentAsync(request);
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
            public Dictionary<System.String, Amazon.Pinpoint.Model.AttributeDimension> WriteSegmentRequest_Dimensions_Attributes { get; set; }
            public Amazon.Pinpoint.Duration WriteSegmentRequest_Dimensions_Behavior_Recency_Duration { get; set; }
            public Amazon.Pinpoint.RecencyType WriteSegmentRequest_Dimensions_Behavior_Recency_RecencyType { get; set; }
            public Amazon.Pinpoint.DimensionType WriteSegmentRequest_Dimensions_Demographic_AppVersion_DimensionType { get; set; }
            public List<System.String> WriteSegmentRequest_Dimensions_Demographic_AppVersion_Values { get; set; }
            public Amazon.Pinpoint.DimensionType WriteSegmentRequest_Dimensions_Demographic_Channel_DimensionType { get; set; }
            public List<System.String> WriteSegmentRequest_Dimensions_Demographic_Channel_Values { get; set; }
            public Amazon.Pinpoint.DimensionType WriteSegmentRequest_Dimensions_Demographic_DeviceType_DimensionType { get; set; }
            public List<System.String> WriteSegmentRequest_Dimensions_Demographic_DeviceType_Values { get; set; }
            public Amazon.Pinpoint.DimensionType WriteSegmentRequest_Dimensions_Demographic_Make_DimensionType { get; set; }
            public List<System.String> WriteSegmentRequest_Dimensions_Demographic_Make_Values { get; set; }
            public Amazon.Pinpoint.DimensionType WriteSegmentRequest_Dimensions_Demographic_Model_DimensionType { get; set; }
            public List<System.String> WriteSegmentRequest_Dimensions_Demographic_Model_Values { get; set; }
            public Amazon.Pinpoint.DimensionType WriteSegmentRequest_Dimensions_Demographic_Platform_DimensionType { get; set; }
            public List<System.String> WriteSegmentRequest_Dimensions_Demographic_Platform_Values { get; set; }
            public Amazon.Pinpoint.DimensionType WriteSegmentRequest_Dimensions_Location_Country_DimensionType { get; set; }
            public List<System.String> WriteSegmentRequest_Dimensions_Location_Country_Values { get; set; }
            public Dictionary<System.String, Amazon.Pinpoint.Model.AttributeDimension> WriteSegmentRequest_Dimensions_UserAttributes { get; set; }
            public System.String WriteSegmentRequest_Name { get; set; }
        }
        
    }
}
