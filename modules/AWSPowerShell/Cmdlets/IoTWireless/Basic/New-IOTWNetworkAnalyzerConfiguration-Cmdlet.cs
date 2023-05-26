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
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// Creates a new network analyzer configuration.
    /// </summary>
    [Cmdlet("New", "IOTWNetworkAnalyzerConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTWireless.Model.CreateNetworkAnalyzerConfigurationResponse")]
    [AWSCmdlet("Calls the AWS IoT Wireless CreateNetworkAnalyzerConfiguration API operation.", Operation = new[] {"CreateNetworkAnalyzerConfiguration"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.CreateNetworkAnalyzerConfigurationResponse))]
    [AWSCmdletOutput("Amazon.IoTWireless.Model.CreateNetworkAnalyzerConfigurationResponse",
        "This cmdlet returns an Amazon.IoTWireless.Model.CreateNetworkAnalyzerConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTWNetworkAnalyzerConfigurationCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
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
        
        #region Parameter MulticastGroup
        /// <summary>
        /// <para>
        /// <para>Multicast Group resources to add to the network analyzer configruation. Provide the
        /// <code>MulticastGroupId</code> of the resource to add in the input array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MulticastGroups")]
        public System.String[] MulticastGroup { get; set; }
        #endregion
        
        #region Parameter Name
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoTWireless.Model.Tag[] Tag { get; set; }
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
        
        #region Parameter WirelessDevice
        /// <summary>
        /// <para>
        /// <para>Wireless device resources to add to the network analyzer configuration. Provide the
        /// <code>WirelessDeviceId</code> of the resource to add in the input array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WirelessDevices")]
        public System.String[] WirelessDevice { get; set; }
        #endregion
        
        #region Parameter WirelessGateway
        /// <summary>
        /// <para>
        /// <para>Wireless gateway resources to add to the network analyzer configuration. Provide the
        /// <code>WirelessGatewayId</code> of the resource to add in the input array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WirelessGateways")]
        public System.String[] WirelessGateway { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.CreateNetworkAnalyzerConfigurationResponse).
        /// Specifying the name of a property of type Amazon.IoTWireless.Model.CreateNetworkAnalyzerConfigurationResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTWNetworkAnalyzerConfiguration (CreateNetworkAnalyzerConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.CreateNetworkAnalyzerConfigurationResponse, NewIOTWNetworkAnalyzerConfigurationCmdlet>(Select) ??
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
            context.ClientRequestToken = this.ClientRequestToken;
            context.Description = this.Description;
            if (this.MulticastGroup != null)
            {
                context.MulticastGroup = new List<System.String>(this.MulticastGroup);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoTWireless.Model.Tag>(this.Tag);
            }
            context.TraceContent_LogLevel = this.TraceContent_LogLevel;
            context.TraceContent_MulticastFrameInfo = this.TraceContent_MulticastFrameInfo;
            context.TraceContent_WirelessDeviceFrameInfo = this.TraceContent_WirelessDeviceFrameInfo;
            if (this.WirelessDevice != null)
            {
                context.WirelessDevice = new List<System.String>(this.WirelessDevice);
            }
            if (this.WirelessGateway != null)
            {
                context.WirelessGateway = new List<System.String>(this.WirelessGateway);
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
            var request = new Amazon.IoTWireless.Model.CreateNetworkAnalyzerConfigurationRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.MulticastGroup != null)
            {
                request.MulticastGroups = cmdletContext.MulticastGroup;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
            if (cmdletContext.WirelessDevice != null)
            {
                request.WirelessDevices = cmdletContext.WirelessDevice;
            }
            if (cmdletContext.WirelessGateway != null)
            {
                request.WirelessGateways = cmdletContext.WirelessGateway;
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
        
        private Amazon.IoTWireless.Model.CreateNetworkAnalyzerConfigurationResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.CreateNetworkAnalyzerConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "CreateNetworkAnalyzerConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateNetworkAnalyzerConfiguration(request);
                #elif CORECLR
                return client.CreateNetworkAnalyzerConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String Description { get; set; }
            public List<System.String> MulticastGroup { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.IoTWireless.Model.Tag> Tag { get; set; }
            public Amazon.IoTWireless.LogLevel TraceContent_LogLevel { get; set; }
            public Amazon.IoTWireless.MulticastFrameInfo TraceContent_MulticastFrameInfo { get; set; }
            public Amazon.IoTWireless.WirelessDeviceFrameInfo TraceContent_WirelessDeviceFrameInfo { get; set; }
            public List<System.String> WirelessDevice { get; set; }
            public List<System.String> WirelessGateway { get; set; }
            public System.Func<Amazon.IoTWireless.Model.CreateNetworkAnalyzerConfigurationResponse, NewIOTWNetworkAnalyzerConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
