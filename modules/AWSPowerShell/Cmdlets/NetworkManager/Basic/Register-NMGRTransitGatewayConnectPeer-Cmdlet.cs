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
using Amazon.NetworkManager;
using Amazon.NetworkManager.Model;

namespace Amazon.PowerShell.Cmdlets.NMGR
{
    /// <summary>
    /// Associates a transit gateway Connect peer with a device, and optionally, with a link.
    /// If you specify a link, it must be associated with the specified device. 
    /// 
    ///  
    /// <para>
    /// You can only associate transit gateway Connect peers that have been created on a transit
    /// gateway that's registered in your global network.
    /// </para><para>
    /// You cannot associate a transit gateway Connect peer with more than one device and
    /// link. 
    /// </para>
    /// </summary>
    [Cmdlet("Register", "NMGRTransitGatewayConnectPeer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkManager.Model.TransitGatewayConnectPeerAssociation")]
    [AWSCmdlet("Calls the AWS Network Manager AssociateTransitGatewayConnectPeer API operation.", Operation = new[] {"AssociateTransitGatewayConnectPeer"}, SelectReturnType = typeof(Amazon.NetworkManager.Model.AssociateTransitGatewayConnectPeerResponse))]
    [AWSCmdletOutput("Amazon.NetworkManager.Model.TransitGatewayConnectPeerAssociation or Amazon.NetworkManager.Model.AssociateTransitGatewayConnectPeerResponse",
        "This cmdlet returns an Amazon.NetworkManager.Model.TransitGatewayConnectPeerAssociation object.",
        "The service call response (type Amazon.NetworkManager.Model.AssociateTransitGatewayConnectPeerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterNMGRTransitGatewayConnectPeerCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeviceId
        /// <summary>
        /// <para>
        /// <para>The ID of the device.</para>
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
        public System.String DeviceId { get; set; }
        #endregion
        
        #region Parameter GlobalNetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the global network.</para>
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
        public System.String GlobalNetworkId { get; set; }
        #endregion
        
        #region Parameter LinkId
        /// <summary>
        /// <para>
        /// <para>The ID of the link.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LinkId { get; set; }
        #endregion
        
        #region Parameter TransitGatewayConnectPeerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Connect peer.</para>
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
        public System.String TransitGatewayConnectPeerArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransitGatewayConnectPeerAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkManager.Model.AssociateTransitGatewayConnectPeerResponse).
        /// Specifying the name of a property of type Amazon.NetworkManager.Model.AssociateTransitGatewayConnectPeerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransitGatewayConnectPeerAssociation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransitGatewayConnectPeerArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-NMGRTransitGatewayConnectPeer (AssociateTransitGatewayConnectPeer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.AssociateTransitGatewayConnectPeerResponse, RegisterNMGRTransitGatewayConnectPeerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeviceId = this.DeviceId;
            #if MODULAR
            if (this.DeviceId == null && ParameterWasBound(nameof(this.DeviceId)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GlobalNetworkId = this.GlobalNetworkId;
            #if MODULAR
            if (this.GlobalNetworkId == null && ParameterWasBound(nameof(this.GlobalNetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalNetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LinkId = this.LinkId;
            context.TransitGatewayConnectPeerArn = this.TransitGatewayConnectPeerArn;
            #if MODULAR
            if (this.TransitGatewayConnectPeerArn == null && ParameterWasBound(nameof(this.TransitGatewayConnectPeerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TransitGatewayConnectPeerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkManager.Model.AssociateTransitGatewayConnectPeerRequest();
            
            if (cmdletContext.DeviceId != null)
            {
                request.DeviceId = cmdletContext.DeviceId;
            }
            if (cmdletContext.GlobalNetworkId != null)
            {
                request.GlobalNetworkId = cmdletContext.GlobalNetworkId;
            }
            if (cmdletContext.LinkId != null)
            {
                request.LinkId = cmdletContext.LinkId;
            }
            if (cmdletContext.TransitGatewayConnectPeerArn != null)
            {
                request.TransitGatewayConnectPeerArn = cmdletContext.TransitGatewayConnectPeerArn;
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
        
        private Amazon.NetworkManager.Model.AssociateTransitGatewayConnectPeerResponse CallAWSServiceOperation(IAmazonNetworkManager client, Amazon.NetworkManager.Model.AssociateTransitGatewayConnectPeerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Manager", "AssociateTransitGatewayConnectPeer");
            try
            {
                #if DESKTOP
                return client.AssociateTransitGatewayConnectPeer(request);
                #elif CORECLR
                return client.AssociateTransitGatewayConnectPeerAsync(request).GetAwaiter().GetResult();
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
            public System.String DeviceId { get; set; }
            public System.String GlobalNetworkId { get; set; }
            public System.String LinkId { get; set; }
            public System.String TransitGatewayConnectPeerArn { get; set; }
            public System.Func<Amazon.NetworkManager.Model.AssociateTransitGatewayConnectPeerResponse, RegisterNMGRTransitGatewayConnectPeerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitGatewayConnectPeerAssociation;
        }
        
    }
}
