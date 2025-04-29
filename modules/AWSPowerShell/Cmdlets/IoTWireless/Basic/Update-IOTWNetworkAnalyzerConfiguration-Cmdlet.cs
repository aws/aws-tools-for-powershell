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
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// Update network analyzer configuration.
    /// </summary>
    [Cmdlet("Update", "IOTWNetworkAnalyzerConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT Wireless UpdateNetworkAnalyzerConfiguration API operation.", Operation = new[] {"UpdateNetworkAnalyzerConfiguration"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.UpdateNetworkAnalyzerConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.IoTWireless.Model.UpdateNetworkAnalyzerConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTWireless.Model.UpdateNetworkAnalyzerConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTWNetworkAnalyzerConfigurationCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigurationName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String ConfigurationName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter TraceContent_LogLevel
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTWireless.LogLevel")]
        public Amazon.IoTWireless.LogLevel TraceContent_LogLevel { get; set; }
        #endregion
        
        #region Parameter TraceContent_MulticastFrameInfo
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTWireless.MulticastFrameInfo")]
        public Amazon.IoTWireless.MulticastFrameInfo TraceContent_MulticastFrameInfo { get; set; }
        #endregion
        
        #region Parameter MulticastGroupsToAdd
        /// <summary>
        /// <para>
        /// <para>Multicast group resources to add to the network analyzer configuration. Provide the
        /// <c>MulticastGroupId</c> of the resource to add in the input array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] MulticastGroupsToAdd { get; set; }
        #endregion
        
        #region Parameter MulticastGroupsToRemove
        /// <summary>
        /// <para>
        /// <para>Multicast group resources to remove from the network analyzer configuration. Provide
        /// the <c>MulticastGroupId</c> of the resources to remove in the input array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] MulticastGroupsToRemove { get; set; }
        #endregion
        
        #region Parameter TraceContent_WirelessDeviceFrameInfo
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTWireless.WirelessDeviceFrameInfo")]
        public Amazon.IoTWireless.WirelessDeviceFrameInfo TraceContent_WirelessDeviceFrameInfo { get; set; }
        #endregion
        
        #region Parameter WirelessDevicesToAdd
        /// <summary>
        /// <para>
        /// <para>Wireless device resources to add to the network analyzer configuration. Provide the
        /// <c>WirelessDeviceId</c> of the resource to add in the input array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] WirelessDevicesToAdd { get; set; }
        #endregion
        
        #region Parameter WirelessDevicesToRemove
        /// <summary>
        /// <para>
        /// <para>Wireless device resources to remove from the network analyzer configuration. Provide
        /// the <c>WirelessDeviceId</c> of the resources to remove in the input array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] WirelessDevicesToRemove { get; set; }
        #endregion
        
        #region Parameter WirelessGatewaysToAdd
        /// <summary>
        /// <para>
        /// <para>Wireless gateway resources to add to the network analyzer configuration. Provide the
        /// <c>WirelessGatewayId</c> of the resource to add in the input array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] WirelessGatewaysToAdd { get; set; }
        #endregion
        
        #region Parameter WirelessGatewaysToRemove
        /// <summary>
        /// <para>
        /// <para>Wireless gateway resources to remove from the network analyzer configuration. Provide
        /// the <c>WirelessGatewayId</c> of the resources to remove in the input array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] WirelessGatewaysToRemove { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.UpdateNetworkAnalyzerConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTWNetworkAnalyzerConfiguration (UpdateNetworkAnalyzerConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.UpdateNetworkAnalyzerConfigurationResponse, UpdateIOTWNetworkAnalyzerConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationName = this.ConfigurationName;
            #if MODULAR
            if (this.ConfigurationName == null && ParameterWasBound(nameof(this.ConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            if (this.MulticastGroupsToAdd != null)
            {
                context.MulticastGroupsToAdd = new List<System.String>(this.MulticastGroupsToAdd);
            }
            if (this.MulticastGroupsToRemove != null)
            {
                context.MulticastGroupsToRemove = new List<System.String>(this.MulticastGroupsToRemove);
            }
            context.TraceContent_LogLevel = this.TraceContent_LogLevel;
            context.TraceContent_MulticastFrameInfo = this.TraceContent_MulticastFrameInfo;
            context.TraceContent_WirelessDeviceFrameInfo = this.TraceContent_WirelessDeviceFrameInfo;
            if (this.WirelessDevicesToAdd != null)
            {
                context.WirelessDevicesToAdd = new List<System.String>(this.WirelessDevicesToAdd);
            }
            if (this.WirelessDevicesToRemove != null)
            {
                context.WirelessDevicesToRemove = new List<System.String>(this.WirelessDevicesToRemove);
            }
            if (this.WirelessGatewaysToAdd != null)
            {
                context.WirelessGatewaysToAdd = new List<System.String>(this.WirelessGatewaysToAdd);
            }
            if (this.WirelessGatewaysToRemove != null)
            {
                context.WirelessGatewaysToRemove = new List<System.String>(this.WirelessGatewaysToRemove);
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
            var request = new Amazon.IoTWireless.Model.UpdateNetworkAnalyzerConfigurationRequest();
            
            if (cmdletContext.ConfigurationName != null)
            {
                request.ConfigurationName = cmdletContext.ConfigurationName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.MulticastGroupsToAdd != null)
            {
                request.MulticastGroupsToAdd = cmdletContext.MulticastGroupsToAdd;
            }
            if (cmdletContext.MulticastGroupsToRemove != null)
            {
                request.MulticastGroupsToRemove = cmdletContext.MulticastGroupsToRemove;
            }
            
             // populate TraceContent
            var requestTraceContentIsNull = true;
            request.TraceContent = new Amazon.IoTWireless.Model.TraceContent();
            Amazon.IoTWireless.LogLevel requestTraceContent_traceContent_LogLevel = null;
            if (cmdletContext.TraceContent_LogLevel != null)
            {
                requestTraceContent_traceContent_LogLevel = cmdletContext.TraceContent_LogLevel;
            }
            if (requestTraceContent_traceContent_LogLevel != null)
            {
                request.TraceContent.LogLevel = requestTraceContent_traceContent_LogLevel;
                requestTraceContentIsNull = false;
            }
            Amazon.IoTWireless.MulticastFrameInfo requestTraceContent_traceContent_MulticastFrameInfo = null;
            if (cmdletContext.TraceContent_MulticastFrameInfo != null)
            {
                requestTraceContent_traceContent_MulticastFrameInfo = cmdletContext.TraceContent_MulticastFrameInfo;
            }
            if (requestTraceContent_traceContent_MulticastFrameInfo != null)
            {
                request.TraceContent.MulticastFrameInfo = requestTraceContent_traceContent_MulticastFrameInfo;
                requestTraceContentIsNull = false;
            }
            Amazon.IoTWireless.WirelessDeviceFrameInfo requestTraceContent_traceContent_WirelessDeviceFrameInfo = null;
            if (cmdletContext.TraceContent_WirelessDeviceFrameInfo != null)
            {
                requestTraceContent_traceContent_WirelessDeviceFrameInfo = cmdletContext.TraceContent_WirelessDeviceFrameInfo;
            }
            if (requestTraceContent_traceContent_WirelessDeviceFrameInfo != null)
            {
                request.TraceContent.WirelessDeviceFrameInfo = requestTraceContent_traceContent_WirelessDeviceFrameInfo;
                requestTraceContentIsNull = false;
            }
             // determine if request.TraceContent should be set to null
            if (requestTraceContentIsNull)
            {
                request.TraceContent = null;
            }
            if (cmdletContext.WirelessDevicesToAdd != null)
            {
                request.WirelessDevicesToAdd = cmdletContext.WirelessDevicesToAdd;
            }
            if (cmdletContext.WirelessDevicesToRemove != null)
            {
                request.WirelessDevicesToRemove = cmdletContext.WirelessDevicesToRemove;
            }
            if (cmdletContext.WirelessGatewaysToAdd != null)
            {
                request.WirelessGatewaysToAdd = cmdletContext.WirelessGatewaysToAdd;
            }
            if (cmdletContext.WirelessGatewaysToRemove != null)
            {
                request.WirelessGatewaysToRemove = cmdletContext.WirelessGatewaysToRemove;
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
        
        private Amazon.IoTWireless.Model.UpdateNetworkAnalyzerConfigurationResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.UpdateNetworkAnalyzerConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "UpdateNetworkAnalyzerConfiguration");
            try
            {
                return client.UpdateNetworkAnalyzerConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfigurationName { get; set; }
            public System.String Description { get; set; }
            public List<System.String> MulticastGroupsToAdd { get; set; }
            public List<System.String> MulticastGroupsToRemove { get; set; }
            public Amazon.IoTWireless.LogLevel TraceContent_LogLevel { get; set; }
            public Amazon.IoTWireless.MulticastFrameInfo TraceContent_MulticastFrameInfo { get; set; }
            public Amazon.IoTWireless.WirelessDeviceFrameInfo TraceContent_WirelessDeviceFrameInfo { get; set; }
            public List<System.String> WirelessDevicesToAdd { get; set; }
            public List<System.String> WirelessDevicesToRemove { get; set; }
            public List<System.String> WirelessGatewaysToAdd { get; set; }
            public List<System.String> WirelessGatewaysToRemove { get; set; }
            public System.Func<Amazon.IoTWireless.Model.UpdateNetworkAnalyzerConfigurationResponse, UpdateIOTWNetworkAnalyzerConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
