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
    /// Updates a monitor. You can update a monitor to change the maximum number of city-networks
    /// (locations and ASNs or internet service providers), to add or remove resources, or
    /// to change the status of the monitor. Note that you can't change the name of a monitor.
    /// 
    ///  
    /// <para>
    /// The city-network maximum that you choose is the limit, but you only pay for the number
    /// of city-networks that are actually monitored. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/IMCityNetworksMaximum.html">Choosing
    /// a city-network maximum value</a> in the <i>Amazon CloudWatch User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CWIMMonitor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.InternetMonitor.Model.UpdateMonitorResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Internet Monitor UpdateMonitor API operation.", Operation = new[] {"UpdateMonitor"}, SelectReturnType = typeof(Amazon.InternetMonitor.Model.UpdateMonitorResponse))]
    [AWSCmdletOutput("Amazon.InternetMonitor.Model.UpdateMonitorResponse",
        "This cmdlet returns an Amazon.InternetMonitor.Model.UpdateMonitorResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCWIMMonitorCmdlet : AmazonInternetMonitorClientCmdlet, IExecutor
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
        /// network or ASN, such as an internet service provider, that clients access the resources
        /// through.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxCityNetworksToMonitor { get; set; }
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
        
        #region Parameter ResourcesToAdd
        /// <summary>
        /// <para>
        /// <para>The resources to include in a monitor, which you provide as a set of Amazon Resource
        /// Names (ARNs).</para><para>You can add a combination of Amazon Virtual Private Clouds (VPCs) and Amazon CloudFront
        /// distributions, or you can add Amazon WorkSpaces directories. You can't add all three
        /// types of resources.</para><note><para>If you add only VPC resources, at least one VPC must have an Internet Gateway attached
        /// to it, to make sure that it has internet connectivity.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ResourcesToAdd { get; set; }
        #endregion
        
        #region Parameter ResourcesToRemove
        /// <summary>
        /// <para>
        /// <para>The resources to remove from a monitor, which you provide as a set of Amazon Resource
        /// Names (ARNs).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ResourcesToRemove { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status for a monitor. The accepted values for <code>Status</code> with the <code>UpdateMonitor</code>
        /// API call are the following: <code>ACTIVE</code> and <code>INACTIVE</code>. The following
        /// values are <i>not</i> accepted: <code>PENDING</code>, and <code>ERROR</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.InternetMonitor.MonitorConfigState")]
        public Amazon.InternetMonitor.MonitorConfigState Status { get; set; }
        #endregion
        
        #region Parameter TrafficPercentageToMonitor
        /// <summary>
        /// <para>
        /// <para>The percentage of the internet-facing traffic for your application that you want to
        /// monitor with this monitor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TrafficPercentageToMonitor { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive string of up to 64 ASCII characters that you specify to make
        /// an idempotent API request. You should not reuse the same client token for other API
        /// requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.InternetMonitor.Model.UpdateMonitorResponse).
        /// Specifying the name of a property of type Amazon.InternetMonitor.Model.UpdateMonitorResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWIMMonitor (UpdateMonitor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.InternetMonitor.Model.UpdateMonitorResponse, UpdateCWIMMonitorCmdlet>(Select) ??
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
            context.HealthEventsConfig_AvailabilityScoreThreshold = this.HealthEventsConfig_AvailabilityScoreThreshold;
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
            if (this.ResourcesToAdd != null)
            {
                context.ResourcesToAdd = new List<System.String>(this.ResourcesToAdd);
            }
            if (this.ResourcesToRemove != null)
            {
                context.ResourcesToRemove = new List<System.String>(this.ResourcesToRemove);
            }
            context.Status = this.Status;
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
            var request = new Amazon.InternetMonitor.Model.UpdateMonitorRequest();
            
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
            if (cmdletContext.ResourcesToAdd != null)
            {
                request.ResourcesToAdd = cmdletContext.ResourcesToAdd;
            }
            if (cmdletContext.ResourcesToRemove != null)
            {
                request.ResourcesToRemove = cmdletContext.ResourcesToRemove;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.InternetMonitor.Model.UpdateMonitorResponse CallAWSServiceOperation(IAmazonInternetMonitor client, Amazon.InternetMonitor.Model.UpdateMonitorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Internet Monitor", "UpdateMonitor");
            try
            {
                #if DESKTOP
                return client.UpdateMonitor(request);
                #elif CORECLR
                return client.UpdateMonitorAsync(request).GetAwaiter().GetResult();
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
            public System.Double? HealthEventsConfig_AvailabilityScoreThreshold { get; set; }
            public System.Double? HealthEventsConfig_PerformanceScoreThreshold { get; set; }
            public System.String S3Config_BucketName { get; set; }
            public System.String S3Config_BucketPrefix { get; set; }
            public Amazon.InternetMonitor.LogDeliveryStatus S3Config_LogDeliveryStatus { get; set; }
            public System.Int32? MaxCityNetworksToMonitor { get; set; }
            public System.String MonitorName { get; set; }
            public List<System.String> ResourcesToAdd { get; set; }
            public List<System.String> ResourcesToRemove { get; set; }
            public Amazon.InternetMonitor.MonitorConfigState Status { get; set; }
            public System.Int32? TrafficPercentageToMonitor { get; set; }
            public System.Func<Amazon.InternetMonitor.Model.UpdateMonitorResponse, UpdateCWIMMonitorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
