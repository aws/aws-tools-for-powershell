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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Creates a Device Defender security profile.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">CreateSecurityProfile</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IOTSecurityProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateSecurityProfileResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateSecurityProfile API operation.", Operation = new[] {"CreateSecurityProfile"}, SelectReturnType = typeof(Amazon.IoT.Model.CreateSecurityProfileResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateSecurityProfileResponse",
        "This cmdlet returns an Amazon.IoT.Model.CreateSecurityProfileResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTSecurityProfileCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdditionalMetricsToRetainV2
        /// <summary>
        /// <para>
        /// <para>A list of metrics whose data is retained (stored). By default, data is retained for
        /// any metric used in the profile's <code>behaviors</code>, but it is also retained for
        /// any metric specified here. Can be used with custom metrics; cannot be used with dimensions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoT.Model.MetricToRetain[] AdditionalMetricsToRetainV2 { get; set; }
        #endregion
        
        #region Parameter AlertTarget
        /// <summary>
        /// <para>
        /// <para>Specifies the destinations to which alerts are sent. (Alerts are always sent to the
        /// console.) Alerts are generated when a device (thing) violates a behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlertTargets")]
        public System.Collections.Hashtable AlertTarget { get; set; }
        #endregion
        
        #region Parameter Behavior
        /// <summary>
        /// <para>
        /// <para>Specifies the behaviors that, when violated by a device (thing), cause an alert.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Behaviors")]
        public Amazon.IoT.Model.Behavior[] Behavior { get; set; }
        #endregion
        
        #region Parameter MetricsExportConfig_MqttTopic
        /// <summary>
        /// <para>
        /// <para>The MQTT topic that Device Defender Detect should publish messages to for metrics
        /// export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricsExportConfig_MqttTopic { get; set; }
        #endregion
        
        #region Parameter MetricsExportConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>This role ARN has permission to publish MQTT messages, after which Device Defender
        /// Detect can assume the role and publish messages on your behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricsExportConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter SecurityProfileDescription
        /// <summary>
        /// <para>
        /// <para>A description of the security profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecurityProfileDescription { get; set; }
        #endregion
        
        #region Parameter SecurityProfileName
        /// <summary>
        /// <para>
        /// <para>The name you are giving to the security profile.</para>
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
        public System.String SecurityProfileName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata that can be used to manage the security profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoT.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter AdditionalMetricsToRetain
        /// <summary>
        /// <para>
        /// <para><i>Please use <a>CreateSecurityProfileRequest$additionalMetricsToRetainV2</a> instead.</i></para><para>A list of metrics whose data is retained (stored). By default, data is retained for
        /// any metric used in the profile's <code>behaviors</code>, but it is also retained for
        /// any metric specified here. Can be used with custom metrics; cannot be used with dimensions.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Use additionalMetricsToRetainV2.")]
        public System.String[] AdditionalMetricsToRetain { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreateSecurityProfileResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreateSecurityProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SecurityProfileName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTSecurityProfile (CreateSecurityProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreateSecurityProfileResponse, NewIOTSecurityProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalMetricsToRetain != null)
            {
                context.AdditionalMetricsToRetain = new List<System.String>(this.AdditionalMetricsToRetain);
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalMetricsToRetainV2 != null)
            {
                context.AdditionalMetricsToRetainV2 = new List<Amazon.IoT.Model.MetricToRetain>(this.AdditionalMetricsToRetainV2);
            }
            if (this.AlertTarget != null)
            {
                context.AlertTarget = new Dictionary<System.String, Amazon.IoT.Model.AlertTarget>(StringComparer.Ordinal);
                foreach (var hashKey in this.AlertTarget.Keys)
                {
                    context.AlertTarget.Add((String)hashKey, (AlertTarget)(this.AlertTarget[hashKey]));
                }
            }
            if (this.Behavior != null)
            {
                context.Behavior = new List<Amazon.IoT.Model.Behavior>(this.Behavior);
            }
            context.MetricsExportConfig_MqttTopic = this.MetricsExportConfig_MqttTopic;
            context.MetricsExportConfig_RoleArn = this.MetricsExportConfig_RoleArn;
            context.SecurityProfileDescription = this.SecurityProfileDescription;
            context.SecurityProfileName = this.SecurityProfileName;
            #if MODULAR
            if (this.SecurityProfileName == null && ParameterWasBound(nameof(this.SecurityProfileName)))
            {
                WriteWarning("You are passing $null as a value for parameter SecurityProfileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoT.Model.Tag>(this.Tag);
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
            var request = new Amazon.IoT.Model.CreateSecurityProfileRequest();
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.AdditionalMetricsToRetain != null)
            {
                request.AdditionalMetricsToRetain = cmdletContext.AdditionalMetricsToRetain;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.AdditionalMetricsToRetainV2 != null)
            {
                request.AdditionalMetricsToRetainV2 = cmdletContext.AdditionalMetricsToRetainV2;
            }
            if (cmdletContext.AlertTarget != null)
            {
                request.AlertTargets = cmdletContext.AlertTarget;
            }
            if (cmdletContext.Behavior != null)
            {
                request.Behaviors = cmdletContext.Behavior;
            }
            
             // populate MetricsExportConfig
            var requestMetricsExportConfigIsNull = true;
            request.MetricsExportConfig = new Amazon.IoT.Model.MetricsExportConfig();
            System.String requestMetricsExportConfig_metricsExportConfig_MqttTopic = null;
            if (cmdletContext.MetricsExportConfig_MqttTopic != null)
            {
                requestMetricsExportConfig_metricsExportConfig_MqttTopic = cmdletContext.MetricsExportConfig_MqttTopic;
            }
            if (requestMetricsExportConfig_metricsExportConfig_MqttTopic != null)
            {
                request.MetricsExportConfig.MqttTopic = requestMetricsExportConfig_metricsExportConfig_MqttTopic;
                requestMetricsExportConfigIsNull = false;
            }
            System.String requestMetricsExportConfig_metricsExportConfig_RoleArn = null;
            if (cmdletContext.MetricsExportConfig_RoleArn != null)
            {
                requestMetricsExportConfig_metricsExportConfig_RoleArn = cmdletContext.MetricsExportConfig_RoleArn;
            }
            if (requestMetricsExportConfig_metricsExportConfig_RoleArn != null)
            {
                request.MetricsExportConfig.RoleArn = requestMetricsExportConfig_metricsExportConfig_RoleArn;
                requestMetricsExportConfigIsNull = false;
            }
             // determine if request.MetricsExportConfig should be set to null
            if (requestMetricsExportConfigIsNull)
            {
                request.MetricsExportConfig = null;
            }
            if (cmdletContext.SecurityProfileDescription != null)
            {
                request.SecurityProfileDescription = cmdletContext.SecurityProfileDescription;
            }
            if (cmdletContext.SecurityProfileName != null)
            {
                request.SecurityProfileName = cmdletContext.SecurityProfileName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.IoT.Model.CreateSecurityProfileResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateSecurityProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateSecurityProfile");
            try
            {
                #if DESKTOP
                return client.CreateSecurityProfile(request);
                #elif CORECLR
                return client.CreateSecurityProfileAsync(request).GetAwaiter().GetResult();
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
            [System.ObsoleteAttribute]
            public List<System.String> AdditionalMetricsToRetain { get; set; }
            public List<Amazon.IoT.Model.MetricToRetain> AdditionalMetricsToRetainV2 { get; set; }
            public Dictionary<System.String, Amazon.IoT.Model.AlertTarget> AlertTarget { get; set; }
            public List<Amazon.IoT.Model.Behavior> Behavior { get; set; }
            public System.String MetricsExportConfig_MqttTopic { get; set; }
            public System.String MetricsExportConfig_RoleArn { get; set; }
            public System.String SecurityProfileDescription { get; set; }
            public System.String SecurityProfileName { get; set; }
            public List<Amazon.IoT.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IoT.Model.CreateSecurityProfileResponse, NewIOTSecurityProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
