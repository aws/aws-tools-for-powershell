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
    /// Disassociates the specified subnets from the transit gateway multicast domain.
    /// </summary>
    [Cmdlet("Unregister", "EC2TransitGatewayMulticastDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TransitGatewayMulticastDomainAssociations")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DisassociateTransitGatewayMulticastDomain API operation.", Operation = new[] {"DisassociateTransitGatewayMulticastDomain"}, SelectReturnType = typeof(Amazon.EC2.Model.DisassociateTransitGatewayMulticastDomainResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayMulticastDomainAssociations or Amazon.EC2.Model.DisassociateTransitGatewayMulticastDomainResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGatewayMulticastDomainAssociations object.",
        "The service call response (type Amazon.EC2.Model.DisassociateTransitGatewayMulticastDomainResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UnregisterEC2TransitGatewayMulticastDomainCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets;</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter TransitGatewayAttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the attachment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransitGatewayAttachmentId { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Associations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DisassociateTransitGatewayMulticastDomainResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DisassociateTransitGatewayMulticastDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Associations";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-EC2TransitGatewayMulticastDomain (DisassociateTransitGatewayMulticastDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DisassociateTransitGatewayMulticastDomainResponse, UnregisterEC2TransitGatewayMulticastDomainCmdlet>(Select) ??
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
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            context.TransitGatewayAttachmentId = this.TransitGatewayAttachmentId;
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
            var request = new Amazon.EC2.Model.DisassociateTransitGatewayMulticastDomainRequest();
            
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
            }
            if (cmdletContext.TransitGatewayAttachmentId != null)
            {
                request.TransitGatewayAttachmentId = cmdletContext.TransitGatewayAttachmentId;
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
        
        private Amazon.EC2.Model.DisassociateTransitGatewayMulticastDomainResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DisassociateTransitGatewayMulticastDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DisassociateTransitGatewayMulticastDomain");
            try
            {
                #if DESKTOP
                return client.DisassociateTransitGatewayMulticastDomain(request);
                #elif CORECLR
                return client.DisassociateTransitGatewayMulticastDomainAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> SubnetId { get; set; }
            public System.String TransitGatewayAttachmentId { get; set; }
            public System.String TransitGatewayMulticastDomainId { get; set; }
            public System.Func<Amazon.EC2.Model.DisassociateTransitGatewayMulticastDomainResponse, UnregisterEC2TransitGatewayMulticastDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Associations;
        }
        
    }
}
