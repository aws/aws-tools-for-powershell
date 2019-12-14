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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Deregisters the specified sources (network interfaces) from the transit gateway multicast
    /// group.
    /// </summary>
    [Cmdlet("Unregister", "EC2TransitGatewayMulticastGroupSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TransitGatewayMulticastDeregisteredGroupSources")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DeregisterTransitGatewayMulticastGroupSources API operation.", Operation = new[] {"DeregisterTransitGatewayMulticastGroupSources"}, SelectReturnType = typeof(Amazon.EC2.Model.DeregisterTransitGatewayMulticastGroupSourcesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayMulticastDeregisteredGroupSources or Amazon.EC2.Model.DeregisterTransitGatewayMulticastGroupSourcesResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGatewayMulticastDeregisteredGroupSources object.",
        "The service call response (type Amazon.EC2.Model.DeregisterTransitGatewayMulticastGroupSourcesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UnregisterEC2TransitGatewayMulticastGroupSourceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter GroupIpAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the transit gateway multicast group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GroupIpAddress { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The IDs of the group sources' network interfaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkInterfaceIds")]
        public System.String[] NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter TransitGatewayMulticastDomainId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway multicast domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TransitGatewayMulticastDomainId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DeregisteredMulticastGroupSources'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DeregisterTransitGatewayMulticastGroupSourcesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DeregisterTransitGatewayMulticastGroupSourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DeregisteredMulticastGroupSources";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TransitGatewayMulticastDomainId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TransitGatewayMulticastDomainId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TransitGatewayMulticastDomainId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransitGatewayMulticastDomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-EC2TransitGatewayMulticastGroupSource (DeregisterTransitGatewayMulticastGroupSources)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DeregisterTransitGatewayMulticastGroupSourcesResponse, UnregisterEC2TransitGatewayMulticastGroupSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TransitGatewayMulticastDomainId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GroupIpAddress = this.GroupIpAddress;
            if (this.NetworkInterfaceId != null)
            {
                context.NetworkInterfaceId = new List<System.String>(this.NetworkInterfaceId);
            }
            context.TransitGatewayMulticastDomainId = this.TransitGatewayMulticastDomainId;
            
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
            var request = new Amazon.EC2.Model.DeregisterTransitGatewayMulticastGroupSourcesRequest();
            
            if (cmdletContext.GroupIpAddress != null)
            {
                request.GroupIpAddress = cmdletContext.GroupIpAddress;
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceIds = cmdletContext.NetworkInterfaceId;
            }
            if (cmdletContext.TransitGatewayMulticastDomainId != null)
            {
                request.TransitGatewayMulticastDomainId = cmdletContext.TransitGatewayMulticastDomainId;
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
        
        private Amazon.EC2.Model.DeregisterTransitGatewayMulticastGroupSourcesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DeregisterTransitGatewayMulticastGroupSourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DeregisterTransitGatewayMulticastGroupSources");
            try
            {
                #if DESKTOP
                return client.DeregisterTransitGatewayMulticastGroupSources(request);
                #elif CORECLR
                return client.DeregisterTransitGatewayMulticastGroupSourcesAsync(request).GetAwaiter().GetResult();
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
            public System.String GroupIpAddress { get; set; }
            public List<System.String> NetworkInterfaceId { get; set; }
            public System.String TransitGatewayMulticastDomainId { get; set; }
            public System.Func<Amazon.EC2.Model.DeregisterTransitGatewayMulticastGroupSourcesResponse, UnregisterEC2TransitGatewayMulticastGroupSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeregisteredMulticastGroupSources;
        }
        
    }
}
