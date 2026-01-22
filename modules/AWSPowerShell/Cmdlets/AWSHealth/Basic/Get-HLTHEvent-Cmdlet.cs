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
using Amazon.AWSHealth;
using Amazon.AWSHealth.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.HLTH
{
    /// <summary>
    /// Returns information about events that meet the specified filter criteria. Events
    /// are returned in a summary form and do not include the detailed description, any additional
    /// metadata that depends on the event type, or any affected resources. To retrieve that
    /// information, use the <a href="https://docs.aws.amazon.com/health/latest/APIReference/API_DescribeEventDetails.html">DescribeEventDetails</a>
    /// and <a href="https://docs.aws.amazon.com/health/latest/APIReference/API_DescribeAffectedEntities.html">DescribeAffectedEntities</a>
    /// operations.
    /// 
    ///  
    /// <para>
    /// If no filter criteria are specified, all events are returned. Results are sorted by
    /// <c>lastModifiedTime</c>, starting with the most recent event.
    /// </para><note><ul><li><para>
    /// When you call the <c>DescribeEvents</c> operation and specify an entity for the <c>entityValues</c>
    /// parameter, Health might return public events that aren't specific to that resource.
    /// For example, if you call <c>DescribeEvents</c> and specify an ID for an Amazon Elastic
    /// Compute Cloud (Amazon EC2) instance, Health might return events that aren't specific
    /// to that resource or service. To get events that are specific to a service, use the
    /// <c>services</c> parameter in the <c>filter</c> object. For more information, see <a href="https://docs.aws.amazon.com/health/latest/APIReference/API_Event.html">Event</a>.
    /// </para></li><li><para>
    /// This API operation uses pagination. Specify the <c>nextToken</c> parameter in the
    /// next request to return more results.
    /// </para></li></ul></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "HLTHEvent")]
    [OutputType("Amazon.AWSHealth.Model.Event")]
    [AWSCmdlet("Calls the AWS Health DescribeEvents API operation.", Operation = new[] {"DescribeEvents"}, SelectReturnType = typeof(Amazon.AWSHealth.Model.DescribeEventsResponse))]
    [AWSCmdletOutput("Amazon.AWSHealth.Model.Event or Amazon.AWSHealth.Model.DescribeEventsResponse",
        "This cmdlet returns a collection of Amazon.AWSHealth.Model.Event objects.",
        "The service call response (type Amazon.AWSHealth.Model.DescribeEventsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetHLTHEventCmdlet : AmazonAWSHealthClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter_Actionability
        /// <summary>
        /// <para>
        /// <para>A list of actionability values to filter events. Use this to filter events based on
        /// whether they require action (<c>ACTION_REQUIRED</c>), may require action (<c>ACTION_MAY_BE_REQUIRED</c>)
        /// or are informational (<c>INFORMATIONAL</c>).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Actionabilities")]
        public System.String[] Filter_Actionability { get; set; }
        #endregion
        
        #region Parameter Filter_AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Web Services Availability Zones.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_AvailabilityZones")]
        public System.String[] Filter_AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter Filter_EndTime
        /// <summary>
        /// <para>
        /// <para>A list of dates and times that the event ended.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_EndTimes")]
        public Amazon.AWSHealth.Model.DateTimeRange[] Filter_EndTime { get; set; }
        #endregion
        
        #region Parameter Filter_EntityArn
        /// <summary>
        /// <para>
        /// <para>A list of entity ARNs (unique identifiers).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_EntityArns")]
        public System.String[] Filter_EntityArn { get; set; }
        #endregion
        
        #region Parameter Filter_EntityValue
        /// <summary>
        /// <para>
        /// <para>A list of entity identifiers, such as EC2 instance IDs (<c>i-34ab692e</c>) or EBS
        /// volumes (<c>vol-426ab23e</c>).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_EntityValues")]
        public System.String[] Filter_EntityValue { get; set; }
        #endregion
        
        #region Parameter Filter_EventArn
        /// <summary>
        /// <para>
        /// <para>A list of event ARNs (unique identifiers). For example: <c>"arn:aws:health:us-east-1::event/EC2/EC2_INSTANCE_RETIREMENT_SCHEDULED/EC2_INSTANCE_RETIREMENT_SCHEDULED_ABC123-CDE456",
        /// "arn:aws:health:us-west-1::event/EBS/AWS_EBS_LOST_VOLUME/AWS_EBS_LOST_VOLUME_CHI789_JKL101"</c></para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_EventArns")]
        public System.String[] Filter_EventArn { get; set; }
        #endregion
        
        #region Parameter Filter_EventStatusCode
        /// <summary>
        /// <para>
        /// <para>A list of event status codes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_EventStatusCodes")]
        public System.String[] Filter_EventStatusCode { get; set; }
        #endregion
        
        #region Parameter Filter_EventTypeCategory
        /// <summary>
        /// <para>
        /// <para>A list of event type category codes. Possible values are <c>issue</c>, <c>accountNotification</c>,
        /// or <c>scheduledChange</c>. Currently, the <c>investigation</c> value isn't supported
        /// at this time.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_EventTypeCategories")]
        public System.String[] Filter_EventTypeCategory { get; set; }
        #endregion
        
        #region Parameter Filter_EventTypeCode
        /// <summary>
        /// <para>
        /// <para>A list of unique identifiers for event types. For example, <c>"AWS_EC2_SYSTEM_MAINTENANCE_EVENT","AWS_RDS_MAINTENANCE_SCHEDULED".</c></para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_EventTypeCodes")]
        public System.String[] Filter_EventTypeCode { get; set; }
        #endregion
        
        #region Parameter Filter_LastUpdatedTime
        /// <summary>
        /// <para>
        /// <para>A list of dates and times that the event was last updated.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_LastUpdatedTimes")]
        public Amazon.AWSHealth.Model.DateTimeRange[] Filter_LastUpdatedTime { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The locale (language) to return information in. English (en) is the default and the
        /// only supported value at this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Locale { get; set; }
        #endregion
        
        #region Parameter Filter_Persona
        /// <summary>
        /// <para>
        /// <para>A list of persona values to filter events. Use this to filter events based on their
        /// target audience: <c>OPERATIONS</c>, <c>SECURITY</c>, or <c>BILLING</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Personas")]
        public System.String[] Filter_Persona { get; set; }
        #endregion
        
        #region Parameter Filter_Region
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Web Services Regions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Regions")]
        public System.String[] Filter_Region { get; set; }
        #endregion
        
        #region Parameter Filter_Service
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services services associated with the event. For example, <c>EC2</c>,
        /// <c>RDS</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Services")]
        public System.String[] Filter_Service { get; set; }
        #endregion
        
        #region Parameter Filter_StartTime
        /// <summary>
        /// <para>
        /// <para>A list of dates and times that the event began.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_StartTimes")]
        public Amazon.AWSHealth.Model.DateTimeRange[] Filter_StartTime { get; set; }
        #endregion
        
        #region Parameter Filter_Tag
        /// <summary>
        /// <para>
        /// <para>A map of entity tags attached to the affected entity.</para><note><para>Currently, the <c>tags</c> property isn't supported.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Tags")]
        public System.Collections.Hashtable[] Filter_Tag { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return in one batch, between 1 and 100, inclusive.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the results of a search are large, only a portion of the results are returned,
        /// and a <c>nextToken</c> pagination token is returned in the response. To retrieve the
        /// next batch of results, reissue the search request and include the returned token.
        /// When all results have been returned, the response does not contain a pagination token
        /// value.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Events'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSHealth.Model.DescribeEventsResponse).
        /// Specifying the name of a property of type Amazon.AWSHealth.Model.DescribeEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Events";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AWSHealth.Model.DescribeEventsResponse, GetHLTHEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter_Actionability != null)
            {
                context.Filter_Actionability = new List<System.String>(this.Filter_Actionability);
            }
            if (this.Filter_AvailabilityZone != null)
            {
                context.Filter_AvailabilityZone = new List<System.String>(this.Filter_AvailabilityZone);
            }
            if (this.Filter_EndTime != null)
            {
                context.Filter_EndTime = new List<Amazon.AWSHealth.Model.DateTimeRange>(this.Filter_EndTime);
            }
            if (this.Filter_EntityArn != null)
            {
                context.Filter_EntityArn = new List<System.String>(this.Filter_EntityArn);
            }
            if (this.Filter_EntityValue != null)
            {
                context.Filter_EntityValue = new List<System.String>(this.Filter_EntityValue);
            }
            if (this.Filter_EventArn != null)
            {
                context.Filter_EventArn = new List<System.String>(this.Filter_EventArn);
            }
            if (this.Filter_EventStatusCode != null)
            {
                context.Filter_EventStatusCode = new List<System.String>(this.Filter_EventStatusCode);
            }
            if (this.Filter_EventTypeCategory != null)
            {
                context.Filter_EventTypeCategory = new List<System.String>(this.Filter_EventTypeCategory);
            }
            if (this.Filter_EventTypeCode != null)
            {
                context.Filter_EventTypeCode = new List<System.String>(this.Filter_EventTypeCode);
            }
            if (this.Filter_LastUpdatedTime != null)
            {
                context.Filter_LastUpdatedTime = new List<Amazon.AWSHealth.Model.DateTimeRange>(this.Filter_LastUpdatedTime);
            }
            if (this.Filter_Persona != null)
            {
                context.Filter_Persona = new List<System.String>(this.Filter_Persona);
            }
            if (this.Filter_Region != null)
            {
                context.Filter_Region = new List<System.String>(this.Filter_Region);
            }
            if (this.Filter_Service != null)
            {
                context.Filter_Service = new List<System.String>(this.Filter_Service);
            }
            if (this.Filter_StartTime != null)
            {
                context.Filter_StartTime = new List<Amazon.AWSHealth.Model.DateTimeRange>(this.Filter_StartTime);
            }
            if (this.Filter_Tag != null)
            {
                context.Filter_Tag = new List<Dictionary<System.String, System.String>>();
                foreach (var hashTable in this.Filter_Tag)
                {
                    var d = new Dictionary<System.String, System.String>();
                    foreach (var hashKey in hashTable.Keys)
                    {
                        d.Add((String)hashKey, (String)(hashTable[hashKey]));
                    }
                    context.Filter_Tag.Add(d);
                }
            }
            context.Locale = this.Locale;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.AWSHealth.Model.DescribeEventsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.AWSHealth.Model.EventFilter();
            List<System.String> requestFilter_filter_Actionability = null;
            if (cmdletContext.Filter_Actionability != null)
            {
                requestFilter_filter_Actionability = cmdletContext.Filter_Actionability;
            }
            if (requestFilter_filter_Actionability != null)
            {
                request.Filter.Actionabilities = requestFilter_filter_Actionability;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_AvailabilityZone = null;
            if (cmdletContext.Filter_AvailabilityZone != null)
            {
                requestFilter_filter_AvailabilityZone = cmdletContext.Filter_AvailabilityZone;
            }
            if (requestFilter_filter_AvailabilityZone != null)
            {
                request.Filter.AvailabilityZones = requestFilter_filter_AvailabilityZone;
                requestFilterIsNull = false;
            }
            List<Amazon.AWSHealth.Model.DateTimeRange> requestFilter_filter_EndTime = null;
            if (cmdletContext.Filter_EndTime != null)
            {
                requestFilter_filter_EndTime = cmdletContext.Filter_EndTime;
            }
            if (requestFilter_filter_EndTime != null)
            {
                request.Filter.EndTimes = requestFilter_filter_EndTime;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EntityArn = null;
            if (cmdletContext.Filter_EntityArn != null)
            {
                requestFilter_filter_EntityArn = cmdletContext.Filter_EntityArn;
            }
            if (requestFilter_filter_EntityArn != null)
            {
                request.Filter.EntityArns = requestFilter_filter_EntityArn;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EntityValue = null;
            if (cmdletContext.Filter_EntityValue != null)
            {
                requestFilter_filter_EntityValue = cmdletContext.Filter_EntityValue;
            }
            if (requestFilter_filter_EntityValue != null)
            {
                request.Filter.EntityValues = requestFilter_filter_EntityValue;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EventArn = null;
            if (cmdletContext.Filter_EventArn != null)
            {
                requestFilter_filter_EventArn = cmdletContext.Filter_EventArn;
            }
            if (requestFilter_filter_EventArn != null)
            {
                request.Filter.EventArns = requestFilter_filter_EventArn;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EventStatusCode = null;
            if (cmdletContext.Filter_EventStatusCode != null)
            {
                requestFilter_filter_EventStatusCode = cmdletContext.Filter_EventStatusCode;
            }
            if (requestFilter_filter_EventStatusCode != null)
            {
                request.Filter.EventStatusCodes = requestFilter_filter_EventStatusCode;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EventTypeCategory = null;
            if (cmdletContext.Filter_EventTypeCategory != null)
            {
                requestFilter_filter_EventTypeCategory = cmdletContext.Filter_EventTypeCategory;
            }
            if (requestFilter_filter_EventTypeCategory != null)
            {
                request.Filter.EventTypeCategories = requestFilter_filter_EventTypeCategory;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EventTypeCode = null;
            if (cmdletContext.Filter_EventTypeCode != null)
            {
                requestFilter_filter_EventTypeCode = cmdletContext.Filter_EventTypeCode;
            }
            if (requestFilter_filter_EventTypeCode != null)
            {
                request.Filter.EventTypeCodes = requestFilter_filter_EventTypeCode;
                requestFilterIsNull = false;
            }
            List<Amazon.AWSHealth.Model.DateTimeRange> requestFilter_filter_LastUpdatedTime = null;
            if (cmdletContext.Filter_LastUpdatedTime != null)
            {
                requestFilter_filter_LastUpdatedTime = cmdletContext.Filter_LastUpdatedTime;
            }
            if (requestFilter_filter_LastUpdatedTime != null)
            {
                request.Filter.LastUpdatedTimes = requestFilter_filter_LastUpdatedTime;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Persona = null;
            if (cmdletContext.Filter_Persona != null)
            {
                requestFilter_filter_Persona = cmdletContext.Filter_Persona;
            }
            if (requestFilter_filter_Persona != null)
            {
                request.Filter.Personas = requestFilter_filter_Persona;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Region = null;
            if (cmdletContext.Filter_Region != null)
            {
                requestFilter_filter_Region = cmdletContext.Filter_Region;
            }
            if (requestFilter_filter_Region != null)
            {
                request.Filter.Regions = requestFilter_filter_Region;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Service = null;
            if (cmdletContext.Filter_Service != null)
            {
                requestFilter_filter_Service = cmdletContext.Filter_Service;
            }
            if (requestFilter_filter_Service != null)
            {
                request.Filter.Services = requestFilter_filter_Service;
                requestFilterIsNull = false;
            }
            List<Amazon.AWSHealth.Model.DateTimeRange> requestFilter_filter_StartTime = null;
            if (cmdletContext.Filter_StartTime != null)
            {
                requestFilter_filter_StartTime = cmdletContext.Filter_StartTime;
            }
            if (requestFilter_filter_StartTime != null)
            {
                request.Filter.StartTimes = requestFilter_filter_StartTime;
                requestFilterIsNull = false;
            }
            List<Dictionary<System.String, System.String>> requestFilter_filter_Tag = null;
            if (cmdletContext.Filter_Tag != null)
            {
                requestFilter_filter_Tag = cmdletContext.Filter_Tag;
            }
            if (requestFilter_filter_Tag != null)
            {
                request.Filter.Tags = requestFilter_filter_Tag;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.AWSHealth.Model.DescribeEventsRequest();
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.AWSHealth.Model.EventFilter();
            List<System.String> requestFilter_filter_Actionability = null;
            if (cmdletContext.Filter_Actionability != null)
            {
                requestFilter_filter_Actionability = cmdletContext.Filter_Actionability;
            }
            if (requestFilter_filter_Actionability != null)
            {
                request.Filter.Actionabilities = requestFilter_filter_Actionability;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_AvailabilityZone = null;
            if (cmdletContext.Filter_AvailabilityZone != null)
            {
                requestFilter_filter_AvailabilityZone = cmdletContext.Filter_AvailabilityZone;
            }
            if (requestFilter_filter_AvailabilityZone != null)
            {
                request.Filter.AvailabilityZones = requestFilter_filter_AvailabilityZone;
                requestFilterIsNull = false;
            }
            List<Amazon.AWSHealth.Model.DateTimeRange> requestFilter_filter_EndTime = null;
            if (cmdletContext.Filter_EndTime != null)
            {
                requestFilter_filter_EndTime = cmdletContext.Filter_EndTime;
            }
            if (requestFilter_filter_EndTime != null)
            {
                request.Filter.EndTimes = requestFilter_filter_EndTime;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EntityArn = null;
            if (cmdletContext.Filter_EntityArn != null)
            {
                requestFilter_filter_EntityArn = cmdletContext.Filter_EntityArn;
            }
            if (requestFilter_filter_EntityArn != null)
            {
                request.Filter.EntityArns = requestFilter_filter_EntityArn;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EntityValue = null;
            if (cmdletContext.Filter_EntityValue != null)
            {
                requestFilter_filter_EntityValue = cmdletContext.Filter_EntityValue;
            }
            if (requestFilter_filter_EntityValue != null)
            {
                request.Filter.EntityValues = requestFilter_filter_EntityValue;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EventArn = null;
            if (cmdletContext.Filter_EventArn != null)
            {
                requestFilter_filter_EventArn = cmdletContext.Filter_EventArn;
            }
            if (requestFilter_filter_EventArn != null)
            {
                request.Filter.EventArns = requestFilter_filter_EventArn;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EventStatusCode = null;
            if (cmdletContext.Filter_EventStatusCode != null)
            {
                requestFilter_filter_EventStatusCode = cmdletContext.Filter_EventStatusCode;
            }
            if (requestFilter_filter_EventStatusCode != null)
            {
                request.Filter.EventStatusCodes = requestFilter_filter_EventStatusCode;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EventTypeCategory = null;
            if (cmdletContext.Filter_EventTypeCategory != null)
            {
                requestFilter_filter_EventTypeCategory = cmdletContext.Filter_EventTypeCategory;
            }
            if (requestFilter_filter_EventTypeCategory != null)
            {
                request.Filter.EventTypeCategories = requestFilter_filter_EventTypeCategory;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EventTypeCode = null;
            if (cmdletContext.Filter_EventTypeCode != null)
            {
                requestFilter_filter_EventTypeCode = cmdletContext.Filter_EventTypeCode;
            }
            if (requestFilter_filter_EventTypeCode != null)
            {
                request.Filter.EventTypeCodes = requestFilter_filter_EventTypeCode;
                requestFilterIsNull = false;
            }
            List<Amazon.AWSHealth.Model.DateTimeRange> requestFilter_filter_LastUpdatedTime = null;
            if (cmdletContext.Filter_LastUpdatedTime != null)
            {
                requestFilter_filter_LastUpdatedTime = cmdletContext.Filter_LastUpdatedTime;
            }
            if (requestFilter_filter_LastUpdatedTime != null)
            {
                request.Filter.LastUpdatedTimes = requestFilter_filter_LastUpdatedTime;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Persona = null;
            if (cmdletContext.Filter_Persona != null)
            {
                requestFilter_filter_Persona = cmdletContext.Filter_Persona;
            }
            if (requestFilter_filter_Persona != null)
            {
                request.Filter.Personas = requestFilter_filter_Persona;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Region = null;
            if (cmdletContext.Filter_Region != null)
            {
                requestFilter_filter_Region = cmdletContext.Filter_Region;
            }
            if (requestFilter_filter_Region != null)
            {
                request.Filter.Regions = requestFilter_filter_Region;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Service = null;
            if (cmdletContext.Filter_Service != null)
            {
                requestFilter_filter_Service = cmdletContext.Filter_Service;
            }
            if (requestFilter_filter_Service != null)
            {
                request.Filter.Services = requestFilter_filter_Service;
                requestFilterIsNull = false;
            }
            List<Amazon.AWSHealth.Model.DateTimeRange> requestFilter_filter_StartTime = null;
            if (cmdletContext.Filter_StartTime != null)
            {
                requestFilter_filter_StartTime = cmdletContext.Filter_StartTime;
            }
            if (requestFilter_filter_StartTime != null)
            {
                request.Filter.StartTimes = requestFilter_filter_StartTime;
                requestFilterIsNull = false;
            }
            List<Dictionary<System.String, System.String>> requestFilter_filter_Tag = null;
            if (cmdletContext.Filter_Tag != null)
            {
                requestFilter_filter_Tag = cmdletContext.Filter_Tag;
            }
            if (requestFilter_filter_Tag != null)
            {
                request.Filter.Tags = requestFilter_filter_Tag;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(100, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    int _receivedThisCall = response.Events?.Count ?? 0;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.AWSHealth.Model.DescribeEventsResponse CallAWSServiceOperation(IAmazonAWSHealth client, Amazon.AWSHealth.Model.DescribeEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Health", "DescribeEvents");
            try
            {
                return client.DescribeEventsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Filter_Actionability { get; set; }
            public List<System.String> Filter_AvailabilityZone { get; set; }
            public List<Amazon.AWSHealth.Model.DateTimeRange> Filter_EndTime { get; set; }
            public List<System.String> Filter_EntityArn { get; set; }
            public List<System.String> Filter_EntityValue { get; set; }
            public List<System.String> Filter_EventArn { get; set; }
            public List<System.String> Filter_EventStatusCode { get; set; }
            public List<System.String> Filter_EventTypeCategory { get; set; }
            public List<System.String> Filter_EventTypeCode { get; set; }
            public List<Amazon.AWSHealth.Model.DateTimeRange> Filter_LastUpdatedTime { get; set; }
            public List<System.String> Filter_Persona { get; set; }
            public List<System.String> Filter_Region { get; set; }
            public List<System.String> Filter_Service { get; set; }
            public List<Amazon.AWSHealth.Model.DateTimeRange> Filter_StartTime { get; set; }
            public List<Dictionary<System.String, System.String>> Filter_Tag { get; set; }
            public System.String Locale { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.AWSHealth.Model.DescribeEventsResponse, GetHLTHEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Events;
        }
        
    }
}
