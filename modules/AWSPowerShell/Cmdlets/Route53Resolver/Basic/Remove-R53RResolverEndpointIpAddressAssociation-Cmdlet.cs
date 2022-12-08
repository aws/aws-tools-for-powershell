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
    /// Removes IP addresses from an inbound or an outbound Resolver endpoint. If you want
    /// to remove more than one IP address, submit one <code>DisassociateResolverEndpointIpAddress</code>
    /// request for each IP address.
    /// 
    ///  
    /// <para>
    /// To add an IP address to an endpoint, see <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_route53resolver_AssociateResolverEndpointIpAddress.html">AssociateResolverEndpointIpAddress</a>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "R53RResolverEndpointIpAddressAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Route53Resolver.Model.ResolverEndpoint")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver DisassociateResolverEndpointIpAddress API operation.", Operation = new[] {"DisassociateResolverEndpointIpAddress"}, SelectReturnType = typeof(Amazon.Route53Resolver.Model.DisassociateResolverEndpointIpAddressResponse))]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.ResolverEndpoint or Amazon.Route53Resolver.Model.DisassociateResolverEndpointIpAddressResponse",
        "This cmdlet returns an Amazon.Route53Resolver.Model.ResolverEndpoint object.",
        "The service call response (type Amazon.Route53Resolver.Model.DisassociateResolverEndpointIpAddressResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveR53RResolverEndpointIpAddressAssociationCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        #region Parameter IpAddress
        /// <summary>
        /// <para>
        /// <para>The IPv4 address that you want to remove from a Resolver endpoint.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Route53Resolver.Model.IpAddressUpdate IpAddress { get; set; }
        #endregion
        
        #region Parameter ResolverEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the Resolver endpoint that you want to disassociate an IP address from.</para>
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
        public System.String ResolverEndpointId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResolverEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Resolver.Model.DisassociateResolverEndpointIpAddressResponse).
        /// Specifying the name of a property of type Amazon.Route53Resolver.Model.DisassociateResolverEndpointIpAddressResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResolverEndpoint";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IpAddress parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IpAddress' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IpAddress' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResolverEndpointId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-R53RResolverEndpointIpAddressAssociation (DisassociateResolverEndpointIpAddress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Resolver.Model.DisassociateResolverEndpointIpAddressResponse, RemoveR53RResolverEndpointIpAddressAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IpAddress;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.IpAddress = this.IpAddress;
            #if MODULAR
            if (this.IpAddress == null && ParameterWasBound(nameof(this.IpAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter IpAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResolverEndpointId = this.ResolverEndpointId;
            #if MODULAR
            if (this.ResolverEndpointId == null && ParameterWasBound(nameof(this.ResolverEndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResolverEndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53Resolver.Model.DisassociateResolverEndpointIpAddressRequest();
            
            if (cmdletContext.IpAddress != null)
            {
                request.IpAddress = cmdletContext.IpAddress;
            }
            if (cmdletContext.ResolverEndpointId != null)
            {
                request.ResolverEndpointId = cmdletContext.ResolverEndpointId;
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
        
        private Amazon.Route53Resolver.Model.DisassociateResolverEndpointIpAddressResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.DisassociateResolverEndpointIpAddressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "DisassociateResolverEndpointIpAddress");
            try
            {
                #if DESKTOP
                return client.DisassociateResolverEndpointIpAddress(request);
                #elif CORECLR
                return client.DisassociateResolverEndpointIpAddressAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Route53Resolver.Model.IpAddressUpdate IpAddress { get; set; }
            public System.String ResolverEndpointId { get; set; }
            public System.Func<Amazon.Route53Resolver.Model.DisassociateResolverEndpointIpAddressResponse, RemoveR53RResolverEndpointIpAddressAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResolverEndpoint;
        }
        
    }
}
