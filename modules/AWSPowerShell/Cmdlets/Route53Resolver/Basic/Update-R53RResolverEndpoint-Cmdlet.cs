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
using Amazon.Route53Resolver;
using Amazon.Route53Resolver.Model;

namespace Amazon.PowerShell.Cmdlets.R53R
{
    /// <summary>
    /// Updates the name, or endpoint type for an inbound or an outbound Resolver endpoint.
    /// You can only update between IPV4 and DUALSTACK, IPV6 endpoint type can't be updated
    /// to other type.
    /// </summary>
    [Cmdlet("Update", "R53RResolverEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53Resolver.Model.ResolverEndpoint")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver UpdateResolverEndpoint API operation.", Operation = new[] {"UpdateResolverEndpoint"}, SelectReturnType = typeof(Amazon.Route53Resolver.Model.UpdateResolverEndpointResponse))]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.ResolverEndpoint or Amazon.Route53Resolver.Model.UpdateResolverEndpointResponse",
        "This cmdlet returns an Amazon.Route53Resolver.Model.ResolverEndpoint object.",
        "The service call response (type Amazon.Route53Resolver.Model.UpdateResolverEndpointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateR53RResolverEndpointCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Resolver endpoint that you want to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para> The protocols you want to use for the endpoint. DoH-FIPS is applicable for inbound
        /// endpoints only. </para><para>For an inbound endpoint you can apply the protocols as follows:</para><ul><li><para> Do53 and DoH in combination.</para></li><li><para>Do53 and DoH-FIPS in combination.</para></li><li><para>Do53 alone.</para></li><li><para>DoH alone.</para></li><li><para>DoH-FIPS alone.</para></li><li><para>None, which is treated as Do53.</para></li></ul><para>For an outbound endpoint you can apply the protocols as follows:</para><ul><li><para> Do53 and DoH in combination.</para></li><li><para>Do53 alone.</para></li><li><para>DoH alone.</para></li><li><para>None, which is treated as Do53.</para></li></ul><important><para> You can't change the protocol of an inbound endpoint directly from only Do53 to only
        /// DoH, or DoH-FIPS. This is to prevent a sudden disruption to incoming traffic that
        /// relies on Do53. To change the protocol from Do53 to DoH, or DoH-FIPS, you must first
        /// enable both Do53 and DoH, or Do53 and DoH-FIPS, to make sure that all incoming traffic
        /// has transferred to using the DoH protocol, or DoH-FIPS, and then remove the Do53.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Protocols")]
        public System.String[] Protocol { get; set; }
        #endregion
        
        #region Parameter ResolverEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the Resolver endpoint that you want to update.</para>
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
        public System.String ResolverEndpointId { get; set; }
        #endregion
        
        #region Parameter ResolverEndpointType
        /// <summary>
        /// <para>
        /// <para> Specifies the endpoint type for what type of IP address the endpoint uses to forward
        /// DNS queries. </para><para>Updating to <c>IPV6</c> type isn't currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Resolver.ResolverEndpointType")]
        public Amazon.Route53Resolver.ResolverEndpointType ResolverEndpointType { get; set; }
        #endregion
        
        #region Parameter UpdateIpAddress
        /// <summary>
        /// <para>
        /// <para> Specifies the IPv6 address when you update the Resolver endpoint from IPv4 to dual-stack.
        /// If you don't specify an IPv6 address, one will be automatically chosen from your subnet.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateIpAddresses")]
        public Amazon.Route53Resolver.Model.UpdateIpAddress[] UpdateIpAddress { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResolverEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Resolver.Model.UpdateResolverEndpointResponse).
        /// Specifying the name of a property of type Amazon.Route53Resolver.Model.UpdateResolverEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResolverEndpoint";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResolverEndpointId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53RResolverEndpoint (UpdateResolverEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Resolver.Model.UpdateResolverEndpointResponse, UpdateR53RResolverEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Name = this.Name;
            if (this.Protocol != null)
            {
                context.Protocol = new List<System.String>(this.Protocol);
            }
            context.ResolverEndpointId = this.ResolverEndpointId;
            #if MODULAR
            if (this.ResolverEndpointId == null && ParameterWasBound(nameof(this.ResolverEndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResolverEndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResolverEndpointType = this.ResolverEndpointType;
            if (this.UpdateIpAddress != null)
            {
                context.UpdateIpAddress = new List<Amazon.Route53Resolver.Model.UpdateIpAddress>(this.UpdateIpAddress);
            }
            
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
            var request = new Amazon.Route53Resolver.Model.UpdateResolverEndpointRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocols = cmdletContext.Protocol;
            }
            if (cmdletContext.ResolverEndpointId != null)
            {
                request.ResolverEndpointId = cmdletContext.ResolverEndpointId;
            }
            if (cmdletContext.ResolverEndpointType != null)
            {
                request.ResolverEndpointType = cmdletContext.ResolverEndpointType;
            }
            if (cmdletContext.UpdateIpAddress != null)
            {
                request.UpdateIpAddresses = cmdletContext.UpdateIpAddress;
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
        
        private Amazon.Route53Resolver.Model.UpdateResolverEndpointResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.UpdateResolverEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "UpdateResolverEndpoint");
            try
            {
                #if DESKTOP
                return client.UpdateResolverEndpoint(request);
                #elif CORECLR
                return client.UpdateResolverEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public List<System.String> Protocol { get; set; }
            public System.String ResolverEndpointId { get; set; }
            public Amazon.Route53Resolver.ResolverEndpointType ResolverEndpointType { get; set; }
            public List<Amazon.Route53Resolver.Model.UpdateIpAddress> UpdateIpAddress { get; set; }
            public System.Func<Amazon.Route53Resolver.Model.UpdateResolverEndpointResponse, UpdateR53RResolverEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResolverEndpoint;
        }
        
    }
}
