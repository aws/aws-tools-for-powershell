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
    /// Accepts a request to associate subnets with a transit gateway multicast domain.
    /// </summary>
    [Cmdlet("Approve", "EC2TransitGatewayMulticastDomainAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TransitGatewayMulticastDomainAssociations")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AcceptTransitGatewayMulticastDomainAssociations API operation.", Operation = new[] {"AcceptTransitGatewayMulticastDomainAssociations"}, SelectReturnType = typeof(Amazon.EC2.Model.AcceptTransitGatewayMulticastDomainAssociationsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayMulticastDomainAssociations or Amazon.EC2.Model.AcceptTransitGatewayMulticastDomainAssociationsResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGatewayMulticastDomainAssociations object.",
        "The service call response (type Amazon.EC2.Model.AcceptTransitGatewayMulticastDomainAssociationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ApproveEC2TransitGatewayMulticastDomainAssociationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets to associate with the transit gateway multicast domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter TransitGatewayAttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway attachment.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AcceptTransitGatewayMulticastDomainAssociationsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AcceptTransitGatewayMulticastDomainAssociationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Associations";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Approve-EC2TransitGatewayMulticastDomainAssociation (AcceptTransitGatewayMulticastDomainAssociations)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AcceptTransitGatewayMulticastDomainAssociationsResponse, ApproveEC2TransitGatewayMulticastDomainAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.EC2.Model.AcceptTransitGatewayMulticastDomainAssociationsRequest();
            
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
        
        private Amazon.EC2.Model.AcceptTransitGatewayMulticastDomainAssociationsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AcceptTransitGatewayMulticastDomainAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AcceptTransitGatewayMulticastDomainAssociations");
            try
            {
                #if DESKTOP
                return client.AcceptTransitGatewayMulticastDomainAssociations(request);
                #elif CORECLR
                return client.AcceptTransitGatewayMulticastDomainAssociationsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.EC2.Model.AcceptTransitGatewayMulticastDomainAssociationsResponse, ApproveEC2TransitGatewayMulticastDomainAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Associations;
        }
        
    }
}
