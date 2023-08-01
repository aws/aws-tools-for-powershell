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
using Amazon.InternetMonitor;
using Amazon.InternetMonitor.Model;

namespace Amazon.PowerShell.Cmdlets.CWIM
{
    /// <summary>
    /// Creates a monitor in Amazon CloudWatch Internet Monitor. A monitor is built based
    /// on information from the application resources that you add: VPCs, Network Load Balancers
    /// (NLBs), Amazon CloudFront distributions, and Amazon WorkSpaces directories. Internet
    /// Monitor then publishes internet measurements from Amazon Web Services that are specific
    /// to the <i>city-networks</i>. That is, the locations and ASNs (typically internet service
    /// providers or ISPs), where clients access your application. For more information, see
    /// <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-InternetMonitor.html">Using
    /// Amazon CloudWatch Internet Monitor</a> in the <i>Amazon CloudWatch User Guide</i>.
    /// 
    ///  
    /// <para>
    /// When you create a monitor, you choose the percentage of traffic that you want to monitor.
    /// You can also set a maximum limit for the number of city-networks where client traffic
    /// is monitored, that caps the total traffic that Internet Monitor monitors. A city-network
    /// maximum is the limit of city-networks, but you only pay for the number of city-networks
    /// that are actually monitored. You can update your monitor at any time to change the
    /// percentage of traffic to monitor or the city-networks maximum. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/IMCityNetworksMaximum.html">Choosing
    /// a city-network maximum value</a> in the <i>Amazon CloudWatch User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CWIMMonitor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.InternetMonitor.Model.CreateMonitorResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Internet Monitor CreateMonitor API operation.", Operation = new[] {"CreateMonitor"}, SelectReturnType = typeof(Amazon.InternetMonitor.Model.CreateMonitorResponse))]
    [AWSCmdletOutput("Amazon.InternetMonitor.Model.CreateMonitorResponse",
        "This cmdlet returns an Amazon.InternetMonitor.Model.CreateMonitorResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCWIMMonitorCmdlet : AmazonInternetMonitorClientCmdlet, IExecutor
    {
        
        #region Parameter HealthEventsConfig_AvailabilityScoreThreshold
        /// <summary>
        /// <para>
        /// <para>The health event threshold percentage set for availability scores.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? HealthEventsConfig_AvailabilityScoreThreshold { get; set; }
        #endregion
        
        #region Parameter S3Config_BucketName
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InternetMeasurementsLogDelivery_S3Config_BucketName")]
        public System.String S3Config_BucketName { get; set; }
        #endregion
        
        #region Parameter S3Config_BucketPrefix
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InternetMeasurementsLogDelivery_S3Config_BucketPrefix")]
        public System.String S3Config_BucketPrefix { get; set; }
        #endregion
        
        #region Parameter AvailabilityLocalHealthEventsConfig_HealthScoreThreshold
        /// <summary>
        /// <para>
        /// <para>The health event threshold percentage set for a local health score.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthEventsConfig_AvailabilityLocalHealthEventsConfig_HealthScoreThreshold")]
        public System.Double? AvailabilityLocalHealthEventsConfig_HealthScoreThreshold { get; set; }
        #endregion
        
        #region Parameter PerformanceLocalHealthEventsConfig_HealthScoreThreshold
        /// <summary>
        /// <para>
        /// <para>The health event threshold percentage set for a local health score.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthEventsConfig_PerformanceLocalHealthEventsConfig_HealthScoreThreshold")]
        public System.Double? PerformanceLocalHealthEventsConfig_HealthScoreThreshold { get; set; }
        #endregion
        
        #region Parameter S3Config_LogDeliveryStatus
        /// <summary>
        /// <para>
        /// <para>The status of publishing Internet Monitor internet measurements to an Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InternetMeasurementsLogDelivery_S3Config_LogDeliveryStatus")]
        [AWSConstantClassSource("Amazon.InternetMonitor.LogDeliveryStatus")]
        public Amazon.InternetMonitor.LogDeliveryStatus S3Config_LogDeliveryStatus { get; set; }
        #endregion
        
        #region Parameter MaxCityNetworksToMonitor
        /// <summary>
        /// <para>
        /// <para>The maximum number of city-networks to monitor for your resources. A city-network
        /// is the location (city) where clients access your application resources from and the
        /// ASN or network provider, such as an internet service provider (ISP), that clients
        /// access the resources through. Setting this limit can help control billing costs.</para><para>To learn more, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/IMCityNetworksMaximum.html">Choosing
        /// a city-network maximum value </a> in the Amazon CloudWatch Internet Monitor section
        /// of the <i>CloudWatch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxCityNetworksToMonitor { get; set; }
        #endregion
        
        #region Parameter AvailabilityLocalHealthEventsConfig_MinTrafficImpact
        /// <summary>
        /// <para>
        /// <para>The minimum percentage of overall traffic for an application that must be impacted
        /// by an issue before Internet Monitor creates an event when a threshold is crossed for
        /// a local health score.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthEventsConfig_AvailabilityLocalHealthEventsConfig_MinTrafficImpact")]
        public System.Double? AvailabilityLocalHealthEventsConfig_MinTrafficImpact { get; set; }
        #endregion
        
        #region Parameter PerformanceLocalHealthEventsConfig_MinTrafficImpact
        /// <summary>
        /// <para>
        /// <para>The minimum percentage of overall traffic for an application that must be impacted
        /// by an issue before Internet Monitor creates an event when a threshold is crossed for
        /// a local health score.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthEventsConfig_PerformanceLocalHealthEventsConfig_MinTrafficImpact")]
        public System.Double? PerformanceLocalHealthEventsConfig_MinTrafficImpact { get; set; }
        #endregion
        
        #region Parameter MonitorName
        /// <summary>
        /// <para>
        /// <para>The name of the monitor. </para>
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
        public System.String MonitorName { get; set; }
        #endregion
        
        #region Parameter HealthEventsConfig_PerformanceScoreThreshold
        /// <summary>
        /// <para>
        /// <para>The health event threshold percentage set for performance scores.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? HealthEventsConfig_PerformanceScoreThreshold { get; set; }
        #endregion
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The resources to include in a monitor, which you provide as a set of Amazon Resource
        /// Names (ARNs). Resources can be VPCs, NLBs, Amazon CloudFront distributions, or Amazon
        /// WorkSpaces directories.</para><para>You can add a combination of VPCs and CloudFront distributions, or you can add WorkSpaces
        /// directories, or you can add NLBs. You can't add NLBs or WorkSpaces directories together
        /// with any other resources.</para><note><para>If you add only Amazon VPC resources, at least one VPC must have an Internet Gateway
        /// attached to it, to make sure that it has internet connectivity.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resources")]
        public System.String[] Resource { get; set; }
        #endregion
        
        #region Parameter AvailabilityLocalHealthEventsConfig_Status
        /// <summary>
        /// <para>
        /// <para>The status of whether Internet Monitor creates a health event based on a threshold
        /// percentage set for a local health score. The status can be <code>ENABLED</code> or
        /// <code>DISABLED</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthEventsConfig_AvailabilityLocalHealthEventsConfig_Status")]
        [AWSConstantClassSource("Amazon.InternetMonitor.LocalHealthEventsConfigStatus")]
        public Amazon.InternetMonitor.LocalHealthEventsConfigStatus AvailabilityLocalHealthEventsConfig_Status { get; set; }
        #endregion
        
        #region Parameter PerformanceLocalHealthEventsConfig_Status
        /// <summary>
        /// <para>
        /// <para>The status of whether Internet Monitor creates a health event based on a threshold
        /// percentage set for a local health score. The status can be <code>ENABLED</code> or
        /// <code>DISABLED</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthEventsConfig_PerformanceLocalHealthEventsConfig_Status")]
        [AWSConstantClassSource("Amazon.InternetMonitor.LocalHealthEventsConfigStatus")]
        public Amazon.InternetMonitor.LocalHealthEventsConfigStatus PerformanceLocalHealthEventsConfig_Status { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for a monitor. You can add a maximum of 50 tags in Internet Monitor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TrafficPercentageToMonitor
        /// <summary>
        /// <para>
        /// <para>The percentage of the internet-facing traffic for your application that you want to
        /// monitor with this monitor. If you set a city-networks maximum, that limit overrides
        /// the traffic percentage that you set.</para><para>To learn more, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/IMTrafficPercentage.html">Choosing
        /// an application traffic percentage to monitor </a> in the Amazon CloudWatch Internet
        /// Monitor section of the <i>CloudWatch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TrafficPercentageToMonitor { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive string of up to 64 ASCII characters that you specify to make
        /// an idempotent API request. Don't reuse the same client token for other API requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.InternetMonitor.Model.CreateMonitorResponse).
        /// Specifying the name of a property of type Amazon.InternetMonitor.Model.CreateMonitorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MonitorName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MonitorName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MonitorName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MonitorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWIMMonitor (CreateMonitor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.InternetMonitor.Model.CreateMonitorResponse, NewCWIMMonitorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MonitorName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.AvailabilityLocalHealthEventsConfig_HealthScoreThreshold = this.AvailabilityLocalHealthEventsConfig_HealthScoreThreshold;
            context.AvailabilityLocalHealthEventsConfig_MinTrafficImpact = this.AvailabilityLocalHealthEventsConfig_MinTrafficImpact;
            context.AvailabilityLocalHealthEventsConfig_Status = this.AvailabilityLocalHealthEventsConfig_Status;
            context.HealthEventsConfig_AvailabilityScoreThreshold = this.HealthEventsConfig_AvailabilityScoreThreshold;
            context.PerformanceLocalHealthEventsConfig_HealthScoreThreshold = this.PerformanceLocalHealthEventsConfig_HealthScoreThreshold;
            context.PerformanceLocalHealthEventsConfig_MinTrafficImpact = this.PerformanceLocalHealthEventsConfig_MinTrafficImpact;
            context.PerformanceLocalHealthEventsConfig_Status = this.PerformanceLocalHealthEventsConfig_Status;
            context.HealthEventsConfig_PerformanceScoreThreshold = this.HealthEventsConfig_PerformanceScoreThreshold;
            context.S3Config_BucketName = this.S3Config_BucketName;
            context.S3Config_BucketPrefix = this.S3Config_BucketPrefix;
            context.S3Config_LogDeliveryStatus = this.S3Config_LogDeliveryStatus;
            context.MaxCityNetworksToMonitor = this.MaxCityNetworksToMonitor;
            context.MonitorName = this.MonitorName;
            #if MODULAR
            if (this.MonitorName == null && ParameterWasBound(nameof(this.MonitorName)))
            {
                WriteWarning("You are passing $null as a value for parameter MonitorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Resource != null)
            {
                context.Resource = new List<System.String>(this.Resource);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.TrafficPercentageToMonitor = this.TrafficPercentageToMonitor;
            
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
            var request = new Amazon.InternetMonitor.Model.CreateMonitorRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate HealthEventsConfig
            var requestHealthEventsConfigIsNull = true;
            request.HealthEventsConfig = new Amazon.InternetMonitor.Model.HealthEventsConfig();
            System.Double? requestHealthEventsConfig_healthEventsConfig_AvailabilityScoreThreshold = null;
            if (cmdletContext.HealthEventsConfig_AvailabilityScoreThreshold != null)
            {
                requestHealthEventsConfig_healthEventsConfig_AvailabilityScoreThreshold = cmdletContext.HealthEventsConfig_AvailabilityScoreThreshold.Value;
            }
            if (requestHealthEventsConfig_healthEventsConfig_AvailabilityScoreThreshold != null)
            {
                request.HealthEventsConfig.AvailabilityScoreThreshold = requestHealthEventsConfig_healthEventsConfig_AvailabilityScoreThreshold.Value;
                requestHealthEventsConfigIsNull = false;
            }
            System.Double? requestHealthEventsConfig_healthEventsConfig_PerformanceScoreThreshold = null;
            if (cmdletContext.HealthEventsConfig_PerformanceScoreThreshold != null)
            {
                requestHealthEventsConfig_healthEventsConfig_PerformanceScoreThreshold = cmdletContext.HealthEventsConfig_PerformanceScoreThreshold.Value;
            }
            if (requestHealthEventsConfig_healthEventsConfig_PerformanceScoreThreshold != null)
            {
                request.HealthEventsConfig.PerformanceScoreThreshold = requestHealthEventsConfig_healthEventsConfig_PerformanceScoreThreshold.Value;
                requestHealthEventsConfigIsNull = false;
            }
            Amazon.InternetMonitor.Model.LocalHealthEventsConfig requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig = null;
            
             // populate AvailabilityLocalHealthEventsConfig
            var requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfigIsNull = true;
            requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig = new Amazon.InternetMonitor.Model.LocalHealthEventsConfig();
            System.Double? requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig_availabilityLocalHealthEventsConfig_HealthScoreThreshold = null;
            if (cmdletContext.AvailabilityLocalHealthEventsConfig_HealthScoreThreshold != null)
            {
                requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig_availabilityLocalHealthEventsConfig_HealthScoreThreshold = cmdletContext.AvailabilityLocalHealthEventsConfig_HealthScoreThreshold.Value;
            }
            if (requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig_availabilityLocalHealthEventsConfig_HealthScoreThreshold != null)
            {
                requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig.HealthScoreThreshold = requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig_availabilityLocalHealthEventsConfig_HealthScoreThreshold.Value;
                requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfigIsNull = false;
            }
            System.Double? requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig_availabilityLocalHealthEventsConfig_MinTrafficImpact = null;
            if (cmdletContext.AvailabilityLocalHealthEventsConfig_MinTrafficImpact != null)
            {
                requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig_availabilityLocalHealthEventsConfig_MinTrafficImpact = cmdletContext.AvailabilityLocalHealthEventsConfig_MinTrafficImpact.Value;
            }
            if (requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig_availabilityLocalHealthEventsConfig_MinTrafficImpact != null)
            {
                requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig.MinTrafficImpact = requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig_availabilityLocalHealthEventsConfig_MinTrafficImpact.Value;
                requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfigIsNull = false;
            }
            Amazon.InternetMonitor.LocalHealthEventsConfigStatus requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig_availabilityLocalHealthEventsConfig_Status = null;
            if (cmdletContext.AvailabilityLocalHealthEventsConfig_Status != null)
            {
                requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig_availabilityLocalHealthEventsConfig_Status = cmdletContext.AvailabilityLocalHealthEventsConfig_Status;
            }
            if (requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig_availabilityLocalHealthEventsConfig_Status != null)
            {
                requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig.Status = requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig_availabilityLocalHealthEventsConfig_Status;
                requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfigIsNull = false;
            }
             // determine if requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig should be set to null
            if (requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfigIsNull)
            {
                requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig = null;
            }
            if (requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig != null)
            {
                request.HealthEventsConfig.AvailabilityLocalHealthEventsConfig = requestHealthEventsConfig_healthEventsConfig_AvailabilityLocalHealthEventsConfig;
                requestHealthEventsConfigIsNull = false;
            }
            Amazon.InternetMonitor.Model.LocalHealthEventsConfig requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig = null;
            
             // populate PerformanceLocalHealthEventsConfig
            var requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfigIsNull = true;
            requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig = new Amazon.InternetMonitor.Model.LocalHealthEventsConfig();
            System.Double? requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig_performanceLocalHealthEventsConfig_HealthScoreThreshold = null;
            if (cmdletContext.PerformanceLocalHealthEventsConfig_HealthScoreThreshold != null)
            {
                requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig_performanceLocalHealthEventsConfig_HealthScoreThreshold = cmdletContext.PerformanceLocalHealthEventsConfig_HealthScoreThreshold.Value;
            }
            if (requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig_performanceLocalHealthEventsConfig_HealthScoreThreshold != null)
            {
                requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig.HealthScoreThreshold = requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig_performanceLocalHealthEventsConfig_HealthScoreThreshold.Value;
                requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfigIsNull = false;
            }
            System.Double? requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig_performanceLocalHealthEventsConfig_MinTrafficImpact = null;
            if (cmdletContext.PerformanceLocalHealthEventsConfig_MinTrafficImpact != null)
            {
                requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig_performanceLocalHealthEventsConfig_MinTrafficImpact = cmdletContext.PerformanceLocalHealthEventsConfig_MinTrafficImpact.Value;
            }
            if (requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig_performanceLocalHealthEventsConfig_MinTrafficImpact != null)
            {
                requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig.MinTrafficImpact = requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig_performanceLocalHealthEventsConfig_MinTrafficImpact.Value;
                requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfigIsNull = false;
            }
            Amazon.InternetMonitor.LocalHealthEventsConfigStatus requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig_performanceLocalHealthEventsConfig_Status = null;
            if (cmdletContext.PerformanceLocalHealthEventsConfig_Status != null)
            {
                requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig_performanceLocalHealthEventsConfig_Status = cmdletContext.PerformanceLocalHealthEventsConfig_Status;
            }
            if (requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig_performanceLocalHealthEventsConfig_Status != null)
            {
                requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig.Status = requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig_performanceLocalHealthEventsConfig_Status;
                requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfigIsNull = false;
            }
             // determine if requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig should be set to null
            if (requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfigIsNull)
            {
                requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig = null;
            }
            if (requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig != null)
            {
                request.HealthEventsConfig.PerformanceLocalHealthEventsConfig = requestHealthEventsConfig_healthEventsConfig_PerformanceLocalHealthEventsConfig;
                requestHealthEventsConfigIsNull = false;
            }
             // determine if request.HealthEventsConfig should be set to null
            if (requestHealthEventsConfigIsNull)
            {
                request.HealthEventsConfig = null;
            }
            
             // populate InternetMeasurementsLogDelivery
            var requestInternetMeasurementsLogDeliveryIsNull = true;
            request.InternetMeasurementsLogDelivery = new Amazon.InternetMonitor.Model.InternetMeasurementsLogDelivery();
            Amazon.InternetMonitor.Model.S3Config requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config = null;
            
             // populate S3Config
            var requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3ConfigIsNull = true;
            requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config = new Amazon.InternetMonitor.Model.S3Config();
            System.String requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config_s3Config_BucketName = null;
            if (cmdletContext.S3Config_BucketName != null)
            {
                requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config_s3Config_BucketName = cmdletContext.S3Config_BucketName;
            }
            if (requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config_s3Config_BucketName != null)
            {
                requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config.BucketName = requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config_s3Config_BucketName;
                requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3ConfigIsNull = false;
            }
            System.String requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config_s3Config_BucketPrefix = null;
            if (cmdletContext.S3Config_BucketPrefix != null)
            {
                requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config_s3Config_BucketPrefix = cmdletContext.S3Config_BucketPrefix;
            }
            if (requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config_s3Config_BucketPrefix != null)
            {
                requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config.BucketPrefix = requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config_s3Config_BucketPrefix;
                requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3ConfigIsNull = false;
            }
            Amazon.InternetMonitor.LogDeliveryStatus requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config_s3Config_LogDeliveryStatus = null;
            if (cmdletContext.S3Config_LogDeliveryStatus != null)
            {
                requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config_s3Config_LogDeliveryStatus = cmdletContext.S3Config_LogDeliveryStatus;
            }
            if (requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config_s3Config_LogDeliveryStatus != null)
            {
                requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config.LogDeliveryStatus = requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config_s3Config_LogDeliveryStatus;
                requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3ConfigIsNull = false;
            }
             // determine if requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config should be set to null
            if (requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3ConfigIsNull)
            {
                requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config = null;
            }
            if (requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config != null)
            {
                request.InternetMeasurementsLogDelivery.S3Config = requestInternetMeasurementsLogDelivery_internetMeasurementsLogDelivery_S3Config;
                requestInternetMeasurementsLogDeliveryIsNull = false;
            }
             // determine if request.InternetMeasurementsLogDelivery should be set to null
            if (requestInternetMeasurementsLogDeliveryIsNull)
            {
                request.InternetMeasurementsLogDelivery = null;
            }
            if (cmdletContext.MaxCityNetworksToMonitor != null)
            {
                request.MaxCityNetworksToMonitor = cmdletContext.MaxCityNetworksToMonitor.Value;
            }
            if (cmdletContext.MonitorName != null)
            {
                request.MonitorName = cmdletContext.MonitorName;
            }
            if (cmdletContext.Resource != null)
            {
                request.Resources = cmdletContext.Resource;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TrafficPercentageToMonitor != null)
            {
                request.TrafficPercentageToMonitor = cmdletContext.TrafficPercentageToMonitor.Value;
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
        
        private Amazon.InternetMonitor.Model.CreateMonitorResponse CallAWSServiceOperation(IAmazonInternetMonitor client, Amazon.InternetMonitor.Model.CreateMonitorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Internet Monitor", "CreateMonitor");
            try
            {
                #if DESKTOP
                return client.CreateMonitor(request);
                #elif CORECLR
                return client.CreateMonitorAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Double? AvailabilityLocalHealthEventsConfig_HealthScoreThreshold { get; set; }
            public System.Double? AvailabilityLocalHealthEventsConfig_MinTrafficImpact { get; set; }
            public Amazon.InternetMonitor.LocalHealthEventsConfigStatus AvailabilityLocalHealthEventsConfig_Status { get; set; }
            public System.Double? HealthEventsConfig_AvailabilityScoreThreshold { get; set; }
            public System.Double? PerformanceLocalHealthEventsConfig_HealthScoreThreshold { get; set; }
            public System.Double? PerformanceLocalHealthEventsConfig_MinTrafficImpact { get; set; }
            public Amazon.InternetMonitor.LocalHealthEventsConfigStatus PerformanceLocalHealthEventsConfig_Status { get; set; }
            public System.Double? HealthEventsConfig_PerformanceScoreThreshold { get; set; }
            public System.String S3Config_BucketName { get; set; }
            public System.String S3Config_BucketPrefix { get; set; }
            public Amazon.InternetMonitor.LogDeliveryStatus S3Config_LogDeliveryStatus { get; set; }
            public System.Int32? MaxCityNetworksToMonitor { get; set; }
            public System.String MonitorName { get; set; }
            public List<System.String> Resource { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Int32? TrafficPercentageToMonitor { get; set; }
            public System.Func<Amazon.InternetMonitor.Model.CreateMonitorResponse, NewCWIMMonitorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
