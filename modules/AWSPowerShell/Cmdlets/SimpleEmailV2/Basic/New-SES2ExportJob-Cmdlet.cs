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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Creates an export job for a data source and destination.
    /// 
    ///  
    /// <para>
    /// You can execute this operation no more than once per second.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SES2ExportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) CreateExportJob API operation.", Operation = new[] {"CreateExportJob"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.CreateExportJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleEmailV2.Model.CreateExportJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleEmailV2.Model.CreateExportJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSES2ExportJobCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExportDestination_DataFormat
        /// <summary>
        /// <para>
        /// <para>The data format of the final export job file, can be one of the following:</para><ul><li><para><c>CSV</c> - A comma-separated values file.</para></li><li><para><c>JSON</c> - A Json file.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.DataFormat")]
        public Amazon.SimpleEmailV2.DataFormat ExportDestination_DataFormat { get; set; }
        #endregion
        
        #region Parameter Exclude_Destination
        /// <summary>
        /// <para>
        /// <para>The recipient's email address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MessageInsightsDataSource_Exclude_Destination")]
        public System.String[] Exclude_Destination { get; set; }
        #endregion
        
        #region Parameter Include_Destination
        /// <summary>
        /// <para>
        /// <para>The recipient's email address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MessageInsightsDataSource_Include_Destination")]
        public System.String[] Include_Destination { get; set; }
        #endregion
        
        #region Parameter MetricsDataSource_Dimension
        /// <summary>
        /// <para>
        /// <para>An object that contains a mapping between a <c>MetricDimensionName</c> and <c>MetricDimensionValue</c>
        /// to filter metrics by. Must contain a least 1 dimension but no more than 3 unique ones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MetricsDataSource_Dimensions")]
        public System.Collections.Hashtable MetricsDataSource_Dimension { get; set; }
        #endregion
        
        #region Parameter MessageInsightsDataSource_EndDate
        /// <summary>
        /// <para>
        /// <para>Represents the end date for the export interval as a timestamp. The end date is inclusive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MessageInsightsDataSource_EndDate")]
        public System.DateTime? MessageInsightsDataSource_EndDate { get; set; }
        #endregion
        
        #region Parameter MetricsDataSource_EndDate
        /// <summary>
        /// <para>
        /// <para>Represents the end date for the export interval as a timestamp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MetricsDataSource_EndDate")]
        public System.DateTime? MetricsDataSource_EndDate { get; set; }
        #endregion
        
        #region Parameter Exclude_FromEmailAddress
        /// <summary>
        /// <para>
        /// <para>The from address used to send the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MessageInsightsDataSource_Exclude_FromEmailAddress")]
        public System.String[] Exclude_FromEmailAddress { get; set; }
        #endregion
        
        #region Parameter Include_FromEmailAddress
        /// <summary>
        /// <para>
        /// <para>The from address used to send the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MessageInsightsDataSource_Include_FromEmailAddress")]
        public System.String[] Include_FromEmailAddress { get; set; }
        #endregion
        
        #region Parameter Exclude_Isp
        /// <summary>
        /// <para>
        /// <para>The recipient's ISP (e.g., <c>Gmail</c>, <c>Yahoo</c>, etc.).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MessageInsightsDataSource_Exclude_Isp")]
        public System.String[] Exclude_Isp { get; set; }
        #endregion
        
        #region Parameter Include_Isp
        /// <summary>
        /// <para>
        /// <para>The recipient's ISP (e.g., <c>Gmail</c>, <c>Yahoo</c>, etc.).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MessageInsightsDataSource_Include_Isp")]
        public System.String[] Include_Isp { get; set; }
        #endregion
        
        #region Parameter Exclude_LastDeliveryEvent
        /// <summary>
        /// <para>
        /// <para> The last delivery-related event for the email, where the ordering is as follows:
        /// <c>SEND</c> &lt; <c>BOUNCE</c> &lt; <c>DELIVERY</c> &lt; <c>COMPLAINT</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MessageInsightsDataSource_Exclude_LastDeliveryEvent")]
        public System.String[] Exclude_LastDeliveryEvent { get; set; }
        #endregion
        
        #region Parameter Include_LastDeliveryEvent
        /// <summary>
        /// <para>
        /// <para> The last delivery-related event for the email, where the ordering is as follows:
        /// <c>SEND</c> &lt; <c>BOUNCE</c> &lt; <c>DELIVERY</c> &lt; <c>COMPLAINT</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MessageInsightsDataSource_Include_LastDeliveryEvent")]
        public System.String[] Include_LastDeliveryEvent { get; set; }
        #endregion
        
        #region Parameter Exclude_LastEngagementEvent
        /// <summary>
        /// <para>
        /// <para> The last engagement-related event for the email, where the ordering is as follows:
        /// <c>OPEN</c> &lt; <c>CLICK</c>. </para><para> Engagement events are only available if <a href="https://docs.aws.amazon.com/ses/latest/dg/vdm-settings.html">Engagement
        /// tracking</a> is enabled. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MessageInsightsDataSource_Exclude_LastEngagementEvent")]
        public System.String[] Exclude_LastEngagementEvent { get; set; }
        #endregion
        
        #region Parameter Include_LastEngagementEvent
        /// <summary>
        /// <para>
        /// <para> The last engagement-related event for the email, where the ordering is as follows:
        /// <c>OPEN</c> &lt; <c>CLICK</c>. </para><para> Engagement events are only available if <a href="https://docs.aws.amazon.com/ses/latest/dg/vdm-settings.html">Engagement
        /// tracking</a> is enabled. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MessageInsightsDataSource_Include_LastEngagementEvent")]
        public System.String[] Include_LastEngagementEvent { get; set; }
        #endregion
        
        #region Parameter MessageInsightsDataSource_MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MessageInsightsDataSource_MaxResults")]
        public System.Int32? MessageInsightsDataSource_MaxResult { get; set; }
        #endregion
        
        #region Parameter MetricsDataSource_Metric
        /// <summary>
        /// <para>
        /// <para>A list of <c>ExportMetric</c> objects to export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MetricsDataSource_Metrics")]
        public Amazon.SimpleEmailV2.Model.ExportMetric[] MetricsDataSource_Metric { get; set; }
        #endregion
        
        #region Parameter MetricsDataSource_Namespace
        /// <summary>
        /// <para>
        /// <para>The metrics namespace - e.g., <c>VDM</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MetricsDataSource_Namespace")]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.MetricNamespace")]
        public Amazon.SimpleEmailV2.MetricNamespace MetricsDataSource_Namespace { get; set; }
        #endregion
        
        #region Parameter ExportDestination_S3Url
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 pre-signed URL that points to the generated export file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExportDestination_S3Url { get; set; }
        #endregion
        
        #region Parameter MessageInsightsDataSource_StartDate
        /// <summary>
        /// <para>
        /// <para>Represents the start date for the export interval as a timestamp. The start date is
        /// inclusive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MessageInsightsDataSource_StartDate")]
        public System.DateTime? MessageInsightsDataSource_StartDate { get; set; }
        #endregion
        
        #region Parameter MetricsDataSource_StartDate
        /// <summary>
        /// <para>
        /// <para>Represents the start date for the export interval as a timestamp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MetricsDataSource_StartDate")]
        public System.DateTime? MetricsDataSource_StartDate { get; set; }
        #endregion
        
        #region Parameter Exclude_Subject
        /// <summary>
        /// <para>
        /// <para>The subject line of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MessageInsightsDataSource_Exclude_Subject")]
        public System.String[] Exclude_Subject { get; set; }
        #endregion
        
        #region Parameter Include_Subject
        /// <summary>
        /// <para>
        /// <para>The subject line of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportDataSource_MessageInsightsDataSource_Include_Subject")]
        public System.String[] Include_Subject { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.CreateExportJobResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmailV2.Model.CreateExportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExportDestination_DataFormat), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SES2ExportJob (CreateExportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.CreateExportJobResponse, NewSES2ExportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MessageInsightsDataSource_EndDate = this.MessageInsightsDataSource_EndDate;
            if (this.Exclude_Destination != null)
            {
                context.Exclude_Destination = new List<System.String>(this.Exclude_Destination);
            }
            if (this.Exclude_FromEmailAddress != null)
            {
                context.Exclude_FromEmailAddress = new List<System.String>(this.Exclude_FromEmailAddress);
            }
            if (this.Exclude_Isp != null)
            {
                context.Exclude_Isp = new List<System.String>(this.Exclude_Isp);
            }
            if (this.Exclude_LastDeliveryEvent != null)
            {
                context.Exclude_LastDeliveryEvent = new List<System.String>(this.Exclude_LastDeliveryEvent);
            }
            if (this.Exclude_LastEngagementEvent != null)
            {
                context.Exclude_LastEngagementEvent = new List<System.String>(this.Exclude_LastEngagementEvent);
            }
            if (this.Exclude_Subject != null)
            {
                context.Exclude_Subject = new List<System.String>(this.Exclude_Subject);
            }
            if (this.Include_Destination != null)
            {
                context.Include_Destination = new List<System.String>(this.Include_Destination);
            }
            if (this.Include_FromEmailAddress != null)
            {
                context.Include_FromEmailAddress = new List<System.String>(this.Include_FromEmailAddress);
            }
            if (this.Include_Isp != null)
            {
                context.Include_Isp = new List<System.String>(this.Include_Isp);
            }
            if (this.Include_LastDeliveryEvent != null)
            {
                context.Include_LastDeliveryEvent = new List<System.String>(this.Include_LastDeliveryEvent);
            }
            if (this.Include_LastEngagementEvent != null)
            {
                context.Include_LastEngagementEvent = new List<System.String>(this.Include_LastEngagementEvent);
            }
            if (this.Include_Subject != null)
            {
                context.Include_Subject = new List<System.String>(this.Include_Subject);
            }
            context.MessageInsightsDataSource_MaxResult = this.MessageInsightsDataSource_MaxResult;
            context.MessageInsightsDataSource_StartDate = this.MessageInsightsDataSource_StartDate;
            if (this.MetricsDataSource_Dimension != null)
            {
                context.MetricsDataSource_Dimension = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.MetricsDataSource_Dimension.Keys)
                {
                    object hashValue = this.MetricsDataSource_Dimension[hashKey];
                    if (hashValue == null)
                    {
                        context.MetricsDataSource_Dimension.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.MetricsDataSource_Dimension.Add((String)hashKey, valueSet);
                }
            }
            context.MetricsDataSource_EndDate = this.MetricsDataSource_EndDate;
            if (this.MetricsDataSource_Metric != null)
            {
                context.MetricsDataSource_Metric = new List<Amazon.SimpleEmailV2.Model.ExportMetric>(this.MetricsDataSource_Metric);
            }
            context.MetricsDataSource_Namespace = this.MetricsDataSource_Namespace;
            context.MetricsDataSource_StartDate = this.MetricsDataSource_StartDate;
            context.ExportDestination_DataFormat = this.ExportDestination_DataFormat;
            #if MODULAR
            if (this.ExportDestination_DataFormat == null && ParameterWasBound(nameof(this.ExportDestination_DataFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportDestination_DataFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExportDestination_S3Url = this.ExportDestination_S3Url;
            
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
            var request = new Amazon.SimpleEmailV2.Model.CreateExportJobRequest();
            
            
             // populate ExportDataSource
            var requestExportDataSourceIsNull = true;
            request.ExportDataSource = new Amazon.SimpleEmailV2.Model.ExportDataSource();
            Amazon.SimpleEmailV2.Model.MessageInsightsDataSource requestExportDataSource_exportDataSource_MessageInsightsDataSource = null;
            
             // populate MessageInsightsDataSource
            var requestExportDataSource_exportDataSource_MessageInsightsDataSourceIsNull = true;
            requestExportDataSource_exportDataSource_MessageInsightsDataSource = new Amazon.SimpleEmailV2.Model.MessageInsightsDataSource();
            System.DateTime? requestExportDataSource_exportDataSource_MessageInsightsDataSource_messageInsightsDataSource_EndDate = null;
            if (cmdletContext.MessageInsightsDataSource_EndDate != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_messageInsightsDataSource_EndDate = cmdletContext.MessageInsightsDataSource_EndDate.Value;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_messageInsightsDataSource_EndDate != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource.EndDate = requestExportDataSource_exportDataSource_MessageInsightsDataSource_messageInsightsDataSource_EndDate.Value;
                requestExportDataSource_exportDataSource_MessageInsightsDataSourceIsNull = false;
            }
            System.Int32? requestExportDataSource_exportDataSource_MessageInsightsDataSource_messageInsightsDataSource_MaxResult = null;
            if (cmdletContext.MessageInsightsDataSource_MaxResult != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_messageInsightsDataSource_MaxResult = cmdletContext.MessageInsightsDataSource_MaxResult.Value;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_messageInsightsDataSource_MaxResult != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource.MaxResults = requestExportDataSource_exportDataSource_MessageInsightsDataSource_messageInsightsDataSource_MaxResult.Value;
                requestExportDataSource_exportDataSource_MessageInsightsDataSourceIsNull = false;
            }
            System.DateTime? requestExportDataSource_exportDataSource_MessageInsightsDataSource_messageInsightsDataSource_StartDate = null;
            if (cmdletContext.MessageInsightsDataSource_StartDate != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_messageInsightsDataSource_StartDate = cmdletContext.MessageInsightsDataSource_StartDate.Value;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_messageInsightsDataSource_StartDate != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource.StartDate = requestExportDataSource_exportDataSource_MessageInsightsDataSource_messageInsightsDataSource_StartDate.Value;
                requestExportDataSource_exportDataSource_MessageInsightsDataSourceIsNull = false;
            }
            Amazon.SimpleEmailV2.Model.MessageInsightsFilters requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude = null;
            
             // populate Exclude
            var requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_ExcludeIsNull = true;
            requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude = new Amazon.SimpleEmailV2.Model.MessageInsightsFilters();
            List<System.String> requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_Destination = null;
            if (cmdletContext.Exclude_Destination != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_Destination = cmdletContext.Exclude_Destination;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_Destination != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude.Destination = requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_Destination;
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_ExcludeIsNull = false;
            }
            List<System.String> requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_FromEmailAddress = null;
            if (cmdletContext.Exclude_FromEmailAddress != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_FromEmailAddress = cmdletContext.Exclude_FromEmailAddress;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_FromEmailAddress != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude.FromEmailAddress = requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_FromEmailAddress;
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_ExcludeIsNull = false;
            }
            List<System.String> requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_Isp = null;
            if (cmdletContext.Exclude_Isp != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_Isp = cmdletContext.Exclude_Isp;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_Isp != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude.Isp = requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_Isp;
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_ExcludeIsNull = false;
            }
            List<System.String> requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_LastDeliveryEvent = null;
            if (cmdletContext.Exclude_LastDeliveryEvent != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_LastDeliveryEvent = cmdletContext.Exclude_LastDeliveryEvent;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_LastDeliveryEvent != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude.LastDeliveryEvent = requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_LastDeliveryEvent;
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_ExcludeIsNull = false;
            }
            List<System.String> requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_LastEngagementEvent = null;
            if (cmdletContext.Exclude_LastEngagementEvent != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_LastEngagementEvent = cmdletContext.Exclude_LastEngagementEvent;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_LastEngagementEvent != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude.LastEngagementEvent = requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_LastEngagementEvent;
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_ExcludeIsNull = false;
            }
            List<System.String> requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_Subject = null;
            if (cmdletContext.Exclude_Subject != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_Subject = cmdletContext.Exclude_Subject;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_Subject != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude.Subject = requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude_exclude_Subject;
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_ExcludeIsNull = false;
            }
             // determine if requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude should be set to null
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_ExcludeIsNull)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude = null;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource.Exclude = requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Exclude;
                requestExportDataSource_exportDataSource_MessageInsightsDataSourceIsNull = false;
            }
            Amazon.SimpleEmailV2.Model.MessageInsightsFilters requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include = null;
            
             // populate Include
            var requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_IncludeIsNull = true;
            requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include = new Amazon.SimpleEmailV2.Model.MessageInsightsFilters();
            List<System.String> requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_Destination = null;
            if (cmdletContext.Include_Destination != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_Destination = cmdletContext.Include_Destination;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_Destination != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include.Destination = requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_Destination;
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_IncludeIsNull = false;
            }
            List<System.String> requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_FromEmailAddress = null;
            if (cmdletContext.Include_FromEmailAddress != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_FromEmailAddress = cmdletContext.Include_FromEmailAddress;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_FromEmailAddress != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include.FromEmailAddress = requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_FromEmailAddress;
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_IncludeIsNull = false;
            }
            List<System.String> requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_Isp = null;
            if (cmdletContext.Include_Isp != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_Isp = cmdletContext.Include_Isp;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_Isp != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include.Isp = requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_Isp;
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_IncludeIsNull = false;
            }
            List<System.String> requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_LastDeliveryEvent = null;
            if (cmdletContext.Include_LastDeliveryEvent != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_LastDeliveryEvent = cmdletContext.Include_LastDeliveryEvent;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_LastDeliveryEvent != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include.LastDeliveryEvent = requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_LastDeliveryEvent;
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_IncludeIsNull = false;
            }
            List<System.String> requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_LastEngagementEvent = null;
            if (cmdletContext.Include_LastEngagementEvent != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_LastEngagementEvent = cmdletContext.Include_LastEngagementEvent;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_LastEngagementEvent != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include.LastEngagementEvent = requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_LastEngagementEvent;
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_IncludeIsNull = false;
            }
            List<System.String> requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_Subject = null;
            if (cmdletContext.Include_Subject != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_Subject = cmdletContext.Include_Subject;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_Subject != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include.Subject = requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include_include_Subject;
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_IncludeIsNull = false;
            }
             // determine if requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include should be set to null
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_IncludeIsNull)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include = null;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include != null)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource.Include = requestExportDataSource_exportDataSource_MessageInsightsDataSource_exportDataSource_MessageInsightsDataSource_Include;
                requestExportDataSource_exportDataSource_MessageInsightsDataSourceIsNull = false;
            }
             // determine if requestExportDataSource_exportDataSource_MessageInsightsDataSource should be set to null
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSourceIsNull)
            {
                requestExportDataSource_exportDataSource_MessageInsightsDataSource = null;
            }
            if (requestExportDataSource_exportDataSource_MessageInsightsDataSource != null)
            {
                request.ExportDataSource.MessageInsightsDataSource = requestExportDataSource_exportDataSource_MessageInsightsDataSource;
                requestExportDataSourceIsNull = false;
            }
            Amazon.SimpleEmailV2.Model.MetricsDataSource requestExportDataSource_exportDataSource_MetricsDataSource = null;
            
             // populate MetricsDataSource
            var requestExportDataSource_exportDataSource_MetricsDataSourceIsNull = true;
            requestExportDataSource_exportDataSource_MetricsDataSource = new Amazon.SimpleEmailV2.Model.MetricsDataSource();
            Dictionary<System.String, List<System.String>> requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_Dimension = null;
            if (cmdletContext.MetricsDataSource_Dimension != null)
            {
                requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_Dimension = cmdletContext.MetricsDataSource_Dimension;
            }
            if (requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_Dimension != null)
            {
                requestExportDataSource_exportDataSource_MetricsDataSource.Dimensions = requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_Dimension;
                requestExportDataSource_exportDataSource_MetricsDataSourceIsNull = false;
            }
            System.DateTime? requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_EndDate = null;
            if (cmdletContext.MetricsDataSource_EndDate != null)
            {
                requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_EndDate = cmdletContext.MetricsDataSource_EndDate.Value;
            }
            if (requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_EndDate != null)
            {
                requestExportDataSource_exportDataSource_MetricsDataSource.EndDate = requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_EndDate.Value;
                requestExportDataSource_exportDataSource_MetricsDataSourceIsNull = false;
            }
            List<Amazon.SimpleEmailV2.Model.ExportMetric> requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_Metric = null;
            if (cmdletContext.MetricsDataSource_Metric != null)
            {
                requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_Metric = cmdletContext.MetricsDataSource_Metric;
            }
            if (requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_Metric != null)
            {
                requestExportDataSource_exportDataSource_MetricsDataSource.Metrics = requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_Metric;
                requestExportDataSource_exportDataSource_MetricsDataSourceIsNull = false;
            }
            Amazon.SimpleEmailV2.MetricNamespace requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_Namespace = null;
            if (cmdletContext.MetricsDataSource_Namespace != null)
            {
                requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_Namespace = cmdletContext.MetricsDataSource_Namespace;
            }
            if (requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_Namespace != null)
            {
                requestExportDataSource_exportDataSource_MetricsDataSource.Namespace = requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_Namespace;
                requestExportDataSource_exportDataSource_MetricsDataSourceIsNull = false;
            }
            System.DateTime? requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_StartDate = null;
            if (cmdletContext.MetricsDataSource_StartDate != null)
            {
                requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_StartDate = cmdletContext.MetricsDataSource_StartDate.Value;
            }
            if (requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_StartDate != null)
            {
                requestExportDataSource_exportDataSource_MetricsDataSource.StartDate = requestExportDataSource_exportDataSource_MetricsDataSource_metricsDataSource_StartDate.Value;
                requestExportDataSource_exportDataSource_MetricsDataSourceIsNull = false;
            }
             // determine if requestExportDataSource_exportDataSource_MetricsDataSource should be set to null
            if (requestExportDataSource_exportDataSource_MetricsDataSourceIsNull)
            {
                requestExportDataSource_exportDataSource_MetricsDataSource = null;
            }
            if (requestExportDataSource_exportDataSource_MetricsDataSource != null)
            {
                request.ExportDataSource.MetricsDataSource = requestExportDataSource_exportDataSource_MetricsDataSource;
                requestExportDataSourceIsNull = false;
            }
             // determine if request.ExportDataSource should be set to null
            if (requestExportDataSourceIsNull)
            {
                request.ExportDataSource = null;
            }
            
             // populate ExportDestination
            var requestExportDestinationIsNull = true;
            request.ExportDestination = new Amazon.SimpleEmailV2.Model.ExportDestination();
            Amazon.SimpleEmailV2.DataFormat requestExportDestination_exportDestination_DataFormat = null;
            if (cmdletContext.ExportDestination_DataFormat != null)
            {
                requestExportDestination_exportDestination_DataFormat = cmdletContext.ExportDestination_DataFormat;
            }
            if (requestExportDestination_exportDestination_DataFormat != null)
            {
                request.ExportDestination.DataFormat = requestExportDestination_exportDestination_DataFormat;
                requestExportDestinationIsNull = false;
            }
            System.String requestExportDestination_exportDestination_S3Url = null;
            if (cmdletContext.ExportDestination_S3Url != null)
            {
                requestExportDestination_exportDestination_S3Url = cmdletContext.ExportDestination_S3Url;
            }
            if (requestExportDestination_exportDestination_S3Url != null)
            {
                request.ExportDestination.S3Url = requestExportDestination_exportDestination_S3Url;
                requestExportDestinationIsNull = false;
            }
             // determine if request.ExportDestination should be set to null
            if (requestExportDestinationIsNull)
            {
                request.ExportDestination = null;
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
        
        private Amazon.SimpleEmailV2.Model.CreateExportJobResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.CreateExportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "CreateExportJob");
            try
            {
                return client.CreateExportJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? MessageInsightsDataSource_EndDate { get; set; }
            public List<System.String> Exclude_Destination { get; set; }
            public List<System.String> Exclude_FromEmailAddress { get; set; }
            public List<System.String> Exclude_Isp { get; set; }
            public List<System.String> Exclude_LastDeliveryEvent { get; set; }
            public List<System.String> Exclude_LastEngagementEvent { get; set; }
            public List<System.String> Exclude_Subject { get; set; }
            public List<System.String> Include_Destination { get; set; }
            public List<System.String> Include_FromEmailAddress { get; set; }
            public List<System.String> Include_Isp { get; set; }
            public List<System.String> Include_LastDeliveryEvent { get; set; }
            public List<System.String> Include_LastEngagementEvent { get; set; }
            public List<System.String> Include_Subject { get; set; }
            public System.Int32? MessageInsightsDataSource_MaxResult { get; set; }
            public System.DateTime? MessageInsightsDataSource_StartDate { get; set; }
            public Dictionary<System.String, List<System.String>> MetricsDataSource_Dimension { get; set; }
            public System.DateTime? MetricsDataSource_EndDate { get; set; }
            public List<Amazon.SimpleEmailV2.Model.ExportMetric> MetricsDataSource_Metric { get; set; }
            public Amazon.SimpleEmailV2.MetricNamespace MetricsDataSource_Namespace { get; set; }
            public System.DateTime? MetricsDataSource_StartDate { get; set; }
            public Amazon.SimpleEmailV2.DataFormat ExportDestination_DataFormat { get; set; }
            public System.String ExportDestination_S3Url { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.CreateExportJobResponse, NewSES2ExportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
