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
    /// Gets information about a tunnel identified by the unique tunnel id.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">DescribeTunnel</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IOTSTTunnel")]
    [OutputType("Amazon.IoTSecureTunneling.Model.Tunnel")]
    [AWSCmdlet("Calls the AWS IoT Secure Tunneling DescribeTunnel API operation.", Operation = new[] {"DescribeTunnel"}, SelectReturnType = typeof(Amazon.IoTSecureTunneling.Model.DescribeTunnelResponse))]
    [AWSCmdletOutput("Amazon.IoTSecureTunneling.Model.Tunnel or Amazon.IoTSecureTunneling.Model.DescribeTunnelResponse",
        "This cmdlet returns an Amazon.IoTSecureTunneling.Model.Tunnel object.",
        "The service call response (type Amazon.IoTSecureTunneling.Model.DescribeTunnelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTSTTunnelCmdlet : AmazonIoTSecureTunnelingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TunnelId
        /// <summary>
        /// <para>
        /// <para>The tunnel to describe.</para>
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
        public System.String TunnelId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Tunnel'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSecureTunneling.Model.DescribeTunnelResponse).
        /// Specifying the name of a property of type Amazon.IoTSecureTunneling.Model.DescribeTunnelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Tunnel";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSecureTunneling.Model.DescribeTunnelResponse, GetIOTSTTunnelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.IoTSecureTunneling.Model.DescribeTunnelRequest();
            
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
        
        private Amazon.IoTSecureTunneling.Model.DescribeTunnelResponse CallAWSServiceOperation(IAmazonIoTSecureTunneling client, Amazon.IoTSecureTunneling.Model.DescribeTunnelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Secure Tunneling", "DescribeTunnel");
            try
            {
                #if DESKTOP
                return client.DescribeTunnel(request);
                #elif CORECLR
                return client.DescribeTunnelAsync(request).GetAwaiter().GetResult();
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
            public System.String TunnelId { get; set; }
            public System.Func<Amazon.IoTSecureTunneling.Model.DescribeTunnelResponse, GetIOTSTTunnelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Tunnel;
        }
        
    }
}
