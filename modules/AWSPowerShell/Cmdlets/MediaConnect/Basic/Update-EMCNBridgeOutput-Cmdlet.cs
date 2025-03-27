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
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// Updates an existing bridge output.
    /// </summary>
    [Cmdlet("Update", "EMCNBridgeOutput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.UpdateBridgeOutputResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect UpdateBridgeOutput API operation.", Operation = new[] {"UpdateBridgeOutput"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.UpdateBridgeOutputResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.UpdateBridgeOutputResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.UpdateBridgeOutputResponse object containing multiple properties."
    )]
    public partial class UpdateEMCNBridgeOutputCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BridgeArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the bridge that you want to update.</para>
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
        public System.String BridgeArn { get; set; }
        #endregion
        
        #region Parameter NetworkOutput_IpAddress
        /// <summary>
        /// <para>
        /// <para>The network output IP Address. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkOutput_IpAddress { get; set; }
        #endregion
        
        #region Parameter NetworkOutput_NetworkName
        /// <summary>
        /// <para>
        /// <para>The network output's gateway network name. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkOutput_NetworkName { get; set; }
        #endregion
        
        #region Parameter OutputName
        /// <summary>
        /// <para>
        /// <para> Tname of the output that you want to update. </para>
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
        public System.String OutputName { get; set; }
        #endregion
        
        #region Parameter NetworkOutput_Port
        /// <summary>
        /// <para>
        /// <para>The network output port. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NetworkOutput_Port { get; set; }
        #endregion
        
        #region Parameter NetworkOutput_Protocol
        /// <summary>
        /// <para>
        /// <para>The network output protocol. </para><note><para>Elemental MediaConnect no longer supports the Fujitsu QoS protocol. This reference
        /// is maintained for legacy purposes only.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.Protocol")]
        public Amazon.MediaConnect.Protocol NetworkOutput_Protocol { get; set; }
        #endregion
        
        #region Parameter NetworkOutput_Ttl
        /// <summary>
        /// <para>
        /// <para>The network output TTL. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NetworkOutput_Ttl { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.UpdateBridgeOutputResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.UpdateBridgeOutputResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OutputName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCNBridgeOutput (UpdateBridgeOutput)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.UpdateBridgeOutputResponse, UpdateEMCNBridgeOutputCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BridgeArn = this.BridgeArn;
            #if MODULAR
            if (this.BridgeArn == null && ParameterWasBound(nameof(this.BridgeArn)))
            {
                WriteWarning("You are passing $null as a value for parameter BridgeArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkOutput_IpAddress = this.NetworkOutput_IpAddress;
            context.NetworkOutput_NetworkName = this.NetworkOutput_NetworkName;
            context.NetworkOutput_Port = this.NetworkOutput_Port;
            context.NetworkOutput_Protocol = this.NetworkOutput_Protocol;
            context.NetworkOutput_Ttl = this.NetworkOutput_Ttl;
            context.OutputName = this.OutputName;
            #if MODULAR
            if (this.OutputName == null && ParameterWasBound(nameof(this.OutputName)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaConnect.Model.UpdateBridgeOutputRequest();
            
            if (cmdletContext.BridgeArn != null)
            {
                request.BridgeArn = cmdletContext.BridgeArn;
            }
            
             // populate NetworkOutput
            var requestNetworkOutputIsNull = true;
            request.NetworkOutput = new Amazon.MediaConnect.Model.UpdateBridgeNetworkOutputRequest();
            System.String requestNetworkOutput_networkOutput_IpAddress = null;
            if (cmdletContext.NetworkOutput_IpAddress != null)
            {
                requestNetworkOutput_networkOutput_IpAddress = cmdletContext.NetworkOutput_IpAddress;
            }
            if (requestNetworkOutput_networkOutput_IpAddress != null)
            {
                request.NetworkOutput.IpAddress = requestNetworkOutput_networkOutput_IpAddress;
                requestNetworkOutputIsNull = false;
            }
            System.String requestNetworkOutput_networkOutput_NetworkName = null;
            if (cmdletContext.NetworkOutput_NetworkName != null)
            {
                requestNetworkOutput_networkOutput_NetworkName = cmdletContext.NetworkOutput_NetworkName;
            }
            if (requestNetworkOutput_networkOutput_NetworkName != null)
            {
                request.NetworkOutput.NetworkName = requestNetworkOutput_networkOutput_NetworkName;
                requestNetworkOutputIsNull = false;
            }
            System.Int32? requestNetworkOutput_networkOutput_Port = null;
            if (cmdletContext.NetworkOutput_Port != null)
            {
                requestNetworkOutput_networkOutput_Port = cmdletContext.NetworkOutput_Port.Value;
            }
            if (requestNetworkOutput_networkOutput_Port != null)
            {
                request.NetworkOutput.Port = requestNetworkOutput_networkOutput_Port.Value;
                requestNetworkOutputIsNull = false;
            }
            Amazon.MediaConnect.Protocol requestNetworkOutput_networkOutput_Protocol = null;
            if (cmdletContext.NetworkOutput_Protocol != null)
            {
                requestNetworkOutput_networkOutput_Protocol = cmdletContext.NetworkOutput_Protocol;
            }
            if (requestNetworkOutput_networkOutput_Protocol != null)
            {
                request.NetworkOutput.Protocol = requestNetworkOutput_networkOutput_Protocol;
                requestNetworkOutputIsNull = false;
            }
            System.Int32? requestNetworkOutput_networkOutput_Ttl = null;
            if (cmdletContext.NetworkOutput_Ttl != null)
            {
                requestNetworkOutput_networkOutput_Ttl = cmdletContext.NetworkOutput_Ttl.Value;
            }
            if (requestNetworkOutput_networkOutput_Ttl != null)
            {
                request.NetworkOutput.Ttl = requestNetworkOutput_networkOutput_Ttl.Value;
                requestNetworkOutputIsNull = false;
            }
             // determine if request.NetworkOutput should be set to null
            if (requestNetworkOutputIsNull)
            {
                request.NetworkOutput = null;
            }
            if (cmdletContext.OutputName != null)
            {
                request.OutputName = cmdletContext.OutputName;
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
        
        private Amazon.MediaConnect.Model.UpdateBridgeOutputResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.UpdateBridgeOutputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "UpdateBridgeOutput");
            try
            {
                return client.UpdateBridgeOutputAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BridgeArn { get; set; }
            public System.String NetworkOutput_IpAddress { get; set; }
            public System.String NetworkOutput_NetworkName { get; set; }
            public System.Int32? NetworkOutput_Port { get; set; }
            public Amazon.MediaConnect.Protocol NetworkOutput_Protocol { get; set; }
            public System.Int32? NetworkOutput_Ttl { get; set; }
            public System.String OutputName { get; set; }
            public System.Func<Amazon.MediaConnect.Model.UpdateBridgeOutputResponse, UpdateEMCNBridgeOutputCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
