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
    /// Registers sources (network interfaces) with the specified transit gateway multicast
    /// group.
    /// 
    ///  
    /// <para>
    /// A multicast source is a network interface attached to a supported instance that sends
    /// multicast traffic. For more information about supported instances, see <a href="https://docs.aws.amazon.com/vpc/latest/tgw/tgw-multicast-overview.html">Multicast
    /// on transit gateways</a> in the <i>Amazon Web Services Transit Gateways Guide</i>.
    /// </para><para>
    /// After you add the source, use <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_SearchTransitGatewayMulticastGroups.html">SearchTransitGatewayMulticastGroups</a>
    /// to verify that the source was added to the multicast group.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "EC2TransitGatewayMulticastGroupSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TransitGatewayMulticastRegisteredGroupSources")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) RegisterTransitGatewayMulticastGroupSources API operation.", Operation = new[] {"RegisterTransitGatewayMulticastGroupSources"}, SelectReturnType = typeof(Amazon.EC2.Model.RegisterTransitGatewayMulticastGroupSourcesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayMulticastRegisteredGroupSources or Amazon.EC2.Model.RegisterTransitGatewayMulticastGroupSourcesResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGatewayMulticastRegisteredGroupSources object.",
        "The service call response (type Amazon.EC2.Model.RegisterTransitGatewayMulticastGroupSourcesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterEC2TransitGatewayMulticastGroupSourceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// <para>The group sources' network interface IDs to register with the transit gateway multicast
        /// group.</para>
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
        [Alias("NetworkInterfaceIds")]
        public System.String[] NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter TransitGatewayMulticastDomainId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway multicast domain.</para>
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
        public System.String TransitGatewayMulticastDomainId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RegisteredMulticastGroupSources'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.RegisterTransitGatewayMulticastGroupSourcesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.RegisterTransitGatewayMulticastGroupSourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RegisteredMulticastGroupSources";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransitGatewayMulticastDomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2TransitGatewayMulticastGroupSource (RegisterTransitGatewayMulticastGroupSources)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.RegisterTransitGatewayMulticastGroupSourcesResponse, RegisterEC2TransitGatewayMulticastGroupSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GroupIpAddress = this.GroupIpAddress;
            if (this.NetworkInterfaceId != null)
            {
                context.NetworkInterfaceId = new List<System.String>(this.NetworkInterfaceId);
            }
            #if MODULAR
            if (this.NetworkInterfaceId == null && ParameterWasBound(nameof(this.NetworkInterfaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkInterfaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransitGatewayMulticastDomainId = this.TransitGatewayMulticastDomainId;
            #if MODULAR
            if (this.TransitGatewayMulticastDomainId == null && ParameterWasBound(nameof(this.TransitGatewayMulticastDomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransitGatewayMulticastDomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.RegisterTransitGatewayMulticastGroupSourcesRequest();
            
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
        
        private Amazon.EC2.Model.RegisterTransitGatewayMulticastGroupSourcesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.RegisterTransitGatewayMulticastGroupSourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "RegisterTransitGatewayMulticastGroupSources");
            try
            {
                #if DESKTOP
                return client.RegisterTransitGatewayMulticastGroupSources(request);
                #elif CORECLR
                return client.RegisterTransitGatewayMulticastGroupSourcesAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.EC2.Model.RegisterTransitGatewayMulticastGroupSourcesResponse, RegisterEC2TransitGatewayMulticastGroupSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RegisteredMulticastGroupSources;
        }
        
    }
}
