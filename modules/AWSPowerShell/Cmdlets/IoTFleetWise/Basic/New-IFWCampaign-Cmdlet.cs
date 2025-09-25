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
using Amazon.IoTFleetWise;
using Amazon.IoTFleetWise.Model;

namespace Amazon.PowerShell.Cmdlets.IFW
{
    /// <summary>
    /// Creates an orchestration of data collection rules. The Amazon Web Services IoT FleetWise
    /// Edge Agent software running in vehicles uses campaigns to decide how to collect and
    /// transfer data to the cloud. You create campaigns in the cloud. After you or your team
    /// approve campaigns, Amazon Web Services IoT FleetWise automatically deploys them to
    /// vehicles. 
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/iot-fleetwise/latest/developerguide/campaigns.html">Collect
    /// and transfer data with campaigns</a> in the <i>Amazon Web Services IoT FleetWise Developer
    /// Guide</i>.
    /// </para><important><para>
    /// Access to certain Amazon Web Services IoT FleetWise features is currently gated. For
    /// more information, see <a href="https://docs.aws.amazon.com/iot-fleetwise/latest/developerguide/fleetwise-regions.html">Amazon
    /// Web Services Region and feature availability</a> in the <i>Amazon Web Services IoT
    /// FleetWise Developer Guide</i>.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "IFWCampaign", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTFleetWise.Model.CreateCampaignResponse")]
    [AWSCmdlet("Calls the AWS IoT FleetWise CreateCampaign API operation.", Operation = new[] {"CreateCampaign"}, SelectReturnType = typeof(Amazon.IoTFleetWise.Model.CreateCampaignResponse))]
    [AWSCmdletOutput("Amazon.IoTFleetWise.Model.CreateCampaignResponse",
        "This cmdlet returns an Amazon.IoTFleetWise.Model.CreateCampaignResponse object containing multiple properties."
    )]
    public partial class NewIFWCampaignCmdlet : AmazonIoTFleetWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Compression
        /// <summary>
        /// <para>
        /// <para>Determines whether to compress signals before transmitting data to Amazon Web Services
        /// IoT FleetWise. If you don't want to compress the signals, use <c>OFF</c>. If it's
        /// not specified, <c>SNAPPY</c> is used. </para><para>Default: <c>SNAPPY</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTFleetWise.Compression")]
        public Amazon.IoTFleetWise.Compression Compression { get; set; }
        #endregion
        
        #region Parameter ConditionBasedCollectionScheme_ConditionLanguageVersion
        /// <summary>
        /// <para>
        /// <para>Specifies the version of the conditional expression language.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CollectionScheme_ConditionBasedCollectionScheme_ConditionLanguageVersion")]
        public System.Int32? ConditionBasedCollectionScheme_ConditionLanguageVersion { get; set; }
        #endregion
        
        #region Parameter DataDestinationConfig
        /// <summary>
        /// <para>
        /// <para>The destination where the campaign sends data. You can send data to an MQTT topic,
        /// or store it in Amazon S3 or Amazon Timestream.</para><para>MQTT is the publish/subscribe messaging protocol used by Amazon Web Services IoT to
        /// communicate with your devices.</para><para>Amazon S3 optimizes the cost of data storage and provides additional mechanisms to
        /// use vehicle data, such as data lakes, centralized data storage, data processing pipelines,
        /// and analytics. Amazon Web Services IoT FleetWise supports at-least-once file delivery
        /// to S3. Your vehicle data is stored on multiple Amazon Web Services IoT FleetWise servers
        /// for redundancy and high availability.</para><para>You can use Amazon Timestream to access and analyze time series data, and Timestream
        /// to query vehicle data so that you can identify trends and patterns.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataDestinationConfigs")]
        public Amazon.IoTFleetWise.Model.DataDestinationConfig[] DataDestinationConfig { get; set; }
        #endregion
        
        #region Parameter DataExtraDimension
        /// <summary>
        /// <para>
        /// <para>A list of vehicle attributes to associate with a campaign. </para><para>Enrich the data with specified vehicle attributes. For example, add <c>make</c> and
        /// <c>model</c> to the campaign, and Amazon Web Services IoT FleetWise will associate
        /// the data with those attributes as dimensions in Amazon Timestream. You can then query
        /// the data against <c>make</c> and <c>model</c>.</para><para>Default: An empty array</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataExtraDimensions")]
        public System.String[] DataExtraDimension { get; set; }
        #endregion
        
        #region Parameter DataPartition
        /// <summary>
        /// <para>
        /// <para>The data partitions associated with the signals collected from the vehicle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataPartitions")]
        public Amazon.IoTFleetWise.Model.DataPartition[] DataPartition { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description of the campaign to help identify its purpose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DiagnosticsMode
        /// <summary>
        /// <para>
        /// <para>Option for a vehicle to send diagnostic trouble codes to Amazon Web Services IoT FleetWise.
        /// If you want to send diagnostic trouble codes, use <c>SEND_ACTIVE_DTCS</c>. If it's
        /// not specified, <c>OFF</c> is used.</para><para>Default: <c>OFF</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTFleetWise.DiagnosticsMode")]
        public Amazon.IoTFleetWise.DiagnosticsMode DiagnosticsMode { get; set; }
        #endregion
        
        #region Parameter ExpiryTime
        /// <summary>
        /// <para>
        /// <para>The time the campaign expires, in seconds since epoch (January 1, 1970 at midnight
        /// UTC time). Vehicle data isn't collected after the campaign expires. </para><para>Default: 253402214400 (December 31, 9999, 00:00:00 UTC)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ExpiryTime { get; set; }
        #endregion
        
        #region Parameter ConditionBasedCollectionScheme_Expression
        /// <summary>
        /// <para>
        /// <para>The logical expression used to recognize what data to collect. For example, <c>$variable.`Vehicle.OutsideAirTemperature`
        /// &gt;= 105.0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CollectionScheme_ConditionBasedCollectionScheme_Expression")]
        public System.String ConditionBasedCollectionScheme_Expression { get; set; }
        #endregion
        
        #region Parameter ConditionBasedCollectionScheme_MinimumTriggerIntervalMs
        /// <summary>
        /// <para>
        /// <para>The minimum duration of time between two triggering events to collect data, in milliseconds.</para><note><para>If a signal changes often, you might want to collect data at a slower rate.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CollectionScheme_ConditionBasedCollectionScheme_MinimumTriggerIntervalMs")]
        public System.Int64? ConditionBasedCollectionScheme_MinimumTriggerIntervalMs { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The name of the campaign to create. </para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TimeBasedCollectionScheme_PeriodMs
        /// <summary>
        /// <para>
        /// <para>The time period (in milliseconds) to decide how often to collect data. For example,
        /// if the time period is <c>60000</c>, the Edge Agent software collects data once every
        /// minute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CollectionScheme_TimeBasedCollectionScheme_PeriodMs")]
        public System.Int64? TimeBasedCollectionScheme_PeriodMs { get; set; }
        #endregion
        
        #region Parameter PostTriggerCollectionDuration
        /// <summary>
        /// <para>
        /// <para>How long (in milliseconds) to collect raw data after a triggering event initiates
        /// the collection. If it's not specified, <c>0</c> is used.</para><para>Default: <c>0</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? PostTriggerCollectionDuration { get; set; }
        #endregion
        
        #region Parameter SignalCatalogArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the signal catalog to associate with the campaign.
        /// </para>
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
        public System.String SignalCatalogArn { get; set; }
        #endregion
        
        #region Parameter SignalsToCollect
        /// <summary>
        /// <para>
        /// <para>A list of information about signals to collect. </para><note><para>If you upload a signal as a condition in a data partition for a campaign, then those
        /// same signals must be included in <c>signalsToCollect</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoTFleetWise.Model.SignalInformation[] SignalsToCollect { get; set; }
        #endregion
        
        #region Parameter SignalsToFetch
        /// <summary>
        /// <para>
        /// <para>A list of information about signals to fetch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoTFleetWise.Model.SignalFetchInformation[] SignalsToFetch { get; set; }
        #endregion
        
        #region Parameter SpoolingMode
        /// <summary>
        /// <para>
        /// <para>Determines whether to store collected data after a vehicle lost a connection with
        /// the cloud. After a connection is re-established, the data is automatically forwarded
        /// to Amazon Web Services IoT FleetWise. If you want to store collected data when a vehicle
        /// loses connection with the cloud, use <c>TO_DISK</c>. If it's not specified, <c>OFF</c>
        /// is used.</para><para>Default: <c>OFF</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTFleetWise.SpoolingMode")]
        public Amazon.IoTFleetWise.SpoolingMode SpoolingMode { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The time, in milliseconds, to deliver a campaign after it was approved. If it's not
        /// specified, <c>0</c> is used.</para><para>Default: <c>0</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata that can be used to manage the campaign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoTFleetWise.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the vehicle or fleet to deploy a campaign to. </para>
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
        public System.String TargetArn { get; set; }
        #endregion
        
        #region Parameter ConditionBasedCollectionScheme_TriggerMode
        /// <summary>
        /// <para>
        /// <para>Whether to collect data for all triggering events (<c>ALWAYS</c>). Specify (<c>RISING_EDGE</c>),
        /// or specify only when the condition first evaluates to false. For example, triggering
        /// on "AirbagDeployed"; Users aren't interested on triggering when the airbag is already
        /// exploded; they only care about the change from not deployed =&gt; deployed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CollectionScheme_ConditionBasedCollectionScheme_TriggerMode")]
        [AWSConstantClassSource("Amazon.IoTFleetWise.TriggerMode")]
        public Amazon.IoTFleetWise.TriggerMode ConditionBasedCollectionScheme_TriggerMode { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>A number indicating the priority of one campaign over another campaign for a certain
        /// vehicle or fleet. A campaign with the lowest value is deployed to vehicles before
        /// any other campaigns. If it's not specified, <c>0</c> is used. </para><para>Default: <c>0</c></para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("priority is no longer used or needed as input")]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTFleetWise.Model.CreateCampaignResponse).
        /// Specifying the name of a property of type Amazon.IoTFleetWise.Model.CreateCampaignResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IFWCampaign (CreateCampaign)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTFleetWise.Model.CreateCampaignResponse, NewIFWCampaignCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConditionBasedCollectionScheme_ConditionLanguageVersion = this.ConditionBasedCollectionScheme_ConditionLanguageVersion;
            context.ConditionBasedCollectionScheme_Expression = this.ConditionBasedCollectionScheme_Expression;
            context.ConditionBasedCollectionScheme_MinimumTriggerIntervalMs = this.ConditionBasedCollectionScheme_MinimumTriggerIntervalMs;
            context.ConditionBasedCollectionScheme_TriggerMode = this.ConditionBasedCollectionScheme_TriggerMode;
            context.TimeBasedCollectionScheme_PeriodMs = this.TimeBasedCollectionScheme_PeriodMs;
            context.Compression = this.Compression;
            if (this.DataDestinationConfig != null)
            {
                context.DataDestinationConfig = new List<Amazon.IoTFleetWise.Model.DataDestinationConfig>(this.DataDestinationConfig);
            }
            if (this.DataExtraDimension != null)
            {
                context.DataExtraDimension = new List<System.String>(this.DataExtraDimension);
            }
            if (this.DataPartition != null)
            {
                context.DataPartition = new List<Amazon.IoTFleetWise.Model.DataPartition>(this.DataPartition);
            }
            context.Description = this.Description;
            context.DiagnosticsMode = this.DiagnosticsMode;
            context.ExpiryTime = this.ExpiryTime;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PostTriggerCollectionDuration = this.PostTriggerCollectionDuration;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Priority = this.Priority;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SignalCatalogArn = this.SignalCatalogArn;
            #if MODULAR
            if (this.SignalCatalogArn == null && ParameterWasBound(nameof(this.SignalCatalogArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SignalCatalogArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SignalsToCollect != null)
            {
                context.SignalsToCollect = new List<Amazon.IoTFleetWise.Model.SignalInformation>(this.SignalsToCollect);
            }
            if (this.SignalsToFetch != null)
            {
                context.SignalsToFetch = new List<Amazon.IoTFleetWise.Model.SignalFetchInformation>(this.SignalsToFetch);
            }
            context.SpoolingMode = this.SpoolingMode;
            context.StartTime = this.StartTime;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoTFleetWise.Model.Tag>(this.Tag);
            }
            context.TargetArn = this.TargetArn;
            #if MODULAR
            if (this.TargetArn == null && ParameterWasBound(nameof(this.TargetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.IoTFleetWise.Model.CreateCampaignRequest();
            
            
             // populate CollectionScheme
            var requestCollectionSchemeIsNull = true;
            request.CollectionScheme = new Amazon.IoTFleetWise.Model.CollectionScheme();
            Amazon.IoTFleetWise.Model.TimeBasedCollectionScheme requestCollectionScheme_collectionScheme_TimeBasedCollectionScheme = null;
            
             // populate TimeBasedCollectionScheme
            var requestCollectionScheme_collectionScheme_TimeBasedCollectionSchemeIsNull = true;
            requestCollectionScheme_collectionScheme_TimeBasedCollectionScheme = new Amazon.IoTFleetWise.Model.TimeBasedCollectionScheme();
            System.Int64? requestCollectionScheme_collectionScheme_TimeBasedCollectionScheme_timeBasedCollectionScheme_PeriodMs = null;
            if (cmdletContext.TimeBasedCollectionScheme_PeriodMs != null)
            {
                requestCollectionScheme_collectionScheme_TimeBasedCollectionScheme_timeBasedCollectionScheme_PeriodMs = cmdletContext.TimeBasedCollectionScheme_PeriodMs.Value;
            }
            if (requestCollectionScheme_collectionScheme_TimeBasedCollectionScheme_timeBasedCollectionScheme_PeriodMs != null)
            {
                requestCollectionScheme_collectionScheme_TimeBasedCollectionScheme.PeriodMs = requestCollectionScheme_collectionScheme_TimeBasedCollectionScheme_timeBasedCollectionScheme_PeriodMs.Value;
                requestCollectionScheme_collectionScheme_TimeBasedCollectionSchemeIsNull = false;
            }
             // determine if requestCollectionScheme_collectionScheme_TimeBasedCollectionScheme should be set to null
            if (requestCollectionScheme_collectionScheme_TimeBasedCollectionSchemeIsNull)
            {
                requestCollectionScheme_collectionScheme_TimeBasedCollectionScheme = null;
            }
            if (requestCollectionScheme_collectionScheme_TimeBasedCollectionScheme != null)
            {
                request.CollectionScheme.TimeBasedCollectionScheme = requestCollectionScheme_collectionScheme_TimeBasedCollectionScheme;
                requestCollectionSchemeIsNull = false;
            }
            Amazon.IoTFleetWise.Model.ConditionBasedCollectionScheme requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme = null;
            
             // populate ConditionBasedCollectionScheme
            var requestCollectionScheme_collectionScheme_ConditionBasedCollectionSchemeIsNull = true;
            requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme = new Amazon.IoTFleetWise.Model.ConditionBasedCollectionScheme();
            System.Int32? requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_ConditionLanguageVersion = null;
            if (cmdletContext.ConditionBasedCollectionScheme_ConditionLanguageVersion != null)
            {
                requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_ConditionLanguageVersion = cmdletContext.ConditionBasedCollectionScheme_ConditionLanguageVersion.Value;
            }
            if (requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_ConditionLanguageVersion != null)
            {
                requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme.ConditionLanguageVersion = requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_ConditionLanguageVersion.Value;
                requestCollectionScheme_collectionScheme_ConditionBasedCollectionSchemeIsNull = false;
            }
            System.String requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_Expression = null;
            if (cmdletContext.ConditionBasedCollectionScheme_Expression != null)
            {
                requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_Expression = cmdletContext.ConditionBasedCollectionScheme_Expression;
            }
            if (requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_Expression != null)
            {
                requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme.Expression = requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_Expression;
                requestCollectionScheme_collectionScheme_ConditionBasedCollectionSchemeIsNull = false;
            }
            System.Int64? requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_MinimumTriggerIntervalMs = null;
            if (cmdletContext.ConditionBasedCollectionScheme_MinimumTriggerIntervalMs != null)
            {
                requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_MinimumTriggerIntervalMs = cmdletContext.ConditionBasedCollectionScheme_MinimumTriggerIntervalMs.Value;
            }
            if (requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_MinimumTriggerIntervalMs != null)
            {
                requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme.MinimumTriggerIntervalMs = requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_MinimumTriggerIntervalMs.Value;
                requestCollectionScheme_collectionScheme_ConditionBasedCollectionSchemeIsNull = false;
            }
            Amazon.IoTFleetWise.TriggerMode requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_TriggerMode = null;
            if (cmdletContext.ConditionBasedCollectionScheme_TriggerMode != null)
            {
                requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_TriggerMode = cmdletContext.ConditionBasedCollectionScheme_TriggerMode;
            }
            if (requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_TriggerMode != null)
            {
                requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme.TriggerMode = requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme_conditionBasedCollectionScheme_TriggerMode;
                requestCollectionScheme_collectionScheme_ConditionBasedCollectionSchemeIsNull = false;
            }
             // determine if requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme should be set to null
            if (requestCollectionScheme_collectionScheme_ConditionBasedCollectionSchemeIsNull)
            {
                requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme = null;
            }
            if (requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme != null)
            {
                request.CollectionScheme.ConditionBasedCollectionScheme = requestCollectionScheme_collectionScheme_ConditionBasedCollectionScheme;
                requestCollectionSchemeIsNull = false;
            }
             // determine if request.CollectionScheme should be set to null
            if (requestCollectionSchemeIsNull)
            {
                request.CollectionScheme = null;
            }
            if (cmdletContext.Compression != null)
            {
                request.Compression = cmdletContext.Compression;
            }
            if (cmdletContext.DataDestinationConfig != null)
            {
                request.DataDestinationConfigs = cmdletContext.DataDestinationConfig;
            }
            if (cmdletContext.DataExtraDimension != null)
            {
                request.DataExtraDimensions = cmdletContext.DataExtraDimension;
            }
            if (cmdletContext.DataPartition != null)
            {
                request.DataPartitions = cmdletContext.DataPartition;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DiagnosticsMode != null)
            {
                request.DiagnosticsMode = cmdletContext.DiagnosticsMode;
            }
            if (cmdletContext.ExpiryTime != null)
            {
                request.ExpiryTime = cmdletContext.ExpiryTime.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PostTriggerCollectionDuration != null)
            {
                request.PostTriggerCollectionDuration = cmdletContext.PostTriggerCollectionDuration.Value;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.SignalCatalogArn != null)
            {
                request.SignalCatalogArn = cmdletContext.SignalCatalogArn;
            }
            if (cmdletContext.SignalsToCollect != null)
            {
                request.SignalsToCollect = cmdletContext.SignalsToCollect;
            }
            if (cmdletContext.SignalsToFetch != null)
            {
                request.SignalsToFetch = cmdletContext.SignalsToFetch;
            }
            if (cmdletContext.SpoolingMode != null)
            {
                request.SpoolingMode = cmdletContext.SpoolingMode;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetArn != null)
            {
                request.TargetArn = cmdletContext.TargetArn;
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
        
        private Amazon.IoTFleetWise.Model.CreateCampaignResponse CallAWSServiceOperation(IAmazonIoTFleetWise client, Amazon.IoTFleetWise.Model.CreateCampaignRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT FleetWise", "CreateCampaign");
            try
            {
                #if DESKTOP
                return client.CreateCampaign(request);
                #elif CORECLR
                return client.CreateCampaignAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? ConditionBasedCollectionScheme_ConditionLanguageVersion { get; set; }
            public System.String ConditionBasedCollectionScheme_Expression { get; set; }
            public System.Int64? ConditionBasedCollectionScheme_MinimumTriggerIntervalMs { get; set; }
            public Amazon.IoTFleetWise.TriggerMode ConditionBasedCollectionScheme_TriggerMode { get; set; }
            public System.Int64? TimeBasedCollectionScheme_PeriodMs { get; set; }
            public Amazon.IoTFleetWise.Compression Compression { get; set; }
            public List<Amazon.IoTFleetWise.Model.DataDestinationConfig> DataDestinationConfig { get; set; }
            public List<System.String> DataExtraDimension { get; set; }
            public List<Amazon.IoTFleetWise.Model.DataPartition> DataPartition { get; set; }
            public System.String Description { get; set; }
            public Amazon.IoTFleetWise.DiagnosticsMode DiagnosticsMode { get; set; }
            public System.DateTime? ExpiryTime { get; set; }
            public System.String Name { get; set; }
            public System.Int64? PostTriggerCollectionDuration { get; set; }
            [System.ObsoleteAttribute]
            public System.Int32? Priority { get; set; }
            public System.String SignalCatalogArn { get; set; }
            public List<Amazon.IoTFleetWise.Model.SignalInformation> SignalsToCollect { get; set; }
            public List<Amazon.IoTFleetWise.Model.SignalFetchInformation> SignalsToFetch { get; set; }
            public Amazon.IoTFleetWise.SpoolingMode SpoolingMode { get; set; }
            public System.DateTime? StartTime { get; set; }
            public List<Amazon.IoTFleetWise.Model.Tag> Tag { get; set; }
            public System.String TargetArn { get; set; }
            public System.Func<Amazon.IoTFleetWise.Model.CreateCampaignResponse, NewIFWCampaignCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
