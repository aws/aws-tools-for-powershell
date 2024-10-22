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
using Amazon.IoTSecureTunneling;
using Amazon.IoTSecureTunneling.Model;

namespace Amazon.PowerShell.Cmdlets.IOTST
{
    /// <summary>
    /// Creates a new tunnel, and returns two client access tokens for clients to use to connect
    /// to the IoT Secure Tunneling proxy server.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">OpenTunnel</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Open", "IOTSTTunnel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSecureTunneling.Model.OpenTunnelResponse")]
    [AWSCmdlet("Calls the AWS IoT Secure Tunneling OpenTunnel API operation.", Operation = new[] {"OpenTunnel"}, SelectReturnType = typeof(Amazon.IoTSecureTunneling.Model.OpenTunnelResponse))]
    [AWSCmdletOutput("Amazon.IoTSecureTunneling.Model.OpenTunnelResponse",
        "This cmdlet returns an Amazon.IoTSecureTunneling.Model.OpenTunnelResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class OpenIOTSTTunnelCmdlet : AmazonIoTSecureTunnelingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A short text description of the tunnel. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter TimeoutConfig_MaxLifetimeTimeoutMinute
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time (in minutes) a tunnel can remain open. If not specified,
        /// maxLifetimeTimeoutMinutes defaults to 720 minutes. Valid values are from 1 minute
        /// to 12 hours (720 minutes) </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutConfig_MaxLifetimeTimeoutMinutes")]
        public System.Int32? TimeoutConfig_MaxLifetimeTimeoutMinute { get; set; }
        #endregion
        
        #region Parameter DestinationConfig_Service
        /// <summary>
        /// <para>
        /// <para>A list of service names that identify the target application. The IoT client running
        /// on the destination device reads this value and uses it to look up a port or an IP
        /// address and a port. The IoT client instantiates the local proxy, which uses this information
        /// to connect to the destination application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfig_Services")]
        public System.String[] DestinationConfig_Service { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A collection of tag metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoTSecureTunneling.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter DestinationConfig_ThingName
        /// <summary>
        /// <para>
        /// <para>The name of the IoT thing to which you want to connect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DestinationConfig_ThingName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSecureTunneling.Model.OpenTunnelResponse).
        /// Specifying the name of a property of type Amazon.IoTSecureTunneling.Model.OpenTunnelResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DestinationConfig_ThingName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Open-IOTSTTunnel (OpenTunnel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSecureTunneling.Model.OpenTunnelResponse, OpenIOTSTTunnelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            if (this.DestinationConfig_Service != null)
            {
                context.DestinationConfig_Service = new List<System.String>(this.DestinationConfig_Service);
            }
            context.DestinationConfig_ThingName = this.DestinationConfig_ThingName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoTSecureTunneling.Model.Tag>(this.Tag);
            }
            context.TimeoutConfig_MaxLifetimeTimeoutMinute = this.TimeoutConfig_MaxLifetimeTimeoutMinute;
            
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
            var request = new Amazon.IoTSecureTunneling.Model.OpenTunnelRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate DestinationConfig
            var requestDestinationConfigIsNull = true;
            request.DestinationConfig = new Amazon.IoTSecureTunneling.Model.DestinationConfig();
            List<System.String> requestDestinationConfig_destinationConfig_Service = null;
            if (cmdletContext.DestinationConfig_Service != null)
            {
                requestDestinationConfig_destinationConfig_Service = cmdletContext.DestinationConfig_Service;
            }
            if (requestDestinationConfig_destinationConfig_Service != null)
            {
                request.DestinationConfig.Services = requestDestinationConfig_destinationConfig_Service;
                requestDestinationConfigIsNull = false;
            }
            System.String requestDestinationConfig_destinationConfig_ThingName = null;
            if (cmdletContext.DestinationConfig_ThingName != null)
            {
                requestDestinationConfig_destinationConfig_ThingName = cmdletContext.DestinationConfig_ThingName;
            }
            if (requestDestinationConfig_destinationConfig_ThingName != null)
            {
                request.DestinationConfig.ThingName = requestDestinationConfig_destinationConfig_ThingName;
                requestDestinationConfigIsNull = false;
            }
             // determine if request.DestinationConfig should be set to null
            if (requestDestinationConfigIsNull)
            {
                request.DestinationConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TimeoutConfig
            var requestTimeoutConfigIsNull = true;
            request.TimeoutConfig = new Amazon.IoTSecureTunneling.Model.TimeoutConfig();
            System.Int32? requestTimeoutConfig_timeoutConfig_MaxLifetimeTimeoutMinute = null;
            if (cmdletContext.TimeoutConfig_MaxLifetimeTimeoutMinute != null)
            {
                requestTimeoutConfig_timeoutConfig_MaxLifetimeTimeoutMinute = cmdletContext.TimeoutConfig_MaxLifetimeTimeoutMinute.Value;
            }
            if (requestTimeoutConfig_timeoutConfig_MaxLifetimeTimeoutMinute != null)
            {
                request.TimeoutConfig.MaxLifetimeTimeoutMinutes = requestTimeoutConfig_timeoutConfig_MaxLifetimeTimeoutMinute.Value;
                requestTimeoutConfigIsNull = false;
            }
             // determine if request.TimeoutConfig should be set to null
            if (requestTimeoutConfigIsNull)
            {
                request.TimeoutConfig = null;
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
        
        private Amazon.IoTSecureTunneling.Model.OpenTunnelResponse CallAWSServiceOperation(IAmazonIoTSecureTunneling client, Amazon.IoTSecureTunneling.Model.OpenTunnelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Secure Tunneling", "OpenTunnel");
            try
            {
                #if DESKTOP
                return client.OpenTunnel(request);
                #elif CORECLR
                return client.OpenTunnelAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public List<System.String> DestinationConfig_Service { get; set; }
            public System.String DestinationConfig_ThingName { get; set; }
            public List<Amazon.IoTSecureTunneling.Model.Tag> Tag { get; set; }
            public System.Int32? TimeoutConfig_MaxLifetimeTimeoutMinute { get; set; }
            public System.Func<Amazon.IoTSecureTunneling.Model.OpenTunnelResponse, OpenIOTSTTunnelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
