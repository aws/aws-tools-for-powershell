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
    /// Set the runtime log configuration for a specific managed thing or for all managed
    /// things as a group.
    /// </summary>
    [Cmdlet("Write", "IOTMIRuntimeLogConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Managed integrations for AWS IoT Device Management PutRuntimeLogConfiguration API operation.", Operation = new[] {"PutRuntimeLogConfiguration"}, SelectReturnType = typeof(Amazon.IoTManagedIntegrations.Model.PutRuntimeLogConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.IoTManagedIntegrations.Model.PutRuntimeLogConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTManagedIntegrations.Model.PutRuntimeLogConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteIOTMIRuntimeLogConfigurationCmdlet : AmazonIoTManagedIntegrationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RuntimeLogConfigurations_DeleteLocalStoreAfterUpload
        /// <summary>
        /// <para>
        /// <para>Configuration to enable or disable deleting of runtime logs in the device once uploaded
        /// to the cloud.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RuntimeLogConfigurations_DeleteLocalStoreAfterUpload { get; set; }
        #endregion
        
        #region Parameter RuntimeLogConfigurations_LocalStoreFileRotationMaxByte
        /// <summary>
        /// <para>
        /// <para>Configuration to set the maximum bytes of runtime logs that can be stored on the device
        /// before the oldest logs are deleted or overwritten.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuntimeLogConfigurations_LocalStoreFileRotationMaxBytes")]
        public System.Int32? RuntimeLogConfigurations_LocalStoreFileRotationMaxByte { get; set; }
        #endregion
        
        #region Parameter RuntimeLogConfigurations_LocalStoreFileRotationMaxFile
        /// <summary>
        /// <para>
        /// <para>Configuration to set the maximum number of runtime log files that can be stored on
        /// the device before the oldest files are deleted or overwritten.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuntimeLogConfigurations_LocalStoreFileRotationMaxFiles")]
        public System.Int32? RuntimeLogConfigurations_LocalStoreFileRotationMaxFile { get; set; }
        #endregion
        
        #region Parameter RuntimeLogConfigurations_LocalStoreLocation
        /// <summary>
        /// <para>
        /// <para>Configuration of where to store runtime logs in the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuntimeLogConfigurations_LocalStoreLocation { get; set; }
        #endregion
        
        #region Parameter RuntimeLogConfigurations_LogFlushLevel
        /// <summary>
        /// <para>
        /// <para>The different log levels available for configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.LogLevel")]
        public Amazon.IoTManagedIntegrations.LogLevel RuntimeLogConfigurations_LogFlushLevel { get; set; }
        #endregion
        
        #region Parameter RuntimeLogConfigurations_LogLevel
        /// <summary>
        /// <para>
        /// <para>The different log levels available for configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.LogLevel")]
        public Amazon.IoTManagedIntegrations.LogLevel RuntimeLogConfigurations_LogLevel { get; set; }
        #endregion
        
        #region Parameter ManagedThingId
        /// <summary>
        /// <para>
        /// <para>The id for a managed thing.</para>
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
        public System.String ManagedThingId { get; set; }
        #endregion
        
        #region Parameter RuntimeLogConfigurations_UploadLog
        /// <summary>
        /// <para>
        /// <para>Configuration to enable or disable uploading of runtime logs to the cloud.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RuntimeLogConfigurations_UploadLog { get; set; }
        #endregion
        
        #region Parameter RuntimeLogConfigurations_UploadPeriodMinute
        /// <summary>
        /// <para>
        /// <para>Configuration to set the time interval in minutes between each batch of runtime logs
        /// that the device uploads to the cloud.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuntimeLogConfigurations_UploadPeriodMinutes")]
        public System.Int32? RuntimeLogConfigurations_UploadPeriodMinute { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTManagedIntegrations.Model.PutRuntimeLogConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ManagedThingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-IOTMIRuntimeLogConfiguration (PutRuntimeLogConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTManagedIntegrations.Model.PutRuntimeLogConfigurationResponse, WriteIOTMIRuntimeLogConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ManagedThingId = this.ManagedThingId;
            #if MODULAR
            if (this.ManagedThingId == null && ParameterWasBound(nameof(this.ManagedThingId)))
            {
                WriteWarning("You are passing $null as a value for parameter ManagedThingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuntimeLogConfigurations_DeleteLocalStoreAfterUpload = this.RuntimeLogConfigurations_DeleteLocalStoreAfterUpload;
            context.RuntimeLogConfigurations_LocalStoreFileRotationMaxByte = this.RuntimeLogConfigurations_LocalStoreFileRotationMaxByte;
            context.RuntimeLogConfigurations_LocalStoreFileRotationMaxFile = this.RuntimeLogConfigurations_LocalStoreFileRotationMaxFile;
            context.RuntimeLogConfigurations_LocalStoreLocation = this.RuntimeLogConfigurations_LocalStoreLocation;
            context.RuntimeLogConfigurations_LogFlushLevel = this.RuntimeLogConfigurations_LogFlushLevel;
            context.RuntimeLogConfigurations_LogLevel = this.RuntimeLogConfigurations_LogLevel;
            context.RuntimeLogConfigurations_UploadLog = this.RuntimeLogConfigurations_UploadLog;
            context.RuntimeLogConfigurations_UploadPeriodMinute = this.RuntimeLogConfigurations_UploadPeriodMinute;
            
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
            var request = new Amazon.IoTManagedIntegrations.Model.PutRuntimeLogConfigurationRequest();
            
            if (cmdletContext.ManagedThingId != null)
            {
                request.ManagedThingId = cmdletContext.ManagedThingId;
            }
            
             // populate RuntimeLogConfigurations
            var requestRuntimeLogConfigurationsIsNull = true;
            request.RuntimeLogConfigurations = new Amazon.IoTManagedIntegrations.Model.RuntimeLogConfigurations();
            System.Boolean? requestRuntimeLogConfigurations_runtimeLogConfigurations_DeleteLocalStoreAfterUpload = null;
            if (cmdletContext.RuntimeLogConfigurations_DeleteLocalStoreAfterUpload != null)
            {
                requestRuntimeLogConfigurations_runtimeLogConfigurations_DeleteLocalStoreAfterUpload = cmdletContext.RuntimeLogConfigurations_DeleteLocalStoreAfterUpload.Value;
            }
            if (requestRuntimeLogConfigurations_runtimeLogConfigurations_DeleteLocalStoreAfterUpload != null)
            {
                request.RuntimeLogConfigurations.DeleteLocalStoreAfterUpload = requestRuntimeLogConfigurations_runtimeLogConfigurations_DeleteLocalStoreAfterUpload.Value;
                requestRuntimeLogConfigurationsIsNull = false;
            }
            System.Int32? requestRuntimeLogConfigurations_runtimeLogConfigurations_LocalStoreFileRotationMaxByte = null;
            if (cmdletContext.RuntimeLogConfigurations_LocalStoreFileRotationMaxByte != null)
            {
                requestRuntimeLogConfigurations_runtimeLogConfigurations_LocalStoreFileRotationMaxByte = cmdletContext.RuntimeLogConfigurations_LocalStoreFileRotationMaxByte.Value;
            }
            if (requestRuntimeLogConfigurations_runtimeLogConfigurations_LocalStoreFileRotationMaxByte != null)
            {
                request.RuntimeLogConfigurations.LocalStoreFileRotationMaxBytes = requestRuntimeLogConfigurations_runtimeLogConfigurations_LocalStoreFileRotationMaxByte.Value;
                requestRuntimeLogConfigurationsIsNull = false;
            }
            System.Int32? requestRuntimeLogConfigurations_runtimeLogConfigurations_LocalStoreFileRotationMaxFile = null;
            if (cmdletContext.RuntimeLogConfigurations_LocalStoreFileRotationMaxFile != null)
            {
                requestRuntimeLogConfigurations_runtimeLogConfigurations_LocalStoreFileRotationMaxFile = cmdletContext.RuntimeLogConfigurations_LocalStoreFileRotationMaxFile.Value;
            }
            if (requestRuntimeLogConfigurations_runtimeLogConfigurations_LocalStoreFileRotationMaxFile != null)
            {
                request.RuntimeLogConfigurations.LocalStoreFileRotationMaxFiles = requestRuntimeLogConfigurations_runtimeLogConfigurations_LocalStoreFileRotationMaxFile.Value;
                requestRuntimeLogConfigurationsIsNull = false;
            }
            System.String requestRuntimeLogConfigurations_runtimeLogConfigurations_LocalStoreLocation = null;
            if (cmdletContext.RuntimeLogConfigurations_LocalStoreLocation != null)
            {
                requestRuntimeLogConfigurations_runtimeLogConfigurations_LocalStoreLocation = cmdletContext.RuntimeLogConfigurations_LocalStoreLocation;
            }
            if (requestRuntimeLogConfigurations_runtimeLogConfigurations_LocalStoreLocation != null)
            {
                request.RuntimeLogConfigurations.LocalStoreLocation = requestRuntimeLogConfigurations_runtimeLogConfigurations_LocalStoreLocation;
                requestRuntimeLogConfigurationsIsNull = false;
            }
            Amazon.IoTManagedIntegrations.LogLevel requestRuntimeLogConfigurations_runtimeLogConfigurations_LogFlushLevel = null;
            if (cmdletContext.RuntimeLogConfigurations_LogFlushLevel != null)
            {
                requestRuntimeLogConfigurations_runtimeLogConfigurations_LogFlushLevel = cmdletContext.RuntimeLogConfigurations_LogFlushLevel;
            }
            if (requestRuntimeLogConfigurations_runtimeLogConfigurations_LogFlushLevel != null)
            {
                request.RuntimeLogConfigurations.LogFlushLevel = requestRuntimeLogConfigurations_runtimeLogConfigurations_LogFlushLevel;
                requestRuntimeLogConfigurationsIsNull = false;
            }
            Amazon.IoTManagedIntegrations.LogLevel requestRuntimeLogConfigurations_runtimeLogConfigurations_LogLevel = null;
            if (cmdletContext.RuntimeLogConfigurations_LogLevel != null)
            {
                requestRuntimeLogConfigurations_runtimeLogConfigurations_LogLevel = cmdletContext.RuntimeLogConfigurations_LogLevel;
            }
            if (requestRuntimeLogConfigurations_runtimeLogConfigurations_LogLevel != null)
            {
                request.RuntimeLogConfigurations.LogLevel = requestRuntimeLogConfigurations_runtimeLogConfigurations_LogLevel;
                requestRuntimeLogConfigurationsIsNull = false;
            }
            System.Boolean? requestRuntimeLogConfigurations_runtimeLogConfigurations_UploadLog = null;
            if (cmdletContext.RuntimeLogConfigurations_UploadLog != null)
            {
                requestRuntimeLogConfigurations_runtimeLogConfigurations_UploadLog = cmdletContext.RuntimeLogConfigurations_UploadLog.Value;
            }
            if (requestRuntimeLogConfigurations_runtimeLogConfigurations_UploadLog != null)
            {
                request.RuntimeLogConfigurations.UploadLog = requestRuntimeLogConfigurations_runtimeLogConfigurations_UploadLog.Value;
                requestRuntimeLogConfigurationsIsNull = false;
            }
            System.Int32? requestRuntimeLogConfigurations_runtimeLogConfigurations_UploadPeriodMinute = null;
            if (cmdletContext.RuntimeLogConfigurations_UploadPeriodMinute != null)
            {
                requestRuntimeLogConfigurations_runtimeLogConfigurations_UploadPeriodMinute = cmdletContext.RuntimeLogConfigurations_UploadPeriodMinute.Value;
            }
            if (requestRuntimeLogConfigurations_runtimeLogConfigurations_UploadPeriodMinute != null)
            {
                request.RuntimeLogConfigurations.UploadPeriodMinutes = requestRuntimeLogConfigurations_runtimeLogConfigurations_UploadPeriodMinute.Value;
                requestRuntimeLogConfigurationsIsNull = false;
            }
             // determine if request.RuntimeLogConfigurations should be set to null
            if (requestRuntimeLogConfigurationsIsNull)
            {
                request.RuntimeLogConfigurations = null;
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
        
        private Amazon.IoTManagedIntegrations.Model.PutRuntimeLogConfigurationResponse CallAWSServiceOperation(IAmazonIoTManagedIntegrations client, Amazon.IoTManagedIntegrations.Model.PutRuntimeLogConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed integrations for AWS IoT Device Management", "PutRuntimeLogConfiguration");
            try
            {
                return client.PutRuntimeLogConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ManagedThingId { get; set; }
            public System.Boolean? RuntimeLogConfigurations_DeleteLocalStoreAfterUpload { get; set; }
            public System.Int32? RuntimeLogConfigurations_LocalStoreFileRotationMaxByte { get; set; }
            public System.Int32? RuntimeLogConfigurations_LocalStoreFileRotationMaxFile { get; set; }
            public System.String RuntimeLogConfigurations_LocalStoreLocation { get; set; }
            public Amazon.IoTManagedIntegrations.LogLevel RuntimeLogConfigurations_LogFlushLevel { get; set; }
            public Amazon.IoTManagedIntegrations.LogLevel RuntimeLogConfigurations_LogLevel { get; set; }
            public System.Boolean? RuntimeLogConfigurations_UploadLog { get; set; }
            public System.Int32? RuntimeLogConfigurations_UploadPeriodMinute { get; set; }
            public System.Func<Amazon.IoTManagedIntegrations.Model.PutRuntimeLogConfigurationResponse, WriteIOTMIRuntimeLogConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
