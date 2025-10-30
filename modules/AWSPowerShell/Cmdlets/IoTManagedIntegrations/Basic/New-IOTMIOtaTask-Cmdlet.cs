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
using Amazon.IoTManagedIntegrations;
using Amazon.IoTManagedIntegrations.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTMI
{
    /// <summary>
    /// Create an over-the-air (OTA) task to target a device.
    /// </summary>
    [Cmdlet("New", "IOTMIOtaTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTManagedIntegrations.Model.CreateOtaTaskResponse")]
    [AWSCmdlet("Calls the Managed integrations for AWS IoT Device Management CreateOtaTask API operation.", Operation = new[] {"CreateOtaTask"}, SelectReturnType = typeof(Amazon.IoTManagedIntegrations.Model.CreateOtaTaskResponse))]
    [AWSCmdletOutput("Amazon.IoTManagedIntegrations.Model.CreateOtaTaskResponse",
        "This cmdlet returns an Amazon.IoTManagedIntegrations.Model.CreateOtaTaskResponse object containing multiple properties."
    )]
    public partial class NewIOTMIOtaTaskCmdlet : AmazonIoTManagedIntegrationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the over-the-air (OTA) task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter OtaSchedulingConfig_EndBehavior
        /// <summary>
        /// <para>
        /// <para>Specifies the end behavior for all task executions after a task reaches the selected
        /// <c>endTime</c>. If <c>endTime</c> is not selected when creating the task, then <c>endBehavior</c>
        /// does not apply.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.SchedulingConfigEndBehavior")]
        public Amazon.IoTManagedIntegrations.SchedulingConfigEndBehavior OtaSchedulingConfig_EndBehavior { get; set; }
        #endregion
        
        #region Parameter OtaSchedulingConfig_EndTime
        /// <summary>
        /// <para>
        /// <para>The time an over-the-air (OTA) task will stop.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OtaSchedulingConfig_EndTime { get; set; }
        #endregion
        
        #region Parameter OtaSchedulingConfig_MaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>Maintenance window list for over-the-air (OTA) task scheduling config.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OtaSchedulingConfig_MaintenanceWindows")]
        public Amazon.IoTManagedIntegrations.Model.ScheduleMaintenanceWindow[] OtaSchedulingConfig_MaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter OtaMechanism
        /// <summary>
        /// <para>
        /// <para>The deployment mechanism for the over-the-air (OTA) task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.OtaMechanism")]
        public Amazon.IoTManagedIntegrations.OtaMechanism OtaMechanism { get; set; }
        #endregion
        
        #region Parameter OtaTargetQueryString
        /// <summary>
        /// <para>
        /// <para>The query string to add things to the thing group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OtaTargetQueryString { get; set; }
        #endregion
        
        #region Parameter OtaType
        /// <summary>
        /// <para>
        /// <para>The frequency type for the over-the-air (OTA) task.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.OtaType")]
        public Amazon.IoTManagedIntegrations.OtaType OtaType { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The connection protocol the over-the-air (OTA) task uses to update the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.OtaProtocol")]
        public Amazon.IoTManagedIntegrations.OtaProtocol Protocol { get; set; }
        #endregion
        
        #region Parameter OtaTaskExecutionRetryConfig_RetryConfigCriterion
        /// <summary>
        /// <para>
        /// <para>The list of retry config criteria.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OtaTaskExecutionRetryConfig_RetryConfigCriteria")]
        public Amazon.IoTManagedIntegrations.Model.RetryConfigCriteria[] OtaTaskExecutionRetryConfig_RetryConfigCriterion { get; set; }
        #endregion
        
        #region Parameter S3Url
        /// <summary>
        /// <para>
        /// <para>The URL to the Amazon S3 bucket where the over-the-air (OTA) task is stored.</para>
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
        public System.String S3Url { get; set; }
        #endregion
        
        #region Parameter OtaSchedulingConfig_StartTime
        /// <summary>
        /// <para>
        /// <para>The time an over-the-air (OTA) task will start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OtaSchedulingConfig_StartTime { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of key/value pairs that are used to manage the over-the-air (OTA) task.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The device targeted for the over-the-air (OTA) task.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Target { get; set; }
        #endregion
        
        #region Parameter TaskConfigurationId
        /// <summary>
        /// <para>
        /// <para>The identifier for the over-the-air (OTA) task configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskConfigurationId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An idempotency token. If you retry a request that completed successfully initially
        /// using the same client token and parameters, then the retry attempt will succeed without
        /// performing any further actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTManagedIntegrations.Model.CreateOtaTaskResponse).
        /// Specifying the name of a property of type Amazon.IoTManagedIntegrations.Model.CreateOtaTaskResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TaskConfigurationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTMIOtaTask (CreateOtaTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTManagedIntegrations.Model.CreateOtaTaskResponse, NewIOTMIOtaTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.OtaMechanism = this.OtaMechanism;
            context.OtaSchedulingConfig_EndBehavior = this.OtaSchedulingConfig_EndBehavior;
            context.OtaSchedulingConfig_EndTime = this.OtaSchedulingConfig_EndTime;
            if (this.OtaSchedulingConfig_MaintenanceWindow != null)
            {
                context.OtaSchedulingConfig_MaintenanceWindow = new List<Amazon.IoTManagedIntegrations.Model.ScheduleMaintenanceWindow>(this.OtaSchedulingConfig_MaintenanceWindow);
            }
            context.OtaSchedulingConfig_StartTime = this.OtaSchedulingConfig_StartTime;
            context.OtaTargetQueryString = this.OtaTargetQueryString;
            if (this.OtaTaskExecutionRetryConfig_RetryConfigCriterion != null)
            {
                context.OtaTaskExecutionRetryConfig_RetryConfigCriterion = new List<Amazon.IoTManagedIntegrations.Model.RetryConfigCriteria>(this.OtaTaskExecutionRetryConfig_RetryConfigCriterion);
            }
            context.OtaType = this.OtaType;
            #if MODULAR
            if (this.OtaType == null && ParameterWasBound(nameof(this.OtaType)))
            {
                WriteWarning("You are passing $null as a value for parameter OtaType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Protocol = this.Protocol;
            context.S3Url = this.S3Url;
            #if MODULAR
            if (this.S3Url == null && ParameterWasBound(nameof(this.S3Url)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Url which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.Target != null)
            {
                context.Target = new List<System.String>(this.Target);
            }
            context.TaskConfigurationId = this.TaskConfigurationId;
            
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
            var request = new Amazon.IoTManagedIntegrations.Model.CreateOtaTaskRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.OtaMechanism != null)
            {
                request.OtaMechanism = cmdletContext.OtaMechanism;
            }
            
             // populate OtaSchedulingConfig
            var requestOtaSchedulingConfigIsNull = true;
            request.OtaSchedulingConfig = new Amazon.IoTManagedIntegrations.Model.OtaTaskSchedulingConfig();
            Amazon.IoTManagedIntegrations.SchedulingConfigEndBehavior requestOtaSchedulingConfig_otaSchedulingConfig_EndBehavior = null;
            if (cmdletContext.OtaSchedulingConfig_EndBehavior != null)
            {
                requestOtaSchedulingConfig_otaSchedulingConfig_EndBehavior = cmdletContext.OtaSchedulingConfig_EndBehavior;
            }
            if (requestOtaSchedulingConfig_otaSchedulingConfig_EndBehavior != null)
            {
                request.OtaSchedulingConfig.EndBehavior = requestOtaSchedulingConfig_otaSchedulingConfig_EndBehavior;
                requestOtaSchedulingConfigIsNull = false;
            }
            System.String requestOtaSchedulingConfig_otaSchedulingConfig_EndTime = null;
            if (cmdletContext.OtaSchedulingConfig_EndTime != null)
            {
                requestOtaSchedulingConfig_otaSchedulingConfig_EndTime = cmdletContext.OtaSchedulingConfig_EndTime;
            }
            if (requestOtaSchedulingConfig_otaSchedulingConfig_EndTime != null)
            {
                request.OtaSchedulingConfig.EndTime = requestOtaSchedulingConfig_otaSchedulingConfig_EndTime;
                requestOtaSchedulingConfigIsNull = false;
            }
            List<Amazon.IoTManagedIntegrations.Model.ScheduleMaintenanceWindow> requestOtaSchedulingConfig_otaSchedulingConfig_MaintenanceWindow = null;
            if (cmdletContext.OtaSchedulingConfig_MaintenanceWindow != null)
            {
                requestOtaSchedulingConfig_otaSchedulingConfig_MaintenanceWindow = cmdletContext.OtaSchedulingConfig_MaintenanceWindow;
            }
            if (requestOtaSchedulingConfig_otaSchedulingConfig_MaintenanceWindow != null)
            {
                request.OtaSchedulingConfig.MaintenanceWindows = requestOtaSchedulingConfig_otaSchedulingConfig_MaintenanceWindow;
                requestOtaSchedulingConfigIsNull = false;
            }
            System.String requestOtaSchedulingConfig_otaSchedulingConfig_StartTime = null;
            if (cmdletContext.OtaSchedulingConfig_StartTime != null)
            {
                requestOtaSchedulingConfig_otaSchedulingConfig_StartTime = cmdletContext.OtaSchedulingConfig_StartTime;
            }
            if (requestOtaSchedulingConfig_otaSchedulingConfig_StartTime != null)
            {
                request.OtaSchedulingConfig.StartTime = requestOtaSchedulingConfig_otaSchedulingConfig_StartTime;
                requestOtaSchedulingConfigIsNull = false;
            }
             // determine if request.OtaSchedulingConfig should be set to null
            if (requestOtaSchedulingConfigIsNull)
            {
                request.OtaSchedulingConfig = null;
            }
            if (cmdletContext.OtaTargetQueryString != null)
            {
                request.OtaTargetQueryString = cmdletContext.OtaTargetQueryString;
            }
            
             // populate OtaTaskExecutionRetryConfig
            var requestOtaTaskExecutionRetryConfigIsNull = true;
            request.OtaTaskExecutionRetryConfig = new Amazon.IoTManagedIntegrations.Model.OtaTaskExecutionRetryConfig();
            List<Amazon.IoTManagedIntegrations.Model.RetryConfigCriteria> requestOtaTaskExecutionRetryConfig_otaTaskExecutionRetryConfig_RetryConfigCriterion = null;
            if (cmdletContext.OtaTaskExecutionRetryConfig_RetryConfigCriterion != null)
            {
                requestOtaTaskExecutionRetryConfig_otaTaskExecutionRetryConfig_RetryConfigCriterion = cmdletContext.OtaTaskExecutionRetryConfig_RetryConfigCriterion;
            }
            if (requestOtaTaskExecutionRetryConfig_otaTaskExecutionRetryConfig_RetryConfigCriterion != null)
            {
                request.OtaTaskExecutionRetryConfig.RetryConfigCriteria = requestOtaTaskExecutionRetryConfig_otaTaskExecutionRetryConfig_RetryConfigCriterion;
                requestOtaTaskExecutionRetryConfigIsNull = false;
            }
             // determine if request.OtaTaskExecutionRetryConfig should be set to null
            if (requestOtaTaskExecutionRetryConfigIsNull)
            {
                request.OtaTaskExecutionRetryConfig = null;
            }
            if (cmdletContext.OtaType != null)
            {
                request.OtaType = cmdletContext.OtaType;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.S3Url != null)
            {
                request.S3Url = cmdletContext.S3Url;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Target != null)
            {
                request.Target = cmdletContext.Target;
            }
            if (cmdletContext.TaskConfigurationId != null)
            {
                request.TaskConfigurationId = cmdletContext.TaskConfigurationId;
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
        
        private Amazon.IoTManagedIntegrations.Model.CreateOtaTaskResponse CallAWSServiceOperation(IAmazonIoTManagedIntegrations client, Amazon.IoTManagedIntegrations.Model.CreateOtaTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed integrations for AWS IoT Device Management", "CreateOtaTask");
            try
            {
                return client.CreateOtaTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public Amazon.IoTManagedIntegrations.OtaMechanism OtaMechanism { get; set; }
            public Amazon.IoTManagedIntegrations.SchedulingConfigEndBehavior OtaSchedulingConfig_EndBehavior { get; set; }
            public System.String OtaSchedulingConfig_EndTime { get; set; }
            public List<Amazon.IoTManagedIntegrations.Model.ScheduleMaintenanceWindow> OtaSchedulingConfig_MaintenanceWindow { get; set; }
            public System.String OtaSchedulingConfig_StartTime { get; set; }
            public System.String OtaTargetQueryString { get; set; }
            public List<Amazon.IoTManagedIntegrations.Model.RetryConfigCriteria> OtaTaskExecutionRetryConfig_RetryConfigCriterion { get; set; }
            public Amazon.IoTManagedIntegrations.OtaType OtaType { get; set; }
            public Amazon.IoTManagedIntegrations.OtaProtocol Protocol { get; set; }
            public System.String S3Url { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<System.String> Target { get; set; }
            public System.String TaskConfigurationId { get; set; }
            public System.Func<Amazon.IoTManagedIntegrations.Model.CreateOtaTaskResponse, NewIOTMIOtaTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
