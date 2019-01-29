/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Adds a route to a network to a Client VPN endpoint. Each Client VPN endpoint has a
    /// route table that describes the available destination network routes. Each route in
    /// the route table specifies the path for traﬃc to speciﬁc resources or networks.
    /// </summary>
    [Cmdlet("New", "EC2ClientVpnRoute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ClientVpnRouteStatus")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CreateClientVpnRoute API operation.", Operation = new[] {"CreateClientVpnRoute"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ClientVpnRouteStatus",
        "This cmdlet returns a ClientVpnRouteStatus object.",
        "The service call response (type Amazon.EC2.Model.CreateClientVpnRouteResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2ClientVpnRouteCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter ClientVpnEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the Client VPN endpoint to which to add the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ClientVpnEndpointId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A brief description of the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DestinationCidrBlock
        /// <summary>
        /// <para>
        /// <para>The IPv4 address range, in CIDR notation, of the route destination. For example:</para><ul><li><para>To add a route for Internet access, enter <code>0.0.0.0/0</code></para></li><li><para>To add a route for a peered VPC, enter the peered VPC's IPv4 CIDR range</para></li><li><para>To add a route for an on-premises network, enter the AWS Site-to-Site VPN connection's
        /// IPv4 CIDR range</para></li></ul><para>Route address ranges cannot overlap with the CIDR range specified for client allocation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationCidrBlock { get; set; }
        #endregion
        
        #region Parameter TargetVpcSubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet through which you want to route traffic. The specified subnet
        /// must be an existing target network of the Client VPN endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetVpcSubnetId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClientVpnEndpointId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2ClientVpnRoute (CreateClientVpnRoute)"))
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
            
            context.ClientVpnEndpointId = this.ClientVpnEndpointId;
            context.Description = this.Description;
            context.DestinationCidrBlock = this.DestinationCidrBlock;
            context.TargetVpcSubnetId = this.TargetVpcSubnetId;
            
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
            var request = new Amazon.EC2.Model.CreateClientVpnRouteRequest();
            
            if (cmdletContext.ClientVpnEndpointId != null)
            {
                request.ClientVpnEndpointId = cmdletContext.ClientVpnEndpointId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DestinationCidrBlock != null)
            {
                request.DestinationCidrBlock = cmdletContext.DestinationCidrBlock;
            }
            if (cmdletContext.TargetVpcSubnetId != null)
            {
                request.TargetVpcSubnetId = cmdletContext.TargetVpcSubnetId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Status;
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
        
        private Amazon.EC2.Model.CreateClientVpnRouteResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateClientVpnRouteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateClientVpnRoute");
            try
            {
                #if DESKTOP
                return client.CreateClientVpnRoute(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateClientVpnRouteAsync(request);
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
            public System.String ClientVpnEndpointId { get; set; }
            public System.String Description { get; set; }
            public System.String DestinationCidrBlock { get; set; }
            public System.String TargetVpcSubnetId { get; set; }
        }
        
    }
}
