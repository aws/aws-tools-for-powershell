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
using Amazon.GreengrassV2;
using Amazon.GreengrassV2.Model;

namespace Amazon.PowerShell.Cmdlets.GGV2
{
    /// <summary>
    /// Retrieves connectivity information for a Greengrass core device.
    /// 
    ///  
    /// <para>
    /// Connectivity information includes endpoints and ports where client devices can connect
    /// to an MQTT broker on the core device. When a client device calls the <a href="https://docs.aws.amazon.com/greengrass/v2/developerguide/greengrass-discover-api.html">IoT
    /// Greengrass discovery API</a>, IoT Greengrass returns connectivity information for
    /// all of the core devices where the client device can connect. For more information,
    /// see <a href="https://docs.aws.amazon.com/greengrass/v2/developerguide/connect-client-devices.html">Connect
    /// client devices to core devices</a> in the <i>IoT Greengrass Version 2 Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "GGV2ConnectivityInfo")]
    [OutputType("Amazon.GreengrassV2.Model.GetConnectivityInfoResponse")]
    [AWSCmdlet("Calls the AWS GreengrassV2 GetConnectivityInfo API operation.", Operation = new[] {"GetConnectivityInfo"}, SelectReturnType = typeof(Amazon.GreengrassV2.Model.GetConnectivityInfoResponse))]
    [AWSCmdletOutput("Amazon.GreengrassV2.Model.GetConnectivityInfoResponse",
        "This cmdlet returns an Amazon.GreengrassV2.Model.GetConnectivityInfoResponse object containing multiple properties."
    )]
    public partial class GetGGV2ConnectivityInfoCmdlet : AmazonGreengrassV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ThingName
        /// <summary>
        /// <para>
        /// <para>The name of the core device. This is also the name of the IoT thing.</para>
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
        public System.String ThingName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GreengrassV2.Model.GetConnectivityInfoResponse).
        /// Specifying the name of a property of type Amazon.GreengrassV2.Model.GetConnectivityInfoResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ThingName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ThingName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ThingName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.GreengrassV2.Model.GetConnectivityInfoResponse, GetGGV2ConnectivityInfoCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ThingName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ThingName = this.ThingName;
            #if MODULAR
            if (this.ThingName == null && ParameterWasBound(nameof(this.ThingName)))
            {
                WriteWarning("You are passing $null as a value for parameter ThingName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GreengrassV2.Model.GetConnectivityInfoRequest();
            
            if (cmdletContext.ThingName != null)
            {
                request.ThingName = cmdletContext.ThingName;
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
        
        private Amazon.GreengrassV2.Model.GetConnectivityInfoResponse CallAWSServiceOperation(IAmazonGreengrassV2 client, Amazon.GreengrassV2.Model.GetConnectivityInfoRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS GreengrassV2", "GetConnectivityInfo");
            try
            {
                #if DESKTOP
                return client.GetConnectivityInfo(request);
                #elif CORECLR
                return client.GetConnectivityInfoAsync(request).GetAwaiter().GetResult();
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
            public System.String ThingName { get; set; }
            public System.Func<Amazon.GreengrassV2.Model.GetConnectivityInfoResponse, GetGGV2ConnectivityInfoCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
