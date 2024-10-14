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
    /// Revokes the current client access token (CAT) and returns new CAT for clients to use
    /// when reconnecting to secure tunneling to access the same tunnel.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">RotateTunnelAccessToken</a>
    /// action.
    /// </para><note><para>
    /// Rotating the CAT doesn't extend the tunnel duration. For example, say the tunnel duration
    /// is 12 hours and the tunnel has already been open for 4 hours. When you rotate the
    /// access tokens, the new tokens that are generated can only be used for the remaining
    /// 8 hours.
    /// </para></note>
    /// </summary>
    [Cmdlet("Invoke", "IOTSTTunnelAccessTokenRotation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSecureTunneling.Model.RotateTunnelAccessTokenResponse")]
    [AWSCmdlet("Calls the AWS IoT Secure Tunneling RotateTunnelAccessToken API operation.", Operation = new[] {"RotateTunnelAccessToken"}, SelectReturnType = typeof(Amazon.IoTSecureTunneling.Model.RotateTunnelAccessTokenResponse))]
    [AWSCmdletOutput("Amazon.IoTSecureTunneling.Model.RotateTunnelAccessTokenResponse",
        "This cmdlet returns an Amazon.IoTSecureTunneling.Model.RotateTunnelAccessTokenResponse object containing multiple properties."
    )]
    public partial class InvokeIOTSTTunnelAccessTokenRotationCmdlet : AmazonIoTSecureTunnelingClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientMode
        /// <summary>
        /// <para>
        /// <para>The mode of the client that will use the client token, which can be either the source
        /// or destination, or both source and destination.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTSecureTunneling.ClientMode")]
        public Amazon.IoTSecureTunneling.ClientMode ClientMode { get; set; }
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
        
        #region Parameter DestinationConfig_ThingName
        /// <summary>
        /// <para>
        /// <para>The name of the IoT thing to which you want to connect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationConfig_ThingName { get; set; }
        #endregion
        
        #region Parameter TunnelId
        /// <summary>
        /// <para>
        /// <para>The tunnel for which you want to rotate the access tokens.</para>
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
        public System.String TunnelId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSecureTunneling.Model.RotateTunnelAccessTokenResponse).
        /// Specifying the name of a property of type Amazon.IoTSecureTunneling.Model.RotateTunnelAccessTokenResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TunnelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-IOTSTTunnelAccessTokenRotation (RotateTunnelAccessToken)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSecureTunneling.Model.RotateTunnelAccessTokenResponse, InvokeIOTSTTunnelAccessTokenRotationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientMode = this.ClientMode;
            #if MODULAR
            if (this.ClientMode == null && ParameterWasBound(nameof(this.ClientMode)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DestinationConfig_Service != null)
            {
                context.DestinationConfig_Service = new List<System.String>(this.DestinationConfig_Service);
            }
            context.DestinationConfig_ThingName = this.DestinationConfig_ThingName;
            context.TunnelId = this.TunnelId;
            #if MODULAR
            if (this.TunnelId == null && ParameterWasBound(nameof(this.TunnelId)))
            {
                WriteWarning("You are passing $null as a value for parameter TunnelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTSecureTunneling.Model.RotateTunnelAccessTokenRequest();
            
            if (cmdletContext.ClientMode != null)
            {
                request.ClientMode = cmdletContext.ClientMode;
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
            if (cmdletContext.TunnelId != null)
            {
                request.TunnelId = cmdletContext.TunnelId;
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
        
        private Amazon.IoTSecureTunneling.Model.RotateTunnelAccessTokenResponse CallAWSServiceOperation(IAmazonIoTSecureTunneling client, Amazon.IoTSecureTunneling.Model.RotateTunnelAccessTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Secure Tunneling", "RotateTunnelAccessToken");
            try
            {
                #if DESKTOP
                return client.RotateTunnelAccessToken(request);
                #elif CORECLR
                return client.RotateTunnelAccessTokenAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IoTSecureTunneling.ClientMode ClientMode { get; set; }
            public List<System.String> DestinationConfig_Service { get; set; }
            public System.String DestinationConfig_ThingName { get; set; }
            public System.String TunnelId { get; set; }
            public System.Func<Amazon.IoTSecureTunneling.Model.RotateTunnelAccessTokenResponse, InvokeIOTSTTunnelAccessTokenRotationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
