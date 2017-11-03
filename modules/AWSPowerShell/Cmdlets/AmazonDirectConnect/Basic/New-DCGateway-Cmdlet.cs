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
    /// Creates a new direct connect gateway. A direct connect gateway is an intermediate
    /// object that enables you to connect a set of virtual interfaces and virtual private
    /// gateways. direct connect gateways are global and visible in any AWS region after they
    /// are created. The virtual interfaces and virtual private gateways that are connected
    /// through a direct connect gateway can be in different regions. This enables you to
    /// connect to a VPC in any region, regardless of the region in which the virtual interfaces
    /// are located, and pass traffic between them.
    /// </summary>
    [Cmdlet("New", "DCGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.DirectConnectGateway")]
    [AWSCmdlet("Invokes the CreateDirectConnectGateway operation against AWS Direct Connect.", Operation = new[] {"CreateDirectConnectGateway"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.DirectConnectGateway",
        "This cmdlet returns a DirectConnectGateway object.",
        "The service call response (type Amazon.DirectConnect.Model.CreateDirectConnectGatewayResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDCGatewayCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter AmazonSideAsn
        /// <summary>
        /// <para>
        /// <para>The autonomous system number (ASN) for Border Gateway Protocol (BGP) to be configured
        /// on the Amazon side of the connection. The ASN must be in the private range of 64,512
        /// to 65,534 or 4,200,000,000 to 4,294,967,294 </para><para>Example: 65200</para><para>Default: 64512</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 AmazonSideAsn { get; set; }
        #endregion
        
        #region Parameter DirectConnectGatewayName
        /// <summary>
        /// <para>
        /// <para>The name of the direct connect gateway.</para><para>Example: "My direct connect gateway"</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectConnectGatewayName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DirectConnectGatewayName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCGateway (CreateDirectConnectGateway)"))
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
            
            if (ParameterWasBound("AmazonSideAsn"))
                context.AmazonSideAsn = this.AmazonSideAsn;
            context.DirectConnectGatewayName = this.DirectConnectGatewayName;
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DirectConnectGateway;
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
        
        private Amazon.DirectConnect.Model.CreateDirectConnectGatewayResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreateDirectConnectGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "CreateDirectConnectGateway");
            try
            {
                #if DESKTOP
                return client.CreateDirectConnectGateway(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateDirectConnectGatewayAsync(request);
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
            public System.Int64? AmazonSideAsn { get; set; }
            public System.String DirectConnectGatewayName { get; set; }
        }
        
    }
}
