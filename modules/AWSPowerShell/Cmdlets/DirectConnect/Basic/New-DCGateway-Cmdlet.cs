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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Creates a Direct Connect gateway, which is an intermediate object that enables you
    /// to connect a set of virtual interfaces and virtual private gateways. A Direct Connect
    /// gateway is global and visible in any Amazon Web Services Region after it is created.
    /// The virtual interfaces and virtual private gateways that are connected through a Direct
    /// Connect gateway can be in different Amazon Web Services Regions. This enables you
    /// to connect to a VPC in any Region, regardless of the Region in which the virtual interfaces
    /// are located, and pass traffic between them.
    /// </summary>
    [Cmdlet("New", "DCGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.DirectConnectGateway")]
    [AWSCmdlet("Calls the AWS Direct Connect CreateDirectConnectGateway API operation.", Operation = new[] {"CreateDirectConnectGateway"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.CreateDirectConnectGatewayResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.DirectConnectGateway or Amazon.DirectConnect.Model.CreateDirectConnectGatewayResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.DirectConnectGateway object.",
        "The service call response (type Amazon.DirectConnect.Model.CreateDirectConnectGatewayResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDCGatewayCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter AmazonSideAsn
        /// <summary>
        /// <para>
        /// <para>The autonomous system number (ASN) for Border Gateway Protocol (BGP) to be configured
        /// on the Amazon side of the connection. The ASN must be in the private range of 64,512
        /// to 65,534 or 4,200,000,000 to 4,294,967,294. The default is 64512.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? AmazonSideAsn { get; set; }
        #endregion
        
        #region Parameter DirectConnectGatewayName
        /// <summary>
        /// <para>
        /// <para>The name of the Direct Connect gateway.</para>
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
        public System.String DirectConnectGatewayName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DirectConnectGateway'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.CreateDirectConnectGatewayResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.CreateDirectConnectGatewayResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DirectConnectGateway";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DirectConnectGatewayName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DirectConnectGatewayName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DirectConnectGatewayName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DirectConnectGatewayName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCGateway (CreateDirectConnectGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.CreateDirectConnectGatewayResponse, NewDCGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DirectConnectGatewayName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AmazonSideAsn = this.AmazonSideAsn;
            context.DirectConnectGatewayName = this.DirectConnectGatewayName;
            #if MODULAR
            if (this.DirectConnectGatewayName == null && ParameterWasBound(nameof(this.DirectConnectGatewayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectConnectGatewayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectConnect.Model.CreateDirectConnectGatewayRequest();
            
            if (cmdletContext.AmazonSideAsn != null)
            {
                request.AmazonSideAsn = cmdletContext.AmazonSideAsn.Value;
            }
            if (cmdletContext.DirectConnectGatewayName != null)
            {
                request.DirectConnectGatewayName = cmdletContext.DirectConnectGatewayName;
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
        
        private Amazon.DirectConnect.Model.CreateDirectConnectGatewayResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreateDirectConnectGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "CreateDirectConnectGateway");
            try
            {
                #if DESKTOP
                return client.CreateDirectConnectGateway(request);
                #elif CORECLR
                return client.CreateDirectConnectGatewayAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? AmazonSideAsn { get; set; }
            public System.String DirectConnectGatewayName { get; set; }
            public System.Func<Amazon.DirectConnect.Model.CreateDirectConnectGatewayResponse, NewDCGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DirectConnectGateway;
        }
        
    }
}
