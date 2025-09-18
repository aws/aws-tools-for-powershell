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
using Amazon.ChimeSDKMessaging;
using Amazon.ChimeSDKMessaging.Model;

namespace Amazon.PowerShell.Cmdlets.CHMMG
{
    /// <summary>
    /// The details of the endpoint for the messaging session.
    /// </summary>
    [Cmdlet("Get", "CHMMGMessagingSessionEndpoint")]
    [OutputType("Amazon.ChimeSDKMessaging.Model.MessagingSessionEndpoint")]
    [AWSCmdlet("Calls the Amazon Chime SDK Messaging GetMessagingSessionEndpoint API operation.", Operation = new[] {"GetMessagingSessionEndpoint"}, SelectReturnType = typeof(Amazon.ChimeSDKMessaging.Model.GetMessagingSessionEndpointResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMessaging.Model.MessagingSessionEndpoint or Amazon.ChimeSDKMessaging.Model.GetMessagingSessionEndpointResponse",
        "This cmdlet returns an Amazon.ChimeSDKMessaging.Model.MessagingSessionEndpoint object.",
        "The service call response (type Amazon.ChimeSDKMessaging.Model.GetMessagingSessionEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCHMMGMessagingSessionEndpointCmdlet : AmazonChimeSDKMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NetworkType
        /// <summary>
        /// <para>
        /// <para>The type of network for the messaging session endpoint. Either IPv4 only or dual-stack
        /// (IPv4 and IPv6).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKMessaging.NetworkType")]
        public Amazon.ChimeSDKMessaging.NetworkType NetworkType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Endpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMessaging.Model.GetMessagingSessionEndpointResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMessaging.Model.GetMessagingSessionEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Endpoint";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NetworkType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NetworkType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NetworkType' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMessaging.Model.GetMessagingSessionEndpointResponse, GetCHMMGMessagingSessionEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NetworkType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.NetworkType = this.NetworkType;
            
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
            var request = new Amazon.ChimeSDKMessaging.Model.GetMessagingSessionEndpointRequest();
            
            if (cmdletContext.NetworkType != null)
            {
                request.NetworkType = cmdletContext.NetworkType;
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
        
        private Amazon.ChimeSDKMessaging.Model.GetMessagingSessionEndpointResponse CallAWSServiceOperation(IAmazonChimeSDKMessaging client, Amazon.ChimeSDKMessaging.Model.GetMessagingSessionEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Messaging", "GetMessagingSessionEndpoint");
            try
            {
                #if DESKTOP
                return client.GetMessagingSessionEndpoint(request);
                #elif CORECLR
                return client.GetMessagingSessionEndpointAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ChimeSDKMessaging.NetworkType NetworkType { get; set; }
            public System.Func<Amazon.ChimeSDKMessaging.Model.GetMessagingSessionEndpointResponse, GetCHMMGMessagingSessionEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Endpoint;
        }
        
    }
}
