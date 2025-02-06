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
using Amazon.GreengrassV2;
using Amazon.GreengrassV2.Model;

namespace Amazon.PowerShell.Cmdlets.GGV2
{
    /// <summary>
    /// Updates connectivity information for a Greengrass core device.
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
    [Cmdlet("Update", "GGV2ConnectivityInfo", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GreengrassV2.Model.UpdateConnectivityInfoResponse")]
    [AWSCmdlet("Calls the AWS GreengrassV2 UpdateConnectivityInfo API operation.", Operation = new[] {"UpdateConnectivityInfo"}, SelectReturnType = typeof(Amazon.GreengrassV2.Model.UpdateConnectivityInfoResponse))]
    [AWSCmdletOutput("Amazon.GreengrassV2.Model.UpdateConnectivityInfoResponse",
        "This cmdlet returns an Amazon.GreengrassV2.Model.UpdateConnectivityInfoResponse object containing multiple properties."
    )]
    public partial class UpdateGGV2ConnectivityInfoCmdlet : AmazonGreengrassV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectivityInfo
        /// <summary>
        /// <para>
        /// <para>The connectivity information for the core device.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.GreengrassV2.Model.ConnectivityInfo[] ConnectivityInfo { get; set; }
        #endregion
        
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GreengrassV2.Model.UpdateConnectivityInfoResponse).
        /// Specifying the name of a property of type Amazon.GreengrassV2.Model.UpdateConnectivityInfoResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ThingName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GGV2ConnectivityInfo (UpdateConnectivityInfo)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GreengrassV2.Model.UpdateConnectivityInfoResponse, UpdateGGV2ConnectivityInfoCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ConnectivityInfo != null)
            {
                context.ConnectivityInfo = new List<Amazon.GreengrassV2.Model.ConnectivityInfo>(this.ConnectivityInfo);
            }
            #if MODULAR
            if (this.ConnectivityInfo == null && ParameterWasBound(nameof(this.ConnectivityInfo)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectivityInfo which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.GreengrassV2.Model.UpdateConnectivityInfoRequest();
            
            if (cmdletContext.ConnectivityInfo != null)
            {
                request.ConnectivityInfo = cmdletContext.ConnectivityInfo;
            }
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
        
        private Amazon.GreengrassV2.Model.UpdateConnectivityInfoResponse CallAWSServiceOperation(IAmazonGreengrassV2 client, Amazon.GreengrassV2.Model.UpdateConnectivityInfoRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS GreengrassV2", "UpdateConnectivityInfo");
            try
            {
                #if DESKTOP
                return client.UpdateConnectivityInfo(request);
                #elif CORECLR
                return client.UpdateConnectivityInfoAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.GreengrassV2.Model.ConnectivityInfo> ConnectivityInfo { get; set; }
            public System.String ThingName { get; set; }
            public System.Func<Amazon.GreengrassV2.Model.UpdateConnectivityInfoResponse, UpdateGGV2ConnectivityInfoCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
