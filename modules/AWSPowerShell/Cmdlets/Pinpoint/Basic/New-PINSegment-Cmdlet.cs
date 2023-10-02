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
    /// Creates a new segment for an application or updates the configuration, dimension,
    /// and other settings for an existing segment that's associated with an application.
    /// </summary>
    [Cmdlet("New", "PINSegment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.SegmentResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint CreateSegment API operation.", Operation = new[] {"CreateSegment"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.CreateSegmentResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.SegmentResponse or Amazon.Pinpoint.Model.CreateSegmentResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.SegmentResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.CreateSegmentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPINSegmentCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter Dimensions_Attribute
        /// <summary>
        /// <para>
        /// <para>One or more custom attributes to use as criteria for the segment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Attributes")]
        public System.Collections.Hashtable Dimensions_Attribute { get; set; }
        #endregion
        
        #region Parameter AppVersion_DimensionType
        /// <summary>
        /// <para>
        /// <para>The type of segment dimension to use. Valid values are: INCLUSIVE, endpoints that
        /// match the criteria are included in the segment; and, EXCLUSIVE, endpoints that match
        /// the criteria are excluded from the segment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_AppVersion_DimensionType")]
        [AWSConstantClassSource("Amazon.Pinpoint.DimensionType")]
        public Amazon.Pinpoint.DimensionType AppVersion_DimensionType { get; set; }
        #endregion
        
        #region Parameter Channel_DimensionType
        /// <summary>
        /// <para>
        /// <para>The type of segment dimension to use. Valid values are: INCLUSIVE, endpoints that
        /// match the criteria are included in the segment; and, EXCLUSIVE, endpoints that match
        /// the criteria are excluded from the segment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Channel_DimensionType")]
        [AWSConstantClassSource("Amazon.Pinpoint.DimensionType")]
        public Amazon.Pinpoint.DimensionType Channel_DimensionType { get; set; }
        #endregion
        
        #region Parameter DeviceType_DimensionType
        /// <summary>
        /// <para>
        /// <para>The type of segment dimension to use. Valid values are: INCLUSIVE, endpoints that
        /// match the criteria are included in the segment; and, EXCLUSIVE, endpoints that match
        /// the criteria are excluded from the segment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_DeviceType_DimensionType")]
        [AWSConstantClassSource("Amazon.Pinpoint.DimensionType")]
        public Amazon.Pinpoint.DimensionType DeviceType_DimensionType { get; set; }
        #endregion
        
        #region Parameter Make_DimensionType
        /// <summary>
        /// <para>
        /// <para>The type of segment dimension to use. Valid values are: INCLUSIVE, endpoints that
        /// match the criteria are included in the segment; and, EXCLUSIVE, endpoints that match
        /// the criteria are excluded from the segment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Make_DimensionType")]
        [AWSConstantClassSource("Amazon.Pinpoint.DimensionType")]
        public Amazon.Pinpoint.DimensionType Make_DimensionType { get; set; }
        #endregion
        
        #region Parameter Model_DimensionType
        /// <summary>
        /// <para>
        /// <para>The type of segment dimension to use. Valid values are: INCLUSIVE, endpoints that
        /// match the criteria are included in the segment; and, EXCLUSIVE, endpoints that match
        /// the criteria are excluded from the segment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Model_DimensionType")]
        [AWSConstantClassSource("Amazon.Pinpoint.DimensionType")]
        public Amazon.Pinpoint.DimensionType Model_DimensionType { get; set; }
        #endregion
        
        #region Parameter Platform_DimensionType
        /// <summary>
        /// <para>
        /// <para>The type of segment dimension to use. Valid values are: INCLUSIVE, endpoints that
        /// match the criteria are included in the segment; and, EXCLUSIVE, endpoints that match
        /// the criteria are excluded from the segment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Platform_DimensionType")]
        [AWSConstantClassSource("Amazon.Pinpoint.DimensionType")]
        public Amazon.Pinpoint.DimensionType Platform_DimensionType { get; set; }
        #endregion
        
        #region Parameter Country_DimensionType
        /// <summary>
        /// <para>
        /// <para>The type of segment dimension to use. Valid values are: INCLUSIVE, endpoints that
        /// match the criteria are included in the segment; and, EXCLUSIVE, endpoints that match
        /// the criteria are excluded from the segment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Location_Country_DimensionType")]
        [AWSConstantClassSource("Amazon.Pinpoint.DimensionType")]
        public Amazon.Pinpoint.DimensionType Country_DimensionType { get; set; }
        #endregion
        
        #region Parameter Recency_Duration
        /// <summary>
        /// <para>
        /// <para>The duration to use when determining whether an endpoint is active or inactive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Behavior_Recency_Duration")]
        [AWSConstantClassSource("Amazon.Pinpoint.Duration")]
        public Amazon.Pinpoint.Duration Recency_Duration { get; set; }
        #endregion
        
        #region Parameter SegmentGroups_Group
        /// <summary>
        /// <para>
        /// <para>An array that defines the set of segment criteria to evaluate when handling segment
        /// groups for the segment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_SegmentGroups_Groups")]
        public Amazon.Pinpoint.Model.SegmentGroup[] SegmentGroups_Group { get; set; }
        #endregion
        
        #region Parameter SegmentGroups_Include
        /// <summary>
        /// <para>
        /// <para>Specifies how to handle multiple segment groups for the segment. For example, if the
        /// segment includes three segment groups, whether the resulting segment includes endpoints
        /// that match all, any, or none of the segment groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_SegmentGroups_Include")]
        [AWSConstantClassSource("Amazon.Pinpoint.Include")]
        public Amazon.Pinpoint.Include SegmentGroups_Include { get; set; }
        #endregion
        
        #region Parameter Coordinates_Latitude
        /// <summary>
        /// <para>
        /// <para>The latitude coordinate of the location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Location_GPSPoint_Coordinates_Latitude")]
        public System.Double? Coordinates_Latitude { get; set; }
        #endregion
        
        #region Parameter Coordinates_Longitude
        /// <summary>
        /// <para>
        /// <para>The longitude coordinate of the location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Location_GPSPoint_Coordinates_Longitude")]
        public System.Double? Coordinates_Longitude { get; set; }
        #endregion
        
        #region Parameter Dimensions_Metric
        /// <summary>
        /// <para>
        /// <para>One or more custom metrics to use as criteria for the segment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Metrics")]
        public System.Collections.Hashtable Dimensions_Metric { get; set; }
        #endregion
        
        #region Parameter WriteSegmentRequest_Name
        /// <summary>
        /// <para>
        /// <para>The name of the segment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WriteSegmentRequest_Name { get; set; }
        #endregion
        
        #region Parameter GPSPoint_RangeInKilometer
        /// <summary>
        /// <para>
        /// <para>The range, in kilometers, from the GPS coordinates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Location_GPSPoint_RangeInKilometers")]
        public System.Double? GPSPoint_RangeInKilometer { get; set; }
        #endregion
        
        #region Parameter Recency_RecencyType
        /// <summary>
        /// <para>
        /// <para>The type of recency dimension to use for the segment. Valid values are: ACTIVE, endpoints
        /// that were active within the specified duration are included in the segment; and, INACTIVE,
        /// endpoints that weren't active within the specified duration are included in the segment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Behavior_Recency_RecencyType")]
        [AWSConstantClassSource("Amazon.Pinpoint.RecencyType")]
        public Amazon.Pinpoint.RecencyType Recency_RecencyType { get; set; }
        #endregion
        
        #region Parameter WriteSegmentRequest_Tag
        /// <summary>
        /// <para>
        /// <note><para>As of <b>22-05-2023</b> tags has been deprecated for update operations. After this
        /// date any value in tags is not processed and an error code is not returned. To manage
        /// tags we recommend using either <a href="https://docs.aws.amazon.com/pinpoint/latest/apireference/tags-resource-arn.html">Tags</a>
        /// in the <i>API Reference for Amazon Pinpoint</i>, <a href="https://docs.aws.amazon.com/cli/latest/reference/resourcegroupstaggingapi/index.html">resourcegroupstaggingapi</a>
        /// commands in the <i>AWS Command Line Interface Documentation</i> or <a href="https://sdk.amazonaws.com/java/api/latest/software/amazon/awssdk/services/resourcegroupstaggingapi/package-summary.html">resourcegroupstaggingapi</a>
        /// in the <i>AWS SDK</i>.</para></note><para>(Deprecated) A string-to-string map of key-value pairs that defines the tags to associate
        /// with the segment. Each tag consists of a required tag key and an associated tag value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Tags")]
        public System.Collections.Hashtable WriteSegmentRequest_Tag { get; set; }
        #endregion
        
        #region Parameter Dimensions_UserAttribute
        /// <summary>
        /// <para>
        /// <para>One or more custom user attributes to use as criteria for the segment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_UserAttributes")]
        public System.Collections.Hashtable Dimensions_UserAttribute { get; set; }
        #endregion
        
        #region Parameter AppVersion_Value
        /// <summary>
        /// <para>
        /// <para>The criteria values to use for the segment dimension. Depending on the value of the
        /// DimensionType property, endpoints are included or excluded from the segment if their
        /// values match the criteria values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_AppVersion_Values")]
        public System.String[] AppVersion_Value { get; set; }
        #endregion
        
        #region Parameter Channel_Value
        /// <summary>
        /// <para>
        /// <para>The criteria values to use for the segment dimension. Depending on the value of the
        /// DimensionType property, endpoints are included or excluded from the segment if their
        /// values match the criteria values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Channel_Values")]
        public System.String[] Channel_Value { get; set; }
        #endregion
        
        #region Parameter DeviceType_Value
        /// <summary>
        /// <para>
        /// <para>The criteria values to use for the segment dimension. Depending on the value of the
        /// DimensionType property, endpoints are included or excluded from the segment if their
        /// values match the criteria values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_DeviceType_Values")]
        public System.String[] DeviceType_Value { get; set; }
        #endregion
        
        #region Parameter Make_Value
        /// <summary>
        /// <para>
        /// <para>The criteria values to use for the segment dimension. Depending on the value of the
        /// DimensionType property, endpoints are included or excluded from the segment if their
        /// values match the criteria values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Make_Values")]
        public System.String[] Make_Value { get; set; }
        #endregion
        
        #region Parameter Model_Value
        /// <summary>
        /// <para>
        /// <para>The criteria values to use for the segment dimension. Depending on the value of the
        /// DimensionType property, endpoints are included or excluded from the segment if their
        /// values match the criteria values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Model_Values")]
        public System.String[] Model_Value { get; set; }
        #endregion
        
        #region Parameter Platform_Value
        /// <summary>
        /// <para>
        /// <para>The criteria values to use for the segment dimension. Depending on the value of the
        /// DimensionType property, endpoints are included or excluded from the segment if their
        /// values match the criteria values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Demographic_Platform_Values")]
        public System.String[] Platform_Value { get; set; }
        #endregion
        
        #region Parameter Country_Value
        /// <summary>
        /// <para>
        /// <para>The criteria values to use for the segment dimension. Depending on the value of the
        /// DimensionType property, endpoints are included or excluded from the segment if their
        /// values match the criteria values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteSegmentRequest_Dimensions_Location_Country_Values")]
        public System.String[] Country_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SegmentResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.CreateSegmentResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.CreateSegmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SegmentResponse";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINSegment (CreateSegment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.CreateSegmentResponse, NewPINSegmentCmdlet>(Select) ??
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
            if (this.Dimensions_Attribute != null)
            {
                context.Dimensions_Attribute = new Dictionary<System.String, Amazon.Pinpoint.Model.AttributeDimension>(StringComparer.Ordinal);
                foreach (var hashKey in this.Dimensions_Attribute.Keys)
                {
                    context.Dimensions_Attribute.Add((String)hashKey, (AttributeDimension)(this.Dimensions_Attribute[hashKey]));
                }
            }
            context.Recency_Duration = this.Recency_Duration;
            context.Recency_RecencyType = this.Recency_RecencyType;
            context.AppVersion_DimensionType = this.AppVersion_DimensionType;
            if (this.AppVersion_Value != null)
            {
                context.AppVersion_Value = new List<System.String>(this.AppVersion_Value);
            }
            context.Channel_DimensionType = this.Channel_DimensionType;
            if (this.Channel_Value != null)
            {
                context.Channel_Value = new List<System.String>(this.Channel_Value);
            }
            context.DeviceType_DimensionType = this.DeviceType_DimensionType;
            if (this.DeviceType_Value != null)
            {
                context.DeviceType_Value = new List<System.String>(this.DeviceType_Value);
            }
            context.Make_DimensionType = this.Make_DimensionType;
            if (this.Make_Value != null)
            {
                context.Make_Value = new List<System.String>(this.Make_Value);
            }
            context.Model_DimensionType = this.Model_DimensionType;
            if (this.Model_Value != null)
            {
                context.Model_Value = new List<System.String>(this.Model_Value);
            }
            context.Platform_DimensionType = this.Platform_DimensionType;
            if (this.Platform_Value != null)
            {
                context.Platform_Value = new List<System.String>(this.Platform_Value);
            }
            context.Country_DimensionType = this.Country_DimensionType;
            if (this.Country_Value != null)
            {
                context.Country_Value = new List<System.String>(this.Country_Value);
            }
            context.Coordinates_Latitude = this.Coordinates_Latitude;
            context.Coordinates_Longitude = this.Coordinates_Longitude;
            context.GPSPoint_RangeInKilometer = this.GPSPoint_RangeInKilometer;
            if (this.Dimensions_Metric != null)
            {
                context.Dimensions_Metric = new Dictionary<System.String, Amazon.Pinpoint.Model.MetricDimension>(StringComparer.Ordinal);
                foreach (var hashKey in this.Dimensions_Metric.Keys)
                {
                    context.Dimensions_Metric.Add((String)hashKey, (MetricDimension)(this.Dimensions_Metric[hashKey]));
                }
            }
            if (this.Dimensions_UserAttribute != null)
            {
                context.Dimensions_UserAttribute = new Dictionary<System.String, Amazon.Pinpoint.Model.AttributeDimension>(StringComparer.Ordinal);
                foreach (var hashKey in this.Dimensions_UserAttribute.Keys)
                {
                    context.Dimensions_UserAttribute.Add((String)hashKey, (AttributeDimension)(this.Dimensions_UserAttribute[hashKey]));
                }
            }
            context.WriteSegmentRequest_Name = this.WriteSegmentRequest_Name;
            if (this.SegmentGroups_Group != null)
            {
                context.SegmentGroups_Group = new List<Amazon.Pinpoint.Model.SegmentGroup>(this.SegmentGroups_Group);
            }
            context.SegmentGroups_Include = this.SegmentGroups_Include;
            if (this.WriteSegmentRequest_Tag != null)
            {
                context.WriteSegmentRequest_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.WriteSegmentRequest_Tag.Keys)
                {
                    context.WriteSegmentRequest_Tag.Add((String)hashKey, (String)(this.WriteSegmentRequest_Tag[hashKey]));
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
            var request = new Amazon.Pinpoint.Model.CreateSegmentRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate WriteSegmentRequest
            var requestWriteSegmentRequestIsNull = true;
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
            Dictionary<System.String, System.String> requestWriteSegmentRequest_writeSegmentRequest_Tag = null;
            if (cmdletContext.WriteSegmentRequest_Tag != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Tag = cmdletContext.WriteSegmentRequest_Tag;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Tag != null)
            {
                request.WriteSegmentRequest.Tags = requestWriteSegmentRequest_writeSegmentRequest_Tag;
                requestWriteSegmentRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.SegmentGroupList requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups = null;
            
             // populate SegmentGroups
            var requestWriteSegmentRequest_writeSegmentRequest_SegmentGroupsIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups = new Amazon.Pinpoint.Model.SegmentGroupList();
            List<Amazon.Pinpoint.Model.SegmentGroup> requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups_segmentGroups_Group = null;
            if (cmdletContext.SegmentGroups_Group != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups_segmentGroups_Group = cmdletContext.SegmentGroups_Group;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups_segmentGroups_Group != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups.Groups = requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups_segmentGroups_Group;
                requestWriteSegmentRequest_writeSegmentRequest_SegmentGroupsIsNull = false;
            }
            Amazon.Pinpoint.Include requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups_segmentGroups_Include = null;
            if (cmdletContext.SegmentGroups_Include != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups_segmentGroups_Include = cmdletContext.SegmentGroups_Include;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups_segmentGroups_Include != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups.Include = requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups_segmentGroups_Include;
                requestWriteSegmentRequest_writeSegmentRequest_SegmentGroupsIsNull = false;
            }
             // determine if requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups should be set to null
            if (requestWriteSegmentRequest_writeSegmentRequest_SegmentGroupsIsNull)
            {
                requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups = null;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups != null)
            {
                request.WriteSegmentRequest.SegmentGroups = requestWriteSegmentRequest_writeSegmentRequest_SegmentGroups;
                requestWriteSegmentRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.SegmentDimensions requestWriteSegmentRequest_writeSegmentRequest_Dimensions = null;
            
             // populate Dimensions
            var requestWriteSegmentRequest_writeSegmentRequest_DimensionsIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions = new Amazon.Pinpoint.Model.SegmentDimensions();
            Dictionary<System.String, Amazon.Pinpoint.Model.AttributeDimension> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_Attribute = null;
            if (cmdletContext.Dimensions_Attribute != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_Attribute = cmdletContext.Dimensions_Attribute;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_Attribute != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions.Attributes = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_Attribute;
                requestWriteSegmentRequest_writeSegmentRequest_DimensionsIsNull = false;
            }
            Dictionary<System.String, Amazon.Pinpoint.Model.MetricDimension> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_Metric = null;
            if (cmdletContext.Dimensions_Metric != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_Metric = cmdletContext.Dimensions_Metric;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_Metric != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions.Metrics = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_Metric;
                requestWriteSegmentRequest_writeSegmentRequest_DimensionsIsNull = false;
            }
            Dictionary<System.String, Amazon.Pinpoint.Model.AttributeDimension> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_UserAttribute = null;
            if (cmdletContext.Dimensions_UserAttribute != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_UserAttribute = cmdletContext.Dimensions_UserAttribute;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_UserAttribute != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions.UserAttributes = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_dimensions_UserAttribute;
                requestWriteSegmentRequest_writeSegmentRequest_DimensionsIsNull = false;
            }
            Amazon.Pinpoint.Model.SegmentBehaviors requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior = null;
            
             // populate Behavior
            var requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_BehaviorIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior = new Amazon.Pinpoint.Model.SegmentBehaviors();
            Amazon.Pinpoint.Model.RecencyDimension requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency = null;
            
             // populate Recency
            var requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_RecencyIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency = new Amazon.Pinpoint.Model.RecencyDimension();
            Amazon.Pinpoint.Duration requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency_recency_Duration = null;
            if (cmdletContext.Recency_Duration != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency_recency_Duration = cmdletContext.Recency_Duration;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency_recency_Duration != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency.Duration = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency_recency_Duration;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_RecencyIsNull = false;
            }
            Amazon.Pinpoint.RecencyType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency_recency_RecencyType = null;
            if (cmdletContext.Recency_RecencyType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Behavior_writeSegmentRequest_Dimensions_Behavior_Recency_recency_RecencyType = cmdletContext.Recency_RecencyType;
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
            var requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_LocationIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location = new Amazon.Pinpoint.Model.SegmentLocation();
            Amazon.Pinpoint.Model.SetDimension requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country = null;
            
             // populate Country
            var requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_CountryIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country = new Amazon.Pinpoint.Model.SetDimension();
            Amazon.Pinpoint.DimensionType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country_country_DimensionType = null;
            if (cmdletContext.Country_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country_country_DimensionType = cmdletContext.Country_DimensionType;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country_country_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country.DimensionType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country_country_DimensionType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_CountryIsNull = false;
            }
            List<System.String> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country_country_Value = null;
            if (cmdletContext.Country_Value != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_Country_country_Value = cmdletContext.Country_Value;
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
            Amazon.Pinpoint.Model.GPSPointDimension requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint = null;
            
             // populate GPSPoint
            var requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPointIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint = new Amazon.Pinpoint.Model.GPSPointDimension();
            System.Double? requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_gPSPoint_RangeInKilometer = null;
            if (cmdletContext.GPSPoint_RangeInKilometer != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_gPSPoint_RangeInKilometer = cmdletContext.GPSPoint_RangeInKilometer.Value;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_gPSPoint_RangeInKilometer != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint.RangeInKilometers = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_gPSPoint_RangeInKilometer.Value;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPointIsNull = false;
            }
            Amazon.Pinpoint.Model.GPSCoordinates requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates = null;
            
             // populate Coordinates
            var requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_CoordinatesIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates = new Amazon.Pinpoint.Model.GPSCoordinates();
            System.Double? requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates_coordinates_Latitude = null;
            if (cmdletContext.Coordinates_Latitude != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates_coordinates_Latitude = cmdletContext.Coordinates_Latitude.Value;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates_coordinates_Latitude != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates.Latitude = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates_coordinates_Latitude.Value;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_CoordinatesIsNull = false;
            }
            System.Double? requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates_coordinates_Longitude = null;
            if (cmdletContext.Coordinates_Longitude != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates_coordinates_Longitude = cmdletContext.Coordinates_Longitude.Value;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates_coordinates_Longitude != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates.Longitude = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates_coordinates_Longitude.Value;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_CoordinatesIsNull = false;
            }
             // determine if requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates should be set to null
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_CoordinatesIsNull)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates = null;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint.Coordinates = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint_writeSegmentRequest_Dimensions_Location_GPSPoint_Coordinates;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPointIsNull = false;
            }
             // determine if requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint should be set to null
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPointIsNull)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint = null;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location.GPSPoint = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Location_writeSegmentRequest_Dimensions_Location_GPSPoint;
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
            var requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_DemographicIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic = new Amazon.Pinpoint.Model.SegmentDemographics();
            Amazon.Pinpoint.Model.SetDimension requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion = null;
            
             // populate AppVersion
            var requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersionIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion = new Amazon.Pinpoint.Model.SetDimension();
            Amazon.Pinpoint.DimensionType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion_appVersion_DimensionType = null;
            if (cmdletContext.AppVersion_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion_appVersion_DimensionType = cmdletContext.AppVersion_DimensionType;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion_appVersion_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion.DimensionType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion_appVersion_DimensionType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersionIsNull = false;
            }
            List<System.String> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion_appVersion_Value = null;
            if (cmdletContext.AppVersion_Value != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_AppVersion_appVersion_Value = cmdletContext.AppVersion_Value;
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
            var requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_ChannelIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel = new Amazon.Pinpoint.Model.SetDimension();
            Amazon.Pinpoint.DimensionType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel_channel_DimensionType = null;
            if (cmdletContext.Channel_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel_channel_DimensionType = cmdletContext.Channel_DimensionType;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel_channel_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel.DimensionType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel_channel_DimensionType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_ChannelIsNull = false;
            }
            List<System.String> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel_channel_Value = null;
            if (cmdletContext.Channel_Value != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Channel_channel_Value = cmdletContext.Channel_Value;
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
            var requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceTypeIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType = new Amazon.Pinpoint.Model.SetDimension();
            Amazon.Pinpoint.DimensionType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType_deviceType_DimensionType = null;
            if (cmdletContext.DeviceType_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType_deviceType_DimensionType = cmdletContext.DeviceType_DimensionType;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType_deviceType_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType.DimensionType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType_deviceType_DimensionType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceTypeIsNull = false;
            }
            List<System.String> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType_deviceType_Value = null;
            if (cmdletContext.DeviceType_Value != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_DeviceType_deviceType_Value = cmdletContext.DeviceType_Value;
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
            var requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_MakeIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make = new Amazon.Pinpoint.Model.SetDimension();
            Amazon.Pinpoint.DimensionType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make_make_DimensionType = null;
            if (cmdletContext.Make_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make_make_DimensionType = cmdletContext.Make_DimensionType;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make_make_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make.DimensionType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make_make_DimensionType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_MakeIsNull = false;
            }
            List<System.String> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make_make_Value = null;
            if (cmdletContext.Make_Value != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Make_make_Value = cmdletContext.Make_Value;
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
            var requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_ModelIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model = new Amazon.Pinpoint.Model.SetDimension();
            Amazon.Pinpoint.DimensionType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model_model_DimensionType = null;
            if (cmdletContext.Model_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model_model_DimensionType = cmdletContext.Model_DimensionType;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model_model_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model.DimensionType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model_model_DimensionType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_ModelIsNull = false;
            }
            List<System.String> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model_model_Value = null;
            if (cmdletContext.Model_Value != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Model_model_Value = cmdletContext.Model_Value;
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
            var requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_PlatformIsNull = true;
            requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform = new Amazon.Pinpoint.Model.SetDimension();
            Amazon.Pinpoint.DimensionType requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform_platform_DimensionType = null;
            if (cmdletContext.Platform_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform_platform_DimensionType = cmdletContext.Platform_DimensionType;
            }
            if (requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform_platform_DimensionType != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform.DimensionType = requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform_platform_DimensionType;
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_PlatformIsNull = false;
            }
            List<System.String> requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform_platform_Value = null;
            if (cmdletContext.Platform_Value != null)
            {
                requestWriteSegmentRequest_writeSegmentRequest_Dimensions_writeSegmentRequest_Dimensions_Demographic_writeSegmentRequest_Dimensions_Demographic_Platform_platform_Value = cmdletContext.Platform_Value;
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
        
        private Amazon.Pinpoint.Model.CreateSegmentResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.CreateSegmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "CreateSegment");
            try
            {
                #if DESKTOP
                return client.CreateSegment(request);
                #elif CORECLR
                return client.CreateSegmentAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.Pinpoint.Model.AttributeDimension> Dimensions_Attribute { get; set; }
            public Amazon.Pinpoint.Duration Recency_Duration { get; set; }
            public Amazon.Pinpoint.RecencyType Recency_RecencyType { get; set; }
            public Amazon.Pinpoint.DimensionType AppVersion_DimensionType { get; set; }
            public List<System.String> AppVersion_Value { get; set; }
            public Amazon.Pinpoint.DimensionType Channel_DimensionType { get; set; }
            public List<System.String> Channel_Value { get; set; }
            public Amazon.Pinpoint.DimensionType DeviceType_DimensionType { get; set; }
            public List<System.String> DeviceType_Value { get; set; }
            public Amazon.Pinpoint.DimensionType Make_DimensionType { get; set; }
            public List<System.String> Make_Value { get; set; }
            public Amazon.Pinpoint.DimensionType Model_DimensionType { get; set; }
            public List<System.String> Model_Value { get; set; }
            public Amazon.Pinpoint.DimensionType Platform_DimensionType { get; set; }
            public List<System.String> Platform_Value { get; set; }
            public Amazon.Pinpoint.DimensionType Country_DimensionType { get; set; }
            public List<System.String> Country_Value { get; set; }
            public System.Double? Coordinates_Latitude { get; set; }
            public System.Double? Coordinates_Longitude { get; set; }
            public System.Double? GPSPoint_RangeInKilometer { get; set; }
            public Dictionary<System.String, Amazon.Pinpoint.Model.MetricDimension> Dimensions_Metric { get; set; }
            public Dictionary<System.String, Amazon.Pinpoint.Model.AttributeDimension> Dimensions_UserAttribute { get; set; }
            public System.String WriteSegmentRequest_Name { get; set; }
            public List<Amazon.Pinpoint.Model.SegmentGroup> SegmentGroups_Group { get; set; }
            public Amazon.Pinpoint.Include SegmentGroups_Include { get; set; }
            public Dictionary<System.String, System.String> WriteSegmentRequest_Tag { get; set; }
            public System.Func<Amazon.Pinpoint.Model.CreateSegmentResponse, NewPINSegmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SegmentResponse;
        }
        
    }
}
