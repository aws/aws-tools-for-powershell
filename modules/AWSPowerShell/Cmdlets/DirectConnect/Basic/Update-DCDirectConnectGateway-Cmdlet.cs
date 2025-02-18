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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Updates the name of a current Direct Connect gateway.
    /// </summary>
    [Cmdlet("Update", "DCDirectConnectGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.DirectConnectGateway")]
    [AWSCmdlet("Calls the AWS Direct Connect UpdateDirectConnectGateway API operation.", Operation = new[] {"UpdateDirectConnectGateway"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.UpdateDirectConnectGatewayResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.DirectConnectGateway or Amazon.DirectConnect.Model.UpdateDirectConnectGatewayResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.DirectConnectGateway object.",
        "The service call response (type Amazon.DirectConnect.Model.UpdateDirectConnectGatewayResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateDCDirectConnectGatewayCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DirectConnectGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the Direct Connect gateway to update.</para>
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
        public System.String DirectConnectGatewayId { get; set; }
        #endregion
        
        #region Parameter NewDirectConnectGatewayName
        /// <summary>
        /// <para>
        /// <para>The new name for the Direct Connect gateway.</para>
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
        public System.String NewDirectConnectGatewayName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DirectConnectGateway'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.UpdateDirectConnectGatewayResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.UpdateDirectConnectGatewayResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DirectConnectGateway";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DCDirectConnectGateway (UpdateDirectConnectGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.UpdateDirectConnectGatewayResponse, UpdateDCDirectConnectGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DirectConnectGatewayId = this.DirectConnectGatewayId;
            #if MODULAR
            if (this.DirectConnectGatewayId == null && ParameterWasBound(nameof(this.DirectConnectGatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectConnectGatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewDirectConnectGatewayName = this.NewDirectConnectGatewayName;
            #if MODULAR
            if (this.NewDirectConnectGatewayName == null && ParameterWasBound(nameof(this.NewDirectConnectGatewayName)))
            {
                WriteWarning("You are passing $null as a value for parameter NewDirectConnectGatewayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectConnect.Model.UpdateDirectConnectGatewayRequest();
            
            if (cmdletContext.DirectConnectGatewayId != null)
            {
                request.DirectConnectGatewayId = cmdletContext.DirectConnectGatewayId;
            }
            if (cmdletContext.NewDirectConnectGatewayName != null)
            {
                request.NewDirectConnectGatewayName = cmdletContext.NewDirectConnectGatewayName;
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
        
        private Amazon.DirectConnect.Model.UpdateDirectConnectGatewayResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.UpdateDirectConnectGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "UpdateDirectConnectGateway");
            try
            {
                return client.UpdateDirectConnectGatewayAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DirectConnectGatewayId { get; set; }
            public System.String NewDirectConnectGatewayName { get; set; }
            public System.Func<Amazon.DirectConnect.Model.UpdateDirectConnectGatewayResponse, UpdateDCDirectConnectGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DirectConnectGateway;
        }
        
    }
}
