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
    /// Set default log level, or log levels by resource types. This can be for wireless device
    /// log options or wireless gateways log options and is used to control the log messages
    /// that'll be displayed in CloudWatch.
    /// </summary>
    [Cmdlet("Update", "IOTWLogLevelsByResourceType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT Wireless UpdateLogLevelsByResourceTypes API operation.", Operation = new[] {"UpdateLogLevelsByResourceTypes"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.UpdateLogLevelsByResourceTypesResponse))]
    [AWSCmdletOutput("None or Amazon.IoTWireless.Model.UpdateLogLevelsByResourceTypesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTWireless.Model.UpdateLogLevelsByResourceTypesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTWLogLevelsByResourceTypeCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DefaultLogLevel
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.IoTWireless.LogLevel")]
        public Amazon.IoTWireless.LogLevel DefaultLogLevel { get; set; }
        #endregion
        
        #region Parameter WirelessDeviceLogOption
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WirelessDeviceLogOptions")]
        public Amazon.IoTWireless.Model.WirelessDeviceLogOption[] WirelessDeviceLogOption { get; set; }
        #endregion
        
        #region Parameter WirelessGatewayLogOption
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WirelessGatewayLogOptions")]
        public Amazon.IoTWireless.Model.WirelessGatewayLogOption[] WirelessGatewayLogOption { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.UpdateLogLevelsByResourceTypesResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DefaultLogLevel parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DefaultLogLevel' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DefaultLogLevel' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DefaultLogLevel), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTWLogLevelsByResourceType (UpdateLogLevelsByResourceTypes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.UpdateLogLevelsByResourceTypesResponse, UpdateIOTWLogLevelsByResourceTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DefaultLogLevel;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DefaultLogLevel = this.DefaultLogLevel;
            if (this.WirelessDeviceLogOption != null)
            {
                context.WirelessDeviceLogOption = new List<Amazon.IoTWireless.Model.WirelessDeviceLogOption>(this.WirelessDeviceLogOption);
            }
            if (this.WirelessGatewayLogOption != null)
            {
                context.WirelessGatewayLogOption = new List<Amazon.IoTWireless.Model.WirelessGatewayLogOption>(this.WirelessGatewayLogOption);
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
            var request = new Amazon.IoTWireless.Model.UpdateLogLevelsByResourceTypesRequest();
            
            if (cmdletContext.DefaultLogLevel != null)
            {
                request.DefaultLogLevel = cmdletContext.DefaultLogLevel;
            }
            if (cmdletContext.WirelessDeviceLogOption != null)
            {
                request.WirelessDeviceLogOptions = cmdletContext.WirelessDeviceLogOption;
            }
            if (cmdletContext.WirelessGatewayLogOption != null)
            {
                request.WirelessGatewayLogOptions = cmdletContext.WirelessGatewayLogOption;
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
        
        private Amazon.IoTWireless.Model.UpdateLogLevelsByResourceTypesResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.UpdateLogLevelsByResourceTypesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "UpdateLogLevelsByResourceTypes");
            try
            {
                #if DESKTOP
                return client.UpdateLogLevelsByResourceTypes(request);
                #elif CORECLR
                return client.UpdateLogLevelsByResourceTypesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IoTWireless.LogLevel DefaultLogLevel { get; set; }
            public List<Amazon.IoTWireless.Model.WirelessDeviceLogOption> WirelessDeviceLogOption { get; set; }
            public List<Amazon.IoTWireless.Model.WirelessGatewayLogOption> WirelessGatewayLogOption { get; set; }
            public System.Func<Amazon.IoTWireless.Model.UpdateLogLevelsByResourceTypesResponse, UpdateIOTWLogLevelsByResourceTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
