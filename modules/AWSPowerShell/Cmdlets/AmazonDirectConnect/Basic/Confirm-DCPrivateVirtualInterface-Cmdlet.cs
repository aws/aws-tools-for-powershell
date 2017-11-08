/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Accept ownership of a private virtual interface created by another customer.
    /// 
    ///  
    /// <para>
    /// After the virtual interface owner calls this function, the virtual interface will
    /// be created and attached to the given virtual private gateway or direct connect gateway,
    /// and will be available for handling traffic.
    /// </para>
    /// </summary>
    [Cmdlet("Confirm", "DCPrivateVirtualInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.VirtualInterfaceState")]
    [AWSCmdlet("Calls the AWS Direct Connect ConfirmPrivateVirtualInterface API operation.", Operation = new[] {"ConfirmPrivateVirtualInterface"})]
    [AWSCmdletOutput("Amazon.DirectConnect.VirtualInterfaceState",
        "This cmdlet returns a VirtualInterfaceState object.",
        "The service call response (type Amazon.DirectConnect.Model.ConfirmPrivateVirtualInterfaceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ConfirmDCPrivateVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter DirectConnectGatewayId
        /// <summary>
        /// <para>
        /// <para>ID of the direct connect gateway that will be attached to the virtual interface.</para><para> A direct connect gateway can be managed via the AWS Direct Connect console or the
        /// <a>CreateDirectConnectGateway</a> action.</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DirectConnectGatewayId { get; set; }
        #endregion
        
        #region Parameter VirtualGatewayId
        /// <summary>
        /// <para>
        /// <para>ID of the virtual private gateway that will be attached to the virtual interface.</para><para> A virtual private gateway can be managed via the Amazon Virtual Private Cloud (VPC)
        /// console or the <a href="http://docs.aws.amazon.com/AWSEC2/latest/APIReference/ApiReference-query-CreateVpnGateway.html">EC2
        /// CreateVpnGateway</a> action.</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String VirtualGatewayId { get; set; }
        #endregion
        
        #region Parameter VirtualInterfaceId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String VirtualInterfaceId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VirtualInterfaceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Confirm-DCPrivateVirtualInterface (ConfirmPrivateVirtualInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DirectConnectGatewayId = this.DirectConnectGatewayId;
            context.VirtualGatewayId = this.VirtualGatewayId;
            context.VirtualInterfaceId = this.VirtualInterfaceId;
            
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
            var request = new Amazon.DirectConnect.Model.ConfirmPrivateVirtualInterfaceRequest();
            
            if (cmdletContext.DirectConnectGatewayId != null)
            {
                request.DirectConnectGatewayId = cmdletContext.DirectConnectGatewayId;
            }
            if (cmdletContext.VirtualGatewayId != null)
            {
                request.VirtualGatewayId = cmdletContext.VirtualGatewayId;
            }
            if (cmdletContext.VirtualInterfaceId != null)
            {
                request.VirtualInterfaceId = cmdletContext.VirtualInterfaceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.VirtualInterfaceState;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.DirectConnect.Model.ConfirmPrivateVirtualInterfaceResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.ConfirmPrivateVirtualInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "ConfirmPrivateVirtualInterface");
            try
            {
                #if DESKTOP
                return client.ConfirmPrivateVirtualInterface(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ConfirmPrivateVirtualInterfaceAsync(request);
                return task.Result;
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
            public System.String DirectConnectGatewayId { get; set; }
            public System.String VirtualGatewayId { get; set; }
            public System.String VirtualInterfaceId { get; set; }
        }
        
    }
}
