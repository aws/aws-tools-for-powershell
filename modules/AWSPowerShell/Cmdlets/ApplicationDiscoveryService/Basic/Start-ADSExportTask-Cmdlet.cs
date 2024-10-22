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
using Amazon.ApplicationDiscoveryService;
using Amazon.ApplicationDiscoveryService.Model;

namespace Amazon.PowerShell.Cmdlets.ADS
{
    /// <summary>
    /// Begins the export of a discovered data report to an Amazon S3 bucket managed by Amazon
    /// Web Services.
    /// 
    ///  <note><para>
    /// Exports might provide an estimate of fees and savings based on certain information
    /// that you provide. Fee estimates do not include any taxes that might apply. Your actual
    /// fees and savings depend on a variety of factors, including your actual usage of Amazon
    /// Web Services services, which might vary from the estimates provided in this report.
    /// </para></note><para>
    /// If you do not specify <c>preferences</c> or <c>agentIds</c> in the filter, a summary
    /// of all servers, applications, tags, and performance is generated. This data is an
    /// aggregation of all server data collected through on-premises tooling, file import,
    /// application grouping and applying tags.
    /// </para><para>
    /// If you specify <c>agentIds</c> in a filter, the task exports up to 72 hours of detailed
    /// data collected by the identified Application Discovery Agent, including network, process,
    /// and performance details. A time range for exported agent data may be set by using
    /// <c>startTime</c> and <c>endTime</c>. Export of detailed agent data is limited to five
    /// concurrently running exports. Export of detailed agent data is limited to two exports
    /// per day.
    /// </para><para>
    /// If you enable <c>ec2RecommendationsPreferences</c> in <c>preferences</c> , an Amazon
    /// EC2 instance matching the characteristics of each server in Application Discovery
    /// Service is generated. Changing the attributes of the <c>ec2RecommendationsPreferences</c>
    /// changes the criteria of the recommendation.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "ADSExportTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Application Discovery Service StartExportTask API operation.", Operation = new[] {"StartExportTask"}, SelectReturnType = typeof(Amazon.ApplicationDiscoveryService.Model.StartExportTaskResponse))]
    [AWSCmdletOutput("System.String or Amazon.ApplicationDiscoveryService.Model.StartExportTaskResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ApplicationDiscoveryService.Model.StartExportTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartADSExportTaskCmdlet : AmazonApplicationDiscoveryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Ec2RecommendationsPreferences_Enabled
        /// <summary>
        /// <para>
        /// <para> If set to true, the export <a href="https://docs.aws.amazon.com/application-discovery/latest/APIReference/API_StartExportTask.html#API_StartExportTask_RequestSyntax">preferences</a>
        /// is set to <c>Ec2RecommendationsExportPreferences</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_Ec2RecommendationsPreferences_Enabled")]
        public System.Boolean? Ec2RecommendationsPreferences_Enabled { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end timestamp for exported data from the single Application Discovery Agent selected
        /// in the filters. If no value is specified, exported data includes the most recent data
        /// collected by the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter Ec2RecommendationsPreferences_ExcludedInstanceType
        /// <summary>
        /// <para>
        /// <para> An array of instance types to exclude from recommendations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_Ec2RecommendationsPreferences_ExcludedInstanceTypes")]
        public System.String[] Ec2RecommendationsPreferences_ExcludedInstanceType { get; set; }
        #endregion
        
        #region Parameter ExportDataFormat
        /// <summary>
        /// <para>
        /// <para>The file format for the returned export data. Default value is <c>CSV</c>. <b>Note:</b><i>The</i><c>GRAPHML</c><i>option has been deprecated.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String[] ExportDataFormat { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>If a filter is present, it selects the single <c>agentId</c> of the Application Discovery
        /// Agent for which data is exported. The <c>agentId</c> can be found in the results of
        /// the <c>DescribeAgents</c> API or CLI. If no filter is present, <c>startTime</c> and
        /// <c>endTime</c> are ignored and exported data includes both Amazon Web Services Application
        /// Discovery Service Agentless Collector collectors data and summary data from Application
        /// Discovery Agent agents. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.ApplicationDiscoveryService.Model.ExportFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter CpuPerformanceMetricBasis_Name
        /// <summary>
        /// <para>
        /// <para> A utilization metric that is used by the recommendations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis_Name")]
        public System.String CpuPerformanceMetricBasis_Name { get; set; }
        #endregion
        
        #region Parameter RamPerformanceMetricBasis_Name
        /// <summary>
        /// <para>
        /// <para> A utilization metric that is used by the recommendations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis_Name")]
        public System.String RamPerformanceMetricBasis_Name { get; set; }
        #endregion
        
        #region Parameter ReservedInstanceOptions_OfferingClass
        /// <summary>
        /// <para>
        /// <para> The flexibility to change the instance types needed for your Reserved Instance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions_OfferingClass")]
        [AWSConstantClassSource("Amazon.ApplicationDiscoveryService.OfferingClass")]
        public Amazon.ApplicationDiscoveryService.OfferingClass ReservedInstanceOptions_OfferingClass { get; set; }
        #endregion
        
        #region Parameter CpuPerformanceMetricBasis_PercentageAdjust
        /// <summary>
        /// <para>
        /// <para> Specifies the percentage of the specified utilization metric that is used by the
        /// recommendations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis_PercentageAdjust")]
        public System.Double? CpuPerformanceMetricBasis_PercentageAdjust { get; set; }
        #endregion
        
        #region Parameter RamPerformanceMetricBasis_PercentageAdjust
        /// <summary>
        /// <para>
        /// <para> Specifies the percentage of the specified utilization metric that is used by the
        /// recommendations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis_PercentageAdjust")]
        public System.Double? RamPerformanceMetricBasis_PercentageAdjust { get; set; }
        #endregion
        
        #region Parameter Ec2RecommendationsPreferences_PreferredRegion
        /// <summary>
        /// <para>
        /// <para> The target Amazon Web Services Region for the recommendations. You can use any of
        /// the Region codes available for the chosen service, as listed in <a href="https://docs.aws.amazon.com/general/latest/gr/rande.html">Amazon
        /// Web Services service endpoints</a> in the <i>Amazon Web Services General Reference</i>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_Ec2RecommendationsPreferences_PreferredRegion")]
        public System.String Ec2RecommendationsPreferences_PreferredRegion { get; set; }
        #endregion
        
        #region Parameter ReservedInstanceOptions_PurchasingOption
        /// <summary>
        /// <para>
        /// <para> The payment plan to use for your Reserved Instance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions_PurchasingOption")]
        [AWSConstantClassSource("Amazon.ApplicationDiscoveryService.PurchasingOption")]
        public Amazon.ApplicationDiscoveryService.PurchasingOption ReservedInstanceOptions_PurchasingOption { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start timestamp for exported data from the single Application Discovery Agent
        /// selected in the filters. If no value is specified, data is exported starting from
        /// the first data collected by the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Ec2RecommendationsPreferences_Tenancy
        /// <summary>
        /// <para>
        /// <para> The target tenancy to use for your recommended EC2 instances. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_Ec2RecommendationsPreferences_Tenancy")]
        [AWSConstantClassSource("Amazon.ApplicationDiscoveryService.Tenancy")]
        public Amazon.ApplicationDiscoveryService.Tenancy Ec2RecommendationsPreferences_Tenancy { get; set; }
        #endregion
        
        #region Parameter ReservedInstanceOptions_TermLength
        /// <summary>
        /// <para>
        /// <para> The preferred duration of the Reserved Instance term. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions_TermLength")]
        [AWSConstantClassSource("Amazon.ApplicationDiscoveryService.TermLength")]
        public Amazon.ApplicationDiscoveryService.TermLength ReservedInstanceOptions_TermLength { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExportId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationDiscoveryService.Model.StartExportTaskResponse).
        /// Specifying the name of a property of type Amazon.ApplicationDiscoveryService.Model.StartExportTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExportId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ADSExportTask (StartExportTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationDiscoveryService.Model.StartExportTaskResponse, StartADSExportTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            if (this.ExportDataFormat != null)
            {
                context.ExportDataFormat = new List<System.String>(this.ExportDataFormat);
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.ApplicationDiscoveryService.Model.ExportFilter>(this.Filter);
            }
            context.CpuPerformanceMetricBasis_Name = this.CpuPerformanceMetricBasis_Name;
            context.CpuPerformanceMetricBasis_PercentageAdjust = this.CpuPerformanceMetricBasis_PercentageAdjust;
            context.Ec2RecommendationsPreferences_Enabled = this.Ec2RecommendationsPreferences_Enabled;
            if (this.Ec2RecommendationsPreferences_ExcludedInstanceType != null)
            {
                context.Ec2RecommendationsPreferences_ExcludedInstanceType = new List<System.String>(this.Ec2RecommendationsPreferences_ExcludedInstanceType);
            }
            context.Ec2RecommendationsPreferences_PreferredRegion = this.Ec2RecommendationsPreferences_PreferredRegion;
            context.RamPerformanceMetricBasis_Name = this.RamPerformanceMetricBasis_Name;
            context.RamPerformanceMetricBasis_PercentageAdjust = this.RamPerformanceMetricBasis_PercentageAdjust;
            context.ReservedInstanceOptions_OfferingClass = this.ReservedInstanceOptions_OfferingClass;
            context.ReservedInstanceOptions_PurchasingOption = this.ReservedInstanceOptions_PurchasingOption;
            context.ReservedInstanceOptions_TermLength = this.ReservedInstanceOptions_TermLength;
            context.Ec2RecommendationsPreferences_Tenancy = this.Ec2RecommendationsPreferences_Tenancy;
            context.StartTime = this.StartTime;
            
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
            var request = new Amazon.ApplicationDiscoveryService.Model.StartExportTaskRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.ExportDataFormat != null)
            {
                request.ExportDataFormat = cmdletContext.ExportDataFormat;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            
             // populate Preferences
            var requestPreferencesIsNull = true;
            request.Preferences = new Amazon.ApplicationDiscoveryService.Model.ExportPreferences();
            Amazon.ApplicationDiscoveryService.Model.Ec2RecommendationsExportPreferences requestPreferences_preferences_Ec2RecommendationsPreferences = null;
            
             // populate Ec2RecommendationsPreferences
            var requestPreferences_preferences_Ec2RecommendationsPreferencesIsNull = true;
            requestPreferences_preferences_Ec2RecommendationsPreferences = new Amazon.ApplicationDiscoveryService.Model.Ec2RecommendationsExportPreferences();
            System.Boolean? requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_Enabled = null;
            if (cmdletContext.Ec2RecommendationsPreferences_Enabled != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_Enabled = cmdletContext.Ec2RecommendationsPreferences_Enabled.Value;
            }
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_Enabled != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences.Enabled = requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_Enabled.Value;
                requestPreferences_preferences_Ec2RecommendationsPreferencesIsNull = false;
            }
            List<System.String> requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_ExcludedInstanceType = null;
            if (cmdletContext.Ec2RecommendationsPreferences_ExcludedInstanceType != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_ExcludedInstanceType = cmdletContext.Ec2RecommendationsPreferences_ExcludedInstanceType;
            }
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_ExcludedInstanceType != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences.ExcludedInstanceTypes = requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_ExcludedInstanceType;
                requestPreferences_preferences_Ec2RecommendationsPreferencesIsNull = false;
            }
            System.String requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_PreferredRegion = null;
            if (cmdletContext.Ec2RecommendationsPreferences_PreferredRegion != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_PreferredRegion = cmdletContext.Ec2RecommendationsPreferences_PreferredRegion;
            }
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_PreferredRegion != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences.PreferredRegion = requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_PreferredRegion;
                requestPreferences_preferences_Ec2RecommendationsPreferencesIsNull = false;
            }
            Amazon.ApplicationDiscoveryService.Tenancy requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_Tenancy = null;
            if (cmdletContext.Ec2RecommendationsPreferences_Tenancy != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_Tenancy = cmdletContext.Ec2RecommendationsPreferences_Tenancy;
            }
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_Tenancy != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences.Tenancy = requestPreferences_preferences_Ec2RecommendationsPreferences_ec2RecommendationsPreferences_Tenancy;
                requestPreferences_preferences_Ec2RecommendationsPreferencesIsNull = false;
            }
            Amazon.ApplicationDiscoveryService.Model.UsageMetricBasis requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis = null;
            
             // populate CpuPerformanceMetricBasis
            var requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasisIsNull = true;
            requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis = new Amazon.ApplicationDiscoveryService.Model.UsageMetricBasis();
            System.String requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis_cpuPerformanceMetricBasis_Name = null;
            if (cmdletContext.CpuPerformanceMetricBasis_Name != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis_cpuPerformanceMetricBasis_Name = cmdletContext.CpuPerformanceMetricBasis_Name;
            }
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis_cpuPerformanceMetricBasis_Name != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis.Name = requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis_cpuPerformanceMetricBasis_Name;
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasisIsNull = false;
            }
            System.Double? requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis_cpuPerformanceMetricBasis_PercentageAdjust = null;
            if (cmdletContext.CpuPerformanceMetricBasis_PercentageAdjust != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis_cpuPerformanceMetricBasis_PercentageAdjust = cmdletContext.CpuPerformanceMetricBasis_PercentageAdjust.Value;
            }
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis_cpuPerformanceMetricBasis_PercentageAdjust != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis.PercentageAdjust = requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis_cpuPerformanceMetricBasis_PercentageAdjust.Value;
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasisIsNull = false;
            }
             // determine if requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis should be set to null
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasisIsNull)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis = null;
            }
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences.CpuPerformanceMetricBasis = requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_CpuPerformanceMetricBasis;
                requestPreferences_preferences_Ec2RecommendationsPreferencesIsNull = false;
            }
            Amazon.ApplicationDiscoveryService.Model.UsageMetricBasis requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis = null;
            
             // populate RamPerformanceMetricBasis
            var requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasisIsNull = true;
            requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis = new Amazon.ApplicationDiscoveryService.Model.UsageMetricBasis();
            System.String requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis_ramPerformanceMetricBasis_Name = null;
            if (cmdletContext.RamPerformanceMetricBasis_Name != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis_ramPerformanceMetricBasis_Name = cmdletContext.RamPerformanceMetricBasis_Name;
            }
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis_ramPerformanceMetricBasis_Name != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis.Name = requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis_ramPerformanceMetricBasis_Name;
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasisIsNull = false;
            }
            System.Double? requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis_ramPerformanceMetricBasis_PercentageAdjust = null;
            if (cmdletContext.RamPerformanceMetricBasis_PercentageAdjust != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis_ramPerformanceMetricBasis_PercentageAdjust = cmdletContext.RamPerformanceMetricBasis_PercentageAdjust.Value;
            }
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis_ramPerformanceMetricBasis_PercentageAdjust != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis.PercentageAdjust = requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis_ramPerformanceMetricBasis_PercentageAdjust.Value;
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasisIsNull = false;
            }
             // determine if requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis should be set to null
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasisIsNull)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis = null;
            }
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences.RamPerformanceMetricBasis = requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_RamPerformanceMetricBasis;
                requestPreferences_preferences_Ec2RecommendationsPreferencesIsNull = false;
            }
            Amazon.ApplicationDiscoveryService.Model.ReservedInstanceOptions requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions = null;
            
             // populate ReservedInstanceOptions
            var requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptionsIsNull = true;
            requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions = new Amazon.ApplicationDiscoveryService.Model.ReservedInstanceOptions();
            Amazon.ApplicationDiscoveryService.OfferingClass requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions_reservedInstanceOptions_OfferingClass = null;
            if (cmdletContext.ReservedInstanceOptions_OfferingClass != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions_reservedInstanceOptions_OfferingClass = cmdletContext.ReservedInstanceOptions_OfferingClass;
            }
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions_reservedInstanceOptions_OfferingClass != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions.OfferingClass = requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions_reservedInstanceOptions_OfferingClass;
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptionsIsNull = false;
            }
            Amazon.ApplicationDiscoveryService.PurchasingOption requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions_reservedInstanceOptions_PurchasingOption = null;
            if (cmdletContext.ReservedInstanceOptions_PurchasingOption != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions_reservedInstanceOptions_PurchasingOption = cmdletContext.ReservedInstanceOptions_PurchasingOption;
            }
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions_reservedInstanceOptions_PurchasingOption != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions.PurchasingOption = requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions_reservedInstanceOptions_PurchasingOption;
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptionsIsNull = false;
            }
            Amazon.ApplicationDiscoveryService.TermLength requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions_reservedInstanceOptions_TermLength = null;
            if (cmdletContext.ReservedInstanceOptions_TermLength != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions_reservedInstanceOptions_TermLength = cmdletContext.ReservedInstanceOptions_TermLength;
            }
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions_reservedInstanceOptions_TermLength != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions.TermLength = requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions_reservedInstanceOptions_TermLength;
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptionsIsNull = false;
            }
             // determine if requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions should be set to null
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptionsIsNull)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions = null;
            }
            if (requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions != null)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences.ReservedInstanceOptions = requestPreferences_preferences_Ec2RecommendationsPreferences_preferences_Ec2RecommendationsPreferences_ReservedInstanceOptions;
                requestPreferences_preferences_Ec2RecommendationsPreferencesIsNull = false;
            }
             // determine if requestPreferences_preferences_Ec2RecommendationsPreferences should be set to null
            if (requestPreferences_preferences_Ec2RecommendationsPreferencesIsNull)
            {
                requestPreferences_preferences_Ec2RecommendationsPreferences = null;
            }
            if (requestPreferences_preferences_Ec2RecommendationsPreferences != null)
            {
                request.Preferences.Ec2RecommendationsPreferences = requestPreferences_preferences_Ec2RecommendationsPreferences;
                requestPreferencesIsNull = false;
            }
             // determine if request.Preferences should be set to null
            if (requestPreferencesIsNull)
            {
                request.Preferences = null;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        private Amazon.ApplicationDiscoveryService.Model.StartExportTaskResponse CallAWSServiceOperation(IAmazonApplicationDiscoveryService client, Amazon.ApplicationDiscoveryService.Model.StartExportTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Application Discovery Service", "StartExportTask");
            try
            {
                #if DESKTOP
                return client.StartExportTask(request);
                #elif CORECLR
                return client.StartExportTaskAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public List<System.String> ExportDataFormat { get; set; }
            public List<Amazon.ApplicationDiscoveryService.Model.ExportFilter> Filter { get; set; }
            public System.String CpuPerformanceMetricBasis_Name { get; set; }
            public System.Double? CpuPerformanceMetricBasis_PercentageAdjust { get; set; }
            public System.Boolean? Ec2RecommendationsPreferences_Enabled { get; set; }
            public List<System.String> Ec2RecommendationsPreferences_ExcludedInstanceType { get; set; }
            public System.String Ec2RecommendationsPreferences_PreferredRegion { get; set; }
            public System.String RamPerformanceMetricBasis_Name { get; set; }
            public System.Double? RamPerformanceMetricBasis_PercentageAdjust { get; set; }
            public Amazon.ApplicationDiscoveryService.OfferingClass ReservedInstanceOptions_OfferingClass { get; set; }
            public Amazon.ApplicationDiscoveryService.PurchasingOption ReservedInstanceOptions_PurchasingOption { get; set; }
            public Amazon.ApplicationDiscoveryService.TermLength ReservedInstanceOptions_TermLength { get; set; }
            public Amazon.ApplicationDiscoveryService.Tenancy Ec2RecommendationsPreferences_Tenancy { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.ApplicationDiscoveryService.Model.StartExportTaskResponse, StartADSExportTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExportId;
        }
        
    }
}
